using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbVisibilityOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbVisibilityOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbVisibilityOverrule_1();

	public delegate void SwigDelegateOdDbVisibilityOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbVisibilityOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbVisibilityOverrule_4(IntPtr pSubject);

	public delegate int SwigDelegateOdDbVisibilityOverrule_5(IntPtr pSubject, int visibility, bool doSubents);

	public delegate int SwigDelegateOdDbVisibilityOverrule_6(IntPtr pSubject, int visibility);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbVisibilityOverrule_0 swigDelegate0;

	private SwigDelegateOdDbVisibilityOverrule_1 swigDelegate1;

	private SwigDelegateOdDbVisibilityOverrule_2 swigDelegate2;

	private SwigDelegateOdDbVisibilityOverrule_3 swigDelegate3;

	private SwigDelegateOdDbVisibilityOverrule_4 swigDelegate4;

	private SwigDelegateOdDbVisibilityOverrule_5 swigDelegate5;

	private SwigDelegateOdDbVisibilityOverrule_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbEntity) };

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDb_Visibility),
		typeof(bool)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDb_Visibility)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbVisibilityOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbVisibilityOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbVisibilityOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbVisibilityOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbVisibilityOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbVisibilityOverrule cast(OdRxObject pObj)
	{
		OdDbVisibilityOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbVisibilityOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_isASwigExplicitOdDbVisibilityOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_queryXSwigExplicitOdDbVisibilityOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbVisibilityOverrule createObject()
	{
		OdDbVisibilityOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbVisibilityOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDb_Visibility visibility(OdDbEntity pSubject)
	{
		int result = (SwigDerivedClassHasMethod("visibility", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_visibilitySwigExplicitOdDbVisibilityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_visibility(swigCPtr, OdDbEntity.getCPtr(pSubject)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual OdResult setVisibility(OdDbEntity pSubject, OdDb_Visibility visibility, bool doSubents)
	{
		int result = (SwigDerivedClassHasMethod("setVisibility", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_setVisibilitySwigExplicitOdDbVisibilityOverrule__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)visibility, doSubents) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_setVisibility__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)visibility, doSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setVisibility(OdDbEntity pSubject, OdDb_Visibility visibility)
	{
		int result = (SwigDerivedClassHasMethod("setVisibility", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_setVisibilitySwigExplicitOdDbVisibilityOverrule__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)visibility) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_setVisibility__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)visibility));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("isApplicable", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisApplicable;
		}
		if (SwigDerivedClassHasMethod("visibility", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodvisibility;
		}
		if (SwigDerivedClassHasMethod("setVisibility", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetVisibility__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setVisibility", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetVisibility__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbVisibilityOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbVisibilityOverrule));
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

	private bool SwigDirectorMethodisApplicable(IntPtr pOverruledSubject)
	{
		return isApplicable(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pOverruledSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodvisibility(IntPtr pSubject)
	{
		return (int)visibility(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodsetVisibility__SWIG_0(IntPtr pSubject, int visibility, bool doSubents)
	{
		return (int)setVisibility(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OdDb_Visibility)visibility, doSubents);
	}

	private int SwigDirectorMethodsetVisibility__SWIG_1(IntPtr pSubject, int visibility)
	{
		return (int)setVisibility(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OdDb_Visibility)visibility);
	}
}
