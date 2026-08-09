using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCompoundCoordinateSystemPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCompoundCoordinateSystemPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCompoundCoordinateSystemPE_1();

	public delegate void SwigDelegateOdDbGeoCompoundCoordinateSystemPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCompoundCoordinateSystemPE_3([MarshalAs(UnmanagedType.LPWStr)] string sCoordSysIdOrFullDef, IntPtr pCoordSys);

	public delegate int SwigDelegateOdDbGeoCompoundCoordinateSystemPE_4([MarshalAs(UnmanagedType.LPWStr)] string sCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string sVerticalCoordSysId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCompoundCoordinateSystemPE_0 swigDelegate0;

	private SwigDelegateOdDbGeoCompoundCoordinateSystemPE_1 swigDelegate1;

	private SwigDelegateOdDbGeoCompoundCoordinateSystemPE_2 swigDelegate2;

	private SwigDelegateOdDbGeoCompoundCoordinateSystemPE_3 swigDelegate3;

	private SwigDelegateOdDbGeoCompoundCoordinateSystemPE_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string),
		typeof(OdDbGeoCompoundCoordinateSystem).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCompoundCoordinateSystemPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCompoundCoordinateSystemPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCompoundCoordinateSystemPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCompoundCoordinateSystemPE cast(OdRxObject pObj)
	{
		OdDbGeoCompoundCoordinateSystemPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCompoundCoordinateSystemPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_isASwigExplicitOdDbGeoCompoundCoordinateSystemPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_queryXSwigExplicitOdDbGeoCompoundCoordinateSystemPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCompoundCoordinateSystemPE createObject()
	{
		OdDbGeoCompoundCoordinateSystemPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCompoundCoordinateSystemPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult create(string sCoordSysIdOrFullDef, ref OdDbGeoCompoundCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : OdDbGeoCompoundCoordinateSystem.getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_create(swigCPtr, sCoordSysIdOrFullDef, ref jarg);
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
				pCoordSys = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCompoundCoordinateSystem>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult verify(string sCoordSysId, string sVerticalCoordSysId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_verify(swigCPtr, sCoordSysId, sVerticalCoordSysId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbGeoCompoundCoordinateSystemPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGeoCompoundCoordinateSystemPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbGeoCompoundCoordinateSystemPE) != GetType();
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
		if (SwigDerivedClassHasMethod("verify", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodverify;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystemPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCompoundCoordinateSystemPE));
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
		OdDbGeoCompoundCoordinateSystem pCoordSys2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCompoundCoordinateSystem>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)create(sCoordSysIdOrFullDef, ref pCoordSys2);
		}
		finally
		{
			IntPtr handle = OdDbGeoCompoundCoordinateSystem.getCPtr(pCoordSys2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pCoordSys);
		}
	}

	private int SwigDirectorMethodverify([MarshalAs(UnmanagedType.LPWStr)] string sCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string sVerticalCoordSysId)
	{
		return (int)verify(sCoordSysId, sVerticalCoordSysId);
	}
}
