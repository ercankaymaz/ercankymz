#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonAppMenuRecentDec : ViewDrawCanvas
{
	private int _maxWidth;

	private string _shortcutText;

	private IContextMenuProvider _provider;

	private KryptonRibbonRecentDoc _recentDoc;

	public KryptonRibbonRecentDoc RecentDoc => _recentDoc;

	public string ShortcutText => _shortcutText;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public IContextMenuProvider Provider => _provider;

	public ViewDrawRibbonAppMenuRecentDec(KryptonRibbon ribbon, IContextMenuProvider provider, KryptonRibbonRecentDoc recentDoc, int maxWidth, NeedPaintHandler needPaintDelegate, int index)
		: base(provider.ProviderStateNormal.ItemHighlight.Back, provider.ProviderStateNormal.ItemHighlight.Border, provider.ProviderStateNormal.ItemHighlight, PaletteMetricPadding.ContextMenuItemHighlight, VisualOrientation.Top)
	{
		_maxWidth = maxWidth;
		_provider = provider;
		_recentDoc = recentDoc;
		_shortcutText = ((index < 10) ? ("&" + index) : "A");
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker { 
		{
			new ViewLayoutSeparator(5),
			ViewDockStyle.Right
		} };
		FixedContentValue values = new FixedContentValue(recentDoc.Text, recentDoc.ExtraText, recentDoc.Image, recentDoc.ImageTransparentColor);
		RibbonRecentDocsEntryToContent paletteContent = new RibbonRecentDocsEntryToContent(ribbon.StateCommon.RibbonGeneral, ribbon.StateCommon.RibbonAppMenuDocsEntry);
		ViewDrawContent item = new ViewDrawContent(paletteContent, values, VisualOrientation.Top);
		viewLayoutDocker.Add(item, ViewDockStyle.Fill);
		viewLayoutDocker.Add(new ViewLayoutSeparator(5), ViewDockStyle.Left);
		FixedContentValue values2 = new FixedContentValue(_shortcutText, null, null, Color.Empty);
		RibbonRecentDocsShortcutToContent paletteContent2 = new RibbonRecentDocsShortcutToContent(ribbon.StateCommon.RibbonGeneral, ribbon.StateCommon.RibbonAppMenuDocsEntry);
		ViewDrawRibbonRecentShortcut item2 = new ViewDrawRibbonRecentShortcut(paletteContent2, values2);
		viewLayoutDocker.Add(item2, ViewDockStyle.Left);
		viewLayoutDocker.Add(new ViewLayoutSeparator(3), ViewDockStyle.Left);
		SourceController = (ISourceController)(KeyController = (IKeyController)(MouseController = new RecentDocController(_provider.ProviderViewManager, this, needPaintDelegate)));
		Add(viewLayoutDocker);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonAppMenuRecentDec:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize.Width = Math.Min(_maxWidth, preferredSize.Width);
		return preferredSize;
	}

	public void Closing(CancelEventArgs cea)
	{
		_provider.OnClosing(cea);
	}

	public void Close(CloseReasonEventArgs e)
	{
		_provider.OnClose(e);
	}
}
