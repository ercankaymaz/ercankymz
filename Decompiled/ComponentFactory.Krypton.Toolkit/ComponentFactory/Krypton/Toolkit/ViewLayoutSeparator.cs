#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutSeparator : ViewLeaf
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

	public ViewLayoutSeparator(int length)
		: this(length, length)
	{
	}

	public ViewLayoutSeparator(int width, int height)
	{
		_width = width;
		_height = height;
	}

	public override string ToString()
	{
		return "ViewLayoutSeparator:" + base.Id;
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
