using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbHighlightOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbHighlightOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbHighlightOverrule_1();

	public delegate void SwigDelegateOdDbHighlightOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbHighlightOverrule_3(IntPtr pOverruledSubject);

	public delegate void SwigDelegateOdDbHighlightOverrule_4(IntPtr pSubject, bool bDoIt, IntPtr pSubId, bool highlightAll);

	public delegate void SwigDelegateOdDbHighlightOverrule_5(IntPtr pSubject, bool bDoIt, IntPtr pSubId);

	public delegate void SwigDelegateOdDbHighlightOverrule_6(IntPtr pSubject, bool bDoIt);

	public delegate void SwigDelegateOdDbHighlightOverrule_7(IntPtr pSubject);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbHighlightOverrule_0 swigDelegate0;

	private SwigDelegateOdDbHighlightOverrule_1 swigDelegate1;

	private SwigDelegateOdDbHighlightOverrule_2 swigDelegate2;

	private SwigDelegateOdDbHighlightOverrule_3 swigDelegate3;

	private SwigDelegateOdDbHighlightOverrule_4 swigDelegate4;

	private SwigDelegateOdDbHighlightOverrule_5 swigDelegate5;

	private SwigDelegateOdDbHighlightOverrule_6 swigDelegate6;

	private SwigDelegateOdDbHighlightOverrule_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(bool),
		typeof(OdDbFullSubentPath),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(bool),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbEntity) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbHighlightOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHighlightOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbHighlightOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbHighlightOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbHighlightOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbHighlightOverrule cast(OdRxObject pObj)
	{
		OdDbHighlightOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHighlightOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_isASwigExplicitOdDbHighlightOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_queryXSwigExplicitOdDbHighlightOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbHighlightOverrule createObject()
	{
		OdDbHighlightOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHighlightOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void highlight(OdDbEntity pSubject, bool bDoIt, OdDbFullSubentPath pSubId, bool highlightAll)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlightSwigExplicitOdDbHighlightOverrule__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), bDoIt, OdDbFullSubentPath.getCPtr(pSubId), highlightAll);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlight__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), bDoIt, OdDbFullSubentPath.getCPtr(pSubId), highlightAll);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdDbEntity pSubject, bool bDoIt, OdDbFullSubentPath pSubId)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlightSwigExplicitOdDbHighlightOverrule__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), bDoIt, OdDbFullSubentPath.getCPtr(pSubId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlight__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), bDoIt, OdDbFullSubentPath.getCPtr(pSubId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdDbEntity pSubject, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlightSwigExplicitOdDbHighlightOverrule__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pSubject), bDoIt);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlight__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pSubject), bDoIt);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdDbEntity pSubject)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlightSwigExplicitOdDbHighlightOverrule__SWIG_3(swigCPtr, OdDbEntity.getCPtr(pSubject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_highlight__SWIG_3(swigCPtr, OdDbEntity.getCPtr(pSubject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodhighlight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodhighlight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodhighlight__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodhighlight__SWIG_3;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHighlightOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbHighlightOverrule));
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

	private void SwigDirectorMethodhighlight__SWIG_0(IntPtr pSubject, bool bDoIt, IntPtr pSubId, bool highlightAll)
	{
		try
		{
			highlight(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), bDoIt, (pSubId == IntPtr.Zero) ? null : new OdDbFullSubentPath(pSubId, cMemoryOwn: false), highlightAll);
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

	private void SwigDirectorMethodhighlight__SWIG_1(IntPtr pSubject, bool bDoIt, IntPtr pSubId)
	{
		try
		{
			highlight(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), bDoIt, (pSubId == IntPtr.Zero) ? null : new OdDbFullSubentPath(pSubId, cMemoryOwn: false));
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

	private void SwigDirectorMethodhighlight__SWIG_2(IntPtr pSubject, bool bDoIt)
	{
		try
		{
			highlight(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), bDoIt);
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

	private void SwigDirectorMethodhighlight__SWIG_3(IntPtr pSubject)
	{
		try
		{
			highlight(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false));
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
}
