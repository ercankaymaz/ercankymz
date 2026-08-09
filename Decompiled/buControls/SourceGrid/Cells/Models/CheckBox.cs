using DevAge.Drawing;

namespace SourceGrid.Cells.Models;

public class CheckBox : IModel, ICheckBox
{
	private string string_0 = null;

	public string Caption
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public CheckBoxStatus GetCheckBoxStatus(CellContext cellContext)
	{
		bool checkEnable = false;
		if (cellContext.Cell.Editor != null && cellContext.Cell.Editor.EnableEdit)
		{
			checkEnable = true;
		}
		object value = cellContext.Cell.Model.ValueModel.GetValue(cellContext);
		if (value != null)
		{
			if (!(value is bool))
			{
				throw new SourceGridException("Cell value not supported for this cell. Expected bool value or null.");
			}
			return new CheckBoxStatus(checkEnable, (bool)value, string_0);
		}
		return new CheckBoxStatus(checkEnable, CheckBoxState.Undefined, string_0);
	}

	public void SetCheckedValue(CellContext cellContext, bool? pChecked)
	{
		if (cellContext.Cell.Editor != null && cellContext.Cell.Editor.EnableEdit)
		{
			cellContext.Cell.Editor.SetCellValue(cellContext, pChecked);
		}
	}
}
