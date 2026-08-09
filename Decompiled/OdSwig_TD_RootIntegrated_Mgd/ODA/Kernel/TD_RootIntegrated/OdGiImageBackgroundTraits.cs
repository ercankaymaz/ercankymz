using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiImageBackgroundTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiImageBackgroundTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiImageBackgroundTraits_1();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiImageBackgroundTraits_3([MarshalAs(UnmanagedType.LPWStr)] string filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiImageBackgroundTraits_4();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_5(bool bFitToScreen);

	public delegate bool SwigDelegateOdGiImageBackgroundTraits_6();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_7(bool bMaintainAspectRatio);

	public delegate bool SwigDelegateOdGiImageBackgroundTraits_8();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_9(bool bUseTiling);

	public delegate bool SwigDelegateOdGiImageBackgroundTraits_10();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_11(double xOffset);

	public delegate double SwigDelegateOdGiImageBackgroundTraits_12();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_13(double yOffset);

	public delegate double SwigDelegateOdGiImageBackgroundTraits_14();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_15(double xScale);

	public delegate double SwigDelegateOdGiImageBackgroundTraits_16();

	public delegate void SwigDelegateOdGiImageBackgroundTraits_17(double yScale);

	public delegate double SwigDelegateOdGiImageBackgroundTraits_18();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiImageBackgroundTraits_0 swigDelegate0;

	private SwigDelegateOdGiImageBackgroundTraits_1 swigDelegate1;

	private SwigDelegateOdGiImageBackgroundTraits_2 swigDelegate2;

	private SwigDelegateOdGiImageBackgroundTraits_3 swigDelegate3;

	private SwigDelegateOdGiImageBackgroundTraits_4 swigDelegate4;

	private SwigDelegateOdGiImageBackgroundTraits_5 swigDelegate5;

	private SwigDelegateOdGiImageBackgroundTraits_6 swigDelegate6;

	private SwigDelegateOdGiImageBackgroundTraits_7 swigDelegate7;

	private SwigDelegateOdGiImageBackgroundTraits_8 swigDelegate8;

	private SwigDelegateOdGiImageBackgroundTraits_9 swigDelegate9;

	private SwigDelegateOdGiImageBackgroundTraits_10 swigDelegate10;

	private SwigDelegateOdGiImageBackgroundTraits_11 swigDelegate11;

	private SwigDelegateOdGiImageBackgroundTraits_12 swigDelegate12;

	private SwigDelegateOdGiImageBackgroundTraits_13 swigDelegate13;

	private SwigDelegateOdGiImageBackgroundTraits_14 swigDelegate14;

	private SwigDelegateOdGiImageBackgroundTraits_15 swigDelegate15;

	private SwigDelegateOdGiImageBackgroundTraits_16 swigDelegate16;

	private SwigDelegateOdGiImageBackgroundTraits_17 swigDelegate17;

	private SwigDelegateOdGiImageBackgroundTraits_18 swigDelegate18;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes18 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiImageBackgroundTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiImageBackgroundTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiImageBackgroundTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiImageBackgroundTraits cast(OdRxObject pObj)
	{
		OdGiImageBackgroundTraits rXObject = Helpers.GetRXObject<OdGiImageBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_isASwigExplicitOdGiImageBackgroundTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_queryXSwigExplicitOdGiImageBackgroundTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiImageBackgroundTraits createObject()
	{
		OdGiImageBackgroundTraits rXObject = Helpers.GetRXObject<OdGiImageBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setImageFilename(string filename)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setImageFilename(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string imageFilename()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_imageFilename(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFitToScreen(bool bFitToScreen)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setFitToScreen(swigCPtr, bFitToScreen);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool fitToScreen()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_fitToScreen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMaintainAspectRatio(bool bMaintainAspectRatio)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setMaintainAspectRatio(swigCPtr, bMaintainAspectRatio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool maintainAspectRatio()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_maintainAspectRatio(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUseTiling(bool bUseTiling)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setUseTiling(swigCPtr, bUseTiling);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool useTiling()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_useTiling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setXOffset(double xOffset)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setXOffset(swigCPtr, xOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double xOffset()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_xOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setYOffset(double yOffset)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setYOffset(swigCPtr, yOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double yOffset()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_yOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setXScale(double xScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setXScale(swigCPtr, xScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double xScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_xScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setYScale(double yScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_setYScale(swigCPtr, yScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double yScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_yScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiImageBackgroundTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiImageBackgroundTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiImageBackgroundTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setImageFilename", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetImageFilename;
		}
		if (SwigDerivedClassHasMethod("imageFilename", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodimageFilename;
		}
		if (SwigDerivedClassHasMethod("setFitToScreen", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetFitToScreen;
		}
		if (SwigDerivedClassHasMethod("fitToScreen", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodfitToScreen;
		}
		if (SwigDerivedClassHasMethod("setMaintainAspectRatio", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetMaintainAspectRatio;
		}
		if (SwigDerivedClassHasMethod("maintainAspectRatio", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodmaintainAspectRatio;
		}
		if (SwigDerivedClassHasMethod("setUseTiling", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetUseTiling;
		}
		if (SwigDerivedClassHasMethod("useTiling", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethoduseTiling;
		}
		if (SwigDerivedClassHasMethod("setXOffset", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetXOffset;
		}
		if (SwigDerivedClassHasMethod("xOffset", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodxOffset;
		}
		if (SwigDerivedClassHasMethod("setYOffset", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetYOffset;
		}
		if (SwigDerivedClassHasMethod("yOffset", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodyOffset;
		}
		if (SwigDerivedClassHasMethod("setXScale", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetXScale;
		}
		if (SwigDerivedClassHasMethod("xScale", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodxScale;
		}
		if (SwigDerivedClassHasMethod("setYScale", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetYScale;
		}
		if (SwigDerivedClassHasMethod("yScale", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodyScale;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiImageBackgroundTraits));
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

	private void SwigDirectorMethodsetImageFilename([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		try
		{
			setImageFilename(filename);
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
	private string SwigDirectorMethodimageFilename()
	{
		return imageFilename();
	}

	private void SwigDirectorMethodsetFitToScreen(bool bFitToScreen)
	{
		try
		{
			setFitToScreen(bFitToScreen);
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

	private bool SwigDirectorMethodfitToScreen()
	{
		return fitToScreen();
	}

	private void SwigDirectorMethodsetMaintainAspectRatio(bool bMaintainAspectRatio)
	{
		try
		{
			setMaintainAspectRatio(bMaintainAspectRatio);
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

	private bool SwigDirectorMethodmaintainAspectRatio()
	{
		return maintainAspectRatio();
	}

	private void SwigDirectorMethodsetUseTiling(bool bUseTiling)
	{
		try
		{
			setUseTiling(bUseTiling);
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

	private bool SwigDirectorMethoduseTiling()
	{
		return useTiling();
	}

	private void SwigDirectorMethodsetXOffset(double xOffset)
	{
		try
		{
			setXOffset(xOffset);
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

	private double SwigDirectorMethodxOffset()
	{
		return xOffset();
	}

	private void SwigDirectorMethodsetYOffset(double yOffset)
	{
		try
		{
			setYOffset(yOffset);
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

	private double SwigDirectorMethodyOffset()
	{
		return yOffset();
	}

	private void SwigDirectorMethodsetXScale(double xScale)
	{
		try
		{
			setXScale(xScale);
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

	private double SwigDirectorMethodxScale()
	{
		return xScale();
	}

	private void SwigDirectorMethodsetYScale(double yScale)
	{
		try
		{
			setYScale(yScale);
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

	private double SwigDirectorMethodyScale()
	{
		return yScale();
	}
}
