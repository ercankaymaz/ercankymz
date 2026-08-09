using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCoordinateSystem : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystem_1();

	public delegate void SwigDelegateOdDbGeoCoordinateSystem_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_3(IntPtr sCoordSysId);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_4(int nEpsgCode);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_5(OdDbGeoCoordinateSystem_Type eType);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_6(IntPtr sDescription);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_7(IntPtr sSource);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_8(UnitsValue eUnitsValue);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_9(OdDbGeoCoordinateSystem_Unit eUnit);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_10(IntPtr sUnit);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_11(double dUnitScale);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_12(OdDbGeoCoordinateSystem_ProjectionCode ePrjCode);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_13(IntPtr arrPrjParams, bool bIncludeSpecialParams);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_14(IntPtr datum);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_15(IntPtr sDatumId);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_16(IntPtr ellipsoid);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_17(IntPtr vOffset);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_18(IntPtr exts);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_19(IntPtr exts);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_20(IntPtr sXml);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_21(IntPtr sWkt);

	public delegate int SwigDelegateOdDbGeoCoordinateSystem_22(OdDbGeoCoordinateSystem_StatusType eStatusType);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCoordinateSystem_0 swigDelegate0;

	private SwigDelegateOdDbGeoCoordinateSystem_1 swigDelegate1;

	private SwigDelegateOdDbGeoCoordinateSystem_2 swigDelegate2;

	private SwigDelegateOdDbGeoCoordinateSystem_3 swigDelegate3;

	private SwigDelegateOdDbGeoCoordinateSystem_4 swigDelegate4;

	private SwigDelegateOdDbGeoCoordinateSystem_5 swigDelegate5;

	private SwigDelegateOdDbGeoCoordinateSystem_6 swigDelegate6;

	private SwigDelegateOdDbGeoCoordinateSystem_7 swigDelegate7;

	private SwigDelegateOdDbGeoCoordinateSystem_8 swigDelegate8;

	private SwigDelegateOdDbGeoCoordinateSystem_9 swigDelegate9;

	private SwigDelegateOdDbGeoCoordinateSystem_10 swigDelegate10;

	private SwigDelegateOdDbGeoCoordinateSystem_11 swigDelegate11;

	private SwigDelegateOdDbGeoCoordinateSystem_12 swigDelegate12;

	private SwigDelegateOdDbGeoCoordinateSystem_13 swigDelegate13;

	private SwigDelegateOdDbGeoCoordinateSystem_14 swigDelegate14;

	private SwigDelegateOdDbGeoCoordinateSystem_15 swigDelegate15;

	private SwigDelegateOdDbGeoCoordinateSystem_16 swigDelegate16;

	private SwigDelegateOdDbGeoCoordinateSystem_17 swigDelegate17;

	private SwigDelegateOdDbGeoCoordinateSystem_18 swigDelegate18;

	private SwigDelegateOdDbGeoCoordinateSystem_19 swigDelegate19;

	private SwigDelegateOdDbGeoCoordinateSystem_20 swigDelegate20;

	private SwigDelegateOdDbGeoCoordinateSystem_21 swigDelegate21;

	private SwigDelegateOdDbGeoCoordinateSystem_22 swigDelegate22;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(int).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbGeoCoordinateSystem_Type).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(UnitsValue).MakeByRefType() };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDbGeoCoordinateSystem_Unit).MakeByRefType() };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbGeoCoordinateSystem_ProjectionCode).MakeByRefType() };

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdArray_OdDbGeoProjectionParameter_OdObjectsAllocator),
		typeof(bool)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbGeoDatum) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbGeoEllipsoid) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGeVector2d) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdDbGeoCoordinateSystem_StatusType).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCoordinateSystem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCoordinateSystem obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCoordinateSystem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCoordinateSystem cast(OdRxObject pObj)
	{
		OdDbGeoCoordinateSystem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_isASwigExplicitOdDbGeoCoordinateSystem(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_queryXSwigExplicitOdDbGeoCoordinateSystem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCoordinateSystem createObject()
	{
		OdDbGeoCoordinateSystem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getId(ref string sCoordSysId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sCoordSysId);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getId(swigCPtr, ref jarg);
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
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getEpsgCode(swigCPtr, out nEpsgCode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getType(out OdDbGeoCoordinateSystem_Type eType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getType(swigCPtr, out eType);
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
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getDescription(swigCPtr, ref jarg);
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

	public virtual OdResult getSource(ref string sSource)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sSource);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getSource(swigCPtr, ref jarg);
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
				sSource = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getUnit(out UnitsValue eUnitsValue)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getUnit__SWIG_0(swigCPtr, out eUnitsValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getUnit(out OdDbGeoCoordinateSystem_Unit eUnit)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getUnit__SWIG_1(swigCPtr, out eUnit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getUnit(ref string sUnit)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sUnit);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getUnit__SWIG_2(swigCPtr, ref jarg);
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
				sUnit = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getUnitScale(out double dUnitScale)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getUnitScale(swigCPtr, out dUnitScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getProjectionCode(out OdDbGeoCoordinateSystem_ProjectionCode ePrjCode)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getProjectionCode(swigCPtr, out ePrjCode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getProjectionParameters(OdArray_OdDbGeoProjectionParameter_OdObjectsAllocator arrPrjParams, bool bIncludeSpecialParams)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getProjectionParameters(swigCPtr, OdArray_OdDbGeoProjectionParameter_OdObjectsAllocator.getCPtr(arrPrjParams), bIncludeSpecialParams);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getDatum(OdDbGeoDatum datum)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getDatum(swigCPtr, OdDbGeoDatum.getCPtr(datum));
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
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getDatumId(swigCPtr, ref jarg);
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

	public virtual OdResult getEllipsoid(OdDbGeoEllipsoid ellipsoid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getEllipsoid(swigCPtr, OdDbGeoEllipsoid.getCPtr(ellipsoid));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getOffset(OdGeVector2d vOffset)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getOffset(swigCPtr, OdGeVector2d.getCPtr(vOffset).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getCartesianExtents(OdGeExtents2d exts)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getCartesianExtents(swigCPtr, OdGeExtents2d.getCPtr(exts));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGeodeticExtents(OdGeExtents2d exts)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getGeodeticExtents(swigCPtr, OdGeExtents2d.getCPtr(exts));
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
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getXmlRepresentation(swigCPtr, ref jarg);
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

	public virtual OdResult getWktRepresentation(ref string sWkt)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sWkt);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getWktRepresentation(swigCPtr, ref jarg);
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
				sWkt = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getStatus(out OdDbGeoCoordinateSystem_StatusType eStatusType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getStatus(swigCPtr, out eStatusType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult create(string sCoordSysIdOrFullDef, ref OdDbGeoCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_create(sCoordSysIdOrFullDef, ref jarg);
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
				pCoordSys = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystem>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult createAll(OdGePoint3d ptGeo, OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator arrCoordSys)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_createAll__SWIG_0(OdGePoint3d.getCPtr(ptGeo), OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createAll(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator arrCoordSys, OdDbGeoCoordinateSystemCategory pCategory)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_createAll__SWIG_1(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys), OdDbGeoCoordinateSystemCategory.getCPtr(pCategory));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createAll(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator arrCoordSys)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_createAll__SWIG_2(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getSource", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetSource;
		}
		if (SwigDerivedClassHasMethod("getUnit", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetUnit__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getUnit", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetUnit__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getUnit", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetUnit__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getUnitScale", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetUnitScale;
		}
		if (SwigDerivedClassHasMethod("getProjectionCode", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetProjectionCode;
		}
		if (SwigDerivedClassHasMethod("getProjectionParameters", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetProjectionParameters;
		}
		if (SwigDerivedClassHasMethod("getDatum", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetDatum;
		}
		if (SwigDerivedClassHasMethod("getDatumId", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetDatumId;
		}
		if (SwigDerivedClassHasMethod("getEllipsoid", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetEllipsoid;
		}
		if (SwigDerivedClassHasMethod("getOffset", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetOffset;
		}
		if (SwigDerivedClassHasMethod("getCartesianExtents", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetCartesianExtents;
		}
		if (SwigDerivedClassHasMethod("getGeodeticExtents", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetGeodeticExtents;
		}
		if (SwigDerivedClassHasMethod("getXmlRepresentation", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetXmlRepresentation;
		}
		if (SwigDerivedClassHasMethod("getWktRepresentation", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetWktRepresentation;
		}
		if (SwigDerivedClassHasMethod("getStatus", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetStatus;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCoordinateSystem));
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

	private int SwigDirectorMethodgetType(OdDbGeoCoordinateSystem_Type eType)
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

	private int SwigDirectorMethodgetSource(IntPtr sSource)
	{
		OdSwigDirectorHelper.director_UnpackData(sSource, out var pOriginalObject, out var pFunction);
		string sSource2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sSource2;
		try
		{
			return (int)getSource(ref sSource2);
		}
		finally
		{
			if (sSource2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sSource2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sSource);
		}
	}

	private int SwigDirectorMethodgetUnit__SWIG_0(UnitsValue eUnitsValue)
	{
		return (int)getUnit(out eUnitsValue);
	}

	private int SwigDirectorMethodgetUnit__SWIG_1(OdDbGeoCoordinateSystem_Unit eUnit)
	{
		return (int)getUnit(out eUnit);
	}

	private int SwigDirectorMethodgetUnit__SWIG_2(IntPtr sUnit)
	{
		OdSwigDirectorHelper.director_UnpackData(sUnit, out var pOriginalObject, out var pFunction);
		string sUnit2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sUnit2;
		try
		{
			return (int)getUnit(ref sUnit2);
		}
		finally
		{
			if (sUnit2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sUnit2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sUnit);
		}
	}

	private int SwigDirectorMethodgetUnitScale(double dUnitScale)
	{
		return (int)getUnitScale(out dUnitScale);
	}

	private int SwigDirectorMethodgetProjectionCode(OdDbGeoCoordinateSystem_ProjectionCode ePrjCode)
	{
		return (int)getProjectionCode(out ePrjCode);
	}

	private int SwigDirectorMethodgetProjectionParameters(IntPtr arrPrjParams, bool bIncludeSpecialParams)
	{
		return (int)getProjectionParameters(new OdArray_OdDbGeoProjectionParameter_OdObjectsAllocator(arrPrjParams, cMemoryOwn: false), bIncludeSpecialParams);
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

	private int SwigDirectorMethodgetEllipsoid(IntPtr ellipsoid)
	{
		return (int)getEllipsoid(new OdDbGeoEllipsoid(ellipsoid, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetOffset(IntPtr vOffset)
	{
		return (int)getOffset(new OdGeVector2d(vOffset, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetCartesianExtents(IntPtr exts)
	{
		return (int)getCartesianExtents(new OdGeExtents2d(exts, cMemoryOwn: false));
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

	private int SwigDirectorMethodgetWktRepresentation(IntPtr sWkt)
	{
		OdSwigDirectorHelper.director_UnpackData(sWkt, out var pOriginalObject, out var pFunction);
		string sWkt2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sWkt2;
		try
		{
			return (int)getWktRepresentation(ref sWkt2);
		}
		finally
		{
			if (sWkt2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sWkt2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sWkt);
		}
	}

	private int SwigDirectorMethodgetStatus(OdDbGeoCoordinateSystem_StatusType eStatusType)
	{
		return (int)getStatus(out eStatusType);
	}
}
