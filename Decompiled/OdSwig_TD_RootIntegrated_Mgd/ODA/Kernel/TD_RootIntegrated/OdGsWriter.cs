using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsWriter : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGsBaseModel m_pGsModel
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_m_pGsModel_get(swigCPtr);
			OdGsBaseModel result = ((intPtr == IntPtr.Zero) ? null : new OdGsBaseModel(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_m_pGsModel_set(swigCPtr, OdGsBaseModel.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsWriter(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsWriter obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsWriter()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsWriter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsWriter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsWriter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsExtAccum extentsAccum()
	{
		OdGsExtAccum rXObject = Helpers.GetRXObject<OdGsExtAccum>(TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_extentsAccum(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsBaseModel gsModel()
	{
		OdGsBaseModel rXObject = Helpers.GetRXObject<OdGsBaseModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_gsModel(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isRecordingMetafile()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_isRecordingMetafile(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsGeomPortion currentGeomPortion()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_currentGeomPortion(swigCPtr);
		OdGsGeomPortion result = ((intPtr == IntPtr.Zero) ? null : new OdGsGeomPortion(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsGeomPortion headGeomPortion()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_headGeomPortion(swigCPtr);
		OdGsGeomPortion result = ((intPtr == IntPtr.Zero) ? null : new OdGsGeomPortion(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void beginMetafileRecording(OdGsGeomPortion pGeomPortion)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_beginMetafileRecording(swigCPtr, OdGsGeomPortion.getCPtr(pGeomPortion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void endMetafileRecording()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_endMetafileRecording(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void separateMetafile()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_separateMetafile(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLayerFrozen(OdGsLayerNode pLayerNode)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_isLayerFrozen(swigCPtr, OdGsLayerNode.getCPtr(pLayerNode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasFrozenLayerBefore(OdGsLayerNode pLayerNode, OdGsGeomPortion pTillPortion)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_hasFrozenLayerBefore__SWIG_0(swigCPtr, OdGsLayerNode.getCPtr(pLayerNode), OdGsGeomPortion.getCPtr(pTillPortion));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasFrozenLayerBefore(OdGsLayerNode pLayerNode)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsWriter_hasFrozenLayerBefore__SWIG_1(swigCPtr, OdGsLayerNode.getCPtr(pLayerNode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
