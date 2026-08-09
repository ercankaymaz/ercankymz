using System;

namespace SourceGrid.Exporter;

[Flags]
public enum ExportHTMLMode
{
	None = 0,
	HTMLAndBody = 1,
	GridBackColor = 2,
	CellBackColor = 4,
	RectangleBorder = 8,
	CellForeColor = 0x10,
	CellImages = 0x20,
	Default = 0x3F
}
