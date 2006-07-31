using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
  class Cable : Spring, ICloneable
  {
    #region properties

    public override float MaxSpringLength { get { return 1000f; } }
    public override float MaximumForce { get { return 0.5f; } }
    public override float CostPerFoot { get { return 1f; } }
    public override float SpringConstant { get { return 5; } }
    public override float WeightPerFoot { get { return 0.25f; } }

    #endregion

    public override float GetTensionForce( float currentLength )
    {
      // f = k x
      float dx = currentLength - m_restLength;

      // cannot push on a rope
      if( dx > 0 )
        return dx;
      else
        return 0;
    }

    #region ICloneable Members

    public override object Clone()
    {
      Cable newSpring = new Cable();
      newSpring.m_endPin = m_endPin;
      newSpring.m_restLength = m_restLength;
      newSpring.m_startPin = m_startPin;
      return newSpring;
    }

    #endregion
  }
}
