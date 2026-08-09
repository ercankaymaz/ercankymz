using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;

internal sealed class _0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D : _0023_003DznmBAWW_B9tXqds3JGNGHTGmGmJA0Izn4ZQ_003D_003D
{
	private _0023_003DzntKPXmU_SFh7iBgnO2un5k3niitxK1gUn9Tp9Jk_003D _0023_003Dz6NcUVy850XR_0024;

	private int _0023_003DzEfCxfUNyj9HQ;

	private int _0023_003DzkSB8HM3WdsAF;

	private float[] _0023_003Dz7qJjpna6QvyZh9fWFA_003D_003D;

	private float[] _0023_003Dzw9Fg4I6ZeDuujC6UaQ_003D_003D;

	private float[] _0023_003DzeLBTAmGoARekz8GF4w_003D_003D;

	private float[] _0023_003DzWnQpXtwiVM_sQZVP_0024A_003D_003D;

	private float _0023_003Dz4cmnjuyrUXh8lGgXuw_003D_003D;

	private float _0023_003DzPeEwMLxF_0024vuh0sAltIInk00_003D;

	public _0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D(_0023_003DzntKPXmU_SFh7iBgnO2un5k3niitxK1gUn9Tp9Jk_003D _0023_003DzaaVPGs2VPKo_0024, int _0023_003DzQRMV62AXh5Ks, int _0023_003Dzj_0024o4m20_003D, float[] _0023_003Dzv4H2M1dooXX7Ta2CBQ_003D_003D, float[] _0023_003DzBqd7LlzhtOV5tLlybQ_003D_003D, float[] _0023_003Dzulhy9AygdSKxlj0nWQ_003D_003D, float[] _0023_003DzTkhWUydSHOhctV7AbQ_003D_003D, float _0023_003DzQwoPqpCHHvg0k0tWgQ_003D_003D, float _0023_003DzzLuGid86qTaFkw4lPWFkb_A_003D)
	{
		_0023_003Dz6NcUVy850XR_0024 = _0023_003DzaaVPGs2VPKo_0024;
		_0023_003DzEfCxfUNyj9HQ = _0023_003DzQRMV62AXh5Ks;
		_0023_003DzkSB8HM3WdsAF = _0023_003Dzj_0024o4m20_003D;
		_0023_003Dz7qJjpna6QvyZh9fWFA_003D_003D = _0023_003Dzv4H2M1dooXX7Ta2CBQ_003D_003D;
		_0023_003Dzw9Fg4I6ZeDuujC6UaQ_003D_003D = _0023_003DzBqd7LlzhtOV5tLlybQ_003D_003D;
		_0023_003DzeLBTAmGoARekz8GF4w_003D_003D = _0023_003Dzulhy9AygdSKxlj0nWQ_003D_003D;
		_0023_003DzWnQpXtwiVM_sQZVP_0024A_003D_003D = _0023_003DzTkhWUydSHOhctV7AbQ_003D_003D;
		_0023_003Dz4cmnjuyrUXh8lGgXuw_003D_003D = _0023_003DzQwoPqpCHHvg0k0tWgQ_003D_003D;
		_0023_003DzPeEwMLxF_0024vuh0sAltIInk00_003D = _0023_003DzzLuGid86qTaFkw4lPWFkb_A_003D;
	}

	[SpecialName]
	public override int _0023_003DzMZORT0_wD2iU()
	{
		return _0023_003Dz6NcUVy850XR_0024._0023_003DzMZORT0_wD2iU();
	}

	[SpecialName]
	public override int[] _0023_003DzgtpcYztDPvrxIz1aLQ_003D_003D()
	{
		return new int[0];
	}

	[SpecialName]
	public override int[] _0023_003Dz9HhhwQK0Q70i()
	{
		return new int[0];
	}

	public virtual bool _0023_003DzBrWcJKetET1VDJFZ2Q_003D_003D()
	{
		return true;
	}

	public virtual Color _0023_003DzyD2LOeq2N7F3hqOUJg_003D_003D()
	{
		return _0023_003Dzk1etjG_0024cxSqN(_0023_003Dzw9Fg4I6ZeDuujC6UaQ_003D_003D);
	}

	private static Color _0023_003Dzk1etjG_0024cxSqN(float[] _0023_003Dz1MMYB1g_003D)
	{
		int value = (int)(_0023_003Dz1MMYB1g_003D[3] * 255f);
		int value2 = (int)(_0023_003Dz1MMYB1g_003D[0] * 255f);
		int value3 = (int)(_0023_003Dz1MMYB1g_003D[1] * 255f);
		int value4 = (int)(_0023_003Dz1MMYB1g_003D[2] * 255f);
		Utility.LimitRange(0, ref value, 255);
		Utility.LimitRange(0, ref value2, 255);
		Utility.LimitRange(0, ref value3, 255);
		Utility.LimitRange(0, ref value4, 255);
		return Color.FromArgb(value, value2, value3, value4);
	}

	public override _0023_003DznmBAWW_B9tXqds3JGNGHTGmGmJA0Izn4ZQ_003D_003D _0023_003Dzl_0024kBRC0_003D(_0023_003DznmBAWW_B9tXqds3JGNGHTGmGmJA0Izn4ZQ_003D_003D _0023_003Dzv_0024fLc28zREub)
	{
		_0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D _0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D2 = new _0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D(_0023_003Dz6NcUVy850XR_0024._0023_003Dzl_0024kBRC0_003D(), _0023_003DzEfCxfUNyj9HQ, _0023_003DzkSB8HM3WdsAF, _0023_003DzUaX45abIO19sQfTsqditkJ4FOENY7dreSw_003D_003D._0023_003Dzl_0024kBRC0_003D(_0023_003Dz7qJjpna6QvyZh9fWFA_003D_003D), _0023_003DzUaX45abIO19sQfTsqditkJ4FOENY7dreSw_003D_003D._0023_003Dzl_0024kBRC0_003D(_0023_003Dzw9Fg4I6ZeDuujC6UaQ_003D_003D), _0023_003DzUaX45abIO19sQfTsqditkJ4FOENY7dreSw_003D_003D._0023_003Dzl_0024kBRC0_003D(_0023_003DzeLBTAmGoARekz8GF4w_003D_003D), _0023_003DzUaX45abIO19sQfTsqditkJ4FOENY7dreSw_003D_003D._0023_003Dzl_0024kBRC0_003D(_0023_003DzWnQpXtwiVM_sQZVP_0024A_003D_003D), _0023_003Dz4cmnjuyrUXh8lGgXuw_003D_003D, _0023_003DzPeEwMLxF_0024vuh0sAltIInk00_003D);
		_0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D2._0023_003DzSD_0024ZCwHi7x_6(_0023_003Dzoyp4rmRaGiPT());
		_0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D2._0023_003DzWTZ7g0wCg1Dm(_0023_003DzI5ye6NQtvmBc());
		_0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D2._0023_003DzqbWVTwgzXw2T(_0023_003Dzv_0024fLc28zREub);
		foreach (_0023_003DznmBAWW_B9tXqds3JGNGHTGmGmJA0Izn4ZQ_003D_003D item in _0023_003Dz3a4lXaPbfyvcA4rU3A_003D_003D())
		{
			_0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D2._0023_003DzSGN9nP_00242SSXc(item._0023_003Dzl_0024kBRC0_003D(_0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D2));
		}
		return _0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D2;
	}

	public static _0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D _0023_003DzuuY9lIM_003D(_0023_003Dz1k8g79YtmFbIePcxbICwvq0f_Fuo9R7q0g_003D_003D _0023_003DzEP3lrAc_003D)
	{
		_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9 = _0023_003DzEP3lrAc_003D._0023_003DzpFQU3MrOxdf3();
		_0023_003DzntKPXmU_SFh7iBgnO2un5k3niitxK1gUn9Tp9Jk_003D _0023_003DzntKPXmU_SFh7iBgnO2un5k3niitxK1gUn9Tp9Jk_003D2 = _0023_003DzntKPXmU_SFh7iBgnO2un5k3niitxK1gUn9Tp9Jk_003D._0023_003DzuuY9lIM_003D(_0023_003DzEP3lrAc_003D);
		int num = -1;
		if ((double)_0023_003DzEP3lrAc_003D._0023_003DzxS4fhlkxDQAJ() >= 9.5)
		{
			num = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzYeSlt_NVa_00248u();
			if (num != 1 && num != 2)
			{
				throw new ArgumentException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935723), num, _0023_003DzntKPXmU_SFh7iBgnO2un5k3niitxK1gUn9Tp9Jk_003D2._0023_003DzMZORT0_wD2iU()));
			}
		}
		int num2 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzIcyyqsXtZDUy();
		bool flag = (num2 & 1) != 0;
		float[] array = null;
		if (flag && (num2 & 2) != 0 && (double)_0023_003DzEP3lrAc_003D._0023_003DzxS4fhlkxDQAJ() < 9.5)
		{
			float num3 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzWTmlNWQ2_0024V27();
			array = new float[4] { num3, num3, num3, 1f };
		}
		else
		{
			array = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzjwzm9Hsz4xeB();
		}
		float[] _0023_003DzBqd7LlzhtOV5tLlybQ_003D_003D = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzjwzm9Hsz4xeB();
		float[] array2 = null;
		if (flag && (num2 & 8) != 0 && (double)_0023_003DzEP3lrAc_003D._0023_003DzxS4fhlkxDQAJ() < 9.5)
		{
			float num4 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzWTmlNWQ2_0024V27();
			array2 = new float[4] { num4, num4, num4, 1f };
		}
		else
		{
			array2 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzjwzm9Hsz4xeB();
		}
		float[] array3 = null;
		if (flag && (num2 & 4) != 0 && (double)_0023_003DzEP3lrAc_003D._0023_003DzxS4fhlkxDQAJ() < 9.5)
		{
			float num5 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzWTmlNWQ2_0024V27();
			array3 = new float[4] { num5, num5, num5, 1f };
		}
		else
		{
			array3 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzjwzm9Hsz4xeB();
		}
		float _0023_003DzQwoPqpCHHvg0k0tWgQ_003D_003D = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzWTmlNWQ2_0024V27();
		float _0023_003DzzLuGid86qTaFkw4lPWFkb_A_003D = -1f;
		if (num == 2)
		{
			_0023_003DzzLuGid86qTaFkw4lPWFkb_A_003D = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzWTmlNWQ2_0024V27();
		}
		return new _0023_003DzTL_BBECM8OgcvOdjAfqRxH4RegS1MEsyJncj3qc_003D(_0023_003DzntKPXmU_SFh7iBgnO2un5k3niitxK1gUn9Tp9Jk_003D2, num, num2, array, _0023_003DzBqd7LlzhtOV5tLlybQ_003D_003D, array2, array3, _0023_003DzQwoPqpCHHvg0k0tWgQ_003D_003D, _0023_003DzzLuGid86qTaFkw4lPWFkb_A_003D);
	}
}
