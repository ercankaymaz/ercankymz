using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGroundPlaneBackgroundTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_1();

	public delegate void SwigDelegateOdGiGroundPlaneBackgroundTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiGroundPlaneBackgroundTraits_3(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_4();

	public delegate void SwigDelegateOdGiGroundPlaneBackgroundTraits_5(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_6();

	public delegate void SwigDelegateOdGiGroundPlaneBackgroundTraits_7(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_8();

	public delegate void SwigDelegateOdGiGroundPlaneBackgroundTraits_9(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_10();

	public delegate void SwigDelegateOdGiGroundPlaneBackgroundTraits_11(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_12();

	public delegate void SwigDelegateOdGiGroundPlaneBackgroundTraits_13(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGroundPlaneBackgroundTraits_14();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_0 swigDelegate0;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_1 swigDelegate1;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_2 swigDelegate2;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_3 swigDelegate3;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_4 swigDelegate4;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_5 swigDelegate5;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_6 swigDelegate6;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_7 swigDelegate7;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_8 swigDelegate8;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_9 swigDelegate9;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_10 swigDelegate10;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_11 swigDelegate11;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_12 swigDelegate12;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_13 swigDelegate13;

	private SwigDelegateOdGiGroundPlaneBackgroundTraits_14 swigDelegate14;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes14 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGroundPlaneBackgroundTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGroundPlaneBackgroundTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGroundPlaneBackgroundTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiGroundPlaneBackgroundTraits cast(OdRxObject pObj)
	{
		OdGiGroundPlaneBackgroundTraits rXObject = Helpers.GetRXObject<OdGiGroundPlaneBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_isASwigExplicitOdGiGroundPlaneBackgroundTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_queryXSwigExplicitOdGiGroundPlaneBackgroundTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiGroundPlaneBackgroundTraits createObject()
	{
		OdGiGroundPlaneBackgroundTraits rXObject = Helpers.GetRXObject<OdGiGroundPlaneBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setColorSkyZenith(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_setColorSkyZenith(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorSkyZenith()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_colorSkyZenith(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorSkyHorizon(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_setColorSkyHorizon(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorSkyHorizon()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_colorSkyHorizon(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorUndergroundHorizon(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_setColorUndergroundHorizon(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorUndergroundHorizon()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_colorUndergroundHorizon(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorUndergroundAzimuth(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_setColorUndergroundAzimuth(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorUndergroundAzimuth()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_colorUndergroundAzimuth(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorGroundPlaneNear(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_setColorGroundPlaneNear(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorGroundPlaneNear()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_colorGroundPlaneNear(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorGroundPlaneFar(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_setColorGroundPlaneFar(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorGroundPlaneFar()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_colorGroundPlaneFar(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiGroundPlaneBackgroundTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGroundPlaneBackgroundTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiGroundPlaneBackgroundTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setColorSkyZenith", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetColorSkyZenith;
		}
		if (SwigDerivedClassHasMethod("colorSkyZenith", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcolorSkyZenith;
		}
		if (SwigDerivedClassHasMethod("setColorSkyHorizon", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetColorSkyHorizon;
		}
		if (SwigDerivedClassHasMethod("colorSkyHorizon", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcolorSkyHorizon;
		}
		if (SwigDerivedClassHasMethod("setColorUndergroundHorizon", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetColorUndergroundHorizon;
		}
		if (SwigDerivedClassHasMethod("colorUndergroundHorizon", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcolorUndergroundHorizon;
		}
		if (SwigDerivedClassHasMethod("setColorUndergroundAzimuth", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetColorUndergroundAzimuth;
		}
		if (SwigDerivedClassHasMethod("colorUndergroundAzimuth", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcolorUndergroundAzimuth;
		}
		if (SwigDerivedClassHasMethod("setColorGroundPlaneNear", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetColorGroundPlaneNear;
		}
		if (SwigDerivedClassHasMethod("colorGroundPlaneNear", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcolorGroundPlaneNear;
		}
		if (SwigDerivedClassHasMethod("setColorGroundPlaneFar", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetColorGroundPlaneFar;
		}
		if (SwigDerivedClassHasMethod("colorGroundPlaneFar", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodcolorGroundPlaneFar;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGroundPlaneBackgroundTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiGroundPlaneBackgroundTraits));
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

	private void SwigDirectorMethodsetColorSkyZenith(IntPtr color)
	{
		try
		{
			setColorSkyZenith(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorSkyZenith()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorSkyZenith()).Handle;
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

	private void SwigDirectorMethodsetColorSkyHorizon(IntPtr color)
	{
		try
		{
			setColorSkyHorizon(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorSkyHorizon()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorSkyHorizon()).Handle;
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

	private void SwigDirectorMethodsetColorUndergroundHorizon(IntPtr color)
	{
		try
		{
			setColorUndergroundHorizon(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorUndergroundHorizon()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorUndergroundHorizon()).Handle;
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

	private void SwigDirectorMethodsetColorUndergroundAzimuth(IntPtr color)
	{
		try
		{
			setColorUndergroundAzimuth(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorUndergroundAzimuth()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorUndergroundAzimuth()).Handle;
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

	private void SwigDirectorMethodsetColorGroundPlaneNear(IntPtr color)
	{
		try
		{
			setColorGroundPlaneNear(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorGroundPlaneNear()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorGroundPlaneNear()).Handle;
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

	private void SwigDirectorMethodsetColorGroundPlaneFar(IntPtr color)
	{
		try
		{
			setColorGroundPlaneFar(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorGroundPlaneFar()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorGroundPlaneFar()).Handle;
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
