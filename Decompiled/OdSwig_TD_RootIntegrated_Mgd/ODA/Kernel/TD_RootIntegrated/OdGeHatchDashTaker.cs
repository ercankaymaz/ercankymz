using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeHatchDashTaker : IDisposable
{
	public delegate bool SwigDelegateOdGeHatchDashTaker_0(IntPtr start, IntPtr end);

	public delegate void SwigDelegateOdGeHatchDashTaker_1(IntPtr arg0);

	public delegate void SwigDelegateOdGeHatchDashTaker_2(bool arg0);

	public delegate bool SwigDelegateOdGeHatchDashTaker_3();

	public delegate void SwigDelegateOdGeHatchDashTaker_4(double arg0);

	public delegate void SwigDelegateOdGeHatchDashTaker_5(double arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGeHatchDashTaker_0 swigDelegate0;

	private SwigDelegateOdGeHatchDashTaker_1 swigDelegate1;

	private SwigDelegateOdGeHatchDashTaker_2 swigDelegate2;

	private SwigDelegateOdGeHatchDashTaker_3 swigDelegate3;

	private SwigDelegateOdGeHatchDashTaker_4 swigDelegate4;

	private SwigDelegateOdGeHatchDashTaker_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGeVector2d) };

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeHatchDashTaker(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeHatchDashTaker obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeHatchDashTaker()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeHatchDashTaker(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool dash(OdGePoint2d start, OdGePoint2d end)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_dash(swigCPtr, OdGePoint2d.getCPtr(start), OdGePoint2d.getCPtr(end));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShift(OdGeVector2d arg0)
	{
		if (SwigDerivedClassHasMethod("setShift", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setShiftSwigExplicitOdGeHatchDashTaker(swigCPtr, OdGeVector2d.getCPtr(arg0).Handle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setShift(swigCPtr, OdGeVector2d.getCPtr(arg0).Handle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDashPeriod(bool arg0)
	{
		if (SwigDerivedClassHasMethod("setDashPeriod", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setDashPeriodSwigExplicitOdGeHatchDashTaker(swigCPtr, arg0);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setDashPeriod(swigCPtr, arg0);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasCache()
	{
		bool result = (SwigDerivedClassHasMethod("hasCache", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_hasCacheSwigExplicitOdGeHatchDashTaker(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_hasCache(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDeviation(double arg0)
	{
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setDeviationSwigExplicitOdGeHatchDashTaker(swigCPtr, arg0);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setDeviation(swigCPtr, arg0);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSmallerDashPeriod(double arg0)
	{
		if (SwigDerivedClassHasMethod("setSmallerDashPeriod", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setSmallerDashPeriodSwigExplicitOdGeHatchDashTaker(swigCPtr, arg0);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_setSmallerDashPeriod(swigCPtr, arg0);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeHatchDashTaker()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeHatchDashTaker(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGeHatchDashTaker) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("dash", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethoddash;
		}
		if (SwigDerivedClassHasMethod("setShift", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetShift;
		}
		if (SwigDerivedClassHasMethod("setDashPeriod", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodsetDashPeriod;
		}
		if (SwigDerivedClassHasMethod("hasCache", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodhasCache;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetDeviation;
		}
		if (SwigDerivedClassHasMethod("setSmallerDashPeriod", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetSmallerDashPeriod;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchDashTaker_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGeHatchDashTaker));
	}

	private bool SwigDirectorMethoddash(IntPtr start, IntPtr end)
	{
		return dash(new OdGePoint2d(start, cMemoryOwn: false), new OdGePoint2d(end, cMemoryOwn: false));
	}

	private void SwigDirectorMethodsetShift(IntPtr arg0)
	{
		try
		{
			setShift(new OdGeVector2d(arg0, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetDashPeriod(bool arg0)
	{
		try
		{
			setDashPeriod(arg0);
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

	private bool SwigDirectorMethodhasCache()
	{
		return hasCache();
	}

	private void SwigDirectorMethodsetDeviation(double arg0)
	{
		try
		{
			setDeviation(arg0);
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

	private void SwigDirectorMethodsetSmallerDashPeriod(double arg0)
	{
		try
		{
			setSmallerDashPeriod(arg0);
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
