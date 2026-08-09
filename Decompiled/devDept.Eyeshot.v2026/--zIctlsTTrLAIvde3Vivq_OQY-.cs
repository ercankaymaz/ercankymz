using System;

internal sealed class _0023_003DzIctlsTTrLAIvde3Vivq_OQY_003D
{
	private int _0023_003Dzg_qdAmM_003D;

	private int[] _0023_003Dz1R6CVs97Tud9;

	private int[] _0023_003DzzGv_0024VO6iZzze;

	public readonly int _0023_003DzpGjKR04_003D;

	public _0023_003DzIctlsTTrLAIvde3Vivq_OQY_003D(_0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D)
	{
		_0023_003DzpGjKR04_003D = _0023_003DzGGJSiQk_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		_0023_003Dz1R6CVs97Tud9 = _0023_003Dzr6wFhgY_003D(_0023_003DzGGJSiQk_003D);
		_0023_003Dzg_qdAmM_003D = _0023_003Dz1R6CVs97Tud9[_0023_003DzpGjKR04_003D];
		_0023_003DzzGv_0024VO6iZzze = _0023_003DzmEscjS4_003D(_0023_003DzGGJSiQk_003D, _0023_003Dz1R6CVs97Tud9);
		_0023_003DzvMxBCjvLfFa2();
	}

	public _0023_003DzIctlsTTrLAIvde3Vivq_OQY_003D(int[] _0023_003Dz1R6CVs97Tud9, int[] _0023_003DzzGv_0024VO6iZzze)
	{
		_0023_003DzpGjKR04_003D = _0023_003Dz1R6CVs97Tud9.Length - 1;
		_0023_003Dzg_qdAmM_003D = _0023_003Dz1R6CVs97Tud9[_0023_003DzpGjKR04_003D];
		this._0023_003Dz1R6CVs97Tud9 = _0023_003Dz1R6CVs97Tud9;
		this._0023_003DzzGv_0024VO6iZzze = _0023_003DzzGv_0024VO6iZzze;
		if (_0023_003Dz1R6CVs97Tud9[0] != 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302940280), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302940247));
		}
		if (_0023_003DzzGv_0024VO6iZzze.Length < _0023_003Dzg_qdAmM_003D)
		{
			throw new ArgumentException();
		}
	}

	public int[] _0023_003DzAdZrjeBUsiUt()
	{
		return _0023_003Dz1R6CVs97Tud9;
	}

	public int[] _0023_003DzlHm2HcTThvFX()
	{
		return _0023_003DzzGv_0024VO6iZzze;
	}

	public int _0023_003DzCR5B5Pw_003D()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < _0023_003DzpGjKR04_003D; i++)
		{
			for (int j = _0023_003Dz1R6CVs97Tud9[i]; j < _0023_003Dz1R6CVs97Tud9[i + 1]; j++)
			{
				int num3 = _0023_003DzzGv_0024VO6iZzze[j];
				num = Math.Max(num, i - num3);
				num2 = Math.Max(num2, num3 - i);
			}
		}
		return num + 1 + num2;
	}

	private int[] _0023_003Dzr6wFhgY_003D(_0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D)
	{
		int num = _0023_003DzpGjKR04_003D;
		int[] array = new int[num + 1];
		for (int i = 0; i < num; i++)
		{
			array[i] = 1;
		}
		foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item in _0023_003DzGGJSiQk_003D._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			int _0023_003Dz2QVVx8s_003D = item._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D2 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0]._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D3 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D4 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2]._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D5 = item._0023_003Dz8WM3j__0024e6O4Z2VuOjw_003D_003D[2]._0023_003DzEzv5_0024vo_003D._0023_003Dz2QVVx8s_003D;
			if (_0023_003Dz2QVVx8s_003D5 < 0 || _0023_003Dz2QVVx8s_003D < _0023_003Dz2QVVx8s_003D5)
			{
				array[_0023_003Dz2QVVx8s_003D2]++;
				array[_0023_003Dz2QVVx8s_003D3]++;
			}
			_0023_003Dz2QVVx8s_003D5 = item._0023_003Dz8WM3j__0024e6O4Z2VuOjw_003D_003D[0]._0023_003DzEzv5_0024vo_003D._0023_003Dz2QVVx8s_003D;
			if (_0023_003Dz2QVVx8s_003D5 < 0 || _0023_003Dz2QVVx8s_003D < _0023_003Dz2QVVx8s_003D5)
			{
				array[_0023_003Dz2QVVx8s_003D3]++;
				array[_0023_003Dz2QVVx8s_003D4]++;
			}
			_0023_003Dz2QVVx8s_003D5 = item._0023_003Dz8WM3j__0024e6O4Z2VuOjw_003D_003D[1]._0023_003DzEzv5_0024vo_003D._0023_003Dz2QVVx8s_003D;
			if (_0023_003Dz2QVVx8s_003D5 < 0 || _0023_003Dz2QVVx8s_003D < _0023_003Dz2QVVx8s_003D5)
			{
				array[_0023_003Dz2QVVx8s_003D4]++;
				array[_0023_003Dz2QVVx8s_003D2]++;
			}
		}
		for (int num2 = num; num2 > 0; num2--)
		{
			array[num2] = array[num2 - 1];
		}
		array[0] = 0;
		for (int j = 1; j <= num; j++)
		{
			array[j] = array[j - 1] + array[j];
		}
		return array;
	}

	private int[] _0023_003DzmEscjS4_003D(_0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D, int[] _0023_003Dz1R6CVs97Tud9)
	{
		int num = _0023_003DzpGjKR04_003D;
		int[] array = new int[num];
		Array.Copy(_0023_003Dz1R6CVs97Tud9, array, num);
		int[] array2 = new int[_0023_003Dz1R6CVs97Tud9[num]];
		for (int i = 0; i < num; i++)
		{
			array2[array[i]] = i;
			array[i]++;
		}
		foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item in _0023_003DzGGJSiQk_003D._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			int _0023_003Dz2QVVx8s_003D = item._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D2 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0]._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D3 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D4 = item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2]._0023_003Dz2QVVx8s_003D;
			int _0023_003Dz2QVVx8s_003D5 = item._0023_003Dz8WM3j__0024e6O4Z2VuOjw_003D_003D[2]._0023_003DzEzv5_0024vo_003D._0023_003Dz2QVVx8s_003D;
			if (_0023_003Dz2QVVx8s_003D5 < 0 || _0023_003Dz2QVVx8s_003D < _0023_003Dz2QVVx8s_003D5)
			{
				array2[array[_0023_003Dz2QVVx8s_003D2]++] = _0023_003Dz2QVVx8s_003D3;
				array2[array[_0023_003Dz2QVVx8s_003D3]++] = _0023_003Dz2QVVx8s_003D2;
			}
			_0023_003Dz2QVVx8s_003D5 = item._0023_003Dz8WM3j__0024e6O4Z2VuOjw_003D_003D[0]._0023_003DzEzv5_0024vo_003D._0023_003Dz2QVVx8s_003D;
			if (_0023_003Dz2QVVx8s_003D5 < 0 || _0023_003Dz2QVVx8s_003D < _0023_003Dz2QVVx8s_003D5)
			{
				array2[array[_0023_003Dz2QVVx8s_003D3]++] = _0023_003Dz2QVVx8s_003D4;
				array2[array[_0023_003Dz2QVVx8s_003D4]++] = _0023_003Dz2QVVx8s_003D3;
			}
			_0023_003Dz2QVVx8s_003D5 = item._0023_003Dz8WM3j__0024e6O4Z2VuOjw_003D_003D[1]._0023_003DzEzv5_0024vo_003D._0023_003Dz2QVVx8s_003D;
			if (_0023_003Dz2QVVx8s_003D5 < 0 || _0023_003Dz2QVVx8s_003D < _0023_003Dz2QVVx8s_003D5)
			{
				array2[array[_0023_003Dz2QVVx8s_003D2]++] = _0023_003Dz2QVVx8s_003D4;
				array2[array[_0023_003Dz2QVVx8s_003D4]++] = _0023_003Dz2QVVx8s_003D2;
			}
		}
		return array2;
	}

	public void _0023_003DzvMxBCjvLfFa2()
	{
		int num = _0023_003DzpGjKR04_003D;
		int[] array = _0023_003DzzGv_0024VO6iZzze;
		for (int i = 0; i < num; i++)
		{
			int num2 = _0023_003Dz1R6CVs97Tud9[i];
			int num3 = _0023_003Dz1R6CVs97Tud9[i + 1];
			Array.Sort(array, num2, num3 - num2);
		}
	}
}
