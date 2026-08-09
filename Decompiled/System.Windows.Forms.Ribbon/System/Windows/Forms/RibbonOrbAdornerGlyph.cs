using System.Drawing;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms;

public class RibbonOrbAdornerGlyph : Glyph
{
	private readonly BehaviorService _behaviorService;

	private readonly Ribbon _ribbon;

	private RibbonDesigner _componentDesigner;

	public bool MenuVisible { get; set; }

	public override Rectangle Bounds
	{
		get
		{
			Point point = _behaviorService.ControlToAdornerWindow(_ribbon);
			return new Rectangle(point.X + _ribbon.OrbBounds.Left, point.Y + _ribbon.OrbBounds.Top, _ribbon.OrbBounds.Height, _ribbon.OrbBounds.Height);
		}
	}

	public RibbonOrbAdornerGlyph(BehaviorService behaviorService, RibbonDesigner designer, Ribbon ribbon)
		: base(new RibbonOrbAdornerGlyphBehavior())
	{
		_behaviorService = behaviorService;
		_componentDesigner = designer;
		_ribbon = ribbon;
	}

	public override Cursor GetHitTest(Point p)
	{
		if (Bounds.Contains(p))
		{
			return Cursors.Hand;
		}
		return null;
	}

	public override void Paint(PaintEventArgs pe)
	{
	}
}
