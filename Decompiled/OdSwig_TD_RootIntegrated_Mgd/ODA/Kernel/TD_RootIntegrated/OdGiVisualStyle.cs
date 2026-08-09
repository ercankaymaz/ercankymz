using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVisualStyle : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVisualStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVisualStyle obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiVisualStyle cast(OdRxObject pObj)
	{
		OdGiVisualStyle rXObject = Helpers.GetRXObject<OdGiVisualStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiVisualStyle createObject()
	{
		OdGiVisualStyle rXObject = Helpers.GetRXObject<OdGiVisualStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiVisualStyle Assign(OdGiVisualStyle visualStyle)
	{
		OdGiVisualStyle rXObject = Helpers.GetRXObject<OdGiVisualStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_Assign(swigCPtr, getCPtr(visualStyle)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdGiVisualStyle visualStyle)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_IsEqual(swigCPtr, getCPtr(visualStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiFaceStyle faceStyle()
	{
		OdGiFaceStyle rXObject = Helpers.GetRXObject<OdGiFaceStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_faceStyle__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiEdgeStyle edgeStyle()
	{
		OdGiEdgeStyle rXObject = Helpers.GetRXObject<OdGiEdgeStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_edgeStyle__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiDisplayStyle displayStyle()
	{
		OdGiDisplayStyle rXObject = Helpers.GetRXObject<OdGiDisplayStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_displayStyle__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setFaceStyle(OdGiFaceStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setFaceStyle(swigCPtr, OdGiFaceStyle.getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEdgeStyle(OdGiEdgeStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setEdgeStyle(swigCPtr, OdGiEdgeStyle.getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDisplayStyle(OdGiDisplayStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setDisplayStyle(swigCPtr, OdGiDisplayStyle.getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void configureForType(OdGiVisualStyle_Type type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_configureForType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool setType(OdGiVisualStyle_Type type)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiVisualStyle_Type type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualStyle_Type)result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_0(swigCPtr, (int)prop, (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdGiVariant pVal, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_1(swigCPtr, (int)prop, OdGiVariant.getCPtr(pVal), (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdGiVariant pVal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_2(swigCPtr, (int)prop, OdGiVariant.getCPtr(pVal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, int nVal, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_3(swigCPtr, (int)prop, nVal, (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, int nVal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_4(swigCPtr, (int)prop, nVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, bool bVal, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_5(swigCPtr, (int)prop, bVal, (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, bool bVal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_6(swigCPtr, (int)prop, bVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, double dVal, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_7(swigCPtr, (int)prop, dVal, (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, double dVal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_8(swigCPtr, (int)prop, dVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, double red, double green, double blue, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_9(swigCPtr, (int)prop, red, green, blue, (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, double red, double green, double blue)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_10(swigCPtr, (int)prop, red, green, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdCmColorBase pColor, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_11(swigCPtr, (int)prop, OdCmColorBase.getCPtr(pColor), (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdCmColorBase pColor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_12(swigCPtr, (int)prop, OdCmColorBase.getCPtr(pColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdCmEntityColor pColor, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_13(swigCPtr, (int)prop, OdCmEntityColor.getCPtr(pColor), (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdCmEntityColor pColor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_14(swigCPtr, (int)prop, OdCmEntityColor.getCPtr(pColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, string pStr, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_15(swigCPtr, (int)prop, pStr, (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTrait(OdGiVisualStyleProperties_Property prop, string pStr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTrait__SWIG_16(swigCPtr, (int)prop, pStr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiVariant trait(OdGiVisualStyleProperties_Property prop, out OdGiVisualStyleOperations_Operation pOp)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_trait__SWIG_0(swigCPtr, (int)prop, out pOp), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiVariant trait(OdGiVisualStyleProperties_Property prop)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_trait__SWIG_1(swigCPtr, (int)prop), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiVisualStyleOperations_Operation operation(OdGiVisualStyleProperties_Property prop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_operation(swigCPtr, (int)prop);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualStyleOperations_Operation)result;
	}

	public virtual bool setTraitFlag(OdGiVisualStyleProperties_Property flagProp, uint flagVal, bool bEnable)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTraitFlag__SWIG_0(swigCPtr, (int)flagProp, flagVal, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setTraitFlag(OdGiVisualStyleProperties_Property flagProp, uint flagVal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_setTraitFlag__SWIG_1(swigCPtr, (int)flagProp, flagVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool traitFlag(OdGiVisualStyleProperties_Property flagProp, uint flagVal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_traitFlag(swigCPtr, (int)flagProp, flagVal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiVariant_VariantType propertyType(OdGiVisualStyleProperties_Property prop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_propertyType((int)prop);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVariant_VariantType)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyle_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
