#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutStretch : ViewComposite
{
	private Orientation _orientation;

	public ViewLayoutStretch(Orientation orientation)
	{
		_orientation = orientation;
	}

	public override string ToString()
	{
		return "ViewLayoutStretch:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Rectangle displayRectangle = (ClientRectangle = context.DisplayRectangle);
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size preferredSize = current.GetPreferredSize(context);
					if (_orientation == Orientation.Vertical)
					{
						context.DisplayRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, preferredSize.Width, ClientRectangle.Height);
					}
					else
					{
						context.DisplayRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, preferredSize.Width, ClientRectangle.Height);
					}
					current.Layout(context);
				}
			}
		}
		context.DisplayRectangle = displayRectangle;
	}
}
