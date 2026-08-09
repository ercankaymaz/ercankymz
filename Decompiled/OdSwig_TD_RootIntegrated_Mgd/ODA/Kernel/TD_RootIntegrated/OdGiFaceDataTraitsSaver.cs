using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFaceDataTraitsSaver : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFaceDataTraitsSaver(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFaceDataTraitsSaver obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiFaceDataTraitsSaver()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFaceDataTraitsSaver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiFaceDataTraitsSaver(OdGiFaceData pFaceData, OdGiSubEntityTraits pTraits, OdGiConveyorContext pDrawCtx, OdGsView_RenderMode renderMode, bool bForEdge, bool ignoreFaceVisibilities)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFaceDataTraitsSaver__SWIG_0(OdGiFaceData.getCPtr(pFaceData), OdGiSubEntityTraits.getCPtr(pTraits), pDrawCtx.GetInterfaceCPtr(), (int)renderMode, bForEdge, ignoreFaceVisibilities), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiFaceDataTraitsSaver(OdGiFaceData pFaceData, OdGiSubEntityTraits pTraits, OdGiConveyorContext pDrawCtx, OdGsView_RenderMode renderMode, bool bForEdge)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFaceDataTraitsSaver__SWIG_1(OdGiFaceData.getCPtr(pFaceData), OdGiSubEntityTraits.getCPtr(pTraits), pDrawCtx.GetInterfaceCPtr(), (int)renderMode, bForEdge), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiFaceDataTraitsSaver(OdGiFaceData pFaceData, OdGiSubEntityTraits pTraits, OdGiConveyorContext pDrawCtx, OdGsView_RenderMode renderMode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFaceDataTraitsSaver__SWIG_2(OdGiFaceData.getCPtr(pFaceData), OdGiSubEntityTraits.getCPtr(pTraits), pDrawCtx.GetInterfaceCPtr(), (int)renderMode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool onExit()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataTraitsSaver_onExit(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool needExit()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataTraitsSaver_needExit(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFaceTraits(int faceIndex)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataTraitsSaver_setFaceTraits(swigCPtr, faceIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataTraitsSaver_hasData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
