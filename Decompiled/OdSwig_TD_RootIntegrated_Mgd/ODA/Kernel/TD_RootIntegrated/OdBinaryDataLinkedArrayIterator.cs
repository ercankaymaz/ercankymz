using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBinaryDataLinkedArrayIterator : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBinaryDataLinkedArrayIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBinaryDataLinkedArrayIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBinaryDataLinkedArrayIterator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBinaryDataLinkedArrayIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdBinaryDataLinkedArrayIterator Previous()
	{
		OdBinaryDataLinkedArrayIterator result = new OdBinaryDataLinkedArrayIterator(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArrayIterator_Previous(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryDataLinkedArrayIterator Next()
	{
		OdBinaryDataLinkedArrayIterator result = new OdBinaryDataLinkedArrayIterator(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArrayIterator_Next(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryData Value()
	{
		OdBinaryData result = new OdBinaryData(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArrayIterator_Value(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetValue(OdBinaryData val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArrayIterator_SetValue(swigCPtr, OdBinaryData.getCPtr(val).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBinaryDataLinkedArrayIterator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBinaryDataLinkedArrayIterator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
