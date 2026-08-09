using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IRenderGlyph
{
	void DrawSeparator(RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, IPaletteBorder paletteBorder, Orientation orientation, PaletteState state, bool canMove);

	Size GetCheckBoxPreferredSize(ViewLayoutContext context, IPalette palette, bool enabled, CheckState checkState, bool tracking, bool pressed);

	void DrawCheckBox(RenderContext context, Rectangle displayRect, IPalette palette, bool enabled, CheckState checkState, bool tracking, bool pressed);

	Size GetRadioButtonPreferredSize(ViewLayoutContext context, IPalette palette, bool enabled, bool checkState, bool tracking, bool pressed);

	void DrawRadioButton(RenderContext context, Rectangle displayRect, IPalette palette, bool enabled, bool checkState, bool tracking, bool pressed);

	Size GetDropDownButtonPreferredSize(ViewLayoutContext context, IPalette palette, PaletteState state, VisualOrientation orientation);

	void DrawDropDownButton(RenderContext context, Rectangle displayRect, IPalette palette, PaletteState state, VisualOrientation orientation);

	void DrawInputControlDropDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state);

	void DrawInputControlNumericUpGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state);

	void DrawInputControlNumericDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state);

	void DrawRibbonDialogBoxLauncher(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	void DrawRibbonDropArrow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	void DrawRibbonContextArrow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	void DrawRibbonOverflow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	void DrawRibbonGroupSeparator(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state);

	Rectangle DrawGridSortGlyph(RenderContext context, SortOrder sortOrder, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state, bool rtl);

	Rectangle DrawGridRowGlyph(RenderContext context, GridRowGlyph rowGlyph, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state, bool rtl);

	Rectangle DrawGridErrorGlyph(RenderContext context, Rectangle cellRect, PaletteState state, bool rtl);

	void DrawDragDropSolidGlyph(RenderContext context, Rectangle drawRect, IPaletteDragDrop dragDropPalette);

	void MeasureDragDropDockingGlyph(RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette, PaletteDragFeedback feedback);

	void DrawDragDropDockingGlyph(RenderContext context, RenderDragDockingData dragData, IPaletteDragDrop dragDropPalette, PaletteDragFeedback feedback);

	void DrawTrackTicksGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, bool topRight, Size positionSize, int minimum, int maximum, int frequency);

	void DrawTrackGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, bool volumeControl);

	void DrawTrackPositionGlyph(RenderContext context, PaletteState state, IPaletteElementColor elementPalette, Rectangle drawRect, Orientation orientation, TickStyle tickStyle);
}
