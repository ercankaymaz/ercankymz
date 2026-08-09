using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms;

public class RibbonPanelGlyphBehavior : Behavior
{
	private RibbonTab _tab;

	private readonly RibbonTabDesigner _designer;

	public RibbonPanelGlyphBehavior(RibbonTabDesigner designer, RibbonTab tab)
	{
		_designer = designer;
		_tab = tab;
	}

	public override bool OnMouseUp(Glyph g, MouseButtons button)
	{
		_designer.AddPanel(this, EventArgs.Empty);
		return base.OnMouseUp(g, button);
	}
}
