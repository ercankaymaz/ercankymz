using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class VisualContextMenuDTP : VisualContextMenu
{
	private Rectangle _dropScreenRect;

	public VisualContextMenuDTP(KryptonContextMenu contextMenu, IPalette palette, PaletteMode paletteMode, PaletteRedirect redirector, PaletteRedirectContextMenu redirectorImages, KryptonContextMenuCollection items, bool enabled, bool keyboardActivated, Rectangle dropScreenRect)
		: base(contextMenu, palette, paletteMode, redirector, redirectorImages, items, enabled, keyboardActivated)
	{
		_dropScreenRect = dropScreenRect;
	}

	public override bool DoesMouseDownGetEaten(Message m, Point pt)
	{
		return _dropScreenRect.Contains(new Point(pt.X, pt.Y));
	}
}
