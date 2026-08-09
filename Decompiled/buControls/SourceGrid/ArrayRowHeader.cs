using SourceGrid.Cells.Virtual;

namespace SourceGrid;

public class ArrayRowHeader : RowHeader
{
	public ArrayRowHeader()
	{
		base.Model.AddModel(new ArrayRowHeaderModel());
		base.ResizeEnabled = false;
	}
}
