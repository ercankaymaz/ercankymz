using SourceGrid.Cells.Virtual;

namespace SourceGrid.Cells.DataGrid;

public class RowHeader : SourceGrid.Cells.Virtual.RowHeader
{
	public RowHeader()
	{
		base.Model.AddModel(new DataGridRowHeaderModel());
	}
}
