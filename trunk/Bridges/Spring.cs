using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bridges
{
  public class Spring : ICloneable
  {

    #region fields

    protected int m_startPin = -1;
    protected int m_endPin = -1;
    public float m_restLength = -1;

    #endregion

    #region properties

    public static float Gravity { get { return 0.001f; } }
    public virtual float MaxSpringLength { get { return 90f; } }
    public virtual float MaximumForce { get { return 1f; } }
    public virtual float CostPerFoot { get { return 10f; } }
    public virtual float SpringConstant { get { return 5; } }
    public virtual float WeightPerFoot { get { return 1; } }
    public int StartPin { get { return m_startPin; } set { m_startPin = value; } }
    public int EndPin { get { return m_endPin; } set { m_endPin = value; } }

    #endregion

    #region methods

    public virtual float GetTensionForce( float currentLength )
    {
      // f = k x
      float dx = currentLength - m_restLength;
      return SpringConstant * dx;
    }

    #endregion

    #region ICloneable Members

    public virtual object Clone()
    {
      Spring newSpring = new Spring();
      newSpring.m_endPin = m_endPin;
      newSpring.m_restLength = m_restLength;
      newSpring.m_startPin = m_startPin;
      return newSpring;
    }

    #endregion
  }
}
