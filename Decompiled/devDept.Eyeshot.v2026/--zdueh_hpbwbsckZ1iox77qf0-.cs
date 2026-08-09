using System.Collections.Generic;

internal sealed class _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private List<int> _0023_003DzUdnH5hoTfBYG;

	internal List<_0023_003DzgpK4H7ZVNTkyNrFi4w_003D_003D> _0023_003DzicQSqB0_003D;

	public _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzUdnH5hoTfBYG = null;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public void _0023_003DzNOZ5eIU_003D(ref double[] _0023_003DzZ_uObknlbXUh, ref string _0023_003DzQvukAtw_003D)
	{
		if (_0023_003Dzwtld1NM_003D != null)
		{
			_0023_003DzZ_uObknlbXUh[0] = _0023_003Dzwtld1NM_003D[0];
			_0023_003DzZ_uObknlbXUh[1] = _0023_003Dzwtld1NM_003D[1];
			_0023_003DzZ_uObknlbXUh[2] = _0023_003Dzwtld1NM_003D[2];
			_0023_003DzQvukAtw_003D = base._0023_003DzQvukAtw_003D;
		}
	}

	public List<int> _0023_003DzngS_0mA_MzJr()
	{
		return _0023_003DzUdnH5hoTfBYG;
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
			_0023_003DzUdnH5hoTfBYG = new List<int>();
			string _0023_003DzgPsOl1A_003D = text.Substring(num + 1, num2 - num - 1);
			string _0023_003DzD5YCi2M_003D = string.Empty;
			int _0023_003DzoiYtBx0_003D = -1;
			while (_0023_003DzgPsOl1A_003D.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
				int item2 = ((!int.TryParse(_0023_003DzD5YCi2M_003D, out _0023_003DzoiYtBx0_003D)) ? (-1) : _0023_003DzoiYtBx0_003D);
				_0023_003DzUdnH5hoTfBYG.Add(item2);
			}
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		{
			_0023_003DzicQSqB0_003D = new List<_0023_003DzgpK4H7ZVNTkyNrFi4w_003D_003D>();
			for (int i = 0; i < _0023_003DzUdnH5hoTfBYG.Count; i++)
			{
				int _0023_003DzoiYtBx0_003D = _0023_003DzUdnH5hoTfBYG[i];
				if (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzoiYtBx0_003D, _0023_003Dz9UNAzE0_003D) is _0023_003DzgpK4H7ZVNTkyNrFi4w_003D_003D item)
				{
					_0023_003DzicQSqB0_003D.Add(item);
				}
			}
			if (_0023_003DzicQSqB0_003D.Count > 0)
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

	internal override void _0023_003DzqANTAlA_003D(double[] _0023_003DzqhpeejkrA8yU, string _0023_003DzQvukAtw_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D)
	{
		_0023_003DzAjEYCJs_003D = true;
		_0023_003Dzwtld1NM_003D = new double[3];
		_0023_003Dzwtld1NM_003D[0] = _0023_003DzqhpeejkrA8yU[0];
		_0023_003Dzwtld1NM_003D[1] = _0023_003DzqhpeejkrA8yU[1];
		_0023_003Dzwtld1NM_003D[2] = _0023_003DzqhpeejkrA8yU[2];
		base._0023_003DzQvukAtw_003D = _0023_003DzQvukAtw_003D;
		if (_0023_003DzicQSqB0_003D == null)
		{
			return;
		}
		foreach (_0023_003DzgpK4H7ZVNTkyNrFi4w_003D_003D item in _0023_003DzicQSqB0_003D)
		{
			foreach (int item2 in item._0023_003DzbMKibTbw8dNI2Upf5w_003D_003D())
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = _0023_003Dz9UNAzE0_003D[item2];
				if (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 != null)
				{
					_0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D _0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2 = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 as _0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D;
					bool flag = false;
					if (_0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2 != null && _0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2._0023_003Dzwtld1NM_003D[0] != -1.0 && _0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2._0023_003Dzwtld1NM_003D[1] != -1.0 && _0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2._0023_003Dzwtld1NM_003D[2] != -1.0)
					{
						flag = true;
					}
					if (_0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2 != null && !flag)
					{
						_0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2._0023_003DzqANTAlA_003D(_0023_003Dzwtld1NM_003D, base._0023_003DzQvukAtw_003D, _0023_003Dz9UNAzE0_003D);
					}
				}
			}
		}
	}

	internal void _0023_003Dz6YYH6PHygFqgZrANTA_003D_003D(_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D _0023_003DzXxuuBFk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D)
	{
		if (_0023_003DzicQSqB0_003D == null)
		{
			return;
		}
		foreach (_0023_003DzgpK4H7ZVNTkyNrFi4w_003D_003D item in _0023_003DzicQSqB0_003D)
		{
			foreach (int item2 in item._0023_003DzbMKibTbw8dNI2Upf5w_003D_003D())
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = _0023_003Dz9UNAzE0_003D[item2];
				if (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 != null && _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 is _0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D _0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2)
				{
					_0023_003DzfT7Q72tBEgS3uyqeIQ_003D_003D2._0023_003DzWd_MwxQ_003D._0023_003DztIaJjPw_003D = _0023_003DzXxuuBFk_003D;
				}
			}
		}
	}
}
