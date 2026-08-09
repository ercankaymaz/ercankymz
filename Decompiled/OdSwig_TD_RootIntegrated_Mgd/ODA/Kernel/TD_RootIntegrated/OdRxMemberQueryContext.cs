using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxMemberQueryContext : OdRxObject
{
	public delegate IntPtr SwigDelegateOdRxMemberQueryContext_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxMemberQueryContext_1();

	public delegate void SwigDelegateOdRxMemberQueryContext_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxMemberQueryContext_3(IntPtr facets, [MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate IntPtr SwigDelegateOdRxMemberQueryContext_4(IntPtr facets);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxMemberQueryContext_0 swigDelegate0;

	private SwigDelegateOdRxMemberQueryContext_1 swigDelegate1;

	private SwigDelegateOdRxMemberQueryContext_2 swigDelegate2;

	private SwigDelegateOdRxMemberQueryContext_3 swigDelegate3;

	private SwigDelegateOdRxMemberQueryContext_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdRxClassPtrArray),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxClassPtrArray) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxMemberQueryContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxMemberQueryContext obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_OdRxMemberQueryContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxMemberQueryContext cast(OdRxObject pObj)
	{
		OdRxMemberQueryContext rXObject = Helpers.GetRXObject<OdRxMemberQueryContext>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_isASwigExplicitOdRxMemberQueryContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_queryXSwigExplicitOdRxMemberQueryContext(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxMemberQueryContext createObject()
	{
		OdRxMemberQueryContext rXObject = Helpers.GetRXObject<OdRxMemberQueryContext>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxMemberIterator newMemberIterator(OdRxClassPtrArray facets)
	{
		OdRxMemberIterator result = Helpers.GetObject<OdRxMemberIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_newMemberIterator(swigCPtr, OdRxClassPtrArray.getCPtr(facets)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxMember find(OdRxClassPtrArray facets, string name)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(SwigDerivedClassHasMethod("find", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_findSwigExplicitOdRxMemberQueryContext(swigCPtr, OdRxClassPtrArray.getCPtr(facets), name) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_find(swigCPtr, OdRxClassPtrArray.getCPtr(facets), name), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected OdRxMemberQueryContext()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxMemberQueryContext(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxMemberQueryContext) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected virtual OdRxMemberIterator subNewMemberIterator(OdRxClassPtrArray facets)
	{
		OdRxMemberIterator result = Helpers.GetObject<OdRxMemberIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_subNewMemberIterator(swigCPtr, OdRxClassPtrArray.getCPtr(facets)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("find", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfind;
		}
		if (SwigDerivedClassHasMethod("subNewMemberIterator", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsubNewMemberIterator;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberQueryContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxMemberQueryContext));
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

	private IntPtr SwigDirectorMethodfind(IntPtr facets, [MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return OdRxMember.getCPtr(find(new OdRxClassPtrArray(facets, cMemoryOwn: false), name)).Handle;
	}

	private IntPtr SwigDirectorMethodsubNewMemberIterator(IntPtr facets)
	{
		return OdRxMemberIterator.getCPtr(subNewMemberIterator(new OdRxClassPtrArray(facets, cMemoryOwn: false))).Handle;
	}
}
