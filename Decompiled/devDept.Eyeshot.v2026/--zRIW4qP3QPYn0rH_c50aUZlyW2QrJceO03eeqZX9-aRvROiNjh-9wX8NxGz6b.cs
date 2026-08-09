using System;
using System.Collections.Generic;
using System.Linq;

internal sealed class _0023_003DzRIW4qP3QPYn0rH_c50aUZlyW2QrJceO03eeqZX9_0024aRvROiNjh_00249wX8NxGz6b
{
	private _0023_003DzC_0024j5WRGKlmvpG_44MtRbb4iZVwJthACsgRhkL8jjVJdJLM_0024eN3IaVic_003D _0023_003DzeQZ6_0024Y5dy_GaBGPthA98E8Q_003D;

	private IList<int> _0023_003Dzb6_0024CzrUdOyA5HgDeaw_003D_003D;

	private IList<int> _0023_003Dzog1ZM1KcH4jjiQwJIg_003D_003D;

	private IList<int> _0023_003DzdbugBtavok1p;

	public _0023_003DzRIW4qP3QPYn0rH_c50aUZlyW2QrJceO03eeqZX9_0024aRvROiNjh_00249wX8NxGz6b(_0023_003DzC_0024j5WRGKlmvpG_44MtRbb4iZVwJthACsgRhkL8jjVJdJLM_0024eN3IaVic_003D _0023_003DzyDchGVGyb4_xIGKoz5ttEuo_003D, int _0023_003DzhrsBtr04uLWE, int _0023_003Dz1h_0024IpFljFpCjfAU5hw_003D_003D, IList<int> _0023_003DzWOb6BSYdL6nG, IList<int> _0023_003Dz7WZkuT10gN_w, IList<int> _0023_003DzJdqmgUaVirHX, IList<int> _0023_003DzHwt0uQos4mAt, IList<int> _0023_003DzgR7ExAz5S2Bh)
	{
		_0023_003DzeQZ6_0024Y5dy_GaBGPthA98E8Q_003D = _0023_003DzyDchGVGyb4_xIGKoz5ttEuo_003D;
		_0023_003Dzb6_0024CzrUdOyA5HgDeaw_003D_003D = _0023_003DzWOb6BSYdL6nG;
		_0023_003Dzog1ZM1KcH4jjiQwJIg_003D_003D = _0023_003Dz7WZkuT10gN_w;
		_0023_003DzdbugBtavok1p = _0023_003DzJdqmgUaVirHX;
	}

	public virtual IList<float> _0023_003DzvfAdsJ9sYTy7()
	{
		float[] array = _0023_003DzeQZ6_0024Y5dy_GaBGPthA98E8Q_003D._0023_003Dz6BzBvOzC_00243Qg();
		float num = array[1] - array[0];
		float num2 = _0023_003Dzb6_0024CzrUdOyA5HgDeaw_003D_003D.Min();
		float num3 = (float)_0023_003Dzb6_0024CzrUdOyA5HgDeaw_003D_003D.Max() - num2;
		float num4 = num / num3;
		float num5 = array[0] - num4 * num2;
		float[] array2 = _0023_003DzeQZ6_0024Y5dy_GaBGPthA98E8Q_003D._0023_003DzgeWsL9zNo0bs();
		float num6 = array2[1] - array2[0];
		float num7 = _0023_003Dzog1ZM1KcH4jjiQwJIg_003D_003D.Min();
		float num8 = (float)_0023_003Dzog1ZM1KcH4jjiQwJIg_003D_003D.Max() - num7;
		float num9 = num6 / num8;
		float num10 = array2[0] - num9 * num7;
		float[] array3 = _0023_003DzeQZ6_0024Y5dy_GaBGPthA98E8Q_003D._0023_003DzaR8pWxJpzant();
		float num11 = array3[1] - array3[0];
		float num12 = _0023_003DzdbugBtavok1p.Min();
		float num13 = (float)_0023_003DzdbugBtavok1p.Max() - num12;
		float num14 = num11 / num13;
		float num15 = array3[0] - num14 * num12;
		IList<float> list = new List<float>();
		for (int i = 0; i < _0023_003Dzb6_0024CzrUdOyA5HgDeaw_003D_003D.Count; i++)
		{
			list.Add(num4 * (float)_0023_003Dzb6_0024CzrUdOyA5HgDeaw_003D_003D[i] + num5);
		}
		IList<float> list2 = new List<float>();
		for (int j = 0; j < _0023_003Dzog1ZM1KcH4jjiQwJIg_003D_003D.Count; j++)
		{
			list2.Add(num9 * (float)_0023_003Dzog1ZM1KcH4jjiQwJIg_003D_003D[j] + num10);
		}
		IList<float> list3 = new List<float>();
		for (int k = 0; k < _0023_003DzdbugBtavok1p.Count; k++)
		{
			list3.Add(num14 * (float)_0023_003DzdbugBtavok1p[k] + num15);
		}
		IList<float> list4 = new List<float>();
		for (int l = 0; l < _0023_003Dzb6_0024CzrUdOyA5HgDeaw_003D_003D.Count; l++)
		{
			list4.Add(list[l]);
			list4.Add(list2[l]);
			list4.Add(list3[l]);
		}
		return list4;
	}

	public static _0023_003DzRIW4qP3QPYn0rH_c50aUZlyW2QrJceO03eeqZX9_0024aRvROiNjh_00249wX8NxGz6b _0023_003DzuuY9lIM_003D(_0023_003Dz1k8g79YtmFbIePcxbICwvq0f_Fuo9R7q0g_003D_003D _0023_003DzEP3lrAc_003D)
	{
		_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 obj = _0023_003DzEP3lrAc_003D._0023_003DzpFQU3MrOxdf3();
		_0023_003DzC_0024j5WRGKlmvpG_44MtRbb4iZVwJthACsgRhkL8jjVJdJLM_0024eN3IaVic_003D _0023_003DzyDchGVGyb4_xIGKoz5ttEuo_003D = _0023_003DzC_0024j5WRGKlmvpG_44MtRbb4iZVwJthACsgRhkL8jjVJdJLM_0024eN3IaVic_003D._0023_003DzuuY9lIM_003D(_0023_003DzEP3lrAc_003D);
		int _0023_003DzhrsBtr04uLWE = obj._0023_003Dzm7mcmeeaNf5j();
		int _0023_003Dz1h_0024IpFljFpCjfAU5hw_003D_003D = obj._0023_003Dzm7mcmeeaNf5j();
		int num = obj._0023_003Dzm7mcmeeaNf5j();
		if (num != 0 && num != 1)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936494) + num);
		}
		IList<int> _0023_003DzWOb6BSYdL6nG = null;
		IList<int> _0023_003Dz7WZkuT10gN_w = null;
		IList<int> _0023_003DzJdqmgUaVirHX = null;
		IList<int> _0023_003DzHwt0uQos4mAt = null;
		IList<int> _0023_003DzgR7ExAz5S2Bh = null;
		if (num == 0)
		{
			_0023_003DzgR7ExAz5S2Bh = _0023_003DzUrYE2gOoVhcwNs60VKUYuDS_00244XWi1OL58pJM180Kd0Ev._0023_003Dz0eyz_0024dIebwj1azpCsA_003D_003D(_0023_003DzEP3lrAc_003D, (_0023_003DzYJtUYZUrtx_0024K8dtKtoGJHUYAam3xDMDxxseL2I_dPhaJ)8);
		}
		else
		{
			_0023_003DzWOb6BSYdL6nG = _0023_003DzUrYE2gOoVhcwNs60VKUYuDS_00244XWi1OL58pJM180Kd0Ev._0023_003Dz0eyz_0024dIebwj1azpCsA_003D_003D(_0023_003DzEP3lrAc_003D, (_0023_003DzYJtUYZUrtx_0024K8dtKtoGJHUYAam3xDMDxxseL2I_dPhaJ)0);
			_0023_003Dz7WZkuT10gN_w = _0023_003DzUrYE2gOoVhcwNs60VKUYuDS_00244XWi1OL58pJM180Kd0Ev._0023_003Dz0eyz_0024dIebwj1azpCsA_003D_003D(_0023_003DzEP3lrAc_003D, (_0023_003DzYJtUYZUrtx_0024K8dtKtoGJHUYAam3xDMDxxseL2I_dPhaJ)0);
			_0023_003DzJdqmgUaVirHX = _0023_003DzUrYE2gOoVhcwNs60VKUYuDS_00244XWi1OL58pJM180Kd0Ev._0023_003Dz0eyz_0024dIebwj1azpCsA_003D_003D(_0023_003DzEP3lrAc_003D, (_0023_003DzYJtUYZUrtx_0024K8dtKtoGJHUYAam3xDMDxxseL2I_dPhaJ)0);
			_0023_003DzHwt0uQos4mAt = _0023_003DzUrYE2gOoVhcwNs60VKUYuDS_00244XWi1OL58pJM180Kd0Ev._0023_003Dz0eyz_0024dIebwj1azpCsA_003D_003D(_0023_003DzEP3lrAc_003D, (_0023_003DzYJtUYZUrtx_0024K8dtKtoGJHUYAam3xDMDxxseL2I_dPhaJ)0);
		}
		return new _0023_003DzRIW4qP3QPYn0rH_c50aUZlyW2QrJceO03eeqZX9_0024aRvROiNjh_00249wX8NxGz6b(_0023_003DzyDchGVGyb4_xIGKoz5ttEuo_003D, _0023_003DzhrsBtr04uLWE, _0023_003Dz1h_0024IpFljFpCjfAU5hw_003D_003D, _0023_003DzWOb6BSYdL6nG, _0023_003Dz7WZkuT10gN_w, _0023_003DzJdqmgUaVirHX, _0023_003DzHwt0uQos4mAt, _0023_003DzgR7ExAz5S2Bh);
	}
}
