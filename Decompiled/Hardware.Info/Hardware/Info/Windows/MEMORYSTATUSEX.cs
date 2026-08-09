using System.Runtime.InteropServices;

namespace Hardware.Info.Windows;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal class MEMORYSTATUSEX
{
	public uint dwLength;

	public uint dwMemoryLoad;

	public ulong ullTotalPhys;

	public ulong ullAvailPhys;

	public ulong ullTotalPageFile;

	public ulong ullAvailPageFile;

	public ulong ullTotalVirtual;

	public ulong ullAvailVirtual;

	public ulong ullAvailExtendedVirtual;

	public MEMORYSTATUSEX()
	{
		dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
	}
}
