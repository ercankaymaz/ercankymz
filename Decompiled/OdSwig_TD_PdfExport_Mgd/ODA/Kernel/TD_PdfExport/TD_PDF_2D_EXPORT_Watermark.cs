using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class TD_PDF_2D_EXPORT_Watermark : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public string text
	{
		get
		{
			string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_text_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_text_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint color
	{
		get
		{
			uint result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_color_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_color_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort fontSize
	{
		get
		{
			ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_fontSize_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_fontSize_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort opacity
	{
		get
		{
			ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_opacity_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_opacity_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_PDF_2D_EXPORT_Watermark_WatermarkFonts font
	{
		get
		{
			int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_font_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (TD_PDF_2D_EXPORT_Watermark_WatermarkFonts)result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_font_set(swigCPtr, (int)value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public TD_PDF_2D_EXPORT_Watermark_WatermarkPosition position
	{
		get
		{
			int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_position_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (TD_PDF_2D_EXPORT_Watermark_WatermarkPosition)result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_position_set(swigCPtr, (int)value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool scaleToPage
	{
		get
		{
			bool result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_scaleToPage_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_scaleToPage_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGePoint2d offset
	{
		get
		{
			IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_offset_get(swigCPtr);
			OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_offset_set(swigCPtr, OdGePoint2d.getCPtr(value));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double rotation
	{
		get
		{
			double result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_rotation_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_rotation_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int pageIndex
	{
		get
		{
			int result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_pageIndex_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_pageIndex_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public string fontName
	{
		get
		{
			string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_fontName_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_fontName_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public string imagePath
	{
		get
		{
			string result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_imagePath_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_imagePath_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort imageWidth
	{
		get
		{
			ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_imageWidth_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_imageWidth_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort imageHeight
	{
		get
		{
			ushort result = TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_imageHeight_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.TD_PDF_2D_EXPORT_Watermark_imageHeight_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_2D_EXPORT_Watermark(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_2D_EXPORT_Watermark obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_2D_EXPORT_Watermark()
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
					TD_PdfExport_GlobalsPINVOKE.delete_TD_PDF_2D_EXPORT_Watermark(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public TD_PDF_2D_EXPORT_Watermark()
		: this(TD_PdfExport_GlobalsPINVOKE.new_TD_PDF_2D_EXPORT_Watermark(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
