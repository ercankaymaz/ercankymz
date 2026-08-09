using System;
using System.Collections.Generic;

internal sealed class _0023_003Dz2KFuzC6NUypsN0Ap_iSYT3ZTh6GmF0bMtjbmk3kBmBYY
{
	private static IList<int> _0023_003Dz_W0BWNohOQ_0024f(_0023_003Dz1k8g79YtmFbIePcxbICwvq0f_Fuo9R7q0g_003D_003D _0023_003DzEP3lrAc_003D)
	{
		_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9 = _0023_003DzEP3lrAc_003D._0023_003DzpFQU3MrOxdf3();
		int num = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzmf8mDHW8MUJO();
		if (num <= 0)
		{
			return new List<int>();
		}
		int num2 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzm7mcmeeaNf5j();
		if (num2 != 0 && num2 != 1 && num2 != 3 && num2 != 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935019) + num2);
		}
		switch (num2)
		{
		case 4:
		{
			int num6 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzm7mcmeeaNf5j();
			if (num6 == 0)
			{
				return _0023_003Dz_W0BWNohOQ_0024f(_0023_003DzEP3lrAc_003D);
			}
			int num7 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzmf8mDHW8MUJO();
			int num8 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzm7mcmeeaNf5j();
			IList<int> list3 = _0023_003Dz_W0BWNohOQ_0024f(_0023_003DzEP3lrAc_003D);
			IList<int> list4 = _0023_003Dz_W0BWNohOQ_0024f(_0023_003DzEP3lrAc_003D);
			IList<int> list2 = new List<int>();
			for (int k = 0; k < list3.Count; k++)
			{
				list2.Add((list4[k] | (list3[k] << num8 - num6)) + num7);
			}
			return list2;
		}
		case 0:
		{
			IList<int> list2 = new List<int>();
			int num5 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzmf8mDHW8MUJO() / 4;
			for (int j = 0; j < num5; j++)
			{
				list2.Add(_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzmf8mDHW8MUJO());
			}
			return list2;
		}
		default:
		{
			int num3 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzmf8mDHW8MUJO();
			int num4 = (int)((double)num3 / 32.0 + 0.99);
			byte[] array = new byte[num4 * 4];
			for (int i = 0; i < num4; i++)
			{
				byte[] array2 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzx_sdUG0Jm7Dk(4);
				if (_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzhY366QI_003D() == (_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8._0023_003DznqdCgf91E_Pg)1)
				{
					array[i * 4] = array2[3];
					array[i * 4 + 1] = array2[2];
					array[i * 4 + 2] = array2[1];
					array[i * 4 + 3] = array2[0];
				}
				else
				{
					array[i * 4] = array2[0];
					array[i * 4 + 1] = array2[1];
					array[i * 4 + 2] = array2[2];
					array[i * 4 + 3] = array2[3];
				}
			}
			_0023_003DzyfH_0024BuBhgX13GvuUpa_d5jbewHjMQyR2N_0024IZlwJccyb3 _0023_003DzDkWkecG7DHfasDKiSw_003D_003D = null;
			IList<int> list = null;
			if (num2 == 3)
			{
				_0023_003DzDkWkecG7DHfasDKiSw_003D_003D = _0023_003DzyfH_0024BuBhgX13GvuUpa_d5jbewHjMQyR2N_0024IZlwJccyb3._0023_003DzuuY9lIM_003D(_0023_003DzEP3lrAc_003D);
				list = _0023_003Dz_W0BWNohOQ_0024f(_0023_003DzEP3lrAc_003D);
				if (num3 == 0 && list.Count == num)
				{
					return list;
				}
			}
			_0023_003Dz3ObUxwwRdhv4SZm5_0024E2uRPhKTiAzrTRSzU_kIxBK8T_e _0023_003DzItnRTLX2YxO = new _0023_003Dz3ObUxwwRdhv4SZm5_0024E2uRPhKTiAzrTRSzU_kIxBK8T_e(array, num3, num, null, _0023_003DzDkWkecG7DHfasDKiSw_003D_003D, list);
			IList<int> list2 = new List<int>();
			switch (num2)
			{
			case 1:
				list2 = _0023_003DzYA3FjxiA2o34gcd3CEOwd6NHCLusQ1E0MfPe24esDjO9wKHJk_0024Ih0LqvPh_0024c._0023_003Dzk2soVoA_003D(_0023_003DzItnRTLX2YxO);
				break;
			case 3:
				list2 = _0023_003Dz966zKSuXxwYrcmeUmYdLXASeP_0024WZ0_3tyyg2EX_0024aNdW2Ceg5GVTp3y0_003D._0023_003DzbkMnxwY_003D(_0023_003DzItnRTLX2YxO);
				break;
			}
			if (list2.Count != num)
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934990) + list2.Count + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915925) + num);
			}
			return list2;
		}
		}
	}

	public static IList<int> _0023_003DzRah59N4uqSSmPo0n3g_003D_003D(_0023_003Dz1k8g79YtmFbIePcxbICwvq0f_Fuo9R7q0g_003D_003D _0023_003DzEP3lrAc_003D, _0023_003DzYJtUYZUrtx_0024K8dtKtoGJHUYAam3xDMDxxseL2I_dPhaJ _0023_003DzRceDbR7_ubFwVTzSBg_003D_003D)
	{
		return _0023_003DzUrYE2gOoVhcwNs60VKUYuDS_00244XWi1OL58pJM180Kd0Ev._0023_003DzOrO8OhEpBn_00246dp4rrthGqMs_003D(_0023_003Dz_W0BWNohOQ_0024f(_0023_003DzEP3lrAc_003D), _0023_003DzRceDbR7_ubFwVTzSBg_003D_003D);
	}

	public static IList<int> _0023_003Dz0eyz_0024dIebwj1azpCsA_003D_003D(_0023_003Dz1k8g79YtmFbIePcxbICwvq0f_Fuo9R7q0g_003D_003D _0023_003DzEP3lrAc_003D, _0023_003DzYJtUYZUrtx_0024K8dtKtoGJHUYAam3xDMDxxseL2I_dPhaJ _0023_003DzRceDbR7_ubFwVTzSBg_003D_003D)
	{
		IList<int> list = _0023_003DzUrYE2gOoVhcwNs60VKUYuDS_00244XWi1OL58pJM180Kd0Ev._0023_003DzOrO8OhEpBn_00246dp4rrthGqMs_003D(_0023_003Dz_W0BWNohOQ_0024f(_0023_003DzEP3lrAc_003D), _0023_003DzRceDbR7_ubFwVTzSBg_003D_003D);
		for (int i = 0; i < list.Count; i++)
		{
			list[i] &= 65535;
		}
		return list;
	}
}
