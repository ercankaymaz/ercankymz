using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbEvalContext : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbEvalContext_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbEvalContext_1();

	public delegate void SwigDelegateOdDbEvalContext_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbEvalContext_3(IntPtr pair);

	public delegate void SwigDelegateOdDbEvalContext_4([MarshalAs(UnmanagedType.LPWStr)] string key);

	public delegate bool SwigDelegateOdDbEvalContext_5(IntPtr pair);

	public delegate IntPtr SwigDelegateOdDbEvalContext_6();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbEvalContext_0 swigDelegate0;

	private SwigDelegateOdDbEvalContext_1 swigDelegate1;

	private SwigDelegateOdDbEvalContext_2 swigDelegate2;

	private SwigDelegateOdDbEvalContext_3 swigDelegate3;

	private SwigDelegateOdDbEvalContext_4 swigDelegate4;

	private SwigDelegateOdDbEvalContext_5 swigDelegate5;

	private SwigDelegateOdDbEvalContext_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbEvalContextPair) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbEvalContextPair) };

	private static Type[] swigMethodTypes6 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbEvalContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbEvalContext obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbEvalContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbEvalContext()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbEvalContext(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbEvalContext) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbEvalContext cast(OdRxObject pObj)
	{
		OdDbEvalContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_isASwigExplicitOdDbEvalContext(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_queryXSwigExplicitOdDbEvalContext(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void insertAt(OdDbEvalContextPair pair)
	{
		if (SwigDerivedClassHasMethod("insertAt", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_insertAtSwigExplicitOdDbEvalContext(swigCPtr, OdDbEvalContextPair.getCPtr(pair));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_insertAt(swigCPtr, OdDbEvalContextPair.getCPtr(pair));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeAt(string key)
	{
		if (SwigDerivedClassHasMethod("removeAt", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_removeAtSwigExplicitOdDbEvalContext(swigCPtr, key);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_removeAt(swigCPtr, key);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getAt(OdDbEvalContextPair pair)
	{
		bool result = (SwigDerivedClassHasMethod("getAt", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_getAtSwigExplicitOdDbEvalContext(swigCPtr, OdDbEvalContextPair.getCPtr(pair)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_getAt(swigCPtr, OdDbEvalContextPair.getCPtr(pair)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbEvalContextIterator newIterator()
	{
		OdDbEvalContextIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalContextIterator>(SwigDerivedClassHasMethod("newIterator", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_newIteratorSwigExplicitOdDbEvalContext(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_newIterator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbEvalContext createObject()
	{
		OdDbEvalContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("insertAt", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinsertAt;
		}
		if (SwigDerivedClassHasMethod("removeAt", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodremoveAt;
		}
		if (SwigDerivedClassHasMethod("getAt", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetAt;
		}
		if (SwigDerivedClassHasMethod("newIterator", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewIterator;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEvalContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbEvalContext));
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

	private void SwigDirectorMethodinsertAt(IntPtr pair)
	{
		try
		{
			insertAt(new OdDbEvalContextPair(pair, cMemoryOwn: false));
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

	private void SwigDirectorMethodremoveAt([MarshalAs(UnmanagedType.LPWStr)] string key)
	{
		try
		{
			removeAt(key);
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

	private bool SwigDirectorMethodgetAt(IntPtr pair)
	{
		return getAt(new OdDbEvalContextPair(pair, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodnewIterator()
	{
		return OdDbEvalContextIterator.getCPtr(newIterator()).Handle;
	}
}
