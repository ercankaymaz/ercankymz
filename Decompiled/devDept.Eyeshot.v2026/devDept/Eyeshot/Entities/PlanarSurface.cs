using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Meshing;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class PlanarSurface : Surface
{
	private Plane plane;

	public Plane Plane => plane;

	public PlanarSurface(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, Plane plane)
		: base(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints)
	{
		this.plane = plane;
	}

	protected PlanarSurface(PlanarSurface another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		plane = (Plane)another.plane.Clone();
	}

	protected internal PlanarSurface(PlanarSurfaceSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetQ(), surrogate.GetV(), surrogate.GetPw(), surrogate.GetPlane())
	{
	}

	public PlanarSurface(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		plane = (Plane)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), typeof(Plane));
	}

	internal void _0023_003DzYmD_5Nzhj6Rt(Plane _0023_003DzPzO_0024GUk_003D)
	{
		plane = _0023_003DzPzO_0024GUk_003D;
	}

	public override object Clone()
	{
		return new PlanarSurface(this);
	}

	public override object CloneWithTessellation()
	{
		return new PlanarSurface(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974753) + plane);
		return stringBuilder.ToString();
	}

	internal override AnalyticSurf _0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D()
	{
		return new PlanarSurf((Point3D)Plane.Origin.Clone(), (Vector3D)Plane.AxisZ.Clone(), (Vector3D)Plane.AxisX.Clone());
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new PlanarSurfaceSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), plane);
	}

	public override void TransformBy(Transformation xform)
	{
		Plane pl = (Plane)Plane.Clone();
		plane.TransformBy(xform);
		double scaleFactor = xform.ScaleFactorX;
		if (xform.IsScaleFactorUniform() || xform.IsScaleFactorUniformForPlanar(pl, ref scaleFactor))
		{
			if (Math.Abs(scaleFactor) != 1.0)
			{
				base.KnotVectorU.Scale(scaleFactor);
				base.KnotVectorV.Scale(scaleFactor);
				if (base.Trimming != null)
				{
					base.Trimming.Scale(scaleFactor, scaleFactor, scaleFactor);
				}
			}
			base.TransformBy(xform);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974767));
	}

	public override bool Project(Point3D P, double coincTol, bool allowOutside, out double u, out double v)
	{
		Plane.Project(P, out u, out v);
		if (!allowOutside)
		{
			Utility.LimitRange(base.DomainU.Low, ref u, base.DomainU.High);
			Utility.LimitRange(base.DomainV.Low, ref v, base.DomainV.High);
		}
		return true;
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v)
	{
		bool flag = Project(P, coincTol, true, out u, out v);
		if (!flag)
		{
			return flag;
		}
		Point3D b = PointAt(u, v);
		if (Point3D.DistanceSquared(P, b) > coincTol * coincTol)
		{
			return false;
		}
		return true;
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v, out Vector2D W)
	{
		bool num = PointInversion(P, coincTol, out u, out v);
		W = null;
		if (num && P is PointTangent pt)
		{
			Vector3D axisX = Plane.AxisX;
			Vector3D axisY = Plane.AxisY;
			Surface.TangentVectorInversion(pt, axisX, axisY, out W);
		}
		return num;
	}

	public override Vector3D NormalAt(double u, double v)
	{
		return (Vector3D)Plane.AxisZ.Clone();
	}

	public override bool IsPlanar(double tol, out Plane pln)
	{
		pln = (Plane)Plane.Clone();
		return true;
	}

	public override bool Offset(double amount, double tol, out Surface offsetSurf)
	{
		offsetSurf = (PlanarSurface)Clone();
		offsetSurf.Translate(Plane.AxisZ * amount);
		return true;
	}

	public override void ReverseU()
	{
		plane = new Plane(plane.Origin, -1.0 * plane.AxisX, plane.AxisY);
		base.ReverseU();
	}

	public override void ReverseV()
	{
		plane = new Plane(plane.Origin, plane.AxisX, -1.0 * plane.AxisY);
		base.ReverseV();
	}

	public override ICurve IsocurveU(double v)
	{
		return new Line(PointAt(base.DomainU.Low, v), PointAt(base.DomainU.High, v));
	}

	public override ICurve IsocurveV(double u)
	{
		return new Line(PointAt(u, base.DomainV.Low), PointAt(u, base.DomainV.High));
	}

	internal override void _0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D()
	{
		if (_convexHull == null)
		{
			double num = ControlBoundingBox().Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
			Point3D point3D = (Pw[0, 0].Euclid + Pw[1, 0].Euclid + Pw[1, 1].Euclid + Pw[0, 1].Euclid) / 4.0;
			Point3D[] vertices = new Point3D[4]
			{
				point3D + new Vector3D(point3D, Pw[0, 0].Euclid) * (1.0 + num),
				point3D + new Vector3D(point3D, Pw[1, 0].Euclid) * (1.0 + num),
				point3D + new Vector3D(point3D, Pw[0, 1].Euclid) * (1.0 + num),
				point3D + new Vector3D(point3D, Pw[1, 1].Euclid) * (1.0 + num)
			};
			IndexTriangle[] triangles = new IndexTriangle[2]
			{
				new IndexTriangle(0, 1, 3),
				new IndexTriangle(0, 3, 2)
			};
			_convexHull = new Mesh(vertices, triangles);
		}
	}

	internal override PolyRegion2D _0023_003DzhQpzdmkVcMiA(SizesOnCurve[][] _0023_003DzU7WRl9I_003D, ICurveMesherCreator _0023_003DzxPYeXbo_003D)
	{
		List<Polygon2D> list = new List<Polygon2D>(_trimming.ContourList.Count);
		for (int i = 0; i < _trimming.ContourList.Count; i++)
		{
			ICurve[] individualCurves = _trimming.ContourList[i].GetIndividualCurves();
			List<Point2D> list2 = new List<Point2D> { individualCurves[0].StartPoint };
			for (int j = 0; j < individualCurves.Length; j++)
			{
				TrimCurve trimCurve = (TrimCurve)individualCurves[j];
				CurveMesher curveMesher = _0023_003DzxPYeXbo_003D.CreateCurveMesher(trimCurve.Edge, _0023_003DzU7WRl9I_003D[i][j]);
				curveMesher.DoWork();
				for (int k = 1; k < curveMesher.Result.Vertices.Length; k++)
				{
					list2.Add(Plane.Project(curveMesher.Result.Vertices[k]));
				}
			}
			list.Add(new Polygon2D(list2));
		}
		return new PolyRegion2D(list);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DznMfYYu4y2pvS(Plane.Origin.ToArray(), Plane.AxisZ.ToArray());
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D: true);
		Surface._0023_003DzRJjg7TSwDjXLGDsfug_003D_003D(base.Trimming.ContourList, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
		_0023_003DzYe_6EnQecc8d(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 };
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = _0023_003DzuAMveDQA6vvk();
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = array[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		int _0023_003DzWuk5xhU5RfkzNR16ug_003D_003D = _0023_003DzyzK8swU_003D;
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		obj._0023_003DznXwBXUw4u1qB(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974921));
		_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D obj2 = (_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D)array[1];
		obj2._0023_003DzWuk5xhU5RfkzNR16ug_003D_003D = _0023_003DzWuk5xhU5RfkzNR16ug_003D_003D;
		obj2._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj2._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj2._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[2]
		{
			new _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D(Plane.Origin, Plane.Equation, 1f, ColorMethod == colorMethodType.byEntity, LayerName, Color),
			new _0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D(0, _0023_003Dzu1Nt2pFN_00246wu(), ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}
}
