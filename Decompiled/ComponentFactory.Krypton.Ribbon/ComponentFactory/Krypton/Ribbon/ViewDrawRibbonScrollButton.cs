#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonScrollButton : ViewLeaf
{
	private KryptonRibbon _ribbon;

	private VisualOrientation _orientation;

	private IDisposable _mementoBack;

	public VisualOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public ViewDrawRibbonScrollButton(KryptonRibbon ribbon, VisualOrientation orientation)
	{
		_ribbon = ribbon;
		_orientation = orientation;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonScrollButton:" + base.Id;
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
		return Size.Empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.X++;
		clientRectangle.Y++;
		Rectangle clientRectangle2 = ClientRectangle;
		clientRectangle2.Inflate(-1, -1);
		using GraphicsPath path = CreateBorderPath(ClientRectangle);
		using GraphicsPath path2 = CreateBorderPath(clientRectangle);
		if (_ribbon.StateCommon.RibbonScroller.PaletteBorder.GetBorderDraw(State) == InheritBool.True)
		{
			using (new AntiAlias(context.Graphics))
			{
				using SolidBrush brush = new SolidBrush(Color.FromArgb(16, Color.Black));
				context.Graphics.FillPath(brush, path2);
			}
		}
		if (_ribbon.StateCommon.RibbonScroller.PaletteBack.GetBackDraw(State) == InheritBool.True)
		{
			_mementoBack = context.Renderer.RenderStandardBack.DrawBack(context, clientRectangle2, path, _ribbon.StateCommon.RibbonScroller.PaletteBack, VisualOrientation.Top, State, _mementoBack);
		}
		if (_ribbon.StateCommon.RibbonScroller.PaletteContent.GetContentDraw(State) == InheritBool.True)
		{
			Color contentShortTextColor = _ribbon.StateCommon.RibbonScroller.PaletteContent.GetContentShortTextColor1(State);
			DrawArrow(context.Graphics, contentShortTextColor, clientRectangle2);
		}
		if (_ribbon.StateCommon.RibbonScroller.PaletteBorder.GetBorderDraw(State) != InheritBool.True)
		{
			return;
		}
		Color borderColor = _ribbon.StateCommon.RibbonScroller.PaletteBorder.GetBorderColor1(State);
		using (new AntiAlias(context.Graphics))
		{
			using Pen pen = new Pen(borderColor);
			context.Graphics.DrawPath(pen, path);
		}
	}

	private GraphicsPath CreateBorderPath(Rectangle rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (Orientation)
		{
		case VisualOrientation.Top:
			graphicsPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left, rect.Top + 2);
			graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left + 2, rect.Top);
			graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Right - 3, rect.Top);
			graphicsPath.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
			graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
			break;
		case VisualOrientation.Bottom:
			graphicsPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Bottom - 3);
			graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 3, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 3);
			graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 1, rect.Top);
			graphicsPath.AddLine(rect.Right - 1, rect.Top, rect.Left, rect.Top);
			break;
		case VisualOrientation.Left:
			graphicsPath.AddLine(rect.Right - 1, rect.Top, rect.Left + 2, rect.Top);
			graphicsPath.AddLine(rect.Left + 2, rect.Top, rect.Left, rect.Top + 2);
			graphicsPath.AddLine(rect.Left, rect.Top + 2, rect.Left, rect.Bottom - 3);
			graphicsPath.AddLine(rect.Left, rect.Bottom - 3, rect.Left + 2, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Left + 2, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Right - 1, rect.Top);
			break;
		case VisualOrientation.Right:
			graphicsPath.AddLine(rect.Left, rect.Top, rect.Right - 3, rect.Top);
			graphicsPath.AddLine(rect.Right - 3, rect.Top, rect.Right - 1, rect.Top + 2);
			graphicsPath.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom - 3);
			graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Right - 3, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left, rect.Top);
			break;
		}
		return graphicsPath;
	}

	private void DrawArrow(Graphics g, Color textColor, Rectangle rect)
	{
		using GraphicsPath path = CreateArrowPath(rect);
		using SolidBrush brush = new SolidBrush(textColor);
		g.FillPath(brush, path);
	}

	private GraphicsPath CreateArrowPath(Rectangle rect)
	{
		int num;
		int num2;
		if (Orientation == VisualOrientation.Left || Orientation == VisualOrientation.Right)
		{
			num = rect.Right - (rect.Width - 4) / 2;
			num2 = rect.Y + rect.Height / 2;
		}
		else
		{
			num = rect.X + rect.Width / 2;
			num2 = rect.Bottom - (rect.Height - 3) / 2;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (Orientation)
		{
		case VisualOrientation.Right:
			graphicsPath.AddLine(num, num2, num - 4, num2 - 4);
			graphicsPath.AddLine(num - 4, num2 - 4, num - 4, num2 + 4);
			graphicsPath.AddLine(num - 4, num2 + 4, num, num2);
			break;
		case VisualOrientation.Left:
			graphicsPath.AddLine(num - 4, num2, num, num2 - 4);
			graphicsPath.AddLine(num, num2 - 4, num, num2 + 4);
			graphicsPath.AddLine(num, num2 + 4, num - 4, num2);
			break;
		case VisualOrientation.Bottom:
			graphicsPath.AddLine((float)num + 3f, (float)num2 - 3f, (float)num - 2f, (float)num2 - 3f);
			graphicsPath.AddLine((float)num - 2f, (float)num2 - 3f, num, num2);
			graphicsPath.AddLine(num, num2, (float)num + 3f, (float)num2 - 3f);
			break;
		case VisualOrientation.Top:
			graphicsPath.AddLine((float)num + 3f, num2, (float)num - 3f, num2);
			graphicsPath.AddLine((float)num - 3f, num2, num, (float)num2 - 4f);
			graphicsPath.AddLine(num, (float)num2 - 4f, (float)num + 3f, num2);
			break;
		}
		return graphicsPath;
	}
}
