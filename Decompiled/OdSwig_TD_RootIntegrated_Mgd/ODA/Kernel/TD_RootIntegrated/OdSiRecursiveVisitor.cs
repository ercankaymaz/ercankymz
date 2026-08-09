using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiRecursiveVisitor : OdSiVisitor
{
	public delegate void SwigDelegateOdSiRecursiveVisitor_0(IntPtr entity, bool completelyInside);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdSiRecursiveVisitor_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(OdSiEntity),
		typeof(bool)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiRecursiveVisitor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiRecursiveVisitor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiRecursiveVisitor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdSiRecursiveVisitor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiRecursiveVisitor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiRecursiveVisitor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdSiShape query()
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_query(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetQuery(OdSiShape pQuery)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_resetQuery(swigCPtr, pQuery.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d worldToNode()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_worldToNode(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setWorldToNode(OdGeMatrix3d tf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_setWorldToNode(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d nodeToWorld()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_nodeToWorld(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNodeToWorld(OdGeMatrix3d tf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_setNodeToWorld(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d worldToModel()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_worldToModel(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setWorldToModel(OdGeMatrix3d tf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_setWorldToModel(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d modelToWorld()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_modelToWorld(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setModelToWorld(OdGeMatrix3d tf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_setModelToWorld(swigCPtr, OdGeMatrix3d.getCPtr(tf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("visit", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodvisit;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSiRecursiveVisitor_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSiRecursiveVisitor));
	}

	private void SwigDirectorMethodvisit(IntPtr entity, bool completelyInside)
	{
		try
		{
			visit(new OdSiEntityImpl(entity, cMemoryOwn: false), completelyInside);
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
