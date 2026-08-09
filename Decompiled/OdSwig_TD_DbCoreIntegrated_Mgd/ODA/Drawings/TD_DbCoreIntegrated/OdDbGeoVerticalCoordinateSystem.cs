using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoVerticalCoordinateSystem : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoVerticalCoordinateSystem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoVerticalCoordinateSystem_1();

	public delegate void SwigDelegateOdDbGeoVerticalCoordinateSystem_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_3(IntPtr sCoordSysId);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_4(int nEpsgCode);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_5(OdDbGeoVerticalCoordinateSystem_Type eType);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_6(IntPtr sDescription);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_7(OdDbGeoVerticalCoordinateSystem_AxisDirection eAxisDirection);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_8(UnitsValue eUnitsValue);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_9(OdDbGeoCoordinateSystem_Unit eUnit);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_10(double dUnitScale);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_11(IntPtr datum);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_12(IntPtr sDatumId);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_13(IntPtr exts);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_14(IntPtr sXml);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystem_15(OdDbGeoCoordinateSystem_StatusType eStatusType);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_0 swigDelegate0;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_1 swigDelegate1;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_2 swigDelegate2;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_3 swigDelegate3;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_4 swigDelegate4;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_5 swigDelegate5;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_6 swigDelegate6;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_7 swigDelegate7;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_8 swigDelegate8;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_9 swigDelegate9;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_10 swigDelegate10;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_11 swigDelegate11;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_12 swigDelegate12;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_13 swigDelegate13;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_14 swigDelegate14;

	private SwigDelegateOdDbGeoVerticalCoordinateSystem_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(int).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbGeoVerticalCoordinateSystem_Type).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbGeoVerticalCoordinateSystem_AxisDirection).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(UnitsValue).MakeByRefType() };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDbGeoCoordinateSystem_Unit).MakeByRefType() };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbGeoDatum) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbGeoCoordinateSystem_StatusType).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoVerticalCoordinateSystem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoVerticalCoordinateSystem obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoVerticalCoordinateSystem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoVerticalCoordinateSystem cast(OdRxObject pObj)
	{
		OdDbGeoVerticalCoordinateSystem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_isASwigExplicitOdDbGeoVerticalCoordinateSystem(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_queryXSwigExplicitOdDbGeoVerticalCoordinateSystem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoVerticalCoordinateSystem createObject()
	{
		OdDbGeoVerticalCoordinateSystem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbGeoVerticalCoordinateSystem()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGeoVerticalCoordinateSystem(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbGeoVerticalCoordinateSystem) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual OdResult getId(ref string sCoordSysId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sCoordSysId);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getId(swigCPtr, ref jarg);
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
				sCoordSysId = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getEpsgCode(out int nEpsgCode)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getEpsgCode(swigCPtr, out nEpsgCode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getType(out OdDbGeoVerticalCoordinateSystem_Type eType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getType(swigCPtr, out eType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getDescription(ref string sDescription)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sDescription);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getDescription(swigCPtr, ref jarg);
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
				sDescription = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getAxisDirection(out OdDbGeoVerticalCoordinateSystem_AxisDirection eAxisDirection)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getAxisDirection(swigCPtr, out eAxisDirection);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getUnit(out UnitsValue eUnitsValue)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getUnit__SWIG_0(swigCPtr, out eUnitsValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getUnit(out OdDbGeoCoordinateSystem_Unit eUnit)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getUnit__SWIG_1(swigCPtr, out eUnit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getUnitScale(out double dUnitScale)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getUnitScale(swigCPtr, out dUnitScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getDatum(OdDbGeoDatum datum)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getDatum(swigCPtr, OdDbGeoDatum.getCPtr(datum));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getDatumId(ref string sDatumId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sDatumId);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getDatumId(swigCPtr, ref jarg);
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
				sDatumId = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getGeodeticExtents(OdGeExtents2d exts)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getGeodeticExtents(swigCPtr, OdGeExtents2d.getCPtr(exts));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getXmlRepresentation(ref string sXml)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sXml);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getXmlRepresentation(swigCPtr, ref jarg);
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
				sXml = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getStatus(out OdDbGeoCoordinateSystem_StatusType eStatusType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getStatus(swigCPtr, out eStatusType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult create(string sCoordSysIdOrFullDef, ref OdDbGeoVerticalCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_create(sCoordSysIdOrFullDef, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pCoordSys = null;
			}
			else if (jarg != intPtr)
			{
				pCoordSys = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystem>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult createAll(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator arrCoordSys, OdDbGeoCoordinateSystemCategory pCategory)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_createAll__SWIG_0(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys), OdDbGeoCoordinateSystemCategory.getCPtr(pCategory));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createAll(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator arrCoordSys)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_createAll__SWIG_1(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("getId", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetId;
		}
		if (SwigDerivedClassHasMethod("getEpsgCode", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetEpsgCode;
		}
		if (SwigDerivedClassHasMethod("getType", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetType;
		}
		if (SwigDerivedClassHasMethod("getDescription", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetDescription;
		}
		if (SwigDerivedClassHasMethod("getAxisDirection", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetAxisDirection;
		}
		if (SwigDerivedClassHasMethod("getUnit", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetUnit__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getUnit", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetUnit__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getUnitScale", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetUnitScale;
		}
		if (SwigDerivedClassHasMethod("getDatum", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetDatum;
		}
		if (SwigDerivedClassHasMethod("getDatumId", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetDatumId;
		}
		if (SwigDerivedClassHasMethod("getGeodeticExtents", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetGeodeticExtents;
		}
		if (SwigDerivedClassHasMethod("getXmlRepresentation", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetXmlRepresentation;
		}
		if (SwigDerivedClassHasMethod("getStatus", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetStatus;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoVerticalCoordinateSystem));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgetId(IntPtr sCoordSysId)
	{
		OdSwigDirectorHelper.director_UnpackData(sCoordSysId, out var pOriginalObject, out var pFunction);
		string sCoordSysId2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sCoordSysId2;
		try
		{
			return (int)getId(ref sCoordSysId2);
		}
		finally
		{
			if (sCoordSysId2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sCoordSysId2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sCoordSysId);
		}
	}

	private int SwigDirectorMethodgetEpsgCode(int nEpsgCode)
	{
		return (int)getEpsgCode(out nEpsgCode);
	}

	private int SwigDirectorMethodgetType(OdDbGeoVerticalCoordinateSystem_Type eType)
	{
		return (int)getType(out eType);
	}

	private int SwigDirectorMethodgetDescription(IntPtr sDescription)
	{
		OdSwigDirectorHelper.director_UnpackData(sDescription, out var pOriginalObject, out var pFunction);
		string sDescription2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sDescription2;
		try
		{
			return (int)getDescription(ref sDescription2);
		}
		finally
		{
			if (sDescription2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sDescription2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sDescription);
		}
	}

	private int SwigDirectorMethodgetAxisDirection(OdDbGeoVerticalCoordinateSystem_AxisDirection eAxisDirection)
	{
		return (int)getAxisDirection(out eAxisDirection);
	}

	private int SwigDirectorMethodgetUnit__SWIG_0(UnitsValue eUnitsValue)
	{
		return (int)getUnit(out eUnitsValue);
	}

	private int SwigDirectorMethodgetUnit__SWIG_1(OdDbGeoCoordinateSystem_Unit eUnit)
	{
		return (int)getUnit(out eUnit);
	}

	private int SwigDirectorMethodgetUnitScale(double dUnitScale)
	{
		return (int)getUnitScale(out dUnitScale);
	}

	private int SwigDirectorMethodgetDatum(IntPtr datum)
	{
		return (int)getDatum(new OdDbGeoDatum(datum, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetDatumId(IntPtr sDatumId)
	{
		OdSwigDirectorHelper.director_UnpackData(sDatumId, out var pOriginalObject, out var pFunction);
		string sDatumId2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sDatumId2;
		try
		{
			return (int)getDatumId(ref sDatumId2);
		}
		finally
		{
			if (sDatumId2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sDatumId2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sDatumId);
		}
	}

	private int SwigDirectorMethodgetGeodeticExtents(IntPtr exts)
	{
		return (int)getGeodeticExtents(new OdGeExtents2d(exts, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetXmlRepresentation(IntPtr sXml)
	{
		OdSwigDirectorHelper.director_UnpackData(sXml, out var pOriginalObject, out var pFunction);
		string sXml2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sXml2;
		try
		{
			return (int)getXmlRepresentation(ref sXml2);
		}
		finally
		{
			if (sXml2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sXml2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sXml);
		}
	}

	private int SwigDirectorMethodgetStatus(OdDbGeoCoordinateSystem_StatusType eStatusType)
	{
		return (int)getStatus(out eStatusType);
	}
}
