#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class GroupItemToolTipToContent : IContentValues
{
	private KryptonRibbonGroupItem _groupItem;

	public bool HasContent => GetImage(PaletteState.Normal) != null || !string.IsNullOrEmpty(GetShortText()) || !string.IsNullOrEmpty(GetLongText());

	public GroupItemToolTipToContent(KryptonRibbonGroupItem groupItem)
	{
		Debug.Assert(groupItem != null);
		_groupItem = groupItem;
	}

	public Image GetImage(PaletteState state)
	{
		return _groupItem.InternalToolTipImage;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return _groupItem.InternalToolTipImageTransparentColor;
	}

	public string GetShortText()
	{
		return _groupItem.InternalToolTipTitle;
	}

	public string GetLongText()
	{
		return _groupItem.InternalToolTipBody;
	}
}
