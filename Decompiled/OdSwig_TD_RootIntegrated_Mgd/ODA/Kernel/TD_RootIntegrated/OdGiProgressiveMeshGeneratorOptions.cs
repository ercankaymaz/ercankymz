using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProgressiveMeshGeneratorOptions : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProgressiveMeshGeneratorOptions(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProgressiveMeshGeneratorOptions obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiProgressiveMeshGeneratorOptions()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProgressiveMeshGeneratorOptions(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiProgressiveMeshGeneratorOptions()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProgressiveMeshGeneratorOptions(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint minVertices()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_minVertices(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinVertices(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setMinVertices(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint minFaces()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_minFaces(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinFaces(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setMinFaces(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double worstDiherial()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_worstDiherial(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setWorstDiherial(double d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setWorstDiherial(swigCPtr, d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double smallestCost()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_smallestCost(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSmallestCost(double d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setSmallestCost(swigCPtr, d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double worstCost()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_worstCost(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setWorstCost(double d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setWorstCost(swigCPtr, d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double infinity()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_infinity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInfinity(double d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setInfinity(swigCPtr, d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getFitNormals()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_getFitNormals(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double normalErrorFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_normalErrorFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFitNormals(bool bFit, double errorFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setFitNormals(swigCPtr, bFit, errorFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getFitColors()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_getFitColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double colorErrorFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_colorErrorFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFitColors(bool bFit, double errorFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setFitColors(swigCPtr, bFit, errorFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double sharpEdgesScaleFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_sharpEdgesScaleFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSharpEdgesScaleFactor(double d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setSharpEdgesScaleFactor(swigCPtr, d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double nextCostThresholdFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_nextCostThresholdFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNextCostThresholdFactor(double d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setNextCostThresholdFactor(swigCPtr, d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getDiffMaxPenalty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_getDiffMaxPenalty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double diffMaxPenaltyFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_diffMaxPenaltyFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDiffMaxPenalty(bool bSet, double factor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setDiffMaxPenalty(swigCPtr, bSet, factor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getSumPenalty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_getSumPenalty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double sumPenaltyFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_sumPenaltyFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSumPenalty(bool bSet, double factor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setSumPenalty(swigCPtr, bSet, factor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public byte strictSharp()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_strictSharp(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint numFaceSamplePoints()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_numFaceSamplePoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNumFaceSamplePoints(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGeneratorOptions_setNumFaceSamplePoints(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
