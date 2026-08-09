#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonQATOverflow : ViewComposite
{
	private static readonly Padding _borderPadding = new Padding(3);

	private static readonly int QAT_HEIGHT_FULL = 28;

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaintDelegate;

	private IDisposable _memento;

	public ViewDrawRibbonQATOverflow(KryptonRibbon ribbon, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_needPaintDelegate = needPaintDelegate;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonQATOverflow:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _memento != null)
		{
			_memento.Dispose();
			_memento = null;
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize = CommonHelper.ApplyPadding(Orientation.Horizontal, preferredSize, _borderPadding);
		preferredSize.Height = Math.Max(preferredSize.Height, QAT_HEIGHT_FULL);
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Rectangle displayRectangle = context.DisplayRectangle;
		ClientRectangle = displayRectangle;
		context.DisplayRectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, ClientRectangle, _borderPadding);
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		_memento = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, ClientRectangle, PaletteState.Normal, _ribbon.StateCommon.RibbonQATOverflow, VisualOrientation.Top, composition: false, _memento);
	}
}
