using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[Designer("ComponentFactory.Krypton.Toolkit.KryptonDateTimePickerColumnDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[ToolboxBitmap(typeof(KryptonDataGridViewDateTimePickerColumn), "ToolboxBitmaps.KryptonDateTimePicker.bmp")]
public class KryptonDataGridViewDateTimePickerColumn : DataGridViewColumn
{
	private DataGridViewColumnSpecCollection _buttonSpecs;

	private DateTimeList _annualDates;

	private DateTimeList _monthlyDates;

	private DateTimeList _dates;

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
			KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell = value as KryptonDataGridViewDateTimePickerCell;
			if (value != null && kryptonDataGridViewDateTimePickerCell == null)
			{
				throw new InvalidCastException("Value provided for CellTemplate must be of type KryptonDataGridViewDateTimePickerCell or derive from it.");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Data")]
	[Description("Set of extra button specs to appear with control.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewColumnSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Appearance")]
	[Description("Determines whether a check box is displayed in the control. When the box is unchecked, no value is selected.")]
	[DefaultValue(false)]
	public bool ShowCheckBox
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.ShowCheckBox;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.ShowCheckBox = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetShowCheckBox(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Appearance")]
	[Description("Indicates whether a spin box rather than a drop-down calendar is displayed for modifying the control value.")]
	[DefaultValue(false)]
	public bool ShowUpDown
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.ShowUpDown;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.ShowUpDown = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetShowUpDown(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Appearance")]
	[Description("Determines whether dates and times are displayed using standard or custom formatting.")]
	[DefaultValue(typeof(DateTimePickerFormat), "Long")]
	[RefreshProperties(RefreshProperties.Repaint)]
	public DateTimePickerFormat Format
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.Format;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.Format = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetFormat(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Determines if keyboard input will automatically shift to the next input field.")]
	[DefaultValue(false)]
	public bool AutoShift
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.AutoShift;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.AutoShift = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetAutoShift(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Determines if the check box is checked and if the ValueNullable is DBNull or a DateTime value.")]
	[DefaultValue(true)]
	public bool Checked
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.Checked;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.Checked = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetChecked(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("The custom format string used to format the date and/or time displayed in the control.")]
	[DefaultValue("")]
	public string CustomFormat
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CustomFormat;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CustomFormat = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCustomFormat(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("The custom text to draw when the control is not checked. Provide an empty string for default action of showing the defined date.")]
	[DefaultValue(" ")]
	public string CustomNullText
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CustomNullText;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CustomNullText = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCustomNullText(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Maximum allowable date.")]
	public DateTime MaxDate
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.MaxDate;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.MaxDate = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetMaxDate(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[Description("Minimum allowable date.")]
	public DateTime MinDate
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.MinDate;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.MinDate = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetMinDate(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Specifies the number of rows and columns of months displayed.")]
	[DefaultValue(typeof(Size), "1,1")]
	public Size CalendarDimensions
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarDimensions;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarDimensions = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarDimensions(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Text used as label for todays date.")]
	[DefaultValue("Today:")]
	public string CalendarTodayText
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarTodayText;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarTodayText = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarTodayText(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("First day of the week.")]
	[DefaultValue(typeof(Day), "Default")]
	public Day CalendarFirstDayOfWeek
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarFirstDayOfWeek;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarFirstDayOfWeek = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarFirstDayOfWeek(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will display todays date.")]
	[DefaultValue(true)]
	public bool CalendarShowToday
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarShowToday;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarShowToday = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarShowToday(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates if clicking the Today button closes the drop down menu.")]
	[DefaultValue(false)]
	public bool CalendarCloseOnTodayClick
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarCloseOnTodayClick;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarCloseOnTodayClick = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarCloseOnTodayClick(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will circle the today date.")]
	[DefaultValue(true)]
	public bool CalendarShowTodayCircle
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarShowTodayCircle;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarShowTodayCircle = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarShowTodayCircle(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will display week numbers to the left of each row.")]
	[DefaultValue(false)]
	public bool CalendarShowWeekNumbers
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarShowWeekNumbers;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarShowWeekNumbers = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarShowWeekNumbers(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Today's date.")]
	public DateTime CalendarTodayDate
	{
		get
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			return DateTimePickerCellTemplate.CalendarTodayDate;
		}
		set
		{
			if (DateTimePickerCellTemplate == null)
			{
				throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
			}
			DateTimePickerCellTemplate.CalendarTodayDate = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is KryptonDataGridViewDateTimePickerCell kryptonDataGridViewDateTimePickerCell)
				{
					kryptonDataGridViewDateTimePickerCell.SetCalendarTodayDate(i, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates which annual dates should be boldface.")]
	[Localizable(true)]
	public DateTime[] CalendarAnnuallyBoldedDates
	{
		get
		{
			return _annualDates.ToArray();
		}
		set
		{
			if (value == null)
			{
				value = new DateTime[0];
			}
			_annualDates.Clear();
			_annualDates.AddRange(value);
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates which monthly dates should be boldface.")]
	[Localizable(true)]
	public DateTime[] CalendarMonthlyBoldedDates
	{
		get
		{
			return _monthlyDates.ToArray();
		}
		set
		{
			if (value == null)
			{
				value = new DateTime[0];
			}
			_monthlyDates.Clear();
			_monthlyDates.AddRange(value);
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates which dates should be boldface.")]
	[Localizable(true)]
	public DateTime[] CalendarBoldedDates
	{
		get
		{
			return _dates.ToArray();
		}
		set
		{
			if (value == null)
			{
				value = new DateTime[0];
			}
			_dates.Clear();
			_dates.AddRange(value);
		}
	}

	private KryptonDataGridViewDateTimePickerCell DateTimePickerCellTemplate => (KryptonDataGridViewDateTimePickerCell)CellTemplate;

	public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick;

	public KryptonDataGridViewDateTimePickerColumn()
		: base(new KryptonDataGridViewDateTimePickerCell())
	{
		_buttonSpecs = new DataGridViewColumnSpecCollection(this);
		_annualDates = new DateTimeList();
		_monthlyDates = new DateTimeList();
		_dates = new DateTimeList();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewDateTimePickerColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewDateTimePickerColumn kryptonDataGridViewDateTimePickerColumn = base.Clone() as KryptonDataGridViewDateTimePickerColumn;
		kryptonDataGridViewDateTimePickerColumn.CalendarAnnuallyBoldedDates = CalendarAnnuallyBoldedDates;
		kryptonDataGridViewDateTimePickerColumn.CalendarMonthlyBoldedDates = CalendarMonthlyBoldedDates;
		kryptonDataGridViewDateTimePickerColumn.CalendarBoldedDates = CalendarBoldedDates;
		foreach (ButtonSpecAny buttonSpec in ButtonSpecs)
		{
			kryptonDataGridViewDateTimePickerColumn.ButtonSpecs.Add(buttonSpec.Clone());
		}
		return kryptonDataGridViewDateTimePickerColumn;
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

	public void ResetCalendarTodayText()
	{
		CalendarTodayText = "Today:";
	}

	private void ResetCalendarTodayDate()
	{
		CalendarTodayDate = DateTime.Now.Date;
	}

	private bool ShouldSerializeCalendarTodayDate()
	{
		return CalendarTodayDate != DateTime.Now.Date;
	}

	public bool ShouldSerializeCalendarAnnuallyBoldedDates()
	{
		return _annualDates.Count > 0;
	}

	private void ResetCalendarAnnuallyBoldedDates()
	{
		CalendarAnnuallyBoldedDates = null;
	}

	public bool ShouldSerializeCalendarMonthlyBoldedDates()
	{
		return _monthlyDates.Count > 0;
	}

	private void ResetCalendarMonthlyBoldedDates()
	{
		CalendarMonthlyBoldedDates = null;
	}

	public bool ShouldSerializeCalendarBoldedDates()
	{
		return _dates.Count > 0;
	}

	private void ResetCalendarBoldedDates()
	{
		CalendarBoldedDates = null;
	}

	internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
	{
		if (this.ButtonSpecClick != null)
		{
			this.ButtonSpecClick(this, args);
		}
	}
}
