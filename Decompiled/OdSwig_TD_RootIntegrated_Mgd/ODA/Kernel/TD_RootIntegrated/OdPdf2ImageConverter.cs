using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdPdf2ImageConverter : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPdf2ImageConverter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdf2ImageConverter_1();

	public delegate void SwigDelegateOdPdf2ImageConverter_2(IntPtr pSource);

	public delegate int SwigDelegateOdPdf2ImageConverter_3([MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate int SwigDelegateOdPdf2ImageConverter_4([MarshalAs(UnmanagedType.LPWStr)] string filename);

	public delegate int SwigDelegateOdPdf2ImageConverter_5(IntPtr pBuf, [MarshalAs(UnmanagedType.LPWStr)] string password);

	public delegate int SwigDelegateOdPdf2ImageConverter_6(IntPtr pBuf);

	public delegate bool SwigDelegateOdPdf2ImageConverter_7();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPdf2ImageConverter_8();

	public delegate ushort SwigDelegateOdPdf2ImageConverter_9();

	public delegate int SwigDelegateOdPdf2ImageConverter_10(ushort pageNum);

	public delegate int SwigDelegateOdPdf2ImageConverter_11();

	public delegate ushort SwigDelegateOdPdf2ImageConverter_12();

	public delegate int SwigDelegateOdPdf2ImageConverter_13(IntPtr layers);

	public delegate int SwigDelegateOdPdf2ImageConverter_14(IntPtr rect);

	public delegate IntPtr SwigDelegateOdPdf2ImageConverter_15(IntPtr params_);

	public delegate IntPtr SwigDelegateOdPdf2ImageConverter_16();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdf2ImageConverter_0 swigDelegate0;

	private SwigDelegateOdPdf2ImageConverter_1 swigDelegate1;

	private SwigDelegateOdPdf2ImageConverter_2 swigDelegate2;

	private SwigDelegateOdPdf2ImageConverter_3 swigDelegate3;

	private SwigDelegateOdPdf2ImageConverter_4 swigDelegate4;

	private SwigDelegateOdPdf2ImageConverter_5 swigDelegate5;

	private SwigDelegateOdPdf2ImageConverter_6 swigDelegate6;

	private SwigDelegateOdPdf2ImageConverter_7 swigDelegate7;

	private SwigDelegateOdPdf2ImageConverter_8 swigDelegate8;

	private SwigDelegateOdPdf2ImageConverter_9 swigDelegate9;

	private SwigDelegateOdPdf2ImageConverter_10 swigDelegate10;

	private SwigDelegateOdPdf2ImageConverter_11 swigDelegate11;

	private SwigDelegateOdPdf2ImageConverter_12 swigDelegate12;

	private SwigDelegateOdPdf2ImageConverter_13 swigDelegate13;

	private SwigDelegateOdPdf2ImageConverter_14 swigDelegate14;

	private SwigDelegateOdPdf2ImageConverter_15 swigDelegate15;

	private SwigDelegateOdPdf2ImageConverter_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdStreamBuf).MakeByRefType(),
		typeof(string)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdStreamBuf).MakeByRefType() };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdPdfLayerArray) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdPdf2ImageConversionParams) };

	private static Type[] swigMethodTypes16 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdf2ImageConverter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdf2ImageConverter obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdPdf2ImageConverter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPdf2ImageConverter cast(OdRxObject pObj)
	{
		OdPdf2ImageConverter rXObject = Helpers.GetRXObject<OdPdf2ImageConverter>(TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_isASwigExplicitOdPdf2ImageConverter(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_queryXSwigExplicitOdPdf2ImageConverter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPdf2ImageConverter createObject()
	{
		OdPdf2ImageConverter rXObject = Helpers.GetRXObject<OdPdf2ImageConverter>(TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult loadPdf(string filename, string password)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_loadPdf__SWIG_0(swigCPtr, filename, password);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult loadPdf(string filename)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_loadPdf__SWIG_1(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult loadPdf(ref OdStreamBuf pBuf, string password)
	{
		IntPtr jarg = ((pBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(pBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_loadPdf__SWIG_2(swigCPtr, ref jarg, password);
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
				pBuf = null;
			}
			else if (jarg != intPtr)
			{
				pBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult loadPdf(ref OdStreamBuf pBuf)
	{
		IntPtr jarg = ((pBuf == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(pBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_loadPdf__SWIG_3(swigCPtr, ref jarg);
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
				pBuf = null;
			}
			else if (jarg != intPtr)
			{
				pBuf = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual bool isLoaded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_isLoaded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilename()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_getFilename(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort getPagesCount()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_getPagesCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setActivePage(ushort pageNum)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_setActivePage__SWIG_0(swigCPtr, pageNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setActivePage()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_setActivePage__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual ushort getActivePage()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_getActivePage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getLayers(OdPdfLayerArray layers)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_getLayers(swigCPtr, OdPdfLayerArray.getCPtr(layers));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getPageSize(OdGsDCRect rect)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_getPageSize(swigCPtr, OdGsDCRect.getCPtr(rect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdGiRasterImage convertPdf(OdPdf2ImageConversionParams params_)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_convertPdf__SWIG_0(swigCPtr, OdPdf2ImageConversionParams.getCPtr(params_)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage convertPdf()
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_convertPdf__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPdf2ImageConverter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdPdf2ImageConverter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdf2ImageConverter) != GetType();
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
		if (SwigDerivedClassHasMethod("loadPdf", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodloadPdf__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("loadPdf", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodloadPdf__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("loadPdf", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodloadPdf__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("loadPdf", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodloadPdf__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("isLoaded", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisLoaded;
		}
		if (SwigDerivedClassHasMethod("getFilename", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetFilename;
		}
		if (SwigDerivedClassHasMethod("getPagesCount", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetPagesCount;
		}
		if (SwigDerivedClassHasMethod("setActivePage", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetActivePage__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setActivePage", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetActivePage__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getActivePage", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetActivePage;
		}
		if (SwigDerivedClassHasMethod("getLayers", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetLayers;
		}
		if (SwigDerivedClassHasMethod("getPageSize", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetPageSize;
		}
		if (SwigDerivedClassHasMethod("convertPdf", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodconvertPdf__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("convertPdf", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodconvertPdf__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdPdf2ImageConverter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdf2ImageConverter));
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

	private int SwigDirectorMethodloadPdf__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.LPWStr)] string password)
	{
		return (int)loadPdf(filename, password);
	}

	private int SwigDirectorMethodloadPdf__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		return (int)loadPdf(filename);
	}

	private int SwigDirectorMethodloadPdf__SWIG_2(IntPtr pBuf, [MarshalAs(UnmanagedType.LPWStr)] string password)
	{
		OdSwigDirectorHelper.director_UnpackData(pBuf, out var pOriginalObject, out var pFunction);
		OdStreamBuf pBuf2 = Helpers.GetRXObject<OdStreamBuf>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)loadPdf(ref pBuf2, password);
		}
		finally
		{
			IntPtr handle = OdStreamBuf.getCPtr(pBuf2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pBuf);
		}
	}

	private int SwigDirectorMethodloadPdf__SWIG_3(IntPtr pBuf)
	{
		OdSwigDirectorHelper.director_UnpackData(pBuf, out var pOriginalObject, out var pFunction);
		OdStreamBuf pBuf2 = Helpers.GetRXObject<OdStreamBuf>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)loadPdf(ref pBuf2);
		}
		finally
		{
			IntPtr handle = OdStreamBuf.getCPtr(pBuf2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pBuf);
		}
	}

	private bool SwigDirectorMethodisLoaded()
	{
		return isLoaded();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFilename()
	{
		return getFilename();
	}

	private ushort SwigDirectorMethodgetPagesCount()
	{
		return getPagesCount();
	}

	private int SwigDirectorMethodsetActivePage__SWIG_0(ushort pageNum)
	{
		return (int)setActivePage(pageNum);
	}

	private int SwigDirectorMethodsetActivePage__SWIG_1()
	{
		return (int)setActivePage();
	}

	private ushort SwigDirectorMethodgetActivePage()
	{
		return getActivePage();
	}

	private int SwigDirectorMethodgetLayers(IntPtr layers)
	{
		return (int)getLayers(new OdPdfLayerArray(layers, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetPageSize(IntPtr rect)
	{
		return (int)getPageSize(new OdGsDCRect(rect, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodconvertPdf__SWIG_0(IntPtr params_)
	{
		return OdGiRasterImage.getCPtr(convertPdf((params_ == IntPtr.Zero) ? null : new OdPdf2ImageConversionParams(params_, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodconvertPdf__SWIG_1()
	{
		return OdGiRasterImage.getCPtr(convertPdf()).Handle;
	}
}
