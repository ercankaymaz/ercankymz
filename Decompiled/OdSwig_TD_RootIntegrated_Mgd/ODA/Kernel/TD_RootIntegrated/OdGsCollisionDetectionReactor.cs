using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCollisionDetectionReactor : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public const uint kNotImplemented = 2147483648u;

	public const int kContinue = 0;

	public const int kBreak = 1;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCollisionDetectionReactor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCollisionDetectionReactor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsCollisionDetectionReactor()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCollisionDetectionReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual uint collisionDetected(OdGiPathNode arg0, OdGiPathNode arg1)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionReactor_collisionDetected__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(arg0), OdGiPathNode.getCPtr(arg1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint collisionDetected(OdGiPathNode pPathNode1, OdGiPathNode pPathNode2, double arg2)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionReactor_collisionDetected__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(pPathNode1), OdGiPathNode.getCPtr(pPathNode2), arg2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsCollisionDetectionReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCollisionDetectionReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
