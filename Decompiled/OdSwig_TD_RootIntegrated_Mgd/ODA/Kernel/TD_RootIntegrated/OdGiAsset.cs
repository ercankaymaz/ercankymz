using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiAsset : OdRxObjectImpl_OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public static string m_serviceDictionary
	{
		get
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiAsset_m_serviceDictionary_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiAsset(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiAsset_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiAsset obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiAsset(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdResult applyAssetTo(OdDbBaseHostAppServices app, OdRxObject db, OdMaterialFBXAssetXData asset, ref OdGiMaterialTraits traits, ref OdRxObject cache)
	{
		IntPtr jarg = ((traits == null) ? IntPtr.Zero : OdGiMaterialTraits.getCPtr(traits).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((cache == null) ? IntPtr.Zero : OdRxObject.getCPtr(cache).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiAsset_applyAssetTo(swigCPtr, OdDbBaseHostAppServices.getCPtr(app), OdRxObject.getCPtr(db), OdMaterialFBXAssetXData.getCPtr(asset), ref jarg, ref jarg2);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				traits = null;
			}
			else if (jarg != intPtr)
			{
				traits = Helpers.GetRXObject<OdGiMaterialTraits>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				cache = null;
			}
			else if (jarg2 != intPtr2)
			{
				cache = Helpers.GetRXObject<OdRxObject>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiAsset_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
