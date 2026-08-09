using System.ComponentModel;
using SourceGrid.Cells.Controllers;

namespace SourceGrid;

public class DataGridCellController : ControllerBase
{
	public override void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
	{
		base.OnValueChanging(sender, e);
		if (!((DataGrid)sender.Grid).BeginEditRow(sender.Position.Row))
		{
			throw new SourceGridException("Failed to editing row " + sender.Position.Row);
		}
	}

	public override void OnEditStarting(CellContext sender, CancelEventArgs e)
	{
		base.OnEditStarting(sender, e);
		bool flag = ((DataGrid)sender.Grid).BeginEditRow(sender.Position.Row);
		e.Cancel = !flag;
	}
}
