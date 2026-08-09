using System;

internal sealed class _0023_003DzROs3b4cS4mBNtFl5_FGzaI8_003D
{
	private sealed class _0023_003DzDpUzAG_XlHUt
	{
		public double _0023_003Dz626x7zvzJ7CL = double.MaxValue;

		public double _0023_003DzXW3l8aPt3z_00248 = double.MinValue;

		public double _0023_003DzY28cqTRJkEjn;

		public int _0023_003Dzpg2zK_N0knx9;

		public void _0023_003Dzv9osLK4_003D()
		{
			_0023_003Dz626x7zvzJ7CL = double.MaxValue;
			_0023_003DzXW3l8aPt3z_00248 = double.MinValue;
			_0023_003DzY28cqTRJkEjn = 0.0;
			_0023_003Dzpg2zK_N0knx9 = 0;
		}

		public double _0023_003DzEAffZoQ_003D(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzjbqS1qE_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dz1v6oPQk_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dzt_m8zV0_003D)
		{
			double num = 0.5 * Math.Abs(_0023_003DzjbqS1qE_003D._0023_003DzBJFJHwk_003D * (_0023_003Dz1v6oPQk_003D._0023_003Dz40R7bAU_003D - _0023_003Dzt_m8zV0_003D._0023_003Dz40R7bAU_003D) + _0023_003Dz1v6oPQk_003D._0023_003DzBJFJHwk_003D * (_0023_003Dzt_m8zV0_003D._0023_003Dz40R7bAU_003D - _0023_003DzjbqS1qE_003D._0023_003Dz40R7bAU_003D) + _0023_003Dzt_m8zV0_003D._0023_003DzBJFJHwk_003D * (_0023_003DzjbqS1qE_003D._0023_003Dz40R7bAU_003D - _0023_003Dz1v6oPQk_003D._0023_003Dz40R7bAU_003D));
			_0023_003Dz626x7zvzJ7CL = Math.Min(_0023_003Dz626x7zvzJ7CL, num);
			_0023_003DzXW3l8aPt3z_00248 = Math.Max(_0023_003DzXW3l8aPt3z_00248, num);
			_0023_003DzY28cqTRJkEjn += num;
			if (num == 0.0)
			{
				_0023_003Dzpg2zK_N0knx9++;
			}
			return num;
		}
	}

	private sealed class _0023_003Dzrd20pj2Cpakc
	{
		public double _0023_003Dz0fxSAd_0024d6yve;

		public double _0023_003Dzq4qOXD6xIuBO;

		public double _0023_003DzHrO45TI0I3aQ;

		public double _0023_003DzvkGrRqdxlX4d;

		public void _0023_003Dzv9osLK4_003D()
		{
			_0023_003Dz0fxSAd_0024d6yve = double.MaxValue;
			_0023_003Dzq4qOXD6xIuBO = double.MinValue;
			_0023_003DzHrO45TI0I3aQ = 0.0;
			_0023_003DzvkGrRqdxlX4d = 0.0;
		}

		public double _0023_003DzEAffZoQ_003D(double _0023_003DzcArZY64_003D, double _0023_003DzFeEghKc_003D, double _0023_003DzslYbsU0_003D, double _0023_003DzXWCF4rA_003D)
		{
			double num = (_0023_003DzFeEghKc_003D + _0023_003DzslYbsU0_003D - _0023_003DzcArZY64_003D) * (_0023_003DzslYbsU0_003D + _0023_003DzcArZY64_003D - _0023_003DzFeEghKc_003D) * (_0023_003DzcArZY64_003D + _0023_003DzFeEghKc_003D - _0023_003DzslYbsU0_003D) / (_0023_003DzcArZY64_003D * _0023_003DzFeEghKc_003D * _0023_003DzslYbsU0_003D);
			_0023_003Dz0fxSAd_0024d6yve = Math.Min(_0023_003Dz0fxSAd_0024d6yve, num);
			_0023_003Dzq4qOXD6xIuBO = Math.Max(_0023_003Dzq4qOXD6xIuBO, num);
			_0023_003DzHrO45TI0I3aQ += num;
			_0023_003DzvkGrRqdxlX4d += num * _0023_003DzXWCF4rA_003D;
			return num;
		}

		public void _0023_003DzbV1eOjg_003D(int _0023_003DzoMNiNRw_003D, double _0023_003DzY28cqTRJkEjn)
		{
			if (_0023_003DzoMNiNRw_003D > 0)
			{
				_0023_003DzHrO45TI0I3aQ /= _0023_003DzoMNiNRw_003D;
			}
			else
			{
				_0023_003DzHrO45TI0I3aQ = 0.0;
			}
			if (_0023_003DzY28cqTRJkEjn > 0.0)
			{
				_0023_003DzvkGrRqdxlX4d /= _0023_003DzY28cqTRJkEjn;
			}
			else
			{
				_0023_003DzvkGrRqdxlX4d = 0.0;
			}
		}
	}

	private sealed class _0023_003DzrgJI2cZ9uUO4
	{
		public double _0023_003DzPkkPpQLvr7qJ;

		public double _0023_003Dz72iRfK4EUuaE;

		public double _0023_003Dz3pBP_0024_0024wDCqmi;

		public double _0023_003DzQvNvi54q5Aae;

		public void _0023_003Dzv9osLK4_003D()
		{
			_0023_003DzPkkPpQLvr7qJ = double.MaxValue;
			_0023_003Dz72iRfK4EUuaE = double.MinValue;
			_0023_003Dz3pBP_0024_0024wDCqmi = 0.0;
			_0023_003DzQvNvi54q5Aae = 0.0;
		}

		private double _0023_003Dzx3IOEOokT4bg(double _0023_003Dzt_m8zV0_003D)
		{
			if (_0023_003Dzt_m8zV0_003D <= -1.0)
			{
				return Math.PI;
			}
			if (1.0 <= _0023_003Dzt_m8zV0_003D)
			{
				return 0.0;
			}
			return Math.Acos(_0023_003Dzt_m8zV0_003D);
		}

		public double _0023_003DzEAffZoQ_003D(double _0023_003DzcArZY64_003D, double _0023_003DzFeEghKc_003D, double _0023_003DzslYbsU0_003D, double _0023_003DzXWCF4rA_003D)
		{
			double val = double.MaxValue;
			double num = _0023_003DzcArZY64_003D * _0023_003DzcArZY64_003D;
			double num2 = _0023_003DzFeEghKc_003D * _0023_003DzFeEghKc_003D;
			double num3 = _0023_003DzslYbsU0_003D * _0023_003DzslYbsU0_003D;
			double val2;
			double val3;
			double val4;
			if (_0023_003DzcArZY64_003D != 0.0 || _0023_003DzFeEghKc_003D != 0.0 || _0023_003DzslYbsU0_003D != 0.0)
			{
				val2 = ((_0023_003DzslYbsU0_003D != 0.0 && _0023_003DzcArZY64_003D != 0.0) ? _0023_003Dzx3IOEOokT4bg((num3 + num - num2) / (2.0 * _0023_003DzslYbsU0_003D * _0023_003DzcArZY64_003D)) : Math.PI);
				val3 = ((_0023_003DzcArZY64_003D != 0.0 && _0023_003DzFeEghKc_003D != 0.0) ? _0023_003Dzx3IOEOokT4bg((num + num2 - num3) / (2.0 * _0023_003DzcArZY64_003D * _0023_003DzFeEghKc_003D)) : Math.PI);
				val4 = ((_0023_003DzFeEghKc_003D != 0.0 && _0023_003DzslYbsU0_003D != 0.0) ? _0023_003Dzx3IOEOokT4bg((num2 + num3 - num) / (2.0 * _0023_003DzFeEghKc_003D * _0023_003DzslYbsU0_003D)) : Math.PI);
			}
			else
			{
				val2 = Math.PI * 2.0 / 3.0;
				val3 = Math.PI * 2.0 / 3.0;
				val4 = Math.PI * 2.0 / 3.0;
			}
			val = Math.Min(val, val2);
			val = Math.Min(val, val3);
			val = Math.Min(val, val4);
			val = val * 3.0 / Math.PI;
			_0023_003Dz3pBP_0024_0024wDCqmi += val;
			_0023_003DzQvNvi54q5Aae += _0023_003DzXWCF4rA_003D * val;
			_0023_003DzPkkPpQLvr7qJ = Math.Min(val, _0023_003DzPkkPpQLvr7qJ);
			_0023_003Dz72iRfK4EUuaE = Math.Max(val, _0023_003Dz72iRfK4EUuaE);
			return val;
		}

		public void _0023_003DzbV1eOjg_003D(int _0023_003DzoMNiNRw_003D, double _0023_003DzY28cqTRJkEjn)
		{
			if (_0023_003DzoMNiNRw_003D > 0)
			{
				_0023_003Dz3pBP_0024_0024wDCqmi /= _0023_003DzoMNiNRw_003D;
			}
			else
			{
				_0023_003Dz3pBP_0024_0024wDCqmi = 0.0;
			}
			if (0.0 < _0023_003DzY28cqTRJkEjn)
			{
				_0023_003DzQvNvi54q5Aae /= _0023_003DzY28cqTRJkEjn;
			}
			else
			{
				_0023_003DzQvNvi54q5Aae = 0.0;
			}
		}
	}

	private _0023_003DzDpUzAG_XlHUt _0023_003Dzhod9SVDTMyYO;

	private _0023_003DzrgJI2cZ9uUO4 _0023_003DzMCWFbhNm4dK4;

	private _0023_003Dzrd20pj2Cpakc _0023_003Dze1IoomU_003D;

	private _0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D;

	public _0023_003DzROs3b4cS4mBNtFl5_FGzaI8_003D()
	{
		_0023_003Dzhod9SVDTMyYO = new _0023_003DzDpUzAG_XlHUt();
		_0023_003DzMCWFbhNm4dK4 = new _0023_003DzrgJI2cZ9uUO4();
		_0023_003Dze1IoomU_003D = new _0023_003Dzrd20pj2Cpakc();
	}

	public double _0023_003DzDuscw6WFSyWP()
	{
		return _0023_003Dzhod9SVDTMyYO._0023_003Dz626x7zvzJ7CL;
	}

	public double _0023_003DzHN1D4dGuBuCs()
	{
		return _0023_003Dzhod9SVDTMyYO._0023_003DzXW3l8aPt3z_00248;
	}

	public double _0023_003DzHd_LTPvdJhSE()
	{
		return _0023_003Dzhod9SVDTMyYO._0023_003DzXW3l8aPt3z_00248 / _0023_003Dzhod9SVDTMyYO._0023_003Dz626x7zvzJ7CL;
	}

	public double _0023_003DzCxV_ERpY3BWQ()
	{
		return _0023_003DzMCWFbhNm4dK4._0023_003DzPkkPpQLvr7qJ;
	}

	public double _0023_003Dz1veergbUyRaS()
	{
		return _0023_003DzMCWFbhNm4dK4._0023_003Dz72iRfK4EUuaE;
	}

	public double _0023_003DzUBVHGEgwPW7s()
	{
		return _0023_003DzMCWFbhNm4dK4._0023_003Dz3pBP_0024_0024wDCqmi;
	}

	public double _0023_003DzFS2R2QaMi5H8()
	{
		return _0023_003DzMCWFbhNm4dK4._0023_003DzQvNvi54q5Aae;
	}

	public double _0023_003DzM2s_OsjPfafn()
	{
		return _0023_003Dze1IoomU_003D._0023_003Dz0fxSAd_0024d6yve;
	}

	public double _0023_003Dz_00249gIGzWDeuh7()
	{
		return _0023_003Dze1IoomU_003D._0023_003Dzq4qOXD6xIuBO;
	}

	public double _0023_003Dz9_0024aN4SdHDfP8()
	{
		return _0023_003Dze1IoomU_003D._0023_003DzHrO45TI0I3aQ;
	}

	public double _0023_003Dz0umYttoH8enf()
	{
		return _0023_003Dze1IoomU_003D._0023_003DzvkGrRqdxlX4d;
	}

	public void _0023_003DzIvyN59Q_003D(_0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D)
	{
		this._0023_003DzGGJSiQk_003D = _0023_003DzGGJSiQk_003D;
		_0023_003Dzhod9SVDTMyYO._0023_003Dzv9osLK4_003D();
		_0023_003DzMCWFbhNm4dK4._0023_003Dzv9osLK4_003D();
		_0023_003Dze1IoomU_003D._0023_003Dzv9osLK4_003D();
		_0023_003DzL9woobs_003D();
	}

	private void _0023_003DzL9woobs_003D()
	{
		int num = 0;
		foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item in _0023_003DzGGJSiQk_003D._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			num++;
			_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0];
			_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D3 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1];
			_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D4 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2];
			double num2 = _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2._0023_003DzBJFJHwk_003D - _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D3._0023_003DzBJFJHwk_003D;
			double num3 = _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2._0023_003Dz40R7bAU_003D - _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D3._0023_003Dz40R7bAU_003D;
			double _0023_003DzcArZY64_003D = Math.Sqrt(num2 * num2 + num3 * num3);
			double num4 = _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D3._0023_003DzBJFJHwk_003D - _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D4._0023_003DzBJFJHwk_003D;
			num3 = _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D3._0023_003Dz40R7bAU_003D - _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D4._0023_003Dz40R7bAU_003D;
			double _0023_003DzFeEghKc_003D = Math.Sqrt(num4 * num4 + num3 * num3);
			double num5 = _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D4._0023_003DzBJFJHwk_003D - _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2._0023_003DzBJFJHwk_003D;
			num3 = _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D4._0023_003Dz40R7bAU_003D - _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2._0023_003Dz40R7bAU_003D;
			double _0023_003DzslYbsU0_003D = Math.Sqrt(num5 * num5 + num3 * num3);
			double _0023_003DzXWCF4rA_003D = _0023_003Dzhod9SVDTMyYO._0023_003DzEAffZoQ_003D(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D2, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D3, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D4);
			_0023_003DzMCWFbhNm4dK4._0023_003DzEAffZoQ_003D(_0023_003DzcArZY64_003D, _0023_003DzFeEghKc_003D, _0023_003DzslYbsU0_003D, _0023_003DzXWCF4rA_003D);
			_0023_003Dze1IoomU_003D._0023_003DzEAffZoQ_003D(_0023_003DzcArZY64_003D, _0023_003DzFeEghKc_003D, _0023_003DzslYbsU0_003D, _0023_003DzXWCF4rA_003D);
		}
		_0023_003DzMCWFbhNm4dK4._0023_003DzbV1eOjg_003D(num, _0023_003Dzhod9SVDTMyYO._0023_003DzY28cqTRJkEjn);
		_0023_003Dze1IoomU_003D._0023_003DzbV1eOjg_003D(num, _0023_003Dzhod9SVDTMyYO._0023_003DzY28cqTRJkEjn);
	}

	public int _0023_003DzCR5B5Pw_003D()
	{
		if (_0023_003DzGGJSiQk_003D == null)
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item in _0023_003DzGGJSiQk_003D._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			for (int i = 0; i < 3; i++)
			{
				int _0023_003Dz2QVVx8s_003D = item._0023_003DzlowB12I_003D(i)._0023_003Dz2QVVx8s_003D;
				for (int j = 0; j < 3; j++)
				{
					int _0023_003Dz2QVVx8s_003D2 = item._0023_003DzlowB12I_003D(j)._0023_003Dz2QVVx8s_003D;
					num2 = Math.Max(num2, _0023_003Dz2QVVx8s_003D2 - _0023_003Dz2QVVx8s_003D);
					num = Math.Max(num, _0023_003Dz2QVVx8s_003D - _0023_003Dz2QVVx8s_003D2);
				}
			}
		}
		return num + 1 + num2;
	}
}
