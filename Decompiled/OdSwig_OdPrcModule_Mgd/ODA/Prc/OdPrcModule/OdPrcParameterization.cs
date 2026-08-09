using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcParameterization : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcParameterization(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcParameterization obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcParameterization()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcParameterization(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcParameterization()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(OdPrcInterval interval, double coeff_a, double coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_1(OdPrcInterval.getCPtr(interval), coeff_a, coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(OdPrcInterval interval, double coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_2(OdPrcInterval.getCPtr(interval), coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(OdPrcInterval interval)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_3(OdPrcInterval.getCPtr(interval)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(OdGeInterval interval, double coeff_a, double coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_4(OdGeInterval.getCPtr(interval), coeff_a, coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(OdGeInterval interval, double coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_5(OdGeInterval.getCPtr(interval), coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(OdGeInterval interval)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_6(OdGeInterval.getCPtr(interval)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(double min, double max, double coeff_a, double coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_7(min, max, coeff_a, coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(double min, double max, double coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_8(min, max, coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcParameterization(double min, double max)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcParameterization__SWIG_9(min, max), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcInterval getImplicitInterval()
	{
		OdPrcInterval result = new OdPrcInterval(OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_getImplicitInterval(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getImplicitParam(double dParam)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_getImplicitParam(swigCPtr, dParam);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getRealParam(double dParam)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_getRealParam(swigCPtr, dParam);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double coeffA()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_coeffA(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double coeffB()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_coeffB(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcInterval interval()
	{
		OdPrcInterval result = new OdPrcInterval(OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_interval(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult set(OdPrcInterval interval, double coeff_a, double coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_0(swigCPtr, OdPrcInterval.getCPtr(interval), coeff_a, coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdPrcInterval interval, double coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_1(swigCPtr, OdPrcInterval.getCPtr(interval), coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdPrcInterval interval)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_2(swigCPtr, OdPrcInterval.getCPtr(interval));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval interval, double coeff_a, double coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_3(swigCPtr, OdGeInterval.getCPtr(interval), coeff_a, coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval interval, double coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_4(swigCPtr, OdGeInterval.getCPtr(interval), coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval interval)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_5(swigCPtr, OdGeInterval.getCPtr(interval));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double min, double max, double coeff_a, double coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_6(swigCPtr, min, max, coeff_a, coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double min, double max, double coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_7(swigCPtr, min, max, coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double min, double max)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcParameterization_set__SWIG_8(swigCPtr, min, max);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}
