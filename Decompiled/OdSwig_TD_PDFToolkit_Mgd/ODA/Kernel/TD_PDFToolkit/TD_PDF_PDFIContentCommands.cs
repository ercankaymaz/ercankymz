using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFIContentCommands : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFIContentCommands(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFIContentCommands obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFIContentCommands()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFIContentCommands(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void setTraits(double lw, uint rgb_s, uint rgb_ns, ushort ci_s, ushort ci_ns, TD_PDF_PDFLineCap capStyle, TD_PDF_PDFLineJoin joinStyle)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_setTraits(swigCPtr, lw, rgb_s, rgb_ns, ci_s, ci_ns, (int)capStyle, (int)joinStyle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getTraits(out double lw, out uint rgb_s, out uint rgb_ns, out ushort ci_s, out ushort ci_ns, out TD_PDF_PDFLineCap capStyle, out TD_PDF_PDFLineJoin joinStyle)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_getTraits(swigCPtr, out lw, out rgb_s, out rgb_ns, out ci_s, out ci_ns, out capStyle, out joinStyle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Do(TD_PDF_PDFName pName)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Do(swigCPtr, TD_PDF_PDFName.getCPtr(pName));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void q()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_q(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Q()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Q(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void gs(TD_PDF_PDFName pGS)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_gs(swigCPtr, TD_PDF_PDFName.getCPtr(pGS));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void cm(double a, double b, double c, double d, double e, double f)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_cm(swigCPtr, a, b, c, d, e, f);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void w(double lw)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_w(swigCPtr, lw);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void J(TD_PDF_PDFLineCap linecap)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_J(swigCPtr, (int)linecap);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void j(TD_PDF_PDFLineJoin linejoin)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_j(swigCPtr, (int)linejoin);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void d(TD_PDF_PDFArray dashPattern, uint dashPhase)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_d(swigCPtr, TD_PDF_PDFArray.getCPtr(dashPattern), dashPhase);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void cs(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_cs(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void CS(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_CS(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void sc(byte indx)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_sc(swigCPtr, indx);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void SC(byte indx)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_SC(swigCPtr, indx);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void RG(double r, double g, double b)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_RG__SWIG_0(swigCPtr, r, g, b);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rg(double r, double g, double b)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_rg__SWIG_0(swigCPtr, r, g, b);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void RG(uint rgb)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_RG__SWIG_1(swigCPtr, rgb);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rg(uint rgb)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_rg__SWIG_1(swigCPtr, rgb);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void g(double g)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_g(swigCPtr, g);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void G(double g)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_G(swigCPtr, g);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void scn(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_scn(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void SCN(TD_PDF_PDFName pColorSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_SCN(swigCPtr, TD_PDF_PDFName.getCPtr(pColorSpace));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void m(double x, double y, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_m__SWIG_0(swigCPtr, x, y, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void m(double x, double y)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_m__SWIG_1(swigCPtr, x, y);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void l(double x, double y, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_l__SWIG_0(swigCPtr, x, y, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void l(double x, double y)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_l__SWIG_1(swigCPtr, x, y);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void c(double x1, double y1, double x2, double y2, double x3, double y3, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_c__SWIG_0(swigCPtr, x1, y1, x2, y2, x3, y3, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void c(double x1, double y1, double x2, double y2, double x3, double y3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_c__SWIG_1(swigCPtr, x1, y1, x2, y2, x3, y3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void v(double x2, double y2, double x3, double y3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_v__SWIG_0(swigCPtr, x2, y2, x3, y3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void y(double x2, double y2, double x3, double y3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_y__SWIG_0(swigCPtr, x2, y2, x3, y3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void m(OdGePoint2d xy, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_m__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(xy), (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void m(OdGePoint2d xy)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_m__SWIG_3(swigCPtr, OdGePoint2d.getCPtr(xy));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void l(OdGePoint2d xy, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_l__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(xy), (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void l(OdGePoint2d xy)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_l__SWIG_3(swigCPtr, OdGePoint2d.getCPtr(xy));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void c(OdGePoint2d xy1, OdGePoint2d xy2, OdGePoint2d xy3, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_c__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(xy1), OdGePoint2d.getCPtr(xy2), OdGePoint2d.getCPtr(xy3), (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void c(OdGePoint2d xy1, OdGePoint2d xy2, OdGePoint2d xy3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_c__SWIG_3(swigCPtr, OdGePoint2d.getCPtr(xy1), OdGePoint2d.getCPtr(xy2), OdGePoint2d.getCPtr(xy3));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void v(OdGePoint2d xy2, OdGePoint2d xy3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_v__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(xy2), OdGePoint2d.getCPtr(xy3));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void y(OdGePoint2d xy2, OdGePoint2d xy3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_y__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(xy2), OdGePoint2d.getCPtr(xy3));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void re(double x, double y, double width, double height)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_re(swigCPtr, x, y, width, height);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void h()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_h(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void S()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_S(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void s()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_s(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void f()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_f(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void f_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_f_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void B()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_B(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void B_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_B_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void b()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_b(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void b_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_b_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void n()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_n(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void W()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_W(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void W_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_W_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tc(double charSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Tc(swigCPtr, charSpace);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tw(double wordSpace)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Tw(swigCPtr, wordSpace);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tz(double scale)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Tz(swigCPtr, scale);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void TL(double leading)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_TL(swigCPtr, leading);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tf(TD_PDF_PDFName font, double size)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Tf(swigCPtr, TD_PDF_PDFName.getCPtr(font), size);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tr(uint render)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Tr(swigCPtr, render);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Ts(double rise)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Ts(swigCPtr, rise);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void BT()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_BT(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void ET()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_ET(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Td(double tx, double ty)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Td(swigCPtr, tx, ty);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void TD(double tx, double ty)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_TD(swigCPtr, tx, ty);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tm(double a, double b, double c, double d, double e, double f)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Tm(swigCPtr, a, b, c, d, e, f);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void T_star()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_T_star(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void Tj(TD_PDF_PDFTextString pStr)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_Tj(swigCPtr, TD_PDF_PDFTextString.getCPtr(pStr));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void TJ(TD_PDF_PDFArray pStr)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_TJ(swigCPtr, TD_PDF_PDFArray.getCPtr(pStr));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void BDC(TD_PDF_PDFName pTag, TD_PDF_PDFObject pProperties)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_BDC(swigCPtr, TD_PDF_PDFName.getCPtr(pTag), TD_PDF_PDFObject.getCPtr(pProperties));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void BMC(TD_PDF_PDFName pTag)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_BMC(swigCPtr, TD_PDF_PDFName.getCPtr(pTag));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void EMC()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_EMC(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void sh(TD_PDF_PDFName pName)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_sh(swigCPtr, TD_PDF_PDFName.getCPtr(pName));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawEllipse(TD_PDF_PDFIContentCommands pICommands, OdGeEllipArc2d ellipArc2d, bool bSkipFirstPoint, double deviation, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawEllipse__SWIG_0(getCPtr(pICommands), OdGeEllipArc2d.getCPtr(ellipArc2d), bSkipFirstPoint, deviation, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawEllipse(TD_PDF_PDFIContentCommands pICommands, OdGeEllipArc2d ellipArc2d, bool bSkipFirstPoint, double deviation)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawEllipse__SWIG_1(getCPtr(pICommands), OdGeEllipArc2d.getCPtr(ellipArc2d), bSkipFirstPoint, deviation);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawEllipse(TD_PDF_PDFIContentCommands pICommands, OdGeEllipArc2d ellipArc2d, bool bSkipFirstPoint)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawEllipse__SWIG_2(getCPtr(pICommands), OdGeEllipArc2d.getCPtr(ellipArc2d), bSkipFirstPoint);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawEllipse(TD_PDF_PDFIContentCommands pICommands, OdGeEllipArc2d ellipArc2d)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawEllipse__SWIG_3(getCPtr(pICommands), OdGeEllipArc2d.getCPtr(ellipArc2d));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawPolyline(TD_PDF_PDFIContentCommands pICommands, uint nPoints, OdGePoint2d pPoints, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawPolyline__SWIG_0(getCPtr(pICommands), nPoints, OdGePoint2d.getCPtr(pPoints), (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawPolyline(TD_PDF_PDFIContentCommands pICommands, uint nPoints, OdGePoint2d pPoints)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawPolyline__SWIG_1(getCPtr(pICommands), nPoints, OdGePoint2d.getCPtr(pPoints));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawPolyline(TD_PDF_PDFIContentCommands pICommands, OdGePoint2dArray pnts2d, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawPolyline__SWIG_2(getCPtr(pICommands), OdGePoint2dArray.getCPtr(pnts2d).Handle, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawPolyline(TD_PDF_PDFIContentCommands pICommands, OdGePoint2dArray pnts2d)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawPolyline__SWIG_3(getCPtr(pICommands), OdGePoint2dArray.getCPtr(pnts2d).Handle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawCurve(TD_PDF_PDFIContentCommands pICommands, OdGeCurve2d pCurve, double deviation, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawCurve__SWIG_0(getCPtr(pICommands), OdGeCurve2d.getCPtr(pCurve), deviation, (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawCurve(TD_PDF_PDFIContentCommands pICommands, OdGeCurve2d pCurve, double deviation)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawCurve__SWIG_1(getCPtr(pICommands), OdGeCurve2d.getCPtr(pCurve), deviation);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawCurve(TD_PDF_PDFIContentCommands pICommands, OdGeCurve2d pCurve)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawCurve__SWIG_2(getCPtr(pICommands), OdGeCurve2d.getCPtr(pCurve));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawPoint(TD_PDF_PDFIContentCommands pICommands, OdGePoint2d pPoint2d, TD_PDF_CoordinatesProcessing coordProc)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawPoint__SWIG_0(getCPtr(pICommands), OdGePoint2d.getCPtr(pPoint2d), (int)coordProc);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void drawPoint(TD_PDF_PDFIContentCommands pICommands, OdGePoint2d pPoint2d)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands_drawPoint__SWIG_1(getCPtr(pICommands), OdGePoint2d.getCPtr(pPoint2d));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
