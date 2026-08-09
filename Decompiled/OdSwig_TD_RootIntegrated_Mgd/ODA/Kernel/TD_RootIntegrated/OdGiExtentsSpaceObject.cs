using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiExtentsSpaceObject : IDisposable
{
	public delegate bool SwigDelegateOdGiExtentsSpaceObject_0(IntPtr extents);

	public delegate bool SwigDelegateOdGiExtentsSpaceObject_1(IntPtr extents);

	public delegate bool SwigDelegateOdGiExtentsSpaceObject_2(IntPtr pObject, IntPtr tol);

	public delegate bool SwigDelegateOdGiExtentsSpaceObject_3(IntPtr pObject);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiExtentsSpaceObject_0 swigDelegate0;

	private SwigDelegateOdGiExtentsSpaceObject_1 swigDelegate1;

	private SwigDelegateOdGiExtentsSpaceObject_2 swigDelegate2;

	private SwigDelegateOdGiExtentsSpaceObject_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(OdGiExtentsSpaceObject),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiExtentsSpaceObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiExtentsSpaceObject(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiExtentsSpaceObject obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiExtentsSpaceObject()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiExtentsSpaceObject(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiExtentsSpaceObject(uint uniqueID)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiExtentsSpaceObject(uniqueID), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiExtentsSpaceObject) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public uint getID()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtentsSpaceObject_getID(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setID(uint uniqueID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtentsSpaceObject_setID(swigCPtr, uniqueID);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isInExtents(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtentsSpaceObject_isInExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isInExtents(OdGeExtents2d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtentsSpaceObject_isInExtents__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEqual(OdGiExtentsSpaceObject pObject, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtentsSpaceObject_isEqual__SWIG_0(swigCPtr, getCPtr(pObject), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEqual(OdGiExtentsSpaceObject pObject)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtentsSpaceObject_isEqual__SWIG_1(swigCPtr, getCPtr(pObject));
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtentsSpaceObject_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiExtentsSpaceObject));
	}

	private bool SwigDirectorMethodisInExtents__SWIG_0(IntPtr extents)
	{
		return isInExtents(new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisInExtents__SWIG_1(IntPtr extents)
	{
		return isInExtents(new OdGeExtents2d(extents, cMemoryOwn: false));
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
