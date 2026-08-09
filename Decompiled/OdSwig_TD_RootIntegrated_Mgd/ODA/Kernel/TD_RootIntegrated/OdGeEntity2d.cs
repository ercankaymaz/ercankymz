using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeEntity2d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeEntity2d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeEntity2d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeEntity2d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeEntity2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool isKindOf(OdGe_EntityId entType)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_isKindOf(swigCPtr, (int)entType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGe_EntityId type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_EntityId)result;
	}

	public OdGeEntity2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_copy(swigCPtr);
		OdGeEntity2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEntity2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity2d Assign(OdGeEntity2d entity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_Assign(swigCPtr, getCPtr(entity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public bool IsEqual(OdGeEntity2d entity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_IsEqual(swigCPtr, getCPtr(entity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeEntity2d entity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_IsNotEqual(swigCPtr, getCPtr(entity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeEntity2d other, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_isEqualTo__SWIG_0(swigCPtr, getCPtr(other), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeEntity2d other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_isEqualTo__SWIG_1(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity2d transformBy(OdGeMatrix2d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity2d translateBy(OdGeVector2d translateVec)
	{
		OdGeEntity2d result = new OdGeEntity2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity2d rotateBy(double angle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_rotateBy__SWIG_1(swigCPtr, angle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity2d mirror(OdGeLine2d line)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeEntity2d result = new OdGeEntity2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity2d scaleBy(double scaleFactor)
	{
		OdGeEntity2d result = new OdGeEntity2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint2d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_isOn__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity2d_isOn__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
