using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal sealed class _0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D : _0023_003DqI_0024qdFH6tAfuROz8_nUFyO5dNm2DCLf_0024KwxG_1CUeCc0_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SecureString _0023_003DziDLVpbY_003D = new SecureString();

	[SpecialName]
	public int _0023_003DzX67Fgyn0f8jfep_0024QyxTcb0WDhzzd3D47UExChgN5NonIRwIhuJ7EwC78_0024QuqUYNLW_0024sxA0f1cQFs_l1j5rUBPUiu2HAq()
	{
		return _0023_003DziDLVpbY_003D.Length;
	}

	public _0023_003DqI_0024qdFH6tAfuROz8_nUFyO5dNm2DCLf_0024KwxG_1CUeCc0_003D _0023_003DzozyYenSNTlw4tlHzXsUpr9kQaRzleXVFr7fhlPIntuER6kEF4OiVIBZrpixFuuRi0izUer9AdarN5Xa4XQ_003D_003D()
	{
		return new _0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D();
	}

	public void _0023_003DzRxycHi1jY4j_wp8cfffJtRdGTXkCFnOnbXcszMUbQJbjxjPhzjNHdHW_Yyms65JuwDxCsqFeoaOL(int _0023_003DziDLVpbY_003D, out byte _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D < 0 || _0023_003DziDLVpbY_003D >= _0023_003DzX67Fgyn0f8jfep_0024QyxTcb0WDhzzd3D47UExChgN5NonIRwIhuJ7EwC78_0024QuqUYNLW_0024sxA0f1cQFs_l1j5rUBPUiu2HAq())
		{
			throw new ArgumentOutOfRangeException();
		}
		IntPtr intPtr = IntPtr.Zero;
		char c = '\0';
		try
		{
			intPtr = Marshal.SecureStringToGlobalAllocUnicode(this._0023_003DziDLVpbY_003D);
			c = (char)Marshal.ReadInt16(intPtr, _0023_003DziDLVpbY_003D * 2);
			_0023_003Dz5rQzobg_003D = _0023_003DzfOJM8Px_0024pH2lngOg5Xt6TUFLeuGQeyL7Bg_003D_003D(c, _0023_003DziDLVpbY_003D);
		}
		finally
		{
			_0023_003DqtFN_00241TjdaenuCmn9GBmqpoxP00_2otIkTTBHYRGB5Ao_003D._0023_003DzWDBPF8QmK64LJkD3SRo6vimjcHxnELr_qHOyQLY_003D(ref c);
			if (intPtr != IntPtr.Zero)
			{
				Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
			}
		}
	}

	public void _0023_003Dz6be2z7fYqX2PEDwC0r7GHQRYTC_0024i47u6CragQyPAO224uxzC95BUOZZayzbk87k_dY20GHpDKJ3dQ0MVRypsYFc_003D(int _0023_003DziDLVpbY_003D, ref byte _0023_003Dz5rQzobg_003D)
	{
		int num = this._0023_003DziDLVpbY_003D.Length;
		while (true)
		{
			if (num > _0023_003DziDLVpbY_003D)
			{
				this._0023_003DziDLVpbY_003D.SetAt(_0023_003DziDLVpbY_003D, _0023_003DzjqV5_Fk0sGWdEEkftad3Tzj7e0PfpQxgYC_0024Ch0vJy_D8(_0023_003Dz5rQzobg_003D, _0023_003DziDLVpbY_003D));
				return;
			}
			if (num == _0023_003DziDLVpbY_003D)
			{
				break;
			}
			this._0023_003DziDLVpbY_003D.AppendChar(_0023_003DzjqV5_Fk0sGWdEEkftad3Tzj7e0PfpQxgYC_0024Ch0vJy_D8(0, num));
			num++;
		}
		this._0023_003DziDLVpbY_003D.AppendChar(_0023_003DzjqV5_Fk0sGWdEEkftad3Tzj7e0PfpQxgYC_0024Ch0vJy_D8(_0023_003Dz5rQzobg_003D, num));
	}

	private static char _0023_003DzjqV5_Fk0sGWdEEkftad3Tzj7e0PfpQxgYC_0024Ch0vJy_D8(byte _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		return (char)(_0023_003DziDLVpbY_003D + 1);
	}

	private static byte _0023_003DzfOJM8Px_0024pH2lngOg5Xt6TUFLeuGQeyL7Bg_003D_003D(char _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		return (byte)(_0023_003DziDLVpbY_003D - 1);
	}

	public void _0023_003Dz0GOe4nZ54B4Hs8VL7hNOyjyIYNB9dJAcWXPfYkqHTdDRzrBNx_0024_OZj6it0mp_0024qzwrzTaE6c_003D()
	{
		_0023_003DziDLVpbY_003D.Clear();
	}

	public void Dispose()
	{
		_0023_003DziDLVpbY_003D.Dispose();
		_0023_003DziDLVpbY_003D = null;
	}
}
