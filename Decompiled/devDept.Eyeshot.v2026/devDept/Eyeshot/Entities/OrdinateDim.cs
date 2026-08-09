using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class OrdinateDim : Dimension
{
	private Point3D _definingPoint;

	private Point3D _leaderEndPoint;

	private double _extLineOffset;

	public bool IsVertical { get; }

	public Point3D Origin => base.Plane.Origin;

	public Point3D DefiningPoint
	{
		get
		{
			return _definingPoint;
		}
		set
		{
			_definingPoint = value;
			DimSetup();
		}
	}

	public Point3D LeaderEndPoint => _leaderEndPoint;

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

	public OrdinateDim(Plane dimPlane, Point3D definingPoint, Point3D dimLinePos, bool isVertical, double textHeight)
		: base(dimPlane, dimPlane.Origin, textHeight)
	{
		_0023_003DztGdcVOA_003D((Point3D)definingPoint.Clone(), isVertical, (Point3D)dimLinePos.Clone());
	}

	public OrdinateDim(Plane sketchPlane, Point2D definingPoint, Point2D dimLinePos, bool isVertical, double textHeight)
		: base(sketchPlane, sketchPlane.Origin, textHeight)
	{
		_0023_003DztGdcVOA_003D(sketchPlane.PointAt(definingPoint), isVertical, sketchPlane.PointAt(dimLinePos));
	}

	protected OrdinateDim(OrdinateDim another)
		: base(another)
	{
		_definingPoint = (Point3D)another._definingPoint.Clone();
		_0023_003Dzde_LaNn_Kpwh(another.IsVertical);
		ExtLineOffset = another.ExtLineOffset;
		DimSetup();
	}

	protected internal OrdinateDim(OrdinateDimSurrogate surrogate)
		: this(surrogate.Plane, surrogate.DefiningPoint, surrogate.DimLinePosition, surrogate.IsVertical, surrogate.Height)
	{
	}

	protected OrdinateDim(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_definingPoint = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973637), typeof(Point3D));
		ExtLineOffset = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954528));
		_0023_003Dzde_LaNn_Kpwh(info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973628)));
		UpdateDistance();
	}

	private void _0023_003DztGdcVOA_003D(Point3D _0023_003Dzj5BUwFK_Tsje, bool _0023_003DzCpjsF78_003D, Point3D _0023_003DzuDL3LADGetTG)
	{
		_definingPoint = _0023_003Dzj5BUwFK_Tsje;
		_0023_003Dzde_LaNn_Kpwh(_0023_003DzCpjsF78_003D);
		ExtLineOffset = height * 0.25;
		base.DimLinePosition = _0023_003DzuDL3LADGetTG;
	}

	public override object Clone()
	{
		return new OrdinateDim(this);
	}

	internal void _0023_003Dzde_LaNn_Kpwh(bool _0023_003DzPzO_0024GUk_003D)
	{
		IsVertical = _0023_003DzPzO_0024GUk_003D;
	}

	internal double _0023_003DzKTDbYiAY8p4J()
	{
		return ExtLineOffset * ScaleOverall;
	}

	protected override void UpdateDistance()
	{
		Point3D point3D = _0023_003DzOITSh_NvlojnSh_0024B3g_003D_003D() * Origin;
		Point3D point3D2 = _0023_003DzOITSh_NvlojnSh_0024B3g_003D_003D() * DefiningPoint;
		base.Distance = Math.Abs(IsVertical ? (point3D.X - point3D2.X) : (point3D.Y - point3D2.Y));
	}

	protected override Transformation GetTextMatrix()
	{
		double sx = (IsVertical ? base.ScaleY : base.ScaleX);
		double sy = (IsVertical ? base.ScaleX : base.ScaleY);
		Transformation result = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ) * new Scaling(base.ScaleBackward, base.ScaleUpsideDown) * new Translation(_textBottomLeft2D.X, _textBottomLeft2D.Y) * new Scaling(sx, sy);
		if (IsVertical)
		{
			result *= (Transformation)new Rotation(Math.PI / 2.0, new Vector3D(0.0, 0.0, 1.0));
		}
		return result;
	}

	internal override void _0023_003DzbC_0024QQAMwgTKD(DrawParams _0023_003DzELu0Pss_003D)
	{
		base._0023_003DzbC_0024QQAMwgTKD(_0023_003DzELu0Pss_003D);
		prevOffset = ExtLineOffset;
		_extLineOffset = height * 0.25;
	}

	internal override void _0023_003DzWFT5K6qE53AJ()
	{
		_extLineOffset = prevOffset;
		base._0023_003DzWFT5K6qE53AJ();
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(_definingPoint.X, _definingPoint.Y, _definingPoint.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		_definingPoint.X = num * array[0];
		_definingPoint.Y = num * array[1];
		_definingPoint.Z = num * array[2];
		if (_leaderEndPoint != null)
		{
			array = xform.ActOnLeft(_leaderEndPoint.X, _leaderEndPoint.Y, _leaderEndPoint.Z, 1.0);
			num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
			_leaderEndPoint.X = num * array[0];
			_leaderEndPoint.Y = num * array[1];
			_leaderEndPoint.Z = num * array[2];
		}
		array = xform.ActOnLeft(base.DimLinePosition.X, base.DimLinePosition.Y, base.DimLinePosition.Z, 1.0);
		num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		base.DimLinePosition.X = num * array[0];
		base.DimLinePosition.Y = num * array[1];
		base.DimLinePosition.Z = num * array[2];
		double scaleFactor = xform.ScaleFactorX;
		if (xform.EqualScaleFactors() || xform.IsScaleFactorUniformForPlanar(base.Plane, ref scaleFactor))
		{
			ExtLineOffset *= scaleFactor;
		}
		base.TransformBy(xform);
		DimSetup();
	}

	private Transformation _0023_003DzOITSh_NvlojnSh_0024B3g_003D_003D()
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(base.Plane, Plane.XY);
		return transformation;
	}

	internal override void RegenInternal(RegenParams _0023_003DzELu0Pss_003D)
	{
		UpdateDistance();
		PrepareText(_0023_003DzELu0Pss_003D, ref myWidthFactor, out exactWidth, out exactDescend, out var _, out var _);
		double _0023_003DzgY7Q1T8TNCW = _0023_003DzJ7p5EJnvP7td();
		double _0023_003DzEPzT0qQPeuuN = _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(arrowheadType.Arrow);
		double _0023_003DznFRw19aTseP = _0023_003DzKTDbYiAY8p4J();
		int verticesLength = 8;
		Point3D[] array = InitVerticesOnPlane(ref verticesLength);
		Transformation transformation = _0023_003DzOITSh_NvlojnSh_0024B3g_003D_003D();
		Point3D _0023_003Dzj5BUwFK_Tsje = transformation * DefiningPoint;
		Point3D point3D = transformation * base.DimLinePosition;
		double x = point3D.X;
		dimLineY = point3D.Y;
		Point3D _0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D;
		Point3D[] array2 = _0023_003Dzm4QUc2NuoxA26pf_GA_003D_003D(_0023_003Dzj5BUwFK_Tsje, point3D, IsVertical, _0023_003DzgY7Q1T8TNCW, _0023_003DzEPzT0qQPeuuN, _0023_003DznFRw19aTseP, base.TextVerticalPosition, out _0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D);
		array[0] = array2[2];
		array[1] = array2[3];
		array[2] = array2[4];
		array[3] = array2[5];
		textLines = new List<string>();
		firstVertexIndexForTexts = 4;
		if (IsVertical)
		{
			double x2 = x - _0023_003DzSKl3eSMXQFvZ();
			array[firstVertexIndexForTexts] = new Point3D(x2, dimLineY - exactWidth / 2.0 + prefixWidth);
			_textBottomLeft2D = new Point2D(x2, dimLineY - exactWidth / 2.0);
		}
		else
		{
			double y = dimLineY + _0023_003DzSKl3eSMXQFvZ();
			array[firstVertexIndexForTexts] = new Point3D(x - exactWidth / 2.0 + prefixWidth, y);
			_textBottomLeft2D = new Point2D(x - exactWidth / 2.0, y);
		}
		_0023_003DzzCaChFUggCUnnuTszAfinDY_003D(array, IsVertical, _0023_003DzjTr87nBCi_hO: false);
		_0023_003Dz0nJAUFysbna4boWQhQ_003D_003D(array);
		_leaderEndPoint = base.Plane.PointAt(_0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D);
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
	}

	public static Segment3D[] Preview(Plane dimPlane, Point3D definingPoint, Point3D dimLinePos, bool isVertical, double textWidth, double hookLen, double offsetFromDefiningPoint, verticalAlignmentType textVerticalPosition, out Point3D leaderEndPoint)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(dimPlane, Plane.XY);
		definingPoint = transformation * definingPoint;
		dimLinePos = transformation * dimLinePos;
		Point3D[] array = _0023_003Dzm4QUc2NuoxA26pf_GA_003D_003D(definingPoint, dimLinePos, isVertical, textWidth, hookLen, offsetFromDefiningPoint, textVerticalPosition, out leaderEndPoint);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = dimPlane.PointAt(array[i]);
		}
		leaderEndPoint = dimPlane.PointAt(leaderEndPoint);
		return new Segment3D[3]
		{
			new Segment3D(array[2], array[3]),
			new Segment3D(array[0], array[1]),
			new Segment3D(array[4], array[5])
		};
	}

	private static Point3D[] _0023_003Dzm4QUc2NuoxA26pf_GA_003D_003D(Point3D _0023_003Dzj5BUwFK_Tsje, Point3D _0023_003Dz2AZWQ2NrfVgE, bool _0023_003DzCpjsF78_003D, double _0023_003DzgY7Q1T8TNCW7, double _0023_003DzEPzT0qQPeuuN, double _0023_003DznFRw19aTseP4, verticalAlignmentType _0023_003Dz5_19amkM2B7E, out Point3D _0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D)
	{
		Point3D[] array = new Point3D[6] { null, null, null, null, null, _0023_003Dzj5BUwFK_Tsje };
		if (_0023_003DzCpjsF78_003D)
		{
			if (_0023_003Dz2AZWQ2NrfVgE.Y > _0023_003Dzj5BUwFK_Tsje.Y)
			{
				array[4] = (Point3D)_0023_003Dzj5BUwFK_Tsje.Clone();
				array[4].Y += 2.0 * _0023_003DzEPzT0qQPeuuN;
				array[2] = (Point3D)_0023_003Dz2AZWQ2NrfVgE.Clone();
				array[2].Y -= _0023_003DzgY7Q1T8TNCW7 / 2.0;
				array[3] = (Point3D)array[2].Clone();
				array[3].Y -= 2.0 * _0023_003DzEPzT0qQPeuuN;
				array[0] = (Point3D)array[3].Clone();
				array[1] = (Point3D)array[4].Clone();
				_0023_003DzOEzSGDYIPPT7ny5m5g_003D_003D(_0023_003DzCpjsF78_003D, -4.0 * _0023_003DzEPzT0qQPeuuN, array);
				_0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D = (Point3D)array[2].Clone();
				if (_0023_003Dz5_19amkM2B7E != verticalAlignmentType.Centered)
				{
					array[2].Y = _0023_003Dz2AZWQ2NrfVgE.Y + _0023_003DzgY7Q1T8TNCW7 / 2.0;
				}
				array[5].Y += _0023_003DznFRw19aTseP4;
			}
			else
			{
				array[4] = (Point3D)_0023_003Dzj5BUwFK_Tsje.Clone();
				array[4].Y -= 2.0 * _0023_003DzEPzT0qQPeuuN;
				array[2] = (Point3D)_0023_003Dz2AZWQ2NrfVgE.Clone();
				array[2].Y += _0023_003DzgY7Q1T8TNCW7 / 2.0;
				array[3] = (Point3D)array[2].Clone();
				array[3].Y += 2.0 * _0023_003DzEPzT0qQPeuuN;
				array[0] = (Point3D)array[3].Clone();
				array[1] = (Point3D)array[4].Clone();
				_0023_003DzOEzSGDYIPPT7ny5m5g_003D_003D(_0023_003DzCpjsF78_003D, 4.0 * _0023_003DzEPzT0qQPeuuN, array);
				_0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D = (Point3D)array[2].Clone();
				if (_0023_003Dz5_19amkM2B7E != verticalAlignmentType.Centered)
				{
					array[2].Y = _0023_003Dz2AZWQ2NrfVgE.Y - _0023_003DzgY7Q1T8TNCW7 / 2.0;
				}
				array[5].Y -= _0023_003DznFRw19aTseP4;
			}
		}
		else if (_0023_003Dz2AZWQ2NrfVgE.X < _0023_003Dzj5BUwFK_Tsje.X)
		{
			array[4] = (Point3D)_0023_003Dzj5BUwFK_Tsje.Clone();
			array[4].X -= 2.0 * _0023_003DzEPzT0qQPeuuN;
			array[2] = (Point3D)_0023_003Dz2AZWQ2NrfVgE.Clone();
			array[2].X += _0023_003DzgY7Q1T8TNCW7 / 2.0;
			array[3] = (Point3D)array[2].Clone();
			array[3].X += 2.0 * _0023_003DzEPzT0qQPeuuN;
			array[0] = (Point3D)array[3].Clone();
			array[1] = (Point3D)array[4].Clone();
			_0023_003DzOEzSGDYIPPT7ny5m5g_003D_003D(_0023_003DzCpjsF78_003D, 4.0 * _0023_003DzEPzT0qQPeuuN, array);
			_0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D = (Point3D)array[2].Clone();
			if (_0023_003Dz5_19amkM2B7E != verticalAlignmentType.Centered)
			{
				array[2].X = _0023_003Dz2AZWQ2NrfVgE.X - _0023_003DzgY7Q1T8TNCW7 / 2.0;
			}
			array[5].X -= _0023_003DznFRw19aTseP4;
		}
		else
		{
			array[4] = (Point3D)_0023_003Dzj5BUwFK_Tsje.Clone();
			array[4].X += 2.0 * _0023_003DzEPzT0qQPeuuN;
			array[2] = (Point3D)_0023_003Dz2AZWQ2NrfVgE.Clone();
			array[2].X -= _0023_003DzgY7Q1T8TNCW7 / 2.0;
			array[3] = (Point3D)array[2].Clone();
			array[3].X -= 2.0 * _0023_003DzEPzT0qQPeuuN;
			array[0] = (Point3D)array[3].Clone();
			array[1] = (Point3D)array[4].Clone();
			_0023_003DzOEzSGDYIPPT7ny5m5g_003D_003D(_0023_003DzCpjsF78_003D, -4.0 * _0023_003DzEPzT0qQPeuuN, array);
			_0023_003Dz8_0024bj6rR13CsUJ6jYgQ_003D_003D = (Point3D)array[2].Clone();
			if (_0023_003Dz5_19amkM2B7E != verticalAlignmentType.Centered)
			{
				array[2].X = _0023_003Dz2AZWQ2NrfVgE.X + _0023_003DzgY7Q1T8TNCW7 / 2.0;
			}
			array[5].X += _0023_003DznFRw19aTseP4;
		}
		return array;
	}

	private static void _0023_003DzOEzSGDYIPPT7ny5m5g_003D_003D(bool _0023_003DzCpjsF78_003D, double _0023_003DzCm_0024dtWSUHZzS, Point3D[] _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D)
	{
		Segment3D seg = new Segment3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[4], _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[5]);
		Segment3D segment3D = new Segment3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[2].ProjectTo(seg), _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[5]);
		Point3D point3D = (Point3D)_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[3].Clone();
		if (_0023_003DzCpjsF78_003D)
		{
			point3D.Y += _0023_003DzCm_0024dtWSUHZzS;
		}
		else
		{
			point3D.X += _0023_003DzCm_0024dtWSUHZzS;
		}
		Segment3D segment3D2 = new Segment3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[3], point3D);
		Segment3D segment3D3 = new Segment3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[3].ProjectTo(seg), _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[5]);
		if (segment3D.Length > Math.Abs(_0023_003DzCm_0024dtWSUHZzS) && segment3D2.Length < segment3D3.Length)
		{
			if (_0023_003DzCpjsF78_003D)
			{
				_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[1].Y = (_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[4].Y = _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[3].Y + _0023_003DzCm_0024dtWSUHZzS);
			}
			else
			{
				_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[1].X = (_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[4].X = _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[3].X + _0023_003DzCm_0024dtWSUHZzS);
			}
		}
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, _vertices, 4, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, _vertices, 4, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	internal override void GetLines(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		base.GetLines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFM3KC0w_003D, _0023_003DzzGo2_Wb1L5us, out _0023_003DzyIUKu5w_003D, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D);
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < 3; i++)
		{
			list.Add((Point3D)_vertices[i].Clone());
			list.Add((Point3D)_vertices[i + 1].Clone());
		}
		list.AddRange(_0023_003DzyIUKu5w_003D);
		_0023_003DzyIUKu5w_003D = list.ToArray();
	}

	internal override Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		if (_0023_003DzFM3KC0w_003D == null)
		{
			return new Point3D[0][];
		}
		return _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, GetTextMatrix());
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (base.Compiling)
		{
			_0023_003Dz_GuEQ6Cz_DBs(context, new Point3D[6]
			{
				_vertices[0],
				_vertices[1],
				_vertices[1],
				_vertices[2],
				_vertices[2],
				_vertices[3]
			}, 6);
		}
		else
		{
			drawData.DrawBuffer(context, 0);
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnitsType.Unitless, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973611) + Origin);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973595) + _definingPoint);
		if (_leaderEndPoint != null)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974323) + _leaderEndPoint);
		}
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955342) + ExtLineOffset);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new OrdinateDimSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973637), _definingPoint);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954528), ExtLineOffset);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973628), IsVertical);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2] { _definingPoint, base.DimLinePosition };
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}
}
