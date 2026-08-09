#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupClusterEdge : ViewDrawBorderEdge
{
	private KryptonRibbon _ribbon;

	private PaletteBorderEdge _palette;

	public ViewDrawRibbonGroupClusterEdge(KryptonRibbon ribbon, PaletteBorderEdge palette)
		: base(palette, Orientation.Vertical)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(palette != null);
		_ribbon = ribbon;
		_palette = palette;
	}

	public override void RenderBefore(RenderContext context)
	{
		base.RenderBefore(context);
		Rectangle displayRect = new Rectangle(ClientLocation.X, ClientLocation.Y + ClientWidth, ClientWidth, ClientHeight - ClientWidth * 2);
		context.Renderer.RenderRibbon.DrawRibbonClusterEdge(_ribbon.RibbonShape, context, displayRect, _palette, State);
	}
}
