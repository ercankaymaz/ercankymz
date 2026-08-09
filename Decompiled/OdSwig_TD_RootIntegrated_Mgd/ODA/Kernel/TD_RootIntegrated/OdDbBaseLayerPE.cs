using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseLayerPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseLayerPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseLayerPE_1();

	public delegate void SwigDelegateOdDbBaseLayerPE_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseLayerPE_3(IntPtr obj);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseLayerPE_4(IntPtr obj, IntPtr arg1);

	public delegate bool SwigDelegateOdDbBaseLayerPE_5(IntPtr obj);

	public delegate bool SwigDelegateOdDbBaseLayerPE_6(IntPtr obj);

	public delegate void SwigDelegateOdDbBaseLayerPE_7(IntPtr obj, bool off);

	public delegate void SwigDelegateOdDbBaseLayerPE_8(IntPtr obj, bool frozen);

	public delegate bool SwigDelegateOdDbBaseLayerPE_9(IntPtr obj, IntPtr LType);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseLayerPE_0 swigDelegate0;

	private SwigDelegateOdDbBaseLayerPE_1 swigDelegate1;

	private SwigDelegateOdDbBaseLayerPE_2 swigDelegate2;

	private SwigDelegateOdDbBaseLayerPE_3 swigDelegate3;

	private SwigDelegateOdDbBaseLayerPE_4 swigDelegate4;

	private SwigDelegateOdDbBaseLayerPE_5 swigDelegate5;

	private SwigDelegateOdDbBaseLayerPE_6 swigDelegate6;

	private SwigDelegateOdDbBaseLayerPE_7 swigDelegate7;

	private SwigDelegateOdDbBaseLayerPE_8 swigDelegate8;

	private SwigDelegateOdDbBaseLayerPE_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGiAuxiliaryData)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGiLinetype)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseLayerPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseLayerPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseLayerPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseLayerPE cast(OdRxObject pObj)
	{
		OdDbBaseLayerPE rXObject = Helpers.GetRXObject<OdDbBaseLayerPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_isASwigExplicitOdDbBaseLayerPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_queryXSwigExplicitOdDbBaseLayerPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseLayerPE createObject()
	{
		OdDbBaseLayerPE rXObject = Helpers.GetRXObject<OdDbBaseLayerPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string name(OdRxObject obj)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_name__SWIG_0(swigCPtr, OdRxObject.getCPtr(obj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string name(OdRxObject obj, OdGiAuxiliaryData arg1)
	{
		string result = (SwigDerivedClassHasMethod("name", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_nameSwigExplicitOdDbBaseLayerPE__SWIG_1(swigCPtr, OdRxObject.getCPtr(obj), OdGiAuxiliaryData.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_name__SWIG_1(swigCPtr, OdRxObject.getCPtr(obj), OdGiAuxiliaryData.getCPtr(arg1)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isOff(OdRxObject obj)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_isOff(swigCPtr, OdRxObject.getCPtr(obj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isFrozen(OdRxObject obj)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_isFrozen(swigCPtr, OdRxObject.getCPtr(obj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIsOff(OdRxObject obj, bool off)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_setIsOff(swigCPtr, OdRxObject.getCPtr(obj), off);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setIsFrozen(OdRxObject obj, bool frozen)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_setIsFrozen(swigCPtr, OdRxObject.getCPtr(obj), frozen);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getLineType(OdRxObject obj, OdGiLinetype LType)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_getLineType(swigCPtr, OdRxObject.getCPtr(obj), OdGiLinetype.getCPtr(LType));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBaseLayerPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseLayerPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseLayerPE) != GetType();
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
		if (SwigDerivedClassHasMethod("name", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodname__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("name", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodname__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isOff", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodisOff;
		}
		if (SwigDerivedClassHasMethod("isFrozen", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisFrozen;
		}
		if (SwigDerivedClassHasMethod("setIsOff", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetIsOff;
		}
		if (SwigDerivedClassHasMethod("setIsFrozen", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetIsFrozen;
		}
		if (SwigDerivedClassHasMethod("getLineType", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetLineType;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayerPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseLayerPE));
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
	private string SwigDirectorMethodname__SWIG_0(IntPtr obj)
	{
		return name(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname__SWIG_1(IntPtr obj, IntPtr arg1)
	{
		return name(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiAuxiliaryData>(arg1, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisOff(IntPtr obj)
	{
		return isOff(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisFrozen(IntPtr obj)
	{
		return isFrozen(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetIsOff(IntPtr obj, bool off)
	{
		try
		{
			setIsOff(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false), off);
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

	private void SwigDirectorMethodsetIsFrozen(IntPtr obj, bool frozen)
	{
		try
		{
			setIsFrozen(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false), frozen);
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

	private bool SwigDirectorMethodgetLineType(IntPtr obj, IntPtr LType)
	{
		return getLineType(Helpers.GetRXObject<OdRxObject>(obj, bOwn: false, bTryAddToTransaction: false), new OdGiLinetype(LType, cMemoryOwn: false));
	}
}
