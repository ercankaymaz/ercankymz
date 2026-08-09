using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbFormattedTableData : OdDbLinkedTableData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbFormattedTableData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbFormattedTableData obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbFormattedTableData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbFormattedTableData cast(OdRxObject pObj)
	{
		OdDbFormattedTableData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFormattedTableData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbFormattedTableData createObject()
	{
		OdDbFormattedTableData rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFormattedTableData>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int insertRowAndInherit(int nIndex, int nInheritFrom, int nNumRows)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_insertRowAndInherit(swigCPtr, nIndex, nInheritFrom, nNumRows);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int insertColumnAndInherit(int nIndex, int nInheritFrom, int nNumCols)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_insertColumnAndInherit(swigCPtr, nIndex, nInheritFrom, nNumCols);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFieldId(int nRow, int nCol, OdDbObjectId idField, OdDb_CellOption nFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setFieldId__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idField), (int)nFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFieldId(int nRow, int nCol, uint nContent, OdDbObjectId idField, OdDb_CellOption nFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setFieldId__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idField), (int)nFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void merge(OdCellRange range)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_merge(swigCPtr, OdCellRange.getCPtr(range));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unmerge(OdCellRange range)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_unmerge(swigCPtr, OdCellRange.getCPtr(range));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isMerged(int nRow, int nCol)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_isMerged(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCellRange getMergeRange(int nRow, int nCol)
	{
		OdCellRange result = new OdCellRange(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_getMergeRange(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMergeAllEnabled(int nRow, int nCol)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_isMergeAllEnabled(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableMergeAll(int nRow, int nCol, bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_enableMergeAll(swigCPtr, nRow, nCol, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isFormatEditable(int nRow, int nCol)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_isFormatEditable(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double rotation(int nRow, int nCol)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_rotation__SWIG_0(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double rotation(int nRow, int nCol, int nContent)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_rotation__SWIG_1(swigCPtr, nRow, nCol, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRotation(int nRow, int nCol, double fRotation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setRotation__SWIG_0(swigCPtr, nRow, nCol, fRotation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRotation(int nRow, int nCol, int nContent, double fRotation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setRotation__SWIG_1(swigCPtr, nRow, nCol, nContent, fRotation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double scale(int nRow, int nCol)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_scale__SWIG_0(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double scale(int nRow, int nCol, int nContent)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_scale__SWIG_1(swigCPtr, nRow, nCol, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setScale(int nRow, int nCol, double fScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setScale__SWIG_0(swigCPtr, nRow, nCol, fScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setScale(int nRow, int nCol, int nContent, double fScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setScale__SWIG_1(swigCPtr, nRow, nCol, nContent, fScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAutoScale(int nRow, int nCol)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_isAutoScale__SWIG_0(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isAutoScale(int nRow, int nCol, int nContent)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_isAutoScale__SWIG_1(swigCPtr, nRow, nCol, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAutoScale(int nRow, int nCol, bool bAutoScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setAutoScale__SWIG_0(swigCPtr, nRow, nCol, bAutoScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAutoScale(int nRow, int nCol, int nContent, bool bAutoScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setAutoScale__SWIG_1(swigCPtr, nRow, nCol, nContent, bAutoScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CellAlignment alignment(int nRow, int nCol)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_alignment(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellAlignment)result;
	}

	public virtual void setAlignment(int nRow, int nCol, OdDb_CellAlignment nAlignment)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setAlignment(swigCPtr, nRow, nCol, (int)nAlignment);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor contentColor(int nRow, int nCol)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_contentColor__SWIG_0(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor contentColor(int nRow, int nCol, int nContent)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_contentColor__SWIG_1(swigCPtr, nRow, nCol, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setContentColor(int nRow, int nCol, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setContentColor__SWIG_0(swigCPtr, nRow, nCol, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setContentColor(int nRow, int nCol, int nContent, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setContentColor__SWIG_1(swigCPtr, nRow, nCol, nContent, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId textStyle(int nRow, int nCol)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_textStyle__SWIG_0(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId textStyle(int nRow, int nCol, int nContent)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_textStyle__SWIG_1(swigCPtr, nRow, nCol, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextStyle(int nRow, int nCol, OdDbObjectId idTextStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setTextStyle__SWIG_0(swigCPtr, nRow, nCol, OdDbObjectId.getCPtr(idTextStyle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextStyle(int nRow, int nCol, int nContent, OdDbObjectId idTextStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setTextStyle__SWIG_1(swigCPtr, nRow, nCol, nContent, OdDbObjectId.getCPtr(idTextStyle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double textHeight(int nRow, int nCol)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_textHeight__SWIG_0(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double textHeight(int nRow, int nCol, int nContent)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_textHeight__SWIG_1(swigCPtr, nRow, nCol, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextHeight(int nRow, int nCol, double fTextHeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setTextHeight__SWIG_0(swigCPtr, nRow, nCol, fTextHeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextHeight(int nRow, int nCol, int nContent, double fTextHeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setTextHeight__SWIG_1(swigCPtr, nRow, nCol, nContent, fTextHeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor backgroundColor(int nRow, int nCol)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_backgroundColor(swigCPtr, nRow, nCol), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackgroundColor(int nRow, int nCol, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setBackgroundColor(swigCPtr, nRow, nCol, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CellContentLayout contentLayout(int nRow, int nCol)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_contentLayout(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellContentLayout)result;
	}

	public virtual void setContentLayout(int nRow, int nCol, OdDb_CellContentLayout nLayout)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setContentLayout(swigCPtr, nRow, nCol, (int)nLayout);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_FlowDirection flowDirection()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_flowDirection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_FlowDirection)result;
	}

	public virtual void setFlowDirection(OdDb_FlowDirection nDir)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setFlowDirection(swigCPtr, (int)nDir);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double margin(int nRow, int nCol, OdDb_CellMargin nMargin)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_margin(swigCPtr, nRow, nCol, (int)nMargin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMargin(int nRow, int nCol, OdDb_CellMargin nMargins, double fMargin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setMargin(swigCPtr, nRow, nCol, (int)nMargins, fMargin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_GridLineStyle gridLineStyle(int nRow, int nCol, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_gridLineStyle(swigCPtr, nRow, nCol, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_GridLineStyle)result;
	}

	public virtual void setGridLineStyle(int nRow, int nCol, OdDb_GridLineType nGridLineTypes, OdDb_GridLineStyle nLineStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridLineStyle(swigCPtr, nRow, nCol, (int)nGridLineTypes, (int)nLineStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual LineWeight gridLineWeight(int nRow, int nCol, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_gridLineWeight(swigCPtr, nRow, nCol, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual void setGridLineWeight(int nRow, int nCol, OdDb_GridLineType nGridLineTypes, LineWeight nLineWeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridLineWeight(swigCPtr, nRow, nCol, (int)nGridLineTypes, (int)nLineWeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId gridLinetype(int nRow, int nCol, OdDb_GridLineType nGridLineType)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_gridLinetype(swigCPtr, nRow, nCol, (int)nGridLineType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridLinetype(int nRow, int nCol, OdDb_GridLineType nGridLineTypes, OdDbObjectId idLinetype)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridLinetype(swigCPtr, nRow, nCol, (int)nGridLineTypes, OdDbObjectId.getCPtr(idLinetype));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor gridColor(int nRow, int nCol, OdDb_GridLineType nGridLineType)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_gridColor(swigCPtr, nRow, nCol, (int)nGridLineType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridColor(int nRow, int nCol, OdDb_GridLineType nGridLineTypes, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridColor(swigCPtr, nRow, nCol, (int)nGridLineTypes, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_Visibility gridVisibility(int nRow, int nCol, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_gridVisibility(swigCPtr, nRow, nCol, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual void setGridVisibility(int nRow, int nCol, OdDb_GridLineType nGridLineTypes, OdDb_Visibility nVisibility)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridVisibility(swigCPtr, nRow, nCol, (int)nGridLineTypes, (int)nVisibility);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double gridDoubleLineSpacing(int nRow, int nCol, OdDb_GridLineType nGridLineType)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_gridDoubleLineSpacing(swigCPtr, nRow, nCol, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGridDoubleLineSpacing(int nRow, int nCol, OdDb_GridLineType nGridLineTypes, double fSpacing)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridDoubleLineSpacing(swigCPtr, nRow, nCol, (int)nGridLineTypes, fSpacing);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getGridProperty(int nRow, int nCol, OdDb_GridLineType nGridLineType, OdGridProperty gridProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_getGridProperty(swigCPtr, nRow, nCol, (int)nGridLineType, OdGridProperty.getCPtr(gridProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridProperty(int nRow, int nCol, OdDb_GridLineType nGridLineTypes, OdGridProperty gridProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridProperty__SWIG_0(swigCPtr, nRow, nCol, (int)nGridLineTypes, OdGridProperty.getCPtr(gridProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridProperty(OdCellRange range, OdDb_GridLineType nGridLineTypes, OdGridProperty gridProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setGridProperty__SWIG_1(swigCPtr, OdCellRange.getCPtr(range), (int)nGridLineTypes, OdGridProperty.getCPtr(gridProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CellProperty getOverride(int nRow, int nCol, int nContent)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_getOverride__SWIG_0(swigCPtr, nRow, nCol, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellProperty)result;
	}

	public virtual OdDb_GridProperty getOverride(int nRow, int nCol, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_getOverride__SWIG_1(swigCPtr, nRow, nCol, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_GridProperty)result;
	}

	public virtual void setOverride(int nRow, int nCol, int nContent, OdDb_CellProperty nOverride)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setOverride__SWIG_0(swigCPtr, nRow, nCol, nContent, (int)nOverride);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOverride(int nRow, int nCol, OdDb_GridLineType nGridLineType, OdDb_GridProperty nOverride)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_setOverride__SWIG_1(swigCPtr, nRow, nCol, (int)nGridLineType, (int)nOverride);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeAllOverrides(int nRow, int nCol)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_removeAllOverrides(swigCPtr, nRow, nCol);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFormattedTableData_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
