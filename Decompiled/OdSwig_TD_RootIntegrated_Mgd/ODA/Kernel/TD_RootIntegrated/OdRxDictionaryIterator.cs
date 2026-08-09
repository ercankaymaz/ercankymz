using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxDictionaryIterator : OdRxIterator
{
	public delegate IntPtr SwigDelegateOdRxDictionaryIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxDictionaryIterator_1();

	public delegate void SwigDelegateOdRxDictionaryIterator_2(IntPtr pSource);

	public delegate bool SwigDelegateOdRxDictionaryIterator_3();

	public delegate bool SwigDelegateOdRxDictionaryIterator_4();

	public delegate IntPtr SwigDelegateOdRxDictionaryIterator_5();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdRxDictionaryIterator_6();

	public delegate uint SwigDelegateOdRxDictionaryIterator_7();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxDictionaryIterator_0 swigDelegate0;

	private SwigDelegateOdRxDictionaryIterator_1 swigDelegate1;

	private SwigDelegateOdRxDictionaryIterator_2 swigDelegate2;

	private SwigDelegateOdRxDictionaryIterator_3 swigDelegate3;

	private SwigDelegateOdRxDictionaryIterator_4 swigDelegate4;

	private SwigDelegateOdRxDictionaryIterator_5 swigDelegate5;

	private SwigDelegateOdRxDictionaryIterator_6 swigDelegate6;

	private SwigDelegateOdRxDictionaryIterator_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxDictionaryIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxDictionaryIterator obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxDictionaryIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxDictionaryIterator cast(OdRxObject pObj)
	{
		OdRxDictionaryIterator rXObject = Helpers.GetRXObject<OdRxDictionaryIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_isASwigExplicitOdRxDictionaryIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_queryXSwigExplicitOdRxDictionaryIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxDictionaryIterator createObject()
	{
		OdRxDictionaryIterator rXObject = Helpers.GetRXObject<OdRxDictionaryIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getKey()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_getKey(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint id()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_id(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxDictionaryIterator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxDictionaryIterator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxDictionaryIterator) != GetType();
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
		if (SwigDerivedClassHasMethod("done", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("next", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("getObject", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetObject;
		}
		if (SwigDerivedClassHasMethod("getKey", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetKey;
		}
		if (SwigDerivedClassHasMethod("id", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodid;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxDictionaryIterator));
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

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private bool SwigDirectorMethodnext()
	{
		return next();
	}

	private IntPtr SwigDirectorMethodgetObject()
	{
		return OdRxObject.getCPtr(getObject()).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetKey()
	{
		return getKey();
	}

	private uint SwigDirectorMethodid()
	{
		return id();
	}
}
