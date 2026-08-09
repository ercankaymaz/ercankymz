using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Arc : Circle
{
	internal Interval angle;

	public override bool IsPoint
	{
		get
		{
			if (!base.IsPoint)
			{
				return AngleInRadians < 1E-12;
			}
			return true;
		}
	}

	public Interval Angle => angle;

	public double AngleInRadians => angle.Length;

	public double AngleInDegrees => 180.0 * angle.Length / Math.PI;

	public override Point3D StartPoint => PointAt(angle.t0);

	public Point3D MidPoint => PointAt(angle.Mid);

	public override Point3D EndPoint => PointAt(angle.t1);

	public override bool IsClosed => angle.IsTwoPI;

	public override Interval Domain
	{
		get
		{
			return angle;
		}
		set
		{
			_0023_003DzP7Itlc0_003D(this, ref angle, value);
		}
	}

	public bool IsCircle => angle.IsTwoPI;

	public override Vector3D StartTangent => TangentAt(angle.t0);

	public override Vector3D EndTangent => TangentAt(angle.t1);

	public Arc(Point3D center, double radius, double angleInRadians)
		: base(center, radius)
	{
		if (!_0023_003DzuvS5KTE_003D(center, radius, angleInRadians))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955100));
		}
	}

	public Arc(Plane arcPlane, Point3D center, double radius, double angleInRadians)
		: base(arcPlane, center, radius)
	{
		if (!_0023_003DzuvS5KTE_003D(center, radius, angleInRadians))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955100));
		}
	}

	public Arc(Point3D center, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(center, radius)
	{
		if (!_0023_003DzuvS5KTE_003D(new Circle(center, radius), new Interval(startAngleInRadians, endAngleInRadians)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955100));
		}
	}

	public Arc(double x, double y, double z, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(x, y, z, radius)
	{
		if (!_0023_003DzuvS5KTE_003D(new Circle(new Point3D(x, y, z), radius), new Interval(startAngleInRadians, endAngleInRadians)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955100));
		}
	}

	public Arc(Plane arcPlane, Point3D center, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(arcPlane, center, radius)
	{
		if (!_0023_003DzuvS5KTE_003D(new Circle(base.Plane, center, radius), new Interval(startAngleInRadians, endAngleInRadians)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955100));
		}
	}

	public Arc(Plane arcPlane, Point2D center, double radius, double startAngleInRadians, double endAngleInRadians)
		: base(arcPlane, center, radius)
	{
		if (!_0023_003DzuvS5KTE_003D(new Circle(base.Plane, base.Plane.PointAt(center), radius), new Interval(startAngleInRadians, endAngleInRadians)))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955100));
		}
	}

	public Arc(Point3D center, Point3D start, Point3D end)
		: base(new Plane(center, start, end), center, 1.0)
	{
		double num = Point3D.Distance(start, center);
		Plane xY = Plane.XY;
		Transformation transformation = new Transformation();
		transformation.Rotation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ, xY.Origin, xY.AxisX, xY.AxisY, xY.AxisZ);
		Point3D point3D = transformation * end;
		double t = Utility.ArcTanProblem(point3D.X, point3D.Y);
		_0023_003DzuvS5KTE_003D(new Circle(base.Plane, center, num), new Interval(0.0, t));
	}

	public Arc(Plane arcPlane, Point2D center, Point2D start, Point2D end)
		: base(arcPlane, center, Point2D.Distance(start, center))
	{
		_0023_003DzJ38LQ1OiX4gt(center, start, end);
	}

	public Arc(Plane arcPlane, Point3D center, double radius, Point3D start, Point3D end, bool flip)
		: base(arcPlane, center, radius)
	{
		angle = new Interval(0.0, Math.PI * 2.0);
		Project(start, out var t);
		Project(end, out var t2);
		if (Utility.AreEqual(t, Math.PI * 2.0, Math.PI * 2.0))
		{
			t = 0.0;
		}
		if (Utility.AreEqual(t2, 0.0, Math.PI * 2.0))
		{
			t2 = Math.PI * 2.0;
		}
		if (flip)
		{
			Utility.Swap(ref t, ref t2);
		}
		if (t > t2 || Math.Abs(t - t2) < 1E-12)
		{
			t2 += Math.PI * 2.0;
		}
		Domain = new Interval(t, t2);
	}

	public Arc(Plane arcPlane, Point2D first, Point2D second, Point2D third, bool flip)
		: base(arcPlane, first, second, third)
	{
		_0023_003DzJ38LQ1OiX4gt(-1.0 * base.Plane.Project(arcPlane.Origin), first, third);
		_0023_003DzIT64oKyducWs(arcPlane.PointAt(second), flip);
	}

	public Arc(Point3D first, Point3D second, Point3D third, bool flip)
		: base(first, second, third)
	{
		_0023_003DzJ38LQ1OiX4gt(Point3D.Origin, base.Plane.Project(first), base.Plane.Project(third));
		_0023_003DzIT64oKyducWs(second, flip);
	}

	protected Arc(Arc another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		angle = another.angle;
	}

	protected internal Arc(ArcSurrogate surrogate)
		: base(surrogate)
	{
		angle = surrogate.GetDomain();
	}

	internal Arc(GArc _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.Plane, _0023_003DzQwa1qM0_003D.Plane.Origin, _0023_003DzQwa1qM0_003D.Radius, _0023_003DzQwa1qM0_003D.Domain.t0, _0023_003DzQwa1qM0_003D.Domain.t1)
	{
	}

	protected Arc(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		angle = (Interval)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955066), typeof(Interval));
	}

	public override object Clone()
	{
		return new Arc(this);
	}

	public override object CloneWithTessellation()
	{
		return new Arc(this, RegenMode != regenType.RegenAndCompile);
	}

	private static void _0023_003Dz76BR52GUuE6s(double _0023_003Dzsu9_0024FLqqWoZkm14dgdZ0KW8_003D, ref double _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D)
	{
		if (_0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D < _0023_003Dzsu9_0024FLqqWoZkm14dgdZ0KW8_003D)
		{
			_0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D += Math.PI * 2.0;
		}
	}

	private void _0023_003DzIT64oKyducWs(Point3D _0023_003DzNniqUwGAVELg, bool _0023_003Dzbu8BV15Qqzan)
	{
		Project(_0023_003DzNniqUwGAVELg, out var t);
		if (Domain.Includes(t, testOpenInterval: false))
		{
			if (_0023_003Dzbu8BV15Qqzan)
			{
				_0023_003Dz46iWwIQ_003D();
			}
		}
		else if (!_0023_003Dzbu8BV15Qqzan)
		{
			_0023_003Dz46iWwIQ_003D();
		}
	}

	private void _0023_003Dz46iWwIQ_003D()
	{
		double t = Domain.t1;
		double _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D = Domain.t0;
		_0023_003Dz76BR52GUuE6s(t, ref _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D);
		_0023_003DzuvS5KTE_003D(this, new Interval(t, _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D));
	}

	private void _0023_003DzJ38LQ1OiX4gt(Point2D _0023_003DzbUvT9Pc_003D, Point2D _0023_003DzAqOpw0w_003D, Point2D _0023_003Dzk64JNOo_003D)
	{
		double num = Utility.ArcTanProblem(_0023_003DzAqOpw0w_003D.X - _0023_003DzbUvT9Pc_003D.X, _0023_003DzAqOpw0w_003D.Y - _0023_003DzbUvT9Pc_003D.Y);
		double _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D = Utility.ArcTanProblem(_0023_003Dzk64JNOo_003D.X - _0023_003DzbUvT9Pc_003D.X, _0023_003Dzk64JNOo_003D.Y - _0023_003DzbUvT9Pc_003D.Y);
		_0023_003Dz76BR52GUuE6s(num, ref _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D);
		_0023_003DzuvS5KTE_003D(this, new Interval(num, _0023_003DzzhVJ9DaUhOONBU9DcZmQZIo_003D));
	}

	private bool _0023_003DzuvS5KTE_003D(Point3D _0023_003DzshZYG54_003D, double _0023_003DzRpXgovo_003D, double _0023_003DzfSrrN4sXVX5o0WAWDg_003D_003D)
	{
		return _0023_003DzuvS5KTE_003D(new Circle(_0023_003DzshZYG54_003D, _0023_003DzRpXgovo_003D), new Interval(0.0, _0023_003DzfSrrN4sXVX5o0WAWDg_003D_003D));
	}

	private bool _0023_003DzuvS5KTE_003D(Circle _0023_003Dzw6jQxH4k7cf_0024, Interval _0023_003DzZMsr2cz1T3kPmxsY8ta9kK_0024Rehng)
	{
		base.Radius = _0023_003Dzw6jQxH4k7cf_0024.Radius;
		angle = _0023_003DzZMsr2cz1T3kPmxsY8ta9kK_0024Rehng;
		if (angle.IsDecreasing)
		{
			angle.Swap();
			Reverse();
		}
		if (angle.Length > Math.PI * 2.0)
		{
			angle.t1 = angle.t0 + Math.PI * 2.0;
		}
		return IsValid();
	}

	public override void Reverse()
	{
		base.Reverse();
		angle.Reverse();
		RegenMode = regenType.RegenAndCompile;
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (AngleInRadians <= 1E-12 || AngleInRadians > 6.283185307180586)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955053));
			return false;
		}
		return base.IsValid(log);
	}

	public override bool SubCurve(double t0, double t1, out ICurve sub)
	{
		bool flag = Math.Abs(Math.Abs(angle.Length) - Math.PI * 2.0) < 1E-12;
		if (!Circle._0023_003DzJUU5L0s5zlzq(flag, angle.t0, angle.t1, Math.PI * 2.0, ref t0, ref t1))
		{
			sub = null;
			return false;
		}
		if (flag && Math.Abs(Math.Abs(t1 - t0) - Math.PI * 2.0) < 1E-12)
		{
			sub = (Arc)Clone();
			return true;
		}
		sub = new Arc(base.Plane, base.Plane.Origin, base.Radius, t0, t1);
		((Entity)sub).CopyAttributes(this);
		return true;
	}

	public override bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		ClosestPointTo(startPt, out var t);
		ClosestPointTo(endPt, out var t2);
		return SubCurve(t, t2, out sub);
	}

	public override bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		if (t > angle.t0 && !Utility.AreEqual(t, angle.t0, Math.PI * 2.0) && t < angle.t1 && !Utility.AreEqual(t, angle.t1, Math.PI * 2.0))
		{
			lower = new Arc(base.Plane, (Point3D)base.Center.Clone(), base.Radius, angle.t0, t);
			upper = new Arc(base.Plane, (Point3D)base.Center.Clone(), base.Radius, t, angle.t1);
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	internal static void _0023_003DzP7Itlc0_003D(Entity _0023_003Dzs_0024uS8LA_003D, ref Interval _0023_003DzLeWJs_BkHX0G, Interval _0023_003DzL8JA6U0_003D)
	{
		if (_0023_003DzL8JA6U0_003D.IsIncreasing && _0023_003DzL8JA6U0_003D.Length < Math.PI * 2.0 + Utility._0023_003DzheSR8QM7q9ya)
		{
			if (_0023_003DzL8JA6U0_003D.Length < 1E-12)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955012));
			}
			_0023_003DzLeWJs_BkHX0G = _0023_003DzL8JA6U0_003D;
		}
		else
		{
			_0023_003DzLeWJs_BkHX0G = new Interval(_0023_003DzL8JA6U0_003D.Low, _0023_003DzL8JA6U0_003D.High + Math.PI * 2.0);
		}
		_0023_003Dzs_0024uS8LA_003D.RegenMode = regenType.RegenAndCompile;
	}

	public override double Length()
	{
		return Math.Abs(AngleInRadians * base.Radius);
	}

	public override void Regen(RegenParams data)
	{
		int num = Utility.NumberOfSegments(base.Radius, angle.Length, data.Deviation, data.Angle);
		_vertices = new Point3D[num + 1];
		for (int i = 0; i < num + 1; i++)
		{
			double t = angle.t0 + (double)i * angle.Length / (double)num;
			Point3D point3D = PointAt(t);
			Vector3D vector3D = TangentAt(t);
			_vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	internal new void _0023_003DzAWinFpBcJb6_3uUJ15BE5C0_003D(RegenParams _0023_003DzELu0Pss_003D, int _0023_003DzgyNPRm1lVYUG)
	{
		_vertices = new Point3D[_0023_003DzgyNPRm1lVYUG + 1];
		for (int i = 0; i < _0023_003DzgyNPRm1lVYUG + 1; i++)
		{
			double t = angle.t0 + (double)i * angle.Length / (double)_0023_003DzgyNPRm1lVYUG;
			Point3D point3D = PointAt(t);
			Vector3D vector3D = TangentAt(t);
			_vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
		}
	}

	internal new void _0023_003Dzci7aJXfjtY_00243OTtVfw_003D_003D(RegenParams _0023_003DzELu0Pss_003D, List<double> _0023_003DzHSO_00246A0_003D, double _0023_003Dz7pAiRvw_003D, double _0023_003DzqU35YqE_003D)
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

	public override Curve GetNurbsForm()
	{
		if (angle.IsTwoPI)
		{
			Curve nurbsForm = base.GetNurbsForm();
			nurbsForm.Rotate(angle.t0, base.Plane.AxisZ, base.Plane.Origin);
			nurbsForm.KnotVector.Offset(angle.t0);
			return nurbsForm;
		}
		double num = Domain.Length;
		double num3;
		int num2;
		if (num <= 1.5707963267958966)
		{
			num2 = 1;
			num3 = 0.5;
		}
		else if (num <= 3.141592653590793)
		{
			num2 = 2;
			num *= 0.5;
			num3 = 0.25;
		}
		else if (num <= 4.71238898038569)
		{
			num2 = 3;
			num /= 3.0;
			num3 = 1.0 / 6.0;
		}
		else
		{
			num2 = 4;
			num *= 0.25;
			num3 = 0.125;
		}
		int num4 = 2 * num2 + 1;
		double[] array = new double[num4 + 2 + 1];
		Point4D[] array2 = new Point4D[num4];
		double num5 = (array[0] = angle.t0);
		for (int i = 0; i < num2; i++)
		{
			array[2 * i + 1] = num5;
			array[2 * i + 2] = num5;
			array2[2 * i] = new Point4D(PointAt(num5));
			num5 += num3 * angle.Length;
			array2[2 * i + 1] = new Point4D(PointAt(num5));
			num5 += num3 * angle.Length;
		}
		num2 *= 2;
		array2[num2] = new Point4D(PointAt(num5));
		array[num2 + 1] = num5;
		array[num2 + 2] = num5;
		array[num2 + 3] = num5;
		double num6 = Math.Cos(0.5 * num);
		double num7 = num6 - 1.0;
		for (int j = 1; j < num2; j += 2)
		{
			array2[j].X += num7 * base.Plane.Origin.X;
			array2[j].Y += num7 * base.Plane.Origin.Y;
			array2[j].Z += num7 * base.Plane.Origin.Z;
			array2[j].W = num6;
		}
		Curve curve = new Curve(2, array, array2, checkKnotsAndCtrlPts: false);
		curve.CopyAttributes(this);
		return curve;
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		Transformation transformation = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = new _0023_003DzdPtvklPFzKqxMoTpEOXyeC1W53neVz2gTQ_003D_003D(0.0, 0.0, 0.0, base.Radius, Domain.t0, Domain.t1, transformation.Matrix, ColorMethod == colorMethodType.byEntity, LayerName, Color, _0023_003Dz_KjZG5vEM9v9: false);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1] { _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 };
	}

	public override Point3D[] GetPointsByLength(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		double num = Length() / length;
		int num2 = (int)Math.Ceiling(num);
		int num3 = (int)Math.Truncate(num);
		int num4 = ((num - (double)num3 < length * Utility._0023_003Dzjyaz_Vfaky9X) ? num3 : num2);
		if (num4 == 0)
		{
			return new Point3D[1] { PointAt(angle.Min) };
		}
		Point3D[] array = new Point3D[num4 + 1];
		for (int i = 0; i <= num4; i++)
		{
			array[i] = PointAt(angle.Min + (double)i * angle.Length / (double)num4);
		}
		return array;
	}

	public override void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		if (angle.IsTwoPI)
		{
			base.GetTightBBox(out boxMin, out boxMax);
			return;
		}
		double[] array = new double[3]
		{
			Utility.ArcTanProblem(base.Plane.AxisX.X, base.Plane.AxisY.X),
			Utility.ArcTanProblem(base.Plane.AxisX.Y, base.Plane.AxisY.Y),
			Utility.ArcTanProblem(base.Plane.AxisX.Z, base.Plane.AxisY.Z)
		};
		List<double> list = new List<double>();
		for (int i = 0; i < 3; i++)
		{
			if (Utility._0023_003DzHIeX7C3oyv3F(array[i], Domain, _0023_003DzQFI4Hrif1AaZ: true, out var _0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D))
			{
				list.AddRange(_0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D);
			}
		}
		list.Add(angle.t0);
		list.Add(angle.t1);
		list = list.Distinct().ToList();
		Point3D[] array2 = new Point3D[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			array2[j] = PointAt(list[j]);
		}
		Utility.ComputeBoundingBox(array2, out boxMin, out boxMax);
	}

	public override bool TrimBy(Point3D limit, bool flipSide)
	{
		ClosestPointTo(limit, out var t);
		return TrimAt(t, flipSide);
	}

	public override bool TrimAt(double t, bool flipSide)
	{
		if (t > angle.t0 && !Utility.AreEqual(t, angle.t0, angle.Length) && t < angle.t1 && !Utility.AreEqual(t, angle.t1, angle.Length))
		{
			if (flipSide)
			{
				_0023_003DzP7Itlc0_003D(this, ref angle, new Interval(t, angle.t1));
			}
			else
			{
				_0023_003DzP7Itlc0_003D(this, ref angle, new Interval(angle.t0, t));
			}
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public override bool ExtendAt(double t)
	{
		if (IsClosed)
		{
			return false;
		}
		if ((t < angle.t0 && !Utility.AreEqual(t, angle.t0, angle.Length)) || (t > angle.t1 && !Utility.AreEqual(t, angle.t1, angle.Length)))
		{
			Interval _0023_003DzJUOlPYhShISQ = angle;
			if (t > angle.t1)
			{
				Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
				if (t > Math.PI * 2.0 && t - angle.t0 > Math.PI * 2.0 + Utility._0023_003DzheSR8QM7q9ya)
				{
					t = angle.t0 + Math.PI * 2.0;
				}
				_0023_003DzP7Itlc0_003D(this, ref angle, new Interval(angle.t0, t));
			}
			else
			{
				Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
				if (angle.t1 - t > Math.PI * 2.0 + Utility._0023_003DzheSR8QM7q9ya)
				{
					t = angle.t1 - Math.PI * 2.0;
				}
				_0023_003DzP7Itlc0_003D(this, ref angle, new Interval(t, angle.t1));
			}
			Utility._0023_003Dz7iiwRWggF9n_(_0023_003DzJUOlPYhShISQ, ref angle);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public override bool ExtendBy(Point3D limit, bool curveEnd = true)
	{
		if (IsCircle)
		{
			return false;
		}
		base.Project(limit, out var t);
		Interval _0023_003DzJUOlPYhShISQ = angle;
		if (curveEnd)
		{
			Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
			_0023_003DzP7Itlc0_003D(this, ref angle, new Interval(angle.t0, t));
		}
		else
		{
			Utility._0023_003Dz6kYhc4pAp6ud(this, ref t);
			_0023_003DzP7Itlc0_003D(this, ref angle, new Interval(t, angle.t1));
		}
		Utility._0023_003Dz7iiwRWggF9n_(_0023_003DzJUOlPYhShISQ, ref angle);
		RegenMode = regenType.RegenAndCompile;
		return true;
	}

	public override bool Project(Point3D point, out double t)
	{
		double num = _0023_003DzAzVFPYFo2TLf(point);
		if (Math.Abs(Math.Abs(num) - Math.PI * 2.0) < Utility._0023_003DzxhnLabVjXjPg)
		{
			num = 0.0;
		}
		t = angle.t0 + num;
		if ((t < angle.t0 && !Utility.AreEqual(t, angle.t0, angle.Length)) || (t > angle.t1 && !Utility.AreEqual(t, angle.t1, angle.Length)))
		{
			double num2 = t + Math.PI;
			double num3 = t - Math.PI;
			if ((num2 > angle.t0 || Utility.AreEqual(num2, angle.t0, angle.Length)) && (num2 < angle.t1 || Utility.AreEqual(num2, angle.t1, angle.Length)))
			{
				t = num2;
				return true;
			}
			if ((num3 > angle.t0 || Utility.AreEqual(num3, angle.t0, angle.Length)) && (num3 < angle.t1 || Utility.AreEqual(num3, angle.t1, angle.Length)))
			{
				t = num3;
				return true;
			}
		}
		return true;
	}

	public override void ClosestPointTo(Point3D point, out double t)
	{
		double num = _0023_003DzAzVFPYFo2TLf(point);
		t = angle.t0 + num;
		if (t < angle.t0 || t > angle.t1)
		{
			if (Point3D.DistanceSquared(point, StartPoint) <= Point3D.DistanceSquared(point, EndPoint))
			{
				t = angle.t0;
			}
			else
			{
				t = angle.t1;
			}
			return;
		}
		double num2 = Point3D.DistanceSquared(point, PointAt(t));
		double num3 = Point3D.DistanceSquared(point, EndPoint);
		if (num3 < num2)
		{
			if (Point3D.DistanceSquared(point, StartPoint) <= num3)
			{
				t = angle.t0;
			}
			else
			{
				t = angle.t1;
			}
		}
		else if (Point3D.DistanceSquared(point, StartPoint) <= num2)
		{
			t = angle.t0;
		}
	}

	internal bool _0023_003Dzk2wgZ0wi2OG4(Point3D _0023_003DzMlCq3wk_003D, out double _0023_003DzNDQ_E88_003D)
	{
		double num = _0023_003DzAzVFPYFo2TLf(_0023_003DzMlCq3wk_003D);
		_0023_003DzNDQ_E88_003D = angle.t0 + num;
		if (((_0023_003DzNDQ_E88_003D < angle.t0 && !Utility.AreEqual(_0023_003DzNDQ_E88_003D, angle.t0, angle.Length)) || (_0023_003DzNDQ_E88_003D > angle.t1 && !Utility.AreEqual(_0023_003DzNDQ_E88_003D, angle.t1, angle.Length))) && _0023_003DzNDQ_E88_003D > (angle.t0 + Math.PI * 2.0 - angle.t1) / 2.0)
		{
			_0023_003DzNDQ_E88_003D -= Math.PI * 2.0;
			return true;
		}
		return true;
	}

	private double _0023_003DzAzVFPYFo2TLf(Point3D _0023_003DzMlCq3wk_003D)
	{
		base.Project(_0023_003DzMlCq3wk_003D, out var t);
		for (t -= angle.t0; t < 0.0; t += Math.PI * 2.0)
		{
		}
		while (t > Math.PI * 2.0 || Utility.AreEqual(t, Math.PI * 2.0, Math.PI * 2.0))
		{
			t -= Math.PI * 2.0;
		}
		return t;
	}

	internal bool _0023_003DzIp4nxx0dXuNdTQbtjP_BbwQ_003D(Point3D _0023_003DzMlCq3wk_003D, out double _0023_003DzNDQ_E88_003D)
	{
		double num = _0023_003DzAzVFPYFo2TLf(_0023_003DzMlCq3wk_003D);
		_0023_003DzNDQ_E88_003D = angle.t0 + num;
		return true;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnitsType = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955214) + angle.t0 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955169) + Utility.RadToDeg(angle.t0) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955182));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955163) + angle.t1 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955169) + Utility.RadToDeg(angle.t1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955182));
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new ArcSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955066), angle);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		if (IsClosed)
		{
			return base.EstimateBoundingBox(blocks, layers);
		}
		Point3D[] array = new Point3D[3];
		double length = angle.Length;
		array[0] = PointAt(angle.t0 + 0.0 * length / 2.0);
		array[1] = PointAt(angle.t0 + length / 2.0);
		array[2] = PointAt(angle.t0 + 2.0 * length / 2.0);
		return array;
	}

	public override Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
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
			return base.ExtrudeAsBrep(amount);
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
			return line.RevolveAsBrep(0.0, angle.Length, base.Plane.AxisZ, base.Center);
		}
		Curve nurbsForm = GetNurbsForm();
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = nurbsForm._0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		Point3D[] array = new Brep.Vertex[4];
		Point3D[] array2 = array;
		array2[0] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.StartPoint.X, _0023_003Dz6nnnQo75Qjsf.StartPoint.Y, _0023_003Dz6nnnQo75Qjsf.StartPoint.Z);
		array2[1] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.EndPoint.X, _0023_003Dz6nnnQo75Qjsf.EndPoint.Y, _0023_003Dz6nnnQo75Qjsf.EndPoint.Z);
		array2[2] = new Brep.Vertex(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
		array2[3] = new Brep.Vertex(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
		Brep.Edge[] edges = new Brep.Edge[4]
		{
			new Brep.Edge((ICurve)_0023_003Dz6nnnQo75Qjsf.Clone(), 0, 1),
			new Brep.Edge((ICurve)curve.Clone(), 2, 3),
			new Brep.Edge(new Line((Point3D)array2[0].Clone(), (Point3D)array2[2].Clone()), 0, 2),
			new Brep.Edge(new Line((Point3D)array2[1].Clone(), (Point3D)array2[3].Clone()), 1, 3)
		};
		Brep.OrientedEdge[] segments = new Brep.OrientedEdge[4]
		{
			new Brep.OrientedEdge(0),
			new Brep.OrientedEdge(3),
			new Brep.OrientedEdge(1, sense: false),
			new Brep.OrientedEdge(2, sense: false)
		};
		Brep.Face[] array3 = new Brep.Face[1];
		Surface surface = Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve);
		AnalyticSurf surface2 = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints);
		array3[0] = new Brep.Face(surface2, new Brep.Loop(segments));
		return new Brep(array2, edges, array3);
	}

	public override Region OffsetToRegion(double amount, bool sharp)
	{
		if (IsClosed)
		{
			return base.OffsetToRegion(amount, sharp);
		}
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
		Line line = new Line(curve2.EndPoint, curve.StartPoint);
		Line line2 = new Line(curve.EndPoint, curve2.StartPoint);
		return new Region(new CompositeCurve(new ICurve[4] { line, curve, line2, curve2 }, sortAndOrient: false), base.Plane, sortAndOrient: false);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2 = new _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D(new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D(new _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D(base.Plane.Origin.ToArray(), base.Radius, base.Plane.AxisX.ToArray(), base.Plane.AxisY.ToArray())), Domain.Min, Domain.Max, _0023_003DznRGKF2T2ZsN6Flrnxw_003D_003D: false);
		_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2._0023_003Dzx3pYiE0_003D = true;
		_0023_003DzYe_6EnQecc8d(_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2 };
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955881), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), base.Radius, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955826), Domain);
	}
}
