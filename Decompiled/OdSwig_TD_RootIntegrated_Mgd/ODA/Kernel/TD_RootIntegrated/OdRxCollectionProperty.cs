using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxCollectionProperty : OdRxPropertyBase
{
	public delegate IntPtr SwigDelegateOdRxCollectionProperty_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxCollectionProperty_1();

	public delegate void SwigDelegateOdRxCollectionProperty_2(IntPtr pSource);

	public delegate bool SwigDelegateOdRxCollectionProperty_3(IntPtr pO);

	public delegate IntPtr SwigDelegateOdRxCollectionProperty_4(IntPtr pO);

	public delegate int SwigDelegateOdRxCollectionProperty_5(IntPtr pO, int count);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxCollectionProperty_0 swigDelegate0;

	private SwigDelegateOdRxCollectionProperty_1 swigDelegate1;

	private SwigDelegateOdRxCollectionProperty_2 swigDelegate2;

	private SwigDelegateOdRxCollectionProperty_3 swigDelegate3;

	private SwigDelegateOdRxCollectionProperty_4 swigDelegate4;

	private SwigDelegateOdRxCollectionProperty_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(int).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxCollectionProperty(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxCollectionProperty obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxCollectionProperty(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxCollectionProperty cast(OdRxObject pObj)
	{
		OdRxCollectionProperty rXObject = Helpers.GetRXObject<OdRxCollectionProperty>(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_isASwigExplicitOdRxCollectionProperty(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_queryXSwigExplicitOdRxCollectionProperty(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxValueIterator newValueIterator(OdRxObject pO)
	{
		OdRxValueIterator rXObject = Helpers.GetRXObject<OdRxValueIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_newValueIterator(swigCPtr, OdRxObject.getCPtr(pO)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult tryGetCount(OdRxObject pO, out int count)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_tryGetCount(swigCPtr, OdRxObject.getCPtr(pO), out count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdRxCollectionProperty()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxCollectionProperty(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxCollectionProperty) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected virtual OdRxValueIterator subNewValueIterator(OdRxObject pO)
	{
		OdRxValueIterator rXObject = Helpers.GetRXObject<OdRxValueIterator>(SwigDerivedClassHasMethod("subNewValueIterator", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_subNewValueIteratorSwigExplicitOdRxCollectionProperty(swigCPtr, OdRxObject.getCPtr(pO)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_subNewValueIterator(swigCPtr, OdRxObject.getCPtr(pO)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual OdResult subTryGetCount(OdRxObject pO, out int count)
	{
		int result = (SwigDerivedClassHasMethod("subTryGetCount", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_subTryGetCountSwigExplicitOdRxCollectionProperty(swigCPtr, OdRxObject.getCPtr(pO), out count) : TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_subTryGetCount(swigCPtr, OdRxObject.getCPtr(pO), out count));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdRxCollectionProperty createObject()
	{
		OdRxCollectionProperty rXObject = Helpers.GetRXObject<OdRxCollectionProperty>(TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("isReadOnly", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisReadOnly;
		}
		if (SwigDerivedClassHasMethod("subNewValueIterator", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsubNewValueIterator;
		}
		if (SwigDerivedClassHasMethod("subTryGetCount", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsubTryGetCount;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxCollectionProperty_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxCollectionProperty));
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

	private bool SwigDirectorMethodisReadOnly(IntPtr pO)
	{
		return isReadOnly(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodsubNewValueIterator(IntPtr pO)
	{
		return OdRxValueIterator.getCPtr(subNewValueIterator(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private int SwigDirectorMethodsubTryGetCount(IntPtr pO, int count)
	{
		return (int)subTryGetCount(Helpers.GetRXObject<OdRxObject>(pO, bOwn: false, bTryAddToTransaction: false), out count);
	}
}
