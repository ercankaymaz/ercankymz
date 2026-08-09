using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteElementColorInherit : GlobalId, IPaletteElementColor
{
	public abstract Color GetElementColor1(PaletteState state);

	public abstract Color GetElementColor2(PaletteState state);

	public abstract Color GetElementColor3(PaletteState state);

	public abstract Color GetElementColor4(PaletteState state);

	public abstract Color GetElementColor5(PaletteState state);
}
