using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMultiClipBoundary : OdGiAbstractClipBoundary
{
	public delegate int SwigDelegateOdGiMultiClipBoundary_0();

	public delegate IntPtr SwigDelegateOdGiMultiClipBoundary_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMultiClipBoundary_0 swigDelegate0;

	private SwigDelegateOdGiMultiClipBoundary_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMultiClipBoundary(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMultiClipBoundary obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMultiClipBoundary(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiMultiClipBoundary()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMultiClipBoundary(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMultiClipBoundary) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdGiAbstractClipBoundary_BoundaryType type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_typeSwigExplicitOdGiMultiClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiAbstractClipBoundary_BoundaryType)result;
	}

	public OdGiMultiClipBoundary_AbstractClipBoundaryArray clipBoundaries()
	{
		OdGiMultiClipBoundary_AbstractClipBoundaryArray result = new OdGiMultiClipBoundary_AbstractClipBoundaryArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_clipBoundaries(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClipBoundaries(OdGiMultiClipBoundary_AbstractClipBoundaryArray pClipBoundaries)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_setClipBoundaries(swigCPtr, OdGiMultiClipBoundary_AbstractClipBoundaryArray.getCPtr(pClipBoundaries));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiAbstractClipBoundary clone()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("clone", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_cloneSwigExplicitOdGiMultiClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_clone(swigCPtr));
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMultiClipBoundary));
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
				return OdGiAbstractClipBoundary.getCPtr(clone()).Handle;
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
