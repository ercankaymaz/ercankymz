using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxPropertyOverrule : OdRxMemberOverrule
{
	public delegate IntPtr SwigDelegateOdRxPropertyOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxPropertyOverrule_1();

	public delegate void SwigDelegateOdRxPropertyOverrule_2(IntPtr pSource);

	public delegate int SwigDelegateOdRxPropertyOverrule_3(IntPtr pProp, IntPtr pO, IntPtr value);

	public delegate int SwigDelegateOdRxPropertyOverrule_4(IntPtr pProp, IntPtr pO, IntPtr value);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxPropertyOverrule_0 swigDelegate0;

	private SwigDelegateOdRxPropertyOverrule_1 swigDelegate1;

	private SwigDelegateOdRxPropertyOverrule_2 swigDelegate2;

	private SwigDelegateOdRxPropertyOverrule_3 swigDelegate3;

	private SwigDelegateOdRxPropertyOverrule_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdRxProperty),
		typeof(OdRxObject),
		typeof(OdRxValue)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdRxProperty),
		typeof(OdRxObject),
		typeof(OdRxValue)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxPropertyOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxPropertyOverrule obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxPropertyOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxPropertyOverrule cast(OdRxObject pObj)
	{
		OdRxPropertyOverrule rXObject = Helpers.GetRXObject<OdRxPropertyOverrule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_isASwigExplicitOdRxPropertyOverrule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_queryXSwigExplicitOdRxPropertyOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getValue(OdRxProperty pProp, OdRxObject pO, OdRxValue value)
	{
		int result = (SwigDerivedClassHasMethod("getValue", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_getValueSwigExplicitOdRxPropertyOverrule(swigCPtr, OdRxProperty.getCPtr(pProp), OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_getValue(swigCPtr, OdRxProperty.getCPtr(pProp), OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setValue(OdRxProperty pProp, OdRxObject pO, OdRxValue value)
	{
		int result = (SwigDerivedClassHasMethod("setValue", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_setValueSwigExplicitOdRxPropertyOverrule(swigCPtr, OdRxProperty.getCPtr(pProp), OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_setValue(swigCPtr, OdRxProperty.getCPtr(pProp), OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdRxPropertyOverrule createObject()
	{
		OdRxPropertyOverrule rXObject = Helpers.GetRXObject<OdRxPropertyOverrule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxPropertyOverrule()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxPropertyOverrule(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxPropertyOverrule) != GetType();
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
		if (SwigDerivedClassHasMethod("getValue", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetValue;
		}
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetValue;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxPropertyOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxPropertyOverrule));
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

	private int SwigDirectorMethodgetValue(IntPtr pProp, IntPtr pO, IntPtr value)
	{
		return (int)getValue(Helpers.GetRXObject<OdRxProperty>(pProp, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false), new OdRxValue(value, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetValue(IntPtr pProp, IntPtr pO, IntPtr value)
	{
		return (int)setValue(Helpers.GetRXObject<OdRxProperty>(pProp, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false), new OdRxValue(value, cMemoryOwn: false));
	}
}
