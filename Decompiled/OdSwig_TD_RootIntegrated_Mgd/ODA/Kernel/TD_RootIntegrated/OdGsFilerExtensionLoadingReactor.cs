using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerExtensionLoadingReactor : OdGsFilerExtension
{
	public delegate int SwigDelegateOdGsFilerExtensionLoadingReactor_0();

	public delegate void SwigDelegateOdGsFilerExtensionLoadingReactor_1(IntPtr pReactor);

	public delegate IntPtr SwigDelegateOdGsFilerExtensionLoadingReactor_2();

	public delegate bool SwigDelegateOdGsFilerExtensionLoadingReactor_3(IntPtr gsId, IntPtr pContext);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsFilerExtensionLoadingReactor_0 swigDelegate0;

	private SwigDelegateOdGsFilerExtensionLoadingReactor_1 swigDelegate1;

	private SwigDelegateOdGsFilerExtensionLoadingReactor_2 swigDelegate2;

	private SwigDelegateOdGsFilerExtensionLoadingReactor_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGsFilerLoadingReactor) };

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdGsFilerObjectId),
		typeof(IntPtr)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerExtensionLoadingReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerExtensionLoadingReactor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionLoadingReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGsFilerExtension_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_typeSwigExplicitOdGsFilerExtensionLoadingReactor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerExtension_Type)result;
	}

	public static OdGsFilerExtensionLoadingReactor cast(OdGsFilerExtension pExt)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_cast__SWIG_0(OdGsFilerExtension.getCPtr(pExt));
		OdGsFilerExtensionLoadingReactor result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionLoadingReactor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setupReactor(OdGsFilerLoadingReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_setupReactor(swigCPtr, OdGsFilerLoadingReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsFilerLoadingReactor reactor()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_reactor(swigCPtr);
		OdGsFilerLoadingReactor result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerLoadingReactor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadGsObject(OdGsFilerObjectId gsId, IntPtr pContext)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_loadGsObject(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pContext);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerExtensionLoadingReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerExtensionLoadingReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFilerExtensionLoadingReactor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("type", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("setupReactor", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetupReactor;
		}
		if (SwigDerivedClassHasMethod("reactor", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodreactor;
		}
		if (SwigDerivedClassHasMethod("loadGsObject", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodloadGsObject;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionLoadingReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFilerExtensionLoadingReactor));
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private void SwigDirectorMethodsetupReactor(IntPtr pReactor)
	{
		try
		{
			setupReactor((pReactor == IntPtr.Zero) ? null : new OdGsFilerLoadingReactor(pReactor, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodreactor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGsFilerLoadingReactor.getCPtr(reactor()).Handle;
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

	private bool SwigDirectorMethodloadGsObject(IntPtr gsId, IntPtr pContext)
	{
		return loadGsObject(new OdGsFilerObjectId(gsId, cMemoryOwn: false), pContext);
	}
}
