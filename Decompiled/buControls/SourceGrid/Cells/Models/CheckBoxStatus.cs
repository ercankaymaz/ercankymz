using DevAge.Drawing;

namespace SourceGrid.Cells.Models;

public struct CheckBoxStatus
{
	private CheckBoxState checkState;

	public bool CheckEnable;

	public string Caption;

	public CheckBoxState CheckState
	{
		get
		{
			return checkState;
		}
		set
		{
			checkState = value;
		}
	}

	public bool? Checked
	{
		get
		{
			if (CheckState != CheckBoxState.Checked)
			{
				if (CheckState != CheckBoxState.Unchecked)
				{
					return null;
				}
				return false;
			}
			return true;
		}
		set
		{
			if (value.HasValue)
			{
				if (!value.Value)
				{
					CheckState = CheckBoxState.Unchecked;
				}
				else
				{
					CheckState = CheckBoxState.Checked;
				}
			}
			else
			{
				CheckState = CheckBoxState.Undefined;
			}
		}
	}

	public CheckBoxStatus(bool checkEnable, bool? bChecked, string caption)
	{
		CheckEnable = checkEnable;
		Caption = caption;
		checkState = CheckBoxState.Undefined;
		Checked = bChecked;
	}

	public CheckBoxStatus(bool checkEnable, CheckBoxState checkState, string caption)
	{
		CheckEnable = checkEnable;
		this.checkState = checkState;
		Caption = caption;
	}
}
