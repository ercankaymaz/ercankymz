using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewComboBoxCell : DataGridViewTextBoxCell
{
	[ThreadStatic]
	private static KryptonComboBox _paintingComboBox;

	private static readonly Type _defaultEditType = typeof(KryptonDataGridViewComboBoxEditingControl);

	private static readonly Type _defaultValueType = typeof(string);

	private static readonly Size _sizeLarge = new Size(10000, 10000);

	private ComboBoxStyle _dropDownStyle;

	private int _maxDropDownItems;

	private int _dropDownHeight;

	private int _dropDownWidth;

	private AutoCompleteMode _autoCompleteMode;

	private AutoCompleteSource _autoCompleteSource;

	private string _displayMember;

	private string _valueMember;

	public override Type EditType => _defaultEditType;

	public override Type ValueType
	{
		get
		{
			Type valueType = base.ValueType;
			if (valueType != null)
			{
				return valueType;
			}
			return _defaultValueType;
		}
	}

	[DefaultValue(0)]
	public ComboBoxStyle DropDownStyle
	{
		get
		{
			return _dropDownStyle;
		}
		set
		{
			if (value == ComboBoxStyle.Simple)
			{
				throw new ArgumentOutOfRangeException("The DropDownStyle property does not support the Simple style.");
			}
			if (_dropDownStyle != value)
			{
				SetDropDownStyle(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(8)]
	public int MaxDropDownItems
	{
		get
		{
			return _maxDropDownItems;
		}
		set
		{
			if (_maxDropDownItems != value)
			{
				SetMaxDropDownItems(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(200)]
	public int DropDownHeight
	{
		get
		{
			return _dropDownHeight;
		}
		set
		{
			if (_dropDownHeight != value)
			{
				SetDropDownHeight(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(121)]
	public int DropDownWidth
	{
		get
		{
			return _dropDownWidth;
		}
		set
		{
			if (DropDownWidth != value)
			{
				SetDropDownWidth(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(121)]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			return _autoCompleteMode;
		}
		set
		{
			if (AutoCompleteMode != value)
			{
				SetAutoCompleteMode(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(121)]
	public AutoCompleteSource AutoCompleteSource
	{
		get
		{
			return _autoCompleteSource;
		}
		set
		{
			if (AutoCompleteSource != value)
			{
				SetAutoCompleteSource(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue("")]
	public string DisplayMember
	{
		get
		{
			return _displayMember;
		}
		set
		{
			if (_displayMember != value)
			{
				SetDisplayMember(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue("")]
	public string ValueMember
	{
		get
		{
			return _valueMember;
		}
		set
		{
			if (_valueMember != value)
			{
				SetValueMember(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	private KryptonDataGridViewComboBoxEditingControl EditingComboBox => base.DataGridView.EditingControl as KryptonDataGridViewComboBoxEditingControl;

	public KryptonDataGridViewComboBoxCell()
	{
		if (_paintingComboBox == null)
		{
			_paintingComboBox = new KryptonComboBox();
			_paintingComboBox.SetLayoutDisplayPadding(new Padding(0, 1, 1, 0));
			_paintingComboBox.StateCommon.ComboBox.Border.Width = 0;
			_paintingComboBox.StateCommon.ComboBox.Border.Draw = InheritBool.False;
		}
		_dropDownStyle = ComboBoxStyle.DropDown;
		_maxDropDownItems = 8;
		_dropDownHeight = 200;
		_dropDownWidth = 121;
		_autoCompleteMode = AutoCompleteMode.None;
		_autoCompleteSource = AutoCompleteSource.None;
		_displayMember = string.Empty;
		_valueMember = string.Empty;
	}

	public override string ToString()
	{
		return "KryptonDataGridViewComboBoxCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
	}

	public override object Clone()
	{
		KryptonDataGridViewComboBoxCell kryptonDataGridViewComboBoxCell = base.Clone() as KryptonDataGridViewComboBoxCell;
		if (kryptonDataGridViewComboBoxCell != null)
		{
			kryptonDataGridViewComboBoxCell.DropDownStyle = DropDownStyle;
			kryptonDataGridViewComboBoxCell.DropDownHeight = DropDownHeight;
			kryptonDataGridViewComboBoxCell.DropDownWidth = DropDownWidth;
			kryptonDataGridViewComboBoxCell.MaxDropDownItems = MaxDropDownItems;
			kryptonDataGridViewComboBoxCell.AutoCompleteMode = AutoCompleteMode;
			kryptonDataGridViewComboBoxCell.AutoCompleteSource = AutoCompleteSource;
			kryptonDataGridViewComboBoxCell.DisplayMember = DisplayMember;
			kryptonDataGridViewComboBoxCell.ValueMember = ValueMember;
		}
		return kryptonDataGridViewComboBoxCell;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override void DetachEditingControl()
	{
		DataGridView dataGridView = base.DataGridView;
		if (dataGridView == null || dataGridView.EditingControl == null)
		{
			throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
		}
		if (dataGridView.EditingControl is KryptonComboBox kryptonComboBox && base.OwningColumn is KryptonDataGridViewComboBoxColumn)
		{
			foreach (ButtonSpecAny buttonSpec in kryptonComboBox.ButtonSpecs)
			{
				buttonSpec.Click -= OnButtonClick;
			}
			kryptonComboBox.ButtonSpecs.Clear();
		}
		base.DetachEditingControl();
	}

	public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
		if (!(base.DataGridView.EditingControl is KryptonComboBox kryptonComboBox))
		{
			return;
		}
		if (base.OwningColumn is KryptonDataGridViewComboBoxColumn kryptonDataGridViewComboBoxColumn)
		{
			object[] array = new object[kryptonDataGridViewComboBoxColumn.Items.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = kryptonDataGridViewComboBoxColumn.Items[i];
			}
			kryptonComboBox.Items.Clear();
			kryptonComboBox.Items.AddRange(array);
			string[] array2 = new string[kryptonDataGridViewComboBoxColumn.AutoCompleteCustomSource.Count];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = kryptonDataGridViewComboBoxColumn.AutoCompleteCustomSource[j];
			}
			kryptonComboBox.AutoCompleteCustomSource.Clear();
			kryptonComboBox.AutoCompleteCustomSource.AddRange(array2);
			kryptonComboBox.ButtonSpecs.Clear();
			kryptonComboBox.ButtonSpecs.Owner = base.DataGridView.Rows[rowIndex].Cells[base.ColumnIndex];
			foreach (ButtonSpecAny buttonSpec in kryptonDataGridViewComboBoxColumn.ButtonSpecs)
			{
				buttonSpec.Click += OnButtonClick;
				kryptonComboBox.ButtonSpecs.Add((object)buttonSpec);
			}
		}
		kryptonComboBox.DropDownStyle = DropDownStyle;
		kryptonComboBox.DropDownHeight = DropDownHeight;
		kryptonComboBox.DropDownWidth = DropDownWidth;
		kryptonComboBox.MaxDropDownItems = MaxDropDownItems;
		kryptonComboBox.AutoCompleteSource = AutoCompleteSource;
		kryptonComboBox.AutoCompleteMode = AutoCompleteMode;
		kryptonComboBox.DisplayMember = DisplayMember;
		kryptonComboBox.ValueMember = ValueMember;
		if (!(initialFormattedValue is string text))
		{
			kryptonComboBox.Text = string.Empty;
		}
		else
		{
			kryptonComboBox.Text = text;
		}
	}

	public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
	{
		Rectangle editingControlBounds = PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
		editingControlBounds = GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
		base.DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
		base.DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
	}

	protected override Rectangle GetErrorIconBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
	{
		Rectangle errorIconBounds = base.GetErrorIconBounds(graphics, cellStyle, rowIndex);
		if (base.DataGridView.RightToLeft == RightToLeft.Yes)
		{
			errorIconBounds.X = errorIconBounds.Left + 16;
		}
		else
		{
			errorIconBounds.X = errorIconBounds.Left - 16;
		}
		return errorIconBounds;
	}

	protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
	{
		if (base.DataGridView == null)
		{
			return new Size(-1, -1);
		}
		Size preferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
		if (constraintSize.Width == 0)
		{
			preferredSize.Width += 24;
		}
		return preferredSize;
	}

	private void OnButtonClick(object sender, EventArgs e)
	{
		KryptonDataGridViewComboBoxColumn kryptonDataGridViewComboBoxColumn = base.OwningColumn as KryptonDataGridViewComboBoxColumn;
		DataGridViewButtonSpecClickEventArgs args = new DataGridViewButtonSpecClickEventArgs(kryptonDataGridViewComboBoxColumn, this, (ButtonSpecAny)sender);
		kryptonDataGridViewComboBoxColumn.PerfomButtonSpecClick(args);
	}

	private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
	{
		int num = _paintingComboBox.GetPreferredSize(_sizeLarge).Height + 2;
		if (num < editingControlBounds.Height)
		{
			switch (cellStyle.Alignment)
			{
			case DataGridViewContentAlignment.MiddleLeft:
			case DataGridViewContentAlignment.MiddleCenter:
			case DataGridViewContentAlignment.MiddleRight:
				editingControlBounds.Y += (editingControlBounds.Height - num) / 2;
				break;
			case DataGridViewContentAlignment.BottomLeft:
			case DataGridViewContentAlignment.BottomCenter:
			case DataGridViewContentAlignment.BottomRight:
				editingControlBounds.Y += editingControlBounds.Height - num;
				break;
			}
		}
		return editingControlBounds;
	}

	private void OnCommonChange()
	{
		if (base.DataGridView != null && !base.DataGridView.IsDisposed && !base.DataGridView.Disposing)
		{
			if (base.RowIndex == -1)
			{
				base.DataGridView.InvalidateColumn(base.ColumnIndex);
			}
			else
			{
				base.DataGridView.UpdateCellValue(base.ColumnIndex, base.RowIndex);
			}
		}
	}

	private bool OwnsEditingComboBox(int rowIndex)
	{
		if (rowIndex == -1 || base.DataGridView == null)
		{
			return false;
		}
		return base.DataGridView.EditingControl is KryptonDataGridViewComboBoxEditingControl kryptonDataGridViewComboBoxEditingControl && rowIndex == ((IDataGridViewEditingControl)kryptonDataGridViewComboBoxEditingControl).EditingControlRowIndex;
	}

	private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
	{
		return (paintParts & paintPart) != 0;
	}

	internal void SetDropDownStyle(int rowIndex, ComboBoxStyle value)
	{
		_dropDownStyle = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.DropDownStyle = value;
		}
	}

	internal void SetMaxDropDownItems(int rowIndex, int value)
	{
		_maxDropDownItems = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.MaxDropDownItems = value;
		}
	}

	internal void SetDropDownHeight(int rowIndex, int value)
	{
		_dropDownHeight = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.DropDownHeight = value;
		}
	}

	internal void SetDropDownWidth(int rowIndex, int value)
	{
		_dropDownWidth = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.DropDownWidth = value;
		}
	}

	internal void SetAutoCompleteMode(int rowIndex, AutoCompleteMode value)
	{
		_autoCompleteMode = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.AutoCompleteMode = value;
		}
	}

	internal void SetAutoCompleteSource(int rowIndex, AutoCompleteSource value)
	{
		_autoCompleteSource = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.AutoCompleteSource = value;
		}
	}

	internal void SetDisplayMember(int rowIndex, string value)
	{
		_displayMember = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.DisplayMember = value;
		}
	}

	internal void SetValueMember(int rowIndex, string value)
	{
		_valueMember = value;
		if (OwnsEditingComboBox(rowIndex))
		{
			EditingComboBox.ValueMember = value;
		}
	}
}
