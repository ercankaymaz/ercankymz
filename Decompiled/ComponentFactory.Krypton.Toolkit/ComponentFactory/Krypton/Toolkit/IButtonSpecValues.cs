using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IButtonSpecValues
{
	event PropertyChangedEventHandler ButtonSpecPropertyChanged;

	Image GetImage(IPalette palette, PaletteState state);

	Color GetImageTransparentColor(IPalette palette);

	string GetShortText(IPalette palette);

	string GetLongText(IPalette palette);

	string GetToolTipTitle(IPalette palette);

	Color GetColorMap(IPalette palette);

	bool GetVisible(IPalette palette);

	ButtonEnabled GetEnabled(IPalette palette);

	void SetView(ViewBase view);

	ViewBase GetView();

	bool GetViewEnabled();

	RelativeEdgeAlign GetEdge(IPalette palette);

	ButtonStyle GetStyle(IPalette palette);

	HeaderLocation GetLocation(IPalette palette);

	ButtonOrientation GetOrientation(IPalette palette);
}
