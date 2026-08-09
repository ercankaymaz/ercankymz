using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxProtocolReactorIterator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxProtocolReactorIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxProtocolReactorIterator_1();

	public delegate void SwigDelegateOdRxProtocolReactorIterator_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxProtocolReactorIterator_3();

	public delegate void SwigDelegateOdRxProtocolReactorIterator_4();

	public delegate bool SwigDelegateOdRxProtocolReactorIterator_5();

	public delegate bool SwigDelegateOdRxProtocolReactorIterator_6();

	public delegate IntPtr SwigDelegateOdRxProtocolReactorIterator_7();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxProtocolReactorIterator_0 swigDelegate0;

	private SwigDelegateOdRxProtocolReactorIterator_1 swigDelegate1;

	private SwigDelegateOdRxProtocolReactorIterator_2 swigDelegate2;

	private SwigDelegateOdRxProtocolReactorIterator_3 swigDelegate3;

	private SwigDelegateOdRxProtocolReactorIterator_4 swigDelegate4;

	private SwigDelegateOdRxProtocolReactorIterator_5 swigDelegate5;

	private SwigDelegateOdRxProtocolReactorIterator_6 swigDelegate6;

	private SwigDelegateOdRxProtocolReactorIterator_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxProtocolReactorIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxProtocolReactorIterator obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxProtocolReactorIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxProtocolReactorIterator cast(OdRxObject pObj)
	{
		OdRxProtocolReactorIterator rXObject = Helpers.GetRXObject<OdRxProtocolReactorIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_isASwigExplicitOdRxProtocolReactorIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_queryXSwigExplicitOdRxProtocolReactorIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxProtocolReactorIterator createObject()
	{
		OdRxProtocolReactorIterator rXObject = Helpers.GetRXObject<OdRxProtocolReactorIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxClass reactorClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_reactorClass(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void start()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_start(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool next()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_next(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool done()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_done(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxProtocolReactor getObject()
	{
		OdRxProtocolReactor rXObject = Helpers.GetRXObject<OdRxProtocolReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_getObject(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxProtocolReactorIterator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxProtocolReactorIterator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxProtocolReactorIterator) != GetType();
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
		if (SwigDerivedClassHasMethod("reactorClass", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodreactorClass;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("next", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("done", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("getObject", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetObject;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxProtocolReactorIterator));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodreactorClass()
	{
		return OdRxClass.getCPtr(reactorClass()).Handle;
	}

	private void SwigDirectorMethodstart()
	{
		try
		{
			start();
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

	private bool SwigDirectorMethodnext()
	{
		return next();
	}

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private IntPtr SwigDirectorMethodgetObject()
	{
		return OdRxProtocolReactor.getCPtr(getObject()).Handle;
	}
}
