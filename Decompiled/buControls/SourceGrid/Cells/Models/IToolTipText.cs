namespace SourceGrid.Cells.Models;

public interface IToolTipText : IModel
{
	string GetToolTipText(CellContext cellContext);
}
