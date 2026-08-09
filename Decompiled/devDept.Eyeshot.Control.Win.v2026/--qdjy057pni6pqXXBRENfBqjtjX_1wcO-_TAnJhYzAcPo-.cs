using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security;
using System.Threading;

internal sealed class _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D
{
	private delegate void _0023_003Dz1SmHC4c_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D);

	private sealed class _0023_003DzDp118Pw_003D : IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D _0023_003DzjYYAPCA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzVC9FBdo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DzwBouG0w_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003Dzf4Pqh9s_003D;

		public void Dispose()
		{
			IDisposable disposable = _0023_003DzVC9FBdo_003D;
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
			if (_0023_003DzwBouG0w_003D != null)
			{
				_0023_003DzwBouG0w_003D.Dispose();
				_0023_003DzwBouG0w_003D = null;
			}
		}
	}

	private struct _0023_003DzJ6W8874_003D(MethodBase _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D) : IEquatable<_0023_003DzJ6W8874_003D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly MethodBase _0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzVC9FBdo_003D = _0023_003DzVC9FBdo_003D;

		[_0023_003Dqu2lukaMdtknH99Y0fKPgR3MS0ohgAboSPWM1iM8m1iY_003D]
		public MethodBase _0023_003DzoHqx0vq_00243HCz7aG3aJN3KzLwo_k3S0YU0RjED9E_003D()
		{
			return _0023_003DzjYYAPCA_003D;
		}

		[_0023_003Dqu2lukaMdtknH99Y0fKPgR3MS0ohgAboSPWM1iM8m1iY_003D]
		public bool _0023_003Dz8hyxt74k_91OG94pHrOASURB9KA0_iCNIFAfTGA_003D()
		{
			return _0023_003DzVC9FBdo_003D;
		}

		public override int GetHashCode()
		{
			return _0023_003DzoHqx0vq_00243HCz7aG3aJN3KzLwo_k3S0YU0RjED9E_003D().GetHashCode() ^ _0023_003Dz8hyxt74k_91OG94pHrOASURB9KA0_iCNIFAfTGA_003D().GetHashCode();
		}

		public override bool Equals(object _0023_003DzjYYAPCA_003D)
		{
			if (_0023_003DzjYYAPCA_003D is _0023_003DzJ6W8874_003D _0023_003DzJ6W8874_003D2)
			{
				return Equals(_0023_003DzJ6W8874_003D2);
			}
			return false;
		}

		public bool Equals(_0023_003DzJ6W8874_003D _0023_003DzjYYAPCA_003D)
		{
			if (_0023_003DzoHqx0vq_00243HCz7aG3aJN3KzLwo_k3S0YU0RjED9E_003D() == _0023_003DzjYYAPCA_003D._0023_003DzoHqx0vq_00243HCz7aG3aJN3KzLwo_k3S0YU0RjED9E_003D())
			{
				return _0023_003Dz8hyxt74k_91OG94pHrOASURB9KA0_iCNIFAfTGA_003D() == _0023_003DzjYYAPCA_003D._0023_003Dz8hyxt74k_91OG94pHrOASURB9KA0_iCNIFAfTGA_003D();
			}
			return false;
		}
	}

	private struct _0023_003DzLtLprGE_003D(_0023_003DqpATz8D_jE9d2tWHW_0024puEsvnytU9xF_AGu2dtFu_0024K4oY_003D _0023_003DzjYYAPCA_003D, _0023_003Dz1SmHC4c_003D _0023_003DzVC9FBdo_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte _0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D._0023_003DzD45raGOlAvpZNeTAgCa7aQ73zjyLCfN_0024_0024Wn_0024TeIqrKZi();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly _0023_003Dz1SmHC4c_003D _0023_003DzVC9FBdo_003D = _0023_003DzVC9FBdo_003D;
	}

	private sealed class _0023_003DzRoqMfFc_003D
	{
		private string _0023_003DzjYYAPCA_003D;

		private Type _0023_003DzVC9FBdo_003D;

		public string _0023_003Dzw_0024yg2mQUw3nIzirNKc_C12Jy5y3J5qkW9Yz1GY0_003D()
		{
			return _0023_003DzjYYAPCA_003D;
		}

		public void _0023_003Dz3vjxt592yWuOWSI2xycW_0024ARNVfNZH0Joxw_003D_003D(string _0023_003DzjYYAPCA_003D)
		{
			this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
		}

		public Type _0023_003DzKHAA_0024hDUC1NF4NrllDxvUiMz5NKxd1EugA_003D_003D()
		{
			return _0023_003DzVC9FBdo_003D;
		}

		public void _0023_003DzIbtJWUb2dEaRHxamTvMDHqpjqS6INXlFgA_003D_003D(Type _0023_003DzjYYAPCA_003D)
		{
			_0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D;
		}
	}

	private struct _0023_003DzTFNDoh0_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly uint _0023_003DzjYYAPCA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly object _0023_003DzVC9FBdo_003D;

		public _0023_003DzTFNDoh0_003D(uint _0023_003DzjYYAPCA_003D)
		{
			this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
			_0023_003DzVC9FBdo_003D = null;
		}

		public _0023_003DzTFNDoh0_003D(uint _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D)
		{
			this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
			this._0023_003DzVC9FBdo_003D = _0023_003DzVC9FBdo_003D;
		}

		[_0023_003Dqu2lukaMdtknH99Y0fKPgR3MS0ohgAboSPWM1iM8m1iY_003D]
		public uint _0023_003DzhoMbiYCjPiX5HmHGX5R_0024L9b6zXYc()
		{
			return _0023_003DzjYYAPCA_003D;
		}

		[_0023_003Dqu2lukaMdtknH99Y0fKPgR3MS0ohgAboSPWM1iM8m1iY_003D]
		public object _0023_003DzjTdiSl_0024wIvTwOshSqwEvP4Q_003D()
		{
			return _0023_003DzVC9FBdo_003D;
		}
	}

	[Serializable]
	private sealed class _0023_003DzVC9FBdo_003D
	{
		public static readonly _0023_003DzVC9FBdo_003D _0023_003DzjYYAPCA_003D = new _0023_003DzVC9FBdo_003D();

		public static Comparison<_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D> _0023_003DzVC9FBdo_003D;

		internal int _0023_003DziYO75IgWv_x_00246Rv_00248BN4swayxnDvDHL6Jk8TgXvo_0024Euh(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D _0023_003DzjYYAPCA_003D, _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D _0023_003DzVC9FBdo_003D)
		{
			if (_0023_003DzjYYAPCA_003D._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP() == _0023_003DzVC9FBdo_003D._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP())
			{
				return _0023_003DzVC9FBdo_003D._0023_003DzWkGfI94pX_1bh7ki_0024ibBr76u1WoF7rtxOQ_003D_003D().CompareTo(_0023_003DzjYYAPCA_003D._0023_003DzWkGfI94pX_1bh7ki_0024ibBr76u1WoF7rtxOQ_003D_003D());
			}
			return _0023_003DzjYYAPCA_003D._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP().CompareTo(_0023_003DzVC9FBdo_003D._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP());
		}
	}

	private sealed class _0023_003DzbAh_0024yNw_003D<_0023_003DzjYYAPCA_003D> : IComparer<KeyValuePair<int, _0023_003DzjYYAPCA_003D>>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Comparison<_0023_003DzjYYAPCA_003D> _0023_003DzjYYAPCA_003D;

		public _0023_003DzbAh_0024yNw_003D(Comparison<_0023_003DzjYYAPCA_003D> _0023_003DzjYYAPCA_003D)
		{
			this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
		}

		public int Compare(KeyValuePair<int, _0023_003DzjYYAPCA_003D> _0023_003DzjYYAPCA_003D, KeyValuePair<int, _0023_003DzjYYAPCA_003D> _0023_003DzVC9FBdo_003D)
		{
			int num = this._0023_003DzjYYAPCA_003D(_0023_003DzjYYAPCA_003D.Value, _0023_003DzVC9FBdo_003D.Value);
			if (num == 0)
			{
				return _0023_003DzVC9FBdo_003D.Key.CompareTo(_0023_003DzjYYAPCA_003D.Key);
			}
			return num;
		}
	}

	private static class _0023_003Dzf4Pqh9s_003D
	{
		public static readonly bool _0023_003DzjYYAPCA_003D;

		static _0023_003Dzf4Pqh9s_003D()
		{
			try
			{
				_0023_003DzjYYAPCA_003D = _0023_003DzH2Kul9YApjxaj9RsKDxN6PU_003D();
			}
			catch
			{
				_0023_003DzjYYAPCA_003D = false;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0023_003DzH2Kul9YApjxaj9RsKDxN6PU_003D()
		{
			if (typeof(DynamicMethod).IsAbstract)
			{
				return false;
			}
			try
			{
				new DynamicMethod(string.Empty, typeof(void), Type.EmptyTypes);
			}
			catch (PlatformNotSupportedException)
			{
				return false;
			}
			return true;
		}
	}

	private static class _0023_003DzjYYAPCA_003D
	{
		public static _0023_003Dz1SmHC4c_003D _0023_003DzjYYAPCA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzVC9FBdo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzwBouG0w_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzf4Pqh9s_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzTFNDoh0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzraVZG9g_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzRoqMfFc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz1SmHC4c_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzLtLprGE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzmZWYhFQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzt2pW2yo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzJ6W8874_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzmjtwFUo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzDp118Pw_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzbAh_0024yNw_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzivyja_00240_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz1latlWs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz7NsQCL4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzoMNiNRw_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzQizPEX8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzKufrQS0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzY8c1My4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzaKmBh2M_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz6It9KyA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz8GBMuoM_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzhGgZIrA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzi8OTyx4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzTD9escs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzgd4c0yY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzKfi4z6E_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzWoS2eJk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzpBK8X4w_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzOIZPJ_00248_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzDw__wI8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzevtAwuM_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz2BwZl2w_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzpGw_0024feA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzJU0R6e0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz0yDzO_0024c_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzDmRZtNk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzM5rdgLs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz7mKSiLg_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzXpoVQZQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzLK6YY4s_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz7dLpRsk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz5PxKZP0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz3kjjQlQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzZ8tYtAY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzFrc_0024oLQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzHw7Dl0k_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz19V87tw_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzfkPKRYQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzuW1CqYA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzOzOni9M_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzo5WhAr0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzkHYU37s_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzkpJ1y4k_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz2QYJXSU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzBVC71KE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzPRPNrro_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzaqY9_Z4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz5kvQ5Hg_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz09M7LQY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzVEHRsFg_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzj25UIwk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzjqAAENI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzSAhtsr0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz_4IhUWs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzmJGqfJY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz6GYXROo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzqLoKr7o_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzeuGuOw0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz9FiFEf4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzrv0NqTQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzCqleKvU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz1EpCtMQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzhThTuf8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzZm8UBbs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz3obFL1Y_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzW34vfOo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz_0024qI1lQs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzMhr2LyQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzNeqst7A_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzXKkoCy0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzKhixoO0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzxzvTo00_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzGMK4xyk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzQccUlQo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzwtkTdfw_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzYbQcnZQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzoLX1o88_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz_TlNN0s_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzMAFuAGM_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzbRF3BQU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzb1LFVDs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzr_0024cEGfg_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzbekpFEo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzZn_13E4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzdXm8s1g_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzD5s6QoI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzh8G_W84_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzEYp_0024UVY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzOr41T4Q_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzsrc1_0024QY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzSO5Kl4U_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DznB3lUg4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dznmd_5fw_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzXmqsZ2I_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzMxlZvbA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzKvkiXSI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DztaW4noE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzbTG2Hh4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzZmkJseI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzStplry4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzPPhL6kw_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzwd7j5iY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzYDAm3To_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzzh0j87s_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzbUSwGy4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz1g8gp8s_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzQQicCX8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzqx7xw4U_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzHn5kbtE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzrrFe5NM_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzzdXgYPI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzEwGee_A_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzBrYseb8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzOvxSA4M_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzDyffOIs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzk_DblsQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzprO7igs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzkjGnIMQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz3JlXtik_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzaf6c79c_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzNn516fc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzrMClyx8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzWIjt_0024fI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzdcz2EwQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzd1hAZ4A_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzRJQSVpk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzx7NVZ48_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzOOo4bvo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzJx6crCU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzpBq5joM_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzITpteWU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzEhoFlyc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzJLVsyS0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz_0024GTvFZg_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzQVubGmM_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzup2h_0024v4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzKtnMqyU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzbq9PzmE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DziSR3fdM_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz_0024nLfT_A_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzyd4vT_0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzE3sP_0024o0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzEqbQfP8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzkdS3nm0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzltw5qNc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzXSTuKJU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzW_0024pZGy8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzrOXxJ28_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz5BgXqy0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzu55XgAk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzAsfC0_00244_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzRtXoeKk_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzhD_HJLU_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz0KV7OXY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzMFQrFCo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DztI8MUyE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz4uQoDiI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dze7MUxgs_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dza9T4i_I_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzQujKg5Y_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz8TCFuOY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzmYVdEjY_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzW2hAkvc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzkfUqbGA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzQAbI59M_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzw7ivbiE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzWERv_Yc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzNMcPi_0024E_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzQ_UinS4_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzLB1vLV0_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzjukWAy8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzpQ3aCQI_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzWUl5QeA_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DziQhyw2I_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz6cOnd9M_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzdBIDw9w_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzEUCwvjE_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzJBBzDss_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dzf_0024_0024Ar9M_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzPyFl18U_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz1kNN9Oc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzjU3US28_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz5Q_00249R5M_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzAuQ_FXg_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzgDAPpuo_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz3Xo1N9I_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzJ3z_9rg_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzyRHYfQQ_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz_cFD_t8_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003DzLnf0_0024lc_003D;

		public static _0023_003Dz1SmHC4c_003D _0023_003Dz1Xfr_002480_003D;
	}

	private static class _0023_003DzmZWYhFQ_003D
	{
		private delegate void _0023_003Dz1SmHC4c_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D, in _0023_003DzRoqMfFc_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D, _0023_003DzRoqMfFc_003D _0023_003DzRoqMfFc_003D);

		private delegate _0023_003DzraVZG9g_003D _0023_003Dz1latlWs_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, out _0023_003DzraVZG9g_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D);

		private delegate _0023_003DzRoqMfFc_003D _0023_003Dz7NsQCL4_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D, out _0023_003DzRoqMfFc_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D);

		private delegate _0023_003DzwBouG0w_003D _0023_003DzDp118Pw_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, out _0023_003DzwBouG0w_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D);

		private delegate _0023_003DzmZWYhFQ_003D _0023_003DzJ6W8874_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D, in _0023_003DzRoqMfFc_003D, in _0023_003Dz1SmHC4c_003D, in _0023_003DzLtLprGE_003D, out _0023_003DzmZWYhFQ_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D, _0023_003DzRoqMfFc_003D _0023_003DzRoqMfFc_003D, _0023_003Dz1SmHC4c_003D _0023_003Dz1SmHC4c_003D, _0023_003DzLtLprGE_003D _0023_003DzLtLprGE_003D);

		private delegate void _0023_003DzLtLprGE_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D, in _0023_003DzRoqMfFc_003D, in _0023_003Dz1SmHC4c_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D, _0023_003DzRoqMfFc_003D _0023_003DzRoqMfFc_003D, _0023_003Dz1SmHC4c_003D _0023_003Dz1SmHC4c_003D);

		private delegate _0023_003DzLtLprGE_003D _0023_003DzQizPEX8_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D, in _0023_003DzRoqMfFc_003D, in _0023_003Dz1SmHC4c_003D, out _0023_003DzLtLprGE_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D, _0023_003DzRoqMfFc_003D _0023_003DzRoqMfFc_003D, _0023_003Dz1SmHC4c_003D _0023_003Dz1SmHC4c_003D);

		private delegate void _0023_003DzRoqMfFc_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D);

		private delegate void _0023_003DzTFNDoh0_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D);

		private delegate void _0023_003DzVC9FBdo_003D<in _0023_003DzjYYAPCA_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D);

		private delegate _0023_003Dzf4Pqh9s_003D _0023_003DzbAh_0024yNw_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, out _0023_003Dzf4Pqh9s_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D);

		private delegate void _0023_003Dzf4Pqh9s_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D);

		private delegate _0023_003DzTFNDoh0_003D _0023_003Dzivyja_00240_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, out _0023_003DzTFNDoh0_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D);

		private delegate void _0023_003DzjYYAPCA_003D();

		private delegate void _0023_003DzmZWYhFQ_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D, in _0023_003DzRoqMfFc_003D, in _0023_003Dz1SmHC4c_003D, in _0023_003DzLtLprGE_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D, _0023_003DzRoqMfFc_003D _0023_003DzRoqMfFc_003D, _0023_003Dz1SmHC4c_003D _0023_003Dz1SmHC4c_003D, _0023_003DzLtLprGE_003D _0023_003DzLtLprGE_003D);

		private delegate _0023_003DzVC9FBdo_003D _0023_003DzmjtwFUo_003D<in _0023_003DzjYYAPCA_003D, out _0023_003DzVC9FBdo_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D);

		private delegate _0023_003Dz1SmHC4c_003D _0023_003DzoMNiNRw_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D, in _0023_003DzraVZG9g_003D, in _0023_003DzRoqMfFc_003D, out _0023_003Dz1SmHC4c_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D, _0023_003DzRoqMfFc_003D _0023_003DzRoqMfFc_003D);

		private delegate void _0023_003DzraVZG9g_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D, in _0023_003DzwBouG0w_003D, in _0023_003Dzf4Pqh9s_003D, in _0023_003DzTFNDoh0_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D);

		private delegate _0023_003DzjYYAPCA_003D _0023_003Dzt2pW2yo_003D<out _0023_003DzjYYAPCA_003D>();

		private delegate void _0023_003DzwBouG0w_003D<in _0023_003DzjYYAPCA_003D, in _0023_003DzVC9FBdo_003D>(_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D _0023_003DzVC9FBdo_003D);

		private static readonly Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> m__0023_003DzjYYAPCA_003D;

		static _0023_003DzmZWYhFQ_003D()
		{
			_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003DzmZWYhFQ_003D.m__0023_003DzjYYAPCA_003D = new Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>>();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object _0023_003DzbVEfm52MCEQEf1K6LLJ7mYoItfx9Et4mF7EYSAo_003D(object _0023_003DzjYYAPCA_003D, MethodBase _0023_003DzVC9FBdo_003D, out MethodInfo _0023_003DzwBouG0w_003D)
		{
			KeyValuePair<Type, MethodInfo> keyValuePair = _0023_003DzE4mJOPfdzYhy6MG1Ii616llQdPPX(_0023_003DzVC9FBdo_003D);
			Delegate result = (Delegate)Activator.CreateInstance(keyValuePair.Key, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D.MethodHandle.GetFunctionPointer());
			_0023_003DzwBouG0w_003D = keyValuePair.Value;
			return result;
		}

		private static KeyValuePair<Type, MethodInfo> _0023_003DzE4mJOPfdzYhy6MG1Ii616llQdPPX(MethodBase _0023_003DzjYYAPCA_003D)
		{
			lock (_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003DzmZWYhFQ_003D.m__0023_003DzjYYAPCA_003D)
			{
				if (_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003DzmZWYhFQ_003D.m__0023_003DzjYYAPCA_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value))
				{
					return value;
				}
				Type type = (_0023_003DzjYYAPCA_003D as MethodInfo)?.ReturnType ?? _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D;
				bool flag = type != _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D;
				ParameterInfo[] parameters = _0023_003DzjYYAPCA_003D.GetParameters();
				if (parameters.Length > 9)
				{
					throw new Exception(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621336), parameters.Length));
				}
				Type[] array = new Type[parameters.Length + (flag ? 1 : 0)];
				for (int i = 0; i < parameters.Length; i++)
				{
					Type parameterType = parameters[i].ParameterType;
					if (parameterType.IsByRef || parameterType.IsPointer)
					{
						throw new Exception(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621414));
					}
					array[i] = parameterType;
				}
				if (flag)
				{
					array[array.Length - 1] = type;
				}
				Type type2 = (flag ? _0023_003DzoPGYYlHAPkzsEH1fUVhOrXE_003D(array) : _0023_003Dz28PZsr8OhMUtnWGsbwnpWgQ_003D(array));
				MethodInfo method = type2.GetMethod(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621751));
				value = new KeyValuePair<Type, MethodInfo>(type2, method);
				_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003DzmZWYhFQ_003D.m__0023_003DzjYYAPCA_003D.Add(_0023_003DzjYYAPCA_003D, value);
				return value;
			}
		}

		private static Type _0023_003DzoPGYYlHAPkzsEH1fUVhOrXE_003D(Type[] _0023_003DzjYYAPCA_003D)
		{
			return _0023_003DzjYYAPCA_003D.Length switch
			{
				1 => typeof(_0023_003Dzt2pW2yo_003D<>).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				2 => typeof(_0023_003DzmjtwFUo_003D<, >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				3 => typeof(_0023_003DzDp118Pw_003D<, , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				4 => typeof(_0023_003DzbAh_0024yNw_003D<, , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				5 => typeof(_0023_003Dzivyja_00240_003D<, , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				6 => typeof(_0023_003Dz1latlWs_003D<, , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				7 => typeof(_0023_003Dz7NsQCL4_003D<, , , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				8 => typeof(_0023_003DzoMNiNRw_003D<, , , , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				9 => typeof(_0023_003DzQizPEX8_003D<, , , , , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				10 => typeof(_0023_003DzJ6W8874_003D<, , , , , , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				_ => null, 
			};
		}

		private static Type _0023_003Dz28PZsr8OhMUtnWGsbwnpWgQ_003D(Type[] _0023_003DzjYYAPCA_003D)
		{
			return _0023_003DzjYYAPCA_003D.Length switch
			{
				0 => typeof(_0023_003DzjYYAPCA_003D), 
				1 => typeof(_0023_003DzVC9FBdo_003D<>).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				2 => typeof(_0023_003DzwBouG0w_003D<, >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				3 => typeof(_0023_003Dzf4Pqh9s_003D<, , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				4 => typeof(_0023_003DzTFNDoh0_003D<, , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				5 => typeof(_0023_003DzraVZG9g_003D<, , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				6 => typeof(_0023_003DzRoqMfFc_003D<, , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				7 => typeof(_0023_003Dz1SmHC4c_003D<, , , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				8 => typeof(_0023_003DzLtLprGE_003D<, , , , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				9 => typeof(_0023_003DzmZWYhFQ_003D<, , , , , , , , >).MakeGenericType(_0023_003DzjYYAPCA_003D), 
				_ => null, 
			};
		}
	}

	private sealed class _0023_003DzmjtwFUo_003D
	{
	}

	private delegate object _0023_003DzraVZG9g_003D(object _0023_003DzjYYAPCA_003D, object[] _0023_003DzVC9FBdo_003D);

	private static class _0023_003Dzt2pW2yo_003D
	{
		private static readonly Dictionary<MethodBase, MethodInfo> _0023_003DzjYYAPCA_003D = new Dictionary<MethodBase, MethodInfo>();

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase _0023_003DznhxElRzbdvuEUHBG9_0024VXsulvtrLnIKYBYA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D _0023_003DzVC9FBdo_003D, MethodBase _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
		{
			lock (_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003Dzt2pW2yo_003D._0023_003DzjYYAPCA_003D)
			{
				if (_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003Dzt2pW2yo_003D._0023_003DzjYYAPCA_003D.TryGetValue(_0023_003DzwBouG0w_003D, out var value))
				{
					return value;
				}
				Type returnType = ((!(_0023_003DzwBouG0w_003D is MethodInfo methodInfo)) ? _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D : methodInfo.ReturnType);
				ParameterInfo[] parameters = _0023_003DzwBouG0w_003D.GetParameters();
				Type[] array;
				if (_0023_003DzwBouG0w_003D.IsStatic)
				{
					array = new Type[parameters.Length];
					for (int i = 0; i < parameters.Length; i++)
					{
						array[i] = parameters[i].ParameterType;
					}
				}
				else
				{
					array = new Type[parameters.Length + 1];
					Type type = _0023_003DzwBouG0w_003D.DeclaringType;
					if (type.IsValueType)
					{
						type = type.MakeByRefType();
						_0023_003Dzf4Pqh9s_003D = false;
					}
					array[0] = type;
					for (int j = 0; j < parameters.Length; j++)
					{
						array[j + 1] = parameters[j].ParameterType;
					}
				}
				string empty = string.Empty;
				if (value == null)
				{
					value = new DynamicMethod(empty, returnType, array, _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DzVC9FBdo_003D._0023_003DzOLMnH5O6nDdsgeNelug7d7P67d9Rvtr_00241w_003D_003D(), _0023_003DzVC9FBdo_003D: true), skipVisibility: true);
				}
				ILGenerator iLGenerator = ((DynamicMethod)value).GetILGenerator();
				for (int k = 0; k < array.Length; k++)
				{
					iLGenerator.Emit(OpCodes.Ldarg, k);
				}
				if (_0023_003DzwBouG0w_003D is ConstructorInfo con)
				{
					iLGenerator.Emit(_0023_003Dzf4Pqh9s_003D ? OpCodes.Callvirt : OpCodes.Call, con);
				}
				else
				{
					iLGenerator.Emit(_0023_003Dzf4Pqh9s_003D ? OpCodes.Callvirt : OpCodes.Call, (MethodInfo)_0023_003DzwBouG0w_003D);
				}
				iLGenerator.Emit(OpCodes.Ret);
				_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003Dzt2pW2yo_003D._0023_003DzjYYAPCA_003D.Add(_0023_003DzwBouG0w_003D, value);
				return value;
			}
		}
	}

	private struct _0023_003DzwBouG0w_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzjYYAPCA_003D;
	}

	private static Type _0023_003DzJU0R6e0_003D;

	private long _0023_003DzevtAwuM_003D;

	private readonly Module m__0023_003DzJ6W8874_003D;

	private _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D[] _0023_003Dz6It9KyA_003D;

	private Type[] _0023_003DzaKmBh2M_003D;

	private _0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D m__0023_003DzbAh_0024yNw_003D;

	private object _0023_003DzY8c1My4_003D;

	private static Type _0023_003Dz1latlWs_003D;

	private readonly _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmlAaZGkNAoWogHOkZvqFGU_003D _0023_003Dz0yDzO_0024c_003D;

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D m__0023_003DzTFNDoh0_003D;

	private Type[] m__0023_003Dzf4Pqh9s_003D;

	private static readonly Dictionary<_0023_003DzJ6W8874_003D, _0023_003DzraVZG9g_003D> _0023_003DzTD9escs_003D = new Dictionary<_0023_003DzJ6W8874_003D, _0023_003DzraVZG9g_003D>(256);

	private bool m__0023_003DzraVZG9g_003D;

	private readonly Stack<_0023_003DzTFNDoh0_003D> m__0023_003DzjYYAPCA_003D = new Stack<_0023_003DzTFNDoh0_003D>();

	private static readonly Dictionary<int, object> _0023_003Dzgd4c0yY_003D;

	private Type _0023_003Dz8GBMuoM_003D;

	private static Type _0023_003DzpBK8X4w_003D;

	private static Type m__0023_003DzVC9FBdo_003D;

	private readonly Stack<_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D> _0023_003DzoMNiNRw_003D = new Stack<_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D>(16);

	private static readonly Dictionary<MethodBase, int> m__0023_003DzwBouG0w_003D;

	private _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzKufrQS0_003D;

	private Stream m__0023_003DzRoqMfFc_003D;

	private static Type m__0023_003DzDp118Pw_003D;

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzDw__wI8_003D;

	private object[] m__0023_003DzLtLprGE_003D;

	private static Type m__0023_003Dz1SmHC4c_003D;

	private bool _0023_003DzQizPEX8_003D;

	private _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003Dzivyja_00240_003D;

	private static Type _0023_003DzhGgZIrA_003D;

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] m__0023_003Dzt2pW2yo_003D;

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] _0023_003DzKfi4z6E_003D;

	private byte[] m__0023_003DzmZWYhFQ_003D;

	private Stack<_0023_003DzDp118Pw_003D> _0023_003Dzi8OTyx4_003D;

	private uint? _0023_003DzOIZPJ_00248_003D;

	private static object _0023_003DzpGw_0024feA_003D = new object();

	private uint m__0023_003DzmjtwFUo_003D;

	private static Dictionary<int, _0023_003DzLtLprGE_003D> _0023_003Dz7NsQCL4_003D;

	private uint _0023_003DzWoS2eJk_003D;

	private static readonly Dictionary<MethodBase, object> _0023_003DzDmRZtNk_003D;

	private uint _0023_003Dz2BwZl2w_003D;

	public _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmlAaZGkNAoWogHOkZvqFGU_003D _0023_003DzjYYAPCA_003D, Module _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dz0yDzO_0024c_003D = _0023_003DzjYYAPCA_003D;
		this.m__0023_003DzJ6W8874_003D = _0023_003DzVC9FBdo_003D;
		_0023_003DzWuk7S46de05GdpDSltMoDxUUvIbmrYYUHg_003D_003D();
	}

	public _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmlAaZGkNAoWogHOkZvqFGU_003D _0023_003DzjYYAPCA_003D)
		: this(_0023_003DzjYYAPCA_003D, typeof(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D).Module)
	{
	}

	static _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D()
	{
		_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzwBouG0w_003D = new Dictionary<MethodBase, int>(256);
		_0023_003DzDmRZtNk_003D = new Dictionary<MethodBase, object>();
		_0023_003Dzgd4c0yY_003D = new Dictionary<int, object>();
		_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzDp118Pw_003D = typeof(_0023_003DzmjtwFUo_003D);
		_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D = typeof(void);
		_0023_003Dz1latlWs_003D = typeof(object[]);
		_0023_003DzhGgZIrA_003D = typeof(IntPtr);
		_0023_003DzpBK8X4w_003D = typeof(Assembly);
		_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzVC9FBdo_003D = typeof(MethodBase);
		_0023_003DzJU0R6e0_003D = typeof(RuntimeHelpers);
	}

	private void _0023_003DzFdlupYgUze2_0024waqwlXUpS5UI_0024l4h(bool _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzvaCQTB2qWP1HsNogYaao34COhZ1z52rgCQ_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D));
	}

	private static void _0023_003DzAT_SvBa7QonL2NIaI76iiMS1pUiG9vltNbRXiUBcS8ph(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		bool flag = false;
		if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() == 0, 
			13 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() == 0, 
			0 => ((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() == IntPtr.Zero, 
			20 => ((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() == UIntPtr.Zero, 
			7 => ((_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzbxMVv9p9wKFTXDEHbUUrzRSF_jqdjYqX8REqAOpnd1TT() == null, 
			19 => !Convert.ToBoolean(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			_ => _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == null, 
		})
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003DzrfqIm0EkueviQNBSH6gOlMAynw_0024XKs_0024VwUWZYaE_003D(Exception _0023_003DzjYYAPCA_003D)
	{
		ExceptionDispatchInfo.Capture(_0023_003DzjYYAPCA_003D).Throw();
	}

	private static void _0023_003Dz9hwpaM1Jv_0IoW3pj_0024ut_0024msmCvmse6p_LQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		FieldInfo fieldInfo = _0023_003DzjYYAPCA_003D._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D(fieldInfo, null));
	}

	private static void _0023_003DzoZgEGun3Iu6tMTdIQRP9Ig9AGuoTws1hYw_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzsaqDCdXA1fjkGC_0024VCiTIyfc_003D(((_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DzVC9FBdo_003D)._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D());
	}

	private static void _0023_003DzktUQSFk4Qs3095LbKoGr97U01s1Vlfe8WQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		checked
		{
			_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
			{
				1 => unchecked((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
				13 => (long)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
				19 => (long)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
				8 => (long)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
				0 => (IntPtr.Size != 4) ? ((long)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : unchecked((uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
				_ => throw new InvalidOperationException(), 
			}));
		}
	}

	private void _0023_003DzkwIyHLXyiC2uebcnoccQT7rFmVP8(bool _0023_003DzjYYAPCA_003D)
	{
		uint num = _0023_003Dz2BwZl2w_003D;
		while (true)
		{
			try
			{
				while (!_0023_003DzQizPEX8_003D)
				{
					if (_0023_003DzOIZPJ_00248_003D.HasValue)
					{
						_0023_003DzWoS2eJk_003D = _0023_003DzOIZPJ_00248_003D.Value;
						_0023_003DzlKeckCaClO9XhMQZJufmJ04_003D(_0023_003DzWoS2eJk_003D);
						_0023_003DzOIZPJ_00248_003D = null;
					}
					else if (_0023_003DzWoS2eJk_003D >= num)
					{
						break;
					}
					_0023_003Dzj1wmj0FWFUW8nBP2uEaCbaM8MZW_();
				}
				break;
			}
			catch (object obj)
			{
				_0023_003Dzbs_0024hQTPNkYOAARtNsmdtjJInauYQ5G09QlNpPeI_003D(obj, 0u);
				if (!_0023_003DzjYYAPCA_003D)
				{
					_0023_003DzkwIyHLXyiC2uebcnoccQT7rFmVP8(_0023_003DzjYYAPCA_003D: true);
					break;
				}
			}
		}
	}

	private void _0023_003DzWuk7S46de05GdpDSltMoDxUUvIbmrYYUHg_003D_003D()
	{
		if (!_0023_003Dz0yDzO_0024c_003D._0023_003DznOGAvlI_0024yo__S_llTCl5zqpUy02tRzXcsA_003D_003D())
		{
			lock (_0023_003Dz0yDzO_0024c_003D)
			{
				if (!_0023_003Dz0yDzO_0024c_003D._0023_003DznOGAvlI_0024yo__S_llTCl5zqpUy02tRzXcsA_003D_003D())
				{
					_0023_003Dz7NsQCL4_003D = _0023_003DzJ16rViqZyydIFfjuyBh_EZESFV5Q(_0023_003Dz0yDzO_0024c_003D);
					_0023_003Dzx4nKMouLux6X2cl3UrAwHOxr7U9o_sIHIg_003D_003D();
					_0023_003Dz0yDzO_0024c_003D._0023_003Dztu7Ts1o3NBw0SAbXO2u2xlyDFyXm(_0023_003DzjYYAPCA_003D: true);
				}
			}
		}
		if (_0023_003Dz7NsQCL4_003D == null)
		{
			_0023_003Dz7NsQCL4_003D = _0023_003DzJ16rViqZyydIFfjuyBh_EZESFV5Q(_0023_003Dz0yDzO_0024c_003D);
		}
	}

	private static void _0023_003Dzv8JsAX95nR_0024JoDLvG8OQjQEKvvmTsBQkKQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622353));
	}

	private static void _0023_003DznhNBt2wQrbbNPMO1dbAJwdmo43PY9hkcYMiRACA_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003DzY8c1My4_003D == null)
		{
			throw new InvalidOperationException();
		}
		_0023_003DzjYYAPCA_003D._0023_003DzPalNqUCr87jJQ2wBQmQB49pkBtH_0024(_0023_003DzjYYAPCA_003D._0023_003DzY8c1My4_003D);
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzWD3rU10LJjN22Og2BCOmR0kC7SgHNC3H7Q_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				if (!_0023_003DzwBouG0w_003D)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num >> num2);
				}
				int num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				int num4 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num3 >>> num4);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003DzWD3rU10LJjN22Og2BCOmR0kC7SgHNC3H7Q_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				if (!_0023_003DzwBouG0w_003D)
				{
					long num5 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
					int num6 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num5 >> num6);
				}
				long num7 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				int num8 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num7 >>> num8);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003DzWD3rU10LJjN22Og2BCOmR0kC7SgHNC3H7Q_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzWD3rU10LJjN22Og2BCOmR0kC7SgHNC3H7Q_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			return _0023_003DzWD3rU10LJjN22Og2BCOmR0kC7SgHNC3H7Q_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzW35di_00249InVltSJ2hlhd6eNMG18iD(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(5);
	}

	private static void _0023_003DzsRA5pdcAI9V7abxXb6a8vRw_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D _0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D2 = (_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DzVC9FBdo_003D;
		_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D obj = new _0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D();
		obj._0023_003Dz0phpHM_0024mCqRB9dTSooptWs6Fd5tg(_0023_003DzjYYAPCA_003D._0023_003DzKfi4z6E_003D[_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D2._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D()]);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzrhmC7EzIlogvg37F_0024jM9GV_GEYF9(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
				obj._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(num & num2);
				return obj;
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				int num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num3 & num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj2 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
				obj2._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(num3 & num5);
				return obj2;
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				long num6 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				long num7 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D obj3 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D();
				obj3._0023_003Dzh9pFyTiMWJW4wbfNIMoSMYw_003D(num6 & num7);
				return obj3;
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				int num8 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num8 & num9);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				int num10 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()) & num10);
				}
				int num11 = Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj4 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
				obj4._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(num11 & num10);
				return obj4;
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				long num12 = Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				long num13 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D obj5 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D();
				obj5._0023_003Dzh9pFyTiMWJW4wbfNIMoSMYw_003D(num12 & num13);
				return obj5;
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num14 = Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					long num15 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num14 & num15);
				}
				int num16 = Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				int num17 = Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num16 & num17);
			}
		}
		throw new InvalidOperationException();
	}

	private bool _0023_003Dz7O9cYwSi7BWCfwoAn4IKAvg_003D(_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003DzjYYAPCA_003D._0023_003DzjxTj7yNPdHyn2C7oYeJs_652ufci().IsInitOnly)
		{
			return true;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003DzjxTj7yNPdHyn2C7oYeJs_652ufci().IsStatic != m__0023_003DzbAh_0024yNw_003D._0023_003Dz1WWVGnrneA8xV7VcXabGDJzz31Kb())
		{
			return false;
		}
		if (m__0023_003DzbAh_0024yNw_003D._0023_003Dz1WWVGnrneA8xV7VcXabGDJzz31Kb() && m__0023_003DzbAh_0024yNw_003D._0023_003Dzm9VWNismLnbdxD6v10tj3f_Xz98q() != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622236))
		{
			return false;
		}
		Type type = _0023_003DzjYYAPCA_003D._0023_003DzjxTj7yNPdHyn2C7oYeJs_652ufci().DeclaringType;
		if (type.IsGenericType)
		{
			type = type.GetGenericTypeDefinition();
		}
		return _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(m__0023_003DzbAh_0024yNw_003D._0023_003DzOLMnH5O6nDdsgeNelug7d7P67d9Rvtr_00241w_003D_003D(), _0023_003DzVC9FBdo_003D: true) == type;
	}

	private static void _0023_003Dzh81FqdqNJzYDc4HXLALIlfzrYDARmL_k5gR2H_4Piall(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		Array array = (Array)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(array.Length));
	}

	private void _0023_003DzlKeckCaClO9XhMQZJufmJ04_003D(long _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dzivyja_00240_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D()._0023_003Dzn_t9hyVATRPnUxdqXwaUj9BPcyICJFt_8Z7_002402XyW0bjVPch0w_YOa0C7Qx9nd4TCWcwQcY_003D(_0023_003DzjYYAPCA_003D - _0023_003DzevtAwuM_003D);
	}

	private bool _0023_003DzDi5YIr3nzofmFxxw54VLk9EOgbhkBBwi_0024A_003D_003D(MethodBase _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] _0023_003DzwBouG0w_003D, object[] _0023_003Dzf4Pqh9s_003D, bool _0023_003DzTFNDoh0_003D, ref object _0023_003DzraVZG9g_003D)
	{
		Type declaringType = _0023_003DzjYYAPCA_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (declaringType == _0023_003DzJU0R6e0_003D && _0023_003DzjYYAPCA_003D.Name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622255) && _0023_003Dzf4Pqh9s_003D.Length == 2 && _0023_003DzjYYAPCA_003D.ToString() == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622265))
		{
			_0023_003DqqA_0024mLT03a6Jqga8x0590_6DcShH4BnLZxSy1HeEKl1o_003D._0023_003Dz5J2cxM9BVc2_0024h_0024sepkwwpLW5ROme((Array)_0023_003Dzf4Pqh9s_003D[0], (RuntimeFieldHandle)_0023_003Dzf4Pqh9s_003D[1]);
			return true;
		}
		return false;
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzLr1faxti3SyKbNVlUCjaH77fmTcUa6L7_0024luk9v0kzLec(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				if (!_0023_003DzwBouG0w_003D)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num % num2);
				}
				int num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num4 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D((int)((uint)num3 % num4));
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzVphNYyCQZGECQcYA9CsPo_0024wlzvO7dFgbKw5ySAo_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzVphNYyCQZGECQcYA9CsPo_0024wlzvO7dFgbKw5ySAo_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
				}
				return _0023_003DzLr1faxti3SyKbNVlUCjaH77fmTcUa6L7_0024luk9v0kzLec(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzVphNYyCQZGECQcYA9CsPo_0024wlzvO7dFgbKw5ySAo_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003DzVphNYyCQZGECQcYA9CsPo_0024wlzvO7dFgbKw5ySAo_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzwBouG0w_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzVphNYyCQZGECQcYA9CsPo_0024wlzvO7dFgbKw5ySAo_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
				}
				return _0023_003DzVphNYyCQZGECQcYA9CsPo_0024wlzvO7dFgbKw5ySAo_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8 && _0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8)
		{
			_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
			obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D() % ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D());
			return obj;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzLr1faxti3SyKbNVlUCjaH77fmTcUa6L7_0024luk9v0kzLec(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			return _0023_003DzLr1faxti3SyKbNVlUCjaH77fmTcUa6L7_0024luk9v0kzLec(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		}
		throw new InvalidOperationException();
	}

	private static bool _0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		bool result = false;
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 1:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			}
			result = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() < ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
			break;
		case 13:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()));
			}
			result = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() < ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			break;
		case 19:
			return _0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), _0023_003DzVC9FBdo_003D);
		case 8:
			result = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D() < ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			break;
		}
		return result;
	}

	private MethodBase _0023_003DzfqeuGMfs7I86ewGQl3MqeT4NzqWLtroZHR5jP_0024U_003D(_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D _0023_003DzjYYAPCA_003D)
	{
		Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DzjYYAPCA_003D._0023_003DzbwqGM_T9wDYA3VBmZbuUw_Jfm88y4ktyYSQ6_rQ_003D()._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003DzVC9FBdo_003D: false);
		BindingFlags bindingAttr = _0023_003DzjSXURF25698U40r_JUeUD2Md5VtOUzuO9w_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzsxSqB6_VoZhb2pr_8QXoxoo_003D());
		Type[] array = null;
		_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D[] array2 = _0023_003DzjYYAPCA_003D._0023_003DzyLgBzI5n1Wp5fTHJXqbsETASnbyWqaKPAOpVAv0_003D();
		if (array2 != null)
		{
			array = new Type[array2.Length];
			for (int i = 0; i < array.Length; i++)
			{
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = array2[i];
				if (_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 != null)
				{
					array[i] = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003DzVC9FBdo_003D: true);
				}
			}
		}
		MemberInfo[] member = type.GetMember(_0023_003DzjYYAPCA_003D._0023_003DzNFA5tRKbMqlXvi2_0024aBt_0024AIZ3iOuA(), MemberTypes.Method, bindingAttr);
		MethodInfo methodInfo = null;
		int num = -1;
		MemberInfo[] array3 = member;
		for (int j = 0; j < array3.Length; j++)
		{
			MethodInfo methodInfo2 = (MethodInfo)array3[j];
			if (_0023_003Dzk1vjYKdrxBDMQqZueQW24U0_003D(methodInfo2, _0023_003DzjYYAPCA_003D, array, out var num2) && num2 > num)
			{
				methodInfo = methodInfo2;
				num = num2;
			}
		}
		if (methodInfo == null)
		{
			throw new Exception(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621659), type.Name, _0023_003DzjYYAPCA_003D._0023_003DzNFA5tRKbMqlXvi2_0024aBt_0024AIZ3iOuA()));
		}
		return methodInfo.MakeGenericMethod(array);
	}

	private void _0023_003Dzbs_0024hQTPNkYOAARtNsmdtjJInauYQ5G09QlNpPeI_003D(object _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D)
	{
		bool flag = _0023_003DzjYYAPCA_003D != null;
		_0023_003DzY8c1My4_003D = _0023_003DzjYYAPCA_003D;
		if (flag)
		{
			this.m__0023_003DzjYYAPCA_003D.Clear();
		}
		this.m__0023_003DzraVZG9g_003D = flag;
		if (!flag)
		{
			this.m__0023_003DzjYYAPCA_003D.Push(new _0023_003DzTFNDoh0_003D(_0023_003DzVC9FBdo_003D));
		}
		_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D[] array = _0023_003Dz6It9KyA_003D;
		foreach (_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2 in array)
		{
			if (!_0023_003DzG7wWBse_002434UcDBdIDTNaews_003D(this.m__0023_003DzmjtwFUo_003D, _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP(), _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003DzWkGfI94pX_1bh7ki_0024ibBr76u1WoF7rtxOQ_003D_003D()))
			{
				continue;
			}
			switch (_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003DzHNQpG_0024tpOYew_0024lIt6Na01xNspeW9JtA6VkrG8Oymy_0024jT())
			{
			case 2:
				if (flag || !_0023_003DzG7wWBse_002434UcDBdIDTNaews_003D(_0023_003DzVC9FBdo_003D, _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP(), _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003DzWkGfI94pX_1bh7ki_0024ibBr76u1WoF7rtxOQ_003D_003D()))
				{
					this.m__0023_003DzjYYAPCA_003D.Push(new _0023_003DzTFNDoh0_003D(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003Dza7solxePsmv2EY25WA_003D_003D()));
				}
				break;
			case 1:
				if (flag)
				{
					this.m__0023_003DzjYYAPCA_003D.Push(new _0023_003DzTFNDoh0_003D(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003Dza7solxePsmv2EY25WA_003D_003D()));
				}
				break;
			case 4:
				if (flag)
				{
					this.m__0023_003DzjYYAPCA_003D.Push(new _0023_003DzTFNDoh0_003D(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003DzNDlTHT0PLMDCjvbpMY63Hf0_003D(), _0023_003DzjYYAPCA_003D));
				}
				break;
			case 0:
				if (flag)
				{
					Type type = _0023_003DzjYYAPCA_003D.GetType();
					Type type2 = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003DzDL_0024AIIUsZu81fPnSIcyANxSE_0024TBjaishcQ_003D_003D(), _0023_003DzVC9FBdo_003D: true);
					if (type == type2 || type.IsSubclassOf(type2))
					{
						this.m__0023_003DzjYYAPCA_003D.Push(new _0023_003DzTFNDoh0_003D(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003Dza7solxePsmv2EY25WA_003D_003D(), _0023_003DzjYYAPCA_003D));
						this.m__0023_003DzraVZG9g_003D = false;
					}
				}
				break;
			}
		}
		_0023_003Dz_Z2_JTJDd9sWOd03XiTIY386_00248_0024k();
	}

	private static bool _0023_003DzE3R7JkA_002492yoTb2YGdjy0NJK6iRO(object _0023_003DzjYYAPCA_003D)
	{
		return RemotingServices.IsTransparentProxy(_0023_003DzjYYAPCA_003D);
	}

	private static void _0023_003DzBm2NNfOzji0uOUZRIW2MBPjB3Gp5X_3glw_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDdxEYiosUoRxou9IAkTu5pP0Zva2LvigIg_003D_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static void _0023_003DzaG2gAGXCwj7uCLKo84evKksgzFiS7FSJCQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D _0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D2 = _0023_003Dz9H6fXyzrPyrSqa8AE5aXDwx8c0jT(_0023_003DzjYYAPCA_003D);
		_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dzivyja_00240_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D();
		long num = _0023_003DzjYYAPCA_003D._0023_003DzdHuQ4vUXAFrCkVr_0024V2X7arg_003D();
		byte[] array = new _0023_003Dq4OhRvt2sLe4PD9nLI_GOIMoFm_0024o0kllhPPsbK6LA6Sw_003D(_0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D2._0023_003DzPlBYbboJj4PEW3TbbF8FZq4mwfqoyePMCjQfRPhN_mn1m86Edy1xLOj0iLXr1IklVw4XiJL9KLkmrRPkxw_003D_003D(), _0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D2._0023_003DzPlBYbboJj4PEW3TbbF8FZq4mwfqoyePMCjQfRPhN_mmD871IktEiFvuhGNw4_00241yVUf5kXdLtuAETsgNWpoi1clk_003D())._0023_003DzUkPPuiIBkLbiKzilkzg1OsAgdW_s(_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D2, _0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D2);
		_0023_003DzDp118Pw_003D _0023_003DzDp118Pw_003D2 = new _0023_003DzDp118Pw_003D
		{
			_0023_003DzjYYAPCA_003D = _0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D2,
			_0023_003Dzf4Pqh9s_003D = num
		};
		_0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D2._0023_003DzGhqi_3VBVF00NVQRV5jf04nCCkORhxQgywV_00244us_003D(_0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D._0023_003DzE8ZqUKqP0by6F02RxvOAQYQ_003D(array.Length) - array.Length);
		_0023_003DzDp118Pw_003D2._0023_003DzVC9FBdo_003D = new _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D(_0023_003DzDp118Pw_003D2._0023_003DzwBouG0w_003D = new _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D(array, 0, array.Length, _0023_003Dzf4Pqh9s_003D: false));
		_0023_003DzjYYAPCA_003D._0023_003DzRN_0024T_e_ketn6jFfvoGJBd6Z0eCaV().Push(_0023_003DzDp118Pw_003D2);
		_0023_003DzjYYAPCA_003D._0023_003Dzxn1GiqJsszWIPLqbSNdHO5j1n2nqhb_8GQr0yfc_003D(_0023_003DzDp118Pw_003D2);
	}

	private static void _0023_003DzMjRhYJtklVTZjrSXqUyqmnTwjEHE(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDE05hLaLH65q6l2w5aXfxhfkQSxYsID41w_003D_003D(0);
	}

	private static void _0023_003Dzdx_00243FCzN706aRPX8Iw2fE24ztFCL(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(4);
	}

	private static void _0023_003Dzb0zk3xwznqylK4djI4QOAZs_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(2);
	}

	private static void _0023_003Dz4wq6IfOAwWrObNrbvLX0p_0024o_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private string _0023_003Dz_0024vGYNMHiNhnPj_9y_DQjzIxlL7viv0q7xqNNcxkdiFoF(int _0023_003DzjYYAPCA_003D)
	{
		lock (_0023_003Dzgd4c0yY_003D)
		{
			bool flag = true;
			if (flag && _0023_003Dzgd4c0yY_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value))
			{
				return (string)value;
			}
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = _0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(_0023_003DzjYYAPCA_003D);
			if (_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003Dzr_EmRq1bb965XQHX42A1yCMQVgDqEWiC_0024Q_003D_003D() == 0)
			{
				return this.m__0023_003DzJ6W8874_003D.ResolveString(_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN());
			}
			string text = ((_0023_003Dq14OGuS53TTgJXN5XHcnlTNUzoMSML4Kc3WYG6QA16tY_003D)_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003Dzda7qbCrYRS_dkFu4eYeIJBGfF1ZN())._0023_003DzcbPtzh2EfhZKuZv_e08YTv4q_JHr_7MhrA_003D_003D();
			if (flag)
			{
				_0023_003Dzgd4c0yY_003D.Add(_0023_003DzjYYAPCA_003D, text);
			}
			return text;
		}
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003Dzl6jejgAs6dRjbmebDDP7OOz_0024X5wFpDr9hA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num ^ num2);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				int num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num3 ^ num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num3 ^ num5);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				long num6 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				long num7 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num6 ^ num7);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				int num8 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num8 ^ num9);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				int num10 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()) ^ num10);
				}
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()) ^ num10);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				long num12 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num11 ^ num12);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					long num14 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num13 ^ num14);
				}
				int num15 = Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				int num16 = Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num15 ^ num16);
			}
		}
		throw new InvalidOperationException();
	}

	private void _0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D()
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 = (_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D)_0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
	}

	private void _0023_003DzU_0024O_hBSbvhYSWXw4fr_zQnw_003D(_0023_003Dqje8unbeuXWKDdxL8YmRQgarGMD66B39FufkB_00246Pya8w_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = _0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(_0023_003DzjYYAPCA_003D._0023_003DzeoqQ_toxluKMucbIc_j16YZe6AjnpZsI3A_003D_003D());
		MethodBase methodBase = _0023_003DzaAnEqGxEYVIky7u6aHRajNVELEAgywuVoJq5Bhg_003D(_0023_003DzjYYAPCA_003D._0023_003DzeoqQ_toxluKMucbIc_j16YZe6AjnpZsI3A_003D_003D(), _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2);
		int num = _0023_003DzjYYAPCA_003D._0023_003DzHozIKZqMf1yXXtuIj1TlZnjDRQk6wcy0GVoYFu0_003D();
		bool flag = (num & 0x40000000) != 0;
		num &= -1073741825;
		Type[] array = _0023_003DzaKmBh2M_003D;
		Type[] array2 = this.m__0023_003Dzf4Pqh9s_003D;
		try
		{
			_0023_003DzaKmBh2M_003D = ((methodBase is ConstructorInfo) ? null : methodBase.GetGenericArguments());
			this.m__0023_003Dzf4Pqh9s_003D = methodBase.DeclaringType.GetGenericArguments();
			_0023_003DzJffmNhaH7ZDZ_zLuaa9fA3s7_0024uZN(num, _0023_003DzaKmBh2M_003D, this.m__0023_003Dzf4Pqh9s_003D, flag);
		}
		finally
		{
			_0023_003DzaKmBh2M_003D = array;
			this.m__0023_003Dzf4Pqh9s_003D = array2;
		}
	}

	private static void _0023_003DzDTpArqXFbkHglDLn1dTYolFdeDT53K3tr7OQ1pM_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz5uz1g3hDsw_0024kQ_0024BOnU6xGYrafh_gbeI2XC40mbg_003D(((_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D)_0023_003DzVC9FBdo_003D)._0023_003DzUrMOHuJ4xEdyCagt_0024A_003D_003D());
	}

	private static byte[] _0023_003DzSWvqCoiw3rSW_MEKwS1EipYB3nxeQTwXDvvAZdw_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		int num = _0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D();
		byte[] result = new byte[num];
		_0023_003DzjYYAPCA_003D._0023_003Dz4_0024_0024Pexl8uo2gvGDQRlS7Fo9UIeiv8gfT0g_003D_003D(result, 0, num);
		return result;
	}

	private static void _0023_003DzxtskdZkOK_0024K_QoGYc_0024pbhRHmTQg4(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDyMz08iL72ZP1158HXKAoQZNcqfmGLIITQ_003D_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private bool _0023_003DzCqQwOaTDluDM7kNOfx7XJS8_003D(MethodBase _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003DzjYYAPCA_003D.IsVirtual)
		{
			return false;
		}
		if (_0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(m__0023_003DzbAh_0024yNw_003D._0023_003DzOLMnH5O6nDdsgeNelug7d7P67d9Rvtr_00241w_003D_003D(), _0023_003DzVC9FBdo_003D: true).IsSubclassOf(_0023_003DzjYYAPCA_003D.DeclaringType))
		{
			return true;
		}
		return false;
	}

	private static void _0023_003Dz8Bf3fV0jtsA8YTCjXWd59IEb7WSfPUzVsA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzjYYAPCA_003D._0023_003DzmfIPvK_0024PsTQjNK_0024pCmCN9anQRL79l18SfU09xLs_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
	}

	private void _0023_003DzDdxEYiosUoRxou9IAkTu5pP0Zva2LvigIg_003D_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		bool flag = IntPtr.Size == 4;
		IntPtr intPtr;
		switch (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 1:
		{
			int value = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
			intPtr = ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(value) : new IntPtr(value));
			break;
		}
		case 13:
		{
			long num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			intPtr = ((!flag) ? ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(num) : new IntPtr(num)) : ((!_0023_003DzjYYAPCA_003D) ? new IntPtr((int)num) : new IntPtr(checked((int)num))));
			break;
		}
		case 8:
		{
			double num2 = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			intPtr = ((!flag) ? ((!_0023_003DzjYYAPCA_003D) ? new IntPtr((long)num2) : new IntPtr(checked((long)num2))) : ((!_0023_003DzjYYAPCA_003D) ? new IntPtr((int)num2) : new IntPtr(checked((int)num2))));
			break;
		}
		case 19:
			intPtr = ((!_0023_003DzjYYAPCA_003D) ? new IntPtr((long)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : new IntPtr(checked((long)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()))));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D obj = new _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D();
		obj._0023_003DzUmdxhDjG74GKtyVW7F3F36VHvsjdtmQ2z8h1mFw_003D(intPtr);
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D[] _0023_003DzCEvGzsiOXS7Fsydh_4iK_0024xQLP1SEZuUJarhtVQk_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		int num = _0023_003DzjYYAPCA_003D._0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D();
		_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D[] array = new _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003DzQq5nLweGWqS_0024KHXLRAD4gYAFUeUUJ0Kb7zhZ9S8_003D(_0023_003DzjYYAPCA_003D);
		}
		return array;
	}

	private static void _0023_003DzGvJ5zaMdsINLbBkrdscpG3rXyFbX(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003DzqKfj9CYzraegqxnAVn6xXHc988bL7uxPBd_qGLg_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(sbyte));
	}

	private static void _0023_003DzpqP6C3BtSQa_0024uEiJ0bIcsFXo63_h44aBY41k1v0_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622612));
	}

	private static void _0023_003Dz0t885_B0F52F3C4wHUHxX2Zwrxtd(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzrD_0024e29g_G2oGu00c_0024qgXo06y_0024yJdKPymZQ_003D_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003DzpvdSNw3Gy4_XVu2QSzlMd_0024pw9MZQ(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type elementType = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		int length;
		if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2)
		{
			length = _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		}
		else if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D2)
		{
			length = _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D2._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp().ToInt32();
		}
		else
		{
			if (!(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D _0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D2))
			{
				throw new Exception();
			}
			length = (int)_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D2._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D().ToUInt32();
		}
		Array array = Array.CreateInstance(elementType, length);
		_0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D obj = new _0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D();
		obj._0023_003DzVMjvbx1F3Y3vH0VPi7ebmaEXlAolbWHv2g3U9eA_003D(array);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static void _0023_003DzKli5nI8i_0024JvIOKrcvX9DA0hwcoPbvtjQn9gvA_A_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(uint));
	}

	private static void _0023_003DzgQrS6PV7UNhd2Fe1JNjaoYNIRQxB0r85XQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz0mcH6doIj0ry_0024d9df66SJ3U3LV6zUlnjgQ_003D_003D(_0023_003DzVC9FBdo_003D);
	}

	private static void _0023_003DzgD6A9TlKR25H1NhaxIamps0_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(2);
	}

	private static void _0023_003DzpmJskuZMWqCuauwtsQKtGMY_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzjZ5w2QCyoeebeU5XHnTLRZk_003D(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: true);
	}

	private static Exception _0023_003DzcAn_0024G9Qy46uqlVBEbeJyZcbop5XNrB4APw4TERXh3Z8_0024(string _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D)
	{
		return new MethodAccessException(_0023_003DzPKGMroGOWHhmnvL5AzUMb_ZYt_srfMzCHTjRfd8_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620886) + _0023_003DzjYYAPCA_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621217) + _0023_003DzVC9FBdo_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914)));
	}

	private static _0023_003DzraVZG9g_003D _0023_003DziL3lnfTn0zrsnlZ_LInxeHJfndrMRbVJ9Q_003D_003D(_0023_003DzJ6W8874_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzraVZG9g_003D value;
		lock (_0023_003DzTD9escs_003D)
		{
			_0023_003DzTD9escs_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out value);
		}
		if (value != null)
		{
			return value;
		}
		MethodBase key = _0023_003DzjYYAPCA_003D._0023_003DzoHqx0vq_00243HCz7aG3aJN3KzLwo_k3S0YU0RjED9E_003D();
		lock (_0023_003DzDmRZtNk_003D)
		{
			while (_0023_003DzDmRZtNk_003D.ContainsKey(key))
			{
				Monitor.Wait(_0023_003DzDmRZtNk_003D);
			}
			_0023_003DzDmRZtNk_003D[key] = null;
		}
		try
		{
			lock (_0023_003DzTD9escs_003D)
			{
				_0023_003DzTD9escs_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out value);
			}
			if (value == null)
			{
				value = _0023_003DzI7ZS6H5p3q75HrHPblTaXVhSI8ri(key, _0023_003DzjYYAPCA_003D._0023_003Dz8hyxt74k_91OG94pHrOASURB9KA0_iCNIFAfTGA_003D());
				lock (_0023_003DzTD9escs_003D)
				{
					_0023_003DzTD9escs_003D[_0023_003DzjYYAPCA_003D] = value;
				}
			}
			return value;
		}
		finally
		{
			lock (_0023_003DzDmRZtNk_003D)
			{
				_0023_003DzDmRZtNk_003D.Remove(key);
				Monitor.PulseAll(_0023_003DzDmRZtNk_003D);
			}
		}
	}

	private static void _0023_003DzALiOMWAsGbjKSV0kAlI6sAMa_eWTOMQxEm58xVA_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621800));
	}

	private static void _0023_003Dzc6LNbmyaxLDNmnqZeUL0XSiFLz1i1dvdXQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (sbyte)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (sbyte)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (sbyte)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => (sbyte)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((sbyte)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((sbyte)(uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private void _0023_003Dz0xkx_0024FbQA5T935rV9MlZIZQ_003D(MethodBase _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		bool flag = !_0023_003DzVC9FBdo_003D && _0023_003DzCqQwOaTDluDM7kNOfx7XJS8_003D(_0023_003DzjYYAPCA_003D);
		if (flag && _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003Dzf4Pqh9s_003D._0023_003DzjYYAPCA_003D)
		{
			_0023_003DzjYYAPCA_003D = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003Dzt2pW2yo_003D._0023_003DznhxElRzbdvuEUHBG9_0024VXsulvtrLnIKYBYA_003D_003D(this, m__0023_003DzbAh_0024yNw_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		}
		ParameterInfo[] parameters = _0023_003DzjYYAPCA_003D.GetParameters();
		int num = parameters.Length;
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] array = new _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[num];
		object[] array2 = new object[num];
		_0023_003DzwBouG0w_003D _0023_003DzwBouG0w_003D2 = default(_0023_003DzwBouG0w_003D);
		try
		{
			_0023_003Dz1rV5jwYXvJleR8kc6Ss4eBN0LIeFGAyWcfoT7Fw_003D(ref _0023_003DzwBouG0w_003D2, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = (array[num2] = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D());
				if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2);
				}
				if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D() != null)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D())._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
				}
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, parameters[num2].ParameterType)._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
				array2[num2] = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
			}
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 = null;
			if (!_0023_003DzjYYAPCA_003D.IsStatic)
			{
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
				if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 != null && _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D() != null)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D())._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4);
				}
			}
			object obj = null;
			object obj2 = null;
			try
			{
				if (_0023_003DzjYYAPCA_003D.IsConstructor)
				{
					obj = Activator.CreateInstance(_0023_003DzjYYAPCA_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array2, null);
					if (!(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D))
					{
						throw new InvalidOperationException();
					}
					obj2 = obj;
				}
				else
				{
					if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 != null)
					{
						_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D5 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4;
						if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D3)
						{
							_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D5 = _0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D3);
						}
						obj2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D5._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
					}
					try
					{
						if (!_0023_003Dzt63WCO3vjTl0sdemnwYQtO7PA8OBTPwVcbDgYpo_003D(_0023_003DzjYYAPCA_003D, obj2, ref obj, array2))
						{
							if (_0023_003DzVC9FBdo_003D && !_0023_003DzjYYAPCA_003D.IsStatic && obj2 == null)
							{
								throw new NullReferenceException();
							}
							if (!_0023_003DzDi5YIr3nzofmFxxw54VLk9EOgbhkBBwi_0024A_003D_003D(_0023_003DzjYYAPCA_003D, obj2, array, array2, _0023_003DzVC9FBdo_003D, ref obj))
							{
								MethodBase methodBase = _0023_003DzjYYAPCA_003D;
								object obj3 = obj2;
								if (flag && !_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003Dzf4Pqh9s_003D._0023_003DzjYYAPCA_003D)
								{
									obj3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003DzmZWYhFQ_003D._0023_003DzbVEfm52MCEQEf1K6LLJ7mYoItfx9Et4mF7EYSAo_003D(obj2, _0023_003DzjYYAPCA_003D, out var methodInfo);
									methodBase = methodInfo;
								}
								obj = _0023_003DzxRKpnEfB4r0_0024al4LmLb_0024SVDOPjC6rNNG_Q_003D_003D(methodBase, obj3, array2, _0023_003DzVC9FBdo_003D);
							}
						}
					}
					catch (TargetInvocationException ex)
					{
						Exception ex2 = ex.InnerException ?? ex;
						_0023_003DzPalNqUCr87jJQ2wBQmQB49pkBtH_0024(ex2);
					}
				}
			}
			finally
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D4)
					{
						object obj4 = array2[i];
						_0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D4, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj4, null));
					}
				}
				if (obj2 != null && _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D5)
				{
					bool flag2 = true;
					if (_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D5 is _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2)
					{
						flag2 = _0023_003Dz7O9cYwSi7BWCfwoAn4IKAvg_003D(_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2);
					}
					if (flag2)
					{
						_0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D5, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj2, _0023_003DzjYYAPCA_003D.DeclaringType));
					}
				}
			}
			MethodInfo methodInfo2 = _0023_003DzjYYAPCA_003D as MethodInfo;
			if (methodInfo2 != null)
			{
				Type returnType = methodInfo2.ReturnType;
				if (returnType != _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D)
				{
					_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, returnType));
				}
			}
		}
		finally
		{
			_0023_003DzX8NAj5tJmqoBVnjrpzPupq2Fwpct(ref _0023_003DzwBouG0w_003D2);
		}
	}

	private _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(int _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzKufrQS0_003D == null)
		{
			throw new InvalidOperationException();
		}
		lock (_0023_003DzKufrQS0_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D())
		{
			_0023_003DzKufrQS0_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D()._0023_003DzF9bNse9wHJLLtepk_gT8nT7RoArbYZ5O7BM_0024pvRSfZZCcif09QuhqkEcicQBZU2Q_1FotqnGeCeOOleA6w_003D_003D(_0023_003DzjYYAPCA_003D, 0);
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D();
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003DzbhlOEsdnEkA7eYqpilK_0024L1ce09ot(_0023_003DzKufrQS0_003D._0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D());
			if (_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003Dzr_EmRq1bb965XQHX42A1yCMQVgDqEWiC_0024Q_003D_003D() == 0)
			{
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003DzyTDUc2e71fyfiu5D8w_003D_003D(_0023_003DzKufrQS0_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			}
			else
			{
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003DzilHQXE308aHUUPNnBeTkkY2vT3CVjj9v0vv_ztbeLPCK(_0023_003DzIk7qBK4C_0024VGVhrNC1uAGHjYkUsNDjInPuqMaAxuW57T3(_0023_003DzKufrQS0_003D));
			}
			return _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2;
		}
	}

	private static void _0023_003Dz22XZDswZzPKvTBsALR8QneTXcDpxezrp9w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMrJpDjzTv4w8b_0024EDqRHaMnnujtbSQqxrkuL8ibA_003D(_0023_003DzVC9FBdo_003D);
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzStnKjFkmuO5zc0ZMVA97i8yATWRoZOmsAxMMau_Wl6q2(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (!_0023_003Dzf4Pqh9s_003D)
		{
			long num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num3 = ((!_0023_003DzwBouG0w_003D) ? (num + num2) : checked(num + num2));
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num5 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num6 = ((!_0023_003DzwBouG0w_003D) ? (num4 + num5) : checked(num4 + num5));
		return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D((long)num6);
	}

	private static void _0023_003DzBzxFrO2pb1nUDYU0Ckm8LGkC5YsE(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622457));
	}

	private void _0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(uint _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzOIZPJ_00248_003D = _0023_003DzjYYAPCA_003D;
	}

	private static void _0023_003DzfDm4J5VFoJ7ruiV_0024vJSJ2VNImfZvQ8J4Og_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzrD_0024e29g_G2oGu00c_0024qgXo06y_0024yJdKPymZQ_003D_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static object _0023_003DzT5WJMTijRhl7mUu1uw_003D_003D(MethodBase _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D, object[] _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D.IsConstructor)
		{
			try
			{
				return Activator.CreateInstance(_0023_003DzjYYAPCA_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003DzwBouG0w_003D, null);
			}
			catch (AmbiguousMatchException)
			{
				return ((ConstructorInfo)_0023_003DzjYYAPCA_003D).Invoke(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003DzwBouG0w_003D, null);
			}
		}
		return _0023_003DzjYYAPCA_003D.Invoke(_0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
	}

	private static void _0023_003Dz0WSxR76tl25dc5ugsswNzj_0024cHfpHkLr1oQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		Debugger.Break();
	}

	[Conditional("DEBUG")]
	public static void _0023_003DzIYk7L4_0024YBNN5MBArABcd3nInZjbT(string _0023_003DzjYYAPCA_003D)
	{
	}

	private static Dictionary<int, _0023_003DzLtLprGE_003D> _0023_003DzJ16rViqZyydIFfjuyBh_EZESFV5Q(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmlAaZGkNAoWogHOkZvqFGU_003D _0023_003DzjYYAPCA_003D)
	{
		return new Dictionary<int, _0023_003DzLtLprGE_003D>(256)
		{
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz6cOnd9M_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz6cOnd9M_003D, _0023_003DzkwR4MYlSgdi9YPxvO7X6byeYcKNZ)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzgDAPpuo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzgDAPpuo_003D, _0023_003Dz22XZDswZzPKvTBsALR8QneTXcDpxezrp9w_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz5BgXqy0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz5BgXqy0_003D, _0023_003DzdFasG0ZCqGMBnuGQsgGIypx3xkK4)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzVC9FBdo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzVC9FBdo_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					if (!_0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
					{
						uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
						_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
					}
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzDw__wI8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzDw__wI8_003D, _0023_003Dz7xiizXYgpL1JHnuu_fnIWet75WQJ)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DziQhyw2I_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DziQhyw2I_003D, _0023_003DzA_02Epg7V4DRFn9qQwcxTisf_VfTrb9mJQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzYDAm3To_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzYDAm3To_003D, _0023_003Dz_LihIsurHWx3_5uyYrzrirA_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzraVZG9g_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzraVZG9g_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzZlh7jtnX_FWEcU6dnmuZNpST3cf_0024pYZ5sQT1Xf8_003D(_0023_003DzjYYAPCA_003D: true);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzPyFl18U_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzPyFl18U_003D, _0023_003DzvQyud78xlsmLdllzCeQEeOg39WkCcjDD_g_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzdBIDw9w_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzdBIDw9w_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(0);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzo5WhAr0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzo5WhAr0_003D, _0023_003DzpZ8rU5lnz1wCSCAaDg61kvzKxkUV)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzkdS3nm0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzkdS3nm0_003D, _0023_003DzY8clfAmD8ZSkgVFu9rDdixN3JiBLrvBFrtfa6My4Qg6E)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzZmkJseI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzZmkJseI_003D, _0023_003DzMe1CBJHLl8UvzbJJG9RwHAk_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzLK6YY4s_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzLK6YY4s_003D, _0023_003DzNIIJQoDINGa68UxsF8L7gbkQByN9Rn1EFYLGkuA_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzf_0024_0024Ar9M_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzf_0024_0024Ar9M_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622612));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzTFNDoh0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzTFNDoh0_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(3);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzOr41T4Q_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzOr41T4Q_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzDp118Pw_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzDp118Pw_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					if (_0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
					{
						uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
						_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
					}
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzAuQ_FXg_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzAuQ_FXg_003D, _0023_003DzMcQFOpwXwXprCzsanK3b9HPKmrju)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzkpJ1y4k_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzkpJ1y4k_003D, _0023_003DzHa7slzoHYTJpNrs9mXp8mLCP0MRN6uQY2pd1ZA9Sit25)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz0yDzO_0024c_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz0yDzO_0024c_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2 = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2;
					MethodBase methodBase = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
					Type declaringType = methodBase.DeclaringType;
					Type type = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType();
					ParameterInfo[] parameters = methodBase.GetParameters();
					Type[] array = new Type[parameters.Length];
					for (int i = 0; i < parameters.Length; i++)
					{
						array[i] = parameters[i].ParameterType;
					}
					MethodBase methodBase2 = null;
					Type type2 = type;
					while (type2 != null && type2 != declaringType)
					{
						MethodInfo method = type2.GetMethod(methodBase.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array, null);
						if (method != null && method.GetBaseDefinition() == methodBase)
						{
							methodBase2 = method;
							break;
						}
						type2 = type2.BaseType;
					}
					if (methodBase2 == null)
					{
						methodBase2 = methodBase;
					}
					_0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D obj = new _0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D();
					obj._0023_003Dzs_H9tD4fic5haXYigbX6_iA_003D(methodBase2);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzmYVdEjY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzmYVdEjY_003D, _0023_003DzGPKeNMW7vKpKwMSB0YIjG2I_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzwtkTdfw_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzwtkTdfw_003D, _0023_003DzgD6A9TlKR25H1NhaxIamps0_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzuW1CqYA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzuW1CqYA_003D, _0023_003DzOT2cGQSyrcB6qUudvJv64TUiR_OWQtWUuA_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz5kvQ5Hg_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz5kvQ5Hg_003D, _0023_003DzLMZRlRU0YaDEheGI98D_SLg_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzMhr2LyQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzMhr2LyQ_003D, _0023_003DzDTpArqXFbkHglDLn1dTYolFdeDT53K3tr7OQ1pM_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz3kjjQlQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz3kjjQlQ_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzrD_0024e29g_G2oGu00c_0024qgXo06y_0024yJdKPymZQ_003D_003D(_0023_003DzjYYAPCA_003D: true);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzxzvTo00_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzxzvTo00_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(5);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz7dLpRsk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz7dLpRsk_003D, _0023_003DzGvJ5zaMdsINLbBkrdscpG3rXyFbX)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzmJGqfJY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzmJGqfJY_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzrhmC7EzIlogvg37F_0024jM9GV_GEYF9(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzY8c1My4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzY8c1My4_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzdUHcgd4GhDGoM7VtTWsRa_0024I_003D(_0023_003DzjYYAPCA_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzLnf0_0024lc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzLnf0_0024lc_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz85YPZTAMkedt0zGj9E3AUSkVpyiZ(_0023_003DzjYYAPCA_003D: false, _0023_003DzVC9FBdo_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzkjGnIMQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzkjGnIMQ_003D, _0023_003DzzrOcj9pfVrCXXxtyrItRZDhbdS4_bKpeF1haaOA_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz09M7LQY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz09M7LQY_003D, _0023_003DzVVWUWzKq0WhUQGWh3f1AdcFFFjnjLoq0jr2erAQ_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzprO7igs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzprO7igs_003D, delegate
				{
					Debugger.Break();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzQQicCX8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzQQicCX8_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzjZ5w2QCyoeebeU5XHnTLRZk_003D(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzFutNBfQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzFutNBfQ_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Type type = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(type);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzr_0024cEGfg_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzr_0024cEGfg_003D, _0023_003DzbhMnO4YF8Epr4S_wYlgv2lc4wyGT)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzHn5kbtE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzHn5kbtE_003D, _0023_003DznhNBt2wQrbbNPMO1dbAJwdmo43PY9hkcYMiRACA_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzWLrZlTE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzWLrZlTE_003D, _0023_003DzAT_SvBa7QonL2NIaI76iiMS1pUiG9vltNbRXiUBcS8ph)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzmjtwFUo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzmjtwFUo_003D, _0023_003DzVIKtdf3ifJpqJFlmyPlzjsR5YZHupu9XOQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzPRPNrro_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzPRPNrro_003D, _0023_003DzKDDUUneJSSls9HGDW4VNxHMlWKj65uH9yjRRHCE_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzZ8tYtAY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzZ8tYtAY_003D, _0023_003Dz7eyIzgD6kKtLG7stLlksnLiQQ9ODXp535YNhLb4aKbQU)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzJU0R6e0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzJU0R6e0_003D, _0023_003DzZvpm9ZNyBYIlhWoRw_u5d_A_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzXmqsZ2I_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzXmqsZ2I_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
					{
						1 => (ushort)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
						13 => (ushort)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
						19 => (ushort)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
						8 => (ushort)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((ushort)(uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzrMClyx8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzrMClyx8_003D, _0023_003DzKCew6PWLdl_flti8Q4CQRZo_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzMFQrFCo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzMFQrFCo_003D, _0023_003DzjrVsHR2Ee3xIM1NrcKJKQcuyGARCDlYHax859qg_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzkHYU37s_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzkHYU37s_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Type type = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(type);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzEUCwvjE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzEUCwvjE_003D, _0023_003Dza0MuWaEORbfaBjPtkJiLu8s_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzqx7xw4U_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzqx7xw4U_003D, _0023_003DzMjRhYJtklVTZjrSXqUyqmnTwjEHE)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzKvkiXSI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzKvkiXSI_003D, _0023_003Dz_zpN5f6cN_sElg05zs3akGM_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzW_0024pZGy8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzW_0024pZGy8_003D, _0023_003DzqRVPHAkNucbise69FHuFY9zzBGLXPu8lkA_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzAZiTqNs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzAZiTqNs_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(uint));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzKufrQS0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzKufrQS0_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
					obj._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(_0023_003DznAT2eFkICx6B9STO5ogYSiU_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzk_DblsQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzk_DblsQ_003D, _0023_003Dz46_hQN3Pp0N44ISYYh4SlpQ_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz1SmHC4c_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz1SmHC4c_003D, _0023_003DzPb0quhUqQ50c_rQaGdIvRCGjsEGT5J7Y6HoKUuDIpSUY)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzt2pW2yo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzt2pW2yo_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzFdlupYgUze2_0024waqwlXUpS5UI_0024l4h(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzXKkoCy0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzXKkoCy0_003D, _0023_003DzUwvqhFWPmdgqqMrtbgZzROs_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzrOXxJ28_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzrOXxJ28_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(_0023_003DzhGgZIrA_003D);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzi8OTyx4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzi8OTyx4_003D, _0023_003Dz82H5rO8lutrvay2FD42A9d8_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzd1hAZ4A_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzd1hAZ4A_003D, _0023_003DzmocyYX3gMQ3qTlllXKtAazZtdhw2s0No0xoT4jGsbf4v)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzfkPKRYQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzfkPKRYQ_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
					{
						1 => (byte)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
						13 => (byte)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
						19 => (byte)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
						8 => (byte)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((byte)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((byte)(uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz_0024nLfT_A_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz_0024nLfT_A_003D, _0023_003Dzlhaep8HqUDVoSvW03lcpGbDN0i4sfGNOX05n_QY_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzPPhL6kw_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzPPhL6kw_003D, _0023_003Dz1MWsfwNOQWrz2VqmQDF8tQwQuqI6)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzBVC71KE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzBVC71KE_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Type type = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), type);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz5PxKZP0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz5PxKZP0_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzjZ5w2QCyoeebeU5XHnTLRZk_003D(_0023_003DzjYYAPCA_003D: false, _0023_003DzVC9FBdo_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzVEHRsFg_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzVEHRsFg_003D, _0023_003DzJ4nQy4z5J6IfeAaMLfSlHN4_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzLtLprGE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzLtLprGE_003D, _0023_003DzqKfj9CYzraegqxnAVn6xXHc988bL7uxPBd_qGLg_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzRoqMfFc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzRoqMfFc_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dznmd_5fw_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dznmd_5fw_003D, _0023_003DzL54ae66vsjw5GZ9dSBhTXDJE3LAU_m7bmBnB21c_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzdXm8s1g_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzdXm8s1g_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					FieldInfo fieldInfo = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D(fieldInfo, null));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzivyja_00240_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzivyja_00240_003D, _0023_003DzOQH_SHsKcK1efN61h2AqQuo_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzOIZPJ_00248_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzOIZPJ_00248_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzFdlupYgUze2_0024waqwlXUpS5UI_0024l4h(_0023_003DzjYYAPCA_003D: false, _0023_003DzVC9FBdo_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzEqbQfP8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzEqbQfP8_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D obj = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					if (obj._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 1)
					{
						throw new InvalidOperationException();
					}
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)obj)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Stack<_0023_003DzDp118Pw_003D> stack = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzRN_0024T_e_ketn6jFfvoGJBd6Z0eCaV();
					if (stack.Count < 2)
					{
						throw new InvalidOperationException();
					}
					using _0023_003DzDp118Pw_003D _0023_003DzDp118Pw_003D2 = stack.Pop();
					if (_0023_003DzDp118Pw_003D2 == null || _0023_003DzDp118Pw_003D2._0023_003DzjYYAPCA_003D._0023_003DzvOtRKFvvRycWecHWbaWMw1PQYV4beLHt_0024Z_0024L3f_0024hUNaOeTNTqp80tyV5sf5QK7xhO5ui3e3ZeH22() != num)
					{
						throw new InvalidOperationException();
					}
					_0023_003DzDp118Pw_003D _0023_003DzDp118Pw_003D3 = stack.Peek();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dzxn1GiqJsszWIPLqbSNdHO5j1n2nqhb_8GQr0yfc_003D(_0023_003DzDp118Pw_003D3);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzWoS2eJk_003D += (uint)_0023_003DzDp118Pw_003D2._0023_003DzjYYAPCA_003D._0023_003DzIc18jN2ZnzNBqoyZrA_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzlKeckCaClO9XhMQZJufmJ04_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzWoS2eJk_003D);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzx7NVZ48_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzx7NVZ48_003D, _0023_003Dz1VWzoFLhegTNuv6ecsR3oTQ_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzCqleKvU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzCqleKvU_003D, _0023_003DzoZgEGun3Iu6tMTdIQRP9Ig9AGuoTws1hYw_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DztI8MUyE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DztI8MUyE_003D, _0023_003DzVUqKFtgvt2DGgl2yKQ0j0xSOKIze)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzWERv_Yc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzWERv_Yc_003D, _0023_003Dzh81FqdqNJzYDc4HXLALIlfzrYDARmL_k5gR2H_4Piall)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzW34vfOo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzW34vfOo_003D, _0023_003DzebZ5pYN0ukSwTwO7tjta3TzjbMH0)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzJ6W8874_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzJ6W8874_003D, _0023_003DzIzi14UMR5ANZLHzGZ_HJdbhGyz4VrWitTg_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz4uQoDiI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz4uQoDiI_003D, _0023_003DzKJX1gCxotYp0aYhCYcA8_MY_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzj25UIwk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzj25UIwk_003D, _0023_003DzVQ8pIXB4S2f9cNdpFUqEsMA50ZI_wJjxfDz9GPc_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz1EpCtMQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz1EpCtMQ_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2 = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2;
					MethodBase methodBase = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
					_0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D obj = new _0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D();
					obj._0023_003Dzs_H9tD4fic5haXYigbX6_iA_003D(methodBase);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzD5s6QoI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzD5s6QoI_003D, _0023_003DzLZ0fHUlfV2EvwvOH4zOWwOJc87Pxio_Oyn3qdic_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzSAhtsr0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzSAhtsr0_003D, _0023_003DzUs7QHTDawIPZdoLBlz1AGLoB4fUrHOQflA_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzYbQcnZQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzYbQcnZQ_003D, _0023_003DzALiOMWAsGbjKSV0kAlI6sAMa_eWTOMQxEm58xVA_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz_0024GTvFZg_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz_0024GTvFZg_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzMzB7WojOWsSyL7Bcs9rkRyQ_003D(_0023_003DzjYYAPCA_003D: true);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzWUl5QeA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzWUl5QeA_003D, _0023_003Dz_8KrABb1AmW8LXBeTylINX4NLUF8)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzwd7j5iY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzwd7j5iY_003D, _0023_003DzzNJtPbKXMEgy8xm7Vhm12rMSBky4)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzoLX1o88_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzoLX1o88_003D, _0023_003Dz5zLQmIZbYTHVtwRmvoMhCr14NlYzx3ZUjWK3QgY_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzMxlZvbA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzMxlZvbA_003D, _0023_003Dz0VZBTYD7dXOsjO5S1lhenHeqTEzq)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz_TlNN0s_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz_TlNN0s_003D, _0023_003Dz2ZizGXWu8FprX1Ip68T_ndAKBMim)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz0KV7OXY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz0KV7OXY_003D, _0023_003DzIGBBxvTl4js4YD4F64bHfYPwkFHCiVHt0w_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzAsfC0_00244_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzAsfC0_00244_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzmlrV_1WGATvgi2njhT6WfN0KtM7G();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzdcz2EwQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzdcz2EwQ_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621770));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzZn_13E4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzZn_13E4_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(long));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dza9T4i_I_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dza9T4i_I_003D, _0023_003DzgQrS6PV7UNhd2Fe1JNjaoYNIRQxB0r85XQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz1latlWs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz0KV7OXY_003D, delegate
				{
					Thread.MemoryBarrier();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzu55XgAk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzu55XgAk_003D, _0023_003DzXfP_jNBBHQvtHTQhJHEBrKzeVvYSf5s2jDidYVpKsFSL)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzStplry4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzStplry4_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzXpoVQZQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzXpoVQZQ_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzTD9escs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzTD9escs_003D, _0023_003DzjW5Y9ZOIZozqEHZPFq3wqI84lrFrjIPD4ERhdoc_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzQAbI59M_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzQAbI59M_003D, _0023_003Dz04HrXzwNt523vL8C7Q_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzLB1vLV0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzLB1vLV0_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Type elementType = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					int length;
					if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 is _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2)
					{
						length = _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					}
					else if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 is _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D2)
					{
						length = _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D2._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp().ToInt32();
					}
					else
					{
						if (!(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 is _0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D _0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D2))
						{
							throw new Exception();
						}
						length = (int)_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D2._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D().ToUInt32();
					}
					Array array = Array.CreateInstance(elementType, length);
					_0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D obj = new _0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D();
					obj._0023_003DzVMjvbx1F3Y3vH0VPi7ebmaEXlAolbWHv2g3U9eA_003D(array);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzpBq5joM_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzpBq5joM_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzDdxEYiosUoRxou9IAkTu5pP0Zva2LvigIg_003D_003D(_0023_003DzjYYAPCA_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzjU3US28_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzjU3US28_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Type t = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Marshal.SizeOf(t)));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzkfUqbGA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzkfUqbGA_003D, _0023_003Dz2_zqpZq29PRvwaIPbGotB9vUey9y5rIJDXo7eRaCUHDF)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzRtXoeKk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzRtXoeKk_003D, _0023_003Dzu68lHPA2xBMZd0qM3qGstMyPufBmyNLRuQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzvccLb_o_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzvccLb_o_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
					{
						1 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
						13 => (int)checked((uint)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
						19 => (int)checked((uint)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
						8 => (int)checked((uint)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
						0 => (IntPtr.Size != 4) ? ((int)checked((uint)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
						_ => throw new InvalidOperationException(), 
					}));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzQujKg5Y_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzQujKg5Y_003D, _0023_003DzAlf6ix7B1qKgPYM8yQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzQVubGmM_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzQVubGmM_003D, _0023_003DzpmJskuZMWqCuauwtsQKtGMY_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzFrc_0024oLQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzFrc_0024oLQ_003D, _0023_003DzBm2NNfOzji0uOUZRIW2MBPjB3Gp5X_3glw_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzXSTuKJU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzXSTuKJU_003D, _0023_003Dz4NRcRof53EFYb6x5BJ2Xpl0_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzNeqst7A_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzNeqst7A_003D, _0023_003DzlVsCYPblzZD0QrM7ag_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz1Xfr_002480_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz1Xfr_002480_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(4);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzjukWAy8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzjukWAy8_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz7mKSiLg_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz7mKSiLg_003D, _0023_003DzzAGcnHt4rMiwZX9Ohi_rTodzA2MLV3Truw_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzBrYseb8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzBrYseb8_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622353));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzQccUlQo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzQccUlQo_003D, _0023_003Dz8Bf3fV0jtsA8YTCjXWd59IEb7WSfPUzVsA_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzWoS2eJk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzWoS2eJk_003D, _0023_003DzFTKvDC939pJhUi7xSQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzmZWYhFQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzmZWYhFQ_003D, _0023_003Dzr0c6vnepSbZ0E3fqHP8GrXtjg9Y1HPHS0w_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz3Xo1N9I_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz3Xo1N9I_003D, _0023_003DzHV8nLO9pcE5znPsNFatW0iE_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz2mpQnTY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2mpQnTY_003D, _0023_003DzbYE9J1d2Uocxkgs5SrvRijuzR8jq)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzhGgZIrA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzhGgZIrA_003D, _0023_003DzhVff2zM8hdFnamD7xeV7fSU_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz5Q_00249R5M_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz5Q_00249R5M_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					FieldInfo fieldInfo = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 as _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D;
					object obj = ((_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 == null) ? _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() : _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D(fieldInfo, obj, _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzyRHYfQQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzyRHYfQQ_003D, _0023_003Dz1wFmrgY0lcWEHEgBC6Q2tUI9sucTWaKSDnz8blzuRy_A)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz3obFL1Y_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz3obFL1Y_003D, _0023_003Dz13dUohXMVYTMqdg0Cnosgi4bf4Hsok0i2UzgGdc_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzFspbex8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzFspbex8_003D, _0023_003DzQmtO80N9_GtgttVzzzDyZwG52bMsfKSVKrLURec_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz8TCFuOY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz8TCFuOY_003D, _0023_003DzIENFZMhaQNCsCY1JN6DjTPIzDY_ZO2U42SocMbBBHOaH)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzKtnMqyU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzKtnMqyU_003D, _0023_003Dz1YZs4D3KdNXaj333B3j5cFh5iajY5vVXXJ7VZS8_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DziSR3fdM_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DziSR3fdM_003D, _0023_003Dz6TJX6GwJA7JRdtHrUC8iCtw_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DznB3lUg4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DznB3lUg4_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzPhOe5dIgi9gNB__002400g_003D_003D(_0023_003DzjYYAPCA_003D: true);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzup2h_0024v4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzup2h_0024v4_003D, _0023_003DzVGzhf8XPWiipDzmRB0BKkwo_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzSO5Kl4U_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzSO5Kl4U_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzDyMz08iL72ZP1158HXKAoQZNcqfmGLIITQ_003D_003D(_0023_003DzjYYAPCA_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzltw5qNc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzltw5qNc_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					string text = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_0024vGYNMHiNhnPj_9y_DQjzIxlL7viv0q7xqNNcxkdiFoF(num);
					_0023_003DqcvSJO7LoKSobiAnO2rDGIYGUavn0qNB0nQQmf73tkgM_003D obj = new _0023_003DqcvSJO7LoKSobiAnO2rDGIYGUavn0qNB0nQQmf73tkgM_003D();
					obj._0023_003Dz0Inh7gk9_dfRSPYoERQjRuA_003D(text);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz_0024_0024JBpTY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz_0024_0024JBpTY_003D, _0023_003DzRXHqQpaHW3x9uexWwEJKzplbpvq5)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzITpteWU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzITpteWU_003D, _0023_003Dz6oSbbu_JsQWPzQ0VKqrChaVZMVD48kmZbw_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzbRF3BQU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzbRF3BQU_003D, _0023_003DzcselSIXUW3hfFirzcKALDEnAEgfj)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzQizPEX8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzQizPEX8_003D, _0023_003DzsRA5pdcAI9V7abxXb6a8vRw_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzbekpFEo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzbekpFEo_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzRv4TNIOd4mm0BbpmaDZLiHXQQ_0024vT(_0023_003DzjYYAPCA_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz1g8gp8s_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz1g8gp8s_003D, _0023_003DzXrmHgNU_kWtK1Mw_viHDjjboi4WJ)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzMAFuAGM_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzMAFuAGM_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(typeof(float));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzKfi4z6E_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzKfi4z6E_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzoMNiNRw_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzoMNiNRw_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DztaW4noE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DztaW4noE_003D, _0023_003DzsL0aIKlnpQ5DqbO0YQeNTO9yf6TX)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzE3_0024uWFc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzE3_0024uWFc_003D, _0023_003DzGoVDWdrNUUQM9G7JC7Froz_exskHugYYerTlaNc_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz8GBMuoM_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz8GBMuoM_003D, _0023_003DzktUQSFk4Qs3095LbKoGr97U01s1Vlfe8WQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzaqY9_Z4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzaqY9_Z4_003D, _0023_003Dz_aS7WXvl_JNrHfpNdUASD5o_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzzdXgYPI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzzdXgYPI_003D, _0023_003Dz3jQ9e80k4_heeWfRN9gYjxEHGsv1)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzZm8UBbs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzZm8UBbs_003D, _0023_003DzBqgKJING8PVThSjXR5Z_rVr5lbUG)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz_0024qI1lQs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz_0024qI1lQs_003D, _0023_003DzCVN_VyJLLQPFeMu2vQ089ywGq_Vv3NJVDQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzevtAwuM_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzevtAwuM_003D, _0023_003DzRCCEqF1fiuKSAKL2YlwflWzGMLIceOSlmA_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzEYp_0024UVY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzEYp_0024UVY_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(int));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzNMcPi_0024E_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzNMcPi_0024E_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Type type = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), type);
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(type);
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz_cFD_t8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz_cFD_t8_003D, _0023_003DzKnUCU9ajZDIhczgqBiZEQUAKYXVx)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzrrFe5NM_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzrrFe5NM_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(1);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz7NsQCL4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz7NsQCL4_003D, _0023_003DzZ0zQzFZ76nW_Mhr2YiUWm2omo5K7YmN3LA_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz1kNN9Oc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz1kNN9Oc_003D, _0023_003DzaG2gAGXCwj7uCLKo84evKksgzFiS7FSJCQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz6It9KyA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz6It9KyA_003D, _0023_003DzOZfkVahj53HAL2DsKiXPgwU_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dze7MUxgs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dze7MUxgs_003D, _0023_003DzJ6OZCddORNQAvxN1LNNTV177k5iDEitod232_mTj0_Be)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzQ_UinS4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzQ_UinS4_003D, _0023_003DzYWmKYcncvWa8m0dmkIyY1FdchuDUpOsTr6kFv1A_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzOOo4bvo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzOOo4bvo_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzXMS1M_M1OGkgq8BfaLjs7A4Ea0_00245rZWliw_003D_003D(_0023_003DzjYYAPCA_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzJx6crCU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzJx6crCU_003D, _0023_003Dzc6LNbmyaxLDNmnqZeUL0XSiFLz1i1dvdXQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz6GYXROo_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz6GYXROo_003D, _0023_003Dzk4pSpFXqGqHdlIWcIPdXMSt8XgeTHJjIip3SFao_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzsrc1_0024QY_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzsrc1_0024QY_003D, _0023_003DzWpe7w_OfU54O8LXpqVNio1qZLyxLEJVvNy3Exbs_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzKhixoO0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzKhixoO0_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(1);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzyd4vT_0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzyd4vT_0_003D, _0023_003DzRCZ65n1CAPJNK2vduDk51WU080nb23TBlw_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz_4IhUWs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz_4IhUWs_003D, _0023_003DzBzxFrO2pb1nUDYU0Ckm8LGkC5YsE)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D, _0023_003DzRSdJPqqnhgG7iJjY_SLqPpY_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzpQ3aCQI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzpQ3aCQI_003D, _0023_003DzdC7TmQGAq_7jMC_PZ95EDh1y7nRtTUbakTa7JFucf_e7)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzsPlwcAs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzsPlwcAs_003D, _0023_003DzPpV5jBZOkBbk9geRJgH8YE0_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzRJQSVpk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzRJQSVpk_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					uint num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
					{
						1 => (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
						13 => (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
						19 => (uint)Convert.ToInt64(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()), 
						_ => throw new InvalidOperationException(), 
					};
					_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D[] array = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D[])((_0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)._0023_003Dzixcg7_x1tHB43m0Vw3MI3iKJ3XOsgQNtqp6h099qwMX3();
					if (num < array.Length)
					{
						uint num2 = (uint)array[num]._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
						_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num2);
					}
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzhThTuf8_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzhThTuf8_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzPhOe5dIgi9gNB__002400g_003D_003D(_0023_003DzjYYAPCA_003D: false);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzWIjt_0024fI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzWIjt_0024fI_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					FieldInfo fieldInfo = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), fieldInfo.FieldType);
					fieldInfo.SetValue(null, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzbAh_0024yNw_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzbAh_0024yNw_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D());
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzHw7Dl0k_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzHw7Dl0k_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(((_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D());
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz3JlXtik_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz3JlXtik_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(uint));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz2QYJXSU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2QYJXSU_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(_0023_003DzhGgZIrA_003D);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzeuGuOw0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzeuGuOw0_003D, delegate
				{
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzW2hAkvc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzW2hAkvc_003D, _0023_003DzenxzzukP2qjOyN_F8g7J6Xc_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzNn516fc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzNn516fc_003D, _0023_003DzNedfprLLOel9rMbDASuzf3z9xHEk)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzpBK8X4w_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzpBK8X4w_003D, _0023_003DzKskMKPPrIMykM2vr9MHBIQthOTvumrd4pNX1uos_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzEhoFlyc_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzEhoFlyc_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(1);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzw7ivbiE_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzw7ivbiE_003D, _0023_003Dzn_kpiUQmnvcbrqXOAA_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzqLoKr7o_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzqLoKr7o_003D, _0023_003DzS8I26ubPwVSQX22vOvuc06pk9PWB)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzhD_HJLU_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzhD_HJLU_003D, _0023_003DznzO5WFF3rZmQ0USiWKF3Ss0_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzrv0NqTQ_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzrv0NqTQ_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dzyw_0024hL79l7r60IKFONJALFLLMtvfhE8EPXH31qX0ZioFO(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzjqAAENI_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzjqAAENI_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					Type type = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
					if (_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dzoc_PM0yoBLqKTVJ8LaIR70z2pV25hUCeuw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, type))
					{
						_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3);
						return;
					}
					throw new InvalidCastException();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzM5rdgLs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzM5rdgLs_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622420));
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzDmRZtNk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzDmRZtNk_003D, _0023_003DzD3Md_XTU1ptb7UGz5ptl5z_GqWDLr1we39qQRCI_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzb1LFVDs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzb1LFVDs_003D, _0023_003DzwqoPMVp6UFSBFAz9DM_jUJZY4rDy)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzzh0j87s_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzzh0j87s_003D, _0023_003DzbSu51qiOrJaQX3CR0w_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzOvxSA4M_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzOvxSA4M_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzOzOni9M_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzOzOni9M_003D, _0023_003Dz0o12iWcxdQSWglDTSkqZ74w9h5Xqhbxk5IcSh9M_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzEwGee_A_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzEwGee_A_003D, _0023_003DzFSCuY2QSUfMgSs91YaGiq2x2S9Nu94zvJQ_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzGMK4xyk_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzGMK4xyk_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(7);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzbAJHMuA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzbAJHMuA_003D, _0023_003DzqsN9lWBaPipXf6sjukSpFXt_hYRLCce8Ow_003D_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzJBBzDss_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzJBBzDss_003D, _0023_003Dzw4DfmlsNTIayVp4swbfQ6lDGCElwX9GVhJL8OdMUVabq)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzDyffOIs_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzDyffOIs_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_Z2_JTJDd9sWOd03XiTIY386_00248_0024k();
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzbTG2Hh4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzbTG2Hh4_003D, _0023_003DzZKLc0Jdl3h6_d7eAtyCkspQ_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzE3sP_0024o0_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzE3sP_0024o0_003D, _0023_003DzTifSzSbPLJr27yOFfKuNeWNLR9ZqXDBz5IEp97A_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003DzpGw_0024feA_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003DzpGw_0024feA_003D, delegate(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz9FiFEf4_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz9FiFEf4_003D, _0023_003Dzb0zk3xwznqylK4djI4QOAZs_003D)
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dz2BwZl2w_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2BwZl2w_003D, delegate
				{
				})
			},
			{
				_0023_003DzjYYAPCA_003D._0023_003Dzf4Pqh9s_003D._0023_003DzxUJvH4rNqGJ0mG3G04jClDyqLchCTB0tDLCvzUshz_vg(),
				new _0023_003DzLtLprGE_003D(_0023_003DzjYYAPCA_003D._0023_003Dzf4Pqh9s_003D, _0023_003Dz0t885_B0F52F3C4wHUHxX2Zwrxtd)
			}
		};
	}

	private static void _0023_003Dz82H5rO8lutrvay2FD42A9d8_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003DzjYYAPCA_003D._0023_003Dzoc_PM0yoBLqKTVJ8LaIR70z2pV25hUCeuw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, type))
		{
			_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
		}
		else
		{
			_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D());
		}
	}

	private static void _0023_003Dz_aS7WXvl_JNrHfpNdUASD5o_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(3);
	}

	private void _0023_003DzyPEOtNr8yOqWQPGxf9ATqDQ_003D()
	{
		_0023_003DzDw__wI8_003D = null;
		this.m__0023_003DzTFNDoh0_003D = null;
		_0023_003DzoMNiNRw_003D.Clear();
	}

	private static void _0023_003DzCC0rFYfx2lJko_0024_0024UrNwjYRfgu18kmOn_rsoGPIqoJfyY(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz85YPZTAMkedt0zGj9E3AUSkVpyiZ(_0023_003DzjYYAPCA_003D: false, _0023_003DzVC9FBdo_003D: false);
	}

	private static void _0023_003Dz7xiizXYgpL1JHnuu_fnIWet75WQJ(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		long num2 = _0023_003DzjYYAPCA_003D._0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo();
		Array array = (Array)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		_0023_003Dq7DDRIUR2HfeJRmeMtT4tOI_iA6FIAmJNKi5MgTnzG6k_003D obj = new _0023_003Dq7DDRIUR2HfeJRmeMtT4tOI_iA6FIAmJNKi5MgTnzG6k_003D();
		obj._0023_003Dz0DRlp_0024d0A_0024e_0024jTMJw2fjMLs50pbEYCzMLuslZH0_003D(array);
		obj._0023_003Dzws7xW22QPhdMiCYc_0024Pzxq5BwtxX_0024(type);
		obj._0023_003Dz1vUFlh5kH4ZpnkDsQxuoinHEfGlEro4oIg_003D_003D(num2);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private void _0023_003DzslACxgLiNWnnlXdB895RmsfYjCx082lHrsvBxQ6W5SeU()
	{
		_0023_003DzkwIyHLXyiC2uebcnoccQT7rFmVP8(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003DzenxzzukP2qjOyN_F8g7J6Xc_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzZlh7jtnX_FWEcU6dnmuZNpST3cf_0024pYZ5sQT1Xf8_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003Dzy104yeOdRegVl7V58lMf47jli_0024iA(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
	}

	private static void _0023_003DzFSCuY2QSUfMgSs91YaGiq2x2S9Nu94zvJQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(typeof(double));
	}

	private static void _0023_003Dz_0024wO8gGhKaVgRRrL53GTSFbk_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(uint));
	}

	private static void _0023_003DzeDaiGzq0xX7Cu_0024ZVcQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0));
	}

	private static void _0023_003Dz5zLQmIZbYTHVtwRmvoMhCr14NlYzx3ZUjWK3QgY_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (!_0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003DzhVff2zM8hdFnamD7xeV7fSU_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzXMS1M_M1OGkgq8BfaLjs7A4Ea0_00245rZWliw_003D_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static void _0023_003DzPb0quhUqQ50c_rQaGdIvRCGjsEGT5J7Y6HoKUuDIpSUY(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(0);
	}

	private static void _0023_003Dz1VWzoFLhegTNuv6ecsR3oTQ_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private long _0023_003DzHoI_0024yGKPPv7jzYnvAUSuJVOOKmJ_0024jO5QWd_1MWA_003D(string _0023_003DzjYYAPCA_003D)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003Dq8riK_u0AutNH4h7bM0BsvHKBvFUFVKriGvuIIlhVkC8_003D._0023_003Dzh9NZIAUV0GLgr8ws4A_003D_003D(_0023_003DzjYYAPCA_003D));
		long result = new _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D(new _0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D(memoryStream, _0023_003DzzCjVacbNBQMLBwfcVJXj7do_003D()))._0023_003Dztd9RtyYy2lWD_9pt8yLFfBodfHRGj5FmrSmIGROFMirZ();
		memoryStream.Dispose();
		return result;
	}

	private static void _0023_003Dz13dUohXMVYTMqdg0Cnosgi4bf4Hsok0i2UzgGdc_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDE05hLaLH65q6l2w5aXfxhfkQSxYsID41w_003D_003D(1);
	}

	private void _0023_003Dz85YPZTAMkedt0zGj9E3AUSkVpyiZ(bool _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzV32PUd33Ebp_0024eGw58ktXSTkfDU1ND09F1pxBxaMGMW5j(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D));
	}

	private void _0023_003DzrD_0024e29g_G2oGu00c_0024qgXo06y_0024yJdKPymZQ_003D_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		bool flag = IntPtr.Size == 4;
		checked
		{
			IntPtr intPtr;
			switch (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
			{
			case 1:
			{
				int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(unchecked((uint)num)) : new IntPtr((uint)num)) : ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(num) : new IntPtr((int)(uint)num)));
				break;
			}
			case 13:
			{
				long num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				intPtr = ((!flag) ? ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(num2) : new IntPtr((long)(ulong)num2)) : ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(unchecked((int)num2)) : new IntPtr((int)(ulong)num2)));
				break;
			}
			case 8:
			{
				double num3 = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(unchecked((long)num3)) : new IntPtr((long)(ulong)num3)) : ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(unchecked((int)(ulong)num3)) : new IntPtr((int)(ulong)num3)));
				break;
			}
			case 19:
				intPtr = ((!_0023_003DzjYYAPCA_003D) ? new IntPtr(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : new IntPtr(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D obj = new _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D();
			obj._0023_003DzUmdxhDjG74GKtyVW7F3F36VHvsjdtmQ2z8h1mFw_003D(intPtr);
			_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
		}
	}

	private static void _0023_003DziSPfAZ8tnEP9Tf435t5phnGI_0024C9u(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(((_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DzVC9FBdo_003D)._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D());
	}

	private static bool _0023_003DzHhJ__0024cOJrYzP2AefgXQYJ6SDEezS()
	{
		return false;
	}

	private static object _0023_003DzxRKpnEfB4r0_0024al4LmLb_0024SVDOPjC6rNNG_Q_003D_003D(MethodBase _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D, object[] _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (!_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D._0023_003Dzf4Pqh9s_003D._0023_003DzjYYAPCA_003D)
		{
			return _0023_003DzT5WJMTijRhl7mUu1uw_003D_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		}
		return _0023_003DzILwSVJ_ETdKfjFYYiqfi8sJNEFoswfvrOmcv9cichdCe(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
	}

	private static void _0023_003DzSCoUSwmagjyZNzzbH6H5_0024gc_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(type);
	}

	private static void _0023_003Dz1MWsfwNOQWrz2VqmQDF8tQwQuqI6(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz8GBMuoM_003D = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
	}

	private static void _0023_003DzLMZRlRU0YaDEheGI98D_SLg_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDE05hLaLH65q6l2w5aXfxhfkQSxYsID41w_003D_003D(2);
	}

	private static void _0023_003DzZ0zQzFZ76nW_Mhr2YiUWm2omo5K7YmN3LA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D);
	}

	private void _0023_003Dz1rV5jwYXvJleR8kc6Ss4eBN0LIeFGAyWcfoT7Fw_003D(ref _0023_003DzwBouG0w_003D _0023_003DzjYYAPCA_003D, MethodBase _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D)
	{
		bool flag = false;
		if (_0023_003DzVC9FBdo_003D.DeclaringType == typeof(Interlocked) && _0023_003DzVC9FBdo_003D.IsStatic)
		{
			string name = _0023_003DzVC9FBdo_003D.Name;
			if (name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622798) || name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622788) || name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622830) || name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622846) || name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622607) || name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622623))
			{
				flag = true;
			}
		}
		if (flag)
		{
			try
			{
			}
			finally
			{
				Monitor.Enter(_0023_003DzpGw_0024feA_003D);
				_0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D = true;
			}
		}
	}

	private static void _0023_003DzzQQ_RFoTqyPWVJ_SkA7P_0024rCsl_5SZqjMgg_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003DzjYYAPCA_003D._0023_003Dzoc_PM0yoBLqKTVJ8LaIR70z2pV25hUCeuw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, type))
		{
			_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
			return;
		}
		throw new InvalidCastException();
	}

	private string _0023_003DzBJtrg4eHkWySVWYW423_bcbxpROe(_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D _0023_003DzjYYAPCA_003D)
	{
		Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DzjYYAPCA_003D._0023_003DzOLMnH5O6nDdsgeNelug7d7P67d9Rvtr_00241w_003D_003D(), _0023_003DzVC9FBdo_003D: false);
		_0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D[] array = _0023_003DzjYYAPCA_003D._0023_003Dzjfr8w_0024YG19uko57Az4_0024mv7ElFen3();
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(array[i]._0023_003Dzt1eFV4wjyaQl60ABlEzvR_jbEMrSq_00240mR6y9GXRV3_pj(), _0023_003DzVC9FBdo_003D: false)?.FullName;
		}
		string text = string.Join(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621248), array2);
		return type.FullName + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810) + _0023_003DzjYYAPCA_003D._0023_003Dzm9VWNismLnbdxD6v10tj3f_Xz98q() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621271) + text + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621295);
	}

	private static void _0023_003DzGoVDWdrNUUQM9G7JC7Froz_exskHugYYerTlaNc_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(byte));
	}

	private static void _0023_003DzzNJtPbKXMEgy8xm7Vhm12rMSBky4(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(-1);
	}

	private static bool _0023_003Dzx7GYkLRRzuFm9D0Dvs1moxvmF45Xl8NjClRD15Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		bool flag = false;
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 1:
			return (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() > (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		case 13:
			return (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() > (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		case 8:
		{
			double num3 = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			double num4 = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			return num3 > num4 || double.IsNaN(num3) || double.IsNaN(num4);
		}
		case 0:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 7 && _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == null)
			{
				return ((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() != IntPtr.Zero;
			}
			return ((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() != ((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzVC9FBdo_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp();
		case 20:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 7 && _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == null)
			{
				return ((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() != UIntPtr.Zero;
			}
			return ((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() != ((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D();
		case 7:
			return ((_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D)_0023_003DzjYYAPCA_003D)._0023_003DzbxMVv9p9wKFTXDEHbUUrzRSF_jqdjYqX8REqAOpnd1TT() != ((_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D)_0023_003DzVC9FBdo_003D)._0023_003DzbxMVv9p9wKFTXDEHbUUrzRSF_jqdjYqX8REqAOpnd1TT();
		case 25:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 7 && _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == null)
			{
				return true;
			}
			return ((_0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D)_0023_003DzjYYAPCA_003D)._0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL() != ((_0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D)_0023_003DzVC9FBdo_003D)._0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL();
		case 19:
		{
			long num = Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D());
			long num2 = ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 1) ? Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()) : ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
			return num > num2;
		}
		default:
			return _0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() != _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
	}

	private static void _0023_003DzGAlJHtNOEl2hTDIk3_0024Pxywh36tNfwT_0024JbI_0024nWX_B6Gs7(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzmlrV_1WGATvgi2njhT6WfN0KtM7G();
	}

	private static void _0023_003DzWpe7w_OfU54O8LXpqVNio1qZLyxLEJVvNy3Exbs_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(float));
	}

	private FieldInfo _0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(int _0023_003DzjYYAPCA_003D)
	{
		lock (_0023_003Dzgd4c0yY_003D)
		{
			bool flag = true;
			FieldInfo fieldInfo;
			if (flag && _0023_003Dzgd4c0yY_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value))
			{
				fieldInfo = (FieldInfo)value;
			}
			else
			{
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = _0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(_0023_003DzjYYAPCA_003D);
				fieldInfo = _0023_003Dzv0H7JXLcGSuu02DtVu5H4a6WhtB7t67sGNGIpeWiH5yE(_0023_003DzjYYAPCA_003D, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2, ref flag);
				if (flag)
				{
					_0023_003Dzgd4c0yY_003D.Add(_0023_003DzjYYAPCA_003D, fieldInfo);
				}
			}
			_0023_003Dzw03qGZ6zeDrQcG40A5UjND4W_CNMp81RYA_003D_003D(fieldInfo);
			return fieldInfo;
		}
	}

	private static void _0023_003DzMN9VQgA_8BcIjpe_00249YD8zbY_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(1);
	}

	private static bool _0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		bool result = false;
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 1:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			}
			result = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() > ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
			break;
		case 13:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()));
			}
			result = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() > ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			break;
		case 19:
			return _0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), _0023_003DzVC9FBdo_003D);
		case 8:
		{
			double num = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			double num2 = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			result = !double.IsNaN(num) && !double.IsNaN(num2) && num > num2;
			break;
		}
		}
		return result;
	}

	private static void _0023_003DzPpV5jBZOkBbk9geRJgH8YE0_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzVC9FBdo_003D);
	}

	private static void _0023_003DzVrsGqHVJ9caDRhhh2mU_0024ZWhzYnwn(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(_0023_003DzhGgZIrA_003D);
	}

	private bool _0023_003Dzk1vjYKdrxBDMQqZueQW24U0_003D(MethodInfo _0023_003DzjYYAPCA_003D, _0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D _0023_003DzVC9FBdo_003D, Type[] _0023_003DzwBouG0w_003D, out int _0023_003Dzf4Pqh9s_003D)
	{
		_0023_003Dzf4Pqh9s_003D = 0;
		if (!_0023_003DzjYYAPCA_003D.IsGenericMethodDefinition)
		{
			return false;
		}
		ParameterInfo[] parameters = _0023_003DzjYYAPCA_003D.GetParameters();
		if (parameters.Length != _0023_003DzVC9FBdo_003D._0023_003DzAYLteFD_0024hSG98T2eZrz_00241pZdXMfq().Length)
		{
			return false;
		}
		if (_0023_003DzjYYAPCA_003D.GetGenericArguments().Length != _0023_003DzVC9FBdo_003D._0023_003DzyLgBzI5n1Wp5fTHJXqbsETASnbyWqaKPAOpVAv0_003D().Length)
		{
			return false;
		}
		for (int i = -1; i < parameters.Length; i++)
		{
			Type type = ((i == -1) ? _0023_003DzjYYAPCA_003D.ReturnType : parameters[i].ParameterType);
			if (_0023_003DzwBouG0w_003D != null && type.IsGenericParameter && type.DeclaringMethod != null)
			{
				type = _0023_003DzwBouG0w_003D[type.GenericParameterPosition] ?? type;
			}
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = ((i == -1) ? _0023_003DzVC9FBdo_003D._0023_003DzTgNAuTXywmWixhTv_00242OU8nhNSsC2() : _0023_003DzVC9FBdo_003D._0023_003DzAYLteFD_0024hSG98T2eZrz_00241pZdXMfq()[i]);
			if (_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 != null)
			{
				if (!_0023_003Dz_0024lZfnkHlFfRD4AK7UfIQXZw_003D(type, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2, out var num))
				{
					return false;
				}
				if (i >= 0)
				{
					_0023_003Dzf4Pqh9s_003D += num;
				}
			}
		}
		return true;
	}

	public object _0023_003Dzh5E65ib_0024HC5Nn1rVqjeOGNZ6ez3RGOgeHXzRH3w_003D(Stream _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D, object[] _0023_003DzwBouG0w_003D, Type[] _0023_003Dzf4Pqh9s_003D, Type[] _0023_003DzTFNDoh0_003D, object[] _0023_003DzraVZG9g_003D)
	{
		this.m__0023_003DzRoqMfFc_003D = _0023_003DzjYYAPCA_003D;
		_0023_003DzELriwvbv1hey9Ci5heVRtkjxyQ4Uvr6HigEVBy7tGvUL(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		return _0023_003DzX8gnPxk6aVoWmV6DcPUIAXx2_0024KEAuLJ7MydlvbUDUPEq(_0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D);
	}

	private static void _0023_003DzzrOcj9pfVrCXXxtyrItRZDhbdS4_bKpeF1haaOA_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003Dzx7GYkLRRzuFm9D0Dvs1moxvmF45Xl8NjClRD15Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0));
	}

	private static void _0023_003Dzr0c6vnepSbZ0E3fqHP8GrXtjg9Y1HPHS0w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D _0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D2 = (_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D)_0023_003DzVC9FBdo_003D;
		_0023_003DzjYYAPCA_003D._0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D2._0023_003DzUrMOHuJ4xEdyCagt_0024A_003D_003D());
	}

	private static void _0023_003DzZvpm9ZNyBYIlhWoRw_u5d_A_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMzB7WojOWsSyL7Bcs9rkRyQ_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003DzQmtO80N9_GtgttVzzzDyZwG52bMsfKSVKrLURec_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzVC9FBdo_003D);
	}

	private static void _0023_003Dz_0024ZJVreZ95gqaRJ5uZ2zSLzbx82TnND4JqpHaQG0_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMzB7WojOWsSyL7Bcs9rkRyQ_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static void _0023_003DzITg_0024ESFvqjFG4r7qzWJZBeqVkV3f(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private static void _0023_003Dzq04cqhtU2H_0024TKI10WvgYqaASucTx6Fp74AUqhTQ_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private static void _0023_003DzmyqE_l3exbm2fbqah7slHUTpblgy9cyc05W_0024_0024Ao_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(long));
	}

	private static void _0023_003DzJ6OZCddORNQAvxN1LNNTV177k5iDEitod232_mTj0_Be(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(ushort));
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzXyZ2GSC9jJ_ElHUQmw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				if (!_0023_003Dzf4Pqh9s_003D)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num3 = ((!_0023_003DzwBouG0w_003D) ? (num - num2) : checked(num - num2));
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num5 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num6 = ((!_0023_003DzwBouG0w_003D) ? (num4 - num5) : checked(num4 - num5));
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D((int)num6);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzwoTu6x5dv_UlHiuEuw_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzwoTu6x5dv_UlHiuEuw_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
				}
				return _0023_003DzXyZ2GSC9jJ_ElHUQmw_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzwoTu6x5dv_UlHiuEuw_003D_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003DzwoTu6x5dv_UlHiuEuw_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzwoTu6x5dv_UlHiuEuw_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
				}
				return _0023_003DzwoTu6x5dv_UlHiuEuw_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8 && _0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8)
		{
			_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
			obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D() - ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D());
			return obj;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzXyZ2GSC9jJ_ElHUQmw_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			return _0023_003DzXyZ2GSC9jJ_ElHUQmw_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzHV8nLO9pcE5znPsNFatW0iE_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(byte));
	}

	private static void _0023_003DzVQ8pIXB4S2f9cNdpFUqEsMA50ZI_wJjxfDz9GPc_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 = (_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (type.IsValueType)
		{
			object obj = _0023_003DzjYYAPCA_003D._0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
			if (_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzJOxLVMUq09gKMmJjDqh_BOpFRd5D2IDnyaMQ_PU_003D(type))
			{
				_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D obj2 = new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D();
				obj2._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(type);
				_0023_003DzjYYAPCA_003D._0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2, obj2);
				return;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(obj, _0023_003DzKI9AhDGv8owR2z5ca5jzdp3a0RvNH6SOl92zEeA_003D(fieldInfo.FieldType));
			}
		}
		else
		{
			_0023_003DzjYYAPCA_003D._0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2, new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D());
		}
	}

	private static string _0023_003DzM_1DobppPL15BMKH098qp_JpvO0t94aGMu18fSU_003D(MethodBase _0023_003DzjYYAPCA_003D)
	{
		Type declaringType = _0023_003DzjYYAPCA_003D.DeclaringType;
		ParameterInfo[] parameters = _0023_003DzjYYAPCA_003D.GetParameters();
		string[] array = new string[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			array[i] = string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622780), parameterInfo.ParameterType, parameterInfo.Name);
		}
		string text = string.Join(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621248), array);
		return declaringType.FullName + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810) + _0023_003DzjYYAPCA_003D.Name + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621271) + text + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621295);
	}

	private static void _0023_003Dz3jQ9e80k4_heeWfRN9gYjxEHGsv1(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(6);
	}

	private static void _0023_003DzQpV_0024jxDINhd1foZn9IC2ZY3uesxAGE_7kdkGy0J6g9Lq(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (byte)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (byte)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (byte)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => (byte)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((byte)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((byte)(uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003Dz68WrFs5NZDQm8a5KGsxC3Q0NERj0LKDfV55r5p61_0024Gsc(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(typeof(float));
	}

	private FieldInfo _0023_003Dzv0H7JXLcGSuu02DtVu5H4a6WhtB7t67sGNGIpeWiH5yE(int _0023_003DzjYYAPCA_003D, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DzVC9FBdo_003D, ref bool _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzVC9FBdo_003D._0023_003Dzr_EmRq1bb965XQHX42A1yCMQVgDqEWiC_0024Q_003D_003D() == 0)
		{
			_0023_003DzwBouG0w_003D = false;
			return this.m__0023_003DzJ6W8874_003D.ResolveField(_0023_003DzVC9FBdo_003D._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN());
		}
		_0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D2 = (_0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D)_0023_003DzVC9FBdo_003D._0023_003Dzda7qbCrYRS_dkFu4eYeIJBGfF1ZN();
		Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D2._0023_003DzOPn_zvFPPSU6i1fGuR7bOdhoyhry6t_0024apw_003D_003D()._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003DzVC9FBdo_003D: false);
		if (type.IsGenericType)
		{
			_0023_003DzwBouG0w_003D = false;
		}
		return type.GetField(bindingAttr: _0023_003DzjSXURF25698U40r_JUeUD2Md5VtOUzuO9w_003D_003D(_0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D2._0023_003DzPsHm_FuC9KPW8HI1CEiZFWs_003D()), name: _0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D2._0023_003DzKJ0qZK0R_c2c1aruy7ibaxGyL37O());
	}

	private static void _0023_003DzM51FmliBLKM_0024eXphxQkVyMiLLghq(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzjYYAPCA_003D._0023_003DzrhmC7EzIlogvg37F_0024jM9GV_GEYF9(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
	}

	private static void _0023_003DzdQ_00249_0024_0024Pe1wwjjUG1_CbOjCY9GSTX(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzjZ5w2QCyoeebeU5XHnTLRZk_003D(_0023_003DzjYYAPCA_003D: false, _0023_003DzVC9FBdo_003D: false);
	}

	public object _0023_003DzTIoStId_0024_0024GHgBSutm03Gs9I_003D(Stream _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D, object[] _0023_003DzwBouG0w_003D)
	{
		return _0023_003Dzh5E65ib_0024HC5Nn1rVqjeOGNZ6ez3RGOgeHXzRH3w_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, null, null, null);
	}

	private static void _0023_003Dzn_kpiUQmnvcbrqXOAA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		double num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
		obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(num);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzV32PUd33Ebp_0024eGw58ktXSTkfDU1ND09F1pxBxaMGMW5j(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				if (!_0023_003Dzf4Pqh9s_003D)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num3 = ((!_0023_003DzwBouG0w_003D) ? (num * num2) : checked(num * num2));
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num5 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num6 = ((!_0023_003DzwBouG0w_003D) ? (num4 * num5) : checked(num4 * num5));
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D((int)num6);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003Dzc8iTqM3hEp0sWUJK7l25TUdxnWjL(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003Dzc8iTqM3hEp0sWUJK7l25TUdxnWjL(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
				}
				return _0023_003DzV32PUd33Ebp_0024eGw58ktXSTkfDU1ND09F1pxBxaMGMW5j(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003Dzc8iTqM3hEp0sWUJK7l25TUdxnWjL(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003Dzc8iTqM3hEp0sWUJK7l25TUdxnWjL(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003Dzc8iTqM3hEp0sWUJK7l25TUdxnWjL(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
				}
				return _0023_003Dzc8iTqM3hEp0sWUJK7l25TUdxnWjL(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8 && _0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8)
		{
			_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
			obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D() * ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D());
			return obj;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzV32PUd33Ebp_0024eGw58ktXSTkfDU1ND09F1pxBxaMGMW5j(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			return _0023_003DzV32PUd33Ebp_0024eGw58ktXSTkfDU1ND09F1pxBxaMGMW5j(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003DzraVZG9g_003D _0023_003DzI7ZS6H5p3q75HrHPblTaXVhSI8ri(MethodBase _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		DynamicMethod dynamicMethod = null;
		if (dynamicMethod == null)
		{
			dynamicMethod = new DynamicMethod(string.Empty, _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D, new Type[2]
			{
				_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D,
				_0023_003Dz1latlWs_003D
			}, typeof(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D).Module, skipVisibility: true);
		}
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ParameterInfo[] parameters = _0023_003DzjYYAPCA_003D.GetParameters();
		Type[] array = new Type[parameters.Length];
		bool flag = false;
		for (int i = 0; i < parameters.Length; i++)
		{
			Type type = parameters[i].ParameterType;
			if (type.IsByRef)
			{
				flag = true;
				type = type.GetElementType();
			}
			array[i] = type;
		}
		LocalBuilder[] array2 = new LocalBuilder[array.Length];
		if (array2.Length != 0)
		{
			dynamicMethod.InitLocals = true;
		}
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = iLGenerator.DeclareLocal(array[j]);
		}
		for (int k = 0; k < array.Length; k++)
		{
			iLGenerator.Emit(OpCodes.Ldarg_1);
			_0023_003DzYnaB_0024xsOKB4HNJHD1aLmzvTQ4xmMA53SDrwm9qg_003D(iLGenerator, k);
			iLGenerator.Emit(OpCodes.Ldelem_Ref);
			_0023_003DzFHBTsSUKSWSSMTJMHg_003D_003D(iLGenerator, array[k]);
			iLGenerator.Emit(OpCodes.Stloc, array2[k]);
		}
		if (flag)
		{
			iLGenerator.BeginExceptionBlock();
		}
		if (!_0023_003DzjYYAPCA_003D.IsStatic && !_0023_003DzjYYAPCA_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Ldarg_0);
			Type declaringType = _0023_003DzjYYAPCA_003D.DeclaringType;
			if (declaringType.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Unbox, declaringType);
				_0023_003DzVC9FBdo_003D = false;
			}
			else
			{
				_0023_003DzoDfvLO8q6gm7oCA12XDqxfINiEsTCB4DL2_sjzI_003D(iLGenerator, declaringType);
			}
		}
		for (int l = 0; l < array.Length; l++)
		{
			if (parameters[l].ParameterType.IsByRef)
			{
				iLGenerator.Emit(OpCodes.Ldloca_S, array2[l]);
			}
			else
			{
				iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
			}
		}
		if (_0023_003DzjYYAPCA_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Newobj, (ConstructorInfo)_0023_003DzjYYAPCA_003D);
			_0023_003Dz5SrxUpo3WuCPWkhx9IpgYcsAPnUJuHAeIFNJWHhparyn(iLGenerator, _0023_003DzjYYAPCA_003D.DeclaringType);
		}
		else
		{
			MethodInfo methodInfo = (MethodInfo)_0023_003DzjYYAPCA_003D;
			if (!_0023_003DzVC9FBdo_003D || _0023_003DzjYYAPCA_003D.IsStatic)
			{
				iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
			}
			else
			{
				iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
			}
			if (methodInfo.ReturnType == _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D)
			{
				iLGenerator.Emit(OpCodes.Ldnull);
			}
			else
			{
				_0023_003Dz5SrxUpo3WuCPWkhx9IpgYcsAPnUJuHAeIFNJWHhparyn(iLGenerator, methodInfo.ReturnType);
			}
		}
		if (flag)
		{
			LocalBuilder local = iLGenerator.DeclareLocal(_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D);
			iLGenerator.Emit(OpCodes.Stloc, local);
			iLGenerator.BeginFinallyBlock();
			for (int m = 0; m < array.Length; m++)
			{
				if (parameters[m].ParameterType.IsByRef)
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					_0023_003DzYnaB_0024xsOKB4HNJHD1aLmzvTQ4xmMA53SDrwm9qg_003D(iLGenerator, m);
					iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
					if (array2[m].LocalType.IsValueType || _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzoC9bH1eMVZamY4yQnHoYg9cMo4hJmwbUvuc_0024TkZjHFud(array2[m].LocalType).IsGenericParameter)
					{
						iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
					}
					iLGenerator.Emit(OpCodes.Stelem_Ref);
				}
			}
			iLGenerator.EndExceptionBlock();
			iLGenerator.Emit(OpCodes.Ldloc, local);
		}
		iLGenerator.Emit(OpCodes.Ret);
		return (_0023_003DzraVZG9g_003D)dynamicMethod.CreateDelegate(typeof(_0023_003DzraVZG9g_003D));
	}

	private static void _0023_003DzcselSIXUW3hfFirzcKALDEnAEgfj(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(((_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D)_0023_003DzVC9FBdo_003D)._0023_003DzUrMOHuJ4xEdyCagt_0024A_003D_003D());
	}

	private static BindingFlags _0023_003DzjSXURF25698U40r_JUeUD2Md5VtOUzuO9w_003D_003D(bool _0023_003DzjYYAPCA_003D)
	{
		BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		if (_0023_003DzjYYAPCA_003D)
		{
			return bindingFlags | BindingFlags.Static;
		}
		return bindingFlags | BindingFlags.Instance;
	}

	private void _0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 2:
			((_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D)_0023_003DzjYYAPCA_003D)._0023_003DzziZoswQLVNeFsP98hnBAEV7aGwJW()._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DzVC9FBdo_003D);
			break;
		case 23:
			this.m__0023_003Dzt2pW2yo_003D[((_0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz9cLa4fSbw_0024YuqDOhZyVXAYptR7h2ZgZ_swy0YsaDDDS5()]._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DzVC9FBdo_003D);
			break;
		case 18:
		{
			_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2 = (_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D)_0023_003DzjYYAPCA_003D;
			FieldInfo fieldInfo = _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzjxTj7yNPdHyn2C7oYeJs_652ufci();
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), fieldInfo.FieldType);
			fieldInfo.SetValue(_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzLZ4Al05E5dyu5Qqv8kCoqc7Io9NoSnfEuw_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
			_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 = _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzcWRdE4jrgMMbS8rO7Slup9E_003D();
			if (_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 != null && fieldInfo.DeclaringType.IsValueType)
			{
				_0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzLZ4Al05E5dyu5Qqv8kCoqc7Io9NoSnfEuw_003D_003D(), null));
			}
			break;
		}
		case 11:
		case 24:
		{
			_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D _0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2 = (_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D)_0023_003DzjYYAPCA_003D;
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), _0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2._0023_003Dzz29d1Mo45Nlkl2uvQNZ2xJDR_3L42IRCr6Mwef8_003D());
			_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2._0023_003Dz2qF14z9PBJ5bjoDSlCY6ZGtipIS_aX8JH14_AHXGdtW1BfLmlQSv9g6M7mhuY5U4NS5ofh5CnXB9tOIM_0024y1R3DDqAiuo(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void _0023_003DzBR8qL8OpsOF08xMEK0MxCYoJrWlQ(Stream _0023_003DzjYYAPCA_003D, long _0023_003DzVC9FBdo_003D, string _0023_003DzwBouG0w_003D)
	{
		int num = _0023_003Dz_r6DY8u6W_ewxwlOynnKjpAxzcDr();
		_0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D _0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D2 = new _0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D(_0023_003DzjYYAPCA_003D, num);
		_0023_003DzKufrQS0_003D = new _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D(_0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D2);
		if (_0023_003DzwBouG0w_003D != null)
		{
			_0023_003DzVC9FBdo_003D = _0023_003DzHoI_0024yGKPPv7jzYnvAUSuJVOOKmJ_0024jO5QWd_1MWA_003D(_0023_003DzwBouG0w_003D);
		}
		_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D2 = _0023_003DzKufrQS0_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D();
		lock (_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D2)
		{
			_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D2._0023_003DzF9bNse9wHJLLtepk_gT8nT7RoArbYZ5O7BM_0024pvRSfZZCcif09QuhqkEcicQBZU2Q_1FotqnGeCeOOleA6w_003D_003D(_0023_003DzVC9FBdo_003D, 0);
			_0023_003DzOKKxyaBKSkkMMD3eMKERwCxNc0n5(_0023_003DzKufrQS0_003D);
			m__0023_003DzbAh_0024yNw_003D = _0023_003DzjGPStJv5AoYJY6j1HSm6NyI_003D(_0023_003DzKufrQS0_003D);
			_0023_003Dz6It9KyA_003D = _0023_003DzCEvGzsiOXS7Fsydh_4iK_0024xQLP1SEZuUJarhtVQk_003D(_0023_003DzKufrQS0_003D);
			this.m__0023_003DzmZWYhFQ_003D = _0023_003DzSWvqCoiw3rSW_MEKwS1EipYB3nxeQTwXDvvAZdw_003D(_0023_003DzKufrQS0_003D);
		}
		_0023_003DznRra0OxARjzZ3cVwLdLnjrhJnN6q4QVwQ_0024hOrLs_003D();
	}

	private void _0023_003DzX8NAj5tJmqoBVnjrpzPupq2Fwpct(ref _0023_003DzwBouG0w_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D)
		{
			Monitor.Exit(_0023_003DzpGw_0024feA_003D);
		}
	}

	private static void _0023_003DznzO5WFF3rZmQ0USiWKF3Ss0_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(long));
	}

	private void _0023_003Dz2fy5GZ_BtqAQusuWA_0024dIS2YNIxUsMwuF6X1c40XS9p29(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzPs11Tb8uXXqCo_0024SHKYAW5lkOFf6Flo1Clw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, _0023_003DzjYYAPCA_003D));
	}

	private static void _0023_003Dz6o1_00240NxKhfa70xiP8dlLLggGhuID(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzRv4TNIOd4mm0BbpmaDZLiHXQQ_0024vT(_0023_003DzjYYAPCA_003D: false);
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzgtdnAZX47uTSJ_JDlAc0pzKw8HzBKRq41YbeKQsgVEn3(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num | num2);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				int num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num3 | num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num3 | num5);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				long num6 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				long num7 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num6 | num7);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				int num8 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num8 | num9);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				int num10 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()) | num10);
				}
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()) | num10);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				long num12 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num11 | num12);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					long num14 = Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num13 | num14);
				}
				int num15 = Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				int num16 = Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num15 | num16);
			}
		}
		throw new InvalidOperationException();
	}

	private int _0023_003DzzCjVacbNBQMLBwfcVJXj7do_003D()
	{
		return 1055444913;
	}

	private static void _0023_003DzOQH_SHsKcK1efN61h2AqQuo_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621605));
	}

	private static void _0023_003Dza0MuWaEORbfaBjPtkJiLu8s_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDE05hLaLH65q6l2w5aXfxhfkQSxYsID41w_003D_003D(((_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D)_0023_003DzVC9FBdo_003D)._0023_003DzUrMOHuJ4xEdyCagt_0024A_003D_003D());
	}

	private static void _0023_003DzS9O0KOE7qOH_00246olvvEDLsYDOVR2A(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), type);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
	}

	private static void _0023_003DzNIIJQoDINGa68UxsF8L7gbkQByN9Rn1EFYLGkuA_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(ushort));
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzDw__wI8_003D;
		if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 != null)
		{
			_0023_003DzDw__wI8_003D = this.m__0023_003DzTFNDoh0_003D;
			this.m__0023_003DzTFNDoh0_003D = null;
			return _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2;
		}
		return _0023_003DzoMNiNRw_003D.Pop();
	}

	private static void _0023_003DzIzi14UMR5ANZLHzGZ_HJdbhGyz4VrWitTg_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		UIntPtr uIntPtr = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => new UIntPtr((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
			13 => new UIntPtr((ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
			19 => new UIntPtr(Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => new UIntPtr((ulong)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D obj = new _0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D();
		obj._0023_003DzGmvilFxLz5ow_00243N4yf6DdNE_003D(uIntPtr);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static void _0023_003Dz0d6fUr0eKX8jx5XiZmCcioUdGg_0024t(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
	}

	private static void _0023_003DzyVB_vrtt35_002427H_00245Iy1JP1Df9j9i(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621770));
	}

	private static void _0023_003Dzjyjkn6vpuilloE092PMQb_0024L546FZubuDsqpjAqh2_0024KpN(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzZlh7jtnX_FWEcU6dnmuZNpST3cf_0024pYZ5sQT1Xf8_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static Exception _0023_003Dztm4gexWTTs0hhUHNRjoX96Kq_0024j38(string _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D)
	{
		return new TypeLoadException(_0023_003DzPKGMroGOWHhmnvL5AzUMb_ZYt_srfMzCHTjRfd8_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620886) + _0023_003DzjYYAPCA_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621194) + _0023_003DzVC9FBdo_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914)));
	}

	private static void _0023_003DzzUjSIkN0Fm_00249UKjflazfzwLlN_Gc(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type t = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Marshal.SizeOf(t)));
	}

	private static void _0023_003DzLZ0fHUlfV2EvwvOH4zOWwOJc87Pxio_Oyn3qdic_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzC3RFxvsWBIn5AV5tTfE6YhyCK1x5AauzoOQ29pg_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private void _0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621227));
		}
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2;
		if (_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D() != null)
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D;
		}
		else
		{
			switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
			{
			case 22:
			{
				_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj9 = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
				obj9._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(((_0023_003DqubUcAaZEWA6CJOJ0kia_0024ubH_0024CouyLJRIcXwyCHHGHlE_003D)_0023_003DzjYYAPCA_003D)._0023_003DzOf0NQqnB_wJg2IRd9FCsyB0feXragPq49AfD28U_003D());
				obj9._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj9;
				break;
			}
			case 12:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj8 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(((_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DzjYYAPCA_003D)._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D());
				obj8._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj8;
				break;
			}
			case 26:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj7 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(((_0023_003DqI6bC3NY1_uNOHm69XetZaAlh3GTk1330136s_0024_00242QJEE_003D)_0023_003DzjYYAPCA_003D)._0023_003DzNijCUO8dEjgGM0dDNLYZlteotNgXL4EKGqi39IPaMeIE());
				obj7._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj7;
				break;
			}
			case 17:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj10 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(((_0023_003Dqqr0fJcmNHD_002426q7CfYl3TM_0024T9WG9iKqdVju8r0aayl0_003D)_0023_003DzjYYAPCA_003D)._0023_003Dzd5ILVKAoOY_0024JKteorIsqspunkdMnkaRfrHPygaCLG_0J());
				obj10._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj10;
				break;
			}
			case 16:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj5 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(((_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzUrMOHuJ4xEdyCagt_0024A_003D_003D());
				obj5._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj5;
				break;
			}
			case 3:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj4 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D((int)((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzjYYAPCA_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D());
				obj4._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj4;
				break;
			}
			case 14:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D obj6 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D((long)((_0023_003DqV6Pla8GvwrNbR9D38ddYubWdWK_0024XThys19__0024KJnwXF8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzyHmu6p03chuj_OE9zsEv7A_00248RYxGCfcKYA_003D_003D());
				obj6._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj6;
				break;
			}
			case 15:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj3 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(((_0023_003Dqnm1S8JiabN5PaFT5RW161BmWIIFzvlf2YSeRf6UXumA_003D)_0023_003DzjYYAPCA_003D)._0023_003DzDboiV5THDkeRTc9EQpimaouILs5d() ? 1 : 0);
				obj3._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj3;
				break;
			}
			case 6:
			{
				_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj2 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(((_0023_003DqZ8xUF8j1H1xe23Bhq6AA_0024_LrMpsfBmGEtp9uo99cI04_003D)_0023_003DzjYYAPCA_003D)._0023_003DzITBXZiewW0RSbvGzNW_0024oa4I_003D());
				obj2._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = obj2;
				break;
			}
			case 7:
			{
				object obj = _0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
				if (obj == null)
				{
					_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D;
					break;
				}
				Type type = obj.GetType();
				if (type.HasElementType && !type.IsArray)
				{
					type = type.GetElementType();
				}
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = ((!(type != null) || type.IsValueType || type.IsEnum) ? _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, type) : _0023_003DzjYYAPCA_003D);
				break;
			}
			default:
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D;
				break;
			}
		}
		if (_0023_003DzDw__wI8_003D != null)
		{
			if (this.m__0023_003DzTFNDoh0_003D != null)
			{
				_0023_003DzoMNiNRw_003D.Push(this.m__0023_003DzTFNDoh0_003D);
			}
			this.m__0023_003DzTFNDoh0_003D = _0023_003DzDw__wI8_003D;
		}
		_0023_003DzDw__wI8_003D = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2;
	}

	private static void _0023_003DzY8clfAmD8ZSkgVFu9rDdixN3JiBLrvBFrtfa6My4Qg6E(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzRv4TNIOd4mm0BbpmaDZLiHXQQ_0024vT(_0023_003DzjYYAPCA_003D: true);
	}

	private _0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D _0023_003DzbZpwss7rLgAIpRQJ5_t7YqS_0024Um9zQXUUCQ_003D_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D obj = new _0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D();
		obj._0023_003DzfXSf_0024QgFPjOFKX5HXs3UmTKT6NOo(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
		obj._0023_003Dz98_EZkrfKcKT8PITYc_uFlrg6FC9HbOG4A_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzQQUfegG5ucAhAjgJ3LsQ2gQ_003D());
		return obj;
	}

	private static void _0023_003DzBCM2NNJShiTw7f_002484GEQmTauQCNBvktLRqOuLJw_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(_0023_003DzhGgZIrA_003D);
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzwoTu6x5dv_UlHiuEuw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (!_0023_003Dzf4Pqh9s_003D)
		{
			long num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num3 = ((!_0023_003DzwBouG0w_003D) ? (num - num2) : checked(num - num2));
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num5 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num6 = ((!_0023_003DzwBouG0w_003D) ? (num4 - num5) : checked(num4 - num5));
		return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D((long)num6);
	}

	private void _0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(Type _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 = (_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D)_0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), _0023_003DzjYYAPCA_003D));
	}

	private static void _0023_003DzKDDUUneJSSls9HGDW4VNxHMlWKj65uH9yjRRHCE_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz2fy5GZ_BtqAQusuWA_0024dIS2YNIxUsMwuF6X1c40XS9p29(_0023_003DzjYYAPCA_003D: true);
	}

	private _0023_003Dqv5jNEINgRiU3U0uL89SFaxyzWoSupFlnsL96ialj7gk_003D _0023_003DzIk7qBK4C_0024VGVhrNC1uAGHjYkUsNDjInPuqMaAxuW57T3(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		switch (_0023_003DzjYYAPCA_003D._0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D())
		{
		case 2:
		{
			_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D obj6 = new _0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D();
			obj6._0023_003DzXo29RJWG4ZETOVgJ7zeSpac_003D(_0023_003DzjYYAPCA_003D._0023_003Dz0w9pyVoUGYVaCx6Z9jRjujMZm1HNixgUUFrxFtI_003D());
			obj6._0023_003DzCFA4r0I99Xh5tGi4FVReANfRsnHE(_0023_003DzjYYAPCA_003D._0023_003DzQQUfegG5ucAhAjgJ3LsQ2gQ_003D());
			obj6._0023_003DzKKSkPwq6xCl5XHjSuQ_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzQQUfegG5ucAhAjgJ3LsQ2gQ_003D());
			obj6._0023_003DzjX443Tf0l2uIAGM7lDu2TGM0H7KA(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			obj6._0023_003DzOv7AmEYKF8_EJUMg64_fKBg7xP1wAU8TYQ_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D _0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2 = obj6;
			int num5 = _0023_003DzjYYAPCA_003D._0023_003Dz7yE4V0_l28IndeCHhDn7Kuk7Huyw();
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D[] array3 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D[num5];
			for (int k = 0; k < num5; k++)
			{
				int num6 = k;
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D obj7 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D();
				obj7._0023_003DzbhlOEsdnEkA7eYqpilK_0024L1ce09ot(1);
				obj7._0023_003DzyTDUc2e71fyfiu5D8w_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
				array3[num6] = obj7;
			}
			_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003Dz2C0ODYy0e7pdHBht_0024qBvQEY_0024Dc2GcVhXqcnow_00248_003D(array3);
			return _0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2;
		}
		case 1:
		{
			_0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D obj9 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDddsxNFiAuXn23Qvp5EdEOQ_003D();
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D obj10 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D();
			obj10._0023_003DzbhlOEsdnEkA7eYqpilK_0024L1ce09ot(1);
			obj10._0023_003DzyTDUc2e71fyfiu5D8w_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			obj9._0023_003Dzvkl1aUv98RJNYrk__0024__aOoc_003D(obj10);
			obj9._0023_003Dz6dmlLrJD68iF9tnasOknGLgoRxGdEKVd799S12E_003D(_0023_003DzjYYAPCA_003D._0023_003Dz0w9pyVoUGYVaCx6Z9jRjujMZm1HNixgUUFrxFtI_003D());
			obj9._0023_003Dz3cMvlQB3JHItbI19OSsOwtJzbFeE1izY2Q_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzQQUfegG5ucAhAjgJ3LsQ2gQ_003D());
			return obj9;
		}
		case 3:
		{
			_0023_003Dqje8unbeuXWKDdxL8YmRQgarGMD66B39FufkB_00246Pya8w_003D obj8 = new _0023_003Dqje8unbeuXWKDdxL8YmRQgarGMD66B39FufkB_00246Pya8w_003D();
			obj8._0023_003Dz37uAAqsa1rgkz3kjgA_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			obj8._0023_003DzN_3EqI_00247SUokfYR2ijL3sl9NzxrN6x9mcuGJyDqGjI6M(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			return obj8;
		}
		case 0:
		{
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D _0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2 = new _0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D();
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D obj2 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D();
			obj2._0023_003DzbhlOEsdnEkA7eYqpilK_0024L1ce09ot(1);
			obj2._0023_003DzyTDUc2e71fyfiu5D8w_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzFgJDhTe_00240ayXKR_00243EzPpONnm1kWJlIBigQ_003D_003D(obj2);
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzkcYZ87JvUuMGBoNkOF5udJJjyk28cVaqnlztJgo_003D(_0023_003DzjYYAPCA_003D._0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D());
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003Dz5IDM_B_Ttm_JwpCY9pjPzx7_0024HfA1QMHEaGHubW0_003D(_0023_003DzjYYAPCA_003D._0023_003Dz0w9pyVoUGYVaCx6Z9jRjujMZm1HNixgUUFrxFtI_003D());
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D obj3 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D();
			obj3._0023_003DzbhlOEsdnEkA7eYqpilK_0024L1ce09ot(1);
			obj3._0023_003DzyTDUc2e71fyfiu5D8w_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003Dzsi96pesrl6lt3YxWZuz_0024D4E_003D(obj3);
			int num = _0023_003DzjYYAPCA_003D._0023_003Dz7yE4V0_l28IndeCHhDn7Kuk7Huyw();
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D[] array = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = i;
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D obj4 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D();
				obj4._0023_003DzbhlOEsdnEkA7eYqpilK_0024L1ce09ot(1);
				obj4._0023_003DzyTDUc2e71fyfiu5D8w_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
				array[num2] = obj4;
			}
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzSMHVjnrvWnR4K7TNA9AgOhFjCPF1g2Y7sEFGU2WNobeo(array);
			int num3 = _0023_003DzjYYAPCA_003D._0023_003Dz7yE4V0_l28IndeCHhDn7Kuk7Huyw();
			_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D[] array2 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D[num3];
			for (int j = 0; j < num3; j++)
			{
				int num4 = j;
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D obj5 = new _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D();
				obj5._0023_003DzbhlOEsdnEkA7eYqpilK_0024L1ce09ot(1);
				obj5._0023_003DzyTDUc2e71fyfiu5D8w_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
				array2[num4] = obj5;
			}
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzG1zQa8OYW9xpTLZh7qMdonpJuQRIVoA0ajYtmT26n5X_0024(array2);
			return _0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2;
		}
		case 4:
		{
			_0023_003Dq14OGuS53TTgJXN5XHcnlTNUzoMSML4Kc3WYG6QA16tY_003D obj = new _0023_003Dq14OGuS53TTgJXN5XHcnlTNUzoMSML4Kc3WYG6QA16tY_003D();
			obj._0023_003DzGCisjX0eiRnFjtrGfZQfotXKo8WRWCDXJAU_Jg4_003D(_0023_003DzjYYAPCA_003D._0023_003Dz0w9pyVoUGYVaCx6Z9jRjujMZm1HNixgUUFrxFtI_003D());
			return obj;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003DzmocyYX3gMQ3qTlllXKtAazZtdhw2s0No0xoT4jGsbf4v(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
	}

	private static void _0023_003DzFTKvDC939pJhUi7xSQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(sbyte));
	}

	private static void _0023_003DzUwvqhFWPmdgqqMrtbgZzROs_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(float));
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzPs11Tb8uXXqCo_0024SHKYAW5lkOFf6Flo1Clw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				if (!_0023_003DzwBouG0w_003D)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num / num2);
				}
				int num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num4 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D((int)((uint)num3 / num4));
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzuiQ78F6JJee8y6CM27wQqDs_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzuiQ78F6JJee8y6CM27wQqDs_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
				}
				return _0023_003DzPs11Tb8uXXqCo_0024SHKYAW5lkOFf6Flo1Clw_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzuiQ78F6JJee8y6CM27wQqDs_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003DzuiQ78F6JJee8y6CM27wQqDs_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzwBouG0w_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzuiQ78F6JJee8y6CM27wQqDs_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
				}
				return _0023_003DzuiQ78F6JJee8y6CM27wQqDs_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8 && _0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8)
		{
			_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
			obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D() / ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D());
			return obj;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzPs11Tb8uXXqCo_0024SHKYAW5lkOFf6Flo1Clw_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			return _0023_003DzPs11Tb8uXXqCo_0024SHKYAW5lkOFf6Flo1Clw_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVphNYyCQZGECQcYA9CsPo_0024wlzvO7dFgbKw5ySAo_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D)
	{
		if (!_0023_003DzwBouG0w_003D)
		{
			long num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num % num2);
		}
		long num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num4 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D((long)((ulong)num3 % num4));
	}

	private static void _0023_003Dz7eyIzgD6kKtLG7stLlksnLiQQ9ODXp535YNhLb4aKbQU(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0));
	}

	private static _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D _0023_003DzQq5nLweGWqS_0024KHXLRAD4gYAFUeUUJ0Kb7zhZ9S8_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D obj = new _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D();
		obj._0023_003Dzz4jy7fzgGQtnIZE3Cz3mP3Fsb8Dxm9EqqA_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D());
		obj._0023_003Dzym9DnQ412bsts5N8Aj0EUpF0skTt16bcgA_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
		obj._0023_003DzNgG9IC2nTjtfiKl37s9hdD7SYieu(_0023_003DzjYYAPCA_003D._0023_003DzEcvK7dMoa2wIyh0TA77RZrYj8LIDTNRaGGUJ26g_003D());
		obj._0023_003DzCsLj2VrtJjL2Rd1gSpKlRvZ5YyuQhtGdjQ_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzEcvK7dMoa2wIyh0TA77RZrYj8LIDTNRaGGUJ26g_003D());
		obj._0023_003DzJRo0YVFEexYH2exURjGkMniMCUti(_0023_003DzjYYAPCA_003D._0023_003DzEcvK7dMoa2wIyh0TA77RZrYj8LIDTNRaGGUJ26g_003D());
		obj._0023_003Dzv4Uzjiy628ql361QsVLJ1vCynNh89aCL_0024VrRQFA_003D(_0023_003DzjYYAPCA_003D._0023_003DzEcvK7dMoa2wIyh0TA77RZrYj8LIDTNRaGGUJ26g_003D());
		return obj;
	}

	private static void _0023_003DzFHBTsSUKSWSSMTJMHg_003D_003D(ILGenerator _0023_003DzjYYAPCA_003D, Type _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzVC9FBdo_003D.IsValueType || _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzoC9bH1eMVZamY4yQnHoYg9cMo4hJmwbUvuc_0024TkZjHFud(_0023_003DzVC9FBdo_003D).IsGenericParameter)
		{
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Unbox_Any, _0023_003DzVC9FBdo_003D);
		}
		else
		{
			_0023_003DzoDfvLO8q6gm7oCA12XDqxfINiEsTCB4DL2_sjzI_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		}
	}

	private void _0023_003DzOKKxyaBKSkkMMD3eMKERwCxNc0n5(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
	}

	private static void _0023_003Dzb5zwX3nj_0024wDFeT_U65WGCewJKpjO(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003Dz5SrxUpo3WuCPWkhx9IpgYcsAPnUJuHAeIFNJWHhparyn(ILGenerator _0023_003DzjYYAPCA_003D, Type _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzVC9FBdo_003D.IsValueType || _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzoC9bH1eMVZamY4yQnHoYg9cMo4hJmwbUvuc_0024TkZjHFud(_0023_003DzVC9FBdo_003D).IsGenericParameter)
		{
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Box, _0023_003DzVC9FBdo_003D);
		}
	}

	private static void _0023_003DzxN5RGqRtqHkIEKk8_0024o0osv6TsGeQxGRHoht1HtM_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		uint num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (uint)Convert.ToInt64(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D[] array = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D[])((_0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D)_0023_003DzVC9FBdo_003D)._0023_003Dzixcg7_x1tHB43m0Vw3MI3iKJ3XOsgQNtqp6h099qwMX3();
		if (num < array.Length)
		{
			uint num2 = (uint)array[num]._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num2);
		}
	}

	public void _0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(Stream _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D, object[] _0023_003DzwBouG0w_003D)
	{
		_0023_003DzTIoStId_0024_0024GHgBSutm03Gs9I_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003DzaAnEqGxEYVIky7u6aHRajNVELEAgywuVoJq5Bhg_003D(int _0023_003DzjYYAPCA_003D, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DzVC9FBdo_003D)
	{
		lock (_0023_003Dzgd4c0yY_003D)
		{
			bool flag = true;
			if (flag && _0023_003Dzgd4c0yY_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value))
			{
				return (MethodBase)value;
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzr_EmRq1bb965XQHX42A1yCMQVgDqEWiC_0024Q_003D_003D() == 0)
			{
				MethodBase methodBase = this.m__0023_003DzJ6W8874_003D.ResolveMethod(_0023_003DzVC9FBdo_003D._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN());
				if (flag)
				{
					_0023_003Dzgd4c0yY_003D.Add(_0023_003DzjYYAPCA_003D, methodBase);
				}
				return methodBase;
			}
			_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D _0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2 = (_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D)_0023_003DzVC9FBdo_003D._0023_003Dzda7qbCrYRS_dkFu4eYeIJBGfF1ZN();
			if (_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003Dzs1wnmGiRbhfKUWYrmBy_0024_00243pKX4HQGMkKLA_003D_003D())
			{
				return _0023_003DzfqeuGMfs7I86ewGQl3MqeT4NzqWLtroZHR5jP_0024U_003D(_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2);
			}
			Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzbwqGM_T9wDYA3VBmZbuUw_Jfm88y4ktyYSQ6_rQ_003D()._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003DzVC9FBdo_003D: false);
			Type type2 = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzTgNAuTXywmWixhTv_00242OU8nhNSsC2()._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003DzVC9FBdo_003D: true);
			Type[] array = new Type[_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzAYLteFD_0024hSG98T2eZrz_00241pZdXMfq().Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzAYLteFD_0024hSG98T2eZrz_00241pZdXMfq()[i]._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003DzVC9FBdo_003D: true);
			}
			if (type.IsGenericType)
			{
				flag = false;
			}
			if (_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzNFA5tRKbMqlXvi2_0024aBt_0024AIZ3iOuA() == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621639))
			{
				ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, array, null) ?? throw new Exception();
				if (flag)
				{
					_0023_003Dzgd4c0yY_003D.Add(_0023_003DzjYYAPCA_003D, constructorInfo);
				}
				return constructorInfo;
			}
			BindingFlags bindingAttr = _0023_003DzjSXURF25698U40r_JUeUD2Md5VtOUzuO9w_003D_003D(_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzsxSqB6_VoZhb2pr_8QXoxoo_003D());
			MethodBase methodBase2 = null;
			try
			{
				methodBase2 = type.GetMethod(_0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzNFA5tRKbMqlXvi2_0024aBt_0024AIZ3iOuA(), bindingAttr, null, CallingConventions.Any, array, null);
			}
			catch (AmbiguousMatchException)
			{
				MethodInfo[] methods = type.GetMethods(bindingAttr);
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.Name != _0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzNFA5tRKbMqlXvi2_0024aBt_0024AIZ3iOuA() || methodInfo.ReturnType != type2)
					{
						continue;
					}
					ParameterInfo[] parameters = methodInfo.GetParameters();
					if (parameters.Length != array.Length)
					{
						continue;
					}
					bool flag2 = false;
					for (int k = 0; k < array.Length; k++)
					{
						if (parameters[k].ParameterType != array[k])
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						methodBase2 = methodInfo;
						break;
					}
				}
			}
			if (methodBase2 == null)
			{
				throw new Exception(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621659), type.Name, _0023_003DqthMd_TqXZ_0024bhR_0024PUVcTt_Y_CFMiOBksw4_eJqUPNblI_003D2._0023_003DzNFA5tRKbMqlXvi2_0024aBt_0024AIZ3iOuA()));
			}
			if (flag)
			{
				_0023_003Dzgd4c0yY_003D.Add(_0023_003DzjYYAPCA_003D, methodBase2);
			}
			return methodBase2;
		}
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzfKH_RCvqJNHp_tonDIgheh0QaV7z(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(-((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(-((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK());
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8)
		{
			_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
			obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(0.0 - ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D());
			return obj;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzfKH_RCvqJNHp_tonDIgheh0QaV7z(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())));
			}
			return _0023_003DzfKH_RCvqJNHp_tonDIgheh0QaV7z(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzuX7L1xguTkBfacsHCVnDzThBQPeZ9m3loh_0024QYW0_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzFdlupYgUze2_0024waqwlXUpS5UI_0024l4h(_0023_003DzjYYAPCA_003D: false, _0023_003DzVC9FBdo_003D: false);
	}

	private bool _0023_003Dzoc_PM0yoBLqKTVJ8LaIR70z2pV25hUCeuw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, Type _0023_003DzVC9FBdo_003D)
	{
		object obj = _0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		if (obj == null)
		{
			return true;
		}
		Type type = _0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D() ?? obj.GetType();
		if (type == _0023_003DzVC9FBdo_003D || _0023_003DzVC9FBdo_003D.IsAssignableFrom(type))
		{
			return true;
		}
		if (!type.IsValueType && !_0023_003DzVC9FBdo_003D.IsValueType)
		{
			if (Marshal.IsComObject(obj))
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.GetComInterfaceForObject(obj, _0023_003DzVC9FBdo_003D);
				}
				catch (ArgumentException)
				{
				}
				catch (InvalidCastException)
				{
				}
				if (intPtr != IntPtr.Zero)
				{
					try
					{
						Marshal.Release(intPtr);
					}
					catch
					{
					}
					return true;
				}
			}
			else if (_0023_003DzE3R7JkA_002492yoTb2YGdjy0NJK6iRO(obj))
			{
				return true;
			}
		}
		return false;
	}

	private static _0023_003DzraVZG9g_003D _0023_003DzcDw9Umm90KMTcwqhsxOouJs_003D(_0023_003DzJ6W8874_003D _0023_003DzjYYAPCA_003D)
	{
		lock (_0023_003DzTD9escs_003D)
		{
			_0023_003DzTD9escs_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value);
			return value;
		}
	}

	private static void _0023_003DzgguxUHc6Cu61sfF_0024ldgIR0UQSs2GbjZblA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2 = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D;
		MethodBase methodBase = _0023_003DzjYYAPCA_003D._0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
		_0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D obj = new _0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D();
		obj._0023_003Dzs_H9tD4fic5haXYigbX6_iA_003D(methodBase);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzvaCQTB2qWP1HsNogYaao34COhZ1z52rgCQ_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				if (!_0023_003Dzf4Pqh9s_003D)
				{
					int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
					int num3 = ((!_0023_003DzwBouG0w_003D) ? (num + num2) : checked(num + num2));
					return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num5 = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				uint num6 = ((!_0023_003DzwBouG0w_003D) ? (num4 + num5) : checked(num4 + num5));
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D((int)num6);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzStnKjFkmuO5zc0ZMVA97i8yATWRoZOmsAxMMau_Wl6q2(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzStnKjFkmuO5zc0ZMVA97i8yATWRoZOmsAxMMau_Wl6q2(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
				}
				return _0023_003DzvaCQTB2qWP1HsNogYaao34COhZ1z52rgCQ_003D_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
			{
				return _0023_003DzStnKjFkmuO5zc0ZMVA97i8yATWRoZOmsAxMMau_Wl6q2(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003DzStnKjFkmuO5zc0ZMVA97i8yATWRoZOmsAxMMau_Wl6q2(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzStnKjFkmuO5zc0ZMVA97i8yATWRoZOmsAxMMau_Wl6q2(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
				}
				return _0023_003DzStnKjFkmuO5zc0ZMVA97i8yATWRoZOmsAxMMau_Wl6q2(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8 && _0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 8)
		{
			_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
			obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D() + ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D());
			return obj;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzvaCQTB2qWP1HsNogYaao34COhZ1z52rgCQ_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
			}
			return _0023_003DzvaCQTB2qWP1HsNogYaao34COhZ1z52rgCQ_003D_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzRqvzqOFsS8U0Wk5qD2cVK6Knq3fTit6YeBiDf_0024o_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDdxEYiosUoRxou9IAkTu5pP0Zva2LvigIg_003D_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003DzIa4MSfgGV5st_gmUjzgqOW_00243YyLa(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzjYYAPCA_003D._0023_003Dzyw_0024hL79l7r60IKFONJALFLLMtvfhE8EPXH31qX0ZioFO(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
	}

	private static void _0023_003DzlVsCYPblzZD0QrM7ag_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		bool num2 = (num & int.MinValue) != 0;
		bool flag = (num & 0x40000000) != 0;
		num &= 0x3FFFFFFF;
		if (num2)
		{
			_0023_003DzjYYAPCA_003D._0023_003DzJffmNhaH7ZDZ_zLuaa9fA3s7_0024uZN(num, null, null, flag);
			return;
		}
		_0023_003Dqje8unbeuXWKDdxL8YmRQgarGMD66B39FufkB_00246Pya8w_003D _0023_003Dqje8unbeuXWKDdxL8YmRQgarGMD66B39FufkB_00246Pya8w_003D2 = (_0023_003Dqje8unbeuXWKDdxL8YmRQgarGMD66B39FufkB_00246Pya8w_003D)_0023_003DzjYYAPCA_003D._0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(num)._0023_003Dzda7qbCrYRS_dkFu4eYeIJBGfF1ZN();
		_0023_003DzjYYAPCA_003D._0023_003DzU_0024O_hBSbvhYSWXw4fr_zQnw_003D(_0023_003Dqje8unbeuXWKDdxL8YmRQgarGMD66B39FufkB_00246Pya8w_003D2);
	}

	private static void _0023_003DzJ4nQy4z5J6IfeAaMLfSlHN4_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz85YPZTAMkedt0zGj9E3AUSkVpyiZ(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: true);
	}

	private static void _0023_003Dz1_0024c1Uhfeq7Dil6u3tcYvlN21xRAIQ2d14w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
	}

	private void _0023_003DzPalNqUCr87jJQ2wBQmQB49pkBtH_0024(object _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D is Exception ex)
		{
			_0023_003DzrfqIm0EkueviQNBSH6gOlMAynw_0024XKs_0024VwUWZYaE_003D(ex);
		}
		_0023_003DzaSsnNBSGqV1cHVirbDmN3UMxw8Ml(_0023_003DzjYYAPCA_003D);
	}

	private static void _0023_003DzA_02Epg7V4DRFn9qQwcxTisf_VfTrb9mJQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzFdlupYgUze2_0024waqwlXUpS5UI_0024l4h(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: true);
	}

	private void _0023_003DzJffmNhaH7ZDZ_zLuaa9fA3s7_0024uZN(int _0023_003DzjYYAPCA_003D, Type[] _0023_003DzVC9FBdo_003D, Type[] _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		_0023_003DzKufrQS0_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D()._0023_003DzF9bNse9wHJLLtepk_gT8nT7RoArbYZ5O7BM_0024pvRSfZZCcif09QuhqkEcicQBZU2Q_1FotqnGeCeOOleA6w_003D_003D(_0023_003DzjYYAPCA_003D, 0);
		_0023_003DzOKKxyaBKSkkMMD3eMKERwCxNc0n5(_0023_003DzKufrQS0_003D);
		_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D _0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2 = _0023_003DzjGPStJv5AoYJY6j1HSm6NyI_003D(_0023_003DzKufrQS0_003D);
		_0023_003DzsKa6aC4yCYRYc_0024rMi6u_eytZiduYunPMx5igbd257DqZ(_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2);
		int num = _0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2._0023_003Dzjfr8w_0024YG19uko57Az4_0024mv7ElFen3().Length;
		object[] array = new object[num];
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] array2 = new _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[num];
		if (_0023_003Dz8GBMuoM_003D != null && _0023_003Dzf4Pqh9s_003D)
		{
			int num2 = ((!_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2._0023_003Dz1WWVGnrneA8xV7VcXabGDJzz31Kb()) ? 1 : 0);
			Type[] array3 = new Type[num - num2];
			for (int num3 = num - 1; num3 >= num2; num3--)
			{
				array3[num3] = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2._0023_003Dzjfr8w_0024YG19uko57Az4_0024mv7ElFen3()[num3]._0023_003Dzt1eFV4wjyaQl60ABlEzvR_jbEMrSq_00240mR6y9GXRV3_pj(), _0023_003DzVC9FBdo_003D: true);
			}
			MethodInfo method = _0023_003Dz8GBMuoM_003D.GetMethod(_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2._0023_003Dzm9VWNismLnbdxD6v10tj3f_Xz98q(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array3, null);
			_0023_003Dz8GBMuoM_003D = null;
			if (method != null)
			{
				_0023_003Dz0xkx_0024FbQA5T935rV9MlZIZQ_003D(method, _0023_003DzVC9FBdo_003D: true);
				return;
			}
		}
		for (int num4 = num - 1; num4 >= 0; num4--)
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = (array2[num4] = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D());
			if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)
			{
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2);
			}
			if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D() != null)
			{
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D())._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
			}
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2._0023_003Dzjfr8w_0024YG19uko57Az4_0024mv7ElFen3()[num4]._0023_003Dzt1eFV4wjyaQl60ABlEzvR_jbEMrSq_00240mR6y9GXRV3_pj(), _0023_003DzVC9FBdo_003D: true))._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
			array[num4] = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
			if (num4 == 0 && _0023_003Dzf4Pqh9s_003D && !_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2._0023_003Dz1WWVGnrneA8xV7VcXabGDJzz31Kb() && array[num4] == null)
			{
				throw new NullReferenceException();
			}
		}
		_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2 = new _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D(_0023_003Dz0yDzO_0024c_003D);
		object[] array4 = new object[1] { this.m__0023_003DzJ6W8874_003D.Assembly };
		object obj;
		try
		{
			obj = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003DzEioGLkR0_0024_0024CPX5lkRi0SzUn7LWa_qYHPx7oRuWN3Y6cG(this.m__0023_003DzRoqMfFc_003D, _0023_003DzjYYAPCA_003D, array, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, array4);
		}
		finally
		{
			bool flag = !_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D2._0023_003Dz1WWVGnrneA8xV7VcXabGDJzz31Kb();
			for (int i = 0; i < num; i++)
			{
				int num5;
				if (flag)
				{
					num5 = i + 1;
					if (num5 == num)
					{
						num5 = 0;
					}
				}
				else
				{
					num5 = i;
				}
				if (array2[num5] is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D3)
				{
					_0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(array[num5], null));
				}
			}
		}
		Type type = _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D2.m__0023_003DzbAh_0024yNw_003D._0023_003DzhG5dcPBwgHZkh1c2OjFbi6be_MyHOUg_fw_003D_003D(), _0023_003DzVC9FBdo_003D: true);
		if (type != _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D)
		{
			_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, type));
		}
	}

	private void _0023_003DzZlh7jtnX_FWEcU6dnmuZNpST3cf_0024pYZ5sQT1Xf8_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		long num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (!_0023_003DzjYYAPCA_003D) ? ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() : ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (!_0023_003DzjYYAPCA_003D) ? ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() : ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (!_0023_003DzjYYAPCA_003D) ? ((long)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : checked((long)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (!_0023_003DzjYYAPCA_003D) ? ((long)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((long)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (!_0023_003DzjYYAPCA_003D) ? ((long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D();
		obj._0023_003Dzh9pFyTiMWJW4wbfNIMoSMYw_003D(num);
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DzjYYAPCA_003D)
	{
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 2:
			return ((_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D)_0023_003DzjYYAPCA_003D)._0023_003DzziZoswQLVNeFsP98hnBAEV7aGwJW();
		case 23:
			return this.m__0023_003Dzt2pW2yo_003D[((_0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz9cLa4fSbw_0024YuqDOhZyVXAYptR7h2ZgZ_swy0YsaDDDS5()];
		case 18:
		{
			_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2 = (_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D)_0023_003DzjYYAPCA_003D;
			return _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzjxTj7yNPdHyn2C7oYeJs_652ufci().GetValue(_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzLZ4Al05E5dyu5Qqv8kCoqc7Io9NoSnfEuw_003D_003D()), null);
		}
		case 11:
		case 24:
		{
			_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D _0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2 = (_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D)_0023_003DzjYYAPCA_003D;
			return _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2._0023_003Dze_c9keEWBNmm7G60eIIr5TN2sVRch4rrpEkTyPk5rb3xsedFKNyZ7UWOPg5K9ojK8fCSfdg_003D(), _0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2._0023_003Dzz29d1Mo45Nlkl2uvQNZ2xJDR_3L42IRCr6Mwef8_003D());
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003DzkMN2HLMd_0024wot338MP1kHqAIjNUD2U6G82Q_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		string text = _0023_003DzjYYAPCA_003D._0023_003Dz_0024vGYNMHiNhnPj_9y_DQjzIxlL7viv0q7xqNNcxkdiFoF(num);
		_0023_003DqcvSJO7LoKSobiAnO2rDGIYGUavn0qNB0nQQmf73tkgM_003D obj = new _0023_003DqcvSJO7LoKSobiAnO2rDGIYGUavn0qNB0nQQmf73tkgM_003D();
		obj._0023_003Dz0Inh7gk9_dfRSPYoERQjRuA_003D(text);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static void _0023_003Dz46_hQN3Pp0N44ISYYh4SlpQ_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if ((_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 8) ? (!_0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)) : (!_0023_003Dzx7GYkLRRzuFm9D0Dvs1moxvmF45Xl8NjClRD15Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private long _0023_003DzdHuQ4vUXAFrCkVr_0024V2X7arg_003D()
	{
		return _0023_003Dzivyja_00240_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D()._0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D() + _0023_003DzevtAwuM_003D;
	}

	private static void _0023_003DzYzgm_0024h6T2j2LbA4m_pksjXIBknpN(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622420));
	}

	private static void _0023_003DzKJX1gCxotYp0aYhCYcA8_MY_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D _0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D2 = (_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DzVC9FBdo_003D;
		_0023_003DzjYYAPCA_003D._0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D2._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D());
	}

	private static void _0023_003DzYWmKYcncvWa8m0dmkIyY1FdchuDUpOsTr6kFv1A_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2 = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D;
		MethodBase methodBase = _0023_003DzjYYAPCA_003D._0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] array = _0023_003DzjYYAPCA_003D._0023_003DzKfi4z6E_003D;
		foreach (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 in array)
		{
			_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
		}
		_0023_003DzjYYAPCA_003D._0023_003Dz0xkx_0024FbQA5T935rV9MlZIZQ_003D(methodBase, _0023_003DzVC9FBdo_003D: false);
	}

	private static void _0023_003DzA_0024eYuypkMgVRoseLuICXrbqg9s3n(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(3);
	}

	private void _0023_003DzDyMz08iL72ZP1158HXKAoQZNcqfmGLIITQ_003D_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		sbyte b = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (!_0023_003DzjYYAPCA_003D) ? ((sbyte)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()) : checked((sbyte)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
			13 => (!_0023_003DzjYYAPCA_003D) ? ((sbyte)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()) : checked((sbyte)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
			19 => (!_0023_003DzjYYAPCA_003D) ? ((sbyte)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : checked((sbyte)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (!_0023_003DzjYYAPCA_003D) ? ((sbyte)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((sbyte)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((sbyte)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((sbyte)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((!_0023_003DzjYYAPCA_003D) ? ((sbyte)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((sbyte)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
		obj._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(b);
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static void _0023_003DzbYE9J1d2Uocxkgs5SrvRijuzR8jq(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (!_0023_003DznAT2eFkICx6B9STO5ogYSiU_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003DzTifSzSbPLJr27yOFfKuNeWNLR9ZqXDBz5IEp97A_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDyMz08iL72ZP1158HXKAoQZNcqfmGLIITQ_003D_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static void _0023_003DzqsN9lWBaPipXf6sjukSpFXt_hYRLCce8Ow_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(int));
	}

	private long _0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo()
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		return _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			0 => ((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp().ToInt64(), 
			20 => (long)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D().ToUInt64(), 
			19 => Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			_ => throw new Exception(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621578)), 
		};
	}

	private static void _0023_003Dz1YZs4D3KdNXaj333B3j5cFh5iajY5vVXXJ7VZS8_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(short));
	}

	private static void _0023_003DzVGzhf8XPWiipDzmRB0BKkwo_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D _0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D2 = (_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D)_0023_003DzVC9FBdo_003D;
		_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D obj = new _0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D();
		obj._0023_003Dz0phpHM_0024mCqRB9dTSooptWs6Fd5tg(_0023_003DzjYYAPCA_003D._0023_003DzKfi4z6E_003D[_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D2._0023_003DzUrMOHuJ4xEdyCagt_0024A_003D_003D()]);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private void _0023_003Dz1QxSginv6WXoVFiB40cXix_wQa7ycZHwpkc7eoE_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		int num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (!_0023_003DzjYYAPCA_003D) ? ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() : ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (int)((!_0023_003DzjYYAPCA_003D) ? ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() : checked((int)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK())), 
			19 => (!_0023_003DzjYYAPCA_003D) ? ((int)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : checked((int)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (!_0023_003DzjYYAPCA_003D) ? ((int)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((int)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((int)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((!_0023_003DzjYYAPCA_003D) ? ((int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()))), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
		obj._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(num);
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private void _0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D)
		{
			this.m__0023_003Dzt2pW2yo_003D[_0023_003DzjYYAPCA_003D] = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2;
		}
		else
		{
			this.m__0023_003Dzt2pW2yo_003D[_0023_003DzjYYAPCA_003D]._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
		}
	}

	[_0023_003DqymTLvf3BrhQp_00245V_LtgjgXZ7MbFbrCr4MV6uwUuDOlY_003D(2)]
	private bool _0023_003Dzt63WCO3vjTl0sdemnwYQtO7PA8OBTPwVcbDgYpo_003D([_0023_003Dqf_1TygBFcnFf0K9AFFRX5jBXHagQ5JvC8Z20voFGbw4_003D(1)] MethodBase _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D, ref object _0023_003DzwBouG0w_003D, [_0023_003Dqf_1TygBFcnFf0K9AFFRX5jBXHagQ5JvC8Z20voFGbw4_003D(new byte[] { 1, 2 })] object[] _0023_003Dzf4Pqh9s_003D)
	{
		Type declaringType = _0023_003DzjYYAPCA_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzJOxLVMUq09gKMmJjDqh_BOpFRd5D2IDnyaMQ_PU_003D(declaringType))
		{
			string name = _0023_003DzjYYAPCA_003D.Name;
			if (name.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622673), StringComparison.Ordinal))
			{
				_0023_003DzwBouG0w_003D = _0023_003DzVC9FBdo_003D != null;
			}
			else if (name.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622718), StringComparison.Ordinal))
			{
				if (_0023_003DzVC9FBdo_003D == null)
				{
					return ((bool?)null).Value;
				}
				_0023_003DzwBouG0w_003D = _0023_003DzVC9FBdo_003D;
			}
			else if (name.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621966), StringComparison.Ordinal))
			{
				switch (_0023_003Dzf4Pqh9s_003D.Length)
				{
				case 0:
					_0023_003DzwBouG0w_003D = _0023_003DzVC9FBdo_003D;
					break;
				case 1:
					if (_0023_003DzVC9FBdo_003D != null)
					{
						_0023_003DzwBouG0w_003D = _0023_003DzVC9FBdo_003D;
					}
					else
					{
						_0023_003DzwBouG0w_003D = _0023_003Dzf4Pqh9s_003D[0];
					}
					break;
				default:
					return false;
				}
			}
			else
			{
				if (_0023_003DzVC9FBdo_003D != null || _0023_003DzjYYAPCA_003D.IsStatic)
				{
					return false;
				}
				_0023_003DzwBouG0w_003D = null;
			}
			return true;
		}
		if (declaringType == _0023_003DzpBK8X4w_003D)
		{
			string name2 = _0023_003DzjYYAPCA_003D.Name;
			if (name2.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621974), StringComparison.Ordinal))
			{
				_0023_003DzwBouG0w_003D = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzraVZG9g_003D;
				return true;
			}
			if (this.m__0023_003DzLtLprGE_003D != null && name2.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622011), StringComparison.Ordinal))
			{
				object[] array = this.m__0023_003DzLtLprGE_003D;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is Assembly assembly)
					{
						_0023_003DzwBouG0w_003D = assembly;
						return true;
					}
				}
			}
		}
		else if (declaringType == _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzVC9FBdo_003D)
		{
			if (_0023_003DzjYYAPCA_003D.Name.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622018), StringComparison.Ordinal))
			{
				if (this.m__0023_003DzLtLprGE_003D != null)
				{
					object[] array = this.m__0023_003DzLtLprGE_003D;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] is MethodBase methodBase)
						{
							_0023_003DzwBouG0w_003D = methodBase;
							return true;
						}
					}
				}
				_0023_003DzwBouG0w_003D = MethodBase.GetCurrentMethod();
				return true;
			}
		}
		else if (declaringType.IsArray && declaringType.GetArrayRank() >= 2)
		{
			return _0023_003DzTSJaaFxItYKJxj19lB5Lj7k_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, ref _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D);
		}
		return false;
	}

	private static void _0023_003DzD3Md_XTU1ptb7UGz5ptl5z_GqWDLr1we39qQRCI_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzjYYAPCA_003D._0023_003DzgtdnAZX47uTSJ_JDlAc0pzKw8HzBKRq41YbeKQsgVEn3(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
	}

	private static void _0023_003DzpZ8rU5lnz1wCSCAaDg61kvzKxkUV(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzC3RFxvsWBIn5AV5tTfE6YhyCK1x5AauzoOQ29pg_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static void _0023_003DzVIKtdf3ifJpqJFlmyPlzjsR5YZHupu9XOQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dze0PMT9UZHrSUMFsj4aVkIXAs__0024qn(_0023_003DzjYYAPCA_003D: true);
	}

	private static void _0023_003DzjW5Y9ZOIZozqEHZPFq3wqI84lrFrjIPD4ERhdoc_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (int)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (int)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (int)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => (int)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((int)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((int)(uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzKnUCU9ajZDIhczgqBiZEQUAKYXVx(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if ((_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 8) ? (!_0023_003Dzx7GYkLRRzuFm9D0Dvs1moxvmF45Xl8NjClRD15Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)) : (!_0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003DzbSu51qiOrJaQX3CR0w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(typeof(double));
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003Dzc8iTqM3hEp0sWUJK7l25TUdxnWjL(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (!_0023_003Dzf4Pqh9s_003D)
		{
			long num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num3 = ((!_0023_003DzwBouG0w_003D) ? (num * num2) : checked(num * num2));
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num5 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num6 = ((!_0023_003DzwBouG0w_003D) ? (num4 * num5) : checked(num4 * num5));
		return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D((long)num6);
	}

	private static void _0023_003DzkwR4MYlSgdi9YPxvO7X6byeYcKNZ(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		IntPtr intPtr = checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => new IntPtr((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
			13 => new IntPtr((long)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
			19 => new IntPtr((long)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => new IntPtr((long)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		});
		_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D obj = new _0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D();
		obj._0023_003DzUmdxhDjG74GKtyVW7F3F36VHvsjdtmQ2z8h1mFw_003D(intPtr);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static void _0023_003DzuJnL2CLxUUSFx7cH6V_0024tGvo_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzjZ5w2QCyoeebeU5XHnTLRZk_003D(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: false);
	}

	private static void _0023_003Dz04HrXzwNt523vL8C7Q_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DzjYYAPCA_003D._0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(type);
	}

	private void _0023_003DzsaqDCdXA1fjkGC_0024VCiTIyfc_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D obj = new _0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D();
		obj._0023_003DzNwc3tw8dXqh23GrJseNh1gGxhjhIXunuAOf7Jdw_003D(_0023_003DzjYYAPCA_003D);
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static void _0023_003DzbhMnO4YF8Epr4S_wYlgv2lc4wyGT(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(double));
	}

	private Type _0023_003Dzc9tMfLKP0BugYDxtDq9aQxDOilg5sy7xBmrPETo_003D(int _0023_003DzjYYAPCA_003D, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DzVC9FBdo_003D, ref bool _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (_0023_003DzVC9FBdo_003D._0023_003Dzr_EmRq1bb965XQHX42A1yCMQVgDqEWiC_0024Q_003D_003D() == 0)
		{
			return this.m__0023_003DzJ6W8874_003D.ResolveType(_0023_003DzVC9FBdo_003D._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN());
		}
		_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D _0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2 = (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D)_0023_003DzVC9FBdo_003D._0023_003Dzda7qbCrYRS_dkFu4eYeIJBGfF1ZN();
		Type type = null;
		if (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003Dzo7ZRia_0024JJxZCLQfqQ7fz2bg_003D())
		{
			if (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzLlOLIHAC3hs_0024wr1KI_0024zoeSjoPQTc() != -1)
			{
				if (_0023_003DzaKmBh2M_003D == null)
				{
					throw new InvalidOperationException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621841));
				}
				type = _0023_003DzaKmBh2M_003D[_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzLlOLIHAC3hs_0024wr1KI_0024zoeSjoPQTc()];
			}
			else
			{
				if (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzAQ85yP4iXai4PDN1Zn0ZohvyEbXbx7MRgg_003D_003D() == -1)
				{
					throw new Exception();
				}
				if (this.m__0023_003Dzf4Pqh9s_003D == null)
				{
					throw new InvalidOperationException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621856));
				}
				type = this.m__0023_003Dzf4Pqh9s_003D[_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzAQ85yP4iXai4PDN1Zn0ZohvyEbXbx7MRgg_003D_003D()];
			}
			Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D> stack = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003Dz9zdkf9pmHD2DO4EmDsXAKIw_003D(_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzZBscPGgB_00243LV6QHIorCDWNUrvfAeUHqwgg_003D_003D());
			type = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzdudXII0n97BwllsbIrch9F0_003D(type, stack);
			_0023_003DzwBouG0w_003D = false;
			return type;
		}
		string text = _0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzZBscPGgB_00243LV6QHIorCDWNUrvfAeUHqwgg_003D_003D();
		try
		{
			type = Type.GetType(text);
		}
		catch (BadImageFormatException)
		{
		}
		if (type == null)
		{
			int num = text.IndexOf(',');
			string text2 = text.Substring(0, num);
			string text3 = text.Substring(num + 1).Trim();
			Assembly assembly = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzraVZG9g_003D;
			if (text3.Equals(assembly.FullName, StringComparison.OrdinalIgnoreCase))
			{
				type = ((!text2.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621903), StringComparison.Ordinal)) ? assembly.GetType(text2) : _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzDp118Pw_003D);
			}
			else
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly2 in assemblies)
				{
					string value = null;
					try
					{
						value = assembly2.Location;
					}
					catch (NotSupportedException)
					{
					}
					if (string.IsNullOrEmpty(value) && assembly2.FullName.Equals(text3, StringComparison.OrdinalIgnoreCase))
					{
						type = assembly2.GetType(text2);
						if (type != null)
						{
							break;
						}
					}
				}
			}
			if (type == null && text2.StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621888), StringComparison.Ordinal) && text2.Contains(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810)))
			{
				try
				{
					Type[] types = Assembly.Load(text3).GetTypes();
					foreach (Type type2 in types)
					{
						if (type2.FullName == text2)
						{
							type = type2;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		if (type == null)
		{
			throw new TypeLoadException(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621946), text));
		}
		if (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003Dzqwl_0024UZMrJFzEx6enPf9lzY8ID1fc())
		{
			if (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzHmV3Hw5jCBIejani4IwF8_0024OiWi24().Length != 0)
			{
				Type[] array = new Type[_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzHmV3Hw5jCBIejani4IwF8_0024OiWi24().Length];
				for (int j = 0; j < _0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzHmV3Hw5jCBIejani4IwF8_0024OiWi24().Length; j++)
				{
					array[j] = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003DzHmV3Hw5jCBIejani4IwF8_0024OiWi24()[j]._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003Dzf4Pqh9s_003D);
				}
				Type genericTypeDefinition = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzoC9bH1eMVZamY4yQnHoYg9cMo4hJmwbUvuc_0024TkZjHFud(type).GetGenericTypeDefinition();
				Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D> stack2 = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzBfue6AoofRZkIGtKnie10y0_003D(type);
				type = genericTypeDefinition.MakeGenericType(array);
				type = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzdudXII0n97BwllsbIrch9F0_003D(type, stack2);
			}
			_0023_003DzwBouG0w_003D = false;
		}
		return type;
	}

	private static void _0023_003Dzw4DfmlsNTIayVp4swbfQ6lDGCElwX9GVhJL8OdMUVabq(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D);
	}

	private void _0023_003Dz0mcH6doIj0ry_0024d9df66SJ3U3LV6zUlnjgQ_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D)
	{
		if (((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D())._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() != 0)
		{
			this.m__0023_003DzjYYAPCA_003D.Push(new _0023_003DzTFNDoh0_003D(_0023_003DzWoS2eJk_003D, _0023_003DzY8c1My4_003D));
			this.m__0023_003DzraVZG9g_003D = false;
		}
		_0023_003Dz_Z2_JTJDd9sWOd03XiTIY386_00248_0024k();
	}

	private static void _0023_003Dz2ZizGXWu8FprX1Ip68T_ndAKBMim(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzZphYYKQ8kEZVbHV0SDCmkB8_003D(_0023_003DzVC9FBdo_003D);
	}

	private static void _0023_003DzXrmHgNU_kWtK1Mw_viHDjjboi4WJ(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		double num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
		obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(num);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	public static object _0023_003DzKI9AhDGv8owR2z5ca5jzdp3a0RvNH6SOl92zEeA_003D(Type _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D.IsValueType)
		{
			return Activator.CreateInstance(_0023_003DzjYYAPCA_003D);
		}
		return null;
	}

	private static void _0023_003DzebZ5pYN0ukSwTwO7tjta3TzjbMH0(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] _0023_003DzvNyS6ZQfijYnSqWPGUw_0024e1Q4ky7VCX_0024OPw1C_fg_003D(object[] _0023_003DzjYYAPCA_003D)
	{
		_0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D[] array = m__0023_003DzbAh_0024yNw_003D._0023_003Dzjfr8w_0024YG19uko57Az4_0024mv7ElFen3();
		int num = array.Length;
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] array2 = new _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[num];
		for (int i = 0; i < num; i++)
		{
			object obj = _0023_003DzjYYAPCA_003D[i];
			Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(array[i]._0023_003Dzt1eFV4wjyaQl60ABlEzvR_jbEMrSq_00240mR6y9GXRV3_pj(), _0023_003DzVC9FBdo_003D: false);
			Type type2 = null;
			Type type3 = _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzM5GjsgMDoYpz28dMdyKB_0024JZsy1eP(type);
			type2 = ((!(type3 == _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D) && !_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzJOxLVMUq09gKMmJjDqh_BOpFRd5D2IDnyaMQ_PU_003D(type3)) ? ((obj != null) ? obj.GetType() : type) : type);
			if (obj != null && !type.IsAssignableFrom(type2) && type.IsByRef && !type.GetElementType().IsAssignableFrom(type2))
			{
				throw new ArgumentException(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622059), type2, type));
			}
			array2[i] = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, type2);
		}
		if (!m__0023_003DzbAh_0024yNw_003D._0023_003Dz1WWVGnrneA8xV7VcXabGDJzz31Kb() && _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(m__0023_003DzbAh_0024yNw_003D._0023_003DzOLMnH5O6nDdsgeNelug7d7P67d9Rvtr_00241w_003D_003D(), _0023_003DzVC9FBdo_003D: false).IsValueType)
		{
			_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D obj2 = new _0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D();
			obj2._0023_003Dz0phpHM_0024mCqRB9dTSooptWs6Fd5tg(array2[0]);
			array2[0] = obj2;
		}
		for (int j = 0; j < num; j++)
		{
			if (array[j]._0023_003DzMW8RMCedlHk3F9zBMrk3xvIZGCxXxH2NIA_003D_003D())
			{
				int num2 = j;
				_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D obj3 = new _0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D();
				obj3._0023_003Dz0phpHM_0024mCqRB9dTSooptWs6Fd5tg(array2[j]);
				array2[num2] = obj3;
			}
		}
		return array2;
	}

	private static bool _0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		bool result = false;
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 1:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			}
			result = (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() < (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
			break;
		case 13:
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				return _0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()));
			}
			result = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() < (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			break;
		case 19:
			return _0023_003Dz4s_0024OFYMgexdsonKxdzYGAfw_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), _0023_003DzVC9FBdo_003D);
		case 8:
		{
			double num = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			double num2 = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			result = num < num2 || double.IsNaN(num) || double.IsNaN(num2);
			break;
		}
		}
		return result;
	}

	private static void _0023_003DzT4GifLqtcyd7ci0p_00244487vI_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(int));
	}

	private static void _0023_003DziUxNJfVM50_0024G8ud5B6hKaW5Cjk_H(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D obj = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (obj._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)obj)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Stack<_0023_003DzDp118Pw_003D> stack = _0023_003DzjYYAPCA_003D._0023_003DzRN_0024T_e_ketn6jFfvoGJBd6Z0eCaV();
		if (stack.Count < 2)
		{
			throw new InvalidOperationException();
		}
		using _0023_003DzDp118Pw_003D _0023_003DzDp118Pw_003D2 = stack.Pop();
		if (_0023_003DzDp118Pw_003D2 == null || _0023_003DzDp118Pw_003D2._0023_003DzjYYAPCA_003D._0023_003DzvOtRKFvvRycWecHWbaWMw1PQYV4beLHt_0024Z_0024L3f_0024hUNaOeTNTqp80tyV5sf5QK7xhO5ui3e3ZeH22() != num)
		{
			throw new InvalidOperationException();
		}
		_0023_003DzDp118Pw_003D _0023_003DzDp118Pw_003D3 = stack.Peek();
		_0023_003DzjYYAPCA_003D._0023_003Dzxn1GiqJsszWIPLqbSNdHO5j1n2nqhb_8GQr0yfc_003D(_0023_003DzDp118Pw_003D3);
		_0023_003DzjYYAPCA_003D._0023_003DzWoS2eJk_003D += (uint)_0023_003DzDp118Pw_003D2._0023_003DzjYYAPCA_003D._0023_003DzIc18jN2ZnzNBqoyZrA_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003DzlKeckCaClO9XhMQZJufmJ04_003D(_0023_003DzjYYAPCA_003D._0023_003DzWoS2eJk_003D);
	}

	private static void _0023_003DzVVWUWzKq0WhUQGWh3f1AdcFFFjnjLoq0jr2erAQ_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(8);
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzvefnNryFIAIc1ckTF4wqRYACL_0024ibgPb7l5xx100_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D, byte _0023_003DzVC9FBdo_003D)
	{
		switch (_0023_003DzVC9FBdo_003D)
		{
		case 11:
			return null;
		case 0:
		{
			_0023_003DzWoS2eJk_003D++;
			_0023_003Dqqr0fJcmNHD_002426q7CfYl3TM_0024T9WG9iKqdVju8r0aayl0_003D obj2 = new _0023_003Dqqr0fJcmNHD_002426q7CfYl3TM_0024T9WG9iKqdVju8r0aayl0_003D();
			obj2._0023_003Dz0KIQNi2hGB5ul8Hw7HyhvXY_003D(_0023_003DzjYYAPCA_003D._0023_003DzQtQvxcFQDR7tquPxydoZ5gk_003D());
			return obj2;
		}
		case 2:
		case 6:
			_0023_003DzWoS2eJk_003D += 4u;
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
		case 10:
			_0023_003DzWoS2eJk_003D += 8u;
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(_0023_003DzjYYAPCA_003D._0023_003Dztd9RtyYy2lWD_9pt8yLFfBodfHRGj5FmrSmIGROFMirZ());
		case 3:
		case 7:
		{
			_0023_003DzWoS2eJk_003D++;
			_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D obj7 = new _0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D();
			obj7._0023_003Dz_UnChU2D6Es_KLZuN3HlnsOy4KsK(_0023_003DzjYYAPCA_003D._0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D());
			return obj7;
		}
		case 5:
		case 12:
		{
			_0023_003DzWoS2eJk_003D += 2u;
			_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D obj6 = new _0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D();
			obj6._0023_003DzBiZYFFyRUzrh6EIFNg_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzgG4EIr51RxBvrAjab0dJg4lv_0024_aq36ZKqiDdChHGYrXG());
			return obj6;
		}
		case 4:
		{
			_0023_003DzWoS2eJk_003D += 4u;
			_0023_003DqubUcAaZEWA6CJOJ0kia_0024ubH_0024CouyLJRIcXwyCHHGHlE_003D obj5 = new _0023_003DqubUcAaZEWA6CJOJ0kia_0024ubH_0024CouyLJRIcXwyCHHGHlE_003D();
			obj5._0023_003Dzly_67TXPorTHy4X5b6steqlovSv3mzzAlQ_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzYSSnQ6sIOclVFmYf3CKHWlZxoY9zLmDzrxI29_0024kU_XrE());
			return obj5;
		}
		case 8:
		{
			_0023_003DzWoS2eJk_003D += 8u;
			_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj4 = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
			obj4._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(_0023_003DzjYYAPCA_003D._0023_003DzRvujv4mziPW1_0024weS_J317p5_0024BxFj());
			return obj4;
		}
		case 1:
		{
			_0023_003DzWoS2eJk_003D += 4u;
			_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D obj3 = new _0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D();
			obj3._0023_003Dz1QYt3zPCf3Jx6AnHDfwhI_00248_003D(_0023_003DzjYYAPCA_003D._0023_003DzEcvK7dMoa2wIyh0TA77RZrYj8LIDTNRaGGUJ26g_003D());
			return obj3;
		}
		case 9:
		{
			int num = _0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D();
			_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D[] array = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			}
			_0023_003DzWoS2eJk_003D += (uint)((num + 1) * 4);
			_0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D obj = new _0023_003Dq4h0qvju5ScNHjkj2BP6NZlC6YJs_0024Mhaa_0024wLarVFEqP4_003D();
			obj._0023_003DzVMjvbx1F3Y3vH0VPi7ebmaEXlAolbWHv2g3U9eA_003D(array);
			return obj;
		}
		default:
			throw new Exception(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622744));
		}
	}

	private static void _0023_003DzGPKeNMW7vKpKwMSB0YIjG2I_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(2);
	}

	private static void _0023_003Dzdi1UspofFxLWYecZv_0024VVR3xPFhzG(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPhOe5dIgi9gNB__002400g_003D_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private int _0023_003Dz_r6DY8u6W_ewxwlOynnKjpAxzcDr()
	{
		return 1447513948;
	}

	private void _0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzKfi4z6E_003D[_0023_003DzjYYAPCA_003D]._0023_003DzmoCa7lXUL7yvAaxU1Zbpx5T8XWXmYhrCsBrXsJwFxW7A2fsxJ1WfvAJMxdHd5pFpu_0024_0024m9jzUqDJr());
	}

	private bool _0023_003Dz_0024lZfnkHlFfRD4AK7UfIQXZw_003D(Type _0023_003DzjYYAPCA_003D, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DzVC9FBdo_003D, out int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzwBouG0w_003D = 0;
		_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D _0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2 = (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D)_0023_003DzVC9FBdo_003D._0023_003Dzda7qbCrYRS_dkFu4eYeIJBGfF1ZN();
		if (_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzoC9bH1eMVZamY4yQnHoYg9cMo4hJmwbUvuc_0024TkZjHFud(_0023_003DzjYYAPCA_003D).IsGenericParameter)
		{
			if (_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2 != null && !_0023_003DqpATz8D_jE9d2tWHW_0024puEsouHEkSPB0IO5IOk0EKTdk0_003D2._0023_003Dzo7ZRia_0024JJxZCLQfqQ7fz2bg_003D())
			{
				return false;
			}
			return true;
		}
		Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DzVC9FBdo_003D._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN(), _0023_003DzVC9FBdo_003D: false);
		if (!_0023_003Dqq5mflhyyhw0UGwZzM_0024dunFtIN3d5IgLMotgkOycUU9Q_003D._0023_003Dz8_0024_kJPbmHmAID6UEFyvxzkV3vw8p(_0023_003DzjYYAPCA_003D, type, out _0023_003DzwBouG0w_003D))
		{
			return false;
		}
		return true;
	}

	private static void _0023_003Dz0VZBTYD7dXOsjO5S1lhenHeqTEzq(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz85YPZTAMkedt0zGj9E3AUSkVpyiZ(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: false);
	}

	private static string _0023_003DzPKGMroGOWHhmnvL5AzUMb_ZYt_srfMzCHTjRfd8_003D(string _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D)
	{
		string fullName = typeof(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D).Assembly.FullName;
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621287) + _0023_003DzjYYAPCA_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621301) + _0023_003DzVC9FBdo_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621059) + Environment.NewLine + Environment.NewLine + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621076) + fullName + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621091);
	}

	private void _0023_003DzC3RFxvsWBIn5AV5tTfE6YhyCK1x5AauzoOQ29pg_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzWD3rU10LJjN22Og2BCOmR0kC7SgHNC3H7Q_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, _0023_003DzjYYAPCA_003D));
	}

	[_0023_003DqymTLvf3BrhQp_00245V_LtgjgXZ7MbFbrCr4MV6uwUuDOlY_003D(2)]
	private bool _0023_003DzTSJaaFxItYKJxj19lB5Lj7k_003D([_0023_003Dqf_1TygBFcnFf0K9AFFRX5jBXHagQ5JvC8Z20voFGbw4_003D(1)] MethodBase _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D, ref object _0023_003DzwBouG0w_003D, [_0023_003Dqf_1TygBFcnFf0K9AFFRX5jBXHagQ5JvC8Z20voFGbw4_003D(new byte[] { 1, 2 })] object[] _0023_003Dzf4Pqh9s_003D)
	{
		if (!_0023_003DzjYYAPCA_003D.IsStatic && _0023_003DzVC9FBdo_003D != null && _0023_003DzjYYAPCA_003D.Name.Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622325), StringComparison.Ordinal) && _0023_003DzjYYAPCA_003D is MethodInfo { ReturnType: var returnType } && returnType.IsByRef)
		{
			Type elementType = returnType.GetElementType();
			int num = _0023_003Dzf4Pqh9s_003D.Length;
			if (num >= 1 && _0023_003Dzf4Pqh9s_003D[0] is int)
			{
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = (int)_0023_003Dzf4Pqh9s_003D[i];
				}
				_0023_003DqrEm2JjIm4VkgfQzkhUQWZdMfhPeC9PIfkH1A1SdtnG0_003D obj = new _0023_003DqrEm2JjIm4VkgfQzkhUQWZdMfhPeC9PIfkH1A1SdtnG0_003D();
				obj._0023_003DzEf1gkD8aNHCBRijH_0024DP8hq9upGr7I5AK02QykclLvOrq((Array)_0023_003DzVC9FBdo_003D);
				obj._0023_003DzwJN0SnMPragOS6AlHb6XQrfhCu6pRlJV_0024A_003D_003D(array);
				obj._0023_003Dzws7xW22QPhdMiCYc_0024Pzxq5BwtxX_0024(elementType);
				_0023_003DzwBouG0w_003D = obj;
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzIGBBxvTl4js4YD4F64bHfYPwkFHCiVHt0w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
	}

	private static void _0023_003Dz_0024OlqS8RVTidBD_SiCapLnkw_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0));
	}

	private void _0023_003Dz5uz1g3hDsw_0024kQ_0024BOnU6xGYrafh_gbeI2XC40mbg_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzKfi4z6E_003D[_0023_003DzjYYAPCA_003D]._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
	}

	private static void _0023_003DzIDTVXsye7d43tY03X4FdbszcoT_0024Aj3wpjEBpYa2EgTf8(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), type);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(type);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
	}

	private static void _0023_003DzXfP_jNBBHQvtHTQhJHEBrKzeVvYSf5s2jDidYVpKsFSL(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		FieldInfo fieldInfo = _0023_003DzjYYAPCA_003D._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D obj = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 as _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D;
		object obj2 = ((_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 == null) ? _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() : _0023_003DzjYYAPCA_003D._0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
		if (obj2 == null)
		{
			throw new NullReferenceException();
		}
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(obj2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
		if (_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 != null && obj2 != null && obj2.GetType().IsValueType)
		{
			_0023_003DzjYYAPCA_003D._0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj2, null));
		}
	}

	private static Exception _0023_003Dz2TxsmUWmUPQJUZXAxNDtmQoAtKBMrg5_DtpK55U_003D(string _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D)
	{
		return new FieldAccessException(_0023_003DzPKGMroGOWHhmnvL5AzUMb_ZYt_srfMzCHTjRfd8_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620886) + _0023_003DzjYYAPCA_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622641) + _0023_003DzVC9FBdo_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914)));
	}

	private static void _0023_003Dzv0Jt_qSp8_0024C0PCR5mou4dZk_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		FieldInfo fieldInfo = _0023_003DzjYYAPCA_003D._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(null, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
	}

	private static void _0023_003DzMcQFOpwXwXprCzsanK3b9HPKmrju(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		object obj = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		long num = _0023_003DzjYYAPCA_003D._0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo();
		Array array = (Array)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(int))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(int));
			((int[])array)[num] = (int)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType == typeof(uint))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(uint));
			((uint[])array)[num] = (uint)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(elementType, obj, num, array);
		}
		else
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(typeof(int), obj, num, array);
		}
	}

	private void _0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(Type _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D, long _0023_003DzwBouG0w_003D, Array _0023_003Dzf4Pqh9s_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(_0023_003DzVC9FBdo_003D, _0023_003DzjYYAPCA_003D);
		_0023_003Dzf4Pqh9s_003D.SetValue(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D(), _0023_003DzwBouG0w_003D);
	}

	private void _0023_003DzRv4TNIOd4mm0BbpmaDZLiHXQQ_0024vT(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (!_0023_003DzjYYAPCA_003D) ? ((ushort)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()) : checked((ushort)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
			13 => (!_0023_003DzjYYAPCA_003D) ? ((ushort)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()) : checked((ushort)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
			19 => (!_0023_003DzjYYAPCA_003D) ? ((ushort)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : checked((ushort)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (!_0023_003DzjYYAPCA_003D) ? ((ushort)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((ushort)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((ushort)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((ushort)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((!_0023_003DzjYYAPCA_003D) ? ((ushort)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((ushort)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((ushort)(ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : checked((ushort)(ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D())) : ((!_0023_003DzjYYAPCA_003D) ? ((ushort)(uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : checked((ushort)(uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003DzmdPKY7jxXQ_0Os981bo_0024NguOH3RKXUuia1PjikScNOKF(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzVC9FBdo_003D);
	}

	private _0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D[] _0023_003DzGPdQ4BM518X7nD2WtHdiK6_0024Ff4jwQvFB3wsavchtfkEq(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D[] array = new _0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D[_0023_003DzjYYAPCA_003D._0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzbZpwss7rLgAIpRQJ5_t7YqS_0024Um9zQXUUCQ_003D_003D(_0023_003DzjYYAPCA_003D);
		}
		return array;
	}

	private static void _0023_003DzjrVsHR2Ee3xIM1NrcKJKQcuyGARCDlYHax859qg_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		bool flag = false;
		if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() != 0, 
			13 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() != 0, 
			0 => ((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() != IntPtr.Zero, 
			20 => ((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() != UIntPtr.Zero, 
			19 => Convert.ToBoolean(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			7 => ((_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzbxMVv9p9wKFTXDEHbUUrzRSF_jqdjYqX8REqAOpnd1TT() != null, 
			_ => _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() != null, 
		})
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private _0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D _0023_003DzjGPStJv5AoYJY6j1HSm6NyI_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D obj = new _0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D();
		obj._0023_003DzD4XCk1lxmqEtDacSnugtVk5EM8PVzEEabACacjQ_003D(_0023_003DzGPdQ4BM518X7nD2WtHdiK6_0024Ff4jwQvFB3wsavchtfkEq(_0023_003DzjYYAPCA_003D));
		obj._0023_003DzzVM_0024kwmSjCSF_0024AAdhg2FqdPI_0024eP3(_0023_003DzO4Q5lCPEgH3pF_00249XhOR6NFr6mvS58S9BBrMoewk_003D(_0023_003DzjYYAPCA_003D));
		obj._0023_003DzWGs19DMBuoMepAwbimZSy5Q_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
		obj._0023_003DzNPcJrH2p2wp9qjdTKPIlV3uMqaC5ifnNTqDvYus_003D(_0023_003DzjYYAPCA_003D._0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D());
		obj._0023_003Dzad4qFeHYZxlp9DCAf6_0024fsUilCcRhNXTMTfe9t7s_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
		obj._0023_003DzGEyQB9XSyaJeo2lUKgZM4DEP7YCs(_0023_003DzjYYAPCA_003D._0023_003Dz0w9pyVoUGYVaCx6Z9jRjujMZm1HNixgUUFrxFtI_003D());
		return obj;
	}

	private static void _0023_003DzRCCEqF1fiuKSAKL2YlwflWzGMLIceOSlmA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDE05hLaLH65q6l2w5aXfxhfkQSxYsID41w_003D_003D(((_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DzVC9FBdo_003D)._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D());
	}

	private static void _0023_003Dz6oSbbu_JsQWPzQ0VKqrChaVZMVD48kmZbw_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzjYYAPCA_003D._0023_003DzfKH_RCvqJNHp_tonDIgheh0QaV7z(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
	}

	private static void _0023_003Dzu0d3TfhoBUiMDCqNttZ_0024ohOpeHnM21hy0w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true);
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(type);
	}

	private void _0023_003DzdxMuTgdgBeB12Q4sxyS6jJw_003D()
	{
		if (m__0023_003DzbAh_0024yNw_003D._0023_003Dz1WWVGnrneA8xV7VcXabGDJzz31Kb())
		{
			Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(m__0023_003DzbAh_0024yNw_003D._0023_003DzOLMnH5O6nDdsgeNelug7d7P67d9Rvtr_00241w_003D_003D(), _0023_003DzVC9FBdo_003D: false);
			if (type != null)
			{
				RuntimeHelpers.RunClassConstructor(type.TypeHandle);
			}
		}
	}

	private static void _0023_003DzBqgKJING8PVThSjXR5Z_rVr5lbUG(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private static void _0023_003DzOn3ZTBeOAuR9ADhCZr_7_0024llIEh77D_0024_uBQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		Thread.MemoryBarrier();
	}

	private static void _0023_003Dzk4pSpFXqGqHdlIWcIPdXMSt8XgeTHJjIip3SFao_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		object obj = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		long num = _0023_003DzjYYAPCA_003D._0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo();
		Array array = (Array)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(short))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(short));
			((short[])array)[num] = (short)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType == typeof(ushort))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(ushort));
			((ushort[])array)[num] = (ushort)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType == typeof(char))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(char));
			((char[])array)[num] = (char)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(elementType, obj, num, array);
		}
		else
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(typeof(short), obj, num, array);
		}
	}

	private static void _0023_003DzDgWwJJTWsVULCapflpdZ0dS0en3Tk_0024IamQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D());
	}

	private static void _0023_003DzWkQqr_LWnE5JGbrTsKQA_0024wMTNw_0024ZK_0ZkezaC3w_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzVC9FBdo_003D);
	}

	private static void _0023_003DzOT2cGQSyrcB6qUudvJv64TUiR_OWQtWUuA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		FieldInfo fieldInfo = _0023_003DzjYYAPCA_003D._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2);
		}
		object obj = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		if (obj == null)
		{
			throw new NullReferenceException();
		}
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(fieldInfo.GetValue(obj), fieldInfo.FieldType));
	}

	private static void _0023_003DzVUKS9pX_0024bvnDxs36o_bSHh_bw3IQh6GpVw_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzFdlupYgUze2_0024waqwlXUpS5UI_0024l4h(_0023_003DzjYYAPCA_003D: true, _0023_003DzVC9FBdo_003D: false);
	}

	private void _0023_003DzMzB7WojOWsSyL7Bcs9rkRyQ_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzLr1faxti3SyKbNVlUCjaH77fmTcUa6L7_0024luk9v0kzLec(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, _0023_003DzjYYAPCA_003D));
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003Dzyw_0024hL79l7r60IKFONJALFLLMtvfhE8EPXH31qX0ZioFO(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
			_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
			obj._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(~num);
			return obj;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			long num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D obj2 = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D();
			obj2._0023_003Dzh9pFyTiMWJW4wbfNIMoSMYw_003D(~num2);
			return obj2;
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(~Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()));
			}
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(~Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzS8I26ubPwVSQX22vOvuc06pk9PWB(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	public static void _0023_003Dz3mPLcVxKEwE_D2oW_3wTpyy40yEfnTG93A_003D_003D<T>(T[] _0023_003DzjYYAPCA_003D, Comparison<T> _0023_003DzVC9FBdo_003D)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[_0023_003DzjYYAPCA_003D.Length];
		for (int i = 0; i < _0023_003DzjYYAPCA_003D.Length; i++)
		{
			array[i] = new KeyValuePair<int, T>(i, _0023_003DzjYYAPCA_003D[i]);
		}
		Array.Sort(array, _0023_003DzjYYAPCA_003D, new _0023_003DzbAh_0024yNw_003D<T>(_0023_003DzVC9FBdo_003D));
	}

	private void _0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(Type _0023_003DzjYYAPCA_003D)
	{
		long index = _0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo();
		Array array = (Array)_0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(array.GetValue(index), _0023_003DzjYYAPCA_003D));
	}

	private void _0023_003DzDE05hLaLH65q6l2w5aXfxhfkQSxYsID41w_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(this.m__0023_003Dzt2pW2yo_003D[_0023_003DzjYYAPCA_003D]._0023_003DzmoCa7lXUL7yvAaxU1Zbpx5T8XWXmYhrCsBrXsJwFxW7A2fsxJ1WfvAJMxdHd5pFpu_0024_0024m9jzUqDJr());
	}

	private static void _0023_003DzRXHqQpaHW3x9uexWwEJKzplbpvq5(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz2fy5GZ_BtqAQusuWA_0024dIS2YNIxUsMwuF6X1c40XS9p29(_0023_003DzjYYAPCA_003D: false);
	}

	private static _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzuiQ78F6JJee8y6CM27wQqDs_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D)
	{
		if (!_0023_003DzwBouG0w_003D)
		{
			long num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			long num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
			return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num / num2);
		}
		long num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		ulong num4 = (ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D((long)((ulong)num3 / num4));
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzkMvdZOzoLwdDseDkXiQIeCo_003D()
	{
		return _0023_003DzDw__wI8_003D ?? _0023_003DzoMNiNRw_003D.Peek();
	}

	private static void _0023_003Dz_8KrABb1AmW8LXBeTylINX4NLUF8(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz1QxSginv6WXoVFiB40cXix_wQa7ycZHwpkc7eoE_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private void _0023_003Dzx4nKMouLux6X2cl3UrAwHOxr7U9o_sIHIg_003D_003D()
	{
	}

	private void _0023_003DzXMS1M_M1OGkgq8BfaLjs7A4Ea0_00245rZWliw_003D_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (int)((!_0023_003DzjYYAPCA_003D) ? ((ushort)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()) : checked((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D())), 
			13 => (int)((!_0023_003DzjYYAPCA_003D) ? ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() : checked((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK())), 
			19 => (int)((!_0023_003DzjYYAPCA_003D) ? Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()) : checked((uint)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()))), 
			8 => (int)((!_0023_003DzjYYAPCA_003D) ? ((uint)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((uint)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D())), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((uint)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((!_0023_003DzjYYAPCA_003D) ? ((int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((int)checked((uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())))), 
			20 => (int)((UIntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : checked((uint)(ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D())) : ((!_0023_003DzjYYAPCA_003D) ? ((uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : ((uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003Dzj1wmj0FWFUW8nBP2uEaCbaM8MZW_()
	{
		this.m__0023_003DzmjtwFUo_003D = _0023_003DzWoS2eJk_003D;
		int key = _0023_003Dzivyja_00240_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D();
		_0023_003DzWoS2eJk_003D += 4u;
		_0023_003Dz7NsQCL4_003D.TryGetValue(key, out var value);
		value._0023_003DzVC9FBdo_003D(this, _0023_003DzvefnNryFIAIc1ckTF4wqRYACL_0024ibgPb7l5xx100_003D(_0023_003Dzivyja_00240_003D, value._0023_003DzjYYAPCA_003D));
	}

	private static void _0023_003Dzv6TIMp7EEwFoV3Xc736ZZgeIh_0024Yc(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
		obj._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(_0023_003DznAT2eFkICx6B9STO5ogYSiU_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2) ? 1 : 0);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private void _0023_003DzELriwvbv1hey9Ci5heVRtkjxyQ4Uvr6HigEVBy7tGvUL(Stream _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzBR8qL8OpsOF08xMEK0MxCYoJrWlQ(_0023_003DzjYYAPCA_003D, 0L, _0023_003DzVC9FBdo_003D);
	}

	private static void _0023_003DzMe1CBJHLl8UvzbJJG9RwHAk_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (long)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => (long)checked((ulong)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzmlrV_1WGATvgi2njhT6WfN0KtM7G()
	{
		_0023_003DzQizPEX8_003D = true;
	}

	private static void _0023_003DzaSsnNBSGqV1cHVirbDmN3UMxw8Ml(object _0023_003DzjYYAPCA_003D)
	{
		throw _0023_003DzjYYAPCA_003D;
	}

	private static bool _0023_003DznAT2eFkICx6B9STO5ogYSiU_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		bool result = false;
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 1:
			result = ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 19) ? ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 7 || _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() != null) ? (((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() == ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()) : (((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() == 0)) : (((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D() == Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			break;
		case 13:
			result = ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 19) ? ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 7 || _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() != null) ? (((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() == ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()) : (((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() == 0)) : (((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() == Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())));
			break;
		case 0:
			result = ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 7 && _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == null) ? (((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() == IntPtr.Zero) : ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 1) ? ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 13) ? (((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() == ((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzVC9FBdo_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : (((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() == new IntPtr(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()))) : (((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DzjYYAPCA_003D)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp() == new IntPtr(((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()))));
			break;
		case 20:
			result = ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 7 && _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == null) ? (((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() == UIntPtr.Zero) : ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 1) ? ((_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 13) ? (((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() == ((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : (((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() == new UIntPtr((ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzVC9FBdo_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()))) : (((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D() == new UIntPtr((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()))));
			break;
		case 7:
			result = _0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
			break;
		case 25:
			result = (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 7 || _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() != null) && ((_0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D)_0023_003DzjYYAPCA_003D)._0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL() == ((_0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D)_0023_003DzVC9FBdo_003D)._0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL();
			break;
		case 19:
		{
			_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D _0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D2 = (_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzjYYAPCA_003D;
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				result = Convert.ToInt64(_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D2._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()) == Convert.ToInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DzVC9FBdo_003D)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D());
			}
			else if (_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D2._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D() == null)
			{
				result = _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == null;
			}
			else if (_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() != null)
			{
				result = Convert.ToInt64(_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D2._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()) == Convert.ToInt64(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
			}
			break;
		}
		case 8:
		{
			double d = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			double num = ((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzVC9FBdo_003D)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D();
			result = !double.IsNaN(d) && !double.IsNaN(num) && d.Equals(num);
			break;
		}
		case 11:
		case 24:
		{
			_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D obj3 = (_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D)_0023_003DzjYYAPCA_003D;
			_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D _0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2 = (_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D)_0023_003DzVC9FBdo_003D;
			result = obj3._0023_003DzzWFR_0024vlWCB4qK6eZsTVSMAeCQadnOulkkHivQtWDnnOgE4qVeYb77rQH8EhBacgd9seMKNaB6QqFYJutOg_003D_003D(_0023_003DqluIhkfU76QJuQlzV2eZsNxvgiYhII_0024qxAvAqL6TdloM_003D2);
			break;
		}
		case 18:
		{
			_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2 = (_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D)_0023_003DzjYYAPCA_003D;
			_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D3 = (_0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D)_0023_003DzVC9FBdo_003D;
			result = _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzLZ4Al05E5dyu5Qqv8kCoqc7Io9NoSnfEuw_003D_003D() == _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D3._0023_003DzLZ4Al05E5dyu5Qqv8kCoqc7Io9NoSnfEuw_003D_003D() && _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D2._0023_003DzjxTj7yNPdHyn2C7oYeJs_652ufci() == _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D3._0023_003DzjxTj7yNPdHyn2C7oYeJs_652ufci();
			break;
		}
		case 23:
		{
			_0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D obj2 = (_0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D)_0023_003DzjYYAPCA_003D;
			_0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D _0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D2 = (_0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D)_0023_003DzVC9FBdo_003D;
			result = obj2._0023_003Dz9cLa4fSbw_0024YuqDOhZyVXAYptR7h2ZgZ_swy0YsaDDDS5() == _0023_003Dq454RVlZTsmz9OfX8mKyUs29E_0024FO2sBYXmJUirSR6pEc_003D2._0023_003Dz9cLa4fSbw_0024YuqDOhZyVXAYptR7h2ZgZ_swy0YsaDDDS5();
			break;
		}
		case 2:
		{
			_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D obj = (_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D)_0023_003DzjYYAPCA_003D;
			result = _0023_003DznAT2eFkICx6B9STO5ogYSiU_003D(((_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D)_0023_003DzVC9FBdo_003D)._0023_003DzziZoswQLVNeFsP98hnBAEV7aGwJW(), obj._0023_003DzziZoswQLVNeFsP98hnBAEV7aGwJW());
			break;
		}
		default:
			result = _0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() == _0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
			break;
		}
		return result;
	}

	private static void _0023_003DzWtU0G_0024_Zp8vlirC_Js4l7gq_0024q0fAKhRt9XwX8eax6Az_0024(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(1);
	}

	private static void _0023_003DzL54ae66vsjw5GZ9dSBhTXDJE3LAU_m7bmBnB21c_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(_0023_003DzhGgZIrA_003D);
	}

	private static void _0023_003DzdC7TmQGAq_7jMC_PZ95EDh1y7nRtTUbakTa7JFucf_e7(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private static void _0023_003Dz_zpN5f6cN_sElg05zs3akGM_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D2 = (_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (double.IsNaN(_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D2._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) || double.IsInfinity(_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D2._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()))
		{
			throw new OverflowException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621689));
		}
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D2);
	}

	private static void _0023_003DzZKLc0Jdl3h6_d7eAtyCkspQ_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzyUc_WyYV74Lpy97iDcTmNJM_003D(typeof(short));
	}

	private static void _0023_003Dz_LihIsurHWx3_5uyYrzrirA_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003DzkMvdZOzoLwdDseDkXiQIeCo_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzmoCa7lXUL7yvAaxU1Zbpx5T8XWXmYhrCsBrXsJwFxW7A2fsxJ1WfvAJMxdHd5pFpu_0024_0024m9jzUqDJr());
	}

	private static void _0023_003DzCVN_VyJLLQPFeMu2vQ089ywGq_Vv3NJVDQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dzbs_0024hQTPNkYOAARtNsmdtjJInauYQ5G09QlNpPeI_003D(null, num);
	}

	private static void _0023_003DzdFasG0ZCqGMBnuGQsgGIypx3xkK4(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003DzH8lUFebTEMxvgMN8fDd6dFRKgRaNYlqnJ_4i39A_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003Dz4NRcRof53EFYb6x5BJ2Xpl0_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzVC9FBdo_003D);
	}

	private static void _0023_003DzVUqKFtgvt2DGgl2yKQ0j0xSOKIze(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		object obj = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		long num = _0023_003DzjYYAPCA_003D._0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo();
		Array array = (Array)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(sbyte))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(sbyte));
			((sbyte[])array)[num] = (sbyte)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType == typeof(byte))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(byte));
			((byte[])array)[num] = (byte)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType == typeof(bool))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(bool));
			((bool[])array)[num] = (bool)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D4._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(elementType, obj, num, array);
		}
		else
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(typeof(sbyte), obj, num, array);
		}
	}

	private void _0023_003DzNV6s8_c3PVetxJK6bg_003D_003D(Type _0023_003DzjYYAPCA_003D)
	{
		object obj = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		long num = _0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo();
		Array array = (Array)_0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		_0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(_0023_003DzjYYAPCA_003D, obj, num, array);
	}

	private static void _0023_003DzGeCJb_0024wnM7k5F9dZMTUkbTE_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2 = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D;
		MethodBase methodBase = _0023_003DzjYYAPCA_003D._0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
		Type declaringType = methodBase.DeclaringType;
		Type type = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType();
		ParameterInfo[] parameters = methodBase.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		MethodBase methodBase2 = null;
		Type type2 = type;
		while (type2 != null && type2 != declaringType)
		{
			MethodInfo method = type2.GetMethod(methodBase.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array, null);
			if (method != null && method.GetBaseDefinition() == methodBase)
			{
				methodBase2 = method;
				break;
			}
			type2 = type2.BaseType;
		}
		if (methodBase2 == null)
		{
			methodBase2 = methodBase;
		}
		_0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D obj = new _0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D();
		obj._0023_003Dzs_H9tD4fic5haXYigbX6_iA_003D(methodBase2);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzmfIPvK_0024PsTQjNK_0024pCmCN9anQRL79l18SfU09xLs_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				int num2 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(num << num2);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003DzmfIPvK_0024PsTQjNK_0024pCmCN9anQRL79l18SfU09xLs_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())));
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 13)
		{
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 1)
			{
				long num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DzjYYAPCA_003D)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
				int num4 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
				return new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(num3 << num4);
			}
			if (_0023_003DzVC9FBdo_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
			{
				return _0023_003DzmfIPvK_0024PsTQjNK_0024pCmCN9anQRL79l18SfU09xLs_003D(_0023_003DzjYYAPCA_003D, new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzVC9FBdo_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())));
			}
		}
		if (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzmfIPvK_0024PsTQjNK_0024pCmCN9anQRL79l18SfU09xLs_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(Convert.ToInt64(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D);
			}
			return _0023_003DzmfIPvK_0024PsTQjNK_0024pCmCN9anQRL79l18SfU09xLs_003D(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(Convert.ToInt32(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D())), _0023_003DzVC9FBdo_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzKCew6PWLdl_flti8Q4CQRZo_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz1QxSginv6WXoVFiB40cXix_wQa7ycZHwpkc7eoE_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] _0023_003DzI9eprt34zNpdNPr5nm_ImGPBfgDrY0hZp70N_ps_003D()
	{
		_0023_003Dq3G38QCarrxCJZRMkg_wb8rf0EqPJVSpn1fDFXqBDpnM_003D[] array = m__0023_003DzbAh_0024yNw_003D._0023_003DzuPh4Rpaf4TxyAt0diywOJqsTt_nlkMJjoJDRqknOICmw();
		int num = array.Length;
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[] array2 = new _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(array[i]._0023_003DzuMFIezNyXctM9s7vaQuIipM_003D(), _0023_003DzVC9FBdo_003D: false));
		}
		return array2;
	}

	private static void _0023_003DzNedfprLLOel9rMbDASuzf3z9xHEk(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003DznAT2eFkICx6B9STO5ogYSiU_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private bool _0023_003DzDN0cYcmVZtLQS_0024WgO8o7AR0YAAsBb9rvrUqaGdw_003D()
	{
		if (_0023_003DzDw__wI8_003D == null)
		{
			return _0023_003DzoMNiNRw_003D.Count != 0;
		}
		return true;
	}

	private void _0023_003Dzw03qGZ6zeDrQcG40A5UjND4W_CNMp81RYA_003D_003D(MemberInfo _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003DzQ3tNhreMmkDoNhcVp56cQfbItZMjT8K1S7dWy7Y_003D() || m__0023_003DzbAh_0024yNw_003D._0023_003DzBf3yXeTp42WNEV4K9r1UciDf2wY_asZm7qimbJpXqP6w())
		{
			return;
		}
		bool flag = false;
		Assembly assembly = typeof(SecurityCriticalAttribute).Assembly;
		MemberInfo memberInfo = _0023_003DzjYYAPCA_003D;
		while (memberInfo != null)
		{
			object[] customAttributes = memberInfo.GetCustomAttributes(inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Type type = customAttributes[i].GetType();
				if (type.Assembly == assembly)
				{
					string fullName = type.FullName;
					if (_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620974).Equals(fullName, StringComparison.Ordinal))
					{
						flag = true;
						goto end_IL_009d;
					}
					if (_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621022).Equals(fullName, StringComparison.Ordinal))
					{
						goto end_IL_009d;
					}
				}
			}
			memberInfo = memberInfo.DeclaringType;
			continue;
			end_IL_009d:
			break;
		}
		if (flag)
		{
			if (_0023_003DzjYYAPCA_003D is MethodBase)
			{
				string text = _0023_003DzM_1DobppPL15BMKH098qp_JpvO0t94aGMu18fSU_003D((MethodBase)_0023_003DzjYYAPCA_003D);
				throw _0023_003DzcAn_0024G9Qy46uqlVBEbeJyZcbop5XNrB4APw4TERXh3Z8_0024(_0023_003DzBJtrg4eHkWySVWYW423_bcbxpROe(m__0023_003DzbAh_0024yNw_003D), text);
			}
			if (_0023_003DzjYYAPCA_003D is FieldInfo)
			{
				string text2 = _0023_003DzjYYAPCA_003D.DeclaringType.FullName + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810) + _0023_003DzjYYAPCA_003D.Name;
				throw _0023_003Dz2TxsmUWmUPQJUZXAxNDtmQoAtKBMrg5_DtpK55U_003D(_0023_003DzBJtrg4eHkWySVWYW423_bcbxpROe(m__0023_003DzbAh_0024yNw_003D), text2);
			}
			if (_0023_003DzjYYAPCA_003D is Type)
			{
				string fullName2 = ((Type)_0023_003DzjYYAPCA_003D).FullName;
				throw _0023_003Dztm4gexWTTs0hhUHNRjoX96Kq_0024j38(_0023_003DzBJtrg4eHkWySVWYW423_bcbxpROe(m__0023_003DzbAh_0024yNw_003D), fullName2);
			}
			throw new SecurityException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620802));
		}
	}

	private void _0023_003DznRra0OxARjzZ3cVwLdLnjrhJnN6q4QVwQ_0024hOrLs_003D()
	{
		_0023_003Dz3mPLcVxKEwE_D2oW_3wTpyy40yEfnTG93A_003D_003D(_0023_003Dz6It9KyA_003D, (_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2, _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D3) => (_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP() == _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D3._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP()) ? _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D3._0023_003DzWkGfI94pX_1bh7ki_0024ibBr76u1WoF7rtxOQ_003D_003D().CompareTo(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003DzWkGfI94pX_1bh7ki_0024ibBr76u1WoF7rtxOQ_003D_003D()) : _0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D2._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP().CompareTo(_0023_003DqP99fuuOnAyhRKsayApRlnIdAVYQ_00247SFTFws60zP69lg_003D3._0023_003Dzc3vqxvsUprAH9x64zyxdUTqOxPWP()));
	}

	private void _0023_003DzjZ5w2QCyoeebeU5XHnTLRZk_003D(bool _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzXyZ2GSC9jJ_ElHUQmw_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D));
	}

	private static void _0023_003DzldXlY9H_0024Q_0024KUxvbQuFyLAQKW_0024DlhaS_DbQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzdUHcgd4GhDGoM7VtTWsRa_0024I_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003DzXP4MBsJT5_0024NTE3oOJM1In_0024S40E87fw_0024xEO6hgZo_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		FieldInfo fieldInfo = _0023_003DzjYYAPCA_003D._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 as _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D;
		object obj = ((_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2 == null) ? _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D() : _0023_003DzjYYAPCA_003D._0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(_0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2)._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003DqPjU0as5GIhLtc26yxRodCsuxdpAOKrWwH9_00246JwS2Ufs_003D(fieldInfo, obj, _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D2));
	}

	private static void _0023_003DzdW8Z7Qw3r2vcfJdGYWPxha9Xe6ajrE9VSq_1o1O9EgK_0024(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (!_0023_003Dzf_0024WVtPE9Ybapotbf76zcghD2B20j0Z3_0024gQ_003D_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private static void _0023_003DzOZfkVahj53HAL2DsKiXPgwU_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzDE05hLaLH65q6l2w5aXfxhfkQSxYsID41w_003D_003D(3);
	}

	private static void _0023_003DzqRVPHAkNucbise69FHuFY9zzBGLXPu8lkA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = _0023_003DzjYYAPCA_003D._0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(num);
		object obj = ((_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003Dzr_EmRq1bb965XQHX42A1yCMQVgDqEWiC_0024Q_003D_003D() == 0) ? _0023_003DzjYYAPCA_003D._0023_003DzcQjwYtdnU_A4wJ_0024PMTbBHzusLlYmH_0024Q2lw_003D_003D(_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003DzMV75VwJRJCkRbVmMGcKSqOQtS5hN()) : (_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2._0023_003Dzda7qbCrYRS_dkFu4eYeIJBGfF1ZN()._0023_003DzrYIfhcGlGVe7T3fQtVmCnm8m2BhYb1LinJVGC5Gbj26ViVyT1IZX8w9Wxt_0024z_0024avheIBYlexd8AkLaZ_MjTw3ISU_003D() switch
		{
			2 => _0023_003DzjYYAPCA_003D._0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(num, _0023_003DzVC9FBdo_003D: true).TypeHandle, 
			0 => _0023_003DzjYYAPCA_003D._0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(num).MethodHandle, 
			1 => _0023_003DzjYYAPCA_003D._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num).FieldHandle, 
			_ => throw new InvalidOperationException(), 
		}));
		_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D obj2 = new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D();
		obj2._0023_003Dzlag9PFrG6XQuYwHv3i0Ig1A_003D(obj);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj2);
	}

	private static void _0023_003DzfGPQuj_0024jdsc4FzPTuzEVY_0024h7CxMLxYxWCDSjlpWXPtzZ(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(1);
	}

	private void _0023_003DzMrJpDjzTv4w8b_0024EDqRHaMnnujtbSQqxrkuL8ibA_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		MethodBase methodBase = _0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(num);
		Type declaringType = methodBase.DeclaringType;
		ParameterInfo[] parameters = methodBase.GetParameters();
		int num2 = parameters.Length;
		object[] array = new object[num2];
		Dictionary<int, _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D> dictionary = new Dictionary<int, _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
			if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 is _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D value)
			{
				dictionary.Add(num3, value);
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dzpuo5o9xAscxOfVi_0024wDIM7N_0024_GTb7aJ7xTDeDZkqKJr2S(value);
			}
			if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D() != null)
			{
				_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D())._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
			}
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, parameters[num3].ParameterType)._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2);
			array[num3] = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		object obj;
		try
		{
			obj = _0023_003DzxRKpnEfB4r0_0024al4LmLb_0024SVDOPjC6rNNG_Q_003D_003D(methodBase, null, array, _0023_003Dzf4Pqh9s_003D: false);
		}
		catch (TargetInvocationException ex)
		{
			Exception ex2 = ex.InnerException ?? ex;
			_0023_003DzPalNqUCr87jJQ2wBQmQB49pkBtH_0024(ex2);
			return;
		}
		foreach (KeyValuePair<int, _0023_003DqNRMsnRsOD6zmKIGS86f_zvYBBUBcQK64OQod8oGh0vk_003D> item in dictionary)
		{
			_0023_003DzRVlZ73R0JCKUjSf5fPAjAtc_003D(item.Value, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(array[item.Key], null));
		}
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, declaringType));
	}

	private _0023_003Dq3G38QCarrxCJZRMkg_wb8rf0EqPJVSpn1fDFXqBDpnM_003D[] _0023_003DzO4Q5lCPEgH3pF_00249XhOR6NFr6mvS58S9BBrMoewk_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dq3G38QCarrxCJZRMkg_wb8rf0EqPJVSpn1fDFXqBDpnM_003D[] array = new _0023_003Dq3G38QCarrxCJZRMkg_wb8rf0EqPJVSpn1fDFXqBDpnM_003D[_0023_003DzjYYAPCA_003D._0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzfgZ7AwDbh6mXY18CrZyt9gU7CC_0024L(_0023_003DzjYYAPCA_003D);
		}
		return array;
	}

	private static object _0023_003DzILwSVJ_ETdKfjFYYiqfi8sJNEFoswfvrOmcv9cichdCe(MethodBase _0023_003DzjYYAPCA_003D, object _0023_003DzVC9FBdo_003D, object[] _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		_0023_003DzJ6W8874_003D _0023_003DzJ6W8874_003D2 = new _0023_003DzJ6W8874_003D(_0023_003DzjYYAPCA_003D, _0023_003Dzf4Pqh9s_003D);
		_0023_003DzraVZG9g_003D _0023_003DzraVZG9g_003D2 = _0023_003DzcDw9Umm90KMTcwqhsxOouJs_003D(_0023_003DzJ6W8874_003D2);
		if (_0023_003DzraVZG9g_003D2 == null)
		{
			bool flag;
			lock (_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzwBouG0w_003D)
			{
				_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzwBouG0w_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value);
				flag = value >= 50;
				if (!flag)
				{
					_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzwBouG0w_003D[_0023_003DzjYYAPCA_003D] = value + 1;
				}
			}
			if (!flag && (_0023_003Dzf4Pqh9s_003D || _0023_003DzVC9FBdo_003D != null || _0023_003DzjYYAPCA_003D.IsStatic || _0023_003DzjYYAPCA_003D.IsConstructor) && !_0023_003DzcPlDgJvoEi5_1mBUYJMRCygipnQIjsZiRuSBT9IQXNpX(_0023_003DzjYYAPCA_003D) && (_0023_003DzjYYAPCA_003D.CallingConvention & CallingConventions.Any) != CallingConventions.VarArgs)
			{
				return _0023_003DzT5WJMTijRhl7mUu1uw_003D_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			_0023_003DzraVZG9g_003D2 = _0023_003DziL3lnfTn0zrsnlZ_LInxeHJfndrMRbVJ9Q_003D_003D(_0023_003DzJ6W8874_003D2);
			lock (_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzwBouG0w_003D)
			{
				_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003DzwBouG0w_003D.Remove(_0023_003DzjYYAPCA_003D);
			}
		}
		return _0023_003DzraVZG9g_003D2(_0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
	}

	private void _0023_003DzPz79U8MaLS22fM00Cw_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DzjYYAPCA_003D));
	}

	private static void _0023_003Dzgjmm7D8BowHkDDANMVVF_0024sxNAV0RKMW38w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzCRzhi0odXZzU_0024XcUrFYRbVlxtGG_ADcy0TmzMQc_003D();
	}

	private static void _0023_003Dzlhaep8HqUDVoSvW03lcpGbDN0i4sfGNOX05n_QY_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622385));
	}

	private _0023_003Dq3G38QCarrxCJZRMkg_wb8rf0EqPJVSpn1fDFXqBDpnM_003D _0023_003DzfgZ7AwDbh6mXY18CrZyt9gU7CC_0024L(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dq3G38QCarrxCJZRMkg_wb8rf0EqPJVSpn1fDFXqBDpnM_003D obj = new _0023_003Dq3G38QCarrxCJZRMkg_wb8rf0EqPJVSpn1fDFXqBDpnM_003D();
		obj._0023_003DzRKYIcBOTAxmqOAZqI5z_0024H6GwYK1CJziCgA_003D_003D(_0023_003DzjYYAPCA_003D._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
		return obj;
	}

	private Stack<_0023_003DzDp118Pw_003D> _0023_003DzRN_0024T_e_ketn6jFfvoGJBd6Z0eCaV()
	{
		Stack<_0023_003DzDp118Pw_003D> stack = _0023_003Dzi8OTyx4_003D;
		if (stack == null)
		{
			stack = (_0023_003Dzi8OTyx4_003D = new Stack<_0023_003DzDp118Pw_003D>());
			stack.Push(new _0023_003DzDp118Pw_003D
			{
				_0023_003DzVC9FBdo_003D = _0023_003Dzivyja_00240_003D,
				_0023_003DzwBouG0w_003D = _0023_003Dzivyja_00240_003D._0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D(),
				_0023_003Dzf4Pqh9s_003D = _0023_003DzevtAwuM_003D
			});
		}
		return stack;
	}

	private static void _0023_003DzAlf6ix7B1qKgPYM8yQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DzjYYAPCA_003D._0023_003Dzl6jejgAs6dRjbmebDDP7OOz_0024X5wFpDr9hA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2));
	}

	private void _0023_003DzdUHcgd4GhDGoM7VtTWsRa_0024I_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		short num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (!_0023_003DzjYYAPCA_003D) ? ((short)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()) : checked((short)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
			13 => (!_0023_003DzjYYAPCA_003D) ? ((short)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()) : checked((short)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
			19 => (!_0023_003DzjYYAPCA_003D) ? ((short)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : checked((short)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (!_0023_003DzjYYAPCA_003D) ? ((short)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((short)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((short)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((short)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((!_0023_003DzjYYAPCA_003D) ? ((short)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((short)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D obj = new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D();
		obj._0023_003Dz_0024My_f5aDNZmtzsx4LL1UCqYWc1Ht(num);
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	private static void _0023_003DzKskMKPPrIMykM2vr9MHBIQthOTvumrd4pNX1uos_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		int num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		FieldInfo fieldInfo = _0023_003DzjYYAPCA_003D._0023_003DzSl_0024vfUWmlJHcYTsTDv_0024ZY_6DLTE01sK6zKpSuefXFp_0024c(num);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(fieldInfo.GetValue(null), fieldInfo.FieldType));
	}

	private static void _0023_003DzzAGcnHt4rMiwZX9Ohi_rTodzA2MLV3Truw_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(0);
	}

	private static void _0023_003Dz1wFmrgY0lcWEHEgBC6Q2tUI9sucTWaKSDnz8blzuRy_A(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzvUiGDfW6NiaAaooeEg5iWrID3au4J8_204HZFb3Lg7MF(_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D);
	}

	private static void _0023_003DzRSdJPqqnhgG7iJjY_SLqPpY_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		float num = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => (float)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D obj = new _0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D();
		obj._0023_003DzSVN0ioX68NyVMCXht4MUXkfW9rpZuJIYjE8olYs_003D(num);
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = _0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(_0023_003DzjYYAPCA_003D);
		MethodBase result = _0023_003DzaAnEqGxEYVIky7u6aHRajNVELEAgywuVoJq5Bhg_003D(_0023_003DzjYYAPCA_003D, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2);
		_0023_003Dzw03qGZ6zeDrQcG40A5UjND4W_CNMp81RYA_003D_003D(result);
		return result;
	}

	private static void _0023_003DzJtK9HSchLzbV0F9e7m8_0024frjK_QBexpBz8w_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPhOe5dIgi9gNB__002400g_003D_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003DzYnaB_0024xsOKB4HNJHD1aLmzvTQ4xmMA53SDrwm9qg_003D(ILGenerator _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		switch (_0023_003DzVC9FBdo_003D)
		{
		case -1:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_M1);
			return;
		case 0:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_0);
			return;
		case 1:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_1);
			return;
		case 2:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_2);
			return;
		case 3:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_3);
			return;
		case 4:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_4);
			return;
		case 5:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_5);
			return;
		case 6:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_6);
			return;
		case 7:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_7);
			return;
		case 8:
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_8);
			return;
		}
		if (_0023_003DzVC9FBdo_003D > -129 && _0023_003DzVC9FBdo_003D < 128)
		{
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4_S, (sbyte)_0023_003DzVC9FBdo_003D);
		}
		else
		{
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Ldc_I4, _0023_003DzVC9FBdo_003D);
		}
	}

	private object _0023_003DzX8gnPxk6aVoWmV6DcPUIAXx2_0024KEAuLJ7MydlvbUDUPEq(object[] _0023_003DzjYYAPCA_003D, Type[] _0023_003DzVC9FBdo_003D, Type[] _0023_003DzwBouG0w_003D, object[] _0023_003Dzf4Pqh9s_003D)
	{
		_0023_003DzdxMuTgdgBeB12Q4sxyS6jJw_003D();
		if (_0023_003DzjYYAPCA_003D == null)
		{
			_0023_003DzjYYAPCA_003D = global::_0023_003DqVcjta0_jSHC_KNEfba3YbsHkfP0vZKefZqNy0GiIyYE_003D<object>._0023_003DzjYYAPCA_003D;
		}
		this.m__0023_003DzLtLprGE_003D = _0023_003Dzf4Pqh9s_003D;
		_0023_003DzaKmBh2M_003D = _0023_003DzVC9FBdo_003D;
		this.m__0023_003Dzf4Pqh9s_003D = _0023_003DzwBouG0w_003D;
		_0023_003DzKfi4z6E_003D = _0023_003DzvNyS6ZQfijYnSqWPGUw_0024e1Q4ky7VCX_0024OPw1C_fg_003D(_0023_003DzjYYAPCA_003D);
		this.m__0023_003Dzt2pW2yo_003D = _0023_003DzI9eprt34zNpdNPr5nm_ImGPBfgDrY0hZp70N_ps_003D();
		try
		{
			_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2 = new _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D(this.m__0023_003DzmZWYhFQ_003D);
			try
			{
				using (_0023_003Dzivyja_00240_003D = new _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D(_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2))
				{
					_0023_003Dz2BwZl2w_003D = (uint)_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2._0023_003DzSo_gaJJm3gV22vwn_0024ZQKP2jkH1Wi8Q1d_0024iW8L0sqejJVZPcg9_XQ6lNh50Arlf2kDIcUyU9sztWajFgX9XnbyJg_003D();
					_0023_003DzQizPEX8_003D = false;
					_0023_003DzOIZPJ_00248_003D = null;
					this.m__0023_003DzmjtwFUo_003D = 0u;
					_0023_003DzWoS2eJk_003D = 0u;
					_0023_003DzyPEOtNr8yOqWQPGxf9ATqDQ_003D();
					_0023_003DzslACxgLiNWnnlXdB895RmsfYjCx082lHrsvBxQ6W5SeU();
				}
			}
			finally
			{
				((IDisposable)_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2).Dispose();
			}
			Type type = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(m__0023_003DzbAh_0024yNw_003D._0023_003DzhG5dcPBwgHZkh1c2OjFbi6be_MyHOUg_fw_003D_003D(), _0023_003DzVC9FBdo_003D: false);
			if (type != _0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D.m__0023_003Dz1SmHC4c_003D && _0023_003DzDN0cYcmVZtLQS_0024WgO8o7AR0YAAsBb9rvrUqaGdw_003D())
			{
				return _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, type)._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D())._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
			}
			return null;
		}
		finally
		{
			for (int i = 0; i < m__0023_003DzbAh_0024yNw_003D._0023_003Dzjfr8w_0024YG19uko57Az4_0024mv7ElFen3().Length; i++)
			{
				_0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D _0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D2 = m__0023_003DzbAh_0024yNw_003D._0023_003Dzjfr8w_0024YG19uko57Az4_0024mv7ElFen3()[i];
				if (_0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D2._0023_003DzMW8RMCedlHk3F9zBMrk3xvIZGCxXxH2NIA_003D_003D())
				{
					_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D _0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D2 = (_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D)_0023_003DzKfi4z6E_003D[i];
					Type type2 = _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(_0023_003DquMh_RbFIfA6Odscsrwq4H62JXdJMCHkp5pTxI3ieh3s_003D2._0023_003Dzt1eFV4wjyaQl60ABlEzvR_jbEMrSq_00240mR6y9GXRV3_pj(), _0023_003DzVC9FBdo_003D: false);
					_0023_003DzjYYAPCA_003D[i] = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(null, type2.GetElementType())._0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003Dqr_0024moDzrF9M_yY31eccEmV5iyd8uufFMxgTRDSm3UXZI_003D2._0023_003DzziZoswQLVNeFsP98hnBAEV7aGwJW())._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
				}
			}
			this.m__0023_003DzLtLprGE_003D = null;
			_0023_003DzKfi4z6E_003D = null;
			this.m__0023_003Dzt2pW2yo_003D = null;
		}
	}

	private static void _0023_003DzoDfvLO8q6gm7oCA12XDqxfINiEsTCB4DL2_sjzI_003D(ILGenerator _0023_003DzjYYAPCA_003D, Type _0023_003DzVC9FBdo_003D)
	{
		if (!(_0023_003DzVC9FBdo_003D == _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D))
		{
			_0023_003DzjYYAPCA_003D.Emit(OpCodes.Castclass, _0023_003DzVC9FBdo_003D);
		}
	}

	private static void _0023_003Dz6TJX6GwJA7JRdtHrUC8iCtw_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz5uz1g3hDsw_0024kQ_0024BOnU6xGYrafh_gbeI2XC40mbg_003D(((_0023_003Dqv5jNEINgRiU3U0uL89SFa1qSutiw1Inh4IslRyXovHk_003D)_0023_003DzVC9FBdo_003D)._0023_003DzmW4DO7bZs_8QrPWaKX4DvN4_003D());
	}

	private Type _0023_003Dz25qlb246hTWT3dZUh1hyfDp7QR5_0024OBHY7q4FH9w_003D(int _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		Type type;
		lock (_0023_003Dzgd4c0yY_003D)
		{
			bool flag = true;
			if (flag && _0023_003Dzgd4c0yY_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value))
			{
				type = (Type)value;
			}
			else
			{
				_0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2 = _0023_003DzRRgr4RfBj61mWcoyDz_0024yuAxgKYH5(_0023_003DzjYYAPCA_003D);
				type = _0023_003Dzc9tMfLKP0BugYDxtDq9aQxDOilg5sy7xBmrPETo_003D(_0023_003DzjYYAPCA_003D, _0023_003DqbhNRXVC7qubyuF3OY4q_0024sbgt7B_0024JKP7qkN8VY1ZCb_k_003D2, ref flag, _0023_003DzVC9FBdo_003D);
				if (flag)
				{
					_0023_003Dzgd4c0yY_003D.Add(_0023_003DzjYYAPCA_003D, type);
				}
			}
		}
		if (_0023_003DzVC9FBdo_003D)
		{
			_0023_003Dzw03qGZ6zeDrQcG40A5UjND4W_CNMp81RYA_003D_003D(type);
		}
		return type;
	}

	private static void _0023_003Dzz_0024jXMf8XK18QRMQUwZxZCITj0kivdRx6kY4W4Geaw_jN(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (ushort)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (ushort)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (ushort)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => (ushort)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((ushort)(uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzvQyud78xlsmLdllzCeQEeOg39WkCcjDD_g_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		MethodBase methodBase = ((_0023_003Dqx7hcqAtUOfazww1XKs1cqycZIt0poj2QdQ64NXQKD1k_003D)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D())._0023_003DzrIqje1BSb08zJ_ToAmnVGXE_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz0xkx_0024FbQA5T935rV9MlZIZQ_003D(methodBase, _0023_003DzVC9FBdo_003D: false);
	}

	private static _0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D _0023_003Dz9H6fXyzrPyrSqa8AE5aXDwx8c0jT(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D obj = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (obj._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 13)
		{
			throw new InvalidOperationException();
		}
		long num = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)obj)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK();
		int num2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D();
		if (num2 != 7 && num2 != 9)
		{
			throw new InvalidOperationException();
		}
		byte[] array = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8TL1Vj_1GqTYBVSrg8oPYEM_003D._0023_003Dz4_Z93rVUyRdjsh8W60rvgetSisr3(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
		if (_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num3 = ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D();
		_0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D obj2 = new _0023_003Dqu2lukaMdtknH99Y0fKPgRwmNKHBe7u_0024iZnMGyzpcVy4_003D();
		obj2._0023_003Dz1PwfpIWvVRdlNP5tmeybEdM_003D(num3);
		obj2._0023_003DzigXdfim56fRXB3WY0B2wrWJS0QVu(array);
		obj2._0023_003DztqTcjLtVDc7bRp2fDUgk3rbfWuAJ(num);
		return obj2;
	}

	private static void _0023_003Dzu68lHPA2xBMZd0qM3qGstMyPufBmyNLRuQ_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003DzPalNqUCr87jJQ2wBQmQB49pkBtH_0024(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
	}

	private void _0023_003Dz_Z2_JTJDd9sWOd03XiTIY386_00248_0024k()
	{
		if (this.m__0023_003DzjYYAPCA_003D.Count == 0)
		{
			if (this.m__0023_003DzraVZG9g_003D)
			{
				_0023_003DzPalNqUCr87jJQ2wBQmQB49pkBtH_0024(_0023_003DzY8c1My4_003D);
			}
			return;
		}
		_0023_003DzTFNDoh0_003D _0023_003DzTFNDoh0_003D2 = this.m__0023_003DzjYYAPCA_003D.Pop();
		if (_0023_003DzTFNDoh0_003D2._0023_003DzjTdiSl_0024wIvTwOshSqwEvP4Q_003D() != null)
		{
			_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D obj = new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D();
			obj._0023_003DzJ_00243zxDoz_EC2ZmGwNXvz3C7v3EjPShf7WXfj3bqqUgJuXtVcXDnwxF8xdcUJcRwU58dzdxpX0qKZsv_sB56GJqw_003D(_0023_003DzTFNDoh0_003D2._0023_003DzjTdiSl_0024wIvTwOshSqwEvP4Q_003D());
			_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(obj);
		}
		else
		{
			_0023_003DzyPEOtNr8yOqWQPGxf9ATqDQ_003D();
		}
		_0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(_0023_003DzTFNDoh0_003D2._0023_003DzhoMbiYCjPiX5HmHGX5R_0024L9b6zXYc());
	}

	private static void _0023_003DzUs7QHTDawIPZdoLBlz1AGLoB4fUrHOQflA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2 = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzVC9FBdo_003D;
		MethodBase methodBase = _0023_003DzjYYAPCA_003D._0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
		_0023_003DzjYYAPCA_003D._0023_003Dz0xkx_0024FbQA5T935rV9MlZIZQ_003D(methodBase, _0023_003DzVC9FBdo_003D: false);
	}

	private static void _0023_003DzjB3Y3ZbAwxd1qLDmJdC_0024Ln_H6GtBPgByNWpj_Mk_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (int)checked((uint)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
			19 => (int)checked((uint)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (int)checked((uint)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((int)checked((uint)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzsKa6aC4yCYRYc_0024rMi6u_eytZiduYunPMx5igbd257DqZ(_0023_003Dqb1QIyuS8QOki0iL4NUD1SV9pfkA78CNznltlIpBIDRA_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzQ3tNhreMmkDoNhcVp56cQfbItZMjT8K1S7dWy7Y_003D() && !m__0023_003DzbAh_0024yNw_003D._0023_003DzBf3yXeTp42WNEV4K9r1UciDf2wY_asZm7qimbJpXqP6w() && _0023_003DzjYYAPCA_003D._0023_003DzBf3yXeTp42WNEV4K9r1UciDf2wY_asZm7qimbJpXqP6w() && !_0023_003DzjYYAPCA_003D._0023_003DzNhMVECZWZrt4tITZr_0024GlTnPpcKKW())
		{
			string text = _0023_003DzBJtrg4eHkWySVWYW423_bcbxpROe(_0023_003DzjYYAPCA_003D);
			throw _0023_003DzcAn_0024G9Qy46uqlVBEbeJyZcbop5XNrB4APw4TERXh3Z8_0024(_0023_003DzBJtrg4eHkWySVWYW423_bcbxpROe(m__0023_003DzbAh_0024yNw_003D), text);
		}
	}

	private object _0023_003DzcQjwYtdnU_A4wJ_0024PMTbBHzusLlYmH_0024Q2lw_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		switch (_0023_003Dqkfr58uYm3J6TSax_00245eZLiqLBpilxpScdfTwiCPZv6F8_003D._0023_003DzAGXICJQuLwbmEo4hUX3_0024h28Yy7wV(_0023_003DzjYYAPCA_003D))
		{
		case 16777216:
		case 33554432:
		case 452984832:
			return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveTypeHandle(_0023_003DzjYYAPCA_003D);
		case 67108864:
			return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveFieldHandle(_0023_003DzjYYAPCA_003D);
		case 100663296:
		case 721420288:
			return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveMethodHandle(_0023_003DzjYYAPCA_003D);
		case 167772160:
			try
			{
				return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveFieldHandle(_0023_003DzjYYAPCA_003D);
			}
			catch
			{
				try
				{
					return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveMethodHandle(_0023_003DzjYYAPCA_003D);
				}
				catch
				{
					throw new InvalidOperationException();
				}
			}
		default:
			throw new InvalidOperationException();
		}
	}

	private static void _0023_003DzwqoPMVp6UFSBFAz9DM_jUJZY4rDy(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz3_0024OcLlRdWsXuQSRcTXltEtyOkpfY(3);
	}

	private object _0023_003DzEioGLkR0_0024_0024CPX5lkRi0SzUn7LWa_qYHPx7oRuWN3Y6cG(Stream _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, object[] _0023_003DzwBouG0w_003D, Type[] _0023_003Dzf4Pqh9s_003D, Type[] _0023_003DzTFNDoh0_003D, object[] _0023_003DzraVZG9g_003D)
	{
		this.m__0023_003DzRoqMfFc_003D = _0023_003DzjYYAPCA_003D;
		_0023_003DzBR8qL8OpsOF08xMEK0MxCYoJrWlQ(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, null);
		return _0023_003DzX8gnPxk6aVoWmV6DcPUIAXx2_0024KEAuLJ7MydlvbUDUPEq(_0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D);
	}

	private void _0023_003Dze0PMT9UZHrSUMFsj4aVkIXAs__0024qn(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (!_0023_003DzjYYAPCA_003D) ? ((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()) : checked((uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
			13 => (!_0023_003DzjYYAPCA_003D) ? ((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK() : ((long)checked((ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK())), 
			19 => (long)((!_0023_003DzjYYAPCA_003D) ? Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()) : Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (long)((!_0023_003DzjYYAPCA_003D) ? ((ulong)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((ulong)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D())), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((long)checked((ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()))) : ((!_0023_003DzjYYAPCA_003D) ? ((uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())), 
			20 => (long)((UIntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : ((ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D())) : ((!_0023_003DzjYYAPCA_003D) ? ((uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : ((uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzZphYYKQ8kEZVbHV0SDCmkB8_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2 = (_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DzjYYAPCA_003D;
		MethodBase methodBase = _0023_003Dz3c57TILa8Vb__0024blcTyRE8I8Ri3nai8krTA_003D_003D(_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D2._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D());
		if (_0023_003Dz8GBMuoM_003D != null)
		{
			ParameterInfo[] parameters = methodBase.GetParameters();
			Type[] array = new Type[parameters.Length];
			int num = 0;
			ParameterInfo[] array2 = parameters;
			foreach (ParameterInfo parameterInfo in array2)
			{
				array[num++] = parameterInfo.ParameterType;
			}
			MethodInfo method = _0023_003Dz8GBMuoM_003D.GetMethod(methodBase.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array, null);
			if (method != null)
			{
				methodBase = method;
			}
			_0023_003Dz8GBMuoM_003D = null;
		}
		_0023_003Dz0xkx_0024FbQA5T935rV9MlZIZQ_003D(methodBase, _0023_003DzVC9FBdo_003D: true);
	}

	private static void _0023_003Dz0o12iWcxdQSWglDTSkqZ74w9h5Xqhbxk5IcSh9M_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzdUHcgd4GhDGoM7VtTWsRa_0024I_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private static void _0023_003Dz_00243qwdaALbDU6_0024ljvLkgGZ08qwI1VxTChGhib9IM_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzMVTODo0aUkOVcJ8fi_0024sc2Zw_003D(0);
	}

	private static void _0023_003DzHa7slzoHYTJpNrs9mXp8mLCP0MRN6uQY2pd1ZA9Sit25(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		object obj = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		long num = _0023_003DzjYYAPCA_003D._0023_003DzOCBZ0cjNL0_wokZx5KbtbXBuxtfo();
		Array array = (Array)_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D()._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(long))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(long));
			((long[])array)[num] = (long)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType == typeof(ulong))
		{
			_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3 = _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D._0023_003DzgAQVjx_0024dfksTxrcc9qSFMGwkh1fbaCEKTuDwA_0024w_003D(obj, typeof(ulong));
			((ulong[])array)[num] = (ulong)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D3._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(elementType, obj, num, array);
		}
		else
		{
			_0023_003DzjYYAPCA_003D._0023_003DzQ4I3fUWwj2KqSM2zc7_0024deBdyHHbL(typeof(long), obj, num, array);
		}
	}

	private static void _0023_003DzhMn1pxGDLYhlMiVKo_7a0E5pNOpRP_0024gnJA_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dz_Z2_JTJDd9sWOd03XiTIY386_00248_0024k();
	}

	private void _0023_003DzPhOe5dIgi9gNB__002400g_003D_003D(bool _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (!_0023_003DzjYYAPCA_003D) ? ((byte)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()) : checked((byte)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D()), 
			13 => (!_0023_003DzjYYAPCA_003D) ? ((byte)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()) : checked((byte)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK()), 
			19 => (!_0023_003DzjYYAPCA_003D) ? ((byte)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())) : checked((byte)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D())), 
			8 => (!_0023_003DzjYYAPCA_003D) ? ((byte)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()) : checked((byte)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((byte)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((byte)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())) : ((!_0023_003DzjYYAPCA_003D) ? ((byte)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : checked((byte)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003DzjYYAPCA_003D) ? ((byte)(ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : checked((byte)(ulong)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D())) : ((!_0023_003DzjYYAPCA_003D) ? ((byte)(uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D()) : checked((byte)(uint)((_0023_003Dq6BQK4POmdQSdOG1gXvn7D52hETT8NqYp9s_0024Efuca9kw_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz8Xbu_z66HZwJgE2us5B4JKhhch4HCdIRLQ_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003Dz2_zqpZq29PRvwaIPbGotB9vUey9y5rIJDXo7eRaCUHDF(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dz_6X6RPctA13PXppIbyeE_AbeTyu5(new _0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D(checked(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D() switch
		{
			1 => (short)(uint)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEl5zycrn0xWB5mZKvWEsQ_Q_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzVnocj78JGwe6sXBqSjaO_0024NnyRU_0024mhImrsA_003D_003D(), 
			13 => (short)(ulong)((_0023_003Dq6ahKqDV0bHMcXnMCBkwrEtFpipgs6t9iCYeFhvMw7rU_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzZ79hV5lAbjFG1lUwEAEm3F6qWPy_N04Bb4KS0q_0024lRXIK(), 
			19 => (short)Convert.ToUInt64(((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbY4h_S7g9LkdrO0592xeCfI_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003Dz53FiA6wcoSA8D37xqu1LnSI_003D()), 
			8 => (short)((_0023_003DqiA1d0doSeLnh_VY97pG2QH6AfU8AM9tMVI6DoPVW4fo_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzwTJH7NvHW0Ap67_0024SAsuT6DUweXP2pyIvNA_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((short)(ulong)(long)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()) : ((short)(uint)(int)((_0023_003DqCYtpYjw7PR14CpnIyTweysuTfjAmb0CMn0jW4XW_00241C8_003D)_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2)._0023_003DzcqT_0024UsFGlhKCwRAlliUcW_00249cvINp()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzIENFZMhaQNCsCY1JN6DjTPIzDY_ZO2U42SocMbBBHOaH(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2 = _0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D();
		if (_0023_003Dzx7GYkLRRzuFm9D0Dvs1moxvmF45Xl8NjClRD15Q_003D(_0023_003DzjYYAPCA_003D._0023_003Dz2cs5Fq4871Tw4jO3Ig_003D_003D(), _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D2))
		{
			uint num = ((_0023_003DqowHKvOKCRadGRJLlIH7sjbksj1cGBpFZCFkmMMGpxus_003D)_0023_003DzVC9FBdo_003D)._0023_003DzC64Zf7qBPoEyJYJ7VCFkPCU2yGA_Hpuwlw_003D_003D();
			_0023_003DzjYYAPCA_003D._0023_003Dzlayexw_x_JISBXgVLvXAR5g_003D(num);
		}
	}

	private void _0023_003Dzxn1GiqJsszWIPLqbSNdHO5j1n2nqhb_8GQr0yfc_003D(_0023_003DzDp118Pw_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dzivyja_00240_003D = _0023_003DzjYYAPCA_003D._0023_003DzVC9FBdo_003D;
		_0023_003DzevtAwuM_003D = _0023_003DzjYYAPCA_003D._0023_003Dzf4Pqh9s_003D;
	}

	private static bool _0023_003DzQ3tNhreMmkDoNhcVp56cQfbItZMjT8K1S7dWy7Y_003D()
	{
		return false;
	}

	private static bool _0023_003DzcPlDgJvoEi5_1mBUYJMRCygipnQIjsZiRuSBT9IQXNpX(MethodBase _0023_003DzjYYAPCA_003D)
	{
		ParameterInfo[] parameters = _0023_003DzjYYAPCA_003D.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			if (parameters[i].ParameterType.IsByRef)
			{
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzsL0aIKlnpQ5DqbO0YQeNTO9yf6TX(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003Dze0PMT9UZHrSUMFsj4aVkIXAs__0024qn(_0023_003DzjYYAPCA_003D: false);
	}

	private static void _0023_003DzP7HPBC_0024XzcEoBKmtfRvvGR8_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzPz79U8MaLS22fM00Cw_003D_003D(7);
	}

	private static void _0023_003DzRCZ65n1CAPJNK2vduDk51WU080nb23TBlw_003D_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzsaqDCdXA1fjkGC_0024VCiTIyfc_003D(((_0023_003DqwN1pp3xYYa9UUayAUmDw5tj8S_00243cEVuetKcVNaNyOT8_003D)_0023_003DzVC9FBdo_003D)._0023_003DzUrMOHuJ4xEdyCagt_0024A_003D_003D());
	}

	private static void _0023_003DzD8gXOD3imR_0024VjcozXWa_0024Fzy6a_0024VNvk8CGzhtJIA_003D(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D _0023_003DzjYYAPCA_003D, _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzjYYAPCA_003D._0023_003DzXMS1M_M1OGkgq8BfaLjs7A4Ea0_00245rZWliw_003D_003D(_0023_003DzjYYAPCA_003D: false);
	}

	[Conditional("DEBUG")]
	private void _0023_003DzZ8cfT5MJ7k7eG1XKaadEFsUwfFlW(object _0023_003DzjYYAPCA_003D)
	{
	}

	private static bool _0023_003DzG7wWBse_002434UcDBdIDTNaews_003D(uint _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D, uint _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D >= _0023_003DzVC9FBdo_003D)
		{
			return _0023_003DzjYYAPCA_003D <= _0023_003DzVC9FBdo_003D + _0023_003DzwBouG0w_003D;
		}
		return false;
	}
}
