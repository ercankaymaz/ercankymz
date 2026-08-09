using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class LinearDim : Dimension, ITwoArrowheads
{
	private double _extLineExt;

	private double _extLineOffset;

	internal Point3D end;

	private bool _showExtLine1 = true;

	private bool _showExtLine2 = true;

	internal Point2D start2D;

	internal Point2D end2D;

	private arrowheadType _leftArrowhead;

	private arrowheadType _rightArrowhead;

	public double ExtLineExt
	{
		get
		{
			return _extLineExt;
		}
		set
		{
			_extLineExt = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double ExtLineOffset
	{
		get
		{
			return _extLineOffset;
		}
		set
		{
			_extLineOffset = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public arrowheadType LeftArrowhead
	{
		get
		{
			return _leftArrowhead;
		}
		set
		{
			_leftArrowhead = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public arrowheadType RightArrowhead
	{
		get
		{
			return _rightArrowhead;
		}
		set
		{
			_rightArrowhead = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public Point3D ExtLine1
	{
		get
		{
			return base.Plane.Origin;
		}
		set
		{
			base.Plane.Origin = value;
			DimSetup();
		}
	}

	public Point3D ExtLine2
	{
		get
		{
			return end;
		}
		set
		{
			end = value;
			DimSetup();
		}
	}

	public bool ShowExtLine1
	{
		get
		{
			return _showExtLine1;
		}
		set
		{
			_showExtLine1 = value;
			DimSetup();
		}
	}

	public bool ShowExtLine2
	{
		get
		{
			return _showExtLine2;
		}
		set
		{
			_showExtLine2 = value;
			DimSetup();
		}
	}

	public LinearDim(Plane dimPlane, Point3D extLine1, Point3D extLine2, Point3D dimLinePos, double textHeight)
		: base(dimPlane, extLine1, textHeight)
	{
		_0023_003DztGdcVOA_003D((Point3D)extLine2.Clone(), (Point3D)dimLinePos.Clone());
	}

	public LinearDim(Plane sketchPlane, Point2D extLine1, Point2D extLine2, Point2D dimLinePos, double textHeight)
		: base(sketchPlane, sketchPlane.PointAt(extLine1), textHeight)
	{
		_0023_003DztGdcVOA_003D(sketchPlane.PointAt(extLine2), sketchPlane.PointAt(dimLinePos));
	}

	protected LinearDim(LinearDim another)
		: base(another)
	{
		end = (Point3D)another.end.Clone();
		LeftArrowhead = another.LeftArrowhead;
		RightArrowhead = another.RightArrowhead;
		ExtLineExt = another.ExtLineExt;
		ExtLineOffset = another.ExtLineOffset;
		ShowExtLine1 = another.ShowExtLine1;
		ShowExtLine2 = another.ShowExtLine2;
		base.LinearDimensionUnits = another.LinearDimensionUnits;
		DimSetup();
	}

	protected internal LinearDim(LinearDimSurrogate surrogate)
		: this(surrogate.Plane, surrogate.ExtLine1, surrogate.ExtLine2, surrogate.DimLinePosition, surrogate.Height)
	{
	}

	protected LinearDim(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		base.Plane.Origin = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), typeof(Point3D));
		end = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), typeof(Point3D));
		LeftArrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954577), typeof(arrowheadType));
		RightArrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954567), typeof(arrowheadType));
		ExtLineExt = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954560));
		ExtLineOffset = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954528));
		ShowExtLine1 = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954732));
		ShowExtLine2 = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954696));
		UpdateDistance();
	}

	internal double _0023_003Dzgy2eWaUzG03z()
	{
		return ExtLineExt * ScaleOverall;
	}

	internal double _0023_003DzKTDbYiAY8p4J()
	{
		return ExtLineOffset * ScaleOverall;
	}

	private void _0023_003DztGdcVOA_003D(Point3D _0023_003DzM7o0gT3hjI42, Point3D _0023_003Dz2AZWQ2NrfVgE)
	{
		end = _0023_003DzM7o0gT3hjI42;
		base.DimLinePosition = _0023_003Dz2AZWQ2NrfVgE;
		LeftArrowhead = arrowheadType.Arrow;
		RightArrowhead = arrowheadType.Arrow;
		ExtLineExt = height * 0.5;
		ExtLineOffset = height * 0.25;
	}

	public override object Clone()
	{
		return new LinearDim(this);
	}

	protected override void UpdateDistance()
	{
		double num = new Segment3D(base.Plane.Origin, base.Plane.Origin + base.Plane.AxisX).Project(end);
		if (num < 0.0)
		{
			Point3D first = base.Plane.Origin;
			Utility.Swap(ref first, ref end);
			base.Plane.Origin = first;
			base.Distance = 0.0 - num;
		}
		else
		{
			base.Distance = num;
		}
	}

	protected override Transformation GetTextMatrix()
	{
		return new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ) * new Scaling(base.ScaleBackward, base.ScaleUpsideDown) * new Translation(_textBottomLeft2D.X, _textBottomLeft2D.Y) * new Scaling(base.ScaleX, base.ScaleY);
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(end.X, end.Y, end.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		end.X = num * array[0];
		end.Y = num * array[1];
		end.Z = num * array[2];
		array = xform.ActOnLeft(base.DimLinePosition.X, base.DimLinePosition.Y, base.DimLinePosition.Z, 1.0);
		num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		base.DimLinePosition.X = num * array[0];
		base.DimLinePosition.Y = num * array[1];
		base.DimLinePosition.Z = num * array[2];
		if (xform.HasScaling)
		{
			double scaleFactor = xform.ScaleFactorX;
			if (xform.EqualScaleFactors() || xform.IsScaleFactorUniformForPlanar(base.Plane, ref scaleFactor))
			{
				ExtLineExt *= scaleFactor;
				ExtLineOffset *= scaleFactor;
			}
		}
		base.TransformBy(xform);
	}

	internal override void RegenInternal(RegenParams _0023_003DzELu0Pss_003D)
	{
		PrepareText(_0023_003DzELu0Pss_003D, ref myWidthFactor, out exactWidth, out exactDescend, out var _, out var _);
		double num = _0023_003DzJ7p5EJnvP7td() / 2.0;
		firstVertexIndexForTexts = 6;
		int verticesLength = 10;
		Point3D[] array = InitVerticesOnPlane(ref verticesLength);
		array[0] = base.Plane.Origin;
		array[4] = end;
		array[6] = base.DimLinePosition;
		_0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(array, verticesLength);
		if (array[4].X < array[0].X)
		{
			Point3D point3D = (Point3D)array[0].Clone();
			array[0] = array[4];
			array[4] = point3D;
		}
		dimLineY = array[6].Y;
		if (ShowExtLine1)
		{
			double num2 = _0023_003Dzgy2eWaUzG03z();
			double num3 = _0023_003DzKTDbYiAY8p4J();
			if (array[6].Y <= array[0].Y)
			{
				num2 *= -1.0;
				num3 *= -1.0;
			}
			array[0].Y += num3;
			array[1] = new Point3D(array[0].X, dimLineY + num2);
		}
		else
		{
			array[0].Y += dimLineY;
			array[1] = new Point3D(array[0].X, dimLineY);
		}
		start2D = (Point2D)array[0].Clone();
		_0023_003DzgFzRnM_0024C_rz3(array[6].X, base.Distance, LeftArrowhead, RightArrowhead, out var _0023_003DzS_jd4PN2HwcY, out var _0023_003DzKRo7zbbg_dT, out var _0023_003Dz93dT3hmUKg0E);
		array[2] = new Point3D(_0023_003DzKRo7zbbg_dT, dimLineY);
		array[3] = new Point3D(_0023_003Dz93dT3hmUKg0E, dimLineY);
		if (ShowExtLine2)
		{
			double num4 = _0023_003Dzgy2eWaUzG03z();
			double num5 = _0023_003DzKTDbYiAY8p4J();
			if (array[6].Y <= array[4].Y)
			{
				num4 *= -1.0;
				num5 *= -1.0;
			}
			array[4].Y += num5;
			array[5] = new Point3D(array[4].X, dimLineY + num4);
		}
		else
		{
			array[4].Y = array[3].Y;
			array[5] = new Point3D(array[4].X, array[3].Y);
		}
		end2D = (Point2D)array[4].Clone();
		array[firstVertexIndexForTexts].X = _0023_003DzS_jd4PN2HwcY - exactWidth / 2.0 + prefixWidth;
		double y = dimLineY + _0023_003DzSKl3eSMXQFvZ();
		array[firstVertexIndexForTexts].Y = y;
		_textBottomLeft2D = new Point2D(_0023_003DzS_jd4PN2HwcY - exactWidth / 2.0, y);
		textLines = new List<string>();
		_0023_003DzzCaChFUggCUnnuTszAfinDY_003D(array, _0023_003DzCpjsF78_003D: false, _0023_003DzjTr87nBCi_hO: false);
		if (_textIsInside && base.TextVerticalPosition == verticalAlignmentType.Centered)
		{
			Point3D point3D2 = new Point3D(_0023_003DzS_jd4PN2HwcY - num, dimLineY);
			Point3D point3D3 = new Point3D(_0023_003DzS_jd4PN2HwcY + num, dimLineY);
			_dimLineInterruptionPoints = new Point3D[2] { point3D2, point3D3 };
		}
		else
		{
			_dimLineInterruptionPoints = null;
		}
		_0023_003Dz0nJAUFysbna4boWQhQ_003D_003D(array);
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
	}

	internal override void GetLines(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		base.GetLines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFM3KC0w_003D, _0023_003DzzGo2_Wb1L5us, out _0023_003DzyIUKu5w_003D, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D);
		List<Point3D> list = new List<Point3D>();
		list.Add(_vertices[0]);
		list.Add(_vertices[1]);
		list.Add(_vertices[2]);
		if (_dimLineInterruptionPoints != null)
		{
			list.Add(_dimLineInterruptionPoints[0]);
			list.Add(_dimLineInterruptionPoints[1]);
		}
		list.Add(_vertices[3]);
		list.Add(_vertices[4]);
		list.Add(_vertices[5]);
		Point3D[] array = null;
		if (!_0023_003DzzGo2_Wb1L5us || LeftArrowhead == arrowheadType.Oblique)
		{
			array = GetArrowHeadPoints(LeftArrowhead, _0023_003DzKw0JSvso00Xq(), reverse: true);
			list.AddRange(array);
		}
		if (!_0023_003DzzGo2_Wb1L5us || RightArrowhead == arrowheadType.Oblique)
		{
			array = GetArrowHeadPoints(RightArrowhead, _0023_003Dzxd1wPlvPgXlh(), reverse: false);
			list.AddRange(array);
		}
		list.AddRange(_0023_003DzyIUKu5w_003D);
		_0023_003DzyIUKu5w_003D = list.ToArray();
	}

	private Transformation _0023_003DzKw0JSvso00Xq()
	{
		return new Translation(start2D.X, dimLineY);
	}

	private Transformation _0023_003Dzxd1wPlvPgXlh()
	{
		return new Translation(end2D.X, dimLineY);
	}

	internal override Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		List<Point3D> list = new List<Point3D>();
		Point3D[] array = null;
		if (LeftArrowhead != arrowheadType.Oblique)
		{
			array = GetArrowHeadTriangles(LeftArrowhead, _0023_003DzKw0JSvso00Xq(), reverse: true);
			list.AddRange(array);
		}
		if (RightArrowhead != arrowheadType.Oblique)
		{
			array = GetArrowHeadTriangles(RightArrowhead, _0023_003Dzxd1wPlvPgXlh(), reverse: false);
			list.AddRange(array);
		}
		if (_0023_003DzFM3KC0w_003D == null)
		{
			return new Point3D[1][] { list.ToArray() };
		}
		return Dimension._0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(_0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix()), list.ToArray());
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (base.Compiling)
		{
			if (_dimLineInterruptionPoints != null)
			{
				Point3D[] array = new Point3D[8]
				{
					_vertices[0],
					_vertices[1],
					_vertices[2],
					_dimLineInterruptionPoints[0],
					_dimLineInterruptionPoints[1],
					_vertices[3],
					_vertices[4],
					_vertices[5]
				};
				_0023_003Dz_GuEQ6Cz_DBs(context, array, array.Length);
			}
			else
			{
				_0023_003Dz_GuEQ6Cz_DBs(context, _vertices, 6);
			}
		}
		else
		{
			drawData.DrawBuffer(context, 0);
		}
		DrawHeads(context, myParams);
	}

	protected override void DrawHeadsInternal(RenderContextBase context, object myParams)
	{
		Color? arrowColor = myParams as Color?;
		DrawArrowHead(context, LeftArrowhead, start2D.X, reverse: false, arrowColor);
		DrawArrowHead(context, RightArrowhead, end2D.X, reverse: true, arrowColor);
	}

	internal override void _0023_003DzbC_0024QQAMwgTKD(DrawParams _0023_003DzELu0Pss_003D)
	{
		base._0023_003DzbC_0024QQAMwgTKD(_0023_003DzELu0Pss_003D);
		prevExt = ExtLineExt;
		prevOffset = ExtLineOffset;
		_extLineExt = height * 0.5;
		_extLineOffset = height * 0.25;
	}

	internal override void _0023_003DzWFT5K6qE53AJ()
	{
		_extLineOffset = prevOffset;
		_extLineExt = prevExt;
		base._0023_003DzWFT5K6qE53AJ();
	}

	protected override void DrawArrow(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		context.TranslateMatrixModelView(myDistance, dimLineY, 0.0);
		if (reverse ? (!_arrowsIsInside) : _arrowsIsInside)
		{
			DrawArrowPointingLeft(context);
		}
		else
		{
			DrawArrowPointingRight(context);
		}
		context.PopModelView();
	}

	protected override void DrawTick(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		context.TranslateMatrixModelView(myDistance, dimLineY, 0.0);
		context.RotateMatrixModelView(45.0, 0.0, 0.0, 1.0);
		DrawTick(context);
		context.PopModelView();
	}

	protected override void DrawDot(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		context.TranslateMatrixModelView(myDistance, dimLineY, 0.0);
		DrawDot(context);
		context.PopModelView();
	}

	protected override void DrawOblique(RenderContextBase context, double myDistance, bool reverse)
	{
		context.PushModelView();
		context.TranslateMatrixModelView(myDistance, dimLineY, 0.0);
		context.RotateMatrixModelView(45.0, 0.0, 0.0, 1.0);
		DrawOblique(context);
		context.PopModelView();
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954644) + LeftArrowhead);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954636) + RightArrowhead);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955363) + ExtLineExt);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955342) + ExtLineOffset);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955293) + ShowExtLine1);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955518) + ShowExtLine2);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new LinearDimSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), base.Plane.Origin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), end);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954577), LeftArrowhead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954567), RightArrowhead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954560), ExtLineExt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954528), ExtLineOffset);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954732), ShowExtLine1);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954696), ShowExtLine2);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[3]
			{
				base.Plane.Origin,
				end,
				base.DimLinePosition
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}
}
