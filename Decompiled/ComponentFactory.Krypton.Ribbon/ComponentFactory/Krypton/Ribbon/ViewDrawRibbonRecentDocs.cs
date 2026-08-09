#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonRecentDocs : ViewLeaf, IContentValues
{
	private KryptonRibbon _ribbon;

	private RibbonRecentDocsTitleToContent _contentProvider;

	private IDisposable _memento;

	public ViewDrawRibbonRecentDocs(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_contentProvider = new RibbonRecentDocsTitleToContent(ribbon.StateCommon.RibbonGeneral, ribbon.StateCommon.RibbonAppMenuDocsTitle);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonRecentDocs:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _memento != null)
		{
			_memento.Dispose();
			_memento = null;
			_contentProvider.Dispose();
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _contentProvider, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		if (_memento != null)
		{
			_memento.Dispose();
			_memento = null;
		}
		_memento = context.Renderer.RenderStandardContent.LayoutContent(context, ClientRectangle, _contentProvider, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
	}

	public override void RenderBefore(RenderContext context)
	{
		if (_memento != null)
		{
			context.Renderer.RenderStandardContent.DrawContent(context, ClientRectangle, _contentProvider, _memento, VisualOrientation.Top, PaletteState.Normal, composition: false, allowFocusRect: true);
		}
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
		if (!string.IsNullOrEmpty(_ribbon.RibbonStrings.RecentDocuments))
		{
			return _ribbon.RibbonStrings.RecentDocuments;
		}
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
