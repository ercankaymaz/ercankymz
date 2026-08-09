using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFdFieldEvaluatorLoader : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFdFieldEvaluatorLoader_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFdFieldEvaluatorLoader_1();

	public delegate void SwigDelegateOdFdFieldEvaluatorLoader_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdFdFieldEvaluatorLoader_3([MarshalAs(UnmanagedType.LPWStr)] string pszEvalId);

	public delegate IntPtr SwigDelegateOdFdFieldEvaluatorLoader_4(IntPtr pField, IntPtr pszEvalId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFdFieldEvaluatorLoader_0 swigDelegate0;

	private SwigDelegateOdFdFieldEvaluatorLoader_1 swigDelegate1;

	private SwigDelegateOdFdFieldEvaluatorLoader_2 swigDelegate2;

	private SwigDelegateOdFdFieldEvaluatorLoader_3 swigDelegate3;

	private SwigDelegateOdFdFieldEvaluatorLoader_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbField),
		typeof(string).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFdFieldEvaluatorLoader(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFdFieldEvaluatorLoader obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFdFieldEvaluatorLoader(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFdFieldEvaluatorLoader cast(OdRxObject pObj)
	{
		OdFdFieldEvaluatorLoader rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluatorLoader>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_isASwigExplicitOdFdFieldEvaluatorLoader(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_queryXSwigExplicitOdFdFieldEvaluatorLoader(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFdFieldEvaluatorLoader createObject()
	{
		OdFdFieldEvaluatorLoader rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluatorLoader>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdFdFieldEvaluator getEvaluator(string pszEvalId)
	{
		OdFdFieldEvaluator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_getEvaluator(swigCPtr, pszEvalId), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdFdFieldEvaluator findEvaluator(OdDbField pField, ref string pszEvalId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pszEvalId);
		IntPtr intPtr = jarg;
		try
		{
			OdFdFieldEvaluator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_findEvaluator(swigCPtr, OdDbField.getCPtr(pField), ref jarg), bOwn: false, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pszEvalId = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFdFieldEvaluatorLoader()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFdFieldEvaluatorLoader(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFdFieldEvaluatorLoader) != GetType();
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
		if (SwigDerivedClassHasMethod("getEvaluator", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetEvaluator;
		}
		if (SwigDerivedClassHasMethod("findEvaluator", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodfindEvaluator;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEvaluatorLoader_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFdFieldEvaluatorLoader));
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

	private IntPtr SwigDirectorMethodgetEvaluator([MarshalAs(UnmanagedType.LPWStr)] string pszEvalId)
	{
		return OdFdFieldEvaluator.getCPtr(getEvaluator(pszEvalId)).Handle;
	}

	private IntPtr SwigDirectorMethodfindEvaluator(IntPtr pField, IntPtr pszEvalId)
	{
		OdSwigDirectorHelper.director_UnpackData(pszEvalId, out var pOriginalObject, out var pFunction);
		string pszEvalId2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = pszEvalId2;
		try
		{
			return OdFdFieldEvaluator.getCPtr(findEvaluator(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(pField, bOwn: false, bTryAddToTransaction: false), ref pszEvalId2)).Handle;
		}
		finally
		{
			if (pszEvalId2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(pszEvalId2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(pszEvalId);
		}
	}
}
