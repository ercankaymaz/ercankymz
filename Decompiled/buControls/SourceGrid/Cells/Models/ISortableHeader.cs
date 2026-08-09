using DevAge.Drawing;

namespace SourceGrid.Cells.Models;

public interface ISortableHeader : IModel
{
	SortStatus GetSortStatus(CellContext cellContext);

	void SetSortMode(CellContext cellContext, HeaderSortStyle pStyle);
}
