using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFdFieldEngine : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFdFieldEngine_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFdFieldEngine_1();

	public delegate void SwigDelegateOdFdFieldEngine_2(IntPtr pSource);

	public delegate void SwigDelegateOdFdFieldEngine_3(IntPtr pLoader);

	public delegate void SwigDelegateOdFdFieldEngine_4(IntPtr pLoader);

	public delegate int SwigDelegateOdFdFieldEngine_5();

	public delegate IntPtr SwigDelegateOdFdFieldEngine_6(int inputIndex);

	public delegate IntPtr SwigDelegateOdFdFieldEngine_7([MarshalAs(UnmanagedType.LPWStr)] string pszEvalId);

	public delegate IntPtr SwigDelegateOdFdFieldEngine_8(IntPtr pField, IntPtr pszEvalId);

	public delegate void SwigDelegateOdFdFieldEngine_9(IntPtr pReactor);

	public delegate void SwigDelegateOdFdFieldEngine_10(IntPtr pReactor);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFdFieldEngine_0 swigDelegate0;

	private SwigDelegateOdFdFieldEngine_1 swigDelegate1;

	private SwigDelegateOdFdFieldEngine_2 swigDelegate2;

	private SwigDelegateOdFdFieldEngine_3 swigDelegate3;

	private SwigDelegateOdFdFieldEngine_4 swigDelegate4;

	private SwigDelegateOdFdFieldEngine_5 swigDelegate5;

	private SwigDelegateOdFdFieldEngine_6 swigDelegate6;

	private SwigDelegateOdFdFieldEngine_7 swigDelegate7;

	private SwigDelegateOdFdFieldEngine_8 swigDelegate8;

	private SwigDelegateOdFdFieldEngine_9 swigDelegate9;

	private SwigDelegateOdFdFieldEngine_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdFdFieldEvaluatorLoader) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdFdFieldEvaluatorLoader) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbField),
		typeof(string).MakeByRefType()
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdFdFieldReactor) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdFdFieldReactor) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFdFieldEngine(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFdFieldEngine obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFdFieldEngine(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFdFieldEngine cast(OdRxObject pObj)
	{
		OdFdFieldEngine rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEngine>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_isASwigExplicitOdFdFieldEngine(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_queryXSwigExplicitOdFdFieldEngine(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFdFieldEngine createObject()
	{
		OdFdFieldEngine rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEngine>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void registerEvaluatorLoader(OdFdFieldEvaluatorLoader pLoader)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_registerEvaluatorLoader(swigCPtr, OdFdFieldEvaluatorLoader.getCPtr(pLoader));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unregisterEvaluatorLoader(OdFdFieldEvaluatorLoader pLoader)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_unregisterEvaluatorLoader(swigCPtr, OdFdFieldEvaluatorLoader.getCPtr(pLoader));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int evaluatorLoaderCount()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_evaluatorLoaderCount(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdFdFieldEvaluatorLoader getEvaluatorLoader(int inputIndex)
	{
		OdFdFieldEvaluatorLoader rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluatorLoader>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_getEvaluatorLoader(swigCPtr, inputIndex), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdFdFieldEvaluator getEvaluator(string pszEvalId)
	{
		OdFdFieldEvaluator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_getEvaluator(swigCPtr, pszEvalId), bOwn: false, bTryAddToTransaction: true);
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
			OdFdFieldEvaluator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_findEvaluator(swigCPtr, OdDbField.getCPtr(pField), ref jarg), bOwn: false, bTryAddToTransaction: true);
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

	public virtual void addFieldReactor(OdFdFieldReactor pReactor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_addFieldReactor(swigCPtr, OdFdFieldReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeFieldReactor(OdFdFieldReactor pReactor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_removeFieldReactor(swigCPtr, OdFdFieldReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFdFieldEngine()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFdFieldEngine(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFdFieldEngine) != GetType();
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
		if (SwigDerivedClassHasMethod("registerEvaluatorLoader", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodregisterEvaluatorLoader;
		}
		if (SwigDerivedClassHasMethod("unregisterEvaluatorLoader", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodunregisterEvaluatorLoader;
		}
		if (SwigDerivedClassHasMethod("evaluatorLoaderCount", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodevaluatorLoaderCount;
		}
		if (SwigDerivedClassHasMethod("getEvaluatorLoader", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetEvaluatorLoader;
		}
		if (SwigDerivedClassHasMethod("getEvaluator", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetEvaluator;
		}
		if (SwigDerivedClassHasMethod("findEvaluator", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodfindEvaluator;
		}
		if (SwigDerivedClassHasMethod("addFieldReactor", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodaddFieldReactor;
		}
		if (SwigDerivedClassHasMethod("removeFieldReactor", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodremoveFieldReactor;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEngine_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFdFieldEngine));
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

	private void SwigDirectorMethodregisterEvaluatorLoader(IntPtr pLoader)
	{
		try
		{
			registerEvaluatorLoader(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluatorLoader>(pLoader, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodunregisterEvaluatorLoader(IntPtr pLoader)
	{
		try
		{
			unregisterEvaluatorLoader(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEvaluatorLoader>(pLoader, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodevaluatorLoaderCount()
	{
		return evaluatorLoaderCount();
	}

	private IntPtr SwigDirectorMethodgetEvaluatorLoader(int inputIndex)
	{
		return OdFdFieldEvaluatorLoader.getCPtr(getEvaluatorLoader(inputIndex)).Handle;
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

	private void SwigDirectorMethodaddFieldReactor(IntPtr pReactor)
	{
		try
		{
			addFieldReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveFieldReactor(IntPtr pReactor)
	{
		try
		{
			removeFieldReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
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
