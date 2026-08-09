using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiEnvironmentBackgroundTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiEnvironmentBackgroundTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiEnvironmentBackgroundTraits_1();

	public delegate void SwigDelegateOdGiEnvironmentBackgroundTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiEnvironmentBackgroundTraits_3(double longRad, double latRad);

	public delegate double SwigDelegateOdGiEnvironmentBackgroundTraits_4();

	public delegate double SwigDelegateOdGiEnvironmentBackgroundTraits_5();

	public delegate void SwigDelegateOdGiEnvironmentBackgroundTraits_6(bool bEnable);

	public delegate bool SwigDelegateOdGiEnvironmentBackgroundTraits_7();

	public delegate void SwigDelegateOdGiEnvironmentBackgroundTraits_8(double fovRad);

	public delegate double SwigDelegateOdGiEnvironmentBackgroundTraits_9();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_0 swigDelegate0;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_1 swigDelegate1;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_2 swigDelegate2;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_3 swigDelegate3;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_4 swigDelegate4;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_5 swigDelegate5;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_6 swigDelegate6;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_7 swigDelegate7;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_8 swigDelegate8;

	private SwigDelegateOdGiEnvironmentBackgroundTraits_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes9 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiEnvironmentBackgroundTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiEnvironmentBackgroundTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiEnvironmentBackgroundTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiEnvironmentBackgroundTraits cast(OdRxObject pObj)
	{
		OdGiEnvironmentBackgroundTraits rXObject = Helpers.GetRXObject<OdGiEnvironmentBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_isASwigExplicitOdGiEnvironmentBackgroundTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_queryXSwigExplicitOdGiEnvironmentBackgroundTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiEnvironmentBackgroundTraits createObject()
	{
		OdGiEnvironmentBackgroundTraits rXObject = Helpers.GetRXObject<OdGiEnvironmentBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRotation(double longRad, double latRad)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_setRotation(swigCPtr, longRad, latRad);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double longitudeRotation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_longitudeRotation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double latitudeRotation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_latitudeRotation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableFovOverride(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_enableFovOverride(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool fovOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_fovOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFovOverrideAngle(double fovRad)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_setFovOverrideAngle(swigCPtr, fovRad);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double fovOverrideAngle()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_fovOverrideAngle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("setRotation", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetRotation;
		}
		if (SwigDerivedClassHasMethod("longitudeRotation", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodlongitudeRotation;
		}
		if (SwigDerivedClassHasMethod("latitudeRotation", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodlatitudeRotation;
		}
		if (SwigDerivedClassHasMethod("enableFovOverride", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodenableFovOverride;
		}
		if (SwigDerivedClassHasMethod("fovOverride", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodfovOverride;
		}
		if (SwigDerivedClassHasMethod("setFovOverrideAngle", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetFovOverrideAngle;
		}
		if (SwigDerivedClassHasMethod("fovOverrideAngle", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodfovOverrideAngle;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEnvironmentBackgroundTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiEnvironmentBackgroundTraits));
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

	private void SwigDirectorMethodsetRotation(double longRad, double latRad)
	{
		try
		{
			setRotation(longRad, latRad);
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

	private double SwigDirectorMethodlongitudeRotation()
	{
		return longitudeRotation();
	}

	private double SwigDirectorMethodlatitudeRotation()
	{
		return latitudeRotation();
	}

	private void SwigDirectorMethodenableFovOverride(bool bEnable)
	{
		try
		{
			enableFovOverride(bEnable);
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

	private bool SwigDirectorMethodfovOverride()
	{
		return fovOverride();
	}

	private void SwigDirectorMethodsetFovOverrideAngle(double fovRad)
	{
		try
		{
			setFovOverrideAngle(fovRad);
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

	private double SwigDirectorMethodfovOverrideAngle()
	{
		return fovOverrideAngle();
	}
}
