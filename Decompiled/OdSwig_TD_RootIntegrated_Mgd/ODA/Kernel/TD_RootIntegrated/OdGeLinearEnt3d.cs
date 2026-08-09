using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeLinearEnt3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeLinearEnt3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeLinearEnt3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeLinearEnt3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeLinearEnt3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_copy(swigCPtr);
		OdGeLinearEnt3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLinearEnt3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt3d translateBy(OdGeVector3d translateVec)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt3d mirror(OdGePlane plane)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt3d scaleBy(double scaleFactor)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, OdGePoint3d intPt, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_intersectWith__SWIG_0(swigCPtr, getCPtr(line), OdGePoint3d.getCPtr(intPt), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d line, OdGePoint3d intPt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_intersectWith__SWIG_1(swigCPtr, getCPtr(line), OdGePoint3d.getCPtr(intPt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlanarEnt plane, OdGePoint3d intPnt, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_intersectWith__SWIG_2(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGePoint3d.getCPtr(intPnt), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGePlanarEnt plane, OdGePoint3d intPnt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_intersectWith__SWIG_3(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGePoint3d.getCPtr(intPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool projIntersectWith(OdGeLinearEnt3d line, OdGeVector3d projDir, OdGePoint3d pntOnThisLine, OdGePoint3d pntOnOtherLine, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_projIntersectWith__SWIG_0(swigCPtr, getCPtr(line), OdGeVector3d.getCPtr(projDir), OdGePoint3d.getCPtr(pntOnThisLine), OdGePoint3d.getCPtr(pntOnOtherLine), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool projIntersectWith(OdGeLinearEnt3d line, OdGeVector3d projDir, OdGePoint3d pntOnThisLine, OdGePoint3d pntOnOtherLine)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_projIntersectWith__SWIG_1(swigCPtr, getCPtr(line), OdGeVector3d.getCPtr(projDir), OdGePoint3d.getCPtr(pntOnThisLine), OdGePoint3d.getCPtr(pntOnOtherLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool overlap(OdGeLinearEnt3d line, out OdGeLinearEnt3d overlap, OdGeTol tol)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_overlap__SWIG_0(swigCPtr, getCPtr(line), out jarg, OdGeTol.getCPtr(tol));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeLinearEnt3d>(typeof(OdGeLinearEnt3d), jarg, bIsWrapperOwnNativeObject: true));
			overlap = Helpers.odCreateObjectInternal<OdGeLinearEnt3d>(typeof(OdGeLinearEnt3d), jarg, currentTransaction == null);
		}
	}

	public bool overlap(OdGeLinearEnt3d line, out OdGeLinearEnt3d overlap)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_overlap__SWIG_1(swigCPtr, getCPtr(line), out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeLinearEnt3d>(typeof(OdGeLinearEnt3d), jarg, bIsWrapperOwnNativeObject: true));
			overlap = Helpers.odCreateObjectInternal<OdGeLinearEnt3d>(typeof(OdGeLinearEnt3d), jarg, currentTransaction == null);
		}
	}

	public bool isOn(OdGePlane plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isOn__SWIG_0(swigCPtr, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePlane plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isOn__SWIG_1(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeLinearEnt3d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isParallelTo__SWIG_0(swigCPtr, getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeLinearEnt3d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isParallelTo__SWIG_1(swigCPtr, getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGePlanarEnt plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isParallelTo__SWIG_2(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGePlanarEnt plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isParallelTo__SWIG_3(swigCPtr, OdGePlanarEnt.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeLinearEnt3d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isPerpendicularTo__SWIG_0(swigCPtr, getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeLinearEnt3d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isPerpendicularTo__SWIG_1(swigCPtr, getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGePlanarEnt plane, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isPerpendicularTo__SWIG_2(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGePlanarEnt plane)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isPerpendicularTo__SWIG_3(swigCPtr, OdGePlanarEnt.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isColinearTo(OdGeLinearEnt3d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isColinearTo__SWIG_0(swigCPtr, getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isColinearTo(OdGeLinearEnt3d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_isColinearTo__SWIG_1(swigCPtr, getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getPerpPlane(OdGePoint3d point, OdGePlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_getPerpPlane(swigCPtr, OdGePoint3d.getCPtr(point), OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d pointOnLine()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_pointOnLine(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d direction()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_direction(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getLine(OdGeLine3d line)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_getLine(swigCPtr, OdGeLine3d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLinearEnt3d Assign(OdGeLinearEnt3d line)
	{
		OdGeLinearEnt3d result = new OdGeLinearEnt3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt3d_Assign(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
