using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace Xceed.Wpf.Toolkit.Primitives;

public abstract class DateTimeUpDownBase<T> : UpDownBase<T>
{
	internal List<DateTimeInfo> _dateTimeInfoList = new List<DateTimeInfo>();

	internal DateTimeInfo _selectedDateTimeInfo;

	internal bool _fireSelectionChangedEvent = true;

	internal bool _processTextChanged = true;

	public static readonly DependencyProperty CurrentDateTimePartProperty = DependencyProperty.Register("CurrentDateTimePart", typeof(DateTimePart), typeof(DateTimeUpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(DateTimePart.Other, new PropertyChangedCallback(OnCurrentDateTimePartChanged), new CoerceValueCallback(OnCurrentDateTimePartCoerce)));

	public static readonly DependencyProperty StepProperty = DependencyProperty.Register("Step", typeof(int), typeof(DateTimeUpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(1, new PropertyChangedCallback(OnStepChanged)));

	public DateTimePart CurrentDateTimePart
	{
		get
		{
			return (DateTimePart)((DependencyObject)this).GetValue(CurrentDateTimePartProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentDateTimePartProperty, (object)value);
		}
	}

	public int Step
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(StepProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StepProperty, (object)value);
		}
	}

	private static object OnCurrentDateTimePartCoerce(DependencyObject d, object baseValue)
	{
		if (d is DateTimeUpDownBase<T> dateTimeUpDownBase)
		{
			return dateTimeUpDownBase.OnCurrentDateTimePartCoerce(baseValue);
		}
		return baseValue;
	}

	protected virtual object OnCurrentDateTimePartCoerce(object baseValue)
	{
		return baseValue;
	}

	private static void OnCurrentDateTimePartChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DateTimeUpDownBase<T> dateTimeUpDownBase)
		{
			dateTimeUpDownBase.OnCurrentDateTimePartChanged((DateTimePart)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (DateTimePart)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnCurrentDateTimePartChanged(DateTimePart oldValue, DateTimePart newValue)
	{
		Select(GetDateTimeInfo(newValue));
	}

	private static void OnStepChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DateTimeUpDownBase<T> dateTimeUpDownBase)
		{
			dateTimeUpDownBase.OnStepChanged((int)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnStepChanged(int oldValue, int newValue)
	{
	}

	internal DateTimeUpDownBase()
	{
		InitializeDateTimeInfoList(base.Value);
		base.Loaded += DateTimeUpDownBase_Loaded;
	}

	public override void OnApplyTemplate()
	{
		if (base.TextBox != null)
		{
			base.TextBox.SelectionChanged -= TextBox_SelectionChanged;
		}
		base.OnApplyTemplate();
		if (base.TextBox != null)
		{
			base.TextBox.SelectionChanged += TextBox_SelectionChanged;
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Invalid comparison between Unknown and I4
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		int num = ((_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.StartPosition : 0);
		int num2 = ((_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.Length : 0);
		Key key = e.Key;
		if ((int)key <= 23)
		{
			if ((int)key == 6)
			{
				if (!base.IsReadOnly)
				{
					_fireSelectionChangedEvent = false;
					BindingOperations.GetBindingExpression((DependencyObject)(object)base.TextBox, TextBox.TextProperty).UpdateSource();
					_fireSelectionChangedEvent = true;
				}
				return;
			}
			if ((int)key != 23)
			{
				goto IL_0133;
			}
			if (IsCurrentValueValid())
			{
				PerformKeyboardSelection((num > 0) ? (num - 1) : 0);
				e.Handled = true;
			}
			_fireSelectionChangedEvent = false;
		}
		else if ((int)key != 25)
		{
			if ((int)key != 85)
			{
				if ((int)key != 87)
				{
					goto IL_0133;
				}
				if (base.AllowSpin && !base.AllowTextInput && !base.IsReadOnly)
				{
					DoDecrement();
					e.Handled = true;
				}
				_fireSelectionChangedEvent = false;
			}
			else
			{
				if (base.AllowSpin && !base.AllowTextInput && !base.IsReadOnly)
				{
					DoIncrement();
					e.Handled = true;
				}
				_fireSelectionChangedEvent = false;
			}
		}
		else
		{
			if (IsCurrentValueValid())
			{
				PerformKeyboardSelection(num + num2);
				e.Handled = true;
			}
			_fireSelectionChangedEvent = false;
		}
		goto IL_013a;
		IL_0133:
		_fireSelectionChangedEvent = false;
		goto IL_013a;
		IL_013a:
		base.OnPreviewKeyDown(e);
	}

	private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
	{
		if (_fireSelectionChangedEvent)
		{
			PerformMouseSelection();
		}
		else
		{
			_fireSelectionChangedEvent = true;
		}
	}

	private void DateTimeUpDownBase_Loaded(object sender, RoutedEventArgs e)
	{
		InitSelection();
	}

	protected virtual void InitializeDateTimeInfoList(T value)
	{
	}

	protected virtual bool IsCurrentValueValid()
	{
		return true;
	}

	protected virtual void PerformMouseSelection()
	{
		DateTimeInfo dateTimeInfo = GetDateTimeInfo(base.TextBox.SelectionStart);
		if (dateTimeInfo != null && dateTimeInfo.Type == DateTimePart.Other)
		{
			((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)4, (Delegate)(Action)delegate
			{
				Select(GetDateTimeInfo(dateTimeInfo.StartPosition + dateTimeInfo.Length));
			});
		}
		else
		{
			Select(dateTimeInfo);
		}
	}

	protected virtual bool IsLowerThan(T value1, T value2)
	{
		return false;
	}

	protected virtual bool IsGreaterThan(T value1, T value2)
	{
		return false;
	}

	internal DateTimeInfo GetDateTimeInfo(int selectionStart)
	{
		return _dateTimeInfoList.FirstOrDefault((DateTimeInfo info) => info.StartPosition <= selectionStart && selectionStart < info.StartPosition + info.Length);
	}

	internal DateTimeInfo GetDateTimeInfo(DateTimePart part)
	{
		return _dateTimeInfoList.FirstOrDefault((DateTimeInfo info) => info.Type == part);
	}

	internal virtual void Select(DateTimeInfo info)
	{
		if (info != null && !info.Equals(_selectedDateTimeInfo) && base.TextBox != null && !string.IsNullOrEmpty(base.TextBox.Text))
		{
			_fireSelectionChangedEvent = false;
			base.TextBox.Select(info.StartPosition, info.Length);
			_fireSelectionChangedEvent = true;
			_selectedDateTimeInfo = info;
			((DependencyObject)this).SetCurrentValue(CurrentDateTimePartProperty, (object)info.Type);
		}
	}

	internal T CoerceValueMinMax(T value)
	{
		if (IsLowerThan(value, base.Minimum))
		{
			return base.Minimum;
		}
		if (IsGreaterThan(value, base.Maximum))
		{
			return base.Maximum;
		}
		return value;
	}

	internal void ValidateDefaultMinMax(T value)
	{
		if (!object.Equals(value, base.DefaultValue))
		{
			if (IsLowerThan(value, base.Minimum))
			{
				throw new ArgumentOutOfRangeException("Minimum", $"Value must be greater than MinValue of {base.Minimum}");
			}
			if (IsGreaterThan(value, base.Maximum))
			{
				throw new ArgumentOutOfRangeException("Maximum", $"Value must be less than MaxValue of {base.Maximum}");
			}
		}
	}

	internal T GetClippedMinMaxValue(T value)
	{
		if (IsGreaterThan(value, base.Maximum))
		{
			return base.Maximum;
		}
		if (IsLowerThan(value, base.Minimum))
		{
			return base.Minimum;
		}
		return value;
	}

	protected internal virtual void PerformKeyboardSelection(int nextSelectionStart)
	{
		base.TextBox.Focus();
		if (!base.UpdateValueOnEnterKey)
		{
			CommitInput();
		}
		int num = ((_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.StartPosition : 0);
		if (nextSelectionStart - num > 0)
		{
			Select(GetNextDateTimeInfo(nextSelectionStart));
		}
		else
		{
			Select(GetPreviousDateTimeInfo(nextSelectionStart - 1));
		}
	}

	private DateTimeInfo GetNextDateTimeInfo(int nextSelectionStart)
	{
		DateTimeInfo dateTimeInfo = GetDateTimeInfo(nextSelectionStart);
		if (dateTimeInfo == null)
		{
			dateTimeInfo = _dateTimeInfoList.First();
		}
		DateTimeInfo objB = dateTimeInfo;
		while (dateTimeInfo.Type == DateTimePart.Other)
		{
			dateTimeInfo = GetDateTimeInfo(dateTimeInfo.StartPosition + dateTimeInfo.Length);
			if (dateTimeInfo == null)
			{
				dateTimeInfo = _dateTimeInfoList.First();
			}
			if (object.Equals(dateTimeInfo, objB))
			{
				throw new InvalidOperationException("Couldn't find a valid DateTimeInfo.");
			}
		}
		return dateTimeInfo;
	}

	private DateTimeInfo GetPreviousDateTimeInfo(int previousSelectionStart)
	{
		DateTimeInfo dateTimeInfo = GetDateTimeInfo(previousSelectionStart);
		if (dateTimeInfo == null && _dateTimeInfoList.Count > 0)
		{
			dateTimeInfo = _dateTimeInfoList.Last();
		}
		DateTimeInfo objB = dateTimeInfo;
		while (dateTimeInfo != null && dateTimeInfo.Type == DateTimePart.Other)
		{
			dateTimeInfo = GetDateTimeInfo(dateTimeInfo.StartPosition - 1);
			if (dateTimeInfo == null)
			{
				dateTimeInfo = _dateTimeInfoList.Last();
			}
			if (object.Equals(dateTimeInfo, objB))
			{
				throw new InvalidOperationException("Couldn't find a valid DateTimeInfo.");
			}
		}
		return dateTimeInfo;
	}

	private void InitSelection()
	{
		if (_selectedDateTimeInfo == null)
		{
			Select((CurrentDateTimePart != DateTimePart.Other) ? GetDateTimeInfo(CurrentDateTimePart) : GetDateTimeInfo(0));
		}
	}
}
