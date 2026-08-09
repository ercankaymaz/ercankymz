using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[Designer("ComponentFactory.Krypton.Toolkit.KryptonNumericUpDownColumnDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[ToolboxBitmap(typeof(KryptonDataGridViewNumericUpDownColumn), "ToolboxBitmaps.KryptonNumericUpDown.bmp")]
public class KryptonDataGridViewNumericUpDownColumn : DataGridViewColumn
{
	private DataGridViewColumnSpecCollection _buttonSpecs;

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
			KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell = value as KryptonDataGridViewNumericUpDownCell;
			if (value != null && kryptonDataGridViewNumericUpDownCell == null)
			{
				throw new InvalidCastException("Value provided for CellTemplate must be of type KryptonDataGridViewNumericUpDownCell or derive from it.");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Data")]
	[Description("Set of extra button specs to appear with control.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewColumnSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Appearance")]
	[DefaultValue(0)]
	[Description("Indicates the number of decimal places to display.")]
	public int DecimalPlaces
	{
		get
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return NumericUpDownCellTemplate.DecimalPlaces;
		}
		set
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			NumericUpDownCellTemplate.DecimalPlaces = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell)
				{
					kryptonDataGridViewNumericUpDownCell.SetDecimalPlaces(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Appearance")]
	[DefaultValue(false)]
	[Description("Indicates wheather the numeric up-down should display its value in hexadecimal.")]
	public bool Hexadecimal
	{
		get
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return NumericUpDownCellTemplate.Hexadecimal;
		}
		set
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			NumericUpDownCellTemplate.Hexadecimal = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell)
				{
					kryptonDataGridViewNumericUpDownCell.SetHexadecimal(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Data")]
	[Description("Indicates the amount to increment or decrement on each button click.")]
	public decimal Increment
	{
		get
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return NumericUpDownCellTemplate.Increment;
		}
		set
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			NumericUpDownCellTemplate.Increment = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell)
				{
					kryptonDataGridViewNumericUpDownCell.SetIncrement(i, value);
				}
			}
		}
	}

	[Category("Data")]
	[Description("Indicates the maximum value for the numeric up-down cells.")]
	[RefreshProperties(RefreshProperties.All)]
	public decimal Maximum
	{
		get
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return NumericUpDownCellTemplate.Maximum;
		}
		set
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			NumericUpDownCellTemplate.Maximum = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell)
				{
					kryptonDataGridViewNumericUpDownCell.SetMaximum(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Data")]
	[Description("Indicates the minimum value for the numeric up-down cells.")]
	[RefreshProperties(RefreshProperties.All)]
	public decimal Minimum
	{
		get
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return NumericUpDownCellTemplate.Minimum;
		}
		set
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			NumericUpDownCellTemplate.Minimum = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell)
				{
					kryptonDataGridViewNumericUpDownCell.SetMinimum(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Data")]
	[DefaultValue(false)]
	[Description("Indicates whether the thousands separator will be inserted between every three decimal digits.")]
	public bool ThousandsSeparator
	{
		get
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return NumericUpDownCellTemplate.ThousandsSeparator;
		}
		set
		{
			if (NumericUpDownCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			NumericUpDownCellTemplate.ThousandsSeparator = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell)
				{
					kryptonDataGridViewNumericUpDownCell.SetThousandsSeparator(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	private KryptonDataGridViewNumericUpDownCell NumericUpDownCellTemplate => (KryptonDataGridViewNumericUpDownCell)CellTemplate;

	public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick;

	public KryptonDataGridViewNumericUpDownColumn()
		: base(new KryptonDataGridViewNumericUpDownCell())
	{
		_buttonSpecs = new DataGridViewColumnSpecCollection(this);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewNumericUpDownColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewNumericUpDownColumn kryptonDataGridViewNumericUpDownColumn = base.Clone() as KryptonDataGridViewNumericUpDownColumn;
		foreach (ButtonSpecAny buttonSpec in ButtonSpecs)
		{
			kryptonDataGridViewNumericUpDownColumn.ButtonSpecs.Add(buttonSpec.Clone());
		}
		return kryptonDataGridViewNumericUpDownColumn;
	}

	private bool ShouldSerializeIncrement()
	{
		return !Increment.Equals(1m);
	}

	private bool ShouldSerializeMaximum()
	{
		return !Maximum.Equals(100m);
	}

	private bool ShouldSerializeMinimum()
	{
		return !Minimum.Equals(0m);
	}

	internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
	{
		if (this.ButtonSpecClick != null)
		{
			this.ButtonSpecClick(this, args);
		}
	}
}
