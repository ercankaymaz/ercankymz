using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdApLongTransactionManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdApLongTransactionManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdApLongTransactionManager_1();

	public delegate void SwigDelegateOdApLongTransactionManager_2(IntPtr pSource);

	public delegate int SwigDelegateOdApLongTransactionManager_3(IntPtr transId, IntPtr objList, IntPtr toBlock, IntPtr errorMap, IntPtr lockBlkRef);

	public delegate int SwigDelegateOdApLongTransactionManager_4(IntPtr transId, IntPtr objList, IntPtr toBlock, IntPtr errorMap);

	public delegate int SwigDelegateOdApLongTransactionManager_5(IntPtr transId, IntPtr errorMap, bool keepObjs);

	public delegate int SwigDelegateOdApLongTransactionManager_6(IntPtr transId, IntPtr errorMap);

	public delegate int SwigDelegateOdApLongTransactionManager_7(IntPtr transId, bool keepObjs);

	public delegate int SwigDelegateOdApLongTransactionManager_8(IntPtr transId);

	public delegate IntPtr SwigDelegateOdApLongTransactionManager_9(IntPtr pDb);

	public delegate void SwigDelegateOdApLongTransactionManager_10(IntPtr arg0);

	public delegate void SwigDelegateOdApLongTransactionManager_11(IntPtr arg0);

	public delegate int SwigDelegateOdApLongTransactionManager_12(IntPtr arg0);

	public delegate bool SwigDelegateOdApLongTransactionManager_13(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdApLongTransactionManager_0 swigDelegate0;

	private SwigDelegateOdApLongTransactionManager_1 swigDelegate1;

	private SwigDelegateOdApLongTransactionManager_2 swigDelegate2;

	private SwigDelegateOdApLongTransactionManager_3 swigDelegate3;

	private SwigDelegateOdApLongTransactionManager_4 swigDelegate4;

	private SwigDelegateOdApLongTransactionManager_5 swigDelegate5;

	private SwigDelegateOdApLongTransactionManager_6 swigDelegate6;

	private SwigDelegateOdApLongTransactionManager_7 swigDelegate7;

	private SwigDelegateOdApLongTransactionManager_8 swigDelegate8;

	private SwigDelegateOdApLongTransactionManager_9 swigDelegate9;

	private SwigDelegateOdApLongTransactionManager_10 swigDelegate10;

	private SwigDelegateOdApLongTransactionManager_11 swigDelegate11;

	private SwigDelegateOdApLongTransactionManager_12 swigDelegate12;

	private SwigDelegateOdApLongTransactionManager_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[5]
	{
		typeof(OdDbObjectId),
		typeof(OdDbObjectIdArray),
		typeof(OdDbObjectId),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes4 = new Type[4]
	{
		typeof(OdDbObjectId),
		typeof(OdDbObjectIdArray),
		typeof(OdDbObjectId),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdDbObjectId),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(bool)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbIdMapping).MakeByRefType()
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdApLongTransactionReactor) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdApLongTransactionReactor) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdRxClass) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdApLongTransactionManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdApLongTransactionManager obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdApLongTransactionManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdApLongTransactionManager cast(OdRxObject pObj)
	{
		OdApLongTransactionManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdApLongTransactionManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_isASwigExplicitOdApLongTransactionManager(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_queryXSwigExplicitOdApLongTransactionManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdApLongTransactionManager createObject()
	{
		OdApLongTransactionManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdApLongTransactionManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult checkOut(OdDbObjectId transId, OdDbObjectIdArray objList, OdDbObjectId toBlock, ref OdDbIdMapping errorMap, OdDbObjectId lockBlkRef)
	{
		IntPtr jarg = ((errorMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(errorMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_checkOut__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(transId), OdDbObjectIdArray.getCPtr(objList), OdDbObjectId.getCPtr(toBlock), ref jarg, OdDbObjectId.getCPtr(lockBlkRef));
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
				errorMap = null;
			}
			if (jarg != intPtr)
			{
				errorMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult checkOut(OdDbObjectId transId, OdDbObjectIdArray objList, OdDbObjectId toBlock, ref OdDbIdMapping errorMap)
	{
		IntPtr jarg = ((errorMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(errorMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_checkOut__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(transId), OdDbObjectIdArray.getCPtr(objList), OdDbObjectId.getCPtr(toBlock), ref jarg);
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
				errorMap = null;
			}
			if (jarg != intPtr)
			{
				errorMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult checkIn(OdDbObjectId transId, ref OdDbIdMapping errorMap, bool keepObjs)
	{
		IntPtr jarg = ((errorMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(errorMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_checkIn__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(transId), ref jarg, keepObjs);
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
				errorMap = null;
			}
			if (jarg != intPtr)
			{
				errorMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult checkIn(OdDbObjectId transId, ref OdDbIdMapping errorMap)
	{
		IntPtr jarg = ((errorMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(errorMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_checkIn__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(transId), ref jarg);
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
				errorMap = null;
			}
			if (jarg != intPtr)
			{
				errorMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult abortLongTransaction(OdDbObjectId transId, bool keepObjs)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_abortLongTransaction__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(transId), keepObjs);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult abortLongTransaction(OdDbObjectId transId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_abortLongTransaction__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(transId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbObjectId currentLongTransactionFor(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_currentLongTransactionFor(swigCPtr, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addReactor(OdApLongTransactionReactor arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_addReactor(swigCPtr, OdApLongTransactionReactor.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeReactor(OdApLongTransactionReactor arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_removeReactor(swigCPtr, OdApLongTransactionReactor.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult addClassFilter(OdRxClass arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_addClassFilter(swigCPtr, OdRxClass.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool isFiltered(OdRxClass arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_isFiltered(swigCPtr, OdRxClass.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdApLongTransactionManager()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdApLongTransactionManager(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdApLongTransactionManager) != GetType();
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
		if (SwigDerivedClassHasMethod("checkOut", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcheckOut__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("checkOut", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcheckOut__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("checkIn", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcheckIn__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("checkIn", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcheckIn__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("abortLongTransaction", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodabortLongTransaction__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("abortLongTransaction", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodabortLongTransaction__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("currentLongTransactionFor", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcurrentLongTransactionFor;
		}
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodaddReactor;
		}
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodremoveReactor;
		}
		if (SwigDerivedClassHasMethod("addClassFilter", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodaddClassFilter;
		}
		if (SwigDerivedClassHasMethod("isFiltered", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodisFiltered;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdApLongTransactionManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdApLongTransactionManager));
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

	private int SwigDirectorMethodcheckOut__SWIG_0(IntPtr transId, IntPtr objList, IntPtr toBlock, IntPtr errorMap, IntPtr lockBlkRef)
	{
		OdSwigDirectorHelper.director_UnpackData(errorMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping errorMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return (int)checkOut(new OdDbObjectId(transId, cMemoryOwn: false), new OdDbObjectIdArray(objList, cMemoryOwn: false), new OdDbObjectId(toBlock, cMemoryOwn: true), ref errorMap2, new OdDbObjectId(lockBlkRef, cMemoryOwn: true));
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(errorMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(errorMap);
		}
	}

	private int SwigDirectorMethodcheckOut__SWIG_1(IntPtr transId, IntPtr objList, IntPtr toBlock, IntPtr errorMap)
	{
		OdSwigDirectorHelper.director_UnpackData(errorMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping errorMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return (int)checkOut(new OdDbObjectId(transId, cMemoryOwn: false), new OdDbObjectIdArray(objList, cMemoryOwn: false), new OdDbObjectId(toBlock, cMemoryOwn: true), ref errorMap2);
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(errorMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(errorMap);
		}
	}

	private int SwigDirectorMethodcheckIn__SWIG_0(IntPtr transId, IntPtr errorMap, bool keepObjs)
	{
		OdSwigDirectorHelper.director_UnpackData(errorMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping errorMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return (int)checkIn(new OdDbObjectId(transId, cMemoryOwn: true), ref errorMap2, keepObjs);
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(errorMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(errorMap);
		}
	}

	private int SwigDirectorMethodcheckIn__SWIG_1(IntPtr transId, IntPtr errorMap)
	{
		OdSwigDirectorHelper.director_UnpackData(errorMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping errorMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return (int)checkIn(new OdDbObjectId(transId, cMemoryOwn: true), ref errorMap2);
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(errorMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(errorMap);
		}
	}

	private int SwigDirectorMethodabortLongTransaction__SWIG_0(IntPtr transId, bool keepObjs)
	{
		return (int)abortLongTransaction(new OdDbObjectId(transId, cMemoryOwn: true), keepObjs);
	}

	private int SwigDirectorMethodabortLongTransaction__SWIG_1(IntPtr transId)
	{
		return (int)abortLongTransaction(new OdDbObjectId(transId, cMemoryOwn: true));
	}

	private IntPtr SwigDirectorMethodcurrentLongTransactionFor(IntPtr pDb)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(currentLongTransactionFor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodaddReactor(IntPtr arg0)
	{
		try
		{
			addReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdApLongTransactionReactor>(arg0, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveReactor(IntPtr arg0)
	{
		try
		{
			removeReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdApLongTransactionReactor>(arg0, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodaddClassFilter(IntPtr arg0)
	{
		return (int)addClassFilter(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisFiltered(IntPtr arg0)
	{
		return isFiltered(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(arg0, bOwn: false, bTryAddToTransaction: false));
	}
}
