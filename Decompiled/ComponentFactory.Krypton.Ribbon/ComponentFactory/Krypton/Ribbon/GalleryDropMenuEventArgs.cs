using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class GalleryDropMenuEventArgs : CancelEventArgs
{
	private KryptonContextMenu _contextMenu;

	public KryptonContextMenu KryptonContextMenu => _contextMenu;

	public GalleryDropMenuEventArgs(KryptonContextMenu contextMenu)
	{
		_contextMenu = contextMenu;
	}
}
