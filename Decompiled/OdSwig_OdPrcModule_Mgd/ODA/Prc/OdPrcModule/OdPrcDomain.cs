using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcDomain : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static double kLowerInfinite
	{
		get
		{
			double result = OdPrcModule_GlobalsPINVOKE.OdPrcDomain_kLowerInfinite_get();
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static double kUpperInfinite
	{
		get
		{
			double result = OdPrcModule_GlobalsPINVOKE.OdPrcDomain_kUpperInfinite_get();
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdPrcDomain kInfinite
	{
		get
		{
			IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcDomain_kInfinite_get();
			OdPrcDomain result = ((intPtr == IntPtr.Zero) ? null : new OdPrcDomain(intPtr, cMemoryOwn: false));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcDomain(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcDomain obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcDomain()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcDomain(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcDomain()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcDomain(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcDomain_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcDomain_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d minUV()
	{
		OdGePoint2d result = new OdGePoint2d(OdPrcModule_GlobalsPINVOKE.OdPrcDomain_minUV(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d maxUV()
	{
		OdGePoint2d result = new OdGePoint2d(OdPrcModule_GlobalsPINVOKE.OdPrcDomain_maxUV(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult set(OdGePoint2d minUV, OdGePoint2d maxUV)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcDomain_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(minUV), OdGePoint2d.getCPtr(maxUV));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval intervalU, OdGeInterval intervalV)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcDomain_set__SWIG_1(swigCPtr, OdGeInterval.getCPtr(intervalU), OdGeInterval.getCPtr(intervalV));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double minU, double minV, double maxU, double maxV)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcDomain_set__SWIG_2(swigCPtr, minU, minV, maxU, maxV);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}
