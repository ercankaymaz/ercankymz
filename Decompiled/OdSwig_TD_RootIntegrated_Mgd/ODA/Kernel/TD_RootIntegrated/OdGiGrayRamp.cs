using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGrayRamp : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGrayRamp(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGrayRamp obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiGrayRamp()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGrayRamp(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGiGrayRamp createDynamic(int nGridDivs, float fIntensity, int nBaseOffset)
	{
		OdGiGrayRamp rXObject = Helpers.GetRXObject<OdGiGrayRamp>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_createDynamic__SWIG_0(nGridDivs, fIntensity, nBaseOffset), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiGrayRamp createDynamic(int nGridDivs, float fIntensity)
	{
		OdGiGrayRamp rXObject = Helpers.GetRXObject<OdGiGrayRamp>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_createDynamic__SWIG_1(nGridDivs, fIntensity), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiGrayRamp createDynamic(int nGridDivs)
	{
		OdGiGrayRamp rXObject = Helpers.GetRXObject<OdGiGrayRamp>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_createDynamic__SWIG_2(nGridDivs), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiGrayRamp createDynamic()
	{
		OdGiGrayRamp rXObject = Helpers.GetRXObject<OdGiGrayRamp>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_createDynamic__SWIG_3(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiGrayRamp cloneIfNeed()
	{
		OdGiGrayRamp rXObject = Helpers.GetRXObject<OdGiGrayRamp>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_cloneIfNeed(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public int baseOffset()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_baseOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int gridDivisions()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_gridDivisions(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public float intensity()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_intensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int dimension()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_dimension(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint color(int nColor)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_color(swigCPtr, nColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int closestMatch(uint cref)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_closestMatch(swigCPtr, cref);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGrayRamp_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
