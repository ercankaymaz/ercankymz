#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutPadding : ViewComposite
{
	private Padding _displayPadding;

	public ViewLayoutPadding()
		: this(Padding.Empty, null)
	{
	}

	public ViewLayoutPadding(Padding displayPadding)
		: this(displayPadding, null)
	{
	}

	public ViewLayoutPadding(Padding displayPadding, ViewBase child)
	{
		_displayPadding = displayPadding;
		Add(child);
	}

	public override string ToString()
	{
		return "ViewLayoutPadding:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize.Width += _displayPadding.Horizontal;
		preferredSize.Height += _displayPadding.Vertical;
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		context.DisplayRectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, ClientRectangle, _displayPadding);
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					current.Layout(context);
				}
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}
}
