using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxBitmap(typeof(KryptonDataGridViewCheckBoxColumn), "ToolboxBitmaps.KryptonCheckBox.bmp")]
public class KryptonDataGridViewCheckBoxColumn : DataGridViewColumn
{
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
			if (value != null && !(value is KryptonDataGridViewCheckBoxCell))
			{
				throw new InvalidCastException("Can only assign a object of type KryptonDataGridViewCheckBoxCell");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Data")]
	[DefaultValue("")]
	[TypeConverter(typeof(StringConverter))]
	public object FalseValue
	{
		get
		{
			if (CheckBoxCellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewCheckBoxColumn cell template required");
			}
			return CheckBoxCellTemplate.FalseValue;
		}
		set
		{
			if (FalseValue == value)
			{
				return;
			}
			CheckBoxCellTemplate.FalseValue = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewCheckBoxCell dataGridViewCheckBoxCell = rows.SharedRow(i).Cells[base.Index] as KryptonDataGridViewCheckBoxCell;
				if (dataGridViewCheckBoxCell != null)
				{
					dataGridViewCheckBoxCell.FalseValue = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Data")]
	[DefaultValue("")]
	[TypeConverter(typeof(StringConverter))]
	public object IndeterminateValue
	{
		get
		{
			if (CheckBoxCellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewCheckBoxColumn cell template required");
			}
			return CheckBoxCellTemplate.IndeterminateValue;
		}
		set
		{
			if (IndeterminateValue == value)
			{
				return;
			}
			CheckBoxCellTemplate.IndeterminateValue = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewCheckBoxCell dataGridViewCheckBoxCell = rows.SharedRow(i).Cells[base.Index] as KryptonDataGridViewCheckBoxCell;
				if (dataGridViewCheckBoxCell != null)
				{
					dataGridViewCheckBoxCell.IndeterminateValue = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Data")]
	[DefaultValue("")]
	[TypeConverter(typeof(StringConverter))]
	public object TrueValue
	{
		get
		{
			if (CheckBoxCellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewCheckBoxColumn cell template required");
			}
			return CheckBoxCellTemplate.TrueValue;
		}
		set
		{
			if (TrueValue == value)
			{
				return;
			}
			CheckBoxCellTemplate.TrueValue = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewCheckBoxCell dataGridViewCheckBoxCell = rows.SharedRow(i).Cells[base.Index] as KryptonDataGridViewCheckBoxCell;
				if (dataGridViewCheckBoxCell != null)
				{
					dataGridViewCheckBoxCell.TrueValue = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[DefaultValue(false)]
	public bool ThreeState
	{
		get
		{
			if (CheckBoxCellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewCheckBoxColumn cell template required");
			}
			return CheckBoxCellTemplate.ThreeState;
		}
		set
		{
			if (ThreeState == value)
			{
				return;
			}
			CheckBoxCellTemplate.ThreeState = value;
			if (base.DataGridView != null)
			{
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewCheckBoxCell dataGridViewCheckBoxCell = rows.SharedRow(i).Cells[base.Index] as KryptonDataGridViewCheckBoxCell;
					if (dataGridViewCheckBoxCell != null)
					{
						dataGridViewCheckBoxCell.ThreeState = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
			if (value && DefaultCellStyle.NullValue is bool && !(bool)DefaultCellStyle.NullValue)
			{
				DefaultCellStyle.NullValue = CheckState.Indeterminate;
			}
			else if (!value && DefaultCellStyle.NullValue is CheckState && (CheckState)DefaultCellStyle.NullValue == CheckState.Indeterminate)
			{
				DefaultCellStyle.NullValue = false;
			}
		}
	}

	private KryptonDataGridViewCheckBoxCell CheckBoxCellTemplate => (KryptonDataGridViewCheckBoxCell)CellTemplate;

	public KryptonDataGridViewCheckBoxColumn()
		: this(threeState: false)
	{
	}

	public KryptonDataGridViewCheckBoxColumn(bool threeState)
		: base(new KryptonDataGridViewCheckBoxCell(threeState))
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle
		{
			Alignment = DataGridViewContentAlignment.MiddleCenter
		};
		if (threeState)
		{
			dataGridViewCellStyle.NullValue = CheckState.Indeterminate;
		}
		else
		{
			dataGridViewCellStyle.NullValue = false;
		}
		DefaultCellStyle = dataGridViewCellStyle;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewCheckBoxColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	private bool ShouldSerializeDefaultCellStyle()
	{
		KryptonDataGridViewCheckBoxCell checkBoxCellTemplate = CheckBoxCellTemplate;
		if (checkBoxCellTemplate != null)
		{
			object obj = ((!checkBoxCellTemplate.ThreeState) ? ((object)false) : ((object)CheckState.Indeterminate));
			if (!base.HasDefaultCellStyle)
			{
				return false;
			}
			DataGridViewCellStyle defaultCellStyle = DefaultCellStyle;
			if (defaultCellStyle.BackColor.IsEmpty && defaultCellStyle.ForeColor.IsEmpty && defaultCellStyle.SelectionBackColor.IsEmpty && defaultCellStyle.SelectionForeColor.IsEmpty && defaultCellStyle.Font == null && defaultCellStyle.NullValue.Equals(obj) && defaultCellStyle.IsDataSourceNullValueDefault && string.IsNullOrEmpty(defaultCellStyle.Format) && defaultCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && defaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter && defaultCellStyle.WrapMode == DataGridViewTriState.NotSet && defaultCellStyle.Tag == null)
			{
				return !defaultCellStyle.Padding.Equals(Padding.Empty);
			}
		}
		return true;
	}
}
