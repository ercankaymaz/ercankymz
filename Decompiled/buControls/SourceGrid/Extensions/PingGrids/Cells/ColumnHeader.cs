using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

namespace SourceGrid.Extensions.PingGrids.Cells;

public class ColumnHeader : SourceGrid.Cells.Virtual.ColumnHeader
{
	public ColumnHeader(string pCaption)
	{
		base.Model.AddModel(new ValueModel(pCaption));
	}
}
