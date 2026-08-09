using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFStreamTraits : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public double m_curLW
	{
		get
		{
			double result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curLW_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curLW_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_curRGB_strok
	{
		get
		{
			uint result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curRGB_strok_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curRGB_strok_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_curRGB_n_strok
	{
		get
		{
			uint result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curRGB_n_strok_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curRGB_n_strok_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort m_curCI_strok
	{
		get
		{
			ushort result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curCI_strok_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curCI_strok_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort m_curCI_n_strok
	{
		get
		{
			ushort result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curCI_n_strok_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curCI_n_strok_set(swigCPtr, value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_PDF_PDFLineCap m_curCapStyle
	{
		get
		{
			int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curCapStyle_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (TD_PDF_PDFLineCap)result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curCapStyle_set(swigCPtr, (int)value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_PDF_PDFLineJoin m_curJoinStyle
	{
		get
		{
			int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curJoinStyle_get(swigCPtr);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (TD_PDF_PDFLineJoin)result;
		}
		set
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFStreamTraits_m_curJoinStyle_set(swigCPtr, (int)value);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFStreamTraits(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFStreamTraits obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFStreamTraits()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFStreamTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_PDFStreamTraits()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFStreamTraits__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_PDFStreamTraits(double lw, uint rgb_s, uint rgb_ns, ushort ci_s, ushort ci_ns, TD_PDF_PDFLineCap capStyle, TD_PDF_PDFLineJoin joinStyle)
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFStreamTraits__SWIG_1(lw, rgb_s, rgb_ns, ci_s, ci_ns, (int)capStyle, (int)joinStyle), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
