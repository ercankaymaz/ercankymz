using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDrawableOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdGiDrawableOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDrawableOverrule_1();

	public delegate void SwigDelegateOdGiDrawableOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiDrawableOverrule_3(IntPtr pOverruledSubject);

	public delegate uint SwigDelegateOdGiDrawableOverrule_4(IntPtr pSubject, IntPtr traits);

	public delegate bool SwigDelegateOdGiDrawableOverrule_5(IntPtr pSubject, IntPtr wd);

	public delegate void SwigDelegateOdGiDrawableOverrule_6(IntPtr pSubject, IntPtr vd);

	public delegate uint SwigDelegateOdGiDrawableOverrule_7(IntPtr pSubject, IntPtr vd);

	public delegate uint SwigDelegateOdGiDrawableOverrule_8(IntPtr pSubject);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDrawableOverrule_0 swigDelegate0;

	private SwigDelegateOdGiDrawableOverrule_1 swigDelegate1;

	private SwigDelegateOdGiDrawableOverrule_2 swigDelegate2;

	private SwigDelegateOdGiDrawableOverrule_3 swigDelegate3;

	private SwigDelegateOdGiDrawableOverrule_4 swigDelegate4;

	private SwigDelegateOdGiDrawableOverrule_5 swigDelegate5;

	private SwigDelegateOdGiDrawableOverrule_6 swigDelegate6;

	private SwigDelegateOdGiDrawableOverrule_7 swigDelegate7;

	private SwigDelegateOdGiDrawableOverrule_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawableTraits)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiWorldDraw)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiViewportDraw)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiViewportDraw)
	};

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiDrawable) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDrawableOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDrawableOverrule obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDrawableOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiDrawableOverrule()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDrawableOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdGiDrawableOverrule cast(OdRxObject pObj)
	{
		OdGiDrawableOverrule rXObject = Helpers.GetRXObject<OdGiDrawableOverrule>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_isASwigExplicitOdGiDrawableOverrule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_queryXSwigExplicitOdGiDrawableOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiDrawableOverrule createObject()
	{
		OdGiDrawableOverrule rXObject = Helpers.GetRXObject<OdGiDrawableOverrule>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint setAttributes(OdGiDrawable pSubject, OdGiDrawableTraits traits)
	{
		uint result = (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_setAttributesSwigExplicitOdGiDrawableOverrule(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiDrawableTraits.getCPtr(traits)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_setAttributes(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiDrawableTraits.getCPtr(traits)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool worldDraw(OdGiDrawable pSubject, OdGiWorldDraw wd)
	{
		bool result = (SwigDerivedClassHasMethod("worldDraw", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_worldDrawSwigExplicitOdGiDrawableOverrule(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiWorldDraw.getCPtr(wd)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_worldDraw(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiWorldDraw.getCPtr(wd)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void viewportDraw(OdGiDrawable pSubject, OdGiViewportDraw vd)
	{
		if (SwigDerivedClassHasMethod("viewportDraw", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_viewportDrawSwigExplicitOdGiDrawableOverrule(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiViewportDraw.getCPtr(vd));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_viewportDraw(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiViewportDraw.getCPtr(vd));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint viewportDrawLogicalFlags(OdGiDrawable pSubject, OdGiViewportDraw vd)
	{
		uint result = (SwigDerivedClassHasMethod("viewportDrawLogicalFlags", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_viewportDrawLogicalFlagsSwigExplicitOdGiDrawableOverrule(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiViewportDraw.getCPtr(vd)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_viewportDrawLogicalFlags(swigCPtr, OdGiDrawable.getCPtr(pSubject), OdGiViewportDraw.getCPtr(vd)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint regenSupportFlags(OdGiDrawable pSubject)
	{
		uint result = (SwigDerivedClassHasMethod("regenSupportFlags", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_regenSupportFlagsSwigExplicitOdGiDrawableOverrule(swigCPtr, OdGiDrawable.getCPtr(pSubject)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_regenSupportFlags(swigCPtr, OdGiDrawable.getCPtr(pSubject)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetAttributes;
		}
		if (SwigDerivedClassHasMethod("worldDraw", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodworldDraw;
		}
		if (SwigDerivedClassHasMethod("viewportDraw", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodviewportDraw;
		}
		if (SwigDerivedClassHasMethod("viewportDrawLogicalFlags", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodviewportDrawLogicalFlags;
		}
		if (SwigDerivedClassHasMethod("regenSupportFlags", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodregenSupportFlags;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDrawableOverrule));
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

	private bool SwigDirectorMethodisApplicable(IntPtr pOverruledSubject)
	{
		return isApplicable(Helpers.GetRXObject<OdRxObject>(pOverruledSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodsetAttributes(IntPtr pSubject, IntPtr traits)
	{
		return setAttributes(Helpers.GetRXObject<OdGiDrawable>(pSubject, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawableTraits>(traits, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodworldDraw(IntPtr pSubject, IntPtr wd)
	{
		return worldDraw(Helpers.GetRXObject<OdGiDrawable>(pSubject, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiWorldDraw>(wd, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodviewportDraw(IntPtr pSubject, IntPtr vd)
	{
		try
		{
			viewportDraw(Helpers.GetRXObject<OdGiDrawable>(pSubject, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodviewportDrawLogicalFlags(IntPtr pSubject, IntPtr vd)
	{
		return viewportDrawLogicalFlags(Helpers.GetRXObject<OdGiDrawable>(pSubject, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodregenSupportFlags(IntPtr pSubject)
	{
		return regenSupportFlags(Helpers.GetRXObject<OdGiDrawable>(pSubject, bOwn: false, bTryAddToTransaction: false));
	}
}
