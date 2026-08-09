namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectBreadCrumb : PaletteRedirect
{
	private bool _left;

	private bool _right;

	private bool _topBottom;

	public bool Left
	{
		get
		{
			return _left;
		}
		set
		{
			_left = value;
		}
	}

	public bool Right
	{
		get
		{
			return _right;
		}
		set
		{
			_right = value;
		}
	}

	public bool TopBottom
	{
		get
		{
			return _topBottom;
		}
		set
		{
			_topBottom = value;
		}
	}

	public PaletteRedirectBreadCrumb(IPalette target)
		: base(target)
	{
		_left = false;
		_right = false;
		_topBottom = true;
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		PaletteDrawBorders paletteDrawBorders = base.GetBorderDrawBorders(style, state);
		if (style == PaletteBorderStyle.ButtonBreadCrumb)
		{
			if (Left)
			{
				paletteDrawBorders &= ~PaletteDrawBorders.Left;
			}
			if (Right)
			{
				paletteDrawBorders &= ~PaletteDrawBorders.Right;
			}
			if (TopBottom)
			{
				paletteDrawBorders &= ~PaletteDrawBorders.TopBottom;
			}
		}
		return paletteDrawBorders;
	}
}
