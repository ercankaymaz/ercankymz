using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonKeyTip : ViewDrawDocker, IContentValues
{
	private KeyTipInfo _keyTipInfo;

	private ViewDrawContent _drawContent;

	public KeyTipInfo KeyTipInfo => _keyTipInfo;

	public ViewDrawRibbonKeyTip(KeyTipInfo keyTipInfo, IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteContent paletteContent)
		: base(paletteBack, paletteBorder)
	{
		_keyTipInfo = keyTipInfo;
		_drawContent = new ViewDrawContent(paletteContent, this, VisualOrientation.Top);
		Add(_drawContent, ViewDockStyle.Fill);
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return _keyTipInfo.KeyString;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
