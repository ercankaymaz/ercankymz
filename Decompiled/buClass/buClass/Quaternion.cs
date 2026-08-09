using System;

namespace buClass;

public struct Quaternion
{
	public double X;

	public double Y;

	public double Z;

	public double W;

	public Vec3D V
	{
		get
		{
			return new Vec3D(X, Y, Z);
		}
		set
		{
			X = value.X;
			Y = value.Y;
			Z = value.Z;
		}
	}

	public Quaternion(double w, double x, double y, double z)
	{
		W = w;
		X = x;
		Y = y;
		Z = z;
	}

	public Quaternion(double w, Vec3D v)
	{
		W = w;
		X = v.X;
		Y = v.Y;
		Z = v.Z;
	}

	public void Normalise()
	{
		double num = W * W + X * X + Y * Y + Z * Z;
		if (num > 0.001)
		{
			num = Math.Sqrt(num);
			W /= num;
			X /= num;
			Y /= num;
			Z /= num;
		}
		else
		{
			W = 1.0;
			X = 0.0;
			Y = 0.0;
			Z = 0.0;
		}
	}

	public void Conjugate()
	{
		X = 0.0 - X;
		Y = 0.0 - Y;
		Z = 0.0 - Z;
	}

	public void FromAxisAngle(Vec3D axis, double angleRadian)
	{
		double magnitude = axis.Magnitude;
		if (magnitude > 0.0001)
		{
			double w = Math.Cos(angleRadian / 2.0);
			double num = Math.Sin(angleRadian / 2.0);
			X = axis.X / magnitude * num;
			Y = axis.Y / magnitude * num;
			Z = axis.Z / magnitude * num;
			W = w;
		}
		else
		{
			W = 1.0;
			X = 0.0;
			Y = 0.0;
			Z = 0.0;
		}
	}

	public Quaternion Copy()
	{
		return new Quaternion(W, X, Y, Z);
	}

	public void Multiply(Quaternion q)
	{
		this *= q;
	}

	public void Rotate(Pnt3D pt)
	{
		Normalise();
		Quaternion quaternion = Copy();
		quaternion.Conjugate();
		Quaternion quaternion2 = new Quaternion(0.0, pt.X, pt.Y, pt.Z);
		quaternion2 = this * quaternion2 * quaternion;
		pt.X = quaternion2.X;
		pt.Y = quaternion2.Y;
		pt.Z = quaternion2.Z;
	}

	public void Rotate(Pnt3D[] nodes)
	{
		Normalise();
		Quaternion quaternion = Copy();
		quaternion.Conjugate();
		for (int i = 0; i < nodes.Length; i++)
		{
			Quaternion quaternion2 = new Quaternion(0.0, nodes[i].X, nodes[i].Y, nodes[i].Z);
			quaternion2 = this * quaternion2 * quaternion;
			nodes[i].X = quaternion2.X;
			nodes[i].Y = quaternion2.Y;
			nodes[i].Z = quaternion2.Z;
		}
	}

	public static Quaternion operator *(Quaternion q1, Quaternion q2)
	{
		double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
		double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
		double y = q1.W * q2.Y + q1.Y * q2.W + q1.Z * q2.X - q1.X * q2.Z;
		double z = q1.W * q2.Z + q1.Z * q2.W + q1.X * q2.Y - q1.Y * q2.X;
		return new Quaternion(w, x, y, z);
	}
}
