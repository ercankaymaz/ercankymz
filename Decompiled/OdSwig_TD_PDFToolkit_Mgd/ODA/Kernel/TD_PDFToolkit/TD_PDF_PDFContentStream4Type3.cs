using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFContentStream4Type3 : TD_PDF_PDFContentStream
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFContentStream4Type3(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFContentStream4Type3 obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFContentStream4Type3(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public new static TD_PDF_PDFContentStream4Type3 createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFContentStream4Type3 result = Helpers.GetObject<TD_PDF_PDFContentStream4Type3>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static TD_PDF_PDFContentStream4Type3 createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFContentStream4Type3 result = Helpers.GetObject<TD_PDF_PDFContentStream4Type3>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void d0(double wx, double wy)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_d0(swigCPtr, wx, wy);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void d1(double wx, double wy, double llx, double lly, double urx, double ury)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_d1(swigCPtr, wx, wy, llx, lly, urx, ury);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void m(double x, double y, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_m__SWIG_0(swigCPtr, x, y, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void m(double x, double y)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_m__SWIG_1(swigCPtr, x, y);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void l(double x, double y, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_l__SWIG_0(swigCPtr, x, y, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void l(double x, double y)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_l__SWIG_1(swigCPtr, x, y);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream4Type3_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
