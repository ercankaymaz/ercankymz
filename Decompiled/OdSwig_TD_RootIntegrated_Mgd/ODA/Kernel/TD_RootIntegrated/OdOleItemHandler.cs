using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdOleItemHandler : OdGiSelfGdiDrawable
{
	public delegate IntPtr SwigDelegateOdOleItemHandler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdOleItemHandler_1();

	public delegate void SwigDelegateOdOleItemHandler_2(IntPtr pSource);

	public delegate bool SwigDelegateOdOleItemHandler_3(IntPtr drawObj, IntPtr hdc, IntPtr screenRect);

	public delegate void SwigDelegateOdOleItemHandler_4(IntPtr streamBuf);

	public delegate void SwigDelegateOdOleItemHandler_5(IntPtr streamBuf);

	public delegate uint SwigDelegateOdOleItemHandler_6();

	public delegate void SwigDelegateOdOleItemHandler_7(IntPtr streamBuf);

	public delegate void SwigDelegateOdOleItemHandler_8(uint numBytes, IntPtr streamBuf);

	public delegate int SwigDelegateOdOleItemHandler_9();

	public delegate int SwigDelegateOdOleItemHandler_10();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemHandler_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemHandler_12();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemHandler_13();

	public delegate void SwigDelegateOdOleItemHandler_14(int drawAspect);

	public delegate int SwigDelegateOdOleItemHandler_15();

	public delegate void SwigDelegateOdOleItemHandler_16(int quality);

	public delegate bool SwigDelegateOdOleItemHandler_17(IntPtr pImage, IntPtr pRxDb);

	public delegate bool SwigDelegateOdOleItemHandler_18(IntPtr pImage);

	public delegate IntPtr SwigDelegateOdOleItemHandler_19(bool bDisplayedOnly);

	public delegate IntPtr SwigDelegateOdOleItemHandler_20();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdOleItemHandler_0 swigDelegate0;

	private SwigDelegateOdOleItemHandler_1 swigDelegate1;

	private SwigDelegateOdOleItemHandler_2 swigDelegate2;

	private SwigDelegateOdOleItemHandler_3 swigDelegate3;

	private SwigDelegateOdOleItemHandler_4 swigDelegate4;

	private SwigDelegateOdOleItemHandler_5 swigDelegate5;

	private SwigDelegateOdOleItemHandler_6 swigDelegate6;

	private SwigDelegateOdOleItemHandler_7 swigDelegate7;

	private SwigDelegateOdOleItemHandler_8 swigDelegate8;

	private SwigDelegateOdOleItemHandler_9 swigDelegate9;

	private SwigDelegateOdOleItemHandler_10 swigDelegate10;

	private SwigDelegateOdOleItemHandler_11 swigDelegate11;

	private SwigDelegateOdOleItemHandler_12 swigDelegate12;

	private SwigDelegateOdOleItemHandler_13 swigDelegate13;

	private SwigDelegateOdOleItemHandler_14 swigDelegate14;

	private SwigDelegateOdOleItemHandler_15 swigDelegate15;

	private SwigDelegateOdOleItemHandler_16 swigDelegate16;

	private SwigDelegateOdOleItemHandler_17 swigDelegate17;

	private SwigDelegateOdOleItemHandler_18 swigDelegate18;

	private SwigDelegateOdOleItemHandler_19 swigDelegate19;

	private SwigDelegateOdOleItemHandler_20 swigDelegate20;

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
	public OdOleItemHandler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdOleItemHandler obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdOleItemHandler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdOleItemHandler cast(OdRxObject pObj)
	{
		OdOleItemHandler rXObject = Helpers.GetRXObject<OdOleItemHandler>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_isASwigExplicitOdOleItemHandler(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_queryXSwigExplicitOdOleItemHandler(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdOleItemHandler createObject()
	{
		OdOleItemHandler rXObject = Helpers.GetRXObject<OdOleItemHandler>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void load(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_load(swigCPtr, ref jarg);
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

	public virtual void save(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_save(swigCPtr, ref jarg);
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

	public virtual uint getCompoundDocumentDataSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_getCompoundDocumentDataSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getCompoundDocument(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_getCompoundDocument(swigCPtr, ref jarg);
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

	public virtual void setCompoundDocument(uint numBytes, ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_setCompoundDocument(swigCPtr, numBytes, ref jarg);
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

	public virtual OdOleItemHandler_Type type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdOleItemHandler_Type)result;
	}

	public virtual OdOleItemHandler_DvAspect drawAspect()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_drawAspect(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdOleItemHandler_DvAspect)result;
	}

	public virtual string linkName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_linkName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string linkPath()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_linkPath(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string userType()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_userType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDrawAspect(OdOleItemHandler_DvAspect drawAspect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_setDrawAspect(swigCPtr, (int)drawAspect);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdOleItemHandler_PlotQuality outputQuality()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_outputQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdOleItemHandler_PlotQuality)result;
	}

	public virtual void setOutputQuality(OdOleItemHandler_PlotQuality quality)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_setOutputQuality(swigCPtr, (int)quality);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool embedRaster(OdGiRasterImage pImage, OdRxObject pRxDb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_embedRaster__SWIG_0(swigCPtr, OdGiRasterImage.getCPtr(pImage), OdRxObject.getCPtr(pRxDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool embedRaster(OdGiRasterImage pImage)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_embedRaster__SWIG_1(swigCPtr, OdGiRasterImage.getCPtr(pImage));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiRasterImage getRaster(bool bDisplayedOnly)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_getRaster__SWIG_0(swigCPtr, bDisplayedOnly), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage getRaster()
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_getRaster__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemHandler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdOleItemHandler));
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

	private IntPtr SwigDirectorMethodgetRaster__SWIG_0(bool bDisplayedOnly)
	{
		return OdGiRasterImage.getCPtr(getRaster(bDisplayedOnly)).Handle;
	}

	private IntPtr SwigDirectorMethodgetRaster__SWIG_1()
	{
		return OdGiRasterImage.getCPtr(getRaster()).Handle;
	}
}
