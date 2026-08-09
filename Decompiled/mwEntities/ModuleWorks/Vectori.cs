using System;
using System.IO;

namespace ModuleWorks;

[Serializable]
public class Vectori : Point3d<int>
{
	public int LengthSq => this * this;

	public static Vectori Max => new Vectori(int.MaxValue, int.MaxValue, int.MaxValue);

	public static Vectori Min => new Vectori(int.MinValue, int.MinValue, int.MinValue);

	public static Vectori UnitX => new Vectori(1, 0, 0);

	public static Vectori UnitY => new Vectori(0, 1, 0);

	public static Vectori UnitZ => new Vectori(0, 0, 1);

	public Vectori()
	{
	}

	public Vectori(int x, int y, int z)
		: base(x, y, z)
	{
	}

	public Vectori(Point3d<int> other)
		: base(other)
	{
	}

	public Vectori(Vectori other)
		: base(other.X, other.Y, other.Z)
	{
	}

	public bool IsAxis(Axis axis)
	{
		bool result = false;
		float num = 0.0001f;
		switch (axis)
		{
		case Axis.X:
			result = Math.Abs((float)base.X - 1f) < num && (float)Math.Abs(base.Y) < num && (float)Math.Abs(base.Z) < num;
			break;
		case Axis.Y:
			result = (float)Math.Abs(base.X) < num && Math.Abs((float)base.Y - 1f) < num && (float)Math.Abs(base.Z) < num;
			break;
		case Axis.Z:
			result = (float)Math.Abs(base.X) < num && (float)Math.Abs(base.Y) < num && Math.Abs((float)base.Z - 1f) < num;
			break;
		}
		return result;
	}

	public unsafe int Load(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			base.X = *(int*)(ptr + index);
			index += 4;
			base.Y = *(int*)(ptr + index);
			index += 4;
			base.Z = *(int*)(ptr + index);
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
		base.X = reader.ReadInt32();
		base.Y = reader.ReadInt32();
		base.Z = reader.ReadInt32();
	}

	public unsafe int Serialize(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			*(int*)(ptr + index) = base.X;
			index += 4;
			*(int*)(ptr + index) = base.Y;
			index += 4;
			*(int*)(ptr + index) = base.Z;
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

	public static Vectori operator +(Vectori v1, Vectori v2)
	{
		Vectori vectori = new Vectori(v1);
		vectori.AddThis(v2);
		return vectori;
	}

	public static Vectori operator -(Vectori v1, Vectori v2)
	{
		return new Vectori(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
	}

	public static Vectori operator -(Vectori v)
	{
		return new Vectori(-v.X, -v.Y, -v.Z);
	}

	public static Vectori operator %(Vectori v1, Vectori v2)
	{
		int x = v1.X;
		int y = v1.Y;
		int z = v1.Z;
		int x2 = v2.X;
		int y2 = v2.Y;
		int z2 = v2.Z;
		return new Vectori(y * z2 - z * y2, z * x2 - x * z2, x * y2 - y * x2);
	}

	public static int operator *(Vectori v1, Vectori v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
	}

	public static Vectori operator *(Vectori v, int factor)
	{
		Vectori vectori = new Vectori(v);
		vectori.MultiplyThis(factor);
		return vectori;
	}

	public static Vectori operator *(int factor, Vectori v)
	{
		return v * factor;
	}

	public static Vectori CrossProduct(Vectori v1, Vectori v2)
	{
		return v1 % v2;
	}

	public void TransformPoint(TransformationMatrixManaged matrix)
	{
		float num = matrix[0, 0] * (float)base.X + matrix[0, 1] * (float)base.Y + matrix[0, 2] * (float)base.Z + matrix[0, 3];
		float num2 = matrix[1, 0] * (float)base.X + matrix[1, 1] * (float)base.Y + matrix[1, 2] * (float)base.Z + matrix[1, 3];
		float num3 = matrix[2, 0] * (float)base.X + matrix[2, 1] * (float)base.Y + matrix[2, 2] * (float)base.Z + matrix[2, 3];
		base.X = (int)num;
		base.Y = (int)num2;
		base.Z = (int)num3;
	}

	public Vectori TransformedPoint(TransformationMatrixManaged matrix)
	{
		Vectori vectori = new Vectori(this);
		vectori.TransformPoint(matrix);
		return vectori;
	}

	public void TransformVector(TransformationMatrixManaged matrix)
	{
		float num = matrix[0, 0] * (float)base.X + matrix[0, 1] * (float)base.Y + matrix[0, 2] * (float)base.Z;
		float num2 = matrix[1, 0] * (float)base.X + matrix[1, 1] * (float)base.Y + matrix[1, 2] * (float)base.Z;
		float num3 = matrix[2, 0] * (float)base.X + matrix[2, 1] * (float)base.Y + matrix[2, 2] * (float)base.Z;
		base.X = (int)num;
		base.Y = (int)num2;
		base.Z = (int)num3;
	}

	public Vectori TransformedVector(TransformationMatrixManaged matrix)
	{
		Vectori vectori = new Vectori(this);
		vectori.TransformVector(matrix);
		return vectori;
	}

	public void AddThis(Vectori v)
	{
		base.X += v.X;
		base.Y += v.Y;
		base.Z += v.Z;
	}

	public void MultiplyThis(int scalar)
	{
		base.X *= scalar;
		base.Y *= scalar;
		base.Z *= scalar;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vectori v))
		{
			return false;
		}
		return Equals(v);
	}

	public bool Equals(Vectori v)
	{
		if ((float)Math.Abs(base.X - v.X) < 0.0001f && (float)Math.Abs(base.Y - v.Y) < 0.0001f)
		{
			return (float)Math.Abs(base.Z - v.Z) < 0.0001f;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.X * -7919 + base.Y * 4447 + base.Z * 6569;
	}
}
