using System;
using System.Runtime.InteropServices;

namespace Microsoft.Internal.Performance;

internal sealed class CodeMarkers
{
	private static class NativeMethods
	{
		[DllImport("Microsoft.Internal.Performance.CodeMarkers.dll", EntryPoint = "PerfCodeMarker")]
		public static extern void DllPerfCodeMarker(int nTimerID, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] aUserParams, int cbParams);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern ushort FindAtom(string lpString);
	}

	private const string AtomName = "VSCodeMarkersEnabled";

	private const string DllName = "Microsoft.Internal.Performance.CodeMarkers.dll";

	public static readonly CodeMarkers Instance = new CodeMarkers();

	private bool fUseCodeMarkers;

	private CodeMarkers()
	{
		fUseCodeMarkers = NativeMethods.FindAtom("VSCodeMarkersEnabled") != 0;
	}

	public void CodeMarker(CodeMarkerEvent nTimerID)
	{
		if (!fUseCodeMarkers)
		{
			return;
		}
		try
		{
			NativeMethods.DllPerfCodeMarker((int)nTimerID, null, 0);
		}
		catch (DllNotFoundException)
		{
			fUseCodeMarkers = false;
		}
	}

	public void CodeMarkerEx(CodeMarkerEvent nTimerID, byte[] aBuff)
	{
		if (aBuff == null)
		{
			throw new ArgumentNullException("aBuff");
		}
		if (!fUseCodeMarkers)
		{
			return;
		}
		try
		{
			NativeMethods.DllPerfCodeMarker((int)nTimerID, aBuff, aBuff.Length);
		}
		catch (DllNotFoundException)
		{
			fUseCodeMarkers = false;
		}
	}
}
