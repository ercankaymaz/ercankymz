using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdGeDwgIO : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeDwgIO(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeDwgIO obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeDwgIO()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdGeDwgIO(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdResult inFields(OdDbDwgFiler pFiler, OdGeMatrix3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_inFields__SWIG_0(OdDbDwgFiler.getCPtr(pFiler), OdGeMatrix3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDwgFiler pFiler, OdGeLine3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_inFields__SWIG_1(OdDbDwgFiler.getCPtr(pFiler), OdGeLine3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDwgFiler pFiler, OdGeLineSeg3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_inFields__SWIG_2(OdDbDwgFiler.getCPtr(pFiler), OdGeLineSeg3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDwgFiler pFiler, OdGeCircArc3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_inFields__SWIG_3(OdDbDwgFiler.getCPtr(pFiler), OdGeCircArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDwgFiler pFiler, OdGeEllipArc3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_inFields__SWIG_4(OdDbDwgFiler.getCPtr(pFiler), OdGeEllipArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDwgFiler pFiler, OdGeCompositeCurve3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_inFields__SWIG_5(OdDbDwgFiler.getCPtr(pFiler), OdGeCompositeCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDwgFiler pFiler, OdGeNurbCurve3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_inFields__SWIG_6(OdDbDwgFiler.getCPtr(pFiler), OdGeNurbCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static void outFields(OdDbDwgFiler pFiler, OdGeMatrix3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_outFields__SWIG_0(OdDbDwgFiler.getCPtr(pFiler), OdGeMatrix3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDwgFiler pFiler, OdGeLine3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_outFields__SWIG_1(OdDbDwgFiler.getCPtr(pFiler), OdGeLine3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDwgFiler pFiler, OdGeLineSeg3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_outFields__SWIG_2(OdDbDwgFiler.getCPtr(pFiler), OdGeLineSeg3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDwgFiler pFiler, OdGeCircArc3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_outFields__SWIG_3(OdDbDwgFiler.getCPtr(pFiler), OdGeCircArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDwgFiler pFiler, OdGeEllipArc3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_outFields__SWIG_4(OdDbDwgFiler.getCPtr(pFiler), OdGeEllipArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDwgFiler pFiler, OdGeNurbCurve3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_outFields__SWIG_5(OdDbDwgFiler.getCPtr(pFiler), OdGeNurbCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDwgFiler pFiler, OdGeCompositeCurve3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_outFields__SWIG_6(OdDbDwgFiler.getCPtr(pFiler), OdGeCompositeCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult loadGeCurve3d(OdDbDwgFiler filer, ref OdGeCurve3d curve)
	{
		IntPtr jarg = ((curve == null) ? IntPtr.Zero : OdGeCurve3d.getCPtr(curve).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_loadGeCurve3d(OdDbDwgFiler.getCPtr(filer), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				curve = null;
			}
			else if (jarg != intPtr)
			{
				curve = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdGeCurve3d>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public static void writeGeCurve3d(OdDbDwgFiler pFiler, OdGeCurve3d curve)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDwgIO_writeGeCurve3d(OdDbDwgFiler.getCPtr(pFiler), OdGeCurve3d.getCPtr(curve));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeDwgIO()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdGeDwgIO(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
