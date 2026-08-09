using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbXRefManExt : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbXRefManExt(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbXRefManExt obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbXRefManExt()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbXRefManExt(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdDbBlockTableRecord addNewXRefDefBlock(OdDbDatabase pDb, string pathName, string blockName, bool overlaid, string password, OdDbHandle handle)
	{
		OdDbBlockTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDefBlock__SWIG_0(OdDbDatabase.getCPtr(pDb), pathName, blockName, overlaid, password, OdDbHandle.getCPtr(handle)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBlockTableRecord addNewXRefDefBlock(OdDbDatabase pDb, string pathName, string blockName, bool overlaid, string password)
	{
		OdDbBlockTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDefBlock__SWIG_1(OdDbDatabase.getCPtr(pDb), pathName, blockName, overlaid, password), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBlockTableRecord addNewXRefDefBlock(OdDbDatabase pDb, string pathName, string blockName, bool overlaid)
	{
		OdDbBlockTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDefBlock__SWIG_2(OdDbDatabase.getCPtr(pDb), pathName, blockName, overlaid), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbLayerTableRecord addNewXRefDependentLayer(OdDbBlockTableRecord pXRefBlock, string layerName)
	{
		OdDbLayerTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDependentLayer__SWIG_0(OdDbBlockTableRecord.getCPtr(pXRefBlock), layerName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbLayerTableRecord addNewXRefDependentLayer(OdDbObjectId xRefBlockId, string layerName)
	{
		OdDbLayerTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDependentLayer__SWIG_1(OdDbObjectId.getCPtr(xRefBlockId), layerName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbLinetypeTableRecord addNewXRefDependentLinetype(OdDbBlockTableRecord pXRefBlock, string linetypeName)
	{
		OdDbLinetypeTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLinetypeTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDependentLinetype__SWIG_0(OdDbBlockTableRecord.getCPtr(pXRefBlock), linetypeName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbLinetypeTableRecord addNewXRefDependentLinetype(OdDbObjectId xRefBlockId, string linetypeName)
	{
		OdDbLinetypeTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLinetypeTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDependentLinetype__SWIG_1(OdDbObjectId.getCPtr(xRefBlockId), linetypeName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTextStyleTableRecord addNewXRefDependentTextStyle(OdDbBlockTableRecord pXRefBlock, string textStyleName)
	{
		OdDbTextStyleTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTextStyleTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDependentTextStyle__SWIG_0(OdDbBlockTableRecord.getCPtr(pXRefBlock), textStyleName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTextStyleTableRecord addNewXRefDependentTextStyle(OdDbObjectId xRefBlockId, string textStyleName)
	{
		OdDbTextStyleTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTextStyleTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNewXRefDependentTextStyle__SWIG_1(OdDbObjectId.getCPtr(xRefBlockId), textStyleName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void addNestedXRefId(OdDbBlockTableRecord pXRefBlock, OdDbObjectId nestedBlockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_addNestedXRefId(OdDbBlockTableRecord.getCPtr(pXRefBlock), OdDbObjectId.getCPtr(nestedBlockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void getNestedXRefIds(OdDbBlockTableRecord pXRefBlock, OdDbObjectIdArray ids)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_getNestedXRefIds(OdDbBlockTableRecord.getCPtr(pXRefBlock), OdDbObjectIdArray.getCPtr(ids));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbObjectId getSymbolTableRecordXrefBlockId(OdDbSymbolTableRecord pRec)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_getSymbolTableRecordXrefBlockId(OdDbSymbolTableRecord.getCPtr(pRec)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult bindRecords(OdDbObjectIdArray ids, OdDbDatabase pHostDatabase)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXRefManExt_bindRecords(OdDbObjectIdArray.getCPtr(ids), OdDbDatabase.getCPtr(pHostDatabase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbXRefManExt()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbXRefManExt(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
