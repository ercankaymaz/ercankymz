using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdCommandStackReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdEdCommandStackReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdCommandStackReactor_1();

	public delegate void SwigDelegateOdEdCommandStackReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdEdCommandStackReactor_3(IntPtr pCommand);

	public delegate void SwigDelegateOdEdCommandStackReactor_4(IntPtr pCommand);

	public delegate void SwigDelegateOdEdCommandStackReactor_5(IntPtr pCommand, IntPtr pCmdCtx);

	public delegate void SwigDelegateOdEdCommandStackReactor_6(IntPtr pCommand, IntPtr pCmdCtx);

	public delegate void SwigDelegateOdEdCommandStackReactor_7(IntPtr pCommand, IntPtr pCmdCtx);

	public delegate void SwigDelegateOdEdCommandStackReactor_8(IntPtr pCommand, IntPtr pCmdCtx);

	public delegate IntPtr SwigDelegateOdEdCommandStackReactor_9([MarshalAs(UnmanagedType.LPWStr)] string commandName, IntPtr pCmdCtx);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdCommandStackReactor_0 swigDelegate0;

	private SwigDelegateOdEdCommandStackReactor_1 swigDelegate1;

	private SwigDelegateOdEdCommandStackReactor_2 swigDelegate2;

	private SwigDelegateOdEdCommandStackReactor_3 swigDelegate3;

	private SwigDelegateOdEdCommandStackReactor_4 swigDelegate4;

	private SwigDelegateOdEdCommandStackReactor_5 swigDelegate5;

	private SwigDelegateOdEdCommandStackReactor_6 swigDelegate6;

	private SwigDelegateOdEdCommandStackReactor_7 swigDelegate7;

	private SwigDelegateOdEdCommandStackReactor_8 swigDelegate8;

	private SwigDelegateOdEdCommandStackReactor_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdEdCommand) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdEdCommand) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdEdCommand),
		typeof(OdEdCommandContext)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdEdCommand),
		typeof(OdEdCommandContext)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdEdCommand),
		typeof(OdEdCommandContext)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdEdCommand),
		typeof(OdEdCommandContext)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(string),
		typeof(OdEdCommandContext)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdCommandStackReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdCommandStackReactor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdCommandStackReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdEdCommandStackReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdCommandStackReactor(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdEdCommandStackReactor cast(OdRxObject pObj)
	{
		OdEdCommandStackReactor rXObject = Helpers.GetRXObject<OdEdCommandStackReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_isASwigExplicitOdEdCommandStackReactor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_queryXSwigExplicitOdEdCommandStackReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void commandAdded(OdEdCommand pCommand)
	{
		if (SwigDerivedClassHasMethod("commandAdded", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandAddedSwigExplicitOdEdCommandStackReactor(swigCPtr, OdEdCommand.getCPtr(pCommand));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandAdded(swigCPtr, OdEdCommand.getCPtr(pCommand));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void commandWillBeRemoved(OdEdCommand pCommand)
	{
		if (SwigDerivedClassHasMethod("commandWillBeRemoved", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandWillBeRemovedSwigExplicitOdEdCommandStackReactor(swigCPtr, OdEdCommand.getCPtr(pCommand));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandWillBeRemoved(swigCPtr, OdEdCommand.getCPtr(pCommand));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void commandWillStart(OdEdCommand pCommand, OdEdCommandContext pCmdCtx)
	{
		if (SwigDerivedClassHasMethod("commandWillStart", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandWillStartSwigExplicitOdEdCommandStackReactor(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandWillStart(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void commandEnded(OdEdCommand pCommand, OdEdCommandContext pCmdCtx)
	{
		if (SwigDerivedClassHasMethod("commandEnded", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandEndedSwigExplicitOdEdCommandStackReactor(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandEnded(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void commandCancelled(OdEdCommand pCommand, OdEdCommandContext pCmdCtx)
	{
		if (SwigDerivedClassHasMethod("commandCancelled", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandCancelledSwigExplicitOdEdCommandStackReactor(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandCancelled(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void commandFailed(OdEdCommand pCommand, OdEdCommandContext pCmdCtx)
	{
		if (SwigDerivedClassHasMethod("commandFailed", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandFailedSwigExplicitOdEdCommandStackReactor(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_commandFailed(swigCPtr, OdEdCommand.getCPtr(pCommand), OdEdCommandContext.getCPtr(pCmdCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdEdCommand unknownCommand(string commandName, OdEdCommandContext pCmdCtx)
	{
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(SwigDerivedClassHasMethod("unknownCommand", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_unknownCommandSwigExplicitOdEdCommandStackReactor(swigCPtr, commandName, OdEdCommandContext.getCPtr(pCmdCtx)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_unknownCommand(swigCPtr, commandName, OdEdCommandContext.getCPtr(pCmdCtx)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdEdCommandStackReactor createObject()
	{
		OdEdCommandStackReactor rXObject = Helpers.GetRXObject<OdEdCommandStackReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("commandAdded", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcommandAdded;
		}
		if (SwigDerivedClassHasMethod("commandWillBeRemoved", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcommandWillBeRemoved;
		}
		if (SwigDerivedClassHasMethod("commandWillStart", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcommandWillStart;
		}
		if (SwigDerivedClassHasMethod("commandEnded", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcommandEnded;
		}
		if (SwigDerivedClassHasMethod("commandCancelled", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcommandCancelled;
		}
		if (SwigDerivedClassHasMethod("commandFailed", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcommandFailed;
		}
		if (SwigDerivedClassHasMethod("unknownCommand", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodunknownCommand;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStackReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdCommandStackReactor));
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

	private void SwigDirectorMethodcommandAdded(IntPtr pCommand)
	{
		try
		{
			commandAdded(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodcommandWillBeRemoved(IntPtr pCommand)
	{
		try
		{
			commandWillBeRemoved(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodcommandWillStart(IntPtr pCommand, IntPtr pCmdCtx)
	{
		try
		{
			commandWillStart(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodcommandEnded(IntPtr pCommand, IntPtr pCmdCtx)
	{
		try
		{
			commandEnded(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodcommandCancelled(IntPtr pCommand, IntPtr pCmdCtx)
	{
		try
		{
			commandCancelled(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodcommandFailed(IntPtr pCommand, IntPtr pCmdCtx)
	{
		try
		{
			commandFailed(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodunknownCommand([MarshalAs(UnmanagedType.LPWStr)] string commandName, IntPtr pCmdCtx)
	{
		return OdEdCommand.getCPtr(unknownCommand(commandName, Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false))).Handle;
	}
}
