using System;
using System.Diagnostics;

internal sealed class _0023_003DzpGp0NAUw_Bls : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz736ekIs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzEGKj_0024SNUUihi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzmKBPh7nOT6nY _0023_003Dzt_m8zV0_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzCJkr8nY_003D;

	public _0023_003DzpGp0NAUw_Bls()
	{
	}

	public _0023_003DzpGp0NAUw_Bls(_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y, _0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY, _0023_003DzmKBPh7nOT6nY _0023_003Dzve8U_5s_003D, bool _0023_003DzGY511ZAPejXe)
	{
		_0023_003DzFj_0024IqDQ_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzsiQjbwmUNI0y);
		_0023_003DzjdeMMkk_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzSElTn3BlQAJY);
		_0023_003Dzt_m8zV0_003D._0023_003Dz_0024xXJldw_003D(_0023_003Dzve8U_5s_003D);
		_0023_003DzCJkr8nY_003D = _0023_003DzGY511ZAPejXe;
		_0023_003Dz_khbnZY_003D();
	}

	public _0023_003DzpGp0NAUw_Bls(_0023_003DzpGp0NAUw_Bls _0023_003DzjbqS1qE_003D)
	{
		_0023_003DzFj_0024IqDQ_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzjbqS1qE_003D._0023_003DzFj_0024IqDQ_003D);
		_0023_003DzjdeMMkk_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzjbqS1qE_003D._0023_003DzjdeMMkk_003D);
		_0023_003Dzt_m8zV0_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzjbqS1qE_003D._0023_003Dzt_m8zV0_003D);
		_0023_003DzCJkr8nY_003D = _0023_003DzjbqS1qE_003D._0023_003DzCJkr8nY_003D;
		_0023_003Dz_khbnZY_003D();
	}

	public virtual void Dispose()
	{
	}

	public double _0023_003DzKyPYkL4vdW1Z()
	{
		return _0023_003Dz736ekIs_003D;
	}

	public _0023_003DzmKBPh7nOT6nY _0023_003DzOXmvu5c_003D(double _0023_003DzNDQ_E88_003D)
	{
		if (Math.Abs(_0023_003DzNDQ_E88_003D) < 1E-14)
		{
			return new _0023_003DzmKBPh7nOT6nY(_0023_003DzFj_0024IqDQ_003D);
		}
		if (Math.Abs(_0023_003DzNDQ_E88_003D - 1.0) < 1E-14)
		{
			return new _0023_003DzmKBPh7nOT6nY(_0023_003DzjdeMMkk_003D);
		}
		double num = _0023_003DzNDQ_E88_003D * _0023_003Dz736ekIs_003D;
		if (!_0023_003DzCJkr8nY_003D)
		{
			num = 0.0 - num;
		}
		_0023_003DzmKBPh7nOT6nY obj = _0023_003DzFj_0024IqDQ_003D - _0023_003Dzt_m8zV0_003D;
		obj._0023_003DztFJP6Q2c8jRl(num / _0023_003DzEGKj_0024SNUUihi);
		return obj + _0023_003Dzt_m8zV0_003D;
	}

	public double _0023_003DzCboccJCws8_0024s(_0023_003DzmKBPh7nOT6nY _0023_003DzffqPLNQ_003D, _0023_003DzmKBPh7nOT6nY _0023_003Dz5Azd7L8_003D, bool _0023_003DzCJkr8nY_003D)
	{
		int num = (_0023_003DzCJkr8nY_003D ? 1 : (-1));
		double num2 = _0023_003DzffqPLNQ_003D._0023_003DzHX2sd2E_003D(_0023_003Dz5Azd7L8_003D);
		if (num2 > 0.9999999999)
		{
			return 0.0;
		}
		if (num2 < -0.9999999999)
		{
			num2 = Math.PI;
		}
		else
		{
			if (num2 > 1.0)
			{
				num2 = 1.0;
			}
			num2 = Math.Acos(num2);
			double num3 = _0023_003DzffqPLNQ_003D._0023_003DzBJFJHwk_003D * _0023_003Dz5Azd7L8_003D._0023_003Dz40R7bAU_003D - _0023_003DzffqPLNQ_003D._0023_003Dz40R7bAU_003D * _0023_003Dz5Azd7L8_003D._0023_003DzBJFJHwk_003D;
			if ((double)num * num3 < 0.0)
			{
				num2 = Math.PI * 2.0 - num2;
			}
		}
		return (double)num * num2;
	}

	private void _0023_003Dz_khbnZY_003D()
	{
		_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = (_0023_003DzFj_0024IqDQ_003D - _0023_003Dzt_m8zV0_003D)._0023_003DzU2U6sSJ82nfe();
		_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY3 = (_0023_003DzjdeMMkk_003D - _0023_003Dzt_m8zV0_003D)._0023_003DzU2U6sSJ82nfe();
		_0023_003DzEGKj_0024SNUUihi = _0023_003DzmKBPh7nOT6nY2._0023_003Dzjw_p5h5zRiC5();
		_0023_003DzmKBPh7nOT6nY2._0023_003Dzt_0024wZMac_003D();
		_0023_003DzmKBPh7nOT6nY3._0023_003Dzt_0024wZMac_003D();
		_0023_003Dz736ekIs_003D = Math.Abs(_0023_003DzCboccJCws8_0024s(_0023_003DzmKBPh7nOT6nY2, _0023_003DzmKBPh7nOT6nY3, _0023_003DzCJkr8nY_003D)) * _0023_003DzEGKj_0024SNUUihi;
	}
}
