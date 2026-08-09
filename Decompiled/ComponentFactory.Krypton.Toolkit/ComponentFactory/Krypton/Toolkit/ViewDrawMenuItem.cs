#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuItem : ViewDrawCanvas
{
	private static Image _empty16x16;

	private IContextMenuProvider _provider;

	private KryptonContextMenuItem _menuItem;

	private ViewDrawMenuImageCanvas _imageCanvas;

	private ViewDrawMenuSeparator _splitSeparator;

	private ViewDrawContent _imageContent;

	private ViewDrawMenuItemContent _textContent;

	private FixedContentValue _fixedImage;

	private VisualContextMenu _contextMenu;

	private ViewDrawMenuItemContent _shortcutContent;

	private ViewDrawMenuItemContent _subMenuContent;

	private FixedContentValue _fixedTextExtraText;

	private KryptonCommand _cachedCommand;

	private bool _imageColumn;

	private bool _standardStyle;

	private bool _itemEnabled;

	private bool _hasSubMenu;

	public KryptonContextMenuItem KryptonContextMenuItem => _menuItem;

	public ViewDrawMenuSeparator SplitSeparator => _splitSeparator;

	public bool ItemEnabled => _itemEnabled;

	public string ItemText => _textContent.Values.GetShortText();

	public string ItemExtraText => _textContent.Values.GetLongText();

	public bool ResolveEnabled
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.Enabled;
			}
			return _menuItem.Enabled;
		}
	}

	public Image ResolveImage
	{
		get
		{
			if (_cachedCommand != null)
			{
				if (_menuItem.LargeKryptonCommandImage)
				{
					return _cachedCommand.ImageLarge;
				}
				return _cachedCommand.ImageSmall;
			}
			return _menuItem.Image;
		}
	}

	public Color ResolveImageTransparentColor
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.ImageTransparentColor;
			}
			return _menuItem.ImageTransparentColor;
		}
	}

	public string ResolveText
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.Text;
			}
			return _menuItem.Text;
		}
	}

	public string ResolveExtraText
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.ExtraText;
			}
			return _menuItem.ExtraText;
		}
	}

	public bool ResolveChecked
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.Checked;
			}
			return _menuItem.Checked;
		}
	}

	public CheckState ResolveCheckState
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.CheckState;
			}
			return _menuItem.CheckState;
		}
	}

	public bool HasSubMenu => _hasSubMenu;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public bool HasParentMenu => _provider.HasParentProvider;

	static ViewDrawMenuItem()
	{
		_empty16x16 = Resources.Empty16x16;
	}

	public ViewDrawMenuItem(IContextMenuProvider provider, KryptonContextMenuItem menuItem, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
		: base(menuItem.StateNormal.ItemHighlight.Back, menuItem.StateNormal.ItemHighlight.Border, menuItem.StateNormal.ItemHighlight, PaletteMetricPadding.ContextMenuItemHighlight, VisualOrientation.Top)
	{
		_provider = provider;
		_menuItem = menuItem;
		_imageColumn = imageColumn;
		_standardStyle = standardStyle;
		_menuItem.SetPaletteRedirect(provider);
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		_itemEnabled = provider.ProviderEnabled && ResolveEnabled;
		PaletteContextMenuItemState paletteContextMenuItemState = (_itemEnabled ? _menuItem.StateNormal : _menuItem.StateDisabled);
		Image image = ResolveImage;
		Color imageTransparentColor = ResolveImageTransparentColor;
		if (image != null)
		{
			if (_imageColumn)
			{
				image = _empty16x16;
				imageTransparentColor = Color.Magenta;
			}
			switch (ResolveCheckState)
			{
			case CheckState.Checked:
				image = provider.ProviderImages.GetContextMenuCheckedImage();
				imageTransparentColor = Color.Empty;
				break;
			case CheckState.Indeterminate:
				image = provider.ProviderImages.GetContextMenuIndeterminateImage();
				imageTransparentColor = Color.Empty;
				break;
			}
		}
		PaletteTripleJustImage paletteTripleJustImage = (ResolveChecked ? _menuItem.StateChecked.ItemImage : paletteContextMenuItemState.ItemImage);
		_fixedImage = new FixedContentValue(null, null, image, imageTransparentColor);
		_imageContent = new ViewDrawContent(paletteTripleJustImage.Content, _fixedImage, VisualOrientation.Top);
		_imageCanvas = new ViewDrawMenuImageCanvas(paletteTripleJustImage.Back, paletteTripleJustImage.Border, 0, zeroHeight: false);
		_imageCanvas.Add(_imageContent);
		viewLayoutDocker.Add(new ViewLayoutCenter(_imageCanvas), ViewDockStyle.Left);
		_imageContent.Enabled = _itemEnabled;
		PaletteContentJustText palette = (standardStyle ? paletteContextMenuItemState.ItemTextStandard : paletteContextMenuItemState.ItemTextAlternate);
		_fixedTextExtraText = new FixedContentValue(ResolveText, ResolveExtraText, null, Color.Empty);
		_textContent = new ViewDrawMenuItemContent(palette, _fixedTextExtraText, 1);
		viewLayoutDocker.Add(_textContent, ViewDockStyle.Fill);
		_textContent.Enabled = _itemEnabled;
		if (_menuItem.ShowShortcutKeys)
		{
			string text = _menuItem.ShortcutKeyDisplayString;
			if (string.IsNullOrEmpty(text))
			{
				text = ((_menuItem.ShortcutKeys != Keys.None) ? new KeysConverter().ConvertToString(_menuItem.ShortcutKeys) : string.Empty);
			}
			if (text.Length > 0)
			{
				_shortcutContent = new ViewDrawMenuItemContent(paletteContextMenuItemState.ItemShortcutText, new FixedContentValue(text, null, null, Color.Empty), 2);
				viewLayoutDocker.Add(_shortcutContent, ViewDockStyle.Right);
				_shortcutContent.Enabled = _itemEnabled;
			}
		}
		_splitSeparator = new ViewDrawMenuSeparator(paletteContextMenuItemState.ItemSplit);
		viewLayoutDocker.Add(_splitSeparator, ViewDockStyle.Right);
		_splitSeparator.Enabled = _itemEnabled;
		_splitSeparator.Draw = _menuItem.Items.Count > 0 && _menuItem.SplitSubMenu;
		_hasSubMenu = _menuItem.Items.Count > 0;
		_subMenuContent = new ViewDrawMenuItemContent(paletteContextMenuItemState.ItemImage.Content, new FixedContentValue(null, null, (!_hasSubMenu) ? _empty16x16 : provider.ProviderImages.GetContextMenuSubMenuImage(), (_menuItem.Items.Count == 0) ? Color.Magenta : Color.Empty), 3);
		viewLayoutDocker.Add(new ViewLayoutCenter(_subMenuContent), ViewDockStyle.Right);
		_subMenuContent.Enabled = _itemEnabled;
		Add(viewLayoutDocker);
		KeyController = (IKeyController)(MouseController = new MenuItemController(provider.ProviderViewManager, this, provider.ProviderNeedPaintDelegate));
		_menuItem.PropertyChanged += OnPropertyChanged;
		if (_menuItem.KryptonCommand != null)
		{
			_cachedCommand = _menuItem.KryptonCommand;
			_menuItem.KryptonCommand.PropertyChanged += OnCommandPropertyChanged;
		}
	}

	public override string ToString()
	{
		return "ViewDrawMenuItem:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_menuItem.PropertyChanged -= OnPropertyChanged;
			if (_cachedCommand != null)
			{
				_cachedCommand.PropertyChanged -= OnCommandPropertyChanged;
				_cachedCommand = null;
			}
		}
		base.Dispose(disposing);
	}

	public bool PointInSubMenu(Point pt)
	{
		if (HasSubMenu)
		{
			if (_splitSeparator.Draw)
			{
				return pt.X > _splitSeparator.ClientRectangle.X;
			}
			return true;
		}
		return false;
	}

	public void Closing(CancelEventArgs cea)
	{
		_provider.OnClosing(cea);
	}

	public void Close(CloseReasonEventArgs e)
	{
		_provider.OnClose(e);
	}

	public void DisposeContextMenu()
	{
		_provider.OnDispose(EventArgs.Empty);
	}

	public void ShowSubMenu(bool keyboardActivated)
	{
		if (_contextMenu != null && !_contextMenu.IsDisposed)
		{
			return;
		}
		_provider.ProviderViewManager.SetTargetSubMenu((IContextMenuTarget)KeyController);
		if (HasSubMenu)
		{
			_contextMenu = new VisualContextMenu(_provider, _menuItem.Items, keyboardActivated);
			_contextMenu.Disposed += OnContextMenuDisposed;
			Rectangle screenRect = OwningControl.RectangleToScreen(ClientRectangle);
			if (_provider.ProviderShowSubMenuFixed(_menuItem))
			{
				_contextMenu.ShowFixed(_provider.ProviderShowSubMenuFixedRect(_menuItem), _provider.ProviderShowHorz, _provider.ProviderShowVert);
			}
			else
			{
				_contextMenu.Show(screenRect, _provider.ProviderShowHorz, _provider.ProviderShowVert, bounce: true, constrain: false);
			}
		}
	}

	public void ClearSubMenu()
	{
		if (_contextMenu != null)
		{
			VisualPopupManager.Singleton.EndPopupTracking(_contextMenu);
		}
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (_imageCanvas != null)
		{
			if (ResolveChecked)
			{
				_imageCanvas.ElementState = PaletteState.CheckedNormal;
				_imageCanvas.Enabled = ResolveEnabled;
			}
			else
			{
				_imageCanvas.ElementState = PaletteState.Normal;
				_imageCanvas.Enabled = true;
			}
		}
		PaletteDouble itemSplit;
		switch (State)
		{
		default:
			SetPalettes(_menuItem.StateNormal.ItemHighlight.Back, _menuItem.StateNormal.ItemHighlight.Border, _menuItem.StateNormal.ItemHighlight);
			itemSplit = _menuItem.StateNormal.ItemSplit;
			break;
		case PaletteState.Disabled:
			SetPalettes(_menuItem.StateDisabled.ItemHighlight.Back, _menuItem.StateDisabled.ItemHighlight.Border, _menuItem.StateDisabled.ItemHighlight);
			itemSplit = _menuItem.StateDisabled.ItemSplit;
			break;
		case PaletteState.Tracking:
			SetPalettes(_menuItem.StateHighlight.ItemHighlight.Back, _menuItem.StateHighlight.ItemHighlight.Border, _menuItem.StateHighlight.ItemHighlight);
			itemSplit = _menuItem.StateHighlight.ItemSplit;
			break;
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (_fixedImage != null)
		{
			Image image = ResolveImage;
			Color imageTransparentColor = ResolveImageTransparentColor;
			if (image == null)
			{
				if (_imageColumn)
				{
					image = _empty16x16;
					imageTransparentColor = Color.Magenta;
				}
				switch (ResolveCheckState)
				{
				case CheckState.Checked:
					image = _provider.ProviderImages.GetContextMenuCheckedImage();
					imageTransparentColor = Color.Empty;
					break;
				case CheckState.Indeterminate:
					image = _provider.ProviderImages.GetContextMenuIndeterminateImage();
					imageTransparentColor = Color.Empty;
					break;
				}
			}
			_itemEnabled = _provider.ProviderEnabled && ResolveEnabled;
			PaletteContextMenuItemState paletteContextMenuItemState = (_itemEnabled ? _menuItem.StateNormal : _menuItem.StateDisabled);
			PaletteTripleJustImage paletteTripleJustImage = (ResolveChecked ? _menuItem.StateChecked.ItemImage : paletteContextMenuItemState.ItemImage);
			if (_imageCanvas != null)
			{
				_imageCanvas.SetPalettes(paletteTripleJustImage.Back, paletteTripleJustImage.Border);
			}
			_imageContent.SetPalette(paletteTripleJustImage.Content);
			_imageContent.Enabled = _itemEnabled;
			_textContent.Enabled = _itemEnabled;
			_splitSeparator.Enabled = _itemEnabled;
			_subMenuContent.Enabled = _itemEnabled;
			if (_shortcutContent != null)
			{
				_shortcutContent.Enabled = _itemEnabled;
			}
			_fixedTextExtraText.ShortText = ResolveText;
			_fixedTextExtraText.LongText = ResolveExtraText;
			_fixedImage.Image = image;
			_fixedImage.ImageTransparentColor = imageTransparentColor;
		}
		if (_splitSeparator != null)
		{
			_splitSeparator.SetPalettes(itemSplit.Back, itemSplit.Border);
		}
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Text":
		case "ExtraText":
		case "Enabled":
		case "Image":
		case "ImageTransparentColor":
		case "Checked":
		case "CheckState":
		case "ShortcutKeys":
		case "ShowShortcutKeys":
		case "LargeKryptonCommandImage":
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		case "KryptonCommand":
			if (_cachedCommand != null)
			{
				_cachedCommand.PropertyChanged -= OnCommandPropertyChanged;
			}
			_cachedCommand = _menuItem.KryptonCommand;
			if (_cachedCommand != null)
			{
				_cachedCommand.PropertyChanged += OnCommandPropertyChanged;
			}
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		}
	}

	private void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Text":
		case "ExtraText":
		case "ImageSmall":
		case "ImageLarge":
		case "ImageTransparentColor":
		case "Enabled":
		case "Checked":
		case "CheckState":
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		}
	}

	private void OnContextMenuDisposed(object sender, EventArgs e)
	{
		if (_contextMenu != null)
		{
			_contextMenu.Disposed -= OnContextMenuDisposed;
			_contextMenu = null;
			_provider.ProviderViewManager.ClearTargetSubMenu((IContextMenuTarget)KeyController);
		}
	}
}
