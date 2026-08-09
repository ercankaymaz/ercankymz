using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiNoiseGenerator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiNoiseGenerator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiNoiseGenerator_1();

	public delegate void SwigDelegateOdGiNoiseGenerator_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiNoiseGenerator_3(uint seed);

	public delegate double SwigDelegateOdGiNoiseGenerator_4(double point);

	public delegate double SwigDelegateOdGiNoiseGenerator_5(IntPtr point);

	public delegate double SwigDelegateOdGiNoiseGenerator_6(IntPtr point);

	public delegate double SwigDelegateOdGiNoiseGenerator_7(IntPtr point, int len);

	public delegate double SwigDelegateOdGiNoiseGenerator_8(IntPtr point, double freq);

	public delegate double SwigDelegateOdGiNoiseGenerator_9(IntPtr point, double freq);

	public delegate double SwigDelegateOdGiNoiseGenerator_10(IntPtr point, double H, double lacunarity, double octaves);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiNoiseGenerator_0 swigDelegate0;

	private SwigDelegateOdGiNoiseGenerator_1 swigDelegate1;

	private SwigDelegateOdGiNoiseGenerator_2 swigDelegate2;

	private SwigDelegateOdGiNoiseGenerator_3 swigDelegate3;

	private SwigDelegateOdGiNoiseGenerator_4 swigDelegate4;

	private SwigDelegateOdGiNoiseGenerator_5 swigDelegate5;

	private SwigDelegateOdGiNoiseGenerator_6 swigDelegate6;

	private SwigDelegateOdGiNoiseGenerator_7 swigDelegate7;

	private SwigDelegateOdGiNoiseGenerator_8 swigDelegate8;

	private SwigDelegateOdGiNoiseGenerator_9 swigDelegate9;

	private SwigDelegateOdGiNoiseGenerator_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(double[]),
		typeof(int)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(double)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(double)
	};

	private static Type[] swigMethodTypes10 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiNoiseGenerator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiNoiseGenerator obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiNoiseGenerator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiNoiseGenerator cast(OdRxObject pObj)
	{
		OdGiNoiseGenerator rXObject = Helpers.GetRXObject<OdGiNoiseGenerator>(TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_isASwigExplicitOdGiNoiseGenerator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_queryXSwigExplicitOdGiNoiseGenerator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiNoiseGenerator createObject()
	{
		OdGiNoiseGenerator rXObject = Helpers.GetRXObject<OdGiNoiseGenerator>(TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void initSeed(uint seed)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_initSeed(swigCPtr, seed);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double noise1d(double point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_noise1d(swigCPtr, point);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double noise2d(OdGePoint2d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_noise2d(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double noise3d(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_noise3d(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double noise(double[] point, int len)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_noise(swigCPtr, Helpers.MarshaldoubleFixedArray(point), len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double turbulence(OdGePoint3d point, double freq)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_turbulence(swigCPtr, OdGePoint3d.getCPtr(point), freq);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double oNoise(OdGePoint3d point, double freq)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_oNoise(swigCPtr, OdGePoint3d.getCPtr(point), freq);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double fBm(OdGePoint3d point, double H, double lacunarity, double octaves)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_fBm(swigCPtr, OdGePoint3d.getCPtr(point), H, lacunarity, octaves);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiNoiseGenerator createObject(uint seed)
	{
		OdGiNoiseGenerator rXObject = Helpers.GetRXObject<OdGiNoiseGenerator>(TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_createObject__SWIG_1(seed), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiNoiseGenerator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiNoiseGenerator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiNoiseGenerator) != GetType();
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
		if (SwigDerivedClassHasMethod("initSeed", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinitSeed;
		}
		if (SwigDerivedClassHasMethod("noise1d", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodnoise1d;
		}
		if (SwigDerivedClassHasMethod("noise2d", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnoise2d;
		}
		if (SwigDerivedClassHasMethod("noise3d", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnoise3d;
		}
		if (SwigDerivedClassHasMethod("noise", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodnoise;
		}
		if (SwigDerivedClassHasMethod("turbulence", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodturbulence;
		}
		if (SwigDerivedClassHasMethod("oNoise", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodoNoise;
		}
		if (SwigDerivedClassHasMethod("fBm", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodfBm;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiNoiseGenerator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiNoiseGenerator));
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

	private void SwigDirectorMethodinitSeed(uint seed)
	{
		try
		{
			initSeed(seed);
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

	private double SwigDirectorMethodnoise1d(double point)
	{
		return noise1d(point);
	}

	private double SwigDirectorMethodnoise2d(IntPtr point)
	{
		return noise2d(new OdGePoint2d(point, cMemoryOwn: false));
	}

	private double SwigDirectorMethodnoise3d(IntPtr point)
	{
		return noise3d(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private double SwigDirectorMethodnoise(IntPtr point, int len)
	{
		return noise(Helpers.UnMarshaldoubleFixedArray(point), len);
	}

	private double SwigDirectorMethodturbulence(IntPtr point, double freq)
	{
		return turbulence(new OdGePoint3d(point, cMemoryOwn: false), freq);
	}

	private double SwigDirectorMethodoNoise(IntPtr point, double freq)
	{
		return oNoise(new OdGePoint3d(point, cMemoryOwn: false), freq);
	}

	private double SwigDirectorMethodfBm(IntPtr point, double H, double lacunarity, double octaves)
	{
		return fBm(new OdGePoint3d(point, cMemoryOwn: false), H, lacunarity, octaves);
	}
}
