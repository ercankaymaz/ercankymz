using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseModelReactor : OdGsModelReactor
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseModelReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseModelReactor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseModelReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual bool onHighlight(OdGsModel pModel, OdGiPathNode path, bool bDoIt, out uint nStyle, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onHighlight__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiPathNode.getCPtr(path), bDoIt, out nStyle, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onHighlight(OdGsModel pModel, OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, out uint nStyle, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onHighlight__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, out nStyle, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onHide(OdGsModel pModel, OdGsNode pNode, out bool bHidden, out bool bSelectable, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onHide__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGsNode.getCPtr(pNode), out bHidden, out bSelectable, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onHide(OdGsModel pModel, OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, out bool bHidden, out bool bSelectable, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onHide__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, out bHidden, out bSelectable, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onExternalTransform(OdGsModel pModel, OdGiPathNode path, bool bDoIt, OdGsMatrixParam xForm, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onExternalTransform__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiPathNode.getCPtr(path), bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onExternalTransform(OdGsModel pModel, OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, OdGsMatrixParam xForm, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onExternalTransform__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onInvalidate(OdGsModel pModel, OdGsModel_InvalidationHint hint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onInvalidate__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), (int)hint);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onInvalidate(OdGsModel pModel, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onInvalidate__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onPropertyModified(OdGsModel pModel, OdGsBaseModelReactor_ModelProperty nProp)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelReactor_onPropertyModified(swigCPtr, OdGsModel.getCPtr(pModel), (int)nProp);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsBaseModelReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseModelReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
