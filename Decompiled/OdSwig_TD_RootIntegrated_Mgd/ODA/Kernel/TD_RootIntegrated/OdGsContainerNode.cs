using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsContainerNode : OdGsNode
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public OdMutex m_nodesMutex
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_m_nodesMutex_get(swigCPtr);
			OdMutex result = ((intPtr == IntPtr.Zero) ? null : new OdMutex(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsContainerNode(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsContainerNode obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsContainerNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public bool hasVpData(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_hasVpData(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint numVpData()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_numVpData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint isAttached(OdGsEntityNode pNode)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_isAttached(swigCPtr, OdGsEntityNode.getCPtr(pNode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEntityListsInvalid()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setEntityListsInvalid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint viewportId(OdGsViewImpl pView, bool bForceVpId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_viewportId__SWIG_0(swigCPtr, OdGsViewImpl.getCPtr(pView), bForceVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint viewportId(OdGsViewImpl pView)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_viewportId__SWIG_1(swigCPtr, OdGsViewImpl.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isVpDepCache()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_isVpDepCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVpDepCache(OdGsViewImpl pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setVpDepCache(swigCPtr, OdGsViewImpl.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEntityListValid(uint nVpId, bool entityListValid)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setEntityListValid(swigCPtr, nVpId, entityListValid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool childrenUpToDate(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_childrenUpToDate(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool needRegen(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_needRegen(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void addChildNode(uint nVpId, OdGsEntityNode pEnt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_addChildNode(swigCPtr, nVpId, OdGsEntityNode.getCPtr(pEnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void turnOnLights(OdGsBaseVectorizer view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_turnOnLights(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual ENodeType nodeType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_nodeType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (ENodeType)result;
	}

	public OdGsEntityNode firstEntityNode(uint nVpId)
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_firstEntityNode__SWIG_0(swigCPtr, nVpId), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsEntityNode lastEntityNode(uint nVpId)
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_lastEntityNode__SWIG_0(swigCPtr, nVpId), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p lightNodesList(uint nVpId)
	{
		OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p result = new OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_lightNodesList__SWIG_0(swigCPtr, nVpId), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint awareFlags(uint viewportId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_awareFlags(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAwareFlags(uint viewportId, uint flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setAwareFlags(swigCPtr, viewportId, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new static OdGsContainerNode cast(OdRxObject pObj)
	{
		OdGsContainerNode rXObject = Helpers.GetRXObject<OdGsContainerNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsContainerNode createObject()
	{
		OdGsContainerNode rXObject = Helpers.GetRXObject<OdGsContainerNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsContainerNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable, bool bSetGsNode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsContainerNode__SWIG_0(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable), bSetGsNode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsContainerNode(OdGsBaseModel pModel, OdGiDrawable pUnderlyingDrawable)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsContainerNode__SWIG_1(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnderlyingDrawable)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool entityListValid(uint nVpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_entityListValid(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool allEntityListsValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_allEntityListsValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setChildrenUpToDate(bool childrenUpToDate, uint nVpID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setChildrenUpToDate__SWIG_0(swigCPtr, childrenUpToDate, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setChildrenUpToDate(bool childrenUpToDate)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setChildrenUpToDate__SWIG_1(swigCPtr, childrenUpToDate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool childrenRegenDraw(uint nVpID)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_childrenRegenDraw(swigCPtr, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setChildrenRegenDraw(bool bVal, uint nVpID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setChildrenRegenDraw(swigCPtr, bVal, nVpID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addChild(OdGiDrawable pDrawable, OdGsViewImpl pView, bool unerased)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_addChild__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGsViewImpl.getCPtr(pView), unerased);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addChild(OdGiDrawable pDrawable, OdGsViewImpl pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_addChild__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGsViewImpl.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeLights(OdGsNode pOwner, uint nVpId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_removeLights__SWIG_0(swigCPtr, OdGsNode.getCPtr(pOwner), nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeLights(OdGsNode pOwner)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_removeLights__SWIG_1(swigCPtr, OdGsNode.getCPtr(pOwner));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeChild(OdGsNode pNode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_removeChild(swigCPtr, OdGsNode.getCPtr(pNode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void updateVisible(OdGsViewImpl pViewImpl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_updateVisible(swigCPtr, OdGsViewImpl.getCPtr(pViewImpl));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSiSpatialIndex spatialIndex(uint nVpId)
	{
		OdSiSpatialIndex rXObject = Helpers.GetRXObject<OdSiSpatialIndex>(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_spatialIndex__SWIG_0(swigCPtr, nVpId), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void invalidate(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_invalidate(swigCPtr, getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool Extents(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_Extents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool extents(OdGsView pView, OdGeExtents3d ext)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_extents(swigCPtr, OdGsView.getCPtr(pView), OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void propagateInvalidVpFlag()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_propagateInvalidVpFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool checkWorkset()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_checkWorkset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCheckWorkset(bool bVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setCheckWorkset(swigCPtr, bVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool findCompatibleCache(ref OdGsViewImpl keyView)
	{
		IntPtr jarg = ((keyView == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(keyView).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_findCompatibleCache(swigCPtr, ref jarg);
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
				keyView = null;
			}
			if (jarg != intPtr)
			{
				keyView = Helpers.GetRXObject<OdGsViewImpl>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public bool highlightSubnodes(uint nSubnodes, bool bHighlight, bool bAll, uint nSelStyle)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_highlightSubnodes__SWIG_0(swigCPtr, nSubnodes, bHighlight, bAll, nSelStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool highlightSubnodes(uint nSubnodes, bool bHighlight, bool bAll)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_highlightSubnodes__SWIG_1(swigCPtr, nSubnodes, bHighlight, bAll);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void destroy()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void destroySubitems()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_destroySubitems(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsUpdateExtents realExtents(uint nVpId)
	{
		OdGsUpdateExtents result = new OdGsUpdateExtents(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_realExtents(swigCPtr, nVpId), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRealExtents(uint nVpId, OdGsUpdateExtents ext, bool bRecompute)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setRealExtents__SWIG_0(swigCPtr, nVpId, OdGsUpdateExtents.getCPtr(ext), bRecompute);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRealExtents(uint nVpId, OdGsUpdateExtents ext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_setRealExtents__SWIG_1(swigCPtr, nVpId, OdGsUpdateExtents.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addViewRef(uint nVpId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_addViewRef(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeViewRef(uint nVpId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_removeViewRef(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ViewRefs viewRefs()
	{
		ViewRefs result = new ViewRefs(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_viewRefs(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public StockProps stock()
	{
		StockProps result = new StockProps(TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_stock(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void makeStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_makeStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void releaseStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_releaseStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void propagateLayerChangesStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_propagateLayerChangesStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool saveNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_saveNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool saveNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_saveNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool loadNodeState(OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_loadNodeState__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadNodeState(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_loadNodeState__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool postprocessNodeLoading(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_postprocessNodeLoading(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool saveLinkedLightSources(OdGsEntityNode pEntity, OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_saveLinkedLightSources(swigCPtr, OdGsEntityNode.getCPtr(pEntity), OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool loadLinkedLightSources(OdGsEntityNode pEntity, OdGsFiler pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_loadLinkedLightSources(swigCPtr, OdGsEntityNode.getCPtr(pEntity), OdGsFiler.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void removeErased()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_removeErased(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numberOfChildren(uint nVpId)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_numberOfChildren(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint numberOfChildrenST(uint nVpId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_numberOfChildrenST(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint numberOfChildrenErased(uint nVpId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_numberOfChildrenErased(swigCPtr, nVpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void addContentToUpdateManager(uint viewportId, OdGsUpdateManager pManager, UpdateManagerContext context)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_addContentToUpdateManager(swigCPtr, viewportId, OdGsUpdateManager.getCPtr(pManager), UpdateManagerContext.getCPtr(context));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsContainerNode_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
