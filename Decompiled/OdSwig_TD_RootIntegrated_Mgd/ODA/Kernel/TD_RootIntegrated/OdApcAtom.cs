using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdApcAtom : OdRxObject
{
	public delegate IntPtr SwigDelegateOdApcAtom_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdApcAtom_1();

	public delegate void SwigDelegateOdApcAtom_2(IntPtr pSource);

	public delegate void SwigDelegateOdApcAtom_3(IntPtr arg0);

	public delegate void SwigDelegateOdApcAtom_4(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdApcAtom_0 swigDelegate0;

	private SwigDelegateOdApcAtom_1 swigDelegate1;

	private SwigDelegateOdApcAtom_2 swigDelegate2;

	private SwigDelegateOdApcAtom_3 swigDelegate3;

	private SwigDelegateOdApcAtom_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(IntPtr) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdApcAtom(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdApcAtom obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdApcAtom(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdApcAtom()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdApcAtom(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public virtual void apcEntryPoint(OdRxObject arg0)
	{
		if (SwigDerivedClassHasMethod("apcEntryPoint", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_apcEntryPointSwigExplicitOdApcAtom__SWIG_0(swigCPtr, OdRxObject.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_apcEntryPoint__SWIG_0(swigCPtr, OdRxObject.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void apcEntryPoint(IntPtr arg0)
	{
		if (SwigDerivedClassHasMethod("apcEntryPoint", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_apcEntryPointSwigExplicitOdApcAtom__SWIG_1(swigCPtr, arg0);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_apcEntryPoint__SWIG_1(swigCPtr, arg0);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdApcAtom createObject()
	{
		OdApcAtom rXObject = Helpers.GetRXObject<OdApcAtom>(TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("apcEntryPoint", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodapcEntryPoint__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("apcEntryPoint", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodapcEntryPoint__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdApcAtom_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdApcAtom));
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

	private void SwigDirectorMethodapcEntryPoint__SWIG_0(IntPtr arg0)
	{
		try
		{
			apcEntryPoint(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodapcEntryPoint__SWIG_1(IntPtr arg0)
	{
		try
		{
			apcEntryPoint(arg0);
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
}
