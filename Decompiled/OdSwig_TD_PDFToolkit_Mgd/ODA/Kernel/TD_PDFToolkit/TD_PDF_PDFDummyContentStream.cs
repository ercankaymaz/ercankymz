using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFDummyContentStream : TD_PDF_PDFIContentCommands
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFDummyContentStream(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFDummyContentStream obj)
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFDummyContentStream(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override void setTraits(double arg0, uint arg1, uint arg2, ushort arg3, ushort arg4, TD_PDF_PDFLineCap arg5, TD_PDF_PDFLineJoin arg6)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_setTraits(swigCPtr, arg0, arg1, arg2, arg3, arg4, (int)arg5, (int)arg6);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void getTraits(out double arg0, out uint arg1, out uint arg2, out ushort arg3, out ushort arg4, out TD_PDF_PDFLineCap arg5, out TD_PDF_PDFLineJoin arg6)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_getTraits(swigCPtr, out arg0, out arg1, out arg2, out arg3, out arg4, out arg5, out arg6);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Do(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Do(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void q()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_q(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Q()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Q(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void cm(double arg0, double arg1, double arg2, double arg3, double arg4, double arg5)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_cm(swigCPtr, arg0, arg1, arg2, arg3, arg4, arg5);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void w(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_w(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void J(TD_PDF_PDFLineCap arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_J(swigCPtr, (int)arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void d(TD_PDF_PDFArray arg0, uint arg1)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_d(swigCPtr, TD_PDF_PDFArray.getCPtr(arg0), arg1);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void j(TD_PDF_PDFLineJoin arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_j(swigCPtr, (int)arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void cs(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_cs(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void gs(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_gs(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void CS(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_CS(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void sc(byte arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_sc(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void SC(byte arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_SC(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void RG(double arg0, double arg1, double arg2)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_RG__SWIG_0(swigCPtr, arg0, arg1, arg2);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void rg(double arg0, double arg1, double arg2)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_rg__SWIG_0(swigCPtr, arg0, arg1, arg2);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void RG(uint arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_RG__SWIG_1(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void rg(uint arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_rg__SWIG_1(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void g(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_g(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void G(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_G(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void m(double arg0, double arg1, TD_PDF_CoordinatesProcessing arg2)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_m__SWIG_0(swigCPtr, arg0, arg1, (int)arg2);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void m(double arg0, double arg1)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_m__SWIG_1(swigCPtr, arg0, arg1);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void l(double arg0, double arg1, TD_PDF_CoordinatesProcessing arg2)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_l__SWIG_0(swigCPtr, arg0, arg1, (int)arg2);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void l(double arg0, double arg1)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_l__SWIG_1(swigCPtr, arg0, arg1);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void c(double arg0, double arg1, double arg2, double arg3, double arg4, double arg5, TD_PDF_CoordinatesProcessing arg6)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_c__SWIG_0(swigCPtr, arg0, arg1, arg2, arg3, arg4, arg5, (int)arg6);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void c(double arg0, double arg1, double arg2, double arg3, double arg4, double arg5)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_c__SWIG_1(swigCPtr, arg0, arg1, arg2, arg3, arg4, arg5);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void v(double arg0, double arg1, double arg2, double arg3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_v(swigCPtr, arg0, arg1, arg2, arg3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void y(double arg0, double arg1, double arg2, double arg3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_y(swigCPtr, arg0, arg1, arg2, arg3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void re(double arg0, double arg1, double arg2, double arg3)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_re(swigCPtr, arg0, arg1, arg2, arg3);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void h()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_h(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void S()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_S(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void s()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_s(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void f()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_f(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void f_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_f_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void B()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_B(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void B_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_B_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void b()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_b(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void b_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_b_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void n()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_n(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void W()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_W(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void W_odd()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_W_odd(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Tc(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Tc(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Tw(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Tw(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Tz(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Tz(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void TL(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_TL(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Tf(TD_PDF_PDFName arg0, double arg1)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Tf(swigCPtr, TD_PDF_PDFName.getCPtr(arg0), arg1);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Tr(uint arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Tr(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Ts(double arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Ts(swigCPtr, arg0);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void BT()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_BT(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void ET()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_ET(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Td(double arg0, double arg1)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Td(swigCPtr, arg0, arg1);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void TD(double arg0, double arg1)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_TD(swigCPtr, arg0, arg1);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Tm(double arg0, double arg1, double arg2, double arg3, double arg4, double arg5)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Tm(swigCPtr, arg0, arg1, arg2, arg3, arg4, arg5);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void T_star()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_T_star(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void Tj(TD_PDF_PDFTextString arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_Tj(swigCPtr, TD_PDF_PDFTextString.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void TJ(TD_PDF_PDFArray arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_TJ(swigCPtr, TD_PDF_PDFArray.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void BDC(TD_PDF_PDFName arg0, TD_PDF_PDFObject arg1)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_BDC(swigCPtr, TD_PDF_PDFName.getCPtr(arg0), TD_PDF_PDFObject.getCPtr(arg1));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void BMC(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_BMC(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void EMC()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_EMC(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void sh(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_sh(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void scn(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_scn(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void SCN(TD_PDF_PDFName arg0)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFDummyContentStream_SCN(swigCPtr, TD_PDF_PDFName.getCPtr(arg0));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_PDFDummyContentStream()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFDummyContentStream(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
