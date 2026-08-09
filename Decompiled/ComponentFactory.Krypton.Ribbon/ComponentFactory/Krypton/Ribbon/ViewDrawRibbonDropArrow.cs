#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDropArrow : ViewLeaf
{
	private static readonly Size _arrowSize = new Size(5, 4);

	private KryptonRibbon _ribbon;

	public ViewDrawRibbonDropArrow(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDropArrow:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _arrowSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		context.Renderer.RenderGlyph.DrawRibbonDropArrow(_ribbon.RibbonShape, context, ClientRectangle, _ribbon.StateCommon.RibbonGeneral, State);
	}
}
