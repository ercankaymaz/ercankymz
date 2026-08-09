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
public class Point : Entity, ICurve, ICloneable, IMateable
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

	public Point3D Position
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

	public Interval Domain => default(Interval);

	public Point3D EndPoint => _vertices[0];

	public Point3D StartPoint => _vertices[0];

	public bool IsClosed => false;

	public bool IsPoint => true;

	public Vector3D StartTangent => new Vector3D();

	public Vector3D EndTangent => new Vector3D();

	public Point(double x, double y, double z, float size)
		: base(entityNatureType.Point)
	{
		LineWeight = size;
		LineWeightMethod = colorMethodType.byEntity;
		_vertices = new Point3D[1]
		{
			new Point3D(x, y, z)
		};
	}

	public Point(double x, double y, double z)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[1]
		{
			new Point3D(x, y, z)
		};
	}

	public Point(double x, double y)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[1]
		{
			new Point3D(x, y, 0.0)
		};
	}

	public Point(Point2D p, float size)
		: base(entityNatureType.Point)
	{
		LineWeight = size;
		LineWeightMethod = colorMethodType.byEntity;
		_vertices = new Point3D[1]
		{
			new Point3D(p.X, p.Y, 0.0)
		};
	}

	public Point(Point2D p)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[1]
		{
			new Point3D(p.X, p.Y, 0.0)
		};
	}

	public Point(Point3D p, float size)
		: base(entityNatureType.Point)
	{
		LineWeight = size;
		LineWeightMethod = colorMethodType.byEntity;
		_vertices = new Point3D[1] { p };
	}

	public Point(Point3D p)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[1] { p };
	}

	public Point(Plane sketchPlane, double x, double y)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[1] { sketchPlane.PointAt(x, y) };
	}

	public Point(Plane sketchPlane, Point2D p)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[1] { sketchPlane.PointAt(p) };
	}

	protected Point(Point another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = new Point3D[1];
		_vertices[0] = (Point3D)another._vertices[0].Clone();
	}

	protected internal Point(PointSurrogate surrogate)
		: this(surrogate.GetPosition())
	{
	}

	internal Point(GPoint _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.Position)
	{
	}

	protected Point(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
	}

	public double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond)
	{
		curve.ClosestPointTo(StartPoint, out var t);
		closestPointOnFirst = new Point3D[1] { StartPoint };
		closestPointOnSecond = new Point3D[1] { curve.PointAt(t) };
		return Point3D.Distance(StartPoint, curve.PointAt(t));
	}

	public override object Clone()
	{
		return new Point(this);
	}

	public override object CloneWithTessellation()
	{
		return new Point(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971148) + Position);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new PointSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return _vertices;
	}

	public double Length()
	{
		return 0.0;
	}

	public void Reverse()
	{
	}

	public bool SubCurve(double startParam, double endParam, out ICurve sub)
	{
		sub = (ICurve)Clone();
		return true;
	}

	public Curve GetNurbsForm()
	{
		return new Curve(0, new double[2] { 0.0, 1.0 }, new Point4D[1]
		{
			new Point4D(_vertices[0].X, _vertices[0].Y, _vertices[0].Z, 1.0)
		});
	}

	public bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		sub = (ICurve)Clone();
		return true;
	}

	public bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		lower = (Point)Clone();
		upper = (Point)Clone();
		return true;
	}

	public bool SplitBy(Point3D pt, out ICurve lower, out ICurve upper)
	{
		lower = (Point)Clone();
		upper = (Point)Clone();
		return true;
	}

	public bool SplitBy(IList<Point3D> points, out ICurve[] segments)
	{
		segments = null;
		return false;
	}

	public bool TrimAt(double t, bool flipSide)
	{
		return false;
	}

	public bool TrimBy(Point3D pt, bool flipSide)
	{
		return false;
	}

	public bool ExtendAt(double t)
	{
		return false;
	}

	public bool ExtendBy(Point3D pt, bool curveEnd = true)
	{
		return false;
	}

	public bool GetParamFromLength(double length, out double t)
	{
		t = 0.0;
		return true;
	}

	public bool GetParamFromLength(double length, double curveLength, out double t)
	{
		t = 0.0;
		return true;
	}

	public bool GetLengthFromParam(double t, out double length)
	{
		length = 0.0;
		return true;
	}

	public Point3D[] IntersectWith(ICurve C2, double maxGap = 0.0, bool computeParameters = true)
	{
		Point3D point3D = _vertices[0];
		if (!C2.IsPoint)
		{
			C2.GetApproximatedBoundingBox(out var boxMin, out var boxMax);
			double diagonal = new Size3D(boxMin, boxMax).Diagonal;
			if (Utility.IsPointInside(point3D, boxMin, boxMax, diagonal * 0.001))
			{
				if (!computeParameters)
				{
					return new Point3D[1] { (Point3D)point3D.Clone() };
				}
				C2.ClosestPointTo(point3D, out var t);
				if (Point3D.AreEqual(point3D, C2.PointAt(t), diagonal))
				{
					return new Point3D[1]
					{
						new InterPoint(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, t, 0.0)
					};
				}
			}
		}
		return new Point3D[0];
	}

	public bool Project(Point3D point, out double t)
	{
		t = 0.0;
		return true;
	}

	public void ClosestPointTo(Point3D point, out double t)
	{
		t = 0.0;
	}

	public ICurve[] GetIndividualCurves()
	{
		return new ICurve[1] { this };
	}

	public bool IsPlanar(double tol, out Plane plane)
	{
		plane = Utility.FitPlane(new List<Point3D> { _vertices[0] });
		return true;
	}

	public bool IsInPlane(Plane plane, double tol)
	{
		bool result = IsValid();
		Point3D point = _vertices[0];
		if (Math.Abs(plane.DistanceTo(point)) > tol)
		{
			result = false;
		}
		return result;
	}

	public bool IsLinear(double tol, out Segment3D line)
	{
		line = null;
		return false;
	}

	public Point3D PointAt(double t)
	{
		return _vertices[0];
	}

	public Vector3D TangentAt(double t)
	{
		return new Vector3D();
	}

	public Vector3D NormalAt(double t)
	{
		return new Vector3D();
	}

	public ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp)
	{
		Point point = (Point)Clone();
		point._vertices[0].X += amount;
		point.CopyAttributes(this);
		return new ICurve[1] { point };
	}

	public Region OffsetToRegion(double amount, bool sharp)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974906));
	}

	public Point3D[] GetPointsByLength(double length)
	{
		return new Point3D[1] { (Point3D)_vertices[0].Clone() };
	}

	public Point3D[] GetPointsByLengthPerSegment(double length)
	{
		return new Point3D[1] { (Point3D)_vertices[0].Clone() };
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		boxMin = (Point3D)_vertices[0].Clone();
		boxMax = (Point3D)_vertices[0].Clone();
	}

	public LinearPath ConvertToLinearPath(double deviation = 0.0, double angle = 0.0)
	{
		throw new NotImplementedException();
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double tolerance, Mesh.natureType meshNature)
	{
		throw new NotImplementedException();
	}

	public Mesh ExtrudeAsMesh(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature)
	{
		throw new NotImplementedException();
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		throw new NotImplementedException();
	}

	public T ExtrudeAsMesh<T>(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		throw new NotImplementedException();
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		throw new NotImplementedException();
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		throw new NotImplementedException();
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		throw new NotImplementedException();
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		throw new NotImplementedException();
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		throw new NotImplementedException();
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		throw new NotImplementedException();
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		throw new NotImplementedException();
	}

	public T[] SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		throw new NotImplementedException();
	}

	public Surface[] ExtrudeAsSurface(Line line)
	{
		throw new NotImplementedException();
	}

	public Surface[] ExtrudeAsSurface(double dx, double dy, double dz)
	{
		throw new NotImplementedException();
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		throw new NotImplementedException();
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		throw new NotImplementedException();
	}

	public Brep ExtrudeAsBrep(Line line, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		throw new NotImplementedException();
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		throw new NotImplementedException();
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis)
	{
		throw new NotImplementedException();
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Line axis, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Line axis, double tolerance = 0.0)
	{
		throw new NotImplementedException();
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType)
	{
		throw new NotImplementedException();
	}

	public Brep SweepAsBrep(ICurve rail, double tolerance, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		throw new NotImplementedException();
	}

	public Brep[] SweepAsBrep(ICurve rail, double tolerance, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		throw new NotImplementedException();
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		throw new NotImplementedException();
	}

	public Solid ExtrudeAsSolid(double dx, double dy, double dz, double tolerance)
	{
		throw new NotImplementedException();
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		throw new NotImplementedException();
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		throw new NotImplementedException();
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		throw new NotImplementedException();
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		throw new NotImplementedException();
	}

	public Solid SweepAsSolid(ICurve rail, double tol, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		throw new NotImplementedException();
	}

	public Solid[] SweepAsSolid(ICurve rail, double tol, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		throw new NotImplementedException();
	}

	public void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax)
	{
		boxMin = (boxMax = (Point3D)_vertices[0].Clone());
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromICurve(this, parents);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (data.Transformation == null)
		{
			if (Camera.IsInFrustum(_vertices[0], data.Frustum))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		else if (Camera.IsInFrustum(data.Transformation * _vertices[0], data.Frustum))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (data.Transformation == null)
		{
			if (Utility._0023_003Dz_0024yfURu187RMm(data.Workspace.RenderContext, _vertices[0], data.ScreenPolygon, data.ModelViewProj, data.ViewFrame))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		else if (Utility._0023_003Dz_0024yfURu187RMm(data.Workspace.RenderContext, data.Transformation * _vertices[0], data.ScreenPolygon, data.ModelViewProj, data.ViewFrame))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	protected internal override void Draw(DrawParams data)
	{
		data.RenderContext.DrawBufferedPoint(_vertices[0]);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
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
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003Dz_Q4HKPwuFf6e2QQ1OJd0reHy3bQkmQVBhQ_003D_003D(Position, ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}

	internal override bool AvoidSmallSizeCulling()
	{
		return true;
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2 = new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(Position.ToArray());
		_0023_003DzYe_6EnQecc8d(_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2 };
	}
}
