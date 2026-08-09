#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuRadioButton : ViewComposite
{
	private IContextMenuProvider _provider;

	private KryptonContextMenuRadioButton _radioButton;

	private FixedContentValue _contentValues;

	private ViewDrawContent _drawContent;

	private ViewDrawRadioButton _drawRadioButton;

	private ViewLayoutCenter _layoutCenter;

	private ViewLayoutDocker _outerDocker;

	private ViewLayoutDocker _innerDocker;

	private bool _itemEnabled;

	public bool ItemEnabled => _itemEnabled;

	public ViewDrawRadioButton ViewDrawRadioButton => _drawRadioButton;

	public ViewDrawContent ViewDrawContent => _drawContent;

	public string ItemText => _contentValues.GetShortText();

	public KryptonContextMenuRadioButton KryptonContextMenuRadioButton => _radioButton;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public ViewDrawMenuRadioButton(IContextMenuProvider provider, KryptonContextMenuRadioButton radioButton)
	{
		_provider = provider;
		_radioButton = radioButton;
		_contentValues = new FixedContentValue(radioButton.Text, radioButton.ExtraText, radioButton.Image, radioButton.ImageTransparentColor);
		_itemEnabled = provider.ProviderEnabled && _radioButton.Enabled;
		_radioButton.SetPaletteRedirect(provider.ProviderRedirector);
		IPaletteContent paletteContent;
		if (!_itemEnabled)
		{
			IPaletteContent overrideDisabled = _radioButton.OverrideDisabled;
			paletteContent = overrideDisabled;
		}
		else
		{
			IPaletteContent overrideDisabled = _radioButton.OverrideNormal;
			paletteContent = overrideDisabled;
		}
		_drawContent = new ViewDrawContent(paletteContent, _contentValues, VisualOrientation.Top);
		_drawContent.UseMnemonic = true;
		_drawContent.Enabled = _itemEnabled;
		_drawRadioButton = new ViewDrawRadioButton(_radioButton.StateRadioButtonImages);
		_drawRadioButton.CheckState = _radioButton.Checked;
		_drawRadioButton.Enabled = _itemEnabled;
		_layoutCenter = new ViewLayoutCenter();
		_layoutCenter.Add(_drawRadioButton);
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
		MenuRadioButtonController menuRadioButtonController = new MenuRadioButtonController(provider.ProviderViewManager, _innerDocker, this, provider.ProviderNeedPaintDelegate);
		menuRadioButtonController.Click += OnClick;
		_innerDocker.MouseController = menuRadioButtonController;
		_innerDocker.KeyController = menuRadioButtonController;
		_radioButton.CheckedChanged += OnCheckedChanged;
		Add(_outerDocker);
	}

	public override string ToString()
	{
		return "ViewDrawMenuRadioButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		_radioButton.CheckedChanged -= OnCheckedChanged;
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

	private void OnCheckedChanged(object sender, EventArgs e)
	{
		_drawRadioButton.CheckState = _radioButton.Checked;
		_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: false));
	}

	private void OnClick(object sender, EventArgs e)
	{
		_radioButton.PerformClick();
	}
}
