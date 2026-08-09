using System;
using System.Runtime.InteropServices;

namespace Xbim.Common.Geometry;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct XbimQuaternion
{
	private static readonly XbimQuaternion _identity;

	private double _x;

	private double _y;

	private double _z;

	private double _w;

	private bool _isNotDefaultInitialised;

	public double X
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _x;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_x = value;
		}
	}

	public double Y
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _y;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_y = value;
		}
	}

	public double Z
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _z;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_z = value;
		}
	}

	public double W
	{
		get
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			return _w;
		}
		set
		{
			if (!_isNotDefaultInitialised)
			{
				this = _identity;
			}
			_w = value;
		}
	}

	static XbimQuaternion()
	{
		_identity = new XbimQuaternion(0.0, 0.0, 0.0, 1.0);
		_identity._isNotDefaultInitialised = true;
	}

	public XbimQuaternion(double x, double y, double z, double w)
	{
		_x = x;
		_y = y;
		_z = z;
		_w = w;
		_isNotDefaultInitialised = false;
	}

	public static void RotationMatrix(ref XbimMatrix3D matrix, out XbimQuaternion result)
	{
		double num = matrix.M11 + matrix.M22 + matrix.M33;
		result = default(XbimQuaternion);
		if (num > 0.0)
		{
			double num2 = Math.Sqrt(num + 1.0);
			result.W = num2 * 0.5;
			num2 = 0.5 / num2;
			result.X = (matrix.M23 - matrix.M32) * num2;
			result.Y = (matrix.M31 - matrix.M13) * num2;
			result.Z = (matrix.M12 - matrix.M21) * num2;
		}
		else if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33)
		{
			double num2 = Math.Sqrt(1.0 + matrix.M11 - matrix.M22 - matrix.M33);
			double num3 = 0.5 / num2;
			result.X = 0.5 * num2;
			result.Y = (matrix.M12 + matrix.M21) * num3;
			result.Z = (matrix.M13 + matrix.M31) * num3;
			result.W = (matrix.M23 - matrix.M32) * num3;
		}
		else if (matrix.M22 > matrix.M33)
		{
			double num2 = Math.Sqrt(1.0 + matrix.M22 - matrix.M11 - matrix.M33);
			double num3 = 0.5 / num2;
			result.X = (matrix.M21 + matrix.M12) * num3;
			result.Y = 0.5 * num2;
			result.Z = (matrix.M32 + matrix.M23) * num3;
			result.W = (matrix.M31 - matrix.M13) * num3;
		}
		else
		{
			double num2 = Math.Sqrt(1.0 + matrix.M33 - matrix.M11 - matrix.M22);
			double num3 = 0.5 / num2;
			result.X = (matrix.M31 + matrix.M13) * num3;
			result.Y = (matrix.M32 + matrix.M23) * num3;
			result.Z = 0.5 * num2;
			result.W = (matrix.M12 - matrix.M21) * num3;
		}
	}

	public bool IsIdentity()
	{
		if (!_isNotDefaultInitialised)
		{
			return true;
		}
		if (Math.Abs(X - _identity.X) < double.Epsilon && Math.Abs(Y - _identity.Y) < double.Epsilon && Math.Abs(Z - _identity.Z) < double.Epsilon)
		{
			return Math.Abs(W - _identity.W) < double.Epsilon;
		}
		return false;
	}

	public static void Transform(ref XbimVector3D vector, ref XbimQuaternion rotation, out XbimVector3D result)
	{
		double num = rotation.X + rotation.X;
		double num2 = rotation.Y + rotation.Y;
		double num3 = rotation.Z + rotation.Z;
		double num4 = rotation.W * num;
		double num5 = rotation.W * num2;
		double num6 = rotation.W * num3;
		double num7 = rotation.X * num;
		double num8 = rotation.X * num2;
		double num9 = rotation.X * num3;
		double num10 = rotation.Y * num2;
		double num11 = rotation.Y * num3;
		double num12 = rotation.Z * num3;
		result = new XbimVector3D(vector.X * (1.0 - num10 - num12) + vector.Y * (num8 - num6) + vector.Z * (num9 + num5), vector.X * (num8 + num6) + vector.Y * (1.0 - num7 - num12) + vector.Z * (num11 - num4), vector.X * (num9 - num5) + vector.Y * (num11 + num4) + vector.Z * (1.0 - num7 - num10));
	}
}
