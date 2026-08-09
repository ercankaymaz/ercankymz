using System;

internal sealed class _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D
{
	private char[] _0023_003DzJZbLMmLxAegC = new char[0];

	public _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(int _0023_003Dz736ekIs_003D)
	{
		if (_0023_003Dz736ekIs_003D < 0)
		{
			_0023_003Dz736ekIs_003D = 0;
		}
		_0023_003DzJZbLMmLxAegC = new char[_0023_003Dz736ekIs_003D];
		for (int i = 0; i < _0023_003DzJZbLMmLxAegC.Length; i++)
		{
			_0023_003DzJZbLMmLxAegC[i] = ' ';
		}
	}

	public _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(char[] _0023_003DzJb5CEkbOkvb_0024, bool _0023_003Dzl_0024kBRC0_003D)
	{
		if (_0023_003DzJb5CEkbOkvb_0024 != null)
		{
			if (_0023_003Dzl_0024kBRC0_003D)
			{
				_0023_003DzJZbLMmLxAegC = new char[_0023_003DzJb5CEkbOkvb_0024.Length];
				Array.Copy(_0023_003DzJb5CEkbOkvb_0024, _0023_003DzJZbLMmLxAegC, _0023_003DzJZbLMmLxAegC.Length);
			}
			else
			{
				_0023_003DzJZbLMmLxAegC = _0023_003DzJb5CEkbOkvb_0024;
			}
		}
	}

	public _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(string _0023_003DzuwH5j5s_003D)
		: this(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003Dzl_0024kBRC0_003D: false)
	{
	}

	public _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(string _0023_003DzuwH5j5s_003D, int _0023_003Dz736ekIs_003D)
		: this(_0023_003Dz736ekIs_003D)
	{
		_0023_003DztmyULho_003D(_0023_003DzuwH5j5s_003D);
	}

	public char[] _0023_003Dz5OSfJ_0024_nqiJX()
	{
		return _0023_003DzJZbLMmLxAegC;
	}

	public int _0023_003Dz4m952JDFwKpj()
	{
		return _0023_003DzJZbLMmLxAegC.Length;
	}

	public void _0023_003DztmyULho_003D(int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D, char[] _0023_003DzkkRS4ExEWcNU)
	{
		if (_0023_003Dz6qhgM4o_003D > _0023_003Dz4m952JDFwKpj())
		{
			_0023_003Dz6qhgM4o_003D = _0023_003Dz4m952JDFwKpj();
		}
		int val = _0023_003Dz6qhgM4o_003D - _0023_003DzAddCv_o_003D + 1;
		val = Math.Min(val, _0023_003DzkkRS4ExEWcNU.Length);
		_0023_003DzAddCv_o_003D--;
		Array.Copy(_0023_003DzkkRS4ExEWcNU, 0, _0023_003DzJZbLMmLxAegC, _0023_003DzAddCv_o_003D, val);
	}

	public void _0023_003DztmyULho_003D(int _0023_003DzAddCv_o_003D, char[] _0023_003DzkkRS4ExEWcNU)
	{
		_0023_003DztmyULho_003D(_0023_003DzAddCv_o_003D, _0023_003Dz4m952JDFwKpj(), _0023_003DzkkRS4ExEWcNU);
	}

	public void _0023_003DztmyULho_003D(char[] _0023_003DzkkRS4ExEWcNU)
	{
		_0023_003DztmyULho_003D(1, _0023_003DzkkRS4ExEWcNU);
	}

	public void _0023_003DztmyULho_003D(int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D, string _0023_003Dzu7yF9Qk_003D)
	{
		_0023_003DztmyULho_003D(_0023_003DzAddCv_o_003D, _0023_003Dz6qhgM4o_003D, _0023_003Dzu7yF9Qk_003D.ToCharArray());
	}

	public void _0023_003DztmyULho_003D(int _0023_003DzAddCv_o_003D, string _0023_003Dzu7yF9Qk_003D)
	{
		_0023_003DztmyULho_003D(_0023_003DzAddCv_o_003D, _0023_003Dzu7yF9Qk_003D.ToCharArray());
	}

	public void _0023_003DztmyULho_003D(string _0023_003Dzu7yF9Qk_003D)
	{
		_0023_003DztmyULho_003D(_0023_003Dzu7yF9Qk_003D.ToCharArray());
	}

	public void _0023_003Dzq7V5WNk_003D(char[] _0023_003Dzb7SPTpc_003D)
	{
		_0023_003DzMCIyDkQObv7g();
		_0023_003DztmyULho_003D(_0023_003Dzb7SPTpc_003D);
	}

	public void _0023_003Dzq7V5WNk_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzb7SPTpc_003D)
	{
		_0023_003Dzq7V5WNk_003D(_0023_003Dzb7SPTpc_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public void _0023_003Dzq7V5WNk_003D(string _0023_003Dzb7SPTpc_003D)
	{
		_0023_003Dzq7V5WNk_003D(_0023_003Dzb7SPTpc_003D.ToCharArray());
	}

	public _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzsChJCuM_003D(int _0023_003DzAddCv_o_003D, int _0023_003Dz6qhgM4o_003D)
	{
		int num = _0023_003Dz6qhgM4o_003D - _0023_003DzAddCv_o_003D + 1;
		_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2 = new _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(num);
		_0023_003DzAddCv_o_003D--;
		Array.Copy(_0023_003DzJZbLMmLxAegC, _0023_003DzAddCv_o_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2._0023_003Dz5OSfJ_0024_nqiJX(), 0, num);
		return _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2;
	}

	public _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzsChJCuM_003D(int _0023_003DzAddCv_o_003D)
	{
		return _0023_003DzsChJCuM_003D(_0023_003DzAddCv_o_003D, _0023_003Dz4m952JDFwKpj());
	}

	public void _0023_003Dz3TO7OSA_003D()
	{
		for (int i = 0; i < _0023_003DzJZbLMmLxAegC.Length; i++)
		{
			_0023_003DzJZbLMmLxAegC[i] = char.ToUpper(_0023_003DzJZbLMmLxAegC[i]);
		}
	}

	public void _0023_003DzEk9ZQR8_003D()
	{
		for (int i = 0; i < _0023_003DzJZbLMmLxAegC.Length; i++)
		{
			_0023_003DzJZbLMmLxAegC[i] = char.ToLower(_0023_003DzJZbLMmLxAegC[i]);
		}
	}

	public void _0023_003DzMCIyDkQObv7g()
	{
		for (int i = 0; i < _0023_003DzJZbLMmLxAegC.Length; i++)
		{
			_0023_003DzJZbLMmLxAegC[i] = ' ';
		}
	}

	public void _0023_003DzMCIyDkQObv7g(int _0023_003DzAqOpw0w_003D, int _0023_003DzDr1MUxo_003D)
	{
		_0023_003DzAqOpw0w_003D--;
		int num = Math.Min(_0023_003DzDr1MUxo_003D, _0023_003DzJZbLMmLxAegC.Length);
		for (int i = _0023_003DzAqOpw0w_003D; i < num; i++)
		{
			_0023_003DzJZbLMmLxAegC[i] = ' ';
		}
	}

	public void _0023_003DzMCIyDkQObv7g(int _0023_003Dz736ekIs_003D)
	{
		_0023_003DzMCIyDkQObv7g(1, _0023_003Dz736ekIs_003D + 1);
	}

	public int _0023_003DzVozam8e35gss()
	{
		if (_0023_003DzzPy760Jv2_2e() == 0)
		{
			return 0;
		}
		return Convert.ToInt32(new string(_0023_003DzJZbLMmLxAegC));
	}

	public string _0023_003Dz6PsRlFc_003D()
	{
		return new string(_0023_003DzJZbLMmLxAegC).TrimEnd(' ');
	}

	public void _0023_003DzzwWR1xL3NS0N()
	{
		int num = 0;
		for (int i = 0; i < _0023_003DzJZbLMmLxAegC.Length && _0023_003DzJZbLMmLxAegC[i] == ' '; i++)
		{
			num++;
		}
		if (num == 0)
		{
			return;
		}
		int num2 = _0023_003DzJZbLMmLxAegC.Length - num;
		for (int j = 0; j < _0023_003DzJZbLMmLxAegC.Length; j++)
		{
			if (j < num2)
			{
				_0023_003DzJZbLMmLxAegC[j] = _0023_003DzJZbLMmLxAegC[num + j];
			}
			else
			{
				_0023_003DzJZbLMmLxAegC[j] = ' ';
			}
		}
	}

	public void _0023_003DzvL6tK27_0024YkBi()
	{
		Array.Reverse(_0023_003DzJZbLMmLxAegC);
		_0023_003DzzwWR1xL3NS0N();
		Array.Reverse(_0023_003DzJZbLMmLxAegC);
	}

	public int _0023_003DzzPy760Jv2_2e()
	{
		int num = _0023_003DzJZbLMmLxAegC.Length;
		char c = ' ';
		int num2 = _0023_003DzJZbLMmLxAegC.Length - 1;
		while (num2 > -1 && _0023_003DzJZbLMmLxAegC[num2] == c)
		{
			num--;
			num2--;
		}
		return num;
	}

	public static _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D operator +(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003DzPJNpNF4_003D(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D operator +(string _0023_003DzuwH5j5s_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003DzPJNpNF4_003D(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D operator +(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, string _0023_003DzuwH5j5s_003D)
	{
		return _0023_003DzPJNpNF4_003D(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray());
	}

	public static _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzPJNpNF4_003D(char[] _0023_003Dzfm4oGj8_003D, char[] _0023_003DzCVdPoWM_003D)
	{
		_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2 = new _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(_0023_003Dzfm4oGj8_003D.Length + _0023_003DzCVdPoWM_003D.Length);
		Array.Copy(_0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003Dzfm4oGj8_003D.Length);
		Array.Copy(_0023_003DzCVdPoWM_003D, 0, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003Dzfm4oGj8_003D.Length, _0023_003DzCVdPoWM_003D.Length);
		return _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2;
	}

	public static bool operator ==(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator ==(string _0023_003DzuwH5j5s_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003DzMAxShrbxTEQp(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator ==(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, string _0023_003DzuwH5j5s_003D)
	{
		return _0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray());
	}

	public static bool operator !=(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return !_0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator !=(string _0023_003DzuwH5j5s_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return !_0023_003DzMAxShrbxTEQp(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator !=(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, string _0023_003DzuwH5j5s_003D)
	{
		return !_0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray());
	}

	public static bool _0023_003DzMAxShrbxTEQp(char[] _0023_003DzeMBeuAQ_003D, char[] _0023_003DznYtQKck_003D)
	{
		int _0023_003Dz736ekIs_003D = Math.Max(_0023_003DzeMBeuAQ_003D.Length, _0023_003DznYtQKck_003D.Length);
		char[] array = _0023_003DzPB_00246Uh8lDY7R(_0023_003DzeMBeuAQ_003D, _0023_003Dz736ekIs_003D);
		char[] array2 = _0023_003DzPB_00246Uh8lDY7R(_0023_003DznYtQKck_003D, _0023_003Dz736ekIs_003D);
		if (array.Length != array2.Length)
		{
			return false;
		}
		bool result = true;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != array2[i])
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public override bool Equals(object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003DzCX9Hbao_003D == null)
		{
			return false;
		}
		if (!(_0023_003DzCX9Hbao_003D is _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2))
		{
			return false;
		}
		return _0023_003DzMAxShrbxTEQp(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D2._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003Dz5OSfJ_0024_nqiJX());
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static bool operator >(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003Dz94C_uhXHr3XX(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator >(string _0023_003DzuwH5j5s_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003Dz94C_uhXHr3XX(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator >(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, string _0023_003DzuwH5j5s_003D)
	{
		return _0023_003Dz94C_uhXHr3XX(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray());
	}

	public static bool operator >=(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		if (!_0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX()))
		{
			return _0023_003Dz94C_uhXHr3XX(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
		}
		return true;
	}

	public static bool operator >=(string _0023_003DzuwH5j5s_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		if (!_0023_003DzMAxShrbxTEQp(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX()))
		{
			return _0023_003Dz94C_uhXHr3XX(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
		}
		return true;
	}

	public static bool operator >=(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, string _0023_003DzuwH5j5s_003D)
	{
		if (!_0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray()))
		{
			return _0023_003Dz94C_uhXHr3XX(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray());
		}
		return true;
	}

	public static bool _0023_003Dz94C_uhXHr3XX(char[] _0023_003DzeMBeuAQ_003D, char[] _0023_003DznYtQKck_003D)
	{
		int _0023_003Dz736ekIs_003D = Math.Max(_0023_003DzeMBeuAQ_003D.Length, _0023_003DznYtQKck_003D.Length);
		char[] array = _0023_003DzPB_00246Uh8lDY7R(_0023_003DzeMBeuAQ_003D, _0023_003Dz736ekIs_003D);
		char[] array2 = _0023_003DzPB_00246Uh8lDY7R(_0023_003DznYtQKck_003D, _0023_003Dz736ekIs_003D);
		bool result = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != array2[i])
			{
				if (array[i] > array2[i])
				{
					result = true;
					break;
				}
				if (array[i] < array2[i])
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	public static bool operator <(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003DzxNw41V_00247w_00248G(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator <(string _0023_003DzuwH5j5s_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		return _0023_003DzxNw41V_00247w_00248G(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
	}

	public static bool operator <(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, string _0023_003DzuwH5j5s_003D)
	{
		return _0023_003DzxNw41V_00247w_00248G(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray());
	}

	public static bool operator <=(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		if (!_0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX()))
		{
			return _0023_003DzxNw41V_00247w_00248G(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
		}
		return true;
	}

	public static bool operator <=(string _0023_003DzuwH5j5s_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzCVdPoWM_003D)
	{
		if (!_0023_003DzMAxShrbxTEQp(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX()))
		{
			return _0023_003DzxNw41V_00247w_00248G(_0023_003DzuwH5j5s_003D.ToCharArray(), _0023_003DzCVdPoWM_003D._0023_003Dz5OSfJ_0024_nqiJX());
		}
		return true;
	}

	public static bool operator <=(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzfm4oGj8_003D, string _0023_003DzuwH5j5s_003D)
	{
		if (!_0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray()))
		{
			return _0023_003DzxNw41V_00247w_00248G(_0023_003Dzfm4oGj8_003D._0023_003Dz5OSfJ_0024_nqiJX(), _0023_003DzuwH5j5s_003D.ToCharArray());
		}
		return true;
	}

	public static bool _0023_003DzxNw41V_00247w_00248G(char[] _0023_003DzeMBeuAQ_003D, char[] _0023_003DznYtQKck_003D)
	{
		int _0023_003Dz736ekIs_003D = Math.Max(_0023_003DzeMBeuAQ_003D.Length, _0023_003DznYtQKck_003D.Length);
		char[] array = _0023_003DzPB_00246Uh8lDY7R(_0023_003DzeMBeuAQ_003D, _0023_003Dz736ekIs_003D);
		char[] array2 = _0023_003DzPB_00246Uh8lDY7R(_0023_003DznYtQKck_003D, _0023_003Dz736ekIs_003D);
		bool result = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != array2[i])
			{
				if (array[i] < array2[i])
				{
					result = true;
					break;
				}
				if (array[i] > array2[i])
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	private static char[] _0023_003DzPB_00246Uh8lDY7R(char[] _0023_003Dzb7SPTpc_003D, int _0023_003Dz736ekIs_003D)
	{
		if (_0023_003Dzb7SPTpc_003D.Length == _0023_003Dz736ekIs_003D)
		{
			return _0023_003Dzb7SPTpc_003D;
		}
		char[] array = new char[_0023_003Dz736ekIs_003D];
		int num = Math.Min(_0023_003Dzb7SPTpc_003D.Length, _0023_003Dz736ekIs_003D);
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003Dzb7SPTpc_003D[i];
		}
		for (int j = num; j < array.Length; j++)
		{
			array[j] = ' ';
		}
		return array;
	}

	public static implicit operator _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(string _0023_003DzuwH5j5s_003D)
	{
		return new _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D(_0023_003DzuwH5j5s_003D);
	}

	public override string ToString()
	{
		return new string(_0023_003DzJZbLMmLxAegC);
	}
}
