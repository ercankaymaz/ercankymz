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
public class DiametricDim : RadialDim, ITwoArrowheads
{
	private arrowheadType _leftArrowhead;

	private arrowheadType _rightArrowhead;

	public override bool TrimLeader
	{
		get
		{
			return false;
		}
		set
		{
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

	public DiametricDim(Circle circle, Point3D dimLinePos, double textHeight)
		: base(circle, dimLinePos, textHeight)
	{
		_0023_003DztGdcVOA_003D();
	}

	public DiametricDim(Circle circle, Point2D dimLinePos, double textHeight)
		: base(circle, dimLinePos, textHeight)
	{
		_0023_003DztGdcVOA_003D();
	}

	public DiametricDim(Circle circle, Point3D dimLinePos, double textHeight, Plane refPlane)
		: base(circle, dimLinePos, textHeight, refPlane)
	{
		_0023_003DztGdcVOA_003D();
	}

	public DiametricDim(Circle circle, double distance, double rotation, double textHeight, Plane refPlane)
		: base(circle, distance, rotation, textHeight, refPlane)
	{
		_0023_003DztGdcVOA_003D();
	}

	public DiametricDim(Circle circle, Point2D dimLinePos, double textHeight, Plane refPlane)
		: base(circle, dimLinePos, textHeight, refPlane)
	{
		_0023_003DztGdcVOA_003D();
	}

	protected DiametricDim(DiametricDim another)
		: base(another)
	{
		LeftArrowhead = another.LeftArrowhead;
		RightArrowhead = another.RightArrowhead;
	}

	protected internal DiametricDim(DiametricDimSurrogate surrogate)
		: this(new Circle(surrogate.Plane, surrogate.Radius), surrogate.DimLinePosition, surrogate.Height)
	{
	}

	protected DiametricDim(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		LeftArrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965636), typeof(arrowheadType));
		RightArrowhead = (arrowheadType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965370), typeof(arrowheadType));
	}

	private void _0023_003DztGdcVOA_003D()
	{
		base.TextPrefix = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965359);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new DiametricDimSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965636), LeftArrowhead);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965370), RightArrowhead);
	}

	public override object Clone()
	{
		return new DiametricDim(this);
	}

	protected override void UpdateDistance()
	{
		base.Distance = 2.0 * base.Radius;
	}

	internal override void RegenInternal(RegenParams _0023_003DzELu0Pss_003D)
	{
		PrepareText(_0023_003DzELu0Pss_003D, ref myWidthFactor, out exactWidth, out exactDescend, out var _, out var _);
		double num = _0023_003DzJ7p5EJnvP7td();
		double num2 = num / 2.0;
		double textDistFromOrigin;
		Point3D[] array = PreProcess(out textDistFromOrigin);
		switch (base.TextLocation)
		{
		case elementPositionType.Auto:
			_textIsInside = num < base.Distance;
			_textIsInside &= textDistFromOrigin < base.Radius;
			break;
		case elementPositionType.Inside:
			_textIsInside = true;
			break;
		case elementPositionType.Outside:
			_textIsInside = false;
			break;
		}
		double _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D = Math.Abs(base.Radius - textDistFromOrigin);
		double value = textDistFromOrigin + base.Radius;
		_0023_003DzL3Hw_0024qWYdWdp_0024JA5XQ_003D_003D(LeftArrowhead, RightArrowhead, num, base.Distance, _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D, value, _0023_003DzL2lT7qyADIGH: false);
		double num3 = base.Radius + num2 + _0023_003DzyH_0024xWtf1YBY_7n7_Rd54RUs_003D(RightArrowhead);
		if (!_textIsInside && textDistFromOrigin < num3)
		{
			textDistFromOrigin = num3;
		}
		double num4 = base.Radius - num2 - _0023_003Dz9ACJTcDlsOrBkRMssrasU3Y_003D(LeftArrowhead);
		if (textDistFromOrigin > num4 && textDistFromOrigin <= base.Radius && _textIsInside)
		{
			textDistFromOrigin = ((!(base.Radius * 2.0 < num + 2.0 * _0023_003Dz9ACJTcDlsOrBkRMssrasU3Y_003D(RightArrowhead))) ? num4 : 0.0);
		}
		else if (textDistFromOrigin > base.Radius && textDistFromOrigin <= num3 && !_textIsInside)
		{
			textDistFromOrigin = num3;
		}
		else if (_textIsInside)
		{
			if (textDistFromOrigin > num4)
			{
				textDistFromOrigin = num4;
			}
		}
		else if (textDistFromOrigin < num3)
		{
			textDistFromOrigin = num3;
		}
		array[0].X = (_arrowsIsInside ? (0.0 - base.Radius) : (0.0 - (base.Radius + _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(RightArrowhead))));
		PostProcess(array, base.Distance / 2.0, textDistFromOrigin, num);
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
	}

	internal override void GetLines(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		base.GetLines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFM3KC0w_003D, _0023_003DzzGo2_Wb1L5us, out _0023_003DzyIUKu5w_003D, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D);
		List<Point3D> list = new List<Point3D>();
		_0023_003DzbqHqSeT0TbL3(_0023_003DzzGo2_Wb1L5us, list);
		list.AddRange(_0023_003DzyIUKu5w_003D);
		_0023_003DzyIUKu5w_003D = list.ToArray();
	}

	private protected override void _0023_003DzbqHqSeT0TbL3(bool _0023_003DzzGo2_Wb1L5us, List<Point3D> _0023_003Dz6QQCnmDNDQzBvgUBuw_003D_003D)
	{
		Point3D[] array = null;
		if (!_0023_003DzzGo2_Wb1L5us || LeftArrowhead == arrowheadType.Oblique)
		{
			array = GetArrowHeadPoints(LeftArrowhead, _0023_003DzKw0JSvso00Xq(), reverse: false);
			_0023_003Dz6QQCnmDNDQzBvgUBuw_003D_003D.AddRange(array);
		}
		if (!_0023_003DzzGo2_Wb1L5us || RightArrowhead == arrowheadType.Oblique)
		{
			array = GetArrowHeadPoints(RightArrowhead, _0023_003Dzxd1wPlvPgXlh(), reverse: true);
			_0023_003Dz6QQCnmDNDQzBvgUBuw_003D_003D.AddRange(array);
		}
	}

	internal override Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		List<Point3D> list = new List<Point3D>();
		Point3D[] array = null;
		if (LeftArrowhead != arrowheadType.Oblique)
		{
			array = GetArrowHeadTriangles(LeftArrowhead, _0023_003DzKw0JSvso00Xq(), reverse: false);
			list.AddRange(array);
		}
		if (RightArrowhead != arrowheadType.Oblique)
		{
			array = GetArrowHeadTriangles(RightArrowhead, _0023_003Dzxd1wPlvPgXlh(), reverse: true);
			list.AddRange(array);
		}
		if (_0023_003DzFM3KC0w_003D == null)
		{
			return new Point3D[1][] { list.ToArray() };
		}
		return Dimension._0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(_0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix()), list.ToArray());
	}

	private Transformation _0023_003DzKw0JSvso00Xq()
	{
		return new Rotation(angle, new Vector3D(0.0, 0.0, 1.0)) * new Translation(base.Radius, 0.0);
	}

	private Transformation _0023_003Dzxd1wPlvPgXlh()
	{
		return new Rotation(angle, new Vector3D(0.0, 0.0, 1.0)) * new Translation(0.0 - base.Radius, 0.0);
	}

	protected override void DrawHeadsInternal(RenderContextBase context, object myParams)
	{
		Color? arrowColor = myParams as Color?;
		DrawArrowHead(context, LeftArrowhead, base.Radius, reverse: false, arrowColor);
		DrawArrowHead(context, RightArrowhead, base.Radius, reverse: true, arrowColor);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954644) + LeftArrowhead);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954636) + RightArrowhead);
		return stringBuilder.ToString();
	}
}
