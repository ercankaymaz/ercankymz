using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

internal sealed class _0023_003DqseJsfTP9GXc8n4REh2Wv0uULmQizd96BKi_3fZSAMm4_003D : _0023_003DquMh_RbFIfA6Odscsrwq4H1xZqNu1kphCuT2OFISKuWI_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dqui43Nmvm7VaVj9UVhsQfgU_0024EB5Ol5mDBnuELRjJfcp8_003D _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzZzVr6_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dz7hRN5Rg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzcbLoSrg_003D;

	public _0023_003DqseJsfTP9GXc8n4REh2Wv0uULmQizd96BKi_3fZSAMm4_003D(_0023_003Dqui43Nmvm7VaVj9UVhsQfgU_0024EB5Ol5mDBnuELRjJfcp8_003D _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003Dzz_0024YSfoHisxPaLNQMff8ATj2jFk42g3Jw_9OBaYm3JlfX())
		{
			throw new NotSupportedException();
		}
		this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003DzZzVr6_0024U_003D = new byte[_0023_003Dzq80RbjQ_003D._0023_003DzT9eA_I8w0CDvq_YsYh_iH47uTsD9brXMemU1_QcwtWy1NzoCuxvYwQduSWZOuC3GCh0X92w_003D()];
		_0023_003Dz7hRN5Rg_003D = _0023_003DzAiY_FKb4L_dnKjsmJkce9LZmzUesQpVjzQ_003D_003D();
		_0023_003DzcbLoSrg_003D = _0023_003DzaK7RsPWTQ_00240UCsU3Rp_H_kBk8396ZfempQJ2eOc_003D();
	}

	private int _0023_003DzAiY_FKb4L_dnKjsmJkce9LZmzUesQpVjzQ_003D_003D()
	{
		return _0023_003Dzq80RbjQ_003D._0023_003DzSEY04nxJtfqOe_NEWeo3eOc0Etbe_0024Jj8XZu70RmqdWkClVfxadDA7Yv3_toO92Ul_00242tmYNYn1vth6Wdsbw_003D_003D();
	}

	private int _0023_003DzaK7RsPWTQ_00240UCsU3Rp_H_kBk8396ZfempQJ2eOc_003D()
	{
		return _0023_003Dzq80RbjQ_003D._0023_003DzT9eA_I8w0CDvq_YsYh_iH47uTsD9brXMemU1_QcwtWy1NzoCuxvYwQduSWZOuC3GCh0X92w_003D() - 10;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0023_003DzT9eA_I8w0CDvq_YsYh_iH47uTsD9brXMemU1_QcwtWy1NzoCuxvYwQduSWZOuC3GCh0X92w_003D()
	{
		return _0023_003DzcbLoSrg_003D;
	}

	public int _0023_003Dzhdoh5k6m_0024AO52PAYFXGKQO9OGwW5kHwW2wyWQpayqijlwE_0024xck_GBc28La0KktESKmzv8a_0024ZIXdc4iz8z4aF4eo_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, byte[] _0023_003DzcbLoSrg_003D, int _0023_003DzqMLoHoQ_003D, RandomNumberGenerator _0023_003DzuwE9t4w_003D)
	{
		return _0023_003Dz52VdN0NaEEBgn6lZoB8FYGNtjVdIC1ajeWJQW4TPjBo7(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D);
	}

	private int _0023_003Dz52VdN0NaEEBgn6lZoB8FYGNtjVdIC1ajeWJQW4TPjBo7(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, byte[] _0023_003DzcbLoSrg_003D, int _0023_003DzqMLoHoQ_003D, RandomNumberGenerator _0023_003DzuwE9t4w_003D)
	{
		int num = this._0023_003Dzq80RbjQ_003D._0023_003DzT9eA_I8w0CDvq_YsYh_iH47uTsD9brXMemU1_QcwtWy1NzoCuxvYwQduSWZOuC3GCh0X92w_003D();
		byte[] array = this._0023_003DzZzVr6_0024U_003D;
		this._0023_003Dzq80RbjQ_003D._0023_003Dzhdoh5k6m_0024AO52PAYFXGKQO9OGwW5kHwW2wyWQpayqijlwE_0024xck_GBc28La0KktESKmzv8a_0024ZIXdc4iz8z4aF4eo_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, array, 0, _0023_003DzuwE9t4w_003D);
		byte num2 = array[0];
		bool flag = num2 != 2;
		int num3 = _0023_003DzFZRq1p2YgSzZaixiuegyNqMtAwq4(num2, array, 0, num);
		num3++;
		if (flag || num3 < 10)
		{
			throw new InvalidOperationException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527776));
		}
		int num4 = num - num3;
		Buffer.BlockCopy(array, num3, _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, num4);
		return num4;
	}

	private static int _0023_003DzFZRq1p2YgSzZaixiuegyNqMtAwq4(byte _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, int _0023_003DzcbLoSrg_003D)
	{
		for (int i = _0023_003Dz7hRN5Rg_003D + 1; i != _0023_003Dz7hRN5Rg_003D + _0023_003DzcbLoSrg_003D; i++)
		{
			if (_0023_003DzZzVr6_0024U_003D[i] == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public void Dispose()
	{
		if (_0023_003Dzq80RbjQ_003D != null)
		{
			_0023_003Dzq80RbjQ_003D.Dispose();
			_0023_003Dzq80RbjQ_003D = null;
		}
	}
}
