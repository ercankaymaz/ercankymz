using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialTextureManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_1();

	public delegate void SwigDelegateOdGiMaterialTextureManager_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiMaterialTextureManager_3(int type);

	public delegate int SwigDelegateOdGiMaterialTextureManager_4();

	public delegate void SwigDelegateOdGiMaterialTextureManager_5(IntPtr pExt);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_6();

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_7(IntPtr matMap);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_8(IntPtr pTexture);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_9([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_10(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, IntPtr matMap);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_11(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, IntPtr pTexture);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_12(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

	public delegate void SwigDelegateOdGiMaterialTextureManager_13(IntPtr matMap, IntPtr pData);

	public delegate void SwigDelegateOdGiMaterialTextureManager_14(IntPtr pTexture, IntPtr pData);

	public delegate void SwigDelegateOdGiMaterialTextureManager_15([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pData);

	public delegate bool SwigDelegateOdGiMaterialTextureManager_16(IntPtr pData);

	public delegate bool SwigDelegateOdGiMaterialTextureManager_17(IntPtr pData);

	public delegate void SwigDelegateOdGiMaterialTextureManager_18();

	public delegate uint SwigDelegateOdGiMaterialTextureManager_19();

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_20(uint nIndex);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureManager_21(uint nIndex);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMaterialTextureManager_0 swigDelegate0;

	private SwigDelegateOdGiMaterialTextureManager_1 swigDelegate1;

	private SwigDelegateOdGiMaterialTextureManager_2 swigDelegate2;

	private SwigDelegateOdGiMaterialTextureManager_3 swigDelegate3;

	private SwigDelegateOdGiMaterialTextureManager_4 swigDelegate4;

	private SwigDelegateOdGiMaterialTextureManager_5 swigDelegate5;

	private SwigDelegateOdGiMaterialTextureManager_6 swigDelegate6;

	private SwigDelegateOdGiMaterialTextureManager_7 swigDelegate7;

	private SwigDelegateOdGiMaterialTextureManager_8 swigDelegate8;

	private SwigDelegateOdGiMaterialTextureManager_9 swigDelegate9;

	private SwigDelegateOdGiMaterialTextureManager_10 swigDelegate10;

	private SwigDelegateOdGiMaterialTextureManager_11 swigDelegate11;

	private SwigDelegateOdGiMaterialTextureManager_12 swigDelegate12;

	private SwigDelegateOdGiMaterialTextureManager_13 swigDelegate13;

	private SwigDelegateOdGiMaterialTextureManager_14 swigDelegate14;

	private SwigDelegateOdGiMaterialTextureManager_15 swigDelegate15;

	private SwigDelegateOdGiMaterialTextureManager_16 swigDelegate16;

	private SwigDelegateOdGiMaterialTextureManager_17 swigDelegate17;

	private SwigDelegateOdGiMaterialTextureManager_18 swigDelegate18;

	private SwigDelegateOdGiMaterialTextureManager_19 swigDelegate19;

	private SwigDelegateOdGiMaterialTextureManager_20 swigDelegate20;

	private SwigDelegateOdGiMaterialTextureManager_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiMaterialTextureManager_ManageType) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiMaterialTextureLoaderExt) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiMaterialMap) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiMaterialTexture) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialTextureEntry),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes11 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialTextureEntry),
		typeof(OdGiMaterialTexture)
	};

	private static Type[] swigMethodTypes12 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialTextureEntry),
		typeof(string)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdGiMaterialMap),
		typeof(OdGiMaterialTextureData)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdGiMaterialTexture),
		typeof(OdGiMaterialTextureData)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(string),
		typeof(OdGiMaterialTextureData)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdGiMaterialTextureData) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiMaterialTextureData) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(uint) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialTextureManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialTextureManager obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTextureManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialTextureManager cast(OdRxObject pObj)
	{
		OdGiMaterialTextureManager rXObject = Helpers.GetRXObject<OdGiMaterialTextureManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_isASwigExplicitOdGiMaterialTextureManager(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_queryXSwigExplicitOdGiMaterialTextureManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMaterialTextureManager createObject()
	{
		OdGiMaterialTextureManager rXObject = Helpers.GetRXObject<OdGiMaterialTextureManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setManageType(OdGiMaterialTextureManager_ManageType type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_setManageType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTextureManager_ManageType manageType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_manageType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialTextureManager_ManageType)result;
	}

	public virtual void setMaterialLoaderExt(OdGiMaterialTextureLoaderExt pExt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_setMaterialLoaderExt(swigCPtr, OdGiMaterialTextureLoaderExt.getCPtr(pExt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTextureLoaderExt materialLoaderExt()
	{
		OdGiMaterialTextureLoaderExt rXObject = Helpers.GetRXObject<OdGiMaterialTextureLoaderExt>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_materialLoaderExt(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData searchTexture(OdGiMaterialMap matMap)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_searchTexture__SWIG_0(swigCPtr, OdGiMaterialMap.getCPtr(matMap)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData searchTexture(OdGiMaterialTexture pTexture)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_searchTexture__SWIG_1(swigCPtr, OdGiMaterialTexture.getCPtr(pTexture)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData searchTexture(string fileName)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_searchTexture__SWIG_2(swigCPtr, fileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData tryToLoad(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialTextureEntry pEntry, OdGiMaterialMap matMap)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_tryToLoad__SWIG_0(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialTextureEntry.getCPtr(pEntry), OdGiMaterialMap.getCPtr(matMap)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData tryToLoad(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialTextureEntry pEntry, OdGiMaterialTexture pTexture)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_tryToLoad__SWIG_1(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialTextureEntry.getCPtr(pEntry), OdGiMaterialTexture.getCPtr(pTexture)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData tryToLoad(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialTextureEntry pEntry, string fileName)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_tryToLoad__SWIG_2(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialTextureEntry.getCPtr(pEntry), fileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void linkTexture(OdGiMaterialMap matMap, OdGiMaterialTextureData pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_linkTexture__SWIG_0(swigCPtr, OdGiMaterialMap.getCPtr(matMap), OdGiMaterialTextureData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void linkTexture(OdGiMaterialTexture pTexture, OdGiMaterialTextureData pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_linkTexture__SWIG_1(swigCPtr, OdGiMaterialTexture.getCPtr(pTexture), OdGiMaterialTextureData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void linkTexture(string fileName, OdGiMaterialTextureData pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_linkTexture__SWIG_2(swigCPtr, fileName, OdGiMaterialTextureData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAvailable(OdGiMaterialTextureData pData)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_isAvailable(swigCPtr, OdGiMaterialTextureData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool unlinkTexture(OdGiMaterialTextureData pData)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_unlinkTexture(swigCPtr, OdGiMaterialTextureData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numTextureEntries()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_numTextureEntries(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTexture textureEntryKey(uint nIndex)
	{
		OdGiMaterialTexture rXObject = Helpers.GetRXObject<OdGiMaterialTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_textureEntryKey(swigCPtr, nIndex), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData textureEntryData(uint nIndex)
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_textureEntryData(swigCPtr, nIndex), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialTextureManager()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureManager(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMaterialTextureManager) != GetType();
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
		if (SwigDerivedClassHasMethod("setManageType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetManageType;
		}
		if (SwigDerivedClassHasMethod("manageType", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodmanageType;
		}
		if (SwigDerivedClassHasMethod("setMaterialLoaderExt", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetMaterialLoaderExt;
		}
		if (SwigDerivedClassHasMethod("materialLoaderExt", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodmaterialLoaderExt;
		}
		if (SwigDerivedClassHasMethod("searchTexture", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsearchTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("searchTexture", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsearchTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("searchTexture", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsearchTexture__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("tryToLoad", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodtryToLoad__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("tryToLoad", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodtryToLoad__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("tryToLoad", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodtryToLoad__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("linkTexture", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlinkTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("linkTexture", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodlinkTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("linkTexture", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodlinkTexture__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("isAvailable", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodisAvailable;
		}
		if (SwigDerivedClassHasMethod("unlinkTexture", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodunlinkTexture;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodclear;
		}
		if (SwigDerivedClassHasMethod("numTextureEntries", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodnumTextureEntries;
		}
		if (SwigDerivedClassHasMethod("textureEntryKey", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodtextureEntryKey;
		}
		if (SwigDerivedClassHasMethod("textureEntryData", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodtextureEntryData;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMaterialTextureManager));
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

	private void SwigDirectorMethodsetManageType(int type)
	{
		try
		{
			setManageType((OdGiMaterialTextureManager_ManageType)type);
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

	private int SwigDirectorMethodmanageType()
	{
		return (int)manageType();
	}

	private void SwigDirectorMethodsetMaterialLoaderExt(IntPtr pExt)
	{
		try
		{
			setMaterialLoaderExt(Helpers.GetRXObject<OdGiMaterialTextureLoaderExt>(pExt, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodmaterialLoaderExt()
	{
		return OdGiMaterialTextureLoaderExt.getCPtr(materialLoaderExt()).Handle;
	}

	private IntPtr SwigDirectorMethodsearchTexture__SWIG_0(IntPtr matMap)
	{
		return OdGiMaterialTextureData.getCPtr(searchTexture(new OdGiMaterialMap(matMap, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodsearchTexture__SWIG_1(IntPtr pTexture)
	{
		return OdGiMaterialTextureData.getCPtr(searchTexture(Helpers.GetRXObject<OdGiMaterialTexture>(pTexture, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodsearchTexture__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		return OdGiMaterialTextureData.getCPtr(searchTexture(fileName)).Handle;
	}

	private IntPtr SwigDirectorMethodtryToLoad__SWIG_0(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, IntPtr matMap)
	{
		return OdGiMaterialTextureData.getCPtr(tryToLoad(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTextureEntry>(pEntry, bOwn: false, bTryAddToTransaction: false), new OdGiMaterialMap(matMap, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodtryToLoad__SWIG_1(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, IntPtr pTexture)
	{
		return OdGiMaterialTextureData.getCPtr(tryToLoad(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTextureEntry>(pEntry, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTexture>(pTexture, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodtryToLoad__SWIG_2(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pEntry, [MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		return OdGiMaterialTextureData.getCPtr(tryToLoad(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTextureEntry>(pEntry, bOwn: false, bTryAddToTransaction: false), fileName)).Handle;
	}

	private void SwigDirectorMethodlinkTexture__SWIG_0(IntPtr matMap, IntPtr pData)
	{
		try
		{
			linkTexture(new OdGiMaterialMap(matMap, cMemoryOwn: false), Helpers.GetRXObject<OdGiMaterialTextureData>(pData, bOwn: true, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodlinkTexture__SWIG_1(IntPtr pTexture, IntPtr pData)
	{
		try
		{
			linkTexture(Helpers.GetRXObject<OdGiMaterialTexture>(pTexture, bOwn: true, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTextureData>(pData, bOwn: true, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodlinkTexture__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pData)
	{
		try
		{
			linkTexture(fileName, Helpers.GetRXObject<OdGiMaterialTextureData>(pData, bOwn: true, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodisAvailable(IntPtr pData)
	{
		return isAvailable(Helpers.GetRXObject<OdGiMaterialTextureData>(pData, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodunlinkTexture(IntPtr pData)
	{
		return unlinkTexture(Helpers.GetRXObject<OdGiMaterialTextureData>(pData, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
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

	private uint SwigDirectorMethodnumTextureEntries()
	{
		return numTextureEntries();
	}

	private IntPtr SwigDirectorMethodtextureEntryKey(uint nIndex)
	{
		return OdGiMaterialTexture.getCPtr(textureEntryKey(nIndex)).Handle;
	}

	private IntPtr SwigDirectorMethodtextureEntryData(uint nIndex)
	{
		return OdGiMaterialTextureData.getCPtr(textureEntryData(nIndex)).Handle;
	}
}
