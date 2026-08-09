#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupClusterSeparator : ViewLeaf
{
	private static readonly Size _preferredSize = new Size(1, 4);

	private KryptonRibbon _ribbon;

	private bool _start;

	public ViewDrawRibbonGroupClusterSeparator(KryptonRibbon ribbon, bool start)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_start = start;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupClusterSeparator:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Rectangle clientRectangle = ClientRectangle;
		if (_start)
		{
			clientRectangle.X -= 4;
		}
		clientRectangle.Width += 4;
		context.Renderer.RenderGlyph.DrawRibbonGroupSeparator(_ribbon.RibbonShape, context, clientRectangle, _ribbon.StateCommon.RibbonGeneral, State);
	}
}
