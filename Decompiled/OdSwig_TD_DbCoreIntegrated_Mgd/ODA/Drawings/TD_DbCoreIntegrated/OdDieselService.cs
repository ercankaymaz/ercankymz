using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDieselService : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDieselService(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDieselService obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDieselService()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDieselService(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool getSystemVariable(string sName, ref string sValue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sValue);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDieselService_getSystemVariable(swigCPtr, sName, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual void getUnits(int pAngularUnits, int pAngularPrec, int pLinearUnits, int pLinearPrec, int pDimzin, int pUnitMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDieselService_getUnits(swigCPtr, pAngularUnits, pAngularPrec, pLinearUnits, pLinearPrec, pDimzin, pUnitMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getEnvironmentVariable(string sName, ref string sValue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sValue);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDieselService_getEnvironmentVariable(swigCPtr, sName, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getDrawingProperty(string sName, ref string sValue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sValue);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDieselService_getDrawingProperty(swigCPtr, sName, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}
}
