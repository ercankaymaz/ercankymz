using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRenderSettingsTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiRenderSettingsTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRenderSettingsTraits_1();

	public delegate void SwigDelegateOdGiRenderSettingsTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiRenderSettingsTraits_3(bool enabled);

	public delegate bool SwigDelegateOdGiRenderSettingsTraits_4();

	public delegate void SwigDelegateOdGiRenderSettingsTraits_5(bool enabled);

	public delegate bool SwigDelegateOdGiRenderSettingsTraits_6();

	public delegate void SwigDelegateOdGiRenderSettingsTraits_7(bool enabled);

	public delegate bool SwigDelegateOdGiRenderSettingsTraits_8();

	public delegate void SwigDelegateOdGiRenderSettingsTraits_9(bool enabled);

	public delegate bool SwigDelegateOdGiRenderSettingsTraits_10();

	public delegate void SwigDelegateOdGiRenderSettingsTraits_11(bool enabled);

	public delegate bool SwigDelegateOdGiRenderSettingsTraits_12();

	public delegate void SwigDelegateOdGiRenderSettingsTraits_13(double scaleFactor);

	public delegate double SwigDelegateOdGiRenderSettingsTraits_14();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRenderSettingsTraits_0 swigDelegate0;

	private SwigDelegateOdGiRenderSettingsTraits_1 swigDelegate1;

	private SwigDelegateOdGiRenderSettingsTraits_2 swigDelegate2;

	private SwigDelegateOdGiRenderSettingsTraits_3 swigDelegate3;

	private SwigDelegateOdGiRenderSettingsTraits_4 swigDelegate4;

	private SwigDelegateOdGiRenderSettingsTraits_5 swigDelegate5;

	private SwigDelegateOdGiRenderSettingsTraits_6 swigDelegate6;

	private SwigDelegateOdGiRenderSettingsTraits_7 swigDelegate7;

	private SwigDelegateOdGiRenderSettingsTraits_8 swigDelegate8;

	private SwigDelegateOdGiRenderSettingsTraits_9 swigDelegate9;

	private SwigDelegateOdGiRenderSettingsTraits_10 swigDelegate10;

	private SwigDelegateOdGiRenderSettingsTraits_11 swigDelegate11;

	private SwigDelegateOdGiRenderSettingsTraits_12 swigDelegate12;

	private SwigDelegateOdGiRenderSettingsTraits_13 swigDelegate13;

	private SwigDelegateOdGiRenderSettingsTraits_14 swigDelegate14;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRenderSettingsTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRenderSettingsTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRenderSettingsTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRenderSettingsTraits cast(OdRxObject pObj)
	{
		OdGiRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_isASwigExplicitOdGiRenderSettingsTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_queryXSwigExplicitOdGiRenderSettingsTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiRenderSettingsTraits createObject()
	{
		OdGiRenderSettingsTraits rXObject = Helpers.GetRXObject<OdGiRenderSettingsTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setMaterialEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_setMaterialEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool materialEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_materialEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextureSampling(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_setTextureSampling(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool textureSampling()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_textureSampling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackFacesEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_setBackFacesEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool backFacesEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_backFacesEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShadowsEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_setShadowsEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool shadowsEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_shadowsEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDiagnosticBackgroundEnabled(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_setDiagnosticBackgroundEnabled(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool diagnosticBackgroundEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_diagnosticBackgroundEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setModelScaleFactor(double scaleFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_setModelScaleFactor(swigCPtr, scaleFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double modelScaleFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_modelScaleFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRenderSettingsTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRenderSettingsTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRenderSettingsTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setMaterialEnabled", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetMaterialEnabled;
		}
		if (SwigDerivedClassHasMethod("materialEnabled", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodmaterialEnabled;
		}
		if (SwigDerivedClassHasMethod("setTextureSampling", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetTextureSampling;
		}
		if (SwigDerivedClassHasMethod("textureSampling", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtextureSampling;
		}
		if (SwigDerivedClassHasMethod("setBackFacesEnabled", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetBackFacesEnabled;
		}
		if (SwigDerivedClassHasMethod("backFacesEnabled", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodbackFacesEnabled;
		}
		if (SwigDerivedClassHasMethod("setShadowsEnabled", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetShadowsEnabled;
		}
		if (SwigDerivedClassHasMethod("shadowsEnabled", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodshadowsEnabled;
		}
		if (SwigDerivedClassHasMethod("setDiagnosticBackgroundEnabled", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetDiagnosticBackgroundEnabled;
		}
		if (SwigDerivedClassHasMethod("diagnosticBackgroundEnabled", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddiagnosticBackgroundEnabled;
		}
		if (SwigDerivedClassHasMethod("setModelScaleFactor", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetModelScaleFactor;
		}
		if (SwigDerivedClassHasMethod("modelScaleFactor", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodmodelScaleFactor;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRenderSettingsTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRenderSettingsTraits));
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

	private void SwigDirectorMethodsetMaterialEnabled(bool enabled)
	{
		try
		{
			setMaterialEnabled(enabled);
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

	private bool SwigDirectorMethodmaterialEnabled()
	{
		return materialEnabled();
	}

	private void SwigDirectorMethodsetTextureSampling(bool enabled)
	{
		try
		{
			setTextureSampling(enabled);
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

	private bool SwigDirectorMethodtextureSampling()
	{
		return textureSampling();
	}

	private void SwigDirectorMethodsetBackFacesEnabled(bool enabled)
	{
		try
		{
			setBackFacesEnabled(enabled);
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

	private bool SwigDirectorMethodbackFacesEnabled()
	{
		return backFacesEnabled();
	}

	private void SwigDirectorMethodsetShadowsEnabled(bool enabled)
	{
		try
		{
			setShadowsEnabled(enabled);
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

	private bool SwigDirectorMethodshadowsEnabled()
	{
		return shadowsEnabled();
	}

	private void SwigDirectorMethodsetDiagnosticBackgroundEnabled(bool enabled)
	{
		try
		{
			setDiagnosticBackgroundEnabled(enabled);
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

	private bool SwigDirectorMethoddiagnosticBackgroundEnabled()
	{
		return diagnosticBackgroundEnabled();
	}

	private void SwigDirectorMethodsetModelScaleFactor(double scaleFactor)
	{
		try
		{
			setModelScaleFactor(scaleFactor);
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

	private double SwigDirectorMethodmodelScaleFactor()
	{
		return modelScaleFactor();
	}
}
