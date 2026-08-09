using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAnnotativeObjectPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbAnnotativeObjectPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbAnnotativeObjectPE_1();

	public delegate void SwigDelegateOdDbAnnotativeObjectPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbAnnotativeObjectPE_3(IntPtr pObject);

	public delegate int SwigDelegateOdDbAnnotativeObjectPE_4(IntPtr pObject, bool bAnnotative);

	public delegate int SwigDelegateOdDbAnnotativeObjectPE_5(IntPtr pObject, bool bUpdated);

	public delegate bool SwigDelegateOdDbAnnotativeObjectPE_6(IntPtr arg0);

	public delegate int SwigDelegateOdDbAnnotativeObjectPE_7(IntPtr arg0, bool arg1);

	public delegate int SwigDelegateOdDbAnnotativeObjectPE_8(IntPtr arg0);

	public delegate bool SwigDelegateOdDbAnnotativeObjectPE_9(IntPtr arg0, int arg1, int arg2);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbAnnotativeObjectPE_0 swigDelegate0;

	private SwigDelegateOdDbAnnotativeObjectPE_1 swigDelegate1;

	private SwigDelegateOdDbAnnotativeObjectPE_2 swigDelegate2;

	private SwigDelegateOdDbAnnotativeObjectPE_3 swigDelegate3;

	private SwigDelegateOdDbAnnotativeObjectPE_4 swigDelegate4;

	private SwigDelegateOdDbAnnotativeObjectPE_5 swigDelegate5;

	private SwigDelegateOdDbAnnotativeObjectPE_6 swigDelegate6;

	private SwigDelegateOdDbAnnotativeObjectPE_7 swigDelegate7;

	private SwigDelegateOdDbAnnotativeObjectPE_8 swigDelegate8;

	private SwigDelegateOdDbAnnotativeObjectPE_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(OdDb_SaveType),
		typeof(DwgVersion)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAnnotativeObjectPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAnnotativeObjectPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAnnotativeObjectPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbAnnotativeObjectPE cast(OdRxObject pObj)
	{
		OdDbAnnotativeObjectPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAnnotativeObjectPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_isASwigExplicitOdDbAnnotativeObjectPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_queryXSwigExplicitOdDbAnnotativeObjectPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbAnnotativeObjectPE createObject()
	{
		OdDbAnnotativeObjectPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAnnotativeObjectPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool annotative(OdDbObject pObject)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_annotative(swigCPtr, OdDbObject.getCPtr(pObject));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setAnnotative(OdDbObject pObject, bool bAnnotative)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_setAnnotative(swigCPtr, OdDbObject.getCPtr(pObject), bAnnotative);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setFromStyle(OdDbObject pObject, out bool bUpdated)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_setFromStyle(swigCPtr, OdDbObject.getCPtr(pObject), out bUpdated);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool forceAnnoAllVisible(OdDbObject arg0)
	{
		bool result = (SwigDerivedClassHasMethod("forceAnnoAllVisible", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_forceAnnoAllVisibleSwigExplicitOdDbAnnotativeObjectPE(swigCPtr, OdDbObject.getCPtr(arg0)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_forceAnnoAllVisible(swigCPtr, OdDbObject.getCPtr(arg0)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setForceAnnoAllVisible(OdDbObject arg0, bool arg1)
	{
		int result = (SwigDerivedClassHasMethod("setForceAnnoAllVisible", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_setForceAnnoAllVisibleSwigExplicitOdDbAnnotativeObjectPE(swigCPtr, OdDbObject.getCPtr(arg0), arg1) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_setForceAnnoAllVisible(swigCPtr, OdDbObject.getCPtr(arg0), arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult resetScaleDependentProperties(OdDbObject arg0)
	{
		int result = (SwigDerivedClassHasMethod("resetScaleDependentProperties", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_resetScaleDependentPropertiesSwigExplicitOdDbAnnotativeObjectPE(swigCPtr, OdDbObject.getCPtr(arg0)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_resetScaleDependentProperties(swigCPtr, OdDbObject.getCPtr(arg0)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool decompose(OdDbObject arg0, OdDb_SaveType arg1, DwgVersion arg2)
	{
		bool result = (SwigDerivedClassHasMethod("decompose", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_decomposeSwigExplicitOdDbAnnotativeObjectPE(swigCPtr, OdDbObject.getCPtr(arg0), (int)arg1, (int)arg2) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_decompose(swigCPtr, OdDbObject.getCPtr(arg0), (int)arg1, (int)arg2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAnnotativeObjectPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbAnnotativeObjectPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbAnnotativeObjectPE) != GetType();
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
		if (SwigDerivedClassHasMethod("annotative", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodannotative;
		}
		if (SwigDerivedClassHasMethod("setAnnotative", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetAnnotative;
		}
		if (SwigDerivedClassHasMethod("setFromStyle", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetFromStyle;
		}
		if (SwigDerivedClassHasMethod("forceAnnoAllVisible", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodforceAnnoAllVisible;
		}
		if (SwigDerivedClassHasMethod("setForceAnnoAllVisible", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetForceAnnoAllVisible;
		}
		if (SwigDerivedClassHasMethod("resetScaleDependentProperties", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodresetScaleDependentProperties;
		}
		if (SwigDerivedClassHasMethod("decompose", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethoddecompose;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAnnotativeObjectPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbAnnotativeObjectPE));
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

	private bool SwigDirectorMethodannotative(IntPtr pObject)
	{
		return annotative(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodsetAnnotative(IntPtr pObject, bool bAnnotative)
	{
		return (int)setAnnotative(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), bAnnotative);
	}

	private int SwigDirectorMethodsetFromStyle(IntPtr pObject, bool bUpdated)
	{
		return (int)setFromStyle(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), out bUpdated);
	}

	private bool SwigDirectorMethodforceAnnoAllVisible(IntPtr arg0)
	{
		return forceAnnoAllVisible(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodsetForceAnnoAllVisible(IntPtr arg0, bool arg1)
	{
		return (int)setForceAnnoAllVisible(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1);
	}

	private int SwigDirectorMethodresetScaleDependentProperties(IntPtr arg0)
	{
		return (int)resetScaleDependentProperties(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethoddecompose(IntPtr arg0, int arg1, int arg2)
	{
		return decompose(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(arg0, bOwn: false, bTryAddToTransaction: false), (OdDb_SaveType)arg1, (DwgVersion)arg2);
	}
}
