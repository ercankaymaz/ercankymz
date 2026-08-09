using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeSurfSurfInt : OdGeEntity3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeSurfSurfInt(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeSurfSurfInt obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeSurfSurfInt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeSurfSurfInt copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_copy(swigCPtr);
		OdGeSurfSurfInt result = ((intPtr == IntPtr.Zero) ? null : new OdGeSurfSurfInt(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfSurfInt transformBy(OdGeMatrix3d xfm)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfSurfInt translateBy(OdGeVector3d translateVec)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfSurfInt rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfSurfInt rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfSurfInt mirror(OdGePlane plane)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfSurfInt scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSurfSurfInt scaleBy(double scaleFactor)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurfSurfInt()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfSurfInt__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurfSurfInt(OdGeSurface srf1, OdGeSurface srf2, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfSurfInt__SWIG_1(OdGeSurface.getCPtr(srf1), OdGeSurface.getCPtr(srf2), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurfSurfInt(OdGeSurface srf1, OdGeSurface srf2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfSurfInt__SWIG_2(OdGeSurface.getCPtr(srf1), OdGeSurface.getCPtr(srf2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurfSurfInt(OdGeSurfSurfInt source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSurfSurfInt__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurface surface1()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_surface1(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurface surface2()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_surface2(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTol tolerance()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_tolerance(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numResults(ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_numResults(swigCPtr, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numIntPoints(ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_numIntPoints(swigCPtr, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d intCurve(int intNum, bool isExternal, ref OdGe_OdGeIntersectError status)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_intCurve(swigCPtr, intNum, isExternal, ref status), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d intParamCurve(int intNum, bool isExternal, bool isFirst, ref OdGe_OdGeIntersectError status)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_intParamCurve(swigCPtr, intNum, isExternal, isFirst, ref status), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d intPoint(int intNum, ref OdGe_OdGeIntersectError status)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_intPoint(swigCPtr, intNum, ref status), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getIntPointParams(int intNum, OdGePoint2d param1, OdGePoint2d param2, ref OdGe_OdGeIntersectError status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_getIntPointParams(swigCPtr, intNum, OdGePoint2d.getCPtr(param1), OdGePoint2d.getCPtr(param2), ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIntConfigs(int intNum, ref OdGe_ssiConfig surf1Left, ref OdGe_ssiConfig surf1Right, ref OdGe_ssiConfig surf2Left, ref OdGe_ssiConfig surf2Right, ref OdGe_ssiType intType, out int dim, ref OdGe_OdGeIntersectError status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_getIntConfigs(swigCPtr, intNum, ref surf1Left, ref surf1Right, ref surf2Left, ref surf2Right, ref intType, out dim, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numIntCurves(ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_numIntCurves(swigCPtr, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getDimension(int intNum, ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_getDimension(swigCPtr, intNum, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGe_ssiType getType(int intNum, ref OdGe_OdGeIntersectError status)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_getType(swigCPtr, intNum, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ssiType)result;
	}

	public bool haveOverlap(ref OdGe_OdGeIntersectError status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_haveOverlap(swigCPtr, ref status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurfSurfInt set(OdGeSurface srf1, OdGeSurface srf2, OdGeTol tol)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_set__SWIG_0(swigCPtr, OdGeSurface.getCPtr(srf1), OdGeSurface.getCPtr(srf2), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurfSurfInt set(OdGeSurface srf1, OdGeSurface srf2)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_set__SWIG_1(swigCPtr, OdGeSurface.getCPtr(srf1), OdGeSurface.getCPtr(srf2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSurfSurfInt Assign(OdGeSurfSurfInt surfSurfInt)
	{
		OdGeSurfSurfInt result = new OdGeSurfSurfInt(TD_RootIntegrated_GlobalsPINVOKE.OdGeSurfSurfInt_Assign(swigCPtr, getCPtr(surfSurfInt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
