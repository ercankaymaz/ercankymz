using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class RibbonShortcuts : Storage
{
	private static readonly Keys _defaultToggleMinimizeMode = Keys.F1 | Keys.Control;

	private static readonly Keys _defaultToggleKeyboardAccess1 = Keys.Menu | Keys.Alt;

	private static readonly Keys _defaultToggleKeyboardAccess2 = Keys.F10;

	private Keys _toggleMinimizeMode;

	private Keys _toggleKeyboardAccess1;

	private Keys _toggleKeyboardAccess2;

	[Browsable(false)]
	public override bool IsDefault => ToggleMinimizeMode == _defaultToggleMinimizeMode && ToggleKeyboardAccess1 == _defaultToggleKeyboardAccess1 && ToggleKeyboardAccess2 == _defaultToggleKeyboardAccess2;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Shortcut to toggle the ribbon minimized mode.")]
	[DefaultValue(typeof(Keys), "F1, Control")]
	public Keys ToggleMinimizeMode
	{
		get
		{
			return _toggleMinimizeMode;
		}
		set
		{
			_toggleMinimizeMode = value;
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Shortcut to toggle keyboard access to the ribbon.")]
	[DefaultValue(typeof(Keys), "Menu, Alt")]
	public Keys ToggleKeyboardAccess1
	{
		get
		{
			return _toggleKeyboardAccess1;
		}
		set
		{
			_toggleKeyboardAccess1 = value;
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Shortcut to toggle keyboard access to the ribbon.")]
	[DefaultValue(typeof(Keys), "F10")]
	public Keys ToggleKeyboardAccess2
	{
		get
		{
			return _toggleKeyboardAccess2;
		}
		set
		{
			_toggleKeyboardAccess2 = value;
		}
	}

	public RibbonShortcuts()
	{
		_toggleMinimizeMode = _defaultToggleMinimizeMode;
		_toggleKeyboardAccess1 = _defaultToggleKeyboardAccess1;
		_toggleKeyboardAccess2 = _defaultToggleKeyboardAccess2;
	}

	private bool ShouldSerializeToggleMinimizeMode()
	{
		return ToggleMinimizeMode != _defaultToggleMinimizeMode;
	}

	public void ResetToggleMinimizeMode()
	{
		ToggleMinimizeMode = _defaultToggleMinimizeMode;
	}

	private bool ShouldSerializeToggleKeyboardAccess1()
	{
		return ToggleKeyboardAccess1 != _defaultToggleKeyboardAccess1;
	}

	public void ResetToggleKeyboardAccess1()
	{
		ToggleKeyboardAccess1 = _defaultToggleKeyboardAccess1;
	}

	private bool ShouldSerializeToggleKeyboardAccess2()
	{
		return ToggleKeyboardAccess2 != _defaultToggleKeyboardAccess2;
	}

	public void ResetToggleKeyboardAccess2()
	{
		ToggleKeyboardAccess2 = _defaultToggleKeyboardAccess2;
	}
}
