using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdCertificateObjectWinImpl : OdCertificateObject
{
	public delegate IntPtr SwigDelegateOdCertificateObjectWinImpl_0();

	public delegate bool SwigDelegateOdCertificateObjectWinImpl_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdCertificateObjectWinImpl_0 swigDelegate0;

	private SwigDelegateOdCertificateObjectWinImpl_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdCertificateObjectWinImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdCertificateObjectWinImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdCertificateObjectWinImpl obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdCertificateObjectWinImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdCertificateObjectWinImpl(SWIGTYPE_p_PCCERT_CONTEXT pCertContext)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCertificateObjectWinImpl(SWIGTYPE_p_PCCERT_CONTEXT.getCPtr(pCertContext)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdCertificateObjectWinImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdCertificateDescription getCertDescription()
	{
		OdCertificateDescription result = new OdCertificateDescription(SwigDerivedClassHasMethod("getCertDescription", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdCertificateObjectWinImpl_getCertDescriptionSwigExplicitOdCertificateObjectWinImpl(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdCertificateObjectWinImpl_getCertDescription(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isTrusted()
	{
		bool result = (SwigDerivedClassHasMethod("isTrusted", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdCertificateObjectWinImpl_isTrustedSwigExplicitOdCertificateObjectWinImpl(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdCertificateObjectWinImpl_isTrusted(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public SWIGTYPE_p_PCCERT_CONTEXT getCertContext()
	{
		SWIGTYPE_p_PCCERT_CONTEXT result = new SWIGTYPE_p_PCCERT_CONTEXT(TD_RootIntegrated_GlobalsPINVOKE.OdCertificateObjectWinImpl_getCertContext(swigCPtr), futureUse: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getCertDescription", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetCertDescription;
		}
		if (SwigDerivedClassHasMethod("isTrusted", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisTrusted;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdCertificateObjectWinImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdCertificateObjectWinImpl));
	}

	private IntPtr SwigDirectorMethodgetCertDescription()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCertificateDescription.getCPtr(getCertDescription()).Handle;
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

	private bool SwigDirectorMethodisTrusted()
	{
		return isTrusted();
	}
}
