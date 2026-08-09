using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFdFieldEvaluator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFdFieldEvaluator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFdFieldEvaluator_1();

	public delegate void SwigDelegateOdFdFieldEvaluator_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdFdFieldEvaluator_3();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdFdFieldEvaluator_4(IntPtr pField);

	public delegate int SwigDelegateOdFdFieldEvaluator_5(IntPtr pField);

	public delegate int SwigDelegateOdFdFieldEvaluator_6(IntPtr pField, IntPtr pDb, IntPtr pResult);

	public delegate int SwigDelegateOdFdFieldEvaluator_7(IntPtr pField, int nContext, IntPtr pDb, IntPtr pResult);

	public delegate int SwigDelegateOdFdFieldEvaluator_8(IntPtr pField, IntPtr pszValue);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFdFieldEvaluator_0 swigDelegate0;

	private SwigDelegateOdFdFieldEvaluator_1 swigDelegate1;

	private SwigDelegateOdFdFieldEvaluator_2 swigDelegate2;

	private SwigDelegateOdFdFieldEvaluator_3 swigDelegate3;

	private SwigDelegateOdFdFieldEvaluator_4 swigDelegate4;

	private SwigDelegateOdFdFieldEvaluator_5 swigDelegate5;

	private SwigDelegateOdFdFieldEvaluator_6 swigDelegate6;

	private SwigDelegateOdFdFieldEvaluator_7 swigDelegate7;

	private SwigDelegateOdFdFieldEvaluator_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbField) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbField) };

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdDbField),
		typeof(OdDbDatabase),
		typeof(OdFdFieldResult)
	};

	private static Type[] swigMethodTypes7 = new Type[4]
	{
		typeof(OdDbField),
		typeof(int),
		typeof(OdDbDatabase),
		typeof(OdFdFieldResult)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbField),
		typeof(string).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFdFieldEvaluator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFdFieldEvaluator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFdFieldEvaluator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFdFieldEvaluator cast(OdRxObject pObj)
	{
		OdFdFieldEvaluator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_isASwigExplicitOdFdFieldEvaluator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_queryXSwigExplicitOdFdFieldEvaluator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFdFieldEvaluator createObject()
	{
		OdFdFieldEvaluator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string evaluatorId()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_evaluatorId__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string evaluatorId(OdDbField pField)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_evaluatorId__SWIG_1(swigCPtr, OdDbField.getCPtr(pField));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult initialize(OdDbField pField)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_initialize(swigCPtr, OdDbField.getCPtr(pField));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult compile(OdDbField pField, OdDbDatabase pDb, OdFdFieldResult pResult)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_compile(swigCPtr, OdDbField.getCPtr(pField), OdDbDatabase.getCPtr(pDb), OdFdFieldResult.getCPtr(pResult));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult evaluate(OdDbField pField, int nContext, OdDbDatabase pDb, OdFdFieldResult pResult)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_evaluate(swigCPtr, OdDbField.getCPtr(pField), nContext, OdDbDatabase.getCPtr(pDb), OdFdFieldResult.getCPtr(pResult));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult format(OdDbField pField, ref string pszValue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pszValue);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_format(swigCPtr, OdDbField.getCPtr(pField), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pszValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFdFieldEvaluator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFdFieldEvaluator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFdFieldEvaluator) != GetType();
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
		if (SwigDerivedClassHasMethod("evaluatorId", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodevaluatorId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("evaluatorId", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodevaluatorId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("initialize", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodinitialize;
		}
		if (SwigDerivedClassHasMethod("compile", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcompile;
		}
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodevaluate;
		}
		if (SwigDerivedClassHasMethod("format", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodformat;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFdFieldEvaluator));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodevaluatorId__SWIG_0()
	{
		return evaluatorId();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodevaluatorId__SWIG_1(IntPtr pField)
	{
		return evaluatorId(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(pField, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodinitialize(IntPtr pField)
	{
		return (int)initialize(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(pField, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodcompile(IntPtr pField, IntPtr pDb, IntPtr pResult)
	{
		return (int)compile(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(pField, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldResult>(pResult, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodevaluate(IntPtr pField, int nContext, IntPtr pDb, IntPtr pResult)
	{
		return (int)evaluate(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(pField, bOwn: false, bTryAddToTransaction: false), nContext, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldResult>(pResult, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodformat(IntPtr pField, IntPtr pszValue)
	{
		OdSwigDirectorHelper.director_UnpackData(pszValue, out var pOriginalObject, out var pFunction);
		string pszValue2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = pszValue2;
		try
		{
			return (int)format(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(pField, bOwn: false, bTryAddToTransaction: false), ref pszValue2);
		}
		finally
		{
			if (pszValue2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(pszValue2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pszValue);
		}
	}
}
