#define DEBUG
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecCalendar : ButtonSpec
{
	private ViewDrawMonth _month;

	private RelativeEdgeAlign _edge;

	private bool _visible;

	private bool _enabled;

	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
		}
	}

	public override bool AllowComponent => false;

	public ButtonSpecCalendar(ViewDrawMonth month, PaletteButtonSpecStyle fixedStyle, RelativeEdgeAlign edge)
	{
		Debug.Assert(month != null);
		_month = month;
		_edge = edge;
		_enabled = true;
		_visible = true;
		base.ProtectedType = fixedStyle;
	}

	public override bool GetVisible(IPalette palette)
	{
		return Visible;
	}

	public override ButtonEnabled GetEnabled(IPalette palette)
	{
		return (!Enabled) ? ButtonEnabled.False : ButtonEnabled.Container;
	}

	public override ButtonCheckState GetChecked(IPalette palette)
	{
		return ButtonCheckState.Unchecked;
	}

	public override RelativeEdgeAlign GetEdge(IPalette palette)
	{
		return _edge;
	}
}
