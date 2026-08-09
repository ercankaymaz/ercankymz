using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsMInsertBlockNode : OdGsBlockReferenceNode
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsMInsertBlockNode(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsMInsertBlockNode obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsMInsertBlockNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsMInsertBlockNode cast(OdRxObject pObj)
	{
		OdGsMInsertBlockNode rXObject = Helpers.GetRXObject<OdGsMInsertBlockNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsMInsertBlockNode createObject()
	{
		OdGsMInsertBlockNode rXObject = Helpers.GetRXObject<OdGsMInsertBlockNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMInsertBlockNode(OdGsBaseModel pModel, OdGiDrawable pInsert, bool bSetGsNode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMInsertBlockNode__SWIG_0(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pInsert), bSetGsNode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsMInsertBlockNode(OdGsBaseModel pModel, OdGiDrawable pInsert)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMInsertBlockNode__SWIG_1(OdGsBaseModel.getCPtr(pModel), OdGiDrawable.getCPtr(pInsert)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void invalidate(OdGsContainerNode pParent, OdGsViewImpl pView, uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_invalidate(swigCPtr, OdGsContainerNode.getCPtr(pParent), OdGsViewImpl.getCPtr(pView), mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void destroy()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_destroy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void destroySubitems()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_destroySubitems(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void highlight(bool bDoIt, bool bWholeBranch, uint nSelStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_highlight__SWIG_0(swigCPtr, bDoIt, bWholeBranch, nSelStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(bool bDoIt, bool bWholeBranch)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_highlight__SWIG_1(swigCPtr, bDoIt, bWholeBranch);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsEntityNode firstEntity()
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_firstEntity(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsEntityNode firstAttrib()
	{
		OdGsEntityNode rXObject = Helpers.GetRXObject<OdGsEntityNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_firstAttrib__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool layersChanged(ref OdGsViewImpl view)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_layersChanged(swigCPtr, ref jarg);
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

	public override void playAsGeometry(OdGsBaseVectorizer view, EMetafilePlayMode eMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_playAsGeometry(swigCPtr, OdGsBaseVectorizer.getCPtr(view), (int)eMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void makeStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_makeStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void releaseStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_releaseStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void propagateLayerChangesStock()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_propagateLayerChangesStock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isMInsert()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_isMInsert(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsEntityNode firstAttrib(uint iInstance)
	{
		OdGsEntityNode result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_firstAttrib__SWIG_1(swigCPtr, iInstance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void stretchExtents()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_stretchExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setParams(OdGeMatrix3d blockTf, int nCols, int nRows, double sx, double sy)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_setParams(swigCPtr, OdGeMatrix3d.getCPtr(blockTf), nCols, nRows, sx, sy);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void doDisplay(OdGsDisplayContext ctx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_doDisplay(swigCPtr, ctx);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool doSelect(OdGsBaseVectorizer vect, OdGiDrawable pDrw, OdSiRecursiveVisitor pVisitor, OdGsView_SelectionMode mode)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_doSelect(swigCPtr, OdGsBaseVectorizer.getCPtr(vect), OdGiDrawable.getCPtr(pDrw), OdSiRecursiveVisitor.getCPtr(pVisitor), (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMInsertBlockNode_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
