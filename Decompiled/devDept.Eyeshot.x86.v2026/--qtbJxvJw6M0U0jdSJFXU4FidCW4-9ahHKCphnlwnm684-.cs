using System;

internal sealed class _0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D
{
	private byte[] _0023_003Dzq80RbjQ_003D;

	private int _0023_003DzZzVr6_0024U_003D;

	private long _0023_003Dz7hRN5Rg_003D;

	private uint _0023_003DzcbLoSrg_003D;

	private uint _0023_003DzqMLoHoQ_003D;

	private uint _0023_003DzuwE9t4w_003D;

	private uint _0023_003DzoyRBT1A_003D;

	private uint _0023_003DzLaPeX80_003D;

	private uint[] _0023_003DzKyPCKaY_003D = new uint[80];

	private int _0023_003DzoVpU9JU_003D;

	public _0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D()
	{
		_0023_003Dzq80RbjQ_003D = new byte[4];
		_0023_003DznnDS4tKQ954CxUd_8mKsDq7d3nhEIDyJIg_003D_003D();
	}

	public _0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D(_0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzYvCB3eblLGZUcB852HpYUBMJGmh7(_0023_003Dzq80RbjQ_003D);
	}

	public void _0023_003Dz5tcggudTpD_0024vA3SNdJ_aM_00240_003D(byte _0023_003Dzq80RbjQ_003D)
	{
		this._0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D++] = _0023_003Dzq80RbjQ_003D;
		if (_0023_003DzZzVr6_0024U_003D == this._0023_003Dzq80RbjQ_003D.Length)
		{
			_0023_003DzIptxeM_6tmonWW1GTrPffDg_003D(this._0023_003Dzq80RbjQ_003D, 0);
			_0023_003DzZzVr6_0024U_003D = 0;
		}
		_0023_003Dz7hRN5Rg_003D++;
	}

	public void _0023_003Dzs2tTTv3faR1MKOKEhRP8WZSLCRiMeBIs5ADjMew_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003Dz7hRN5Rg_003D = Math.Max(0, _0023_003Dz7hRN5Rg_003D);
		int i = 0;
		if (this._0023_003DzZzVr6_0024U_003D != 0)
		{
			while (i < _0023_003Dz7hRN5Rg_003D)
			{
				this._0023_003Dzq80RbjQ_003D[this._0023_003DzZzVr6_0024U_003D++] = _0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + i++];
				if (this._0023_003DzZzVr6_0024U_003D == 4)
				{
					_0023_003DzIptxeM_6tmonWW1GTrPffDg_003D(this._0023_003Dzq80RbjQ_003D, 0);
					this._0023_003DzZzVr6_0024U_003D = 0;
					break;
				}
			}
		}
		for (int num = ((_0023_003Dz7hRN5Rg_003D - i) & -4) + i; i < num; i += 4)
		{
			_0023_003DzIptxeM_6tmonWW1GTrPffDg_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D + i);
		}
		while (i < _0023_003Dz7hRN5Rg_003D)
		{
			this._0023_003Dzq80RbjQ_003D[this._0023_003DzZzVr6_0024U_003D++] = _0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + i++];
		}
		this._0023_003Dz7hRN5Rg_003D += _0023_003Dz7hRN5Rg_003D;
	}

	public void _0023_003DzO8qCbYx0VVBN0a5jhB4m9PHvBo7s0qj9pcgGi_Y_003D()
	{
		long num = _0023_003Dz7hRN5Rg_003D << 3;
		_0023_003Dz5tcggudTpD_0024vA3SNdJ_aM_00240_003D(128);
		while (_0023_003DzZzVr6_0024U_003D != 0)
		{
			_0023_003Dz5tcggudTpD_0024vA3SNdJ_aM_00240_003D(0);
		}
		_0023_003DzDIQSFxZuyYxDej_8Tg_003D_003D(num);
		_0023_003Dz9txcQbl_0024TrgZwJPSzPuI9xuTgWF9WKU_x712hM0_003D();
	}

	public int _0023_003DzFWi7PFoqUAsL8iyeDEtZld8_003D()
	{
		return 64;
	}

	private void _0023_003DzYvCB3eblLGZUcB852HpYUBMJGmh7(_0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D _0023_003Dzq80RbjQ_003D)
	{
		this._0023_003Dzq80RbjQ_003D = new byte[_0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D.Length];
		Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D, 0, this._0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D.Length);
		_0023_003DzZzVr6_0024U_003D = _0023_003Dzq80RbjQ_003D._0023_003DzZzVr6_0024U_003D;
		_0023_003Dz7hRN5Rg_003D = _0023_003Dzq80RbjQ_003D._0023_003Dz7hRN5Rg_003D;
		_0023_003DzcbLoSrg_003D = _0023_003Dzq80RbjQ_003D._0023_003DzcbLoSrg_003D;
		_0023_003DzqMLoHoQ_003D = _0023_003Dzq80RbjQ_003D._0023_003DzqMLoHoQ_003D;
		_0023_003DzuwE9t4w_003D = _0023_003Dzq80RbjQ_003D._0023_003DzuwE9t4w_003D;
		_0023_003DzoyRBT1A_003D = _0023_003Dzq80RbjQ_003D._0023_003DzoyRBT1A_003D;
		_0023_003DzLaPeX80_003D = _0023_003Dzq80RbjQ_003D._0023_003DzLaPeX80_003D;
		Array.Copy(_0023_003Dzq80RbjQ_003D._0023_003DzKyPCKaY_003D, 0, _0023_003DzKyPCKaY_003D, 0, _0023_003Dzq80RbjQ_003D._0023_003DzKyPCKaY_003D.Length);
		_0023_003DzoVpU9JU_003D = _0023_003Dzq80RbjQ_003D._0023_003DzoVpU9JU_003D;
	}

	public int _0023_003Dz2_0024MhPH_0024NNHL6PWd812iQaYc_003D()
	{
		return 20;
	}

	public void _0023_003DzIptxeM_6tmonWW1GTrPffDg_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DzKyPCKaY_003D[_0023_003DzoVpU9JU_003D] = _0023_003DzLS5EEbTYQQADUWkiwSM9Xro_nAIG(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
		if (++_0023_003DzoVpU9JU_003D == 16)
		{
			_0023_003Dz9txcQbl_0024TrgZwJPSzPuI9xuTgWF9WKU_x712hM0_003D();
		}
	}

	public void _0023_003DzDIQSFxZuyYxDej_8Tg_003D_003D(long _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003DzoVpU9JU_003D > 14)
		{
			_0023_003Dz9txcQbl_0024TrgZwJPSzPuI9xuTgWF9WKU_x712hM0_003D();
		}
		_0023_003DzKyPCKaY_003D[14] = (uint)((ulong)_0023_003Dzq80RbjQ_003D >> 32);
		_0023_003DzKyPCKaY_003D[15] = (uint)_0023_003Dzq80RbjQ_003D;
	}

	public int _0023_003Dz33B2_0024v6jjPwaWJdWfFIjL3bEZs7o3cF8pzOotO3w6Qb6(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DzO8qCbYx0VVBN0a5jhB4m9PHvBo7s0qj9pcgGi_Y_003D();
		_0023_003DzkYMgFdPiTqIwskM1rHgc0WSdl2tZJIamIEYS0Ovm2qNc(_0023_003DzcbLoSrg_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
		_0023_003DzkYMgFdPiTqIwskM1rHgc0WSdl2tZJIamIEYS0Ovm2qNc(_0023_003DzqMLoHoQ_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D + 4);
		_0023_003DzkYMgFdPiTqIwskM1rHgc0WSdl2tZJIamIEYS0Ovm2qNc(_0023_003DzuwE9t4w_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D + 8);
		_0023_003DzkYMgFdPiTqIwskM1rHgc0WSdl2tZJIamIEYS0Ovm2qNc(_0023_003DzoyRBT1A_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D + 12);
		_0023_003DzkYMgFdPiTqIwskM1rHgc0WSdl2tZJIamIEYS0Ovm2qNc(_0023_003DzLaPeX80_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D + 16);
		_0023_003DznnDS4tKQ954CxUd_8mKsDq7d3nhEIDyJIg_003D_003D();
		return 20;
	}

	public void _0023_003DznnDS4tKQ954CxUd_8mKsDq7d3nhEIDyJIg_003D_003D()
	{
		_0023_003Dz7hRN5Rg_003D = 0L;
		_0023_003DzZzVr6_0024U_003D = 0;
		Array.Clear(_0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D.Length);
		_0023_003DzcbLoSrg_003D = 1732584193u;
		_0023_003DzqMLoHoQ_003D = 4023233417u;
		_0023_003DzuwE9t4w_003D = 2562383102u;
		_0023_003DzoyRBT1A_003D = 271733878u;
		_0023_003DzLaPeX80_003D = 3285377520u;
		_0023_003DzoVpU9JU_003D = 0;
		Array.Clear(_0023_003DzKyPCKaY_003D, 0, _0023_003DzKyPCKaY_003D.Length);
	}

	private static uint _0023_003Dzw2uHKUGRQZpH_00245u9BvTqcgn9ygud(uint _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D, uint _0023_003Dz7hRN5Rg_003D)
	{
		return (_0023_003Dzq80RbjQ_003D & _0023_003DzZzVr6_0024U_003D) | (~_0023_003Dzq80RbjQ_003D & _0023_003Dz7hRN5Rg_003D);
	}

	private static uint _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(uint _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D, uint _0023_003Dz7hRN5Rg_003D)
	{
		return _0023_003Dzq80RbjQ_003D ^ _0023_003DzZzVr6_0024U_003D ^ _0023_003Dz7hRN5Rg_003D;
	}

	private static uint _0023_003DziY6ZAQZg1Aq4hAIVWo9twbWKus5UI1UaIpTN7xQ_003D(uint _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D, uint _0023_003Dz7hRN5Rg_003D)
	{
		return (_0023_003Dzq80RbjQ_003D & _0023_003DzZzVr6_0024U_003D) | (_0023_003Dzq80RbjQ_003D & _0023_003Dz7hRN5Rg_003D) | (_0023_003DzZzVr6_0024U_003D & _0023_003Dz7hRN5Rg_003D);
	}

	private void _0023_003Dz9txcQbl_0024TrgZwJPSzPuI9xuTgWF9WKU_x712hM0_003D()
	{
		for (int i = 16; i < 80; i++)
		{
			uint num = _0023_003DzKyPCKaY_003D[i - 3] ^ _0023_003DzKyPCKaY_003D[i - 8] ^ _0023_003DzKyPCKaY_003D[i - 14] ^ _0023_003DzKyPCKaY_003D[i - 16];
			_0023_003DzKyPCKaY_003D[i] = (num << 1) | (num >> 31);
		}
		uint num2 = _0023_003DzcbLoSrg_003D;
		uint num3 = _0023_003DzqMLoHoQ_003D;
		uint num4 = _0023_003DzuwE9t4w_003D;
		uint num5 = _0023_003DzoyRBT1A_003D;
		uint num6 = _0023_003DzLaPeX80_003D;
		int num7 = 0;
		for (int j = 0; j < 4; j++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003Dzw2uHKUGRQZpH_00245u9BvTqcgn9ygud(num3, num4, num5) + _0023_003DzKyPCKaY_003D[num7++] + 1518500249;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003Dzw2uHKUGRQZpH_00245u9BvTqcgn9ygud(num2, num3, num4) + _0023_003DzKyPCKaY_003D[num7++] + 1518500249;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003Dzw2uHKUGRQZpH_00245u9BvTqcgn9ygud(num6, num2, num3) + _0023_003DzKyPCKaY_003D[num7++] + 1518500249;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003Dzw2uHKUGRQZpH_00245u9BvTqcgn9ygud(num5, num6, num2) + _0023_003DzKyPCKaY_003D[num7++] + 1518500249;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003Dzw2uHKUGRQZpH_00245u9BvTqcgn9ygud(num4, num5, num6) + _0023_003DzKyPCKaY_003D[num7++] + 1518500249;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int k = 0; k < 4; k++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num3, num4, num5) + _0023_003DzKyPCKaY_003D[num7++] + 1859775393;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num2, num3, num4) + _0023_003DzKyPCKaY_003D[num7++] + 1859775393;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num6, num2, num3) + _0023_003DzKyPCKaY_003D[num7++] + 1859775393;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num5, num6, num2) + _0023_003DzKyPCKaY_003D[num7++] + 1859775393;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num4, num5, num6) + _0023_003DzKyPCKaY_003D[num7++] + 1859775393;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int l = 0; l < 4; l++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003DziY6ZAQZg1Aq4hAIVWo9twbWKus5UI1UaIpTN7xQ_003D(num3, num4, num5) + _0023_003DzKyPCKaY_003D[num7++]) + -1894007588);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003DziY6ZAQZg1Aq4hAIVWo9twbWKus5UI1UaIpTN7xQ_003D(num2, num3, num4) + _0023_003DzKyPCKaY_003D[num7++]) + -1894007588);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003DziY6ZAQZg1Aq4hAIVWo9twbWKus5UI1UaIpTN7xQ_003D(num6, num2, num3) + _0023_003DzKyPCKaY_003D[num7++]) + -1894007588);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003DziY6ZAQZg1Aq4hAIVWo9twbWKus5UI1UaIpTN7xQ_003D(num5, num6, num2) + _0023_003DzKyPCKaY_003D[num7++]) + -1894007588);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003DziY6ZAQZg1Aq4hAIVWo9twbWKus5UI1UaIpTN7xQ_003D(num4, num5, num6) + _0023_003DzKyPCKaY_003D[num7++]) + -1894007588);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int m = 0; m < 4; m++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num3, num4, num5) + _0023_003DzKyPCKaY_003D[num7++]) + -899497514);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num2, num3, num4) + _0023_003DzKyPCKaY_003D[num7++]) + -899497514);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num6, num2, num3) + _0023_003DzKyPCKaY_003D[num7++]) + -899497514);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num5, num6, num2) + _0023_003DzKyPCKaY_003D[num7++]) + -899497514);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003DzHtjx091BvHlXQvwOz9CJclLyIUSXv9ol_0024azeMBMXl34J(num4, num5, num6) + _0023_003DzKyPCKaY_003D[num7++]) + -899497514);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		_0023_003DzcbLoSrg_003D += num2;
		_0023_003DzqMLoHoQ_003D += num3;
		_0023_003DzuwE9t4w_003D += num4;
		_0023_003DzoyRBT1A_003D += num5;
		_0023_003DzLaPeX80_003D += num6;
		_0023_003DzoVpU9JU_003D = 0;
		Array.Clear(_0023_003DzKyPCKaY_003D, 0, 16);
	}

	private static void _0023_003DzkYMgFdPiTqIwskM1rHgc0WSdl2tZJIamIEYS0Ovm2qNc(uint _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D] = (byte)(_0023_003Dzq80RbjQ_003D >> 24);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 1] = (byte)(_0023_003Dzq80RbjQ_003D >> 16);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 2] = (byte)(_0023_003Dzq80RbjQ_003D >> 8);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 3] = (byte)_0023_003Dzq80RbjQ_003D;
	}

	private static uint _0023_003DzLS5EEbTYQQADUWkiwSM9Xro_nAIG(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		return (uint)((_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D] << 24) | (_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + 1] << 16) | (_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + 2] << 8) | _0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + 3]);
	}

	public _0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D _0023_003DzkLEOY59VzcNcm8jKWeZYsPZudlDAyW_c1w_003D_003D()
	{
		return new _0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D(this);
	}

	public void _0023_003DzT_0024GDhJwzhZAIVMvwmaqaYdKS_0024ID0wgaCaw_003D_003D(_0023_003DqtbJxvJw6M0U0jdSJFXU4FidCW4_00249ahHKCphnlwnm684_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzYvCB3eblLGZUcB852HpYUBMJGmh7(_0023_003Dzq80RbjQ_003D);
	}
}
