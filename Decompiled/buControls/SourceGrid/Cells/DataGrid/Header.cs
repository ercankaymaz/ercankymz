using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

namespace SourceGrid.Cells.DataGrid;

public class Header : SourceGrid.Cells.Virtual.Header
{
	public Header()
	{
		base.Model.AddModel(new NullValueModel());
	}
}
