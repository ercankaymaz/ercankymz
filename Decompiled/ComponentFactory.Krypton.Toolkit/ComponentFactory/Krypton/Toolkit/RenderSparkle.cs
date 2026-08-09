#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class RenderSparkle : RenderProfessional
{
	private static readonly Blend _ribbonGroup5Blend;

	private static readonly Blend _ribbonGroup6Blend;

	private static readonly Blend _ribbonGroup7Blend;

	static RenderSparkle()
	{
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

	public override IDisposable DrawRibbonBack(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, VisualOrientation orientation, bool composition, IDisposable memento)
	{
		if ((state & PaletteState.FocusOverride) == PaletteState.FocusOverride)
		{
			state &= ~PaletteState.FocusOverride;
		}
		return palette.GetRibbonBackColorStyle(state) switch
		{
			PaletteRibbonColorStyle.RibbonGroupNormalBorderTracking => DrawRibbonGroupNormalBorder(context, rect, state, palette, tracking: true, lightInside: false, memento), 
			PaletteRibbonColorStyle.RibbonGroupAreaBorder => DrawRibbonGroupAreaBorder1And2(context, rect, state, palette, limited: false, fading: true, memento), 
			PaletteRibbonColorStyle.RibbonGroupAreaBorder2 => DrawRibbonGroupAreaBorder1And2(context, rect, state, palette, limited: true, fading: true, memento), 
			_ => base.DrawRibbonBack(shape, context, rect, state, palette, orientation, composition, memento), 
		};
	}

	public override IDisposable DrawRibbonTabContextTitle(PaletteRibbonShape shape, RenderContext context, Rectangle rect, IPaletteRibbonGeneral paletteGeneral, IPaletteRibbonBack paletteBack, IDisposable memento)
	{
		return DrawRibbonTabContext(context, rect, paletteGeneral, paletteBack, memento);
	}

	public override IDisposable DrawRibbonApplicationButton(PaletteRibbonShape shape, RenderContext context, Rectangle rect, PaletteState state, IPaletteRibbonBack palette, IDisposable memento)
	{
		return DrawRibbonAppButton(shape, context, rect, state, palette, trackBorderAsPressed: true, memento);
	}

	public override void DrawRibbonDropArrow(PaletteRibbonShape shape, RenderContext context, Rectangle displayRect, IPaletteRibbonGeneral paletteGeneral, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteGeneral != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteGeneral == null)
		{
			throw new ArgumentNullException("paletteGeneral");
		}
		Color color = ((state == PaletteState.Disabled) ? paletteGeneral.GetRibbonDisabledDark(state) : paletteGeneral.GetRibbonGroupDialogDark(state));
		Color color2 = ((state == PaletteState.Disabled) ? paletteGeneral.GetRibbonDisabledLight(state) : paletteGeneral.GetRibbonGroupDialogLight(state));
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color2);
		context.Graphics.DrawLine(pen2, displayRect.Left, displayRect.Top + 1, displayRect.Left + 2, displayRect.Top + 3);
		context.Graphics.DrawLine(pen2, displayRect.Left + 2, displayRect.Top + 3, displayRect.Left + 4, displayRect.Top + 1);
		context.Graphics.DrawLine(pen2, displayRect.Left + 4, displayRect.Top + 1, displayRect.Left + 1, displayRect.Top + 1);
		context.Graphics.DrawLine(pen2, displayRect.Left + 1, displayRect.Top + 1, displayRect.Left + 2, displayRect.Top + 2);
		context.Graphics.DrawLine(pen, displayRect.Left, displayRect.Top + 2, displayRect.Left + 2, displayRect.Top + 4);
		context.Graphics.DrawLine(pen, displayRect.Left + 2, displayRect.Top + 4, displayRect.Left + 4, displayRect.Top + 2);
	}

	public override void DrawInputControlDropDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteContent == null)
		{
			throw new ArgumentNullException("paletteContent");
		}
		Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
		int num = cellRect.Left + (cellRect.Right - cellRect.Left - 4) / 2;
		int num2 = cellRect.Top + (cellRect.Bottom - cellRect.Top - 3) / 2;
		using Pen pen = new Pen(contentShortTextColor);
		context.Graphics.DrawLine(pen, num, num2, num + 4, num2);
		context.Graphics.DrawLine(pen, num + 1, num2 + 1, num + 3, num2 + 1);
		context.Graphics.DrawLine(pen, num + 2, num2 + 2, num + 2, num2 + 1);
	}

	public override void DrawInputControlNumericUpGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteContent == null)
		{
			throw new ArgumentNullException("paletteContent");
		}
		Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
		int num = cellRect.Left + (cellRect.Right - cellRect.Left - 4) / 2;
		int num2 = cellRect.Top + (cellRect.Bottom - cellRect.Top - 3) / 2;
		using Pen pen = new Pen(contentShortTextColor);
		context.Graphics.DrawLine(pen, num, num2 + 3, num + 4, num2 + 3);
		context.Graphics.DrawLine(pen, num + 1, num2 + 2, num + 3, num2 + 2);
		context.Graphics.DrawLine(pen, num + 2, num2 + 2, num + 2, num2 + 1);
	}

	public override void DrawInputControlNumericDownGlyph(RenderContext context, Rectangle cellRect, IPaletteContent paletteContent, PaletteState state)
	{
		Debug.Assert(context != null);
		Debug.Assert(paletteContent != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (paletteContent == null)
		{
			throw new ArgumentNullException("paletteContent");
		}
		Color contentShortTextColor = paletteContent.GetContentShortTextColor1(state);
		int num = cellRect.Left + (cellRect.Right - cellRect.Left - 4) / 2;
		int num2 = cellRect.Top + (cellRect.Bottom - cellRect.Top - 3) / 2;
		using Pen pen = new Pen(contentShortTextColor);
		context.Graphics.DrawLine(pen, num, num2, num + 4, num2);
		context.Graphics.DrawLine(pen, num + 1, num2 + 1, num + 3, num2 + 1);
		context.Graphics.DrawLine(pen, num + 2, num2 + 2, num + 2, num2 + 1);
	}

	public override ToolStripRenderer RenderToolStrip(IPalette colorPalette)
	{
		Debug.Assert(colorPalette != null);
		if (colorPalette == null)
		{
			throw new ArgumentNullException("colorPalette");
		}
		KryptonSparkleRenderer kryptonSparkleRenderer = new KryptonSparkleRenderer(colorPalette.ColorTable);
		kryptonSparkleRenderer.RoundedEdges = colorPalette.ColorTable.UseRoundedEdges != InheritBool.False;
		return kryptonSparkleRenderer;
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
