#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutStack : ViewComposite
{
	private bool _horizontal;

	private bool _fillLastChild;

	public bool Horizontal
	{
		get
		{
			return _horizontal;
		}
		set
		{
			_horizontal = value;
		}
	}

	public bool FillLastChild
	{
		get
		{
			return _fillLastChild;
		}
		set
		{
			_fillLastChild = value;
		}
	}

	public ViewLayoutStack(bool horizontal)
	{
		_horizontal = horizontal;
		_fillLastChild = true;
	}

	public override string ToString()
	{
		return "ViewLayoutStack:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size empty = Size.Empty;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size preferredSize = current.GetPreferredSize(context);
					if (Horizontal)
					{
						empty.Height = Math.Max(empty.Height, preferredSize.Height);
						empty.Width += preferredSize.Width;
					}
					else
					{
						empty.Height += preferredSize.Height;
						empty.Width = Math.Max(empty.Width, preferredSize.Width);
					}
				}
			}
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		Rectangle clientRectangle = ClientRectangle;
		ViewBase viewBase = null;
		foreach (ViewBase item in Reverse())
		{
			if (item.Visible)
			{
				viewBase = item;
				break;
			}
		}
		using (IEnumerator<ViewBase> enumerator2 = GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				ViewBase current2 = enumerator2.Current;
				if (!current2.Visible)
				{
					continue;
				}
				context.DisplayRectangle = clientRectangle;
				Size preferredSize = current2.GetPreferredSize(context);
				if (Horizontal)
				{
					preferredSize.Height = clientRectangle.Height;
					if (current2 == viewBase && FillLastChild)
					{
						preferredSize.Width = clientRectangle.Width;
					}
					else
					{
						clientRectangle.X += preferredSize.Width;
						clientRectangle.Width -= preferredSize.Width;
					}
				}
				else
				{
					preferredSize.Width = clientRectangle.Width;
					if (current2 == viewBase && FillLastChild)
					{
						preferredSize.Height = clientRectangle.Height;
					}
					else
					{
						clientRectangle.Y += preferredSize.Height;
						clientRectangle.Height -= preferredSize.Height;
					}
				}
				context.DisplayRectangle = new Rectangle(context.DisplayRectangle.Location, preferredSize);
				current2.Layout(context);
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}
}
