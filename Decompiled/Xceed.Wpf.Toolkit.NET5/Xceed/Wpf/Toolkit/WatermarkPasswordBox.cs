using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public class WatermarkPasswordBox : WatermarkTextBox
{
	private int _newCaretIndex = -1;

	public static readonly DependencyProperty PasswordCharProperty = DependencyProperty.Register("PasswordChar", typeof(char), typeof(WatermarkPasswordBox), (PropertyMetadata)(object)new UIPropertyMetadata('●', new PropertyChangedCallback(OnPasswordCharChanged)));

	public static readonly RoutedEvent PasswordChangedEvent = EventManager.RegisterRoutedEvent("PasswordChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WatermarkPasswordBox));

	public string Password
	{
		[SecuritySafeCritical]
		get
		{
			IntPtr intPtr = Marshal.SecureStringToBSTR(SecurePassword);
			try
			{
				return Marshal.PtrToStringUni(intPtr);
			}
			finally
			{
				Marshal.ZeroFreeBSTR(intPtr);
			}
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			SecurePassword = new SecureString();
			for (int i = 0; i < value.Length; i++)
			{
				SecurePassword.AppendChar(value[i]);
			}
			SyncTextPassword(_newCaretIndex);
			RaiseEvent(new RoutedEventArgs(PasswordChangedEvent, this));
		}
	}

	public char PasswordChar
	{
		get
		{
			return (char)((DependencyObject)this).GetValue(PasswordCharProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PasswordCharProperty, (object)value);
		}
	}

	public SecureString SecurePassword { get; private set; }

	public event RoutedEventHandler PasswordChanged
	{
		add
		{
			AddHandler(PasswordChangedEvent, value);
		}
		remove
		{
			RemoveHandler(PasswordChangedEvent, value);
		}
	}

	private static void OnPasswordCharChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is WatermarkPasswordBox watermarkPasswordBox)
		{
			watermarkPasswordBox.OnPasswordCharChanged((char)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (char)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnPasswordCharChanged(char oldValue, char newValue)
	{
		SyncTextPassword(base.CaretIndex);
	}

	public WatermarkPasswordBox()
	{
		Password = string.Empty;
		base.IsUndoEnabled = false;
		base.UndoLimit = 0;
		CommandManager.AddPreviewCanExecuteHandler(this, OnPreviewCanExecuteCommand);
		DataObject.AddPastingHandler((DependencyObject)(object)this, OnPaste);
	}

	[SecuritySafeCritical]
	protected override void OnPreviewTextInput(TextCompositionEventArgs e)
	{
		if (e.Text != "\r")
		{
			PasswordInsert(e.Text, base.CaretIndex);
		}
		e.Handled = true;
		base.OnPreviewTextInput(e);
	}

	[SecuritySafeCritical]
	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Invalid comparison between Unknown and I4
		Key key = e.Key;
		if ((int)key <= 13)
		{
			if ((int)key != 2)
			{
				if ((int)key != 6)
				{
					if ((int)key == 13)
					{
						e.Handled = true;
					}
				}
				else if (base.AcceptsReturn)
				{
					PasswordInsert("\r", base.CaretIndex);
				}
			}
			else
			{
				PasswordRemove((base.SelectedText.Length > 0) ? base.CaretIndex : (base.CaretIndex - 1));
				e.Handled = true;
			}
		}
		else if ((int)key != 18)
		{
			if ((int)key != 32)
			{
				if ((int)key == 65 && (Keyboard.Modifiers & 2) == 2 && Clipboard.ContainsText())
				{
					PasswordInsert(Clipboard.GetText(), base.CaretIndex);
					e.Handled = true;
				}
			}
			else
			{
				PasswordRemove(base.CaretIndex);
				e.Handled = true;
			}
		}
		else
		{
			PasswordInsert(" ", base.CaretIndex);
			e.Handled = true;
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		base.OnTextChanged(e);
		if (base.Text.Length != Password.Length)
		{
			if (base.Text == "")
			{
				SetPassword("", 0);
			}
			else
			{
				SyncTextPassword(Password.Length);
			}
		}
	}

	[SecuritySafeCritical]
	private void OnPaste(object sender, DataObjectPastingEventArgs e)
	{
		if (e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, autoConvert: true))
		{
			if (e.SourceDataObject.GetData(DataFormats.UnicodeText) is string text)
			{
				PasswordInsert(text, base.CaretIndex);
			}
			e.CancelCommand();
		}
	}

	private void OnPreviewCanExecuteCommand(object sender, CanExecuteRoutedEventArgs e)
	{
		if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Undo)
		{
			e.CanExecute = false;
			e.Handled = true;
		}
	}

	[SecurityCritical]
	private void PasswordInsert(string text, int index)
	{
		if (text == null || index < 0 || index > Password.Length)
		{
			return;
		}
		if (base.SelectedText.Length > 0)
		{
			PasswordRemove(index);
		}
		string text2 = Password;
		for (int i = 0; i < text.Length; i++)
		{
			if (base.MaxLength == 0 || text2.Length < base.MaxLength)
			{
				text2 = text2.Insert(index++, text[i].ToString());
			}
		}
		SetPassword(text2, index);
	}

	[SecurityCritical]
	private void PasswordRemove(int index)
	{
		if (index < 0 || index >= Password.Length)
		{
			return;
		}
		if (base.SelectedText.Length > 0)
		{
			string text = Password;
			for (int i = 0; i < base.SelectedText.Length; i++)
			{
				text = text.Remove(index, 1);
			}
			SetPassword(text, index);
		}
		else
		{
			string password = Password.Remove(index, 1);
			SetPassword(password, index);
		}
	}

	private void SetPassword(string password, int caretIndex)
	{
		_newCaretIndex = caretIndex;
		Password = password;
		_newCaretIndex = -1;
	}

	private void SyncTextPassword(int nextCarretIndex)
	{
		StringBuilder stringBuilder = new StringBuilder();
		base.Text = stringBuilder.Append(Enumerable.Repeat(PasswordChar, Password.Length).ToArray()).ToString();
		base.CaretIndex = Math.Max(nextCarretIndex, 0);
	}
}
