using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdLispEngineReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdEdLispEngineReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdLispEngineReactor_1();

	public delegate void SwigDelegateOdEdLispEngineReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdEdLispEngineReactor_3(IntPtr pCmdCtx, [MarshalAs(UnmanagedType.LPWStr)] string firstLine);

	public delegate void SwigDelegateOdEdLispEngineReactor_4(IntPtr pCmdCtx);

	public delegate void SwigDelegateOdEdLispEngineReactor_5(IntPtr pCmdCtx);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdLispEngineReactor_0 swigDelegate0;

	private SwigDelegateOdEdLispEngineReactor_1 swigDelegate1;

	private SwigDelegateOdEdLispEngineReactor_2 swigDelegate2;

	private SwigDelegateOdEdLispEngineReactor_3 swigDelegate3;

	private SwigDelegateOdEdLispEngineReactor_4 swigDelegate4;

	private SwigDelegateOdEdLispEngineReactor_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdEdCommandContext),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdEdCommandContext) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdEdCommandContext) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdLispEngineReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdLispEngineReactor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdLispEngineReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdEdLispEngineReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdLispEngineReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdEdLispEngineReactor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdEdLispEngineReactor cast(OdRxObject pObj)
	{
		OdEdLispEngineReactor rXObject = Helpers.GetRXObject<OdEdLispEngineReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_isASwigExplicitOdEdLispEngineReactor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_queryXSwigExplicitOdEdLispEngineReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdEdLispEngineReactor createObject()
	{
		OdEdLispEngineReactor rXObject = Helpers.GetRXObject<OdEdLispEngineReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void lispWillStart(OdEdCommandContext pCmdCtx, string firstLine)
	{
		if (SwigDerivedClassHasMethod("lispWillStart", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_lispWillStartSwigExplicitOdEdLispEngineReactor(swigCPtr, OdEdCommandContext.getCPtr(pCmdCtx), firstLine);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_lispWillStart(swigCPtr, OdEdCommandContext.getCPtr(pCmdCtx), firstLine);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void lispEnded(OdEdCommandContext pCmdCtx)
	{
		if (SwigDerivedClassHasMethod("lispEnded", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_lispEndedSwigExplicitOdEdLispEngineReactor(swigCPtr, OdEdCommandContext.getCPtr(pCmdCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_lispEnded(swigCPtr, OdEdCommandContext.getCPtr(pCmdCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void lispCancelled(OdEdCommandContext pCmdCtx)
	{
		if (SwigDerivedClassHasMethod("lispCancelled", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_lispCancelledSwigExplicitOdEdLispEngineReactor(swigCPtr, OdEdCommandContext.getCPtr(pCmdCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_lispCancelled(swigCPtr, OdEdCommandContext.getCPtr(pCmdCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("lispWillStart", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodlispWillStart;
		}
		if (SwigDerivedClassHasMethod("lispEnded", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodlispEnded;
		}
		if (SwigDerivedClassHasMethod("lispCancelled", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodlispCancelled;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdEdLispEngineReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdLispEngineReactor));
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

	private void SwigDirectorMethodlispWillStart(IntPtr pCmdCtx, [MarshalAs(UnmanagedType.LPWStr)] string firstLine)
	{
		try
		{
			lispWillStart(Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false), firstLine);
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

	private void SwigDirectorMethodlispEnded(IntPtr pCmdCtx)
	{
		try
		{
			lispEnded(Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodlispCancelled(IntPtr pCmdCtx)
	{
		try
		{
			lispCancelled(Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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
