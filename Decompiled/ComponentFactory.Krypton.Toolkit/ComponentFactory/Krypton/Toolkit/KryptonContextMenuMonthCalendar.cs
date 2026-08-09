using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuMonthCalendar), "ToolboxBitmaps.KryptonMonthCalendar.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("DateChanged")]
[DefaultProperty("SelectionRange")]
public class KryptonContextMenuMonthCalendar : KryptonContextMenuItemBase
{
	private static readonly string _defaultToday = "Today:";

	private PaletteMonthCalendarRedirect _stateCommon;

	private PaletteMonthCalendarStateRedirect _stateFocus;

	private PaletteMonthCalendarStateRedirect _stateBolded;

	private PaletteMonthCalendarStateRedirect _stateToday;

	private PaletteMonthCalendarDoubleState _stateDisabled;

	private PaletteMonthCalendarDoubleState _stateNormal;

	private PaletteMonthCalendarState _stateTracking;

	private PaletteMonthCalendarState _statePressed;

	private PaletteMonthCalendarState _stateCheckedNormal;

	private PaletteMonthCalendarState _stateCheckedTracking;

	private PaletteMonthCalendarState _stateCheckedPressed;

	private PaletteTripleOverride _boldedDisabled;

	private PaletteTripleOverride _boldedNormal;

	private PaletteTripleOverride _boldedTracking;

	private PaletteTripleOverride _boldedPressed;

	private PaletteTripleOverride _boldedCheckedNormal;

	private PaletteTripleOverride _boldedCheckedTracking;

	private PaletteTripleOverride _boldedCheckedPressed;

	private PaletteTripleOverride _todayDisabled;

	private PaletteTripleOverride _todayNormal;

	private PaletteTripleOverride _todayTracking;

	private PaletteTripleOverride _todayPressed;

	private PaletteTripleOverride _todayCheckedNormal;

	private PaletteTripleOverride _todayCheckedTracking;

	private PaletteTripleOverride _todayCheckedPressed;

	private PaletteTripleOverride _overrideDisabled;

	private PaletteTripleOverride _overrideNormal;

	private PaletteTripleOverride _overrideTracking;

	private PaletteTripleOverride _overridePressed;

	private PaletteTripleOverride _overrideCheckedNormal;

	private PaletteTripleOverride _overrideCheckedTracking;

	private PaletteTripleOverride _overrideCheckedPressed;

	private HeaderStyle _headerStyle;

	private ButtonStyle _dayStyle;

	private ButtonStyle _dayOfWeekStyle;

	private Day _firstDayOfWeek;

	private Size _dimensions;

	private string _todayFormat;

	private bool _autoClose;

	private bool _enabled;

	private bool _hasFocus;

	private bool _showWeekNumbers;

	private bool _showTodayCircle;

	private bool _showToday;

	private bool _closeOnTodayClick;

	private DateTime _selectionStart;

	private DateTime _selectionEnd;

	private DateTime _minDate;

	private DateTime _maxDate;

	private DateTime _todayDate;

	private DateTime? _focusDay;

	private int _maxSelectionCount;

	private DateTimeList _annualDates;

	private DateTimeList _monthlyDates;

	private DateTimeList _dates;

	private int _monthlyDays;

	private int[] _annualDays;

	private string _today;

	private int _scrollChange;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if selecting a day closes the context menu.")]
	[DefaultValue(true)]
	public bool AutoClose
	{
		get
		{
			return _autoClose;
		}
		set
		{
			if (_autoClose != value)
			{
				_autoClose = value;
				OnPropertyChanged(new PropertyChangedEventArgs("AutoClose"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if clicking the Today button closes the drop down menu.")]
	[DefaultValue(false)]
	public bool CloseOnTodayClick
	{
		get
		{
			return _closeOnTodayClick;
		}
		set
		{
			if (_closeOnTodayClick != value)
			{
				_closeOnTodayClick = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CloseOnTodayClick"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether the month calendar is enabled.")]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (_enabled != value)
			{
				_enabled = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Enabled"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Number of months to scroll when next/prev buttons are used.")]
	[DefaultValue(0)]
	public int ScrollChange
	{
		get
		{
			return _scrollChange;
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			_scrollChange = value;
			OnPropertyChanged(new PropertyChangedEventArgs("ScrollChange"));
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Today's date.")]
	public DateTime TodayDate
	{
		get
		{
			return _todayDate;
		}
		set
		{
			bool flag = false;
			_todayDate = value;
			OnPropertyChanged(new PropertyChangedEventArgs("TodayDate"));
		}
	}

	[KryptonPersist]
	[Localizable(true)]
	[Description("Indicates which annual dates should be boldface.")]
	public DateTime[] AnnuallyBoldedDates
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
			for (int i = 0; i < 12; i++)
			{
				_annualDays[i] = 0;
			}
			DateTime[] array = value;
			for (int j = 0; j < array.Length; j++)
			{
				DateTime dateTime = array[j];
				_annualDays[dateTime.Month - 1] |= 1 << dateTime.Day - 1;
			}
			OnPropertyChanged(new PropertyChangedEventArgs("AnnuallyBoldedDates"));
		}
	}

	[KryptonPersist]
	[Localizable(true)]
	[Description("Indicates which monthly dates should be boldface.")]
	public DateTime[] MonthlyBoldedDates
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
			_monthlyDays = 0;
			DateTime[] array = value;
			foreach (DateTime dateTime in array)
			{
				_monthlyDays |= 1 << dateTime.Day - 1;
			}
			OnPropertyChanged(new PropertyChangedEventArgs("MonthlyBoldedDates"));
		}
	}

	[KryptonPersist]
	[Localizable(true)]
	[Description("Indicates which dates should be boldface.")]
	public DateTime[] BoldedDates
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
			OnPropertyChanged(new PropertyChangedEventArgs("BoldedDates"));
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Minimum allowable date.")]
	[RefreshProperties(RefreshProperties.All)]
	public DateTime MinDate
	{
		get
		{
			return _minDate;
		}
		set
		{
			if (value != _minDate)
			{
				if (value > DateTimePicker.MaximumDateTime)
				{
					throw new ArgumentOutOfRangeException("Date provided is greater than the maximum culture supported date.");
				}
				if (value < DateTimePicker.MinimumDateTime)
				{
					throw new ArgumentOutOfRangeException("Date provided is less than the minimum culture supported date.");
				}
			}
			_minDate = value;
			SetRange();
			OnPropertyChanged(new PropertyChangedEventArgs("MinDate"));
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Maximum allowable date.")]
	[RefreshProperties(RefreshProperties.All)]
	public DateTime MaxDate
	{
		get
		{
			return _maxDate;
		}
		set
		{
			if (value != _maxDate)
			{
				if (value > DateTimePicker.MaximumDateTime)
				{
					throw new ArgumentOutOfRangeException("Date provided is greater than the maximum culture supported date.");
				}
				if (value < DateTimePicker.MinimumDateTime)
				{
					throw new ArgumentOutOfRangeException("Date provided is less than the minimum culture supported date.");
				}
			}
			_maxDate = value;
			SetRange();
			OnPropertyChanged(new PropertyChangedEventArgs("MaxDate"));
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Maximum number of days that can be selected.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(7)]
	public int MaxSelectionCount
	{
		get
		{
			return _maxSelectionCount;
		}
		set
		{
			if (value < 1)
			{
				throw new ArgumentOutOfRangeException("MaxSelectionCount cannot be less than zero.");
			}
			if (value != _maxSelectionCount)
			{
				_maxSelectionCount = value;
				SetSelectionRange(_selectionStart, _selectionEnd);
				OnPropertyChanged(new PropertyChangedEventArgs("MaxSelectionCount"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Start date of the selected range of dates.")]
	[RefreshProperties(RefreshProperties.All)]
	[Browsable(true)]
	public DateTime SelectionStart
	{
		get
		{
			return _selectionStart;
		}
		set
		{
			if (value != _selectionStart)
			{
				if (value > _maxDate)
				{
					throw new ArgumentOutOfRangeException("Date provided is greater than the maximum date.");
				}
				if (value < _minDate)
				{
					throw new ArgumentOutOfRangeException("Date provided is less than the minimum date.");
				}
				if (_selectionEnd < value)
				{
					_selectionEnd = value;
				}
				if ((_selectionEnd - value).Days >= _maxSelectionCount)
				{
					_selectionEnd = value.AddDays(_maxSelectionCount - 1);
				}
				SetSelRange(value, _selectionEnd);
				OnPropertyChanged(new PropertyChangedEventArgs("SelectionStart"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("End date of the selected range of dates.")]
	[RefreshProperties(RefreshProperties.All)]
	[Bindable(true)]
	public DateTime SelectionEnd
	{
		get
		{
			return _selectionEnd;
		}
		set
		{
			if (value != _selectionEnd)
			{
				if (value > _maxDate)
				{
					throw new ArgumentOutOfRangeException("Date provided is greater than the maximum date.");
				}
				if (value < _minDate)
				{
					throw new ArgumentOutOfRangeException("Date provided is less than the minimum date.");
				}
				if (_selectionStart > value)
				{
					_selectionStart = value;
				}
				if ((value - _selectionStart).Days >= _maxSelectionCount)
				{
					_selectionStart = value.AddDays(1 - _maxSelectionCount);
				}
				SetSelRange(_selectionStart, value);
				OnPropertyChanged(new PropertyChangedEventArgs("SelectionEnd"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Specifies the selected range of dates.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[RefreshProperties(RefreshProperties.All)]
	[Bindable(true)]
	public SelectionRange SelectionRange
	{
		get
		{
			return new SelectionRange(SelectionStart, SelectionEnd);
		}
		set
		{
			SetSelectionRange(value.Start, value.End);
		}
	}

	[Category("Behavior")]
	[Description("The today format string used to format the date displayed in the today button.")]
	[DefaultValue("d")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Localizable(true)]
	public string TodayFormat
	{
		get
		{
			return _todayFormat;
		}
		set
		{
			if (_todayFormat != value && value != null)
			{
				_todayFormat = value;
				OnPropertyChanged(new PropertyChangedEventArgs("TodayFormat"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Text used as label for todays date.")]
	[DefaultValue("Today:")]
	[Localizable(true)]
	public string TodayText
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
			OnPropertyChanged(new PropertyChangedEventArgs("TodayText"));
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
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
			if (!_dimensions.Equals(value))
			{
				if (value.Width < 1)
				{
					throw new ArgumentOutOfRangeException("CalendarDimension Width must be greater than 0");
				}
				if (value.Height < 1)
				{
					throw new ArgumentOutOfRangeException("CalendarDimension Height must be greater than 0");
				}
				_dimensions = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CalendarDimensions"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("First day of the week.")]
	[Localizable(true)]
	public Day FirstDayOfWeek
	{
		get
		{
			return _firstDayOfWeek;
		}
		set
		{
			if (_firstDayOfWeek != value)
			{
				_firstDayOfWeek = value;
				OnPropertyChanged(new PropertyChangedEventArgs("FirstDayOfWeek"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether this month calendar will display todays date.")]
	[DefaultValue(true)]
	public bool ShowToday
	{
		get
		{
			return _showToday;
		}
		set
		{
			if (_showToday != value)
			{
				_showToday = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ShowToday"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether this month calendar will circle the today date.")]
	[DefaultValue(true)]
	public bool ShowTodayCircle
	{
		get
		{
			return _showTodayCircle;
		}
		set
		{
			if (_showTodayCircle != value)
			{
				_showTodayCircle = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ShowTodayCircle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether this month calendar will display week numbers to the left of each row.")]
	[DefaultValue(false)]
	public bool ShowWeekNumbers
	{
		get
		{
			return _showWeekNumbers;
		}
		set
		{
			if (_showWeekNumbers != value)
			{
				_showWeekNumbers = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ShowWeekNumbers"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Header style for the month calendar.")]
	[DefaultValue(typeof(HeaderStyle), "Calendar")]
	public HeaderStyle HeaderStyle
	{
		get
		{
			return _headerStyle;
		}
		set
		{
			if (_headerStyle != value)
			{
				_headerStyle = value;
				_stateCommon.Header.SetStyles(_headerStyle);
				OnPropertyChanged(new PropertyChangedEventArgs("HeaderStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Content style for the day entries.")]
	[DefaultValue(typeof(ButtonStyle), "Calendar Day")]
	public ButtonStyle DayStyle
	{
		get
		{
			return _dayStyle;
		}
		set
		{
			if (_dayStyle != value)
			{
				_dayStyle = value;
				_stateCommon.DayStyle = value;
				_stateFocus.DayStyle = value;
				_stateBolded.DayStyle = value;
				_stateToday.DayStyle = value;
				OnPropertyChanged(new PropertyChangedEventArgs("DayStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Content style for the day of week labels.")]
	[DefaultValue(typeof(ButtonStyle), "CalendarDay")]
	public ButtonStyle DayOfWeekStyle
	{
		get
		{
			return _dayOfWeekStyle;
		}
		set
		{
			if (_dayOfWeekStyle != value)
			{
				_dayOfWeekStyle = value;
				_stateCommon.DayOfWeekStyle = value;
				OnPropertyChanged(new PropertyChangedEventArgs("DayOfWeekStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining month calendar appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarStateRedirect OverrideFocus => _stateFocus;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining month calendar appearance when it is bolded.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarStateRedirect OverrideBolded => _stateBolded;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining month calendar appearance when it is today.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarStateRedirect OverrideToday => _stateToday;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common month calendar appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining month calendar disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarDoubleState StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining month calendar normal appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarDoubleState StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StatePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked normal month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateCheckedNormal => _stateCheckedNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked tracking month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateCheckedTracking => _stateCheckedTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked pressed month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateCheckedPressed => _stateCheckedPressed;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteTripleOverride OverrideDisabled => _overrideDisabled;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteTripleOverride OverrideNormal => _overrideNormal;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteTripleOverride OverrideTracking => _overrideTracking;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteTripleOverride OverridePressed => _overridePressed;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteTripleOverride OverrideCheckedNormal => _overrideCheckedNormal;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteTripleOverride OverrideCheckedTracking => _overrideCheckedTracking;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PaletteTripleOverride OverrideCheckedPressed => _overrideCheckedPressed;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public DateTimeList BoldedDatesList => _dates;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int MonthlyBoldedDatesMask => _monthlyDays;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int[] AnnuallyBoldedDatesMask => _annualDays;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool HasFocus
	{
		get
		{
			return _hasFocus;
		}
		set
		{
			_hasFocus = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DateTime? FocusDay
	{
		get
		{
			return _focusDay;
		}
		set
		{
			_focusDay = value;
		}
	}

	[Category("Action")]
	[Description("Occurs when the selected date changes.")]
	public event DateRangeEventHandler DateChanged;

	[Category("Property Changed")]
	[Description("Occurs when the selected start date changes.")]
	public event EventHandler SelectionStartChanged;

	[Category("Property Changed")]
	[Description("Occurs when the selected end date changes.")]
	public event EventHandler SelectionEndChanged;

	public KryptonContextMenuMonthCalendar()
	{
		_autoClose = true;
		_enabled = true;
		_showToday = true;
		_showTodayCircle = true;
		_closeOnTodayClick = false;
		_dimensions = new Size(1, 1);
		_firstDayOfWeek = Day.Default;
		_headerStyle = HeaderStyle.Calendar;
		_dayStyle = ButtonStyle.CalendarDay;
		_dayOfWeekStyle = ButtonStyle.CalendarDay;
		_selectionStart = DateTime.Now.Date;
		_selectionEnd = _selectionStart;
		_todayDate = _selectionStart;
		_minDate = DateTimePicker.MinimumDateTime;
		_maxDate = DateTimePicker.MaximumDateTime;
		_maxSelectionCount = 7;
		_annualDays = new int[12];
		_annualDates = new DateTimeList();
		_monthlyDates = new DateTimeList();
		_dates = new DateTimeList();
		_today = _defaultToday;
		_todayFormat = "d";
		_stateCommon = new PaletteMonthCalendarRedirect();
		_stateFocus = new PaletteMonthCalendarStateRedirect();
		_stateBolded = new PaletteMonthCalendarStateRedirect();
		_stateToday = new PaletteMonthCalendarStateRedirect();
		_stateDisabled = new PaletteMonthCalendarDoubleState(_stateCommon);
		_stateNormal = new PaletteMonthCalendarDoubleState(_stateCommon);
		_stateTracking = new PaletteMonthCalendarState(_stateCommon);
		_statePressed = new PaletteMonthCalendarState(_stateCommon);
		_stateCheckedNormal = new PaletteMonthCalendarState(_stateCommon);
		_stateCheckedTracking = new PaletteMonthCalendarState(_stateCommon);
		_stateCheckedPressed = new PaletteMonthCalendarState(_stateCommon);
		_boldedDisabled = new PaletteTripleOverride(_stateBolded.Day, _stateDisabled.Day, PaletteState.BoldedOverride);
		_boldedNormal = new PaletteTripleOverride(_stateBolded.Day, _stateNormal.Day, PaletteState.BoldedOverride);
		_boldedTracking = new PaletteTripleOverride(_stateBolded.Day, _stateTracking.Day, PaletteState.BoldedOverride);
		_boldedPressed = new PaletteTripleOverride(_stateBolded.Day, _statePressed.Day, PaletteState.BoldedOverride);
		_boldedCheckedNormal = new PaletteTripleOverride(_stateBolded.Day, _stateCheckedNormal.Day, PaletteState.BoldedOverride);
		_boldedCheckedTracking = new PaletteTripleOverride(_stateBolded.Day, _stateCheckedTracking.Day, PaletteState.BoldedOverride);
		_boldedCheckedPressed = new PaletteTripleOverride(_stateBolded.Day, _stateCheckedPressed.Day, PaletteState.BoldedOverride);
		_todayDisabled = new PaletteTripleOverride(_stateToday.Day, _boldedDisabled, PaletteState.TodayOverride);
		_todayNormal = new PaletteTripleOverride(_stateToday.Day, _boldedNormal, PaletteState.TodayOverride);
		_todayTracking = new PaletteTripleOverride(_stateToday.Day, _boldedTracking, PaletteState.TodayOverride);
		_todayPressed = new PaletteTripleOverride(_stateToday.Day, _boldedPressed, PaletteState.TodayOverride);
		_todayCheckedNormal = new PaletteTripleOverride(_stateToday.Day, _boldedCheckedNormal, PaletteState.TodayOverride);
		_todayCheckedTracking = new PaletteTripleOverride(_stateToday.Day, _boldedCheckedTracking, PaletteState.TodayOverride);
		_todayCheckedPressed = new PaletteTripleOverride(_stateToday.Day, _boldedCheckedPressed, PaletteState.TodayOverride);
		_overrideDisabled = new PaletteTripleOverride(_stateFocus.Day, _todayDisabled, PaletteState.FocusOverride);
		_overrideNormal = new PaletteTripleOverride(_stateFocus.Day, _todayNormal, PaletteState.FocusOverride);
		_overrideTracking = new PaletteTripleOverride(_stateFocus.Day, _todayTracking, PaletteState.FocusOverride);
		_overridePressed = new PaletteTripleOverride(_stateFocus.Day, _todayPressed, PaletteState.FocusOverride);
		_overrideCheckedNormal = new PaletteTripleOverride(_stateFocus.Day, _todayCheckedNormal, PaletteState.FocusOverride);
		_overrideCheckedTracking = new PaletteTripleOverride(_stateFocus.Day, _todayCheckedTracking, PaletteState.FocusOverride);
		_overrideCheckedPressed = new PaletteTripleOverride(_stateFocus.Day, _todayCheckedPressed, PaletteState.FocusOverride);
	}

	public override string ToString()
	{
		return "(Month Calendar)";
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		return false;
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		return new ViewDrawMenuMonthCalendar(provider, this);
	}

	private void ResetTodayDate()
	{
		TodayDate = DateTime.Now.Date;
	}

	private bool ShouldSerializeTodayDate()
	{
		return TodayDate != DateTime.Now.Date;
	}

	private void ResetAnnuallyBoldedDates()
	{
		AnnuallyBoldedDates = null;
	}

	private bool ShouldSerializeAnnuallyBoldedDates()
	{
		return _annualDates.Count > 0;
	}

	private void ResetMonthlyBoldedDates()
	{
		MonthlyBoldedDates = null;
	}

	private bool ShouldSerializeMonthlyBoldedDates()
	{
		return _monthlyDates.Count > 0;
	}

	private void ResetBoldedDates()
	{
		BoldedDates = null;
	}

	private bool ShouldSerializeBoldedDates()
	{
		return _dates.Count > 0;
	}

	private void ResetMinDate()
	{
		MinDate = DateTimePicker.MinimumDateTime;
	}

	private bool ShouldSerializeMinDate()
	{
		return _minDate != DateTimePicker.MinimumDateTime;
	}

	private void ResetMaxDate()
	{
		MaxDate = DateTimePicker.MaximumDateTime;
	}

	private bool ShouldSerializeMaxDate()
	{
		return _maxDate != DateTimePicker.MaximumDateTime;
	}

	private void ResetSelectionStart()
	{
		SelectionStart = DateTime.Now.Date;
	}

	private bool ShouldSerializeSelectionStart()
	{
		return SelectionStart != DateTime.Now.Date;
	}

	private void ResetSelectionEnd()
	{
		SelectionEnd = DateTime.Now.Date;
	}

	private bool ShouldSerializeSelectionEnd()
	{
		return SelectionStart != DateTime.Now.Date;
	}

	private void ResetSelectionRange()
	{
		ResetSelectionStart();
		ResetSelectionEnd();
	}

	private bool ShouldSerializeSelectionRange()
	{
		return false;
	}

	private void ResetTodayText()
	{
		TodayText = _defaultToday;
	}

	private void ResetFirstDayOfWeek()
	{
		FirstDayOfWeek = Day.Default;
	}

	private bool ShouldSerializeFirstDayOfWeek()
	{
		return FirstDayOfWeek != Day.Default;
	}

	private bool ShouldSerializeHeaderStyle()
	{
		return _headerStyle != HeaderStyle.Calendar;
	}

	private bool ShouldSerializeDayStyle()
	{
		return _dayStyle != ButtonStyle.CalendarDay;
	}

	private void ResetDayStyle()
	{
		DayStyle = ButtonStyle.CalendarDay;
	}

	private bool ShouldSerializeDayOfWeekStyle()
	{
		return _dayOfWeekStyle != ButtonStyle.CalendarDay;
	}

	private void ResetDayOfWeekStyle()
	{
		DayOfWeekStyle = ButtonStyle.CalendarDay;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	private bool ShouldSerializeOverrideBolded()
	{
		return !_stateBolded.IsDefault;
	}

	private bool ShouldSerializeOverrideToday()
	{
		return !_stateToday.IsDefault;
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

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateCheckedTracking()
	{
		return !_stateCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeStateCheckedPressed()
	{
		return !_stateCheckedPressed.IsDefault;
	}

	public void AddAnnuallyBoldedDate(DateTime date)
	{
		if (!_annualDates.Contains(date))
		{
			_annualDates.Add(date);
			_annualDays[date.Month - 1] |= 1 << date.Day - 1;
			OnPropertyChanged(new PropertyChangedEventArgs("AnnuallyBoldedDates"));
		}
	}

	public void AddBoldedDate(DateTime date)
	{
		if (!_dates.Contains(date))
		{
			_dates.Add(date);
			OnPropertyChanged(new PropertyChangedEventArgs("BoldedDates"));
		}
	}

	public void AddMonthlyBoldedDate(DateTime date)
	{
		if (!_monthlyDates.Contains(date))
		{
			_monthlyDates.Add(date);
			_monthlyDays |= 1 << date.Day - 1;
			OnPropertyChanged(new PropertyChangedEventArgs("MonthlyBoldedDates"));
		}
	}

	public void RemoveAllAnnuallyBoldedDates()
	{
		_annualDates.Clear();
		for (int i = 0; i < 12; i++)
		{
			_annualDays[i] = 0;
		}
		OnPropertyChanged(new PropertyChangedEventArgs("AnnuallyBoldedDates"));
	}

	public void RemoveAllBoldedDates()
	{
		_dates.Clear();
		OnPropertyChanged(new PropertyChangedEventArgs("BoldedDates"));
	}

	public void RemoveAllMonthlyBoldedDates()
	{
		_monthlyDates.Clear();
		_monthlyDays = 0;
		OnPropertyChanged(new PropertyChangedEventArgs("MonthlyBoldedDates"));
	}

	public void SetSelectionRange(DateTime start, DateTime end)
	{
		if (start.Ticks > _maxDate.Ticks)
		{
			throw new ArgumentOutOfRangeException("Start date provided is greater than the maximum date.");
		}
		if (start.Ticks < _minDate.Ticks)
		{
			throw new ArgumentOutOfRangeException("Start date provided is less than the minimum date.");
		}
		if (end.Ticks > _maxDate.Ticks)
		{
			throw new ArgumentOutOfRangeException("End date provided is greater than the maximum date.");
		}
		if (end.Ticks < _minDate.Ticks)
		{
			throw new ArgumentOutOfRangeException("End date provided is less than the minimum date.");
		}
		if (start > end)
		{
			end = start;
		}
		if ((end - start).Days >= _maxSelectionCount)
		{
			if (start.Ticks == _selectionStart.Ticks)
			{
				start = end.AddDays(1 - _maxSelectionCount);
			}
			else
			{
				end = start.AddDays(_maxSelectionCount - 1);
			}
		}
		SetSelRange(start, end);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SetBoldedOverride(bool bolded)
	{
		_boldedDisabled.Apply = bolded;
		_boldedNormal.Apply = bolded;
		_boldedTracking.Apply = bolded;
		_boldedPressed.Apply = bolded;
		_boldedCheckedNormal.Apply = bolded;
		_boldedCheckedTracking.Apply = bolded;
		_boldedCheckedPressed.Apply = bolded;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SetTodayOverride(bool today)
	{
		_todayDisabled.Apply = today;
		_todayNormal.Apply = today;
		_todayTracking.Apply = today;
		_todayPressed.Apply = today;
		_todayCheckedNormal.Apply = today;
		_todayCheckedTracking.Apply = today;
		_todayCheckedPressed.Apply = today;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SetFocusOverride(bool focus)
	{
		_overrideDisabled.Apply = _hasFocus && focus;
		_overrideNormal.Apply = _hasFocus && focus;
		_overrideTracking.Apply = _hasFocus && focus;
		_overridePressed.Apply = _hasFocus && focus;
		_overrideCheckedNormal.Apply = _hasFocus && focus;
		_overrideCheckedTracking.Apply = _hasFocus && focus;
		_overrideCheckedPressed.Apply = _hasFocus && focus;
	}

	protected virtual void OnDateChanged(DateRangeEventArgs e)
	{
		if (this.DateChanged != null)
		{
			this.DateChanged(this, e);
		}
	}

	protected virtual void OnSelectionStartChanged(EventArgs e)
	{
		if (this.SelectionStartChanged != null)
		{
			this.SelectionStartChanged(this, e);
		}
	}

	protected virtual void OnSelectionEndChanged(EventArgs e)
	{
		if (this.SelectionEndChanged != null)
		{
			this.SelectionEndChanged(this, e);
		}
	}

	internal void SetPaletteRedirect(PaletteRedirect redirector)
	{
		_stateCommon.SetRedirector(redirector);
		_stateFocus.SetRedirector(redirector);
		_stateBolded.SetRedirector(redirector);
		_stateToday.SetRedirector(redirector);
	}

	private void SetRange()
	{
		bool flag = false;
		bool flag2 = false;
		if (_selectionStart < _minDate)
		{
			_selectionStart = _minDate.Date;
			flag = true;
		}
		if (_selectionStart > _maxDate)
		{
			_selectionStart = _maxDate.Date;
			flag = true;
		}
		if (_selectionEnd < _minDate)
		{
			_selectionEnd = _minDate.Date;
			flag2 = true;
		}
		if (_selectionEnd > _maxDate)
		{
			_selectionEnd = _maxDate.Date;
			flag2 = true;
		}
		if (flag)
		{
			OnSelectionStartChanged(EventArgs.Empty);
		}
		if (flag2)
		{
			OnSelectionEndChanged(EventArgs.Empty);
		}
		if (flag || flag2)
		{
			OnDateChanged(new DateRangeEventArgs(_selectionStart, _selectionEnd));
		}
		SetFocusDay();
	}

	private void SetSelRange(DateTime lower, DateTime upper)
	{
		bool flag = false;
		bool flag2 = false;
		if (lower != _selectionStart)
		{
			_selectionStart = lower;
			flag = true;
		}
		if (upper != _selectionEnd)
		{
			_selectionEnd = upper;
			flag2 = true;
		}
		if (flag)
		{
			OnSelectionStartChanged(EventArgs.Empty);
		}
		if (flag2)
		{
			OnSelectionEndChanged(EventArgs.Empty);
		}
		if (flag || flag2)
		{
			OnDateChanged(new DateRangeEventArgs(_selectionStart, _selectionEnd));
		}
		SetFocusDay();
	}

	private void SetFocusDay()
	{
		if (!_focusDay.HasValue)
		{
			_focusDay = SelectionStart.Date;
		}
		else if (_focusDay.Value < SelectionStart)
		{
			_focusDay = SelectionStart.Date;
		}
		else if (_focusDay.Value > SelectionStart)
		{
			_focusDay = SelectionEnd.Date;
		}
	}
}
