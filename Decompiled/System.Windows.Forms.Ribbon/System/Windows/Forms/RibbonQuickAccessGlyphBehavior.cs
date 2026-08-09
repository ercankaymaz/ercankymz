using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms;

public class RibbonQuickAccessGlyphBehavior : Behavior
{
	private readonly Ribbon _ribbon;

	private readonly RibbonDesigner _designer;

	public RibbonQuickAccessGlyphBehavior(RibbonDesigner designer, Ribbon ribbon)
	{
		_designer = designer;
		_ribbon = ribbon;
	}

	public override bool OnMouseUp(Glyph g, MouseButtons button)
	{
		_designer.CreateItem(_ribbon, _ribbon.QuickAccessToolbar.Items, typeof(RibbonButton));
		return base.OnMouseUp(g, button);
	}
}
