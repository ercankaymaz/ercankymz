using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFaceStyle : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiFaceStyle_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiFaceStyle_1();

	public delegate void SwigDelegateOdGiFaceStyle_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiFaceStyle_3(int lightingModel);

	public delegate int SwigDelegateOdGiFaceStyle_4();

	public delegate void SwigDelegateOdGiFaceStyle_5(int lightingQuality);

	public delegate int SwigDelegateOdGiFaceStyle_6();

	public delegate void SwigDelegateOdGiFaceStyle_7(int mode);

	public delegate int SwigDelegateOdGiFaceStyle_8();

	public delegate void SwigDelegateOdGiFaceStyle_9(uint nModifiers);

	public delegate void SwigDelegateOdGiFaceStyle_10(int flag, bool bEnable);

	public delegate uint SwigDelegateOdGiFaceStyle_11();

	public delegate bool SwigDelegateOdGiFaceStyle_12(int flag);

	public delegate void SwigDelegateOdGiFaceStyle_13(double nLevel, bool bEnableModifier);

	public delegate double SwigDelegateOdGiFaceStyle_14();

	public delegate void SwigDelegateOdGiFaceStyle_15(double nAmount, bool bEnableModifier);

	public delegate double SwigDelegateOdGiFaceStyle_16();

	public delegate void SwigDelegateOdGiFaceStyle_17(IntPtr color, bool bEnableMode);

	public delegate IntPtr SwigDelegateOdGiFaceStyle_18();

	public delegate IntPtr SwigDelegateOdGiFaceStyle_19();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiFaceStyle_0 swigDelegate0;

	private SwigDelegateOdGiFaceStyle_1 swigDelegate1;

	private SwigDelegateOdGiFaceStyle_2 swigDelegate2;

	private SwigDelegateOdGiFaceStyle_3 swigDelegate3;

	private SwigDelegateOdGiFaceStyle_4 swigDelegate4;

	private SwigDelegateOdGiFaceStyle_5 swigDelegate5;

	private SwigDelegateOdGiFaceStyle_6 swigDelegate6;

	private SwigDelegateOdGiFaceStyle_7 swigDelegate7;

	private SwigDelegateOdGiFaceStyle_8 swigDelegate8;

	private SwigDelegateOdGiFaceStyle_9 swigDelegate9;

	private SwigDelegateOdGiFaceStyle_10 swigDelegate10;

	private SwigDelegateOdGiFaceStyle_11 swigDelegate11;

	private SwigDelegateOdGiFaceStyle_12 swigDelegate12;

	private SwigDelegateOdGiFaceStyle_13 swigDelegate13;

	private SwigDelegateOdGiFaceStyle_14 swigDelegate14;

	private SwigDelegateOdGiFaceStyle_15 swigDelegate15;

	private SwigDelegateOdGiFaceStyle_16 swigDelegate16;

	private SwigDelegateOdGiFaceStyle_17 swigDelegate17;

	private SwigDelegateOdGiFaceStyle_18 swigDelegate18;

	private SwigDelegateOdGiFaceStyle_19 swigDelegate19;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiFaceStyle_LightingModel) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiFaceStyle_LightingQuality) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiFaceStyle_FaceColorMode) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGiFaceStyle_FaceModifier),
		typeof(bool)
	};

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdGiFaceStyle_FaceModifier) };

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdCmColorBase),
		typeof(bool)
	};

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFaceStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFaceStyle obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFaceStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiFaceStyle cast(OdRxObject pObj)
	{
		OdGiFaceStyle rXObject = Helpers.GetRXObject<OdGiFaceStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_isASwigExplicitOdGiFaceStyle(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_queryXSwigExplicitOdGiFaceStyle(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiFaceStyle createObject()
	{
		OdGiFaceStyle rXObject = Helpers.GetRXObject<OdGiFaceStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void set(OdGiFaceStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_set(swigCPtr, getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiFaceStyle Assign(OdGiFaceStyle style)
	{
		OdGiFaceStyle rXObject = Helpers.GetRXObject<OdGiFaceStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_Assign(swigCPtr, getCPtr(style)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdGiFaceStyle style)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_IsEqual(swigCPtr, getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLightingModel(OdGiFaceStyle_LightingModel lightingModel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setLightingModel(swigCPtr, (int)lightingModel);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiFaceStyle_LightingModel lightingModel()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_lightingModel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFaceStyle_LightingModel)result;
	}

	public virtual void setLightingQuality(OdGiFaceStyle_LightingQuality lightingQuality)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setLightingQuality(swigCPtr, (int)lightingQuality);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiFaceStyle_LightingQuality lightingQuality()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_lightingQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFaceStyle_LightingQuality)result;
	}

	public virtual void setFaceColorMode(OdGiFaceStyle_FaceColorMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setFaceColorMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiFaceStyle_FaceColorMode faceColorMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_faceColorMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFaceStyle_FaceColorMode)result;
	}

	public virtual void setFaceModifiers(uint nModifiers)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setFaceModifiers(swigCPtr, nModifiers);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFaceModifierFlag(OdGiFaceStyle_FaceModifier flag, bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setFaceModifierFlag(swigCPtr, (int)flag, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint faceModifiers()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_faceModifiers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isFaceModifierFlagSet(OdGiFaceStyle_FaceModifier flag)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_isFaceModifierFlagSet(swigCPtr, (int)flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOpacityLevel(double nLevel, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setOpacityLevel(swigCPtr, nLevel, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double opacityLevel()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_opacityLevel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSpecularAmount(double nAmount, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setSpecularAmount(swigCPtr, nAmount, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double specularAmount()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_specularAmount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMonoColor(OdCmColorBase color, bool bEnableMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_setMonoColor(swigCPtr, OdCmColorBase.getCPtr(color), bEnableMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColorBase monoColor()
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_monoColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiFaceStyle()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFaceStyle(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiFaceStyle) != GetType();
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
		if (SwigDerivedClassHasMethod("setLightingModel", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetLightingModel;
		}
		if (SwigDerivedClassHasMethod("lightingModel", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodlightingModel;
		}
		if (SwigDerivedClassHasMethod("setLightingQuality", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetLightingQuality;
		}
		if (SwigDerivedClassHasMethod("lightingQuality", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodlightingQuality;
		}
		if (SwigDerivedClassHasMethod("setFaceColorMode", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetFaceColorMode;
		}
		if (SwigDerivedClassHasMethod("faceColorMode", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodfaceColorMode;
		}
		if (SwigDerivedClassHasMethod("setFaceModifiers", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetFaceModifiers;
		}
		if (SwigDerivedClassHasMethod("setFaceModifierFlag", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetFaceModifierFlag;
		}
		if (SwigDerivedClassHasMethod("faceModifiers", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodfaceModifiers;
		}
		if (SwigDerivedClassHasMethod("isFaceModifierFlagSet", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodisFaceModifierFlagSet;
		}
		if (SwigDerivedClassHasMethod("setOpacityLevel", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetOpacityLevel;
		}
		if (SwigDerivedClassHasMethod("opacityLevel", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodopacityLevel;
		}
		if (SwigDerivedClassHasMethod("setSpecularAmount", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetSpecularAmount;
		}
		if (SwigDerivedClassHasMethod("specularAmount", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodspecularAmount;
		}
		if (SwigDerivedClassHasMethod("setMonoColor", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetMonoColor;
		}
		if (SwigDerivedClassHasMethod("monoColor", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodmonoColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("monoColor", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodmonoColor__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceStyle_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiFaceStyle));
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

	private void SwigDirectorMethodsetLightingModel(int lightingModel)
	{
		try
		{
			setLightingModel((OdGiFaceStyle_LightingModel)lightingModel);
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

	private int SwigDirectorMethodlightingModel()
	{
		return (int)lightingModel();
	}

	private void SwigDirectorMethodsetLightingQuality(int lightingQuality)
	{
		try
		{
			setLightingQuality((OdGiFaceStyle_LightingQuality)lightingQuality);
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

	private int SwigDirectorMethodlightingQuality()
	{
		return (int)lightingQuality();
	}

	private void SwigDirectorMethodsetFaceColorMode(int mode)
	{
		try
		{
			setFaceColorMode((OdGiFaceStyle_FaceColorMode)mode);
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

	private int SwigDirectorMethodfaceColorMode()
	{
		return (int)faceColorMode();
	}

	private void SwigDirectorMethodsetFaceModifiers(uint nModifiers)
	{
		try
		{
			setFaceModifiers(nModifiers);
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

	private void SwigDirectorMethodsetFaceModifierFlag(int flag, bool bEnable)
	{
		try
		{
			setFaceModifierFlag((OdGiFaceStyle_FaceModifier)flag, bEnable);
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

	private uint SwigDirectorMethodfaceModifiers()
	{
		return faceModifiers();
	}

	private bool SwigDirectorMethodisFaceModifierFlagSet(int flag)
	{
		return isFaceModifierFlagSet((OdGiFaceStyle_FaceModifier)flag);
	}

	private void SwigDirectorMethodsetOpacityLevel(double nLevel, bool bEnableModifier)
	{
		try
		{
			setOpacityLevel(nLevel, bEnableModifier);
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

	private double SwigDirectorMethodopacityLevel()
	{
		return opacityLevel();
	}

	private void SwigDirectorMethodsetSpecularAmount(double nAmount, bool bEnableModifier)
	{
		try
		{
			setSpecularAmount(nAmount, bEnableModifier);
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

	private double SwigDirectorMethodspecularAmount()
	{
		return specularAmount();
	}

	private void SwigDirectorMethodsetMonoColor(IntPtr color, bool bEnableMode)
	{
		try
		{
			setMonoColor(Helpers.GetObject<OdCmColorBase>(color, bOwn: false, bTryAddToTransaction: false), bEnableMode);
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

	private IntPtr SwigDirectorMethodmonoColor__SWIG_0()
	{
		return OdCmColorBase.getCPtr(monoColor()).Handle;
	}

	private IntPtr SwigDirectorMethodmonoColor__SWIG_1()
	{
		return OdCmColorBase.getCPtr(monoColor()).Handle;
	}
}
