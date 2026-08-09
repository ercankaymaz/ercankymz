#define DEBUG
using System;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonRecentShortcut : ViewDrawContent
{
	public ViewDrawRibbonRecentShortcut(IPaletteContent paletteContent, IContentValues values)
		: base(paletteContent, values, VisualOrientation.Top)
	{
	}

	public override string ToString()
	{
		return "ViewDrawRibbonRecentShortcut:" + base.Id;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		string shortText = base.Values.GetShortText();
		if (!string.IsNullOrEmpty(shortText) && !shortText.Equals("A"))
		{
			base.RenderBefore(context);
		}
	}
}
