using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_CalculatorButtonPanel", Type = typeof(ContentControl))]
public class Calculator : Control
{
	public enum CalculatorButtonType
	{
		Add,
		Back,
		Cancel,
		Clear,
		Decimal,
		Divide,
		Eight,
		Equal,
		Five,
		Four,
		Fraction,
		MAdd,
		MC,
		MR,
		MS,
		MSub,
		Multiply,
		Negate,
		Nine,
		None,
		One,
		Percent,
		Seven,
		Six,
		Sqrt,
		Subtract,
		Three,
		Two,
		Zero
	}

	public enum Operation
	{
		Add,
		Subtract,
		Divide,
		Multiply,
		Percent,
		Sqrt,
		Fraction,
		None,
		Clear,
		Negate
	}

	private const string PART_CalculatorButtonPanel = "PART_CalculatorButtonPanel";

	private ContentControl _buttonPanel;

	private bool _showNewNumber = true;

	private decimal _previousValue;

	private Operation _lastOperation = Operation.None;

	private readonly Dictionary<Button, DispatcherTimer> _timers = new Dictionary<Button, DispatcherTimer>();

	public static readonly DependencyProperty CalculatorButtonPanelTemplateProperty;

	public static readonly DependencyProperty CalculatorButtonTypeProperty;

	public static readonly DependencyProperty DisplayTextProperty;

	public static readonly DependencyProperty MemoryProperty;

	public static readonly DependencyProperty PrecisionProperty;

	public static readonly DependencyProperty ValueProperty;

	public static readonly RoutedEvent ValueChangedEvent;

	public ControlTemplate CalculatorButtonPanelTemplate
	{
		get
		{
			return (ControlTemplate)((DependencyObject)this).GetValue(CalculatorButtonPanelTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CalculatorButtonPanelTemplateProperty, (object)value);
		}
	}

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

	public decimal? Value
	{
		get
		{
			return (decimal?)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	public event RoutedPropertyChangedEventHandler<object> ValueChanged
	{
		add
		{
			AddHandler(ValueChangedEvent, value);
		}
		remove
		{
			RemoveHandler(ValueChangedEvent, value);
		}
	}

	public static CalculatorButtonType GetCalculatorButtonType(DependencyObject target)
	{
		return (CalculatorButtonType)target.GetValue(CalculatorButtonTypeProperty);
	}

	public static void SetCalculatorButtonType(DependencyObject target, CalculatorButtonType value)
	{
		target.SetValue(CalculatorButtonTypeProperty, (object)value);
	}

	private static void OnCalculatorButtonTypeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		OnCalculatorButtonTypeChanged(o, (CalculatorButtonType)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (CalculatorButtonType)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnCalculatorButtonTypeChanged(DependencyObject o, CalculatorButtonType oldValue, CalculatorButtonType newValue)
	{
		Button button = o as Button;
		button.CommandParameter = newValue;
		if (button.Content == null)
		{
			button.Content = CalculatorUtilities.GetCalculatorButtonContent(newValue);
		}
	}

	private static void OnDisplayTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is Calculator calculator)
		{
			calculator.OnDisplayTextChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnDisplayTextChanged(string oldValue, string newValue)
	{
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is Calculator calculator)
		{
			calculator.OnValueChanged((decimal?)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (decimal?)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnValueChanged(decimal? oldValue, decimal? newValue)
	{
		SetDisplayText(newValue);
		RoutedPropertyChangedEventArgs<object> e = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue);
		e.RoutedEvent = ValueChangedEvent;
		RaiseEvent(e);
	}

	static Calculator()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		CalculatorButtonPanelTemplateProperty = DependencyProperty.Register("CalculatorButtonPanelTemplate", typeof(ControlTemplate), typeof(Calculator), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CalculatorButtonTypeProperty = DependencyProperty.RegisterAttached("CalculatorButtonType", typeof(CalculatorButtonType), typeof(Calculator), (PropertyMetadata)(object)new UIPropertyMetadata(CalculatorButtonType.None, new PropertyChangedCallback(OnCalculatorButtonTypeChanged)));
		DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(string), typeof(Calculator), (PropertyMetadata)(object)new UIPropertyMetadata("0", new PropertyChangedCallback(OnDisplayTextChanged)));
		MemoryProperty = DependencyProperty.Register("Memory", typeof(decimal), typeof(Calculator), (PropertyMetadata)(object)new UIPropertyMetadata((object)0m));
		PrecisionProperty = DependencyProperty.Register("Precision", typeof(int), typeof(Calculator), (PropertyMetadata)(object)new UIPropertyMetadata((object)6));
		ValueProperty = DependencyProperty.Register("Value", typeof(decimal?), typeof(Calculator), (PropertyMetadata)(object)new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnValueChanged)));
		ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(Calculator));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Calculator), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(Calculator)));
	}

	public Calculator()
	{
		base.CommandBindings.Add(new CommandBinding(CalculatorCommands.CalculatorButtonClick, ExecuteCalculatorButtonClick));
		AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(Calculator_OnMouseDown), handledEventsToo: true);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_buttonPanel = GetTemplateChild("PART_CalculatorButtonPanel") as ContentControl;
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		CalculatorButtonType calculatorButtonTypeFromText = CalculatorUtilities.GetCalculatorButtonTypeFromText(e.Text);
		if (calculatorButtonTypeFromText != CalculatorButtonType.None)
		{
			SimulateCalculatorButtonClick(calculatorButtonTypeFromText);
			ProcessCalculatorButton(calculatorButtonTypeFromText);
		}
	}

	private void Calculator_OnMouseDown(object sender, MouseButtonEventArgs e)
	{
		if (!base.IsFocused)
		{
			Focus();
			e.Handled = true;
		}
	}

	private void Timer_Tick(object sender, EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		DispatcherTimer timer = (DispatcherTimer)sender;
		timer.Stop();
		timer.Tick -= Timer_Tick;
		if (_timers.ContainsValue(timer))
		{
			Button button = (from x in _timers
				where x.Value == timer
				select x.Key).FirstOrDefault();
			if (button != null)
			{
				VisualStateManager.GoToState(button, button.IsMouseOver ? "MouseOver" : "Normal", useTransitions: true);
				_timers.Remove(button);
			}
		}
	}

	internal void InitializeToValue(decimal? value)
	{
		_previousValue = default(decimal);
		_lastOperation = Operation.None;
		_showNewNumber = true;
		Value = value;
		SetDisplayText(value);
	}

	private void Calculate()
	{
		if (_lastOperation == Operation.None)
		{
			return;
		}
		try
		{
			Value = decimal.Round(CalculateValue(_lastOperation), Precision);
			SetDisplayText(Value);
		}
		catch
		{
			Value = null;
			DisplayText = "ERROR";
		}
	}

	private void SetDisplayText(decimal? newValue)
	{
		if (newValue.HasValue && newValue.Value != 0m)
		{
			DisplayText = newValue.ToString();
		}
		else
		{
			DisplayText = "0";
		}
	}

	private void Calculate(Operation newOperation)
	{
		if (!_showNewNumber)
		{
			Calculate();
		}
		_lastOperation = newOperation;
	}

	private void Calculate(Operation currentOperation, Operation newOperation)
	{
		_lastOperation = currentOperation;
		Calculate();
		_lastOperation = newOperation;
	}

	private decimal CalculateValue(Operation operation)
	{
		decimal num = default(decimal);
		decimal num2 = CalculatorUtilities.ParseDecimal(DisplayText);
		return operation switch
		{
			Operation.Add => CalculatorUtilities.Add(_previousValue, num2), 
			Operation.Subtract => CalculatorUtilities.Subtract(_previousValue, num2), 
			Operation.Multiply => CalculatorUtilities.Multiply(_previousValue, num2), 
			Operation.Divide => CalculatorUtilities.Divide(_previousValue, num2), 
			Operation.Sqrt => CalculatorUtilities.SquareRoot(num2), 
			Operation.Fraction => CalculatorUtilities.Fraction(num2), 
			Operation.Negate => CalculatorUtilities.Negate(num2), 
			_ => default(decimal), 
		};
	}

	private void ProcessBackKey()
	{
		string displayText;
		if (DisplayText.Length > 1 && (DisplayText.Length != 2 || DisplayText[0] != '-'))
		{
			displayText = DisplayText.Remove(DisplayText.Length - 1, 1);
		}
		else
		{
			displayText = "0";
			_showNewNumber = true;
		}
		DisplayText = displayText;
	}

	private void ProcessCalculatorButton(CalculatorButtonType buttonType)
	{
		if (CalculatorUtilities.IsDigit(buttonType))
		{
			ProcessDigitKey(buttonType);
		}
		else if (CalculatorUtilities.IsMemory(buttonType))
		{
			ProcessMemoryKey(buttonType);
		}
		else
		{
			ProcessOperationKey(buttonType);
		}
	}

	private void ProcessDigitKey(CalculatorButtonType buttonType)
	{
		if (_showNewNumber)
		{
			DisplayText = CalculatorUtilities.GetCalculatorButtonContent(buttonType);
		}
		else
		{
			DisplayText += CalculatorUtilities.GetCalculatorButtonContent(buttonType);
		}
		_showNewNumber = false;
	}

	private void ProcessMemoryKey(CalculatorButtonType buttonType)
	{
		decimal num = CalculatorUtilities.ParseDecimal(DisplayText);
		_showNewNumber = true;
		switch (buttonType)
		{
		case CalculatorButtonType.MAdd:
			Memory += num;
			break;
		case CalculatorButtonType.MC:
			Memory = 0m;
			break;
		case CalculatorButtonType.MR:
			DisplayText = Memory.ToString();
			_showNewNumber = false;
			break;
		case CalculatorButtonType.MS:
			Memory = num;
			break;
		case CalculatorButtonType.MSub:
			Memory -= num;
			break;
		}
	}

	private void ProcessOperationKey(CalculatorButtonType buttonType)
	{
		switch (buttonType)
		{
		case CalculatorButtonType.Add:
			Calculate(Operation.Add);
			break;
		case CalculatorButtonType.Subtract:
			Calculate(Operation.Subtract);
			break;
		case CalculatorButtonType.Multiply:
			Calculate(Operation.Multiply);
			break;
		case CalculatorButtonType.Divide:
			Calculate(Operation.Divide);
			break;
		case CalculatorButtonType.Percent:
			if (_lastOperation != Operation.None)
			{
				decimal secondNumber = CalculatorUtilities.ParseDecimal(DisplayText);
				DisplayText = CalculatorUtilities.Percent(_previousValue, secondNumber).ToString();
			}
			else
			{
				DisplayText = "0";
				_showNewNumber = true;
			}
			return;
		case CalculatorButtonType.Sqrt:
			Calculate(Operation.Sqrt, Operation.None);
			break;
		case CalculatorButtonType.Fraction:
			Calculate(Operation.Fraction, Operation.None);
			break;
		case CalculatorButtonType.Negate:
			Calculate(Operation.Negate, Operation.None);
			break;
		case CalculatorButtonType.Equal:
			Calculate(Operation.None);
			break;
		case CalculatorButtonType.Clear:
			Calculate(Operation.Clear, Operation.None);
			break;
		case CalculatorButtonType.Cancel:
			DisplayText = _previousValue.ToString();
			_lastOperation = Operation.None;
			_showNewNumber = true;
			return;
		case CalculatorButtonType.Back:
			ProcessBackKey();
			return;
		}
		decimal.TryParse(DisplayText, out _previousValue);
		_showNewNumber = true;
	}

	private void SimulateCalculatorButtonClick(CalculatorButtonType buttonType)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		Button button = CalculatorUtilities.FindButtonByCalculatorButtonType((DependencyObject)(object)_buttonPanel, buttonType);
		if (button != null)
		{
			VisualStateManager.GoToState(button, "Pressed", useTransitions: true);
			DispatcherTimer val;
			if (_timers.ContainsKey(button))
			{
				val = _timers[button];
				val.Stop();
			}
			else
			{
				val = new DispatcherTimer();
				val.Interval = TimeSpan.FromMilliseconds(100.0);
				val.Tick += Timer_Tick;
				_timers.Add(button, val);
			}
			val.Start();
		}
	}

	private void ExecuteCalculatorButtonClick(object sender, ExecutedRoutedEventArgs e)
	{
		CalculatorButtonType buttonType = (CalculatorButtonType)e.Parameter;
		ProcessCalculatorButton(buttonType);
	}
}
