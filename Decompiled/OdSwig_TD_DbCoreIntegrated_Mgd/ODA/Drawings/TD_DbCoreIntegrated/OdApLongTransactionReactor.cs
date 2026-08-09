using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdApLongTransactionReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdApLongTransactionReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdApLongTransactionReactor_1();

	public delegate void SwigDelegateOdApLongTransactionReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdApLongTransactionReactor_3(IntPtr lt, IntPtr originList);

	public delegate void SwigDelegateOdApLongTransactionReactor_4(IntPtr arg0);

	public delegate void SwigDelegateOdApLongTransactionReactor_5(IntPtr arg0);

	public delegate void SwigDelegateOdApLongTransactionReactor_6(IntPtr arg0);

	public delegate void SwigDelegateOdApLongTransactionReactor_7(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdApLongTransactionReactor_0 swigDelegate0;

	private SwigDelegateOdApLongTransactionReactor_1 swigDelegate1;

	private SwigDelegateOdApLongTransactionReactor_2 swigDelegate2;

	private SwigDelegateOdApLongTransactionReactor_3 swigDelegate3;

	private SwigDelegateOdApLongTransactionReactor_4 swigDelegate4;

	private SwigDelegateOdApLongTransactionReactor_5 swigDelegate5;

	private SwigDelegateOdApLongTransactionReactor_6 swigDelegate6;

	private SwigDelegateOdApLongTransactionReactor_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbLongTransaction).MakeByRefType(),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbLongTransaction).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbLongTransaction).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbLongTransaction).MakeByRefType() };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbLongTransaction).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdApLongTransactionReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdApLongTransactionReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdApLongTransactionReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdApLongTransactionReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdApLongTransactionReactor(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdApLongTransactionReactor cast(OdRxObject pObj)
	{
		OdApLongTransactionReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdApLongTransactionReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_isASwigExplicitOdApLongTransactionReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_queryXSwigExplicitOdApLongTransactionReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void beginCheckOut(ref OdDbLongTransaction lt, OdDbObjectIdArray originList)
	{
		IntPtr jarg = ((lt == null) ? IntPtr.Zero : OdDbLongTransaction.getCPtr(lt).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("beginCheckOut", swigMethodTypes3))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_beginCheckOutSwigExplicitOdApLongTransactionReactor(swigCPtr, ref jarg, OdDbObjectIdArray.getCPtr(originList));
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_beginCheckOut(swigCPtr, ref jarg, OdDbObjectIdArray.getCPtr(originList));
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				lt = null;
			}
			if (jarg != intPtr)
			{
				lt = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void endCheckOut(ref OdDbLongTransaction arg0)
	{
		IntPtr jarg = ((arg0 == null) ? IntPtr.Zero : OdDbLongTransaction.getCPtr(arg0).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("endCheckOut", swigMethodTypes4))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_endCheckOutSwigExplicitOdApLongTransactionReactor(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_endCheckOut(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				arg0 = null;
			}
			if (jarg != intPtr)
			{
				arg0 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void beginCheckIn(ref OdDbLongTransaction arg0)
	{
		IntPtr jarg = ((arg0 == null) ? IntPtr.Zero : OdDbLongTransaction.getCPtr(arg0).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("beginCheckIn", swigMethodTypes5))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_beginCheckInSwigExplicitOdApLongTransactionReactor(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_beginCheckIn(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				arg0 = null;
			}
			if (jarg != intPtr)
			{
				arg0 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void endCheckIn(ref OdDbLongTransaction arg0)
	{
		IntPtr jarg = ((arg0 == null) ? IntPtr.Zero : OdDbLongTransaction.getCPtr(arg0).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("endCheckIn", swigMethodTypes6))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_endCheckInSwigExplicitOdApLongTransactionReactor(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_endCheckIn(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				arg0 = null;
			}
			if (jarg != intPtr)
			{
				arg0 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void abortLongTransaction(ref OdDbLongTransaction arg0)
	{
		IntPtr jarg = ((arg0 == null) ? IntPtr.Zero : OdDbLongTransaction.getCPtr(arg0).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("abortLongTransaction", swigMethodTypes7))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_abortLongTransactionSwigExplicitOdApLongTransactionReactor(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_abortLongTransaction(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				arg0 = null;
			}
			if (jarg != intPtr)
			{
				arg0 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdApLongTransactionReactor createObject()
	{
		OdApLongTransactionReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdApLongTransactionReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("beginCheckOut", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodbeginCheckOut;
		}
		if (SwigDerivedClassHasMethod("endCheckOut", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodendCheckOut;
		}
		if (SwigDerivedClassHasMethod("beginCheckIn", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodbeginCheckIn;
		}
		if (SwigDerivedClassHasMethod("endCheckIn", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodendCheckIn;
		}
		if (SwigDerivedClassHasMethod("abortLongTransaction", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodabortLongTransaction;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdApLongTransactionReactor));
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

	private void SwigDirectorMethodbeginCheckOut(IntPtr lt, IntPtr originList)
	{
		OdSwigDirectorHelper.director_UnpackData(lt, out var pOriginalObject, out var pFunction);
		OdDbLongTransaction lt2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			beginCheckOut(ref lt2, new OdDbObjectIdArray(originList, cMemoryOwn: false));
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
		finally
		{
			IntPtr handle = OdDbLongTransaction.getCPtr(lt2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(lt);
		}
	}

	private void SwigDirectorMethodendCheckOut(IntPtr arg0)
	{
		OdSwigDirectorHelper.director_UnpackData(arg0, out var pOriginalObject, out var pFunction);
		OdDbLongTransaction arg1 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			endCheckOut(ref arg1);
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
		finally
		{
			IntPtr handle = OdDbLongTransaction.getCPtr(arg1).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(arg0);
		}
	}

	private void SwigDirectorMethodbeginCheckIn(IntPtr arg0)
	{
		OdSwigDirectorHelper.director_UnpackData(arg0, out var pOriginalObject, out var pFunction);
		OdDbLongTransaction arg1 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			beginCheckIn(ref arg1);
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
		finally
		{
			IntPtr handle = OdDbLongTransaction.getCPtr(arg1).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(arg0);
		}
	}

	private void SwigDirectorMethodendCheckIn(IntPtr arg0)
	{
		OdSwigDirectorHelper.director_UnpackData(arg0, out var pOriginalObject, out var pFunction);
		OdDbLongTransaction arg1 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			endCheckIn(ref arg1);
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
		finally
		{
			IntPtr handle = OdDbLongTransaction.getCPtr(arg1).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(arg0);
		}
	}

	private void SwigDirectorMethodabortLongTransaction(IntPtr arg0)
	{
		OdSwigDirectorHelper.director_UnpackData(arg0, out var pOriginalObject, out var pFunction);
		OdDbLongTransaction arg1 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransaction>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			abortLongTransaction(ref arg1);
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
		finally
		{
			IntPtr handle = OdDbLongTransaction.getCPtr(arg1).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(arg0);
		}
	}
}
