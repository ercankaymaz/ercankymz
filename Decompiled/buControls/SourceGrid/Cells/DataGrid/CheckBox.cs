using SourceGrid.Cells.Virtual;

namespace SourceGrid.Cells.DataGrid;

public class CheckBox : SourceGrid.Cells.Virtual.CheckBox
{
	public CheckBox()
	{
		base.Model.AddModel(new DataGridValueModel());
	}
}
