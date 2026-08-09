#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGalleryButtons : ViewComposite
{
	public override string ToString()
	{
		return "ViewLayoutRibbonGalleryButtons:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size empty = Size.Empty;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				Size preferredSize = current.GetPreferredSize(context);
				empty.Height += preferredSize.Width;
				empty.Width = Math.Max(empty.Width, preferredSize.Width);
			}
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		int num = 0;
		int num2 = ClientHeight / Count + 1;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current == this[Count - 1])
				{
					num2 = ClientHeight - num;
				}
				context.DisplayRectangle = new Rectangle(ClientLocation.X, num, ClientWidth, num2);
				current.Layout(context);
				num += num2 - 1;
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}
}
