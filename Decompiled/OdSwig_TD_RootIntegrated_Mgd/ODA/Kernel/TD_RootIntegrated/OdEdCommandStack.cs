using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdCommandStack : OdRxObject
{
	public delegate IntPtr SwigDelegateOdEdCommandStack_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdCommandStack_1();

	public delegate void SwigDelegateOdEdCommandStack_2(IntPtr pSource);

	public delegate void SwigDelegateOdEdCommandStack_3(IntPtr pReactor);

	public delegate void SwigDelegateOdEdCommandStack_4(IntPtr pReactor);

	public delegate IntPtr SwigDelegateOdEdCommandStack_5();

	public delegate void SwigDelegateOdEdCommandStack_6(IntPtr pCommand);

	public delegate IntPtr SwigDelegateOdEdCommandStack_7([MarshalAs(UnmanagedType.LPWStr)] string sGroupName, [MarshalAs(UnmanagedType.LPWStr)] string sGlobalName, [MarshalAs(UnmanagedType.LPWStr)] string sLocalName, uint commandFlags, IntPtr pFunction, IntPtr pModule);

	public delegate IntPtr SwigDelegateOdEdCommandStack_8([MarshalAs(UnmanagedType.LPWStr)] string sGroupName, [MarshalAs(UnmanagedType.LPWStr)] string sGlobalName, [MarshalAs(UnmanagedType.LPWStr)] string sLocalName, uint commandFlags, IntPtr pFunction);

	public delegate IntPtr SwigDelegateOdEdCommandStack_9();

	public delegate IntPtr SwigDelegateOdEdCommandStack_10([MarshalAs(UnmanagedType.LPWStr)] string groupName);

	public delegate IntPtr SwigDelegateOdEdCommandStack_11();

	public delegate IntPtr SwigDelegateOdEdCommandStack_12([MarshalAs(UnmanagedType.LPWStr)] string commandName, int lookupFlags, [MarshalAs(UnmanagedType.LPWStr)] string groupName);

	public delegate IntPtr SwigDelegateOdEdCommandStack_13([MarshalAs(UnmanagedType.LPWStr)] string commandName, int lookupFlags);

	public delegate IntPtr SwigDelegateOdEdCommandStack_14([MarshalAs(UnmanagedType.LPWStr)] string commandName);

	public delegate void SwigDelegateOdEdCommandStack_15(IntPtr pCmd, IntPtr pCmdCtx);

	public delegate void SwigDelegateOdEdCommandStack_16([MarshalAs(UnmanagedType.LPWStr)] string cmdName, IntPtr pCmdCtx, int lookupFlags, [MarshalAs(UnmanagedType.LPWStr)] string groupName);

	public delegate void SwigDelegateOdEdCommandStack_17([MarshalAs(UnmanagedType.LPWStr)] string cmdName, IntPtr pCmdCtx, int lookupFlags);

	public delegate void SwigDelegateOdEdCommandStack_18([MarshalAs(UnmanagedType.LPWStr)] string cmdName, IntPtr pCmdCtx);

	public delegate void SwigDelegateOdEdCommandStack_19([MarshalAs(UnmanagedType.LPWStr)] string groupName, [MarshalAs(UnmanagedType.LPWStr)] string globalName);

	public delegate void SwigDelegateOdEdCommandStack_20(IntPtr pCommand);

	public delegate void SwigDelegateOdEdCommandStack_21([MarshalAs(UnmanagedType.LPWStr)] string groupName);

	public delegate int SwigDelegateOdEdCommandStack_22([MarshalAs(UnmanagedType.LPWStr)] string cmdGroupName);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdCommandStack_0 swigDelegate0;

	private SwigDelegateOdEdCommandStack_1 swigDelegate1;

	private SwigDelegateOdEdCommandStack_2 swigDelegate2;

	private SwigDelegateOdEdCommandStack_3 swigDelegate3;

	private SwigDelegateOdEdCommandStack_4 swigDelegate4;

	private SwigDelegateOdEdCommandStack_5 swigDelegate5;

	private SwigDelegateOdEdCommandStack_6 swigDelegate6;

	private SwigDelegateOdEdCommandStack_7 swigDelegate7;

	private SwigDelegateOdEdCommandStack_8 swigDelegate8;

	private SwigDelegateOdEdCommandStack_9 swigDelegate9;

	private SwigDelegateOdEdCommandStack_10 swigDelegate10;

	private SwigDelegateOdEdCommandStack_11 swigDelegate11;

	private SwigDelegateOdEdCommandStack_12 swigDelegate12;

	private SwigDelegateOdEdCommandStack_13 swigDelegate13;

	private SwigDelegateOdEdCommandStack_14 swigDelegate14;

	private SwigDelegateOdEdCommandStack_15 swigDelegate15;

	private SwigDelegateOdEdCommandStack_16 swigDelegate16;

	private SwigDelegateOdEdCommandStack_17 swigDelegate17;

	private SwigDelegateOdEdCommandStack_18 swigDelegate18;

	private SwigDelegateOdEdCommandStack_19 swigDelegate19;

	private SwigDelegateOdEdCommandStack_20 swigDelegate20;

	private SwigDelegateOdEdCommandStack_21 swigDelegate21;

	private SwigDelegateOdEdCommandStack_22 swigDelegate22;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdEdCommandStackReactor) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdEdCommandStackReactor) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdEdCommand) };

	private static Type[] swigMethodTypes7 = new Type[6]
	{
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(uint),
		typeof(TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate),
		typeof(OdRxModule)
	};

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(uint),
		typeof(TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate)
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdEdCommand),
		typeof(OdEdCommandContext)
	};

	private static Type[] swigMethodTypes16 = new Type[4]
	{
		typeof(string),
		typeof(OdEdCommandContext),
		typeof(int),
		typeof(string)
	};

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(string),
		typeof(OdEdCommandContext),
		typeof(int)
	};

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(string),
		typeof(OdEdCommandContext)
	};

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdEdCommand) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdCommandStack(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdCommandStack obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdCommandStack(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdEdCommandStack cast(OdRxObject pObj)
	{
		OdEdCommandStack rXObject = Helpers.GetRXObject<OdEdCommandStack>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_isASwigExplicitOdEdCommandStack(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_queryXSwigExplicitOdEdCommandStack(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdEdCommandStack createObject()
	{
		OdEdCommandStack rXObject = Helpers.GetRXObject<OdEdCommandStack>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void addReactor(OdEdCommandStackReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_addReactor(swigCPtr, OdEdCommandStackReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeReactor(OdEdCommandStackReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_removeReactor(swigCPtr, OdEdCommandStackReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdEdCommandStackReactorArray getCommandStackReactors()
	{
		OdEdCommandStackReactorArray result = new OdEdCommandStackReactorArray(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_getCommandStackReactors(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addCommand(OdEdCommand pCommand)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_addCommand__SWIG_0(swigCPtr, OdEdCommand.getCPtr(pCommand));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdEdCommand addCommand(string sGroupName, string sGlobalName, string sLocalName, uint commandFlags, TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate pFunction, OdRxModule pModule)
	{
		TD_RootIntegrated_Globals.OdEdCommandFunctionDelegateNative odEdCommandFunctionDelegateNative = null;
		if (pFunction != null)
		{
			odEdCommandFunctionDelegateNative = delegate(IntPtr pCmdCtx)
			{
				pFunction(OdMarshalHelper.PtrToObject<OdEdCommandContext>(pCmdCtx));
			};
		}
		IntPtr jarg = ((pFunction == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odEdCommandFunctionDelegateNative));
		DelegateHolder.Add(odEdCommandFunctionDelegateNative);
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(SwigDerivedClassHasMethod("addCommand", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_addCommandSwigExplicitOdEdCommandStack__SWIG_1(swigCPtr, sGroupName, sGlobalName, sLocalName, commandFlags, jarg, OdRxModule.getCPtr(pModule)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_addCommand__SWIG_1(swigCPtr, sGroupName, sGlobalName, sLocalName, commandFlags, jarg, OdRxModule.getCPtr(pModule)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdCommand addCommand(string sGroupName, string sGlobalName, string sLocalName, uint commandFlags, TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate pFunction)
	{
		TD_RootIntegrated_Globals.OdEdCommandFunctionDelegateNative odEdCommandFunctionDelegateNative = null;
		if (pFunction != null)
		{
			odEdCommandFunctionDelegateNative = delegate(IntPtr pCmdCtx)
			{
				pFunction(OdMarshalHelper.PtrToObject<OdEdCommandContext>(pCmdCtx));
			};
		}
		IntPtr jarg = ((pFunction == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odEdCommandFunctionDelegateNative));
		DelegateHolder.Add(odEdCommandFunctionDelegateNative);
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(SwigDerivedClassHasMethod("addCommand", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_addCommandSwigExplicitOdEdCommandStack__SWIG_2(swigCPtr, sGroupName, sGlobalName, sLocalName, commandFlags, jarg) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_addCommand__SWIG_2(swigCPtr, sGroupName, sGlobalName, sLocalName, commandFlags, jarg), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxIterator newIterator()
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_newIterator__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxIterator newIterator(string groupName)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_newIterator__SWIG_1(swigCPtr, groupName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxIterator newGroupIterator()
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_newGroupIterator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdCommand lookupCmd(string commandName, int lookupFlags, string groupName)
	{
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_lookupCmd__SWIG_0(swigCPtr, commandName, lookupFlags, groupName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdCommand lookupCmd(string commandName, int lookupFlags)
	{
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_lookupCmd__SWIG_1(swigCPtr, commandName, lookupFlags), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdCommand lookupCmd(string commandName)
	{
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_lookupCmd__SWIG_2(swigCPtr, commandName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void executeCommand(OdEdCommand pCmd, OdEdCommandContext pCmdCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_executeCommand__SWIG_0(swigCPtr, OdEdCommand.getCPtr(pCmd), OdEdCommandContext.getCPtr(pCmdCtx));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void executeCommand(string cmdName, OdEdCommandContext pCmdCtx, int lookupFlags, string groupName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_executeCommand__SWIG_1(swigCPtr, cmdName, OdEdCommandContext.getCPtr(pCmdCtx), lookupFlags, groupName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void executeCommand(string cmdName, OdEdCommandContext pCmdCtx, int lookupFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_executeCommand__SWIG_2(swigCPtr, cmdName, OdEdCommandContext.getCPtr(pCmdCtx), lookupFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void executeCommand(string cmdName, OdEdCommandContext pCmdCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_executeCommand__SWIG_3(swigCPtr, cmdName, OdEdCommandContext.getCPtr(pCmdCtx));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeCmd(string groupName, string globalName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_removeCmd__SWIG_0(swigCPtr, groupName, globalName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeCmd(OdEdCommand pCommand)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_removeCmd__SWIG_1(swigCPtr, OdEdCommand.getCPtr(pCommand));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeGroup(string groupName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_removeGroup(swigCPtr, groupName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult popGroupToTop(string cmdGroupName)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_popGroupToTop(swigCPtr, cmdGroupName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdEdCommandStack()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdCommandStack(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdEdCommandStack) != GetType();
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
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddReactor;
		}
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodremoveReactor;
		}
		if (SwigDerivedClassHasMethod("getCommandStackReactors", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetCommandStackReactors;
		}
		if (SwigDerivedClassHasMethod("addCommand", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodaddCommand__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("addCommand", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodaddCommand__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("addCommand", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodaddCommand__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("newIterator", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodnewIterator__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("newIterator", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodnewIterator__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("newGroupIterator", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodnewGroupIterator;
		}
		if (SwigDerivedClassHasMethod("lookupCmd", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodlookupCmd__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("lookupCmd", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlookupCmd__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("lookupCmd", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodlookupCmd__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("executeCommand", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodexecuteCommand__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("executeCommand", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodexecuteCommand__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("executeCommand", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodexecuteCommand__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("executeCommand", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodexecuteCommand__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("removeCmd", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodremoveCmd__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("removeCmd", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodremoveCmd__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("removeGroup", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodremoveGroup;
		}
		if (SwigDerivedClassHasMethod("popGroupToTop", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodpopGroupToTop;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommandStack_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdCommandStack));
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

	private void SwigDirectorMethodaddReactor(IntPtr pReactor)
	{
		try
		{
			addReactor(Helpers.GetRXObject<OdEdCommandStackReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveReactor(IntPtr pReactor)
	{
		try
		{
			removeReactor(Helpers.GetRXObject<OdEdCommandStackReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgetCommandStackReactors()
	{
		return OdEdCommandStackReactorArray.getCPtr(getCommandStackReactors()).Handle;
	}

	private void SwigDirectorMethodaddCommand__SWIG_0(IntPtr pCommand)
	{
		try
		{
			addCommand(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodaddCommand__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string sGroupName, [MarshalAs(UnmanagedType.LPWStr)] string sGlobalName, [MarshalAs(UnmanagedType.LPWStr)] string sLocalName, uint commandFlags, IntPtr pFunction, IntPtr pModule)
	{
		return OdEdCommand.getCPtr(addCommand(sGroupName, sGlobalName, sLocalName, commandFlags, ((Func<TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate>)delegate
		{
			IntPtr nativeCallback = pFunction;
			TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = delegate(OdEdCommandContext pCmdCtx)
				{
					(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.OdEdCommandFunctionDelegateNative)) as TD_RootIntegrated_Globals.OdEdCommandFunctionDelegateNative)(OdMarshalHelper.ObjectToPtr<OdEdCommandContext>(pCmdCtx));
				};
			}
			return result;
		})(), Helpers.GetRXObject<OdRxModule>(pModule, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodaddCommand__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string sGroupName, [MarshalAs(UnmanagedType.LPWStr)] string sGlobalName, [MarshalAs(UnmanagedType.LPWStr)] string sLocalName, uint commandFlags, IntPtr pFunction)
	{
		return OdEdCommand.getCPtr(addCommand(sGroupName, sGlobalName, sLocalName, commandFlags, ((Func<TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate>)delegate
		{
			IntPtr nativeCallback = pFunction;
			TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = delegate(OdEdCommandContext pCmdCtx)
				{
					(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.OdEdCommandFunctionDelegateNative)) as TD_RootIntegrated_Globals.OdEdCommandFunctionDelegateNative)(OdMarshalHelper.ObjectToPtr<OdEdCommandContext>(pCmdCtx));
				};
			}
			return result;
		})())).Handle;
	}

	private IntPtr SwigDirectorMethodnewIterator__SWIG_0()
	{
		return OdRxIterator.getCPtr(newIterator()).Handle;
	}

	private IntPtr SwigDirectorMethodnewIterator__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string groupName)
	{
		return OdRxIterator.getCPtr(newIterator(groupName)).Handle;
	}

	private IntPtr SwigDirectorMethodnewGroupIterator()
	{
		return OdRxIterator.getCPtr(newGroupIterator()).Handle;
	}

	private IntPtr SwigDirectorMethodlookupCmd__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string commandName, int lookupFlags, [MarshalAs(UnmanagedType.LPWStr)] string groupName)
	{
		return OdEdCommand.getCPtr(lookupCmd(commandName, lookupFlags, groupName)).Handle;
	}

	private IntPtr SwigDirectorMethodlookupCmd__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string commandName, int lookupFlags)
	{
		return OdEdCommand.getCPtr(lookupCmd(commandName, lookupFlags)).Handle;
	}

	private IntPtr SwigDirectorMethodlookupCmd__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string commandName)
	{
		return OdEdCommand.getCPtr(lookupCmd(commandName)).Handle;
	}

	private void SwigDirectorMethodexecuteCommand__SWIG_0(IntPtr pCmd, IntPtr pCmdCtx)
	{
		try
		{
			executeCommand(Helpers.GetRXObject<OdEdCommand>(pCmd, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexecuteCommand__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string cmdName, IntPtr pCmdCtx, int lookupFlags, [MarshalAs(UnmanagedType.LPWStr)] string groupName)
	{
		try
		{
			executeCommand(cmdName, Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false), lookupFlags, groupName);
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

	private void SwigDirectorMethodexecuteCommand__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string cmdName, IntPtr pCmdCtx, int lookupFlags)
	{
		try
		{
			executeCommand(cmdName, Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false), lookupFlags);
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

	private void SwigDirectorMethodexecuteCommand__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string cmdName, IntPtr pCmdCtx)
	{
		try
		{
			executeCommand(cmdName, Helpers.GetRXObject<OdEdCommandContext>(pCmdCtx, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveCmd__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string groupName, [MarshalAs(UnmanagedType.LPWStr)] string globalName)
	{
		try
		{
			removeCmd(groupName, globalName);
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

	private void SwigDirectorMethodremoveCmd__SWIG_1(IntPtr pCommand)
	{
		try
		{
			removeCmd(Helpers.GetRXObject<OdEdCommand>(pCommand, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveGroup([MarshalAs(UnmanagedType.LPWStr)] string groupName)
	{
		try
		{
			removeGroup(groupName);
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

	private int SwigDirectorMethodpopGroupToTop([MarshalAs(UnmanagedType.LPWStr)] string cmdGroupName)
	{
		return (int)popGroupToTop(cmdGroupName);
	}
}
