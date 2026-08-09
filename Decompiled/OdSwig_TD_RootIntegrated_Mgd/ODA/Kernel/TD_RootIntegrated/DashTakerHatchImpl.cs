using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class DashTakerHatchImpl : OdGeHatchDashTaker
{
	public delegate bool SwigDelegateDashTakerHatchImpl_0(IntPtr start, IntPtr end);

	public delegate void SwigDelegateDashTakerHatchImpl_1(IntPtr pShift);

	public delegate void SwigDelegateDashTakerHatchImpl_2(bool value);

	public delegate bool SwigDelegateDashTakerHatchImpl_3();

	public delegate void SwigDelegateDashTakerHatchImpl_4(double deviation);

	public delegate void SwigDelegateDashTakerHatchImpl_5(double dSmallerPeriod);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateDashTakerHatchImpl_0 swigDelegate0;

	private SwigDelegateDashTakerHatchImpl_1 swigDelegate1;

	private SwigDelegateDashTakerHatchImpl_2 swigDelegate2;

	private SwigDelegateDashTakerHatchImpl_3 swigDelegate3;

	private SwigDelegateDashTakerHatchImpl_4 swigDelegate4;

	private SwigDelegateDashTakerHatchImpl_5 swigDelegate5;

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
	public DashTakerHatchImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(DashTakerHatchImpl obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_DashTakerHatchImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public DashTakerHatchImpl(uint maxHatchDensity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_DashTakerHatchImpl(maxHatchDensity), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(DashTakerHatchImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override void setDashPeriod(bool value)
	{
		if (SwigDerivedClassHasMethod("setDashPeriod", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setDashPeriodSwigExplicitDashTakerHatchImpl(swigCPtr, value);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setDashPeriod(swigCPtr, value);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setShift(OdGeVector2d pShift)
	{
		if (SwigDerivedClassHasMethod("setShift", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setShiftSwigExplicitDashTakerHatchImpl(swigCPtr, OdGeVector2d.getCPtr(pShift).Handle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setShift(swigCPtr, OdGeVector2d.getCPtr(pShift).Handle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool hasCache()
	{
		bool result = (SwigDerivedClassHasMethod("hasCache", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_hasCacheSwigExplicitDashTakerHatchImpl(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_hasCache(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSmallerDashPeriod(double dSmallerPeriod)
	{
		if (SwigDerivedClassHasMethod("setSmallerDashPeriod", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setSmallerDashPeriodSwigExplicitDashTakerHatchImpl(swigCPtr, dSmallerPeriod);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setSmallerDashPeriod(swigCPtr, dSmallerPeriod);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool dash(OdGePoint2d start, OdGePoint2d end)
	{
		bool result = (SwigDerivedClassHasMethod("dash", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_dashSwigExplicitDashTakerHatchImpl(swigCPtr, OdGePoint2d.getCPtr(start), OdGePoint2d.getCPtr(end)) : TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_dash(swigCPtr, OdGePoint2d.getCPtr(start), OdGePoint2d.getCPtr(end)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setDeviation(double deviation)
	{
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setDeviationSwigExplicitDashTakerHatchImpl(swigCPtr, deviation);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_setDeviation(swigCPtr, deviation);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector2d shift()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_shift(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2dArray getStartPoints()
	{
		OdGePoint2dArray result = new OdGePoint2dArray(TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_getStartPoints(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2dArray getEndPoints()
	{
		OdGePoint2dArray result = new OdGePoint2dArray(TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_getEndPoints(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		TD_RootIntegrated_GlobalsPINVOKE.DashTakerHatchImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(DashTakerHatchImpl));
	}

	private bool SwigDirectorMethoddash(IntPtr start, IntPtr end)
	{
		return dash(new OdGePoint2d(start, cMemoryOwn: false), new OdGePoint2d(end, cMemoryOwn: false));
	}

	private void SwigDirectorMethodsetShift(IntPtr pShift)
	{
		try
		{
			setShift(new OdGeVector2d(pShift, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetDashPeriod(bool value)
	{
		try
		{
			setDashPeriod(value);
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

	private void SwigDirectorMethodsetDeviation(double deviation)
	{
		try
		{
			setDeviation(deviation);
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

	private void SwigDirectorMethodsetSmallerDashPeriod(double dSmallerPeriod)
	{
		try
		{
			setSmallerDashPeriod(dSmallerPeriod);
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
