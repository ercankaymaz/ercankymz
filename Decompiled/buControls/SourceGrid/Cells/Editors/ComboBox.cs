using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class ComboBox : EditorControlBase
{
	public new DevAgeComboBox Control => (DevAgeComboBox)base.Control;

	public ComboBox(Type p_Type)
		: base(p_Type)
	{
	}

	public ComboBox(Type p_Type, ICollection p_StandardValues, bool p_StandardValueExclusive)
		: base(p_Type)
	{
		base.StandardValues = p_StandardValues;
		base.StandardValuesExclusive = p_StandardValueExclusive;
	}

	protected override Control CreateControl()
	{
		DevAgeComboBox devAgeComboBox = new DevAgeComboBox();
		devAgeComboBox.Validator = this;
		return devAgeComboBox;
	}

	public override void SetEditValue(object editValue)
	{
		if (!(editValue is string) || !IsStringConversionSupported() || Control.DropDownStyle != ComboBoxStyle.DropDown)
		{
			Control.SelectedIndex = -1;
			Control.Value = editValue;
			Control.SelectAll();
			return;
		}
		Control.SelectedIndex = -1;
		Control.Text = (string)editValue;
		Control.SelectionLength = 0;
		if (Control.Text == null)
		{
			Control.SelectionStart = 0;
		}
		else
		{
			Control.SelectionStart = Control.Text.Length;
		}
	}

	public override object GetEditedValue()
	{
		return Control.Value;
	}

	protected override void OnSendCharToEditor(char key)
	{
		if (Control.DropDownStyle == ComboBoxStyle.DropDown)
		{
			Control.Text = key.ToString();
			if (Control.Text != null)
			{
				Control.SelectionStart = Control.Text.Length;
			}
		}
	}
}
