using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class MinimumDistance : WorkUnit
{
	private sealed class _0023_003Dz_0024HJN1ByiTN5X : _0023_003DzI5MiWyE_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dze4t_00247iOgStAt;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dzn2AChhNvYV_0024X;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dz26bdYj92cflX;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dz6uDQbFls3_0024n5;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzWWgGxds_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DziP9fFuA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz61IPlm0_003D;

		public _0023_003Dz_0024HJN1ByiTN5X(int _0023_003DzfFyRe754BKan, int _0023_003Dz6GbnGMPrTRLa, int _0023_003DzbnY3p4zUi6xQ, int _0023_003DzbC8Oj1P5_nD9, PointNormalUv _0023_003DzCbSDGus_003D, PointNormalUv _0023_003Dzjtp_lVY_003D)
			: base(_0023_003DzCbSDGus_003D, _0023_003Dzjtp_lVY_003D)
		{
			_0023_003Dze4t_00247iOgStAt = _0023_003DzfFyRe754BKan;
			_0023_003Dzn2AChhNvYV_0024X = _0023_003Dz6GbnGMPrTRLa;
			_0023_003Dz26bdYj92cflX = _0023_003DzbnY3p4zUi6xQ;
			_0023_003Dz6uDQbFls3_0024n5 = _0023_003DzbC8Oj1P5_nD9;
			_0023_003DzWWgGxds_003D = _0023_003Dz5UWQnIQ_003D.U;
			_0023_003DziP9fFuA_003D = _0023_003DzwzHUHq4_003D.U;
			_0023_003Dz61IPlm0_003D = _0023_003DzwzHUHq4_003D.V;
		}

		public override object Clone()
		{
			return new _0023_003Dz_0024HJN1ByiTN5X(_0023_003Dze4t_00247iOgStAt, _0023_003Dzn2AChhNvYV_0024X, _0023_003Dz26bdYj92cflX, _0023_003Dz6uDQbFls3_0024n5, (PointNormalUv)_0023_003DzwzHUHq4_003D.Clone(), (PointNormalUv)_0023_003Dz5UWQnIQ_003D.Clone());
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Comparison<_0023_003Dzq03E8WAcFKhl> _0023_003DzCLL27sqP_D3AFHFS3w_003D_003D;

		internal int _0023_003DzAcHUEer_0024bJw_0024l5Eole6Bu_0024_ycpO0(_0023_003Dzq03E8WAcFKhl _0023_003DzL_BXzuA_003D, _0023_003Dzq03E8WAcFKhl _0023_003DzW0adwBQ_003D)
		{
			return _0023_003DzL_BXzuA_003D._0023_003DzVNOVRN7mF1xbxNA5DQ_003D_003D().CompareTo(_0023_003DzW0adwBQ_003D._0023_003DzVNOVRN7mF1xbxNA5DQ_003D_003D());
		}
	}

	private enum _0023_003Dz8eqy3JQ_003D : byte
	{

	}

	private sealed class _0023_003DzCQRN6dAk9sLt : _0023_003DzI5MiWyE_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dztyc6kG4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzpZbzwQ4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz6ND2cc0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dzu0pfCNc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzgzzCeHY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dzoj4236c_003D;

		public _0023_003DzCQRN6dAk9sLt(int _0023_003DzZSMvk48_003D, int _0023_003DzAxuPLmU_003D, PointNormalUv _0023_003DzCbSDGus_003D, PointNormalUv _0023_003Dzjtp_lVY_003D)
			: base(_0023_003DzCbSDGus_003D, _0023_003Dzjtp_lVY_003D)
		{
			_0023_003Dztyc6kG4_003D = _0023_003DzZSMvk48_003D;
			_0023_003DzpZbzwQ4_003D = _0023_003DzAxuPLmU_003D;
			_0023_003Dz6ND2cc0_003D = _0023_003DzwzHUHq4_003D.U;
			_0023_003Dzu0pfCNc_003D = _0023_003DzwzHUHq4_003D.V;
			_0023_003DzgzzCeHY_003D = _0023_003Dz5UWQnIQ_003D.U;
			_0023_003Dzoj4236c_003D = _0023_003Dz5UWQnIQ_003D.V;
		}

		public override object Clone()
		{
			return new _0023_003DzCQRN6dAk9sLt(_0023_003Dztyc6kG4_003D, _0023_003DzpZbzwQ4_003D, (PointNormalUv)_0023_003DzwzHUHq4_003D.Clone(), (PointNormalUv)_0023_003Dz5UWQnIQ_003D.Clone());
		}
	}

	private sealed class _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D
	{
		public MinimumDistance _0023_003DzopRx0_MBcTQs;

		public Point3D[] _0023_003Dze13_0024sqWsbmC5;

		public double[] _0023_003Dzd2yCtzjnqXgSvMXLNz7SSgawiuVd;

		internal void _0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D(int _0023_003DzDAv4aw4_003D)
		{
			_0023_003DzopRx0_MBcTQs._0023_003Dz0tEHeuB0qP9j[_0023_003DzDAv4aw4_003D].ClosestPointTo(_0023_003DzopRx0_MBcTQs._0023_003DzrvvzXC0ysFW6, out var u, out var v);
			_0023_003Dze13_0024sqWsbmC5[_0023_003DzDAv4aw4_003D] = _0023_003DzopRx0_MBcTQs._0023_003Dz0tEHeuB0qP9j[_0023_003DzDAv4aw4_003D].PointAt(u, v);
			_0023_003Dzd2yCtzjnqXgSvMXLNz7SSgawiuVd[_0023_003DzDAv4aw4_003D] = Point3D.DistanceSquared(_0023_003DzopRx0_MBcTQs._0023_003DzrvvzXC0ysFW6, _0023_003Dze13_0024sqWsbmC5[_0023_003DzDAv4aw4_003D]);
		}
	}

	private abstract class _0023_003DzI5MiWyE_003D : ICloneable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public PointNormalUv _0023_003DzwzHUHq4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public PointNormalUv _0023_003Dz5UWQnIQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003Dz6Fpx7M09bM7ZsDbDiHNwSI8_003D;

		protected _0023_003DzI5MiWyE_003D(PointNormalUv _0023_003DzCbSDGus_003D, PointNormalUv _0023_003Dzjtp_lVY_003D)
		{
			_0023_003DzwzHUHq4_003D = _0023_003DzCbSDGus_003D;
			_0023_003Dz5UWQnIQ_003D = _0023_003Dzjtp_lVY_003D;
			_0023_003Dzz_0024CeF8LN7AMy(double.NaN);
		}

		public double _0023_003DzzSdvRJ4yZZNL()
		{
			return _0023_003Dz6Fpx7M09bM7ZsDbDiHNwSI8_003D;
		}

		public void _0023_003Dzz_0024CeF8LN7AMy(double _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz6Fpx7M09bM7ZsDbDiHNwSI8_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public void _0023_003DzIhIYScs0NLnP()
		{
			_0023_003Dzz_0024CeF8LN7AMy(Point3D.DistanceSquared(_0023_003DzwzHUHq4_003D, _0023_003Dz5UWQnIQ_003D));
		}

		public override string ToString()
		{
			if (!(_0023_003DzwzHUHq4_003D != null) || !(_0023_003Dz5UWQnIQ_003D != null))
			{
				return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996929);
			}
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996914), _0023_003DzzSdvRJ4yZZNL(), _0023_003DzwzHUHq4_003D, _0023_003Dz5UWQnIQ_003D);
		}

		public abstract object Clone();
	}

	private sealed class _0023_003DzL2QA5Joe2J8m : _0023_003DzI5MiWyE_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dzs6P3GxWeRx1x;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzpdUUD_4F36Bi;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzPTaMMVZeD4_q;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzvmlSRlsCugW7;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzQXe2ycFqrkRt;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzvPuEqJ7P3C5d;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzDTx2OHE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzSMytmtQ_003D;

		public _0023_003DzL2QA5Joe2J8m(int _0023_003DzItiq2wKgbn_00249, int _0023_003DzJp4xQgyZy3mQ, int _0023_003Dzht9ciYDXtz30, int _0023_003DzzxPS6jWUEVYe, int _0023_003DzChMGZiM87pW6, int _0023_003DzE0KLzJXEVkPi, PointNormalUv _0023_003DzCbSDGus_003D, PointNormalUv _0023_003Dzjtp_lVY_003D)
			: base(_0023_003DzCbSDGus_003D, _0023_003Dzjtp_lVY_003D)
		{
			_0023_003Dzs6P3GxWeRx1x = _0023_003DzItiq2wKgbn_00249;
			_0023_003DzpdUUD_4F36Bi = _0023_003DzJp4xQgyZy3mQ;
			_0023_003DzPTaMMVZeD4_q = _0023_003Dzht9ciYDXtz30;
			_0023_003DzvmlSRlsCugW7 = _0023_003DzzxPS6jWUEVYe;
			_0023_003DzQXe2ycFqrkRt = _0023_003DzChMGZiM87pW6;
			_0023_003DzvPuEqJ7P3C5d = _0023_003DzE0KLzJXEVkPi;
			_0023_003DzDTx2OHE_003D = _0023_003DzwzHUHq4_003D.U;
			_0023_003DzSMytmtQ_003D = _0023_003Dz5UWQnIQ_003D.U;
		}

		public override object Clone()
		{
			return new _0023_003DzL2QA5Joe2J8m(_0023_003Dzs6P3GxWeRx1x, _0023_003DzpdUUD_4F36Bi, _0023_003DzPTaMMVZeD4_q, _0023_003DzvmlSRlsCugW7, _0023_003DzQXe2ycFqrkRt, _0023_003DzvPuEqJ7P3C5d, (PointNormalUv)_0023_003DzwzHUHq4_003D.Clone(), (PointNormalUv)_0023_003Dz5UWQnIQ_003D.Clone());
		}
	}

	private sealed class _0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D
	{
		public MinimumDistance _0023_003DzopRx0_MBcTQs;

		public _0023_003Dzq03E8WAcFKhl[] _0023_003DzXCKVKJVntiTL;

		internal void _0023_003DzQHo_0024BxJt2mz3KfBqkQzftS4_003D(int _0023_003DzZSMvk48_003D)
		{
			for (int i = 0; i < _0023_003DzopRx0_MBcTQs._0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length; i++)
			{
				int num = _0023_003DzZSMvk48_003D * _0023_003DzopRx0_MBcTQs._0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length + i;
				_0023_003DzXCKVKJVntiTL[num] = new _0023_003Dzq03E8WAcFKhl(_0023_003DzZSMvk48_003D, i, _0023_003DzopRx0_MBcTQs._0023_003DzOE0AAeumraCVMCzBSQ_003D_003D, _0023_003DzopRx0_MBcTQs._0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D, _0023_003DzopRx0_MBcTQs._0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt, _0023_003DzopRx0_MBcTQs._0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL, _0023_003DzopRx0_MBcTQs._0023_003Dz6LYSVEJVpLFjFhvnoQ_003D_003D, _0023_003DzopRx0_MBcTQs._0023_003DzEoWlxu1MwzlHZjCTvw_003D_003D);
			}
		}

		internal void _0023_003DzsZhLEp8d_ZnxtQuJ9JkbZW8_003D(int _0023_003DzBn0sGNA_003D)
		{
			_0023_003DzXCKVKJVntiTL[_0023_003DzBn0sGNA_003D]._0023_003DztuEjAT2fbtI4lc7vqA_003D_003D();
			_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003DzXCKVKJVntiTL.Length, _0023_003DzopRx0_MBcTQs.PreprocessingEntitiesText, _0023_003DzopRx0_MBcTQs._0023_003DzsWnj47U_003D, _0023_003DzopRx0_MBcTQs._0023_003DzEBehidw_003D);
		}
	}

	private sealed class _0023_003Dzq03E8WAcFKhl
	{
		[Serializable]
		private sealed class _0023_003Dz2IEmqow_003D
		{
			public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

			public static Func<ICurve, ICurve> _0023_003DzuB7dv7S8eYwTHojJJw_003D_003D;

			public static Func<_0023_003DzI5MiWyE_003D, bool> _0023_003Dzxp7xNXOAagU4emu62A_003D_003D;

			public static Func<_0023_003DzI5MiWyE_003D, double> _0023_003Dz9ZCukRtgAHjTwD_dmw_003D_003D;

			public static Func<_0023_003DzI5MiWyE_003D, double> _0023_003Dzu2ZevFJy53VMTThQWA_003D_003D;

			public static Func<_0023_003DzCQRN6dAk9sLt, _0023_003DzCQRN6dAk9sLt> _0023_003DznpZt5R8lffynlK56FQ_003D_003D;

			public static Func<_0023_003Dz_0024HJN1ByiTN5X, _0023_003Dz_0024HJN1ByiTN5X> _0023_003Dzlm2lrQMxP9Z4cmGPiw_003D_003D;

			public static Func<_0023_003DzL2QA5Joe2J8m, _0023_003DzL2QA5Joe2J8m> _0023_003DzOK8hhnyykmyvQb_0024Qpg_003D_003D;

			public static Action<_0023_003DzL2QA5Joe2J8m> _0023_003DzCrJzJ1fv7yio0ulh1w_003D_003D;

			public static Comparison<_0023_003DzL2QA5Joe2J8m> _0023_003DzZDKA7lMXwtwoUhXG9A_003D_003D;

			public static Action<_0023_003Dz_0024HJN1ByiTN5X> _0023_003DzL8A4vc001c0gQY3dGg_003D_003D;

			public static Comparison<_0023_003Dz_0024HJN1ByiTN5X> _0023_003DzUvYHuXmf4QeFMv1mWA_003D_003D;

			internal ICurve _0023_003DzUrxrYx4DerSMe6193yOYb5M_003D(ICurve _0023_003Dzt_m8zV0_003D)
			{
				return ((TrimCurve)_0023_003Dzt_m8zV0_003D).Edge;
			}

			internal bool _0023_003DzjYsmRAr1I_0024dD23gP4ZeYaqw_003D(_0023_003DzI5MiWyE_003D _0023_003DzuwH5j5s_003D)
			{
				return _0023_003DzuwH5j5s_003D != null;
			}

			internal double _0023_003Dz7iHR_002486QWp0M0WybPKoxJYc_003D(_0023_003DzI5MiWyE_003D _0023_003DzuwH5j5s_003D)
			{
				return _0023_003DzuwH5j5s_003D._0023_003DzzSdvRJ4yZZNL();
			}

			internal double _0023_003DzNWjpNKion5vf4F8DX3qPFw0A2Fy1m4rxbQ_003D_003D(_0023_003DzI5MiWyE_003D _0023_003Dz5rQzobg_003D)
			{
				return _0023_003Dz5rQzobg_003D?._0023_003DzzSdvRJ4yZZNL() ?? double.MaxValue;
			}

			internal _0023_003DzCQRN6dAk9sLt _0023_003DzDXyabHxa8LZIJLueidBQkU0_003D(_0023_003DzCQRN6dAk9sLt _0023_003Dz5rQzobg_003D)
			{
				return (_0023_003DzCQRN6dAk9sLt)_0023_003Dz5rQzobg_003D.Clone();
			}

			internal _0023_003Dz_0024HJN1ByiTN5X _0023_003DzImBXQQ5feyDe1R0ywDfSyKk_003D(_0023_003Dz_0024HJN1ByiTN5X _0023_003Dz5rQzobg_003D)
			{
				return (_0023_003Dz_0024HJN1ByiTN5X)_0023_003Dz5rQzobg_003D.Clone();
			}

			internal _0023_003DzL2QA5Joe2J8m _0023_003Dzw_AEGtqBsO68QQldH3Bp3E0_003D(_0023_003DzL2QA5Joe2J8m _0023_003Dz5rQzobg_003D)
			{
				return (_0023_003DzL2QA5Joe2J8m)_0023_003Dz5rQzobg_003D.Clone();
			}

			internal void _0023_003DzT0u5HJ9eP03TduLyBt_CGWtY2XIg(_0023_003DzL2QA5Joe2J8m _0023_003Dz5rQzobg_003D)
			{
				_0023_003Dz5rQzobg_003D._0023_003DzIhIYScs0NLnP();
			}

			internal int _0023_003DzCv12b3HQQVB8tBo3R6ABPRjTrONW(_0023_003DzL2QA5Joe2J8m _0023_003Dzva8YATk_003D, _0023_003DzL2QA5Joe2J8m _0023_003Dz6ED5_S8_003D)
			{
				return _0023_003Dzva8YATk_003D._0023_003DzzSdvRJ4yZZNL().CompareTo(_0023_003Dz6ED5_S8_003D._0023_003DzzSdvRJ4yZZNL());
			}

			internal void _0023_003DzbntQChwyQksJsR3_0024JWJXNsUI1Q_00246(_0023_003Dz_0024HJN1ByiTN5X _0023_003Dz5rQzobg_003D)
			{
				_0023_003Dz5rQzobg_003D._0023_003DzIhIYScs0NLnP();
			}

			internal int _0023_003Dz7sNkwZb42ptyo3mqSKGzHjp01yjj(_0023_003Dz_0024HJN1ByiTN5X _0023_003Dzva8YATk_003D, _0023_003Dz_0024HJN1ByiTN5X _0023_003Dz6ED5_S8_003D)
			{
				return _0023_003Dzva8YATk_003D._0023_003DzzSdvRJ4yZZNL().CompareTo(_0023_003Dz6ED5_S8_003D._0023_003DzzSdvRJ4yZZNL());
			}
		}

		private sealed class _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D
		{
			public int _0023_003Dz3pKCiioRSr_00242sJfqFk7dY7s_003D;

			public ICurve[] _0023_003DzX4KJCrvCv8tc;

			public int[][] _0023_003Dza7EwQmUyHpuW;

			public ICurve[] _0023_003DzxJBvE8ms39_0024N;

			public _0023_003DzI5MiWyE_003D[] _0023_003DzSCLYcFo5XJr9;

			public _0023_003Dzq03E8WAcFKhl _0023_003DzopRx0_MBcTQs;

			public double _0023_003DzOWjUf9o_003D;

			internal void _0023_003DzGgfQV7bzRcNs0q2fsqug4LZmEx_qKABTjA_003D_003D(int _0023_003Dzr7MLYP0_003D)
			{
				int num = _0023_003Dzr7MLYP0_003D * _0023_003Dz3pKCiioRSr_00242sJfqFk7dY7s_003D;
				int num2 = _0023_003Dzr7MLYP0_003D / _0023_003DzX4KJCrvCv8tc.Length;
				int num3 = _0023_003Dzr7MLYP0_003D % _0023_003DzX4KJCrvCv8tc.Length;
				_0023_003Dza7EwQmUyHpuW[_0023_003Dzr7MLYP0_003D] = new int[2] { num2, num3 };
				ICurve curve = (ICurve)_0023_003DzxJBvE8ms39_0024N[num2].Clone();
				ICurve curve2 = (ICurve)_0023_003DzX4KJCrvCv8tc[num3].Clone();
				Point3D[] array = new Point3D[2] { curve.StartPoint, curve.EndPoint };
				Point3D[] array2 = new Point3D[2] { curve2.StartPoint, curve2.EndPoint };
				for (int i = 0; i < array.Length; i++)
				{
					curve.Project(array[i], out var t);
					PointNormalUv _0023_003DzCbSDGus_003D = new PointNormalUv(array[i].X, array[i].Y, array[i].Z, t, double.NaN);
					curve2.ClosestPointTo(array[i], out var t2);
					Point3D point3D = curve2.PointAt(t2);
					PointNormalUv _0023_003Dzjtp_lVY_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, t2, double.NaN);
					_0023_003DzSCLYcFo5XJr9[num] = new _0023_003DzL2QA5Joe2J8m(-1, -1, _0023_003DzopRx0_MBcTQs._0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DzopRx0_MBcTQs._0023_003DznIV4h3VT9mbQ(), num2, num3, _0023_003DzCbSDGus_003D, _0023_003Dzjtp_lVY_003D);
					_0023_003DzSCLYcFo5XJr9[num]._0023_003DzIhIYScs0NLnP();
					num++;
					for (int j = 0; j < array2.Length; j++)
					{
						curve2.Project(array2[i], out var t3);
						PointNormalUv _0023_003Dzjtp_lVY_003D2 = new PointNormalUv(array2[i].X, array2[i].Y, array2[i].Z, t3, double.NaN);
						_0023_003DzSCLYcFo5XJr9[num] = new _0023_003DzL2QA5Joe2J8m(-1, -1, _0023_003DzopRx0_MBcTQs._0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DzopRx0_MBcTQs._0023_003DznIV4h3VT9mbQ(), num2, num3, _0023_003DzCbSDGus_003D, _0023_003Dzjtp_lVY_003D2);
						_0023_003DzSCLYcFo5XJr9[num]._0023_003DzIhIYScs0NLnP();
						num++;
						if (i == 0)
						{
							curve.ClosestPointTo(array2[j], out var t4);
							Point3D point3D2 = curve.PointAt(t4);
							PointNormalUv _0023_003DzCbSDGus_003D2 = new PointNormalUv(point3D2.X, point3D2.Y, point3D2.Z, t4, double.NaN);
							_0023_003DzSCLYcFo5XJr9[num] = new _0023_003DzL2QA5Joe2J8m(-1, -1, _0023_003DzopRx0_MBcTQs._0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DzopRx0_MBcTQs._0023_003DznIV4h3VT9mbQ(), num2, num3, _0023_003DzCbSDGus_003D2, _0023_003Dzjtp_lVY_003D2);
							_0023_003DzSCLYcFo5XJr9[num]._0023_003DzIhIYScs0NLnP();
							num++;
						}
					}
				}
			}

			internal bool _0023_003DzIoW8LiPxXDac93dJrjhNZz7sUfg0wttg0w_003D_003D(_0023_003DzI5MiWyE_003D _0023_003Dz5rQzobg_003D)
			{
				if (_0023_003Dz5rQzobg_003D != null)
				{
					return _0023_003Dz5rQzobg_003D._0023_003DzzSdvRJ4yZZNL() == _0023_003DzOWjUf9o_003D;
				}
				return false;
			}
		}

		private sealed class _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D
		{
			public int _0023_003Dz4CY5xohrHpS5;

			public _0023_003DzL2QA5Joe2J8m[] _0023_003Dzu5kSRZe5IOmZ;

			public ICurve[][] _0023_003Dz98kwboInvyL0nCy_0024LA_003D_003D;

			public ICurve[][] _0023_003DzxRsp0K3G0iTb94YFkw_003D_003D;

			public _0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;

			internal void _0023_003DzLLx_0024bFJOLilSL9EwJA_003D_003D(int _0023_003Dz437_00244ak_003D)
			{
				int num = _0023_003Dz437_00244ak_003D + _0023_003Dz4CY5xohrHpS5;
				_0023_003DzL2QA5Joe2J8m _0023_003DzL2QA5Joe2J8m2 = _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				Curve nurbsForm = _0023_003Dz98kwboInvyL0nCy_0024LA_003D_003D[_0023_003DzL2QA5Joe2J8m2._0023_003DzPTaMMVZeD4_q][_0023_003DzL2QA5Joe2J8m2._0023_003DzQXe2ycFqrkRt].GetNurbsForm();
				Curve nurbsForm2 = _0023_003DzxRsp0K3G0iTb94YFkw_003D_003D[_0023_003DzL2QA5Joe2J8m2._0023_003DzvmlSRlsCugW7][_0023_003DzL2QA5Joe2J8m2._0023_003DzvPuEqJ7P3C5d].GetNurbsForm();
				if (Curve.MinimumDistance(nurbsForm.Clone() as Curve, nurbsForm2.Clone() as Curve, allowOutside: false, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzDTx2OHE_003D, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzSMytmtQ_003D, out var distance))
				{
					Point3D point3D = nurbsForm.PointAt(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzDTx2OHE_003D);
					Point3D point3D2 = nurbsForm2.PointAt(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzSMytmtQ_003D);
					_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzwzHUHq4_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzDTx2OHE_003D, double.NaN);
					_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz5UWQnIQ_003D = new PointNormalUv(point3D2.X, point3D2.Y, point3D2.Z, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzSMytmtQ_003D, double.NaN);
					_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzz_0024CeF8LN7AMy(distance * distance);
					_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				}
				else
				{
					_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = null;
				}
			}
		}

		private sealed class _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D
		{
			public Surface[] _0023_003Dzt_vaKiHI6Zn0;

			public Point3D[] _0023_003Dzm9bQX1ehzIK5;

			public int _0023_003Dz5Ex_zZ0_003D;

			public _0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;

			public _0023_003Dzq03E8WAcFKhl _0023_003DzopRx0_MBcTQs;

			internal void _0023_003DzmoBj5ZqS3WnPGtFYGfR__gocbAJyN3QH9tRK2l4_003D(int _0023_003Dz437_00244ak_003D)
			{
				_0023_003Dzt_vaKiHI6Zn0[_0023_003Dz437_00244ak_003D].ClosestPointTo(_0023_003Dzm9bQX1ehzIK5[_0023_003Dz437_00244ak_003D], out var u, out var v);
				Point3D point3D = _0023_003Dzt_vaKiHI6Zn0[_0023_003Dz437_00244ak_003D].PointAt(u, v);
				PointNormalUv _0023_003Dzjtp_lVY_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, u, v);
				int num = _0023_003Dz437_00244ak_003D + _0023_003Dz5Ex_zZ0_003D;
				_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = new _0023_003DzL2QA5Joe2J8m(-1, -1, _0023_003DzopRx0_MBcTQs._0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DzopRx0_MBcTQs._0023_003DznIV4h3VT9mbQ(), -2, -2, new PointNormalUv(_0023_003Dzm9bQX1ehzIK5[_0023_003Dz437_00244ak_003D].X, _0023_003Dzm9bQX1ehzIK5[_0023_003Dz437_00244ak_003D].Y, _0023_003Dzm9bQX1ehzIK5[_0023_003Dz437_00244ak_003D].Z, u, v), _0023_003Dzjtp_lVY_003D);
				_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num]._0023_003DzIhIYScs0NLnP();
			}
		}

		private sealed class _0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D
		{
			public int _0023_003Dz4CY5xohrHpS5;

			public _0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;

			public _0023_003Dzq03E8WAcFKhl _0023_003DzopRx0_MBcTQs;

			public _0023_003DzCQRN6dAk9sLt[] _0023_003Dzu5kSRZe5IOmZ;

			internal void _0023_003DzLLx_0024bFJOLilSL9EwJA_003D_003D(int _0023_003Dz437_00244ak_003D)
			{
				int num = _0023_003Dz437_00244ak_003D + _0023_003Dz4CY5xohrHpS5;
				_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = null;
				if (Surface.MinimumDistance(_0023_003DzopRx0_MBcTQs._0023_003DzY5A0be7u239W().Clone() as Surface, _0023_003DzopRx0_MBcTQs._0023_003DzMkvdrYGZ_a_9().Clone() as Surface, allowOutside: false, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D, out var distance) && _0023_003DzopRx0_MBcTQs._0023_003DzY5A0be7u239W().Trimming.IsPointInside(new Point2D(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D)) && _0023_003DzopRx0_MBcTQs._0023_003DzMkvdrYGZ_a_9().Trimming.IsPointInside(new Point2D(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D)))
				{
					Point3D point3D = _0023_003DzopRx0_MBcTQs._0023_003DzY5A0be7u239W().PointAt(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D);
					Point3D point3D2 = _0023_003DzopRx0_MBcTQs._0023_003DzMkvdrYGZ_a_9().PointAt(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D);
					_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzwzHUHq4_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D);
					_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz5UWQnIQ_003D = new PointNormalUv(point3D2.X, point3D2.Y, point3D2.Z, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D);
					_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzz_0024CeF8LN7AMy(distance * distance);
					_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				}
			}
		}

		private sealed class _0023_003DzeUlnIR2nH9kxjFvfCiO5RAc_003D
		{
			public int _0023_003Dz4CY5xohrHpS5;

			public _0023_003Dz_0024HJN1ByiTN5X[] _0023_003Dzu5kSRZe5IOmZ;

			public ICurve[][] _0023_003DzfxOvlojPGZ4N1QPmuw_003D_003D;

			public Surface _0023_003Dzt_vaKiHI6Zn0;

			public _0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;

			internal void _0023_003DzLLx_0024bFJOLilSL9EwJA_003D_003D(int _0023_003Dz437_00244ak_003D)
			{
				int num = _0023_003Dz437_00244ak_003D + _0023_003Dz4CY5xohrHpS5;
				_0023_003Dz_0024HJN1ByiTN5X _0023_003Dz_0024HJN1ByiTN5X2 = _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				ICurve nurbsForm = _0023_003DzfxOvlojPGZ4N1QPmuw_003D_003D[_0023_003Dz_0024HJN1ByiTN5X2._0023_003Dzn2AChhNvYV_0024X][_0023_003Dz_0024HJN1ByiTN5X2._0023_003Dz6uDQbFls3_0024n5].GetNurbsForm();
				if (Surface.MinimumDistance(nurbsForm.Clone() as Curve, _0023_003Dzt_vaKiHI6Zn0.Clone() as Surface, allowOutside: false, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzWWgGxds_003D, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, ref _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D, out var _))
				{
					if (_0023_003Dzt_vaKiHI6Zn0.Trimming.IsPointInside(new Point2D(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D)))
					{
						Point3D point3D = _0023_003Dzt_vaKiHI6Zn0.PointAt(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D);
						Point3D point3D2 = nurbsForm.PointAt(_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzWWgGxds_003D);
						_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzwzHUHq4_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D);
						_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz5UWQnIQ_003D = new PointNormalUv(point3D2.X, point3D2.Y, point3D2.Z, _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzWWgGxds_003D, double.NaN);
						_0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzz_0024CeF8LN7AMy(Point3D.DistanceSquared(point3D, point3D2));
						_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = _0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
					}
				}
				else
				{
					_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = null;
				}
			}
		}

		private sealed class _0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D
		{
			public double _0023_003DzsVw1i9LkTBtX;

			internal bool _0023_003Dzy2gKO_R7jy7dZQ_cOQ_003D_003D(_0023_003DzI5MiWyE_003D _0023_003DzuwH5j5s_003D)
			{
				return _0023_003DzuwH5j5s_003D._0023_003DzzSdvRJ4yZZNL() == _0023_003DzsVw1i9LkTBtX;
			}
		}

		private Surface _0023_003DzBLJ0D13nLukwVrxWO2alOx0_003D;

		private Surface _0023_003DzFXtnlJt09IZS2imcK5CzzGE_003D;

		private int _0023_003DznxI1hTCuyRYWOYIzmHt3sA0_003D;

		private int _0023_003DzFOsrUUiK5aZg_0024fnF9EIDEfo_003D;

		private _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzmImYbCrJsAIetuCUOg_003D_003D;

		private _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzcugdMLFxmusQvYXuHg_003D_003D;

		private Surface _0023_003Dznglta8uBxexg8IdK5w_003D_003D;

		private Surface _0023_003Dz1kw4r2gze1YR1iJMBA_003D_003D;

		private ICurve _0023_003Dzi873der3K5oH;

		private ICurve _0023_003DzzZjTY9c2yAB4;

		private readonly bool _0023_003DzsZloMVGK8ZkO;

		private readonly bool _0023_003DzOek1KW781Sec;

		private Dictionary<int, Surface> _0023_003Dzy_cNf3LwMHg7p79N_00241jwviunMM7i;

		private double _0023_003DzAzEDeemPbj_0024RQX4sLq3xej8_003D;

		private Size3D _0023_003DziRmSnf8_003D;

		private Size3D _0023_003DzQLzlP_00240_003D;

		public _0023_003Dzq03E8WAcFKhl(int _0023_003DzZSMvk48_003D, int _0023_003DzAxuPLmU_003D, _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[] _0023_003DzL_BXzuA_003D, _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[] _0023_003DzW0adwBQ_003D, ICurve[][] _0023_003Dz_VcMTQo_003D, ICurve[][] _0023_003DzYPH49Nw_003D, bool _0023_003DzHcI4PoYGY7Ce, bool _0023_003Dz4ErAcXJzBnRY)
		{
			_0023_003DzK4XK9a6dDJTR(_0023_003DzZSMvk48_003D);
			_0023_003DzU1cuSDaLpYum(_0023_003DzAxuPLmU_003D);
			_0023_003DzN5XUGmTwNxDS(_0023_003DzL_BXzuA_003D[_0023_003Dzd6Zj9Sy9x0fQ()]);
			_0023_003DzcnK2heYdw5oA(_0023_003DzW0adwBQ_003D[_0023_003DznIV4h3VT9mbQ()]);
			_0023_003DzsZloMVGK8ZkO = _0023_003DzHcI4PoYGY7Ce;
			_0023_003DzOek1KW781Sec = _0023_003Dz4ErAcXJzBnRY;
			if (_0023_003DzsZloMVGK8ZkO)
			{
				_0023_003DzMOWnlLAMAqGQ(_0023_003DzupniDK2icQa7().GetGeneric());
				_0023_003DzFoHrptTD9cPX(_0023_003DzupniDK2icQa7().EntityData as Surface);
				_0023_003DzT0ugZ7H95sDb(_0023_003DzG2gBauy43SUi(), _0023_003DzY5A0be7u239W());
			}
			else
			{
				_0023_003Dzi873der3K5oH = _0023_003Dz_VcMTQo_003D[0][0];
			}
			if (_0023_003DzOek1KW781Sec)
			{
				_0023_003DzQcy7akr0v17g(_0023_003DzecV2YrL4IIEU().GetGeneric());
				_0023_003Dzh79Y0H4q2ENQ(_0023_003DzecV2YrL4IIEU().EntityData as Surface);
				_0023_003DzT0ugZ7H95sDb(_0023_003DzptrwmCjJ5DJX(), _0023_003DzMkvdrYGZ_a_9());
			}
			else
			{
				_0023_003DzzZjTY9c2yAB4 = _0023_003DzYPH49Nw_003D[0][0];
			}
			_0023_003Dz0WW3xxQq6a7WT67WFQ_003D_003D(new Dictionary<int, Surface>(2));
		}

		private Surface _0023_003DzY5A0be7u239W()
		{
			return _0023_003DzBLJ0D13nLukwVrxWO2alOx0_003D;
		}

		private void _0023_003DzFoHrptTD9cPX(Surface _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzBLJ0D13nLukwVrxWO2alOx0_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private Surface _0023_003DzMkvdrYGZ_a_9()
		{
			return _0023_003DzFXtnlJt09IZS2imcK5CzzGE_003D;
		}

		private void _0023_003Dzh79Y0H4q2ENQ(Surface _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzFXtnlJt09IZS2imcK5CzzGE_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private int _0023_003Dzd6Zj9Sy9x0fQ()
		{
			return _0023_003DznxI1hTCuyRYWOYIzmHt3sA0_003D;
		}

		private void _0023_003DzK4XK9a6dDJTR(int _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DznxI1hTCuyRYWOYIzmHt3sA0_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private int _0023_003DznIV4h3VT9mbQ()
		{
			return _0023_003DzFOsrUUiK5aZg_0024fnF9EIDEfo_003D;
		}

		private void _0023_003DzU1cuSDaLpYum(int _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzFOsrUUiK5aZg_0024fnF9EIDEfo_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzupniDK2icQa7()
		{
			return _0023_003DzmImYbCrJsAIetuCUOg_003D_003D;
		}

		private void _0023_003DzN5XUGmTwNxDS(_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzmImYbCrJsAIetuCUOg_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzecV2YrL4IIEU()
		{
			return _0023_003DzcugdMLFxmusQvYXuHg_003D_003D;
		}

		private void _0023_003DzcnK2heYdw5oA(_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzcugdMLFxmusQvYXuHg_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private Surface _0023_003DzG2gBauy43SUi()
		{
			return _0023_003Dznglta8uBxexg8IdK5w_003D_003D;
		}

		private void _0023_003DzMOWnlLAMAqGQ(Surface _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dznglta8uBxexg8IdK5w_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private Surface _0023_003DzptrwmCjJ5DJX()
		{
			return _0023_003Dz1kw4r2gze1YR1iJMBA_003D_003D;
		}

		private void _0023_003DzQcy7akr0v17g(Surface _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz1kw4r2gze1YR1iJMBA_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private Dictionary<int, Surface> _0023_003Dzdo4hrfm6Vp4YCtMIhA_003D_003D()
		{
			return _0023_003Dzy_cNf3LwMHg7p79N_00241jwviunMM7i;
		}

		private void _0023_003Dz0WW3xxQq6a7WT67WFQ_003D_003D(Dictionary<int, Surface> _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dzy_cNf3LwMHg7p79N_00241jwviunMM7i = _0023_003DzPzO_0024GUk_003D;
		}

		public double _0023_003DzVNOVRN7mF1xbxNA5DQ_003D_003D()
		{
			return _0023_003DzAzEDeemPbj_0024RQX4sLq3xej8_003D;
		}

		private void _0023_003DzZpClo6xq3WTwSppCuw_003D_003D(double _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzAzEDeemPbj_0024RQX4sLq3xej8_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private void _0023_003DzT0ugZ7H95sDb(Surface _0023_003DzSStqbLA_003D, Surface _0023_003Dz4wZe_0024Xg_003D)
		{
			if (_0023_003DzSStqbLA_003D.Trimming == null)
			{
				_0023_003DzSStqbLA_003D.Trimming = ((_0023_003Dz4wZe_0024Xg_003D.Trimming == null) ? _0023_003DzSStqbLA_003D._0023_003Dzrkte6ryoSSy1((Surface._0023_003DzQAHUODcCipZscKjjuw_003D_003D)0) : _0023_003Dz4wZe_0024Xg_003D.Trimming);
			}
		}

		public void _0023_003DztuEjAT2fbtI4lc7vqA_003D_003D()
		{
			_0023_003DzdtA46wQ_003D(_0023_003DzsZloMVGK8ZkO, _0023_003DzG2gBauy43SUi(), _0023_003Dzi873der3K5oH, out var _0023_003DzDPcjoBJLcqli, out var _0023_003Dz_0024N_0024yKptW9BoC);
			_0023_003DzdtA46wQ_003D(_0023_003DzOek1KW781Sec, _0023_003DzptrwmCjJ5DJX(), _0023_003DzzZjTY9c2yAB4, out var _0023_003DzDPcjoBJLcqli2, out var _0023_003Dz_0024N_0024yKptW9BoC2);
			_0023_003DziRmSnf8_003D = new Size3D(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
			_0023_003DzQLzlP_00240_003D = new Size3D(_0023_003DzDPcjoBJLcqli2, _0023_003Dz_0024N_0024yKptW9BoC2);
			double num = Math.Max(Math.Max(_0023_003Dz_0024N_0024yKptW9BoC.X, _0023_003Dz_0024N_0024yKptW9BoC2.X) - Math.Min(_0023_003DzDPcjoBJLcqli.X, _0023_003DzDPcjoBJLcqli2.X) - _0023_003DziRmSnf8_003D.X - _0023_003DzQLzlP_00240_003D.X, 0.0);
			double num2 = Math.Max(Math.Max(_0023_003Dz_0024N_0024yKptW9BoC.Y, _0023_003Dz_0024N_0024yKptW9BoC2.Y) - Math.Min(_0023_003DzDPcjoBJLcqli.Y, _0023_003DzDPcjoBJLcqli2.Y) - _0023_003DziRmSnf8_003D.Y - _0023_003DzQLzlP_00240_003D.Y, 0.0);
			double num3 = Math.Max(Math.Max(_0023_003Dz_0024N_0024yKptW9BoC.Z, _0023_003Dz_0024N_0024yKptW9BoC2.Z) - Math.Min(_0023_003DzDPcjoBJLcqli.Z, _0023_003DzDPcjoBJLcqli2.Z) - _0023_003DziRmSnf8_003D.Z - _0023_003DzQLzlP_00240_003D.Z, 0.0);
			_0023_003DzZpClo6xq3WTwSppCuw_003D_003D(num * num + num2 * num2 + num3 * num3);
		}

		private void _0023_003DzdtA46wQ_003D(bool _0023_003DzwqLDjLUAtIIs, Surface _0023_003DzSStqbLA_003D, ICurve _0023_003DzEZ_0024X0WU_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
		{
			if (_0023_003DzwqLDjLUAtIIs)
			{
				_0023_003DzSStqbLA_003D.ControlBoundingBox(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
			}
			else
			{
				_0023_003DzEZ_0024X0WU_003D.GetApproximatedBoundingBox(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
			}
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996903), _0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DznIV4h3VT9mbQ(), _0023_003DzVNOVRN7mF1xbxNA5DQ_003D_003D().ToString());
		}

		private void _0023_003Dzned77_y6zgU23q3X0Q_003D_003D(int _0023_003DzPiQ20TI_WI4i, _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzKBncRpw_003D, PointNormalUv[] _0023_003DzxrWdajaRb_0024n3, Region _0023_003DzSMEAtjbL_0024xnQju99hA_003D_003D)
		{
			_0023_003Dzdo4hrfm6Vp4YCtMIhA_003D_003D()[_0023_003DzPiQ20TI_WI4i] = _0023_003DzKBncRpw_003D;
			if (_0023_003DzxrWdajaRb_0024n3[_0023_003DzPiQ20TI_WI4i] == null)
			{
				Interval interval = _0023_003DzKBncRpw_003D.DomainU;
				Interval interval2 = _0023_003DzKBncRpw_003D.DomainV;
				if (_0023_003DzSMEAtjbL_0024xnQju99hA_003D_003D != null)
				{
					_0023_003DzSMEAtjbL_0024xnQju99hA_003D_003D.ContourList[0].GetApproximatedBoundingBox(out var boxMin, out var boxMax);
					interval = new Interval(Math.Max(_0023_003DzKBncRpw_003D.DomainU.Low, boxMin.X), Math.Min(_0023_003DzKBncRpw_003D.DomainU.High, boxMax.X));
					interval2 = new Interval(Math.Max(_0023_003DzKBncRpw_003D.DomainV.Low, boxMin.Y), Math.Min(_0023_003DzKBncRpw_003D.DomainV.High, boxMax.Y));
				}
				double mid = interval.Mid;
				double mid2 = interval2.Mid;
				Point3D point3D = _0023_003DzKBncRpw_003D.PointAt(mid, mid2);
				_0023_003DzxrWdajaRb_0024n3[_0023_003DzPiQ20TI_WI4i] = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, mid, mid2);
			}
		}

		private void _0023_003Dz06n9PkUun1HUgE6byQ_003D_003D(int _0023_003DzPiQ20TI_WI4i, ICurve[][] _0023_003DzTj1oJWREOpXS, PointNormalUv[][][] _0023_003DzhsLTc4Ll03fL)
		{
			if (_0023_003DzhsLTc4Ll03fL[_0023_003DzPiQ20TI_WI4i] != null)
			{
				return;
			}
			_0023_003DzhsLTc4Ll03fL[_0023_003DzPiQ20TI_WI4i] = new PointNormalUv[_0023_003DzTj1oJWREOpXS[_0023_003DzPiQ20TI_WI4i].Length][];
			for (int i = 0; i < _0023_003DzTj1oJWREOpXS[_0023_003DzPiQ20TI_WI4i].Length; i++)
			{
				Curve nurbsForm = _0023_003DzTj1oJWREOpXS[_0023_003DzPiQ20TI_WI4i][i].GetNurbsForm();
				Point3D[] array = _0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX._0023_003DzvKjleDzBEPeHTOWneerYzYE_003D(nurbsForm, 0.0, Math.PI / 3.0);
				PointNormalUv[] array2 = new PointNormalUv[array.Length - 1];
				for (int j = 1; j < array.Length; j++)
				{
					double u = (((PointTangentU)array[j - 1]).U + ((PointTangentU)array[j]).U) / 2.0;
					Point3D point3D = nurbsForm.PointAt(u);
					array2[j - 1] = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, u, double.NaN);
				}
				_0023_003DzhsLTc4Ll03fL[_0023_003DzPiQ20TI_WI4i][i] = array2;
			}
		}

		private void _0023_003DzPozHq98wlQ4E(Surface _0023_003Dz9KmenBCrwEbu, int _0023_003DzbnY3p4zUi6xQ, _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D _0023_003DzI3yADFBjNaFY, Region _0023_003DzD6Xozp02B6si, ICurve[][] _0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci)
		{
			if (_0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ] != null)
			{
				return;
			}
			if (_0023_003Dz9KmenBCrwEbu.IsTrimmed)
			{
				List<ICurve> list = new List<ICurve>(_0023_003DzD6Xozp02B6si.ContourList.Count);
				for (int i = 0; i < _0023_003DzD6Xozp02B6si.ContourList.Count; i++)
				{
					ICurve curve = _0023_003DzD6Xozp02B6si.ContourList[i];
					list.AddRange(curve.GetIndividualCurves().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzUrxrYx4DerSMe6193yOYb5M_003D));
				}
				_0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ] = list.ToArray();
			}
			else
			{
				_0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ] = new ICurve[4];
				_0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ][0] = _0023_003DzI3yADFBjNaFY.IsocurveU(_0023_003DzI3yADFBjNaFY.DomainV.Min);
				_0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ][1] = _0023_003DzI3yADFBjNaFY.IsocurveU(_0023_003DzI3yADFBjNaFY.DomainV.Max);
				_0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ][2] = _0023_003DzI3yADFBjNaFY.IsocurveV(_0023_003DzI3yADFBjNaFY.DomainU.Min);
				_0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ][3] = _0023_003DzI3yADFBjNaFY.IsocurveV(_0023_003DzI3yADFBjNaFY.DomainU.Max);
			}
		}

		public _0023_003DzI5MiWyE_003D _0023_003DzObuEcWw_003D(PointNormalUv[] _0023_003DzPd_0024YIDuPT7q4, PointNormalUv[] _0023_003Dz2TRgmLFkSVzn, PointNormalUv[][][] _0023_003DzeuK9F1zJsEYi, PointNormalUv[][][] _0023_003DzdLG7B7NAsnOU, ICurve[][] _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi, ICurve[][] _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ)
		{
			_0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D _0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D2 = new _0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D();
			if (_0023_003DzsZloMVGK8ZkO)
			{
				_0023_003DzPozHq98wlQ4E(_0023_003DzY5A0be7u239W(), _0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DzupniDK2icQa7(), _0023_003DzY5A0be7u239W().Trimming, _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi);
				_0023_003Dzned77_y6zgU23q3X0Q_003D_003D(_0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DzupniDK2icQa7(), _0023_003DzPd_0024YIDuPT7q4, _0023_003DzY5A0be7u239W().Trimming);
			}
			if (_0023_003DzOek1KW781Sec)
			{
				_0023_003DzPozHq98wlQ4E(_0023_003DzMkvdrYGZ_a_9(), _0023_003DznIV4h3VT9mbQ(), _0023_003DzecV2YrL4IIEU(), _0023_003DzMkvdrYGZ_a_9().Trimming, _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ);
				_0023_003Dzned77_y6zgU23q3X0Q_003D_003D(_0023_003DznIV4h3VT9mbQ(), _0023_003DzecV2YrL4IIEU(), _0023_003Dz2TRgmLFkSVzn, _0023_003DzMkvdrYGZ_a_9().Trimming);
			}
			_0023_003Dz06n9PkUun1HUgE6byQ_003D_003D(_0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi, _0023_003DzeuK9F1zJsEYi);
			_0023_003Dz06n9PkUun1HUgE6byQ_003D_003D(_0023_003DznIV4h3VT9mbQ(), _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ, _0023_003DzdLG7B7NAsnOU);
			int _0023_003DzVcCdollQFFgHMHOHXg_003D_003D = 10;
			_0023_003DzCQRN6dAk9sLt[] array = new _0023_003DzCQRN6dAk9sLt[0];
			_0023_003Dz_0024HJN1ByiTN5X[] array2 = new _0023_003Dz_0024HJN1ByiTN5X[0];
			_0023_003Dz_0024HJN1ByiTN5X[] array3 = new _0023_003Dz_0024HJN1ByiTN5X[0];
			if (_0023_003DzsZloMVGK8ZkO && _0023_003DzOek1KW781Sec)
			{
				array = new _0023_003DzCQRN6dAk9sLt[1]
				{
					new _0023_003DzCQRN6dAk9sLt(_0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DznIV4h3VT9mbQ(), _0023_003DzPd_0024YIDuPT7q4[_0023_003Dzd6Zj9Sy9x0fQ()], _0023_003Dz2TRgmLFkSVzn[_0023_003DznIV4h3VT9mbQ()])
				};
			}
			if (_0023_003DzsZloMVGK8ZkO)
			{
				array2 = _0023_003DzGzdO8YYDKfW2mfKNiw_003D_003D(_0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DznIV4h3VT9mbQ(), _0023_003DzPd_0024YIDuPT7q4, _0023_003DzdLG7B7NAsnOU, _0023_003DzVcCdollQFFgHMHOHXg_003D_003D);
			}
			if (_0023_003DzOek1KW781Sec)
			{
				array3 = _0023_003DzGzdO8YYDKfW2mfKNiw_003D_003D(_0023_003DznIV4h3VT9mbQ(), _0023_003Dzd6Zj9Sy9x0fQ(), _0023_003Dz2TRgmLFkSVzn, _0023_003DzeuK9F1zJsEYi, _0023_003DzVcCdollQFFgHMHOHXg_003D_003D);
			}
			_0023_003DzL2QA5Joe2J8m[] array4 = _0023_003DzGzdO8YYDKfW2mfKNiw_003D_003D(_0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DznIV4h3VT9mbQ(), _0023_003DzeuK9F1zJsEYi, _0023_003DzdLG7B7NAsnOU, _0023_003DzVcCdollQFFgHMHOHXg_003D_003D);
			List<Point3D> list = _0023_003DzPU8qr8vYSdWE(_0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi, _0023_003DzOek1KW781Sec, _0023_003DziRmSnf8_003D.Diagonal, _0023_003Dzd6Zj9Sy9x0fQ());
			List<Point3D> list2 = _0023_003DzPU8qr8vYSdWE(_0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ, _0023_003DzsZloMVGK8ZkO, _0023_003DzQLzlP_00240_003D.Diagonal, _0023_003DznIV4h3VT9mbQ());
			int num = 1 + list.Count + list2.Count;
			_0023_003DzI5MiWyE_003D[] array5 = new _0023_003DzI5MiWyE_003D[array.Length + array2.Length + array3.Length + array4.Length + num];
			int _0023_003Dz5Ex_zZ0_003D = 0;
			_0023_003DzhqmMiyg_0024U6sJ(array5, array, ref _0023_003Dz5Ex_zZ0_003D);
			_0023_003DzhqmMiyg_0024U6sJ(array5, array2, _0023_003DzY5A0be7u239W(), _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ, ref _0023_003Dz5Ex_zZ0_003D);
			_0023_003DzhqmMiyg_0024U6sJ(array5, array3, _0023_003DzMkvdrYGZ_a_9(), _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi, ref _0023_003Dz5Ex_zZ0_003D);
			_0023_003DzhqmMiyg_0024U6sJ(array5, array4, _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi, _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ, ref _0023_003Dz5Ex_zZ0_003D);
			_0023_003DzB_0024VJ94E2RvjqwlWgP0tJlr4_003D(array5, _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi, _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ, list, list2, ref _0023_003Dz5Ex_zZ0_003D);
			_0023_003DzI5MiWyE_003D[] array6 = array5.Where((_0023_003DzI5MiWyE_003D _0023_003DzuwH5j5s_003D) => _0023_003DzuwH5j5s_003D != null).ToArray();
			_0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D2._0023_003DzsVw1i9LkTBtX = ((array6.Length == 0) ? double.NaN : array6.Min((_0023_003DzI5MiWyE_003D _0023_003DzuwH5j5s_003D) => _0023_003DzuwH5j5s_003D._0023_003DzzSdvRJ4yZZNL()));
			return array6.FirstOrDefault(_0023_003Dzf4o_8L5zdSxRaajyYOnfP1c_003D2._0023_003Dzy2gKO_R7jy7dZQ_cOQ_003D_003D);
		}

		private List<Point3D> _0023_003DzPU8qr8vYSdWE(ICurve[][] _0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci, bool _0023_003DzwqLDjLUAtIIs, double _0023_003Dz14lzA48_003D, int _0023_003DzbnY3p4zUi6xQ)
		{
			if (_0023_003DzwqLDjLUAtIIs)
			{
				ICurve[] array = _0023_003DzybYPzqvzY1rrqBwq6Gluh4n1GYci[_0023_003DzbnY3p4zUi6xQ];
				if (array == null || array.Length == 0)
				{
					return new List<Point3D>();
				}
				int num = array.Length;
				List<Point3D> list = new List<Point3D>(num * 2);
				for (int i = 0; i < num; i++)
				{
					Utility._0023_003DzbIDY9BOTPqfc(array[i].StartPoint, list, _0023_003Dz14lzA48_003D);
					Utility._0023_003DzbIDY9BOTPqfc(array[i].EndPoint, list, _0023_003Dz14lzA48_003D);
				}
				return list;
			}
			return new List<Point3D>();
		}

		private void _0023_003Dz_BA5HuwC1r1V_Qzzdd7P2kaYrLmU(_0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D, Point3D[] _0023_003Dzm9bQX1ehzIK5, Surface[] _0023_003Dzt_vaKiHI6Zn0, int _0023_003Dz5Ex_zZ0_003D)
		{
			_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2 = new _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D();
			_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzt_vaKiHI6Zn0 = _0023_003Dzt_vaKiHI6Zn0;
			_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzm9bQX1ehzIK5 = _0023_003Dzm9bQX1ehzIK5;
			_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dz5Ex_zZ0_003D = _0023_003Dz5Ex_zZ0_003D;
			_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D = _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;
			_0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzopRx0_MBcTQs = this;
			Parallel.For(0, _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003Dzm9bQX1ehzIK5.Length, _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D2._0023_003DzmoBj5ZqS3WnPGtFYGfR__gocbAJyN3QH9tRK2l4_003D);
		}

		private void _0023_003DzB_0024VJ94E2RvjqwlWgP0tJlr4_003D(_0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D, ICurve[][] _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi, ICurve[][] _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ, List<Point3D> _0023_003Dzdr2IDjgg8MRY, List<Point3D> _0023_003DzhmuR6F7fj9hZ, ref int _0023_003Dz5Ex_zZ0_003D)
		{
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2 = new _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D();
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzopRx0_MBcTQs = this;
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzxJBvE8ms39_0024N = _0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi[_0023_003Dzd6Zj9Sy9x0fQ()];
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzX4KJCrvCv8tc = _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ[_0023_003DznIV4h3VT9mbQ()];
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dz3pKCiioRSr_00242sJfqFk7dY7s_003D = 8;
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzSCLYcFo5XJr9 = new _0023_003DzI5MiWyE_003D[_0023_003DzaDARBOcxk0_0024m92550WhBt2DA6UMi[_0023_003Dzd6Zj9Sy9x0fQ()].Length * _0023_003Dzbfhm8tWgOSlHGJvEZz_5PbMgLUzJ[_0023_003DznIV4h3VT9mbQ()].Length * _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dz3pKCiioRSr_00242sJfqFk7dY7s_003D];
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dza7EwQmUyHpuW = new int[_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzxJBvE8ms39_0024N.Length * _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzX4KJCrvCv8tc.Length][];
			Parallel.For(0, _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzxJBvE8ms39_0024N.Length * _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzX4KJCrvCv8tc.Length, _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzGgfQV7bzRcNs0q2fsqug4LZmEx_qKABTjA_003D_003D);
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzOWjUf9o_003D = ((IEnumerable<_0023_003DzI5MiWyE_003D>)_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzSCLYcFo5XJr9).Min((Func<_0023_003DzI5MiWyE_003D, double>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzNWjpNKion5vf4F8DX3qPFw0A2Fy1m4rxbQ_003D_003D);
			_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[_0023_003Dz5Ex_zZ0_003D] = _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzSCLYcFo5XJr9.FirstOrDefault(_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzIoW8LiPxXDac93dJrjhNZz7sUfg0wttg0w_003D_003D);
			_0023_003Dz5Ex_zZ0_003D++;
			Point3D[] array = new Point3D[_0023_003Dzdr2IDjgg8MRY.Count + _0023_003DzhmuR6F7fj9hZ.Count];
			Surface[] array2 = new Surface[array.Length];
			int num = 0;
			int num2 = 0;
			while (num2 < _0023_003Dzdr2IDjgg8MRY.Count)
			{
				array[num] = _0023_003Dzdr2IDjgg8MRY[num2];
				array2[num] = _0023_003DzMkvdrYGZ_a_9();
				num2++;
				num++;
			}
			int num3 = 0;
			while (num3 < _0023_003DzhmuR6F7fj9hZ.Count)
			{
				array[num] = _0023_003DzhmuR6F7fj9hZ[num3];
				array2[num] = _0023_003DzY5A0be7u239W();
				num3++;
				num++;
			}
			_0023_003Dz_BA5HuwC1r1V_Qzzdd7P2kaYrLmU(_0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D, array, array2, _0023_003Dz5Ex_zZ0_003D);
		}

		private void _0023_003DzhqmMiyg_0024U6sJ(_0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D, _0023_003DzCQRN6dAk9sLt[] _0023_003DzSCLYcFo5XJr9, ref int _0023_003Dz5Ex_zZ0_003D)
		{
			_0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D CS_0024_003C_003E8__locals33 = new _0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D();
			CS_0024_003C_003E8__locals33._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D = _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;
			CS_0024_003C_003E8__locals33._0023_003DzopRx0_MBcTQs = this;
			if (_0023_003DzSCLYcFo5XJr9.Length == 0)
			{
				return;
			}
			CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ = _0023_003DzSCLYcFo5XJr9.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzDXyabHxa8LZIJLueidBQkU0_003D).ToArray();
			CS_0024_003C_003E8__locals33._0023_003Dz4CY5xohrHpS5 = _0023_003Dz5Ex_zZ0_003D;
			Parallel.For(0, _0023_003DzSCLYcFo5XJr9.Length, delegate(int _0023_003Dz437_00244ak_003D)
			{
				int num = _0023_003Dz437_00244ak_003D + CS_0024_003C_003E8__locals33._0023_003Dz4CY5xohrHpS5;
				CS_0024_003C_003E8__locals33._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = null;
				if (Surface.MinimumDistance(CS_0024_003C_003E8__locals33._0023_003DzopRx0_MBcTQs._0023_003DzY5A0be7u239W().Clone() as Surface, CS_0024_003C_003E8__locals33._0023_003DzopRx0_MBcTQs._0023_003DzMkvdrYGZ_a_9().Clone() as Surface, allowOutside: false, ref CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, ref CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D, ref CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, ref CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D, out var distance) && CS_0024_003C_003E8__locals33._0023_003DzopRx0_MBcTQs._0023_003DzY5A0be7u239W().Trimming.IsPointInside(new Point2D(CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D)) && CS_0024_003C_003E8__locals33._0023_003DzopRx0_MBcTQs._0023_003DzMkvdrYGZ_a_9().Trimming.IsPointInside(new Point2D(CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D)))
				{
					Point3D point3D = CS_0024_003C_003E8__locals33._0023_003DzopRx0_MBcTQs._0023_003DzY5A0be7u239W().PointAt(CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D);
					Point3D point3D2 = CS_0024_003C_003E8__locals33._0023_003DzopRx0_MBcTQs._0023_003DzMkvdrYGZ_a_9().PointAt(CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D);
					CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzwzHUHq4_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz6ND2cc0_003D, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzu0pfCNc_003D);
					CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz5UWQnIQ_003D = new PointNormalUv(point3D2.X, point3D2.Y, point3D2.Z, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzgzzCeHY_003D, CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzoj4236c_003D);
					CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzz_0024CeF8LN7AMy(distance * distance);
					CS_0024_003C_003E8__locals33._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = CS_0024_003C_003E8__locals33._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				}
			});
			_0023_003Dz5Ex_zZ0_003D += _0023_003DzSCLYcFo5XJr9.Length;
		}

		private void _0023_003DzhqmMiyg_0024U6sJ(_0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D, _0023_003Dz_0024HJN1ByiTN5X[] _0023_003DzSCLYcFo5XJr9, Surface _0023_003Dzt_vaKiHI6Zn0, ICurve[][] _0023_003DzfxOvlojPGZ4N1QPmuw_003D_003D, ref int _0023_003Dz5Ex_zZ0_003D)
		{
			_0023_003DzeUlnIR2nH9kxjFvfCiO5RAc_003D CS_0024_003C_003E8__locals28 = new _0023_003DzeUlnIR2nH9kxjFvfCiO5RAc_003D();
			CS_0024_003C_003E8__locals28._0023_003DzfxOvlojPGZ4N1QPmuw_003D_003D = _0023_003DzfxOvlojPGZ4N1QPmuw_003D_003D;
			CS_0024_003C_003E8__locals28._0023_003Dzt_vaKiHI6Zn0 = _0023_003Dzt_vaKiHI6Zn0;
			CS_0024_003C_003E8__locals28._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D = _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;
			if (_0023_003DzSCLYcFo5XJr9.Length == 0)
			{
				return;
			}
			CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ = _0023_003DzSCLYcFo5XJr9.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzImBXQQ5feyDe1R0ywDfSyKk_003D).ToArray();
			CS_0024_003C_003E8__locals28._0023_003Dz4CY5xohrHpS5 = _0023_003Dz5Ex_zZ0_003D;
			Parallel.For(0, _0023_003DzSCLYcFo5XJr9.Length, delegate(int _0023_003Dz437_00244ak_003D)
			{
				int num = _0023_003Dz437_00244ak_003D + CS_0024_003C_003E8__locals28._0023_003Dz4CY5xohrHpS5;
				_0023_003Dz_0024HJN1ByiTN5X _0023_003Dz_0024HJN1ByiTN5X2 = CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				ICurve nurbsForm = CS_0024_003C_003E8__locals28._0023_003DzfxOvlojPGZ4N1QPmuw_003D_003D[_0023_003Dz_0024HJN1ByiTN5X2._0023_003Dzn2AChhNvYV_0024X][_0023_003Dz_0024HJN1ByiTN5X2._0023_003Dz6uDQbFls3_0024n5].GetNurbsForm();
				if (Surface.MinimumDistance(nurbsForm.Clone() as Curve, CS_0024_003C_003E8__locals28._0023_003Dzt_vaKiHI6Zn0.Clone() as Surface, allowOutside: false, ref CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzWWgGxds_003D, ref CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, ref CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D, out var _))
				{
					if (CS_0024_003C_003E8__locals28._0023_003Dzt_vaKiHI6Zn0.Trimming.IsPointInside(new Point2D(CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D)))
					{
						Point3D point3D = CS_0024_003C_003E8__locals28._0023_003Dzt_vaKiHI6Zn0.PointAt(CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D);
						Point3D point3D2 = nurbsForm.PointAt(CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzWWgGxds_003D);
						CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzwzHUHq4_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DziP9fFuA_003D, CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz61IPlm0_003D);
						CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz5UWQnIQ_003D = new PointNormalUv(point3D2.X, point3D2.Y, point3D2.Z, CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzWWgGxds_003D, double.NaN);
						CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzz_0024CeF8LN7AMy(Point3D.DistanceSquared(point3D, point3D2));
						CS_0024_003C_003E8__locals28._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = CS_0024_003C_003E8__locals28._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
					}
				}
				else
				{
					CS_0024_003C_003E8__locals28._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = null;
				}
			});
			_0023_003Dz5Ex_zZ0_003D += _0023_003DzSCLYcFo5XJr9.Length;
		}

		private void _0023_003DzhqmMiyg_0024U6sJ(_0023_003DzI5MiWyE_003D[] _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D, _0023_003DzL2QA5Joe2J8m[] _0023_003DzSCLYcFo5XJr9, ICurve[][] _0023_003Dz98kwboInvyL0nCy_0024LA_003D_003D, ICurve[][] _0023_003DzxRsp0K3G0iTb94YFkw_003D_003D, ref int _0023_003Dz5Ex_zZ0_003D)
		{
			_0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D CS_0024_003C_003E8__locals21 = new _0023_003DzKq2KbiEkaF73TYJqbghCPQk_003D();
			CS_0024_003C_003E8__locals21._0023_003Dz98kwboInvyL0nCy_0024LA_003D_003D = _0023_003Dz98kwboInvyL0nCy_0024LA_003D_003D;
			CS_0024_003C_003E8__locals21._0023_003DzxRsp0K3G0iTb94YFkw_003D_003D = _0023_003DzxRsp0K3G0iTb94YFkw_003D_003D;
			CS_0024_003C_003E8__locals21._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D = _0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D;
			if (_0023_003DzSCLYcFo5XJr9.Length == 0)
			{
				return;
			}
			CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ = _0023_003DzSCLYcFo5XJr9.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzw_AEGtqBsO68QQldH3Bp3E0_003D).ToArray();
			CS_0024_003C_003E8__locals21._0023_003Dz4CY5xohrHpS5 = _0023_003Dz5Ex_zZ0_003D;
			Parallel.For(0, _0023_003DzSCLYcFo5XJr9.Length, delegate(int _0023_003Dz437_00244ak_003D)
			{
				int num = _0023_003Dz437_00244ak_003D + CS_0024_003C_003E8__locals21._0023_003Dz4CY5xohrHpS5;
				_0023_003DzL2QA5Joe2J8m _0023_003DzL2QA5Joe2J8m2 = CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				Curve nurbsForm = CS_0024_003C_003E8__locals21._0023_003Dz98kwboInvyL0nCy_0024LA_003D_003D[_0023_003DzL2QA5Joe2J8m2._0023_003DzPTaMMVZeD4_q][_0023_003DzL2QA5Joe2J8m2._0023_003DzQXe2ycFqrkRt].GetNurbsForm();
				Curve nurbsForm2 = CS_0024_003C_003E8__locals21._0023_003DzxRsp0K3G0iTb94YFkw_003D_003D[_0023_003DzL2QA5Joe2J8m2._0023_003DzvmlSRlsCugW7][_0023_003DzL2QA5Joe2J8m2._0023_003DzvPuEqJ7P3C5d].GetNurbsForm();
				if (Curve.MinimumDistance(nurbsForm.Clone() as Curve, nurbsForm2.Clone() as Curve, allowOutside: false, ref CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzDTx2OHE_003D, ref CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzSMytmtQ_003D, out var distance))
				{
					Point3D point3D = nurbsForm.PointAt(CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzDTx2OHE_003D);
					Point3D point3D2 = nurbsForm2.PointAt(CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzSMytmtQ_003D);
					CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzwzHUHq4_003D = new PointNormalUv(point3D.X, point3D.Y, point3D.Z, CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzDTx2OHE_003D, double.NaN);
					CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dz5UWQnIQ_003D = new PointNormalUv(point3D2.X, point3D2.Y, point3D2.Z, CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003DzSMytmtQ_003D, double.NaN);
					CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D]._0023_003Dzz_0024CeF8LN7AMy(distance * distance);
					CS_0024_003C_003E8__locals21._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = CS_0024_003C_003E8__locals21._0023_003Dzu5kSRZe5IOmZ[_0023_003Dz437_00244ak_003D];
				}
				else
				{
					CS_0024_003C_003E8__locals21._0023_003DzK2TqAJYt4fLL7qkFHQ_003D_003D[num] = null;
				}
			});
			_0023_003Dz5Ex_zZ0_003D += _0023_003DzSCLYcFo5XJr9.Length;
		}

		private _0023_003DzL2QA5Joe2J8m[] _0023_003DzGzdO8YYDKfW2mfKNiw_003D_003D(int _0023_003DzItiq2wKgbn_00249, int _0023_003DzJp4xQgyZy3mQ, PointNormalUv[][][] _0023_003DzeuK9F1zJsEYi, PointNormalUv[][][] _0023_003DzdLG7B7NAsnOU, int _0023_003DzVcCdollQFFgHMHOHXg_003D_003D)
		{
			List<_0023_003DzL2QA5Joe2J8m> list = new List<_0023_003DzL2QA5Joe2J8m>();
			PointNormalUv[][] array = _0023_003DzeuK9F1zJsEYi[_0023_003DzItiq2wKgbn_00249];
			PointNormalUv[][] array2 = _0023_003DzdLG7B7NAsnOU[_0023_003DzJp4xQgyZy3mQ];
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array2.Length; j++)
				{
					for (int k = 0; k < array[i].Length; k++)
					{
						for (int l = 0; l < array2[j].Length; l++)
						{
							list.Add(new _0023_003DzL2QA5Joe2J8m(_0023_003DzItiq2wKgbn_00249, _0023_003DzJp4xQgyZy3mQ, _0023_003Dzd6Zj9Sy9x0fQ(), _0023_003DznIV4h3VT9mbQ(), i, j, array[i][k], array2[j][l]));
						}
					}
				}
			}
			Parallel.ForEach(list, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzT0u5HJ9eP03TduLyBt_CGWtY2XIg);
			_0023_003DzL2QA5Joe2J8m[] array3 = list.ToArray();
			Array.Sort(array3, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzCv12b3HQQVB8tBo3R6ABPRjTrONW);
			return array3.Take(_0023_003DzVcCdollQFFgHMHOHXg_003D_003D).ToArray();
		}

		private _0023_003Dz_0024HJN1ByiTN5X[] _0023_003DzGzdO8YYDKfW2mfKNiw_003D_003D(int _0023_003DzbnY3p4zUi6xQ, int _0023_003Dzw7MBMaBHrOWE, PointNormalUv[] _0023_003DzxrWdajaRb_0024n3, PointNormalUv[][][] _0023_003Dz_4ecOKDqSXMG, int _0023_003DzVcCdollQFFgHMHOHXg_003D_003D)
		{
			_ = _0023_003Dz_4ecOKDqSXMG[_0023_003Dzw7MBMaBHrOWE];
			int num = 0;
			PointNormalUv[][] array = _0023_003Dz_4ecOKDqSXMG[_0023_003Dzw7MBMaBHrOWE];
			foreach (PointNormalUv[] array2 in array)
			{
				num += array2.Length;
			}
			_0023_003Dz_0024HJN1ByiTN5X[] array3 = new _0023_003Dz_0024HJN1ByiTN5X[num];
			int num2 = 0;
			for (int j = 0; j < _0023_003Dz_4ecOKDqSXMG[_0023_003Dzw7MBMaBHrOWE].Length; j++)
			{
				int num3 = 0;
				while (num3 < _0023_003Dz_4ecOKDqSXMG[_0023_003Dzw7MBMaBHrOWE][j].Length)
				{
					array3[num2] = new _0023_003Dz_0024HJN1ByiTN5X(_0023_003DzbnY3p4zUi6xQ, _0023_003Dzw7MBMaBHrOWE, _0023_003DzbnY3p4zUi6xQ, j, _0023_003DzxrWdajaRb_0024n3[_0023_003DzbnY3p4zUi6xQ], _0023_003Dz_4ecOKDqSXMG[_0023_003Dzw7MBMaBHrOWE][j][num3]);
					num3++;
					num2++;
				}
			}
			Parallel.ForEach(array3, delegate(_0023_003Dz_0024HJN1ByiTN5X _0023_003Dz5rQzobg_003D)
			{
				_0023_003Dz5rQzobg_003D._0023_003DzIhIYScs0NLnP();
			});
			Array.Sort(array3, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz7sNkwZb42ptyo3mqSKGzHjp01yjj);
			return array3.Take(_0023_003DzVcCdollQFFgHMHOHXg_003D_003D).ToArray();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Brep _0023_003DzhJ0Kgk4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Brep _0023_003DzlP92nO4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Surface[] _0023_003Dz0tEHeuB0qP9j;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Surface[] _0023_003DzF3hGxhIdtSIJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[] _0023_003DzOE0AAeumraCVMCzBSQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[] _0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ICurve[][] _0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ICurve[][] _0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointNormalUv[] _0023_003DzGcMuHaIsUIRMiPrSK_0024FHM_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointNormalUv[] _0023_003DzY1Z9GDSwHnj7RX7A1WLK18s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointNormalUv[][][] _0023_003DzVdMSTv_t71W2KHjS7Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointNormalUv[][][] _0023_003Dzx74ByLO3b_00242zK9xKuQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzKuQT6Co_003D = double.NaN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003Dzk4V07DxKbrHU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzrvvzXC0ysFW6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzZTvPwjreUTFi_00243wXHw_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302993344);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz2J_vjxTBv1r1gpz3xg0QTgA_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996895);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz0hGN2DrhOMH6D1Dsfw_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996607);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz8eqy3JQ_003D _0023_003Dzoe71ZrttfeF_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz6LYSVEJVpLFjFhvnoQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEoWlxu1MwzlHZjCTvw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationToken _0023_003DzEBehidw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzSTrWZN0yjYEq;

	public Segment3D Result
	{
		get
		{
			if (!(_0023_003Dzk4V07DxKbrHU != null))
			{
				return null;
			}
			return new Segment3D(_0023_003Dzk4V07DxKbrHU, _0023_003DzrvvzXC0ysFW6);
		}
	}

	public string InitializingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZTvPwjreUTFi_00243wXHw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZTvPwjreUTFi_00243wXHw_003D_003D = value;
		}
	}

	public string PreprocessingEntitiesText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2J_vjxTBv1r1gpz3xg0QTgA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz2J_vjxTBv1r1gpz3xg0QTgA_003D = value;
		}
	}

	public string ProcessingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0hGN2DrhOMH6D1Dsfw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0hGN2DrhOMH6D1Dsfw_003D_003D = value;
		}
	}

	private MinimumDistance()
	{
		_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzCBXaK_002496NUpX(3, this);
	}

	public MinimumDistance(Entity a, Entity b)
		: this()
	{
		if (a is Brep)
		{
			((Brep)a).Rebuild(0.0, soft: true);
		}
		if (b is Brep)
		{
			((Brep)b).Rebuild(0.0, soft: true);
		}
		Brep brep = a as Brep;
		Surface surface = a as Surface;
		ICurve curve = ((a.GetType() == typeof(Point)) ? null : (a as ICurve));
		Point point = a as Point;
		Brep brep2 = b as Brep;
		Surface surface2 = b as Surface;
		ICurve curve2 = ((b.GetType() == typeof(Point)) ? null : (b as ICurve));
		Point point2 = b as Point;
		_0023_003Dz__0024oxiQweHZtN(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996563), a, brep, surface, curve, point);
		_0023_003Dz__0024oxiQweHZtN(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996571), b, brep2, surface2, curve2, point2);
		_0023_003Dz0IIZ8fPlyAv3(brep, brep2, surface, surface2, curve, curve2, point, point2);
		if (!_0023_003DzSTrWZN0yjYEq)
		{
			_0023_003Dz0IIZ8fPlyAv3(brep2, brep, surface2, surface, curve2, curve, point2, point);
		}
	}

	private void _0023_003Dz__0024oxiQweHZtN(string _0023_003Dz0wko66oIrfDg, Entity _0023_003DzbfrNXYE_003D, Brep _0023_003Dz1v6oPQk_003D, Surface _0023_003DzuwH5j5s_003D, ICurve _0023_003Dzt_m8zV0_003D, Point _0023_003DzB68dg9Q_003D)
	{
		if (_0023_003Dz1v6oPQk_003D == null && _0023_003DzuwH5j5s_003D == null && _0023_003Dzt_m8zV0_003D == null && _0023_003DzB68dg9Q_003D == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974825) + _0023_003Dz0wko66oIrfDg + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + _0023_003DzbfrNXYE_003D.GetType().ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996547));
		}
	}

	private void _0023_003Dz0IIZ8fPlyAv3(Brep _0023_003Dz2wpkEvw_003D, Brep _0023_003DzoqButm0_003D, Surface _0023_003DzgPsOl1A_003D, Surface _0023_003DzD5YCi2M_003D, ICurve _0023_003Dzfm4oGj8_003D, ICurve _0023_003DzCVdPoWM_003D, Point _0023_003DzFj_0024IqDQ_003D, Point _0023_003DzjdeMMkk_003D)
	{
		if (_0023_003Dz2wpkEvw_003D != null && _0023_003DzoqButm0_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003Dz2wpkEvw_003D, _0023_003DzoqButm0_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003Dz2wpkEvw_003D != null && _0023_003DzD5YCi2M_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003Dz2wpkEvw_003D, _0023_003DzD5YCi2M_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003Dz2wpkEvw_003D != null && _0023_003DzCVdPoWM_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003Dz2wpkEvw_003D, _0023_003DzCVdPoWM_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003Dz2wpkEvw_003D != null && _0023_003DzjdeMMkk_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003Dz2wpkEvw_003D, _0023_003DzjdeMMkk_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003DzgPsOl1A_003D != null && _0023_003DzD5YCi2M_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003DzgPsOl1A_003D != null && _0023_003DzCVdPoWM_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003DzgPsOl1A_003D, _0023_003DzCVdPoWM_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003DzgPsOl1A_003D != null && _0023_003DzjdeMMkk_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003DzgPsOl1A_003D, _0023_003DzjdeMMkk_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003Dzfm4oGj8_003D != null && _0023_003DzCVdPoWM_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003Dzfm4oGj8_003D != null && _0023_003DzjdeMMkk_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzjdeMMkk_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
		else if (_0023_003DzFj_0024IqDQ_003D != null && _0023_003DzjdeMMkk_003D != null)
		{
			_0023_003DztGdcVOA_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
			_0023_003DzSTrWZN0yjYEq = true;
		}
	}

	private void _0023_003DztGdcVOA_003D(Brep _0023_003DzE8QrneA_003D, Brep _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)0;
		_0023_003DzhJ0Kgk4_003D = _0023_003DzE8QrneA_003D;
		_0023_003DzlP92nO4_003D = _0023_003DzH9VU2k0_003D;
		_0023_003Dz0tEHeuB0qP9j = _0023_003Dz2pnV7LKEBUZM(_0023_003DzhJ0Kgk4_003D);
		_0023_003DzF3hGxhIdtSIJ = _0023_003Dz2pnV7LKEBUZM(_0023_003DzlP92nO4_003D);
	}

	private void _0023_003DztGdcVOA_003D(Brep _0023_003DzE8QrneA_003D, Surface _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)1;
		_0023_003DzhJ0Kgk4_003D = _0023_003DzE8QrneA_003D;
		_0023_003DzlP92nO4_003D = _0023_003DzH9VU2k0_003D.ConvertToBrep();
		_0023_003Dz0tEHeuB0qP9j = _0023_003Dz2pnV7LKEBUZM(_0023_003DzhJ0Kgk4_003D);
		_0023_003DzF3hGxhIdtSIJ = _0023_003Dz2pnV7LKEBUZM(_0023_003DzlP92nO4_003D);
	}

	private void _0023_003DztGdcVOA_003D(Brep _0023_003DzE8QrneA_003D, ICurve _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)2;
		_0023_003DzhJ0Kgk4_003D = _0023_003DzE8QrneA_003D;
		_0023_003Dz0tEHeuB0qP9j = _0023_003Dz2pnV7LKEBUZM(_0023_003DzhJ0Kgk4_003D);
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL = new ICurve[1][];
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL[0] = new ICurve[1];
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL[0][0] = _0023_003DzH9VU2k0_003D;
	}

	private void _0023_003DztGdcVOA_003D(Brep _0023_003DzE8QrneA_003D, Point _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)3;
		_0023_003DzhJ0Kgk4_003D = _0023_003DzE8QrneA_003D;
		_0023_003Dz0tEHeuB0qP9j = _0023_003Dz2pnV7LKEBUZM(_0023_003DzhJ0Kgk4_003D);
		_0023_003DzrvvzXC0ysFW6 = (Point3D)_0023_003DzH9VU2k0_003D.Position.Clone();
	}

	private void _0023_003DztGdcVOA_003D(Surface _0023_003DzE8QrneA_003D, Surface _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)4;
		_0023_003DzhJ0Kgk4_003D = _0023_003DzE8QrneA_003D.ConvertToBrep();
		_0023_003DzlP92nO4_003D = _0023_003DzH9VU2k0_003D.ConvertToBrep();
		_0023_003Dz0tEHeuB0qP9j = _0023_003Dz2pnV7LKEBUZM(_0023_003DzhJ0Kgk4_003D);
		_0023_003DzF3hGxhIdtSIJ = _0023_003Dz2pnV7LKEBUZM(_0023_003DzlP92nO4_003D);
	}

	private void _0023_003DztGdcVOA_003D(Surface _0023_003DzE8QrneA_003D, ICurve _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)5;
		_0023_003DzhJ0Kgk4_003D = _0023_003DzE8QrneA_003D.ConvertToBrep();
		_0023_003Dz0tEHeuB0qP9j = _0023_003Dz2pnV7LKEBUZM(_0023_003DzhJ0Kgk4_003D);
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL = new ICurve[1][];
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL[0] = new ICurve[1];
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL[0][0] = _0023_003DzH9VU2k0_003D;
	}

	private void _0023_003DztGdcVOA_003D(Surface _0023_003DzE8QrneA_003D, Point _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)6;
		_0023_003Dz0tEHeuB0qP9j = new Surface[1];
		_0023_003Dz0tEHeuB0qP9j[0] = _0023_003DzE8QrneA_003D;
		_0023_003DzrvvzXC0ysFW6 = (Point3D)_0023_003DzH9VU2k0_003D.Position.Clone();
	}

	private void _0023_003DztGdcVOA_003D(ICurve _0023_003DzE8QrneA_003D, ICurve _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)7;
		_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt = new ICurve[1][];
		_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt[0] = new ICurve[1];
		_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt[0][0] = _0023_003DzE8QrneA_003D;
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL = new ICurve[1][];
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL[0] = new ICurve[1];
		_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL[0][0] = _0023_003DzH9VU2k0_003D;
	}

	private void _0023_003DztGdcVOA_003D(ICurve _0023_003DzE8QrneA_003D, Point _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)8;
		_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt = new ICurve[1][];
		_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt[0] = new ICurve[1];
		_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt[0][0] = _0023_003DzE8QrneA_003D;
		_0023_003DzrvvzXC0ysFW6 = (Point3D)_0023_003DzH9VU2k0_003D.Position.Clone();
	}

	private void _0023_003DztGdcVOA_003D(Point _0023_003DzE8QrneA_003D, Point _0023_003DzH9VU2k0_003D)
	{
		_0023_003Dzoe71ZrttfeF_0024 = (_0023_003Dz8eqy3JQ_003D)9;
		_0023_003Dzk4V07DxKbrHU = (Point3D)_0023_003DzE8QrneA_003D.Position.Clone();
		_0023_003DzrvvzXC0ysFW6 = (Point3D)_0023_003DzH9VU2k0_003D.Position.Clone();
	}

	private Surface[] _0023_003Dz2pnV7LKEBUZM(Brep _0023_003Dz1v6oPQk_003D)
	{
		List<Surface> list = new List<Surface>();
		Brep.Face[] faces = _0023_003Dz1v6oPQk_003D.Faces;
		for (int i = 0; i < faces.Length; i++)
		{
			Surface[] array = faces[i].ConvertToSurface();
			if (array.Length != 0)
			{
				list.Add(array[0]);
			}
		}
		return list.ToArray();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2 = new _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D();
		_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzsWnj47U_003D = progress;
		_0023_003DzEBehidw_003D = ct;
		if (_0023_003Dzoe71ZrttfeF_0024 == (_0023_003Dz8eqy3JQ_003D)3)
		{
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dzd2yCtzjnqXgSvMXLNz7SSgawiuVd = new double[_0023_003Dz0tEHeuB0qP9j.Length];
			_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dze13_0024sqWsbmC5 = new Point3D[_0023_003Dz0tEHeuB0qP9j.Length];
			Parallel.For(0, _0023_003Dz0tEHeuB0qP9j.Length, _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D);
			double num = _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dzd2yCtzjnqXgSvMXLNz7SSgawiuVd.Min();
			int num2 = Array.IndexOf(_0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dzd2yCtzjnqXgSvMXLNz7SSgawiuVd, num);
			_0023_003Dzk4V07DxKbrHU = _0023_003DzG0jQj7ffC24HCwl_lnif_II_003D2._0023_003Dze13_0024sqWsbmC5[num2];
			_0023_003DzKuQT6Co_003D = Math.Sqrt(num);
		}
		else if (_0023_003Dzoe71ZrttfeF_0024 == (_0023_003Dz8eqy3JQ_003D)6)
		{
			_0023_003Dz0tEHeuB0qP9j[0].ClosestPointTo(_0023_003DzrvvzXC0ysFW6, out var u, out var v);
			_0023_003Dzk4V07DxKbrHU = _0023_003Dz0tEHeuB0qP9j[0].PointAt(u, v);
		}
		else if (_0023_003Dzoe71ZrttfeF_0024 == (_0023_003Dz8eqy3JQ_003D)8)
		{
			_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt[0][0].ClosestPointTo(_0023_003DzrvvzXC0ysFW6, out var t);
			_0023_003Dzk4V07DxKbrHU = _0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt[0][0].PointAt(t);
		}
		else if (_0023_003Dzoe71ZrttfeF_0024 != (_0023_003Dz8eqy3JQ_003D)9)
		{
			_0023_003Dz1hpCyOKDoFIyCQUT8w_003D_003D();
		}
		if (double.IsNaN(_0023_003DzKuQT6Co_003D) && _0023_003Dzk4V07DxKbrHU != null && _0023_003DzrvvzXC0ysFW6 != null)
		{
			_0023_003DzKuQT6Co_003D = _0023_003Dzk4V07DxKbrHU.DistanceTo(_0023_003DzrvvzXC0ysFW6);
		}
	}

	private void _0023_003Dz1hpCyOKDoFIyCQUT8w_003D_003D()
	{
		_0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D CS_0024_003C_003E8__locals18 = new _0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D();
		CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz6LYSVEJVpLFjFhvnoQ_003D_003D = (int)_0023_003Dzoe71ZrttfeF_0024 < 6;
		_0023_003DzEoWlxu1MwzlHZjCTvw_003D_003D = (int)_0023_003Dzoe71ZrttfeF_0024 < 2 || _0023_003Dzoe71ZrttfeF_0024 == (_0023_003Dz8eqy3JQ_003D)4;
		_0023_003Dzs0HPXCwRNSuwxyndUA_003D_003D(_0023_003Dz0tEHeuB0qP9j, _0023_003Dz6LYSVEJVpLFjFhvnoQ_003D_003D, out _0023_003DzOE0AAeumraCVMCzBSQ_003D_003D);
		_0023_003Dzs0HPXCwRNSuwxyndUA_003D_003D(_0023_003DzF3hGxhIdtSIJ, _0023_003DzEoWlxu1MwzlHZjCTvw_003D_003D, out _0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D);
		_0023_003DzGcMuHaIsUIRMiPrSK_0024FHM_0024U_003D = new PointNormalUv[_0023_003DzOE0AAeumraCVMCzBSQ_003D_003D.Length];
		_0023_003DzVdMSTv_t71W2KHjS7Q_003D_003D = new PointNormalUv[_0023_003DzOE0AAeumraCVMCzBSQ_003D_003D.Length][][];
		_0023_003DzY1Z9GDSwHnj7RX7A1WLK18s_003D = new PointNormalUv[_0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length];
		_0023_003Dzx74ByLO3b_00242zK9xKuQ_003D_003D = new PointNormalUv[_0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length][][];
		if (_0023_003Dz6LYSVEJVpLFjFhvnoQ_003D_003D)
		{
			_0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt = new ICurve[_0023_003DzOE0AAeumraCVMCzBSQ_003D_003D.Length][];
		}
		if (_0023_003DzEoWlxu1MwzlHZjCTvw_003D_003D)
		{
			_0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL = new ICurve[_0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length][];
		}
		CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL = new _0023_003Dzq03E8WAcFKhl[_0023_003DzOE0AAeumraCVMCzBSQ_003D_003D.Length * _0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length];
		ResetProgress();
		Parallel.For(0, _0023_003DzOE0AAeumraCVMCzBSQ_003D_003D.Length, delegate(int _0023_003DzZSMvk48_003D)
		{
			for (int i = 0; i < CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length; i++)
			{
				int num4 = _0023_003DzZSMvk48_003D * CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D.Length + i;
				CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL[num4] = new _0023_003Dzq03E8WAcFKhl(_0023_003DzZSMvk48_003D, i, CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003DzOE0AAeumraCVMCzBSQ_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003Dz_00248fp_vPXbkr0HKQ3_g_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt, CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL, CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003Dz6LYSVEJVpLFjFhvnoQ_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs._0023_003DzEoWlxu1MwzlHZjCTvw_003D_003D);
			}
		});
		ResetProgress();
		Parallel.For(0, CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL.Length, CS_0024_003C_003E8__locals18._0023_003DzsZhLEp8d_ZnxtQuJ9JkbZW8_003D);
		double num = 1E-24;
		Array.Sort(CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL, (_0023_003Dzq03E8WAcFKhl _0023_003DzL_BXzuA_003D, _0023_003Dzq03E8WAcFKhl _0023_003DzW0adwBQ_003D) => _0023_003DzL_BXzuA_003D._0023_003DzVNOVRN7mF1xbxNA5DQ_003D_003D().CompareTo(_0023_003DzW0adwBQ_003D._0023_003DzVNOVRN7mF1xbxNA5DQ_003D_003D()));
		_0023_003DzI5MiWyE_003D _0023_003DzI5MiWyE_003D2 = null;
		_0023_003DzI5MiWyE_003D _0023_003DzI5MiWyE_003D3 = null;
		double num2 = double.MaxValue;
		for (int num3 = 0; num3 < CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL.Length; num3++)
		{
			if (CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL[num3]._0023_003DzVNOVRN7mF1xbxNA5DQ_003D_003D() > num2)
			{
				UpdateProgressTo100(ProcessingText, _0023_003DzsWnj47U_003D);
				break;
			}
			_0023_003DzI5MiWyE_003D2 = CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL[num3]._0023_003DzObuEcWw_003D(_0023_003DzGcMuHaIsUIRMiPrSK_0024FHM_0024U_003D, _0023_003DzY1Z9GDSwHnj7RX7A1WLK18s_003D, _0023_003DzVdMSTv_t71W2KHjS7Q_003D_003D, _0023_003Dzx74ByLO3b_00242zK9xKuQ_003D_003D, _0023_003DzC1dSFOjJDKK9kwQlxwFT3_6x0tnt, _0023_003Dzw62fyfbst6WDwrbB94Cn47wOnlIL);
			if (_0023_003DzI5MiWyE_003D2 != null && _0023_003DzI5MiWyE_003D2._0023_003DzzSdvRJ4yZZNL() < num2)
			{
				num2 = _0023_003DzI5MiWyE_003D2._0023_003DzzSdvRJ4yZZNL();
				_0023_003DzI5MiWyE_003D3 = _0023_003DzI5MiWyE_003D2;
				if (num2 < num)
				{
					UpdateProgressTo100(ProcessingText, _0023_003DzsWnj47U_003D);
					break;
				}
			}
			UpdateProgressAndCheckCancelled(num3, CS_0024_003C_003E8__locals18._0023_003DzXCKVKJVntiTL.Length, ProcessingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D);
		}
		_0023_003DzKuQT6Co_003D = Math.Sqrt(num2);
		if (_0023_003DzI5MiWyE_003D3 != null)
		{
			_0023_003Dzk4V07DxKbrHU = _0023_003DzI5MiWyE_003D3._0023_003DzwzHUHq4_003D;
			_0023_003DzrvvzXC0ysFW6 = _0023_003DzI5MiWyE_003D3._0023_003Dz5UWQnIQ_003D;
		}
	}

	private void _0023_003DzbBGtScc4KY1MWVjx3A_003D_003D(Surface _0023_003DzuwH5j5s_003D, out _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[] _0023_003Dzewd7VQrpQxiyqllqgQ_003D_003D)
	{
		_0023_003Dzewd7VQrpQxiyqllqgQ_003D_003D = _0023_003DzqGVCgrBynBx__0zpNyyIoDq1UDfHNc80x4V1z5BRniPJF0BHLg_003D_003D._0023_003DzbBGtScc4KY1MWVjx3A_003D_003D(_0023_003DzuwH5j5s_003D, 0.0, Math.PI / 3.0, _0023_003DzWLlA6AcQKGFm3rZGPw_003D_003D: false);
		_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[] array = _0023_003Dzewd7VQrpQxiyqllqgQ_003D_003D;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].EntityData = _0023_003DzuwH5j5s_003D;
		}
	}

	private void _0023_003Dzs0HPXCwRNSuwxyndUA_003D_003D(Surface[] _0023_003DzpPOEJqcAh7Lr, bool _0023_003DzAkABTQW9Sw0E1diaXQ_003D_003D, out _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[] _0023_003DzBIXUjOtOQkBX)
	{
		if (_0023_003DzAkABTQW9Sw0E1diaXQ_003D_003D)
		{
			List<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D> list = new List<_0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D>();
			ResetProgress();
			for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
			{
				_0023_003DzbBGtScc4KY1MWVjx3A_003D_003D(_0023_003DzpPOEJqcAh7Lr[i], out var _0023_003Dzewd7VQrpQxiyqllqgQ_003D_003D);
				list.AddRange(_0023_003Dzewd7VQrpQxiyqllqgQ_003D_003D);
				UpdateProgressAndCheckCancelled(i, _0023_003DzpPOEJqcAh7Lr.Length, InitializingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D);
			}
			_0023_003DzBIXUjOtOQkBX = list.ToArray();
		}
		else
		{
			_0023_003DzBIXUjOtOQkBX = new _0023_003DzBn2nX1VxOJ3z6Bv8_0024GZfBA4slVj97g_mm8WLQKg_003D[1];
		}
	}
}
