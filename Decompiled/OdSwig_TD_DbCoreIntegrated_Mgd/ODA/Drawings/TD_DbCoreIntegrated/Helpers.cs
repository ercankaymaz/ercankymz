using System;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class Helpers
{
	public static byte[] UnmarshalByteArray(IntPtr data)
	{
		if (data == IntPtr.Zero)
		{
			return null;
		}
		int num = Marshal.ReadInt32(data);
		byte[] array = new byte[num];
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			array[i] = Marshal.ReadByte(data, num2++);
		}
		Marshal.FreeCoTaskMem(data);
		return array;
	}
}
