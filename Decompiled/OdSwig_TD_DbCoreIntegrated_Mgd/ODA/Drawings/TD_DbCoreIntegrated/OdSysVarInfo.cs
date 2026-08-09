using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdSysVarInfo : OdRxObject
{
	public delegate IntPtr SwigDelegateOdSysVarInfo_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdSysVarInfo_1();

	public delegate void SwigDelegateOdSysVarInfo_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdSysVarInfo_0 swigDelegate0;

	private SwigDelegateOdSysVarInfo_1 swigDelegate1;

	private SwigDelegateOdSysVarInfo_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	public const int kToAcadType = 0;

	public const int kToDDType = 1;

	public TD_DbCoreIntegrated_Globals.GetFnDelegate m_getFn
	{
		get
		{
			IntPtr nativeCallback = TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_m_getFn_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			TD_DbCoreIntegrated_Globals.GetFnDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = (OdDbDatabase pDb) => OdMarshalHelper.PtrToObject<OdResBuf>((Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.GetFnDelegateNative)) as TD_DbCoreIntegrated_Globals.GetFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbDatabase>(pDb)));
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_Globals.GetFnDelegateNative getFnDelegateNative = null;
			if (value != null)
			{
				getFnDelegateNative = (IntPtr pDb) => OdMarshalHelper.ObjectToPtr<OdResBuf>(value(OdMarshalHelper.PtrToObject<OdDbDatabase>(pDb)));
			}
			IntPtr jarg = ((getFnDelegateNative == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(getFnDelegateNative));
			DelegateHolder.Add(getFnDelegateNative);
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_m_getFn_set(swigCPtr, jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_DbCoreIntegrated_Globals.SetFnDelegate m_setFn
	{
		get
		{
			IntPtr nativeCallback = TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_m_setFn_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			TD_DbCoreIntegrated_Globals.SetFnDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = delegate(OdDbDatabase pDb, OdResBuf pRbValue)
				{
					(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.SetFnDelegateNative)) as TD_DbCoreIntegrated_Globals.SetFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbDatabase>(pDb), OdMarshalHelper.ObjectToPtr<OdResBuf>(pRbValue));
				};
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_Globals.SetFnDelegateNative setFnDelegateNative = null;
			if (value != null)
			{
				setFnDelegateNative = delegate(IntPtr pDb, IntPtr pRbValue)
				{
					value(OdMarshalHelper.PtrToObject<OdDbDatabase>(pDb), OdMarshalHelper.PtrToObject<OdResBuf>(pRbValue));
				};
			}
			IntPtr jarg = ((setFnDelegateNative == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(setFnDelegateNative));
			DelegateHolder.Add(setFnDelegateNative);
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_m_setFn_set(swigCPtr, jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_DbCoreIntegrated_Globals.MapTypeFnDelegate m_mapTypeFn
	{
		get
		{
			IntPtr nativeCallback = TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_m_mapTypeFn_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			TD_DbCoreIntegrated_Globals.MapTypeFnDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = delegate(OdDbDatabase pDb, OdResBuf pVal, int opt)
				{
					(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.MapTypeFnDelegateNative)) as TD_DbCoreIntegrated_Globals.MapTypeFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbDatabase>(pDb), OdMarshalHelper.ObjectToPtr<OdResBuf>(pVal), opt);
				};
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_Globals.MapTypeFnDelegateNative mapTypeFnDelegateNative = null;
			if (value != null)
			{
				mapTypeFnDelegateNative = delegate(IntPtr pDb, IntPtr pVal, int opt)
				{
					value(OdMarshalHelper.PtrToObject<OdDbDatabase>(pDb), OdMarshalHelper.PtrToObject<OdResBuf>(pVal), opt);
				};
			}
			IntPtr jarg = ((mapTypeFnDelegateNative == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mapTypeFnDelegateNative));
			DelegateHolder.Add(mapTypeFnDelegateNative);
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_m_mapTypeFn_set(swigCPtr, jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSysVarInfo(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSysVarInfo obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdSysVarInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_getRealClassName(ptr);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdSysVarInfo_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSysVarInfo));
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
