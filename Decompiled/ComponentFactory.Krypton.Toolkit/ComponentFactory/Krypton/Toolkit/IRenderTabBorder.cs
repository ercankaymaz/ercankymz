using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IRenderTabBorder
{
	bool GetTabBorderLeftDrawing(TabBorderStyle tabBorderStyle);

	int GetTabBorderSpacingGap(TabBorderStyle tabBorderStyle);

	Padding GetTabBorderDisplayPadding(ViewLayoutContext context, IPaletteBorder palette, PaletteState state, VisualOrientation orientation, TabBorderStyle tabBorderStyle);

	GraphicsPath GetTabBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle);

	GraphicsPath GetTabBackPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle);

	void DrawTabBorder(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state, TabBorderStyle tabBorderStyle);
}
