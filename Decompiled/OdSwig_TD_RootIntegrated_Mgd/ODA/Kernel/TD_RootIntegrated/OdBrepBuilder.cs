using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrepBuilder : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static uint kDefaultShellId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_kDefaultShellId_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static uint kDefaultVertexId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_kDefaultVertexId_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrepBuilder(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrepBuilder obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBrepBuilder()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrepBuilder(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdBrepBuilder()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrepBuilder(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepType getType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_getType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (BrepType)result;
	}

	public void set(IntPtr pFile)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_set(swigCPtr, pFile);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint addCoedge(uint loopId, uint edgeId, OdBrepBuilder_EntityDirection codgeDirection, OdGeCurve2d pParCur)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addCoedge__SWIG_0(swigCPtr, loopId, edgeId, (int)codgeDirection, OdGeCurve2d.getCPtr(pParCur));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addCoedge(uint loopId, uint edgeId, OdBrepBuilder_EntityDirection codgeDirection)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addCoedge__SWIG_1(swigCPtr, loopId, edgeId, (int)codgeDirection);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addCoedge(uint loopId, uint edgeId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addCoedge__SWIG_2(swigCPtr, loopId, edgeId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addEdge(OdGeCurve3d pCurveForEdge)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addEdge__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(pCurveForEdge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addEdge(OdGeCurve3d pCurveForEdge, uint vertex1Id, uint vertex2Id)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addEdge__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(pCurveForEdge), vertex1Id, vertex2Id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addVertex(OdGePoint3d point)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addVertex(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addFace(OdGeSurface pSurf, OdBrepBuilder_EntityDirection faceDirection, uint shellId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addFace__SWIG_0(swigCPtr, OdGeSurface.getCPtr(pSurf), (int)faceDirection, shellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addFace(OdGeSurface pSurf, OdBrepBuilder_EntityDirection faceDirection)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addFace__SWIG_1(swigCPtr, OdGeSurface.getCPtr(pSurf), (int)faceDirection);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addLoop(uint faceId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addLoop(swigCPtr, faceId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addShell(uint complexId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addShell(swigCPtr, complexId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint addComplex()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_addComplex(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void allowRemovalOfProblematicFaces()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_allowRemovalOfProblematicFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool canAddGeometry()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_canAddGeometry(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void finishComplex(uint complexId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_finishComplex(swigCPtr, complexId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void finishShell(uint shellId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_finishShell(swigCPtr, shellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void finishFace(uint faceId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_finishFace(swigCPtr, faceId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void finishLoop(uint loopId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_finishLoop(swigCPtr, loopId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject getResult()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_getResult(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isPermittedSurfaceType(OdGeSurface pSurf)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isPermittedSurfaceType(swigCPtr, OdGeSurface.getCPtr(pSurf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isResultAvailable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isResultAvailable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidEdgeId(uint edgeId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isValidEdgeId(swigCPtr, edgeId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidComplexId(uint complexId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isValidComplexId(swigCPtr, complexId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidShellId(uint shellId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isValidShellId(swigCPtr, shellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidFaceId(uint faceId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isValidFaceId(swigCPtr, faceId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidLoopId(uint loopId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isValidLoopId(swigCPtr, loopId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool removedSomeFaces()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_removedSomeFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAllowShortEdges()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setAllowShortEdges(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFlag(uint id, uint flag, bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setFlag(swigCPtr, id, flag, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setFacesMaterial(uint faceId, OdDbStub materialId)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setFacesMaterial(swigCPtr, faceId, OdDbStub.getCPtr(materialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setFaceMaterialMapping(uint faceId, OdGiMapper materialMapper)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setFaceMaterialMapping(swigCPtr, faceId, OdGiMapper.getCPtr(materialMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setEdgeColor(uint edgeId, OdCmEntityColor edgeColor)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setEdgeColor(swigCPtr, edgeId, OdCmEntityColor.getCPtr(edgeColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setFaceColor(uint faceId, OdCmEntityColor faceColor)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setFaceColor(swigCPtr, faceId, OdCmEntityColor.getCPtr(faceColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdRxObject finish()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_finish(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setTag(uint id, uint tag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setTag(swigCPtr, id, tag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void enableValidator(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_enableValidator__SWIG_0(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void enableValidator()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_enableValidator__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ValidationErrors getValidationErrors()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_getValidationErrors(swigCPtr);
		ValidationErrors result = ((intPtr == IntPtr.Zero) ? null : new ValidationErrors(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getBBSettings()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_getBBSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBBSettings(uint flag, bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setBBSettings(swigCPtr, flag, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setTransformation(OdGeMatrix3d transformation)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrepBuilder_setTransformation(swigCPtr, OdGeMatrix3d.getCPtr(transformation));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}
