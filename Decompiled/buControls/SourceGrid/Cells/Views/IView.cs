using System;
using System.Drawing;
using DevAge.Drawing;

namespace SourceGrid.Cells.Views;

public interface IView : ICloneable
{
	Font Font { get; set; }

	bool WordWrap { get; set; }

	DevAge.Drawing.ContentAlignment TextAlignment { get; set; }

	IBorder Border { get; set; }

	Color BackColor { get; set; }

	Color ForeColor { get; set; }

	Font GetDrawingFont(GridVirtual grid);

	void DrawCell(CellContext cellContext, GraphicsCache graphics, RectangleF rectangle);

	Size Measure(CellContext cellContext, Size maxLayoutArea);
}
