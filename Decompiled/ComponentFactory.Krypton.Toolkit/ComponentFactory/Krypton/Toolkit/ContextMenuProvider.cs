using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ContextMenuProvider : IContextMenuProvider
{
	private bool _enabled;

	private ViewLayoutStack _viewColumns;

	private ViewContextMenuManager _viewManager;

	private PaletteContextMenuRedirect _stateCommon;

	private PaletteContextMenuItemState _stateDisabled;

	private PaletteContextMenuItemState _stateNormal;

	private PaletteContextMenuItemStateHighlight _stateHighlight;

	private PaletteContextMenuItemStateChecked _stateChecked;

	private PaletteRedirectContextMenu _redirectorImages;

	private IPalette _palette;

	private PaletteMode _paletteMode;

	private PaletteRedirect _redirector;

	private NeedPaintHandler _needPaintDelegate;

	private IContextMenuProvider _parent;

	private ToolStripDropDownCloseReason? _closeReason;

	private KryptonContextMenuPositionH _showHorz;

	private KryptonContextMenuPositionV _showVert;

	private bool _canCloseMenu;

	public bool HasParentProvider => _parent != null;

	public bool ProviderEnabled => _enabled;

	public bool ProviderCanCloseMenu => _canCloseMenu;

	public ToolStripDropDownCloseReason? ProviderCloseReason
	{
		get
		{
			if (_parent != null)
			{
				return _parent.ProviderCloseReason;
			}
			return _closeReason;
		}
		set
		{
			if (_parent != null)
			{
				_parent.ProviderCloseReason = value;
			}
			else
			{
				_closeReason = value;
			}
		}
	}

	public KryptonContextMenuPositionH ProviderShowHorz
	{
		get
		{
			return _showHorz;
		}
		set
		{
			_showHorz = value;
		}
	}

	public KryptonContextMenuPositionV ProviderShowVert
	{
		get
		{
			return _showVert;
		}
		set
		{
			_showVert = value;
		}
	}

	public ViewLayoutStack ProviderViewColumns => _viewColumns;

	public ViewContextMenuManager ProviderViewManager => _viewManager;

	public PaletteContextMenuRedirect ProviderStateCommon => _stateCommon;

	public PaletteContextMenuItemState ProviderStateDisabled => _stateDisabled;

	public PaletteContextMenuItemState ProviderStateNormal => _stateNormal;

	public PaletteContextMenuItemStateHighlight ProviderStateHighlight => _stateHighlight;

	public PaletteContextMenuItemStateChecked ProviderStateChecked => _stateChecked;

	public PaletteRedirectContextMenu ProviderImages => _redirectorImages;

	public IPalette ProviderPalette => _palette;

	public PaletteMode ProviderPaletteMode => _paletteMode;

	public PaletteRedirect ProviderRedirector => _redirector;

	public NeedPaintHandler ProviderNeedPaintDelegate => _needPaintDelegate;

	public event EventHandler Dispose;

	public event CancelEventHandler Closing;

	public event EventHandler<CloseReasonEventArgs> Close;

	public ContextMenuProvider(IContextMenuProvider provider, ViewContextMenuManager viewManager, ViewLayoutStack viewColumns, NeedPaintHandler needPaintDelegate)
	{
		_parent = provider;
		_enabled = provider.ProviderEnabled;
		_canCloseMenu = provider.ProviderCanCloseMenu;
		_viewManager = viewManager;
		_viewColumns = viewColumns;
		_stateCommon = provider.ProviderStateCommon;
		_stateDisabled = provider.ProviderStateDisabled;
		_stateNormal = provider.ProviderStateNormal;
		_stateHighlight = provider.ProviderStateHighlight;
		_stateChecked = provider.ProviderStateChecked;
		_redirectorImages = provider.ProviderImages;
		_palette = provider.ProviderPalette;
		_paletteMode = provider.ProviderPaletteMode;
		_redirector = provider.ProviderRedirector;
		_needPaintDelegate = needPaintDelegate;
		_showHorz = provider.ProviderShowHorz;
		_showVert = provider.ProviderShowVert;
	}

	public ContextMenuProvider(KryptonContextMenu contextMenu, ViewContextMenuManager viewManager, ViewLayoutStack viewColumns, IPalette palette, PaletteMode paletteMode, PaletteRedirect redirector, PaletteRedirectContextMenu redirectorImages, NeedPaintHandler needPaintDelegate, bool enabled)
	{
		_showHorz = KryptonContextMenuPositionH.Left;
		_showVert = KryptonContextMenuPositionV.Below;
		_enabled = enabled;
		_viewManager = viewManager;
		_viewColumns = viewColumns;
		_stateCommon = contextMenu.StateCommon;
		_stateDisabled = contextMenu.StateDisabled;
		_stateNormal = contextMenu.StateNormal;
		_stateHighlight = contextMenu.StateHighlight;
		_stateChecked = contextMenu.StateChecked;
		_redirectorImages = redirectorImages;
		_palette = palette;
		_paletteMode = paletteMode;
		_redirector = redirector;
		_needPaintDelegate = needPaintDelegate;
		_canCloseMenu = true;
	}

	public ContextMenuProvider(ViewContextMenuManager viewManager, ViewLayoutStack viewColumns, IPalette palette, PaletteMode paletteMode, PaletteContextMenuRedirect stateCommon, PaletteContextMenuItemState stateDisabled, PaletteContextMenuItemState stateNormal, PaletteContextMenuItemStateHighlight stateHighlight, PaletteContextMenuItemStateChecked stateChecked, PaletteRedirect redirector, PaletteRedirectContextMenu redirectorImages, NeedPaintHandler needPaintDelegate, bool enabled)
	{
		_showHorz = KryptonContextMenuPositionH.Left;
		_showVert = KryptonContextMenuPositionV.Below;
		_enabled = enabled;
		_viewManager = viewManager;
		_viewColumns = viewColumns;
		_stateCommon = stateCommon;
		_stateDisabled = stateDisabled;
		_stateNormal = stateNormal;
		_stateHighlight = stateHighlight;
		_stateChecked = stateChecked;
		_redirectorImages = redirectorImages;
		_palette = palette;
		_paletteMode = paletteMode;
		_redirector = redirector;
		_needPaintDelegate = needPaintDelegate;
	}

	public void OnDispose(EventArgs e)
	{
		if (this.Dispose != null)
		{
			this.Dispose(this, e);
		}
	}

	public void OnClosing(CancelEventArgs cea)
	{
		if (_parent != null)
		{
			_parent.OnClosing(cea);
		}
		else if (this.Closing != null)
		{
			this.Closing(this, cea);
		}
	}

	public void OnClose(CloseReasonEventArgs e)
	{
		if (_parent != null)
		{
			_parent.OnClose(e);
		}
		else if (this.Close != null)
		{
			this.Close(this, e);
		}
	}

	public bool ProviderShowSubMenuFixed(KryptonContextMenuItem menuItem)
	{
		if (HasParentProvider)
		{
			return _parent.ProviderShowSubMenuFixed(menuItem);
		}
		return false;
	}

	public Rectangle ProviderShowSubMenuFixedRect(KryptonContextMenuItem menuItem)
	{
		if (HasParentProvider)
		{
			return _parent.ProviderShowSubMenuFixedRect(menuItem);
		}
		return Rectangle.Empty;
	}
}
