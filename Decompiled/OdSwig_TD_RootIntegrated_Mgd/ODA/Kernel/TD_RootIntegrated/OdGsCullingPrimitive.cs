using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCullingPrimitive : IDisposable
{
	public delegate int SwigDelegateOdGsCullingPrimitive_0();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGsCullingPrimitive_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCullingPrimitive(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCullingPrimitive obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsCullingPrimitive()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCullingPrimitive(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsCullingPrimitive()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingPrimitive(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsCullingPrimitive) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual OdGsCullingPrimitive_PrimitiveType primitiveType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingPrimitive_primitiveType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsCullingPrimitive_PrimitiveType)result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("primitiveType", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodprimitiveType;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingPrimitive_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsCullingPrimitive));
	}

	private int SwigDirectorMethodprimitiveType()
	{
		return (int)primitiveType();
	}
}
