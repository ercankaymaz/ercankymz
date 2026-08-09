using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public interface IRenderBack
{
	IDisposable DrawBack(RenderContext context, Rectangle rect, GraphicsPath path, IPaletteBack palette, VisualOrientation orientation, PaletteState state, IDisposable memento);
}
