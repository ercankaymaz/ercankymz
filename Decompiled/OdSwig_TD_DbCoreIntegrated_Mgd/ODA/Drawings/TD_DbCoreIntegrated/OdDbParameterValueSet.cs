using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbParameterValueSet : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbParameterValueSet_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbParameterValueSet_1();

	public delegate void SwigDelegateOdDbParameterValueSet_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbParameterValueSet_3(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbParameterValueSet_4(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbParameterValueSet_0 swigDelegate0;

	private SwigDelegateOdDbParameterValueSet_1 swigDelegate1;

	private SwigDelegateOdDbParameterValueSet_2 swigDelegate2;

	private SwigDelegateOdDbParameterValueSet_3 swigDelegate3;

	private SwigDelegateOdDbParameterValueSet_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbEvalVariant) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbEvalVariant) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbParameterValueSet(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbParameterValueSet obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbParameterValueSet(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbParameterValueSet cast(OdRxObject pObj)
	{
		OdDbParameterValueSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParameterValueSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_isASwigExplicitOdDbParameterValueSet(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_queryXSwigExplicitOdDbParameterValueSet(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbParameterValueSet()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbParameterValueSet(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbParameterValueSet) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool valueIsLegal(OdDbEvalVariant arg0)
	{
		bool result = (SwigDerivedClassHasMethod("valueIsLegal", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_valueIsLegalSwigExplicitOdDbParameterValueSet(swigCPtr, OdDbEvalVariant.getCPtr(arg0)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_valueIsLegal(swigCPtr, OdDbEvalVariant.getCPtr(arg0)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbEvalVariant closestLegalValue(OdDbEvalVariant arg0)
	{
		OdDbEvalVariant result = new OdDbEvalVariant(SwigDerivedClassHasMethod("closestLegalValue", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_closestLegalValueSwigExplicitOdDbParameterValueSet(swigCPtr, OdDbEvalVariant.getCPtr(arg0)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_closestLegalValue(swigCPtr, OdDbEvalVariant.getCPtr(arg0)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbParameterValueSet createObject(OdDbBlockParamValueSet arg0, double arg1)
	{
		OdDbParameterValueSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParameterValueSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_createObject__SWIG_0(OdDbBlockParamValueSet.getCPtr(arg0), arg1), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbParameterValueSet createObject()
	{
		OdDbParameterValueSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParameterValueSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_createObject__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("valueIsLegal", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodvalueIsLegal;
		}
		if (SwigDerivedClassHasMethod("closestLegalValue", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodclosestLegalValue;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterValueSet_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbParameterValueSet));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodvalueIsLegal(IntPtr arg0)
	{
		return valueIsLegal(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodclosestLegalValue(IntPtr arg0)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbEvalVariant.getCPtr(closestLegalValue(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(arg0, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
