using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Entities;

namespace ACadSharp.Objects;

[DxfSubClass("AcDbFormattedTableData")]
public abstract class FormattedTableData : LinkedTableData
{
	public override string SubclassMarker => "AcDbFormattedTableData";

	public List<TableEntity.CellRange> MergedCellRanges { get; set; } = new List<TableEntity.CellRange>();

	public TableEntity.CellStyle CellStyleOverride { get; set; } = new TableEntity.CellStyle();
}
