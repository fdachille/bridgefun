using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
  class HeavySteel : LightSteel, ICloneable
  {
    #region properties

    public override float MaxSpringLength { get { return 90f; } }
    public override float MaximumForce { get { return 2f; } }
    public override float CostPerFoot { get { return 30f; } }
    public override float SpringConstant { get { return 5; } }
    public override float WeightPerFoot { get { return 3; } }

    #endregion

    #region ICloneable Members

    public override object Clone()
    {
      HeavySteel newSpring = new HeavySteel();
      newSpring.m_endPin = m_endPin;
      newSpring.m_restLength = m_restLength;
      newSpring.m_startPin = m_startPin;
      return newSpring;
    }

    #endregion
  }
}
