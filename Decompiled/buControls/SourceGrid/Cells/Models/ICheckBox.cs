namespace SourceGrid.Cells.Models;

public interface ICheckBox : IModel
{
	CheckBoxStatus GetCheckBoxStatus(CellContext cellContext);

	void SetCheckedValue(CellContext cellContext, bool? pChecked);
}
