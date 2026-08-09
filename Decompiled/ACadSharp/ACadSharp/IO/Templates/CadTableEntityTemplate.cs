using System;
using System.Collections.Generic;
using ACadSharp.Entities;
using CSUtilities.Extensions;

namespace ACadSharp.IO.Templates;

internal class CadTableEntityTemplate : CadInsertTemplate
{
	internal class CadCellStyleTemplate : CadTableCellContentFormatTemplate
	{
		public List<Tuple<TableEntity.CellBorder, ulong>> BorderLinetypePairs { get; set; } = new List<Tuple<TableEntity.CellBorder, ulong>>();

		public CadCellStyleTemplate()
			: base(new TableEntity.ContentFormat())
		{
		}

		public CadCellStyleTemplate(TableEntity.CellStyle style)
			: base(style)
		{
		}
	}

	internal class CadTableAttributeTemplate : ICadTemplate
	{
		private TableEntity.TableAttribute _tableAtt;

		public ulong? AttDefHandle { get; internal set; }

		public CadTableAttributeTemplate(TableEntity.TableAttribute tableAtt)
		{
			_tableAtt = tableAtt;
		}

		public void Build(CadDocumentBuilder builder)
		{
			throw new NotImplementedException();
		}
	}

	internal class CadTableCellContentFormatTemplate : ICadTemplate
	{
		public TableEntity.ContentFormat Format { get; }

		public ulong? TextStyleHandle { get; internal set; }

		public CadTableCellContentFormatTemplate(TableEntity.ContentFormat format)
		{
			Format = format;
		}

		public void Build(CadDocumentBuilder builder)
		{
			throw new NotImplementedException();
		}
	}

	internal class CadTableCellContentTemplate : ICadTemplate
	{
		public ulong? BlockRecordHandle { get; set; }

		public TableEntity.CellContent Content { get; }

		public ulong? FieldHandle { get; set; }

		public CadTableCellContentTemplate(TableEntity.CellContent content)
		{
			Content = content;
		}

		public void Build(CadDocumentBuilder builder)
		{
			throw new NotImplementedException();
		}
	}

	internal class CadTableCellTemplate : ICadTemplate
	{
		public ulong? ValueHandle { get; set; }

		public TableEntity.Cell Cell { get; }

		public List<CadTableCellContentTemplate> ContentTemplates { get; } = new List<CadTableCellContentTemplate>();

		public double? FormatTextHeight { get; set; }

		public int StyleId { get; internal set; }

		public ulong? UnknownHandle { get; internal set; }

		public string CellText { get; internal set; }

		public HashSet<(ulong, string)> AttributeHandles { get; } = new HashSet<(ulong, string)>();

		public ulong? TextStyleOverrideHandle { get; set; }

		public CadTableCellTemplate(TableEntity.Cell cell)
		{
			Cell = cell;
		}

		public void Build(CadDocumentBuilder builder)
		{
			builder.TryGetCadObject<CadObject>(ValueHandle, out var _);
			CellText.IsNullOrEmpty();
		}
	}

	private int _currCellIndex;

	public ulong? BlockOwnerHandle { get; set; }

	public TableEntity.Cell CurrentCell => CurrentCellTemplate.Cell;

	public CadTableCellTemplate CurrentCellTemplate { get; private set; }

	public double? HorizontalMargin { get; set; }

	public ulong? NullHandle { get; internal set; }

	public ulong? StyleHandle { get; set; }

	public TableEntity TableEntity => base.CadObject as TableEntity;

	public List<CadTableCellTemplate> CadTableCellTemplates { get; } = new List<CadTableCellTemplate>();

	public CadTableEntityTemplate()
		: base(new TableEntity())
	{
	}

	public CadTableEntityTemplate(TableEntity table)
		: base(table)
	{
	}

	public void CreateCell(TableEntity.CellType type)
	{
		int index = _currCellIndex / TableEntity.Columns.Count;
		TableEntity.Cell cell = new TableEntity.Cell();
		cell.Type = type;
		TableEntity.Rows[index].Cells.Add(cell);
		CurrentCellTemplate = new CadTableCellTemplate(cell);
		CadTableCellTemplates.Add(CurrentCellTemplate);
		_currCellIndex++;
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (CadTableCellTemplate cadTableCellTemplate in CadTableCellTemplates)
		{
			cadTableCellTemplate.Build(builder);
		}
	}
}
