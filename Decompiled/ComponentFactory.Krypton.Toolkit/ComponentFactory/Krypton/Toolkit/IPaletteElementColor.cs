using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteElementColor
{
	Color GetElementColor1(PaletteState state);

	Color GetElementColor2(PaletteState state);

	Color GetElementColor3(PaletteState state);

	Color GetElementColor4(PaletteState state);

	Color GetElementColor5(PaletteState state);
}
