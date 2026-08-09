using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerExtension : IDisposable
{
	public delegate int SwigDelegateOdGsFilerExtension_0();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGsFilerExtension_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerExtension(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerExtension obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsFilerExtension()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtension(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdGsFilerExtension_Type type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtension_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerExtension_Type)result;
	}

	public OdGsFilerExtension()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerExtension(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFilerExtension) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("type", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodtype;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtension_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFilerExtension));
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}
}
