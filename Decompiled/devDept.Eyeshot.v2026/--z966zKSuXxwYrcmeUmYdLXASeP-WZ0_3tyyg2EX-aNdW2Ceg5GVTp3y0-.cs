using System;
using System.Collections.Generic;

internal sealed class _0023_003Dz966zKSuXxwYrcmeUmYdLXASeP_0024WZ0_3tyyg2EX_0024aNdW2Ceg5GVTp3y0_003D
{
	public static IList<int> _0023_003DzbkMnxwY_003D(_0023_003Dz3ObUxwwRdhv4SZm5_0024E2uRPhKTiAzrTRSzU_kIxBK8T_e _0023_003DzItnRTLX2YxO5)
	{
		List<int> list = new List<int>();
		_0023_003Dz7_Q_00247lH14RB0e4Sc7IUOMRW8_AjhZHAJh_u4_e9b6cvX8VHKTd4XNEk_003D _0023_003Dz7_Q_00247lH14RB0e4Sc7IUOMRW8_AjhZHAJh_u4_e9b6cvX8VHKTd4XNEk_003D2 = new _0023_003Dz7_Q_00247lH14RB0e4Sc7IUOMRW8_AjhZHAJh_u4_e9b6cvX8VHKTd4XNEk_003D(_0023_003DzItnRTLX2YxO5._0023_003DzvwZotbXqlnjNvBozzg_003D_003D());
		int num = 0;
		int num2 = 0;
		int num3 = 65535;
		int num4 = 0;
		int num5 = 0;
		int num6 = _0023_003DzItnRTLX2YxO5._0023_003DzxI_oWtmAuLhY();
		int num7 = 0;
		int[] array = new int[3];
		int num8 = 0;
		IList<int> list2 = _0023_003DzItnRTLX2YxO5._0023_003DznW3Oee_isi08RPCpIg_003D_003D();
		int[] array2 = _0023_003DzItnRTLX2YxO5._0023_003Dz_0024kiaV6NWlaiA();
		if (array2 == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934653));
		}
		num4 = array2[0];
		num5 = array2[1];
		num = (num4 >> 16) & 0xFFFF;
		num4 <<= 16;
		num5 = 16;
		for (int i = 0; i < num6; i++)
		{
			int _0023_003Dz_gNfoeFb9NXerzA4Jw_003D_003D = ((num - num2 + 1) * _0023_003Dz7_Q_00247lH14RB0e4Sc7IUOMRW8_AjhZHAJh_u4_e9b6cvX8VHKTd4XNEk_003D2._0023_003DzhCDbTTHDLgi_(num7) - 1) / (num3 - num2 + 1);
			_0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2 = _0023_003Dz7_Q_00247lH14RB0e4Sc7IUOMRW8_AjhZHAJh_u4_e9b6cvX8VHKTd4XNEk_003D2._0023_003Dz5Ri1wxim4MXu08sLxEGkI3NXDE36(num7, _0023_003Dz_gNfoeFb9NXerzA4Jw_003D_003D, array);
			int num9 = num3 - num2 + 1;
			num3 = num2 + (num9 * array[1] / array[2] - 1);
			num2 += num9 * array[0] / array[2];
			while (true)
			{
				if ((~(num3 ^ num2) & 0x8000) <= 0)
				{
					if ((num2 & 0x4000) <= 0 || (num3 & 0x4000) != 0)
					{
						break;
					}
					num ^= 0x4000;
					num &= 0xFFFF;
					num2 &= 0x3FFF;
					num2 &= 0xFFFF;
					num3 |= 0x4000;
					num3 &= 0xFFFF;
				}
				num2 = (num2 << 1) & 0xFFFF;
				num3 = (num3 << 1) & 0xFFFF;
				num3 = (num3 | 1) & 0xFFFF;
				num = (num << 1) & 0xFFFF;
				if (num5 == 0)
				{
					array2 = _0023_003DzItnRTLX2YxO5._0023_003Dz_0024kiaV6NWlaiA();
					if (array2 == null)
					{
						throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934653));
					}
					num4 = array2[0];
					num5 = array2[1];
				}
				num |= (num4 >> 31) & 1;
				num4 <<= 1;
				num5--;
			}
			if (_0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2._0023_003Dzg4vLGuo_003D() != -2 || num7 <= 0)
			{
				if (_0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2._0023_003Dzg4vLGuo_003D() == -2 && num8 >= list2.Count)
				{
					throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934602) + i + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915925) + num6);
				}
				list.Add((_0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2._0023_003Dzg4vLGuo_003D() == -2 && num8 < list2.Count) ? list2[num8++] : _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2._0023_003Dzqn_YlnP2eEqA());
			}
			num7 = _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2._0023_003Dz6bhkNzl_0024_M0L();
		}
		return list;
	}
}
