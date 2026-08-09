#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonTabSep : ViewLayoutRibbonSeparator
{
	private static readonly int SEP_WIDTH;

	private static readonly Color _lighten1;

	private static readonly Blend _fadeBlend;

	private IPaletteRibbonGeneral _palette;

	private bool _draw;

	public bool Draw
	{
		get
		{
			return _draw;
		}
		set
		{
			_draw = value;
		}
	}

	static ViewDrawRibbonTabSep()
	{
		SEP_WIDTH = 4;
		_lighten1 = Color.FromArgb(128, Color.White);
		_fadeBlend = new Blend();
		_fadeBlend.Factors = new float[3] { 0f, 1f, 1f };
		_fadeBlend.Positions = new float[3] { 0f, 0.33f, 1f };
	}

	public ViewDrawRibbonTabSep(IPaletteRibbonGeneral palette)
		: base(SEP_WIDTH, ignoreMouse: true)
	{
		Debug.Assert(palette != null);
		_palette = palette;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonTabSep:" + base.Id;
	}

	public override void RenderBefore(RenderContext context)
	{
		if (!Draw)
		{
			return;
		}
		RectangleF rect = new RectangleF(ClientLocation.X, (float)ClientLocation.Y - 0.5f, ClientWidth, ClientHeight + 1);
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Transparent, _palette.GetRibbonTabSeparatorColor(PaletteState.Normal), 90f);
		linearGradientBrush.Blend = _fadeBlend;
		PaletteRibbonShape ribbonShape = _palette.GetRibbonShape();
		PaletteRibbonShape paletteRibbonShape = ribbonShape;
		if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
		{
			context.Graphics.FillRectangle(linearGradientBrush, ClientLocation.X + 2, ClientLocation.Y, 1, ClientHeight - 1);
			return;
		}
		context.Graphics.FillRectangle(linearGradientBrush, ClientLocation.X + 1, ClientLocation.Y, 1, ClientHeight - 1);
		using LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, _lighten1, 90f);
		context.Graphics.FillRectangle(brush, ClientLocation.X + 2, ClientLocation.Y, 1, ClientHeight - 1);
	}
}
