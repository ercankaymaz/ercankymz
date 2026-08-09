using System;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class PlaneAngles : buSerilization5
{
	public double A = 0.0;

	public double B = 0.0;

	public double C = 0.0;

	public PlaneAngles()
	{
	}

	public PlaneAngles(double a, double b, double c)
	{
		A = a;
		B = b;
		C = c;
	}

	public override string ToString()
	{
		return $"A: {A:F2}°, B: {B:F2}°, C: {C:F2}°";
	}
}
