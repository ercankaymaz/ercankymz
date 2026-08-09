using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxSubPropertyOfIndexedProperty : OdRxIndexedProperty
{
	public delegate IntPtr SwigDelegateOdRxSubPropertyOfIndexedProperty_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxSubPropertyOfIndexedProperty_1();

	public delegate void SwigDelegateOdRxSubPropertyOfIndexedProperty_2(IntPtr pSource);

	public delegate bool SwigDelegateOdRxSubPropertyOfIndexedProperty_3(IntPtr pO);

	public delegate IntPtr SwigDelegateOdRxSubPropertyOfIndexedProperty_4(IntPtr pO);

	public delegate int SwigDelegateOdRxSubPropertyOfIndexedProperty_5(IntPtr pO, int count);

	public delegate int SwigDelegateOdRxSubPropertyOfIndexedProperty_6(IntPtr arg0, int arg1, IntPtr arg2);

	public delegate int SwigDelegateOdRxSubPropertyOfIndexedProperty_7(IntPtr arg0, int arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_0 swigDelegate0;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_1 swigDelegate1;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_2 swigDelegate2;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_3 swigDelegate3;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_4 swigDelegate4;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_5 swigDelegate5;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_6 swigDelegate6;

	private SwigDelegateOdRxSubPropertyOfIndexedProperty_7 swigDelegate7;

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

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(int),
		typeof(OdRxValue)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(int)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxSubPropertyOfIndexedProperty(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxSubPropertyOfIndexedProperty_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxSubPropertyOfIndexedProperty obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxSubPropertyOfIndexedProperty(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdRxSubPropertyOfIndexedProperty()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxSubPropertyOfIndexedProperty(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxSubPropertyOfIndexedProperty) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdRxMember createObject(string memberName, OdRxValueType type, OdRxIndexedProperty owner)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(TD_RootIntegrated_GlobalsPINVOKE.OdRxSubPropertyOfIndexedProperty_createObject(memberName, OdRxValueType.getCPtr(type), OdRxIndexedProperty.getCPtr(owner)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult SubGetValue(OdRxObject pO, int index, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSubPropertyOfIndexedProperty_SubGetValue(swigCPtr, OdRxObject.getCPtr(pO), index, OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult SubSetValue(OdRxObject pO, int index, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSubPropertyOfIndexedProperty_SubSetValue(swigCPtr, OdRxObject.getCPtr(pO), index, OdRxValue.getCPtr(value));
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
		if (SwigDerivedClassHasMethod("subNewValueIterator", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsubNewValueIterator;
		}
		if (SwigDerivedClassHasMethod("subTryGetCount", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsubTryGetCount;
		}
		if (SwigDerivedClassHasMethod("subInsertValue", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsubInsertValue;
		}
		if (SwigDerivedClassHasMethod("subRemoveValue", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsubRemoveValue;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxSubPropertyOfIndexedProperty_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxSubPropertyOfIndexedProperty));
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

	private int SwigDirectorMethodsubInsertValue(IntPtr arg0, int arg1, IntPtr arg2)
	{
		return (int)subInsertValue(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1, new OdRxValue(arg2, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsubRemoveValue(IntPtr arg0, int arg1)
	{
		return (int)subRemoveValue(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), arg1);
	}
}
