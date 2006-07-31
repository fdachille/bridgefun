using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
  class LightSteel : Spring, ICloneable
  {
    #region ICloneable Members

    public override object Clone()
    {
      LightSteel newSpring = new LightSteel();
      newSpring.m_endPin = m_endPin;
      newSpring.m_restLength = m_restLength;
      newSpring.m_startPin = m_startPin;
      return newSpring;
    }

    #endregion
  }
}
