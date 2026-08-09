using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class LinearPath : Entity, ICurve, ICloneable, IMateable
{
	private sealed class _0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D
	{
		public LinearPath _0023_003DzopRx0_MBcTQs;

		public List<Point3D> _0023_003DzsSLPcz8_003D;

		internal void _0023_003DzKFozHbTsItYyMODIIA_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzHQ90e_g_003D)
		{
			_0023_003DzB8iS0QA_003D.DrawTriangles(_0023_003DzopRx0_MBcTQs.PatternGlobalWidthVertices.ToArray());
			_0023_003DzB8iS0QA_003D.DrawLines(_0023_003DzsSLPcz8_003D.ToArray());
		}
	}

	private int _edgeIndex = -1;

	private bool _fromBooleanIntersection;

	private EntityGraphicsData fatGraphicsData;

	private bool _isPlanarForGlobalWidth = true;

	internal List<Point3D> GlobalWidthVertices;

	internal List<Point3D> PatternGlobalWidthVertices;

	private double _globalWidth;

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

	public Point3D StartPoint => _vertices[0];

	public Interval Domain => new Interval(0.0, Length());

	public Point3D EndPoint => _vertices[_vertices.Length - 1];

	public bool IsClosed
	{
		get
		{
			if (localMin == null)
			{
				return StartPoint == EndPoint;
			}
			return Point3D.AreEqual(StartPoint, EndPoint, new Size3D(localMin, localMax).Diagonal);
		}
	}

	public bool IsPoint
	{
		get
		{
			Point3D point3D = _vertices[0];
			for (int i = 1; i < _vertices.Length; i++)
			{
				if (_vertices[i] != point3D)
				{
					return false;
				}
			}
			return true;
		}
	}

	public Vector3D StartTangent
	{
		get
		{
			Vector3D vector3D = Vector3D.Subtract(_vertices[1], _vertices[0]);
			vector3D.Normalize();
			return vector3D;
		}
	}

	public Vector3D EndTangent
	{
		get
		{
			int num = _vertices.Length;
			Vector3D vector3D = Vector3D.Subtract(_vertices[num - 1], _vertices[num - 2]);
			vector3D.Normalize();
			return vector3D;
		}
	}

	public double GlobalWidth
	{
		get
		{
			return _globalWidth;
		}
		set
		{
			if (value != _globalWidth)
			{
				RegenMode = regenType.RegenAndCompile;
			}
			else if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
			_globalWidth = value;
		}
	}

	public override colorMethodType LineTypeMethod
	{
		get
		{
			return base.LineTypeMethod;
		}
		set
		{
			base.LineTypeMethod = value;
			if (GlobalWidth > 0.0)
			{
				RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	public override string LineTypeName
	{
		get
		{
			return base.LineTypeName;
		}
		set
		{
			base.LineTypeName = value;
			if (GlobalWidth > 0.0)
			{
				RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	public LinearPath(int numVertices)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[numVertices];
	}

	public LinearPath(ICollection<Point3D> points)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[points.Count];
		points.CopyTo(_vertices, 0);
	}

	public LinearPath(params Point3D[] points)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[points.Length];
		points.CopyTo(_vertices, 0);
	}

	public LinearPath(Plane sketchPlane, params Point2D[] points)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[points.Length];
		for (int i = 0; i < points.Length; i++)
		{
			Point2D point2D = points[i];
			_vertices[i] = sketchPlane.PointAt(point2D.X, point2D.Y);
		}
	}

	public LinearPath(Plane sketchPlane, IList<Point2D> points)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[points.Count];
		for (int i = 0; i < points.Count; i++)
		{
			Point2D point2D = points[i];
			_vertices[i] = sketchPlane.PointAt(point2D.X, point2D.Y);
		}
	}

	public LinearPath(double width, double height)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[5];
		_vertices[0] = new Point3D(0.0, 0.0, 0.0);
		_vertices[1] = new Point3D(width, 0.0, 0.0);
		_vertices[2] = new Point3D(width, height, 0.0);
		_vertices[3] = new Point3D(0.0, height, 0.0);
		_vertices[4] = new Point3D(0.0, 0.0, 0.0);
	}

	public LinearPath(Point2D min, Point2D max)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[5];
		_vertices[0] = new Point3D(min.X, min.Y);
		_vertices[1] = new Point3D(max.X, min.Y);
		_vertices[2] = new Point3D(max.X, max.Y);
		_vertices[3] = new Point3D(min.X, max.Y);
		_vertices[4] = new Point3D(min.X, min.Y);
	}

	public LinearPath(Plane plane, Point2D min, Point2D max)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[5];
		_vertices[0] = plane.PointAt(min.X, min.Y);
		_vertices[1] = plane.PointAt(max.X, min.Y);
		_vertices[2] = plane.PointAt(max.X, max.Y);
		_vertices[3] = plane.PointAt(min.X, max.Y);
		_vertices[4] = plane.PointAt(min.X, min.Y);
	}

	public LinearPath(double x, double y, double width, double height)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[5];
		_vertices[0] = new Point3D(x, y, 0.0);
		_vertices[1] = new Point3D(x + width, y, 0.0);
		_vertices[2] = new Point3D(x + width, y + height, 0.0);
		_vertices[3] = new Point3D(x, y + height, 0.0);
		_vertices[4] = new Point3D(x, y, 0.0);
	}

	public LinearPath(Plane plane, double x, double y, double width, double height)
		: base(entityNatureType.Wire)
	{
		_vertices = new Point3D[5];
		_vertices[0] = plane.PointAt(x, y);
		_vertices[1] = plane.PointAt(x + width, y);
		_vertices[2] = plane.PointAt(x + width, y + height);
		_vertices[3] = plane.PointAt(x, y + height);
		_vertices[4] = plane.PointAt(x, y);
	}

	protected LinearPath(LinearPath another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = new Point3D[another._vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			_vertices[i] = (Point3D)another._vertices[i].Clone();
		}
		_globalWidth = another.GlobalWidth;
		if (!keepTessellation || !(another.GlobalWidth > 0.0))
		{
			return;
		}
		GlobalWidthVertices = new List<Point3D>(another.GlobalWidthVertices.Count);
		foreach (Point3D globalWidthVertex in another.GlobalWidthVertices)
		{
			GlobalWidthVertices.Add((Point3D)globalWidthVertex.Clone());
		}
	}

	protected internal LinearPath(LinearPathSurrogate surrogate)
		: this(surrogate.GetVertices())
	{
	}

	internal LinearPath(GLinearPath _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.Vertices)
	{
	}

	public LinearPath(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
		_globalWidth = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971829));
	}

	public override void TransformBy(Transformation xform)
	{
		GlobalWidth *= xform.ScaleFactorX;
		base.TransformBy(xform);
	}

	private protected override void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
	{
		_0023_003DzPlNF88On5JTLRSHV3sl4bGU_003D();
		base._0023_003Dzl_SRSHmkyuNv(_0023_003DzLS0sR0pzioXc);
	}

	public override object Clone()
	{
		return new LinearPath(this);
	}

	public override object CloneWithTessellation()
	{
		return new LinearPath(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public override void Regen(RegenParams data)
	{
		_0023_003DzPlNF88On5JTLRSHV3sl4bGU_003D();
		base.Regen(data);
	}

	private void _0023_003DzPlNF88On5JTLRSHV3sl4bGU_003D()
	{
		if (GlobalWidth > 0.0)
		{
			Plane _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D = _0023_003DzmOy4AUeTaJxqadf6zg_003D_003D();
			_0023_003Dz2KuGHDTZgCNXG06bVYShYXg_003D(_vertices, _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D, out GlobalWidthVertices);
		}
		else
		{
			GlobalWidthVertices = null;
		}
	}

	public void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(_vertices, out boxMin, out boxMax);
	}

	public double Length()
	{
		double num = 0.0;
		if (_vertices.Length != 0)
		{
			for (int i = 0; i < _vertices.Length - 1; i++)
			{
				num += Point3D.Distance(_vertices[i], _vertices[i + 1]);
			}
		}
		return num;
	}

	public Line[] ConvertToLines()
	{
		Line[] array = new Line[_vertices.Length - 1];
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			array[i] = new Line((Point3D)_vertices[i].Clone(), (Point3D)_vertices[i + 1].Clone());
			array[i].CopyAttributes(this);
		}
		return array;
	}

	public Region OffsetToRegion(double amount, bool sharp)
	{
		if (_vertices.Length > 2 && IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane))
		{
			ICurve[] array = Offset(amount, plane.AxisZ, sharp);
			ICurve curve = ((array != null) ? array[0] : null);
			ICurve curve2 = (ICurve)Clone();
			if (amount > 0.0)
			{
				curve2.Reverse();
			}
			else
			{
				curve.Reverse();
			}
			if (IsClosed)
			{
				return new Region(new ICurve[2] { curve2, curve }, plane);
			}
			Line line = new Line(curve.EndPoint, curve2.StartPoint);
			Line line2 = new Line(curve2.EndPoint, curve.StartPoint);
			Region region = new Region(new CompositeCurve(new ICurve[4] { line, curve2, line2, curve }, sortAndOrient: false), plane, sortAndOrient: false);
			region.CopyAttributes(this);
			return region;
		}
		return null;
	}

	public Point3D[] GetPointsByLength(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		double num = Domain.Length / length;
		int num2 = (int)Math.Ceiling(num);
		int num3 = (int)Math.Truncate(num);
		int num4 = ((num - (double)num3 < length * Utility._0023_003DzxhnLabVjXjPg) ? num3 : num2);
		double num5 = Domain.Length / (double)num4;
		Point3D[] array = new Point3D[num4 + 1];
		for (int i = 0; i <= num4; i++)
		{
			array[i] = PointAt(num5 * (double)i);
		}
		return array;
	}

	public Point3D[] GetPointsByLengthPerSegment(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		List<Point3D> list = new List<Point3D>(_vertices.Length);
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			Line line = new Line(_vertices[i], _vertices[i + 1]);
			list.AddRange(line.GetPointsByLength(length));
			if (i < _vertices.Length - 2)
			{
				list.RemoveAt(list.Count - 1);
			}
		}
		return list.ToArray();
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(_vertices, out boxMin, out boxMax);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962751) + (IsClosed ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964049) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964069)));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971815) + GlobalWidth);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963264) + Length().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (_vertices.Length == 0)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960514));
			return false;
		}
		return base.IsValid(log);
	}

	public void Reverse()
	{
		Array.Reverse(_vertices);
		RegenMode = regenType.RegenAndCompile;
	}

	internal bool _0023_003Dzv_fXkky_Y9Oe(double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, out ICurve _0023_003DzPCgfXmU_003D, double _0023_003Dzm0CYiiE_003D)
	{
		double num = Length();
		if (!Circle._0023_003DzJUU5L0s5zlzq(IsClosed, 0.0, num, num, ref _0023_003DzDSaZWik_003D, ref _0023_003DzsK_Xndk_003D))
		{
			_0023_003DzPCgfXmU_003D = null;
			return false;
		}
		Interval interval = new Interval(_0023_003DzDSaZWik_003D, _0023_003DzsK_Xndk_003D);
		List<Point3D> list = new List<Point3D>();
		double num2 = 0.0;
		bool flag = false;
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			Segment3D segment3D = new Segment3D(_vertices[i], _vertices[i + 1]);
			double length = segment3D.Length;
			double num3 = (interval.t0 - num2) / length;
			double num4 = (interval.t1 - num2) / length;
			if (!flag && num2 + length > interval.t0)
			{
				if (num2 + length >= interval.t1)
				{
					list.Add(segment3D.PointAt(num3));
					list.Add(segment3D.PointAt(num4));
					_0023_003DzPCgfXmU_003D = new LinearPath(list.ToArray());
					((Entity)_0023_003DzPCgfXmU_003D).CopyAttributes(this);
					return true;
				}
				if (Math.Abs(num3 - 1.0) > _0023_003Dzm0CYiiE_003D)
				{
					list.Add(segment3D.PointAt(num3));
				}
				flag = true;
			}
			else if (flag && num2 + length >= interval.t1)
			{
				if (num4 > _0023_003Dzm0CYiiE_003D)
				{
					list.Add(segment3D.PointAt(num4));
				}
				_0023_003DzPCgfXmU_003D = new LinearPath(list.ToArray());
				((Entity)_0023_003DzPCgfXmU_003D).CopyAttributes(this);
				return true;
			}
			if (flag)
			{
				list.Add(_vertices[i + 1]);
			}
			num2 += segment3D.Length;
		}
		_0023_003DzPCgfXmU_003D = null;
		return false;
	}

	public bool SubCurve(double t0, double t1, out ICurve sub)
	{
		return _0023_003Dzv_fXkky_Y9Oe(t0, t1, out sub, 0.0);
	}

	public Curve GetNurbsForm()
	{
		Point3D[] array = Utility.RemoveDuplicates(_vertices);
		Point4D[] array2 = new Point4D[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = new Point4D(array[i]);
		}
		double[] array3 = new double[array.Length + 2];
		double num = 0.0;
		for (int j = 0; j < array.Length - 1; j++)
		{
			array3[j + 1] = num;
			num += Point3D.Distance(array[j + 1], array[j]);
		}
		array3[array.Length] = num;
		array3[array.Length + 1] = num;
		Curve curve = new Curve(1, array3, array2, checkKnotsAndCtrlPts: false);
		curve.CopyAttributes(this);
		return curve;
	}

	public bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		ClosestPointTo(startPt, out var t);
		ClosestPointTo(endPt, out var t2);
		return SubCurve(t, t2, out sub);
	}

	public bool MergeWith(LinearPath other)
	{
		if (EndPoint != other.StartPoint)
		{
			return false;
		}
		int num = _vertices.Length;
		Point3D[] array = new Point3D[num + other._vertices.Length - 1];
		for (int i = 0; i < num; i++)
		{
			array[i] = (Point3D)_vertices[i].Clone();
		}
		for (int j = 1; j < other._vertices.Length; j++)
		{
			array[num - 1 + j] = (Point3D)other._vertices[j].Clone();
		}
		_vertices = array;
		RegenMode = regenType.RegenAndCompile;
		return true;
	}

	public bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		double _0023_003Dz0GIu0jtbXvUp;
		int num = _0023_003Dz1mW4kjcoTEf17njxVw_003D_003D(t, out _0023_003Dz0GIu0jtbXvUp);
		if (num != -1)
		{
			return _0023_003DzqFkWDscPxqrR(num, _0023_003Dz0GIu0jtbXvUp, out lower, out upper);
		}
		lower = null;
		upper = null;
		return false;
	}

	public bool SplitBy(Point3D pt, out ICurve lower, out ICurve upper)
	{
		double _0023_003Dz0GIu0jtbXvUp;
		int num = _0023_003DzbhsBVnMczjeA(pt, _0023_003Dz3P41GFRPL8iZ: true, out _0023_003Dz0GIu0jtbXvUp);
		if (num != -1)
		{
			return _0023_003DzqFkWDscPxqrR(num, _0023_003Dz0GIu0jtbXvUp, out lower, out upper);
		}
		lower = null;
		upper = null;
		return false;
	}

	private bool _0023_003DzqFkWDscPxqrR(int _0023_003Dzm9yP7rA_003D, double _0023_003Dz7UfRm3UI25id, out ICurve _0023_003Dz6V_0024QadA_003D, out ICurve _0023_003DzCskoEKg_003D)
	{
		Regen(0.0);
		double diagonal = base.BoxSize.Diagonal;
		int num = _vertices.Length;
		Segment3D segment3D = new Segment3D(_vertices[_0023_003Dzm9yP7rA_003D], _vertices[_0023_003Dzm9yP7rA_003D + 1]);
		Point3D point3D = segment3D.PointAt(_0023_003Dz7UfRm3UI25id / segment3D.Length);
		if (point3D.DistanceTo(segment3D.P0) < diagonal * 1E-06)
		{
			if (_0023_003Dzm9yP7rA_003D == 0)
			{
				_0023_003Dz6V_0024QadA_003D = null;
				_0023_003DzCskoEKg_003D = null;
				return false;
			}
			_0023_003Dz6V_0024QadA_003D = new LinearPath(_0023_003Dzm9yP7rA_003D + 1);
			_0023_003DzCskoEKg_003D = new LinearPath(num - _0023_003Dzm9yP7rA_003D);
			((Entity)_0023_003Dz6V_0024QadA_003D).CopyAttributes(this);
			((Entity)_0023_003DzCskoEKg_003D).CopyAttributes(this);
			for (int i = 0; i < _0023_003Dzm9yP7rA_003D; i++)
			{
				((LinearPath)_0023_003Dz6V_0024QadA_003D).Vertices[i] = (Point3D)_vertices[i].Clone();
			}
			((LinearPath)_0023_003Dz6V_0024QadA_003D).Vertices[_0023_003Dzm9yP7rA_003D] = point3D;
			((LinearPath)_0023_003DzCskoEKg_003D).Vertices[0] = (Point3D)point3D.Clone();
			for (int j = _0023_003Dzm9yP7rA_003D + 1; j < num; j++)
			{
				((LinearPath)_0023_003DzCskoEKg_003D).Vertices[j - _0023_003Dzm9yP7rA_003D] = (Point3D)_vertices[j].Clone();
			}
			return true;
		}
		if (point3D.DistanceTo(segment3D.P1) < diagonal * 1E-06)
		{
			if (_0023_003Dzm9yP7rA_003D == num - 2)
			{
				_0023_003Dz6V_0024QadA_003D = null;
				_0023_003DzCskoEKg_003D = null;
				return false;
			}
			_0023_003Dz6V_0024QadA_003D = new LinearPath(_0023_003Dzm9yP7rA_003D + 2);
			_0023_003DzCskoEKg_003D = new LinearPath(num - _0023_003Dzm9yP7rA_003D - 1);
			((Entity)_0023_003Dz6V_0024QadA_003D).CopyAttributes(this);
			((Entity)_0023_003DzCskoEKg_003D).CopyAttributes(this);
			for (int k = 0; k < _0023_003Dzm9yP7rA_003D + 1; k++)
			{
				((LinearPath)_0023_003Dz6V_0024QadA_003D).Vertices[k] = (Point3D)_vertices[k].Clone();
			}
			((LinearPath)_0023_003Dz6V_0024QadA_003D).Vertices[_0023_003Dzm9yP7rA_003D + 1] = point3D;
			((LinearPath)_0023_003DzCskoEKg_003D).Vertices[0] = (Point3D)point3D.Clone();
			for (int l = _0023_003Dzm9yP7rA_003D + 2; l < num; l++)
			{
				((LinearPath)_0023_003DzCskoEKg_003D).Vertices[l - _0023_003Dzm9yP7rA_003D - 1] = (Point3D)_vertices[l].Clone();
			}
			return true;
		}
		_0023_003Dz6V_0024QadA_003D = new LinearPath(_0023_003Dzm9yP7rA_003D + 2);
		_0023_003DzCskoEKg_003D = new LinearPath(num - _0023_003Dzm9yP7rA_003D);
		((Entity)_0023_003Dz6V_0024QadA_003D).CopyAttributes(this);
		((Entity)_0023_003DzCskoEKg_003D).CopyAttributes(this);
		for (int m = 0; m < _0023_003Dzm9yP7rA_003D + 1; m++)
		{
			((LinearPath)_0023_003Dz6V_0024QadA_003D).Vertices[m] = (Point3D)_vertices[m].Clone();
		}
		((LinearPath)_0023_003Dz6V_0024QadA_003D).Vertices[_0023_003Dzm9yP7rA_003D + 1] = point3D;
		((LinearPath)_0023_003DzCskoEKg_003D).Vertices[0] = (Point3D)point3D.Clone();
		for (int n = _0023_003Dzm9yP7rA_003D + 1; n < num; n++)
		{
			((LinearPath)_0023_003DzCskoEKg_003D).Vertices[n - _0023_003Dzm9yP7rA_003D] = (Point3D)_vertices[n].Clone();
		}
		return true;
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
		if (SplitAt(t, out var lower, out var upper))
		{
			if (flipSide)
			{
				_vertices = ((LinearPath)upper)._vertices;
				RegenMode = regenType.RegenAndCompile;
				return true;
			}
			_vertices = ((LinearPath)lower)._vertices;
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool TrimBy(Point3D pt, bool flipSide)
	{
		ClosestPointTo(pt, out var t);
		return TrimAt(t, flipSide);
	}

	public bool ExtendAt(double t)
	{
		if (IsClosed && Vector3D.AreCoincident(StartTangent, EndTangent))
		{
			return false;
		}
		Point3D point3D = PointAt(t);
		if (t > Domain.High && !Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			Array.Resize(ref _vertices, _vertices.Length + 1);
			_vertices[_vertices.Length - 1] = point3D;
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		if (t < Domain.Low && !Utility.AreEqual(t, Domain.Low, Domain.Length))
		{
			Array.Resize(ref _vertices, _vertices.Length + 1);
			_vertices[0] = point3D;
			for (int num = _vertices.Length - 2; num >= 0; num--)
			{
				_vertices[num + 1] = _vertices[num];
			}
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtendBy(Point3D pt, bool curveEnd = true)
	{
		if (IsClosed && Vector3D.AreCoincident(StartTangent, EndTangent))
		{
			return false;
		}
		Array.Resize(ref _vertices, _vertices.Length + 1);
		if (curveEnd)
		{
			Segment3D segment3D = new Segment3D(_vertices[_vertices.Length - 3], _vertices[_vertices.Length - 2]);
			_vertices[_vertices.Length - 1] = segment3D.PointAt(segment3D.Project(pt));
		}
		else
		{
			Segment3D segment3D2 = new Segment3D(_vertices[0], _vertices[1]);
			_vertices[0] = segment3D2.PointAt(segment3D2.Project(pt));
			for (int num = _vertices.Length - 2; num >= 0; num--)
			{
				_vertices[num + 1] = _vertices[num];
			}
		}
		RegenMode = regenType.RegenAndCompile;
		return true;
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
		double _0023_003DzccAR5G0_003D = Utility._0023_003Dz_0024lZxMnYFa_0024OQDkZzoQ_003D_003D(this, C2);
		return _0023_003DzGKZuR_4q838u(C2, _0023_003DzccAR5G0_003D, maxGap, computeParameters);
	}

	internal Point3D[] _0023_003DzGKZuR_4q838u(ICurve _0023_003Dzn8t0_00249E_003D, double _0023_003DzccAR5G0_003D, double _0023_003DzX0qX_IwWxysi, bool _0023_003Dzr9Kx_zv09bH0)
	{
		List<Point3D> list = new List<Point3D>();
		Line[] _0023_003Dz6iOJQfc_003D = new Line[_vertices.Length - 1];
		if (_0023_003Dzn8t0_00249E_003D is LinearPath linearPath)
		{
			for (int i = 0; i < linearPath.Vertices.Length - 1; i++)
			{
				Line _0023_003DzTWKA7Sl5zfW3hXWxgg_003D_003D = new Line(linearPath.Vertices[i], linearPath.Vertices[i + 1]);
				list.AddRange(_0023_003DzxlboeJT9MYrm(_0023_003Dzn8t0_00249E_003D, _0023_003DzTWKA7Sl5zfW3hXWxgg_003D_003D, ref _0023_003Dz6iOJQfc_003D, _0023_003DzccAR5G0_003D, _0023_003Dzr9Kx_zv09bH0, _0023_003DzX0qX_IwWxysi));
			}
		}
		else if (_0023_003Dzn8t0_00249E_003D is CompositeCurve compositeCurve)
		{
			ICurve[] array = compositeCurve._0023_003DzpoMoKemHyOl4();
			foreach (ICurve _0023_003DzTWKA7Sl5zfW3hXWxgg_003D_003D2 in array)
			{
				list.AddRange(_0023_003DzxlboeJT9MYrm(_0023_003Dzn8t0_00249E_003D, _0023_003DzTWKA7Sl5zfW3hXWxgg_003D_003D2, ref _0023_003Dz6iOJQfc_003D, _0023_003DzccAR5G0_003D, _0023_003Dzr9Kx_zv09bH0, _0023_003DzX0qX_IwWxysi));
			}
		}
		else
		{
			list.AddRange(_0023_003DzxlboeJT9MYrm(_0023_003Dzn8t0_00249E_003D, _0023_003Dzn8t0_00249E_003D, ref _0023_003Dz6iOJQfc_003D, _0023_003DzccAR5G0_003D, _0023_003Dzr9Kx_zv09bH0, _0023_003DzX0qX_IwWxysi));
		}
		return list.ToArray();
	}

	private Point3D[] _0023_003DzxlboeJT9MYrm(ICurve _0023_003DzlceoNLYyvbUi, ICurve _0023_003DzTWKA7Sl5zfW3hXWxgg_003D_003D, ref Line[] _0023_003Dz6iOJQfc_003D, double _0023_003DzccAR5G0_003D, bool _0023_003Dzr9Kx_zv09bH0, double _0023_003DzX0qX_IwWxysi)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			if (_0023_003Dz6iOJQfc_003D[i] == null)
			{
				_0023_003Dz6iOJQfc_003D[i] = new Line(_vertices[i], _vertices[i + 1]);
			}
			Point3D[] array = _0023_003Dz6iOJQfc_003D[i]._0023_003DzGKZuR_4q838u(_0023_003DzTWKA7Sl5zfW3hXWxgg_003D_003D, _0023_003DzX0qX_IwWxysi, _0023_003Dzr9Kx_zv09bH0, _0023_003DzccAR5G0_003D);
			if (array == null)
			{
				continue;
			}
			Point3D[] array2 = array;
			foreach (Point3D point3D in array2)
			{
				if (Utility._0023_003DzbIDY9BOTPqfc(point3D, list, _0023_003DzccAR5G0_003D) && _0023_003Dzr9Kx_zv09bH0)
				{
					ClosestPointTo(point3D, out var t);
					((InterPoint)point3D).u = t;
					if (_0023_003DzlceoNLYyvbUi is LinearPath || _0023_003DzlceoNLYyvbUi is CompositeCurve)
					{
						_0023_003DzlceoNLYyvbUi.ClosestPointTo(point3D, out var t2);
						((InterPoint)point3D).s = t2;
					}
				}
			}
		}
		return list.ToArray();
	}

	public bool IsLinear(double tolerance, out Segment3D line)
	{
		int num = _vertices.Length;
		line = null;
		if (num == 2)
		{
			return true;
		}
		if (num < 2 || IsClosed)
		{
			return false;
		}
		if (tolerance <= 0.0)
		{
			tolerance = 1E-12;
		}
		double num2 = double.MinValue;
		Segment3D segment3D = null;
		for (int i = 0; i < num - 1; i++)
		{
			Segment3D segment3D2 = new Segment3D(_vertices[i], _vertices[i + 1]);
			double lengthSquared = segment3D2.LengthSquared;
			if (lengthSquared > num2)
			{
				segment3D = segment3D2;
				num2 = lengthSquared;
			}
		}
		bool flag = false;
		if (segment3D != null)
		{
			if (segment3D.IsPoint)
			{
				return false;
			}
			flag = true;
			Point3D[] vertices = Vertices;
			foreach (Point3D point3D in vertices)
			{
				double t = segment3D.Project(point3D);
				if (point3D.DistanceTo(segment3D.PointAt(t)) > tolerance)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			line = segment3D;
		}
		return flag;
	}

	public Point3D PointAt(double t)
	{
		double num = 0.0;
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			Segment3D segment3D = new Segment3D(_vertices[i], _vertices[i + 1]);
			double length = segment3D.Length;
			if (num + length >= t)
			{
				return segment3D.PointAt((t - num) / length);
			}
			if (i == _vertices.Length - 2)
			{
				return segment3D.PointAt((t - num) / length);
			}
			num += length;
		}
		return _vertices[0];
	}

	public Vector3D TangentAt(double t)
	{
		double num = 0.0;
		double length = Domain.Length;
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			Segment3D segment3D = new Segment3D(_vertices[i], _vertices[i + 1]);
			double length2 = segment3D.Length;
			if (num + length2 > t || Utility.AreEqual(num + length2, t, length))
			{
				Vector3D vector3D = Vector3D.Subtract(segment3D.P1, segment3D.P0);
				if (vector3D.Normalize())
				{
					return vector3D;
				}
				return null;
			}
			num += length2;
		}
		return null;
	}

	public Vector3D NormalAt(double t)
	{
		return new Vector3D();
	}

	private double _0023_003DzZFjJ92OzYORzZR1l6A_003D_003D(out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D)
	{
		if (base.BoxMax == null || base.BoxMin == null)
		{
			Utility.ComputeBoundingBox(_vertices, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		}
		else
		{
			_0023_003Dz8dK2uhU_003D = localMax;
			_0023_003DzF7v9r2A_003D = localMin;
		}
		return new Size3D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D).Diagonal * Utility._0023_003DzxhnLabVjXjPg;
	}

	public ICurve[] Inflate(double amount, double tol)
	{
		return Inflate(amount, null, tol);
	}

	public ICurve[] Inflate(double amount, Vector3D planeNormal, double tol)
	{
		Point3D _0023_003DzF7v9r2A_003D;
		Point3D _0023_003Dz8dK2uhU_003D;
		double tol2 = _0023_003DzZFjJ92OzYORzZR1l6A_003D_003D(out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		if (!IsPlanar(tol2, out var plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971805));
		}
		if (planeNormal != null)
		{
			plane = new Plane((Point3D)StartPoint.Clone(), planeNormal);
		}
		Align3D align3D = null;
		int num = Vertices.Length;
		Point3D[] array = Vertices;
		if (!Vector3D.AreParallel(plane.AxisZ, Vector3D.AxisZ))
		{
			align3D = new Align3D(plane, Plane.XY);
			array = new Point3D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = align3D * Vertices[i];
			}
		}
		_0023_003DzF7v9r2A_003D.X -= amount;
		_0023_003DzF7v9r2A_003D.Y -= amount;
		_0023_003Dz8dK2uhU_003D.X += amount;
		_0023_003Dz8dK2uhU_003D.Y += amount;
		IntegerGrid integerGrid = new IntegerGrid(524288, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list = new List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>();
		for (int j = 0; j < num; j++)
		{
			Point3D point3D = array[j];
			integerGrid.ScaleToGrid(point3D.X, point3D.Y, out long gridX, out long gridY);
			_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D item = new _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(gridX, gridY);
			list.Add(item);
		}
		double _0023_003DzO1AkaTYvv61l = integerGrid._0023_003DzO1AkaTYvv61l;
		_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u obj = new _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u(2.0, tol * _0023_003DzO1AkaTYvv61l);
		obj._0023_003DzaPQ7dk0_003D(list, (_0023_003Dz5nKwufsJUZoRBmnCJySV3Co_003D)1, (_0023_003DzSeuDV6qEG_t7CCQHDy_pEY8_003D)4);
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dz1erSizk_003D = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>();
		obj._0023_003Dz_IsqsVA_003D(ref _0023_003Dz1erSizk_003D, amount * _0023_003DzO1AkaTYvv61l);
		if (align3D != null)
		{
			align3D.Invert();
		}
		ICurve[] array2 = new ICurve[_0023_003Dz1erSizk_003D.Count];
		for (int k = 0; k < _0023_003Dz1erSizk_003D.Count; k++)
		{
			List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list2 = _0023_003Dz1erSizk_003D[k];
			List<Point3D> list3 = new List<Point3D>();
			if (align3D != null)
			{
				foreach (_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D item3 in list2)
				{
					integerGrid.ScaleToWorld(item3._0023_003Dzyk2fsPo_003D, item3._0023_003DzvXOLtKg_003D, out var x, out var y);
					Point3D point3D2 = new Point3D(x, y);
					list3.Add(align3D * point3D2);
				}
			}
			else
			{
				foreach (_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D item4 in list2)
				{
					integerGrid.ScaleToWorld(item4._0023_003Dzyk2fsPo_003D, item4._0023_003DzvXOLtKg_003D, out var x2, out var y2);
					Point3D item2 = new Point3D(x2, y2);
					list3.Add(item2);
				}
			}
			list3.Add(list3[0]);
			array2[k] = new LinearPath(list3);
		}
		return array2;
	}

	public Mesh Inflate(double rX, double rY, double angleLimit, double smoothingAngle, bool fillCaps = true)
	{
		Ellipse ellipse = new Ellipse(Plane.XZ, rX, rY);
		Point3D _0023_003DzF7v9r2A_003D;
		Point3D _0023_003Dz8dK2uhU_003D;
		double tol = _0023_003DzZFjJ92OzYORzZR1l6A_003D_003D(out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		if (!IsPlanar(tol, out var plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971805));
		}
		LinearPath linearPath = (LinearPath)Clone();
		Align3D align3D = null;
		if (!Vector3D.AreCoincident(plane.AxisZ, Vector3D.AxisZ))
		{
			align3D = new Align3D(plane, Plane.XY);
			linearPath.TransformBy(align3D);
		}
		if (!Plane.XZ.Equals(ellipse.Plane))
		{
			Align3D xform = new Align3D(ellipse.Plane, Plane.XZ);
			ellipse = (Ellipse)ellipse.Clone();
			ellipse.TransformBy(xform);
		}
		ellipse.Regen(0.0);
		int num = linearPath.Vertices.Length;
		if (IsClosed)
		{
			num--;
		}
		Point3D[] array = new Point3D[num * ellipse.Vertices.Length];
		int num2 = 0;
		Point3D[] array2 = linearPath.Vertices;
		if (!IsClosed)
		{
			array2 = new Point3D[linearPath.Vertices.Length + 1];
			Array.Copy(linearPath.Vertices, array2, array2.Length - 1);
			array2[^1] = (Point3D)array2[0].Clone();
		}
		for (int i = 0; i < num; i++)
		{
			int num3 = i % array2.Length;
			int num4 = (i + 1) % array2.Length;
			int num5 = (i + 2) % array2.Length;
			if (num5 < num3)
			{
				num5++;
			}
			Vector3D vector3D = new Vector3D(array2[num3], array2[num4]);
			Vector3D vector3D2 = new Vector3D(array2[num4], array2[num5]);
			vector3D.Normalize();
			vector3D2.Normalize();
			double num6 = ((Vector2D.PerpDotProduct(vector3D, vector3D2) > 0.0) ? ((Math.PI - Vector2D.AngleBetween(vector3D2, vector3D)) / 2.0) : ((Math.PI + Vector2D.AngleBetween(vector3D2, vector3D)) / 2.0));
			double angleInXY = vector3D2.AngleInXY;
			double sx = ((Math.Abs(Math.PI - Math.Abs(num6)) < angleLimit || Math.Abs(num6) < angleLimit) ? 1.0 : (1.0 / Math.Sin(num6)));
			Transformation transformation = new Translation(array2[i + 1].AsVector);
			if (IsClosed || i < num - 2)
			{
				transformation = transformation * new Rotation(angleInXY + num6, Vector3D.AxisZ) * new Scaling(sx, 1.0);
			}
			else
			{
				Vector3D vector3D3 = null;
				Vector3D vector3D4 = null;
				Point3D point3D = null;
				if (i == num - 1)
				{
					vector3D3 = array2[^1].AsVector;
					vector3D4 = new Vector3D(array2[^1], array2[1]);
					point3D = array2[^1];
				}
				else
				{
					vector3D3 = array2[^2].AsVector;
					vector3D4 = new Vector3D(array2[^3], array2[^2]);
					point3D = array2[^2];
				}
				new Translation(vector3D3);
				Vector3D vector3D5 = (Vector3D)ellipse.Plane.AxisZ.Clone();
				vector3D5.Normalize();
				vector3D4.Normalize();
				Vector3D rotAxis;
				double angleInDegrees;
				if (Vector3D.AreOpposite(vector3D5, vector3D4))
				{
					rotAxis = Vector3D.AxisZ;
					angleInDegrees = 180.0;
				}
				else
				{
					Utility.GetRotationAxisAndAngle(vector3D5, vector3D4, out rotAxis, out angleInDegrees);
				}
				transformation = new Rotation(Utility.DegToRad(0.0 - angleInDegrees), rotAxis, point3D) * transformation;
			}
			int num7 = 0;
			while (num7 < ellipse.Vertices.Length)
			{
				array[num2] = (Point3D)ellipse.Vertices[num7].Clone();
				array[num2].TransformBy(transformation);
				num7++;
				num2++;
			}
		}
		if (!IsClosed && fillCaps)
		{
			Array.Resize(ref array, array.Length + 2);
			array[^2] = (Point3D)linearPath.EndPoint.Clone();
			array[^1] = (Point3D)linearPath.StartPoint.Clone();
		}
		IndexTriangle[] triangles = _0023_003DzzQc4WA4SyUUOZzlgSw_003D_003D(num, ellipse.Vertices.Length, fillCaps);
		Mesh mesh = new Mesh(array, triangles);
		mesh.SmoothingAngle = smoothingAngle;
		if (align3D != null)
		{
			align3D.Invert();
			mesh.TransformBy(align3D);
		}
		return mesh;
	}

	private IndexTriangle[] _0023_003DzzQc4WA4SyUUOZzlgSw_003D_003D(int _0023_003DzO_0024xvpvo_003D, int _0023_003DzmVsXTy4_003D, bool _0023_003DzX_0024cbI0kDqM5e)
	{
		bool flag = !IsClosed;
		bool flag2 = flag && _0023_003DzX_0024cbI0kDqM5e;
		int num = (flag ? (_0023_003DzO_0024xvpvo_003D - 1) : _0023_003DzO_0024xvpvo_003D) * (_0023_003DzmVsXTy4_003D - 1) * 2;
		if (flag2)
		{
			num += 2 * _0023_003DzmVsXTy4_003D;
		}
		IndexTriangle[] array = new IndexTriangle[num];
		int num2 = 0;
		for (int i = 0; i < _0023_003DzO_0024xvpvo_003D; i++)
		{
			if (!flag || i != _0023_003DzO_0024xvpvo_003D - 2)
			{
				int num3 = 0;
				while (num3 < _0023_003DzmVsXTy4_003D - 1)
				{
					int num4 = num3 + i * _0023_003DzmVsXTy4_003D;
					int v = num4 + 1;
					int num5 = num3 + (i + 1) % _0023_003DzO_0024xvpvo_003D * _0023_003DzmVsXTy4_003D;
					int num6 = num5 + 1;
					array[num2] = new SmoothTriangle(num4, v, num6);
					array[num2 + 1] = new SmoothTriangle(num4, num6, num5);
					num3++;
					num2 += 2;
				}
			}
		}
		if (flag2)
		{
			int num7 = _0023_003DzO_0024xvpvo_003D * _0023_003DzmVsXTy4_003D;
			int num8 = _0023_003DzO_0024xvpvo_003D - 2;
			int[] array2 = new int[2];
			int num9 = 0;
			while (num9 < 2)
			{
				int num10 = 0;
				while (num10 < _0023_003DzmVsXTy4_003D)
				{
					array2[num9] = num10 + num8 * _0023_003DzmVsXTy4_003D;
					array2[(num9 + 1) % 2] = (num10 + 1) % _0023_003DzmVsXTy4_003D + num8 * _0023_003DzmVsXTy4_003D;
					array[num2] = new SmoothTriangle(array2[0], array2[1], num7);
					num10++;
					num2++;
				}
				num9++;
				num7++;
				num8++;
			}
		}
		return array;
	}

	public ICurve[] Offset(double amount)
	{
		return Offset(amount, null, sharp: false);
	}

	public ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp)
	{
		ICurve[] array = new CompositeCurve(GetIndividualCurves()).Offset(amount, planeNormal, sharp);
		if (array == null)
		{
			return Array.Empty<ICurve>();
		}
		for (int i = 0; i < array.Length; i++)
		{
			ICurve curve = array[i];
			bool flag = true;
			ICurve[] individualCurves = curve.GetIndividualCurves();
			for (int j = 0; j < individualCurves.Length; j++)
			{
				if (!(individualCurves[j] is Line))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				array[i] = array[i].ConvertToLinearPath(0.0, 0.0);
			}
		}
		return array;
	}

	private double _0023_003DzcWsuvoQfLK3L()
	{
		if (localMin == null)
		{
			Utility.ComputeBoundingBox(EstimateBoundingBox(null, null), out localMin, out localMax);
		}
		return base.BoxSize.Diagonal * Utility._0023_003DzxhnLabVjXjPg;
	}

	public ICurve[] QuickOffset(double amount, Plane pln)
	{
		return QuickOffset(amount, pln, cornerType.Miter, 0.0, 2.0);
	}

	public ICurve[] QuickOffset(double amount, Plane pln, cornerType ct)
	{
		double tol = _0023_003DzR86yw02LkTxN();
		return QuickOffset(amount, pln, ct, tol, 2.0);
	}

	private double _0023_003DzR86yw02LkTxN()
	{
		if (localMin == null)
		{
			UpdateBoundingBox(null);
		}
		return base.BoxSize.Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
	}

	public ICurve[] QuickOffset(double amount, Plane pln, cornerType ct, double tol, double miterLimit)
	{
		if (Vertices.Length == 2)
		{
			return new Line(_vertices[0], _vertices[1]).Offset(amount, pln.AxisZ);
		}
		if (!IsClosed)
		{
			return Offset(amount, pln.AxisZ, sharp: true);
		}
		int num = _vertices.Length;
		Point3D[] array = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			Point2D point2D = pln.Project(_vertices[i]);
			array[i] = new Point3D(point2D.X, point2D.Y);
		}
		LinearPath linearPath = new LinearPath(array);
		Region region = new Region(linearPath, Plane.XY, true);
		double num2 = amount;
		if (linearPath.IsClosed && Utility.PolygonArea(linearPath.Vertices) < 0.0)
		{
			num2 *= -1.0;
		}
		IntegerGrid _0023_003DzOSo8vaE_003D;
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list = region._0023_003DzeMYhs5Z_0024EcJ2(num2, ct, miterLimit, tol, out _0023_003DzOSo8vaE_003D);
		int count = list.Count;
		ICurve[] array2 = new ICurve[count];
		for (int j = 0; j < count; j++)
		{
			List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list2 = list[j];
			int count2 = list2.Count;
			Point3D[] array3 = new Point3D[count2 + 1];
			for (int k = 0; k < count2; k++)
			{
				_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2 = list2[k];
				_0023_003DzOSo8vaE_003D.ScaleToWorld((int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003Dzyk2fsPo_003D, (int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003DzvXOLtKg_003D, out var x, out var y);
				array3[k] = pln.PointAt(x, y);
			}
			array3[count2] = (Point3D)array3[0].Clone();
			LinearPath linearPath2 = new LinearPath(array3);
			if (Math.Sign(_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC27._0023_003Dz0B52BHY_003D(list2)) != Math.Sign(Utility.PolygonArea(((LinearPath)region.ContourList[0]).Vertices)))
			{
				linearPath2.Reverse();
			}
			array2[j] = linearPath2;
		}
		return array2;
	}

	public ICurve[] Pocket(double amount, Plane pln)
	{
		return Pocket(amount, pln, cornerType.Miter, 0.0, 2.0);
	}

	public ICurve[] Pocket(double amount, Plane pln, cornerType ct)
	{
		double tol = _0023_003DzR86yw02LkTxN();
		return Pocket(amount, pln, ct, tol, 2.0);
	}

	public ICurve[] Pocket(double amount, Plane pln, cornerType ct, double tol, double miterLimit)
	{
		if (ct == cornerType.Round && IsPlanar(tol, out var plane))
		{
			return Region.Pocket(this, amount, plane.AxisZ, useSharpConnection: false);
		}
		List<ICurve> list = new List<ICurve>();
		if (amount <= 0.0)
		{
			return null;
		}
		int num = -1;
		while (true)
		{
			ICurve[] array = QuickOffset(amount * (double)num, pln, ct, tol, miterLimit);
			num--;
			if (array == null || array.Length == 0)
			{
				break;
			}
			ICurve[] array2 = array;
			foreach (ICurve item in array2)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	public double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond)
	{
		double num = double.MaxValue;
		closestPointOnFirst = null;
		closestPointOnSecond = null;
		if (Utility.IsLine(curve))
		{
			Line _0023_003DzNyidyKE_003D = new Line(curve.StartPoint, curve.EndPoint);
			for (int i = 0; (double)i < Length(); i++)
			{
				ICurve curve2 = GetIndividualCurves()[i];
				Utility._0023_003DziWIBdhJJlTub._0023_003DzwbbgHmo_003D _0023_003DzwbbgHmo_003D = Utility._0023_003DziWIBdhJJlTub._0023_003DzL9woobs_003D(new Line(curve2.StartPoint, curve2.EndPoint), _0023_003DzNyidyKE_003D, 1E-12);
				if (_0023_003DzwbbgHmo_003D._0023_003DzOxKU6GM_003D < num)
				{
					num = _0023_003DzwbbgHmo_003D._0023_003DzOxKU6GM_003D;
					closestPointOnFirst = new Point3D[1] { _0023_003DzwbbgHmo_003D._0023_003DzCRi06tFycJw_0024 };
					closestPointOnSecond = new Point3D[1] { _0023_003DzwbbgHmo_003D._0023_003Dzlwi4wOuYZwyn };
				}
			}
			return num;
		}
		if (curve is Circle _0023_003Dzw6jQxH4k7cf_0024)
		{
			for (int j = 0; (double)j < Length(); j++)
			{
				ICurve curve3 = GetIndividualCurves()[j];
				Utility._0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D = Utility._0023_003DztDh_5dSqxQPzO4_gIg_003D_003D._0023_003DzL9woobs_003D(new Line(curve3.StartPoint, curve3.EndPoint), _0023_003Dzw6jQxH4k7cf_0024, 1E-12, 1E-12);
				if (_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzOxKU6GM_003D < num)
				{
					num = _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzOxKU6GM_003D;
					closestPointOnFirst = _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzOK_0024S8ThjuNW5;
					closestPointOnSecond = _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D._0023_003DzyUs6D9_SWs1i;
				}
			}
			return num;
		}
		if (curve is CompositeCurve)
		{
			ICurve[] individualCurves = curve.GetIndividualCurves();
			for (int k = 0; k < individualCurves.Length; k++)
			{
				Curve[] array = individualCurves[k].GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
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
		double _0023_003Dz0GIu0jtbXvUp;
		int num = _0023_003DzbhsBVnMczjeA(point, _0023_003Dz3P41GFRPL8iZ: false, out _0023_003Dz0GIu0jtbXvUp);
		t = 0.0;
		if (num == -1)
		{
			Segment3D segment3D = new Segment3D(_vertices[0], _vertices[1]);
			double num2 = segment3D.Project(point);
			bool flag = num2 < 0.0;
			Segment3D segment3D2 = new Segment3D(_vertices[_vertices.Length - 2], _vertices[_vertices.Length - 1]);
			double num3 = segment3D2.Project(point);
			bool flag2 = num3 > 1.0;
			if (flag && flag2)
			{
				if (Point3D.DistanceSquared(point, segment3D.PointAt(num2)) <= Point3D.DistanceSquared(point, segment3D2.PointAt(num3)))
				{
					t = num2 * segment3D.Length;
					return true;
				}
				t = Length() + (num3 - 1.0) * segment3D2.Length;
				return true;
			}
			if (flag)
			{
				t = num2 * segment3D.Length;
				return true;
			}
			if (flag2)
			{
				t = Length() + (num3 - 1.0) * segment3D2.Length;
				return true;
			}
			return false;
		}
		double num4 = 0.0;
		for (int i = 0; i < num; i++)
		{
			Segment3D segment3D3 = new Segment3D(_vertices[i], _vertices[i + 1]);
			num4 += segment3D3.Length;
		}
		num4 += _0023_003Dz0GIu0jtbXvUp;
		t = num4;
		return true;
	}

	public void ClosestPointTo(Point3D point, out double t)
	{
		double _0023_003Dz0GIu0jtbXvUp;
		int num = _0023_003DzbhsBVnMczjeA(point, _0023_003Dz3P41GFRPL8iZ: true, out _0023_003Dz0GIu0jtbXvUp);
		t = 0.0;
		if (num != -1)
		{
			double num2 = 0.0;
			for (int i = 0; i < num; i++)
			{
				Segment3D segment3D = new Segment3D(_vertices[i], _vertices[i + 1]);
				num2 += segment3D.Length;
			}
			num2 += _0023_003Dz0GIu0jtbXvUp;
			t = num2;
		}
	}

	private int _0023_003DzbhsBVnMczjeA(Point3D _0023_003DzlY77YgY_003D, bool _0023_003Dz3P41GFRPL8iZ, out double _0023_003Dz0GIu0jtbXvUp)
	{
		int result = -1;
		_0023_003Dz0GIu0jtbXvUp = 0.0;
		double num = double.MaxValue;
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			Segment3D segment3D = new Segment3D(_vertices[i], _vertices[i + 1]);
			double num2 = segment3D.Project(_0023_003DzlY77YgY_003D);
			if (_0023_003Dz3P41GFRPL8iZ)
			{
				if (num2 < 0.0)
				{
					num2 = 0.0;
				}
				else if (num2 > 1.0)
				{
					num2 = 1.0;
				}
			}
			if ((num2 > 0.0 || Utility.AreEqual(num2, 0.0, 1.0)) && (num2 < 1.0 || Utility.AreEqual(num2, 1.0, 1.0)))
			{
				double num3 = Point3D.DistanceSquared(segment3D.PointAt(num2), _0023_003DzlY77YgY_003D);
				if (num3 < num)
				{
					num = num3;
					result = i;
					_0023_003Dz0GIu0jtbXvUp = num2 * segment3D.Length;
				}
			}
		}
		return result;
	}

	private int _0023_003Dz1mW4kjcoTEf17njxVw_003D_003D(double _0023_003DzNDQ_E88_003D, out double _0023_003Dz0GIu0jtbXvUp)
	{
		int result = -1;
		_0023_003Dz0GIu0jtbXvUp = 0.0;
		double num = 0.0;
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			double length = new Segment3D(_vertices[i], _vertices[i + 1]).Length;
			double num2 = num;
			double num3 = num + length;
			if ((_0023_003DzNDQ_E88_003D > num2 || Utility.AreEqual(_0023_003DzNDQ_E88_003D, num2, length)) && (_0023_003DzNDQ_E88_003D < num3 || Utility.AreEqual(_0023_003DzNDQ_E88_003D, num3, length)))
			{
				result = i;
				_0023_003Dz0GIu0jtbXvUp = _0023_003DzNDQ_E88_003D - num2;
			}
			num += length;
		}
		return result;
	}

	public ICurve[] GetIndividualCurves()
	{
		ICurve[] array = new ICurve[_vertices.Length - 1];
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			array[i] = new Line(_vertices[i], _vertices[i + 1]);
		}
		return array;
	}

	public ICurve[] SplitAtDiscontinuities()
	{
		List<ICurve> list = new List<ICurve>();
		Point3D point3D = (Point3D)_vertices[0].Clone();
		for (int i = 1; i < _vertices.Length - 1; i++)
		{
			Vector3D vector3D = new Vector3D(point3D, _vertices[i]);
			vector3D.Normalize();
			Vector3D vector3D2 = new Vector3D(point3D, _vertices[i + 1]);
			vector3D2.Normalize();
			if (!Vector3D.AreCoincident(vector3D2, vector3D, 1E-06))
			{
				list.Add(new Line(point3D, _vertices[i]));
				point3D = (Point3D)_vertices[i].Clone();
			}
		}
		list.Add(new Line(point3D, _vertices[_vertices.Length - 1]));
		foreach (Entity item in list)
		{
			item.CopyAttributes(item);
		}
		return list.ToArray();
	}

	public bool IsPlanar(double tol, out Plane plane)
	{
		plane = null;
		Plane plane2 = Utility.FitPlane(_vertices);
		bool num = IsInPlane(plane2, tol);
		if (num)
		{
			if (!IsClosed)
			{
				plane = plane2;
				return num;
			}
			if (Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(Vertices, plane2))
			{
				plane2.Flip();
			}
			plane = plane2;
		}
		return num;
	}

	public bool IsInPlane(Plane plane, double tol)
	{
		bool result = IsValid();
		Point3D[] vertices = _vertices;
		foreach (Point3D point in vertices)
		{
			if (Math.Abs(plane.DistanceTo(point)) > tol)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public static LinearPath CreateHelix(double radius, double pitch, double turns, bool reverseTwist, double deviation)
	{
		if (radius < Utility._0023_003DzheSR8QM7q9ya || pitch < Utility._0023_003DzheSR8QM7q9ya || turns < Utility._0023_003DzheSR8QM7q9ya || deviation < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971518));
		}
		int num = Utility.NumberOfSegments(radius, Math.PI * 2.0, deviation);
		double num2 = (double)num * turns;
		int num3 = (int)Math.Floor(num2);
		double num4 = Math.PI * 2.0 / (double)num;
		double num5 = (num2 - (double)num3) * num4;
		Point3D[] array = new Point3D[(num5 > 0.0) ? (num3 + 2) : (num3 + 1)];
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = pitch / (double)num;
		double num9 = 1.0;
		if (reverseTwist)
		{
			num9 = -1.0;
		}
		int num10 = num;
		double[] array2 = new double[num10];
		double[] array3 = new double[num10];
		for (int i = 0; i < num; i++)
		{
			array2[i] = radius * Math.Cos(num9 * num6);
			array3[i] = radius * Math.Sin(num9 * num6);
			num6 += num4;
		}
		int num11 = ((num5 > 0.0) ? (array.Length - 1) : array.Length);
		for (int j = 0; j < num11; j++)
		{
			array[j] = new Point3D(array2[j % num10], array3[j % num10], num7);
			num7 += num8;
		}
		if (num5 > 0.0)
		{
			num6 = num4 * num2;
			num7 = num8 * num2;
			array[^1] = new Point3D(radius * Math.Cos(num9 * num6), radius * Math.Sin(num9 * num6), num7);
		}
		return new LinearPath(array);
	}

	public static LinearPath CreateHelix(double radius, double angle, double height, double deviation, bool reverseTwist)
	{
		double num = Math.PI * 2.0 * radius * Math.Tan(angle);
		return CreateHelix(radius, num, height / num, reverseTwist, deviation);
	}

	private Region[] _0023_003DzZxdDHjqtS52igxLIaQ_003D_003D(double _0023_003DztIrx_ybgyvsO, double _0023_003Dzetc0sjwdrddceszzig_003D_003D, bool _0023_003DzEXLcE10_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out ICurve[] _0023_003DzTj1oJWREOpXS)
	{
		if (_0023_003Dzetc0sjwdrddceszzig_003D_003D >= _0023_003DztIrx_ybgyvsO)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971503));
		}
		if (!IsPlanar(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971440));
		}
		if (Math.Abs(_0023_003DztIrx_ybgyvsO) <= Utility._0023_003DzheSR8QM7q9ya && Math.Abs(_0023_003DztIrx_ybgyvsO) >= Math.PI * 2.0 - Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971636));
		}
		ICurve[] individualCurves = GetIndividualCurves();
		CompositeCurve compositeCurve = new CompositeCurve();
		compositeCurve.CurveList.Add(individualCurves[0]);
		for (int i = 0; i < individualCurves.Length - 1; i++)
		{
			double num = Utility._0023_003Dz9Nw_0024YI_v5jW6812R4UknSZnBGZ67((Line)individualCurves[i], (Line)individualCurves[i + 1], plane);
			if (num == -1.0)
			{
				_0023_003DzTj1oJWREOpXS = null;
				return null;
			}
			if (num + _0023_003DzuMKQhOieejyEvhtVOw_003D_003D < _0023_003DztIrx_ybgyvsO)
			{
				throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971629), i, i + 1, num));
			}
			Curve.Fillet(individualCurves[i], individualCurves[i + 1], _0023_003DztIrx_ybgyvsO, flip1: false, flip2: false, trim1: true, trim2: true, out var fillet);
			if (fillet != null)
			{
				if (fillet.StartPoint.Equals(individualCurves[i].StartPoint))
				{
					compositeCurve.CurveList.RemoveAt(compositeCurve.CurveList.Count - 1);
				}
				compositeCurve.CurveList.Add(fillet);
				if (!fillet.EndPoint.Equals(individualCurves[i + 1].EndPoint))
				{
					compositeCurve.CurveList.Add(individualCurves[i + 1]);
				}
				continue;
			}
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971527), i, i + 1));
		}
		if (IsClosed)
		{
			Curve.Fillet(individualCurves[^1], individualCurves[0], _0023_003DztIrx_ybgyvsO, flip1: false, flip2: false, trim1: true, trim2: true, out var fillet2);
			if (fillet2 != null)
			{
				if (fillet2.StartPoint.Equals(individualCurves[^1].StartPoint))
				{
					compositeCurve.CurveList.RemoveAt(compositeCurve.CurveList.Count - 1);
				}
				if (fillet2.EndPoint.Equals(individualCurves[0].EndPoint))
				{
					compositeCurve.CurveList.RemoveAt(0);
				}
				compositeCurve.CurveList.Add(fillet2);
			}
		}
		Region[] array = new Region[compositeCurve.CurveList.Count];
		for (int j = 0; j < compositeCurve.CurveList.Count; j++)
		{
			if (compositeCurve.CurveList[j] is Line line)
			{
				array[j] = line._0023_003DzFxZnHP2tiqx8sOob9Q_003D_003D(plane, _0023_003DzEXLcE10_003D ? _0023_003Dzetc0sjwdrddceszzig_003D_003D : (0.0 - _0023_003Dzetc0sjwdrddceszzig_003D_003D), _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzalFofRO0Igsv: true);
			}
			else if (compositeCurve.CurveList[j] is Arc arc && Vector3D.AreOpposite(arc.Plane.AxisZ, plane.AxisZ))
			{
				arc.Reverse();
				array[j] = arc.OffsetToRegion((!_0023_003DzEXLcE10_003D) ? _0023_003Dzetc0sjwdrddceszzig_003D_003D : (0.0 - _0023_003Dzetc0sjwdrddceszzig_003D_003D), sharp: true);
			}
			else
			{
				array[j] = compositeCurve.CurveList[j].OffsetToRegion(_0023_003DzEXLcE10_003D ? _0023_003Dzetc0sjwdrddceszzig_003D_003D : (0.0 - _0023_003Dzetc0sjwdrddceszzig_003D_003D), sharp: true);
			}
		}
		compositeCurve.SortAndOrient();
		_0023_003DzTj1oJWREOpXS = compositeCurve.CurveList.ToArray();
		return array;
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
		if (!IsPlanar(tolerance, out var plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964222));
		}
		bool flag = Vector3D.AreParallel(obj, plane.AxisZ);
		double offsetDistance = Entity.GetOffsetDistance(obj, amount, draftAngleInRadians);
		ICurve[] individualCurves = GetIndividualCurves();
		ICurve[] array2;
		if (flag)
		{
			ICurve[] array = Offset(offsetDistance, amount, sharp: true);
			array2 = ((array != null) ? array[0] : null).GetIndividualCurves();
		}
		else
		{
			array2 = new ICurve[individualCurves.Length];
			for (int i = 0; i < individualCurves.Length; i++)
			{
				ICurve[] array3 = array2;
				int num = i;
				ICurve[] array4 = individualCurves[i].Offset(offsetDistance, amount, sharp: true);
				array3[num] = ((array4 != null) ? array4[0] : null);
			}
		}
		Surface[] array5 = new Surface[individualCurves.Length];
		for (int j = 0; j < individualCurves.Length; j++)
		{
			Entity entity = (Entity)array2[j].Clone();
			entity.Translate(amount);
			Surface surface = Surface.Ruled(individualCurves[j], (ICurve)entity);
			surface.ReverseU();
			array5[j] = surface;
		}
		return array5.ToArray();
	}

	public Brep ExtrudeAsBrep(Line line, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, line.Direction, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(Interval amount, double bendRadius, double thickness, bool reverse = false, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		ICurve[] _0023_003DzTj1oJWREOpXS;
		Region[] array = _0023_003DzZxdDHjqtS52igxLIaQ_003D_003D(bendRadius, thickness, reverse, tolerance, out _0023_003DzTj1oJWREOpXS);
		Brep brep = array[0].ExtrudeAsBrep(amount, 0.0, tolerance);
		List<Brep> list = new List<Brep>();
		list.Add(brep);
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		for (int i = 1; i < _0023_003DzTj1oJWREOpXS.Length; i++)
		{
			Plane plane = new Plane(_0023_003DzTj1oJWREOpXS[i].StartPoint, _0023_003DzTj1oJWREOpXS[i].StartTangent);
			num = brep.GetPlanarFaceIndex(plane, _0023_003DzTj1oJWREOpXS[i].StartPoint);
			Brep brep2 = array[i].ExtrudeAsBrep(amount, 0.0, tolerance);
			num2 = brep2.GetPlanarFaceIndex(plane, _0023_003DzTj1oJWREOpXS[i].StartPoint);
			if (i == _0023_003DzTj1oJWREOpXS.Length - 1 && IsClosed)
			{
				plane = new Plane(_0023_003DzTj1oJWREOpXS[i].EndPoint, _0023_003DzTj1oJWREOpXS[i].EndTangent);
				num3 = brep.GetPlanarFaceIndex(plane, _0023_003DzTj1oJWREOpXS[i].EndPoint);
				num4 = brep2.GetPlanarFaceIndex(plane, _0023_003DzTj1oJWREOpXS[i].EndPoint);
			}
			try
			{
				brep._0023_003DzBvKljzDhzeqN(new int[2] { num, num3 }, brep2, new int[2] { num2, num4 }, new int[1] { -1 }, _0023_003Dz7Fxltek9kn7U: false);
			}
			catch (Exception)
			{
				list.Add(brep2);
			}
		}
		return brep;
	}

	public Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, new Vector3D(dx, dy, dz), _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
	{
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
		if (!IsPlanar(tolerance, out var plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964222));
		}
		if (!Vector3D.AreParallel(obj, plane.AxisZ))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964190));
		}
		double offsetDistance = Entity.GetOffsetDistance(obj, amount, draftAngleInRadians);
		ICurve[] array = Offset(offsetDistance, amount, sharp: true);
		ICurve obj2 = ((array != null) ? array[0] : null);
		((Entity)obj2).Translate(amount);
		ICurve[] individualCurves = GetIndividualCurves();
		ICurve[] individualCurves2 = obj2.GetIndividualCurves();
		int num = individualCurves.Length;
		Point3D[] array2;
		Brep.Edge[] array3;
		Brep.Face[] array4;
		Brep.OrientedEdge[][] array5;
		TabulatedSurf[] array6;
		if (IsClosed)
		{
			array2 = new Point3D[num * 2];
			array3 = new Brep.Edge[num * 3];
			array4 = new Brep.Face[num];
			array5 = new Brep.OrientedEdge[num][];
			array6 = new TabulatedSurf[num];
		}
		else
		{
			array2 = new Point3D[num * 2 + 2];
			array3 = new Brep.Edge[num * 3 + 1];
			array5 = new Brep.OrientedEdge[num][];
			array6 = new TabulatedSurf[num];
			array4 = new Brep.Face[num];
		}
		int num2 = array2.Length / 2;
		for (int i = 0; i < num; i++)
		{
			array2[i] = new Brep.Vertex(individualCurves[i].StartPoint.X, individualCurves[i].StartPoint.Y, individualCurves[i].StartPoint.Z);
			array2[num2 + i] = new Brep.Vertex(individualCurves2[i].StartPoint.X, individualCurves2[i].StartPoint.Y, individualCurves2[i].StartPoint.Z);
			if (!IsClosed && i == num - 1)
			{
				array2[i + 1] = new Brep.Vertex(individualCurves[i].EndPoint.X, individualCurves[i].EndPoint.Y, individualCurves[i].EndPoint.Z);
				array2[num2 + i + 1] = new Brep.Vertex(individualCurves2[i].EndPoint.X, individualCurves2[i].EndPoint.Y, individualCurves2[i].EndPoint.Z);
			}
			int num3 = i + 1;
			if (IsClosed)
			{
				num3 = (i + 1) % num2;
			}
			array3[i] = new Brep.Edge((ICurve)individualCurves[i].Clone(), i, num3);
			array3[num + i] = new Brep.Edge((ICurve)individualCurves2[i].Clone(), num2 + i, num2 + num3);
			array3[num * 2 + i] = new Brep.Edge(new Line((Point3D)array2[i].Clone(), (Point3D)array2[num2 + i].Clone()), i, num2 + i);
			if (!IsClosed && i == num - 1)
			{
				array3[num * 2 + num3] = new Brep.Edge(new Line((Point3D)array2[num3].Clone(), (Point3D)array2[num2 + num3].Clone()), num3, num2 + num3);
			}
			array5[i] = new Brep.OrientedEdge[4];
			array5[i][0] = new Brep.OrientedEdge(i);
			array5[i][1] = new Brep.OrientedEdge(num * 2 + num3);
			array5[i][2] = new Brep.OrientedEdge(num + i, sense: false);
			array5[i][3] = new Brep.OrientedEdge(num * 2 + i, sense: false);
			Vector3D generatrix = new Vector3D((Point3D)individualCurves[i].StartPoint.Clone(), (Point3D)individualCurves2[i].StartPoint.Clone());
			ICurve directrix = ((individualCurves[i].Length() > individualCurves2[i].Length()) ? ((ICurve)individualCurves[i].Clone()) : ((ICurve)individualCurves2[i].Clone()));
			array6[i] = new TabulatedSurf(directrix, generatrix, i);
			array4[i] = new Brep.Face(array6[i], new Brep.Loop(array5[i]));
		}
		return new Brep(array2, array3, array4);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis.Direction, axis.StartPoint);
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

	public Solid RevolveAsSolid(Interval interval, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(interval.Low, interval.Length, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval interval, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(interval.Low, interval.Length, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
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
		return new LinearPathSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
		{
			if (!(GlobalWidth <= 0.0))
			{
				if (GlobalWidth > 0.0)
				{
					return GlobalWidthVertices != null;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971829), GlobalWidth);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return Utility.GetSampling(_vertices);
	}

	public bool IsOrientedClockwise(Plane plane)
	{
		return Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(Vertices, plane);
	}

	public bool IsOrientedClockwise(Transformation t)
	{
		if (!IsClosed)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972252));
		}
		return Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(t, Vertices);
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromICurve(this, parents);
	}

	protected internal override void Draw(DrawParams data)
	{
		if (GlobalWidth > 0.0 && GlobalWidth > (double)(data.ScreenToWorld * 2f) && _isPlanarForGlobalWidth)
		{
			data.RenderContext.PushRasterizerState();
			data.RenderContext.PushShader();
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			data.RenderContext.SetShader(shaderType.NoLights);
			data.RenderContext.Draw(fatGraphicsData);
			data.RenderContext.PopShader();
			data.RenderContext.PopRasterizerState();
		}
		else
		{
			DrawWire(data);
		}
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (fatGraphicsData == null)
		{
			fatGraphicsData = renderContext.CreateEntityGraphicsData(this);
		}
	}

	public override void Compile(CompileParams data)
	{
		_0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D _0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D2 = new _0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D();
		_0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D2._0023_003DzopRx0_MBcTQs = this;
		InitGraphicsData(data.RenderContext);
		if (GlobalWidth > 0.0 && _isPlanarForGlobalWidth)
		{
			_0023_003Dzma_eXFlLam8J(data, out var _0023_003DzyIUKu5w_003D, out var _0023_003DzrdSL0CI_003D, out var _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D);
			if (data.LineType != null)
			{
				_0023_003Dzc9k01_0024u8VSbkzzVPdZG7MHE_003D(_0023_003DzyIUKu5w_003D, _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D);
			}
			else
			{
				PatternGlobalWidthVertices = GlobalWidthVertices.ToList();
			}
			_0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D2._0023_003DzsSLPcz8_003D = new List<Point3D>();
			double num = GlobalWidth / 2.0;
			for (int i = 0; i < _0023_003DzrdSL0CI_003D.Count; i++)
			{
				PointTangent pointTangent = (PointTangent)_0023_003DzrdSL0CI_003D[i];
				Vector3D tangent = pointTangent.Tangent;
				Vector3D vector3D = Vector3D.Cross(_0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.AxisZ, tangent);
				_0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D2._0023_003DzsSLPcz8_003D.Add(pointTangent - vector3D * num);
				_0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D2._0023_003DzsSLPcz8_003D.Add(pointTangent + vector3D * num);
			}
			data.RenderContext.Compile(fatGraphicsData, _0023_003DzpI0RpXmSkwJc7t1HwCD36R4_003D2._0023_003DzKFozHbTsItYyMODIIA_003D_003D, null);
		}
		CompileWire(data);
		RegenMode = regenType.NotNeeded;
	}

	public override void Dispose()
	{
		fatGraphicsData?.Dispose();
		base.Dispose();
	}

	private Plane _0023_003DzmOy4AUeTaJxqadf6zg_003D_003D()
	{
		double tol = _0023_003DzcWsuvoQfLK3L();
		Plane plane;
		if (_vertices.Length < 3 || (_vertices.Length == 3 && IsClosed) || IsLinear(Utility._0023_003DzheSR8QM7q9ya, out var _))
		{
			plane = ((AutodeskProperties != null && AutodeskProperties.ExtrusionDir != null) ? new Plane(Point3D.Origin, AutodeskProperties.ExtrusionDir) : Plane.XY);
		}
		else
		{
			_isPlanarForGlobalWidth = IsPlanar(tol, out plane);
		}
		if (plane == null)
		{
			plane = Plane.XY;
		}
		return plane;
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		if (GlobalWidth > 0.0)
		{
			return Entity.ComputeBoundingBox(data, GlobalWidthVertices, out boxMin, out boxMax);
		}
		return Entity.ComputeBoundingBox(data, _vertices, out boxMin, out boxMax);
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		if (GlobalWidth > 0.0)
		{
			Entity.ComputeOffsetOnCameraAxes(data, GlobalWidthVertices, GlobalWidthVertices.Count);
		}
		base.ComputeOffsetOnCameraAxes(data);
	}

	private void _0023_003Dz2KuGHDTZgCNXG06bVYShYXg_003D(Point3D[] _0023_003DzrdSL0CI_003D, Plane _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D, out List<Point3D> _0023_003DzsSLPcz8_003D)
	{
		double num = GlobalWidth / 2.0;
		_0023_003DzsSLPcz8_003D = new List<Point3D>(_0023_003DzrdSL0CI_003D.Length * 2);
		Point3D point3D = null;
		Point3D point3D2 = null;
		Vector3D vector3D = null;
		Vector3D vector3D2 = null;
		bool flag = false;
		double z = 0.0;
		if (Vector3D.AreCoincident(_0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.AxisZ, Vector3D.AxisZ))
		{
			flag = true;
			z = _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Origin.Z;
		}
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Length - 1; i++)
		{
			Vector3D vector3D3 = vector3D ?? Vector3D.Subtract(_0023_003DzrdSL0CI_003D[i + 1], _0023_003DzrdSL0CI_003D[i]);
			vector3D3.Normalize();
			Vector3D vector3D4 = vector3D2 ?? Vector3D.Cross(vector3D3, _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.AxisZ);
			vector3D4.Normalize();
			Point3D point3D3 = _0023_003DzrdSL0CI_003D[i];
			Point3D point3D4 = ((!(point3D != null)) ? (point3D3 - vector3D4 * num) : point3D);
			Point3D point3D5 = ((!(point3D2 != null)) ? (point3D3 + vector3D4 * num) : point3D2);
			point3D = (point3D2 = null);
			point3D3 = _0023_003DzrdSL0CI_003D[i + 1];
			Point3D point3D6 = point3D3 - vector3D4 * num;
			Point3D point3D7 = point3D3 + vector3D4 * num;
			Point2D p;
			Point2D p2;
			if (flag)
			{
				p = new Point2D(point3D4.X, point3D4.Y);
				p2 = new Point2D(point3D5.X, point3D5.Y);
			}
			else
			{
				p = _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D4);
				p2 = _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D5);
			}
			Point2D p3;
			Point2D p4;
			if (i < _0023_003DzrdSL0CI_003D.Length - 2)
			{
				vector3D = Vector3D.Subtract(_0023_003DzrdSL0CI_003D[i + 2], _0023_003DzrdSL0CI_003D[i + 1]);
				vector3D.Normalize();
				vector3D2 = Vector3D.Cross(vector3D, _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.AxisZ);
				vector3D2.Normalize();
				point3D3 = _0023_003DzrdSL0CI_003D[i + 1];
				Point3D point3D8 = point3D3 - vector3D2 * num;
				Point3D point3D9 = point3D3 + vector3D2 * num;
				point3D3 = _0023_003DzrdSL0CI_003D[i + 2];
				Point3D point3D10 = point3D3 - vector3D2 * num;
				Point3D point3D11 = point3D3 + vector3D2 * num;
				if (flag)
				{
					p3 = new Point3D(point3D6.X, point3D6.Y);
					p4 = new Point3D(point3D7.X, point3D7.Y);
				}
				else
				{
					p3 = _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D6);
					p4 = _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D7);
				}
				Segment2D s = new Segment2D(p, p3);
				Segment2D s2 = new Segment2D(p2, p4);
				Segment2D s3;
				Segment2D s4;
				if (flag)
				{
					s3 = new Segment2D(point3D8, point3D10);
					s4 = new Segment2D(point3D9, point3D11);
				}
				else
				{
					s3 = new Segment2D(_0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D8), _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D10));
					s4 = new Segment2D(_0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D9), _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D11));
				}
				if (Utility.RadToDeg(Vector3D.AngleBetween(vector3D3 * -1.0, vector3D)) > 28.0)
				{
					Point2D i2 = null;
					Point2D i3 = null;
					if (Segment2D.Intersection(s, s3, out i2))
					{
						if (!Segment2D.IntersectionLine(s2, s4, out i3))
						{
						}
					}
					else if (Segment2D.Intersection(s, s4, out i2))
					{
						if (!Segment2D.IntersectionLine(s2, s3, out i3))
						{
						}
					}
					else if (Segment2D.Intersection(s2, s3, out i2))
					{
						if (!Segment2D.IntersectionLine(s, s4, out i3))
						{
						}
					}
					else if (Segment2D.Intersection(s2, s4, out i2))
					{
						Segment2D.IntersectionLine(s, s3, out i3);
					}
					if (i2 != null)
					{
						point3D6 = ((!flag) ? _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.PointAt(i2) : new Point3D(i2.X, i2.Y, z));
						point3D = point3D6;
					}
					if (i3 != null)
					{
						point3D7 = ((!flag) ? _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.PointAt(i3) : new Point3D(i3.X, i3.Y, z));
						point3D2 = point3D7;
					}
				}
			}
			if (flag)
			{
				p3 = new Point2D(point3D6.X, point3D6.Y);
				p4 = new Point3D(point3D7.X, point3D7.Y);
			}
			else
			{
				p3 = _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D6);
				p4 = _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D.Project(point3D7);
			}
			if (Segment2D.Intersection(new Segment2D(p, p3), new Segment2D(p2, p4), out var _))
			{
				Point3D point3D12 = point3D6;
				point3D6 = point3D7;
				point3D7 = point3D12;
				Point3D point3D13 = point3D;
				point3D = point3D2;
				point3D2 = point3D13;
			}
			_0023_003DzsSLPcz8_003D.Add(point3D4);
			_0023_003DzsSLPcz8_003D.Add(point3D6);
			_0023_003DzsSLPcz8_003D.Add(point3D7);
			_0023_003DzsSLPcz8_003D.Add(point3D4);
			_0023_003DzsSLPcz8_003D.Add(point3D7);
			_0023_003DzsSLPcz8_003D.Add(point3D5);
		}
	}

	private void _0023_003Dzma_eXFlLam8J(CompileParams _0023_003DzELu0Pss_003D, out List<Point3D> _0023_003DzyIUKu5w_003D, out List<Point3D> _0023_003DzrdSL0CI_003D, out Plane _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D)
	{
		_0023_003DzyIUKu5w_003D = new List<Point3D>();
		_0023_003DzrdSL0CI_003D = new List<Point3D>();
		if (_0023_003DzELu0Pss_003D.LineType != null)
		{
			_0023_003DzELu0Pss_003D.LineType.GetPatternVertices(_0023_003DzELu0Pss_003D.MaxPatternRepetitions, _vertices, LineTypeScale * _0023_003DzELu0Pss_003D.LineTypeScale, out _0023_003DzyIUKu5w_003D, out _0023_003DzrdSL0CI_003D);
		}
		_0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D = _0023_003DzmOy4AUeTaJxqadf6zg_003D_003D();
	}

	private void _0023_003Dzc9k01_0024u8VSbkzzVPdZG7MHE_003D(List<Point3D> _0023_003DzyIUKu5w_003D, Plane _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D)
	{
		PatternGlobalWidthVertices = new List<Point3D>();
		for (int i = 0; i < _0023_003DzyIUKu5w_003D.Count; i += 2)
		{
			_0023_003Dz2KuGHDTZgCNXG06bVYShYXg_003D(new Point3D[2]
			{
				_0023_003DzyIUKu5w_003D[i],
				_0023_003DzyIUKu5w_003D[i + 1]
			}, _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D, out var _0023_003DzsSLPcz8_003D);
			PatternGlobalWidthVertices.AddRange(_0023_003DzsSLPcz8_003D);
		}
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
			new _0023_003DzCvMCt05pVvqGJGI368UlSvv09UP9pWWmRo3Qh0YGOXCU(_vertices, _0023_003Dzy2VY7ExflvP_: true, ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		int num = _vertices.Length;
		if (num > 1)
		{
			Vector3D vector3D = Vector3D.Subtract(_vertices[num - 1], _vertices[num - 2]);
			if (!vector3D.IsZero)
			{
				Utility.DrawArrowOnView(data, vector3D, _vertices[num - 1]);
			}
		}
	}

	public void WriteCSharp(TextWriter tw, int index)
	{
		tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972217), index, _vertices.Length));
		Point3D[] vertices = _vertices;
		foreach (Point3D point3D in vertices)
		{
			tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972166), point3D.X, point3D.Y, point3D.Z));
		}
		tw.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964365));
		tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972390), index));
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		int num = _vertices.Length;
		_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu[] array = new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(_vertices[i].ToArray());
		}
		_0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D _0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D2 = new _0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D(new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>(array));
		_0023_003DzYe_6EnQecc8d(_0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D2 };
	}
}
