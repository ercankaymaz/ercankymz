using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcContentLayerFilterItems : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcContentLayerFilterItems(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcContentLayerFilterItems obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcContentLayerFilterItems()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcContentLayerFilterItems(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcContentLayerFilterItems()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcContentLayerFilterItems(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentLayerFilterItems_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentLayerFilterItems_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt32Array layerIndex()
	{
		OdUInt32Array result = new OdUInt32Array(OdPrcModule_GlobalsPINVOKE.OdPrcContentLayerFilterItems_layerIndex__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIsInclusive(bool isInclusive)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentLayerFilterItems_setIsInclusive(swigCPtr, isInclusive);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInclusive()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcContentLayerFilterItems_isInclusive(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
