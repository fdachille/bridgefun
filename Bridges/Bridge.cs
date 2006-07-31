using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
  public class Bridge : ICloneable
  {
    #region fields

    private int m_numAnchorPoints = 0;

    private List<PointF> m_pins = new List<PointF>();

    private List<Spring> m_springs = new List<Spring>();

    private PointF [] m_pinForces = new PointF[0];

    private int m_numBrokenLinks = 0;

    private Spring m_pendingSpring = null;

    private PointF m_cursorPos = new PointF( 0f, 0f );

    private bool m_pinMode = false;

    private bool m_snapMode = true;

    private Spring m_currentSpringType = new LightSteel();

    #endregion

    #region properties

    public PointF CursorPos
    {
      set { m_cursorPos = value; }
    }

    public bool PinMode
    {
      get { return m_pinMode; }
      set { m_pinMode = value; }
    }

    public bool SnapMode
    {
      get { return m_snapMode; }
      set { m_snapMode = value; }
    }

    public int NumBrokenLinks
    {
      get { return m_numBrokenLinks; }
      set { m_numBrokenLinks = value; }
    }

    public Spring CurrentSpringType
    {
      get { return m_currentSpringType; }
      set { m_currentSpringType = value; }
    }

    public int NumAnchorPoints
    {
      get { return m_numAnchorPoints; }
      set { m_numAnchorPoints = value; }
    }

    public List<PointF> Pins
    {
      get { return m_pins; }
    }

    public int NumSprings
    {
      get { return m_springs.Count; }
    }

    #endregion

    #region construction

    public Bridge()
    {
      Load( MainForm.CurrentLevel );
    }

    #endregion

    #region methods

    public void Reset()
    {
      m_pins.Clear();
      m_springs.Clear();
      m_snapMode = true;
      m_pinMode = false;
      m_pendingSpring = null;
      m_numAnchorPoints = 0;
      m_numBrokenLinks = 0;
      m_currentSpringType = new LightSteel();
    }

    public void Load( Level level )
    {
      Reset();
      foreach( PointF pos in level.AnchorPoints )
        m_pins.Add( pos );
      m_pinForces = new PointF[ level.AnchorPoints.Count ];
      m_numAnchorPoints = level.AnchorPoints.Count;
    }

    private PointF SnapPoint( PointF pos )
    {
      if( m_snapMode )
      {
        const int snap = 20;
        return new PointF( snap * ( int ) ( pos.X / snap + 0.5F ), snap * ( int ) ( pos.Y / snap + 0.5F ) );
      }
      else
        return pos;
    }

    public void AddPin( PointF pos )
    {
      PointF snappedPos = SnapPoint( pos );
      float nearest = float.MaxValue;
      foreach( PointF pin in m_pins )
      {
        float distance = GetLength( new PointF( pin.X - snappedPos.X, pin.Y - snappedPos.Y ) );
        nearest = Math.Min( nearest, distance );
      }
      if( nearest > 10 )
        m_pins.Add( snappedPos );

      // make sure there are enough pin forces to go around
      if( m_pinForces.Length != m_pins.Count )
      {
        m_pinForces = new PointF [ m_pins.Count ];
        for( int i = 0; i < m_pinForces.Length; i++ )
        {
          m_pinForces [ i ].X = 0;
          m_pinForces [ i ].Y = 0;
        }
      }
    }

    public bool RemovePin( PointF pos )
    {
      bool removed = false;
      List<int> deadSprings = new List<int>();

      float nearestDistance;
      int nearest = GetNearestPin( pos, out nearestDistance );
      if( nearest >= m_numAnchorPoints && nearestDistance < 21 )
      {
        m_pins.RemoveAt( nearest );
        removed = true;
        foreach( Spring spring in m_springs )
        {
          bool dead = false;

          if( spring.StartPin == nearest )
            dead = true;
          else if( spring.StartPin > nearest )
            spring.StartPin--;

          if( spring.EndPin == nearest )
            dead = true;
          else if( spring.EndPin > nearest )
            spring.EndPin--;

          if( dead )
            deadSprings.Add( m_springs.IndexOf( spring ) );

        }
      }

      // remove dead springs
      for( int i = deadSprings.Count - 1; i >= 0; i-- )
      {
        m_springs.RemoveAt( deadSprings [ i ] );
      }

      return removed;
    }

    public void RemoveSpring( PointF pos )
    {
      if( m_pendingSpring != null )
        m_pendingSpring = null;
      else
      {
        bool removedPin = RemovePin( pos );
        if( !removedPin )
        {
          float nearestDistance;
          int nearest = GetNearestSpring( pos, out nearestDistance );
          if( nearest != -1 && nearestDistance < 21 )
          {
            m_springs.RemoveAt( nearest );
          }
        }
      }
    }

    /// <summary>
    /// Uses formula from http://mathworld.wolfram.com/Point-LineDistance2-Dimensional.html
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="nearestDistance"></param>
    /// <returns></returns>
    private int GetNearestSpring( PointF pos, out float nearestDistance )
    {
      int nearest = -1;
      nearestDistance = float.MaxValue;
      for( int i = 0; i < m_springs.Count; i++ )
      {
        float x0 = pos.X;
        float y0 = pos.Y;
        float x1 = m_pins[ m_springs[i].StartPin ].X;
        float y1 = m_pins[ m_springs[i].StartPin ].Y;
        float x2 = m_pins[ m_springs[i].EndPin ].X;
        float y2 = m_pins[ m_springs[i].EndPin ].Y;
        float distance = Math.Abs( ( x2 - x1 ) * ( y1 - y0 ) - ( x1 - x0 ) * ( y2 - y1 ) ) / GetLength( new PointF( x2 - x1, y2 - y1 ) );
        float distStart = GetLength( new PointF( x1 - x0, y1 - y0 ) );
        float distEnd = GetLength( new PointF( x2 - x0, y2 - y0 ) );
        float springLength = GetLength( new PointF( x2 - x1, y2 - y1 ) );
        if( distance < nearestDistance && distStart < springLength && distEnd < springLength )
        {
          nearestDistance = distance;
          nearest = i;
        }
      }
      return nearest;
    }

    private int GetNearestPin( PointF pos, out float nearestDistance )
    {
      int nearest = -1;
      nearestDistance = float.MaxValue;
      for( int i = 0; i < m_pins.Count; i++ )
      {
        float distance = ( float ) Math.Sqrt( Math.Pow( m_pins [ i ].X - pos.X, 2 ) + Math.Pow( m_pins [ i ].Y - pos.Y, 2 ) );
        if( distance < nearestDistance )
        {
          nearestDistance = distance;
          nearest = i;
        }
      }
      return nearest;
    }

    private float GetPinDistance( int pin1, int pin2 )
    {
      return ( float ) Math.Sqrt( Math.Pow( m_pins [ pin1 ].X - m_pins [ pin2 ].X, 2 ) + Math.Pow( m_pins [ pin1 ].Y - m_pins [ pin2 ].Y, 2 ) );
    }

    public void AddSpring( PointF pos )
    {
      float nearestDistance;
      int nearest = GetNearestPin( pos, out nearestDistance );
      if( m_pendingSpring == null )
      {
        if( nearest != -1 )
        {
          m_pendingSpring = (Spring) m_currentSpringType.Clone();
          m_pendingSpring.StartPin = nearest;
        }
      }
      else
      {
        float springLength = GetLength( new PointF( m_pins [ m_pendingSpring.StartPin ].X - SnapPoint( pos ).X, m_pins [ m_pendingSpring.StartPin ].Y - SnapPoint( pos ).Y ) );
        if( nearestDistance >= 20 && springLength < m_pendingSpring.MaxSpringLength )
        {
          AddPin( SnapPoint( pos ) );
          nearest = GetNearestPin( pos, out nearestDistance );
        }
        if ( nearest != -1 && nearestDistance < 20 )
        {
          bool alreadySpringThere = false;
          foreach( Spring spring in m_springs )
          {
            if( ( spring.StartPin == m_pendingSpring.StartPin && spring.EndPin == nearest ) ||
                ( spring.EndPin == m_pendingSpring.StartPin && spring.StartPin == nearest ) )
            {
              alreadySpringThere = true;
            }
          }
          float distance = GetPinDistance( m_pendingSpring.StartPin, nearest );
          if( distance > 0 && distance < m_pendingSpring.MaxSpringLength && !alreadySpringThere )
          {
            m_pendingSpring.EndPin = nearest;
            m_pendingSpring.m_restLength = distance;
            m_springs.Add( m_pendingSpring );
            m_pendingSpring = ( Spring ) m_currentSpringType.Clone();
            m_pendingSpring.StartPin = nearest;
          }
        }
      }
    }

    public void ClearUnusedPins()
    {

      List<bool> pinUsed = new List<bool>( m_pins.Count );
      foreach( PointF pin in m_pins )
        pinUsed.Add( false );

      foreach( Spring spring in m_springs )
      {
        pinUsed [ spring.StartPin ] = true;
        pinUsed [ spring.EndPin ] = true;
      }

      for( int i = pinUsed.Count - 1; i >= m_numAnchorPoints; i-- )
      {
        if( pinUsed [ i ] == false )
        {
          m_pins.RemoveAt( i );

          // slide down pin indices in springs
          for( int j = 0; j < m_springs.Count; j++ )
          {
            if( m_springs [ j ].StartPin > i )
              m_springs [ j ].StartPin--;
            if( m_springs [ j ].EndPin > i )
              m_springs [ j ].EndPin--;
          }
        }
      }

    }

    public void Paint( Graphics g )
    {
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
      g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

      // draw two main anchor points
      const float radius = 5;
      for ( int i = 0; i < 2 && i < m_numAnchorPoints; i++ )
      {
        PointF anchor = ( PointF ) m_pins [i];
        g.FillRectangle( Brushes.Goldenrod, anchor.X - radius, anchor.Y - radius, 2 * radius, 2 * radius );
      }

      // draw remaining anchor points
      for ( int i = 2; i < m_numAnchorPoints; i++ )
      {
        PointF anchor = ( PointF ) m_pins [i];
        g.FillRectangle( Brushes.White, anchor.X - radius, anchor.Y - radius, 2 * radius, 2 * radius );
      }

      // draw pins
      Color pinColor = Color.White;
      using( Brush pinBrush = new SolidBrush( pinColor ) )
      {
        for( int i = m_numAnchorPoints; i < m_pins.Count; i++ )
        {
          PointF pin = ( PointF ) m_pins [ i ];
          g.FillEllipse( pinBrush, pin.X - radius, pin.Y - radius, 2 * radius, 2 * radius );
        }
      }

      // draw springs
      const float penWidth = 3;
      foreach( Spring spring in m_springs )
      {
        float currentLength = GetPinDistance( spring.StartPin, spring.EndPin );
        float force = spring.GetTensionForce( currentLength );
        float width = penWidth;
        if( spring is Cable )
          width = 1;
        else if( spring is HeavySteel )
          width = 5;
        using( Pen springPen = new Pen( ForceColors.GetColor( force / spring.MaximumForce ), width ) )
        {
          g.DrawLine( springPen, m_pins [ spring.StartPin ], m_pins [ spring.EndPin ] );
        }
      }

      // draw pending pin
      if( m_pinMode )
      {
        using( Brush brush = new SolidBrush( Color.FromArgb( 128, pinColor ) ) )
        {
          g.FillEllipse( brush, m_cursorPos.X - radius, m_cursorPos.Y - radius, 2 * radius, 2 * radius );
        }
        g.DrawLine( Pens.White, m_cursorPos.X, m_cursorPos.Y, SnapPoint( m_cursorPos ).X, SnapPoint( m_cursorPos ).Y );
      }

      // draw pending spring
      else if( m_pendingSpring != null )
      {
        float distance = ( float ) Math.Sqrt( Math.Pow( m_pins [ m_pendingSpring.StartPin ].X - SnapPoint( m_cursorPos ).X, 2 ) + Math.Pow( m_pins [ m_pendingSpring.StartPin ].Y - SnapPoint( m_cursorPos ).Y, 2 ) );
        float width = penWidth;
        if( m_pendingSpring is Cable )
          width = 1;
        else if( m_pendingSpring is HeavySteel )
          width = 5;
        if( distance > m_pendingSpring.MaxSpringLength || CalculateCost() > MainForm.CurrentLevel.Budget )
        {
          using( Pen invalidPen = new Pen( Color.FromArgb( 128, 255, 0, 0 ), width ) )
            g.DrawLine( invalidPen, m_pins [ m_pendingSpring.StartPin ], SnapPoint( m_cursorPos ) );
        }
        else
        {
          using( Pen validPen = new Pen( Color.FromArgb( 128, 0, 255, 0 ), width ) )
            g.DrawLine( validPen, m_pins [ m_pendingSpring.StartPin ], SnapPoint( m_cursorPos ) );
        }
      }

      // draw forces
      using( Pen forcePen = new Pen( Color.White ) )
      {
        for( int i = 0; i < m_pins.Count; i++ )
        {
          PointF pin = ( PointF ) m_pins [ i ];
          const float scale = 20.0f;
          g.DrawLine( forcePen, pin.X, pin.Y, pin.X + m_pinForces [ i ].X * scale, pin.Y + m_pinForces [ i ].Y * scale );
        }
      }

    }

    private PointF GetNormal( PointF vector )
    {
      float length = ( float ) Math.Sqrt( Math.Pow( vector.X, 2 ) + Math.Pow( vector.Y, 2 ) );
      if( length == 0 )
        return vector;
      else
        return new PointF( vector.X / length, vector.Y / length );
    }

    private void CalculateForces()
    {

      // clear out the spring forces
      const float damping = 0.9f;
      for( int i = 0; i < m_pinForces.Length; i++ )
      {
        m_pinForces [ i ].X *= damping;
        m_pinForces [ i ].Y *= damping;
      }

      // apply gravity to pins
      foreach( Spring spring in m_springs )
      {
        float weight = Spring.Gravity * spring.WeightPerFoot * spring.m_restLength;
        m_pinForces [ spring.StartPin ].Y += weight / 2;
        m_pinForces [ spring.EndPin ].Y += weight / 2;
      }

      // stretch/shrink springs and accumulate forces at pins
      for( int i = m_springs.Count - 1; i >= 0; i-- )
      {
        Spring spring = m_springs [ i ];

        // calculate force and direction
        float currentLength = GetPinDistance( spring.StartPin, spring.EndPin );
        float tension = spring.GetTensionForce( currentLength );
        PointF direction = GetNormal( new PointF( m_pins [ spring.EndPin ].X - m_pins [ spring.StartPin ].X, m_pins [ spring.EndPin ].Y - m_pins [ spring.StartPin ].Y ) );
        float forceX = tension * direction.X;
        float forceY = tension * direction.Y;

        // potentially break spring
        if( Math.Abs( tension ) > spring.MaximumForce )
        {
          m_springs.RemoveAt( i );
          forceX = forceY = 0;
          m_numBrokenLinks++;
        }

        // accumulate first end
        m_pinForces [ spring.StartPin ].X += forceX;
        m_pinForces [ spring.StartPin ].Y += forceY;

        // accumulate second end
        m_pinForces [ spring.EndPin ].X -= forceX;
        m_pinForces [ spring.EndPin ].Y -= forceY;
      }

    }

    private float GetLength( PointF vector )
    {
      return ( float ) Math.Sqrt( Math.Pow( vector.X, 2 ) + Math.Pow( vector.Y, 2 ) );
    }

    public void Deflect()
    {
      // get maximum force
      CalculateForces();
      float maxForce = float.MinValue;
      foreach( PointF force in m_pinForces )
      {
        float forceMagnitude = GetLength( force );
        maxForce = Math.Max( maxForce, forceMagnitude );
      }

      // apply damped forces to pins
      const float tooFast = 0.1f;
      float damping = ( maxForce > tooFast ) ? tooFast / maxForce : 1.0f;
      damping *= 0.1f;
      for( int i = m_numAnchorPoints; i < m_pins.Count; i++ )
        m_pins [ i ] = new PointF( m_pins [ i ].X + m_pinForces [ i ].X * damping, m_pins [ i ].Y + m_pinForces [ i ].Y * damping );
    }

    public float CalculateCost()
    {

      // sum springs
      float cost = 0;
      foreach( Spring spring in m_springs )
        cost += spring.m_restLength * spring.CostPerFoot;

      // add pending
      if ( m_pendingSpring != null && m_pendingSpring.StartPin < m_pins.Count )
      {
        float x = m_pins[ m_pendingSpring.StartPin ].X - SnapPoint( m_cursorPos ).X;
        float y = m_pins[ m_pendingSpring.StartPin ].Y - SnapPoint( m_cursorPos ).Y;
        float pendingDistance = GetLength( new PointF( x, y ) );
        cost += pendingDistance * m_pendingSpring.CostPerFoot;
      }

      return cost;
    }

    public bool IsConnected( int startPin, int endPin, List<int> possibleSprings )
    {
      if ( possibleSprings.Count == 0 )
        return false;

      for ( int i = 0; i < possibleSprings.Count; i++ )
      {
        Spring testSpring = m_springs [possibleSprings [i]];
        if ( ( testSpring.StartPin == startPin && testSpring.EndPin == endPin ) ||
          ( testSpring.StartPin == endPin && testSpring.EndPin == startPin ) )
        {
          return true;
        }
        else
        {
          List<int> subsetSprings = new List<int>( possibleSprings );
          subsetSprings.RemoveAt( i );
          if ( testSpring.StartPin == startPin )
          {
            if ( IsConnected( testSpring.EndPin, endPin, subsetSprings ) )
              return true;
          }
          else if ( testSpring.EndPin == startPin )
          {
            if ( IsConnected( testSpring.StartPin, endPin, subsetSprings ) )
              return true;
          }
          else if ( testSpring.StartPin == endPin )
          {
            if ( IsConnected( startPin, testSpring.EndPin, subsetSprings ) )
              return true;
          }
          else if ( testSpring.EndPin == endPin )
          {
            if ( IsConnected( startPin, testSpring.StartPin, subsetSprings ) )
              return true;
          }
        }
      }

      return false;
    }

    #endregion

    #region ICloneable Members

    public object Clone()
    {
      Bridge newBridge = new Bridge();
      newBridge.m_cursorPos = m_cursorPos;
      newBridge.m_numAnchorPoints = m_numAnchorPoints;
      newBridge.m_pendingSpring = ( m_pendingSpring == null ) ? null : ( Spring ) m_pendingSpring.Clone();
      newBridge.m_pinMode = m_pinMode;
      newBridge.m_pins = new List<PointF>( m_pins );
      newBridge.m_pinForces = new PointF [ m_pinForces.Length ];
      for( int i = 0; i < m_pinForces.Length; i++ )
        newBridge.m_pinForces [ i ] = m_pinForces [ i ];
      newBridge.m_snapMode = m_snapMode;
      newBridge.m_springs = new List<Spring>( m_springs );
      newBridge.m_currentSpringType = (Spring) m_currentSpringType.Clone();
      return newBridge;
    }

    #endregion

  }
}
