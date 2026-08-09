using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteButtonSpec
{
	Icon GetButtonSpecIcon(PaletteButtonSpecStyle style);

	Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state);

	Color GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle style);

	string GetButtonSpecShortText(PaletteButtonSpecStyle style);

	string GetButtonSpecLongText(PaletteButtonSpecStyle style);

	string GetButtonSpecToolTipTitle(PaletteButtonSpecStyle style);

	Color GetButtonSpecColorMap(PaletteButtonSpecStyle style);

	PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style);

	HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style);

	PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style);

	PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style);
}
