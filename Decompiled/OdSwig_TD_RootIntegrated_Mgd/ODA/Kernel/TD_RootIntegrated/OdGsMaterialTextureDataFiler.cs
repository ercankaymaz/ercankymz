using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsMaterialTextureDataFiler : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsMaterialTextureDataFiler(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsMaterialTextureDataFiler obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsMaterialTextureDataFiler()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsMaterialTextureDataFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool saveClientMaterialTextureData(OdGiMaterialTextureData arg0, OdGsFiler arg1)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialTextureDataFiler_saveClientMaterialTextureData(swigCPtr, OdGiMaterialTextureData.getCPtr(arg0), OdGsFiler.getCPtr(arg1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureData loadClientMaterialTextureData(OdGsFiler arg0, OdGiMaterialTextureEntry arg1)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialTextureDataFiler_loadClientMaterialTextureData(swigCPtr, OdGsFiler.getCPtr(arg0), OdGiMaterialTextureEntry.getCPtr(arg1)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialTextureDataFiler()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMaterialTextureDataFiler(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
