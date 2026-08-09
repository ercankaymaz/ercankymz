#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonQATExtraButton : ViewLeaf
{
	private static readonly Size _viewSize = new Size(13, 22);

	private static readonly Size _contentSize = new Size(-4, -7);

	private KryptonRibbon _ribbon;

	private IDisposable _mementoBack;

	private EventHandler _finishDelegate;

	private bool _overflow;

	public IRibbonKeyTipTarget KeyTipTarget => SourceController as IRibbonKeyTipTarget;

	public bool Overflow
	{
		get
		{
			return _overflow;
		}
		set
		{
			_overflow = value;
		}
	}

	public override bool Visible
	{
		get
		{
			return _ribbon.Visible && base.Visible;
		}
		set
		{
			base.Visible = value;
		}
	}

	public event ClickAndFinishHandler ClickAndFinish;

	public ViewDrawRibbonQATExtraButton(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_finishDelegate = ClickFinished;
		QATExtraButtonController qATExtraButtonController = new QATExtraButtonController(ribbon, this, needPaint);
		qATExtraButtonController.Click += OnClick;
		MouseController = qATExtraButtonController;
		SourceController = qATExtraButtonController;
		KeyController = qATExtraButtonController;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonQATExtraButton:" + base.Id;
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
	}

	public override void RenderBefore(RenderContext context)
	{
		Enabled = _ribbon.Enabled;
		IPaletteBack paletteBack = _ribbon.StateCommon.RibbonGroupDialogButton.PaletteBack;
		IPaletteBorder paletteBorder = _ribbon.StateCommon.RibbonGroupDialogButton.PaletteBorder;
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
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.Inflate(_contentSize);
		if (Overflow)
		{
			context.Renderer.RenderGlyph.DrawRibbonOverflow(_ribbon.RibbonShape, context, clientRectangle, ribbonGeneral, State);
		}
		else
		{
			context.Renderer.RenderGlyph.DrawRibbonContextArrow(_ribbon.RibbonShape, context, clientRectangle, ribbonGeneral, State);
		}
	}

	private void ClickFinished(object sender, EventArgs e)
	{
		LeftDownButtonController leftDownButtonController = (LeftDownButtonController)MouseController;
		leftDownButtonController.RemoveFixed();
	}

	private void OnClick(object sender, MouseEventArgs e)
	{
		_ribbon.FindForm()?.Activate();
		if (this.ClickAndFinish != null && !_ribbon.InDesignMode)
		{
			this.ClickAndFinish(this, _finishDelegate);
		}
		else
		{
			ClickFinished(this, EventArgs.Empty);
		}
	}
}
