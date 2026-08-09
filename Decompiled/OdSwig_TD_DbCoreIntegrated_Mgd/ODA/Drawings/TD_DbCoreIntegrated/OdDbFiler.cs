using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbFiler : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbFiler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbFiler_1();

	public delegate void SwigDelegateOdDbFiler_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbFiler_3();

	public delegate void SwigDelegateOdDbFiler_4();

	public delegate int SwigDelegateOdDbFiler_5();

	public delegate IntPtr SwigDelegateOdDbFiler_6();

	public delegate int SwigDelegateOdDbFiler_7(MaintReleaseVer pMaintReleaseVer);

	public delegate int SwigDelegateOdDbFiler_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbFiler_0 swigDelegate0;

	private SwigDelegateOdDbFiler_1 swigDelegate1;

	private SwigDelegateOdDbFiler_2 swigDelegate2;

	private SwigDelegateOdDbFiler_3 swigDelegate3;

	private SwigDelegateOdDbFiler_4 swigDelegate4;

	private SwigDelegateOdDbFiler_5 swigDelegate5;

	private SwigDelegateOdDbFiler_6 swigDelegate6;

	private SwigDelegateOdDbFiler_7 swigDelegate7;

	private SwigDelegateOdDbFiler_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(MaintReleaseVer).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbFiler obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbFiler()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFiler(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbFiler) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbFiler cast(OdRxObject pObj)
	{
		OdDbFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_isASwigExplicitOdDbFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_queryXSwigExplicitOdDbFiler(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbFiler createObject()
	{
		OdDbFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult filerStatus()
	{
		int result = (SwigDerivedClassHasMethod("filerStatus", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_filerStatusSwigExplicitOdDbFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_filerStatus(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void resetFilerStatus()
	{
		if (SwigDerivedClassHasMethod("resetFilerStatus", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_resetFilerStatusSwigExplicitOdDbFiler(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_resetFilerStatus(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbFiler_FilerType filerType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_filerType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbFiler_FilerType)result;
	}

	public virtual OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("database", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_databaseSwigExplicitOdDbFiler(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual DwgVersion dwgVersion(out MaintReleaseVer pMaintReleaseVer)
	{
		int result = (SwigDerivedClassHasMethod("dwgVersion", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_dwgVersionSwigExplicitOdDbFiler__SWIG_0(swigCPtr, out pMaintReleaseVer) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_dwgVersion__SWIG_0(swigCPtr, out pMaintReleaseVer));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public virtual DwgVersion dwgVersion()
	{
		int result = (SwigDerivedClassHasMethod("dwgVersion", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_dwgVersionSwigExplicitOdDbFiler__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_dwgVersion__SWIG_1(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public OdDbAuditInfo getAuditInfo()
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_getAuditInfo(swigCPtr);
		OdDbAuditInfo result = ((intPtr == IntPtr.Zero) ? null : new OdDbAuditInfo(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("filerStatus", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfilerStatus;
		}
		if (SwigDerivedClassHasMethod("resetFilerStatus", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodresetFilerStatus;
		}
		if (SwigDerivedClassHasMethod("filerType", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodfilerType;
		}
		if (SwigDerivedClassHasMethod("database", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddatabase;
		}
		if (SwigDerivedClassHasMethod("dwgVersion", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddwgVersion__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("dwgVersion", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddwgVersion__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFiler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbFiler));
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

	private int SwigDirectorMethodfilerStatus()
	{
		return (int)filerStatus();
	}

	private void SwigDirectorMethodresetFilerStatus()
	{
		try
		{
			resetFilerStatus();
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

	private int SwigDirectorMethodfilerType()
	{
		return (int)filerType();
	}

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdDbDatabase.getCPtr(database()).Handle;
	}

	private int SwigDirectorMethoddwgVersion__SWIG_0(MaintReleaseVer pMaintReleaseVer)
	{
		return (int)dwgVersion(out pMaintReleaseVer);
	}

	private int SwigDirectorMethoddwgVersion__SWIG_1()
	{
		return (int)dwgVersion();
	}
}
