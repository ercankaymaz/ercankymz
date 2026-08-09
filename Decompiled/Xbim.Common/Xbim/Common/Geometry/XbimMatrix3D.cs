using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Xbim.Common.Exceptions;

namespace Xbim.Common.Geometry;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct XbimMatrix3D
{
	private static readonly XbimMatrix3D _identity;

	private double _m11;

	private double _m12;

	private double _m13;

	private double _m14;

	private double _m21;

	private double _m22;

	private double _m23;

	private double _m24;

	private double _m31;

	private double _m32;

	private double _m33;

	private double _m34;

	private double _offsetX;

	private double _offsetY;

	private double _offsetZ;

	private double _m44;

	private const double FloatEpsilon = 9.999999974752427E-07;

	private bool _isNotDefaultInitialised;

	public double M11
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _m11;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m11 = value;
		}
	}

	public double M12
	{
		get
		{
			return _m12;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m12 = value;
		}
	}

	public double M13
	{
		get
		{
			return _m13;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m13 = value;
		}
	}

	public double M14
	{
		get
		{
			return _m14;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m14 = value;
		}
	}

	public double M21
	{
		get
		{
			return _m21;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m21 = value;
		}
	}

	public double M22
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _m22;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m22 = value;
		}
	}

	public double M23
	{
		get
		{
			return _m23;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m23 = value;
		}
	}

	public double M24
	{
		get
		{
			return _m24;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m24 = value;
		}
	}

	public double M31
	{
		get
		{
			return _m31;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m31 = value;
		}
	}

	public double M32
	{
		get
		{
			return _m32;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m32 = value;
		}
	}

	public double M33
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _m33;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m33 = value;
		}
	}

	public double M34
	{
		get
		{
			return _m34;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m34 = value;
		}
	}

	public double OffsetX
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _offsetX;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_offsetX = value;
		}
	}

	public double OffsetY
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _offsetY;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_offsetY = value;
		}
	}

	public double OffsetZ
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _offsetZ;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_offsetZ = value;
		}
	}

	public double M44
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _m44;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_m44 = value;
		}
	}

	public bool IsAffine
	{
		get
		{
			if (Math.Abs(_m14) < 9.999999974752427E-07 && Math.Abs(_m24) < 9.999999974752427E-07 && Math.Abs(_m34) < 9.999999974752427E-07)
			{
				return Math.Abs(_m44 - 1.0) < 9.999999974752427E-07;
			}
			return false;
		}
	}

	public static XbimMatrix3D Identity => _identity;

	public bool IsIdentity
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
				return true;
			}
			return Equal(this, _identity);
		}
	}

	public XbimVector3D Up => new XbimVector3D(M21, M22, M23);

	public XbimVector3D Down => new XbimVector3D(0.0 - M21, 0.0 - M22, 0.0 - M23);

	public XbimVector3D Right => new XbimVector3D(M11, M12, M13);

	public XbimVector3D Left => new XbimVector3D(0.0 - M11, 0.0 - M12, 0.0 - M13);

	public XbimVector3D Forward => new XbimVector3D(0.0 - M31, 0.0 - M32, 0.0 - M33);

	public XbimVector3D Backward => new XbimVector3D(M31, M32, M33);

	public XbimVector3D Translation => new XbimVector3D(_offsetX, _offsetY, _offsetZ);

	static XbimMatrix3D()
	{
		_identity = new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0)
		{
			_isNotDefaultInitialised = true
		};
	}

	public XbimMatrix3D(XbimVector3D offset)
	{
		_m11 = Identity.M11;
		_m12 = Identity.M12;
		_m13 = Identity.M13;
		_m14 = Identity.M14;
		_m21 = Identity.M21;
		_m22 = Identity.M22;
		_m23 = Identity.M23;
		_m24 = Identity.M24;
		_m31 = Identity.M31;
		_m32 = Identity.M32;
		_m33 = Identity.M33;
		_m34 = Identity.M34;
		_offsetX = offset.X;
		_offsetY = offset.Y;
		_offsetZ = offset.Z;
		_m44 = Identity.M44;
		_isNotDefaultInitialised = true;
	}

	public XbimMatrix3D(double scale)
	{
		_m11 = scale;
		_m12 = Identity.M12;
		_m13 = Identity.M13;
		_m14 = Identity.M14;
		_m21 = Identity.M21;
		_m22 = scale;
		_m23 = Identity.M23;
		_m24 = Identity.M24;
		_m31 = Identity.M31;
		_m32 = Identity.M32;
		_m33 = scale;
		_m34 = Identity.M34;
		_offsetX = Identity.OffsetX;
		_offsetY = Identity.OffsetY;
		_offsetZ = Identity.OffsetZ;
		_m44 = Identity.M44;
		_isNotDefaultInitialised = true;
	}

	public XbimMatrix3D(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double offsetX, double offsetY, double offsetZ, double m44)
	{
		_m11 = m11;
		_m12 = m12;
		_m13 = m13;
		_m14 = m14;
		_m21 = m21;
		_m22 = m22;
		_m23 = m23;
		_m24 = m24;
		_m31 = m31;
		_m32 = m32;
		_m33 = m33;
		_m34 = m34;
		_offsetX = offsetX;
		_offsetY = offsetY;
		_offsetZ = offsetZ;
		_m44 = m44;
		_isNotDefaultInitialised = true;
	}

	public static XbimMatrix3D FromString(string val)
	{
		string[] array = val.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 1 && array[0] == "I")
		{
			return Identity;
		}
		return new XbimMatrix3D(Convert.ToDouble(array[0], CultureInfo.InvariantCulture), Convert.ToDouble(array[1], CultureInfo.InvariantCulture), Convert.ToDouble(array[2], CultureInfo.InvariantCulture), Convert.ToDouble(array[3], CultureInfo.InvariantCulture), Convert.ToDouble(array[4], CultureInfo.InvariantCulture), Convert.ToDouble(array[5], CultureInfo.InvariantCulture), Convert.ToDouble(array[6], CultureInfo.InvariantCulture), Convert.ToDouble(array[7], CultureInfo.InvariantCulture), Convert.ToDouble(array[8], CultureInfo.InvariantCulture), Convert.ToDouble(array[9], CultureInfo.InvariantCulture), Convert.ToDouble(array[10], CultureInfo.InvariantCulture), Convert.ToDouble(array[11], CultureInfo.InvariantCulture), Convert.ToDouble(array[12], CultureInfo.InvariantCulture), Convert.ToDouble(array[13], CultureInfo.InvariantCulture), Convert.ToDouble(array[14], CultureInfo.InvariantCulture), Convert.ToDouble(array[15], CultureInfo.InvariantCulture));
	}

	public static XbimMatrix3D FromArray(byte[] array)
	{
		if (array.Length == 0)
		{
			return Identity;
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(array));
		if (array.Length > 64)
		{
			return new XbimMatrix3D(binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble(), binaryReader.ReadDouble());
		}
		return new XbimMatrix3D(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
	}

	public XbimPoint3D Transform(XbimPoint3D p)
	{
		return XbimPoint3D.Multiply(p, this);
	}

	public static XbimMatrix3D operator *(XbimMatrix3D a, XbimMatrix3D b)
	{
		return Multiply(a, b);
	}

	public override bool Equals(object obj)
	{
		if (obj is XbimMatrix3D)
		{
			return Equal(this, (XbimMatrix3D)obj);
		}
		return false;
	}

	public override string ToString()
	{
		return Str();
	}

	public override int GetHashCode()
	{
		XbimPoint3D p = new XbimPoint3D(1.0, 3.0, 5.0);
		return Transform(p).GetHashCode();
	}

	public static XbimMatrix3D Multiply(XbimMatrix3D mat1, XbimMatrix3D mat2)
	{
		if (mat1.IsIdentity)
		{
			return mat2;
		}
		if (mat2.IsIdentity)
		{
			return mat1;
		}
		return new XbimMatrix3D(mat1._m11 * mat2._m11 + mat1._m12 * mat2._m21 + mat1._m13 * mat2._m31 + mat1._m14 * mat2._offsetX, mat1._m11 * mat2._m12 + mat1._m12 * mat2._m22 + mat1._m13 * mat2._m32 + mat1._m14 * mat2._offsetY, mat1._m11 * mat2._m13 + mat1._m12 * mat2._m23 + mat1._m13 * mat2._m33 + mat1._m14 * mat2._offsetZ, mat1._m11 * mat2._m14 + mat1._m12 * mat2._m24 + mat1._m13 * mat2._m34 + mat1._m14 * mat2._m44, mat1._m21 * mat2._m11 + mat1._m22 * mat2._m21 + mat1._m23 * mat2._m31 + mat1._m24 * mat2._offsetX, mat1._m21 * mat2._m12 + mat1._m22 * mat2._m22 + mat1._m23 * mat2._m32 + mat1._m24 * mat2._offsetY, mat1._m21 * mat2._m13 + mat1._m22 * mat2._m23 + mat1._m23 * mat2._m33 + mat1._m24 * mat2._offsetZ, mat1._m21 * mat2._m14 + mat1._m22 * mat2._m24 + mat1._m23 * mat2._m34 + mat1._m24 * mat2._m44, mat1._m31 * mat2._m11 + mat1._m32 * mat2._m21 + mat1._m33 * mat2._m31 + mat1._m34 * mat2._offsetX, mat1._m31 * mat2._m12 + mat1._m32 * mat2._m22 + mat1._m33 * mat2._m32 + mat1._m34 * mat2._offsetY, mat1._m31 * mat2._m13 + mat1._m32 * mat2._m23 + mat1._m33 * mat2._m33 + mat1._m34 * mat2._offsetZ, mat1._m31 * mat2._m14 + mat1._m32 * mat2._m24 + mat1._m33 * mat2._m34 + mat1._m34 * mat2._m44, mat1._offsetX * mat2._m11 + mat1._offsetY * mat2._m21 + mat1._offsetZ * mat2._m31 + mat1._m44 * mat2._offsetX, mat1._offsetX * mat2._m12 + mat1._offsetY * mat2._m22 + mat1._offsetZ * mat2._m32 + mat1._m44 * mat2._offsetY, mat1._offsetX * mat2._m13 + mat1._offsetY * mat2._m23 + mat1._offsetZ * mat2._m33 + mat1._m44 * mat2._offsetZ, mat1._offsetX * mat2._m14 + mat1._offsetY * mat2._m24 + mat1._offsetZ * mat2._m34 + mat1._m44 * mat2._m44);
	}

	public static bool Equal(XbimMatrix3D a, XbimMatrix3D b)
	{
		if (Math.Abs(a.M11 - b.M11) < 9.999999974752427E-07 && Math.Abs(a.M12 - b.M12) < 9.999999974752427E-07 && Math.Abs(a.M13 - b.M13) < 9.999999974752427E-07 && Math.Abs(a.M14 - b.M14) < 9.999999974752427E-07 && Math.Abs(a.M21 - b.M21) < 9.999999974752427E-07 && Math.Abs(a.M22 - b.M22) < 9.999999974752427E-07 && Math.Abs(a.M23 - b.M23) < 9.999999974752427E-07 && Math.Abs(a.M24 - b.M34) < 9.999999974752427E-07 && Math.Abs(a.M31 - b.M31) < 9.999999974752427E-07 && Math.Abs(a.M32 - b.M32) < 9.999999974752427E-07 && Math.Abs(a.M33 - b.M33) < 9.999999974752427E-07 && Math.Abs(a.M34 - b.M34) < 9.999999974752427E-07 && Math.Abs(a.OffsetX - b.OffsetX) < 9.999999974752427E-07 && Math.Abs(a.OffsetY - b.OffsetY) < 9.999999974752427E-07 && Math.Abs(a.OffsetZ - b.OffsetZ) < 9.999999974752427E-07)
		{
			return Math.Abs(a.M44 - b.M44) < 9.999999974752427E-07;
		}
		return false;
	}

	public static XbimMatrix3D Copy(XbimMatrix3D m)
	{
		return new XbimMatrix3D(m.M11, m.M12, m.M13, m.M14, m.M21, m.M22, m.M23, m.M24, m.M31, m.M32, m.M33, m.M34, m.OffsetX, m.OffsetY, m.OffsetZ, m.M44);
	}

	public static XbimMatrix3D CreateRotation(XbimPoint3D fromDirection, XbimPoint3D toDirection)
	{
		XbimVector3D xbimVector3D = new XbimVector3D(toDirection.X, toDirection.Y, toDirection.Z);
		XbimVector3D xbimVector3D2 = new XbimVector3D(fromDirection.X, fromDirection.Y, fromDirection.Z);
		xbimVector3D = xbimVector3D.Normalized();
		xbimVector3D2 = xbimVector3D2.Normalized();
		double d = clamp(xbimVector3D.DotProduct(xbimVector3D2), -1.0, 1.0);
		return CreateRotation(axis: XbimVector3D.CrossProduct(xbimVector3D, xbimVector3D2).Normalized(), angle: Math.Acos(d));
	}

	public static XbimMatrix3D FromScaleRotationTranslation(IVector3D scale, XbimQuaternion rotation, IVector3D translation)
	{
		double num = rotation.X * rotation.X;
		double num2 = rotation.X * rotation.Y;
		double num3 = rotation.X * rotation.Z;
		double num4 = rotation.X * rotation.W;
		double num5 = rotation.Y * rotation.Y;
		double num6 = rotation.Y * rotation.Z;
		double num7 = rotation.Y * rotation.W;
		double num8 = rotation.Z * rotation.Z;
		double num9 = rotation.Z * rotation.W;
		double num10 = rotation.W * rotation.W;
		return new XbimMatrix3D((2.0 * (num + num10) - 1.0) * scale.X, 2.0 * (num2 + num9) * scale.X, 2.0 * (num3 - num7) * scale.X, 0.0, 2.0 * (num2 - num9) * scale.Y, (2.0 * (num5 + num10) - 1.0) * scale.Y, 2.0 * (num6 + num4) * scale.Y, 0.0, 2.0 * (num3 + num7) * scale.Z, 2.0 * (num6 - num4) * scale.Z, (2.0 * (num8 + num10) - 1.0) * scale.Z, 0.0, translation.X, translation.Y, translation.Z, 1.0);
	}

	private static double clamp(double x, double minval, double maxval)
	{
		return Math.Min(Math.Max(x, minval), maxval);
	}

	private static XbimMatrix3D CreateRotation(double angle, XbimVector3D axis)
	{
		XbimMatrix3D identity = Identity;
		if (angle == 0.0 || (axis.X == 0.0 && axis.Y == 0.0 && axis.Z == 0.0))
		{
			return identity;
		}
		double num = Math.Sin(angle);
		double num2 = Math.Cos(angle);
		double num3 = axis.X;
		double num4 = axis.Y;
		double num5 = axis.Z;
		if (num3 == 0.0)
		{
			if (num4 == 0.0)
			{
				if (num5 != 0.0)
				{
					identity.M11 = num2;
					identity.M22 = num2;
					if (num5 < 0.0)
					{
						identity.M21 = 0.0 - num;
						identity.M12 = num;
					}
					else
					{
						identity.M21 = num;
						identity.M12 = 0.0 - num;
					}
					return identity;
				}
			}
			else if (num5 == 0.0)
			{
				identity.M11 = num2;
				identity.M33 = num2;
				if (num4 < 0.0)
				{
					identity.M31 = num;
					identity.M13 = 0.0 - num;
				}
				else
				{
					identity.M31 = 0.0 - num;
					identity.M13 = num;
				}
				return identity;
			}
		}
		else if (num4 == 0.0 && num5 == 0.0)
		{
			identity.M22 = num2;
			identity.M33 = num2;
			if (num3 < 0.0)
			{
				identity.M32 = 0.0 - num;
				identity.M23 = num;
			}
			else
			{
				identity.M32 = num;
				identity.M23 = 0.0 - num;
			}
			return identity;
		}
		double num6 = num3 * num3 + num4 * num4 + num5 * num5;
		if (num6 > 1.0001 || num6 < 0.99999)
		{
			double num7 = Math.Sqrt(num6);
			num3 /= num7;
			num4 /= num7;
			num5 /= num7;
		}
		double num8 = num3 * num3;
		double num9 = num4 * num4;
		double num10 = num5 * num5;
		double num11 = num3 * num4;
		double num12 = num4 * num5;
		double num13 = num5 * num3;
		double num14 = num3 * num;
		double num15 = num4 * num;
		double num16 = num5 * num;
		double num17 = 1.0 - num2;
		identity.M11 = num17 * num8 + num2;
		identity.M21 = num17 * num11 + num16;
		identity.M31 = num17 * num13 - num15;
		identity.M12 = num17 * num11 - num16;
		identity.M22 = num17 * num9 + num2;
		identity.M32 = num17 * num12 + num14;
		identity.M13 = num17 * num13 + num15;
		identity.M23 = num17 * num12 - num14;
		identity.M33 = num17 * num10 + num2;
		return identity;
	}

	public static XbimMatrix3D CreateScale(double uniformScale)
	{
		return CreateScale(uniformScale, uniformScale, uniformScale);
	}

	public static XbimMatrix3D CreateScale(double scaleX, double scaleY, double scaleZ)
	{
		return new XbimMatrix3D(scaleX, 0.0, 0.0, 0.0, 0.0, scaleY, 0.0, 0.0, 0.0, 0.0, scaleZ, 0.0, 0.0, 0.0, 0.0, 1.0);
	}

	public static XbimMatrix3D CreateWorld(XbimVector3D position, XbimVector3D forward, XbimVector3D up)
	{
		forward.Normalized();
		XbimVector3D xbimVector3D = forward * -1.0;
		XbimVector3D v = XbimVector3D.CrossProduct(up, xbimVector3D);
		v.Normalized();
		XbimVector3D xbimVector3D2 = XbimVector3D.CrossProduct(xbimVector3D, v);
		return new XbimMatrix3D(v.X, v.Y, v.Z, 0.0, xbimVector3D2.X, xbimVector3D2.Y, xbimVector3D2.Z, 0.0, xbimVector3D.X, xbimVector3D.Y, xbimVector3D.Z, 0.0, position.X, position.Y, position.Z, 0.0);
	}

	public static XbimMatrix3D CreateLookAt(XbimVector3D cameraPosition, XbimVector3D cameraTarget, XbimVector3D cameraUpVector)
	{
		XbimVector3D xbimVector3D = (cameraPosition - cameraTarget).Normalized();
		XbimVector3D xbimVector3D2 = XbimVector3D.CrossProduct(cameraUpVector, xbimVector3D).Normalized();
		XbimVector3D v = XbimVector3D.CrossProduct(xbimVector3D, xbimVector3D2);
		return new XbimMatrix3D(xbimVector3D2.X, v.X, xbimVector3D.X, 0.0, xbimVector3D2.Y, v.Y, xbimVector3D.Y, 0.0, xbimVector3D2.Z, v.Z, xbimVector3D.Z, 0.0, 0.0 - XbimVector3D.DotProduct(xbimVector3D2, cameraPosition), 0.0 - XbimVector3D.DotProduct(v, cameraPosition), 0.0 - XbimVector3D.DotProduct(xbimVector3D, cameraPosition), 1.0);
	}

	public static XbimMatrix3D CreateTranslation(double x, double y, double z)
	{
		return new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, x, y, z, 1.0);
	}

	public static XbimMatrix3D CreateTranslation(XbimVector3D translationVector)
	{
		return CreateTranslation(translationVector.X, translationVector.Y, translationVector.Z);
	}

	public string Str()
	{
		if (IsIdentity)
		{
			return "I";
		}
		return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15}", M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, OffsetX, OffsetY, OffsetZ, M44);
	}

	public bool Decompose(out XbimVector3D scale, out XbimQuaternion rotation, out XbimVector3D translation)
	{
		translation = new XbimVector3D(_offsetX, _offsetY, _offsetZ);
		scale = new XbimVector3D(Math.Sqrt(M11 * M11 + M12 * M12 + M13 * M13), Math.Sqrt(M21 * M21 + M22 * M22 + M23 * M23), Math.Sqrt(M31 * M31 + M32 * M32 + M33 * M33));
		double num = 3E-06;
		if (Math.Abs(scale.X) < num || Math.Abs(scale.Y) < num || Math.Abs(scale.Z) < num)
		{
			rotation = default(XbimQuaternion);
			return false;
		}
		XbimMatrix3D matrix = new XbimMatrix3D
		{
			M11 = M11 / scale.X,
			M12 = M12 / scale.X,
			M13 = M13 / scale.X,
			M21 = M21 / scale.Y,
			M22 = M22 / scale.Y,
			M23 = M23 / scale.Y,
			M31 = M31 / scale.Z,
			M32 = M32 / scale.Z,
			M33 = M33 / scale.Z,
			M44 = 1.0
		};
		XbimQuaternion.RotationMatrix(ref matrix, out rotation);
		return true;
	}

	public XbimVector3D Transform(XbimVector3D xbimVector3D)
	{
		return XbimVector3D.Multiply(xbimVector3D, this);
	}

	public void Invert()
	{
		double m = M11;
		double m2 = M12;
		double m3 = M13;
		double m4 = M14;
		double m5 = M21;
		double m6 = M22;
		double m7 = M23;
		double m8 = M24;
		double m9 = M31;
		double m10 = M32;
		double m11 = M33;
		double m12 = M34;
		double offsetX = OffsetX;
		double offsetY = OffsetY;
		double offsetZ = OffsetZ;
		double m13 = M44;
		double num = m * m6 - m2 * m5;
		double num2 = m * m7 - m3 * m5;
		double num3 = m * m8 - m4 * m5;
		double num4 = m2 * m7 - m3 * m6;
		double num5 = m2 * m8 - m4 * m6;
		double num6 = m3 * m8 - m4 * m7;
		double num7 = m9 * offsetY - m10 * offsetX;
		double num8 = m9 * offsetZ - m11 * offsetX;
		double num9 = m9 * m13 - m12 * offsetX;
		double num10 = m10 * offsetZ - m11 * offsetY;
		double num11 = m10 * m13 - m12 * offsetY;
		double num12 = m11 * m13 - m12 * offsetZ;
		double num13 = num * num12 - num2 * num11 + num3 * num10 + num4 * num9 - num5 * num8 + num6 * num7;
		if (num13 == 0.0)
		{
			throw new XbimException("Matrix does not have an inverse");
		}
		double num14 = 1.0 / num13;
		M11 = (m6 * num12 - m7 * num11 + m8 * num10) * num14;
		M12 = ((0.0 - m2) * num12 + m3 * num11 - m4 * num10) * num14;
		M13 = (offsetY * num6 - offsetZ * num5 + m13 * num4) * num14;
		M14 = ((0.0 - m10) * num6 + m11 * num5 - m12 * num4) * num14;
		M21 = ((0.0 - m5) * num12 + m7 * num9 - m8 * num8) * num14;
		M22 = (m * num12 - m3 * num9 + m4 * num8) * num14;
		M23 = ((0.0 - offsetX) * num6 + offsetZ * num3 - m13 * num2) * num14;
		M24 = (m9 * num6 - m11 * num3 + m12 * num2) * num14;
		M31 = (m5 * num11 - m6 * num9 + m8 * num7) * num14;
		M32 = ((0.0 - m) * num11 + m2 * num9 - m4 * num7) * num14;
		M33 = (offsetX * num5 - offsetY * num3 + m13 * num) * num14;
		M34 = ((0.0 - m9) * num5 + m10 * num3 - m12 * num) * num14;
		OffsetX = ((0.0 - m5) * num10 + m6 * num8 - m7 * num7) * num14;
		OffsetY = (m * num10 - m2 * num8 + m3 * num7) * num14;
		OffsetZ = ((0.0 - offsetX) * num4 + offsetY * num2 - offsetZ * num) * num14;
		M44 = (m9 * num4 - m10 * num2 + m11 * num) * num14;
	}

	public float[] ToFloatArray()
	{
		return new float[16]
		{
			(float)M11,
			(float)M12,
			(float)M13,
			(float)M14,
			(float)M21,
			(float)M22,
			(float)M23,
			(float)M24,
			(float)M31,
			(float)M32,
			(float)M33,
			(float)M34,
			(float)OffsetX,
			(float)OffsetY,
			(float)OffsetZ,
			(float)M44
		};
	}

	public double[] ToDoubleArray()
	{
		return new double[16]
		{
			M11, M12, M13, M14, M21, M22, M23, M24, M31, M32,
			M33, M34, OffsetX, OffsetY, OffsetZ, M44
		};
	}

	public byte[] ToArray(bool useDouble = true)
	{
		if (useDouble)
		{
			byte[] array = new byte[128];
			BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream(array));
			binaryWriter.Write(M11);
			binaryWriter.Write(M12);
			binaryWriter.Write(M13);
			binaryWriter.Write(M14);
			binaryWriter.Write(M21);
			binaryWriter.Write(M22);
			binaryWriter.Write(M23);
			binaryWriter.Write(M24);
			binaryWriter.Write(M31);
			binaryWriter.Write(M32);
			binaryWriter.Write(M33);
			binaryWriter.Write(M34);
			binaryWriter.Write(OffsetX);
			binaryWriter.Write(OffsetY);
			binaryWriter.Write(OffsetZ);
			binaryWriter.Write(M44);
			return array;
		}
		byte[] array2 = new byte[64];
		BinaryWriter binaryWriter2 = new BinaryWriter(new MemoryStream(array2));
		binaryWriter2.Write((float)M11);
		binaryWriter2.Write((float)M12);
		binaryWriter2.Write((float)M13);
		binaryWriter2.Write((float)M14);
		binaryWriter2.Write((float)M21);
		binaryWriter2.Write((float)M22);
		binaryWriter2.Write((float)M23);
		binaryWriter2.Write((float)M24);
		binaryWriter2.Write((float)M31);
		binaryWriter2.Write((float)M32);
		binaryWriter2.Write((float)M33);
		binaryWriter2.Write((float)M34);
		binaryWriter2.Write((float)OffsetX);
		binaryWriter2.Write((float)OffsetY);
		binaryWriter2.Write((float)OffsetZ);
		binaryWriter2.Write((float)M44);
		return array2;
	}

	public void Scale(double s)
	{
		M11 *= s;
		M12 *= s;
		M13 *= s;
		M14 *= s;
		M21 *= s;
		M22 *= s;
		M23 *= s;
		M24 *= s;
		M31 *= s;
		M32 *= s;
		M33 *= s;
		M34 *= s;
	}

	public void Scale(XbimVector3D xbimVector3D)
	{
		double x = xbimVector3D.X;
		double y = xbimVector3D.Y;
		double z = xbimVector3D.Z;
		M11 *= x;
		M12 *= x;
		M13 *= x;
		M14 *= x;
		M21 *= y;
		M22 *= y;
		M23 *= y;
		M24 *= y;
		M31 *= z;
		M32 *= z;
		M33 *= z;
		M34 *= z;
	}

	public void RotateAroundXAxis(double radAngle)
	{
		double num = Math.Sin(radAngle);
		double num2 = Math.Cos(radAngle);
		double m = _m21;
		double m2 = _m22;
		double m3 = _m23;
		double m4 = _m24;
		double m5 = _m31;
		double m6 = _m32;
		double m7 = _m33;
		double m8 = _m34;
		if (IsIdentity)
		{
			_m22 = num2;
			_m23 = num;
			_m32 = 0.0 - num;
			_m33 = num2;
			return;
		}
		_m21 = m * num2 + m5 * num;
		_m22 = m2 * num2 + m6 * num;
		_m23 = m3 * num2 + m7 * num;
		_m24 = m4 * num2 + m8 * num;
		_m31 = m * (0.0 - num) + m5 * num2;
		_m32 = m2 * (0.0 - num) + m6 * num2;
		_m33 = m3 * (0.0 - num) + m7 * num2;
		_m34 = m4 * (0.0 - num) + m8 * num2;
	}

	public void RotateAroundYAxis(double radAngle)
	{
		double num = Math.Sin(radAngle);
		double num2 = Math.Cos(radAngle);
		double m = _m11;
		double m2 = _m12;
		double m3 = _m13;
		double m4 = _m14;
		double m5 = _m31;
		double m6 = _m32;
		double m7 = _m33;
		double m8 = _m34;
		if (IsIdentity)
		{
			_m11 = num2;
			_m13 = 0.0 - num;
			_m31 = num;
			_m33 = num2;
			return;
		}
		_m11 = m * num2 + m5 * (0.0 - num);
		_m12 = m2 * num2 + m6 * (0.0 - num);
		_m13 = m3 * num2 + m7 * (0.0 - num);
		_m14 = m4 * num2 + m8 * (0.0 - num);
		_m31 = m * num + m5 * num2;
		_m32 = m2 * num + m6 * num2;
		_m33 = m3 * num + m7 * num2;
		_m34 = m4 * num + m8 * num2;
	}

	public void RotateAroundZAxis(double radAngle)
	{
		double num = Math.Sin(radAngle);
		double num2 = Math.Cos(radAngle);
		double m = _m11;
		double m2 = _m12;
		double m3 = _m13;
		double m4 = _m14;
		double m5 = _m21;
		double m6 = _m22;
		double m7 = _m23;
		double m8 = _m24;
		if (IsIdentity)
		{
			_m11 = num2;
			_m12 = num;
			_m21 = 0.0 - num;
			_m22 = num2;
			return;
		}
		_m11 = m * num2 + m5 * num;
		_m12 = m2 * num2 + m6 * num;
		_m13 = m3 * num2 + m7 * num;
		_m14 = m4 * num2 + m8 * num;
		_m21 = m * (0.0 - num) + m5 * num2;
		_m22 = m2 * (0.0 - num) + m6 * num2;
		_m23 = m3 * (0.0 - num) + m7 * num2;
		_m24 = m4 * (0.0 - num) + m8 * num2;
	}

	public XbimQuaternion GetRotationQuaternion()
	{
		Decompose(out var _, out var rotation, out var _);
		return rotation;
	}
}
