using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiExtents3dSpaceEdge : OdGiExtentsSpaceObject
{
	public delegate bool SwigDelegateOdGiExtents3dSpaceEdge_0(IntPtr arg0);

	public delegate bool SwigDelegateOdGiExtents3dSpaceEdge_1(IntPtr arg0);

	public delegate bool SwigDelegateOdGiExtents3dSpaceEdge_2(IntPtr arg0, IntPtr arg1);

	public delegate bool SwigDelegateOdGiExtents3dSpaceEdge_3(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiExtents3dSpaceEdge_0 swigDelegate0;

	private SwigDelegateOdGiExtents3dSpaceEdge_1 swigDelegate1;

	private SwigDelegateOdGiExtents3dSpaceEdge_2 swigDelegate2;

	private SwigDelegateOdGiExtents3dSpaceEdge_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(OdGiExtentsSpaceObject),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiExtentsSpaceObject) };

	public uint m_iVert1
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_iVert1_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_iVert1_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_iVert2
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_iVert2_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_iVert2_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool m_bVisited
	{
		get
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_bVisited_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_bVisited_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool m_bIsVisible
	{
		get
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_bIsVisible_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_m_bIsVisible_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiExtents3dSpaceEdge(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiExtents3dSpaceEdge obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiExtents3dSpaceEdge(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiExtents3dSpaceEdge(OdGiExtents3dSpacePoint pt1, OdGiExtents3dSpacePoint pt2, uint uniqueID)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiExtents3dSpaceEdge(OdGiExtents3dSpacePoint.getCPtr(pt1), OdGiExtents3dSpacePoint.getCPtr(pt2), uniqueID), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiExtents3dSpaceEdge) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setVisited(bool bVisit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_setVisited(swigCPtr, bVisit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isVisited()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isVisited(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getSecondVertex(uint iDfirst)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_getSecondVertex(swigCPtr, iDfirst);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isInExtents(OdGeExtents3d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isInExtentsSwigExplicitOdGiExtents3dSpaceEdge__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isInExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isInExtents(OdGeExtents2d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isInExtentsSwigExplicitOdGiExtents3dSpaceEdge__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isInExtents__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEqual(OdGiExtentsSpaceObject arg0, OdGeTol arg1)
	{
		bool result = (SwigDerivedClassHasMethod("isEqual", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isEqualSwigExplicitOdGiExtents3dSpaceEdge__SWIG_0(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0), OdGeTol.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isEqual__SWIG_0(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0), OdGeTol.getCPtr(arg1)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEqual(OdGiExtentsSpaceObject arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isEqual", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isEqualSwigExplicitOdGiExtents3dSpaceEdge__SWIG_1(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_isEqual__SWIG_1(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0)));
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceEdge_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiExtents3dSpaceEdge));
	}

	private bool SwigDirectorMethodisInExtents__SWIG_0(IntPtr arg0)
	{
		return isInExtents(new OdGeExtents3d(arg0, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisInExtents__SWIG_1(IntPtr arg0)
	{
		return isInExtents(new OdGeExtents2d(arg0, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisEqual__SWIG_0(IntPtr arg0, IntPtr arg1)
	{
		return isEqual((arg0 == IntPtr.Zero) ? null : new OdGiExtentsSpaceObject(arg0, cMemoryOwn: false), new OdGeTol(arg1, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisEqual__SWIG_1(IntPtr arg0)
	{
		return isEqual((arg0 == IntPtr.Zero) ? null : new OdGiExtentsSpaceObject(arg0, cMemoryOwn: false));
	}
}
