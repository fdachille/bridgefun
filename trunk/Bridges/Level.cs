using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Bridges
{
  [ Serializable ]
  public class Level : ICloneable
  {
    #region fields

    protected List<PointF> m_anchorPoints = new List<PointF>();

    protected float m_budget = 0;

    protected Image m_backgroundImage = null;

    protected string m_name = string.Empty;

    #endregion

    #region properties

    public List<PointF> AnchorPoints
    {
      get { return m_anchorPoints; }
      set { m_anchorPoints = value; }
    }

    public float Budget
    {
      get { return m_budget; }
      set { m_budget = value; ; }
    }

    [ XmlIgnore ]
    public Image BackgroundImage
    {
      get { return m_backgroundImage; }
      set { m_backgroundImage = value; }
    }

    public string Name
    {
      get { return m_name; }
      set { m_name = value; }
    }

    #endregion

    #region methods

    public static string GetLevelFolder()
    {
      string applicationFolder = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location );
      return System.IO.Path.Combine( applicationFolder, "levels" );
    }

    public static List<Level> GetLevels()
    {
      string [] levelFolders = System.IO.Directory.GetDirectories( GetLevelFolder() );
      List<Level> levels = new List<Level>();

      foreach ( string levelFolder in levelFolders )
      {
        // read XML
        string levelFile = System.IO.Path.Combine( levelFolder, "level.xml.jpg" );
        TextReader levelReader = new StreamReader( new FileStream( levelFile, FileMode.Open ) );
        XmlSerializer levelXml = new XmlSerializer( typeof( Level ) );
        Level level = ( Level ) levelXml.Deserialize( levelReader );
        levelReader.Close();

        // read background
        string backgroundFile = System.IO.Path.Combine( levelFolder, "background.jpg" );
        if ( System.IO.File.Exists( backgroundFile ) )
          level.BackgroundImage = System.Drawing.Image.FromFile( backgroundFile );

        levels.Add( level );
      }

      return levels;
    }

    #endregion

    #region ICloneable Members

    public object Clone()
    {
      Level newLevel = new Level();
      newLevel.m_anchorPoints = new List<PointF>( m_anchorPoints );
      newLevel.m_backgroundImage = (System.Drawing.Image) m_backgroundImage.Clone();
      newLevel.m_budget = m_budget;
      newLevel.m_name = m_name;
      return newLevel;
    }

    #endregion
  }

  class Level1 : Level
  {
    public Level1()
    {
      m_anchorPoints.Add( new PointF( 100, 300 ) );
      m_anchorPoints.Add( new PointF( 420, 300 ) );
      m_budget = 12000;
      m_backgroundImage = Bitmap.FromFile( "images/stone_bridge.jpg" );
    }
  }

  class Level2 : Level
  {
    public Level2()
    {
      m_anchorPoints.Add( new PointF( 60, 300 ) );
      m_anchorPoints.Add( new PointF( 460, 300 ) );
      m_budget = 16000;
      m_backgroundImage = Bitmap.FromFile( "images/medium_truss.jpg" );
    }
  }

  class Level3 : Level
  {
    public Level3()
    {
      m_anchorPoints.Add( new PointF( 20, 300 ) );
      m_anchorPoints.Add( new PointF( 500, 300 ) );
      m_budget = 40000;
      m_backgroundImage = Bitmap.FromFile( "images/long_truss.jpg" );
    }
  }

  class Level4 : Level
  {
    public Level4()
    {
      m_anchorPoints.Add( new PointF( 20, 220 ) );
      m_anchorPoints.Add( new PointF( 500, 220 ) );
      m_anchorPoints.Add( new PointF( 260, 440 ) );
      m_budget = 21000;
      m_backgroundImage = Bitmap.FromFile( "images/double_truss.jpg" );
    }
  }

  class Level5 : Level
  {
    public Level5()
    {
      m_anchorPoints.Add( new PointF( 20, 380 ) );
      m_anchorPoints.Add( new PointF( 500, 380 ) );
      m_anchorPoints.Add( new PointF( 20, 60 ) );
      m_budget = 7000;
      m_backgroundImage = Bitmap.FromFile( "images/suspension.jpg" );
    }
  }

  class Level6 : Level
  {
    public Level6()
    {
      m_anchorPoints.Add( new PointF( 20, 200 ) );
      m_anchorPoints.Add( new PointF( 500, 200 ) );
      m_anchorPoints.Add( new PointF( 20, 360 ) );
      m_anchorPoints.Add( new PointF( 500, 360 ) );
      m_budget = 23000;
      m_backgroundImage = Bitmap.FromFile( "images/arch_under.jpg" );
    }
  }

  class MyLevel : Level
  {
    public MyLevel()
    {
      m_budget = 1000000;
      m_backgroundImage = null;
    }
  }
}
