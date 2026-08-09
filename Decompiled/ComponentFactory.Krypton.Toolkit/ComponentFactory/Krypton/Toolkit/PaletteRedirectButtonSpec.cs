using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectButtonSpec : PaletteRedirect
{
	private IPaletteButtonSpec _inherit;

	public PaletteRedirectButtonSpec(IPalette target, IPaletteButtonSpec inherit)
		: base(target)
	{
		_inherit = inherit;
	}

	public override Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
	{
		return _inherit.GetButtonSpecImage(style, state);
	}

	public override string GetButtonSpecShortText(PaletteButtonSpecStyle style)
	{
		return _inherit.GetButtonSpecShortText(style);
	}

	public override string GetButtonSpecLongText(PaletteButtonSpecStyle style)
	{
		return _inherit.GetButtonSpecLongText(style);
	}

	public override Color GetButtonSpecColorMap(PaletteButtonSpecStyle style)
	{
		return _inherit.GetButtonSpecColorMap(style);
	}

	public override PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style)
	{
		return _inherit.GetButtonSpecStyle(style);
	}

	public override HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style)
	{
		return _inherit.GetButtonSpecLocation(style);
	}

	public override PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style)
	{
		return _inherit.GetButtonSpecEdge(style);
	}

	public override PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style)
	{
		return _inherit.GetButtonSpecOrientation(style);
	}
}
