using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFCharPair : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public ushort nCharCode
	{
		get
		{
			ushort result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFCharPair_nCharCode_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFCharPair_nCharCode_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort nUnicodeCode
	{
		get
		{
			ushort result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFCharPair_nUnicodeCode_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFCharPair_nUnicodeCode_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFCharPair(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFCharPair obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFCharPair()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFCharPair(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_PDFCharPair()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFCharPair(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(TD_PDF_PDFCharPair otherPair)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFCharPair_IsEqual(swigCPtr, getCPtr(otherPair));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(TD_PDF_PDFCharPair otherPair)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFCharPair_IsNotEqual(swigCPtr, getCPtr(otherPair));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
