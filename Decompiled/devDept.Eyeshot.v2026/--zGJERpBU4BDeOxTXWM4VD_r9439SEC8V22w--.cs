using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Meshing;
using devDept.Geometry;

internal sealed class _0023_003DzGJERpBU4BDeOxTXWM4VD_r9439SEC8V22w_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<KeyValuePair<Point3D, int>, bool> _0023_003Dzy7nEv89xDomyXIe12g_003D_003D;

		public static Func<KeyValuePair<Point3D, int>, Point3D> _0023_003DzfXeuS1tbkOGAdf2Kdw_003D_003D;

		public static Func<int, bool> _0023_003Dz4r8Rr35Bk_fzaIJ7Cg_003D_003D;

		public static Func<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzI8MDv9j45m_0024_0024Zc8lYw_003D_003D;

		public static Func<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzRoNSlMNm4kh4k8QjBg_003D_003D;

		public static Func<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzeJGThMBxDE_0024vc6bU_g_003D_003D;

		public static Func<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzzgjetQjeANpuuShv1w_003D_003D;

		internal bool _0023_003Dzog_VtqbPG_1dMJmfAVM_00240wMHTaOi(KeyValuePair<Point3D, int> _0023_003Dz4okd4Qo_003D)
		{
			return _0023_003Dz4okd4Qo_003D.Value > 2;
		}

		internal Point3D _0023_003DzDQgKRh_0024snG_0024qqrw8HVPyu_0024uJTAGo(KeyValuePair<Point3D, int> _0023_003Dz4okd4Qo_003D)
		{
			return _0023_003Dz4okd4Qo_003D.Key;
		}

		internal bool _0023_003Dz_vywA1z6747Ey89ByZCBzf3aXdP8R_0024QwuRgCLFjSpJrU(int _0023_003Dz77g161c_003D)
		{
			return _0023_003Dz77g161c_003D > 2;
		}

		internal _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dz9AtaKTp3e9mA_rjQe6leWGMG5A4N(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DziaT44sk_003D)
		{
			return (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D)_0023_003DziaT44sk_003D.Clone();
		}

		internal _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dza2YHHjVrIx8YpoT_5fZL5hrXMNDL(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzVEkuCAU_003D)
		{
			return (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D)_0023_003DzVEkuCAU_003D.Clone();
		}

		internal _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzP8OYRiP4iKp5tyL_0024iMnNxqWYxkpi(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzMtgiygk_003D)
		{
			return (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D)_0023_003DzMtgiygk_003D.Clone();
		}

		internal _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzhnQ3u3LBu8GjW7kg716F1I59DBm1(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dz_k_cewo_003D)
		{
			return (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D)_0023_003Dz_k_cewo_003D.Clone();
		}
	}

	private sealed class _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D : PointTangent
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dz3k5Uze_VdwnF;

		public _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D)
		{
		}

		public _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(Point3D _0023_003DzMlCq3wk_003D, Vector3D _0023_003DzlllF2to_003D)
			: base(_0023_003DzMlCq3wk_003D.X, _0023_003DzMlCq3wk_003D.Y, _0023_003DzMlCq3wk_003D.Z, _0023_003DzlllF2to_003D.X, _0023_003DzlllF2to_003D.Y, _0023_003DzlllF2to_003D.Z)
		{
		}

		public override object Clone()
		{
			return new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(this, base.Tangent)
			{
				_0023_003Dz3k5Uze_VdwnF = _0023_003Dz3k5Uze_VdwnF
			};
		}
	}

	private readonly Surface _0023_003DzBXeGKPzO7YMs;

	private double _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D = double.MinValue;

	private _0023_003Dzi34rfaFGynKfVrmvSmrRLxMNVpZxoYbbssjSQmGdCd8wL0oHEHxQ_0024zso8XvNpS7cJw_003D_003D _0023_003Dz1W4ZsBkmMZgE;

	public _0023_003DzGJERpBU4BDeOxTXWM4VD_r9439SEC8V22w_003D_003D(Surface _0023_003DzF7GfYSI_003D)
	{
		_0023_003DzBXeGKPzO7YMs = _0023_003DzF7GfYSI_003D;
		_0023_003Dz1W4ZsBkmMZgE = new _0023_003Dzi34rfaFGynKfVrmvSmrRLxMNVpZxoYbbssjSQmGdCd8wL0oHEHxQ_0024zso8XvNpS7cJw_003D_003D(_0023_003DzBXeGKPzO7YMs);
	}

	public ICurve[] _0023_003DzOB4DRXeM_vAvDgLnnQ_003D_003D(ICurve _0023_003Dz06A5WivSSyUp, ref int _0023_003Dzvw5eEfc_003D)
	{
		ICurve[] individualCurves = _0023_003Dz06A5WivSSyUp.GetIndividualCurves();
		double num = _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D;
		if (_0023_003DzSRvk1WMSbrph0n9Syw_003D_003D == double.MinValue || _0023_003DzBXeGKPzO7YMs.IsClosedU || _0023_003DzBXeGKPzO7YMs.IsClosedV)
		{
			num = _0023_003DzY9KxrlKiNnNqNs61ig_003D_003D(individualCurves);
		}
		if (num > _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D)
		{
			_0023_003DzSRvk1WMSbrph0n9Syw_003D_003D = num;
		}
		List<ICurve> list = new List<ICurve>();
		int num2 = individualCurves.Length;
		for (int i = 0; i < num2; i++)
		{
			ICurve curve = individualCurves[i];
			if (!_0023_003Dz9D8dDjb0uUoA(curve, num, out var _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D) || _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D == null || !(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.ControlLength() > _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D * 0.0001))
			{
				continue;
			}
			int num3;
			int num4;
			if (_0023_003DzBXeGKPzO7YMs is SphericalSurface && (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.IsLine || _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.IsLinear(Utility._0023_003Dzjyaz_Vfaky9X, out var _)))
			{
				num3 = (_0023_003Dzq4sdH5I_003D(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D, Utility._0023_003DzxhnLabVjXjPg) ? 1 : 0);
				if (num3 != 0 && _0023_003DzBXeGKPzO7YMs.topEdge != null)
				{
					num4 = (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Pw[0].Y, _0023_003DzBXeGKPzO7YMs.DomainV.High, _0023_003DzBXeGKPzO7YMs.DomainV.Length) ? 1 : 0);
					goto IL_0129;
				}
			}
			else
			{
				num3 = 0;
			}
			num4 = 0;
			goto IL_0129;
			IL_0129:
			bool flag = (byte)num4 != 0;
			if ((num3 == 0 || !(_0023_003DzBXeGKPzO7YMs.bottomEdge != null) || !Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Pw[0].Y, _0023_003DzBXeGKPzO7YMs.DomainV.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Length)) && !flag)
			{
				_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.TranslationID = ((Entity)curve).TranslationID;
				TrimCurve trimCurve = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D._0023_003DzmGgqdRaHiXdg(curve, _0023_003Dzvw5eEfc_003D);
				trimCurve.EdgeIndex = curve.EdgeIndex;
				list.Add(trimCurve);
				_0023_003Dzvw5eEfc_003D++;
			}
		}
		return list.ToArray();
	}

	private double _0023_003DzY9KxrlKiNnNqNs61ig_003D_003D(ICurve[] _0023_003DzKTAIrow_003D)
	{
		Size2D size2D = _0023_003Dz1W4ZsBkmMZgE._0023_003DzL9woobs_003D(_0023_003DzKTAIrow_003D);
		double num = size2D.Min;
		if (num < size2D.Max * 0.0001)
		{
			num = size2D.Max;
		}
		double num2 = Math.Min(_0023_003DzBXeGKPzO7YMs.DomainU.Length, _0023_003DzBXeGKPzO7YMs.DomainV.Length);
		if (num > num2)
		{
			num = num2;
		}
		return num / 100.0;
	}

	private static Size2D _0023_003DzeagJbYB4uGYs_Vw65k5G5ZqJ8dWoz_00247_0024uAKUvbV70Zf8(Surface _0023_003Dz_0024KKopL9T7nzT, ICurve[] _0023_003DzKTAIrow_003D)
	{
		int num = _0023_003DzKTAIrow_003D.Length;
		List<Point2D> list = new List<Point2D>();
		if (num == 1)
		{
			Curve nurbsForm = _0023_003DzKTAIrow_003D[0].GetNurbsForm();
			Point3D euclid = nurbsForm.Pw[0].Euclid;
			_0023_003Dz_0024KKopL9T7nzT.Project(euclid, double.MaxValue, false, out double u, out double v);
			list.Add(new Point2D(u, v));
			Point3D euclid2 = nurbsForm.Pw[nurbsForm._0023_003DzFNjygTLTZtF3() - 1].Euclid;
			_0023_003Dz_0024KKopL9T7nzT.Project(euclid2, double.MaxValue, false, out u, out v);
			list.Add(new Point2D(u, v));
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				Point3D euclid3 = _0023_003DzKTAIrow_003D[i].GetNurbsForm().Pw[0].Euclid;
				_0023_003Dz_0024KKopL9T7nzT.Project(euclid3, double.MaxValue, false, out double u2, out double v2);
				list.Add(new Point2D(u2, v2));
			}
		}
		Utility.ComputeBoundingRect(list, out var boxMin, out var boxMax);
		return new Size2D(boxMin, boxMax);
	}

	public bool _0023_003Dz9D8dDjb0uUoA(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out Curve _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D)
	{
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D = null;
		if (_0023_003Dz8fpRyMu9aKjE is Line { StartTangent: var startTangent } line)
		{
			for (int i = 0; i < line.Vertices.Length; i++)
			{
				Point3D point3D = line.Vertices[i];
				line.Vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, startTangent.X, startTangent.Y, startTangent.Z);
			}
		}
		if ((_0023_003DzBXeGKPzO7YMs is PlanarSurface || (_0023_003DzBXeGKPzO7YMs is TabulatedSurface tabulatedSurface && Utility.IsLine(tabulatedSurface.Directrix))) && _0023_003Dz8fpRyMu9aKjE is Circle _0023_003DzN4MDZ_0024c_003D)
		{
			Surface _0023_003Dz42Cx_4Czbilr = _0023_003DzBXeGKPzO7YMs;
			if (_0023_003DzBXeGKPzO7YMs.TryGetPlanar(out var ps))
			{
				if (_0023_003DzBXeGKPzO7YMs is TabulatedSurface tabulatedSurface2)
				{
					ps.Plane.Translate(tabulatedSurface2.Directrix.StartTangent * (0.0 - _0023_003DzBXeGKPzO7YMs.DomainU.Low));
				}
				_0023_003Dz42Cx_4Czbilr = ps;
			}
			return _0023_003Dz5ItFd91rFdBRi63lS0Js8Kk_003D(_0023_003DzN4MDZ_0024c_003D, _0023_003Dz42Cx_4Czbilr, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D);
		}
		if (!_0023_003DzoiOjxv_CG26o(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var _0023_003DzrAOtYIs_003D))
		{
			return false;
		}
		int num = _0023_003DzrAOtYIs_003D.Length;
		if (_0023_003Dz8fpRyMu9aKjE is Curve && ((Curve)_0023_003Dz8fpRyMu9aKjE).Degree == 1)
		{
			Point3D[] array = new Point3D[num];
			for (int j = 0; j < num; j++)
			{
				PointTangent pointTangent = _0023_003DzrAOtYIs_003D[j];
				array[j] = new Point3D(pointTangent.X, pointTangent.Y);
			}
			_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D = new LinearPath(array).GetNurbsForm();
			if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D._0023_003DzMv2C5Tm1QMvc() == 1)
			{
				return false;
			}
			_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Regen(0.0);
			return true;
		}
		if (!_0023_003Dz9gl2FK__zVr8MPumUA_003D_003D(_0023_003DzrAOtYIs_003D, num) && !_0023_003DzBXeGKPzO7YMs.IsClosedU && !_0023_003DzBXeGKPzO7YMs.IsClosedV)
		{
			num = ((Entity)_0023_003Dz8fpRyMu9aKjE).Vertices.Length;
			List<PointTangent> list = new List<PointTangent>();
			for (int k = 0; k < num; k++)
			{
				if (_0023_003DzBXeGKPzO7YMs.PointInversion(((Entity)_0023_003Dz8fpRyMu9aKjE).Vertices[k], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var u, out var v, out var W))
				{
					if (W != null)
					{
						list.Add(new PointTangent(u, v, 0.0, W.X, W.Y, 0.0));
					}
					else
					{
						list.Add(new PointTangent(u, v));
					}
				}
			}
			_0023_003DzrAOtYIs_003D = list.ToArray();
			num = _0023_003DzrAOtYIs_003D.Length;
			if (!_0023_003Dz9gl2FK__zVr8MPumUA_003D_003D(_0023_003DzrAOtYIs_003D, num))
			{
				return false;
			}
		}
		if (_0023_003DzrAOtYIs_003D.Length != 0)
		{
			Vector2D vector2D = new Vector2D(_0023_003DzrAOtYIs_003D[0].Tangent.X, _0023_003DzrAOtYIs_003D[0].Tangent.Y);
			vector2D.Normalize();
			Vector2D vector2D2 = new Vector2D(_0023_003DzrAOtYIs_003D[num - 1].Tangent.X, _0023_003DzrAOtYIs_003D[num - 1].Tangent.Y);
			vector2D2.Normalize();
			if (_0023_003DzrAOtYIs_003D.Length == 2 && Vector2D.AreCoincident(vector2D, vector2D2, Utility._0023_003DzxhnLabVjXjPg))
			{
				goto IL_0335;
			}
			if (_0023_003DzrAOtYIs_003D.Length > 2)
			{
				Point3D[] points = _0023_003DzrAOtYIs_003D;
				if (new LinearPath(points).IsLinear(Utility._0023_003DzxhnLabVjXjPg, out var _))
				{
					goto IL_0335;
				}
			}
			Utility.BoundingRect(_0023_003DzrAOtYIs_003D, out var min, out var max);
			double err = Point2D.Distance(min, max) * 1E-05;
			_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D = Curve.LocalApproximation(_0023_003DzrAOtYIs_003D, err);
			if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D == null)
			{
				return false;
			}
			goto IL_0382;
		}
		return false;
		IL_0382:
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Vertices = new Point3D[num];
		for (int l = 0; l < num; l++)
		{
			_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Vertices[l] = _0023_003DzrAOtYIs_003D[l];
		}
		return true;
		IL_0335:
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D = new Line(_0023_003DzrAOtYIs_003D[0], _0023_003DzrAOtYIs_003D[num - 1]).GetNurbsForm();
		goto IL_0382;
	}

	private bool _0023_003Dz9gl2FK__zVr8MPumUA_003D_003D(PointTangent[] _0023_003DzrAOtYIs_003D, int _0023_003Dz9JZgoew_003D)
	{
		for (int i = 0; i < _0023_003Dz9JZgoew_003D - 2; i++)
		{
			Vector2D vector2D = new Vector2D(_0023_003DzrAOtYIs_003D[i], _0023_003DzrAOtYIs_003D[i + 1]);
			vector2D.Normalize();
			Vector2D vector2D2 = new Vector2D(_0023_003DzrAOtYIs_003D[i + 1], _0023_003DzrAOtYIs_003D[i + 2]);
			vector2D2.Normalize();
			if (Vector2D.AngleBetween(vector2D, vector2D2) > Math.PI * 3.0 / 4.0)
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003Dz5ItFd91rFdBRi63lS0Js8Kk_003D(Circle _0023_003DzN4MDZ_0024c_003D, Surface _0023_003Dz42Cx_4Czbilr, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out Curve _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D)
	{
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D = _0023_003DzN4MDZ_0024c_003D.GetNurbsForm();
		for (int i = 0; i < _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.ControlPoints.Length; i++)
		{
			Point4D point4D = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.ControlPoints[i];
			_0023_003Dz42Cx_4Czbilr.PointInversion(point4D.Euclid, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var u, out var v, out var _);
			_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Pw[i] = new Point4D(u * point4D.W, v * point4D.W, 0.0, point4D.W);
		}
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Vertices = new Point3D[_0023_003DzN4MDZ_0024c_003D.Vertices.Length];
		for (int j = 0; j < _0023_003DzN4MDZ_0024c_003D.Vertices.Length; j++)
		{
			_0023_003Dz42Cx_4Czbilr.PointInversion(_0023_003DzN4MDZ_0024c_003D.Vertices[j], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var u2, out var v2, out var W2);
			_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Vertices[j] = ((W2 == null) ? new PointTangent(u2, v2) : new PointTangent(u2, v2, W2.X, W2.Y));
		}
		return true;
	}

	public bool _0023_003DzNR0fOHUR0UbDJd_nqA_003D_003D(ICurve _0023_003DzCivZpYzcuBCJqDNstA_003D_003D, double _0023_003Dz3SduW_0024w_003D)
	{
		ICurve[] individualCurves = _0023_003DzCivZpYzcuBCJqDNstA_003D_003D.GetIndividualCurves();
		TrimCurve trimCurve = (TrimCurve)individualCurves.First();
		TrimCurve trimCurve2 = (TrimCurve)individualCurves.Last();
		Point4D point4D = trimCurve.Pw.First();
		Point4D point4D2 = trimCurve2.Pw.Last();
		Segment2D segment2D = new Segment2D(trimCurve.Pw[0], trimCurve.Pw[1]);
		Vector2D vector2D = segment2D.Tan();
		Segment2D segment2D2 = new Segment2D(trimCurve2.Pw[trimCurve2._0023_003DzFNjygTLTZtF3() - 1], trimCurve2.Pw[trimCurve2._0023_003DzFNjygTLTZtF3()]);
		Vector2D vector2D2 = segment2D2.Tan();
		List<double> list = new List<double> { point4D.DistanceTo(point4D2) };
		bool flag = false;
		if (Vector2D.AreCoincident(vector2D, vector2D2, Utility._0023_003Dzjyaz_Vfaky9X) && individualCurves.Length > 1)
		{
			Segment2D segment2D3 = new Segment2D(point4D, point4D + vector2D);
			double num = segment2D3.Project(segment2D.MidPoint);
			double num2 = segment2D3.Project(segment2D2.MidPoint);
			if (point4D.DistanceTo(point4D2) < Math.Min(_0023_003DzBXeGKPzO7YMs.DomainU.Length, _0023_003DzBXeGKPzO7YMs.DomainV.Length) / 2.0)
			{
				flag = num > num2;
			}
		}
		else
		{
			if (Segment2D.IntersectionLine(segment2D2, segment2D, out var i))
			{
				double num = segment2D2.Project(i);
				double num2 = segment2D.Project(i);
				if (num > 0.9 && num < 1.1 && num2 > -0.1 && num2 < 0.1)
				{
					Point2D point2D = segment2D2.PointAt(num);
					Point2D point2D2 = segment2D.PointAt(num2);
					list.Add(point2D.DistanceTo(point4D));
					list.Add(point2D2.DistanceTo(point4D2));
					list.Sort();
				}
			}
			flag = list.First() < _0023_003Dz3SduW_0024w_003D;
		}
		if (flag)
		{
			_0023_003DzBvjalPZAcZb6(trimCurve2, trimCurve);
			for (int j = 0; j < individualCurves.Length - 1; j++)
			{
				_0023_003DzBvjalPZAcZb6((TrimCurve)individualCurves[j], (TrimCurve)individualCurves[j + 1]);
			}
		}
		else
		{
			Point2D _0023_003DzMlCq3wk_003D = _0023_003DzDfyP7u9dNfLO(point4D, vector2D);
			_0023_003DzzBKmLZAgGweP(trimCurve, _0023_003DzMlCq3wk_003D);
			Point2D _0023_003DzMlCq3wk_003D2 = _0023_003DzDfyP7u9dNfLO(point4D2, vector2D2);
			_0023_003Dz1Xp5RBtYnKPg(trimCurve2, _0023_003DzMlCq3wk_003D2);
			for (int k = 0; k < individualCurves.Length - 1; k++)
			{
				_0023_003DzBvjalPZAcZb6((TrimCurve)individualCurves[k], (TrimCurve)individualCurves[k + 1]);
			}
		}
		bool flag2 = true;
		for (int l = 0; l < individualCurves.Length - 1; l++)
		{
			TrimCurve obj = (TrimCurve)individualCurves[l];
			TrimCurve trimCurve3 = (TrimCurve)individualCurves[l + 1];
			if (obj.Pw.Last().DistanceTo(trimCurve3.Pw.First()) > _0023_003Dz3SduW_0024w_003D)
			{
				flag2 = false;
				break;
			}
		}
		return flag && flag2;
	}

	private static void _0023_003DzBvjalPZAcZb6(TrimCurve _0023_003Dz3Ftsho0_003D, TrimCurve _0023_003DzvmFFjUs_003D)
	{
		if (!_0023_003DzvmFFjUs_003D.IsLine)
		{
			Transformation xform = new Translation(Vector2D.Subtract(_0023_003Dz3Ftsho0_003D.Pw.Last(), _0023_003DzvmFFjUs_003D.Pw.First()));
			_0023_003DzvmFFjUs_003D.Pw.First().TransformBy(xform);
			_0023_003DzvmFFjUs_003D.Vertices.First().TransformBy(xform);
			return;
		}
		if (!_0023_003Dz3Ftsho0_003D.IsLine)
		{
			Transformation xform2 = new Translation(Vector2D.Subtract(_0023_003DzvmFFjUs_003D.Pw.First(), _0023_003Dz3Ftsho0_003D.Pw.Last()));
			_0023_003Dz3Ftsho0_003D.Pw.Last().TransformBy(xform2);
			_0023_003Dz3Ftsho0_003D.Vertices.Last().TransformBy(xform2);
			return;
		}
		Vector2D vector2D = Vector2D.Subtract(_0023_003DzvmFFjUs_003D.Pw[1], _0023_003DzvmFFjUs_003D.Pw[0]);
		vector2D.Normalize();
		Vector2D vector2D2 = Vector2D.Subtract(_0023_003Dz3Ftsho0_003D.Pw[_0023_003Dz3Ftsho0_003D._0023_003DzFNjygTLTZtF3()], _0023_003Dz3Ftsho0_003D.Pw[_0023_003Dz3Ftsho0_003D._0023_003DzFNjygTLTZtF3() - 1]);
		vector2D2.Normalize();
		if (!Vector2D.AreParallel(vector2D, vector2D2, Utility._0023_003Dzjyaz_Vfaky9X))
		{
			Segment2D.IntersectionLine(new Segment2D(_0023_003Dz3Ftsho0_003D.Pw[0], _0023_003Dz3Ftsho0_003D.Pw[1]), new Segment2D(_0023_003DzvmFFjUs_003D.Pw[0], _0023_003DzvmFFjUs_003D.Pw[1]), out var i);
			if (vector2D2.X == 0.0 || vector2D2.Y == 0.0)
			{
				_0023_003Dz1Xp5RBtYnKPg(_0023_003Dz3Ftsho0_003D, i);
			}
			else
			{
				_0023_003Dz3Ftsho0_003D.Pw.Last().X = i.X;
				_0023_003Dz3Ftsho0_003D.Pw.Last().Y = i.Y;
				_0023_003Dz3Ftsho0_003D.Vertices.Last().X = i.X;
				_0023_003Dz3Ftsho0_003D.Vertices.Last().Y = i.Y;
			}
			if (vector2D.X == 0.0 || vector2D.Y == 0.0)
			{
				_0023_003DzzBKmLZAgGweP(_0023_003DzvmFFjUs_003D, i);
				return;
			}
			_0023_003DzvmFFjUs_003D.Pw.First().X = i.X;
			_0023_003DzvmFFjUs_003D.Pw.First().Y = i.Y;
			_0023_003DzvmFFjUs_003D.Vertices.First().X = i.X;
			_0023_003DzvmFFjUs_003D.Vertices.First().Y = i.Y;
		}
	}

	private static void _0023_003Dz1Xp5RBtYnKPg(TrimCurve _0023_003DzTjnkGyI_003D, Point2D _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003Dz2lsfKGk_003D(_0023_003DzTjnkGyI_003D, 0.0))
		{
			_0023_003DzTjnkGyI_003D.Pw.Last().Y = _0023_003DzMlCq3wk_003D.Y;
			_0023_003DzTjnkGyI_003D.Vertices.Last().Y = _0023_003DzMlCq3wk_003D.Y;
			return;
		}
		if (_0023_003Dzq4sdH5I_003D(_0023_003DzTjnkGyI_003D, 0.0))
		{
			_0023_003DzTjnkGyI_003D.Pw.Last().X = _0023_003DzMlCq3wk_003D.X;
			_0023_003DzTjnkGyI_003D.Vertices.Last().X = _0023_003DzMlCq3wk_003D.X;
			return;
		}
		_0023_003DzTjnkGyI_003D.Pw.Last().X = _0023_003DzMlCq3wk_003D.X;
		_0023_003DzTjnkGyI_003D.Pw.Last().Y = _0023_003DzMlCq3wk_003D.Y;
		_0023_003DzTjnkGyI_003D.Vertices.Last().X = _0023_003DzMlCq3wk_003D.X;
		_0023_003DzTjnkGyI_003D.Vertices.Last().Y = _0023_003DzMlCq3wk_003D.Y;
	}

	private static bool _0023_003Dzq4sdH5I_003D(Curve _0023_003DzzmfUkNI_003D, double _0023_003Dzm0CYiiE_003D)
	{
		int num = _0023_003DzzmfUkNI_003D.Pw.Length;
		if (_0023_003Dzm0CYiiE_003D != 0.0)
		{
			return Utility.Compare(_0023_003Dzm0CYiiE_003D, _0023_003DzzmfUkNI_003D.Pw[num - 2].Y, _0023_003DzzmfUkNI_003D.Pw[num - 1].Y) == 0;
		}
		return _0023_003DzzmfUkNI_003D.Pw[num - 2].Y == _0023_003DzzmfUkNI_003D.Pw[num - 1].Y;
	}

	private static bool _0023_003Dz2lsfKGk_003D(TrimCurve _0023_003DzzmfUkNI_003D, double _0023_003Dzm0CYiiE_003D)
	{
		int num = _0023_003DzzmfUkNI_003D.Pw.Length;
		if (_0023_003Dzm0CYiiE_003D != 0.0)
		{
			return Utility.Compare(_0023_003Dzm0CYiiE_003D, _0023_003DzzmfUkNI_003D.Pw[num - 2].X, _0023_003DzzmfUkNI_003D.Pw[num - 1].X) == 0;
		}
		return _0023_003DzzmfUkNI_003D.Pw[num - 2].X == _0023_003DzzmfUkNI_003D.Pw[num - 1].X;
	}

	private static void _0023_003DzzBKmLZAgGweP(TrimCurve _0023_003DzTjnkGyI_003D, Point2D _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003DzTjnkGyI_003D.Pw[0].X == _0023_003DzTjnkGyI_003D.Pw[1].X)
		{
			_0023_003DzTjnkGyI_003D.Pw.First().Y = _0023_003DzMlCq3wk_003D.Y;
			_0023_003DzTjnkGyI_003D.Vertices.First().Y = _0023_003DzMlCq3wk_003D.Y;
			return;
		}
		if (_0023_003DzTjnkGyI_003D.Pw[0].Y == _0023_003DzTjnkGyI_003D.Pw[1].Y)
		{
			_0023_003DzTjnkGyI_003D.Pw.First().X = _0023_003DzMlCq3wk_003D.X;
			_0023_003DzTjnkGyI_003D.Vertices.First().X = _0023_003DzMlCq3wk_003D.X;
			return;
		}
		_0023_003DzTjnkGyI_003D.Pw.First().X = _0023_003DzMlCq3wk_003D.X;
		_0023_003DzTjnkGyI_003D.Pw.First().Y = _0023_003DzMlCq3wk_003D.Y;
		_0023_003DzTjnkGyI_003D.Vertices.First().X = _0023_003DzMlCq3wk_003D.X;
		_0023_003DzTjnkGyI_003D.Vertices.First().Y = _0023_003DzMlCq3wk_003D.Y;
	}

	private Point2D _0023_003DzDfyP7u9dNfLO(Point2D _0023_003DzXq1BPpQ_003D, Vector2D _0023_003DzZRQZPkw1E3os)
	{
		double low = _0023_003DzBXeGKPzO7YMs.DomainU.Low;
		double low2 = _0023_003DzBXeGKPzO7YMs.DomainV.Low;
		double high = _0023_003DzBXeGKPzO7YMs.DomainU.High;
		double high2 = _0023_003DzBXeGKPzO7YMs.DomainV.High;
		Segment2D segment2D = new Segment2D(low, low2, high, low2);
		Segment2D segment2D2 = new Segment2D(high, low2, high, high2);
		Segment2D segment2D3 = new Segment2D(high, high2, low, high2);
		Segment2D segment2D4 = new Segment2D(low, high2, low, low2);
		Segment2D[] obj = new Segment2D[4] { segment2D, segment2D2, segment2D3, segment2D4 };
		double num = double.MaxValue;
		Point2D result = null;
		Segment2D[] array = obj;
		foreach (Segment2D segment2D5 in array)
		{
			if (!Vector2D.AreCoincident(_0023_003DzZRQZPkw1E3os, segment2D5.Tan(), 1E-05))
			{
				double t = segment2D5.Project(_0023_003DzXq1BPpQ_003D);
				Point2D point2D = segment2D5.PointAt(t);
				double num2 = Point2D.DistanceSquared(_0023_003DzXq1BPpQ_003D, point2D);
				if (num2 < num)
				{
					num = num2;
					result = point2D;
				}
			}
		}
		return result;
	}

	private static List<List<ICurve>> _0023_003DzC2TZyLfvjbrtYwWKMOdjMUdfdJqw(ICurve[] _0023_003DzKTAIrow_003D, Point3D[] _0023_003Dz5FSQCK2_0024O5eX)
	{
		Dictionary<Point3D, int> dictionary = new Dictionary<Point3D, int>(_0023_003Dz5FSQCK2_0024O5eX.Length);
		Point3D[] array = _0023_003Dz5FSQCK2_0024O5eX;
		foreach (Point3D key in array)
		{
			dictionary[key] = 0;
		}
		List<ICurve> list = new List<ICurve>();
		Stack<List<ICurve>> stack = new Stack<List<ICurve>>(new global::_0023_003Dz59HJ4yStYPkbzfhacP1yQy8_003D<List<ICurve>>(list));
		List<List<ICurve>> list2 = new List<List<ICurve>>();
		foreach (ICurve curve in _0023_003DzKTAIrow_003D)
		{
			list.Add(curve);
			Point3D point3D = null;
			array = _0023_003Dz5FSQCK2_0024O5eX;
			foreach (Point3D point3D2 in array)
			{
				if (point3D2.DistanceTo(curve.EndPoint) < 0.0001)
				{
					point3D = point3D2;
				}
			}
			if (!(point3D != null))
			{
				continue;
			}
			dictionary[point3D]++;
			if (dictionary[point3D] % 2 == 1)
			{
				stack.Push(list);
				list = new List<ICurve>();
				continue;
			}
			if (list.Count > 0)
			{
				list2.Add(list);
			}
			list = stack.Pop();
		}
		while (stack.Count > 0)
		{
			list2.Add(stack.Pop());
		}
		return list2;
	}

	private static bool _0023_003DzEBJqPPhwR_qK(List<List<ICurve>> _0023_003DzioZVRgU38Nuidy0T1w_003D_003D)
	{
		for (int i = 0; i < _0023_003DzioZVRgU38Nuidy0T1w_003D_003D.Count; i++)
		{
			foreach (ICurve item in _0023_003DzioZVRgU38Nuidy0T1w_003D_003D[i])
			{
				Curve nurbsForm = item.GetNurbsForm();
				for (int j = i + 1; j < _0023_003DzioZVRgU38Nuidy0T1w_003D_003D.Count; j++)
				{
					foreach (ICurve item2 in _0023_003DzioZVRgU38Nuidy0T1w_003D_003D[j])
					{
						Curve nurbsForm2 = item2.GetNurbsForm();
						if (Curve._0023_003DzRGcO5v1wS2S_(nurbsForm, nurbsForm2, out var _, out var _, out var _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, 1.0) != 0)
						{
							_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = true;
							return _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
						}
					}
				}
			}
		}
		return false;
	}

	public static ICurve[] _0023_003DzsaAglSHy2IKvaz1THg_003D_003D(Surface _0023_003Dz_0024KKopL9T7nzT, IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, List<ICurve> _0023_003DzGL3tKho1V0Kd, out bool _0023_003DzL_0024jiyct2alU99vd7_Q_003D_003D)
	{
		List<ICurve> list = new List<ICurve>();
		List<List<ICurve>> list2 = new List<List<ICurve>>();
		_0023_003DzL_0024jiyct2alU99vd7_Q_003D_003D = false;
		foreach (ICurve item2 in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			ICurve[] individualCurves = item2.GetIndividualCurves();
			individualCurves = Utility._0023_003DzCW598inSZMVFMY1xOw_003D_003D(individualCurves, _0023_003DzGL3tKho1V0Kd);
			if (_0023_003DzSolDE1f26IPBnu0J9uZSAnGlPx0yR3TM8w_003D_003D(individualCurves, 0.0001, out var _))
			{
				if (_0023_003DzSolDE1f26IPBnu0J9uZSAnGlPx0yR3TM8w_003D_003D(individualCurves, 0.1, out var _0023_003DzqAZX1x0_003D2))
				{
					_0023_003DzL_0024jiyct2alU99vd7_Q_003D_003D = true;
					Point3D[] _0023_003Dz5FSQCK2_0024O5eX = (from _0023_003Dz4okd4Qo_003D in _0023_003DzqAZX1x0_003D2
						where _0023_003Dz4okd4Qo_003D.Value > 2
						select _0023_003Dz4okd4Qo_003D.Key).ToArray();
					List<List<ICurve>> list3 = _0023_003DzC2TZyLfvjbrtYwWKMOdjMUdfdJqw(individualCurves, _0023_003Dz5FSQCK2_0024O5eX);
					if (list3.Count == 0 || _0023_003DzEBJqPPhwR_qK(list3))
					{
						list2.Add(individualCurves.ToList());
						continue;
					}
					foreach (List<ICurve> item3 in list3)
					{
						list2.AddRange(_0023_003Dza2vDvy66t31N(item3, 0.1, _0023_003Dzp9LPrpP9wSDR: false));
					}
				}
				else
				{
					list2.Add(individualCurves.ToList());
				}
			}
			else
			{
				ICurve[] array = individualCurves;
				foreach (ICurve item in array)
				{
					list.Add(item);
				}
			}
		}
		if (list.Count == 0 && list2.Count == 0)
		{
			return new ICurve[0];
		}
		if (list.Count > 0)
		{
			list2.AddRange(_0023_003Dza2vDvy66t31N(list, 0.1, _0023_003Dzp9LPrpP9wSDR: false));
		}
		_0023_003DzyS7XKxjFCfHR(_0023_003Dz_0024KKopL9T7nzT, out var _0023_003Dzogw1P6crB4Ag, out var _0023_003DzDUQ6StWedsgq, out var _0023_003DzLm1V17IUTtct, out var _0023_003Dznudhha0NlmQ);
		List<ICurve> list4 = new List<ICurve>();
		double num2 = 0.0;
		for (int num3 = 0; num3 < list2.Count; num3++)
		{
			List<ICurve> list5 = list2[num3];
			num2 = _0023_003DzkkuZ9yRj4LhU(list5, _0023_003DzbErHvVw_003D: true);
			list.Clear();
			foreach (ICurve item4 in list5)
			{
				if (!_0023_003DzNQgoJCNtOT3A_COSl0p1yc0_003D(item4, _0023_003Dz_0024KKopL9T7nzT, num2, _0023_003Dzogw1P6crB4Ag, _0023_003DzDUQ6StWedsgq, _0023_003DzLm1V17IUTtct, _0023_003Dznudhha0NlmQ, _0023_003DzGL3tKho1V0Kd))
				{
					list.Add(item4);
				}
			}
			if (list.Count <= 0)
			{
				continue;
			}
			foreach (List<ICurve> item5 in Utility._0023_003Dzx1_VB8cQKrRRV2_0024w7g_003D_003D(list, num2 * 1.1, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: true, _0023_003Dzp9LPrpP9wSDR: false))
			{
				list4.Add(Utility.SmartAdd(item5));
			}
		}
		return list4.ToArray();
	}

	private static bool _0023_003DzSolDE1f26IPBnu0J9uZSAnGlPx0yR3TM8w_003D_003D(ICurve[] _0023_003DzO4AfWbIOSd0ir7MmL4KwHYQ_003D, double _0023_003Dzm0CYiiE_003D, out Dictionary<Point3D, int> _0023_003DzqAZX1x0_003D)
	{
		_0023_003DzqAZX1x0_003D = _0023_003DzT6WR4HHQmJft(_0023_003DzO4AfWbIOSd0ir7MmL4KwHYQ_003D, _0023_003Dzm0CYiiE_003D);
		if (_0023_003DzqAZX1x0_003D.Values.Any((int _0023_003Dz77g161c_003D) => _0023_003Dz77g161c_003D > 2))
		{
			return true;
		}
		return false;
	}

	private static Dictionary<Point3D, int> _0023_003DzT6WR4HHQmJft(ICurve[] _0023_003Dz7lSFiHzi6FkhWMdeiw_003D_003D, double _0023_003Dzm0CYiiE_003D)
	{
		Dictionary<Point3D, int> dictionary = new Dictionary<Point3D, int>();
		foreach (ICurve curve in _0023_003Dz7lSFiHzi6FkhWMdeiw_003D_003D)
		{
			if (curve.Length() < _0023_003Dzm0CYiiE_003D)
			{
				continue;
			}
			bool flag = false;
			foreach (KeyValuePair<Point3D, int> item in dictionary)
			{
				if (item.Key.DistanceTo(curve.StartPoint) < _0023_003Dzm0CYiiE_003D)
				{
					dictionary[item.Key]++;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				dictionary.Add(curve.StartPoint, 1);
			}
			flag = false;
			foreach (KeyValuePair<Point3D, int> item2 in dictionary)
			{
				if (item2.Key.DistanceTo(curve.EndPoint) < _0023_003Dzm0CYiiE_003D)
				{
					dictionary[item2.Key]++;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				dictionary.Add(curve.EndPoint, 1);
			}
		}
		return dictionary;
	}

	private static bool _0023_003DziY4yvLGmVAhHOVhsHQ_003D_003D(ICurve _0023_003Dzl8M2I3VOhFfS, double _0023_003DzX0qX_IwWxysi)
	{
		return _0023_003Dzl8M2I3VOhFfS.StartPoint.DistanceTo(_0023_003Dzl8M2I3VOhFfS.EndPoint) < _0023_003DzX0qX_IwWxysi;
	}

	private static bool _0023_003DzNQgoJCNtOT3A_COSl0p1yc0_003D(ICurve _0023_003DzFDJdA7A_003D, Surface _0023_003Dz_0024KKopL9T7nzT, double _0023_003DzujGysfJz1iWV, Segment3D _0023_003Dzogw1P6crB4Ag, Segment3D _0023_003DzDUQ6StWedsgq, Segment3D _0023_003DzLm1V17IUTtct, Segment3D _0023_003Dznudhha0NlmQ4, List<ICurve> _0023_003DzGL3tKho1V0Kd)
	{
		if (_0023_003DzFDJdA7A_003D.Length() < _0023_003DzujGysfJz1iWV)
		{
			return true;
		}
		Segment3D line;
		if (_0023_003Dz_0024KKopL9T7nzT.IsClosedU)
		{
			if (_0023_003Dz_0024KKopL9T7nzT is RevolvedSurface)
			{
				if (((RevolvedSurface)_0023_003Dz_0024KKopL9T7nzT).IsOnSeamU(_0023_003DzFDJdA7A_003D))
				{
					_0023_003DzGL3tKho1V0Kd.Add(_0023_003DzFDJdA7A_003D);
					return true;
				}
			}
			else if (_0023_003DzFDJdA7A_003D.IsLinear(_0023_003DzFDJdA7A_003D.Length() * Utility._0023_003DzxhnLabVjXjPg, out line) && _0023_003Dz7NwtcbDGtE_0024FoHpfI76Wuv0_003D(_0023_003DzFDJdA7A_003D, _0023_003Dzogw1P6crB4Ag, _0023_003DzDUQ6StWedsgq, _0023_003DzLm1V17IUTtct, _0023_003Dznudhha0NlmQ4))
			{
				_0023_003DzGL3tKho1V0Kd.Add(_0023_003DzFDJdA7A_003D);
				return true;
			}
			if (_0023_003Dz_0024KKopL9T7nzT.GetType() == typeof(Surface) && _0023_003Dz_0024KKopL9T7nzT.IsOnSeamU(_0023_003DzFDJdA7A_003D, _0023_003DzFDJdA7A_003D.Length() * 0.001))
			{
				_0023_003DzGL3tKho1V0Kd.Add(_0023_003DzFDJdA7A_003D);
				return true;
			}
		}
		if (_0023_003Dz_0024KKopL9T7nzT.IsClosedV)
		{
			if (_0023_003Dz_0024KKopL9T7nzT is RevolvedSurface)
			{
				if (((RevolvedSurface)_0023_003Dz_0024KKopL9T7nzT).IsOnSeamV(_0023_003DzFDJdA7A_003D))
				{
					_0023_003DzGL3tKho1V0Kd.Add(_0023_003DzFDJdA7A_003D);
					return true;
				}
			}
			else if (_0023_003DzFDJdA7A_003D.IsLinear(_0023_003DzFDJdA7A_003D.Length() * Utility._0023_003DzxhnLabVjXjPg, out line) && _0023_003Dz7NwtcbDGtE_0024FoHpfI76Wuv0_003D(_0023_003DzFDJdA7A_003D, _0023_003Dzogw1P6crB4Ag, _0023_003DzDUQ6StWedsgq, _0023_003DzLm1V17IUTtct, _0023_003Dznudhha0NlmQ4))
			{
				_0023_003DzGL3tKho1V0Kd.Add(_0023_003DzFDJdA7A_003D);
				return true;
			}
			if (_0023_003Dz_0024KKopL9T7nzT.GetType() == typeof(Surface) && _0023_003Dz_0024KKopL9T7nzT.IsOnSeamV(_0023_003DzFDJdA7A_003D, _0023_003DzFDJdA7A_003D.Length() * 0.001))
			{
				_0023_003DzGL3tKho1V0Kd.Add(_0023_003DzFDJdA7A_003D);
				return true;
			}
		}
		return false;
	}

	private static bool _0023_003Dz7NwtcbDGtE_0024FoHpfI76Wuv0_003D(ICurve _0023_003DzSwfghCo_003D, Segment3D _0023_003Dzogw1P6crB4Ag, Segment3D _0023_003DzDUQ6StWedsgq, Segment3D _0023_003DzLm1V17IUTtct, Segment3D _0023_003Dznudhha0NlmQ4)
	{
		double num = _0023_003DzSwfghCo_003D.Length() * Utility._0023_003Dzjyaz_Vfaky9X;
		if (_0023_003Dzogw1P6crB4Ag != null && _0023_003DzSwfghCo_003D.StartPoint.DistanceTo(_0023_003Dzogw1P6crB4Ag) < num && _0023_003DzSwfghCo_003D.EndPoint.DistanceTo(_0023_003Dzogw1P6crB4Ag) < num)
		{
			return true;
		}
		if (_0023_003DzDUQ6StWedsgq != null && _0023_003DzSwfghCo_003D.StartPoint.DistanceTo(_0023_003DzDUQ6StWedsgq) < num && _0023_003DzSwfghCo_003D.EndPoint.DistanceTo(_0023_003DzDUQ6StWedsgq) < num)
		{
			return true;
		}
		if (_0023_003DzLm1V17IUTtct != null && _0023_003DzSwfghCo_003D.StartPoint.DistanceTo(_0023_003DzLm1V17IUTtct) < num && _0023_003DzSwfghCo_003D.EndPoint.DistanceTo(_0023_003DzLm1V17IUTtct) < num)
		{
			return true;
		}
		if (_0023_003Dznudhha0NlmQ4 != null && _0023_003DzSwfghCo_003D.StartPoint.DistanceTo(_0023_003Dznudhha0NlmQ4) < num && _0023_003DzSwfghCo_003D.EndPoint.DistanceTo(_0023_003Dznudhha0NlmQ4) < num)
		{
			return true;
		}
		return false;
	}

	private static void _0023_003DzyS7XKxjFCfHR(Surface _0023_003Dz_0024KKopL9T7nzT, out Segment3D _0023_003Dzogw1P6crB4Ag, out Segment3D _0023_003DzDUQ6StWedsgq, out Segment3D _0023_003DzLm1V17IUTtct, out Segment3D _0023_003Dznudhha0NlmQ4)
	{
		ICurve edge = ((TrimCurve)((CompositeCurve)_0023_003Dz_0024KKopL9T7nzT.Trimming.ContourList.First()).CurveList[0]).Edge;
		ICurve edge2 = ((TrimCurve)((CompositeCurve)_0023_003Dz_0024KKopL9T7nzT.Trimming.ContourList.First()).CurveList[1]).Edge;
		ICurve edge3 = ((TrimCurve)((CompositeCurve)_0023_003Dz_0024KKopL9T7nzT.Trimming.ContourList.First()).CurveList[2]).Edge;
		ICurve edge4 = ((TrimCurve)((CompositeCurve)_0023_003Dz_0024KKopL9T7nzT.Trimming.ContourList.First()).CurveList[3]).Edge;
		_0023_003Dzogw1P6crB4Ag = null;
		_0023_003DzDUQ6StWedsgq = null;
		_0023_003DzLm1V17IUTtct = null;
		_0023_003Dznudhha0NlmQ4 = null;
		double _0023_003DzxhnLabVjXjPg = Utility._0023_003DzxhnLabVjXjPg;
		if (edge.IsLinear(edge.Length() * _0023_003DzxhnLabVjXjPg, out var line))
		{
			_0023_003Dzogw1P6crB4Ag = line;
		}
		if (edge2.IsLinear(edge2.Length() * _0023_003DzxhnLabVjXjPg, out line))
		{
			_0023_003DzDUQ6StWedsgq = line;
		}
		if (edge3.IsLinear(edge3.Length() * _0023_003DzxhnLabVjXjPg, out line))
		{
			_0023_003DzLm1V17IUTtct = line;
		}
		if (edge4.IsLinear(edge4.Length() * _0023_003DzxhnLabVjXjPg, out line))
		{
			_0023_003Dznudhha0NlmQ4 = line;
		}
	}

	public List<List<ICurve>> _0023_003DzLFNKGsuebyrhJkRSBA_003D_003D(ICurve[] _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D, bool _0023_003Dz5asPnd3sOMag0XnWOw_003D_003D)
	{
		ICurve[] array;
		if (_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D.Length == 1 || (!_0023_003DzBXeGKPzO7YMs.IsClosedU && !_0023_003DzBXeGKPzO7YMs.IsClosedV))
		{
			if (_0023_003Dz5asPnd3sOMag0XnWOw_003D_003D)
			{
				Vector3D startTangent = _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[0].StartTangent;
				Utility.SortAndOrient(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D, reverseVertices: true, assumeClosed: false);
				Vector3D startTangent2 = _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[0].StartTangent;
				if (Vector3D.AreOpposite(startTangent, startTangent2))
				{
					Array.Reverse(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D);
					array = _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].Reverse();
					}
				}
			}
			return new List<List<ICurve>>
			{
				new List<ICurve>(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D)
			};
		}
		double num = double.MaxValue;
		array = _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D;
		for (int i = 0; i < array.Length; i++)
		{
			double num2 = ((Curve)array[i]).ControlLength();
			if (num2 < num)
			{
				num = num2;
			}
		}
		num = Math.Max(num / 2.0, Utility._0023_003Dzjyaz_Vfaky9X);
		return _0023_003Dza2vDvy66t31N(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D, num, _0023_003Dzp9LPrpP9wSDR: true);
	}

	private static List<List<ICurve>> _0023_003Dza2vDvy66t31N(IList<ICurve> _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D, double _0023_003DzCQgCmFxr6YJX, bool _0023_003Dzp9LPrpP9wSDR)
	{
		List<List<ICurve>> result = null;
		int num = int.MaxValue;
		int num2 = 0;
		double num3 = Utility._0023_003DzxhnLabVjXjPg;
		double num4 = -6.0;
		double num5 = -1.0;
		for (int i = 0; i < 12; i++)
		{
			List<List<ICurve>> list = Utility._0023_003Dzx1_VB8cQKrRRV2_0024w7g_003D_003D(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D, num3, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: true, _0023_003Dzp9LPrpP9wSDR);
			int num6 = 0;
			foreach (List<ICurve> item in list)
			{
				if (_0023_003DziY4yvLGmVAhHOVhsHQ_003D_003D(new CompositeCurve(item, sortAndOrient: false), num3))
				{
					num6++;
				}
			}
			if (list.Count < num || (list.Count == num && num6 > num2))
			{
				result = list;
				num = list.Count;
				num2 = num6;
			}
			double y = num4 + (double)i * (num5 - num4) / 11.0;
			num3 = Math.Pow(10.0, y);
			if (num3 > _0023_003DzCQgCmFxr6YJX)
			{
				break;
			}
		}
		return result;
	}

	private bool _0023_003DzoiOjxv_CG26o(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		if (_0023_003DzBXeGKPzO7YMs is ToroidalSurface)
		{
			if (!_0023_003DzgGiPqId2ePEErWkhmA_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
			{
				return false;
			}
		}
		else if (_0023_003DzBXeGKPzO7YMs is SphericalSurface)
		{
			if (!_0023_003DzsUvTKmcT73mr_5fiOA_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
			{
				return false;
			}
		}
		else if (_0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D || _0023_003DzBXeGKPzO7YMs._0023_003Dzoa6bboA_003D || _0023_003DzBXeGKPzO7YMs is RevolvedSurface)
		{
			if (!_0023_003Dz4m_0024FR9_0024qfEiHExkprr6NiYQ_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
			{
				return false;
			}
		}
		else if (!_0023_003Dzh9HEAlkSJeuc(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzgGiPqId2ePEErWkhmA_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		if (_0023_003Dz8fpRyMu9aKjE is PlanarEntity && (Vector3D.AreParallel(((PlanarEntity)_0023_003Dz8fpRyMu9aKjE).Plane.AxisZ, ((RevolvedSurface)_0023_003DzBXeGKPzO7YMs).SeamPlane.AxisY) || _0023_003DzI1Z3bX6wv_0024Pa0XOy5w_003D_003D(_0023_003Dz8fpRyMu9aKjE)) && _0023_003DzRP5emtgRBCcE(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
		{
			return true;
		}
		Entity entity = (Entity)_0023_003Dz8fpRyMu9aKjE;
		_0023_003DzrAOtYIs_003D = new PointTangent[entity._vertices.Length];
		if (!_0023_003DzX8FPpd4_003D(ref entity._vertices, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003DzrAOtYIs_003D))
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzsUvTKmcT73mr_5fiOA_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		if (_0023_003DzRP5emtgRBCcE(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
		{
			return true;
		}
		Entity entity = (Entity)_0023_003Dz8fpRyMu9aKjE;
		_0023_003DzrAOtYIs_003D = new PointTangent[entity._vertices.Length];
		if (!_0023_003DzX8FPpd4_003D(ref entity._vertices, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003DzrAOtYIs_003D))
		{
			return false;
		}
		return true;
	}

	private bool _0023_003Dz4m_0024FR9_0024qfEiHExkprr6NiYQ_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		if (((_0023_003Dz8fpRyMu9aKjE is Circle && _0023_003DzEOVn_0024EfyAbcW4rLVpD5g3dI_003D(_0023_003Dz8fpRyMu9aKjE)) || (Utility.IsLine(_0023_003Dz8fpRyMu9aKjE) && _0023_003DzcYm4oCw4omeJNFDq6OA_0024cJ8whL8v(_0023_003Dz8fpRyMu9aKjE))) && _0023_003DzRP5emtgRBCcE(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
		{
			return true;
		}
		bool flag = Utility.IsLine(_0023_003Dz8fpRyMu9aKjE);
		Entity entity = (Entity)_0023_003Dz8fpRyMu9aKjE;
		_0023_003DzrAOtYIs_003D = new PointTangent[entity.Vertices.Length];
		if (!_0023_003DzX8FPpd4_003D(ref entity._vertices, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003DzrAOtYIs_003D))
		{
			return false;
		}
		if (flag)
		{
			if (_0023_003DzBXeGKPzO7YMs.topEdge != null)
			{
				if (entity._vertices[0].DistanceTo(_0023_003DzBXeGKPzO7YMs.topEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
				{
					_0023_003DzrAOtYIs_003D[0].X = _0023_003DzrAOtYIs_003D[1].X;
					_0023_003DzrAOtYIs_003D[0].Y = (Utility.AreEqual(_0023_003DzrAOtYIs_003D[0].Y, _0023_003DzBXeGKPzO7YMs.DomainV.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Length) ? _0023_003DzBXeGKPzO7YMs.DomainV.Low : _0023_003DzBXeGKPzO7YMs.DomainV.High);
				}
				else if (entity._vertices[1].DistanceTo(_0023_003DzBXeGKPzO7YMs.topEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
				{
					_0023_003DzrAOtYIs_003D[1].X = _0023_003DzrAOtYIs_003D[0].X;
					_0023_003DzrAOtYIs_003D[1].Y = (Utility.AreEqual(_0023_003DzrAOtYIs_003D[1].Y, _0023_003DzBXeGKPzO7YMs.DomainV.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Length) ? _0023_003DzBXeGKPzO7YMs.DomainV.Low : _0023_003DzBXeGKPzO7YMs.DomainV.High);
				}
			}
			else if (_0023_003DzBXeGKPzO7YMs.bottomEdge != null)
			{
				if (entity._vertices[0].DistanceTo(_0023_003DzBXeGKPzO7YMs.bottomEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
				{
					_0023_003DzrAOtYIs_003D[0].X = _0023_003DzrAOtYIs_003D[1].X;
					_0023_003DzrAOtYIs_003D[0].Y = (Utility.AreEqual(_0023_003DzrAOtYIs_003D[0].Y, _0023_003DzBXeGKPzO7YMs.DomainV.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Length) ? _0023_003DzBXeGKPzO7YMs.DomainV.Low : _0023_003DzBXeGKPzO7YMs.DomainV.High);
				}
				else if (entity._vertices[1].DistanceTo(_0023_003DzBXeGKPzO7YMs.bottomEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
				{
					_0023_003DzrAOtYIs_003D[1].X = _0023_003DzrAOtYIs_003D[0].X;
					_0023_003DzrAOtYIs_003D[1].Y = (Utility.AreEqual(_0023_003DzrAOtYIs_003D[1].Y, _0023_003DzBXeGKPzO7YMs.DomainV.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Length) ? _0023_003DzBXeGKPzO7YMs.DomainV.Low : _0023_003DzBXeGKPzO7YMs.DomainV.High);
				}
			}
		}
		return true;
	}

	private bool _0023_003Dzh9HEAlkSJeuc(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		if (_0023_003DzRP5emtgRBCcE(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D))
		{
			return true;
		}
		Entity entity = (Entity)_0023_003Dz8fpRyMu9aKjE;
		_0023_003DzrAOtYIs_003D = new PointTangent[entity.Vertices.Length];
		if (!_0023_003DzX8FPpd4_003D(ref entity._vertices, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003DzrAOtYIs_003D))
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzcYm4oCw4omeJNFDq6OA_0024cJ8whL8v(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		if (Utility.IsLine(_0023_003Dz8fpRyMu9aKjE) && _0023_003DzBXeGKPzO7YMs is CylindricalSurface)
		{
			CylindricalSurface cylindricalSurface = (CylindricalSurface)_0023_003DzBXeGKPzO7YMs;
			Segment3D seg = new Segment3D(cylindricalSurface.Center, cylindricalSurface.Center + cylindricalSurface.Axis);
			Point3D startPoint = _0023_003Dz8fpRyMu9aKjE.StartPoint;
			Point3D endPoint = _0023_003Dz8fpRyMu9aKjE.EndPoint;
			Point3D p = startPoint.ProjectTo(seg);
			Point3D p2 = endPoint.ProjectTo(seg);
			Vector3D vector3D = new Vector3D(p, startPoint);
			Vector3D vector3D2 = new Vector3D(p2, endPoint);
			if (vector3D.IsZero || vector3D2.IsZero)
			{
				return true;
			}
			vector3D.Normalize();
			vector3D2.Normalize();
			if (1.0 - Math.Abs(vector3D * vector3D2) > Utility._0023_003DzheSR8QM7q9ya)
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003DzEOVn_0024EfyAbcW4rLVpD5g3dI_003D(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		Circle circle = (Circle)_0023_003Dz8fpRyMu9aKjE;
		if (_0023_003DzBXeGKPzO7YMs is RevolvedSurface)
		{
			RevolvedSurface revolvedSurface = (RevolvedSurface)_0023_003DzBXeGKPzO7YMs;
			if (Vector3D.AreParallel(circle.Plane.AxisZ, revolvedSurface.Axis))
			{
				return true;
			}
		}
		if (_0023_003DzBXeGKPzO7YMs is TabulatedSurface)
		{
			Vector3D vector3D = (Vector3D)((TabulatedSurface)_0023_003DzBXeGKPzO7YMs).Generatrix.Clone();
			vector3D.Normalize();
			if (Vector3D.AreParallel(circle.Plane.AxisZ, vector3D))
			{
				return true;
			}
		}
		return false;
	}

	private bool _0023_003DzI1Z3bX6wv_0024Pa0XOy5w_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		Segment3D seg = new Segment3D(((RevolvedSurface)_0023_003DzBXeGKPzO7YMs).Center, ((RevolvedSurface)_0023_003DzBXeGKPzO7YMs).Center + ((RevolvedSurface)_0023_003DzBXeGKPzO7YMs).Axis);
		double num = -1.0;
		if (_0023_003Dz8fpRyMu9aKjE is Circle)
		{
			Circle obj = (Circle)_0023_003Dz8fpRyMu9aKjE;
			Point3D b = obj.Center.ProjectTo(seg);
			num = obj.Center.DistanceTo(b);
		}
		if (_0023_003Dz8fpRyMu9aKjE is Ellipse)
		{
			Ellipse obj2 = (Ellipse)_0023_003Dz8fpRyMu9aKjE;
			Point3D b2 = obj2.Center.ProjectTo(seg);
			num = obj2.Center.DistanceTo(b2);
		}
		if (num > 0.0)
		{
			double num2 = ((Circle)((RevolvedSurface)_0023_003DzBXeGKPzO7YMs).Generatrix).Center.DistanceTo(seg);
			double num3 = num2 * Utility._0023_003DzxhnLabVjXjPg;
			if (!(num < num3))
			{
				return Math.Abs(num - num2) < num3;
			}
			return true;
		}
		return false;
	}

	private bool _0023_003DzX8FPpd4_003D(ref Point3D[] _0023_003DzZ86NWzV6mlAE, ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		if (_0023_003DzBXeGKPzO7YMs is PlanarSurface || _0023_003DzBXeGKPzO7YMs is RevolvedSurface || _0023_003DzBXeGKPzO7YMs is TabulatedSurface)
		{
			if (!_0023_003DzqkYqEHMHoliQ(_0023_003DzZ86NWzV6mlAE, _0023_003DzrAOtYIs_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D))
			{
				return false;
			}
		}
		else if (!_0023_003DzDMZqCi4vUCvc(_0023_003DzZ86NWzV6mlAE, _0023_003DzrAOtYIs_003D, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D))
		{
			return false;
		}
		int num = _0023_003DzrAOtYIs_003D.Length;
		if (num < 2)
		{
			return false;
		}
		if (num == 2)
		{
			if (Utility.IsLine(_0023_003Dz8fpRyMu9aKjE))
			{
				if (_0023_003DzBXeGKPzO7YMs is RevolvedSurface)
				{
					RevolvedSurface revolvedSurface = (RevolvedSurface)_0023_003DzBXeGKPzO7YMs;
					if (Vector3D.AreParallel(_0023_003Dz8fpRyMu9aKjE.StartTangent, revolvedSurface.Axis, Utility._0023_003Dzjyaz_Vfaky9X))
					{
						PointTangent pointTangent = _0023_003DzrAOtYIs_003D[0];
						PointTangent pointTangent2 = _0023_003DzrAOtYIs_003D[1];
						double num2 = pointTangent2.Y - pointTangent.Y;
						_0023_003DzrAOtYIs_003D = new PointTangent[4]
						{
							pointTangent,
							new PointTangent(pointTangent.X, pointTangent.Y + num2 / 3.0, 0.0, Math.Sign(num2)),
							new PointTangent(pointTangent.X, pointTangent.Y + 2.0 * num2 / 3.0, 0.0, Math.Sign(num2)),
							pointTangent2
						};
					}
				}
				else if (_0023_003DzBXeGKPzO7YMs.GetType() == typeof(Surface) && _0023_003DzBXeGKPzO7YMs._0023_003DzB68dg9Q_003D > 2 && _0023_003DzBXeGKPzO7YMs.q > 2 && (_0023_003DzBXeGKPzO7YMs.IsClosedU || _0023_003DzBXeGKPzO7YMs.IsClosedV))
				{
					Point3D _0023_003Dzl3DhHgI_003D = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.ParameterAt(0.333));
					Point3D _0023_003Dzl3DhHgI_003D2 = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.ParameterAt(0.666));
					_0023_003Dz79D5HL1nh2ZL(_0023_003Dzl3DhHgI_003D, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var _0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D);
					_0023_003Dz79D5HL1nh2ZL(_0023_003Dzl3DhHgI_003D2, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var _0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D2);
					Array.Resize(ref _0023_003DzrAOtYIs_003D, 4);
					_0023_003DzrAOtYIs_003D[3] = _0023_003DzrAOtYIs_003D[1];
					_0023_003DzrAOtYIs_003D[1] = _0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D;
					_0023_003DzrAOtYIs_003D[2] = _0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D2;
					_0023_003DzUonnfTv97up9223i_0024Q_003D_003D(_0023_003DzrAOtYIs_003D, 4);
				}
			}
		}
		else
		{
			_0023_003DzuMlf0KfSsXM2X8wE9w_003D_003D(_0023_003DzZ86NWzV6mlAE, _0023_003DzrAOtYIs_003D, num, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D);
			_0023_003DzUonnfTv97up9223i_0024Q_003D_003D(_0023_003DzrAOtYIs_003D, num);
			_0023_003DzOq_CSAk_003D(ref _0023_003DzrAOtYIs_003D, ref _0023_003DzZ86NWzV6mlAE, _0023_003Dz3Wd_TE0CdMv6(_0023_003DzrAOtYIs_003D) * 0.0001);
		}
		for (int i = 0; i < _0023_003DzrAOtYIs_003D.Length; i++)
		{
			if (_0023_003DzrAOtYIs_003D[i].Tangent.IsZero)
			{
				_0023_003DzJFjKpRcoO6rn(i, _0023_003DzrAOtYIs_003D);
			}
		}
		return true;
	}

	private void _0023_003DzOq_CSAk_003D<T, E>(ref T[] _0023_003DzH8lRnh_0024QaWyS, ref E[] _0023_003DzoOMH0wZBhkab, double _0023_003Dzm0CYiiE_003D) where T : Point2D where E : Point3D
	{
		_0023_003Dzm0CYiiE_003D *= _0023_003Dzm0CYiiE_003D;
		for (int i = 0; i < _0023_003DzH8lRnh_0024QaWyS.Length - 1; i++)
		{
			if (!(Point2D.DistanceSquared(_0023_003DzH8lRnh_0024QaWyS[i], _0023_003DzH8lRnh_0024QaWyS[i + 1]) > _0023_003Dzm0CYiiE_003D))
			{
				int _0023_003DzyzK8swU_003D = ((i < 1) ? (i + 1) : i);
				_0023_003DzYIJwJJalrSpy2ked8X7Y_0024QY_003D._0023_003DzmSyvi00_003D(ref _0023_003DzH8lRnh_0024QaWyS, _0023_003DzyzK8swU_003D, 1);
				_0023_003DzYIJwJJalrSpy2ked8X7Y_0024QY_003D._0023_003DzmSyvi00_003D(ref _0023_003DzoOMH0wZBhkab, _0023_003DzyzK8swU_003D, 1);
				i--;
			}
		}
	}

	private double _0023_003Dz3Wd_TE0CdMv6<T>(T[] _0023_003DzrdSL0CI_003D) where T : Point2D
	{
		double num = 0.0;
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Length - 1; i++)
		{
			num += Point2D.Distance(_0023_003DzrdSL0CI_003D[i], _0023_003DzrdSL0CI_003D[i + 1]);
		}
		return num;
	}

	private static void _0023_003Dz2mgHiA4l0xPHbeT1fQ_003D_003D(Point3D[] _0023_003DzZ86NWzV6mlAE, PointTangent[] _0023_003DzrAOtYIs_003D, Surface _0023_003Dz_0024KKopL9T7nzT, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
	{
		int num = _0023_003DzrAOtYIs_003D.Length;
		for (int i = 0; i < num - 2; i++)
		{
			Vector2D vector2D = new Vector2D(_0023_003DzrAOtYIs_003D[i], _0023_003DzrAOtYIs_003D[i + 1]);
			bool num2 = vector2D.Normalize();
			Vector2D vector2D2 = new Vector2D(_0023_003DzrAOtYIs_003D[i + 1], _0023_003DzrAOtYIs_003D[i + 2]);
			bool flag = vector2D2.Normalize();
			if (!(num2 && flag) || !(Vector2D.AngleBetween(vector2D, vector2D2) > 3.0915926535897933))
			{
				continue;
			}
			if (i == 0 && _0023_003Dz_0024KKopL9T7nzT._0023_003DzgXk8Ru_iJQUJ(_0023_003DzZ86NWzV6mlAE[i], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D))
			{
				if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[0].X, _0023_003Dz_0024KKopL9T7nzT.DomainU.Low, _0023_003Dz_0024KKopL9T7nzT.DomainU.Length))
				{
					_0023_003DzrAOtYIs_003D[0].X = _0023_003Dz_0024KKopL9T7nzT.DomainU.High;
				}
				else
				{
					_0023_003DzrAOtYIs_003D[0].X = _0023_003Dz_0024KKopL9T7nzT.DomainU.Low;
				}
			}
			else if (i == num - 3 && _0023_003Dz_0024KKopL9T7nzT._0023_003DzgXk8Ru_iJQUJ(_0023_003DzZ86NWzV6mlAE[num - 1], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D))
			{
				if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[num - 1].X, _0023_003Dz_0024KKopL9T7nzT.DomainU.Low, _0023_003Dz_0024KKopL9T7nzT.DomainU.Length))
				{
					_0023_003DzrAOtYIs_003D[num - 1].X = _0023_003Dz_0024KKopL9T7nzT.DomainU.High;
				}
				else
				{
					_0023_003DzrAOtYIs_003D[num - 1].X = _0023_003Dz_0024KKopL9T7nzT.DomainU.Low;
				}
			}
		}
	}

	private bool _0023_003DzDMZqCi4vUCvc(Point3D[] _0023_003DzZ86NWzV6mlAE, PointTangent[] _0023_003DzrAOtYIs_003D, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
	{
		Vector2D _0023_003DzxmoHVeQ_003D = null;
		Vector3D _0023_003DzRpXgovo_003D = null;
		List<PointTangent> list = new List<PointTangent>();
		if (_0023_003DzBXeGKPzO7YMs._0023_003DzgXk8Ru_iJQUJ(_0023_003DzZ86NWzV6mlAE[0], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D))
		{
			_0023_003DzrAOtYIs_003D[0] = new PointTangent(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.X, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Y);
			list.Add(_0023_003DzrAOtYIs_003D[0]);
		}
		else
		{
			if (!_0023_003Dz79D5HL1nh2ZL(_0023_003DzZ86NWzV6mlAE[0], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzrAOtYIs_003D[0]))
			{
				return false;
			}
			list.Add(_0023_003DzrAOtYIs_003D[0]);
			if (_0023_003DzBXeGKPzO7YMs.IsClosedU && _0023_003DzrAOtYIs_003D[0].X - _0023_003DzBXeGKPzO7YMs.DomainU.Low < Utility._0023_003DzheSR8QM7q9ya)
			{
				list.Add(new PointTangent(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzrAOtYIs_003D[0].Y));
			}
			else if (_0023_003DzBXeGKPzO7YMs.IsClosedU && _0023_003DzBXeGKPzO7YMs.DomainU.High - _0023_003DzrAOtYIs_003D[0].X < Utility._0023_003DzheSR8QM7q9ya)
			{
				list.Add(new PointTangent(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzrAOtYIs_003D[0].Y));
			}
			if (_0023_003DzBXeGKPzO7YMs.IsClosedV && _0023_003DzrAOtYIs_003D[0].Y - _0023_003DzBXeGKPzO7YMs.DomainV.Low < Utility._0023_003DzheSR8QM7q9ya)
			{
				list.Add(new PointTangent(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.High));
			}
			else if (_0023_003DzBXeGKPzO7YMs.IsClosedV && _0023_003DzBXeGKPzO7YMs.DomainV.High - _0023_003DzrAOtYIs_003D[0].Y < Utility._0023_003DzheSR8QM7q9ya)
			{
				list.Add(new PointTangent(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Low));
			}
		}
		Vector2D u = null;
		int num = _0023_003DzZ86NWzV6mlAE.Length;
		for (int i = 1; i < num; i++)
		{
			if (i == num - 1 && _0023_003DzBXeGKPzO7YMs._0023_003DzgXk8Ru_iJQUJ(_0023_003DzZ86NWzV6mlAE[i], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D))
			{
				_0023_003DzrAOtYIs_003D[i] = new PointTangent(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.X, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Y);
				continue;
			}
			PointTangent pointTangent = _0023_003DzrAOtYIs_003D[i - 1];
			bool flag = false;
			double _0023_003Dz_eY3Y4c_003D = 0.0;
			double _0023_003Dz77g161c_003D = 0.0;
			Vector3D _0023_003Dz1lrYpwo_003D;
			Vector3D _0023_003DzSbDTaOc_003D;
			if (i == 1 && list.Count > 1)
			{
				double num2 = double.MaxValue;
				foreach (PointTangent item in list)
				{
					double _0023_003Dz_eY3Y4c_003D2 = item.X;
					double _0023_003Dz77g161c_003D2 = item.Y;
					flag = _0023_003DzBXeGKPzO7YMs._0023_003DzCAkKPyqtNt3E(_0023_003DzZ86NWzV6mlAE[i], ref _0023_003Dz_eY3Y4c_003D2, ref _0023_003Dz77g161c_003D2, _0023_003Dz0ZT3gEddQ5QD: false, out var _0023_003DzRpXgovo_003D2, out _0023_003Dz1lrYpwo_003D, out _0023_003DzSbDTaOc_003D, out var _0023_003DzxmoHVeQ_003D2);
					double num3 = Point3D.Distance(_0023_003DzBXeGKPzO7YMs.PointAt(_0023_003Dz_eY3Y4c_003D2, _0023_003Dz77g161c_003D2), _0023_003DzZ86NWzV6mlAE[1]);
					if (num3 < num2)
					{
						num2 = num3;
						Vector3D[,] array = _0023_003DzBXeGKPzO7YMs.Evaluate(item.X, item.Y, 2);
						Vector3D su = array[1, 0];
						Vector3D sv = array[0, 1];
						Surface.TangentVectorInversion((PointTangent)_0023_003DzZ86NWzV6mlAE[0], su, sv, out var W);
						_0023_003DzrAOtYIs_003D[0] = new PointTangent(item.X, item.Y, W.X, W.Y);
						pointTangent = _0023_003DzrAOtYIs_003D[0];
						_0023_003Dz_eY3Y4c_003D = _0023_003Dz_eY3Y4c_003D2;
						_0023_003Dz77g161c_003D = _0023_003Dz77g161c_003D2;
						_0023_003DzxmoHVeQ_003D = _0023_003DzxmoHVeQ_003D2;
						_0023_003DzRpXgovo_003D = _0023_003DzRpXgovo_003D2;
					}
				}
			}
			else
			{
				_0023_003Dz_eY3Y4c_003D = pointTangent.X;
				_0023_003Dz77g161c_003D = pointTangent.Y;
				flag = _0023_003DzBXeGKPzO7YMs._0023_003DzCAkKPyqtNt3E(_0023_003DzZ86NWzV6mlAE[i], ref _0023_003Dz_eY3Y4c_003D, ref _0023_003Dz77g161c_003D, _0023_003Dz0ZT3gEddQ5QD: false, out _0023_003DzRpXgovo_003D, out _0023_003DzSbDTaOc_003D, out _0023_003Dz1lrYpwo_003D, out _0023_003DzxmoHVeQ_003D);
			}
			_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D = new Point2D(_0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D);
			bool flag2 = false;
			Vector2D vector2D = null;
			if (flag)
			{
				if (_0023_003DzxmoHVeQ_003D != null)
				{
					_0023_003DzxmoHVeQ_003D.Normalize();
				}
				vector2D = new Vector2D(pointTangent, new Point2D(_0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D));
				vector2D.Normalize();
				if (((i > 1 && !_0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D && !_0023_003DzBXeGKPzO7YMs._0023_003Dzoa6bboA_003D) || (i > 2 && i < num - 2 && (_0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D || _0023_003DzBXeGKPzO7YMs._0023_003Dzoa6bboA_003D))) && (vector2D.IsZero || Vector2D.Dot(u, vector2D) < 0.6))
				{
					flag2 = true;
				}
			}
			if (!flag || flag2 || _0023_003DzRpXgovo_003D.Length > _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzBXeGKPzO7YMs.ClosestPointTo(_0023_003DzZ86NWzV6mlAE[i], out _0023_003Dz_eY3Y4c_003D, out _0023_003Dz77g161c_003D);
				_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.X = _0023_003Dz_eY3Y4c_003D;
				_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Y = _0023_003Dz77g161c_003D;
				_0023_003DzxmoHVeQ_003D = null;
				vector2D = new Vector2D(pointTangent, new Point2D(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.X, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Y));
				vector2D.Normalize();
			}
			u = vector2D;
			if (_0023_003DzxmoHVeQ_003D != null)
			{
				_0023_003DzrAOtYIs_003D[i] = new PointTangent(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.X, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Y, 0.0, _0023_003DzxmoHVeQ_003D.X, _0023_003DzxmoHVeQ_003D.Y, 0.0);
			}
			else
			{
				_0023_003DzrAOtYIs_003D[i] = new PointTangent(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.X, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Y);
			}
		}
		return true;
	}

	private bool _0023_003Dz79D5HL1nh2ZL(Point3D _0023_003Dzl3DhHgI_003D, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out PointTangent _0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D)
	{
		_0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D = null;
		if (_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dzl3DhHgI_003D, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out Point2D proj, out Vector2D W))
		{
			if (W != null)
			{
				W.Normalize();
				_0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D = new PointTangent(proj.X, proj.Y, 0.0, W.X, W.Y, 0.0);
			}
			else
			{
				_0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D = new PointTangent(proj.X, proj.Y);
			}
			return true;
		}
		return false;
	}

	private bool _0023_003DzqkYqEHMHoliQ(Point3D[] _0023_003DzZ86NWzV6mlAE, PointTangent[] _0023_003DzrAOtYIs_003D, ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
	{
		_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003DzZ86NWzV6mlAE[0], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var u, out var v, out var W);
		_0023_003DzrAOtYIs_003D[0] = ((W == null) ? new PointTangent(u, v) : new PointTangent(u, v, W.X, W.Y));
		int num = _0023_003DzZ86NWzV6mlAE.Length;
		for (int i = 1; i < num; i++)
		{
			_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003DzZ86NWzV6mlAE[i], _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out u, out v, out W);
			_0023_003DzrAOtYIs_003D[i] = ((W == null) ? new PointTangent(u, v) : new PointTangent(u, v, W.X, W.Y));
			Point2D point2D;
			if (i == 1 && num == 2 && !Utility.IsLine(_0023_003Dz8fpRyMu9aKjE))
			{
				Point3D p = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.ParameterAt(0.5));
				_0023_003DzBXeGKPzO7YMs.PointInversion(p, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out double u2, out double v2);
				point2D = new Point2D(u2, v2);
			}
			else
			{
				point2D = _0023_003DzrAOtYIs_003D[i - 1];
			}
			if (_0023_003DzBXeGKPzO7YMs._0023_003Dzoa6bboA_003D && _0023_003DzBXeGKPzO7YMs._0023_003DzofW46gkww8rn(v, _0023_003DzBXeGKPzO7YMs.DomainV.Low) && point2D.Y > _0023_003DzBXeGKPzO7YMs.DomainV.Mid)
			{
				_0023_003DzrAOtYIs_003D[i].Y = _0023_003DzBXeGKPzO7YMs.DomainV.High;
			}
			if (_0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D && _0023_003DzBXeGKPzO7YMs._0023_003DzXZbP_5fvidzb(u, _0023_003DzBXeGKPzO7YMs.DomainU.Low) && point2D.X > _0023_003DzBXeGKPzO7YMs.DomainU.Mid)
			{
				_0023_003DzrAOtYIs_003D[i].X = _0023_003DzBXeGKPzO7YMs.DomainU.High;
			}
		}
		if (_0023_003DzrAOtYIs_003D.Length == 2 && _0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D && Math.Abs(_0023_003DzrAOtYIs_003D[0].Y - _0023_003DzrAOtYIs_003D[1].Y) < 1E-12)
		{
			if (_0023_003DzrAOtYIs_003D[0].Tx < 0.0 && _0023_003DzrAOtYIs_003D[1].Tx < 0.0 && _0023_003DzrAOtYIs_003D[0].X < _0023_003DzrAOtYIs_003D[1].X)
			{
				if (_0023_003DzBXeGKPzO7YMs._0023_003DzXZbP_5fvidzb(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainU.Low))
				{
					_0023_003DzrAOtYIs_003D[0].X = _0023_003DzBXeGKPzO7YMs.DomainU.High;
				}
			}
			else if (_0023_003DzrAOtYIs_003D[0].Tx > 0.0 && _0023_003DzrAOtYIs_003D[1].Tx > 0.0 && _0023_003DzrAOtYIs_003D[0].X > _0023_003DzrAOtYIs_003D[1].X && _0023_003DzBXeGKPzO7YMs._0023_003DzXZbP_5fvidzb(_0023_003DzrAOtYIs_003D[1].X, _0023_003DzBXeGKPzO7YMs.DomainU.High))
			{
				_0023_003DzrAOtYIs_003D[1].X = _0023_003DzBXeGKPzO7YMs.DomainU.Low;
			}
		}
		return true;
	}

	private bool _0023_003Dz0g4Z9A2LdorXqfO1hoqBAM8_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out double _0023_003DzPDTZopC1CzVl, out double _0023_003DzYFoflhXBWlEJ, out double _0023_003DzjNAtBPTsaRz0, out double _0023_003Dzfp1c0f08McaJ)
	{
		Point3D p = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.ParameterAt(1.0 / 3.0));
		Point3D p2 = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.ParameterAt(2.0 / 3.0));
		_0023_003DzBXeGKPzO7YMs.PointInversion(p, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ);
		_0023_003DzBXeGKPzO7YMs.PointInversion(p2, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzjNAtBPTsaRz0, out _0023_003Dzfp1c0f08McaJ);
		if (_0023_003Dz8fpRyMu9aKjE is Circle && _0023_003DzBXeGKPzO7YMs is ToroidalSurface)
		{
			Circle circle = (Circle)_0023_003Dz8fpRyMu9aKjE;
			ToroidalSurface toroidalSurface = (ToroidalSurface)_0023_003DzBXeGKPzO7YMs;
			if (Vector3D.AreParallel(new Plane(toroidalSurface.SeamPlane.Origin, toroidalSurface.SeamPlane.AxisX, toroidalSurface.SeamPlane.AxisZ).AxisZ, circle.Plane.AxisZ))
			{
				if (Utility.AreEqual(circle.Radius, toroidalSurface.MajorRadius + toroidalSurface.MinorRadius, toroidalSurface.MajorRadius + toroidalSurface.MinorRadius))
				{
					_0023_003DzYFoflhXBWlEJ = (_0023_003Dzfp1c0f08McaJ = Math.Min(_0023_003DzYFoflhXBWlEJ, _0023_003Dzfp1c0f08McaJ));
				}
				else
				{
					_0023_003DzYFoflhXBWlEJ = (_0023_003Dzfp1c0f08McaJ = Math.Max(_0023_003DzYFoflhXBWlEJ, _0023_003Dzfp1c0f08McaJ));
				}
			}
		}
		return Math.Abs(_0023_003DzYFoflhXBWlEJ - _0023_003Dzfp1c0f08McaJ) > Math.Abs(_0023_003DzPDTZopC1CzVl - _0023_003DzjNAtBPTsaRz0);
	}

	private bool _0023_003DzRP5emtgRBCcE(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		_0023_003DzrAOtYIs_003D = null;
		bool flag = _0023_003DzBXeGKPzO7YMs is CylindricalSurface || ((_0023_003DzBXeGKPzO7YMs.IsClosedU || _0023_003DzBXeGKPzO7YMs.IsClosedV) && Utility.IsLine(_0023_003Dz8fpRyMu9aKjE) && (_0023_003DzBXeGKPzO7YMs._0023_003DzB68dg9Q_003D == 1 || _0023_003DzBXeGKPzO7YMs.q == 1));
		bool flag2 = !(_0023_003DzBXeGKPzO7YMs.GetType() == typeof(SphericalSurface)) && (_0023_003DzBXeGKPzO7YMs is RevolvedSurface || (_0023_003DzBXeGKPzO7YMs is TabulatedSurface && ((TabulatedSurface)_0023_003DzBXeGKPzO7YMs).Directrix is Circle)) && (_0023_003Dz8fpRyMu9aKjE is Circle || (_0023_003Dz8fpRyMu9aKjE is Ellipse && ((Ellipse)_0023_003Dz8fpRyMu9aKjE).IsCircle));
		if (!flag2 && _0023_003DzBXeGKPzO7YMs is SphericalSurface && ((_0023_003Dz8fpRyMu9aKjE is Arc && !Utility._0023_003Dz1hSRhoQON8zJ(((Arc)_0023_003Dz8fpRyMu9aKjE).Domain)) || (_0023_003Dz8fpRyMu9aKjE is EllipticalArc && ((Ellipse)_0023_003Dz8fpRyMu9aKjE).IsCircle && !Utility._0023_003Dz1hSRhoQON8zJ(((EllipticalArc)_0023_003Dz8fpRyMu9aKjE).Domain))))
		{
			SphericalSurface sphericalSurface = (SphericalSurface)_0023_003DzBXeGKPzO7YMs;
			if (_0023_003Dz8fpRyMu9aKjE is Circle)
			{
				Circle circle = (Circle)_0023_003Dz8fpRyMu9aKjE;
				if (sphericalSurface.Center.DistanceTo(circle.Center) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D * Utility._0023_003Dzjyaz_Vfaky9X && (Vector3D.AreParallel(circle.Plane.AxisZ, sphericalSurface.Axis) || Vector3D.AreOrthogonal(circle.Plane.AxisZ, sphericalSurface.Axis)))
				{
					flag2 = true;
				}
			}
		}
		double _0023_003DzPDTZopC1CzVl;
		double _0023_003DzYFoflhXBWlEJ;
		double _0023_003DzjNAtBPTsaRz;
		double _0023_003Dzfp1c0f08McaJ;
		if (flag2 && ((_0023_003Dz8fpRyMu9aKjE is Arc && !Utility._0023_003Dz1hSRhoQON8zJ(((Arc)_0023_003Dz8fpRyMu9aKjE).Domain)) || (_0023_003Dz8fpRyMu9aKjE is EllipticalArc && !Utility._0023_003Dz1hSRhoQON8zJ(((EllipticalArc)_0023_003Dz8fpRyMu9aKjE).Domain))))
		{
			if (_0023_003Dz0g4Z9A2LdorXqfO1hoqBAM8_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ, out _0023_003DzjNAtBPTsaRz, out _0023_003Dzfp1c0f08McaJ))
			{
				double x = _0023_003DzPDTZopC1CzVl;
				bool flag3 = _0023_003DzYFoflhXBWlEJ < _0023_003Dzfp1c0f08McaJ;
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ);
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.EndPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzjNAtBPTsaRz, out _0023_003Dzfp1c0f08McaJ);
				_0023_003Dz1My_aPJI63wi54n0hw_003D_003D(_0023_003DzBXeGKPzO7YMs._0023_003Dzoa6bboA_003D, flag3, ref _0023_003DzYFoflhXBWlEJ, ref _0023_003Dzfp1c0f08McaJ, _0023_003DzBXeGKPzO7YMs.DomainV);
				_0023_003DzrAOtYIs_003D = new PointTangent[2]
				{
					new PointTangent(x, _0023_003DzYFoflhXBWlEJ, 0.0, flag3 ? 1 : (-1)),
					new PointTangent(x, _0023_003Dzfp1c0f08McaJ, 0.0, flag3 ? 1 : (-1))
				};
			}
			else
			{
				double y = _0023_003DzYFoflhXBWlEJ;
				bool flag4 = _0023_003DzPDTZopC1CzVl < _0023_003DzjNAtBPTsaRz;
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ);
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.EndPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzjNAtBPTsaRz, out _0023_003Dzfp1c0f08McaJ);
				_0023_003Dz1My_aPJI63wi54n0hw_003D_003D(_0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D, flag4, ref _0023_003DzPDTZopC1CzVl, ref _0023_003DzjNAtBPTsaRz, _0023_003DzBXeGKPzO7YMs.DomainU);
				_0023_003DzrAOtYIs_003D = new PointTangent[2]
				{
					new PointTangent(_0023_003DzPDTZopC1CzVl, y, flag4 ? 1 : (-1), 0.0),
					new PointTangent(_0023_003DzjNAtBPTsaRz, y, flag4 ? 1 : (-1), 0.0)
				};
			}
		}
		else if (flag2 && (_0023_003Dz8fpRyMu9aKjE is Circle || (_0023_003Dz8fpRyMu9aKjE is Ellipse && Utility._0023_003Dz1hSRhoQON8zJ(((Ellipse)_0023_003Dz8fpRyMu9aKjE).Domain))))
		{
			if (_0023_003Dz0g4Z9A2LdorXqfO1hoqBAM8_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ, out _0023_003DzjNAtBPTsaRz, out _0023_003Dzfp1c0f08McaJ))
			{
				double x2 = _0023_003DzPDTZopC1CzVl;
				if (_0023_003DzYFoflhXBWlEJ < _0023_003Dzfp1c0f08McaJ)
				{
					_0023_003DzrAOtYIs_003D = new PointTangent[2]
					{
						new PointTangent(x2, _0023_003DzBXeGKPzO7YMs.DomainV.Low, 0.0, 0.0, 1.0, 0.0),
						new PointTangent(x2, _0023_003DzBXeGKPzO7YMs.DomainV.High, 0.0, 0.0, 1.0, 0.0)
					};
				}
				else
				{
					_0023_003DzrAOtYIs_003D = new PointTangent[2]
					{
						new PointTangent(x2, _0023_003DzBXeGKPzO7YMs.DomainV.High, 0.0, 0.0, -1.0, 0.0),
						new PointTangent(x2, _0023_003DzBXeGKPzO7YMs.DomainV.Low, 0.0, 0.0, -1.0, 0.0)
					};
				}
			}
			else
			{
				double y2 = _0023_003DzYFoflhXBWlEJ;
				if (_0023_003DzPDTZopC1CzVl < _0023_003DzjNAtBPTsaRz)
				{
					_0023_003DzrAOtYIs_003D = new PointTangent[2]
					{
						new PointTangent(_0023_003DzBXeGKPzO7YMs.DomainU.Low, y2, 0.0, 1.0, 0.0, 0.0),
						new PointTangent(_0023_003DzBXeGKPzO7YMs.DomainU.High, y2, 0.0, 1.0, 0.0, 0.0)
					};
				}
				else
				{
					_0023_003DzrAOtYIs_003D = new PointTangent[2]
					{
						new PointTangent(_0023_003DzBXeGKPzO7YMs.DomainU.High, y2, 0.0, -1.0, 0.0, 0.0),
						new PointTangent(_0023_003DzBXeGKPzO7YMs.DomainU.Low, y2, 0.0, -1.0, 0.0, 0.0)
					};
				}
			}
		}
		else
		{
			if (!flag || (!(_0023_003Dz8fpRyMu9aKjE is Line) && (!(_0023_003Dz8fpRyMu9aKjE is Curve) || !((Curve)_0023_003Dz8fpRyMu9aKjE).IsLine)))
			{
				return false;
			}
			_0023_003Dz0g4Z9A2LdorXqfO1hoqBAM8_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ, out _0023_003DzjNAtBPTsaRz, out _0023_003Dzfp1c0f08McaJ);
			double num = _0023_003DzBXeGKPzO7YMs._0023_003DzVx1luJEZaaC7().Diagonal * Utility._0023_003DzheSR8QM7q9ya;
			if (Math.Abs(_0023_003DzPDTZopC1CzVl - _0023_003DzjNAtBPTsaRz) < num)
			{
				double x3 = _0023_003DzPDTZopC1CzVl;
				bool flag5 = _0023_003DzYFoflhXBWlEJ < _0023_003Dzfp1c0f08McaJ;
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ);
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.EndPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzjNAtBPTsaRz, out _0023_003Dzfp1c0f08McaJ);
				_0023_003Dz1My_aPJI63wi54n0hw_003D_003D(_0023_003DzBXeGKPzO7YMs._0023_003Dzoa6bboA_003D, flag5, ref _0023_003DzYFoflhXBWlEJ, ref _0023_003Dzfp1c0f08McaJ, _0023_003DzBXeGKPzO7YMs.DomainV);
				_0023_003DzrAOtYIs_003D = new PointTangent[2]
				{
					new PointTangent(x3, _0023_003DzYFoflhXBWlEJ, 0.0, 0.0, flag5 ? 1 : (-1), 0.0),
					new PointTangent(x3, _0023_003Dzfp1c0f08McaJ, 0.0, 0.0, flag5 ? 1 : (-1), 0.0)
				};
			}
			else
			{
				if (!(Math.Abs(_0023_003DzYFoflhXBWlEJ - _0023_003Dzfp1c0f08McaJ) < num))
				{
					return false;
				}
				double y3 = _0023_003DzYFoflhXBWlEJ;
				bool flag6 = _0023_003DzPDTZopC1CzVl < _0023_003DzjNAtBPTsaRz;
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzPDTZopC1CzVl, out _0023_003DzYFoflhXBWlEJ);
				_0023_003DzBXeGKPzO7YMs.PointInversion(_0023_003Dz8fpRyMu9aKjE.EndPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out _0023_003DzjNAtBPTsaRz, out _0023_003Dzfp1c0f08McaJ);
				_0023_003Dz1My_aPJI63wi54n0hw_003D_003D(_0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D, flag6, ref _0023_003DzPDTZopC1CzVl, ref _0023_003DzjNAtBPTsaRz, _0023_003DzBXeGKPzO7YMs.DomainU);
				_0023_003DzrAOtYIs_003D = new PointTangent[2]
				{
					new PointTangent(_0023_003DzPDTZopC1CzVl, y3, 0.0, flag6 ? 1 : (-1), 0.0, 0.0),
					new PointTangent(_0023_003DzjNAtBPTsaRz, y3, 0.0, flag6 ? 1 : (-1), 0.0, 0.0)
				};
			}
		}
		return true;
	}

	private void _0023_003Dz1My_aPJI63wi54n0hw_003D_003D(bool _0023_003DzbErHvVw_003D, bool _0023_003DzcErddC_ANNyKczV_KQ_003D_003D, ref double _0023_003DzFj_0024IqDQ_003D, ref double _0023_003DzjdeMMkk_003D, Interval _0023_003DzhbkBViI_003D)
	{
		if (!_0023_003DzbErHvVw_003D)
		{
			return;
		}
		if (_0023_003DzcErddC_ANNyKczV_KQ_003D_003D)
		{
			if (Math.Abs(_0023_003DzjdeMMkk_003D - _0023_003DzhbkBViI_003D.Low) < Math.Abs(_0023_003DzFj_0024IqDQ_003D - _0023_003DzhbkBViI_003D.High))
			{
				if (Utility._0023_003DzLQiOPy8NYuPb(_0023_003DzjdeMMkk_003D, _0023_003DzhbkBViI_003D.Low, _0023_003DzhbkBViI_003D.Length) && _0023_003DzFj_0024IqDQ_003D > _0023_003DzjdeMMkk_003D)
				{
					_0023_003DzjdeMMkk_003D = _0023_003DzhbkBViI_003D.High;
				}
			}
			else if (Utility._0023_003DzLQiOPy8NYuPb(_0023_003DzFj_0024IqDQ_003D, _0023_003DzhbkBViI_003D.High, _0023_003DzhbkBViI_003D.Length) && _0023_003DzFj_0024IqDQ_003D > _0023_003DzjdeMMkk_003D)
			{
				_0023_003DzFj_0024IqDQ_003D = _0023_003DzhbkBViI_003D.Low;
			}
		}
		else if (Math.Abs(_0023_003DzFj_0024IqDQ_003D - _0023_003DzhbkBViI_003D.Low) < Math.Abs(_0023_003DzjdeMMkk_003D - _0023_003DzhbkBViI_003D.High))
		{
			if (Utility._0023_003DzLQiOPy8NYuPb(_0023_003DzFj_0024IqDQ_003D, _0023_003DzhbkBViI_003D.Low, _0023_003DzhbkBViI_003D.Length) && _0023_003DzjdeMMkk_003D > _0023_003DzFj_0024IqDQ_003D)
			{
				_0023_003DzFj_0024IqDQ_003D = _0023_003DzhbkBViI_003D.High;
			}
		}
		else if (Utility._0023_003DzLQiOPy8NYuPb(_0023_003DzjdeMMkk_003D, _0023_003DzhbkBViI_003D.High, _0023_003DzhbkBViI_003D.Length) && _0023_003DzjdeMMkk_003D > _0023_003DzFj_0024IqDQ_003D)
		{
			_0023_003DzjdeMMkk_003D = _0023_003DzhbkBViI_003D.Low;
		}
	}

	private void _0023_003DzuMlf0KfSsXM2X8wE9w_003D_003D(Point3D[] _0023_003DzZ86NWzV6mlAE, PointTangent[] _0023_003DzrAOtYIs_003D, int _0023_003Dz9JZgoew_003D, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
	{
		if (_0023_003DzBXeGKPzO7YMs.bottomEdge != null)
		{
			if (_0023_003DzZ86NWzV6mlAE[_0023_003Dz9JZgoew_003D - 1].DistanceTo(_0023_003DzBXeGKPzO7YMs.bottomEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].X;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Tx = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Tx;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Ty = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Ty;
			}
			else if (_0023_003DzZ86NWzV6mlAE[0].DistanceTo(_0023_003DzBXeGKPzO7YMs.bottomEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[0].X = _0023_003DzrAOtYIs_003D[1].X;
				_0023_003DzrAOtYIs_003D[0].Tx = _0023_003DzrAOtYIs_003D[1].Tx;
				_0023_003DzrAOtYIs_003D[0].Ty = _0023_003DzrAOtYIs_003D[1].Ty;
			}
		}
		if (_0023_003DzBXeGKPzO7YMs.topEdge != null)
		{
			if (_0023_003DzZ86NWzV6mlAE[0].DistanceTo(_0023_003DzBXeGKPzO7YMs.topEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[0].X = _0023_003DzrAOtYIs_003D[1].X;
				_0023_003DzrAOtYIs_003D[0].Tx = _0023_003DzrAOtYIs_003D[1].Tx;
				_0023_003DzrAOtYIs_003D[0].Ty = _0023_003DzrAOtYIs_003D[1].Ty;
			}
			else if (_0023_003DzZ86NWzV6mlAE[_0023_003Dz9JZgoew_003D - 1].DistanceTo(_0023_003DzBXeGKPzO7YMs.topEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].X;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Tx = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Tx;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Ty = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Ty;
			}
		}
		if (_0023_003DzBXeGKPzO7YMs.leftEdge != null)
		{
			if (_0023_003DzZ86NWzV6mlAE[_0023_003Dz9JZgoew_003D - 1].DistanceTo(_0023_003DzBXeGKPzO7YMs.leftEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Y;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Tx = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Tx;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Ty = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Ty;
			}
			else if (_0023_003DzZ86NWzV6mlAE[0].DistanceTo(_0023_003DzBXeGKPzO7YMs.leftEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[0].Y = _0023_003DzrAOtYIs_003D[1].Y;
				_0023_003DzrAOtYIs_003D[0].Tx = _0023_003DzrAOtYIs_003D[1].Tx;
				_0023_003DzrAOtYIs_003D[0].Ty = _0023_003DzrAOtYIs_003D[1].Ty;
			}
		}
		if (_0023_003DzBXeGKPzO7YMs.rightEdge != null)
		{
			if (_0023_003DzZ86NWzV6mlAE[0].DistanceTo(_0023_003DzBXeGKPzO7YMs.rightEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[0].Y = _0023_003DzrAOtYIs_003D[1].Y;
				_0023_003DzrAOtYIs_003D[0].Tx = _0023_003DzrAOtYIs_003D[1].Tx;
				_0023_003DzrAOtYIs_003D[0].Ty = _0023_003DzrAOtYIs_003D[1].Ty;
			}
			else if (_0023_003DzZ86NWzV6mlAE[_0023_003Dz9JZgoew_003D - 1].DistanceTo(_0023_003DzBXeGKPzO7YMs.rightEdge) < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Y;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Tx = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Tx;
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Ty = _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2].Ty;
			}
		}
		_0023_003Dz2mgHiA4l0xPHbeT1fQ_003D_003D(_0023_003DzZ86NWzV6mlAE, _0023_003DzrAOtYIs_003D, _0023_003DzBXeGKPzO7YMs, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D);
	}

	private void _0023_003DzUonnfTv97up9223i_0024Q_003D_003D(PointTangent[] _0023_003DzrAOtYIs_003D, int _0023_003Dz9JZgoew_003D)
	{
		if (_0023_003DzBXeGKPzO7YMs._0023_003Dzoa6bboA_003D)
		{
			_0023_003DzmZLbRfGImqpMkJ5XmQ_003D_003D(_0023_003DzrAOtYIs_003D, _0023_003Dz9JZgoew_003D);
		}
		if (_0023_003DzBXeGKPzO7YMs._0023_003DzCq59RVw_003D)
		{
			_0023_003DzrjO_0024_cp483ii5RAKeA_003D_003D(_0023_003DzrAOtYIs_003D, _0023_003Dz9JZgoew_003D);
		}
	}

	private void _0023_003DzrjO_0024_cp483ii5RAKeA_003D_003D(PointTangent[] _0023_003DzrAOtYIs_003D, int _0023_003Dz9JZgoew_003D)
	{
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[1], _0023_003DzrAOtYIs_003D[0]).Normalize();
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[2], _0023_003DzrAOtYIs_003D[1]).Normalize();
		double num = _0023_003DzBXeGKPzO7YMs.DomainU.Length / 2.0;
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainU.Length))
		{
			Point2D b = new Point2D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzrAOtYIs_003D[0].Y);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[1], b).Length < num)
			{
				_0023_003DzrAOtYIs_003D[0].X = _0023_003DzBXeGKPzO7YMs.DomainU.High;
			}
		}
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainU.Length))
		{
			Point2D b2 = new Point2D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzrAOtYIs_003D[0].Y);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[1], b2).Length < num)
			{
				_0023_003DzrAOtYIs_003D[0].X = _0023_003DzBXeGKPzO7YMs.DomainU.Low;
			}
		}
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 3], _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2]).Normalize();
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2], _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1]).Normalize();
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X, _0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainU.Length))
		{
			Point2D b3 = new Point2D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2], b3).Length < num)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X = _0023_003DzBXeGKPzO7YMs.DomainU.High;
			}
		}
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X, _0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainU.Length))
		{
			Point2D b4 = new Point2D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2], b4).Length < num)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X = _0023_003DzBXeGKPzO7YMs.DomainU.Low;
			}
		}
	}

	private void _0023_003DzmZLbRfGImqpMkJ5XmQ_003D_003D(PointTangent[] _0023_003DzrAOtYIs_003D, int _0023_003Dz9JZgoew_003D)
	{
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[1], _0023_003DzrAOtYIs_003D[0]).Normalize();
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[2], _0023_003DzrAOtYIs_003D[1]).Normalize();
		double num = _0023_003DzBXeGKPzO7YMs.DomainV.Length / 2.0;
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[0].Y, _0023_003DzBXeGKPzO7YMs.DomainV.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Length))
		{
			Point2D b = new Point2D(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.High);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[1], b).Length < num)
			{
				_0023_003DzrAOtYIs_003D[0].Y = _0023_003DzBXeGKPzO7YMs.DomainV.High;
			}
		}
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[0].Y, _0023_003DzBXeGKPzO7YMs.DomainV.High, _0023_003DzBXeGKPzO7YMs.DomainV.Length))
		{
			Point2D b2 = new Point2D(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Low);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[1], b2).Length < num)
			{
				_0023_003DzrAOtYIs_003D[0].Y = _0023_003DzBXeGKPzO7YMs.DomainV.Low;
			}
		}
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 3], _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2]).Normalize();
		Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2], _0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1]).Normalize();
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y, _0023_003DzBXeGKPzO7YMs.DomainV.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Length))
		{
			Point2D b3 = new Point2D(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X, _0023_003DzBXeGKPzO7YMs.DomainV.High);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2], b3).Length < num)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y = _0023_003DzBXeGKPzO7YMs.DomainV.High;
			}
		}
		if (Utility._0023_003Dz_Dm7r9Ftq7Ss(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y, _0023_003DzBXeGKPzO7YMs.DomainV.High, _0023_003DzBXeGKPzO7YMs.DomainV.Length))
		{
			Point2D b4 = new Point2D(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].X, _0023_003DzBXeGKPzO7YMs.DomainV.Low);
			if (Vector2D.Subtract(_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 2], b4).Length < num)
			{
				_0023_003DzrAOtYIs_003D[_0023_003Dz9JZgoew_003D - 1].Y = _0023_003DzBXeGKPzO7YMs.DomainV.Low;
			}
		}
	}

	private static void _0023_003DzJFjKpRcoO6rn(int _0023_003DzyzK8swU_003D, PointTangent[] _0023_003DzrAOtYIs_003D)
	{
		int num = _0023_003DzrAOtYIs_003D.Length;
		for (int num2 = _0023_003DzyzK8swU_003D - 1; num2 >= 0; num2--)
		{
			if (!_0023_003DzrAOtYIs_003D[num2].Tangent.IsZero)
			{
				_0023_003DzrAOtYIs_003D[_0023_003DzyzK8swU_003D].Tx = _0023_003DzrAOtYIs_003D[num2].Tx;
				_0023_003DzrAOtYIs_003D[_0023_003DzyzK8swU_003D].Ty = _0023_003DzrAOtYIs_003D[num2].Ty;
				_0023_003DzrAOtYIs_003D[_0023_003DzyzK8swU_003D].Tz = _0023_003DzrAOtYIs_003D[num2].Tz;
				return;
			}
		}
		for (int i = _0023_003DzyzK8swU_003D + 1; i < num; i++)
		{
			if (!_0023_003DzrAOtYIs_003D[i].Tangent.IsZero)
			{
				_0023_003DzrAOtYIs_003D[_0023_003DzyzK8swU_003D].Tx = _0023_003DzrAOtYIs_003D[i].Tx;
				_0023_003DzrAOtYIs_003D[_0023_003DzyzK8swU_003D].Ty = _0023_003DzrAOtYIs_003D[i].Ty;
				_0023_003DzrAOtYIs_003D[_0023_003DzyzK8swU_003D].Tz = _0023_003DzrAOtYIs_003D[i].Tz;
				break;
			}
		}
	}

	public ICurve[] _0023_003DzA1c2N2ytz4nNtnv9nKnMeI0_003D(List<List<ICurve>> _0023_003DzymlhK_0SKtJvecP2yw_003D_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, Dictionary<int, SizesOnCurve> _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, double _0023_003Dz3SduW_0024w_003D, IList<ICurve> _0023_003DzeCgcyzdFK_C2TushVg_003D_003D, IList<ICurve> _0023_003DzGL3tKho1V0Kd, out ICurve[] _0023_003DzMwEeeTIRNK2e, ref int _0023_003Dzvw5eEfc_003D)
	{
		List<List<ICurve>> list = new List<List<ICurve>>();
		foreach (List<ICurve> item in _0023_003DzymlhK_0SKtJvecP2yw_003D_003D)
		{
			List<ICurve> list2 = new List<ICurve>();
			foreach (ICurve item2 in item)
			{
				ICurve curve = (ICurve)item2.Clone();
				if (((Entity)item2).Vertices != null)
				{
					((Entity)curve).Vertices = Utility.DeepCopy(((Entity)item2).Vertices);
				}
				list2.Add(curve);
			}
			list.Add(list2);
		}
		bool _0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D;
		ICurve[] result = _0023_003Dze4I646pTllo2fPjnVw_003D_003D(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, _0023_003Dz3SduW_0024w_003D, _0023_003DzeCgcyzdFK_C2TushVg_003D_003D, _0023_003DzGL3tKho1V0Kd, out _0023_003DzMwEeeTIRNK2e, ref _0023_003Dzvw5eEfc_003D, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D: true, out _0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D);
		if (_0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D)
		{
			_0023_003DzymlhK_0SKtJvecP2yw_003D_003D = list;
			ICurve[] result2 = _0023_003Dze4I646pTllo2fPjnVw_003D_003D(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, _0023_003Dz3SduW_0024w_003D, _0023_003DzeCgcyzdFK_C2TushVg_003D_003D, _0023_003DzGL3tKho1V0Kd, out _0023_003DzMwEeeTIRNK2e, ref _0023_003Dzvw5eEfc_003D, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D: false, out _0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D);
			if (!_0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D)
			{
				_0023_003DzymlhK_0SKtJvecP2yw_003D_003D = list;
				return result2;
			}
		}
		return result;
	}

	public ICurve[] _0023_003Dze4I646pTllo2fPjnVw_003D_003D(List<List<ICurve>> _0023_003DzymlhK_0SKtJvecP2yw_003D_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, Dictionary<int, SizesOnCurve> _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, double _0023_003Dz3SduW_0024w_003D, IList<ICurve> _0023_003DzeCgcyzdFK_C2TushVg_003D_003D, IList<ICurve> _0023_003DzGL3tKho1V0Kd, out ICurve[] _0023_003DzMwEeeTIRNK2e, ref int _0023_003Dzvw5eEfc_003D, bool _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D, out bool _0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D)
	{
		_0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D = false;
		if (_0023_003DzNgWSnR6iGqlHmH6GuLeYetI_003D())
		{
			_0023_003DzMwEeeTIRNK2e = new ICurve[0];
			return new ICurve[0];
		}
		ICurve[] array;
		if (_0023_003DzymlhK_0SKtJvecP2yw_003D_003D.Count == 0)
		{
			if (((_0023_003DzBXeGKPzO7YMs is RevolvedSurface && _0023_003DzBXeGKPzO7YMs.rightEdge == null && _0023_003DzBXeGKPzO7YMs.leftEdge == null && _0023_003DzBXeGKPzO7YMs.bottomEdge != null && _0023_003DzBXeGKPzO7YMs.topEdge != null && _0023_003DzBXeGKPzO7YMs.IsClosedU) || (_0023_003DzBXeGKPzO7YMs is ToroidalSurface && _0023_003DzBXeGKPzO7YMs.IsClosedU && _0023_003DzBXeGKPzO7YMs.IsClosedV)) && (!(_0023_003DzBXeGKPzO7YMs is ToroidalSurface) || ((ToroidalSurface)_0023_003DzBXeGKPzO7YMs).Type != torusType.Lemon) && (_0023_003DzeCgcyzdFK_C2TushVg_003D_003D.Count == 0 || (_0023_003DzeCgcyzdFK_C2TushVg_003D_003D.Count > 0 && _0023_003Dzs9MYYwqms0Mxf7FbgxdU1lQ_003D(_0023_003DzeCgcyzdFK_C2TushVg_003D_003D))))
			{
				array = _0023_003DzBXeGKPzO7YMs._0023_003Dzrkte6ryoSSy1(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D).ContourList.ToArray();
				_0023_003DzMwEeeTIRNK2e = ((CompositeCurve)array.First()).CurveList.ToArray();
				if (_0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D != null)
				{
					if (_0023_003DzBXeGKPzO7YMs.bottomEdge == null)
					{
						_0023_003DzEzEeIC1V_FSY(0, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(1.0, 0.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(1.0, 0.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
					if (_0023_003DzBXeGKPzO7YMs.rightEdge == null)
					{
						_0023_003DzEzEeIC1V_FSY(1, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(0.0, 1.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(0.0, 1.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
					if (_0023_003DzBXeGKPzO7YMs.topEdge == null)
					{
						_0023_003DzEzEeIC1V_FSY(2, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(-1.0, 0.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(-1.0, 0.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
					if (_0023_003DzBXeGKPzO7YMs.leftEdge == null)
					{
						_0023_003DzEzEeIC1V_FSY(3, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(0.0, -1.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(0.0, -1.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
					_0023_003Dz4AOqcu4H8eHnOWSI0Q_003D_003D(((CompositeCurve)array.First()).CurveList.ToArray(), _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, _0023_003DzBXeGKPzO7YMs, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D);
				}
				else if (_0023_003DzGL3tKho1V0Kd.Count > 0)
				{
					if (_0023_003DzBXeGKPzO7YMs.bottomEdge == null)
					{
						_0023_003DzXwb8yslpHri8BmHW38Esbdc_003D(0, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(1.0, 0.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(1.0, 0.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
					if (_0023_003DzBXeGKPzO7YMs.rightEdge == null)
					{
						_0023_003DzXwb8yslpHri8BmHW38Esbdc_003D(1, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(0.0, 1.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(0.0, 1.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
					if (_0023_003DzBXeGKPzO7YMs.topEdge == null)
					{
						_0023_003DzXwb8yslpHri8BmHW38Esbdc_003D(2, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(-1.0, 0.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(-1.0, 0.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
					if (_0023_003DzBXeGKPzO7YMs.leftEdge == null)
					{
						_0023_003DzXwb8yslpHri8BmHW38Esbdc_003D(3, new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.High), new Vector3D(0.0, -1.0)), new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(new Point3D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Low), new Vector3D(0.0, -1.0)), _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzGL3tKho1V0Kd, array);
					}
				}
				{
					foreach (ICurve item in _0023_003DzeCgcyzdFK_C2TushVg_003D_003D)
					{
						ICurve[] individualCurves = item.GetIndividualCurves();
						for (int i = 0; i < individualCurves.Length; i++)
						{
							((TrimCurve)individualCurves[i]).Index += 4;
						}
					}
					return array;
				}
			}
			_0023_003DzMwEeeTIRNK2e = null;
			return new ICurve[0];
		}
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list = new List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D>();
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list2 = new List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D>();
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list3 = new List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D>();
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list4 = new List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D>();
		_0023_003DzKk6iXt3oicxi(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, list, list2);
		_0023_003DzqBDHmLvr0NML(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, list3, list4);
		List<ICurve> list5 = new List<ICurve>();
		_0023_003DzD_jVUuQCj6Zl(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, list, list2, _0023_003DzPKbzPJ4_003D: false, _0023_003DzGL3tKho1V0Kd, list5, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out var _0023_003Dz5RkD1sku7Kv, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D);
		List<ICurve> _0023_003DzWga_01xR5MHm7sEWsA_003D_003D = new List<ICurve>(list5);
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list6 = list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz9AtaKTp3e9mA_rjQe6leWGMG5A4N).ToList();
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list7 = list2.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dza2YHHjVrIx8YpoT_5fZL5hrXMNDL).ToList();
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list8 = list3.Select((_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzMtgiygk_003D) => (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D)_0023_003DzMtgiygk_003D.Clone()).ToList();
		List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> list9 = list4.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzhnQ3u3LBu8GjW7kg716F1I59DBm1).ToList();
		if (_0023_003Dz8ZkWhDVkvjGAbHMeu_Jio_0024w_003D(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz3SduW_0024w_003D, list5, _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, list3, list2, list4, list, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, out var _0023_003DzyA3T2Zg_003D, out _0023_003DzMwEeeTIRNK2e))
		{
			return _0023_003DzyA3T2Zg_003D;
		}
		list = list6;
		list2 = list7;
		list4 = list9;
		list3 = list8;
		_0023_003DzD_jVUuQCj6Zl(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, list3, list4, _0023_003DzPKbzPJ4_003D: true, _0023_003DzGL3tKho1V0Kd, list5, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out var _0023_003Dz5RkD1sku7Kv2, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D);
		if (_0023_003DzBXeGKPzO7YMs is TabulatedSurface || _0023_003DzBXeGKPzO7YMs is CylindricalSurface)
		{
			_0023_003Dz5RkD1sku7Kv = false;
		}
		_0023_003DzWga_01xR5MHm7sEWsA_003D_003D = new List<ICurve>(list5);
		if (_0023_003Dz8ZkWhDVkvjGAbHMeu_Jio_0024w_003D(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz3SduW_0024w_003D, list5, _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, list3, list2, list4, list, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, out _0023_003DzyA3T2Zg_003D, out _0023_003DzMwEeeTIRNK2e))
		{
			return _0023_003DzyA3T2Zg_003D;
		}
		if (_0023_003Dz5RkD1sku7Kv2)
		{
			list3.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Low));
			list3.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.Low));
			list4.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.High));
			list4.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.High));
			_0023_003DzD_jVUuQCj6Zl(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, list3, list4, _0023_003DzPKbzPJ4_003D: true, _0023_003DzGL3tKho1V0Kd, list5, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D);
			_0023_003Dz8ZkWhDVkvjGAbHMeu_Jio_0024w_003D(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz3SduW_0024w_003D, list5, _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, list3, list2, list4, list, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, out _0023_003DzyA3T2Zg_003D, out _0023_003DzMwEeeTIRNK2e);
		}
		else if (_0023_003Dz5RkD1sku7Kv)
		{
			list.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.High));
			list.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Low, _0023_003DzBXeGKPzO7YMs.DomainV.Low));
			list2.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.Low));
			list2.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.High, _0023_003DzBXeGKPzO7YMs.DomainV.High));
			_0023_003DzD_jVUuQCj6Zl(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, list, list2, _0023_003DzPKbzPJ4_003D: false, _0023_003DzGL3tKho1V0Kd, list5, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D);
			_0023_003Dz8ZkWhDVkvjGAbHMeu_Jio_0024w_003D(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz3SduW_0024w_003D, list5, _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, list3, list2, list4, list, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, out _0023_003DzyA3T2Zg_003D, out _0023_003DzMwEeeTIRNK2e);
		}
		int num = 0;
		if ((list3.Count > 0 && list3.Count % 2 == 0) || (list4.Count > 0 && list4.Count % 2 == 0))
		{
			num = 1;
		}
		else if ((list2.Count > 0 && list2.Count % 2 == 0) || (list.Count > 0 && list.Count % 2 == 0))
		{
			num = 2;
		}
		switch (num)
		{
		case 0:
			_0023_003DzMwEeeTIRNK2e = list5.ToArray();
			_0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D = true;
			return new ICurve[0];
		case 1:
			_0023_003DzD_jVUuQCj6Zl(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, list3, list4, _0023_003DzPKbzPJ4_003D: true, _0023_003DzGL3tKho1V0Kd, list5, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D);
			break;
		case 2:
			_0023_003DzD_jVUuQCj6Zl(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, list, list2, _0023_003DzPKbzPJ4_003D: false, _0023_003DzGL3tKho1V0Kd, list5, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv2, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D);
			break;
		}
		if (_0023_003Dzs58MHt5MtOC7(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz3SduW_0024w_003D, list5, _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, out _0023_003DzyA3T2Zg_003D, out _0023_003DzMwEeeTIRNK2e))
		{
			return _0023_003DzyA3T2Zg_003D;
		}
		List<Point2D> list10 = new List<Point2D>();
		foreach (List<ICurve> item2 in _0023_003DzymlhK_0SKtJvecP2yw_003D_003D)
		{
			foreach (TrimCurve item3 in item2)
			{
				Point4D[] pw = item3.Pw;
				foreach (Point4D point4D in pw)
				{
					list10.Add(point4D.Euclid);
				}
			}
		}
		Utility.ComputeBoundingRect(list10, out var boxMin, out var boxMax);
		array = _0023_003DzBXeGKPzO7YMs._0023_003Dzrkte6ryoSSy1(boxMin, boxMax, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D).ContourList.ToArray();
		_0023_003DzMwEeeTIRNK2e = new ICurve[0];
		_0023_003DzVjCiYTrAHhMmYY0wRgMEZJA_003D = true;
		return array;
	}

	private void _0023_003DzEzEeIC1V_FSY(int _0023_003DzPtPDwLg_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzAqOpw0w_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dzk64JNOo_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, IList<ICurve> _0023_003DzGL3tKho1V0Kd, ICurve[] _0023_003DzsdySxIlQLgFZ)
	{
		List<ICurve> list = new List<ICurve>();
		int _0023_003Dzvw5eEfc_003D = 0;
		_0023_003DzCbwMy4hP1Yo47_UcQsCts3Y_003D(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D, list, _0023_003DzGL3tKho1V0Kd, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out var _, _0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D: false);
		((Entity)((TrimCurve)list[0]).Edge).Vertices = null;
		((TrimCurve)list[0]).Index = ((TrimCurve)((CompositeCurve)_0023_003DzsdySxIlQLgFZ[0]).CurveList[_0023_003DzPtPDwLg_003D]).Index;
		((CompositeCurve)_0023_003DzsdySxIlQLgFZ[0]).CurveList[_0023_003DzPtPDwLg_003D] = list[0];
	}

	private void _0023_003DzXwb8yslpHri8BmHW38Esbdc_003D(int _0023_003DzPtPDwLg_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzAqOpw0w_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dzk64JNOo_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, IList<ICurve> _0023_003DzGL3tKho1V0Kd, ICurve[] _0023_003DzsdySxIlQLgFZ)
	{
		List<ICurve> list = new List<ICurve>();
		int _0023_003Dzvw5eEfc_003D = 0;
		_0023_003DzCbwMy4hP1Yo47_UcQsCts3Y_003D(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D, list, _0023_003DzGL3tKho1V0Kd, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out var _, _0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D: false);
		((TrimCurve)list[0]).Index = ((TrimCurve)((CompositeCurve)_0023_003DzsdySxIlQLgFZ[0]).CurveList[_0023_003DzPtPDwLg_003D]).Index;
		((CompositeCurve)_0023_003DzsdySxIlQLgFZ[0]).CurveList[_0023_003DzPtPDwLg_003D] = list[0];
	}

	private bool _0023_003Dzs58MHt5MtOC7(List<List<ICurve>> _0023_003DzymlhK_0SKtJvecP2yw_003D_003D, double _0023_003Dz3SduW_0024w_003D, List<ICurve> _0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D, List<ICurve> _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, Dictionary<int, SizesOnCurve> _0023_003Dzc4OC2_ccc_tK, out ICurve[] _0023_003DzyA3T2Zg_003D, out ICurve[] _0023_003DzMwEeeTIRNK2e)
	{
		_0023_003DzMwEeeTIRNK2e = null;
		List<ICurve> list = new List<ICurve>(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D.Count);
		foreach (List<ICurve> item in _0023_003DzymlhK_0SKtJvecP2yw_003D_003D)
		{
			list.AddRange(item);
		}
		if (_0023_003Dzc4OC2_ccc_tK != null)
		{
			_0023_003Dz4AOqcu4H8eHnOWSI0Q_003D_003D(_0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D, _0023_003Dzc4OC2_ccc_tK, _0023_003DzBXeGKPzO7YMs, _0023_003DzSRvk1WMSbrph0n9Syw_003D_003D);
		}
		list.AddRange(_0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D);
		_0023_003DzyA3T2Zg_003D = _0023_003Dz1wxZ8ns7o2I5YhSlXA_003D_003D(list, _0023_003Dz3SduW_0024w_003D);
		_0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D.AddRange(_0023_003DzWga_01xR5MHm7sEWsA_003D_003D);
		ICurve curve = _0023_003DzyA3T2Zg_003D.First();
		if (curve.StartPoint.DistanceTo(curve.EndPoint) < _0023_003Dz3SduW_0024w_003D)
		{
			_0023_003DzMwEeeTIRNK2e = _0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D.ToArray();
			return true;
		}
		return false;
	}

	internal static void _0023_003Dz4AOqcu4H8eHnOWSI0Q_003D_003D(IList<ICurve> _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D, Dictionary<int, SizesOnCurve> _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, Surface _0023_003Dz_0024KKopL9T7nzT, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
	{
		foreach (TrimCurve item in _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D)
		{
			if (((Entity)item.Edge).Vertices == null && !item.Edge.IsPoint)
			{
				SizesOnCurve sizesOnCurve = _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D[item.EdgeIndex];
				_0023_003Dz_0024KKopL9T7nzT.PointInversion(item.Edge.PointAt(item.Edge.Domain.ParameterAt(0.333)), _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var proj);
				_0023_003Dz_0024KKopL9T7nzT.PointInversion(item.Edge.PointAt(item.Edge.Domain.ParameterAt(0.666)), _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var proj2);
				CurveMesher curveMesher = new CurveMesher(item.Edge, sizesOnCurve.StartSize, sizesOnCurve.EndSize);
				if (sizesOnCurve.StartSize != sizesOnCurve.EndSize)
				{
					curveMesher = ((Math.Abs(proj.X - proj2.X) < Math.Abs(proj.Y - proj2.Y)) ? ((!new Interval(proj.Y, proj2.Y).IsDecreasing) ? new CurveMesher(item.Edge, sizesOnCurve.StartSize, sizesOnCurve.EndSize) : new CurveMesher(item.Edge, sizesOnCurve.EndSize, sizesOnCurve.StartSize)) : ((!new Interval(proj.X, proj2.X).IsDecreasing) ? new CurveMesher(item.Edge, sizesOnCurve.StartSize, sizesOnCurve.EndSize) : new CurveMesher(item.Edge, sizesOnCurve.EndSize, sizesOnCurve.StartSize)));
				}
				curveMesher.DoWork();
				((Entity)item.Edge).Vertices = curveMesher.Result.Vertices;
			}
		}
	}

	private bool _0023_003Dz8ZkWhDVkvjGAbHMeu_Jio_0024w_003D(List<List<ICurve>> _0023_003DzymlhK_0SKtJvecP2yw_003D_003D, double _0023_003Dz3SduW_0024w_003D, List<ICurve> _0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D, List<ICurve> _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003Dz5F7_i_0024U_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DznYtQKck_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzXmrDMdc_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzeMBeuAQ_003D, Dictionary<int, SizesOnCurve> _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, out ICurve[] _0023_003DzyA3T2Zg_003D, out ICurve[] _0023_003DzMwEeeTIRNK2e)
	{
		if (_0023_003Dzs58MHt5MtOC7(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz3SduW_0024w_003D, _0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D, _0023_003DzWga_01xR5MHm7sEWsA_003D_003D, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, out _0023_003DzyA3T2Zg_003D, out _0023_003DzMwEeeTIRNK2e))
		{
			return true;
		}
		_0023_003DzymlhK_0SKtJvecP2yw_003D_003D.Clear();
		ICurve[] array = _0023_003DzyA3T2Zg_003D;
		foreach (ICurve curve in array)
		{
			if (curve is CompositeCurve)
			{
				CompositeCurve compositeCurve = (CompositeCurve)curve;
				_0023_003DzymlhK_0SKtJvecP2yw_003D_003D.Add(new List<ICurve>(compositeCurve.CurveList));
			}
			else
			{
				_0023_003DzymlhK_0SKtJvecP2yw_003D_003D.Add(new List<ICurve> { curve });
			}
		}
		_0023_003Dz5F7_i_0024U_003D.Clear();
		_0023_003DzXmrDMdc_003D.Clear();
		_0023_003DzqBDHmLvr0NML(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003Dz5F7_i_0024U_003D, _0023_003DzXmrDMdc_003D);
		_0023_003DzeMBeuAQ_003D.Clear();
		_0023_003DznYtQKck_003D.Clear();
		_0023_003DzKk6iXt3oicxi(_0023_003DzymlhK_0SKtJvecP2yw_003D_003D, _0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D);
		_0023_003DzWga_01xR5MHm7sEWsA_003D_003D.AddRange(_0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D);
		_0023_003DzoxKwQnJ9OBDKJcmzLQ_003D_003D.Clear();
		_0023_003DzMwEeeTIRNK2e = null;
		return false;
	}

	private static bool _0023_003Dzs9MYYwqms0Mxf7FbgxdU1lQ_003D(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		int index = 0;
		double num = double.MaxValue;
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i].GetTightBBox(out var boxMin, out var _);
			if (boxMin.X < num)
			{
				num = boxMin.X;
				index = i;
			}
		}
		return Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[index], Plane.XY);
	}

	internal static bool _0023_003DzinOQp4_qBUm4opZWpg_003D_003D(IList<ICurve> _0023_003DzKTAIrow_003D)
	{
		List<Point2D> list = new List<Point2D>();
		foreach (Curve item in _0023_003DzKTAIrow_003D)
		{
			if (item.Vertices != null)
			{
				for (int i = 0; i < item.Vertices.Length - 1; i++)
				{
					list.Add(item.Vertices[i]);
				}
				continue;
			}
			int num = (int)Math.Sqrt(item._0023_003DzMv2C5Tm1QMvc());
			bool isClosed = item.IsClosed;
			if (item.Degree == 1 && num < 1)
			{
				num = 1;
			}
			else if (item.Degree > 1 && num < 2 && !isClosed)
			{
				num = 2;
			}
			else if (item.Degree > 1 && num < 3 && isClosed)
			{
				num = 3;
			}
			for (int j = 0; j < num; j++)
			{
				int num2 = (int)((double)j * (double)item._0023_003DzMv2C5Tm1QMvc()) / num;
				list.Add(item.Pw[num2].Euclid);
			}
		}
		list.Add(list[0]);
		return Utility.PolygonArea(list) < 0.0;
	}

	private void _0023_003DzKk6iXt3oicxi(List<List<ICurve>> _0023_003Dz1y9aCkAPPkUYasYOaw_003D_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzeMBeuAQ_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DznYtQKck_003D)
	{
		for (int i = 0; i < _0023_003Dz1y9aCkAPPkUYasYOaw_003D_003D.Count; i++)
		{
			List<ICurve> list = _0023_003Dz1y9aCkAPPkUYasYOaw_003D_003D[i];
			TrimCurve trimCurve = (TrimCurve)list[0];
			Vector3D vector3D = trimCurve.TangentAt(trimCurve.Domain.ParameterAt(0.1));
			if (Math.Abs(vector3D.X) > Utility._0023_003Dzjyaz_Vfaky9X)
			{
				_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2 = new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(trimCurve.Pw.First(), vector3D)
				{
					_0023_003Dz3k5Uze_VdwnF = true
				};
				if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2.X == _0023_003DzBXeGKPzO7YMs.DomainU.Low)
				{
					_0023_003DzeMBeuAQ_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2);
				}
				else if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2.X == _0023_003DzBXeGKPzO7YMs.DomainU.High)
				{
					_0023_003DznYtQKck_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2);
				}
			}
			TrimCurve trimCurve2 = (TrimCurve)list[list.Count - 1];
			Vector3D vector3D2 = trimCurve2.TangentAt(trimCurve2.Domain.ParameterAt(0.9));
			if (Math.Abs(vector3D2.X) > Utility._0023_003Dzjyaz_Vfaky9X)
			{
				_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3 = new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(trimCurve2.Pw.Last(), vector3D2);
				if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3.X == _0023_003DzBXeGKPzO7YMs.DomainU.High)
				{
					_0023_003DznYtQKck_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3);
				}
				else if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3.X == _0023_003DzBXeGKPzO7YMs.DomainU.Low)
				{
					_0023_003DzeMBeuAQ_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3);
				}
			}
		}
	}

	private void _0023_003DzqBDHmLvr0NML(List<List<ICurve>> _0023_003Dz1y9aCkAPPkUYasYOaw_003D_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003Dz5F7_i_0024U_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzXmrDMdc_003D)
	{
		for (int i = 0; i < _0023_003Dz1y9aCkAPPkUYasYOaw_003D_003D.Count; i++)
		{
			List<ICurve> list = _0023_003Dz1y9aCkAPPkUYasYOaw_003D_003D[i];
			TrimCurve trimCurve = (TrimCurve)list[0];
			Vector3D vector3D = trimCurve.TangentAt(trimCurve.Domain.ParameterAt(0.1));
			if (Math.Abs(vector3D.Y) > Utility._0023_003Dzjyaz_Vfaky9X)
			{
				_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2 = new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(trimCurve.Pw.First(), vector3D)
				{
					_0023_003Dz3k5Uze_VdwnF = true
				};
				if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2.Y == _0023_003DzBXeGKPzO7YMs.DomainV.Low)
				{
					_0023_003Dz5F7_i_0024U_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2);
				}
				else if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2.Y == _0023_003DzBXeGKPzO7YMs.DomainV.High)
				{
					_0023_003DzXmrDMdc_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D2);
				}
			}
			TrimCurve trimCurve2 = (TrimCurve)list[list.Count - 1];
			Vector3D vector3D2 = trimCurve2.TangentAt(trimCurve2.Domain.ParameterAt(0.9));
			if (Math.Abs(vector3D2.Y) > Utility._0023_003Dzjyaz_Vfaky9X)
			{
				_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3 = new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(trimCurve2.Pw.Last(), vector3D2);
				if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3.Y == _0023_003DzBXeGKPzO7YMs.DomainV.High)
				{
					_0023_003DzXmrDMdc_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3);
				}
				else if (_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3.Y == _0023_003DzBXeGKPzO7YMs.DomainV.Low)
				{
					_0023_003Dz5F7_i_0024U_003D.Add(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D3);
				}
			}
		}
	}

	private void _0023_003DzD_jVUuQCj6Zl(List<List<ICurve>> _0023_003DzymlhK_0SKtJvecP2yw_003D_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzeMBeuAQ_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DznYtQKck_003D, bool _0023_003DzPKbzPJ4_003D, IList<ICurve> _0023_003DzGL3tKho1V0Kd, List<ICurve> _0023_003DzMwEeeTIRNK2e, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref int _0023_003Dzvw5eEfc_003D, out bool _0023_003Dz5RkD1sku7Kv8, bool _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
	{
		_0023_003Dz5RkD1sku7Kv8 = false;
		if (_0023_003DzeMBeuAQ_003D.Count == 0 && _0023_003DznYtQKck_003D.Count == 0)
		{
			return;
		}
		_0023_003DzEVVwx8ypl1vuQZfFbQ_003D_003D(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D, _0023_003DzPKbzPJ4_003D, _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D);
		List<ICurve> list = new List<ICurve>();
		foreach (List<ICurve> item in _0023_003DzymlhK_0SKtJvecP2yw_003D_003D)
		{
			list.AddRange(item);
		}
		int count = list.Count;
		if (_0023_003DzPKbzPJ4_003D)
		{
			_0023_003DznYtQKck_003D.Sort(new _0023_003Dzb2F0Dui7RGks4ARxJqE598arcSBur8z6lA_003D_003D());
			_0023_003DznYtQKck_003D.Reverse();
		}
		else
		{
			_0023_003DznYtQKck_003D.Sort(new _0023_003DzsUeaS33687NC8I5Z3V2Fr1PxgF_0024B9lieCg_003D_003D());
		}
		for (int i = 0; i < _0023_003DznYtQKck_003D.Count - 1; i += 2)
		{
			_0023_003DzCbwMy4hP1Yo47_UcQsCts3Y_003D(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DznYtQKck_003D[i], _0023_003DznYtQKck_003D[i + 1], list, _0023_003DzGL3tKho1V0Kd, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv8, _0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D: true);
			if (_0023_003Dz5RkD1sku7Kv8)
			{
				_0023_003DzCbwMy4hP1Yo47_UcQsCts3Y_003D(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DznYtQKck_003D[i + 1], _0023_003DznYtQKck_003D[i], list, _0023_003DzGL3tKho1V0Kd, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv8, _0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D: true);
				if (_0023_003Dz5RkD1sku7Kv8)
				{
					return;
				}
			}
		}
		if (_0023_003DzPKbzPJ4_003D)
		{
			_0023_003DzeMBeuAQ_003D.Sort(new _0023_003Dzb2F0Dui7RGks4ARxJqE598arcSBur8z6lA_003D_003D());
		}
		else
		{
			_0023_003DzeMBeuAQ_003D.Sort(new _0023_003DzsUeaS33687NC8I5Z3V2Fr1PxgF_0024B9lieCg_003D_003D());
			_0023_003DzeMBeuAQ_003D.Reverse();
		}
		for (int j = 0; j < _0023_003DzeMBeuAQ_003D.Count - 1; j += 2)
		{
			_0023_003DzCbwMy4hP1Yo47_UcQsCts3Y_003D(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzeMBeuAQ_003D[j], _0023_003DzeMBeuAQ_003D[j + 1], list, _0023_003DzGL3tKho1V0Kd, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv8, _0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D: true);
			if (_0023_003Dz5RkD1sku7Kv8)
			{
				_0023_003DzCbwMy4hP1Yo47_UcQsCts3Y_003D(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzeMBeuAQ_003D[j + 1], _0023_003DzeMBeuAQ_003D[j], list, _0023_003DzGL3tKho1V0Kd, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref _0023_003Dzvw5eEfc_003D, out _0023_003Dz5RkD1sku7Kv8, _0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D: true);
				if (_0023_003Dz5RkD1sku7Kv8)
				{
					return;
				}
			}
		}
		for (int k = count; k < list.Count; k++)
		{
			_0023_003DzMwEeeTIRNK2e.Add(list[k]);
		}
	}

	private ICurve[] _0023_003Dz1wxZ8ns7o2I5YhSlXA_003D_003D(IList<ICurve> _0023_003DzKTAIrow_003D, double _0023_003Dz3SduW_0024w_003D)
	{
		List<List<ICurve>> list = Utility._0023_003Dzx1_VB8cQKrRRV2_0024w7g_003D_003D(_0023_003DzKTAIrow_003D, _0023_003Dz3SduW_0024w_003D, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: true, _0023_003Dzp9LPrpP9wSDR: false);
		List<ICurve> list2 = new List<ICurve>();
		foreach (List<ICurve> item in list)
		{
			list2.Add(Utility.SmartAdd(item));
		}
		return list2.ToArray();
	}

	private void _0023_003DzbIDY9BOTPqfc(double _0023_003DzXULhp_00248_003D, IList<double> _0023_003DzcDEsV8s_003D, double _0023_003DzhbkBViI_003D)
	{
		bool flag = false;
		foreach (double item in _0023_003DzcDEsV8s_003D)
		{
			if (Utility.Compare(_0023_003DzhbkBViI_003D * Utility._0023_003Dzjyaz_Vfaky9X, item, _0023_003DzXULhp_00248_003D) == 0)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			_0023_003DzcDEsV8s_003D.Add(_0023_003DzXULhp_00248_003D);
		}
	}

	private void _0023_003DzCbwMy4hP1Yo47_UcQsCts3Y_003D(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzstAn7cw2vRC7, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzA5kmIQrPan7q, IList<ICurve> _0023_003Dz06A5WivSSyUp, IList<ICurve> _0023_003DzGL3tKho1V0Kd, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, ref int _0023_003Dzvw5eEfc_003D, out bool _0023_003Dz5RkD1sku7Kv8, bool _0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D)
	{
		_0023_003Dz5RkD1sku7Kv8 = false;
		if (_0023_003DzstAn7cw2vRC7.DistanceTo(_0023_003DzA5kmIQrPan7q) < 1E-12)
		{
			return;
		}
		Curve nurbsForm = new Line(_0023_003DzstAn7cw2vRC7, _0023_003DzA5kmIQrPan7q).GetNurbsForm();
		Vector2D tangent = _0023_003DzstAn7cw2vRC7.Tangent;
		Vector2D startTangent = nurbsForm.StartTangent;
		Vector2D tangent2 = _0023_003DzA5kmIQrPan7q.Tangent;
		if (_0023_003DzrLDcOevOeQ4qbLU2kw_003D_003D && !(_0023_003DzBXeGKPzO7YMs is SphericalSurface) && !_0023_003DzBXeGKPzO7YMs._0023_003DzaHuyAw_0024HZVzX() && (!_0023_003DzBXeGKPzO7YMs.IsClosedU || !_0023_003DzBXeGKPzO7YMs.IsClosedV))
		{
			if ((!_0023_003DzstAn7cw2vRC7.Tangent.IsZero && _0023_003DzstAn7cw2vRC7._0023_003Dz3k5Uze_VdwnF) || (!_0023_003DzA5kmIQrPan7q.Tangent.IsZero && !_0023_003DzA5kmIQrPan7q._0023_003Dz3k5Uze_VdwnF))
			{
				_0023_003Dz5RkD1sku7Kv8 = true;
				return;
			}
		}
		else if (Vector2D.PerpDotProduct(tangent, startTangent) < 0.0 - Utility._0023_003Dzjyaz_Vfaky9X || Vector2D.PerpDotProduct(startTangent, tangent2) < 0.0 - Utility._0023_003Dzjyaz_Vfaky9X)
		{
			_0023_003Dz5RkD1sku7Kv8 = true;
			return;
		}
		Vector3D vector3D = new Vector3D(_0023_003DzstAn7cw2vRC7, _0023_003DzA5kmIQrPan7q);
		vector3D.Normalize();
		nurbsForm.Vertices = new Point3D[2];
		nurbsForm.Vertices[0] = new PointTangent(_0023_003DzstAn7cw2vRC7.X, _0023_003DzstAn7cw2vRC7.Y, 0.0, vector3D.X, vector3D.Y, 0.0);
		nurbsForm.Vertices[1] = new PointTangent(_0023_003DzA5kmIQrPan7q.X, _0023_003DzA5kmIQrPan7q.Y, 0.0, vector3D.X, vector3D.Y, 0.0);
		List<ICurve> list = new List<ICurve> { nurbsForm };
		_0023_003DzTJHrVX5xjxwih8_0024bomy_0024c38_jpz9(_0023_003DzstAn7cw2vRC7, _0023_003DzA5kmIQrPan7q, _0023_003DzGL3tKho1V0Kd, vector3D, list, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D);
		double num = _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D * _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D;
		foreach (Curve item2 in list)
		{
			int count = _0023_003Dz06A5WivSSyUp.Count;
			foreach (ICurve item3 in _0023_003DzGL3tKho1V0Kd)
			{
				if (item3.IsPoint)
				{
					continue;
				}
				Plane plane = ((!(item3 is PlanarEntity planarEntity)) ? Utility.FitPlane(((Entity)item3).Vertices) : planarEntity.Plane);
				if (!(_0023_003DzBXeGKPzO7YMs is RevolvedSurface revolvedSurface) || _0023_003DzstAn7cw2vRC7.Y != _0023_003DzA5kmIQrPan7q.Y || Vector3D.AreParallel(revolvedSurface.Plane.AxisZ, plane.AxisZ))
				{
					Point3D point3D = _0023_003DzBXeGKPzO7YMs.Evaluate(item2.PointAt(item2.Domain.ParameterAt(1.0 / 3.0)));
					item3.Project(point3D, out var t);
					Point3D point3D2 = _0023_003DzBXeGKPzO7YMs.Evaluate(item2.PointAt(item2.Domain.ParameterAt(2.0 / 3.0)));
					item3.Project(point3D2, out var t2);
					if (item3.Domain.ParameterAt(0.01) < t && item3.Domain.ParameterAt(0.99) > t2 && Point3D.DistanceSquared(item3.PointAt(t), point3D) < num && Point3D.DistanceSquared(item3.PointAt(t2), point3D2) < num && t < t2)
					{
						TrimCurve item = _0023_003DzOHEaiyF6F9Go(item3, item2, ref _0023_003Dzvw5eEfc_003D);
						_0023_003Dz06A5WivSSyUp.Add(item);
						break;
					}
				}
			}
			if (_0023_003Dz06A5WivSSyUp.Count <= count)
			{
				ICurve curve2 = _0023_003DzBXeGKPzO7YMs.LiftCurve(item2, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
				((Entity)curve2).Regen(new RegenParams(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D));
				TrimCurve item = _0023_003DzOHEaiyF6F9Go(curve2, item2, ref _0023_003Dzvw5eEfc_003D);
				_0023_003Dz06A5WivSSyUp.Add(item);
			}
		}
	}

	private void _0023_003DzTJHrVX5xjxwih8_0024bomy_0024c38_jpz9(_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzstAn7cw2vRC7, _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D _0023_003DzA5kmIQrPan7q, IList<ICurve> _0023_003DzGL3tKho1V0Kd, Vector3D _0023_003DzlllF2to_003D, List<ICurve> _0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
	{
		List<double> list = new List<double> { _0023_003DzstAn7cw2vRC7.X, _0023_003DzA5kmIQrPan7q.X };
		List<double> list2 = new List<double> { _0023_003DzstAn7cw2vRC7.Y, _0023_003DzA5kmIQrPan7q.Y };
		foreach (ICurve item in _0023_003DzGL3tKho1V0Kd)
		{
			_0023_003DzBXeGKPzO7YMs.Project(item.StartPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var proj);
			if ((proj.X > _0023_003DzstAn7cw2vRC7.X && proj.X < _0023_003DzA5kmIQrPan7q.X) || (proj.X < _0023_003DzstAn7cw2vRC7.X && proj.X > _0023_003DzA5kmIQrPan7q.X))
			{
				_0023_003DzbIDY9BOTPqfc(proj.X, list, _0023_003DzBXeGKPzO7YMs.DomainU.Length);
			}
			if ((proj.Y > _0023_003DzstAn7cw2vRC7.Y && proj.Y < _0023_003DzA5kmIQrPan7q.Y) || (proj.Y < _0023_003DzstAn7cw2vRC7.Y && proj.Y > _0023_003DzA5kmIQrPan7q.Y))
			{
				_0023_003DzbIDY9BOTPqfc(proj.Y, list2, _0023_003DzBXeGKPzO7YMs.DomainV.Length);
			}
			_0023_003DzBXeGKPzO7YMs.Project(item.EndPoint, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var proj2);
			if ((proj2.X > _0023_003DzstAn7cw2vRC7.X && proj2.X < _0023_003DzA5kmIQrPan7q.X) || (proj2.X < _0023_003DzstAn7cw2vRC7.X && proj2.X > _0023_003DzA5kmIQrPan7q.X))
			{
				_0023_003DzbIDY9BOTPqfc(proj2.X, list, _0023_003DzBXeGKPzO7YMs.DomainU.Length);
			}
			if ((proj2.Y > _0023_003DzstAn7cw2vRC7.Y && proj2.Y < _0023_003DzA5kmIQrPan7q.Y) || (proj2.Y < _0023_003DzstAn7cw2vRC7.Y && proj2.Y > _0023_003DzA5kmIQrPan7q.Y))
			{
				_0023_003DzbIDY9BOTPqfc(proj2.Y, list2, _0023_003DzBXeGKPzO7YMs.DomainV.Length);
			}
		}
		Curve curve = (Curve)_0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D.First();
		if (list.Count > 2)
		{
			list.Sort();
			if (curve.Pw[0].X - curve.Pw[1].X > 0.0)
			{
				list.Reverse();
			}
			if (curve.Pw[0].Y == curve.Pw[1].Y)
			{
				_0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D.Clear();
			}
			for (int i = 0; i < list.Count - 1; i++)
			{
				Curve nurbsForm = new Line(list[i], _0023_003DzstAn7cw2vRC7.Y, list[i + 1], _0023_003DzstAn7cw2vRC7.Y).GetNurbsForm();
				nurbsForm.Vertices = new Point3D[2]
				{
					new PointTangent(list[i], _0023_003DzstAn7cw2vRC7.Y, 0.0, _0023_003DzlllF2to_003D.X, _0023_003DzlllF2to_003D.Y, 0.0),
					new PointTangent(list[i + 1], _0023_003DzstAn7cw2vRC7.Y, 0.0, _0023_003DzlllF2to_003D.X, _0023_003DzlllF2to_003D.Y, 0.0)
				};
				_0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D.Add(nurbsForm);
			}
		}
		if (list2.Count > 2)
		{
			list2.Sort();
			if (curve.Pw[0].Y - curve.Pw[1].Y > 0.0)
			{
				list2.Reverse();
			}
			if (curve.Pw[0].X == curve.Pw[1].X)
			{
				_0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D.Clear();
			}
			for (int j = 0; j < list2.Count - 1; j++)
			{
				Curve nurbsForm2 = new Line(_0023_003DzstAn7cw2vRC7.X, list2[j], _0023_003DzstAn7cw2vRC7.X, list2[j + 1]).GetNurbsForm();
				nurbsForm2.Vertices = new Point3D[2]
				{
					new PointTangent(_0023_003DzstAn7cw2vRC7.X, list2[j], 0.0, _0023_003DzlllF2to_003D.X, _0023_003DzlllF2to_003D.Y, 0.0),
					new PointTangent(_0023_003DzstAn7cw2vRC7.X, list2[j + 1], 0.0, _0023_003DzlllF2to_003D.X, _0023_003DzlllF2to_003D.Y, 0.0)
				};
				_0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D.Add(nurbsForm2);
			}
		}
	}

	private void _0023_003DzEVVwx8ypl1vuQZfFbQ_003D_003D(List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DzeMBeuAQ_003D, List<_0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D> _0023_003DznYtQKck_003D, bool _0023_003DzPKbzPJ4_003D, bool _0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
	{
		if (_0023_003DzPKbzPJ4_003D)
		{
			if (_0023_003DzeMBeuAQ_003D.Count % 2 == 1)
			{
				if (_0023_003DzeMBeuAQ_003D[0]._0023_003Dz3k5Uze_VdwnF)
				{
					if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
					{
						_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Min, _0023_003DzeMBeuAQ_003D[0].Y));
					}
					else
					{
						_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Max, _0023_003DzeMBeuAQ_003D[0].Y));
					}
				}
				else if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
				{
					_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Max, _0023_003DzeMBeuAQ_003D[0].Y));
				}
				else
				{
					_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Min, _0023_003DzeMBeuAQ_003D[0].Y));
				}
			}
			if (_0023_003DznYtQKck_003D.Count % 2 != 1)
			{
				return;
			}
			if (_0023_003DznYtQKck_003D.Last()._0023_003Dz3k5Uze_VdwnF)
			{
				if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
				{
					_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Max, _0023_003DznYtQKck_003D[0].Y));
				}
				else
				{
					_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Min, _0023_003DznYtQKck_003D[0].Y));
				}
			}
			else if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
			{
				_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Min, _0023_003DznYtQKck_003D[0].Y));
			}
			else
			{
				_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzBXeGKPzO7YMs.DomainU.Max, _0023_003DznYtQKck_003D[0].Y));
			}
			return;
		}
		if (_0023_003DzeMBeuAQ_003D.Count % 2 == 1)
		{
			if (_0023_003DzeMBeuAQ_003D[0]._0023_003Dz3k5Uze_VdwnF)
			{
				if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
				{
					_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzeMBeuAQ_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Max));
				}
				else
				{
					_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzeMBeuAQ_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Min));
				}
			}
			else if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
			{
				_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzeMBeuAQ_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Min));
			}
			else
			{
				_0023_003DzeMBeuAQ_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DzeMBeuAQ_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Max));
			}
		}
		if (_0023_003DznYtQKck_003D.Count % 2 != 1)
		{
			return;
		}
		if (_0023_003DznYtQKck_003D.Last()._0023_003Dz3k5Uze_VdwnF)
		{
			if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
			{
				_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DznYtQKck_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Min));
			}
			else
			{
				_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DznYtQKck_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Max));
			}
		}
		else if (_0023_003DzEJ6gY8zcI7jJKQ_DhA_003D_003D)
		{
			_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DznYtQKck_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Max));
		}
		else
		{
			_0023_003DznYtQKck_003D.Add(new _0023_003Dz3jdQylzWHk7vrbmzAw_003D_003D(_0023_003DznYtQKck_003D[0].X, _0023_003DzBXeGKPzO7YMs.DomainV.Min));
		}
	}

	private static TrimCurve _0023_003DzOHEaiyF6F9Go(ICurve _0023_003DzTx2aqr8_003D, Curve _0023_003Dzl_0024kBRC0_003D, ref int _0023_003Dzvw5eEfc_003D)
	{
		int edgeIndex = _0023_003DzTx2aqr8_003D.EdgeIndex;
		TrimCurve trimCurve = _0023_003Dzl_0024kBRC0_003D._0023_003DzmGgqdRaHiXdg(_0023_003DzTx2aqr8_003D);
		trimCurve.Index = _0023_003Dzvw5eEfc_003D++;
		trimCurve.EdgeIndex = edgeIndex;
		return trimCurve;
	}

	public static double _0023_003DzkkuZ9yRj4LhU(IList<ICurve> _0023_003DzKTAIrow_003D, bool _0023_003DzbErHvVw_003D)
	{
		double num = Utility.GetMaxGap(_0023_003DzKTAIrow_003D, _0023_003DzbErHvVw_003D);
		if (num < Utility._0023_003DzheSR8QM7q9ya)
		{
			num = Utility._0023_003DzheSR8QM7q9ya;
		}
		return num;
	}

	public bool _0023_003DzcEaRaYGiOQ7FMhR_0024jTcUjEo_003D(IList<ICurve> _0023_003DzKTAIrow_003D)
	{
		if (_0023_003DzNgWSnR6iGqlHmH6GuLeYetI_003D())
		{
			return true;
		}
		if (_0023_003DzKTAIrow_003D.Count == 1)
		{
			return _0023_003DzKTAIrow_003D.First().IsClosed;
		}
		List<double> list = new List<double>(_0023_003DzKTAIrow_003D.Count + 1);
		ICurve curve = _0023_003DzKTAIrow_003D.Last();
		ICurve curve2 = _0023_003DzKTAIrow_003D.First();
		if ((_0023_003DzBXeGKPzO7YMs.IsClosedU && Math.Abs(curve.EndPoint.X - curve2.StartPoint.X) > _0023_003DzBXeGKPzO7YMs.DomainU.Length / 2.0) || (_0023_003DzBXeGKPzO7YMs.IsClosedV && Math.Abs(curve.EndPoint.Y - curve2.StartPoint.Y) > _0023_003DzBXeGKPzO7YMs.DomainV.Length / 2.0))
		{
			return false;
		}
		list.Add(Point3D.Distance(curve2.StartPoint, curve.EndPoint));
		for (int i = 0; i < _0023_003DzKTAIrow_003D.Count - 1; i++)
		{
			curve = _0023_003DzKTAIrow_003D[i];
			curve2 = _0023_003DzKTAIrow_003D[i + 1];
			list.Add(Point3D.Distance(curve.EndPoint, curve2.StartPoint));
		}
		double _0023_003Dzv6h5LMciF8Z8AHoc6A_003D_003D;
		Size2D size2D = Surface._0023_003DzZVrB7YDW9a_wYxQUtS9H2Ak_003D(_0023_003DzKTAIrow_003D, out _0023_003Dzv6h5LMciF8Z8AHoc6A_003D_003D);
		return list._0023_003Dz3GrFfNQ_003D() < size2D.Diagonal * 0.0001;
	}

	private bool _0023_003DzNgWSnR6iGqlHmH6GuLeYetI_003D()
	{
		if (!_0023_003DzBXeGKPzO7YMs.IsClosedU && !_0023_003DzBXeGKPzO7YMs.IsClosedV && _0023_003DzBXeGKPzO7YMs.bottomEdge == null && _0023_003DzBXeGKPzO7YMs.rightEdge == null && _0023_003DzBXeGKPzO7YMs.topEdge == null)
		{
			return _0023_003DzBXeGKPzO7YMs.leftEdge == null;
		}
		return false;
	}
}
