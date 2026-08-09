using System.Collections.Generic;

internal sealed class _0023_003Dz_0024fzAI1JIuk4iSR5gAggxbwvzCorJ2sFkQQ_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	internal List<int> _0023_003DzsyasCTaT1ezN;

	internal int _0023_003Dz6U1HVNBmQ6_q;

	internal List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzhrgkevI_003D;

	internal _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzNzjvfA4_003D;

	internal _0023_003Dz_0024fzAI1JIuk4iSR5gAggxbwvzCorJ2sFkQQ_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzsyasCTaT1ezN = null;
		_0023_003Dz6U1HVNBmQ6_q = -1;
		_0023_003DzhrgkevI_003D = null;
		_0023_003DzNzjvfA4_003D = null;
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
			_0023_003DzsyasCTaT1ezN = new List<int>();
			string _0023_003DzgPsOl1A_003D = text.Substring(num + 1, num2 - num - 1);
			string _0023_003DzD5YCi2M_003D = string.Empty;
			int _0023_003DzoiYtBx0_003D = -1;
			while (_0023_003DzgPsOl1A_003D.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
				int.TryParse(_0023_003DzD5YCi2M_003D, out _0023_003DzoiYtBx0_003D);
				_0023_003DzsyasCTaT1ezN.Add(_0023_003DzoiYtBx0_003D);
			}
			text = text.Remove(0, num2 + 1);
			int num3 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
			text = text.Remove(0, num3 + 1);
			text = text.Trim();
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref text, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
			int.TryParse(_0023_003DzD5YCi2M_003D, out _0023_003Dz6U1HVNBmQ6_q);
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		{
			_0023_003DzhrgkevI_003D = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
			for (int i = 0; i < _0023_003DzsyasCTaT1ezN.Count; i++)
			{
				int _0023_003DzoiYtBx0_003D = _0023_003DzsyasCTaT1ezN[i];
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzoiYtBx0_003D, _0023_003Dz9UNAzE0_003D);
				_0023_003DzhrgkevI_003D.Add(item);
			}
			_0023_003DzNzjvfA4_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003Dz6U1HVNBmQ6_q, _0023_003Dz9UNAzE0_003D);
			if (_0023_003DzhrgkevI_003D.Count > 0 && _0023_003DzNzjvfA4_003D != null)
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
}
