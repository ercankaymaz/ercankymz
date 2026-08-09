using SourceGrid.Cells.Virtual;

namespace SourceGrid.Cells.DataGrid;

public class Link : SourceGrid.Cells.Virtual.Link
{
	public Link()
	{
		base.Model.AddModel(new DataGridValueModel());
	}
}
