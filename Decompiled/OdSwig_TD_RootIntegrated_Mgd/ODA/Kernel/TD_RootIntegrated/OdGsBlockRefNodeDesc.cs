using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBlockRefNodeDesc : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBlockRefNodeDesc(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBlockRefNodeDesc obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsBlockRefNodeDesc()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBlockRefNodeDesc(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsBlockRefNodeDesc(OdDbStub layoutBlockId, OdGiSubEntityTraitsData tr, OdGeScale3d scale, bool bUsePlotStyles, OdGiAnnoScaleSet annoScales)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBlockRefNodeDesc__SWIG_0(OdDbStub.getCPtr(layoutBlockId), OdGiSubEntityTraitsData.getCPtr(tr), OdGeScale3d.getCPtr(scale), bUsePlotStyles, OdGiAnnoScaleSet.getCPtr(annoScales)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsBlockRefNodeDesc(OdGsBlockRefNodeDesc c)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBlockRefNodeDesc__SWIG_1(getCPtr(c)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsBlockRefNodeDesc Assign(OdGsBlockRefNodeDesc c)
	{
		OdGsBlockRefNodeDesc result = new OdGsBlockRefNodeDesc(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockRefNodeDesc_Assign(swigCPtr, getCPtr(c)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsBlockRefNodeDesc()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBlockRefNodeDesc__SWIG_2(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeScale3d scale()
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockRefNodeDesc_scale(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void save(OdGsFiler pFiler)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockRefNodeDesc_save(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void load(OdGsFiler pFiler)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBlockRefNodeDesc_load(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
