using System;

internal sealed class _0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D
{
	private byte[] _0023_003Dz9jrlnWk_003D;

	private int _0023_003DzBxpHhQ0_003D;

	private long _0023_003Dztgqm2r4_003D;

	private uint _0023_003DzzKDx05I_003D;

	private uint _0023_003Dz3iPku7s_003D;

	private uint _0023_003Dz2X8kE24_003D;

	private uint _0023_003DzJGsRSpg_003D;

	private uint _0023_003Dz9I8ZVlc_003D;

	private uint[] _0023_003DzgqvoyJk_003D = new uint[80];

	private int _0023_003DzoEGLyuM_003D;

	public _0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D()
	{
		_0023_003Dz9jrlnWk_003D = new byte[4];
		_0023_003DzAlfLydtiZIMZaqEo__0024lTz9lRsks9pgD_00246g_003D_003D();
	}

	public _0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D(_0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dzp4i0MctNzBRRjec2dYkPNKlnGnZx(_0023_003Dz9jrlnWk_003D);
	}

	public void _0023_003DzjBs1tFjgRPINONTh9a_0024_HbQ_003D(byte _0023_003Dz9jrlnWk_003D)
	{
		this._0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D++] = _0023_003Dz9jrlnWk_003D;
		if (_0023_003DzBxpHhQ0_003D == this._0023_003Dz9jrlnWk_003D.Length)
		{
			_0023_003DzbZ_2_00242apX7bm5msY0a_OxD8_003D(this._0023_003Dz9jrlnWk_003D, 0);
			_0023_003DzBxpHhQ0_003D = 0;
		}
		_0023_003Dztgqm2r4_003D++;
	}

	public void _0023_003DzDw1Qy8sRKJy8cMhtROXGZ7sHI_GMxJKo_0024mLPPew_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		_0023_003Dztgqm2r4_003D = Math.Max(0, _0023_003Dztgqm2r4_003D);
		int i = 0;
		if (this._0023_003DzBxpHhQ0_003D != 0)
		{
			while (i < _0023_003Dztgqm2r4_003D)
			{
				this._0023_003Dz9jrlnWk_003D[this._0023_003DzBxpHhQ0_003D++] = _0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + i++];
				if (this._0023_003DzBxpHhQ0_003D == 4)
				{
					_0023_003DzbZ_2_00242apX7bm5msY0a_OxD8_003D(this._0023_003Dz9jrlnWk_003D, 0);
					this._0023_003DzBxpHhQ0_003D = 0;
					break;
				}
			}
		}
		for (int num = ((_0023_003Dztgqm2r4_003D - i) & -4) + i; i < num; i += 4)
		{
			_0023_003DzbZ_2_00242apX7bm5msY0a_OxD8_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D + i);
		}
		while (i < _0023_003Dztgqm2r4_003D)
		{
			this._0023_003Dz9jrlnWk_003D[this._0023_003DzBxpHhQ0_003D++] = _0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + i++];
		}
		this._0023_003Dztgqm2r4_003D += _0023_003Dztgqm2r4_003D;
	}

	public void _0023_003Dz2DmYOpvxQ2HgfiAEJZnBT73hWuZU3V6gnHpJ37s_003D()
	{
		long num = _0023_003Dztgqm2r4_003D << 3;
		_0023_003DzjBs1tFjgRPINONTh9a_0024_HbQ_003D(128);
		while (_0023_003DzBxpHhQ0_003D != 0)
		{
			_0023_003DzjBs1tFjgRPINONTh9a_0024_HbQ_003D(0);
		}
		_0023_003DzehxDTQ8Cnid_0024Uun0kA_003D_003D(num);
		_0023_003DzTUqGwjEjlMlE3IhYfpOdHMCwpN2pcebs7BhxVQM_003D();
	}

	public int _0023_003DzJ7BOLxYkWGXoDSggb0E5c6g_003D()
	{
		return 64;
	}

	private void _0023_003Dzp4i0MctNzBRRjec2dYkPNKlnGnZx(_0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D _0023_003Dz9jrlnWk_003D)
	{
		this._0023_003Dz9jrlnWk_003D = new byte[_0023_003Dz9jrlnWk_003D._0023_003Dz9jrlnWk_003D.Length];
		Buffer.BlockCopy(_0023_003Dz9jrlnWk_003D._0023_003Dz9jrlnWk_003D, 0, this._0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D._0023_003Dz9jrlnWk_003D.Length);
		_0023_003DzBxpHhQ0_003D = _0023_003Dz9jrlnWk_003D._0023_003DzBxpHhQ0_003D;
		_0023_003Dztgqm2r4_003D = _0023_003Dz9jrlnWk_003D._0023_003Dztgqm2r4_003D;
		_0023_003DzzKDx05I_003D = _0023_003Dz9jrlnWk_003D._0023_003DzzKDx05I_003D;
		_0023_003Dz3iPku7s_003D = _0023_003Dz9jrlnWk_003D._0023_003Dz3iPku7s_003D;
		_0023_003Dz2X8kE24_003D = _0023_003Dz9jrlnWk_003D._0023_003Dz2X8kE24_003D;
		_0023_003DzJGsRSpg_003D = _0023_003Dz9jrlnWk_003D._0023_003DzJGsRSpg_003D;
		_0023_003Dz9I8ZVlc_003D = _0023_003Dz9jrlnWk_003D._0023_003Dz9I8ZVlc_003D;
		Array.Copy(_0023_003Dz9jrlnWk_003D._0023_003DzgqvoyJk_003D, 0, _0023_003DzgqvoyJk_003D, 0, _0023_003Dz9jrlnWk_003D._0023_003DzgqvoyJk_003D.Length);
		_0023_003DzoEGLyuM_003D = _0023_003Dz9jrlnWk_003D._0023_003DzoEGLyuM_003D;
	}

	public int _0023_003Dz_0024Ws_0024TTR1FRwt5YA2ammroAo_003D()
	{
		return 20;
	}

	public void _0023_003DzbZ_2_00242apX7bm5msY0a_OxD8_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DzgqvoyJk_003D[_0023_003DzoEGLyuM_003D] = _0023_003DzNECDxfTs6H0xIMUsHLxPF6xlDNIu(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
		if (++_0023_003DzoEGLyuM_003D == 16)
		{
			_0023_003DzTUqGwjEjlMlE3IhYfpOdHMCwpN2pcebs7BhxVQM_003D();
		}
	}

	public void _0023_003DzehxDTQ8Cnid_0024Uun0kA_003D_003D(long _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003DzoEGLyuM_003D > 14)
		{
			_0023_003DzTUqGwjEjlMlE3IhYfpOdHMCwpN2pcebs7BhxVQM_003D();
		}
		_0023_003DzgqvoyJk_003D[14] = (uint)((ulong)_0023_003Dz9jrlnWk_003D >> 32);
		_0023_003DzgqvoyJk_003D[15] = (uint)_0023_003Dz9jrlnWk_003D;
	}

	public int _0023_003Dzk_QnmXuI3vamaNlm1Hm8K8HmYO62CEoxP5DCNht4qlLS(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz2DmYOpvxQ2HgfiAEJZnBT73hWuZU3V6gnHpJ37s_003D();
		_0023_003DzBYZpsv0iL3v9tJku16EE12uKPvp_0024h161MYjJDpDhCkzc(_0023_003DzzKDx05I_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
		_0023_003DzBYZpsv0iL3v9tJku16EE12uKPvp_0024h161MYjJDpDhCkzc(_0023_003Dz3iPku7s_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D + 4);
		_0023_003DzBYZpsv0iL3v9tJku16EE12uKPvp_0024h161MYjJDpDhCkzc(_0023_003Dz2X8kE24_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D + 8);
		_0023_003DzBYZpsv0iL3v9tJku16EE12uKPvp_0024h161MYjJDpDhCkzc(_0023_003DzJGsRSpg_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D + 12);
		_0023_003DzBYZpsv0iL3v9tJku16EE12uKPvp_0024h161MYjJDpDhCkzc(_0023_003Dz9I8ZVlc_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D + 16);
		_0023_003DzAlfLydtiZIMZaqEo__0024lTz9lRsks9pgD_00246g_003D_003D();
		return 20;
	}

	public void _0023_003DzAlfLydtiZIMZaqEo__0024lTz9lRsks9pgD_00246g_003D_003D()
	{
		_0023_003Dztgqm2r4_003D = 0L;
		_0023_003DzBxpHhQ0_003D = 0;
		Array.Clear(_0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D.Length);
		_0023_003DzzKDx05I_003D = 1732584193u;
		_0023_003Dz3iPku7s_003D = 4023233417u;
		_0023_003Dz2X8kE24_003D = 2562383102u;
		_0023_003DzJGsRSpg_003D = 271733878u;
		_0023_003Dz9I8ZVlc_003D = 3285377520u;
		_0023_003DzoEGLyuM_003D = 0;
		Array.Clear(_0023_003DzgqvoyJk_003D, 0, _0023_003DzgqvoyJk_003D.Length);
	}

	private static uint _0023_003DzRm1NgD_qkOfdiZllERAnLZlYeAEN(uint _0023_003Dz9jrlnWk_003D, uint _0023_003DzBxpHhQ0_003D, uint _0023_003Dztgqm2r4_003D)
	{
		return (_0023_003Dz9jrlnWk_003D & _0023_003DzBxpHhQ0_003D) | (~_0023_003Dz9jrlnWk_003D & _0023_003Dztgqm2r4_003D);
	}

	private static uint _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(uint _0023_003Dz9jrlnWk_003D, uint _0023_003DzBxpHhQ0_003D, uint _0023_003Dztgqm2r4_003D)
	{
		return _0023_003Dz9jrlnWk_003D ^ _0023_003DzBxpHhQ0_003D ^ _0023_003Dztgqm2r4_003D;
	}

	private static uint _0023_003Dzmny38TAE5TxVZTAgvwrTcDEoD4zRNF1YpeTYOmU_003D(uint _0023_003Dz9jrlnWk_003D, uint _0023_003DzBxpHhQ0_003D, uint _0023_003Dztgqm2r4_003D)
	{
		return (_0023_003Dz9jrlnWk_003D & _0023_003DzBxpHhQ0_003D) | (_0023_003Dz9jrlnWk_003D & _0023_003Dztgqm2r4_003D) | (_0023_003DzBxpHhQ0_003D & _0023_003Dztgqm2r4_003D);
	}

	private void _0023_003DzTUqGwjEjlMlE3IhYfpOdHMCwpN2pcebs7BhxVQM_003D()
	{
		for (int i = 16; i < 80; i++)
		{
			uint num = _0023_003DzgqvoyJk_003D[i - 3] ^ _0023_003DzgqvoyJk_003D[i - 8] ^ _0023_003DzgqvoyJk_003D[i - 14] ^ _0023_003DzgqvoyJk_003D[i - 16];
			_0023_003DzgqvoyJk_003D[i] = (num << 1) | (num >> 31);
		}
		uint num2 = _0023_003DzzKDx05I_003D;
		uint num3 = _0023_003Dz3iPku7s_003D;
		uint num4 = _0023_003Dz2X8kE24_003D;
		uint num5 = _0023_003DzJGsRSpg_003D;
		uint num6 = _0023_003Dz9I8ZVlc_003D;
		int num7 = 0;
		for (int j = 0; j < 4; j++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003DzRm1NgD_qkOfdiZllERAnLZlYeAEN(num3, num4, num5) + _0023_003DzgqvoyJk_003D[num7++] + 1518500249;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003DzRm1NgD_qkOfdiZllERAnLZlYeAEN(num2, num3, num4) + _0023_003DzgqvoyJk_003D[num7++] + 1518500249;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003DzRm1NgD_qkOfdiZllERAnLZlYeAEN(num6, num2, num3) + _0023_003DzgqvoyJk_003D[num7++] + 1518500249;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003DzRm1NgD_qkOfdiZllERAnLZlYeAEN(num5, num6, num2) + _0023_003DzgqvoyJk_003D[num7++] + 1518500249;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003DzRm1NgD_qkOfdiZllERAnLZlYeAEN(num4, num5, num6) + _0023_003DzgqvoyJk_003D[num7++] + 1518500249;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int k = 0; k < 4; k++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num3, num4, num5) + _0023_003DzgqvoyJk_003D[num7++] + 1859775393;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num2, num3, num4) + _0023_003DzgqvoyJk_003D[num7++] + 1859775393;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num6, num2, num3) + _0023_003DzgqvoyJk_003D[num7++] + 1859775393;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num5, num6, num2) + _0023_003DzgqvoyJk_003D[num7++] + 1859775393;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num4, num5, num6) + _0023_003DzgqvoyJk_003D[num7++] + 1859775393;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int l = 0; l < 4; l++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003Dzmny38TAE5TxVZTAgvwrTcDEoD4zRNF1YpeTYOmU_003D(num3, num4, num5) + _0023_003DzgqvoyJk_003D[num7++]) + -1894007588);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003Dzmny38TAE5TxVZTAgvwrTcDEoD4zRNF1YpeTYOmU_003D(num2, num3, num4) + _0023_003DzgqvoyJk_003D[num7++]) + -1894007588);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003Dzmny38TAE5TxVZTAgvwrTcDEoD4zRNF1YpeTYOmU_003D(num6, num2, num3) + _0023_003DzgqvoyJk_003D[num7++]) + -1894007588);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003Dzmny38TAE5TxVZTAgvwrTcDEoD4zRNF1YpeTYOmU_003D(num5, num6, num2) + _0023_003DzgqvoyJk_003D[num7++]) + -1894007588);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003Dzmny38TAE5TxVZTAgvwrTcDEoD4zRNF1YpeTYOmU_003D(num4, num5, num6) + _0023_003DzgqvoyJk_003D[num7++]) + -1894007588);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int m = 0; m < 4; m++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num3, num4, num5) + _0023_003DzgqvoyJk_003D[num7++]) + -899497514);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num2, num3, num4) + _0023_003DzgqvoyJk_003D[num7++]) + -899497514);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num6, num2, num3) + _0023_003DzgqvoyJk_003D[num7++]) + -899497514);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num5, num6, num2) + _0023_003DzgqvoyJk_003D[num7++]) + -899497514);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003DzzSZbGuY_78mcqt7CS48bHmIdnh3SiCQouUhkpmgqCTTc(num4, num5, num6) + _0023_003DzgqvoyJk_003D[num7++]) + -899497514);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		_0023_003DzzKDx05I_003D += num2;
		_0023_003Dz3iPku7s_003D += num3;
		_0023_003Dz2X8kE24_003D += num4;
		_0023_003DzJGsRSpg_003D += num5;
		_0023_003Dz9I8ZVlc_003D += num6;
		_0023_003DzoEGLyuM_003D = 0;
		Array.Clear(_0023_003DzgqvoyJk_003D, 0, 16);
	}

	private static void _0023_003DzBYZpsv0iL3v9tJku16EE12uKPvp_0024h161MYjJDpDhCkzc(uint _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D] = (byte)(_0023_003Dz9jrlnWk_003D >> 24);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 1] = (byte)(_0023_003Dz9jrlnWk_003D >> 16);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 2] = (byte)(_0023_003Dz9jrlnWk_003D >> 8);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 3] = (byte)_0023_003Dz9jrlnWk_003D;
	}

	private static uint _0023_003DzNECDxfTs6H0xIMUsHLxPF6xlDNIu(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		return (uint)((_0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D] << 24) | (_0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + 1] << 16) | (_0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + 2] << 8) | _0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + 3]);
	}

	public _0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D _0023_003Dz8wZEy9Ue2gMzG3ij4LaO2wsGUzOSheYfCg_003D_003D()
	{
		return new _0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D(this);
	}

	public void _0023_003DzKPB_ovYRQ1bb2NzG3COIe5ceT_X4XyPHiQ_003D_003D(_0023_003DqUR7_0024aTHoiijy1rATVvJvalCC5cJ1yu5bgqNvWUN6IS8_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dzp4i0MctNzBRRjec2dYkPNKlnGnZx(_0023_003Dz9jrlnWk_003D);
	}
}
