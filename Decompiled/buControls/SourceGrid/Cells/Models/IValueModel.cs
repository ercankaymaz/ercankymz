namespace SourceGrid.Cells.Models;

public interface IValueModel : IModel
{
	object GetValue(CellContext cellContext);

	void SetValue(CellContext cellContext, object p_Value);
}
