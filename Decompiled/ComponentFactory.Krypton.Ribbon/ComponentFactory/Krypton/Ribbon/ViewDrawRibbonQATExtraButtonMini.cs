#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonQATExtraButtonMini : ViewDrawRibbonQATExtraButton
{
	private static readonly int MINI_BUTTON_HEIGHT = 22;

	private static readonly int MINI_BUTTON_OFFSET = 24;

	public ViewDrawRibbonQATExtraButtonMini(KryptonRibbon ribbon, NeedPaintHandler needPaint)
		: base(ribbon, needPaint)
	{
	}

	public override string ToString()
	{
		return "ViewDrawRibbonQATExtraButtonMini:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Rectangle displayRectangle = context.DisplayRectangle;
		displayRectangle.Y = displayRectangle.Bottom - 1 - MINI_BUTTON_OFFSET;
		displayRectangle.Height = MINI_BUTTON_HEIGHT;
		context.DisplayRectangle = displayRectangle;
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}
}
