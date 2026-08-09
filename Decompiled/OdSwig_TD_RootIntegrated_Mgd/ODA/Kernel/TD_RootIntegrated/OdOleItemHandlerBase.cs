using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdOleItemHandlerBase : OdOleItemHandler
{
	public delegate IntPtr SwigDelegateOdOleItemHandlerBase_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdOleItemHandlerBase_1();

	public delegate void SwigDelegateOdOleItemHandlerBase_2(IntPtr pSource);

	public delegate bool SwigDelegateOdOleItemHandlerBase_3(IntPtr drawObj, IntPtr hdc, IntPtr screenRect);

	public delegate void SwigDelegateOdOleItemHandlerBase_4(IntPtr streamBuf);

	public delegate void SwigDelegateOdOleItemHandlerBase_5(IntPtr streamBuf);

	public delegate uint SwigDelegateOdOleItemHandlerBase_6();

	public delegate void SwigDelegateOdOleItemHandlerBase_7(IntPtr streamBuf);

	public delegate void SwigDelegateOdOleItemHandlerBase_8(uint numBytes, IntPtr streamBuf);

	public delegate int SwigDelegateOdOleItemHandlerBase_9();

	public delegate int SwigDelegateOdOleItemHandlerBase_10();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemHandlerBase_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemHandlerBase_12();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemHandlerBase_13();

	public delegate void SwigDelegateOdOleItemHandlerBase_14(int drawAspect);

	public delegate int SwigDelegateOdOleItemHandlerBase_15();

	public delegate void SwigDelegateOdOleItemHandlerBase_16(int quality);

	public delegate bool SwigDelegateOdOleItemHandlerBase_17(IntPtr pImage, IntPtr pRxDb);

	public delegate bool SwigDelegateOdOleItemHandlerBase_18(IntPtr pImage);

	public delegate IntPtr SwigDelegateOdOleItemHandlerBase_19(bool arg0);

	public delegate IntPtr SwigDelegateOdOleItemHandlerBase_20();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdOleItemHandlerBase_0 swigDelegate0;

	private SwigDelegateOdOleItemHandlerBase_1 swigDelegate1;

	private SwigDelegateOdOleItemHandlerBase_2 swigDelegate2;

	private SwigDelegateOdOleItemHandlerBase_3 swigDelegate3;

	private SwigDelegateOdOleItemHandlerBase_4 swigDelegate4;

	private SwigDelegateOdOleItemHandlerBase_5 swigDelegate5;

	private SwigDelegateOdOleItemHandlerBase_6 swigDelegate6;

	private SwigDelegateOdOleItemHandlerBase_7 swigDelegate7;

	private SwigDelegateOdOleItemHandlerBase_8 swigDelegate8;

	private SwigDelegateOdOleItemHandlerBase_9 swigDelegate9;

	private SwigDelegateOdOleItemHandlerBase_10 swigDelegate10;

	private SwigDelegateOdOleItemHandlerBase_11 swigDelegate11;

	private SwigDelegateOdOleItemHandlerBase_12 swigDelegate12;

	private SwigDelegateOdOleItemHandlerBase_13 swigDelegate13;

	private SwigDelegateOdOleItemHandlerBase_14 swigDelegate14;

	private SwigDelegateOdOleItemHandlerBase_15 swigDelegate15;

	private SwigDelegateOdOleItemHandlerBase_16 swigDelegate16;

	private SwigDelegateOdOleItemHandlerBase_17 swigDelegate17;

	private SwigDelegateOdOleItemHandlerBase_18 swigDelegate18;

	private SwigDelegateOdOleItemHandlerBase_19 swigDelegate19;

	private SwigDelegateOdOleItemHandlerBase_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdGiCommonDraw),
		typeof(IntPtr),
		typeof(OdGsDCRect)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdStreamBuf).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdStreamBuf).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdStreamBuf).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(uint),
		typeof(OdStreamBuf).MakeByRefType()
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdOleItemHandler_DvAspect) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdOleItemHandler_PlotQuality) };

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdGiRasterImage),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdGiRasterImage) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes20 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdOleItemHandlerBase(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdOleItemHandlerBase obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdOleItemHandlerBase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdOleItemHandlerBase()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdOleItemHandlerBase(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdOleItemHandlerBase) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdOleItemHandlerBase cast(OdRxObject pObj)
	{
		OdOleItemHandlerBase rXObject = Helpers.GetRXObject<OdOleItemHandlerBase>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_isASwigExplicitOdOleItemHandlerBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_queryXSwigExplicitOdOleItemHandlerBase(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdOleItemHandlerBase createObject()
	{
		OdOleItemHandlerBase rXObject = Helpers.GetRXObject<OdOleItemHandlerBase>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void load(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("load", swigMethodTypes4))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_loadSwigExplicitOdOleItemHandlerBase(swigCPtr, ref jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_load(swigCPtr, ref jarg);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override void save(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("save", swigMethodTypes5))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_saveSwigExplicitOdOleItemHandlerBase(swigCPtr, ref jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_save(swigCPtr, ref jarg);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				streamBuf = null;
			}
			if (jarg != intPtr)
			{
				streamBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override bool draw(OdGiCommonDraw drawObj, IntPtr hdc, OdGsDCRect screenRect)
	{
		bool result = (SwigDerivedClassHasMethod("draw", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_drawSwigExplicitOdOleItemHandlerBase(swigCPtr, OdGiCommonDraw.getCPtr(drawObj), hdc, OdGsDCRect.getCPtr(screenRect)) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_draw(swigCPtr, OdGiCommonDraw.getCPtr(drawObj), hdc, OdGsDCRect.getCPtr(screenRect)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdOleItemHandler_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_typeSwigExplicitOdOleItemHandlerBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdOleItemHandler_Type)result;
	}

	public override string linkName()
	{
		string result = (SwigDerivedClassHasMethod("linkName", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_linkNameSwigExplicitOdOleItemHandlerBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_linkName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string linkPath()
	{
		string result = (SwigDerivedClassHasMethod("linkPath", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_linkPathSwigExplicitOdOleItemHandlerBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_linkPath(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string userType()
	{
		string result = (SwigDerivedClassHasMethod("userType", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_userTypeSwigExplicitOdOleItemHandlerBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_userType(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdOleItemHandler_DvAspect drawAspect()
	{
		int result = (SwigDerivedClassHasMethod("drawAspect", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_drawAspectSwigExplicitOdOleItemHandlerBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_drawAspect(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdOleItemHandler_DvAspect)result;
	}

	public override void setDrawAspect(OdOleItemHandler_DvAspect drawAspect)
	{
		if (SwigDerivedClassHasMethod("setDrawAspect", swigMethodTypes14))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setDrawAspectSwigExplicitOdOleItemHandlerBase(swigCPtr, (int)drawAspect);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setDrawAspect(swigCPtr, (int)drawAspect);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint itemId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_itemId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setItemId(uint nId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setItemId(swigCPtr, nId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdOleItemHandler_DvAspect adviseType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_adviseType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdOleItemHandler_DvAspect)result;
	}

	public void setAdviseType(OdOleItemHandler_DvAspect at)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setAdviseType(swigCPtr, (int)at);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool monikerAssigned()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_monikerAssigned(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMonikerAssigned(bool assigned)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setMonikerAssigned(swigCPtr, assigned);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint oleVersion()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_oleVersion(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOleVersion(uint oleVer)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setOleVersion(swigCPtr, oleVer);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdOleItemHandler_PlotQuality outputQuality()
	{
		int result = (SwigDerivedClassHasMethod("outputQuality", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_outputQualitySwigExplicitOdOleItemHandlerBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_outputQuality(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdOleItemHandler_PlotQuality)result;
	}

	public override void setOutputQuality(OdOleItemHandler_PlotQuality quality)
	{
		if (SwigDerivedClassHasMethod("setOutputQuality", swigMethodTypes16))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setOutputQualitySwigExplicitOdOleItemHandlerBase(swigCPtr, (int)quality);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_setOutputQuality(swigCPtr, (int)quality);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool embedRaster(OdGiRasterImage pImage, OdRxObject pRxDb)
	{
		bool result = (SwigDerivedClassHasMethod("embedRaster", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_embedRasterSwigExplicitOdOleItemHandlerBase__SWIG_0(swigCPtr, OdGiRasterImage.getCPtr(pImage), OdRxObject.getCPtr(pRxDb)) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_embedRaster__SWIG_0(swigCPtr, OdGiRasterImage.getCPtr(pImage), OdRxObject.getCPtr(pRxDb)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool embedRaster(OdGiRasterImage pImage)
	{
		bool result = (SwigDerivedClassHasMethod("embedRaster", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_embedRasterSwigExplicitOdOleItemHandlerBase__SWIG_1(swigCPtr, OdGiRasterImage.getCPtr(pImage)) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_embedRaster__SWIG_1(swigCPtr, OdGiRasterImage.getCPtr(pImage)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiRasterImage getRaster(bool arg0)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("getRaster", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getRasterSwigExplicitOdOleItemHandlerBase__SWIG_0(swigCPtr, arg0) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getRaster__SWIG_0(swigCPtr, arg0), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiRasterImage getRaster()
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("getRaster", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getRasterSwigExplicitOdOleItemHandlerBase__SWIG_1(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getRaster__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool getImageData(OdBinaryData data, ref string psExtSuffix)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(psExtSuffix);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getImageData__SWIG_0(swigCPtr, OdBinaryData.getCPtr(data).Handle, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				psExtSuffix = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getImageData(OdBinaryData data)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getImageData__SWIG_1(swigCPtr, OdBinaryData.getCPtr(data).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getWmfData(OdBinaryData data)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getWmfData(swigCPtr, OdBinaryData.getCPtr(data).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddraw;
		}
		if (SwigDerivedClassHasMethod("load", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodload;
		}
		if (SwigDerivedClassHasMethod("save", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsave;
		}
		if (SwigDerivedClassHasMethod("getCompoundDocumentDataSize", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetCompoundDocumentDataSize;
		}
		if (SwigDerivedClassHasMethod("getCompoundDocument", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetCompoundDocument;
		}
		if (SwigDerivedClassHasMethod("setCompoundDocument", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetCompoundDocument;
		}
		if (SwigDerivedClassHasMethod("type", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("drawAspect", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethoddrawAspect;
		}
		if (SwigDerivedClassHasMethod("linkName", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodlinkName;
		}
		if (SwigDerivedClassHasMethod("linkPath", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodlinkPath;
		}
		if (SwigDerivedClassHasMethod("userType", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoduserType;
		}
		if (SwigDerivedClassHasMethod("setDrawAspect", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetDrawAspect;
		}
		if (SwigDerivedClassHasMethod("outputQuality", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodoutputQuality;
		}
		if (SwigDerivedClassHasMethod("setOutputQuality", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetOutputQuality;
		}
		if (SwigDerivedClassHasMethod("embedRaster", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodembedRaster__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("embedRaster", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodembedRaster__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getRaster", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetRaster__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getRaster", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetRaster__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandlerBase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdOleItemHandlerBase));
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

	private bool SwigDirectorMethoddraw(IntPtr drawObj, IntPtr hdc, IntPtr screenRect)
	{
		return draw(Helpers.GetRXObject<OdGiCommonDraw>(drawObj, bOwn: false, bTryAddToTransaction: false), hdc, new OdGsDCRect(screenRect, cMemoryOwn: false));
	}

	private void SwigDirectorMethodload(IntPtr streamBuf)
	{
		OdSwigDirectorHelper.director_UnpackData(streamBuf, out var pOriginalObject, out var pFunction);
		OdStreamBuf streamBuf2 = Helpers.GetRXObject<OdStreamBuf>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			load(ref streamBuf2);
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
		finally
		{
			IntPtr handle = OdStreamBuf.getCPtr(streamBuf2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(streamBuf);
		}
	}

	private void SwigDirectorMethodsave(IntPtr streamBuf)
	{
		OdSwigDirectorHelper.director_UnpackData(streamBuf, out var pOriginalObject, out var pFunction);
		OdStreamBuf streamBuf2 = Helpers.GetRXObject<OdStreamBuf>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			save(ref streamBuf2);
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
		finally
		{
			IntPtr handle = OdStreamBuf.getCPtr(streamBuf2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(streamBuf);
		}
	}

	private uint SwigDirectorMethodgetCompoundDocumentDataSize()
	{
		return getCompoundDocumentDataSize();
	}

	private void SwigDirectorMethodgetCompoundDocument(IntPtr streamBuf)
	{
		OdSwigDirectorHelper.director_UnpackData(streamBuf, out var pOriginalObject, out var pFunction);
		OdStreamBuf streamBuf2 = Helpers.GetRXObject<OdStreamBuf>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			getCompoundDocument(ref streamBuf2);
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
		finally
		{
			IntPtr handle = OdStreamBuf.getCPtr(streamBuf2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(streamBuf);
		}
	}

	private void SwigDirectorMethodsetCompoundDocument(uint numBytes, IntPtr streamBuf)
	{
		OdSwigDirectorHelper.director_UnpackData(streamBuf, out var pOriginalObject, out var pFunction);
		OdStreamBuf streamBuf2 = Helpers.GetRXObject<OdStreamBuf>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			setCompoundDocument(numBytes, ref streamBuf2);
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
		finally
		{
			IntPtr handle = OdStreamBuf.getCPtr(streamBuf2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(streamBuf);
		}
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private int SwigDirectorMethoddrawAspect()
	{
		return (int)drawAspect();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodlinkName()
	{
		return linkName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodlinkPath()
	{
		return linkPath();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethoduserType()
	{
		return userType();
	}

	private void SwigDirectorMethodsetDrawAspect(int drawAspect)
	{
		try
		{
			setDrawAspect((OdOleItemHandler_DvAspect)drawAspect);
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

	private int SwigDirectorMethodoutputQuality()
	{
		return (int)outputQuality();
	}

	private void SwigDirectorMethodsetOutputQuality(int quality)
	{
		try
		{
			setOutputQuality((OdOleItemHandler_PlotQuality)quality);
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

	private bool SwigDirectorMethodembedRaster__SWIG_0(IntPtr pImage, IntPtr pRxDb)
	{
		return embedRaster(Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: true, bTryAddToTransaction: false), Helpers.GetRXObject<OdRxObject>(pRxDb, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodembedRaster__SWIG_1(IntPtr pImage)
	{
		return embedRaster(Helpers.GetRXObject<OdGiRasterImage>(pImage, bOwn: true, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgetRaster__SWIG_0(bool arg0)
	{
		return OdGiRasterImage.getCPtr(getRaster(arg0)).Handle;
	}

	private IntPtr SwigDirectorMethodgetRaster__SWIG_1()
	{
		return OdGiRasterImage.getCPtr(getRaster()).Handle;
	}
}
