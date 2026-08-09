using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class KryptonDataGridViewDateTimePickerEditingControl : KryptonDateTimePicker, IDataGridViewEditingControl
{
	private static DateTimeConverter _dtc = new DateTimeConverter();

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
			if (value == null || value == DBNull.Value)
			{
				base.ValueNullable = value;
				return;
			}
			string text = value as string;
			if (string.IsNullOrEmpty(text))
			{
				base.ValueNullable = ((text == string.Empty) ? null : value);
			}
			else
			{
				base.Value = (DateTime)_dtc.ConvertFromInvariantString(text);
			}
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

	public KryptonDataGridViewDateTimePickerEditingControl()
	{
		base.TabStop = false;
		base.StateCommon.Border.Width = 0;
		base.StateCommon.Border.Draw = InheritBool.False;
		base.ShowBorder = false;
	}

	public virtual void PrepareEditingControlForEdit(bool selectAll)
	{
	}

	public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.StateCommon.Content.Font = dataGridViewCellStyle.Font;
		base.StateCommon.Content.Color1 = dataGridViewCellStyle.ForeColor;
		base.StateCommon.Back.Color1 = dataGridViewCellStyle.BackColor;
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
		if (base.ValueNullable == null || base.ValueNullable == DBNull.Value)
		{
			return string.Empty;
		}
		return _dtc.ConvertToInvariantString(base.Value);
	}

	protected override void OnValueNullableChanged(EventArgs e)
	{
		base.OnValueNullableChanged(e);
		if (Focused)
		{
			NotifyDataGridViewOfValueChange();
		}
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
