using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProceduralGenerator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiProceduralGenerator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiProceduralGenerator_1();

	public delegate void SwigDelegateOdGiProceduralGenerator_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiProceduralGenerator_3(IntPtr pTexture, IntPtr image, double renderCoef);

	public delegate bool SwigDelegateOdGiProceduralGenerator_4(IntPtr pTexture, IntPtr image);

	public delegate void SwigDelegateOdGiProceduralGenerator_5(IntPtr color1, IntPtr color2, double radialNoise, double axialNoise, double grainThickness, IntPtr image, double renderCoef);

	public delegate void SwigDelegateOdGiProceduralGenerator_6(IntPtr color1, IntPtr color2, double radialNoise, double axialNoise, double grainThickness, IntPtr image);

	public delegate void SwigDelegateOdGiProceduralGenerator_7(IntPtr stoneColor, IntPtr veinColor, double veinSpacing, double veinWidth, IntPtr image, double renderCoef);

	public delegate void SwigDelegateOdGiProceduralGenerator_8(IntPtr stoneColor, IntPtr veinColor, double veinSpacing, double veinWidth, IntPtr image);

	public delegate void SwigDelegateOdGiProceduralGenerator_9(IntPtr gradient);

	public delegate IntPtr SwigDelegateOdGiProceduralGenerator_10();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiProceduralGenerator_0 swigDelegate0;

	private SwigDelegateOdGiProceduralGenerator_1 swigDelegate1;

	private SwigDelegateOdGiProceduralGenerator_2 swigDelegate2;

	private SwigDelegateOdGiProceduralGenerator_3 swigDelegate3;

	private SwigDelegateOdGiProceduralGenerator_4 swigDelegate4;

	private SwigDelegateOdGiProceduralGenerator_5 swigDelegate5;

	private SwigDelegateOdGiProceduralGenerator_6 swigDelegate6;

	private SwigDelegateOdGiProceduralGenerator_7 swigDelegate7;

	private SwigDelegateOdGiProceduralGenerator_8 swigDelegate8;

	private SwigDelegateOdGiProceduralGenerator_9 swigDelegate9;

	private SwigDelegateOdGiProceduralGenerator_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdGiProceduralTexture),
		typeof(OdGiImageBGRA32),
		typeof(double)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiProceduralTexture),
		typeof(OdGiImageBGRA32)
	};

	private static Type[] swigMethodTypes5 = new Type[7]
	{
		typeof(OdGiPixelBGRA32),
		typeof(OdGiPixelBGRA32),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(OdGiImageBGRA32),
		typeof(double)
	};

	private static Type[] swigMethodTypes6 = new Type[6]
	{
		typeof(OdGiPixelBGRA32),
		typeof(OdGiPixelBGRA32),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(OdGiImageBGRA32)
	};

	private static Type[] swigMethodTypes7 = new Type[6]
	{
		typeof(OdGiPixelBGRA32),
		typeof(OdGiPixelBGRA32),
		typeof(double),
		typeof(double),
		typeof(OdGiImageBGRA32),
		typeof(double)
	};

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(OdGiPixelBGRA32),
		typeof(OdGiPixelBGRA32),
		typeof(double),
		typeof(double),
		typeof(OdGiImageBGRA32)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiGradientGenerator) };

	private static Type[] swigMethodTypes10 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProceduralGenerator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProceduralGenerator obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProceduralGenerator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiProceduralGenerator cast(OdRxObject pObj)
	{
		OdGiProceduralGenerator rXObject = Helpers.GetRXObject<OdGiProceduralGenerator>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_isASwigExplicitOdGiProceduralGenerator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_queryXSwigExplicitOdGiProceduralGenerator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiProceduralGenerator createObject()
	{
		OdGiProceduralGenerator rXObject = Helpers.GetRXObject<OdGiProceduralGenerator>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool generateProceduralTexture(OdGiProceduralTexture pTexture, OdGiImageBGRA32 image, double renderCoef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_generateProceduralTexture__SWIG_0(swigCPtr, OdGiProceduralTexture.getCPtr(pTexture), OdGiImageBGRA32.getCPtr(image), renderCoef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool generateProceduralTexture(OdGiProceduralTexture pTexture, OdGiImageBGRA32 image)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_generateProceduralTexture__SWIG_1(swigCPtr, OdGiProceduralTexture.getCPtr(pTexture), OdGiImageBGRA32.getCPtr(image));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void generateProceduralWood(OdGiPixelBGRA32 color1, OdGiPixelBGRA32 color2, double radialNoise, double axialNoise, double grainThickness, OdGiImageBGRA32 image, double renderCoef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_generateProceduralWood__SWIG_0(swigCPtr, OdGiPixelBGRA32.getCPtr(color1), OdGiPixelBGRA32.getCPtr(color2), radialNoise, axialNoise, grainThickness, OdGiImageBGRA32.getCPtr(image), renderCoef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void generateProceduralWood(OdGiPixelBGRA32 color1, OdGiPixelBGRA32 color2, double radialNoise, double axialNoise, double grainThickness, OdGiImageBGRA32 image)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_generateProceduralWood__SWIG_1(swigCPtr, OdGiPixelBGRA32.getCPtr(color1), OdGiPixelBGRA32.getCPtr(color2), radialNoise, axialNoise, grainThickness, OdGiImageBGRA32.getCPtr(image));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void generateProceduralMarble(OdGiPixelBGRA32 stoneColor, OdGiPixelBGRA32 veinColor, double veinSpacing, double veinWidth, OdGiImageBGRA32 image, double renderCoef)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_generateProceduralMarble__SWIG_0(swigCPtr, OdGiPixelBGRA32.getCPtr(stoneColor), OdGiPixelBGRA32.getCPtr(veinColor), veinSpacing, veinWidth, OdGiImageBGRA32.getCPtr(image), renderCoef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void generateProceduralMarble(OdGiPixelBGRA32 stoneColor, OdGiPixelBGRA32 veinColor, double veinSpacing, double veinWidth, OdGiImageBGRA32 image)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_generateProceduralMarble__SWIG_1(swigCPtr, OdGiPixelBGRA32.getCPtr(stoneColor), OdGiPixelBGRA32.getCPtr(veinColor), veinSpacing, veinWidth, OdGiImageBGRA32.getCPtr(image));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColorGradient(OdGiGradientGenerator gradient)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_setColorGradient(swigCPtr, OdGiGradientGenerator.getCPtr(gradient));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiGradientGenerator colorGradient()
	{
		OdGiGradientGenerator result = new OdGiGradientGenerator(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_colorGradient(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiProceduralGenerator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProceduralGenerator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiProceduralGenerator) != GetType();
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
		if (SwigDerivedClassHasMethod("generateProceduralTexture", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgenerateProceduralTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("generateProceduralTexture", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgenerateProceduralTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("generateProceduralWood", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgenerateProceduralWood__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("generateProceduralWood", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgenerateProceduralWood__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("generateProceduralMarble", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgenerateProceduralMarble__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("generateProceduralMarble", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgenerateProceduralMarble__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setColorGradient", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetColorGradient;
		}
		if (SwigDerivedClassHasMethod("colorGradient", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcolorGradient;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGenerator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiProceduralGenerator));
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

	private bool SwigDirectorMethodgenerateProceduralTexture__SWIG_0(IntPtr pTexture, IntPtr image, double renderCoef)
	{
		return generateProceduralTexture(Helpers.GetRXObject<OdGiProceduralTexture>(pTexture, bOwn: true, bTryAddToTransaction: false), new OdGiImageBGRA32(image, cMemoryOwn: false), renderCoef);
	}

	private bool SwigDirectorMethodgenerateProceduralTexture__SWIG_1(IntPtr pTexture, IntPtr image)
	{
		return generateProceduralTexture(Helpers.GetRXObject<OdGiProceduralTexture>(pTexture, bOwn: true, bTryAddToTransaction: false), new OdGiImageBGRA32(image, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgenerateProceduralWood__SWIG_0(IntPtr color1, IntPtr color2, double radialNoise, double axialNoise, double grainThickness, IntPtr image, double renderCoef)
	{
		try
		{
			generateProceduralWood(new OdGiPixelBGRA32(color1, cMemoryOwn: true), new OdGiPixelBGRA32(color2, cMemoryOwn: true), radialNoise, axialNoise, grainThickness, new OdGiImageBGRA32(image, cMemoryOwn: false), renderCoef);
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

	private void SwigDirectorMethodgenerateProceduralWood__SWIG_1(IntPtr color1, IntPtr color2, double radialNoise, double axialNoise, double grainThickness, IntPtr image)
	{
		try
		{
			generateProceduralWood(new OdGiPixelBGRA32(color1, cMemoryOwn: true), new OdGiPixelBGRA32(color2, cMemoryOwn: true), radialNoise, axialNoise, grainThickness, new OdGiImageBGRA32(image, cMemoryOwn: false));
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

	private void SwigDirectorMethodgenerateProceduralMarble__SWIG_0(IntPtr stoneColor, IntPtr veinColor, double veinSpacing, double veinWidth, IntPtr image, double renderCoef)
	{
		try
		{
			generateProceduralMarble(new OdGiPixelBGRA32(stoneColor, cMemoryOwn: true), new OdGiPixelBGRA32(veinColor, cMemoryOwn: true), veinSpacing, veinWidth, new OdGiImageBGRA32(image, cMemoryOwn: false), renderCoef);
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

	private void SwigDirectorMethodgenerateProceduralMarble__SWIG_1(IntPtr stoneColor, IntPtr veinColor, double veinSpacing, double veinWidth, IntPtr image)
	{
		try
		{
			generateProceduralMarble(new OdGiPixelBGRA32(stoneColor, cMemoryOwn: true), new OdGiPixelBGRA32(veinColor, cMemoryOwn: true), veinSpacing, veinWidth, new OdGiImageBGRA32(image, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetColorGradient(IntPtr gradient)
	{
		try
		{
			setColorGradient(new OdGiGradientGenerator(gradient, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorGradient()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiGradientGenerator.getCPtr(colorGradient()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
