using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PlanarSurf : AnalyticSurf
{
	private double _amount = 0.01;

	private Plane _plane;

	protected double ExtensionAmount => _amount;

	public Plane Plane => _plane;

	public override bool HasSeam => false;

	public PlanarSurf(Point3D location, Vector3D normal, Vector3D refDir, int index = 0)
		: base(index)
	{
		if (refDir.IsZero)
		{
			_plane = new Plane(location, normal);
		}
		else
		{
			_plane = new Plane(location, refDir, Vector3D.Cross(normal, refDir));
		}
	}

	protected internal PlanarSurf(Plane plane, int index = 0)
		: base(index)
	{
		_plane = plane;
	}

	protected PlanarSurf(PlanarSurf another)
		: base(another)
	{
		_plane = (Plane)another.Plane.Clone();
	}

	public override object Clone()
	{
		return new PlanarSurf(this);
	}

	public override bool IsPlanar(double tol, out Plane pln)
	{
		if (GetType() == typeof(PlanarSurf))
		{
			pln = Plane;
			return true;
		}
		return base.IsPlanar(tol, out pln);
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new PlanarSurfSurrogate(this);
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		tu = (Vector3D)Plane.AxisX.Clone();
		tv = (Vector3D)Plane.AxisY.Clone();
		return (Vector3D)Plane.AxisZ.Clone();
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
		Curve._0023_003Dz61B8IYSGx6wG(trimLoops, out var _0023_003DzF7v9r2A_003D, out var _0023_003Dz8dK2uhU_003D);
		PlanarSurface planarSurface = Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(Plane, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		planarSurface.TranslationID = base.TranslationID;
		if (reverse)
		{
			planarSurface.ReverseU();
		}
		List<ICurve> list = new List<ICurve>();
		for (int i = 0; i < trimLoops.Count; i++)
		{
			ICurve curve = trimLoops[i];
			if (!(curve is CompositeCurve))
			{
				continue;
			}
			CompositeCurve compositeCurve = (CompositeCurve)curve;
			bool flag = true;
			int count = compositeCurve.CurveList.Count;
			for (int j = 0; j < count - 1; j++)
			{
				if (!(compositeCurve.CurveList[j] is Line))
				{
					flag = false;
				}
			}
			if (flag)
			{
				LinearPath linearPath = new LinearPath(count + 1);
				for (int k = 0; k < count; k++)
				{
					ICurve curve2 = compositeCurve.CurveList[k];
					linearPath.Vertices[k] = curve2.StartPoint;
				}
				linearPath.Vertices[count] = (Point3D)linearPath.Vertices[0].Clone();
				list.Add(linearPath);
			}
			else
			{
				list.Add(curve);
			}
		}
		Surface surface = Surface._0023_003DzCaJhR_0024Jdhxn_0024lcMUgA_003D_003D(planarSurface.Plane, trimLoops).ConvertToSurface();
		return new Surface[1] { surface };
	}

	public override Surface GetUntrimmed(IList<ICurve> edgeCurves, bool sense, out Surface notRotated)
	{
		Curve._0023_003Dz61B8IYSGx6wG(edgeCurves, Plane, out var _0023_003DzF7v9r2A_003D, out var _0023_003Dz8dK2uhU_003D);
		Size2D size2D = new Size2D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		double num = ((size2D.X > Utility._0023_003DzxhnLabVjXjPg) ? size2D.X : 1E-05);
		double num2 = ((size2D.Y > Utility._0023_003DzxhnLabVjXjPg) ? size2D.Y : 1E-05);
		_0023_003DzF7v9r2A_003D.X -= num * _amount;
		_0023_003Dz8dK2uhU_003D.X += num * _amount;
		_0023_003DzF7v9r2A_003D.Y -= num2 * _amount;
		_0023_003Dz8dK2uhU_003D.Y += num2 * _amount;
		PlanarSurface planarSurface = new PlanarSurface(1, new double[4] { _0023_003DzF7v9r2A_003D.X, _0023_003DzF7v9r2A_003D.X, _0023_003Dz8dK2uhU_003D.X, _0023_003Dz8dK2uhU_003D.X }, 1, new double[4] { _0023_003DzF7v9r2A_003D.Y, _0023_003DzF7v9r2A_003D.Y, _0023_003Dz8dK2uhU_003D.Y, _0023_003Dz8dK2uhU_003D.Y }, new Point4D[2, 2]
		{
			{
				new Point4D(Plane.PointAt(_0023_003DzF7v9r2A_003D.X, _0023_003DzF7v9r2A_003D.Y)),
				new Point4D(Plane.PointAt(_0023_003DzF7v9r2A_003D.X, _0023_003Dz8dK2uhU_003D.Y))
			},
			{
				new Point4D(Plane.PointAt(_0023_003Dz8dK2uhU_003D.X, _0023_003DzF7v9r2A_003D.Y)),
				new Point4D(Plane.PointAt(_0023_003Dz8dK2uhU_003D.X, _0023_003Dz8dK2uhU_003D.Y))
			}
		}, Plane);
		planarSurface.TranslationID = base.TranslationID;
		if (!sense)
		{
			planarSurface.ReverseU();
		}
		notRotated = planarSurface;
		return planarSurface;
	}

	internal static void _0023_003DzHNhzuamBoympuHB_8w_003D_003D(Plane _0023_003Dzpyw2kZk_003D, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, out Interval _0023_003DzG0W_0024gTEMzheB, out Interval _0023_003DzliazXp7OuE_N)
	{
		Segment3D segment3D = new Segment3D(_0023_003Dzpyw2kZk_003D.Origin, _0023_003Dzpyw2kZk_003D.Origin + _0023_003Dzpyw2kZk_003D.AxisZ);
		_0023_003DzG0W_0024gTEMzheB = new Interval(double.MaxValue, double.MinValue);
		Interval interval = new Interval(Math.PI, 0.0);
		Interval interval2 = new Interval(Math.PI * 2.0, Math.PI);
		Interval interval3 = new Interval(7.853981633974483, 4.71238898038469);
		Interval interval4 = new Interval(4.71238898038469, Math.PI);
		List<Curve> list = new List<Curve>();
		foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
		{
			ICurve[] individualCurves = item.GetIndividualCurves();
			foreach (ICurve curve in individualCurves)
			{
				list.Add(curve.GetNurbsForm());
			}
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		foreach (Curve item2 in list)
		{
			int num6 = item2._0023_003DzMv2C5Tm1QMvc();
			for (int j = 0; j < num6; j++)
			{
				num++;
				Point3D euclid = item2.ControlPoints[j].Euclid;
				double num7 = segment3D.Project(euclid);
				if (num7 < _0023_003DzG0W_0024gTEMzheB.t0)
				{
					_0023_003DzG0W_0024gTEMzheB.t0 = num7;
				}
				if (num7 > _0023_003DzG0W_0024gTEMzheB.t1)
				{
					_0023_003DzG0W_0024gTEMzheB.t1 = num7;
				}
				Point2D point2D = _0023_003Dzpyw2kZk_003D.Project(euclid);
				double num8 = Utility.ArcTanProblem(point2D.X, point2D.Y);
				if (point2D.Y > 0.0)
				{
					num2++;
					if (num8 < interval.t0)
					{
						interval.t0 = num8;
					}
					if (num8 > interval.t1)
					{
						interval.t1 = num8;
					}
				}
				else
				{
					num3++;
					if (num8 < interval2.t0)
					{
						interval2.t0 = num8;
					}
					if (num8 > interval2.t1)
					{
						interval2.t1 = num8;
					}
				}
				if (point2D.X < 0.0)
				{
					num4++;
					if (num8 < interval4.t0)
					{
						interval4.t0 = num8;
					}
					if (num8 > interval4.t1)
					{
						interval4.t1 = num8;
					}
					continue;
				}
				num5++;
				if (num8 < Math.PI / 2.0)
				{
					num8 += Math.PI * 2.0;
				}
				if (num8 < interval3.t0)
				{
					interval3.t0 = num8;
				}
				if (num8 > interval3.t1)
				{
					interval3.t1 = num8;
				}
			}
		}
		if (num5 == num)
		{
			_0023_003DzliazXp7OuE_N = interval3;
		}
		else if (num4 == num)
		{
			_0023_003DzliazXp7OuE_N = interval4;
		}
		else if (num2 == num)
		{
			_0023_003DzliazXp7OuE_N = interval;
		}
		else if (num3 == num)
		{
			_0023_003DzliazXp7OuE_N = interval2;
		}
		else
		{
			_0023_003DzliazXp7OuE_N = new Interval(0.0, 0.0);
		}
	}

	internal static void _0023_003DzHNhzuamBoympuHB_8w_003D_003D(Plane _0023_003Dzpyw2kZk_003D, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, out Interval _0023_003DzG0W_0024gTEMzheB)
	{
		_0023_003DzG0W_0024gTEMzheB = Utility._0023_003DzHNhzuamBoympuHB_8w_003D_003D(_0023_003Dzpyw2kZk_003D.Origin, _0023_003Dzpyw2kZk_003D.AxisZ, _0023_003DzRTbTK_0024KwG32W);
	}

	internal static void _0023_003Dzq2rheECiVvE_Rpm9bw_003D_003D(Segment3D _0023_003DzFDJdA7A_003D, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, out Interval _0023_003Dz5D8mFln5vcyJ)
	{
		_0023_003Dz5D8mFln5vcyJ = new Interval(double.MaxValue, double.MinValue);
		foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
		{
			ICurve[] individualCurves = item.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				Curve nurbsForm = individualCurves[i].GetNurbsForm();
				int num = nurbsForm._0023_003DzMv2C5Tm1QMvc();
				for (int j = 0; j < num; j++)
				{
					double num2 = nurbsForm.ControlPoints[j].Euclid.DistanceTo(_0023_003DzFDJdA7A_003D);
					if (num2 < _0023_003Dz5D8mFln5vcyJ.t0)
					{
						_0023_003Dz5D8mFln5vcyJ.t0 = num2;
					}
					if (num2 > _0023_003Dz5D8mFln5vcyJ.t1)
					{
						_0023_003Dz5D8mFln5vcyJ.t1 = num2;
					}
				}
			}
		}
	}

	internal static bool _0023_003DzvyAuVZcDxArs6XmJHcj7N_00248_003D(IList<ICurve> _0023_003DzRTbTK_0024KwG32W, Curve _0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D, Vector3D _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, out Interval _0023_003Dz6Jdj4TI_003D, out Vector3D _0023_003DzYNjcavt9guh2, out double _0023_003Dz_EiucSU_003D)
	{
		List<Segment3D> list = new List<Segment3D>();
		list.Add(new Segment3D(_0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D.StartPoint, _0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D.StartPoint + _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D));
		for (int i = 0; i < _0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D._0023_003DziP9fFuA_003D.Length - 1; i++)
		{
			if (_0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D._0023_003DziP9fFuA_003D[i] != _0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D._0023_003DziP9fFuA_003D[i + 1])
			{
				Point3D point3D = _0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D.PointAt(_0023_003Dz_002479GqV8CBtk_wrjmnQ_003D_003D._0023_003DziP9fFuA_003D[i + 1]);
				list.Add(new Segment3D(point3D, point3D + _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D));
			}
		}
		HashSet<double> hashSet = new HashSet<double>();
		foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
		{
			ICurve[] individualCurves = item.GetIndividualCurves();
			foreach (ICurve curve in individualCurves)
			{
				Curve nurbsForm = curve.GetNurbsForm();
				if (curve is EllipticalArc && nurbsForm.Pw.Length == 3 && ((EllipticalArc)curve).Domain.Length > Math.PI * 2.0 / 3.0)
				{
					continue;
				}
				nurbsForm.ControlBoundingBox(out var min, out var max);
				Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(min, max);
				foreach (Segment3D item2 in list)
				{
					Point3D[] array = boundingBoxCorners;
					foreach (Point3D pt in array)
					{
						hashSet.Add(item2.Project(pt));
					}
				}
			}
		}
		double[] array2 = hashSet.ToArray();
		Array.Sort(array2);
		double t = array2[0];
		double t2 = array2[^1];
		_0023_003Dz_EiucSU_003D = 0.1;
		_0023_003Dz6Jdj4TI_003D = new Interval(t, t2);
		if (_0023_003Dz6Jdj4TI_003D.Length < Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003DzYNjcavt9guh2 = new Vector3D();
			return false;
		}
		_0023_003DzYNjcavt9guh2 = (1.0 + 2.0 * _0023_003Dz_EiucSU_003D) * _0023_003Dz6Jdj4TI_003D.Length * _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D;
		return true;
	}

	public override void TransformBy(Transformation xform)
	{
		Plane.TransformBy(xform);
		if (xform.HasReflection)
		{
			Plane.Flip();
			Plane.Rotate(Math.PI / 2.0, Plane.AxisZ, Plane.Origin);
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659415) + Plane.Origin);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659406) + Plane.AxisZ);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659361) + Plane.AxisX);
		return stringBuilder.ToString();
	}

	internal override void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D()
	{
	}

	public override Point3D PointAt(double u, double v)
	{
		return Plane.PointAt(u, v);
	}
}
