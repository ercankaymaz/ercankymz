using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeExternalCurve2d : OdGeCurve2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeExternalCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeExternalCurve2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeExternalCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeExternalCurve2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_copy(swigCPtr);
		OdGeExternalCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeExternalCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve2d translateBy(OdGeVector2d translateVec)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve2d rotateBy(double angle)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve2d mirror(OdGeLine2d line)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeExternalCurve2d scaleBy(double scaleFactor)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalCurve2d(OdGeExternalCurve2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalCurve2d(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve2d__SWIG_2(pCurveDef, (int)curveKind, makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExternalCurve2d(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeExternalCurve2d__SWIG_3(pCurveDef, (int)curveKind), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isNurbCurve()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_isNurbCurve__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNurbCurve(OdGeNurbCurve2d nurbCurve)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_isNurbCurve__SWIG_1(swigCPtr, OdGeNurbCurve2d.getCPtr(nurbCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDefined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_isDefined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getExternalCurve(out IntPtr pCurveDef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_getExternalCurve(swigCPtr, out pCurveDef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGe_ExternalEntityKind externalCurveKind()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_externalCurveKind(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ExternalEntityKind)result;
	}

	public OdGeExternalCurve2d set(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind, bool makeCopy)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_set__SWIG_0(swigCPtr, pCurveDef, (int)curveKind, makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve2d set(IntPtr pCurveDef, OdGe_ExternalEntityKind curveKind)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_set__SWIG_1(swigCPtr, pCurveDef, (int)curveKind), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOwnerOfCurve()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_isOwnerOfCurve(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve2d setToOwnCurve()
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_setToOwnCurve(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExternalCurve2d Assign(OdGeExternalCurve2d extCurve)
	{
		OdGeExternalCurve2d result = new OdGeExternalCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeExternalCurve2d_Assign(swigCPtr, getCPtr(extCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
