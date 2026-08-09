using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdTtfDescriptor : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdTtfDescriptor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdTtfDescriptor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdTtfDescriptor()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdTtfDescriptor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdTtfDescriptor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTtfDescriptor__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdTtfDescriptor(string typeface, bool bold, bool italic, int charset, int pitchAndFamily)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTtfDescriptor__SWIG_1(typeface, bold, italic, charset, pitchAndFamily), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string fileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_fileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string typeface()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_typeface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearFileName()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_clearFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearTypeface()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_clearTypeface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addTypeface(char typeface)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_addTypeface(swigCPtr, typeface);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFileName(string filename)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setFileName(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTypeFace(string typeface)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setTypeFace(swigCPtr, typeface);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTtfFlags(uint flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setTtfFlags__SWIG_0(swigCPtr, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTtfFlags(bool bold, bool italic, int charset, int pitchAndFamily)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setTtfFlags__SWIG_1(swigCPtr, bold, italic, charset, pitchAndFamily);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBold(bool bold)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setBold(swigCPtr, bold);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setItalic(bool italic)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setItalic(swigCPtr, italic);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPseudoBold(bool bold)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setPseudoBold(swigCPtr, bold);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPseudoItalic(bool italic)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setPseudoItalic(swigCPtr, italic);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCharSet(int charset)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setCharSet(swigCPtr, charset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPitchAndFamily(int pitchAndFamily)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setPitchAndFamily(swigCPtr, pitchAndFamily);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isBold()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_isBold(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isItalic()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_isItalic(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPseudoBold()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_isPseudoBold(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPseudoItalic()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_isPseudoItalic(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort charSet()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_charSet(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int pitchAndFamily()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_pitchAndFamily(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getPitch()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_getPitch(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getFamily()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_getFamily(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public TextRenderingMode textRenderingMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_textRenderingMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TextRenderingMode)result;
	}

	public void setTextRenderingMode(TextRenderingMode renderingMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTtfDescriptor_setTextRenderingMode(swigCPtr, (int)renderingMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
