using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsMaterialNode : OdGsNode
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsMaterialNode(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsMaterialNode obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsMaterialNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsMaterialNode cast(OdRxObject pObj)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsMaterialNode createObject()
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable, bool bSetGsNode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMaterialNode__SWIG_0(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable), bSetGsNode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsMaterialNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMaterialNode__SWIG_1(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void destroy()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTraitsData materialTraits()
	{
		OdGiMaterialTraitsData result = new OdGiMaterialTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_materialTraits__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void onModified(OdGsBaseVectorizer view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_onModified(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void invalidate(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_invalidate(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidateModule(IntPtr pModule)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_invalidateModule(swigCPtr, pModule);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsMaterialNode nextNode()
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_nextNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode prevNode()
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_prevNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode setNextNode(OdGsMaterialNode newNode)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_setNextNode(swigCPtr, getCPtr(newNode)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode setPrevNode(OdGsMaterialNode newNode)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_setPrevNode(swigCPtr, getCPtr(newNode)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isDataModified()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_isDataModified(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCachedDataModified(OdGsBaseVectorizer view)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_isCachedDataModified(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCachedDataUpdated(OdGsBaseVectorizer view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_setCachedDataUpdated(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject cachedData(OdGsBaseVectorizer view)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_cachedData(swigCPtr, OdGsBaseVectorizer.getCPtr(view)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setCachedData(OdGsBaseVectorizer view, OdRxObject newCachedData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_setCachedData(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdRxObject.getCPtr(newCachedData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdMutexPtr cacheMutex()
	{
		OdMutexPtr result = new OdMutexPtr(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_cacheMutex(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ENodeType nodeType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_nodeType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (ENodeType)result;
	}

	public override bool saveNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_saveNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool saveNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_saveNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_loadNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_loadNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialNode_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
