namespace Bridges
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
          this.toolStrip1 = new System.Windows.Forms.ToolStrip();
          this.m_testButton = new System.Windows.Forms.ToolStripButton();
          this.m_stopButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
          this.m_resetButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.m_levelSelection = new System.Windows.Forms.ToolStripComboBox();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.m_pinTool = new System.Windows.Forms.ToolStripButton();
          this.m_lightSteelTool = new System.Windows.Forms.ToolStripButton();
          this.m_heavySteelTool = new System.Windows.Forms.ToolStripButton();
          this.m_cableTool = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.m_snapTool = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
          this.m_helpButton = new System.Windows.Forms.ToolStripButton();
          this.m_statusStrip = new System.Windows.Forms.StatusStrip();
          this.m_progressBar = new System.Windows.Forms.ToolStripProgressBar();
          this.m_statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
          this.toolStrip1.SuspendLayout();
          this.m_statusStrip.SuspendLayout();
          this.SuspendLayout();
          // 
          // toolStrip1
          // 
          this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem [] {
            this.m_testButton,
            this.m_stopButton,
            this.toolStripSeparator4,
            this.m_resetButton,
            this.toolStripSeparator2,
            this.m_levelSelection,
            this.toolStripSeparator3,
            this.m_pinTool,
            this.m_lightSteelTool,
            this.m_heavySteelTool,
            this.m_cableTool,
            this.toolStripSeparator1,
            this.m_snapTool,
            this.toolStripSeparator5,
            this.m_helpButton} );
          this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
          this.toolStrip1.Name = "toolStrip1";
          this.toolStrip1.Size = new System.Drawing.Size( 539, 25 );
          this.toolStrip1.TabIndex = 1;
          this.toolStrip1.Text = "toolStrip1";
          // 
          // m_testButton
          // 
          this.m_testButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_testButton.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_testButton.Image" ) ) );
          this.m_testButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_testButton.Name = "m_testButton";
          this.m_testButton.Size = new System.Drawing.Size( 32, 22 );
          this.m_testButton.Text = "Test";
          this.m_testButton.Click += new System.EventHandler( this.m_testButton_Click );
          // 
          // m_stopButton
          // 
          this.m_stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_stopButton.Enabled = false;
          this.m_stopButton.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_stopButton.Image" ) ) );
          this.m_stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_stopButton.Name = "m_stopButton";
          this.m_stopButton.Size = new System.Drawing.Size( 33, 22 );
          this.m_stopButton.Text = "Stop";
          this.m_stopButton.Click += new System.EventHandler( this.m_stopButton_Click );
          // 
          // toolStripSeparator4
          // 
          this.toolStripSeparator4.Name = "toolStripSeparator4";
          this.toolStripSeparator4.Size = new System.Drawing.Size( 6, 25 );
          // 
          // m_resetButton
          // 
          this.m_resetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_resetButton.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_resetButton.Image" ) ) );
          this.m_resetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_resetButton.Name = "m_resetButton";
          this.m_resetButton.Size = new System.Drawing.Size( 39, 22 );
          this.m_resetButton.Text = "Reset";
          this.m_resetButton.Click += new System.EventHandler( this.m_resetButton_Click );
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size( 6, 25 );
          // 
          // m_levelSelection
          // 
          this.m_levelSelection.Items.AddRange( new object [] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5",
            "Level 6",
            "Build Your Own"} );
          this.m_levelSelection.Name = "m_levelSelection";
          this.m_levelSelection.Size = new System.Drawing.Size( 100, 25 );
          this.m_levelSelection.Text = "Level 1";
          this.m_levelSelection.SelectedIndexChanged += new System.EventHandler( this.m_levelSelection_SelectedIndexChanged );
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          this.toolStripSeparator3.Size = new System.Drawing.Size( 6, 25 );
          // 
          // m_pinTool
          // 
          this.m_pinTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_pinTool.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_pinTool.Image" ) ) );
          this.m_pinTool.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_pinTool.Name = "m_pinTool";
          this.m_pinTool.Size = new System.Drawing.Size( 25, 22 );
          this.m_pinTool.Text = "Pin";
          this.m_pinTool.Click += new System.EventHandler( this.m_pinTool_Click );
          // 
          // m_lightSteelTool
          // 
          this.m_lightSteelTool.Checked = true;
          this.m_lightSteelTool.CheckState = System.Windows.Forms.CheckState.Checked;
          this.m_lightSteelTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_lightSteelTool.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_lightSteelTool.Image" ) ) );
          this.m_lightSteelTool.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_lightSteelTool.Name = "m_lightSteelTool";
          this.m_lightSteelTool.Size = new System.Drawing.Size( 60, 22 );
          this.m_lightSteelTool.Text = "Light steel";
          this.m_lightSteelTool.Click += new System.EventHandler( this.m_lightSteelTool_Click );
          // 
          // m_heavySteelTool
          // 
          this.m_heavySteelTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_heavySteelTool.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_heavySteelTool.Image" ) ) );
          this.m_heavySteelTool.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_heavySteelTool.Name = "m_heavySteelTool";
          this.m_heavySteelTool.Size = new System.Drawing.Size( 69, 22 );
          this.m_heavySteelTool.Text = "Heavy Steel";
          this.m_heavySteelTool.Click += new System.EventHandler( this.m_heavySteelTool_Click );
          // 
          // m_cableTool
          // 
          this.m_cableTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_cableTool.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_cableTool.Image" ) ) );
          this.m_cableTool.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_cableTool.Name = "m_cableTool";
          this.m_cableTool.Size = new System.Drawing.Size( 38, 22 );
          this.m_cableTool.Text = "Cable";
          this.m_cableTool.Click += new System.EventHandler( this.m_cableButton_Click );
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
          // 
          // m_snapTool
          // 
          this.m_snapTool.Checked = true;
          this.m_snapTool.CheckState = System.Windows.Forms.CheckState.Checked;
          this.m_snapTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_snapTool.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_snapTool.Image" ) ) );
          this.m_snapTool.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_snapTool.Name = "m_snapTool";
          this.m_snapTool.Size = new System.Drawing.Size( 35, 22 );
          this.m_snapTool.Text = "Snap";
          this.m_snapTool.Click += new System.EventHandler( this.m_snapTool_Click );
          // 
          // toolStripSeparator5
          // 
          this.toolStripSeparator5.Name = "toolStripSeparator5";
          this.toolStripSeparator5.Size = new System.Drawing.Size( 6, 25 );
          // 
          // m_helpButton
          // 
          this.m_helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.m_helpButton.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "m_helpButton.Image" ) ) );
          this.m_helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.m_helpButton.Name = "m_helpButton";
          this.m_helpButton.Size = new System.Drawing.Size( 32, 22 );
          this.m_helpButton.Text = "Help";
          this.m_helpButton.Click += new System.EventHandler( this.m_helpButton_Click );
          // 
          // m_statusStrip
          // 
          this.m_statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem [] {
            this.m_progressBar,
            this.m_statusLabel} );
          this.m_statusStrip.Location = new System.Drawing.Point( 0, 489 );
          this.m_statusStrip.Name = "m_statusStrip";
          this.m_statusStrip.Size = new System.Drawing.Size( 539, 22 );
          this.m_statusStrip.TabIndex = 2;
          this.m_statusStrip.Text = "statusStrip1";
          // 
          // m_progressBar
          // 
          this.m_progressBar.Name = "m_progressBar";
          this.m_progressBar.Size = new System.Drawing.Size( 100, 16 );
          this.m_progressBar.Step = 1;
          this.m_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
          this.m_progressBar.Visible = false;
          // 
          // m_statusLabel
          // 
          this.m_statusLabel.Name = "m_statusLabel";
          this.m_statusLabel.Size = new System.Drawing.Size( 38, 17 );
          this.m_statusLabel.Text = "Ready";
          // 
          // MainForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size( 539, 511 );
          this.Controls.Add( this.m_statusStrip );
          this.Controls.Add( this.toolStrip1 );
          this.Name = "MainForm";
          this.Text = "Bridges";
          this.MouseClick += new System.Windows.Forms.MouseEventHandler( this.MainForm_MouseClick );
          this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.MainForm_MouseMove );
          this.toolStrip1.ResumeLayout( false );
          this.toolStrip1.PerformLayout();
          this.m_statusStrip.ResumeLayout( false );
          this.m_statusStrip.PerformLayout();
          this.ResumeLayout( false );
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton m_pinTool;
      private System.Windows.Forms.ToolStripButton m_lightSteelTool;
      private System.Windows.Forms.ToolStripButton m_snapTool;
      private System.Windows.Forms.StatusStrip m_statusStrip;
      private System.Windows.Forms.ToolStripStatusLabel m_statusLabel;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton m_resetButton;
      private System.Windows.Forms.ToolStripComboBox m_levelSelection;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton m_testButton;
      private System.Windows.Forms.ToolStripProgressBar m_progressBar;
      private System.Windows.Forms.ToolStripButton m_stopButton;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripButton m_cableTool;
      private System.Windows.Forms.ToolStripButton m_heavySteelTool;
      private System.Windows.Forms.ToolStripButton m_helpButton;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

