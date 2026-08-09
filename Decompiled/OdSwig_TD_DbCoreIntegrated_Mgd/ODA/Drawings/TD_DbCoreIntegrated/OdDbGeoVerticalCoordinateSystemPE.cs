using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoVerticalCoordinateSystemPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoVerticalCoordinateSystemPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoVerticalCoordinateSystemPE_1();

	public delegate void SwigDelegateOdDbGeoVerticalCoordinateSystemPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystemPE_3([MarshalAs(UnmanagedType.LPWStr)] string sCoordSysIdOrFullDef, IntPtr pCoordSys);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystemPE_4(IntPtr arrCoordSys, IntPtr pCategory);

	public delegate int SwigDelegateOdDbGeoVerticalCoordinateSystemPE_5(IntPtr arrCoordSys);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoVerticalCoordinateSystemPE_0 swigDelegate0;

	private SwigDelegateOdDbGeoVerticalCoordinateSystemPE_1 swigDelegate1;

	private SwigDelegateOdDbGeoVerticalCoordinateSystemPE_2 swigDelegate2;

	private SwigDelegateOdDbGeoVerticalCoordinateSystemPE_3 swigDelegate3;

	private SwigDelegateOdDbGeoVerticalCoordinateSystemPE_4 swigDelegate4;

	private SwigDelegateOdDbGeoVerticalCoordinateSystemPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string),
		typeof(OdDbGeoVerticalCoordinateSystem).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator),
		typeof(OdDbGeoCoordinateSystemCategory)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoVerticalCoordinateSystemPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoVerticalCoordinateSystemPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoVerticalCoordinateSystemPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoVerticalCoordinateSystemPE cast(OdRxObject pObj)
	{
		OdDbGeoVerticalCoordinateSystemPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystemPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_isASwigExplicitOdDbGeoVerticalCoordinateSystemPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_queryXSwigExplicitOdDbGeoVerticalCoordinateSystemPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoVerticalCoordinateSystemPE createObject()
	{
		OdDbGeoVerticalCoordinateSystemPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystemPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult create(string sCoordSysIdOrFullDef, ref OdDbGeoVerticalCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : OdDbGeoVerticalCoordinateSystem.getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_create(swigCPtr, sCoordSysIdOrFullDef, ref jarg);
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

	public virtual OdResult createAll(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator arrCoordSys, OdDbGeoCoordinateSystemCategory pCategory)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_createAll__SWIG_0(swigCPtr, OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys), OdDbGeoCoordinateSystemCategory.getCPtr(pCategory));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createAll(OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator arrCoordSys)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_createAll__SWIG_1(swigCPtr, OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator.getCPtr(arrCoordSys));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbGeoVerticalCoordinateSystemPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGeoVerticalCoordinateSystemPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbGeoVerticalCoordinateSystemPE) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoVerticalCoordinateSystemPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoVerticalCoordinateSystemPE));
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

	private int SwigDirectorMethodcreate([MarshalAs(UnmanagedType.LPWStr)] string sCoordSysIdOrFullDef, IntPtr pCoordSys)
	{
		OdSwigDirectorHelper.director_UnpackData(pCoordSys, out var pOriginalObject, out var pFunction);
		OdDbGeoVerticalCoordinateSystem pCoordSys2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystem>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)create(sCoordSysIdOrFullDef, ref pCoordSys2);
		}
		finally
		{
			IntPtr handle = OdDbGeoVerticalCoordinateSystem.getCPtr(pCoordSys2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pCoordSys);
		}
	}

	private int SwigDirectorMethodcreateAll__SWIG_0(IntPtr arrCoordSys, IntPtr pCategory)
	{
		return (int)createAll(new OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator(arrCoordSys, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategory>(pCategory, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodcreateAll__SWIG_1(IntPtr arrCoordSys)
	{
		return (int)createAll(new OdArray_OdSmartPtr_OdDbGeoVerticalCoordinateSystem_OdObjectsAllocator(arrCoordSys, cMemoryOwn: false));
	}
}
