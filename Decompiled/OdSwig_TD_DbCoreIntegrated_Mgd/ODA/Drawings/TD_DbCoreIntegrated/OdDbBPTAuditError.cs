using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBPTAuditError : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBPTAuditError(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBPTAuditError obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbBPTAuditError()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBPTAuditError(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbBPTAuditError_BPTAuditErrorType errorType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBPTAuditError_errorType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbBPTAuditError_BPTAuditErrorType)result;
	}

	public void getCellIndex(out int row, out int col)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBPTAuditError_getCellIndex(swigCPtr, out row, out col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int getColumnIndex()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBPTAuditError_getColumnIndex(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdIntArray getRowIndex()
	{
		OdIntArray result = new OdIntArray(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBPTAuditError_getRowIndex(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getUnmatchedValueIndex()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBPTAuditError_getUnmatchedValueIndex(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBPTAuditError(OdDbBPTAuditError_BPTAuditErrorType t, int r, int c, OdIntArray indices)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBPTAuditError__SWIG_0((int)t, r, c, OdIntArray.getCPtr(indices)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBPTAuditError(OdDbBPTAuditError_BPTAuditErrorType t, int r, int c)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBPTAuditError__SWIG_1((int)t, r, c), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBPTAuditError(OdDbBPTAuditError_BPTAuditErrorType t, int r)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBPTAuditError__SWIG_2((int)t, r), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBPTAuditError(OdDbBPTAuditError_BPTAuditErrorType t)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBPTAuditError__SWIG_3((int)t), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBPTAuditError()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBPTAuditError__SWIG_4(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
