#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonCenterPadding : ViewLayoutRibbonCenter
{
	private Padding _preferredPadding;

	public Padding PreferredPadding
	{
		get
		{
			return _preferredPadding;
		}
		set
		{
			_preferredPadding = value;
		}
	}

	public ViewLayoutRibbonCenterPadding(Padding preferredPadding)
	{
		_preferredPadding = preferredPadding;
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonCenterPadding:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size preferredSize = base.GetPreferredSize(context);
		return new Size(preferredSize.Width + _preferredPadding.Horizontal, preferredSize.Height + _preferredPadding.Vertical);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.X += PreferredPadding.Left;
		clientRectangle.Y += PreferredPadding.Top;
		clientRectangle.Width -= PreferredPadding.Horizontal;
		clientRectangle.Height -= PreferredPadding.Vertical;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size preferredSize = current.GetPreferredSize(context);
					if (preferredSize.Width > ClientRectangle.Width)
					{
						preferredSize.Width = ClientWidth;
					}
					if (preferredSize.Height > ClientRectangle.Height)
					{
						preferredSize.Height = ClientHeight;
					}
					int num = (clientRectangle.Width - preferredSize.Width) / 2;
					int num2 = (clientRectangle.Height - preferredSize.Height) / 2;
					context.DisplayRectangle = new Rectangle(clientRectangle.X + num, clientRectangle.Y + num2, preferredSize.Width, preferredSize.Height);
					current.Layout(context);
				}
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}
}
