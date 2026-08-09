using System.Collections.Generic;

internal sealed class _0023_003DzXzvXPV1Q_0024_xeiEp9nXGkVg0_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private int _0023_003DzginCQikAoNDdTGP_qA_003D_003D;

	private int _0023_003DzFJms9ANSgsb3mPcTnQ_003D_003D;

	internal _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D _0023_003DzBe_0024nQCB_0024uHrX;

	internal _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D _0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D;

	internal _0023_003DzXzvXPV1Q_0024_xeiEp9nXGkVg0_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzginCQikAoNDdTGP_qA_003D_003D = -1;
		_0023_003DzFJms9ANSgsb3mPcTnQ_003D_003D = -1;
		_0023_003DzBe_0024nQCB_0024uHrX = null;
		_0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D = null;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public static int _0023_003DztowQFZAD4xAY(string _0023_003Dzz0apMk0_003D, string _0023_003Dzkv_0024RgcnpMtzk)
	{
		int num = 0;
		if (_0023_003Dzz0apMk0_003D.Contains(_0023_003Dzkv_0024RgcnpMtzk))
		{
			for (int i = 0; i < _0023_003Dzz0apMk0_003D.Length; i++)
			{
				string text = _0023_003Dzz0apMk0_003D.Substring(i);
				if (text.Length >= _0023_003Dzkv_0024RgcnpMtzk.Length && _0023_003Dzz0apMk0_003D.Substring(i, _0023_003Dzkv_0024RgcnpMtzk.Length).Equals(_0023_003Dzkv_0024RgcnpMtzk) && text.TrimStart(',', ' ').StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027)))
				{
					num++;
					i += _0023_003Dzkv_0024RgcnpMtzk.Length - 1;
				}
			}
		}
		return num;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			string _0023_003Dz7TFjJCU_003D = _0023_003DziHtkvmE_003D;
			int num = _0023_003DztowQFZAD4xAY(_0023_003Dz7TFjJCU_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962));
			string _0023_003DzgPsOl1A_003D = string.Empty;
			int result = -1;
			if (num > 3)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzhQccLgfjFg14(ref _0023_003Dz7TFjJCU_003D, ref _0023_003DzgPsOl1A_003D);
				_0023_003Dz0cCjg9B5UMsA._0023_003DzhQccLgfjFg14(ref _0023_003Dz7TFjJCU_003D, ref _0023_003DzgPsOl1A_003D);
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Trim();
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, 1);
				_0023_003Dz0cCjg9B5UMsA._0023_003DzhQccLgfjFg14(ref _0023_003Dz7TFjJCU_003D, ref _0023_003DzgPsOl1A_003D);
				_0023_003Dz0cCjg9B5UMsA._0023_003DzhQccLgfjFg14(ref _0023_003Dz7TFjJCU_003D, ref _0023_003DzgPsOl1A_003D);
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Trim();
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, 1);
				_0023_003Dz7TFjJCU_003D = _0023_003DzgPsOl1A_003D;
			}
			else
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzBOy9x2E_003D(ref _0023_003Dz7TFjJCU_003D, ref _0023_003DzgPsOl1A_003D);
			}
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003Dz7TFjJCU_003D, ref _0023_003DzgPsOl1A_003D);
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Trim();
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, 1);
			int.TryParse(_0023_003DzgPsOl1A_003D, out result);
			_0023_003DzginCQikAoNDdTGP_qA_003D_003D = result;
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003Dz7TFjJCU_003D, ref _0023_003DzgPsOl1A_003D);
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Trim();
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, 1);
			int.TryParse(_0023_003DzgPsOl1A_003D, out result);
			_0023_003DzFJms9ANSgsb3mPcTnQ_003D_003D = result;
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
			_0023_003DzBe_0024nQCB_0024uHrX = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzginCQikAoNDdTGP_qA_003D_003D, _0023_003Dz9UNAzE0_003D) as _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D;
			_0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzFJms9ANSgsb3mPcTnQ_003D_003D, _0023_003Dz9UNAzE0_003D) as _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D;
			if (_0023_003DzBe_0024nQCB_0024uHrX != null && _0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D != null)
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
}
