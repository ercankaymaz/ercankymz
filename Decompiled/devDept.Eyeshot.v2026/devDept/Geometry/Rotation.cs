using System;
using System.Runtime.Serialization;

namespace devDept.Geometry;

[Serializable]
[Obsolete("Use Transformation.CreateRotation() instead.")]
public class Rotation : Transformation
{
	public Rotation(double angleInRadians, Vector3D axis)
	{
		Rotation(angleInRadians, axis);
	}

	public Rotation(double angleInRadians, Vector3D axis, Point3D center)
	{
		Rotation(angleInRadians, axis, center);
	}

	public Rotation(double angleInRadians, Point3D axisStart, Point3D axisEnd)
	{
		Rotation(angleInRadians, axisStart, axisEnd);
	}

	protected Rotation(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public Rotation(int firstNodeIndex, int secondNodeIndex, Point3D[] nodes)
	{
		_0023_003Dzwwd8lwZlkxhItKiJuA_003D_003D(Vector3D.Subtract(nodes[secondNodeIndex], nodes[firstNodeIndex]));
	}

	public Rotation(Vector2D xAxis)
	{
		_0023_003Dzwwd8lwZlkxhItKiJuA_003D_003D(xAxis);
	}

	public Rotation(int firstNodeIndex, int secondNodeIndex, int thirdNodeIndex, Point3D[] nodes)
	{
		_0023_003DzVBKXZC6Sj4oPUTXSxg_003D_003D(Vector3D.Subtract(nodes[secondNodeIndex], nodes[firstNodeIndex]), Vector3D.Subtract(nodes[thirdNodeIndex], nodes[firstNodeIndex]));
	}

	public Rotation(double alpha, double beta, double gamma)
	{
		Rotation rotation = new Rotation(alpha, Vector3D.AxisX);
		Rotation rotation2 = new Rotation(beta, Vector3D.AxisY);
		Transformation transformation = new Rotation(gamma, Vector3D.AxisZ) * rotation2 * rotation;
		base.Matrix = transformation.Matrix;
	}

	public Rotation(Vector3D xAxis, Vector3D yAxis)
	{
		_0023_003DzVBKXZC6Sj4oPUTXSxg_003D_003D(xAxis, yAxis);
	}

	public new void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}

	private void _0023_003Dzwwd8lwZlkxhItKiJuA_003D_003D(Vector2D _0023_003Dztv6hMfw_003D)
	{
		if (_0023_003Dztv6hMfw_003D.Normalize())
		{
			base.Matrix[0, 0] = _0023_003Dztv6hMfw_003D.X;
			base.Matrix[1, 1] = _0023_003Dztv6hMfw_003D.X;
			base.Matrix[1, 0] = 0.0 - _0023_003Dztv6hMfw_003D.Y;
			base.Matrix[0, 1] = _0023_003Dztv6hMfw_003D.Y;
			base.Matrix[2, 2] = 1.0;
		}
		else
		{
			base.Matrix[0, 0] = 1.0;
			base.Matrix[1, 1] = 1.0;
			base.Matrix[2, 2] = 1.0;
		}
	}

	internal static void _0023_003DzHYKmfEmUvliP(Rotation _0023_003DzJiBboSI_003D, out double _0023_003DzWkUPZLg_003D, out double _0023_003DzpjSkdJn4nx2K, out double _0023_003DzwK8u8qc_003D)
	{
		double[,] array = devDept.Geometry.Matrix.Transpose(_0023_003DzJiBboSI_003D.Matrix);
		double num = array[2, 0];
		if (num == 1.0)
		{
			_0023_003DzpjSkdJn4nx2K = -Math.PI / 2.0;
			_0023_003DzwK8u8qc_003D = 0.0;
			_0023_003DzWkUPZLg_003D = 0.0 - _0023_003DzwK8u8qc_003D + Math.Atan2(0.0 - array[0, 1], 0.0 - array[0, 2]);
		}
		else if (num == -1.0)
		{
			_0023_003DzpjSkdJn4nx2K = Math.PI / 2.0;
			_0023_003DzwK8u8qc_003D = 0.0;
			_0023_003DzWkUPZLg_003D = _0023_003DzwK8u8qc_003D + Math.Atan2(array[0, 1], array[0, 2]);
		}
		else
		{
			_0023_003DzpjSkdJn4nx2K = 0.0 - Math.Asin(num);
			double num2 = Math.Cos(_0023_003DzpjSkdJn4nx2K);
			_0023_003DzWkUPZLg_003D = Math.Atan2(array[2, 1] / num2, array[2, 2] / num2);
			_0023_003DzwK8u8qc_003D = Math.Atan2(array[1, 0] / num2, array[0, 0] / num2);
		}
	}

	private void _0023_003DzVBKXZC6Sj4oPUTXSxg_003D_003D(Vector3D _0023_003Dztv6hMfw_003D, Vector3D _0023_003Dztg84lvw_003D)
	{
		Vector3D b = _0023_003Dztg84lvw_003D;
		Vector3D vector3D = Vector3D.Cross(_0023_003Dztv6hMfw_003D, b);
		b = Vector3D.Cross(vector3D, _0023_003Dztv6hMfw_003D);
		if (_0023_003Dztv6hMfw_003D.Normalize() && b.Normalize() && vector3D.Normalize())
		{
			base.Matrix[0, 0] = _0023_003Dztv6hMfw_003D.X;
			base.Matrix[0, 1] = _0023_003Dztv6hMfw_003D.Y;
			base.Matrix[0, 2] = _0023_003Dztv6hMfw_003D.Z;
			base.Matrix[1, 0] = b.X;
			base.Matrix[1, 1] = b.Y;
			base.Matrix[1, 2] = b.Z;
			base.Matrix[2, 0] = vector3D.X;
			base.Matrix[2, 1] = vector3D.Y;
			base.Matrix[2, 2] = vector3D.Z;
		}
		else
		{
			base.Matrix[0, 0] = 1.0;
			base.Matrix[1, 1] = 1.0;
			base.Matrix[2, 2] = 1.0;
		}
	}
}
