using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbTable : OdDbBlockReference
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbTable(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbTable obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbTable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbTable cast(OdRxObject pObj)
	{
		OdDbTable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTable>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbTable createObject()
	{
		OdDbTable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTable>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId tableStyle()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_tableStyle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTableStyle(OdDbObjectId tableStyleId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTableStyle(swigCPtr, OdDbObjectId.getCPtr(tableStyleId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector3d direction()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_direction(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDirection(OdGeVector3d horizVector)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDirection(swigCPtr, OdGeVector3d.getCPtr(horizVector));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numRows()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_numRows(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNumRows(uint numRows)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setNumRows(swigCPtr, numRows);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numColumns()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_numColumns(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNumColumns(uint numColumns)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setNumColumns(swigCPtr, numColumns);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double width()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_width(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWidth(double width)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setWidth(swigCPtr, width);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double columnWidth(uint column)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_columnWidth(swigCPtr, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColumnWidth(uint column, double width)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setColumnWidth__SWIG_0(swigCPtr, column, width);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColumnWidth(double width)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setColumnWidth__SWIG_1(swigCPtr, width);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double height()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_height(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHeight(double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setHeight(swigCPtr, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double rowHeight(uint row)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_rowHeight(swigCPtr, row);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRowHeight(uint row, double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setRowHeight__SWIG_0(swigCPtr, row, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRowHeight(double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setRowHeight__SWIG_1(swigCPtr, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double minimumColumnWidth(uint column)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_minimumColumnWidth(swigCPtr, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double minimumRowHeight(uint row)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_minimumRowHeight(swigCPtr, row);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double minimumTableWidth()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_minimumTableWidth(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double minimumTableHeight()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_minimumTableHeight(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double horzCellMargin()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_horzCellMargin(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHorzCellMargin(double cellMargin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setHorzCellMargin(swigCPtr, cellMargin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double vertCellMargin()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_vertCellMargin(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVertCellMargin(double cellMargin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setVertCellMargin(swigCPtr, cellMargin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_FlowDirection flowDirection()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_flowDirection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_FlowDirection)result;
	}

	public virtual void setFlowDirection(OdDb_FlowDirection flowDirection)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setFlowDirection(swigCPtr, (int)flowDirection);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isTitleSuppressed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isTitleSuppressed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void suppressTitleRow(bool suppress)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_suppressTitleRow(swigCPtr, suppress);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isHeaderSuppressed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isHeaderSuppressed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void suppressHeaderRow(bool suppress)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_suppressHeaderRow(swigCPtr, suppress);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CellAlignment alignment(OdDb_RowType rowType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_alignment__SWIG_0(swigCPtr, (int)rowType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellAlignment)result;
	}

	public virtual OdDb_CellAlignment alignment()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_alignment__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellAlignment)result;
	}

	public virtual OdDb_CellAlignment alignment(uint row, uint column)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_alignment__SWIG_2(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellAlignment)result;
	}

	public virtual void setAlignment(OdDb_CellAlignment alignment, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setAlignment__SWIG_0(swigCPtr, (int)alignment, rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAlignment(OdDb_CellAlignment alignment)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setAlignment__SWIG_1(swigCPtr, (int)alignment);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAlignment(uint row, uint column, OdDb_CellAlignment alignment)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setAlignment__SWIG_2(swigCPtr, row, column, (int)alignment);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isBackgroundColorNone(OdDb_RowType rowType)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isBackgroundColorNone__SWIG_0(swigCPtr, (int)rowType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isBackgroundColorNone()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isBackgroundColorNone__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isBackgroundColorNone(uint row, uint column)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isBackgroundColorNone__SWIG_2(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackgroundColorNone(bool disable, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBackgroundColorNone__SWIG_0(swigCPtr, disable, rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBackgroundColorNone(bool disable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBackgroundColorNone__SWIG_1(swigCPtr, disable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBackgroundColorNone(uint row, uint column, bool disable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBackgroundColorNone__SWIG_2(swigCPtr, row, column, disable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor backgroundColor(OdDb_RowType rowType)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_backgroundColor__SWIG_0(swigCPtr, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor backgroundColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_backgroundColor__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor backgroundColor(uint row, uint column)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_backgroundColor__SWIG_2(swigCPtr, row, column), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackgroundColor(OdCmColor color, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBackgroundColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBackgroundColor(OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBackgroundColor__SWIG_1(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBackgroundColor(uint row, uint column, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBackgroundColor__SWIG_2(swigCPtr, row, column, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor contentColor(OdDb_RowType rowType)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_contentColor__SWIG_0(swigCPtr, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor contentColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_contentColor__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor contentColor(uint row, uint column)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_contentColor__SWIG_2(swigCPtr, row, column), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setContentColor(OdCmColor color, uint nRowType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setContentColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), nRowType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setContentColor(OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setContentColor__SWIG_1(swigCPtr, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setContentColor(uint row, uint column, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setContentColor__SWIG_2(swigCPtr, row, column, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId textStyle(OdDb_RowType rowType)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textStyle__SWIG_0(swigCPtr, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId textStyle()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textStyle__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId textStyle(uint row, uint column)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textStyle__SWIG_2(swigCPtr, row, column), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextStyle(OdDbObjectId textStyleId, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextStyle__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(textStyleId), rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextStyle(OdDbObjectId textStyleId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextStyle__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(textStyleId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextStyle(uint row, uint column, OdDbObjectId textStyleId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextStyle__SWIG_2(swigCPtr, row, column, OdDbObjectId.getCPtr(textStyleId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double textHeight(OdDb_RowType rowType)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textHeight__SWIG_0(swigCPtr, (int)rowType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double textHeight()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textHeight__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double textHeight(uint row, uint column)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textHeight__SWIG_2(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextHeight(double height, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextHeight__SWIG_0(swigCPtr, height, rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextHeight(double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextHeight__SWIG_1(swigCPtr, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextHeight(uint row, uint column, double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextHeight__SWIG_2(swigCPtr, row, column, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual LineWeight gridLineWeight(OdDb_GridLineType gridlineType, OdDb_RowType rowType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridLineWeight__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual LineWeight gridLineWeight(OdDb_GridLineType gridlineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridLineWeight__SWIG_1(swigCPtr, (int)gridlineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual LineWeight gridLineWeight(uint row, uint column, OdDb_CellEdgeMask edgeType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridLineWeight__SWIG_2(swigCPtr, row, column, (int)edgeType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual void setGridLineWeight(LineWeight lineWeight, uint gridlineTypes, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridLineWeight__SWIG_0(swigCPtr, (int)lineWeight, gridlineTypes, rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridLineWeight(uint row, uint column, short edgeTypes, LineWeight lineWeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridLineWeight__SWIG_1(swigCPtr, row, column, edgeTypes, (int)lineWeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor gridColor(OdDb_GridLineType gridlineType, OdDb_RowType rowType)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridColor__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor gridColor(OdDb_GridLineType gridlineType)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridColor__SWIG_1(swigCPtr, (int)gridlineType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor gridColor(uint row, uint column, OdDb_CellEdgeMask edgeType)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridColor__SWIG_2(swigCPtr, row, column, (int)edgeType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDb_Visibility gridVisibility(OdDb_GridLineType gridlineType, OdDb_RowType rowType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridVisibility__SWIG_0(swigCPtr, (int)gridlineType, (int)rowType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual OdDb_Visibility gridVisibility(OdDb_GridLineType gridlineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridVisibility__SWIG_1(swigCPtr, (int)gridlineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual OdDb_Visibility gridVisibility(uint row, uint column, OdDb_CellEdgeMask edgeType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridVisibility__SWIG_2(swigCPtr, row, column, (int)edgeType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public virtual void setGridVisibility(OdDb_Visibility gridVisiblity, uint gridlineTypes, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridVisibility__SWIG_0(swigCPtr, (int)gridVisiblity, gridlineTypes, rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridVisibility(uint row, uint column, short edgeTypes, OdDb_Visibility gridVisibility)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridVisibility__SWIG_1(swigCPtr, row, column, edgeTypes, (int)gridVisibility);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool tableStyleOverrides(OdUInt32Array overrides)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_tableStyleOverrides(swigCPtr, OdUInt32Array.getCPtr(overrides).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearTableStyleOverrides(int option)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_clearTableStyleOverrides__SWIG_0(swigCPtr, option);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clearTableStyleOverrides()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_clearTableStyleOverrides__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_CellType cellType(uint row, uint column)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_cellType(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellType)result;
	}

	public virtual void setCellType(uint row, uint column, OdDb_CellType cellType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setCellType(swigCPtr, row, column, (int)cellType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getCellExtents(uint row, uint column, bool isOuterCell, OdGePoint3dArray pts)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getCellExtents(swigCPtr, row, column, isOuterCell, OdGePoint3dArray.getCPtr(pts).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d attachmentPoint(uint row, uint column)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_attachmentPoint__SWIG_0(swigCPtr, row, column), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool cellStyleOverrides(uint row, uint column, OdUInt32Array overrides)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_cellStyleOverrides(swigCPtr, row, column, OdUInt32Array.getCPtr(overrides).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearCellOverrides(uint row, uint column)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_clearCellOverrides(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteCellContent(uint row, uint column)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteCellContent(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_RowType rowType(uint row)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_rowType(swigCPtr, row);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_RowType)result;
	}

	public virtual string textString(uint row, uint column)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textString__SWIG_0(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTextString(uint row, uint column, string textString)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextString__SWIG_0(swigCPtr, row, column, textString);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId fieldId(uint row, uint column)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_fieldId__SWIG_0(swigCPtr, row, column), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFieldId(uint row, uint column, OdDbObjectId fieldId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setFieldId__SWIG_0(swigCPtr, row, column, OdDbObjectId.getCPtr(fieldId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDb_RotationAngle textRotation(uint row, uint column)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textRotation(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_RotationAngle)result;
	}

	public virtual void setTextRotation(uint row, uint column, OdDb_RotationAngle textRotation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextRotation(swigCPtr, row, column, (int)textRotation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAutoScale(uint row, uint column)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isAutoScale__SWIG_0(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAutoScale(uint row, uint column, bool autoScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setAutoScale__SWIG_0(swigCPtr, row, column, autoScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId blockTableRecordId(uint row, uint column)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_blockTableRecordId__SWIG_0(swigCPtr, row, column), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBlockTableRecordId(uint row, uint column, OdDbObjectId blockId, bool autoScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBlockTableRecordId__SWIG_0(swigCPtr, row, column, OdDbObjectId.getCPtr(blockId), autoScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBlockTableRecordId(uint row, uint column, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBlockTableRecordId__SWIG_1(swigCPtr, row, column, OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double blockScale(uint row, uint column)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_blockScale(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBlockScale(uint row, uint column, double blockScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBlockScale(swigCPtr, row, column, blockScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double blockRotation(uint row, uint column)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_blockRotation(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBlockRotation(uint row, uint column, double blockRotation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBlockRotation(swigCPtr, row, column, blockRotation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getBlockAttributeValue(uint row, uint column, OdDbObjectId attdefId, ref string attValue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(attValue);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getBlockAttributeValue__SWIG_0(swigCPtr, row, column, OdDbObjectId.getCPtr(attdefId), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				attValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual void setBlockAttributeValue(uint row, uint column, OdDbObjectId attdefId, string attValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBlockAttributeValue__SWIG_0(swigCPtr, row, column, OdDbObjectId.getCPtr(attdefId), attValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridColor(OdCmColor color, uint gridlineTypes, uint rowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridColor__SWIG_0(swigCPtr, OdCmColor.getCPtr(color), gridlineTypes, rowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGridColor(uint row, uint column, short edgeTypes, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridColor__SWIG_1(swigCPtr, row, column, edgeTypes, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void insertColumns(uint column, double width, uint numColumns)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_insertColumns__SWIG_0(swigCPtr, column, width, numColumns);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void insertColumns(uint column, double width)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_insertColumns__SWIG_1(swigCPtr, column, width);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteColumns(uint column, uint numColumns)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteColumns__SWIG_0(swigCPtr, column, numColumns);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteColumns(uint column)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteColumns__SWIG_1(swigCPtr, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void insertRows(uint row, double height, uint numRows)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_insertRows__SWIG_0(swigCPtr, row, height, numRows);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void insertRows(uint row, double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_insertRows__SWIG_1(swigCPtr, row, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteRows(uint row, uint numRows)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteRows__SWIG_0(swigCPtr, row, numRows);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void deleteRows(uint row)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteRows__SWIG_1(swigCPtr, row);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mergeCells(uint minRow, uint maxRow, uint minColumn, uint maxColumn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_mergeCells(swigCPtr, minRow, maxRow, minColumn, maxColumn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unmergeCells(uint minRow, uint maxRow, uint minColumn, uint maxColumn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_unmergeCells(swigCPtr, minRow, maxRow, minColumn, maxColumn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isMergedCell(uint row, uint column, ref uint minRow, ref uint maxRow, ref uint minColumn, ref uint maxColumn)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isMergedCell__SWIG_0(swigCPtr, row, column, ref minRow, ref maxRow, ref minColumn, ref maxColumn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMergedCell(uint row, uint column, ref uint minRow, ref uint maxRow, ref uint minColumn)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isMergedCell__SWIG_1(swigCPtr, row, column, ref minRow, ref maxRow, ref minColumn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMergedCell(uint row, uint column, ref uint minRow, ref uint maxRow)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isMergedCell__SWIG_2(swigCPtr, row, column, ref minRow, ref maxRow);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMergedCell(uint row, uint column, ref uint minRow)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isMergedCell__SWIG_3(swigCPtr, row, column, ref minRow);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMergedCell(uint row, uint column)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isMergedCell__SWIG_4(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint mergedHeight(uint row, uint column)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_mergedHeight(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint mergedWidth(uint row, uint column)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_mergedWidth(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool mergedFlag(uint row, uint column)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_mergedFlag(swigCPtr, row, column);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult generateLayout()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_generateLayout(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult recomputeTableBlock(bool forceUpdate)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_recomputeTableBlock__SWIG_0(swigCPtr, forceUpdate);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult recomputeTableBlock()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_recomputeTableBlock__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool hitTest(OdGePoint3d wpt, OdGeVector3d wviewVec, double wxaper, double wyaper, out int resultRowIndex, out int resultColumnIndex, int subTable)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_hitTest__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(wpt), OdGeVector3d.getCPtr(wviewVec), wxaper, wyaper, out resultRowIndex, out resultColumnIndex, subTable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hitTest(OdGePoint3d wpt, OdGeVector3d wviewVec, double wxaper, double wyaper, out int resultRowIndex, out int resultColumnIndex)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_hitTest__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(wpt), OdGeVector3d.getCPtr(wviewVec), wxaper, wyaper, out resultRowIndex, out resultColumnIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hitTest(OdGePoint3d wpt, OdGeVector3d wviewVec, double wxaper, double wyaper, out int resultRowIndex, out int resultColumnIndex, out int contentIndex, out OdDb_TableHitItem nItem, int subTable)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_hitTest__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(wpt), OdGeVector3d.getCPtr(wviewVec), wxaper, wyaper, out resultRowIndex, out resultColumnIndex, out contentIndex, out nItem, subTable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hitTest(OdGePoint3d wpt, OdGeVector3d wviewVec, double wxaper, double wyaper, out int resultRowIndex, out int resultColumnIndex, out int contentIndex, out OdDb_TableHitItem nItem)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_hitTest__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(wpt), OdGeVector3d.getCPtr(wviewVec), wxaper, wyaper, out resultRowIndex, out resultColumnIndex, out contentIndex, out nItem);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult select(OdGePoint3d wpt, OdGeVector3d wvwVec, OdGeVector3d wvwxVec, double wxaper, double wyaper, bool allowOutside, bool bInPickFirst, out int resultRowIndex, out int resultColumnIndex, OdDbFullSubentPathArray pPaths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_select__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(wpt), OdGeVector3d.getCPtr(wvwVec), OdGeVector3d.getCPtr(wvwxVec), wxaper, wyaper, allowOutside, bInPickFirst, out resultRowIndex, out resultColumnIndex, OdDbFullSubentPathArray.getCPtr(pPaths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult select(OdGePoint3d wpt, OdGeVector3d wvwVec, OdGeVector3d wvwxVec, double wxaper, double wyaper, bool allowOutside, bool bInPickFirst, out int resultRowIndex, out int resultColumnIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_select__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(wpt), OdGeVector3d.getCPtr(wvwVec), OdGeVector3d.getCPtr(wvwxVec), wxaper, wyaper, allowOutside, bInPickFirst, out resultRowIndex, out resultColumnIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult selectSubRegion(OdGePoint3d wpt1, OdGePoint3d wpt2, OdGeVector3d wvwVec, OdGeVector3d wvwxVec, double wxaper, double wyaper, OdDb_SelectType seltype, bool bIncludeCurrentSelection, bool bInPickFirst, out int rowMin, out int rowMax, out int colMin, out int colMax, OdDbFullSubentPathArray pPaths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_selectSubRegion__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(wpt1), OdGePoint3d.getCPtr(wpt2), OdGeVector3d.getCPtr(wvwVec), OdGeVector3d.getCPtr(wvwxVec), wxaper, wyaper, (int)seltype, bIncludeCurrentSelection, bInPickFirst, out rowMin, out rowMax, out colMin, out colMax, OdDbFullSubentPathArray.getCPtr(pPaths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult selectSubRegion(OdGePoint3d wpt1, OdGePoint3d wpt2, OdGeVector3d wvwVec, OdGeVector3d wvwxVec, double wxaper, double wyaper, OdDb_SelectType seltype, bool bIncludeCurrentSelection, bool bInPickFirst, out int rowMin, out int rowMax, out int colMin, out int colMax)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_selectSubRegion__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(wpt1), OdGePoint3d.getCPtr(wpt2), OdGeVector3d.getCPtr(wvwVec), OdGeVector3d.getCPtr(wvwxVec), wxaper, wyaper, (int)seltype, bIncludeCurrentSelection, bInPickFirst, out rowMin, out rowMax, out colMin, out colMax);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool reselectSubRegion(OdDbFullSubentPathArray paths)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_reselectSubRegion(swigCPtr, OdDbFullSubentPathArray.getCPtr(paths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getSubSelection(out int rowMin, out int rowMax, out int colMin, out int colMax, int subTable)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getSubSelection__SWIG_0(swigCPtr, out rowMin, out rowMax, out colMin, out colMax, subTable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubSelection(out int rowMin, out int rowMax, out int colMin, out int colMax)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getSubSelection__SWIG_1(swigCPtr, out rowMin, out rowMax, out colMin, out colMax);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdCellRange getSubSelection(int subTable)
	{
		OdCellRange result = new OdCellRange(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getSubSelection__SWIG_2(swigCPtr, subTable), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCellRange getSubSelection()
	{
		OdCellRange result = new OdCellRange(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getSubSelection__SWIG_3(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setSubSelection(OdCellRange range, int subTable)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setSubSelection__SWIG_0(swigCPtr, OdCellRange.getCPtr(range), subTable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubSelection(OdCellRange range)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setSubSelection__SWIG_1(swigCPtr, OdCellRange.getCPtr(range));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubSelection(int rowMin, int rowMax, int colMin, int colMax, int subTable)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setSubSelection__SWIG_2(swigCPtr, rowMin, rowMax, colMin, colMax, subTable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult setSubSelection(int rowMin, int rowMax, int colMin, int colMax)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setSubSelection__SWIG_3(swigCPtr, rowMin, rowMax, colMin, colMax);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void clearSubSelection()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_clearSubSelection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasSubSelection()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_hasSubSelection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult select_next_cell(int dir, out int resultRowIndex, out int resultColumnIndex, OdDbFullSubentPathArray pPaths, bool bSupportTextCellOnly)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_select_next_cell__SWIG_0(swigCPtr, dir, out resultRowIndex, out resultColumnIndex, OdDbFullSubentPathArray.getCPtr(pPaths), bSupportTextCellOnly);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult select_next_cell(int dir, out int resultRowIndex, out int resultColumnIndex, OdDbFullSubentPathArray pPaths)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_select_next_cell__SWIG_1(swigCPtr, dir, out resultRowIndex, out resultColumnIndex, OdDbFullSubentPathArray.getCPtr(pPaths));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult select_next_cell(int dir, out int resultRowIndex, out int resultColumnIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_select_next_cell__SWIG_2(swigCPtr, dir, out resultRowIndex, out resultColumnIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void subClose()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_subClose(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void subSetDatabaseDefaults(OdDbDatabase pDb, bool doSubents)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_subSetDatabaseDefaults(swigCPtr, OdDbDatabase.getCPtr(pDb), doSubents);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void modified(OdDbObject pObj)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_modified(swigCPtr, OdDbObject.getCPtr(pObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getDataType(out OdValue_DataType nDataType, out OdValue_UnitType nUnitType, OdDb_RowType type)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getDataType__SWIG_0(swigCPtr, out nDataType, out nUnitType, (int)type);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataType(OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataType__SWIG_0(swigCPtr, (int)nDataType, (int)nUnitType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDataType(OdValue_DataType nDataType, OdValue_UnitType nUnitType, int nRowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataType__SWIG_1(swigCPtr, (int)nDataType, (int)nUnitType, nRowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string format(OdDb_RowType type)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_format__SWIG_0(swigCPtr, (int)type);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFormat(string pszFormat)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setFormat__SWIG_0(swigCPtr, pszFormat);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFormat(string pszFormat, int nRowTypes)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setFormat__SWIG_1(swigCPtr, pszFormat, nRowTypes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDataType(uint row, uint col, out OdValue_DataType nDataType, out OdValue_UnitType nUnitType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getDataType__SWIG_1(swigCPtr, row, col, out nDataType, out nUnitType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDataType(uint row, uint col, OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataType__SWIG_2(swigCPtr, row, col, (int)nDataType, (int)nUnitType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue value(uint row, uint col)
	{
		OdValue result = new OdValue(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_value__SWIG_0(swigCPtr, row, col), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setValue(uint row, uint col, OdValue val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setValue__SWIG_0(swigCPtr, row, col, OdValue.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setValue(uint row, uint col, ref string pszText, OdValue_ParseOption nOption)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pszText);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setValue__SWIG_1(swigCPtr, row, col, ref jarg, (int)nOption);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				pszText = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void resetValue(uint row, uint col)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_resetValue(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string format(uint row, uint col)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_format__SWIG_1(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFormat(uint row, uint col, string pszFormat)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setFormat__SWIG_2(swigCPtr, row, col, pszFormat);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isBreakEnabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isBreakEnabled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableBreak(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_enableBreak(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_TableBreakFlowDirection breakFlowDirection()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_breakFlowDirection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_TableBreakFlowDirection)result;
	}

	public void setBreakFlowDirection(OdDb_TableBreakFlowDirection flowDir)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBreakFlowDirection(swigCPtr, (int)flowDir);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double breakHeight(uint index)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_breakHeight(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBreakHeight(uint index, double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBreakHeight(swigCPtr, index, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d breakOffset(uint index)
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_breakOffset(swigCPtr, index), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBreakOffset(uint index, OdGeVector3d vec)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBreakOffset(swigCPtr, index, OdGeVector3d.getCPtr(vec));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_TableBreakOption breakOption()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_breakOption(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_TableBreakOption)result;
	}

	public void setBreakOption(OdDb_TableBreakOption option)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBreakOption(swigCPtr, (int)option);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double breakSpacing()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_breakSpacing(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBreakSpacing(double spacing)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBreakSpacing(swigCPtr, spacing);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSize(int rows, int cols)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setSize(swigCPtr, rows, cols);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool canInsert(int nIndex, bool bRow)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_canInsert(swigCPtr, nIndex, bRow);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void insertRowsAndInherit(int nIndex, int nInheritFrom, int nNumRows)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_insertRowsAndInherit(swigCPtr, nIndex, nInheritFrom, nNumRows);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void insertColumnsAndInherit(int col, int nInheritFrom, int nNumCols)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_insertColumnsAndInherit(swigCPtr, col, nInheritFrom, nNumCols);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool canDelete(int nIndex, int nCount, bool bRow)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_canDelete(swigCPtr, nIndex, nCount, bRow);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEmpty(int row, int col)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isEmpty(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCellRange getMergeRange(int row, int col)
	{
		OdCellRange result = new OdCellRange(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getMergeRange(swigCPtr, row, col), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isContentEditable(int row, int col)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isContentEditable(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isFormatEditable(int row, int col)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isFormatEditable(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDb_CellState cellState(int row, int col)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_cellState(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellState)result;
	}

	public void setCellState(int row, int col, OdDb_CellState nLock)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setCellState(swigCPtr, row, col, (int)nLock);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numContents(int row, int col)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_numContents(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int createContent(int row, int col, int nIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_createContent(swigCPtr, row, col, nIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void moveContent(int row, int col, int nFromIndex, int nToIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_moveContent(swigCPtr, row, col, nFromIndex, nToIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteContent(int row, int col)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteContent__SWIG_0(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteContent(int row, int col, int nIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteContent__SWIG_1(swigCPtr, row, col, nIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteContent(OdCellRange range)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_deleteContent__SWIG_2(swigCPtr, OdCellRange.getCPtr(range));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_CellContentType contentType(int row, int col)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_contentType__SWIG_0(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellContentType)result;
	}

	public OdDb_CellContentType contentType(int row, int col, int nIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_contentType__SWIG_1(swigCPtr, row, col, nIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellContentType)result;
	}

	public OdValue value(int row, int col, int nContent)
	{
		OdValue result = new OdValue(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_value__SWIG_1(swigCPtr, row, col, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdValue value(int row, int col, int nContent, OdValue_FormatOption nOption)
	{
		OdValue result = new OdValue(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_value__SWIG_2(swigCPtr, row, col, nContent, (int)nOption), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setValue(int row, int col, int nContent, OdValue val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setValue__SWIG_2(swigCPtr, row, col, nContent, OdValue.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setValue(int row, int col, int nContent, OdValue val, OdValue_ParseOption nOption)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setValue__SWIG_3(swigCPtr, row, col, nContent, OdValue.getCPtr(val), (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setValue(int row, int col, int nContent, string sText, OdValue_ParseOption nOption)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setValue__SWIG_4(swigCPtr, row, col, nContent, sText, (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string dataFormat(int row, int col)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_dataFormat__SWIG_0(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string dataFormat(int row, int col, int nContent)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_dataFormat__SWIG_1(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDataFormat(int row, int col, string sFormat)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataFormat__SWIG_0(swigCPtr, row, col, sFormat);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDataFormat(int row, int col, int nContent, string sFormat)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataFormat__SWIG_1(swigCPtr, row, col, nContent, sFormat);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string textString(int row, int col, int nContent)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textString__SWIG_1(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string textString(int row, int col, int nContent, OdValue_FormatOption nOption)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textString__SWIG_2(swigCPtr, row, col, nContent, (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string textString(int row, int col, OdValue_FormatOption nOption)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textString__SWIG_3(swigCPtr, row, col, (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextString(int row, int col, int nContent, string text)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextString__SWIG_1(swigCPtr, row, col, nContent, text);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasFormula(int row, int col, int nContent)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_hasFormula(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getFormula(int row, int col, int nContent)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getFormula(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFormula(int row, int col, int nContent, string pszFormula)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setFormula(swigCPtr, row, col, nContent, pszFormula);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId fieldId(int row, int col, int nContent)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_fieldId__SWIG_1(swigCPtr, row, col, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFieldId(int row, int col, int nContent, OdDbObjectId fieldId, OdDb_CellOption nFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setFieldId__SWIG_1(swigCPtr, row, col, nContent, OdDbObjectId.getCPtr(fieldId), (int)nFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId blockTableRecordId(int row, int col, int nContent)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_blockTableRecordId__SWIG_1(swigCPtr, row, col, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBlockTableRecordId(int row, int col, int nContent, OdDbObjectId blkId, bool autoFit)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBlockTableRecordId__SWIG_2(swigCPtr, row, col, nContent, OdDbObjectId.getCPtr(blkId), autoFit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getBlockAttributeValue(int row, int col, int nContent, OdDbObjectId attdefId)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getBlockAttributeValue__SWIG_1(swigCPtr, row, col, nContent, OdDbObjectId.getCPtr(attdefId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBlockAttributeValue(int row, int col, int nContent, OdDbObjectId attdefId, string atrValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setBlockAttributeValue__SWIG_1(swigCPtr, row, col, nContent, OdDbObjectId.getCPtr(attdefId), atrValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int getCustomData(int row, int col)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getCustomData__SWIG_0(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCustomData(int row, int col, int nData)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setCustomData__SWIG_0(swigCPtr, row, col, nData);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue getCustomData(int row, int col, string sKey)
	{
		OdValue result = new OdValue(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getCustomData__SWIG_1(swigCPtr, row, col, sKey), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCustomData(int row, int col, string sKey, OdValue pData)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setCustomData__SWIG_1(swigCPtr, row, col, sKey, OdValue.getCPtr(pData));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string cellStyle(int row, int col)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_cellStyle(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCellStyle(int row, int col, string sCellStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setCellStyle(swigCPtr, row, col, sCellStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double margin(int row, int col, OdDb_CellMargin nMargin)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_margin(swigCPtr, row, col, (int)nMargin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMargin(int row, int col, OdDb_CellMargin nMargins, double fMargin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setMargin(swigCPtr, row, col, (int)nMargins, fMargin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d attachmentPoint(int row, int col, int content)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_attachmentPoint__SWIG_1(swigCPtr, row, col, content), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmColor contentColor(int row, int col, int nContent)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_contentColor__SWIG_3(swigCPtr, row, col, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setContentColor(int row, int col, int nContent, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setContentColor__SWIG_3(swigCPtr, row, col, nContent, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDataType(int row, int col, int nContent, out OdValue_DataType nDataType, out OdValue_UnitType nUnitType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getDataType__SWIG_2(swigCPtr, row, col, nContent, out nDataType, out nUnitType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDataType(int row, int col, int nContent, OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataType__SWIG_3(swigCPtr, row, col, nContent, (int)nDataType, (int)nUnitType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId textStyle(int row, int col, int nContent)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textStyle__SWIG_3(swigCPtr, row, col, nContent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextStyle(int row, int col, int nContent, OdDbObjectId id)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextStyle__SWIG_3(swigCPtr, row, col, nContent, OdDbObjectId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double textHeight(int row, int col, int nContent)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_textHeight__SWIG_3(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextHeight(int row, int col, int nContent, double height)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setTextHeight__SWIG_3(swigCPtr, row, col, nContent, height);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new double rotation()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_rotation__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double rotation(int row, int col, int nContent)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_rotation__SWIG_1(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setRotation(double fAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setRotation__SWIG_0(swigCPtr, fAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRotation(int row, int col, int nContent, double fAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setRotation__SWIG_1(swigCPtr, row, col, nContent, fAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isAutoScale(int row, int col, int nContent)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isAutoScale__SWIG_1(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAutoScale(int row, int col, int nContent, bool autoFit)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setAutoScale__SWIG_1(swigCPtr, row, col, nContent, autoFit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double scale(int row, int col, int nContent)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_scale(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setScale(int row, int col, int nContent, double scale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setScale(swigCPtr, row, col, nContent, scale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_CellContentLayout contentLayout(int row, int col)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_contentLayout(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellContentLayout)result;
	}

	public void setContentLayout(int row, int col, OdDb_CellContentLayout nLayout)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setContentLayout(swigCPtr, row, col, (int)nLayout);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMergeAllEnabled(int row, int col)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isMergeAllEnabled(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void enableMergeAll(int row, int col, bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_enableMergeAll(swigCPtr, row, col, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_CellProperty getOverride(int row, int col, int nContent)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getOverride__SWIG_0(swigCPtr, row, col, nContent);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CellProperty)result;
	}

	public OdDb_GridProperty getOverride(int row, int col, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getOverride__SWIG_1(swigCPtr, row, col, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_GridProperty)result;
	}

	public void setOverride(int row, int col, int nContent, OdDb_CellProperty nOverride)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setOverride__SWIG_0(swigCPtr, row, col, nContent, (int)nOverride);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOverride(int row, int col, OdDb_GridLineType nGridLineType, OdDb_GridProperty nOverride)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setOverride__SWIG_1(swigCPtr, row, col, (int)nGridLineType, (int)nOverride);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeAllOverrides(int row, int col)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_removeAllOverrides(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_GridLineStyle gridLineStyle(int row, int col, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridLineStyle(swigCPtr, row, col, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_GridLineStyle)result;
	}

	public void setGridLineStyle(int row, int col, OdDb_GridLineType nGridLineTypes, OdDb_GridLineStyle nLineStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridLineStyle(swigCPtr, row, col, (int)nGridLineTypes, (int)nLineStyle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public LineWeight gridLineWeight(int row, int col, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridLineWeight__SWIG_3(swigCPtr, row, col, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void setGridLineWeight(int row, int col, OdDb_GridLineType nGridLineTypes, LineWeight nLineWeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridLineWeight__SWIG_2(swigCPtr, row, col, (int)nGridLineTypes, (int)nLineWeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId gridLinetype(int row, int col, OdDb_GridLineType nGridLineType)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridLinetype(swigCPtr, row, col, (int)nGridLineType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGridLinetype(int row, int col, OdDb_GridLineType nGridLineTypes, OdDbObjectId idLinetype)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridLinetype(swigCPtr, row, col, (int)nGridLineTypes, OdDbObjectId.getCPtr(idLinetype));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor gridColor(int row, int col, OdDb_GridLineType nGridLineType)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridColor__SWIG_3(swigCPtr, row, col, (int)nGridLineType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGridColor(int row, int col, OdDb_GridLineType nGridlineTypes, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridColor__SWIG_2(swigCPtr, row, col, (int)nGridlineTypes, OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDb_Visibility gridVisibility(int row, int col, OdDb_GridLineType nGridLineType)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridVisibility__SWIG_3(swigCPtr, row, col, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	public void setGridVisibility(int row, int col, OdDb_GridLineType nGridLineTypes, OdDb_Visibility nVisibility)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridVisibility__SWIG_2(swigCPtr, row, col, (int)nGridLineTypes, (int)nVisibility);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double gridDoubleLineSpacing(int row, int col, OdDb_GridLineType nGridLineType)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_gridDoubleLineSpacing(swigCPtr, row, col, (int)nGridLineType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGridDoubleLineSpacing(int row, int col, OdDb_GridLineType nGridLineTypes, double fSpacing)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridDoubleLineSpacing(swigCPtr, row, col, (int)nGridLineTypes, fSpacing);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getGridProperty(int row, int col, OdDb_GridLineType nGridLineType, OdGridProperty gridProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getGridProperty(swigCPtr, row, col, (int)nGridLineType, OdGridProperty.getCPtr(gridProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGridProperty(int row, int col, OdDb_GridLineType nGridLineTypes, OdGridProperty gridProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridProperty__SWIG_0(swigCPtr, row, col, (int)nGridLineTypes, OdGridProperty.getCPtr(gridProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGridProperty(OdCellRange rangeIn, OdDb_GridLineType nGridLineTypes, OdGridProperty gridProp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setGridProperty__SWIG_1(swigCPtr, OdCellRange.getCPtr(rangeIn), (int)nGridLineTypes, OdGridProperty.getCPtr(gridProp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLinked(int row, int col)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isLinked(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getDataLink(int row, int col)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getDataLink__SWIG_0(swigCPtr, row, col), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDataLink getDataLink(int row, int col, OdDb_OpenMode mode)
	{
		OdDbDataLink rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataLink>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getDataLink__SWIG_1(swigCPtr, row, col, (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public int getDataLink(OdCellRange pRange, OdDbObjectIdArray dataLinkIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getDataLink__SWIG_2(swigCPtr, OdCellRange.getCPtr(pRange), OdDbObjectIdArray.getCPtr(dataLinkIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDataLink(int row, int col, OdDbObjectId idDataLink, bool bUpdate)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataLink__SWIG_0(swigCPtr, row, col, OdDbObjectId.getCPtr(idDataLink), bUpdate);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDataLink(OdCellRange range, OdDbObjectId idDataLink, bool bUpdate)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setDataLink__SWIG_1(swigCPtr, OdCellRange.getCPtr(range), OdDbObjectId.getCPtr(idDataLink), bUpdate);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCellRange getDataLinkRange(int row, int col)
	{
		OdCellRange result = new OdCellRange(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getDataLinkRange(swigCPtr, row, col), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void removeDataLink(int row, int col)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_removeDataLink__SWIG_0(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeDataLink()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_removeDataLink__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void updateDataLink(int row, int col, OdDb_UpdateDirection nDir, OdDb_UpdateOption nOption)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_updateDataLink__SWIG_0(swigCPtr, row, col, (int)nDir, (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void updateDataLink(OdDb_UpdateDirection nDir, OdDb_UpdateOption nOption)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_updateDataLink__SWIG_1(swigCPtr, (int)nDir, (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getColumnName(int nIndex)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getColumnName(swigCPtr, nIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColumnName(int nIndex, string sName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setColumnName(swigCPtr, nIndex, sName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getToolTip(int row, int col)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getToolTip(swigCPtr, row, col);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setToolTip(int row, int col, string sToolTip)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_setToolTip(swigCPtr, row, col, sToolTip);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyFrom(OdRxObject pSource)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_copyFrom__SWIG_0(swigCPtr, OdRxObject.getCPtr(pSource));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFrom(OdDbLinkedTableData pSrc, OdDb_TableCopyOption nOption)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_copyFrom__SWIG_1(swigCPtr, OdDbLinkedTableData.getCPtr(pSrc), (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFrom(OdDbLinkedTableData pSrc, OdDb_TableCopyOption nOption, OdCellRange srcRange, OdCellRange targetRange, OdCellRange pNewTargetRangeOut)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_copyFrom__SWIG_2(swigCPtr, OdDbLinkedTableData.getCPtr(pSrc), (int)nOption, OdCellRange.getCPtr(srcRange), OdCellRange.getCPtr(targetRange), OdCellRange.getCPtr(pNewTargetRangeOut));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFrom(OdDbTable pSrc, OdDb_TableCopyOption nOption, OdCellRange srcRange, OdCellRange targetRange, OdCellRange pNewTargetRangeOut)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_copyFrom__SWIG_3(swigCPtr, getCPtr(pSrc), (int)nOption, OdCellRange.getCPtr(srcRange), OdCellRange.getCPtr(targetRange), OdCellRange.getCPtr(pNewTargetRangeOut));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void appendToOwner(OdDbIdPair idPair, OdDbObject pOwnerObject, ref OdDbIdMapping ownerIdMap)
	{
		IntPtr jarg = ((ownerIdMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(ownerIdMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_appendToOwner(swigCPtr, OdDbIdPair.getCPtr(idPair), OdDbObject.getCPtr(pOwnerObject), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				ownerIdMap = null;
			}
			if (jarg != intPtr)
			{
				ownerIdMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public bool isRegenerateTableSuppressed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_isRegenerateTableSuppressed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void suppressRegenerateTable(bool bSuppress)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_suppressRegenerateTable(swigCPtr, bSuppress);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createTemplate(OdDbTableTemplate target, OdDb_TableCopyOption nCopyOption)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_createTemplate(swigCPtr, OdDbTableTemplate.getCPtr(target), (int)nCopyOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult subErase(bool erasing)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_subErase(swigCPtr, erasing);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public new virtual void subHighlight(bool bDoIt, OdDbFullSubentPath pSubId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_subHighlight__SWIG_0(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void subHighlight(bool bDoIt)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_subHighlight__SWIG_1(swigCPtr, bDoIt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void subHighlight()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_subHighlight__SWIG_2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int getSubTablesInfo(OdArray_OdDbSubTable_OdObjectsAllocator subTables)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getSubTablesInfo(swigCPtr, OdArray_OdDbSubTable_OdObjectsAllocator.getCPtr(subTables));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbTableIterator getIterator()
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getIterator__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbTableIterator getIterator(OdCellRange pRange, OdDb_TableIteratorOption nOption)
	{
		OdDbTableIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTableIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getIterator__SWIG_1(swigCPtr, OdCellRange.getCPtr(pRange), (int)nOption), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void getIndicatorSize(out double dWidth, out double dHeight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getIndicatorSize(swigCPtr, out dWidth, out dHeight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int getContentBounding(uint row, uint col, int content, OdGePoint3dArray pts)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getContentBounding(swigCPtr, row, col, content, OdGePoint3dArray.getCPtr(pts).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void applyPartialUndo(OdDbDwgFiler pUndoFiler, OdRxClass pClass)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_applyPartialUndo(swigCPtr, OdDbDwgFiler.getCPtr(pUndoFiler), OdRxClass.getCPtr(pClass));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override bool SubWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void SubViewportDraw(OdGiViewportDraw pVd)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(pVd));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult SubTransformBy(OdGeMatrix3d xfm)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult SubGetTransformedCopy(OdGeMatrix3d xfm, ref OdDbEntity pCopy)
	{
		IntPtr jarg = ((pCopy == null) ? IntPtr.Zero : OdDbEntity.getCPtr(pCopy).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubGetTransformedCopy(swigCPtr, OdGeMatrix3d.getCPtr(xfm), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pCopy = null;
			}
			else if (jarg != intPtr)
			{
				pCopy = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public new virtual OdResult SubGetGeomExtents(OdGeExtents3d extents)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubGetGeomExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult SubExplode(OdRxObjectPtrArray entitySet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubExplode(swigCPtr, OdRxObjectPtrArray.getCPtr(entitySet).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void SubHighlight(bool bDoIt, OdDbFullSubentPath pSubId, bool highlightAll)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubHighlight(swigCPtr, bDoIt, OdDbFullSubentPath.getCPtr(pSubId), highlightAll);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObject SubWblockClone(ref OdDbIdMapping idMap, OdDbObject owner, bool bPrimary)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_SubWblockClone(swigCPtr, ref jarg, OdDbObject.getCPtr(owner), bPrimary), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTable_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
