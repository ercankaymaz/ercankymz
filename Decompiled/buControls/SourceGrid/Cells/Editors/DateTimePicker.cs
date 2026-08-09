using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class DateTimePicker : EditorControlBase
{
	public new System.Windows.Forms.DateTimePicker Control => (System.Windows.Forms.DateTimePicker)base.Control;

	public DateTimePicker()
		: base(typeof(DateTime))
	{
	}

	protected override Control CreateControl()
	{
		System.Windows.Forms.DateTimePicker dateTimePicker = new System.Windows.Forms.DateTimePicker();
		dateTimePicker.Format = DateTimePickerFormat.Short;
		dateTimePicker.ShowCheckBox = base.AllowNull;
		return dateTimePicker;
	}

	protected override void OnChanged(EventArgs e)
	{
		base.OnChanged(e);
		if (Control != null)
		{
			Control.ShowCheckBox = base.AllowNull;
		}
	}

	protected override void OnStartingEdit(CellContext cellContext, Control editorControl)
	{
		base.OnStartingEdit(cellContext, editorControl);
		System.Windows.Forms.DateTimePicker dateTimePicker = (System.Windows.Forms.DateTimePicker)editorControl;
		dateTimePicker.Font = cellContext.Cell.View.Font;
	}

	public override void SetEditValue(object editValue)
	{
		if (!(editValue is DateTime))
		{
			if (editValue != null)
			{
				throw new SourceGridException("Invalid edit value, expected DateTime");
			}
			Control.Checked = false;
		}
		else
		{
			Control.Value = (DateTime)editValue;
		}
	}

	public override object GetEditedValue()
	{
		if (!Control.Checked)
		{
			return null;
		}
		return Control.Value;
	}

	protected override void OnSendCharToEditor(char key)
	{
	}
}
