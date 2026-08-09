#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonCaptionArea : ViewDrawDocker
{
	private static readonly int MIN_INTEGRATED_HEIGHT = 26;

	private static readonly int CAPTION_TEXT_GAPS = 10;

	private static readonly int MIN_SELF_HEIGHT = 28;

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaintDelegate;

	private NeedPaintHandler _needIntegratedDelegate;

	private PaletteCaptionRedirect _redirect;

	private PaletteDoubleRedirect _redirectCaption;

	private ViewDrawRibbonComposition _compositionArea;

	private ViewLayoutRibbonAppButton _captionAppButton;

	private ViewLayoutRibbonAppButton _otherAppButton;

	private ViewLayoutSeparator _spaceInsteadOfAppButton;

	private ViewLayoutRibbonQATMini _captionQAT;

	private ViewLayoutRibbonQATMini _nonCaptionQAT;

	private ViewLayoutRibbonContextTitles _contextTiles;

	private ViewDrawRibbonCompoRightBorder _compRightBorder;

	private AppButtonController _appButtonController;

	private AppTabController _appTabController;

	private KryptonForm _kryptonForm;

	private bool _integrated;

	private bool _preventIntegration;

	private bool _compoRightInjected;

	private int _calculatedHeight;

	private Font _cacheRibbonFont;

	private int _cacheRibbonFontHeight;

	public AppButtonController AppButtonController => _appButtonController;

	public AppTabController AppTabController => _appTabController;

	public bool PreventIntegration
	{
		get
		{
			return _preventIntegration;
		}
		set
		{
			if (_preventIntegration != value)
			{
				_preventIntegration = value;
				OnFormChromeCheck(this, EventArgs.Empty);
			}
		}
	}

	public override bool DrawBorderLast => false;

	public ViewLayoutRibbonQATMini VisibleQAT
	{
		get
		{
			if (_integrated)
			{
				return _captionQAT;
			}
			return _nonCaptionQAT;
		}
	}

	public bool UsingCustomChrome => _integrated;

	public bool DrawCaptionOnComposition => UsingCustomChrome && KryptonForm.ApplyComposition;

	public KryptonForm KryptonForm => _kryptonForm;

	public Padding RealWindowBorders
	{
		get
		{
			if (_kryptonForm != null)
			{
				return _kryptonForm.RealWindowBorders;
			}
			return Padding.Empty;
		}
	}

	public ViewLayoutRibbonContextTitles ContextTitles => _contextTiles;

	protected NeedPaintHandler NeedPaintDelegate
	{
		[DebuggerStepThrough]
		get
		{
			return _needPaintDelegate;
		}
	}

	public ViewDrawRibbonCaptionArea(KryptonRibbon ribbon, PaletteRedirect redirect, ViewDrawRibbonComposition compositionArea, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(redirect != null);
		Debug.Assert(compositionArea != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_compositionArea = compositionArea;
		_needPaintDelegate = needPaintDelegate;
		_needIntegratedDelegate = OnIntegratedNeedPaint;
		_redirect = new PaletteCaptionRedirect(redirect);
		CreateViewElements();
		SetupParentMonitoring();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _kryptonForm != null)
		{
			if (_integrated)
			{
				_captionAppButton.OwnerForm = null;
				_kryptonForm.AllowIconDisplay = true;
				_kryptonForm.RevokeViewElement(_contextTiles, ViewDockStyle.Fill);
				_kryptonForm.RevokeViewElement(_captionAppButton, ViewDockStyle.Left);
				_kryptonForm.RevokeViewElement(_captionQAT, ViewDockStyle.Left);
				_integrated = false;
			}
			_kryptonForm.ApplyCustomChromeChanged -= OnFormChromeCheck;
			_kryptonForm.ClientSizeChanged -= OnFormChromeCheck;
			_kryptonForm.WindowActiveChanged -= OnWindowActiveChanged;
			_kryptonForm = null;
		}
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonCaptionArea:" + base.Id;
	}

	public void HookToolTipHandling()
	{
		_captionAppButton.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _captionAppButton, _captionAppButton.MouseController);
		_otherAppButton.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _otherAppButton, _otherAppButton.MouseController);
	}

	public void AppButtonChanged()
	{
		OnAppButtonNeedPaint(this, new NeedLayoutEventArgs(needLayout: false));
	}

	public void UpdateVisible()
	{
		Visible = !_integrated && (_ribbon.RibbonAppButton.AppButtonVisible || _ribbon.QATLocation == QATLocation.Above || _ribbon.RibbonContexts.Count > 0);
	}

	public void UpdateQAT()
	{
		bool visible = _captionQAT.Visible;
		_captionQAT.Visible = _ribbon.Visible && _ribbon.QATLocation == QATLocation.Above;
		_nonCaptionQAT.Visible = _ribbon.Visible && _ribbon.QATLocation == QATLocation.Above;
		UpdateVisible();
		if (visible != _captionQAT.Visible)
		{
			QATButtonsChanged();
		}
	}

	public void AppButtonVisibleChanged()
	{
		bool flag = _ribbon.RibbonAppButton.AppButtonVisible && _ribbon.RibbonShape == PaletteRibbonShape.Office2007;
		if (_captionAppButton.Visible != flag)
		{
			_captionAppButton.Visible = flag;
			_spaceInsteadOfAppButton.Visible = !_captionAppButton.Visible;
			_otherAppButton.Visible = _captionAppButton.Visible;
			_captionQAT.OverlapAppButton = _captionAppButton.Visible;
			_nonCaptionQAT.OverlapAppButton = _captionAppButton.Visible;
			UpdateVisible();
			OnAppButtonNeedPaint(this, new NeedLayoutEventArgs(needLayout: true));
		}
	}

	public void QATButtonsChanged()
	{
		if (UsingCustomChrome)
		{
			OnIntegratedNeedPaint(this, new NeedLayoutEventArgs(needLayout: true));
		}
	}

	public void RedrawCustomChrome(bool layout)
	{
		if (UsingCustomChrome)
		{
			_kryptonForm.PerformNeedPaint(layout);
		}
	}

	public void PerformFormChromeCheck()
	{
		OnFormChromeCheck(null, EventArgs.Empty);
	}

	public bool DoesCurrentMouseDownEndAllTracking(Point pt)
	{
		if (UsingCustomChrome)
		{
			Point pt2 = _kryptonForm.PointToClient(pt);
			Padding realWindowBorders = _kryptonForm.RealWindowBorders;
			pt2.X += realWindowBorders.Left;
			pt2.Y += realWindowBorders.Top;
			if (ContextTitles != null)
			{
				foreach (ViewBase contextTitle in ContextTitles)
				{
					if (contextTitle is ViewDrawRibbonContextTitle && contextTitle.ClientRectangle.Contains(pt2))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize.Height = Math.Max(_calculatedHeight, preferredSize.Height);
		return preferredSize;
	}

	protected void PerformNeedPaint(bool needLayout)
	{
		_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout));
	}

	private void CreateViewElements()
	{
		_redirectCaption = new PaletteDoubleRedirect(_redirect, PaletteBackStyle.HeaderForm, PaletteBorderStyle.HeaderForm, NeedPaintDelegate);
		_captionAppButton = new ViewLayoutRibbonAppButton(_ribbon, bottomHalf: false);
		_otherAppButton = new ViewLayoutRibbonAppButton(_ribbon, bottomHalf: false);
		_appButtonController = new AppButtonController(_ribbon);
		_appButtonController.Target1 = _captionAppButton.AppButton;
		_appButtonController.Target2 = _otherAppButton.AppButton;
		_appButtonController.NeedPaint += OnAppButtonNeedPaint;
		_captionAppButton.MouseController = _appButtonController;
		_otherAppButton.MouseController = _appButtonController;
		_appTabController = new AppTabController(_ribbon);
		_appTabController.NeedPaint += OnAppButtonNeedPaint;
		_spaceInsteadOfAppButton = new ViewLayoutSeparator(0);
		_spaceInsteadOfAppButton.Visible = false;
		_captionQAT = new ViewLayoutRibbonQATMini(_ribbon, _needIntegratedDelegate);
		_nonCaptionQAT = new ViewLayoutRibbonQATMini(_ribbon, NeedPaintDelegate);
		_contextTiles = new ViewLayoutRibbonContextTitles(_ribbon, this);
		_contextTiles.ReverseRenderOrder = true;
		_compRightBorder = new ViewDrawRibbonCompoRightBorder();
		_compositionArea.CompRightBorder = _compRightBorder;
		Add(_contextTiles, ViewDockStyle.Fill);
		Add(_nonCaptionQAT, ViewDockStyle.Left);
		Add(_otherAppButton, ViewDockStyle.Left);
		base.SetPalettes(_redirectCaption.PaletteBack, _redirectCaption.PaletteBorder);
	}

	private void SetupParentMonitoring()
	{
		_ribbon.ParentChanged += OnRibbonParentChanged;
	}

	private void OnRibbonParentChanged(object sender, EventArgs e)
	{
		if (_kryptonForm != null)
		{
			_kryptonForm.ApplyCustomChromeChanged -= OnFormChromeCheck;
			_kryptonForm.ClientSizeChanged -= OnFormChromeCheck;
			_kryptonForm.WindowActiveChanged -= OnWindowActiveChanged;
			_kryptonForm = null;
		}
		if (!_ribbon.IsDisposed && !_ribbon.Disposing)
		{
			if (_ribbon.Parent is Form form && form is KryptonForm)
			{
				_kryptonForm = form as KryptonForm;
				_kryptonForm.Composition = _compositionArea;
				_kryptonForm.ApplyCustomChromeChanged += OnFormChromeCheck;
				_kryptonForm.ClientSizeChanged += OnFormChromeCheck;
				_kryptonForm.WindowActiveChanged += OnWindowActiveChanged;
			}
			OnFormChromeCheck(null, EventArgs.Empty);
		}
	}

	private void OnFormChromeCheck(object sender, EventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		if (_kryptonForm != null && _kryptonForm.ApplyCustomChrome && _ribbon.Location == Point.Empty)
		{
			int top = _kryptonForm.RealWindowBorders.Top;
			if (top >= MIN_INTEGRATED_HEIGHT)
			{
				flag2 = true;
			}
			_spaceInsteadOfAppButton.SeparatorSize = new Size(_kryptonForm.RealWindowBorders.Left, 0);
		}
		if (_kryptonForm != null)
		{
			bool flag3 = flag2;
			if (PreventIntegration && flag3)
			{
				flag3 = false;
			}
			if (flag3 != _integrated)
			{
				if (!_integrated)
				{
					_captionAppButton.OwnerForm = _kryptonForm;
					_captionQAT.OwnerForm = _kryptonForm;
					_kryptonForm.InjectViewElement(_captionQAT, ViewDockStyle.Left);
					_kryptonForm.InjectViewElement(_spaceInsteadOfAppButton, ViewDockStyle.Left);
					_kryptonForm.InjectViewElement(_captionAppButton, ViewDockStyle.Left);
					if (!_compoRightInjected)
					{
						_kryptonForm.InjectViewElement(_compRightBorder, ViewDockStyle.Right);
						_compoRightInjected = true;
					}
					_kryptonForm.InjectViewElement(_contextTiles, ViewDockStyle.Fill);
				}
				else
				{
					_captionAppButton.OwnerForm = null;
					_captionQAT.OwnerForm = null;
					_kryptonForm.RevokeViewElement(_contextTiles, ViewDockStyle.Fill);
					if (_ribbon.InDesignMode || Environment.OSVersion.Version.Major < 6 || !DWM.IsCompositionEnabled)
					{
						_kryptonForm.RevokeViewElement(_compRightBorder, ViewDockStyle.Right);
						_compoRightInjected = true;
					}
					_kryptonForm.RevokeViewElement(_captionAppButton, ViewDockStyle.Left);
					_kryptonForm.RevokeViewElement(_spaceInsteadOfAppButton, ViewDockStyle.Left);
					_kryptonForm.RevokeViewElement(_captionQAT, ViewDockStyle.Left);
				}
				_integrated = flag3;
				UpdateVisible();
				flag = true;
			}
			_kryptonForm.AllowComposition = _ribbon.AllowFormIntegrate && !_ribbon.InDesignMode;
			bool flag4 = !_integrated || !_ribbon.RibbonAppButton.AppButtonVisible;
			if (_kryptonForm.AllowIconDisplay != flag4)
			{
				_kryptonForm.AllowIconDisplay = flag4;
				flag = true;
			}
		}
		if (!_integrated)
		{
			Font ribbonTextFont = _ribbon.StateCommon.RibbonGeneral.GetRibbonTextFont(PaletteState.Normal);
			if (ribbonTextFont != _cacheRibbonFont)
			{
				_cacheRibbonFont = ribbonTextFont;
				_cacheRibbonFontHeight = ribbonTextFont.Height;
			}
			int num = Math.Max(_cacheRibbonFontHeight + CAPTION_TEXT_GAPS, MIN_SELF_HEIGHT);
			if (_calculatedHeight != num)
			{
				_calculatedHeight = num;
				flag = true;
			}
		}
		if (flag)
		{
			PerformNeedPaint(needLayout: true);
			if (_kryptonForm != null)
			{
				_kryptonForm.RecreateMinMaxCloseButtons();
				_kryptonForm.PerformNeedPaint(needLayout: true);
			}
		}
	}

	private void OnWindowActiveChanged(object sender, EventArgs e)
	{
		if (_kryptonForm != null && _kryptonForm.ApplyCustomChrome && _kryptonForm.ApplyComposition)
		{
			PerformNeedPaint(needLayout: true);
		}
	}

	private void OnAppButtonNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		PerformNeedPaint(e.NeedLayout);
		_ribbon.Refresh();
		if (_integrated)
		{
			_kryptonForm.PerformNeedPaint(e.NeedLayout);
		}
	}

	private void OnIntegratedNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (_integrated)
		{
			_kryptonForm.PerformNeedPaint(e.NeedLayout);
		}
	}
}
