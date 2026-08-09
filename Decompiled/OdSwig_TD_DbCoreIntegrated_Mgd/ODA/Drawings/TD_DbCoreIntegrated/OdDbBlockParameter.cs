using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlockParameter : OdDbBlockElement
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBlockParameter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlockParameter obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlockParameter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBlockParameter cast(OdRxObject pObj)
	{
		OdDbBlockParameter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockParameter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbBlockParameter createObject()
	{
		OdDbBlockParameter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockParameter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void removedFromGraph(OdDbEvalGraph arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_removedFromGraph(swigCPtr, OdDbEvalGraph.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getPropertyConnectionName(string arg0)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getPropertyConnectionName(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getPropertyDescription(OdDbBlkParamPropertyDescriptorArray arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getPropertyDescription(swigCPtr, OdDbBlkParamPropertyDescriptorArray.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbEvalVariant getPropertyValue(string name)
	{
		OdDbEvalVariant result = new OdDbEvalVariant(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getPropertyValue__SWIG_0(swigCPtr, name), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbEvalVariant getPropertyValue(string name, OdGeMatrix3d matrix)
	{
		OdDbEvalVariant result = new OdDbEvalVariant(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getPropertyValue__SWIG_1(swigCPtr, name, OdGeMatrix3d.getCPtr(matrix).Handle), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setPropertyValue(string name, OdDbEvalVariant value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_setPropertyValue__SWIG_0(swigCPtr, name, OdDbEvalVariant.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setPropertyValue(string name, OdGeMatrix3d matrix, OdDbEvalVariant value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_setPropertyValue__SWIG_1(swigCPtr, name, OdGeMatrix3d.getCPtr(matrix).Handle, OdDbEvalVariant.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void gripErased(OdDbBlockParameter_ParameterComponent arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_gripErased(swigCPtr, (int)arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getGrips(OdDbBlockGripPtrArray arg0, OdDb_OpenMode arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getGrips__SWIG_0(swigCPtr, OdDbBlockGripPtrArray.getCPtr(arg0), (int)arg1);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getGrips(OdDbBlockGripPtrArray arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getGrips__SWIG_1(swigCPtr, OdDbBlockGripPtrArray.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getNumberOfGrips()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getNumberOfGrips(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbBlockParameter_ParameterComponent getComponentForGrip(uint arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getComponentForGrip(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbBlockParameter_ParameterComponent)result;
	}

	public virtual void removeGrip(OdDbBlockParameter_ParameterComponent arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_removeGrip(swigCPtr, (int)arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void resetGrips()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_resetGrips(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNumberOfGrips(int arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_setNumberOfGrips(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool chainActions()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_chainActions(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setChainActions(bool arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_setChainActions(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool showProperties()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_showProperties(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShowProperties(bool arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_setShowProperties(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint addGrip(OdDbBlockParameter_ParameterComponent arg0)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_addGrip(swigCPtr, (int)arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short orderInPropertyPalette()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_orderInPropertyPalette(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOrderInPropertyPalette(short order)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_setOrderInPropertyPalette(swigCPtr, order);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isPropertyLabelUnique(OdDbEvalGraph graph, string label, ref string suffix)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(suffix);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_isPropertyLabelUnique__SWIG_0(OdDbEvalGraph.getCPtr(graph), label, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				suffix = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static bool isPropertyLabelUnique(OdDbEvalGraph graph, string label)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_isPropertyLabelUnique__SWIG_1(OdDbEvalGraph.getCPtr(graph), label);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string toolTipString()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_toolTipString(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParameter_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
