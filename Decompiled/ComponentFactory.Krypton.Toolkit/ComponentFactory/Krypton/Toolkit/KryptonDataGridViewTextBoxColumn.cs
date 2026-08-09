using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[Designer("ComponentFactory.Krypton.Toolkit.KryptonTextBoxColumnDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[ToolboxBitmap(typeof(KryptonDataGridViewTextBoxColumn), "ToolboxBitmaps.KryptonTextBox.bmp")]
public class KryptonDataGridViewTextBoxColumn : DataGridViewColumn
{
	private DataGridViewColumnSpecCollection _buttonSpecs;

	[Category("Behavior")]
	[DefaultValue(typeof(int), "32767")]
	public int MaxInputLength
	{
		get
		{
			if (TextBoxCellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewTextBoxColumn cell template required");
			}
			return TextBoxCellTemplate.MaxInputLength;
		}
		set
		{
			if (MaxInputLength == value)
			{
				return;
			}
			TextBoxCellTemplate.MaxInputLength = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is DataGridViewTextBoxCell dataGridViewTextBoxCell)
				{
					dataGridViewTextBoxCell.MaxInputLength = value;
				}
			}
		}
	}

	[DefaultValue(typeof(DataGridViewColumnSortMode), "Automatic")]
	public new DataGridViewColumnSortMode SortMode
	{
		get
		{
			return base.SortMode;
		}
		set
		{
			base.SortMode = value;
		}
	}

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
			if (value != null && !(value is KryptonDataGridViewTextBoxCell))
			{
				throw new InvalidCastException("Can only assign a object of type KryptonDataGridViewTextBoxCell");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Data")]
	[Description("Set of extra button specs to appear with control.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewColumnSpecCollection ButtonSpecs => _buttonSpecs;

	private KryptonDataGridViewTextBoxCell TextBoxCellTemplate => (KryptonDataGridViewTextBoxCell)CellTemplate;

	public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick;

	public KryptonDataGridViewTextBoxColumn()
		: base(new KryptonDataGridViewTextBoxCell())
	{
		_buttonSpecs = new DataGridViewColumnSpecCollection(this);
		SortMode = DataGridViewColumnSortMode.Automatic;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewTextBoxColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn = base.Clone() as KryptonDataGridViewTextBoxColumn;
		foreach (ButtonSpecAny buttonSpec in ButtonSpecs)
		{
			kryptonDataGridViewTextBoxColumn.ButtonSpecs.Add(buttonSpec.Clone());
		}
		return kryptonDataGridViewTextBoxColumn;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
	{
		if (this.ButtonSpecClick != null)
		{
			this.ButtonSpecClick(this, args);
		}
	}
}
