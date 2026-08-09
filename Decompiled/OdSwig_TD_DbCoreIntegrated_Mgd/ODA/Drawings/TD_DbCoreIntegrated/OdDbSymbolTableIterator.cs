using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSymbolTableIterator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbSymbolTableIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSymbolTableIterator_1();

	public delegate void SwigDelegateOdDbSymbolTableIterator_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbSymbolTableIterator_3(bool atBeginning, bool skipErased);

	public delegate void SwigDelegateOdDbSymbolTableIterator_4(bool atBeginning);

	public delegate void SwigDelegateOdDbSymbolTableIterator_5();

	public delegate bool SwigDelegateOdDbSymbolTableIterator_6();

	public delegate IntPtr SwigDelegateOdDbSymbolTableIterator_7();

	public delegate IntPtr SwigDelegateOdDbSymbolTableIterator_8(int openMode, bool openErasedRecord);

	public delegate IntPtr SwigDelegateOdDbSymbolTableIterator_9(int openMode);

	public delegate IntPtr SwigDelegateOdDbSymbolTableIterator_10();

	public delegate void SwigDelegateOdDbSymbolTableIterator_11(bool forward, bool skipErased);

	public delegate void SwigDelegateOdDbSymbolTableIterator_12(bool forward);

	public delegate void SwigDelegateOdDbSymbolTableIterator_13();

	public delegate void SwigDelegateOdDbSymbolTableIterator_14(IntPtr ObjectId);

	public delegate void SwigDelegateOdDbSymbolTableIterator_15(IntPtr pRecord);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSymbolTableIterator_0 swigDelegate0;

	private SwigDelegateOdDbSymbolTableIterator_1 swigDelegate1;

	private SwigDelegateOdDbSymbolTableIterator_2 swigDelegate2;

	private SwigDelegateOdDbSymbolTableIterator_3 swigDelegate3;

	private SwigDelegateOdDbSymbolTableIterator_4 swigDelegate4;

	private SwigDelegateOdDbSymbolTableIterator_5 swigDelegate5;

	private SwigDelegateOdDbSymbolTableIterator_6 swigDelegate6;

	private SwigDelegateOdDbSymbolTableIterator_7 swigDelegate7;

	private SwigDelegateOdDbSymbolTableIterator_8 swigDelegate8;

	private SwigDelegateOdDbSymbolTableIterator_9 swigDelegate9;

	private SwigDelegateOdDbSymbolTableIterator_10 swigDelegate10;

	private SwigDelegateOdDbSymbolTableIterator_11 swigDelegate11;

	private SwigDelegateOdDbSymbolTableIterator_12 swigDelegate12;

	private SwigDelegateOdDbSymbolTableIterator_13 swigDelegate13;

	private SwigDelegateOdDbSymbolTableIterator_14 swigDelegate14;

	private SwigDelegateOdDbSymbolTableIterator_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDb_OpenMode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDb_OpenMode) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbSymbolTableRecord) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSymbolTableIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSymbolTableIterator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSymbolTableIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSymbolTableIterator cast(OdRxObject pObj)
	{
		OdDbSymbolTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSymbolTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_isASwigExplicitOdDbSymbolTableIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_queryXSwigExplicitOdDbSymbolTableIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSymbolTableIterator createObject()
	{
		OdDbSymbolTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSymbolTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void start(bool atBeginning, bool skipErased)
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_startSwigExplicitOdDbSymbolTableIterator__SWIG_0(swigCPtr, atBeginning, skipErased);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_start__SWIG_0(swigCPtr, atBeginning, skipErased);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start(bool atBeginning)
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_startSwigExplicitOdDbSymbolTableIterator__SWIG_1(swigCPtr, atBeginning);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_start__SWIG_1(swigCPtr, atBeginning);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start()
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_startSwigExplicitOdDbSymbolTableIterator__SWIG_2(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_start__SWIG_2(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = (SwigDerivedClassHasMethod("done", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_doneSwigExplicitOdDbSymbolTableIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_done(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getRecordId()
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getRecordId", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecordIdSwigExplicitOdDbSymbolTableIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecordId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbSymbolTableRecord getRecord(OdDb_OpenMode openMode, bool openErasedRecord)
	{
		OdDbSymbolTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSymbolTableRecord>(SwigDerivedClassHasMethod("getRecord", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecordSwigExplicitOdDbSymbolTableIterator__SWIG_0(swigCPtr, (int)openMode, openErasedRecord) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecord__SWIG_0(swigCPtr, (int)openMode, openErasedRecord), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbSymbolTableRecord getRecord(OdDb_OpenMode openMode)
	{
		OdDbSymbolTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSymbolTableRecord>(SwigDerivedClassHasMethod("getRecord", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecordSwigExplicitOdDbSymbolTableIterator__SWIG_1(swigCPtr, (int)openMode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecord__SWIG_1(swigCPtr, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbSymbolTableRecord getRecord()
	{
		OdDbSymbolTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSymbolTableRecord>(SwigDerivedClassHasMethod("getRecord", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecordSwigExplicitOdDbSymbolTableIterator__SWIG_2(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRecord__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void step(bool forward, bool skipErased)
	{
		if (SwigDerivedClassHasMethod("step", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_stepSwigExplicitOdDbSymbolTableIterator__SWIG_0(swigCPtr, forward, skipErased);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_step__SWIG_0(swigCPtr, forward, skipErased);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void step(bool forward)
	{
		if (SwigDerivedClassHasMethod("step", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_stepSwigExplicitOdDbSymbolTableIterator__SWIG_1(swigCPtr, forward);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_step__SWIG_1(swigCPtr, forward);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void step()
	{
		if (SwigDerivedClassHasMethod("step", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_stepSwigExplicitOdDbSymbolTableIterator__SWIG_2(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_step__SWIG_2(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void seek(OdDbObjectId ObjectId)
	{
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_seekSwigExplicitOdDbSymbolTableIterator__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(ObjectId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_seek__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(ObjectId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void seek(OdDbSymbolTableRecord pRecord)
	{
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_seekSwigExplicitOdDbSymbolTableIterator__SWIG_1(swigCPtr, OdDbSymbolTableRecord.getCPtr(pRecord));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_seek__SWIG_1(swigCPtr, OdDbSymbolTableRecord.getCPtr(pRecord));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected OdDbSymbolTableIterator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSymbolTableIterator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbSymbolTableIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("start", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodstart__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodstart__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodstart__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("done", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("getRecordId", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetRecordId;
		}
		if (SwigDerivedClassHasMethod("getRecord", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetRecord__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getRecord", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetRecord__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getRecord", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetRecord__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodstep__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodstep__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodstep__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodseek__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodseek__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymbolTableIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSymbolTableIterator));
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

	private void SwigDirectorMethodstart__SWIG_0(bool atBeginning, bool skipErased)
	{
		try
		{
			start(atBeginning, skipErased);
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

	private void SwigDirectorMethodstart__SWIG_1(bool atBeginning)
	{
		try
		{
			start(atBeginning);
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

	private void SwigDirectorMethodstart__SWIG_2()
	{
		try
		{
			start();
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

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private IntPtr SwigDirectorMethodgetRecordId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getRecordId()).Handle;
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

	private IntPtr SwigDirectorMethodgetRecord__SWIG_0(int openMode, bool openErasedRecord)
	{
		return OdDbSymbolTableRecord.getCPtr(getRecord((OdDb_OpenMode)openMode, openErasedRecord)).Handle;
	}

	private IntPtr SwigDirectorMethodgetRecord__SWIG_1(int openMode)
	{
		return OdDbSymbolTableRecord.getCPtr(getRecord((OdDb_OpenMode)openMode)).Handle;
	}

	private IntPtr SwigDirectorMethodgetRecord__SWIG_2()
	{
		return OdDbSymbolTableRecord.getCPtr(getRecord()).Handle;
	}

	private void SwigDirectorMethodstep__SWIG_0(bool forward, bool skipErased)
	{
		try
		{
			step(forward, skipErased);
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

	private void SwigDirectorMethodstep__SWIG_1(bool forward)
	{
		try
		{
			step(forward);
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

	private void SwigDirectorMethodstep__SWIG_2()
	{
		try
		{
			step();
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

	private void SwigDirectorMethodseek__SWIG_0(IntPtr ObjectId)
	{
		try
		{
			seek(new OdDbObjectId(ObjectId, cMemoryOwn: false));
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

	private void SwigDirectorMethodseek__SWIG_1(IntPtr pRecord)
	{
		try
		{
			seek(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSymbolTableRecord>(pRecord, bOwn: false, bTryAddToTransaction: false));
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
