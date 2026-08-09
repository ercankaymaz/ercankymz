using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewNumericUpDownCell : DataGridViewTextBoxCell
{
	[ThreadStatic]
	private static KryptonNumericUpDown _paintingNumericUpDown;

	private static readonly DataGridViewContentAlignment _anyRight = (DataGridViewContentAlignment)1092;

	private static readonly DataGridViewContentAlignment _anyCenter = (DataGridViewContentAlignment)546;

	private static readonly Type _defaultEditType = typeof(KryptonDataGridViewNumericUpDownEditingControl);

	private static readonly Type _defaultValueType = typeof(decimal);

	private static readonly Size _sizeLarge = new Size(10000, 10000);

	private int _decimalPlaces;

	private decimal _increment;

	private decimal _minimum;

	private decimal _maximum;

	private bool _thousandsSeparator;

	private bool _hexadecimal;

	public override Type EditType => _defaultEditType;

	[DefaultValue(0)]
	public int DecimalPlaces
	{
		get
		{
			return _decimalPlaces;
		}
		set
		{
			if (value < 0 || value > 99)
			{
				throw new ArgumentOutOfRangeException("The DecimalPlaces property cannot be smaller than 0 or larger than 99.");
			}
			if (_decimalPlaces != value)
			{
				SetDecimalPlaces(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	public bool Hexadecimal
	{
		get
		{
			return _hexadecimal;
		}
		set
		{
			if (_hexadecimal != value)
			{
				SetHexadecimal(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	public decimal Increment
	{
		get
		{
			return _increment;
		}
		set
		{
			if (value < 0m)
			{
				throw new ArgumentOutOfRangeException("The Increment property cannot be smaller than 0.");
			}
			SetIncrement(base.RowIndex, value);
		}
	}

	public decimal Maximum
	{
		get
		{
			return _maximum;
		}
		set
		{
			if (_maximum != value)
			{
				SetMaximum(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	public decimal Minimum
	{
		get
		{
			return _minimum;
		}
		set
		{
			if (_minimum != value)
			{
				SetMinimum(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool ThousandsSeparator
	{
		get
		{
			return _thousandsSeparator;
		}
		set
		{
			if (_thousandsSeparator != value)
			{
				SetThousandsSeparator(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

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

	private KryptonDataGridViewNumericUpDownEditingControl EditingNumericUpDown => base.DataGridView.EditingControl as KryptonDataGridViewNumericUpDownEditingControl;

	public KryptonDataGridViewNumericUpDownCell()
	{
		if (_paintingNumericUpDown == null)
		{
			_paintingNumericUpDown = new KryptonNumericUpDown();
			_paintingNumericUpDown.SetLayoutDisplayPadding(new Padding(0, 0, 0, -1));
			_paintingNumericUpDown.Maximum = 7922816251426433759354395033.5m;
			_paintingNumericUpDown.Minimum = -7922816251426433759354395033.5m;
			_paintingNumericUpDown.StateCommon.Border.Width = 0;
			_paintingNumericUpDown.StateCommon.Border.Draw = InheritBool.False;
		}
		_decimalPlaces = 0;
		_increment = 1m;
		_minimum = default(decimal);
		_maximum = 100m;
		_thousandsSeparator = false;
		_hexadecimal = false;
	}

	public override string ToString()
	{
		return "DataGridViewNumericUpDownCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
	}

	public override object Clone()
	{
		KryptonDataGridViewNumericUpDownCell kryptonDataGridViewNumericUpDownCell = base.Clone() as KryptonDataGridViewNumericUpDownCell;
		if (kryptonDataGridViewNumericUpDownCell != null)
		{
			kryptonDataGridViewNumericUpDownCell.DecimalPlaces = DecimalPlaces;
			kryptonDataGridViewNumericUpDownCell.Increment = Increment;
			kryptonDataGridViewNumericUpDownCell.Maximum = Maximum;
			kryptonDataGridViewNumericUpDownCell.Minimum = Minimum;
			kryptonDataGridViewNumericUpDownCell.ThousandsSeparator = ThousandsSeparator;
			kryptonDataGridViewNumericUpDownCell.Hexadecimal = Hexadecimal;
		}
		return kryptonDataGridViewNumericUpDownCell;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override void DetachEditingControl()
	{
		DataGridView dataGridView = base.DataGridView;
		if (dataGridView == null || dataGridView.EditingControl == null)
		{
			throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
		}
		if (dataGridView.EditingControl is KryptonNumericUpDown kryptonNumericUpDown && base.OwningColumn is KryptonDataGridViewNumericUpDownColumn)
		{
			foreach (ButtonSpecAny buttonSpec in kryptonNumericUpDown.ButtonSpecs)
			{
				buttonSpec.Click -= OnButtonClick;
			}
			kryptonNumericUpDown.ButtonSpecs.Clear();
			if (kryptonNumericUpDown.Controls[0].Controls[1] is TextBox textBox)
			{
				textBox.ClearUndo();
			}
		}
		base.DetachEditingControl();
	}

	public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
		if (!(base.DataGridView.EditingControl is KryptonNumericUpDown kryptonNumericUpDown))
		{
			return;
		}
		kryptonNumericUpDown.DecimalPlaces = DecimalPlaces;
		kryptonNumericUpDown.Increment = Increment;
		kryptonNumericUpDown.Maximum = Maximum;
		kryptonNumericUpDown.Minimum = Minimum;
		kryptonNumericUpDown.ThousandsSeparator = ThousandsSeparator;
		kryptonNumericUpDown.Hexadecimal = Hexadecimal;
		if (base.OwningColumn is KryptonDataGridViewNumericUpDownColumn kryptonDataGridViewNumericUpDownColumn)
		{
			kryptonNumericUpDown.ButtonSpecs.Clear();
			kryptonNumericUpDown.ButtonSpecs.Owner = base.DataGridView.Rows[rowIndex].Cells[base.ColumnIndex];
			foreach (ButtonSpecAny buttonSpec in kryptonDataGridViewNumericUpDownColumn.ButtonSpecs)
			{
				buttonSpec.Click += OnButtonClick;
				kryptonNumericUpDown.ButtonSpecs.Add((object)buttonSpec);
			}
		}
		if (!(initialFormattedValue is string text))
		{
			kryptonNumericUpDown.Text = string.Empty;
		}
		else
		{
			kryptonNumericUpDown.Text = text;
		}
	}

	public override bool KeyEntersEditMode(KeyEventArgs e)
	{
		NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
		Keys keys = Keys.None;
		string negativeSign = numberFormat.NegativeSign;
		if (!string.IsNullOrEmpty(negativeSign) && negativeSign.Length == 1)
		{
			keys = (Keys)PI.VkKeyScan(negativeSign[0]);
		}
		if ((char.IsDigit((char)e.KeyCode) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || keys == e.KeyCode || Keys.Subtract == e.KeyCode) && !e.Shift && !e.Alt && !e.Control)
		{
			return true;
		}
		return false;
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

	protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
	{
		object formattedValue = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
		string value2 = formattedValue as string;
		if (!string.IsNullOrEmpty(value2) && value != null)
		{
			decimal num = Convert.ToDecimal(value);
			decimal num2 = Convert.ToDecimal(value2);
			if (num == num2)
			{
				return num2.ToString((ThousandsSeparator ? "N" : "F") + DecimalPlaces);
			}
		}
		return formattedValue;
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
		KryptonDataGridViewNumericUpDownColumn kryptonDataGridViewNumericUpDownColumn = base.OwningColumn as KryptonDataGridViewNumericUpDownColumn;
		DataGridViewButtonSpecClickEventArgs args = new DataGridViewButtonSpecClickEventArgs(kryptonDataGridViewNumericUpDownColumn, this, (ButtonSpecAny)sender);
		kryptonDataGridViewNumericUpDownColumn.PerfomButtonSpecClick(args);
	}

	private decimal Constrain(decimal value)
	{
		if (value < _minimum)
		{
			value = _minimum;
		}
		if (value > _maximum)
		{
			value = _maximum;
		}
		return value;
	}

	private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
	{
		int num = _paintingNumericUpDown.GetPreferredSize(_sizeLarge).Height + 2;
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

	private bool OwnsEditingNumericUpDown(int rowIndex)
	{
		if (rowIndex == -1 || base.DataGridView == null)
		{
			return false;
		}
		return base.DataGridView.EditingControl is KryptonDataGridViewNumericUpDownEditingControl kryptonDataGridViewNumericUpDownEditingControl && rowIndex == ((IDataGridViewEditingControl)kryptonDataGridViewNumericUpDownEditingControl).EditingControlRowIndex;
	}

	private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
	{
		return (paintParts & paintPart) != 0;
	}

	internal void SetDecimalPlaces(int rowIndex, int value)
	{
		_decimalPlaces = value;
		if (OwnsEditingNumericUpDown(rowIndex))
		{
			EditingNumericUpDown.DecimalPlaces = value;
		}
	}

	internal void SetHexadecimal(int rowIndex, bool value)
	{
		_hexadecimal = value;
		if (OwnsEditingNumericUpDown(rowIndex))
		{
			EditingNumericUpDown.Hexadecimal = value;
		}
	}

	internal void SetIncrement(int rowIndex, decimal value)
	{
		_increment = value;
		if (OwnsEditingNumericUpDown(rowIndex))
		{
			EditingNumericUpDown.Increment = value;
		}
	}

	internal void SetMaximum(int rowIndex, decimal value)
	{
		_maximum = value;
		if (_minimum > _maximum)
		{
			_minimum = _maximum;
		}
		object value2 = GetValue(rowIndex);
		if (value2 != null)
		{
			decimal num = Convert.ToDecimal(value2);
			decimal num2 = Constrain(num);
			if (num2 != num)
			{
				SetValue(rowIndex, num2);
			}
		}
		if (OwnsEditingNumericUpDown(rowIndex))
		{
			EditingNumericUpDown.Maximum = value;
		}
	}

	internal void SetMinimum(int rowIndex, decimal value)
	{
		_minimum = value;
		if (_minimum > _maximum)
		{
			_maximum = value;
		}
		object value2 = GetValue(rowIndex);
		if (value2 != null)
		{
			decimal num = Convert.ToDecimal(value2);
			decimal num2 = Constrain(num);
			if (num2 != num)
			{
				SetValue(rowIndex, num2);
			}
		}
		if (OwnsEditingNumericUpDown(rowIndex))
		{
			EditingNumericUpDown.Minimum = value;
		}
	}

	internal void SetThousandsSeparator(int rowIndex, bool value)
	{
		_thousandsSeparator = value;
		if (OwnsEditingNumericUpDown(rowIndex))
		{
			EditingNumericUpDown.ThousandsSeparator = value;
		}
	}

	internal static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment align)
	{
		if ((align & _anyRight) != DataGridViewContentAlignment.NotSet)
		{
			return HorizontalAlignment.Right;
		}
		if ((align & _anyCenter) != DataGridViewContentAlignment.NotSet)
		{
			return HorizontalAlignment.Center;
		}
		return HorizontalAlignment.Left;
	}
}
