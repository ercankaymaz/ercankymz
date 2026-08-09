using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeRuled : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeRuled(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeRuled obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeRuled(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeRuled copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_copy(swigCPtr);
		OdGeRuled result = ((intPtr == IntPtr.Zero) ? null : new OdGeRuled(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRuled transformBy(OdGeMatrix3d xfm)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRuled translateBy(OdGeVector3d translateVec)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRuled rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRuled rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRuled mirror(OdGePlane plane)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRuled scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeRuled scaleBy(double scaleFactor)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeRuled()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRuled__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRuled(OdGeCurve3d pProfileCurve1, OdGeCurve3d pProfileCurve2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRuled__SWIG_1(OdGeCurve3d.getCPtr(pProfileCurve1), OdGeCurve3d.getCPtr(pProfileCurve2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRuled(OdGeCurve3d pProfileCurve1, OdGePoint3d pPoint2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRuled__SWIG_2(OdGeCurve3d.getCPtr(pProfileCurve1), OdGePoint3d.getCPtr(pPoint2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRuled(OdGePoint3d pPoint1, OdGeCurve3d pProfileCurve2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRuled__SWIG_3(OdGePoint3d.getCPtr(pPoint1), OdGeCurve3d.getCPtr(pProfileCurve2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRuled(OdGeRuled ruled)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeRuled__SWIG_4(getCPtr(ruled)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGeCurve3d pProfileCurve1, OdGeCurve3d pProfileCurve2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_set__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(pProfileCurve1), OdGeCurve3d.getCPtr(pProfileCurve2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGeCurve3d pProfileCurve1, OdGePoint3d pPoint2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_set__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(pProfileCurve1), OdGePoint3d.getCPtr(pPoint2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGePoint3d pPoint1, OdGeCurve3d pProfileCurve2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_set__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(pPoint1), OdGeCurve3d.getCPtr(pProfileCurve2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeRuled Assign(OdGeRuled extSurf)
	{
		OdGeRuled result = new OdGeRuled(TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_Assign(swigCPtr, getCPtr(extSurf)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getProfileCurve(byte iIndex, out OdGeCurve3d pProfileCurve)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_getProfileCurve(swigCPtr, iIndex, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, bIsWrapperOwnNativeObject: true));
			pProfileCurve = Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, currentTransaction == null);
		}
	}

	public OdResult getPoint(byte iIndex, OdGePoint3d point)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_getPoint(swigCPtr, iIndex, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new bool setEnvelope(OdGeInterval intrvlU, OdGeInterval intrvlV)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_setEnvelope(swigCPtr, OdGeInterval.getCPtr(intrvlU), OdGeInterval.getCPtr(intrvlV));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new void getEnvelope(OdGeInterval intrvlU, OdGeInterval intrvlV)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_getEnvelope(swigCPtr, OdGeInterval.getCPtr(intrvlU), OdGeInterval.getCPtr(intrvlV));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasFirstProfilePoint()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_hasFirstProfilePoint(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasSecondProfilePoint()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeRuled_hasSecondProfilePoint(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
