using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxBoxedValue : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxBoxedValue_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxBoxedValue_1();

	public delegate IntPtr SwigDelegateOdRxBoxedValue_2();

	public delegate void SwigDelegateOdRxBoxedValue_3(IntPtr other);

	public delegate bool SwigDelegateOdRxBoxedValue_4(IntPtr other);

	public delegate IntPtr SwigDelegateOdRxBoxedValue_5();

	public delegate IntPtr SwigDelegateOdRxBoxedValue_6();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxBoxedValue_0 swigDelegate0;

	private SwigDelegateOdRxBoxedValue_1 swigDelegate1;

	private SwigDelegateOdRxBoxedValue_2 swigDelegate2;

	private SwigDelegateOdRxBoxedValue_3 swigDelegate3;

	private SwigDelegateOdRxBoxedValue_4 swigDelegate4;

	private SwigDelegateOdRxBoxedValue_5 swigDelegate5;

	private SwigDelegateOdRxBoxedValue_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxBoxedValue(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxBoxedValue obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxBoxedValue(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxBoxedValue cast(OdRxObject pObj)
	{
		OdRxBoxedValue rXObject = Helpers.GetRXObject<OdRxBoxedValue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_isASwigExplicitOdRxBoxedValue(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_queryXSwigExplicitOdRxBoxedValue(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxBoxedValue createObject()
	{
		OdRxBoxedValue rXObject = Helpers.GetRXObject<OdRxBoxedValue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxValue value()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_value__SWIG_0(swigCPtr);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxBoxedValue newBoxedValueOnHeap(OdRxValue value)
	{
		OdRxBoxedValue rXObject = Helpers.GetRXObject<OdRxBoxedValue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_newBoxedValueOnHeap(OdRxValue.getCPtr(value)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_cloneSwigExplicitOdRxBoxedValue(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject other)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_copyFromSwigExplicitOdRxBoxedValue(swigCPtr, OdRxObject.getCPtr(other));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_copyFrom(swigCPtr, OdRxObject.getCPtr(other));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isEqualTo(OdRxObject other)
	{
		bool result = (SwigDerivedClassHasMethod("isEqualTo", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_isEqualToSwigExplicitOdRxBoxedValue(swigCPtr, OdRxObject.getCPtr(other)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_isEqualTo(swigCPtr, OdRxObject.getCPtr(other)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdRx_Ordering comparedTo(OdRxObject other)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_comparedTo(swigCPtr, OdRxObject.getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdRx_Ordering)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxBoxedValue()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxBoxedValue(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxBoxedValue) != GetType();
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
		if (SwigDerivedClassHasMethod("clone", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodclone;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("isEqualTo", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisEqualTo;
		}
		if (SwigDerivedClassHasMethod("value", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodvalue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("value", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodvalue__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxBoxedValue_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxBoxedValue));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private IntPtr SwigDirectorMethodclone()
	{
		return OdRxObject.getCPtr(clone()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr other)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(other, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodisEqualTo(IntPtr other)
	{
		return isEqualTo(Helpers.GetRXObject<OdRxObject>(other, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodvalue__SWIG_0()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdRxValue.getCPtr(value()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodvalue__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdRxValue.getCPtr(value()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
