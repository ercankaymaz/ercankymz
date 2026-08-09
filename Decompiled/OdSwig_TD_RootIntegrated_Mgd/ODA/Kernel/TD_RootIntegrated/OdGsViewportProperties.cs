using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsViewportProperties : OdGsProperties
{
	public delegate IntPtr SwigDelegateOdGsViewportProperties_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsViewportProperties_1();

	public delegate void SwigDelegateOdGsViewportProperties_2(IntPtr pSource);

	public delegate int SwigDelegateOdGsViewportProperties_3();

	public delegate IntPtr SwigDelegateOdGsViewportProperties_4(int type);

	public delegate void SwigDelegateOdGsViewportProperties_5(IntPtr pUnderlyingDrawable, IntPtr view, uint incFlags);

	public delegate void SwigDelegateOdGsViewportProperties_6(IntPtr pUnderlyingDrawable, IntPtr view);

	public delegate void SwigDelegateOdGsViewportProperties_7(IntPtr view, IntPtr pdro, uint incFlags);

	public delegate void SwigDelegateOdGsViewportProperties_8(IntPtr view, IntPtr pdro);

	public delegate void SwigDelegateOdGsViewportProperties_9(IntPtr view);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsViewportProperties_0 swigDelegate0;

	private SwigDelegateOdGsViewportProperties_1 swigDelegate1;

	private SwigDelegateOdGsViewportProperties_2 swigDelegate2;

	private SwigDelegateOdGsViewportProperties_3 swigDelegate3;

	private SwigDelegateOdGsViewportProperties_4 swigDelegate4;

	private SwigDelegateOdGsViewportProperties_5 swigDelegate5;

	private SwigDelegateOdGsViewportProperties_6 swigDelegate6;

	private SwigDelegateOdGsViewportProperties_7 swigDelegate7;

	private SwigDelegateOdGsViewportProperties_8 swigDelegate8;

	private SwigDelegateOdGsViewportProperties_9 swigDelegate9;

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
	public OdGsViewportProperties(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsViewportProperties obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsViewportProperties(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsViewportProperties cast(OdRxObject pObj)
	{
		OdGsViewportProperties rXObject = Helpers.GetRXObject<OdGsViewportProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_isASwigExplicitOdGsViewportProperties(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_queryXSwigExplicitOdGsViewportProperties(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsViewportProperties()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsViewportProperties(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsViewportProperties) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdGiViewportTraitsData viewportTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_viewportTraitsData(swigCPtr);
		OdGiViewportTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiViewportTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTraitsModified()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_isTraitsModified(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearTraits()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_clearTraits(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsProperties_PropertiesType propertiesType()
	{
		int result = (SwigDerivedClassHasMethod("propertiesType", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_propertiesTypeSwigExplicitOdGsViewportProperties(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_propertiesType(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsProperties_PropertiesType)result;
	}

	public override OdGsProperties propertiesForType(OdGsProperties_PropertiesType type)
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(SwigDerivedClassHasMethod("propertiesForType", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_propertiesForTypeSwigExplicitOdGsViewportProperties(swigCPtr, (int)type) : TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_propertiesForType(swigCPtr, (int)type), bOwn: true, bTryAddToTransaction: true);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_updateSwigExplicitOdGsViewportProperties__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view), incFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_update__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view), incFlags);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_updateSwigExplicitOdGsViewportProperties__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_update__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view));
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_displaySwigExplicitOdGsViewportProperties__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_display__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_displaySwigExplicitOdGsViewportProperties__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_display__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_displaySwigExplicitOdGsViewportProperties__SWIG_2(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_display__SWIG_2(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGsViewportProperties createObject()
	{
		OdGsViewportProperties rXObject = Helpers.GetRXObject<OdGsViewportProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewportProperties_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsViewportProperties));
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
