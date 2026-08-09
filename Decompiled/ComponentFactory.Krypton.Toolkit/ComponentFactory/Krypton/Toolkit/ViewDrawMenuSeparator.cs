#define DEBUG
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMenuSeparator : ViewDrawDocker
{
	private bool _draw;

	public bool Draw
	{
		get
		{
			return _draw;
		}
		set
		{
			_draw = value;
		}
	}

	public ViewDrawMenuSeparator(KryptonContextMenuSeparator separator, PaletteDoubleRedirect palette)
		: base(separator.StateNormal.Back, separator.StateNormal.Border)
	{
		_draw = true;
		separator.SetPaletteRedirect(palette);
		if (separator.Horizontal)
		{
			base.Orientation = VisualOrientation.Top;
		}
		else
		{
			base.Orientation = VisualOrientation.Left;
		}
		Add(new ViewLayoutSeparator(1));
	}

	public ViewDrawMenuSeparator(PaletteDouble state)
		: base(state.Back, state.Border)
	{
		base.Orientation = VisualOrientation.Left;
		Add(new ViewLayoutSeparator(1));
	}

	public override string ToString()
	{
		return "ViewDrawMenuSeparator:" + base.Id;
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (Draw)
		{
			base.Render(context);
		}
	}
}
