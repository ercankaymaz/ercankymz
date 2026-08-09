using System.Drawing;

namespace SourceGrid.Cells;

public interface ICell : ICellVirtual
{
	string DisplayText { get; }

	object Value { get; set; }

	object Tag { get; set; }

	string ToolTipText { get; set; }

	System.Drawing.Image Image { get; set; }

	Grid Grid { get; }

	GridColumn Column { get; }

	GridRow Row { get; }

	Range Range { get; }

	int ColumnSpan { get; set; }

	int RowSpan { get; set; }

	void BindToGrid(Grid p_grid, Position p_Position);

	void UnBindToGrid();

	void SetSpan(int rowSpan, int colSpan);
}
