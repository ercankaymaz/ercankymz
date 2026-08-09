using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsNestedBackground : IDisposable
{
	public delegate void SwigDelegateOdGsNestedBackground_0(IntPtr view, IntPtr pDrawable, IntPtr pBackgroundTraits, IntPtr pdro);

	public delegate void SwigDelegateOdGsNestedBackground_1(IntPtr view, IntPtr pDrawable, IntPtr pBackgroundTraits);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGsNestedBackground_0 swigDelegate0;

	private SwigDelegateOdGsNestedBackground_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[4]
	{
		typeof(OdGsBaseVectorizer),
		typeof(OdGiDrawable),
		typeof(OdGiBackgroundTraitsData),
		typeof(OdGsPropertiesDirectRenderOutput)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(OdGsBaseVectorizer),
		typeof(OdGiDrawable),
		typeof(OdGiBackgroundTraitsData)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsNestedBackground(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsNestedBackground obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsNestedBackground()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsNestedBackground(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void nestedBackgroundDisplay(OdGsBaseVectorizer view, OdGiDrawable pDrawable, OdGiBackgroundTraitsData pBackgroundTraits, OdGsPropertiesDirectRenderOutput pdro)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsNestedBackground_nestedBackgroundDisplay__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGiDrawable.getCPtr(pDrawable), OdGiBackgroundTraitsData.getCPtr(pBackgroundTraits), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void nestedBackgroundDisplay(OdGsBaseVectorizer view, OdGiDrawable pDrawable, OdGiBackgroundTraitsData pBackgroundTraits)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsNestedBackground_nestedBackgroundDisplay__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGiDrawable.getCPtr(pDrawable), OdGiBackgroundTraitsData.getCPtr(pBackgroundTraits));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsNestedBackground()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsNestedBackground(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsNestedBackground) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("nestedBackgroundDisplay", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodnestedBackgroundDisplay__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("nestedBackgroundDisplay", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodnestedBackgroundDisplay__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsNestedBackground_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsNestedBackground));
	}

	private void SwigDirectorMethodnestedBackgroundDisplay__SWIG_0(IntPtr view, IntPtr pDrawable, IntPtr pBackgroundTraits, IntPtr pdro)
	{
		try
		{
			nestedBackgroundDisplay(new OdGsBaseVectorizer(view, cMemoryOwn: false), Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), (pBackgroundTraits == IntPtr.Zero) ? null : new OdGiBackgroundTraitsData(pBackgroundTraits, cMemoryOwn: false), (pdro == IntPtr.Zero) ? null : new OdGsPropertiesDirectRenderOutput(pdro, cMemoryOwn: false));
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

	private void SwigDirectorMethodnestedBackgroundDisplay__SWIG_1(IntPtr view, IntPtr pDrawable, IntPtr pBackgroundTraits)
	{
		try
		{
			nestedBackgroundDisplay(new OdGsBaseVectorizer(view, cMemoryOwn: false), Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), (pBackgroundTraits == IntPtr.Zero) ? null : new OdGiBackgroundTraitsData(pBackgroundTraits, cMemoryOwn: false));
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
