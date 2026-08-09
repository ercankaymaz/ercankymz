using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IRenderBorder
{
	Padding GetBorderRawPadding(IPaletteBorder palette, PaletteState state, VisualOrientation orientation);

	Padding GetBorderDisplayPadding(IPaletteBorder palette, PaletteState state, VisualOrientation orientation);

	GraphicsPath GetOutsideBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);

	GraphicsPath GetBorderPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);

	GraphicsPath GetBackPath(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);

	void DrawBorder(RenderContext context, Rectangle rect, IPaletteBorder palette, VisualOrientation orientation, PaletteState state);
}
