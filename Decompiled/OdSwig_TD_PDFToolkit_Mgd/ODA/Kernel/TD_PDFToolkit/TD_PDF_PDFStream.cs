using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFStream : TD_PDF_PDFObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFStream(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFStream obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFStream(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public override bool Export(TD_PDF_PDFIStream pStream, TD_PDF_PDFVersion ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_Export(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getLength()
	{
		uint result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_getLength(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool AddFilter(string pFilterName, TD_PDF_PDFDecodeParametersDictionary pDecodeParams)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_AddFilter(swigCPtr, pFilterName, TD_PDF_PDFDecodeParametersDictionary.getCPtr(pDecodeParams));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool RemoveFilter(string pFilterName)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_RemoveFilter(swigCPtr, pFilterName);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getNumberOfFilters()
	{
		uint result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_getNumberOfFilters(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getFilterAt(uint nIndx, ref string pFilterName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pFilterName);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_getFilterAt(swigCPtr, nIndx, ref jarg);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pFilterName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getDecodeParamsAt(uint nIndx, ref TD_PDF_PDFDecodeParametersDictionary pDecodeParams)
	{
		IntPtr jarg = ((pDecodeParams == null) ? IntPtr.Zero : TD_PDF_PDFDecodeParametersDictionary.getCPtr(pDecodeParams).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_getDecodeParamsAt(swigCPtr, nIndx, ref jarg);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pDecodeParams = null;
			}
			else if (jarg != intPtr)
			{
				pDecodeParams = Helpers.GetObject<TD_PDF_PDFDecodeParametersDictionary>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStream_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
