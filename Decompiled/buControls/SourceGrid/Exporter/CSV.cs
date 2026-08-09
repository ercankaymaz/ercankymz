using System;
using System.Globalization;
using System.IO;
using SourceGrid.Cells;

namespace SourceGrid.Exporter;

public class CSV
{
	private string string_0;

	private string string_1;

	public string FieldSeparator
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string LineSeparator
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public CSV()
	{
		string_0 = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
		string_1 = Environment.NewLine;
	}

	public virtual void Export(GridVirtual grid, TextWriter stream)
	{
		for (int i = 0; i < grid.Rows.Count; i++)
		{
			for (int j = 0; j < grid.Columns.Count; j++)
			{
				if (j > 0)
				{
					stream.Write(string_0);
				}
				ICellVirtual cell = grid.GetCell(i, j);
				Position pPosition = new Position(i, j);
				CellContext context = new CellContext(grid, pPosition, cell);
				ExportCSVCell(context, stream);
			}
			stream.Write(string_1);
		}
	}

	protected virtual void ExportCSVCell(CellContext context, TextWriter stream)
	{
		if (context.Cell == null)
		{
			stream.Write("");
			return;
		}
		string text = context.DisplayText;
		if (text == null)
		{
			text = string.Empty;
		}
		text = text.Replace("\r\n", " ");
		text = text.Replace("\n", " ");
		text = text.Replace("\r", " ");
		stream.Write(text);
	}
}
