using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDynBlockTableRecord : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDynBlockTableRecord(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDynBlockTableRecord obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbDynBlockTableRecord()
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
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbDynBlockTableRecord(OdDbObjectId blockRefId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockTableRecord__SWIG_PCTS(OdDbObjectId.getCPtr(blockRefId)), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdDbDynBlockTableRecord(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockTableRecord__SWIG_PCTS(OdDbObjectId.getCPtr(blockRefId)), cMemoryOwn: true));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDynamicBlock()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockTableRecord_isDynamicBlock__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isDynamicBlock(OdDbBlockTableRecord pBlockTableRecord)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockTableRecord_isDynamicBlock__SWIG_1(OdDbBlockTableRecord.getCPtr(pBlockTableRecord));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId blockTableRecordId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockTableRecord_blockTableRecordId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAnonymousBlockIds(OdDbObjectIdArray anonymousIds)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockTableRecord_getAnonymousBlockIds(swigCPtr, OdDbObjectIdArray.getCPtr(anonymousIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void updateAnonymousBlocks()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockTableRecord_updateAnonymousBlocks(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void convertToStaticBlock()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockTableRecord_convertToStaticBlock(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
