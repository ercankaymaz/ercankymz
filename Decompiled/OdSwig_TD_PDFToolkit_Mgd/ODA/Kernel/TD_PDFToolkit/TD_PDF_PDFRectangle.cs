using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFRectangle : TD_PDF_PDFObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFRectangle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFRectangle obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFRectangle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public static TD_PDF_PDFRectangle createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFRectangle result = Helpers.GetObject<TD_PDF_PDFRectangle>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFRectangle createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFRectangle result = Helpers.GetObject<TD_PDF_PDFRectangle>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(int lx, int ly, int ux, int uy)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_set__SWIG_0(swigCPtr, lx, ly, ux, uy);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGeExtents2d extents2d)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_set__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(extents2d));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void get(out int lx, out int ly, out int ux, out int uy)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_get(swigCPtr, out lx, out ly, out ux, out uy);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool Export(TD_PDF_PDFIStream pStream, TD_PDF_PDFVersion ver)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_Export(swigCPtr, TD_PDF_PDFIStream.getCPtr(pStream), TD_PDF_PDFVersion.getCPtr(ver));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFRectangle_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
