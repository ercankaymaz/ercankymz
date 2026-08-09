#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecView : GlobalId, IContentValues
{
	private PaletteRedirect _redirector;

	private ButtonSpecManagerBase _manager;

	private ButtonSpec _buttonSpec;

	private PaletteTripleRedirect _palette;

	private PaletteRedirect _remapPalette;

	private ViewDrawButton _viewButton;

	private ViewLayoutCenter _viewCenter;

	private EventHandler _finishDelegate;

	private ButtonController _controller;

	public ButtonSpecManagerBase Manager => _manager;

	public ButtonSpec ButtonSpec => _buttonSpec;

	public ViewLayoutCenter ViewCenter => _viewCenter;

	public ViewDrawButton ViewButton => _viewButton;

	public PaletteRedirect RemapPalette => _remapPalette;

	public bool DrawButtonSpecOnComposition
	{
		get
		{
			return _viewButton.DrawButtonComposition;
		}
		set
		{
			_viewButton.DrawButtonComposition = value;
		}
	}

	public ButtonSpecView(PaletteRedirect redirector, IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, ButtonSpecManagerBase manager, ButtonSpec buttonSpec)
	{
		Debug.Assert(redirector != null);
		Debug.Assert(manager != null);
		Debug.Assert(buttonSpec != null);
		_redirector = redirector;
		_manager = manager;
		_buttonSpec = buttonSpec;
		_finishDelegate = OnFinishDelegate;
		NeedPaintHandler needPaint = OnNeedPaint;
		_remapPalette = _manager.CreateButtonSpecRemap(redirector, buttonSpec);
		_palette = new PaletteTripleRedirect(_remapPalette, PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec, needPaint);
		_viewButton = new ViewDrawButton(_palette, _palette, _palette, _palette, paletteMetric, this, VisualOrientation.Top, useMnemonic: false);
		if (buttonSpec.AllowComponent)
		{
			_viewButton.Component = buttonSpec;
		}
		_viewCenter = new ViewLayoutCenter(paletteMetric, metricPadding, VisualOrientation.Top);
		_viewCenter.Add(_viewButton);
		ButtonSpecViewControllers buttonSpecViewControllers = CreateController(_viewButton, needPaint, OnClick);
		_viewButton.MouseController = buttonSpecViewControllers.MouseController;
		_viewButton.SourceController = buttonSpecViewControllers.SourceController;
		_viewButton.KeyController = buttonSpecViewControllers.KeyController;
		_buttonSpec.ButtonSpecPropertyChanged += OnPropertyChanged;
		_buttonSpec.SetView(_viewButton);
		UpdateButtonStyle();
		UpdateVisible();
		UpdateEnabled();
		UpdateChecked();
	}

	public void PerformNeedPaint(bool needLayout)
	{
		_manager.PerformNeedPaint(this, needLayout);
	}

	public void UpdateButtonStyle()
	{
		_palette.SetStyles(_buttonSpec.GetStyle(_redirector));
	}

	public bool UpdateVisible()
	{
		bool visible = _viewCenter.Visible;
		_viewCenter.Visible = _buttonSpec.GetVisible(_redirector);
		return visible != _viewCenter.Visible;
	}

	public bool UpdateEnabled()
	{
		bool result = false;
		ViewBase viewBase;
		bool flag;
		switch (_buttonSpec.GetEnabled(_redirector))
		{
		case ButtonEnabled.True:
			viewBase = null;
			flag = true;
			break;
		case ButtonEnabled.False:
			viewBase = null;
			flag = false;
			break;
		case ButtonEnabled.Container:
			viewBase = _viewCenter.Parent;
			flag = true;
			break;
		default:
			Debug.Assert(condition: false);
			viewBase = null;
			flag = false;
			break;
		}
		if (flag != _viewButton.Enabled)
		{
			_viewButton.Enabled = flag;
			result = true;
		}
		if (viewBase != _viewButton.DependantEnabledState)
		{
			_viewButton.DependantEnabledState = viewBase;
			result = true;
		}
		return result;
	}

	public bool UpdateChecked()
	{
		bool flag;
		switch (_buttonSpec.GetChecked(_redirector))
		{
		case ButtonCheckState.NotCheckButton:
		case ButtonCheckState.Unchecked:
			flag = false;
			break;
		case ButtonCheckState.Checked:
			flag = true;
			break;
		default:
			Debug.Assert(condition: false);
			flag = false;
			break;
		}
		if (flag != _viewButton.Checked)
		{
			_viewButton.Checked = flag;
			return true;
		}
		return false;
	}

	public void Destruct()
	{
		_buttonSpec.ButtonSpecPropertyChanged -= OnPropertyChanged;
		_buttonSpec.SetView(null);
		_viewCenter.Dispose();
	}

	public virtual ButtonSpecViewControllers CreateController(ViewDrawButton viewButton, NeedPaintHandler needPaint, MouseEventHandler clickHandler)
	{
		_controller = new ButtonController(viewButton, needPaint);
		_controller.BecomesFixed = true;
		_controller.Click += clickHandler;
		IMouseController mouseController = _controller;
		if (Manager.ToolTipManager != null)
		{
			mouseController = new ToolTipController(Manager.ToolTipManager, viewButton, _controller);
		}
		return new ButtonSpecViewControllers(mouseController, _controller, _controller);
	}

	protected virtual void OnFinishDelegate(object sender, EventArgs e)
	{
		_controller.RemoveFixed();
	}

	public Image GetImage(PaletteState state)
	{
		return _buttonSpec.GetImage(_redirector, state);
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return _buttonSpec.GetImageTransparentColor(_redirector);
	}

	public string GetShortText()
	{
		return _buttonSpec.GetShortText(_redirector);
	}

	public string GetLongText()
	{
		return _buttonSpec.GetLongText(_redirector);
	}

	private void OnClick(object sender, MouseEventArgs e)
	{
		if (!CommonHelper.DesignMode(_manager.Control))
		{
			_buttonSpec.PerformClick(e);
			if (_buttonSpec.KryptonContextMenu != null && ViewButton != null)
			{
				Rectangle clientRectangle = ViewButton.ClientRectangle;
				Point screenPt = ((!(_manager.Control is Form)) ? _manager.Control.PointToScreen(new Point(clientRectangle.Left, clientRectangle.Bottom + 3)) : new Point(_manager.Control.Left + clientRectangle.Left, _manager.Control.Top + clientRectangle.Bottom + 3));
				_buttonSpec.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
				if (!_buttonSpec.KryptonContextMenu.Show(_buttonSpec, screenPt))
				{
					_buttonSpec.KryptonContextMenu.Closed -= OnKryptonContextMenuClosed;
					if (_finishDelegate != null)
					{
						_finishDelegate(this, EventArgs.Empty);
					}
				}
			}
			else if (_buttonSpec.ContextMenuStrip != null && ViewButton != null)
			{
				_buttonSpec.ContextMenuStrip.Renderer = _manager.RenderToolStrip();
				Rectangle clientRectangle2 = ViewButton.ClientRectangle;
				Point screenPt2 = _manager.Control.PointToScreen(new Point(clientRectangle2.Left, clientRectangle2.Bottom + 3));
				VisualPopupManager.Singleton.ShowContextMenuStrip(_buttonSpec.ContextMenuStrip, screenPt2, _finishDelegate);
			}
			else if (_finishDelegate != null)
			{
				_finishDelegate(this, EventArgs.Empty);
			}
		}
		else if (_finishDelegate != null)
		{
			_finishDelegate(this, EventArgs.Empty);
		}
	}

	private void OnKryptonContextMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		KryptonContextMenu kryptonContextMenu = (KryptonContextMenu)sender;
		kryptonContextMenu.Closed -= OnKryptonContextMenuClosed;
		OnFinishDelegate(sender, e);
	}

	private void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		PerformNeedPaint(e.NeedLayout);
	}

	private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Image":
		case "Text":
		case "ExtraText":
		case "ColorMap":
			PerformNeedPaint(needLayout: true);
			break;
		case "Style":
			UpdateButtonStyle();
			PerformNeedPaint(needLayout: true);
			break;
		case "Visible":
			UpdateVisible();
			PerformNeedPaint(needLayout: true);
			break;
		case "Enabled":
			UpdateEnabled();
			PerformNeedPaint(needLayout: true);
			break;
		case "Checked":
			UpdateChecked();
			PerformNeedPaint(needLayout: true);
			break;
		}
	}
}
