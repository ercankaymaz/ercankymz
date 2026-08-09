using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbTransactionReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbTransactionReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbTransactionReactor_1();

	public delegate void SwigDelegateOdDbTransactionReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbTransactionReactor_3(IntPtr pDb);

	public delegate void SwigDelegateOdDbTransactionReactor_4(IntPtr pDb);

	public delegate void SwigDelegateOdDbTransactionReactor_5(IntPtr pDb);

	public delegate void SwigDelegateOdDbTransactionReactor_6(IntPtr pDb);

	public delegate void SwigDelegateOdDbTransactionReactor_7(IntPtr pDb);

	public delegate void SwigDelegateOdDbTransactionReactor_8(IntPtr pDb);

	public delegate void SwigDelegateOdDbTransactionReactor_9(IntPtr pDb);

	public delegate void SwigDelegateOdDbTransactionReactor_10(IntPtr pTransObj, IntPtr pOtherTransObj, IntPtr pDb);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbTransactionReactor_0 swigDelegate0;

	private SwigDelegateOdDbTransactionReactor_1 swigDelegate1;

	private SwigDelegateOdDbTransactionReactor_2 swigDelegate2;

	private SwigDelegateOdDbTransactionReactor_3 swigDelegate3;

	private SwigDelegateOdDbTransactionReactor_4 swigDelegate4;

	private SwigDelegateOdDbTransactionReactor_5 swigDelegate5;

	private SwigDelegateOdDbTransactionReactor_6 swigDelegate6;

	private SwigDelegateOdDbTransactionReactor_7 swigDelegate7;

	private SwigDelegateOdDbTransactionReactor_8 swigDelegate8;

	private SwigDelegateOdDbTransactionReactor_9 swigDelegate9;

	private SwigDelegateOdDbTransactionReactor_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(OdDbObject),
		typeof(OdDbDatabase)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbTransactionReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbTransactionReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbTransactionReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbTransactionReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbTransactionReactor(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbTransactionReactor cast(OdRxObject pObj)
	{
		OdDbTransactionReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTransactionReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_isASwigExplicitOdDbTransactionReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_queryXSwigExplicitOdDbTransactionReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void transactionAboutToStart(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("transactionAboutToStart", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAboutToStartSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAboutToStart(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void transactionStarted(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("transactionStarted", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionStartedSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionStarted(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void transactionAboutToEnd(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("transactionAboutToEnd", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAboutToEndSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAboutToEnd(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void transactionEnded(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("transactionEnded", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionEndedSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionEnded(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void transactionAboutToAbort(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("transactionAboutToAbort", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAboutToAbortSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAboutToAbort(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void transactionAborted(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("transactionAborted", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAbortedSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_transactionAborted(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endCalledOnOutermostTransaction(OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("endCalledOnOutermostTransaction", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_endCalledOnOutermostTransactionSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_endCalledOnOutermostTransaction(swigCPtr, OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void objectIdSwapped(OdDbObject pTransObj, OdDbObject pOtherTransObj, OdDbDatabase pDb)
	{
		if (SwigDerivedClassHasMethod("objectIdSwapped", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_objectIdSwappedSwigExplicitOdDbTransactionReactor(swigCPtr, OdDbObject.getCPtr(pTransObj), OdDbObject.getCPtr(pOtherTransObj), OdDbDatabase.getCPtr(pDb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_objectIdSwapped(swigCPtr, OdDbObject.getCPtr(pTransObj), OdDbObject.getCPtr(pOtherTransObj), OdDbDatabase.getCPtr(pDb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbTransactionReactor createObject()
	{
		OdDbTransactionReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTransactionReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("transactionAboutToStart", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtransactionAboutToStart;
		}
		if (SwigDerivedClassHasMethod("transactionStarted", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodtransactionStarted;
		}
		if (SwigDerivedClassHasMethod("transactionAboutToEnd", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodtransactionAboutToEnd;
		}
		if (SwigDerivedClassHasMethod("transactionEnded", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtransactionEnded;
		}
		if (SwigDerivedClassHasMethod("transactionAboutToAbort", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodtransactionAboutToAbort;
		}
		if (SwigDerivedClassHasMethod("transactionAborted", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodtransactionAborted;
		}
		if (SwigDerivedClassHasMethod("endCalledOnOutermostTransaction", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodendCalledOnOutermostTransaction;
		}
		if (SwigDerivedClassHasMethod("objectIdSwapped", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodobjectIdSwapped;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransactionReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbTransactionReactor));
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

	private void SwigDirectorMethodtransactionAboutToStart(IntPtr pDb)
	{
		try
		{
			transactionAboutToStart(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtransactionStarted(IntPtr pDb)
	{
		try
		{
			transactionStarted(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtransactionAboutToEnd(IntPtr pDb)
	{
		try
		{
			transactionAboutToEnd(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtransactionEnded(IntPtr pDb)
	{
		try
		{
			transactionEnded(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtransactionAboutToAbort(IntPtr pDb)
	{
		try
		{
			transactionAboutToAbort(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtransactionAborted(IntPtr pDb)
	{
		try
		{
			transactionAborted(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodendCalledOnOutermostTransaction(IntPtr pDb)
	{
		try
		{
			endCalledOnOutermostTransaction(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodobjectIdSwapped(IntPtr pTransObj, IntPtr pOtherTransObj, IntPtr pDb)
	{
		try
		{
			objectIdSwapped(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pTransObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOtherTransObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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
