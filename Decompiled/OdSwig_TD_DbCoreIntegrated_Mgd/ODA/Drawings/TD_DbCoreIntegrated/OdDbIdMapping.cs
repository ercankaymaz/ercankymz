using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbIdMapping : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbIdMapping_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbIdMapping_1();

	public delegate void SwigDelegateOdDbIdMapping_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbIdMapping_3(IntPtr idPair);

	public delegate bool SwigDelegateOdDbIdMapping_4(IntPtr idPair);

	public delegate bool SwigDelegateOdDbIdMapping_5(IntPtr key);

	public delegate IntPtr SwigDelegateOdDbIdMapping_6();

	public delegate IntPtr SwigDelegateOdDbIdMapping_7();

	public delegate void SwigDelegateOdDbIdMapping_8(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbIdMapping_9();

	public delegate IntPtr SwigDelegateOdDbIdMapping_10();

	public delegate int SwigDelegateOdDbIdMapping_11();

	public delegate int SwigDelegateOdDbIdMapping_12();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbIdMapping_0 swigDelegate0;

	private SwigDelegateOdDbIdMapping_1 swigDelegate1;

	private SwigDelegateOdDbIdMapping_2 swigDelegate2;

	private SwigDelegateOdDbIdMapping_3 swigDelegate3;

	private SwigDelegateOdDbIdMapping_4 swigDelegate4;

	private SwigDelegateOdDbIdMapping_5 swigDelegate5;

	private SwigDelegateOdDbIdMapping_6 swigDelegate6;

	private SwigDelegateOdDbIdMapping_7 swigDelegate7;

	private SwigDelegateOdDbIdMapping_8 swigDelegate8;

	private SwigDelegateOdDbIdMapping_9 swigDelegate9;

	private SwigDelegateOdDbIdMapping_10 swigDelegate10;

	private SwigDelegateOdDbIdMapping_11 swigDelegate11;

	private SwigDelegateOdDbIdMapping_12 swigDelegate12;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbIdPair) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbIdPair) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbIdMapping(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbIdMapping obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbIdMapping(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbIdMapping cast(OdRxObject pObj)
	{
		OdDbIdMapping rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_isASwigExplicitOdDbIdMapping(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_queryXSwigExplicitOdDbIdMapping(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbIdMapping createObject()
	{
		OdDbIdMapping rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbIdMapping()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdMapping(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbIdMapping) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdDbIdMapping createObject(OdDb_DeepCloneType arg0)
	{
		OdDbIdMapping rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_createObject__SWIG_1((int)arg0), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void assign(OdDbIdPair idPair)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_assign(swigCPtr, OdDbIdPair.getCPtr(idPair));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool compute(OdDbIdPair idPair)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_compute(swigCPtr, OdDbIdPair.getCPtr(idPair));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool del(OdDbObjectId key)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_del(swigCPtr, OdDbObjectId.getCPtr(key));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbIdMappingIter newIterator()
	{
		OdDbIdMappingIter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMappingIter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_newIterator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase destDb()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_destDb(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDestDb(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_setDestDb(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbDatabase origDb()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_origDb(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId insertingXrefBlockId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_insertingXrefBlockId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDb_DeepCloneType deepCloneContext()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_deepCloneContext(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_DeepCloneType)result;
	}

	public virtual OdDb_DuplicateRecordCloning duplicateRecordCloning()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_duplicateRecordCloning(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_DuplicateRecordCloning)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("assign", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodassign;
		}
		if (SwigDerivedClassHasMethod("compute", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcompute;
		}
		if (SwigDerivedClassHasMethod("del", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddel;
		}
		if (SwigDerivedClassHasMethod("newIterator", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewIterator;
		}
		if (SwigDerivedClassHasMethod("destDb", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddestDb;
		}
		if (SwigDerivedClassHasMethod("setDestDb", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetDestDb;
		}
		if (SwigDerivedClassHasMethod("origDb", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodorigDb;
		}
		if (SwigDerivedClassHasMethod("insertingXrefBlockId", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodinsertingXrefBlockId;
		}
		if (SwigDerivedClassHasMethod("deepCloneContext", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethoddeepCloneContext;
		}
		if (SwigDerivedClassHasMethod("duplicateRecordCloning", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodduplicateRecordCloning;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdMapping_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbIdMapping));
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

	private void SwigDirectorMethodassign(IntPtr idPair)
	{
		try
		{
			assign(new OdDbIdPair(idPair, cMemoryOwn: false));
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

	private bool SwigDirectorMethodcompute(IntPtr idPair)
	{
		return compute(new OdDbIdPair(idPair, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoddel(IntPtr key)
	{
		return del(new OdDbObjectId(key, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodnewIterator()
	{
		return OdDbIdMappingIter.getCPtr(newIterator()).Handle;
	}

	private IntPtr SwigDirectorMethoddestDb()
	{
		return OdDbDatabase.getCPtr(destDb()).Handle;
	}

	private void SwigDirectorMethodsetDestDb(IntPtr pDb)
	{
		try
		{
			setDestDb(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodorigDb()
	{
		return OdDbDatabase.getCPtr(origDb()).Handle;
	}

	private IntPtr SwigDirectorMethodinsertingXrefBlockId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(insertingXrefBlockId()).Handle;
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

	private int SwigDirectorMethoddeepCloneContext()
	{
		return (int)deepCloneContext();
	}

	private int SwigDirectorMethodduplicateRecordCloning()
	{
		return (int)duplicateRecordCloning();
	}
}
