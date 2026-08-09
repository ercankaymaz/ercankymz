using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDwfxSignatureHandlerModule : OdRxModule
{
	public delegate IntPtr SwigDelegateOdDwfxSignatureHandlerModule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDwfxSignatureHandlerModule_1();

	public delegate void SwigDelegateOdDwfxSignatureHandlerModule_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDwfxSignatureHandlerModule_3();

	public delegate void SwigDelegateOdDwfxSignatureHandlerModule_4();

	public delegate void SwigDelegateOdDwfxSignatureHandlerModule_5();

	public delegate void SwigDelegateOdDwfxSignatureHandlerModule_6();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDwfxSignatureHandlerModule_7();

	public delegate IntPtr SwigDelegateOdDwfxSignatureHandlerModule_8();

	public delegate int SwigDelegateOdDwfxSignatureHandlerModule_9(IntPtr certificates);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDwfxSignatureHandlerModule_0 swigDelegate0;

	private SwigDelegateOdDwfxSignatureHandlerModule_1 swigDelegate1;

	private SwigDelegateOdDwfxSignatureHandlerModule_2 swigDelegate2;

	private SwigDelegateOdDwfxSignatureHandlerModule_3 swigDelegate3;

	private SwigDelegateOdDwfxSignatureHandlerModule_4 swigDelegate4;

	private SwigDelegateOdDwfxSignatureHandlerModule_5 swigDelegate5;

	private SwigDelegateOdDwfxSignatureHandlerModule_6 swigDelegate6;

	private SwigDelegateOdDwfxSignatureHandlerModule_7 swigDelegate7;

	private SwigDelegateOdDwfxSignatureHandlerModule_8 swigDelegate8;

	private SwigDelegateOdDwfxSignatureHandlerModule_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdArray_OdCertParameters_OdObjectsAllocator) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDwfxSignatureHandlerModule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandlerModule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDwfxSignatureHandlerModule obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDwfxSignatureHandlerModule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdDwfxSignatureHandler getDwfxSignatureHandler()
	{
		OdDwfxSignatureHandler result = Helpers.GetObject<OdDwfxSignatureHandler>(TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandlerModule_getDwfxSignatureHandler(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getSuitableCertificatesList(OdArray_OdCertParameters_OdObjectsAllocator certificates)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandlerModule_getSuitableCertificatesList(swigCPtr, OdArray_OdCertParameters_OdObjectsAllocator.getCPtr(certificates));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandlerModule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("sysData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsysData;
		}
		if (SwigDerivedClassHasMethod("deleteModule", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddeleteModule;
		}
		if (SwigDerivedClassHasMethod("initApp", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodinitApp;
		}
		if (SwigDerivedClassHasMethod("uninitApp", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoduninitApp;
		}
		if (SwigDerivedClassHasMethod("moduleName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmoduleName;
		}
		if (SwigDerivedClassHasMethod("getDwfxSignatureHandler", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetDwfxSignatureHandler;
		}
		if (SwigDerivedClassHasMethod("getSuitableCertificatesList", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetSuitableCertificatesList;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandlerModule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDwfxSignatureHandlerModule));
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

	private IntPtr SwigDirectorMethodsysData()
	{
		return sysData();
	}

	private void SwigDirectorMethoddeleteModule()
	{
		try
		{
			deleteModule();
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

	private void SwigDirectorMethodinitApp()
	{
		try
		{
			initApp();
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

	private void SwigDirectorMethoduninitApp()
	{
		try
		{
			uninitApp();
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
	private string SwigDirectorMethodmoduleName()
	{
		return moduleName();
	}

	private IntPtr SwigDirectorMethodgetDwfxSignatureHandler()
	{
		return OdDwfxSignatureHandler.getCPtr(getDwfxSignatureHandler()).Handle;
	}

	private int SwigDirectorMethodgetSuitableCertificatesList(IntPtr certificates)
	{
		return getSuitableCertificatesList(new OdArray_OdCertParameters_OdObjectsAllocator(certificates, cMemoryOwn: false));
	}
}
