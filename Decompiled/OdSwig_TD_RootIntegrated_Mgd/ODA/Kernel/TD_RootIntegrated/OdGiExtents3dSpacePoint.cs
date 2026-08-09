using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiExtents3dSpacePoint : OdGiExtentsSpaceObject
{
	public delegate bool SwigDelegateOdGiExtents3dSpacePoint_0(IntPtr extents);

	public delegate bool SwigDelegateOdGiExtents3dSpacePoint_1(IntPtr arg0);

	public delegate bool SwigDelegateOdGiExtents3dSpacePoint_2(IntPtr pObject, IntPtr tol);

	public delegate bool SwigDelegateOdGiExtents3dSpacePoint_3(IntPtr pObject);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiExtents3dSpacePoint_0 swigDelegate0;

	private SwigDelegateOdGiExtents3dSpacePoint_1 swigDelegate1;

	private SwigDelegateOdGiExtents3dSpacePoint_2 swigDelegate2;

	private SwigDelegateOdGiExtents3dSpacePoint_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(OdGiExtentsSpaceObject),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiExtentsSpaceObject) };

	public OdGePoint3d m_pt
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_m_pt_get(swigCPtr);
			OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_m_pt_set(swigCPtr, OdGePoint3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiExtents3dSpacePoint(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiExtents3dSpacePoint obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiExtents3dSpacePoint(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiExtents3dSpacePoint(OdGePoint3d pt, uint uniqueID)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiExtents3dSpacePoint(OdGePoint3d.getCPtr(pt), uniqueID), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiExtents3dSpacePoint) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void addEdge(uint ID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_addEdge(swigCPtr, ID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addInvisible(uint ID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_addInvisible(swigCPtr, ID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeInvisible(uint ID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_removeInvisible(swigCPtr, ID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isInExtents(OdGeExtents3d extents)
	{
		bool result = (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isInExtentsSwigExplicitOdGiExtents3dSpacePoint__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isInExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isInExtents(OdGeExtents2d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isInExtentsSwigExplicitOdGiExtents3dSpacePoint__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isInExtents__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEqual(OdGiExtentsSpaceObject pObject, OdGeTol tol)
	{
		bool result = (SwigDerivedClassHasMethod("isEqual", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isEqualSwigExplicitOdGiExtents3dSpacePoint__SWIG_0(swigCPtr, OdGiExtentsSpaceObject.getCPtr(pObject), OdGeTol.getCPtr(tol)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isEqual__SWIG_0(swigCPtr, OdGiExtentsSpaceObject.getCPtr(pObject), OdGeTol.getCPtr(tol)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEqual(OdGiExtentsSpaceObject pObject)
	{
		bool result = (SwigDerivedClassHasMethod("isEqual", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isEqualSwigExplicitOdGiExtents3dSpacePoint__SWIG_1(swigCPtr, OdGiExtentsSpaceObject.getCPtr(pObject)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isEqual__SWIG_1(swigCPtr, OdGiExtentsSpaceObject.getCPtr(pObject)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ulong getPower()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_getPower(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public std_set_OdUInt32 getEdges()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_getEdges(swigCPtr);
		std_set_OdUInt32 result = ((intPtr == IntPtr.Zero) ? null : new std_set_OdUInt32(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public std_set_OdUInt32 getInvisilbeEdges()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_getInvisilbeEdges(swigCPtr);
		std_set_OdUInt32 result = ((intPtr == IntPtr.Zero) ? null : new std_set_OdUInt32(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVisited(bool bVisit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_setVisited(swigCPtr, bVisit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isVisited()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_isVisited(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodisInExtents__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisInExtents__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isEqual", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodisEqual__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isEqual", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisEqual__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpacePoint_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiExtents3dSpacePoint));
	}

	private bool SwigDirectorMethodisInExtents__SWIG_0(IntPtr extents)
	{
		return isInExtents(new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisInExtents__SWIG_1(IntPtr arg0)
	{
		return isInExtents(new OdGeExtents2d(arg0, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisEqual__SWIG_0(IntPtr pObject, IntPtr tol)
	{
		return isEqual((pObject == IntPtr.Zero) ? null : new OdGiExtentsSpaceObject(pObject, cMemoryOwn: false), new OdGeTol(tol, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisEqual__SWIG_1(IntPtr pObject)
	{
		return isEqual((pObject == IntPtr.Zero) ? null : new OdGiExtentsSpaceObject(pObject, cMemoryOwn: false));
	}
}
