using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeHatchStrokes : IDisposable
{
	public delegate double SwigDelegateOdGeHatchStrokes_0(double prevEvent);

	public delegate double SwigDelegateOdGeHatchStrokes_1(double prevEvent);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGeHatchStrokes_0 swigDelegate0;

	private SwigDelegateOdGeHatchStrokes_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(double) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeHatchStrokes(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeHatchStrokes obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeHatchStrokes()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeHatchStrokes(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual double getNearestStroke(double prevEvent)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchStrokes_getNearestStroke(swigCPtr, prevEvent);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getNextStroke(double prevEvent)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchStrokes_getNextStroke(swigCPtr, prevEvent);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeHatchStrokes()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeHatchStrokes(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGeHatchStrokes) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGeHatchStrokes_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGeHatchStrokes));
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
