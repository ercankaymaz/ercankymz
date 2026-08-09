#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuCheckBox : ViewComposite
{
	private IContextMenuProvider _provider;

	private KryptonContextMenuCheckBox _checkBox;

	private FixedContentValue _contentValues;

	private ViewDrawContent _drawContent;

	private ViewDrawCheckBox _drawCheckBox;

	private ViewLayoutCenter _layoutCenter;

	private ViewLayoutDocker _outerDocker;

	private ViewLayoutDocker _innerDocker;

	private KryptonCommand _cachedCommand;

	private bool _itemEnabled;

	public ViewDrawCheckBox ViewDrawCheckBox => _drawCheckBox;

	public ViewDrawContent ViewDrawContent => _drawContent;

	public bool ItemEnabled => _itemEnabled;

	public string ItemText => _contentValues.GetShortText();

	public bool ResolveEnabled
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.Enabled;
			}
			return _checkBox.Enabled;
		}
	}

	public Image ResolveImage
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.ImageSmall;
			}
			return _checkBox.Image;
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
			return _checkBox.ImageTransparentColor;
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
			return _checkBox.Text;
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
			return _checkBox.ExtraText;
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
			return _checkBox.CheckState;
		}
	}

	public KryptonContextMenuCheckBox KryptonContextMenuCheckBox => _checkBox;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public ViewDrawMenuCheckBox(IContextMenuProvider provider, KryptonContextMenuCheckBox checkBox)
	{
		_provider = provider;
		_checkBox = checkBox;
		_contentValues = new FixedContentValue(ResolveText, ResolveExtraText, ResolveImage, ResolveImageTransparentColor);
		_itemEnabled = provider.ProviderEnabled && ResolveEnabled;
		_checkBox.SetPaletteRedirect(provider.ProviderRedirector);
		IPaletteContent paletteContent;
		if (!_itemEnabled)
		{
			IPaletteContent overrideDisabled = _checkBox.OverrideDisabled;
			paletteContent = overrideDisabled;
		}
		else
		{
			IPaletteContent overrideDisabled = _checkBox.OverrideNormal;
			paletteContent = overrideDisabled;
		}
		_drawContent = new ViewDrawContent(paletteContent, _contentValues, VisualOrientation.Top);
		_drawContent.UseMnemonic = true;
		_drawContent.Enabled = _itemEnabled;
		_drawCheckBox = new ViewDrawCheckBox(_checkBox.StateCheckBoxImages);
		_drawCheckBox.CheckState = ResolveCheckState;
		_drawCheckBox.Enabled = _itemEnabled;
		_layoutCenter = new ViewLayoutCenter();
		_layoutCenter.Add(_drawCheckBox);
		_innerDocker = new ViewLayoutDocker();
		_innerDocker.Add(_drawContent, ViewDockStyle.Fill);
		_innerDocker.Add(_layoutCenter, ViewDockStyle.Left);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Right);
		_innerDocker.Add(new ViewLayoutSeparator(3), ViewDockStyle.Left);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Top);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Bottom);
		_outerDocker = new ViewLayoutDocker();
		_outerDocker.Add(_innerDocker, ViewDockStyle.Top);
		_outerDocker.Add(new ViewLayoutNull(), ViewDockStyle.Fill);
		MenuCheckBoxController menuCheckBoxController = new MenuCheckBoxController(provider.ProviderViewManager, _innerDocker, this, provider.ProviderNeedPaintDelegate);
		menuCheckBoxController.Click += OnClick;
		_innerDocker.MouseController = menuCheckBoxController;
		_innerDocker.KeyController = menuCheckBoxController;
		Add(_outerDocker);
		_checkBox.PropertyChanged += OnPropertyChanged;
		if (_checkBox.KryptonCommand != null)
		{
			_cachedCommand = _checkBox.KryptonCommand;
			_checkBox.KryptonCommand.PropertyChanged += OnCommandPropertyChanged;
		}
	}

	public override string ToString()
	{
		return "ViewDrawMenuCheckBox:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_checkBox.PropertyChanged -= OnPropertyChanged;
			if (_cachedCommand != null)
			{
				_cachedCommand.PropertyChanged -= OnCommandPropertyChanged;
				_cachedCommand = null;
			}
		}
		base.Dispose(disposing);
	}

	public void Closing(CancelEventArgs cea)
	{
		_provider.OnClosing(cea);
	}

	public void Close(CloseReasonEventArgs e)
	{
		_provider.OnClose(e);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		_contentValues.ShortText = ResolveText;
		_contentValues.LongText = ResolveExtraText;
		_contentValues.Image = ResolveImage;
		_contentValues.ImageTransparentColor = ResolveImageTransparentColor;
		_itemEnabled = _provider.ProviderEnabled && ResolveEnabled;
		ViewDrawContent drawContent = _drawContent;
		IPaletteContent palette;
		if (!_itemEnabled)
		{
			IPaletteContent overrideDisabled = _checkBox.OverrideDisabled;
			palette = overrideDisabled;
		}
		else
		{
			IPaletteContent overrideDisabled = _checkBox.OverrideNormal;
			palette = overrideDisabled;
		}
		drawContent.SetPalette(palette);
		_drawContent.Enabled = _itemEnabled;
		_drawCheckBox.Enabled = _itemEnabled;
		_drawCheckBox.CheckState = ResolveCheckState;
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Text":
		case "ExtraText":
		case "Image":
		case "ImageTransparentColor":
		case "Enabled":
		case "Checked":
		case "CheckState":
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		case "KryptonCommand":
			if (_cachedCommand != null)
			{
				_cachedCommand.PropertyChanged -= OnCommandPropertyChanged;
			}
			_cachedCommand = _checkBox.KryptonCommand;
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
		case "ImageTransparentColor":
		case "Enabled":
		case "Checked":
		case "CheckState":
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		}
	}

	private void OnClick(object sender, EventArgs e)
	{
		_checkBox.PerformClick();
	}
}
