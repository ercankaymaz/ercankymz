using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonDateTimePicker), "ToolboxBitmaps.KryptonDateTimePicker.bmp")]
[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
[DefaultBindingProperty("Value")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonDateTimePickerDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Enables the user to select a date and time, and to display that date and time in a specified format.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonDateTimePicker : VisualControlBase, IContentValues
{
	public class DateTimePickerButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public DateTimePickerButtonSpecCollection(KryptonDateTimePicker owner)
			: base((object)owner)
		{
		}
	}

	private static readonly string _defaultToday = "Today:";

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutDocker _drawDockerInner;

	private ViewLayoutStretch _dropStretch;

	private ViewLayoutFit _upDownFit;

	private PaletteTripleToPalette _paletteDropDown;

	private PaletteTripleToPalette _paletteUpDown;

	private ViewDrawDateTimeButton _buttonDropDown;

	private ViewDrawDateTimeButton _buttonUp;

	private ViewDrawDateTimeButton _buttonDown;

	private ViewDrawDateTimeText _drawText;

	private ViewDrawCheckBox _drawCheckBox;

	private ViewLayoutCenter _layoutCheckBox;

	private CheckBoxImages _checkBoxImages;

	private PaletteInputControlTripleRedirect _stateCommon;

	private PaletteInputControlTripleStates _stateDisabled;

	private PaletteInputControlTripleStates _stateNormal;

	private PaletteInputControlTripleStates _stateActive;

	private DateTimePickerButtonSpecCollection _buttonSpecs;

	private ButtonSpecManagerDraw _buttonManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ToolTipManager _toolTipManager;

	private KryptonContextMenuMonthCalendar _kmc;

	private InputControlStyle _inputControlStyle;

	private ButtonStyle _upDownButtonStyle;

	private ButtonStyle _dropButtonStyle;

	private HeaderStyle _headerStyle;

	private ButtonStyle _dayStyle;

	private ButtonStyle _dayOfWeekStyle;

	private bool? _fixedActive;

	private DateTimePickerFormat _format;

	private LeftRightAlignment _dropDownAlign;

	private DateTime _maxDateTime;

	private DateTime _minDateTime;

	private DateTime _dateTime;

	private DateTime _todayDate;

	private Size _dimensions;

	private DateTimeList _annualDates;

	private DateTimeList _monthlyDates;

	private DateTimeList _dates;

	private string _customFormat;

	private string _todayFormat;

	private string _today;

	private string _customNullText;

	private string _lastActiveFragment;

	private bool _inRibbonDesignMode;

	private bool _allowButtonSpecToolTips;

	private bool _autoShift;

	private bool _showAdornments;

	private bool _showUpDown;

	private bool _showCheckBox;

	private bool _showWeekNumbers;

	private bool _showTodayCircle;

	private bool _showToday;

	private bool _mouseOver;

	private bool _dropped;

	private bool _alwaysActive;

	private bool _userSetDateTime;

	private bool _dropDownMonthChanged;

	private bool _closeOnTodayClick;

	private object _rawDateTime;

	private Day _firstDayOfWeek;

	private int _cachedHeight;

	[Browsable(false)]
	[Bindable(false)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public override string Text
	{
		get
		{
			if (ValueNullable == null || ValueNullable == DBNull.Value)
			{
				return string.Empty;
			}
			return _drawText.ToString();
		}
		set
		{
		}
	}

	[Category("MonthCalendar")]
	[Description("Specifies the number of rows and columns of months displayed.")]
	[DefaultValue(typeof(Size), "1,1")]
	[Localizable(true)]
	public Size CalendarDimensions
	{
		get
		{
			return _dimensions;
		}
		set
		{
			_dimensions = value;
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
			return _today;
		}
		set
		{
			if (value == null)
			{
				value = _defaultToday;
			}
			_today = value;
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
			return _firstDayOfWeek;
		}
		set
		{
			_firstDayOfWeek = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will display todays date.")]
	[DefaultValue(true)]
	public bool CalendarShowToday
	{
		get
		{
			return _showToday;
		}
		set
		{
			_showToday = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates if clicking the Today button closes the drop down menu.")]
	[DefaultValue(false)]
	public bool CalendarCloseOnTodayClick
	{
		get
		{
			return _closeOnTodayClick;
		}
		set
		{
			_closeOnTodayClick = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will circle the today date.")]
	[DefaultValue(true)]
	public bool CalendarShowTodayCircle
	{
		get
		{
			return _showTodayCircle;
		}
		set
		{
			_showTodayCircle = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Indicates whether this month calendar will display week numbers to the left of each row.")]
	[DefaultValue(false)]
	public bool CalendarShowWeekNumbers
	{
		get
		{
			return _showWeekNumbers;
		}
		set
		{
			_showWeekNumbers = value;
		}
	}

	[Category("MonthCalendar")]
	[Description("Today's date.")]
	public DateTime CalendarTodayDate
	{
		get
		{
			return _todayDate;
		}
		set
		{
			bool flag = false;
			_todayDate = value;
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

	[Category("Appearance")]
	[Description("Alignment of the drop-down calendar on the KryptonDateTimePicker control.")]
	[DefaultValue(typeof(LeftRightAlignment), "Left")]
	[Localizable(true)]
	public LeftRightAlignment DropDownAlign
	{
		get
		{
			return _dropDownAlign;
		}
		set
		{
			_dropDownAlign = value;
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
			return _rawDateTime;
		}
		set
		{
			if (value == null || value is DBNull || value is DateTime)
			{
				if (_rawDateTime != value)
				{
					_rawDateTime = value;
					_userSetDateTime = true;
					if (_rawDateTime == null || _rawDateTime is DBNull)
					{
						_rawDateTime = DBNull.Value;
						_drawCheckBox.CheckState = CheckState.Unchecked;
					}
					else
					{
						_drawCheckBox.CheckState = CheckState.Checked;
					}
					if (value is DateTime && _dateTime != (DateTime)value)
					{
						_dateTime = (DateTime)value;
						OnValueChanged(EventArgs.Empty);
					}
					OnValueNullableChanged(EventArgs.Empty);
					PerformNeedPaint(needLayout: true);
				}
				return;
			}
			throw new ArgumentException("Value can only accept 'null', 'DBNull' or 'DateTime' values.");
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
			return _dateTime;
		}
		set
		{
			_drawCheckBox.CheckState = CheckState.Checked;
			_userSetDateTime = true;
			if (_dateTime != value || _rawDateTime == DBNull.Value)
			{
				_dateTime = value;
				_rawDateTime = value;
				OnValueChanged(EventArgs.Empty);
				OnValueNullableChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
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
			return _format;
		}
		set
		{
			if (_format != value)
			{
				_format = value;
				PerformNeedPaint(needLayout: true);
				OnFormatChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[Description("Indicates whether the control layout is right-to-left when the RightToLeft property is True.")]
	[DefaultValue(false)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public bool RightToLeftLayout
	{
		get
		{
			return _drawText.RightToLeftLayout;
		}
		set
		{
			if (_drawText.RightToLeftLayout != value)
			{
				_drawText.RightToLeftLayout = value;
				UpdateForRightToLeft();
				PerformNeedPaint(needLayout: true);
				OnRightToLeftLayoutChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[Description("Determines if keyboard input will automatically shift to the next input field.")]
	[DefaultValue(false)]
	public bool AutoShift
	{
		get
		{
			return _autoShift;
		}
		set
		{
			_autoShift = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates whether a spin box rather than a drop-down calendar is displayed for modifying the control value.")]
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
				_showUpDown = value;
				_upDownFit.Visible = value && _showAdornments;
				_dropStretch.Visible = !value && _showAdornments;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Determines whether a check box is displayed in the control. When the box is unchecked, no value is selected.")]
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
				_showCheckBox = value;
				_layoutCheckBox.Visible = value && _showAdornments;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Defines if mnemonic characters generate click events for button specs.")]
	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return _buttonManager.UseMnemonic;
		}
		set
		{
			if (_buttonManager.UseMnemonic != value)
			{
				_buttonManager.UseMnemonic = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Maximum allowable date.")]
	public DateTime MaxDate
	{
		get
		{
			return EffectiveMaxDate(_maxDateTime);
		}
		set
		{
			if (!(value != _maxDateTime))
			{
				return;
			}
			if (value < EffectiveMinDate(_minDateTime))
			{
				throw new ArgumentOutOfRangeException("Date provided is less than the minimum supported date.");
			}
			if (value > DateTimePicker.MaximumDateTime)
			{
				throw new ArgumentOutOfRangeException("Date provided is greater than the maximum supported date.");
			}
			_maxDateTime = value;
			if (_dateTime > _maxDateTime)
			{
				_dateTime = _maxDateTime;
				OnValueChanged(EventArgs.Empty);
				if (_rawDateTime is DateTime)
				{
					_rawDateTime = _maxDateTime;
					OnValueNullableChanged(EventArgs.Empty);
				}
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Minimum allowable date.")]
	public DateTime MinDate
	{
		get
		{
			return EffectiveMinDate(_minDateTime);
		}
		set
		{
			if (!(value != _minDateTime))
			{
				return;
			}
			if (value > EffectiveMaxDate(_maxDateTime))
			{
				throw new ArgumentOutOfRangeException("Date provided is greater than the maximum supported date.");
			}
			if (value < DateTimePicker.MinimumDateTime)
			{
				throw new ArgumentOutOfRangeException("Date provided is less than the minimum supported date.");
			}
			_minDateTime = value;
			if (_dateTime < _minDateTime)
			{
				_dateTime = _minDateTime;
				OnValueChanged(EventArgs.Empty);
				if (_rawDateTime is DateTime)
				{
					_rawDateTime = _minDateTime;
					OnValueNullableChanged(EventArgs.Empty);
				}
				PerformNeedPaint(needLayout: true);
			}
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
			return _drawCheckBox.CheckState == CheckState.Checked;
		}
		set
		{
			if (Checked != value)
			{
				if (value)
				{
					_drawCheckBox.CheckState = CheckState.Checked;
					_rawDateTime = _dateTime;
				}
				else
				{
					_drawCheckBox.CheckState = CheckState.Unchecked;
					_rawDateTime = DBNull.Value;
				}
				PerformNeedPaint(needLayout: true);
				OnCheckedChanged(EventArgs.Empty);
				OnValueChanged(EventArgs.Empty);
				OnValueNullableChanged(EventArgs.Empty);
			}
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
			return _customFormat;
		}
		set
		{
			if (_customFormat != value && value != null)
			{
				_customFormat = value;
				PerformNeedPaint(needLayout: true);
			}
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
			return _customNullText;
		}
		set
		{
			if (_customNullText != value)
			{
				_customNullText = value;
				PerformNeedPaint(needLayout: true);
			}
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
			return _todayFormat;
		}
		set
		{
			_todayFormat = value;
		}
	}

	[Category("Visuals - MonthCalendar")]
	[Description("Header style for the month calendar.")]
	public HeaderStyle CalendarHeaderStyle
	{
		get
		{
			return _headerStyle;
		}
		set
		{
			_headerStyle = value;
		}
	}

	[Category("Visuals - MonthCalendar")]
	[Description("Content style for the day entries.")]
	public ButtonStyle CalendarDayStyle
	{
		get
		{
			return _dayStyle;
		}
		set
		{
			_dayStyle = value;
		}
	}

	[Category("Visuals - MonthCalendar")]
	[Description("Content style for the day of week labels.")]
	public ButtonStyle CalendarDayOfWeekStyle
	{
		get
		{
			return _dayOfWeekStyle;
		}
		set
		{
			_dayOfWeekStyle = value;
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("Palette applied to drawing.")]
	[DefaultValue(typeof(PaletteMode), "Global")]
	public new PaletteMode PaletteMode
	{
		get
		{
			return base.PaletteMode;
		}
		set
		{
			base.PaletteMode = value;
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("Custom palette applied to drawing.")]
	[DefaultValue(null)]
	public new IPalette Palette
	{
		get
		{
			return base.Palette;
		}
		set
		{
			base.Palette = value;
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("Determines if the control is always active or only when the mouse is over the control or has focus.")]
	[DefaultValue(true)]
	public bool AlwaysActive
	{
		get
		{
			return _alwaysActive;
		}
		set
		{
			if (_alwaysActive != value)
			{
				_alwaysActive = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("CheckBox image overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public CheckBoxImages Images => _checkBoxImages;

	[Category("Visuals - DateTimePicker")]
	[Description("Input control style.")]
	public InputControlStyle InputControlStyle
	{
		get
		{
			return _inputControlStyle;
		}
		set
		{
			if (_inputControlStyle != value)
			{
				_inputControlStyle = value;
				_stateCommon.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("Up and down buttons style.")]
	public ButtonStyle UpDownButtonStyle
	{
		get
		{
			return _upDownButtonStyle;
		}
		set
		{
			if (_upDownButtonStyle != value)
			{
				_upDownButtonStyle = value;
				_paletteUpDown.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("DropButton style.")]
	public ButtonStyle DropButtonStyle
	{
		get
		{
			return _dropButtonStyle;
		}
		set
		{
			if (_dropButtonStyle != value)
			{
				_dropButtonStyle = value;
				_paletteDropDown.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DateTimePickerButtonSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Visuals - DateTimePicker")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _allowButtonSpecToolTips;
		}
		set
		{
			_allowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals - DateTimePicker")]
	[Description("Overrides for defining common date time picker appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleRedirect StateCommon => _stateCommon;

	[Category("Visuals - DateTimePicker")]
	[Description("Overrides for defining disabled date time picker appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates StateDisabled => _stateDisabled;

	[Category("Visuals - DateTimePicker")]
	[Description("Overrides for defining normal date time picker appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates StateNormal => _stateNormal;

	[Category("Visuals - DateTimePicker")]
	[Description("Overrides for defining active date time picker appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates StateActive => _stateActive;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string ActiveFragment
	{
		get
		{
			return _drawText.ActiveFragment;
		}
		set
		{
			if (_drawText.ActiveFragment != value)
			{
				_drawText.ActiveFragment = value;
				if (_drawText.ActiveFragment == value)
				{
					PerformNeedPaint(needLayout: true);
					CheckActiveFragment();
				}
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _toolTipManager;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsActive
	{
		get
		{
			if (_fixedActive.HasValue)
			{
				return _fixedActive.Value;
			}
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsMouseOver => _mouseOver;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsDropped => _dropped;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool InRibbonDesignMode
	{
		get
		{
			return _inRibbonDesignMode;
		}
		set
		{
			_inRibbonDesignMode = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowAdornments
	{
		set
		{
			if (_showAdornments != value)
			{
				_showAdornments = value;
				_layoutCheckBox.Visible = ShowCheckBox && _showAdornments;
				_upDownFit.Visible = ShowUpDown && _showAdornments;
				_dropStretch.Visible = !ShowUpDown && _showAdornments;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowBorder
	{
		set
		{
			_drawDockerOuter.IgnoreAllBorderAndPadding = !value;
		}
	}

	protected override Size DefaultSize => new Size(240, PreferredHeight);

	internal ViewDrawCheckBox InternalViewDrawCheckBox => _drawCheckBox;

	internal bool IsFixedActive => _fixedActive.HasValue;

	private int PreferredHeight => GetPreferredSize(new Size(int.MaxValue, int.MaxValue)).Height;

	[Category("Action")]
	[Description("Event raised when the value of the Value property is changed on KryptonDateTimePicker.")]
	public event EventHandler ValueChanged;

	[Category("Action")]
	[Description("Event raised when the value of the ValueNullable property is changed on KryptonDateTimePicker.")]
	public event EventHandler ValueNullableChanged;

	[Category("Action")]
	[Description("Event raised when the value of the ActiveFragment property is changed on KryptonDateTimePicker.")]
	public event EventHandler ActiveFragmentChanged;

	[Category("Action")]
	[Description("Event raised when the drop down is shown.")]
	public event EventHandler<DateTimePickerDropArgs> DropDown;

	[Category("Action")]
	[Description("Event raised when the drop down has been closed.")]
	public event EventHandler<DateTimePickerCloseArgs> CloseUp;

	[Category("Action")]
	[Description("Event raised to indicate the month calendar date changed whilst dropped down.")]
	public event EventHandler CloseUpMonthCalendarChanged;

	[Category("Action")]
	[Description("Event raised when auto shifting to the next field but overflowing the end.")]
	public event CancelEventHandler AutoShiftOverflow;

	[Category("Property Changed")]
	[Description("Event raised when the value of the Checked property is changed on KryptonDateTimePicker.")]
	public event EventHandler CheckedChanged;

	[Category("Property Changed")]
	[Description("Event raised when the value of the Format property is changed on KryptonDateTimePicker.")]
	public event EventHandler FormatChanged;

	[Category("Property Changed")]
	[Description("Event raised when the value of the RightToLeftLayout property is changed on KryptonDateTimePicker.")]
	public event EventHandler RightToLeftLayoutChanged;

	public KryptonDateTimePicker()
	{
		SetStyle(ControlStyles.FixedHeight, value: true);
		_cachedHeight = -1;
		_alwaysActive = true;
		_showUpDown = false;
		_autoShift = false;
		_showAdornments = true;
		_showCheckBox = false;
		_dropped = false;
		_mouseOver = false;
		_allowButtonSpecToolTips = false;
		_showToday = true;
		_showTodayCircle = true;
		_closeOnTodayClick = false;
		_userSetDateTime = false;
		_customFormat = string.Empty;
		_customNullText = string.Empty;
		_todayFormat = "d";
		_dateTime = DateTime.Now;
		_rawDateTime = _dateTime;
		_todayDate = DateTime.Now.Date;
		_maxDateTime = DateTime.MaxValue;
		_minDateTime = DateTime.MinValue;
		_dropDownAlign = LeftRightAlignment.Left;
		_format = DateTimePickerFormat.Long;
		_inputControlStyle = InputControlStyle.Standalone;
		_upDownButtonStyle = ButtonStyle.InputControl;
		_dropButtonStyle = ButtonStyle.InputControl;
		_headerStyle = HeaderStyle.Calendar;
		_dayStyle = ButtonStyle.CalendarDay;
		_dayOfWeekStyle = ButtonStyle.CalendarDay;
		_dimensions = new Size(1, 1);
		_today = _defaultToday;
		_firstDayOfWeek = Day.Default;
		_annualDates = new DateTimeList();
		_monthlyDates = new DateTimeList();
		_dates = new DateTimeList();
		_buttonSpecs = new DateTimePickerButtonSpecCollection(this);
		_stateCommon = new PaletteInputControlTripleRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, base.NeedPaintDelegate);
		_stateDisabled = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_checkBoxImages = new CheckBoxImages(base.NeedPaintDelegate);
		PaletteRedirectCheckBox palette = new PaletteRedirectCheckBox(base.Redirector, _checkBoxImages);
		_drawCheckBox = new ViewDrawCheckBox(palette);
		_drawCheckBox.CheckState = CheckState.Checked;
		_layoutCheckBox = new ViewLayoutCenter();
		_layoutCheckBox.Add(new ViewLayoutPadding(new Padding(1, 1, 4, 1), _drawCheckBox));
		_layoutCheckBox.Visible = false;
		CheckBoxController checkBoxController = new CheckBoxController(_drawCheckBox, _drawCheckBox, base.NeedPaintDelegate);
		checkBoxController.Click += OnCheckBoxClick;
		checkBoxController.Enabled = true;
		_drawCheckBox.MouseController = checkBoxController;
		_drawCheckBox.KeyController = checkBoxController;
		_drawText = new ViewDrawDateTimeText(this, base.NeedPaintDelegate);
		_drawDockerInner = new ViewLayoutDocker();
		_drawDockerInner.IgnoreRightToLeftLayout = true;
		_drawDockerInner.Add(_layoutCheckBox, ViewDockStyle.Left);
		_drawDockerInner.Add(_drawText, ViewDockStyle.Fill);
		_paletteDropDown = new PaletteTripleToPalette(base.Redirector, PaletteBackStyle.ButtonInputControl, PaletteBorderStyle.ButtonInputControl, PaletteContentStyle.ButtonInputControl);
		_paletteUpDown = new PaletteTripleToPalette(base.Redirector, PaletteBackStyle.ButtonInputControl, PaletteBorderStyle.ButtonInputControl, PaletteContentStyle.ButtonInputControl);
		_buttonDropDown = new ViewDrawDateTimeButton(this, _paletteDropDown, new PaletteMetricRedirect(base.Redirector), this, ViewDrawDateTimeButton.DrawDateTimeGlyph.DropDownButton, base.NeedPaintDelegate, repeat: false);
		_buttonUp = new ViewDrawDateTimeButton(this, _paletteUpDown, new PaletteMetricRedirect(base.Redirector), this, ViewDrawDateTimeButton.DrawDateTimeGlyph.UpButton, base.NeedPaintDelegate, repeat: true);
		_buttonDown = new ViewDrawDateTimeButton(this, _paletteUpDown, new PaletteMetricRedirect(base.Redirector), this, ViewDrawDateTimeButton.DrawDateTimeGlyph.DownButton, base.NeedPaintDelegate, repeat: true);
		_buttonDropDown.Click += OnDropDownClick;
		_buttonUp.Click += OnUpClick;
		_buttonDown.Click += OnDownClick;
		_dropStretch = new ViewLayoutStretch(Orientation.Vertical);
		_dropStretch.Add(_buttonDropDown);
		_drawDockerInner.Add(_dropStretch, ViewDockStyle.Right);
		_upDownFit = new ViewLayoutFit(Orientation.Vertical);
		_upDownFit.Add(_buttonUp);
		_upDownFit.Add(_buttonDown);
		_upDownFit.Visible = false;
		_drawDockerInner.Add(_upDownFit, ViewDockStyle.Right);
		_drawDockerOuter = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border);
		_drawDockerOuter.Add(new ViewLayoutPadding(new Padding(2, 0, 1, 0), _drawDockerInner), ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDockerOuter);
		_buttonManager = new ButtonSpecManagerDraw(this, base.Redirector, _buttonSpecs, null, new ViewDrawDocker[1] { _drawDockerOuter }, new IPaletteMetric[1] { _stateCommon }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetPrimary }, new PaletteMetricPadding[1] { PaletteMetricPadding.HeaderButtonPaddingPrimary }, base.CreateToolStripRenderer, base.NeedPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
		UpdateForRightToLeft();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			OnCancelToolTip(this, EventArgs.Empty);
			_buttonManager.Destruct();
		}
		base.Dispose(disposing);
	}

	public void ResetCalendarTodayText()
	{
		CalendarTodayText = _defaultToday;
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

	public bool ShouldSerializeValueNullable()
	{
		return _userSetDateTime;
	}

	public void ResetValueNullable()
	{
		_drawCheckBox.CheckState = CheckState.Checked;
		_userSetDateTime = false;
		_dateTime = DateTime.Now;
		_rawDateTime = _dateTime;
		OnValueChanged(EventArgs.Empty);
		OnValueNullableChanged(EventArgs.Empty);
		PerformNeedPaint(needLayout: true);
	}

	public bool ShouldSerializeValue()
	{
		return false;
	}

	public void ResetValue()
	{
		_drawCheckBox.CheckState = CheckState.Checked;
		_userSetDateTime = false;
		_dateTime = DateTime.Now;
		_rawDateTime = _dateTime;
		OnValueChanged(EventArgs.Empty);
		OnValueNullableChanged(EventArgs.Empty);
		PerformNeedPaint(needLayout: true);
	}

	public bool ShouldSerializeMaxDate()
	{
		return _maxDateTime != DateTimePicker.MaximumDateTime && _maxDateTime != DateTime.MaxValue;
	}

	private void ResetMaxDate()
	{
		MaxDate = DateTime.MaxValue;
	}

	public bool ShouldSerializeMinDate()
	{
		return _minDateTime != DateTimePicker.MinimumDateTime && _minDateTime != DateTime.MinValue;
	}

	private void ResetMinDate()
	{
		MinDate = DateTime.MinValue;
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

	private bool ShouldSerializeImages()
	{
		return !_checkBoxImages.IsDefault;
	}

	private void ResetInputControlStyle()
	{
		InputControlStyle = InputControlStyle.Standalone;
	}

	private bool ShouldSerializeInputControlStyle()
	{
		return InputControlStyle != InputControlStyle.Standalone;
	}

	private void ResetUpDownButtonStyle()
	{
		UpDownButtonStyle = ButtonStyle.InputControl;
	}

	private bool ShouldSerializeUpDownButtonStyle()
	{
		return UpDownButtonStyle != ButtonStyle.InputControl;
	}

	private void ResetDropButtonStyle()
	{
		DropButtonStyle = ButtonStyle.InputControl;
	}

	private bool ShouldSerializeDropButtonStyle()
	{
		return DropButtonStyle != ButtonStyle.InputControl;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateActive()
	{
		return !_stateActive.IsDefault;
	}

	public void SelectFirstFragment()
	{
		_drawText.MoveFirstFragment();
		PerformNeedPaint(needLayout: true);
		CheckActiveFragment();
	}

	public void SelectNextFragment()
	{
		_drawText.MoveNextFragment();
		PerformNeedPaint(needLayout: true);
		CheckActiveFragment();
	}

	public void SelectPreviousFragment()
	{
		_drawText.MovePreviousFragment();
		PerformNeedPaint(needLayout: true);
		CheckActiveFragment();
	}

	public void SelectLastFragment()
	{
		_drawText.MoveLastFragment();
		PerformNeedPaint(needLayout: true);
		CheckActiveFragment();
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	public override Size GetPreferredSize(Size proposedSize)
	{
		if (base.ViewManager != null)
		{
			Size preferredSize = base.ViewManager.GetPreferredSize(base.Renderer, proposedSize);
			if (MaximumSize.Width > 0)
			{
				preferredSize.Width = Math.Min(MaximumSize.Width, preferredSize.Width);
			}
			if (MaximumSize.Height > 0)
			{
				preferredSize.Height = Math.Min(MaximumSize.Height, preferredSize.Width);
			}
			if (MinimumSize.Width > 0)
			{
				preferredSize.Width = Math.Max(MinimumSize.Width, preferredSize.Width);
			}
			if (MinimumSize.Height > 0)
			{
				preferredSize.Height = Math.Max(MinimumSize.Height, preferredSize.Height);
			}
			return preferredSize;
		}
		return base.GetPreferredSize(proposedSize);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool DesignerGetHitTest(Point pt)
	{
		if (base.IsDisposed)
		{
			return false;
		}
		if (_buttonManager != null && _buttonManager.DesignerGetHitTest(pt))
		{
			return true;
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Component DesignerComponentFromPoint(Point pt)
	{
		if (base.IsDisposed)
		{
			return null;
		}
		return base.ViewManager.ComponentFromPoint(pt);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void DesignerMouseLeave()
	{
		OnMouseLeave(EventArgs.Empty);
	}

	protected virtual void OnRightToLeftLayoutChanged(EventArgs e)
	{
		if (this.RightToLeftLayoutChanged != null)
		{
			this.RightToLeftLayoutChanged(this, e);
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

	protected virtual void OnDropDown(DateTimePickerDropArgs e)
	{
		if (this.DropDown != null)
		{
			this.DropDown(this, e);
		}
	}

	protected virtual void OnCloseUp(DateTimePickerCloseArgs e)
	{
		if (this.CloseUp != null)
		{
			this.CloseUp(this, e);
		}
	}

	protected virtual void OnCloseUpMonthCalendarChanged(EventArgs e)
	{
		if (this.CloseUpMonthCalendarChanged != null)
		{
			this.CloseUpMonthCalendarChanged(this, e);
		}
	}

	protected internal virtual void OnAutoShiftOverflow(CancelEventArgs e)
	{
		if (this.AutoShiftOverflow != null)
		{
			this.AutoShiftOverflow(this, e);
		}
	}

	protected virtual void OnValueChanged(EventArgs e)
	{
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, e);
		}
	}

	protected virtual void OnValueNullableChanged(EventArgs e)
	{
		if (this.ValueNullableChanged != null)
		{
			this.ValueNullableChanged(this, e);
		}
	}

	protected virtual void OnActiveFragmentChanged(EventArgs e)
	{
		if (this.ActiveFragmentChanged != null)
		{
			this.ActiveFragmentChanged(this, e);
		}
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 132 && _inRibbonDesignMode)
		{
			m.Result = (IntPtr)(-1);
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	protected override bool IsInputChar(char charCode)
	{
		return char.IsLetterOrDigit(charCode);
	}

	protected override bool IsInputKey(Keys keyData)
	{
		Keys keys = keyData & ~Keys.Shift;
		Keys keys2 = keys;
		if ((uint)(keys2 - 37) <= 3u)
		{
			return true;
		}
		return base.IsInputKey(keyData);
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (UseMnemonic && CanProcessMnemonic() && _buttonManager.ProcessMnemonic(charCode))
		{
			return true;
		}
		return base.ProcessMnemonic(charCode);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !_inRibbonDesignMode)
		{
			if (e.KeyCode == Keys.Space)
			{
				if (_drawCheckBox.ForcedTracking)
				{
					Checked = !Checked;
				}
			}
			else
			{
				_drawText.PerformKeyDown(e);
				CheckActiveFragment();
			}
		}
		base.OnKeyDown(e);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !_inRibbonDesignMode)
		{
			_drawText.PerformKeyPress(e);
			CheckActiveFragment();
		}
		base.OnKeyPress(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !_inRibbonDesignMode)
		{
			KeyEventArgs e2 = new KeyEventArgs((e.Delta < 0) ? Keys.Down : Keys.Up);
			int num = Math.Abs(e.Delta) / SystemInformation.MouseWheelScrollDelta;
			for (int i = 0; i < num; i++)
			{
				_drawText.PerformKeyDown(e2);
			}
			CheckActiveFragment();
		}
		base.OnMouseWheel(e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		UpdateStateAndPalettes();
		_drawText.Enabled = base.Enabled;
		_drawCheckBox.Enabled = base.Enabled;
		_buttonDropDown.Enabled = base.Enabled;
		_buttonDown.Enabled = base.Enabled;
		_buttonUp.Enabled = base.Enabled;
		_drawDockerInner.Enabled = base.Enabled;
		_drawDockerOuter.Enabled = base.Enabled;
		_buttonManager.RefreshButtons();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		bool flag = _drawText.RightToLeftLayout && RightToLeft == RightToLeft.Yes;
		if ((!ShowUpDown && !flag && e.X < _buttonDropDown.ClientLocation.X) || (!ShowUpDown && flag && e.X > _buttonDropDown.ClientRectangle.Right) || (ShowUpDown && !flag && e.X < _buttonUp.ClientLocation.X) || (ShowUpDown && flag && e.X < _buttonUp.ClientRectangle.Right))
		{
			if (!ShowCheckBox || (ShowCheckBox && !flag && Checked && e.X > _drawCheckBox.ClientRectangle.Right) || (ShowCheckBox && flag && Checked && e.X < _drawCheckBox.ClientRectangle.Left))
			{
				_drawCheckBox.ForcedTracking = false;
				_drawText.SelectFragment(new Point(e.X, e.Y), e.Button);
				CheckActiveFragment();
			}
			else
			{
				_drawCheckBox.ForcedTracking = true;
				_drawText.ClearActiveFragment();
				CheckActiveFragment();
			}
			PerformNeedPaint(needLayout: true);
		}
		if (!base.ContainsFocus)
		{
			Focus();
		}
		base.OnMouseDown(e);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		PerformNeedPaint(needLayout: false);
		InvokeLayout();
		base.Height = PreferredHeight;
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed)
		{
			base.Height = PreferredHeight;
			base.OnLayout(levent);
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		_mouseOver = true;
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		_mouseOver = false;
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		_drawText.HasFocus = true;
		if (!_drawText.HasActiveFragment)
		{
			if (ShowCheckBox)
			{
				_drawCheckBox.ForcedTracking = true;
			}
			else
			{
				_drawText.MoveFirstFragment();
				CheckActiveFragment();
			}
		}
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		_drawCheckBox.ForcedTracking = false;
		_drawText.HasFocus = false;
		_drawText.ClearActiveFragment();
		CheckActiveFragment();
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
		{
			if (_cachedHeight == -1)
			{
				_cachedHeight = height;
			}
			height = PreferredHeight;
		}
		if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
		{
			_cachedHeight = height;
		}
		base.SetBoundsCore(x, y, width, height, specified);
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		UpdateForRightToLeft();
		base.OnRightToLeftChanged(e);
	}

	protected override void OnButtonSpecChanged(object sender, EventArgs e)
	{
		_buttonManager.RecreateButtons();
		base.OnButtonSpecChanged(sender, e);
	}

	internal DateTime InternalDateTime()
	{
		return _dateTime;
	}

	internal bool InternalDateTimeNull()
	{
		return _rawDateTime == DBNull.Value;
	}

	internal DateTime EffectiveMaxDate(DateTime maxDate)
	{
		DateTime maximumDateTime = DateTimePicker.MaximumDateTime;
		if (maxDate > maximumDateTime)
		{
			return maximumDateTime;
		}
		return maxDate;
	}

	internal DateTime EffectiveMinDate(DateTime minDate)
	{
		DateTime minimumDateTime = DateTimePicker.MinimumDateTime;
		if (minDate < minimumDateTime)
		{
			return minimumDateTime;
		}
		return minDate;
	}

	private void UpdateStateAndPalettes()
	{
		IPaletteTriple tripleState = GetTripleState();
		_drawDockerOuter.SetPalettes(tripleState.PaletteBack, tripleState.PaletteBorder);
		_drawDockerOuter.Enabled = base.Enabled;
		PaletteState elementState = ((!IsActive) ? PaletteState.Normal : PaletteState.Tracking);
		_drawDockerOuter.ElementState = elementState;
	}

	private IPaletteTriple GetTripleState()
	{
		if (base.Enabled)
		{
			if (IsActive)
			{
				return _stateActive;
			}
			return _stateNormal;
		}
		return _stateDisabled;
	}

	private void CheckActiveFragment()
	{
		if (_lastActiveFragment != ActiveFragment)
		{
			_lastActiveFragment = ActiveFragment;
			OnActiveFragmentChanged(EventArgs.Empty);
		}
	}

	private void UpdateForRightToLeft()
	{
		if (_drawText.RightToLeftLayout && RightToLeft == RightToLeft.Yes)
		{
			_drawDockerInner.SetDock(_dropStretch, ViewDockStyle.Left);
			_drawDockerInner.SetDock(_upDownFit, ViewDockStyle.Left);
			_drawDockerInner.SetDock(_layoutCheckBox, ViewDockStyle.Right);
		}
		else
		{
			_drawDockerInner.SetDock(_dropStretch, ViewDockStyle.Right);
			_drawDockerInner.SetDock(_upDownFit, ViewDockStyle.Right);
			_drawDockerInner.SetDock(_layoutCheckBox, ViewDockStyle.Left);
		}
	}

	private void OnShowToolTip(object sender, ToolTipEventArgs e)
	{
		if (base.IsDisposed)
		{
			return;
		}
		Form form = FindForm();
		if ((form != null && !form.ContainsFocus) || base.DesignMode)
		{
			return;
		}
		IContentValues contentValues = null;
		LabelStyle style = LabelStyle.ToolTip;
		ButtonSpec buttonSpec = _buttonManager.ButtonSpecFromView(e.Target);
		if (buttonSpec != null && AllowButtonSpecToolTips)
		{
			ButtonSpecToContent buttonSpecToContent = new ButtonSpecToContent(base.Redirector, buttonSpec);
			if (buttonSpecToContent.HasContent)
			{
				contentValues = buttonSpecToContent;
				style = buttonSpec.ToolTipStyle;
			}
		}
		if (contentValues != null)
		{
			if (_visualPopupToolTip != null)
			{
				_visualPopupToolTip.Dispose();
			}
			_visualPopupToolTip = new VisualPopupToolTip(base.Redirector, contentValues, base.Renderer, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, CommonHelper.ContentStyleFromLabelStyle(style));
			_visualPopupToolTip.Disposed += OnVisualPopupToolTipDisposed;
			_visualPopupToolTip.ShowCalculatingSize(RectangleToScreen(e.Target.ClientRectangle));
		}
	}

	private void OnCheckBoxClick(object sender, EventArgs e)
	{
		Checked = !Checked;
	}

	private void OnDropDownClick(object sender, EventArgs e)
	{
		if (!_inRibbonDesignMode)
		{
			_drawText.EndInputDigits();
			_dropDownMonthChanged = false;
			DTPContextMenu dTPContextMenu = new DTPContextMenu(RectangleToScreen(_buttonDropDown.ClientRectangle));
			_kmc = new KryptonContextMenuMonthCalendar();
			_kmc.CalendarDimensions = CalendarDimensions;
			_kmc.TodayText = CalendarTodayText;
			_kmc.TodayFormat = CalendarTodayFormat;
			_kmc.FirstDayOfWeek = CalendarFirstDayOfWeek;
			_kmc.MaxDate = MaxDate.Date;
			_kmc.MaxSelectionCount = 1;
			_kmc.MinDate = MinDate.Date;
			_kmc.SelectionStart = Value.Date;
			_kmc.ShowToday = CalendarShowToday;
			_kmc.ShowTodayCircle = CalendarShowTodayCircle;
			_kmc.ShowWeekNumbers = CalendarShowWeekNumbers;
			_kmc.CloseOnTodayClick = CalendarCloseOnTodayClick;
			_kmc.TodayDate = CalendarTodayDate;
			_kmc.AnnuallyBoldedDates = CalendarAnnuallyBoldedDates;
			_kmc.MonthlyBoldedDates = CalendarMonthlyBoldedDates;
			_kmc.BoldedDates = CalendarBoldedDates;
			_kmc.DayOfWeekStyle = CalendarDayOfWeekStyle;
			_kmc.DayStyle = CalendarDayStyle;
			_kmc.HeaderStyle = CalendarHeaderStyle;
			_kmc.DateChanged += OnMonthCalendarDateChanged;
			dTPContextMenu.Items.Add(_kmc);
			if (PaletteMode != PaletteMode.Custom)
			{
				dTPContextMenu.PaletteMode = PaletteMode;
			}
			else
			{
				dTPContextMenu.Palette = Palette;
			}
			DateTimePickerDropArgs dateTimePickerDropArgs = new DateTimePickerDropArgs(dTPContextMenu, (DropDownAlign == LeftRightAlignment.Left) ? KryptonContextMenuPositionH.Left : KryptonContextMenuPositionH.Right, KryptonContextMenuPositionV.Below);
			OnDropDown(dateTimePickerDropArgs);
			if (!dateTimePickerDropArgs.Cancel && dateTimePickerDropArgs.KryptonContextMenu != null)
			{
				Checked = true;
				Rectangle screenRect = RectangleToScreen(base.ClientRectangle);
				if (CommonHelper.ValidKryptonContextMenu(dateTimePickerDropArgs.KryptonContextMenu))
				{
					switch (dateTimePickerDropArgs.PositionV)
					{
					case KryptonContextMenuPositionV.Above:
						screenRect.Y--;
						break;
					case KryptonContextMenuPositionV.Below:
						screenRect.Height++;
						break;
					}
					switch (dateTimePickerDropArgs.PositionH)
					{
					case KryptonContextMenuPositionH.Before:
						screenRect.X--;
						break;
					case KryptonContextMenuPositionH.After:
						screenRect.Width++;
						break;
					}
					dateTimePickerDropArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
					dateTimePickerDropArgs.KryptonContextMenu.Show(this, screenRect, dateTimePickerDropArgs.PositionH, dateTimePickerDropArgs.PositionV);
					return;
				}
			}
			dTPContextMenu.Dispose();
		}
		_buttonDropDown.RemoveFixed();
	}

	private void OnMonthCalendarDateChanged(object sender, DateRangeEventArgs e)
	{
		DateTime dateTime = new DateTime(e.Start.Year, e.Start.Month, e.Start.Day, _dateTime.Hour, _dateTime.Minute, _dateTime.Second, _dateTime.Millisecond);
		if (dateTime > MaxDate)
		{
			dateTime = MaxDate;
		}
		if (dateTime < MinDate)
		{
			dateTime = MinDate;
		}
		Value = dateTime;
		_dropDownMonthChanged = true;
	}

	private void OnKryptonContextMenuClosed(object sender, EventArgs e)
	{
		KryptonContextMenu kryptonContextMenu = (KryptonContextMenu)sender;
		kryptonContextMenu.Closed -= OnKryptonContextMenuClosed;
		if (_kmc != null)
		{
			_kmc.DateChanged -= OnMonthCalendarDateChanged;
			_kmc = null;
		}
		DateTimePickerCloseArgs e2 = new DateTimePickerCloseArgs(kryptonContextMenu);
		OnCloseUp(e2);
		if (_dropDownMonthChanged)
		{
			OnCloseUpMonthCalendarChanged(EventArgs.Empty);
		}
		_buttonDropDown.RemoveFixed();
		kryptonContextMenu.Dispose();
	}

	private void OnUpClick(object sender, EventArgs e)
	{
		if (!_inRibbonDesignMode)
		{
			_drawText.PerformKeyDown(new KeyEventArgs(Keys.Up));
			CheckActiveFragment();
		}
		_buttonUp.RemoveFixed();
	}

	private void OnDownClick(object sender, EventArgs e)
	{
		if (!_inRibbonDesignMode)
		{
			_drawText.PerformKeyDown(new KeyEventArgs(Keys.Down));
			CheckActiveFragment();
		}
		_buttonDown.RemoveFixed();
	}

	private void OnCancelToolTip(object sender, EventArgs e)
	{
		if (_visualPopupToolTip != null)
		{
			_visualPopupToolTip.Dispose();
		}
	}

	private void OnVisualPopupToolTipDisposed(object sender, EventArgs e)
	{
		VisualPopupToolTip visualPopupToolTip = (VisualPopupToolTip)sender;
		visualPopupToolTip.Disposed -= OnVisualPopupToolTipDisposed;
		_visualPopupToolTip = null;
	}
}
