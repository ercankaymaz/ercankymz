using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxMemberQueryEngine : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxMemberQueryEngine(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxMemberQueryEngine obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxMemberQueryEngine()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxMemberQueryEngine(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdRxMemberQueryEngine theEngine()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_theEngine();
		OdRxMemberQueryEngine result = ((intPtr == IntPtr.Zero) ? null : new OdRxMemberQueryEngine(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxMember find(OdRxObject pO, string name, OdRxMemberQueryContext pContext, bool bQueryFacets)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_find__SWIG_0(swigCPtr, OdRxObject.getCPtr(pO), name, OdRxMemberQueryContext.getCPtr(pContext), bQueryFacets), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxMember find(OdRxObject pO, string name, OdRxMemberQueryContext pContext)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_find__SWIG_1(swigCPtr, OdRxObject.getCPtr(pO), name, OdRxMemberQueryContext.getCPtr(pContext)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxMember find(OdRxObject pO, string name)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_find__SWIG_2(swigCPtr, OdRxObject.getCPtr(pO), name), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxMemberIterator newMemberIterator(OdRxObject pO, OdRxMemberQueryContext pContext)
	{
		OdRxMemberIterator result = Helpers.GetObject<OdRxMemberIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_newMemberIterator__SWIG_0(swigCPtr, OdRxObject.getCPtr(pO), OdRxMemberQueryContext.getCPtr(pContext)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxMemberIterator newMemberIterator(OdRxObject pO)
	{
		OdRxMemberIterator result = Helpers.GetObject<OdRxMemberIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_newMemberIterator__SWIG_1(swigCPtr, OdRxObject.getCPtr(pO)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxMemberQueryContext defaultContext()
	{
		OdRxMemberQueryContext rXObject = Helpers.GetRXObject<OdRxMemberQueryContext>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_defaultContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxPromotingQueryContext promotingContext()
	{
		OdRxPromotingQueryContext rXObject = Helpers.GetRXObject<OdRxPromotingQueryContext>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_promotingContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void addFacetProvider(OdRxFacetProvider pProvider)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_addFacetProvider(swigCPtr, OdRxFacetProvider.getCPtr(pProvider));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeFacetProvider(OdRxFacetProvider pProvider)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_removeFacetProvider(swigCPtr, OdRxFacetProvider.getCPtr(pProvider));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addReactor(OdRxMemberReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_addReactor(swigCPtr, OdRxMemberReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeReactor(OdRxMemberReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryEngine_removeReactor(swigCPtr, OdRxMemberReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
