using System;
using System.Collections.Generic;
using devDept.Geometry;

internal sealed class _0023_003Dz0UuyzKeWoftDid2rHh7d4tc_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private int _0023_003DzMNyEKNc_003D = -1;

	private int _0023_003Dzo_0024bBi0E_003D = -1;

	private List<List<int>> _0023_003Dzwo9YTP6d_00243jt;

	private string _0023_003Dzb7N9qcQ_WmXf;

	private bool _0023_003DzJCwb4bs_003D;

	private bool _0023_003Dzjn4_0024xRo_003D;

	private bool _0023_003Dz_00246EQcw9LUSy7;

	private List<int> _0023_003DzJHSBrkcTenvdOGUm8k9173Y_003D;

	private List<int> _0023_003DzmfH2pckxi9U_pq_00246p9AY3uA_003D;

	private List<double> _0023_003DzRQbiPKyhjGqRUyVh3g_003D_003D;

	private List<double> _0023_003Dz7LxcB2vamJ41WAN_0024_0024A_003D_003D;

	private List<double> _0023_003DzQuv3myvnehSV;

	private List<double> _0023_003DzbTcvrXagsoun;

	private string _0023_003Dz9FR3dZ9QR_0024CK;

	private List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>> _0023_003DzTkPhA8X_2C3n;

	internal _0023_003Dz0UuyzKeWoftDid2rHh7d4tc_003D()
	{
	}

	internal _0023_003Dz0UuyzKeWoftDid2rHh7d4tc_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	internal _0023_003Dz0UuyzKeWoftDid2rHh7d4tc_003D(int _0023_003DzItEkemKZi0TS, int _0023_003DzdGLdpUwncACK, List<double> _0023_003DzZ3ctEyJbeI9j, List<double> _0023_003Dz2FvJJSmA6lkJ, List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>> _0023_003DzpDQeEMI7yWiW)
	{
		_0023_003DzeN7Q1GfT4YVu(_0023_003DzItEkemKZi0TS);
		_0023_003Dz1k6275iE5mew(_0023_003DzdGLdpUwncACK);
		_0023_003DzQuv3myvnehSV = _0023_003DzZ3ctEyJbeI9j;
		_0023_003DzbTcvrXagsoun = _0023_003Dz2FvJJSmA6lkJ;
		_0023_003DzhKyJEgpB7Qbn(_0023_003DzpDQeEMI7yWiW);
	}

	internal List<double> _0023_003Dz5ftQ4PPOVhb5xw1VYw_003D_003D()
	{
		if (_0023_003DzQuv3myvnehSV == null)
		{
			_0023_003DzQuv3myvnehSV = new List<double>();
			for (int i = 0; i < _0023_003DzRQbiPKyhjGqRUyVh3g_003D_003D.Count; i++)
			{
				double item = _0023_003DzRQbiPKyhjGqRUyVh3g_003D_003D[i];
				int num = _0023_003DzJHSBrkcTenvdOGUm8k9173Y_003D[i];
				for (int j = 1; j <= num; j++)
				{
					_0023_003DzQuv3myvnehSV.Add(item);
				}
			}
		}
		return _0023_003DzQuv3myvnehSV;
	}

	internal void _0023_003Dz28_6S7RXnPLXfc7t_g_003D_003D(List<double> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzQuv3myvnehSV = _0023_003DzPzO_0024GUk_003D;
	}

	internal List<double> _0023_003Dz6PYJ9ArzPazRrnCH4A_003D_003D()
	{
		if (_0023_003DzbTcvrXagsoun == null)
		{
			_0023_003DzbTcvrXagsoun = new List<double>();
			for (int i = 0; i < _0023_003Dz7LxcB2vamJ41WAN_0024_0024A_003D_003D.Count; i++)
			{
				double item = _0023_003Dz7LxcB2vamJ41WAN_0024_0024A_003D_003D[i];
				int num = _0023_003DzmfH2pckxi9U_pq_00246p9AY3uA_003D[i];
				for (int j = 1; j <= num; j++)
				{
					_0023_003DzbTcvrXagsoun.Add(item);
				}
			}
		}
		return _0023_003DzbTcvrXagsoun;
	}

	internal void _0023_003DzO9Q_0024B1pI1FxQM7NEcQ_003D_003D(List<double> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzbTcvrXagsoun = _0023_003DzPzO_0024GUk_003D;
	}

	internal int _0023_003Dzru8rZIVWaRST()
	{
		return _0023_003DzMNyEKNc_003D;
	}

	internal void _0023_003DzeN7Q1GfT4YVu(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMNyEKNc_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal int _0023_003DzYTFd2bOayy9Z()
	{
		return _0023_003Dzo_0024bBi0E_003D;
	}

	internal void _0023_003Dz1k6275iE5mew(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzo_0024bBi0E_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>> _0023_003DzinGuj5Boveem()
	{
		return _0023_003DzTkPhA8X_2C3n;
	}

	internal void _0023_003DzhKyJEgpB7Qbn(List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzTkPhA8X_2C3n = _0023_003DzPzO_0024GUk_003D;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			string _0023_003DzgPsOl1A_003D = _0023_003DziHtkvmE_003D;
			string _0023_003DzD5YCi2M_003D = string.Empty;
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			if (int.TryParse(_0023_003DzD5YCi2M_003D, out var result))
			{
				_0023_003DzMNyEKNc_003D = result;
			}
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			if (int.TryParse(_0023_003DzD5YCi2M_003D, out result))
			{
				_0023_003Dzo_0024bBi0E_003D = result;
			}
			int num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
			int num2 = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920789));
			if (num2 < 0)
			{
				num2 = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920800));
			}
			_0023_003Dzwo9YTP6d_00243jt = new List<List<int>>();
			string text = _0023_003DzgPsOl1A_003D.Substring(num + 1, num2 - num);
			string _0023_003DzD5YCi2M_003D2 = string.Empty;
			int _0023_003DzoiYtBx0_003D = -1;
			while (text.Length > 0)
			{
				int num3 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
				int num4 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
				List<int> list3 = new List<int>();
				string _0023_003DzgPsOl1A_003D2 = text.Substring(num3 + 1, num4 - num3 - 1);
				while (_0023_003DzgPsOl1A_003D2.Length > 0)
				{
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D2, ref _0023_003DzD5YCi2M_003D2);
					_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
					_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Remove(0, 1);
					int item2 = ((!int.TryParse(_0023_003DzD5YCi2M_003D2, out _0023_003DzoiYtBx0_003D)) ? (-1) : _0023_003DzoiYtBx0_003D);
					list3.Add(item2);
				}
				_0023_003Dzwo9YTP6d_00243jt.Add(list3);
				int num5 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
				text = text.Remove(0, num5 + 1);
			}
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, num2 + 3);
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003Dzb7N9qcQ_WmXf = _0023_003DzD5YCi2M_003D;
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			if (_0023_003DzD5YCi2M_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920778))
			{
				_0023_003DzJCwb4bs_003D = true;
			}
			else
			{
				_0023_003DzJCwb4bs_003D = false;
			}
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			if (_0023_003DzD5YCi2M_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920778))
			{
				_0023_003Dzjn4_0024xRo_003D = true;
			}
			else
			{
				_0023_003Dzjn4_0024xRo_003D = false;
			}
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			if (_0023_003DzD5YCi2M_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920778))
			{
				_0023_003Dz_00246EQcw9LUSy7 = true;
			}
			else
			{
				_0023_003Dz_00246EQcw9LUSy7 = false;
			}
			_0023_003DzJHSBrkcTenvdOGUm8k9173Y_003D = new List<int>();
			num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
			num2 = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
			text = _0023_003DzgPsOl1A_003D.Substring(num + 1, num2 - num - 1);
			while (text.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref text, ref _0023_003DzD5YCi2M_003D2);
				_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
				int.TryParse(_0023_003DzD5YCi2M_003D2, out _0023_003DzoiYtBx0_003D);
				_0023_003DzJHSBrkcTenvdOGUm8k9173Y_003D.Add(_0023_003DzoiYtBx0_003D);
			}
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, num2 + 2);
			_0023_003DzmfH2pckxi9U_pq_00246p9AY3uA_003D = new List<int>();
			num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
			num2 = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
			text = _0023_003DzgPsOl1A_003D.Substring(num + 1, num2 - num - 1);
			while (text.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref text, ref _0023_003DzD5YCi2M_003D2);
				_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
				int.TryParse(_0023_003DzD5YCi2M_003D2, out _0023_003DzoiYtBx0_003D);
				_0023_003DzmfH2pckxi9U_pq_00246p9AY3uA_003D.Add(_0023_003DzoiYtBx0_003D);
			}
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, num2 + 2);
			_0023_003DzRQbiPKyhjGqRUyVh3g_003D_003D = new List<double>();
			num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
			num2 = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
			text = _0023_003DzgPsOl1A_003D.Substring(num + 1, num2 - num - 1);
			while (text.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref text, ref _0023_003DzD5YCi2M_003D2);
				_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
				double item3 = Utility.DoubleParse(_0023_003DzD5YCi2M_003D2);
				_0023_003DzRQbiPKyhjGqRUyVh3g_003D_003D.Add(item3);
			}
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, num2 + 2);
			_0023_003Dz7LxcB2vamJ41WAN_0024_0024A_003D_003D = new List<double>();
			num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
			num2 = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
			text = _0023_003DzgPsOl1A_003D.Substring(num + 1, num2 - num - 1);
			while (text.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref text, ref _0023_003DzD5YCi2M_003D2);
				_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
				double item4 = Utility.DoubleParse(_0023_003DzD5YCi2M_003D2);
				_0023_003Dz7LxcB2vamJ41WAN_0024_0024A_003D_003D.Add(item4);
			}
			_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, num2 + 2);
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003Dz9FR3dZ9QR_0024CK = _0023_003DzD5YCi2M_003D;
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		{
			_0023_003DzTkPhA8X_2C3n = new List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>>();
			for (int i = 0; i < _0023_003Dzwo9YTP6d_00243jt.Count; i++)
			{
				List<int> list = _0023_003Dzwo9YTP6d_00243jt[i];
				List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> list2 = new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>();
				for (int j = 0; j < list.Count; j++)
				{
					int _0023_003DzoiYtBx0_003D = list[j];
					_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu item = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzoiYtBx0_003D, _0023_003Dz9UNAzE0_003D) as _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu;
					list2.Add(item);
				}
				_0023_003DzTkPhA8X_2C3n.Add(list2);
			}
			if (_0023_003DzTkPhA8X_2C3n.Count > 0)
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

	internal int _0023_003DzcB9JyLA_003D(_0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		string text = Convert.ToString(_0023_003DzMNyEKNc_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962) + Convert.ToString(_0023_003Dzo_0024bBi0E_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962);
		string empty = string.Empty;
		List<List<int>> list = new List<List<int>>();
		int count = _0023_003DzTkPhA8X_2C3n.Count;
		int count2 = _0023_003DzTkPhA8X_2C3n[0].Count;
		for (int i = 0; i < count; i++)
		{
			List<int> list2 = new List<int>();
			for (int j = 0; j < count2; j++)
			{
				int item = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu._0023_003DzuXztUSYcR_Yh_0024879s0ykZ2A_003D(_0023_003DzTkPhA8X_2C3n[i][j]._0023_003Dzfj_WbJ59_mOa(), _0023_003DzmDt2hY3pmRst);
				list2.Add(item);
			}
			list.Add(list2);
		}
		string _0023_003DzTc9crIYGGlGB = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003Dz7NMyIYrENQxj(list, ref _0023_003DzTc9crIYGGlGB);
		empty += _0023_003DzTc9crIYGGlGB;
		string text2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302923836);
		string empty2 = string.Empty;
		empty2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302923794);
		string empty3 = string.Empty;
		empty3 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302923794);
		string empty4 = string.Empty;
		empty4 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302923794);
		string _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D = string.Empty;
		_0023_003DzCB_0024YP142o8MTStDhmQ_003D_003D(ref _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D);
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927623), ref _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D += text;
		_0023_003DznXG736c_003D += empty;
		_0023_003DznXG736c_003D += text2;
		_0023_003DznXG736c_003D += empty2;
		_0023_003DznXG736c_003D += empty3;
		_0023_003DznXG736c_003D += empty4;
		_0023_003DznXG736c_003D += _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D;
		_0023_003DznXG736c_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920352);
		_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
		return result;
	}

	private void _0023_003DzCB_0024YP142o8MTStDhmQ_003D_003D(ref string _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D)
	{
		List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D> _0023_003DzhTEa_00242LAPcQF = new List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D>();
		List<double> _0023_003DzXlrK7uHk5jWP = _0023_003Dz5ftQ4PPOVhb5xw1VYw_003D_003D();
		_0023_003Dz1ngJit_i3oIi(_0023_003DzXlrK7uHk5jWP, ref _0023_003DzhTEa_00242LAPcQF);
		List<int> list = new List<int>();
		List<double> list2 = new List<double>();
		foreach (_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D item in _0023_003DzhTEa_00242LAPcQF)
		{
			list2.Add(item._0023_003DzPzO_0024GUk_003D);
			list.Add(item._0023_003DzDWcHi0N1Oi3bm2_0024Ky__0024xo5I_003D);
		}
		string _0023_003Dz7sMlKVNgxyUH = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003DzfNF7_0024BJ0E8wF(list, ref _0023_003Dz7sMlKVNgxyUH);
		_0023_003Dz7sMlKVNgxyUH += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962);
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D += _0023_003Dz7sMlKVNgxyUH;
		List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D> _0023_003DzhTEa_00242LAPcQF2 = new List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D>();
		_0023_003DzXlrK7uHk5jWP = _0023_003Dz6PYJ9ArzPazRrnCH4A_003D_003D();
		_0023_003Dz1ngJit_i3oIi(_0023_003DzXlrK7uHk5jWP, ref _0023_003DzhTEa_00242LAPcQF2);
		List<int> list3 = new List<int>();
		List<double> list4 = new List<double>();
		foreach (_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D item2 in _0023_003DzhTEa_00242LAPcQF2)
		{
			list4.Add(item2._0023_003DzPzO_0024GUk_003D);
			list3.Add(item2._0023_003DzDWcHi0N1Oi3bm2_0024Ky__0024xo5I_003D);
		}
		string _0023_003Dz7sMlKVNgxyUH2 = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003DzfNF7_0024BJ0E8wF(list3, ref _0023_003Dz7sMlKVNgxyUH2);
		_0023_003Dz7sMlKVNgxyUH2 += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962);
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D += _0023_003Dz7sMlKVNgxyUH2;
		string _0023_003Dz7sMlKVNgxyUH3 = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003Dz_iBXQ9R5IhAq(list2, ref _0023_003Dz7sMlKVNgxyUH3);
		_0023_003Dz7sMlKVNgxyUH3 += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962);
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D += _0023_003Dz7sMlKVNgxyUH3;
		string _0023_003Dz7sMlKVNgxyUH4 = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003Dz_iBXQ9R5IhAq(list4, ref _0023_003Dz7sMlKVNgxyUH4);
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D += _0023_003Dz7sMlKVNgxyUH4;
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920970);
	}
}
