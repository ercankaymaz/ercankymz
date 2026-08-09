using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class RadialDim : Dimension, ISingleArrowhead
{
	private double _radius;

	private bool _trimLeader;

	internal bool showCenterMark = true;

	protected internal double angle;

	protected Point2D chordPoint2D;

	private arrowheadType _arrowhead;

	private double _centerMarkSize;

	private double _prevCenterMark;

	public virtual bool TrimLeader
	{
		get
		{
			return _trimLeader;
		}
		set
		{
			_trimLeader = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double CenterMarkSize
	{
		get
		{
			return _centerMarkSize;
		}
		set
		{
			_centerMarkSize = value;
			showCenterMark = value != 0.0;
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

	public double Radius
	{
		get
		{
			return _radius;
		}
		set
		{
			_radius = value;
			DimSetup();
		}
	}

	public RadialDim(Circle circle, Point3D dimLinePos, double textHeight)
		: base(circle.Plane, circle.Center, textHeight)
	{
		_0023_003DztGdcVOA_003D(circle, dimLinePos, textHeight);
	}

	public RadialDim(Circle circle, Point3D dimLinePos, double textHeight, Plane refPlane)
		: base(_0023_003Dz90HPbnqWBK4mgrS_deEVl40_003D(circle.Plane, refPlane), circle.Center, textHeight)
	{
		_0023_003DztGdcVOA_003D(circle, dimLinePos, textHeight);
	}

	public RadialDim(Circle circle, double distance, double rotation, double textHeight, Plane refPlane)
		: base(_0023_003Dz90HPbnqWBK4mgrS_deEVl40_003D(circle.Plane, refPlane), circle.Center, textHeight)
	{
		Point3D point3D = new Point3D(distance, 0.0, 0.0);
		point3D.TransformBy(new Rotation(rotation, Vector3D.AxisZ));
		Align3D xform = new Align3D(Plane.XY, base.Plane);
		point3D.TransformBy(xform);
		_0023_003DztGdcVOA_003D(circle, point3D, textHeight);
	}

	public RadialDim(Circle circle, Point2D dimLinePos, double textHeight)
		: base(circle.Plane, circle.Center, textHeight)
	{
		_0023_003DztGdcVOA_003D(circle, base.Plane.PointAt(dimLinePos), textHeight);
	}

	public RadialDim(Circle circle, Point2D dimLinePos, double textHeight, Plane refPlane)
		: base(_0023_003Dz90HPbnqWBK4mgrS_deEVl40_003D(circle.Plane, refPlane), circle.Center, textHeight)
	{
		_0023_003DztGdcVOA_003D(circle, base.Plane.PointAt(dimLinePos), textHeight);
	}

	protected RadialDim(RadialDim another)
		: base(another)
	{
		_radius = another._radius;
		Arrowhead = another.Arrowhead;
		CenterMarkSize = another.CenterMarkSize;
		TrimLeader = another.TrimLeader;
		DimSetup();
	}

	protected internal RadialDim(RadialDimSurrogate surrogate)
		: this(new Circle(surrogate.Plane, surrogate.Radius), surrogate.DimLinePosition, surrogate.Height)
	{
	}

	protected RadialDim(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_radius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843));
		Arrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956520), typeof(arrowheadType));
		CenterMarkSize = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975874));
		TrimLeader = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975607));
		UpdateDistance();
	}

	internal double _0023_003Dz3GSu1RSi9U2w()
	{
		return CenterMarkSize * ScaleOverall;
	}

	private void _0023_003DztGdcVOA_003D(Circle _0023_003Dzw6jQxH4k7cf_0024, Point3D _0023_003Dz2AZWQ2NrfVgE, double _0023_003Dzx0bH0r8MZhkE)
	{
		_radius = _0023_003Dzw6jQxH4k7cf_0024.Radius;
		base.DimLinePosition = _0023_003Dz2AZWQ2NrfVgE;
		Arrowhead = arrowheadType.Arrow;
		CenterMarkSize = _0023_003Dzx0bH0r8MZhkE / 2.0;
		base.TextPrefix = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911028);
	}

	private static Plane _0023_003Dz90HPbnqWBK4mgrS_deEVl40_003D(Plane _0023_003Dzpyw2kZk_003D, Plane _0023_003Dz_azkov5EDxoe)
	{
		return new Plane(_0023_003Dzpyw2kZk_003D.Origin, _0023_003Dz_azkov5EDxoe.AxisX, _0023_003Dz_azkov5EDxoe.AxisY);
	}

	public override object Clone()
	{
		return new RadialDim(this);
	}

	protected override void UpdateDistance()
	{
		base.Distance = _radius;
	}

	protected internal override Transformation GetBillboardTransformation(DrawParams data, out double scaleX, out double scaleY, out double scaleZ)
	{
		data.Viewport.Camera.GetFrame(out var _, out var camX, out var camY, out var _);
		Plane plane = (Plane)base.Plane.Clone();
		plane.Origin = Point3D.Origin;
		if (textFlipped)
		{
			plane.Rotate(Math.PI + angle, plane.AxisZ);
		}
		else
		{
			plane.Rotate(angle, plane.AxisZ);
		}
		_0023_003Dz6_tAcSMiWiQ_0024635CMcOdIWk_003D(data, out var _0023_003Dzk3JS5glTSWfF, out scaleX, out scaleY, out scaleZ);
		return _0023_003Dzk3JS5glTSWfF * new Align3D(plane, new Plane(Point3D.Origin, camX, camY));
	}

	protected override Transformation GetTextMatrix()
	{
		Transformation transformation = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		if (textFlipped)
		{
			transformation *= (Transformation)new Rotation(Math.PI + angle, Vector3D.AxisZ);
		}
		else
		{
			transformation *= (Transformation)new Rotation(angle, Vector3D.AxisZ);
		}
		return transformation * new Scaling(base.ScaleBackward, base.ScaleUpsideDown) * new Translation(_textBottomLeft2D.X, _textBottomLeft2D.Y) * new Scaling(base.ScaleX, base.ScaleY);
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(base.DimLinePosition.X, base.DimLinePosition.Y, base.DimLinePosition.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		base.DimLinePosition.X = num * array[0];
		base.DimLinePosition.Y = num * array[1];
		base.DimLinePosition.Z = num * array[2];
		if (xform.HasScaling)
		{
			double scaleFactor = xform.ScaleFactorX;
			if (xform.EqualScaleFactors() || xform.IsScaleFactorUniformForPlanar(base.Plane, ref scaleFactor))
			{
				CenterMarkSize *= scaleFactor;
				_radius *= scaleFactor;
			}
		}
		base.TransformBy(xform);
	}

	internal override void RegenInternal(RegenParams _0023_003DzELu0Pss_003D)
	{
		PrepareText(_0023_003DzELu0Pss_003D, ref myWidthFactor, out exactWidth, out exactDescend, out var _, out var _);
		double num = _0023_003DzJ7p5EJnvP7td();
		double num2 = num / 2.0;
		double textDistFromOrigin;
		Point3D[] verticesOnPlane = PreProcess(out textDistFromOrigin);
		switch (base.TextLocation)
		{
		case elementPositionType.Auto:
			_textIsInside = num < _radius;
			_textIsInside &= textDistFromOrigin < _radius;
			break;
		case elementPositionType.Inside:
			_textIsInside = true;
			break;
		case elementPositionType.Outside:
			_textIsInside = false;
			break;
		}
		double _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D = Math.Abs(Radius - textDistFromOrigin);
		_0023_003DzL3Hw_0024qWYdWdp_0024JA5XQ_003D_003D(Arrowhead, null, num, _radius, _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D, null, _0023_003DzL2lT7qyADIGH: false);
		double num3 = base.Distance + num2 + _0023_003DzyH_0024xWtf1YBY_7n7_Rd54RUs_003D(Arrowhead);
		double num4 = base.Distance - num2 - _0023_003Dz9ACJTcDlsOrBkRMssrasU3Y_003D(Arrowhead);
		if (!_textIsInside && textDistFromOrigin < num3)
		{
			textDistFromOrigin = num3;
		}
		else if (_textIsInside && textDistFromOrigin < num2)
		{
			textDistFromOrigin = num2;
		}
		else if (_textIsInside && textDistFromOrigin > num4 && textDistFromOrigin <= base.Distance)
		{
			textDistFromOrigin = num4;
		}
		else if (textDistFromOrigin > base.Distance && textDistFromOrigin <= num4 && !_textIsInside)
		{
			textDistFromOrigin = num4;
		}
		else if (_textIsInside)
		{
			double num5 = _radius - num2 - _0023_003Dz9ACJTcDlsOrBkRMssrasU3Y_003D(Arrowhead);
			if (textDistFromOrigin > num5)
			{
				textDistFromOrigin = num5;
			}
		}
		else
		{
			double num6 = _radius + num2 + _0023_003DzyH_0024xWtf1YBY_7n7_Rd54RUs_003D(Arrowhead);
			if (textDistFromOrigin < num6)
			{
				textDistFromOrigin = num6;
			}
		}
		PostProcess(verticesOnPlane, base.Distance, textDistFromOrigin, num);
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
	}

	private Point3D[] _0023_003DzJsJcJhSniZi0cInVFS9i7x4_003D()
	{
		Point3D[] array = _vertices;
		if (!showCenterMark)
		{
			array = new Point3D[_vertices.Length - 4];
			int num = 0;
			array[num++] = _vertices[0];
			array[num++] = _vertices[5];
			for (int i = firstVertexIndexForTexts; i < _vertices.Length; i++)
			{
				array[num++] = _vertices[i];
			}
		}
		return array;
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		Point3D[] array = _0023_003DzJsJcJhSniZi0cInVFS9i7x4_003D();
		Entity.ComputeOffsetOnCameraAxes(data, array, array.Length);
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		Point3D[] entityVertices = _0023_003DzJsJcJhSniZi0cInVFS9i7x4_003D();
		return Entity.ComputeBoundingBox(data, entityVertices, out boxMin, out boxMax);
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		Utility._0023_003Dzyx35VoBSR6flPmM7uA_003D_003D(_0023_003DzJsJcJhSniZi0cInVFS9i7x4_003D(), out var _0023_003DzTbDlaOM_003D);
		verticesCoords = _0023_003DzTbDlaOM_003D;
		return true;
	}

	protected Point3D[] PreProcess(out double textDistFromOrigin)
	{
		int verticesLength = 10;
		Point3D[] array = InitVerticesOnPlane(ref verticesLength);
		array[0] = base.Plane.Origin;
		array[5] = base.DimLinePosition;
		_0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(array, verticesLength);
		array[1] = new Point3D(array[0].X - _0023_003Dz3GSu1RSi9U2w(), 0.0);
		array[2] = new Point3D(array[0].X + _0023_003Dz3GSu1RSi9U2w(), 0.0);
		array[3] = new Point3D(0.0, array[0].Y - _0023_003Dz3GSu1RSi9U2w());
		array[4] = new Point3D(0.0, array[0].Y + _0023_003Dz3GSu1RSi9U2w());
		double x = array[5].X;
		double y = array[5].Y;
		textDistFromOrigin = Math.Sqrt(x * x + y * y);
		angle = Math.Atan2(y, x);
		if (angle < 0.0)
		{
			angle += Math.PI * 2.0;
		}
		textFlipped = Utility.TextNeedsToBeFlippedAccordingToDrawingRules(angle - Math.PI / 2.0);
		return array;
	}

	protected void PostProcess(Point3D[] verticesOnPlane, double radius, double textDistFromOrigin, double textBoxWidth)
	{
		_dimLineInterruptionPoints = null;
		verticesOnPlane[5].Y = (verticesOnPlane[0].Y = 0.0);
		if (_textIsInside)
		{
			if (_arrowsIsInside)
			{
				verticesOnPlane[5].X = radius;
			}
			else
			{
				verticesOnPlane[5].X = radius + _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(Arrowhead);
			}
			if (TrimLeader)
			{
				verticesOnPlane[0].X = textDistFromOrigin + ((base.TextVerticalPosition == verticalAlignmentType.Centered) ? (textBoxWidth / 2.0) : ((0.0 - textBoxWidth) / 2.0));
			}
			else if (base.TextVerticalPosition == verticalAlignmentType.Centered)
			{
				Point3D point3D = new Point3D(textDistFromOrigin - textBoxWidth / 2.0, 0.0);
				Point3D point3D2 = new Point3D(textDistFromOrigin + textBoxWidth / 2.0, 0.0);
				_dimLineInterruptionPoints = new Point3D[2] { point3D, point3D2 };
			}
		}
		else
		{
			double x = textDistFromOrigin + ((base.TextVerticalPosition == verticalAlignmentType.Centered) ? ((0.0 - textBoxWidth) / 2.0) : (textBoxWidth / 2.0));
			verticesOnPlane[5].X = x;
			if (TrimLeader)
			{
				verticesOnPlane[0].X = radius;
			}
		}
		chordPoint2D = new Point2D(radius * Math.Cos(angle), radius * Math.Sin(angle));
		textLines = new List<string>();
		firstVertexIndexForTexts = 6;
		double num = _0023_003DzSKl3eSMXQFvZ();
		verticesOnPlane[firstVertexIndexForTexts] = new Point3D(textDistFromOrigin - exactWidth / 2.0 + prefixWidth, textFlipped ? (0.0 - num) : num);
		double num2 = (textFlipped ? (0.0 - textDistFromOrigin) : textDistFromOrigin);
		_textBottomLeft2D = new Point2D(num2 - exactWidth / 2.0, num);
		_0023_003DzzCaChFUggCUnnuTszAfinDY_003D(verticesOnPlane, _0023_003DzCpjsF78_003D: false, _0023_003DzjTr87nBCi_hO: false);
		Transformation transformation = Transformation.CreateRotation(angle, Vector3D.AxisZ);
		for (int i = firstVertexIndexForTexts; i < verticesOnPlane.Length; i++)
		{
			verticesOnPlane[i] = transformation * verticesOnPlane[i];
		}
		verticesOnPlane[0] = transformation * verticesOnPlane[0];
		verticesOnPlane[5] = transformation * verticesOnPlane[5];
		for (int j = 0; j < _basicToleranceBoxVertices.Length; j++)
		{
			_basicToleranceBoxVertices[j] = transformation * _basicToleranceBoxVertices[j];
		}
		if (_dimLineInterruptionPoints != null)
		{
			for (int k = 0; k < _dimLineInterruptionPoints.Length; k++)
			{
				_dimLineInterruptionPoints[k] = transformation * _dimLineInterruptionPoints[k];
			}
		}
		_0023_003Dz0nJAUFysbna4boWQhQ_003D_003D(verticesOnPlane);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, new Point3D[6]
		{
			_vertices[1],
			_vertices[2],
			_vertices[3],
			_vertices[4],
			_vertices[0],
			_vertices[5]
		}, 6, 2))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, new Point3D[6]
		{
			_vertices[1],
			_vertices[2],
			_vertices[3],
			_vertices[4],
			_vertices[0],
			_vertices[5]
		}, 6, 2))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	internal override void GetLines(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		base.GetLines(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, _0023_003DzzGo2_Wb1L5us, out _0023_003DzyIUKu5w_003D, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D);
		List<Point3D> list = new List<Point3D>();
		if (showCenterMark)
		{
			list.Add(_vertices[1]);
			list.Add(_vertices[2]);
			list.Add(_vertices[3]);
			list.Add(_vertices[4]);
		}
		list.Add(_vertices[0]);
		if (_dimLineInterruptionPoints != null)
		{
			list.AddRange(_dimLineInterruptionPoints);
		}
		list.Add(_vertices[5]);
		_0023_003DzbqHqSeT0TbL3(_0023_003DzzGo2_Wb1L5us, list);
		list.AddRange(_0023_003DzyIUKu5w_003D);
		_0023_003DzyIUKu5w_003D = list.ToArray();
	}

	private protected virtual void _0023_003DzbqHqSeT0TbL3(bool _0023_003DzzGo2_Wb1L5us, List<Point3D> _0023_003Dz6QQCnmDNDQzBvgUBuw_003D_003D)
	{
		if (!_0023_003DzzGo2_Wb1L5us || Arrowhead == arrowheadType.Oblique)
		{
			Point3D[] array = null;
			array = GetArrowHeadPoints(Arrowhead, _0023_003DzrZFKkMInS_0024Hi(), reverse: false);
			_0023_003Dz6QQCnmDNDQzBvgUBuw_003D_003D.AddRange(array);
		}
	}

	private Transformation _0023_003DzrZFKkMInS_0024Hi()
	{
		return new Rotation(angle, new Vector3D(0.0, 0.0, 1.0)) * new Translation(base.Distance, 0.0);
	}

	internal override Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		Point3D[] array = null;
		array = GetArrowHeadTriangles(Arrowhead, _0023_003DzrZFKkMInS_0024Hi(), reverse: false);
		if (_0023_003DzFM3KC0w_003D == null)
		{
			return new Point3D[1][] { array.ToArray() };
		}
		return Dimension._0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(_0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix()), array);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		DrawCrossAndRadius(context);
		DrawHeads(context, myParams);
	}

	protected override void DrawHeadsInternal(RenderContextBase context, object myParams)
	{
		DrawArrowHead(context, Arrowhead, base.Distance, reverse: false, myParams as Color?);
	}

	protected void DrawCrossAndRadius(RenderContextBase context)
	{
		if (base.Compiling)
		{
			List<Point3D> list = new List<Point3D>(8);
			if (showCenterMark)
			{
				list.AddRange(new global::_0023_003DzQ7KJPYazFHsNmrIUbA_003D_003D<Point3D>(new Point3D[4]
				{
					_vertices[1],
					_vertices[2],
					_vertices[3],
					_vertices[4]
				}));
			}
			list.Add(_vertices[0]);
			if (_dimLineInterruptionPoints != null)
			{
				list.AddRange(_dimLineInterruptionPoints);
			}
			list.Add(_vertices[5]);
			_0023_003Dz_GuEQ6Cz_DBs(context, list.ToArray(), list.Count);
		}
		else
		{
			drawData.DrawBuffer(context, 0);
		}
	}

	private void _0023_003DzK48Px00_003D(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzkJwy_6DWl7EF, bool _0023_003DzEXLcE10_003D)
	{
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(Utility.RadToDeg(angle), 0.0, 0.0, 1.0);
		_0023_003DzB8iS0QA_003D.TranslateMatrixModelView(_0023_003DzEXLcE10_003D ? (0.0 - _0023_003DzkJwy_6DWl7EF) : _0023_003DzkJwy_6DWl7EF, 0.0, 0.0);
	}

	protected override void DrawArrow(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		_0023_003DzK48Px00_003D(context, myDistance, reverse);
		if (reverse ? (!_arrowsIsInside) : _arrowsIsInside)
		{
			DrawArrowPointingRight(context);
		}
		else
		{
			DrawArrowPointingLeft(context);
		}
		context.PopModelView();
	}

	protected override void DrawTick(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		_0023_003DzK48Px00_003D(context, myDistance, reverse);
		context.RotateMatrixModelView(45.0, 0.0, 0.0, 1.0);
		DrawTick(context);
		context.PopModelView();
	}

	protected override void DrawDot(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		_0023_003DzK48Px00_003D(context, myDistance, reverse);
		DrawDot(context);
		context.PopModelView();
	}

	protected override void DrawOblique(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		_0023_003DzK48Px00_003D(context, myDistance, reverse);
		context.RotateMatrixModelView(45.0, 0.0, 0.0, 1.0);
		DrawOblique(context);
		context.PopModelView();
	}

	internal override void _0023_003DzbC_0024QQAMwgTKD(DrawParams _0023_003DzELu0Pss_003D)
	{
		base._0023_003DzbC_0024QQAMwgTKD(_0023_003DzELu0Pss_003D);
		_prevCenterMark = _centerMarkSize;
		_centerMarkSize = height * 0.5;
	}

	internal override void _0023_003DzWFT5K6qE53AJ()
	{
		_centerMarkSize = _prevCenterMark;
		base._0023_003DzWFT5K6qE53AJ();
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975593) + CenterMarkSize);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956419) + CenterMarkSize);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975555) + TrimLeader);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new RadialDimSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), _radius);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956520), Arrowhead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975874), CenterMarkSize);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975607), TrimLeader);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2]
			{
				base.Plane.Origin,
				base.DimLinePosition
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}
}
