using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

internal class _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D : SilhoWireData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzZSnvfVF8Y5Qg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzTNgUFyqUTGF3Q5n3QnnlrNv9y2li[] _0023_003DzU4XYawo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool[] _0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double[] _0023_003DzmN5Mam9VUpygzj_00243Sw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector3D[] _0023_003DzLUPb4pvedYKYJ9evdg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzxISBIJzOu2SzyhYKlA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool[] _0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Plane[] _0023_003DzWPOC_00241m_KrQbs_0024YxHGQ73_00244_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public IList<int> _0023_003DzbiEHIdtmxpLPvJBt7Q_003D_003D;

	public _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D()
	{
	}

	public _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
		: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D)
	{
	}

	public _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003Dzl_0024kBRC0_003D)
		: base(_0023_003Dzl_0024kBRC0_003D)
	{
		if (_0023_003Dzl_0024kBRC0_003D != null)
		{
			if (_0023_003Dzl_0024kBRC0_003D._0023_003DzZSnvfVF8Y5Qg != null)
			{
				_0023_003DzZSnvfVF8Y5Qg = _0023_003Dzl_0024kBRC0_003D._0023_003DzZSnvfVF8Y5Qg;
				_0023_003DzU4XYawo_003D = _0023_003Dzl_0024kBRC0_003D._0023_003DzU4XYawo_003D;
			}
			_0023_003Dzxhr71LaqxMWZ(_0023_003Dzl_0024kBRC0_003D._0023_003DzkpGtkwc69sJY());
		}
	}

	public bool _0023_003DzkpGtkwc69sJY()
	{
		return _0023_003DzxISBIJzOu2SzyhYKlA_003D_003D;
	}

	public void _0023_003Dzxhr71LaqxMWZ(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzxISBIJzOu2SzyhYKlA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzexqDWFK72cEWXpSSzQ_003D_003D()
	{
		_0023_003DzbiEHIdtmxpLPvJBt7Q_003D_003D = new List<int>(_0023_003DzZSnvfVF8Y5Qg.Length);
		for (int i = 0; i < _0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D.Length; i++)
		{
			if (!_0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[i])
			{
				_0023_003DzbiEHIdtmxpLPvJBt7Q_003D_003D.Add(i);
			}
		}
	}

	internal void _0023_003Dzab4M_0024oaJ7IdKql486g_003D_003D()
	{
		_0023_003DzLUPb4pvedYKYJ9evdg_003D_003D = new Vector3D[_0023_003DzZSnvfVF8Y5Qg.Length];
		_0023_003DzWPOC_00241m_KrQbs_0024YxHGQ73_00244_003D = new Plane[_0023_003DzZSnvfVF8Y5Qg.Length];
		foreach (int item in _0023_003DzbiEHIdtmxpLPvJBt7Q_003D_003D)
		{
			int[] array = _0023_003DzZSnvfVF8Y5Qg[item]._0023_003DzhMDfC7g_003D[0];
			double[] array2 = new double[3]
			{
				ScreenVertices[array[0], 0],
				ScreenVertices[array[0], 1],
				ScreenVertices[array[0], 2]
			};
			double[] array3 = new double[3]
			{
				ScreenVertices[array[1], 0],
				ScreenVertices[array[1], 1],
				ScreenVertices[array[1], 2]
			};
			Vector3D vector3D = new Vector3D(array3[0] - array2[0], array3[1] - array2[1], array3[2] - array2[2]);
			vector3D.Normalize();
			Vector3D vector3D2 = null;
			for (int num = array.Length - 1; num > 1; num--)
			{
				double[] array4 = new double[3]
				{
					ScreenVertices[array[num], 0],
					ScreenVertices[array[num], 1],
					ScreenVertices[array[num], 2]
				};
				vector3D2 = new Vector3D(array4[0] - array2[0], array4[1] - array2[1], array4[2] - array2[2]);
				vector3D2.Normalize();
				if (!Vector3D.AreParallel(vector3D, vector3D2))
				{
					break;
				}
			}
			Vector3D vector3D3 = Vector3D.Cross(vector3D, vector3D2);
			if (_0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D[item])
			{
				_0023_003DzWPOC_00241m_KrQbs_0024YxHGQ73_00244_003D[item] = new Plane(new Point3D(array2), vector3D3);
			}
			if (vector3D3.Z < 0.0)
			{
				vector3D3.Negate();
			}
			_0023_003DzLUPb4pvedYKYJ9evdg_003D_003D[item] = vector3D3;
		}
	}

	internal List<HiddenLinesView.HdlCurve> _0023_003DzEYc93l4qAj85V49lUA_003D_003D(Plane _0023_003Dz__4OfIpVgJ6A, RenderContextBase _0023_003DzQdnFby4_003D, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj)
	{
		ICurve[] _0023_003DzTj1oJWREOpXS;
		if (Entity is Brep brep)
		{
			_0023_003DzTj1oJWREOpXS = brep.Section(_0023_003Dz__4OfIpVgJ6A, 0.0);
		}
		else
		{
			if (!(Entity is Surface surface))
			{
				return new List<HiddenLinesView.HdlCurve>();
			}
			_0023_003DzTj1oJWREOpXS = surface.Section(_0023_003Dz__4OfIpVgJ6A, 0.0);
		}
		return _0023_003DzKZ8WOphMClYKoR_nfA_003D_003D(_0023_003DzTj1oJWREOpXS, _0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003Dz__4OfIpVgJ6A);
	}

	private List<HiddenLinesView.HdlCurve> _0023_003DzKZ8WOphMClYKoR_nfA_003D_003D(IReadOnlyList<ICurve> _0023_003DzTj1oJWREOpXS, RenderContextBase _0023_003DzQdnFby4_003D, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, Plane _0023_003Dz__4OfIpVgJ6A)
	{
		List<HiddenLinesView.HdlCurve> list = new List<HiddenLinesView.HdlCurve>(_0023_003DzTj1oJWREOpXS.Count);
		Vector3D vector3D = _0023_003Dz__4OfIpVgJ6A.AxisZ;
		if (Transformation != null)
		{
			vector3D = (Vector3D)vector3D.Clone();
			vector3D.TransformBy(Transformation);
		}
		foreach (ICurve _0023_003DzTj1oJWREOpX in _0023_003DzTj1oJWREOpXS)
		{
			ICurve[] individualCurves = _0023_003DzTj1oJWREOpX.GetIndividualCurves();
			foreach (ICurve curve in individualCurves)
			{
				if (Transformation != null)
				{
					((Entity)curve).TransformBy(Transformation);
				}
				ICurve curve2 = curve;
				Circle circle;
				double _0023_003Dzm3rc4SA8WtT;
				double _0023_003DzOM5CofBvYOXf;
				double _0023_003Dz_00246VsdVC_0024uVkn;
				Point2D point2D3;
				Point2D first;
				if (!(curve2 is Arc arc))
				{
					circle = curve2 as Circle;
					if (circle == null)
					{
						if (!(curve2 is Curve curve3))
						{
							if (!(curve2 is Ellipse ellipse))
							{
								if (!(curve2 is Line line))
								{
									if (!(curve2 is LinearPath linearPath))
									{
										throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998378));
									}
									Point2D[] array = new Point2D[linearPath.Vertices.Length];
									for (int j = 0; j < array.Length; j++)
									{
										Point3D point3D = linearPath.Vertices[j];
										Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, point3D.X, point3D.Y, point3D.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
										array[j] = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
									}
									double num = 0.0;
									for (int k = 0; k < array.Length - 1; k++)
									{
										num += Point2D.Distance(array[k], array[k + 1]);
									}
									if (!(num <= 1E-12))
									{
										list.Add(new HiddenLinesView.HdlLinearPath(array, Entity, -1, Parents, base.Attributes));
									}
								}
								else
								{
									Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
									Point2D point2D = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
									Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
									Point2D point2D2 = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
									if (!(point2D.DistanceTo(point2D2) <= 1E-12))
									{
										list.Add(new HiddenLinesView.HdlLinearPath(new Point2D[2] { point2D, point2D2 }, Entity, -1, Parents, base.Attributes));
									}
								}
								continue;
							}
							if (Vector3D.AreOpposite(ellipse.Plane.AxisZ, vector3D))
							{
								ellipse.Reverse();
							}
							Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
							point2D3 = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
							Point3D point3D2 = ellipse.PointAt(0.0);
							Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, point3D2.X, point3D2.Y, point3D2.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
							Point3D point3D3 = new Point3D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
							double num2 = point2D3.DistanceTo(point3D3);
							if (num2 <= 1E-12)
							{
								continue;
							}
							point3D2 = ellipse.PointAt(Math.PI / 2.0);
							Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, point3D2.X, point3D2.Y, point3D2.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
							Point3D point3D4 = new Point3D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
							double num3 = point2D3.DistanceTo(point3D4);
							if (!(num3 <= 1E-12))
							{
								Plane _0023_003Dzrgqz890sj_0024X = new Plane(new Point3D(point2D3.X, point2D3.Y), point3D3, point3D4);
								double t;
								double t2;
								if (ellipse is EllipticalArc { IsClosed: false, Angle: var angle } ellipticalArc)
								{
									t = angle.Low;
									t2 = ellipticalArc.Angle.High;
								}
								else
								{
									t = 0.0;
									t2 = Math.PI * 2.0;
								}
								list.Add(new HiddenLinesView.HdlEllipticalArc(_0023_003Dzrgqz890sj_0024X, num2, num3, new Interval(t, t2), Entity, -1, Parents, base.Attributes));
							}
						}
						else
						{
							Point4D[] array2 = new Point4D[curve3.ControlPoints.Length];
							for (int l = 0; l < array2.Length; l++)
							{
								Point4D point4D = curve3.ControlPoints[l];
								Point3D euclid = point4D.Euclid;
								Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, euclid.X, euclid.Y, euclid.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
								double w = point4D.W;
								array2[l] = new Point4D(_0023_003Dzm3rc4SA8WtT * w, _0023_003DzOM5CofBvYOXf * w, 0.0, w);
							}
							double num4 = 0.0;
							for (int m = 0; m < array2.Length - 1; m++)
							{
								num4 += Point2D.Distance(array2[m], array2[m + 1]);
							}
							if (!(num4 <= 1E-12))
							{
								list.Add(new HiddenLinesView.HdlSpline(curve3.Degree, curve3.KnotVector, array2, Entity, -1, Parents, base.Attributes));
							}
						}
						continue;
					}
				}
				else
				{
					if (!arc.IsCircle)
					{
						Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, arc.Center.X, arc.Center.Y, arc.Center.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
						point2D3 = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
						Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
						first = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
						Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
						Point2D second = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
						if (Vector3D.AreOpposite(arc.Plane.AxisZ, vector3D))
						{
							Utility.Swap(ref first, ref second);
						}
						if (!(point2D3.DistanceTo(first) <= 1E-12))
						{
							Arc arc2 = new Arc(Plane.XY, point2D3, first, second);
							list.Add(new HiddenLinesView.HdlArc(point2D3, arc2.Radius, arc2.Angle, Entity, -1, Parents, base.Attributes));
						}
						continue;
					}
					circle = (Circle)curve2;
				}
				Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, circle.Center.X, circle.Center.Y, circle.Center.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
				point2D3 = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
				Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
				first = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
				double num5 = point2D3.DistanceTo(first);
				if (!(num5 <= 1E-12))
				{
					list.Add(new HiddenLinesView.HdlArc(point2D3, num5, new Interval(0.0, Math.PI * 2.0), Entity, -1, Parents, base.Attributes));
				}
			}
		}
		return list;
	}
}
