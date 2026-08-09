#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonCenter : ViewComposite
{
	public override string ToString()
	{
		return "ViewLayoutRibbonCenter:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size preferredSize = current.GetPreferredSize(context);
					if (preferredSize.Width > ClientWidth)
					{
						preferredSize.Width = ClientWidth;
					}
					if (preferredSize.Height > ClientHeight)
					{
						preferredSize.Height = ClientHeight;
					}
					int num = (ClientWidth - preferredSize.Width) / 2;
					int num2 = (ClientHeight - preferredSize.Height) / 2;
					context.DisplayRectangle = new Rectangle(ClientRectangle.X + num, ClientRectangle.Y + num2, preferredSize.Width, preferredSize.Height);
					current.Layout(context);
				}
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}
}
