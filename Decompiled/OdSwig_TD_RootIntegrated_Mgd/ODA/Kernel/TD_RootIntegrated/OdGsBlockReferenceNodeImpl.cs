using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBlockReferenceNodeImpl : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBlockReferenceNodeImpl(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBlockReferenceNodeImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsBlockReferenceNodeImpl()
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
	}

	public virtual bool invalidate(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_invalidate(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool destroy()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool destroySubitems()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_destroySubitems(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool select(OdGsBaseVectorizer view, OdSiRecursiveVisitor pVisitor, bool bHasExtents, OdGsView_SelectionMode mode)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_select(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdSiRecursiveVisitor.getCPtr(pVisitor), bHasExtents, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void highlight(bool bDoIt, bool bWholeBranch, uint nSelStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_highlight__SWIG_0(swigCPtr, bDoIt, bWholeBranch, nSelStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(bool bDoIt, bool bWholeBranch)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_highlight__SWIG_1(swigCPtr, bDoIt, bWholeBranch);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsEntityNode firstEntity()
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_firstEntity(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void playAsGeometry(OdGsBaseVectorizer view, EMetafilePlayMode eMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_playAsGeometry(swigCPtr, OdGsBaseVectorizer.getCPtr(view), (int)eMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSharedReference()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_isSharedReference(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSharedDefinition()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_isSharedDefinition(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool layersChanged(ref OdGsViewImpl view)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_layersChanged(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				view = null;
			}
			if (jarg != intPtr)
			{
				view = Helpers.GetRXObject<OdGsViewImpl>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void makeStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_makeStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void releaseStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_releaseStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void propagateLayerChangesStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_propagateLayerChangesStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool saveNodeImplState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_saveNodeImplState(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadNodeImplState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer, OdGsBaseModel pModel)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_loadNodeImplState(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer), OdGsBaseModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void postprocessNodeImplLoading(OdGsFiler arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_postprocessNodeImplLoading(swigCPtr, OdGsFiler.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGsBlockReferenceNodeImpl constructNodeImpl(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer, OdGsBaseModel pModel, bool bRead)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_constructNodeImpl__SWIG_0(OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer), OdGsBaseModel.getCPtr(pModel), bRead);
		OdGsBlockReferenceNodeImpl result = ((intPtr == IntPtr.Zero) ? null : new OdGsBlockReferenceNodeImpl(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsBlockReferenceNodeImpl constructNodeImpl(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer, OdGsBaseModel pModel)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNodeImpl_constructNodeImpl__SWIG_1(OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer), OdGsBaseModel.getCPtr(pModel));
		OdGsBlockReferenceNodeImpl result = ((intPtr == IntPtr.Zero) ? null : new OdGsBlockReferenceNodeImpl(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
