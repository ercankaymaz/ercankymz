using System;

internal static class _0023_003DzIUbJ_m6erIySAkF_0024H_NBnsY_003D
{
	public static bool _0023_003DzedEHTyqioyyN(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzjbqS1qE_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dz1v6oPQk_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzvORV0oA_003D, double _0023_003DzezTples_003D)
	{
		if (Math.Abs((_0023_003DzvORV0oA_003D._0023_003DzqJqZpJk_003D() - _0023_003DzjbqS1qE_003D._0023_003DzqJqZpJk_003D()) * (_0023_003Dz1v6oPQk_003D._0023_003DzR216mFc_003D() - _0023_003DzjbqS1qE_003D._0023_003DzR216mFc_003D()) - (_0023_003DzvORV0oA_003D._0023_003DzR216mFc_003D() - _0023_003DzjbqS1qE_003D._0023_003DzR216mFc_003D()) * (_0023_003Dz1v6oPQk_003D._0023_003DzqJqZpJk_003D() - _0023_003DzjbqS1qE_003D._0023_003DzqJqZpJk_003D())) > _0023_003DzezTples_003D)
		{
			return false;
		}
		double num = (_0023_003DzvORV0oA_003D._0023_003DzR216mFc_003D() - _0023_003DzjbqS1qE_003D._0023_003DzR216mFc_003D()) * (_0023_003Dz1v6oPQk_003D._0023_003DzR216mFc_003D() - _0023_003DzjbqS1qE_003D._0023_003DzR216mFc_003D()) + (_0023_003DzvORV0oA_003D._0023_003DzqJqZpJk_003D() - _0023_003DzjbqS1qE_003D._0023_003DzqJqZpJk_003D()) * (_0023_003Dz1v6oPQk_003D._0023_003DzqJqZpJk_003D() - _0023_003DzjbqS1qE_003D._0023_003DzqJqZpJk_003D());
		if (num < 0.0)
		{
			return false;
		}
		double num2 = (_0023_003Dz1v6oPQk_003D._0023_003DzR216mFc_003D() - _0023_003DzjbqS1qE_003D._0023_003DzR216mFc_003D()) * (_0023_003Dz1v6oPQk_003D._0023_003DzR216mFc_003D() - _0023_003DzjbqS1qE_003D._0023_003DzR216mFc_003D()) + (_0023_003Dz1v6oPQk_003D._0023_003DzqJqZpJk_003D() - _0023_003DzjbqS1qE_003D._0023_003DzqJqZpJk_003D()) * (_0023_003Dz1v6oPQk_003D._0023_003DzqJqZpJk_003D() - _0023_003DzjbqS1qE_003D._0023_003DzqJqZpJk_003D());
		if (num > num2)
		{
			return false;
		}
		return true;
	}

	public static void _0023_003DzWKRNY3gzTQH9(_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzDVubtvo_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzFj_0024IqDQ_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzyXeeZSw_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dz7ZE84gQ_003D, ref _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzGQE5xwU_003D)
	{
		double num = _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D - _0023_003DzDVubtvo_003D._0023_003DzBJFJHwk_003D;
		double num2 = _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D - _0023_003DzDVubtvo_003D._0023_003Dz40R7bAU_003D;
		double num3 = _0023_003Dz7ZE84gQ_003D._0023_003DzBJFJHwk_003D - _0023_003DzyXeeZSw_003D._0023_003DzBJFJHwk_003D;
		double num4 = _0023_003Dz7ZE84gQ_003D._0023_003Dz40R7bAU_003D - _0023_003DzyXeeZSw_003D._0023_003Dz40R7bAU_003D;
		double num5 = _0023_003DzDVubtvo_003D._0023_003DzBJFJHwk_003D - _0023_003DzyXeeZSw_003D._0023_003DzBJFJHwk_003D;
		double num6 = _0023_003DzDVubtvo_003D._0023_003Dz40R7bAU_003D - _0023_003DzyXeeZSw_003D._0023_003Dz40R7bAU_003D;
		double num7 = num * num4 - num2 * num3;
		double num8 = (num3 * num6 - num4 * num5) / num7;
		_0023_003DzGQE5xwU_003D._0023_003DzBJFJHwk_003D = _0023_003DzDVubtvo_003D._0023_003DzR216mFc_003D() + num8 * num;
		_0023_003DzGQE5xwU_003D._0023_003Dz40R7bAU_003D = _0023_003DzDVubtvo_003D._0023_003DzqJqZpJk_003D() + num8 * num2;
	}

	public static bool _0023_003DzDBFEKei_0024i4R4xSBN_g_003D_003D(_0023_003DzTovi_qDieZRnvMDU6A_003D_003D _0023_003DzpwNEYBU_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzDVubtvo_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzFj_0024IqDQ_003D, ref _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzGQE5xwU_003D, ref _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dzfm4oGj8_003D)
	{
		double num = _0023_003DzpwNEYBU_003D._0023_003DzdeQouaJ8sRT8();
		double num2 = _0023_003DzpwNEYBU_003D._0023_003Dz7Q8NCjwVr8CM();
		double num3 = _0023_003DzpwNEYBU_003D._0023_003DzVa_0024oj2xEedri();
		double num4 = _0023_003DzpwNEYBU_003D._0023_003Dze5l_0024RiEBG8Fu();
		double num5 = _0023_003DzDVubtvo_003D._0023_003DzR216mFc_003D();
		double num6 = _0023_003DzDVubtvo_003D._0023_003DzqJqZpJk_003D();
		double num7 = _0023_003DzFj_0024IqDQ_003D._0023_003DzR216mFc_003D();
		double num8 = _0023_003DzFj_0024IqDQ_003D._0023_003DzqJqZpJk_003D();
		double num9 = 0.0;
		double num10 = 1.0;
		double num11 = num7 - num5;
		double num12 = num8 - num6;
		double num13 = 0.0;
		double num14 = 0.0;
		for (int i = 0; i < 4; i++)
		{
			if (i == 0)
			{
				num13 = 0.0 - num11;
				num14 = 0.0 - (num - num5);
			}
			if (i == 1)
			{
				num13 = num11;
				num14 = num2 - num5;
			}
			if (i == 2)
			{
				num13 = 0.0 - num12;
				num14 = 0.0 - (num3 - num6);
			}
			if (i == 3)
			{
				num13 = num12;
				num14 = num4 - num6;
			}
			double num15 = num14 / num13;
			if (num13 == 0.0 && num14 < 0.0)
			{
				return false;
			}
			if (num13 < 0.0)
			{
				if (num15 > num10)
				{
					return false;
				}
				if (num15 > num9)
				{
					num9 = num15;
				}
			}
			else if (num13 > 0.0)
			{
				if (num15 < num9)
				{
					return false;
				}
				if (num15 < num10)
				{
					num10 = num15;
				}
			}
		}
		_0023_003DzGQE5xwU_003D._0023_003Dz8vQIrOc_003D(num5 + num9 * num11);
		_0023_003DzGQE5xwU_003D._0023_003DzsMht64A_003D(num6 + num9 * num12);
		_0023_003Dzfm4oGj8_003D._0023_003Dz8vQIrOc_003D(num5 + num10 * num11);
		_0023_003Dzfm4oGj8_003D._0023_003DzsMht64A_003D(num6 + num10 * num12);
		return true;
	}

	public static bool _0023_003Dz9tYkRgakodEx(_0023_003DzTovi_qDieZRnvMDU6A_003D_003D _0023_003DzpwNEYBU_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzDVubtvo_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzFj_0024IqDQ_003D, ref _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dzfm4oGj8_003D)
	{
		return _0023_003Dz9tYkRgakodEx(_0023_003DzpwNEYBU_003D, _0023_003DzDVubtvo_003D, _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D - _0023_003DzDVubtvo_003D._0023_003DzBJFJHwk_003D, _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D - _0023_003DzDVubtvo_003D._0023_003Dz40R7bAU_003D, ref _0023_003Dzfm4oGj8_003D);
	}

	public static _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dz9tYkRgakodEx(_0023_003DzTovi_qDieZRnvMDU6A_003D_003D _0023_003DzpwNEYBU_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzB68dg9Q_003D, double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D)
	{
		_0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dzt_m8zV0_003D = new _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D();
		if (_0023_003Dz9tYkRgakodEx(_0023_003DzpwNEYBU_003D, _0023_003DzB68dg9Q_003D, _0023_003DzaQ_y9PQ_003D, _0023_003DzD47R4_0_003D, ref _0023_003Dzt_m8zV0_003D))
		{
			return _0023_003Dzt_m8zV0_003D;
		}
		return null;
	}

	public static bool _0023_003Dz9tYkRgakodEx(_0023_003DzTovi_qDieZRnvMDU6A_003D_003D _0023_003DzpwNEYBU_003D, _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003DzB68dg9Q_003D, double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, ref _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D _0023_003Dzt_m8zV0_003D)
	{
		double num = _0023_003DzB68dg9Q_003D._0023_003DzR216mFc_003D();
		double num2 = _0023_003DzB68dg9Q_003D._0023_003DzqJqZpJk_003D();
		double num3 = _0023_003DzpwNEYBU_003D._0023_003DzdeQouaJ8sRT8();
		double num4 = _0023_003DzpwNEYBU_003D._0023_003Dz7Q8NCjwVr8CM();
		double num5 = _0023_003DzpwNEYBU_003D._0023_003DzVa_0024oj2xEedri();
		double num6 = _0023_003DzpwNEYBU_003D._0023_003Dze5l_0024RiEBG8Fu();
		if (num < num3 || num > num4 || num2 < num5 || num2 > num6)
		{
			return false;
		}
		double num7;
		double _0023_003DzBJFJHwk_003D;
		double _0023_003Dz40R7bAU_003D;
		if (_0023_003DzaQ_y9PQ_003D < 0.0)
		{
			num7 = (num3 - num) / _0023_003DzaQ_y9PQ_003D;
			_0023_003DzBJFJHwk_003D = num3;
			_0023_003Dz40R7bAU_003D = num2 + num7 * _0023_003DzD47R4_0_003D;
		}
		else if (_0023_003DzaQ_y9PQ_003D > 0.0)
		{
			num7 = (num4 - num) / _0023_003DzaQ_y9PQ_003D;
			_0023_003DzBJFJHwk_003D = num4;
			_0023_003Dz40R7bAU_003D = num2 + num7 * _0023_003DzD47R4_0_003D;
		}
		else
		{
			num7 = double.MaxValue;
			_0023_003DzBJFJHwk_003D = (_0023_003Dz40R7bAU_003D = 0.0);
		}
		double num8;
		double _0023_003DzBJFJHwk_003D2;
		double _0023_003Dz40R7bAU_003D2;
		if (_0023_003DzD47R4_0_003D < 0.0)
		{
			num8 = (num5 - num2) / _0023_003DzD47R4_0_003D;
			_0023_003DzBJFJHwk_003D2 = num + num8 * _0023_003DzaQ_y9PQ_003D;
			_0023_003Dz40R7bAU_003D2 = num5;
		}
		else if (_0023_003DzD47R4_0_003D > 0.0)
		{
			num8 = (num6 - num2) / _0023_003DzD47R4_0_003D;
			_0023_003DzBJFJHwk_003D2 = num + num8 * _0023_003DzaQ_y9PQ_003D;
			_0023_003Dz40R7bAU_003D2 = num6;
		}
		else
		{
			num8 = double.MaxValue;
			_0023_003DzBJFJHwk_003D2 = (_0023_003Dz40R7bAU_003D2 = 0.0);
		}
		if (num7 < num8)
		{
			_0023_003Dzt_m8zV0_003D._0023_003DzBJFJHwk_003D = _0023_003DzBJFJHwk_003D;
			_0023_003Dzt_m8zV0_003D._0023_003Dz40R7bAU_003D = _0023_003Dz40R7bAU_003D;
		}
		else
		{
			_0023_003Dzt_m8zV0_003D._0023_003DzBJFJHwk_003D = _0023_003DzBJFJHwk_003D2;
			_0023_003Dzt_m8zV0_003D._0023_003Dz40R7bAU_003D = _0023_003Dz40R7bAU_003D2;
		}
		return true;
	}
}
