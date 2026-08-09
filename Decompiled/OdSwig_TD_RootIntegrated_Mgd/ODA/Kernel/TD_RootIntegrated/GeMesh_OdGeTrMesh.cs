using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class GeMesh_OdGeTrMesh : GeMesh_OdGeMesh
{
	public delegate double SwigDelegateGeMesh_OdGeTrMesh_0(IntPtr pt, IntPtr ptClosest, bool bPrecise);

	public delegate int SwigDelegateGeMesh_OdGeTrMesh_1(IntPtr mesh, IntPtr aPtMismatch, double tol);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateGeMesh_OdGeTrMesh_0 swigDelegate0;

	private SwigDelegateGeMesh_OdGeTrMesh_1 swigDelegate1;

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

	public OdArray_GeMesh_OdGeTr_OdObjectsAllocator m_aTr
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_m_aTr_get(swigCPtr);
			OdArray_GeMesh_OdGeTr_OdObjectsAllocator result = ((intPtr == IntPtr.Zero) ? null : new OdArray_GeMesh_OdGeTr_OdObjectsAllocator(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_m_aTr_set(swigCPtr, OdArray_GeMesh_OdGeTr_OdObjectsAllocator.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdArray_OdIntPairArray m_vxToTr
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_m_vxToTr_get(swigCPtr);
			OdArray_OdIntPairArray result = ((intPtr == IntPtr.Zero) ? null : new OdArray_OdIntPairArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_m_vxToTr_set(swigCPtr, OdArray_OdIntPairArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public GeMesh_OdGeTrMesh(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(GeMesh_OdGeTrMesh obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_GeMesh_OdGeTrMesh(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override double distanceTo(OdGePoint3d pt, OdGePoint3d ptClosest, bool bPrecise)
	{
		double result = (SwigDerivedClassHasMethod("distanceTo", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_distanceToSwigExplicitGeMesh_OdGeTrMesh(swigCPtr, OdGePoint3d.getCPtr(pt), OdGePoint3d.getCPtr(ptClosest), bPrecise) : TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_distanceTo(swigCPtr, OdGePoint3d.getCPtr(pt), OdGePoint3d.getCPtr(ptClosest), bPrecise));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int checkMeshMismatch(GeMesh_OdGeMesh mesh, OdGePoint3dArray aPtMismatch, double tol)
	{
		int result = (SwigDerivedClassHasMethod("checkMeshMismatch", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_checkMeshMismatchSwigExplicitGeMesh_OdGeTrMesh(swigCPtr, GeMesh_OdGeMesh.getCPtr(mesh), OdGePoint3dArray.getCPtr(aPtMismatch), tol) : TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_checkMeshMismatch(swigCPtr, GeMesh_OdGeMesh.getCPtr(mesh), OdGePoint3dArray.getCPtr(aPtMismatch), tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d trNormal(int t, ref double area)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_trNormal__SWIG_0(swigCPtr, t, ref area), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d trNormal(int t)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_trNormal__SWIG_1(swigCPtr, t), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d vxNormal(int v)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_vxNormal(swigCPtr, v), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool walkNextTr(out int iTr, out int w, bool dir)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_walkNextTr(swigCPtr, out iTr, out w, dir);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool walkAroundVertex(out int iTr, out int w, GeMesh_int3 aux)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_walkAroundVertex(swigCPtr, out iTr, out w, GeMesh_int3.getCPtr(aux));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getCoEdge(int t, int e)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_getCoEdge(swigCPtr, t, e);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int fillNbLinks()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_fillNbLinks(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void removeDegenerateTriangles(double tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_removeDegenerateTriangles(swigCPtr, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void append(GeMesh_OdGeTrMesh mesh)
	{
		TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_append(swigCPtr, getCPtr(mesh));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fillVxToTr()
	{
		TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_fillVxToTr(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeUnusedVertices()
	{
		TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_removeUnusedVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public GeMesh_OdGeTrMesh()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_GeMesh_OdGeTrMesh(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(GeMesh_OdGeTrMesh) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		TD_RootIntegrated_GlobalsPINVOKE.GeMesh_OdGeTrMesh_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(GeMesh_OdGeTrMesh));
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
