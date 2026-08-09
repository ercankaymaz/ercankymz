using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLocalDrawableDesc : OdGiDrawableDesc
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public IntPtr _nSelectionMarker
	{
		get
		{
			IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc__nSelectionMarker_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc__nSelectionMarker_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeMatrix3d _xModelToWorld
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc__xModelToWorld_get(swigCPtr);
			OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc__xModelToWorld_set(swigCPtr, OdGeMatrix3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeMatrix3d _pxModelToWorld
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc__pxModelToWorld_get(swigCPtr);
			OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc__pxModelToWorld_set(swigCPtr, OdGeMatrix3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLocalDrawableDesc(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLocalDrawableDesc obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLocalDrawableDesc(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	private static IntPtr SwigConstructOdGiLocalDrawableDesc(out OdGiDrawableDesc pParentDesc)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLocalDrawableDesc(out jarg);
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGiDrawableDesc>(typeof(OdGiDrawableDesc), jarg, bIsWrapperOwnNativeObject: true));
			pParentDesc = Helpers.odCreateObjectInternal<OdGiDrawableDesc>(typeof(OdGiDrawableDesc), jarg, currentTransaction == null);
		}
	}

	public OdGiLocalDrawableDesc(out OdGiDrawableDesc pParentDesc)
		: this(SwigConstructOdGiLocalDrawableDesc(out pParentDesc), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiPathNode parent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc_parent(swigCPtr);
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub persistentDrawableId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc_persistentDrawableId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawable transientDrawable()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc_transientDrawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual IntPtr selectionMarker()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc_selectionMarker(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d modelToWorld()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc_modelToWorld(swigCPtr);
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setModelToWorld(OdGeMatrix3d x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLocalDrawableDesc_setModelToWorld(swigCPtr, OdGeMatrix3d.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
