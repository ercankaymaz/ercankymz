using SourceGrid.Cells.Virtual;

namespace SourceGrid.Extensions.PingGrids.Cells;

public class CheckBox : SourceGrid.Cells.Virtual.CheckBox
{
	public CheckBox()
	{
		base.Model.AddModel(new PingGridValueModel());
	}
}
