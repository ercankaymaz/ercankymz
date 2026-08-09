using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class OdBrepBuilderFiller : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrepBuilderFiller(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrepBuilderFiller obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBrepBuilderFiller()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_OdBrepBuilderFiller(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdBrepBuilderFillerParams params_()
	{
		OdBrepBuilderFillerParams result = new OdBrepBuilderFillerParams(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFiller_params___SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult initFrom(OdBrepBuilder builder, BrepBuilderInitialData data)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFiller_initFrom__SWIG_0(swigCPtr, OdBrepBuilder.getCPtr(builder), BrepBuilderInitialData.getCPtr(data));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult initFrom(OdBrepBuilder builder, OdBrBrep brep, OdIMaterialAndColorHelper pMaterialHelper)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFiller_initFrom__SWIG_1(swigCPtr, OdBrepBuilder.getCPtr(builder), OdBrBrep.getCPtr(brep), OdIMaterialAndColorHelper.getCPtr(pMaterialHelper));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult initFrom(OdBrepBuilder builder, OdBrBrep brep)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFiller_initFrom__SWIG_2(swigCPtr, OdBrepBuilder.getCPtr(builder), OdBrBrep.getCPtr(brep));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult initFromNURBSingleFace(OdBrepBuilder builder, OdBrBrep brep)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBrepBuilderFiller_initFromNURBSingleFace(swigCPtr, OdBrepBuilder.getCPtr(builder), OdBrBrep.getCPtr(brep));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdBrepBuilderFiller()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_OdBrepBuilderFiller(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
