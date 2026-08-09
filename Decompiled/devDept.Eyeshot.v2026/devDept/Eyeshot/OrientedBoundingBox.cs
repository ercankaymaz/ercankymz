using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class OrientedBoundingBox : OrientedBoundingRect
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal new Size3D _0023_003DzPcQdeHOMvY_0024e = new Size3D(0.0, 0.0, 0.0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal new Size3D _0023_003DzGZ0TqShlfr9O;

	protected Vector3D _componentZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static ushort _0023_003DzszzjyBDXuKw6 = 3855;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ushort _0023_003DzVe_0024yuN2XL3_0024c = _0023_003DzszzjyBDXuKw6;

	public override Point2D Size
	{
		get
		{
			if (_0023_003DzGZ0TqShlfr9O == null || _0023_003DziQOhVy0_003D)
			{
				Transformation fullTransformation = GetFullTransformation();
				return new Size3D(_0023_003DzPcQdeHOMvY_0024e.X * fullTransformation.ScaleFactorX, _0023_003DzPcQdeHOMvY_0024e.Y * fullTransformation.ScaleFactorY, _0023_003DzPcQdeHOMvY_0024e.Z * fullTransformation.ScaleFactorZ);
			}
			return _0023_003DzGZ0TqShlfr9O;
		}
	}

	public OrientedBoundingBox(Point3D origin, double width, double depth, double height)
		: base(origin, width, height)
	{
		_0023_003DzPcQdeHOMvY_0024e = new Size3D(width, depth, height);
		_transformation = new Translation(origin.X, origin.Y, origin.Z);
		needToUpdate = true;
	}

	public OrientedBoundingBox(Point3D origin, Vector3D axisX, Vector3D axisY, double width, double depth, double height)
		: this(origin, width, depth, height)
	{
		Align3D transformation = new Align3D(Plane.XY, new Plane(origin, axisX, axisY));
		_transformation = transformation;
		needToUpdate = true;
	}

	public OrientedBoundingBox(IList<Point2D> pointCloud, Vector3D axisX, Vector3D axisY)
		: base(Point2D.Origin, 0.0, 0.0)
	{
		Plane plane = new Plane(Point3D.Origin, axisX, axisY);
		Vector3D axisZ = plane.AxisZ;
		Vector3D[] array = new Vector3D[3] { axisX, axisY, axisZ };
		Point3D[] _0023_003DzoOMH0wZBhkab;
		double[] _0023_003DzrdSL0CI_003D = _0023_003DzmRIQc83K9njuVqEihw_003D_003D(pointCloud, out _0023_003DzoOMH0wZBhkab);
		_0023_003DziusUiMCxltDmbjhcdeH7GeQ_003D(_0023_003DzrdSL0CI_003D, array, out var _0023_003DzzIuoxRCeLmZB, out var _0023_003Dzr3DDjEqJ95CF);
		plane.Origin.TransformBy(new Translation(array[0] * _0023_003DzzIuoxRCeLmZB[0]));
		plane.Origin.TransformBy(new Translation(array[1] * _0023_003DzzIuoxRCeLmZB[1]));
		plane.Origin.TransformBy(new Translation(array[2] * _0023_003DzzIuoxRCeLmZB[2]));
		Transformation _0023_003DzPzO_0024GUk_003D = new Align3D(Plane.XY, plane);
		_0023_003DznTv6jJyUD3Pu(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzPcQdeHOMvY_0024e = new Size3D(new Point3D(_0023_003DzzIuoxRCeLmZB), new Point3D(_0023_003Dzr3DDjEqJ95CF));
		needToUpdate = true;
		_0023_003DziQOhVy0_003D = false;
		_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
	}

	public OrientedBoundingBox(IList<Point2D> pointCloud, Vector3D orientation)
		: base(Point2D.Origin, 0.0, 0.0)
	{
		Transformation transformation = Transformation.CreateAlignment(new Plane(Point3D.Origin, orientation), Plane.XY);
		List<Point2D> list = new List<Point2D>();
		double num = double.MaxValue;
		double num2 = double.MinValue;
		for (int num3 = pointCloud.Count - 1; num3 >= 0; num3--)
		{
			Point3D point3D = (Point3D)pointCloud[num3].Clone();
			point3D.TransformBy(transformation);
			if (point3D.Z < num)
			{
				num = point3D.Z;
			}
			if (point3D.Z > num2)
			{
				num2 = point3D.Z;
			}
			bool flag = false;
			foreach (Point2D item in list)
			{
				if (Math.Abs(item.X - point3D.X) < 1E-12 && Math.Abs(item.Y - point3D.Y) < 1E-12)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(new Point2D(point3D.X, point3D.Y));
			}
		}
		OrientedBoundingRect orientedBoundingRect = new OrientedBoundingRect(list);
		Point2D origin = orientedBoundingRect.GetOrigin();
		Vector2D[] axis = orientedBoundingRect.GetAxis();
		transformation.Invert();
		_0023_003DznTv6jJyUD3Pu(transformation * Transformation.CreateAlignment(Plane.XY, new Plane(new Point3D(origin.X, origin.Y, num), new Vector3D(axis[0].X, axis[0].Y, 0.0), new Vector3D(axis[1].X, axis[1].Y, 0.0))));
		_0023_003DzPcQdeHOMvY_0024e = new Size3D(orientedBoundingRect.Size.X, orientedBoundingRect.Size.Y, num2 - num);
		needToUpdate = true;
		_0023_003DziQOhVy0_003D = false;
		_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
	}

	public OrientedBoundingBox(IList<Point2D> pointCloud)
		: base(Point2D.Origin, 0.0, 0.0)
	{
		_0023_003DzYmmm7HJwAVJv8BhDyQ_003D_003D(pointCloud);
		needToUpdate = true;
	}

	protected OrientedBoundingBox(OrientedBoundingBox another)
		: base(another)
	{
		_0023_003DzPcQdeHOMvY_0024e = new Size3D(another._0023_003DzPcQdeHOMvY_0024e.X, another._0023_003DzPcQdeHOMvY_0024e.Y, another._0023_003DzPcQdeHOMvY_0024e.Z);
	}

	public override Point2D GetOrigin()
	{
		if (needToUpdate)
		{
			UpdateOrigin();
		}
		return (Point3D)_0023_003DzU_D1Mh3KgbPX().Clone();
	}

	protected override void UpdateOrigin()
	{
		_origin = Point3D.Origin;
		_origin.TransformBy(GetFullTransformation());
	}

	public override Vector2D[] GetAxis()
	{
		if (needToUpdate)
		{
			UpdateAxis();
		}
		return new Vector3D[3]
		{
			(Vector3D)_0023_003DzwFgeztXTDiyb()[0].Clone(),
			(Vector3D)_0023_003DzwFgeztXTDiyb()[1].Clone(),
			(Vector3D)_0023_003DzwFgeztXTDiyb()[2].Clone()
		};
	}

	protected override void UpdateData()
	{
		if (needToUpdate)
		{
			UpdateAxis();
			UpdateOrigin();
			_componentX = null;
			_componentY = null;
			_componentZ = null;
			_0023_003DzGZ0TqShlfr9O = null;
			needToUpdate = false;
		}
	}

	protected override void UpdateAxis()
	{
		Vector2D[] axis = new Vector3D[3]
		{
			Vector3D.AxisX,
			Vector3D.AxisY,
			Vector3D.AxisZ
		};
		_axis = axis;
		Transformation fullTransformation = GetFullTransformation();
		((Vector3D)_axis[0]).TransformBy(fullTransformation);
		((Vector3D)_axis[1]).TransformBy(fullTransformation);
		((Vector3D)_axis[2]).TransformBy(fullTransformation);
		((Vector3D)_axis[0]).Normalize();
		((Vector3D)_axis[1]).Normalize();
		((Vector3D)_axis[2]).Normalize();
	}

	[SpecialName]
	internal override Vector2D _0023_003Dzh4_kjFUbrJxh()
	{
		if (needToUpdate || _componentX == null)
		{
			_componentX = (Vector3D)_0023_003DzwFgeztXTDiyb()[0] * Size.X;
		}
		return _componentX;
	}

	[SpecialName]
	internal override Vector2D _0023_003DzrI8_Aef5mDa4()
	{
		if (needToUpdate || _componentY == null)
		{
			_componentY = (Vector3D)_0023_003DzwFgeztXTDiyb()[1] * Size.Y;
		}
		return (Vector3D)_componentY;
	}

	internal Vector3D _0023_003DzTYQbumyxLCOo()
	{
		if (needToUpdate || _componentZ == null)
		{
			_componentZ = (Vector3D)_0023_003DzwFgeztXTDiyb()[2] * ((Point3D)Size).Z;
		}
		return _componentZ;
	}

	public override Point2D[] GetVertices()
	{
		if (needToUpdate)
		{
			UpdateData();
		}
		return new Point3D[8]
		{
			(Point3D)_0023_003DzU_D1Mh3KgbPX().Clone(),
			(Point3D)_0023_003DzU_D1Mh3KgbPX() + (Vector3D)_0023_003Dzh4_kjFUbrJxh(),
			(Point3D)_0023_003DzU_D1Mh3KgbPX() + (Vector3D)_0023_003Dzh4_kjFUbrJxh() + (Vector3D)_0023_003DzrI8_Aef5mDa4(),
			(Point3D)_0023_003DzU_D1Mh3KgbPX() + (Vector3D)_0023_003DzrI8_Aef5mDa4(),
			(Point3D)_0023_003DzU_D1Mh3KgbPX() + _0023_003DzTYQbumyxLCOo(),
			(Point3D)_0023_003DzU_D1Mh3KgbPX() + _0023_003DzTYQbumyxLCOo() + (Vector3D)_0023_003Dzh4_kjFUbrJxh(),
			(Point3D)_0023_003DzU_D1Mh3KgbPX() + _0023_003DzTYQbumyxLCOo() + (Vector3D)_0023_003DzrI8_Aef5mDa4() + (Vector3D)_0023_003Dzh4_kjFUbrJxh(),
			(Point3D)_0023_003DzU_D1Mh3KgbPX() + _0023_003DzTYQbumyxLCOo() + (Vector3D)_0023_003DzrI8_Aef5mDa4()
		};
	}

	public override object Clone()
	{
		return new OrientedBoundingBox(this);
	}

	private void _0023_003DzYmmm7HJwAVJv8BhDyQ_003D_003D(IList<Point2D> _0023_003DzowJ91FqbMlIg)
	{
		Vector3D[] array = new Vector3D[3];
		Point3D[] _0023_003DzoOMH0wZBhkab;
		double[] _0023_003DzrdSL0CI_003D = _0023_003DzmRIQc83K9njuVqEihw_003D_003D(_0023_003DzowJ91FqbMlIg, out _0023_003DzoOMH0wZBhkab);
		double[] _0023_003DzbUvT9Pc_003D;
		double[,] array2 = _0023_003DzhmmevJvecPIvKI8PzAMeXXw_003D(_0023_003DzrdSL0CI_003D, out _0023_003DzbUvT9Pc_003D);
		if (!_0023_003Dz9DRqciTZEb8_0024F2cj7CbVCXob8dXwTAtS1w_003D_003D(array2[0, 0], array2[1, 1], array2[2, 2], array2[0, 1], array2[0, 2], array2[1, 2], array2, out array[0], out array[1], out array[2]))
		{
			Utility.ComputeBoundingBox(null, _0023_003DzoOMH0wZBhkab, _0023_003DzowJ91FqbMlIg.Count, out var boxMin, out var boxMax);
			_0023_003DznTv6jJyUD3Pu(new Translation(boxMin.X, boxMin.Y, boxMin.Z));
			_0023_003DzPcQdeHOMvY_0024e = new Size3D(boxMin, boxMax);
			needToUpdate = true;
			_0023_003DziQOhVy0_003D = false;
			_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
			return;
		}
		Plane plane = new Plane(Point3D.Origin, array[0], array[1]);
		if (!Point3D.AreEqual(array[2].AsPoint, plane.AxisZ.AsPoint, 1.0))
		{
			array[2] = plane.AxisZ;
		}
		_0023_003DziusUiMCxltDmbjhcdeH7GeQ_003D(_0023_003DzrdSL0CI_003D, array, out var _0023_003DzzIuoxRCeLmZB, out var _0023_003Dzr3DDjEqJ95CF);
		plane.Origin.TransformBy(new Translation(array[0] * _0023_003DzzIuoxRCeLmZB[0]));
		plane.Origin.TransformBy(new Translation(array[1] * _0023_003DzzIuoxRCeLmZB[1]));
		plane.Origin.TransformBy(new Translation(array[2] * _0023_003DzzIuoxRCeLmZB[2]));
		Transformation _0023_003DzPzO_0024GUk_003D = new Align3D(Plane.XY, plane);
		_0023_003DznTv6jJyUD3Pu(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzPcQdeHOMvY_0024e = new Size3D(new Point3D(_0023_003DzzIuoxRCeLmZB), new Point3D(_0023_003Dzr3DDjEqJ95CF));
		needToUpdate = true;
		_0023_003DziQOhVy0_003D = false;
		_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
	}

	internal double[,] _0023_003DzhmmevJvecPIvKI8PzAMeXXw_003D(double[] _0023_003DzrdSL0CI_003D, out double[] _0023_003DzbUvT9Pc_003D)
	{
		double num = 1.0;
		double[,] array = new double[3, 3];
		double[] array2 = new double[3];
		int num2;
		for (num2 = 0; num2 < _0023_003DzrdSL0CI_003D.Length; num2++)
		{
			array2[0] += _0023_003DzrdSL0CI_003D[num2];
			array2[1] += _0023_003DzrdSL0CI_003D[++num2];
			array2[2] += _0023_003DzrdSL0CI_003D[++num2];
		}
		array2[0] = array2[0] / ((double)_0023_003DzrdSL0CI_003D.Length / 3.0) / num;
		array2[1] = array2[1] / ((double)_0023_003DzrdSL0CI_003D.Length / 3.0) / num;
		array2[2] = array2[2] / ((double)_0023_003DzrdSL0CI_003D.Length / 3.0) / num;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i, j] = 0.0;
				for (int k = 0; k < _0023_003DzrdSL0CI_003D.Length; k += 3)
				{
					array[i, j] += (array2[i] - _0023_003DzrdSL0CI_003D[k + i] / num) * (array2[j] - _0023_003DzrdSL0CI_003D[k + j] / num);
				}
				double num3 = _0023_003DzrdSL0CI_003D.Length / 3 - 1;
				array[i, j] /= num3;
			}
		}
		_0023_003DzbUvT9Pc_003D = array2;
		return array;
	}

	private void _0023_003DziusUiMCxltDmbjhcdeH7GeQ_003D(double[] _0023_003DzrdSL0CI_003D, Vector3D[] _0023_003DzmbZmnckmzEJv, out double[] _0023_003DzzIuoxRCeLmZB, out double[] _0023_003Dzr3DDjEqJ95CF)
	{
		_0023_003DzXzFvxyg8v2WM(Point3D.Origin);
		double[] array = new double[3];
		double[] array2 = new double[3];
		for (int i = 0; i < 3; i++)
		{
			Vector3D v = _0023_003DzmbZmnckmzEJv[i];
			Point3D p = new Point3D(_0023_003DzrdSL0CI_003D[0], _0023_003DzrdSL0CI_003D[1], _0023_003DzrdSL0CI_003D[2]);
			array[i] = Vector3D.Dot(v, p);
			array2[i] = Vector3D.Dot(v, p);
			int num;
			for (num = 3; num < _0023_003DzrdSL0CI_003D.Length; num++)
			{
				Point3D p2 = new Point3D(_0023_003DzrdSL0CI_003D[num], _0023_003DzrdSL0CI_003D[++num], _0023_003DzrdSL0CI_003D[++num]);
				double val = Vector3D.Dot(v, p2);
				array[i] = Math.Min(array[i], val);
				array2[i] = Math.Max(array2[i], val);
			}
		}
		_0023_003DzzIuoxRCeLmZB = array;
		_0023_003Dzr3DDjEqJ95CF = array2;
	}

	internal double[] _0023_003DzmRIQc83K9njuVqEihw_003D_003D(IList<Point2D> _0023_003DzrdSL0CI_003D, out Point3D[] _0023_003DzoOMH0wZBhkab)
	{
		_0023_003DzoOMH0wZBhkab = new Point3D[_0023_003DzrdSL0CI_003D.Count];
		double[] array = new double[_0023_003DzrdSL0CI_003D.Count * 3];
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Count; i++)
		{
			array[i * 3] = _0023_003DzrdSL0CI_003D[i].X;
			array[i * 3 + 1] = _0023_003DzrdSL0CI_003D[i].Y;
			array[i * 3 + 2] = ((Point3D)_0023_003DzrdSL0CI_003D[i]).Z;
			_0023_003DzoOMH0wZBhkab[i] = (Point3D)_0023_003DzrdSL0CI_003D[i];
		}
		return array;
	}

	private void _0023_003DzyvJI0pbmsOTG(double[,] _0023_003Dz1CpmY6Bb5o3N, out double _0023_003DzVufSfd4_003D, out double _0023_003DzWCb_GsUb_0024PKW, out double _0023_003DzHfEFovwEcsAs)
	{
		double num = 0.0 - _0023_003Dz1CpmY6Bb5o3N[2, 0];
		double num2 = Math.Sqrt(1.0 - num * num);
		double y;
		double x;
		double y2;
		double x2;
		if (Math.Abs(num2) > 10.0)
		{
			y = _0023_003Dz1CpmY6Bb5o3N[2, 1] / num2;
			x = _0023_003Dz1CpmY6Bb5o3N[2, 2] / num2;
			y2 = _0023_003Dz1CpmY6Bb5o3N[1, 0] / num2;
			x2 = _0023_003Dz1CpmY6Bb5o3N[0, 0] / num2;
		}
		else
		{
			y = 0.0 - _0023_003Dz1CpmY6Bb5o3N[1, 2];
			x = _0023_003Dz1CpmY6Bb5o3N[1, 1];
			y2 = 0.0;
			x2 = 1.0;
		}
		_0023_003DzVufSfd4_003D = Math.Atan2(y2, x2) * 180.0 / Math.PI;
		_0023_003DzWCb_GsUb_0024PKW = Math.Atan2(num, num2) * 180.0 / Math.PI;
		_0023_003DzHfEFovwEcsAs = Math.Atan2(y, x) * 180.0 / Math.PI;
	}

	private static bool _0023_003Dz9DRqciTZEb8_0024F2cj7CbVCXob8dXwTAtS1w_003D_003D(double _0023_003DziBUQaxQ_003D, double _0023_003Dzj7R2n7s_003D, double _0023_003DzTE9Q7QY_003D, double _0023_003DzDrsOjho_003D, double _0023_003Dz_0024t1YGpA_003D, double _0023_003Dz7sUcotE_003D, double[,] _0023_003Dz_bfkZEYTtpP3, out Vector3D _0023_003DzJm8Md4c_003D, out Vector3D _0023_003DzkD_Pkaw_003D, out Vector3D _0023_003DzsjXs7dE_003D)
	{
		double _0023_003DzbfrNXYE_003D = 0.0 - (_0023_003DziBUQaxQ_003D + _0023_003Dzj7R2n7s_003D + _0023_003DzTE9Q7QY_003D);
		double _0023_003DzhidJeNw_003D = _0023_003DziBUQaxQ_003D * _0023_003Dzj7R2n7s_003D + _0023_003Dzj7R2n7s_003D * _0023_003DzTE9Q7QY_003D + _0023_003DzTE9Q7QY_003D * _0023_003DziBUQaxQ_003D - _0023_003DzDrsOjho_003D * _0023_003DzDrsOjho_003D - _0023_003Dz_0024t1YGpA_003D * _0023_003Dz_0024t1YGpA_003D - _0023_003Dz7sUcotE_003D * _0023_003Dz7sUcotE_003D;
		double _0023_003Dz5rQzobg_003D = _0023_003DzDrsOjho_003D * _0023_003DzDrsOjho_003D * _0023_003DzTE9Q7QY_003D + _0023_003Dz_0024t1YGpA_003D * _0023_003Dz_0024t1YGpA_003D * _0023_003Dzj7R2n7s_003D + _0023_003Dz7sUcotE_003D * _0023_003Dz7sUcotE_003D * _0023_003DziBUQaxQ_003D - _0023_003DzDrsOjho_003D * _0023_003Dz7sUcotE_003D * _0023_003Dz_0024t1YGpA_003D * 2.0 - _0023_003DziBUQaxQ_003D * _0023_003Dzj7R2n7s_003D * _0023_003DzTE9Q7QY_003D;
		if (!_0023_003DzKu37C_l6iiGZ(_0023_003DzbfrNXYE_003D, _0023_003DzhidJeNw_003D, _0023_003Dz5rQzobg_003D, out var _0023_003DzNDQ_E88_003D, out var _0023_003Dz_eY3Y4c_003D, out var _0023_003Dz77g161c_003D))
		{
			_0023_003DzJm8Md4c_003D = new Vector3D(1.0, 0.0, 0.0);
			_0023_003DzkD_Pkaw_003D = new Vector3D(0.0, 1.0, 0.0);
			_0023_003DzsjXs7dE_003D = new Vector3D(0.0, 0.0, 1.0);
			return false;
		}
		double[] obj = new double[3] { _0023_003DzNDQ_E88_003D, _0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D };
		Array.Sort(obj);
		_0023_003DzNDQ_E88_003D = obj[2];
		_0023_003Dz_eY3Y4c_003D = obj[1];
		_0023_003Dz77g161c_003D = obj[0];
		bool result = _0023_003DzC5t4EhYbWMr5UcvRuQ_003D_003D(_0023_003DziBUQaxQ_003D, _0023_003DzDrsOjho_003D, _0023_003Dz_0024t1YGpA_003D, _0023_003Dzj7R2n7s_003D, _0023_003Dz7sUcotE_003D, _0023_003DzTE9Q7QY_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D, out _0023_003DzJm8Md4c_003D, out _0023_003DzkD_Pkaw_003D, out _0023_003DzsjXs7dE_003D);
		_0023_003Dzj9H9TFlgcU_0024WQ3erIg_003D_003D(_0023_003Dz_bfkZEYTtpP3, _0023_003DzJm8Md4c_003D, _0023_003DzNDQ_E88_003D, 1);
		_0023_003Dzj9H9TFlgcU_0024WQ3erIg_003D_003D(_0023_003Dz_bfkZEYTtpP3, _0023_003DzkD_Pkaw_003D, _0023_003Dz_eY3Y4c_003D, 2);
		_0023_003Dzj9H9TFlgcU_0024WQ3erIg_003D_003D(_0023_003Dz_bfkZEYTtpP3, _0023_003DzsjXs7dE_003D, _0023_003Dz77g161c_003D, 3);
		if (!Vector3D.AreCoincident(Vector3D.Cross(_0023_003DzJm8Md4c_003D, _0023_003DzkD_Pkaw_003D), _0023_003DzsjXs7dE_003D) && Vector3D.AreCoincident(Vector3D.Cross(_0023_003DzkD_Pkaw_003D, _0023_003DzJm8Md4c_003D), _0023_003DzsjXs7dE_003D))
		{
			Vector3D vector3D = _0023_003DzkD_Pkaw_003D;
			_0023_003DzkD_Pkaw_003D = _0023_003DzJm8Md4c_003D;
			_0023_003DzJm8Md4c_003D = vector3D;
		}
		return result;
	}

	private static void _0023_003Dzj9H9TFlgcU_0024WQ3erIg_003D_003D(double[,] _0023_003Dz_bfkZEYTtpP3, Vector3D _0023_003DzJm8Md4c_003D, double _0023_003Dzd4SeU9c_003D, int _0023_003Dz437_00244ak_003D)
	{
		double[] array = new double[3];
		double[] array2 = new double[3] { _0023_003DzJm8Md4c_003D.X, _0023_003DzJm8Md4c_003D.Y, _0023_003DzJm8Md4c_003D.Z };
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i] += _0023_003Dz_bfkZEYTtpP3[i, j] * array2[j];
			}
		}
		double[] array3 = new double[3];
		for (int k = 0; k < 3; k++)
		{
			array3[k] = _0023_003Dzd4SeU9c_003D * array2[k];
		}
	}

	private static Vector3D _0023_003Dzm2Rhk77qnvjCrpTdxA_003D_003D(double _0023_003DzMqv9fS8_003D, double _0023_003DzHhTDgCE_003D, double _0023_003Dztw_0024P_0024LY_003D, double _0023_003DzSSKs3wk_003D, double _0023_003DzEvngaT8_003D, double _0023_003Dz_0024wXDnOY_003D, double _0023_003DzbfrNXYE_003D)
	{
		double[] array = new double[3]
		{
			_0023_003DzHhTDgCE_003D * _0023_003DzEvngaT8_003D - _0023_003Dztw_0024P_0024LY_003D * (_0023_003DzSSKs3wk_003D - _0023_003DzbfrNXYE_003D),
			_0023_003Dztw_0024P_0024LY_003D * _0023_003DzHhTDgCE_003D - _0023_003DzEvngaT8_003D * (_0023_003DzMqv9fS8_003D - _0023_003DzbfrNXYE_003D),
			(_0023_003DzMqv9fS8_003D - _0023_003DzbfrNXYE_003D) * (_0023_003DzSSKs3wk_003D - _0023_003DzbfrNXYE_003D) - _0023_003DzHhTDgCE_003D * _0023_003DzHhTDgCE_003D
		};
		Vector3D vector3D = new Vector3D(array[0], array[1], array[2]);
		if (vector3D.IsZero)
		{
			double num;
			double num2;
			double num3;
			if (_0023_003DzMqv9fS8_003D - _0023_003DzbfrNXYE_003D != 0.0 || _0023_003DzHhTDgCE_003D != 0.0 || _0023_003Dztw_0024P_0024LY_003D != 0.0)
			{
				num = _0023_003DzMqv9fS8_003D - _0023_003DzbfrNXYE_003D;
				num2 = _0023_003DzHhTDgCE_003D;
				num3 = _0023_003Dztw_0024P_0024LY_003D;
			}
			else if (_0023_003DzHhTDgCE_003D != 0.0 || _0023_003DzSSKs3wk_003D - _0023_003DzbfrNXYE_003D != 0.0 || _0023_003DzEvngaT8_003D != 0.0)
			{
				num = _0023_003DzHhTDgCE_003D;
				num2 = _0023_003DzSSKs3wk_003D - _0023_003DzbfrNXYE_003D;
				num3 = _0023_003DzEvngaT8_003D;
			}
			else if (_0023_003Dztw_0024P_0024LY_003D != 0.0 || _0023_003DzEvngaT8_003D != 0.0 || _0023_003Dz_0024wXDnOY_003D - _0023_003DzbfrNXYE_003D != 0.0)
			{
				num = _0023_003Dztw_0024P_0024LY_003D;
				num2 = _0023_003DzEvngaT8_003D;
				num3 = _0023_003Dz_0024wXDnOY_003D - _0023_003DzbfrNXYE_003D;
			}
			else
			{
				num = 1.0;
				num2 = 0.0;
				num3 = 0.0;
			}
			if (num == 0.0)
			{
				vector3D.X = 0.0;
			}
			else
			{
				vector3D.X = 1.0;
			}
			if (num2 == 0.0)
			{
				vector3D.Y = 0.0;
			}
			else
			{
				vector3D.Y = 1.0;
			}
			if (num3 == 0.0)
			{
				vector3D.Z = 0.0;
				if (_0023_003DzHhTDgCE_003D != 0.0)
				{
					vector3D.Y = (0.0 - num) / num2;
				}
			}
			else
			{
				vector3D.Z = (num2 - num) / num3;
			}
		}
		if (vector3D.LengthSquared <= 9.999999747378752E-06)
		{
			vector3D *= 100000.0;
		}
		vector3D.Normalize();
		return vector3D;
	}

	private static bool _0023_003DzC5t4EhYbWMr5UcvRuQ_003D_003D(double _0023_003DzMqv9fS8_003D, double _0023_003DzHhTDgCE_003D, double _0023_003Dztw_0024P_0024LY_003D, double _0023_003DzSSKs3wk_003D, double _0023_003DzEvngaT8_003D, double _0023_003Dz_0024wXDnOY_003D, double _0023_003Dz2T4sy2I_003D, double _0023_003DzO91j_0024fQ_003D, double _0023_003DzOC64tNw_003D, out Vector3D _0023_003DzJm8Md4c_003D, out Vector3D _0023_003DzkD_Pkaw_003D, out Vector3D _0023_003DzsjXs7dE_003D)
	{
		Vector3D a = new Vector3D(0.0, 1.0, 0.0);
		Vector3D a2 = new Vector3D(1.0, 0.0, 0.0);
		_0023_003DzJm8Md4c_003D = _0023_003Dzm2Rhk77qnvjCrpTdxA_003D_003D(_0023_003DzMqv9fS8_003D, _0023_003DzHhTDgCE_003D, _0023_003Dztw_0024P_0024LY_003D, _0023_003DzSSKs3wk_003D, _0023_003DzEvngaT8_003D, _0023_003Dz_0024wXDnOY_003D, _0023_003Dz2T4sy2I_003D);
		_0023_003DzkD_Pkaw_003D = _0023_003Dzm2Rhk77qnvjCrpTdxA_003D_003D(_0023_003DzMqv9fS8_003D, _0023_003DzHhTDgCE_003D, _0023_003Dztw_0024P_0024LY_003D, _0023_003DzSSKs3wk_003D, _0023_003DzEvngaT8_003D, _0023_003Dz_0024wXDnOY_003D, _0023_003DzO91j_0024fQ_003D);
		_0023_003DzsjXs7dE_003D = _0023_003Dzm2Rhk77qnvjCrpTdxA_003D_003D(_0023_003DzMqv9fS8_003D, _0023_003DzHhTDgCE_003D, _0023_003Dztw_0024P_0024LY_003D, _0023_003DzSSKs3wk_003D, _0023_003DzEvngaT8_003D, _0023_003Dz_0024wXDnOY_003D, _0023_003DzOC64tNw_003D);
		bool flag2;
		bool flag3;
		bool flag = (flag2 = (flag3 = false));
		if (_0023_003DzJm8Md4c_003D.IsZero)
		{
			flag = true;
		}
		if (_0023_003DzkD_Pkaw_003D.IsZero)
		{
			flag2 = true;
		}
		if (_0023_003DzsjXs7dE_003D.IsZero)
		{
			flag3 = true;
		}
		bool flag4 = Math.Abs(Vector3D.Dot(_0023_003DzJm8Md4c_003D, _0023_003DzkD_Pkaw_003D)) > 1E-06;
		bool flag5 = Math.Abs(Vector3D.Dot(_0023_003DzJm8Md4c_003D, _0023_003DzsjXs7dE_003D)) > 1E-06;
		bool flag6 = Math.Abs(Vector3D.Dot(_0023_003DzkD_Pkaw_003D, _0023_003DzsjXs7dE_003D)) > 1E-06;
		if ((flag && flag2 && flag3) || (flag4 && flag3) || (flag5 && flag2) || (flag6 && flag))
		{
			_0023_003DzJm8Md4c_003D = new Vector3D(1.0, 0.0, 0.0);
			_0023_003DzkD_Pkaw_003D = new Vector3D(0.0, 1.0, 0.0);
			_0023_003DzsjXs7dE_003D = new Vector3D(0.0, 0.0, 1.0);
			return false;
		}
		int num = -1;
		if (flag4 && flag5 && flag6)
		{
			double maximumCoordinate = _0023_003DzJm8Md4c_003D.MaximumCoordinate;
			double maximumCoordinate2 = _0023_003DzkD_Pkaw_003D.MaximumCoordinate;
			double maximumCoordinate3 = _0023_003DzsjXs7dE_003D.MaximumCoordinate;
			num = ((maximumCoordinate < maximumCoordinate2 && maximumCoordinate < maximumCoordinate3) ? 1 : ((maximumCoordinate2 < maximumCoordinate3) ? 2 : 3));
		}
		if ((flag && flag2) || num == 3)
		{
			Vector3D vector3D = Vector3D.Cross(a, _0023_003DzsjXs7dE_003D);
			if (vector3D.LengthSquared < 9.999999747378752E-06)
			{
				vector3D = Vector3D.Cross(a2, _0023_003DzsjXs7dE_003D);
			}
			vector3D.Normalize();
			_0023_003DzJm8Md4c_003D = vector3D;
			_0023_003DzkD_Pkaw_003D = Vector3D.Cross(_0023_003DzsjXs7dE_003D, _0023_003DzJm8Md4c_003D);
			return true;
		}
		if ((flag3 && flag) || num == 2)
		{
			Vector3D vector3D = Vector3D.Cross(a, _0023_003DzkD_Pkaw_003D);
			if (vector3D.LengthSquared < 9.999999747378752E-06)
			{
				vector3D = Vector3D.Cross(a2, _0023_003DzkD_Pkaw_003D);
			}
			vector3D.Normalize();
			_0023_003DzsjXs7dE_003D = vector3D;
			_0023_003DzJm8Md4c_003D = Vector3D.Cross(_0023_003DzkD_Pkaw_003D, _0023_003DzsjXs7dE_003D);
			return true;
		}
		if ((flag2 && flag3) || num == 1)
		{
			Vector3D vector3D = Vector3D.Cross(a, _0023_003DzJm8Md4c_003D);
			if (vector3D.LengthSquared < 9.999999747378752E-06)
			{
				vector3D = Vector3D.Cross(a2, _0023_003DzJm8Md4c_003D);
			}
			vector3D.Normalize();
			_0023_003DzkD_Pkaw_003D = vector3D;
			_0023_003DzsjXs7dE_003D = Vector3D.Cross(_0023_003DzJm8Md4c_003D, _0023_003DzkD_Pkaw_003D);
			return true;
		}
		if (flag || flag4)
		{
			if (!flag6)
			{
				_0023_003DzJm8Md4c_003D = Vector3D.Cross(_0023_003DzkD_Pkaw_003D, _0023_003DzsjXs7dE_003D);
			}
			else if (!flag5)
			{
				_0023_003DzkD_Pkaw_003D = Vector3D.Cross(_0023_003DzJm8Md4c_003D, _0023_003DzsjXs7dE_003D);
			}
			return true;
		}
		if (flag2 || flag6)
		{
			_0023_003DzsjXs7dE_003D = Vector3D.Cross(_0023_003DzJm8Md4c_003D, _0023_003DzkD_Pkaw_003D);
			return true;
		}
		if (flag3 || flag5)
		{
			_0023_003DzsjXs7dE_003D = Vector3D.Cross(_0023_003DzJm8Md4c_003D, _0023_003DzkD_Pkaw_003D);
			return true;
		}
		return true;
	}

	private static bool _0023_003DzKu37C_l6iiGZ(double _0023_003DzbfrNXYE_003D, double _0023_003DzhidJeNw_003D, double _0023_003Dz5rQzobg_003D, out double _0023_003DzNDQ_E88_003D, out double _0023_003Dz_eY3Y4c_003D, out double _0023_003Dz77g161c_003D)
	{
		double num = _0023_003DzhidJeNw_003D - _0023_003DzbfrNXYE_003D * _0023_003DzbfrNXYE_003D / 3.0;
		double num2 = _0023_003Dz5rQzobg_003D - _0023_003DzbfrNXYE_003D * _0023_003DzhidJeNw_003D / 3.0 + _0023_003DzbfrNXYE_003D * _0023_003DzbfrNXYE_003D * _0023_003DzbfrNXYE_003D * 2.0 / 27.0;
		double num3 = num2 * num2 / 4.0 + num * num * num / 27.0;
		if (num3 > 0.0 || double.IsNaN(num3))
		{
			_0023_003DzNDQ_E88_003D = (_0023_003Dz_eY3Y4c_003D = (_0023_003Dz77g161c_003D = 0.0));
			return false;
		}
		if (num3 == 0.0 && num2 == 0.0)
		{
			_0023_003DzNDQ_E88_003D = (0.0 - _0023_003DzbfrNXYE_003D) / 3.0;
			_0023_003Dz_eY3Y4c_003D = (0.0 - _0023_003DzbfrNXYE_003D) / 3.0;
			_0023_003Dz77g161c_003D = (0.0 - _0023_003DzbfrNXYE_003D) / 3.0;
			return true;
		}
		double num4 = Math.Sqrt(num2 * num2 / 4.0 - num3);
		double num5 = ((!(num4 < 0.0)) ? Math.Pow(num4, 0.3333333432674408) : (0.0 - Math.Pow(0.0 - num4, 0.3333333432674408)));
		double num6 = Math.Acos((0.0 - num2) / (2.0 * num4));
		double num7 = Math.Cos(num6 / 3.0);
		double num8 = Math.Sqrt(3.0) * Math.Sin(num6 / 3.0);
		_0023_003DzNDQ_E88_003D = 2.0 * num5 * num7 - _0023_003DzbfrNXYE_003D / 3.0;
		_0023_003Dz_eY3Y4c_003D = (0.0 - num5) * (num7 + num8) - _0023_003DzbfrNXYE_003D / 3.0;
		_0023_003Dz77g161c_003D = (0.0 - num5) * (num7 - num8) - _0023_003DzbfrNXYE_003D / 3.0;
		if (double.IsNaN(_0023_003DzNDQ_E88_003D) || double.IsNaN(_0023_003Dz_eY3Y4c_003D) || double.IsNaN(_0023_003Dz77g161c_003D) || double.IsInfinity(_0023_003DzNDQ_E88_003D) || double.IsInfinity(_0023_003Dz_eY3Y4c_003D) || double.IsInfinity(_0023_003Dz77g161c_003D))
		{
			_0023_003DzNDQ_E88_003D = (_0023_003Dz_eY3Y4c_003D = (_0023_003Dz77g161c_003D = 0.0));
			return false;
		}
		return true;
	}

	private void _0023_003DzVOioqJaeeZfJrKYK4EYjtZY_003D(double[,] _0023_003Dz_0024nkBdpc_003D, double[] _0023_003DzS7BO2YjPrT1sZf8keA_003D_003D, out Vector3D[] _0023_003Dz8L_SxADmiKmkEihTycZ_0024i1g_003D)
	{
		_0023_003Dz8L_SxADmiKmkEihTycZ_0024i1g_003D = new Vector3D[3];
		_0023_003DztkC8fAS67S_0024ai7P5LQ_003D_003D(_0023_003Dz_0024nkBdpc_003D, _0023_003DzS7BO2YjPrT1sZf8keA_003D_003D[0], out _0023_003Dz8L_SxADmiKmkEihTycZ_0024i1g_003D[0]);
		_0023_003DztkC8fAS67S_0024ai7P5LQ_003D_003D(_0023_003Dz_0024nkBdpc_003D, _0023_003DzS7BO2YjPrT1sZf8keA_003D_003D[1], out _0023_003Dz8L_SxADmiKmkEihTycZ_0024i1g_003D[1]);
		_0023_003DztkC8fAS67S_0024ai7P5LQ_003D_003D(_0023_003Dz_0024nkBdpc_003D, _0023_003DzS7BO2YjPrT1sZf8keA_003D_003D[2], out _0023_003Dz8L_SxADmiKmkEihTycZ_0024i1g_003D[2]);
	}

	private void _0023_003DztkC8fAS67S_0024ai7P5LQ_003D_003D(double[,] _0023_003Dz_0024nkBdpc_003D, double _0023_003DzvII3iqWK9LSkBWlrdw_003D_003D, out Vector3D _0023_003DzY5pSLwI_003D)
	{
		double num = 1.0;
		double num2 = (_0023_003Dz_0024nkBdpc_003D[0, 1] * _0023_003Dz_0024nkBdpc_003D[1, 0] - _0023_003Dz_0024nkBdpc_003D[0, 0] * _0023_003Dz_0024nkBdpc_003D[1, 1] + _0023_003DzvII3iqWK9LSkBWlrdw_003D_003D * (_0023_003Dz_0024nkBdpc_003D[1, 1] + _0023_003Dz_0024nkBdpc_003D[0, 0]) - _0023_003DzvII3iqWK9LSkBWlrdw_003D_003D * _0023_003DzvII3iqWK9LSkBWlrdw_003D_003D) / (_0023_003Dz_0024nkBdpc_003D[0, 2] * _0023_003DzvII3iqWK9LSkBWlrdw_003D_003D - _0023_003Dz_0024nkBdpc_003D[1, 1] * _0023_003Dz_0024nkBdpc_003D[0, 2] + _0023_003Dz_0024nkBdpc_003D[0, 1] * _0023_003Dz_0024nkBdpc_003D[1, 2]);
		double y = -1.0 * (_0023_003Dz_0024nkBdpc_003D[0, 1] * num2 + (_0023_003Dz_0024nkBdpc_003D[0, 0] - _0023_003DzvII3iqWK9LSkBWlrdw_003D_003D) * num) / _0023_003Dz_0024nkBdpc_003D[0, 1];
		_0023_003DzY5pSLwI_003D = new Vector3D(num, y, num2);
		_0023_003DzY5pSLwI_003D.Normalize();
	}

	public static bool DoOverlapOrTouch(OrientedBoundingBox first, OrientedBoundingBox second)
	{
		return DoOverlapOrTouchInternal(first, second, touch: true);
	}

	public static bool DoOverlap(OrientedBoundingBox first, OrientedBoundingBox second)
	{
		return DoOverlapOrTouchInternal(first, second, touch: false);
	}

	protected static bool DoOverlapOrTouchInternal(OrientedBoundingBox first, OrientedBoundingBox second, bool touch)
	{
		if (!OrientedBoundingRect.DoOverlapOrTouchInternal(first, second, touch))
		{
			return false;
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (((Vector3D)first._0023_003DzwFgeztXTDiyb()[i]).IsZero || ((Vector3D)second._0023_003DzwFgeztXTDiyb()[j]).IsZero)
				{
					continue;
				}
				Vector3D obj = first._0023_003DzwFgeztXTDiyb()[i].Clone() as Vector3D;
				Vector3D vector3D = second._0023_003DzwFgeztXTDiyb()[j].Clone() as Vector3D;
				obj.Normalize();
				vector3D.Normalize();
				Vector3D vector3D2 = Vector3D.Cross(obj, vector3D);
				vector3D2.Normalize();
				if (vector3D2.IsZero)
				{
					continue;
				}
				OrientedBoundingRect.projectVerticesOnAxis(first.GetVertices(), vector3D2, out var minSecond, out var maxSecond);
				OrientedBoundingRect.projectVerticesOnAxis(second.GetVertices(), vector3D2, out var minSecond2, out var maxSecond2);
				if (touch)
				{
					if (minSecond2 > maxSecond + OrientedBoundingRect.TOLERANCE || minSecond > maxSecond2 + OrientedBoundingRect.TOLERANCE)
					{
						return false;
					}
				}
				else if (minSecond2 > maxSecond - OrientedBoundingRect.TOLERANCE || minSecond > maxSecond2 - OrientedBoundingRect.TOLERANCE)
				{
					return false;
				}
			}
		}
		return true;
	}
}
