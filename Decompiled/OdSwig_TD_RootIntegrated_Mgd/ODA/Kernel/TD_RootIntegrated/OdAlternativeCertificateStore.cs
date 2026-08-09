using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAlternativeCertificateStore : OdRxObject
{
	public delegate IntPtr SwigDelegateOdAlternativeCertificateStore_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdAlternativeCertificateStore_1();

	public delegate void SwigDelegateOdAlternativeCertificateStore_2(IntPtr pSource);

	public delegate uint SwigDelegateOdAlternativeCertificateStore_3(IntPtr certificates);

	public delegate IntPtr SwigDelegateOdAlternativeCertificateStore_4(IntPtr certShortDesc);

	public delegate bool SwigDelegateOdAlternativeCertificateStore_5(IntPtr cert);

	public delegate void SwigDelegateOdAlternativeCertificateStore_6([MarshalAs(UnmanagedType.LPWStr)] string dir);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdAlternativeCertificateStore_7();

	public delegate void SwigDelegateOdAlternativeCertificateStore_8([MarshalAs(UnmanagedType.LPWStr)] string dir);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdAlternativeCertificateStore_9();

	public delegate void SwigDelegateOdAlternativeCertificateStore_10([MarshalAs(UnmanagedType.LPWStr)] string dir);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdAlternativeCertificateStore_11();

	public delegate void SwigDelegateOdAlternativeCertificateStore_12([MarshalAs(UnmanagedType.LPWStr)] string fullPathToCaBundle);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdAlternativeCertificateStore_13();

	public delegate void SwigDelegateOdAlternativeCertificateStore_14(bool allow);

	public delegate void SwigDelegateOdAlternativeCertificateStore_15(IntPtr privateKeyFileNames);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdAlternativeCertificateStore_0 swigDelegate0;

	private SwigDelegateOdAlternativeCertificateStore_1 swigDelegate1;

	private SwigDelegateOdAlternativeCertificateStore_2 swigDelegate2;

	private SwigDelegateOdAlternativeCertificateStore_3 swigDelegate3;

	private SwigDelegateOdAlternativeCertificateStore_4 swigDelegate4;

	private SwigDelegateOdAlternativeCertificateStore_5 swigDelegate5;

	private SwigDelegateOdAlternativeCertificateStore_6 swigDelegate6;

	private SwigDelegateOdAlternativeCertificateStore_7 swigDelegate7;

	private SwigDelegateOdAlternativeCertificateStore_8 swigDelegate8;

	private SwigDelegateOdAlternativeCertificateStore_9 swigDelegate9;

	private SwigDelegateOdAlternativeCertificateStore_10 swigDelegate10;

	private SwigDelegateOdAlternativeCertificateStore_11 swigDelegate11;

	private SwigDelegateOdAlternativeCertificateStore_12 swigDelegate12;

	private SwigDelegateOdAlternativeCertificateStore_13 swigDelegate13;

	private SwigDelegateOdAlternativeCertificateStore_14 swigDelegate14;

	private SwigDelegateOdAlternativeCertificateStore_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdArray_OdCertificateDescription_OdObjectsAllocator) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdCertificateShortDesc) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdCertificateObject) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdStringArray) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAlternativeCertificateStore(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAlternativeCertificateStore obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAlternativeCertificateStore(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdAlternativeCertificateStore cast(OdRxObject pObj)
	{
		OdAlternativeCertificateStore rXObject = Helpers.GetRXObject<OdAlternativeCertificateStore>(TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_isASwigExplicitOdAlternativeCertificateStore(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_queryXSwigExplicitOdAlternativeCertificateStore(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdAlternativeCertificateStore createObject()
	{
		OdAlternativeCertificateStore rXObject = Helpers.GetRXObject<OdAlternativeCertificateStore>(TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint getPersonalCertsWithTrustedStatus(OdArray_OdCertificateDescription_OdObjectsAllocator certificates)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_getPersonalCertsWithTrustedStatus(swigCPtr, OdArray_OdCertificateDescription_OdObjectsAllocator.getCPtr(certificates));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCertificateObject getCertObjByShortDesc(OdCertificateShortDesc certShortDesc)
	{
		OdCertificateObject result = Helpers.GetObject<OdCertificateObject>(TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_getCertObjByShortDesc(swigCPtr, OdCertificateShortDesc.getCPtr(certShortDesc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isTrusted(OdCertificateObject cert)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_isTrusted(swigCPtr, OdCertificateObject.getCPtr(cert));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCertsDirectory(string dir)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_setCertsDirectory(swigCPtr, dir);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string certsDirectory()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_certsDirectory(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPrivateKeysDirectory(string dir)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_setPrivateKeysDirectory(swigCPtr, dir);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string privateKeysDirectory()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_privateKeysDirectory(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCaDirectory(string dir)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_setCaDirectory(swigCPtr, dir);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string caDirectory()
	{
		string result = (SwigDerivedClassHasMethod("caDirectory", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_caDirectorySwigExplicitOdAlternativeCertificateStore(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_caDirectory(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCaBundleFile(string fullPathToCaBundle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_setCaBundleFile(swigCPtr, fullPathToCaBundle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string caBundleFile()
	{
		string result = (SwigDerivedClassHasMethod("caBundleFile", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_caBundleFileSwigExplicitOdAlternativeCertificateStore(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_caBundleFile(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAllowSelfSignedCerts(bool allow)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_setAllowSelfSignedCerts(swigCPtr, allow);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getAllPrivateKeyFileNames(OdStringArray privateKeyFileNames)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_getAllPrivateKeyFileNames(swigCPtr, OdStringArray.getCPtr(privateKeyFileNames));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdAlternativeCertificateStore()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdAlternativeCertificateStore(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdAlternativeCertificateStore) != GetType();
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
		if (SwigDerivedClassHasMethod("isTrusted", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodisTrusted;
		}
		if (SwigDerivedClassHasMethod("setCertsDirectory", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetCertsDirectory;
		}
		if (SwigDerivedClassHasMethod("certsDirectory", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcertsDirectory;
		}
		if (SwigDerivedClassHasMethod("setPrivateKeysDirectory", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetPrivateKeysDirectory;
		}
		if (SwigDerivedClassHasMethod("privateKeysDirectory", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodprivateKeysDirectory;
		}
		if (SwigDerivedClassHasMethod("setCaDirectory", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetCaDirectory;
		}
		if (SwigDerivedClassHasMethod("caDirectory", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcaDirectory;
		}
		if (SwigDerivedClassHasMethod("setCaBundleFile", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetCaBundleFile;
		}
		if (SwigDerivedClassHasMethod("caBundleFile", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodcaBundleFile;
		}
		if (SwigDerivedClassHasMethod("setAllowSelfSignedCerts", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetAllowSelfSignedCerts;
		}
		if (SwigDerivedClassHasMethod("getAllPrivateKeyFileNames", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetAllPrivateKeyFileNames;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdAlternativeCertificateStore_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdAlternativeCertificateStore));
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

	private bool SwigDirectorMethodisTrusted(IntPtr cert)
	{
		return isTrusted(Helpers.GetObject<OdCertificateObject>(cert, bOwn: true, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetCertsDirectory([MarshalAs(UnmanagedType.LPWStr)] string dir)
	{
		try
		{
			setCertsDirectory(dir);
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
	private string SwigDirectorMethodcertsDirectory()
	{
		return certsDirectory();
	}

	private void SwigDirectorMethodsetPrivateKeysDirectory([MarshalAs(UnmanagedType.LPWStr)] string dir)
	{
		try
		{
			setPrivateKeysDirectory(dir);
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
	private string SwigDirectorMethodprivateKeysDirectory()
	{
		return privateKeysDirectory();
	}

	private void SwigDirectorMethodsetCaDirectory([MarshalAs(UnmanagedType.LPWStr)] string dir)
	{
		try
		{
			setCaDirectory(dir);
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
	private string SwigDirectorMethodcaDirectory()
	{
		return caDirectory();
	}

	private void SwigDirectorMethodsetCaBundleFile([MarshalAs(UnmanagedType.LPWStr)] string fullPathToCaBundle)
	{
		try
		{
			setCaBundleFile(fullPathToCaBundle);
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
	private string SwigDirectorMethodcaBundleFile()
	{
		return caBundleFile();
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

	private void SwigDirectorMethodgetAllPrivateKeyFileNames(IntPtr privateKeyFileNames)
	{
		try
		{
			getAllPrivateKeyFileNames(new OdStringArray(privateKeyFileNames, cMemoryOwn: false));
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
