using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class VisualContextMenu : VisualPopup
{
	private KryptonContextMenu _contextMenu;

	private IPalette _palette;

	private ContextMenuProvider _provider;

	private ViewDrawDocker _drawDocker;

	private ViewLayoutStack _viewColumns;

	private PaletteRedirect _redirector;

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

	public VisualContextMenu(IContextMenuProvider provider, KryptonContextMenuCollection items, bool keyboardActivated)
		: base(shadow: true)
	{
		_redirector = provider.ProviderRedirector;
		base.ViewManager = new ViewContextMenuManager(this, new ViewLayoutNull());
		if (provider.ProviderPalette != null)
		{
			SetPalette(provider.ProviderPalette);
		}
		else
		{
			SetPalette(KryptonManager.GetPaletteForMode(provider.ProviderPaletteMode));
		}
		_viewColumns = new ViewLayoutStack(horizontal: true);
		_provider = new ContextMenuProvider(provider, (ViewContextMenuManager)base.ViewManager, _viewColumns, base.NeedPaintDelegate);
		_provider.Closing += OnProviderClosing;
		_provider.Close += OnProviderClose;
		_provider.Dispose += OnProviderClose;
		Construct(items, keyboardActivated);
	}

	public VisualContextMenu(KryptonContextMenu contextMenu, IPalette palette, PaletteMode paletteMode, PaletteRedirect redirector, PaletteRedirectContextMenu redirectorImages, KryptonContextMenuCollection items, bool enabled, bool keyboardActivated)
		: base(shadow: true)
	{
		_contextMenu = contextMenu;
		_redirector = redirector;
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
		_provider = new ContextMenuProvider(contextMenu, (ViewContextMenuManager)base.ViewManager, _viewColumns, palette, paletteMode, redirector, redirectorImages, base.NeedPaintDelegate, enabled);
		_provider.Closing += OnProviderClosing;
		_provider.Close += OnProviderClose;
		_provider.Dispose += OnProviderClose;
		Construct(items, keyboardActivated);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _palette != null)
		{
			_palette.PalettePaint -= OnPaletteNeedPaint;
			_palette.BasePaletteChanged -= OnBaseChanged;
			_palette.BaseRendererChanged -= OnBaseChanged;
		}
		base.Dispose(disposing);
	}

	public new void Show()
	{
		Show(Control.MousePosition);
	}

	public void Show(Point screenPt)
	{
		Show(new Rectangle(screenPt, Size.Empty));
	}

	public new void Show(Rectangle screenRect)
	{
		Show(screenRect, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below);
	}

	public void Show(Rectangle screenRect, KryptonContextMenuPositionH horz, KryptonContextMenuPositionV vert)
	{
		Show(screenRect, horz, vert, bounce: false, constrain: true);
	}

	public void Show(Rectangle screenRect, KryptonContextMenuPositionH horz, KryptonContextMenuPositionV vert, bool bounce, bool constrain)
	{
		Size size = CalculatePreferredSize();
		Rectangle workingArea = Screen.GetWorkingArea(screenRect);
		if (constrain)
		{
			size.Width = Math.Min(workingArea.Width, size.Width);
			size.Height = Math.Min(workingArea.Height, size.Height);
		}
		Point empty = Point.Empty;
		switch (horz)
		{
		case KryptonContextMenuPositionH.After:
			empty.X = screenRect.Right;
			break;
		case KryptonContextMenuPositionH.Before:
			empty.X = screenRect.Left - size.Width;
			break;
		case KryptonContextMenuPositionH.Left:
			empty.X = screenRect.Left;
			break;
		case KryptonContextMenuPositionH.Right:
			empty.X = screenRect.Right - size.Width;
			break;
		}
		switch (vert)
		{
		case KryptonContextMenuPositionV.Above:
			empty.Y = screenRect.Top - size.Height;
			break;
		case KryptonContextMenuPositionV.Below:
			empty.Y = screenRect.Bottom;
			break;
		case KryptonContextMenuPositionV.Top:
			empty.Y = screenRect.Top;
			break;
		case KryptonContextMenuPositionV.Bottom:
			empty.Y = screenRect.Bottom - size.Height;
			break;
		}
		if (bounce)
		{
			if (empty.X + size.Width > workingArea.Right && (horz == KryptonContextMenuPositionH.After || horz == KryptonContextMenuPositionH.Left))
			{
				horz = KryptonContextMenuPositionH.Before;
				empty.X = screenRect.Left - size.Width;
			}
			if (empty.X < workingArea.X && (horz == KryptonContextMenuPositionH.Before || horz == KryptonContextMenuPositionH.Right))
			{
				horz = KryptonContextMenuPositionH.After;
				empty.X = screenRect.Right;
			}
			if (empty.Y + size.Height > workingArea.Bottom && (vert == KryptonContextMenuPositionV.Below || vert == KryptonContextMenuPositionV.Top))
			{
				vert = KryptonContextMenuPositionV.Bottom;
				empty.Y = screenRect.Bottom - size.Height;
			}
			if (empty.Y < workingArea.Y && (vert == KryptonContextMenuPositionV.Above || vert == KryptonContextMenuPositionV.Bottom))
			{
				vert = KryptonContextMenuPositionV.Top;
				empty.Y = screenRect.Top;
			}
		}
		if (constrain)
		{
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
		}
		ShowHorz = horz;
		ShowVert = vert;
		base.Show(new Rectangle(empty, size));
	}

	public void ShowFixed(Rectangle screenRect, KryptonContextMenuPositionH horz, KryptonContextMenuPositionV vert)
	{
		ShowHorz = horz;
		ShowVert = vert;
		base.Show(screenRect);
	}

	public override bool DoesStackedClientMouseDownBecomeCurrent(Message m, Point pt)
	{
		return ViewContextMenuManager.DoesStackedClientMouseDownBecomeCurrent(m, pt);
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
		GraphicsPath outsideBorderPath = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _provider.ProviderStateCommon.ControlOuter.Border, VisualOrientation.Top, PaletteState.Normal);
		clientRectangle.Inflate(-1, -1);
		GraphicsPath outsideBorderPath2 = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _provider.ProviderStateCommon.ControlOuter.Border, VisualOrientation.Top, PaletteState.Normal);
		clientRectangle.Inflate(-1, -1);
		GraphicsPath outsideBorderPath3 = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _provider.ProviderStateCommon.ControlOuter.Border, VisualOrientation.Top, PaletteState.Normal);
		base.Region = new Region(outsideBorderPath);
		DefineShadowPaths(outsideBorderPath, outsideBorderPath2, outsideBorderPath3);
	}

	protected virtual void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		OnNeedPaint(sender, e);
	}

	private void Construct(KryptonContextMenuCollection items, bool keyboardActivated)
	{
		items.GenerateView(_provider, this, _viewColumns, standardStyle: true, imageColumn: true);
		ViewDrawCanvas viewDrawCanvas = new ViewDrawCanvas(_provider.ProviderStateCommon.ControlInner.Back, _provider.ProviderStateCommon.ControlInner.Border, VisualOrientation.Top);
		viewDrawCanvas.Add(_viewColumns);
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		Padding metricPadding = _provider.ProviderRedirector.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.ContextMenuItemOuter);
		viewLayoutDocker.Add(new ViewLayoutSeparator(metricPadding.Top), ViewDockStyle.Top);
		viewLayoutDocker.Add(new ViewLayoutSeparator(metricPadding.Bottom), ViewDockStyle.Bottom);
		viewLayoutDocker.Add(new ViewLayoutSeparator(metricPadding.Left), ViewDockStyle.Left);
		viewLayoutDocker.Add(new ViewLayoutSeparator(metricPadding.Right), ViewDockStyle.Right);
		viewLayoutDocker.Add(viewDrawCanvas, ViewDockStyle.Fill);
		_drawDocker = new ViewDrawDocker(_provider.ProviderStateCommon.ControlOuter.Back, _provider.ProviderStateCommon.ControlOuter.Border, null);
		_drawDocker.Add(viewLayoutDocker, ViewDockStyle.Fill);
		_drawDocker.KeyController = new ContextMenuController((ViewContextMenuManager)base.ViewManager);
		base.ViewManager.Root = _drawDocker;
		if (keyboardActivated)
		{
			((ViewContextMenuManager)base.ViewManager).KeyDown();
		}
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

	private void OnProviderClosing(object sender, CancelEventArgs e)
	{
		if (_contextMenu != null)
		{
			_contextMenu.OnClosing(e);
		}
	}

	private void OnProviderClose(object sender, CloseReasonEventArgs e)
	{
		if (_contextMenu != null)
		{
			_contextMenu.Close(e.CloseReason);
		}
	}

	private void OnProviderClose(object sender, EventArgs e)
	{
		ContextMenuProvider contextMenuProvider = (ContextMenuProvider)sender;
		_provider.Dispose -= OnProviderClose;
		Dispose();
	}
}
