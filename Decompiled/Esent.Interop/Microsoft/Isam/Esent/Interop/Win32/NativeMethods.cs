using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Win32;

internal static class NativeMethods
{
	private const string WinCoreMemoryDll = "kernel32.dll";

	private const string HeapObsolete = "kernel32.dll";

	private const string WinCoreProcessThreads = "kernel32.dll";

	public static void ThrowExceptionOnNull(IntPtr ptr, string message)
	{
		if (IntPtr.Zero == ptr)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error(), message);
		}
	}

	public static void ThrowExceptionOnFailure(bool success, string message)
	{
		if (!success)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error(), message);
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr VirtualAlloc(IntPtr plAddress, UIntPtr dwSize, uint flAllocationType, uint flProtect);

	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool VirtualFree(IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);

	[DllImport("kernel32.dll")]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	public static extern IntPtr LocalAlloc(int uFlags, UIntPtr sizetdwBytes);

	[DllImport("kernel32.dll")]
	public static extern IntPtr LocalFree(IntPtr hglobal);

	[DllImport("kernel32.dll")]
	public static extern int GetCurrentProcessId();
}
