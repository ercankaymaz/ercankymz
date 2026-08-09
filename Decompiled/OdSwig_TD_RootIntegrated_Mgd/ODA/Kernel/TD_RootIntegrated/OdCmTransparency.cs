using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdCmTransparency : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdCmTransparency(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdCmTransparency obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdCmTransparency()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdCmTransparency(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdCmTransparency()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmTransparency__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmTransparency(OdCmTransparency_transparencyMethod method)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmTransparency__SWIG_1((int)method), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmTransparency(byte alpha)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmTransparency__SWIG_2(alpha), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmTransparency(double alphaPercent)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmTransparency__SWIG_3(alphaPercent), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdCmTransparency transparency)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_IsEqual(swigCPtr, getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdCmTransparency transparency)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_IsNotEqual(swigCPtr, getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlpha(byte alpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_setAlpha(swigCPtr, alpha);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public byte alpha()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_alpha(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlphaPercent(double alphaPercent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_setAlphaPercent(swigCPtr, alphaPercent);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double alphaPercent()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_alphaPercent(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmTransparency_transparencyMethod method()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_method(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCmTransparency_transparencyMethod)result;
	}

	public void setMethod(OdCmTransparency_transparencyMethod method)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_setMethod(swigCPtr, (int)method);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isByAlpha()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_isByAlpha(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByBlock()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_isByBlock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByLayer()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_isByLayer(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInvalid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_isInvalid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClear()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_isClear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSolid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_isSolid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint serializeOut()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_serializeOut(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void serializeIn(uint transparency)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmTransparency_serializeIn(swigCPtr, transparency);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
