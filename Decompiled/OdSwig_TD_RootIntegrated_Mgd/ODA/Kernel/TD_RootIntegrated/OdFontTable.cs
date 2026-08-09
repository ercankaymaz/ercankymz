using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdFontTable : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFontTable(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFontTable obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdFontTable()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdFontTable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdFontTable fontTable()
	{
		OdFontTable rXObject = Helpers.GetRXObject<OdFontTable>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_fontTable(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void init()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_init();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void uninit()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_uninit();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFont defaultFont()
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_defaultFont(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFont defaultGdtFont()
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_defaultGdtFont(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFont defaultShapeFont()
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_defaultShapeFont(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void setDefaultShxFont(OdFont pFont)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_setDefaultShxFont(OdFont.getCPtr(pFont));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setDefaultGdtFont(OdFont pFont)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_setDefaultGdtFont(OdFont.getCPtr(pFont));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdFont getFont(string fileName)
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_getFont__SWIG_0(fileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFont getFont(OdTtfDescriptor descr, string fileName)
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_getFont__SWIG_1(OdTtfDescriptor.getCPtr(descr), fileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static string getFontKey(OdTtfDescriptor descr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_getFontKey(OdTtfDescriptor.getCPtr(descr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdFont getFontByKey(string fontKey, ref string fileName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fileName);
		IntPtr intPtr = jarg;
		try
		{
			OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_getFontByKey(fontKey, ref jarg), bOwn: true, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg != intPtr)
			{
				fileName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdFont getFontAt(uint nPos)
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_getFontAt(nPos), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void removeFontAt(uint nPos)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_removeFontAt(nPos);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void addFontByKey(string fontKey, OdFont pFont, string fileName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_addFontByKey(fontKey, OdFont.getCPtr(pFont), fileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFontTable_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
