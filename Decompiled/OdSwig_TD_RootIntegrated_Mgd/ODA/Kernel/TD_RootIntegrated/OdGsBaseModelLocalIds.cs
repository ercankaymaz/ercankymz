using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseModelLocalIds : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGsBaseModelLocalIds_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdGsBaseModelLocalIds_1();

	public delegate void SwigDelegateOdGsBaseModelLocalIds_2(IntPtr pSource);

	public delegate void SwigDelegateOdGsBaseModelLocalIds_3(IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModelLocalIds_4(IntPtr pView, uint nId);

	public delegate uint SwigDelegateOdGsBaseModelLocalIds_5(IntPtr pView);

	public delegate uint SwigDelegateOdGsBaseModelLocalIds_6(IntPtr pView);

	public delegate uint SwigDelegateOdGsBaseModelLocalIds_7();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseModelLocalIds_0 swigDelegate0;

	private SwigDelegateOdGsBaseModelLocalIds_1 swigDelegate1;

	private SwigDelegateOdGsBaseModelLocalIds_2 swigDelegate2;

	private SwigDelegateOdGsBaseModelLocalIds_3 swigDelegate3;

	private SwigDelegateOdGsBaseModelLocalIds_4 swigDelegate4;

	private SwigDelegateOdGsBaseModelLocalIds_5 swigDelegate5;

	private SwigDelegateOdGsBaseModelLocalIds_6 swigDelegate6;

	private SwigDelegateOdGsBaseModelLocalIds_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGsViewImpl) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGsViewImpl),
		typeof(uint)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGsViewImpl) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGsViewImpl) };

	private static Type[] swigMethodTypes7 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseModelLocalIds(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseModelLocalIds obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseModelLocalIds(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void onViewDelete(OdGsViewImpl pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_onViewDelete(swigCPtr, OdGsViewImpl.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void resetViewId(OdGsViewImpl pView, uint nId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_resetViewId(swigCPtr, OdGsViewImpl.getCPtr(pView), nId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getViewId(OdGsViewImpl pView)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_getViewId(swigCPtr, OdGsViewImpl.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint registerView(OdGsViewImpl pView)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_registerView(swigCPtr, OdGsViewImpl.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getMaxId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_getMaxId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsBaseModelLocalIds createObject()
	{
		OdGsBaseModelLocalIds rXObject = Helpers.GetRXObject<OdGsBaseModelLocalIds>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsBaseModelLocalIds()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseModelLocalIds(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsBaseModelLocalIds) != GetType();
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
		if (SwigDerivedClassHasMethod("onViewDelete", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodonViewDelete;
		}
		if (SwigDerivedClassHasMethod("resetViewId", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodresetViewId;
		}
		if (SwigDerivedClassHasMethod("getViewId", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetViewId;
		}
		if (SwigDerivedClassHasMethod("registerView", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodregisterView;
		}
		if (SwigDerivedClassHasMethod("getMaxId", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetMaxId;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModelLocalIds_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseModelLocalIds));
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

	private void SwigDirectorMethodonViewDelete(IntPtr pView)
	{
		try
		{
			onViewDelete(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodresetViewId(IntPtr pView, uint nId)
	{
		try
		{
			resetViewId(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false), nId);
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

	private uint SwigDirectorMethodgetViewId(IntPtr pView)
	{
		return getViewId(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodregisterView(IntPtr pView)
	{
		return registerView(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodgetMaxId()
	{
		return getMaxId();
	}
}
