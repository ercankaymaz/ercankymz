using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdMTLoadReactor : IDisposable
{
	public delegate bool SwigDelegateOdMTLoadReactor_0();

	public delegate void SwigDelegateOdMTLoadReactor_1(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdMTLoadReactor_2();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdMTLoadReactor_0 swigDelegate0;

	private SwigDelegateOdMTLoadReactor_1 swigDelegate1;

	private SwigDelegateOdMTLoadReactor_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes2 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdMTLoadReactor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdMTLoadReactor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdMTLoadReactor()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdMTLoadReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool shouldInterrupt()
	{
		bool result = (SwigDerivedClassHasMethod("shouldInterrupt", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdMTLoadReactor_shouldInterruptSwigExplicitOdMTLoadReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdMTLoadReactor_shouldInterrupt(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void insertDetected(OdDbObjectId arg0)
	{
		if (SwigDerivedClassHasMethod("insertDetected", swigMethodTypes1))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdMTLoadReactor_insertDetectedSwigExplicitOdMTLoadReactor(swigCPtr, OdDbObjectId.getCPtr(arg0));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdMTLoadReactor_insertDetected(swigCPtr, OdDbObjectId.getCPtr(arg0));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdMutex accessMutex()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("accessMutex", swigMethodTypes2) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdMTLoadReactor_accessMutexSwigExplicitOdMTLoadReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdMTLoadReactor_accessMutex(swigCPtr));
		OdMutex result = ((intPtr == IntPtr.Zero) ? null : new OdMutex(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdMTLoadReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdMTLoadReactor(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdMTLoadReactor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("shouldInterrupt", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodshouldInterrupt;
		}
		if (SwigDerivedClassHasMethod("insertDetected", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodinsertDetected;
		}
		if (SwigDerivedClassHasMethod("accessMutex", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodaccessMutex;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMTLoadReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdMTLoadReactor));
	}

	private bool SwigDirectorMethodshouldInterrupt()
	{
		return shouldInterrupt();
	}

	private void SwigDirectorMethodinsertDetected(IntPtr arg0)
	{
		try
		{
			insertDetected(new OdDbObjectId(arg0, cMemoryOwn: true));
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

	private IntPtr SwigDirectorMethodaccessMutex()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdMutex.getCPtr(accessMutex()).Handle;
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
}
