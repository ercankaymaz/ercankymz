#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class QATButtonToolTipToContent : IContentValues
{
	private IQuickAccessToolbarButton _qatButton;

	public bool HasContent => GetImage(PaletteState.Normal) != null || !string.IsNullOrEmpty(GetShortText()) || !string.IsNullOrEmpty(GetLongText());

	public QATButtonToolTipToContent(IQuickAccessToolbarButton qatButton)
	{
		Debug.Assert(qatButton != null);
		_qatButton = qatButton;
	}

	public Image GetImage(PaletteState state)
	{
		return _qatButton.GetToolTipImage();
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return _qatButton.GetToolTipImageTransparentColor();
	}

	public string GetShortText()
	{
		return _qatButton.GetToolTipTitle();
	}

	public string GetLongText()
	{
		return _qatButton.GetToolTipBody();
	}
}
