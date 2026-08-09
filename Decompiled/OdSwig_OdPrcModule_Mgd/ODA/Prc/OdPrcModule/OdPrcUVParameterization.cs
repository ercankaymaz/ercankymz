using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcUVParameterization : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcUVParameterization(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcUVParameterization obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcUVParameterization()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcUVParameterization(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcUVParameterization()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b, double v_coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_1(OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b, v_coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_2(OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a, double v_coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_3(OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a, v_coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_4(OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdPrcDomain uv_domain, bool swap_uv)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_5(OdPrcDomain.getCPtr(uv_domain), swap_uv), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdPrcDomain uv_domain)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_6(OdPrcDomain.getCPtr(uv_domain)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b, double v_coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_7(OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b, v_coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_8(OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a, double v_coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_9(OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a, v_coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_10(OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_11(OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(OdGeInterval ivU, OdGeInterval ivV)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_12(OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b, double v_coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_13(minU, maxU, minV, maxV, swap_uv, u_coeff_a, v_coeff_a, u_coeff_b, v_coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_14(minU, maxU, minV, maxV, swap_uv, u_coeff_a, v_coeff_a, u_coeff_b), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a, double v_coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_15(minU, maxU, minV, maxV, swap_uv, u_coeff_a, v_coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_16(minU, maxU, minV, maxV, swap_uv, u_coeff_a), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(double minU, double maxU, double minV, double maxV, bool swap_uv)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_17(minU, maxU, minV, maxV, swap_uv), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUVParameterization(double minU, double maxU, double minV, double maxV)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUVParameterization__SWIG_18(minU, maxU, minV, maxV), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcDomain uvDomain()
	{
		OdPrcDomain result = new OdPrcDomain(OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_uvDomain(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool swapUV()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_swapUV(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double uCoeffA()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_uCoeffA(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double vCoeffA()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_vCoeffA(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double uCoeffB()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_uCoeffB(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double vCoeffB()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_vCoeffB(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult set(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b, double v_coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_0(swigCPtr, OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b, v_coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_1(swigCPtr, OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a, double v_coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_2(swigCPtr, OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a, v_coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdPrcDomain uv_domain, bool swap_uv, double u_coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_3(swigCPtr, OdPrcDomain.getCPtr(uv_domain), swap_uv, u_coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdPrcDomain uv_domain, bool swap_uv)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_4(swigCPtr, OdPrcDomain.getCPtr(uv_domain), swap_uv);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdPrcDomain uv_domain)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_5(swigCPtr, OdPrcDomain.getCPtr(uv_domain));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b, double v_coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_6(swigCPtr, OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b, v_coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_7(swigCPtr, OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a, v_coeff_a, u_coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a, double v_coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_8(swigCPtr, OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a, v_coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv, double u_coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_9(swigCPtr, OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv, u_coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval ivU, OdGeInterval ivV, bool swap_uv)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_10(swigCPtr, OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV), swap_uv);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdGeInterval ivU, OdGeInterval ivV)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_11(swigCPtr, OdGeInterval.getCPtr(ivU), OdGeInterval.getCPtr(ivV));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b, double v_coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_12(swigCPtr, minU, maxU, minV, maxV, swap_uv, u_coeff_a, v_coeff_a, u_coeff_b, v_coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a, double v_coeff_a, double u_coeff_b)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_13(swigCPtr, minU, maxU, minV, maxV, swap_uv, u_coeff_a, v_coeff_a, u_coeff_b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a, double v_coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_14(swigCPtr, minU, maxU, minV, maxV, swap_uv, u_coeff_a, v_coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double minU, double maxU, double minV, double maxV, bool swap_uv, double u_coeff_a)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_15(swigCPtr, minU, maxU, minV, maxV, swap_uv, u_coeff_a);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double minU, double maxU, double minV, double maxV, bool swap_uv)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_16(swigCPtr, minU, maxU, minV, maxV, swap_uv);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(double minU, double maxU, double minV, double maxV)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_set__SWIG_17(swigCPtr, minU, maxU, minV, maxV);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public double getImplicitUParam(OdGePoint2d param)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_getImplicitUParam(swigCPtr, OdGePoint2d.getCPtr(param));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getImplicitVParam(OdGePoint2d param)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_getImplicitVParam(swigCPtr, OdGePoint2d.getCPtr(param));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getImplicitDomain(out double startU, out double startV, out double endU, out double endV)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_getImplicitDomain__SWIG_0(swigCPtr, out startU, out startV, out endU, out endV);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getImplicitDomain(OdPrcDomain domain)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_getImplicitDomain__SWIG_1(swigCPtr, OdPrcDomain.getCPtr(domain));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getRealUParam(OdGePoint2d implicitParam)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_getRealUParam(swigCPtr, OdGePoint2d.getCPtr(implicitParam));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getRealVParam(OdGePoint2d implicitParam)
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_getRealVParam(swigCPtr, OdGePoint2d.getCPtr(implicitParam));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d getRealParam(OdGePoint2d implicitParam)
	{
		OdGePoint2d result = new OdGePoint2d(OdPrcModule_GlobalsPINVOKE.OdPrcUVParameterization_getRealParam(swigCPtr, OdGePoint2d.getCPtr(implicitParam)), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
