using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxDisplayAsAttribute : OdRxAttribute
{
	public delegate IntPtr SwigDelegateOdRxDisplayAsAttribute_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxDisplayAsAttribute_1();

	public delegate void SwigDelegateOdRxDisplayAsAttribute_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdRxDisplayAsAttribute_3(IntPtr value, bool useDynamicProperties);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdRxDisplayAsAttribute_4(IntPtr value);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxDisplayAsAttribute_0 swigDelegate0;

	private SwigDelegateOdRxDisplayAsAttribute_1 swigDelegate1;

	private SwigDelegateOdRxDisplayAsAttribute_2 swigDelegate2;

	private SwigDelegateOdRxDisplayAsAttribute_3 swigDelegate3;

	private SwigDelegateOdRxDisplayAsAttribute_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdRxValue),
		typeof(bool)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxValue) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxDisplayAsAttribute(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxDisplayAsAttribute obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxDisplayAsAttribute(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxDisplayAsAttribute cast(OdRxObject pObj)
	{
		OdRxDisplayAsAttribute rXObject = Helpers.GetRXObject<OdRxDisplayAsAttribute>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_isASwigExplicitOdRxDisplayAsAttribute(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_queryXSwigExplicitOdRxDisplayAsAttribute(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxAttribute createObject(string property_name)
	{
		OdRxAttribute rXObject = Helpers.GetRXObject<OdRxAttribute>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_createObject__SWIG_0(property_name), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public string propertyName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_propertyName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getDisplayValue(OdRxValue value, bool useDynamicProperties)
	{
		string result = (SwigDerivedClassHasMethod("getDisplayValue", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_getDisplayValueSwigExplicitOdRxDisplayAsAttribute__SWIG_0(swigCPtr, OdRxValue.getCPtr(value), useDynamicProperties) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_getDisplayValue__SWIG_0(swigCPtr, OdRxValue.getCPtr(value), useDynamicProperties));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getDisplayValue(OdRxValue value)
	{
		string result = (SwigDerivedClassHasMethod("getDisplayValue", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_getDisplayValueSwigExplicitOdRxDisplayAsAttribute__SWIG_1(swigCPtr, OdRxValue.getCPtr(value)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_getDisplayValue__SWIG_1(swigCPtr, OdRxValue.getCPtr(value)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxDisplayAsAttribute()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxDisplayAsAttribute(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxDisplayAsAttribute) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdRxDisplayAsAttribute createObject()
	{
		OdRxDisplayAsAttribute rXObject = Helpers.GetRXObject<OdRxDisplayAsAttribute>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_createObject__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("getDisplayValue", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetDisplayValue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getDisplayValue", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetDisplayValue__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDisplayAsAttribute_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxDisplayAsAttribute));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetDisplayValue__SWIG_0(IntPtr value, bool useDynamicProperties)
	{
		return getDisplayValue(new OdRxValue(value, cMemoryOwn: false), useDynamicProperties);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetDisplayValue__SWIG_1(IntPtr value)
	{
		return getDisplayValue(new OdRxValue(value, cMemoryOwn: false));
	}
}
