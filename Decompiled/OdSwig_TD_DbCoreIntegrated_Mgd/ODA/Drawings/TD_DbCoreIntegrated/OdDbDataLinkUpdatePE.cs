using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDataLinkUpdatePE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbDataLinkUpdatePE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDataLinkUpdatePE_1();

	public delegate void SwigDelegateOdDbDataLinkUpdatePE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbDataLinkUpdatePE_3(IntPtr pDataLink, int nDir, int nOption);

	public delegate IntPtr SwigDelegateOdDbDataLinkUpdatePE_4(IntPtr sBasePath, int nOptionm, IntPtr path);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDataLinkUpdatePE_0 swigDelegate0;

	private SwigDelegateOdDbDataLinkUpdatePE_1 swigDelegate1;

	private SwigDelegateOdDbDataLinkUpdatePE_2 swigDelegate2;

	private SwigDelegateOdDbDataLinkUpdatePE_3 swigDelegate3;

	private SwigDelegateOdDbDataLinkUpdatePE_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdDbDataLink),
		typeof(OdDb_UpdateDirection),
		typeof(OdDb_UpdateOption)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(string).MakeByRefType(),
		typeof(OdDb_PathOption),
		typeof(string).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDataLinkUpdatePE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDataLinkUpdatePE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDataLinkUpdatePE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdError dataLinkUpdate(OdDbDataLink pDataLink, OdDb_UpdateDirection nDir, OdDb_UpdateOption nOption)
	{
		OdError result = new OdError(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_dataLinkUpdate(swigCPtr, OdDbDataLink.getCPtr(pDataLink), (int)nDir, (int)nOption), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdError repathSourceFiles(ref string sBasePath, OdDb_PathOption nOptionm, ref string path)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sBasePath);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = Marshal.StringToCoTaskMemUni(path);
		IntPtr intPtr2 = jarg2;
		try
		{
			OdError result = new OdError(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_repathSourceFiles(swigCPtr, ref jarg, (int)nOptionm, ref jarg2), cMemoryOwn: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sBasePath = Marshal.PtrToStringUni(jarg);
			}
			if (jarg2 != intPtr2)
			{
				path = Marshal.PtrToStringUni(jarg2);
			}
		}
	}

	public new static OdDbDataLinkUpdatePE cast(OdRxObject pObj)
	{
		OdDbDataLinkUpdatePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataLinkUpdatePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_isASwigExplicitOdDbDataLinkUpdatePE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_queryXSwigExplicitOdDbDataLinkUpdatePE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDataLinkUpdatePE createObject()
	{
		OdDbDataLinkUpdatePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataLinkUpdatePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDataLinkUpdatePE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDataLinkUpdatePE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbDataLinkUpdatePE) != GetType();
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
		if (SwigDerivedClassHasMethod("dataLinkUpdate", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddataLinkUpdate;
		}
		if (SwigDerivedClassHasMethod("repathSourceFiles", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodrepathSourceFiles;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataLinkUpdatePE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDataLinkUpdatePE));
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

	private IntPtr SwigDirectorMethoddataLinkUpdate(IntPtr pDataLink, int nDir, int nOption)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdError.getCPtr(dataLinkUpdate(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataLink>(pDataLink, bOwn: false, bTryAddToTransaction: false), (OdDb_UpdateDirection)nDir, (OdDb_UpdateOption)nOption)).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodrepathSourceFiles(IntPtr sBasePath, int nOptionm, IntPtr path)
	{
		OdSwigDirectorHelper.director_UnpackData(sBasePath, out var pOriginalObject, out var pFunction);
		string tmpStr_sBasePath = Marshal.PtrToStringUni(pOriginalObject);
		string text = tmpStr_sBasePath;
		OdSwigDirectorHelper.director_UnpackData(path, out var pOriginalObject2, out var pFunction2);
		string tmpStr_path = Marshal.PtrToStringUni(pOriginalObject2);
		string text2 = tmpStr_path;
		try
		{
			return ((Func<IntPtr>)delegate
			{
				try
				{
					return OdError.getCPtr(repathSourceFiles(ref tmpStr_sBasePath, (OdDb_PathOption)nOptionm, ref tmpStr_path)).Handle;
				}
				catch (OdEdEmptyInput odEdEmptyInput)
				{
					TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
					throw odEdEmptyInput;
				}
				catch (OdEdOtherInput odEdOtherInput)
				{
					TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
					throw odEdOtherInput;
				}
				catch (OdError odError)
				{
					TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
					throw odError;
				}
				catch (Exception ex)
				{
					TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
					throw ex;
				}
			})();
		}
		finally
		{
			if (tmpStr_sBasePath != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(tmpStr_sBasePath);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sBasePath);
			if (tmpStr_path != text2)
			{
				IntPtr intPtr2 = Marshal.StringToCoTaskMemUni(tmpStr_path);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction2, intPtr2);
				Marshal.FreeCoTaskMem(intPtr2);
			}
			OdSwigDirectorHelper.director_freeData(path);
		}
	}
}
