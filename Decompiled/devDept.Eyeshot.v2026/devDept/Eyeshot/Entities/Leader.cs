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
public class Leader : PlanarEntity
{
	internal Point2D Start2D;

	internal double Angle;

	private double _arrowheadSize = 1.0;

	private double _scale = 1.0;

	private arrowheadType _arrowhead;

	public override Point3D[] Vertices
	{
		get
		{
			return _vertices;
		}
		set
		{
			_vertices = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double ArrowheadSize
	{
		get
		{
			return _arrowheadSize;
		}
		set
		{
			_arrowheadSize = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool ShowArrowHead { get; set; } = true;

	public new double Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public arrowheadType Arrowhead
	{
		get
		{
			return _arrowhead;
		}
		set
		{
			_arrowhead = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public Point3D FirstPoint
	{
		get
		{
			if (_vertices != null && _vertices.Length != 0)
			{
				return _vertices[0];
			}
			return null;
		}
	}

	public Point3D LastPoint
	{
		get
		{
			if (_vertices != null && _vertices.Length != 0)
			{
				return _vertices[_vertices.Length - 1];
			}
			return null;
		}
	}

	protected Transformation Transform => PlaneTransform;

	protected Transformation PlaneTransform => new Transformation(FirstPoint, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);

	public Leader(Plane pln, params Point3D[] points)
		: base(pln)
	{
		_0023_003DzXOF_0024I71eUGhxZCzR1w_003D_003D(points);
		_vertices = new Point3D[points.Length];
		points.CopyTo(_vertices, 0);
	}

	public Leader(Plane pln, ICollection<Point3D> points)
		: base(pln)
	{
		_0023_003DzXOF_0024I71eUGhxZCzR1w_003D_003D(points.ToArray());
		_vertices = new Point3D[points.Count];
		points.CopyTo(_vertices, 0);
	}

	public Leader(Plane pln, params Point2D[] points)
		: base(pln)
	{
		_0023_003DzXOF_0024I71eUGhxZCzR1w_003D_003D(points);
		_vertices = new Point3D[points.Length];
		for (int i = 0; i < points.Length; i++)
		{
			_vertices[i] = pln.PointAt(points[i]);
		}
	}

	public Leader(Plane pln, ICollection<Point2D> points)
		: base(pln)
	{
		_0023_003DzXOF_0024I71eUGhxZCzR1w_003D_003D(points.ToArray());
		_vertices = new Point3D[points.Count];
		for (int i = 0; i < points.Count; i++)
		{
			_vertices[i] = pln.PointAt(points.ElementAt(i));
		}
	}

	public Leader(Plane pln, Point3D[] points, bool hasHookLine, bool hookLineOnXDir, arrowheadType arrowhead, double arrowHeadSize, double scale)
		: this(pln, points)
	{
		_arrowheadSize = arrowHeadSize;
		_arrowhead = arrowhead;
		_scale = scale;
		if (hasHookLine)
		{
			_0023_003DzeC_0024NDvz831G7(hookLineOnXDir);
		}
	}

	protected Leader(Leader another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_arrowhead = another.Arrowhead;
		_scale = another.Scale;
		_arrowheadSize = another.ArrowheadSize;
		_vertices = new Point3D[another._vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			_vertices[i] = (Point3D)another._vertices[i].Clone();
		}
		if (keepTessellation)
		{
			Start2D = (Point2D)another.Start2D.Clone();
			Angle = another.Angle;
		}
	}

	protected internal Leader(LeaderSurrogate surrogate)
		: this(surrogate.Plane, surrogate.Vertices)
	{
	}

	protected Leader(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
		base.Plane.Origin = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), typeof(Point3D));
		ArrowheadSize = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360));
		Arrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956520), typeof(arrowheadType));
		Scale = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956350));
		ShowArrowHead = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956330));
		Start2D = (Point2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971737), typeof(Point2D));
		Angle = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971719));
	}

	public override object Clone()
	{
		return new Leader(this);
	}

	public override object CloneWithTessellation()
	{
		return new Leader(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	internal double _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D()
	{
		return ArrowheadSize * Scale;
	}

	private void _0023_003DzeC_0024NDvz831G7(bool _0023_003DzXwBbCz52o0Cb)
	{
		double num = _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D();
		int num2 = _vertices.Length;
		List<Point3D> list = new List<Point3D>();
		Transformation transformation = new Transformation();
		transformation.Rotation(base.Plane, Plane.XY);
		for (int i = 0; i < num2; i++)
		{
			list.Add(transformation * _vertices[i]);
		}
		Point3D item = (Point3D)list[num2 - 1].Clone();
		if (_0023_003DzXwBbCz52o0Cb)
		{
			item += Plane.XY.AxisX * num;
		}
		else
		{
			item -= Plane.XY.AxisX * num;
		}
		list.Insert(num2 - 1, item);
		List<Point3D> list2 = new List<Point3D>();
		for (int j = 0; j < list.Count; j++)
		{
			Point3D item2 = base.Plane.PointAt(list[j]);
			list2.Add(item2);
		}
		_vertices = list2.ToArray();
	}

	public override void Regen(RegenParams data)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(new Plane(FirstPoint, base.Plane.AxisX, base.Plane.AxisY), Plane.XY);
		Start2D = (Point2D)(transformation * _vertices[0]).Clone();
		Point3D point3D = transformation * _vertices[1];
		Angle = Math.Atan2(point3D.Y, point3D.X);
		if (Angle < 0.0)
		{
			Angle += Math.PI * 2.0;
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	public Entity[] Explode()
	{
		List<Entity> list = new List<Entity>();
		LinearPath linearPath = new LinearPath(Vertices);
		Entity.PropagateAttributes(this, linearPath, force: true);
		list.Add(linearPath);
		Point3D[] array = _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D()[0];
		for (int i = 0; i < array.Length; i++)
		{
			Triangle triangle = new Triangle(array[i++], array[i++], array[i]);
			Entity.PropagateAttributes(this, triangle, force: true);
			list.Add(triangle);
		}
		return list.ToArray();
	}

	internal Point3D[] _0023_003DzAqQbug4_003D(bool _0023_003DzzGo2_Wb1L5us)
	{
		List<Point3D> list = new List<Point3D>();
		if (!_0023_003DzzGo2_Wb1L5us)
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA = new Rotation(Angle, new Vector3D(0.0, 0.0, 1.0));
			Point3D[] collection = _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003Dz7tEgWrFHxteq(Arrowhead, base.Plane, _0023_003Dz9ZUzIX4xmsyA, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D: false, _0023_003DzEXLcE10_003D: false);
			list.AddRange(collection);
		}
		for (int i = 0; i < Vertices.Length - 1; i++)
		{
			list.Add(Vertices[i]);
			list.Add(Vertices[i + 1]);
		}
		return list.ToArray();
	}

	internal Point3D[][] _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D()
	{
		Point3D[] array = Array.Empty<Point3D>();
		if (Arrowhead != arrowheadType.Oblique && ShowArrowHead)
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA = new Rotation(Angle, new Vector3D(0.0, 0.0, 1.0));
			array = _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzQvPWxyC95069Svh7qQVH_ZY_003D(Arrowhead, new Plane(FirstPoint, base.Plane.AxisX, base.Plane.AxisY), _0023_003Dz9ZUzIX4xmsyA, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D: false, _0023_003DzEXLcE10_003D: false);
		}
		return new Point3D[1][] { array };
	}

	public static Segment3D[] Preview(Plane pln, Point3D[] points)
	{
		_0023_003DzXOF_0024I71eUGhxZCzR1w_003D_003D(points);
		Segment3D[] array = new Segment3D[points.Length - 1];
		for (int i = 0; i < points.Length - 1; i++)
		{
			array[i] = new Segment3D(points[i], points[i + 1]);
		}
		return array;
	}

	private static void _0023_003DzXOF_0024I71eUGhxZCzR1w_003D_003D(IList<Point2D> _0023_003DzrdSL0CI_003D)
	{
		if (_0023_003DzrdSL0CI_003D == null || _0023_003DzrdSL0CI_003D.Count < 2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971699));
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		DrawLeader(data, disableCulling: true);
	}

	protected internal override void Render(RenderParams data)
	{
		Transformation blockRefTransform = null;
		if (data.RenderContext.Shaders != null)
		{
			blockRefTransform = data.ShaderParams.BlockRefTransform;
			Transformation transform = Transform;
			data.ShaderParams.BlockRefTransform = data.ShaderParams.BlockRefTransform * transform;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
		base.Render(data);
		if (data.RenderContext.Shaders != null)
		{
			data.ShaderParams.BlockRefTransform = blockRefTransform;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
	}

	internal void _0023_003DzDRltr_0024tq410iEbjI0g_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth > 1f)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PushShader();
			_0023_003DzELu0Pss_003D.RenderContext.EnableThickLines();
		}
	}

	internal void _0023_003DzJRtNwJRRVQc52IQRig_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth > 1f)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PopShader();
		}
	}

	protected virtual void DrawLeader(DrawParams data, bool disableCulling)
	{
		PreDraw(data, disableCulling);
		data.RenderContext.PushModelView();
		if (data.RenderContext.IsDirect3D)
		{
			_0023_003DzDRltr_0024tq410iEbjI0g_003D_003D(data);
			DrawEntity(data.RenderContext, null);
			_0023_003DzJRtNwJRRVQc52IQRig_003D_003D(data);
		}
		else
		{
			DrawEntity(data.RenderContext, null);
		}
		data.RenderContext.PopModelView();
		PostDraw(data);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		DrawLeader(data, disableCulling: false);
	}

	protected void PostDraw(DrawParams data)
	{
		data.RenderContext.PopRasterizerState();
	}

	protected void PreDraw(DrawParams data, bool disableCulling)
	{
		data.RenderContext.PushRasterizerState();
		if (data.viewportInternal.parent.Backface.ColorMethod == backfaceColorMethodType.Cull && !disableCulling)
		{
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
		}
		else
		{
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
		}
	}

	public override void TransformBy(Transformation xform)
	{
		if (xform.HasScaling)
		{
			ArrowheadSize *= xform.ScaleFactorX;
		}
		base.TransformBy(xform);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (base.Compiling)
		{
			context.DrawLineStrip(_vertices, 0, _vertices.Length);
		}
		else
		{
			drawData.DrawBuffer(context, 0);
		}
		Transformation transform = new Transformation(FirstPoint, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		context.MultMatrixModelView(transform);
		if (ShowArrowHead)
		{
			DrawArrowHead(context, Arrowhead, Start2D.X, reverse: false);
		}
	}

	protected void DrawArrowHead(RenderContextBase context, arrowheadType arrowhead, double myDistance, bool reverse)
	{
		if (context.CurrentLineWidth > 1f)
		{
			context.SetLineSize(1f);
		}
		context.PushModelView();
		context.MultMatrixModelView(GetArrowHeadTransformation(arrowhead, myDistance));
		switch (arrowhead)
		{
		case arrowheadType.Arrow:
			DrawArrow(context, myDistance, reverse);
			break;
		case arrowheadType.Tick:
			DrawTick(context, myDistance, reverse);
			break;
		case arrowheadType.Dot:
			DrawDot(context, myDistance, reverse);
			break;
		case arrowheadType.Oblique:
			DrawOblique(context, myDistance, reverse);
			break;
		}
		context.PopModelView();
	}

	protected virtual void DrawArrow(RenderContextBase context, double myDistance, bool reverse)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzySK4JX4gwaSvQLZwafPBUrg_003D(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	protected virtual Transformation GetArrowHeadTransformation(arrowheadType arrowhead, double myDistance)
	{
		return arrowhead switch
		{
			arrowheadType.Tick => new Translation(myDistance, 0.0) * new Rotation(Angle + Math.PI / 4.0, new Vector3D(0.0, 0.0, 1.0)), 
			arrowheadType.Dot => new Translation(myDistance, 0.0), 
			arrowheadType.Oblique => new Translation(myDistance, 0.0) * new Rotation(Angle + Math.PI / 4.0, new Vector3D(0.0, 0.0, 1.0)), 
			_ => new Translation(myDistance, 0.0) * new Rotation(Angle, new Vector3D(0.0, 0.0, 1.0)), 
		};
	}

	protected virtual void DrawTick(RenderContextBase context, double myDistance, bool reverse)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzZl3uTZY2SDdp(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	protected virtual void DrawDot(RenderContextBase context, double myDistance, bool reverse)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzT2MIyACvYuZK(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	protected virtual void DrawOblique(RenderContextBase context, double myDistance, bool reverse)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzpFyrpKXLMt3yujRxSw_003D_003D(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956152) + ArrowheadSize);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956101) + _scale);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956144) + ShowArrowHead);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new LeaderSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
		{
			return Start2D != null;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), base.Plane.Origin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360), ArrowheadSize);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956520), Arrowhead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956350), Scale);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956330), ShowArrowHead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971737), Start2D);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971719), Angle);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return Utility.GetSampling(_vertices);
	}
}
