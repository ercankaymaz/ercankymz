using System;
using System.Runtime.InteropServices;
using System.Text;
using Aladdin.HASP.Internal.NativeMethods32;

namespace Aladdin.HASP.Internal;

internal static class ApiDisp
{
	private static ApiDispatcher apidsp;

	public static int IsRunningOnMono()
	{
		int result = 1;
		if (Environment.OSVersion.ToString().IndexOf("Windows") >= 0)
		{
			result = 0;
		}
		else
		{
			string text = Environment.OSVersion.ToString();
			int num = text.IndexOf('.');
			int num2 = text.IndexOf(' ');
			if (num >= 0 && num2 >= 0)
			{
				string s = text.Substring(num2, num - num2);
				int num3 = int.Parse(s);
				if (num3 >= 4)
				{
					result = 2;
				}
			}
		}
		return result;
	}

	public static IntPtr NativeUtf8FromString(string managedString)
	{
		if (managedString == null)
		{
			return Marshal.StringToHGlobalAnsi(managedString);
		}
		int byteCount = Encoding.UTF8.GetByteCount(managedString);
		byte[] array = new byte[byteCount + 1];
		Encoding.UTF8.GetBytes(managedString, 0, managedString.Length, array, 0);
		IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
		Marshal.Copy(array, 0, intPtr, array.Length);
		return intPtr;
	}

	public static string StringFromNativeUtf8(IntPtr nativeUtf8)
	{
		int i;
		for (i = 0; Marshal.ReadByte(nativeUtf8, i) != 0; i++)
		{
		}
		if (i == 0)
		{
			return string.Empty;
		}
		byte[] array = new byte[i];
		Marshal.Copy(nativeUtf8, array, 0, array.Length);
		return Encoding.UTF8.GetString(array);
	}

	public static HaspStatus login(int feature_id, string vendor_code, ref int handle)
	{
		return apidsp.disp_login(feature_id, vendor_code, ref handle);
	}

	public static HaspStatus login(int feature_id, byte[] vendor_code, ref int handle)
	{
		return apidsp.disp_login(feature_id, vendor_code, ref handle);
	}

	public static HaspStatus login_scope(int feature_id, string scope, string vendor_code, ref int handle)
	{
		return apidsp.disp_login_scope(feature_id, scope, vendor_code, ref handle);
	}

	public static HaspStatus login_scope(int feature_id, string scope, byte[] vendor_code, ref int handle)
	{
		return apidsp.disp_login_scope(feature_id, scope, vendor_code, ref handle);
	}

	public static HaspStatus logout(int handle)
	{
		return apidsp.disp_logout(handle);
	}

	public static HaspStatus encrypt(int handle, byte[] data)
	{
		return apidsp.disp_encrypt(handle, data);
	}

	public static HaspStatus encrypt(int handle, char[] data)
	{
		short[] array = new short[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = (short)data[i];
		}
		HaspStatus result = apidsp.disp_encrypt(handle, array);
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = (char)array[i];
		}
		return result;
	}

	public static HaspStatus encrypt(int handle, double[] data)
	{
		return apidsp.disp_encrypt(handle, data);
	}

	public static HaspStatus encrypt(int handle, short[] data)
	{
		return apidsp.disp_encrypt(handle, data);
	}

	public static HaspStatus encrypt(int handle, int[] data)
	{
		return apidsp.disp_encrypt(handle, data);
	}

	public static HaspStatus encrypt(int handle, long[] data)
	{
		return apidsp.disp_encrypt(handle, data);
	}

	public static HaspStatus encrypt(int handle, float[] data)
	{
		return apidsp.disp_encrypt(handle, data);
	}

	public static HaspStatus encrypt(int handle, ref string data)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(data);
		HaspStatus result = apidsp.disp_encrypt(handle, bytes);
		data = Convert.ToBase64String(bytes);
		return result;
	}

	public static HaspStatus decrypt(int handle, byte[] data)
	{
		return apidsp.disp_decrypt(handle, data);
	}

	public static HaspStatus decrypt(int handle, char[] data)
	{
		short[] array = new short[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = (short)data[i];
		}
		HaspStatus result = apidsp.disp_decrypt(handle, array);
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = (char)array[i];
		}
		return result;
	}

	public static HaspStatus decrypt(int handle, double[] data)
	{
		return apidsp.disp_decrypt(handle, data);
	}

	public static HaspStatus decrypt(int handle, short[] data)
	{
		return apidsp.disp_decrypt(handle, data);
	}

	public static HaspStatus decrypt(int handle, int[] data)
	{
		return apidsp.disp_decrypt(handle, data);
	}

	public static HaspStatus decrypt(int handle, long[] data)
	{
		return apidsp.disp_decrypt(handle, data);
	}

	public static HaspStatus decrypt(int handle, float[] data)
	{
		return apidsp.disp_decrypt(handle, data);
	}

	public static HaspStatus decrypt(int handle, ref string data)
	{
		byte[] array = Convert.FromBase64String(data);
		HaspStatus result = apidsp.disp_decrypt(handle, array);
		data = Encoding.UTF8.GetString(array);
		return result;
	}

	public static HaspStatus read(int handle, int fileid, int offset, byte[] buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, buffer.Length, buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref bool buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref byte buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref char buffer)
	{
		short buffer2 = 0;
		HaspStatus result = apidsp.disp_read(handle, fileid, offset, ref buffer2);
		buffer = (char)buffer2;
		return result;
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref double buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref short buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref int buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref long buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref ushort buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref uint buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref ulong buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref float buffer)
	{
		return apidsp.disp_read(handle, fileid, offset, ref buffer);
	}

	public static HaspStatus read(int handle, int fileid, int offset, ref string buffer)
	{
		byte buffer2 = 0;
		HaspStatus haspStatus = read(handle, fileid, offset, ref buffer2);
		if (haspStatus != HaspStatus.StatusOk)
		{
			buffer = "";
			return haspStatus;
		}
		byte[] array = new byte[buffer2];
		haspStatus = read(handle, fileid, offset + 1, array);
		if (haspStatus != HaspStatus.StatusOk)
		{
			buffer = "";
			return haspStatus;
		}
		buffer = Encoding.UTF8.GetString(array);
		return HaspStatus.StatusOk;
	}

	public static HaspStatus write(int handle, int fileid, int offset, byte[] buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, bool buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, byte buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, char buffer)
	{
		short buffer2 = (short)buffer;
		return apidsp.disp_write(handle, fileid, offset, buffer2);
	}

	public static HaspStatus write(int handle, int fileid, int offset, double buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, short buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, int buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, long buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, ushort buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, uint buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, ulong buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, float buffer)
	{
		return apidsp.disp_write(handle, fileid, offset, buffer);
	}

	public static HaspStatus write(int handle, int fileid, int offset, string buffer)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(buffer);
		byte[] array = new byte[bytes.Length + 1];
		if (bytes.Length > 255)
		{
			return HaspStatus.InvalidParameter;
		}
		array[0] = (byte)bytes.Length;
		bytes.CopyTo(array, 1);
		return apidsp.disp_write(handle, fileid, offset, array);
	}

	public static HaspStatus get_size(int handle, int fileid, ref int size)
	{
		return apidsp.disp_get_size(handle, fileid, ref size);
	}

	public static HaspStatus get_rtc(int handle, ref long time)
	{
		return apidsp.disp_get_rtc(handle, ref time);
	}

	public static HaspStatus legacy_encrypt(int handle, byte[] buffer)
	{
		return apidsp.disp_legacy_encrypt(handle, buffer);
	}

	public static HaspStatus legacy_encrypt(int handle, char[] data)
	{
		short[] array = new short[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = (short)data[i];
		}
		HaspStatus result = apidsp.disp_legacy_encrypt(handle, array);
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = (char)array[i];
		}
		return result;
	}

	public static HaspStatus legacy_encrypt(int handle, double[] buffer)
	{
		return apidsp.disp_legacy_encrypt(handle, buffer);
	}

	public static HaspStatus legacy_encrypt(int handle, short[] buffer)
	{
		return apidsp.disp_legacy_encrypt(handle, buffer);
	}

	public static HaspStatus legacy_encrypt(int handle, int[] buffer)
	{
		return apidsp.disp_legacy_encrypt(handle, buffer);
	}

	public static HaspStatus legacy_encrypt(int handle, long[] buffer)
	{
		return apidsp.disp_legacy_encrypt(handle, buffer);
	}

	public static HaspStatus legacy_encrypt(int handle, float[] buffer)
	{
		return apidsp.disp_legacy_encrypt(handle, buffer);
	}

	public static HaspStatus legacy_encrypt(int handle, ref string data)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(data);
		HaspStatus result = apidsp.disp_legacy_encrypt(handle, bytes);
		data = Convert.ToBase64String(bytes);
		return result;
	}

	public static HaspStatus legacy_decrypt(int handle, byte[] buffer)
	{
		return apidsp.disp_legacy_decrypt(handle, buffer);
	}

	public static HaspStatus legacy_decrypt(int handle, char[] data)
	{
		short[] array = new short[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = (short)data[i];
		}
		HaspStatus result = apidsp.disp_legacy_decrypt(handle, array);
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = (char)array[i];
		}
		return result;
	}

	public static HaspStatus legacy_decrypt(int handle, double[] buffer)
	{
		return apidsp.disp_legacy_decrypt(handle, buffer);
	}

	public static HaspStatus legacy_decrypt(int handle, short[] buffer)
	{
		return apidsp.disp_legacy_decrypt(handle, buffer);
	}

	public static HaspStatus legacy_decrypt(int handle, int[] buffer)
	{
		return apidsp.disp_legacy_decrypt(handle, buffer);
	}

	public static HaspStatus legacy_decrypt(int handle, long[] buffer)
	{
		return apidsp.disp_legacy_decrypt(handle, buffer);
	}

	public static HaspStatus legacy_decrypt(int handle, float[] buffer)
	{
		return apidsp.disp_legacy_decrypt(handle, buffer);
	}

	public static HaspStatus legacy_decrypt(int handle, ref string data)
	{
		byte[] array = Convert.FromBase64String(data);
		HaspStatus result = apidsp.disp_legacy_decrypt(handle, array);
		data = Encoding.UTF8.GetString(array);
		return result;
	}

	public static HaspStatus legacy_set_rtc(int handle, long new_time)
	{
		return apidsp.disp_legacy_set_rtc(handle, new_time);
	}

	public static HaspStatus legacy_set_idletime(int handle, short idle_time)
	{
		return apidsp.disp_legacy_set_idletime(handle, idle_time);
	}

	public static HaspStatus get_info(string scope, string format, string vendor_code, ref string info)
	{
		return apidsp.disp_get_info(scope, format, vendor_code, ref info);
	}

	public static HaspStatus get_info(string scope, string format, byte[] vendor_code, ref string info)
	{
		return apidsp.disp_get_info(scope, format, vendor_code, ref info);
	}

	public static HaspStatus get_sessioninfo(int handle, string format, ref string info)
	{
		return apidsp.disp_get_sessioninfo(handle, format, ref info);
	}

	public static HaspStatus update(string update_data, ref string ack_data)
	{
		return apidsp.disp_update(update_data, ref ack_data);
	}

	public static HaspStatus get_version(ref int major_version, ref int minor_version, ref int build_server, ref int build_number, string vendor_code)
	{
		return apidsp.disp_get_version(ref major_version, ref minor_version, ref build_server, ref build_number, vendor_code);
	}

	public static HaspStatus get_version(ref int major_version, ref int minor_version, ref int build_server, ref int build_number, byte[] vendor_code)
	{
		return apidsp.disp_get_version(ref major_version, ref minor_version, ref build_server, ref build_number, vendor_code);
	}

	public static HaspStatus detach(string detach_action, string scope, string vendor_code, string recipient, ref string info)
	{
		return apidsp.disp_detach(detach_action, scope, vendor_code, recipient, ref info);
	}

	public static HaspStatus detach(string detach_action, string scope, byte[] vendor_code, string recipient, ref string info)
	{
		return apidsp.disp_detach(detach_action, scope, vendor_code, recipient, ref info);
	}

	public static HaspStatus set_lib_path(string path)
	{
		if (IsRunningOnMono() == 1)
		{
			NativeMethods.SetDllDirectory(path);
		}
		return apidsp.disp_set_lib_path(path);
	}

	public static HaspStatus transfer(string action, string scope, string vendor_code, string recipient, ref string info)
	{
		return apidsp.disp_transfer(action, scope, vendor_code, recipient, ref info);
	}

	public static HaspStatus transfer(string action, string scope, byte[] vendor_code, string recipient, ref string info)
	{
		return apidsp.disp_transfer(action, scope, vendor_code, recipient, ref info);
	}

	static ApiDisp()
	{
		object obj;
		if (IsRunningOnMono() <= 0)
		{
			if (IntPtr.Size != 4)
			{
				ApiDispatcher apiDispatcher = new ApiDispatcher64();
				obj = apiDispatcher;
			}
			else
			{
				obj = new ApiDispatcher32();
			}
		}
		else if (IsRunningOnMono() != 1)
		{
			obj = new ApiDispatcherDarwin();
		}
		else if (IntPtr.Size != 4)
		{
			ApiDispatcher apiDispatcher = new ApiDispatcherLinux64();
			obj = apiDispatcher;
		}
		else
		{
			obj = new ApiDispatcherLinux32();
		}
		apidsp = (ApiDispatcher)obj;
	}
}
