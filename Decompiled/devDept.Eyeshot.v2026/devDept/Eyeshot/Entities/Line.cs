using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Line : Entity, ICurve, ICloneable, IEvaluable, IMateable
{
	private int _edgeIndex = -1;

	private bool _fromBooleanIntersection;

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

	public Point3D MidPoint => Point3D.MidPoint(_vertices[0], _vertices[1]);

	public bool IsPoint => _vertices[0] == _vertices[1];

	public Vector3D Tangent => TangentAt(0.0);

	public Vector3D StartTangent => Tangent;

	public Vector3D EndTangent => Tangent;

	public Vector3D Direction => Vector3D.Subtract(_vertices[1], _vertices[0]);

	public Point3D StartPoint
	{
		get
		{
			return _vertices[0];
		}
		set
		{
			_vertices[0] = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Interval Domain => new Interval(0.0, Length());

	public Point3D EndPoint
	{
		get
		{
			return _vertices[1];
		}
		set
		{
			_vertices[1] = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool IsClosed => false;

	public Line(double x1, double y1, double x2, double y2)
		: this(new Point3D(x1, y1), new Point3D(x2, y2))
	{
	}

	public Line(Plane sketchPlane, double x1, double y1, double x2, double y2)
		: this(sketchPlane.PointAt(x1, y1), sketchPlane.PointAt(x2, y2))
	{
	}

	public Line(Plane sketchPlane, Point2D startPoint, Point2D endPoint)
		: this(sketchPlane.PointAt(startPoint), sketchPlane.PointAt(endPoint))
	{
	}

	public Line(double x1, double y1, double z1, double x2, double y2, double z2)
		: this(new Point3D(x1, y1, z1), new Point3D(x2, y2, z2))
	{
	}

	public Line(Point3D start, Point3D end)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[2] { start, end };
	}

	public Line(Segment2D seg)
		: this(new Point3D(seg.P0.X, seg.P0.Y), new Point3D(seg.P1.X, seg.P1.Y))
	{
	}

	public Line(Segment3D seg)
		: this(seg.P0, seg.P1)
	{
	}

	protected Line(Line another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = new Point3D[2];
		_vertices[0] = (Point3D)another._vertices[0].Clone();
		_vertices[1] = (Point3D)another._vertices[1].Clone();
	}

	protected internal Line(LineSurrogate surrogate)
		: this(surrogate.GetStartPoint(), surrogate.GetEndPoint())
	{
	}

	internal Line(GLine _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.StartPoint, _0023_003DzQwa1qM0_003D.EndPoint)
	{
	}

	protected Line(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
	}

	public override object Clone()
	{
		return new Line(this);
	}

	public override object CloneWithTessellation()
	{
		return new Line(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public double Length()
	{
		Point3D point3D = _vertices[0];
		Point3D point3D2 = _vertices[_vertices.Length - 1];
		if (point3D.Z == point3D2.Z)
		{
			if (point3D.Y == point3D2.Y)
			{
				return Math.Abs(point3D.X - point3D2.X);
			}
			if (point3D.X == point3D2.X)
			{
				return Math.Abs(point3D.Y - point3D2.Y);
			}
			return Point2D.Distance(point3D, point3D2);
		}
		return Point3D.Distance(point3D, point3D2);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956065) + StartPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956056) + EndPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971672) + Length().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public Region OffsetToRegion(double amount, bool sharp)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971656));
	}

	internal Region _0023_003DzFxZnHP2tiqx8sOob9Q_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzYNjcavt9guh2, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzalFofRO0Igsv)
	{
		ICurve curve = (ICurve)Clone();
		ICurve[] array = Offset(_0023_003DzYNjcavt9guh2, _0023_003Dzrgqz890sj_0024X9.AxisZ, _0023_003DzalFofRO0Igsv);
		ICurve curve2 = ((array != null) ? array[0] : null);
		if (_0023_003DzYNjcavt9guh2 > 0.0)
		{
			curve.Reverse();
		}
		else
		{
			curve2.Reverse();
		}
		Line line = new Line(curve2.EndPoint, curve.StartPoint);
		Line line2 = new Line(curve.EndPoint, curve2.StartPoint);
		return new Region(new CompositeCurve(new ICurve[4] { line, curve, line2, curve2 }, sortAndOrient: false), _0023_003Dzrgqz890sj_0024X9, sortAndOrient: false);
	}

	public Point3D[] GetPointsByLength(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		Point3D point3D = _vertices[0];
		Point3D point3D2 = _vertices[1];
		double num = Length() / length;
		int num2 = (int)Math.Ceiling(num);
		int num3 = (int)Math.Truncate(num);
		int num4 = ((num - (double)num3 < length * Utility._0023_003DzxhnLabVjXjPg) ? num3 : num2);
		if (num4 == 0)
		{
			return new Point3D[1] { (Point3D)point3D.Clone() };
		}
		Point3D[] array = new Point3D[num4 + 1];
		for (int i = 0; i <= num4; i++)
		{
			array[i] = new Point3D(point3D.X + (double)i * (point3D2.X - point3D.X) / (double)num4, point3D.Y + (double)i * (point3D2.Y - point3D.Y) / (double)num4, point3D.Z + (double)i * (point3D2.Z - point3D.Z) / (double)num4);
		}
		return array;
	}

	public Point3D[] GetPointsByLengthPerSegment(double length)
	{
		return GetPointsByLength(length);
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(_vertices, out boxMin, out boxMax);
	}

	public Curve GetNurbsForm()
	{
		double[] knotVector = ((!Utility.AreEqual(Domain.Low, Domain.High, 1.0)) ? new double[4] { Domain.Low, Domain.Low, Domain.High, Domain.High } : new double[4] { 0.0, 0.0, 1.0, 1.0 });
		Curve curve = new Curve(1, knotVector, new Point4D[2]
		{
			new Point4D(_vertices[0]),
			new Point4D(_vertices[1])
		}, checkKnotsAndCtrlPts: false);
		curve.CopyAttributes(this);
		return curve;
	}

	internal Surface[] _0023_003DzaUv3PxprKveEN3wn_g_003D_003D(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		Surface surface = ((ICurve)this).GetNurbsForm()._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, this);
		if (surface != null)
		{
			return new Surface[1] { surface };
		}
		return new Surface[0];
	}

	public bool SubCurve(double t0, double t1, out ICurve sub)
	{
		if (t0 > t1)
		{
			sub = null;
			return false;
		}
		sub = new Line(PointAt(t0), PointAt(t1));
		((Entity)sub).CopyAttributes(this);
		return true;
	}

	public bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		ClosestPointTo(startPt, out var t);
		ClosestPointTo(endPt, out var t2);
		bool result = SubCurve(t, t2, out sub);
		if (sub != null)
		{
			((Entity)sub).CopyAttributes(this);
		}
		return result;
	}

	public bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		if (t > Domain.Low && !Utility.AreEqual(t, Domain.Low, Domain.Length) && t < Domain.High && !Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			Point3D point3D = PointAt(t);
			lower = new Line(_vertices[0], point3D);
			upper = new Line((Point3D)point3D.Clone(), _vertices[1]);
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
		bool result = Utility._0023_003Dz01EVtoUdEn9B(this, points, out segments);
		ICurve[] array = segments;
		for (int i = 0; i < array.Length; i++)
		{
			((Entity)array[i]).CopyAttributes(this);
		}
		return result;
	}

	public bool TrimAt(double t, bool flipSide)
	{
		if (t > Domain.Low && !Utility.AreEqual(t, Domain.Low, Domain.Length) && t < Domain.High && !Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			if (!flipSide)
			{
				_vertices[1] = PointAt(t);
			}
			else
			{
				_vertices[0] = PointAt(t);
			}
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtendAt(double t)
	{
		if (t > Domain.High && !Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			_vertices[1] = PointAt(t);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		if (t < Domain.Low && !Utility.AreEqual(t, Domain.Low, Domain.Length))
		{
			_vertices[0] = PointAt(t);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtendBy(Point3D pt, bool curveEnd = true)
	{
		Project(pt, out var t);
		return ExtendAt(t);
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
			t = Domain.Low;
			return true;
		}
		if (Utility.AreEqual(length, curveLength, curveLength))
		{
			t = Domain.High;
			return true;
		}
		if (length < 0.0 || length > curveLength)
		{
			t = Domain.Low;
			return false;
		}
		t = length;
		return true;
	}

	public bool GetLengthFromParam(double t, out double length)
	{
		if (t < Domain.Low || t > Domain.High)
		{
			length = 0.0;
			return false;
		}
		length = t;
		return true;
	}

	public Point3D[] IntersectWith(ICurve C2, double maxGap = 0.0, bool computeParameters = true)
	{
		return _0023_003DzGKZuR_4q838u(C2, maxGap, computeParameters, 0.0);
	}

	internal Point3D[] _0023_003DzGKZuR_4q838u(ICurve _0023_003Dzn8t0_00249E_003D, double _0023_003DzX0qX_IwWxysi, bool _0023_003Dzr9Kx_zv09bH0, double _0023_003DzccAR5G0_003D)
	{
		List<Point3D> list = new List<Point3D>();
		GetApproximatedBoundingBox(out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		_0023_003Dzn8t0_00249E_003D.GetApproximatedBoundingBox(out var boxMin2, out var boxMax2);
		Size3D size3D2 = new Size3D(boxMin2, boxMax2);
		if (_0023_003DzccAR5G0_003D == 0.0)
		{
			_0023_003DzccAR5G0_003D = size3D.Diagonal + size3D2.Diagonal;
		}
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(_0023_003DzX0qX_IwWxysi, boxMin, boxMax);
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(_0023_003DzX0qX_IwWxysi, boxMin2, boxMax2);
		if (Utility.DoOverlapOrTouch(boxMin, boxMax, boxMin2, boxMax2))
		{
			if (Utility.IsLine(_0023_003Dzn8t0_00249E_003D))
			{
				if (_0023_003Dz3a74KJAFKP9OrQrJ3xojG00_003D(this, _0023_003Dzn8t0_00249E_003D, list, _0023_003DzX0qX_IwWxysi))
				{
					return list.ToArray();
				}
				Line line = new Line(_0023_003Dzn8t0_00249E_003D.StartPoint, _0023_003Dzn8t0_00249E_003D.EndPoint);
				Utility._0023_003DziWIBdhJJlTub._0023_003DzwbbgHmo_003D _0023_003DzwbbgHmo_003D = ((_0023_003DzX0qX_IwWxysi > 0.0) ? Utility._0023_003DziWIBdhJJlTub._0023_003DzL9woobs_003D(this, line, _0023_003DzX0qX_IwWxysi) : Utility._0023_003DziWIBdhJJlTub._0023_003DzL9woobs_003D(this, line, 1E-09 * _0023_003DzccAR5G0_003D));
				if ((object)_0023_003DzwbbgHmo_003D._0023_003DzQ7usAag_003D != null)
				{
					if (!_0023_003Dzr9Kx_zv09bH0)
					{
						list.Add(_0023_003DzwbbgHmo_003D._0023_003DzCRi06tFycJw_0024);
					}
					else
					{
						if (_0023_003Dzn8t0_00249E_003D.Domain.Low != line.Domain.Low || _0023_003Dzn8t0_00249E_003D.Domain.High != line.Domain.High)
						{
							_0023_003DzwbbgHmo_003D._0023_003Dz2LueQ4zIuh5i = _0023_003Dzn8t0_00249E_003D.Domain.Low + _0023_003Dzn8t0_00249E_003D.Domain.Length / line.Domain.Length * (_0023_003DzwbbgHmo_003D._0023_003Dz2LueQ4zIuh5i - line.Domain.Low);
						}
						list.Add(new InterPoint(_0023_003DzwbbgHmo_003D._0023_003DzCRi06tFycJw_0024.X, _0023_003DzwbbgHmo_003D._0023_003DzCRi06tFycJw_0024.Y, _0023_003DzwbbgHmo_003D._0023_003DzCRi06tFycJw_0024.Z, _0023_003DzwbbgHmo_003D._0023_003DzRgUiPi1yoiaQ, 0.0, _0023_003DzwbbgHmo_003D._0023_003Dz2LueQ4zIuh5i, 0.0));
					}
				}
				return list.ToArray();
			}
			if (_0023_003Dzn8t0_00249E_003D is Circle)
			{
				Utility._0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D = ((_0023_003DzX0qX_IwWxysi > 0.0) ? Utility._0023_003DztDh_5dSqxQPzO4_gIg_003D_003D._0023_003DzL9woobs_003D(this, (Circle)_0023_003Dzn8t0_00249E_003D, _0023_003DzX0qX_IwWxysi, 1E-12) : Utility._0023_003DztDh_5dSqxQPzO4_gIg_003D_003D._0023_003DzL9woobs_003D(this, (Circle)_0023_003Dzn8t0_00249E_003D, 1E-09 * _0023_003DzccAR5G0_003D, 1E-12));
				for (int i = 0; i < _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz7L3Iw6frIRXoyynokiNCmg4_003D; i++)
				{
					if (!_0023_003Dzr9Kx_zv09bH0)
					{
						list.Add(_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item1);
					}
					else
					{
						list.Add(new InterPoint(_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item1.X, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item1.Y, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[i].Item1.Z, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzqLMDDyVBo88_0024[i], 0.0, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzlcY317DiY_0024sJ[i], 0.0));
					}
				}
				return list.ToArray();
			}
			if (_0023_003Dzn8t0_00249E_003D is Ellipse)
			{
				if (Utility._0023_003Dzjkn37He1Dc0IA_0024_CNA_003D_003D(this, (Ellipse)_0023_003Dzn8t0_00249E_003D, _0023_003DzccAR5G0_003D, out var _0023_003Dz348XSZM_003D, out var _0023_003DzVxmwB6Y_003D))
				{
					if (!_0023_003Dzr9Kx_zv09bH0)
					{
						list.Add(_0023_003Dz348XSZM_003D);
						if (_0023_003DzVxmwB6Y_003D != null)
						{
							list.Add(_0023_003DzVxmwB6Y_003D);
						}
					}
					else
					{
						if (_0023_003Dz348XSZM_003D != null)
						{
							InterPoint item = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, _0023_003Dzn8t0_00249E_003D, _0023_003Dz348XSZM_003D);
							list.Add(item);
						}
						if (_0023_003DzVxmwB6Y_003D != null)
						{
							InterPoint item = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, _0023_003Dzn8t0_00249E_003D, _0023_003DzVxmwB6Y_003D);
							list.Add(item);
						}
					}
				}
				return list.ToArray();
			}
			if (_0023_003Dzn8t0_00249E_003D is LinearPath || _0023_003Dzn8t0_00249E_003D is CompositeCurve || _0023_003Dzn8t0_00249E_003D is Point)
			{
				Point3D[] array = ((!(_0023_003Dzn8t0_00249E_003D is LinearPath linearPath)) ? ((!(_0023_003Dzn8t0_00249E_003D is CompositeCurve compositeCurve)) ? _0023_003Dzn8t0_00249E_003D.IntersectWith(this, _0023_003DzX0qX_IwWxysi) : compositeCurve._0023_003DzGKZuR_4q838u(this, _0023_003DzccAR5G0_003D, _0023_003DzX0qX_IwWxysi, _0023_003Dzr9Kx_zv09bH0)) : linearPath._0023_003DzGKZuR_4q838u(this, _0023_003DzccAR5G0_003D, _0023_003DzX0qX_IwWxysi, _0023_003Dzr9Kx_zv09bH0));
				if (_0023_003Dzr9Kx_zv09bH0)
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
			if (_0023_003Dzn8t0_00249E_003D.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane) && IsInPlane(plane, Utility._0023_003DzheSR8QM7q9ya) && _0023_003DzX0qX_IwWxysi == 0.0)
			{
				return Utility.Intersection2D(this, _0023_003Dzn8t0_00249E_003D, plane);
			}
			return Utility.Intersection(this, _0023_003Dzn8t0_00249E_003D, _0023_003DzX0qX_IwWxysi, _0023_003Dzr9Kx_zv09bH0);
		}
		return list.ToArray();
	}

	internal static bool _0023_003Dz3a74KJAFKP9OrQrJ3xojG00_003D(ICurve _0023_003DzciI1ZbKMmHTX, ICurve _0023_003DzZ7F0G0CUj83f, List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, double _0023_003DzX0qX_IwWxysi)
	{
		bool result = false;
		if (Utility.IsLine(_0023_003DzciI1ZbKMmHTX) && Utility.IsLine(_0023_003DzZ7F0G0CUj83f))
		{
			Line line = new Line(_0023_003DzciI1ZbKMmHTX.StartPoint, _0023_003DzciI1ZbKMmHTX.EndPoint);
			Line line2 = new Line(_0023_003DzZ7F0G0CUj83f.StartPoint, _0023_003DzZ7F0G0CUj83f.EndPoint);
			if (AreCollinear(line, line2))
			{
				result = true;
				double num = Math.Min(line.Length(), line2.Length());
				double num2 = num * 1E-12;
				Point3D startPoint = _0023_003DzciI1ZbKMmHTX.StartPoint;
				Point3D endPoint = _0023_003DzciI1ZbKMmHTX.EndPoint;
				Point3D startPoint2 = _0023_003DzZ7F0G0CUj83f.StartPoint;
				Point3D endPoint2 = _0023_003DzZ7F0G0CUj83f.EndPoint;
				if (Point3D.Distance(startPoint, startPoint2) <= _0023_003DzX0qX_IwWxysi + num2 && !Vector3D.AreCoincident(_0023_003DzciI1ZbKMmHTX.StartTangent, _0023_003DzZ7F0G0CUj83f.StartTangent))
				{
					Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(startPoint.X, startPoint.Y, startPoint.Z, _0023_003DzciI1ZbKMmHTX.Domain.Low, 0.0, _0023_003DzZ7F0G0CUj83f.Domain.Low, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
				}
				else if (Point3D.Distance(startPoint, endPoint2) <= _0023_003DzX0qX_IwWxysi + num2 && Vector3D.AreCoincident(_0023_003DzciI1ZbKMmHTX.StartTangent, _0023_003DzZ7F0G0CUj83f.EndTangent))
				{
					Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(startPoint.X, startPoint.Y, startPoint.Z, _0023_003DzciI1ZbKMmHTX.Domain.Low, 0.0, _0023_003DzZ7F0G0CUj83f.Domain.High, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
				}
				else if (Point3D.Distance(endPoint, startPoint2) <= _0023_003DzX0qX_IwWxysi + num2 && Vector3D.AreCoincident(_0023_003DzciI1ZbKMmHTX.EndTangent, _0023_003DzZ7F0G0CUj83f.StartTangent))
				{
					Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(endPoint.X, endPoint.Y, endPoint.Z, _0023_003DzciI1ZbKMmHTX.Domain.High, 0.0, _0023_003DzZ7F0G0CUj83f.Domain.Low, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
				}
				else if (Point3D.Distance(endPoint, endPoint2) <= _0023_003DzX0qX_IwWxysi + num2 && !Vector3D.AreCoincident(_0023_003DzciI1ZbKMmHTX.EndTangent, _0023_003DzZ7F0G0CUj83f.EndTangent))
				{
					Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(endPoint.X, endPoint.Y, endPoint.Z, _0023_003DzciI1ZbKMmHTX.Domain.High, 0.0, _0023_003DzZ7F0G0CUj83f.Domain.High, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
				}
				else
				{
					_0023_003DzciI1ZbKMmHTX.Project(startPoint2, out var t);
					_0023_003DzciI1ZbKMmHTX.Project(endPoint2, out var t2);
					_0023_003DzZ7F0G0CUj83f.Project(startPoint, out var t3);
					_0023_003DzZ7F0G0CUj83f.Project(endPoint, out var t4);
					if (_0023_003DzciI1ZbKMmHTX.Domain.Includes(t, testOpenInterval: false))
					{
						Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(startPoint2.X, startPoint2.Y, startPoint2.Z, t, 0.0, _0023_003DzZ7F0G0CUj83f.Domain.Left, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
					}
					if (_0023_003DzciI1ZbKMmHTX.Domain.Includes(t2, testOpenInterval: false))
					{
						Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(endPoint2.X, endPoint2.Y, endPoint2.Z, t2, 0.0, _0023_003DzZ7F0G0CUj83f.Domain.Right, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
					}
					if (_0023_003DzZ7F0G0CUj83f.Domain.Includes(t3, testOpenInterval: false))
					{
						Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(startPoint.X, startPoint.Y, startPoint.Z, _0023_003DzciI1ZbKMmHTX.Domain.Left, 0.0, t3, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
					}
					if (_0023_003DzZ7F0G0CUj83f.Domain.Includes(t4, testOpenInterval: false))
					{
						Utility._0023_003DzbIDY9BOTPqfc(new InterPoint(endPoint.X, endPoint.Y, endPoint.Z, _0023_003DzciI1ZbKMmHTX.Domain.Right, 0.0, t4, 0.0), _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D, num);
					}
				}
			}
		}
		return result;
	}

	public double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond)
	{
		if (Utility.IsLine(curve))
		{
			Line _0023_003DzNyidyKE_003D = new Line(curve.StartPoint, curve.EndPoint);
			Utility._0023_003DziWIBdhJJlTub._0023_003DzwbbgHmo_003D _0023_003DzwbbgHmo_003D = Utility._0023_003DziWIBdhJJlTub._0023_003DzL9woobs_003D(this, _0023_003DzNyidyKE_003D, 1E-12);
			closestPointOnFirst = new Point3D[1] { _0023_003DzwbbgHmo_003D._0023_003DzCRi06tFycJw_0024 };
			closestPointOnSecond = new Point3D[1] { _0023_003DzwbbgHmo_003D._0023_003Dzlwi4wOuYZwyn };
			return _0023_003DzwbbgHmo_003D._0023_003DzOxKU6GM_003D;
		}
		if (curve.GetType() == typeof(Circle))
		{
			Circle _0023_003Dzw6jQxH4k7cf_0024 = (Circle)curve;
			Utility._0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D = Utility._0023_003DztDh_5dSqxQPzO4_gIg_003D_003D._0023_003DzL9woobs_003D(this, _0023_003Dzw6jQxH4k7cf_0024, 1E-12, 1E-12);
			closestPointOnFirst = _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzOK_0024S8ThjuNW5;
			closestPointOnSecond = _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzyUs6D9_SWs1i;
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

	public bool Project(Point3D point, out double t)
	{
		Segment3D segment3D = new Segment3D(_vertices[0], _vertices[1]);
		t = segment3D.Project(point);
		t = t * Domain.Length + Domain.Low;
		return true;
	}

	public void ClosestPointTo(Point3D point, out double t)
	{
		Segment3D segment3D = new Segment3D(_vertices[0], _vertices[1]);
		t = segment3D.ClosestPointTo(point);
		t = t * Domain.Length + Domain.Low;
	}

	public ICurve[] GetIndividualCurves()
	{
		return new ICurve[1] { this };
	}

	public bool IsPlanar(double tol, out Plane plane)
	{
		plane = Utility.FitPlane(_vertices);
		return true;
	}

	public bool IsInPlane(Plane plane, double tol)
	{
		return new Segment3D(_vertices[0], _vertices[1]).IsInPlane(plane, tol);
	}

	public bool IsLinear(double tol, out Segment3D line)
	{
		line = new Segment3D(_vertices[0], _vertices[1]);
		return true;
	}

	public Point3D PointAt(double t)
	{
		return new Segment3D(_vertices[0], _vertices[1]).PointAt(t / Domain.Length);
	}

	public Vector3D TangentAt(double t)
	{
		Vector3D direction = Direction;
		direction.Normalize();
		return direction;
	}

	public Vector3D NormalAt(double t)
	{
		return new Vector3D();
	}

	public ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp = false)
	{
		Line line = (Line)Clone();
		Vector3D vector3D = Vector3D.Cross(line.Tangent, planeNormal);
		vector3D.Normalize();
		Vector3D v = vector3D * amount;
		line.Translate(v);
		line.CopyAttributes(this);
		return new ICurve[1] { line };
	}

	public bool TrimBy(Point3D limit, bool flipSide)
	{
		ClosestPointTo(limit, out var t);
		return TrimAt(t, flipSide);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new LineSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
	}

	public void Reverse()
	{
		Array.Reverse(_vertices);
		RegenMode = regenType.RegenAndCompile;
	}

	public bool InPlane(out Plane plane, double tolerance)
	{
		Vector3D vector3D = Vector3D.Subtract(_vertices[1], _vertices[0]);
		bool flag = Math.Abs(vector3D.X) <= tolerance;
		bool flag2 = Math.Abs(vector3D.Y) <= tolerance;
		bool flag3 = Math.Abs(vector3D.Z) <= tolerance;
		bool result = true;
		Vector3D vector3D2 = Vector3D.AxisY;
		Vector3D vector3D3;
		if (flag3 && (!flag || !flag2))
		{
			vector3D3 = Vector3D.AxisX;
			vector3D2 = Vector3D.AxisY;
		}
		else if (flag && (!flag2 || !flag3))
		{
			vector3D3 = Vector3D.AxisY;
			vector3D2 = Vector3D.AxisZ;
		}
		else if (flag2 && (!flag3 || !flag))
		{
			vector3D3 = Vector3D.AxisZ;
			vector3D2 = Vector3D.AxisX;
		}
		else
		{
			vector3D3 = vector3D;
			vector3D3.Normalize();
			vector3D2.PerpendicularTo(vector3D3);
			if (flag && flag2 && flag3)
			{
				result = false;
				if (vector3D3.IsZero)
				{
					vector3D3 = Vector3D.AxisX;
					vector3D2 = Vector3D.AxisY;
				}
			}
		}
		plane = new Plane(StartPoint, vector3D3, vector3D2);
		return result;
	}

	public LinearPath ConvertToLinearPath(double deviation = 0.0, double angle = 0.0)
	{
		return _0023_003DztgI92lDISTaw0QRVK9fD0NM_003D();
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
		Vector3D obj = (Vector3D)amount.Clone();
		obj.Normalize();
		Vector3D closestMainAxis = Entity.GetClosestMainAxis(obj);
		double num = Math.Sign(new Plane(Point3D.Origin, closestMainAxis).DistanceTo(amount.AsPoint));
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Length = Math.Abs(amount.Length / Math.Cos(draftAngleInRadians));
		Line line = new Line(StartPoint, StartPoint + vector3D);
		line.Rotate((0.0 - draftAngleInRadians) * num, Direction, StartPoint);
		Surface[] array = ExtrudeAsSurface(line.Direction);
		Surface[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i]._0023_003DzrtnP79knlhMG(this);
		}
		return array;
	}

	public Brep ExtrudeAsBrep(Line line, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, line.Direction, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, new Vector3D(dx, dy, dz), _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
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
		Vector3D obj = (Vector3D)amount.Clone();
		obj.Normalize();
		Vector3D closestMainAxis = Entity.GetClosestMainAxis(obj);
		double num = Math.Sign(new Plane(Point3D.Origin, closestMainAxis).DistanceTo(amount.AsPoint));
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Length = Math.Abs(amount.Length / Math.Cos(draftAngleInRadians));
		Line line = new Line(StartPoint, StartPoint + vector3D);
		line.Rotate((0.0 - draftAngleInRadians) * num, Direction, StartPoint);
		Brep brep = ExtrudeAsBrep(line.Direction);
		brep._0023_003DzrtnP79knlhMG(this);
		return brep;
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return _0023_003DzaUv3PxprKveEN3wn_g_003D_003D(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return _0023_003DzaUv3PxprKveEN3wn_g_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis)
	{
		return _0023_003DzaUv3PxprKveEN3wn_g_003D_003D(startAngle, deltaAngle, axis.Direction, axis.StartPoint);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, startAngle, deltaAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, intervalAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Line axis, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Line axis, double tolerance = 0.0)
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

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return _vertices;
	}

	public static bool AreCollinear(Line l1, Line l2)
	{
		Segment3D s = new Segment3D(l1.StartPoint, l1.EndPoint);
		Segment3D s2 = new Segment3D(l2.StartPoint, l2.EndPoint);
		return Segment3D.AreCollinear(s, s2);
	}

	public Vector3D[] Evaluate(double u, int d)
	{
		Vector3D[] array = new Vector3D[d + 1];
		Point3D point3D = PointAt(u);
		array[0] = new Vector3D(point3D.X, point3D.Y, point3D.Z);
		if (d >= 1)
		{
			array[1] = Direction / Domain.Length;
		}
		for (int i = 2; i < d + 1; i++)
		{
			array[i] = new Vector3D();
		}
		return array;
	}

	public void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(_vertices, out boxMin, out boxMax);
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromICurve(this, parents);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
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
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D(StartPoint, EndPoint, ColorMethod == colorMethodType.byEntity, LayerName, Color, _0023_003Dz_KjZG5vEM9v9: false)
		};
	}

	internal LinearPath _0023_003DzERE6p7JEcywKj0t_00247Q_003D_003D()
	{
		LinearPath linearPath = new LinearPath(_vertices);
		linearPath.Regen(0.0);
		linearPath.CopyAttributes(this);
		linearPath.EdgeIndex = EdgeIndex;
		linearPath.FromBooleanIntersection = FromBooleanIntersection;
		return linearPath;
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		if (!Direction.IsZero)
		{
			Vector3D direction = Direction;
			direction.Normalize();
			Utility.DrawArrowOnView(data, direction, _vertices[1]);
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		DrawWire(data);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		CompileWire(data);
		RegenMode = regenType.NotNeeded;
	}

	internal override bool _0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		if (!_0023_003DzjZRgeJk_003D || _localOB == null)
		{
			Vector3D vector3D = new Vector3D(StartPoint, EndPoint);
			double length = vector3D.Length;
			vector3D.Normalize();
			_localOB = new OrientedBoundingRect(StartPoint, vector3D, Vector3D.Cross(Vector3D.AxisZ, vector3D), length, 0.0);
		}
		base._0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(_0023_003DzELu0Pss_003D, out _0023_003DzrdSL0CI_003D, out _0023_003DzD5Gs7jmmc9uK, out _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D: true);
		return true;
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzybTYvIZgcdcLyyLjJw_003D_003D _0023_003DzybTYvIZgcdcLyyLjJw_003D_003D2 = new _0023_003DzybTYvIZgcdcLyyLjJw_003D_003D(StartPoint.ToArray(), EndPoint.ToArray());
		_0023_003DzYe_6EnQecc8d(_0023_003DzybTYvIZgcdcLyyLjJw_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzybTYvIZgcdcLyyLjJw_003D_003D2 };
	}
}
