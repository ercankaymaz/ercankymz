using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectIterator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbObjectIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectIterator_1();

	public delegate void SwigDelegateOdDbObjectIterator_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbObjectIterator_3(bool atBeginning, bool skipErased);

	public delegate void SwigDelegateOdDbObjectIterator_4(bool atBeginning);

	public delegate void SwigDelegateOdDbObjectIterator_5();

	public delegate bool SwigDelegateOdDbObjectIterator_6();

	public delegate IntPtr SwigDelegateOdDbObjectIterator_7();

	public delegate IntPtr SwigDelegateOdDbObjectIterator_8(int openMode, bool openErasedEntity);

	public delegate IntPtr SwigDelegateOdDbObjectIterator_9(int openMode);

	public delegate IntPtr SwigDelegateOdDbObjectIterator_10();

	public delegate void SwigDelegateOdDbObjectIterator_11(bool forward, bool skipErased);

	public delegate void SwigDelegateOdDbObjectIterator_12(bool forward);

	public delegate void SwigDelegateOdDbObjectIterator_13();

	public delegate bool SwigDelegateOdDbObjectIterator_14(IntPtr objectId);

	public delegate bool SwigDelegateOdDbObjectIterator_15(IntPtr pEntity);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectIterator_0 swigDelegate0;

	private SwigDelegateOdDbObjectIterator_1 swigDelegate1;

	private SwigDelegateOdDbObjectIterator_2 swigDelegate2;

	private SwigDelegateOdDbObjectIterator_3 swigDelegate3;

	private SwigDelegateOdDbObjectIterator_4 swigDelegate4;

	private SwigDelegateOdDbObjectIterator_5 swigDelegate5;

	private SwigDelegateOdDbObjectIterator_6 swigDelegate6;

	private SwigDelegateOdDbObjectIterator_7 swigDelegate7;

	private SwigDelegateOdDbObjectIterator_8 swigDelegate8;

	private SwigDelegateOdDbObjectIterator_9 swigDelegate9;

	private SwigDelegateOdDbObjectIterator_10 swigDelegate10;

	private SwigDelegateOdDbObjectIterator_11 swigDelegate11;

	private SwigDelegateOdDbObjectIterator_12 swigDelegate12;

	private SwigDelegateOdDbObjectIterator_13 swigDelegate13;

	private SwigDelegateOdDbObjectIterator_14 swigDelegate14;

	private SwigDelegateOdDbObjectIterator_15 swigDelegate15;

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

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbEntity) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectIterator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbObjectIterator cast(OdRxObject pObj)
	{
		OdDbObjectIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_isASwigExplicitOdDbObjectIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_queryXSwigExplicitOdDbObjectIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectIterator createObject()
	{
		OdDbObjectIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectIterator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectIterator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbObjectIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void start(bool atBeginning, bool skipErased)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_start__SWIG_0(swigCPtr, atBeginning, skipErased);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start(bool atBeginning)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_start__SWIG_1(swigCPtr, atBeginning);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_start__SWIG_2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_done(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId objectId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_objectId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbEntity entity(OdDb_OpenMode openMode, bool openErasedEntity)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_entity__SWIG_0(swigCPtr, (int)openMode, openErasedEntity), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbEntity entity(OdDb_OpenMode openMode)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_entity__SWIG_1(swigCPtr, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbEntity entity()
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_entity__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void step(bool forward, bool skipErased)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_step__SWIG_0(swigCPtr, forward, skipErased);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void step(bool forward)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_step__SWIG_1(swigCPtr, forward);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void step()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_step__SWIG_2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool seek(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_seek__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool seek(OdDbEntity pEntity)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_seek__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("objectId", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodobjectId;
		}
		if (SwigDerivedClassHasMethod("entity", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodentity__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("entity", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodentity__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("entity", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodentity__SWIG_2;
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectIterator));
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

	private IntPtr SwigDirectorMethodobjectId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(objectId()).Handle;
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

	private IntPtr SwigDirectorMethodentity__SWIG_0(int openMode, bool openErasedEntity)
	{
		return OdDbEntity.getCPtr(entity((OdDb_OpenMode)openMode, openErasedEntity)).Handle;
	}

	private IntPtr SwigDirectorMethodentity__SWIG_1(int openMode)
	{
		return OdDbEntity.getCPtr(entity((OdDb_OpenMode)openMode)).Handle;
	}

	private IntPtr SwigDirectorMethodentity__SWIG_2()
	{
		return OdDbEntity.getCPtr(entity()).Handle;
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

	private bool SwigDirectorMethodseek__SWIG_0(IntPtr objectId)
	{
		return seek(new OdDbObjectId(objectId, cMemoryOwn: true));
	}

	private bool SwigDirectorMethodseek__SWIG_1(IntPtr pEntity)
	{
		return seek(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEntity, bOwn: false, bTryAddToTransaction: false));
	}
}
