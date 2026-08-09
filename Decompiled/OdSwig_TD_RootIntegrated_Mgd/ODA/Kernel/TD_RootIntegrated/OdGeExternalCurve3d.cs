using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeExternalCurve3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeExternalCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeExternalCurve3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeExternalCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeExternalCurve3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_copy(swigCPtr);
		OdGeExternalCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeExternalCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve3d translateBy(OdGeVector3d translateVec)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve3d mirror(OdGePlane plane)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve3d scaleBy(double scaleFactor)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalCurve3d(OdGeExternalCurve3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalCurve3d(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve3d__SWIG_2(pCurveDef, (int)curveKind, makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalCurve3d(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve3d__SWIG_3(pCurveDef, (int)curveKind), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLine()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isLine(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRay()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isRay(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLineSeg()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isLineSeg(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCircArc()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isCircArc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEllipArc()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isEllipArc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNurbCurve()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isNurbCurve(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDefined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isDefined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNativeCurve(out OdGeCurve3d nativeCurve)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isNativeCurve(swigCPtr, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, bIsWrapperOwnNativeObject: true));
			nativeCurve = Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, currentTransaction == null);
		}
	}

	public void getExternalCurve(out IntPtr pCurveDef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_getExternalCurve(swigCPtr, out pCurveDef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGe_ExternalEntityKind externalCurveKind()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_externalCurveKind(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ExternalEntityKind)result;
	}

	public OdGeExternalCurve3d set(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind, bool makeCopy)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_set__SWIG_0(swigCPtr, pCurveDef, (int)curveKind, makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve3d set(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_set__SWIG_1(swigCPtr, pCurveDef, (int)curveKind), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve3d Assign(OdGeExternalCurve3d extCurve)
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_Assign(swigCPtr, getCPtr(extCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOwnerOfCurve()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_isOwnerOfCurve(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve3d setToOwnCurve()
	{
		OdGeExternalCurve3d result = new OdGeExternalCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve3d_setToOwnCurve(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
