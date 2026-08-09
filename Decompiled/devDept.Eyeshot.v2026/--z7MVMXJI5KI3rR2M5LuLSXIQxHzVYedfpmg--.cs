using System;

internal sealed class _0023_003Dz7MVMXJI5KI3rR2M5LuLSXIQxHzVYedfpmg_003D_003D
{
	private _0023_003DzIctlsTTrLAIvde3Vivq_OQY_003D _0023_003DzlTrXFNo_003D;

	public int[] _0023_003Dzwvu0gI8_003D(_0023_003DziQV1ad2pQ48G _0023_003DzGGJSiQk_003D)
	{
		_0023_003DzGGJSiQk_003D._0023_003Dzwvu0gI8_003D((_0023_003DzKRlreg4OKYipbqvK8nffVtE_003D)1);
		return _0023_003Dzwvu0gI8_003D(new _0023_003DzIctlsTTrLAIvde3Vivq_OQY_003D(_0023_003DzGGJSiQk_003D));
	}

	public int[] _0023_003Dzwvu0gI8_003D(_0023_003DzIctlsTTrLAIvde3Vivq_OQY_003D _0023_003DzlTrXFNo_003D)
	{
		this._0023_003DzlTrXFNo_003D = _0023_003DzlTrXFNo_003D;
		int num = _0023_003DzlTrXFNo_003D._0023_003DzCR5B5Pw_003D();
		int[] _0023_003DzjbqS1qE_003D = _0023_003DzlTrXFNo_003D._0023_003DzAdZrjeBUsiUt();
		_0023_003DzrYnBVRQ_003D(_0023_003DzjbqS1qE_003D, _0023_003DzCBEAoWM_003D: true);
		int[] _0023_003DzvZUH06hpArK = _0023_003Dza3yu8yUSJ5WP();
		int[] array = _0023_003DzW0AQL4LZO8PS(_0023_003DzvZUH06hpArK);
		int num2 = _0023_003DzIgGMIVLga_0024jT(_0023_003DzvZUH06hpArK, array);
		if (_0023_003DzFssxjLXQIoCN._0023_003Dzgn4R6SUws5Zs())
		{
			_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003DzFWGyYpI_003D(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302940228), num, num2));
		}
		_0023_003DzrYnBVRQ_003D(_0023_003DzjbqS1qE_003D, _0023_003DzCBEAoWM_003D: false);
		return array;
	}

	private int[] _0023_003Dza3yu8yUSJ5WP()
	{
		int _0023_003DzpGjKR04_003D = _0023_003DzlTrXFNo_003D._0023_003DzpGjKR04_003D;
		int[] array = new int[_0023_003DzpGjKR04_003D];
		int _0023_003DzFW4ETP7Rarvt = 0;
		int _0023_003Dz4FlvAtfAI8Ps = 0;
		int[] _0023_003DzNn6SUB6oR60k = new int[_0023_003DzpGjKR04_003D + 1];
		int[] array2 = new int[_0023_003DzpGjKR04_003D];
		for (int i = 0; i < _0023_003DzpGjKR04_003D; i++)
		{
			array2[i] = 1;
		}
		int num = 1;
		for (int i = 0; i < _0023_003DzpGjKR04_003D; i++)
		{
			if (array2[i] != 0)
			{
				int _0023_003DzeBP9GLo_003D = i;
				_0023_003DzoCaW_0024mHVUkbN(ref _0023_003DzeBP9GLo_003D, array2, ref _0023_003Dz4FlvAtfAI8Ps, _0023_003DzNn6SUB6oR60k, array, num - 1);
				_0023_003DzM8qrSIk_003D(_0023_003DzeBP9GLo_003D, array2, array, num - 1, ref _0023_003DzFW4ETP7Rarvt);
				num += _0023_003DzFW4ETP7Rarvt;
				if (_0023_003DzpGjKR04_003D < num)
				{
					return array;
				}
			}
		}
		return array;
	}

	private void _0023_003DzM8qrSIk_003D(int _0023_003DzeBP9GLo_003D, int[] _0023_003Dz4Dqaxfw_003D, int[] _0023_003DzvZUH06hpArK4, int _0023_003DzfBEBL_o_003D, ref int _0023_003DzFW4ETP7Rarvt)
	{
		int[] array = _0023_003DzlTrXFNo_003D._0023_003DzAdZrjeBUsiUt();
		int[] array2 = _0023_003DzlTrXFNo_003D._0023_003DzlHm2HcTThvFX();
		int[] array3 = new int[_0023_003DzlTrXFNo_003D._0023_003DzpGjKR04_003D];
		_0023_003DzXf0erh4_003D(_0023_003DzeBP9GLo_003D, _0023_003Dz4Dqaxfw_003D, array3, ref _0023_003DzFW4ETP7Rarvt, _0023_003DzvZUH06hpArK4, _0023_003DzfBEBL_o_003D);
		_0023_003Dz4Dqaxfw_003D[_0023_003DzeBP9GLo_003D] = 0;
		if (_0023_003DzFW4ETP7Rarvt <= 1)
		{
			return;
		}
		int num = 0;
		int num2 = 1;
		while (num < num2)
		{
			int num3 = num + 1;
			num = num2;
			for (int i = num3; i <= num; i++)
			{
				int num4 = _0023_003DzvZUH06hpArK4[_0023_003DzfBEBL_o_003D + i - 1];
				int num5 = array[num4];
				int num6 = array[num4 + 1] - 1;
				int num7 = num2 + 1;
				for (int j = num5; j <= num6; j++)
				{
					int num8 = array2[j - 1];
					if (_0023_003Dz4Dqaxfw_003D[num8] != 0)
					{
						num2++;
						_0023_003Dz4Dqaxfw_003D[num8] = 0;
						_0023_003DzvZUH06hpArK4[_0023_003DzfBEBL_o_003D + num2 - 1] = num8;
					}
				}
				if (num2 <= num7)
				{
					continue;
				}
				int num9 = num7;
				while (num9 < num2)
				{
					int num10 = num9;
					num9++;
					int num8 = _0023_003DzvZUH06hpArK4[_0023_003DzfBEBL_o_003D + num9 - 1];
					while (num7 < num10)
					{
						int num11 = _0023_003DzvZUH06hpArK4[_0023_003DzfBEBL_o_003D + num10 - 1];
						if (array3[num11 - 1] <= array3[num8 - 1])
						{
							break;
						}
						_0023_003DzvZUH06hpArK4[_0023_003DzfBEBL_o_003D + num10] = num11;
						num10--;
					}
					_0023_003DzvZUH06hpArK4[_0023_003DzfBEBL_o_003D + num10] = num8;
				}
			}
		}
		_0023_003DzGHF2JkKf7h75(_0023_003DzvZUH06hpArK4, _0023_003DzfBEBL_o_003D, _0023_003DzFW4ETP7Rarvt);
	}

	private void _0023_003DzoCaW_0024mHVUkbN(ref int _0023_003DzeBP9GLo_003D, int[] _0023_003Dz4Dqaxfw_003D, ref int _0023_003Dz4FlvAtfAI8Ps, int[] _0023_003DzNn6SUB6oR60k, int[] _0023_003DzfNi7d4A_003D, int _0023_003DzfBEBL_o_003D)
	{
		int[] array = _0023_003DzlTrXFNo_003D._0023_003DzAdZrjeBUsiUt();
		int[] array2 = _0023_003DzlTrXFNo_003D._0023_003DzlHm2HcTThvFX();
		int _0023_003Dz4FlvAtfAI8Ps2 = 0;
		_0023_003DzsAL16p_r_0024dmC(ref _0023_003DzeBP9GLo_003D, _0023_003Dz4Dqaxfw_003D, ref _0023_003Dz4FlvAtfAI8Ps, _0023_003DzNn6SUB6oR60k, _0023_003DzfNi7d4A_003D, _0023_003DzfBEBL_o_003D);
		int num = _0023_003DzNn6SUB6oR60k[_0023_003Dz4FlvAtfAI8Ps] - 1;
		if (_0023_003Dz4FlvAtfAI8Ps == 1 || _0023_003Dz4FlvAtfAI8Ps == num)
		{
			return;
		}
		do
		{
			int num2 = num;
			int num3 = _0023_003DzNn6SUB6oR60k[_0023_003Dz4FlvAtfAI8Ps - 1];
			_0023_003DzeBP9GLo_003D = _0023_003DzfNi7d4A_003D[_0023_003DzfBEBL_o_003D + num3 - 1];
			if (num3 < num)
			{
				for (int i = num3; i <= num; i++)
				{
					int num4 = _0023_003DzfNi7d4A_003D[_0023_003DzfBEBL_o_003D + i - 1];
					int num5 = 0;
					int num6 = array[num4 - 1];
					int num7 = array[num4] - 1;
					for (int j = num6; j <= num7; j++)
					{
						int num8 = array2[j - 1];
						if (_0023_003Dz4Dqaxfw_003D[num8] > 0)
						{
							num5++;
						}
					}
					if (num5 < num2)
					{
						_0023_003DzeBP9GLo_003D = num4;
						num2 = num5;
					}
				}
			}
			_0023_003DzsAL16p_r_0024dmC(ref _0023_003DzeBP9GLo_003D, _0023_003Dz4Dqaxfw_003D, ref _0023_003Dz4FlvAtfAI8Ps2, _0023_003DzNn6SUB6oR60k, _0023_003DzfNi7d4A_003D, _0023_003DzfBEBL_o_003D);
			if (_0023_003Dz4FlvAtfAI8Ps2 > _0023_003Dz4FlvAtfAI8Ps)
			{
				_0023_003Dz4FlvAtfAI8Ps = _0023_003Dz4FlvAtfAI8Ps2;
				continue;
			}
			break;
		}
		while (num > _0023_003Dz4FlvAtfAI8Ps);
	}

	private void _0023_003DzsAL16p_r_0024dmC(ref int _0023_003DzeBP9GLo_003D, int[] _0023_003Dz4Dqaxfw_003D, ref int _0023_003Dz4FlvAtfAI8Ps, int[] _0023_003DzNn6SUB6oR60k, int[] _0023_003DzfNi7d4A_003D, int _0023_003DzfBEBL_o_003D)
	{
		int[] array = _0023_003DzlTrXFNo_003D._0023_003DzAdZrjeBUsiUt();
		int[] array2 = _0023_003DzlTrXFNo_003D._0023_003DzlHm2HcTThvFX();
		_0023_003Dz4Dqaxfw_003D[_0023_003DzeBP9GLo_003D] = 0;
		_0023_003DzfNi7d4A_003D[_0023_003DzfBEBL_o_003D] = _0023_003DzeBP9GLo_003D;
		_0023_003Dz4FlvAtfAI8Ps = 0;
		int num = 0;
		int num2 = 1;
		do
		{
			int num3 = num + 1;
			num = num2;
			_0023_003Dz4FlvAtfAI8Ps++;
			_0023_003DzNn6SUB6oR60k[_0023_003Dz4FlvAtfAI8Ps - 1] = num3;
			for (int i = num3; i <= num; i++)
			{
				int num4 = _0023_003DzfNi7d4A_003D[_0023_003DzfBEBL_o_003D + i - 1];
				int num5 = array[num4];
				int num6 = array[num4 + 1] - 1;
				for (int j = num5; j <= num6; j++)
				{
					int num7 = array2[j - 1];
					if (_0023_003Dz4Dqaxfw_003D[num7] != 0)
					{
						num2++;
						_0023_003DzfNi7d4A_003D[_0023_003DzfBEBL_o_003D + num2 - 1] = num7;
						_0023_003Dz4Dqaxfw_003D[num7] = 0;
					}
				}
			}
		}
		while (num2 - num > 0);
		_0023_003DzNn6SUB6oR60k[_0023_003Dz4FlvAtfAI8Ps] = num + 1;
		for (int i = 0; i < num2; i++)
		{
			_0023_003Dz4Dqaxfw_003D[_0023_003DzfNi7d4A_003D[_0023_003DzfBEBL_o_003D + i]] = 1;
		}
	}

	private void _0023_003DzXf0erh4_003D(int _0023_003DzeBP9GLo_003D, int[] _0023_003Dz4Dqaxfw_003D, int[] _0023_003DzbU0rLpQ_003D, ref int _0023_003DzFW4ETP7Rarvt, int[] _0023_003DzjD_wkCI_003D, int _0023_003DzfBEBL_o_003D)
	{
		int[] array = _0023_003DzlTrXFNo_003D._0023_003DzAdZrjeBUsiUt();
		int[] array2 = _0023_003DzlTrXFNo_003D._0023_003DzlHm2HcTThvFX();
		int num = 1;
		_0023_003DzjD_wkCI_003D[_0023_003DzfBEBL_o_003D] = _0023_003DzeBP9GLo_003D;
		array[_0023_003DzeBP9GLo_003D] = -array[_0023_003DzeBP9GLo_003D];
		int num2 = 0;
		_0023_003DzFW4ETP7Rarvt = 1;
		while (num > 0)
		{
			int num3 = num2 + 1;
			num2 = _0023_003DzFW4ETP7Rarvt;
			for (int i = num3; i <= num2; i++)
			{
				int num4 = _0023_003DzjD_wkCI_003D[_0023_003DzfBEBL_o_003D + i - 1];
				int num5 = -array[num4];
				int num6 = Math.Abs(array[num4 + 1]) - 1;
				int num7 = 0;
				for (int j = num5; j <= num6; j++)
				{
					int num8 = array2[j - 1];
					if (_0023_003Dz4Dqaxfw_003D[num8] != 0)
					{
						num7++;
						if (0 <= array[num8])
						{
							array[num8] = -array[num8];
							_0023_003DzFW4ETP7Rarvt++;
							_0023_003DzjD_wkCI_003D[_0023_003DzfBEBL_o_003D + _0023_003DzFW4ETP7Rarvt - 1] = num8;
						}
					}
				}
				_0023_003DzbU0rLpQ_003D[num4] = num7;
			}
			num = _0023_003DzFW4ETP7Rarvt - num2;
		}
		for (int i = 0; i < _0023_003DzFW4ETP7Rarvt; i++)
		{
			int num4 = _0023_003DzjD_wkCI_003D[_0023_003DzfBEBL_o_003D + i];
			array[num4] = -array[num4];
		}
	}

	private int _0023_003DzIgGMIVLga_0024jT(int[] _0023_003DzvZUH06hpArK4, int[] _0023_003Dza4aJqheczJk_0024bjnUMQ_003D_003D)
	{
		int[] array = _0023_003DzlTrXFNo_003D._0023_003DzAdZrjeBUsiUt();
		int[] array2 = _0023_003DzlTrXFNo_003D._0023_003DzlHm2HcTThvFX();
		int num = 0;
		int num2 = 0;
		int _0023_003DzpGjKR04_003D = _0023_003DzlTrXFNo_003D._0023_003DzpGjKR04_003D;
		for (int i = 0; i < _0023_003DzpGjKR04_003D; i++)
		{
			for (int j = array[_0023_003DzvZUH06hpArK4[i]]; j < array[_0023_003DzvZUH06hpArK4[i] + 1]; j++)
			{
				int num3 = _0023_003Dza4aJqheczJk_0024bjnUMQ_003D_003D[array2[j - 1]];
				num = Math.Max(num, i - num3);
				num2 = Math.Max(num2, num3 - i);
			}
		}
		return num + 1 + num2;
	}

	private int[] _0023_003DzW0AQL4LZO8PS(int[] _0023_003DzvZUH06hpArK4)
	{
		int _0023_003DzpGjKR04_003D = _0023_003DzlTrXFNo_003D._0023_003DzpGjKR04_003D;
		int[] array = new int[_0023_003DzpGjKR04_003D];
		for (int i = 0; i < _0023_003DzpGjKR04_003D; i++)
		{
			array[_0023_003DzvZUH06hpArK4[i]] = i;
		}
		return array;
	}

	private void _0023_003DzGHF2JkKf7h75(int[] _0023_003DzjbqS1qE_003D, int _0023_003DzfBEBL_o_003D, int _0023_003Dz14lzA48_003D)
	{
		for (int i = 0; i < _0023_003Dz14lzA48_003D / 2; i++)
		{
			int num = _0023_003DzjbqS1qE_003D[_0023_003DzfBEBL_o_003D + i];
			_0023_003DzjbqS1qE_003D[_0023_003DzfBEBL_o_003D + i] = _0023_003DzjbqS1qE_003D[_0023_003DzfBEBL_o_003D + _0023_003Dz14lzA48_003D - 1 - i];
			_0023_003DzjbqS1qE_003D[_0023_003DzfBEBL_o_003D + _0023_003Dz14lzA48_003D - 1 - i] = num;
		}
	}

	private void _0023_003DzrYnBVRQ_003D(int[] _0023_003DzjbqS1qE_003D, bool _0023_003DzCBEAoWM_003D)
	{
		int num = _0023_003DzjbqS1qE_003D.Length;
		if (_0023_003DzCBEAoWM_003D)
		{
			for (int i = 0; i < num; i++)
			{
				_0023_003DzjbqS1qE_003D[i]++;
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				_0023_003DzjbqS1qE_003D[j]--;
			}
		}
	}
}
