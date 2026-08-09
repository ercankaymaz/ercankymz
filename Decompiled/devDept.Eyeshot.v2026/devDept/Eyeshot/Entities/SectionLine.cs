using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class SectionLine : Text
{
	private double _angle;

	private Point3D _endPoint;

	private arrowheadType _arrowHead;

	private bool _showArrowHead = true;

	private double _arrowHeadSize;

	private Vector3D _startEnd;

	private Vector3D _perpendicular;

	public bool ShowArrowHead
	{
		get
		{
			return _showArrowHead;
		}
		set
		{
			_showArrowHead = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double ArrowHeadSize
	{
		get
		{
			return _arrowHeadSize;
		}
		set
		{
			_arrowHeadSize = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Point3D EndPoint
	{
		get
		{
			return _endPoint;
		}
		set
		{
			_endPoint = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public SectionLine(double x1, double y1, double x2, double y2, string textString, double textHeight)
		: base(Plane.XY, new Point2D(x1, y1), textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(new Point3D(x2, y2, 0.0));
	}

	public SectionLine(Point2D startPoint, Point2D endPoint, string textString, double textHeight)
		: base(Plane.XY, startPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(new Point3D(endPoint.X, endPoint.Y, 0.0));
	}

	public SectionLine(Plane sketchPlane, Point2D startPoint, Point2D endPoint, string textString, double textHeight)
		: base(sketchPlane, startPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(sketchPlane.PointAt(endPoint));
	}

	public SectionLine(Plane plane, Point3D startPoint, Point3D endPoint, string textString, double textHeight)
		: base(plane, startPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(endPoint);
	}

	protected SectionLine(SectionLine another)
		: base(another)
	{
		_endPoint = another._endPoint;
		_arrowHead = another._arrowHead;
		_arrowHeadSize = another._arrowHeadSize;
		_showArrowHead = another._showArrowHead;
	}

	protected internal SectionLine(SectionLineSurrogate surrogate)
		: this(surrogate.Plane, surrogate.Plane.Origin, surrogate.EndPoint, surrogate.TextString, surrogate.Height)
	{
	}

	protected SectionLine(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		ArrowHeadSize = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360));
		ShowArrowHead = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956330));
		_endPoint = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), typeof(Point3D));
	}

	private void _0023_003DztGdcVOA_003D(Point3D _0023_003DzMnu3zKCWb6Kc)
	{
		_endPoint = _0023_003DzMnu3zKCWb6Kc;
		_arrowHeadSize = height;
		alignment = alignmentType.MiddleCenter;
	}

	public override object Clone()
	{
		return new SectionLine(this);
	}

	private void _0023_003DzDRltr_0024tq410iEbjI0g_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.IsDirect3D)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PushShader();
			if (_0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth > 1f)
			{
				_0023_003DzELu0Pss_003D.RenderContext.EnableThickLines();
			}
		}
	}

	private void _0023_003DzJRtNwJRRVQc52IQRig_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.IsDirect3D)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PopShader();
		}
	}

	protected new void PostDraw(DrawParams data)
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
		double scaleFactorX = xform.ScaleFactorX;
		if (Math.Abs(scaleFactorX) != 1.0)
		{
			ArrowHeadSize *= scaleFactorX;
		}
		_endPoint.TransformBy(xform);
		base.TransformBy(xform);
	}

	private protected override void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
	{
		_0023_003DzCzO2MCm1TY7s_0024NMWgokejf0_003D();
		base._0023_003Dzl_SRSHmkyuNv(_0023_003DzLS0sR0pzioXc);
		_0023_003Dz3_RK3NySGSUi();
	}

	public override void Regen(RegenParams data)
	{
		if (CheckRegenParams(data))
		{
			base.Regen(data);
			_0023_003DzCzO2MCm1TY7s_0024NMWgokejf0_003D();
			Point3D[] array = (Point3D[])_vertices.Clone();
			_vertices = new Point3D[array.Length * 2 + 8];
			for (int i = 0; i < array.Length; i++)
			{
				_vertices[i] = array[i] + _perpendicular;
			}
			_0023_003DzneRwnSgCYwNUteM3_0024PjwC8s_003D(array.Length);
			Vector3D vector3D = (Vector3D)_perpendicular.Clone();
			vector3D.Normalize();
			vector3D *= ArrowHeadSize * 2.0;
			_vertices[_vertices.Length - 8] = base.Plane.Origin - _startEnd * ArrowHeadSize;
			_vertices[_vertices.Length - 7] = _endPoint + _startEnd * ArrowHeadSize;
			_vertices[_vertices.Length - 6] = (Point3D)base.Plane.Origin.Clone();
			_vertices[_vertices.Length - 5] = base.Plane.Origin + vector3D;
			_vertices[_vertices.Length - 4] = (Point3D)_endPoint.Clone();
			_vertices[_vertices.Length - 3] = _endPoint + vector3D;
			_vertices[_vertices.Length - 2] = base.Plane.Origin + _startEnd * ArrowHeadSize;
			_vertices[_vertices.Length - 1] = _endPoint - _startEnd * ArrowHeadSize;
			_0023_003Dz3_RK3NySGSUi();
			UpdateBoundingBox(data);
			RegenMode = regenType.CompileOnly;
		}
	}

	private void _0023_003DzneRwnSgCYwNUteM3_0024PjwC8s_003D(int _0023_003DzV1JTeIBuIS2zZYokeLYd4S0_003D)
	{
		double num = _endPoint.X - base.Plane.Origin.X;
		double num2 = _endPoint.Y - base.Plane.Origin.Y;
		double num3 = _endPoint.Z - base.Plane.Origin.Z;
		for (int i = 0; i < _0023_003DzV1JTeIBuIS2zZYokeLYd4S0_003D; i++)
		{
			_vertices[i + _0023_003DzV1JTeIBuIS2zZYokeLYd4S0_003D] = new Point3D(_vertices[i].X + num, _vertices[i].Y + num2, _vertices[i].Z + num3);
		}
	}

	private void _0023_003Dz3_RK3NySGSUi()
	{
		Point2D point2D = base.Plane.Project(base.Plane.Origin);
		Point2D point2D2 = base.Plane.Project(_endPoint);
		_angle = Math.Atan2(point2D.Y - point2D2.Y, point2D.X - point2D2.X);
		if (_angle < 0.0)
		{
			_angle += Math.PI * 2.0;
		}
	}

	private void _0023_003DzCzO2MCm1TY7s_0024NMWgokejf0_003D()
	{
		_startEnd = new Vector3D(base.Plane.Origin, _endPoint);
		_startEnd.Normalize();
		_perpendicular = (Vector3D)_startEnd.Clone();
		_perpendicular.TransformBy(Transformation.CreateRotation(-Math.PI / 2.0, base.Plane.AxisZ));
		_perpendicular *= height + ArrowHeadSize * 2.0;
	}

	protected override void DrawWire(DrawParams data)
	{
		_0023_003DzDRltr_0024tq410iEbjI0g_003D_003D(data);
		if (!data.LineTypes.TryGetValue(data.Attributes?.LineTypeName, out var value) || !_0023_003DzVmP7M1MzcRAi(data, value))
		{
			data.RenderContext.DrawBufferedLine(_vertices[14], _vertices[15]);
		}
		_0023_003DzJRtNwJRRVQc52IQRig_003D_003D(data);
	}

	private protected override void _0023_003DzcbxI7LvTjkOHwnPzLg_003D_003D(DrawParams _0023_003DzELu0Pss_003D, LineType _0023_003DzhC3Yby0_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		base._0023_003DzcbxI7LvTjkOHwnPzLg_003D_003D(_0023_003DzELu0Pss_003D, _0023_003DzhC3Yby0_003D, new Point3D[2]
		{
			_vertices[14],
			_vertices[15]
		});
	}

	protected internal override void Draw(DrawParams data)
	{
		_0023_003Dz0AKy2urG8Vm2(data, _0023_003Dzjrk7FZSkkMDSr5VHWA_003D_003D: true);
		data.RenderContext.PushModelView();
		data.RenderContext.TranslateMatrixModelView(_perpendicular.X, _perpendicular.Y, _perpendicular.Z);
		base.Draw(data);
		data.RenderContext.TranslateMatrixModelView(_endPoint.X - base.Plane.Origin.X, _endPoint.Y - base.Plane.Origin.Y, _endPoint.Z - base.Plane.Origin.Z);
		base.Draw(data);
		data.RenderContext.PopModelView();
		DrawWire(data);
		float currentLineWidth = data.RenderContext.CurrentLineWidth;
		data.RenderContext.SetLineSize(Math.Max(currentLineWidth * 2f, 2f));
		data.RenderContext.DrawLine(_vertices[8], _vertices[14]);
		data.RenderContext.DrawLine(_vertices[15], _vertices[9]);
		data.RenderContext.SetLineSize(currentLineWidth);
	}

	protected override void DrawSimplified(RenderContextBase context)
	{
	}

	private void _0023_003Dz0AKy2urG8Vm2(DrawParams _0023_003DzELu0Pss_003D, bool _0023_003Dzjrk7FZSkkMDSr5VHWA_003D_003D)
	{
		PreDraw(_0023_003DzELu0Pss_003D, _0023_003Dzjrk7FZSkkMDSr5VHWA_003D_003D);
		_0023_003DzELu0Pss_003D.RenderContext.PushMatrices();
		if (_0023_003DzELu0Pss_003D.RenderContext.IsDirect3D)
		{
			_0023_003DzDRltr_0024tq410iEbjI0g_003D_003D(_0023_003DzELu0Pss_003D);
			DrawEntity(_0023_003DzELu0Pss_003D.RenderContext, _0023_003DzELu0Pss_003D);
			_0023_003DzJRtNwJRRVQc52IQRig_003D_003D(_0023_003DzELu0Pss_003D);
		}
		else
		{
			DrawEntity(_0023_003DzELu0Pss_003D.RenderContext, _0023_003DzELu0Pss_003D);
		}
		_0023_003DzELu0Pss_003D.RenderContext.PopMatrices();
		PostDraw(_0023_003DzELu0Pss_003D);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (base.Compiling)
		{
			context.DrawLine(_vertices[10], _vertices[11]);
			context.DrawLine(_vertices[12], _vertices[13]);
			context.DrawLine(_vertices[8], _vertices[14]);
			context.DrawLine(_vertices[9], _vertices[15]);
		}
		else
		{
			drawData.DrawBuffer(context, 0);
			drawData.DrawBuffer(context, 1);
			drawData.DrawBuffer(context, 2);
			drawData.DrawBuffer(context, 3);
		}
		if (ShowArrowHead)
		{
			context.PushMatrices();
			Transformation transform = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
			context.PushModelView();
			context.MultMatrixModelView(transform);
			DrawArrow(context);
			context.PopModelView();
			context.PushModelView();
			context.TranslateMatrixModelView(_endPoint.X - base.Plane.Origin.X, _endPoint.Y - base.Plane.Origin.Y, _endPoint.Z - base.Plane.Origin.Z);
			context.MultMatrixModelView(transform);
			DrawArrow(context);
			context.PopModelView();
			context.PopMatrices();
		}
	}

	protected internal override void Render(RenderParams data)
	{
		Transformation blockRefTransform = null;
		if (data.RenderContext.Shaders != null)
		{
			blockRefTransform = data.ShaderParams.BlockRefTransform;
			Transformation transform = base.Transform;
			data.ShaderParams.BlockRefTransform *= transform;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
		base.Render(data);
		if (data.RenderContext.Shaders != null)
		{
			data.ShaderParams.BlockRefTransform = blockRefTransform;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		if (data.CompileWires)
		{
			CompilePattern(data);
		}
		base.Compile(data);
	}

	protected override void DrawWithPattern(RenderContextBase renderContext, object myParams)
	{
		CompileParams compileParams = (CompileParams)myParams;
		compileParams.LineType.GetPatternVertices(compileParams.MaxPatternRepetitions, new Point3D[2]
		{
			_vertices[14],
			_vertices[15]
		}, LineTypeScale * compileParams.LineTypeScale, out var lines, out var points);
		compileParams.RenderContext.DrawLinesAndPoints(lines.ToArray(), points.ToArray());
	}

	protected void DrawArrow(RenderContextBase context)
	{
		context.PushModelView();
		float currentLineWidth = context.CurrentLineWidth;
		if (context.CurrentLineWidth > 1f && context.IsDirect3D)
		{
			context.SetLineSize(1f);
		}
		context.MultMatrixModelView(GetArrowHeadTransformation());
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzySK4JX4gwaSvQLZwafPBUrg_003D(context, drawData, ArrowHeadSize, base.Compiling);
		if (context.IsDirect3D)
		{
			context.SetLineSize(currentLineWidth);
		}
		context.PopModelView();
	}

	protected virtual Transformation GetArrowHeadTransformation()
	{
		return new Rotation(_angle + Math.PI / 2.0, new Vector3D(0.0, 0.0, 1.0));
	}

	internal void _0023_003DzAqQbug4_003D(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_vertices != null)
		{
			list.Add(_vertices[8]);
			list.Add(_vertices[9]);
			list.Add(_vertices[10]);
			list.Add(_vertices[11]);
			list.Add(_vertices[12]);
			list.Add(_vertices[13]);
			list.Add(_vertices[14]);
			list.Add(_vertices[15]);
		}
		if (!_0023_003DzzGo2_Wb1L5us)
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA = new Rotation(_angle, new Vector3D(0.0, 0.0, 1.0));
			Point3D[] collection = _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003Dz7tEgWrFHxteq(_arrowHead, base.Plane, _0023_003Dz9ZUzIX4xmsyA, ArrowHeadSize, _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D: false, _0023_003DzEXLcE10_003D: false);
			list.AddRange(collection);
		}
		if (!_0023_003DzzGo2_Wb1L5us || _0023_003DzFM3KC0w_003D.TextStyles[base.StyleName].IsSHX())
		{
			_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D = GetOutlines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFM3KC0w_003D);
		}
		else
		{
			_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D = null;
		}
		_0023_003DzyIUKu5w_003D = list.ToArray();
	}

	internal override Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_arrowHead != arrowheadType.Oblique && ShowArrowHead)
		{
			Transformation arrowHeadTransformation = GetArrowHeadTransformation();
			List<Point3D> first = _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzQvPWxyC95069Svh7qQVH_ZY_003D(_arrowHead, new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY), arrowHeadTransformation, ArrowHeadSize, _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D: false, _0023_003DzEXLcE10_003D: false).ToList();
			List<Point3D> second = _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzQvPWxyC95069Svh7qQVH_ZY_003D(_arrowHead, new Plane(_endPoint, base.Plane.AxisX, base.Plane.AxisY), arrowHeadTransformation, ArrowHeadSize, _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D: false, _0023_003DzEXLcE10_003D: false).ToList();
			list = first.Concat(second).ToList();
		}
		if (_0023_003DzFM3KC0w_003D == null)
		{
			return new Point3D[1][] { list.ToArray() };
		}
		Point3D[][] array = _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix());
		Point3D[][] array2 = _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix());
		Point3D[][] array3 = new Point3D[array.Length + array2.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			array3[i] = array[i];
		}
		for (int j = 0; j < array2.Length; j++)
		{
			array3[j + array.Length] = array2[j];
			for (int k = 0; k < array2[j].Length; k++)
			{
				array3[j + array.Length][k].TransformBy(Transformation.CreateTranslation(new Vector3D(base.Plane.Origin, EndPoint)));
			}
		}
		for (int l = 0; l < array3.Length; l++)
		{
			for (int m = 0; m < array3[l].Length; m++)
			{
				array3[l][m].TransformBy(Transformation.CreateTranslation(_perpendicular));
			}
		}
		return _0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(array3, list.ToArray());
	}

	internal static Point3D[][] _0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(Point3D[][] _0023_003DznTMMDLcTw5Mi, Point3D[] _0023_003DzODmzqhKgfV9FgRqr5pymjR475kPj)
	{
		Point3D[][] array = new Point3D[_0023_003DznTMMDLcTw5Mi.GetLength(0) + 1][];
		int i;
		for (i = 0; i < _0023_003DznTMMDLcTw5Mi.GetLength(0); i++)
		{
			array[i] = _0023_003DznTMMDLcTw5Mi[i];
		}
		array[i] = _0023_003DzODmzqhKgfV9FgRqr5pymjR475kPj;
		return array;
	}

	protected internal override Point3D[] GetTextRectangleVertices()
	{
		Point3D[] textRectangleVertices = base.GetTextRectangleVertices();
		for (int i = 0; i < textRectangleVertices.Length; i++)
		{
			textRectangleVertices[i].TransformBy(Transformation.CreateTranslation(_perpendicular));
		}
		Point3D[] array = new Point3D[textRectangleVertices.Length];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = (Point3D)textRectangleVertices[j].Clone();
			array[j].TransformBy(Transformation.CreateTranslation(new Vector3D(base.Plane.Origin, _endPoint)));
		}
		return textRectangleVertices.Concat(array).ToArray();
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2]
			{
				base.Plane.Origin,
				EndPoint
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956065) + InsertionPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956056) + _endPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956152) + ArrowHeadSize);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956144) + ShowArrowHead);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new SectionLineSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), InsertionPoint);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360), ArrowHeadSize);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956330), ShowArrowHead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), _endPoint);
	}

	public Entity[] Explode(LayerKeyedCollection layers = null, double? parentLineWeight = null)
	{
		Entity[] array = new Entity[9];
		float num = LineWeight;
		if (layers != null)
		{
			num = (float)GetLineWeight(layers, parentLineWeight);
		}
		array[0] = new Line(_vertices[8], _vertices[14]);
		array[1] = new Line(_vertices[15], _vertices[9]);
		array[2] = new Line(_vertices[10], _vertices[11]);
		array[3] = new Line(_vertices[12], _vertices[13]);
		array[4] = new Line(_vertices[14], _vertices[15]);
		Vector3D vector3D = new Vector3D(_vertices[10], _vertices[11]);
		vector3D /= 2.0;
		Vector3D vector3D2 = (Vector3D)vector3D.Clone();
		vector3D2 /= 4.0;
		vector3D2.TransformBy(Transformation.CreateRotation(Math.PI / 2.0, base.Plane.AxisZ));
		array[5] = new Triangle(_vertices[10], _vertices[10] + vector3D - vector3D2, _vertices[10] + vector3D + vector3D2);
		array[6] = new Triangle(_vertices[12], _vertices[12] + vector3D - vector3D2, _vertices[12] + vector3D + vector3D2);
		array[7] = new Text(base.Plane, (_vertices[0] + _vertices[2]) / 2.0, TextString, base.Height, alignmentType.MiddleCenter);
		array[8] = new Text(base.Plane, (_vertices[4] + _vertices[6]) / 2.0, TextString, base.Height, alignmentType.MiddleCenter);
		Entity[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].CopyAttributes(this);
		}
		for (int j = 0; j <= 3; j++)
		{
			array[j].LineTypeName = null;
			array[j].LineTypeMethod = colorMethodType.byEntity;
		}
		array[0].LineWeight = Math.Max(num * 2f, 2f);
		array[0].LineWeightMethod = colorMethodType.byEntity;
		array[1].LineWeight = Math.Max(num * 2f, 2f);
		array[1].LineWeightMethod = colorMethodType.byEntity;
		return array;
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, new Point3D[2]
		{
			_vertices[8],
			_vertices[14]
		}, 2, 1) || Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, new Point3D[2]
		{
			_vertices[9],
			_vertices[15]
		}, 2, 1) || Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, new Point3D[2]
		{
			_vertices[10],
			_vertices[11]
		}, 2, 1) || Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, new Point3D[2]
		{
			_vertices[12],
			_vertices[13]
		}, 2, 1) || _0023_003DzNkb6VJVWhexf5w96czyl0gp4gs8n7Yk8LA_003D_003D(data, new Point3D[2]
		{
			_vertices[14],
			_vertices[15]
		}))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, new Point3D[2]
		{
			_vertices[8],
			_vertices[14]
		}, 2, 1) || Entity.InsideOrCrossingScreenPolygonInternal(data, new Point3D[2]
		{
			_vertices[9],
			_vertices[15]
		}, 2, 1) || Entity.InsideOrCrossingScreenPolygonInternal(data, new Point3D[2]
		{
			_vertices[10],
			_vertices[11]
		}, 2, 1) || Entity.InsideOrCrossingScreenPolygonInternal(data, new Point3D[2]
		{
			_vertices[12],
			_vertices[13]
		}, 2, 1) || _0023_003DzcFr63eaiASa3_0024hOEHoERiJm809TR(data, new Point3D[2]
		{
			_vertices[14],
			_vertices[15]
		}))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	private bool _0023_003DzcFr63eaiASa3_0024hOEHoERiJm809TR(ScreenPolygonParams _0023_003DzELu0Pss_003D, Point3D[] _0023_003DzrdSL0CI_003D)
	{
		_0023_003DzELu0Pss_003D.LineType = GetLineType(_0023_003DzELu0Pss_003D.Document.LineTypes, _0023_003DzELu0Pss_003D.Document.Layers, _0023_003DzELu0Pss_003D.ParentLineType);
		if (IsValidPatternByScreenToWorld(_0023_003DzELu0Pss_003D.LineType, _0023_003DzELu0Pss_003D.ScreenToWorld))
		{
			_0023_003DzELu0Pss_003D.LineType.GetPatternVertices(_0023_003DzELu0Pss_003D.MaxPatternRepetitions, _0023_003DzrdSL0CI_003D, LineTypeScale * _0023_003DzELu0Pss_003D.Document.LineTypeScale, out var lines, out var points);
			if (Entity.InsideOrCrossingScreenPolygonInternal(_0023_003DzELu0Pss_003D, lines, lines.Count, 2) || Entity.InsideOrCrossingScreenPolygonPoint(_0023_003DzELu0Pss_003D, points, points.Count))
			{
				AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
				return true;
			}
			return false;
		}
		if (Entity.InsideOrCrossingScreenPolygonInternal(_0023_003DzELu0Pss_003D, _0023_003DzrdSL0CI_003D, _0023_003DzrdSL0CI_003D.Length, 1))
		{
			AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
			return true;
		}
		return false;
	}

	private bool _0023_003DzNkb6VJVWhexf5w96czyl0gp4gs8n7Yk8LA_003D_003D(FrustumParams _0023_003DzELu0Pss_003D, Point3D[] _0023_003DzrdSL0CI_003D)
	{
		_0023_003DzELu0Pss_003D.LineType = GetLineType(_0023_003DzELu0Pss_003D.Document.LineTypes, _0023_003DzELu0Pss_003D.Document.Layers, _0023_003DzELu0Pss_003D.ParentLineType);
		if (IsValidPatternByScreenToWorld(_0023_003DzELu0Pss_003D.LineType, _0023_003DzELu0Pss_003D.ScreenToWorld))
		{
			_0023_003DzELu0Pss_003D.LineType.GetPatternVertices(_0023_003DzELu0Pss_003D.MaxPatternRepetitions, _0023_003DzrdSL0CI_003D, LineTypeScale * _0023_003DzELu0Pss_003D.Document.LineTypeScale, out var lines, out var points);
			if (Entity.InsideOrCrossingFrustumInternal(_0023_003DzELu0Pss_003D.Frustum, _0023_003DzELu0Pss_003D.Transformation, lines, lines.Count, 2) || Entity.InsideFrustumPoint(_0023_003DzELu0Pss_003D.Frustum, _0023_003DzELu0Pss_003D.Transformation, points, points.Count))
			{
				AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
				return true;
			}
			return false;
		}
		if (Entity.InsideOrCrossingFrustumInternal(_0023_003DzELu0Pss_003D.Frustum, _0023_003DzELu0Pss_003D.Transformation, _0023_003DzrdSL0CI_003D, _0023_003DzrdSL0CI_003D.Length, 1))
		{
			AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity.ThroughTriangleQuad(data, _vertices.Take(4).ToArray()) || Entity.ThroughTriangleQuad(data, _vertices.Skip(4).Take(4).ToArray()))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.ThroughTriangleScreenPolygonQuad(_vertices.Take(4).ToArray(), data) || Entity.ThroughTriangleScreenPolygonQuad(_vertices.Skip(4).Take(4).ToArray(), data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}
}
