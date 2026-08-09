using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbTableIterator : OdStaticRxObject_OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbTableIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbTableIterator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbTableIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbTableIterator cast(OdRxObject pObj)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTableIterator createObject()
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTableIterator createObject(OdDbTable pTable)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_createObject__SWIG_1(OdDbTable.getCPtr(pTable)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTableIterator createObject(OdDbTable pTable, OdCellRange range, OdDb_TableIteratorOption nOption)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_createObject__SWIG_2(OdDbTable.getCPtr(pTable), OdCellRange.getCPtr(range), (int)nOption), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTableIterator createObject(OdDbLinkedTableData pTable)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_createObject__SWIG_3(OdDbLinkedTableData.getCPtr(pTable)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTableIterator createObject(OdDbLinkedTableData pTable, OdCellRange range, OdDb_TableIteratorOption nOption)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_createObject__SWIG_4(OdDbLinkedTableData.getCPtr(pTable), OdCellRange.getCPtr(range), (int)nOption), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTableIterator createObject(OdCellRange range)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_createObject__SWIG_5(OdCellRange.getCPtr(range)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbTableIterator createObject(OdCellRange range, OdDb_TableIteratorOption nOption)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_createObject__SWIG_6(OdCellRange.getCPtr(range), (int)nOption), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void start()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_start(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void step()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_step(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool done()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_done(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool seek(OdDbCell cell)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_seek(swigCPtr, OdDbCell.getCPtr(cell));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbCell getCell()
	{
		OdDbCell result = new OdDbCell(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_getCell(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getRow()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_getRow(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getColumn()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_getColumn(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTableIterator_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
