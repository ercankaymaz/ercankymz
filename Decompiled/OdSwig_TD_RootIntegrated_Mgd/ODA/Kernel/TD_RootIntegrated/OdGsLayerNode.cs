using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsLayerNode : OdGsNode
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsLayerNode(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsLayerNode obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsLayerNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsLayerNode cast(OdRxObject pObj)
	{
		OdGsLayerNode rXObject = Helpers.GetRXObject<OdGsLayerNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsLayerNode createObject()
	{
		OdGsLayerNode rXObject = Helpers.GetRXObject<OdGsLayerNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsLayerNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable, bool bSetGsNode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsLayerNode__SWIG_0(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable), bSetGsNode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsLayerNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsLayerNode__SWIG_1(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void destroy()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiLayerTraitsData layerTraits(uint nVpId, bool bVpFrozen)
	{
		OdGiLayerTraitsData result = new OdGiLayerTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_layerTraits__SWIG_0(swigCPtr, nVpId, bVpFrozen), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiLayerTraitsData layerTraits(uint nVpId)
	{
		OdGiLayerTraitsData result = new OdGiLayerTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_layerTraits__SWIG_1(swigCPtr, nVpId), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void reserveLayerTraits(uint nVpId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_reserveLayerTraits(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDirty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isDirty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDirty(bool bDirty)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_setDirty(swigCPtr, bDirty);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isUpToDate(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isUpToDate(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidCache(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isValidCache(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCacheUpToDate(uint nVpId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_setCacheUpToDate(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInvalidated()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isInvalidated(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isVpDep()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isVpDep(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ENodeType nodeType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_nodeType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (ENodeType)result;
	}

	public bool isVpFrozen()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isVpFrozen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isFrozen()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isFrozen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void invalidate(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_invalidate(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isTraitsCompatible(uint nVpId1, uint nVpId2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_isTraitsCompatible(swigCPtr, nVpId1, nVpId2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool saveNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_saveNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool saveNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_saveNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_loadNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_loadNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsLayerNode_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
