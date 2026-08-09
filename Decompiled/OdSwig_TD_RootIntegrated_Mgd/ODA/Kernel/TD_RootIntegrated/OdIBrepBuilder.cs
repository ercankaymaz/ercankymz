using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrepBuilder : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrepBuilder(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrepBuilder obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdIBrepBuilder()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrepBuilder(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual BrepType getType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_getType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (BrepType)result;
	}

	public virtual uint addCoedge(uint loopId, uint edgeId, bool isCoedgeReversed, OdGeCurve2d pParCur)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addCoedge__SWIG_0(swigCPtr, loopId, edgeId, isCoedgeReversed, OdGeCurve2d.getCPtr(pParCur));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addCoedge(uint loopId, uint edgeId, bool isCoedgeReversed)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addCoedge__SWIG_1(swigCPtr, loopId, edgeId, isCoedgeReversed);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addCoedge(uint loopId, uint edgeId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addCoedge__SWIG_2(swigCPtr, loopId, edgeId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addEdge(OdGeCurve3d pCurveForEdge)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addEdge__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(pCurveForEdge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addEdge(OdGeCurve3d pCurveForEdge, uint vertex1Id, uint vertex2Id)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addEdge__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(pCurveForEdge), vertex1Id, vertex2Id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addVertex(OdGePoint3d point)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addVertex(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addFace(OdGeSurface pSurf, bool isFaceReversed, uint shellId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addFace__SWIG_0(swigCPtr, OdGeSurface.getCPtr(pSurf), isFaceReversed, shellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addFace(OdGeSurface pSurf, bool isFaceReversed)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addFace__SWIG_1(swigCPtr, OdGeSurface.getCPtr(pSurf), isFaceReversed);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addLoop(uint faceId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addLoop(swigCPtr, faceId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addShell(uint complexId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addShell(swigCPtr, complexId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint addComplex()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_addComplex(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTag(uint id, uint tag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setTag(swigCPtr, id, tag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void allowRemovalOfProblematicFaces()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_allowRemovalOfProblematicFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool canAddGeometry()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_canAddGeometry(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void finishComplex(uint complexId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_finishComplex(swigCPtr, complexId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void finishShell(uint shellId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_finishShell(swigCPtr, shellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void finishFace(uint faceId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_finishFace(swigCPtr, faceId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void finishLoop(uint loopId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_finishLoop(swigCPtr, loopId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getResult()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_getResult(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isPermittedSurfaceType(OdGeSurface pSurf)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_isPermittedSurfaceType(swigCPtr, OdGeSurface.getCPtr(pSurf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isResultAvailable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_isResultAvailable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidEdgeId(uint edgeId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_isValidEdgeId(swigCPtr, edgeId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidComplexId(uint complexId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_isValidComplexId(swigCPtr, complexId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidShellId(uint shellId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_isValidShellId(swigCPtr, shellId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidFaceId(uint faceId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_isValidFaceId(swigCPtr, faceId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isValidLoopId(uint loopId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_isValidLoopId(swigCPtr, loopId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool removedSomeFaces()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_removedSomeFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAllowShortEdges()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setAllowShortEdges(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFlag(uint id, uint flag, bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setFlag(swigCPtr, id, flag, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult setFacesMaterial(uint faceId, OdDbStub materialId)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setFacesMaterial(swigCPtr, faceId, OdDbStub.getCPtr(materialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setFaceMaterialMapping(uint faceId, OdGiMapper materialMapper)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setFaceMaterialMapping(swigCPtr, faceId, OdGiMapper.getCPtr(materialMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setEdgeColor(uint edgeId, OdCmEntityColor edgeColor)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setEdgeColor(swigCPtr, edgeId, OdCmEntityColor.getCPtr(edgeColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setFaceColor(uint faceId, OdCmEntityColor faceColor)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setFaceColor(swigCPtr, faceId, OdCmEntityColor.getCPtr(faceColor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdRxObject finish()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_finish(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void enableValidator(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_enableValidator__SWIG_0(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void enableValidator()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_enableValidator__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ValidationErrors getValidationErrors()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_getValidationErrors(swigCPtr);
		ValidationErrors result = ((intPtr == IntPtr.Zero) ? null : new ValidationErrors(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getBBSettings()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_getBBSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBBSettings(uint flag, bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setBBSettings(swigCPtr, flag, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult setTransformation(OdGeMatrix3d transformation)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrepBuilder_setTransformation(swigCPtr, OdGeMatrix3d.getCPtr(transformation));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}
