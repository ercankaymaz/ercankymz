using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Milling;

[Serializable]
public class Stock : devDept.Eyeshot.Entities.Region, ITriangles
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003DzpCCztDyGR2lwaDafuQ_003D_003D;

		public static Comparison<HitTriangle> _0023_003DzCGlXcj2dTSAkCOvvBg_003D_003D;

		internal bool _0023_003DzI5X_GmV0g_0024RuQeTQz7c43o1VFxFd(Entity _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D is IFace;
		}

		internal int _0023_003DzfkCUx_0024QpL_ndKkX08YsPmIs_003D(HitTriangle _0023_003DzsK_Xndk_003D, HitTriangle _0023_003Dz0ADyCos_003D)
		{
			return _0023_003Dz0ADyCos_003D.IntersectionPoint.Z.CompareTo(_0023_003DzsK_Xndk_003D.IntersectionPoint.Z);
		}
	}

	private sealed class _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D
	{
		public Point2D _0023_003DzS2kgxLms7NqU;

		public double _0023_003DzRMqo1fsPfx14;

		public Interval _0023_003Dzz8LDe9E24U4G;

		public double _0023_003DzvAxV_0024Ic_003D;

		public Point2D _0023_003DzqZ3m1qPoZ7Qh;

		public Stock _0023_003DzopRx0_MBcTQs;

		public float[] _0023_003DzZ86NWzV6mlAE;

		public int _0023_003Dz1IBya9M_003D;

		public float[] _0023_003DzBKiGhhHOxwgd;

		internal void _0023_003Dzwpq0C20xOYiD84rC1A_003D_003D(int _0023_003DzTSeNR8Q_003D)
		{
			for (int i = 0; i < _0023_003Dz1IBya9M_003D + 1; i++)
			{
				double num = _0023_003DzS2kgxLms7NqU.X + (double)i * _0023_003DzRMqo1fsPfx14;
				double num2 = _0023_003DzS2kgxLms7NqU.Y + (double)_0023_003DzTSeNR8Q_003D * _0023_003DzRMqo1fsPfx14;
				double num3 = _0023_003Dzz8LDe9E24U4G.Low + _0023_003DzvAxV_0024Ic_003D;
				_0023_003DzqZ3m1qPoZ7Qh.X = num;
				_0023_003DzqZ3m1qPoZ7Qh.Y = num2;
				if (_0023_003DzopRx0_MBcTQs._mesh != null)
				{
					num3 = ((_0023_003DzopRx0_MBcTQs._heightMap != null) ? _0023_003DzopRx0_MBcTQs._0023_003DzhzO9qhNvoTNZWxoj2A_003D_003D(i, _0023_003DzTSeNR8Q_003D, _0023_003DzopRx0_MBcTQs._zRange) : _0023_003DzopRx0_MBcTQs._0023_003DzP1_0024RPjAjjASb(num, num2, _0023_003DzopRx0_MBcTQs._zRange));
					num3 += _0023_003Dzz8LDe9E24U4G.Low;
				}
				else if (!_0023_003DzopRx0_MBcTQs._0023_003DzHLQLFcW1EFEh(new Point2D(num, num2)))
				{
					num3 = _0023_003Dzz8LDe9E24U4G.Low;
				}
				_0023_003DzZ86NWzV6mlAE[i * 3 + _0023_003DzTSeNR8Q_003D * (_0023_003Dz1IBya9M_003D + 1) * 3] = (float)num;
				_0023_003DzZ86NWzV6mlAE[i * 3 + _0023_003DzTSeNR8Q_003D * (_0023_003Dz1IBya9M_003D + 1) * 3 + 1] = (float)num2;
				_0023_003DzZ86NWzV6mlAE[i * 3 + _0023_003DzTSeNR8Q_003D * (_0023_003Dz1IBya9M_003D + 1) * 3 + 2] = (float)num3;
				_0023_003DzBKiGhhHOxwgd[i * 3 + _0023_003DzTSeNR8Q_003D * (_0023_003Dz1IBya9M_003D + 1) * 3] = 0f;
				_0023_003DzBKiGhhHOxwgd[i * 3 + _0023_003DzTSeNR8Q_003D * (_0023_003Dz1IBya9M_003D + 1) * 3 + 1] = 0f;
				_0023_003DzBKiGhhHOxwgd[i * 3 + _0023_003DzTSeNR8Q_003D * (_0023_003Dz1IBya9M_003D + 1) * 3 + 2] = 1f;
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static string _0023_003DzgrpqC0lGgmdj = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996046);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Color _0023_003DzMaVJB1g_003D = Color.Gray;

	private Interval _zRange;

	private Mesh _mesh;

	private float[,] _heightMap;

	private Vector3D[] _normals;

	private PolyRegion2D _polyReg;

	private double _domainSize;

	private Setup _setup;

	public Interval RangeZ
	{
		get
		{
			return _zRange;
		}
		set
		{
			_zRange = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Vector3D[] Normals => _normals;

	public Setup Setup
	{
		get
		{
			return _setup;
		}
		set
		{
			value._0023_003DzC88fK_14IU6Z(base.Plane);
			_setup = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Stock(ICurve outer, Interval zRange)
		: base(outer, Plane.XY)
	{
		_0023_003DztGdcVOA_003D(zRange);
	}

	public Stock(ICurve outer, Plane pln, Interval zRange)
		: base(outer, pln)
	{
		_0023_003DztGdcVOA_003D(zRange);
	}

	protected Stock(Stock another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_zRange = another._zRange;
		_setup = another._setup;
		if (keepTessellation)
		{
			_0023_003DzGCLU9Ejbtici1iGNzQ_003D_003D(Utility._0023_003DzuKHw7_00241xg_0024SB(another.Normals));
		}
	}

	public Stock(IList<ICurve> contours, Interval zRange)
		: base(contours, Plane.XY)
	{
		_0023_003DztGdcVOA_003D(zRange);
	}

	public Stock(IList<ICurve> contours, Plane pln, Interval zRange)
		: base(contours, pln)
	{
		_0023_003DztGdcVOA_003D(zRange);
	}

	public Stock(IList<Entity> entList, Plane pln, double deviation = 0.0, double angleInRadians = 0.0)
	{
		ColorMethod = colorMethodType.byEntity;
		Color = _0023_003DzMaVJB1g_003D;
		Mesh mesh = _0023_003Dz5QqNaQdJ903R(entList, deviation, angleInRadians);
		if (mesh._vertices.Length != 0)
		{
			_0023_003DzY7jsN85ByTdp(mesh, pln);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996361));
	}

	public Stock(IWorkspace workspace, Plane pln, double deviation = 0.0, double angleInRadians = 0.0)
		: this(workspace.Document, pln, deviation, angleInRadians)
	{
	}

	public Stock(Document document, Plane pln, double deviation = 0.0, double angleInRadians = 0.0)
	{
		ColorMethod = colorMethodType.byEntity;
		Color = _0023_003DzMaVJB1g_003D;
		List<Entity> list = new List<Entity>();
		bool keepTessellation = deviation == 0.0 && angleInRadians == 0.0;
		foreach (Entity entity in document.Entities)
		{
			if (entity is BlockReference blockReference)
			{
				list.AddRange(blockReference.ExplodeDeep(document.Blocks, keepTessellation));
			}
			else
			{
				list.Add(entity);
			}
		}
		Mesh mesh = _0023_003Dz5QqNaQdJ903R(list, deviation, angleInRadians);
		if (mesh._vertices.Length != 0)
		{
			_0023_003DzY7jsN85ByTdp(mesh, pln);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996361));
	}

	public Stock(BlockReference br, BlockKeyedCollection blocks, Plane pln, double deviation = 0.0, double angleInRadians = 0.0)
	{
		Mesh mesh = _0023_003Dz5QqNaQdJ903R(br.ExplodeDeep(blocks, deviation == 0.0 && angleInRadians == 0.0), deviation, angleInRadians);
		if (mesh._vertices.Length != 0)
		{
			_0023_003DzY7jsN85ByTdp(mesh, pln);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996361));
	}

	public Stock(Mesh mesh, Plane pln)
	{
		_0023_003DzY7jsN85ByTdp(mesh, pln);
		ColorMethod = colorMethodType.byEntity;
		Color = _0023_003DzMaVJB1g_003D;
	}

	protected internal Stock(StockSurrogate surrogate)
	{
		_0023_003DztGdcVOA_003D(surrogate.RangeZ);
	}

	protected Stock(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_zRange = (Interval)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996064), typeof(Interval));
	}

	private void _0023_003DztGdcVOA_003D(Interval _0023_003DzA4HfEuA_003D)
	{
		if (_0023_003DzA4HfEuA_003D.IsDecreasing)
		{
			throw new EyeshotException(_0023_003DzgrpqC0lGgmdj);
		}
		_zRange = _0023_003DzA4HfEuA_003D;
		ColorMethod = colorMethodType.byEntity;
		Color = _0023_003DzMaVJB1g_003D;
	}

	public override object Clone()
	{
		return new Stock(this);
	}

	public override object CloneWithTessellation()
	{
		return new Stock(this, RegenMode != regenType.RegenAndCompile);
	}

	private void _0023_003DzY7jsN85ByTdp(Mesh _0023_003DzkKfJheA_003D, Plane _0023_003Dzpyw2kZk_003D)
	{
		Align3D xform = new Align3D(_0023_003Dzpyw2kZk_003D, Plane.XY);
		Mesh mesh = (Mesh)_0023_003DzkKfJheA_003D.Clone();
		mesh.TransformBy(xform);
		mesh.UpdateBoundingBox(null);
		Point3D boxMax = mesh.BoxMax;
		Point3D boxMin = mesh.BoxMin;
		base.ContourList = new List<ICurve>(new ICurve[1] { CompositeCurve.CreateRectangle(_0023_003Dzpyw2kZk_003D, boxMin.X, boxMin.Y, boxMax.X - boxMin.X, boxMax.Y - boxMin.Y) });
		base.Plane = _0023_003Dzpyw2kZk_003D;
		_mesh?.Dispose();
		_mesh = mesh;
		_zRange = new Interval(0.0, boxMax.Z);
	}

	private Mesh _0023_003Dz5QqNaQdJ903R(IList<Entity> _0023_003DzWc9WmS8VMsuA, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D)
	{
		Mesh mesh = new Mesh(0, 0, Mesh.natureType.Plain);
		foreach (IFace item in _0023_003DzWc9WmS8VMsuA.Where((Entity _0023_003DzbfrNXYE_003D) => _0023_003DzbfrNXYE_003D is IFace))
		{
			Mesh mesh2 = item.ConvertToMesh(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, Mesh.natureType.Plain, weld: false);
			if (mesh._vertices.Length == 0)
			{
				mesh = mesh2;
			}
			else
			{
				mesh.MergeWith(mesh2, weldNow: false);
			}
		}
		return mesh;
	}

	public static Stock CreateBox(double width, double depth, double height)
	{
		return CreateBox(Plane.XY, width, depth, new Interval(0.0, height));
	}

	public static Stock CreateBox(Plane pln, double width, double depth, double height)
	{
		return CreateBox(pln, width, depth, new Interval(0.0, height));
	}

	public static Stock CreateBox(double width, double depth, Interval zRange)
	{
		return new Stock(new LinearPath(0.0, 0.0, width, depth), Plane.XY, zRange)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003DzMaVJB1g_003D
		};
	}

	public static Stock CreateBox(Plane pln, double width, double depth, Interval zRange)
	{
		return new Stock(new LinearPath(pln, 0.0, 0.0, width, depth), pln, zRange)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003DzMaVJB1g_003D
		};
	}

	public static Stock CreateBox(double x, double y, double width, double depth, double height)
	{
		return CreateBox(Plane.XY, x, y, width, depth, new Interval(0.0, height));
	}

	public static Stock CreateBox(Plane pln, double x, double y, double width, double depth, double height)
	{
		return CreateBox(pln, x, y, width, depth, new Interval(0.0, height));
	}

	public static Stock CreateBox(double x, double y, double width, double depth, Interval zRange)
	{
		return new Stock(new LinearPath(x, y, width, depth), zRange)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003DzMaVJB1g_003D
		};
	}

	public static Stock CreateBox(Plane pln, double x, double y, double width, double depth, Interval zRange)
	{
		return new Stock(new LinearPath(pln, x, y, width, depth), pln, zRange)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003DzMaVJB1g_003D
		};
	}

	public static Stock CreateCylinder(double radius, double height)
	{
		return CreateCylinder(0.0, 0.0, radius, new Interval(0.0, height));
	}

	public static Stock CreateCylinder(Plane pln, double radius, double height)
	{
		return CreateCylinder(pln, 0.0, 0.0, radius, new Interval(0.0, height));
	}

	public static Stock CreateCylinder(double radius, Interval zRange)
	{
		return CreateCylinder(0.0, 0.0, radius, zRange);
	}

	public static Stock CreateCylinder(Plane pln, double radius, Interval zRange)
	{
		return CreateCylinder(pln, 0.0, 0.0, radius, zRange);
	}

	public static Stock CreateCylinder(double x, double y, double radius, double height)
	{
		return CreateCylinder(x, y, radius, new Interval(0.0, height));
	}

	public static Stock CreateCylinder(Plane pln, double x, double y, double radius, double height)
	{
		return CreateCylinder(pln, x, y, radius, new Interval(0.0, height));
	}

	public static Stock CreateCylinder(double x, double y, double radius, Interval zRange)
	{
		return new Stock(new Circle(x, y, 0.0, radius), zRange)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003DzMaVJB1g_003D
		};
	}

	public static Stock CreateCylinder(Plane pln, double x, double y, double radius, Interval zRange)
	{
		return new Stock(new Circle(pln, new Point2D(x, y), radius), pln, zRange)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003DzMaVJB1g_003D
		};
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		GetSizeOnPlane(base.Plane, out var min, out var max);
		Point2D[] array = new Point2D[4]
		{
			min,
			min + base.Plane.AxisX * (max.X - min.X),
			max,
			min + base.Plane.AxisY * (max.Y - min.Y)
		};
		Point2D[] array2 = new Point2D[4]
		{
			min,
			min + base.Plane.AxisX * (max.X - min.X),
			max,
			min + base.Plane.AxisY * (max.Y - min.Y)
		};
		Point3D[] array3 = new Point3D[8];
		for (int i = 0; i < 4; i++)
		{
			array3[i] = base.Plane.PointAt(array[i].X, array[i].Y, _zRange.Low);
			array3[4 + i] = base.Plane.PointAt(array2[i].X, array2[i].Y, _zRange.High);
		}
		Utility.ComputeBoundingBox(data.Transformation, array3, out boxMin, out boxMax);
		return true;
	}

	internal void _0023_003DzGCLU9Ejbtici1iGNzQ_003D_003D(Vector3D[] _0023_003DzPzO_0024GUk_003D)
	{
		_normals = _0023_003DzPzO_0024GUk_003D;
		RegenMode = regenType.CompileOnly;
	}

	public override void Regen(RegenParams data)
	{
		base.Regen(data);
		IndexTriangle[] array = new IndexTriangle[base.Triangles.Length];
		for (int i = 0; i < base.Triangles.Length; i++)
		{
			array[i] = new SmoothTriangle(base.Triangles[i].V1, base.Triangles[i].V2, base.Triangles[i].V3);
		}
		Mesh mesh = new Mesh(_vertices, array);
		mesh.ExtrudePlanar(base.Plane.AxisZ * _zRange.Length);
		mesh.Translate(base.Plane.AxisZ * _zRange.Low);
		mesh.UpdateNormals();
		mesh.ComputeEdges();
		_normals = mesh.Normals;
		_vertices = mesh.Vertices;
		edges = mesh.Edges;
		base.Triangles = mesh.Triangles;
		ComputeBoundingBox(new TraversalParams(), out localMin, out localMax);
		_domainSize = new Size3D(localMin, localMax).Diagonal;
		UpdateBoundingBoxSphere();
		RegenMode = regenType.CompileOnly;
	}

	public override void TransformBy(Transformation xform)
	{
		double scaleFactorZ = xform.ScaleFactorZ;
		if (scaleFactorZ != 1.0)
		{
			_zRange = new Interval(_zRange.Low * scaleFactorZ, _zRange.High * scaleFactorZ);
		}
		base.TransformBy(xform);
		if (xform.HasReflection)
		{
			Utility.FlipTriangles(base.Triangles);
		}
		if (_normals != null)
		{
			Utility.TransformNormals(xform, _normals);
		}
		if (localMin != null)
		{
			_domainSize = new Size3D(localMin, localMax).Diagonal;
		}
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, Vertices, base.Triangles, base.Edges, _0023_003DzbErHvVw_003D: true, 0.0);
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, data);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		data.RenderContext.Compile(drawData, _0023_003DzanB6YgBA_IW1jvjjlB3tzNM_003D, null);
		data.RenderContext.Compile(drawEdges, _0023_003DzxLlyy8S7CaNX, null);
		RegenMode = regenType.NotNeeded;
	}

	private void _0023_003DzanB6YgBA_IW1jvjjlB3tzNM_003D(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzQdnFby4_003D.DrawTriangles(_vertices, _normals, base.Triangles, null);
	}

	private void _0023_003DzxLlyy8S7CaNX(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzB8iS0QA_003D.DrawIndexLines(edges, _vertices);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		data.RenderContext.DrawNormalsPerVertex(_vertices, base.Triangles, _normals, normalLength);
	}

	public void GetSizeOnPlane(Plane pln, out Point2D min, out Point2D max)
	{
		if (base.ContourList.Count == 0)
		{
			min = null;
			max = null;
			return;
		}
		List<Point3D> list = new List<Point3D>();
		ICurve[] individualCurves = base.ContourList[0].GetIndividualCurves();
		bool flag = true;
		ICurve[] array = individualCurves;
		foreach (ICurve curve in array)
		{
			if (curve is Line line)
			{
				list.Add(line.StartPoint);
				continue;
			}
			if (curve is LinearPath linearPath)
			{
				list.AddRange(linearPath.Vertices.Take(linearPath.Vertices.Length - 1));
				continue;
			}
			flag = false;
			break;
		}
		Point3D boxMin;
		Point3D boxMax;
		if (flag)
		{
			Utility.ComputeBoundingBox(list, out boxMin, out boxMax);
			Utility.GetSizeOnPlane(boxMin, boxMax, pln, out min, out max);
			return;
		}
		list.Clear();
		if (individualCurves.Length == 1 && individualCurves[0].GetType() == typeof(Circle))
		{
			Circle circle = (Circle)individualCurves[0];
			if (Vector3D.AreParallel(circle.Plane.AxisX, Vector3D.AxisX) || Vector3D.AreParallel(circle.Plane.AxisX, Vector3D.AxisY) || Vector3D.AreParallel(circle.Plane.AxisX, Vector3D.AxisZ) || Vector3D.AreParallel(circle.Plane.AxisY, Vector3D.AxisX) || Vector3D.AreParallel(circle.Plane.AxisY, Vector3D.AxisY) || Vector3D.AreParallel(circle.Plane.AxisY, Vector3D.AxisZ))
			{
				list.Add(circle.PointAt(0.0));
				list.Add(circle.PointAt(Math.PI / 2.0));
				list.Add(circle.PointAt(Math.PI));
				list.Add(circle.PointAt(4.71238898038469));
				Utility.ComputeBoundingBox(list, out boxMin, out boxMax);
				Utility.GetSizeOnPlane(boxMin, boxMax, pln, out min, out max);
				return;
			}
		}
		list.Clear();
		Utility.ComputeBoundingBox(EstimateBoundingBox(null, null), out boxMin, out boxMax);
		double deviation = new Size3D(boxMin, boxMax).Diagonal / 1000.0;
		array = individualCurves;
		for (int i = 0; i < array.Length; i++)
		{
			Entity entity = (Entity)array[i];
			entity.Regen(deviation);
			list.AddRange(entity.Vertices.Take(entity.Vertices.Length - 1));
		}
		Utility.ComputeBoundingBox(list, out boxMin, out boxMax);
		Utility.GetSizeOnPlane(boxMin, boxMax, pln, out min, out max);
	}

	public SimulationStock GetSimulationStock(int vertexCount = 100000, IWorkspace workspace = null)
	{
		_0023_003DzRJFujto0gsGdzkuPkA_003D_003D(out var _0023_003DzS2kgxLms7NqU, out var _0023_003DzchHJIY1hQ2BJ, out _domainSize);
		Size2D size2D = new Size2D(_0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ);
		double num = Math.Sqrt((double)vertexCount * size2D.Y / size2D.X);
		double gridStep = size2D.Y / num;
		return GetSimulationStock(gridStep, workspace);
	}

	public SimulationStock GetSimulationStock(double gridStep, IWorkspace workspace = null)
	{
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2 = new _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D();
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzopRx0_MBcTQs = this;
		if (_setup == null && !Vector3D.AreCoincident(base.Plane.AxisZ, Vector3D.AxisZ))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995989));
		}
		Point2D _0023_003DzchHJIY1hQ2BJ;
		Plane plane = _0023_003DzRJFujto0gsGdzkuPkA_003D_003D(out _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, out _0023_003DzchHJIY1hQ2BJ, out _domainSize);
		if (_mesh == null)
		{
			Polygon2D[] array = new Polygon2D[base.ContourList.Count];
			for (int i = 0; i < array.Length; i++)
			{
				Entity entity = (Entity)base.ContourList[i];
				entity.Regen(_domainSize / 1000.0);
				Point2D[] array2 = new Point2D[entity.Vertices.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = plane.Project(entity.Vertices[j]);
				}
				array[i] = new Polygon2D(array2);
			}
			_polyReg = new PolyRegion2D(array);
			_polyReg.UpdateBoundingRect();
		}
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G = _zRange;
		if (_setup != null)
		{
			Segment3D segment3D = new Segment3D(_setup.Plane.Origin, _setup.Plane.Origin + base.Plane.AxisZ);
			Point3D pt = base.Plane.Origin + base.Plane.AxisZ * _zRange.Low;
			Point3D pt2 = base.Plane.Origin + base.Plane.AxisZ * _zRange.High;
			double t = segment3D.Project(pt);
			double t2 = segment3D.Project(pt2);
			_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G = new Interval(t, t2);
		}
		Size2D size2D = new Size2D(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ);
		double x = size2D.X;
		double y = size2D.Y;
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzvAxV_0024Ic_003D = _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G.Length;
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D = (int)(x / gridStep);
		int num = (int)(y / gridStep);
		double _0023_003DzRMqo1fsPfx = x / (double)_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D;
		double _0023_003DzRMqo1fsPfx2 = y / (double)num;
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14 = _0023_003DzRMqo1fsPfx;
		if (x < y)
		{
			_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14 = _0023_003DzRMqo1fsPfx2;
			_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D = (int)(x / _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14);
		}
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzZ86NWzV6mlAE = new float[(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * (num + 1) * 3];
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzBKiGhhHOxwgd = new float[(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * (num + 1) * 3];
		_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzqZ3m1qPoZ7Qh = new Point2D();
		if (_mesh != null)
		{
			if (workspace != null)
			{
				_mesh.Regen(0.0);
				_mesh.Compile(new CompileParams(workspace));
				Point2D point2D = _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU + new Vector2D((double)_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D * _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, (double)num * _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14);
				Vector2D vector2D = new Vector2D(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14) * 0.5;
				_0023_003Dzh4d0Yuy8_UGa64wxCO2VVXg_003D(workspace.RenderContext, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU - vector2D, point2D + vector2D, _zRange, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1, num + 1);
			}
			else
			{
				_mesh.BuildOctree(_mesh.Triangles.Length / 100);
			}
		}
		Parallel.For(0, num + 1, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzwpq0C20xOYiD84rC1A_003D_003D);
		int num2 = 0;
		int[] array3 = new int[_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D * num * 3 * 2];
		for (int k = 0; k < num; k++)
		{
			for (int l = 0; l < _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D; l++)
			{
				array3[num2] = l + (_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * k;
				num2++;
				array3[num2] = l + 1 + (_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * k;
				num2++;
				array3[num2] = l + 1 + (_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * (k + 1);
				num2++;
				array3[num2] = l + (_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * k;
				num2++;
				array3[num2] = l + 1 + (_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * (k + 1);
				num2++;
				array3[num2] = l + (_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * (k + 1);
				num2++;
			}
		}
		num2 = 0;
		byte[] array4 = new byte[(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1) * (num + 1) * 3];
		for (int m = 0; m < num + 1; m++)
		{
			for (int n = 0; n < _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D + 1; n++)
			{
				array4[num2++] = Color.R;
				array4[num2++] = Color.G;
				array4[num2++] = Color.B;
			}
		}
		SimulationStock simulationStock = new SimulationStock(num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D);
		simulationStock.ColorMethod = ColorMethod;
		simulationStock.Color = Color;
		simulationStock.PointArray = _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzZ86NWzV6mlAE;
		simulationStock.NormalArray = _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzBKiGhhHOxwgd;
		simulationStock.TriangleArray = array3;
		simulationStock.ColorArray = array4;
		simulationStock.GridStep = _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14;
		simulationStock._0023_003DzR_IIhqyn5_prcagI0Q_003D_003D(_0023_003Dz45thxeUyuKPZ: true);
		if (_mesh == null)
		{
			simulationStock._0023_003DztOrWpXn2GxeGkL7mK1Td_Bg_003D(_0023_003Dz9rlxqYwkcpYy(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G, 0.0, 0.0, _0023_003DzpS_hL4S_0024_8GX: false), _0023_003DzogHaGSXhPzKE(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G, 0.0, 0.0, _0023_003DzpS_hL4S_0024_8GX: false), _0023_003DzAOE2zb6Jdj98(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G), _0023_003DzVLyxd_73o66P(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G), _0023_003DzmQm5iBgprj0y(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G));
		}
		else
		{
			simulationStock._0023_003DztOrWpXn2GxeGkL7mK1Td_Bg_003D(_0023_003DzsmR5TUwFrUpoq4YcQQ_003D_003D(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzZ86NWzV6mlAE, (float)_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G.Low), _0023_003DzpQzTHIGMU7pUopT80A_003D_003D(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzZ86NWzV6mlAE, (float)_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G.Low), _0023_003DzKizrqOWvPQ_0024V7I1WcQ_003D_003D(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzZ86NWzV6mlAE, (float)_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G.Low), _0023_003DzKFgdn6kfyOkDnAR_0024gQ_003D_003D(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzZ86NWzV6mlAE, (float)_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G.Low), _0023_003DzmQm5iBgprj0y(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dz1IBya9M_003D, num, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzRMqo1fsPfx14, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G));
		}
		simulationStock._0023_003DzR_IIhqyn5_prcagI0Q_003D_003D(_0023_003Dz45thxeUyuKPZ: false);
		simulationStock.UpdateNormals();
		simulationStock.localMin = new Point3D(_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU.X, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003DzS2kgxLms7NqU.Y, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G.Low);
		simulationStock.localMax = new Point3D(_0023_003DzchHJIY1hQ2BJ.X, _0023_003DzchHJIY1hQ2BJ.Y, _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D2._0023_003Dzz8LDe9E24U4G.High);
		simulationStock.workMin = (Point3D)simulationStock.localMin.Clone();
		simulationStock.workMax = (Point3D)simulationStock.localMax.Clone();
		if (_setup != null)
		{
			simulationStock._0023_003DznTv6jJyUD3Pu(_setup.Transformation);
		}
		else
		{
			simulationStock._0023_003DznTv6jJyUD3Pu(new Align3D(Plane.XY, plane));
		}
		simulationStock.ComputeBoundingBox(new TraversalParams(), out simulationStock.localMin, out simulationStock.localMax);
		simulationStock.UpdateBoundingBoxSphere();
		simulationStock.RegenMode = regenType.CompileOnly;
		return simulationStock;
	}

	private void _0023_003Dzh4d0Yuy8_UGa64wxCO2VVXg_003D(RenderContextBase _0023_003DzQdnFby4_003D, Point2D _0023_003DzF7v9r2A_003D, Point2D _0023_003Dz8dK2uhU_003D, Interval _0023_003DzA4HfEuA_003D, int _0023_003Dz6tVBpdk_003D, int _0023_003DzvAxV_0024Ic_003D)
	{
		double num = (_0023_003Dz8dK2uhU_003D.X - _0023_003DzF7v9r2A_003D.X) / 2.0;
		double num2 = (_0023_003Dz8dK2uhU_003D.Y - _0023_003DzF7v9r2A_003D.Y) / 2.0;
		Point2D point2D = _0023_003DzF7v9r2A_003D + 0.5 * (_0023_003Dz8dK2uhU_003D - _0023_003DzF7v9r2A_003D);
		double[] m = Camera.LookAt(new Point3D(point2D.X, point2D.Y, _0023_003DzA4HfEuA_003D.Max), new Point3D(point2D.X, point2D.Y, _0023_003DzA4HfEuA_003D.Min), Vector3D.AxisY, reflection: false);
		double[] m2 = Camera.myOrtho(_0023_003DzQdnFby4_003D, 0.0 - num, num, 0.0 - num2, num2, 0.0, _0023_003DzA4HfEuA_003D.Length);
		Transformation transformation = new Transformation(m, byRow: false);
		double[] matrixAsVectorByColumn = (new Transformation(m2, byRow: false) * transformation).MatrixAsVectorByColumn;
		_heightMap = _0023_003DzQdnFby4_003D.GetHeightmapFromGeometry(matrixAsVectorByColumn, new int[4] { 0, 0, _0023_003Dz6tVBpdk_003D, _0023_003DzvAxV_0024Ic_003D }, _0023_003Dzcfj4z1PXF0TmXt2nGMHroC1hJYevQiNVjA_003D_003D);
	}

	private Plane _0023_003DzRJFujto0gsGdzkuPkA_003D_003D(out Point2D _0023_003DzS2kgxLms7NqU, out Point2D _0023_003DzchHJIY1hQ2BJ, out double _0023_003DzxH4ozIo_003D)
	{
		Plane plane = ((_setup != null) ? _setup.Plane : base.Plane);
		if (_mesh != null)
		{
			_0023_003DzxH4ozIo_003D = new Size2D(_mesh.BoxMin, _mesh.BoxMax).Diagonal;
			_0023_003DzS2kgxLms7NqU = new Point2D(_mesh.BoxMin.X, _mesh.BoxMin.Y);
			_0023_003DzchHJIY1hQ2BJ = new Point2D(_mesh.BoxMax.X, _mesh.BoxMax.Y);
		}
		else
		{
			GetSizeOnPlane(plane, out _0023_003DzS2kgxLms7NqU, out _0023_003DzchHJIY1hQ2BJ);
			_0023_003DzxH4ozIo_003D = new Size2D(_0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ).Diagonal;
		}
		return plane;
	}

	public bool HasBoundary()
	{
		if (base.ContourList.Count > 1)
		{
			return true;
		}
		if (base.ContourList[0] is CompositeCurve compositeCurve)
		{
			if (compositeCurve.CurveList.Count != 4)
			{
				return true;
			}
			Point2D[] array = new Point2D[4];
			for (int i = 0; i < 4; i++)
			{
				ICurve curve = compositeCurve.CurveList[i];
				if (!Utility.IsLine(curve))
				{
					return true;
				}
				array[i] = base.Plane.Project(curve.StartPoint);
			}
			if (Utility.Compare(array[0].X, array[1].X) != 0 && Utility.Compare(array[0].Y, array[1].Y) != 0)
			{
				return true;
			}
			if (Utility.Compare(array[1].X, array[2].X) != 0 && Utility.Compare(array[1].Y, array[2].Y) != 0)
			{
				return true;
			}
			if (Utility.Compare(array[2].X, array[3].X) != 0 && Utility.Compare(array[2].Y, array[3].Y) != 0)
			{
				return true;
			}
			if (Utility.Compare(array[3].X, array[0].X) != 0 && Utility.Compare(array[3].Y, array[0].Y) != 0)
			{
				return true;
			}
		}
		else
		{
			if (!(base.ContourList[0] is LinearPath linearPath))
			{
				return true;
			}
			if (linearPath.Vertices.Length != 5)
			{
				return true;
			}
			Point2D[] array2 = new Point2D[4];
			for (int j = 0; j < 4; j++)
			{
				array2[j] = base.Plane.Project(linearPath.Vertices[j]);
			}
			if (Utility.Compare(array2[0].X, array2[1].X) != 0 && Utility.Compare(array2[0].Y, array2[1].Y) != 0)
			{
				return true;
			}
			if (Utility.Compare(array2[1].X, array2[2].X) != 0 && Utility.Compare(array2[1].Y, array2[2].Y) != 0)
			{
				return true;
			}
			if (Utility.Compare(array2[2].X, array2[3].X) != 0 && Utility.Compare(array2[2].Y, array2[3].Y) != 0)
			{
				return true;
			}
			if (Utility.Compare(array2[3].X, array2[0].X) != 0 && Utility.Compare(array2[3].Y, array2[0].Y) != 0)
			{
				return true;
			}
		}
		return false;
	}

	private double _0023_003DzP1_0024RPjAjjASb(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, Interval _0023_003DzYgWYV9o_003D)
	{
		Segment3D seg = new Segment3D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzYgWYV9o_003D.High, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzYgWYV9o_003D.Low);
		IList<HitTriangle> list = _mesh.FindClosestTriangle(null, seg);
		list.ToList().Sort((HitTriangle _0023_003DzsK_Xndk_003D, HitTriangle _0023_003Dz0ADyCos_003D) => _0023_003Dz0ADyCos_003D.IntersectionPoint.Z.CompareTo(_0023_003DzsK_Xndk_003D.IntersectionPoint.Z));
		if (list.Count > 0)
		{
			return list[0].IntersectionPoint.Z;
		}
		return _0023_003DzYgWYV9o_003D.Min;
	}

	private double _0023_003DzhzO9qhNvoTNZWxoj2A_003D_003D(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D, Interval _0023_003DzYgWYV9o_003D)
	{
		if (_heightMap != null)
		{
			return _0023_003DzYgWYV9o_003D.Max - _0023_003DzYgWYV9o_003D.Length * (double)_heightMap[_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D];
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996145));
	}

	private bool _0023_003DzHLQLFcW1EFEh(Point2D _0023_003DzMlCq3wk_003D)
	{
		return _polyReg.IsPointInside(_0023_003DzMlCq3wk_003D, _domainSize);
	}

	internal FastMesh _0023_003Dz9rlxqYwkcpYy(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, double _0023_003DzRMqo1fsPfx14, Point2D _0023_003DzS2kgxLms7NqU, Point2D _0023_003DzchHJIY1hQ2BJ, Interval _0023_003Dzz8LDe9E24U4G, double _0023_003Dzo5jdAtc_003D, double _0023_003Dz3PB4mZU_003D, bool _0023_003DzpS_hL4S_0024_8GX)
	{
		double length = _0023_003Dzz8LDe9E24U4G.Length;
		int num = 2;
		float[] array = new float[(_0023_003Dz1IBya9M_003D + 1) * num * 3];
		float[] array2 = new float[(_0023_003Dz1IBya9M_003D + 1) * num * 3];
		int num2 = 0;
		int num3 = 0;
		Point2D point2D = new Point2D();
		bool flag = HasBoundary();
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < _0023_003Dz1IBya9M_003D + 1; j++)
			{
				double num4 = _0023_003Dzo5jdAtc_003D + _0023_003DzS2kgxLms7NqU.X + (double)j * _0023_003DzRMqo1fsPfx14;
				double num5 = _0023_003Dz3PB4mZU_003D + _0023_003DzS2kgxLms7NqU.Y;
				double num6 = _0023_003Dzz8LDe9E24U4G.Low + (double)i * length;
				point2D.X = num4;
				point2D.Y = num5;
				if (flag && !_0023_003DzHLQLFcW1EFEh(point2D))
				{
					num6 = _0023_003Dzz8LDe9E24U4G.Low;
				}
				array[num2++] = (float)num4;
				array[num2++] = (float)num5;
				array[num2++] = (float)num6;
				array2[num3++] = 0f;
				array2[num3++] = (_0023_003DzpS_hL4S_0024_8GX ? 1 : (-1));
				array2[num3++] = 0f;
			}
		}
		num2 = 0;
		int[] array3 = new int[_0023_003Dz1IBya9M_003D * (num - 1) * 3 * 2];
		for (int k = 0; k < num - 1; k++)
		{
			for (int l = 0; l < _0023_003Dz1IBya9M_003D; l++)
			{
				array3[num2++] = l + (_0023_003Dz1IBya9M_003D + 1) * k;
				array3[num2++] = l + 1 + (_0023_003Dz1IBya9M_003D + 1) * (_0023_003DzpS_hL4S_0024_8GX ? (k + 1) : k);
				array3[num2++] = l + 1 + (_0023_003Dz1IBya9M_003D + 1) * (_0023_003DzpS_hL4S_0024_8GX ? k : (k + 1));
				array3[num2++] = l + (_0023_003Dz1IBya9M_003D + 1) * k;
				array3[num2++] = l + (_0023_003Dz1IBya9M_003D + 1) * (k + 1) + ((!_0023_003DzpS_hL4S_0024_8GX) ? 1 : 0);
				array3[num2++] = l + (_0023_003Dz1IBya9M_003D + 1) * (k + 1) + (_0023_003DzpS_hL4S_0024_8GX ? 1 : 0);
			}
		}
		FastMesh fastMesh = new FastMesh();
		fastMesh.PointArray = array;
		fastMesh.NormalArray = array2;
		fastMesh.TriangleArray = array3;
		fastMesh.Color = Color;
		fastMesh.ColorMethod = colorMethodType.byEntity;
		fastMesh.UpdateBoundingBox(null);
		fastMesh.RegenMode = regenType.CompileOnly;
		return fastMesh;
	}

	internal FastMesh _0023_003DzogHaGSXhPzKE(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, double _0023_003DzRMqo1fsPfx14, Point2D _0023_003DzS2kgxLms7NqU, Point2D _0023_003DzchHJIY1hQ2BJ, Interval _0023_003Dzz8LDe9E24U4G, double _0023_003Dzo5jdAtc_003D, double _0023_003Dz3PB4mZU_003D, bool _0023_003DzpS_hL4S_0024_8GX)
	{
		double num = (double)_0023_003Dz1IBya9M_003D * _0023_003DzRMqo1fsPfx14;
		double length = _0023_003Dzz8LDe9E24U4G.Length;
		int num2 = 2;
		float[] array = new float[(_0023_003DzuiOvIzs_003D + 1) * num2 * 3];
		float[] array2 = new float[(_0023_003DzuiOvIzs_003D + 1) * num2 * 3];
		int num3 = 0;
		int num4 = 0;
		Point2D point2D = new Point2D();
		bool flag = HasBoundary();
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < _0023_003DzuiOvIzs_003D + 1; j++)
			{
				double num5 = _0023_003Dzo5jdAtc_003D + _0023_003DzS2kgxLms7NqU.X + num;
				double num6 = _0023_003Dz3PB4mZU_003D + _0023_003DzS2kgxLms7NqU.Y + (double)j * _0023_003DzRMqo1fsPfx14;
				double num7 = _0023_003Dzz8LDe9E24U4G.Low + (double)i * length;
				point2D.X = num5;
				point2D.Y = num6;
				if (flag && !_0023_003DzHLQLFcW1EFEh(point2D))
				{
					num7 = _0023_003Dzz8LDe9E24U4G.Low;
				}
				array[num3++] = (float)num5;
				array[num3++] = (float)num6;
				array[num3++] = (float)num7;
				array2[num4++] = ((!_0023_003DzpS_hL4S_0024_8GX) ? 1 : (-1));
				array2[num4++] = 0f;
				array2[num4++] = 0f;
			}
		}
		num3 = 0;
		int[] array3 = new int[_0023_003DzuiOvIzs_003D * (num2 - 1) * 3 * 2];
		for (int k = 0; k < num2 - 1; k++)
		{
			for (int l = 0; l < _0023_003DzuiOvIzs_003D; l++)
			{
				array3[num3++] = l + (_0023_003DzuiOvIzs_003D + 1) * k;
				array3[num3++] = l + 1 + (_0023_003DzuiOvIzs_003D + 1) * (_0023_003DzpS_hL4S_0024_8GX ? (k + 1) : k);
				array3[num3++] = l + 1 + (_0023_003DzuiOvIzs_003D + 1) * (_0023_003DzpS_hL4S_0024_8GX ? k : (k + 1));
				array3[num3++] = l + (_0023_003DzuiOvIzs_003D + 1) * k;
				array3[num3++] = l + (_0023_003DzuiOvIzs_003D + 1) * (k + 1) + ((!_0023_003DzpS_hL4S_0024_8GX) ? 1 : 0);
				array3[num3++] = l + (_0023_003DzuiOvIzs_003D + 1) * (k + 1) + (_0023_003DzpS_hL4S_0024_8GX ? 1 : 0);
			}
		}
		FastMesh fastMesh = new FastMesh();
		fastMesh.PointArray = array;
		fastMesh.NormalArray = array2;
		fastMesh.TriangleArray = array3;
		fastMesh.Color = Color;
		fastMesh.ColorMethod = colorMethodType.byEntity;
		fastMesh.UpdateBoundingBox(null);
		fastMesh.RegenMode = regenType.CompileOnly;
		return fastMesh;
	}

	internal FastMesh _0023_003DzAOE2zb6Jdj98(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, double _0023_003DzRMqo1fsPfx14, Point2D _0023_003DzS2kgxLms7NqU, Point2D _0023_003DzchHJIY1hQ2BJ, Interval _0023_003Dzz8LDe9E24U4G)
	{
		return _0023_003Dz9rlxqYwkcpYy(_0023_003Dz1IBya9M_003D, _0023_003DzuiOvIzs_003D, _0023_003DzRMqo1fsPfx14, _0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003Dzz8LDe9E24U4G, 0.0, (double)_0023_003DzuiOvIzs_003D * _0023_003DzRMqo1fsPfx14, _0023_003DzpS_hL4S_0024_8GX: true);
	}

	internal FastMesh _0023_003DzVLyxd_73o66P(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, double _0023_003DzRMqo1fsPfx14, Point2D _0023_003DzS2kgxLms7NqU, Point2D _0023_003DzchHJIY1hQ2BJ, Interval _0023_003Dzz8LDe9E24U4G)
	{
		return _0023_003DzogHaGSXhPzKE(_0023_003Dz1IBya9M_003D, _0023_003DzuiOvIzs_003D, _0023_003DzRMqo1fsPfx14, _0023_003DzS2kgxLms7NqU, _0023_003DzchHJIY1hQ2BJ, _0023_003Dzz8LDe9E24U4G, (double)(-_0023_003Dz1IBya9M_003D) * _0023_003DzRMqo1fsPfx14, 0.0, _0023_003DzpS_hL4S_0024_8GX: true);
	}

	internal FastMesh _0023_003DzmQm5iBgprj0y(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, double _0023_003DzRMqo1fsPfx14, Point2D _0023_003DzS2kgxLms7NqU, Point2D _0023_003DzchHJIY1hQ2BJ, Interval _0023_003Dzz8LDe9E24U4G)
	{
		double num = _0023_003DzRMqo1fsPfx14 * (double)_0023_003Dz1IBya9M_003D;
		double num2 = _0023_003DzRMqo1fsPfx14 * (double)_0023_003DzuiOvIzs_003D;
		_ = _0023_003Dzz8LDe9E24U4G.Length;
		_0023_003Dz1IBya9M_003D = 2;
		_0023_003DzuiOvIzs_003D = 2;
		float[] array = new float[_0023_003Dz1IBya9M_003D * _0023_003DzuiOvIzs_003D * 3];
		float[] array2 = new float[_0023_003Dz1IBya9M_003D * _0023_003DzuiOvIzs_003D * 3];
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < _0023_003DzuiOvIzs_003D; i++)
		{
			for (int j = 0; j < _0023_003Dz1IBya9M_003D; j++)
			{
				array[num3++] = (float)(_0023_003DzS2kgxLms7NqU.X + (double)j * num);
				array[num3++] = (float)(_0023_003DzS2kgxLms7NqU.Y + (double)i * num2);
				array[num3++] = (float)_0023_003Dzz8LDe9E24U4G.Low;
				array2[num4++] = 0f;
				array2[num4++] = 0f;
				array2[num4++] = -1f;
			}
		}
		num3 = 0;
		int[] array3 = new int[6];
		array3[num3++] = 0;
		array3[num3++] = 3;
		array3[num3++] = 1;
		array3[num3++] = 0;
		array3[num3++] = 2;
		array3[num3++] = 3;
		FastMesh fastMesh = new FastMesh();
		fastMesh.PointArray = array;
		fastMesh.NormalArray = array2;
		fastMesh.TriangleArray = array3;
		fastMesh.Color = Color;
		fastMesh.ColorMethod = colorMethodType.byEntity;
		fastMesh.UpdateBoundingBox(null);
		fastMesh.RegenMode = regenType.CompileOnly;
		return fastMesh;
	}

	internal FastMesh _0023_003DzsmR5TUwFrUpoq4YcQQ_003D_003D(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, float[] _0023_003DzUXasvLLbY71v, float _0023_003Dz89Mrb8s_003D)
	{
		int num = 2;
		float[] array = new float[(_0023_003Dz1IBya9M_003D + 1) * num * 3];
		float[] array2 = new float[(_0023_003Dz1IBya9M_003D + 1) * num * 3];
		new Point2D();
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < _0023_003Dz1IBya9M_003D + 1; i++)
		{
			array[(_0023_003Dz1IBya9M_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[num2];
			array[num2] = _0023_003DzUXasvLLbY71v[num2];
			num2++;
			array[(_0023_003Dz1IBya9M_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[num2];
			array[num2] = _0023_003DzUXasvLLbY71v[num2];
			num2++;
			array[(_0023_003Dz1IBya9M_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[num2];
			array[num2] = _0023_003Dz89Mrb8s_003D;
			num2++;
			array2[(_0023_003Dz1IBya9M_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
			array2[(_0023_003Dz1IBya9M_003D + 1) * 3 + num3] = -1f;
			array2[num3] = -1f;
			num3++;
			array2[(_0023_003Dz1IBya9M_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
		}
		num2 = 0;
		int[] array3 = new int[_0023_003Dz1IBya9M_003D * (num - 1) * 3 * 2];
		for (int j = 0; j < num - 1; j++)
		{
			for (int k = 0; k < _0023_003Dz1IBya9M_003D; k++)
			{
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * j;
				array3[num2++] = k + 1 + (_0023_003Dz1IBya9M_003D + 1) * j;
				array3[num2++] = k + 1 + (_0023_003Dz1IBya9M_003D + 1) * (j + 1);
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * j;
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * (j + 1) + 1;
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * (j + 1);
			}
		}
		FastMesh fastMesh = new FastMesh();
		fastMesh.PointArray = array;
		fastMesh.NormalArray = array2;
		fastMesh.TriangleArray = array3;
		fastMesh.ColorMethod = ColorMethod;
		fastMesh.Color = Color;
		fastMesh.UpdateBoundingBox(null);
		fastMesh.RegenMode = regenType.CompileOnly;
		return fastMesh;
	}

	internal FastMesh _0023_003DzpQzTHIGMU7pUopT80A_003D_003D(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, float[] _0023_003DzUXasvLLbY71v, float _0023_003Dz89Mrb8s_003D)
	{
		int num = 2;
		float[] array = new float[(_0023_003DzuiOvIzs_003D + 1) * num * 3];
		float[] array2 = new float[(_0023_003DzuiOvIzs_003D + 1) * num * 3];
		new Point2D();
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < _0023_003DzuiOvIzs_003D + 1; i++)
		{
			array[(_0023_003DzuiOvIzs_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[_0023_003Dz1IBya9M_003D * 3 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			array[num2] = _0023_003DzUXasvLLbY71v[_0023_003Dz1IBya9M_003D * 3 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			num2++;
			array[(_0023_003DzuiOvIzs_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[1 + _0023_003Dz1IBya9M_003D * 3 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			array[num2] = _0023_003DzUXasvLLbY71v[1 + _0023_003Dz1IBya9M_003D * 3 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			num2++;
			array[(_0023_003DzuiOvIzs_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[2 + _0023_003Dz1IBya9M_003D * 3 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			array[num2] = _0023_003Dz89Mrb8s_003D;
			num2++;
			array2[(_0023_003DzuiOvIzs_003D + 1) * 3 + num3] = 1f;
			array2[num3] = 1f;
			num3++;
			array2[(_0023_003DzuiOvIzs_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
			array2[(_0023_003DzuiOvIzs_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
		}
		num2 = 0;
		int[] array3 = new int[_0023_003DzuiOvIzs_003D * (num - 1) * 3 * 2];
		for (int j = 0; j < num - 1; j++)
		{
			for (int k = 0; k < _0023_003DzuiOvIzs_003D; k++)
			{
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * j;
				array3[num2++] = k + 1 + (_0023_003DzuiOvIzs_003D + 1) * j;
				array3[num2++] = k + 1 + (_0023_003DzuiOvIzs_003D + 1) * (j + 1);
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * j;
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * (j + 1) + 1;
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * (j + 1);
			}
		}
		FastMesh fastMesh = new FastMesh();
		fastMesh.PointArray = array;
		fastMesh.NormalArray = array2;
		fastMesh.TriangleArray = array3;
		fastMesh.ColorMethod = ColorMethod;
		fastMesh.Color = Color;
		fastMesh.UpdateBoundingBox(null);
		fastMesh.RegenMode = regenType.CompileOnly;
		return fastMesh;
	}

	internal FastMesh _0023_003DzKFgdn6kfyOkDnAR_0024gQ_003D_003D(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, float[] _0023_003DzUXasvLLbY71v, float _0023_003Dz89Mrb8s_003D)
	{
		int num = 2;
		float[] array = new float[(_0023_003DzuiOvIzs_003D + 1) * num * 3];
		float[] array2 = new float[(_0023_003DzuiOvIzs_003D + 1) * num * 3];
		new Point2D();
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < _0023_003DzuiOvIzs_003D + 1; i++)
		{
			array[(_0023_003DzuiOvIzs_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			array[num2] = _0023_003DzUXasvLLbY71v[i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			num2++;
			array[(_0023_003DzuiOvIzs_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[1 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			array[num2] = _0023_003DzUXasvLLbY71v[1 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			num2++;
			array[(_0023_003DzuiOvIzs_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[2 + i * (_0023_003Dz1IBya9M_003D + 1) * 3];
			array[num2] = _0023_003Dz89Mrb8s_003D;
			num2++;
			array2[(_0023_003DzuiOvIzs_003D + 1) * 3 + num3] = -1f;
			array2[num3] = -1f;
			num3++;
			array2[(_0023_003DzuiOvIzs_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
			array2[(_0023_003DzuiOvIzs_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
		}
		num2 = 0;
		int[] array3 = new int[_0023_003DzuiOvIzs_003D * (num - 1) * 3 * 2];
		for (int j = 0; j < num - 1; j++)
		{
			for (int k = 0; k < _0023_003DzuiOvIzs_003D; k++)
			{
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * j;
				array3[num2++] = k + 1 + (_0023_003DzuiOvIzs_003D + 1) * (j + 1);
				array3[num2++] = k + 1 + (_0023_003DzuiOvIzs_003D + 1) * j;
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * j;
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * (j + 1);
				array3[num2++] = k + (_0023_003DzuiOvIzs_003D + 1) * (j + 1) + 1;
			}
		}
		FastMesh fastMesh = new FastMesh();
		fastMesh.PointArray = array;
		fastMesh.NormalArray = array2;
		fastMesh.TriangleArray = array3;
		fastMesh.ColorMethod = ColorMethod;
		fastMesh.Color = Color;
		fastMesh.UpdateBoundingBox(null);
		fastMesh.RegenMode = regenType.CompileOnly;
		return fastMesh;
	}

	internal FastMesh _0023_003DzKizrqOWvPQ_0024V7I1WcQ_003D_003D(int _0023_003Dz1IBya9M_003D, int _0023_003DzuiOvIzs_003D, float[] _0023_003DzUXasvLLbY71v, float _0023_003Dz89Mrb8s_003D)
	{
		int num = 2;
		float[] array = new float[(_0023_003Dz1IBya9M_003D + 1) * num * 3];
		float[] array2 = new float[(_0023_003Dz1IBya9M_003D + 1) * num * 3];
		new Point2D();
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i <= _0023_003Dz1IBya9M_003D; i++)
		{
			array[(_0023_003Dz1IBya9M_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[num2 + (_0023_003Dz1IBya9M_003D + 1) * 3 * _0023_003DzuiOvIzs_003D];
			array[num2] = _0023_003DzUXasvLLbY71v[num2 + (_0023_003Dz1IBya9M_003D + 1) * 3 * _0023_003DzuiOvIzs_003D];
			num2++;
			array[(_0023_003Dz1IBya9M_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[num2 + (_0023_003Dz1IBya9M_003D + 1) * 3 * _0023_003DzuiOvIzs_003D];
			array[num2] = _0023_003DzUXasvLLbY71v[num2 + (_0023_003Dz1IBya9M_003D + 1) * 3 * _0023_003DzuiOvIzs_003D];
			num2++;
			array[(_0023_003Dz1IBya9M_003D + 1) * 3 + num2] = _0023_003DzUXasvLLbY71v[num2 + (_0023_003Dz1IBya9M_003D + 1) * 3 * _0023_003DzuiOvIzs_003D];
			array[num2] = _0023_003Dz89Mrb8s_003D;
			num2++;
			array2[(_0023_003Dz1IBya9M_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
			array2[(_0023_003Dz1IBya9M_003D + 1) * 3 + num3] = 1f;
			array2[num3] = 1f;
			num3++;
			array2[(_0023_003Dz1IBya9M_003D + 1) * 3 + num3] = 0f;
			array2[num3] = 0f;
			num3++;
		}
		num2 = 0;
		int[] array3 = new int[_0023_003Dz1IBya9M_003D * (num - 1) * 3 * 2];
		for (int j = 0; j < num - 1; j++)
		{
			for (int k = 0; k < _0023_003Dz1IBya9M_003D; k++)
			{
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * j;
				array3[num2++] = k + 1 + (_0023_003Dz1IBya9M_003D + 1) * (j + 1);
				array3[num2++] = k + 1 + (_0023_003Dz1IBya9M_003D + 1) * j;
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * j;
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * (j + 1);
				array3[num2++] = k + (_0023_003Dz1IBya9M_003D + 1) * (j + 1) + 1;
			}
		}
		FastMesh fastMesh = new FastMesh();
		fastMesh.PointArray = array;
		fastMesh.NormalArray = array2;
		fastMesh.TriangleArray = array3;
		fastMesh.ColorMethod = ColorMethod;
		fastMesh.Color = Color;
		fastMesh.UpdateBoundingBox(null);
		fastMesh.RegenMode = regenType.CompileOnly;
		return fastMesh;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996140);
		Interval zRange = _zRange;
		stringBuilder.AppendLine(text + zRange.ToString());
		return stringBuilder.ToString();
	}

	public override void Dispose()
	{
		base.Dispose();
		_mesh?.Dispose();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new StockSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996064), _zRange);
	}

	private void _0023_003Dzcfj4z1PXF0TmXt2nGMHroC1hJYevQiNVjA_003D_003D(RenderContextBase _0023_003DzRpXgovo_003D)
	{
		_0023_003DzRpXgovo_003D.Draw(_mesh.drawData);
	}
}
