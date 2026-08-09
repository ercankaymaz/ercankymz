using System;
using System.Collections.Generic;

internal sealed class _0023_003DzwoUEu1GYTUlM2M8ECGZLrNlSDaFxTsjwOTs_YVzfEZjn
{
	private readonly _0023_003DzAMGa07y9qH6s4xaLezhLAFrxQ775hm32_ykzluw_003D _0023_003DzC52D07s_003D;

	public _0023_003DzwoUEu1GYTUlM2M8ECGZLrNlSDaFxTsjwOTs_YVzfEZjn(_0023_003DzAMGa07y9qH6s4xaLezhLAFrxQ775hm32_ykzluw_003D _0023_003Dz_0024VUrqC8_003D)
	{
		_0023_003DzC52D07s_003D = _0023_003Dz_0024VUrqC8_003D;
	}

	public int _0023_003Dzd7KOrGM_003D(double _0023_003DzZSyoUlOgPyhZHVLrrLlLcvc_003D, _0023_003DzpYoteAqt0D_0024zP2ZOoAlrRyKQ0ICQlGMKIzEozS0_003D _0023_003Dz5Z0e1TPvRJxr, ref uint _0023_003Dz919Srlp4O7cL)
	{
		uint num = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzmVsXTy4_003D();
		uint num2 = _0023_003DzC52D07s_003D._0023_003DzJoQyuB3L218D1ey_g5qeO8s0GOMg();
		bool flag = _0023_003DzZSyoUlOgPyhZHVLrrLlLcvc_003D > 0.0 && _0023_003DzZSyoUlOgPyhZHVLrrLlLcvc_003D < double.MaxValue && _0023_003Dz5Z0e1TPvRJxr._0023_003DzqOsxzwuH4oyb();
		_0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2 = new _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D();
		_0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D2 = new _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D();
		double num3 = 0.0;
		_0023_003Dz919Srlp4O7cL = 0u;
		if (num2 == 0)
		{
			return 0;
		}
		if (!_0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D2._0023_003DzroU3nqY_003D(num, 0.0))
		{
			return -199;
		}
		if (flag)
		{
			num3 = 1.0 / Math.Log(_0023_003DzZSyoUlOgPyhZHVLrrLlLcvc_003D + 1.0);
		}
		for (uint num4 = 0u; num4 < num; num4++)
		{
			if (!_0023_003DzC52D07s_003D._0023_003DzrdMf_pfCsdQCtxsMsJuNcuA_003D(num4))
			{
				continue;
			}
			uint _0023_003DzOzmGr5I_003D = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzYlRpapy_b5uM(num4);
			double num5 = _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2._0023_003DzXULhp_00248_003D(_0023_003DzC52D07s_003D._0023_003DzhqrRQ_0024w_003D, _0023_003DzC52D07s_003D._0023_003DzGUyJY9w_003D, _0023_003DzOzmGr5I_003D, _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D);
			if (flag)
			{
				double val = _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2._0023_003Dz84KsKCc_003D(_0023_003DzC52D07s_003D._0023_003DzhqrRQ_0024w_003D, _0023_003Dz5Z0e1TPvRJxr, _0023_003DzOzmGr5I_003D, _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D);
				val = Math.Max(val, 1.0);
				double num6 = 0.0;
				if (val > 0.0 && num5 > 0.0)
				{
					num6 = Math.Abs(Math.Log(val / num5)) * num3;
				}
				num6 /= num6 + num5;
				num5 = val + num6 * (num5 - val);
			}
			num5 = Math.Max(num5, 1.0);
			_0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D2._0023_003DzSZ0NwQM_003D(num4, num5);
		}
		_0023_003DzSARxLFOsM9qFYzSJfA_003D_003D(1.5, _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D2);
		double value = _0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003DzH1SwwS4_003D(_0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D2);
		_0023_003Dz919Srlp4O7cL = Convert.ToUInt32(value);
		return 0;
	}

	private void _0023_003DzSARxLFOsM9qFYzSJfA_003D_003D(double _0023_003Dz8u08_P9_0024Lj1p, _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003DzmXBK3CU_003D)
	{
		uint num = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzmVsXTy4_003D();
		_0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2 = new _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D();
		List<Tuple<double, uint[]>> list = new List<Tuple<double, uint[]>>();
		double num2 = 0.0;
		uint[] array = new uint[2];
		uint num3 = Convert.ToUInt32(_0023_003Dz_AGJ6KmEuGEmg39CWE8OigaLompxyY5yxwkbEIU_003D._0023_003DznLcGlpnwFvnn.NBR_BOUNDARIES);
		for (uint num4 = 0u; num4 < num; num4++)
		{
			double num5 = _0023_003DzmXBK3CU_003D._0023_003DzYBaDcXE_003D(num4);
			if (num5 == 0.0)
			{
				continue;
			}
			uint _0023_003DzOzmGr5I_003D = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzYlRpapy_b5uM(num4);
			double _0023_003Dzj8RyfSk_003D = _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2._0023_003DzXULhp_00248_003D(_0023_003DzC52D07s_003D._0023_003DzhqrRQ_0024w_003D, _0023_003DzOzmGr5I_003D, _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D);
			for (uint num6 = 0u; num6 < num3; num6++)
			{
				uint num7 = _0023_003DzC52D07s_003D._0023_003DzsLmDCzE_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num6, num4);
				if (num7 > num4)
				{
					continue;
				}
				double num8 = _0023_003DzmXBK3CU_003D._0023_003DzYBaDcXE_003D(num7);
				if (num8 != 0.0)
				{
					uint _0023_003DzOzmGr5I_003D2 = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzYlRpapy_b5uM(num7);
					double _0023_003Dz8J_Cjwo_003D = _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2._0023_003DzXULhp_00248_003D(_0023_003DzC52D07s_003D._0023_003DzhqrRQ_0024w_003D, _0023_003DzOzmGr5I_003D2, _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D);
					num2 = _0023_003DzHicbBIfc4C_0024hEwo5oKwrmflQck7AuaaLHNtgFfc_003D(num5, _0023_003Dzj8RyfSk_003D, num8, _0023_003Dz8J_Cjwo_003D);
					num2 = Math.Min(num2, 3.4028234663852886E+38);
					if (num2 > _0023_003Dz8u08_P9_0024Lj1p)
					{
						list.Add(Tuple.Create(num2, new uint[2] { num4, num7 }));
					}
					num2 = 1.0 / num2;
					if (num2 > _0023_003Dz8u08_P9_0024Lj1p)
					{
						list.Add(Tuple.Create(num2, new uint[2] { num7, num4 }));
					}
				}
			}
		}
		while (list.Count > 0)
		{
			num2 = list[0].Item1;
			array = list[0].Item2;
			list.RemoveAt(0);
			uint num4 = array[0];
			uint num7 = array[1];
			uint _0023_003DzOzmGr5I_003D = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzYlRpapy_b5uM(num4);
			uint _0023_003DzOzmGr5I_003D2 = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzYlRpapy_b5uM(num7);
			double _0023_003Dzj8RyfSk_003D = _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2._0023_003DzXULhp_00248_003D(_0023_003DzC52D07s_003D._0023_003DzhqrRQ_0024w_003D, _0023_003DzOzmGr5I_003D, _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D);
			double _0023_003Dz8J_Cjwo_003D = _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2._0023_003DzXULhp_00248_003D(_0023_003DzC52D07s_003D._0023_003DzhqrRQ_0024w_003D, _0023_003DzOzmGr5I_003D2, _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D);
			double num5 = _0023_003DzmXBK3CU_003D._0023_003DzYBaDcXE_003D(num4);
			double num8 = _0023_003DzmXBK3CU_003D._0023_003DzYBaDcXE_003D(num7);
			double num9 = _0023_003Dz8u08_P9_0024Lj1p * num8 * (_0023_003Dzj8RyfSk_003D / _0023_003Dz8J_Cjwo_003D);
			if (num5 < num9 * 1.000000000001)
			{
				continue;
			}
			_0023_003DzmXBK3CU_003D._0023_003DzSZ0NwQM_003D(num4, num9);
			num5 = num9;
			for (uint num10 = 0u; num10 < num3; num10++)
			{
				uint num11 = _0023_003DzC52D07s_003D._0023_003DzsLmDCzE_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num10, num4);
				if (num11 == uint.MaxValue || num11 == num7)
				{
					continue;
				}
				num8 = _0023_003DzmXBK3CU_003D._0023_003DzYBaDcXE_003D(num11);
				if (num8 != 0.0)
				{
					_0023_003DzOzmGr5I_003D2 = _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D._0023_003DzYlRpapy_b5uM(num11);
					_0023_003Dz8J_Cjwo_003D = _0023_003DzzOfVWE1bly2dF4JN1pBMc4s6DzGVO_002411FRn2V8ICdaTkkAVfOQ_003D_003D2._0023_003DzXULhp_00248_003D(_0023_003DzC52D07s_003D._0023_003DzhqrRQ_0024w_003D, _0023_003DzOzmGr5I_003D2, _0023_003DzC52D07s_003D._0023_003DzH2Hqp0s_003D);
					num2 = _0023_003DzHicbBIfc4C_0024hEwo5oKwrmflQck7AuaaLHNtgFfc_003D(num8, _0023_003Dz8J_Cjwo_003D, num5, _0023_003Dzj8RyfSk_003D);
					num2 = Math.Min(num2, 3.4028234663852886E+38);
					if (num2 > _0023_003Dz8u08_P9_0024Lj1p)
					{
						list.Add(Tuple.Create(num2, new uint[2] { num11, num4 }));
					}
				}
			}
		}
	}

	private static double _0023_003DzHicbBIfc4C_0024hEwo5oKwrmflQck7AuaaLHNtgFfc_003D(double _0023_003DzklzjGv8_003D, double _0023_003Dzj8RyfSk_003D, double _0023_003Dze_8O_0024Rg_003D, double _0023_003Dz8J_Cjwo_003D)
	{
		return _0023_003DzklzjGv8_003D * _0023_003Dz8J_Cjwo_003D / (_0023_003Dze_8O_0024Rg_003D * _0023_003Dzj8RyfSk_003D);
	}
}
