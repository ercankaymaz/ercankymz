using System;

internal sealed class _0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D
{
	private byte[] _0023_003DzjYYAPCA_003D;

	private int _0023_003DzVC9FBdo_003D;

	private long _0023_003DzwBouG0w_003D;

	private uint _0023_003Dzf4Pqh9s_003D;

	private uint _0023_003DzTFNDoh0_003D;

	private uint _0023_003DzraVZG9g_003D;

	private uint _0023_003DzRoqMfFc_003D;

	private uint _0023_003Dz1SmHC4c_003D;

	private uint[] _0023_003DzLtLprGE_003D = new uint[80];

	private int _0023_003DzmZWYhFQ_003D;

	public _0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D()
	{
		_0023_003DzjYYAPCA_003D = new byte[4];
		_0023_003DzSDIC4VOXiKpVP0iFpWcNbsFEtDoGQu2h_0024Q_003D_003D();
	}

	public _0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D(_0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzfQvnWet7tuxWaLjeMnznJE7BxFjn(_0023_003DzjYYAPCA_003D);
	}

	public void _0023_003DzAmAj8l8SsCGR_0024hRntZ6pKCU_003D(byte _0023_003DzjYYAPCA_003D)
	{
		this._0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D++] = _0023_003DzjYYAPCA_003D;
		if (_0023_003DzVC9FBdo_003D == this._0023_003DzjYYAPCA_003D.Length)
		{
			_0023_003DzqTnU38Y8lCTAIeKx8HMo_002454_003D(this._0023_003DzjYYAPCA_003D, 0);
			_0023_003DzVC9FBdo_003D = 0;
		}
		_0023_003DzwBouG0w_003D++;
	}

	public void _0023_003DzDGn_AbqNSidQB4JPsXfLyad9Ukiid7q5prEVdQk_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzwBouG0w_003D = Math.Max(0, _0023_003DzwBouG0w_003D);
		int i = 0;
		if (this._0023_003DzVC9FBdo_003D != 0)
		{
			while (i < _0023_003DzwBouG0w_003D)
			{
				this._0023_003DzjYYAPCA_003D[this._0023_003DzVC9FBdo_003D++] = _0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + i++];
				if (this._0023_003DzVC9FBdo_003D == 4)
				{
					_0023_003DzqTnU38Y8lCTAIeKx8HMo_002454_003D(this._0023_003DzjYYAPCA_003D, 0);
					this._0023_003DzVC9FBdo_003D = 0;
					break;
				}
			}
		}
		for (int num = ((_0023_003DzwBouG0w_003D - i) & -4) + i; i < num; i += 4)
		{
			_0023_003DzqTnU38Y8lCTAIeKx8HMo_002454_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D + i);
		}
		while (i < _0023_003DzwBouG0w_003D)
		{
			this._0023_003DzjYYAPCA_003D[this._0023_003DzVC9FBdo_003D++] = _0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + i++];
		}
		this._0023_003DzwBouG0w_003D += _0023_003DzwBouG0w_003D;
	}

	public void _0023_003DzNMSukPE5H2YpD6eHxPB8HQ1cXPHizIQfrTFOF80_003D()
	{
		long num = _0023_003DzwBouG0w_003D << 3;
		_0023_003DzAmAj8l8SsCGR_0024hRntZ6pKCU_003D(128);
		while (_0023_003DzVC9FBdo_003D != 0)
		{
			_0023_003DzAmAj8l8SsCGR_0024hRntZ6pKCU_003D(0);
		}
		_0023_003Dz1L1JnkczT_1tEIMfYg_003D_003D(num);
		_0023_003Dzb_DPByRNdftaSSGwGUI69P8jXhjbMAF5UnM49lA_003D();
	}

	public int _0023_003DzydvD6GVkrCLbaF4dwe1Ba_0024U_003D()
	{
		return 64;
	}

	private void _0023_003DzfQvnWet7tuxWaLjeMnznJE7BxFjn(_0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D _0023_003DzjYYAPCA_003D)
	{
		this._0023_003DzjYYAPCA_003D = new byte[_0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D.Length];
		Buffer.BlockCopy(_0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D, 0, this._0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D.Length);
		_0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D._0023_003DzVC9FBdo_003D;
		_0023_003DzwBouG0w_003D = _0023_003DzjYYAPCA_003D._0023_003DzwBouG0w_003D;
		_0023_003Dzf4Pqh9s_003D = _0023_003DzjYYAPCA_003D._0023_003Dzf4Pqh9s_003D;
		_0023_003DzTFNDoh0_003D = _0023_003DzjYYAPCA_003D._0023_003DzTFNDoh0_003D;
		_0023_003DzraVZG9g_003D = _0023_003DzjYYAPCA_003D._0023_003DzraVZG9g_003D;
		_0023_003DzRoqMfFc_003D = _0023_003DzjYYAPCA_003D._0023_003DzRoqMfFc_003D;
		_0023_003Dz1SmHC4c_003D = _0023_003DzjYYAPCA_003D._0023_003Dz1SmHC4c_003D;
		Array.Copy(_0023_003DzjYYAPCA_003D._0023_003DzLtLprGE_003D, 0, _0023_003DzLtLprGE_003D, 0, _0023_003DzjYYAPCA_003D._0023_003DzLtLprGE_003D.Length);
		_0023_003DzmZWYhFQ_003D = _0023_003DzjYYAPCA_003D._0023_003DzmZWYhFQ_003D;
	}

	public int _0023_003DzbUk1euUiF7v2D8kSUEMPlpA_003D()
	{
		return 20;
	}

	public void _0023_003DzqTnU38Y8lCTAIeKx8HMo_002454_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzLtLprGE_003D[_0023_003DzmZWYhFQ_003D] = _0023_003DzMK0mnFF7KP28X4Buk7SztGyxhki9(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		if (++_0023_003DzmZWYhFQ_003D == 16)
		{
			_0023_003Dzb_DPByRNdftaSSGwGUI69P8jXhjbMAF5UnM49lA_003D();
		}
	}

	public void _0023_003Dz1L1JnkczT_1tEIMfYg_003D_003D(long _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzmZWYhFQ_003D > 14)
		{
			_0023_003Dzb_DPByRNdftaSSGwGUI69P8jXhjbMAF5UnM49lA_003D();
		}
		_0023_003DzLtLprGE_003D[14] = (uint)((ulong)_0023_003DzjYYAPCA_003D >> 32);
		_0023_003DzLtLprGE_003D[15] = (uint)_0023_003DzjYYAPCA_003D;
	}

	public int _0023_003Dz9W0ILhHpEXxVzFXN4w3ZTNrrk4nI0vb445WMozNIs28L(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzNMSukPE5H2YpD6eHxPB8HQ1cXPHizIQfrTFOF80_003D();
		_0023_003DztlLSHAgvwJrxWqHWzLUnA_8kBJPY5qaUvjpDiTbsIbGn(_0023_003Dzf4Pqh9s_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		_0023_003DztlLSHAgvwJrxWqHWzLUnA_8kBJPY5qaUvjpDiTbsIbGn(_0023_003DzTFNDoh0_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D + 4);
		_0023_003DztlLSHAgvwJrxWqHWzLUnA_8kBJPY5qaUvjpDiTbsIbGn(_0023_003DzraVZG9g_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D + 8);
		_0023_003DztlLSHAgvwJrxWqHWzLUnA_8kBJPY5qaUvjpDiTbsIbGn(_0023_003DzRoqMfFc_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D + 12);
		_0023_003DztlLSHAgvwJrxWqHWzLUnA_8kBJPY5qaUvjpDiTbsIbGn(_0023_003Dz1SmHC4c_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D + 16);
		_0023_003DzSDIC4VOXiKpVP0iFpWcNbsFEtDoGQu2h_0024Q_003D_003D();
		return 20;
	}

	public void _0023_003DzSDIC4VOXiKpVP0iFpWcNbsFEtDoGQu2h_0024Q_003D_003D()
	{
		_0023_003DzwBouG0w_003D = 0L;
		_0023_003DzVC9FBdo_003D = 0;
		Array.Clear(_0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D.Length);
		_0023_003Dzf4Pqh9s_003D = 1732584193u;
		_0023_003DzTFNDoh0_003D = 4023233417u;
		_0023_003DzraVZG9g_003D = 2562383102u;
		_0023_003DzRoqMfFc_003D = 271733878u;
		_0023_003Dz1SmHC4c_003D = 3285377520u;
		_0023_003DzmZWYhFQ_003D = 0;
		Array.Clear(_0023_003DzLtLprGE_003D, 0, _0023_003DzLtLprGE_003D.Length);
	}

	private static uint _0023_003Dzh_0024pVHET6pHyF0egy4czv2Co_EY9J(uint _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D, uint _0023_003DzwBouG0w_003D)
	{
		return (_0023_003DzjYYAPCA_003D & _0023_003DzVC9FBdo_003D) | (~_0023_003DzjYYAPCA_003D & _0023_003DzwBouG0w_003D);
	}

	private static uint _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(uint _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D, uint _0023_003DzwBouG0w_003D)
	{
		return _0023_003DzjYYAPCA_003D ^ _0023_003DzVC9FBdo_003D ^ _0023_003DzwBouG0w_003D;
	}

	private static uint _0023_003DzZSBc4UWnbhBnDWBHpqdXyIiKJf1EgX4FXt7XZhw_003D(uint _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D, uint _0023_003DzwBouG0w_003D)
	{
		return (_0023_003DzjYYAPCA_003D & _0023_003DzVC9FBdo_003D) | (_0023_003DzjYYAPCA_003D & _0023_003DzwBouG0w_003D) | (_0023_003DzVC9FBdo_003D & _0023_003DzwBouG0w_003D);
	}

	private void _0023_003Dzb_DPByRNdftaSSGwGUI69P8jXhjbMAF5UnM49lA_003D()
	{
		for (int i = 16; i < 80; i++)
		{
			uint num = _0023_003DzLtLprGE_003D[i - 3] ^ _0023_003DzLtLprGE_003D[i - 8] ^ _0023_003DzLtLprGE_003D[i - 14] ^ _0023_003DzLtLprGE_003D[i - 16];
			_0023_003DzLtLprGE_003D[i] = (num << 1) | (num >> 31);
		}
		uint num2 = _0023_003Dzf4Pqh9s_003D;
		uint num3 = _0023_003DzTFNDoh0_003D;
		uint num4 = _0023_003DzraVZG9g_003D;
		uint num5 = _0023_003DzRoqMfFc_003D;
		uint num6 = _0023_003Dz1SmHC4c_003D;
		int num7 = 0;
		for (int j = 0; j < 4; j++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003Dzh_0024pVHET6pHyF0egy4czv2Co_EY9J(num3, num4, num5) + _0023_003DzLtLprGE_003D[num7++] + 1518500249;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003Dzh_0024pVHET6pHyF0egy4czv2Co_EY9J(num2, num3, num4) + _0023_003DzLtLprGE_003D[num7++] + 1518500249;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003Dzh_0024pVHET6pHyF0egy4czv2Co_EY9J(num6, num2, num3) + _0023_003DzLtLprGE_003D[num7++] + 1518500249;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003Dzh_0024pVHET6pHyF0egy4czv2Co_EY9J(num5, num6, num2) + _0023_003DzLtLprGE_003D[num7++] + 1518500249;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003Dzh_0024pVHET6pHyF0egy4czv2Co_EY9J(num4, num5, num6) + _0023_003DzLtLprGE_003D[num7++] + 1518500249;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int k = 0; k < 4; k++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num3, num4, num5) + _0023_003DzLtLprGE_003D[num7++] + 1859775393;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num2, num3, num4) + _0023_003DzLtLprGE_003D[num7++] + 1859775393;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num6, num2, num3) + _0023_003DzLtLprGE_003D[num7++] + 1859775393;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num5, num6, num2) + _0023_003DzLtLprGE_003D[num7++] + 1859775393;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num4, num5, num6) + _0023_003DzLtLprGE_003D[num7++] + 1859775393;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int l = 0; l < 4; l++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003DzZSBc4UWnbhBnDWBHpqdXyIiKJf1EgX4FXt7XZhw_003D(num3, num4, num5) + _0023_003DzLtLprGE_003D[num7++]) + -1894007588);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003DzZSBc4UWnbhBnDWBHpqdXyIiKJf1EgX4FXt7XZhw_003D(num2, num3, num4) + _0023_003DzLtLprGE_003D[num7++]) + -1894007588);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003DzZSBc4UWnbhBnDWBHpqdXyIiKJf1EgX4FXt7XZhw_003D(num6, num2, num3) + _0023_003DzLtLprGE_003D[num7++]) + -1894007588);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003DzZSBc4UWnbhBnDWBHpqdXyIiKJf1EgX4FXt7XZhw_003D(num5, num6, num2) + _0023_003DzLtLprGE_003D[num7++]) + -1894007588);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003DzZSBc4UWnbhBnDWBHpqdXyIiKJf1EgX4FXt7XZhw_003D(num4, num5, num6) + _0023_003DzLtLprGE_003D[num7++]) + -1894007588);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int m = 0; m < 4; m++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num3, num4, num5) + _0023_003DzLtLprGE_003D[num7++]) + -899497514);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num2, num3, num4) + _0023_003DzLtLprGE_003D[num7++]) + -899497514);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num6, num2, num3) + _0023_003DzLtLprGE_003D[num7++]) + -899497514);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num5, num6, num2) + _0023_003DzLtLprGE_003D[num7++]) + -899497514);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003DzwhJqkjJPqgy9g9hnaKzMRBcO8AQu7NFFFzq7wZH_0024OKoE(num4, num5, num6) + _0023_003DzLtLprGE_003D[num7++]) + -899497514);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		_0023_003Dzf4Pqh9s_003D += num2;
		_0023_003DzTFNDoh0_003D += num3;
		_0023_003DzraVZG9g_003D += num4;
		_0023_003DzRoqMfFc_003D += num5;
		_0023_003Dz1SmHC4c_003D += num6;
		_0023_003DzmZWYhFQ_003D = 0;
		Array.Clear(_0023_003DzLtLprGE_003D, 0, 16);
	}

	private static void _0023_003DztlLSHAgvwJrxWqHWzLUnA_8kBJPY5qaUvjpDiTbsIbGn(uint _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D] = (byte)(_0023_003DzjYYAPCA_003D >> 24);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 1] = (byte)(_0023_003DzjYYAPCA_003D >> 16);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 2] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 3] = (byte)_0023_003DzjYYAPCA_003D;
	}

	private static uint _0023_003DzMK0mnFF7KP28X4Buk7SztGyxhki9(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		return (uint)((_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D] << 24) | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 1] << 16) | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 2] << 8) | _0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 3]);
	}

	public _0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D _0023_003Dz8RCSIdHrgW63kkSenIN4WE9h5pxtBm7i_Q_003D_003D()
	{
		return new _0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D(this);
	}

	public void _0023_003Dz9itLC3gyA3iulgQh5rnw4esEc5bbTd92UA_003D_003D(_0023_003Dqx7hcqAtUOfazww1XKs1cq_0024kjHy44b8nkFy9e8tqjQD4_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzfQvnWet7tuxWaLjeMnznJE7BxFjn(_0023_003DzjYYAPCA_003D);
	}
}
