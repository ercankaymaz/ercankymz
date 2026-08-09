using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDb3dSolid : OdDbEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDb3dSolid(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDb3dSolid obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDb3dSolid(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDb3dSolid cast(OdRxObject pObj)
	{
		OdDb3dSolid rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDb3dSolid createObject()
	{
		OdDb3dSolid rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isNull()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isNull(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult acisOut(OdStreamBuf pStreamBuf, int typeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_acisOut__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), typeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult acisOut(OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_acisOut__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult acisIn(OdStreamBuf pStreamBuf, out int pTypeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_acisIn__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), out pTypeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult acisIn(OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_acisIn__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void brep(OdBrBrep brep)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_brep(swigCPtr, OdBrBrep.getCPtr(brep));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getFaceMesh(GeMesh_OdGeTrMesh mesh, IntPtr iFace, wrTriangulationParams triangulationParams)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getFaceMesh(swigCPtr, GeMesh_OdGeTrMesh.getCPtr(mesh), iFace, wrTriangulationParams.getCPtr(triangulationParams));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createBox(double xLen, double yLen, double zLen)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createBox(swigCPtr, xLen, yLen, zLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createFrustum(double height, double majorRadius, double minorRadius, double topMajorRadius)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createFrustum(swigCPtr, height, majorRadius, minorRadius, topMajorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createSphere(double radius)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createSphere(swigCPtr, radius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createTorus(double majorRadius, double minorRadius)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createTorus(swigCPtr, majorRadius, minorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createWedge(double xLen, double yLen, double zLen)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createWedge(swigCPtr, xLen, yLen, zLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult extrude(OdDbRegion pRegion, double height, double taperAngle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_extrude__SWIG_0(swigCPtr, OdDbRegion.getCPtr(pRegion), height, taperAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrude(OdDbRegion pRegion, double height)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_extrude__SWIG_1(swigCPtr, OdDbRegion.getCPtr(pRegion), height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult revolve(OdDbRegion pRegion, OdGePoint3d axisPoint, OdGeVector3d axisDir, double angleOfRevolution)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_revolve(swigCPtr, OdDbRegion.getCPtr(pRegion), OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir), angleOfRevolution);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult booleanOper(OdDb_BoolOperType operation, OdDb3dSolid solid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_booleanOper(swigCPtr, (int)operation, getCPtr(solid));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrudeAlongPath(OdDbRegion region, OdDbCurve path, double taperAngle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_extrudeAlongPath__SWIG_0(swigCPtr, OdDbRegion.getCPtr(region), OdDbCurve.getCPtr(path), taperAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrudeAlongPath(OdDbRegion region, OdDbCurve path)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_extrudeAlongPath__SWIG_1(swigCPtr, OdDbRegion.getCPtr(region), OdDbCurve.getCPtr(path));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult imprintEntity(OdDbEntity pEntity)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_imprintEntity(swigCPtr, OdDbEntity.getCPtr(pEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getArea(out double area)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getArea(swigCPtr, out area);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkInterference(OdDb3dSolid otherSolid, bool createNewSolid, out bool solidsInterfere, ref OdDb3dSolid commonVolumeSolid)
	{
		IntPtr jarg = ((commonVolumeSolid == null) ? IntPtr.Zero : getCPtr(commonVolumeSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_checkInterference(swigCPtr, getCPtr(otherSolid), createNewSolid, out solidsInterfere, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				commonVolumeSolid = null;
			}
			else if (jarg != intPtr)
			{
				commonVolumeSolid = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getMassProp(out double volume, OdGePoint3d centroid, double[] momInertia, double[] prodInertia, double[] prinMoments, OdGeVector3d prinAxes, double[] radiiGyration, OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getMassProp(swigCPtr, out volume, OdGePoint3d.getCPtr(centroid), momInertia, prodInertia, prinMoments, OdGeVector3d.getCPtr(prinAxes), radiiGyration, OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSection(OdGePlane plane, ref OdDbRegion sectionRegion)
	{
		IntPtr jarg = ((sectionRegion == null) ? IntPtr.Zero : OdDbRegion.getCPtr(sectionRegion).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getSection(swigCPtr, OdGePlane.getCPtr(plane), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				sectionRegion = null;
			}
			else if (jarg != intPtr)
			{
				sectionRegion = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRegion>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getSlice(OdGePlane plane, bool bGetNegHalfToo, ref OdDb3dSolid pNegHalfSolid)
	{
		IntPtr jarg = ((pNegHalfSolid == null) ? IntPtr.Zero : getCPtr(pNegHalfSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getSlice__SWIG_0(swigCPtr, OdGePlane.getCPtr(plane), bGetNegHalfToo, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pNegHalfSolid = null;
			}
			else if (jarg != intPtr)
			{
				pNegHalfSolid = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getSlice(OdDbSurface pSurface, bool bGetNegHalfToo, ref OdDb3dSolid pNegHalfSolid)
	{
		IntPtr jarg = ((pNegHalfSolid == null) ? IntPtr.Zero : getCPtr(pNegHalfSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getSlice__SWIG_1(swigCPtr, OdDbSurface.getCPtr(pSurface), bGetNegHalfToo, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pNegHalfSolid = null;
			}
			else if (jarg != intPtr)
			{
				pNegHalfSolid = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult cleanBody()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_cleanBody(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult offsetBody(double offsetDistance)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_offsetBody(swigCPtr, offsetDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult separateBody(OdDb3dSolidPtrArray newSolids)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_separateBody(swigCPtr, OdDb3dSolidPtrArray.getCPtr(newSolids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createExtrudedSolid(OdDbEntity pSweepEnt, OdGeVector3d directionVec, OdDbSweepOptions sweepOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createExtrudedSolid__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdGeVector3d.getCPtr(directionVec), OdDbSweepOptions.getCPtr(sweepOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createExtrudedSolid(OdDbEntity pSweepEnt, OdDbSubentId faceSubentId, OdGeVector3d directionVec, OdDbSweepOptions sweepOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createExtrudedSolid__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdDbSubentId.getCPtr(faceSubentId), OdGeVector3d.getCPtr(directionVec), OdDbSweepOptions.getCPtr(sweepOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createExtrudedSolid(OdDbEntity pSweepEnt, OdDbSubentId faceSubentId, double height, OdDbSweepOptions sweepOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createExtrudedSolid__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdDbSubentId.getCPtr(faceSubentId), height, OdDbSweepOptions.getCPtr(sweepOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoftedSolid(OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, OdDbEntity pPathCurve, OdDbLoftOptions loftOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createLoftedSolid(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), OdDbEntity.getCPtr(pPathCurve), OdDbLoftOptions.getCPtr(loftOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createPyramid(double height, int sides, double radius, double topRadius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createPyramid__SWIG_0(swigCPtr, height, sides, radius, topRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createPyramid(double height, int sides, double radius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createPyramid__SWIG_1(swigCPtr, height, sides, radius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createRevolvedSolid(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, double revAngle, double startAngle, OdDbRevolveOptions revolveOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createRevolvedSolid__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), revAngle, startAngle, OdDbRevolveOptions.getCPtr(revolveOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createRevolvedSolid(OdDbEntity pRevEnt, OdDbSubentId faceSubentId, OdGePoint3d axisPnt, OdGeVector3d axisDir, double revAngle, double startAngle, OdDbRevolveOptions revolveOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createRevolvedSolid__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdDbSubentId.getCPtr(faceSubentId), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), revAngle, startAngle, OdDbRevolveOptions.getCPtr(revolveOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSweptSolid(OdDbEntity pSweepEnt, OdDbSubentId faceSubentId, OdDbEntity pPathEnt, OdDbSweepOptions sweepOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createSweptSolid__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdDbSubentId.getCPtr(faceSubentId), OdDbEntity.getCPtr(pPathEnt), OdDbSweepOptions.getCPtr(sweepOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSweptSolid(OdDbEntity pSweepEnt, OdDbEntity pPathEnt, OdDbSweepOptions sweepOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createSweptSolid__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdDbEntity.getCPtr(pPathEnt), OdDbSweepOptions.getCPtr(sweepOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult stlOut(OdStreamBuf output, bool asciiFormat, double maxSurfaceDeviation)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_stlOut__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(output), asciiFormat, maxSurfaceDeviation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult stlOut(OdStreamBuf output, bool asciiFormat)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_stlOut__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(output), asciiFormat);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult stlOut(string filename, bool asciiFormat, double maxSurfaceDeviation)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_stlOut__SWIG_2(swigCPtr, filename, asciiFormat, maxSurfaceDeviation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult stlOut(string filename, bool asciiFormat)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_stlOut__SWIG_3(swigCPtr, filename, asciiFormat);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdDbObject decomposeForSave(DwgVersion ver, OdDbObjectId replaceId, out bool exchangeXData)
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_decomposeForSave(swigCPtr, (int)ver, OdDbObjectId.getCPtr(replaceId), out exchangeXData), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void saveAs(OdGiWorldDraw pWd, DwgVersion ver)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_saveAs(swigCPtr, OdGiWorldDraw.getCPtr(pWd), (int)ver);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult setBody(IntPtr pGeometry)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_setBody(swigCPtr, pGeometry);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual IntPtr body()
	{
		IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_body(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult copyEdge(OdDbSubentId subentId, ref OdDbEntity newEntity)
	{
		IntPtr jarg = ((newEntity == null) ? IntPtr.Zero : OdDbEntity.getCPtr(newEntity).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_copyEdge(swigCPtr, OdDbSubentId.getCPtr(subentId), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				newEntity = null;
			}
			else if (jarg != intPtr)
			{
				newEntity = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult copyFace(OdDbSubentId subentId, ref OdDbEntity newEntity)
	{
		IntPtr jarg = ((newEntity == null) ? IntPtr.Zero : OdDbEntity.getCPtr(newEntity).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_copyFace(swigCPtr, OdDbSubentId.getCPtr(subentId), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				newEntity = null;
			}
			else if (jarg != intPtr)
			{
				newEntity = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public new virtual OdResult subGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_subGetSubentPathsAtGsMarker(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbSubentId internalSubentId(IntPtr ent)
	{
		OdDbSubentId result = new OdDbSubentId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_internalSubentId(swigCPtr, ent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IntPtr internalSubentPtr(OdDbSubentId id)
	{
		IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_internalSubentPtr(swigCPtr, OdDbSubentId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult extrudeFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, double height, double taper)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_extrudeFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), height, taper);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrudeFacesAlongPath(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, OdDbCurve path)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_extrudeFacesAlongPath(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), OdDbCurve.getCPtr(path));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult taperFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, OdGePoint3d basePoint, OdGeVector3d draftVector, double draftAngle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_taperFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(draftVector), draftAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult transformFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, OdGeMatrix3d matrix)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_transformFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), OdGeMatrix3d.getCPtr(matrix).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult removeFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_removeFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult offsetFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, double offsetDistance)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_offsetFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), offsetDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult shellBody(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, double offsetDistance)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_shellBody(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), offsetDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual uint numChanges()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_numChanges(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setSubentColor(OdDbSubentId subentId, OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_setSubentColor(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentColor(OdDbSubentId subentId, OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getSubentColor(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentMaterial(OdDbSubentId subentId, OdDbObjectId matId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_setSubentMaterial(swigCPtr, OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentMaterial(OdDbSubentId subentId, OdDbObjectId matId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getSubentMaterial(swigCPtr, OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentMaterialMapper(OdDbSubentId subentId, OdGiMapper mapper)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_setSubentMaterialMapper(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGiMapper.getCPtr(mapper));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentMaterialMapper(OdDbSubentId subentId, OdGiMapper mapper)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getSubentMaterialMapper(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGiMapper.getCPtr(mapper));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult chamferEdges(OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDbSubentId baseFaceSubentId, double baseDist, double otherDist)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_chamferEdges(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDbSubentId.getCPtr(baseFaceSubentId), baseDist, otherDist);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult filletEdges(OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDoubleArray radius, OdDoubleArray startSetback, OdDoubleArray endSetback)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_filletEdges(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDoubleArray.getCPtr(radius).Handle, OdDoubleArray.getCPtr(startSetback).Handle, OdDoubleArray.getCPtr(endSetback).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createFrom(OdDbEntity pFromEntity)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createFrom(swigCPtr, OdDbEntity.getCPtr(pFromEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool recordHistory()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_recordHistory(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool showHistory()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_showHistory(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setRecordHistory(bool bRecord)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_setRecordHistory(swigCPtr, bRecord);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setShowHistory(bool bShow)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_setShowHistory(swigCPtr, bShow);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult convertToBrepAtSubentPaths(OdDbFullSubentPathArray arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_convertToBrepAtSubentPaths(swigCPtr, OdDbFullSubentPathArray.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult projectOnToSolid(OdDbEntity pEntityToProject, OdGeVector3d projectionDirection, OdDbEntityPtrArray projectedEntities)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_projectOnToSolid(swigCPtr, OdDbEntity.getCPtr(pEntityToProject), OdGeVector3d.getCPtr(projectionDirection), OdDbEntityPtrArray.getCPtr(projectedEntities));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult createSculptedSolid(OdDbEntityPtrArray limitingBodies, OdIntArray limitingFlags)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_createSculptedSolid(swigCPtr, OdDbEntityPtrArray.getCPtr(limitingBodies), OdIntArray.getCPtr(limitingFlags).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void subClose()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_subClose(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb3dSolid_GeomType determineGeomType(bool byBrep, SWIGTYPE_p_p_OdDb3dSolidGeomParams params_)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_determineGeomType__SWIG_0(swigCPtr, byBrep, SWIGTYPE_p_p_OdDb3dSolidGeomParams.getCPtr(params_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb3dSolid_GeomType)result;
	}

	public OdDb3dSolid_GeomType determineGeomType(bool byBrep)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_determineGeomType__SWIG_1(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb3dSolid_GeomType)result;
	}

	public OdDb3dSolid_GeomType determineGeomType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_determineGeomType__SWIG_2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb3dSolid_GeomType)result;
	}

	public bool isSphere(bool byBrep, double radius, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSphere__SWIG_0(swigCPtr, byBrep, radius, OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSphere(bool byBrep, double radius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSphere__SWIG_1(swigCPtr, byBrep, radius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSphere(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSphere__SWIG_2(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSphere()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSphere__SWIG_3(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus(bool byBrep, double majorRadius, double minorRadius, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isTorus__SWIG_0(swigCPtr, byBrep, majorRadius, minorRadius, OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus(bool byBrep, double majorRadius, double minorRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isTorus__SWIG_1(swigCPtr, byBrep, majorRadius, minorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus(bool byBrep, double majorRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isTorus__SWIG_2(swigCPtr, byBrep, majorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isTorus__SWIG_3(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isTorus__SWIG_4(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder(bool byBrep, double height, double majorRadius, double minorRadius, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCylinder__SWIG_0(swigCPtr, byBrep, height, majorRadius, minorRadius, OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder(bool byBrep, double height, double majorRadius, double minorRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCylinder__SWIG_1(swigCPtr, byBrep, height, majorRadius, minorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder(bool byBrep, double height, double majorRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCylinder__SWIG_2(swigCPtr, byBrep, height, majorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder(bool byBrep, double height)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCylinder__SWIG_3(swigCPtr, byBrep, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCylinder__SWIG_4(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCylinder__SWIG_5(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone(bool byBrep, double height, double majorRadius, double minorRadius, double topMajorRadius, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCone__SWIG_0(swigCPtr, byBrep, height, majorRadius, minorRadius, topMajorRadius, OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone(bool byBrep, double height, double majorRadius, double minorRadius, double topMajorRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCone__SWIG_1(swigCPtr, byBrep, height, majorRadius, minorRadius, topMajorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone(bool byBrep, double height, double majorRadius, double minorRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCone__SWIG_2(swigCPtr, byBrep, height, majorRadius, minorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone(bool byBrep, double height, double majorRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCone__SWIG_3(swigCPtr, byBrep, height, majorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone(bool byBrep, double height)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCone__SWIG_4(swigCPtr, byBrep, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCone__SWIG_5(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isCone__SWIG_6(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox(bool byBrep, double xLen, double yLen, double zLen, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isBox__SWIG_0(swigCPtr, byBrep, xLen, yLen, zLen, OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox(bool byBrep, double xLen, double yLen, double zLen)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isBox__SWIG_1(swigCPtr, byBrep, xLen, yLen, zLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox(bool byBrep, double xLen, double yLen)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isBox__SWIG_2(swigCPtr, byBrep, xLen, yLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox(bool byBrep, double xLen)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isBox__SWIG_3(swigCPtr, byBrep, xLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isBox__SWIG_4(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBox()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isBox__SWIG_5(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isWedge(bool byBrep, double xLen, double yLen, double zLen, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isWedge__SWIG_0(swigCPtr, byBrep, xLen, yLen, zLen, OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isWedge(bool byBrep, double xLen, double yLen, double zLen)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isWedge__SWIG_1(swigCPtr, byBrep, xLen, yLen, zLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isWedge(bool byBrep, double xLen, double yLen)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isWedge__SWIG_2(swigCPtr, byBrep, xLen, yLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isWedge(bool byBrep, double xLen)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isWedge__SWIG_3(swigCPtr, byBrep, xLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isWedge(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isWedge__SWIG_4(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isWedge()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isWedge__SWIG_5(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPyramid(bool byBrep, double height, int sides, double radius, double topRadius, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isPyramid__SWIG_0(swigCPtr, byBrep, height, sides, radius, topRadius, OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPyramid(bool byBrep, double height, int sides, double radius, double topRadius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isPyramid__SWIG_1(swigCPtr, byBrep, height, sides, radius, topRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPyramid(bool byBrep, double height, int sides, double radius)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isPyramid__SWIG_2(swigCPtr, byBrep, height, sides, radius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPyramid(bool byBrep, double height, int sides)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isPyramid__SWIG_3(swigCPtr, byBrep, height, sides);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPyramid(bool byBrep, double height)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isPyramid__SWIG_4(swigCPtr, byBrep, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPyramid(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isPyramid__SWIG_5(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPyramid()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isPyramid__SWIG_6(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExtrusion(bool byBrep, OdGeVector3d direction, SWIGTYPE_p_p_OdDbEntity extrusionEntity, OdDbSweepOptions options, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isExtrusion__SWIG_0(swigCPtr, byBrep, OdGeVector3d.getCPtr(direction), SWIGTYPE_p_p_OdDbEntity.getCPtr(extrusionEntity), OdDbSweepOptions.getCPtr(options), OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExtrusion(bool byBrep, OdGeVector3d direction, SWIGTYPE_p_p_OdDbEntity extrusionEntity, OdDbSweepOptions options)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isExtrusion__SWIG_1(swigCPtr, byBrep, OdGeVector3d.getCPtr(direction), SWIGTYPE_p_p_OdDbEntity.getCPtr(extrusionEntity), OdDbSweepOptions.getCPtr(options));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExtrusion(bool byBrep, OdGeVector3d direction, SWIGTYPE_p_p_OdDbEntity extrusionEntity)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isExtrusion__SWIG_2(swigCPtr, byBrep, OdGeVector3d.getCPtr(direction), SWIGTYPE_p_p_OdDbEntity.getCPtr(extrusionEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExtrusion(bool byBrep, OdGeVector3d direction)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isExtrusion__SWIG_3(swigCPtr, byBrep, OdGeVector3d.getCPtr(direction));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExtrusion(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isExtrusion__SWIG_4(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExtrusion()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isExtrusion__SWIG_5(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSweep(bool byBrep, SWIGTYPE_p_p_OdDbEntity sweepEntity, SWIGTYPE_p_p_OdDbEntity pathEntity, OdDbSweepOptions options, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSweep__SWIG_0(swigCPtr, byBrep, SWIGTYPE_p_p_OdDbEntity.getCPtr(sweepEntity), SWIGTYPE_p_p_OdDbEntity.getCPtr(pathEntity), OdDbSweepOptions.getCPtr(options), OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSweep(bool byBrep, SWIGTYPE_p_p_OdDbEntity sweepEntity, SWIGTYPE_p_p_OdDbEntity pathEntity, OdDbSweepOptions options)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSweep__SWIG_1(swigCPtr, byBrep, SWIGTYPE_p_p_OdDbEntity.getCPtr(sweepEntity), SWIGTYPE_p_p_OdDbEntity.getCPtr(pathEntity), OdDbSweepOptions.getCPtr(options));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSweep(bool byBrep, SWIGTYPE_p_p_OdDbEntity sweepEntity, SWIGTYPE_p_p_OdDbEntity pathEntity)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSweep__SWIG_2(swigCPtr, byBrep, SWIGTYPE_p_p_OdDbEntity.getCPtr(sweepEntity), SWIGTYPE_p_p_OdDbEntity.getCPtr(pathEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSweep(bool byBrep, SWIGTYPE_p_p_OdDbEntity sweepEntity)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSweep__SWIG_3(swigCPtr, byBrep, SWIGTYPE_p_p_OdDbEntity.getCPtr(sweepEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSweep(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSweep__SWIG_4(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSweep()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isSweep__SWIG_5(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLoft(bool byBrep, OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, SWIGTYPE_p_p_OdDbEntity pathCurve, OdDbLoftOptions options, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isLoft__SWIG_0(swigCPtr, byBrep, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), SWIGTYPE_p_p_OdDbEntity.getCPtr(pathCurve), OdDbLoftOptions.getCPtr(options), OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLoft(bool byBrep, OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, SWIGTYPE_p_p_OdDbEntity pathCurve, OdDbLoftOptions options)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isLoft__SWIG_1(swigCPtr, byBrep, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), SWIGTYPE_p_p_OdDbEntity.getCPtr(pathCurve), OdDbLoftOptions.getCPtr(options));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLoft(bool byBrep, OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, SWIGTYPE_p_p_OdDbEntity pathCurve)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isLoft__SWIG_2(swigCPtr, byBrep, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), SWIGTYPE_p_p_OdDbEntity.getCPtr(pathCurve));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLoft(bool byBrep, OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isLoft__SWIG_3(swigCPtr, byBrep, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLoft(bool byBrep, OdDbEntityPtrArray crossSectionCurves)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isLoft__SWIG_4(swigCPtr, byBrep, OdDbEntityPtrArray.getCPtr(crossSectionCurves));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLoft(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isLoft__SWIG_5(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLoft()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isLoft__SWIG_6(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep, double revolveAngle, double startAngle, OdGePoint3d axisPoint, OdGeVector3d axisDir, SWIGTYPE_p_p_OdDbEntity revolveEntity, OdDbRevolveOptions options, OdGeMatrix3d matrix)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_0(swigCPtr, byBrep, revolveAngle, startAngle, OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir), SWIGTYPE_p_p_OdDbEntity.getCPtr(revolveEntity), OdDbRevolveOptions.getCPtr(options), OdGeMatrix3d.getCPtr(matrix));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep, double revolveAngle, double startAngle, OdGePoint3d axisPoint, OdGeVector3d axisDir, SWIGTYPE_p_p_OdDbEntity revolveEntity, OdDbRevolveOptions options)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_1(swigCPtr, byBrep, revolveAngle, startAngle, OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir), SWIGTYPE_p_p_OdDbEntity.getCPtr(revolveEntity), OdDbRevolveOptions.getCPtr(options));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep, double revolveAngle, double startAngle, OdGePoint3d axisPoint, OdGeVector3d axisDir, SWIGTYPE_p_p_OdDbEntity revolveEntity)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_2(swigCPtr, byBrep, revolveAngle, startAngle, OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir), SWIGTYPE_p_p_OdDbEntity.getCPtr(revolveEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep, double revolveAngle, double startAngle, OdGePoint3d axisPoint, OdGeVector3d axisDir)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_3(swigCPtr, byBrep, revolveAngle, startAngle, OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep, double revolveAngle, double startAngle, OdGePoint3d axisPoint)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_4(swigCPtr, byBrep, revolveAngle, startAngle, OdGePoint3d.getCPtr(axisPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep, double revolveAngle, double startAngle)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_5(swigCPtr, byBrep, revolveAngle, startAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep, double revolveAngle)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_6(swigCPtr, byBrep, revolveAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve(bool byBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_7(swigCPtr, byBrep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRevolve()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_isRevolve__SWIG_8(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void copyFrom(OdRxObject pSource)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool SubWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void SubViewportDraw(OdGiViewportDraw pVd)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubTransformBy(OdGeMatrix3d xfm)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubGetSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubGetSubentPathsAtGsMarker(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult SubGetGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubGetGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbEntity SubSubentPtr(OdDbFullSubentPath id)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubSubentPtr(swigCPtr, OdDbFullSubentPath.getCPtr(id)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override uint SubSetAttributes(OdGiDrawableTraits pTraits)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(pTraits));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult SubGetGeomExtents(OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_SubGetGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolid_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
