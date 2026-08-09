using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdExPrcHostAppProgressMeter : OdDbHostAppProgressMeter
{
	public delegate void SwigDelegateOdExPrcHostAppProgressMeter_0([MarshalAs(UnmanagedType.LPWStr)] string displayString);

	public delegate void SwigDelegateOdExPrcHostAppProgressMeter_1();

	public delegate void SwigDelegateOdExPrcHostAppProgressMeter_2();

	public delegate void SwigDelegateOdExPrcHostAppProgressMeter_3();

	public delegate void SwigDelegateOdExPrcHostAppProgressMeter_4(int max);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdExPrcHostAppProgressMeter_0 swigDelegate0;

	private SwigDelegateOdExPrcHostAppProgressMeter_1 swigDelegate1;

	private SwigDelegateOdExPrcHostAppProgressMeter_2 swigDelegate2;

	private SwigDelegateOdExPrcHostAppProgressMeter_3 swigDelegate3;

	private SwigDelegateOdExPrcHostAppProgressMeter_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(int) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdExPrcHostAppProgressMeter(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdExPrcHostAppProgressMeter obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdExPrcHostAppProgressMeter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdExPrcHostAppProgressMeter()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdExPrcHostAppProgressMeter(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdExPrcHostAppProgressMeter) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override void start(string displayString)
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_startSwigExplicitOdExPrcHostAppProgressMeter__SWIG_0(swigCPtr, displayString);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_start__SWIG_0(swigCPtr, displayString);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void start()
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes1))
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_startSwigExplicitOdExPrcHostAppProgressMeter__SWIG_1(swigCPtr);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_start__SWIG_1(swigCPtr);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void stop()
	{
		if (SwigDerivedClassHasMethod("stop", swigMethodTypes2))
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_stopSwigExplicitOdExPrcHostAppProgressMeter(swigCPtr);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_stop(swigCPtr);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void meterProgress()
	{
		if (SwigDerivedClassHasMethod("meterProgress", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_meterProgressSwigExplicitOdExPrcHostAppProgressMeter(swigCPtr);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_meterProgress(swigCPtr);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setLimit(int max)
	{
		if (SwigDerivedClassHasMethod("setLimit", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_setLimitSwigExplicitOdExPrcHostAppProgressMeter(swigCPtr, max);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_setLimit(swigCPtr, max);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void disableOutput(bool disable)
	{
		OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_disableOutput(swigCPtr, disable);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrefix(string prefix)
	{
		OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_setPrefix(swigCPtr, prefix);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodstart__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodstart__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("stop", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodstop;
		}
		if (SwigDerivedClassHasMethod("meterProgress", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodmeterProgress;
		}
		if (SwigDerivedClassHasMethod("setLimit", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetLimit;
		}
		OdPrcModule_GlobalsPINVOKE.OdExPrcHostAppProgressMeter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdExPrcHostAppProgressMeter));
	}

	private void SwigDirectorMethodstart__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string displayString)
	{
		try
		{
			start(displayString);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodstart__SWIG_1()
	{
		try
		{
			start();
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodstop()
	{
		try
		{
			stop();
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodmeterProgress()
	{
		try
		{
			meterProgress();
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetLimit(int max)
	{
		try
		{
			setLimit(max);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
