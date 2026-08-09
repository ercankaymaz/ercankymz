using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdGeDxfIO : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeDxfIO(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeDxfIO obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeDxfIO()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdGeDxfIO(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeMatrix3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_outFields__SWIG_0(OdDbDxfFiler.getCPtr(pFiler), OdGeMatrix3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeLine3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_outFields__SWIG_1(OdDbDxfFiler.getCPtr(pFiler), OdGeLine3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeLineSeg3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_outFields__SWIG_2(OdDbDxfFiler.getCPtr(pFiler), OdGeLineSeg3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeCircArc3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_outFields__SWIG_3(OdDbDxfFiler.getCPtr(pFiler), OdGeCircArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeEllipArc3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_outFields__SWIG_4(OdDbDxfFiler.getCPtr(pFiler), OdGeEllipArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeNurbCurve3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_outFields__SWIG_5(OdDbDxfFiler.getCPtr(pFiler), OdGeNurbCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeCompositeCurve3d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_outFields__SWIG_6(OdDbDxfFiler.getCPtr(pFiler), OdGeCompositeCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult inFields(OdDbDxfFiler pFiler, OdGeMatrix3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_inFields__SWIG_0(OdDbDxfFiler.getCPtr(pFiler), OdGeMatrix3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDxfFiler pFiler, OdGeLine3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_inFields__SWIG_1(OdDbDxfFiler.getCPtr(pFiler), OdGeLine3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDxfFiler pFiler, OdGeLineSeg3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_inFields__SWIG_2(OdDbDxfFiler.getCPtr(pFiler), OdGeLineSeg3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDxfFiler pFiler, OdGeCircArc3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_inFields__SWIG_3(OdDbDxfFiler.getCPtr(pFiler), OdGeCircArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDxfFiler pFiler, OdGeEllipArc3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_inFields__SWIG_4(OdDbDxfFiler.getCPtr(pFiler), OdGeEllipArc3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDxfFiler pFiler, OdGeNurbCurve3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_inFields__SWIG_5(OdDbDxfFiler.getCPtr(pFiler), OdGeNurbCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult inFields(OdDbDxfFiler pFiler, OdGeCompositeCurve3d object_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_inFields__SWIG_6(OdDbDxfFiler.getCPtr(pFiler), OdGeCompositeCurve3d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult loadGeCurve3d(OdDbDxfFiler pFiler, ref OdGeCurve3d curve)
	{
		IntPtr jarg = ((curve == null) ? IntPtr.Zero : OdGeCurve3d.getCPtr(curve).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_loadGeCurve3d(OdDbDxfFiler.getCPtr(pFiler), ref jarg);
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

	public static void writeGeCurve3d(OdDbDxfFiler pFiler, OdGeCurve3d curve)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGeDxfIO_writeGeCurve3d(OdDbDxfFiler.getCPtr(pFiler), OdGeCurve3d.getCPtr(curve));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeDxfIO()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdGeDxfIO(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
