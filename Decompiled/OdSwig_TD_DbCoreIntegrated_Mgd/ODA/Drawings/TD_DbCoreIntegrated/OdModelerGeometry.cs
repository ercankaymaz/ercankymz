using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdModelerGeometry : OdRxObject
{
	public class NumIsolines : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint numU
		{
			get
			{
				uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_NumIsolines_numU_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_NumIsolines_numU_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public uint numV
		{
			get
			{
				uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_NumIsolines_numV_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_NumIsolines_numV_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NumIsolines(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(NumIsolines obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~NumIsolines()
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
						TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdModelerGeometry_NumIsolines(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public NumIsolines()
			: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdModelerGeometry_NumIsolines(), cMemoryOwn: true)
		{
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdModelerGeometry(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdModelerGeometry obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdModelerGeometry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdModelerGeometry cast(OdRxObject pObj)
	{
		OdModelerGeometry rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdModelerGeometry createObject()
	{
		OdModelerGeometry rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult in_(OdStreamBuf pStreamBuf, out int typeVer, bool standardSaveFlag)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_in___SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), out typeVer, standardSaveFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult in_(OdStreamBuf pStreamBuf, out int typeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_in___SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), out typeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult in_(OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_in___SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult out_(OdStreamBuf pStreamBuf, int typeVer, bool standardSaveFlag)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_out___SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), typeVer, standardSaveFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult out_(OdStreamBuf pStreamBuf, int typeVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_out___SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), typeVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool brep(OdBrBrep brBrep)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_brep(swigCPtr, OdBrBrep.getCPtr(brBrep));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getEdgeSubentityGeometry(OdUInt32ValuesArray indexesOfEdgeCalculation, out OdGeCurve3d pEdgeCurve)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getEdgeSubentityGeometry(swigCPtr, OdUInt32ValuesArray.getCPtr(indexesOfEdgeCalculation), out jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, bIsWrapperOwnNativeObject: true));
			pEdgeCurve = ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, currentTransaction == null);
		}
	}

	public virtual OdResult setSubentPath(OdBrEntity arg0, OdDbFullSubentPath arg1)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setSubentPath(swigCPtr, OdBrEntity.getCPtr(arg0), OdDbFullSubentPath.getCPtr(arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult generateMesh(OdBrMesh2dFilter arg0, OdBrMesh2d arg1)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_generateMesh(swigCPtr, OdBrMesh2dFilter.getCPtr(arg0), OdBrMesh2d.getCPtr(arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool setFACETRES(double facetRes)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setFACETRES(swigCPtr, facetRes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool worldDraw(OdGiCommonDraw pWd, uint geomType, NumIsolines pNumIsolines)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_worldDraw__SWIG_0(swigCPtr, OdGiCommonDraw.getCPtr(pWd), geomType, NumIsolines.getCPtr(pNumIsolines));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool worldDraw(OdGiCommonDraw pWd, uint geomType)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_worldDraw__SWIG_1(swigCPtr, OdGiCommonDraw.getCPtr(pWd), geomType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool drawSilhouettes(OdGiViewportDraw pVd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_drawSilhouettes(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getCachedSilhouettes(OdGeCurve3dPtrArray cachedSilhouettes)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getCachedSilhouettes(swigCPtr, OdGeCurve3dPtrArray.getCPtr(cachedSilhouettes).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool getTransformation(OdGeMatrix3d xfm)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getTransformation(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void transformBy(OdGeMatrix3d xfm)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createBox(double xLen, double yLen, double zLen)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createBox(swigCPtr, xLen, yLen, zLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createFrustum(double height, double xRadius, double yRadius, double topXRadius)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createFrustum(swigCPtr, height, xRadius, yRadius, topXRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createSphere(double radius)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createSphere(swigCPtr, radius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createTorus(double majorRadius, double minorRadius)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createTorus(swigCPtr, majorRadius, minorRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void createWedge(double xLen, double yLen, double zLen)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createWedge(swigCPtr, xLen, yLen, zLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult extrude(OdDbRegion pRegion, double height, double taperAngle, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extrude__SWIG_0(swigCPtr, OdDbRegion.getCPtr(pRegion), height, taperAngle, isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrude(OdDbRegion pRegion, double height, double taperAngle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extrude__SWIG_1(swigCPtr, OdDbRegion.getCPtr(pRegion), height, taperAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult revolve(OdDbRegion pRegion, OdGePoint3d axisPoint, OdGeVector3d axisDir, double angleOfRevolution, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_revolve__SWIG_0(swigCPtr, OdDbRegion.getCPtr(pRegion), OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir), angleOfRevolution, isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult revolve(OdDbRegion pRegion, OdGePoint3d axisPoint, OdGeVector3d axisDir, double angleOfRevolution)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_revolve__SWIG_1(swigCPtr, OdDbRegion.getCPtr(pRegion), OdGePoint3d.getCPtr(axisPoint), OdGeVector3d.getCPtr(axisDir), angleOfRevolution);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void ClearColorAttributes()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_ClearColorAttributes(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ClearMaterialAttributes(OdArray_OdDbSubentId_OdObjectsAllocator aSubents)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_ClearMaterialAttributes__SWIG_0(swigCPtr, OdArray_OdDbSubentId_OdObjectsAllocator.getCPtr(aSubents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ClearMaterialAttributes()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_ClearMaterialAttributes__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ClearMaterialMapperAttributes()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_ClearMaterialMapperAttributes(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdModelerGeometry_MaterialState hasMaterials()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_hasMaterials(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdModelerGeometry_MaterialState)result;
	}

	public virtual bool hasTrueColorAttributes()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_hasTrueColorAttributes(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getPlane(OdGePlane regionPlane)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getPlane(swigCPtr, OdGePlane.getCPtr(regionPlane));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool setMMPerUnit(double mmPerUnit)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setMMPerUnit(swigCPtr, mmPerUnit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMMPerUnit(out double mmPerUnit)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getMMPerUnit(swigCPtr, out mmPerUnit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdModelerGeometry_geomType bodyType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_bodyType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdModelerGeometry_geomType)result;
	}

	public virtual bool explode(OdModelerGeometry_geomType typeThis, OdDbEntityPtrArray entitySet)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_explode(swigCPtr, (int)typeThis, OdDbEntityPtrArray.getCPtr(entitySet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult booleanOper(OdDbDatabase database, OdDb_BoolOperType operation, OdModelerGeometry otherBody, OdModelerGeometry_geomType typeThis, OdModelerGeometry_geomType typeOther)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_booleanOper__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(database), (int)operation, getCPtr(otherBody), (int)typeThis, (int)typeOther);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult booleanOper(OdDbDatabase database, OdDb_BoolOperType operation, OdModelerGeometry otherBody, OdModelerGeometry_geomType typeThis, OdModelerGeometry_geomType typeOther, ref OdModelerGeometry result, OdDbEntityPtrArray intersectionEntities)
	{
		IntPtr jarg = ((result == null) ? IntPtr.Zero : getCPtr(result).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result2 = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_booleanOper__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(database), (int)operation, getCPtr(otherBody), (int)typeThis, (int)typeOther, ref jarg, OdDbEntityPtrArray.getCPtr(intersectionEntities));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result2;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				result = null;
			}
			else if (jarg != intPtr)
			{
				result = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult booleanOper(OdDbDatabase database, OdDb_BoolOperType operation, OdModelerGeometry otherBody, OdModelerGeometry_geomType typeThis, OdModelerGeometry_geomType typeOther, ref OdModelerGeometry result)
	{
		IntPtr jarg = ((result == null) ? IntPtr.Zero : getCPtr(result).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result2 = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_booleanOper__SWIG_2(swigCPtr, OdDbDatabase.getCPtr(database), (int)operation, getCPtr(otherBody), (int)typeThis, (int)typeOther, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result2;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				result = null;
			}
			else if (jarg != intPtr)
			{
				result = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult checkInterference(OdDbDatabase database, OdModelerGeometry otherSolid, bool createNewSolid, out bool solidsInterfere, ref OdDb3dSolid commonVolumeSolid)
	{
		IntPtr jarg = ((commonVolumeSolid == null) ? IntPtr.Zero : OdDb3dSolid.getCPtr(commonVolumeSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkInterference(swigCPtr, OdDbDatabase.getCPtr(database), getCPtr(otherSolid), createNewSolid, out solidsInterfere, ref jarg);
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

	public virtual OdResult getArea(out double regionArea)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getArea(swigCPtr, out regionArea);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getPerimeter(out double arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getPerimeter(swigCPtr, out arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getAreaProp(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis, out double perimeter, out double area, OdGePoint2d centroid, double[] momInertia, out double prodInertia, double[] prinMoments, OdGeVector2d prinAxes, double[] radiiGyration, OdGePoint2d extentsLow, OdGePoint2d extentsHigh)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getAreaProp(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), out perimeter, out area, OdGePoint2d.getCPtr(centroid), momInertia, out prodInertia, prinMoments, OdGeVector2d.getCPtr(prinAxes), radiiGyration, OdGePoint2d.getCPtr(extentsLow), OdGePoint2d.getCPtr(extentsHigh));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult clear()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrudeAlongPath(OdDbRegion region, OdDbCurve path, double taperAngle, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extrudeAlongPath__SWIG_0(swigCPtr, OdDbRegion.getCPtr(region), OdDbCurve.getCPtr(path), taperAngle, isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrudeAlongPath(OdDbRegion region, OdDbCurve path, double taperAngle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extrudeAlongPath__SWIG_1(swigCPtr, OdDbRegion.getCPtr(region), OdDbCurve.getCPtr(path), taperAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrudeAlongPath(OdDbRegion region, OdDbCurve path)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extrudeAlongPath__SWIG_2(swigCPtr, OdDbRegion.getCPtr(region), OdDbCurve.getCPtr(path));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult imprintEntity(OdDbEntity pEntity)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_imprintEntity(swigCPtr, OdDbEntity.getCPtr(pEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getMassProp(out double volume, OdGePoint3d centroid, double[] momInertia, double[] prodInertia, double[] prinMoments, OdGeVector3d prinAxes, double[] radiiGyration, OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getMassProp(swigCPtr, out volume, OdGePoint3d.getCPtr(centroid), momInertia, prodInertia, prinMoments, OdGeVector3d.getCPtr(prinAxes), radiiGyration, OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSection(OdGePlane plane, ref OdDbRegion sectionRegion, OdDbEntityPtrArray pSectionCurves)
	{
		IntPtr jarg = ((sectionRegion == null) ? IntPtr.Zero : OdDbRegion.getCPtr(sectionRegion).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSection__SWIG_0(swigCPtr, OdGePlane.getCPtr(plane), ref jarg, OdDbEntityPtrArray.getCPtr(pSectionCurves));
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

	public virtual OdResult getSection(OdGePlane plane, ref OdDbRegion sectionRegion)
	{
		IntPtr jarg = ((sectionRegion == null) ? IntPtr.Zero : OdDbRegion.getCPtr(sectionRegion).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSection__SWIG_1(swigCPtr, OdGePlane.getCPtr(plane), ref jarg);
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

	public virtual OdResult getSlice(OdGePlane plane, bool getNegHalfToo, ref OdDb3dSolid negHalfSolid)
	{
		IntPtr jarg = ((negHalfSolid == null) ? IntPtr.Zero : OdDb3dSolid.getCPtr(negHalfSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSlice__SWIG_0(swigCPtr, OdGePlane.getCPtr(plane), getNegHalfToo, ref jarg);
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
				negHalfSolid = null;
			}
			else if (jarg != intPtr)
			{
				negHalfSolid = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getSlice(OdDbSurface pSurface, bool bGetNegHalfToo, ref OdDb3dSolid pNegHalfSolid)
	{
		IntPtr jarg = ((pNegHalfSolid == null) ? IntPtr.Zero : OdDb3dSolid.getCPtr(pNegHalfSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSlice__SWIG_1(swigCPtr, OdDbSurface.getCPtr(pSurface), bGetNegHalfToo, ref jarg);
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
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_cleanBody(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult offsetBody(double offsetDistance)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_offsetBody(swigCPtr, offsetDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult separateBody(OdDb3dSolidPtrArray newSolids)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_separateBody(swigCPtr, OdDb3dSolidPtrArray.getCPtr(newSolids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createExtrudedObject(OdDbEntity pSweepEnt, OdGeVector3d directionVec, OdDbSweepOptions sweepOptions, bool isSolid, bool bHistoryEnabled)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createExtrudedObject__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdGeVector3d.getCPtr(directionVec), OdDbSweepOptions.getCPtr(sweepOptions), isSolid, bHistoryEnabled);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createExtrudedObject(OdDbEntity pSweepEnt, OdGeVector3d directionVec, OdDbSweepOptions sweepOptions, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createExtrudedObject__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdGeVector3d.getCPtr(directionVec), OdDbSweepOptions.getCPtr(sweepOptions), isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createExtrudedObject(OdDbEntity pSweepEnt, OdGeVector3d directionVec, OdDbSweepOptions sweepOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createExtrudedObject__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdGeVector3d.getCPtr(directionVec), OdDbSweepOptions.getCPtr(sweepOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoftedObject(OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, OdDbEntity pPathCurve, OdDbLoftOptions loftOptions, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createLoftedObject__SWIG_0(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), OdDbEntity.getCPtr(pPathCurve), OdDbLoftOptions.getCPtr(loftOptions), isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createLoftedObject(OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, OdDbEntity pPathCurve, OdDbLoftOptions loftOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createLoftedObject__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), OdDbEntity.getCPtr(pPathCurve), OdDbLoftOptions.getCPtr(loftOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createBlendObject(OdDbEntityPtrArray blendedEdges, OdDbBlendOptions blendOptions, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createBlendObject__SWIG_0(swigCPtr, OdDbEntityPtrArray.getCPtr(blendedEdges), OdDbBlendOptions.getCPtr(blendOptions), isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createBlendObject(OdDbEntityPtrArray blendedEdges, OdDbBlendOptions blendOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createBlendObject__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(blendedEdges), OdDbBlendOptions.getCPtr(blendOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createPyramid(double height, int sides, double radius, double topRadius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createPyramid__SWIG_0(swigCPtr, height, sides, radius, topRadius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createPyramid(double height, int sides, double radius)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createPyramid__SWIG_1(swigCPtr, height, sides, radius);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createRevolvedObject(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, double revAngle, double startAngle, OdDbRevolveOptions revolveOptions, bool isSolid, bool bHistoryEnabled)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createRevolvedObject__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), revAngle, startAngle, OdDbRevolveOptions.getCPtr(revolveOptions), isSolid, bHistoryEnabled);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createRevolvedObject(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, double revAngle, double startAngle, OdDbRevolveOptions revolveOptions, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createRevolvedObject__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), revAngle, startAngle, OdDbRevolveOptions.getCPtr(revolveOptions), isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createRevolvedObject(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, double revAngle, double startAngle, OdDbRevolveOptions revolveOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createRevolvedObject__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), revAngle, startAngle, OdDbRevolveOptions.getCPtr(revolveOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSweptObject(OdDbEntity pSweepEnt, OdDbEntity pPathEnt, OdDbSweepOptions sweepOptions, bool isSolid, bool bHistoryEnabled)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createSweptObject__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdDbEntity.getCPtr(pPathEnt), OdDbSweepOptions.getCPtr(sweepOptions), isSolid, bHistoryEnabled);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSweptObject(OdDbEntity pSweepEnt, OdDbEntity pPathEnt, OdDbSweepOptions sweepOptions, bool isSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createSweptObject__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdDbEntity.getCPtr(pPathEnt), OdDbSweepOptions.getCPtr(sweepOptions), isSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSweptObject(OdDbEntity pSweepEnt, OdDbEntity pPathEnt, OdDbSweepOptions sweepOptions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createSweptObject__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), OdDbEntity.getCPtr(pPathEnt), OdDbSweepOptions.getCPtr(sweepOptions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkCrossSectionCurves(OdDbEntityPtrArray crossSectionCurves, out bool allOpen, out bool allClosed, out bool allPlanar, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkCrossSectionCurves__SWIG_0(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), out allOpen, out allClosed, out allPlanar, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkCrossSectionCurves(OdDbEntityPtrArray crossSectionCurves, out bool allOpen, out bool allClosed, out bool allPlanar)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkCrossSectionCurves__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), out allOpen, out allClosed, out allPlanar);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkGuideCurves(OdDbEntityPtrArray guideCurves, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkGuideCurves__SWIG_0(swigCPtr, OdDbEntityPtrArray.getCPtr(guideCurves), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkGuideCurves(OdDbEntityPtrArray guideCurves)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkGuideCurves__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(guideCurves));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkPathCurve(OdDbEntity pPathCurve, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkPathCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pPathCurve), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkPathCurve(OdDbEntity pPathCurve)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkPathCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pPathCurve));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkSweepCurve(OdDbEntity pSweepEnt, out OdDb_Planarity planarity, OdGePoint3d pnt, OdGeVector3d vec, out bool closed, out double approxArcLen, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkSweepCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), out planarity, OdGePoint3d.getCPtr(pnt), OdGeVector3d.getCPtr(vec), out closed, out approxArcLen, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkSweepCurve(OdDbEntity pSweepEnt, out OdDb_Planarity planarity, OdGePoint3d pnt, OdGeVector3d vec, out bool closed, out double approxArcLen)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkSweepCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), out planarity, OdGePoint3d.getCPtr(pnt), OdGeVector3d.getCPtr(vec), out closed, out approxArcLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkSweepPathCurve(OdDbEntity pPathEnt, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkSweepPathCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pPathEnt), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkSweepPathCurve(OdDbEntity pPathEnt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkSweepPathCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pPathEnt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkRevolveCurve(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, out bool closed, out bool endPointsOnAxis, out bool planar, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkRevolveCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), out closed, out endPointsOnAxis, out planar, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult checkRevolveCurve(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, out bool closed, out bool endPointsOnAxis, out bool planar)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_checkRevolveCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), out closed, out endPointsOnAxis, out planar);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createFrom(OdDbEntity pFromEntity, bool bFrom3dSolid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createFrom(swigCPtr, OdDbEntity.getCPtr(pFromEntity), bFrom3dSolid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult convertToRegion(OdDbEntityPtrArray regions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_convertToRegion(swigCPtr, OdDbEntityPtrArray.getCPtr(regions));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult thicken(double thickness, bool bBothSides, ref OdDb3dSolid pSolid)
	{
		IntPtr jarg = ((pSolid == null) ? IntPtr.Zero : OdDb3dSolid.getCPtr(pSolid).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_thicken(swigCPtr, thickness, bBothSides, ref jarg);
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
				pSolid = null;
			}
			else if (jarg != intPtr)
			{
				pSolid = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dSolid>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult intersectWith(OdDbEntity ent, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_intersectWith__SWIG_0(swigCPtr, OdDbEntity.getCPtr(ent), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity ent, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_intersectWith__SWIG_1(swigCPtr, OdDbEntity.getCPtr(ent), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult copySubEntity(OdDbSubentId subentId, ref OdDbEntity newEntity)
	{
		IntPtr jarg = ((newEntity == null) ? IntPtr.Zero : OdDbEntity.getCPtr(newEntity).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_copySubEntity(swigCPtr, OdDbSubentId.getCPtr(subentId), ref jarg);
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

	public virtual OdResult taperFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, OdGePoint3d basePoint, OdGeVector3d draftVector, double draftAngle)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_taperFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), OdGePoint3d.getCPtr(basePoint), OdGeVector3d.getCPtr(draftVector), draftAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult removeFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_removeFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult offsetFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, double offsetDistance)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_offsetFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), offsetDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult shellBody(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, double offsetDistance)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_shellBody(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), offsetDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult transformFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, OdGeMatrix3d matrix)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_transformFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), OdGeMatrix3d.getCPtr(matrix).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray entAndInsertStack)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSubentPathsAtGsMarker__SWIG_0(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(entAndInsertStack));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathsAtGsMarker(OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSubentPathsAtGsMarker__SWIG_1(swigCPtr, (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGsMarkersAtSubentPath(OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getGsMarkersAtSubentPath(swigCPtr, OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbSubentId internalSubentId(IntPtr ent)
	{
		OdDbSubentId result = new OdDbSubentId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_internalSubentId(swigCPtr, ent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IntPtr internalSubentPtr(OdDbSubentId id)
	{
		IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_internalSubentPtr(swigCPtr, OdDbSubentId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getNurbCurvesCache(OdGeCurve3dPtrArray arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNurbCurvesCache(swigCPtr, OdGeCurve3dPtrArray.getCPtr(arg0).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setBody(IntPtr arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setBody(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual IntPtr body()
	{
		IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_body(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setSubentColor(OdDbSubentId subentId, OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setSubentColor(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentColor(OdDbSubentId subentId, OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSubentColor(swigCPtr, OdDbSubentId.getCPtr(subentId), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentMaterial(OdDbSubentId subentId, OdDbObjectId matId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setSubentMaterial(swigCPtr, OdDbSubentId.getCPtr(subentId), OdDbObjectId.getCPtr(matId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentMaterial(OdDbSubentId subentId, out ulong matId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSubentMaterial(swigCPtr, OdDbSubentId.getCPtr(subentId), out matId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubentMaterialMapper(OdDbSubentId subentId, OdGeMatrix3d mx, out byte projection, out byte tiling, out byte autoTransform)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setSubentMaterialMapper(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGeMatrix3d.getCPtr(mx), out projection, out tiling, out autoTransform);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentMaterialMapper(OdDbSubentId subentId, OdGeMatrix3d mx, out byte projection, out byte tiling, out byte autoTransform)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getSubentMaterialMapper(swigCPtr, OdDbSubentId.getCPtr(subentId), OdGeMatrix3d.getCPtr(mx), out projection, out tiling, out autoTransform);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult chamferEdges(OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDbSubentId baseFaceSubentId, double baseDist, double otherDist)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_chamferEdges(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDbSubentId.getCPtr(baseFaceSubentId), baseDist, otherDist);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult filletEdges(OdArray_OdDbSubentId__p_OdObjectsAllocator edgeSubentIds, OdDoubleArray radius, OdDoubleArray startSetback, OdDoubleArray endSetback)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_filletEdges(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(edgeSubentIds), OdDoubleArray.getCPtr(radius).Handle, OdDoubleArray.getCPtr(startSetback).Handle, OdDoubleArray.getCPtr(endSetback).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSectionObjects(OdGePlane sectionPlane, OdDbEntityPtrArray sectionObjects)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createSectionObjects(swigCPtr, OdGePlane.getCPtr(sectionPlane), OdDbEntityPtrArray.getCPtr(sectionObjects));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult sliceByPlane(OdGePlane slicePlane, ref OdDbSurface pNegHalfSurface, ref OdDbSurface pNewSurface, bool bNotModifyItself)
	{
		IntPtr jarg = ((pNegHalfSurface == null) ? IntPtr.Zero : OdDbSurface.getCPtr(pNegHalfSurface).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((pNewSurface == null) ? IntPtr.Zero : OdDbSurface.getCPtr(pNewSurface).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_sliceByPlane(swigCPtr, OdGePlane.getCPtr(slicePlane), ref jarg, ref jarg2, bNotModifyItself);
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
				pNegHalfSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNegHalfSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				pNewSurface = null;
			}
			else if (jarg2 != intPtr2)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult sliceBySurface(OdDbSurface pSlicingSurface, ref OdDbSurface pNegHalfSurface, ref OdDbSurface pNewSurface, bool bNotModifyItself)
	{
		IntPtr jarg = ((pNegHalfSurface == null) ? IntPtr.Zero : OdDbSurface.getCPtr(pNegHalfSurface).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((pNewSurface == null) ? IntPtr.Zero : OdDbSurface.getCPtr(pNewSurface).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_sliceBySurface(swigCPtr, OdDbSurface.getCPtr(pSlicingSurface), ref jarg, ref jarg2, bNotModifyItself);
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
				pNegHalfSurface = null;
			}
			else if (jarg != intPtr)
			{
				pNegHalfSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				pNewSurface = null;
			}
			else if (jarg2 != intPtr2)
			{
				pNewSurface = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult extrudeFaces(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, double height, double taper)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extrudeFaces(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), height, taper);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extrudeFacesAlongPath(OdArray_OdDbSubentId__p_OdObjectsAllocator faceSubentIds, OdDbCurve path)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extrudeFacesAlongPath(swigCPtr, OdArray_OdDbSubentId__p_OdObjectsAllocator.getCPtr(faceSubentIds), OdDbCurve.getCPtr(path));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult ChangeFacesDoubleSidedParam(bool isDoubleSided)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_ChangeFacesDoubleSidedParam(swigCPtr, isDoubleSided);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult convertToNurbSurface(OdDbNurbSurfacePtrArray nurbSurfaceArray)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_convertToNurbSurface(swigCPtr, OdDbNurbSurfacePtrArray.getCPtr(nurbSurfaceArray));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult get(out int iUDegree, out int iVDegree, out bool bRational, out int iUNumControlPoints, out int iVNumControlPoints, OdGePoint3dArray ctrlPtsArr, OdDoubleArray weights, OdGeKnotVector uKnots, OdGeKnotVector vKnots)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_get(swigCPtr, out iUDegree, out iVDegree, out bRational, out iUNumControlPoints, out iVNumControlPoints, OdGePoint3dArray.getCPtr(ctrlPtsArr).Handle, OdDoubleArray.getCPtr(weights).Handle, OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult set(int iUDegree, int iVDegree, bool bRational, int iUNumControlPoints, int iVNumControlPoints, OdGePoint3dArray ctrlPtsArr, OdDoubleArray weights, OdGeKnotVector uKnots, OdGeKnotVector vKnots)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_set(swigCPtr, iUDegree, iVDegree, bRational, iUNumControlPoints, iVNumControlPoints, OdGePoint3dArray.getCPtr(ctrlPtsArr).Handle, OdDoubleArray.getCPtr(weights).Handle, OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNumberOfControlPointsInU(out int iCount)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNumberOfControlPointsInU(swigCPtr, out iCount);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNumberOfControlPointsInV(out int iCount)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNumberOfControlPointsInV(swigCPtr, out iCount);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNumberOfKnotsInU(out int iCount)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNumberOfKnotsInU(swigCPtr, out iCount);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNumberOfKnotsInV(out int iCount)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNumberOfKnotsInV(swigCPtr, out iCount);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getUKnots(OdGeKnotVector knots)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getUKnots(swigCPtr, OdGeKnotVector.getCPtr(knots));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getVKnots(OdGeKnotVector knots)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getVKnots(swigCPtr, OdGeKnotVector.getCPtr(knots));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getDegreeInU(out int iDegree)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getDegreeInU(swigCPtr, out iDegree);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getDegreeInV(out int iDegree)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getDegreeInV(swigCPtr, out iDegree);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult isClosedInU(out bool bIsClosed)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isClosedInU(swigCPtr, out bIsClosed);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult isClosedInV(out bool bIsClosed)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isClosedInV(swigCPtr, out bIsClosed);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult isPeriodicInU(out bool bIsPeriodic)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isPeriodicInU(swigCPtr, out bIsPeriodic);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult isPeriodicInV(out bool bIsPeriodic)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isPeriodicInV(swigCPtr, out bIsPeriodic);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getPeriodInU(out double dPeriod)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getPeriodInU(swigCPtr, out dPeriod);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getPeriodInV(out double dPeriod)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getPeriodInV(swigCPtr, out dPeriod);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult evaluate(double dU, double dV, OdGePoint3d pos)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_evaluate__SWIG_0(swigCPtr, dU, dV, OdGePoint3d.getCPtr(pos));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult evaluate(double dU, double dV, OdGePoint3d pos, OdGeVector3d uDeriv, OdGeVector3d vDeriv)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_evaluate__SWIG_1(swigCPtr, dU, dV, OdGePoint3d.getCPtr(pos), OdGeVector3d.getCPtr(uDeriv), OdGeVector3d.getCPtr(vDeriv));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult evaluate(double dU, double dV, OdGePoint3d pos, OdGeVector3d uDeriv, OdGeVector3d vDeriv, OdGeVector3d uuDeriv, OdGeVector3d uvDeriv, OdGeVector3d vvDeriv)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_evaluate__SWIG_2(swigCPtr, dU, dV, OdGePoint3d.getCPtr(pos), OdGeVector3d.getCPtr(uDeriv), OdGeVector3d.getCPtr(vDeriv), OdGeVector3d.getCPtr(uuDeriv), OdGeVector3d.getCPtr(uvDeriv), OdGeVector3d.getCPtr(vvDeriv));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult evaluate(double dU, double dV, int iDerivDegree, OdGePoint3d point, OdGeVector3dArray derivatives)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_evaluate__SWIG_3(swigCPtr, dU, dV, iDerivDegree, OdGePoint3d.getCPtr(point), OdGeVector3dArray.getCPtr(derivatives).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult isRational(out bool bIsRational)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isRational(swigCPtr, out bIsRational);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult isPlanar(out bool bIsPlanar, OdGePoint3d ptOnSurface, OdGeVector3d normal)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isPlanar(swigCPtr, out bIsPlanar, OdGePoint3d.getCPtr(ptOnSurface), OdGeVector3d.getCPtr(normal));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult isPointOnSurface(OdGePoint3d point, out bool bOnSurface)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_isPointOnSurface(swigCPtr, OdGePoint3d.getCPtr(point), out bOnSurface);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNormal(double dU, double dV, OdGeVector3d normal)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNormal(swigCPtr, dU, dV, OdGeVector3d.getCPtr(normal));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNumberOfSpansInU(out int iSpan)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNumberOfSpansInU(swigCPtr, out iSpan);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNumberOfSpansInV(out int iSpan)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getNumberOfSpansInV(swigCPtr, out iSpan);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getIsolineAtU(double dU, OdDbCurvePtrArray lineSegments)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getIsolineAtU(swigCPtr, dU, OdDbCurvePtrArray.getCPtr(lineSegments));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getIsolineAtV(double dV, OdDbCurvePtrArray lineSegments)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getIsolineAtV(swigCPtr, dV, OdDbCurvePtrArray.getCPtr(lineSegments));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult InsertKnot(double dVal, int iUorV)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_InsertKnot(swigCPtr, dVal, iUorV);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult InsertControlPointsAtU(double dU, OdGePoint3dArray vCtrlPts, OdDoubleArray vWeights)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_InsertControlPointsAtU(swigCPtr, dU, OdGePoint3dArray.getCPtr(vCtrlPts).Handle, OdDoubleArray.getCPtr(vWeights).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult InsertControlPointsAtV(double dV, OdGePoint3dArray uCtrlPts, OdDoubleArray uWeights)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_InsertControlPointsAtV(swigCPtr, dV, OdGePoint3dArray.getCPtr(uCtrlPts).Handle, OdDoubleArray.getCPtr(uWeights).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult RemoveControlPointsAtU(int iUDegree)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_RemoveControlPointsAtU(swigCPtr, iUDegree);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult RemoveControlPointsAtV(int iVDegree)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_RemoveControlPointsAtV(swigCPtr, iVDegree);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult rebuild(int iUDegree, int iVDegree, int iNumUCtrlPts, int iNumVCtrlPts, bool bRestore)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_rebuild(swigCPtr, iUDegree, iVDegree, iNumUCtrlPts, iNumVCtrlPts, bRestore);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult modifyPositionAndTangent(double dU, double dV, OdGePoint3d point, OdGeVector3d uDeriv, OdGeVector3d vDeriv)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_modifyPositionAndTangent(swigCPtr, dU, dV, OdGePoint3d.getCPtr(point), OdGeVector3d.getCPtr(uDeriv), OdGeVector3d.getCPtr(vDeriv));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getParameterOfPoint(OdGePoint3d point, out double dU, out double dV)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getParameterOfPoint(swigCPtr, OdGePoint3d.getCPtr(point), out dU, out dV);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getControlPoints(out int iUCount, out int iVCount, OdGePoint3dArray points)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getControlPoints(swigCPtr, out iUCount, out iVCount, OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setControlPoints(int iUCount, int iVCount, OdGePoint3dArray points)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setControlPoints(swigCPtr, iUCount, iVCount, OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getControlPointAndWeight(int iUIndex, int iVIndex, OdGePoint3d point, out double weight, out bool bIsRational)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getControlPointAndWeight(swigCPtr, iUIndex, iVIndex, OdGePoint3d.getCPtr(point), out weight, out bIsRational);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setControlPointAndWeight(int iUIndex, int iVIndex, OdGePoint3d point, double weight)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setControlPointAndWeight(swigCPtr, iUIndex, iVIndex, OdGePoint3d.getCPtr(point), weight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setColorToSubents(OdCmColor color)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setColorToSubents(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMaterialToSubents(OdDbObjectId materialId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setMaterialToSubents(swigCPtr, OdDbObjectId.getCPtr(materialId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMaterialResolver(OdMaterialResolver arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setMaterialResolver(swigCPtr, OdMaterialResolver.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setMaterialMapperToSubents(OdGeMatrix3d mx, out byte projection, out byte tiling, out byte autoTransform)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_setMaterialMapperToSubents(swigCPtr, OdGeMatrix3d.getCPtr(mx), out projection, out tiling, out autoTransform);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult trimSurface(OdDbObjectIdArray toolIds, OdDbObjectIdArray toolCurveIds, OdGeVector3dArray projVectors, OdGePoint3d pickPoint, OdGeVector3d viewVector, bool bAutoExtend, bool bAssociativeEnabled)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_trimSurface(swigCPtr, OdDbObjectIdArray.getCPtr(toolIds), OdDbObjectIdArray.getCPtr(toolCurveIds), OdGeVector3dArray.getCPtr(projVectors).Handle, OdGePoint3d.getCPtr(pickPoint), OdGeVector3d.getCPtr(viewVector), bAutoExtend, bAssociativeEnabled);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult projectOnToEntity(OdDbEntity pEntityToProject, OdGeVector3d projectionDirection, OdDbEntityPtrArray projectedEntities)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_projectOnToEntity(swigCPtr, OdDbEntity.getCPtr(pEntityToProject), OdGeVector3d.getCPtr(projectionDirection), OdDbEntityPtrArray.getCPtr(projectedEntities));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createSculptedSolid(OdDbEntityPtrArray limitingBodies, OdIntArray limitingFlags)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createSculptedSolid(swigCPtr, OdDbEntityPtrArray.getCPtr(limitingBodies), OdIntArray.getCPtr(limitingFlags).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult rayTest(OdGePoint3d rayBasePoint, OdGeVector3d rayDir, double rayRadius, OdArray_OdDbSubentId_OdObjectsAllocator subEntIds, OdDoubleArray parameters)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_rayTest(swigCPtr, OdGePoint3d.getCPtr(rayBasePoint), OdGeVector3d.getCPtr(rayDir), rayRadius, OdArray_OdDbSubentId_OdObjectsAllocator.getCPtr(subEntIds), OdDoubleArray.getCPtr(parameters).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createFilletSurface(ref OdDbSurface surf1, OdGePoint3d pickPt1, ref OdDbSurface surf2, OdGePoint3d pickPt2, double dRadius, OdDb_FilletTrimMode trimMode, OdGeVector3d projDir)
	{
		IntPtr jarg = ((surf1 == null) ? IntPtr.Zero : OdDbSurface.getCPtr(surf1).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((surf2 == null) ? IntPtr.Zero : OdDbSurface.getCPtr(surf2).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createFilletSurface(swigCPtr, ref jarg, OdGePoint3d.getCPtr(pickPt1), ref jarg2, OdGePoint3d.getCPtr(pickPt2), dRadius, (int)trimMode, OdGeVector3d.getCPtr(projDir));
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
				surf1 = null;
			}
			else if (jarg != intPtr)
			{
				surf1 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				surf2 = null;
			}
			else if (jarg2 != intPtr2)
			{
				surf2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSurface>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult createNetworkSurface(OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator uProfiles, OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator vProfiles)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createNetworkSurface(swigCPtr, OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator.getCPtr(uProfiles), OdArray_OdSmartPtr_OdDb3dProfile_OdObjectsAllocator.getCPtr(vProfiles));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extendEdges(OdDbFullSubentPathArray edgesId, double dExtDist, OdDbSurface_EdgeExtensionType extOption)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_extendEdges(swigCPtr, OdDbFullSubentPathArray.getCPtr(edgesId), dExtDist, (int)extOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getObjectMesh(MeshFaceterSettings faceter, OdGePoint3dArray vertexArray, OdInt32Array faceArray, out OdGiFaceData faceData)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getObjectMesh(swigCPtr, MeshFaceterSettings.getCPtr(faceter), OdGePoint3dArray.getCPtr(vertexArray).Handle, OdInt32Array.getCPtr(faceArray).Handle, out jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGiFaceData>(typeof(OdGiFaceData), jarg, bIsWrapperOwnNativeObject: true));
			faceData = ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGiFaceData>(typeof(OdGiFaceData), jarg, currentTransaction == null);
		}
	}

	public virtual OdResult getBoundingBox(OdGeExtents3d box)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getBoundingBox(swigCPtr, OdGeExtents3d.getCPtr(box));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult createCachedCurves(OdGeCurve3dPtrArray pCurves)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_createCachedCurves(swigCPtr, OdGeCurve3dPtrArray.getCPtr(pCurves).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult restoreAttributes(OdModelerGeometry oldmodeler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_restoreAttributes(swigCPtr, getCPtr(oldmodeler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult addSubentitySpecialSettings(AcisDataType addedDT, AcisDataTypeArrFirst addedDTFirst, OdDbSubentId subentId, OdUInt32ValuesArray retArray, uint idx)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_addSubentitySpecialSettings(swigCPtr, (int)addedDT, (int)addedDTFirst, OdDbSubentId.getCPtr(subentId), OdUInt32ValuesArray.getCPtr(retArray), idx);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool getFaceMesh(GeMesh_OdGeTrMesh mesh, IntPtr iFace, wrTriangulationParams triangulationParams)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getFaceMesh(swigCPtr, GeMesh_OdGeTrMesh.getCPtr(mesh), iFace, wrTriangulationParams.getCPtr(triangulationParams));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult auditAcisData(OdDbAuditInfo arg0, OdRxObject arg1)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_auditAcisData(swigCPtr, OdDbAuditInfo.getCPtr(arg0), OdRxObject.getCPtr(arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void enableAcisAudit(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_enableAcisAudit(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdModelerGeometry_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
