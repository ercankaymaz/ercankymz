#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDataGridViewCells : Storage
{
	private PaletteDataGridViewTripleStates _dataCell;

	private PaletteDataGridViewTripleStates _headerColumn;

	private PaletteDataGridViewTripleStates _headerRow;

	[Browsable(false)]
	public override bool IsDefault => DataCell.IsDefault && HeaderColumn.IsDefault && HeaderRow.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining data cell appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteDataGridViewTripleStates DataCell => _dataCell;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining header column cell appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteDataGridViewTripleStates HeaderColumn => _headerColumn;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining header row cell appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteDataGridViewTripleStates HeaderRow => _headerRow;

	public PaletteDataGridViewCells(PaletteDataGridViewRedirect inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		NeedPaint = needPaint;
		_dataCell = new PaletteDataGridViewTripleStates(inherit.DataCell, needPaint);
		_headerColumn = new PaletteDataGridViewTripleStates(inherit.HeaderColumn, needPaint);
		_headerRow = new PaletteDataGridViewTripleStates(inherit.HeaderRow, needPaint);
	}

	public virtual void PopulateFromBase(KryptonPaletteCommon common, PaletteState state, GridStyle gridStyle)
	{
		if (gridStyle == GridStyle.List)
		{
			common.StateCommon.SetStyles(PaletteBackStyle.GridDataCellList, PaletteBorderStyle.GridDataCellList, PaletteContentStyle.GridDataCellList);
		}
		else
		{
			common.StateCommon.SetStyles(PaletteBackStyle.GridDataCellSheet, PaletteBorderStyle.GridDataCellSheet, PaletteContentStyle.GridDataCellSheet);
		}
		_dataCell.PopulateFromBase(state);
		if (gridStyle == GridStyle.List)
		{
			common.StateCommon.SetStyles(PaletteBackStyle.GridHeaderColumnList, PaletteBorderStyle.GridHeaderColumnList, PaletteContentStyle.GridHeaderColumnList);
		}
		else
		{
			common.StateCommon.SetStyles(PaletteBackStyle.GridHeaderColumnSheet, PaletteBorderStyle.GridHeaderColumnSheet, PaletteContentStyle.GridHeaderColumnSheet);
		}
		_headerColumn.PopulateFromBase(state);
		if (gridStyle == GridStyle.List)
		{
			common.StateCommon.SetStyles(PaletteBackStyle.GridHeaderRowList, PaletteBorderStyle.GridHeaderRowList, PaletteContentStyle.GridHeaderRowList);
		}
		else
		{
			common.StateCommon.SetStyles(PaletteBackStyle.GridHeaderRowSheet, PaletteBorderStyle.GridHeaderRowSheet, PaletteContentStyle.GridHeaderRowSheet);
		}
		_headerRow.PopulateFromBase(state);
	}

	public virtual void SetInherit(PaletteDataGridViewRedirect inherit)
	{
		_dataCell.SetInherit(inherit.DataCell);
		_headerColumn.SetInherit(inherit.HeaderColumn);
		_headerRow.SetInherit(inherit.HeaderRow);
	}

	private bool ShouldSerializeDataCell()
	{
		return !_dataCell.IsDefault;
	}

	private bool ShouldSerializeHeaderColumn()
	{
		return !_headerColumn.IsDefault;
	}

	private bool ShouldSerializeHeaderRow()
	{
		return !_headerRow.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
