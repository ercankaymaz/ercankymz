using SourceGrid.Cells.Virtual;

namespace SourceGrid.Extensions.PingGrids.Cells;

public class Image : SourceGrid.Cells.Virtual.Image
{
	public Image()
	{
		base.Model.AddModel(new PingGridValueModel());
	}
}
