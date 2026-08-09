using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class KryptonDataGridViewComboBoxEditingControl : KryptonComboBox, IDataGridViewEditingControl
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

	public KryptonDataGridViewComboBoxEditingControl()
	{
		base.TabStop = false;
		base.StateCommon.ComboBox.Border.Width = 0;
		base.StateCommon.ComboBox.Border.Draw = InheritBool.False;
		SetLayoutDisplayPadding(new Padding(0, 1, 1, 0));
	}

	public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.StateCommon.ComboBox.Content.Font = dataGridViewCellStyle.Font;
		base.StateCommon.ComboBox.Content.Color1 = dataGridViewCellStyle.ForeColor;
		base.StateCommon.ComboBox.Back.Color1 = dataGridViewCellStyle.BackColor;
	}

	public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
	{
		Keys keys = keyData & Keys.KeyCode;
		Keys keys2 = keys;
		if ((uint)(keys2 - 36) <= 4u || keys2 == Keys.Delete)
		{
			return true;
		}
		return !dataGridViewWantsInputKey;
	}

	public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
	{
		return Text;
	}

	public virtual void PrepareEditingControlForEdit(bool selectAll)
	{
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		if (Focused)
		{
			NotifyDataGridViewOfValueChange();
		}
	}

	protected override void OnSelectedIndexChanged(EventArgs e)
	{
		base.OnSelectedIndexChanged(e);
		if (base.SelectedIndex != -1)
		{
			NotifyDataGridViewOfValueChange();
		}
	}

	protected override bool ProcessKeyEventArgs(ref Message m)
	{
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
