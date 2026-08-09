using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerExtensionPointersRegistrator : OdGsFilerExtension
{
	public delegate int SwigDelegateOdGsFilerExtensionPointersRegistrator_0();

	public delegate void SwigDelegateOdGsFilerExtensionPointersRegistrator_1(IntPtr pPtr);

	public delegate void SwigDelegateOdGsFilerExtensionPointersRegistrator_2(IntPtr pPtr);

	public delegate bool SwigDelegateOdGsFilerExtensionPointersRegistrator_3(IntPtr pPtr);

	public delegate void SwigDelegateOdGsFilerExtensionPointersRegistrator_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsFilerExtensionPointersRegistrator_0 swigDelegate0;

	private SwigDelegateOdGsFilerExtensionPointersRegistrator_1 swigDelegate1;

	private SwigDelegateOdGsFilerExtensionPointersRegistrator_2 swigDelegate2;

	private SwigDelegateOdGsFilerExtensionPointersRegistrator_3 swigDelegate3;

	private SwigDelegateOdGsFilerExtensionPointersRegistrator_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerExtensionPointersRegistrator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerExtensionPointersRegistrator obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionPointersRegistrator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGsFilerExtension_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_typeSwigExplicitOdGsFilerExtensionPointersRegistrator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerExtension_Type)result;
	}

	public static OdGsFilerExtensionPointersRegistrator cast(OdGsFilerExtension pExt)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_cast__SWIG_0(OdGsFilerExtension.getCPtr(pExt));
		OdGsFilerExtensionPointersRegistrator result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionPointersRegistrator(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void registerPtr(IntPtr pPtr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_registerPtr(swigCPtr, pPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unregisterPtr(IntPtr pPtr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_unregisterPtr(swigCPtr, pPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isPtrRegistered(IntPtr pPtr)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_isPtrRegistered(swigCPtr, pPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearRegisteredPtrs()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_clearRegisteredPtrs(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerExtensionPointersRegistrator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerExtensionPointersRegistrator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFilerExtensionPointersRegistrator) != GetType();
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
		if (SwigDerivedClassHasMethod("registerPtr", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodregisterPtr;
		}
		if (SwigDerivedClassHasMethod("unregisterPtr", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodunregisterPtr;
		}
		if (SwigDerivedClassHasMethod("isPtrRegistered", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisPtrRegistered;
		}
		if (SwigDerivedClassHasMethod("clearRegisteredPtrs", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodclearRegisteredPtrs;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionPointersRegistrator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFilerExtensionPointersRegistrator));
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private void SwigDirectorMethodregisterPtr(IntPtr pPtr)
	{
		try
		{
			registerPtr(pPtr);
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

	private void SwigDirectorMethodunregisterPtr(IntPtr pPtr)
	{
		try
		{
			unregisterPtr(pPtr);
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

	private bool SwigDirectorMethodisPtrRegistered(IntPtr pPtr)
	{
		return isPtrRegistered(pPtr);
	}

	private void SwigDirectorMethodclearRegisteredPtrs()
	{
		try
		{
			clearRegisteredPtrs();
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
