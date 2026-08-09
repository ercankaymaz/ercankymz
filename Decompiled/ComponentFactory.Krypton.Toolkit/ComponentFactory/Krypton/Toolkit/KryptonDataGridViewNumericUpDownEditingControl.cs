using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class KryptonDataGridViewNumericUpDownEditingControl : KryptonNumericUpDown, IDataGridViewEditingControl
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

	public KryptonDataGridViewNumericUpDownEditingControl()
	{
		base.TabStop = false;
		base.StateCommon.Border.Width = 0;
		base.StateCommon.Border.Draw = InheritBool.False;
		SetLayoutDisplayPadding(new Padding(0, 0, 0, -1));
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
			if (base.Controls[0].Controls[1] is TextBox textBox2 && ((RightToLeft == RightToLeft.No && (textBox2.SelectionLength != 0 || textBox2.SelectionStart != textBox2.Text.Length)) || (RightToLeft == RightToLeft.Yes && (textBox2.SelectionLength != 0 || textBox2.SelectionStart != 0))))
			{
				return true;
			}
			break;
		case Keys.Left:
			if (base.Controls[0].Controls[1] is TextBox textBox3 && ((RightToLeft == RightToLeft.No && (textBox3.SelectionLength != 0 || textBox3.SelectionStart != 0)) || (RightToLeft == RightToLeft.Yes && (textBox3.SelectionLength != 0 || textBox3.SelectionStart != textBox3.Text.Length))))
			{
				return true;
			}
			break;
		case Keys.Down:
			if (base.Value > base.Minimum)
			{
				return true;
			}
			break;
		case Keys.Up:
			if (base.Value < base.Maximum)
			{
				return true;
			}
			break;
		case Keys.End:
		case Keys.Home:
			if (base.Controls[0].Controls[1] is TextBox textBox4 && textBox4.SelectionLength != textBox4.Text.Length)
			{
				return true;
			}
			break;
		case Keys.Delete:
			if (base.Controls[0].Controls[1] is TextBox textBox && (textBox.SelectionLength > 0 || textBox.SelectionStart < textBox.Text.Length))
			{
				return true;
			}
			break;
		}
		return !dataGridViewWantsInputKey;
	}

	public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
	{
		bool userEdit = base.UserEdit;
		try
		{
			base.UserEdit = (context & DataGridViewDataErrorContexts.Display) == 0;
			return base.Value.ToString((base.ThousandsSeparator ? "N" : "F") + base.DecimalPlaces);
		}
		finally
		{
			base.UserEdit = userEdit;
		}
	}

	public virtual void PrepareEditingControlForEdit(bool selectAll)
	{
		if (base.Controls[0].Controls[1] is TextBox textBox)
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

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		base.OnKeyPress(e);
		bool flag = false;
		if (char.IsDigit(e.KeyChar))
		{
			flag = true;
		}
		else
		{
			NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
			string numberDecimalSeparator = numberFormat.NumberDecimalSeparator;
			string numberGroupSeparator = numberFormat.NumberGroupSeparator;
			string negativeSign = numberFormat.NegativeSign;
			if (!string.IsNullOrEmpty(numberDecimalSeparator) && numberDecimalSeparator.Length == 1)
			{
				flag = numberDecimalSeparator[0] == e.KeyChar;
			}
			if (!flag && !string.IsNullOrEmpty(numberGroupSeparator) && numberGroupSeparator.Length == 1)
			{
				flag = numberGroupSeparator[0] == e.KeyChar;
			}
			if (!flag && !string.IsNullOrEmpty(negativeSign) && negativeSign.Length == 1)
			{
				flag = negativeSign[0] == e.KeyChar;
			}
		}
		if (flag)
		{
			NotifyDataGridViewOfValueChange();
		}
	}

	protected override void OnValueChanged(EventArgs e)
	{
		base.OnValueChanged(e);
		if (Focused)
		{
			NotifyDataGridViewOfValueChange();
		}
	}

	protected override bool ProcessKeyEventArgs(ref Message m)
	{
		if (base.Controls[0].Controls[1] is TextBox textBox)
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
