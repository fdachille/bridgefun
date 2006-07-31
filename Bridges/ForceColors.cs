using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
  public static class ForceColors
  {
    #region fields

    private static readonly int m_numColors = 100;
    private static Color [] m_colors = new Color [ m_numColors ];

    #endregion

    #region construction

    static ForceColors()
    {
      for( int i = 0; i < m_numColors; i++ )
      {
        int halfway = m_numColors / 2;
        if( i <= halfway )
        {
          float alpha = ( float ) i / halfway;
          int green = ( int ) ( 255 * alpha );
          int blue = ( int ) ( 255 * ( 1 - alpha ) );
          m_colors [ i ] = Color.FromArgb( 0, green, blue );
        }
        else
        {
          float alpha = ( float ) ( i - halfway ) / halfway;
          int red = ( int ) ( 255 * alpha );
          int green = ( int ) ( 255 * ( 1 - alpha ) );
          m_colors [ i ] = Color.FromArgb( red, green, 0 );
        }
      }
    }

    #endregion

    #region methods

    /// <summary>
    /// Get the color associated with the input force
    /// </summary>
    /// <param name="inputForce">1 is maximum tension, -1 is maximum compression, anything outside is clamped</param>
    /// <returns></returns>
    public static Color GetColor( float inputForce )
    {

      int index = ( int ) ( ( inputForce + 1 ) * 0.5f * m_numColors );

      if( index < 0 )
        index = 0;

      if( index > m_numColors - 1 )
        index = m_numColors - 1;

      return m_colors [ index ];

    }

    #endregion

  }
}
