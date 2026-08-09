#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewLayoutColorStack : ViewLayoutStack
{
	public ViewLayoutColorStack()
		: base(horizontal: false)
	{
	}

	public override string ToString()
	{
		return "ViewLayoutColorStack:" + base.Id;
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		RenderBefore(context);
		RenderAfter(context);
	}

	public override void RenderBefore(RenderContext context)
	{
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (current.Visible && current.ClientRectangle.IntersectsWith(context.ClipRect))
			{
				current.RenderBefore(context);
			}
		}
	}

	public override void RenderAfter(RenderContext context)
	{
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (current.Visible && current.ClientRectangle.IntersectsWith(context.ClipRect))
			{
				current.RenderAfter(context);
			}
		}
	}
}
