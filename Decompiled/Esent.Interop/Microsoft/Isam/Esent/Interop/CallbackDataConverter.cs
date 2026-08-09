using System;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

internal static class CallbackDataConverter
{
	public static object GetManagedData(IntPtr nativeData, JET_SNP snp, JET_SNT snt)
	{
		if (IntPtr.Zero != nativeData && snt == JET_SNT.Progress)
		{
			NATIVE_SNPROG fromNative = (NATIVE_SNPROG)Marshal.PtrToStructure(nativeData, typeof(NATIVE_SNPROG));
			JET_SNPROG jET_SNPROG = new JET_SNPROG();
			jET_SNPROG.SetFromNative(fromNative);
			return jET_SNPROG;
		}
		return null;
	}
}
