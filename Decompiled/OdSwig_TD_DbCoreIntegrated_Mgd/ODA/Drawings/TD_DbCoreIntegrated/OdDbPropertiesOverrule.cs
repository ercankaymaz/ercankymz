using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbPropertiesOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbPropertiesOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPropertiesOverrule_1();

	public delegate void SwigDelegateOdDbPropertiesOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbPropertiesOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbPropertiesOverrule_4(IntPtr pSubject, IntPtr pClsid);

	public delegate void SwigDelegateOdDbPropertiesOverrule_5(IntPtr pSubject);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPropertiesOverrule_0 swigDelegate0;

	private SwigDelegateOdDbPropertiesOverrule_1 swigDelegate1;

	private SwigDelegateOdDbPropertiesOverrule_2 swigDelegate2;

	private SwigDelegateOdDbPropertiesOverrule_3 swigDelegate3;

	private SwigDelegateOdDbPropertiesOverrule_4 swigDelegate4;

	private SwigDelegateOdDbPropertiesOverrule_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbEntity) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPropertiesOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPropertiesOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbPropertiesOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbPropertiesOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbPropertiesOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbPropertiesOverrule cast(OdRxObject pObj)
	{
		OdDbPropertiesOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPropertiesOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_isASwigExplicitOdDbPropertiesOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_queryXSwigExplicitOdDbPropertiesOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbPropertiesOverrule createObject()
	{
		OdDbPropertiesOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPropertiesOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getClassID(OdDbObject pSubject, IntPtr pClsid)
	{
		int result = (SwigDerivedClassHasMethod("getClassID", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_getClassIDSwigExplicitOdDbPropertiesOverrule(swigCPtr, OdDbObject.getCPtr(pSubject), pClsid) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_getClassID(swigCPtr, OdDbObject.getCPtr(pSubject), pClsid));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void list(OdDbEntity pSubject)
	{
		if (SwigDerivedClassHasMethod("list", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_listSwigExplicitOdDbPropertiesOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_list(swigCPtr, OdDbEntity.getCPtr(pSubject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getClassID", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetClassID;
		}
		if (SwigDerivedClassHasMethod("list", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodlist;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbPropertiesOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPropertiesOverrule));
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

	private int SwigDirectorMethodgetClassID(IntPtr pSubject, IntPtr pClsid)
	{
		return (int)getClassID(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false), pClsid);
	}

	private void SwigDirectorMethodlist(IntPtr pSubject)
	{
		try
		{
			list(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false));
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
