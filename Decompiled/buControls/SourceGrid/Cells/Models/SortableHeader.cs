using DevAge.Drawing;

namespace SourceGrid.Cells.Models;

public class SortableHeader : IModel, ISortableHeader
{
	private SortStatus sortStatus_0 = new SortStatus(HeaderSortStyle.None, null);

	public SortStatus SortStatus
	{
		get
		{
			return sortStatus_0;
		}
		set
		{
			sortStatus_0 = value;
		}
	}

	public SortStatus GetSortStatus(CellContext cellContext)
	{
		return sortStatus_0;
	}

	public void SetSortMode(CellContext cellContext, HeaderSortStyle pStyle)
	{
		sortStatus_0.Style = pStyle;
	}
}
