using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TempOdGsBaseVectorizeViewJoinMT : TempOdGsBaseVectorizeViewJoin
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TempOdGsBaseVectorizeViewJoinMT(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoinMT_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TempOdGsBaseVectorizeViewJoinMT obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_TempOdGsBaseVectorizeViewJoinMT(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual uint numVectorizers()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoinMT_numVectorizers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsBaseVectorizer getVectorizer(bool arg0)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoinMT_getVectorizer(swigCPtr, arg0);
		OdGsBaseVectorizer result = ((intPtr == IntPtr.Zero) ? null : new OdGsBaseVectorizer(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void releaseVectorizer(OdGsBaseVectorizer arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoinMT_releaseVectorizer(swigCPtr, OdGsBaseVectorizer.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
