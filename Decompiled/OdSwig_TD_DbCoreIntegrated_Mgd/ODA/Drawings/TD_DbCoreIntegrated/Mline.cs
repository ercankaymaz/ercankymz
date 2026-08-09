using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class Mline : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public const int kTop = 0;

	public const int kZero = 1;

	public const int kBottom = 2;

	public const int kOpen = 0;

	public const int kClosed = 1;

	public const int kMerged = 2;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public Mline(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(Mline obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~Mline()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_Mline(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public Mline()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_Mline(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
