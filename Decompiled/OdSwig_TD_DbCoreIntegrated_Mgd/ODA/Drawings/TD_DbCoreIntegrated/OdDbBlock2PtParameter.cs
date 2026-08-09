using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlock2PtParameter : OdDbBlockParameter
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBlock2PtParameter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlock2PtParameter obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlock2PtParameter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBlock2PtParameter cast(OdRxObject pObj)
	{
		OdDbBlock2PtParameter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlock2PtParameter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbBlock2PtParameter createObject()
	{
		OdDbBlock2PtParameter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlock2PtParameter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d basePoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_basePoint(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBasePoint(OdGePoint3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_setBasePoint(swigCPtr, OdGePoint3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d endPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEndPoint(OdGePoint3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_setEndPoint(swigCPtr, OdGePoint3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double distance()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_distance(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double angle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_angle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBlock2PtParameter_ParameterBaseLocation baseLocation()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_baseLocation(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbBlock2PtParameter_ParameterBaseLocation)result;
	}

	public void setBaseLocation(OdDbBlock2PtParameter_ParameterBaseLocation arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_setBaseLocation(swigCPtr, (int)arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d definitionBasePoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_definitionBasePoint(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDefinitionBasePoint(OdGePoint3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_setDefinitionBasePoint(swigCPtr, OdGePoint3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d definitionEndPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_definitionEndPoint(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDefinitionEndPoint(OdGePoint3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_setDefinitionEndPoint(swigCPtr, OdGePoint3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double definitionDistance()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_definitionDistance(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double definitionAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_definitionAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d updatedBasePoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_updatedBasePoint(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUpdatedBasePoint(OdGePoint3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_setUpdatedBasePoint(swigCPtr, OdGePoint3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d updatedEndPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_updatedEndPoint(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUpdatedEndPoint(OdGePoint3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_setUpdatedEndPoint(swigCPtr, OdGePoint3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double updatedDistance()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_updatedDistance(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double updatedAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_updatedAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_normal(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBlockGrip getAssociatedGrip(OdDbBlockParameter_ParameterComponent pc, OdDb_OpenMode mode)
	{
		OdDbBlockGrip rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockGrip>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_getAssociatedGrip__SWIG_0(swigCPtr, (int)pc, (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbBlockGrip getAssociatedGrip(OdDbBlockParameter_ParameterComponent pc)
	{
		OdDbBlockGrip rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockGrip>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_getAssociatedGrip__SWIG_1(swigCPtr, (int)pc), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void graphEvalEnd(bool nodeIsActive)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_graphEvalEnd(swigCPtr, nodeIsActive);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool parameterComponentHasAction(OdDbBlockParameter_ParameterComponent pc, OdDbBlockAction action)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_parameterComponentHasAction__SWIG_0(swigCPtr, (int)pc, OdDbBlockAction.getCPtr(action));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool parameterComponentHasAction(OdDbBlockParameter_ParameterComponent pc)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_parameterComponentHasAction__SWIG_1(swigCPtr, (int)pc);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlock2PtParameter_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
