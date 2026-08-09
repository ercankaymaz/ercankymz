#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecToContent : IContentValues
{
	private ButtonSpec _buttonSpec;

	private IPalette _palette;

	public bool HasContent => GetImage(PaletteState.Normal) != null || !string.IsNullOrEmpty(GetShortText()) || !string.IsNullOrEmpty(GetLongText());

	public ButtonSpecToContent(IPalette palette, ButtonSpec buttonSpec)
	{
		Debug.Assert(palette != null);
		Debug.Assert(buttonSpec != null);
		_palette = palette;
		_buttonSpec = buttonSpec;
	}

	public Image GetImage(PaletteState state)
	{
		return _buttonSpec.ToolTipImage;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return _buttonSpec.ToolTipImageTransparentColor;
	}

	public string GetShortText()
	{
		return _buttonSpec.GetToolTipTitle(_palette);
	}

	public string GetLongText()
	{
		return _buttonSpec.ToolTipBody;
	}
}
