using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class OdBrepBuilderFillerParams : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrepBuilderFillerParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrepBuilderFillerParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBrepBuilderFillerParams()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_OdBrepBuilderFillerParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdBrepBuilderFillerParams()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_OdBrepBuilderFillerParams(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBrepBuilderFillerParams setSkipNullSurface(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setSkipNullSurface(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSkipNullSurface()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isSkipNullSurface(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setSkipCoedge2dCurve(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setSkipCoedge2dCurve(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSkipCoedge2dCurve()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isSkipCoedge2dCurve(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setSkipCheckLoopType(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setSkipCheckLoopType(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSkipCheckLoopType()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isSkipCheckLoopType(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setGenerateExplicitLoops(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setGenerateExplicitLoops(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isGenerateExplicitLoops()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isGenerateExplicitLoops(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setMakeEllipMajorGreaterMinor(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setMakeEllipMajorGreaterMinor(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMakeEllipMajorGreaterMinor()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isMakeEllipMajorGreaterMinor(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setIgnoreComplexShell(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setIgnoreComplexShell(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isIgnoreComplexShell()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isIgnoreComplexShell(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setGenerateVertices(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setGenerateVertices(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isGenerateVertices()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isGenerateVertices(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setMake2dIntervalInclude3d(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setMake2dIntervalInclude3d(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMake2dIntervalInclude3d()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isMake2dIntervalInclude3d(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setCheckShellsConnectivity(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setCheckShellsConnectivity(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCheckShellsConnectivity()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isCheckShellsConnectivity(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setSetFaceGsMarkersTags(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setSetFaceGsMarkersTags(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSetFaceGsMarkersTags()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isSetFaceGsMarkersTags(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setSetEdgeGsMarkersTags(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setSetEdgeGsMarkersTags(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSetEdgeGsMarkersTags()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isSetEdgeGsMarkersTags(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setSetVertexGsMarkersTags(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setSetVertexGsMarkersTags(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSetVertexGsMarkersTags()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isSetVertexGsMarkersTags(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setUseFaceRegions(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setUseFaceRegions(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUseFaceRegions()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isUseFaceRegions(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setFixFaceRegionsConnections(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setFixFaceRegionsConnections(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isFixFaceRegionsConnections()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isFixFaceRegionsConnections(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setOldUvCurveHandling(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setOldUvCurveHandling(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOldUvCurveHandling()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isOldUvCurveHandling(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setSplitEdgeByPole(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setSplitEdgeByPole(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSplitEdgeByPole()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isSplitEdgeByPole(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setGlobalBrepTransform(bool val)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setGlobalBrepTransform(swigCPtr, val), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isGlobalBrepTransform()
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_isGlobalBrepTransform(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setupFor(OdRxObject pSourceDb, OdRxObject pDestinationDb)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setupFor__SWIG_0(swigCPtr, OdRxObject.getCPtr(pSourceDb), OdRxObject.getCPtr(pDestinationDb)), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setupFor(OdBrepBuilderFillerParams_BrepType sourceBrepType, OdRxObject pSourceDb, OdRxObject pDestinationDb)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setupFor__SWIG_1(swigCPtr, (int)sourceBrepType, OdRxObject.getCPtr(pSourceDb), OdRxObject.getCPtr(pDestinationDb)), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setupFor(OdBrepBuilderFillerParams_BrepType sourceBrepType, OdRxObject pSourceDb, OdBrepBuilderFillerParams_BrepType destinationBrepType, OdRxObject pDestinationDb)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setupFor__SWIG_2(swigCPtr, (int)sourceBrepType, OdRxObject.getCPtr(pSourceDb), (int)destinationBrepType, OdRxObject.getCPtr(pDestinationDb)), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setupFor(OdBrepBuilderFillerParams_BrepType sourceBrepType, OdRxObject pDestinationDb)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setupFor__SWIG_3(swigCPtr, (int)sourceBrepType, OdRxObject.getCPtr(pDestinationDb)), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setupFor(OdRxObject pSourceDb, OdBrepBuilderFillerParams_BrepType destinationBrepType)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setupFor__SWIG_4(swigCPtr, OdRxObject.getCPtr(pSourceDb), (int)destinationBrepType), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrepBuilderFillerParams setupFor(OdBrepBuilderFillerParams_BrepType sourceBrepType, OdBrepBuilderFillerParams_BrepType destinationBrepType)
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_setupFor__SWIG_5(swigCPtr, (int)sourceBrepType, (int)destinationBrepType), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject sourceDb()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_sourceDb(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdBrepBuilderFillerParams_BrepType sourceBrepType()
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_sourceBrepType(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrepBuilderFillerParams_BrepType)result;
	}

	public OdRxObject destinationDb()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_destinationDb(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdBrepBuilderFillerParams_BrepType destinationBrepType()
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFillerParams_destinationBrepType(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrepBuilderFillerParams_BrepType)result;
	}
}
