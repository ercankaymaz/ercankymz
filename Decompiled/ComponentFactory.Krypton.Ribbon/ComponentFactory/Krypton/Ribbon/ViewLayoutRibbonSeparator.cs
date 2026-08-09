#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonSeparator : ViewLeaf
{
	private int _width;

	private int _height;

	public Size SeparatorSize
	{
		get
		{
			return new Size(_width, _height);
		}
		set
		{
			_width = value.Width;
			_height = value.Height;
		}
	}

	public ViewLayoutRibbonSeparator(int length, bool ignoreMouse)
		: this(length, length, ignoreMouse)
	{
	}

	public ViewLayoutRibbonSeparator(int width, int height, bool ignoreMouse)
	{
		_width = width;
		_height = height;
		if (ignoreMouse)
		{
			MouseController = NullController.Singleton;
		}
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonSeparator:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return new Size(_width, _height);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}
}
