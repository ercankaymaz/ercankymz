using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiExtendedClipBoundary : OdGiAbstractClipBoundary
{
	public delegate int SwigDelegateOdGiExtendedClipBoundary_0();

	public delegate IntPtr SwigDelegateOdGiExtendedClipBoundary_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiExtendedClipBoundary_0 swigDelegate0;

	private SwigDelegateOdGiExtendedClipBoundary_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiExtendedClipBoundary(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiExtendedClipBoundary obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiExtendedClipBoundary(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiExtendedClipBoundary()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiExtendedClipBoundary(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiExtendedClipBoundary) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdGiAbstractClipBoundary_BoundaryType type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_typeSwigExplicitOdGiExtendedClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiAbstractClipBoundary_BoundaryType)result;
	}

	public OdIntArray clipBoundaryCounts()
	{
		OdIntArray result = new OdIntArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_clipBoundaryCounts(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClipBoundaryCounts(OdIntArray pCounts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_setClipBoundaryCounts(swigCPtr, OdIntArray.getCPtr(pCounts).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2dArray clipBoundaryPoints()
	{
		OdGePoint2dArray result = new OdGePoint2dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_clipBoundaryPoints(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClipBoundaryPoints(OdGePoint2dArray pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_setClipBoundaryPoints(swigCPtr, OdGePoint2dArray.getCPtr(pPoints).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiAbstractClipBoundary clone()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("clone", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_cloneSwigExplicitOdGiExtendedClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_clone(swigCPtr));
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtendedClipBoundary_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiExtendedClipBoundary));
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
