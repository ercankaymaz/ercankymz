using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiAuxiliaryData : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiAuxiliaryData_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiAuxiliaryData_1();

	public delegate void SwigDelegateOdGiAuxiliaryData_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiAuxiliaryData_3();

	public delegate void SwigDelegateOdGiAuxiliaryData_4(IntPtr pLevelOverrides);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiAuxiliaryData_0 swigDelegate0;

	private SwigDelegateOdGiAuxiliaryData_1 swigDelegate1;

	private SwigDelegateOdGiAuxiliaryData_2 swigDelegate2;

	private SwigDelegateOdGiAuxiliaryData_3 swigDelegate3;

	private SwigDelegateOdGiAuxiliaryData_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiLayerOverrides) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiAuxiliaryData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiAuxiliaryData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiAuxiliaryData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiAuxiliaryData cast(OdRxObject pObj)
	{
		OdGiAuxiliaryData rXObject = Helpers.GetRXObject<OdGiAuxiliaryData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_isASwigExplicitOdGiAuxiliaryData(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_queryXSwigExplicitOdGiAuxiliaryData(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiAuxiliaryData createObject()
	{
		OdGiAuxiliaryData rXObject = Helpers.GetRXObject<OdGiAuxiliaryData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiLayerOverrides getLevelOverrides()
	{
		OdGiLayerOverrides rXObject = Helpers.GetRXObject<OdGiLayerOverrides>(TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_getLevelOverrides(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setLevelOverrides(OdGiLayerOverrides pLevelOverrides)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_setLevelOverrides(swigCPtr, OdGiLayerOverrides.getCPtr(pLevelOverrides));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiAuxiliaryData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiAuxiliaryData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiAuxiliaryData) != GetType();
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
		if (SwigDerivedClassHasMethod("getLevelOverrides", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetLevelOverrides;
		}
		if (SwigDerivedClassHasMethod("setLevelOverrides", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetLevelOverrides;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiAuxiliaryData_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiAuxiliaryData));
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

	private IntPtr SwigDirectorMethodgetLevelOverrides()
	{
		return OdGiLayerOverrides.getCPtr(getLevelOverrides()).Handle;
	}

	private void SwigDirectorMethodsetLevelOverrides(IntPtr pLevelOverrides)
	{
		try
		{
			setLevelOverrides(Helpers.GetRXObject<OdGiLayerOverrides>(pLevelOverrides, bOwn: true, bTryAddToTransaction: false));
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
