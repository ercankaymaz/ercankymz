using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRenderEnvironmentTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiRenderEnvironmentTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRenderEnvironmentTraits_1();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_3(bool bEnable);

	public delegate bool SwigDelegateOdGiRenderEnvironmentTraits_4();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_5(bool bEnable);

	public delegate bool SwigDelegateOdGiRenderEnvironmentTraits_6();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_7(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiRenderEnvironmentTraits_8();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_9(double nearDist);

	public delegate double SwigDelegateOdGiRenderEnvironmentTraits_10();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_11(double farDist);

	public delegate double SwigDelegateOdGiRenderEnvironmentTraits_12();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_13(double nearPct);

	public delegate double SwigDelegateOdGiRenderEnvironmentTraits_14();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_15(double farPct);

	public delegate double SwigDelegateOdGiRenderEnvironmentTraits_16();

	public delegate void SwigDelegateOdGiRenderEnvironmentTraits_17(IntPtr m);

	public delegate IntPtr SwigDelegateOdGiRenderEnvironmentTraits_18();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRenderEnvironmentTraits_0 swigDelegate0;

	private SwigDelegateOdGiRenderEnvironmentTraits_1 swigDelegate1;

	private SwigDelegateOdGiRenderEnvironmentTraits_2 swigDelegate2;

	private SwigDelegateOdGiRenderEnvironmentTraits_3 swigDelegate3;

	private SwigDelegateOdGiRenderEnvironmentTraits_4 swigDelegate4;

	private SwigDelegateOdGiRenderEnvironmentTraits_5 swigDelegate5;

	private SwigDelegateOdGiRenderEnvironmentTraits_6 swigDelegate6;

	private SwigDelegateOdGiRenderEnvironmentTraits_7 swigDelegate7;

	private SwigDelegateOdGiRenderEnvironmentTraits_8 swigDelegate8;

	private SwigDelegateOdGiRenderEnvironmentTraits_9 swigDelegate9;

	private SwigDelegateOdGiRenderEnvironmentTraits_10 swigDelegate10;

	private SwigDelegateOdGiRenderEnvironmentTraits_11 swigDelegate11;

	private SwigDelegateOdGiRenderEnvironmentTraits_12 swigDelegate12;

	private SwigDelegateOdGiRenderEnvironmentTraits_13 swigDelegate13;

	private SwigDelegateOdGiRenderEnvironmentTraits_14 swigDelegate14;

	private SwigDelegateOdGiRenderEnvironmentTraits_15 swigDelegate15;

	private SwigDelegateOdGiRenderEnvironmentTraits_16 swigDelegate16;

	private SwigDelegateOdGiRenderEnvironmentTraits_17 swigDelegate17;

	private SwigDelegateOdGiRenderEnvironmentTraits_18 swigDelegate18;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiMaterialTexture) };

	private static Type[] swigMethodTypes18 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRenderEnvironmentTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRenderEnvironmentTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRenderEnvironmentTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRenderEnvironmentTraits cast(OdRxObject pObj)
	{
		OdGiRenderEnvironmentTraits rXObject = Helpers.GetRXObject<OdGiRenderEnvironmentTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_isASwigExplicitOdGiRenderEnvironmentTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_queryXSwigExplicitOdGiRenderEnvironmentTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiRenderEnvironmentTraits createObject()
	{
		OdGiRenderEnvironmentTraits rXObject = Helpers.GetRXObject<OdGiRenderEnvironmentTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setEnable(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setEnable(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool enable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_enable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIsBackground(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setIsBackground(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isBackground()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_isBackground(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFogColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setFogColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor fogColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_fogColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNearDistance(double nearDist)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setNearDistance(swigCPtr, nearDist);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double nearDistance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_nearDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFarDistance(double farDist)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setFarDistance(swigCPtr, farDist);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double farDistance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_farDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNearPercentage(double nearPct)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setNearPercentage(swigCPtr, nearPct);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double nearPercentage()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_nearPercentage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFarPercentage(double farPct)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setFarPercentage(swigCPtr, farPct);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double farPercentage()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_farPercentage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEnvironmentMap(OdGiMaterialTexture m)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_setEnvironmentMap(swigCPtr, OdGiMaterialTexture.getCPtr(m));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialTexture environmentMap()
	{
		OdGiMaterialTexture rXObject = Helpers.GetRXObject<OdGiMaterialTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_environmentMap(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRenderEnvironmentTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRenderEnvironmentTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRenderEnvironmentTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setEnable", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetEnable;
		}
		if (SwigDerivedClassHasMethod("enable", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodenable;
		}
		if (SwigDerivedClassHasMethod("setIsBackground", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetIsBackground;
		}
		if (SwigDerivedClassHasMethod("isBackground", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisBackground;
		}
		if (SwigDerivedClassHasMethod("setFogColor", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetFogColor;
		}
		if (SwigDerivedClassHasMethod("fogColor", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodfogColor;
		}
		if (SwigDerivedClassHasMethod("setNearDistance", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetNearDistance;
		}
		if (SwigDerivedClassHasMethod("nearDistance", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodnearDistance;
		}
		if (SwigDerivedClassHasMethod("setFarDistance", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetFarDistance;
		}
		if (SwigDerivedClassHasMethod("farDistance", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodfarDistance;
		}
		if (SwigDerivedClassHasMethod("setNearPercentage", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetNearPercentage;
		}
		if (SwigDerivedClassHasMethod("nearPercentage", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodnearPercentage;
		}
		if (SwigDerivedClassHasMethod("setFarPercentage", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetFarPercentage;
		}
		if (SwigDerivedClassHasMethod("farPercentage", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodfarPercentage;
		}
		if (SwigDerivedClassHasMethod("setEnvironmentMap", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetEnvironmentMap;
		}
		if (SwigDerivedClassHasMethod("environmentMap", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodenvironmentMap;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderEnvironmentTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRenderEnvironmentTraits));
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

	private void SwigDirectorMethodsetEnable(bool bEnable)
	{
		try
		{
			setEnable(bEnable);
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

	private bool SwigDirectorMethodenable()
	{
		return enable();
	}

	private void SwigDirectorMethodsetIsBackground(bool bEnable)
	{
		try
		{
			setIsBackground(bEnable);
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

	private bool SwigDirectorMethodisBackground()
	{
		return isBackground();
	}

	private void SwigDirectorMethodsetFogColor(IntPtr color)
	{
		try
		{
			setFogColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodfogColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(fogColor()).Handle;
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

	private void SwigDirectorMethodsetNearDistance(double nearDist)
	{
		try
		{
			setNearDistance(nearDist);
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

	private double SwigDirectorMethodnearDistance()
	{
		return nearDistance();
	}

	private void SwigDirectorMethodsetFarDistance(double farDist)
	{
		try
		{
			setFarDistance(farDist);
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

	private double SwigDirectorMethodfarDistance()
	{
		return farDistance();
	}

	private void SwigDirectorMethodsetNearPercentage(double nearPct)
	{
		try
		{
			setNearPercentage(nearPct);
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

	private double SwigDirectorMethodnearPercentage()
	{
		return nearPercentage();
	}

	private void SwigDirectorMethodsetFarPercentage(double farPct)
	{
		try
		{
			setFarPercentage(farPct);
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

	private double SwigDirectorMethodfarPercentage()
	{
		return farPercentage();
	}

	private void SwigDirectorMethodsetEnvironmentMap(IntPtr m)
	{
		try
		{
			setEnvironmentMap(Helpers.GetRXObject<OdGiMaterialTexture>(m, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodenvironmentMap()
	{
		return OdGiMaterialTexture.getCPtr(environmentMap()).Handle;
	}
}
