using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxProtocolReactorList : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxProtocolReactorList_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxProtocolReactorList_1();

	public delegate void SwigDelegateOdRxProtocolReactorList_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxProtocolReactorList_3();

	public delegate bool SwigDelegateOdRxProtocolReactorList_4(IntPtr pReactor);

	public delegate void SwigDelegateOdRxProtocolReactorList_5(IntPtr pReactor);

	public delegate IntPtr SwigDelegateOdRxProtocolReactorList_6();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxProtocolReactorList_0 swigDelegate0;

	private SwigDelegateOdRxProtocolReactorList_1 swigDelegate1;

	private SwigDelegateOdRxProtocolReactorList_2 swigDelegate2;

	private SwigDelegateOdRxProtocolReactorList_3 swigDelegate3;

	private SwigDelegateOdRxProtocolReactorList_4 swigDelegate4;

	private SwigDelegateOdRxProtocolReactorList_5 swigDelegate5;

	private SwigDelegateOdRxProtocolReactorList_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxProtocolReactor) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxProtocolReactor) };

	private static Type[] swigMethodTypes6 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxProtocolReactorList(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxProtocolReactorList obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxProtocolReactorList(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxProtocolReactorList cast(OdRxObject pObj)
	{
		OdRxProtocolReactorList rXObject = Helpers.GetRXObject<OdRxProtocolReactorList>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_isASwigExplicitOdRxProtocolReactorList(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_queryXSwigExplicitOdRxProtocolReactorList(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxProtocolReactorList createObject()
	{
		OdRxProtocolReactorList rXObject = Helpers.GetRXObject<OdRxProtocolReactorList>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxClass reactorClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_reactorClass(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool addReactor(OdRxProtocolReactor pReactor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_addReactor(swigCPtr, OdRxProtocolReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void removeReactor(OdRxProtocolReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_removeReactor(swigCPtr, OdRxProtocolReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxProtocolReactorIterator newIterator()
	{
		OdRxProtocolReactorIterator rXObject = Helpers.GetRXObject<OdRxProtocolReactorIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_newIterator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxProtocolReactorList()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxProtocolReactorList(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxProtocolReactorList) != GetType();
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
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodaddReactor;
		}
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodremoveReactor;
		}
		if (SwigDerivedClassHasMethod("newIterator", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewIterator;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxProtocolReactorList_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxProtocolReactorList));
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

	private bool SwigDirectorMethodaddReactor(IntPtr pReactor)
	{
		return addReactor(Helpers.GetRXObject<OdRxProtocolReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodremoveReactor(IntPtr pReactor)
	{
		try
		{
			removeReactor(Helpers.GetRXObject<OdRxProtocolReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodnewIterator()
	{
		return OdRxProtocolReactorIterator.getCPtr(newIterator()).Handle;
	}
}
