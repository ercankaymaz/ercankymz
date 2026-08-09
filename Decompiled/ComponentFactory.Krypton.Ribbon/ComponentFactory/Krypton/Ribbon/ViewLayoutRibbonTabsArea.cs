#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonTabsArea : ViewLayoutDocker
{
	public class RibbonButtonSpecFixedCollection : ButtonSpecCollection<ButtonSpec>
	{
		public RibbonButtonSpecFixedCollection(KryptonRibbon owner)
			: base((object)owner)
		{
		}
	}

	private static HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);

	private static readonly int BUTTON_TAB_GAP_2007 = 5;

	private static readonly int BUTTON_TAB_GAP_2010 = 0;

	private static readonly int FAR_TAB_GAP = 1;

	private static readonly int SCROLL_SPEED = 12;

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaintDelegate;

	private ViewLayoutRibbonTabs _layoutRibbonTabs;

	private ViewLayoutRibbonScrollPort _tabsViewport;

	private ViewLayoutRibbonAppButton _layoutAppButton;

	private ViewLayoutRibbonAppTab _layoutAppTab;

	private ViewLayoutSeparator _layoutAppButtonSep;

	private ViewLayoutRibbonSeparator _leftSeparator;

	private ViewLayoutRibbonSeparator _rightSeparator;

	private ViewDrawRibbonCaptionArea _captionArea;

	private ViewLayoutRibbonContextTitles _layoutContexts;

	private AppButtonController _appButtonController;

	private AppTabController _appTabController;

	private VisualPopupToolTip _visualPopupToolTip;

	private VisualPopupAppMenu _appMenu;

	private ToolTipManager _toolTipManager;

	private DateTime _lastAppButtonClick;

	private RibbonButtonSpecFixedCollection _buttonSpecsFixed;

	private ButtonSpecMdiChildClose _buttonSpecClose;

	private ButtonSpecMdiChildRestore _buttonSpecRestore;

	private ButtonSpecMdiChildMin _buttonSpecMin;

	private ButtonSpecMinimizeRibbon _buttonSpecMinimize;

	private ButtonSpecExpandRibbon _buttonSpecExpand;

	private ButtonSpecManagerLayoutRibbon _buttonManager;

	private Timer _invalidateTimer;

	private Form _formContainer;

	private Form _activeMdiChild;

	private int _paintCount;

	private bool _setVisible;

	public ViewLayoutRibbonTabs LayoutTabs => _layoutRibbonTabs;

	public ViewLayoutRibbonAppButton LayoutAppButton => _layoutAppButton;

	public ViewLayoutRibbonAppTab LayoutAppTab => _layoutAppTab;

	public ViewLayoutControl TabsContainerControl => _tabsViewport.ViewLayoutControl;

	public ToolTipManager ToolTipManager => _toolTipManager;

	public ButtonSpecManagerLayoutRibbon ButtonSpecManager => _buttonManager;

	protected NeedPaintHandler NeedPaintDelegate
	{
		[DebuggerStepThrough]
		get
		{
			return _needPaintDelegate;
		}
	}

	public event PaintEventHandler PaintBackground;

	public ViewLayoutRibbonTabsArea(KryptonRibbon ribbon, PaletteRedirect redirect, ViewDrawRibbonCaptionArea captionArea, ViewLayoutRibbonContextTitles layoutContexts, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(redirect != null);
		Debug.Assert(layoutContexts != null);
		Debug.Assert(captionArea != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_captionArea = captionArea;
		_appButtonController = captionArea.AppButtonController;
		_appTabController = captionArea.AppTabController;
		_layoutContexts = layoutContexts;
		_needPaintDelegate = needPaintDelegate;
		_setVisible = true;
		_lastAppButtonClick = DateTime.MinValue;
		CreateController();
		CreateButtonSpecs();
		CreateViewElements(redirect);
		SetupParentMonitoring();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			OnCancelToolTip(this, EventArgs.Empty);
			_ribbon.ParentChanged += OnRibbonParentChanged;
			if (_formContainer != null)
			{
				_formContainer.Deactivate -= OnRibbonFormDeactivate;
				_formContainer.Activated -= OnRibbonFormActivated;
				_formContainer.SizeChanged -= OnRibbonFormSizeChanged;
				_formContainer.MdiChildActivate -= OnRibbonMdiChildActivate;
				_formContainer = null;
			}
			if (_activeMdiChild != null)
			{
				_activeMdiChild.SizeChanged -= OnRibbonMdiChildSizeChanged;
				_activeMdiChild = null;
			}
			if (_buttonManager != null)
			{
				_buttonManager.Destruct();
				_buttonManager = null;
			}
		}
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonTabsArea:" + base.Id;
	}

	public void HookToolTipHandling()
	{
		_layoutAppButton.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _layoutAppButton, _appButtonController);
		_layoutAppTab.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _layoutAppTab, _appTabController);
	}

	public void CheckRibbonSize()
	{
		if (_ribbon.IsDisposed)
		{
			return;
		}
		Form form = _ribbon.FindForm();
		if (form == null || CommonHelper.IsFormMinimized(form))
		{
			return;
		}
		bool flag = form.ClientSize.Width >= _ribbon.HideRibbonSize.Width && form.ClientSize.Height >= _ribbon.HideRibbonSize.Height;
		if (Environment.OSVersion.Version.Major >= 6)
		{
			if (_ribbon.MainPanel.Visible != flag)
			{
				_ribbon.MainPanel.Visible = flag;
				_captionArea.PreventIntegration = !flag;
				if (_captionArea.KryptonForm != null)
				{
					_captionArea.KryptonForm.RecalculateComposition();
				}
			}
		}
		else if (_ribbon.Visible != flag || _setVisible != flag)
		{
			_ribbon.Visible = flag;
			_setVisible = flag;
			if (_captionArea.UsingCustomChrome)
			{
				_paintCount = _captionArea.KryptonForm.PaintCount;
				_invalidateTimer.Start();
			}
		}
	}

	public void AppButtonVisibleChanged()
	{
		_layoutAppButton.Visible = _ribbon.RibbonAppButton.AppButtonVisible && _ribbon.RibbonShape == PaletteRibbonShape.Office2007;
		_layoutAppTab.Visible = _ribbon.RibbonAppButton.AppButtonVisible && _ribbon.RibbonShape != PaletteRibbonShape.Office2007;
		_leftSeparator.SeparatorSize = ((_ribbon.RibbonShape == PaletteRibbonShape.Office2007) ? new Size(BUTTON_TAB_GAP_2007, BUTTON_TAB_GAP_2007) : new Size(BUTTON_TAB_GAP_2010, BUTTON_TAB_GAP_2010));
		_layoutAppButtonSep.Visible = !_layoutAppButton.Visible;
	}

	public KeyTipInfo GetAppButtonKeyTip()
	{
		Rectangle rectangle = _ribbon.RectangleToScreen(_layoutAppButton.ClientRectangle);
		rectangle.Y -= 5;
		rectangle.X += 2;
		return new KeyTipInfo(screenPt: new Point(rectangle.Left + rectangle.Width / 2, rectangle.Top), enabled: true, keyString: _ribbon.RibbonStrings.AppButtonKeyTip, clientRect: _layoutAppButton.ClientRectangle, target: _appButtonController);
	}

	public KeyTipInfo GetAppTabKeyTip()
	{
		Rectangle rectangle = _ribbon.RectangleToScreen(_layoutAppTab.ClientRectangle);
		return new KeyTipInfo(screenPt: new Point(rectangle.Left + rectangle.Width / 2, rectangle.Bottom + 2), enabled: true, keyString: _ribbon.RibbonStrings.AppButtonKeyTip, clientRect: _layoutAppTab.ClientRectangle, target: _appTabController);
	}

	public KeyTipInfo[] GetTabKeyTips()
	{
		KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
		keyTipInfoList.AddRange(LayoutTabs.GetTabKeyTips());
		Rectangle rectangle = new Rectangle(Point.Empty, _tabsViewport.ClientSize);
		for (int i = 0; i < keyTipInfoList.Count; i++)
		{
			if (!rectangle.Contains(keyTipInfoList[i].ClientRect))
			{
				keyTipInfoList[i].Visible = false;
			}
		}
		return keyTipInfoList.ToArray();
	}

	public override void Layout(ViewLayoutContext context)
	{
		base.Layout(context);
		Rectangle displayRectangle = context.DisplayRectangle;
		context.DisplayRectangle = _layoutContexts.ClientRectangle;
		_layoutContexts.Layout(context);
		context.DisplayRectangle = displayRectangle;
		if (_captionArea.UsingCustomChrome && !_captionArea.KryptonForm.ApplyComposition)
		{
			_paintCount = _captionArea.KryptonForm.PaintCount;
			_invalidateTimer.Start();
		}
	}

	public void TestForAppButtonDoubleClick()
	{
		DateTime now = DateTime.Now;
		TimeSpan timeSpan = now - _lastAppButtonClick;
		_lastAppButtonClick = now;
		if (timeSpan.TotalMilliseconds < (double)SystemInformation.DoubleClickTime && _ribbon.RibbonShape != PaletteRibbonShape.Office2010)
		{
			_ribbon.FindForm()?.Close();
		}
	}

	public void RecreateButtons()
	{
		if (_buttonManager != null)
		{
			_buttonManager.RecreateButtons();
		}
	}

	protected void PerformNeedPaint(bool needLayout)
	{
		_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout));
	}

	private void CreateController()
	{
		RibbonTabsController ribbonTabsController = new RibbonTabsController(_ribbon);
		ribbonTabsController.ContextClick += OnContextClicked;
		MouseController = ribbonTabsController;
	}

	private void CreateButtonSpecs()
	{
		_buttonSpecsFixed = new RibbonButtonSpecFixedCollection(_ribbon);
		_buttonSpecClose = new ButtonSpecMdiChildClose(_ribbon);
		_buttonSpecRestore = new ButtonSpecMdiChildRestore(_ribbon);
		_buttonSpecMin = new ButtonSpecMdiChildMin(_ribbon);
		_buttonSpecMinimize = new ButtonSpecMinimizeRibbon(_ribbon);
		_buttonSpecExpand = new ButtonSpecExpandRibbon(_ribbon);
		_buttonSpecsFixed.AddRange(new ButtonSpec[5] { _buttonSpecMinimize, _buttonSpecExpand, _buttonSpecMin, _buttonSpecRestore, _buttonSpecClose });
	}

	private void CreateViewElements(PaletteRedirect redirect)
	{
		_layoutRibbonTabs = new ViewLayoutRibbonTabs(_ribbon, NeedPaintDelegate);
		_tabsViewport = new ViewLayoutRibbonScrollPort(_ribbon, System.Windows.Forms.Orientation.Horizontal, _layoutRibbonTabs, insetForTabs: true, SCROLL_SPEED, NeedPaintDelegate);
		_tabsViewport.TransparentBackground = true;
		_tabsViewport.PaintBackground += OnTabsPaintBackground;
		_layoutRibbonTabs.ParentControl = _tabsViewport.ViewLayoutControl.ChildControl;
		_layoutRibbonTabs.NeedPaintDelegate = _tabsViewport.ViewControlPaintDelegate;
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		viewLayoutDocker.Add(_tabsViewport, ViewDockStyle.Fill);
		_layoutAppButton = new ViewLayoutRibbonAppButton(_ribbon, bottomHalf: true);
		_layoutAppTab = new ViewLayoutRibbonAppTab(_ribbon);
		_appButtonController.Target3 = _layoutAppButton.AppButton;
		_appButtonController.Click += OnAppButtonClicked;
		_appButtonController.MouseReleased += OnAppButtonReleased;
		_layoutAppButton.MouseController = _appButtonController;
		_layoutAppButton.SourceController = _appButtonController;
		_layoutAppButton.KeyController = _appButtonController;
		_appTabController.Target1 = _layoutAppTab.AppTab;
		_appTabController.Click += OnAppButtonClicked;
		_appTabController.MouseReleased += OnAppButtonReleased;
		_layoutAppTab.MouseController = _appTabController;
		_layoutAppTab.SourceController = _appTabController;
		_layoutAppTab.KeyController = _appTabController;
		_layoutAppButtonSep = new ViewLayoutSeparator(5, 0);
		_layoutAppButtonSep.Visible = false;
		_rightSeparator = new ViewLayoutRibbonSeparator(FAR_TAB_GAP, ignoreMouse: true);
		_leftSeparator = new ViewLayoutRibbonSeparator(BUTTON_TAB_GAP_2007, ignoreMouse: true);
		Add(_rightSeparator, ViewDockStyle.Left);
		Add(_leftSeparator, ViewDockStyle.Left);
		Add(_layoutAppButton, ViewDockStyle.Left);
		Add(_layoutAppButtonSep, ViewDockStyle.Left);
		Add(_layoutAppTab, ViewDockStyle.Left);
		Add(viewLayoutDocker, ViewDockStyle.Fill);
		PaletteRedirect redirector = new PaletteRedirectRibbonAeroOverride(_ribbon, redirect);
		_buttonManager = new ButtonSpecManagerLayoutRibbon(_ribbon, redirector, _ribbon.ButtonSpecs, _buttonSpecsFixed, new ViewLayoutDocker[1] { viewLayoutDocker }, new IPaletteMetric[1] { _ribbon.StateCommon }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetPrimary }, new PaletteMetricPadding[1] { PaletteMetricPadding.RibbonButtonPadding }, _ribbon.CreateToolStripRenderer, NeedPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
	}

	private void SetupParentMonitoring()
	{
		_ribbon.ParentChanged += OnRibbonParentChanged;
		_invalidateTimer = new Timer();
		_invalidateTimer.Interval = 1;
		_invalidateTimer.Tick += OnRedrawTick;
	}

	private void OnRibbonParentChanged(object sender, EventArgs e)
	{
		if (_formContainer != null)
		{
			_formContainer.Deactivate -= OnRibbonFormDeactivate;
			_formContainer.Activated -= OnRibbonFormActivated;
			_formContainer.SizeChanged -= OnRibbonFormSizeChanged;
			_formContainer.MdiChildActivate -= OnRibbonMdiChildActivate;
		}
		_formContainer = _ribbon.FindForm();
		if (_formContainer != null)
		{
			_formContainer.MdiChildActivate += OnRibbonMdiChildActivate;
			_formContainer.SizeChanged += OnRibbonFormSizeChanged;
			_formContainer.Activated += OnRibbonFormActivated;
			_formContainer.Deactivate += OnRibbonFormDeactivate;
			_ribbon.UpdateBackStyle();
		}
	}

	private void OnRibbonFormActivated(object sender, EventArgs e)
	{
		_ribbon.ViewRibbonManager.Active();
		_ribbon.UpdateBackStyle();
	}

	private void OnRibbonFormDeactivate(object sender, EventArgs e)
	{
		_ribbon.ViewRibbonManager.Inactive();
		_ribbon.UpdateBackStyle();
	}

	private void OnRibbonFormSizeChanged(object sender, EventArgs e)
	{
		CheckRibbonSize();
	}

	private void OnRibbonMdiChildActivate(object sender, EventArgs e)
	{
		Form form = sender as Form;
		if (_activeMdiChild != null)
		{
			_activeMdiChild.SizeChanged -= OnRibbonMdiChildSizeChanged;
		}
		_activeMdiChild = form.ActiveMdiChild;
		if (_activeMdiChild != null)
		{
			_activeMdiChild.SizeChanged += OnRibbonMdiChildSizeChanged;
		}
		_buttonSpecClose.MdiChild = _activeMdiChild;
		_buttonSpecRestore.MdiChild = _activeMdiChild;
		_buttonSpecMin.MdiChild = _activeMdiChild;
		_buttonManager.RecreateButtons();
		PerformNeedPaint(needLayout: true);
		PI.SetMenu(new HandleRef(_ribbon, form.Handle), NullHandleRef);
		if (_activeMdiChild != null)
		{
			uint windowLong = PI.GetWindowLong(_activeMdiChild.Handle, -16);
			windowLong |= 0x80000;
			PI.SetWindowLong(_activeMdiChild.Handle, -16, windowLong);
		}
	}

	private void OnRibbonMdiChildSizeChanged(object sender, EventArgs e)
	{
		_buttonManager.RecreateButtons();
		PerformNeedPaint(needLayout: true);
	}

	private void OnRedrawTick(object sender, EventArgs e)
	{
		_invalidateTimer.Stop();
		if (_captionArea != null && _captionArea.KryptonForm != null && _captionArea.UsingCustomChrome && _captionArea.KryptonForm.PaintCount == _paintCount)
		{
			_captionArea.RedrawCustomChrome(layout: true);
		}
	}

	private void OnAppButtonReleased(object sender, EventArgs e)
	{
		if (!_ribbon.InDesignMode)
		{
			TestForAppButtonDoubleClick();
		}
	}

	private void OnAppButtonClicked(object sender, EventArgs e)
	{
		if (_ribbon.InDesignMode)
		{
			OnAppMenuDisposed(this, EventArgs.Empty);
			return;
		}
		CancelEventArgs e2 = new CancelEventArgs();
		_ribbon.OnAppButtonMenuOpening(e2);
		if (e2.Cancel)
		{
			OnAppMenuDisposed(this, EventArgs.Empty);
			return;
		}
		if (_ribbon.RealMinimizedMode)
		{
			_ribbon.KillMinimizedPopup();
		}
		Application.DoEvents();
		if (!_ribbon.InDesignMode && !_ribbon.IsDisposed)
		{
			Rectangle rectangle2;
			Rectangle rectAppButtonTopHalf;
			Rectangle screenRect;
			if (_ribbon.RibbonShape == PaletteRibbonShape.Office2007)
			{
				Rectangle rectangle = _ribbon.RectangleToScreen(_layoutAppButton.AppButton.ClientRectangle);
				rectangle2 = new Rectangle(rectangle.X, rectangle.Y + 22, rectangle.Width, rectangle.Height - 21);
				rectAppButtonTopHalf = new Rectangle(rectangle2.X, rectangle2.Y - 21, rectangle2.Width, 21);
				screenRect = rectangle2;
			}
			else
			{
				Rectangle rectangle3 = _ribbon.RectangleToScreen(_layoutAppTab.AppTab.ClientRectangle);
				rectangle2 = Rectangle.Empty;
				rectAppButtonTopHalf = rectangle3;
				screenRect = new Rectangle(rectangle3.X, rectangle3.Bottom - 1, rectangle3.Width, 0);
			}
			_appMenu = new VisualPopupAppMenu(_ribbon, _ribbon.RibbonAppButton, _ribbon.Palette, _ribbon.PaletteMode, _ribbon.GetRedirector(), rectAppButtonTopHalf, rectangle2, _appButtonController.Keyboard);
			_appMenu.Disposed += OnAppMenuDisposed;
			screenRect.X -= 3;
			screenRect.Height = 0;
			_appMenu.Show(screenRect);
			_ribbon.OnAppButtonMenuOpened(EventArgs.Empty);
		}
	}

	private void OnAppMenuDisposed(object sender, EventArgs e)
	{
		_ribbon.KillKeyboardMode();
		_appButtonController.RemoveFixed();
		_appTabController.RemoveFixed();
		if (_appMenu != null)
		{
			_appMenu.Disposed -= OnAppMenuDisposed;
			ToolStripDropDownCloseReason reason = ToolStripDropDownCloseReason.AppFocusChange;
			if (_appMenu.CloseReason.HasValue)
			{
				reason = _appMenu.CloseReason.Value;
			}
			_appMenu = null;
			_ribbon.OnAppButtonMenuClosed(new ToolStripDropDownClosedEventArgs(reason));
		}
	}

	private void OnContextClicked(object sender, MouseEventArgs e)
	{
		if (!_ribbon.InDesignMode)
		{
			_ribbon.DisplayRibbonContextMenu(e);
		}
	}

	private void OnShowToolTip(object sender, ToolTipEventArgs e)
	{
		if (_ribbon.IsDisposed)
		{
			return;
		}
		Form form = _ribbon.FindForm();
		if ((form != null && !form.ContainsFocus) || _ribbon.InDesignMode)
		{
			return;
		}
		IContentValues contentValues = null;
		LabelStyle style = LabelStyle.SuperTip;
		Rectangle screenRect = new Rectangle(e.ScreenPt, new Size(1, 1));
		if (e.Target is ViewLayoutRibbonAppButton || e.Target is ViewLayoutRibbonAppTab)
		{
			AppButtonToolTipToContent appButtonToolTipToContent = new AppButtonToolTipToContent(_ribbon);
			if (appButtonToolTipToContent.HasContent)
			{
				contentValues = appButtonToolTipToContent;
				style = _ribbon.RibbonAppButton.AppButtonToolTipStyle;
				screenRect.Height += SystemInformation.CursorSize.Height / 3 * 2;
			}
		}
		else if (e.Target is ViewDrawRibbonQATButton)
		{
			ViewDrawRibbonQATButton viewDrawRibbonQATButton = (ViewDrawRibbonQATButton)e.Target;
			QATButtonToolTipToContent qATButtonToolTipToContent = new QATButtonToolTipToContent(viewDrawRibbonQATButton.QATButton);
			if (qATButtonToolTipToContent.HasContent)
			{
				contentValues = qATButtonToolTipToContent;
				style = viewDrawRibbonQATButton.QATButton.GetToolTipStyle();
				screenRect.Height += SystemInformation.CursorSize.Height / 3 * 2;
			}
		}
		else if (e.Target.Parent != null && e.Target.Parent is ViewDrawRibbonGroupLabel)
		{
			ViewDrawRibbonGroupLabel viewDrawRibbonGroupLabel = (ViewDrawRibbonGroupLabel)e.Target.Parent;
			GroupItemToolTipToContent groupItemToolTipToContent = new GroupItemToolTipToContent(viewDrawRibbonGroupLabel.GroupLabel);
			if (groupItemToolTipToContent.HasContent)
			{
				contentValues = groupItemToolTipToContent;
				style = viewDrawRibbonGroupLabel.GroupLabel.ToolTipStyle;
				Rectangle toolTipScreenRectangle = _ribbon.ToolTipScreenRectangle;
				screenRect.Y = toolTipScreenRectangle.Y;
				screenRect.Height = toolTipScreenRectangle.Height;
				screenRect.X = toolTipScreenRectangle.X + viewDrawRibbonGroupLabel.ClientLocation.X;
				screenRect.Width = viewDrawRibbonGroupLabel.ClientWidth;
			}
		}
		else if (e.Target is ViewDrawRibbonGroupButtonBackBorder)
		{
			ViewDrawRibbonGroupButtonBackBorder viewDrawRibbonGroupButtonBackBorder = (ViewDrawRibbonGroupButtonBackBorder)e.Target;
			GroupItemToolTipToContent groupItemToolTipToContent2 = new GroupItemToolTipToContent(viewDrawRibbonGroupButtonBackBorder.GroupItem);
			if (groupItemToolTipToContent2.HasContent)
			{
				contentValues = groupItemToolTipToContent2;
				style = viewDrawRibbonGroupButtonBackBorder.GroupItem.InternalToolTipStyle;
				Rectangle toolTipScreenRectangle2 = _ribbon.ToolTipScreenRectangle;
				screenRect.Y = toolTipScreenRectangle2.Y;
				screenRect.Height = toolTipScreenRectangle2.Height;
				screenRect.X = toolTipScreenRectangle2.X + viewDrawRibbonGroupButtonBackBorder.ClientLocation.X;
				screenRect.Width = viewDrawRibbonGroupButtonBackBorder.ClientWidth;
			}
		}
		else if (e.Target is ViewLayoutRibbonCheckBox)
		{
			ViewDrawRibbonGroupCheckBox viewDrawRibbonGroupCheckBox = (ViewDrawRibbonGroupCheckBox)e.Target.Parent;
			GroupItemToolTipToContent groupItemToolTipToContent3 = new GroupItemToolTipToContent(viewDrawRibbonGroupCheckBox.GroupCheckBox);
			if (groupItemToolTipToContent3.HasContent)
			{
				contentValues = groupItemToolTipToContent3;
				style = viewDrawRibbonGroupCheckBox.GroupCheckBox.InternalToolTipStyle;
				Rectangle toolTipScreenRectangle3 = _ribbon.ToolTipScreenRectangle;
				screenRect.Y = toolTipScreenRectangle3.Y;
				screenRect.Height = toolTipScreenRectangle3.Height;
				screenRect.X = toolTipScreenRectangle3.X + viewDrawRibbonGroupCheckBox.ClientLocation.X;
				screenRect.Width = viewDrawRibbonGroupCheckBox.ClientWidth;
			}
		}
		else if (e.Target is ViewLayoutRibbonRadioButton)
		{
			ViewDrawRibbonGroupRadioButton viewDrawRibbonGroupRadioButton = (ViewDrawRibbonGroupRadioButton)e.Target.Parent;
			GroupItemToolTipToContent groupItemToolTipToContent4 = new GroupItemToolTipToContent(viewDrawRibbonGroupRadioButton.GroupRadioButton);
			if (groupItemToolTipToContent4.HasContent)
			{
				contentValues = groupItemToolTipToContent4;
				style = viewDrawRibbonGroupRadioButton.GroupRadioButton.InternalToolTipStyle;
				Rectangle toolTipScreenRectangle4 = _ribbon.ToolTipScreenRectangle;
				screenRect.Y = toolTipScreenRectangle4.Y;
				screenRect.Height = toolTipScreenRectangle4.Height;
				screenRect.X = toolTipScreenRectangle4.X + viewDrawRibbonGroupRadioButton.ClientLocation.X;
				screenRect.Width = viewDrawRibbonGroupRadioButton.ClientWidth;
			}
		}
		else
		{
			ButtonSpec buttonSpec = _buttonManager.ButtonSpecFromView(e.Target);
			if (buttonSpec != null && _ribbon.AllowButtonSpecToolTips)
			{
				ButtonSpecToContent buttonSpecToContent = new ButtonSpecToContent(_ribbon.GetRedirector(), buttonSpec);
				if (buttonSpecToContent.HasContent)
				{
					contentValues = buttonSpecToContent;
					style = buttonSpec.ToolTipStyle;
					screenRect.Height += SystemInformation.CursorSize.Height / 3 * 2;
				}
			}
		}
		if (contentValues != null)
		{
			if (_visualPopupToolTip != null)
			{
				_visualPopupToolTip.Dispose();
			}
			_visualPopupToolTip = new VisualPopupToolTip(_ribbon.GetRedirector(), contentValues, _ribbon.Renderer, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, CommonHelper.ContentStyleFromLabelStyle(style));
			_visualPopupToolTip.Disposed += OnVisualPopupToolTipDisposed;
			screenRect.Height -= 20;
			_visualPopupToolTip.ShowCalculatingSize(screenRect);
		}
	}

	private void OnCancelToolTip(object sender, EventArgs e)
	{
		if (_visualPopupToolTip != null)
		{
			_visualPopupToolTip.Dispose();
		}
	}

	private void OnVisualPopupToolTipDisposed(object sender, EventArgs e)
	{
		VisualPopupToolTip visualPopupToolTip = (VisualPopupToolTip)sender;
		visualPopupToolTip.Disposed -= OnVisualPopupToolTipDisposed;
		_visualPopupToolTip = null;
	}

	private void OnTabsPaintBackground(object sender, PaintEventArgs e)
	{
		if (this.PaintBackground != null)
		{
			this.PaintBackground(sender, e);
		}
	}
}
