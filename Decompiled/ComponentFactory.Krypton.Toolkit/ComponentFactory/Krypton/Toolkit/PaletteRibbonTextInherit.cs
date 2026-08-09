using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteRibbonTextInherit : GlobalId, IPaletteRibbonText
{
	public abstract Color GetRibbonTextColor(PaletteState state);
}
