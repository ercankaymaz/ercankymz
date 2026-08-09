using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCoordinateSystemPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemPE_1();

	public delegate void SwigDelegateOdDbGeoCoordinateSystemPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemPE_3([MarshalAs(UnmanagedType.LPWStr)] string coordSysIdOrFullDef, IntPtr pCoordSys);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemPE_4(IntPtr geoPt, IntPtr arrCoordSys);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemPE_5(IntPtr arrCoordSys, IntPtr pCategory);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemPE_6(IntPtr arrCoordSys);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCoordinateSystemPE_0 swigDelegate0;

	private SwigDelegateOdDbGeoCoordinateSystemPE_1 swigDelegate1;

	private SwigDelegateOdDbGeoCoordinateSystemPE_2 swigDelegate2;

	private SwigDelegateOdDbGeoCoordinateSystemPE_3 swigDelegate3;

	private SwigDelegateOdDbGeoCoordinateSystemPE_4 swigDelegate4;

	private SwigDelegateOdDbGeoCoordinateSystemPE_5 swigDelegate5;

	private SwigDelegateOdDbGeoCoordinateSystemPE_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string),
		typeof(OdDbGeoCoordinateSystem).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator),
		typeof(OdDbGeoCoordinateSystemCategory)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCoordinateSystemPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCoordinateSystemPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCoordinateSystemPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCoordinateSystemPE cast(OdRxObject pObj)
	{
		OdDbGeoCoordinateSystemPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_isASwigExplicitOdDbGeoCoordinateSystemPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_queryXSwigExplicitOdDbGeoCoordinateSystemPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCoordinateSystemPE createObject()
	{
		OdDbGeoCoordinateSystemPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult create(string coordSysIdOrFullDef, ref OdDbGeoCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : OdDbGeoCoordinateSystem.getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_create(swigCPtr, coordSysIdOrFullDef, ref jarg);
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

	public virtual OdResult createAll(OdGePoint3d geoPt, OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator arrCoordSys)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_createAll__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(geoPt), OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createAll(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator arrCoordSys, OdDbGeoCoordinateSystemCategory pCategory)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_createAll__SWIG_1(swigCPtr, OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys), OdDbGeoCoordinateSystemCategory.getCPtr(pCategory));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createAll(OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator arrCoordSys)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_createAll__SWIG_2(swigCPtr, OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("create", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreate;
		}
		if (SwigDerivedClassHasMethod("createAll", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcreateAll__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createAll", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateAll__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createAll", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcreateAll__SWIG_2;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCoordinateSystemPE));
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

	private int SwigDirectorMethodcreate([MarshalAs(UnmanagedType.LPWStr)] string coordSysIdOrFullDef, IntPtr pCoordSys)
	{
		OdSwigDirectorHelper.director_UnpackData(pCoordSys, out var pOriginalObject, out var pFunction);
		OdDbGeoCoordinateSystem pCoordSys2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystem>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)create(coordSysIdOrFullDef, ref pCoordSys2);
		}
		finally
		{
			IntPtr handle = OdDbGeoCoordinateSystem.getCPtr(pCoordSys2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pCoordSys);
		}
	}

	private int SwigDirectorMethodcreateAll__SWIG_0(IntPtr geoPt, IntPtr arrCoordSys)
	{
		return (int)createAll(new OdGePoint3d(geoPt, cMemoryOwn: false), new OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator(arrCoordSys, cMemoryOwn: false));
	}

	private int SwigDirectorMethodcreateAll__SWIG_1(IntPtr arrCoordSys, IntPtr pCategory)
	{
		return (int)createAll(new OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator(arrCoordSys, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategory>(pCategory, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodcreateAll__SWIG_2(IntPtr arrCoordSys)
	{
		return (int)createAll(new OdArray_OdSmartPtr_OdDbGeoCoordinateSystem_OdObjectsAllocator(arrCoordSys, cMemoryOwn: false));
	}
}
