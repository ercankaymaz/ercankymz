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
public class Balloon : Text
{
	public enum balloonStyleType : byte
	{
		None,
		Circular,
		Triangle,
		Box
	}

	private Point2D _start2D;

	private Point2D _end2D;

	private double _angle;

	private Vector3D _leaderDir;

	private Point3D _shapeCenter;

	private double _balloonRadius;

	private Point3D[] _shapeVertices;

	private Point3D _anchorPoint;

	internal Point3D[] textVertices;

	private balloonStyleType _style = balloonStyleType.Circular;

	private bool _showArrowHead = true;

	private int _size = 1;

	private arrowheadType _arrowHead;

	private double _arrowHeadSize = 1.0;

	private double _scale = 1.0;

	public Point3D AnchorPoint
	{
		get
		{
			return _anchorPoint;
		}
		set
		{
			_anchorPoint = value;
		}
	}

	public balloonStyleType Style
	{
		get
		{
			return _style;
		}
		set
		{
			_style = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

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

	public int Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public arrowheadType ArrowHead
	{
		get
		{
			return _arrowHead;
		}
		set
		{
			_arrowHead = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
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

	public Balloon(Point2D insertionPoint, Point2D anchorPoint, string textString, double textHeight)
		: base(Plane.XY, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(new Point3D(anchorPoint.X, anchorPoint.Y, 0.0), 1, arrowheadType.Arrow);
	}

	public Balloon(Point2D insertionPoint, Point2D anchorPoint, string textString, double textHeight, int size)
		: base(Plane.XY, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(new Point3D(anchorPoint.X, anchorPoint.Y, 0.0), size, arrowheadType.Arrow);
	}

	public Balloon(Point2D insertionPoint, Point2D anchorPoint, string textString, double textHeight, int size, arrowheadType arrowhead)
		: base(Plane.XY, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(new Point3D(anchorPoint.X, anchorPoint.Y, 0.0), size, arrowhead);
	}

	public Balloon(Plane plane, Point3D insertionPoint, Point3D anchorPoint, string textString, double textHeight)
		: base(plane, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(anchorPoint, 1, arrowheadType.Arrow);
	}

	public Balloon(Plane plane, Point3D insertionPoint, Point3D anchorPoint, string textString, double textHeight, int size)
		: base(plane, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(anchorPoint, size, arrowheadType.Arrow);
	}

	public Balloon(Plane plane, Point3D insertionPoint, Point3D anchorPoint, string textString, double textHeight, int size, arrowheadType arrowhead)
		: base(plane, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(anchorPoint, size, arrowhead);
	}

	public Balloon(Plane sketchPlane, Point2D insertionPoint, Point2D anchorPoint, string textString, double textHeight)
		: base(sketchPlane, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(sketchPlane.PointAt(anchorPoint), 1, arrowheadType.Arrow);
	}

	public Balloon(Plane sketchPlane, Point2D insertionPoint, Point2D anchorPoint, string textString, double textHeight, int size)
		: base(sketchPlane, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(sketchPlane.PointAt(anchorPoint), size, arrowheadType.Arrow);
	}

	public Balloon(Plane sketchPlane, Point2D insertionPoint, Point2D anchorPoint, string textString, double textHeight, int size, arrowheadType arrowhead)
		: base(sketchPlane, insertionPoint, textString, textHeight)
	{
		_0023_003DztGdcVOA_003D(sketchPlane.PointAt(anchorPoint), size, arrowhead);
	}

	protected Balloon(Balloon another)
		: base(another)
	{
		AnchorPoint = another.AnchorPoint;
		ArrowHead = another.ArrowHead;
		Scale = another.Scale;
		ArrowHeadSize = another.ArrowHeadSize;
		ShowArrowHead = another.ShowArrowHead;
		Style = another.Style;
		Size = another.Size;
	}

	protected internal Balloon(BalloonSurrogate surrogate)
		: this(surrogate.Plane, surrogate.Plane.Origin, surrogate.AnchorPoint, surrogate.TextString, surrogate.Height)
	{
	}

	protected Balloon(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		base.Plane.Origin = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), typeof(Point3D));
		ArrowHeadSize = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360));
		Scale = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956350));
		ShowArrowHead = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956330));
		Style = (balloonStyleType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956318), typeof(balloonStyleType));
		Size = info.GetInt16(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956298));
		AnchorPoint = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956531), typeof(Point3D));
		ArrowHead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956520), typeof(arrowheadType));
	}

	private void _0023_003DztGdcVOA_003D(Point3D _0023_003Dzuci3Jtybajad, int _0023_003Dz14lzA48_003D, arrowheadType _0023_003DznFgbSKJUuB3UbXqTVw_003D_003D)
	{
		_anchorPoint = _0023_003Dzuci3Jtybajad;
		_size = _0023_003Dz14lzA48_003D;
		_arrowHead = _0023_003DznFgbSKJUuB3UbXqTVw_003D_003D;
	}

	public override object Clone()
	{
		return new Balloon(this);
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
		base.TransformBy(xform);
		_anchorPoint.TransformBy(xform);
	}

	private protected override void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
	{
		_shapeCenter.TransformBy(_0023_003DzLS0sR0pzioXc);
		Entity._0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(_shapeVertices, _0023_003DzLS0sR0pzioXc);
		base._0023_003Dzl_SRSHmkyuNv(_0023_003DzLS0sR0pzioXc);
	}

	private void _0023_003DzpbAn5Q5zxlot(RegenParams _0023_003DzELu0Pss_003D)
	{
		_leaderDir = (_shapeCenter - AnchorPoint).AsVector;
		_leaderDir.Normalize();
		_start2D = _0023_003DzTRb0qf8_003D(_0023_003DzELu0Pss_003D);
		_end2D = base.Plane.Project(AnchorPoint);
		_angle = Math.Atan2(_start2D.Y - _end2D.Y, _start2D.X - _end2D.X);
		if (_angle < 0.0)
		{
			_angle += Math.PI * 2.0;
		}
	}

	private Point2D _0023_003DzTRb0qf8_003D(RegenParams _0023_003DzELu0Pss_003D)
	{
		Point3D[] _0023_003DzrdSL0CI_003D = ((Style == balloonStyleType.None) ? _0023_003Dz1eo8C4aog2sScFjxrBa9NUWQh7XF(_0023_003DzELu0Pss_003D) : _shapeVertices);
		return base.Plane.Project(_0023_003Dzk0MlU7qT3L5B0mBq6A_003D_003D(_0023_003DzrdSL0CI_003D));
	}

	private Point3D _0023_003Dzk0MlU7qT3L5B0mBq6A_003D_003D(Point3D[] _0023_003DzrdSL0CI_003D)
	{
		double num = 2147483647.0;
		Point3D result = null;
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Length - 1; i++)
		{
			Point3D a = _0023_003DzrdSL0CI_003D[i];
			Point3D b = _0023_003DzrdSL0CI_003D[i + 1];
			Point3D point3D = Point3D.MidPoint(a, b);
			double num2 = Point3D.Distance(point3D, AnchorPoint);
			if (num2 < num)
			{
				result = point3D;
				num = num2;
			}
		}
		return result;
	}

	public override void Regen(RegenParams data)
	{
		if (CheckRegenParams(data))
		{
			base.Regen(data);
			textVertices = Vertices;
			_shapeCenter = Point3D.MidPoint(_vertices[0], _vertices[2]);
			_balloonRadius = Point3D.Distance(_vertices[0], _shapeCenter) * (double)_size;
			if (_size > 1)
			{
				_balloonRadius *= 0.75;
			}
			_0023_003DzsypbGvz1cf2emiZqaHnwSdM_003D(data);
			_0023_003Dz7Nj1WsA3tGamOMpzjBJW9UHmix_0024e();
			_0023_003DzpbAn5Q5zxlot(data);
			UpdateBoundingBox(data);
			RegenMode = regenType.CompileOnly;
		}
	}

	private void _0023_003Dz7Nj1WsA3tGamOMpzjBJW9UHmix_0024e()
	{
		_vertices = new Point3D[5];
		_vertices[0] = (Point3D)AnchorPoint.Clone();
		double num = ((Style == balloonStyleType.Triangle) ? Math.Sqrt(3.0) : 1.0) * _balloonRadius;
		_vertices[1] = _shapeCenter - num * base.Plane.AxisX - num * base.Plane.AxisY;
		_vertices[2] = _shapeCenter + num * base.Plane.AxisX - num * base.Plane.AxisY;
		_vertices[3] = _shapeCenter + num * base.Plane.AxisX + num * base.Plane.AxisY;
		_vertices[4] = _shapeCenter - num * base.Plane.AxisX + num * base.Plane.AxisY;
	}

	private void _0023_003DzsypbGvz1cf2emiZqaHnwSdM_003D(RegenParams _0023_003DzELu0Pss_003D)
	{
		_shapeVertices = null;
		switch (Style)
		{
		case balloonStyleType.Circular:
			_shapeVertices = _0023_003Dz1eo8C4aog2sScFjxrBa9NUWQh7XF(_0023_003DzELu0Pss_003D);
			break;
		case balloonStyleType.Triangle:
			_shapeVertices = _0023_003DzbKVIphXHgbj0kpSvhdfmVMU_003D();
			break;
		case balloonStyleType.Box:
			_shapeVertices = _0023_003DzbvjrBw7jrYdhGldEa_0024TLFYE_003D();
			break;
		case balloonStyleType.None:
			break;
		}
	}

	private Point3D[] _0023_003DzbKVIphXHgbj0kpSvhdfmVMU_003D()
	{
		Point3D[] array = new Point3D[3];
		double num = Math.Sqrt(3.0);
		array[0] = _shapeCenter - num * _balloonRadius * base.Plane.AxisX - _balloonRadius * base.Plane.AxisY;
		array[1] = _shapeCenter + num * _balloonRadius * base.Plane.AxisX - _balloonRadius * base.Plane.AxisY;
		array[2] = _shapeCenter + num * _balloonRadius * base.Plane.AxisY;
		return array;
	}

	private Point3D[] _0023_003DzbvjrBw7jrYdhGldEa_0024TLFYE_003D()
	{
		return new Point3D[4]
		{
			_shapeCenter - _balloonRadius * base.Plane.AxisX - _balloonRadius * base.Plane.AxisY,
			_shapeCenter + _balloonRadius * base.Plane.AxisX - _balloonRadius * base.Plane.AxisY,
			_shapeCenter + _balloonRadius * base.Plane.AxisX + _balloonRadius * base.Plane.AxisY,
			_shapeCenter - _balloonRadius * base.Plane.AxisX + _balloonRadius * base.Plane.AxisY
		};
	}

	private Point3D[] _0023_003Dz1eo8C4aog2sScFjxrBa9NUWQh7XF(RegenParams _0023_003DzELu0Pss_003D)
	{
		int num = 10 * Utility.NumberOfSegments(_balloonRadius, Math.PI * 2.0, _0023_003DzELu0Pss_003D.Deviation, _0023_003DzELu0Pss_003D.Angle);
		Point3D[] array = new Point3D[num + 1];
		Plane plane = new Plane(_shapeCenter, base.Plane.AxisX, base.Plane.AxisY);
		for (int i = 0; i < num + 1; i++)
		{
			Point3D point3D = Ellipse.PointOnEllipseAt((double)(i * 2) * Math.PI / (double)num, plane, _balloonRadius, _balloonRadius);
			array[i] = new Point3D(point3D.X, point3D.Y, point3D.Z);
		}
		return array;
	}

	protected internal override void Draw(DrawParams data)
	{
		_0023_003DznHkCc4qYpDklD8_niw_003D_003D(data, _0023_003Dzjrk7FZSkkMDSr5VHWA_003D_003D: true);
		base.Draw(data);
	}

	protected override void DrawSimplified(RenderContextBase context)
	{
	}

	private void _0023_003DznHkCc4qYpDklD8_niw_003D_003D(DrawParams _0023_003DzELu0Pss_003D, bool _0023_003Dzjrk7FZSkkMDSr5VHWA_003D_003D)
	{
		PreDraw(_0023_003DzELu0Pss_003D, _0023_003Dzjrk7FZSkkMDSr5VHWA_003D_003D);
		_0023_003DzELu0Pss_003D.RenderContext.PushModelView();
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
		_0023_003DzELu0Pss_003D.RenderContext.PopModelView();
		PostDraw(_0023_003DzELu0Pss_003D);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (base.Compiling)
		{
			context.DrawLineStrip(new Point3D[2]
			{
				base.Plane.PointAt(_start2D),
				base.Plane.PointAt(_end2D)
			}, 0, 2);
			if (Style != balloonStyleType.None)
			{
				context.DrawLineLoop(_shapeVertices, 0, _shapeVertices.Length);
			}
		}
		else
		{
			drawData.DrawBuffer(context, 0);
			if (Style != balloonStyleType.None)
			{
				drawData.DrawBuffer(context, 1);
			}
		}
		if (ShowArrowHead)
		{
			Transformation transform = new Transformation(AnchorPoint, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
			context.MultMatrixModelView(transform);
			DrawArrowHead(context, ArrowHead, 0.0, reverse: false);
		}
	}

	protected internal override void Render(RenderParams data)
	{
		Transformation blockRefTransform = null;
		if (data.RenderContext.Shaders != null)
		{
			blockRefTransform = data.ShaderParams.BlockRefTransform;
			Transformation transform = base.Transform;
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
			_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzySK4JX4gwaSvQLZwafPBUrg_003D(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
			break;
		case arrowheadType.Tick:
			_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzZl3uTZY2SDdp(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
			break;
		case arrowheadType.Dot:
			_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzT2MIyACvYuZK(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
			break;
		case arrowheadType.Oblique:
			_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzpFyrpKXLMt3yujRxSw_003D_003D(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
			break;
		}
		context.PopModelView();
	}

	protected virtual Transformation GetArrowHeadTransformation(arrowheadType arrowhead, double myDistance)
	{
		return arrowhead switch
		{
			arrowheadType.Tick => new Translation(myDistance, 0.0) * new Rotation(_angle + Math.PI / 4.0, new Vector3D(0.0, 0.0, 1.0)), 
			arrowheadType.Dot => new Translation(myDistance, 0.0), 
			arrowheadType.Oblique => new Translation(myDistance, 0.0) * new Rotation(_angle + Math.PI / 4.0, new Vector3D(0.0, 0.0, 1.0)), 
			_ => new Translation(myDistance, 0.0) * new Rotation(_angle, new Vector3D(0.0, 0.0, 1.0)), 
		};
	}

	internal double _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D()
	{
		return ArrowHeadSize * Scale;
	}

	internal void _0023_003DzAqQbug4_003D(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_shapeVertices != null)
		{
			int num = _shapeVertices.Length;
			for (int i = 0; i < num - 1; i++)
			{
				list.Add(_shapeVertices[i]);
				list.Add(_shapeVertices[i + 1]);
			}
			list.Add(_shapeVertices[num - 1]);
			list.Add(_shapeVertices[0]);
		}
		list.Add(base.Plane.PointAt(_start2D));
		list.Add(base.Plane.PointAt(_end2D));
		if (!_0023_003DzzGo2_Wb1L5us)
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA = new Rotation(_angle, new Vector3D(0.0, 0.0, 1.0));
			Point3D[] collection = _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003Dz7tEgWrFHxteq(ArrowHead, base.Plane, _0023_003Dz9ZUzIX4xmsyA, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D: false, _0023_003DzEXLcE10_003D: false);
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

	internal Point3D[][] _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (ArrowHead != arrowheadType.Oblique && ShowArrowHead)
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA = new Rotation(_angle, new Vector3D(0.0, 0.0, 1.0));
			list = _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzQvPWxyC95069Svh7qQVH_ZY_003D(ArrowHead, new Plane(AnchorPoint, base.Plane.AxisX, base.Plane.AxisY), _0023_003Dz9ZUzIX4xmsyA, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D: false, _0023_003DzEXLcE10_003D: false).ToList();
		}
		if (_0023_003DzFM3KC0w_003D == null)
		{
			return new Point3D[1][] { list.ToArray() };
		}
		return _0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(_0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix()), list.ToArray());
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

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2]
			{
				base.Plane.Origin,
				AnchorPoint
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956503) + AnchorPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956493) + InsertionPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956456) + Style);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956437) + Size);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956419) + ArrowHead);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956152) + ArrowHeadSize);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956144) + ShowArrowHead);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956101) + Scale);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new BalloonSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), InsertionPoint);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360), ArrowHeadSize);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956350), Scale);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956330), ShowArrowHead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956318), Style);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956298), Size);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956531), AnchorPoint);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956520), ArrowHead);
	}

	public Entity[] Explode()
	{
		List<Entity> list = new List<Entity>();
		list.Add(new Text(base.Plane, InsertionPoint, TextString, base.Height));
		Leader leader = new Leader(base.Plane.Clone() as Plane, base.Plane.PointAt(_end2D), base.Plane.PointAt(_start2D));
		_0023_003Dz5vWsjEZHzDSQ(leader);
		list.Add(leader);
		if (Style != balloonStyleType.None)
		{
			list.Add(_0023_003Dz9Ft8e1HezHv_0024BGca6uNL6Js_003D());
		}
		return list.ToArray();
	}

	private void _0023_003Dz5vWsjEZHzDSQ(Leader _0023_003Dz6OvJlPUOABCu)
	{
		_0023_003Dz6OvJlPUOABCu.ArrowheadSize = ArrowHeadSize;
		_0023_003Dz6OvJlPUOABCu.ShowArrowHead = ShowArrowHead;
		_0023_003Dz6OvJlPUOABCu.Arrowhead = ArrowHead;
		_0023_003Dz6OvJlPUOABCu.Scale = Scale;
	}

	private Entity _0023_003Dz9Ft8e1HezHv_0024BGca6uNL6Js_003D()
	{
		if (Style == balloonStyleType.Circular)
		{
			return new Circle(base.Plane, _shapeCenter, _balloonRadius);
		}
		List<Point3D> list = new List<Point3D>();
		list.AddRange(_shapeVertices);
		list.Add(_shapeVertices[0]);
		return new LinearPath(list);
	}
}
