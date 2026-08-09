using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class TrimCurve : Curve
{
	internal Surface originalSurface;

	private ICurve _edge;

	internal bool dontEnrich;

	internal Brep._0023_003DzKfMGQQU_003D FaceInfo;

	internal bool fromTangentEdgeParent;

	internal bool? refinedToleranceforPlanarCut;

	public int Index { get; set; } = -1;

	public ICurve Edge
	{
		get
		{
			return _edge;
		}
		set
		{
			_edge = value;
		}
	}

	public TrimCurve(int degree, double[] knotVector, Point4D[] ctrlPoints, ICurve edge)
		: base(degree, knotVector, ctrlPoints)
	{
		_edge = edge;
	}

	public TrimCurve(Curve parametricSpace, ICurve modelSpace)
		: base(parametricSpace)
	{
		_edge = modelSpace;
	}

	internal TrimCurve()
	{
	}

	protected TrimCurve(TrimCurve another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		if (another._edge != null)
		{
			if (keepTessellation)
			{
				_edge = (ICurve)((Entity)another._edge).CloneWithTessellation();
			}
			else
			{
				_edge = (ICurve)another._edge.Clone();
				if (((Entity)another._edge).Vertices != null)
				{
					((Entity)_edge).Vertices = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(((Entity)another._edge).Vertices);
				}
			}
		}
		if (another.originalSurface != null)
		{
			originalSurface = another.originalSurface;
		}
		Index = another.Index;
		dontEnrich = another.dontEnrich;
		FaceInfo = another.FaceInfo;
	}

	protected internal TrimCurve(TrimCurveSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetPw(), surrogate.Edge as ICurve)
	{
	}

	internal TrimCurve(GTrimCurve _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.P, _0023_003DzQwa1qM0_003D.U, _0023_003DzQwa1qM0_003D.Pw, GEntity.CreateEntityFromPrimitive(_0023_003DzQwa1qM0_003D.Edge) as ICurve)
	{
	}

	public TrimCurve(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_edge = (ICurve)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958913), typeof(ICurve));
	}

	public override object Clone()
	{
		return new TrimCurve(this);
	}

	public override object CloneWithTessellation()
	{
		return new TrimCurve(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982462));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982424));
		stringBuilder.Append(((Entity)_edge).Dump(linearUnits, massUnits, null, materials));
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new TrimCurveSurrogate(this);
	}

	public override void Reverse()
	{
		base.Reverse();
		if (Vertices != null)
		{
			Array.Reverse(Vertices, 0, Vertices.Length);
		}
		if (_edge == null)
		{
			return;
		}
		_edge.Reverse();
		if (!(_edge is Line) && !(_edge is LinearPath))
		{
			Point3D[] vertices = ((Entity)_edge).Vertices;
			if (vertices != null)
			{
				Array.Reverse(vertices, 0, vertices.Length);
			}
		}
	}

	public override bool SubCurve(double uStart, double uEnd, out ICurve sub)
	{
		ICurve sub2;
		bool num = base.SubCurve(uStart, uEnd, out sub2);
		if (num)
		{
			if (_edge != null)
			{
				sub = ((Curve)sub2)._0023_003DzmGgqdRaHiXdg((ICurve)_edge.Clone());
				return num;
			}
			sub = ((Curve)sub2)._0023_003DzmGgqdRaHiXdg(_edge);
			return num;
		}
		sub = null;
		return num;
	}

	public override bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		ICurve sub2;
		bool num = base.SubCurve(startPt, endPt, out sub2);
		if (num)
		{
			if (_edge != null)
			{
				sub = ((Curve)sub2)._0023_003DzmGgqdRaHiXdg((ICurve)_edge.Clone());
				return num;
			}
			sub = ((Curve)sub2)._0023_003DzmGgqdRaHiXdg(_edge);
			return num;
		}
		sub = null;
		return num;
	}

	internal static _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003Dzr6lX0LAcmuDg(ICurve _0023_003DzTx2aqr8_003D)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2 = new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D();
		List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> list = new List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>();
		if (_0023_003DzTx2aqr8_003D is Line line)
		{
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2._0023_003DzBHs1Mmk_003D(line.StartPoint.ToArray(), line.EndPoint.ToArray());
		}
		else if (_0023_003DzTx2aqr8_003D is Circle circle)
		{
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2._0023_003DzT862__0024Xk5q8pozbUqA_003D_003D(circle.Center.ToArray(), circle.Radius, circle.Plane.AxisX.ToArray(), circle.Plane.AxisY.ToArray());
		}
		else if (_0023_003DzTx2aqr8_003D is Ellipse ellipse)
		{
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2._0023_003DzACk1EOs5Ii85(ellipse.Center.ToArray(), ellipse.RadiusX, ellipse.RadiusY, ellipse.Plane.AxisX.ToArray(), ellipse.Plane.AxisY.ToArray());
		}
		else if (_0023_003DzTx2aqr8_003D is Curve { Pw: var pw } curve)
		{
			foreach (Point4D point4D in pw)
			{
				list.Add(new _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D(point4D.X / point4D.W, point4D.Y / point4D.W, point4D.Z / point4D.W, point4D.W));
			}
			if (curve.IsRational)
			{
				_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2._0023_003DzqVHn7UdWSyzx(curve._0023_003DzB68dg9Q_003D, new List<double>(curve._0023_003DziP9fFuA_003D), list);
			}
			else
			{
				_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2._0023_003DzDzC91SBb2vjN(curve._0023_003DzB68dg9Q_003D, new List<double>(curve._0023_003DziP9fFuA_003D), list);
			}
		}
		else if (_0023_003DzTx2aqr8_003D is CompositeCurve compositeCurve)
		{
			_0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D[] array = new _0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D[compositeCurve.CurveList.Count];
			for (int j = 0; j < compositeCurve.CurveList.Count; j++)
			{
				array[j] = new _0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D(((Entity)compositeCurve.CurveList[j])._0023_003DzAKDLnmImamFN(Color.Black, null, linearUnitsType.Unitless)[0]);
			}
			new _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D(array, _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D: false);
			throw new NotImplementedException();
		}
		return _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2;
	}

	internal static _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzDj2isiZZZIae(ICurve _0023_003DzTx2aqr8_003D)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D obj = _0023_003Dzr6lX0LAcmuDg(_0023_003DzTx2aqr8_003D);
		obj._0023_003Dze8HLGHdo_0024aUJ(new _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D(_0023_003DzTx2aqr8_003D.StartPoint.X, _0023_003DzTx2aqr8_003D.StartPoint.Y, _0023_003DzTx2aqr8_003D.StartPoint.Z, 1.0));
		obj._0023_003DzkiChZxXAOBwG(new _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D(_0023_003DzTx2aqr8_003D.EndPoint.X, _0023_003DzTx2aqr8_003D.EndPoint.Y, _0023_003DzTx2aqr8_003D.EndPoint.Z, 1.0));
		obj._0023_003DzGwuYzgEfSgJW = true;
		return obj;
	}

	public override string ToString()
	{
		if (_edge != null)
		{
			string text = _edge.GetType().ToString().Split('.')[^1];
			bool flag = _edge is Circle;
			if (((Entity)_edge).Vertices != null)
			{
				if (flag)
				{
					return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982642), base.StartPoint.X, base.StartPoint.Y, base.EndPoint.X, base.EndPoint.Y, text, ((Circle)_edge).Radius, _edge.StartPoint, _edge.EndPoint, ((Entity)_edge).Vertices.Length, Index, base.EdgeIndex);
				}
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982557), base.StartPoint.X, base.StartPoint.Y, base.EndPoint.X, base.EndPoint.Y, text, _edge.StartPoint, _edge.EndPoint, ((Entity)_edge).ToString().Length, Index, base.EdgeIndex);
			}
			if (flag)
			{
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982208), base.StartPoint.X, base.StartPoint.Y, base.EndPoint.X, base.EndPoint.Y, text, ((Circle)_edge).Radius, _edge.StartPoint, _edge.EndPoint, Index, base.EdgeIndex);
			}
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982342), base.StartPoint.X, base.StartPoint.Y, base.EndPoint.X, base.EndPoint.Y, text, _edge.StartPoint, _edge.EndPoint, Index, base.EdgeIndex);
		}
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983039), base.StartPoint.X, base.StartPoint.Y, base.EndPoint.X, base.EndPoint.Y, Index, base.EdgeIndex);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958913), _edge);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		return ((Entity)Edge)._0023_003DzuAMveDQA6vvk();
	}

	public bool IsHorizontal(double domainV)
	{
		if (Utility.IsLine(this))
		{
			return Utility.AreEqual(Pw[0].Y, Pw[1].Y, domainV);
		}
		return false;
	}

	public bool IsVertical(double domainU)
	{
		if (Utility.IsLine(this))
		{
			return Utility.AreEqual(Pw[0].X, Pw[1].X, domainU);
		}
		return false;
	}

	internal bool _0023_003DzilaVq9lUAYio(double _0023_003DziNACtEGVcTJY, BoundingCone _0023_003DzFeEghKc_003D)
	{
		if (_0023_003DzFeEghKc_003D == null)
		{
			return false;
		}
		Vector2D vector2D = new Vector2D(_0023_003DzFeEghKc_003D.Axis.X, _0023_003DzFeEghKc_003D.Axis.Y);
		double num = Utility.ArcTanProblem(vector2D.X, vector2D.Y);
		if (num < _0023_003DziNACtEGVcTJY || num > Math.PI * 2.0 - _0023_003DziNACtEGVcTJY)
		{
			return true;
		}
		return false;
	}

	internal bool _0023_003Dz1Wx_0024MkKldSDb4Wy10g_003D_003D(double _0023_003DziNACtEGVcTJY, BoundingCone _0023_003DzFeEghKc_003D)
	{
		if (_0023_003DzFeEghKc_003D == null)
		{
			return false;
		}
		Vector2D vector2D = new Vector2D(_0023_003DzFeEghKc_003D.Axis.X, _0023_003DzFeEghKc_003D.Axis.Y);
		double num = Utility.ArcTanProblem(vector2D.X, vector2D.Y);
		if (num > Math.PI / 2.0 - _0023_003DziNACtEGVcTJY && num < Math.PI / 2.0 + _0023_003DziNACtEGVcTJY)
		{
			return true;
		}
		return false;
	}

	internal bool _0023_003DzekN1Mmr9L4Zx(double _0023_003DziNACtEGVcTJY, BoundingCone _0023_003DzFeEghKc_003D)
	{
		if (_0023_003DzFeEghKc_003D == null)
		{
			return false;
		}
		Vector2D vector2D = new Vector2D(_0023_003DzFeEghKc_003D.Axis.X, _0023_003DzFeEghKc_003D.Axis.Y);
		double num = Utility.ArcTanProblem(vector2D.X, vector2D.Y);
		if (num > Math.PI - _0023_003DziNACtEGVcTJY && num < Math.PI + _0023_003DziNACtEGVcTJY)
		{
			return true;
		}
		return false;
	}

	internal bool _0023_003DzAwkNbKCyuKPITvXE_Q_003D_003D(double _0023_003DziNACtEGVcTJY, BoundingCone _0023_003DzFeEghKc_003D)
	{
		if (_0023_003DzFeEghKc_003D == null)
		{
			return false;
		}
		Vector2D vector2D = new Vector2D(_0023_003DzFeEghKc_003D.Axis.X, _0023_003DzFeEghKc_003D.Axis.Y);
		double num = Utility.ArcTanProblem(vector2D.X, vector2D.Y);
		if (num > 4.71238898038469 - _0023_003DziNACtEGVcTJY && num < 4.71238898038469 + _0023_003DziNACtEGVcTJY)
		{
			return true;
		}
		return false;
	}
}
