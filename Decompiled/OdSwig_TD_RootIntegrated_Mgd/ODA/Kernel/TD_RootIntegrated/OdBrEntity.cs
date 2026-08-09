using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrEntity : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static double dUnspecified
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_dUnspecified_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_dUnspecified_set(value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrEntity(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrEntity obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBrEntity()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrEntity(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool isNull()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_isNull(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdBrEntity pOtherEntity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_isEqualTo(swigCPtr, getCPtr(pOtherEntity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getBrep(OdBrBrep brep)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getBrep(swigCPtr, OdBrBrep.getCPtr(brep));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool checkEntity()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_checkEntity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus getSubentPath(OdDbBaseFullSubentPath subPath)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getSubentPath(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subPath));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setSubentPath(OdBrBrep brep, OdDbBaseFullSubentPath subpath)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_setSubentPath(swigCPtr, OdBrBrep.getCPtr(brep), OdDbBaseFullSubentPath.getCPtr(subpath));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getPointContainment(OdGePoint3d point, OdGe_PointContainment containment, out OdBrEntity brEntContainer)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getPointContainment(swigCPtr, OdGePoint3d.getCPtr(point), containment, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdBrEntity>(typeof(OdBrEntity), jarg, bIsWrapperOwnNativeObject: true));
			brEntContainer = Helpers.odCreateObjectInternal<OdBrEntity>(typeof(OdBrEntity), jarg, currentTransaction == null);
		}
	}

	public OdBrErrorStatus getLineContainment(OdGeLinearEnt3d line, uint iNumHitsWanted, out uint iNumHitsFound, out OdBrHit brHit)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getLineContainment(swigCPtr, OdGeLinearEnt3d.getCPtr(line), iNumHitsWanted, out iNumHitsFound, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdBrHit>(typeof(OdBrHit), jarg, bIsWrapperOwnNativeObject: true));
			brHit = Helpers.odCreateObjectInternal<OdBrHit>(typeof(OdBrHit), jarg, currentTransaction == null);
		}
	}

	public OdBrErrorStatus getBoundBlock(OdGeBoundBlock3d block)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getBoundBlock(swigCPtr, OdGeBoundBlock3d.getCPtr(block));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setValidationLevel(ref BrValidationLevel level)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_setValidationLevel(swigCPtr, ref level);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getValidationLevel(ref BrValidationLevel level)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getValidationLevel(swigCPtr, ref level);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public uint getFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus getGsMarker(out IntPtr marker)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getGsMarker(swigCPtr, out marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getMassProps(OdBrMassProps massProps, double dDensity, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getMassProps__SWIG_0(swigCPtr, OdBrMassProps.getCPtr(massProps), dDensity, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getMassProps(OdBrMassProps massProps, double dDensity, double dTolRequired)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getMassProps__SWIG_1(swigCPtr, OdBrMassProps.getCPtr(massProps), dDensity, dTolRequired);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getMassProps(OdBrMassProps massProps, double dDensity)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getMassProps__SWIG_2(swigCPtr, OdBrMassProps.getCPtr(massProps), dDensity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getMassProps(OdBrMassProps massProps)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getMassProps__SWIG_3(swigCPtr, OdBrMassProps.getCPtr(massProps));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getVolume(out double dVolume, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getVolume__SWIG_0(swigCPtr, out dVolume, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getVolume(out double dVolume, double dTolRequired)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getVolume__SWIG_1(swigCPtr, out dVolume, dTolRequired);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getVolume(out double dVolume)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getVolume__SWIG_2(swigCPtr, out dVolume);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getSurfaceArea(out double dArea, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getSurfaceArea__SWIG_0(swigCPtr, out dArea, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getSurfaceArea(out double dArea, double dTolRequired)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getSurfaceArea__SWIG_1(swigCPtr, out dArea, dTolRequired);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getSurfaceArea(out double dArea)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getSurfaceArea__SWIG_2(swigCPtr, out dArea);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getPerimeterLength(out double dLength, double dTolRequired, out double dTolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getPerimeterLength__SWIG_0(swigCPtr, out dLength, dTolRequired, out dTolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getPerimeterLength(out double dLength, double dTolRequired)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getPerimeterLength__SWIG_1(swigCPtr, out dLength, dTolRequired);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getPerimeterLength(out double dLength)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getPerimeterLength__SWIG_2(swigCPtr, out dLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public ulong getUniqueId()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_getUniqueId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdBrEntity()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrEntity__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrEntity) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected OdBrEntity(OdBrEntity arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrEntity__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrEntity) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrEntity_director_connect(swigCPtr);
	}
}
