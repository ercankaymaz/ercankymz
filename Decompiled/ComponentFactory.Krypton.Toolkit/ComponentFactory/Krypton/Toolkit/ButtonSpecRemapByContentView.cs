namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecRemapByContentView : ButtonSpecRemapByContentBase
{
	private ViewDrawContent _foreground;

	public ViewDrawContent Foreground
	{
		get
		{
			return _foreground;
		}
		set
		{
			_foreground = value;
		}
	}

	public override IPaletteContent PaletteContent
	{
		get
		{
			if (_foreground != null)
			{
				return _foreground.GetPalette();
			}
			return null;
		}
	}

	public override PaletteState PaletteState => _foreground.State;

	public ButtonSpecRemapByContentView(IPalette target, ButtonSpec buttonSpec)
		: base(target, buttonSpec)
	{
	}
}
