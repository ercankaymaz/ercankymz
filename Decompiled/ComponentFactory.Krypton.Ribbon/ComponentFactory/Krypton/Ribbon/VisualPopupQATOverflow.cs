#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class VisualPopupQATOverflow : VisualPopup
{
	private KryptonRibbon _ribbon;

	private ViewDrawRibbonQATOverflow _viewQAT;

	private ViewLayoutRibbonQATContents _viewQATContents;

	public ViewRibbonQATOverflowManager ViewOverflowManager => base.ViewManager as ViewRibbonQATOverflowManager;

	public ViewLayoutRibbonQATContents ViewQATContents => _viewQATContents;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Style |= 33554432;
			return createParams;
		}
	}

	public VisualPopupQATOverflow(KryptonRibbon ribbon, ViewLayoutRibbonQATContents contents, IRenderer renderer)
		: base(renderer, shadow: true)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_viewQAT = new ViewDrawRibbonQATOverflow(ribbon, base.NeedPaintDelegate);
		_viewQATContents = new ViewLayoutRibbonQATFromOverflow(this, ribbon, base.NeedPaintDelegate, showExtraButton: true, contents);
		_viewQAT.Add(_viewQATContents);
		base.ViewManager = new ViewRibbonQATOverflowManager(ribbon, this, _viewQATContents, _viewQAT);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			base.ViewManager.MouseLeave(EventArgs.Empty);
			for (int num = base.Controls.Count - 1; num >= 0; num--)
			{
				base.Controls.RemoveAt(0);
			}
			if (_ribbon.InKeyboardMode && _ribbon.KeyTipMode == KeyTipMode.PopupQATOverflow)
			{
				_ribbon.KeyTipMode = KeyTipMode.Root;
				_ribbon.SetKeyTips(_ribbon.GenerateKeyTipsAtTopLevel(), KeyTipMode.Root);
			}
		}
		base.Dispose(disposing);
	}

	public void SetFirstFocusItem()
	{
		ViewOverflowManager.FocusView = _viewQATContents.GetFirstQATView();
		PerformNeedPaint(needLayout: false);
	}

	public void SetLastFocusItem()
	{
		ViewOverflowManager.FocusView = _viewQATContents.GetLastQATView();
		PerformNeedPaint(needLayout: false);
	}

	public void SetNextFocusItem()
	{
		ViewBase nextQATView = _viewQATContents.GetNextQATView(ViewOverflowManager.FocusView);
		if (nextQATView == null)
		{
			SetFirstFocusItem();
			return;
		}
		ViewOverflowManager.FocusView = nextQATView;
		PerformNeedPaint(needLayout: false);
	}

	public void SetPreviousFocusItem()
	{
		ViewBase previousQATView = _viewQATContents.GetPreviousQATView(ViewOverflowManager.FocusView);
		if (previousQATView == null)
		{
			SetLastFocusItem();
			return;
		}
		ViewOverflowManager.FocusView = previousQATView;
		PerformNeedPaint(needLayout: false);
	}

	public void ShowCalculatingSize(Rectangle parentScreenRect, EventHandler finishDelegate)
	{
		Size preferredSize;
		using (ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer))
		{
			preferredSize = _viewQAT.GetPreferredSize(context);
		}
		base.DismissedDelegate = finishDelegate;
		Show(parentScreenRect, preferredSize);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
		PaletteRibbonShape paletteRibbonShape = ribbonShape;
		int rounding = ((paletteRibbonShape != PaletteRibbonShape.Office2007 && paletteRibbonShape == PaletteRibbonShape.Office2010) ? 1 : 2);
		using GraphicsPath path = CommonHelper.RoundedRectanglePath(base.ClientRectangle, rounding);
		base.Region = new Region(path);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (_ribbon.InKeyboardMode && _ribbon.InKeyTipsMode)
		{
			_ribbon.AppendKeyTipPress(char.ToUpper(e.KeyChar));
		}
		base.OnKeyPress(e);
	}
}
