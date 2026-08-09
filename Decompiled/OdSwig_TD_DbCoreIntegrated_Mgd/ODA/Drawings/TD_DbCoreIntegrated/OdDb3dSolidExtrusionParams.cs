using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDb3dSolidExtrusionParams : OdDb3dSolidGeomParams
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public OdGeVector3d direction
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidExtrusionParams_direction_get(swigCPtr);
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidExtrusionParams_direction_set(swigCPtr, OdGeVector3d.getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDbEntity extrusionEntity
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidExtrusionParams_extrusionEntity_get(swigCPtr);
			OdDbEntity result = ((intPtr == IntPtr.Zero) ? null : new OdDbEntity(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidExtrusionParams_extrusionEntity_set(swigCPtr, OdDbEntity.getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDbSweepOptions options
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidExtrusionParams_options_get(swigCPtr);
			OdDbSweepOptions result = ((intPtr == IntPtr.Zero) ? null : new OdDbSweepOptions(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidExtrusionParams_options_set(swigCPtr, OdDbSweepOptions.getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDb3dSolidExtrusionParams(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidExtrusionParams_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDb3dSolidExtrusionParams obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDb3dSolidExtrusionParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDb3dSolidExtrusionParams()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dSolidExtrusionParams(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
