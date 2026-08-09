using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class RenderProfessional : RenderStandard
{
	private static readonly int _grabSquareLength = 2;

	private static readonly int _grabSquareOffset = 1;

	private static readonly int _grabSquareTotal = 3;

	private static readonly int _grabSquareGap = 1;

	private static readonly int _grabSquareMinSpace = 5;

	private static readonly int _grabSquareCount = 5;

	private static readonly Color _grabHandleLight = Color.FromArgb(228, 255, 255, 255);

	private static readonly Color _grabHandleDark = Color.FromArgb(144, 0, 0, 0);

	public override void DrawSeparator(RenderContext context, Rectangle displayRect, IPaletteBack paletteBack, IPaletteBorder paletteBorder, Orientation orientation, PaletteState state, bool canMove)
	{
		base.DrawSeparator(context, displayRect, paletteBack, paletteBorder, orientation, state, canMove);
		if (paletteBack.GetBackDraw(state) == InheritBool.True && canMove)
		{
			DrawGrabHandleGlyph(context, displayRect, orientation, state);
		}
	}

	protected virtual void DrawGrabHandleGlyph(RenderContext context, Rectangle displayRect, Orientation orientation, PaletteState state)
	{
		if (displayRect.Height < _grabSquareMinSpace || displayRect.Width < _grabSquareMinSpace)
		{
			return;
		}
		displayRect.Inflate(-_grabSquareGap, -_grabSquareGap);
		int num = ((orientation == Orientation.Horizontal) ? displayRect.Width : displayRect.Height);
		for (int num2 = _grabSquareCount; num2 > 0; num2--)
		{
			int num3 = num2 * _grabSquareTotal + ((num2 > 1) ? ((num2 - 1) * _grabSquareGap) : 0);
			if (num3 <= num)
			{
				int num4 = (num - num3) / 2;
				Point point = ((orientation != Orientation.Horizontal) ? new Point(displayRect.X + (displayRect.Width - _grabSquareTotal) / 2, displayRect.Y + num4) : new Point(displayRect.X + num4, displayRect.Y + (displayRect.Height - _grabSquareTotal) / 2));
				using Brush brush = new SolidBrush(_grabHandleLight);
				using Brush brush2 = new SolidBrush(_grabHandleDark);
				for (int i = 0; i < num2; i++)
				{
					context.Graphics.FillRectangle(brush, point.X + _grabSquareOffset, point.Y + _grabSquareOffset, _grabSquareLength, _grabSquareLength);
					context.Graphics.FillRectangle(brush2, point.X, point.Y, _grabSquareLength, _grabSquareLength);
					if (orientation == Orientation.Horizontal)
					{
						point.X += _grabSquareTotal + _grabSquareGap;
					}
					else
					{
						point.Y += _grabSquareTotal + _grabSquareGap;
					}
				}
				break;
			}
		}
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
