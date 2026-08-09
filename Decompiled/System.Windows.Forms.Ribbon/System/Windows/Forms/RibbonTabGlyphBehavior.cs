using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms;

public class RibbonTabGlyphBehavior : Behavior
{
	private readonly RibbonDesigner _designer;

	public RibbonTabGlyphBehavior(RibbonDesigner designer, Ribbon ribbon)
	{
		_designer = designer;
	}

	public override bool OnMouseUp(Glyph g, MouseButtons button)
	{
		_designer.AddTabVerb(this, EventArgs.Empty);
		return base.OnMouseUp(g, button);
	}
}
