#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMenuColorColumn : ViewComposite
{
	public ViewDrawMenuColorColumn(IContextMenuProvider provider, KryptonContextMenuColorColumns colorColumns, Color[] colors, int start, int end, bool enabled)
	{
		ViewLayoutColorStack viewLayoutColorStack = new ViewLayoutColorStack();
		for (int i = start; i < end; i++)
		{
			viewLayoutColorStack.Add(new ViewDrawMenuColorBlock(provider, colorColumns, colors[i], i == start, i == end - 1, enabled));
		}
		Add(viewLayoutColorStack);
	}

	public override string ToString()
	{
		return "ViewDrawMenuColorColumn:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		using SolidBrush brush = new SolidBrush(Color.FromArgb(197, 197, 197));
		context.Graphics.FillRectangle(brush, ClientRectangle);
	}
}
