using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MS.Internal;

namespace Microsoft.Windows.Design.Interaction;

public class ToolGesture : InputGesture
{
	private ToolAction _toolAction;

	private MouseButtonState[] _buttons;

	private ModifierKeys _modifiers;

	public ToolAction ToolAction
	{
		get
		{
			return _toolAction;
		}
		set
		{
			if (!EnumValidator.IsValid(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_toolAction = value;
		}
	}

	public MouseButtonState LeftButton
	{
		get
		{
			return _buttons[0];
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Expected I4, but got Unknown
			_buttons[0] = (MouseButtonState)(int)value;
		}
	}

	public MouseButtonState RightButton
	{
		get
		{
			return _buttons[2];
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Expected I4, but got Unknown
			_buttons[2] = (MouseButtonState)(int)value;
		}
	}

	public MouseButtonState MiddleButton
	{
		get
		{
			return _buttons[1];
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Expected I4, but got Unknown
			_buttons[1] = (MouseButtonState)(int)value;
		}
	}

	public MouseButtonState XButton1
	{
		get
		{
			return _buttons[3];
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Expected I4, but got Unknown
			_buttons[3] = (MouseButtonState)(int)value;
		}
	}

	public MouseButtonState XButton2
	{
		get
		{
			return _buttons[4];
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Expected I4, but got Unknown
			_buttons[4] = (MouseButtonState)(int)value;
		}
	}

	public ModifierKeys Modifiers
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _modifiers;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_modifiers = value;
		}
	}

	public ToolGesture()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		_toolAction = ToolAction.None;
		_buttons = (MouseButtonState[])(object)new MouseButtonState[5];
		for (int i = 0; i < _buttons.Length; i++)
		{
			_buttons[i] = (MouseButtonState)1;
		}
		_modifiers = (ModifierKeys)15;
	}

	public ToolGesture(ToolAction action)
		: this()
	{
		if (!EnumValidator.IsValid(action))
		{
			throw new ArgumentOutOfRangeException("action");
		}
		_toolAction = action;
	}

	public ToolGesture(ToolAction action, MouseButton button)
		: this()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		ValidateButton(button);
		if (!EnumValidator.IsValid(action))
		{
			throw new ArgumentOutOfRangeException("action");
		}
		_toolAction = action;
		for (int i = 0; i < _buttons.Length; i++)
		{
			_buttons[i] = (MouseButtonState)0;
		}
		_buttons[button] = (MouseButtonState)1;
	}

	public ToolGesture(ToolAction action, MouseButton button, ModifierKeys modifiers)
		: this(action, button)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		ValidateButton(button);
		if (!EnumValidator.IsValid(action))
		{
			throw new ArgumentOutOfRangeException("action");
		}
		_toolAction = action;
		_modifiers = modifiers;
	}

	private static ToolAction GetToolAction(InputEventArgs inputEventArgs)
	{
		if (inputEventArgs is ToolActionEventArgs e)
		{
			return e.ToolAction;
		}
		return ToolAction.None;
	}

	private static ModifierKeys GetModifiers(InputEventArgs inputEventArgs)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		DragEventArgs e = null;
		if (inputEventArgs is ToolActionEventArgs e2)
		{
			EventArgs sourceEvent = e2.SourceEvent;
			e = (DragEventArgs)(object)((sourceEvent is DragEventArgs) ? sourceEvent : null);
		}
		ModifierKeys val = (ModifierKeys)0;
		if (e != null)
		{
			DragDropKeyStates keyStates = e.KeyStates;
			if ((keyStates & 0x20) != 0)
			{
				val = (ModifierKeys)(val | 1);
			}
			if ((keyStates & 8) != 0)
			{
				val = (ModifierKeys)(val | 2);
			}
			if ((keyStates & 4) != 0)
			{
				val = (ModifierKeys)(val | 4);
			}
		}
		else
		{
			val = KeyboardHelper.Modifiers;
		}
		return val;
	}

	private static MouseButtonState[] GetButtons(InputEventArgs inputEventArgs)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected I4, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected I4, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected I4, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected I4, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected I4, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected I4, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected I4, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected I4, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected I4, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected I4, but got Unknown
		MouseButtonState[] array = (MouseButtonState[])(object)new MouseButtonState[5];
		EventArgs e = (EventArgs)(object)inputEventArgs;
		if (e is ToolActionEventArgs e2)
		{
			e = e2.SourceEvent;
		}
		MouseButtonEventArgs e3;
		MouseEventArgs e4;
		if ((e3 = (MouseButtonEventArgs)(object)((e is MouseButtonEventArgs) ? e : null)) != null)
		{
			array[e3.ChangedButton] = (MouseButtonState)1;
		}
		else if ((e4 = (MouseEventArgs)(object)((e is MouseEventArgs) ? e : null)) != null)
		{
			array[0] = (MouseButtonState)(int)e4.LeftButton;
			array[1] = (MouseButtonState)(int)e4.MiddleButton;
			array[2] = (MouseButtonState)(int)e4.RightButton;
			array[3] = (MouseButtonState)(int)e4.XButton1;
			array[4] = (MouseButtonState)(int)e4.XButton2;
		}
		else
		{
			array[0] = (MouseButtonState)(int)Mouse.LeftButton;
			array[1] = (MouseButtonState)(int)Mouse.MiddleButton;
			array[2] = (MouseButtonState)(int)Mouse.RightButton;
			array[3] = (MouseButtonState)(int)Mouse.XButton1;
			array[4] = (MouseButtonState)(int)Mouse.XButton2;
		}
		return array;
	}

	public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between I4 and Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if (inputEventArgs == null)
		{
			throw new ArgumentNullException("inputEventArgs");
		}
		ToolAction toolAction = GetToolAction(inputEventArgs);
		if (_toolAction != toolAction)
		{
			return false;
		}
		ModifierKeys modifiers = GetModifiers(inputEventArgs);
		if (15 != (int)_modifiers)
		{
			if ((int)modifiers == 0 && (int)_modifiers != 0)
			{
				return false;
			}
			if ((ModifierKeys)(_modifiers & modifiers) != modifiers)
			{
				return false;
			}
		}
		MouseButtonState[] buttons = GetButtons(inputEventArgs);
		for (int i = 0; i < _buttons.Length; i++)
		{
			if ((int)_buttons[i] == 0 && (int)buttons[i] == 1)
			{
				return false;
			}
		}
		return true;
	}

	public override string ToString()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < _buttons.Length; i++)
		{
			if ((int)_buttons[i] == 1)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(":");
				}
				stringBuilder.Append(((object)(MouseButton)i).ToString());
			}
		}
		return string.Concat(_toolAction, ", ", stringBuilder.ToString(), ", ", _modifiers);
	}

	private void ValidateButton(MouseButton button)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Expected I4, but got Unknown
		int num = (int)button;
		if (num < 0 || num > _buttons.Length)
		{
			throw new ArgumentOutOfRangeException("button");
		}
	}
}
