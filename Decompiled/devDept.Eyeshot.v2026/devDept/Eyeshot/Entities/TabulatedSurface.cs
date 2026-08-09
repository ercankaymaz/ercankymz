using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class TabulatedSurface : Surface
{
	private ICurve _directrix;

	private Vector3D _generatrix;

	internal double scaleU = 1.0;

	public ICurve Directrix => _directrix;

	public Vector3D Generatrix => _generatrix;

	public TabulatedSurface(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, Vector3D theGeneratrix, ICurve theDirectrix)
	{
		_0023_003Dzk__0024yqBPiVV__(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints);
		_generatrix = theGeneratrix;
		_directrix = theDirectrix;
		ICurve _0023_003DzCqUI6VbvL79X = (ICurve)_directrix.Clone();
		ICurve _0023_003DzzmPi46a_0024aQ2V = new Line((Point3D)_directrix.EndPoint.Clone(), _directrix.EndPoint + _generatrix);
		ICurve curve = (ICurve)_directrix.Clone();
		((Entity)curve).Translate(_generatrix);
		curve.Reverse();
		Line line = new Line((Point3D)_directrix.StartPoint.Clone(), _directrix.StartPoint + _generatrix);
		line.Reverse();
		base.Trimming = _0023_003Dzrkte6ryoSSy1(base.DomainU.Low, base.DomainV.Low, base.DomainU.High, base.DomainV.High, _0023_003DzCqUI6VbvL79X, _0023_003DzzmPi46a_0024aQ2V, curve, line);
	}

	protected TabulatedSurface(TabulatedSurface another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_generatrix = (Vector3D)another._generatrix.Clone();
		_directrix = (ICurve)another._directrix.Clone();
		scaleU = another.scaleU;
	}

	protected internal TabulatedSurface(TabulatedSurfaceSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetQ(), surrogate.GetV(), surrogate.GetPw(), surrogate.GetGeneratrix(), surrogate.GetDirectrix() as ICurve)
	{
	}

	public TabulatedSurface(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_generatrix = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976224), typeof(Vector3D));
		_directrix = (ICurve)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980737), typeof(ICurve));
	}

	public override object Clone()
	{
		return new TabulatedSurface(this);
	}

	public override object CloneWithTessellation()
	{
		return new TabulatedSurface(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981489) + _generatrix);
		stringBuilder.AppendLine(Environment.NewLine);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980737));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.Append(((Entity)_directrix).Dump());
		return stringBuilder.ToString();
	}

	internal override AnalyticSurf _0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D()
	{
		return new TabulatedSurf((ICurve)_directrix.Clone(), (Vector3D)_generatrix.Clone());
	}

	public override void TransformBy(Transformation xform)
	{
		if (_directrix is CompositeCurve)
		{
			CompositeCurve compositeCurve = (CompositeCurve)_directrix;
			ICurve[] array = new ICurve[compositeCurve.CurveList.Count];
			for (int i = 0; i < compositeCurve.CurveList.Count; i++)
			{
				ICurve _0023_003Dz8fpRyMu9aKjE = compositeCurve.CurveList[i];
				array[i] = _0023_003DzF0LQtrYJkPzE(_0023_003Dz8fpRyMu9aKjE, xform);
			}
			_directrix = new CompositeCurve(array);
		}
		else
		{
			ICurve directrix = _0023_003DzF0LQtrYJkPzE(_directrix, xform);
			_directrix = directrix;
		}
		_generatrix.TransformBy(xform);
		base.TransformBy(xform);
		if (_directrix is Line)
		{
			double num = _directrix.Domain.Length / base.DomainU.Length;
			if (num != 1.0)
			{
				base.KnotVectorU.Scale(num);
				base.Trimming.Scale(num, 1.0);
			}
		}
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new TabulatedSurfaceSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976224), _generatrix);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980737), _directrix);
	}

	public override bool ExtendAtU(double u)
	{
		if (!_directrix.ExtendAt(u))
		{
			return false;
		}
		TabulatedSurface _0023_003DzIvBl2Vc_003D = (TabulatedSurface)_directrix.ExtrudeAsSurface(_generatrix)[0];
		_0023_003Dz5Frw3Rt7frdQvIYqKBE8nQs_003D(_0023_003DzIvBl2Vc_003D);
		return true;
	}

	public override bool ExtendAtV(double v)
	{
		if (v > base.DomainV.Low && !Utility.AreEqual(v, base.DomainV.Low, base.DomainV.Length) && v < base.DomainV.High && !Utility.AreEqual(v, base.DomainV.High, base.DomainV.Length))
		{
			return false;
		}
		if (v > base.DomainV.High)
		{
			double num = v / _generatrix.Length;
			_generatrix *= num;
		}
		else
		{
			if (!(v < base.DomainV.Low))
			{
				return false;
			}
			Vector3D vector3D = (Vector3D)_generatrix.Clone();
			vector3D.Normalize();
			Translation xform = new Translation(v * vector3D);
			((Entity)_directrix).TransformBy(xform);
			double num2 = _generatrix.Length - v;
			num2 /= _generatrix.Length;
			_generatrix *= num2;
		}
		TabulatedSurface _0023_003DzIvBl2Vc_003D = (TabulatedSurface)_directrix.ExtrudeAsSurface(_generatrix)[0];
		_0023_003Dz5Frw3Rt7frdQvIYqKBE8nQs_003D(_0023_003DzIvBl2Vc_003D);
		return true;
	}

	private void _0023_003Dz5Frw3Rt7frdQvIYqKBE8nQs_003D(TabulatedSurface _0023_003DzIvBl2Vc_003D)
	{
		bool isTrimmed = base.IsTrimmed;
		_0023_003Dzk__0024yqBPiVV__(_0023_003DzIvBl2Vc_003D.DegreeU, _0023_003DzIvBl2Vc_003D.KnotVectorU, _0023_003DzIvBl2Vc_003D.DegreeV, _0023_003DzIvBl2Vc_003D.KnotVectorV, _0023_003DzIvBl2Vc_003D.ControlPoints);
		if (!isTrimmed)
		{
			ICurve _0023_003DzCqUI6VbvL79X = (ICurve)_directrix.Clone();
			ICurve _0023_003DzzmPi46a_0024aQ2V = new Line((Point3D)_directrix.EndPoint.Clone(), _directrix.EndPoint + _generatrix);
			ICurve curve = (ICurve)_directrix.Clone();
			((Entity)curve).Translate(_generatrix);
			curve.Reverse();
			Line line = new Line((Point3D)_directrix.StartPoint.Clone(), _directrix.StartPoint + _generatrix);
			line.Reverse();
			base.Trimming = _0023_003Dzrkte6ryoSSy1(base.DomainU.Low, base.DomainV.Low, base.DomainU.High, base.DomainV.High, _0023_003DzCqUI6VbvL79X, _0023_003DzzmPi46a_0024aQ2V, curve, line);
		}
		_0023_003Dz7roAELUN1jwt();
	}

	public override bool Project(Point3D P, double coincTol, bool allowOutside, out double u, out double v)
	{
		bool flag = _directrix is PlanarEntity;
		Vector3D vector3D = (Vector3D)_generatrix.Clone();
		vector3D.Normalize();
		if (flag || _directrix is Line)
		{
			if (flag)
			{
				PlanarEntity planarEntity = (PlanarEntity)_directrix;
				if (Vector3D.AreParallel(vector3D, planarEntity.Plane.AxisZ))
				{
					if (planarEntity is Circle)
					{
						Circle circle = (Circle)planarEntity;
						Arc arc = new Arc(circle.Plane, Point2D.Origin, circle.Radius, circle.Domain.Low, circle.Domain.High);
						double t;
						double nurbsParam;
						if (allowOutside)
						{
							arc._0023_003Dzk2wgZ0wi2OG4(P, out t);
							Arc arc2 = arc;
							if (Utility.AreEqual(t, arc.Domain.Low, arc.Domain.Length))
							{
								nurbsParam = arc.Domain.Low;
							}
							else if (Utility.AreEqual(t, arc.Domain.High, arc.Domain.Length))
							{
								nurbsParam = arc.Domain.High;
							}
							else if (!arc.Domain.Includes(t, testOpenInterval: false))
							{
								if (!arc.GetNurbsForm().Project(P, coincTol, allowOutside, out nurbsParam))
								{
									return base.Project(P, coincTol, allowOutside, out u, out v);
								}
							}
							else
							{
								arc2.GetNurbsFormParameterFromRadian(t, out nurbsParam);
							}
						}
						else
						{
							arc.ClosestPointTo(P, out t);
							arc.GetNurbsFormParameterFromRadian(t, out nurbsParam);
						}
						u = (nurbsParam - arc.Domain.Low) * scaleU + base.DomainU.Low;
						Point3D point3D = arc.PointAt(t);
						double num = new Segment3D(point3D, point3D + _generatrix).Project(P);
						v = base.DomainV.Low + num * base.DomainV.Length;
						return _0023_003DzhM2gxPHDylsG(P, coincTol, u, v);
					}
					if (planarEntity is Ellipse)
					{
						Curve nurbsForm = ((ICurve)planarEntity).GetNurbsForm();
						nurbsForm._0023_003DzKWdaQi8_003D(P, allowOutside, out var _0023_003DzNDQ_E88_003D);
						u = (_0023_003DzNDQ_E88_003D - nurbsForm.Domain.Low) * scaleU + base.DomainU.Low;
						Point3D point3D2 = nurbsForm.PointAt(_0023_003DzNDQ_E88_003D);
						double num2 = new Segment3D(point3D2, point3D2 + _generatrix).Project(P);
						v = base.DomainV.Low + num2 * base.DomainV.Length;
						return _0023_003DzhM2gxPHDylsG(P, coincTol, u, v);
					}
				}
			}
			else
			{
				Line line = (Line)_directrix;
				Vector3D tangent = line.Tangent;
				if (Utility.AreEqual(0.0, vector3D * tangent, Math.PI * 2.0))
				{
					line.Project(P, out var t2);
					u = t2 * scaleU + base.DomainU.Low;
					Point3D point3D3 = line.PointAt(t2);
					double num3 = new Segment3D(point3D3, point3D3 + _generatrix).Project(P);
					v = base.DomainV.Low + num3 * base.DomainV.Length;
					return _0023_003DzhM2gxPHDylsG(P, coincTol, u, v);
				}
			}
		}
		else
		{
			Curve nurbsForm2 = _directrix.GetNurbsForm();
			double tol = nurbsForm2.ControlBoundingBox().Diagonal * Utility._0023_003DzheSR8QM7q9ya;
			if (_directrix.IsPlanar(tol, out var plane) && Vector3D.AreParallel(vector3D, plane.AxisZ))
			{
				Point2D pt = plane.Project(P);
				Point3D p = plane.PointAt(pt);
				nurbsForm2.Project(p, coincTol, allowOutside, out var u2);
				u = (u2 - nurbsForm2.Domain.Low) * scaleU + base.DomainU.Low;
				Point3D point3D4 = _directrix.PointAt(u2);
				double num4 = new Segment3D(point3D4, point3D4 + _generatrix).Project(P);
				v = base.DomainV.Low + num4 * base.DomainV.Length;
				return _0023_003DzhM2gxPHDylsG(P, coincTol, u, v);
			}
		}
		return base.Project(P, coincTol, allowOutside, out u, out v);
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v)
	{
		if (IsOrthogonal())
		{
			return Project(P, coincTol, false, out u, out v);
		}
		return base.PointInversion(P, coincTol, out u, out v);
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v, out Vector2D W)
	{
		if (IsOrthogonal())
		{
			bool num = Project(P, coincTol, false, out u, out v);
			W = null;
			if (num && P is PointTangent pt)
			{
				Vector3D[,] array = Evaluate(u, v, 1);
				Vector3D su = array[1, 0];
				Vector3D sv = array[0, 1];
				Surface.TangentVectorInversion(pt, su, sv, out W);
			}
			return num;
		}
		return base.PointInversion(P, coincTol, out u, out v, out W);
	}

	public bool IsOrthogonal()
	{
		bool flag = _directrix is PlanarEntity;
		if (flag || _directrix is Line)
		{
			Vector3D vector3D = (Vector3D)_generatrix.Clone();
			vector3D.Normalize();
			if (flag)
			{
				PlanarEntity planarEntity = (PlanarEntity)_directrix;
				if (Vector3D.AreParallel(vector3D, planarEntity.Plane.AxisZ))
				{
					return true;
				}
			}
			else
			{
				Vector3D tangent = ((Line)_directrix).Tangent;
				if (Utility.AreEqual(0.0, vector3D * tangent, Math.PI * 2.0))
				{
					return true;
				}
			}
		}
		else
		{
			Vector3D vector3D2 = (Vector3D)_generatrix.Clone();
			vector3D2.Normalize();
			double tol = _directrix.GetNurbsForm().ControlBoundingBox().Diagonal * Utility._0023_003DzheSR8QM7q9ya;
			if (_directrix.IsPlanar(tol, out var plane) && Vector3D.AreParallel(vector3D2, plane.AxisZ))
			{
				return true;
			}
		}
		return false;
	}

	public override bool IsPlanar(double tol, out Plane plane)
	{
		plane = null;
		if (_directrix is Line)
		{
			Vector3D startTangent = _directrix.StartTangent;
			Vector3D vector3D = (Vector3D)_generatrix.Clone();
			vector3D.Normalize();
			if (!Vector3D.AreParallel(startTangent, vector3D))
			{
				plane = new Plane(_directrix.StartPoint, startTangent, _generatrix);
				return true;
			}
			return false;
		}
		if (_directrix is PlanarEntity)
		{
			Vector3D obj = (Vector3D)_generatrix.Clone();
			obj.Normalize();
			if (Vector3D.AreOrthogonal(obj, ((PlanarEntity)_directrix).Plane.AxisZ))
			{
				plane = (Plane)((PlanarEntity)_directrix).Plane.Clone();
				return true;
			}
			return false;
		}
		if (_directrix is Curve)
		{
			Curve curve = (Curve)_directrix;
			if (curve.IsLine)
			{
				Line line = new Line(curve.StartPoint, curve.EndPoint);
				Vector3D startTangent2 = line.StartTangent;
				plane = new Plane(line.StartPoint, startTangent2, _generatrix);
				return true;
			}
		}
		return base.IsPlanar(tol, out plane);
	}

	public override void ReverseU()
	{
		_directrix.Reverse();
		base.ReverseU();
	}

	public override void ReverseV()
	{
		((Entity)_directrix).Translate(_generatrix);
		_generatrix.Negate();
		base.ReverseV();
	}

	internal bool _0023_003Dz9RVyx9VUSIjUCVGOFQ_003D_003D(TabulatedSurface _0023_003DzmjyTi06uxopx)
	{
		if (_0023_003DzmjyTi06uxopx._directrix is Circle)
		{
			return true;
		}
		if (!(_0023_003DzmjyTi06uxopx._directrix is CompositeCurve))
		{
			return false;
		}
		if (base.DomainU.Low != _0023_003DzmjyTi06uxopx.DomainU.Low || base.DomainU.High != _0023_003DzmjyTi06uxopx.DomainU.High)
		{
			return false;
		}
		foreach (ICurve curve in ((CompositeCurve)_0023_003DzmjyTi06uxopx._directrix).CurveList)
		{
			if (!(curve is Arc))
			{
				return false;
			}
		}
		return true;
	}

	public override bool Offset(double amount, double tol, out Surface offsetSurf)
	{
		Vector3D vector3D = (Vector3D)_generatrix.Clone();
		vector3D.Normalize();
		if (_directrix is Line)
		{
			Vector3D obj = (Vector3D)_directrix.StartTangent.Clone();
			obj.Normalize();
			Vector3D vector3D2 = Vector3D.Cross(obj, vector3D);
			vector3D2.Normalize();
			offsetSurf = (TabulatedSurface)Clone();
			offsetSurf.Translate(vector3D2 * amount);
			return true;
		}
		if (IsOrthogonal())
		{
			ICurve[] array = _directrix.Offset(amount, vector3D, sharp: true);
			Surface[] array2 = ((array != null) ? array[0] : null).ExtrudeAsSurface(_generatrix);
			offsetSurf = array2[0];
			if (base.IsTrimmed)
			{
				offsetSurf.EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976892);
				List<ICurve> list = new List<ICurve>();
				Size3D size3D = null;
				bool flag = _0023_003Dz9RVyx9VUSIjUCVGOFQ_003D_003D((TabulatedSurface)offsetSurf);
				if (flag)
				{
					offsetSurf.Trimming = (Region)base.Trimming.Clone();
				}
				else
				{
					ICurve[] individualCurves = base.Trimming.ContourList[0].GetIndividualCurves();
					for (int i = 0; i < individualCurves.Length; i++)
					{
						TrimCurve trimCurve = (TrimCurve)individualCurves[i];
						list.Add(trimCurve.Edge);
					}
					size3D = Surface._0023_003DzWu3S5IPxj3tfF03Eyw_003D_003D(list.ToArray());
					offsetSurf.Trimming.ContourList.Clear();
				}
				for (int j = 0; j < base.Trimming.ContourList.Count; j++)
				{
					ICurve[] individualCurves2 = base.Trimming.ContourList[j].GetIndividualCurves();
					List<ICurve> list2 = new List<ICurve>();
					for (int k = 0; k < individualCurves2.Length; k++)
					{
						TrimCurve trimCurve2 = (TrimCurve)individualCurves2[k];
						if (flag)
						{
							TrimCurve obj2 = (TrimCurve)((CompositeCurve)offsetSurf.Trimming.ContourList[j]).CurveList[k];
							ICurve edge = offsetSurf.LiftCurve(trimCurve2, tol);
							obj2.Edge = edge;
							continue;
						}
						if (!_0023_003DztOXazPhlCl2U(trimCurve2, offsetSurf, amount, out var _0023_003Dza4SeUA_0024HGEBl))
						{
							ICurve edge = _0023_003Dz3JJdLbUPbfbS(trimCurve2.Edge, offsetSurf, amount, tol);
							bool flag2 = IsOnSeamU(edge);
							bool flag3 = IsOnSeamV(edge);
							new _0023_003DzGJERpBU4BDeOxTXWM4VD_r9439SEC8V22w_003D_003D(offsetSurf)._0023_003Dz9D8dDjb0uUoA(edge, size3D.Diagonal / 10.0, out var _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D);
							if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D == null)
							{
								return false;
							}
							if (flag2 && !Utility.AreEqual(trimCurve2.StartPoint.X, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.StartPoint.X, base.DomainU.Length))
							{
								Point4D[] pw = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Pw;
								for (int i = 0; i < pw.Length; i++)
								{
									pw[i].X = base.DomainU.High;
								}
							}
							if (flag3 && !Utility.AreEqual(trimCurve2.StartPoint.Y, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.StartPoint.Y, base.DomainV.Length))
							{
								Point4D[] pw = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Pw;
								for (int i = 0; i < pw.Length; i++)
								{
									pw[i].Y = base.DomainV.High;
								}
							}
							_0023_003Dza4SeUA_0024HGEBl = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D._0023_003DzmGgqdRaHiXdg(edge);
						}
						list2.Add(_0023_003Dza4SeUA_0024HGEBl);
					}
					if (!flag)
					{
						offsetSurf.Trimming.ContourList.Add(new CompositeCurve(list2, sortAndOrient: false));
					}
				}
			}
			else
			{
				offsetSurf.Trimming = offsetSurf._0023_003Dzrkte6ryoSSy1((_0023_003DzQAHUODcCipZscKjjuw_003D_003D)0);
			}
			return true;
		}
		return base.Offset(amount, tol, out offsetSurf);
	}

	public override ICurve IsocurveU(double v)
	{
		ICurve obj = (ICurve)_directrix.Clone();
		((Entity)obj).Translate(new Vector3D(PointAt(base.DomainU.Low, base.DomainV.Low), PointAt(base.DomainU.Low, v)));
		return obj;
	}

	public override ICurve IsocurveV(double u)
	{
		return new Line(PointAt(u, base.DomainV.Low), PointAt(u, base.DomainV.High));
	}

	internal override bool _0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out PlanarSurface _0023_003DzaR3A1ks_003D, out Transformation _0023_003DzNDQ_E88_003D)
	{
		if (!base.IsTrimmed)
		{
			_0023_003DzNDQ_E88_003D = null;
			_0023_003DzaR3A1ks_003D = null;
			Vector3D vector3D = (Vector3D)Generatrix.Clone();
			vector3D.Normalize();
			ICurve _0023_003Dz_0024QYZi2U_003D = _0023_003DzlBKVcQ_0024YdTRCIYrMaF_ktZo_003D(base.DomainU.Low).Promote();
			if (_0023_003DzVasKXhwkeXkghr_00246lQ_003D_003D(_0023_003Dz_0024QYZi2U_003D, vector3D, ref _0023_003DzaR3A1ks_003D))
			{
				_0023_003DzNDQ_E88_003D = Surface._0023_003Dzd7oNpnXAu4OMUUVkSd_0024PEQ4_003D(this, _0023_003DzaR3A1ks_003D);
				return true;
			}
			_0023_003Dz_0024QYZi2U_003D = _0023_003DzAlfUFnKPryimd24Ct6UXtpA_003D(base.DomainV.Low).Promote();
			if (_0023_003DzVasKXhwkeXkghr_00246lQ_003D_003D(_0023_003Dz_0024QYZi2U_003D, vector3D, ref _0023_003DzaR3A1ks_003D))
			{
				_0023_003DzNDQ_E88_003D = Surface._0023_003Dzd7oNpnXAu4OMUUVkSd_0024PEQ4_003D(this, _0023_003DzaR3A1ks_003D);
				return true;
			}
		}
		return base._0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out _0023_003DzaR3A1ks_003D, out _0023_003DzNDQ_E88_003D);
	}

	private bool _0023_003DzVasKXhwkeXkghr_00246lQ_003D_003D(ICurve _0023_003Dz_0024QYZi2U_003D, Vector3D _0023_003Dz40R7bAU_003D, ref PlanarSurface _0023_003DzaR3A1ks_003D)
	{
		if (_0023_003Dz_0024QYZi2U_003D is Line)
		{
			Vector3D direction = ((Line)_0023_003Dz_0024QYZi2U_003D).Direction;
			direction.Normalize();
			if (direction * _0023_003Dz40R7bAU_003D < Utility._0023_003DzheSR8QM7q9ya)
			{
				ControlBoundingBox(out var min, out var max);
				Size3D size3D = new Size3D(min, max);
				if (IsPlanar(size3D.Diagonal * Utility._0023_003DzheSR8QM7q9ya, out var _))
				{
					Plane pln = new Plane(Pw[0, 0], direction, _0023_003Dz40R7bAU_003D);
					_0023_003DzaR3A1ks_003D = Surface.CreatePlanar(pln, Pw[0, 0], Pw[1, 1]);
					if (_0023_003DzaR3A1ks_003D == null)
					{
						return false;
					}
					return true;
				}
			}
		}
		return false;
	}

	public bool TryGetCylindrical(out Surface cs)
	{
		cs = null;
		Circle arc = null;
		if (_directrix is Circle || (_directrix is Curve curve && curve.TryGetArc(out arc)))
		{
			if (arc == null)
			{
				arc = (Circle)_directrix;
			}
			int num = Pw.GetLength(0) - 1;
			Point3D euclid = Pw[0, 0].Euclid;
			Point3D euclid2 = Pw[num, 0].Euclid;
			Segment3D segment3D = new Segment3D(euclid, euclid2);
			Point3D euclid3 = Pw[0, 1].Euclid;
			Point3D euclid4 = Pw[num, 1].Euclid;
			Vector3D vector3D = new Vector3D(P1: new Segment3D(euclid3, euclid4).MidPoint, P0: segment3D.MidPoint);
			vector3D.Normalize();
			double _0023_003Dz3veEI49c6b6Q = 0.0;
			if (Vector3D.AreOpposite(vector3D, arc.Plane.AxisZ))
			{
				vector3D *= -1.0;
			}
			else if (!Vector3D.AreCoincident(vector3D, arc.Plane.AxisZ))
			{
				return false;
			}
			Curve curve2 = _0023_003DzlBKVcQ_0024YdTRCIYrMaF_ktZo_003D(base.DomainU.Low);
			ICurve curve3 = curve2.Promote();
			if (!(curve3 is Line))
			{
				return false;
			}
			Surface surface = curve2._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, arc.Domain.Length, vector3D, arc.Center, curve3, _0023_003Dz_Gzfs9c_003D: false);
			if (_0023_003DzQ0FsPoVr_0024QfS(surface))
			{
				cs = surface;
				return true;
			}
			return false;
		}
		return false;
	}

	public override bool IsOnSeamU(ICurve curve, double tol = 0.0)
	{
		if (_0023_003DzCq59RVw_003D && Utility.IsLine(curve))
		{
			Segment3D seg = new Segment3D(_directrix.StartPoint, _directrix.StartPoint + _generatrix);
			Point3D point3D = curve.StartPoint.ProjectTo(seg);
			if (curve.StartPoint == point3D)
			{
				Vector3D vector3D = (Vector3D)_generatrix.Clone();
				vector3D.Normalize();
				return Vector3D.AreParallel(curve.StartTangent, vector3D);
			}
		}
		return base.IsOnSeamU(curve, tol);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] array2;
		if (Directrix is CompositeCurve)
		{
			Surface[] individualSurfaces = Surface.GetIndividualSurfaces(this);
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] array = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D[individualSurfaces.Length];
			array2 = array;
			for (int i = 0; i < individualSurfaces.Length; i++)
			{
				TabulatedSurface _0023_003DzQPs31LY_003D = (TabulatedSurface)individualSurfaces[i];
				array2[i] = _0023_003DzKw5kb5OTrXQJ(_0023_003DzQPs31LY_003D, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
			}
		}
		else
		{
			array2 = new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzKw5kb5OTrXQJ(this, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ) };
		}
		return array2;
	}

	private _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzKw5kb5OTrXQJ(TabulatedSurface _0023_003DzQPs31LY_003D, Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv = TrimCurve._0023_003DzDj2isiZZZIae(_0023_003DzQPs31LY_003D.Directrix);
		double _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D = _0023_003DzQPs31LY_003D.Generatrix.Length;
		Vector3D obj = (Vector3D)_0023_003DzQPs31LY_003D.Generatrix.Clone();
		obj.Normalize();
		double[] _0023_003DzbIIdMFuNXKsO = obj.ToArray();
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dz0b4GnlLoqtdeU075oZx2gvc_003D(ref _0023_003DzcX2HU0yGwowv, ref _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D, ref _0023_003DzbIIdMFuNXKsO);
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D: true);
		Surface._0023_003DzRJjg7TSwDjXLGDsfug_003D_003D(_0023_003DzQPs31LY_003D.Trimming.ContourList, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
		_0023_003DzYe_6EnQecc8d(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = _0023_003DzuAMveDQA6vvk();
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = array[0];
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		int _0023_003DzWuk5xhU5RfkzNR16ug_003D_003D = _0023_003DzyzK8swU_003D;
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		if (base.IsTrimmed)
		{
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DznXwBXUw4u1qB(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974921));
			_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D obj = (_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D)array[1];
			obj._0023_003DzWuk5xhU5RfkzNR16ug_003D_003D = _0023_003DzWuk5xhU5RfkzNR16ug_003D_003D;
			obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
			obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		}
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[2]
		{
			new _0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO(((Entity)Directrix)._0023_003DzuAMveDQA6vvk()[0], Directrix.StartPoint + Generatrix, ColorMethod == colorMethodType.byEntity, LayerName, Color),
			new _0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D(0, _0023_003Dzu1Nt2pFN_00246wu(), ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}
}
