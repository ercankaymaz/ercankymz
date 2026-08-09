using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxDictionaryProperty : OdRxCollectionProperty
{
	public delegate IntPtr SwigDelegateOdRxDictionaryProperty_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxDictionaryProperty_1();

	public delegate void SwigDelegateOdRxDictionaryProperty_2(IntPtr pSource);

	public delegate bool SwigDelegateOdRxDictionaryProperty_3(IntPtr pO);

	public delegate IntPtr SwigDelegateOdRxDictionaryProperty_4(IntPtr pO);

	public delegate int SwigDelegateOdRxDictionaryProperty_5(IntPtr pO, int count);

	public delegate int SwigDelegateOdRxDictionaryProperty_6(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1, IntPtr arg2);

	public delegate int SwigDelegateOdRxDictionaryProperty_7(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1, IntPtr arg2);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxDictionaryProperty_0 swigDelegate0;

	private SwigDelegateOdRxDictionaryProperty_1 swigDelegate1;

	private SwigDelegateOdRxDictionaryProperty_2 swigDelegate2;

	private SwigDelegateOdRxDictionaryProperty_3 swigDelegate3;

	private SwigDelegateOdRxDictionaryProperty_4 swigDelegate4;

	private SwigDelegateOdRxDictionaryProperty_5 swigDelegate5;

	private SwigDelegateOdRxDictionaryProperty_6 swigDelegate6;

	private SwigDelegateOdRxDictionaryProperty_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(string),
		typeof(OdRxValue)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(string),
		typeof(OdRxValue)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxDictionaryProperty(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxDictionaryProperty obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxDictionaryProperty(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxDictionaryProperty cast(OdRxObject pObj)
	{
		OdRxDictionaryProperty rXObject = Helpers.GetRXObject<OdRxDictionaryProperty>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_isASwigExplicitOdRxDictionaryProperty(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_queryXSwigExplicitOdRxDictionaryProperty(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult getValue(OdRxObject pO, string key, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_getValue(swigCPtr, OdRxObject.getCPtr(pO), key, OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(OdRxObject pO, string key, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_setValue(swigCPtr, OdRxObject.getCPtr(pO), key, OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdRxDictionaryProperty()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxDictionaryProperty(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxDictionaryProperty) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected virtual OdResult subGetValue(OdRxObject arg0, string arg1, OdRxValue arg2)
	{
		int result = (SwigDerivedClassHasMethod("subGetValue", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_subGetValueSwigExplicitOdRxDictionaryProperty(swigCPtr, OdRxObject.getCPtr(arg0), arg1, OdRxValue.getCPtr(arg2)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_subGetValue(swigCPtr, OdRxObject.getCPtr(arg0), arg1, OdRxValue.getCPtr(arg2)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subSetValue(OdRxObject arg0, string arg1, OdRxValue arg2)
	{
		int result = (SwigDerivedClassHasMethod("subSetValue", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_subSetValueSwigExplicitOdRxDictionaryProperty(swigCPtr, OdRxObject.getCPtr(arg0), arg1, OdRxValue.getCPtr(arg2)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_subSetValue(swigCPtr, OdRxObject.getCPtr(arg0), arg1, OdRxValue.getCPtr(arg2)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdRxDictionaryProperty createObject()
	{
		OdRxDictionaryProperty rXObject = Helpers.GetRXObject<OdRxDictionaryProperty>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("isReadOnly", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisReadOnly;
		}
		if (SwigDerivedClassHasMethod("subNewValueIterator", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsubNewValueIterator;
		}
		if (SwigDerivedClassHasMethod("subTryGetCount", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsubTryGetCount;
		}
		if (SwigDerivedClassHasMethod("subGetValue", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsubGetValue;
		}
		if (SwigDerivedClassHasMethod("subSetValue", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsubSetValue;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionaryProperty_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxDictionaryProperty));
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

	private bool SwigDirectorMethodisReadOnly(IntPtr pO)
	{
		return isReadOnly(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodsubNewValueIterator(IntPtr pO)
	{
		return OdRxValueIterator.getCPtr(subNewValueIterator(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private int SwigDirectorMethodsubTryGetCount(IntPtr pO, int count)
	{
		return (int)subTryGetCount(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false), out count);
	}

	private int SwigDirectorMethodsubGetValue(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1, IntPtr arg2)
	{
		return (int)subGetValue(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1, new OdRxValue(arg2, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubSetValue(IntPtr arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1, IntPtr arg2)
	{
		return (int)subSetValue(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1, new OdRxValue(arg2, cMemoryOwn: false));
	}
}
