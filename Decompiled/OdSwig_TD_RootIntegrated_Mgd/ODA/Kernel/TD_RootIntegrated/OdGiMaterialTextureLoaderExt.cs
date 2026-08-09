using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialTextureLoaderExt : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiMaterialTextureLoaderExt_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureLoaderExt_1();

	public delegate void SwigDelegateOdGiMaterialTextureLoaderExt_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiMaterialTextureLoaderExt_3(IntPtr pTexture);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureLoaderExt_4(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, IntPtr pTexture);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMaterialTextureLoaderExt_0 swigDelegate0;

	private SwigDelegateOdGiMaterialTextureLoaderExt_1 swigDelegate1;

	private SwigDelegateOdGiMaterialTextureLoaderExt_2 swigDelegate2;

	private SwigDelegateOdGiMaterialTextureLoaderExt_3 swigDelegate3;

	private SwigDelegateOdGiMaterialTextureLoaderExt_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiMaterialTexture) };

	private static Type[] swigMethodTypes4 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialTextureEntry),
		typeof(OdGiMaterialTexture)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialTextureLoaderExt(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialTextureLoaderExt obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTextureLoaderExt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialTextureLoaderExt cast(OdRxObject pObj)
	{
		OdGiMaterialTextureLoaderExt rXObject = Helpers.GetRXObject<OdGiMaterialTextureLoaderExt>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_isASwigExplicitOdGiMaterialTextureLoaderExt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_queryXSwigExplicitOdGiMaterialTextureLoaderExt(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMaterialTextureLoaderExt createObject()
	{
		OdGiMaterialTextureLoaderExt rXObject = Helpers.GetRXObject<OdGiMaterialTextureLoaderExt>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool allowTextureLoading(OdGiMaterialTexture pTexture)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_allowTextureLoading(swigCPtr, OdGiMaterialTexture.getCPtr(pTexture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureData loadTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialTextureEntry pEntry, OdGiMaterialTexture pTexture)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_loadTexture(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialTextureEntry.getCPtr(pEntry), OdGiMaterialTexture.getCPtr(pTexture)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialTextureLoaderExt()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureLoaderExt(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMaterialTextureLoaderExt) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("allowTextureLoading", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodallowTextureLoading;
		}
		if (SwigDerivedClassHasMethod("loadTexture", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodloadTexture;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoaderExt_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMaterialTextureLoaderExt));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodallowTextureLoading(IntPtr pTexture)
	{
		return allowTextureLoading(Helpers.GetRXObject<OdGiMaterialTexture>(pTexture, bOwn: true, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodloadTexture(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, IntPtr pTexture)
	{
		return OdGiMaterialTextureData.getCPtr(loadTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTextureEntry>(pEntry, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTexture>(pTexture, bOwn: true, bTryAddToTransaction: false))).Handle;
	}
}
