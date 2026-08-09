using SourceGrid.Cells.Virtual;

namespace SourceGrid;

public class ArrayColumnHeader : ColumnHeader
{
	public ArrayColumnHeader()
	{
		base.Model.AddModel(new ArrayColumnHeaderModel());
		base.AutomaticSortEnabled = false;
		base.ResizeEnabled = false;
	}
}
