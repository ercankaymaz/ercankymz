using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeClipBoundary2d : OdGeEntity2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeClipBoundary2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeClipBoundary2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeClipBoundary2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeClipBoundary2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_copy(swigCPtr);
		OdGeClipBoundary2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeClipBoundary2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeClipBoundary2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeClipBoundary2d translateBy(OdGeVector2d translateVec)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeClipBoundary2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeClipBoundary2d rotateBy(double angle)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeClipBoundary2d mirror(OdGeLine2d line)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeClipBoundary2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeClipBoundary2d scaleBy(double scaleFactor)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeClipBoundary2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeClipBoundary2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeClipBoundary2d(OdGePoint2d cornerA, OdGePoint2d cornerB)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeClipBoundary2d__SWIG_1(OdGePoint2d.getCPtr(cornerA), OdGePoint2d.getCPtr(cornerB)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeClipBoundary2d(OdGePoint2dArray clipBoundary)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeClipBoundary2d__SWIG_2(OdGePoint2dArray.getCPtr(clipBoundary).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeClipBoundary2d(OdGeClipBoundary2d src)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeClipBoundary2d__SWIG_3(getCPtr(src)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGe_ClipError set(OdGePoint2d cornerA, OdGePoint2d cornerB)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(cornerA), OdGePoint2d.getCPtr(cornerB));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ClipError)result;
	}

	public OdGe_ClipError set(OdGePoint2dArray clipBoundary)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_set__SWIG_1(swigCPtr, OdGePoint2dArray.getCPtr(clipBoundary).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ClipError)result;
	}

	public OdGe_ClipError clipPolygon(OdGePoint2dArray rawVertices, OdGePoint2dArray clippedVertices, ref OdGe_ClipCondition clipCondition, OdIntArray pClippedSegmentSourceLabel)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_clipPolygon__SWIG_0(swigCPtr, OdGePoint2dArray.getCPtr(rawVertices).Handle, OdGePoint2dArray.getCPtr(clippedVertices).Handle, ref clipCondition, OdIntArray.getCPtr(pClippedSegmentSourceLabel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ClipError)result;
	}

	public OdGe_ClipError clipPolygon(OdGePoint2dArray rawVertices, OdGePoint2dArray clippedVertices, ref OdGe_ClipCondition clipCondition)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_clipPolygon__SWIG_1(swigCPtr, OdGePoint2dArray.getCPtr(rawVertices).Handle, OdGePoint2dArray.getCPtr(clippedVertices).Handle, ref clipCondition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ClipError)result;
	}

	public OdGe_ClipError clipPolyline(OdGePoint2dArray rawVertices, OdGePoint2dArray clippedVertices, ref OdGe_ClipCondition clipCondition, OdIntArray pClippedSegmentSourceLabel)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_clipPolyline__SWIG_0(swigCPtr, OdGePoint2dArray.getCPtr(rawVertices).Handle, OdGePoint2dArray.getCPtr(clippedVertices).Handle, ref clipCondition, OdIntArray.getCPtr(pClippedSegmentSourceLabel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ClipError)result;
	}

	public OdGe_ClipError clipPolyline(OdGePoint2dArray rawVertices, OdGePoint2dArray clippedVertices, ref OdGe_ClipCondition clipCondition)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_clipPolyline__SWIG_1(swigCPtr, OdGePoint2dArray.getCPtr(rawVertices).Handle, OdGePoint2dArray.getCPtr(clippedVertices).Handle, ref clipCondition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ClipError)result;
	}

	public OdGeClipBoundary2d Assign(OdGeClipBoundary2d src)
	{
		OdGeClipBoundary2d result = new OdGeClipBoundary2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeClipBoundary2d_Assign(swigCPtr, getCPtr(src)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
