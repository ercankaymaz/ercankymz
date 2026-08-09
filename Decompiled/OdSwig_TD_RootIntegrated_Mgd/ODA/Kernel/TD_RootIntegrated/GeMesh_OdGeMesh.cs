using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class GeMesh_OdGeMesh : IDisposable
{
	public delegate double SwigDelegateGeMesh_OdGeMesh_0(IntPtr pt, IntPtr ptClosest, bool bPrecise);

	public delegate int SwigDelegateGeMesh_OdGeMesh_1(IntPtr mesh, IntPtr aPtMismatch, double tol);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateGeMesh_OdGeMesh_0 swigDelegate0;

	private SwigDelegateGeMesh_OdGeMesh_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(GeMesh_OdGeMesh),
		typeof(OdGePoint3dArray),
		typeof(double)
	};

	public OdGePoint3dArray m_aVx
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_m_aVx_get(swigCPtr);
			OdGePoint3dArray result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3dArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_m_aVx_set(swigCPtr, OdGePoint3dArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdIntArray m_aVxTag
	{
		get
		{
			OdIntArray result = new OdIntArray(TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_m_aVxTag_get(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_m_aVxTag_set(swigCPtr, OdIntArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int m_tagMesh
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_m_tagMesh_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_m_tagMesh_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public GeMesh_OdGeMesh(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(GeMesh_OdGeMesh obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~GeMesh_OdGeMesh()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_GeMesh_OdGeMesh(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public GeMesh_OdGeMesh()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_GeMesh_OdGeMesh(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(GeMesh_OdGeMesh) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_getExtents(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double distanceTo(OdGePoint3d pt, OdGePoint3d ptClosest, bool bPrecise)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_distanceTo(swigCPtr, OdGePoint3d.getCPtr(pt), OdGePoint3d.getCPtr(ptClosest), bPrecise);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int checkMeshMismatch(GeMesh_OdGeMesh mesh, OdGePoint3dArray aPtMismatch, double tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_checkMeshMismatch(swigCPtr, getCPtr(mesh), OdGePoint3dArray.getCPtr(aPtMismatch), tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("distanceTo", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethoddistanceTo;
		}
		if (SwigDerivedClassHasMethod("checkMeshMismatch", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodcheckMeshMismatch;
		}
		TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeMesh_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(GeMesh_OdGeMesh));
	}

	private double SwigDirectorMethoddistanceTo(IntPtr pt, IntPtr ptClosest, bool bPrecise)
	{
		return distanceTo(new OdGePoint3d(pt, cMemoryOwn: false), new OdGePoint3d(ptClosest, cMemoryOwn: false), bPrecise);
	}

	private int SwigDirectorMethodcheckMeshMismatch(IntPtr mesh, IntPtr aPtMismatch, double tol)
	{
		return checkMeshMismatch(new GeMesh_OdGeMesh(mesh, cMemoryOwn: false), new OdGePoint3dArray(aPtMismatch, cMemoryOwn: false), tol);
	}
}
