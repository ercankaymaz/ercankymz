using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLongTransWorkSetIterator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbLongTransWorkSetIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLongTransWorkSetIterator_1();

	public delegate void SwigDelegateOdDbLongTransWorkSetIterator_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbLongTransWorkSetIterator_3(bool incRemovedObjs, bool incSecondaryObjs);

	public delegate void SwigDelegateOdDbLongTransWorkSetIterator_4(bool incRemovedObjs);

	public delegate void SwigDelegateOdDbLongTransWorkSetIterator_5();

	public delegate bool SwigDelegateOdDbLongTransWorkSetIterator_6();

	public delegate void SwigDelegateOdDbLongTransWorkSetIterator_7();

	public delegate IntPtr SwigDelegateOdDbLongTransWorkSetIterator_8();

	public delegate bool SwigDelegateOdDbLongTransWorkSetIterator_9();

	public delegate bool SwigDelegateOdDbLongTransWorkSetIterator_10();

	public delegate bool SwigDelegateOdDbLongTransWorkSetIterator_11();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLongTransWorkSetIterator_0 swigDelegate0;

	private SwigDelegateOdDbLongTransWorkSetIterator_1 swigDelegate1;

	private SwigDelegateOdDbLongTransWorkSetIterator_2 swigDelegate2;

	private SwigDelegateOdDbLongTransWorkSetIterator_3 swigDelegate3;

	private SwigDelegateOdDbLongTransWorkSetIterator_4 swigDelegate4;

	private SwigDelegateOdDbLongTransWorkSetIterator_5 swigDelegate5;

	private SwigDelegateOdDbLongTransWorkSetIterator_6 swigDelegate6;

	private SwigDelegateOdDbLongTransWorkSetIterator_7 swigDelegate7;

	private SwigDelegateOdDbLongTransWorkSetIterator_8 swigDelegate8;

	private SwigDelegateOdDbLongTransWorkSetIterator_9 swigDelegate9;

	private SwigDelegateOdDbLongTransWorkSetIterator_10 swigDelegate10;

	private SwigDelegateOdDbLongTransWorkSetIterator_11 swigDelegate11;

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

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLongTransWorkSetIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLongTransWorkSetIterator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLongTransWorkSetIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbLongTransWorkSetIterator cast(OdRxObject pObj)
	{
		OdDbLongTransWorkSetIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransWorkSetIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_isASwigExplicitOdDbLongTransWorkSetIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_queryXSwigExplicitOdDbLongTransWorkSetIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbLongTransWorkSetIterator createObject()
	{
		OdDbLongTransWorkSetIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLongTransWorkSetIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void start(bool incRemovedObjs, bool incSecondaryObjs)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_start__SWIG_0(swigCPtr, incRemovedObjs, incSecondaryObjs);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start(bool incRemovedObjs)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_start__SWIG_1(swigCPtr, incRemovedObjs);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void start()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_start__SWIG_2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool done()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_done(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void step()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_step(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId objectId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_objectId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool curObjectIsErased()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_curObjectIsErased(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool curObjectIsRemoved()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_curObjectIsRemoved(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool curObjectIsPrimary()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_curObjectIsPrimary(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbLongTransWorkSetIterator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLongTransWorkSetIterator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbLongTransWorkSetIterator) != GetType();
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
		if (SwigDerivedClassHasMethod("step", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodstep;
		}
		if (SwigDerivedClassHasMethod("objectId", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodobjectId;
		}
		if (SwigDerivedClassHasMethod("curObjectIsErased", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcurObjectIsErased;
		}
		if (SwigDerivedClassHasMethod("curObjectIsRemoved", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcurObjectIsRemoved;
		}
		if (SwigDerivedClassHasMethod("curObjectIsPrimary", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcurObjectIsPrimary;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLongTransWorkSetIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLongTransWorkSetIterator));
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

	private void SwigDirectorMethodstart__SWIG_0(bool incRemovedObjs, bool incSecondaryObjs)
	{
		try
		{
			start(incRemovedObjs, incSecondaryObjs);
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

	private void SwigDirectorMethodstart__SWIG_1(bool incRemovedObjs)
	{
		try
		{
			start(incRemovedObjs);
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

	private void SwigDirectorMethodstep()
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

	private bool SwigDirectorMethodcurObjectIsErased()
	{
		return curObjectIsErased();
	}

	private bool SwigDirectorMethodcurObjectIsRemoved()
	{
		return curObjectIsRemoved();
	}

	private bool SwigDirectorMethodcurObjectIsPrimary()
	{
		return curObjectIsPrimary();
	}
}
