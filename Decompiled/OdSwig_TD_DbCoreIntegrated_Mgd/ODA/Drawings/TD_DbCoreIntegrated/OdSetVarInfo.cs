using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdSetVarInfo : OdRxObject
{
	public delegate IntPtr SwigDelegateOdSetVarInfo_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdSetVarInfo_1();

	public delegate void SwigDelegateOdSetVarInfo_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdSetVarInfo_0 swigDelegate0;

	private SwigDelegateOdSetVarInfo_1 swigDelegate1;

	private SwigDelegateOdSetVarInfo_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	public TD_DbCoreIntegrated_Globals.FormatFnDelegate m_formatFn
	{
		get
		{
			IntPtr nativeCallback = TD_DbCoreIntegrated_GlobalsPINVOKE.OdSetVarInfo_m_formatFn_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			TD_DbCoreIntegrated_Globals.FormatFnDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = (OdDbDatabase pDbCmdCtx, OdResBuf pRbValue) => OdString2StringConvHelper.OdStringToString((Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.FormatFnDelegateNative)) as TD_DbCoreIntegrated_Globals.FormatFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbDatabase>(pDbCmdCtx), OdMarshalHelper.ObjectToPtr<OdResBuf>(pRbValue)));
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_Globals.FormatFnDelegateNative formatFnDelegateNative = null;
			if (value != null)
			{
				formatFnDelegateNative = (IntPtr pDbCmdCtx, IntPtr pRbValue) => OdString2StringConvHelper.StringToOdString(value(OdMarshalHelper.PtrToObject<OdDbDatabase>(pDbCmdCtx), OdMarshalHelper.PtrToObject<OdResBuf>(pRbValue)));
			}
			IntPtr jarg = ((formatFnDelegateNative == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(formatFnDelegateNative));
			DelegateHolder.Add(formatFnDelegateNative);
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdSetVarInfo_m_formatFn_set(swigCPtr, jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_DbCoreIntegrated_Globals.PromptFnDelegate m_promptFn
	{
		get
		{
			IntPtr nativeCallback = TD_DbCoreIntegrated_GlobalsPINVOKE.OdSetVarInfo_m_promptFn_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			TD_DbCoreIntegrated_Globals.PromptFnDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = delegate(OdDbCommandContext pDbCmdCtx, string varName, OdResBuf pVal)
				{
					(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.PromptFnDelegateNative)) as TD_DbCoreIntegrated_Globals.PromptFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbCommandContext>(pDbCmdCtx), OdString2StringConvHelper.StringToOdString(varName), OdMarshalHelper.ObjectToPtr<OdResBuf>(pVal));
				};
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_Globals.PromptFnDelegateNative promptFnDelegateNative = null;
			if (value != null)
			{
				promptFnDelegateNative = delegate(IntPtr pDbCmdCtx, IntPtr varName, IntPtr pVal)
				{
					value(OdMarshalHelper.PtrToObject<OdDbCommandContext>(pDbCmdCtx), OdString2StringConvHelper.OdStringToString(varName), OdMarshalHelper.PtrToObject<OdResBuf>(pVal));
				};
			}
			IntPtr jarg = ((promptFnDelegateNative == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(promptFnDelegateNative));
			DelegateHolder.Add(promptFnDelegateNative);
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdSetVarInfo_m_promptFn_set(swigCPtr, jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSetVarInfo(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdSetVarInfo_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSetVarInfo obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdSetVarInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdSetVarInfo_getRealClassName(ptr);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdSetVarInfo_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSetVarInfo));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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
}
