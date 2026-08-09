using System.Collections.Generic;

internal sealed class _0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private string _0023_003DzzZz_HCgOu4TIbo8lxQ_003D_003D;

	public List<int> _0023_003Dz6jhwFaVMbWdi;

	public List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> _0023_003DzsiUDYctF8XNnGONmwqa0jfM_003D;

	internal _0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003Dz6jhwFaVMbWdi = null;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public _0023_003DzPfV6UNqyPahF4KQLBInOsRQ_003D(List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> _0023_003DzdHCHoyE_RvDMKQOgUA_003D_003D)
	{
		_0023_003DzsiUDYctF8XNnGONmwqa0jfM_003D = new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>();
		foreach (_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu item in _0023_003DzdHCHoyE_RvDMKQOgUA_003D_003D)
		{
			_0023_003DzsiUDYctF8XNnGONmwqa0jfM_003D.Add(item);
		}
	}

	public string _0023_003DzAGBrXxaBnC0H()
	{
		return _0023_003DzzZz_HCgOu4TIbo8lxQ_003D_003D;
	}

	public void _0023_003DzB5YP3O2dV44D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzzZz_HCgOu4TIbo8lxQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
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
			_0023_003Dz6jhwFaVMbWdi = new List<int>();
			string _0023_003DzgPsOl1A_003D = text.Substring(num + 1, num2 - num - 1);
			string _0023_003DzD5YCi2M_003D = string.Empty;
			int _0023_003DzoiYtBx0_003D = -1;
			while (_0023_003DzgPsOl1A_003D.Length > 0)
			{
				_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
				_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
				int item2 = ((!int.TryParse(_0023_003DzD5YCi2M_003D, out _0023_003DzoiYtBx0_003D)) ? (-1) : _0023_003DzoiYtBx0_003D);
				_0023_003Dz6jhwFaVMbWdi.Add(item2);
			}
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		{
			_0023_003DzsiUDYctF8XNnGONmwqa0jfM_003D = new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>();
			for (int i = 0; i < _0023_003Dz6jhwFaVMbWdi.Count; i++)
			{
				int _0023_003DzoiYtBx0_003D = _0023_003Dz6jhwFaVMbWdi[i];
				_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu item = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzoiYtBx0_003D, _0023_003Dz9UNAzE0_003D) as _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu;
				_0023_003DzsiUDYctF8XNnGONmwqa0jfM_003D.Add(item);
			}
			if (_0023_003DzsiUDYctF8XNnGONmwqa0jfM_003D.Count > 0)
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

	public int _0023_003DzJaWt7Ru_M4jo(_0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		List<int> list = new List<int>();
		foreach (_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu item in _0023_003DzsiUDYctF8XNnGONmwqa0jfM_003D)
		{
			int num = 0;
			num = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu._0023_003DzuXztUSYcR_Yh_0024879s0ykZ2A_003D(item._0023_003Dzfj_WbJ59_mOa(), _0023_003DzmDt2hY3pmRst);
			list.Add(num);
		}
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921880), ref _0023_003DznXG736c_003D);
		string _0023_003Dzf_00247a57H8L4S = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003DzwjRq6xeLBWXe(list, ref _0023_003Dzf_00247a57H8L4S);
		_0023_003DznXG736c_003D += _0023_003Dzf_00247a57H8L4S;
		_0023_003DznXG736c_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920352);
		_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
		return result;
	}
}
