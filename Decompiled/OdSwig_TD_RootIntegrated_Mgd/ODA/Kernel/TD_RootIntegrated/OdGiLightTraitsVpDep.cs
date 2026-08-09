using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLightTraitsVpDep : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiLightTraitsVpDep_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiLightTraitsVpDep_1();

	public delegate void SwigDelegateOdGiLightTraitsVpDep_2(IntPtr pSource);

	public delegate uint SwigDelegateOdGiLightTraitsVpDep_3();

	public delegate IntPtr SwigDelegateOdGiLightTraitsVpDep_4();

	public delegate void SwigDelegateOdGiLightTraitsVpDep_5(bool on);

	public delegate bool SwigDelegateOdGiLightTraitsVpDep_6();

	public delegate void SwigDelegateOdGiLightTraitsVpDep_7(double dim);

	public delegate double SwigDelegateOdGiLightTraitsVpDep_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiLightTraitsVpDep_0 swigDelegate0;

	private SwigDelegateOdGiLightTraitsVpDep_1 swigDelegate1;

	private SwigDelegateOdGiLightTraitsVpDep_2 swigDelegate2;

	private SwigDelegateOdGiLightTraitsVpDep_3 swigDelegate3;

	private SwigDelegateOdGiLightTraitsVpDep_4 swigDelegate4;

	private SwigDelegateOdGiLightTraitsVpDep_5 swigDelegate5;

	private SwigDelegateOdGiLightTraitsVpDep_6 swigDelegate6;

	private SwigDelegateOdGiLightTraitsVpDep_7 swigDelegate7;

	private SwigDelegateOdGiLightTraitsVpDep_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLightTraitsVpDep(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLightTraitsVpDep obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLightTraitsVpDep(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiLightTraitsVpDep cast(OdRxObject pObj)
	{
		OdGiLightTraitsVpDep rXObject = Helpers.GetRXObject<OdGiLightTraitsVpDep>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_isASwigExplicitOdGiLightTraitsVpDep(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_queryXSwigExplicitOdGiLightTraitsVpDep(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiLightTraitsVpDep createObject()
	{
		OdGiLightTraitsVpDep rXObject = Helpers.GetRXObject<OdGiLightTraitsVpDep>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint viewportId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_viewportId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub viewportObjectId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_viewportObjectId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOn(bool on)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_setOn(swigCPtr, on);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isOn()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_isOn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimming(double dim)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_setDimming(swigCPtr, dim);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimming()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_dimming(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiLightTraitsVpDep()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLightTraitsVpDep(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiLightTraitsVpDep) != GetType();
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
		if (SwigDerivedClassHasMethod("viewportId", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodviewportId;
		}
		if (SwigDerivedClassHasMethod("viewportObjectId", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodviewportObjectId;
		}
		if (SwigDerivedClassHasMethod("setOn", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetOn;
		}
		if (SwigDerivedClassHasMethod("isOn", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisOn;
		}
		if (SwigDerivedClassHasMethod("setDimming", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetDimming;
		}
		if (SwigDerivedClassHasMethod("dimming", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddimming;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLightTraitsVpDep_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiLightTraitsVpDep));
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

	private uint SwigDirectorMethodviewportId()
	{
		return viewportId();
	}

	private IntPtr SwigDirectorMethodviewportObjectId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(viewportObjectId()).Handle;
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

	private void SwigDirectorMethodsetOn(bool on)
	{
		try
		{
			setOn(on);
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

	private bool SwigDirectorMethodisOn()
	{
		return isOn();
	}

	private void SwigDirectorMethodsetDimming(double dim)
	{
		try
		{
			setDimming(dim);
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

	private double SwigDirectorMethoddimming()
	{
		return dimming();
	}
}
