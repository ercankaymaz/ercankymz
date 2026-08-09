using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeEntity3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeEntity3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeEntity3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeEntity3d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeEntity3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool isKindOf(OdGe_EntityId entType)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_isKindOf(swigCPtr, (int)entType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGe_EntityId type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_EntityId)result;
	}

	public OdGeEntity3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_copy(swigCPtr);
		OdGeEntity3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeEntity3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d Assign(OdGeEntity3d entity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_Assign(swigCPtr, getCPtr(entity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public bool IsEqual(OdGeEntity3d entity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_IsEqual(swigCPtr, getCPtr(entity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeEntity3d entity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_IsNotEqual(swigCPtr, getCPtr(entity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeEntity3d object_, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_isEqualTo__SWIG_0(swigCPtr, getCPtr(object_), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeEntity3d object_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_isEqualTo__SWIG_1(swigCPtr, getCPtr(object_));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d transformBy(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity3d translateBy(OdGeVector3d translateVec)
	{
		OdGeEntity3d result = new OdGeEntity3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity3d rotateBy(double angle, OdGeVector3d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity3d mirror(OdGePlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_mirror(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return this;
	}

	public OdGeEntity3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeEntity3d result = new OdGeEntity3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEntity3d scaleBy(double scaleFactor)
	{
		OdGeEntity3d result = new OdGeEntity3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_isOn__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEntity3d_isOn__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
