using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public class DateTimeUpDown : DateTimeUpDownBase<DateTime?>
{
	private DateTime? _lastValidDate;

	private bool _setKindInternal;

	public static readonly DependencyProperty AutoClipTimePartsProperty;

	public static readonly DependencyProperty FormatProperty;

	public static readonly DependencyProperty FormatStringProperty;

	public static readonly DependencyProperty KindProperty;

	public bool AutoClipTimeParts
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoClipTimePartsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoClipTimePartsProperty, (object)value);
		}
	}

	public DateTimeFormat Format
	{
		get
		{
			return (DateTimeFormat)((DependencyObject)this).GetValue(FormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatProperty, (object)value);
		}
	}

	public string FormatString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FormatStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatStringProperty, (object)value);
		}
	}

	public DateTimeKind Kind
	{
		get
		{
			return (DateTimeKind)((DependencyObject)this).GetValue(KindProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KindProperty, (object)value);
		}
	}

	internal DateTime? TempValue { get; set; }

	internal DateTime ContextNow => DateTimeUtilities.GetContextNow(Kind);

	private static void OnFormatChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DateTimeUpDown dateTimeUpDown)
		{
			dateTimeUpDown.OnFormatChanged((DateTimeFormat)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (DateTimeFormat)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnFormatChanged(DateTimeFormat oldValue, DateTimeFormat newValue)
	{
		FormatUpdated();
	}

	internal static bool IsFormatStringValid(object value)
	{
		try
		{
			CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MinSupportedDateTime.ToString((string)value, CultureInfo.CurrentCulture);
		}
		catch
		{
			return false;
		}
		return true;
	}

	private static void OnFormatStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DateTimeUpDown dateTimeUpDown)
		{
			dateTimeUpDown.OnFormatStringChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnFormatStringChanged(string oldValue, string newValue)
	{
		FormatUpdated();
	}

	private static void OnKindChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DateTimeUpDown dateTimeUpDown)
		{
			dateTimeUpDown.OnKindChanged((DateTimeKind)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (DateTimeKind)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnKindChanged(DateTimeKind oldValue, DateTimeKind newValue)
	{
		if (!_setKindInternal && base.Value.HasValue && base.IsInitialized)
		{
			base.Value = ConvertToKind(base.Value.Value, newValue);
		}
	}

	private void SetKindInternal(DateTimeKind kind)
	{
		_setKindInternal = true;
		try
		{
			((DependencyObject)this).SetCurrentValue(KindProperty, (object)kind);
		}
		finally
		{
			_setKindInternal = false;
		}
	}

	static DateTimeUpDown()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		AutoClipTimePartsProperty = DependencyProperty.Register("AutoClipTimeParts", typeof(bool), typeof(DateTimeUpDown), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		FormatProperty = DependencyProperty.Register("Format", typeof(DateTimeFormat), typeof(DateTimeUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(DateTimeFormat.FullDateTime, new PropertyChangedCallback(OnFormatChanged)));
		FormatStringProperty = DependencyProperty.Register("FormatString", typeof(string), typeof(DateTimeUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnFormatStringChanged)), new ValidateValueCallback(IsFormatStringValid));
		KindProperty = DependencyProperty.Register("Kind", typeof(DateTimeKind), typeof(DateTimeUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata(DateTimeKind.Unspecified, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnKindChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimeUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(DateTimeUpDown)));
		UpDownBase<DateTime?>.MaximumProperty.OverrideMetadata(typeof(DateTimeUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MaxSupportedDateTime));
		UpDownBase<DateTime?>.MinimumProperty.OverrideMetadata(typeof(DateTimeUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)CultureInfo.CurrentCulture.DateTimeFormat.Calendar.MinSupportedDateTime));
		UpDownBase<DateTime?>.UpdateValueOnEnterKeyProperty.OverrideMetadata(typeof(DateTimeUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	public DateTimeUpDown()
	{
		base.Loaded += DateTimeUpDown_Loaded;
	}

	public override bool CommitInput()
	{
		bool result = SyncTextAndValueProperties(updateValueFromText: true, base.Text);
		_lastValidDate = base.Value;
		return result;
	}

	protected override void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
	{
		FormatUpdated();
	}

	protected override void OnIncrement()
	{
		if (IsCurrentValueValid())
		{
			Increment(base.Step);
		}
	}

	protected override void OnDecrement()
	{
		if (IsCurrentValueValid())
		{
			Increment(-base.Step);
		}
	}

	protected override void OnTextChanged(string previousValue, string currentValue)
	{
		if (_processTextChanged)
		{
			base.OnTextChanged(previousValue, currentValue);
		}
	}

	protected override DateTime? ConvertTextToValue(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		TryParseDateTime(text, out var result);
		if (Kind != DateTimeKind.Unspecified)
		{
			result = ConvertToKind(result, Kind);
		}
		if (base.ClipValueToMinMax)
		{
			return GetClippedMinMaxValue(result);
		}
		ValidateDefaultMinMax(result);
		return result;
	}

	protected override string ConvertValueToText()
	{
		if (!base.Value.HasValue)
		{
			return string.Empty;
		}
		return base.Value.Value.ToString(GetFormatString(Format), base.CultureInfo);
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

	protected override object OnCoerceValue(object newValue)
	{
		DateTime? dateTime = (DateTime?)base.OnCoerceValue(newValue);
		if (dateTime.HasValue && base.IsInitialized)
		{
			SetKindInternal(dateTime.Value.Kind);
		}
		return dateTime;
	}

	protected override void OnValueChanged(DateTime? oldValue, DateTime? newValue)
	{
		DateTimeInfo dateTimeInfo = _selectedDateTimeInfo;
		if (dateTimeInfo == null)
		{
			dateTimeInfo = ((base.CurrentDateTimePart != DateTimePart.Other) ? GetDateTimeInfo(base.CurrentDateTimePart) : _dateTimeInfoList[0]);
		}
		if (dateTimeInfo == null)
		{
			dateTimeInfo = _dateTimeInfoList[0];
		}
		if (newValue.HasValue)
		{
			ParseValueIntoDateTimeInfo(base.Value);
		}
		base.OnValueChanged(oldValue, newValue);
		if (!_isTextChangedFromUI)
		{
			_lastValidDate = newValue;
		}
		if (base.TextBox != null)
		{
			_fireSelectionChangedEvent = false;
			base.TextBox.Select(dateTimeInfo.StartPosition, dateTimeInfo.Length);
			_fireSelectionChangedEvent = true;
		}
	}

	protected override bool IsCurrentValueValid()
	{
		if (string.IsNullOrEmpty(base.TextBox.Text))
		{
			return true;
		}
		DateTime result;
		return TryParseDateTime(base.TextBox.Text, out result);
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		if (!base.Value.HasValue)
		{
			return;
		}
		DateTimeKind kind = base.Value.Value.Kind;
		if (kind != Kind)
		{
			if (Kind == DateTimeKind.Unspecified)
			{
				SetKindInternal(kind);
			}
			else
			{
				base.Value = ConvertToKind(base.Value.Value, Kind);
			}
		}
	}

	protected override void PerformMouseSelection()
	{
		if (base.UpdateValueOnEnterKey)
		{
			ParseValueIntoDateTimeInfo(ConvertTextToValue(base.TextBox.Text));
		}
		base.PerformMouseSelection();
	}

	protected internal override void PerformKeyboardSelection(int nextSelectionStart)
	{
		if (base.UpdateValueOnEnterKey)
		{
			ParseValueIntoDateTimeInfo(ConvertTextToValue(base.TextBox.Text));
		}
		base.PerformKeyboardSelection(nextSelectionStart);
	}

	protected override void InitializeDateTimeInfoList(DateTime? value)
	{
		_dateTimeInfoList.Clear();
		_selectedDateTimeInfo = null;
		string text = GetFormatString(Format);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		while (text.Length > 0)
		{
			int num = GetElementLengthByFormat(text);
			DateTimeInfo item = null;
			switch (text[0])
			{
			case '"':
			case '\'':
			{
				int num2 = text.IndexOf(text[0], 1);
				item = new DateTimeInfo
				{
					IsReadOnly = true,
					Type = DateTimePart.Other,
					Length = 1,
					Content = text.Substring(1, Math.Max(1, num2 - 1))
				};
				num = Math.Max(1, num2 + 1);
				break;
			}
			case 'D':
			case 'd':
			{
				string text11 = text.Substring(0, num);
				if (num == 1)
				{
					text11 = "%" + text11;
				}
				item = ((num <= 2) ? new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Day,
					Length = num,
					Format = text11
				} : new DateTimeInfo
				{
					IsReadOnly = true,
					Type = DateTimePart.DayName,
					Length = num,
					Format = text11
				});
				break;
			}
			case 'F':
			case 'f':
			{
				string text6 = text.Substring(0, num);
				if (num == 1)
				{
					text6 = "%" + text6;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Millisecond,
					Length = num,
					Format = text6
				};
				break;
			}
			case 'h':
			{
				string text7 = text.Substring(0, num);
				if (num == 1)
				{
					text7 = "%" + text7;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Hour12,
					Length = num,
					Format = text7
				};
				break;
			}
			case 'H':
			{
				string text9 = text.Substring(0, num);
				if (num == 1)
				{
					text9 = "%" + text9;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Hour24,
					Length = num,
					Format = text9
				};
				break;
			}
			case 'M':
			{
				string text4 = text.Substring(0, num);
				if (num == 1)
				{
					text4 = "%" + text4;
				}
				item = ((num < 3) ? new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Month,
					Length = num,
					Format = text4
				} : new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.MonthName,
					Length = num,
					Format = text4
				});
				break;
			}
			case 'S':
			case 's':
			{
				string text10 = text.Substring(0, num);
				if (num == 1)
				{
					text10 = "%" + text10;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Second,
					Length = num,
					Format = text10
				};
				break;
			}
			case 'T':
			case 't':
			{
				string text3 = text.Substring(0, num);
				if (num == 1)
				{
					text3 = "%" + text3;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.AmPmDesignator,
					Length = num,
					Format = text3
				};
				break;
			}
			case 'Y':
			case 'y':
			{
				string text12 = text.Substring(0, num);
				if (num == 1)
				{
					text12 = "%" + text12;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Year,
					Length = num,
					Format = text12
				};
				break;
			}
			case '\\':
				if (text.Length >= 2)
				{
					item = new DateTimeInfo
					{
						IsReadOnly = true,
						Content = text.Substring(1, 1),
						Length = 1,
						Type = DateTimePart.Other
					};
					num = 2;
				}
				break;
			case 'g':
			{
				string text8 = text.Substring(0, num);
				if (num == 1)
				{
					text8 = "%" + text8;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = true,
					Type = DateTimePart.Period,
					Length = num,
					Format = text.Substring(0, num)
				};
				break;
			}
			case 'm':
			{
				string text5 = text.Substring(0, num);
				if (num == 1)
				{
					text5 = "%" + text5;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = false,
					Type = DateTimePart.Minute,
					Length = num,
					Format = text5
				};
				break;
			}
			case 'z':
			{
				string text2 = text.Substring(0, num);
				if (num == 1)
				{
					text2 = "%" + text2;
				}
				item = new DateTimeInfo
				{
					IsReadOnly = true,
					Type = DateTimePart.TimeZone,
					Length = num,
					Format = text2
				};
				break;
			}
			default:
				num = 1;
				item = new DateTimeInfo
				{
					IsReadOnly = true,
					Length = 1,
					Content = text[0].ToString(),
					Type = DateTimePart.Other
				};
				break;
			}
			_dateTimeInfoList.Add(item);
			text = text.Substring(num);
		}
	}

	protected override bool IsLowerThan(DateTime? value1, DateTime? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return value1.Value < value2.Value;
	}

	protected override bool IsGreaterThan(DateTime? value1, DateTime? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return value1.Value > value2.Value;
	}

	protected override void OnUpdateValueOnEnterKeyChanged(bool oldValue, bool newValue)
	{
		throw new NotSupportedException("DateTimeUpDown controls do not support modifying UpdateValueOnEnterKey property.");
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13)
		{
			SyncTextAndValueProperties(updateValueFromText: false, null);
			e.Handled = true;
		}
		base.OnKeyDown(e);
	}

	public void SelectAll()
	{
		_fireSelectionChangedEvent = false;
		base.TextBox.SelectAll();
		_fireSelectionChangedEvent = true;
	}

	private void FormatUpdated()
	{
		InitializeDateTimeInfoList(base.Value);
		if (base.Value.HasValue)
		{
			ParseValueIntoDateTimeInfo(base.Value);
		}
		_processTextChanged = false;
		SyncTextAndValueProperties(updateValueFromText: false, null);
		_processTextChanged = true;
	}

	private static int GetElementLengthByFormat(string format)
	{
		for (int i = 1; i < format.Length; i++)
		{
			if (string.Compare(format[i].ToString(), format[0].ToString(), ignoreCase: false) != 0)
			{
				return i;
			}
		}
		return format.Length;
	}

	private void Increment(int step)
	{
		_fireSelectionChangedEvent = false;
		DateTime? currentDateTime = ConvertTextToValue(base.TextBox.Text);
		if (currentDateTime.HasValue)
		{
			DateTime? dateTime = UpdateDateTime(currentDateTime, step);
			if (!dateTime.HasValue)
			{
				return;
			}
			base.TextBox.Text = dateTime.Value.ToString(GetFormatString(Format), base.CultureInfo);
		}
		else
		{
			base.TextBox.Text = (base.DefaultValue.HasValue ? base.DefaultValue.Value.ToString(GetFormatString(Format), base.CultureInfo) : ContextNow.ToString(GetFormatString(Format), base.CultureInfo));
		}
		if (base.TextBox != null)
		{
			DateTimeInfo dateTimeInfo = _selectedDateTimeInfo;
			if (dateTimeInfo == null)
			{
				dateTimeInfo = ((base.CurrentDateTimePart != DateTimePart.Other) ? GetDateTimeInfo(base.CurrentDateTimePart) : _dateTimeInfoList[0]);
			}
			if (dateTimeInfo == null)
			{
				dateTimeInfo = _dateTimeInfoList[0];
			}
			ParseValueIntoDateTimeInfo(ConvertTextToValue(base.TextBox.Text));
			base.TextBox.Select(dateTimeInfo.StartPosition, dateTimeInfo.Length);
		}
		_fireSelectionChangedEvent = true;
		SyncTextAndValueProperties(updateValueFromText: true, base.Text);
	}

	private void ParseValueIntoDateTimeInfo(DateTime? newDate)
	{
		string text = string.Empty;
		_dateTimeInfoList.ForEach(delegate(DateTimeInfo info)
		{
			if (info.Format == null)
			{
				info.StartPosition = text.Length;
				info.Length = info.Content.Length;
				text += info.Content;
			}
			else if (newDate.HasValue)
			{
				DateTime value = newDate.Value;
				info.StartPosition = text.Length;
				info.Content = value.ToString(info.Format, base.CultureInfo.DateTimeFormat);
				info.Length = info.Content.Length;
				text += info.Content;
			}
		});
	}

	internal string GetFormatString(DateTimeFormat dateTimeFormat)
	{
		return dateTimeFormat switch
		{
			DateTimeFormat.ShortDate => base.CultureInfo.DateTimeFormat.ShortDatePattern, 
			DateTimeFormat.LongDate => base.CultureInfo.DateTimeFormat.LongDatePattern, 
			DateTimeFormat.ShortTime => base.CultureInfo.DateTimeFormat.ShortTimePattern, 
			DateTimeFormat.LongTime => base.CultureInfo.DateTimeFormat.LongTimePattern, 
			DateTimeFormat.FullDateTime => base.CultureInfo.DateTimeFormat.FullDateTimePattern, 
			DateTimeFormat.MonthDay => base.CultureInfo.DateTimeFormat.MonthDayPattern, 
			DateTimeFormat.RFC1123 => base.CultureInfo.DateTimeFormat.RFC1123Pattern, 
			DateTimeFormat.SortableDateTime => base.CultureInfo.DateTimeFormat.SortableDateTimePattern, 
			DateTimeFormat.UniversalSortableDateTime => base.CultureInfo.DateTimeFormat.UniversalSortableDateTimePattern, 
			DateTimeFormat.YearMonth => base.CultureInfo.DateTimeFormat.YearMonthPattern, 
			DateTimeFormat.Custom => FormatString switch
			{
				"d" => base.CultureInfo.DateTimeFormat.ShortDatePattern, 
				"t" => base.CultureInfo.DateTimeFormat.ShortTimePattern, 
				"T" => base.CultureInfo.DateTimeFormat.LongTimePattern, 
				"D" => base.CultureInfo.DateTimeFormat.LongDatePattern, 
				"f" => base.CultureInfo.DateTimeFormat.LongDatePattern + " " + base.CultureInfo.DateTimeFormat.ShortTimePattern, 
				"F" => base.CultureInfo.DateTimeFormat.FullDateTimePattern, 
				"g" => base.CultureInfo.DateTimeFormat.ShortDatePattern + " " + base.CultureInfo.DateTimeFormat.ShortTimePattern, 
				"G" => base.CultureInfo.DateTimeFormat.ShortDatePattern + " " + base.CultureInfo.DateTimeFormat.LongTimePattern, 
				"m" => base.CultureInfo.DateTimeFormat.MonthDayPattern, 
				"y" => base.CultureInfo.DateTimeFormat.YearMonthPattern, 
				"r" => base.CultureInfo.DateTimeFormat.RFC1123Pattern, 
				"s" => base.CultureInfo.DateTimeFormat.SortableDateTimePattern, 
				"u" => base.CultureInfo.DateTimeFormat.UniversalSortableDateTimePattern, 
				_ => FormatString, 
			}, 
			_ => throw new ArgumentException("Not a supported format"), 
		};
	}

	private DateTime? UpdateDateTime(DateTime? currentDateTime, int value)
	{
		DateTimeInfo dateTimeInfo = _selectedDateTimeInfo;
		if (dateTimeInfo == null)
		{
			dateTimeInfo = ((base.CurrentDateTimePart != DateTimePart.Other) ? GetDateTimeInfo(base.CurrentDateTimePart) : _dateTimeInfoList[0]);
		}
		if (dateTimeInfo == null)
		{
			dateTimeInfo = _dateTimeInfoList[0];
		}
		DateTime? value2 = null;
		try
		{
			switch (dateTimeInfo.Type)
			{
			case DateTimePart.Year:
				value2 = currentDateTime.Value.AddYears(value);
				break;
			case DateTimePart.Month:
			case DateTimePart.MonthName:
				value2 = currentDateTime.Value.AddMonths(value);
				break;
			case DateTimePart.Day:
			case DateTimePart.DayName:
				value2 = currentDateTime.Value.AddDays(value);
				break;
			case DateTimePart.Hour12:
			case DateTimePart.Hour24:
				value2 = currentDateTime.Value.AddHours(value);
				break;
			case DateTimePart.Minute:
				value2 = currentDateTime.Value.AddMinutes(value);
				break;
			case DateTimePart.Second:
				value2 = currentDateTime.Value.AddSeconds(value);
				break;
			case DateTimePart.Millisecond:
				value2 = currentDateTime.Value.AddMilliseconds(value);
				break;
			case DateTimePart.AmPmDesignator:
				value2 = currentDateTime.Value.AddHours(value * 12);
				break;
			case DateTimePart.Other:
			case DateTimePart.Period:
			case DateTimePart.TimeZone:
				break;
			}
		}
		catch
		{
		}
		return CoerceValueMinMax(value2);
	}

	protected virtual bool TryParseDateTime(string text, out DateTime result)
	{
		bool flag = false;
		result = ContextNow;
		DateTime dateTime = ContextNow;
		try
		{
			dateTime = (TempValue.HasValue ? TempValue.Value : (base.Value.HasValue ? base.Value.Value : DateTime.Parse(ContextNow.ToString(), base.CultureInfo.DateTimeFormat)));
			flag = DateTimeParser.TryParse(text, GetFormatString(Format), dateTime, base.CultureInfo, AutoClipTimeParts, out result);
		}
		catch (FormatException)
		{
			flag = false;
		}
		if (!flag)
		{
			flag = DateTime.TryParseExact(text, GetFormatString(Format), base.CultureInfo, DateTimeStyles.None, out result);
		}
		if (!flag)
		{
			result = (_lastValidDate.HasValue ? _lastValidDate.Value : dateTime);
		}
		return flag;
	}

	private DateTime ConvertToKind(DateTime dateTime, DateTimeKind kind)
	{
		if (kind == dateTime.Kind)
		{
			return dateTime;
		}
		if (dateTime.Kind != DateTimeKind.Unspecified)
		{
			switch (kind)
			{
			case DateTimeKind.Unspecified:
				break;
			default:
				return dateTime.ToUniversalTime();
			case DateTimeKind.Local:
				return dateTime.ToLocalTime();
			}
		}
		return DateTime.SpecifyKind(dateTime, kind);
	}

	private void DateTimeUpDown_Loaded(object sender, RoutedEventArgs e)
	{
		if (Format == DateTimeFormat.Custom && string.IsNullOrEmpty(FormatString))
		{
			throw new InvalidOperationException("A FormatString is necessary when Format is set to Custom.");
		}
	}
}
