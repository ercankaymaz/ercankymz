using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdCommand : OdRxObject
{
	public delegate IntPtr SwigDelegateOdEdCommand_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdCommand_1();

	public delegate void SwigDelegateOdEdCommand_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdCommand_3();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdCommand_4();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdCommand_5();

	public delegate void SwigDelegateOdEdCommand_6(IntPtr pCommandContext);

	public delegate IntPtr SwigDelegateOdEdCommand_7();

	public delegate void SwigDelegateOdEdCommand_8(bool undefIt);

	public delegate int SwigDelegateOdEdCommand_9();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdCommand_0 swigDelegate0;

	private SwigDelegateOdEdCommand_1 swigDelegate1;

	private SwigDelegateOdEdCommand_2 swigDelegate2;

	private SwigDelegateOdEdCommand_3 swigDelegate3;

	private SwigDelegateOdEdCommand_4 swigDelegate4;

	private SwigDelegateOdEdCommand_5 swigDelegate5;

	private SwigDelegateOdEdCommand_6 swigDelegate6;

	private SwigDelegateOdEdCommand_7 swigDelegate7;

	private SwigDelegateOdEdCommand_8 swigDelegate8;

	private SwigDelegateOdEdCommand_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdEdCommandContext) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes9 = new Type[0];

	public const int kModal = 0;

	public const int kTransparent = 1;

	public const int kUsePickset = 2;

	public const int kRedraw = 4;

	public const int kNoPerspective = 8;

	public const int kNoMultiple = 16;

	public const int kNoTilemode = 32;

	public const int kNoPaperspace = 64;

	public const int kPlotOnly = 128;

	public const int kNoOEM = 256;

	public const int kUndefined = 512;

	public const int kInProgress = 1024;

	public const int kDefun = 2048;

	public const int kNoNewStack = 65536;

	public const int kNoInternalLock = 131072;

	public const int kDocReadLock = 524288;

	public const int kDocExclusiveLock = 1048576;

	public const int kSession = 2097152;

	public const int kInterruptible = 4194304;

	public const int kNoHistory = 8388608;

	public const int kNoUndoMarker = 16777216;

	public const int kNoBedit = 33554432;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdCommand(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdCommand obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdCommand(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdEdCommand()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdCommand(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdEdCommand cast(OdRxObject pObj)
	{
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_isASwigExplicitOdEdCommand(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_queryXSwigExplicitOdEdCommand(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdEdCommand createObject()
	{
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdEdCommand createObject(string sGroupName, string sGlobalName, string sLocalName, uint commandFlags, TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate pFunction, OdRxModule pModule)
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
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_createObject__SWIG_1(sGroupName, sGlobalName, sLocalName, commandFlags, jarg, OdRxModule.getCPtr(pModule)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdEdCommand createObject(string sGroupName, string sGlobalName, string sLocalName, uint commandFlags, TD_RootIntegrated_Globals.OdEdCommandFunctionDelegate pFunction)
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
		OdEdCommand rXObject = Helpers.GetRXObject<OdEdCommand>(TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_createObject__SWIG_2(sGroupName, sGlobalName, sLocalName, commandFlags, jarg), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string groupName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_groupName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string globalName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_globalName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string localName()
	{
		string result = (SwigDerivedClassHasMethod("localName", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_localNameSwigExplicitOdEdCommand(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_localName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void execute(OdEdCommandContext pCommandContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_execute(swigCPtr, OdEdCommandContext.getCPtr(pCommandContext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxModule module()
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(SwigDerivedClassHasMethod("module", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_moduleSwigExplicitOdEdCommand(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_module(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void undefine(bool undefIt)
	{
		if (SwigDerivedClassHasMethod("undefine", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_undefineSwigExplicitOdEdCommand(swigCPtr, undefIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_undefine(swigCPtr, undefIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int flags()
	{
		int result = (SwigDerivedClassHasMethod("flags", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_flagsSwigExplicitOdEdCommand(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_flags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("groupName", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgroupName;
		}
		if (SwigDerivedClassHasMethod("globalName", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodglobalName;
		}
		if (SwigDerivedClassHasMethod("localName", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodlocalName;
		}
		if (SwigDerivedClassHasMethod("execute", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodexecute;
		}
		if (SwigDerivedClassHasMethod("module", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmodule;
		}
		if (SwigDerivedClassHasMethod("undefine", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodundefine;
		}
		if (SwigDerivedClassHasMethod("flags", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodflags;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdEdCommand_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdCommand));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgroupName()
	{
		return groupName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodglobalName()
	{
		return globalName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodlocalName()
	{
		return localName();
	}

	private void SwigDirectorMethodexecute(IntPtr pCommandContext)
	{
		try
		{
			execute(Helpers.GetRXObject<OdEdCommandContext>(pCommandContext, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodmodule()
	{
		return OdRxModule.getCPtr(module()).Handle;
	}

	private void SwigDirectorMethodundefine(bool undefIt)
	{
		try
		{
			undefine(undefIt);
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

	private int SwigDirectorMethodflags()
	{
		return flags();
	}
}
