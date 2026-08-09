using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal sealed class _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D : _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCRfBVkIJ6g7sMnXA5H8CU9w_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SecureString _0023_003Dzq80RbjQ_003D = new SecureString();

	[SpecialName]
	public int _0023_003DzIQalVa_aHfzVUQ3sYhbar_Ni62EZeZpf6UgqP7i2m42SUid_ZFLEZaMQxAbTpULH8r1y2JDeT61FxKPKgpApviA2CLz8()
	{
		return _0023_003Dzq80RbjQ_003D.Length;
	}

	public _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCRfBVkIJ6g7sMnXA5H8CU9w_003D _0023_003DztnL5NCe_pHPx5OQaU_0024cK49zsURlT_jH4BcsngCyq3vSE_0024mF9TL_aHtzqvi4W75Qsru_0024LIdACiS2N5zh0HQ_003D_003D()
	{
		return new _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D();
	}

	public void _0023_003DzuExStp_0024rmmlysNxz4DRwMvkk7nCfcrnBvgBIDaV_IiRtycy6Z94SpM7etFS22iedgWtajcHK1ElY(int _0023_003Dzq80RbjQ_003D, out byte _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D < 0 || _0023_003Dzq80RbjQ_003D >= _0023_003DzIQalVa_aHfzVUQ3sYhbar_Ni62EZeZpf6UgqP7i2m42SUid_ZFLEZaMQxAbTpULH8r1y2JDeT61FxKPKgpApviA2CLz8())
		{
			throw new ArgumentOutOfRangeException();
		}
		IntPtr intPtr = IntPtr.Zero;
		char c = '\0';
		try
		{
			intPtr = Marshal.SecureStringToGlobalAllocUnicode(this._0023_003Dzq80RbjQ_003D);
			c = (char)Marshal.ReadInt16(intPtr, _0023_003Dzq80RbjQ_003D * 2);
			_0023_003DzZzVr6_0024U_003D = _0023_003Dzx2xvpU2zdPi1UogTEUIjwemYmMNp_BPr4A_003D_003D(c, _0023_003Dzq80RbjQ_003D);
		}
		finally
		{
			_0023_003DqJTjaQmhkW8F60LVdPhnyDwAhChaGibjTaoC8s8wvFVU_003D._0023_003Dz89hvaDs7QuK1oCVXdB3lXcNGNj4DwuOrFzLOoH8_003D(ref c);
			if (intPtr != IntPtr.Zero)
			{
				Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
			}
		}
	}

	public void _0023_003DznuGnbDrfmx_0024J0fjFtOULWj4_E76__00243bC66oqcos5vODkk66EtFukcnpeFM6UCBnXQPDu4bnhXef8uKg7LR1fE1w_003D(int _0023_003Dzq80RbjQ_003D, ref byte _0023_003DzZzVr6_0024U_003D)
	{
		int num = this._0023_003Dzq80RbjQ_003D.Length;
		while (true)
		{
			if (num > _0023_003Dzq80RbjQ_003D)
			{
				this._0023_003Dzq80RbjQ_003D.SetAt(_0023_003Dzq80RbjQ_003D, _0023_003Dz1cSgBL3IGMGiCAZFae4CUTB6gczbjGhyBRKoxxCAzSqq(_0023_003DzZzVr6_0024U_003D, _0023_003Dzq80RbjQ_003D));
				return;
			}
			if (num == _0023_003Dzq80RbjQ_003D)
			{
				break;
			}
			this._0023_003Dzq80RbjQ_003D.AppendChar(_0023_003Dz1cSgBL3IGMGiCAZFae4CUTB6gczbjGhyBRKoxxCAzSqq(0, num));
			num++;
		}
		this._0023_003Dzq80RbjQ_003D.AppendChar(_0023_003Dz1cSgBL3IGMGiCAZFae4CUTB6gczbjGhyBRKoxxCAzSqq(_0023_003DzZzVr6_0024U_003D, num));
	}

	private static char _0023_003Dz1cSgBL3IGMGiCAZFae4CUTB6gczbjGhyBRKoxxCAzSqq(byte _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		return (char)(_0023_003Dzq80RbjQ_003D + 1);
	}

	private static byte _0023_003Dzx2xvpU2zdPi1UogTEUIjwemYmMNp_BPr4A_003D_003D(char _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		return (byte)(_0023_003Dzq80RbjQ_003D - 1);
	}

	public void _0023_003DzXCtz2cJOCM0S8YNTRzENhFoYOLMACGWGCx0qUJKL2LukaKYnpBR_0024lwc4MTgbUAks1lWGL8s_003D()
	{
		_0023_003Dzq80RbjQ_003D.Clear();
	}

	public void Dispose()
	{
		_0023_003Dzq80RbjQ_003D.Dispose();
		_0023_003Dzq80RbjQ_003D = null;
	}
}
