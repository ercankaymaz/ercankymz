using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlockTableIterator : OdDbSymbolTableIterator
{
	public delegate IntPtr SwigDelegateOdDbBlockTableIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBlockTableIterator_1();

	public delegate void SwigDelegateOdDbBlockTableIterator_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbBlockTableIterator_3(bool atBeginning, bool skipErased);

	public delegate void SwigDelegateOdDbBlockTableIterator_4(bool atBeginning);

	public delegate void SwigDelegateOdDbBlockTableIterator_5();

	public delegate bool SwigDelegateOdDbBlockTableIterator_6();

	public delegate IntPtr SwigDelegateOdDbBlockTableIterator_7();

	public delegate IntPtr SwigDelegateOdDbBlockTableIterator_8(int openMode, bool openErasedRecord);

	public delegate IntPtr SwigDelegateOdDbBlockTableIterator_9(int openMode);

	public delegate IntPtr SwigDelegateOdDbBlockTableIterator_10();

	public delegate void SwigDelegateOdDbBlockTableIterator_11(bool forward, bool skipErased);

	public delegate void SwigDelegateOdDbBlockTableIterator_12(bool forward);

	public delegate void SwigDelegateOdDbBlockTableIterator_13();

	public delegate void SwigDelegateOdDbBlockTableIterator_14(IntPtr ObjectId);

	public delegate void SwigDelegateOdDbBlockTableIterator_15(IntPtr pRecord);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBlockTableIterator_0 swigDelegate0;

	private SwigDelegateOdDbBlockTableIterator_1 swigDelegate1;

	private SwigDelegateOdDbBlockTableIterator_2 swigDelegate2;

	private SwigDelegateOdDbBlockTableIterator_3 swigDelegate3;

	private SwigDelegateOdDbBlockTableIterator_4 swigDelegate4;

	private SwigDelegateOdDbBlockTableIterator_5 swigDelegate5;

	private SwigDelegateOdDbBlockTableIterator_6 swigDelegate6;

	private SwigDelegateOdDbBlockTableIterator_7 swigDelegate7;

	private SwigDelegateOdDbBlockTableIterator_8 swigDelegate8;

	private SwigDelegateOdDbBlockTableIterator_9 swigDelegate9;

	private SwigDelegateOdDbBlockTableIterator_10 swigDelegate10;

	private SwigDelegateOdDbBlockTableIterator_11 swigDelegate11;

	private SwigDelegateOdDbBlockTableIterator_12 swigDelegate12;

	private SwigDelegateOdDbBlockTableIterator_13 swigDelegate13;

	private SwigDelegateOdDbBlockTableIterator_14 swigDelegate14;

	private SwigDelegateOdDbBlockTableIterator_15 swigDelegate15;

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
	public OdDbBlockTableIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlockTableIterator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlockTableIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBlockTableIterator cast(OdRxObject pObj)
	{
		OdDbBlockTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_isASwigExplicitOdDbBlockTableIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_queryXSwigExplicitOdDbBlockTableIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbBlockTableIterator createObject()
	{
		OdDbBlockTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected OdDbBlockTableIterator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBlockTableIterator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBlockTableIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_getRealClassName(ptr);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBlockTableIterator));
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
