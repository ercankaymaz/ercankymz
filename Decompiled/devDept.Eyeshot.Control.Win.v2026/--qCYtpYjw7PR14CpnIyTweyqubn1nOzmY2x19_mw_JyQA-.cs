using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal sealed class _0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D : _0023_003DqokHK_cUOtnj3sNXR4_J_JGyd7MWVblsGDjoZNXi163k_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SecureString _0023_003DzjYYAPCA_003D = new SecureString();

	[SpecialName]
	public int _0023_003DzfVLl9guJQ11BDKy_LRjFuxAYjkZtCfNnn1k1JSFtuUZAshlHeNxmseO4LkYMQXwKRRyAxp2yh9YNtWFUM1SeEPeqBslu()
	{
		return _0023_003DzjYYAPCA_003D.Length;
	}

	public _0023_003DqokHK_cUOtnj3sNXR4_J_JGyd7MWVblsGDjoZNXi163k_003D _0023_003Dz4ncsu_00240quf2df4QxB06j05vsiLCR_cc08kOrWhRabBDNJvmzkwB9L_0024g7IhKShTTkAunoKyhW8noMY_002472vg_003D_003D()
	{
		return new _0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D();
	}

	public void _0023_003Dz6Sd4lL7SfNtIRvzJ9lKZPCaYmAgOgAXs_GdbjiPIpKRdYtzCSSW17G_ZdlNdoy3lOsSgAXX6JE6h(int _0023_003DzjYYAPCA_003D, out byte _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D < 0 || _0023_003DzjYYAPCA_003D >= _0023_003DzfVLl9guJQ11BDKy_LRjFuxAYjkZtCfNnn1k1JSFtuUZAshlHeNxmseO4LkYMQXwKRRyAxp2yh9YNtWFUM1SeEPeqBslu())
		{
			throw new ArgumentOutOfRangeException();
		}
		IntPtr intPtr = IntPtr.Zero;
		char c = '\0';
		try
		{
			intPtr = Marshal.SecureStringToGlobalAllocUnicode(this._0023_003DzjYYAPCA_003D);
			c = (char)Marshal.ReadInt16(intPtr, _0023_003DzjYYAPCA_003D * 2);
			_0023_003DzVC9FBdo_003D = _0023_003DzYnZ6sbD_SOVE0_0024raHA_0024fR2lcPan_00240TqdlA_003D_003D(c, _0023_003DzjYYAPCA_003D);
		}
		finally
		{
			_0023_003DqubUcAaZEWA6CJOJ0kia_0024uf2_00240MWo_00242G02WJefdmBBC0_003D._0023_003Dz1p2XAbVlJZ7SI8qTmZVhCqO7RBDzYMKbVEMPWm4_003D(ref c);
			if (intPtr != IntPtr.Zero)
			{
				Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
			}
		}
	}

	public void _0023_003DzvNQqK_0024BjjIY9Y4ldB7rODa1hFaVzgq_0024DYF5Zw_0024NFAtSTZErtmcA_HBAYIrz9NhS_00242flOuq_7UUXMTIV6CM1rar0_003D(int _0023_003DzjYYAPCA_003D, ref byte _0023_003DzVC9FBdo_003D)
	{
		int num = this._0023_003DzjYYAPCA_003D.Length;
		while (true)
		{
			if (num > _0023_003DzjYYAPCA_003D)
			{
				this._0023_003DzjYYAPCA_003D.SetAt(_0023_003DzjYYAPCA_003D, _0023_003Dz6tN4r9r0B5rAKSFRQJTEl3swqPe_Mx5PwBwdG4_YEEg_0024(_0023_003DzVC9FBdo_003D, _0023_003DzjYYAPCA_003D));
				return;
			}
			if (num == _0023_003DzjYYAPCA_003D)
			{
				break;
			}
			this._0023_003DzjYYAPCA_003D.AppendChar(_0023_003Dz6tN4r9r0B5rAKSFRQJTEl3swqPe_Mx5PwBwdG4_YEEg_0024(0, num));
			num++;
		}
		this._0023_003DzjYYAPCA_003D.AppendChar(_0023_003Dz6tN4r9r0B5rAKSFRQJTEl3swqPe_Mx5PwBwdG4_YEEg_0024(_0023_003DzVC9FBdo_003D, num));
	}

	private static char _0023_003Dz6tN4r9r0B5rAKSFRQJTEl3swqPe_Mx5PwBwdG4_YEEg_0024(byte _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		return (char)(_0023_003DzjYYAPCA_003D + 1);
	}

	private static byte _0023_003DzYnZ6sbD_SOVE0_0024raHA_0024fR2lcPan_00240TqdlA_003D_003D(char _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		return (byte)(_0023_003DzjYYAPCA_003D - 1);
	}

	public void _0023_003DzgHzfCf7k7OzyB2e4cb6VXV9cubUORtGgF1wy122mmEHUuDsbwUTny4WLbyyooEla15_0024EWI8_003D()
	{
		_0023_003DzjYYAPCA_003D.Clear();
	}

	public void Dispose()
	{
		_0023_003DzjYYAPCA_003D.Dispose();
		_0023_003DzjYYAPCA_003D = null;
	}
}
