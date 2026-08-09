using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeMatrix3dStack : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeMatrix3dStack(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeMatrix3dStack obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeMatrix3dStack()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeMatrix3dStack(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeMatrix3dStack()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeMatrix3dStack(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void push(OdGeMatrix3d inVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_push__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(inVal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d push()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_push__SWIG_2(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void pop(OdGeMatrix3d outVal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_pop__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(outVal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d top()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_top__SWIG_0(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void pop()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_pop__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d beforeTop()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_beforeTop(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3dStack_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
