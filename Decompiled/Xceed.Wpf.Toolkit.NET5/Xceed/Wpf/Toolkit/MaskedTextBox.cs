using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Media;
using System.Reflection;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public class MaskedTextBox : ValueRangeTextBox
{
	private static readonly char[] MaskChars;

	private static char DefaultPasswordChar;

	private static string NullMaskString;

	public static readonly DependencyProperty AllowPromptAsInputProperty;

	public static readonly DependencyProperty ClipboardMaskFormatProperty;

	public static readonly DependencyProperty HidePromptOnLeaveProperty;

	public static readonly DependencyProperty IncludeLiteralsInValueProperty;

	public static readonly DependencyProperty IncludePromptInValueProperty;

	public static readonly DependencyProperty InsertKeyModeProperty;

	private static readonly DependencyPropertyKey IsMaskCompletedPropertyKey;

	public static readonly DependencyProperty IsMaskCompletedProperty;

	private static readonly DependencyPropertyKey IsMaskFullPropertyKey;

	public static readonly DependencyProperty IsMaskFullProperty;

	public static readonly DependencyProperty MaskProperty;

	public static readonly DependencyProperty PromptCharProperty;

	public static readonly DependencyProperty RejectInputOnFirstFailureProperty;

	public static readonly DependencyProperty ResetOnPromptProperty;

	public static readonly DependencyProperty ResetOnSpaceProperty;

	public static readonly DependencyProperty RestrictToAsciiProperty;

	public static readonly DependencyProperty SkipLiteralsProperty;

	private MaskedTextProvider m_maskedTextProvider;

	private bool m_insertToggled;

	private bool m_maskIsNull = true;

	private bool m_forcingMask;

	private List<int> m_unhandledLiteralsPositions;

	private string m_formatSpecifier;

	private MethodInfo m_valueToStringMethodInfo;

	public bool AllowPromptAsInput
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowPromptAsInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowPromptAsInputProperty, (object)value);
		}
	}

	public MaskFormat ClipboardMaskFormat
	{
		get
		{
			return (MaskFormat)((DependencyObject)this).GetValue(ClipboardMaskFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClipboardMaskFormatProperty, (object)value);
		}
	}

	public bool HidePromptOnLeave
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HidePromptOnLeaveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HidePromptOnLeaveProperty, (object)value);
		}
	}

	public bool IncludeLiteralsInValue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeLiteralsInValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeLiteralsInValueProperty, (object)value);
		}
	}

	public bool IncludePromptInValue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludePromptInValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludePromptInValueProperty, (object)value);
		}
	}

	public InsertKeyMode InsertKeyMode
	{
		get
		{
			return (InsertKeyMode)((DependencyObject)this).GetValue(InsertKeyModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InsertKeyModeProperty, (object)value);
		}
	}

	public bool IsMaskCompleted => (bool)((DependencyObject)this).GetValue(IsMaskCompletedProperty);

	public bool IsMaskFull => (bool)((DependencyObject)this).GetValue(IsMaskFullProperty);

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

	public MaskedTextProvider MaskedTextProvider
	{
		get
		{
			if (!m_maskIsNull)
			{
				return m_maskedTextProvider.Clone() as MaskedTextProvider;
			}
			return null;
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

	public bool RejectInputOnFirstFailure
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RejectInputOnFirstFailureProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RejectInputOnFirstFailureProperty, (object)value);
		}
	}

	public bool ResetOnPrompt
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ResetOnPromptProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResetOnPromptProperty, (object)value);
		}
	}

	public bool ResetOnSpace
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ResetOnSpaceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResetOnSpaceProperty, (object)value);
		}
	}

	public bool RestrictToAscii
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RestrictToAsciiProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RestrictToAsciiProperty, (object)value);
		}
	}

	public bool SkipLiterals
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SkipLiteralsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SkipLiteralsProperty, (object)value);
		}
	}

	internal bool IsForcingMask => m_forcingMask;

	internal string FormatSpecifier
	{
		get
		{
			return m_formatSpecifier;
		}
		set
		{
			m_formatSpecifier = value;
		}
	}

	internal override bool IsTextReadyToBeParsed => IsMaskCompleted;

	private bool IsOverwriteMode
	{
		get
		{
			if (!m_maskIsNull)
			{
				switch (InsertKeyMode)
				{
				case InsertKeyMode.Default:
					return m_insertToggled;
				case InsertKeyMode.Insert:
					return false;
				case InsertKeyMode.Overwrite:
					return true;
				}
			}
			return false;
		}
	}

	private string MaskedTextOutput => m_maskedTextProvider.ToString();

	public event EventHandler<AutoCompletingMaskEventArgs> AutoCompletingMask;

	private static string GetRawText(MaskedTextProvider provider)
	{
		return provider.ToString(ignorePasswordChar: true, includePrompt: false, includeLiterals: false, 0, provider.Length);
	}

	public static string GetFormatSpecifierFromMask(string mask, IFormatProvider formatProvider)
	{
		List<int> unhandledLiteralsPositions;
		return GetFormatSpecifierFromMask(mask, MaskChars, formatProvider, includeNonSeparatorLiteralsInValue: true, out unhandledLiteralsPositions);
	}

	private static string GetFormatSpecifierFromMask(string mask, char[] maskChars, IFormatProvider formatProvider, bool includeNonSeparatorLiteralsInValue, out List<int> unhandledLiteralsPositions)
	{
		unhandledLiteralsPositions = new List<int>();
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
		StringBuilder stringBuilder = new StringBuilder(32);
		bool flag = false;
		int i = 0;
		int num = 0;
		for (; i < mask.Length; i++)
		{
			char c = mask[i];
			if (c == '\\' && !flag)
			{
				flag = true;
				continue;
			}
			if (flag || Array.IndexOf(maskChars, c) < 0)
			{
				flag = false;
				stringBuilder.Append('\\');
				stringBuilder.Append(c);
				if (!includeNonSeparatorLiteralsInValue && c != ' ')
				{
					unhandledLiteralsPositions.Add(num);
				}
				num++;
				continue;
			}
			switch (c)
			{
			case '#':
			case '0':
			case '9':
				stringBuilder.Append('0');
				num++;
				break;
			case '.':
				stringBuilder.Append('.');
				num += instance.NumberDecimalSeparator.Length;
				break;
			case ',':
				stringBuilder.Append(',');
				num += instance.NumberGroupSeparator.Length;
				break;
			case '$':
			{
				string currencySymbol = instance.CurrencySymbol;
				stringBuilder.Append('"');
				stringBuilder.Append(currencySymbol);
				stringBuilder.Append('"');
				for (int j = 0; j < currencySymbol.Length; j++)
				{
					if (!includeNonSeparatorLiteralsInValue)
					{
						unhandledLiteralsPositions.Add(num);
					}
					num++;
				}
				break;
			}
			default:
				stringBuilder.Append(c);
				if (!includeNonSeparatorLiteralsInValue && c != ' ')
				{
					unhandledLiteralsPositions.Add(num);
				}
				num++;
				break;
			}
		}
		return stringBuilder.ToString();
	}

	static MaskedTextBox()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0214: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_025b: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		//IL_0343: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		MaskChars = new char[18]
		{
			'0', '9', '#', 'L', '?', '&', 'C', 'A', 'a', '.',
			',', ':', '/', '$', '<', '>', '|', '\\'
		};
		DefaultPasswordChar = '\0';
		NullMaskString = "<>";
		AllowPromptAsInputProperty = DependencyProperty.Register("AllowPromptAsInput", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(AllowPromptAsInputPropertyChangedCallback)));
		ClipboardMaskFormatProperty = DependencyProperty.Register("ClipboardMaskFormat", typeof(MaskFormat), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)MaskFormat.IncludeLiterals));
		HidePromptOnLeaveProperty = DependencyProperty.Register("HidePromptOnLeave", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		IncludeLiteralsInValueProperty = DependencyProperty.Register("IncludeLiteralsInValue", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(InlcudeLiteralsInValuePropertyChangedCallback)));
		IncludePromptInValueProperty = DependencyProperty.Register("IncludePromptInValue", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(IncludePromptInValuePropertyChangedCallback)));
		InsertKeyModeProperty = DependencyProperty.Register("InsertKeyMode", typeof(InsertKeyMode), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)InsertKeyMode.Default));
		IsMaskCompletedPropertyKey = DependencyProperty.RegisterReadOnly("IsMaskCompleted", typeof(bool), typeof(MaskedTextBox), new PropertyMetadata((object)false));
		IsMaskCompletedProperty = IsMaskCompletedPropertyKey.DependencyProperty;
		IsMaskFullPropertyKey = DependencyProperty.RegisterReadOnly("IsMaskFull", typeof(bool), typeof(MaskedTextBox), new PropertyMetadata((object)false));
		IsMaskFullProperty = IsMaskFullPropertyKey.DependencyProperty;
		MaskProperty = DependencyProperty.Register("Mask", typeof(string), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(string.Empty, new PropertyChangedCallback(MaskPropertyChangedCallback), new CoerceValueCallback(MaskCoerceValueCallback)));
		PromptCharProperty = DependencyProperty.Register("PromptChar", typeof(char), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata('_', new PropertyChangedCallback(PromptCharPropertyChangedCallback), new CoerceValueCallback(PromptCharCoerceValueCallback)));
		RejectInputOnFirstFailureProperty = DependencyProperty.Register("RejectInputOnFirstFailure", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ResetOnPromptProperty = DependencyProperty.Register("ResetOnPrompt", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(ResetOnPromptPropertyChangedCallback)));
		ResetOnSpaceProperty = DependencyProperty.Register("ResetOnSpace", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(ResetOnSpacePropertyChangedCallback)));
		RestrictToAsciiProperty = DependencyProperty.Register("RestrictToAscii", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(RestrictToAsciiPropertyChangedCallback), new CoerceValueCallback(RestrictToAsciiCoerceValueCallback)));
		SkipLiteralsProperty = DependencyProperty.Register("SkipLiterals", typeof(bool), typeof(MaskedTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(SkipLiteralsPropertyChangedCallback)));
		TextBox.TextProperty.OverrideMetadata(typeof(MaskedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new CoerceValueCallback(TextCoerceValueCallback)));
	}

	public MaskedTextBox()
	{
		CommandManager.AddPreviewCanExecuteHandler(this, OnPreviewCanExecuteCommands);
		CommandManager.AddPreviewExecutedHandler(this, OnPreviewExecutedCommands);
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, null, CanExecutePaste));
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, null, CanExecuteCut));
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, null, CanExecuteCopy));
		base.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleInsert, ToggleInsertExecutedCallback));
		base.CommandBindings.Add(new CommandBinding(EditingCommands.Delete, null, CanExecuteDelete));
		base.CommandBindings.Add(new CommandBinding(EditingCommands.DeletePreviousWord, null, CanExecuteDeletePreviousWord));
		base.CommandBindings.Add(new CommandBinding(EditingCommands.DeleteNextWord, null, CanExecuteDeleteNextWord));
		base.CommandBindings.Add(new CommandBinding(EditingCommands.Backspace, null, CanExecuteBackspace));
		DragDrop.AddPreviewQueryContinueDragHandler((DependencyObject)(object)this, PreviewQueryContinueDragCallback);
		base.AllowDrop = false;
	}

	private void InitializeMaskedTextProvider()
	{
		string text = base.Text;
		string mask = Mask;
		if (mask == string.Empty)
		{
			m_maskedTextProvider = CreateMaskedTextProvider(NullMaskString);
			m_maskIsNull = true;
		}
		else
		{
			m_maskedTextProvider = CreateMaskedTextProvider(mask);
			m_maskIsNull = false;
		}
		if (!m_maskIsNull && text != string.Empty && !m_maskedTextProvider.Add(text) && !DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			throw new InvalidOperationException("An attempt was made to apply a new mask that cannot be applied to the current text.");
		}
	}

	protected override void OnInitialized(EventArgs e)
	{
		InitializeMaskedTextProvider();
		SetIsMaskCompleted(m_maskedTextProvider.MaskCompleted);
		SetIsMaskFull(m_maskedTextProvider.MaskFull);
		base.OnInitialized(e);
	}

	private static void AllowPromptAsInputPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(maskedTextBox.Mask);
		}
	}

	private static void InlcudeLiteralsInValuePropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized)
		{
			maskedTextBox.RefreshConversionHelpers();
			maskedTextBox.RefreshValue();
		}
	}

	private static void IncludePromptInValuePropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized)
		{
			maskedTextBox.RefreshValue();
		}
	}

	private void SetIsMaskCompleted(bool value)
	{
		((DependencyObject)this).SetValue(IsMaskCompletedPropertyKey, (object)value);
	}

	private void SetIsMaskFull(bool value)
	{
		((DependencyObject)this).SetValue(IsMaskFullPropertyKey, (object)value);
	}

	private static object MaskCoerceValueCallback(DependencyObject sender, object value)
	{
		if (value == null)
		{
			value = string.Empty;
		}
		if (value.Equals(string.Empty))
		{
			return value;
		}
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!maskedTextBox.IsInitialized)
		{
			return value;
		}
		bool flag;
		try
		{
			MaskedTextProvider maskedTextProvider = maskedTextBox.CreateMaskedTextProvider((string)value);
			string rawText = GetRawText(maskedTextBox.m_maskedTextProvider);
			flag = maskedTextProvider.VerifyString(rawText);
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("An error occured while testing the current text against the new mask.", innerException);
		}
		if (!flag)
		{
			throw new ArgumentException("The mask cannot be applied to the current text.", "Mask");
		}
		return value;
	}

	private static void MaskPropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized)
		{
			MaskedTextProvider maskedTextProvider = null;
			string text = (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			if (text == string.Empty)
			{
				maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(NullMaskString);
				maskedTextBox.m_maskIsNull = true;
				maskedTextBox.Text = "";
			}
			else
			{
				maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(text);
				maskedTextBox.m_maskIsNull = false;
			}
			maskedTextBox.m_maskedTextProvider = maskedTextProvider;
			maskedTextBox.RefreshConversionHelpers();
			if (maskedTextBox.ValueDataType != null)
			{
				string textFromValue = maskedTextBox.GetTextFromValue(maskedTextBox.Value);
				maskedTextBox.m_maskedTextProvider.Set(textFromValue);
			}
			maskedTextBox.RefreshCurrentText(preserveCurrentCaretPosition: true);
		}
	}

	private static object PromptCharCoerceValueCallback(object sender, object value)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!maskedTextBox.IsInitialized)
		{
			return value;
		}
		MaskedTextProvider maskedTextProvider = maskedTextBox.m_maskedTextProvider.Clone() as MaskedTextProvider;
		try
		{
			maskedTextProvider.PromptChar = (char)value;
			return value;
		}
		catch (Exception innerException)
		{
			throw new ArgumentException("The prompt character is invalid.", innerException);
		}
	}

	private static void PromptCharPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.PromptChar = (char)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			maskedTextBox.RefreshCurrentText(preserveCurrentCaretPosition: true);
		}
	}

	private static void ResetOnPromptPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.ResetOnPrompt = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private static void ResetOnSpacePropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.ResetOnSpace = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private static object RestrictToAsciiCoerceValueCallback(object sender, object value)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!maskedTextBox.IsInitialized)
		{
			return value;
		}
		if (maskedTextBox.m_maskIsNull)
		{
			return value;
		}
		bool flag = (bool)value;
		if (!flag)
		{
			return value;
		}
		if (!maskedTextBox.CreateMaskedTextProvider(maskedTextBox.Mask, maskedTextBox.GetCultureInfo(), maskedTextBox.AllowPromptAsInput, maskedTextBox.PromptChar, DefaultPasswordChar, flag).VerifyString(maskedTextBox.Text))
		{
			throw new ArgumentException("The current text cannot be restricted to ASCII characters. The RestrictToAscii property is set to true.", "RestrictToAscii");
		}
		return flag;
	}

	private static void RestrictToAsciiPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider = maskedTextBox.CreateMaskedTextProvider(maskedTextBox.Mask);
			maskedTextBox.RefreshCurrentText(preserveCurrentCaretPosition: true);
		}
	}

	private static void SkipLiteralsPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (maskedTextBox.IsInitialized && !maskedTextBox.m_maskIsNull)
		{
			maskedTextBox.m_maskedTextProvider.SkipLiterals = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private static object TextCoerceValueCallback(DependencyObject sender, object value)
	{
		MaskedTextBox maskedTextBox = sender as MaskedTextBox;
		if (!maskedTextBox.IsInitialized)
		{
			return DependencyProperty.UnsetValue;
		}
		if (maskedTextBox.IsInIMEComposition)
		{
			return value;
		}
		if (value == null)
		{
			value = string.Empty;
		}
		if (maskedTextBox.IsForcingText || maskedTextBox.m_maskIsNull)
		{
			return value;
		}
		return maskedTextBox.ValidateText((string)value);
	}

	private string ValidateText(string text)
	{
		string text2 = text;
		if (RejectInputOnFirstFailure)
		{
			MaskedTextProvider maskedTextProvider = m_maskedTextProvider.Clone() as MaskedTextProvider;
			if (maskedTextProvider.Set(text, out var _, out var _) || maskedTextProvider.Mask.StartsWith(">") || maskedTextProvider.Mask.StartsWith("<"))
			{
				text2 = GetFormattedString(maskedTextProvider, text);
			}
			else
			{
				text2 = GetFormattedString(m_maskedTextProvider, text);
				m_maskedTextProvider.Set(text2);
			}
		}
		else
		{
			MaskedTextProvider provider = (MaskedTextProvider)m_maskedTextProvider.Clone();
			if (CanReplace(provider, text, 0, m_maskedTextProvider.Length, RejectInputOnFirstFailure, out var _))
			{
				text2 = GetFormattedString(provider, text);
			}
			else
			{
				text2 = GetFormattedString(m_maskedTextProvider, text);
				m_maskedTextProvider.Set(text2);
			}
		}
		return text2;
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		if (!m_maskIsNull && (base.IsInValueChanged || !base.IsForcingText))
		{
			string text = base.Text;
			if (m_maskIsNull)
			{
				base.CaretIndex = text.Length;
			}
			else
			{
				m_maskedTextProvider.Set(text);
				if (m_maskedTextProvider.Mask.StartsWith(">") || m_maskedTextProvider.Mask.StartsWith("<"))
				{
					base.CaretIndex = text.Length;
				}
				else
				{
					int num = m_maskedTextProvider.FindUnassignedEditPositionFrom(0, direction: true);
					if (num == -1)
					{
						num = m_maskedTextProvider.Length;
					}
					base.CaretIndex = num;
				}
			}
		}
		if (m_maskedTextProvider != null)
		{
			SetIsMaskCompleted(m_maskedTextProvider.MaskCompleted);
			SetIsMaskFull(m_maskedTextProvider.MaskFull);
		}
		base.OnTextChanged(e);
	}

	private void OnPreviewCanExecuteCommands(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		if (e.Command is RoutedUICommand routedUICommand && (routedUICommand.Name == "Space" || routedUICommand.Name == "ShiftSpace"))
		{
			if (base.IsReadOnly)
			{
				e.CanExecute = false;
			}
			else
			{
				MaskedTextProvider provider = (MaskedTextProvider)m_maskedTextProvider.Clone();
				e.CanExecute = CanReplace(provider, " ", base.SelectionStart, base.SelectionLength, RejectInputOnFirstFailure, out var _);
			}
			e.Handled = true;
		}
		else if (e.Command == ApplicationCommands.Undo || e.Command == ApplicationCommands.Redo)
		{
			e.CanExecute = false;
			e.Handled = true;
		}
	}

	private void OnPreviewExecutedCommands(object sender, ExecutedRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		if (e.Command == EditingCommands.Delete)
		{
			e.Handled = true;
			Delete(base.SelectionStart, base.SelectionLength, deleteForward: true);
		}
		else if (e.Command == EditingCommands.DeleteNextWord)
		{
			e.Handled = true;
			EditingCommands.SelectRightByWord.Execute(null, this);
			Delete(base.SelectionStart, base.SelectionLength, deleteForward: true);
		}
		else if (e.Command == EditingCommands.DeletePreviousWord)
		{
			e.Handled = true;
			EditingCommands.SelectLeftByWord.Execute(null, this);
			Delete(base.SelectionStart, base.SelectionLength, deleteForward: false);
		}
		else if (e.Command == EditingCommands.Backspace)
		{
			e.Handled = true;
			Delete(base.SelectionStart, base.SelectionLength, deleteForward: false);
		}
		else if (e.Command == ApplicationCommands.Cut)
		{
			e.Handled = true;
			if (ApplicationCommands.Copy.CanExecute(null, this))
			{
				ApplicationCommands.Copy.Execute(null, this);
			}
			Delete(base.SelectionStart, base.SelectionLength, deleteForward: true);
		}
		else if (e.Command == ApplicationCommands.Copy)
		{
			e.Handled = true;
			ExecuteCopy();
		}
		else if (e.Command == ApplicationCommands.Paste)
		{
			e.Handled = true;
			string text = (string)Clipboard.GetDataObject().GetData("System.String");
			Replace(text, base.SelectionStart, base.SelectionLength);
		}
		else if (e.Command is RoutedUICommand routedUICommand && (routedUICommand.Name == "Space" || routedUICommand.Name == "ShiftSpace"))
		{
			e.Handled = true;
			ProcessTextInput(" ");
		}
	}

	private void CanExecuteDelete(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.CanExecute = CanDelete(base.SelectionStart, base.SelectionLength, deleteForward: true, MaskedTextProvider.Clone() as MaskedTextProvider);
			e.Handled = true;
			if (!e.CanExecute && base.BeepOnError)
			{
				PlayBeep();
			}
		}
	}

	private void CanExecuteDeletePreviousWord(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		bool flag = !base.IsReadOnly && EditingCommands.SelectLeftByWord.CanExecute(null, this);
		if (flag)
		{
			int selectionStart = base.SelectionStart;
			int selectionLength = base.SelectionLength;
			EditingCommands.SelectLeftByWord.Execute(null, this);
			flag = CanDelete(base.SelectionStart, base.SelectionLength, deleteForward: false, MaskedTextProvider.Clone() as MaskedTextProvider);
			if (!flag)
			{
				base.SelectionStart = selectionStart;
				base.SelectionLength = selectionLength;
			}
		}
		e.CanExecute = flag;
		e.Handled = true;
		if (!e.CanExecute && base.BeepOnError)
		{
			PlayBeep();
		}
	}

	private void CanExecuteDeleteNextWord(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		bool flag = !base.IsReadOnly && EditingCommands.SelectRightByWord.CanExecute(null, this);
		if (flag)
		{
			int selectionStart = base.SelectionStart;
			int selectionLength = base.SelectionLength;
			EditingCommands.SelectRightByWord.Execute(null, this);
			flag = CanDelete(base.SelectionStart, base.SelectionLength, deleteForward: true, MaskedTextProvider.Clone() as MaskedTextProvider);
			if (!flag)
			{
				base.SelectionStart = selectionStart;
				base.SelectionLength = selectionLength;
			}
		}
		e.CanExecute = flag;
		e.Handled = true;
		if (!e.CanExecute && base.BeepOnError)
		{
			PlayBeep();
		}
	}

	private void CanExecuteBackspace(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.CanExecute = CanDelete(base.SelectionStart, base.SelectionLength, deleteForward: false, MaskedTextProvider.Clone() as MaskedTextProvider);
			e.Handled = true;
			if (!e.CanExecute && base.BeepOnError)
			{
				PlayBeep();
			}
		}
	}

	private void CanExecuteCut(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			bool flag = !base.IsReadOnly && base.SelectionLength > 0;
			if (flag)
			{
				int endPosition = ((base.SelectionLength > 0) ? (base.SelectionStart + base.SelectionLength - 1) : base.SelectionStart);
				flag = (m_maskedTextProvider.Clone() as MaskedTextProvider).RemoveAt(base.SelectionStart, endPosition);
			}
			e.CanExecute = flag;
			e.Handled = true;
			if (!flag && base.BeepOnError)
			{
				PlayBeep();
			}
		}
	}

	private void CanExecutePaste(object sender, CanExecuteRoutedEventArgs e)
	{
		if (m_maskIsNull)
		{
			return;
		}
		bool canExecute = false;
		if (!base.IsReadOnly)
		{
			string empty = string.Empty;
			try
			{
				empty = (string)Clipboard.GetDataObject().GetData("System.String");
				if (empty != null)
				{
					MaskedTextProvider provider = (MaskedTextProvider)m_maskedTextProvider.Clone();
					canExecute = CanReplace(provider, empty, base.SelectionStart, base.SelectionLength, RejectInputOnFirstFailure, out var _);
				}
			}
			catch
			{
			}
		}
		e.CanExecute = canExecute;
		e.Handled = true;
		if (!e.CanExecute && base.BeepOnError)
		{
			PlayBeep();
		}
	}

	private void CanExecuteCopy(object sender, CanExecuteRoutedEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.CanExecute = !m_maskedTextProvider.IsPassword;
			e.Handled = true;
			if (!e.CanExecute && base.BeepOnError)
			{
				PlayBeep();
			}
		}
	}

	private void ExecuteCopy()
	{
		string selectedText = GetSelectedText();
		try
		{
			if (selectedText.Length == 0)
			{
				Clipboard.Clear();
			}
			else
			{
				Clipboard.SetText(selectedText);
			}
		}
		catch (SecurityException)
		{
		}
	}

	private void ToggleInsertExecutedCallback(object sender, ExecutedRoutedEventArgs e)
	{
		m_insertToggled = !m_insertToggled;
	}

	private void PreviewQueryContinueDragCallback(object sender, QueryContinueDragEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.Action = DragAction.Cancel;
			e.Handled = true;
		}
	}

	protected override void OnDragEnter(DragEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.Effects = DragDropEffects.None;
			e.Handled = true;
		}
		base.OnDragEnter(e);
	}

	protected override void OnDragOver(DragEventArgs e)
	{
		if (!m_maskIsNull)
		{
			e.Effects = DragDropEffects.None;
			e.Handled = true;
		}
		base.OnDragOver(e);
	}

	protected override bool QueryValueFromTextCore(string text, out object value)
	{
		if (base.ValueDataType != null && m_unhandledLiteralsPositions != null && m_unhandledLiteralsPositions.Count > 0)
		{
			text = m_maskedTextProvider.ToString(ignorePasswordChar: false, includePrompt: false, includeLiterals: true, 0, m_maskedTextProvider.Length);
			for (int num = m_unhandledLiteralsPositions.Count - 1; num >= 0; num--)
			{
				text = text.Remove(m_unhandledLiteralsPositions[num], 1);
			}
		}
		return base.QueryValueFromTextCore(text, out value);
	}

	protected override string QueryTextFromValueCore(object value)
	{
		if (m_valueToStringMethodInfo != null && value != null)
		{
			try
			{
				return (string)m_valueToStringMethodInfo.Invoke(value, new object[2]
				{
					m_formatSpecifier,
					GetActiveFormatProvider()
				});
			}
			catch
			{
			}
		}
		return base.QueryTextFromValueCore(value);
	}

	protected virtual char[] GetMaskCharacters()
	{
		return MaskChars;
	}

	private MaskedTextProvider CreateMaskedTextProvider(string mask)
	{
		return CreateMaskedTextProvider(mask, GetCultureInfo(), AllowPromptAsInput, PromptChar, DefaultPasswordChar, RestrictToAscii);
	}

	protected virtual MaskedTextProvider CreateMaskedTextProvider(string mask, CultureInfo cultureInfo, bool allowPromptAsInput, char promptChar, char passwordChar, bool restrictToAscii)
	{
		return new MaskedTextProvider(mask, cultureInfo, allowPromptAsInput, promptChar, passwordChar, restrictToAscii)
		{
			ResetOnPrompt = ResetOnPrompt,
			ResetOnSpace = ResetOnSpace,
			SkipLiterals = SkipLiterals,
			IncludeLiterals = true,
			IncludePrompt = true,
			IsPassword = false
		};
	}

	internal override void OnIMECompositionEnded(CachedTextInfo cachedTextInfo)
	{
		ForceText(cachedTextInfo.Text, preserveCaret: false);
		base.CaretIndex = cachedTextInfo.CaretIndex;
		base.SelectionStart = cachedTextInfo.SelectionStart;
		base.SelectionLength = cachedTextInfo.SelectionLength;
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		if (base.IsInIMEComposition)
		{
			EndIMEComposition();
		}
		if (m_maskIsNull || m_maskedTextProvider == null || base.IsReadOnly)
		{
			base.OnTextInput(e);
			return;
		}
		e.Handled = true;
		if (base.CharacterCasing == CharacterCasing.Upper)
		{
			ProcessTextInput(e.Text.ToUpper());
		}
		else if (base.CharacterCasing == CharacterCasing.Lower)
		{
			ProcessTextInput(e.Text.ToLower());
		}
		else
		{
			ProcessTextInput(e.Text);
		}
		base.OnTextInput(e);
	}

	private void ProcessTextInput(string text)
	{
		if (text.Length == 1)
		{
			string maskedTextOutput = MaskedTextOutput;
			if (PlaceChar(text[0], base.SelectionStart, base.SelectionLength, IsOverwriteMode, out var caretIndex))
			{
				if (MaskedTextOutput != maskedTextOutput)
				{
					RefreshCurrentText(preserveCurrentCaretPosition: false);
				}
				base.SelectionStart = caretIndex + 1;
			}
			else if (base.BeepOnError)
			{
				PlayBeep();
			}
			if (base.SelectionLength > 0)
			{
				base.SelectionLength = 0;
			}
		}
		else
		{
			Replace(text, base.SelectionStart, base.SelectionLength);
		}
	}

	protected override void ValidateValue(object value)
	{
		base.ValidateValue(value);
		if (!m_maskIsNull)
		{
			string textFromValue = GetTextFromValue(value);
			if (!(m_maskedTextProvider.Clone() as MaskedTextProvider).VerifyString(textFromValue))
			{
				throw new ArgumentException("The value representation '" + textFromValue + "' does not match the mask.", "value");
			}
		}
	}

	internal override bool GetIsEditTextEmpty()
	{
		if (!m_maskIsNull)
		{
			return MaskedTextProvider.AssignedEditPositionCount == 0;
		}
		return true;
	}

	internal override string GetCurrentText()
	{
		if (m_maskIsNull)
		{
			return base.GetCurrentText();
		}
		return GetFormattedString(m_maskedTextProvider, base.Text);
	}

	internal override string GetParsableText()
	{
		if (m_maskIsNull)
		{
			return base.GetParsableText();
		}
		bool flag = false;
		bool flag2 = true;
		if (base.ValueDataType == typeof(string))
		{
			flag = IncludePromptInValue;
			flag2 = IncludeLiteralsInValue;
		}
		return m_maskedTextProvider.ToString(ignorePasswordChar: false, flag, flag2, 0, m_maskedTextProvider.Length);
	}

	internal override void OnFormatProviderChanged()
	{
		MaskedTextProvider maskedTextProvider = new MaskedTextProvider(Mask);
		m_maskedTextProvider = maskedTextProvider;
		RefreshConversionHelpers();
		RefreshCurrentText(preserveCurrentCaretPosition: true);
		base.OnFormatProviderChanged();
	}

	internal override void RefreshConversionHelpers()
	{
		Type valueDataType = base.ValueDataType;
		if (valueDataType == null || !base.IsNumericValueDataType)
		{
			m_formatSpecifier = null;
			m_valueToStringMethodInfo = null;
			m_unhandledLiteralsPositions = null;
			return;
		}
		m_valueToStringMethodInfo = valueDataType.GetMethod("ToString", new Type[2]
		{
			typeof(string),
			typeof(IFormatProvider)
		});
		string mask = m_maskedTextProvider.Mask;
		IFormatProvider activeFormatProvider = GetActiveFormatProvider();
		char[] maskCharacters = GetMaskCharacters();
		m_formatSpecifier = GetFormatSpecifierFromMask(mask, maskCharacters, activeFormatProvider, IncludeLiteralsInValue, out var unhandledLiteralsPositions);
		if (activeFormatProvider.GetFormat(typeof(NumberFormatInfo)) is NumberFormatInfo numberFormatInfo)
		{
			string negativeSign = numberFormatInfo.NegativeSign;
			if (m_formatSpecifier.Contains(negativeSign))
			{
				m_formatSpecifier = m_formatSpecifier + ";" + m_formatSpecifier + ";" + m_formatSpecifier;
			}
		}
		m_unhandledLiteralsPositions = unhandledLiteralsPositions;
	}

	internal void SetValueToStringMethodInfo(MethodInfo valueToStringMethodInfo)
	{
		m_valueToStringMethodInfo = valueToStringMethodInfo;
	}

	internal void ForceMask(string mask)
	{
		m_forcingMask = true;
		try
		{
			Mask = mask;
		}
		finally
		{
			m_forcingMask = false;
		}
	}

	private void PlayBeep()
	{
		SystemSounds.Beep.Play();
	}

	private bool PlaceChar(char ch, int startPosition, int length, bool overwrite, out int caretIndex)
	{
		return PlaceChar(m_maskedTextProvider, ch, startPosition, length, overwrite, out caretIndex);
	}

	private bool PlaceChar(MaskedTextProvider provider, char ch, int startPosition, int length, bool overwrite, out int caretPosition)
	{
		if (ShouldQueryAutoCompleteMask(provider.Clone() as MaskedTextProvider, ch, startPosition))
		{
			AutoCompletingMaskEventArgs e = new AutoCompletingMaskEventArgs(m_maskedTextProvider.Clone() as MaskedTextProvider, startPosition, length, ch.ToString());
			OnAutoCompletingMask(e);
			if (!e.Cancel && e.AutoCompleteStartPosition > -1)
			{
				caretPosition = startPosition;
				for (int i = 0; i < e.AutoCompleteText.Length; i++)
				{
					if (!PlaceCharCore(provider, e.AutoCompleteText[i], e.AutoCompleteStartPosition + i, 0, overwrite: true, out caretPosition))
					{
						return false;
					}
				}
				caretPosition = e.AutoCompleteStartPosition + e.AutoCompleteText.Length;
				return true;
			}
		}
		return PlaceCharCore(provider, ch, startPosition, length, overwrite, out caretPosition);
	}

	private bool ShouldQueryAutoCompleteMask(MaskedTextProvider provider, char ch, int startPosition)
	{
		if (provider.IsEditPosition(startPosition))
		{
			int num = provider.FindNonEditPositionFrom(startPosition, direction: true);
			if (num != -1 && provider[num].Equals(ch))
			{
				int startPosition2 = provider.FindNonEditPositionFrom(startPosition, direction: false);
				if (provider.FindUnassignedEditPositionInRange(startPosition2, num, direction: true) != -1)
				{
					return true;
				}
			}
		}
		return false;
	}

	protected virtual void OnAutoCompletingMask(AutoCompletingMaskEventArgs e)
	{
		if (this.AutoCompletingMask != null)
		{
			this.AutoCompletingMask(this, e);
		}
	}

	private bool PlaceCharCore(MaskedTextProvider provider, char ch, int startPosition, int length, bool overwrite, out int caretPosition)
	{
		caretPosition = startPosition;
		if (startPosition < m_maskedTextProvider.Length)
		{
			MaskedTextResultHint resultHint;
			if (length > 0)
			{
				int endPosition = startPosition + length - 1;
				return provider.Replace(ch, startPosition, endPosition, out caretPosition, out resultHint);
			}
			if (overwrite)
			{
				return provider.Replace(ch, startPosition, out caretPosition, out resultHint);
			}
			return provider.InsertAt(ch, startPosition, out caretPosition, out resultHint);
		}
		return false;
	}

	internal void Replace(string text, int startPosition, int selectionLength)
	{
		MaskedTextProvider maskedTextProvider = (MaskedTextProvider)m_maskedTextProvider.Clone();
		if (CanReplace(maskedTextProvider, text, startPosition, selectionLength, RejectInputOnFirstFailure, out var tentativeCaretIndex))
		{
			bool num = MaskedTextOutput != maskedTextProvider.ToString();
			m_maskedTextProvider = maskedTextProvider;
			if (num)
			{
				RefreshCurrentText(preserveCurrentCaretPosition: false);
			}
			base.CaretIndex = tentativeCaretIndex + 1;
		}
		else if (base.BeepOnError)
		{
			PlayBeep();
		}
	}

	internal virtual bool CanReplace(MaskedTextProvider provider, string text, int startPosition, int selectionLength, bool rejectInputOnFirstFailure, out int tentativeCaretIndex)
	{
		int num = startPosition + selectionLength - 1;
		tentativeCaretIndex = -1;
		bool result = false;
		foreach (char c in text)
		{
			if (!m_maskedTextProvider.VerifyEscapeChar(c, startPosition))
			{
				int num2 = provider.FindEditPositionFrom(startPosition, direction: true);
				if (num2 == MaskedTextProvider.InvalidIndex)
				{
					break;
				}
				startPosition = num2;
			}
			int num3 = ((num >= startPosition) ? 1 : 0);
			bool overwrite = num3 > 0;
			if (PlaceChar(provider, c, startPosition, num3, overwrite, out tentativeCaretIndex))
			{
				result = true;
				startPosition = tentativeCaretIndex + 1;
			}
			else if (rejectInputOnFirstFailure)
			{
				return false;
			}
		}
		if (selectionLength > 0 && startPosition <= num && !provider.RemoveAt(startPosition, num, out var _, out var _))
		{
			result = false;
		}
		return result;
	}

	private bool CanDelete(int startPosition, int selectionLength, bool deleteForward, MaskedTextProvider provider)
	{
		if (base.IsReadOnly)
		{
			return false;
		}
		if (selectionLength == 0)
		{
			if (!deleteForward)
			{
				if (startPosition == 0)
				{
					return false;
				}
				startPosition--;
			}
			else if (startPosition + selectionLength == provider.Length)
			{
				return false;
			}
		}
		int testPosition = startPosition;
		int endPosition = ((selectionLength > 0) ? (startPosition + selectionLength - 1) : startPosition);
		MaskedTextResultHint resultHint;
		return provider.RemoveAt(startPosition, endPosition, out testPosition, out resultHint);
	}

	private void Delete(int startPosition, int selectionLength, bool deleteForward)
	{
		if (base.IsReadOnly)
		{
			return;
		}
		if (selectionLength == 0)
		{
			if (!deleteForward)
			{
				if (startPosition == 0)
				{
					return;
				}
				startPosition--;
			}
			else if (startPosition + selectionLength == m_maskedTextProvider.Length)
			{
				return;
			}
		}
		int testPosition = startPosition;
		int endPosition = ((selectionLength > 0) ? (startPosition + selectionLength - 1) : startPosition);
		string maskedTextOutput = MaskedTextOutput;
		if (!m_maskedTextProvider.RemoveAt(startPosition, endPosition, out testPosition, out var resultHint))
		{
			if (base.BeepOnError)
			{
				PlayBeep();
			}
			return;
		}
		if (MaskedTextOutput != maskedTextOutput)
		{
			RefreshCurrentText(preserveCurrentCaretPosition: false);
		}
		else if (selectionLength > 0)
		{
			testPosition = startPosition;
		}
		else if (resultHint == MaskedTextResultHint.NoEffect)
		{
			if (deleteForward)
			{
				testPosition = m_maskedTextProvider.FindEditPositionFrom(startPosition, direction: true);
			}
			else
			{
				testPosition = ((m_maskedTextProvider.FindAssignedEditPositionFrom(startPosition, direction: true) != MaskedTextProvider.InvalidIndex) ? m_maskedTextProvider.FindEditPositionFrom(startPosition, direction: false) : m_maskedTextProvider.FindAssignedEditPositionFrom(startPosition, direction: false));
				if (testPosition != MaskedTextProvider.InvalidIndex)
				{
					testPosition++;
				}
			}
			if (testPosition == MaskedTextProvider.InvalidIndex)
			{
				testPosition = startPosition;
			}
		}
		else if (!deleteForward)
		{
			testPosition = startPosition;
		}
		base.CaretIndex = testPosition;
	}

	private string GetRawText()
	{
		if (m_maskIsNull)
		{
			return base.Text;
		}
		return GetRawText(m_maskedTextProvider);
	}

	private string GetFormattedString(MaskedTextProvider provider, string text)
	{
		bool flag = !HidePromptOnLeave || base.IsFocused;
		string text2 = provider.ToString(ignorePasswordChar: false, flag, includeLiterals: true, 0, m_maskedTextProvider.Length);
		if (provider.Mask.StartsWith(">"))
		{
			return text2.ToUpper();
		}
		if (provider.Mask.StartsWith("<"))
		{
			return text2.ToLower();
		}
		return text2;
	}

	private string GetSelectedText()
	{
		int selectionLength = base.SelectionLength;
		if (selectionLength == 0)
		{
			return string.Empty;
		}
		bool flag = (ClipboardMaskFormat & MaskFormat.IncludePrompt) != 0;
		bool flag2 = (ClipboardMaskFormat & MaskFormat.IncludeLiterals) != 0;
		return m_maskedTextProvider.ToString(ignorePasswordChar: true, flag, flag2, base.SelectionStart, selectionLength);
	}
}
