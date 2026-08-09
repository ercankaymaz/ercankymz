using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxProperty : OdRxPropertyBase
{
	public delegate IntPtr SwigDelegateOdRxProperty_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxProperty_1();

	public delegate void SwigDelegateOdRxProperty_2(IntPtr pSource);

	public delegate bool SwigDelegateOdRxProperty_3(IntPtr pO);

	public delegate int SwigDelegateOdRxProperty_4(IntPtr pO, IntPtr value);

	public delegate int SwigDelegateOdRxProperty_5(IntPtr pO, IntPtr value);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxProperty_0 swigDelegate0;

	private SwigDelegateOdRxProperty_1 swigDelegate1;

	private SwigDelegateOdRxProperty_2 swigDelegate2;

	private SwigDelegateOdRxProperty_3 swigDelegate3;

	private SwigDelegateOdRxProperty_4 swigDelegate4;

	private SwigDelegateOdRxProperty_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxValue)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdRxValue)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxProperty(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxProperty obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxProperty(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxProperty cast(OdRxObject pObj)
	{
		OdRxProperty rXObject = Helpers.GetRXObject<OdRxProperty>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_isASwigExplicitOdRxProperty(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_queryXSwigExplicitOdRxProperty(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxProperty()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxProperty(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxProperty) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdResult getValue(OdRxObject pO, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_getValue(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setValue(OdRxObject pO, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_setValue(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subGetValue(OdRxObject pO, OdRxValue value)
	{
		int result = (SwigDerivedClassHasMethod("subGetValue", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_subGetValueSwigExplicitOdRxProperty(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_subGetValue(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected virtual OdResult subSetValue(OdRxObject pO, OdRxValue value)
	{
		int result = (SwigDerivedClassHasMethod("subSetValue", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_subSetValueSwigExplicitOdRxProperty(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_subSetValue(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdRxProperty createObject()
	{
		OdRxProperty rXObject = Helpers.GetRXObject<OdRxProperty>(TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("subGetValue", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsubGetValue;
		}
		if (SwigDerivedClassHasMethod("subSetValue", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsubSetValue;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxProperty_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxProperty));
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

	private int SwigDirectorMethodsubGetValue(IntPtr pO, IntPtr value)
	{
		return (int)subGetValue(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false), new OdRxValue(value, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubSetValue(IntPtr pO, IntPtr value)
	{
		return (int)subSetValue(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false), new OdRxValue(value, cMemoryOwn: false));
	}
}
