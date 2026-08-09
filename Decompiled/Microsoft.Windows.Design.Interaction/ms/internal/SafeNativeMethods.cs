using System.Runtime.InteropServices;
using System.Security;

namespace MS.Internal;

[SuppressUnmanagedCodeSecurity]
internal static class SafeNativeMethods
{
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	internal static extern int GetSystemMetrics(int nIndex);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SystemParametersInfo(int nAction, int nParam, out int value, int ignore);
}
