using System.Collections.Generic;

internal sealed class _0023_003Dz2iCL0iKkw54x_0024FRXGA_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private List<int> _0023_003Dz0nNl9eDps7Ak;

	private List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzsSLPcz8_003D;

	public _0023_003Dz2iCL0iKkw54x_0024FRXGA_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003Dz0nNl9eDps7Ak = null;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			string text = _0023_003DziHtkvmE_003D;
			int num = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
			int num2 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
			_0023_003Dz0nNl9eDps7Ak = new List<int>();
			string _0023_003DzgPsOl1A_003D = text.Substring(num + 1, num2 - num - 1);
			string _0023_003DzD5YCi2M_003D = string.Empty;
			int _0023_003DzoiYtBx0_003D = -1;
			while (_0023_003DzgPsOl1A_003D.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
				int item2 = ((!int.TryParse(_0023_003DzD5YCi2M_003D, out _0023_003DzoiYtBx0_003D)) ? (-1) : _0023_003DzoiYtBx0_003D);
				_0023_003Dz0nNl9eDps7Ak.Add(item2);
			}
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		{
			_0023_003DzsSLPcz8_003D = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
			for (int i = 0; i < _0023_003Dz0nNl9eDps7Ak.Count; i++)
			{
				int _0023_003DzoiYtBx0_003D = _0023_003Dz0nNl9eDps7Ak[i];
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzoiYtBx0_003D, _0023_003Dz9UNAzE0_003D);
				_0023_003DzsSLPcz8_003D.Add(item);
			}
			if (_0023_003DzsSLPcz8_003D.Count > 0)
			{
				_0023_003DzpXqcGaz7sKJt = true;
				_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
			}
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2:
			_0023_003DzpXqcGaz7sKJt = true;
			break;
		}
	}

	internal void _0023_003DzxRlo_00243mk5Xqcxj6gVpF31ng_003D(out _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu[] _0023_003DzgLezC1VSfJ0_0024)
	{
		int count = _0023_003DzsSLPcz8_003D.Count;
		_0023_003DzgLezC1VSfJ0_0024 = new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu[count];
		for (int i = 0; i < count; i++)
		{
			_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2 = _0023_003DzsSLPcz8_003D[i] as _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu;
			_0023_003DzgLezC1VSfJ0_0024[i] = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2;
		}
	}
}
