using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeEqualStepHatchStrokes : OdGeHatchStrokes
{
	public delegate double SwigDelegateOdGeEqualStepHatchStrokes_0(double prevEvent);

	public delegate double SwigDelegateOdGeEqualStepHatchStrokes_1(double prevEvent);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGeEqualStepHatchStrokes_0 swigDelegate0;

	private SwigDelegateOdGeEqualStepHatchStrokes_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(double) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeEqualStepHatchStrokes(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeEqualStepHatchStrokes_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeEqualStepHatchStrokes obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeEqualStepHatchStrokes(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGeEqualStepHatchStrokes(double d0, double step)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEqualStepHatchStrokes(d0, step), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGeEqualStepHatchStrokes) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override double getNearestStroke(double prevEvent)
	{
		double result = (SwigDerivedClassHasMethod("getNearestStroke", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGeEqualStepHatchStrokes_getNearestStrokeSwigExplicitOdGeEqualStepHatchStrokes(swigCPtr, prevEvent) : TD_RootIntegrated_GlobalsPINVOKE.OdGeEqualStepHatchStrokes_getNearestStroke(swigCPtr, prevEvent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double getNextStroke(double prevEvent)
	{
		double result = (SwigDerivedClassHasMethod("getNextStroke", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGeEqualStepHatchStrokes_getNextStrokeSwigExplicitOdGeEqualStepHatchStrokes(swigCPtr, prevEvent) : TD_RootIntegrated_GlobalsPINVOKE.OdGeEqualStepHatchStrokes_getNextStroke(swigCPtr, prevEvent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getNearestStroke", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetNearestStroke;
		}
		if (SwigDerivedClassHasMethod("getNextStroke", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetNextStroke;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEqualStepHatchStrokes_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGeEqualStepHatchStrokes));
	}

	private double SwigDirectorMethodgetNearestStroke(double prevEvent)
	{
		return getNearestStroke(prevEvent);
	}

	private double SwigDirectorMethodgetNextStroke(double prevEvent)
	{
		return getNextStroke(prevEvent);
	}
}
