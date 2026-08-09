using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[DesignerCategory("code")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class DTPContextMenu : KryptonContextMenu
{
	private Rectangle _dropScreenRect;

	public DTPContextMenu(Rectangle dropScreenRect)
	{
		_dropScreenRect = dropScreenRect;
	}

	protected override VisualContextMenu CreateContextMenu(KryptonContextMenu kcm, IPalette palette, PaletteMode paletteMode, PaletteRedirect redirector, PaletteRedirectContextMenu redirectorImages, KryptonContextMenuCollection items, bool enabled, bool keyboardActivated)
	{
		return new VisualContextMenuDTP(kcm, palette, paletteMode, redirector, redirectorImages, items, enabled, keyboardActivated, _dropScreenRect);
	}
}
