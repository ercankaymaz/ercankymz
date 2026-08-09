using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupDateTimePicker), "ToolboxBitmaps.KryptonRibbonGroupDateTimePicker.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupDateTimePickerDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
[DefaultBindingProperty("Value")]
public class KryptonRibbonGroupDateTimePicker : KryptonRibbonGroupItem
{
	private bool _visible;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonDateTimePicker _dateTimePicker;

	private KryptonDateTimePicker _lastDateTimePicker;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _dateTimePickerView;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override KryptonRibbon Ribbon
	{
		set
		{
			base.Ribbon = value;
			if (value != null)
			{
				_dateTimePicker.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to set focus to the date time picker.")]
	public Keys ShortcutKeys
	{
		get
		{
			return _shortcutKeys;
		}
		set
		{
			_shortcutKeys = value;
		}
	}

	[Description("Access to the actual embedded KryptonDateTimePicker instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonDateTimePicker DateTimePicker => _dateTimePicker;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group date time picker key tip.")]
	[DefaultValue("X")]
	public string KeyTip
	{
		get
		{
			return _keyTip;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "X";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the date time picker is visible or hidden.")]
	[DefaultValue(true)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (value != _visible)
			{
				_visible = value;
				OnPropertyChanged("Visible");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the group date time picker is enabled.")]
	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return _dateTimePicker.Enabled;
		}
		set
		{
			_dateTimePicker.Enabled = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the minimum size of the control.")]
	[DefaultValue(typeof(Size), "180, 0")]
	public Size MinimumSize
	{
		get
		{
			return _dateTimePicker.MinimumSize;
		}
		set
		{
			_dateTimePicker.MinimumSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum size of the control.")]
	[DefaultValue(typeof(Size), "180, 0")]
	public Size MaximumSize
	{
		get
		{
			return _dateTimePicker.MaximumSize;
		}
		set
		{
			_dateTimePicker.MaximumSize = value;
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _dateTimePicker.ContextMenuStrip;
		}
		set
		{
			_dateTimePicker.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the date time picker is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _dateTimePicker.KryptonContextMenu;
		}
		set
		{
			_dateTimePicker.KryptonContextMenu = value;
		}
	}

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _dateTimePicker.AllowButtonSpecToolTips;
		}
		set
		{
			_dateTimePicker.AllowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonDateTimePicker.DateTimePickerButtonSpecCollection ButtonSpecs => _dateTimePicker.ButtonSpecs;

	[Category("MonthCalendar")]
	[Description("Specifies the number of rows and columns of months displayed.")]
	[DefaultValue(typeof(Size), "1,1")]
	[Localizable(true)]
	public Size CalendarDimensions
	{
		get
		{
			return _dateTimePicker.CalendarDimensions;
		}
		set
		{
			_dateTimePicker.CalendarDimensions = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Text used as label for todays date.")]
	[DefaultValue("Today:")]
	[Localizable(true)]
	public string CalendarTodayText
	{
		get
		{
			return _dateTimePicker.CalendarTodayText;
		}
		set
		{
			_dateTimePicker.CalendarTodayText = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("First day of the week.")]
	[DefaultValue(typeof(Day), "Default")]
	[Localizable(true)]
	public Day CalendarFirstDayOfWeek
	{
		get
		{
			return _dateTimePicker.CalendarFirstDayOfWeek;
		}
		set
		{
			_dateTimePicker.CalendarFirstDayOfWeek = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates if clicking the Today button closes the drop down menu.")]
	[DefaultValue(false)]
	public bool CalendarCloseOnTodayClick
	{
		get
		{
			return _dateTimePicker.CalendarCloseOnTodayClick;
		}
		set
		{
			_dateTimePicker.CalendarCloseOnTodayClick = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will display todays date.")]
	[DefaultValue(true)]
	public bool CalendarShowToday
	{
		get
		{
			return _dateTimePicker.CalendarShowToday;
		}
		set
		{
			_dateTimePicker.CalendarShowToday = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will circle the today date.")]
	[DefaultValue(true)]
	public bool CalendarShowTodayCircle
	{
		get
		{
			return _dateTimePicker.CalendarShowTodayCircle;
		}
		set
		{
			_dateTimePicker.CalendarShowTodayCircle = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will display week numbers to the left of each row.")]
	[DefaultValue(false)]
	public bool CalendarShowWeekNumbers
	{
		get
		{
			return _dateTimePicker.CalendarShowWeekNumbers;
		}
		set
		{
			_dateTimePicker.CalendarShowWeekNumbers = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Today's date.")]
	public DateTime CalendarTodayDate
	{
		get
		{
			return _dateTimePicker.CalendarTodayDate;
		}
		set
		{
			_dateTimePicker.CalendarTodayDate = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates which annual dates should be boldface.")]
	[Localizable(true)]
	public DateTime[] CalendarAnnuallyBoldedDates
	{
		get
		{
			return _dateTimePicker.CalendarAnnuallyBoldedDates;
		}
		set
		{
			_dateTimePicker.CalendarAnnuallyBoldedDates = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates which monthly dates should be boldface.")]
	[Localizable(true)]
	public DateTime[] CalendarMonthlyBoldedDates
	{
		get
		{
			return _dateTimePicker.CalendarMonthlyBoldedDates;
		}
		set
		{
			_dateTimePicker.CalendarMonthlyBoldedDates = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates which dates should be boldface.")]
	[Localizable(true)]
	public DateTime[] CalendarBoldedDates
	{
		get
		{
			return _dateTimePicker.CalendarBoldedDates;
		}
		set
		{
			_dateTimePicker.CalendarBoldedDates = value;
		}
	}

	[Category("Appearance")]
	[Description("Alignment of the drop-down calendar on the KryptonDateTimePicker control.")]
	[DefaultValue(typeof(LeftRightAlignment), "Left")]
	[Localizable(true)]
	public LeftRightAlignment DropDownAlign
	{
		get
		{
			return _dateTimePicker.DropDownAlign;
		}
		set
		{
			_dateTimePicker.DropDownAlign = value;
		}
	}

	[Category("Appearance")]
	[Description("Property for the date/time that can be null.")]
	[TypeConverter(typeof(DateTimeNullableConverter))]
	[RefreshProperties(RefreshProperties.All)]
	[Bindable(true)]
	public object ValueNullable
	{
		get
		{
			return _dateTimePicker.ValueNullable;
		}
		set
		{
			_dateTimePicker.ValueNullable = value;
		}
	}

	[Category("Appearance")]
	[Description("Property for the date/time.")]
	[RefreshProperties(RefreshProperties.All)]
	[Bindable(true)]
	public DateTime Value
	{
		get
		{
			return _dateTimePicker.Value;
		}
		set
		{
			_dateTimePicker.Value = value;
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
			return _dateTimePicker.Format;
		}
		set
		{
			_dateTimePicker.Format = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates whether a spin box rather than a drop-down calendar is displayed for modifying the control value.")]
	[DefaultValue(false)]
	public bool ShowUpDown
	{
		get
		{
			return _dateTimePicker.ShowUpDown;
		}
		set
		{
			_dateTimePicker.ShowUpDown = value;
		}
	}

	[Category("Appearance")]
	[Description("Determines whether a check box is displayed in the control. When the box is unchecked, no value is selected.")]
	[DefaultValue(false)]
	public bool ShowCheckBox
	{
		get
		{
			return _dateTimePicker.ShowCheckBox;
		}
		set
		{
			_dateTimePicker.ShowCheckBox = value;
		}
	}

	[Category("Appearance")]
	[Description("Defines if mnemonic characters generate click events for button specs.")]
	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return _dateTimePicker.UseMnemonic;
		}
		set
		{
			_dateTimePicker.UseMnemonic = value;
		}
	}

	[Category("Behavior")]
	[Description("Maximum allowable date.")]
	public DateTime MaxDate
	{
		get
		{
			return _dateTimePicker.MaxDate;
		}
		set
		{
			_dateTimePicker.MaxDate = value;
		}
	}

	[Category("Behavior")]
	[Description("Minimum allowable date.")]
	public DateTime MinDate
	{
		get
		{
			return _dateTimePicker.MinDate;
		}
		set
		{
			_dateTimePicker.MinDate = value;
		}
	}

	[Category("Behavior")]
	[Description("Determines if the check box is checked and if the ValueNullable is DBNull or a DateTime value.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool Checked
	{
		get
		{
			return _dateTimePicker.Checked;
		}
		set
		{
			_dateTimePicker.Checked = value;
		}
	}

	[Category("Behavior")]
	[Description("The custom format string used to format the date and/or time displayed in the control.")]
	[DefaultValue("")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Localizable(true)]
	public string CustomFormat
	{
		get
		{
			return _dateTimePicker.CustomFormat;
		}
		set
		{
			_dateTimePicker.CustomFormat = value;
		}
	}

	[Category("Behavior")]
	[Description("The custom text to draw when the control is not checked. Provide an empty string for default action of showing the defined date.")]
	[DefaultValue("")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Localizable(true)]
	public string CustomNullText
	{
		get
		{
			return _dateTimePicker.CustomNullText;
		}
		set
		{
			_dateTimePicker.CustomNullText = value;
		}
	}

	[Category("Visuals - MonthCalendar")]
	[Description("The today format string used to format the date displayed in the today button.")]
	[DefaultValue("d")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Localizable(true)]
	public string CalendarTodayFormat
	{
		get
		{
			return _dateTimePicker.CalendarTodayFormat;
		}
		set
		{
			_dateTimePicker.CalendarTodayFormat = value;
		}
	}

	[Category("Visuals - MonthCalendar")]
	[Description("Header style for the month calendar.")]
	public HeaderStyle CalendarHeaderStyle
	{
		get
		{
			return _dateTimePicker.CalendarHeaderStyle;
		}
		set
		{
			_dateTimePicker.CalendarHeaderStyle = value;
		}
	}

	[Category("Visuals - MonthCalendar")]
	[Description("Content style for the day entries.")]
	public ButtonStyle CalendarDayStyle
	{
		get
		{
			return _dateTimePicker.CalendarDayStyle;
		}
		set
		{
			_dateTimePicker.CalendarDayStyle = value;
		}
	}

	[Category("Visuals - MonthCalendar")]
	[Description("Content style for the day of week labels.")]
	public ButtonStyle CalendarDayOfWeekStyle
	{
		get
		{
			return _dateTimePicker.CalendarDayOfWeekStyle;
		}
		set
		{
			_dateTimePicker.CalendarDayOfWeekStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMaximum
	{
		get
		{
			return GroupItemSize.Large;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMinimum
	{
		get
		{
			return GroupItemSize.Small;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeCurrent
	{
		get
		{
			return _itemSizeCurrent;
		}
		set
		{
			if (_itemSizeCurrent != value)
			{
				_itemSizeCurrent = value;
				OnPropertyChanged("ItemSizeCurrent");
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public IKryptonDesignObject DateTimePickerDesigner
	{
		get
		{
			return _designer;
		}
		set
		{
			_designer = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase DateTimePickerView
	{
		get
		{
			return _dateTimePickerView;
		}
		set
		{
			_dateTimePickerView = value;
		}
	}

	internal Control LastParentControl
	{
		get
		{
			return _lastParentControl;
		}
		set
		{
			_lastParentControl = value;
		}
	}

	internal KryptonDateTimePicker LastDateTimePicker
	{
		get
		{
			return _lastDateTimePicker;
		}
		set
		{
			_lastDateTimePicker = value;
		}
	}

	internal NeedPaintHandler ViewPaintDelegate
	{
		get
		{
			return _viewPaintDelegate;
		}
		set
		{
			_viewPaintDelegate = value;
		}
	}

	[Browsable(false)]
	public event EventHandler GotFocus;

	[Browsable(false)]
	public event EventHandler LostFocus;

	[Category("Action")]
	[Description("Event raised when the value of the Value property is changed.")]
	public event EventHandler ValueChanged;

	[Category("Action")]
	[Description("Event raised when the value of the ValueNullable property is changed.")]
	public event EventHandler ValueNullableChanged;

	[Category("Action")]
	[Description("Event raised when the drop down is shown.")]
	public event EventHandler<DateTimePickerDropArgs> DropDown;

	[Category("Action")]
	[Description("Event raised when the drop down has been closed.")]
	public event EventHandler<DateTimePickerCloseArgs> CloseUp;

	[Category("Property Changed")]
	[Description("Event raised when the value of the Checked property is changed.")]
	public event EventHandler CheckedChanged;

	[Category("Property Changed")]
	[Description("Event raised when the value of the Format property is changed.")]
	public event EventHandler FormatChanged;

	[Description("Occurs when a key is pressed while the control has focus.")]
	[Category("Key")]
	public event KeyPressEventHandler KeyPress;

	[Description("Occurs when a key is released while the control has focus.")]
	[Category("Key")]
	public event KeyEventHandler KeyUp;

	[Description("Occurs when a key is pressed while the control has focus.")]
	[Category("Key")]
	public event KeyEventHandler KeyDown;

	[Description("Occurs before the KeyDown event when a key is pressed while focus is on this control.")]
	[Category("Key")]
	public event PreviewKeyDownEventHandler PreviewKeyDown;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupDateTimePicker()
	{
		_visible = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_shortcutKeys = Keys.None;
		_keyTip = "X";
		_dateTimePicker = new KryptonDateTimePicker();
		_dateTimePicker.InputControlStyle = InputControlStyle.Ribbon;
		_dateTimePicker.AlwaysActive = false;
		_dateTimePicker.MinimumSize = new Size(180, 0);
		_dateTimePicker.MaximumSize = new Size(180, 0);
		_dateTimePicker.TabStop = false;
		_dateTimePicker.ValueChanged += OnDateTimePickerValueChanged;
		_dateTimePicker.ValueNullableChanged += OnDateTimePickerValueNullableChanged;
		_dateTimePicker.DropDown += OnDateTimePickerDropDown;
		_dateTimePicker.CloseUp += OnDateTimePickerCloseUp;
		_dateTimePicker.CheckedChanged += OnDateTimePickerCheckedChanged;
		_dateTimePicker.FormatChanged += OnDateTimePickerFormatChanged;
		_dateTimePicker.GotFocus += OnDateTimePickerGotFocus;
		_dateTimePicker.LostFocus += OnDateTimePickerLostFocus;
		_dateTimePicker.KeyDown += OnDateTimePickerKeyDown;
		_dateTimePicker.KeyUp += OnDateTimePickerKeyUp;
		_dateTimePicker.KeyPress += OnDateTimePickerKeyPress;
		_dateTimePicker.PreviewKeyDown += OnDateTimePickerKeyDown;
		MonitorControl(_dateTimePicker);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _dateTimePicker != null)
		{
			UnmonitorControl(_dateTimePicker);
			_dateTimePicker.Dispose();
			_dateTimePicker = null;
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys != Keys.None;
	}

	public void ResetShortcutKeys()
	{
		ShortcutKeys = Keys.None;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	private void ResetCalendarTodayText()
	{
		_dateTimePicker.ResetCalendarTodayText();
	}

	private void ResetCalendarTodayDate()
	{
		CalendarTodayDate = DateTime.Now.Date;
	}

	private bool ShouldSerializeCalendarTodayDate()
	{
		return CalendarTodayDate != DateTime.Now.Date;
	}

	private void ResetCalendarAnnuallyBoldedDates()
	{
		CalendarAnnuallyBoldedDates = null;
	}

	private bool ShouldSerializeCalendarAnnuallyBoldedDates()
	{
		return _dateTimePicker.ShouldSerializeCalendarAnnuallyBoldedDates();
	}

	private void ResetCalendarMonthlyBoldedDates()
	{
		CalendarMonthlyBoldedDates = null;
	}

	private bool ShouldSerializeCalendarMonthlyBoldedDates()
	{
		return _dateTimePicker.ShouldSerializeCalendarMonthlyBoldedDates();
	}

	private void ResetCalendarBoldedDates()
	{
		CalendarBoldedDates = null;
	}

	private bool ShouldSerializeCalendarBoldedDates()
	{
		return _dateTimePicker.ShouldSerializeCalendarBoldedDates();
	}

	private void ResetValueNullable()
	{
		_dateTimePicker.ResetValueNullable();
	}

	private bool ShouldSerializeValueNullable()
	{
		return _dateTimePicker.ShouldSerializeValueNullable();
	}

	private void ResetValue()
	{
		_dateTimePicker.ResetValue();
	}

	private bool ShouldSerializeValue()
	{
		return _dateTimePicker.ShouldSerializeValue();
	}

	private void ResetMaxDate()
	{
		MaxDate = DateTime.MaxValue;
	}

	private bool ShouldSerializeMaxDate()
	{
		return _dateTimePicker.ShouldSerializeMaxDate();
	}

	private void ResetMinDate()
	{
		MinDate = DateTime.MinValue;
	}

	private bool ShouldSerializeMinDate()
	{
		return _dateTimePicker.ShouldSerializeMinDate();
	}

	private void ResetCalendarHeaderStyle()
	{
		CalendarHeaderStyle = HeaderStyle.Calendar;
	}

	private bool ShouldSerializeCalendarHeaderStyle()
	{
		return CalendarHeaderStyle != HeaderStyle.Calendar;
	}

	private void ResetCalendarDayStyle()
	{
		CalendarDayStyle = ButtonStyle.CalendarDay;
	}

	private bool ShouldSerializeCalendarDayStyle()
	{
		return CalendarDayStyle != ButtonStyle.CalendarDay;
	}

	private void ResetCalendarDayOfWeekStyle()
	{
		CalendarDayOfWeekStyle = ButtonStyle.CalendarDay;
	}

	private bool ShouldSerializeCalendarDayOfWeekStyle()
	{
		return CalendarDayOfWeekStyle != ButtonStyle.CalendarDay;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupDateTimePicker(ribbon, this, needPaint);
	}

	protected virtual void OnGotFocus(EventArgs e)
	{
		if (this.GotFocus != null)
		{
			this.GotFocus(this, e);
		}
	}

	protected virtual void OnLostFocus(EventArgs e)
	{
		if (this.LostFocus != null)
		{
			this.LostFocus(this, e);
		}
	}

	protected virtual void OnFormatChanged(EventArgs e)
	{
		if (this.FormatChanged != null)
		{
			this.FormatChanged(this, e);
		}
	}

	protected virtual void OnCheckedChanged(EventArgs e)
	{
		if (this.CheckedChanged != null)
		{
			this.CheckedChanged(this, e);
		}
	}

	protected virtual void OnCloseUp(DateTimePickerCloseArgs e)
	{
		if (this.CloseUp != null)
		{
			this.CloseUp(this, e);
		}
	}

	protected virtual void OnDropDown(DateTimePickerDropArgs e)
	{
		if (this.DropDown != null)
		{
			this.DropDown(this, e);
		}
	}

	protected virtual void OnValueNullableChanged(EventArgs e)
	{
		if (this.ValueNullableChanged != null)
		{
			this.ValueNullableChanged(this, e);
		}
	}

	protected virtual void OnValueChanged(EventArgs e)
	{
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, e);
		}
	}

	protected virtual void OnKeyDown(KeyEventArgs e)
	{
		if (this.KeyDown != null)
		{
			this.KeyDown(this, e);
		}
	}

	protected virtual void OnKeyUp(KeyEventArgs e)
	{
		if (this.KeyUp != null)
		{
			this.KeyUp(this, e);
		}
	}

	protected virtual void OnKeyPress(KeyPressEventArgs e)
	{
		if (this.KeyPress != null)
		{
			this.KeyPress(this, e);
		}
	}

	protected virtual void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
	{
		if (this.PreviewKeyDown != null)
		{
			this.PreviewKeyDown(this, e);
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	internal void OnDesignTimeContextMenu(MouseEventArgs e)
	{
		if (this.DesignTimeContextMenu != null)
		{
			this.DesignTimeContextMenu(this, e);
		}
	}

	internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (Enabled && base.ChainVisible && ShortcutKeys != Keys.None && ShortcutKeys == keyData)
		{
			if (LastDateTimePicker != null && LastDateTimePicker.CanFocus)
			{
				LastDateTimePicker.Focus();
			}
			return true;
		}
		return false;
	}

	private void MonitorControl(KryptonDateTimePicker c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonDateTimePicker c)
	{
		c.MouseEnter -= OnControlEnter;
		c.MouseLeave -= OnControlLeave;
	}

	private void OnControlEnter(object sender, EventArgs e)
	{
		if (this.MouseEnterControl != null)
		{
			this.MouseEnterControl(this, e);
		}
	}

	private void OnControlLeave(object sender, EventArgs e)
	{
		if (this.MouseLeaveControl != null)
		{
			this.MouseLeaveControl(this, e);
		}
	}

	private void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (_viewPaintDelegate != null)
		{
			_viewPaintDelegate(this, e);
		}
	}

	private void OnDateTimePickerGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnDateTimePickerLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnDateTimePickerFormatChanged(object sender, EventArgs e)
	{
		OnFormatChanged(e);
	}

	private void OnDateTimePickerCheckedChanged(object sender, EventArgs e)
	{
		OnCheckedChanged(e);
	}

	private void OnDateTimePickerCloseUp(object sender, DateTimePickerCloseArgs e)
	{
		OnCloseUp(e);
	}

	private void OnDateTimePickerDropDown(object sender, DateTimePickerDropArgs e)
	{
		OnDropDown(e);
	}

	private void OnDateTimePickerValueNullableChanged(object sender, EventArgs e)
	{
		OnValueNullableChanged(e);
	}

	private void OnDateTimePickerValueChanged(object sender, EventArgs e)
	{
		OnValueChanged(e);
	}

	private void OnDateTimePickerKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnDateTimePickerKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnDateTimePickerKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnDateTimePickerKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_dateTimePicker.Palette = Ribbon.GetResolvedPalette();
	}
}
