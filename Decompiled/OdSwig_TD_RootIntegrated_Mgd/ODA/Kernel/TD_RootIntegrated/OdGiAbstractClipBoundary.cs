using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiAbstractClipBoundary : IDisposable
{
	public delegate int SwigDelegateOdGiAbstractClipBoundary_0();

	public delegate IntPtr SwigDelegateOdGiAbstractClipBoundary_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiAbstractClipBoundary_0 swigDelegate0;

	private SwigDelegateOdGiAbstractClipBoundary_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiAbstractClipBoundary(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiAbstractClipBoundary obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiAbstractClipBoundary()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiAbstractClipBoundary(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiAbstractClipBoundary()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiAbstractClipBoundary(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiAbstractClipBoundary) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual OdGiAbstractClipBoundary_BoundaryType type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiAbstractClipBoundary_typeSwigExplicitOdGiAbstractClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiAbstractClipBoundary_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiAbstractClipBoundary_BoundaryType)result;
	}

	public virtual OdGiAbstractClipBoundary clone()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("clone", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiAbstractClipBoundary_cloneSwigExplicitOdGiAbstractClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiAbstractClipBoundary_clone(swigCPtr));
		OdGiAbstractClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("type", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("clone", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodclone;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiAbstractClipBoundary_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiAbstractClipBoundary));
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private IntPtr SwigDirectorMethodclone()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return getCPtr(clone()).Handle;
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
}
