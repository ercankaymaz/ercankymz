using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IContextMenuProvider
{
	bool HasParentProvider { get; }

	bool ProviderEnabled { get; }

	bool ProviderCanCloseMenu { get; }

	ToolStripDropDownCloseReason? ProviderCloseReason { get; set; }

	KryptonContextMenuPositionH ProviderShowHorz { get; set; }

	KryptonContextMenuPositionV ProviderShowVert { get; set; }

	ViewLayoutStack ProviderViewColumns { get; }

	ViewContextMenuManager ProviderViewManager { get; }

	PaletteContextMenuRedirect ProviderStateCommon { get; }

	PaletteContextMenuItemState ProviderStateDisabled { get; }

	PaletteContextMenuItemState ProviderStateNormal { get; }

	PaletteContextMenuItemStateHighlight ProviderStateHighlight { get; }

	PaletteContextMenuItemStateChecked ProviderStateChecked { get; }

	PaletteRedirectContextMenu ProviderImages { get; }

	IPalette ProviderPalette { get; }

	PaletteMode ProviderPaletteMode { get; }

	PaletteRedirect ProviderRedirector { get; }

	NeedPaintHandler ProviderNeedPaintDelegate { get; }

	event EventHandler Dispose;

	event CancelEventHandler Closing;

	event EventHandler<CloseReasonEventArgs> Close;

	void OnDispose(EventArgs e);

	void OnClosing(CancelEventArgs cea);

	void OnClose(CloseReasonEventArgs e);

	bool ProviderShowSubMenuFixed(KryptonContextMenuItem menuItem);

	Rectangle ProviderShowSubMenuFixedRect(KryptonContextMenuItem menuItem);
}
