using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdOleItemSimplestHandler : OdOleItemHandlerBase
{
	public delegate IntPtr SwigDelegateOdOleItemSimplestHandler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdOleItemSimplestHandler_1();

	public delegate void SwigDelegateOdOleItemSimplestHandler_2(IntPtr pSource);

	public delegate bool SwigDelegateOdOleItemSimplestHandler_3(IntPtr drawObj, IntPtr hdc, IntPtr screenRect);

	public delegate void SwigDelegateOdOleItemSimplestHandler_4(IntPtr streamBuf);

	public delegate void SwigDelegateOdOleItemSimplestHandler_5(IntPtr streamBuf);

	public delegate uint SwigDelegateOdOleItemSimplestHandler_6();

	public delegate void SwigDelegateOdOleItemSimplestHandler_7(IntPtr streamBuf);

	public delegate void SwigDelegateOdOleItemSimplestHandler_8(uint numBytes, IntPtr streamBuf);

	public delegate int SwigDelegateOdOleItemSimplestHandler_9();

	public delegate int SwigDelegateOdOleItemSimplestHandler_10();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemSimplestHandler_11();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemSimplestHandler_12();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemSimplestHandler_13();

	public delegate void SwigDelegateOdOleItemSimplestHandler_14(int drawAspect);

	public delegate int SwigDelegateOdOleItemSimplestHandler_15();

	public delegate void SwigDelegateOdOleItemSimplestHandler_16(int quality);

	public delegate bool SwigDelegateOdOleItemSimplestHandler_17(IntPtr pImage, IntPtr pRxDb);

	public delegate bool SwigDelegateOdOleItemSimplestHandler_18(IntPtr pImage);

	public delegate IntPtr SwigDelegateOdOleItemSimplestHandler_19(bool arg0);

	public delegate IntPtr SwigDelegateOdOleItemSimplestHandler_20();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdOleItemSimplestHandler_0 swigDelegate0;

	private SwigDelegateOdOleItemSimplestHandler_1 swigDelegate1;

	private SwigDelegateOdOleItemSimplestHandler_2 swigDelegate2;

	private SwigDelegateOdOleItemSimplestHandler_3 swigDelegate3;

	private SwigDelegateOdOleItemSimplestHandler_4 swigDelegate4;

	private SwigDelegateOdOleItemSimplestHandler_5 swigDelegate5;

	private SwigDelegateOdOleItemSimplestHandler_6 swigDelegate6;

	private SwigDelegateOdOleItemSimplestHandler_7 swigDelegate7;

	private SwigDelegateOdOleItemSimplestHandler_8 swigDelegate8;

	private SwigDelegateOdOleItemSimplestHandler_9 swigDelegate9;

	private SwigDelegateOdOleItemSimplestHandler_10 swigDelegate10;

	private SwigDelegateOdOleItemSimplestHandler_11 swigDelegate11;

	private SwigDelegateOdOleItemSimplestHandler_12 swigDelegate12;

	private SwigDelegateOdOleItemSimplestHandler_13 swigDelegate13;

	private SwigDelegateOdOleItemSimplestHandler_14 swigDelegate14;

	private SwigDelegateOdOleItemSimplestHandler_15 swigDelegate15;

	private SwigDelegateOdOleItemSimplestHandler_16 swigDelegate16;

	private SwigDelegateOdOleItemSimplestHandler_17 swigDelegate17;

	private SwigDelegateOdOleItemSimplestHandler_18 swigDelegate18;

	private SwigDelegateOdOleItemSimplestHandler_19 swigDelegate19;

	private SwigDelegateOdOleItemSimplestHandler_20 swigDelegate20;

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
	public OdOleItemSimplestHandler(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdOleItemSimplestHandler obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdOleItemSimplestHandler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override uint getCompoundDocumentDataSize()
	{
		uint result = (SwigDerivedClassHasMethod("getCompoundDocumentDataSize", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_getCompoundDocumentDataSizeSwigExplicitOdOleItemSimplestHandler(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_getCompoundDocumentDataSize(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getCompoundDocument(ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("getCompoundDocument", swigMethodTypes7))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_getCompoundDocumentSwigExplicitOdOleItemSimplestHandler(swigCPtr, ref jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_getCompoundDocument(swigCPtr, ref jarg);
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

	public override void setCompoundDocument(uint numBytes, ref OdStreamBuf streamBuf)
	{
		IntPtr jarg = ((streamBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(streamBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("setCompoundDocument", swigMethodTypes8))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_setCompoundDocumentSwigExplicitOdOleItemSimplestHandler(swigCPtr, numBytes, ref jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_setCompoundDocument(swigCPtr, numBytes, ref jarg);
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

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdOleItemSimplestHandler createObject()
	{
		OdOleItemSimplestHandler rXObject = Helpers.GetRXObject<OdOleItemSimplestHandler>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdOleItemSimplestHandler()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdOleItemSimplestHandler(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdOleItemSimplestHandler) != GetType();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemSimplestHandler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdOleItemSimplestHandler));
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
