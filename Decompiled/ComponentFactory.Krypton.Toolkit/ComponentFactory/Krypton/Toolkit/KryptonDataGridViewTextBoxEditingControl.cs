using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class KryptonDataGridViewTextBoxEditingControl : KryptonTextBox, IDataGridViewEditingControl
{
	private DataGridView _dataGridView;

	private bool _valueChanged;

	private int _rowIndex;

	public virtual DataGridView EditingControlDataGridView
	{
		get
		{
			return _dataGridView;
		}
		set
		{
			_dataGridView = value;
		}
	}

	public virtual object EditingControlFormattedValue
	{
		get
		{
			return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
		}
		set
		{
			Text = (string)value;
		}
	}

	public virtual int EditingControlRowIndex
	{
		get
		{
			return _rowIndex;
		}
		set
		{
			_rowIndex = value;
		}
	}

	public virtual bool EditingControlValueChanged
	{
		get
		{
			return _valueChanged;
		}
		set
		{
			_valueChanged = value;
		}
	}

	public virtual Cursor EditingPanelCursor => Cursors.Default;

	public virtual bool RepositionEditingControlOnValueChange => false;

	public KryptonDataGridViewTextBoxEditingControl()
	{
		base.TabStop = false;
		base.StateCommon.Border.Width = 0;
		base.StateCommon.Border.Draw = InheritBool.False;
		base.StateCommon.Content.Padding = new Padding(0);
	}

	public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.StateCommon.Content.Font = dataGridViewCellStyle.Font;
		base.StateCommon.Content.Color1 = dataGridViewCellStyle.ForeColor;
		base.StateCommon.Back.Color1 = dataGridViewCellStyle.BackColor;
		base.TextAlign = KryptonDataGridViewNumericUpDownCell.TranslateAlignment(dataGridViewCellStyle.Alignment);
	}

	public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
	{
		switch (keyData & Keys.KeyCode)
		{
		case Keys.Right:
			if (base.Controls[0] is TextBox textBox3 && ((RightToLeft == RightToLeft.No && (textBox3.SelectionLength != 0 || textBox3.SelectionStart != textBox3.Text.Length)) || (RightToLeft == RightToLeft.Yes && (textBox3.SelectionLength != 0 || textBox3.SelectionStart != 0))))
			{
				return true;
			}
			break;
		case Keys.Left:
			if (base.Controls[0] is TextBox textBox2 && ((RightToLeft == RightToLeft.No && (textBox2.SelectionLength != 0 || textBox2.SelectionStart != 0)) || (RightToLeft == RightToLeft.Yes && (textBox2.SelectionLength != 0 || textBox2.SelectionStart != textBox2.Text.Length))))
			{
				return true;
			}
			break;
		case Keys.Up:
		case Keys.Down:
			return true;
		case Keys.End:
		case Keys.Home:
			if (base.Controls[0] is TextBox textBox4 && textBox4.SelectionLength != textBox4.Text.Length)
			{
				return true;
			}
			break;
		case Keys.Delete:
			if (base.Controls[0] is TextBox textBox && (textBox.SelectionLength > 0 || textBox.SelectionStart < textBox.Text.Length))
			{
				return true;
			}
			break;
		}
		return !dataGridViewWantsInputKey;
	}

	public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
	{
		return Text;
	}

	public virtual void PrepareEditingControlForEdit(bool selectAll)
	{
		if (base.Controls[0] is TextBox textBox)
		{
			if (selectAll)
			{
				textBox.SelectAll();
			}
			else
			{
				textBox.SelectionStart = textBox.Text.Length;
			}
		}
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		if (Focused)
		{
			NotifyDataGridViewOfValueChange();
		}
	}

	protected override bool ProcessKeyEventArgs(ref Message m)
	{
		if (base.Controls[0] is TextBox textBox)
		{
			PI.SendMessage(textBox.Handle, m.Msg, m.WParam, m.LParam);
			return true;
		}
		return base.ProcessKeyEventArgs(ref m);
	}

	private void NotifyDataGridViewOfValueChange()
	{
		if (!_valueChanged)
		{
			_valueChanged = true;
			_dataGridView.NotifyCurrentCellDirty(dirty: true);
		}
	}
}
