using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGsReactor_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdGsReactor_1();

	public delegate void SwigDelegateOdGsReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdGsReactor_3(IntPtr pView);

	public delegate void SwigDelegateOdGsReactor_4(IntPtr pView);

	public delegate void SwigDelegateOdGsReactor_5(IntPtr pView, int flags);

	public delegate void SwigDelegateOdGsReactor_6(IntPtr pView, int flags);

	public delegate void SwigDelegateOdGsReactor_7(IntPtr pModule);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsReactor_0 swigDelegate0;

	private SwigDelegateOdGsReactor_1 swigDelegate1;

	private SwigDelegateOdGsReactor_2 swigDelegate2;

	private SwigDelegateOdGsReactor_3 swigDelegate3;

	private SwigDelegateOdGsReactor_4 swigDelegate4;

	private SwigDelegateOdGsReactor_5 swigDelegate5;

	private SwigDelegateOdGsReactor_6 swigDelegate6;

	private SwigDelegateOdGsReactor_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGsView),
		typeof(int)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGsView),
		typeof(int)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGsModule) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsReactor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void viewWasCreated(OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("viewWasCreated", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewWasCreatedSwigExplicitOdGsReactor(swigCPtr, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewWasCreated(swigCPtr, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void viewToBeDestroyed(OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("viewToBeDestroyed", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewToBeDestroyedSwigExplicitOdGsReactor(swigCPtr, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewToBeDestroyed(swigCPtr, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void viewToBeUpdated(OdGsView pView, int flags)
	{
		if (SwigDerivedClassHasMethod("viewToBeUpdated", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewToBeUpdatedSwigExplicitOdGsReactor(swigCPtr, OdGsView.getCPtr(pView), flags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewToBeUpdated(swigCPtr, OdGsView.getCPtr(pView), flags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void viewWasUpdated(OdGsView pView, int flags)
	{
		if (SwigDerivedClassHasMethod("viewWasUpdated", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewWasUpdatedSwigExplicitOdGsReactor(swigCPtr, OdGsView.getCPtr(pView), flags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_viewWasUpdated(swigCPtr, OdGsView.getCPtr(pView), flags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void gsToBeUnloaded(OdGsModule pModule)
	{
		if (SwigDerivedClassHasMethod("gsToBeUnloaded", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_gsToBeUnloadedSwigExplicitOdGsReactor(swigCPtr, OdGsModule.getCPtr(pModule));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_gsToBeUnloaded(swigCPtr, OdGsModule.getCPtr(pModule));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsReactor createObject()
	{
		OdGsReactor rXObject = Helpers.GetRXObject<OdGsReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsReactor) != GetType();
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
		if (SwigDerivedClassHasMethod("viewWasCreated", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodviewWasCreated;
		}
		if (SwigDerivedClassHasMethod("viewToBeDestroyed", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodviewToBeDestroyed;
		}
		if (SwigDerivedClassHasMethod("viewToBeUpdated", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodviewToBeUpdated;
		}
		if (SwigDerivedClassHasMethod("viewWasUpdated", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodviewWasUpdated;
		}
		if (SwigDerivedClassHasMethod("gsToBeUnloaded", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgsToBeUnloaded;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsReactor));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private void SwigDirectorMethodviewWasCreated(IntPtr pView)
	{
		try
		{
			viewWasCreated(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodviewToBeDestroyed(IntPtr pView)
	{
		try
		{
			viewToBeDestroyed(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodviewToBeUpdated(IntPtr pView, int flags)
	{
		try
		{
			viewToBeUpdated(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false), flags);
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

	private void SwigDirectorMethodviewWasUpdated(IntPtr pView, int flags)
	{
		try
		{
			viewWasUpdated(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false), flags);
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

	private void SwigDirectorMethodgsToBeUnloaded(IntPtr pModule)
	{
		try
		{
			gsToBeUnloaded(Helpers.GetRXObject<OdGsModule>(pModule, bOwn: false, bTryAddToTransaction: false));
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
}
