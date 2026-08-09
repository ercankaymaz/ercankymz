using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFdFieldResult : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFdFieldResult_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFdFieldResult_1();

	public delegate void SwigDelegateOdFdFieldResult_2(IntPtr pSource);

	public delegate void SwigDelegateOdFdFieldResult_3(IntPtr pValue);

	public delegate void SwigDelegateOdFdFieldResult_4(int errorStatus, int errorCode, [MarshalAs(UnmanagedType.LPWStr)] string errorMessage);

	public delegate void SwigDelegateOdFdFieldResult_5(int errorStatus, int errorCode);

	public delegate void SwigDelegateOdFdFieldResult_6(int errorStatus);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFdFieldResult_0 swigDelegate0;

	private SwigDelegateOdFdFieldResult_1 swigDelegate1;

	private SwigDelegateOdFdFieldResult_2 swigDelegate2;

	private SwigDelegateOdFdFieldResult_3 swigDelegate3;

	private SwigDelegateOdFdFieldResult_4 swigDelegate4;

	private SwigDelegateOdFdFieldResult_5 swigDelegate5;

	private SwigDelegateOdFdFieldResult_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdFieldValue) };

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdDbField_EvalStatus),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbField_EvalStatus),
		typeof(int)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbField_EvalStatus) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFdFieldResult(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFdFieldResult obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFdFieldResult(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFdFieldResult cast(OdRxObject pObj)
	{
		OdFdFieldResult rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldResult>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_isASwigExplicitOdFdFieldResult(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_queryXSwigExplicitOdFdFieldResult(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFdFieldResult createObject()
	{
		OdFdFieldResult rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldResult>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFdFieldResult()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFdFieldResult(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFdFieldResult) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void setFieldValue(OdFieldValue pValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_setFieldValue(swigCPtr, OdFieldValue.getCPtr(pValue));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEvaluationStatus(OdDbField_EvalStatus errorStatus, int errorCode, string errorMessage)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_setEvaluationStatus__SWIG_0(swigCPtr, (int)errorStatus, errorCode, errorMessage);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEvaluationStatus(OdDbField_EvalStatus errorStatus, int errorCode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_setEvaluationStatus__SWIG_1(swigCPtr, (int)errorStatus, errorCode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEvaluationStatus(OdDbField_EvalStatus errorStatus)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_setEvaluationStatus__SWIG_2(swigCPtr, (int)errorStatus);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("setFieldValue", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetFieldValue;
		}
		if (SwigDerivedClassHasMethod("setEvaluationStatus", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetEvaluationStatus__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setEvaluationStatus", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetEvaluationStatus__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setEvaluationStatus", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetEvaluationStatus__SWIG_2;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldResult_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFdFieldResult));
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

	private void SwigDirectorMethodsetFieldValue(IntPtr pValue)
	{
		try
		{
			setFieldValue(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFieldValue>(pValue, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetEvaluationStatus__SWIG_0(int errorStatus, int errorCode, [MarshalAs(UnmanagedType.LPWStr)] string errorMessage)
	{
		try
		{
			setEvaluationStatus((OdDbField_EvalStatus)errorStatus, errorCode, errorMessage);
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

	private void SwigDirectorMethodsetEvaluationStatus__SWIG_1(int errorStatus, int errorCode)
	{
		try
		{
			setEvaluationStatus((OdDbField_EvalStatus)errorStatus, errorCode);
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

	private void SwigDirectorMethodsetEvaluationStatus__SWIG_2(int errorStatus)
	{
		try
		{
			setEvaluationStatus((OdDbField_EvalStatus)errorStatus);
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
}
