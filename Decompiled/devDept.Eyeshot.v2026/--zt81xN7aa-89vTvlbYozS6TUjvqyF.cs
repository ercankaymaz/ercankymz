using System;
using System.Text;

internal sealed class _0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF
{
	public static int _0023_003DzeW8irBmpZ6UG9EuJcQ_003D_003D(string _0023_003DzuwH5j5s_003D)
	{
		if (_0023_003DzuwH5j5s_003D == null)
		{
			return 0;
		}
		int num = _0023_003DzuwH5j5s_003D.Length;
		char c = ' ';
		int num2 = _0023_003DzuwH5j5s_003D.Length - 1;
		while (num2 > -1 && _0023_003DzuwH5j5s_003D[num2] == c)
		{
			num--;
			num2--;
		}
		return num;
	}

	public static int _0023_003DzeW8irBmpZ6UG9EuJcQ_003D_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dz241G5c8_003D)
	{
		return _0023_003Dz241G5c8_003D._0023_003DzzPy760Jv2_2e();
	}

	public static string _0023_003Dz_0024DSpNWgKtC2U(string _0023_003DzuwH5j5s_003D, int _0023_003Dz4A4IlCndC25r)
	{
		string empty = string.Empty;
		if (string.IsNullOrEmpty(_0023_003DzuwH5j5s_003D) || _0023_003Dz4A4IlCndC25r < 1)
		{
			return empty;
		}
		StringBuilder stringBuilder = new StringBuilder(_0023_003DzuwH5j5s_003D.Length * _0023_003Dz4A4IlCndC25r);
		for (int i = 0; i < _0023_003Dz4A4IlCndC25r; i++)
		{
			stringBuilder.Append(_0023_003DzuwH5j5s_003D);
		}
		return stringBuilder.ToString();
	}

	public static int _0023_003DzE4Ox648_003D(int _0023_003DzH8_0024G110_003D, int _0023_003DzN9y2G9c_003D)
	{
		if (_0023_003DzN9y2G9c_003D >= 0)
		{
			return Math.Abs(_0023_003DzH8_0024G110_003D);
		}
		return -Math.Abs(_0023_003DzH8_0024G110_003D);
	}

	public static float _0023_003DzE4Ox648_003D(float _0023_003DzH8_0024G110_003D, float _0023_003DzN9y2G9c_003D)
	{
		if (_0023_003DzN9y2G9c_003D >= 0f)
		{
			return Math.Abs(_0023_003DzH8_0024G110_003D);
		}
		return 0f - Math.Abs(_0023_003DzH8_0024G110_003D);
	}

	public static double _0023_003DzE4Ox648_003D(double _0023_003DzH8_0024G110_003D, double _0023_003DzN9y2G9c_003D)
	{
		if (_0023_003DzN9y2G9c_003D >= 0.0)
		{
			return Math.Abs(_0023_003DzH8_0024G110_003D);
		}
		return 0.0 - Math.Abs(_0023_003DzH8_0024G110_003D);
	}

	public static int _0023_003Dz4vcHOP8_003D(int _0023_003DzH8_0024G110_003D, int _0023_003DzN9y2G9c_003D)
	{
		return _0023_003DzH8_0024G110_003D - _0023_003DzN9y2G9c_003D * (_0023_003DzH8_0024G110_003D / _0023_003DzN9y2G9c_003D);
	}

	public static float _0023_003Dz3WM0XiY_003D(float _0023_003DzH8_0024G110_003D, float _0023_003DzN9y2G9c_003D)
	{
		return _0023_003DzH8_0024G110_003D - _0023_003DzN9y2G9c_003D * Convert.ToSingle(Math.Truncate(_0023_003DzH8_0024G110_003D / _0023_003DzN9y2G9c_003D));
	}

	public static double _0023_003Dz4vjeg6g_003D(double _0023_003DzH8_0024G110_003D, double _0023_003DzN9y2G9c_003D)
	{
		return _0023_003DzH8_0024G110_003D - _0023_003DzN9y2G9c_003D * Math.Truncate(_0023_003DzH8_0024G110_003D / _0023_003DzN9y2G9c_003D);
	}

	public static int _0023_003Dz_0024x71IRirKf7t(string _0023_003DzuwH5j5s_003D, string _0023_003DzOnQC6_0024o_003D, bool _0023_003Dzw0AXpOM_003D)
	{
		int num = -1;
		if (!_0023_003Dzw0AXpOM_003D)
		{
			num = _0023_003DzuwH5j5s_003D.IndexOfAny(_0023_003DzOnQC6_0024o_003D.ToCharArray());
		}
		else
		{
			char[] array = _0023_003DzuwH5j5s_003D.ToCharArray();
			Array.Reverse(array);
			int num2 = new string(array).IndexOfAny(_0023_003DzOnQC6_0024o_003D.ToCharArray());
			if (num2 != -1)
			{
				num = _0023_003DzuwH5j5s_003D.Length - num2 - 1;
			}
		}
		return num + 1;
	}

	public static int _0023_003Dz_0024x71IRirKf7t(string _0023_003DzuwH5j5s_003D, string _0023_003DzOnQC6_0024o_003D)
	{
		return _0023_003Dz_0024x71IRirKf7t(_0023_003DzuwH5j5s_003D, _0023_003DzOnQC6_0024o_003D, _0023_003Dzw0AXpOM_003D: false);
	}

	public static int _0023_003Dz_0024x71IRirKf7t(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzfGY1riY_003D, string _0023_003DzOnQC6_0024o_003D, bool _0023_003Dzw0AXpOM_003D)
	{
		return _0023_003Dz_0024x71IRirKf7t(_0023_003DzfGY1riY_003D.ToString(), _0023_003DzOnQC6_0024o_003D, _0023_003Dzw0AXpOM_003D);
	}

	public static int _0023_003Dz_0024x71IRirKf7t(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzfGY1riY_003D, string _0023_003DzOnQC6_0024o_003D)
	{
		return _0023_003Dz_0024x71IRirKf7t(_0023_003DzfGY1riY_003D.ToString(), _0023_003DzOnQC6_0024o_003D);
	}

	public static int _0023_003Dz_0024MGVtQk_003D(string _0023_003DzuwH5j5s_003D, string _0023_003DzPzO_0024GUk_003D, bool _0023_003Dzw0AXpOM_003D)
	{
		int num = -1;
		num = (_0023_003Dzw0AXpOM_003D ? _0023_003DzuwH5j5s_003D.LastIndexOf(_0023_003DzPzO_0024GUk_003D) : _0023_003DzuwH5j5s_003D.IndexOf(_0023_003DzPzO_0024GUk_003D));
		return num + 1;
	}

	public static int _0023_003Dz_0024MGVtQk_003D(string _0023_003DzuwH5j5s_003D, string _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003Dz_0024MGVtQk_003D(_0023_003DzuwH5j5s_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dzw0AXpOM_003D: false);
	}

	public static int _0023_003Dz_0024MGVtQk_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dz241G5c8_003D, string _0023_003DzPzO_0024GUk_003D, bool _0023_003Dzw0AXpOM_003D)
	{
		return _0023_003Dz_0024MGVtQk_003D(_0023_003Dz241G5c8_003D.ToString(), _0023_003DzPzO_0024GUk_003D, _0023_003Dzw0AXpOM_003D);
	}

	public static int _0023_003Dz_0024MGVtQk_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dz241G5c8_003D, string _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003Dz_0024MGVtQk_003D(_0023_003Dz241G5c8_003D.ToString(), _0023_003DzPzO_0024GUk_003D, _0023_003Dzw0AXpOM_003D: false);
	}

	public static int _0023_003Dz_0024MGVtQk_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dz241G5c8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzPzO_0024GUk_003D, bool _0023_003Dzw0AXpOM_003D)
	{
		return _0023_003Dz_0024MGVtQk_003D(_0023_003Dz241G5c8_003D.ToString(), _0023_003DzPzO_0024GUk_003D.ToString(), _0023_003Dzw0AXpOM_003D);
	}

	public static int _0023_003Dz_0024MGVtQk_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dz241G5c8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003Dz_0024MGVtQk_003D(_0023_003Dz241G5c8_003D.ToString(), _0023_003DzPzO_0024GUk_003D.ToString());
	}

	public static string _0023_003Dzi7Gvi5zc29PS(string _0023_003DzuwH5j5s_003D)
	{
		StringBuilder stringBuilder = new StringBuilder(_0023_003DzuwH5j5s_003D.Length);
		stringBuilder.Append(_0023_003DzuwH5j5s_003D.TrimStart());
		string value = new string(' ', _0023_003DzuwH5j5s_003D.Length - stringBuilder.Length);
		stringBuilder.Append(value);
		return stringBuilder.ToString();
	}

	public string _0023_003DzoUvDWJHkKOmW(string _0023_003DzuwH5j5s_003D)
	{
		StringBuilder stringBuilder = new StringBuilder(_0023_003DzuwH5j5s_003D.Length);
		stringBuilder.Append(_0023_003DzuwH5j5s_003D.TrimEnd());
		string value = new string(' ', _0023_003DzuwH5j5s_003D.Length - stringBuilder.Length);
		stringBuilder.Insert(0, value);
		return stringBuilder.ToString();
	}

	public static string _0023_003DzsChJCuM_003D(string _0023_003DzuwH5j5s_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D)
	{
		_0023_003DzAddCv_o_003D--;
		_0023_003Dz6qhgM4o_003D--;
		int length = _0023_003Dz6qhgM4o_003D - _0023_003DzAddCv_o_003D + 1;
		return _0023_003DzuwH5j5s_003D.Substring(_0023_003DzAddCv_o_003D, length);
	}

	public static string _0023_003DzsChJCuM_003D(string _0023_003DzuwH5j5s_003D, int _0023_003DzAddCv_o_003D)
	{
		return _0023_003DzsChJCuM_003D(_0023_003DzuwH5j5s_003D, _0023_003DzAddCv_o_003D, _0023_003DzuwH5j5s_003D.Length);
	}

	public static void _0023_003DztmyULho_003D(ref string _0023_003DzYtbUXI8_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D, string _0023_003Dzu7yF9Qk_003D)
	{
		char[] array = _0023_003DzYtbUXI8_003D.ToCharArray();
		_0023_003DztmyULho_003D(array, _0023_003DzAddCv_o_003D, _0023_003Dz6qhgM4o_003D, _0023_003Dzu7yF9Qk_003D.ToCharArray());
		_0023_003DzYtbUXI8_003D = new string(array);
	}

	public static void _0023_003DztmyULho_003D(ref string _0023_003DzYtbUXI8_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D, char _0023_003Dzb7SPTpc_003D)
	{
		if (_0023_003DzAddCv_o_003D != _0023_003Dz6qhgM4o_003D)
		{
			new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302916046));
		}
		_0023_003DztmyULho_003D(ref _0023_003DzYtbUXI8_003D, _0023_003DzAddCv_o_003D, _0023_003Dz6qhgM4o_003D, _0023_003Dzb7SPTpc_003D.ToString());
	}

	public static void _0023_003DztmyULho_003D(ref string _0023_003DzYtbUXI8_003D, int _0023_003DzAddCv_o_003D, string _0023_003Dzu7yF9Qk_003D)
	{
		int _0023_003Dz6qhgM4o_003D = Math.Min(_0023_003DzYtbUXI8_003D.Length, _0023_003Dzu7yF9Qk_003D.Length);
		_0023_003DztmyULho_003D(ref _0023_003DzYtbUXI8_003D, _0023_003DzAddCv_o_003D, _0023_003Dz6qhgM4o_003D, _0023_003Dzu7yF9Qk_003D);
	}

	public static void _0023_003DztmyULho_003D(ref string _0023_003DzYtbUXI8_003D, string _0023_003Dzu7yF9Qk_003D)
	{
		_0023_003DztmyULho_003D(ref _0023_003DzYtbUXI8_003D, 1, _0023_003Dzu7yF9Qk_003D);
	}

	public static char[] _0023_003DzsChJCuM_003D(char[] _0023_003DzuwH5j5s_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D)
	{
		char[] array = new char[_0023_003Dz6qhgM4o_003D - _0023_003DzAddCv_o_003D + 1];
		_0023_003DzAddCv_o_003D--;
		_0023_003Dz6qhgM4o_003D--;
		for (int i = _0023_003DzAddCv_o_003D; i < _0023_003Dz6qhgM4o_003D; i++)
		{
			array[i - _0023_003DzAddCv_o_003D] = _0023_003DzuwH5j5s_003D[i];
		}
		return array;
	}

	public static char[] _0023_003DzsChJCuM_003D(char[] _0023_003DzuwH5j5s_003D, int _0023_003DzAddCv_o_003D)
	{
		return _0023_003DzsChJCuM_003D(_0023_003DzuwH5j5s_003D, _0023_003DzAddCv_o_003D, _0023_003DzuwH5j5s_003D.Length);
	}

	public static void _0023_003DztmyULho_003D(char[] _0023_003DzoYZIBIk_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D, char[] _0023_003Dz6BeAw9c_003D)
	{
		_0023_003DzAddCv_o_003D--;
		int val = _0023_003Dz6qhgM4o_003D - _0023_003DzAddCv_o_003D;
		val = Math.Min(val, _0023_003Dz6BeAw9c_003D.Length);
		val = Math.Min(val, _0023_003DzoYZIBIk_003D.Length - _0023_003DzAddCv_o_003D);
		for (int i = 0; i < val; i++)
		{
			_0023_003DzoYZIBIk_003D[i + _0023_003DzAddCv_o_003D] = _0023_003Dz6BeAw9c_003D[i];
		}
	}

	public static void _0023_003DztmyULho_003D(char[] _0023_003DzoYZIBIk_003D, int _0023_003DzAddCv_o_003D, char[] _0023_003Dz6BeAw9c_003D)
	{
		_0023_003DztmyULho_003D(_0023_003DzoYZIBIk_003D, _0023_003DzAddCv_o_003D, _0023_003DzoYZIBIk_003D.Length, _0023_003Dz6BeAw9c_003D);
	}

	public static void _0023_003DztmyULho_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzb7SPTpc_003D)
	{
		_0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzAddCv_o_003D, _0023_003Dz6qhgM4o_003D, _0023_003Dzb7SPTpc_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static void _0023_003DztmyULho_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, int _0023_003DzAddCv_o_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzb7SPTpc_003D)
	{
		_0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzAddCv_o_003D, _0023_003Dzb7SPTpc_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static void _0023_003DztmyULho_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzb7SPTpc_003D)
	{
		_0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D._0023_003Dz5OSfJ_0024_nqiJX(), 1, _0023_003Dzb7SPTpc_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static void _0023_003DztmyULho_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D, string _0023_003Dzb7SPTpc_003D)
	{
		_0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzAddCv_o_003D, _0023_003Dz6qhgM4o_003D, _0023_003Dzb7SPTpc_003D.ToCharArray());
	}

	public static void _0023_003DztmyULho_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, int _0023_003DzAddCv_o_003D, string _0023_003Dzb7SPTpc_003D)
	{
		_0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzAddCv_o_003D, _0023_003Dzb7SPTpc_003D.ToCharArray());
	}

	public static void _0023_003DztmyULho_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, string _0023_003Dzb7SPTpc_003D)
	{
		_0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D._0023_003Dz5OSfJ_0024_nqiJX(), 1, _0023_003Dzb7SPTpc_003D.ToCharArray());
	}
}
