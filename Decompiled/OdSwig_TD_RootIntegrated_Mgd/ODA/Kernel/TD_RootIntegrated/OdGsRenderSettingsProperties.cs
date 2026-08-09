using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsRenderSettingsProperties : OdGsProperties
{
	public delegate IntPtr SwigDelegateOdGsRenderSettingsProperties_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsRenderSettingsProperties_1();

	public delegate void SwigDelegateOdGsRenderSettingsProperties_2(IntPtr pSource);

	public delegate int SwigDelegateOdGsRenderSettingsProperties_3();

	public delegate IntPtr SwigDelegateOdGsRenderSettingsProperties_4(int type);

	public delegate void SwigDelegateOdGsRenderSettingsProperties_5(IntPtr pUnderlyingDrawable, IntPtr view, uint incFlags);

	public delegate void SwigDelegateOdGsRenderSettingsProperties_6(IntPtr pUnderlyingDrawable, IntPtr view);

	public delegate void SwigDelegateOdGsRenderSettingsProperties_7(IntPtr view, IntPtr pdro, uint incFlags);

	public delegate void SwigDelegateOdGsRenderSettingsProperties_8(IntPtr view, IntPtr pdro);

	public delegate void SwigDelegateOdGsRenderSettingsProperties_9(IntPtr view);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsRenderSettingsProperties_0 swigDelegate0;

	private SwigDelegateOdGsRenderSettingsProperties_1 swigDelegate1;

	private SwigDelegateOdGsRenderSettingsProperties_2 swigDelegate2;

	private SwigDelegateOdGsRenderSettingsProperties_3 swigDelegate3;

	private SwigDelegateOdGsRenderSettingsProperties_4 swigDelegate4;

	private SwigDelegateOdGsRenderSettingsProperties_5 swigDelegate5;

	private SwigDelegateOdGsRenderSettingsProperties_6 swigDelegate6;

	private SwigDelegateOdGsRenderSettingsProperties_7 swigDelegate7;

	private SwigDelegateOdGsRenderSettingsProperties_8 swigDelegate8;

	private SwigDelegateOdGsRenderSettingsProperties_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGsProperties_PropertiesType) };

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdGiDrawable),
		typeof(OdGsViewImpl),
		typeof(uint)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGsViewImpl)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdGsBaseVectorizer),
		typeof(OdGsPropertiesDirectRenderOutput),
		typeof(uint)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGsBaseVectorizer),
		typeof(OdGsPropertiesDirectRenderOutput)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGsBaseVectorizer) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsRenderSettingsProperties(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsRenderSettingsProperties obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsRenderSettingsProperties(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsRenderSettingsProperties cast(OdRxObject pObj)
	{
		OdGsRenderSettingsProperties rXObject = Helpers.GetRXObject<OdGsRenderSettingsProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_isASwigExplicitOdGsRenderSettingsProperties(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_queryXSwigExplicitOdGsRenderSettingsProperties(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsRenderSettingsProperties()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsRenderSettingsProperties(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsRenderSettingsProperties) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdGiRenderSettingsTraitsData renderSettingsTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_renderSettingsTraitsData(swigCPtr);
		OdGiRenderSettingsTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiRenderSettingsTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasMentalRayRenderSettings()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_hasMentalRayRenderSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMentalRayRenderSettingsTraitsData mentalRayRenderSettingsTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_mentalRayRenderSettingsTraitsData(swigCPtr);
		OdGiMentalRayRenderSettingsTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiMentalRayRenderSettingsTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasRapidRTRenderSettings()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_hasRapidRTRenderSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRapidRTRenderSettingsTraitsData rapidRTRenderSettingsTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_rapidRTRenderSettingsTraitsData(swigCPtr);
		OdGiRapidRTRenderSettingsTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiRapidRTRenderSettingsTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasVisualizeRTRenderSettings()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_hasVisualizeRTRenderSettings(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiVisualizeRTRenderSettingsTraitsData visualizeRTRenderSettingsTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_visualizeRTRenderSettingsTraitsData(swigCPtr);
		OdGiVisualizeRTRenderSettingsTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiVisualizeRTRenderSettingsTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTraitsModified()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_isTraitsModified(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearTraits()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_clearTraits(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsProperties_PropertiesType propertiesType()
	{
		int result = (SwigDerivedClassHasMethod("propertiesType", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_propertiesTypeSwigExplicitOdGsRenderSettingsProperties(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_propertiesType(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsProperties_PropertiesType)result;
	}

	public override OdGsProperties propertiesForType(OdGsProperties_PropertiesType type)
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(SwigDerivedClassHasMethod("propertiesForType", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_propertiesForTypeSwigExplicitOdGsRenderSettingsProperties(swigCPtr, (int)type) : TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_propertiesForType(swigCPtr, (int)type), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void update(OdGiDrawable pUnderlyingDrawable, OdGsViewImpl view, uint incFlags)
	{
		if (SwigDerivedClassHasMethod("update", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_updateSwigExplicitOdGsRenderSettingsProperties__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view), incFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_update__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view), incFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void update(OdGiDrawable pUnderlyingDrawable, OdGsViewImpl view)
	{
		if (SwigDerivedClassHasMethod("update", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_updateSwigExplicitOdGsRenderSettingsProperties__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_update__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void display(OdGsBaseVectorizer view, OdGsPropertiesDirectRenderOutput pdro, uint incFlags)
	{
		if (SwigDerivedClassHasMethod("display", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_displaySwigExplicitOdGsRenderSettingsProperties__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_display__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void display(OdGsBaseVectorizer view, OdGsPropertiesDirectRenderOutput pdro)
	{
		if (SwigDerivedClassHasMethod("display", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_displaySwigExplicitOdGsRenderSettingsProperties__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_display__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void display(OdGsBaseVectorizer view)
	{
		if (SwigDerivedClassHasMethod("display", swigMethodTypes9))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_displaySwigExplicitOdGsRenderSettingsProperties__SWIG_2(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_display__SWIG_2(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGsRenderSettingsProperties createObject()
	{
		OdGsRenderSettingsProperties rXObject = Helpers.GetRXObject<OdGsRenderSettingsProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("propertiesType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodpropertiesType;
		}
		if (SwigDerivedClassHasMethod("propertiesForType", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodpropertiesForType;
		}
		if (SwigDerivedClassHasMethod("update", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodupdate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("update", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodupdate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("display", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddisplay__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("display", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddisplay__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("display", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethoddisplay__SWIG_2;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsRenderSettingsProperties_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsRenderSettingsProperties));
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

	private int SwigDirectorMethodpropertiesType()
	{
		return (int)propertiesType();
	}

	private IntPtr SwigDirectorMethodpropertiesForType(int type)
	{
		return OdGsProperties.getCPtr(propertiesForType((OdGsProperties_PropertiesType)type)).Handle;
	}

	private void SwigDirectorMethodupdate__SWIG_0(IntPtr pUnderlyingDrawable, IntPtr view, uint incFlags)
	{
		try
		{
			update(Helpers.GetRXObject<OdGiDrawable>(pUnderlyingDrawable, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsViewImpl>(view, bOwn: false, bTryAddToTransaction: false), incFlags);
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

	private void SwigDirectorMethodupdate__SWIG_1(IntPtr pUnderlyingDrawable, IntPtr view)
	{
		try
		{
			update(Helpers.GetRXObject<OdGiDrawable>(pUnderlyingDrawable, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsViewImpl>(view, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoddisplay__SWIG_0(IntPtr view, IntPtr pdro, uint incFlags)
	{
		try
		{
			display(new OdGsBaseVectorizer(view, cMemoryOwn: false), (pdro == IntPtr.Zero) ? null : new OdGsPropertiesDirectRenderOutput(pdro, cMemoryOwn: false), incFlags);
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

	private void SwigDirectorMethoddisplay__SWIG_1(IntPtr view, IntPtr pdro)
	{
		try
		{
			display(new OdGsBaseVectorizer(view, cMemoryOwn: false), (pdro == IntPtr.Zero) ? null : new OdGsPropertiesDirectRenderOutput(pdro, cMemoryOwn: false));
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

	private void SwigDirectorMethoddisplay__SWIG_2(IntPtr view)
	{
		try
		{
			display(new OdGsBaseVectorizer(view, cMemoryOwn: false));
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
}
