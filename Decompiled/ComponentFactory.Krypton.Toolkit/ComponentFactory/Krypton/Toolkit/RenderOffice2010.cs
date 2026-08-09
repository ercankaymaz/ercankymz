#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class RenderOffice2010 : RenderProfessional
{
	private static readonly float BORDER_PERCENT;

	private static readonly float WHITE_PERCENT;

	private static readonly Blend _ribbonGroup5Blend;

	private static readonly Blend _ribbonGroup6Blend;

	private static readonly Blend _ribbonGroup7Blend;

	static RenderOffice2010()
	{
		BORDER_PERCENT = 0.6f;
		WHITE_PERCENT = 0.4f;
		_ribbonGroup5Blend = new Blend();
		_ribbonGroup5Blend.Factors = new float[3] { 0f, 0f, 1f };
		_ribbonGroup5Blend.Positions = new float[3] { 0f, 0.5f, 1f };
		_ribbonGroup6Blend = new Blend();
		_ribbonGroup6Blend.Factors = new float[4] { 0f, 0f, 0.75f, 1f };
		_ribbonGroup6Blend.Positions = new float[4] { 0f, 0.1f, 0.45f, 1f };
		_ribbonGroup7Blend = new Blend();
		_ribbonGroup7Blend.Factors = new float[4] { 0f, 1f, 1f, 0f };
		_ribbonGroup7Blend.Positions = new float[4] { 0f, 0.15f, 0.85f, 1f };
	}

	public override void DrawRibbonClusterEdge(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteBack != null);
		Color backColor = paletteBack.GetBackColor1(state);
		Color color = CommonHelper.MergeColors(backColor, BORDER_PERCENT, Color.White, WHITE_PERCENT);
		using SolidBrush brush = new SolidBrush(color);
		context.Graphics.FillRectangle(brush, displayRect);
	}

	public override ToolStripRenderer RenderToolStrip(IPalette colorPalette)
	{
		Debug.Assert(colorPalette != null);
		if (colorPalette == null)
		{
			throw new ArgumentNullException("colorPalette");
		}
		KryptonOffice2010Renderer kryptonOffice2010Renderer = new KryptonOffice2010Renderer(colorPalette.ColorTable);
		kryptonOffice2010Renderer.RoundedEdges = colorPalette.ColorTable.UseRoundedEdges != InheritBool.False;
		return kryptonOffice2010Renderer;
	}

	protected override IDisposable DrawRibbonTabContext(RenderContext context, Rectangle rect, IPaletteRibbonGeneral paletteGeneral, IPaletteRibbonBack paletteBack, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonTabSeparatorContextColor = paletteGeneral.GetRibbonTabSeparatorContextColor(PaletteState.Normal);
			Color ribbonBackColor = paletteBack.GetRibbonBackColor5(PaletteState.ContextCheckedNormal);
			bool flag = true;
			MementoRibbonTabContextOffice2010 mementoRibbonTabContextOffice;
			if (memento == null || !(memento is MementoRibbonTabContextOffice2010))
			{
				memento?.Dispose();
				mementoRibbonTabContextOffice = new MementoRibbonTabContextOffice2010(rect, ribbonTabSeparatorContextColor, ribbonBackColor);
				memento = mementoRibbonTabContextOffice;
			}
			else
			{
				mementoRibbonTabContextOffice = (MementoRibbonTabContextOffice2010)memento;
				flag = !mementoRibbonTabContextOffice.UseCachedValues(rect, ribbonTabSeparatorContextColor, ribbonBackColor);
			}
			if (flag)
			{
				mementoRibbonTabContextOffice.Dispose();
				mementoRibbonTabContextOffice.borderOuterPen = new Pen(ribbonTabSeparatorContextColor);
				mementoRibbonTabContextOffice.borderInnerPen = new Pen(CommonHelper.MergeColors(Color.Black, 0.1f, ribbonBackColor, 0.9f));
				mementoRibbonTabContextOffice.topBrush = new SolidBrush(ribbonBackColor);
				Color baseColor = ControlPaint.Light(ribbonBackColor);
				mementoRibbonTabContextOffice.bottomBrush = new LinearGradientBrush(new RectangleF(rect.X - 1, rect.Y, rect.Width + 2, rect.Height + 1), Color.FromArgb(128, baseColor), Color.FromArgb(64, baseColor), 90f);
			}
			context.Graphics.DrawLine(mementoRibbonTabContextOffice.borderOuterPen, rect.X, rect.Y, rect.X, rect.Bottom);
			context.Graphics.DrawLine(mementoRibbonTabContextOffice.borderInnerPen, rect.X + 1, rect.Y, rect.X + 1, rect.Bottom - 1);
			context.Graphics.DrawLine(mementoRibbonTabContextOffice.borderOuterPen, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 1);
			context.Graphics.DrawLine(mementoRibbonTabContextOffice.borderInnerPen, rect.Right - 2, rect.Y, rect.Right - 2, rect.Bottom - 1);
			context.Graphics.FillRectangle(mementoRibbonTabContextOffice.topBrush, rect.X + 2, rect.Y, rect.Width - 4, 4);
			context.Graphics.FillRectangle(mementoRibbonTabContextOffice.bottomBrush, rect.X + 2, rect.Y + 4, rect.Width - 4, rect.Height - 4);
		}
		return memento;
	}
}
