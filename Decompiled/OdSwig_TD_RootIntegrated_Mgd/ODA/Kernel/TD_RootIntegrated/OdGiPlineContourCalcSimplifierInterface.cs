using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPlineContourCalcSimplifierInterface : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPlineContourCalcSimplifierInterface(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPlineContourCalcSimplifierInterface obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPlineContourCalcSimplifierInterface()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlineContourCalcSimplifierInterface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void plineCalcShellWires(int[] faceListSize, EdgeData pEdgeData, OdGiFaceData pFaceData)
	{
		IntPtr intPtr = Helpers.MarshalInt32FixedArray(faceListSize);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPlineContourCalcSimplifierInterface_plineCalcShellWires__SWIG_0(swigCPtr, intPtr, pEdgeData, OdGiFaceData.getCPtr(pFaceData));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void plineCalcShellWires(int[] faceListSize, EdgeData pEdgeData)
	{
		IntPtr intPtr = Helpers.MarshalInt32FixedArray(faceListSize);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPlineContourCalcSimplifierInterface_plineCalcShellWires__SWIG_1(swigCPtr, intPtr, pEdgeData);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void plineCalcShellWires(int[] faceListSize)
	{
		IntPtr intPtr = Helpers.MarshalInt32FixedArray(faceListSize);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPlineContourCalcSimplifierInterface_plineCalcShellWires__SWIG_2(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void dropPlineCalcShellWires(bool bStrips)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlineContourCalcSimplifierInterface_dropPlineCalcShellWires(swigCPtr, bStrips);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
