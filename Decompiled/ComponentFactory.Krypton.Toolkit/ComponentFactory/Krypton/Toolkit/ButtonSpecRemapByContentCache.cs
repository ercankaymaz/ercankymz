namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecRemapByContentCache : ButtonSpecRemapByContentBase
{
	private IPaletteContent _paletteContent;

	private PaletteState _paletteState;

	public override IPaletteContent PaletteContent => _paletteContent;

	public override PaletteState PaletteState => _paletteState;

	public ButtonSpecRemapByContentCache(IPalette target, ButtonSpec buttonSpec)
		: base(target, buttonSpec)
	{
	}

	public void SetPaletteContent(IPaletteContent paletteContent)
	{
		_paletteContent = paletteContent;
	}

	public void SetPaletteState(PaletteState paletteState)
	{
		_paletteState = paletteState;
	}
}
