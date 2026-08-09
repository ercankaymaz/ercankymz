using System;
using System.Runtime.CompilerServices;

namespace buCadCamResVer5.Robotic;

public class Vector3DD
{
	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private double double_2;

	public double X
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public double Y
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		set
		{
			double_1 = value;
		}
	}

	public double Z
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
		[CompilerGenerated]
		set
		{
			double_2 = value;
		}
	}

	public Vector3DD(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public double Length()
	{
		return Math.Sqrt(X * X + Y * Y + Z * Z);
	}

	public Vector3DD Normalize()
	{
		double num = Length();
		if (!(num < 1E-10))
		{
			return new Vector3DD(X / num, Y / num, Z / num);
		}
		return this;
	}

	public static Vector3DD Cross(Vector3DD a, Vector3DD b)
	{
		return new Vector3DD(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
	}

	public static double Dot(Vector3DD a, Vector3DD b)
	{
		return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
	}
}
