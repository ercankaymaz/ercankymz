using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Circle : PlanarEntity, ICurve, ICloneable, IEvaluable
{
	private int _edgeIndex = -1;

	private bool _fromBooleanIntersection;

	private double radius;

	public int EdgeIndex
	{
		get
		{
			return _edgeIndex;
		}
		set
		{
			_edgeIndex = value;
		}
	}

	public bool FromBooleanIntersection
	{
		get
		{
			return _fromBooleanIntersection;
		}
		set
		{
			_fromBooleanIntersection = value;
		}
	}

	public virtual bool IsPoint => radius < 1E-12;

	public Point3D Center
	{
		get
		{
			return base.Plane.Origin;
		}
		set
		{
			base.Plane.Origin = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double Radius
	{
		get
		{
			return radius;
		}
		set
		{
			if (value < 1E-12)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963671));
			}
			radius = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double Diameter => 2.0 * radius;

	public virtual Point3D StartPoint => PointAt(0.0);

	public virtual bool IsClosed => true;

	public virtual Interval Domain
	{
		get
		{
			return new Interval(0.0, Math.PI * 2.0);
		}
		set
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963627));
		}
	}

	public virtual Point3D EndPoint => PointAt(0.0);

	public virtual Vector3D StartTangent => TangentAt(0.0);

	public virtual Vector3D EndTangent => TangentAt(0.0);

	public Circle(double x, double y, double z, double radius)
		: base(Plane.XY)
	{
		if (!_0023_003DzuvS5KTE_003D(new Point3D(x, y, z), radius))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963458));
		}
	}

	public Circle(Point3D center, double radius)
		: base(Plane.XY)
	{
		if (!_0023_003DzuvS5KTE_003D(center, radius))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963458));
		}
	}

	public Circle(Plane plane, Point3D center, double radius)
		: base((Plane)plane.Clone())
	{
		if (!_0023_003DzuvS5KTE_003D(center, radius))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963458));
		}
	}

	public Circle(Plane plane, double radius)
		: base((Plane)plane.Clone())
	{
		if (!_0023_003DzuvS5KTE_003D(radius))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963458));
		}
	}

	public Circle(Plane plane, Point2D center, double radius)
		: base((Plane)plane.Clone())
	{
		if (!_0023_003DzuvS5KTE_003D(base.Plane.PointAt(center), radius))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963458));
		}
	}

	public Circle(Plane plane, Point2D first, Point2D second, Point2D third)
		: base((Plane)plane.Clone())
	{
		if (!_0023_003DzuvS5KTE_003D(first, second, third))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963458));
		}
	}

	public Circle(Point3D first, Point3D second, Point3D third)
	{
		Plane _0023_003Dzrgqz890sj_0024X;
		bool flag = Utility._0023_003DzNY5YUv279_SW(first, second, third, out _0023_003Dzrgqz890sj_0024X);
		if (flag)
		{
			base.Plane = _0023_003Dzrgqz890sj_0024X;
			Point2D _0023_003DzRVoDPs0_003D = _0023_003Dzrgqz890sj_0024X.Project(first);
			Point2D _0023_003Dz_0024ozI2Ww_003D = _0023_003Dzrgqz890sj_0024X.Project(second);
			Point2D _0023_003DzL765hYo5gCjL = _0023_003Dzrgqz890sj_0024X.Project(third);
			flag = _0023_003DzuvS5KTE_003D(_0023_003DzRVoDPs0_003D, _0023_003Dz_0024ozI2Ww_003D, _0023_003DzL765hYo5gCjL);
		}
		if (!flag)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963458));
		}
	}

	protected Circle(Circle another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		radius = another.radius;
	}

	protected internal Circle(CircleSurrogate surrogate)
		: base(surrogate.GetPlane())
	{
		radius = surrogate.GetRadius();
	}

	internal Circle(GCircle _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.Plane, _0023_003DzQwa1qM0_003D.Radius)
	{
	}

	protected Circle(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		radius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843));
	}

	public override object Clone()
	{
		return new Circle(this);
	}

	public override object CloneWithTessellation()
	{
		return new Circle(this, RegenMode != regenType.RegenAndCompile);
	}

	private bool _0023_003DzuvS5KTE_003D(double _0023_003DzRpXgovo_003D)
	{
		radius = _0023_003DzRpXgovo_003D;
		if (base.IsValid((StringBuilder)null))
		{
			return radius > 1E-12;
		}
		return false;
	}

	private bool _0023_003DzuvS5KTE_003D(Point3D _0023_003DzshZYG54_003D, double _0023_003DzRpXgovo_003D)
	{
		base.Plane.Origin.X = _0023_003DzshZYG54_003D.X;
		base.Plane.Origin.Y = _0023_003DzshZYG54_003D.Y;
		base.Plane.Origin.Z = _0023_003DzshZYG54_003D.Z;
		base.Plane.UpdateEquation();
		return _0023_003DzuvS5KTE_003D(_0023_003DzRpXgovo_003D);
	}

	private bool _0023_003DzuvS5KTE_003D(Point2D _0023_003DzRVoDPs0_003D, Point2D _0023_003Dz_0024ozI2Ww_003D, Point2D _0023_003DzL765hYo5gCjL)
	{
		Point2D obj = (Point2D)_0023_003DzRVoDPs0_003D.Clone();
		Point2D point2D = (Point2D)_0023_003Dz_0024ozI2Ww_003D.Clone();
		Point2D point2D2 = (Point2D)_0023_003DzL765hYo5gCjL.Clone();
		Translation xform = new Translation(0.0 - _0023_003DzRVoDPs0_003D.X, 0.0 - _0023_003DzRVoDPs0_003D.Y);
		obj.TransformBy(xform);
		point2D.TransformBy(xform);
		point2D2.TransformBy(xform);
		double x = obj.X;
		double y = obj.Y;
		double x2 = point2D.X;
		double y2 = point2D.Y;
		double x3 = point2D2.X;
		double y3 = point2D2.Y;
		double num = x * x + y * y;
		double num2 = x2 * x2 + y2 * y2;
		double num3 = x3 * x3 + y3 * y3;
		double[,] array = new double[3, 3]
		{
			{ num, y, 1.0 },
			{ num2, y2, 1.0 },
			{ num3, y3, 1.0 }
		};
		double num4 = Matrix.Determinant3(new double[3, 3]
		{
			{ x, y, 1.0 },
			{ x2, y2, 1.0 },
			{ x3, y3, 1.0 }
		});
		if (num4 == 0.0)
		{
			return false;
		}
		double num5 = Matrix.Determinant3(array) / (2.0 * num4);
		array[0, 0] = x;
		array[0, 1] = num;
		array[0, 2] = 1.0;
		array[1, 0] = x2;
		array[1, 1] = num2;
		array[1, 2] = 1.0;
		array[2, 0] = x3;
		array[2, 1] = num3;
		array[2, 2] = 1.0;
		double num6 = Matrix.Determinant3(array) / (2.0 * num4);
		array[0, 0] = x;
		array[0, 1] = y;
		array[0, 2] = num;
		array[1, 0] = x2;
		array[1, 1] = y2;
		array[1, 2] = num2;
		array[2, 0] = x3;
		array[2, 1] = y3;
		array[2, 2] = num3;
		Radius = Math.Sqrt(num5 * num5 + num6 * num6 + Matrix.Determinant3(array) / num4);
		Point2D point2D3 = new Point2D(num5, num6);
		Translation xform2 = new Translation(_0023_003DzRVoDPs0_003D.X, _0023_003DzRVoDPs0_003D.Y);
		point2D3.TransformBy(xform2);
		base.Plane.Origin = base.Plane.PointAt(point2D3);
		if (!(this is Arc))
		{
			if (base.IsValid((StringBuilder)null))
			{
				return radius > 1E-12;
			}
			return false;
		}
		return true;
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (radius <= 1E-12)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963681));
			return false;
		}
		return base.IsValid(log);
	}

	public bool IsPlanar(double tol, out Plane plane)
	{
		plane = (Plane)base.Plane.Clone();
		return true;
	}

	public bool IsInPlane(Plane testPlane, double tolerance)
	{
		bool flag = IsValid();
		int num = 0;
		while (flag && num < 3)
		{
			if (Math.Abs(testPlane.Equation.ValueAt(PointAt(Math.PI * 2.0 * (double)num / 3.0))) > tolerance)
			{
				flag = false;
				break;
			}
			num++;
		}
		return flag;
	}

	public bool IsPointInside(Point3D testPoint)
	{
		Point2D p = new Point2D(0.0, 0.0);
		Vector2D u = new Vector2D(p, base.Plane.Project(StartPoint));
		Point2D p2 = base.Plane.Project(testPoint);
		Vector2D vector2D = new Vector2D(p, p2);
		double t = Vector2D.SignedAngleBetween(u, vector2D);
		Point3D a = PointAt(t);
		double lengthSquared = vector2D.LengthSquared;
		double num = Point3D.DistanceSquared(a, base.Plane.Origin);
		if (lengthSquared < num)
		{
			return true;
		}
		return false;
	}

	public bool IsLinear(double tol, out Segment3D line)
	{
		line = null;
		return false;
	}

	public Point3D PointAt(double t)
	{
		return Ellipse.PointOnEllipseAt(t, base.Plane, radius, radius);
	}

	public override void Regen(RegenParams data)
	{
		int num = Utility.NumberOfSegments(radius, Math.PI * 2.0, data.Deviation, data.Angle);
		_vertices = new Point3D[num + 1];
		for (int i = 0; i < num + 1; i++)
		{
			double t = (double)(i * 2) * Math.PI / (double)num;
			Point3D point3D = PointAt(t);
			Vector3D vector3D = TangentAt(t);
			_vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	internal void _0023_003DzAWinFpBcJb6_3uUJ15BE5C0_003D(RegenParams _0023_003DzELu0Pss_003D, int _0023_003DzgyNPRm1lVYUG)
	{
		_vertices = new Point3D[_0023_003DzgyNPRm1lVYUG + 1];
		for (int i = 0; i < _0023_003DzgyNPRm1lVYUG + 1; i++)
		{
			double t = (double)(i * 2) * Math.PI / (double)_0023_003DzgyNPRm1lVYUG;
			Point3D point3D = PointAt(t);
			Vector3D vector3D = TangentAt(t);
			_vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
		}
	}

	internal void _0023_003Dzci7aJXfjtY_00243OTtVfw_003D_003D(RegenParams _0023_003DzELu0Pss_003D, List<double> _0023_003DzHSO_00246A0_003D, double _0023_003Dz7pAiRvw_003D, double _0023_003DzqU35YqE_003D)
	{
		List<Point3D> list = new List<Point3D>();
		list.Add(new PointTangent(StartPoint.X, StartPoint.Y, StartPoint.Z, StartTangent.X, StartTangent.Y, StartTangent.Z));
		double num = _0023_003Dz7pAiRvw_003D;
		if (_0023_003Dz7pAiRvw_003D > _0023_003DzqU35YqE_003D)
		{
			_0023_003DzHSO_00246A0_003D.Reverse();
			num = _0023_003DzqU35YqE_003D;
		}
		new Interval(_0023_003Dz7pAiRvw_003D, _0023_003DzqU35YqE_003D);
		for (int i = 0; i < _0023_003DzHSO_00246A0_003D.Count; i++)
		{
			double num2 = (_0023_003DzHSO_00246A0_003D[i] - num) / Math.Abs(_0023_003DzqU35YqE_003D - _0023_003Dz7pAiRvw_003D);
			if (_0023_003Dz7pAiRvw_003D > _0023_003DzqU35YqE_003D)
			{
				num2 = 1.0 - num2;
			}
			if (!(Math.Abs(num2 - _0023_003DzqU35YqE_003D) < Utility._0023_003DzheSR8QM7q9ya) && !(Math.Abs(num2 - _0023_003Dz7pAiRvw_003D) < Utility._0023_003DzheSR8QM7q9ya))
			{
				double t = Domain.ParameterAt(num2);
				Point3D point3D = PointAt(t);
				Vector3D vector3D = TangentAt(t);
				list.Add(new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z));
			}
		}
		list.Add(new PointTangent(EndPoint.X, EndPoint.Y, EndPoint.Z, EndTangent.X, EndTangent.Y, EndTangent.Z));
		_vertices = list.ToArray();
	}

	public virtual double Length()
	{
		return Math.PI * 2.0 * radius;
	}

	public virtual void Reverse()
	{
		Vector3D axisY = base.Plane.AxisY;
		axisY.Negate();
		base.Plane = new Plane(base.Plane.Origin, base.Plane.AxisX, axisY);
		RegenMode = regenType.RegenAndCompile;
	}

	public virtual Region OffsetToRegion(double amount, bool sharp)
	{
		ICurve curve = (ICurve)Clone();
		ICurve[] array = Offset(amount, base.Plane.AxisZ, sharp);
		ICurve curve2 = ((array != null) ? array[0] : null);
		if (amount > 0.0)
		{
			curve.Reverse();
		}
		else
		{
			curve2.Reverse();
		}
		return new Region(new ICurve[2] { curve, curve2 }, base.Plane);
	}

	public virtual Point3D[] GetPointsByLength(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		double num = Math.PI * 2.0;
		double num2 = Length() / length;
		int num3 = (int)Math.Ceiling(num2);
		int num4 = (int)Math.Truncate(num2);
		int num5 = ((num2 - (double)num4 < length * Utility._0023_003DzxhnLabVjXjPg) ? num4 : num3);
		if (num5 < 3)
		{
			num5 = 3;
		}
		Point3D[] array = new Point3D[num5 + 1];
		for (int i = 0; i <= num5; i++)
		{
			array[i] = PointAt(0.0 + (double)i * num / (double)num5);
		}
		return array;
	}

	public Point3D[] GetPointsByLengthPerSegment(double length)
	{
		return GetPointsByLength(length);
	}

	public virtual void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		Vector3D axisZ = base.Plane.AxisZ;
		double a = _0023_003Dzv3_XI_A_003D(axisZ, new Vector3D(1.0, 0.0, 0.0));
		double a2 = _0023_003Dzv3_XI_A_003D(axisZ, new Vector3D(0.0, 1.0, 0.0));
		double a3 = _0023_003Dzv3_XI_A_003D(axisZ, new Vector3D(0.0, 0.0, 1.0));
		Vector3D vector3D = new Vector3D(Math.Sin(a), Math.Sin(a2), Math.Sin(a3));
		vector3D *= Radius;
		Utility.ComputeBoundingBox(new Point3D[2]
		{
			Center - vector3D,
			Center + vector3D
		}, out boxMin, out boxMax);
	}

	private static double _0023_003Dzv3_XI_A_003D(Vector3D _0023_003DzE8QrneA_003D, Vector3D _0023_003DzH9VU2k0_003D)
	{
		double num = _0023_003DzE8QrneA_003D * _0023_003DzH9VU2k0_003D;
		if (num <= -1.0)
		{
			return Math.PI;
		}
		if (num >= 1.0)
		{
			return 0.0;
		}
		return Math.Acos(num);
	}

	public Vector3D TangentAt(double t)
	{
		return Ellipse._0023_003DzDY8DgLzNJbK6(t, base.Plane, 1.0, 1.0);
	}

	public Vector3D NormalAt(double t)
	{
		return Ellipse._0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(2, t, base.Plane, 1.0, 1.0);
	}

	public ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp = false)
	{
		Vector3D vector3D = (Vector3D)planeNormal.Clone();
		vector3D.Normalize();
		Circle circle = (Circle)Clone();
		if (Vector3D.AreCoincident(vector3D, base.Plane.AxisZ))
		{
			double num = Math.Abs(Radius + amount);
			if (num < 1E-12)
			{
				return Array.Empty<ICurve>();
			}
			circle.Radius = Math.Abs(num);
		}
		else
		{
			if (!Vector3D.AreOpposite(vector3D, base.Plane.AxisZ))
			{
				return GetNurbsForm().Offset(amount, planeNormal);
			}
			double num = Math.Abs(Radius - amount);
			if (num < 1E-12)
			{
				return Array.Empty<ICurve>();
			}
			circle.Radius = Math.Abs(num);
		}
		circle.CopyAttributes(this);
		return new ICurve[1] { circle };
	}

	public Vector3D DerivativeAt(int d, double t)
	{
		return Ellipse._0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(d, t, base.Plane, radius, radius);
	}

	public virtual Curve GetNurbsForm()
	{
		double length = Domain.Length;
		double[] array = new double[12];
		array[0] = (array[1] = (array[2] = 0.0));
		array[3] = (array[4] = 0.25 * length);
		array[5] = (array[6] = 0.5 * length);
		array[7] = (array[8] = 0.75 * length);
		array[9] = (array[10] = (array[11] = length));
		Point4D[] array2 = new Point4D[9];
		array2[0] = new Point4D(base.Plane.PointAt(radius, 0.0));
		array2[1] = new Point4D(base.Plane.PointAt(radius, radius));
		array2[2] = new Point4D(base.Plane.PointAt(0.0, radius));
		array2[3] = new Point4D(base.Plane.PointAt(0.0 - radius, radius));
		array2[4] = new Point4D(base.Plane.PointAt(0.0 - radius, 0.0));
		array2[5] = new Point4D(base.Plane.PointAt(0.0 - radius, 0.0 - radius));
		array2[6] = new Point4D(base.Plane.PointAt(0.0, 0.0 - radius));
		array2[7] = new Point4D(base.Plane.PointAt(radius, 0.0 - radius));
		array2[8] = (Point4D)array2[0].Clone();
		double num = 1.0 / Math.Sqrt(2.0);
		for (int i = 1; i < 8; i += 2)
		{
			array2[i].X *= num;
			array2[i].Y *= num;
			array2[i].Z *= num;
			array2[i].W = num;
		}
		Curve curve = new Curve(2, array, array2, checkKnotsAndCtrlPts: false);
		curve.CopyAttributes(this);
		return curve;
	}

	internal Surface[] _0023_003Dz_u3Gbv9hz91RZ4WcZ1pXeok_003D(double _0023_003DzAqOpw0w_003D, double _0023_003DzEEncnNQ_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		Surface surface = ((ICurve)this).GetNurbsForm()._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003DzAqOpw0w_003D, _0023_003DzEEncnNQ_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, this);
		if (surface != null)
		{
			return new Surface[1] { surface };
		}
		return new Surface[0];
	}

	public virtual bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		if (!Utility.AreEqual(t, 0.0, Math.PI * 2.0) && !Utility.AreEqual(t, Math.PI * 2.0, Math.PI * 2.0) && t > 0.0 && t < Math.PI * 2.0)
		{
			lower = new Arc(base.Plane, (Point3D)Center.Clone(), Radius, 0.0, t);
			upper = new Arc(base.Plane, (Point3D)Center.Clone(), Radius, t, Math.PI * 2.0);
			((Entity)lower).CopyAttributes(this);
			((Entity)upper).CopyAttributes(this);
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	public bool SplitBy(Point3D pt, out ICurve lower, out ICurve upper)
	{
		ClosestPointTo(pt, out var t);
		return SplitAt(t, out lower, out upper);
	}

	public bool SplitBy(IList<Point3D> points, out ICurve[] segments)
	{
		return Utility._0023_003Dz01EVtoUdEn9B(this, points, out segments);
	}

	public virtual bool TrimAt(double t, bool flipSide)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963328));
	}

	public virtual bool TrimBy(Point3D pt, bool flipSide)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963328));
	}

	public virtual bool ExtendAt(double t)
	{
		return false;
	}

	public virtual bool ExtendBy(Point3D pt, bool curveEnd = true)
	{
		return false;
	}

	public virtual bool Project(Point3D point, out double t)
	{
		base.Plane.Project(point, out var s, out var t2);
		if (s == 0.0 && t2 == 0.0)
		{
			t = 0.0;
		}
		else
		{
			t = Math.Atan2(t2, s);
			if (t < 0.0)
			{
				t += Math.PI * 2.0;
			}
		}
		return true;
	}

	public Point3D[] IntersectWith(ICurve C2, double maxGap = 0.0, bool computeParameters = true)
	{
		List<Point3D> list = new List<Point3D>();
		GetApproximatedBoundingBox(out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		C2.GetApproximatedBoundingBox(out var boxMin2, out var boxMax2);
		Size3D size3D2 = new Size3D(boxMin2, boxMax2);
		double num = size3D.Diagonal + size3D2.Diagonal;
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(maxGap, boxMin, boxMax);
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(maxGap, boxMin2, boxMax2);
		if (Utility.DoOverlapOrTouch(boxMin, boxMax, boxMin2, boxMax2))
		{
			if (Utility.IsLine(C2))
			{
				Line line = new Line(C2.StartPoint, C2.EndPoint);
				Utility._0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D = ((maxGap > 0.0) ? Utility._0023_003DztDh_5dSqxQPzO4_gIg_003D_003D._0023_003DzL9woobs_003D(line, this, maxGap, 1E-12) : Utility._0023_003DztDh_5dSqxQPzO4_gIg_003D_003D._0023_003DzL9woobs_003D(line, this, 1E-09 * num, 1E-12));
				for (int i = 0; i < _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz7L3Iw6frIRXoyynokiNCmg4_003D; i++)
				{
					if (C2.Domain.Low != line.Domain.Low || C2.Domain.High != line.Domain.High)
					{
						_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzqLMDDyVBo88_0024[i] = C2.Domain.Low + C2.Domain.Length / line.Domain.Length * (_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzqLMDDyVBo88_0024[i] - line.Domain.Low);
					}
					if (!computeParameters)
					{
						list.Add(_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item2);
					}
					else
					{
						list.Add(new InterPoint(_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item2.X, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item2.Y, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item2.Z, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzlcY317DiY_0024sJ[i], 0.0, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzqLMDDyVBo88_0024[i], 0.0));
					}
				}
				return list.ToArray();
			}
			if (C2 is Circle)
			{
				if (Utility._0023_003Dz4BQ0X_NQrDi3B6fchajn6vP0dc1x(this, (Circle)C2, out var _0023_003Dz348XSZM_003D, out var _0023_003DzVxmwB6Y_003D, num))
				{
					if (!computeParameters)
					{
						list.Add(_0023_003Dz348XSZM_003D);
						if (_0023_003DzVxmwB6Y_003D != null)
						{
							list.Add(_0023_003DzVxmwB6Y_003D);
						}
					}
					else
					{
						InterPoint item = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, C2, _0023_003Dz348XSZM_003D);
						list.Add(item);
						if (_0023_003DzVxmwB6Y_003D != null)
						{
							item = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, C2, _0023_003DzVxmwB6Y_003D);
							list.Add(item);
						}
					}
				}
				return list.ToArray();
			}
			if (C2 is LinearPath || C2 is CompositeCurve || C2 is Point)
			{
				Point3D[] array = ((!(C2 is LinearPath linearPath)) ? ((!(C2 is CompositeCurve compositeCurve)) ? C2.IntersectWith(this) : compositeCurve._0023_003DzGKZuR_4q838u(this, num, maxGap, computeParameters)) : linearPath._0023_003DzGKZuR_4q838u(this, num, maxGap, computeParameters));
				if (computeParameters)
				{
					for (int j = 0; j < array.Length; j++)
					{
						InterPoint obj = (InterPoint)array[j];
						double u = obj.u;
						obj.u = obj.s;
						obj.s = u;
					}
				}
				return array;
			}
			return Utility.Intersection(this, C2, maxGap, computeParameters);
		}
		return list.ToArray();
	}

	public Point3D[] IntersectWithPlane(Plane pln, bool computeParameters = true)
	{
		List<Point3D> list = new List<Point3D>();
		if (Math.Abs(pln.DistanceTo(Center)) > Radius + 1E-12)
		{
			return list.ToArray();
		}
		if (Plane.Intersection(base.Plane, pln, out var intSeg) != planeIntersectionType.UniqueLine)
		{
			return list.ToArray();
		}
		Vector3D asVector = (intSeg.P1 - intSeg.P0).AsVector;
		asVector.Normalize();
		Line line = new Line(intSeg.P0 - asVector * 2.0 * Radius, intSeg.P1 + asVector * 2.0 * Radius);
		GetApproximatedBoundingBox(out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		line.GetApproximatedBoundingBox(out var boxMin2, out var boxMax2);
		Size3D size3D2 = new Size3D(boxMin2, boxMax2);
		double _0023_003DzccAR5G0_003D = size3D.Diagonal + size3D2.Diagonal;
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(0.001, boxMin, boxMax);
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(0.001, boxMin2, boxMax2);
		line.ExtendBy(boxMin);
		line.ExtendBy(boxMax);
		line.ExtendAt(line.Domain.Low - 2.0 * Radius);
		line.ExtendAt(line.Domain.High + 2.0 * Radius);
		if (Utility._0023_003DzlTBtz4ei63kfZ2jCcIi4R8c_003D(line, this, _0023_003DzccAR5G0_003D, out var _0023_003Dz348XSZM_003D, out var _0023_003DzVxmwB6Y_003D))
		{
			if (!computeParameters)
			{
				list.Add(_0023_003Dz348XSZM_003D);
				if (_0023_003DzVxmwB6Y_003D != null)
				{
					list.Add(_0023_003DzVxmwB6Y_003D);
				}
			}
			else
			{
				InterPoint interPoint = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, line, _0023_003Dz348XSZM_003D);
				InitialPoint initialPoint = new InitialPoint(interPoint.X, interPoint.Y, interPoint.Z, interPoint.u, interPoint.v, interPoint.s, interPoint.t);
				Vector3D vector3D = TangentAt(interPoint.u);
				initialPoint.curveTx = vector3D.X;
				initialPoint.curveTy = vector3D.Y;
				initialPoint.curveTz = vector3D.Z;
				list.Add(initialPoint);
				if (_0023_003DzVxmwB6Y_003D != null)
				{
					interPoint = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, line, _0023_003DzVxmwB6Y_003D);
					initialPoint = new InitialPoint(interPoint.X, interPoint.Y, interPoint.Z, interPoint.u, interPoint.v, interPoint.s, interPoint.t);
					vector3D = TangentAt(interPoint.u);
					initialPoint.curveTx = vector3D.X;
					initialPoint.curveTy = vector3D.Y;
					initialPoint.curveTz = vector3D.Z;
					list.Add(initialPoint);
				}
			}
			if (computeParameters)
			{
				foreach (InitialPoint item in list)
				{
					pln.Project(item, out var s, out var t);
					item.s = s;
					item.t = t;
				}
			}
			return list.ToArray();
		}
		return list.ToArray();
	}

	public double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond)
	{
		if (Utility.IsLine(curve))
		{
			Utility._0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D = Utility._0023_003DztDh_5dSqxQPzO4_gIg_003D_003D._0023_003DzL9woobs_003D(new Line(curve.StartPoint, curve.EndPoint), this, 1E-12, 1E-12);
			closestPointOnFirst = _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzyUs6D9_SWs1i;
			closestPointOnSecond = _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzOK_0024S8ThjuNW5;
			return _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzOxKU6GM_003D;
		}
		double num = double.MaxValue;
		closestPointOnFirst = null;
		closestPointOnSecond = null;
		if (curve is CompositeCurve)
		{
			ICurve[] individualCurves = curve.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				Curve[] array = individualCurves[i].GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
				foreach (Curve b in array)
				{
					MinimumDistance minimumDistance = new MinimumDistance(this, b);
					minimumDistance.DoWork();
					if (minimumDistance.Result.Length < num)
					{
						num = minimumDistance.Result.Length;
						closestPointOnFirst = new Point3D[1] { minimumDistance.Result.P0 };
						closestPointOnSecond = new Point3D[1] { minimumDistance.Result.P1 };
					}
				}
			}
		}
		else
		{
			Curve[] array2 = curve.GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
			foreach (Curve b2 in array2)
			{
				MinimumDistance minimumDistance2 = new MinimumDistance(this, b2);
				minimumDistance2.DoWork();
				if (minimumDistance2.Result.Length < num)
				{
					num = minimumDistance2.Result.Length;
					closestPointOnFirst = new Point3D[1] { minimumDistance2.Result.P0 };
					closestPointOnSecond = new Point3D[1] { minimumDistance2.Result.P1 };
				}
			}
		}
		return num;
	}

	public virtual void ClosestPointTo(Point3D pt, out double t)
	{
		Project(pt, out t);
	}

	public ICurve[] GetIndividualCurves()
	{
		return new ICurve[1] { this };
	}

	public override void TransformBy(Transformation xform)
	{
		Plane pl = (Plane)base.Plane.Clone();
		base.TransformBy(xform);
		double scaleFactor = Math.Abs(xform.ScaleFactorX);
		if (xform.IsScaleFactorUniform() || xform.IsScaleFactorUniformForPlanar(pl, ref scaleFactor))
		{
			radius *= scaleFactor;
		}
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			Point3D[] array = new Point3D[4];
			double num = Math.PI * 2.0;
			array[0] = PointAt(0.0 * num / 4.0);
			array[1] = PointAt(num / 4.0);
			array[2] = PointAt(2.0 * num / 4.0);
			array[3] = PointAt(3.0 * num / 4.0);
			return array;
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public bool GetParamFromLength(double length, out double t)
	{
		double curveLength = Length();
		return GetParamFromLength(length, curveLength, out t);
	}

	public bool GetParamFromLength(double length, double curveLength, out double t)
	{
		if (Utility.AreEqual(length, 0.0, curveLength))
		{
			t = Domain.t0;
			return true;
		}
		if (Utility.AreEqual(length, curveLength, curveLength))
		{
			t = Domain.t1;
			return true;
		}
		if (length < 0.0 || length > curveLength)
		{
			t = Domain.t0;
			return false;
		}
		t = Domain.Low + length / radius;
		return true;
	}

	public bool GetLengthFromParam(double t, out double length)
	{
		double low = Domain.Low;
		double high = Domain.High;
		if (t < low || t > high)
		{
			length = 0.0;
			return false;
		}
		length = Math.Abs((t - low) * Radius);
		return true;
	}

	public virtual bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		ClosestPointTo(startPt, out var t);
		ClosestPointTo(endPt, out var t2);
		if (t > t2)
		{
			t2 += Math.PI * 2.0;
		}
		return SubCurve(t, t2, out sub);
	}

	public virtual bool SubCurve(double t0, double t1, out ICurve sub)
	{
		double num = Math.PI * 2.0;
		if (!_0023_003DzJUU5L0s5zlzq(_0023_003DzbErHvVw_003D: true, 0.0, num, num, ref t0, ref t1))
		{
			sub = null;
			return false;
		}
		sub = new Arc(base.Plane, base.Plane.Origin, radius, t0, t1);
		((Entity)sub).CopyAttributes(this);
		return true;
	}

	internal static bool _0023_003DzJUU5L0s5zlzq(bool _0023_003DzbErHvVw_003D, double _0023_003Dzpm4hAvE_003D, double _0023_003Dz7CNwMo8_003D, double _0023_003DzhbkBViI_003D, ref double _0023_003DzDSaZWik_003D, ref double _0023_003DzsK_Xndk_003D)
	{
		bool flag = Utility.AreEqual(_0023_003DzDSaZWik_003D, _0023_003DzsK_Xndk_003D, _0023_003DzhbkBViI_003D);
		bool flag2 = Utility.AreEqual(_0023_003DzDSaZWik_003D, _0023_003Dz7CNwMo8_003D, _0023_003DzhbkBViI_003D);
		bool flag3 = Utility.AreEqual(_0023_003DzDSaZWik_003D, _0023_003Dzpm4hAvE_003D, _0023_003DzhbkBViI_003D);
		bool flag4 = Utility.AreEqual(_0023_003DzsK_Xndk_003D, _0023_003Dzpm4hAvE_003D, _0023_003DzhbkBViI_003D);
		if (_0023_003DzbErHvVw_003D)
		{
			if (flag)
			{
				if (!(flag3 || flag2))
				{
					return false;
				}
				_0023_003DzDSaZWik_003D = _0023_003Dzpm4hAvE_003D;
				_0023_003DzsK_Xndk_003D = _0023_003Dz7CNwMo8_003D;
			}
			if (_0023_003DzDSaZWik_003D > _0023_003DzsK_Xndk_003D)
			{
				if (flag2)
				{
					_0023_003DzDSaZWik_003D = _0023_003Dzpm4hAvE_003D;
				}
				if (flag4)
				{
					_0023_003DzsK_Xndk_003D = _0023_003Dz7CNwMo8_003D;
				}
				if (!flag2 && !flag4)
				{
					return false;
				}
			}
		}
		else
		{
			if (Utility.AreEqual(_0023_003DzDSaZWik_003D, _0023_003Dzpm4hAvE_003D, _0023_003DzhbkBViI_003D))
			{
				_0023_003DzDSaZWik_003D = _0023_003Dzpm4hAvE_003D;
			}
			if (Utility.AreEqual(_0023_003DzsK_Xndk_003D, _0023_003Dz7CNwMo8_003D, _0023_003DzhbkBViI_003D))
			{
				_0023_003DzsK_Xndk_003D = _0023_003Dz7CNwMo8_003D;
			}
			if (flag)
			{
				return false;
			}
			if (_0023_003DzDSaZWik_003D < _0023_003Dzpm4hAvE_003D || _0023_003DzsK_Xndk_003D > _0023_003Dz7CNwMo8_003D || _0023_003DzDSaZWik_003D > _0023_003DzsK_Xndk_003D)
			{
				return false;
			}
		}
		return true;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963250) + radius + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963264) + Length().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public bool GetNurbsFormParameterFromRadian(double radianParam, out double nurbsParam)
	{
		Curve nurbsForm = GetNurbsForm();
		return GetNurbsFormParameterFromRadian(radianParam, out nurbsParam, nurbsForm);
	}

	public bool GetNurbsFormParameterFromRadian(double radianParam, out double nurbsParam, Curve crv)
	{
		return new EllipticalArc(base.Plane, Center, Radius, Radius, crv.Domain.t0, crv.Domain.t1)._0023_003DzkIYRqMrwTtoQ7uOV_dn3JAI_003D(radianParam, out nurbsParam, crv);
	}

	public bool GetRadianFromNurbFormParameter(double nurbParameter, out double radianParameter)
	{
		Curve nurbsForm = GetNurbsForm();
		return GetRadianFromNurbFormParameter(nurbParameter, out radianParameter, nurbsForm);
	}

	public bool GetRadianFromNurbFormParameter(double nurbParameter, out double radianParameter, Curve nurbsArc)
	{
		return new EllipticalArc(base.Plane, Center, Radius, Radius, nurbsArc.Domain.t0, nurbsArc.Domain.t1)._0023_003DziF9U0ToEO_0024ZpwCK8UCiW2dw_003D(nurbParameter, out radianParameter, nurbsArc, _0023_003DzNLR5KV3Ce3_0024s: true);
	}

	public LinearPath ConvertToLinearPath(double deviation = 0.0, double angle = 0.0)
	{
		if (deviation == 0.0)
		{
			return _0023_003DztgI92lDISTaw0QRVK9fD0NM_003D();
		}
		Circle obj = (Circle)Clone();
		obj.Regen(new RegenParams(deviation, angle));
		return obj.ConvertToLinearPath();
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(amount, tolerance, meshNature);
	}

	public Mesh ExtrudeAsMesh(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(amount, tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		Mesh[] array = _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		T[] array = _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		return _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, merge);
	}

	public T[] SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, merge);
	}

	public Surface[] ExtrudeAsSurface(Line line)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(line.Direction);
	}

	public Surface[] ExtrudeAsSurface(double dx, double dy, double dz)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(new Vector3D(dx, dy, dz));
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		double value = vector3D * base.Plane.AxisZ;
		if (1.0 - Math.Abs(value) < 1E-09)
		{
			double num = Math.Sign(new Plane(Point3D.Origin, Entity.GetClosestMainAxis(vector3D)).DistanceTo(amount.AsPoint));
			Vector3D vector3D2 = (Vector3D)amount.Clone();
			vector3D2.Length = Math.Abs(amount.Length / Math.Cos(draftAngleInRadians));
			Line line = new Line(StartPoint, StartPoint + vector3D2);
			line.Rotate((0.0 - num) * draftAngleInRadians, StartTangent, StartPoint);
			return line.RevolveAsSurface(0.0, Domain.Length, base.Plane.AxisZ, Center);
		}
		Curve nurbsForm = GetNurbsForm();
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = nurbsForm._0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		Surface[] array = new Surface[1] { Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve) };
		Surface[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i]._0023_003DzrtnP79knlhMG(this);
		}
		return array;
	}

	public Brep ExtrudeAsBrep(Line line, double tolerance = 0.001)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, line.Direction, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, null, 0.0);
	}

	public Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.001)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, new Vector3D(dx, dy, dz), _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public virtual Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, amount, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		double num = vector3D * base.Plane.AxisZ;
		Curve nurbsForm = GetNurbsForm();
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = nurbsForm._0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		Point3D[] array = new Brep.Vertex[2];
		Point3D[] array2 = array;
		array2[0] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.StartPoint.X, _0023_003Dz6nnnQo75Qjsf.StartPoint.Y, _0023_003Dz6nnnQo75Qjsf.StartPoint.Z);
		array2[1] = new Brep.Vertex(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
		Brep.Edge[] edges = new Brep.Edge[3]
		{
			new Brep.Edge((ICurve)_0023_003Dz6nnnQo75Qjsf.Clone(), 0, 0),
			new Brep.Edge((ICurve)curve.Clone(), 1, 1),
			new Brep.Edge(new Line((Point3D)array2[0].Clone(), (Point3D)array2[1].Clone()), 0, 1)
		};
		Brep.OrientedEdge[] segments = new Brep.OrientedEdge[4]
		{
			new Brep.OrientedEdge(0),
			new Brep.OrientedEdge(2),
			new Brep.OrientedEdge(1, sense: false),
			new Brep.OrientedEdge(2, sense: false)
		};
		Brep.Face[] array3 = new Brep.Face[1];
		if (1.0 - Math.Abs(num) < 1E-09)
		{
			Vector3D axis = new Vector3D(Math.Abs(base.Plane.AxisZ.X), Math.Abs(base.Plane.AxisZ.Y), Math.Abs(base.Plane.AxisZ.Z));
			Plane _0023_003Dzrgqz890sj_0024X = new Plane(Center, amount);
			bool flag = Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(this, _0023_003Dzrgqz890sj_0024X);
			AnalyticSurf surface = new ConicalSurf(Center, axis, base.Plane.AxisX, radius, (double)(flag ? 1 : (-1)) * draftAngleInRadians);
			array3[0] = new Brep.Face(surface, new Brep.Loop(segments), num > 1E-09);
		}
		else
		{
			Surface surface2 = Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve);
			AnalyticSurf surface = new NurbsSurf(surface2.DegreeU, surface2.KnotVectorU, surface2.DegreeV, surface2.KnotVectorV, surface2.ControlPoints);
			array3[0] = new Brep.Face(surface, new Brep.Loop(segments));
		}
		Brep brep = new Brep(array2, edges, array3);
		brep._0023_003DzrtnP79knlhMG(this);
		return brep;
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return _0023_003Dz_u3Gbv9hz91RZ4WcZ1pXeok_003D(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return _0023_003Dz_u3Gbv9hz91RZ4WcZ1pXeok_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis)
	{
		return _0023_003Dz_u3Gbv9hz91RZ4WcZ1pXeok_003D(startAngle, deltaAngle, axis.Direction, axis.StartPoint);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.001)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, startAngle, deltaAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.001)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, intervalAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.001)
	{
		return RevolveAsBrep(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.001)
	{
		return RevolveAsBrep(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Line axis, double tolerance = 0.001)
	{
		return RevolveAsBrep(startAngle, deltaAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Line axis, double tolerance = 0.001)
	{
		return RevolveAsBrep(intervalAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003Dz789GXCk_003D(rail, tol, methodType);
	}

	public Brep SweepAsBrep(ICurve rail, double tolerance, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep[] array = Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, _0023_003DzjepEGXc_003D: true, methodType);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Brep[] SweepAsBrep(ICurve rail, double tolerance, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, merge, methodType);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount, tolerance);
	}

	public Solid ExtrudeAsSolid(double dx, double dy, double dz, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(new Vector3D(dx, dy, dz), tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(intervalAngle.Low, intervalAngle.Length, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(intervalAngle.Low, intervalAngle.Length, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid SweepAsSolid(ICurve rail, double tol, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		Solid[] array = _0023_003DzggPwIWi3oqtM(rail, tol, _0023_003DzjepEGXc_003D: true, sweepMethod);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Solid[] SweepAsSolid(ICurve rail, double tol, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003DzggPwIWi3oqtM(rail, tol, merge, sweepMethod);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new CircleSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), radius);
	}

	public Vector3D[] Evaluate(double u, int d)
	{
		Vector3D[] array = new Vector3D[d + 1];
		Point3D point3D = base.Plane.PointAt(Math.Cos(u) * radius, Math.Sin(u) * radius);
		array[0] = new Vector3D(point3D.X, point3D.Y, point3D.Z);
		for (int i = 1; i < d + 1; i++)
		{
			array[i] = Ellipse._0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(i, u, base.Plane, radius, radius);
		}
		return array;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963245), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), Radius);
	}

	public void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax)
	{
		GetTightBBox(out boxMin, out boxMax);
	}

	protected internal override void Draw(DrawParams data)
	{
		DrawWire(data);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		CompileWire(data);
		RegenMode = regenType.NotNeeded;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		Transformation transformation = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = new _0023_003DzdPtvklPFzKqxMoTpEOXyeC1W53neVz2gTQ_003D_003D(0.0, 0.0, 0.0, Radius, 0.0, Math.PI * 2.0, transformation.Matrix, ColorMethod == colorMethodType.byEntity, LayerName, Color, _0023_003Dz_KjZG5vEM9v9: false);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1] { _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 };
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		Utility.DrawArrowOnView(data, EndTangent, EndPoint);
	}

	internal override bool _0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		if (!_0023_003DzjZRgeJk_003D || _localOB == null)
		{
			_localOB = new OrientedBoundingRect(base.Plane.Origin - Vector3D.AxisX * Radius - Vector3D.AxisY * Radius, Radius * 2.0, Radius * 2.0);
		}
		base._0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(_0023_003DzELu0Pss_003D, out _0023_003DzrdSL0CI_003D, out _0023_003DzD5Gs7jmmc9uK, out _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D: true);
		return true;
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D2 = new _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D(base.Plane.Origin.ToArray(), Radius, base.Plane.AxisX.ToArray(), base.Plane.AxisY.ToArray());
		_0023_003DzYe_6EnQecc8d(_0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D2 };
	}
}
