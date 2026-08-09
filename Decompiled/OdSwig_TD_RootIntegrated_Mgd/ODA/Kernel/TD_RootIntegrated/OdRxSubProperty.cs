using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxSubProperty : OdRxProperty
{
	public delegate IntPtr SwigDelegateOdRxSubProperty_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxSubProperty_1();

	public delegate void SwigDelegateOdRxSubProperty_2(IntPtr pSource);

	public delegate bool SwigDelegateOdRxSubProperty_3(IntPtr pO);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxSubProperty_0 swigDelegate0;

	private SwigDelegateOdRxSubProperty_1 swigDelegate1;

	private SwigDelegateOdRxSubProperty_2 swigDelegate2;

	private SwigDelegateOdRxSubProperty_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxSubProperty(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxSubProperty_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxSubProperty obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxSubProperty(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isReadOnly(OdRxObject pO)
	{
		bool result = (SwigDerivedClassHasMethod("isReadOnly", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxSubProperty_isReadOnlySwigExplicitOdRxSubProperty(swigCPtr, OdRxObject.getCPtr(pO)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxSubProperty_isReadOnly(swigCPtr, OdRxObject.getCPtr(pO)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSubProperty_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult SubGetValue(OdRxObject pO, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSubProperty_SubGetValue(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult SubSetValue(OdRxObject pO, OdRxValue value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSubProperty_SubSetValue(swigCPtr, OdRxObject.getCPtr(pO), OdRxValue.getCPtr(value));
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
		TD_RootIntegrated_GlobalsPINVOKE.OdRxSubProperty_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxSubProperty));
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
