using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBreakDataWatcherPE : OdDbEvalWatcherPE
{
	public delegate IntPtr SwigDelegateOdDbBreakDataWatcherPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBreakDataWatcherPE_1();

	public delegate void SwigDelegateOdDbBreakDataWatcherPE_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbBreakDataWatcherPE_3(IntPtr pObj, IntPtr pEnt);

	public delegate void SwigDelegateOdDbBreakDataWatcherPE_4(IntPtr pObj, IntPtr pAssocObj);

	public delegate void SwigDelegateOdDbBreakDataWatcherPE_5(IntPtr pObj, IntPtr pEnt, bool bErasing);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBreakDataWatcherPE_0 swigDelegate0;

	private SwigDelegateOdDbBreakDataWatcherPE_1 swigDelegate1;

	private SwigDelegateOdDbBreakDataWatcherPE_2 swigDelegate2;

	private SwigDelegateOdDbBreakDataWatcherPE_3 swigDelegate3;

	private SwigDelegateOdDbBreakDataWatcherPE_4 swigDelegate4;

	private SwigDelegateOdDbBreakDataWatcherPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(OdDbObject),
		typeof(bool)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBreakDataWatcherPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBreakDataWatcherPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBreakDataWatcherPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override void modified(OdDbObject pObj, OdDbObject pEnt)
	{
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_modifiedSwigExplicitOdDbBreakDataWatcherPE(swigCPtr, OdDbObject.getCPtr(pObj), OdDbObject.getCPtr(pEnt));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_modified(swigCPtr, OdDbObject.getCPtr(pObj), OdDbObject.getCPtr(pEnt));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void erased(OdDbObject pObj, OdDbObject pEnt, bool bErasing)
	{
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_erasedSwigExplicitOdDbBreakDataWatcherPE(swigCPtr, OdDbObject.getCPtr(pObj), OdDbObject.getCPtr(pEnt), bErasing);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_erased(swigCPtr, OdDbObject.getCPtr(pObj), OdDbObject.getCPtr(pEnt), bErasing);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbBreakDataWatcherPE createObject()
	{
		OdDbBreakDataWatcherPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBreakDataWatcherPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodmodified;
		}
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodopenedForModify;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoderased;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBreakDataWatcherPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBreakDataWatcherPE));
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

	private void SwigDirectorMethodmodified(IntPtr pObj, IntPtr pEnt)
	{
		try
		{
			modified(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pEnt, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodopenedForModify(IntPtr pObj, IntPtr pAssocObj)
	{
		try
		{
			openedForModify(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pAssocObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoderased(IntPtr pObj, IntPtr pEnt, bool bErasing)
	{
		try
		{
			erased(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pEnt, bOwn: false, bTryAddToTransaction: false), bErasing);
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
}
