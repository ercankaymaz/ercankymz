#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDataGridViewRedirect : Storage
{
	private PaletteDoubleRedirect _background;

	private PaletteDataGridViewTripleRedirect _dataCell;

	private PaletteDataGridViewTripleRedirect _headerColumn;

	private PaletteDataGridViewTripleRedirect _headerRow;

	[Browsable(false)]
	public override bool IsDefault => Background.IsDefault && DataCell.IsDefault && HeaderColumn.IsDefault && HeaderRow.IsDefault;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteBackStyle BackStyle
	{
		get
		{
			return _background.BackStyle;
		}
		set
		{
			_background.BackStyle = value;
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining data grid view background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteBack Background => _background.Back;

	internal IPaletteDouble BackgroundDouble => _background;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining data cell appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteDataGridViewTripleRedirect DataCell => _dataCell;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining header column cell appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteDataGridViewTripleRedirect HeaderColumn => _headerColumn;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining header row cell appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteDataGridViewTripleRedirect HeaderRow => _headerRow;

	public PaletteDataGridViewRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_background = new PaletteDoubleRedirect(redirect, PaletteBackStyle.GridBackgroundList, PaletteBorderStyle.GridDataCellList, needPaint);
		_dataCell = new PaletteDataGridViewTripleRedirect(redirect, PaletteBackStyle.GridDataCellList, PaletteBorderStyle.GridDataCellList, PaletteContentStyle.GridDataCellList, needPaint);
		_headerColumn = new PaletteDataGridViewTripleRedirect(redirect, PaletteBackStyle.GridHeaderColumnList, PaletteBorderStyle.GridHeaderColumnList, PaletteContentStyle.GridHeaderColumnList, needPaint);
		_headerRow = new PaletteDataGridViewTripleRedirect(redirect, PaletteBackStyle.GridHeaderRowList, PaletteBorderStyle.GridHeaderRowList, PaletteContentStyle.GridHeaderRowList, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_background.SetRedirector(redirect);
		_dataCell.SetRedirector(redirect);
		_headerColumn.SetRedirector(redirect);
		_headerRow.SetRedirector(redirect);
	}

	public void SetGridStyles(GridStyle headerColumn, GridStyle headerRow, GridStyle dataCell)
	{
		switch (headerColumn)
		{
		case GridStyle.List:
			_headerColumn.SetStyles(PaletteBackStyle.GridHeaderColumnList, PaletteBorderStyle.GridHeaderColumnList, PaletteContentStyle.GridHeaderColumnList);
			break;
		case GridStyle.Sheet:
			_headerColumn.SetStyles(PaletteBackStyle.GridHeaderColumnSheet, PaletteBorderStyle.GridHeaderColumnSheet, PaletteContentStyle.GridHeaderColumnSheet);
			break;
		case GridStyle.Custom1:
			_headerColumn.SetStyles(PaletteBackStyle.GridHeaderColumnCustom1, PaletteBorderStyle.GridHeaderColumnCustom1, PaletteContentStyle.GridHeaderColumnCustom1);
			break;
		}
		switch (headerRow)
		{
		case GridStyle.List:
			_headerRow.SetStyles(PaletteBackStyle.GridHeaderRowList, PaletteBorderStyle.GridHeaderRowList, PaletteContentStyle.GridHeaderRowList);
			break;
		case GridStyle.Sheet:
			_headerRow.SetStyles(PaletteBackStyle.GridHeaderRowSheet, PaletteBorderStyle.GridHeaderRowSheet, PaletteContentStyle.GridHeaderRowSheet);
			break;
		case GridStyle.Custom1:
			_headerRow.SetStyles(PaletteBackStyle.GridHeaderRowCustom1, PaletteBorderStyle.GridHeaderRowCustom1, PaletteContentStyle.GridHeaderRowCustom1);
			break;
		}
		switch (dataCell)
		{
		case GridStyle.List:
			_dataCell.SetStyles(PaletteBackStyle.GridDataCellList, PaletteBorderStyle.GridDataCellList, PaletteContentStyle.GridDataCellList);
			break;
		case GridStyle.Sheet:
			_dataCell.SetStyles(PaletteBackStyle.GridDataCellSheet, PaletteBorderStyle.GridDataCellSheet, PaletteContentStyle.GridDataCellSheet);
			break;
		case GridStyle.Custom1:
			_dataCell.SetStyles(PaletteBackStyle.GridDataCellCustom1, PaletteBorderStyle.GridDataCellCustom1, PaletteContentStyle.GridDataCellCustom1);
			break;
		}
	}

	private bool ShouldSerializeBackground()
	{
		return !_background.IsDefault;
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
