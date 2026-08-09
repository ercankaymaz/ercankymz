using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

namespace SourceGrid.Cells.DataGrid;

public class ColumnHeader : SourceGrid.Cells.Virtual.ColumnHeader
{
	public ColumnHeader(string pCaption)
	{
		base.Model.AddModel(new ValueModel(pCaption));
	}
}
