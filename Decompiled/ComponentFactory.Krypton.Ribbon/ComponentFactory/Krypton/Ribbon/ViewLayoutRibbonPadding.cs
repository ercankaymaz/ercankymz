using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonPadding : ViewComposite
{
	private Padding _preferredPadding;

	public ViewLayoutRibbonPadding(Padding preferredPadding)
	{
		_preferredPadding = preferredPadding;
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonPadding:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size preferredSize = base.GetPreferredSize(context);
		return new Size(preferredSize.Width + _preferredPadding.Horizontal, preferredSize.Height + _preferredPadding.Vertical);
	}

	public override void Layout(ViewLayoutContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		context.DisplayRectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, ClientRectangle, _preferredPadding);
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}
}
