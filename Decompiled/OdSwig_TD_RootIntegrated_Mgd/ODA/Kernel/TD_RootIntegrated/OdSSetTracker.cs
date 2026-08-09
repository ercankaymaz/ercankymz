using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSSetTracker : OdEdInputTracker
{
	public delegate IntPtr SwigDelegateOdSSetTracker_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdSSetTracker_1();

	public delegate void SwigDelegateOdSSetTracker_2(IntPtr pSource);

	public delegate int SwigDelegateOdSSetTracker_3(IntPtr pView);

	public delegate void SwigDelegateOdSSetTracker_4(IntPtr pView);

	public delegate bool SwigDelegateOdSSetTracker_5(IntPtr id, IntPtr pMethod);

	public delegate bool SwigDelegateOdSSetTracker_6(IntPtr id, IntPtr pMethod);

	public delegate bool SwigDelegateOdSSetTracker_7();

	public delegate bool SwigDelegateOdSSetTracker_8(IntPtr subEntPath, IntPtr pMethod);

	public delegate bool SwigDelegateOdSSetTracker_9(IntPtr subEntPath, IntPtr pMethod);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdSSetTracker_0 swigDelegate0;

	private SwigDelegateOdSSetTracker_1 swigDelegate1;

	private SwigDelegateOdSSetTracker_2 swigDelegate2;

	private SwigDelegateOdSSetTracker_3 swigDelegate3;

	private SwigDelegateOdSSetTracker_4 swigDelegate4;

	private SwigDelegateOdSSetTracker_5 swigDelegate5;

	private SwigDelegateOdSSetTracker_6 swigDelegate6;

	private SwigDelegateOdSSetTracker_7 swigDelegate7;

	private SwigDelegateOdSSetTracker_8 swigDelegate8;

	private SwigDelegateOdSSetTracker_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbBaseFullSubentPath),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdDbBaseFullSubentPath),
		typeof(OdDbSelectionMethod)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSSetTracker(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSSetTracker obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSSetTracker(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdSSetTracker cast(OdRxObject pObj)
	{
		OdSSetTracker rXObject = Helpers.GetRXObject<OdSSetTracker>(TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_isASwigExplicitOdSSetTracker(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_queryXSwigExplicitOdSSetTracker(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool append(OdDbStub id, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("append", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_appendSwigExplicitOdSSetTracker__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)) : TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_append__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool remove(OdDbStub id, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("remove", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_removeSwigExplicitOdSSetTracker__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)) : TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_remove__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool trackSubentities()
	{
		bool result = (SwigDerivedClassHasMethod("trackSubentities", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_trackSubentitiesSwigExplicitOdSSetTracker(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_trackSubentities(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool append(OdDbBaseFullSubentPath subEntPath, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("append", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_appendSwigExplicitOdSSetTracker__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)) : TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_append__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool remove(OdDbBaseFullSubentPath subEntPath, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("remove", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_removeSwigExplicitOdSSetTracker__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)) : TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_remove__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdSSetTracker createObject()
	{
		OdSSetTracker rXObject = Helpers.GetRXObject<OdSSetTracker>(TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdSSetTracker()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSSetTracker(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSSetTracker) != GetType();
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
		if (SwigDerivedClassHasMethod("addDrawables", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddDrawables;
		}
		if (SwigDerivedClassHasMethod("removeDrawables", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodremoveDrawables;
		}
		if (SwigDerivedClassHasMethod("append", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodappend__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("remove", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodremove__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("trackSubentities", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodtrackSubentities;
		}
		if (SwigDerivedClassHasMethod("append", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodappend__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("remove", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodremove__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSSetTracker_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSSetTracker));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodaddDrawables(IntPtr pView)
	{
		return addDrawables(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodremoveDrawables(IntPtr pView)
	{
		try
		{
			removeDrawables(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodappend__SWIG_0(IntPtr id, IntPtr pMethod)
	{
		return append((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false), Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodremove__SWIG_0(IntPtr id, IntPtr pMethod)
	{
		return remove((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false), Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodtrackSubentities()
	{
		return trackSubentities();
	}

	private bool SwigDirectorMethodappend__SWIG_1(IntPtr subEntPath, IntPtr pMethod)
	{
		return append(new OdDbBaseFullSubentPath(subEntPath, cMemoryOwn: false), Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodremove__SWIG_1(IntPtr subEntPath, IntPtr pMethod)
	{
		return remove(new OdDbBaseFullSubentPath(subEntPath, cMemoryOwn: false), Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}
}
