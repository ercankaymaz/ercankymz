#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonTabsSpare : ViewLeaf
{
	public override string ToString()
	{
		return "ViewLayoutRibbonTabsSpare:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return Size.Empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
	}
}
