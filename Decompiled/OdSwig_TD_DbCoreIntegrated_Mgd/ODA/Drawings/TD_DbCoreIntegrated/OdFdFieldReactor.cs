using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFdFieldReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFdFieldReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFdFieldReactor_1();

	public delegate void SwigDelegateOdFdFieldReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdFdFieldReactor_3(int nContext, IntPtr pDb);

	public delegate void SwigDelegateOdFdFieldReactor_4(int nContext, IntPtr pDb);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFdFieldReactor_0 swigDelegate0;

	private SwigDelegateOdFdFieldReactor_1 swigDelegate1;

	private SwigDelegateOdFdFieldReactor_2 swigDelegate2;

	private SwigDelegateOdFdFieldReactor_3 swigDelegate3;

	private SwigDelegateOdFdFieldReactor_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(int),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(int),
		typeof(OdDbDatabase)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFdFieldReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFdFieldReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFdFieldReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFdFieldReactor cast(OdRxObject pObj)
	{
		OdFdFieldReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_isASwigExplicitOdFdFieldReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_queryXSwigExplicitOdFdFieldReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void beginEvaluateFields(int nContext, OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("beginEvaluateFields", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_beginEvaluateFieldsSwigExplicitOdFdFieldReactor(swigCPtr, nContext, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_beginEvaluateFields(swigCPtr, nContext, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endEvaluateFields(int nContext, OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("endEvaluateFields", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_endEvaluateFieldsSwigExplicitOdFdFieldReactor(swigCPtr, nContext, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_endEvaluateFields(swigCPtr, nContext, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdFdFieldReactor createObject()
	{
		OdFdFieldReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFdFieldReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFdFieldReactor(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFdFieldReactor) != GetType();
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
		if (SwigDerivedClassHasMethod("beginEvaluateFields", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodbeginEvaluateFields;
		}
		if (SwigDerivedClassHasMethod("endEvaluateFields", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodendEvaluateFields;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFdFieldReactor));
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

	private void SwigDirectorMethodbeginEvaluateFields(int nContext, IntPtr pDb)
	{
		try
		{
			beginEvaluateFields(nContext, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodendEvaluateFields(int nContext, IntPtr pDb)
	{
		try
		{
			endEvaluateFields(nContext, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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
