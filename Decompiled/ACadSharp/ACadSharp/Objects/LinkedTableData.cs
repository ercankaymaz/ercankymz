using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Entities;

namespace ACadSharp.Objects;

[DxfSubClass("AcDbLinkedTableData")]
public abstract class LinkedTableData : LinkedData
{
	public override string SubclassMarker => "AcDbLinkedTableData";

	public List<TableEntity.Row> Rows { get; } = new List<TableEntity.Row>();

	public List<TableEntity.Column> Columns { get; } = new List<TableEntity.Column>();
}
