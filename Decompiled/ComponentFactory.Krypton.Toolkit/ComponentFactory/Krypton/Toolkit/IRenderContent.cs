using System;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IRenderContent
{
	Size GetContentPreferredSize(ViewLayoutContext context, IPaletteContent palette, IContentValues values, VisualOrientation orientation, PaletteState state, bool composition);

	IDisposable LayoutContent(ViewLayoutContext context, Rectangle availableRect, IPaletteContent palette, IContentValues values, VisualOrientation orientation, PaletteState state, bool composition);

	void DrawContent(RenderContext context, Rectangle displayRect, IPaletteContent palette, IDisposable memento, VisualOrientation orientation, PaletteState state, bool composition, bool allowFocusRect);

	bool GetContentImageDisplayed(IDisposable memento);

	Rectangle GetContentImageRectangle(IDisposable memento);

	bool GetContentShortTextDisplayed(IDisposable memento);

	Rectangle GetContentShortTextRectangle(IDisposable memento);

	bool GetContentLongTextDisplayed(IDisposable memento);

	Rectangle GetContentLongTextRectangle(IDisposable memento);
}
