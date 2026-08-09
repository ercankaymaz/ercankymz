using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDecoratorFixedSize : ViewDecorator
{
	private Size _fixedSize;

	public Size FixedSize
	{
		get
		{
			return _fixedSize;
		}
		set
		{
			_fixedSize = value;
		}
	}

	public ViewDecoratorFixedSize(ViewBase child, Size fixedSize)
		: base(child)
	{
		_fixedSize = fixedSize;
	}

	public override string ToString()
	{
		return "ViewDecoratorFixedSize:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _fixedSize;
	}
}
