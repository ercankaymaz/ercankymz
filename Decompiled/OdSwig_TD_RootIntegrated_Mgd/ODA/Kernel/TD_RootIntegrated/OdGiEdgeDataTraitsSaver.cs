using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiEdgeDataTraitsSaver : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiEdgeDataTraitsSaver(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiEdgeDataTraitsSaver obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiEdgeDataTraitsSaver()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiEdgeDataTraitsSaver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiEdgeDataTraitsSaver(EdgeData pEdgeData, OdGiSubEntityTraits pTraits, OdGiConveyorContext pDrawCtx, OdGsView_RenderMode renderMode, bool bFaceChk)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiEdgeDataTraitsSaver__SWIG_0(pEdgeData, OdGiSubEntityTraits.getCPtr(pTraits), pDrawCtx.GetInterfaceCPtr(), (int)renderMode, bFaceChk), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiEdgeDataTraitsSaver(EdgeData pEdgeData, OdGiSubEntityTraits pTraits, OdGiConveyorContext pDrawCtx, OdGsView_RenderMode renderMode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiEdgeDataTraitsSaver__SWIG_1(pEdgeData, OdGiSubEntityTraits.getCPtr(pTraits), pDrawCtx.GetInterfaceCPtr(), (int)renderMode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool onExit(bool bFaceChk)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataTraitsSaver_onExit__SWIG_0(swigCPtr, bFaceChk);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool onExit()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataTraitsSaver_onExit__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setEdgeTraits(int edgeIndex)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataTraitsSaver_setEdgeTraits(swigCPtr, edgeIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataTraitsSaver_hasData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
