using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class OrientedBoundingRect : ICloneable
{
	protected Transformation _transformation = new Identity();

	protected Transformation _accumulatedTrans;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003DzkoBWLrQ_003D;

	protected Point2D _origin;

	protected Vector2D[] _axis;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Size2D _0023_003DzPcQdeHOMvY_0024e = new Size2D(0.0, 0.0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Size2D _0023_003DzGZ0TqShlfr9O;

	protected Vector2D _componentX;

	protected Vector2D _componentY;

	protected bool needToUpdate;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DziQOhVy0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D;

	protected static double TOLERANCE = Utility._0023_003DzheSR8QM7q9ya;

	public Transformation Transformation => _transformation;

	public Transformation AccumulatedTransformation
	{
		get
		{
			return _accumulatedTrans;
		}
		set
		{
			_accumulatedTrans = value;
			needToUpdate = true;
			_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = true;
		}
	}

	public virtual Point2D Size
	{
		get
		{
			if (_0023_003DzGZ0TqShlfr9O == null || _0023_003DziQOhVy0_003D)
			{
				Transformation fullTransformation = GetFullTransformation();
				_0023_003DzGZ0TqShlfr9O = new Size2D(_0023_003DzPcQdeHOMvY_0024e.X * fullTransformation.ScaleFactorX, _0023_003DzPcQdeHOMvY_0024e.Y * fullTransformation.ScaleFactorY);
			}
			return _0023_003DzGZ0TqShlfr9O;
		}
	}

	public OrientedBoundingRect(Point2D origin, double width, double height)
	{
		_0023_003DzPcQdeHOMvY_0024e = new Size2D(width, height);
		_transformation = new Translation(origin.X, origin.Y);
		needToUpdate = true;
	}

	public OrientedBoundingRect(Point2D origin, Vector2D axisX, Vector2D axisY, double width, double height)
		: this(origin, width, height)
	{
		Align3D transformation = new Align3D(Plane.XY, new Plane(new Point3D(origin.X, origin.Y), new Vector3D(axisX.X, axisX.Y), new Vector3D(axisY.X, axisY.Y)));
		_transformation = transformation;
		needToUpdate = true;
	}

	public OrientedBoundingRect(IList<Point2D> pointCloud, Vector2D axisX, Vector2D axisY)
	{
		Plane plane = new Plane(Point3D.Origin, new Vector3D(axisX.X, axisX.Y), new Vector3D(axisY.X, axisY.Y));
		Utility.BoundingRectOnPlane(pointCloud, plane, out var min, out var max);
		plane.Origin.TransformBy(new Translation(min.X, min.Y));
		Transformation _0023_003DzPzO_0024GUk_003D = new Align3D(Plane.XY, plane);
		_0023_003DznTv6jJyUD3Pu(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzPcQdeHOMvY_0024e = new Size2D(min, max);
		needToUpdate = true;
		_0023_003DziQOhVy0_003D = false;
		_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
	}

	public OrientedBoundingRect(IList<Point2D> pointCloud)
	{
		LinearPath linearPath = Utility.ConvexHull2D(pointCloud);
		if (linearPath.IsOrientedClockwise(Plane.XY))
		{
			linearPath.Reverse();
		}
		_0023_003DzTV5TRVQHS87xy_4n5lbdRVA_003D(linearPath, out var _0023_003DzVlAX6WI_003D, out var _0023_003DzmScrddQ_003D, out var _0023_003DzF7v9r2A_003D, out var _0023_003Dz8dK2uhU_003D);
		Plane plane = new Plane(Point3D.Origin, new Vector3D(_0023_003DzVlAX6WI_003D.X, _0023_003DzVlAX6WI_003D.Y), new Vector3D(_0023_003DzmScrddQ_003D.X, _0023_003DzmScrddQ_003D.Y));
		Point3D origin = plane.PointAt(_0023_003DzF7v9r2A_003D);
		plane.Origin = origin;
		Transformation _0023_003DzPzO_0024GUk_003D = new Align3D(Plane.XY, plane);
		_0023_003DznTv6jJyUD3Pu(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzPcQdeHOMvY_0024e = new Size2D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		needToUpdate = true;
		_0023_003DziQOhVy0_003D = false;
		_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
	}

	protected OrientedBoundingRect(OrientedBoundingRect another)
	{
		_0023_003DzPcQdeHOMvY_0024e = new Size2D(another._0023_003DzPcQdeHOMvY_0024e.X, another._0023_003DzPcQdeHOMvY_0024e.Y);
		_transformation = another._transformation;
		_accumulatedTrans = another._accumulatedTrans;
		needToUpdate = true;
		_0023_003DziQOhVy0_003D = another._0023_003DziQOhVy0_003D;
		_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = another._0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D;
	}

	internal void _0023_003DznTv6jJyUD3Pu(Transformation _0023_003DzPzO_0024GUk_003D)
	{
		_transformation = _0023_003DzPzO_0024GUk_003D;
		needToUpdate = true;
		_0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = true;
	}

	public Transformation GetFullTransformation()
	{
		if (_0023_003DzkoBWLrQ_003D == null || needToUpdate || _0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D || _0023_003DziQOhVy0_003D)
		{
			_0023_003DzkoBWLrQ_003D = (AccumulatedTransformation ?? new Identity()) * Transformation;
		}
		return _0023_003DzkoBWLrQ_003D;
	}

	internal void _0023_003DzK3EEX2U_003D(Transformation _0023_003Dz6Os7KWo_003D)
	{
		_0023_003DznTv6jJyUD3Pu(_0023_003Dz6Os7KWo_003D * Transformation);
	}

	public void AccumulateTransformation(Transformation newTransformation)
	{
		if (AccumulatedTransformation == null)
		{
			AccumulatedTransformation = newTransformation;
		}
		else
		{
			AccumulatedTransformation = newTransformation * AccumulatedTransformation;
		}
	}

	internal virtual Point2D _0023_003DzU_D1Mh3KgbPX()
	{
		if (needToUpdate)
		{
			UpdateOrigin();
		}
		return _origin;
	}

	internal virtual void _0023_003DzXzFvxyg8v2WM(Point2D _0023_003DzPzO_0024GUk_003D)
	{
		_origin = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual Point2D GetOrigin()
	{
		if (needToUpdate)
		{
			UpdateOrigin();
		}
		return new Point2D(_0023_003DzU_D1Mh3KgbPX().X, _0023_003DzU_D1Mh3KgbPX().Y);
	}

	protected virtual void UpdateOrigin()
	{
		_origin = Point3D.Origin;
		_origin.TransformBy(GetFullTransformation());
	}

	internal virtual Vector2D[] _0023_003DzwFgeztXTDiyb()
	{
		if (needToUpdate)
		{
			UpdateAxis();
		}
		return _axis;
	}

	internal virtual void _0023_003DzBbR6DxwT59si(Vector2D[] _0023_003DzPzO_0024GUk_003D)
	{
		_axis = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual Vector2D[] GetAxis()
	{
		if (needToUpdate)
		{
			UpdateAxis();
		}
		return new Vector2D[2]
		{
			(Vector2D)_0023_003DzwFgeztXTDiyb()[0].Clone(),
			(Vector2D)_0023_003DzwFgeztXTDiyb()[1].Clone()
		};
	}

	protected virtual void UpdateAxis()
	{
		_axis = new Vector2D[2]
		{
			Vector2D.AxisX,
			Vector2D.AxisY
		};
		Transformation fullTransformation = GetFullTransformation();
		_axis[0].TransformBy(fullTransformation);
		_axis[1].TransformBy(fullTransformation);
		_axis[0].Normalize();
		_axis[1].Normalize();
	}

	internal virtual Vector2D _0023_003Dzh4_kjFUbrJxh()
	{
		if (needToUpdate || _componentX == null)
		{
			_componentX = _0023_003DzwFgeztXTDiyb()[0] * Size.X;
		}
		return _componentX;
	}

	internal virtual Vector2D _0023_003DzrI8_Aef5mDa4()
	{
		if (needToUpdate || _componentY == null)
		{
			_componentY = _0023_003DzwFgeztXTDiyb()[1] * Size.Y;
		}
		return _componentY;
	}

	public virtual Point2D[] GetVertices()
	{
		if (needToUpdate)
		{
			UpdateData();
		}
		return new Point2D[4]
		{
			new Point2D(_0023_003DzU_D1Mh3KgbPX().X, _0023_003DzU_D1Mh3KgbPX().Y),
			_0023_003DzU_D1Mh3KgbPX() + _0023_003Dzh4_kjFUbrJxh(),
			_0023_003DzU_D1Mh3KgbPX() + _0023_003Dzh4_kjFUbrJxh() + _0023_003DzrI8_Aef5mDa4(),
			_0023_003DzU_D1Mh3KgbPX() + _0023_003DzrI8_Aef5mDa4()
		};
	}

	protected virtual void UpdateData()
	{
		if (needToUpdate)
		{
			UpdateAxis();
			UpdateOrigin();
			_componentX = null;
			_componentY = null;
			_0023_003DzGZ0TqShlfr9O = null;
			needToUpdate = false;
		}
	}

	public virtual object Clone()
	{
		return new OrientedBoundingRect(this);
	}

	internal void _0023_003DzTV5TRVQHS87xy_4n5lbdRVA_003D(LinearPath _0023_003DzU3hosSAzkxO7, out Vector2D _0023_003DzVlAX6WI_003D, out Vector2D _0023_003DzmScrddQ_003D, out Point2D _0023_003DzF7v9r2A_003D, out Point2D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzVlAX6WI_003D = Vector2D.AxisX;
		_0023_003DzmScrddQ_003D = Vector2D.AxisY;
		_0023_003DzF7v9r2A_003D = Point2D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point2D.MinValue;
		double num = (_0023_003Dz8dK2uhU_003D.X - _0023_003DzF7v9r2A_003D.X) * (_0023_003Dz8dK2uhU_003D.Y - _0023_003DzF7v9r2A_003D.Y);
		int num2 = 0;
		while (num2 < _0023_003DzU3hosSAzkxO7.Vertices.Length - 1)
		{
			Vector2D vector2D = new Vector2D(_0023_003DzU3hosSAzkxO7.Vertices[num2], _0023_003DzU3hosSAzkxO7.Vertices[num2 + 1]);
			vector2D.Normalize();
			Vector2D vector2D2 = Vector3D.Cross(new Vector3D(vector2D.X, vector2D.Y), Vector3D.AxisZ * -1.0);
			vector2D2.Normalize();
			Plane plane = new Plane(Point3D.Origin, new Vector3D(vector2D.X, vector2D.Y), new Vector3D(vector2D2.X, vector2D2.Y));
			Utility.BoundingRectOnPlane(_0023_003DzU3hosSAzkxO7.Vertices, plane, out var min, out var max);
			double num3 = (max.X - min.X) * (max.Y - min.Y);
			if (num3 < num)
			{
				num = num3;
				_0023_003DzVlAX6WI_003D = vector2D;
				_0023_003DzmScrddQ_003D = vector2D2;
				_0023_003DzF7v9r2A_003D = min;
				_0023_003Dz8dK2uhU_003D = max;
			}
			int num4 = num2 + 1;
			for (int i = num4 + 1; i < _0023_003DzU3hosSAzkxO7.Vertices.Length; i++)
			{
				Point3D p = _0023_003DzU3hosSAzkxO7.Vertices[i];
				if (plane.Project(p).X == _0023_003Dz8dK2uhU_003D.X)
				{
					num4 = i - 1;
					break;
				}
			}
			num2 = num4;
		}
	}

	public static bool DoOverlapOrTouch(OrientedBoundingRect first, OrientedBoundingRect second)
	{
		return DoOverlapOrTouchInternal(first, second, touch: true);
	}

	public static bool DoOverlap(OrientedBoundingRect first, OrientedBoundingRect second)
	{
		return DoOverlapOrTouchInternal(first, second, touch: false);
	}

	protected static bool DoOverlapOrTouchInternal(OrientedBoundingRect first, OrientedBoundingRect second, bool touch)
	{
		first.UpdateData();
		second.UpdateData();
		Vector2D[] array = new Vector2D[first._0023_003DzwFgeztXTDiyb().Length];
		Vector2D[] array2 = new Vector2D[second._0023_003DzwFgeztXTDiyb().Length];
		for (int i = 0; i < array.Length; i++)
		{
			if ((first._0023_003DzwFgeztXTDiyb()[i] is Vector3D && ((Vector3D)first._0023_003DzwFgeztXTDiyb()[i]).IsZero) || (first._0023_003DzwFgeztXTDiyb()[i].GetType() == typeof(Vector2D) && first._0023_003DzwFgeztXTDiyb()[i].IsZero))
			{
				continue;
			}
			array[i] = (Vector2D)first._0023_003DzwFgeztXTDiyb()[i].Clone();
			double[] array3 = first.Size.ToArray();
			double num;
			double num2;
			if (array[i] is Vector3D)
			{
				((Vector3D)array[i]).Normalize();
				num = Vector3D.Dot(array[i] as Vector3D, (Point3D)first._0023_003DzU_D1Mh3KgbPX());
				num2 = num + array3[i] * ((Vector3D)first._0023_003DzwFgeztXTDiyb()[i]).Length;
			}
			else
			{
				array[i].Normalize();
				num = Vector2D.Dot(array[i], first._0023_003DzU_D1Mh3KgbPX());
				num2 = num + array3[i] * first._0023_003DzwFgeztXTDiyb()[i].Length;
			}
			projectVerticesOnAxis(second.GetVertices(), array[i], out var minSecond, out var maxSecond);
			if (touch)
			{
				if (minSecond > num2 + TOLERANCE || num > maxSecond + TOLERANCE)
				{
					return false;
				}
			}
			else if (minSecond > num2 - TOLERANCE || num > maxSecond - TOLERANCE)
			{
				return false;
			}
		}
		for (int j = 0; j < array2.Length; j++)
		{
			if ((second._0023_003DzwFgeztXTDiyb()[j] is Vector3D && ((Vector3D)second._0023_003DzwFgeztXTDiyb()[j]).IsZero) || (second._0023_003DzwFgeztXTDiyb()[j].GetType() == typeof(Vector2D) && second._0023_003DzwFgeztXTDiyb()[j].IsZero))
			{
				continue;
			}
			array2[j] = (Vector2D)second._0023_003DzwFgeztXTDiyb()[j].Clone();
			double[] array4 = second.Size.ToArray();
			double num3;
			double num4;
			if (array2[j] is Vector3D)
			{
				((Vector3D)array2[j]).Normalize();
				num3 = Vector3D.Dot((Vector3D)array2[j], (Point3D)second._0023_003DzU_D1Mh3KgbPX());
				num4 = num3 + array4[j] * ((Vector3D)second._0023_003DzwFgeztXTDiyb()[j]).Length;
			}
			else
			{
				array2[j].Normalize();
				num3 = Vector2D.Dot(array2[j], second._0023_003DzU_D1Mh3KgbPX());
				num4 = num3 + array4[j] * second._0023_003DzwFgeztXTDiyb()[j].Length;
			}
			projectVerticesOnAxis(first.GetVertices(), array2[j], out var minSecond2, out var maxSecond2);
			if (touch)
			{
				if (num3 > maxSecond2 + TOLERANCE || minSecond2 > num4 + TOLERANCE)
				{
					return false;
				}
			}
			else if (num3 > maxSecond2 - TOLERANCE || minSecond2 > num4 - TOLERANCE)
			{
				return false;
			}
		}
		return true;
	}

	protected static void projectVerticesOnAxis(Point2D[] vertices, Vector2D axis, out double minSecond, out double maxSecond)
	{
		maxSecond = (minSecond = 0.0);
		for (int i = 0; i < vertices.Length; i++)
		{
			double num = ((!(axis is Vector3D)) ? Vector2D.Dot(axis, vertices[i]) : Vector3D.Dot((Vector3D)axis, (Point3D)vertices[i]));
			if (i == 0)
			{
				minSecond = (maxSecond = num);
				continue;
			}
			if (minSecond > num)
			{
				minSecond = num;
			}
			if (maxSecond < num)
			{
				maxSecond = num;
			}
		}
	}
}
