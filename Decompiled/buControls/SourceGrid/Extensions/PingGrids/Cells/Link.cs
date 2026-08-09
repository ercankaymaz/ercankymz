using SourceGrid.Cells.Virtual;

namespace SourceGrid.Extensions.PingGrids.Cells;

public class Link : SourceGrid.Cells.Virtual.Link
{
	public Link()
	{
		base.Model.AddModel(new PingGridValueModel());
	}
}
