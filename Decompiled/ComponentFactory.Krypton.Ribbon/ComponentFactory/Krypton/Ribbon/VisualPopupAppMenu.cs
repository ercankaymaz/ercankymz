using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class VisualPopupAppMenu : VisualPopup
{
	private KryptonRibbon _ribbon;

	private IPalette _palette;

	private IPaletteBack _drawOutsideBack;

	private IPaletteBorder _drawOutsideBorder;

	private AppButtonMenuProvider _provider;

	private ViewDrawRibbonAppMenu _drawOutsideDocker;

	private ViewDrawRibbonAppMenuOuter _drawOutsideBacking;

	private ViewDrawRibbonAppMenuInner _drawInnerBacking;

	private ViewDrawRibbonAppButton _appButtonBottom;

	private ViewLayoutStack _viewColumns;

	private ViewLayoutDocker _viewButtonSpecDocker;

	private PaletteRedirect _redirector;

	private ButtonSpecManagerLayout _buttonManager;

	private Rectangle _rectAppButtonBottomHalf;

	private Rectangle _rectAppButtonTopHalf;

	public ToolStripDropDownCloseReason? CloseReason => _provider.ProviderCloseReason;

	public KryptonContextMenuPositionH ShowHorz
	{
		get
		{
			return _provider.ProviderShowHorz;
		}
		set
		{
			_provider.ProviderShowHorz = value;
		}
	}

	public KryptonContextMenuPositionV ShowVert
	{
		get
		{
			return _provider.ProviderShowVert;
		}
		set
		{
			_provider.ProviderShowVert = value;
		}
	}

	public ViewContextMenuManager ViewContextMenuManager => (ViewContextMenuManager)base.ViewManager;

	protected PaletteRedirect Redirector
	{
		[DebuggerStepThrough]
		get
		{
			return _redirector;
		}
	}

	public VisualPopupAppMenu(KryptonRibbon ribbon, RibbonAppButton appButton, IPalette palette, PaletteMode paletteMode, PaletteRedirect redirector, Rectangle rectAppButtonTopHalf, Rectangle rectAppButtonBottomHalf, bool keyboardActivated)
		: base(shadow: true)
	{
		_redirector = redirector;
		_ribbon = ribbon;
		_rectAppButtonTopHalf = rectAppButtonTopHalf;
		_rectAppButtonBottomHalf = rectAppButtonBottomHalf;
		base.ViewManager = new ViewContextMenuManager(this, new ViewLayoutNull());
		if (palette != null)
		{
			SetPalette(palette);
		}
		else
		{
			SetPalette(KryptonManager.GetPaletteForMode(paletteMode));
		}
		_viewColumns = new ViewLayoutStack(horizontal: true);
		_provider = new AppButtonMenuProvider((ViewContextMenuManager)base.ViewManager, _ribbon.RibbonAppButton.AppButtonMenuItems, _viewColumns, palette, paletteMode, redirector, base.NeedPaintDelegate);
		_provider.Closing += OnProviderClosing;
		_provider.Close += OnProviderClose;
		_provider.Dispose += OnProviderClose;
		CreateAppButtonBottom();
		CreateButtonSpecView();
		CreateContextMenuView(appButton);
		CreateRecentDocumentsView();
		CreateInnerBacking(CreateInsideCanvas());
		CreateOuterBacking();
		CreateOutsideDocker();
		CreateButtonManager(appButton);
		base.ViewManager.Root = _drawOutsideDocker;
		if (keyboardActivated)
		{
			((ViewContextMenuManager)base.ViewManager).KeyDown();
		}
	}

	private void CreateButtonSpecView()
	{
		_viewButtonSpecDocker = new ViewLayoutDocker();
	}

	private void CreateContextMenuView(RibbonAppButton appButton)
	{
		KryptonContextMenuCollection kryptonContextMenuCollection = new KryptonContextMenuCollection();
		KryptonContextMenuItems kryptonContextMenuItems = new KryptonContextMenuItems();
		kryptonContextMenuItems.ImageColumn = false;
		kryptonContextMenuCollection.Add(kryptonContextMenuItems);
		foreach (KryptonContextMenuItemBase appButtonMenuItem in appButton.AppButtonMenuItems)
		{
			kryptonContextMenuItems.Items.Add(appButtonMenuItem);
		}
		kryptonContextMenuCollection.GenerateView(_provider, this, _viewColumns, standardStyle: true, imageColumn: true);
	}

	private void CreateRecentDocumentsView()
	{
		if (!_ribbon.RibbonAppButton.AppButtonShowRecentDocs)
		{
			return;
		}
		KryptonContextMenuSeparator kryptonContextMenuSeparator = new KryptonContextMenuSeparator();
		kryptonContextMenuSeparator.Horizontal = false;
		_viewColumns.Add(new ViewDrawMenuSeparator(kryptonContextMenuSeparator, _provider.ProviderStateCommon.Separator));
		_viewColumns.Add(new ViewLayoutSeparator(0, _ribbon.RibbonAppButton.AppButtonMinRecentSize.Height));
		ViewDrawRibbonAppMenuDocs viewDrawRibbonAppMenuDocs = new ViewDrawRibbonAppMenuDocs(_ribbon);
		_viewColumns.Add(viewDrawRibbonAppMenuDocs);
		ViewLayoutStack viewLayoutStack = new ViewLayoutStack(horizontal: false);
		viewDrawRibbonAppMenuDocs.Add(viewLayoutStack);
		viewLayoutStack.Add(new ViewLayoutSeparator(_ribbon.RibbonAppButton.AppButtonMinRecentSize.Width, 0));
		viewLayoutStack.Add(new ViewDrawRibbonRecentDocs(_ribbon));
		KryptonContextMenuSeparator separator = new KryptonContextMenuSeparator();
		viewLayoutStack.Add(new ViewDrawMenuSeparator(separator, _provider.ProviderStateCommon.Separator));
		viewLayoutStack.Add(new ViewLayoutSeparator(2));
		int num = 1;
		foreach (KryptonRibbonRecentDoc appButtonRecentDoc in _ribbon.RibbonAppButton.AppButtonRecentDocs)
		{
			viewLayoutStack.Add(new ViewDrawRibbonAppMenuRecentDec(_ribbon, _provider, appButtonRecentDoc, _ribbon.RibbonAppButton.AppButtonMaxRecentSize.Width, base.NeedPaintDelegate, num++));
		}
		viewLayoutStack.Add(new ViewLayoutSeparator(1));
		_provider.FixedViewBase = viewDrawRibbonAppMenuDocs;
	}

	private ViewDrawCanvas CreateInsideCanvas()
	{
		ViewDrawCanvas viewDrawCanvas = new ViewDrawCanvas(_provider.ProviderStateCommon.ControlInner.Back, _provider.ProviderStateCommon.ControlInner.Border, VisualOrientation.Top);
		viewDrawCanvas.Add(_viewColumns);
		viewDrawCanvas.KeyController = new ContextMenuController((ViewContextMenuManager)base.ViewManager);
		return viewDrawCanvas;
	}

	private void CreateInnerBacking(ViewBase fillElement)
	{
		_drawInnerBacking = new ViewDrawRibbonAppMenuInner(_ribbon);
		_drawInnerBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Top);
		_drawInnerBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Bottom);
		_drawInnerBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Left);
		_drawInnerBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Right);
		_drawInnerBacking.Add(fillElement, ViewDockStyle.Fill);
	}

	private void CreateOuterBacking()
	{
		_drawOutsideBacking = new ViewDrawRibbonAppMenuOuter(_ribbon);
		_drawOutsideBacking.Add(_drawInnerBacking, ViewDockStyle.Fill);
		_drawOutsideBacking.Add(new ViewLayoutSeparator(14), ViewDockStyle.Top);
		_drawOutsideBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Left);
		_drawOutsideBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Right);
		_drawOutsideBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Bottom);
		_drawOutsideBacking.Add(_viewButtonSpecDocker, ViewDockStyle.Bottom);
		_drawOutsideBacking.Add(new ViewLayoutSeparator(2), ViewDockStyle.Bottom);
	}

	private void CreateAppButtonBottom()
	{
		_appButtonBottom = new ViewDrawRibbonAppButton(_ribbon, bottomHalf: true);
		_appButtonBottom.ElementState = PaletteState.Pressed;
		if (_ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			_appButtonBottom.Visible = false;
		}
	}

	private void CreateOutsideDocker()
	{
		_drawOutsideBack = new PaletteBackToPalette(_redirector, PaletteBackStyle.ControlRibbonAppMenu);
		_drawOutsideBorder = new PaletteBorderToPalette(_redirector, PaletteBorderStyle.ControlRibbonAppMenu);
		_drawOutsideDocker = new ViewDrawRibbonAppMenu(_drawOutsideBack, _drawOutsideBorder, _appButtonBottom, _rectAppButtonBottomHalf);
		_drawOutsideDocker.KeyController = new ContextMenuController((ViewContextMenuManager)base.ViewManager);
		_drawOutsideDocker.Add(_drawOutsideBacking, ViewDockStyle.Fill);
	}

	private void CreateButtonManager(RibbonAppButton appButton)
	{
		_buttonManager = new ButtonSpecManagerLayoutAppButton((ViewContextMenuManager)base.ViewManager, this, _redirector, appButton.AppButtonSpecs, null, new ViewLayoutDocker[1] { _viewButtonSpecDocker }, new IPaletteMetric[1] { _ribbon.StateCommon }, new PaletteMetricInt[1], new PaletteMetricPadding[1] { PaletteMetricPadding.RibbonAppButton }, base.CreateToolStripRenderer, OnButtonSpecPaint);
		_buttonManager.RecreateButtons();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnPaletteNeedPaint;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			if (_buttonManager != null)
			{
				_buttonManager.Destruct();
				_buttonManager = null;
			}
		}
		base.Dispose(disposing);
	}

	public override void Show(Rectangle screenRect)
	{
		Size size = CalculatePreferredSize();
		Rectangle rect = new Rectangle(screenRect.Location, size);
		Rectangle workingArea = Screen.GetWorkingArea(rect);
		size.Width = Math.Min(workingArea.Width, size.Width);
		size.Height = Math.Min(workingArea.Height, size.Height);
		Point empty = Point.Empty;
		empty.X = screenRect.Left;
		empty.Y = screenRect.Bottom;
		empty.X = Math.Max(empty.X, workingArea.X);
		empty.Y = Math.Max(empty.Y, workingArea.Y);
		if (empty.X + size.Width > workingArea.Right)
		{
			empty.X = workingArea.Right - size.Width;
		}
		if (empty.Y + size.Height > workingArea.Bottom)
		{
			empty.Y = workingArea.Bottom - size.Height;
		}
		base.Show(new Rectangle(empty, size));
	}

	public override bool DoesCurrentMouseDownEndAllTracking(Message m, Point pt)
	{
		if (_appButtonBottom.Visible)
		{
			if (RectangleToClient(_rectAppButtonTopHalf).Contains(pt))
			{
				return false;
			}
			if (base.ClientRectangle.Contains(pt) && _appButtonBottom.ClientRectangle.Contains(pt))
			{
				return true;
			}
		}
		return base.DoesCurrentMouseDownEndAllTracking(m, pt);
	}

	public override bool DoesStackedClientMouseDownBecomeCurrent(Message m, Point pt)
	{
		if (base.ClientRectangle.Contains(pt) && _appButtonBottom.Visible && _appButtonBottom.ClientRectangle.Contains(pt))
		{
			return false;
		}
		return ViewContextMenuManager.DoesStackedClientMouseDownBecomeCurrent(m, pt);
	}

	public override bool DoesMouseDownGetEaten(Message m, Point pt)
	{
		if (_rectAppButtonTopHalf.Contains(pt))
		{
			VisualPopupManager.Singleton.EndAllTracking();
			return true;
		}
		return base.DoesMouseDownGetEaten(m, pt);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override IPalette GetResolvedPalette()
	{
		return _palette;
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!base.IsDisposed && e.KeyData == Keys.Escape)
		{
			_provider.ProviderCloseReason = ToolStripDropDownCloseReason.Keyboard;
		}
		base.OnKeyDown(e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		using RenderContext context = new RenderContext(this, null, base.ClientRectangle, base.Renderer);
		Rectangle clientRectangle = base.ClientRectangle;
		GraphicsPath outsideBorderPath = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _drawOutsideBorder, VisualOrientation.Top, PaletteState.Normal);
		clientRectangle.Inflate(-1, -1);
		GraphicsPath outsideBorderPath2 = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _drawOutsideBorder, VisualOrientation.Top, PaletteState.Normal);
		clientRectangle.Inflate(-1, -1);
		GraphicsPath outsideBorderPath3 = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _drawOutsideBorder, VisualOrientation.Top, PaletteState.Normal);
		base.Region = new Region(outsideBorderPath);
		DefineShadowPaths(outsideBorderPath, outsideBorderPath2, outsideBorderPath3);
	}

	protected virtual void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		OnNeedPaint(sender, e);
	}

	private Size CalculatePreferredSize()
	{
		SuspendLayout();
		try
		{
			using ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer);
			return base.ViewManager.Root.GetPreferredSize(context);
		}
		finally
		{
			ResumeLayout();
		}
	}

	private void SetPalette(IPalette palette)
	{
		if (palette != _palette)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnPaletteNeedPaint;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			_palette = palette;
			_redirector.Target = _palette;
			base.Renderer = _palette.GetRenderer();
			if (_palette != null)
			{
				_palette.PalettePaint += OnPaletteNeedPaint;
				_palette.BasePaletteChanged += OnBaseChanged;
				_palette.BaseRendererChanged += OnBaseChanged;
			}
		}
	}

	private void OnBaseChanged(object sender, EventArgs e)
	{
		base.Renderer = _palette.GetRenderer();
	}

	private void OnButtonSpecPaint(object sender, NeedLayoutEventArgs e)
	{
		OnNeedPaint(sender, new NeedLayoutEventArgs(needLayout: false));
	}

	private void OnProviderClosing(object sender, CancelEventArgs e)
	{
		if (_ribbon != null)
		{
			_ribbon.OnAppButtonMenuClosing(e);
		}
	}

	private void OnProviderClose(object sender, CloseReasonEventArgs e)
	{
		VisualPopupManager.Singleton.EndPopupTracking(this);
	}

	private void OnProviderClose(object sender, EventArgs e)
	{
		IContextMenuProvider contextMenuProvider = (IContextMenuProvider)sender;
		_provider.Dispose -= OnProviderClose;
		Dispose();
	}
}
