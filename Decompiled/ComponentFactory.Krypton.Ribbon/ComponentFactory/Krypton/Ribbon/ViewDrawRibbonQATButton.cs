#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonQATButton : ViewComposite, IContentValues
{
	private static readonly Size _viewSize = new Size(22, 22);

	private KryptonRibbon _ribbon;

	private IQuickAccessToolbarButton _qatButton;

	private QATButtonToContent _contentProvider;

	private ViewDrawContent _drawContent;

	private IDisposable _mementoBack;

	public IRibbonKeyTipTarget KeyTipTarget => SourceController as IRibbonKeyTipTarget;

	public IQuickAccessToolbarButton QATButton => _qatButton;

	public override bool Enabled
	{
		get
		{
			return base.Enabled && _ribbon.Enabled;
		}
		set
		{
			base.Enabled = value;
			UpdateEnabled();
		}
	}

	public ViewDrawRibbonQATButton(KryptonRibbon ribbon, IQuickAccessToolbarButton qatButton, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(qatButton != null);
		_ribbon = ribbon;
		_qatButton = qatButton;
		Component = qatButton as Component;
		QATButtonController qATButtonController = new QATButtonController(ribbon, this, needPaint);
		qATButtonController.Click += OnClick;
		SourceController = qATButtonController;
		KeyController = qATButtonController;
		MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, this, qATButtonController);
		_contentProvider = new QATButtonToContent(qatButton);
		_drawContent = new ViewDrawContent(_contentProvider, this, VisualOrientation.Top);
		Add(_drawContent);
		_ribbon.EnabledChanged += OnRibbonEnableChanged;
		UpdateEnabled();
	}

	public override string ToString()
	{
		return "ViewDrawRibbonQATButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _mementoBack != null)
		{
			_mementoBack.Dispose();
			_mementoBack = null;
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _viewSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	public override void RenderBefore(RenderContext context)
	{
		if (!Enabled && _ribbon.InDesignHelperMode)
		{
			ElementState = PaletteState.Disabled;
		}
		IPaletteBack paletteBack = _ribbon.StateCommon.RibbonQATButton.PaletteBack;
		IPaletteBorder paletteBorder = _ribbon.StateCommon.RibbonQATButton.PaletteBorder;
		IPaletteRibbonGeneral ribbonGeneral = _ribbon.StateCommon.RibbonGeneral;
		if (paletteBack.GetBackDraw(State) == InheritBool.True)
		{
			using GraphicsPath path = context.Renderer.RenderStandardBorder.GetBackPath(context, ClientRectangle, paletteBorder, VisualOrientation.Top, State);
			Padding borderRawPadding = context.Renderer.RenderStandardBorder.GetBorderRawPadding(paletteBorder, State, VisualOrientation.Top);
			Rectangle rect = CommonHelper.ApplyPadding(VisualOrientation.Top, ClientRectangle, borderRawPadding);
			_mementoBack = context.Renderer.RenderStandardBack.DrawBack(context, rect, path, paletteBack, VisualOrientation.Top, State, _mementoBack);
		}
		if (paletteBorder.GetBorderDraw(State) == InheritBool.True)
		{
			context.Renderer.RenderStandardBorder.DrawBorder(context, ClientRectangle, paletteBorder, VisualOrientation.Top, State);
		}
		base.RenderBefore(context);
	}

	private void OnRibbonEnableChanged(object sender, EventArgs e)
	{
		UpdateEnabled();
	}

	private void UpdateEnabled()
	{
		_drawContent.Enabled = base.Enabled && _ribbon.Enabled;
	}

	private void OnClick(object sender, MouseEventArgs e)
	{
		if (!_ribbon.InDesignMode)
		{
			_ribbon.FindForm()?.Activate();
			_qatButton.PerformClick();
		}
	}

	public Image GetImage(PaletteState state)
	{
		return _qatButton.GetImage();
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
