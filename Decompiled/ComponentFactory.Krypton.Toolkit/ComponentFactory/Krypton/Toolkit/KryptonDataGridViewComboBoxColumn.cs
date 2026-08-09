using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[Designer("ComponentFactory.Krypton.Toolkit.KryptonComboBoxColumnDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[ToolboxBitmap(typeof(KryptonDataGridViewComboBoxColumn), "ToolboxBitmaps.KryptonComboBox.bmp")]
public class KryptonDataGridViewComboBoxColumn : DataGridViewColumn
{
	private StringCollection _items;

	private AutoCompleteStringCollection _autoCompleteCustom;

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
			KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell = value as KryptonDataGridViewComboBoxCell;
			if (value != null && kryptonDataGridViewComboBoxCell == null)
			{
				throw new InvalidCastException("Value provided for CellTemplate must be of type KryptonDataGridViewComboBoxCell or derive from it.");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Data")]
	[Description("Set of extra button specs to appear with control.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewColumnSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Data")]
	[Description("The allowable items of the domain up down.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	public StringCollection Items => _items;

	private bool ShouldSerializeItems => true;

	[Category("Appearance")]
	[Description("Controls the appearance and functionality of the KryptonComboBox.")]
	[DefaultValue(typeof(ComboBoxStyle), "DropDown")]
	[RefreshProperties(RefreshProperties.Repaint)]
	public ComboBoxStyle DropDownStyle
	{
		get
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return ComboBoxCellTemplate.DropDownStyle;
		}
		set
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			ComboBoxCellTemplate.DropDownStyle = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell)
				{
					kryptonDataGridViewComboBoxCell.SetDropDownStyle(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("The maximum number of entries to display in the drop-down list.")]
	[Localizable(true)]
	[DefaultValue(8)]
	public int MaxDropDownItems
	{
		get
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return ComboBoxCellTemplate.MaxDropDownItems;
		}
		set
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			ComboBoxCellTemplate.MaxDropDownItems = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell)
				{
					kryptonDataGridViewComboBoxCell.SetMaxDropDownItems(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("The height, in pixels, of the drop down box in a KryptonComboBox.")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(200)]
	[Browsable(true)]
	public int DropDownHeight
	{
		get
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return ComboBoxCellTemplate.DropDownHeight;
		}
		set
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			ComboBoxCellTemplate.DropDownHeight = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell)
				{
					kryptonDataGridViewComboBoxCell.SetMaxDropDownItems(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("The width, in pixels, of the drop down box in a KryptonComboBox.")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public int DropDownWidth
	{
		get
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return ComboBoxCellTemplate.DropDownWidth;
		}
		set
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			ComboBoxCellTemplate.DropDownWidth = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell)
				{
					kryptonDataGridViewComboBoxCell.SetDropDownWidth(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Description("The StringCollection to use when the AutoCompleteSource property is set to CustomSource.")]
	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Localizable(true)]
	[Browsable(true)]
	public AutoCompleteStringCollection AutoCompleteCustomSource => _autoCompleteCustom;

	private bool ShouldSerializeAutoCompleteCustomSource => true;

	[Description("Indicates the text completion behavior of the combobox.")]
	[DefaultValue(typeof(AutoCompleteMode), "None")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return ComboBoxCellTemplate.AutoCompleteMode;
		}
		set
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			ComboBoxCellTemplate.AutoCompleteMode = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell)
				{
					kryptonDataGridViewComboBoxCell.SetAutoCompleteMode(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Description("The autocomplete source, which can be one of the values from AutoCompleteSource enumeration.")]
	[DefaultValue(typeof(AutoCompleteSource), "None")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public AutoCompleteSource AutoCompleteSource
	{
		get
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return ComboBoxCellTemplate.AutoCompleteSource;
		}
		set
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			ComboBoxCellTemplate.AutoCompleteSource = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell)
				{
					kryptonDataGridViewComboBoxCell.SetAutoCompleteSource(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Data")]
	[Description("Indicates the property to display for the items in this control.")]
	[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string DisplayMember
	{
		get
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return ComboBoxCellTemplate.DisplayMember;
		}
		set
		{
			if (ComboBoxCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			ComboBoxCellTemplate.DisplayMember = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell)
				{
					kryptonDataGridViewComboBoxCell.SetDisplayMember(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	private KryptonDataGridViewComboBoxCell ComboBoxCellTemplate => (KryptonDataGridViewComboBoxCell)CellTemplate;

	public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick;

	public KryptonDataGridViewComboBoxColumn()
		: base(new KryptonDataGridViewComboBoxCell())
	{
		_buttonSpecs = new DataGridViewColumnSpecCollection(this);
		_items = new StringCollection();
		_autoCompleteCustom = new AutoCompleteStringCollection();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewComboBoxColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewComboBoxColumn kryptonDataGridViewComboBoxColumn = base.Clone() as KryptonDataGridViewComboBoxColumn;
		string[] array = new string[Items.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Items[i];
		}
		kryptonDataGridViewComboBoxColumn.Items.AddRange(array);
		array = new string[AutoCompleteCustomSource.Count];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = AutoCompleteCustomSource[j];
		}
		kryptonDataGridViewComboBoxColumn.AutoCompleteCustomSource.AddRange(array);
		foreach (ButtonSpecAny buttonSpec in ButtonSpecs)
		{
			kryptonDataGridViewComboBoxColumn.ButtonSpecs.Add(buttonSpec.Clone());
		}
		return kryptonDataGridViewComboBoxColumn;
	}

	internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
	{
		if (this.ButtonSpecClick != null)
		{
			this.ButtonSpecClick(this, args);
		}
	}
}
