using SourceGrid.Cells.Models;
using SourceGrid.Cells.Virtual;

namespace SourceGrid;

public class ArrayHeader : Header
{
	public ArrayHeader()
	{
		base.Model.AddModel(new NullValueModel());
	}
}
