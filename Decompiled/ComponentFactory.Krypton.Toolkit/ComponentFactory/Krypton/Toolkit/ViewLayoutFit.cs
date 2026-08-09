#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutFit : ViewComposite
{
	private Orientation _orientation;

	public ViewLayoutFit(Orientation orientation)
	{
		_orientation = orientation;
	}

	public override string ToString()
	{
		return "ViewLayoutFit:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Rectangle displayRectangle = (ClientRectangle = context.DisplayRectangle);
		int num = 0;
		int num2 = ((_orientation == Orientation.Vertical) ? ClientHeight : ClientWidth);
		for (int i = 0; i < Count; i++)
		{
			ViewBase viewBase = this[i];
			int num3 = 0;
			num3 = ((i != Count - 1) ? (num2 / (Count - i)) : num2);
			Size preferredSize = viewBase.GetPreferredSize(context);
			if (_orientation == Orientation.Vertical)
			{
				context.DisplayRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y + num, preferredSize.Width, num3);
			}
			else
			{
				context.DisplayRectangle = new Rectangle(ClientRectangle.X + num, ClientRectangle.Y, num3, ClientRectangle.Height);
			}
			viewBase.Layout(context);
			num += num3;
			num2 -= num3;
		}
		context.DisplayRectangle = displayRectangle;
	}
}
