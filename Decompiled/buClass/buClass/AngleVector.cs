using System;

namespace buClass;

[Serializable]
public class AngleVector : buSerilization
{
	public double X = 0.0;

	public double Y = 0.0;

	public double Z = 0.0;

	public AngleVector()
	{
	}

	public AngleVector(AngleVector angle)
	{
		X = angle.X;
		Y = angle.Y;
		Z = angle.Z;
	}

	public AngleVector(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public override string ToString()
	{
		return "X: " + X.ToString("f3") + "  Y: " + Y.ToString("f3") + "  Z: " + Z;
	}
}
