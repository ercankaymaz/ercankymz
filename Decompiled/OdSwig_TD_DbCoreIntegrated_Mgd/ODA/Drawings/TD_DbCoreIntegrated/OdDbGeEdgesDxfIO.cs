using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeEdgesDxfIO : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeEdgesDxfIO(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeEdgesDxfIO obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbGeEdgesDxfIO()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeEdgesDxfIO(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeLineSeg2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_outFields__SWIG_0(OdDbDxfFiler.getCPtr(pFiler), OdGeLineSeg2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeCircArc2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_outFields__SWIG_1(OdDbDxfFiler.getCPtr(pFiler), OdGeCircArc2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeEllipArc2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_outFields__SWIG_2(OdDbDxfFiler.getCPtr(pFiler), OdGeEllipArc2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeNurbCurve2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_outFields__SWIG_3(OdDbDxfFiler.getCPtr(pFiler), OdGeNurbCurve2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void outFields(OdDbDxfFiler pFiler, OdGeSegmentChain2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_outFields__SWIG_4(OdDbDxfFiler.getCPtr(pFiler), OdGeSegmentChain2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void inFields(OdDbDxfFiler pFiler, OdGeLineSeg2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_inFields__SWIG_0(OdDbDxfFiler.getCPtr(pFiler), OdGeLineSeg2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void inFields(OdDbDxfFiler pFiler, OdGeCircArc2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_inFields__SWIG_1(OdDbDxfFiler.getCPtr(pFiler), OdGeCircArc2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void inFields(OdDbDxfFiler pFiler, OdGeEllipArc2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_inFields__SWIG_2(OdDbDxfFiler.getCPtr(pFiler), OdGeEllipArc2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void inFields(OdDbDxfFiler pFiler, OdGeNurbCurve2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_inFields__SWIG_3(OdDbDxfFiler.getCPtr(pFiler), OdGeNurbCurve2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void inFields(OdDbDxfFiler pFiler, OdGeSegmentChain2d object_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeEdgesDxfIO_inFields__SWIG_4(OdDbDxfFiler.getCPtr(pFiler), OdGeSegmentChain2d.getCPtr(object_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbGeEdgesDxfIO()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGeEdgesDxfIO(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
