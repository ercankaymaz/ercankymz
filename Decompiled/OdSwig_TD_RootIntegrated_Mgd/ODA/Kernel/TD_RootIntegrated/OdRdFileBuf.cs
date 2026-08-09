using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRdFileBuf : OdBaseFileBuf
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRdFileBuf(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRdFileBuf obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRdFileBuf(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRdFileBuf createObject()
	{
		OdRdFileBuf rXObject = Helpers.GetRXObject<OdRdFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRdFileBuf createObject(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode, Oda_FileCreationDisposition creationDisposition)
	{
		OdRdFileBuf rXObject = Helpers.GetRXObject<OdRdFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_createObject__SWIG_1(filename, (int)shareMode, (int)accessMode, (int)creationDisposition), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRdFileBuf createObject(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode)
	{
		OdRdFileBuf rXObject = Helpers.GetRXObject<OdRdFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_createObject__SWIG_2(filename, (int)shareMode, (int)accessMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRdFileBuf createObject(string filename, Oda_FileShareMode shareMode)
	{
		OdRdFileBuf rXObject = Helpers.GetRXObject<OdRdFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_createObject__SWIG_3(filename, (int)shareMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRdFileBuf createObject(string filename)
	{
		OdRdFileBuf rXObject = Helpers.GetRXObject<OdRdFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_createObject__SWIG_4(filename), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void open(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode, Oda_FileCreationDisposition creationDisposition)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_open__SWIG_0(swigCPtr, filename, (int)shareMode, (int)accessMode, (int)creationDisposition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void open(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_open__SWIG_1(swigCPtr, filename, (int)shareMode, (int)accessMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void open(string filename, Oda_FileShareMode shareMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_open__SWIG_2(swigCPtr, filename, (int)shareMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void open(string filename)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_open__SWIG_3(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void close()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_close(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ulong length()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong seek(long offset, OdDb_FilerSeekType seekType)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_seek(swigCPtr, offset, (int)seekType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong tell()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_tell(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEof()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_isEof(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override byte getByte()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_getByte(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private new void getBytes(IntPtr buffer, uint numBytes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_getBytes(swigCPtr, buffer, numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void putByte(byte value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_putByte(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void putBytes(byte[] buffer)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_putBytes(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public override void truncate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_truncate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyDataTo(OdStreamBuf pDestination, ulong sourceStart, ulong sourceEnd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_copyDataTo(swigCPtr, OdStreamBuf.getCPtr(pDestination), sourceStart, sourceEnd);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRdFileBuf_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
