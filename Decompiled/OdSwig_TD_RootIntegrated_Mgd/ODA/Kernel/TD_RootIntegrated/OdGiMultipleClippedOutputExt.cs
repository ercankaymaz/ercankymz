using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMultipleClippedOutputExt : IDisposable
{
	public delegate void SwigDelegateOdGiMultipleClippedOutputExt_0(int nClipClient);

	public delegate void SwigDelegateOdGiMultipleClippedOutputExt_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiMultipleClippedOutputExt_0 swigDelegate0;

	private SwigDelegateOdGiMultipleClippedOutputExt_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMultipleClippedOutputExt(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMultipleClippedOutputExt obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiMultipleClippedOutputExt()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMultipleClippedOutputExt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void selectClipOutput(int nClipClient)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultipleClippedOutputExt_selectClipOutput__SWIG_0(swigCPtr, nClipClient);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void selectClipOutput()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultipleClippedOutputExt_selectClipOutput__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMultipleClippedOutputExt()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMultipleClippedOutputExt(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMultipleClippedOutputExt) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("selectClipOutput", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodselectClipOutput__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("selectClipOutput", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodselectClipOutput__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultipleClippedOutputExt_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMultipleClippedOutputExt));
	}

	private void SwigDirectorMethodselectClipOutput__SWIG_0(int nClipClient)
	{
		try
		{
			selectClipOutput(nClipClient);
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

	private void SwigDirectorMethodselectClipOutput__SWIG_1()
	{
		try
		{
			selectClipOutput();
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
