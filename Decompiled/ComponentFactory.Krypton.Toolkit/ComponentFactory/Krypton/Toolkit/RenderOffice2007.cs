#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class RenderOffice2007 : RenderProfessional
{
	private static readonly float BORDER_PERCENT;

	private static readonly float WHITE_PERCENT;

	private static readonly Blend _ribbonGroup5Blend;

	private static readonly Blend _ribbonGroup6Blend;

	private static readonly Blend _ribbonGroup7Blend;

	static RenderOffice2007()
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
		KryptonOffice2007Renderer kryptonOffice2007Renderer = new KryptonOffice2007Renderer(colorPalette.ColorTable);
		kryptonOffice2007Renderer.RoundedEdges = colorPalette.ColorTable.UseRoundedEdges != InheritBool.False;
		return kryptonOffice2007Renderer;
	}

	protected override IDisposable DrawRibbonTabContext(RenderContext context, Rectangle rect, IPaletteRibbonGeneral paletteGeneral, IPaletteRibbonBack paletteBack, IDisposable memento)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			Color ribbonTabSeparatorContextColor = paletteGeneral.GetRibbonTabSeparatorContextColor(PaletteState.Normal);
			Color ribbonBackColor = paletteBack.GetRibbonBackColor5(PaletteState.ContextCheckedNormal);
			bool flag = true;
			MementoRibbonTabContextOffice mementoRibbonTabContextOffice;
			if (memento == null || !(memento is MementoRibbonTabContextOffice))
			{
				memento?.Dispose();
				mementoRibbonTabContextOffice = new MementoRibbonTabContextOffice(rect, ribbonTabSeparatorContextColor, ribbonBackColor);
				memento = mementoRibbonTabContextOffice;
			}
			else
			{
				mementoRibbonTabContextOffice = (MementoRibbonTabContextOffice)memento;
				flag = !mementoRibbonTabContextOffice.UseCachedValues(rect, ribbonTabSeparatorContextColor, ribbonBackColor);
			}
			if (flag)
			{
				mementoRibbonTabContextOffice.Dispose();
				Rectangle rect2 = new Rectangle(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2);
				mementoRibbonTabContextOffice.fillRect = new Rectangle(rect.X + 1, rect.Y, rect.Width - 2, rect.Height - 1);
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, ribbonTabSeparatorContextColor, Color.Transparent, 270f);
				linearGradientBrush.Blend = _ribbonGroup5Blend;
				mementoRibbonTabContextOffice.borderPen = new Pen(linearGradientBrush);
				LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect2, Color.Transparent, Color.FromArgb(200, ribbonBackColor), 0f);
				linearGradientBrush2.Blend = _ribbonGroup7Blend;
				mementoRibbonTabContextOffice.underlinePen = new Pen(linearGradientBrush2);
				mementoRibbonTabContextOffice.fillBrush = new LinearGradientBrush(rect2, Color.FromArgb(106, ribbonBackColor), Color.Transparent, 270f);
				mementoRibbonTabContextOffice.fillBrush.Blend = _ribbonGroup6Blend;
			}
			context.Graphics.DrawLine(mementoRibbonTabContextOffice.borderPen, rect.X, rect.Y, rect.X, rect.Bottom - 1);
			context.Graphics.DrawLine(mementoRibbonTabContextOffice.borderPen, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 1);
			context.Graphics.FillRectangle(mementoRibbonTabContextOffice.fillBrush, mementoRibbonTabContextOffice.fillRect);
			context.Graphics.DrawLine(mementoRibbonTabContextOffice.underlinePen, rect.X + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
		}
		return memento;
	}
}
