using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxRasterServices : OdRxModule
{
	public delegate IntPtr SwigDelegateOdRxRasterServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxRasterServices_1();

	public delegate void SwigDelegateOdRxRasterServices_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxRasterServices_3();

	public delegate void SwigDelegateOdRxRasterServices_4();

	public delegate void SwigDelegateOdRxRasterServices_5();

	public delegate void SwigDelegateOdRxRasterServices_6();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdRxRasterServices_7();

	public delegate IntPtr SwigDelegateOdRxRasterServices_8([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFlagsChain);

	public delegate IntPtr SwigDelegateOdRxRasterServices_9([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate IntPtr SwigDelegateOdRxRasterServices_10(IntPtr pStreamBuf, IntPtr pFlagsChain);

	public delegate IntPtr SwigDelegateOdRxRasterServices_11(IntPtr pStreamBuf);

	public delegate IntPtr SwigDelegateOdRxRasterServices_12(IntPtr pImp);

	public delegate bool SwigDelegateOdRxRasterServices_13(IntPtr rasterImage, [MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFlagsChain);

	public delegate bool SwigDelegateOdRxRasterServices_14(IntPtr rasterImage, [MarshalAs(UnmanagedType.LPWStr)] string filename, uint type, IntPtr pFlagsChain);

	public delegate bool SwigDelegateOdRxRasterServices_15(IntPtr rasterImage, IntPtr pStream, uint type, IntPtr pFlagsChain);

	public delegate bool SwigDelegateOdRxRasterServices_16(IntPtr pRaster, uint type, IntPtr pStreamBuf, IntPtr pFlagsChain);

	public delegate bool SwigDelegateOdRxRasterServices_17(IntPtr pRaster, uint type, IntPtr pStreamBuf);

	public delegate bool SwigDelegateOdRxRasterServices_18(IntPtr pSrcStream, IntPtr pDstStream, uint type, IntPtr pFlagsChainSrc, IntPtr pFlagsChainDst);

	public delegate bool SwigDelegateOdRxRasterServices_19(IntPtr pSrcStream, IntPtr pDstStream, uint type, IntPtr pFlagsChainSrc);

	public delegate bool SwigDelegateOdRxRasterServices_20(IntPtr pSrcStream, IntPtr pDstStream, uint type);

	public delegate IntPtr SwigDelegateOdRxRasterServices_21();

	public delegate bool SwigDelegateOdRxRasterServices_22(uint type);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdRxRasterServices_23(uint type, IntPtr psFilterName);

	public delegate uint SwigDelegateOdRxRasterServices_24([MarshalAs(UnmanagedType.LPWStr)] string extension);

	public delegate uint SwigDelegateOdRxRasterServices_25([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate uint SwigDelegateOdRxRasterServices_26(IntPtr pStreamBuf);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxRasterServices_0 swigDelegate0;

	private SwigDelegateOdRxRasterServices_1 swigDelegate1;

	private SwigDelegateOdRxRasterServices_2 swigDelegate2;

	private SwigDelegateOdRxRasterServices_3 swigDelegate3;

	private SwigDelegateOdRxRasterServices_4 swigDelegate4;

	private SwigDelegateOdRxRasterServices_5 swigDelegate5;

	private SwigDelegateOdRxRasterServices_6 swigDelegate6;

	private SwigDelegateOdRxRasterServices_7 swigDelegate7;

	private SwigDelegateOdRxRasterServices_8 swigDelegate8;

	private SwigDelegateOdRxRasterServices_9 swigDelegate9;

	private SwigDelegateOdRxRasterServices_10 swigDelegate10;

	private SwigDelegateOdRxRasterServices_11 swigDelegate11;

	private SwigDelegateOdRxRasterServices_12 swigDelegate12;

	private SwigDelegateOdRxRasterServices_13 swigDelegate13;

	private SwigDelegateOdRxRasterServices_14 swigDelegate14;

	private SwigDelegateOdRxRasterServices_15 swigDelegate15;

	private SwigDelegateOdRxRasterServices_16 swigDelegate16;

	private SwigDelegateOdRxRasterServices_17 swigDelegate17;

	private SwigDelegateOdRxRasterServices_18 swigDelegate18;

	private SwigDelegateOdRxRasterServices_19 swigDelegate19;

	private SwigDelegateOdRxRasterServices_20 swigDelegate20;

	private SwigDelegateOdRxRasterServices_21 swigDelegate21;

	private SwigDelegateOdRxRasterServices_22 swigDelegate22;

	private SwigDelegateOdRxRasterServices_23 swigDelegate23;

	private SwigDelegateOdRxRasterServices_24 swigDelegate24;

	private SwigDelegateOdRxRasterServices_25 swigDelegate25;

	private SwigDelegateOdRxRasterServices_26 swigDelegate26;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(string),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdGiRasterImage),
		typeof(string),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes14 = new Type[4]
	{
		typeof(OdGiRasterImage),
		typeof(string),
		typeof(uint),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes15 = new Type[4]
	{
		typeof(OdGiRasterImage),
		typeof(OdStreamBuf),
		typeof(uint),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes16 = new Type[4]
	{
		typeof(OdGiRasterImage),
		typeof(uint),
		typeof(OdStreamBuf),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(OdGiRasterImage),
		typeof(uint),
		typeof(OdStreamBuf)
	};

	private static Type[] swigMethodTypes18 = new Type[5]
	{
		typeof(OdStreamBuf),
		typeof(OdStreamBuf),
		typeof(uint),
		typeof(uint[]),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes19 = new Type[4]
	{
		typeof(OdStreamBuf),
		typeof(OdStreamBuf),
		typeof(uint),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes20 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdStreamBuf),
		typeof(uint)
	};

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes23 = new Type[2]
	{
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdStreamBuf) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxRasterServices(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxRasterServices obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxRasterServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxRasterServices cast(OdRxObject pObj)
	{
		OdRxRasterServices rXObject = Helpers.GetRXObject<OdRxRasterServices>(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_isASwigExplicitOdRxRasterServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_queryXSwigExplicitOdRxRasterServices(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxRasterServices createObject()
	{
		OdRxRasterServices rXObject = Helpers.GetRXObject<OdRxRasterServices>(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage loadRasterImage(string filename, uint[] pFlagsChain)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_loadRasterImage__SWIG_0(swigCPtr, filename, Helpers.MarshalUInt32FixedArray(pFlagsChain)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage loadRasterImage(string filename)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_loadRasterImage__SWIG_1(swigCPtr, filename), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage loadRasterImage(OdStreamBuf pStreamBuf, uint[] pFlagsChain)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_loadRasterImage__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), Helpers.MarshalUInt32FixedArray(pFlagsChain)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage loadRasterImage(OdStreamBuf pStreamBuf)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_loadRasterImage__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage createRasterImage(IntPtr pImp)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("createRasterImage", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_createRasterImageSwigExplicitOdRxRasterServices(swigCPtr, pImp) : TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_createRasterImage(swigCPtr, pImp), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool saveRasterImage(OdGiRasterImage rasterImage, string filename, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_saveRasterImage__SWIG_0(swigCPtr, OdGiRasterImage.getCPtr(rasterImage), filename, Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveRasterImage(OdGiRasterImage rasterImage, string filename, uint type, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_saveRasterImage__SWIG_1(swigCPtr, OdGiRasterImage.getCPtr(rasterImage), filename, type, Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveRasterImage(OdGiRasterImage rasterImage, OdStreamBuf pStream, uint type, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_saveRasterImage__SWIG_2(swigCPtr, OdGiRasterImage.getCPtr(rasterImage), OdStreamBuf.getCPtr(pStream), type, Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool convertRasterImage(OdGiRasterImage pRaster, uint type, OdStreamBuf pStreamBuf, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_convertRasterImage__SWIG_0(swigCPtr, OdGiRasterImage.getCPtr(pRaster), type, OdStreamBuf.getCPtr(pStreamBuf), Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool convertRasterImage(OdGiRasterImage pRaster, uint type, OdStreamBuf pStreamBuf)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_convertRasterImage__SWIG_1(swigCPtr, OdGiRasterImage.getCPtr(pRaster), type, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool convertRasterImage(OdStreamBuf pSrcStream, OdStreamBuf pDstStream, uint type, uint[] pFlagsChainSrc, uint[] pFlagsChainDst)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_convertRasterImage__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pSrcStream), OdStreamBuf.getCPtr(pDstStream), type, Helpers.MarshalUInt32FixedArray(pFlagsChainSrc), Helpers.MarshalUInt32FixedArray(pFlagsChainDst));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool convertRasterImage(OdStreamBuf pSrcStream, OdStreamBuf pDstStream, uint type, uint[] pFlagsChainSrc)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_convertRasterImage__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pSrcStream), OdStreamBuf.getCPtr(pDstStream), type, Helpers.MarshalUInt32FixedArray(pFlagsChainSrc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool convertRasterImage(OdStreamBuf pSrcStream, OdStreamBuf pDstStream, uint type)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_convertRasterImage__SWIG_4(swigCPtr, OdStreamBuf.getCPtr(pSrcStream), OdStreamBuf.getCPtr(pDstStream), type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdUInt32Array getRasterImageTypes()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_getRasterImageTypes(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isRasterImageTypeSupported(uint type)
	{
		bool result = (SwigDerivedClassHasMethod("isRasterImageTypeSupported", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_isRasterImageTypeSupportedSwigExplicitOdRxRasterServices(swigCPtr, type) : TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_isRasterImageTypeSupported(swigCPtr, type));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string mapTypeToExtension(uint type, string psFilterName)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_mapTypeToExtension(swigCPtr, type, psFilterName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint mapExtensionToType(string extension)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_mapExtensionToType(swigCPtr, extension);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getImageFormat(string filename)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_getImageFormat__SWIG_0(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getImageFormat(OdStreamBuf pStreamBuf)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_getImageFormat__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxRasterServices()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxRasterServices(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxRasterServices) != GetType();
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
		if (SwigDerivedClassHasMethod("sysData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsysData;
		}
		if (SwigDerivedClassHasMethod("deleteModule", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddeleteModule;
		}
		if (SwigDerivedClassHasMethod("initApp", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodinitApp;
		}
		if (SwigDerivedClassHasMethod("uninitApp", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoduninitApp;
		}
		if (SwigDerivedClassHasMethod("moduleName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmoduleName;
		}
		if (SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodloadRasterImage__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodloadRasterImage__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodloadRasterImage__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("loadRasterImage", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodloadRasterImage__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("createRasterImage", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcreateRasterImage;
		}
		if (SwigDerivedClassHasMethod("saveRasterImage", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsaveRasterImage__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("saveRasterImage", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsaveRasterImage__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("saveRasterImage", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsaveRasterImage__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("convertRasterImage", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodconvertRasterImage__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("convertRasterImage", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodconvertRasterImage__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("convertRasterImage", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodconvertRasterImage__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("convertRasterImage", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodconvertRasterImage__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("convertRasterImage", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodconvertRasterImage__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getRasterImageTypes", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetRasterImageTypes;
		}
		if (SwigDerivedClassHasMethod("isRasterImageTypeSupported", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodisRasterImageTypeSupported;
		}
		if (SwigDerivedClassHasMethod("mapTypeToExtension", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodmapTypeToExtension;
		}
		if (SwigDerivedClassHasMethod("mapExtensionToType", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodmapExtensionToType;
		}
		if (SwigDerivedClassHasMethod("getImageFormat", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodgetImageFormat__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getImageFormat", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetImageFormat__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxRasterServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxRasterServices));
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

	private IntPtr SwigDirectorMethodsysData()
	{
		return sysData();
	}

	private void SwigDirectorMethoddeleteModule()
	{
		try
		{
			deleteModule();
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

	private void SwigDirectorMethodinitApp()
	{
		try
		{
			initApp();
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

	private void SwigDirectorMethoduninitApp()
	{
		try
		{
			uninitApp();
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodmoduleName()
	{
		return moduleName();
	}

	private IntPtr SwigDirectorMethodloadRasterImage__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFlagsChain)
	{
		return OdGiRasterImage.getCPtr(loadRasterImage(filename, Helpers.UnMarshalUInt32FixedArray(pFlagsChain))).Handle;
	}

	private IntPtr SwigDirectorMethodloadRasterImage__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return OdGiRasterImage.getCPtr(loadRasterImage(filename)).Handle;
	}

	private IntPtr SwigDirectorMethodloadRasterImage__SWIG_2(IntPtr pStreamBuf, IntPtr pFlagsChain)
	{
		return OdGiRasterImage.getCPtr(loadRasterImage(Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalUInt32FixedArray(pFlagsChain))).Handle;
	}

	private IntPtr SwigDirectorMethodloadRasterImage__SWIG_3(IntPtr pStreamBuf)
	{
		return OdGiRasterImage.getCPtr(loadRasterImage(Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRasterImage(IntPtr pImp)
	{
		return OdGiRasterImage.getCPtr(createRasterImage(pImp)).Handle;
	}

	private bool SwigDirectorMethodsaveRasterImage__SWIG_0(IntPtr rasterImage, [MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr pFlagsChain)
	{
		return saveRasterImage(Helpers.GetRXObject<OdGiRasterImage>(rasterImage, bOwn: false, bTryAddToTransaction: false), filename, Helpers.UnMarshalUInt32FixedArray(pFlagsChain));
	}

	private bool SwigDirectorMethodsaveRasterImage__SWIG_1(IntPtr rasterImage, [MarshalAs(UnmanagedType.LPWStr)] string filename, uint type, IntPtr pFlagsChain)
	{
		return saveRasterImage(Helpers.GetRXObject<OdGiRasterImage>(rasterImage, bOwn: false, bTryAddToTransaction: false), filename, type, Helpers.UnMarshalUInt32FixedArray(pFlagsChain));
	}

	private bool SwigDirectorMethodsaveRasterImage__SWIG_2(IntPtr rasterImage, IntPtr pStream, uint type, IntPtr pFlagsChain)
	{
		return saveRasterImage(Helpers.GetRXObject<OdGiRasterImage>(rasterImage, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false), type, Helpers.UnMarshalUInt32FixedArray(pFlagsChain));
	}

	private bool SwigDirectorMethodconvertRasterImage__SWIG_0(IntPtr pRaster, uint type, IntPtr pStreamBuf, IntPtr pFlagsChain)
	{
		return convertRasterImage(Helpers.GetRXObject<OdGiRasterImage>(pRaster, bOwn: false, bTryAddToTransaction: false), type, Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false), Helpers.UnMarshalUInt32FixedArray(pFlagsChain));
	}

	private bool SwigDirectorMethodconvertRasterImage__SWIG_1(IntPtr pRaster, uint type, IntPtr pStreamBuf)
	{
		return convertRasterImage(Helpers.GetRXObject<OdGiRasterImage>(pRaster, bOwn: false, bTryAddToTransaction: false), type, Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodconvertRasterImage__SWIG_2(IntPtr pSrcStream, IntPtr pDstStream, uint type, IntPtr pFlagsChainSrc, IntPtr pFlagsChainDst)
	{
		return convertRasterImage(Helpers.GetRXObject<OdStreamBuf>(pSrcStream, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdStreamBuf>(pDstStream, bOwn: false, bTryAddToTransaction: false), type, Helpers.UnMarshalUInt32FixedArray(pFlagsChainSrc), Helpers.UnMarshalUInt32FixedArray(pFlagsChainDst));
	}

	private bool SwigDirectorMethodconvertRasterImage__SWIG_3(IntPtr pSrcStream, IntPtr pDstStream, uint type, IntPtr pFlagsChainSrc)
	{
		return convertRasterImage(Helpers.GetRXObject<OdStreamBuf>(pSrcStream, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdStreamBuf>(pDstStream, bOwn: false, bTryAddToTransaction: false), type, Helpers.UnMarshalUInt32FixedArray(pFlagsChainSrc));
	}

	private bool SwigDirectorMethodconvertRasterImage__SWIG_4(IntPtr pSrcStream, IntPtr pDstStream, uint type)
	{
		return convertRasterImage(Helpers.GetRXObject<OdStreamBuf>(pSrcStream, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdStreamBuf>(pDstStream, bOwn: false, bTryAddToTransaction: false), type);
	}

	private IntPtr SwigDirectorMethodgetRasterImageTypes()
	{
		return OdUInt32Array.getCPtr(getRasterImageTypes()).Handle;
	}

	private bool SwigDirectorMethodisRasterImageTypeSupported(uint type)
	{
		return isRasterImageTypeSupported(type);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodmapTypeToExtension(uint type, IntPtr psFilterName)
	{
		string psFilterName2 = Marshal.PtrToStringUni(psFilterName);
		return mapTypeToExtension(type, psFilterName2);
	}

	private uint SwigDirectorMethodmapExtensionToType([MarshalAs(UnmanagedType.LPWStr)] string extension)
	{
		return mapExtensionToType(extension);
	}

	private uint SwigDirectorMethodgetImageFormat__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return getImageFormat(filename);
	}

	private uint SwigDirectorMethodgetImageFormat__SWIG_1(IntPtr pStreamBuf)
	{
		return getImageFormat(Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false));
	}
}
