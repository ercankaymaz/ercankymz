using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsDCPoint : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public int x
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_x_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_x_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int y
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_y_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_y_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsDCPoint(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsDCPoint obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsDCPoint()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsDCPoint(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsDCPoint()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCPoint__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCPoint(int xx, int yy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCPoint__SWIG_1(xx, yy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCPoint(OdGsDCPoint_MaxFlag arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCPoint__SWIG_2((int)arg0), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCPoint(OdGsDCPoint_MinFlag arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCPoint__SWIG_3((int)arg0), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCPoint(OdGsDCPoint other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCPoint__SWIG_4(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Assign(OdGsDCPoint_MaxFlag arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_Assign__SWIG_0(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Assign(OdGsDCPoint_MinFlag arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_Assign__SWIG_1(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCPoint Assign(OdGsDCPoint dcPoint)
	{
		OdGsDCPoint result = new OdGsDCPoint(TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_Assign__SWIG_2(swigCPtr, getCPtr(dcPoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGsDCPoint dcPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_IsEqual(swigCPtr, getCPtr(dcPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGsDCPoint dcPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_IsNotEqual(swigCPtr, getCPtr(dcPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int GetItem(uint i)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCPoint_GetItem(swigCPtr, i);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
