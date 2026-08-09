using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrEntity : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrEntity(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrEntity obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdIBrEntity()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrEntity(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool isEqualTo(OdIBrEntity pIBrEntity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_isEqualTo(swigCPtr, getCPtr(pIBrEntity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isNull()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_isNull(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdIBrFile getBrep()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getBrep(swigCPtr);
		OdIBrFile result = ((intPtr == IntPtr.Zero) ? null : new OdIBrFile(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool checkEntity()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_checkEntity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdBrErrorStatus getSubentPath(out int type, out int index)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getSubentPath(swigCPtr, out type, out index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getMassProps(OdBrMassProps massProps, double dDensity, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getMassProps(swigCPtr, OdBrMassProps.getCPtr(massProps), dDensity, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getVolume(out double dVolume, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getVolume(swigCPtr, out dVolume, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getSurfaceArea(out double dArea, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getSurfaceArea(swigCPtr, out dArea, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getPerimeterLength(out double dLength, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getPerimeterLength(swigCPtr, out dLength, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getBoundBlock(OdGeBoundBlock3d block)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getBoundBlock(swigCPtr, OdGeBoundBlock3d.getCPtr(block));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getPointContainment(OdGePoint3d arg0, OdGe_PointContainment arg1, out OdIBrEntity arg2, out uint arg3)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getPointContainment(swigCPtr, OdGePoint3d.getCPtr(arg0), arg1, out jarg, out arg3);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, bIsWrapperOwnNativeObject: true));
			arg2 = Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, currentTransaction == null);
		}
	}

	public virtual OdBrErrorStatus getLineContainment(OdGeLinearEnt3d arg0, uint arg1, out uint arg2, OdIBrHit arg3)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getLineContainment(swigCPtr, OdGeLinearEnt3d.getCPtr(arg0), arg1, out arg2, OdIBrHit.getCPtr(arg3).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual uint getFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdBrErrorStatus getGsMarker(out IntPtr marker)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEntity_getGsMarker(swigCPtr, out marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdIBrEntity()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdIBrEntity(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
