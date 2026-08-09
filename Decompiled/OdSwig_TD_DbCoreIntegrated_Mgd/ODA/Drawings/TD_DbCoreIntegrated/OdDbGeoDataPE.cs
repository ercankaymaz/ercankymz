using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoDataPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoDataPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoDataPE_1();

	public delegate void SwigDelegateOdDbGeoDataPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoDataPE_3(IntPtr pGeoData, double dLongitude, double dLatitude, double dAltitude, double dDwgX, double dDwgY, double dDwgZ);

	public delegate int SwigDelegateOdDbGeoDataPE_4(IntPtr pGeoData, double dDwgX, double dDwgY, double dDwgZ, double dLongitude, double dLatitude, double dAltitude);

	public delegate bool SwigDelegateOdDbGeoDataPE_5([MarshalAs(UnmanagedType.LPWStr)] string sCoordinateSystem);

	public delegate int SwigDelegateOdDbGeoDataPE_6(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sNewCsId);

	public delegate int SwigDelegateOdDbGeoDataPE_7(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sOldCsId);

	public delegate int SwigDelegateOdDbGeoDataPE_8(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sNewCsId, [MarshalAs(UnmanagedType.LPWStr)] string arg2);

	public delegate int SwigDelegateOdDbGeoDataPE_9(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sOldCsId, [MarshalAs(UnmanagedType.LPWStr)] string arg2);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoDataPE_0 swigDelegate0;

	private SwigDelegateOdDbGeoDataPE_1 swigDelegate1;

	private SwigDelegateOdDbGeoDataPE_2 swigDelegate2;

	private SwigDelegateOdDbGeoDataPE_3 swigDelegate3;

	private SwigDelegateOdDbGeoDataPE_4 swigDelegate4;

	private SwigDelegateOdDbGeoDataPE_5 swigDelegate5;

	private SwigDelegateOdDbGeoDataPE_6 swigDelegate6;

	private SwigDelegateOdDbGeoDataPE_7 swigDelegate7;

	private SwigDelegateOdDbGeoDataPE_8 swigDelegate8;

	private SwigDelegateOdDbGeoDataPE_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[7]
	{
		typeof(OdDbGeoData),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[7]
	{
		typeof(OdDbGeoData),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbGeoData),
		typeof(string)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbGeoData),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdDbGeoData),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdDbGeoData),
		typeof(string),
		typeof(string)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoDataPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoDataPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoDataPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoDataPE cast(OdRxObject pObj)
	{
		OdDbGeoDataPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoDataPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_isASwigExplicitOdDbGeoDataPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_queryXSwigExplicitOdDbGeoDataPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoDataPE createObject()
	{
		OdDbGeoDataPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoDataPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult transformFromLonLatAlt(OdDbGeoData pGeoData, double dLongitude, double dLatitude, double dAltitude, out double dDwgX, out double dDwgY, out double dDwgZ)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_transformFromLonLatAlt(swigCPtr, OdDbGeoData.getCPtr(pGeoData), dLongitude, dLatitude, dAltitude, out dDwgX, out dDwgY, out dDwgZ);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult transformToLonLatAlt(OdDbGeoData pGeoData, double dDwgX, double dDwgY, double dDwgZ, out double dLongitude, out double dLatitude, out double dAltitude)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_transformToLonLatAlt(swigCPtr, OdDbGeoData.getCPtr(pGeoData), dDwgX, dDwgY, dDwgZ, out dLongitude, out dLatitude, out dAltitude);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool validateCs(string sCoordinateSystem)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_validateCs(swigCPtr, sCoordinateSystem);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult geoCoordinateSystemWillChange(OdDbGeoData pGeoData, string sNewCsId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_geoCoordinateSystemWillChange__SWIG_0(swigCPtr, OdDbGeoData.getCPtr(pGeoData), sNewCsId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult geoCoordinateSystemChanged(OdDbGeoData pGeoData, string sOldCsId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_geoCoordinateSystemChanged__SWIG_0(swigCPtr, OdDbGeoData.getCPtr(pGeoData), sOldCsId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult geoCoordinateSystemWillChange(OdDbGeoData pGeoData, string sNewCsId, string arg2)
	{
		int result = (SwigDerivedClassHasMethod("geoCoordinateSystemWillChange", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_geoCoordinateSystemWillChangeSwigExplicitOdDbGeoDataPE__SWIG_1(swigCPtr, OdDbGeoData.getCPtr(pGeoData), sNewCsId, arg2) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_geoCoordinateSystemWillChange__SWIG_1(swigCPtr, OdDbGeoData.getCPtr(pGeoData), sNewCsId, arg2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult geoCoordinateSystemChanged(OdDbGeoData pGeoData, string sOldCsId, string arg2)
	{
		int result = (SwigDerivedClassHasMethod("geoCoordinateSystemChanged", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_geoCoordinateSystemChangedSwigExplicitOdDbGeoDataPE__SWIG_1(swigCPtr, OdDbGeoData.getCPtr(pGeoData), sOldCsId, arg2) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_geoCoordinateSystemChanged__SWIG_1(swigCPtr, OdDbGeoData.getCPtr(pGeoData), sOldCsId, arg2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("transformFromLonLatAlt", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtransformFromLonLatAlt;
		}
		if (SwigDerivedClassHasMethod("transformToLonLatAlt", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodtransformToLonLatAlt;
		}
		if (SwigDerivedClassHasMethod("validateCs", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodvalidateCs;
		}
		if (SwigDerivedClassHasMethod("geoCoordinateSystemWillChange", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgeoCoordinateSystemWillChange__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("geoCoordinateSystemChanged", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgeoCoordinateSystemChanged__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("geoCoordinateSystemWillChange", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgeoCoordinateSystemWillChange__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("geoCoordinateSystemChanged", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgeoCoordinateSystemChanged__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoDataPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoDataPE));
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

	private int SwigDirectorMethodtransformFromLonLatAlt(IntPtr pGeoData, double dLongitude, double dLatitude, double dAltitude, double dDwgX, double dDwgY, double dDwgZ)
	{
		return (int)transformFromLonLatAlt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoData>(pGeoData, bOwn: false, bTryAddToTransaction: false), dLongitude, dLatitude, dAltitude, out dDwgX, out dDwgY, out dDwgZ);
	}

	private int SwigDirectorMethodtransformToLonLatAlt(IntPtr pGeoData, double dDwgX, double dDwgY, double dDwgZ, double dLongitude, double dLatitude, double dAltitude)
	{
		return (int)transformToLonLatAlt(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoData>(pGeoData, bOwn: false, bTryAddToTransaction: false), dDwgX, dDwgY, dDwgZ, out dLongitude, out dLatitude, out dAltitude);
	}

	private bool SwigDirectorMethodvalidateCs([MarshalAs(UnmanagedType.LPWStr)] string sCoordinateSystem)
	{
		return validateCs(sCoordinateSystem);
	}

	private int SwigDirectorMethodgeoCoordinateSystemWillChange__SWIG_0(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sNewCsId)
	{
		return (int)geoCoordinateSystemWillChange(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoData>(pGeoData, bOwn: false, bTryAddToTransaction: false), sNewCsId);
	}

	private int SwigDirectorMethodgeoCoordinateSystemChanged__SWIG_0(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sOldCsId)
	{
		return (int)geoCoordinateSystemChanged(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoData>(pGeoData, bOwn: false, bTryAddToTransaction: false), sOldCsId);
	}

	private int SwigDirectorMethodgeoCoordinateSystemWillChange__SWIG_1(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sNewCsId, [MarshalAs(UnmanagedType.LPWStr)] string arg2)
	{
		return (int)geoCoordinateSystemWillChange(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoData>(pGeoData, bOwn: false, bTryAddToTransaction: false), sNewCsId, arg2);
	}

	private int SwigDirectorMethodgeoCoordinateSystemChanged__SWIG_1(IntPtr pGeoData, [MarshalAs(UnmanagedType.LPWStr)] string sOldCsId, [MarshalAs(UnmanagedType.LPWStr)] string arg2)
	{
		return (int)geoCoordinateSystemChanged(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoData>(pGeoData, bOwn: false, bTryAddToTransaction: false), sOldCsId, arg2);
	}
}
