using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_TimeListItems", Type = typeof(ListBox))]
public class TimePicker : DateTimePickerBase
{
	private const string PART_TimeListItems = "PART_TimeListItems";

	private ListBox _timeListBox;

	private bool _isListBoxInvalid = true;

	internal static readonly TimeSpan EndTimeDefaultValue;

	internal static readonly TimeSpan StartTimeDefaultValue;

	internal static readonly TimeSpan TimeIntervalDefaultValue;

	public static readonly DependencyProperty EndTimeProperty;

	public static readonly DependencyProperty TimeListItemsStyleProperty;

	public static readonly DependencyProperty MaxDropDownHeightProperty;

	public static readonly DependencyProperty StartTimeProperty;

	public static readonly DependencyProperty TimeIntervalProperty;

	public TimeSpan EndTime
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(EndTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndTimeProperty, (object)value);
		}
	}

	public Style TimeListItemsStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(TimeListItemsStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeListItemsStyleProperty, (object)value);
		}
	}

	public double MaxDropDownHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxDropDownHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxDropDownHeightProperty, (object)value);
		}
	}

	public TimeSpan StartTime
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(StartTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartTimeProperty, (object)value);
		}
	}

	public TimeSpan TimeInterval
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(TimeIntervalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeIntervalProperty, (object)value);
		}
	}

	private static object OnCoerceEndTime(DependencyObject o, object value)
	{
		if (o is TimePicker timePicker)
		{
			return timePicker.OnCoerceEndTime((TimeSpan)value);
		}
		return value;
	}

	private static void OnEndTimeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnEndTimeChanged((TimeSpan)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TimeSpan)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual TimeSpan OnCoerceEndTime(TimeSpan value)
	{
		ValidateTime(value);
		return value;
	}

	protected virtual void OnEndTimeChanged(TimeSpan oldValue, TimeSpan newValue)
	{
		InvalidateListBoxItems();
	}

	protected override void OnFormatChanged(DateTimeFormat oldValue, DateTimeFormat newValue)
	{
		base.OnFormatChanged(oldValue, newValue);
		InvalidateListBoxItems();
	}

	private static void OnTimeListItemsStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((TimePicker)(object)d).OnTimeListItemsStyleChanged(e);
	}

	protected virtual void OnTimeListItemsStyleChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static void OnMaxDropDownHeightChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnMaxDropDownHeightChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnMaxDropDownHeightChanged(double oldValue, double newValue)
	{
	}

	private static object OnCoerceStartTime(DependencyObject o, object value)
	{
		if (o is TimePicker timePicker)
		{
			return timePicker.OnCoerceStartTime((TimeSpan)value);
		}
		return value;
	}

	private static void OnStartTimeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnStartTimeChanged((TimeSpan)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TimeSpan)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual TimeSpan OnCoerceStartTime(TimeSpan value)
	{
		ValidateTime(value);
		return value;
	}

	protected virtual void OnStartTimeChanged(TimeSpan oldValue, TimeSpan newValue)
	{
		InvalidateListBoxItems();
	}

	private static object OnCoerceTimeInterval(DependencyObject o, object value)
	{
		if (o is TimePicker timePicker)
		{
			return timePicker.OnCoerceTimeInterval((TimeSpan)value);
		}
		return value;
	}

	private static void OnTimeIntervalChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimePicker timePicker)
		{
			timePicker.OnTimeIntervalChanged((TimeSpan)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TimeSpan)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual TimeSpan OnCoerceTimeInterval(TimeSpan value)
	{
		ValidateTime(value);
		if (value.Ticks == 0L)
		{
			throw new ArgumentException("TimeInterval must be greater than zero");
		}
		return value;
	}

	protected virtual void OnTimeIntervalChanged(TimeSpan oldValue, TimeSpan newValue)
	{
		InvalidateListBoxItems();
	}

	static TimePicker()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0069: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012a: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		EndTimeDefaultValue = new TimeSpan(23, 59, 0);
		StartTimeDefaultValue = new TimeSpan(0, 0, 0);
		TimeIntervalDefaultValue = new TimeSpan(1, 0, 0);
		EndTimeProperty = DependencyProperty.Register("EndTime", typeof(TimeSpan), typeof(TimePicker), (PropertyMetadata)(object)new UIPropertyMetadata(EndTimeDefaultValue, new PropertyChangedCallback(OnEndTimeChanged), new CoerceValueCallback(OnCoerceEndTime)));
		TimeListItemsStyleProperty = DependencyProperty.Register("TimeListItemsStyle", typeof(Style), typeof(TimePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnTimeListItemsStyleChanged)));
		MaxDropDownHeightProperty = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(TimePicker), (PropertyMetadata)(object)new UIPropertyMetadata(130.0, new PropertyChangedCallback(OnMaxDropDownHeightChanged)));
		StartTimeProperty = DependencyProperty.Register("StartTime", typeof(TimeSpan), typeof(TimePicker), (PropertyMetadata)(object)new UIPropertyMetadata(StartTimeDefaultValue, new PropertyChangedCallback(OnStartTimeChanged), new CoerceValueCallback(OnCoerceStartTime)));
		TimeIntervalProperty = DependencyProperty.Register("TimeInterval", typeof(TimeSpan), typeof(TimePicker), (PropertyMetadata)(object)new UIPropertyMetadata(TimeIntervalDefaultValue, new PropertyChangedCallback(OnTimeIntervalChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimePicker)));
		DateTimeUpDown.FormatProperty.OverrideMetadata(typeof(TimePicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)DateTimeFormat.ShortTime));
		UpDownBase<DateTime?>.UpdateValueOnEnterKeyProperty.OverrideMetadata(typeof(TimePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	protected override void OnFormatStringChanged(string oldValue, string newValue)
	{
		if (base.Format == DateTimeFormat.Custom)
		{
			InvalidateListBoxItems();
		}
		base.OnFormatStringChanged(oldValue, newValue);
	}

	protected override void OnMaximumChanged(DateTime? oldValue, DateTime? newValue)
	{
		base.OnMaximumChanged(oldValue, newValue);
		InvalidateListBoxItems();
	}

	protected override void OnMinimumChanged(DateTime? oldValue, DateTime? newValue)
	{
		base.OnMinimumChanged(oldValue, newValue);
		InvalidateListBoxItems();
	}

	protected override void OnValueChanged(DateTime? oldValue, DateTime? newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		bool flag = false;
		if (DateTimeUtilities.IsSameDate(base.Minimum, oldValue) != DateTimeUtilities.IsSameDate(base.Minimum, newValue))
		{
			flag = true;
		}
		if (DateTimeUtilities.IsSameDate(base.Maximum, oldValue) != DateTimeUtilities.IsSameDate(base.Maximum, newValue))
		{
			flag = true;
		}
		if (oldValue.GetValueOrDefault().Date != newValue.GetValueOrDefault().Date)
		{
			flag = true;
		}
		if (flag)
		{
			InvalidateListBoxItems();
		}
		else
		{
			UpdateListBoxSelectedItem();
		}
	}

	protected override void Popup_Opened(object sender, EventArgs e)
	{
		base.Popup_Opened(sender, e);
		if (_timeListBox != null)
		{
			UpdateListBoxItems();
			TimeSpan time = (base.Value.HasValue ? base.Value.Value.TimeOfDay : StartTimeDefaultValue);
			TimeItem nearestTimeItem = GetNearestTimeItem(time);
			if (nearestTimeItem != null)
			{
				_timeListBox.ScrollIntoView(nearestTimeItem);
				UpdateListBoxSelectedItem();
			}
			_timeListBox.Focus();
		}
	}

	public override void OnApplyTemplate()
	{
		if (base.TextBox != null)
		{
			base.TextBox.GotKeyboardFocus -= TextBoxSpinner_GotKeyboardFocus;
		}
		if (base.Spinner != null)
		{
			base.Spinner.GotKeyboardFocus -= TextBoxSpinner_GotKeyboardFocus;
		}
		base.OnApplyTemplate();
		if (base.TextBox != null)
		{
			base.TextBox.GotKeyboardFocus += TextBoxSpinner_GotKeyboardFocus;
		}
		if (base.Spinner != null)
		{
			base.Spinner.GotKeyboardFocus += TextBoxSpinner_GotKeyboardFocus;
		}
		if (_timeListBox != null)
		{
			_timeListBox.SelectionChanged -= TimeListBox_SelectionChanged;
			_timeListBox.MouseUp -= TimeListBox_MouseUp;
		}
		_timeListBox = GetTemplateChild("PART_TimeListItems") as ListBox;
		if (_timeListBox != null)
		{
			_timeListBox.SelectionChanged += TimeListBox_SelectionChanged;
			_timeListBox.MouseUp += TimeListBox_MouseUp;
			InvalidateListBoxItems();
		}
	}

	internal void UpdateTempValue(DateTime? newDate)
	{
		DateTime value = newDate ?? base.ContextNow;
		if (base.TextBox != null)
		{
			base.TextBox.Text = value.ToString(GetFormatString(base.Format), base.CultureInfo);
		}
		base.TempValue = value;
	}

	private void TimeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count > 0)
		{
			TimeSpan time = ((TimeItem)e.AddedItems[0]).Time;
			DateTime dateTime = base.Value ?? base.ContextNow;
			base.Value = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hours, time.Minutes, time.Seconds, time.Milliseconds, dateTime.Kind);
		}
	}

	private void TextBoxSpinner_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
	{
		ClosePopup(isFocusOnTextBox: true);
	}

	private void TimeListBox_MouseUp(object sender, MouseButtonEventArgs e)
	{
		ClosePopup(isFocusOnTextBox: true);
	}

	private void ValidateTime(TimeSpan time)
	{
		if (time.TotalHours >= 24.0)
		{
			throw new ArgumentException("Time value cannot be greater than or equal to 24 hours.");
		}
	}

	public IEnumerable GenerateTimeListItemsSource()
	{
		TimeSpan timeSpan = StartTime;
		TimeSpan timeSpan2 = EndTime;
		if (timeSpan2 <= timeSpan)
		{
			timeSpan2 = EndTimeDefaultValue;
			timeSpan = StartTimeDefaultValue;
		}
		if (base.Value.HasValue)
		{
			DateTime value = base.Value.Value;
			DateTime valueOrDefault = base.Minimum.GetValueOrDefault(CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MinSupportedDateTime);
			DateTime valueOrDefault2 = base.Maximum.GetValueOrDefault(CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MaxSupportedDateTime);
			TimeSpan timeOfDay = valueOrDefault.TimeOfDay;
			TimeSpan timeOfDay2 = valueOrDefault2.TimeOfDay;
			if (value.Date == valueOrDefault.Date && timeSpan.Ticks < timeOfDay.Ticks)
			{
				timeSpan = timeOfDay;
			}
			if (value.Date == valueOrDefault2.Date && timeSpan2.Ticks > timeOfDay2.Ticks)
			{
				timeSpan2 = timeOfDay2;
			}
			if (timeSpan2 < timeSpan)
			{
				timeSpan = timeSpan2;
			}
		}
		TimeSpan timeInterval = TimeInterval;
		List<TimeItem> list = new List<TimeItem>();
		if (timeInterval.Ticks > 0)
		{
			while (timeSpan <= timeSpan2)
			{
				list.Add(CreateTimeItem(timeSpan));
				timeSpan = timeSpan.Add(timeInterval);
			}
		}
		return list;
	}

	protected virtual TimeItem CreateTimeItem(TimeSpan time)
	{
		DateTime dateTime = base.Value ?? base.ContextNow;
		string formatString = GetFormatString(base.Format);
		return new TimeItem(dateTime.Date.Add(time).ToString(formatString, base.CultureInfo), time);
	}

	private void UpdateListBoxSelectedItem()
	{
		if (_timeListBox == null)
		{
			return;
		}
		TimeItem timeItem = null;
		if (base.Value.HasValue)
		{
			timeItem = CreateTimeItem(base.Value.Value.TimeOfDay);
			if (!_timeListBox.Items.Contains(timeItem))
			{
				timeItem = null;
			}
		}
		_timeListBox.SelectedItem = timeItem;
	}

	private void InvalidateListBoxItems()
	{
		_isListBoxInvalid = true;
		if (base.IsOpen)
		{
			UpdateListBoxItems();
		}
	}

	private void UpdateListBoxItems()
	{
		if (_timeListBox != null && _isListBoxInvalid)
		{
			_timeListBox.ItemsSource = GenerateTimeListItemsSource();
			UpdateListBoxSelectedItem();
			_isListBoxInvalid = false;
		}
	}

	private TimeItem GetNearestTimeItem(TimeSpan time)
	{
		if (_timeListBox != null)
		{
			int count = _timeListBox.Items.Count;
			for (int i = 0; i < count; i++)
			{
				if (_timeListBox.Items[i] is TimeItem timeItem && timeItem.Time >= time)
				{
					return timeItem;
				}
			}
			if (count > 0)
			{
				return _timeListBox.Items[count - 1] as TimeItem;
			}
		}
		return null;
	}
}
