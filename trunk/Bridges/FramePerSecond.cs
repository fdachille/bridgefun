using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
  class FramePerSecond
  {
    private Queue<DateTime> m_timings = new Queue<DateTime>(11);
    private double m_framesPerSecond;

    public double FramesPerSecond { get { return m_framesPerSecond; } }

    public void SampleTime()
    {

      DateTime now = DateTime.Now;
      m_timings.Enqueue( now );

      const int smoothing = 30;
      while ( m_timings.Count > smoothing )
      {

        DateTime then = m_timings.Dequeue();
        TimeSpan span = now - then;
        
        m_framesPerSecond = smoothing / span.TotalSeconds;
      
      }

    }
  }
}
