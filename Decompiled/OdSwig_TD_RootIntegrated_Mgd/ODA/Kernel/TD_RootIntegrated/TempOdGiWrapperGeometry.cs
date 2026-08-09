using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TempOdGiWrapperGeometry : OdGiViewportGeometry
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TempOdGiWrapperGeometry(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TempOdGiWrapperGeometry obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_TempOdGiWrapperGeometry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual void pline(OdGiPolyline p, uint i, uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_pline(swigCPtr, OdGiPolyline.getCPtr(p), i, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGeMatrix3d getModelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_getModelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d getWorldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_getWorldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void pushModelTransform(OdGeVector3d vNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_pushModelTransform__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(vNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushModelTransform(OdGeMatrix3d xMat)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_pushModelTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(xMat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void popModelTransform()
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_popModelTransform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circle(OdGePoint3d center, double radius, OdGeVector3d normal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_circle__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circle(OdGePoint3d p1, OdGePoint3d p2, OdGePoint3d p3)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_circle__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGePoint3d.getCPtr(p3));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_circularArc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_circularArc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circularArc(OdGePoint3d start, OdGePoint3d point, OdGePoint3d end, OdGiArcType arcType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_circularArc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(start), OdGePoint3d.getCPtr(point), OdGePoint3d.getCPtr(end), (int)arcType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void circularArc(OdGePoint3d start, OdGePoint3d point, OdGePoint3d end)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_circularArc__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(start), OdGePoint3d.getCPtr(point), OdGePoint3d.getCPtr(end));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void polyline(OdGePoint3d[] nbPoints, OdGeVector3d pNormal, IntPtr lBaseSubEntMarker)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(nbPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_polyline__SWIG_0(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), lBaseSubEntMarker);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void polyline(OdGePoint3d[] nbPoints, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(nbPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_polyline__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void polyline(OdGePoint3d[] nbPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(nbPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_polyline__SWIG_2(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void polygon(OdGePoint3d[] nbPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(nbPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_polygon__SWIG_0(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void polygon(OdGePoint3d[] nbPoints, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(nbPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_polygon__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void mesh(MeshData rows)
	{
		IntPtr intPtr = Helpers.MarshalMeshData(rows);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_mesh(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void shell(ShellData nbVertex)
	{
		IntPtr intPtr = Helpers.MarshalShellData(nbVertex);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_shell(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique, string msg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_text__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique, msg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, string msg, bool raw, OdGiTextStyle pTextStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_text__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), msg, raw, OdGiTextStyle.getCPtr(pTextStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void ray(OdGePoint3d first, OdGePoint3d second)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_ray(swigCPtr, OdGePoint3d.getCPtr(first), OdGePoint3d.getCPtr(second));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void nurbs(OdGeNurbCurve3d nurbs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_nurbs(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void xline(OdGePoint3d p1, OdGePoint3d p2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_xline(swigCPtr, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ellipArc(OdGeEllipArc3d arc, OdGePoint3d[] pEndPointsOverrides, OdGiArcType arcType)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(pEndPointsOverrides);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_ellipArc__SWIG_0(swigCPtr, OdGeEllipArc3d.getCPtr(arc), intPtr, (int)arcType);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public virtual void ellipArc(OdGeEllipArc3d arc, OdGePoint3d[] pEndPointsOverrides)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(pEndPointsOverrides);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_ellipArc__SWIG_1(swigCPtr, OdGeEllipArc3d.getCPtr(arc), intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public virtual void ellipArc(OdGeEllipArc3d arc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_ellipArc__SWIG_2(swigCPtr, OdGeEllipArc3d.getCPtr(arc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void draw(OdGiDrawable pD)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_draw(swigCPtr, OdGiDrawable.getCPtr(pD));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushClipBoundary(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_pushClipBoundary(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void popClipBoundary()
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_popClipBoundary(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void worldLine(OdGePoint3d pnts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperGeometry_worldLine(swigCPtr, OdGePoint3d.getCPtr(pnts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
