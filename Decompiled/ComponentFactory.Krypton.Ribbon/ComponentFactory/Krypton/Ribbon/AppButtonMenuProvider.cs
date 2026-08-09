using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class AppButtonMenuProvider : IContextMenuProvider
{
	private bool _enabled;

	private bool _canCloseMenu;

	private IPalette _palette;

	private PaletteMode _paletteMode;

	private PaletteRedirect _redirector;

	private IContextMenuProvider _parent;

	private ViewLayoutStack _viewColumns;

	private NeedPaintHandler _needPaintDelegate;

	private ViewContextMenuManager _viewManager;

	private KryptonContextMenuPositionH _showHorz;

	private KryptonContextMenuPositionV _showVert;

	private PaletteContextMenuRedirect _stateCommon;

	private PaletteContextMenuItemState _stateDisabled;

	private PaletteContextMenuItemState _stateNormal;

	private PaletteRedirectContextMenu _redirectorImages;

	private PaletteContextMenuItemStateHighlight _stateHighlight;

	private PaletteContextMenuItemStateChecked _stateChecked;

	private ToolStripDropDownCloseReason? _closeReason;

	private KryptonContextMenuItemCollection _menuCollection;

	private ViewBase _fixedViewElement;

	public ViewBase FixedViewBase
	{
		get
		{
			return _fixedViewElement;
		}
		set
		{
			_fixedViewElement = value;
		}
	}

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

	public AppButtonMenuProvider(ViewContextMenuManager viewManager, KryptonContextMenuItemCollection menuCollection, ViewLayoutStack viewColumns, IPalette palette, PaletteMode paletteMode, PaletteRedirect redirector, NeedPaintHandler needPaintDelegate)
	{
		_viewManager = viewManager;
		_menuCollection = menuCollection;
		_viewColumns = viewColumns;
		_palette = palette;
		_paletteMode = paletteMode;
		_redirector = redirector;
		_needPaintDelegate = needPaintDelegate;
		_parent = null;
		_enabled = true;
		_canCloseMenu = true;
		_showHorz = KryptonContextMenuPositionH.After;
		_showVert = KryptonContextMenuPositionV.Top;
		_stateCommon = new PaletteContextMenuRedirect(redirector, needPaintDelegate);
		_stateNormal = new PaletteContextMenuItemState(_stateCommon);
		_stateDisabled = new PaletteContextMenuItemState(_stateCommon);
		_stateHighlight = new PaletteContextMenuItemStateHighlight(_stateCommon);
		_stateChecked = new PaletteContextMenuItemStateChecked(_stateCommon);
		_redirectorImages = new PaletteRedirectContextMenu(redirector, new ContextMenuImages(needPaintDelegate));
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
			_closeReason = e.CloseReason;
			this.Close(this, e);
		}
	}

	public bool ProviderShowSubMenuFixed(KryptonContextMenuItem menuItem)
	{
		return FixedViewBase != null && _menuCollection.Contains(menuItem);
	}

	public Rectangle ProviderShowSubMenuFixedRect(KryptonContextMenuItem menuItem)
	{
		if (ProviderShowSubMenuFixed(menuItem))
		{
			Rectangle result = _fixedViewElement.OwningControl.RectangleToScreen(_fixedViewElement.ClientRectangle);
			result.Y++;
			result.Width -= 3;
			result.Height -= 4;
			return result;
		}
		return Rectangle.Empty;
	}
}
