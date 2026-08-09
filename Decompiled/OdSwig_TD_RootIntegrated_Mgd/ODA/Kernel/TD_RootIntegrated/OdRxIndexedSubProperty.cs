using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxIndexedSubProperty : OdRxIndexedProperty
{
	public delegate IntPtr SwigDelegateOdRxIndexedSubProperty_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxIndexedSubProperty_1();

	public delegate void SwigDelegateOdRxIndexedSubProperty_2(IntPtr pSource);

	public delegate bool SwigDelegateOdRxIndexedSubProperty_3(IntPtr pO);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxIndexedSubProperty_0 swigDelegate0;

	private SwigDelegateOdRxIndexedSubProperty_1 swigDelegate1;

	private SwigDelegateOdRxIndexedSubProperty_2 swigDelegate2;

	private SwigDelegateOdRxIndexedSubProperty_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxIndexedSubProperty(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxIndexedSubProperty obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxIndexedSubProperty(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdRxIndexedSubProperty()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxIndexedSubProperty(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxIndexedSubProperty) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdRxMember createObject(string memberName, OdRxValueType type, OdRxProperty owner)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_createObject(memberName, OdRxValueType.getCPtr(type), OdRxProperty.getCPtr(owner)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult SubGetValue(OdRxObject pO, int index, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_SubGetValue(swigCPtr, OdRxObject.getCPtr(pO), index, OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult SubSetValue(OdRxObject pO, int index, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_SubSetValue(swigCPtr, OdRxObject.getCPtr(pO), index, OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult SubInsertValue(OdRxObject pO, int index, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_SubInsertValue(swigCPtr, OdRxObject.getCPtr(pO), index, OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult SubRemoveValue(OdRxObject pO, int index)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_SubRemoveValue(swigCPtr, OdRxObject.getCPtr(pO), index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdRxValueIterator SubNewValueIterator(OdRxObject pO)
	{
		OdRxValueIterator rXObject = Helpers.GetRXObject<OdRxValueIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_SubNewValueIterator(swigCPtr, OdRxObject.getCPtr(pO)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult SubTryGetCount(OdRxObject pO, out int count)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_SubTryGetCount(swigCPtr, OdRxObject.getCPtr(pO), out count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
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
		TD_RootIntegrated_GlobalsPINVOKE.OdRxIndexedSubProperty_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxIndexedSubProperty));
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
}
