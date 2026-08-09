using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public class TimeSpanUpDown : DateTimeUpDownBase<TimeSpan?>
{
	private static readonly int HoursInDay;

	private static readonly int MinutesInDay;

	private static readonly int MinutesInHour;

	private static readonly int SecondsInDay;

	private static readonly int SecondsInHour;

	private static readonly int SecondsInMinute;

	private static readonly int MilliSecondsInDay;

	private static readonly int MilliSecondsInHour;

	private static readonly int MilliSecondsInMinute;

	private static readonly int MilliSecondsInSecond;

	private int _defaultFractionalSecondsDigitsCount = 3;

	public static readonly DependencyProperty FractionalSecondsDigitsCountProperty;

	public static readonly DependencyProperty ShowDaysProperty;

	public static readonly DependencyProperty ShowHoursProperty;

	public static readonly DependencyProperty ShowSecondsProperty;

	public int FractionalSecondsDigitsCount
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(FractionalSecondsDigitsCountProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FractionalSecondsDigitsCountProperty, (object)value);
		}
	}

	public bool ShowDays
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowDaysProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowDaysProperty, (object)value);
		}
	}

	public bool ShowHours
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowHoursProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowHoursProperty, (object)value);
		}
	}

	public bool ShowSeconds
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSecondsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSecondsProperty, (object)value);
		}
	}

	static TimeSpanUpDown()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00a9: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		HoursInDay = 24;
		MinutesInDay = 1440;
		MinutesInHour = 60;
		SecondsInDay = 86400;
		SecondsInHour = 3600;
		SecondsInMinute = 60;
		MilliSecondsInDay = SecondsInDay * 1000;
		MilliSecondsInHour = SecondsInHour * 1000;
		MilliSecondsInMinute = SecondsInMinute * 1000;
		MilliSecondsInSecond = 1000;
		FractionalSecondsDigitsCountProperty = DependencyProperty.Register("FractionalSecondsDigitsCount", typeof(int), typeof(TimeSpanUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(0, new PropertyChangedCallback(OnFractionalSecondsDigitsCountChanged), new CoerceValueCallback(OnCoerceFractionalSecondsDigitsCount)));
		ShowDaysProperty = DependencyProperty.Register("ShowDays", typeof(bool), typeof(TimeSpanUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnShowDaysChanged)));
		ShowHoursProperty = DependencyProperty.Register("ShowHours", typeof(bool), typeof(TimeSpanUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnShowHoursChanged)));
		ShowSecondsProperty = DependencyProperty.Register("ShowSeconds", typeof(bool), typeof(TimeSpanUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnShowSecondsChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeSpanUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimeSpanUpDown)));
		UpDownBase<TimeSpan?>.MaximumProperty.OverrideMetadata(typeof(TimeSpanUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSpan.MaxValue));
		UpDownBase<TimeSpan?>.MinimumProperty.OverrideMetadata(typeof(TimeSpanUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSpan.MinValue));
		UpDownBase<TimeSpan?>.DefaultValueProperty.OverrideMetadata(typeof(TimeSpanUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSpan.Zero));
	}

	public TimeSpanUpDown()
	{
		DataObject.AddPastingHandler((DependencyObject)(object)this, OnPasting);
	}

	private static object OnCoerceFractionalSecondsDigitsCount(DependencyObject o, object value)
	{
		if (o is TimeSpanUpDown)
		{
			int num = (int)value;
			if (num < 0 || num > 3)
			{
				throw new ArgumentException("Fractional seconds digits count must be between 0 and 3.");
			}
		}
		return value;
	}

	private static void OnFractionalSecondsDigitsCountChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimeSpanUpDown timeSpanUpDown)
		{
			timeSpanUpDown.OnFractionalSecondsDigitsCountChanged((int)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnFractionalSecondsDigitsCountChanged(int oldValue, int newValue)
	{
		UpdateValue();
	}

	private static void OnShowDaysChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimeSpanUpDown timeSpanUpDown)
		{
			timeSpanUpDown.OnShowDaysChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnShowDaysChanged(bool oldValue, bool newValue)
	{
		UpdateValue();
	}

	private static void OnShowHoursChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimeSpanUpDown timeSpanUpDown)
		{
			timeSpanUpDown.OnShowHoursChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnShowHoursChanged(bool oldValue, bool newValue)
	{
		UpdateValue();
	}

	private static void OnShowSecondsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is TimeSpanUpDown timeSpanUpDown)
		{
			timeSpanUpDown.OnShowSecondsChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnShowSecondsChanged(bool oldValue, bool newValue)
	{
		UpdateValue();
	}

	public override bool CommitInput()
	{
		bool result = SyncTextAndValueProperties(updateValueFromText: true, base.Text);
		if (base.UpdateValueOnEnterKey && _selectedDateTimeInfo != null && _dateTimeInfoList != null)
		{
			DateTimeInfo dateTimeInfo = _dateTimeInfoList.FirstOrDefault((DateTimeInfo x) => x.Type == _selectedDateTimeInfo.Type && x.Type != DateTimePart.Other);
			_selectedDateTimeInfo = ((dateTimeInfo != null) ? dateTimeInfo : _dateTimeInfoList.FirstOrDefault((DateTimeInfo x) => x.Type != DateTimePart.Other));
			if (_selectedDateTimeInfo != null)
			{
				_fireSelectionChangedEvent = false;
				base.TextBox.Select(_selectedDateTimeInfo.StartPosition, _selectedDateTimeInfo.Length);
				_fireSelectionChangedEvent = true;
			}
		}
		return result;
	}

	protected override void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
	{
		TimeSpan? value = ((!base.UpdateValueOnEnterKey) ? base.Value : ((base.TextBox != null) ? ConvertTextToValue(base.TextBox.Text) : ((TimeSpan?)null)));
		InitializeDateTimeInfoList(value);
	}

	protected override void OnCurrentDateTimePartChanged(DateTimePart oldValue, DateTimePart newValue)
	{
		if (base.CurrentDateTimePart == DateTimePart.Millisecond && FractionalSecondsDigitsCount < 3)
		{
			((DependencyObject)this).SetCurrentValue(FractionalSecondsDigitsCountProperty, (object)_defaultFractionalSecondsDigitsCount);
		}
		base.OnCurrentDateTimePartChanged(oldValue, newValue);
	}

	protected override void SetValidSpinDirection()
	{
		ValidSpinDirections validSpinDirections = ValidSpinDirections.None;
		if (!base.IsReadOnly)
		{
			if (IsLowerThan(base.Value, base.Maximum) || !base.Value.HasValue || !base.Maximum.HasValue)
			{
				validSpinDirections |= ValidSpinDirections.Increase;
			}
			if (IsGreaterThan(base.Value, base.Minimum) || !base.Value.HasValue || !base.Minimum.HasValue)
			{
				validSpinDirections |= ValidSpinDirections.Decrease;
			}
		}
		if (base.Spinner != null)
		{
			base.Spinner.ValidSpinDirection = validSpinDirections;
		}
	}

	protected override void OnIncrement()
	{
		Increment(base.Step);
	}

	protected override void OnDecrement()
	{
		Increment(-base.Step);
	}

	protected override string ConvertValueToText()
	{
		if (!base.Value.HasValue)
		{
			return string.Empty;
		}
		return ParseValueIntoTimeSpanInfo(base.Value, modifyInfo: true);
	}

	protected override TimeSpan? ConvertTextToValue(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		TimeSpan value = TimeSpan.MinValue;
		List<char> source = text.Where((char x) => x == ':' || x == '.').ToList();
		string[] array = text.Split(':', '.');
		if (array.Count() <= 1 || array.Any((string x) => string.IsNullOrEmpty(x)))
		{
			return ResetToLastValidValue();
		}
		int[] array2 = new int[array.Count()];
		for (int num = 0; num < array.Count(); num++)
		{
			if (!int.TryParse(array[num].Replace("-", ""), out array2[num]))
			{
				return ResetToLastValidValue();
			}
		}
		if (array2.Count() >= 2)
		{
			bool flag = source.Count() > 1 && source.Last() == '.';
			bool flag2 = source.Count() > 1 && source.First() == '.' && array2.Count() >= 3;
			if (!ShowHours && ShowDays)
			{
				throw new NotSupportedException("Cannot show days when show hours is set to false.");
			}
			if (ShowDays)
			{
				int num2 = (flag2 ? array2[0] : (array2[0] / 24));
				if (num2 > TimeSpan.MaxValue.Days)
				{
					return ResetToLastValidValue();
				}
				int num3 = (flag2 ? array2[1] : (array2[0] % 24));
				if ((double)(num2 * HoursInDay + num3) > TimeSpan.MaxValue.TotalHours)
				{
					return ResetToLastValidValue();
				}
				int num4 = (flag2 ? array2[2] : array2[1]);
				if ((double)(num2 * MinutesInDay + num3 * MinutesInHour + num4) > TimeSpan.MaxValue.TotalMinutes)
				{
					return ResetToLastValidValue();
				}
				int num5 = (ShowSeconds ? ((flag2 && array2.Count() >= 4) ? array2[3] : ((array2.Count() >= 3) ? array2[2] : 0)) : 0);
				if ((double)(num2 * SecondsInDay + num3 * SecondsInHour + num4 * SecondsInMinute + num5) > TimeSpan.MaxValue.TotalSeconds)
				{
					return ResetToLastValidValue();
				}
				int num6 = (flag ? array2.Last() : 0);
				if ((double)(num2 * MilliSecondsInDay + num3 * MilliSecondsInHour + num4 * MilliSecondsInMinute + num5 * MilliSecondsInSecond + num6) > TimeSpan.MaxValue.TotalMilliseconds)
				{
					return ResetToLastValidValue();
				}
				value = new TimeSpan(num2, num3, num4, num5, num6);
			}
			else if (ShowHours)
			{
				int num7 = array2[0];
				if ((double)num7 > TimeSpan.MaxValue.TotalHours)
				{
					return ResetToLastValidValue();
				}
				int num8 = array2[1];
				if ((double)(num7 * MinutesInHour + num8) > TimeSpan.MaxValue.TotalMinutes)
				{
					return ResetToLastValidValue();
				}
				int num9 = ((ShowSeconds && array2.Count() >= 3) ? array2[2] : 0);
				if ((double)(num7 * SecondsInHour + num8 * SecondsInMinute + num9) > TimeSpan.MaxValue.TotalSeconds)
				{
					return ResetToLastValidValue();
				}
				int num10 = (flag ? array2.Last() : 0);
				if ((double)(num7 * MilliSecondsInHour + num8 * MilliSecondsInMinute + num9 * MilliSecondsInSecond + num10) > TimeSpan.MaxValue.TotalMilliseconds)
				{
					return ResetToLastValidValue();
				}
				value = new TimeSpan(0, num7, num8, num9, num10);
			}
			else
			{
				int num11 = array2[0];
				if ((double)num11 > TimeSpan.MaxValue.TotalMinutes)
				{
					return ResetToLastValidValue();
				}
				int num12 = ((ShowSeconds && array2.Count() >= 2) ? array2[1] : 0);
				if ((double)(num11 * SecondsInMinute + num12) > TimeSpan.MaxValue.TotalSeconds)
				{
					return ResetToLastValidValue();
				}
				int num13 = (flag ? array2.Last() : 0);
				if ((double)(num11 * MilliSecondsInMinute + num12 * MilliSecondsInSecond + num13) > TimeSpan.MaxValue.TotalMilliseconds)
				{
					return ResetToLastValidValue();
				}
				value = new TimeSpan(0, 0, num11, num12, num13);
			}
			if (text.StartsWith("-"))
			{
				value = value.Negate();
			}
		}
		if (base.ClipValueToMinMax)
		{
			return GetClippedMinMaxValue(value);
		}
		ValidateDefaultMinMax(value);
		return value;
	}

	protected override void OnPreviewTextInput(TextCompositionEventArgs e)
	{
		e.Handled = !IsNumber(e.Text);
		base.OnPreviewTextInput(e);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 18)
		{
			e.Handled = true;
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnTextChanged(string previousValue, string currentValue)
	{
		if (!_processTextChanged)
		{
			return;
		}
		if (string.IsNullOrEmpty(currentValue))
		{
			if (!base.UpdateValueOnEnterKey)
			{
				base.Value = null;
			}
			return;
		}
		if (base.Value.HasValue)
		{
			_ = base.Value.Value;
		}
		List<char> source = currentValue.Where((char x) => x == ':' || x == '.').ToList();
		string[] array = currentValue.Split(':', '.');
		if (array.Count() < 2 || array.Any((string x) => string.IsNullOrEmpty(x)))
		{
			return;
		}
		bool flag = source.First() == '.' && array.Count() >= 3;
		bool flag2 = source.Count() > 1 && source.Last() == '.';
		int[] array2 = new int[array.Count()];
		for (int num = 0; num < array.Count(); num++)
		{
			if (!int.TryParse(array[num], out array2[num]))
			{
				return;
			}
		}
		int num2 = (flag ? Math.Abs(array2[0]) : 0);
		if (num2 > TimeSpan.MaxValue.Days)
		{
			return;
		}
		int num3 = (flag ? Math.Abs(array2[1]) : Math.Abs(array2[0]));
		if ((double)(num2 * HoursInDay + num3) > TimeSpan.MaxValue.TotalHours)
		{
			return;
		}
		int num4 = (flag ? Math.Abs(array2[2]) : Math.Abs(array2[1]));
		if ((double)(num2 * MinutesInDay + num3 * MinutesInHour + num4) > TimeSpan.MaxValue.TotalMinutes)
		{
			return;
		}
		int num5 = ((flag && ShowSeconds && array2.Count() >= 4) ? Math.Abs(array2[3]) : ((ShowSeconds && array2.Count() >= 3) ? Math.Abs(array2[2]) : 0));
		if ((double)(num2 * SecondsInDay + num3 * SecondsInHour + num4 * SecondsInMinute + num5) > TimeSpan.MaxValue.TotalSeconds)
		{
			return;
		}
		int num6 = (flag2 ? Math.Abs(array2.Last()) : 0);
		if (!((double)(num2 * MilliSecondsInDay + num3 * MilliSecondsInHour + num4 * MilliSecondsInMinute + num5 * MilliSecondsInSecond + num6) > TimeSpan.MaxValue.TotalMilliseconds))
		{
			TimeSpan timeSpan = new TimeSpan(num2, num3, num4, num5, num6);
			if (array2[0] < 0)
			{
				timeSpan = timeSpan.Negate();
			}
			currentValue = timeSpan.ToString();
			string[] array3 = previousValue?.Split(':', '.');
			string[] array4 = currentValue?.Split(':', '.');
			bool flag3 = array3 != null && array4 != null && array3.Length == array4.Length && currentValue.Length == previousValue.Length;
			if ((_isTextChangedFromUI && !base.UpdateValueOnEnterKey && flag3) || !_isTextChangedFromUI)
			{
				SyncTextAndValueProperties(updateValueFromText: true, currentValue);
			}
		}
	}

	protected override void OnValueChanged(TimeSpan? oldValue, TimeSpan? newValue)
	{
		if (newValue.HasValue)
		{
			TimeSpan? value = ((!base.UpdateValueOnEnterKey) ? base.Value : ((base.TextBox != null) ? ConvertTextToValue(base.TextBox.Text) : ((TimeSpan?)null)));
			InitializeDateTimeInfoList(value);
		}
		base.OnValueChanged(oldValue, newValue);
	}

	protected override void PerformMouseSelection()
	{
		if (!base.UpdateValueOnEnterKey)
		{
			CommitInput();
			InitializeDateTimeInfoList(base.Value);
		}
		DateTimeInfo dateTimeInfo = ((_selectedDateTimeInfo == null && base.CurrentDateTimePart != DateTimePart.Other) ? GetDateTimeInfo(base.CurrentDateTimePart) : GetDateTimeInfo(base.TextBox.SelectionStart));
		if (dateTimeInfo != null && dateTimeInfo.Type == DateTimePart.Other)
		{
			Select(GetDateTimeInfo(dateTimeInfo.StartPosition + dateTimeInfo.Length));
		}
		else
		{
			Select(dateTimeInfo);
		}
	}

	protected override void InitializeDateTimeInfoList(TimeSpan? value)
	{
		DateTimeInfo dateTimeInfo = _dateTimeInfoList.FirstOrDefault((DateTimeInfo x) => x.Type == DateTimePart.Day);
		bool flag = dateTimeInfo != null;
		DateTimeInfo dateTimeInfo2 = _dateTimeInfoList.FirstOrDefault((DateTimeInfo x) => x.Type == DateTimePart.Hour12 || x.Type == DateTimePart.Hour24);
		bool flag2 = dateTimeInfo2 != null;
		DateTimeInfo dateTimeInfo3 = _dateTimeInfoList.FirstOrDefault((DateTimeInfo x) => x.Type == DateTimePart.Other);
		bool flag3 = dateTimeInfo3 != null && dateTimeInfo3.Content == "-";
		_dateTimeInfoList.Clear();
		if (value.HasValue && value.Value.TotalMilliseconds < 0.0)
		{
			_dateTimeInfoList.Add(new DateTimeInfo
			{
				Type = DateTimePart.Other,
				Length = 1,
				Content = "-",
				IsReadOnly = true
			});
			if (!flag3 && base.TextBox != null)
			{
				_fireSelectionChangedEvent = false;
				base.TextBox.SelectionStart++;
				_fireSelectionChangedEvent = true;
			}
		}
		if (!ShowHours && ShowDays)
		{
			throw new NotSupportedException("Cannot show days when show hours is set to false.");
		}
		if (ShowDays)
		{
			if (value.HasValue)
			{
				int length = Math.Abs(value.Value.Days).ToString("00").Length;
				_dateTimeInfoList.Add(new DateTimeInfo
				{
					Type = DateTimePart.Day,
					Length = Math.Max(2, length),
					Format = "dd"
				});
				_dateTimeInfoList.Add(new DateTimeInfo
				{
					Type = DateTimePart.Other,
					Length = 1,
					Content = ".",
					IsReadOnly = true
				});
				if (base.TextBox != null)
				{
					if (flag && length != dateTimeInfo.Length && _selectedDateTimeInfo.Type != DateTimePart.Day)
					{
						_fireSelectionChangedEvent = false;
						base.TextBox.SelectionStart = Math.Max(0, base.TextBox.SelectionStart + (length - dateTimeInfo.Length));
						_fireSelectionChangedEvent = true;
					}
					else if (!flag)
					{
						_fireSelectionChangedEvent = false;
						base.TextBox.SelectionStart += length + 1;
						_fireSelectionChangedEvent = true;
					}
				}
			}
			else if (flag)
			{
				_fireSelectionChangedEvent = false;
				base.TextBox.SelectionStart = Math.Max(flag3 ? 1 : 0, base.TextBox.SelectionStart - (dateTimeInfo.Length + 1));
				_fireSelectionChangedEvent = true;
			}
		}
		if (ShowHours)
		{
			if (value.HasValue)
			{
				int length2 = Math.Abs(value.Value.Hours).ToString("00").Length;
				_dateTimeInfoList.Add(new DateTimeInfo
				{
					Type = DateTimePart.Hour24,
					Length = Math.Max(2, length2),
					Format = "hh"
				});
				_dateTimeInfoList.Add(new DateTimeInfo
				{
					Type = DateTimePart.Other,
					Length = 1,
					Content = ":",
					IsReadOnly = true
				});
				if (base.TextBox != null)
				{
					if (flag2 && length2 != dateTimeInfo2.Length && _selectedDateTimeInfo.Type != DateTimePart.Hour24)
					{
						_fireSelectionChangedEvent = false;
						base.TextBox.SelectionStart = Math.Max(0, base.TextBox.SelectionStart + (length2 - dateTimeInfo2.Length));
						_fireSelectionChangedEvent = true;
					}
					else if (!flag2)
					{
						_fireSelectionChangedEvent = false;
						base.TextBox.SelectionStart += length2 + 1;
						_fireSelectionChangedEvent = true;
					}
				}
			}
			else if (flag2)
			{
				_fireSelectionChangedEvent = false;
				base.TextBox.SelectionStart = Math.Max(flag3 ? 1 : 0, base.TextBox.SelectionStart - (dateTimeInfo2.Length + 1));
				_fireSelectionChangedEvent = true;
			}
		}
		_dateTimeInfoList.Add(new DateTimeInfo
		{
			Type = DateTimePart.Minute,
			Length = 2,
			Format = "mm"
		});
		if (ShowSeconds)
		{
			_dateTimeInfoList.Add(new DateTimeInfo
			{
				Type = DateTimePart.Other,
				Length = 1,
				Content = ":",
				IsReadOnly = true
			});
			_dateTimeInfoList.Add(new DateTimeInfo
			{
				Type = DateTimePart.Second,
				Length = 2,
				Format = "ss"
			});
		}
		if (FractionalSecondsDigitsCount > 0)
		{
			_dateTimeInfoList.Add(new DateTimeInfo
			{
				Type = DateTimePart.Other,
				Length = 1,
				Content = ".",
				IsReadOnly = true
			});
			string text = new string('f', FractionalSecondsDigitsCount);
			if (text.Length == 1)
			{
				text = "%" + text;
			}
			_dateTimeInfoList.Add(new DateTimeInfo
			{
				Type = DateTimePart.Millisecond,
				Length = FractionalSecondsDigitsCount,
				Format = text
			});
		}
		if (value.HasValue)
		{
			ParseValueIntoTimeSpanInfo(value, modifyInfo: true);
		}
	}

	protected override bool IsLowerThan(TimeSpan? value1, TimeSpan? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return value1.Value < value2.Value;
	}

	protected override bool IsGreaterThan(TimeSpan? value1, TimeSpan? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return value1.Value > value2.Value;
	}

	protected override object OnCurrentDateTimePartCoerce(object baseValue)
	{
		if (baseValue is DateTimePart dateTimePart)
		{
			switch (dateTimePart)
			{
			case DateTimePart.Month:
			case DateTimePart.MonthName:
			case DateTimePart.Other:
			case DateTimePart.Period:
			case DateTimePart.TimeZone:
			case DateTimePart.Year:
				OnCurrentDateTimePartChanged(dateTimePart, DateTimePart.Day);
				return DateTimePart.Day;
			case DateTimePart.AmPmDesignator:
			case DateTimePart.Hour12:
				OnCurrentDateTimePartChanged(dateTimePart, DateTimePart.Hour24);
				return DateTimePart.Hour24;
			default:
				return baseValue;
			}
		}
		return baseValue;
	}

	internal override void Select(DateTimeInfo info)
	{
		if (base.UpdateValueOnEnterKey)
		{
			if (info == null || info.Equals(_selectedDateTimeInfo) || base.TextBox == null || string.IsNullOrEmpty(base.TextBox.Text))
			{
				return;
			}
			int num = _dateTimeInfoList.IndexOf(info) / 2;
			if (num < 0)
			{
				base.Select(info);
				return;
			}
			string[] array = base.Text.Split(':', '.');
			int num2 = array.Take(num).Sum((string x) => x.Length) + num;
			int num3 = array[num].Length;
			if (num == 0 && array.First().StartsWith("-"))
			{
				num2++;
				num3--;
			}
			_fireSelectionChangedEvent = false;
			base.TextBox.Select(num2, num3);
			_fireSelectionChangedEvent = true;
			_selectedDateTimeInfo = info;
			((DependencyObject)this).SetCurrentValue(DateTimeUpDownBase<TimeSpan?>.CurrentDateTimePartProperty, (object)info.Type);
		}
		else
		{
			base.Select(info);
		}
	}

	private string ParseValueIntoTimeSpanInfo(TimeSpan? value, bool modifyInfo)
	{
		string text = string.Empty;
		_dateTimeInfoList.ForEach(delegate(DateTimeInfo info)
		{
			if (info.Format == null)
			{
				if (modifyInfo)
				{
					info.StartPosition = text.Length;
					info.Length = info.Content.Length;
				}
				text += info.Content;
			}
			else
			{
				TimeSpan timeSpan = TimeSpan.Parse(value.ToString());
				if (modifyInfo)
				{
					info.StartPosition = text.Length;
				}
				string text2 = "";
				text2 = ((!ShowDays && timeSpan.Days != 0 && info.Format == "hh") ? Math.Truncate(Math.Abs(timeSpan.TotalHours)).ToString() : timeSpan.ToString(info.Format, base.CultureInfo.DateTimeFormat));
				if (modifyInfo)
				{
					if (info.Format == "dd")
					{
						text2 = Convert.ToInt32(text2).ToString("00");
					}
					info.Content = text2;
					info.Length = info.Content.Length;
				}
				text += text2;
			}
		});
		return text;
	}

	private TimeSpan? UpdateTimeSpan(TimeSpan? currentValue, int value)
	{
		DateTimeInfo dateTimeInfo = _selectedDateTimeInfo;
		if (dateTimeInfo == null)
		{
			dateTimeInfo = ((base.CurrentDateTimePart != DateTimePart.Other) ? GetDateTimeInfo(base.CurrentDateTimePart) : ((_dateTimeInfoList[0].Content != "-") ? _dateTimeInfoList[0] : _dateTimeInfoList[1]));
			if (dateTimeInfo == null)
			{
				dateTimeInfo = _dateTimeInfoList[0];
			}
		}
		TimeSpan? timeSpan = null;
		try
		{
			switch (dateTimeInfo.Type)
			{
			case DateTimePart.Day:
				timeSpan = currentValue.Value.Add(new TimeSpan(value, 0, 0, 0, 0));
				break;
			case DateTimePart.Hour24:
				timeSpan = currentValue.Value.Add(new TimeSpan(0, value, 0, 0, 0));
				break;
			case DateTimePart.Minute:
				timeSpan = currentValue.Value.Add(new TimeSpan(0, 0, value, 0, 0));
				break;
			case DateTimePart.Second:
				timeSpan = currentValue.Value.Add(new TimeSpan(0, 0, 0, value, 0));
				break;
			case DateTimePart.Millisecond:
				value = FractionalSecondsDigitsCount switch
				{
					1 => value * 100, 
					2 => value * 10, 
					_ => value, 
				};
				timeSpan = currentValue.Value.Add(new TimeSpan(0, 0, 0, 0, value));
				break;
			}
		}
		catch
		{
		}
		timeSpan = ((timeSpan.HasValue && timeSpan.HasValue) ? new TimeSpan?(timeSpan.Value) : timeSpan);
		return CoerceValueMinMax(timeSpan);
	}

	private void Increment(int step)
	{
		if (base.UpdateValueOnEnterKey)
		{
			string text = string.Empty;
			TimeSpan? currentValue = ConvertTextToValue(base.TextBox.Text);
			TimeSpan? timeSpan = (currentValue.HasValue ? UpdateTimeSpan(currentValue, step) : new TimeSpan?(base.DefaultValue ?? TimeSpan.Zero));
			if (!timeSpan.HasValue || _dateTimeInfoList == null)
			{
				return;
			}
			int num = 0;
			int length = 0;
			if (timeSpan.Value.TotalMilliseconds < 0.0 && _dateTimeInfoList[0].Content != "-")
			{
				text = "-";
			}
			for (int i = 0; i < _dateTimeInfoList.Count; i++)
			{
				DateTimeInfo dateTimeInfo = _dateTimeInfoList[i];
				int count = ((dateTimeInfo.Content != null) ? dateTimeInfo.Content.Length : dateTimeInfo.Length);
				if (_selectedDateTimeInfo != null && dateTimeInfo.Type == _selectedDateTimeInfo.Type)
				{
					num = text.Length;
				}
				switch (dateTimeInfo.Type)
				{
				case DateTimePart.Day:
				{
					string text6 = Math.Abs(timeSpan.Value.Days).ToString(new string('0', count));
					dateTimeInfo.StartPosition = text.Length;
					dateTimeInfo.Length = text6.Length;
					text += text6;
					break;
				}
				case DateTimePart.Hour24:
				{
					string text3 = ((i <= 1) ? Math.Truncate(Math.Abs(timeSpan.Value.TotalHours)).ToString(new string('0', count)) : Math.Abs(timeSpan.Value.Hours).ToString(new string('0', count)));
					dateTimeInfo.StartPosition = text.Length;
					dateTimeInfo.Length = text3.Length;
					text += text3;
					break;
				}
				case DateTimePart.Minute:
				{
					string text5 = ((i <= 1) ? Math.Truncate(Math.Abs(timeSpan.Value.TotalMinutes)).ToString(new string('0', count)) : Math.Abs(timeSpan.Value.Minutes).ToString(new string('0', count)));
					dateTimeInfo.StartPosition = text.Length;
					dateTimeInfo.Length = text5.Length;
					text += text5;
					break;
				}
				case DateTimePart.Second:
				{
					string text4 = ((i <= 1) ? Math.Truncate(Math.Abs(timeSpan.Value.TotalSeconds)).ToString(new string('0', count)) : Math.Abs(timeSpan.Value.Seconds).ToString(new string('0', count)));
					dateTimeInfo.StartPosition = text.Length;
					dateTimeInfo.Length = text4.Length;
					text += text4;
					break;
				}
				case DateTimePart.Millisecond:
				{
					string text7 = ((i <= 1) ? Math.Truncate(Math.Abs(timeSpan.Value.TotalMilliseconds)).ToString(new string('0', count)) : Math.Abs(timeSpan.Value.Milliseconds).ToString(new string('0', count)));
					dateTimeInfo.StartPosition = text.Length;
					dateTimeInfo.Length = text7.Length;
					text += text7;
					break;
				}
				case DateTimePart.Other:
				{
					string text2 = ((i == 0 && timeSpan.Value.TotalMilliseconds >= 0.0) ? "" : dateTimeInfo.Content);
					dateTimeInfo.StartPosition = text.Length;
					dateTimeInfo.Length = text2.Length;
					text += text2;
					break;
				}
				}
				if (_selectedDateTimeInfo != null && dateTimeInfo.Type == _selectedDateTimeInfo.Type)
				{
					length = text.Length - num;
				}
			}
			base.TextBox.Text = text;
			base.TextBox.Select(num, length);
		}
		else if (base.Value.HasValue)
		{
			TimeSpan? value = UpdateTimeSpan(base.Value, step);
			if (!value.HasValue)
			{
				return;
			}
			int start = 0;
			int length2 = 0;
			InitializeDateTimeInfoList(value);
			if (_selectedDateTimeInfo == null && base.CurrentDateTimePart != DateTimePart.Other)
			{
				DateTimeInfo dateTimeInfo2 = GetDateTimeInfo(base.CurrentDateTimePart);
				if (dateTimeInfo2 != null)
				{
					start = dateTimeInfo2.StartPosition;
					length2 = dateTimeInfo2.Length;
				}
			}
			else
			{
				start = base.TextBox.SelectionStart;
				length2 = base.TextBox.SelectionLength;
			}
			base.Value = value;
			base.TextBox.Select(start, length2);
		}
		else
		{
			base.Value = base.DefaultValue ?? TimeSpan.Zero;
		}
	}

	private bool IsNumber(string str)
	{
		for (int i = 0; i < str.Length; i++)
		{
			if (!char.IsNumber(str[i]))
			{
				return false;
			}
		}
		return true;
	}

	private void UpdateValue()
	{
		TimeSpan? value = ((!base.UpdateValueOnEnterKey) ? base.Value : ((base.TextBox != null) ? ConvertTextToValue(base.TextBox.Text) : ((TimeSpan?)null)));
		InitializeDateTimeInfoList(value);
		SyncTextAndValueProperties(updateValueFromText: false, base.Text);
	}

	private TimeSpan? ResetToLastValidValue()
	{
		InitializeDateTimeInfoList(base.Value);
		return base.Value;
	}

	private void OnPasting(object sender, DataObjectPastingEventArgs e)
	{
		if (e.DataObject.GetDataPresent(typeof(string)) && !TimeSpan.TryParse(e.DataObject.GetData(typeof(string)) as string, out var _))
		{
			e.CancelCommand();
		}
	}
}
