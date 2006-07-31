using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bridges
{
  public partial class MainForm : Form
  {
    private static Level m_currentLevel = new Level1();
    private List<Level> m_availableLevels = Level.GetLevels();
    private static Bridge m_bridge = new Bridge();
    private Bridge m_staticBridge = null;
    TextureBrush m_textureBrush = null;
    Image m_currentBackgroundImage = null;
    private System.ComponentModel.BackgroundWorker m_backgroundWorker = new System.ComponentModel.BackgroundWorker();
    private FramePerSecond m_paintFps = new FramePerSecond();
    static readonly int m_snapSize = 20;
    bool m_helpShown = false;
    bool m_designMode = false;

    public static Level CurrentLevel
    {
      get { return m_currentLevel; }
    }

    public static Bridge Bridge
    {
      get { return m_bridge; }
    }

    public MainForm()
    {
      InitializeComponent();
      this.DoubleBuffered = true;

      // initialize the background worker
      m_backgroundWorker.WorkerReportsProgress = true;
      m_backgroundWorker.WorkerSupportsCancellation = true;
      m_backgroundWorker.DoWork += new DoWorkEventHandler( m_backgroundWorker_DoWork );
      m_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( m_backgroundWorker_RunWorkerCompleted );
      m_backgroundWorker.ProgressChanged += new ProgressChangedEventHandler( m_backgroundWorker_ProgressChanged );

      // initialize the levels
      m_levelSelection.Items.Clear();
      foreach ( Level level in m_availableLevels )
      {
        m_levelSelection.Items.Add( level.Name );
      }
      m_levelSelection.Items.Add( "Build your own" );
    }

    protected override void OnPaint( PaintEventArgs e )
    {

      base.OnPaint( e );

      // check the current background image
      if ( m_currentLevel.BackgroundImage != m_currentBackgroundImage )
      {
        m_currentBackgroundImage = m_currentLevel.BackgroundImage;
        m_textureBrush = null;
      }

      // create a background texture
      if ( m_textureBrush == null )
      {
        if ( m_currentBackgroundImage == null )
        {
          Bitmap image = new Bitmap( m_snapSize, m_snapSize );
          Graphics graphics = Graphics.FromImage( image );
          graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          graphics.Clear( Color.FromArgb( 0, 0, 128 ) );
          using ( Pen pen = new Pen( Color.FromArgb( 0, 0, 164 ) ) )
          {
            graphics.DrawLine( pen, 0, 0, m_snapSize, 0 );
            graphics.DrawLine( pen, 0, 0, 0, m_snapSize );
          }
          m_textureBrush = new TextureBrush( image );
          m_textureBrush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
        }
        else
        {
          Bitmap image = new Bitmap( m_currentBackgroundImage );
          Graphics graphics = Graphics.FromImage( image );
          using ( Brush brush = new SolidBrush( Color.FromArgb( 128, Color.Gray ) ) )
            graphics.FillRectangle( brush, graphics.VisibleClipBounds );
          graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
          graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
          using ( Pen pen = new Pen( Color.FromArgb( 128, 0, 0, 164 ) ) )
          {
            for ( int x = 0; x < image.Width; x += m_snapSize )
              graphics.DrawLine( pen, x, 0, x, image.Height - 1 );
            for ( int y = 0; y < image.Height; y += m_snapSize )
              graphics.DrawLine( pen, 0, y, image.Width - 1, y );
          }
          m_textureBrush = new TextureBrush( image );
          m_textureBrush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
        }
      }

      // draw the background
      e.Graphics.FillRectangle( m_textureBrush, 0, 0, this.Width, this.Height );

      // draw the bridge
      m_bridge.Paint( e.Graphics );

      // sample the statistics
      m_paintFps.SampleTime();

      // show help
      if ( m_helpShown == false )
      {
        m_helpShown = true;
        AboutBox about = new AboutBox();
        about.Show();
      }

    }

    private void MainForm_MouseClick( object sender, MouseEventArgs e )
    {

      if ( m_backgroundWorker.IsBusy )
        return;

      PointF position = new PointF( e.X, e.Y );
      if ( e.Button == MouseButtons.Left )
      {
        float cost = m_bridge.CalculateCost();
        if ( cost < MainForm.CurrentLevel.Budget )
        {
          if ( m_bridge.PinMode )
          {
            m_bridge.AddPin( position );
            if ( m_designMode )
              m_bridge.NumAnchorPoints = m_bridge.Pins.Count;
          }
          else
          {
            m_bridge.AddSpring( position );
          }
        }
      }
      if ( e.Button == MouseButtons.Right )
      {
        if ( m_bridge.PinMode )
        {
          if ( m_designMode )
          {
            m_bridge.NumAnchorPoints = 0;
            m_bridge.RemovePin( position );
            m_bridge.NumAnchorPoints = m_bridge.Pins.Count;
          }
          else
          {
            m_bridge.RemovePin( position );
          }
        }
        else
          m_bridge.RemoveSpring( position );
      }

      // make sure it is fully connected
      List<int> allSprings = new List<int>( m_bridge.NumSprings );
      for ( int i = 0; i < m_bridge.NumSprings; i++ )
        allSprings.Add( i );
      m_testButton.Enabled = m_bridge.IsConnected( 0, 1, allSprings );

      UpdateStatus();
      Invalidate();
    }

    private void m_pinTool_Click( object sender, EventArgs e )
    {
      m_bridge.PinMode = m_pinTool.Checked = true;
      m_lightSteelTool.Checked = false;
      m_heavySteelTool.Checked = false;
      m_cableTool.Checked = false;
    }

    private void m_lightSteelTool_Click( object sender, EventArgs e )
    {
      m_bridge.PinMode = m_pinTool.Checked = false;
      m_lightSteelTool.Checked = true;
      m_heavySteelTool.Checked = false;
      m_cableTool.Checked = false;
      m_bridge.CurrentSpringType = new LightSteel();
    }

    private void m_heavySteelTool_Click( object sender, EventArgs e )
    {
      m_bridge.PinMode = m_pinTool.Checked = false;
      m_lightSteelTool.Checked = false;
      m_heavySteelTool.Checked = true;
      m_cableTool.Checked = false;
      m_bridge.CurrentSpringType = new HeavySteel();
    }

    private void m_cableButton_Click( object sender, EventArgs e )
    {
      m_bridge.PinMode = m_pinTool.Checked = false;
      m_lightSteelTool.Checked = false;
      m_heavySteelTool.Checked = false;
      m_cableTool.Checked = true;
      m_bridge.CurrentSpringType = new Cable();
    }

    private void MainForm_MouseMove( object sender, MouseEventArgs e )
    {
      m_bridge.CursorPos = new PointF( e.X, e.Y );
      UpdateStatus();
      Invalidate();
    }

    private void m_snapTool_Click( object sender, EventArgs e )
    {
      m_snapTool.Checked = m_bridge.SnapMode = !m_bridge.SnapMode;
    }

    private void UpdateStatus()
    {
      // price check aisle three
      float cost = m_bridge.CalculateCost();
      m_statusLabel.Text = string.Format( "Cost: ${0} out of ${1}", ( int ) cost, ( int ) MainForm.CurrentLevel.Budget );
      if ( m_bridge.NumBrokenLinks > 0 )
        m_statusLabel.Text += string.Format( ", {0} broken links", m_bridge.NumBrokenLinks );
      if ( m_paintFps.FramesPerSecond != 0 )
        m_statusLabel.Text += string.Format( ", {0} fps drawing", Math.Round( m_paintFps.FramesPerSecond, 1 ) );
      if ( m_designMode )
        m_statusLabel.Text += ", Design mode";
    }

    private void m_resetButton_Click( object sender, EventArgs e )
    {
      Reset();
    }

    private void Reset()
    {
      m_bridge.PinMode = false;
      m_pinTool.Checked = false;
      m_lightSteelTool.Checked = true;
      m_heavySteelTool.Checked = false;
      m_cableTool.Checked = false;
      m_bridge.CurrentSpringType = new LightSteel();
      m_bridge.SnapMode = true;
      m_snapTool.Checked = true;
      m_bridge = new Bridge();

      if ( m_designMode )
      {
        m_pinTool.Enabled = m_pinTool.Checked = true;
        m_lightSteelTool.Enabled = m_lightSteelTool.Checked = false;
        m_heavySteelTool.Enabled = m_heavySteelTool.Checked = false;
        m_cableTool.Enabled = m_cableTool.Checked = false;
        m_bridge.PinMode = true;
      }

      Invalidate();
    }

    private void m_levelSelection_SelectedIndexChanged( object sender, EventArgs e )
    {

      if ( m_levelSelection.SelectedIndex == m_availableLevels.Count )
      {
        m_currentLevel = new MyLevel();
        m_designMode = true;
        DesignForm form = new DesignForm();
        form.Show();
      }
      else
      {
        m_designMode = false;
        m_currentLevel = (Level) m_availableLevels[ m_levelSelection.SelectedIndex ].Clone();
      }

      Reset();
    }

    private void m_testButton_Click( object sender, EventArgs e )
    {
      m_progressBar.Visible = true;
      m_testButton.Enabled = false;
      m_stopButton.Enabled = true;
      m_resetButton.Enabled = false;
      m_levelSelection.Enabled = false;
      m_bridge.ClearUnusedPins();
      m_bridge.NumBrokenLinks = 0;
      m_staticBridge = ( Bridge ) m_bridge.Clone();
      m_backgroundWorker.RunWorkerAsync();
    }

    private void m_stopButton_Click( object sender, EventArgs e )
    {
      m_backgroundWorker.CancelAsync();
    }

    private void m_helpButton_Click( object sender, EventArgs e )
    {
      AboutBox about = new AboutBox();
      about.Show();
    }

    #region background worker implementation

    // This event handler is where the actual,
    // potentially time-consuming work is done.
    private void m_backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
    {
      // Get the BackgroundWorker that raised this event.
      BackgroundWorker worker = sender as BackgroundWorker;

      // Assign the result of the computation
      // to the Result property of the DoWorkEventArgs
      // object. This is will be available to the 
      // RunWorkerCompleted eventhandler.
      //e.Result = Simulate( worker, e );

      // we have to throttle the computation to wait for the
      // drawing to complete. We would like the ReportProgress
      // to be a synchronous call, but it is not. So we set
      // the progress percentage to be a unique value and
      // wait for the main thread to complete the drawing
      // and signal us by setting the same value in a shared
      // variable (we'll use the m_progressBar.Value for this
      // purpose).

      int percentComplete = 1;

      while ( !worker.CancellationPending )
      {
        for ( int j = 0; j < 100; j++ )
          m_bridge.Deflect();

        worker.ReportProgress( percentComplete );

        // poll for up to one second before going again
        for ( int i = 0; i < 100 && m_progressBar.Value != percentComplete; i++ )
          System.Threading.Thread.Sleep( 1 );

        percentComplete++;
        if ( percentComplete >= m_progressBar.Maximum )
          percentComplete = m_progressBar.Minimum;
      }

      e.Cancel = true;
    }

    // This event handler deals with the results of the
    // background operation.
    private void m_backgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
    {
      // First, handle the case where an exception was thrown.
      if ( e.Error != null )
      {
        MessageBox.Show( e.Error.Message );
      }
      else if ( e.Cancelled )
      {
        // Next, handle the case where the user canceled 
        // the operation.
        // Note that due to a race condition in 
        // the DoWork event handler, the Cancelled
        // flag may not have been set, even though
        // CancelAsync was called.
        //resultLabel.Text = "Canceled";
      }
      else
      {
        // Finally, handle the case where the operation 
        // succeeded.
        //resultLabel.Text = e.Result.ToString();
      }

      m_bridge = m_staticBridge;
      Invalidate();

      m_progressBar.Visible = false;
      m_testButton.Enabled = true;
      m_stopButton.Enabled = false;
      m_resetButton.Enabled = true;
      m_levelSelection.Enabled = true;
    }

    // This event handler updates the progress bar.
    private void m_backgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e )
    {
      Invalidate();
      Update();
      UpdateStatus();

      // signal the thread to start computing
      m_progressBar.Value = e.ProgressPercentage;
    }

    // This is the method that does the actual work. For this
    // example, it computes a Fibonacci number and
    // reports progress as it does its work.
    void Simulate( BackgroundWorker worker, DoWorkEventArgs e )
    {

      // Abort the operation if the user has canceled.
      // Note that a call to CancelAsync may have set 
      // CancellationPending to true just after the
      // last invocation of this method exits, so this 
      // code will not have the opportunity to set the 
      // DoWorkEventArgs.Cancel flag to true. This means
      // that RunWorkerCompletedEventArgs.Cancelled will
      // not be set to true in your RunWorkerCompleted
      // event handler. This is a race condition.
      //if( worker.CancellationPending )
      //{
      //  e.Cancel = true;
      //}


    }

    #endregion

  }
}