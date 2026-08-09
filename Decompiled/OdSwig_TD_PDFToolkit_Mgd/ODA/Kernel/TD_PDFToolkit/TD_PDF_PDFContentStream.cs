using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFContentStream : TD_PDF_PDFStream
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFContentStream(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFContentStream obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFContentStream(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	public static TD_PDF_PDFContentStream createObject(TD_PDF_PDFDocument pDoc, bool isIndirect)
	{
		TD_PDF_PDFContentStream result = Helpers.GetObject<TD_PDF_PDFContentStream>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_createObject__SWIG_0(TD_PDF_PDFDocument.getCPtr(pDoc), isIndirect), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFContentStream createObject(TD_PDF_PDFDocument pDoc)
	{
		TD_PDF_PDFContentStream result = Helpers.GetObject<TD_PDF_PDFContentStream>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_createObject__SWIG_1(TD_PDF_PDFDocument.getCPtr(pDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTraits(double lw, uint rgb_s, uint rgb_ns, ushort ci_s, ushort ci_ns, TD_PDF_PDFLineCap capStyle, TD_PDF_PDFLineJoin joinStyle)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_setTraits(swigCPtr, lw, rgb_s, rgb_ns, ci_s, ci_ns, (int)capStyle, (int)joinStyle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getTraits(out double lw, out uint rgb_s, out uint rgb_ns, out ushort ci_s, out ushort ci_ns, out TD_PDF_PDFLineCap capStyle, out TD_PDF_PDFLineJoin joinStyle)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_getTraits(swigCPtr, out lw, out rgb_s, out rgb_ns, out ci_s, out ci_ns, out capStyle, out joinStyle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Do(TD_PDF_PDFName pName)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Do(swigCPtr, TD_PDF_PDFName.getCPtr(pName));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void q()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_q(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Q()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Q(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void gs(TD_PDF_PDFName pGS)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_gs(swigCPtr, TD_PDF_PDFName.getCPtr(pGS));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void cm(double a, double b, double c, double d, double e, double f)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_cm(swigCPtr, a, b, c, d, e, f);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void w(double lw)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_w(swigCPtr, lw);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void J(TD_PDF_PDFLineCap linecap)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_J(swigCPtr, (int)linecap);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void j(TD_PDF_PDFLineJoin linejoin)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_j(swigCPtr, (int)linejoin);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void d(TD_PDF_PDFArray dashArray, uint phase)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_d(swigCPtr, TD_PDF_PDFArray.getCPtr(dashArray), phase);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void cs(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_cs(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void CS(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_CS(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void sc(byte indx)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_sc(swigCPtr, indx);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void SC(byte indx)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_SC(swigCPtr, indx);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void RG(double r, double g, double b)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_RG__SWIG_0(swigCPtr, r, g, b);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rg(double r, double g, double b)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_rg__SWIG_0(swigCPtr, r, g, b);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void RG(uint rgb)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_RG__SWIG_1(swigCPtr, rgb);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rg(uint rgb)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_rg__SWIG_1(swigCPtr, rgb);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void g(double g)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_g(swigCPtr, g);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void G(double g)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_G(swigCPtr, g);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void scn(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_scn(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void SCN(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_SCN(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void m(double x, double y, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_m__SWIG_0(swigCPtr, x, y, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void m(double x, double y)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_m__SWIG_1(swigCPtr, x, y);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void l(double x, double y, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_l__SWIG_0(swigCPtr, x, y, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void l(double x, double y)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_l__SWIG_1(swigCPtr, x, y);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void c(double x1, double y1, double x2, double y2, double x3, double y3, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_c__SWIG_0(swigCPtr, x1, y1, x2, y2, x3, y3, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void c(double x1, double y1, double x2, double y2, double x3, double y3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_c__SWIG_1(swigCPtr, x1, y1, x2, y2, x3, y3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void v(double x2, double y2, double x3, double y3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_v(swigCPtr, x2, y2, x3, y3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void y(double x2, double y2, double x3, double y3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_y(swigCPtr, x2, y2, x3, y3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void re(double x, double y, double width, double height)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_re(swigCPtr, x, y, width, height);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void h()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_h(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void S()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_S(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void s()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_s(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void f()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_f(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void f_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_f_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void B()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_B(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void B_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_B_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void b()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_b(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void b_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_b_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void n()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_n(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void W()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_W(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void W_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_W_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tc(double charSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Tc(swigCPtr, charSpace);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tw(double wordSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Tw(swigCPtr, wordSpace);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tz(double scale)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Tz(swigCPtr, scale);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void TL(double leading)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_TL(swigCPtr, leading);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tf(TD_PDF_PDFName font, double size)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Tf(swigCPtr, TD_PDF_PDFName.getCPtr(font), size);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tr(uint render)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Tr(swigCPtr, render);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Ts(double rise)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Ts(swigCPtr, rise);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void BT()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_BT(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ET()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_ET(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Td(double tx, double ty)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Td(swigCPtr, tx, ty);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void TD(double tx, double ty)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_TD(swigCPtr, tx, ty);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tm(double a, double b, double c, double d, double e, double f)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Tm(swigCPtr, a, b, c, d, e, f);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void T_star()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_T_star(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tj(TD_PDF_PDFTextString pStr)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_Tj(swigCPtr, TD_PDF_PDFTextString.getCPtr(pStr));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void TJ(TD_PDF_PDFArray pStr)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_TJ(swigCPtr, TD_PDF_PDFArray.getCPtr(pStr));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void BDC(TD_PDF_PDFName pTag, TD_PDF_PDFObject pProperties)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_BDC(swigCPtr, TD_PDF_PDFName.getCPtr(pTag), TD_PDF_PDFObject.getCPtr(pProperties));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void BMC(TD_PDF_PDFName pTag)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_BMC(swigCPtr, TD_PDF_PDFName.getCPtr(pTag));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void EMC()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_EMC(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void sh(TD_PDF_PDFName pName)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_sh(swigCPtr, TD_PDF_PDFName.getCPtr(pName));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFContentStream_getRealClassName(ptr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
