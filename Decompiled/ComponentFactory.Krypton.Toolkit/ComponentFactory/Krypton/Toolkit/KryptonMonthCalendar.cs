using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonMonthCalendar), "ToolboxBitmaps.KryptonMonthCalendar.bmp")]
[DefaultEvent("DateChanged")]
[DefaultProperty("SelectionRange")]
[DefaultBindingProperty("SelectionRange")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonMonthCalendarDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Select a date using a visual monthly calendar display.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonMonthCalendar : VisualSimpleBase, IKryptonMonthCalendar
{
	private ViewDrawDocker _drawDocker;

	private ViewLayoutMonths _drawMonths;

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

	private DateTime _selectionStart;

	private DateTime _selectionEnd;

	private DateTime _minDate;

	private DateTime _maxDate;

	private DateTime _todayDate;

	private DateTimeList _annualDates;

	private DateTimeList _monthlyDates;

	private DateTimeList _dates;

	private Day _firstDayOfWeek;

	private Size _dimensions;

	private string _todayFormat;

	private int _maxSelectionCount;

	private int _monthlyDays;

	private int _scrollChange;

	private int[] _annualDays;

	private bool _hasFocus;

	private DateTime? _focusDay;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public override AutoSizeMode AutoSizeMode
	{
		get
		{
			return base.AutoSizeMode;
		}
		set
		{
			base.AutoSizeMode = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ImeMode ImeMode
	{
		get
		{
			return base.ImeMode;
		}
		set
		{
			base.ImeMode = value;
		}
	}

	[Browsable(false)]
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

	[Category("Behavior")]
	[Description("Minimum allowable date.")]
	[RefreshProperties(RefreshProperties.All)]
	public DateTime MinDate
	{
		get
		{
			return EffectiveMinDate(_minDate);
		}
		set
		{
			if (value != _minDate)
			{
				if (value > EffectiveMaxDate(_maxDate))
				{
					throw new ArgumentOutOfRangeException("Date provided is greater than the maximum supported date.");
				}
				if (value < DateTimePicker.MinimumDateTime)
				{
					throw new ArgumentOutOfRangeException("Date provided is less than the minimum supported date.");
				}
				_minDate = value;
				SetRange();
			}
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

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
			PerformNeedPaint(needLayout: true);
		}
	}

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
			PerformNeedPaint(needLayout: true);
		}
	}

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
			PerformNeedPaint(needLayout: true);
		}
	}

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
			PerformNeedPaint(needLayout: true);
		}
	}

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
			PerformNeedPaint(needLayout: true);
		}
	}

	[Category("Behavior")]
	[Description("Maximum allowable date.")]
	[RefreshProperties(RefreshProperties.All)]
	public DateTime MaxDate
	{
		get
		{
			return EffectiveMaxDate(_maxDate);
		}
		set
		{
			if (value != _maxDate)
			{
				if (value < EffectiveMinDate(_minDate))
				{
					throw new ArgumentOutOfRangeException("Date provided is less than the minimum supported date.");
				}
				if (value > DateTimePicker.MaximumDateTime)
				{
					throw new ArgumentOutOfRangeException("Date provided is greater than the maximum supported date.");
				}
				_maxDate = value;
				SetRange();
			}
		}
	}

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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Start date of the selected range of dates.")]
	[RefreshProperties(RefreshProperties.All)]
	[Bindable(true)]
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
				DateTime dateTime = _selectionEnd;
				if (dateTime < value)
				{
					dateTime = value;
				}
				if ((dateTime - value).Days >= _maxSelectionCount)
				{
					dateTime = value.AddDays(_maxSelectionCount - 1);
				}
				SetSelRange(value, dateTime);
			}
		}
	}

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
				DateTime dateTime = _selectionStart;
				if (dateTime > value)
				{
					dateTime = value;
				}
				if ((value - dateTime).Days >= _maxSelectionCount)
				{
					dateTime = value.AddDays(1 - _maxSelectionCount);
				}
				SetSelRange(dateTime, value);
			}
		}
	}

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
				base.Size = GetPreferredSize(new Size(int.MaxValue, int.MaxValue));
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("First day of the week.")]
	[DefaultValue(typeof(Day), "Default")]
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Background style for the month calendar.")]
	public PaletteBackStyle ControlBackStyle
	{
		get
		{
			return _stateCommon.BackStyle;
		}
		set
		{
			if (_stateCommon.BackStyle != value)
			{
				_stateCommon.BackStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Border style for the month calendar.")]
	public PaletteBorderStyle ControlBorderStyle
	{
		get
		{
			return _stateCommon.BorderStyle;
		}
		set
		{
			if (_stateCommon.BorderStyle != value)
			{
				_stateCommon.BorderStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Header style for the month calendar.")]
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Content style for the day entries.")]
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
				_stateBolded.DayStyle = value;
				_stateFocus.DayStyle = value;
				_stateToday.DayStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Content style for the day of week labels.")]
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether this month calendar will display todays date.")]
	[DefaultValue(true)]
	public bool ShowToday
	{
		get
		{
			return _drawMonths.ShowToday;
		}
		set
		{
			if (_drawMonths.ShowToday != value)
			{
				_drawMonths.ShowToday = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether this month calendar will circle the today date.")]
	[DefaultValue(true)]
	public bool ShowTodayCircle
	{
		get
		{
			return _drawMonths.ShowTodayCircle;
		}
		set
		{
			if (_drawMonths.ShowTodayCircle != value)
			{
				_drawMonths.ShowTodayCircle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether this month calendar will display week numbers to the left of each row.")]
	[DefaultValue(false)]
	public bool ShowWeekNumbers
	{
		get
		{
			return _drawMonths.ShowWeekNumbers;
		}
		set
		{
			if (_drawMonths.ShowWeekNumbers != value)
			{
				_drawMonths.ShowWeekNumbers = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining month calendar appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarStateRedirect OverrideFocus => _stateFocus;

	[Category("Visuals")]
	[Description("Overrides for defining month calendar appearance when it is bolded.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarStateRedirect OverrideBolded => _stateBolded;

	[Category("Visuals")]
	[Description("Overrides for defining month calendar appearance when it is today.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarStateRedirect OverrideToday => _stateToday;

	[Category("Visuals")]
	[Description("Overrides for defining common month calendar appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining month calendar disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarDoubleState StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining month calendar normal appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarDoubleState StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining tracking month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StatePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining checked normal month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateCheckedNormal => _stateCheckedNormal;

	[Category("Visuals")]
	[Description("Overrides for defining checked tracking month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateCheckedTracking => _stateCheckedTracking;

	[Category("Visuals")]
	[Description("Overrides for defining checked pressed month calendar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteMonthCalendarState StateCheckedPressed => _stateCheckedPressed;

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public MonthCalendarButtonSpecCollection ButtonSpecs => _drawMonths.ButtonSpecs;

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _drawMonths.AllowButtonSpecToolTips;
		}
		set
		{
			_drawMonths.AllowButtonSpecToolTips = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Control CalendarControl => this;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool InDesignMode => base.DesignMode;

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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public GetToolStripRenderer GetToolStripDelegate => base.CreateToolStripRenderer;

	[Category("Action")]
	[Description("Occurs when the selected date changes.")]
	public event DateRangeEventHandler DateChanged;

	[Category("Property Changed")]
	[Description("Occurs when the selected start date changes.")]
	public event EventHandler SelectionStartChanged;

	[Category("Property Changed")]
	[Description("Occurs when the selected end date changes.")]
	public event EventHandler SelectionEndChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler Click;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler DoubleClick;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler TextChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler ForeColorChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler FontChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageLayoutChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackColorChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler PaddingChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event PaintEventHandler Paint;

	public KryptonMonthCalendar()
	{
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		_stateCommon = new PaletteMonthCalendarRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateFocus = new PaletteMonthCalendarStateRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateBolded = new PaletteMonthCalendarStateRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateToday = new PaletteMonthCalendarStateRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateDisabled = new PaletteMonthCalendarDoubleState(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteMonthCalendarDoubleState(_stateCommon, base.NeedPaintDelegate);
		_stateTracking = new PaletteMonthCalendarState(_stateCommon, base.NeedPaintDelegate);
		_statePressed = new PaletteMonthCalendarState(_stateCommon, base.NeedPaintDelegate);
		_stateCheckedNormal = new PaletteMonthCalendarState(_stateCommon, base.NeedPaintDelegate);
		_stateCheckedTracking = new PaletteMonthCalendarState(_stateCommon, base.NeedPaintDelegate);
		_stateCheckedPressed = new PaletteMonthCalendarState(_stateCommon, base.NeedPaintDelegate);
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
		_drawMonths = new ViewLayoutMonths(null, null, null, this, base.Redirector, base.NeedPaintDelegate);
		_drawDocker = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border, null);
		_drawDocker.Add(_drawMonths, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDocker);
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
		_scrollChange = 0;
		_todayFormat = "d";
	}

	private void ResetMinDate()
	{
		MinDate = DateTimePicker.MinimumDateTime;
	}

	private bool ShouldSerializeMinDate()
	{
		return _minDate != DateTimePicker.MinimumDateTime;
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

	private void ResetMaxDate()
	{
		MaxDate = DateTime.MaxValue;
	}

	private bool ShouldSerializeMaxDate()
	{
		return _maxDate != DateTimePicker.MaximumDateTime && _maxDate != DateTime.MaxValue;
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
		return SelectionEnd != DateTime.Now.Date;
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

	private bool ShouldSerializeControlBackStyle()
	{
		return ControlBackStyle != PaletteBackStyle.ControlClient;
	}

	private void ResetControlBackStyle()
	{
		ControlBackStyle = PaletteBackStyle.ControlClient;
	}

	private bool ShouldSerializeControlBorderStyle()
	{
		return ControlBorderStyle != PaletteBorderStyle.ControlClient;
	}

	private void ResetControlBorderStyle()
	{
		ControlBorderStyle = PaletteBorderStyle.ControlClient;
	}

	private bool ShouldSerializeHeaderStyle()
	{
		return _headerStyle != HeaderStyle.Calendar;
	}

	private void ResetHeaderStyle()
	{
		HeaderStyle = HeaderStyle.Calendar;
	}

	private bool ShouldSerializeDayStyle()
	{
		return _dayStyle != ButtonStyle.CalendarDay;
	}

	private void ResetDayStyle()
	{
		DayOfWeekStyle = ButtonStyle.CalendarDay;
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
			PerformNeedPaint(needLayout: true);
		}
	}

	public void AddBoldedDate(DateTime date)
	{
		if (!_dates.Contains(date))
		{
			_dates.Add(date);
			PerformNeedPaint(needLayout: true);
		}
	}

	public void AddMonthlyBoldedDate(DateTime date)
	{
		if (!_monthlyDates.Contains(date))
		{
			_monthlyDates.Add(date);
			_monthlyDays |= 1 << date.Day - 1;
			PerformNeedPaint(needLayout: true);
		}
	}

	public void RemoveAllAnnuallyBoldedDates()
	{
		_annualDates.Clear();
		for (int i = 0; i < 12; i++)
		{
			_annualDays[i] = 0;
		}
		PerformNeedPaint(needLayout: true);
	}

	public void RemoveAllBoldedDates()
	{
		_dates.Clear();
		PerformNeedPaint(needLayout: true);
	}

	public void RemoveAllMonthlyBoldedDates()
	{
		_monthlyDates.Clear();
		_monthlyDays = 0;
		PerformNeedPaint(needLayout: true);
	}

	public IRenderer GetRenderer()
	{
		return base.Renderer;
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool DesignerGetHitTest(Point pt)
	{
		if (base.IsDisposed)
		{
			return false;
		}
		if (_drawMonths != null && _drawMonths.ButtonManager.DesignerGetHitTest(pt))
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

	protected override void OnButtonSpecChanged(object sender, EventArgs e)
	{
		_drawMonths.RecreateButtons();
		base.OnButtonSpecChanged(sender, e);
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

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (base.IsDisposed || base.Disposing || !_drawMonths.ProcessKeyDown(this, e))
		{
			base.OnKeyDown(e);
		}
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

	protected override void OnGotFocus(EventArgs e)
	{
		SetFocusDay();
		UpdateFocusOverride(focus: true);
		PerformNeedPaint(needLayout: false);
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		UpdateFocusOverride(focus: false);
		PerformNeedPaint(needLayout: false);
		base.OnLostFocus(e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (this.Paint != null)
		{
			this.Paint(this, e);
		}
		base.OnPaint(e);
	}

	protected override void OnClick(EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
		base.OnClick(e);
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		if (this.DoubleClick != null)
		{
			this.DoubleClick(this, e);
		}
		base.OnDoubleClick(e);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		if (this.TextChanged != null)
		{
			this.TextChanged(this, e);
		}
		base.OnTextChanged(e);
	}

	protected override void OnForeColorChanged(EventArgs e)
	{
		if (this.ForeColorChanged != null)
		{
			this.ForeColorChanged(this, e);
		}
		base.OnForeColorChanged(e);
	}

	protected override void OnFontChanged(EventArgs e)
	{
		if (this.FontChanged != null)
		{
			this.FontChanged(this, e);
		}
		base.OnFontChanged(e);
	}

	protected override void OnBackgroundImageChanged(EventArgs e)
	{
		if (this.BackgroundImageChanged != null)
		{
			this.BackgroundImageChanged(this, e);
		}
		base.OnBackgroundImageChanged(e);
	}

	protected override void OnBackgroundImageLayoutChanged(EventArgs e)
	{
		if (this.BackgroundImageLayoutChanged != null)
		{
			this.BackgroundImageLayoutChanged(this, e);
		}
		base.OnBackgroundImageLayoutChanged(e);
	}

	protected override void OnBackColorChanged(EventArgs e)
	{
		if (this.BackColorChanged != null)
		{
			this.BackColorChanged(this, e);
		}
		base.OnBackColorChanged(e);
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		if (this.PaddingChanged != null)
		{
			this.PaddingChanged(this, e);
		}
		base.OnPaddingChanged(e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		_drawDocker.Enabled = base.Enabled;
		_drawMonths.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed && !base.Disposing)
		{
			int num = base.Width;
			int num2 = base.Height;
			AdjustSize(ref num, ref num2);
			if (num != base.Width || num2 != base.Height)
			{
				base.Size = new Size(num, num2);
			}
		}
		base.OnLayout(levent);
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		Rectangle bounds = base.Bounds;
		AdjustSize(ref width, ref height);
		base.SetBoundsCore(x, y, width, height, specified);
	}

	private DateTime EffectiveMaxDate(DateTime maxDate)
	{
		DateTime maximumDateTime = DateTimePicker.MaximumDateTime;
		if (maxDate > maximumDateTime)
		{
			return maximumDateTime;
		}
		return maxDate;
	}

	private DateTime EffectiveMinDate(DateTime minDate)
	{
		DateTime minimumDateTime = DateTimePicker.MinimumDateTime;
		if (minDate < minimumDateTime)
		{
			return minimumDateTime;
		}
		return minDate;
	}

	private void AdjustSize(ref int width, ref int height)
	{
		using ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer);
		Size nonChildSize = _drawDocker.GetNonChildSize(context);
		Size singleMonthSize = _drawMonths.GetSingleMonthSize(context);
		int gAP = ViewLayoutMonths.GAP;
		int num = Math.Max(1, (width - nonChildSize.Width - gAP) / (singleMonthSize.Width + gAP));
		int num2 = Math.Max(1, (height - nonChildSize.Height - gAP) / (singleMonthSize.Height + gAP));
		width = nonChildSize.Width + num * singleMonthSize.Width + gAP * (num + 1);
		height = nonChildSize.Height + num2 * singleMonthSize.Height + gAP * (num2 + 1);
		Size extraSize = _drawMonths.GetExtraSize(context);
		width += extraSize.Width;
		height += extraSize.Height;
		CalendarDimensions = new Size(num, num2);
	}

	private void SetRange()
	{
		bool flag = false;
		bool flag2 = false;
		DateTime dateTime = EffectiveMinDate(_minDate);
		DateTime dateTime2 = EffectiveMaxDate(_maxDate);
		if (_selectionStart < dateTime)
		{
			_selectionStart = dateTime.Date;
			flag = true;
		}
		if (_selectionStart > dateTime2)
		{
			_selectionStart = dateTime2.Date;
			flag = true;
		}
		if (_selectionEnd < dateTime)
		{
			_selectionEnd = dateTime.Date;
			flag2 = true;
		}
		if (_selectionEnd > dateTime2)
		{
			_selectionEnd = dateTime2.Date;
			flag2 = true;
		}
		PerformNeedPaint(needLayout: true);
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
		PerformNeedPaint(needLayout: true);
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

	private void UpdateFocusOverride(bool focus)
	{
		_hasFocus = focus;
	}
}
