using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Bridges
{
  public partial class DesignForm : Form
  {
    public DesignForm()
    {
      InitializeComponent();
    }

    private void m_buttonSelectBackgroundImage_Click( object sender, EventArgs e )
    {
      System.Windows.Forms.FileDialog dialog = new System.Windows.Forms.OpenFileDialog();
      dialog.CheckFileExists = true;
      dialog.DefaultExt = "jpg";
      dialog.Filter = "Image files (*.jpg)|*.jpg";
      if ( dialog.ShowDialog() == DialogResult.OK )
      {
        if ( File.Exists( dialog.FileName ) )
        {
          m_backgroundImage.Text = dialog.FileName;
          if ( m_levelName.Text.Length > 0 )
            m_buttonSave.Enabled = true;
        }
        else
        {
          m_buttonSave.Enabled = false;
        }
      }
    }

    private void m_buttonSave_Click( object sender, EventArgs e )
    {
      // create the folder
      string newLevelFolder = Path.Combine( Level.GetLevelFolder(), m_levelName.Text );
      if ( System.IO.Directory.Exists( newLevelFolder ) )
      {
        System.Windows.Forms.MessageBox.Show( "That level name already exists; please choose another and try again." );
        return;
      }
      Directory.CreateDirectory( newLevelFolder );
      File.Copy( m_backgroundImage.Text, Path.Combine( newLevelFolder, "background.jpg" ) );

      // create the level
      Level outputLevel = new Level();
      outputLevel.AnchorPoints.AddRange( MainForm.Bridge.Pins );
      outputLevel.BackgroundImage = System.Drawing.Bitmap.FromFile( m_backgroundImage.Text );
      outputLevel.Budget = (float) m_budget.Value;
      outputLevel.Name = m_levelName.Text;

      // write the level XML
      TextWriter writer = new StreamWriter( new FileStream( Path.Combine( newLevelFolder, "level.xml.jpg" ), FileMode.Create ) );
      XmlSerializer levelXml = new XmlSerializer( typeof( Level ) );
      levelXml.Serialize( writer, outputLevel );
      writer.Close();

      System.Windows.Forms.MessageBox.Show( "The level has been saved. The next time you open the application it will be available.",
        "Level Saved", MessageBoxButtons.OK, MessageBoxIcon.Information );

      this.Close();
    }

    private void m_buttonCancel_Click( object sender, EventArgs e )
    {
      this.Close();
    }

    private void m_levelName_TextChanged( object sender, EventArgs e )
    {
      if ( m_levelName.Text.Length > 0 &&
        m_backgroundImage.Text.Length > 0 &&
        File.Exists( m_backgroundImage.Text ) )
      {
        m_buttonSave.Enabled = true;
      }
      else
      {
        m_buttonSave.Enabled = false;
      }
    }

  }
}