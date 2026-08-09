using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiHLRemover : OdGiConveyorNode
{
	public delegate IntPtr SwigDelegateOdGiHLRemover_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiHLRemover_1();

	public delegate void SwigDelegateOdGiHLRemover_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiHLRemover_3();

	public delegate IntPtr SwigDelegateOdGiHLRemover_4();

	public delegate void SwigDelegateOdGiHLRemover_5(IntPtr deviations);

	public delegate void SwigDelegateOdGiHLRemover_6(IntPtr pDeviation);

	public delegate void SwigDelegateOdGiHLRemover_7(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiHLRemover_8();

	public delegate void SwigDelegateOdGiHLRemover_9(bool enabled);

	public delegate bool SwigDelegateOdGiHLRemover_10();

	public delegate void SwigDelegateOdGiHLRemover_11(bool bDoIt);

	public delegate bool SwigDelegateOdGiHLRemover_12();

	public delegate IntPtr SwigDelegateOdGiHLRemover_13(uint pNumItems);

	public delegate IntPtr SwigDelegateOdGiHLRemover_14();

	public delegate void SwigDelegateOdGiHLRemover_15();

	public delegate void SwigDelegateOdGiHLRemover_16(bool bDoIt);

	public delegate bool SwigDelegateOdGiHLRemover_17();

	public delegate IntPtr SwigDelegateOdGiHLRemover_18();

	public delegate void SwigDelegateOdGiHLRemover_19(IntPtr path);

	public delegate void SwigDelegateOdGiHLRemover_20(IntPtr pCtx);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiHLRemover_0 swigDelegate0;

	private SwigDelegateOdGiHLRemover_1 swigDelegate1;

	private SwigDelegateOdGiHLRemover_2 swigDelegate2;

	private SwigDelegateOdGiHLRemover_3 swigDelegate3;

	private SwigDelegateOdGiHLRemover_4 swigDelegate4;

	private SwigDelegateOdGiHLRemover_5 swigDelegate5;

	private SwigDelegateOdGiHLRemover_6 swigDelegate6;

	private SwigDelegateOdGiHLRemover_7 swigDelegate7;

	private SwigDelegateOdGiHLRemover_8 swigDelegate8;

	private SwigDelegateOdGiHLRemover_9 swigDelegate9;

	private SwigDelegateOdGiHLRemover_10 swigDelegate10;

	private SwigDelegateOdGiHLRemover_11 swigDelegate11;

	private SwigDelegateOdGiHLRemover_12 swigDelegate12;

	private SwigDelegateOdGiHLRemover_13 swigDelegate13;

	private SwigDelegateOdGiHLRemover_14 swigDelegate14;

	private SwigDelegateOdGiHLRemover_15 swigDelegate15;

	private SwigDelegateOdGiHLRemover_16 swigDelegate16;

	private SwigDelegateOdGiHLRemover_17 swigDelegate17;

	private SwigDelegateOdGiHLRemover_18 swigDelegate18;

	private SwigDelegateOdGiHLRemover_19 swigDelegate19;

	private SwigDelegateOdGiHLRemover_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGiDeviation) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(uint).MakeByRefType() };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbStubPtrArray) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdGiHLRContext) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiHLRemover(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiHLRemover obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiHLRemover(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiHLRemover cast(OdRxObject pObj)
	{
		OdGiHLRemover rXObject = Helpers.GetRXObject<OdGiHLRemover>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_isASwigExplicitOdGiHLRemover(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_queryXSwigExplicitOdGiHLRemover(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiHLRemover createObject()
	{
		OdGiHLRemover rXObject = Helpers.GetRXObject<OdGiHLRemover>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void process()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_process(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void enable(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_enable(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool enabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_enabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void invertZ(bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_invertZ(swigCPtr, bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool zInverted()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_zInverted(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiHlrResults hlrResults(out uint pNumItems)
	{
		OdGiHlrResults rXObject = Helpers.GetRXObject<OdGiHlrResults>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_hlrResults__SWIG_0(swigCPtr, out pNumItems), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiHlrResults hlrResults()
	{
		OdGiHlrResults rXObject = Helpers.GetRXObject<OdGiHlrResults>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_hlrResults__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void freeResults()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_freeResults(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void keepHidden(bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_keepHidden(swigCPtr, bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hiddenKept()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_hiddenKept(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStubPtrArray currentDrawablePath()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_currentDrawablePath(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCurrentDrawablePath(OdDbStubPtrArray path)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_setCurrentDrawablePath(swigCPtr, OdDbStubPtrArray.getCPtr(path));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHLRemoverContext(OdGiHLRContext pCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_setHLRemoverContext(swigCPtr, OdGiHLRContext.getCPtr(pCtx));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiHLRemover()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiHLRemover(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiHLRemover) != GetType();
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
		if (SwigDerivedClassHasMethod("input", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinput;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("process", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodprocess;
		}
		if (SwigDerivedClassHasMethod("enable", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodenable;
		}
		if (SwigDerivedClassHasMethod("enabled", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodenabled;
		}
		if (SwigDerivedClassHasMethod("invertZ", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodinvertZ;
		}
		if (SwigDerivedClassHasMethod("zInverted", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodzInverted;
		}
		if (SwigDerivedClassHasMethod("hlrResults", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodhlrResults__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("hlrResults", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodhlrResults__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("freeResults", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodfreeResults;
		}
		if (SwigDerivedClassHasMethod("keepHidden", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodkeepHidden;
		}
		if (SwigDerivedClassHasMethod("hiddenKept", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodhiddenKept;
		}
		if (SwigDerivedClassHasMethod("currentDrawablePath", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodcurrentDrawablePath;
		}
		if (SwigDerivedClassHasMethod("setCurrentDrawablePath", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetCurrentDrawablePath;
		}
		if (SwigDerivedClassHasMethod("setHLRemoverContext", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetHLRemoverContext;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRemover_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiHLRemover));
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

	private IntPtr SwigDirectorMethodinput()
	{
		return input().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetDeviation__SWIG_0(IntPtr deviations)
	{
		try
		{
			setDeviation(new OdDoubleArray(deviations, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetDeviation__SWIG_1(IntPtr pDeviation)
	{
		try
		{
			setDeviation(new OdGiDeviation_Internal(pDeviation, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDrawContext(IntPtr pDrawCtx)
	{
		try
		{
			setDrawContext(new OdGiConveyorContext_Internal(pDrawCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethodprocess()
	{
		try
		{
			process();
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

	private void SwigDirectorMethodenable(bool enabled)
	{
		try
		{
			enable(enabled);
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

	private bool SwigDirectorMethodenabled()
	{
		return enabled();
	}

	private void SwigDirectorMethodinvertZ(bool bDoIt)
	{
		try
		{
			invertZ(bDoIt);
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

	private bool SwigDirectorMethodzInverted()
	{
		return zInverted();
	}

	private IntPtr SwigDirectorMethodhlrResults__SWIG_0(uint pNumItems)
	{
		return OdGiHlrResults.getCPtr(hlrResults(out pNumItems)).Handle;
	}

	private IntPtr SwigDirectorMethodhlrResults__SWIG_1()
	{
		return OdGiHlrResults.getCPtr(hlrResults()).Handle;
	}

	private void SwigDirectorMethodfreeResults()
	{
		try
		{
			freeResults();
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

	private void SwigDirectorMethodkeepHidden(bool bDoIt)
	{
		try
		{
			keepHidden(bDoIt);
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

	private bool SwigDirectorMethodhiddenKept()
	{
		return hiddenKept();
	}

	private IntPtr SwigDirectorMethodcurrentDrawablePath()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStubPtrArray.getCPtr(currentDrawablePath()).Handle;
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

	private void SwigDirectorMethodsetCurrentDrawablePath(IntPtr path)
	{
		try
		{
			setCurrentDrawablePath(new OdDbStubPtrArray(path, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetHLRemoverContext(IntPtr pCtx)
	{
		try
		{
			setHLRemoverContext((pCtx == IntPtr.Zero) ? null : new OdGiHLRContext(pCtx, cMemoryOwn: false));
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
