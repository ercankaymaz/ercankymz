using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbCrypt : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbCrypt_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbCrypt_1();

	public delegate void SwigDelegateOdDbCrypt_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbCrypt_3(IntPtr securityParams);

	public delegate bool SwigDelegateOdDbCrypt_4(IntPtr buffer);

	public delegate bool SwigDelegateOdDbCrypt_5(IntPtr buffer);

	public delegate bool SwigDelegateOdDbCrypt_6();

	public delegate void SwigDelegateOdDbCrypt_7(IntPtr dataBlock);

	public delegate bool SwigDelegateOdDbCrypt_8(IntPtr securityParams, IntPtr signatureBlock);

	public delegate void SwigDelegateOdDbCrypt_9(IntPtr signatureBlock, OdCryptoServices_OdSignatureVerificationResult verificationResult, IntPtr signatureDesc);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbCrypt_0 swigDelegate0;

	private SwigDelegateOdDbCrypt_1 swigDelegate1;

	private SwigDelegateOdDbCrypt_2 swigDelegate2;

	private SwigDelegateOdDbCrypt_3 swigDelegate3;

	private SwigDelegateOdDbCrypt_4 swigDelegate4;

	private SwigDelegateOdDbCrypt_5 swigDelegate5;

	private SwigDelegateOdDbCrypt_6 swigDelegate6;

	private SwigDelegateOdDbCrypt_7 swigDelegate7;

	private SwigDelegateOdDbCrypt_8 swigDelegate8;

	private SwigDelegateOdDbCrypt_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdSecurityParams) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(byte[]) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(byte[]) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdBinaryData) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdSecurityParams),
		typeof(OdBinaryData)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdBinaryData),
		typeof(OdCryptoServices_OdSignatureVerificationResult).MakeByRefType(),
		typeof(OdSignatureDescription)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbCrypt(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbCrypt obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbCrypt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbCrypt()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbCrypt(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbCrypt cast(OdRxObject pObj)
	{
		OdDbCrypt rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCrypt>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_isASwigExplicitOdDbCrypt(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_queryXSwigExplicitOdDbCrypt(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbCrypt createObject()
	{
		OdDbCrypt rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCrypt>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool initialize(OdSecurityParams securityParams)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_initialize(swigCPtr, OdSecurityParams.getCPtr(securityParams));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool encryptData(byte[] buffer)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_encryptData(swigCPtr, intPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual bool decryptData(byte[] buffer)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_decryptData(swigCPtr, intPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual bool digitalSignatureModeLaunched()
	{
		bool result = (SwigDerivedClassHasMethod("digitalSignatureModeLaunched", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_digitalSignatureModeLaunchedSwigExplicitOdDbCrypt(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_digitalSignatureModeLaunched(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void appendDataToProcessSignature(OdBinaryData dataBlock)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_appendDataToProcessSignature(swigCPtr, OdBinaryData.getCPtr(dataBlock).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool signData(OdSecurityParams securityParams, OdBinaryData signatureBlock)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_signData(swigCPtr, OdSecurityParams.getCPtr(securityParams), OdBinaryData.getCPtr(signatureBlock).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void verifyDataSignature(OdBinaryData signatureBlock, out OdCryptoServices_OdSignatureVerificationResult verificationResult, OdSignatureDescription signatureDesc)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_verifyDataSignature(swigCPtr, OdBinaryData.getCPtr(signatureBlock).Handle, out verificationResult, OdSignatureDescription.getCPtr(signatureDesc).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("initialize", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinitialize;
		}
		if (SwigDerivedClassHasMethod("encryptData", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodencryptData;
		}
		if (SwigDerivedClassHasMethod("decryptData", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddecryptData;
		}
		if (SwigDerivedClassHasMethod("digitalSignatureModeLaunched", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddigitalSignatureModeLaunched;
		}
		if (SwigDerivedClassHasMethod("appendDataToProcessSignature", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodappendDataToProcessSignature;
		}
		if (SwigDerivedClassHasMethod("signData", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsignData;
		}
		if (SwigDerivedClassHasMethod("verifyDataSignature", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodverifyDataSignature;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCrypt_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbCrypt));
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

	private bool SwigDirectorMethodinitialize(IntPtr securityParams)
	{
		return initialize(new OdSecurityParams(securityParams, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodencryptData(IntPtr buffer)
	{
		return encryptData(ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalbyteFixedArray(buffer));
	}

	private bool SwigDirectorMethoddecryptData(IntPtr buffer)
	{
		return decryptData(ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalbyteFixedArray(buffer));
	}

	private bool SwigDirectorMethoddigitalSignatureModeLaunched()
	{
		return digitalSignatureModeLaunched();
	}

	private void SwigDirectorMethodappendDataToProcessSignature(IntPtr dataBlock)
	{
		try
		{
			appendDataToProcessSignature(new OdBinaryData(dataBlock, cMemoryOwn: true));
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

	private bool SwigDirectorMethodsignData(IntPtr securityParams, IntPtr signatureBlock)
	{
		return signData(new OdSecurityParams(securityParams, cMemoryOwn: false), new OdBinaryData(signatureBlock, cMemoryOwn: true));
	}

	private void SwigDirectorMethodverifyDataSignature(IntPtr signatureBlock, OdCryptoServices_OdSignatureVerificationResult verificationResult, IntPtr signatureDesc)
	{
		try
		{
			verifyDataSignature(new OdBinaryData(signatureBlock, cMemoryOwn: true), out verificationResult, new OdSignatureDescription(signatureDesc, cMemoryOwn: true));
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
