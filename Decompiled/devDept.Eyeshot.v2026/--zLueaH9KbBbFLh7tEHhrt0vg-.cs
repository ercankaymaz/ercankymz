using System;

internal sealed class _0023_003DzLueaH9KbBbFLh7tEHhrt0vg_003D
{
	public static void _0023_003Dzn6oeQ2ACRlf9(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, int _0023_003Dz736ekIs_003D)
	{
		string text = Console.ReadLine();
		if (text.Length > _0023_003Dz736ekIs_003D)
		{
			text = text.Substring(0, _0023_003Dz736ekIs_003D);
		}
		_0023_003Dzw_E1nLs_003D._0023_003DzMCIyDkQObv7g(_0023_003Dz736ekIs_003D);
		_0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D, text);
	}

	public static void _0023_003Dzkz9ORNs_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, int _0023_003DzkXQ_IWk_003D, int _0023_003Dz6tVBpdk_003D, int _0023_003DzkKfJheA_003D)
	{
		_0023_003Dzw_E1nLs_003D._0023_003DzMCIyDkQObv7g(_0023_003Dz6tVBpdk_003D);
		char[] array = new char[_0023_003Dz6tVBpdk_003D];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = '#';
		}
		for (int j = 0; j < _0023_003DzkKfJheA_003D; j++)
		{
			array[j] = '0';
		}
		Array.Reverse(array);
		string text = new string(array);
		string text2 = _0023_003DzkXQ_IWk_003D.ToString(text);
		text2 = ((text2.Length <= _0023_003Dz6tVBpdk_003D) ? (new string(' ', _0023_003Dz6tVBpdk_003D - text2.Length) + text2) : new string('*', _0023_003Dz6tVBpdk_003D));
		_0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D, text2);
	}

	public static void _0023_003Dz9LxJ6iQ_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzw_E1nLs_003D, float _0023_003DzkXQ_IWk_003D, int _0023_003Dz6tVBpdk_003D, int _0023_003DzXrexKjY_003D)
	{
		_0023_003Dzw_E1nLs_003D._0023_003DzMCIyDkQObv7g(_0023_003Dz6tVBpdk_003D);
		string empty = string.Empty;
		if (_0023_003Dz6tVBpdk_003D <= _0023_003DzXrexKjY_003D + 2)
		{
			empty = new string('*', _0023_003Dz6tVBpdk_003D);
		}
		else
		{
			char[] array = new char[_0023_003Dz6tVBpdk_003D];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = '#';
			}
			for (int j = 0; j < _0023_003DzXrexKjY_003D; j++)
			{
				array[j] = '0';
			}
			array[_0023_003DzXrexKjY_003D] = '.';
			Array.Reverse(array);
			string text = new string(array);
			empty = _0023_003DzkXQ_IWk_003D.ToString(text);
		}
		empty = ((empty.Length <= _0023_003Dz6tVBpdk_003D) ? (new string(' ', _0023_003Dz6tVBpdk_003D - empty.Length) + empty) : new string('*', _0023_003Dz6tVBpdk_003D));
		_0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003DztmyULho_003D(_0023_003Dzw_E1nLs_003D, empty);
	}

	public static bool _0023_003DzP2ag06g_003D(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dzb7SPTpc_003D, int _0023_003Dz6tVBpdk_003D, int _0023_003DzXrexKjY_003D, out float _0023_003Dzw_E1nLs_003D)
	{
		string text = _0023_003Dzb7SPTpc_003D._0023_003DzsChJCuM_003D(1, _0023_003Dz6tVBpdk_003D).ToString();
		float result2;
		bool result = float.TryParse(text, out result2);
		_0023_003Dzw_E1nLs_003D = result2;
		if (!text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290)))
		{
			_0023_003Dzw_E1nLs_003D *= (float)Math.Pow(10.0, -_0023_003DzXrexKjY_003D);
		}
		return result;
	}

	public static void _0023_003DzWPwu0IAf_XTT(_0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003Dz9s8KP64_003D, _0023_003DzqIrg0gdAcKOTcF0g9kvRF4c_003D _0023_003DzysdZ6Uk_003D)
	{
		DateTime now = DateTime.Now;
		_0023_003Dz9s8KP64_003D._0023_003DzMCIyDkQObv7g(8);
		_0023_003DzysdZ6Uk_003D._0023_003DzMCIyDkQObv7g(10);
		_0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003DztmyULho_003D(_0023_003Dz9s8KP64_003D, now.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302916078)));
		_0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003DztmyULho_003D(_0023_003DzysdZ6Uk_003D, now.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302916059)));
	}
}
