using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonPanel : ViewDrawPanel
{
	private static readonly int EDGE_GAP = 1;

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _paintDelegate;

	private Blend _compBlend;

	private bool DrawOnComposition
	{
		get
		{
			if (_ribbon != null)
			{
				return _ribbon.CaptionArea.DrawCaptionOnComposition;
			}
			return false;
		}
	}

	public ViewDrawRibbonPanel(KryptonRibbon ribbon, IPaletteBack paletteBack, NeedPaintHandler paintDelegate)
		: base(paletteBack)
	{
		_ribbon = ribbon;
		_paintDelegate = paintDelegate;
		_compBlend = new Blend();
		_compBlend.Positions = new float[3] { 0f, 0.4f, 1f };
		_compBlend.Factors = new float[3] { 0f, 0.87f, 1f };
	}

	public override void RenderBefore(RenderContext context)
	{
		if (DrawOnComposition && _ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			int clientHeight = _ribbon.TabsArea.ClientHeight;
			using (new Clipping(context.Graphics, new Rectangle(ClientLocation.X, ClientLocation.Y + clientHeight, ClientWidth, ClientHeight - clientHeight)))
			{
				base.RenderBefore(context);
			}
			PaintRectangle(context.Graphics, new Rectangle(ClientLocation.X, ClientLocation.Y, ClientWidth, clientHeight), edges: true, null);
		}
		else
		{
			base.RenderBefore(context);
		}
	}

	public void PaintRectangle(Graphics g, Rectangle rect, bool edges, Control sender)
	{
		if (!DrawOnComposition || _ribbon.RibbonShape != PaletteRibbonShape.Office2010)
		{
			return;
		}
		if (edges)
		{
			rect.X += EDGE_GAP;
			rect.Width -= EDGE_GAP * 2;
		}
		else if (sender != null && !_ribbon.MinimizedMode)
		{
			using ViewDrawRibbonGroupsBorder viewDrawRibbonGroupsBorder = new ViewDrawRibbonGroupsBorder(_ribbon, borderOutside: false, _paintDelegate);
			viewDrawRibbonGroupsBorder.ClientRectangle = new Rectangle(-sender.Location.X, rect.Bottom - 1, _ribbon.Width, 10);
			using RenderContext context = new RenderContext(_ribbon, g, rect, _ribbon.Renderer);
			viewDrawRibbonGroupsBorder.Render(context);
		}
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(rect.X, rect.Y - 1, rect.Width, rect.Height + 1), Color.Transparent, Color.White, 90f);
		linearGradientBrush.Blend = _compBlend;
		g.FillRectangle(linearGradientBrush, new Rectangle(rect.X, rect.Y, rect.Width, rect.Height - 1));
	}
}
