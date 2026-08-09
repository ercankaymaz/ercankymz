using System.Collections.Generic;

internal sealed class _0023_003DzybTYvIZgcdcLyyLjJw_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private int _0023_003DzmBBSG5w_003D;

	private int _0023_003DzNqYimbY_003D;

	internal _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu _0023_003DzlY77YgY_003D;

	internal _0023_003DzG9_0024QNM8Ikh4XnXfUBw_003D_003D _0023_003DzY5pSLwI_003D;

	private double[] _0023_003Dz3k5Uze_VdwnF;

	private double[] _0023_003DzMnu3zKCWb6Kc;

	internal _0023_003DzybTYvIZgcdcLyyLjJw_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzmBBSG5w_003D = -1;
		_0023_003DzNqYimbY_003D = -1;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public _0023_003DzybTYvIZgcdcLyyLjJw_003D_003D(double[] _0023_003DzFj_0024IqDQ_003D, double[] _0023_003DzjdeMMkk_003D)
	{
		_0023_003Dz3k5Uze_VdwnF = _0023_003DzFj_0024IqDQ_003D;
		_0023_003DzMnu3zKCWb6Kc = _0023_003DzjdeMMkk_003D;
	}

	internal _0023_003DzybTYvIZgcdcLyyLjJw_003D_003D(double[] _0023_003DzFj_0024IqDQ_003D, double _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D, double[] _0023_003Dz6u3psoE_003D)
	{
		_0023_003DzlY77YgY_003D = new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(_0023_003DzFj_0024IqDQ_003D);
		_0023_003DzY5pSLwI_003D = new _0023_003DzG9_0024QNM8Ikh4XnXfUBw_003D_003D(ref _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D, ref _0023_003Dz6u3psoE_003D);
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			string _0023_003DzgPsOl1A_003D = _0023_003DziHtkvmE_003D;
			for (int num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083)); num > -1; num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083)))
			{
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, 1);
			}
			for (int num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091)); num > -1; num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091)))
			{
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(num, 1);
			}
			string _0023_003DzD5YCi2M_003D = string.Empty;
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
			if (int.TryParse(_0023_003DzD5YCi2M_003D, out var result))
			{
				_0023_003DzmBBSG5w_003D = result;
			}
			else
			{
				_0023_003DzmBBSG5w_003D = -1;
			}
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
			if (int.TryParse(_0023_003DzD5YCi2M_003D, out result))
			{
				_0023_003DzNqYimbY_003D = result;
			}
			else
			{
				_0023_003DzNqYimbY_003D = -1;
			}
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
			_0023_003DzlY77YgY_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzmBBSG5w_003D, _0023_003Dz9UNAzE0_003D) as _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu;
			_0023_003DzY5pSLwI_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzNqYimbY_003D, _0023_003Dz9UNAzE0_003D) as _0023_003DzG9_0024QNM8Ikh4XnXfUBw_003D_003D;
			if (_0023_003DzlY77YgY_003D != null && _0023_003DzY5pSLwI_003D != null)
			{
				_0023_003DzpXqcGaz7sKJt = true;
				_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
			}
			break;
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2:
			_0023_003DzpXqcGaz7sKJt = true;
			break;
		}
	}

	internal void _0023_003Dzz1B0qTa4kmjo(double[] _0023_003DzFj_0024IqDQ_003D, double[] _0023_003DzjdeMMkk_003D)
	{
		_0023_003Dz3k5Uze_VdwnF = _0023_003DzFj_0024IqDQ_003D;
		_0023_003DzMnu3zKCWb6Kc = _0023_003DzjdeMMkk_003D;
	}

	internal int _0023_003DzPTN_0024Y7Y_003D(_0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst, bool _0023_003DzvzZ_0024Ud4VozKo)
	{
		int num = -1;
		if (_0023_003DzvzZ_0024Ud4VozKo)
		{
			num = new _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D(new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D(this), _0023_003Dz3k5Uze_VdwnF, _0023_003DzMnu3zKCWb6Kc, _0023_003DznRGKF2T2ZsN6Flrnxw_003D_003D: true)
			{
				_0023_003Dzx3pYiE0_003D = true
			}._0023_003DzIRy9siWqErpc(_0023_003DzmDt2hY3pmRst);
		}
		else
		{
			int _0023_003Dz5_0024BiNfc_003D = -1;
			double[] array = new double[3];
			_0023_003DzIZZ0zrg_003D(_0023_003Dz3k5Uze_VdwnF, _0023_003DzMnu3zKCWb6Kc, ref array);
			_0023_003DzG9_0024QNM8Ikh4XnXfUBw_003D_003D._0023_003DzMy_0024_0024Nck_003D(array, ref _0023_003Dz5_0024BiNfc_003D, _0023_003DzmDt2hY3pmRst);
			int num2 = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu._0023_003DzuXztUSYcR_Yh_0024879s0ykZ2A_003D(_0023_003Dz3k5Uze_VdwnF, _0023_003DzmDt2hY3pmRst);
			string _0023_003DznXG736c_003D = string.Empty;
			num = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927704), ref _0023_003DznXG736c_003D);
			string text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302923533), num2, _0023_003Dz5_0024BiNfc_003D);
			_0023_003DznXG736c_003D += text;
			_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
		}
		return num;
	}

	private void _0023_003DzIZZ0zrg_003D(double[] _0023_003Dz3k5Uze_VdwnF, double[] _0023_003DzMnu3zKCWb6Kc, ref double[] _0023_003DzY5pSLwI_003D)
	{
		double num = _0023_003DzMnu3zKCWb6Kc[0] - _0023_003Dz3k5Uze_VdwnF[0];
		double num2 = _0023_003DzMnu3zKCWb6Kc[1] - _0023_003Dz3k5Uze_VdwnF[1];
		double num3 = _0023_003DzMnu3zKCWb6Kc[2] - _0023_003Dz3k5Uze_VdwnF[2];
		_0023_003DzY5pSLwI_003D[0] = num;
		_0023_003DzY5pSLwI_003D[1] = num2;
		_0023_003DzY5pSLwI_003D[2] = num3;
	}
}
