using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiBoundBlock3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiBoundBlock3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiBoundBlock3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSiBoundBlock3d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiBoundBlock3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdSiBoundBlock3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiBoundBlock3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSiBoundBlock3d(OdGeExtents3d ab)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiBoundBlock3d__SWIG_1(OdGeExtents3d.getCPtr(ab)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSiBoundBlock3d(OdGeBoundBlock3d bb)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiBoundBlock3d__SWIG_2(OdGeBoundBlock3d.getCPtr(bb)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSiBoundBlock3d(OdGePoint3d p1, OdGePoint3d p2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiBoundBlock3d__SWIG_3(OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSiBoundBlock3d(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis, OdGeVector3d zAxis)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiBoundBlock3d__SWIG_4(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(zAxis)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGeExtents3d ab)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_set__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(ab));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGeBoundBlock3d bb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_set__SWIG_1(swigCPtr, OdGeBoundBlock3d.getCPtr(bb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGePoint3d p1, OdGePoint3d p2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_set__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis, OdGeVector3d zAxis)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_set__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(zAxis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void get(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis, OdGeVector3d zAxis)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_get(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(zAxis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void transformBy(OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDisjoint(OdGeExtents3d exts, OdGeTol tolerance)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_isDisjoint__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(exts), OdGeTol.getCPtr(tolerance));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeExtents3d exts)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_isDisjoint__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGeExtents3d exts, OdGeTol tolerance)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_contains__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(exts), OdGeTol.getCPtr(tolerance));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGePoint3d pt, OdGeTol tolerance)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_contains__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(pt), OdGeTol.getCPtr(tolerance));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d minPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_minPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d maxPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_maxPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getMinMaxPoints(OdGePoint3d p1, OdGePoint3d p2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_getMinMaxPoints(swigCPtr, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void extents(OdGeExtents3d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_extents(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isBox()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_isBox(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOrtho()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiBoundBlock3d_isOrtho(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
