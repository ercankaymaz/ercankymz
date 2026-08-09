using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialTextureLoadPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiMaterialTextureLoadPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMaterialTextureLoadPE_1();

	public delegate void SwigDelegateOdGiMaterialTextureLoadPE_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiMaterialTextureLoadPE_3(IntPtr fileName, IntPtr pDb);

	public delegate void SwigDelegateOdGiMaterialTextureLoadPE_4([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pDb);

	public delegate void SwigDelegateOdGiMaterialTextureLoadPE_5([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pDb);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMaterialTextureLoadPE_0 swigDelegate0;

	private SwigDelegateOdGiMaterialTextureLoadPE_1 swigDelegate1;

	private SwigDelegateOdGiMaterialTextureLoadPE_2 swigDelegate2;

	private SwigDelegateOdGiMaterialTextureLoadPE_3 swigDelegate3;

	private SwigDelegateOdGiMaterialTextureLoadPE_4 swigDelegate4;

	private SwigDelegateOdGiMaterialTextureLoadPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string).MakeByRefType(),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(OdRxObject)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(string),
		typeof(OdRxObject)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialTextureLoadPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialTextureLoadPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialTextureLoadPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialTextureLoadPE cast(OdRxObject pObj)
	{
		OdGiMaterialTextureLoadPE rXObject = Helpers.GetRXObject<OdGiMaterialTextureLoadPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_isASwigExplicitOdGiMaterialTextureLoadPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_queryXSwigExplicitOdGiMaterialTextureLoadPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMaterialTextureLoadPE createObject()
	{
		OdGiMaterialTextureLoadPE rXObject = Helpers.GetRXObject<OdGiMaterialTextureLoadPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiMaterialTextureLoadPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialTextureLoadPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMaterialTextureLoadPE) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void startTextureLoading(ref string fileName, OdRxObject pDb)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fileName);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_startTextureLoading(swigCPtr, ref jarg, OdRxObject.getCPtr(pDb));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				fileName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual void textureLoaded(string fileName, OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_textureLoaded(swigCPtr, fileName, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void textureLoadingFailed(string fileName, OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_textureLoadingFailed(swigCPtr, fileName, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("startTextureLoading", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodstartTextureLoading;
		}
		if (SwigDerivedClassHasMethod("textureLoaded", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodtextureLoaded;
		}
		if (SwigDerivedClassHasMethod("textureLoadingFailed", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodtextureLoadingFailed;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialTextureLoadPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMaterialTextureLoadPE));
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

	private void SwigDirectorMethodstartTextureLoading(IntPtr fileName, IntPtr pDb)
	{
		OdSwigDirectorHelper.director_UnpackData(fileName, out var pOriginalObject, out var pFunction);
		string fileName2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = fileName2;
		try
		{
			startTextureLoading(ref fileName2, Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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
		finally
		{
			if (fileName2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(fileName2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(fileName);
		}
	}

	private void SwigDirectorMethodtextureLoaded([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pDb)
	{
		try
		{
			textureLoaded(fileName, Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodtextureLoadingFailed([MarshalAs(UnmanagedType.LPWStr)] string fileName, IntPtr pDb)
	{
		try
		{
			textureLoadingFailed(fileName, Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false));
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
