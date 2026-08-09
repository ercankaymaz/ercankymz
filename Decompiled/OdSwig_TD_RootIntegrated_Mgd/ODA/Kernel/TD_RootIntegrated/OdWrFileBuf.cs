using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdWrFileBuf : OdBaseFileBuf
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdWrFileBuf(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdWrFileBuf obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdWrFileBuf(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdWrFileBuf createObject()
	{
		OdWrFileBuf rXObject = Helpers.GetRXObject<OdWrFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdWrFileBuf createObject(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode, Oda_FileCreationDisposition creationDisposition)
	{
		OdWrFileBuf rXObject = Helpers.GetRXObject<OdWrFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_createObject__SWIG_1(filename, (int)shareMode, (int)accessMode, (int)creationDisposition), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdWrFileBuf createObject(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode)
	{
		OdWrFileBuf rXObject = Helpers.GetRXObject<OdWrFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_createObject__SWIG_2(filename, (int)shareMode, (int)accessMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdWrFileBuf createObject(string filename, Oda_FileShareMode shareMode)
	{
		OdWrFileBuf rXObject = Helpers.GetRXObject<OdWrFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_createObject__SWIG_3(filename, (int)shareMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdWrFileBuf createObject(string filename)
	{
		OdWrFileBuf rXObject = Helpers.GetRXObject<OdWrFileBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_createObject__SWIG_4(filename), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void close()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_close(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ulong seek(long offset, OdDb_FilerSeekType seekType)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_seek(swigCPtr, offset, (int)seekType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void copyDataTo(OdStreamBuf pDestination, ulong sourceStart, ulong sourceEnd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_copyDataTo(swigCPtr, OdStreamBuf.getCPtr(pDestination), sourceStart, sourceEnd);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ulong tell()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_tell(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong length()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void putByte(byte value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_putByte(swigCPtr, value);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_putBytes(swigCPtr, intPtr);
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

	public override byte getByte()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_getByte(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private new void getBytes(IntPtr buffer, uint numBytes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_getBytes(swigCPtr, buffer, numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void open(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode, Oda_FileCreationDisposition creationDisposition)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_open__SWIG_0(swigCPtr, filename, (int)shareMode, (int)accessMode, (int)creationDisposition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void open(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_open__SWIG_1(swigCPtr, filename, (int)shareMode, (int)accessMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void open(string filename, Oda_FileShareMode shareMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_open__SWIG_2(swigCPtr, filename, (int)shareMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void open(string filename)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_open__SWIG_3(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdWrFileBuf_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
