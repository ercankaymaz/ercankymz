using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxBitmap(typeof(KryptonDataGridViewButtonColumn), "ToolboxBitmaps.KryptonButton.bmp")]
public class KryptonDataGridViewButtonColumn : DataGridViewColumn
{
	private MethodInfo _miColumnCommonChange;

	private PropertyInfo _piUseColumnTextForButtonValueInternal;

	private string _text;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override DataGridViewCell CellTemplate
	{
		get
		{
			return base.CellTemplate;
		}
		set
		{
			if (value != null && !(value is KryptonDataGridViewButtonCell))
			{
				throw new InvalidCastException("Can only assign a object of type KryptonDataGridViewButtonCell");
			}
			base.CellTemplate = value;
		}
	}

	[Browsable(true)]
	[Category("Appearance")]
	public override DataGridViewCellStyle DefaultCellStyle
	{
		get
		{
			return base.DefaultCellStyle;
		}
		set
		{
			base.DefaultCellStyle = value;
		}
	}

	[Category("Appearance")]
	[DefaultValue(null)]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (string.Equals(value, _text, StringComparison.Ordinal))
			{
				return;
			}
			_text = value;
			if (base.DataGridView == null)
			{
				return;
			}
			if (UseColumnTextForButtonValue)
			{
				ColumnCommonChange(base.Index);
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is KryptonDataGridViewButtonCell { UseColumnTextForButtonValue: not false })
				{
					ColumnCommonChange(base.Index);
					return;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Appearance")]
	[DefaultValue(false)]
	public bool UseColumnTextForButtonValue
	{
		get
		{
			if (CellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewButtonColumn cell template required");
			}
			return ((KryptonDataGridViewButtonCell)CellTemplate).UseColumnTextForButtonValue;
		}
		set
		{
			if (UseColumnTextForButtonValue == value)
			{
				return;
			}
			SetUseColumnTextForButtonValueInternal(CellTemplate, value);
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewButtonCell dataGridViewButtonCell = rows.SharedRow(i).Cells[base.Index] as KryptonDataGridViewButtonCell;
				if (dataGridViewButtonCell != null)
				{
					SetUseColumnTextForButtonValueInternal(dataGridViewButtonCell, value);
				}
			}
			ColumnCommonChange(base.Index);
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(ButtonStyle), "Standalone")]
	public ButtonStyle ButtonStyle
	{
		get
		{
			if (CellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewButtonColumn cell template required");
			}
			return ((KryptonDataGridViewButtonCell)CellTemplate).ButtonStyle;
		}
		set
		{
			if (ButtonStyle == value)
			{
				return;
			}
			((KryptonDataGridViewButtonCell)CellTemplate).ButtonStyleInternal = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is KryptonDataGridViewButtonCell kryptonDataGridViewButtonCell)
				{
					kryptonDataGridViewButtonCell.ButtonStyleInternal = value;
				}
			}
			ColumnCommonChange(base.Index);
		}
	}

	public KryptonDataGridViewButtonColumn()
		: base(new KryptonDataGridViewButtonCell())
	{
		DefaultCellStyle = new DataGridViewCellStyle
		{
			Alignment = DataGridViewContentAlignment.MiddleCenter
		};
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewButtonColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewButtonColumn kryptonDataGridViewButtonColumn = base.Clone() as KryptonDataGridViewButtonColumn;
		kryptonDataGridViewButtonColumn.Text = Text;
		return kryptonDataGridViewButtonColumn;
	}

	private bool ShouldSerializeDefaultCellStyle()
	{
		if (!base.HasDefaultCellStyle)
		{
			return false;
		}
		DataGridViewCellStyle defaultCellStyle = DefaultCellStyle;
		if (defaultCellStyle.BackColor.IsEmpty && defaultCellStyle.ForeColor.IsEmpty && defaultCellStyle.SelectionBackColor.IsEmpty && defaultCellStyle.SelectionForeColor.IsEmpty && defaultCellStyle.Font == null && defaultCellStyle.IsNullValueDefault && defaultCellStyle.IsDataSourceNullValueDefault && string.IsNullOrEmpty(defaultCellStyle.Format) && defaultCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && defaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter && defaultCellStyle.WrapMode == DataGridViewTriState.NotSet && defaultCellStyle.Tag == null)
		{
			return !defaultCellStyle.Padding.Equals(Padding.Empty);
		}
		return true;
	}

	private void ColumnCommonChange(int columnIndex)
	{
		if (_miColumnCommonChange == null)
		{
			_miColumnCommonChange = typeof(DataGridView).GetMethod("OnColumnCommonChange", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		_miColumnCommonChange.Invoke(base.DataGridView, new object[1] { columnIndex });
	}

	private void SetUseColumnTextForButtonValueInternal(object instance, bool value)
	{
		if (_piUseColumnTextForButtonValueInternal == null)
		{
			_piUseColumnTextForButtonValueInternal = typeof(DataGridViewButtonCell).GetProperty("UseColumnTextForButtonValueInternal", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
		}
		_piUseColumnTextForButtonValueInternal.SetValue(instance, value, null);
	}
}
