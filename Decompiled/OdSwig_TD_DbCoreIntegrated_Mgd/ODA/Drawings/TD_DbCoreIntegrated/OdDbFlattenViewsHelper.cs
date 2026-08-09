using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbFlattenViewsHelper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbFlattenViewsHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbFlattenViewsHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbFlattenViewsHelper()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbFlattenViewsHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbFlattenViewsHelper(OdDbDatabase pDb)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFlattenViewsHelper(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbFlattenViewsHelper) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult setProjectionPlane(OdGePoint3d ptBase, OdGeVector3d vrDir, OdGeVector3d vrUp)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_setProjectionPlane(swigCPtr, OdGePoint3d.getCPtr(ptBase), OdGeVector3d.getCPtr(vrDir), OdGeVector3d.getCPtr(vrUp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdGePoint3d projectionBase()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_projectionBase(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d projectionDirection()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_projectionDirection(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d projectionUp()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_projectionUp(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool includeTangentalEdgesFlag()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_includeTangentalEdgesFlag(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIncludeTangentalEdgesFlag(bool bSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_setIncludeTangentalEdgesFlag(swigCPtr, bSet);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTangentalEdgesAngle(double dAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_setTangentalEdgesAngle(swigCPtr, dAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setEntities(OdDbObjectIdArray arr3dObjects)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_setEntities(swigCPtr, OdDbObjectIdArray.getCPtr(arr3dObjects));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdArray_OdDbObjectId_OdObjectsAllocator getEntities()
	{
		OdArray_OdDbObjectId_OdObjectsAllocator result = new OdArray_OdDbObjectId_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_getEntities(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_getExtents(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult createSectionHLR(bool bCreateSection, bool bCreateHiddenLines)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_createSectionHLR(swigCPtr, bCreateSection, bCreateHiddenLines);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult addToBlock(OdDbBlockTableRecord pOwner, OdGeMatrix3d matTransform)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_addToBlock__SWIG_0(swigCPtr, OdDbBlockTableRecord.getCPtr(pOwner), OdGeMatrix3d.getCPtr(matTransform));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult addToBlock(OdDbBlockTableRecord pOwner)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_addToBlock__SWIG_1(swigCPtr, OdDbBlockTableRecord.getCPtr(pOwner));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbHLRCurveProperties foregroundCurveProperties()
	{
		OdDbHLRCurveProperties result = new OdDbHLRCurveProperties(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_foregroundCurveProperties(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForegroundCurveProperties(OdDbHLRCurveProperties curveProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_setForegroundCurveProperties(swigCPtr, OdDbHLRCurveProperties.getCPtr(curveProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHLRCurveProperties obscuredCurveProperties()
	{
		OdDbHLRCurveProperties result = new OdDbHLRCurveProperties(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_obscuredCurveProperties(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setObscuredCurveProperties(OdDbHLRCurveProperties curveProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_setObscuredCurveProperties(swigCPtr, OdDbHLRCurveProperties.getCPtr(curveProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSectionHatchPatternSettings sectionHatchSettings()
	{
		OdDbSectionHatchPatternSettings result = new OdDbSectionHatchPatternSettings(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_sectionHatchSettings(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSectionHatchSettings(OdDbSectionHatchPatternSettings patternSettings)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_setSectionHatchSettings(swigCPtr, OdDbSectionHatchPatternSettings.getCPtr(patternSettings));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getSectionHatches(OdRxObjectPtrArray arrHatches, bool bSetProperties)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_getSectionHatches(swigCPtr, OdRxObjectPtrArray.getCPtr(arrHatches).Handle, bSetProperties);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getHiddenLines(OdRxObjectPtrArray arrHiddenLines, bool bSetProperties)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_getHiddenLines(swigCPtr, OdRxObjectPtrArray.getCPtr(arrHiddenLines).Handle, bSetProperties);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getVisibleLines(OdRxObjectPtrArray arrVisibleLines, bool bSetProperties)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_getVisibleLines(swigCPtr, OdRxObjectPtrArray.getCPtr(arrVisibleLines).Handle, bSetProperties);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFlattenViewsHelper_director_connect(swigCPtr);
	}
}
