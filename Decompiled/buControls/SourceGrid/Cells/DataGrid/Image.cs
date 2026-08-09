using SourceGrid.Cells.Virtual;

namespace SourceGrid.Cells.DataGrid;

public class Image : SourceGrid.Cells.Virtual.Image
{
	public Image()
	{
		base.Model.AddModel(new DataGridValueModel());
	}
}
