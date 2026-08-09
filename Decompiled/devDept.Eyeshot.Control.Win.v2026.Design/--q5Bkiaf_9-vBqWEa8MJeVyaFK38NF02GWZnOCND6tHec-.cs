using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dq5Bkiaf_9_0024vBqWEa8MJeVyaFK38NF02GWZnOCND6tHec_003D : _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dq6tS8rMV1rGswJPasZDHd79p3grccgecsUnZJdkolocw_003D _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzzKDx05I_003D;

	public _0023_003Dq5Bkiaf_9_0024vBqWEa8MJeVyaFK38NF02GWZnOCND6tHec_003D(_0023_003Dq6tS8rMV1rGswJPasZDHd79p3grccgecsUnZJdkolocw_003D _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzGsIvs9WJkp3mAOjK83j9CB1lRhmt6LIbhcQDXmTKocSs())
		{
			throw new NotSupportedException();
		}
		this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003DzBxpHhQ0_003D = new byte[_0023_003Dz9jrlnWk_003D._0023_003DzuStpncDoFB_0024Bn9X5utYOeB3A395GiZ_0024S_00241CSFTjWTpb_Iwp2iPbLvZPZ_q72dNX1SakAOAk_003D()];
		_0023_003Dztgqm2r4_003D = _0023_003DzrnCHFJ2XljSObFjKuRssZj2bGjjRRkFVfA_003D_003D();
		_0023_003DzzKDx05I_003D = _0023_003Dzbrrj_Y8CczMURMvgeuTNVp19tRKX_jlJI_0024T3Y5I_003D();
	}

	private int _0023_003DzrnCHFJ2XljSObFjKuRssZj2bGjjRRkFVfA_003D_003D()
	{
		return _0023_003Dz9jrlnWk_003D._0023_003Dzl3Rckx5OVe4f3GM0WfBt7ZdV11R_0024nASNDSkqwIZT1MAKB0ukP_00242MtXtNOAkqHH1UoeoQg0tHnRD_x9ZBIg_003D_003D();
	}

	private int _0023_003Dzbrrj_Y8CczMURMvgeuTNVp19tRKX_jlJI_0024T3Y5I_003D()
	{
		return _0023_003Dz9jrlnWk_003D._0023_003DzuStpncDoFB_0024Bn9X5utYOeB3A395GiZ_0024S_00241CSFTjWTpb_Iwp2iPbLvZPZ_q72dNX1SakAOAk_003D() - 10;
	}

	public int _0023_003DzRUaRf1_0024uXCd_0024014IgyPFGQ1WhzdakNCGTidf3nBX4zF3OwW0KT0ZmzkEoZUFoCJ2InG3qf_002466q8cxaPSHFzfr5g_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, byte[] _0023_003DzzKDx05I_003D, int _0023_003Dz3iPku7s_003D, RandomNumberGenerator _0023_003Dz2X8kE24_003D)
	{
		return _0023_003DzYqNRrg6Li8CLWtox52RQ70Kue97s_fNoKdCwfFqXdIrX(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D);
	}

	private int _0023_003DzYqNRrg6Li8CLWtox52RQ70Kue97s_fNoKdCwfFqXdIrX(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, byte[] _0023_003DzzKDx05I_003D, int _0023_003Dz3iPku7s_003D, RandomNumberGenerator _0023_003Dz2X8kE24_003D)
	{
		int num = this._0023_003Dz9jrlnWk_003D._0023_003DzuStpncDoFB_0024Bn9X5utYOeB3A395GiZ_0024S_00241CSFTjWTpb_Iwp2iPbLvZPZ_q72dNX1SakAOAk_003D();
		byte[] array = this._0023_003DzBxpHhQ0_003D;
		this._0023_003Dz9jrlnWk_003D._0023_003DzRUaRf1_0024uXCd_0024014IgyPFGQ1WhzdakNCGTidf3nBX4zF3OwW0KT0ZmzkEoZUFoCJ2InG3qf_002466q8cxaPSHFzfr5g_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, array, 0, _0023_003Dz2X8kE24_003D);
		byte num2 = array[0];
		bool flag = num2 != 2;
		int num3 = _0023_003DzFDgm1KXXL_0024BoNg4t75XaX966rAo4(num2, array, 0, num);
		num3++;
		if (flag || num3 < 10)
		{
			throw new InvalidOperationException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312314));
		}
		int num4 = num - num3;
		Buffer.BlockCopy(array, num3, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D, num4);
		return num4;
	}

	private static int _0023_003DzFDgm1KXXL_0024BoNg4t75XaX966rAo4(byte _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, int _0023_003DzzKDx05I_003D)
	{
		for (int i = _0023_003Dztgqm2r4_003D + 1; i != _0023_003Dztgqm2r4_003D + _0023_003DzzKDx05I_003D; i++)
		{
			if (_0023_003DzBxpHhQ0_003D[i] == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public void Dispose()
	{
		if (_0023_003Dz9jrlnWk_003D != null)
		{
			_0023_003Dz9jrlnWk_003D.Dispose();
			_0023_003Dz9jrlnWk_003D = null;
		}
	}
}
