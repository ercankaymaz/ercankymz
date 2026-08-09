using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Xbim.Common.Geometry;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct XbimRect3D
{
	private static readonly XbimRect3D _empty;

	private double _x;

	private double _y;

	private double _z;

	private double _sizeX;

	private double _sizeY;

	private double _sizeZ;

	public static XbimRect3D Empty => _empty;

	public double SizeX
	{
		get
		{
			return _sizeX;
		}
		set
		{
			_sizeX = value;
		}
	}

	public double SizeY
	{
		get
		{
			return _sizeY;
		}
		set
		{
			_sizeY = value;
		}
	}

	public double SizeZ
	{
		get
		{
			return _sizeZ;
		}
		set
		{
			_sizeZ = value;
		}
	}

	public XbimPoint3D Location
	{
		get
		{
			return new XbimPoint3D(_x, _y, _z);
		}
		set
		{
			_x = value.X;
			_y = value.Y;
			_z = value.Z;
		}
	}

	public double X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public double Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public double Z
	{
		get
		{
			return _z;
		}
		set
		{
			_z = value;
		}
	}

	public bool IsEmpty => SizeX < 0.0;

	public XbimPoint3D Min => Location;

	public XbimPoint3D Max => new XbimPoint3D(_x + _sizeX, _y + _sizeY, _z + _sizeZ);

	public double Volume => _sizeX * _sizeY * _sizeZ;

	public XbimRect3D(double x, double y, double z, double sizeX, double sizeY, double sizeZ)
	{
		_x = x;
		_y = y;
		_z = z;
		_sizeX = sizeX;
		_sizeY = sizeY;
		_sizeZ = sizeZ;
	}

	public XbimRect3D(XbimPoint3D Position, XbimVector3D Size)
	{
		_x = Position.X;
		_y = Position.Y;
		_z = Position.Z;
		_sizeX = Size.X;
		_sizeY = Size.Y;
		_sizeZ = Size.Z;
	}

	public XbimRect3D(XbimPoint3D p1, XbimPoint3D p2)
	{
		_x = Math.Min(p1.X, p2.X);
		_y = Math.Min(p1.Y, p2.Y);
		_z = Math.Min(p1.Z, p2.Z);
		_sizeX = Math.Max(p1.X, p2.X) - _x;
		_sizeY = Math.Max(p1.Y, p2.Y) - _y;
		_sizeZ = Math.Max(p1.Z, p2.Z) - _z;
	}

	static XbimRect3D()
	{
		_empty = new XbimRect3D
		{
			_x = double.PositiveInfinity,
			_y = double.PositiveInfinity,
			_z = double.PositiveInfinity,
			_sizeX = double.NegativeInfinity,
			_sizeY = double.NegativeInfinity,
			_sizeZ = double.NegativeInfinity
		};
	}

	public XbimRect3D(XbimPoint3D highpt)
	{
		_x = highpt.X;
		_y = highpt.Y;
		_z = highpt.Z;
		_sizeX = 0.0;
		_sizeY = 0.0;
		_sizeZ = 0.0;
	}

	public XbimRect3D(XbimVector3D vMin, XbimVector3D vMax)
	{
		_x = Math.Min(vMin.X, vMax.X);
		_y = Math.Min(vMin.Y, vMax.Y);
		_z = Math.Min(vMin.Z, vMax.Z);
		_sizeX = Math.Max(vMin.X, vMax.X) - _x;
		_sizeY = Math.Max(vMin.Y, vMax.Y) - _y;
		_sizeZ = Math.Max(vMin.Z, vMax.Z) - _z;
	}

	public static XbimRect3D FromArray(byte[] array)
	{
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(array));
		XbimRect3D result = default(XbimRect3D);
		if (array.Length == 24)
		{
			double x = binaryReader.ReadSingle();
			double y = binaryReader.ReadSingle();
			double z = binaryReader.ReadSingle();
			result.Location = new XbimPoint3D(x, y, z);
			double sizeX = binaryReader.ReadSingle();
			double sizeY = binaryReader.ReadSingle();
			double sizeZ = binaryReader.ReadSingle();
			result.SizeX = sizeX;
			result.SizeY = sizeY;
			result.SizeZ = sizeZ;
		}
		else
		{
			double x2 = binaryReader.ReadDouble();
			double y2 = binaryReader.ReadDouble();
			double z2 = binaryReader.ReadDouble();
			result.Location = new XbimPoint3D(x2, y2, z2);
			double sizeX2 = binaryReader.ReadDouble();
			double sizeY2 = binaryReader.ReadDouble();
			double sizeZ2 = binaryReader.ReadDouble();
			result.SizeX = sizeX2;
			result.SizeY = sizeY2;
			result.SizeZ = sizeZ2;
		}
		return result;
	}

	public byte[] ToDoublesArray()
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(_x);
		binaryWriter.Write(_y);
		binaryWriter.Write(_z);
		binaryWriter.Write(_sizeX);
		binaryWriter.Write(_sizeY);
		binaryWriter.Write(_sizeZ);
		return memoryStream.ToArray();
	}

	public byte[] ToFloatArray()
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((float)_x);
		binaryWriter.Write((float)_y);
		binaryWriter.Write((float)_z);
		binaryWriter.Write((float)_sizeX);
		binaryWriter.Write((float)_sizeY);
		binaryWriter.Write((float)_sizeZ);
		return memoryStream.ToArray();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5}", _x, _y, _z, _sizeX, _sizeY, _sizeZ);
	}

	public bool FromString(string Value)
	{
		string[] array = Value.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries);
		_x = Convert.ToSingle(array[0], CultureInfo.InvariantCulture);
		_y = Convert.ToSingle(array[1], CultureInfo.InvariantCulture);
		_z = Convert.ToSingle(array[2], CultureInfo.InvariantCulture);
		_sizeX = Convert.ToSingle(array[3], CultureInfo.InvariantCulture);
		_sizeY = Convert.ToSingle(array[4], CultureInfo.InvariantCulture);
		_sizeZ = Convert.ToSingle(array[5], CultureInfo.InvariantCulture);
		return true;
	}

	public static XbimRect3D Parse(string Value)
	{
		string[] array = Value.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries);
		return new XbimRect3D(Convert.ToDouble(array[0], CultureInfo.InvariantCulture), Convert.ToDouble(array[1], CultureInfo.InvariantCulture), Convert.ToDouble(array[2], CultureInfo.InvariantCulture), Convert.ToDouble(array[3], CultureInfo.InvariantCulture), Convert.ToDouble(array[4], CultureInfo.InvariantCulture), Convert.ToDouble(array[5], CultureInfo.InvariantCulture));
	}

	public XbimRect3D Inflate(double x, double y, double z)
	{
		return Inflate(this, x, y, z);
	}

	public static XbimRect3D Inflate(XbimRect3D original, double x, double y, double z)
	{
		XbimPoint3D position = new XbimPoint3D(original.X - x, original.Y - y, original.Z - z);
		XbimVector3D size = new XbimVector3D(original.SizeX + x * 2.0, original.SizeY + y * 2.0, original.SizeZ + z * 2.0);
		return new XbimRect3D(position, size);
	}

	public static XbimRect3D Inflate(XbimRect3D original, double inflate)
	{
		XbimPoint3D position = new XbimPoint3D(original.X - inflate, original.Y - inflate, original.Z - inflate);
		XbimVector3D size = new XbimVector3D(original.SizeX + inflate * 2.0, original.SizeY + inflate * 2.0, original.SizeZ + inflate * 2.0);
		return new XbimRect3D(position, size);
	}

	public XbimRect3D Inflate(double d)
	{
		return Inflate(this, d);
	}

	public XbimPoint3D Centroid()
	{
		if (IsEmpty)
		{
			return new XbimPoint3D(0.0, 0.0, 0.0);
		}
		return new XbimPoint3D(X + SizeX / 2.0, Y + SizeY / 2.0, Z + SizeZ / 2.0);
	}

	public static XbimRect3D TransformBy(XbimRect3D rect3d, XbimMatrix3D m)
	{
		XbimPoint3D min = rect3d.Min;
		XbimPoint3D max = rect3d.Max;
		XbimVector3D up = m.Up;
		XbimVector3D right = m.Right;
		XbimVector3D backward = m.Backward;
		XbimVector3D a = right * min.X;
		XbimVector3D b = right * max.X;
		XbimVector3D a2 = up * min.Y;
		XbimVector3D b2 = up * max.Y;
		XbimVector3D a3 = backward * min.Z;
		XbimVector3D b3 = backward * max.Z;
		return new XbimRect3D(XbimVector3D.Min(a, b) + XbimVector3D.Min(a2, b2) + XbimVector3D.Min(a3, b3) + m.Translation, XbimVector3D.Max(a, b) + XbimVector3D.Max(a2, b2) + XbimVector3D.Max(a3, b3) + m.Translation);
	}

	public void Union(XbimRect3D bb)
	{
		if (IsEmpty)
		{
			X = bb.X;
			Y = bb.Y;
			Z = bb.Z;
			SizeX = bb.SizeX;
			SizeY = bb.SizeY;
			SizeZ = bb.SizeZ;
		}
		else if (!bb.IsEmpty)
		{
			double num = Math.Min(X, bb.X);
			double num2 = Math.Min(Y, bb.Y);
			double num3 = Math.Min(Z, bb.Z);
			_sizeX = Math.Max(X + _sizeX, bb.X + bb._sizeX) - num;
			_sizeY = Math.Max(Y + _sizeY, bb.Y + bb._sizeY) - num2;
			_sizeZ = Math.Max(Z + _sizeZ, bb.Z + bb._sizeZ) - num3;
			X = num;
			Y = num2;
			Z = num3;
		}
	}

	public void Union(XbimPoint3D highpt)
	{
		Union(new XbimRect3D(highpt, highpt));
	}

	public bool Contains(double x, double y, double z)
	{
		if (IsEmpty)
		{
			return false;
		}
		return ContainsCoords(x, y, z);
	}

	public bool Contains(XbimPoint3D pt)
	{
		if (IsEmpty)
		{
			return false;
		}
		return ContainsCoords(pt.X, pt.Y, pt.Z);
	}

	private bool ContainsCoords(double x, double y, double z)
	{
		if (x >= _x && x <= _x + _sizeX && y >= _y && y <= _y + _sizeY && z >= _z)
		{
			return z <= _z + _sizeZ;
		}
		return false;
	}

	public bool Intersects(XbimRect3D rect)
	{
		if (IsEmpty || rect.IsEmpty)
		{
			return false;
		}
		if (rect._x <= _x + _sizeX && rect._x + rect._sizeX >= _x && rect._y <= _y + _sizeY && rect._y + rect._sizeY >= _y && rect._z <= _z + _sizeZ)
		{
			return rect._z + rect._sizeZ >= _z;
		}
		return false;
	}

	public bool Contains(XbimRect3D rect)
	{
		if (IsEmpty)
		{
			return false;
		}
		if (Contains(rect.Min))
		{
			return Contains(rect.Max);
		}
		return false;
	}

	public double Radius()
	{
		double length = new XbimVector3D(SizeX, SizeY, SizeZ).Length;
		if (length != 0.0)
		{
			return length / 2.0;
		}
		return 0.0;
	}

	public double Length()
	{
		return new XbimVector3D(SizeX, SizeY, SizeZ).Length;
	}

	public XbimRect3D Transform(XbimMatrix3D composed)
	{
		XbimPoint3D p = Min * composed;
		XbimPoint3D p2 = Max * composed;
		return new XbimRect3D(p, p2);
	}

	public void Round(int digits)
	{
		_x = Math.Round(_x, digits);
		_y = Math.Round(_y, digits);
		_z = Math.Round(_z, digits);
		_sizeX = Math.Round(_sizeX, digits);
		_sizeY = Math.Round(_sizeY, digits);
		_sizeZ = Math.Round(_sizeZ, digits);
	}

	public static XbimRect3D Round(XbimRect3D r, int digits)
	{
		return new XbimRect3D(Math.Round(r.X, digits), Math.Round(r.Y, digits), Math.Round(r.Z, digits), Math.Round(r.SizeX, digits), Math.Round(r.SizeY, digits), Math.Round(r.SizeZ, digits));
	}

	public bool IsSimilar(XbimRect3D rect, double tolerance)
	{
		double num = Math.Abs(tolerance);
		double num2 = 2.0 * num;
		if (Math.Abs(_x - rect.X) <= num && Math.Abs(_y - rect.Y) <= num && Math.Abs(_z - rect.Z) <= num && Math.Abs(_sizeX - rect.SizeX) <= num2 && Math.Abs(_sizeY - rect.SizeY) <= num2)
		{
			return Math.Abs(_sizeZ - rect.SizeZ) <= num2;
		}
		return false;
	}
}
