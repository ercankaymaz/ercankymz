internal static class _0023_003DzTzQEWh4_003D
{
	private static string _0023_003DzJJuhRFc_003D;

	private static int _0023_003DzylgAmzyK2nyc;

	public static string _0023_003DzrvJrkEcmo0d2(string _0023_003Dzu7yF9Qk_003D, int _0023_003DzwP4ywwY_003D, char _0023_003DzDXzLkFc_003D)
	{
		return ((_0023_003DzwP4ywwY_003D > 0) ? _0023_003Dzu7yF9Qk_003D.Substring(0, _0023_003DzwP4ywwY_003D) : string.Empty) + _0023_003DzDXzLkFc_003D + ((_0023_003DzwP4ywwY_003D < _0023_003Dzu7yF9Qk_003D.Length - 1) ? _0023_003Dzu7yF9Qk_003D.Substring(_0023_003DzwP4ywwY_003D + 1) : string.Empty);
	}

	public static bool _0023_003DzO3MaJxDy4iuw(char _0023_003Dz6itnqSU_003D)
	{
		if (char.IsDigit(_0023_003Dz6itnqSU_003D))
		{
			return true;
		}
		if (_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302932096).IndexOf(_0023_003Dz6itnqSU_003D) > -1)
		{
			return true;
		}
		return false;
	}

	public static string _0023_003DzgPOsV8fPIfAu(string _0023_003DzWE2NcgOmt8CM, char _0023_003Dz_0024cbBdfs58heE)
	{
		int num = _0023_003DzWE2NcgOmt8CM.IndexOf(_0023_003Dz_0024cbBdfs58heE);
		if (num > -1)
		{
			return _0023_003DzWE2NcgOmt8CM.Substring(num);
		}
		return null;
	}

	public static string _0023_003Dz5hAJLoeJ1SDL(string _0023_003DzWE2NcgOmt8CM, char _0023_003Dz_0024cbBdfs58heE)
	{
		int num = _0023_003DzWE2NcgOmt8CM.LastIndexOf(_0023_003Dz_0024cbBdfs58heE);
		if (num > -1)
		{
			return _0023_003DzWE2NcgOmt8CM.Substring(num);
		}
		return null;
	}

	public static string _0023_003DzMZ13WxQYa1UG(string _0023_003DzWE2NcgOmt8CM, string _0023_003DzlRDqGjKtT9_0024X)
	{
		int num = _0023_003DzWE2NcgOmt8CM.IndexOf(_0023_003DzlRDqGjKtT9_0024X);
		if (num > -1)
		{
			return _0023_003DzWE2NcgOmt8CM.Substring(num);
		}
		return null;
	}

	public static string _0023_003DzFfFrHBwl1waw(string _0023_003DzgpUqWBkDMD39, string _0023_003DzNZ_0024EYhAyZAIM7pJ_00241w_003D_003D)
	{
		if (_0023_003DzgpUqWBkDMD39 != null)
		{
			_0023_003DzJJuhRFc_003D = _0023_003DzgpUqWBkDMD39;
			_0023_003DzylgAmzyK2nyc = -1;
		}
		if (_0023_003DzJJuhRFc_003D == null)
		{
			return null;
		}
		if (_0023_003DzylgAmzyK2nyc == _0023_003DzJJuhRFc_003D.Length)
		{
			return null;
		}
		_0023_003DzylgAmzyK2nyc++;
		while (_0023_003DzylgAmzyK2nyc < _0023_003DzJJuhRFc_003D.Length && _0023_003DzNZ_0024EYhAyZAIM7pJ_00241w_003D_003D.IndexOf(_0023_003DzJJuhRFc_003D[_0023_003DzylgAmzyK2nyc]) > -1)
		{
			_0023_003DzylgAmzyK2nyc++;
		}
		if (_0023_003DzylgAmzyK2nyc == _0023_003DzJJuhRFc_003D.Length)
		{
			return null;
		}
		int num = _0023_003DzylgAmzyK2nyc;
		do
		{
			_0023_003DzylgAmzyK2nyc++;
		}
		while (_0023_003DzylgAmzyK2nyc < _0023_003DzJJuhRFc_003D.Length && _0023_003DzNZ_0024EYhAyZAIM7pJ_00241w_003D_003D.IndexOf(_0023_003DzJJuhRFc_003D[_0023_003DzylgAmzyK2nyc]) == -1);
		return _0023_003DzJJuhRFc_003D.Substring(num, _0023_003DzylgAmzyK2nyc - num);
	}
}
