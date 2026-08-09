using System;

namespace ModuleWorks;

[Serializable]
public class Vectord : Point3d<double>
{
	public double Length => Math.Sqrt(LengthSq);

	public double LengthSq => this * this;

	public static Vectord Max => new Vectord(double.MaxValue, double.MaxValue, double.MaxValue);

	public static Vectord Min => new Vectord(double.MinValue, double.MinValue, double.MinValue);

	public static Vectord UnitX => new Vectord(1.0, 0.0, 0.0);

	public static Vectord UnitY => new Vectord(0.0, 1.0, 0.0);

	public static Vectord UnitZ => new Vectord(0.0, 0.0, 1.0);

	public Vectord()
	{
	}

	public Vectord(double x, double y, double z)
		: base(x, y, z)
	{
	}

	public Vectord(Vectord other)
		: base((Point3d<double>)other)
	{
	}

	public Vectord(Point3d<double> other)
		: base(other)
	{
	}

	public Vectord(Point3d<float> other)
		: base((double)other.X, (double)other.Y, (double)other.Z)
	{
	}

	public bool IsAxis(Axis axis)
	{
		bool result = false;
		double num = 0.0001;
		switch (axis)
		{
		case Axis.X:
			result = Math.Abs(base.X - 1.0) < num && Math.Abs(base.Y) < num && Math.Abs(base.Z) < num;
			break;
		case Axis.Y:
			result = Math.Abs(base.X) < num && Math.Abs(base.Y - 1.0) < num && Math.Abs(base.Z) < num;
			break;
		case Axis.Z:
			result = Math.Abs(base.X) < num && Math.Abs(base.Y) < num && Math.Abs(base.Z - 1.0) < num;
			break;
		}
		return result;
	}

	public unsafe int Load(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			base.X = *(double*)(ptr + index);
			index += 8;
			base.Y = *(double*)(ptr + index);
			index += 8;
			base.Z = *(double*)(ptr + index);
			index += 8;
		}
		return index;
	}

	public unsafe int Serialize(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			*(double*)(ptr + index) = base.X;
			index += 8;
			*(double*)(ptr + index) = base.Y;
			index += 8;
			*(double*)(ptr + index) = base.Z;
			index += 8;
		}
		return index;
	}

	public static Vectord operator +(Vectord v1, Vectord v2)
	{
		Vectord vectord = new Vectord(v1);
		vectord.AddThis(v2);
		return vectord;
	}

	public static Vectord operator -(Vectord v1, Vectord v2)
	{
		return new Vectord(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
	}

	public static Vectord operator -(Vectord v)
	{
		return new Vectord(0.0 - v.X, 0.0 - v.Y, 0.0 - v.Z);
	}

	public static Vectord operator %(Vectord v1, Vectord v2)
	{
		double x = v1.X;
		double y = v1.Y;
		double z = v1.Z;
		double x2 = v2.X;
		double y2 = v2.Y;
		double z2 = v2.Z;
		return new Vectord(y * z2 - z * y2, z * x2 - x * z2, x * y2 - y * x2);
	}

	public static double operator ~(Vectord v)
	{
		return v.Length;
	}

	public static double operator *(Vectord v1, Vectord v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
	}

	public static Vectord operator *(Vectord v, double factor)
	{
		Vectord vectord = new Vectord(v);
		vectord.MultiplyThis(factor);
		return vectord;
	}

	public static Vectord operator *(double factor, Vectord v)
	{
		return v * factor;
	}

	public static Vectord operator /(Vectord v, double factor)
	{
		return v * (1.0 / factor);
	}

	public static Vectord CrossProduct(Vectord v1, Vectord v2)
	{
		return v1 % v2;
	}

	public void Normalize()
	{
		double lengthSq = LengthSq;
		if (lengthSq <= double.Epsilon)
		{
			throw new Exception();
		}
		if (lengthSq > 1.0001 || lengthSq < 0.9999)
		{
			double scalar = 1.0 / Math.Sqrt(lengthSq);
			MultiplyThis(scalar);
		}
	}

	public Vectord Normalized()
	{
		Vectord vectord = new Vectord(this);
		vectord.Normalize();
		return vectord;
	}

	public void TransformPoint(TransformationMatrixManagedD matrix)
	{
		double x = matrix[0, 0] * base.X + matrix[0, 1] * base.Y + matrix[0, 2] * base.Z + matrix[0, 3];
		double y = matrix[1, 0] * base.X + matrix[1, 1] * base.Y + matrix[1, 2] * base.Z + matrix[1, 3];
		double z = matrix[2, 0] * base.X + matrix[2, 1] * base.Y + matrix[2, 2] * base.Z + matrix[2, 3];
		base.X = x;
		base.Y = y;
		base.Z = z;
	}

	public Vectord TransformedPoint(TransformationMatrixManagedD matrix)
	{
		Vectord vectord = new Vectord(this);
		vectord.TransformPoint(matrix);
		return vectord;
	}

	public void TransformVector(TransformationMatrixManagedD matrix)
	{
		double x = matrix[0, 0] * base.X + matrix[0, 1] * base.Y + matrix[0, 2] * base.Z;
		double y = matrix[1, 0] * base.X + matrix[1, 1] * base.Y + matrix[1, 2] * base.Z;
		double z = matrix[2, 0] * base.X + matrix[2, 1] * base.Y + matrix[2, 2] * base.Z;
		base.X = x;
		base.Y = y;
		base.Z = z;
	}

	public Vectord TransformedVector(TransformationMatrixManagedD matrix)
	{
		Vectord vectord = new Vectord(this);
		vectord.TransformVector(matrix);
		return vectord;
	}

	public void AddThis(Vectord v)
	{
		base.X += v.X;
		base.Y += v.Y;
		base.Z += v.Z;
	}

	public void MultiplyThis(double scalar)
	{
		base.X *= scalar;
		base.Y *= scalar;
		base.Z *= scalar;
	}

	[Obsolete("Deprecated since Release 2024.04. Please use ProjectOn instead! ATTENTION: The input vectors (this and parameter 'axis' are switched")]
	public Vectord ProjectOnto(Vectord axis)
	{
		double lengthSq = LengthSq;
		if (lengthSq <= double.Epsilon)
		{
			throw new Exception("Cannot project a null vector!");
		}
		return this * axis / lengthSq * this;
	}

	public Vectord ProjectOn(Vectord axis)
	{
		if (axis == null)
		{
			throw new ArgumentNullException("axis");
		}
		double lengthSq = axis.LengthSq;
		if (lengthSq <= 0.0)
		{
			throw new ArgumentOutOfRangeException("Cannot project on a null vector!");
		}
		return this * axis / lengthSq * axis;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vectord v))
		{
			return false;
		}
		return Equals(v);
	}

	public bool Equals(Vectord v)
	{
		if (Math.Abs(base.X - v.X) < 0.0001 && Math.Abs(base.Y - v.Y) < 0.0001)
		{
			return Math.Abs(base.Z - v.Z) < 0.0001;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)(base.X * 10000.0) * -7919 + (int)(base.Y * 10000.0) * 4447 + (int)(base.Z * 10000.0) * 6569;
	}
}
