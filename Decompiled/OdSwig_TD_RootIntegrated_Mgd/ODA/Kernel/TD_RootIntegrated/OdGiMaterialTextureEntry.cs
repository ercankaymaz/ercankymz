using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialTextureEntry : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiMaterialTextureEntry_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureEntry_1();

	public delegate void SwigDelegateOdGiMaterialTextureEntry_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureEntry_3();

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_4();

	public delegate uint SwigDelegateOdGiMaterialTextureEntry_5();

	public delegate void SwigDelegateOdGiMaterialTextureEntry_6(uint width);

	public delegate uint SwigDelegateOdGiMaterialTextureEntry_7();

	public delegate void SwigDelegateOdGiMaterialTextureEntry_8(uint height);

	public delegate void SwigDelegateOdGiMaterialTextureEntry_9(uint width, uint height);

	public delegate double SwigDelegateOdGiMaterialTextureEntry_10();

	public delegate void SwigDelegateOdGiMaterialTextureEntry_11(double coef);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_12(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr matMap, IntPtr pManager);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_13(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr matMap);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_14(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pTexture, IntPtr pManager);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_15(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pTexture);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_16(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, [MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pManager);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_17(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_18(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, double opacity, IntPtr pManager);

	public delegate bool SwigDelegateOdGiMaterialTextureEntry_19(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, double opacity);

	public delegate void SwigDelegateOdGiMaterialTextureEntry_20(IntPtr pTextureData, IntPtr pManager);

	public delegate void SwigDelegateOdGiMaterialTextureEntry_21(IntPtr pTextureData);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMaterialTextureEntry_0 swigDelegate0;

	private SwigDelegateOdGiMaterialTextureEntry_1 swigDelegate1;

	private SwigDelegateOdGiMaterialTextureEntry_2 swigDelegate2;

	private SwigDelegateOdGiMaterialTextureEntry_3 swigDelegate3;

	private SwigDelegateOdGiMaterialTextureEntry_4 swigDelegate4;

	private SwigDelegateOdGiMaterialTextureEntry_5 swigDelegate5;

	private SwigDelegateOdGiMaterialTextureEntry_6 swigDelegate6;

	private SwigDelegateOdGiMaterialTextureEntry_7 swigDelegate7;

	private SwigDelegateOdGiMaterialTextureEntry_8 swigDelegate8;

	private SwigDelegateOdGiMaterialTextureEntry_9 swigDelegate9;

	private SwigDelegateOdGiMaterialTextureEntry_10 swigDelegate10;

	private SwigDelegateOdGiMaterialTextureEntry_11 swigDelegate11;

	private SwigDelegateOdGiMaterialTextureEntry_12 swigDelegate12;

	private SwigDelegateOdGiMaterialTextureEntry_13 swigDelegate13;

	private SwigDelegateOdGiMaterialTextureEntry_14 swigDelegate14;

	private SwigDelegateOdGiMaterialTextureEntry_15 swigDelegate15;

	private SwigDelegateOdGiMaterialTextureEntry_16 swigDelegate16;

	private SwigDelegateOdGiMaterialTextureEntry_17 swigDelegate17;

	private SwigDelegateOdGiMaterialTextureEntry_18 swigDelegate18;

	private SwigDelegateOdGiMaterialTextureEntry_19 swigDelegate19;

	private SwigDelegateOdGiMaterialTextureEntry_20 swigDelegate20;

	private SwigDelegateOdGiMaterialTextureEntry_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes12 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialMap),
		typeof(OdGiMaterialTextureManager)
	};

	private static Type[] swigMethodTypes13 = new Type[4]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialMap)
	};

	private static Type[] swigMethodTypes14 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialTexture),
		typeof(OdGiMaterialTextureManager)
	};

	private static Type[] swigMethodTypes15 = new Type[4]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(OdGiMaterialTexture)
	};

	private static Type[] swigMethodTypes16 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(string),
		typeof(OdGiMaterialTextureManager)
	};

	private static Type[] swigMethodTypes17 = new Type[4]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(string)
	};

	private static Type[] swigMethodTypes18 = new Type[5]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(double),
		typeof(OdGiMaterialTextureManager)
	};

	private static Type[] swigMethodTypes19 = new Type[4]
	{
		typeof(OdGiMaterialTextureData.DevDataVariant),
		typeof(OdRxClass),
		typeof(OdGiContext),
		typeof(double)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdGiMaterialTextureData),
		typeof(OdGiMaterialTextureManager)
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGiMaterialTextureData) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialTextureEntry(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialTextureEntry obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTextureEntry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialTextureEntry cast(OdRxObject pObj)
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_isASwigExplicitOdGiMaterialTextureEntry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_queryXSwigExplicitOdGiMaterialTextureEntry(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMaterialTextureEntry createObject()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureData textureData()
	{
		OdGiMaterialTextureData rXObject = Helpers.GetRXObject<OdGiMaterialTextureData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_textureData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isTextureInitialized()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_isTextureInitialized(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint proceduralTextureWidth()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_proceduralTextureWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setProceduralTextureWidth(uint width)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setProceduralTextureWidth(swigCPtr, width);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint proceduralTextureHeight()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_proceduralTextureHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setProceduralTextureHeight(uint height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setProceduralTextureHeight(swigCPtr, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setProceduralTextureResolution(uint width, uint height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setProceduralTextureResolution(swigCPtr, width, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double proceduralTextureQuality()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_proceduralTextureQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setProceduralTextureQuality(double coef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setProceduralTextureQuality(swigCPtr, coef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialMap matMap, OdGiMaterialTextureManager pManager)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_0(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialMap.getCPtr(matMap), OdGiMaterialTextureManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialMap matMap)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_1(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialMap.getCPtr(matMap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialTexture pTexture, OdGiMaterialTextureManager pManager)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_2(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialTexture.getCPtr(pTexture), OdGiMaterialTextureManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, OdGiMaterialTexture pTexture)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_3(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), OdGiMaterialTexture.getCPtr(pTexture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, string fileName, OdGiMaterialTextureManager pManager)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_4(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), fileName, OdGiMaterialTextureManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, string fileName)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_5(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), fileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, double opacity, OdGiMaterialTextureManager pManager)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_6(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), opacity, OdGiMaterialTextureManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setGiMaterialTexture(OdGiMaterialTextureData.DevDataVariant pDeviceInfo, OdRxClass pTexDataImpl, OdGiContext giCtx, double opacity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setGiMaterialTexture__SWIG_7(swigCPtr, OdGiMaterialTextureData.DevDataVariant.getCPtr(pDeviceInfo), OdRxClass.getCPtr(pTexDataImpl), OdGiContext.getCPtr(giCtx), opacity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextureData(OdGiMaterialTextureData pTextureData, OdGiMaterialTextureManager pManager)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setTextureData__SWIG_0(swigCPtr, OdGiMaterialTextureData.getCPtr(pTextureData), OdGiMaterialTextureManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextureData(OdGiMaterialTextureData pTextureData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_setTextureData__SWIG_1(swigCPtr, OdGiMaterialTextureData.getCPtr(pTextureData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialTextureEntry()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureEntry(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMaterialTextureEntry) != GetType();
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
		if (SwigDerivedClassHasMethod("textureData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtextureData;
		}
		if (SwigDerivedClassHasMethod("isTextureInitialized", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisTextureInitialized;
		}
		if (SwigDerivedClassHasMethod("proceduralTextureWidth", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodproceduralTextureWidth;
		}
		if (SwigDerivedClassHasMethod("setProceduralTextureWidth", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetProceduralTextureWidth;
		}
		if (SwigDerivedClassHasMethod("proceduralTextureHeight", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodproceduralTextureHeight;
		}
		if (SwigDerivedClassHasMethod("setProceduralTextureHeight", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetProceduralTextureHeight;
		}
		if (SwigDerivedClassHasMethod("setProceduralTextureResolution", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetProceduralTextureResolution;
		}
		if (SwigDerivedClassHasMethod("proceduralTextureQuality", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodproceduralTextureQuality;
		}
		if (SwigDerivedClassHasMethod("setProceduralTextureQuality", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetProceduralTextureQuality;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetGiMaterialTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetGiMaterialTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetGiMaterialTexture__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetGiMaterialTexture__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetGiMaterialTexture__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetGiMaterialTexture__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetGiMaterialTexture__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("setGiMaterialTexture", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetGiMaterialTexture__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("setTextureData", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetTextureData__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setTextureData", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetTextureData__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureEntry_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMaterialTextureEntry));
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

	private IntPtr SwigDirectorMethodtextureData()
	{
		return OdGiMaterialTextureData.getCPtr(textureData()).Handle;
	}

	private bool SwigDirectorMethodisTextureInitialized()
	{
		return isTextureInitialized();
	}

	private uint SwigDirectorMethodproceduralTextureWidth()
	{
		return proceduralTextureWidth();
	}

	private void SwigDirectorMethodsetProceduralTextureWidth(uint width)
	{
		try
		{
			setProceduralTextureWidth(width);
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

	private uint SwigDirectorMethodproceduralTextureHeight()
	{
		return proceduralTextureHeight();
	}

	private void SwigDirectorMethodsetProceduralTextureHeight(uint height)
	{
		try
		{
			setProceduralTextureHeight(height);
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

	private void SwigDirectorMethodsetProceduralTextureResolution(uint width, uint height)
	{
		try
		{
			setProceduralTextureResolution(width, height);
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

	private double SwigDirectorMethodproceduralTextureQuality()
	{
		return proceduralTextureQuality();
	}

	private void SwigDirectorMethodsetProceduralTextureQuality(double coef)
	{
		try
		{
			setProceduralTextureQuality(coef);
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

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_0(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr matMap, IntPtr pManager)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), new OdGiMaterialMap(matMap, cMemoryOwn: false), Helpers.GetRXObject<OdGiMaterialTextureManager>(pManager, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_1(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr matMap)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), new OdGiMaterialMap(matMap, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_2(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pTexture, IntPtr pManager)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTexture>(pTexture, bOwn: true, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTextureManager>(pManager, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_3(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, IntPtr pTexture)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTexture>(pTexture, bOwn: true, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_4(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, [MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pManager)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), fileName, Helpers.GetRXObject<OdGiMaterialTextureManager>(pManager, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_5(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, [MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), fileName);
	}

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_6(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, double opacity, IntPtr pManager)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), opacity, Helpers.GetRXObject<OdGiMaterialTextureManager>(pManager, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsetGiMaterialTexture__SWIG_7(IntPtr pDeviceInfo, IntPtr pTexDataImpl, IntPtr giCtx, double opacity)
	{
		return setGiMaterialTexture(new OdGiMaterialTextureData.DevDataVariant(pDeviceInfo, cMemoryOwn: true), Helpers.GetRXObject<OdRxClass>(pTexDataImpl, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiContext>(giCtx, bOwn: false, bTryAddToTransaction: false), opacity);
	}

	private void SwigDirectorMethodsetTextureData__SWIG_0(IntPtr pTextureData, IntPtr pManager)
	{
		try
		{
			setTextureData(Helpers.GetRXObject<OdGiMaterialTextureData>(pTextureData, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiMaterialTextureManager>(pManager, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetTextureData__SWIG_1(IntPtr pTextureData)
	{
		try
		{
			setTextureData(Helpers.GetRXObject<OdGiMaterialTextureData>(pTextureData, bOwn: false, bTryAddToTransaction: false));
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
}
