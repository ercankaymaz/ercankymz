using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Input;

namespace Xceed.Wpf.Toolkit.Primitives;

[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
[TemplatePart(Name = "PART_Spinner", Type = typeof(Spinner))]
public abstract class UpDownBase<T> : InputBase, IValidateInput
{
	internal const string PART_TextBox = "PART_TextBox";

	internal const string PART_Spinner = "PART_Spinner";

	internal bool _isTextChangedFromUI;

	private bool _isSyncingTextAndValueProperties;

	private bool _internalValueSet;

	public static readonly DependencyProperty AllowSpinProperty = DependencyProperty.Register("AllowSpin", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));

	public static readonly DependencyProperty ButtonSpinnerHeightProperty = DependencyProperty.Register("ButtonSpinnerHeight", typeof(double), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)double.NaN));

	public static readonly DependencyProperty ButtonSpinnerLocationProperty = DependencyProperty.Register("ButtonSpinnerLocation", typeof(Location), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)Location.Right));

	public static readonly DependencyProperty ButtonSpinnerDownContentTemplateProperty = DependencyProperty.Register("ButtonSpinnerDownContentTemplate", typeof(DataTemplate), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty ButtonSpinnerDownDisabledContentTemplateProperty = DependencyProperty.Register("ButtonSpinnerDownDisabledContentTemplate", typeof(DataTemplate), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty ButtonSpinnerUpContentTemplateProperty = DependencyProperty.Register("ButtonSpinnerUpContentTemplate", typeof(DataTemplate), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty ButtonSpinnerUpDisabledContentTemplateProperty = DependencyProperty.Register("ButtonSpinnerUpDisabledContentTemplate", typeof(DataTemplate), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty ButtonSpinnerWidthProperty = DependencyProperty.Register("ButtonSpinnerWidth", typeof(double), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)SystemParameters.VerticalScrollBarWidth));

	public static readonly DependencyProperty ClipValueToMinMaxProperty = DependencyProperty.Register("ClipValueToMinMax", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty DisplayDefaultValueOnEmptyTextProperty = DependencyProperty.Register("DisplayDefaultValueOnEmptyText", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnDisplayDefaultValueOnEmptyTextChanged)));

	public static readonly DependencyProperty DefaultValueProperty = DependencyProperty.Register("DefaultValue", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(default(T), new PropertyChangedCallback(OnDefaultValueChanged)));

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(default(T), new PropertyChangedCallback(OnMaximumChanged), new CoerceValueCallback(OnCoerceMaximum)));

	public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(default(T), new PropertyChangedCallback(OnMinimumChanged), new CoerceValueCallback(OnCoerceMinimum)));

	public static readonly DependencyProperty MouseWheelActiveTriggerProperty = DependencyProperty.Register("MouseWheelActiveTrigger", typeof(MouseWheelActiveTrigger), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)MouseWheelActiveTrigger.FocusedMouseOver));

	[Obsolete("Use MouseWheelActiveTrigger property instead")]
	public static readonly DependencyProperty MouseWheelActiveOnFocusProperty = DependencyProperty.Register("MouseWheelActiveOnFocus", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnMouseWheelActiveOnFocusChanged)));

	public static readonly DependencyProperty ShowButtonSpinnerProperty = DependencyProperty.Register("ShowButtonSpinner", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));

	public static readonly DependencyProperty UpdateValueOnEnterKeyProperty = DependencyProperty.Register("UpdateValueOnEnterKey", typeof(bool), typeof(UpDownBase<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnUpdateValueOnEnterKeyChanged)));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(T), typeof(UpDownBase<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(default(T), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnValueChanged), new CoerceValueCallback(OnCoerceValue), isAnimationProhibited: false, UpdateSourceTrigger.PropertyChanged));

	protected Spinner Spinner { get; private set; }

	protected TextBox TextBox { get; private set; }

	public bool AllowSpin
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowSpinProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowSpinProperty, (object)value);
		}
	}

	public double ButtonSpinnerHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ButtonSpinnerHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerHeightProperty, (object)value);
		}
	}

	public Location ButtonSpinnerLocation
	{
		get
		{
			return (Location)((DependencyObject)this).GetValue(ButtonSpinnerLocationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerLocationProperty, (object)value);
		}
	}

	public DataTemplate ButtonSpinnerDownContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(ButtonSpinnerDownContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerDownContentTemplateProperty, (object)value);
		}
	}

	public DataTemplate ButtonSpinnerDownDisabledContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(ButtonSpinnerDownDisabledContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerDownDisabledContentTemplateProperty, (object)value);
		}
	}

	public DataTemplate ButtonSpinnerUpContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(ButtonSpinnerUpContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerUpContentTemplateProperty, (object)value);
		}
	}

	public DataTemplate ButtonSpinnerUpDisabledContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(ButtonSpinnerUpDisabledContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerUpDisabledContentTemplateProperty, (object)value);
		}
	}

	public double ButtonSpinnerWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ButtonSpinnerWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerWidthProperty, (object)value);
		}
	}

	public bool ClipValueToMinMax
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClipValueToMinMaxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClipValueToMinMaxProperty, (object)value);
		}
	}

	public bool DisplayDefaultValueOnEmptyText
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayDefaultValueOnEmptyTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayDefaultValueOnEmptyTextProperty, (object)value);
		}
	}

	public T DefaultValue
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(DefaultValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultValueProperty, (object)value);
		}
	}

	public T Maximum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public T Minimum
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public MouseWheelActiveTrigger MouseWheelActiveTrigger
	{
		get
		{
			return (MouseWheelActiveTrigger)((DependencyObject)this).GetValue(MouseWheelActiveTriggerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseWheelActiveTriggerProperty, (object)value);
		}
	}

	[Obsolete("Use MouseWheelActiveTrigger property instead")]
	public bool MouseWheelActiveOnFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(MouseWheelActiveOnFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseWheelActiveOnFocusProperty, (object)value);
		}
	}

	public bool ShowButtonSpinner
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowButtonSpinnerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowButtonSpinnerProperty, (object)value);
		}
	}

	public bool UpdateValueOnEnterKey
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UpdateValueOnEnterKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UpdateValueOnEnterKeyProperty, (object)value);
		}
	}

	public T Value
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	public event InputValidationErrorEventHandler InputValidationError;

	public event EventHandler<SpinEventArgs> Spinned;

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

	private static void OnDisplayDefaultValueOnEmptyTextChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
	{
		((UpDownBase<T>)(object)source).OnDisplayDefaultValueOnEmptyTextChanged((bool)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
	}

	private void OnDisplayDefaultValueOnEmptyTextChanged(bool oldValue, bool newValue)
	{
		if (base.IsInitialized && string.IsNullOrEmpty(base.Text))
		{
			SyncTextAndValueProperties(updateValueFromText: false, base.Text);
		}
	}

	private static void OnDefaultValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
	{
		((UpDownBase<T>)(object)source).OnDefaultValueChanged((T)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (T)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
	}

	private void OnDefaultValueChanged(T oldValue, T newValue)
	{
		if (base.IsInitialized && string.IsNullOrEmpty(base.Text))
		{
			SyncTextAndValueProperties(updateValueFromText: true, base.Text);
		}
	}

	private static void OnMaximumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.OnMaximumChanged((T)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (T)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnMaximumChanged(T oldValue, T newValue)
	{
		if (base.IsInitialized)
		{
			SetValidSpinDirection();
		}
	}

	private static object OnCoerceMaximum(DependencyObject d, object baseValue)
	{
		if (d is UpDownBase<T> upDownBase)
		{
			return upDownBase.OnCoerceMaximum((T)baseValue);
		}
		return baseValue;
	}

	protected virtual T OnCoerceMaximum(T baseValue)
	{
		return baseValue;
	}

	private static void OnMinimumChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.OnMinimumChanged((T)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (T)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnMinimumChanged(T oldValue, T newValue)
	{
		if (base.IsInitialized)
		{
			SetValidSpinDirection();
		}
	}

	private static object OnCoerceMinimum(DependencyObject d, object baseValue)
	{
		if (d is UpDownBase<T> upDownBase)
		{
			return upDownBase.OnCoerceMinimum((T)baseValue);
		}
		return baseValue;
	}

	protected virtual T OnCoerceMinimum(T baseValue)
	{
		return baseValue;
	}

	private static void OnMouseWheelActiveOnFocusChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.MouseWheelActiveTrigger = (((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue) ? MouseWheelActiveTrigger.FocusedMouseOver : MouseWheelActiveTrigger.MouseOver);
		}
	}

	private static void OnUpdateValueOnEnterKeyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.OnUpdateValueOnEnterKeyChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnUpdateValueOnEnterKeyChanged(bool oldValue, bool newValue)
	{
	}

	private void SetValueInternal(T value)
	{
		_internalValueSet = true;
		try
		{
			Value = value;
		}
		finally
		{
			_internalValueSet = false;
		}
	}

	private static object OnCoerceValue(DependencyObject o, object basevalue)
	{
		return ((UpDownBase<T>)(object)o).OnCoerceValue(basevalue);
	}

	protected virtual object OnCoerceValue(object newValue)
	{
		return newValue;
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is UpDownBase<T> upDownBase)
		{
			upDownBase.OnValueChanged((T)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (T)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnValueChanged(T oldValue, T newValue)
	{
		if (!_internalValueSet && base.IsInitialized)
		{
			SyncTextAndValueProperties(updateValueFromText: false, null, forceTextUpdate: true);
		}
		SetValidSpinDirection();
		RaiseValueChangedEvent(oldValue, newValue);
	}

	internal UpDownBase()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		AddHandler(Mouse.PreviewMouseDownOutsideCapturedElementEvent, new RoutedEventHandler(HandleClickOutsideOfControlWithMouseCapture), handledEventsToo: true);
		base.IsKeyboardFocusWithinChanged += new DependencyPropertyChangedEventHandler(UpDownBase_IsKeyboardFocusWithinChanged);
	}

	protected override void OnAccessKey(AccessKeyEventArgs e)
	{
		if (TextBox != null)
		{
			TextBox.Focus();
		}
		base.OnAccessKey(e);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (TextBox != null)
		{
			TextBox.TextChanged -= TextBox_TextChanged;
			TextBox.RemoveHandler(Mouse.PreviewMouseDownEvent, new MouseButtonEventHandler(TextBox_PreviewMouseDown));
		}
		TextBox = GetTemplateChild("PART_TextBox") as TextBox;
		if (TextBox != null)
		{
			TextBox.Text = base.Text;
			TextBox.TextChanged += TextBox_TextChanged;
			TextBox.AddHandler(Mouse.PreviewMouseDownEvent, new MouseButtonEventHandler(TextBox_PreviewMouseDown), handledEventsToo: true);
		}
		if (Spinner != null)
		{
			Spinner.Spin -= OnSpinnerSpin;
		}
		Spinner = GetTemplateChild("PART_Spinner") as Spinner;
		if (Spinner != null)
		{
			Spinner.Spin += OnSpinnerSpin;
		}
		SetValidSpinDirection();
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			bool flag = CommitInput();
			e.Handled = !flag;
		}
	}

	protected override void OnTextChanged(string oldValue, string newValue)
	{
		if (!base.IsInitialized)
		{
			return;
		}
		if (UpdateValueOnEnterKey)
		{
			if (!_isTextChangedFromUI)
			{
				SyncTextAndValueProperties(updateValueFromText: true, base.Text);
			}
		}
		else
		{
			SyncTextAndValueProperties(updateValueFromText: true, base.Text);
		}
	}

	protected override void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
	{
		if (base.IsInitialized)
		{
			SyncTextAndValueProperties(updateValueFromText: false, null);
		}
	}

	protected override void OnReadOnlyChanged(bool oldValue, bool newValue)
	{
		SetValidSpinDirection();
	}

	private void TextBox_PreviewMouseDown(object sender, RoutedEventArgs e)
	{
		if (MouseWheelActiveTrigger == MouseWheelActiveTrigger.Focused && Mouse.Captured != Spinner)
		{
			((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)5, (Delegate)(Action)delegate
			{
				Mouse.Capture(Spinner);
			});
		}
	}

	private void HandleClickOutsideOfControlWithMouseCapture(object sender, RoutedEventArgs e)
	{
		if (Mouse.Captured is Spinner)
		{
			Spinner.ReleaseMouseCapture();
		}
	}

	private void OnSpinnerSpin(object sender, SpinEventArgs e)
	{
		if (AllowSpin && !base.IsReadOnly)
		{
			MouseWheelActiveTrigger mouseWheelActiveTrigger = MouseWheelActiveTrigger;
			if ((!e.UsingMouseWheel || mouseWheelActiveTrigger == MouseWheelActiveTrigger.MouseOver) | (TextBox != null && TextBox.IsFocused && mouseWheelActiveTrigger == MouseWheelActiveTrigger.FocusedMouseOver) | (TextBox != null && TextBox.IsFocused && mouseWheelActiveTrigger == MouseWheelActiveTrigger.Focused && Mouse.Captured is Spinner))
			{
				e.Handled = true;
				OnSpin(e);
			}
		}
	}

	protected virtual void OnSpin(SpinEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		this.Spinned?.Invoke(this, e);
		if (e.Direction == SpinDirection.Increase)
		{
			DoIncrement();
		}
		else
		{
			DoDecrement();
		}
	}

	protected virtual void RaiseValueChangedEvent(T oldValue, T newValue)
	{
		RoutedPropertyChangedEventArgs<object> e = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue);
		e.RoutedEvent = ValueChangedEvent;
		RaiseEvent(e);
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		bool flag = ((DependencyObject)this).ReadLocalValue(ValueProperty) == DependencyProperty.UnsetValue && BindingOperations.GetBinding((DependencyObject)(object)this, ValueProperty) == null && object.Equals(Value, ValueProperty.DefaultMetadata.DefaultValue);
		SyncTextAndValueProperties(flag, base.Text, !flag);
	}

	internal void DoDecrement()
	{
		if (Spinner == null || (Spinner.ValidSpinDirection & ValidSpinDirections.Decrease) == ValidSpinDirections.Decrease)
		{
			OnDecrement();
		}
	}

	internal void DoIncrement()
	{
		if (Spinner == null || (Spinner.ValidSpinDirection & ValidSpinDirections.Increase) == ValidSpinDirections.Increase)
		{
			OnIncrement();
		}
	}

	private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (!base.IsKeyboardFocusWithin)
		{
			return;
		}
		try
		{
			_isTextChangedFromUI = true;
			base.Text = ((TextBox)sender).Text;
		}
		finally
		{
			_isTextChangedFromUI = false;
		}
	}

	private void UpDownBase_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (!(bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			CommitInput();
		}
	}

	private void RaiseInputValidationError(Exception e)
	{
		if (this.InputValidationError != null)
		{
			InputValidationErrorEventArgs e2 = new InputValidationErrorEventArgs(e);
			this.InputValidationError(this, e2);
			if (e2.ThrowException)
			{
				throw e2.Exception;
			}
		}
	}

	public virtual bool CommitInput()
	{
		return SyncTextAndValueProperties(updateValueFromText: true, base.Text);
	}

	protected bool SyncTextAndValueProperties(bool updateValueFromText, string text)
	{
		return SyncTextAndValueProperties(updateValueFromText, text, forceTextUpdate: false);
	}

	private bool SyncTextAndValueProperties(bool updateValueFromText, string text, bool forceTextUpdate)
	{
		if (_isSyncingTextAndValueProperties)
		{
			return true;
		}
		_isSyncingTextAndValueProperties = true;
		bool flag = true;
		try
		{
			if (updateValueFromText)
			{
				if (string.IsNullOrEmpty(text))
				{
					SetValueInternal(DefaultValue);
				}
				else
				{
					try
					{
						T val = ConvertTextToValue(text);
						if (!object.Equals(val, Value))
						{
							SetValueInternal(val);
						}
					}
					catch (Exception e)
					{
						flag = false;
						if (!_isTextChangedFromUI)
						{
							RaiseInputValidationError(e);
						}
					}
				}
			}
			if (!_isTextChangedFromUI)
			{
				if (forceTextUpdate || !string.IsNullOrEmpty(base.Text) || !object.Equals(Value, DefaultValue) || DisplayDefaultValueOnEmptyText)
				{
					string text2 = ConvertValueToText();
					if (!object.Equals(base.Text, text2))
					{
						base.Text = text2;
					}
				}
				if (TextBox != null)
				{
					TextBox.Text = base.Text;
				}
			}
			if (_isTextChangedFromUI && !flag)
			{
				if (Spinner != null)
				{
					Spinner.ValidSpinDirection = ValidSpinDirections.None;
				}
			}
			else
			{
				SetValidSpinDirection();
			}
		}
		finally
		{
			_isSyncingTextAndValueProperties = false;
		}
		return flag;
	}

	protected abstract T ConvertTextToValue(string text);

	protected abstract string ConvertValueToText();

	protected abstract void OnIncrement();

	protected abstract void OnDecrement();

	protected abstract void SetValidSpinDirection();
}
