using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFastExtCalc : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFastExtCalc(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFastExtCalc obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiFastExtCalc()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFastExtCalc(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public void resetExtents()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_resetExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getExtents(OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_getExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDrawInvisible(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_setDrawInvisible(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDrawInvisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_isDrawInvisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDrawInvisibleNested(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_setDrawInvisibleNested(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDrawInvisibleNested()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_isDrawInvisibleNested(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetFirstDrawFlag()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_resetFirstDrawFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setViewportDrawEnabled(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_setViewportDrawEnabled(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isViewportDrawEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_isViewportDrawEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiWorldDraw getWorldDraw()
	{
		OdGiWorldDraw rXObject = Helpers.GetRXObject<OdGiWorldDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_getWorldDraw(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiViewportDraw getViewportDraw()
	{
		OdGiViewportDraw rXObject = Helpers.GetRXObject<OdGiViewportDraw>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_getViewportDraw(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiWorldGeometry getWorldGeometry()
	{
		OdGiWorldGeometry rXObject = Helpers.GetRXObject<OdGiWorldGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_getWorldGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiViewportGeometry getViewportGeometry()
	{
		OdGiViewportGeometry rXObject = Helpers.GetRXObject<OdGiViewportGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_getViewportGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool regenAbort()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_regenAbort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double deviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_deviation(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRegenType regenType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_regenType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public void circle(OdGePoint3d center, double radius, OdGeVector3d normal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_circle__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circle(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_circle__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_circularArc__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle, (int)arcType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_circularArc__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(center), radius, OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(startVector), sweepAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circularArc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGiArcType arcType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_circularArc__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint), (int)arcType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void circularArc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_circularArc__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint), OdGePoint3d.getCPtr(thirdPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyline(OdGePoint3d[] numVertices, OdGeVector3d pNormal, IntPtr baseSubEntMarker)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyline__SWIG_0(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal), baseSubEntMarker);
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

	public void polyline(OdGePoint3d[] numVertices, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyline__SWIG_1(swigCPtr, intPtr, OdGeVector3d.getCPtr(pNormal));
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

	public void polyline(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyline__SWIG_2(swigCPtr, intPtr);
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

	public void polygon(OdGePoint3d[] numVertices)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polygon(swigCPtr, intPtr);
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

	public void pline(OdGiPolyline polyline, uint fromIndex, uint numSegs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_pline__SWIG_0(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex, numSegs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pline(OdGiPolyline polyline, uint fromIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_pline__SWIG_1(swigCPtr, OdGiPolyline.getCPtr(polyline), fromIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pline(OdGiPolyline polyline)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_pline__SWIG_2(swigCPtr, OdGiPolyline.getCPtr(polyline));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void shape(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, int shapeNumber, OdGiTextStyle pTextStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_shape(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), shapeNumber, OdGiTextStyle.getCPtr(pTextStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique, string msg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_text__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique, msg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, string msg, bool raw, OdGiTextStyle pTextStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_text__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), msg, raw, OdGiTextStyle.getCPtr(pTextStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void xline(OdGePoint3d firstPoint, OdGePoint3d secondPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_xline(swigCPtr, OdGePoint3d.getCPtr(firstPoint), OdGePoint3d.getCPtr(secondPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void ray(OdGePoint3d basePoint, OdGePoint3d throughPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_ray(swigCPtr, OdGePoint3d.getCPtr(basePoint), OdGePoint3d.getCPtr(throughPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void nurbs(OdGeNurbCurve3d nurbsCurve)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_nurbs(swigCPtr, OdGeNurbCurve3d.getCPtr(nurbsCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void ellipArc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointsOverrides, OdGiArcType arcType)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointsOverrides);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_ellipArc__SWIG_0(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr, (int)arcType);
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

	public void ellipArc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointsOverrides)
	{
		IntPtr intPtr = Helpers.MarshalPointPair(endPointsOverrides);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_ellipArc__SWIG_1(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc), intPtr);
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

	public void ellipArc(OdGeEllipArc3d ellipArc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_ellipArc__SWIG_2(swigCPtr, OdGeEllipArc3d.getCPtr(ellipArc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void mesh(MeshData numRows)
	{
		IntPtr intPtr = Helpers.MarshalMeshData(numRows);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_mesh(swigCPtr, intPtr);
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

	public void shell(ShellData numVertices)
	{
		IntPtr intPtr = Helpers.MarshalShellData(numVertices);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_shell(swigCPtr, intPtr);
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

	public void worldLine(OdGePoint3d points)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_worldLine(swigCPtr, OdGePoint3d.getCPtr(points));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void image(OdGiImageBGRA32 img, OdGePoint3d origin, OdGeVector3d uVec, OdGeVector3d vVec, OdGiRasterImage_TransparencyMode trpMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_image__SWIG_0(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec), (int)trpMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void image(OdGiImageBGRA32 img, OdGePoint3d origin, OdGeVector3d uVec, OdGeVector3d vVec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_image__SWIG_1(swigCPtr, OdGiImageBGRA32.getCPtr(img), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(uVec), OdGeVector3d.getCPtr(vVec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void edge(OdGeCurve2dArray edges)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_edge(swigCPtr, OdGeCurve2dArray.getCPtr(edges));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polypoint(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, IntPtr[] pSubEntMarkers, int nPointSize)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(numPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polypoint(swigCPtr, intPtr, OdCmEntityColor.getCPtr(pColors), OdCmTransparency.getCPtr(pTransparency), OdGeVector3d.getCPtr(pNormals), Helpers.MarshalIntPtrFixedArray(pSubEntMarkers), nPointSize);
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

	public void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors, OdCmTransparency pFillTransparencies)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyPolygon__SWIG_0(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors), OdCmTransparency.getCPtr(pFillTransparencies));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyPolygon__SWIG_1(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes, OdCmEntityColor.getCPtr(pFillColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyPolygon__SWIG_2(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors), ref pOutlinePsLinetypes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyPolygon__SWIG_3(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints), OdCmEntityColor.getCPtr(pOutlineColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void polyPolygon(uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_polyPolygon__SWIG_4(swigCPtr, numIndices, ref pNumPositions, OdGePoint3d.getCPtr(pPositions), ref pNumPoints, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void rowOfDots(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_rowOfDots(swigCPtr, numPoints, OdGePoint3d.getCPtr(startPoint), OdGeVector3d.getCPtr(dirToNextPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pointCloud(OdGiPointCloud pCloud)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_pointCloud(swigCPtr, OdGiPointCloud.getCPtr(pCloud));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setExtents(OdGePoint3d newExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_setExtents(swigCPtr, OdGePoint3d.getCPtr(newExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pushClipBoundary(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_pushClipBoundary(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void popClipBoundary()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_popClipBoundary(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pushModelTransform(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_pushModelTransform(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void popModelTransform()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_popModelTransform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void draw(OdGiDrawable pDrawable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFastExtCalc_draw(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
