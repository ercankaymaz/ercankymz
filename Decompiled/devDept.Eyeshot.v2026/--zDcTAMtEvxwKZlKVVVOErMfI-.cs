using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

internal static class _0023_003DzDcTAMtEvxwKZlKVVVOErMfI_003D
{
	private sealed class _0023_003DzSZxYioiCBggi
	{
		private string _0023_003DzpZSyoR95nNkIq4M43A_003D_003D = string.Empty;

		private string _0023_003DzxkZRffkAvq_0024EoHSiCQ_003D_003D = string.Empty;

		private string _0023_003DzhMYtkxfuiXduJzJo_kFGw6Y_003D = string.Empty;

		private string _0023_003DzxJTZPdhgoWndxf6rYR_0024jF2s_003D = string.Empty;

		public string _0023_003DzCCx6QeiDpT0l()
		{
			return _0023_003DzpZSyoR95nNkIq4M43A_003D_003D;
		}

		public void _0023_003Dz3XwqAG4zjmmp(string _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzpZSyoR95nNkIq4M43A_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public string _0023_003DzfeBhG4Jz4m4i()
		{
			return _0023_003DzxkZRffkAvq_0024EoHSiCQ_003D_003D;
		}

		public void _0023_003DzuTFqpihnXW1e(string _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzxkZRffkAvq_0024EoHSiCQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public string _0023_003DzMvzs9gDnSFuA()
		{
			return _0023_003DzhMYtkxfuiXduJzJo_kFGw6Y_003D;
		}

		public void _0023_003Dz8uiJ58CHMUJB(string _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzhMYtkxfuiXduJzJo_kFGw6Y_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public string _0023_003DzrEyZgkGS5HPO()
		{
			return _0023_003DzxJTZPdhgoWndxf6rYR_0024jF2s_003D;
		}

		public void _0023_003DzNvtaeKBGKSHf(string _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzxJTZPdhgoWndxf6rYR_0024jF2s_003D = _0023_003DzPzO_0024GUk_003D;
		}
	}

	public static string _0023_003Dz0c4AeZ_MDBQU()
	{
		if (!_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D())
		{
			return string.Empty;
		}
		_0023_003DzSZxYioiCBggi _0023_003DzSZxYioiCBggi2 = _0023_003DzKUYHLzZJB0fhIzcQBg_003D_003D((Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942573)).TrimEnd('\\'));
		if (_0023_003DzSZxYioiCBggi2 == null)
		{
			return string.Empty;
		}
		if (!string.IsNullOrWhiteSpace(_0023_003DzSZxYioiCBggi2._0023_003DzrEyZgkGS5HPO()))
		{
			return _0023_003DzSZxYioiCBggi2._0023_003DzrEyZgkGS5HPO().Trim();
		}
		string text = (_0023_003DzSZxYioiCBggi2._0023_003DzCCx6QeiDpT0l() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzSZxYioiCBggi2._0023_003DzfeBhG4Jz4m4i()).Trim();
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return string.Empty;
	}

	private static _0023_003DzSZxYioiCBggi? _0023_003DzKUYHLzZJB0fhIzcQBg_003D_003D(string _0023_003DzhKcriekaIolc)
	{
		using SafeFileHandle safeFileHandle = _0023_003DzJHgD45g_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942551) + _0023_003DzhKcriekaIolc, 0u, 3u, IntPtr.Zero, 3u, 128u, IntPtr.Zero);
		if (safeFileHandle.IsInvalid)
		{
			return null;
		}
		byte[] array = new byte[12];
		Array.Copy(BitConverter.GetBytes(0), 0, array, 0, 4);
		Array.Copy(BitConverter.GetBytes(0), 0, array, 4, 4);
		IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
		try
		{
			Marshal.Copy(array, 0, intPtr, array.Length);
			byte[] array2 = new byte[4096];
			if (!_0023_003DzbKC7aLd2B4kJ(safeFileHandle, 2954240, intPtr, array.Length, array2, array2.Length, out var _0023_003DzZ5lm75YqGFm, IntPtr.Zero) || _0023_003DzZ5lm75YqGFm < 32)
			{
				return null;
			}
			uint num = BitConverter.ToUInt32(array2, 4);
			if (num == 0 || num > _0023_003DzZ5lm75YqGFm || num > array2.Length)
			{
				return null;
			}
			uint _0023_003DzfBEBL_o_003D = BitConverter.ToUInt32(array2, 12);
			uint _0023_003DzfBEBL_o_003D2 = BitConverter.ToUInt32(array2, 16);
			uint _0023_003DzfBEBL_o_003D3 = BitConverter.ToUInt32(array2, 20);
			uint _0023_003DzfBEBL_o_003D4 = BitConverter.ToUInt32(array2, 24);
			string _0023_003DzPzO_0024GUk_003D = _0023_003DzcDQh_T4JqhPJiQIxkg_003D_003D(array2, _0023_003DzZ5lm75YqGFm, _0023_003DzfBEBL_o_003D);
			string _0023_003DzPzO_0024GUk_003D2 = _0023_003DzcDQh_T4JqhPJiQIxkg_003D_003D(array2, _0023_003DzZ5lm75YqGFm, _0023_003DzfBEBL_o_003D2);
			string _0023_003DzPzO_0024GUk_003D3 = _0023_003DzcDQh_T4JqhPJiQIxkg_003D_003D(array2, _0023_003DzZ5lm75YqGFm, _0023_003DzfBEBL_o_003D3);
			string _0023_003DzPzO_0024GUk_003D4 = _0023_003DzcDQh_T4JqhPJiQIxkg_003D_003D(array2, _0023_003DzZ5lm75YqGFm, _0023_003DzfBEBL_o_003D4);
			_0023_003DzSZxYioiCBggi obj = new _0023_003DzSZxYioiCBggi();
			obj._0023_003Dz3XwqAG4zjmmp(_0023_003DzPzO_0024GUk_003D);
			obj._0023_003DzuTFqpihnXW1e(_0023_003DzPzO_0024GUk_003D2);
			obj._0023_003Dz8uiJ58CHMUJB(_0023_003DzPzO_0024GUk_003D3);
			obj._0023_003DzNvtaeKBGKSHf(_0023_003DzPzO_0024GUk_003D4);
			return obj;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	private static string _0023_003DzcDQh_T4JqhPJiQIxkg_003D_003D(byte[] _0023_003DzzLvmjQQ_003D, int _0023_003DzyK1MTHG1rKv0, uint _0023_003DzfBEBL_o_003D)
	{
		if (_0023_003DzfBEBL_o_003D == 0)
		{
			return string.Empty;
		}
		if (_0023_003DzfBEBL_o_003D >= (uint)_0023_003DzyK1MTHG1rKv0)
		{
			return string.Empty;
		}
		if (_0023_003DzfBEBL_o_003D < 24)
		{
			return string.Empty;
		}
		int i = (int)_0023_003DzfBEBL_o_003D;
		int num = i;
		for (; i < _0023_003DzyK1MTHG1rKv0 && _0023_003DzzLvmjQQ_003D[i] != 0; i++)
		{
		}
		if (i <= num)
		{
			return string.Empty;
		}
		for (int j = num; j < i; j++)
		{
			byte b = _0023_003DzzLvmjQQ_003D[j];
			if (b < 32 || b > 126)
			{
				return string.Empty;
			}
		}
		return Encoding.ASCII.GetString(_0023_003DzzLvmjQQ_003D, num, i - num).Trim();
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileW", SetLastError = true)]
	private static extern SafeFileHandle _0023_003DzJHgD45g_003D(string _0023_003Dzz4pfsj_0024HcLp3, uint _0023_003Dz5b0zDpeq1Wqn, uint _0023_003DzAqA1Ix4SaEx8, IntPtr _0023_003DzKzSeAKL12n7q, uint _0023_003DzogRctfAc_ms7, uint _0023_003DzwJ4oQXIJLXXS, IntPtr _0023_003Dz6P8uLZxb5ks5);

	[DllImport("kernel32.dll", EntryPoint = "DeviceIoControl", SetLastError = true)]
	private static extern bool _0023_003DzbKC7aLd2B4kJ(SafeFileHandle _0023_003DzWPLtM5k_003D, int _0023_003DzLnq3tSVQDpku, IntPtr _0023_003DzRgPpepOWaDCc, int _0023_003DzPtHki0rDhghX, [Out] byte[] _0023_003DzL3yIvwuixa4q, int _0023_003DzyiWuZBBx_0024Ekt, out int _0023_003DzZ5lm75YqGFm2, IntPtr _0023_003DzAD_0024D6GlDCtqw);
}
