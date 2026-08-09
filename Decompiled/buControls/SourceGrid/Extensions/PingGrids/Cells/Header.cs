using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

namespace SourceGrid.Extensions.PingGrids.Cells;

public class Header : SourceGrid.Cells.Virtual.Header
{
	public Header()
	{
		base.Model.AddModel(new NullValueModel());
	}
}
