using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDynBlockReference : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDynBlockReference(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDynBlockReference obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbDynBlockReference()
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

	public OdDbDynBlockReference(OdDbObjectId blockRefId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockReference__SWIG_PCTS(OdDbObjectId.getCPtr(blockRefId)), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdDbDynBlockReference(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockReference__SWIG_PCTS(OdDbObjectId.getCPtr(blockRefId)), cMemoryOwn: true));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isDynamicBlock(OdDbObjectId blockTableRecordId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_isDynamicBlock__SWIG_0(OdDbObjectId.getCPtr(blockTableRecordId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDynamicBlock()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_isDynamicBlock__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId blockId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_blockId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getBlockProperties(OdDbDynBlockReferencePropertyArray properties)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_getBlockProperties(swigCPtr, OdDbDynBlockReferencePropertyArray.getCPtr(properties));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetBlock()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_resetBlock(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool convertToStaticBlock()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_convertToStaticBlock__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool convertToStaticBlock(string newBlockName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_convertToStaticBlock__SWIG_1(swigCPtr, newBlockName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId dynamicBlockTableRecord()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_dynamicBlockTableRecord(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId anonymousBlockTableRecord()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_anonymousBlockTableRecord(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBlockRepresentationContext getRepresentationContext()
	{
		OdDbBlockRepresentationContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockRepresentationContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReference_getRepresentationContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
