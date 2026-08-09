using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class OdPrcFontKeysSameFont : IDisposable
{
	public class FontKey : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public int font_size
		{
			get
			{
				int result = OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_FontKey_font_size_get(swigCPtr);
				if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_FontKey_font_size_set(swigCPtr, value);
				if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte attributes
		{
			get
			{
				byte result = OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_FontKey_attributes_get(swigCPtr);
				if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_FontKey_attributes_set(swigCPtr, value);
				if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FontKey(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(FontKey obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~FontKey()
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
						OdPrcModule_GlobalsPINVOKE.delete_OdPrcFontKeysSameFont_FontKey(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public FontKey()
			: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFontKeysSameFont_FontKey(), cMemoryOwn: true)
		{
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcFontKeysSameFont(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcFontKeysSameFont obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcFontKeysSameFont()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcFontKeysSameFont(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcFontKeysSameFont()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFontKeysSameFont(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdPrcFontKeysSameFont_FontKey_OdObjectsAllocator fontKeys()
	{
		OdArray_OdPrcFontKeysSameFont_FontKey_OdObjectsAllocator result = new OdArray_OdPrcFontKeysSameFont_FontKey_OdObjectsAllocator(OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_fontKeys__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFontName(string font_name)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_setFontName(swigCPtr, font_name);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string fontName()
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_fontName(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCharSet(uint char_set)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_setCharSet(swigCPtr, char_set);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint charSet()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFontKeysSameFont_charSet(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
