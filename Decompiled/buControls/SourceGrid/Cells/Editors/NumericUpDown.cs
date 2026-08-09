using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class NumericUpDown : EditorControlBase
{
	public new System.Windows.Forms.NumericUpDown Control => (System.Windows.Forms.NumericUpDown)base.Control;

	public NumericUpDown()
		: base(typeof(decimal))
	{
	}

	public NumericUpDown(Type p_CellType, decimal p_Maximum, decimal p_Minimum, decimal p_Increment)
		: base(p_CellType)
	{
		if (!(p_CellType == null) && !(p_CellType == typeof(int)) && !(p_CellType == typeof(long)) && !(p_CellType == typeof(decimal)))
		{
			throw new SourceGridException("Invalid CellType expected long, int or decimal");
		}
		Control.Maximum = p_Maximum;
		Control.Minimum = p_Minimum;
		Control.Increment = p_Increment;
	}

	protected override Control CreateControl()
	{
		System.Windows.Forms.NumericUpDown numericUpDown = new System.Windows.Forms.NumericUpDown();
		numericUpDown.BorderStyle = BorderStyle.None;
		return numericUpDown;
	}

	public override void SetEditValue(object editValue)
	{
		decimal value;
		if (!(editValue is decimal))
		{
			if (!(editValue is long))
			{
				if (!(editValue is int))
				{
					if (editValue != null)
					{
						throw new SourceGridException("Invalid value, expected Decimal, Int or Long");
					}
					value = Control.Minimum;
				}
				else
				{
					value = (int)editValue;
				}
			}
			else
			{
				value = (long)editValue;
			}
		}
		else
		{
			value = (decimal)editValue;
		}
		_ = Control.Value;
		Control.Value = value;
	}

	public override object GetEditedValue()
	{
		if (!(base.ValueType == null))
		{
			if (!(base.ValueType == typeof(decimal)))
			{
				if (!(base.ValueType == typeof(int)))
				{
					if (!(base.ValueType == typeof(long)))
					{
						throw new SourceGridException("Invalid type of the cell expected decimal, long or int");
					}
					return (long)Control.Value;
				}
				return (int)Control.Value;
			}
			return Control.Value;
		}
		return Control.Value;
	}

	protected override void OnSendCharToEditor(char key)
	{
	}
}
