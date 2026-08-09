using System;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IRenderRibbon
{
	IDisposable DrawRibbonBack(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, bool composition, IDisposable memento);

	IDisposable DrawRibbonTabContextTitle(PaletteRibbonShape shape, RenderContext context, Rectangle rect, IPaletteRibbonGeneral paletteGeneral, IPaletteRibbonBack paletteBack, IDisposable memento);

	IDisposable DrawRibbonApplicationButton(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento);

	IDisposable DrawRibbonApplicationTab(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, Color baseColor1, Color baseColor2, IDisposable memento);

	void DrawRibbonClusterEdge(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, PaletteState state);
}
