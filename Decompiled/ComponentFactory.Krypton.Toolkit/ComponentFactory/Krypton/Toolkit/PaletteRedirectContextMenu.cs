#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectContextMenu : PaletteRedirect
{
	private ContextMenuImages _images;

	public PaletteRedirectContextMenu(IPalette target, ContextMenuImages images)
		: base(target)
	{
		Debug.Assert(images != null);
		_images = images;
	}

	public override Image GetContextMenuCheckedImage()
	{
		Image image = _images.Checked;
		if (image == null)
		{
			image = Target.GetContextMenuCheckedImage();
		}
		return image;
	}

	public override Image GetContextMenuIndeterminateImage()
	{
		Image image = _images.Indeterminate;
		if (image == null)
		{
			image = Target.GetContextMenuIndeterminateImage();
		}
		return image;
	}

	public override Image GetContextMenuSubMenuImage()
	{
		Image image = _images.SubMenu;
		if (image == null)
		{
			image = Target.GetContextMenuSubMenuImage();
		}
		return image;
	}
}
