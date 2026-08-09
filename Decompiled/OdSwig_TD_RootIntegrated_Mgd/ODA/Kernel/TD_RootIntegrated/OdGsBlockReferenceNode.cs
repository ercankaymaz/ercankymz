using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBlockReferenceNode : OdGsEntityNode
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBlockReferenceNode(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBlockReferenceNode obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBlockReferenceNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsBlockReferenceNode cast(OdRxObject pObj)
	{
		OdGsBlockReferenceNode rXObject = Helpers.GetRXObject<OdGsBlockReferenceNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsBlockReferenceNode createObject()
	{
		OdGsBlockReferenceNode rXObject = Helpers.GetRXObject<OdGsBlockReferenceNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsBlockReferenceNode(OdGsBaseModel pModel, OdGiDrawable pDrawable, bool bSetGsNode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBlockReferenceNode__SWIG_0(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pDrawable), bSetGsNode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsBlockReferenceNode(OdGsBaseModel pModel, OdGiDrawable pDrawable)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBlockReferenceNode__SWIG_1(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pDrawable)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setValid(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_setValid(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool excludeFromViewExt()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_excludeFromViewExt(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExcludeFromViewExt(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_setExcludeFromViewExt(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isForceNotEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_isForceNotEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForceNotEmpty(bool b)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_setForceNotEmpty(swigCPtr, b);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isReference()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_isReference(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isSelfReferential()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_isSelfReferential(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool layersChanged(ref OdGsViewImpl view)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_layersChanged(swigCPtr, ref jarg);
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

	public new virtual void propagateLayerChanges(ref OdGsViewImpl view)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_propagateLayerChanges(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
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

	public new virtual void invalidate(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_invalidate(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void destroy()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void destroySubitems()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_destroySubitems(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool select(OdGsBaseVectorizer view, OdSiRecursiveVisitor arg1, OdGsView_SelectionMode mode)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_select(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdSiRecursiveVisitor.getCPtr(arg1), (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint awareFlags(uint viewportId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_awareFlags(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool awareFlagsAreInvalid(uint viewportId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_awareFlagsAreInvalid(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsEntityNode firstEntity()
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_firstEntity(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsEntityNode firstAttrib()
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_firstAttrib(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsBlockNode blockNode()
	{
		OdGsBlockNode rXObject = Helpers.GetRXObject<OdGsBlockNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_blockNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void clearBlockNode()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_clearBlockNode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void makeStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_makeStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void releaseStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_releaseStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void propagateLayerChangesStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_propagateLayerChangesStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void updateBlockNode(OdGiDrawable pBlockTableRecord)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_updateBlockNode(swigCPtr, OdGiDrawable.getCPtr(pBlockTableRecord));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr sharedDefinition(OdGsViewImpl view)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_sharedDefinition(swigCPtr, OdGsViewImpl.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMInsert()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_isMInsert(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsBlockReferenceNode create(OdGsBaseModel pModel, OdGiDrawable pDrawable)
	{
		OdGsBlockReferenceNode rXObject = Helpers.GetRXObject<OdGsBlockReferenceNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_create(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pDrawable)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void doDisplay(OdGsDisplayContext ctx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_doDisplay(swigCPtr, ctx);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool doSelect(OdGsBaseVectorizer vect, OdGiDrawable pDrw, OdSiRecursiveVisitor pVisitor, OdGsView_SelectionMode mode)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_doSelect(swigCPtr, OdGsBaseVectorizer.getCPtr(vect), OdGiDrawable.getCPtr(pDrw), OdSiRecursiveVisitor.getCPtr(pVisitor), (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void spatialQuery(OdGsView view, OdSiRecursiveVisitor pVisitor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_spatialQuery(swigCPtr, OdGsView.getCPtr(view), OdSiRecursiveVisitor.getCPtr(pVisitor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getSharedTransform(OdGeMatrix3d transform)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_getSharedTransform(swigCPtr, OdGeMatrix3d.getCPtr(transform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void invalidateBlockNode(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask, bool bRecursively)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_invalidateBlockNode__SWIG_0(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask, bRecursively);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidateBlockNode(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_invalidateBlockNode__SWIG_1(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockReferenceNode_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
