using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeLinearEnt2d : OdGeCurve2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeLinearEnt2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeLinearEnt2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeLinearEnt2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeLinearEnt2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_copy(swigCPtr);
		OdGeLinearEnt2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLinearEnt2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt2d translateBy(OdGeVector2d translateVec)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt2d rotateBy(double angle)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt2d mirror(OdGeLine2d line)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLinearEnt2d scaleBy(double scaleFactor)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt2d line, OdGePoint2d intPnt, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_intersectWith__SWIG_0(swigCPtr, getCPtr(line), OdGePoint2d.getCPtr(intPnt), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt2d line, OdGePoint2d intPnt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_intersectWith__SWIG_1(swigCPtr, getCPtr(line), OdGePoint2d.getCPtr(intPnt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool overlap(OdGeLinearEnt2d line, out OdGeLinearEnt2d overlap, OdGeTol tol)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_overlap__SWIG_0(swigCPtr, getCPtr(line), out jarg, OdGeTol.getCPtr(tol));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeLinearEnt2d>(typeof(OdGeLinearEnt2d), jarg, bIsWrapperOwnNativeObject: true));
			overlap = Helpers.odCreateObjectInternal<OdGeLinearEnt2d>(typeof(OdGeLinearEnt2d), jarg, currentTransaction == null);
		}
	}

	public bool overlap(OdGeLinearEnt2d line, out OdGeLinearEnt2d overlap)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_overlap__SWIG_1(swigCPtr, getCPtr(line), out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeLinearEnt2d>(typeof(OdGeLinearEnt2d), jarg, bIsWrapperOwnNativeObject: true));
			overlap = Helpers.odCreateObjectInternal<OdGeLinearEnt2d>(typeof(OdGeLinearEnt2d), jarg, currentTransaction == null);
		}
	}

	public bool isParallelTo(OdGeLinearEnt2d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_isParallelTo__SWIG_0(swigCPtr, getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeLinearEnt2d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_isParallelTo__SWIG_1(swigCPtr, getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeLinearEnt2d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_isPerpendicularTo__SWIG_0(swigCPtr, getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeLinearEnt2d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_isPerpendicularTo__SWIG_1(swigCPtr, getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isColinearTo(OdGeLinearEnt2d line, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_isColinearTo__SWIG_0(swigCPtr, getCPtr(line), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isColinearTo(OdGeLinearEnt2d line)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_isColinearTo__SWIG_1(swigCPtr, getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getPerpLine(OdGePoint2d point, OdGeLine2d perpLine)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_getPerpLine(swigCPtr, OdGePoint2d.getCPtr(point), OdGeLine2d.getCPtr(perpLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d pointOnLine()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_pointOnLine(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d direction()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_direction(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getLine(OdGeLine2d line)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_getLine(swigCPtr, OdGeLine2d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLinearEnt2d Assign(OdGeLinearEnt2d line)
	{
		OdGeLinearEnt2d result = new OdGeLinearEnt2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLinearEnt2d_Assign(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
