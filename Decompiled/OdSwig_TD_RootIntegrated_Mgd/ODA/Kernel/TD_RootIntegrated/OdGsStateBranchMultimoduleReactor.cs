using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsStateBranchMultimoduleReactor : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsStateBranchMultimoduleReactor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsStateBranchMultimoduleReactor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsStateBranchMultimoduleReactor()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsStateBranchMultimoduleReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static void attach(OdGsStateBranch pStateBranch, IntPtr pModule, OdGsStateBranchReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchMultimoduleReactor_attach(OdGsStateBranch.getCPtr(pStateBranch), pModule, OdGsStateBranchReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void detach(OdGsStateBranch pStateBranch, IntPtr pModule)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchMultimoduleReactor_detach(OdGsStateBranch.getCPtr(pStateBranch), pModule);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGsStateBranchReactor getReactor(OdGsStateBranch pStateBranch, IntPtr pModule)
	{
		OdGsStateBranchReactor rXObject = Helpers.GetRXObject<OdGsStateBranchReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchMultimoduleReactor_getReactor(OdGsStateBranch.getCPtr(pStateBranch), pModule), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void setReactor(OdGsStateBranch pStateBranch, IntPtr pModule, OdGsStateBranchReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchMultimoduleReactor_setReactor(OdGsStateBranch.getCPtr(pStateBranch), pModule, OdGsStateBranchReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsStateBranchMultimoduleReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsStateBranchMultimoduleReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
