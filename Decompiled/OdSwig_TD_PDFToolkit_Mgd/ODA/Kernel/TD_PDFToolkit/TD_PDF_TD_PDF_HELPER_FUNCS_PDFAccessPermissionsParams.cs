using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public bool AllowExtract
	{
		get
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowExtract_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowExtract_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool AllowAssemble
	{
		get
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAssemble_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAssemble_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool AllowAnnotateAndForm
	{
		get
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAnnotateAndForm_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAnnotateAndForm_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool AllowFormFilling
	{
		get
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowFormFilling_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowFormFilling_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool AllowModifyOther
	{
		get
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowModifyOther_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowModifyOther_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool AllowPrintAll
	{
		get
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintAll_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintAll_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool AllowPrintLow
	{
		get
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintLow_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintLow_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
