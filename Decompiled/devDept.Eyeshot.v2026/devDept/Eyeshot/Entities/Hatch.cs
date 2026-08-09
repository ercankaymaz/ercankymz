using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Hatch : PlanarEntity, ITriangles
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<byte, int> _0023_003Dz6gM36XYyNu4Gy2rPhQ_003D_003D;

		internal int _0023_003Dz_s7qnlcOSIyRRLN41Xm9_0024LA_003D(byte _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D;
		}
	}

	public const string SolidPatternName = "SOLID";

	internal List<ICurve> contourList;

	private float _patternScale = 1f;

	private double _patternAngle;

	private string _patternName;

	private Point2D _patternOrigin = Point2D.Origin;

	private double _patternSpacing;

	private bool _patternDouble;

	private bool _isUserDefinedPattern;

	internal Point3D[] patternLines;

	internal Point3D[] patternPoints;

	private IndexTriangle[] _triangles;

	public IndexTriangle[] Triangles
	{
		get
		{
			return _triangles;
		}
		set
		{
			_triangles = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public List<ICurve> ContourList
	{
		get
		{
			return contourList;
		}
		set
		{
			contourList = value;
			_0023_003DztGdcVOA_003D(PatternName, contourList, null);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public string PatternName
	{
		get
		{
			return _patternName;
		}
		set
		{
			_patternName = value;
			base.entityNature = ((_patternName == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485)) ? entityNatureType.Polygon : entityNatureType.Wire);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public float PatternScale
	{
		get
		{
			return _patternScale;
		}
		set
		{
			_patternScale = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double PatternAngle
	{
		get
		{
			return _patternAngle;
		}
		set
		{
			_patternAngle = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Point2D PatternOrigin
	{
		get
		{
			return _patternOrigin;
		}
		set
		{
			_patternOrigin = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double PatternSpacing
	{
		get
		{
			return _patternSpacing;
		}
		set
		{
			_patternSpacing = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool PatternDouble
	{
		get
		{
			return _patternDouble;
		}
		set
		{
			_patternDouble = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool IsUserDefinedPattern
	{
		get
		{
			return _isUserDefinedPattern;
		}
		set
		{
			_isUserDefinedPattern = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	protected Hatch(Hatch another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		contourList = new List<ICurve>(another.contourList.Count);
		for (int i = 0; i < another.contourList.Count; i++)
		{
			contourList.Add((ICurve)(keepTessellation ? ((Entity)another.contourList[i]).CloneWithTessellation() : ((Entity)another.contourList[i]).Clone()));
		}
		_patternName = another.PatternName;
		_patternScale = another.PatternScale;
		_patternAngle = another.PatternAngle;
		_patternOrigin = (Point2D)another.PatternOrigin.Clone();
		_patternSpacing = another.PatternSpacing;
		_patternDouble = another.PatternDouble;
		_isUserDefinedPattern = another.IsUserDefinedPattern;
		if (!keepTessellation)
		{
			return;
		}
		if (another.Triangles != null)
		{
			Triangles = Utility._0023_003DzX42kjXfbzdxuD8Dt7A_003D_003D(another.Triangles);
		}
		else if (another.patternLines != null)
		{
			patternLines = new Point3D[another.patternLines.Length];
			for (int j = 0; j < another.patternLines.Length; j++)
			{
				patternLines[j] = (Point3D)another.patternLines[j].Clone();
			}
			patternPoints = new Point3D[another.patternPoints.Length];
			for (int k = 0; k < another.patternPoints.Length; k++)
			{
				patternPoints[k] = (Point3D)another.patternPoints[k].Clone();
			}
		}
		regenMode = regenType.CompileOnly;
	}

	public Hatch(string patternName, ICurve outer, Plane pln = null)
		: this(patternName, new ICurve[1] { outer }, pln)
	{
	}

	public Hatch(string patternName, IList<ICurve> contours, Plane pln = null)
		: base(pln)
	{
		_0023_003DztGdcVOA_003D(patternName, contours, pln);
	}

	protected Hatch(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		PatternName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970738));
		PatternScale = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970723));
		PatternAngle = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970711));
		PatternOrigin = (Point2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970699), typeof(Point2D));
		PatternSpacing = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970658));
		PatternDouble = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970648));
		IsUserDefinedPattern = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970635));
		contourList = (List<ICurve>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970856), typeof(List<ICurve>));
	}

	internal Hatch(HatchSurrogate _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.PatternName, new List<ICurve>(), _0023_003DzQwa1qM0_003D.Plane)
	{
	}

	private void _0023_003DztGdcVOA_003D(string _0023_003DzS5V6fD8_003D, IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Plane _0023_003Dzpyw2kZk_003D)
	{
		PatternName = _0023_003DzS5V6fD8_003D;
		if (_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count != 0)
		{
			contourList = new List<ICurve>(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count);
			for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
			{
				contourList.Add((ICurve)_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i].Clone());
			}
			if (_0023_003Dzpyw2kZk_003D == null)
			{
				Utility.ComputeBoundingBox(EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
				double tol = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
				base.Plane = Region.EstimatePlane(contourList, tol);
			}
			else
			{
				base.Plane = (Plane)_0023_003Dzpyw2kZk_003D.Clone();
			}
		}
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970738), PatternName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970723), PatternScale);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970711), PatternAngle);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970699), PatternOrigin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970658), PatternSpacing);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970648), PatternDouble);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970635), IsUserDefinedPattern);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970856), ContourList);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new HatchSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (!IsSolid())
		{
			if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && patternLines != null)
			{
				return patternPoints != null;
			}
			return false;
		}
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && Triangles != null)
		{
			return Triangles.Length != 0;
		}
		return false;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970841) + PatternName);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970831) + PatternAngle);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970792) + PatternScale);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970781) + PatternOrigin);
		return stringBuilder.ToString();
	}

	internal bool IsSolid()
	{
		return base.entityNature == entityNatureType.Polygon;
	}

	public override void Regen(double deviation)
	{
		if (PatternName != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970465));
		}
		base.Regen(deviation);
	}

	public override void Regen(RegenParams data)
	{
		bool flag = PatternName == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485);
		Point3D[][] array = new Point3D[contourList.Count][];
		Point3D point3D = null;
		Point3D point3D2 = null;
		for (int i = 0; i < contourList.Count; i++)
		{
			Entity entity = (Entity)contourList[i];
			entity.Regen(data);
			array[i] = entity.Vertices;
			if (point3D == null)
			{
				point3D = entity.BoxMin;
				point3D2 = entity.BoxMax;
			}
			else if (entity.BoxMin != null)
			{
				Utility.UpdateMinMaxQuick(entity.BoxMin, point3D, point3D2);
				Utility.UpdateMinMaxQuick(entity.BoxMax, point3D, point3D2);
			}
		}
		if (point3D2 == null)
		{
			return;
		}
		double domainSize = point3D2.DistanceTo(point3D);
		if (!flag)
		{
			if (data.Document == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970600));
			}
			List<Point3D> list = new List<Point3D>();
			for (int j = 0; j < array.Length; j++)
			{
				Point3D[] array2 = array[j];
				bool flag2 = Point3D.AreEqual(array2[0], array2[^1], domainSize);
				for (int k = 0; k < array2.Length - (flag2 ? 1 : 0); k++)
				{
					list.Add(array2[k]);
				}
				if (!flag2)
				{
					Array.Resize(ref array[j], array[j].Length + 1);
					array[j][array[j].Length - 1] = (Point3D)array2[0].Clone();
				}
			}
			_vertices = list.ToArray();
			_triangles = null;
			if (_0023_003DzIJvMMMHMmvUn(array, data))
			{
				base.entityNature = entityNatureType.Wire;
			}
			else
			{
				base.entityNature = entityNatureType.Polygon;
				flag = true;
			}
		}
		if (flag)
		{
			patternPoints = null;
			List<Point3D> list2 = new List<Point3D>();
			for (int l = 0; l < ContourList.Count; l++)
			{
				Entity entity2 = (Entity)ContourList[l];
				entity2.Regen(data);
				for (int m = 0; m < entity2.Vertices.Length; m++)
				{
					list2.Add(entity2.Vertices[m]);
					list2.Add(entity2.Vertices[(m + 1) % entity2.Vertices.Length]);
				}
			}
			patternLines = list2.ToArray();
			List<Point3D> list3 = new List<Point3D>();
			List<IndexTriangle> list4 = new List<IndexTriangle>();
			for (int n = 0; n < ContourList.Count; n++)
			{
				int count = list3.Count;
				if (array[n].Length >= 3)
				{
					int num = array[n].Length;
					if (Point3D.AreEqual(array[n][0], array[n][num - 1], domainSize))
					{
						num--;
					}
					for (int num2 = 0; num2 < num; num2++)
					{
						list3.Add(array[n][num2]);
					}
					for (int num3 = 1; num3 < num - 1; num3++)
					{
						int num4 = count;
						int num5 = count + num3;
						int num6 = count + num3 + 1;
						list4.Add(Utility.IsOrientedClockwise(list3[num4], list3[num5], list3[num6], base.Plane.AxisZ) ? new IndexTriangle(num4, num6, num5) : new IndexTriangle(num4, num5, num6));
					}
				}
			}
			if (list3.Count == 0)
			{
				for (int num7 = 0; num7 < contourList.Count; num7++)
				{
					if (list3.Count >= 2)
					{
						break;
					}
					for (int num8 = 0; num8 < array[num7].Length; num8++)
					{
						if (list3.Count >= 2)
						{
							break;
						}
						list3.Add(array[num7][num8]);
					}
				}
				_vertices = list3.ToArray();
				_triangles = new IndexTriangle[0];
			}
			_vertices = list3.ToArray();
			_triangles = list4.ToArray();
		}
		localMin = point3D;
		localMax = point3D2;
		UpdateBoundingBoxSphere();
		RegenMode = regenType.CompileOnly;
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		if (!IsSolid())
		{
			data.RenderContext.Compile(drawData, DrawWireEntity, null);
		}
		else
		{
			base.Compile(data);
		}
		RegenMode = regenType.NotNeeded;
	}

	private bool _0023_003DzIJvMMMHMmvUn(Point3D[][] _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, RegenParams _0023_003DzELu0Pss_003D)
	{
		HatchPattern hatchPattern = (IsUserDefinedPattern ? _0023_003Dz6gUxK08I4REJ(PatternSpacing, PatternDouble) : _0023_003DzELu0Pss_003D.Document.HatchPatterns[PatternName]);
		if (hatchPattern.Lines.Length == 0)
		{
			return false;
		}
		if (!hatchPattern._0023_003Dz3QLIG1l0mkXxlcWP0A_003D_003D(this, _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, _0023_003DzELu0Pss_003D, out var _0023_003DzNSmDw08N3j1d, out var _0023_003DzpvQNJPOeOqfy))
		{
			return false;
		}
		patternLines = _0023_003DzNSmDw08N3j1d.ToArray();
		patternPoints = _0023_003DzpvQNJPOeOqfy.ToArray();
		return true;
	}

	private static HatchPattern _0023_003Dz6gUxK08I4REJ(double _0023_003DzQ5O7DL4AOXqU, bool _0023_003DzpZFGz6w_003D)
	{
		HatchPatternLine[] array = new HatchPatternLine[(!_0023_003DzpZFGz6w_003D) ? 1 : 2];
		array[0] = new HatchPatternLine(0.0, Point2D.Origin, 0.0, _0023_003DzQ5O7DL4AOXqU, null);
		if (_0023_003DzpZFGz6w_003D)
		{
			array[1] = new HatchPatternLine(Math.PI / 2.0, Point2D.Origin, 0.0, _0023_003DzQ5O7DL4AOXqU, null);
		}
		return new HatchPattern(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970542), array);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		List<Point3D> list = new List<Point3D>();
		foreach (ICurve contour in contourList)
		{
			list.AddRange(((Entity)contour).EstimateBoundingBox(blocks, layers));
		}
		return list.ToArray();
	}

	public override Mesh ExtrudeAsMesh(double amount, double deviation, Mesh.natureType meshNature)
	{
		throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970522));
	}

	public override Surface ExtrudeAsSurface(double amount)
	{
		throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970522));
	}

	protected internal override void Draw(DrawParams data)
	{
		if (IsSolid())
		{
			RenderContextBase renderContext = data.RenderContext;
			renderContext.PushRasterizerState();
			renderContext.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.None);
			renderContext.PushShader();
			renderContext.PushDepthStencilState();
			renderContext.SetShader(shaderType.NoLights);
			renderContext.SetColorMask(colorMaskFlags.None);
			renderContext.ClearDepthStencil(depthBuffer: false, stencilBuffer: true, 0);
			renderContext.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Never_1_FF_Op_Invert_Keep_Keep);
			renderContext.PushRasterizerState();
			renderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			base.Draw(data);
			renderContext.PopRasterizerState();
			renderContext.PopShader();
			renderContext.SetColorMask(colorMaskFlags.RGBA);
			renderContext.SetState(depthStencilStateType.DepthTestLess_StencilOn_Func_Equal_1_1_Op_Keep_Keep_Keep);
			int num;
			if (renderContext._0023_003DzdJ308q6v_sqSI6Ni5w_003D_003D(out var _0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D))
			{
				num = (renderContext.IsDirect3D ? 1 : 0);
				if (num != 0)
				{
					renderContext.PushShader();
					renderContext.SetShader(_0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D);
				}
			}
			else
			{
				num = 0;
			}
			base.Draw(data);
			if (num != 0)
			{
				renderContext.PopShader();
			}
			renderContext.PopDepthStencilState();
			renderContext.PopRasterizerState();
		}
		else
		{
			base.Draw(data);
		}
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		context.DrawTrianglesPlanar(_vertices, _triangles, base.Plane.AxisZ);
	}

	protected override void DrawWireEntity(RenderContextBase context, object myParams)
	{
		context.DrawLinesAndPoints(patternLines, patternPoints);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (!IsSolid())
		{
			if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, patternLines, patternLines.Length, 2) || Entity.InsideFrustumPoint(data.Frustum, data.Transformation, patternPoints, patternPoints.Length))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
			return false;
		}
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, patternLines, patternLines.Length, 2))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (!IsSolid() && (Entity.InsideOrCrossingScreenPolygonInternal(data, patternLines, patternLines.Length, 2) || Entity.InsideOrCrossingScreenPolygonPoint(data, patternPoints, patternPoints.Length)))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, patternLines, patternLines.Length, 2))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (!IsSolid())
		{
			return false;
		}
		Segment3D[] selectionEdges = data.SelectionEdges;
		for (int i = 0; i < data.SelectionEdges.Length; i++)
		{
			data.SelectionEdges = new Segment3D[1] { data.SelectionEdges[i] };
			Entity._0023_003Dzz3lsBX3i0Rg2(data, _vertices, _triangles, _0023_003DzTymA54q3SWU7: false, out var _0023_003Dzsc0Foo8_003D);
			data.SelectionEdges = selectionEdges;
			if (_0023_003Dzsc0Foo8_003D.Sum((byte _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D) % 2 == 1)
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (!IsSolid())
		{
			return false;
		}
		IList<Point2D> screenPolygon = data.ScreenPolygon;
		foreach (Point2D item in screenPolygon)
		{
			data.ScreenPolygon = new Point2D[5]
			{
				item,
				new Point2D(item.X + 1.0, item.Y),
				new Point2D(item.X + 1.0, item.Y + 1.0),
				new Point2D(item.X, item.Y + 1.0),
				new Point2D(item.X, item.Y)
			};
			Entity._0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(_vertices, _triangles, data, _0023_003DzTymA54q3SWU7: false, out var _0023_003Dzsc0Foo8_003D);
			data.ScreenPolygon = screenPolygon;
			if (_0023_003Dzsc0Foo8_003D.Sum() % 2 == 1)
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	public override void TransformBy(Transformation xform)
	{
		foreach (Entity contour in contourList)
		{
			contour.TransformBy(xform);
		}
		PatternScale = (float)((double)PatternScale * xform.ScaleFactorX);
		PatternOrigin.TransformBy(xform);
		RegenMode = regenType.RegenAndCompile;
		base.TransformBy(xform);
	}

	private protected override void _0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(Transformation _0023_003DzLS0sR0pzioXc, bool _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D)
	{
	}

	public override object Clone()
	{
		return new Hatch(this);
	}

	public override object CloneWithTessellation()
	{
		return new Hatch(this, RegenMode != regenType.RegenAndCompile);
	}

	public Entity[] Explode()
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971259));
		}
		if (IsSolid())
		{
			return new Entity[0];
		}
		Entity[] array = new Entity[patternLines.Length / 2 + patternPoints.Length];
		int num = 0;
		int num2;
		for (num2 = 0; num2 < patternLines.Length - 1; num2++)
		{
			Line line = new Line((Point3D)patternLines[num2].Clone(), (Point3D)patternLines[++num2].Clone());
			Entity.PropagateAttributes(this, line, force: true);
			array[num++] = line;
		}
		for (int i = 0; i < patternPoints.Length; i++)
		{
			Point point = new Point((Point3D)patternPoints[i].Clone());
			Entity.PropagateAttributes(this, point, force: true);
			array[num++] = point;
		}
		return array;
	}
}
