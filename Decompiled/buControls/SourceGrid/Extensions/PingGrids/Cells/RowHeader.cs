using SourceGrid.Cells.Virtual;

namespace SourceGrid.Extensions.PingGrids.Cells;

public class RowHeader : SourceGrid.Cells.Virtual.RowHeader
{
	public RowHeader()
	{
		base.Model.AddModel(new DataGridRowHeaderModel());
	}
}
