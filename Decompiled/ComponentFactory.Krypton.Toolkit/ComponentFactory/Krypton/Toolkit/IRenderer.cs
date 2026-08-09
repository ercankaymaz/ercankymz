using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IRenderer
{
	IRenderBorder RenderStandardBorder { get; }

	IRenderBack RenderStandardBack { get; }

	IRenderContent RenderStandardContent { get; }

	IRenderTabBorder RenderTabBorder { get; }

	IRenderRibbon RenderRibbon { get; }

	IRenderGlyph RenderGlyph { get; }

	bool EvalTransparentPaint(IPaletteBack paletteBack, PaletteState state);

	bool EvalTransparentPaint(IPaletteBack paletteBack, IPaletteBorder paletteBorder, PaletteState state);

	ToolStripRenderer RenderToolStrip(IPalette colorPalette);
}
