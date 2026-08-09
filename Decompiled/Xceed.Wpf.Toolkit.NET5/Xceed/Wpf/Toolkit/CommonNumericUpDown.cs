using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public abstract class CommonNumericUpDown<T> : NumericUpDown<T?> where T : struct, IFormattable, IComparable<T>
{
	protected delegate bool FromText(string s, NumberStyles style, IFormatProvider provider, out T result);

	protected delegate T FromDecimal(decimal d);

	private FromText _fromText;

	private FromDecimal _fromDecimal;

	private Func<T, T, bool> _fromLowerThan;

	private Func<T, T, bool> _fromGreaterThan;

	internal static readonly DependencyProperty IsInvalidProperty = DependencyProperty.Register("IsInvalid", typeof(bool), typeof(CommonNumericUpDown<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty ParsingNumberStyleProperty = DependencyProperty.Register("ParsingNumberStyle", typeof(NumberStyles), typeof(CommonNumericUpDown<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)NumberStyles.Any));

	internal bool IsInvalid
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsInvalidProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(IsInvalidProperty, (object)value);
		}
	}

	public NumberStyles ParsingNumberStyle
	{
		get
		{
			return (NumberStyles)((DependencyObject)this).GetValue(ParsingNumberStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParsingNumberStyleProperty, (object)value);
		}
	}

	protected CommonNumericUpDown(FromText fromText, FromDecimal fromDecimal, Func<T, T, bool> fromLowerThan, Func<T, T, bool> fromGreaterThan)
	{
		if (fromText == null)
		{
			throw new ArgumentNullException("tryParseMethod");
		}
		if (fromDecimal == null)
		{
			throw new ArgumentNullException("fromDecimal");
		}
		if (fromLowerThan == null)
		{
			throw new ArgumentNullException("fromLowerThan");
		}
		if (fromGreaterThan == null)
		{
			throw new ArgumentNullException("fromGreaterThan");
		}
		_fromText = fromText;
		_fromDecimal = fromDecimal;
		_fromLowerThan = fromLowerThan;
		_fromGreaterThan = fromGreaterThan;
	}

	protected static void UpdateMetadata(Type type, T? increment, T? minValue, T? maxValue)
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(type, (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)type));
		UpdateMetadataCommon(type, increment, minValue, maxValue);
	}

	protected void TestInputSpecialValue(AllowedSpecialValues allowedValues, AllowedSpecialValues valueToCompare)
	{
		if ((allowedValues & valueToCompare) != valueToCompare)
		{
			switch (valueToCompare)
			{
			case AllowedSpecialValues.NaN:
				throw new InvalidDataException("Value to parse shouldn't be NaN.");
			case AllowedSpecialValues.PositiveInfinity:
				throw new InvalidDataException("Value to parse shouldn't be Positive Infinity.");
			case AllowedSpecialValues.NegativeInfinity:
				throw new InvalidDataException("Value to parse shouldn't be Negative Infinity.");
			case AllowedSpecialValues.NaN | AllowedSpecialValues.PositiveInfinity:
				break;
			}
		}
	}

	internal bool IsBetweenMinMax(T? value)
	{
		if (!IsLowerThan(value, base.Minimum))
		{
			return !IsGreaterThan(value, base.Maximum);
		}
		return false;
	}

	private static void UpdateMetadataCommon(Type type, T? increment, T? minValue, T? maxValue)
	{
		NumericUpDown<T?>.IncrementProperty.OverrideMetadata(type, (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)increment));
		UpDownBase<T?>.MaximumProperty.OverrideMetadata(type, (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)maxValue));
		UpDownBase<T?>.MinimumProperty.OverrideMetadata(type, (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)minValue));
	}

	private bool IsLowerThan(T? value1, T? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return _fromLowerThan(value1.Value, value2.Value);
	}

	private bool IsGreaterThan(T? value1, T? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return _fromGreaterThan(value1.Value, value2.Value);
	}

	private bool HandleNullSpin()
	{
		if (!(base.UpdateValueOnEnterKey ? ConvertTextToValue(base.TextBox.Text).HasValue : base.Value.HasValue))
		{
			T value = (base.DefaultValue.HasValue ? base.DefaultValue.Value : default(T));
			T? value2 = CoerceValueMinMax(value);
			if (base.UpdateValueOnEnterKey)
			{
				base.TextBox.Text = value2.Value.ToString(base.FormatString, base.CultureInfo);
			}
			else
			{
				base.Value = value2;
			}
			return true;
		}
		if (!base.Increment.HasValue)
		{
			return true;
		}
		return false;
	}

	private T? CoerceValueMinMax(T value)
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

	protected override void OnIncrement()
	{
		if (!HandleNullSpin())
		{
			if (base.UpdateValueOnEnterKey)
			{
				T value = IncrementValue(ConvertTextToValue(base.TextBox.Text).Value, base.Increment.Value);
				T? val = CoerceValueMinMax(value);
				base.TextBox.Text = val.Value.ToString(base.FormatString, base.CultureInfo);
			}
			else
			{
				T value2 = IncrementValue(base.Value.Value, base.Increment.Value);
				base.Value = CoerceValueMinMax(value2);
			}
		}
	}

	protected override void OnDecrement()
	{
		if (!HandleNullSpin())
		{
			if (base.UpdateValueOnEnterKey)
			{
				T value = DecrementValue(ConvertTextToValue(base.TextBox.Text).Value, base.Increment.Value);
				T? val = CoerceValueMinMax(value);
				base.TextBox.Text = val.Value.ToString(base.FormatString, base.CultureInfo);
			}
			else
			{
				T value2 = DecrementValue(base.Value.Value, base.Increment.Value);
				base.Value = CoerceValueMinMax(value2);
			}
		}
	}

	protected override void OnMinimumChanged(T? oldValue, T? newValue)
	{
		base.OnMinimumChanged(oldValue, newValue);
		if (base.Value.HasValue && base.ClipValueToMinMax)
		{
			base.Value = CoerceValueMinMax(base.Value.Value);
		}
	}

	protected override void OnMaximumChanged(T? oldValue, T? newValue)
	{
		base.OnMaximumChanged(oldValue, newValue);
		if (base.Value.HasValue && base.ClipValueToMinMax)
		{
			base.Value = CoerceValueMinMax(base.Value.Value);
		}
	}

	protected override T? ConvertTextToValue(string text)
	{
		T? result = null;
		if (string.IsNullOrEmpty(text))
		{
			return result;
		}
		string text2 = ConvertValueToText();
		if (object.Equals(text2, text))
		{
			IsInvalid = false;
			return base.Value;
		}
		result = ConvertTextToValueCore(text2, text);
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
		IsInvalid = false;
		if (base.FormatString.Contains("{0"))
		{
			return string.Format(base.CultureInfo, base.FormatString, base.Value.Value);
		}
		return base.Value.Value.ToString(base.FormatString, base.CultureInfo);
	}

	protected override void SetValidSpinDirection()
	{
		ValidSpinDirections validSpinDirections = ValidSpinDirections.None;
		if (base.Increment.HasValue && !base.IsReadOnly)
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

	private bool IsPercent(string stringToTest)
	{
		int num = stringToTest.IndexOf("P");
		if (num >= 0)
		{
			return !stringToTest.Substring(0, num).Contains("'") || !stringToTest.Substring(num, base.FormatString.Length - num).Contains("'");
		}
		return false;
	}

	private bool CultureContainsCharacter(char c)
	{
		NumberFormatInfo info = NumberFormatInfo.GetInstance(base.CultureInfo);
		string charString = c.ToString();
		return (from p in info.GetType().GetProperties()
			where p.PropertyType == typeof(string) && (p.Name.Contains("Separator") || p.Name.Contains("NegativeSign"))
			select (string)p.GetValue(info, null)).Any((string value) => !string.IsNullOrEmpty(value) && value == charString);
	}

	private T? ConvertTextToValueCore(string currentValueText, string text)
	{
		T? result;
		if (IsPercent(base.FormatString))
		{
			result = _fromDecimal(NumericUpDown<T?>.ParsePercent(text, base.CultureInfo));
		}
		else
		{
			T result2 = new T();
			if (!_fromText(text, ParsingNumberStyle, base.CultureInfo, out result2))
			{
				bool flag = true;
				if (!_fromText(currentValueText, ParsingNumberStyle, base.CultureInfo, out var _) && currentValueText.Where((char c) => !char.IsDigit(c)).Count() > 0)
				{
					IEnumerable<char> enumerable = text.Where((char c) => !char.IsDigit(c));
					if (decimal.TryParse(new string(text.Where((char c) => char.IsDigit(c) || CultureContainsCharacter(c)).ToArray()), ParsingNumberStyle, base.CultureInfo, out var _))
					{
						foreach (char item in enumerable)
						{
							if (!CultureContainsCharacter(item))
							{
								text = text.Replace(item.ToString(), string.Empty);
							}
						}
					}
					else
					{
						foreach (char item2 in enumerable)
						{
							text = text.Replace(item2.ToString(), string.Empty);
						}
					}
					if (_fromText(text, ParsingNumberStyle, base.CultureInfo, out result2))
					{
						flag = false;
					}
				}
				if (flag)
				{
					IsInvalid = true;
					throw new InvalidDataException("Input string was not in a correct format.");
				}
			}
			result = result2;
		}
		return result;
	}

	private T? GetClippedMinMaxValue(T? result)
	{
		if (IsGreaterThan(result, base.Maximum))
		{
			return base.Maximum;
		}
		if (IsLowerThan(result, base.Minimum))
		{
			return base.Minimum;
		}
		return result;
	}

	private void ValidateDefaultMinMax(T? value)
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

	protected abstract T IncrementValue(T value, T increment);

	protected abstract T DecrementValue(T value, T increment);
}
