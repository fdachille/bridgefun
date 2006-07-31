namespace Bridges
{
  partial class DesignForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label2 = new System.Windows.Forms.Label();
      this.m_backgroundImage = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.m_buttonSelectBackgroundImage = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label3 = new System.Windows.Forms.Label();
      this.m_levelName = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
      this.m_buttonSave = new System.Windows.Forms.Button();
      this.m_buttonCancel = new System.Windows.Forms.Button();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.m_budget = new System.Windows.Forms.NumericUpDown();
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel5.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      ( ( System.ComponentModel.ISupportInitialize ) ( this.m_budget ) ).BeginInit();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point( 3, 5 );
      this.label2.Margin = new System.Windows.Forms.Padding( 3, 5, 3, 0 );
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size( 99, 13 );
      this.label2.TabIndex = 3;
      this.label2.Text = "Background image:";
      // 
      // m_backgroundImage
      // 
      this.m_backgroundImage.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.m_backgroundImage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
      this.m_backgroundImage.Location = new System.Drawing.Point( 108, 3 );
      this.m_backgroundImage.Name = "m_backgroundImage";
      this.m_backgroundImage.ReadOnly = true;
      this.m_backgroundImage.Size = new System.Drawing.Size( 249, 20 );
      this.m_backgroundImage.TabIndex = 4;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel4, 0, 2 );
      this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel1, 0, 0 );
      this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel5, 0, 3 );
      this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel3, 0, 1 );
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point( 0, 0 );
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 4;
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 35F ) );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel2.Size = new System.Drawing.Size( 400, 135 );
      this.tableLayoutPanel2.TabIndex = 1;
      // 
      // tableLayoutPanel4
      // 
      this.tableLayoutPanel4.AutoSize = true;
      this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel4.ColumnCount = 3;
      this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel4.Controls.Add( this.label2, 0, 0 );
      this.tableLayoutPanel4.Controls.Add( this.m_backgroundImage, 1, 0 );
      this.tableLayoutPanel4.Controls.Add( this.m_buttonSelectBackgroundImage, 2, 0 );
      this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel4.Location = new System.Drawing.Point( 3, 70 );
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 1;
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel4.Size = new System.Drawing.Size( 398, 29 );
      this.tableLayoutPanel4.TabIndex = 1;
      // 
      // m_buttonSelectBackgroundImage
      // 
      this.m_buttonSelectBackgroundImage.Location = new System.Drawing.Point( 363, 3 );
      this.m_buttonSelectBackgroundImage.Name = "m_buttonSelectBackgroundImage";
      this.m_buttonSelectBackgroundImage.Size = new System.Drawing.Size( 32, 23 );
      this.m_buttonSelectBackgroundImage.TabIndex = 5;
      this.m_buttonSelectBackgroundImage.Text = "...";
      this.m_buttonSelectBackgroundImage.UseVisualStyleBackColor = true;
      this.m_buttonSelectBackgroundImage.Click += new System.EventHandler( this.m_buttonSelectBackgroundImage_Click );
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel1.Controls.Add( this.label3, 0, 0 );
      this.tableLayoutPanel1.Controls.Add( this.m_levelName, 1, 0 );
      this.tableLayoutPanel1.Location = new System.Drawing.Point( 3, 3 );
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel1.Size = new System.Drawing.Size( 398, 26 );
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point( 3, 5 );
      this.label3.Margin = new System.Windows.Forms.Padding( 3, 5, 3, 0 );
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size( 75, 13 );
      this.label3.TabIndex = 0;
      this.label3.Text = "Name of level:";
      // 
      // m_levelName
      // 
      this.m_levelName.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.m_levelName.Location = new System.Drawing.Point( 84, 3 );
      this.m_levelName.Name = "m_levelName";
      this.m_levelName.Size = new System.Drawing.Size( 311, 20 );
      this.m_levelName.TabIndex = 1;
      this.m_levelName.TextChanged += new System.EventHandler( this.m_levelName_TextChanged );
      // 
      // tableLayoutPanel5
      // 
      this.tableLayoutPanel5.AutoSize = true;
      this.tableLayoutPanel5.ColumnCount = 2;
      this.tableLayoutPanel5.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel5.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel5.Controls.Add( this.m_buttonSave, 0, 0 );
      this.tableLayoutPanel5.Controls.Add( this.m_buttonCancel, 1, 0 );
      this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel5.Location = new System.Drawing.Point( 3, 105 );
      this.tableLayoutPanel5.Name = "tableLayoutPanel5";
      this.tableLayoutPanel5.RowCount = 1;
      this.tableLayoutPanel5.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel5.Size = new System.Drawing.Size( 398, 29 );
      this.tableLayoutPanel5.TabIndex = 4;
      // 
      // m_buttonSave
      // 
      this.m_buttonSave.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.m_buttonSave.Enabled = false;
      this.m_buttonSave.Location = new System.Drawing.Point( 121, 3 );
      this.m_buttonSave.Name = "m_buttonSave";
      this.m_buttonSave.Size = new System.Drawing.Size( 75, 23 );
      this.m_buttonSave.TabIndex = 0;
      this.m_buttonSave.Text = "Save";
      this.m_buttonSave.UseVisualStyleBackColor = true;
      this.m_buttonSave.Click += new System.EventHandler( this.m_buttonSave_Click );
      // 
      // m_buttonCancel
      // 
      this.m_buttonCancel.Location = new System.Drawing.Point( 202, 3 );
      this.m_buttonCancel.Name = "m_buttonCancel";
      this.m_buttonCancel.Size = new System.Drawing.Size( 75, 23 );
      this.m_buttonCancel.TabIndex = 1;
      this.m_buttonCancel.Text = "Cancel";
      this.m_buttonCancel.UseVisualStyleBackColor = true;
      this.m_buttonCancel.Click += new System.EventHandler( this.m_buttonCancel_Click );
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.AutoSize = true;
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel3.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel3.Controls.Add( this.label1, 0, 0 );
      this.tableLayoutPanel3.Controls.Add( this.m_budget, 1, 0 );
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point( 3, 35 );
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel3.Size = new System.Drawing.Size( 398, 29 );
      this.tableLayoutPanel3.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point( 3, 5 );
      this.label1.Margin = new System.Windows.Forms.Padding( 3, 5, 3, 0 );
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size( 59, 13 );
      this.label1.TabIndex = 0;
      this.label1.Text = "Budget ($):";
      // 
      // m_budget
      // 
      this.m_budget.Increment = new decimal( new int [] {
            1000,
            0,
            0,
            0} );
      this.m_budget.Location = new System.Drawing.Point( 68, 3 );
      this.m_budget.Maximum = new decimal( new int [] {
            1000000000,
            0,
            0,
            0} );
      this.m_budget.Minimum = new decimal( new int [] {
            1000,
            0,
            0,
            0} );
      this.m_budget.Name = "m_budget";
      this.m_budget.Size = new System.Drawing.Size( 120, 20 );
      this.m_budget.TabIndex = 1;
      this.m_budget.ThousandsSeparator = true;
      this.m_budget.Value = new decimal( new int [] {
            20000,
            0,
            0,
            0} );
      // 
      // DesignForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 400, 135 );
      this.ControlBox = false;
      this.Controls.Add( this.tableLayoutPanel2 );
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Name = "DesignForm";
      this.Text = "Design a level...";
      this.tableLayoutPanel2.ResumeLayout( false );
      this.tableLayoutPanel2.PerformLayout();
      this.tableLayoutPanel4.ResumeLayout( false );
      this.tableLayoutPanel4.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout( false );
      this.tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel5.ResumeLayout( false );
      this.tableLayoutPanel3.ResumeLayout( false );
      this.tableLayoutPanel3.PerformLayout();
      ( ( System.ComponentModel.ISupportInitialize ) ( this.m_budget ) ).EndInit();
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox m_backgroundImage;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    private System.Windows.Forms.Button m_buttonSelectBackgroundImage;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox m_levelName;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    private System.Windows.Forms.Button m_buttonSave;
    private System.Windows.Forms.Button m_buttonCancel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown m_budget;

  }
}