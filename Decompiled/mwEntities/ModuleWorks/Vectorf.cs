using System;
using System.IO;

namespace ModuleWorks;

[Serializable]
public class Vectorf : Point3d<float>
{
	public float Length => (float)Math.Sqrt(LengthSq);

	public float LengthSq => this * this;

	public static Vectorf Max => new Vectorf(float.MaxValue, float.MaxValue, float.MaxValue);

	public static Vectorf Min => new Vectorf(float.MinValue, float.MinValue, float.MinValue);

	public static Vectorf UnitX => new Vectorf(1f, 0f, 0f);

	public static Vectorf UnitY => new Vectorf(0f, 1f, 0f);

	public static Vectorf UnitZ => new Vectorf(0f, 0f, 1f);

	public static Vectorf NaN => new Vectorf(float.NaN, float.NaN, float.NaN);

	public Vectorf()
	{
	}

	public Vectorf(float x, float y, float z)
		: base(x, y, z)
	{
	}

	public Vectorf(Point3d<float> other)
		: base(other)
	{
	}

	public Vectorf(Vectorf other)
		: base(other.X, other.Y, other.Z)
	{
	}

	public Vectorf(Point3d<double> other)
		: base((float)other.X, (float)other.Y, (float)other.Z)
	{
	}

	public bool IsAxis(Axis axis)
	{
		bool result = false;
		float num = 0.0001f;
		switch (axis)
		{
		case Axis.X:
			result = Math.Abs(base.X - 1f) < num && Math.Abs(base.Y) < num && Math.Abs(base.Z) < num;
			break;
		case Axis.Y:
			result = Math.Abs(base.X) < num && Math.Abs(base.Y - 1f) < num && Math.Abs(base.Z) < num;
			break;
		case Axis.Z:
			result = Math.Abs(base.X) < num && Math.Abs(base.Y) < num && Math.Abs(base.Z - 1f) < num;
			break;
		}
		return result;
	}

	public unsafe int Load(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			base.X = *(float*)(ptr + index);
			index += 4;
			base.Y = *(float*)(ptr + index);
			index += 4;
			base.Z = *(float*)(ptr + index);
			index += 4;
		}
		return index;
	}

	public void Load(Stream stream)
	{
		using BinaryReader reader = new BinaryReader(stream);
		Load(reader);
	}

	public void Load(BinaryReader reader)
	{
		base.X = reader.ReadSingle();
		base.Y = reader.ReadSingle();
		base.Z = reader.ReadSingle();
	}

	public unsafe int Serialize(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			*(float*)(ptr + index) = base.X;
			index += 4;
			*(float*)(ptr + index) = base.Y;
			index += 4;
			*(float*)(ptr + index) = base.Z;
			index += 4;
		}
		return index;
	}

	public void Serialize(Stream stream)
	{
		using BinaryWriter writer = new BinaryWriter(stream);
		Serialize(writer);
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(base.X);
		writer.Write(base.Y);
		writer.Write(base.Z);
	}

	public static Vectorf operator +(Vectorf v1, Vectorf v2)
	{
		Vectorf vectorf = new Vectorf(v1);
		vectorf.AddThis(v2);
		return vectorf;
	}

	public static Vectorf operator -(Vectorf v1, Vectorf v2)
	{
		return new Vectorf(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
	}

	public static Vectorf operator -(Vectorf v)
	{
		return new Vectorf(0f - v.X, 0f - v.Y, 0f - v.Z);
	}

	public static Vectorf operator %(Vectorf v1, Vectorf v2)
	{
		float x = v1.X;
		float y = v1.Y;
		float z = v1.Z;
		float x2 = v2.X;
		float y2 = v2.Y;
		float z2 = v2.Z;
		return new Vectorf(y * z2 - z * y2, z * x2 - x * z2, x * y2 - y * x2);
	}

	public static float operator ~(Vectorf v)
	{
		return v.Length;
	}

	public static float operator *(Vectorf v1, Vectorf v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
	}

	public static Vectorf operator *(Vectorf v, float factor)
	{
		Vectorf vectorf = new Vectorf(v);
		vectorf.MultiplyThis(factor);
		return vectorf;
	}

	public static Vectorf operator *(float factor, Vectorf v)
	{
		return v * factor;
	}

	public static Vectorf operator /(Vectorf v, float factor)
	{
		return v * (1f / factor);
	}

	public static Vectorf CrossProduct(Vectorf v1, Vectorf v2)
	{
		return v1 % v2;
	}

	public void Normalize()
	{
		float lengthSq = LengthSq;
		if (lengthSq <= float.Epsilon)
		{
			throw new Exception();
		}
		if (lengthSq > 1.0001f || lengthSq < 0.9999f)
		{
			float scalar = 1f / (float)Math.Sqrt(lengthSq);
			MultiplyThis(scalar);
		}
	}

	public Vectorf Normalized()
	{
		Vectorf vectorf = new Vectorf(this);
		vectorf.Normalize();
		return vectorf;
	}

	public void TransformPoint(TransformationMatrixManaged matrix)
	{
		float x = matrix[0, 0] * base.X + matrix[0, 1] * base.Y + matrix[0, 2] * base.Z + matrix[0, 3];
		float y = matrix[1, 0] * base.X + matrix[1, 1] * base.Y + matrix[1, 2] * base.Z + matrix[1, 3];
		float z = matrix[2, 0] * base.X + matrix[2, 1] * base.Y + matrix[2, 2] * base.Z + matrix[2, 3];
		base.X = x;
		base.Y = y;
		base.Z = z;
	}

	public Vectorf TransformedPoint(TransformationMatrixManaged matrix)
	{
		Vectorf vectorf = new Vectorf(this);
		vectorf.TransformPoint(matrix);
		return vectorf;
	}

	public void TransformVector(TransformationMatrixManaged matrix)
	{
		float x = matrix[0, 0] * base.X + matrix[0, 1] * base.Y + matrix[0, 2] * base.Z;
		float y = matrix[1, 0] * base.X + matrix[1, 1] * base.Y + matrix[1, 2] * base.Z;
		float z = matrix[2, 0] * base.X + matrix[2, 1] * base.Y + matrix[2, 2] * base.Z;
		base.X = x;
		base.Y = y;
		base.Z = z;
	}

	public Vectorf TransformedVector(TransformationMatrixManaged matrix)
	{
		Vectorf vectorf = new Vectorf(this);
		vectorf.TransformVector(matrix);
		return vectorf;
	}

	public void AddThis(Vectorf v)
	{
		base.X += v.X;
		base.Y += v.Y;
		base.Z += v.Z;
	}

	public void MultiplyThis(float scalar)
	{
		base.X *= scalar;
		base.Y *= scalar;
		base.Z *= scalar;
	}

	[Obsolete("Deprecated since Release 2024.04. Please use ProjectOn instead! ATTENTION: The input vectors (this and parameter 'axis' are switched")]
	public Vectorf ProjectOnto(Vectorf axis)
	{
		float lengthSq = LengthSq;
		if (lengthSq <= float.Epsilon)
		{
			throw new Exception("Cannot project a null vector!");
		}
		return this * axis / lengthSq * this;
	}

	public Vectorf ProjectOn(Vectorf axis)
	{
		if (axis == null)
		{
			throw new ArgumentNullException("axis");
		}
		float lengthSq = axis.LengthSq;
		if ((double)lengthSq <= 0.0)
		{
			throw new ArgumentOutOfRangeException("Cannot project on a null vector!");
		}
		return this * axis / lengthSq * axis;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vectorf v))
		{
			return false;
		}
		return Equals(v);
	}

	public bool Equals(Vectorf v)
	{
		if (Math.Abs(base.X - v.X) < 0.0001f && Math.Abs(base.Y - v.Y) < 0.0001f)
		{
			return Math.Abs(base.Z - v.Z) < 0.0001f;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)((double)base.X * 10000.0) * -7919 + (int)((double)base.Y * 10000.0) * 4447 + (int)((double)base.Z * 10000.0) * 6569;
	}

	[Obsolete("Deprecated since Release 2017.04. Please use constructor Vectorf(Vectord other) instead!")]
	public static Vectorf Convert(Point3d<double> point)
	{
		return new Vectorf((float)point.X, (float)point.Y, (float)point.Z);
	}
}
