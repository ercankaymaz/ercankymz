#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupDialogButton : ViewLeaf
{
	private static readonly Size _viewSize = new Size(14, 14);

	private static readonly Size _contentSize = new Size(-3, -3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroup _ribbonGroup;

	private IDisposable _mementoBack;

	public DialogLauncherButtonController DialogButtonController => SourceController as DialogLauncherButtonController;

	public ViewDrawRibbonGroupDialogButton(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGroup != null);
		_ribbon = ribbon;
		_ribbonGroup = ribbonGroup;
		DialogLauncherButtonController dialogLauncherButtonController = new DialogLauncherButtonController(ribbon, this, needPaint);
		dialogLauncherButtonController.Click += OnClick;
		MouseController = dialogLauncherButtonController;
		SourceController = dialogLauncherButtonController;
		KeyController = dialogLauncherButtonController;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupButton:" + base.Id;
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
		context.Renderer.RenderGlyph.DrawRibbonDialogBoxLauncher(_ribbon.RibbonShape, context, clientRectangle, ribbonGeneral, State);
	}

	private void OnClick(object sender, MouseEventArgs e)
	{
		if (!_ribbon.InDesignMode)
		{
			_ribbonGroup.OnDialogBoxLauncherClick(EventArgs.Empty);
		}
	}
}
