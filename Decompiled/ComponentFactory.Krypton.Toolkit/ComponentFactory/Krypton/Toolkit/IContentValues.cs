using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IContentValues
{
	Image GetImage(PaletteState state);

	Color GetImageTransparentColor(PaletteState state);

	string GetShortText();

	string GetLongText();
}
