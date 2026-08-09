using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiHLRContext : IDisposable
{
	public delegate void SwigDelegateOdGiHLRContext_0(IntPtr arg0);

	public delegate void SwigDelegateOdGiHLRContext_1();

	public delegate void SwigDelegateOdGiHLRContext_2();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiHLRContext_0 swigDelegate0;

	private SwigDelegateOdGiHLRContext_1 swigDelegate1;

	private SwigDelegateOdGiHLRContext_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiHLRContext(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiHLRContext obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiHLRContext()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiHLRContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void getObscuredColor(OdCmEntityColor arg0)
	{
		if (SwigDerivedClassHasMethod("getObscuredColor", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRContext_getObscuredColorSwigExplicitOdGiHLRContext(swigCPtr, OdCmEntityColor.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRContext_getObscuredColor(swigCPtr, OdCmEntityColor.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginHiddenOutput()
	{
		if (SwigDerivedClassHasMethod("beginHiddenOutput", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRContext_beginHiddenOutputSwigExplicitOdGiHLRContext(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRContext_beginHiddenOutput(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endHiddenOutput()
	{
		if (SwigDerivedClassHasMethod("endHiddenOutput", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRContext_endHiddenOutputSwigExplicitOdGiHLRContext(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRContext_endHiddenOutput(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiHLRContext()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiHLRContext(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiHLRContext) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getObscuredColor", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetObscuredColor;
		}
		if (SwigDerivedClassHasMethod("beginHiddenOutput", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodbeginHiddenOutput;
		}
		if (SwigDerivedClassHasMethod("endHiddenOutput", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodendHiddenOutput;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHLRContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiHLRContext));
	}

	private void SwigDirectorMethodgetObscuredColor(IntPtr arg0)
	{
		try
		{
			getObscuredColor(new OdCmEntityColor(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodbeginHiddenOutput()
	{
		try
		{
			beginHiddenOutput();
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

	private void SwigDirectorMethodendHiddenOutput()
	{
		try
		{
			endHiddenOutput();
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
