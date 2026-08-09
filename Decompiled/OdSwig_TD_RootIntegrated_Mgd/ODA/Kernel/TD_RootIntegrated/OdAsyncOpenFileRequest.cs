using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAsyncOpenFileRequest : OdAsyncBaseRequest
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public string m_filename
	{
		get
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_filename_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_filename_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public Oda_FileAccessMode m_accessMode
	{
		get
		{
			long result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_accessMode_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (Oda_FileAccessMode)result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_accessMode_set(swigCPtr, (int)value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public Oda_FileShareMode m_shareMode
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_shareMode_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (Oda_FileShareMode)result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_shareMode_set(swigCPtr, (int)value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public Oda_FileCreationDisposition m_creationDisposition
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_creationDisposition_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (Oda_FileCreationDisposition)result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_creationDisposition_set(swigCPtr, (int)value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdStreamBuf m_pFileStream
	{
		get
		{
			OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_pFileStream_get(swigCPtr), bOwn: true, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		set
		{
			IntPtr jarg = ((value == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(value).Handle);
			TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_m_pFileStream_set(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAsyncOpenFileRequest(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAsyncOpenFileRequest obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAsyncOpenFileRequest(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdAsyncOpenFileRequest()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdAsyncOpenFileRequest(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdAsyncOpenFileRequest) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAsyncOpenFileRequest_director_connect(swigCPtr);
	}
}
