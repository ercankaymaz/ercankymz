using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.Obselete;

[Obsolete("Legacy implementation of MaskedTextBox. Use Xceed.Wpf.Toolkit.MaskedTextBox instead.", false)]
public class MaskedTextBox : TextBox
{
	private bool _isSyncingTextAndValueProperties;

	private bool _isInitialized;

	private bool _convertExceptionOccurred;

	public static readonly DependencyProperty IncludePromptProperty;

	public static readonly DependencyProperty IncludeLiteralsProperty;

	public static readonly DependencyProperty MaskProperty;

	public static readonly DependencyProperty PromptCharProperty;

	public static readonly DependencyProperty SelectAllOnGotFocusProperty;

	public static readonly DependencyProperty ValueProperty;

	public static readonly DependencyProperty ValueTypeProperty;

	public static readonly RoutedEvent ValueChangedEvent;

	protected MaskedTextProvider MaskProvider { get; set; }

	public bool IncludePrompt
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludePromptProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludePromptProperty, (object)value);
		}
	}

	public bool IncludeLiterals
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeLiteralsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeLiteralsProperty, (object)value);
		}
	}

	public string Mask
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MaskProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaskProperty, (object)value);
		}
	}

	public char PromptChar
	{
		get
		{
			return (char)((DependencyObject)this).GetValue(PromptCharProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PromptCharProperty, (object)value);
		}
	}

	public bool SelectAllOnGotFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectAllOnGotFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAllOnGotFocusProperty, (object)value);
		}
	}

	public object Value
	{
		get
		{
			return ((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, value);
		}
	}

	public Type ValueType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(ValueTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueTypeProperty, (object)value);
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

	private static void OnIncludePromptPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnIncludePromptChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIncludePromptChanged(bool oldValue, bool newValue)
	{
		UpdateMaskProvider(Mask);
	}

	private static void OnIncludeLiteralsPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnIncludeLiteralsChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIncludeLiteralsChanged(bool oldValue, bool newValue)
	{
		UpdateMaskProvider(Mask);
	}

	private static void OnMaskPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnMaskChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnMaskChanged(string oldValue, string newValue)
	{
		UpdateMaskProvider(newValue);
		UpdateText(0);
	}

	private static void OnPromptCharChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnPromptCharChanged((char)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (char)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnPromptCharChanged(char oldValue, char newValue)
	{
		UpdateMaskProvider(Mask);
	}

	private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnTextChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
		if (_isInitialized)
		{
			SyncTextAndValueProperties(TextBox.TextProperty, newValue);
		}
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnValueChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnValueChanged(object oldValue, object newValue)
	{
		if (_isInitialized)
		{
			SyncTextAndValueProperties(ValueProperty, newValue);
		}
		RoutedPropertyChangedEventArgs<object> e = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue);
		e.RoutedEvent = ValueChangedEvent;
		RaiseEvent(e);
	}

	private static void OnValueTypeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MaskedTextBox maskedTextBox)
		{
			maskedTextBox.OnValueTypeChanged((Type)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Type)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnValueTypeChanged(Type oldValue, Type newValue)
	{
		if (_isInitialized)
		{
			SyncTextAndValueProperties(TextBox.TextProperty, base.Text);
		}
	}

	static MaskedTextBox()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		IncludePromptProperty = DependencyProperty.Register("IncludePrompt", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIncludePromptPropertyChanged)));
		IncludeLiteralsProperty = DependencyProperty.Register("IncludeLiterals", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnIncludeLiteralsPropertyChanged)));
		MaskProperty = DependencyProperty.Register("Mask", typeof(string), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata("<>", new PropertyChangedCallback(OnMaskPropertyChanged)));
		PromptCharProperty = DependencyProperty.Register("PromptChar", typeof(char), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata('_', new PropertyChangedCallback(OnPromptCharChanged)));
		SelectAllOnGotFocusProperty = DependencyProperty.Register("SelectAllOnGotFocus", typeof(bool), typeof(MaskedTextBox), new PropertyMetadata((object)false));
		ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(MaskedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnValueChanged)));
		ValueTypeProperty = DependencyProperty.Register("ValueType", typeof(Type), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(typeof(string), new PropertyChangedCallback(OnValueTypeChanged)));
		ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(MaskedTextBox));
		TextBox.TextProperty.OverrideMetadata(typeof(MaskedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextChanged)));
	}

	public MaskedTextBox()
	{
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, Paste));
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, null, CanCut));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		UpdateMaskProvider(Mask);
		UpdateText(0);
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		if (!_isInitialized)
		{
			_isInitialized = true;
			SyncTextAndValueProperties(ValueProperty, Value);
		}
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		if (SelectAllOnGotFocus)
		{
			SelectAll();
		}
		base.OnGotKeyboardFocus(e);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		if (!e.Handled)
		{
			HandlePreviewKeyDown(e);
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnPreviewTextInput(TextCompositionEventArgs e)
	{
		if (!e.Handled)
		{
			HandlePreviewTextInput(e);
		}
		base.OnPreviewTextInput(e);
	}

	private void UpdateText()
	{
		UpdateText(base.SelectionStart);
	}

	private void UpdateText(int position)
	{
		MaskedTextProvider maskProvider = MaskProvider;
		if (maskProvider == null)
		{
			throw new InvalidOperationException();
		}
		base.Text = maskProvider.ToDisplayString();
		base.SelectionLength = 0;
		base.SelectionStart = position;
	}

	private int GetNextCharacterPosition(int startPosition)
	{
		int num = MaskProvider.FindEditPositionFrom(startPosition, direction: true);
		if (num != -1)
		{
			return num;
		}
		return startPosition;
	}

	private void UpdateMaskProvider(string mask)
	{
		if (!string.IsNullOrEmpty(mask))
		{
			MaskProvider = new MaskedTextProvider(mask)
			{
				IncludePrompt = IncludePrompt,
				IncludeLiterals = IncludeLiterals,
				PromptChar = PromptChar,
				ResetOnSpace = false
			};
		}
	}

	private object ConvertTextToValue(string text)
	{
		object obj = null;
		Type valueType = ValueType;
		string text2 = MaskProvider.ToString().Trim();
		try
		{
			if (text2.GetType() == valueType || valueType.IsInstanceOfType(text2))
			{
				obj = text2;
			}
			else if (string.IsNullOrWhiteSpace(text2))
			{
				obj = Activator.CreateInstance(valueType);
			}
			else if (obj == null && text2 != null)
			{
				obj = Convert.ChangeType(text2, valueType);
			}
		}
		catch
		{
			_convertExceptionOccurred = true;
			return Value;
		}
		return obj;
	}

	private string ConvertValueToText(object value)
	{
		if (value == null)
		{
			value = string.Empty;
		}
		if (_convertExceptionOccurred)
		{
			value = Value;
			_convertExceptionOccurred = false;
		}
		if (MaskProvider == null)
		{
			return value.ToString();
		}
		MaskProvider.Set(value.ToString());
		return MaskProvider.ToDisplayString();
	}

	private void SyncTextAndValueProperties(DependencyProperty p, object newValue)
	{
		if (!_isSyncingTextAndValueProperties)
		{
			_isSyncingTextAndValueProperties = true;
			if (TextBox.TextProperty == p && newValue != null)
			{
				((DependencyObject)this).SetValue(ValueProperty, ConvertTextToValue(newValue.ToString()));
			}
			((DependencyObject)this).SetValue(TextBox.TextProperty, (object)ConvertValueToText(newValue));
			_isSyncingTextAndValueProperties = false;
		}
	}

	private void HandlePreviewTextInput(TextCompositionEventArgs e)
	{
		if (!base.IsReadOnly)
		{
			InsertText(e.Text);
		}
		e.Handled = true;
	}

	private void HandlePreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Invalid comparison between Unknown and I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		if ((int)e.Key == 32)
		{
			e.Handled = base.IsReadOnly || HandleKeyDownDelete();
		}
		else if ((int)e.Key == 2)
		{
			e.Handled = base.IsReadOnly || HandleKeyDownBack();
		}
		else if ((int)e.Key == 18)
		{
			if (!base.IsReadOnly)
			{
				InsertText(" ");
			}
			e.Handled = true;
		}
		else if ((int)e.Key == 6 || (int)e.Key == 6)
		{
			if (!base.IsReadOnly && base.AcceptsReturn)
			{
				InsertText("\r");
			}
			e.Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			e.Handled = true;
		}
		else if ((int)e.Key == 3 && base.AcceptsTab)
		{
			if (!base.IsReadOnly)
			{
				InsertText("\t");
			}
			e.Handled = true;
		}
	}

	private bool HandleKeyDownDelete()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Invalid comparison between Unknown and I4
		ModifierKeys modifiers = Keyboard.Modifiers;
		bool result = true;
		if ((int)modifiers == 0)
		{
			if (!RemoveSelectedText())
			{
				int selectionStart = base.SelectionStart;
				if (selectionStart < base.Text.Length)
				{
					RemoveText(selectionStart, 1);
					UpdateText(selectionStart);
				}
			}
			else
			{
				UpdateText();
			}
		}
		else if ((int)modifiers == 2)
		{
			if (!RemoveSelectedText())
			{
				int selectionStart2 = base.SelectionStart;
				RemoveTextToEnd(selectionStart2);
				UpdateText(selectionStart2);
			}
			else
			{
				UpdateText();
			}
		}
		else if ((int)modifiers == 4)
		{
			if (RemoveSelectedText())
			{
				UpdateText();
			}
			else
			{
				result = false;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private bool HandleKeyDownBack()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		ModifierKeys modifiers = Keyboard.Modifiers;
		bool result = true;
		if ((int)modifiers == 0 || (int)modifiers == 4)
		{
			if (!RemoveSelectedText())
			{
				int selectionStart = base.SelectionStart;
				if (selectionStart > 0)
				{
					int position = selectionStart - 1;
					RemoveText(position, 1);
					UpdateText(position);
				}
			}
			else
			{
				UpdateText();
			}
		}
		else if ((int)modifiers == 2)
		{
			if (!RemoveSelectedText())
			{
				RemoveTextFromStart(base.SelectionStart);
				UpdateText(0);
			}
			else
			{
				UpdateText();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private void InsertText(string text)
	{
		int selectionStart = base.SelectionStart;
		MaskedTextProvider maskProvider = MaskProvider;
		bool num = RemoveSelectedText();
		selectionStart = GetNextCharacterPosition(selectionStart);
		if (!num && Keyboard.IsKeyToggled((Key)31))
		{
			if (maskProvider.Replace(text, selectionStart))
			{
				selectionStart += text.Length;
			}
		}
		else if (maskProvider.InsertAt(text, selectionStart))
		{
			selectionStart += text.Length;
		}
		selectionStart = GetNextCharacterPosition(selectionStart);
		UpdateText(selectionStart);
	}

	private void RemoveTextFromStart(int endPosition)
	{
		RemoveText(0, endPosition);
	}

	private void RemoveTextToEnd(int startPosition)
	{
		RemoveText(startPosition, base.Text.Length - startPosition);
	}

	private void RemoveText(int position, int length)
	{
		if (length != 0)
		{
			MaskProvider.RemoveAt(position, position + length - 1);
		}
	}

	private bool RemoveSelectedText()
	{
		int selectionLength = base.SelectionLength;
		if (selectionLength == 0)
		{
			return false;
		}
		int selectionStart = base.SelectionStart;
		return MaskProvider.RemoveAt(selectionStart, selectionStart + selectionLength - 1);
	}

	private void Paste(object sender, RoutedEventArgs e)
	{
		if (base.IsReadOnly)
		{
			return;
		}
		object data = Clipboard.GetData(DataFormats.Text);
		if (data != null)
		{
			string text = data.ToString().Trim();
			if (text.Length > 0)
			{
				int selectionStart = base.SelectionStart;
				MaskProvider.Set(text);
				UpdateText(selectionStart);
			}
		}
	}

	private void CanCut(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = false;
		e.Handled = true;
	}
}
