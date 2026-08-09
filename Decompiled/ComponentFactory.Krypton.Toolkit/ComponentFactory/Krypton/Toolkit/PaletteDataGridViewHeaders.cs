#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDataGridViewHeaders : Storage
{
	private PaletteDataGridViewTripleStates _headerColumn;

	private PaletteDataGridViewTripleStates _headerRow;

	[Browsable(false)]
	public override bool IsDefault => HeaderColumn.IsDefault && HeaderRow.IsDefault;

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

	public PaletteDataGridViewHeaders(PaletteDataGridViewRedirect inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		NeedPaint = needPaint;
		_headerColumn = new PaletteDataGridViewTripleStates(inherit.HeaderColumn, needPaint);
		_headerRow = new PaletteDataGridViewTripleStates(inherit.HeaderRow, needPaint);
	}

	public virtual void PopulateFromBase(KryptonPaletteCommon common, PaletteState state, GridStyle gridStyle)
	{
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
		_headerColumn.SetInherit(inherit.HeaderColumn);
		_headerRow.SetInherit(inherit.HeaderRow);
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
