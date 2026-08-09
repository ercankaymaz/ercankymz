using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_Calendar", Type = typeof(System.Windows.Controls.Calendar))]
[TemplatePart(Name = "PART_TimeUpDown", Type = typeof(TimePicker))]
public class DateTimePicker : DateTimePickerBase
{
	private const string PART_Calendar = "PART_Calendar";

	private const string PART_TimeUpDown = "PART_TimeUpDown";

	private System.Windows.Controls.Calendar _calendar;

	private TimePicker _timePicker;

	private DateTime? _calendarTemporaryDateTime;

	private DateTime? _calendarIntendedDateTime;

	private bool _isModifyingCalendarInternally;

	public static readonly DependencyProperty AutoCloseCalendarProperty;

	public static readonly DependencyProperty AutoCloseCalendarOnTimeSelectionProperty;

	public static readonly DependencyProperty CalendarDisplayModeProperty;

	public static readonly DependencyProperty CalendarWidthProperty;

	public static readonly DependencyProperty TimeFormatProperty;

	public static readonly DependencyProperty TimeFormatStringProperty;

	public static readonly DependencyProperty TimePickerAllowSpinProperty;

	public static readonly DependencyProperty TimePickerTimeListItemsStyleProperty;

	public static readonly DependencyProperty TimePickerShowButtonSpinnerProperty;

	public static readonly DependencyProperty TimePickerVisibilityProperty;

	public static readonly DependencyProperty TimeWatermarkProperty;

	public static readonly DependencyProperty TimeWatermarkTemplateProperty;

	public static readonly RoutedEvent TodayEvent;

	public bool AutoCloseCalendar
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoCloseCalendarProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoCloseCalendarProperty, (object)value);
		}
	}

	public bool AutoCloseCalendarOnTimeSelection
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoCloseCalendarOnTimeSelectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoCloseCalendarOnTimeSelectionProperty, (object)value);
		}
	}

	public CalendarMode CalendarDisplayMode
	{
		get
		{
			return (CalendarMode)((DependencyObject)this).GetValue(CalendarDisplayModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CalendarDisplayModeProperty, (object)value);
		}
	}

	public double CalendarWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CalendarWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CalendarWidthProperty, (object)value);
		}
	}

	public DateTimeFormat TimeFormat
	{
		get
		{
			return (DateTimeFormat)((DependencyObject)this).GetValue(TimeFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeFormatProperty, (object)value);
		}
	}

	public string TimeFormatString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TimeFormatStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeFormatStringProperty, (object)value);
		}
	}

	public bool TimePickerAllowSpin
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(TimePickerAllowSpinProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimePickerAllowSpinProperty, (object)value);
		}
	}

	public Style TimePickerTimeListItemsStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(TimePickerTimeListItemsStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimePickerTimeListItemsStyleProperty, (object)value);
		}
	}

	public bool TimePickerShowButtonSpinner
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(TimePickerShowButtonSpinnerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimePickerShowButtonSpinnerProperty, (object)value);
		}
	}

	public Visibility TimePickerVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(TimePickerVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimePickerVisibilityProperty, (object)value);
		}
	}

	public object TimeWatermark
	{
		get
		{
			return ((DependencyObject)this).GetValue(TimeWatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeWatermarkProperty, value);
		}
	}

	public DataTemplate TimeWatermarkTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(TimeWatermarkTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeWatermarkTemplateProperty, (object)value);
		}
	}

	public event RoutedEventHandler Today
	{
		add
		{
			AddHandler(TodayEvent, value);
		}
		remove
		{
			RemoveHandler(TodayEvent, value);
		}
	}

	private static bool IsTimeFormatStringValid(object value)
	{
		return DateTimeUpDown.IsFormatStringValid(value);
	}

	private static void OnTimePickerTimeListItemsStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DateTimePicker)(object)d).OnTimePickerTimeListItemsStyleChanged(e);
	}

	protected virtual void OnTimePickerTimeListItemsStyleChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	static DateTimePicker()
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		AutoCloseCalendarProperty = DependencyProperty.Register("AutoCloseCalendar", typeof(bool), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		AutoCloseCalendarOnTimeSelectionProperty = DependencyProperty.Register("AutoCloseCalendarOnTimeSelection", typeof(bool), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		CalendarDisplayModeProperty = DependencyProperty.Register("CalendarDisplayMode", typeof(CalendarMode), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)CalendarMode.Month));
		CalendarWidthProperty = DependencyProperty.Register("CalendarWidth", typeof(double), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)178.0));
		TimeFormatProperty = DependencyProperty.Register("TimeFormat", typeof(DateTimeFormat), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)DateTimeFormat.ShortTime));
		TimeFormatStringProperty = DependencyProperty.Register("TimeFormatString", typeof(string), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)null), new ValidateValueCallback(IsTimeFormatStringValid));
		TimePickerAllowSpinProperty = DependencyProperty.Register("TimePickerAllowSpin", typeof(bool), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		TimePickerTimeListItemsStyleProperty = DependencyProperty.Register("TimePickerTimeListItemsStyle", typeof(Style), typeof(DateTimePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnTimePickerTimeListItemsStyleChanged)));
		TimePickerShowButtonSpinnerProperty = DependencyProperty.Register("TimePickerShowButtonSpinner", typeof(bool), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		TimePickerVisibilityProperty = DependencyProperty.Register("TimePickerVisibility", typeof(Visibility), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)Visibility.Visible));
		TimeWatermarkProperty = DependencyProperty.Register("TimeWatermark", typeof(object), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		TimeWatermarkTemplateProperty = DependencyProperty.Register("TimeWatermarkTemplate", typeof(DataTemplate), typeof(DateTimePicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		TodayEvent = EventManager.RegisterRoutedEvent("Today", RoutingStrategy.Bubble, typeof(EventHandler), typeof(DateTimePicker));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(DateTimePicker)));
		UpDownBase<DateTime?>.UpdateValueOnEnterKeyProperty.OverrideMetadata(typeof(DateTimePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	public DateTimePicker()
	{
		EventManager.RegisterClassHandler(typeof(ListBoxItem), UIElement.PreviewMouseUpEvent, new RoutedEventHandler(PreviewMouseUpEventHandler));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_calendar != null)
		{
			_calendar.SelectedDatesChanged -= Calendar_SelectedDatesChanged;
			_calendar.MouseDoubleClick -= Calendar_MouseDoubleClick;
		}
		_calendar = GetTemplateChild("PART_Calendar") as System.Windows.Controls.Calendar;
		if (_calendar != null)
		{
			_calendar.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
			_calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
			_calendar.MouseDoubleClick += Calendar_MouseDoubleClick;
			_calendar.SelectedDate = base.Value ?? ((DateTime?)null);
			_calendar.DisplayDate = base.Value ?? base.ContextNow;
			SetBlackOutDates();
		}
		if (_timePicker != null)
		{
			_timePicker.ValueChanged -= TimePicker_ValueChanged;
		}
		_timePicker = GetTemplateChild("PART_TimeUpDown") as TimePicker;
		if (_timePicker != null)
		{
			_timePicker.ValueChanged += TimePicker_ValueChanged;
		}
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		if (Mouse.Captured is CalendarItem)
		{
			Mouse.Capture(null);
			if (AutoCloseCalendar && _calendar != null && _calendar.DisplayMode == CalendarMode.Month)
			{
				ClosePopup(isFocusOnTextBox: true);
			}
		}
		base.OnPreviewMouseUp(e);
	}

	protected override void OnValueChanged(DateTime? oldValue, DateTime? newValue)
	{
		DateTime? dateTime = (newValue.HasValue ? new DateTime?(newValue.Value.Date) : ((DateTime?)null));
		if (_calendar != null && _calendar.SelectedDate != dateTime)
		{
			_isModifyingCalendarInternally = true;
			_calendar.SelectedDate = dateTime;
			_calendar.DisplayDate = newValue.GetValueOrDefault(base.ContextNow);
			_isModifyingCalendarInternally = false;
		}
		if (_calendar != null && _calendarTemporaryDateTime.HasValue && newValue != _calendarTemporaryDateTime)
		{
			_calendarTemporaryDateTime = null;
			_calendarIntendedDateTime = null;
		}
		if (_timePicker != null)
		{
			_timePicker.UpdateTempValue(newValue);
		}
		base.OnValueChanged(oldValue, newValue);
	}

	protected override void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		base.OnIsOpenChanged(oldValue, newValue);
		if (!newValue)
		{
			_calendarTemporaryDateTime = null;
			_calendarIntendedDateTime = null;
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		if (!base.IsOpen)
		{
			base.OnPreviewKeyDown(e);
		}
	}

	protected override void OnMaximumChanged(DateTime? oldValue, DateTime? newValue)
	{
		base.OnMaximumChanged(oldValue, newValue);
		SetBlackOutDates();
	}

	protected override void OnMinimumChanged(DateTime? oldValue, DateTime? newValue)
	{
		base.OnMinimumChanged(oldValue, newValue);
		SetBlackOutDates();
	}

	protected override void HandleKeyDown(object sender, KeyEventArgs e)
	{
		if (!base.IsOpen || _timePicker == null || !_timePicker.IsKeyboardFocusWithin || (!_timePicker.IsOpen && !e.Handled))
		{
			base.HandleKeyDown(sender, e);
		}
	}

	private void TimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
	{
		e.Handled = true;
		if (base.UpdateValueOnEnterKey)
		{
			DateTime? dateTime = e.NewValue as DateTime?;
			if (dateTime.HasValue)
			{
				_fireSelectionChangedEvent = false;
				DateTime dateTime2 = ConvertTextToValue(base.TextBox.Text) ?? base.ContextNow;
				DateTime dateTime3 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, dateTime.Value.Millisecond, dateTime2.Kind);
				base.TextBox.Text = dateTime3.ToString(GetFormatString(base.Format), base.CultureInfo);
				_fireSelectionChangedEvent = true;
			}
		}
	}

	private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count <= 0)
		{
			return;
		}
		DateTime? dateTime = (DateTime?)e.AddedItems[0];
		if (dateTime.HasValue)
		{
			dateTime = DateTime.SpecifyKind(dateTime.Value, base.Kind);
			if (_calendarIntendedDateTime.HasValue)
			{
				dateTime = dateTime.Value.Date + _calendarIntendedDateTime.Value.TimeOfDay;
				_calendarTemporaryDateTime = null;
				_calendarIntendedDateTime = null;
			}
			else if (_timePicker != null && _timePicker.TempValue.HasValue)
			{
				dateTime = dateTime.Value.Date + _timePicker.TempValue.Value.TimeOfDay;
			}
			else if (base.Value.HasValue)
			{
				dateTime = dateTime.Value.Date + base.Value.Value.TimeOfDay;
			}
			DateTime? clippedMinMaxValue = GetClippedMinMaxValue(dateTime);
			if (clippedMinMaxValue.Value != dateTime.Value)
			{
				_calendarTemporaryDateTime = clippedMinMaxValue;
				_calendarIntendedDateTime = dateTime;
				dateTime = clippedMinMaxValue;
			}
		}
		if (!_isModifyingCalendarInternally && !object.Equals(dateTime, base.Value))
		{
			base.Value = dateTime;
		}
	}

	private void Calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		if (e.OriginalSource is Shape shape && shape.TemplatedParent is CalendarDayButton)
		{
			ClosePopup(isFocusOnTextBox: true);
		}
	}

	protected override void Popup_Opened(object sender, EventArgs e)
	{
		base.Popup_Opened(sender, e);
		if (_calendar != null)
		{
			_calendar.Focus();
		}
		if (_timePicker != null && base.TextBox != null)
		{
			DateTime? newDate = ConvertTextToValue(base.TextBox.Text);
			_timePicker.UpdateTempValue(newDate);
		}
	}

	private void PreviewMouseUpEventHandler(object sender, RoutedEventArgs e)
	{
		if (sender is ListBoxItem listBoxItem && listBoxItem.Content is TimeItem)
		{
			Mouse.Capture(null);
			if (AutoCloseCalendarOnTimeSelection && _calendar != null && _calendar.DisplayMode == CalendarMode.Month)
			{
				ClosePopup(isFocusOnTextBox: true);
			}
		}
	}

	private void SetBlackOutDates()
	{
		if (_calendar != null)
		{
			_calendar.BlackoutDates.Clear();
			if (base.Minimum.HasValue && base.Minimum.HasValue && base.Minimum.Value >= CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MinSupportedDateTime.AddDays(1.0))
			{
				DateTime value = base.Minimum.Value;
				_calendar.BlackoutDates.Add(new CalendarDateRange(CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MinSupportedDateTime, value.AddDays(-1.0)));
			}
			if (base.Maximum.HasValue && base.Maximum.HasValue && base.Maximum.Value <= CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MaxSupportedDateTime.AddDays(-1.0))
			{
				DateTime value2 = base.Maximum.Value;
				_calendar.BlackoutDates.Add(new CalendarDateRange(value2.AddDays(1.0), CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MaxSupportedDateTime));
			}
		}
	}
}
