using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxCollectionPropertyOverrule : OdRxMemberOverrule
{
	public delegate IntPtr SwigDelegateOdRxCollectionPropertyOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxCollectionPropertyOverrule_1();

	public delegate void SwigDelegateOdRxCollectionPropertyOverrule_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxCollectionPropertyOverrule_3(IntPtr pProp, IntPtr pO);

	public delegate int SwigDelegateOdRxCollectionPropertyOverrule_4(IntPtr pProp, IntPtr pO, int count);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxCollectionPropertyOverrule_0 swigDelegate0;

	private SwigDelegateOdRxCollectionPropertyOverrule_1 swigDelegate1;

	private SwigDelegateOdRxCollectionPropertyOverrule_2 swigDelegate2;

	private SwigDelegateOdRxCollectionPropertyOverrule_3 swigDelegate3;

	private SwigDelegateOdRxCollectionPropertyOverrule_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdRxCollectionProperty),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdRxCollectionProperty),
		typeof(OdRxObject),
		typeof(int).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxCollectionPropertyOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxCollectionPropertyOverrule obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxCollectionPropertyOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxCollectionPropertyOverrule cast(OdRxObject pObj)
	{
		OdRxCollectionPropertyOverrule rXObject = Helpers.GetRXObject<OdRxCollectionPropertyOverrule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_isASwigExplicitOdRxCollectionPropertyOverrule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_queryXSwigExplicitOdRxCollectionPropertyOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxValueIterator newValueIterator(OdRxCollectionProperty pProp, OdRxObject pO)
	{
		OdRxValueIterator rXObject = Helpers.GetRXObject<OdRxValueIterator>(SwigDerivedClassHasMethod("newValueIterator", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_newValueIteratorSwigExplicitOdRxCollectionPropertyOverrule(swigCPtr, OdRxCollectionProperty.getCPtr(pProp), OdRxObject.getCPtr(pO)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_newValueIterator(swigCPtr, OdRxCollectionProperty.getCPtr(pProp), OdRxObject.getCPtr(pO)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult tryGetCount(OdRxCollectionProperty pProp, OdRxObject pO, out int count)
	{
		int result = (SwigDerivedClassHasMethod("tryGetCount", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_tryGetCountSwigExplicitOdRxCollectionPropertyOverrule(swigCPtr, OdRxCollectionProperty.getCPtr(pProp), OdRxObject.getCPtr(pO), out count) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_tryGetCount(swigCPtr, OdRxCollectionProperty.getCPtr(pProp), OdRxObject.getCPtr(pO), out count));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdRxCollectionPropertyOverrule createObject()
	{
		OdRxCollectionPropertyOverrule rXObject = Helpers.GetRXObject<OdRxCollectionPropertyOverrule>(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxCollectionPropertyOverrule()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxCollectionPropertyOverrule(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxCollectionPropertyOverrule) != GetType();
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
		if (SwigDerivedClassHasMethod("newValueIterator", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodnewValueIterator;
		}
		if (SwigDerivedClassHasMethod("tryGetCount", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodtryGetCount;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionPropertyOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxCollectionPropertyOverrule));
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

	private IntPtr SwigDirectorMethodnewValueIterator(IntPtr pProp, IntPtr pO)
	{
		return OdRxValueIterator.getCPtr(newValueIterator(Helpers.GetRXObject<OdRxCollectionProperty>(pProp, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private int SwigDirectorMethodtryGetCount(IntPtr pProp, IntPtr pO, int count)
	{
		return (int)tryGetCount(Helpers.GetRXObject<OdRxCollectionProperty>(pProp, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false), out count);
	}
}
