using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDefaultErrorContext : OdErrorContext
{
	public delegate IntPtr SwigDelegateOdDefaultErrorContext_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdDefaultErrorContext_1();

	public delegate void SwigDelegateOdDefaultErrorContext_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDefaultErrorContext_3();

	public delegate int SwigDelegateOdDefaultErrorContext_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDefaultErrorContext_0 swigDelegate0;

	private SwigDelegateOdDefaultErrorContext_1 swigDelegate1;

	private SwigDelegateOdDefaultErrorContext_2 swigDelegate2;

	private SwigDelegateOdDefaultErrorContext_3 swigDelegate3;

	private SwigDelegateOdDefaultErrorContext_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDefaultErrorContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDefaultErrorContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDefaultErrorContext obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDefaultErrorContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDefaultErrorContext(OdResult err, OdErrorContext pPreviousError)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDefaultErrorContext__SWIG_0((int)err, OdErrorContext.getCPtr(pPreviousError)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDefaultErrorContext) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDefaultErrorContext(OdResult err)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDefaultErrorContext__SWIG_1((int)err), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDefaultErrorContext) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdResult code()
	{
		int result = (SwigDerivedClassHasMethod("code", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdDefaultErrorContext_codeSwigExplicitOdDefaultErrorContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDefaultErrorContext_code(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override string description()
	{
		string result = (SwigDerivedClassHasMethod("description", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdDefaultErrorContext_descriptionSwigExplicitOdDefaultErrorContext(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDefaultErrorContext_description(swigCPtr));
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
		if (SwigDerivedClassHasMethod("description", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("code", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcode;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDefaultErrorContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDefaultErrorContext));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoddescription()
	{
		return description();
	}

	private int SwigDirectorMethodcode()
	{
		return (int)code();
	}
}
