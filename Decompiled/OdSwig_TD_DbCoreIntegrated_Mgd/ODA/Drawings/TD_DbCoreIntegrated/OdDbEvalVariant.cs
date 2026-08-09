using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbEvalVariant : OdStaticRxObject_OdResBuf
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbEvalVariant(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbEvalVariant obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbEvalVariant(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbEvalVariant cast(OdRxObject pObj)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbEvalVariant createObject()
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(OdDbEvalVariant other)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_0(getCPtr(other)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(double dVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_2(dVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(short iVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_3(iVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(int lVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_4(lVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(long lVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_5(lVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(OdDbObjectId id)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_6(OdDbObjectId.getCPtr(id)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(OdGePoint2d pt)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_7(OdGePoint2d.getCPtr(pt)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(OdGePoint3d pt)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_8(OdGePoint3d.getCPtr(pt)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(OdResBuf rb)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_9(OdResBuf.getCPtr(rb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEvalVariant init(string str)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_init__SWIG_10(str), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(OdResBuf rb)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_0(swigCPtr, OdResBuf.getCPtr(rb)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(double dVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_1(swigCPtr, dVal), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(short iVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_2(swigCPtr, iVal), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(int lVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_3(swigCPtr, lVal), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(long lVal)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_4(swigCPtr, lVal), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(OdDbEvalVariant other)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_5(swigCPtr, getCPtr(other)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(OdDbObjectId id)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_7(swigCPtr, OdDbObjectId.getCPtr(id)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(OdGePoint2d pt)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_8(swigCPtr, OdGePoint2d.getCPtr(pt)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(OdGePoint3d pt)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_9(swigCPtr, OdGePoint3d.getCPtr(pt)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalVariant Assign(string str)
	{
		OdDbEvalVariant rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_Assign__SWIG_10(swigCPtr, str), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyFrom(OdRxObject pOther)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_copyFrom(swigCPtr, OdRxObject.getCPtr(pOther));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdDbEvalVariant val)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_IsEqual(swigCPtr, getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdDbEvalVariant val)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_IsNotEqual(swigCPtr, getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public DwgDataType getType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgDataType)result;
	}

	public OdResult setValue(int groupcode, double value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_0(swigCPtr, groupcode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(int groupcode, short value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_1(swigCPtr, groupcode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(int groupcode, int value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_2(swigCPtr, groupcode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(int groupcode, long value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_3(swigCPtr, groupcode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(int groupcode, string value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_4(swigCPtr, groupcode, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(int groupcode, OdDbObjectId value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_5(swigCPtr, groupcode, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(int groupcode, OdGePoint3d value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_6(swigCPtr, groupcode, OdGePoint3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(int groupcode, OdGePoint2d value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_setValue__SWIG_7(swigCPtr, groupcode, OdGePoint2d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(out double value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_0(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(out short value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_1(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(out int value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_2(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(out long value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_3(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_4(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public OdResult getValue(OdDbObjectId value, OdDbDatabase pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_5(swigCPtr, OdDbObjectId.getCPtr(value), OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(OdDbObjectId value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_6(swigCPtr, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(OdGePoint3d value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_7(swigCPtr, OdGePoint3d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getValue(OdGePoint2d value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getValue__SWIG_8(swigCPtr, OdGePoint2d.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public int getAsInt()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getAsInt(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getAsDouble()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getAsDouble(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEmpty()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_isEmpty(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string toString()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_toString(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalVariant_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
