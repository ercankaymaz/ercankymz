#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuLinkLabel : ViewComposite
{
	private IContextMenuProvider _provider;

	private KryptonContextMenuLinkLabel _linkLabel;

	private FixedContentValue _contentValues;

	private ViewDrawContent _drawContent;

	private ViewLayoutDocker _outerDocker;

	private ViewLayoutDocker _innerDocker;

	private KryptonCommand _cachedCommand;

	private bool _itemEnabled;

	public string ItemText => _contentValues.GetShortText();

	public bool ItemEnabled => _itemEnabled;

	public Image ResolveImage
	{
		get
		{
			if (_cachedCommand != null)
			{
				return _cachedCommand.ImageSmall;
			}
			return _linkLabel.Image;
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
			return _linkLabel.ImageTransparentColor;
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
			return _linkLabel.Text;
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
			return _linkLabel.ExtraText;
		}
	}

	public bool Focused
	{
		set
		{
			_linkLabel.OverrideFocusNotVisited.Apply = value;
			_linkLabel.OverridePressedFocus.Apply = value;
		}
	}

	public bool Pressed
	{
		set
		{
			_drawContent.SetPalette(value ? _linkLabel.OverridePressedFocus : _linkLabel.OverrideFocusNotVisited);
		}
	}

	public KryptonContextMenuLinkLabel KryptonContextMenuLinkLabel => _linkLabel;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public ViewDrawMenuLinkLabel(IContextMenuProvider provider, KryptonContextMenuLinkLabel linkLabel)
	{
		_provider = provider;
		_linkLabel = linkLabel;
		_contentValues = new FixedContentValue(linkLabel.Text, linkLabel.ExtraText, linkLabel.Image, linkLabel.ImageTransparentColor);
		_itemEnabled = provider.ProviderEnabled;
		linkLabel.SetPaletteRedirect(provider.ProviderRedirector);
		_drawContent = new ViewDrawContent(linkLabel.OverrideFocusNotVisited, _contentValues, VisualOrientation.Top);
		_drawContent.UseMnemonic = true;
		_drawContent.Enabled = _itemEnabled;
		_innerDocker = new ViewLayoutDocker();
		_innerDocker.Add(_drawContent, ViewDockStyle.Fill);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Right);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Left);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Top);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Bottom);
		_outerDocker = new ViewLayoutDocker();
		_outerDocker.Add(_innerDocker, ViewDockStyle.Top);
		_outerDocker.Add(new ViewLayoutNull(), ViewDockStyle.Fill);
		MenuLinkLabelController menuLinkLabelController = new MenuLinkLabelController(provider.ProviderViewManager, _drawContent, this, provider.ProviderNeedPaintDelegate);
		menuLinkLabelController.Click += OnClick;
		_drawContent.MouseController = menuLinkLabelController;
		_drawContent.KeyController = menuLinkLabelController;
		Add(_outerDocker);
		_linkLabel.PropertyChanged += OnPropertyChanged;
		if (_linkLabel.KryptonCommand != null)
		{
			_cachedCommand = _linkLabel.KryptonCommand;
			_linkLabel.KryptonCommand.PropertyChanged += OnCommandPropertyChanged;
		}
	}

	public override string ToString()
	{
		return "ViewDrawMenuLinkLabel:" + base.Id;
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
		_itemEnabled = _provider.ProviderEnabled;
		_drawContent.Enabled = _itemEnabled;
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
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		case "KryptonCommand":
			if (_cachedCommand != null)
			{
				_cachedCommand.PropertyChanged -= OnCommandPropertyChanged;
			}
			_cachedCommand = _linkLabel.KryptonCommand;
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
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		}
	}

	private void OnClick(object sender, EventArgs e)
	{
		_linkLabel.PerformClick();
	}
}
