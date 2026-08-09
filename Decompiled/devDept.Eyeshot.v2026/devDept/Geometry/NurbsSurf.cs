using System;
using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class NurbsSurf : AnalyticSurf
{
	private int p;

	private int q;

	private double[] U;

	private double[] V;

	private Point4D[,] Pw;

	public int DegreeU => p;

	public int DegreeV => q;

	public double[] KnotVectorU => U;

	public double[] KnotVectorV => V;

	public Point4D[,] ControlPoints => Pw;

	public override bool HasSeam
	{
		get
		{
			Utility._0023_003DzThVkk3uHVTf3(Pw, _0023_003DzMv2C5Tm1QMvc(), _0023_003Dz_0024Cc_PmC_0024ZTq7(), out var _, out var _0023_003DzCq59RVw_003D, out var _0023_003Dzoa6bboA_003D);
			if (_0023_003DzCq59RVw_003D || _0023_003Dzoa6bboA_003D)
			{
				return true;
			}
			return false;
		}
	}

	public NurbsSurf(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, int index = 0)
		: base(index)
	{
		p = uDegree;
		q = vDegree;
		U = uKnotVector;
		V = vKnotVector;
		Pw = ctrlPoints;
	}

	protected NurbsSurf(NurbsSurf another)
		: base(another)
	{
		p = another.p;
		q = another.q;
		U = new double[another.U.Length];
		another.U.CopyTo(U, 0);
		V = new double[another.V.Length];
		another.V.CopyTo(V, 0);
		Pw = new Point4D[another.Pw.GetLength(0), another.Pw.GetLength(1)];
		Utility._0023_003DzD_00245nWTrQrjSP(another.Pw, Pw);
	}

	public override object Clone()
	{
		return new NurbsSurf(this);
	}

	public override bool IsPlanar(double tol, out Plane pln)
	{
		return new Surface(DegreeU, U, DegreeV, V, Pw).IsPlanar(tol, out pln);
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new NurbsSurfSurrogate(this);
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		Surface _0023_003DzF7GfYSI_003D = new Surface(p, U, q, V, Pw);
		return _0023_003Dz9T2qChw_003D(point, _0023_003DzF7GfYSI_003D, out tu, out tv);
	}

	internal Vector3D _0023_003Dz9T2qChw_003D(Point3D _0023_003DzlY77YgY_003D, Surface _0023_003DzF7GfYSI_003D, out Vector3D _0023_003Dze_Mokvc_003D, out Vector3D _0023_003DzH_9cnwY_003D)
	{
		_0023_003DzF7GfYSI_003D.ControlBoundingBox(out var min, out var max);
		Size3D size3D = new Size3D(min, max);
		double coincTol = Utility._0023_003Dzjyaz_Vfaky9X * size3D.Diagonal;
		_0023_003DzF7GfYSI_003D.PointInversion(_0023_003DzlY77YgY_003D, coincTol, out double u, out double v);
		_0023_003DzF7GfYSI_003D._0023_003DzfSoiFiPSG81U(u, v, out var _, out _0023_003Dze_Mokvc_003D, out _0023_003DzH_9cnwY_003D, out var _0023_003DzZbOaTIM_003D);
		return _0023_003DzZbOaTIM_003D;
	}

	internal override bool _0023_003DziYlx1Dzq9Zgl(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = -1;
		return false;
	}

	internal override bool _0023_003Dzp2cxcSDr1evr(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = -1;
		return false;
	}

	public override Surface[] GetSurface(IList<ICurve> trimLoops, bool reverse = false)
	{
		NurbsSurf nurbsSurf = new NurbsSurf(this);
		Surface surface = new Surface(nurbsSurf.p, nurbsSurf.U, nurbsSurf.q, nurbsSurf.V, nurbsSurf.Pw);
		surface.TranslationID = base.TranslationID;
		if (reverse)
		{
			surface.ReverseU();
		}
		if (trimLoops == null)
		{
			return new Surface[1] { surface };
		}
		return Surface._0023_003DzNxaR6FzQJCTX(surface, trimLoops, _0023_003Dz4IdClGB7rrJOo8FQbQ_003D_003D: true, _0023_003DzpGLMqOBpGtiN_0024iaD_0024A_003D_003D: true, _0023_003DzBBEA37cFU9UA_HEvnA_003D_003D: true, null);
	}

	public override Surface GetUntrimmed(IList<ICurve> edgeCurves, bool sense, out Surface notRotated)
	{
		Surface surface = (Surface)new Surface(p, U, q, V, Pw).Clone();
		surface.TranslationID = base.TranslationID;
		if (!sense)
		{
			surface.ReverseU();
		}
		notRotated = surface;
		return surface;
	}

	public override void TransformBy(Transformation xform)
	{
		for (int i = 0; i < _0023_003Dz_0024Cc_PmC_0024ZTq7(); i++)
		{
			for (int j = 0; j < _0023_003DzMv2C5Tm1QMvc(); j++)
			{
				Pw[j, i].TransformBy(xform);
			}
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658618));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980104));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980334) + p + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980318) + _0023_003DzMv2C5Tm1QMvc() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980284) + _0023_003Dzc2sIpYmbrSSe().Low.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964238) + _0023_003Dzc2sIpYmbrSSe().High.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + U.GetStyle(p, _0023_003DzMv2C5Tm1QMvc()).ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980248));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980334) + q + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980318) + _0023_003Dz_0024Cc_PmC_0024ZTq7() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980284) + _0023_003Dz6I0VonsHpxSm().Low.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964238) + _0023_003Dz6I0VonsHpxSm().High.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + V.GetStyle(q, _0023_003Dz_0024Cc_PmC_0024ZTq7()).ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
		return stringBuilder.ToString();
	}

	private int _0023_003Dz_0024Cc_PmC_0024ZTq7()
	{
		return Pw.GetLength(1);
	}

	private int _0023_003DzMv2C5Tm1QMvc()
	{
		return Pw.GetLength(0);
	}

	private Interval _0023_003Dzc2sIpYmbrSSe()
	{
		return new Interval(U.Left(), U.Right());
	}

	private Interval _0023_003Dz6I0VonsHpxSm()
	{
		return new Interval(V.Left(), V.Right());
	}

	internal override void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D()
	{
		collapsedEdges._0023_003DztGdcVOA_003D(Pw, null);
	}

	public override Point3D PointAt(double u, double v)
	{
		return new Surface(p, U, q, V, Pw).PointAt(u, v);
	}
}
