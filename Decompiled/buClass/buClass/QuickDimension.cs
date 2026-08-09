using System;

namespace buClass;

[Serializable]
public class QuickDimension : buSerilization
{
	public bool ForceVertical = false;

	public bool ForceHorizontal = false;

	public bool AngleEnable = false;

	public double Angle = 0.0;

	public double Length = 0.0;
}
