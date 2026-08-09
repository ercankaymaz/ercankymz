#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawEmptyContent : ViewDrawContent, IContentValues
{
	private IPaletteContent _paletteContentNormal;

	private IPaletteContent _paletteContentDisabled;

	public ViewDrawEmptyContent(IPaletteContent paletteContentDisabled, IPaletteContent paletteContentNormal)
		: base(paletteContentNormal, null, VisualOrientation.Top)
	{
		base.Values = this;
		_paletteContentDisabled = paletteContentDisabled;
		_paletteContentNormal = paletteContentNormal;
	}

	public override string ToString()
	{
		return "ViewDrawEmptyContent:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (Enabled)
		{
			SetPalette(_paletteContentNormal);
		}
		else
		{
			SetPalette(_paletteContentDisabled);
		}
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (Enabled)
		{
			SetPalette(_paletteContentNormal);
		}
		else
		{
			SetPalette(_paletteContentDisabled);
		}
		base.Layout(context);
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (Enabled)
		{
			SetPalette(_paletteContentNormal);
		}
		else
		{
			SetPalette(_paletteContentDisabled);
		}
		base.RenderBefore(context);
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
