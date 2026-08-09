using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsSelectionReactor : IDisposable
{
	public delegate bool SwigDelegateOdGsSelectionReactor_0(IntPtr pDrawableDesc);

	public delegate uint SwigDelegateOdGsSelectionReactor_1(IntPtr arg0, IntPtr arg1);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public const uint kNotImplemented = 2147483648u;

	private SwigDelegateOdGsSelectionReactor_0 swigDelegate0;

	private SwigDelegateOdGsSelectionReactor_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdGiDrawableDesc) };

	private static Type[] swigMethodTypes1 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(OdGiViewport)
	};

	public const int kContinue = 0;

	public const int kBreak = 1;

	public const int kSkipDrawable = 2;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsSelectionReactor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsSelectionReactor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsSelectionReactor()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsSelectionReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool selected(OdGiDrawableDesc pDrawableDesc)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsSelectionReactor_selected__SWIG_0(swigCPtr, OdGiDrawableDesc.getCPtr(pDrawableDesc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint selected(OdGiPathNode arg0, OdGiViewport arg1)
	{
		uint result = (SwigDerivedClassHasMethod("selected", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsSelectionReactor_selectedSwigExplicitOdGsSelectionReactor__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(arg0), OdGiViewport.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsSelectionReactor_selected__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(arg0), OdGiViewport.getCPtr(arg1)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsSelectionReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsSelectionReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsSelectionReactor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("selected", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodselected__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("selected", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodselected__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsSelectionReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsSelectionReactor));
	}

	private bool SwigDirectorMethodselected__SWIG_0(IntPtr pDrawableDesc)
	{
		return selected(new OdGiDrawableDesc(pDrawableDesc, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodselected__SWIG_1(IntPtr arg0, IntPtr arg1)
	{
		return selected(new OdGiPathNode(arg0, cMemoryOwn: false), Helpers.GetRXObject<OdGiViewport>(arg1, bOwn: false, bTryAddToTransaction: false));
	}
}
