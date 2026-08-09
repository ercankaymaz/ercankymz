using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteImagesContextMenu : Storage
{
	private PaletteRedirect _redirect;

	private Image _checked;

	private Image _indeterminate;

	private Image _subMenu;

	[Browsable(false)]
	public override bool IsDefault => _checked == null && _indeterminate == null && _subMenu == null;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use with a checked menu item.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (_checked != value)
			{
				_checked = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use with an indeterminate menu item.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Indeterminate
	{
		get
		{
			return _indeterminate;
		}
		set
		{
			if (_indeterminate != value)
			{
				_indeterminate = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image indicating a sub-menu on a context menu item.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image SubMenu
	{
		get
		{
			return _subMenu;
		}
		set
		{
			if (_subMenu != value)
			{
				_subMenu = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public KryptonPaletteImagesContextMenu(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_redirect = redirect;
		NeedPaint = needPaint;
		_checked = null;
		_indeterminate = null;
		_subMenu = null;
	}

	public void PopulateFromBase()
	{
		_checked = _redirect.GetContextMenuCheckedImage();
		_indeterminate = _redirect.GetContextMenuIndeterminateImage();
		_subMenu = _redirect.GetContextMenuSubMenuImage();
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public void ResetChecked()
	{
		Checked = null;
	}

	public void ResetIndeterminate()
	{
		Indeterminate = null;
	}

	public void ResetSubMenu()
	{
		SubMenu = null;
	}
}
