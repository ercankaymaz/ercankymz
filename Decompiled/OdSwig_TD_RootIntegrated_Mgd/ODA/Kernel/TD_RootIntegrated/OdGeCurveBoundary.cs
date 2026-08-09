using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCurveBoundary : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCurveBoundary(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCurveBoundary obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeCurveBoundary()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCurveBoundary(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public void getContour(out int numCurves, out OdGeEntity3d[] crv3d, out OdGeCurve2d[] crv2d, out bool[] orientation3d, out bool[] orientation2d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_getContour(swigCPtr, out numCurves, out var jarg, out var jarg2, out var jarg3, out var jarg4);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		crv3d = new OdGeEntity3d[numCurves];
		crv2d = new OdGeCurve2d[numCurves];
		for (int i = 0; i < numCurves; i++)
		{
			crv3d[i] = new OdGeEntity3d(Marshal.ReadIntPtr(jarg, i * Marshal.SizeOf(Marshal.SizeOf(typeof(IntPtr)))), cMemoryOwn: false);
			crv2d[i] = new OdGeCurve2d(Marshal.ReadIntPtr(jarg2, i * Marshal.SizeOf(Marshal.SizeOf(typeof(IntPtr)))), cMemoryOwn: false);
		}
		orientation3d = Helpers.UnMarshalBoolFixedArray(jarg3, numCurves);
		orientation2d = Helpers.UnMarshalBoolFixedArray(jarg4, numCurves);
	}

	public OdGeCurveBoundary()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveBoundary__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveBoundary(int numCurves, OdGeEntity3d[] crv3d, OdGeCurve2d[] crv2d, bool[] orientation3d, bool[] orientation2d, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveBoundary__SWIG_1(numCurves, crv3d, crv2d, Helpers.MarshalboolFixedArray(orientation3d), Helpers.MarshalboolFixedArray(orientation2d), makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveBoundary(int numCurves, OdGeEntity3d[] crv3d, OdGeCurve2d[] crv2d, bool[] orientation3d, bool[] orientation2d)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveBoundary__SWIG_2(numCurves, crv3d, crv2d, Helpers.MarshalboolFixedArray(orientation3d), Helpers.MarshalboolFixedArray(orientation2d)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveBoundary(OdGeCurveBoundary source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCurveBoundary__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurveBoundary Assign(OdGeCurveBoundary crvBoundary)
	{
		OdGeCurveBoundary result = new OdGeCurveBoundary(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_Assign(swigCPtr, getCPtr(crvBoundary)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDegenerate()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_isDegenerate__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDegenerate(OdGePosition3d degenPoint, OdGeCurve2d[] paramCurve)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_isDegenerate__SWIG_1(swigCPtr, OdGePosition3d.getCPtr(degenPoint), paramCurve);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numElements()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_numElements(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveBoundary set(int numCurves, OdGeEntity3d[] crv3d, OdGeCurve2d[] crv2d, bool[] orientation3d, bool[] orientation2d, bool makeCopy)
	{
		OdGeCurveBoundary result = new OdGeCurveBoundary(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_set__SWIG_0(swigCPtr, numCurves, crv3d, crv2d, Helpers.MarshalboolFixedArray(orientation3d), Helpers.MarshalboolFixedArray(orientation2d), makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveBoundary set(int numCurves, OdGeEntity3d[] crv3d, OdGeCurve2d[] crv2d, bool[] orientation3d, bool[] orientation2d)
	{
		OdGeCurveBoundary result = new OdGeCurveBoundary(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_set__SWIG_1(swigCPtr, numCurves, crv3d, crv2d, Helpers.MarshalboolFixedArray(orientation3d), Helpers.MarshalboolFixedArray(orientation2d)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOwnerOfCurves()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_isOwnerOfCurves(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurveBoundary setToOwnCurves()
	{
		OdGeCurveBoundary result = new OdGeCurveBoundary(TD_RootIntegrated_GlobalsPINVOKE.OdGeCurveBoundary_setToOwnCurves(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
