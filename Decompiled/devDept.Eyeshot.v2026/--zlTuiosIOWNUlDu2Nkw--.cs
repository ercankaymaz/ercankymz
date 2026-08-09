using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using devDept.Geometry;

internal sealed class _0023_003DzlTuiosIOWNUlDu2Nkw_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	internal enum _0023_003Dz60nKVXZRHrmUmllhR3Ad_28_003D
	{

	}

	private _0023_003Dz60nKVXZRHrmUmllhR3Ad_28_003D _0023_003DzJ6_0024AAD8gNwCxFlTV9N1G300_003D;

	private string _0023_003DzzZz_HCgOu4TIbo8lxQ_003D_003D;

	private string _0023_003DziG0XwjXiiRBtCquTsWzgm5Q_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919710);

	private string _0023_003Dzpwe0jpIFz6WvWlfFxQXohFA_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302918151);

	private string _0023_003DzYAHaNqa2qyggusSpoAb4C4zmvWzc74EpLg_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302916820);

	private string _0023_003DzHhMtZvhXx7nBs7ZULjnEiYaJh1q4gQkdOg_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919921);

	private string _0023_003DzjqLdfv3cO5UmFV0v00UrM_002472uKON = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919919);

	private string _0023_003Dz_6sEKknfIq2eMutMp2Pe_0024zJmWjk6 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302918238);

	private int _0023_003DzU7eDCS_XZhhv;

	private List<double> _0023_003Dzr7tgnwG7XK6N;

	private List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> _0023_003DzTkPhA8X_2C3n;

	internal List<double> _0023_003DzCku_002453QjDvjT;

	private List<int> _0023_003Dzwo9YTP6d_00243jt;

	private List<int> _0023_003DzP_pKGt1u_00245yI62FXqGNBBzCeJssJ;

	private string _0023_003Dz9FR3dZ9QR_0024CK;

	private bool _0023_003DzD_D1VcrhgOOvi2Gquw_003D_003D;

	private bool _0023_003Dzy4Vz_mQ6Ay_7;

	internal int _0023_003Dz1bXverEEKoAG;

	internal _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003Dz1XT8oSBP1okG;

	internal List<int> _0023_003DzCmMXRrZv7WPEVtxMcr7W6Zo_003D;

	internal List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzZdVMPLLyTc368DDKmQ_003D_003D;

	internal _0023_003DzlTuiosIOWNUlDu2Nkw_003D_003D()
	{
	}

	public _0023_003DzlTuiosIOWNUlDu2Nkw_003D_003D(int _0023_003DzbU0rLpQ_003D, List<double> _0023_003Dzr7tgnwG7XK6N, List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> _0023_003DzpDQeEMI7yWiW)
	{
		_0023_003DzU7eDCS_XZhhv = _0023_003DzbU0rLpQ_003D;
		_0023_003DzTkPhA8X_2C3n = new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>();
		foreach (_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D item in _0023_003DzpDQeEMI7yWiW)
		{
			_0023_003DzTkPhA8X_2C3n.Add(new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(item._0023_003Dzfj_WbJ59_mOa()));
			_0023_003DzemnQes38Znyn(_0023_003DzpDQeEMI7yWiW);
		}
		_0023_003DzGv_0024dJm__0024mfG8qTLNxA_003D_003D(_0023_003Dzr7tgnwG7XK6N);
	}

	internal _0023_003DzlTuiosIOWNUlDu2Nkw_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302916345), _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzU7eDCS_XZhhv = -1;
		_0023_003Dzwo9YTP6d_00243jt = null;
		_0023_003DzP_pKGt1u_00245yI62FXqGNBBzCeJssJ = null;
		_0023_003Dzr7tgnwG7XK6N = null;
		_0023_003DzTkPhA8X_2C3n = null;
		_0023_003DzCku_002453QjDvjT = null;
		_0023_003DzD_D1VcrhgOOvi2Gquw_003D_003D = false;
		_0023_003Dzy4Vz_mQ6Ay_7 = false;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	internal _0023_003Dz60nKVXZRHrmUmllhR3Ad_28_003D _0023_003DzULkNx9eyeEcWQQGzYw_003D_003D()
	{
		return _0023_003DzJ6_0024AAD8gNwCxFlTV9N1G300_003D;
	}

	internal void _0023_003DzgEwTXmYHzoVoIr3B_A_003D_003D(_0023_003Dz60nKVXZRHrmUmllhR3Ad_28_003D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzJ6_0024AAD8gNwCxFlTV9N1G300_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003Dzrxn048_SPofRl5_0024BXA_003D_003D()
	{
		return _0023_003DzD_D1VcrhgOOvi2Gquw_003D_003D;
	}

	public string _0023_003DzAGBrXxaBnC0H()
	{
		return _0023_003DzzZz_HCgOu4TIbo8lxQ_003D_003D;
	}

	public void _0023_003DzB5YP3O2dV44D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzzZz_HCgOu4TIbo8lxQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> _0023_003DzinGuj5Boveem()
	{
		return _0023_003DzTkPhA8X_2C3n;
	}

	internal List<double> _0023_003DzjCHGVKpw2wFY()
	{
		List<double> list = new List<double>();
		for (int i = 0; i < _0023_003Dzr7tgnwG7XK6N.Count; i++)
		{
			double item = _0023_003Dzr7tgnwG7XK6N[i];
			int num = _0023_003DzP_pKGt1u_00245yI62FXqGNBBzCeJssJ[i];
			for (int j = 1; j <= num; j++)
			{
				list.Add(item);
			}
		}
		return list;
	}

	internal int _0023_003DzY6A_5BDYyyq7()
	{
		return _0023_003DzU7eDCS_XZhhv;
	}

	private void _0023_003DzcYJKSuhMNUf1(bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		if (_0023_003Dzm4CSmX5Y3o6Q)
		{
			_0023_003DziG0XwjXiiRBtCquTsWzgm5Q_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919881);
			_0023_003Dzpwe0jpIFz6WvWlfFxQXohFA_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919861);
			_0023_003DzYAHaNqa2qyggusSpoAb4C4zmvWzc74EpLg_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919844);
			_0023_003DzHhMtZvhXx7nBs7ZULjnEiYaJh1q4gQkdOg_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919856);
			_0023_003DzjqLdfv3cO5UmFV0v00UrM_002472uKON = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919833);
			_0023_003Dz_6sEKknfIq2eMutMp2Pe_0024zJmWjk6 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919816);
		}
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		int result = -1;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			_0023_003DzcYJKSuhMNUf1(_0023_003Dzm4CSmX5Y3o6Q);
			string text = _0023_003DziHtkvmE_003D;
			string text2 = _0023_003DziG0XwjXiiRBtCquTsWzgm5Q_003D;
			int num = text.IndexOf(text2);
			if (num != -1)
			{
				text = text.Remove(0, num);
				text = text.Remove(0, text2.Length);
			}
			else
			{
				text2 = _0023_003Dzpwe0jpIFz6WvWlfFxQXohFA_003D;
				num = text.IndexOf(text2);
				text = text.Remove(0, num);
			}
			text2 = _0023_003DzYAHaNqa2qyggusSpoAb4C4zmvWzc74EpLg_003D_003D;
			if (text.Contains(text2))
			{
				_0023_003DzgEwTXmYHzoVoIr3B_A_003D_003D((_0023_003Dz60nKVXZRHrmUmllhR3Ad_28_003D)1);
				num = text.IndexOf(text2);
				if (num > 0)
				{
					string _0023_003DziPvQmkPUf2xd = text.Substring(0, num);
					text = text.Remove(0, num + text2.Length);
					text2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920563);
					string _0023_003DziPvQmkPUf2xd2 = text[..text.IndexOf(text2)];
					text2 = _0023_003DzHhMtZvhXx7nBs7ZULjnEiYaJh1q4gQkdOg_003D_003D;
					num = text.IndexOf(text2);
					text = text.Remove(0, num + text2.Length);
					num = text.IndexOf(_0023_003DzjqLdfv3cO5UmFV0v00UrM_002472uKON);
					string _0023_003DziPvQmkPUf2xd3 = ((num == -1) ? text : text.Substring(0, num));
					_0023_003DziPvQmkPUf2xd = _0023_003Dz0cCjg9B5UMsA._0023_003DzAnJmIq4_003D(_0023_003DziPvQmkPUf2xd);
					_0023_003DziPvQmkPUf2xd2 = _0023_003Dz0cCjg9B5UMsA._0023_003DzAnJmIq4_003D(_0023_003DziPvQmkPUf2xd2);
					_0023_003DziPvQmkPUf2xd3 = _0023_003Dz0cCjg9B5UMsA._0023_003DzAnJmIq4_003D(_0023_003DziPvQmkPUf2xd3);
					string _0023_003DzD5YCi2M_003D = string.Empty;
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd, ref _0023_003DzD5YCi2M_003D);
					int.TryParse(_0023_003DzD5YCi2M_003D, out var result2);
					_0023_003DzU7eDCS_XZhhv = result2;
					int num2 = _0023_003DziPvQmkPUf2xd.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
					int num3 = _0023_003DziPvQmkPUf2xd.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
					_0023_003Dzwo9YTP6d_00243jt = new List<int>();
					string _0023_003DzgPsOl1A_003D = _0023_003DziPvQmkPUf2xd.Substring(num2 + 1, num3 - num2 - 1);
					string _0023_003DzD5YCi2M_003D2 = string.Empty;
					while (_0023_003DzgPsOl1A_003D.Length > 0)
					{
						_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D2);
						_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
						_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Remove(0, 1);
						int item3 = ((!int.TryParse(_0023_003DzD5YCi2M_003D2, out result)) ? (-1) : result);
						_0023_003Dzwo9YTP6d_00243jt.Add(item3);
					}
					_0023_003DziPvQmkPUf2xd = _0023_003DziPvQmkPUf2xd.Remove(0, num3 + 1);
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd, ref _0023_003DzD5YCi2M_003D);
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd, ref _0023_003DzD5YCi2M_003D);
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd, ref _0023_003DzD5YCi2M_003D);
					_0023_003DzP_pKGt1u_00245yI62FXqGNBBzCeJssJ = new List<int>();
					num2 = _0023_003DziPvQmkPUf2xd2.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
					num3 = _0023_003DziPvQmkPUf2xd2.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
					_0023_003DzgPsOl1A_003D = _0023_003DziPvQmkPUf2xd2.Substring(num2 + 1, num3 - num2 - 1);
					while (_0023_003DzgPsOl1A_003D.Length > 0)
					{
						_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D2);
						_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
						int.TryParse(_0023_003DzD5YCi2M_003D2, out result);
						_0023_003DzP_pKGt1u_00245yI62FXqGNBBzCeJssJ.Add(result);
					}
					_0023_003DziPvQmkPUf2xd2 = _0023_003DziPvQmkPUf2xd2.Remove(0, num3 + 1);
					_0023_003Dzr7tgnwG7XK6N = new List<double>();
					num2 = _0023_003DziPvQmkPUf2xd2.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
					num3 = _0023_003DziPvQmkPUf2xd2.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
					_0023_003DzgPsOl1A_003D = _0023_003DziPvQmkPUf2xd2.Substring(num2 + 1, num3 - num2 - 1);
					while (_0023_003DzgPsOl1A_003D.Length > 0)
					{
						_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D2);
						_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
						double item4 = Utility.DoubleParse(_0023_003DzD5YCi2M_003D2);
						_0023_003Dzr7tgnwG7XK6N.Add(item4);
					}
					_0023_003DziPvQmkPUf2xd2 = _0023_003DziPvQmkPUf2xd2.Remove(0, num3 + 1);
					result2 = _0023_003DziPvQmkPUf2xd2.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
					_0023_003DzD5YCi2M_003D = _0023_003DziPvQmkPUf2xd2.Substring(result2);
					_0023_003Dz9FR3dZ9QR_0024CK = _0023_003DzD5YCi2M_003D;
					_0023_003DzCku_002453QjDvjT = new List<double>();
					num2 = _0023_003DziPvQmkPUf2xd3.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
					num3 = _0023_003DziPvQmkPUf2xd3.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
					_0023_003DzgPsOl1A_003D = _0023_003DziPvQmkPUf2xd3.Substring(num2 + 1, num3 - num2 - 1);
					while (_0023_003DzgPsOl1A_003D.Length > 0)
					{
						_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D2);
						_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
						double item5 = Utility.DoubleParse(_0023_003DzD5YCi2M_003D2);
						_0023_003DzCku_002453QjDvjT.Add(item5);
					}
					_0023_003DzpXqcGaz7sKJt = false;
					_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
				}
			}
			else if (text.Contains(_0023_003Dz_6sEKknfIq2eMutMp2Pe_0024zJmWjk6))
			{
				_0023_003DzD_D1VcrhgOOvi2Gquw_003D_003D = true;
				_0023_003DzgEwTXmYHzoVoIr3B_A_003D_003D((_0023_003Dz60nKVXZRHrmUmllhR3Ad_28_003D)2);
				text2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920563);
				num = text.IndexOf(text2);
				if (num > 0)
				{
					string _0023_003DziPvQmkPUf2xd4 = text.Substring(0, num);
					text = text.Remove(0, num + text2.Length);
					text2 = _0023_003Dz_6sEKknfIq2eMutMp2Pe_0024zJmWjk6;
					_ = text[..text.IndexOf(text2)];
					text2 = _0023_003DzHhMtZvhXx7nBs7ZULjnEiYaJh1q4gQkdOg_003D_003D;
					num = text.IndexOf(text2);
					text.Substring(0, num);
					text = text.Remove(0, num + text2.Length);
					string _0023_003DziPvQmkPUf2xd5 = text[..text.IndexOf(_0023_003DzjqLdfv3cO5UmFV0v00UrM_002472uKON)];
					_0023_003DziPvQmkPUf2xd4 = _0023_003Dz0cCjg9B5UMsA._0023_003DzAnJmIq4_003D(_0023_003DziPvQmkPUf2xd4);
					_0023_003DziPvQmkPUf2xd5 = _0023_003Dz0cCjg9B5UMsA._0023_003DzAnJmIq4_003D(_0023_003DziPvQmkPUf2xd5);
					string _0023_003DzD5YCi2M_003D3 = string.Empty;
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd4, ref _0023_003DzD5YCi2M_003D3);
					int.TryParse(_0023_003DzD5YCi2M_003D3, out var result3);
					_0023_003DzU7eDCS_XZhhv = result3;
					int num4 = _0023_003DziPvQmkPUf2xd4.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
					int num5 = _0023_003DziPvQmkPUf2xd4.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
					_0023_003Dzwo9YTP6d_00243jt = new List<int>();
					string _0023_003DzgPsOl1A_003D2 = _0023_003DziPvQmkPUf2xd4.Substring(num4 + 1, num5 - num4 - 1);
					string _0023_003DzD5YCi2M_003D4 = string.Empty;
					while (_0023_003DzgPsOl1A_003D2.Length > 0)
					{
						_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D2, ref _0023_003DzD5YCi2M_003D4);
						_0023_003DzD5YCi2M_003D4 = _0023_003DzD5YCi2M_003D4.Trim();
						_0023_003DzD5YCi2M_003D4 = _0023_003DzD5YCi2M_003D4.Remove(0, 1);
						int item6 = ((!int.TryParse(_0023_003DzD5YCi2M_003D4, out result)) ? (-1) : result);
						_0023_003Dzwo9YTP6d_00243jt.Add(item6);
					}
					_0023_003DziPvQmkPUf2xd4 = _0023_003DziPvQmkPUf2xd4.Remove(0, num5 + 1);
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd4, ref _0023_003DzD5YCi2M_003D3);
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd4, ref _0023_003DzD5YCi2M_003D3);
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DziPvQmkPUf2xd4, ref _0023_003DzD5YCi2M_003D3);
					_0023_003DzCku_002453QjDvjT = new List<double>();
					num4 = _0023_003DziPvQmkPUf2xd5.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
					num5 = _0023_003DziPvQmkPUf2xd5.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
					_0023_003DzgPsOl1A_003D2 = _0023_003DziPvQmkPUf2xd5.Substring(num4 + 1, num5 - num4 - 1);
					while (_0023_003DzgPsOl1A_003D2.Length > 0)
					{
						_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D2, ref _0023_003DzD5YCi2M_003D4);
						_0023_003DzD5YCi2M_003D4 = _0023_003DzD5YCi2M_003D4.Trim();
						double.TryParse(_0023_003DzD5YCi2M_003D4, NumberStyles.Float, CultureInfo.InvariantCulture, out var result4);
						_0023_003DzCku_002453QjDvjT.Add(result4);
					}
					_0023_003DzpXqcGaz7sKJt = false;
					_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
				}
			}
			else if (text.Contains(_0023_003Dzpwe0jpIFz6WvWlfFxQXohFA_003D))
			{
				_0023_003Dzy4Vz_mQ6Ay_7 = true;
				string _0023_003DzD5YCi2M_003D5 = string.Empty;
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref text, ref _0023_003DzD5YCi2M_003D5);
				int num6 = _0023_003DzD5YCi2M_003D5.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
				_0023_003DzD5YCi2M_003D5 = _0023_003DzD5YCi2M_003D5.Remove(0, num6 + 1);
				_0023_003DzD5YCi2M_003D5 = _0023_003DzD5YCi2M_003D5.Trim();
				_0023_003DzD5YCi2M_003D5 = _0023_003DzD5YCi2M_003D5.Remove(0, 1);
				int.TryParse(_0023_003DzD5YCi2M_003D5, out var result5);
				_0023_003Dz1bXverEEKoAG = result5;
				int num7 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083));
				int num8 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
				_0023_003DzCmMXRrZv7WPEVtxMcr7W6Zo_003D = new List<int>();
				string _0023_003DzgPsOl1A_003D3 = text.Substring(num7 + 1, num8 - num7 - 1);
				string _0023_003DzD5YCi2M_003D6 = string.Empty;
				int result6 = -1;
				while (_0023_003DzgPsOl1A_003D3.Length > 0)
				{
					_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D3, ref _0023_003DzD5YCi2M_003D6);
					_0023_003DzD5YCi2M_003D6 = _0023_003DzD5YCi2M_003D6.Trim();
					_0023_003DzD5YCi2M_003D6 = _0023_003DzD5YCi2M_003D6.Remove(0, 1);
					int item7 = ((!int.TryParse(_0023_003DzD5YCi2M_003D6, out result6)) ? (-1) : result6);
					_0023_003DzCmMXRrZv7WPEVtxMcr7W6Zo_003D.Add(item7);
				}
				_0023_003DzpXqcGaz7sKJt = false;
				_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			}
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		{
			_0023_003DzTkPhA8X_2C3n = new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>();
			if (_0023_003Dzwo9YTP6d_00243jt != null)
			{
				for (int i = 0; i < _0023_003Dzwo9YTP6d_00243jt.Count; i++)
				{
					result = _0023_003Dzwo9YTP6d_00243jt[i];
					_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu item = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(result, _0023_003Dz9UNAzE0_003D) as _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu;
					_0023_003DzTkPhA8X_2C3n.Add(item);
				}
				if (_0023_003DzTkPhA8X_2C3n.Count > 0 && _0023_003DzCku_002453QjDvjT.Count == _0023_003DzTkPhA8X_2C3n.Count)
				{
					_0023_003DzpXqcGaz7sKJt = true;
					_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
				}
				break;
			}
			_0023_003Dz1XT8oSBP1okG = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003Dz1bXverEEKoAG, _0023_003Dz9UNAzE0_003D);
			_0023_003DzZdVMPLLyTc368DDKmQ_003D_003D = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
			for (int j = 0; j < _0023_003DzCmMXRrZv7WPEVtxMcr7W6Zo_003D.Count; j++)
			{
				result = _0023_003DzCmMXRrZv7WPEVtxMcr7W6Zo_003D[j];
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item2 = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(result, _0023_003Dz9UNAzE0_003D);
				_0023_003DzZdVMPLLyTc368DDKmQ_003D_003D.Add(item2);
				if (_0023_003Dz1XT8oSBP1okG != null && _0023_003DzZdVMPLLyTc368DDKmQ_003D_003D != null)
				{
					_0023_003DzpXqcGaz7sKJt = true;
					_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
				}
			}
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2:
			_0023_003DzpXqcGaz7sKJt = true;
			break;
		}
	}

	private void _0023_003DzGv_0024dJm__0024mfG8qTLNxA_003D_003D(List<double> _0023_003Dzr7tgnwG7XK6N)
	{
		List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D> _0023_003DzhTEa_00242LAPcQF = new List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D>();
		_0023_003Dz1ngJit_i3oIi(_0023_003Dzr7tgnwG7XK6N, ref _0023_003DzhTEa_00242LAPcQF);
		List<int> list = new List<int>();
		List<double> list2 = new List<double>();
		foreach (_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D item in _0023_003DzhTEa_00242LAPcQF)
		{
			list2.Add(item._0023_003DzPzO_0024GUk_003D);
			list.Add(item._0023_003DzDWcHi0N1Oi3bm2_0024Ky__0024xo5I_003D);
		}
		this._0023_003Dzr7tgnwG7XK6N = list2;
		_0023_003DzP_pKGt1u_00245yI62FXqGNBBzCeJssJ = list;
	}

	private void _0023_003DzfmbScF0Xm5Od()
	{
		int count = _0023_003DzTkPhA8X_2C3n.Count;
		int count2 = _0023_003DzCku_002453QjDvjT.Count;
		if (count == count2)
		{
			for (int i = 0; i < count; i++)
			{
				_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2 = _0023_003DzTkPhA8X_2C3n[i];
				double num = _0023_003DzCku_002453QjDvjT[i];
				_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[0] = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[0] * num;
				_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[1] = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[1] * num;
				_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[2] = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[2] * num;
			}
		}
	}

	internal int _0023_003DzfdGSFjNSj9rq(_0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		string text = Convert.ToString(_0023_003DzU7eDCS_XZhhv);
		string _0023_003Dzi8wKtemSiam_ = string.Empty;
		_0023_003DzWWgvTfQ001Kh(ref _0023_003Dzi8wKtemSiam_, _0023_003DzmDt2hY3pmRst);
		string text2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920575);
		string empty = string.Empty;
		empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920531);
		string empty2 = string.Empty;
		empty2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920531);
		string _0023_003DznXG736c_003D = string.Empty;
		int _0023_003DzNTT6cfvhuweZ = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920541), ref _0023_003DznXG736c_003D);
		string empty3 = string.Empty;
		if (!_0023_003Dzrxn048_SPofRl5_0024BXA_003D_003D())
		{
			if (_0023_003Dzy4Vz_mQ6Ay_7)
			{
				int num = -1;
				string empty4 = string.Empty;
				if (_0023_003Dz1XT8oSBP1okG is _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2)
				{
					num = _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2._0023_003DzIRy9siWqErpc(_0023_003DzmDt2hY3pmRst);
				}
				List<int> list = new List<int>();
				foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item in _0023_003DzZdVMPLLyTc368DDKmQ_003D_003D)
				{
					_0023_003Dz9fO8BMouBiuNOQGMlA_003D_003D _0023_003Dz9fO8BMouBiuNOQGMlA_003D_003D2 = item as _0023_003Dz9fO8BMouBiuNOQGMlA_003D_003D;
					int num2 = 0;
					if (_0023_003Dz9fO8BMouBiuNOQGMlA_003D_003D2 != null)
					{
						num2 = _0023_003Dz9fO8BMouBiuNOQGMlA_003D_003D2._0023_003DzR1LbjFd_nhx_0024(_0023_003DzmDt2hY3pmRst);
						list.Add(num2);
					}
				}
				string _0023_003Dzf_00247a57H8L4S = string.Empty;
				_0023_003Dz0cCjg9B5UMsA._0023_003DzwjRq6xeLBWXe(list, ref _0023_003Dzf_00247a57H8L4S);
				string text3 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920502), num, _0023_003Dzf_00247a57H8L4S);
				empty4 = empty4 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920466) + text3;
				empty3 += empty4;
			}
			else
			{
				string _0023_003DzRWNRObVEfFli = string.Empty;
				_0023_003DzomK_a1cbdNDg(ref _0023_003DzRWNRObVEfFli);
				string _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D = string.Empty;
				_0023_003DzCB_0024YP142o8MTStDhmQ_003D_003D(ref _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D);
				empty3 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920645), text, _0023_003Dzi8wKtemSiam_, text2, empty, empty2, _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D, _0023_003DzRWNRObVEfFli);
			}
		}
		else
		{
			string _0023_003DzRWNRObVEfFli2 = string.Empty;
			_0023_003DzomK_a1cbdNDg(ref _0023_003DzRWNRObVEfFli2);
			empty3 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920232), text, _0023_003Dzi8wKtemSiam_, text2, empty, empty2, _0023_003DzRWNRObVEfFli2);
		}
		empty3 += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920352);
		_0023_003DznXG736c_003D += empty3;
		StreamWriter streamWriter = _0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc();
		streamWriter.WriteLine(_0023_003DznXG736c_003D);
		if (_0023_003DzAjEYCJs_003D)
		{
			int _0023_003Dz87CsieGRdQilf1A0GJXyb1w_003D = _0023_003DzcnHHIYcjnSGfdEcRuw_003D_003D._0023_003DztQhijao_003D(_0023_003Dzwtld1NM_003D, _0023_003DzmDt2hY3pmRst);
			int num3 = _0023_003DzLJa7lQY_003D(ref _0023_003Dz87CsieGRdQilf1A0GJXyb1w_003D, ref _0023_003DzNTT6cfvhuweZ, _0023_003DzmDt2hY3pmRst);
			string _0023_003DznXG736c_003D2 = string.Empty;
			string empty5 = string.Empty;
			_0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920327), ref _0023_003DznXG736c_003D2);
			empty5 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921034), num3, -1);
			_0023_003DznXG736c_003D2 += empty5;
			_0023_003DznXG736c_003D2 += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920352);
			streamWriter.WriteLine(_0023_003DznXG736c_003D2);
		}
		return _0023_003DzNTT6cfvhuweZ;
	}

	private int _0023_003DzLJa7lQY_003D(ref int _0023_003Dz87CsieGRdQilf1A0GJXyb1w_003D, ref int _0023_003DzNTT6cfvhuweZ, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		StreamWriter streamWriter = _0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc();
		if (streamWriter == null)
		{
			return 0;
		}
		string empty = string.Empty;
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921018), ref _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D = string.Concat(str1: string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921008), _0023_003Dz87CsieGRdQilf1A0GJXyb1w_003D, _0023_003DzNTT6cfvhuweZ), str0: _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920352);
		streamWriter.WriteLine(_0023_003DznXG736c_003D);
		return result;
	}

	private void _0023_003DzWWgvTfQ001Kh(ref string _0023_003Dzi8wKtemSiam_, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		List<int> list = new List<int>();
		int count = _0023_003DzTkPhA8X_2C3n.Count;
		for (int i = 0; i < count; i++)
		{
			int item = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu._0023_003DzuXztUSYcR_Yh_0024879s0ykZ2A_003D(_0023_003DzTkPhA8X_2C3n[i]._0023_003Dzfj_WbJ59_mOa(), _0023_003DzmDt2hY3pmRst);
			list.Add(item);
		}
		string _0023_003Dzf_00247a57H8L4S = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003DzwjRq6xeLBWXe(list, ref _0023_003Dzf_00247a57H8L4S);
		_0023_003Dzi8wKtemSiam_ += _0023_003Dzf_00247a57H8L4S;
	}

	private void _0023_003DzCB_0024YP142o8MTStDhmQ_003D_003D(ref string _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D)
	{
		List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D> _0023_003DzhTEa_00242LAPcQF = new List<_0023_003Dz9uFdeKnZNHjw0FfUVw_003D_003D>();
		List<double> _0023_003DzXlrK7uHk5jWP = _0023_003DzjCHGVKpw2wFY();
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
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D += _0023_003Dz7sMlKVNgxyUH;
		string _0023_003Dz7sMlKVNgxyUH2 = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003Dz_iBXQ9R5IhAq(list2, ref _0023_003Dz7sMlKVNgxyUH2);
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D = _0023_003DzyMeRYsgLaMZ9l8623w_003D_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962) + _0023_003Dz7sMlKVNgxyUH2;
		_0023_003DzyMeRYsgLaMZ9l8623w_003D_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920970);
	}

	private void _0023_003DzomK_a1cbdNDg(ref string _0023_003DzRWNRObVEfFli)
	{
		List<double> list = new List<double>();
		_ = _0023_003DzCku_002453QjDvjT.Count;
		foreach (double item in _0023_003DzCku_002453QjDvjT)
		{
			list.Add(item);
		}
		string _0023_003Dz7sMlKVNgxyUH = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003Dz_iBXQ9R5IhAq(list, ref _0023_003Dz7sMlKVNgxyUH);
		_0023_003DzRWNRObVEfFli += _0023_003Dz7sMlKVNgxyUH;
	}

	private void _0023_003DzemnQes38Znyn(List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> _0023_003DzpDQeEMI7yWiW)
	{
		_0023_003DzCku_002453QjDvjT = new List<double>();
		for (int i = 0; i < _0023_003DzpDQeEMI7yWiW.Count; i++)
		{
			double item = _0023_003DzpDQeEMI7yWiW[i]._0023_003Dzfj_WbJ59_mOa()[3];
			_0023_003DzCku_002453QjDvjT.Add(item);
		}
	}
}
