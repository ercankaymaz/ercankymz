using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry.ConstraintSolver;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(PlaneConverter))]
public class Plane : ICloneable, IMateable
{
	private Point3D origin;

	private Vector3D xAxis;

	private Vector3D yAxis;

	private Vector3D zAxis;

	private PlaneEquation equation = new PlaneEquation();

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public static Plane XY => new Plane();

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public static Plane YX => new Plane(Point3D.Origin, Vector3D.AxisY, Vector3D.AxisX);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public static Plane YZ => new Plane(Point3D.Origin, Vector3D.AxisY, Vector3D.AxisZ);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public static Plane ZY => new Plane(Point3D.Origin, Vector3D.AxisZ, Vector3D.AxisY);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public static Plane ZX => new Plane(Point3D.Origin, Vector3D.AxisZ, Vector3D.AxisX);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public static Plane XZ => new Plane(Point3D.Origin, Vector3D.AxisX, Vector3D.AxisZ);

	[Description("The plane origin")]
	public Point3D Origin
	{
		get
		{
			return origin;
		}
		set
		{
			origin = value;
			UpdateEquation();
		}
	}

	[Description("The plane X axis")]
	public Vector3D AxisX
	{
		get
		{
			return xAxis;
		}
		set
		{
			xAxis = value;
			_0023_003Dz_0024TgnSgZ3mKb6((Point3D)Origin.Clone(), (Vector3D)xAxis.Clone(), (Vector3D)yAxis.Clone());
		}
	}

	[Description("The plane Y axis")]
	public Vector3D AxisY
	{
		get
		{
			return yAxis;
		}
		set
		{
			yAxis = value;
			_0023_003Dz_0024TgnSgZ3mKb6((Point3D)Origin.Clone(), (Vector3D)xAxis.Clone(), (Vector3D)yAxis.Clone());
		}
	}

	[Description("The plane Z axis")]
	public Vector3D AxisZ
	{
		get
		{
			return zAxis;
		}
		set
		{
			zAxis = value;
			_0023_003Dz9KxVQ_H3p_PX((Point3D)Origin.Clone(), (Vector3D)zAxis.Clone());
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PlaneEquation Equation => equation;

	public Plane()
	{
		origin = Point3D.Origin;
		xAxis = Vector3D.AxisX;
		yAxis = Vector3D.AxisY;
		zAxis = Vector3D.AxisZ;
		equation.X = (equation.Y = (equation.D = 0.0));
		equation.Z = 1.0;
	}

	public Plane(Point3D P, Vector3D N)
	{
		if (!_0023_003Dz9KxVQ_H3p_PX((Point3D)P.Clone(), (Vector3D)N.Clone()))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659357));
		}
	}

	public Plane(Vector3D N)
	{
		if (!_0023_003Dz9KxVQ_H3p_PX(Point3D.Origin, (Vector3D)N.Clone()))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659357));
		}
	}

	public Plane(Point3D P, Vector3D X, Vector3D Y)
	{
		if (!_0023_003Dz_0024TgnSgZ3mKb6((Point3D)P.Clone(), (Vector3D)X.Clone(), Y))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659357));
		}
	}

	protected Plane(Plane another)
	{
		_0023_003Dz_0024TgnSgZ3mKb6((Point3D)another.origin.Clone(), (Vector3D)another.xAxis.Clone(), another.yAxis);
	}

	public Plane(Point3D P, Point3D Q, Point3D R)
	{
		CreateFromPoints(P, Q, R);
	}

	public Plane(double[] e)
	{
		if (!_0023_003DzTLekQra2tkRnCeCMFQ_003D_003D(e))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659357));
		}
	}

	protected Plane(SerializationInfo info, StreamingContext context)
	{
		origin = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951300), typeof(Point3D));
		xAxis = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659581), typeof(Vector3D));
		yAxis = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659564), typeof(Vector3D));
		zAxis = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659543), typeof(Vector3D));
		UpdateEquation();
	}

	public virtual object Clone()
	{
		return new Plane(this);
	}

	internal bool _0023_003Dz9KxVQ_H3p_PX(Point3D _0023_003Dzl3DhHgI_003D, Vector3D _0023_003DzpGjKR04_003D)
	{
		origin = _0023_003Dzl3DhHgI_003D;
		zAxis = _0023_003DzpGjKR04_003D;
		bool result = zAxis.Normalize();
		xAxis = Vector3D.AxisX;
		xAxis.PerpendicularTo(zAxis);
		xAxis.Normalize();
		yAxis = Vector3D.Cross(zAxis, xAxis);
		yAxis.Normalize();
		_0023_003Dz_0024TgnSgZ3mKb6(origin, xAxis, yAxis);
		return result;
	}

	private bool _0023_003Dz_0024TgnSgZ3mKb6(Point3D _0023_003Dzl3DhHgI_003D, Vector3D _0023_003Dzyk2fsPo_003D, Vector3D _0023_003DzvXOLtKg_003D)
	{
		origin = _0023_003Dzl3DhHgI_003D;
		xAxis = _0023_003Dzyk2fsPo_003D;
		xAxis.Normalize();
		yAxis = _0023_003DzvXOLtKg_003D - Vector3D.Dot(_0023_003DzvXOLtKg_003D, xAxis) * xAxis;
		yAxis.Normalize();
		zAxis = Vector3D.Cross(xAxis, yAxis);
		bool num = zAxis.Normalize();
		if (num)
		{
			UpdateEquation();
		}
		return num;
	}

	public bool CreateFromPoints(Point3D P, Point3D Q, Point3D R)
	{
		origin = P;
		zAxis = new Vector3D(P, Q, R);
		bool result = !zAxis.IsZero;
		xAxis = Vector3D.Subtract(Q, P);
		xAxis.Normalize();
		yAxis = Vector3D.Cross(zAxis, xAxis);
		yAxis.Normalize();
		if (!equation.Create(origin, zAxis))
		{
			result = false;
		}
		return result;
	}

	private bool _0023_003DzTLekQra2tkRnCeCMFQ_003D_003D(double[] _0023_003DzbfrNXYE_003D)
	{
		bool result = false;
		equation = new PlaneEquation();
		equation.X = _0023_003DzbfrNXYE_003D[0];
		equation.Y = _0023_003DzbfrNXYE_003D[1];
		equation.Z = _0023_003DzbfrNXYE_003D[2];
		equation.D = _0023_003DzbfrNXYE_003D[3];
		zAxis = new Vector3D(_0023_003DzbfrNXYE_003D[0], _0023_003DzbfrNXYE_003D[1], _0023_003DzbfrNXYE_003D[2]);
		double length = zAxis.Length;
		zAxis.Normalize();
		if (length > 0.0)
		{
			length = 1.0 / length;
			origin = (0.0 - length) * equation.D * zAxis.AsPoint;
			result = true;
		}
		xAxis = new Vector3D();
		xAxis.PerpendicularTo(zAxis);
		xAxis.Normalize();
		yAxis = Vector3D.Cross(zAxis, xAxis);
		yAxis.Normalize();
		return result;
	}

	public void UpdateEquation()
	{
		equation = new PlaneEquation(origin, zAxis);
	}

	public Point3D Reflect(Point3D point)
	{
		double num = DistanceTo(point);
		Point2D pt = Project(point);
		return new Point3D((PointAt(pt) - num * zAxis).ToArray());
	}

	public Vector3D Reflect(Vector3D vector)
	{
		Plane plane = new Plane(zAxis);
		Point3D point = new Point3D(vector.ToArray());
		return new Vector3D(plane.Reflect(point).ToArray());
	}

	public bool IsValid(StringBuilder log = null)
	{
		if (!equation.IsValid())
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659526));
			return false;
		}
		double value = equation.ValueAt(origin);
		if (Math.Abs(value) > 1E-12)
		{
			double num = Math.Abs(origin.MaximumCoordinate) + Math.Abs(equation.D);
			if (!(num > 1000.0) || !origin.IsValid())
			{
				return false;
			}
			num *= 2.220446049250313E-15;
			if (Math.Abs(value) > num)
			{
				return false;
			}
		}
		if (!_0023_003DzAoYbzyaWopJZ(xAxis, yAxis, zAxis))
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659518));
			return false;
		}
		Vector3D vector3D = new Vector3D(equation.X, equation.Y, equation.Z);
		vector3D.Normalize();
		value = vector3D * zAxis;
		if (Math.Abs(value - 1.0) > 1.490116119385E-08)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982510));
			return false;
		}
		return true;
	}

	private bool _0023_003Dz2TkMDR4ay0NjSFh_Nc9qDik_003D(Vector3D _0023_003Dzyk2fsPo_003D, Vector3D _0023_003DzvXOLtKg_003D, Vector3D _0023_003Dz8wjMonY_003D)
	{
		if (!_0023_003Dzyk2fsPo_003D.IsValid() || !_0023_003DzvXOLtKg_003D.IsValid() || !_0023_003Dz8wjMonY_003D.IsValid())
		{
			return false;
		}
		double length = _0023_003Dzyk2fsPo_003D.Length;
		double length2 = _0023_003DzvXOLtKg_003D.Length;
		double length3 = _0023_003Dz8wjMonY_003D.Length;
		if (length <= 1.490116119385E-08)
		{
			return false;
		}
		if (length2 <= 1.490116119385E-08)
		{
			return false;
		}
		if (length3 <= 1.490116119385E-08)
		{
			return false;
		}
		length = 1.0 / length;
		length2 = 1.0 / length2;
		length3 = 1.0 / length3;
		double value = (_0023_003Dzyk2fsPo_003D.X * _0023_003DzvXOLtKg_003D.X + _0023_003Dzyk2fsPo_003D.Y * _0023_003DzvXOLtKg_003D.Y + _0023_003Dzyk2fsPo_003D.Z * _0023_003DzvXOLtKg_003D.Z) * length * length2;
		double value2 = (_0023_003DzvXOLtKg_003D.X * _0023_003Dz8wjMonY_003D.X + _0023_003DzvXOLtKg_003D.Y * _0023_003Dz8wjMonY_003D.Y + _0023_003DzvXOLtKg_003D.Z * _0023_003Dz8wjMonY_003D.Z) * length2 * length3;
		double value3 = (_0023_003Dz8wjMonY_003D.X * _0023_003Dzyk2fsPo_003D.X + _0023_003Dz8wjMonY_003D.Y * _0023_003Dzyk2fsPo_003D.Y + _0023_003Dz8wjMonY_003D.Z * _0023_003Dzyk2fsPo_003D.Z) * length3 * length;
		if (Math.Abs(value) > 1.490116119385E-08 || Math.Abs(value2) > 1.490116119385E-08 || Math.Abs(value3) > 1.490116119385E-08)
		{
			double num = 1.52587890625E-05;
			if (Math.Abs(value) >= num || Math.Abs(value2) >= num || Math.Abs(value3) >= num)
			{
				return false;
			}
			Vector3D vector3D = length * length2 * Vector3D.Cross(_0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D);
			num = Math.Abs((vector3D.X * _0023_003Dz8wjMonY_003D.X + vector3D.Y * _0023_003Dz8wjMonY_003D.Y + vector3D.Z * _0023_003Dz8wjMonY_003D.Z) * length3);
			if (Math.Abs(num - 1.0) > 1.490116119385E-08)
			{
				return false;
			}
			vector3D = length2 * length3 * Vector3D.Cross(_0023_003DzvXOLtKg_003D, _0023_003Dz8wjMonY_003D);
			num = Math.Abs((vector3D.X * _0023_003Dzyk2fsPo_003D.X + vector3D.Y * _0023_003Dzyk2fsPo_003D.Y + vector3D.Z * _0023_003Dzyk2fsPo_003D.Z) * length);
			if (Math.Abs(num - 1.0) > 1.490116119385E-08)
			{
				return false;
			}
			vector3D = length3 * length * Vector3D.Cross(_0023_003Dz8wjMonY_003D, _0023_003Dzyk2fsPo_003D);
			num = Math.Abs((vector3D.X * _0023_003DzvXOLtKg_003D.X + vector3D.Y * _0023_003DzvXOLtKg_003D.Y + vector3D.Z * _0023_003DzvXOLtKg_003D.Z) * length2);
			if (Math.Abs(num - 1.0) > 1.490116119385E-08)
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003DzmSUgLaWrIp8yXTQM0nsISQk_003D(Vector3D _0023_003Dzyk2fsPo_003D, Vector3D _0023_003DzvXOLtKg_003D, Vector3D _0023_003Dz8wjMonY_003D)
	{
		if (!_0023_003Dz2TkMDR4ay0NjSFh_Nc9qDik_003D(_0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D, _0023_003Dz8wjMonY_003D))
		{
			return false;
		}
		if (Math.Abs(_0023_003Dzyk2fsPo_003D.Length - 1.0) > 1.490116119385E-08)
		{
			return false;
		}
		if (Math.Abs(_0023_003DzvXOLtKg_003D.Length - 1.0) > 1.490116119385E-08)
		{
			return false;
		}
		if (Math.Abs(_0023_003Dz8wjMonY_003D.Length - 1.0) > 1.490116119385E-08)
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzAoYbzyaWopJZ(Vector3D _0023_003Dzyk2fsPo_003D, Vector3D _0023_003DzvXOLtKg_003D, Vector3D _0023_003Dz8wjMonY_003D)
	{
		if (!_0023_003DzmSUgLaWrIp8yXTQM0nsISQk_003D(_0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D, _0023_003Dz8wjMonY_003D))
		{
			return false;
		}
		if (Vector3D.Cross(_0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D) * _0023_003Dz8wjMonY_003D <= 1.490116119385E-08)
		{
			return false;
		}
		return true;
	}

	public Point3D PointAt(Point2D pt)
	{
		return PointAt(pt.X, pt.Y);
	}

	public Point3D PointAt(double s, double t)
	{
		return origin + s * xAxis + t * yAxis;
	}

	public Point3D PointAt(double s, double t, double c)
	{
		return origin + s * xAxis + t * yAxis + c * zAxis;
	}

	public static planeIntersectionType Intersection(Plane pln1, Plane pln2, out Segment3D intSeg)
	{
		Point3D pt;
		Vector3D u;
		planeIntersectionType result = Intersection(pln1, pln2, 1E-11, out pt, out u);
		intSeg = new Segment3D(pt, pt + u);
		return result;
	}

	public static planeIntersectionType Intersection(Plane pln1, Plane pln2, double tol, out Segment3D intSeg)
	{
		Point3D pt;
		Vector3D u;
		planeIntersectionType result = Intersection(pln1, pln2, tol, out pt, out u);
		intSeg = new Segment3D(pt, pt + u);
		return result;
	}

	public static planeIntersectionType Intersection(Plane pln1, Plane pln2, double tol, out Point3D pt, out Vector3D u)
	{
		pt = new Point3D();
		u = Vector3D.Cross(pln1.AxisZ, pln2.AxisZ);
		double num = ((u.X >= 0.0) ? u.X : (0.0 - u.X));
		double num2 = ((u.Y >= 0.0) ? u.Y : (0.0 - u.Y));
		double num3 = ((u.Z >= 0.0) ? u.Z : (0.0 - u.Z));
		if (num + num2 + num3 < 1E-08)
		{
			Vector3D vector3D = Vector3D.Subtract(pln2.Origin, pln1.Origin);
			if (Utility.Compare(tol, pln1.AxisZ * vector3D, 0.0) == 0)
			{
				return planeIntersectionType.Coincide;
			}
			return planeIntersectionType.Disjoint;
		}
		int num4 = ((num > num2) ? ((num > num3) ? 1 : 3) : ((!(num2 > num3)) ? 3 : 2));
		double num5 = 0.0 - Vector3D.Dot(pln1.AxisZ, pln1.Origin);
		double num6 = 0.0 - Vector3D.Dot(pln2.AxisZ, pln2.Origin);
		switch (num4)
		{
		case 1:
			pt.X = 0.0;
			pt.Y = (num6 * pln1.AxisZ.Z - num5 * pln2.AxisZ.Z) / u.X;
			pt.Z = (num5 * pln2.AxisZ.Y - num6 * pln1.AxisZ.Y) / u.X;
			break;
		case 2:
			pt.X = (num5 * pln2.AxisZ.Z - num6 * pln1.AxisZ.Z) / u.Y;
			pt.Y = 0.0;
			pt.Z = (num6 * pln1.AxisZ.X - num5 * pln2.AxisZ.X) / u.Y;
			break;
		case 3:
			pt.X = (num6 * pln1.AxisZ.Y - num5 * pln2.AxisZ.Y) / u.Z;
			pt.Y = (num5 * pln2.AxisZ.X - num6 * pln1.AxisZ.X) / u.Z;
			pt.Z = 0.0;
			break;
		}
		return planeIntersectionType.UniqueLine;
	}

	public void TransformBy(Transformation xform)
	{
		Point3D point3D = xform * origin;
		Vector3D _0023_003Dzyk2fsPo_003D = Vector3D.Subtract(xform * (origin + xAxis), point3D);
		Vector3D _0023_003DzvXOLtKg_003D = Vector3D.Subtract(xform * (origin + yAxis), point3D);
		_0023_003Dz_0024TgnSgZ3mKb6(point3D, _0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D);
	}

	public Plane Offset(double amount)
	{
		Plane plane = new Plane(this);
		plane.Origin += zAxis * amount;
		return plane;
	}

	internal void _0023_003Dz6dFS2Jo_003D(double _0023_003Dz5ERWzMqlsNBW, double _0023_003DzDvBPIgt1VY_M, Vector3D _0023_003DzxuJqjrs_003D)
	{
		if (Vector3D.AreCoincident(_0023_003DzxuJqjrs_003D, zAxis))
		{
			Vector3D vector3D = _0023_003DzDvBPIgt1VY_M * xAxis + _0023_003Dz5ERWzMqlsNBW * yAxis;
			Vector3D vector3D2 = _0023_003DzDvBPIgt1VY_M * yAxis - _0023_003Dz5ERWzMqlsNBW * xAxis;
			xAxis = vector3D;
			yAxis = vector3D2;
		}
		else
		{
			Point3D point3D = origin;
			_0023_003Dz6dFS2Jo_003D(_0023_003Dz5ERWzMqlsNBW, _0023_003DzDvBPIgt1VY_M, _0023_003DzxuJqjrs_003D, origin);
			origin = point3D;
		}
	}

	internal void _0023_003Dz6dFS2Jo_003D(double _0023_003Dz5ERWzMqlsNBW, double _0023_003DzDvBPIgt1VY_M, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzqQUgk1F8KyAi)
	{
		Transformation transformation = new Transformation();
		transformation._0023_003DzGvMngiE_003D(_0023_003Dz5ERWzMqlsNBW, _0023_003DzDvBPIgt1VY_M, _0023_003DzxuJqjrs_003D, _0023_003DzqQUgk1F8KyAi);
		TransformBy(transformation);
	}

	public void Rotate(double angleInRadians, Vector3D axis)
	{
		Rotate(angleInRadians, axis, Point3D.Origin);
	}

	public void Rotate(double angleInRadians, Vector3D axis, Point3D center)
	{
		_0023_003Dz6dFS2Jo_003D(Math.Sin(angleInRadians), Math.Cos(angleInRadians), axis, center);
	}

	public void Translate(double dx, double dy, double dz = 0.0)
	{
		Transformation transformation = new Transformation();
		transformation.Translation(dx, dy, dz);
		TransformBy(transformation);
	}

	public void Translate(Vector3D delta)
	{
		Transformation transformation = new Transformation();
		transformation.Translation(delta);
		TransformBy(transformation);
	}

	public double DistanceTo(Point3D point)
	{
		return Vector3D.Dot(point - origin, zAxis);
	}

	public bool Flip()
	{
		Vector3D vector3D = xAxis;
		xAxis = yAxis;
		yAxis = vector3D;
		zAxis.Negate();
		UpdateEquation();
		return true;
	}

	public void Project(Point3D P, out double s, out double t)
	{
		Vector3D vector3D = Vector3D.Subtract(P, origin);
		s = vector3D * xAxis;
		t = vector3D * yAxis;
	}

	public Point2D Project(Point3D P)
	{
		Project(P, out var s, out var t);
		return new Point2D(s, t);
	}

	public Vector2D Project(Vector3D P)
	{
		Project(P.AsPoint, out var s, out var t);
		return new Vector2D(s, t);
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951300), origin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659581), xAxis);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659564), yAxis);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659543), zAxis);
	}

	public virtual PlaneSurrogate ConvertToSurrogate()
	{
		return new PlaneSurrogate(this);
	}

	public override string ToString()
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659476) + origin?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659458) + zAxis;
	}

	public bool Equals(Plane other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (object.Equals(other.zAxis, zAxis) && object.Equals(other.yAxis, yAxis) && object.Equals(other.xAxis, xAxis))
		{
			return object.Equals(other.origin, origin);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Plane))
		{
			return false;
		}
		return Equals((Plane)obj);
	}

	public override int GetHashCode()
	{
		return (((((((zAxis != null) ? zAxis.GetHashCode() : 0) * 397) ^ ((yAxis != null) ? yAxis.GetHashCode() : 0)) * 397) ^ ((xAxis != null) ? xAxis.GetHashCode() : 0)) * 397) ^ ((origin != null) ? origin.GetHashCode() : 0);
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromAnalyticSurf(new PlanarSurf(this), parents);
	}

	public static bool operator ==(Plane left, Plane right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Plane left, Plane right)
	{
		return !object.Equals(left, right);
	}
}
