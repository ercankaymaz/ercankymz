using System;
using System.Text;

internal sealed class _0023_003DzdwUsoVJh2asJi3cMG2Slo1jQ9syoz1RZlQ_003D_003D
{
	private long _0023_003DzS0AjKGk_u7Mh;

	private long _0023_003DzjE33Iss_003D;

	private _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzeqbWctMvYQRl;

	private _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8._0023_003DznqdCgf91E_Pg _0023_003Dz3Ns7fHTHUh0m;

	public _0023_003DzdwUsoVJh2asJi3cMG2Slo1jQ9syoz1RZlQ_003D_003D(_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzjbC91_Hr67is)
		: this(_0023_003DzjbC91_Hr67is, (long)_0023_003DzjbC91_Hr67is._0023_003Dzu8sgotQ_003D() << 3)
	{
	}

	public _0023_003DzdwUsoVJh2asJi3cMG2Slo1jQ9syoz1RZlQ_003D_003D(_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzjbC91_Hr67is, long _0023_003DzODSmOzg_003D)
	{
		_0023_003DzeqbWctMvYQRl = _0023_003DzjbC91_Hr67is;
		_0023_003DzS0AjKGk_u7Mh = _0023_003DzODSmOzg_003D;
		_0023_003DzjE33Iss_003D = 0L;
		_0023_003Dz3Ns7fHTHUh0m = (_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8._0023_003DznqdCgf91E_Pg)0;
	}

	public virtual void _0023_003DzVCntbi5rW1N9(_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8._0023_003DznqdCgf91E_Pg _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz3Ns7fHTHUh0m = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual int _0023_003DzyrUSnjH5Ld0s07AgsA_003D_003D(int _0023_003DzhrsBtr04uLWE)
	{
		if (_0023_003DzhrsBtr04uLWE <= 0)
		{
			return 0;
		}
		int num = 0;
		if (_0023_003DzAy6_oLDd5YjL(_0023_003DzjE33Iss_003D, _0023_003DzhrsBtr04uLWE) > 4)
		{
			return (int)_0023_003DzNdSHo_8cguJL(_0023_003DzjE33Iss_003D, _0023_003DzhrsBtr04uLWE, 32);
		}
		return _0023_003Dz61yrXlD_1Qgi(_0023_003DzjE33Iss_003D, _0023_003DzhrsBtr04uLWE, 32);
	}

	public virtual int _0023_003Dz9x5_3XyXe_0024BAvNZbgg_003D_003D(int _0023_003DzhrsBtr04uLWE)
	{
		return _0023_003DzyrUSnjH5Ld0s07AgsA_003D_003D(_0023_003DzhrsBtr04uLWE) << 32 - _0023_003DzhrsBtr04uLWE >> 32 - _0023_003DzhrsBtr04uLWE;
	}

	public virtual long _0023_003Dzq6E6aZ9ium1i()
	{
		return _0023_003DzjE33Iss_003D;
	}

	public virtual void _0023_003Dz3k6H7_ShzOCw(long _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzjE33Iss_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual string _0023_003DzgIZg8II_003D(long _0023_003DzhrsBtr04uLWE)
	{
		long num = _0023_003DzjE33Iss_003D;
		StringBuilder stringBuilder = new StringBuilder();
		long num2 = _0023_003DzjE33Iss_003D;
		_0023_003DzhrsBtr04uLWE += num2;
		if (_0023_003DzhrsBtr04uLWE == -1)
		{
			_0023_003DzhrsBtr04uLWE = _0023_003DzS0AjKGk_u7Mh;
			num2 = 0L;
		}
		for (long num3 = num2; num3 < _0023_003DzhrsBtr04uLWE; num3++)
		{
			if (num3 > 0 && (num3 - num2) % 8 == 0L)
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append((_0023_003Dz61yrXlD_1Qgi(num3, 1, 1) == 1) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746));
		}
		_0023_003DzjE33Iss_003D = num;
		return stringBuilder.ToString();
	}

	private int _0023_003Dz5GRqQItYFLzo(int _0023_003DzhrsBtr04uLWE)
	{
		return -1 >>> 32 - _0023_003DzhrsBtr04uLWE;
	}

	private long _0023_003Dz3w4SvU9joCu5(int _0023_003DzhrsBtr04uLWE)
	{
		return (int)(ulong.MaxValue >> 64 - _0023_003DzhrsBtr04uLWE);
	}

	private int _0023_003DzAy6_oLDd5YjL(long _0023_003Dzf40hVYc5sMgL, int _0023_003DzhrsBtr04uLWE)
	{
		return (int)((_0023_003Dzf40hVYc5sMgL % 8 + _0023_003DzhrsBtr04uLWE + 7) / 8);
	}

	private int _0023_003Dza8lScH8eDx0N544wbLs7kwImqH_0024U(int _0023_003DzZR5Gg5kFeo7R, long _0023_003Dzf40hVYc5sMgL, int _0023_003DzhrsBtr04uLWE)
	{
		long num = ((_0023_003Dz3Ns7fHTHUh0m != 0) ? (_0023_003Dzf40hVYc5sMgL % 8) : (7 - (_0023_003DzhrsBtr04uLWE + _0023_003Dzf40hVYc5sMgL + 7) % 8));
		return _0023_003DzZR5Gg5kFeo7R >> (int)num;
	}

	private long _0023_003Dz2UJl_XCDfYuLZctF0Nk37kaSBGSP(long _0023_003DzZR5Gg5kFeo7R, long _0023_003Dzf40hVYc5sMgL, int _0023_003DzhrsBtr04uLWE)
	{
		long num = ((_0023_003Dz3Ns7fHTHUh0m != 0) ? (_0023_003Dzf40hVYc5sMgL % 8) : (7 - (_0023_003DzhrsBtr04uLWE + _0023_003Dzf40hVYc5sMgL + 7) % 8));
		return _0023_003DzZR5Gg5kFeo7R >> (int)num;
	}

	private void _0023_003DzNq0ogHJMCk3c(long _0023_003Dzf40hVYc5sMgL, int _0023_003DzGUTxcoVbxngh, int _0023_003DzSzIGyyQMt0sK)
	{
		if (_0023_003DzGUTxcoVbxngh < 1)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936111) + _0023_003DzGUTxcoVbxngh + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936080));
		}
		if (_0023_003Dzf40hVYc5sMgL < 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936274) + _0023_003Dzf40hVYc5sMgL + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936261));
		}
		if (_0023_003DzSzIGyyQMt0sK != 1 && _0023_003DzSzIGyyQMt0sK != 8 && _0023_003DzSzIGyyQMt0sK != 16 && _0023_003DzSzIGyyQMt0sK != 32 && _0023_003DzSzIGyyQMt0sK != 64)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936225) + _0023_003DzSzIGyyQMt0sK + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936198));
		}
		if (_0023_003DzGUTxcoVbxngh > _0023_003DzSzIGyyQMt0sK)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936913) + _0023_003DzGUTxcoVbxngh + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936902) + _0023_003DzSzIGyyQMt0sK + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936887) + _0023_003Dzf40hVYc5sMgL + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936860));
		}
		if (_0023_003Dzf40hVYc5sMgL + _0023_003DzGUTxcoVbxngh > _0023_003DzS0AjKGk_u7Mh)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936835) + (_0023_003Dzf40hVYc5sMgL + _0023_003DzGUTxcoVbxngh) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915925) + _0023_003DzS0AjKGk_u7Mh);
		}
	}

	private int _0023_003Dz_b6jN_Z_Q_0024_8oJJplA_003D_003D(int _0023_003Dzx4vlTn91DAD9, int _0023_003DzTiF4TcjmT_e4)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < _0023_003Dzx4vlTn91DAD9; i++)
		{
			_0023_003DzeqbWctMvYQRl._0023_003DztUjb52A_003D(_0023_003DzTiF4TcjmT_e4++);
			num2 = 0xFF & _0023_003DzeqbWctMvYQRl._0023_003DzlDvF6iY_003D();
			num = ((_0023_003Dz3Ns7fHTHUh0m != (_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8._0023_003DznqdCgf91E_Pg)1) ? ((num2 << (_0023_003Dzx4vlTn91DAD9 - i - 1 << 3)) | num) : (num | (num2 << (i << 3))));
		}
		return num;
	}

	private long _0023_003Dz7yhyLyeNfgT0axG52g_003D_003D(int _0023_003Dzx4vlTn91DAD9, int _0023_003DzTiF4TcjmT_e4)
	{
		long num = 0L;
		long num2 = 0L;
		for (int i = 0; i < _0023_003Dzx4vlTn91DAD9; i++)
		{
			_0023_003DzeqbWctMvYQRl._0023_003DztUjb52A_003D(_0023_003DzTiF4TcjmT_e4++);
			num2 = 0xFF & _0023_003DzeqbWctMvYQRl._0023_003DzlDvF6iY_003D();
			num = ((_0023_003Dz3Ns7fHTHUh0m != (_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8._0023_003DznqdCgf91E_Pg)1) ? ((num2 << (_0023_003Dzx4vlTn91DAD9 - i - 1 << 3)) | num) : (num | (num2 << (i << 3))));
		}
		return num;
	}

	private int _0023_003Dz61yrXlD_1Qgi(long _0023_003Dzf40hVYc5sMgL, int _0023_003DzGUTxcoVbxngh, int _0023_003DzSzIGyyQMt0sK)
	{
		_0023_003DzNq0ogHJMCk3c(_0023_003Dzf40hVYc5sMgL, _0023_003DzGUTxcoVbxngh, _0023_003DzSzIGyyQMt0sK);
		int _0023_003Dzx4vlTn91DAD = _0023_003DzAy6_oLDd5YjL(_0023_003Dzf40hVYc5sMgL, _0023_003DzGUTxcoVbxngh);
		int _0023_003DzZR5Gg5kFeo7R = _0023_003Dz_b6jN_Z_Q_0024_8oJJplA_003D_003D(_0023_003Dzx4vlTn91DAD, (int)(_0023_003Dzf40hVYc5sMgL >> 3));
		int result = _0023_003Dz5GRqQItYFLzo(_0023_003DzGUTxcoVbxngh) & _0023_003Dza8lScH8eDx0N544wbLs7kwImqH_0024U(_0023_003DzZR5Gg5kFeo7R, _0023_003Dzf40hVYc5sMgL, _0023_003DzGUTxcoVbxngh);
		_0023_003DzjE33Iss_003D = _0023_003Dzf40hVYc5sMgL + _0023_003DzGUTxcoVbxngh;
		return result;
	}

	private long _0023_003DzNdSHo_8cguJL(long _0023_003Dzf40hVYc5sMgL, int _0023_003DzGUTxcoVbxngh, int _0023_003DzSzIGyyQMt0sK)
	{
		_0023_003DzNq0ogHJMCk3c(_0023_003Dzf40hVYc5sMgL, _0023_003DzGUTxcoVbxngh, _0023_003DzSzIGyyQMt0sK);
		int _0023_003Dzx4vlTn91DAD = _0023_003DzAy6_oLDd5YjL(_0023_003Dzf40hVYc5sMgL, _0023_003DzGUTxcoVbxngh);
		long _0023_003DzZR5Gg5kFeo7R = _0023_003Dz7yhyLyeNfgT0axG52g_003D_003D(_0023_003Dzx4vlTn91DAD, (int)(_0023_003Dzf40hVYc5sMgL >> 3));
		long result = _0023_003Dz3w4SvU9joCu5(_0023_003DzGUTxcoVbxngh) & _0023_003Dz2UJl_XCDfYuLZctF0Nk37kaSBGSP(_0023_003DzZR5Gg5kFeo7R, _0023_003Dzf40hVYc5sMgL, _0023_003DzGUTxcoVbxngh);
		_0023_003DzjE33Iss_003D = _0023_003Dzf40hVYc5sMgL + _0023_003DzGUTxcoVbxngh;
		return result;
	}

	public virtual long _0023_003DzbWAA6qw_003D()
	{
		return _0023_003DzS0AjKGk_u7Mh;
	}
}
