using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiExtents3dSpaceChainPolyline : OdGiExtentsSpaceObject
{
	public delegate bool SwigDelegateOdGiExtents3dSpaceChainPolyline_0(IntPtr arg0);

	public delegate bool SwigDelegateOdGiExtents3dSpaceChainPolyline_1(IntPtr arg0);

	public delegate bool SwigDelegateOdGiExtents3dSpaceChainPolyline_2(IntPtr arg0, IntPtr arg1);

	public delegate bool SwigDelegateOdGiExtents3dSpaceChainPolyline_3(IntPtr arg0);

	public delegate void SwigDelegateOdGiExtents3dSpaceChainPolyline_4(IntPtr pVertex);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiExtents3dSpaceChainPolyline_0 swigDelegate0;

	private SwigDelegateOdGiExtents3dSpaceChainPolyline_1 swigDelegate1;

	private SwigDelegateOdGiExtents3dSpaceChainPolyline_2 swigDelegate2;

	private SwigDelegateOdGiExtents3dSpaceChainPolyline_3 swigDelegate3;

	private SwigDelegateOdGiExtents3dSpaceChainPolyline_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(OdGiExtentsSpaceObject),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiExtentsSpaceObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiExtents3dSpacePoint) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiExtents3dSpaceChainPolyline(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiExtents3dSpaceChainPolyline obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiExtents3dSpaceChainPolyline(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiExtents3dSpaceChainPolyline(uint uniqueID)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiExtents3dSpaceChainPolyline(uniqueID), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiExtents3dSpaceChainPolyline) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void addVertex(OdGiExtents3dSpacePoint pVertex)
	{
		if (SwigDerivedClassHasMethod("addVertex", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_addVertexSwigExplicitOdGiExtents3dSpaceChainPolyline(swigCPtr, OdGiExtents3dSpacePoint.getCPtr(pVertex));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_addVertex(swigCPtr, OdGiExtents3dSpacePoint.getCPtr(pVertex));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint getNumberOfVertices()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_getNumberOfVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getNumberOfVertices_closed()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_getNumberOfVertices_closed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getPoints(OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_getPoints(swigCPtr, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPoints_closed(OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_getPoints_closed(swigCPtr, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isInExtents(OdGeExtents3d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isInExtentsSwigExplicitOdGiExtents3dSpaceChainPolyline__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isInExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isInExtents(OdGeExtents2d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isInExtents", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isInExtentsSwigExplicitOdGiExtents3dSpaceChainPolyline__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isInExtents__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEqual(OdGiExtentsSpaceObject arg0, OdGeTol arg1)
	{
		bool result = (SwigDerivedClassHasMethod("isEqual", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isEqualSwigExplicitOdGiExtents3dSpaceChainPolyline__SWIG_0(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0), OdGeTol.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isEqual__SWIG_0(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0), OdGeTol.getCPtr(arg1)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEqual(OdGiExtentsSpaceObject arg0)
	{
		bool result = (SwigDerivedClassHasMethod("isEqual", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isEqualSwigExplicitOdGiExtents3dSpaceChainPolyline__SWIG_1(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_isEqual__SWIG_1(swigCPtr, OdGiExtentsSpaceObject.getCPtr(arg0)));
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
		if (SwigDerivedClassHasMethod("addVertex", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodaddVertex;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtents3dSpaceChainPolyline_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiExtents3dSpaceChainPolyline));
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

	private void SwigDirectorMethodaddVertex(IntPtr pVertex)
	{
		try
		{
			addVertex((pVertex == IntPtr.Zero) ? null : new OdGiExtents3dSpacePoint(pVertex, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
