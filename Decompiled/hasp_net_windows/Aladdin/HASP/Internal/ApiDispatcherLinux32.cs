using System;
using System.Runtime.InteropServices;
using System.Text;
using Aladdin.HASP.Internal.NativeMethodsLinux32;

namespace Aladdin.HASP.Internal;

internal class ApiDispatcherLinux32 : ApiDispatcher
{
	public HaspStatus disp_login(int feature_id, string vendor_code, ref int handle)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(vendor_code);
		HaspStatus result = NativeMethods.hasp_login(feature_id, zero, ref handle);
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return result;
	}

	public HaspStatus disp_login(int feature_id, byte[] vendor_code, ref int handle)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(Encoding.ASCII.GetString(vendor_code));
		HaspStatus result = NativeMethods.hasp_login(feature_id, zero, ref handle);
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return result;
	}

	public HaspStatus disp_login_scope(int feature_id, string scope, string vendor_code, ref int handle)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(vendor_code);
		zero2 = Marshal.StringToHGlobalAnsi(scope);
		HaspStatus result = NativeMethods.hasp_login_scope(feature_id, zero2, zero, ref handle);
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		return result;
	}

	public HaspStatus disp_login_scope(int feature_id, string scope, byte[] vendor_code, ref int handle)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(Encoding.ASCII.GetString(vendor_code));
		zero2 = Marshal.StringToHGlobalAnsi(scope);
		HaspStatus result = NativeMethods.hasp_login_scope(feature_id, zero2, zero, ref handle);
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		return result;
	}

	public HaspStatus disp_logout(int handle)
	{
		return NativeMethods.hasp_logout(handle);
	}

	public HaspStatus disp_encrypt(int handle, byte[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_encrypt(handle, zero, data.Length);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_encrypt(int handle, double[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_encrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_encrypt(int handle, short[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 2);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_encrypt(handle, zero, data.Length * 2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_encrypt(int handle, int[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_encrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_encrypt(int handle, long[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_encrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_encrypt(int handle, float[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_encrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_decrypt(int handle, byte[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_decrypt(handle, zero, data.Length);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_decrypt(int handle, double[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_decrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_decrypt(int handle, short[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 2);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_decrypt(handle, zero, data.Length * 2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_decrypt(int handle, int[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_decrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_decrypt(int handle, long[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_decrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_decrypt(int handle, float[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_decrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, int length, byte[] buffer)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(buffer.Length);
		HaspStatus haspStatus = NativeMethods.hasp_read(handle, fileid, offset, length, zero);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, buffer, 0, length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref bool buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 1, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref byte buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 1, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref char buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 2, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref double buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 8, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref short buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 2, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref int buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 4, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref long buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 8, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref ushort buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 2, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref uint buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 4, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref ulong buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 8, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref float buffer)
	{
		return NativeMethods.hasp_read(handle, fileid, offset, 4, ref buffer);
	}

	public HaspStatus disp_read(int handle, int fileid, int offset, ref string buffer)
	{
		IntPtr buffer2 = IntPtr.Zero;
		HaspStatus haspStatus = NativeMethods.hasp_read(handle, fileid, offset, 1, ref buffer2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			buffer = Marshal.PtrToStringAuto(buffer2);
		}
		if (buffer2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(buffer2);
		}
		return haspStatus;
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, byte[] buffer)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(buffer.Length);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(buffer, 0, zero, buffer.Length);
		}
		HaspStatus result = NativeMethods.hasp_write(handle, fileid, offset, buffer.Length, zero);
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return result;
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, bool buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 1, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, byte buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 1, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, char buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 2, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, double buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 8, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, short buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 2, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, int buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 4, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, long buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 8, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, ushort buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 2, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, uint buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 4, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, ulong buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 8, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, float buffer)
	{
		return NativeMethods.hasp_write(handle, fileid, offset, 4, ref buffer);
	}

	public HaspStatus disp_write(int handle, int fileid, int offset, string buffer)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.StringToCoTaskMemAuto(buffer);
		HaspStatus haspStatus = NativeMethods.hasp_write(handle, fileid, offset, 1, ref zero);
		if (haspStatus == HaspStatus.StatusOk)
		{
			buffer = Marshal.PtrToStringAnsi(zero);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_get_size(int handle, int fileid, ref int size)
	{
		return NativeMethods.hasp_get_size(handle, fileid, ref size);
	}

	public HaspStatus disp_get_rtc(int handle, ref long time)
	{
		return NativeMethods.hasp_get_rtc(handle, ref time);
	}

	public HaspStatus disp_legacy_encrypt(int handle, byte[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_encrypt(handle, zero, data.Length);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_encrypt(int handle, double[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_encrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_encrypt(int handle, short[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 2);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_encrypt(handle, zero, data.Length * 2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_encrypt(int handle, int[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_encrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_encrypt(int handle, long[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_encrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_encrypt(int handle, float[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_encrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_decrypt(int handle, byte[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_decrypt(handle, zero, data.Length);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_decrypt(int handle, double[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_decrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_decrypt(int handle, short[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 2);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_decrypt(handle, zero, data.Length * 2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_decrypt(int handle, int[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_decrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_decrypt(int handle, long[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 8);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_decrypt(handle, zero, data.Length * 8);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_decrypt(int handle, float[] data)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.AllocHGlobal(data.Length * 4);
		if (zero != IntPtr.Zero)
		{
			Marshal.Copy(data, 0, zero, data.Length);
		}
		HaspStatus haspStatus = NativeMethods.hasp_legacy_decrypt(handle, zero, data.Length * 4);
		if (haspStatus == HaspStatus.StatusOk)
		{
			Marshal.Copy(zero, data, 0, data.Length);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return haspStatus;
	}

	public HaspStatus disp_legacy_set_rtc(int handle, long new_time)
	{
		return NativeMethods.hasp_legacy_set_rtc(handle, new_time);
	}

	public HaspStatus disp_legacy_set_idletime(int handle, short idle_time)
	{
		return NativeMethods.hasp_legacy_set_idletime(handle, idle_time);
	}

	public HaspStatus disp_get_info(string scope, string format, string vendor_code, ref string info)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr info2 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(scope);
		zero2 = Marshal.StringToHGlobalAnsi(format);
		zero3 = Marshal.StringToHGlobalAnsi(vendor_code);
		HaspStatus haspStatus = NativeMethods.hasp_get_info(zero, zero2, zero3, ref info2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			info = Marshal.PtrToStringAnsi(info2);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		if (zero3 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero3);
		}
		if (info2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(info2);
		}
		return haspStatus;
	}

	public HaspStatus disp_get_info(string scope, string format, byte[] vendor_code, ref string info)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr info2 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(scope);
		zero2 = Marshal.StringToHGlobalAnsi(format);
		zero3 = Marshal.StringToHGlobalAnsi(Encoding.ASCII.GetString(vendor_code));
		HaspStatus haspStatus = NativeMethods.hasp_get_info(zero, zero2, zero3, ref info2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			info = Marshal.PtrToStringAnsi(info2);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		if (zero3 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero3);
		}
		if (info2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(info2);
		}
		return haspStatus;
	}

	public HaspStatus disp_get_sessioninfo(int handle, string format, ref string info)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr info2 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(format);
		HaspStatus haspStatus = NativeMethods.hasp_get_sessioninfo(handle, zero, ref info2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			info = Marshal.PtrToStringAnsi(info2);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (info2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(info2);
		}
		return haspStatus;
	}

	public void disp_free(IntPtr info)
	{
		NativeMethods.hasp_free(info);
	}

	public HaspStatus disp_update(string update_data, ref string ack_data)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr ack_data2 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(update_data);
		HaspStatus haspStatus = NativeMethods.hasp_update(zero, ref ack_data2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			ack_data = Marshal.PtrToStringAnsi(ack_data2);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (ack_data2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(ack_data2);
		}
		return haspStatus;
	}

	public HaspStatus disp_detach(string detach_action, string scope, string vendor_code, string recipient, ref string info)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr info2 = IntPtr.Zero;
		IntPtr zero4 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(scope);
		zero2 = Marshal.StringToHGlobalAnsi(detach_action);
		zero3 = Marshal.StringToHGlobalAnsi(vendor_code);
		zero4 = Marshal.StringToHGlobalAnsi(recipient);
		HaspStatus haspStatus = NativeMethods.hasp_detach(zero2, zero, zero3, zero4, ref info2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			info = Marshal.PtrToStringAnsi(info2);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		if (zero3 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero3);
		}
		if (info2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(info2);
		}
		if (zero4 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero4);
		}
		return haspStatus;
	}

	public HaspStatus disp_detach(string detach_action, string scope, byte[] vendor_code, string recipient, ref string info)
	{
		string info2 = "";
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr zero4 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(scope);
		zero2 = Marshal.StringToHGlobalAnsi(detach_action);
		zero3 = Marshal.StringToHGlobalAnsi(Encoding.ASCII.GetString(vendor_code));
		zero4 = Marshal.StringToHGlobalAnsi(recipient);
		HaspStatus haspStatus = NativeMethods.hasp_detach(detach_action, scope, vendor_code, recipient, ref info2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			info = info2;
		}
		if (!string.IsNullOrEmpty(info2))
		{
			info2 = "";
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		if (zero3 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero3);
		}
		if (zero4 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero4);
		}
		return haspStatus;
	}

	public HaspStatus disp_transfer(string action, string scope, string vendor_code, string recipient, ref string info)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr info2 = IntPtr.Zero;
		IntPtr zero4 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(scope);
		zero2 = Marshal.StringToHGlobalAnsi(action);
		zero3 = Marshal.StringToHGlobalAnsi(vendor_code);
		zero4 = Marshal.StringToHGlobalAnsi(recipient);
		HaspStatus haspStatus = NativeMethods.hasp_transfer(zero2, zero, zero3, zero4, ref info2);
		if (haspStatus == HaspStatus.StatusOk)
		{
			info = Marshal.PtrToStringAnsi(info2);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		if (zero3 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero3);
		}
		if (info2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(info2);
		}
		if (zero4 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero4);
		}
		return haspStatus;
	}

	public HaspStatus disp_transfer(string action, string scope, byte[] vendor_code, string recipient, ref string info)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr zero4 = IntPtr.Zero;
		IntPtr zero5 = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(scope);
		zero2 = Marshal.StringToHGlobalAnsi(action);
		zero3 = Marshal.StringToHGlobalAnsi(Encoding.ASCII.GetString(vendor_code));
		zero5 = Marshal.StringToHGlobalAnsi(recipient);
		HaspStatus haspStatus = NativeMethods.hasp_transfer(action, scope, vendor_code, recipient, ref info);
		if (haspStatus == HaspStatus.StatusOk)
		{
			info = Marshal.PtrToStringAnsi(zero4);
		}
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		if (zero2 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero2);
		}
		if (zero3 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero3);
		}
		if (zero4 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero4);
		}
		if (zero5 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero5);
		}
		return haspStatus;
	}

	public HaspStatus disp_get_version(ref int major_version, ref int minor_version, ref int build_server, ref int build_number, string vendor_code)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(vendor_code);
		HaspStatus result = NativeMethods.hasp_get_version(ref major_version, ref minor_version, ref build_server, ref build_number, zero);
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return result;
	}

	public HaspStatus disp_get_version(ref int major_version, ref int minor_version, ref int build_server, ref int build_number, byte[] vendor_code)
	{
		IntPtr zero = IntPtr.Zero;
		zero = Marshal.StringToHGlobalAnsi(Encoding.ASCII.GetString(vendor_code));
		HaspStatus result = NativeMethods.hasp_get_version(ref major_version, ref minor_version, ref build_server, ref build_number, zero);
		if (zero != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(zero);
		}
		return result;
	}

	public HaspStatus disp_datetime_to_hasptime(int day, int month, int year, int hour, int minute, int second, ref long time)
	{
		return NativeMethods.hasp_datetime_to_hasptime(day, month, year, hour, minute, second, ref time);
	}

	public HaspStatus disp_hasptime_to_datetime(long time, ref int day, ref int month, ref int year, ref int hour, ref int minute, ref int second)
	{
		return NativeMethods.hasp_hasptime_to_datetime(time, ref day, ref month, ref year, ref hour, ref minute, ref second);
	}

	public HaspStatus disp_set_lib_path(string path)
	{
		return HaspStatus.NotImplemented;
	}
}
