using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsProperties : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGsProperties_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsProperties_1();

	public delegate void SwigDelegateOdGsProperties_2(IntPtr pSource);

	public delegate int SwigDelegateOdGsProperties_3();

	public delegate IntPtr SwigDelegateOdGsProperties_4(int arg0);

	public delegate void SwigDelegateOdGsProperties_5(IntPtr pUnderlyingDrawable, IntPtr view, uint incFlags);

	public delegate void SwigDelegateOdGsProperties_6(IntPtr pUnderlyingDrawable, IntPtr view);

	public delegate void SwigDelegateOdGsProperties_7(IntPtr view, IntPtr pdro, uint incFlags);

	public delegate void SwigDelegateOdGsProperties_8(IntPtr view, IntPtr pdro);

	public delegate void SwigDelegateOdGsProperties_9(IntPtr view);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsProperties_0 swigDelegate0;

	private SwigDelegateOdGsProperties_1 swigDelegate1;

	private SwigDelegateOdGsProperties_2 swigDelegate2;

	private SwigDelegateOdGsProperties_3 swigDelegate3;

	private SwigDelegateOdGsProperties_4 swigDelegate4;

	private SwigDelegateOdGsProperties_5 swigDelegate5;

	private SwigDelegateOdGsProperties_6 swigDelegate6;

	private SwigDelegateOdGsProperties_7 swigDelegate7;

	private SwigDelegateOdGsProperties_8 swigDelegate8;

	private SwigDelegateOdGsProperties_9 swigDelegate9;

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
	public OdGsProperties(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsProperties obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsProperties(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsProperties cast(OdRxObject pObj)
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_isASwigExplicitOdGsProperties(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_queryXSwigExplicitOdGsProperties(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsProperties createObject()
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsProperties()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsProperties(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsProperties) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setUnderlyingDrawable(OdGiDrawable pUnderlyingDrawable, OdGiContext ctx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_setUnderlyingDrawable(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGiContext.getCPtr(ctx));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDrawable underlyingDrawable()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_underlyingDrawable(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isUnderlyingDrawableChanged(OdGiDrawable pUnderlyingDrawable)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_isUnderlyingDrawableChanged(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasUnderlyingDrawable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_hasUnderlyingDrawable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUnderlyingDrawablePersistent()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_isUnderlyingDrawablePersistent(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub underlyingDrawableId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_underlyingDrawableId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDrawable_DrawableType underlyingDrawableType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_underlyingDrawableType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDrawable_DrawableType)result;
	}

	public virtual OdGsProperties_PropertiesType propertiesType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_propertiesType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsProperties_PropertiesType)result;
	}

	public virtual OdGsProperties propertiesForType(OdGsProperties_PropertiesType arg0)
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(SwigDerivedClassHasMethod("propertiesForType", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_propertiesForTypeSwigExplicitOdGsProperties(swigCPtr, (int)arg0) : TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_propertiesForType(swigCPtr, (int)arg0), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void update(OdGiDrawable pUnderlyingDrawable, OdGsViewImpl view, uint incFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_update__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view), incFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void update(OdGiDrawable pUnderlyingDrawable, OdGsViewImpl view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_update__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void display(OdGsBaseVectorizer view, OdGsPropertiesDirectRenderOutput pdro, uint incFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_display__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void display(OdGsBaseVectorizer view, OdGsPropertiesDirectRenderOutput pdro)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_display__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void display(OdGsBaseVectorizer view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_display__SWIG_2(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGsProperties_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsProperties));
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

	private IntPtr SwigDirectorMethodpropertiesForType(int arg0)
	{
		return getCPtr(propertiesForType((OdGsProperties_PropertiesType)arg0)).Handle;
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
