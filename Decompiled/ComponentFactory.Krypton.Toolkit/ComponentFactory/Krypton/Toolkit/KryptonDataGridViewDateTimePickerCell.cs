using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewDateTimePickerCell : DataGridViewTextBoxCell
{
	[ThreadStatic]
	private static KryptonDateTimePicker _paintingDateTime;

	private static DateTimeConverter _dtc = new DateTimeConverter();

	private static readonly Type _defaultEditType = typeof(KryptonDataGridViewDateTimePickerEditingControl);

	private static readonly Type _defaultValueType = typeof(DateTime);

	private static readonly Size _sizeLarge = new Size(10000, 10000);

	private bool _showCheckBox;

	private bool _showUpDown;

	private bool _autoShift;

	private bool _checked;

	private string _customFormat;

	private string _customNullText;

	private DateTime _maxDate;

	private DateTime _minDate;

	private DateTimePickerFormat _format;

	private Size _calendarDimensions;

	private string _calendarTodayText;

	private Day _calendarFirstDayOfWeek;

	private bool _calendarShowToday;

	private bool _calendarCloseOnTodayClick;

	private bool _calendarShowTodayCircle;

	private bool _calendarShowWeekNumbers;

	private DateTime _calendarTodayDate;

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

	[DefaultValue(false)]
	public bool ShowCheckBox
	{
		get
		{
			return _showCheckBox;
		}
		set
		{
			if (_showCheckBox != value)
			{
				SetShowCheckBox(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool ShowUpDown
	{
		get
		{
			return _showUpDown;
		}
		set
		{
			if (_showUpDown != value)
			{
				SetShowUpDown(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool AutoShift
	{
		get
		{
			return _autoShift;
		}
		set
		{
			if (_autoShift != value)
			{
				SetAutoShift(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(false)]
	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (_checked != value)
			{
				SetChecked(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue("")]
	public string CustomFormat
	{
		get
		{
			return _customFormat;
		}
		set
		{
			if (_customFormat != value)
			{
				SetCustomFormat(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(" ")]
	public string CustomNullText
	{
		get
		{
			return _customNullText;
		}
		set
		{
			if (_customNullText != value)
			{
				SetCustomNullText(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	public DateTime MaxDate
	{
		get
		{
			return _maxDate;
		}
		set
		{
			if (_maxDate != value)
			{
				SetMaxDate(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	public DateTime MinDate
	{
		get
		{
			return _minDate;
		}
		set
		{
			if (_minDate != value)
			{
				SetMinDate(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(typeof(DateTimePickerFormat), "Long")]
	public DateTimePickerFormat Format
	{
		get
		{
			return _format;
		}
		set
		{
			if (_format != value)
			{
				SetFormat(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(typeof(Size), "1,1")]
	public Size CalendarDimensions
	{
		get
		{
			return _calendarDimensions;
		}
		set
		{
			if (_calendarDimensions != value)
			{
				SetCalendarDimensions(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue("Today:")]
	public string CalendarTodayText
	{
		get
		{
			return _calendarTodayText;
		}
		set
		{
			if (_calendarTodayText != value)
			{
				SetCalendarTodayText(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(typeof(Day), "Default")]
	public Day CalendarFirstDayOfWeek
	{
		get
		{
			return _calendarFirstDayOfWeek;
		}
		set
		{
			if (_calendarFirstDayOfWeek != value)
			{
				SetCalendarFirstDayOfWeek(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool CalendarShowToday
	{
		get
		{
			return _calendarShowToday;
		}
		set
		{
			if (_calendarShowToday != value)
			{
				SetCalendarShowToday(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool CalendarCloseOnTodayClick
	{
		get
		{
			return _calendarCloseOnTodayClick;
		}
		set
		{
			if (_calendarCloseOnTodayClick != value)
			{
				SetCalendarCloseOnTodayClick(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool CalendarShowTodayCircle
	{
		get
		{
			return _calendarShowTodayCircle;
		}
		set
		{
			if (_calendarShowTodayCircle != value)
			{
				SetCalendarShowTodayCircle(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public bool CalendarShowWeekNumbers
	{
		get
		{
			return _calendarShowWeekNumbers;
		}
		set
		{
			if (_calendarShowWeekNumbers != value)
			{
				SetCalendarShowWeekNumbers(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	[DefaultValue(true)]
	public DateTime CalendarTodayDate
	{
		get
		{
			return _calendarTodayDate;
		}
		set
		{
			if (_calendarTodayDate != value)
			{
				SetCalendarTodayDate(base.RowIndex, value);
				OnCommonChange();
			}
		}
	}

	private KryptonDataGridViewDateTimePickerEditingControl EditingDateTimePicker => base.DataGridView.EditingControl as KryptonDataGridViewDateTimePickerEditingControl;

	public KryptonDataGridViewDateTimePickerCell()
	{
		if (_paintingDateTime == null)
		{
			_paintingDateTime = new KryptonDateTimePicker();
			_paintingDateTime.ShowBorder = false;
			_paintingDateTime.StateCommon.Border.Width = 0;
			_paintingDateTime.StateCommon.Border.Draw = InheritBool.False;
		}
		_showCheckBox = false;
		_showUpDown = false;
		_autoShift = false;
		_checked = false;
		_customFormat = string.Empty;
		_customNullText = " ";
		_maxDate = DateTime.MaxValue;
		_minDate = DateTime.MinValue;
		_format = DateTimePickerFormat.Long;
		_calendarDimensions = new Size(1, 1);
		_calendarTodayText = "Today:";
		_calendarFirstDayOfWeek = Day.Default;
		_calendarShowToday = true;
		_calendarCloseOnTodayClick = false;
		_calendarShowTodayCircle = true;
		_calendarShowWeekNumbers = false;
		_calendarTodayDate = DateTime.Now.Date;
	}

	public override string ToString()
	{
		return "KryptonDataGridViewDateTimePickerCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
	}

	public override object Clone()
	{
		KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell = base.Clone() as KryptonDataGridViewDateTimePickerCell;
		if (kryptonDataGridViewDateTimePickerCell != null)
		{
			kryptonDataGridViewDateTimePickerCell.AutoShift = AutoShift;
			kryptonDataGridViewDateTimePickerCell.Checked = Checked;
			kryptonDataGridViewDateTimePickerCell.ShowCheckBox = ShowCheckBox;
			kryptonDataGridViewDateTimePickerCell.ShowUpDown = ShowUpDown;
			kryptonDataGridViewDateTimePickerCell.CustomFormat = CustomFormat;
			kryptonDataGridViewDateTimePickerCell.CustomNullText = CustomNullText;
			kryptonDataGridViewDateTimePickerCell.MaxDate = MaxDate;
			kryptonDataGridViewDateTimePickerCell.MinDate = MinDate;
			kryptonDataGridViewDateTimePickerCell.Format = Format;
			kryptonDataGridViewDateTimePickerCell.CalendarDimensions = CalendarDimensions;
			kryptonDataGridViewDateTimePickerCell.CalendarTodayText = CalendarTodayText;
			kryptonDataGridViewDateTimePickerCell.CalendarFirstDayOfWeek = CalendarFirstDayOfWeek;
			kryptonDataGridViewDateTimePickerCell.CalendarShowToday = CalendarShowToday;
			kryptonDataGridViewDateTimePickerCell.CalendarCloseOnTodayClick = CalendarCloseOnTodayClick;
			kryptonDataGridViewDateTimePickerCell.CalendarShowTodayCircle = CalendarShowTodayCircle;
			kryptonDataGridViewDateTimePickerCell.CalendarShowWeekNumbers = CalendarShowWeekNumbers;
			kryptonDataGridViewDateTimePickerCell.CalendarTodayDate = CalendarTodayDate;
		}
		return kryptonDataGridViewDateTimePickerCell;
	}

	public bool ShouldSerializeMaxDate()
	{
		return MaxDate != DateTimePicker.MaximumDateTime && MaxDate != DateTime.MaxValue;
	}

	private void ResetMaxDate()
	{
		MaxDate = DateTime.MaxValue;
	}

	public bool ShouldSerializeMinDate()
	{
		return MinDate != DateTimePicker.MinimumDateTime && MinDate != DateTime.MinValue;
	}

	private void ResetMinDate()
	{
		MinDate = DateTime.MinValue;
	}

	private void ResetCalendarTodayDate()
	{
		CalendarTodayDate = DateTime.Now.Date;
	}

	private bool ShouldSerializeCalendarTodayDate()
	{
		return CalendarTodayDate != DateTime.Now.Date;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override void DetachEditingControl()
	{
		DataGridView dataGridView = base.DataGridView;
		if (dataGridView == null || dataGridView.EditingControl == null)
		{
			throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
		}
		if (dataGridView.EditingControl is KryptonDateTimePicker kryptonDateTimePicker && base.OwningColumn is KryptonDataGridViewDateTimePickerColumn)
		{
			foreach (ButtonSpecAny buttonSpec in kryptonDateTimePicker.ButtonSpecs)
			{
				buttonSpec.Click -= OnButtonClick;
			}
			kryptonDateTimePicker.ButtonSpecs.Clear();
		}
		base.DetachEditingControl();
	}

	public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
		if (!(base.DataGridView.EditingControl is KryptonDateTimePicker kryptonDateTimePicker))
		{
			return;
		}
		if (base.OwningColumn is KryptonDataGridViewDateTimePickerColumn kryptonDataGridViewDateTimePickerColumn)
		{
			kryptonDateTimePicker.ShowCheckBox = ShowCheckBox;
			kryptonDateTimePicker.ShowUpDown = ShowUpDown;
			kryptonDateTimePicker.AutoShift = AutoShift;
			kryptonDateTimePicker.Checked = Checked;
			kryptonDateTimePicker.CustomFormat = CustomFormat;
			kryptonDateTimePicker.CustomNullText = CustomNullText;
			kryptonDateTimePicker.MaxDate = MaxDate;
			kryptonDateTimePicker.MinDate = MinDate;
			kryptonDateTimePicker.Format = Format;
			kryptonDateTimePicker.CalendarDimensions = CalendarDimensions;
			kryptonDateTimePicker.CalendarTodayText = CalendarTodayText;
			kryptonDateTimePicker.CalendarFirstDayOfWeek = CalendarFirstDayOfWeek;
			kryptonDateTimePicker.CalendarShowToday = CalendarShowToday;
			kryptonDateTimePicker.CalendarCloseOnTodayClick = CalendarCloseOnTodayClick;
			kryptonDateTimePicker.CalendarShowTodayCircle = CalendarShowTodayCircle;
			kryptonDateTimePicker.CalendarShowWeekNumbers = CalendarShowWeekNumbers;
			kryptonDateTimePicker.CalendarTodayDate = CalendarTodayDate;
			kryptonDateTimePicker.CalendarAnnuallyBoldedDates = kryptonDataGridViewDateTimePickerColumn.CalendarAnnuallyBoldedDates;
			kryptonDateTimePicker.CalendarMonthlyBoldedDates = kryptonDataGridViewDateTimePickerColumn.CalendarMonthlyBoldedDates;
			kryptonDateTimePicker.CalendarBoldedDates = kryptonDataGridViewDateTimePickerColumn.CalendarBoldedDates;
			kryptonDateTimePicker.ButtonSpecs.Clear();
			kryptonDateTimePicker.ButtonSpecs.Owner = base.DataGridView.Rows[rowIndex].Cells[base.ColumnIndex];
			foreach (ButtonSpecAny buttonSpec in kryptonDataGridViewDateTimePickerColumn.ButtonSpecs)
			{
				buttonSpec.Click += OnButtonClick;
				kryptonDateTimePicker.ButtonSpecs.Add((object)buttonSpec);
			}
		}
		if (!(initialFormattedValue is string text) || string.IsNullOrEmpty(text))
		{
			kryptonDateTimePicker.ValueNullable = null;
			return;
		}
		DateTime value = (DateTime)_dtc.ConvertFromInvariantString(text);
		bool flag = true;
		kryptonDateTimePicker.Value = value;
	}

	protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
	{
		if (value == null || value == DBNull.Value)
		{
			return string.Empty;
		}
		DateTime dateTime = (DateTime)value;
		bool flag = true;
		return _dtc.ConvertToInvariantString(dateTime);
	}

	public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
	{
		if (formattedValue == null)
		{
			return DBNull.Value;
		}
		string text = (string)formattedValue;
		if (string.IsNullOrEmpty(text))
		{
			return DBNull.Value;
		}
		return _dtc.ConvertFromInvariantString(text);
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

	protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
	{
		if (base.DataGridView != null)
		{
			_paintingDateTime.RightToLeft = base.DataGridView.RightToLeft;
			_paintingDateTime.Format = Format;
			_paintingDateTime.CustomFormat = CustomFormat;
			_paintingDateTime.CustomNullText = CustomNullText;
			_paintingDateTime.MaxDate = MaxDate;
			_paintingDateTime.MinDate = MinDate;
			string formattedValue2 = CustomNullText;
			if (value == null || value == DBNull.Value)
			{
				_paintingDateTime.ValueNullable = value;
				_paintingDateTime.PerformLayout();
			}
			else
			{
				_paintingDateTime.Value = (DateTime)value;
				_paintingDateTime.PerformLayout();
				formattedValue2 = _paintingDateTime.Text;
			}
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, (object)formattedValue2, errorText, cellStyle, advancedBorderStyle, paintParts);
		}
	}

	private void OnButtonClick(object sender, EventArgs e)
	{
		KryptonDataGridViewDateTimePickerColumn kryptonDataGridViewDateTimePickerColumn = base.OwningColumn as KryptonDataGridViewDateTimePickerColumn;
		DataGridViewButtonSpecClickEventArgs args = new DataGridViewButtonSpecClickEventArgs(kryptonDataGridViewDateTimePickerColumn, this, (ButtonSpecAny)sender);
		kryptonDataGridViewDateTimePickerColumn.PerfomButtonSpecClick(args);
	}

	private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
	{
		int num = _paintingDateTime.GetPreferredSize(_sizeLarge).Height + 2;
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

	private bool OwnsEditingDateTimePicker(int rowIndex)
	{
		if (rowIndex == -1 || base.DataGridView == null)
		{
			return false;
		}
		return base.DataGridView.EditingControl is KryptonDataGridViewDateTimePickerEditingControl kryptonDataGridViewDateTimePickerEditingControl && rowIndex == ((IDataGridViewEditingControl)kryptonDataGridViewDateTimePickerEditingControl).EditingControlRowIndex;
	}

	private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
	{
		return (paintParts & paintPart) != 0;
	}

	internal void SetShowCheckBox(int rowIndex, bool value)
	{
		_showCheckBox = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.ShowCheckBox = value;
		}
	}

	internal void SetShowUpDown(int rowIndex, bool value)
	{
		_showUpDown = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.ShowUpDown = value;
		}
	}

	internal void SetAutoShift(int rowIndex, bool value)
	{
		_autoShift = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.AutoShift = value;
		}
	}

	internal void SetChecked(int rowIndex, bool value)
	{
		_checked = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.Checked = value;
		}
	}

	internal void SetCustomFormat(int rowIndex, string value)
	{
		_customFormat = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CustomFormat = value;
		}
	}

	internal void SetCustomNullText(int rowIndex, string value)
	{
		_customNullText = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CustomNullText = value;
		}
	}

	internal void SetMaxDate(int rowIndex, DateTime value)
	{
		_maxDate = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.MaxDate = value;
		}
	}

	internal void SetMinDate(int rowIndex, DateTime value)
	{
		_minDate = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.MinDate = value;
		}
	}

	internal void SetFormat(int rowIndex, DateTimePickerFormat value)
	{
		_format = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.Format = value;
		}
	}

	internal void SetCalendarCloseOnTodayClick(int rowIndex, bool value)
	{
		_calendarCloseOnTodayClick = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarCloseOnTodayClick = value;
		}
	}

	internal void SetCalendarDimensions(int rowIndex, Size value)
	{
		_calendarDimensions = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarDimensions = value;
		}
	}

	internal void SetCalendarFirstDayOfWeek(int rowIndex, Day value)
	{
		_calendarFirstDayOfWeek = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarFirstDayOfWeek = value;
		}
	}

	internal void SetCalendarShowToday(int rowIndex, bool value)
	{
		_calendarShowToday = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarShowToday = value;
		}
	}

	internal void SetCalendarShowTodayCircle(int rowIndex, bool value)
	{
		_calendarShowTodayCircle = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarShowTodayCircle = value;
		}
	}

	internal void SetCalendarShowWeekNumbers(int rowIndex, bool value)
	{
		_calendarShowWeekNumbers = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarShowWeekNumbers = value;
		}
	}

	internal void SetCalendarTodayText(int rowIndex, string value)
	{
		_calendarTodayText = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarTodayText = value;
		}
	}

	internal void SetCalendarTodayDate(int rowIndex, DateTime value)
	{
		_calendarTodayDate = value;
		if (OwnsEditingDateTimePicker(rowIndex))
		{
			EditingDateTimePicker.CalendarTodayDate = value;
		}
	}
}
