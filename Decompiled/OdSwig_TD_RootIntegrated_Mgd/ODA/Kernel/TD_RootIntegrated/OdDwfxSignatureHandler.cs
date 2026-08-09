using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDwfxSignatureHandler : IDisposable
{
	public delegate void SwigDelegateOdDwfxSignatureHandler_0(IntPtr certParams);

	public delegate bool SwigDelegateOdDwfxSignatureHandler_1([MarshalAs(UnmanagedType.LPWStr)] string filePath);

	public delegate bool SwigDelegateOdDwfxSignatureHandler_2([MarshalAs(UnmanagedType.LPWStr)] string filePath);

	public delegate bool SwigDelegateOdDwfxSignatureHandler_3([MarshalAs(UnmanagedType.LPWStr)] string filePath, OdDwfxSignatureHandler_SignatureValidationResult validationResult, IntPtr certParams);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDwfxSignatureHandler_0 swigDelegate0;

	private SwigDelegateOdDwfxSignatureHandler_1 swigDelegate1;

	private SwigDelegateOdDwfxSignatureHandler_2 swigDelegate2;

	private SwigDelegateOdDwfxSignatureHandler_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdCertParameters) };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(string),
		typeof(OdDwfxSignatureHandler_SignatureValidationResult).MakeByRefType(),
		typeof(OdCertParameters)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDwfxSignatureHandler(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDwfxSignatureHandler obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDwfxSignatureHandler()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDwfxSignatureHandler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void setCertParameters(OdCertParameters certParams)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandler_setCertParameters(swigCPtr, OdCertParameters.getCPtr(certParams));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool signPackage(string filePath)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandler_signPackage(swigCPtr, filePath);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool removeExistingSignature(string filePath)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandler_removeExistingSignature(swigCPtr, filePath);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool validatePackageSignature(string filePath, out OdDwfxSignatureHandler_SignatureValidationResult validationResult, OdCertParameters certParams)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandler_validatePackageSignature(swigCPtr, filePath, out validationResult, OdCertParameters.getCPtr(certParams));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandler_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDwfxSignatureHandler()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDwfxSignatureHandler(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDwfxSignatureHandler) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("setCertParameters", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodsetCertParameters;
		}
		if (SwigDerivedClassHasMethod("signPackage", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsignPackage;
		}
		if (SwigDerivedClassHasMethod("removeExistingSignature", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodremoveExistingSignature;
		}
		if (SwigDerivedClassHasMethod("validatePackageSignature", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodvalidatePackageSignature;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDwfxSignatureHandler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDwfxSignatureHandler));
	}

	private void SwigDirectorMethodsetCertParameters(IntPtr certParams)
	{
		try
		{
			setCertParameters(new OdCertParameters(certParams, cMemoryOwn: false));
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

	private bool SwigDirectorMethodsignPackage([MarshalAs(UnmanagedType.LPWStr)] string filePath)
	{
		return signPackage(filePath);
	}

	private bool SwigDirectorMethodremoveExistingSignature([MarshalAs(UnmanagedType.LPWStr)] string filePath)
	{
		return removeExistingSignature(filePath);
	}

	private bool SwigDirectorMethodvalidatePackageSignature([MarshalAs(UnmanagedType.LPWStr)] string filePath, OdDwfxSignatureHandler_SignatureValidationResult validationResult, IntPtr certParams)
	{
		return validatePackageSignature(filePath, out validationResult, new OdCertParameters(certParams, cMemoryOwn: false));
	}
}
