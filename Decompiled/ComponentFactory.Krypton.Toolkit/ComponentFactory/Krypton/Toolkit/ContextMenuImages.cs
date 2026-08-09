using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ContextMenuImages : Storage
{
	private Image _checked;

	private Image _indeterminate;

	private Image _subMenu;

	[Browsable(false)]
	public override bool IsDefault => _checked == null && _indeterminate == null && _subMenu == null;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for a checked context menu item.")]
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
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for an indeterminate context menu item.")]
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
				PerformNeedPaint();
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
				PerformNeedPaint();
			}
		}
	}

	public ContextMenuImages(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_checked = null;
		_indeterminate = null;
		_subMenu = null;
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
