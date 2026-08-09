using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBaseFileBuf : OdRxObjectImpl_OdStreamBuf
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBaseFileBuf(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBaseFileBuf obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBaseFileBuf(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void open(string filename, Oda_FileShareMode shareMode, Oda_FileAccessMode accessMode, Oda_FileCreationDisposition creationDisposition)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_open(swigCPtr, filename, (int)shareMode, (int)accessMode, (int)creationDisposition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void close()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_close(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual string fileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_fileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint getShareMode()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_getShareMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual ulong length()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual ulong seek(long offset, OdDb_FilerSeekType seekType)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_seek(swigCPtr, offset, (int)seekType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual ulong tell()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_tell(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isEof()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_isEof(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual byte getByte()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_getByte(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private new void getBytes(IntPtr buffer, uint numBytes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_getBytes(swigCPtr, buffer, numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void putByte(byte value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_putByte(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void putBytes(byte[] buffer)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_putBytes(swigCPtr, intPtr);
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

	public new virtual void truncate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_truncate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void copyDataTo(OdStreamBuf pDestination, ulong sourceStart, ulong sourceEnd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_copyDataTo(swigCPtr, OdStreamBuf.getCPtr(pDestination), sourceStart, sourceEnd);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getAccessMode()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_getAccessMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdBaseFileBuf_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
