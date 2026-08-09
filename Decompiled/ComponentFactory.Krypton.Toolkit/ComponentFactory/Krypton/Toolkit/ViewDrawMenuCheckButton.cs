#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuCheckButton : ViewComposite
{
	private IContextMenuProvider _provider;

	private KryptonContextMenuCheckButton _checkButton;

	private FixedContentValue _contentValues;

	private ViewDrawButton _drawButton;

	private ViewLayoutDocker _outerDocker;

	private ViewLayoutDocker _innerDocker;

	private KryptonCommand _cachedCommand;

	private bool _itemEnabled;

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
			return _checkButton.Enabled;
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
			return _checkButton.Image;
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
			return _checkButton.ImageTransparentColor;
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
			return _checkButton.Text;
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
			return _checkButton.ExtraText;
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
			return _checkButton.Checked;
		}
	}

	public KryptonContextMenuCheckButton KryptonContextMenuCheckButton => _checkButton;

	public ViewDrawButton ViewDrawButton => _drawButton;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public ViewDrawMenuCheckButton(IContextMenuProvider provider, KryptonContextMenuCheckButton checkButton)
	{
		_provider = provider;
		_checkButton = checkButton;
		_contentValues = new FixedContentValue(ResolveText, ResolveExtraText, ResolveImage, ResolveImageTransparentColor);
		_itemEnabled = provider.ProviderEnabled && ResolveEnabled;
		_checkButton.SetPaletteRedirect(provider.ProviderRedirector);
		_drawButton = new ViewDrawButton(checkButton.OverrideDisabled, checkButton.OverrideNormal, checkButton.OverrideTracking, checkButton.OverridePressed, new PaletteMetricRedirect(provider.ProviderRedirector), _contentValues, VisualOrientation.Top, useMnemonic: true);
		_drawButton.SetCheckedPalettes(checkButton.OverrideCheckedNormal, checkButton.OverrideCheckedTracking, checkButton.OverrideCheckedPressed);
		_drawButton.Enabled = _itemEnabled;
		_drawButton.Checked = ResolveChecked;
		_innerDocker = new ViewLayoutDocker();
		_innerDocker.Add(_drawButton, ViewDockStyle.Fill);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Right);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Left);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Top);
		_innerDocker.Add(new ViewLayoutSeparator(1), ViewDockStyle.Bottom);
		_outerDocker = new ViewLayoutDocker();
		_outerDocker.Add(_innerDocker, ViewDockStyle.Top);
		_outerDocker.Add(new ViewLayoutNull(), ViewDockStyle.Fill);
		MenuCheckButtonController menuCheckButtonController = new MenuCheckButtonController(provider.ProviderViewManager, _innerDocker, this, provider.ProviderNeedPaintDelegate);
		menuCheckButtonController.Click += OnClick;
		_innerDocker.MouseController = menuCheckButtonController;
		_innerDocker.KeyController = menuCheckButtonController;
		Add(_outerDocker);
		_checkButton.PropertyChanged += OnPropertyChanged;
		if (_checkButton.KryptonCommand != null)
		{
			_cachedCommand = _checkButton.KryptonCommand;
			_checkButton.KryptonCommand.PropertyChanged += OnCommandPropertyChanged;
		}
	}

	public override string ToString()
	{
		return "ViewDrawMenuCheckButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_checkButton.PropertyChanged -= OnPropertyChanged;
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
		_drawButton.Enabled = _itemEnabled;
		_drawButton.Checked = ResolveChecked;
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
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		case "KryptonCommand":
			if (_cachedCommand != null)
			{
				_cachedCommand.PropertyChanged -= OnCommandPropertyChanged;
			}
			_cachedCommand = _checkButton.KryptonCommand;
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
			_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			break;
		}
	}

	private void OnClick(object sender, EventArgs e)
	{
		_checkButton.PerformClick();
	}
}
