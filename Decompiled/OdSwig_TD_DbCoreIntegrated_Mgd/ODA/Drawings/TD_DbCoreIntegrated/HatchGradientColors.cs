using System;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class HatchGradientColors
{
	private OdDoubleArray gradientValues;

	private OdCmColorArray colors;

	public OdDoubleArray GradientValues => gradientValues;

	public OdCmColorArray Colors => colors;

	public HatchGradientColors(OdDoubleArray gradientValues, OdCmColorArray ca)
	{
		this.gradientValues = gradientValues;
		colors = ca;
		if (this.gradientValues.Count != colors.Count)
		{
			throw new Exception("gradientValues.Count != colors.Count");
		}
	}

	public IntPtr Marshal()
	{
		IntPtr handle = OdCmColorArray.getCPtr(Colors).Handle;
		IntPtr handle2 = OdDoubleArray.getCPtr(GradientValues).Handle;
		IntPtr intPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(IntPtr.Size * 2);
		if (IntPtr.Size == 4)
		{
			System.Runtime.InteropServices.Marshal.WriteInt32(intPtr, 0, handle.ToInt32());
			System.Runtime.InteropServices.Marshal.WriteInt32(intPtr, IntPtr.Size, handle2.ToInt32());
		}
		else
		{
			System.Runtime.InteropServices.Marshal.WriteInt64(intPtr, 0, handle.ToInt64());
			System.Runtime.InteropServices.Marshal.WriteInt64(intPtr, IntPtr.Size, handle2.ToInt64());
		}
		return intPtr;
	}
}
