using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdCryptoServices : OdRxObject
{
	public delegate IntPtr SwigDelegateOdCryptoServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdCryptoServices_1();

	public delegate void SwigDelegateOdCryptoServices_2(IntPtr pSource);

	public delegate uint SwigDelegateOdCryptoServices_3(IntPtr certificates);

	public delegate IntPtr SwigDelegateOdCryptoServices_4(IntPtr certShortDesc);

	public delegate IntPtr SwigDelegateOdCryptoServices_5(IntPtr dataOfAttrValue);

	public delegate IntPtr SwigDelegateOdCryptoServices_6(IntPtr pCertObj, IntPtr pSubjectKeyIdAttr);

	public delegate bool SwigDelegateOdCryptoServices_7(IntPtr pSignPara, IntPtr message, OdBinaryData signature);

	public delegate void SwigDelegateOdCryptoServices_8(IntPtr message, IntPtr signature, OdCryptoServices_OdSignatureVerificationResult verificationResult);

	public delegate IntPtr SwigDelegateOdCryptoServices_9(IntPtr signature);

	public delegate IntPtr SwigDelegateOdCryptoServices_10(IntPtr signature);

	public delegate bool SwigDelegateOdCryptoServices_11(IntPtr passwordAsBinaryData, uint nProvType, [MarshalAs(UnmanagedType.LPWStr)] string provName, uint nAlgId, uint nKeyLength);

	public delegate void SwigDelegateOdCryptoServices_12();

	public delegate bool SwigDelegateOdCryptoServices_13(IntPtr buffer, uint bufferSize);

	public delegate bool SwigDelegateOdCryptoServices_14(IntPtr buffer, uint bufferSize);

	public delegate void SwigDelegateOdCryptoServices_15(bool allow);

	public delegate bool SwigDelegateOdCryptoServices_16();

	public delegate void SwigDelegateOdCryptoServices_17(IntPtr store);

	public delegate IntPtr SwigDelegateOdCryptoServices_18();

	public delegate bool SwigDelegateOdCryptoServices_19(IntPtr cert);

	public delegate IntPtr SwigDelegateOdCryptoServices_20(IntPtr pCertObj, int hashAlg, IntPtr data, OdBinaryData signature);

	public delegate int SwigDelegateOdCryptoServices_21(IntPtr pCertObj, int hashAlg, IntPtr data, IntPtr signature);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdCryptoServices_0 swigDelegate0;

	private SwigDelegateOdCryptoServices_1 swigDelegate1;

	private SwigDelegateOdCryptoServices_2 swigDelegate2;

	private SwigDelegateOdCryptoServices_3 swigDelegate3;

	private SwigDelegateOdCryptoServices_4 swigDelegate4;

	private SwigDelegateOdCryptoServices_5 swigDelegate5;

	private SwigDelegateOdCryptoServices_6 swigDelegate6;

	private SwigDelegateOdCryptoServices_7 swigDelegate7;

	private SwigDelegateOdCryptoServices_8 swigDelegate8;

	private SwigDelegateOdCryptoServices_9 swigDelegate9;

	private SwigDelegateOdCryptoServices_10 swigDelegate10;

	private SwigDelegateOdCryptoServices_11 swigDelegate11;

	private SwigDelegateOdCryptoServices_12 swigDelegate12;

	private SwigDelegateOdCryptoServices_13 swigDelegate13;

	private SwigDelegateOdCryptoServices_14 swigDelegate14;

	private SwigDelegateOdCryptoServices_15 swigDelegate15;

	private SwigDelegateOdCryptoServices_16 swigDelegate16;

	private SwigDelegateOdCryptoServices_17 swigDelegate17;

	private SwigDelegateOdCryptoServices_18 swigDelegate18;

	private SwigDelegateOdCryptoServices_19 swigDelegate19;

	private SwigDelegateOdCryptoServices_20 swigDelegate20;

	private SwigDelegateOdCryptoServices_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdArray_OdCertificateDescription_OdObjectsAllocator) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdCertificateShortDesc) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdBinaryData) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdCertificateObject),
		typeof(OdSubjectKeyIdAttrib)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdCryptSignMessagePara),
		typeof(OdBinaryDataLinkedArray),
		typeof(OdBinaryData).MakeByRefType()
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdBinaryDataLinkedArray),
		typeof(OdBinaryData),
		typeof(OdCryptoServices_OdSignatureVerificationResult).MakeByRefType()
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdBinaryData) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdBinaryData) };

	private static Type[] swigMethodTypes11 = new Type[5]
	{
		typeof(OdBinaryData),
		typeof(uint),
		typeof(string),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(byte[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(byte[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdAlternativeCertificateStore) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdCertificateObject) };

	private static Type[] swigMethodTypes20 = new Type[4]
	{
		typeof(OdCertificateObject),
		typeof(OdSignatureHashAlgorithm),
		typeof(OdBinaryData),
		typeof(OdBinaryData).MakeByRefType()
	};

	private static Type[] swigMethodTypes21 = new Type[4]
	{
		typeof(OdCertificateObject),
		typeof(OdSignatureHashAlgorithm),
		typeof(OdBinaryData),
		typeof(OdBinaryData)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdCryptoServices(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdCryptoServices obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdCryptoServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdCryptoServices cast(OdRxObject pObj)
	{
		OdCryptoServices rXObject = Helpers.GetRXObject<OdCryptoServices>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_isASwigExplicitOdCryptoServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_queryXSwigExplicitOdCryptoServices(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdCryptoServices createObject()
	{
		OdCryptoServices rXObject = Helpers.GetRXObject<OdCryptoServices>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint getPersonalCertsWithTrustedStatus(OdArray_OdCertificateDescription_OdObjectsAllocator certificates)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_getPersonalCertsWithTrustedStatus(swigCPtr, OdArray_OdCertificateDescription_OdObjectsAllocator.getCPtr(certificates));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCertificateObject getCertObjByShortDesc(OdCertificateShortDesc certShortDesc)
	{
		OdCertificateObject result = Helpers.GetObject<OdCertificateObject>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_getCertObjByShortDesc(swigCPtr, OdCertificateShortDesc.getCPtr(certShortDesc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdSubjectKeyIdAttrib newSubjectKeyIdentifierAttr(OdBinaryData dataOfAttrValue)
	{
		OdSubjectKeyIdAttrib result = Helpers.GetObject<OdSubjectKeyIdAttrib>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_newSubjectKeyIdentifierAttr(swigCPtr, OdBinaryData.getCPtr(dataOfAttrValue).Handle), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCryptSignMessagePara newCryptSignMessagePara(OdCertificateObject pCertObj, OdSubjectKeyIdAttrib pSubjectKeyIdAttr)
	{
		OdCryptSignMessagePara result = Helpers.GetObject<OdCryptSignMessagePara>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_newCryptSignMessagePara(swigCPtr, OdCertificateObject.getCPtr(pCertObj), OdSubjectKeyIdAttrib.getCPtr(pSubjectKeyIdAttr)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool generateDetachedSignature(OdCryptSignMessagePara pSignPara, OdBinaryDataLinkedArray message, out OdBinaryData signature)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_generateDetachedSignature(swigCPtr, OdCryptSignMessagePara.getCPtr(pSignPara), OdBinaryDataLinkedArray.getCPtr(message), out signature);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void verifyDetachedSignature(OdBinaryDataLinkedArray message, OdBinaryData signature, out OdCryptoServices_OdSignatureVerificationResult verificationResult)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_verifyDetachedSignature(swigCPtr, OdBinaryDataLinkedArray.getCPtr(message), OdBinaryData.getCPtr(signature).Handle, out verificationResult);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCertificateObject getCertFromDetachedSignature(OdBinaryData signature)
	{
		OdCertificateObject result = Helpers.GetObject<OdCertificateObject>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_getCertFromDetachedSignature(swigCPtr, OdBinaryData.getCPtr(signature).Handle), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdSubjectKeyIdAttrib getSubjectKeyIdFromDetachedSignature(OdBinaryData signature)
	{
		OdSubjectKeyIdAttrib result = Helpers.GetObject<OdSubjectKeyIdAttrib>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_getSubjectKeyIdFromDetachedSignature(swigCPtr, OdBinaryData.getCPtr(signature).Handle), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool initSessionKeyToEncryptData(OdBinaryData passwordAsBinaryData, uint nProvType, string provName, uint nAlgId, uint nKeyLength)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_initSessionKeyToEncryptData(swigCPtr, OdBinaryData.getCPtr(passwordAsBinaryData).Handle, nProvType, provName, nAlgId, nKeyLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void resetSessionKeyToEncryptData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_resetSessionKeyToEncryptData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool encryptData(byte[] buffer, uint bufferSize)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_encryptData(swigCPtr, Helpers.MarshalbyteFixedArray(buffer), bufferSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool decryptData(byte[] buffer, uint bufferSize)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_decryptData(swigCPtr, Helpers.MarshalbyteFixedArray(buffer), bufferSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAllowSelfSignedCerts(bool allow)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_setAllowSelfSignedCerts(swigCPtr, allow);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool allowSelfSignedCerts()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_allowSelfSignedCerts(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAlternativeCertificateStore(OdAlternativeCertificateStore store)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_setAlternativeCertificateStore(swigCPtr, OdAlternativeCertificateStore.getCPtr(store));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdAlternativeCertificateStore alternativeCertificateStore()
	{
		OdAlternativeCertificateStore rXObject = Helpers.GetRXObject<OdAlternativeCertificateStore>(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_alternativeCertificateStore(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isTrustedCert(OdCertificateObject cert)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_isTrustedCert(swigCPtr, OdCertificateObject.getCPtr(cert));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdSignDataStatus signData(OdCertificateObject pCertObj, OdSignatureHashAlgorithm hashAlg, OdBinaryData data, out OdBinaryData signature)
	{
		OdSignDataStatus result = new OdSignDataStatus(TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_signData(swigCPtr, OdCertificateObject.getCPtr(pCertObj), (int)hashAlg, OdBinaryData.getCPtr(data).Handle, out signature), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCryptoServices_OdSignatureVerificationResult verifySignature(OdCertificateObject pCertObj, OdSignatureHashAlgorithm hashAlg, OdBinaryData data, OdBinaryData signature)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_verifySignature(swigCPtr, OdCertificateObject.getCPtr(pCertObj), (int)hashAlg, OdBinaryData.getCPtr(data).Handle, OdBinaryData.getCPtr(signature).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCryptoServices_OdSignatureVerificationResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCryptoServices()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCryptoServices(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdCryptoServices) != GetType();
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
		if (SwigDerivedClassHasMethod("getPersonalCertsWithTrustedStatus", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetPersonalCertsWithTrustedStatus;
		}
		if (SwigDerivedClassHasMethod("getCertObjByShortDesc", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetCertObjByShortDesc;
		}
		if (SwigDerivedClassHasMethod("newSubjectKeyIdentifierAttr", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnewSubjectKeyIdentifierAttr;
		}
		if (SwigDerivedClassHasMethod("newCryptSignMessagePara", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewCryptSignMessagePara;
		}
		if (SwigDerivedClassHasMethod("generateDetachedSignature", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgenerateDetachedSignature;
		}
		if (SwigDerivedClassHasMethod("verifyDetachedSignature", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodverifyDetachedSignature;
		}
		if (SwigDerivedClassHasMethod("getCertFromDetachedSignature", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetCertFromDetachedSignature;
		}
		if (SwigDerivedClassHasMethod("getSubjectKeyIdFromDetachedSignature", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetSubjectKeyIdFromDetachedSignature;
		}
		if (SwigDerivedClassHasMethod("initSessionKeyToEncryptData", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodinitSessionKeyToEncryptData;
		}
		if (SwigDerivedClassHasMethod("resetSessionKeyToEncryptData", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodresetSessionKeyToEncryptData;
		}
		if (SwigDerivedClassHasMethod("encryptData", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodencryptData;
		}
		if (SwigDerivedClassHasMethod("decryptData", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethoddecryptData;
		}
		if (SwigDerivedClassHasMethod("setAllowSelfSignedCerts", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetAllowSelfSignedCerts;
		}
		if (SwigDerivedClassHasMethod("allowSelfSignedCerts", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodallowSelfSignedCerts;
		}
		if (SwigDerivedClassHasMethod("setAlternativeCertificateStore", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetAlternativeCertificateStore;
		}
		if (SwigDerivedClassHasMethod("alternativeCertificateStore", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodalternativeCertificateStore;
		}
		if (SwigDerivedClassHasMethod("isTrustedCert", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodisTrustedCert;
		}
		if (SwigDerivedClassHasMethod("signData", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsignData;
		}
		if (SwigDerivedClassHasMethod("verifySignature", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodverifySignature;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdCryptoServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdCryptoServices));
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

	private uint SwigDirectorMethodgetPersonalCertsWithTrustedStatus(IntPtr certificates)
	{
		return getPersonalCertsWithTrustedStatus(new OdArray_OdCertificateDescription_OdObjectsAllocator(certificates, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodgetCertObjByShortDesc(IntPtr certShortDesc)
	{
		return OdCertificateObject.getCPtr(getCertObjByShortDesc(new OdCertificateShortDesc(certShortDesc, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodnewSubjectKeyIdentifierAttr(IntPtr dataOfAttrValue)
	{
		return OdSubjectKeyIdAttrib.getCPtr(newSubjectKeyIdentifierAttr(new OdBinaryData(dataOfAttrValue, cMemoryOwn: true))).Handle;
	}

	private IntPtr SwigDirectorMethodnewCryptSignMessagePara(IntPtr pCertObj, IntPtr pSubjectKeyIdAttr)
	{
		return OdCryptSignMessagePara.getCPtr(newCryptSignMessagePara(Helpers.GetObject<OdCertificateObject>(pCertObj, bOwn: true, bTryAddToTransaction: false), Helpers.GetObject<OdSubjectKeyIdAttrib>(pSubjectKeyIdAttr, bOwn: true, bTryAddToTransaction: false))).Handle;
	}

	private bool SwigDirectorMethodgenerateDetachedSignature(IntPtr pSignPara, IntPtr message, OdBinaryData signature)
	{
		return generateDetachedSignature(Helpers.GetObject<OdCryptSignMessagePara>(pSignPara, bOwn: true, bTryAddToTransaction: false), new OdBinaryDataLinkedArray(message, cMemoryOwn: false), out signature);
	}

	private void SwigDirectorMethodverifyDetachedSignature(IntPtr message, IntPtr signature, OdCryptoServices_OdSignatureVerificationResult verificationResult)
	{
		try
		{
			verifyDetachedSignature(new OdBinaryDataLinkedArray(message, cMemoryOwn: false), new OdBinaryData(signature, cMemoryOwn: true), out verificationResult);
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

	private IntPtr SwigDirectorMethodgetCertFromDetachedSignature(IntPtr signature)
	{
		return OdCertificateObject.getCPtr(getCertFromDetachedSignature(new OdBinaryData(signature, cMemoryOwn: true))).Handle;
	}

	private IntPtr SwigDirectorMethodgetSubjectKeyIdFromDetachedSignature(IntPtr signature)
	{
		return OdSubjectKeyIdAttrib.getCPtr(getSubjectKeyIdFromDetachedSignature(new OdBinaryData(signature, cMemoryOwn: true))).Handle;
	}

	private bool SwigDirectorMethodinitSessionKeyToEncryptData(IntPtr passwordAsBinaryData, uint nProvType, [MarshalAs(UnmanagedType.LPWStr)] string provName, uint nAlgId, uint nKeyLength)
	{
		return initSessionKeyToEncryptData(new OdBinaryData(passwordAsBinaryData, cMemoryOwn: true), nProvType, provName, nAlgId, nKeyLength);
	}

	private void SwigDirectorMethodresetSessionKeyToEncryptData()
	{
		try
		{
			resetSessionKeyToEncryptData();
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

	private bool SwigDirectorMethodencryptData(IntPtr buffer, uint bufferSize)
	{
		return encryptData(Helpers.UnMarshalbyteFixedArray(buffer), bufferSize);
	}

	private bool SwigDirectorMethoddecryptData(IntPtr buffer, uint bufferSize)
	{
		return decryptData(Helpers.UnMarshalbyteFixedArray(buffer), bufferSize);
	}

	private void SwigDirectorMethodsetAllowSelfSignedCerts(bool allow)
	{
		try
		{
			setAllowSelfSignedCerts(allow);
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

	private bool SwigDirectorMethodallowSelfSignedCerts()
	{
		return allowSelfSignedCerts();
	}

	private void SwigDirectorMethodsetAlternativeCertificateStore(IntPtr store)
	{
		try
		{
			setAlternativeCertificateStore(Helpers.GetRXObject<OdAlternativeCertificateStore>(store, bOwn: true, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodalternativeCertificateStore()
	{
		return OdAlternativeCertificateStore.getCPtr(alternativeCertificateStore()).Handle;
	}

	private bool SwigDirectorMethodisTrustedCert(IntPtr cert)
	{
		return isTrustedCert(Helpers.GetObject<OdCertificateObject>(cert, bOwn: true, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodsignData(IntPtr pCertObj, int hashAlg, IntPtr data, OdBinaryData signature)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdSignDataStatus.getCPtr(signData(Helpers.GetObject<OdCertificateObject>(pCertObj, bOwn: true, bTryAddToTransaction: false), (OdSignatureHashAlgorithm)hashAlg, new OdBinaryData(data, cMemoryOwn: true), out signature)).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private int SwigDirectorMethodverifySignature(IntPtr pCertObj, int hashAlg, IntPtr data, IntPtr signature)
	{
		return (int)verifySignature(Helpers.GetObject<OdCertificateObject>(pCertObj, bOwn: true, bTryAddToTransaction: false), (OdSignatureHashAlgorithm)hashAlg, new OdBinaryData(data, cMemoryOwn: true), new OdBinaryData(signature, cMemoryOwn: true));
	}
}
