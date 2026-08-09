using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_CalculatorPopup", Type = typeof(Popup))]
[TemplatePart(Name = "PART_Calculator", Type = typeof(Calculator))]
public class CalculatorUpDown : DecimalUpDown
{
	private const string PART_CalculatorPopup = "PART_CalculatorPopup";

	private const string PART_Calculator = "PART_Calculator";

	private Popup _calculatorPopup;

	private Calculator _calculator;

	private decimal? _initialValue;

	public static readonly DependencyProperty DisplayTextProperty;

	public static readonly DependencyProperty DropDownButtonContentProperty;

	public static readonly DependencyProperty DropDownButtonDisabledContentProperty;

	public static readonly DependencyProperty DropDownButtonHeightProperty;

	public static readonly DependencyProperty DropDownButtonWidthProperty;

	public static readonly DependencyProperty EnterClosesCalculatorProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty MemoryProperty;

	public static readonly DependencyProperty PrecisionProperty;

	public string DisplayText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DisplayTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayTextProperty, (object)value);
		}
	}

	public object DropDownButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonContentProperty, value);
		}
	}

	public object DropDownButtonDisabledContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownButtonDisabledContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonDisabledContentProperty, value);
		}
	}

	public double DropDownButtonHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DropDownButtonHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonHeightProperty, (object)value);
		}
	}

	public double DropDownButtonWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DropDownButtonWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonWidthProperty, (object)value);
		}
	}

	public bool EnterClosesCalculator
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EnterClosesCalculatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnterClosesCalculatorProperty, (object)value);
		}
	}

	public bool IsOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsOpenProperty, (object)value);
		}
	}

	public decimal Memory
	{
		get
		{
			return (decimal)((DependencyObject)this).GetValue(MemoryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MemoryProperty, (object)value);
		}
	}

	public int Precision
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PrecisionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrecisionProperty, (object)value);
		}
	}

	private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CalculatorUpDown calculatorUpDown)
		{
			calculatorUpDown.OnIsOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialValue = (base.UpdateValueOnEnterKey ? ConvertTextToValue(base.TextBox.Text) : base.Value);
		}
	}

	static CalculatorUpDown()
	{
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(string), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata((object)"0"));
		DropDownButtonContentProperty = DependencyProperty.Register("DropDownButtonContent", typeof(object), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		DropDownButtonDisabledContentProperty = DependencyProperty.Register("DropDownButtonDisabledContent", typeof(object), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		DropDownButtonHeightProperty = DependencyProperty.Register("DropDownButtonHeight", typeof(double), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata((object)double.NaN));
		DropDownButtonWidthProperty = DependencyProperty.Register("DropDownButtonWidth", typeof(double), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata((object)double.NaN));
		EnterClosesCalculatorProperty = DependencyProperty.Register("EnterClosesCalculator", typeof(bool), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsOpenChanged)));
		MemoryProperty = DependencyProperty.Register("Memory", typeof(decimal), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata((object)0m));
		PrecisionProperty = DependencyProperty.Register("Precision", typeof(int), typeof(CalculatorUpDown), (PropertyMetadata)(object)new UIPropertyMetadata((object)6));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CalculatorUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(CalculatorUpDown)));
	}

	public CalculatorUpDown()
	{
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_calculatorPopup != null)
		{
			_calculatorPopup.Opened -= CalculatorPopup_Opened;
		}
		_calculatorPopup = GetTemplateChild("PART_CalculatorPopup") as Popup;
		if (_calculatorPopup != null)
		{
			_calculatorPopup.Opened += CalculatorPopup_Opened;
		}
		if (_calculator != null)
		{
			_calculator.ValueChanged -= OnCalculatorValueChanged;
		}
		_calculator = GetTemplateChild("PART_Calculator") as Calculator;
		if (_calculator != null)
		{
			_calculator.ValueChanged += OnCalculatorValueChanged;
		}
	}

	private void OnCalculatorValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (_calculator != null && IsBetweenMinMax(_calculator.Value))
		{
			if (base.UpdateValueOnEnterKey)
			{
				base.TextBox.Text = (_calculator.Value.HasValue ? _calculator.Value.Value.ToString(base.FormatString, base.CultureInfo) : null);
			}
			else
			{
				base.Value = _calculator.Value;
			}
		}
	}

	private void CalculatorPopup_Opened(object sender, EventArgs e)
	{
		if (_calculator != null)
		{
			decimal? value = (base.UpdateValueOnEnterKey ? ConvertTextToValue(base.TextBox.Text) : base.Value);
			_calculator.InitializeToValue(value);
			_calculator.Focus();
		}
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		if (IsOpen && EnterClosesCalculator && CalculatorUtilities.GetCalculatorButtonTypeFromText(e.Text) == Calculator.CalculatorButtonType.Equal)
		{
			CloseCalculatorUpDown(isFocusOnTextBox: true);
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsOpen = true;
				e.Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e))
		{
			CloseCalculatorUpDown(isFocusOnTextBox: true);
			e.Handled = true;
		}
		else
		{
			if ((int)e.Key != 13)
			{
				return;
			}
			if (EnterClosesCalculator)
			{
				if (base.UpdateValueOnEnterKey)
				{
					base.TextBox.Text = (_initialValue.HasValue ? _initialValue.Value.ToString(base.FormatString, base.CultureInfo) : null);
				}
				else
				{
					base.Value = _initialValue;
				}
			}
			CloseCalculatorUpDown(isFocusOnTextBox: true);
			e.Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseCalculatorUpDown(isFocusOnTextBox: true);
	}

	private void CloseCalculatorUpDown(bool isFocusOnTextBox)
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		ReleaseMouseCapture();
		if (isFocusOnTextBox && base.TextBox != null)
		{
			base.TextBox.Focus();
		}
	}
}
