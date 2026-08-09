using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbXRefMan : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbXRefMan(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbXRefMan obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbXRefMan()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbXRefMan(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdResult load(OdDbDatabase pHostDb, string xrefBlockname)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_load__SWIG_0(OdDbDatabase.getCPtr(pHostDb), xrefBlockname);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult load(OdDbObjectIdArray xrefBTRids)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_load__SWIG_1(OdDbObjectIdArray.getCPtr(xrefBTRids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult load(OdDbBlockTableRecord pBTR)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_load__SWIG_2(OdDbBlockTableRecord.getCPtr(pBTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult loadAll(OdDbDatabase pHostDb, bool verify)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_loadAll__SWIG_0(OdDbDatabase.getCPtr(pHostDb), verify);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult loadAll(OdDbDatabase pHostDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_loadAll__SWIG_1(OdDbDatabase.getCPtr(pHostDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static void unload(OdDbBlockTableRecord pBTR)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_unload__SWIG_0(OdDbBlockTableRecord.getCPtr(pBTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void unload(OdDbObjectIdArray xrefBTRids)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_unload__SWIG_1(OdDbObjectIdArray.getCPtr(xrefBTRids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void unloadAll(OdDbDatabase pHostDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_unloadAll(OdDbDatabase.getCPtr(pHostDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult bind(OdDbBlockTableRecord pBTR, bool insertBind)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_bind__SWIG_0(OdDbBlockTableRecord.getCPtr(pBTR), insertBind);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult bind(OdDbBlockTableRecord pBTR)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_bind__SWIG_1(OdDbBlockTableRecord.getCPtr(pBTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult detach(OdDbBlockTableRecord pBTR)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_detach(OdDbBlockTableRecord.getCPtr(pBTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static void setOverlaid(OdDbBlockTableRecord pBTR, bool overlaid)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_setOverlaid__SWIG_0(OdDbBlockTableRecord.getCPtr(pBTR), overlaid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setOverlaid(OdDbBlockTableRecord pBTR)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefMan_setOverlaid__SWIG_1(OdDbBlockTableRecord.getCPtr(pBTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbXRefMan()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbXRefMan(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
