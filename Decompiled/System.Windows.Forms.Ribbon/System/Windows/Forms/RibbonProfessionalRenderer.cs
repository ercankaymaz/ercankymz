using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms.RibbonHelpers;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms;

public class RibbonProfessionalRenderer : RibbonRenderer
{
	public enum Corners
	{
		None = 0,
		NorthWest = 2,
		NorthEast = 4,
		SouthEast = 8,
		SouthWest = 16,
		All = 30,
		North = 6,
		South = 24,
		East = 12,
		West = 18
	}

	private readonly Size arrowSize = new Size(5, 3);

	private readonly Ribbon _ownerRibbon;

	public Theme Theme
	{
		get
		{
			if (_ownerRibbon != null)
			{
				return _ownerRibbon.Theme;
			}
			return Theme.Standard;
		}
	}

	public RibbonProfesionalRendererColorTable ColorTable => Theme.RendererColorTable;

	public RibbonProfessionalRenderer(Ribbon ownerRibbon)
	{
		_ownerRibbon = ownerRibbon;
	}

	public Color GetTextColor(bool enabled, Color alternative)
	{
		if (enabled)
		{
			return alternative;
		}
		return ColorTable.ArrowDisabled;
	}

	public Color LightenColor(Color color, float correctionFactor)
	{
		float num = (int)color.R;
		float num2 = (int)color.G;
		float num3 = (int)color.B;
		if (0f < correctionFactor && correctionFactor < 1f)
		{
			num += (255f - num) * correctionFactor;
			num2 += (255f - num2) * correctionFactor;
			num3 += (255f - num3) * correctionFactor;
		}
		return Color.FromArgb(color.A, (int)num, (int)num2, (int)num3);
	}

	public Color DarkenColor(Color color, float correctionFactor)
	{
		float num = (int)color.R;
		float num2 = (int)color.G;
		float num3 = (int)color.B;
		if (0f < correctionFactor && correctionFactor < 1f)
		{
			num -= num * correctionFactor;
			num2 -= num2 * correctionFactor;
			num3 -= num3 * correctionFactor;
		}
		return Color.FromArgb(color.A, (int)num, (int)num2, (int)num3);
	}

	public static GraphicsPath RoundRectangle(Rectangle r, int radius)
	{
		return RoundRectangle(r, radius, Corners.All);
	}

	public static GraphicsPath RoundRectangle(Rectangle r, int radius, Corners corners)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = radius * 2;
		int num2 = (((corners & Corners.NorthWest) == Corners.NorthWest) ? num : 0);
		int num3 = (((corners & Corners.NorthEast) == Corners.NorthEast) ? num : 0);
		int num4 = (((corners & Corners.SouthEast) == Corners.SouthEast) ? num : 0);
		int num5 = (((corners & Corners.SouthWest) == Corners.SouthWest) ? num : 0);
		graphicsPath.AddLine(r.Left + num2, r.Top, r.Right - num3, r.Top);
		if (num3 > 0)
		{
			graphicsPath.AddArc(Rectangle.FromLTRB(r.Right - num3, r.Top, r.Right, r.Top + num3), -90f, 90f);
		}
		graphicsPath.AddLine(r.Right, r.Top + num3, r.Right, r.Bottom - num4);
		if (num4 > 0)
		{
			graphicsPath.AddArc(Rectangle.FromLTRB(r.Right - num4, r.Bottom - num4, r.Right, r.Bottom), 0f, 90f);
		}
		graphicsPath.AddLine(r.Right - num4, r.Bottom, r.Left + num5, r.Bottom);
		if (num5 > 0)
		{
			graphicsPath.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - num5, r.Left + num5, r.Bottom), 90f, 90f);
		}
		graphicsPath.AddLine(r.Left, r.Bottom - num5, r.Left, r.Top + num2);
		if (num2 > 0)
		{
			graphicsPath.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + num2, r.Top + num2), 180f, 90f);
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath FlatRectangle(Rectangle r)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(r.Left, r.Top, r.Right, r.Top);
		graphicsPath.AddLine(r.Right, r.Top, r.Right, r.Bottom);
		graphicsPath.AddLine(r.Right, r.Bottom, r.Left, r.Bottom);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	private void GradientRect(Graphics g, Rectangle r, Color northColor, Color southColor)
	{
		using Brush brush = new LinearGradientBrush(new Point(r.X, r.Y - 1), new Point(r.Left, r.Bottom), northColor, southColor);
		g.FillRectangle(brush, r);
	}

	public void DrawPressedShadow(Graphics g, Rectangle r)
	{
		Rectangle rectangle = Rectangle.FromLTRB(r.Left, r.Top, r.Right, r.Top + 4);
		using GraphicsPath path = RoundRectangle(rectangle, 3, Corners.North);
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(50, Color.Black), Color.FromArgb(0, Color.Black), 90f);
		linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
		g.FillPath(linearGradientBrush, path);
	}

	public void DrawArrow(Graphics g, Rectangle b, Color c, RibbonArrowDirection d)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		Rectangle rectangle = b;
		if (b.Width % 2 != 0 && d == RibbonArrowDirection.Up)
		{
			rectangle = new Rectangle(new Point(b.Left - 1, b.Top - 1), new Size(b.Width + 1, b.Height + 1));
		}
		switch (d)
		{
		case RibbonArrowDirection.Up:
			graphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
			graphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Left + rectangle.Width / 2, rectangle.Top);
			break;
		case RibbonArrowDirection.Down:
			graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
			graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Left + rectangle.Width / 2, rectangle.Bottom);
			break;
		case RibbonArrowDirection.Left:
			graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top + rectangle.Height / 2);
			graphicsPath.AddLine(rectangle.Right, rectangle.Top + rectangle.Height / 2, rectangle.Left, rectangle.Bottom);
			break;
		default:
			graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Left, rectangle.Top + rectangle.Height / 2);
			graphicsPath.AddLine(rectangle.Left, rectangle.Top + rectangle.Height / 2, rectangle.Right, rectangle.Bottom);
			break;
		}
		graphicsPath.CloseFigure();
		using (SolidBrush brush = new SolidBrush(c))
		{
			SmoothingMode smoothingMode = g.SmoothingMode;
			g.SmoothingMode = SmoothingMode.None;
			g.FillPath(brush, graphicsPath);
			g.SmoothingMode = smoothingMode;
		}
		graphicsPath.Dispose();
	}

	public void DrawArrowShaded(Graphics g, Rectangle b, RibbonArrowDirection d, bool enabled)
	{
		Size size = arrowSize;
		if (d == RibbonArrowDirection.Left || d == RibbonArrowDirection.Right)
		{
			size = new Size(arrowSize.Height, arrowSize.Width);
		}
		Point location = new Point(b.Left + (b.Width - size.Width) / 2, b.Top + (b.Height - size.Height) / 2);
		Rectangle rectangle = new Rectangle(location, size);
		Rectangle b2 = rectangle;
		b2.Offset(0, 1);
		Color c = ColorTable.ArrowLight;
		Color c2 = ColorTable.Arrow;
		if (!enabled)
		{
			c = Color.Transparent;
			c2 = ColorTable.ArrowDisabled;
		}
		DrawArrow(g, b2, c, d);
		DrawArrow(g, rectangle, c2, d);
	}

	public Rectangle CenterOn(Rectangle container, Rectangle r)
	{
		return new Rectangle(container.Left + (container.Width - r.Width) / 2, container.Top + (container.Height - r.Height) / 2, r.Width, r.Height);
	}

	public void DrawGripDot(Graphics g, Point location)
	{
		Rectangle rect = new Rectangle(location.X - 1, location.Y + 1, 2, 2);
		Rectangle rect2 = new Rectangle(location, new Size(2, 2));
		using (SolidBrush brush = new SolidBrush(ColorTable.DropDownGripLight))
		{
			g.FillRectangle(brush, rect);
		}
		using SolidBrush brush2 = new SolidBrush(ColorTable.DropDownGripDark);
		g.FillRectangle(brush2, rect2);
	}

	public GraphicsPath CreateCompleteTabPath_2007(RibbonTab t)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = 6;
		if (t.Invisible)
		{
			graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabContentBounds.Right - num, t.TabBounds.Bottom);
		}
		else
		{
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Left - num, t.TabBounds.Bottom - num, t.TabBounds.Left, t.TabBounds.Bottom), 90f, -90f);
			graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom - num, t.TabBounds.Left, t.TabBounds.Top + num);
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Left, t.TabBounds.Top, t.TabBounds.Left + num, t.TabBounds.Top + num), 180f, 90f);
			graphicsPath.AddLine(t.TabBounds.Left + num, t.TabBounds.Top, t.TabBounds.Right - num, t.TabBounds.Top);
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Right - num, t.TabBounds.Top, t.TabBounds.Right, t.TabBounds.Top + num), -90f, 90f);
			graphicsPath.AddLine(t.TabBounds.Right, t.TabBounds.Top + num, t.TabBounds.Right, t.TabBounds.Bottom - num);
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Right, t.TabBounds.Bottom - num, t.TabBounds.Right + num, t.TabBounds.Bottom), -180f, -90f);
			graphicsPath.AddLine(t.TabBounds.Right + num, t.TabBounds.Bottom, t.TabContentBounds.Right - num, t.TabBounds.Bottom);
		}
		graphicsPath.AddArc(Rectangle.FromLTRB(t.TabContentBounds.Right - num, t.TabBounds.Bottom, t.TabContentBounds.Right, t.TabBounds.Bottom + num), -90f, 90f);
		graphicsPath.AddLine(t.TabContentBounds.Right, t.TabContentBounds.Top + num, t.TabContentBounds.Right, t.TabContentBounds.Bottom - num);
		graphicsPath.AddArc(Rectangle.FromLTRB(t.TabContentBounds.Right - num, t.TabContentBounds.Bottom - num, t.TabContentBounds.Right, t.TabContentBounds.Bottom), 0f, 90f);
		graphicsPath.AddLine(t.TabContentBounds.Right - num, t.TabContentBounds.Bottom, t.TabContentBounds.Left + num, t.TabContentBounds.Bottom);
		graphicsPath.AddArc(Rectangle.FromLTRB(t.TabContentBounds.Left, t.TabContentBounds.Bottom - num, t.TabContentBounds.Left + num, t.TabContentBounds.Bottom), 90f, 90f);
		graphicsPath.AddLine(t.TabContentBounds.Left, t.TabContentBounds.Bottom - num, t.TabContentBounds.Left, t.TabBounds.Bottom + num);
		graphicsPath.AddArc(Rectangle.FromLTRB(t.TabContentBounds.Left, t.TabBounds.Bottom, t.TabContentBounds.Left + num, t.TabBounds.Bottom + num), 180f, 90f);
		graphicsPath.AddLine(t.TabContentBounds.Left + num, t.TabContentBounds.Top, t.TabBounds.Left - num, t.TabBounds.Bottom);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public GraphicsPath CreateCompleteTopTabPath_2010(RibbonTab t)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = 6;
		graphicsPath.AddLine(t.TabContentBounds.Left, t.TabContentBounds.Top, t.TabBounds.Left - num, t.TabBounds.Bottom);
		if (t.Invisible)
		{
			graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabContentBounds.Right - num, t.TabBounds.Bottom);
		}
		else
		{
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Left - num, t.TabBounds.Bottom - num, t.TabBounds.Left, t.TabBounds.Bottom), 90f, -90f);
			graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom - num, t.TabBounds.Left, t.TabBounds.Top + num);
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Left, t.TabBounds.Top, t.TabBounds.Left + num, t.TabBounds.Top + num), 180f, 90f);
			graphicsPath.AddLine(t.TabBounds.Left + num, t.TabBounds.Top, t.TabBounds.Right - num, t.TabBounds.Top);
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Right - num, t.TabBounds.Top, t.TabBounds.Right, t.TabBounds.Top + num), -90f, 90f);
			graphicsPath.AddLine(t.TabBounds.Right, t.TabBounds.Top + num, t.TabBounds.Right, t.TabBounds.Bottom - num);
			graphicsPath.AddArc(Rectangle.FromLTRB(t.TabBounds.Right, t.TabBounds.Bottom - num, t.TabBounds.Right + num, t.TabBounds.Bottom), -180f, -90f);
			graphicsPath.AddLine(t.TabBounds.Right + num, t.TabBounds.Bottom, t.TabContentBounds.Right, t.TabBounds.Bottom);
		}
		return graphicsPath;
	}

	public GraphicsPath CreateCompleteTabPath_2013(RibbonTab t)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(t.TabContentBounds.Left, t.TabContentBounds.Top, t.TabBounds.Left, t.TabBounds.Bottom);
		if (t.Invisible)
		{
			graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabContentBounds.Right, t.TabBounds.Bottom);
		}
		else
		{
			graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabBounds.Left, t.TabBounds.Top);
			graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Top, t.TabBounds.Right, t.TabBounds.Top);
			graphicsPath.AddLine(t.TabBounds.Right, t.TabBounds.Top, t.TabBounds.Right, t.TabBounds.Bottom);
			graphicsPath.AddLine(t.TabBounds.Right, t.TabBounds.Bottom, t.TabContentBounds.Right, t.TabBounds.Bottom);
		}
		return graphicsPath;
	}

	public GraphicsPath CreateTabPath_2010(RibbonTab t)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = 6;
		int num2 = 1;
		graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabBounds.Left, t.TabBounds.Top + num);
		graphicsPath.AddArc(new Rectangle(t.TabBounds.Left, t.TabBounds.Top, num, num), 180f, 90f);
		graphicsPath.AddLine(t.TabBounds.Left + num, t.TabBounds.Top, t.TabBounds.Right - num - num2, t.TabBounds.Top);
		graphicsPath.AddArc(new Rectangle(t.TabBounds.Right - num - num2, t.TabBounds.Top, num, num), -90f, 90f);
		graphicsPath.AddLine(t.TabBounds.Right - num2, t.TabBounds.Top + num, t.TabBounds.Right - num2, t.TabBounds.Bottom);
		return graphicsPath;
	}

	public GraphicsPath CreateTabPath_2013(RibbonTab t)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = 1;
		graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabBounds.Left, t.TabBounds.Top);
		graphicsPath.AddLine(t.TabBounds.Left, t.TabBounds.Top, t.TabBounds.Right - num, t.TabBounds.Top);
		graphicsPath.AddLine(t.TabBounds.Right - num, t.TabBounds.Top, t.TabBounds.Right - num, t.TabBounds.Bottom);
		return graphicsPath;
	}

	public void DrawCompleteTab(RibbonTabRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			using (GraphicsPath path = RoundRectangle(e.Tab.TabContentBounds, 4))
			{
				Color color = ColorTable.TabContentNorth;
				Color color2 = ColorTable.TabContentSouth;
				if (e.Tab.Contextual)
				{
					color = ColorTable.DropDownBg;
					color2 = color;
				}
				int num = e.Tab.TabContentBounds.Height / 2;
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, e.Tab.TabContentBounds.Top + num), new Point(0, e.Tab.TabContentBounds.Bottom - 10), color, color2);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(linearGradientBrush, path);
				e.Graphics.SmoothingMode = smoothingMode;
			}
			if (!e.Tab.Invisible)
			{
				using GraphicsPath path2 = RoundRectangle(Rectangle.FromLTRB(e.Tab.TabContentBounds.Left, e.Tab.TabContentBounds.Top + 1, e.Tab.TabContentBounds.Right, e.Tab.TabContentBounds.Top + 18), 6, Corners.North);
				using Brush brush = new SolidBrush(Color.FromArgb(30, Color.White));
				SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(brush, path2);
				e.Graphics.SmoothingMode = smoothingMode2;
			}
			using GraphicsPath path3 = CreateCompleteTabPath_2007(e.Tab);
			using Pen pen = new Pen(ColorTable.TabBorder);
			SmoothingMode smoothingMode3 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.DrawPath(pen, path3);
			e.Graphics.SmoothingMode = smoothingMode3;
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (GraphicsPath path4 = FlatRectangle(e.Tab.TabContentBounds))
			{
				Color tabContentNorth = ColorTable.TabContentNorth;
				Color tabContentSouth = ColorTable.TabContentSouth;
				using LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, e.Tab.TabContentBounds.Top), new Point(0, e.Tab.TabContentBounds.Bottom), tabContentNorth, tabContentSouth);
				SmoothingMode smoothingMode4 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(brush2, path4);
				e.Graphics.SmoothingMode = smoothingMode4;
			}
			using (GraphicsPath path5 = CreateCompleteTopTabPath_2010(e.Tab))
			{
				using Pen pen2 = new Pen(ColorTable.TabBorder);
				SmoothingMode smoothingMode5 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.DrawPath(pen2, path5);
				e.Graphics.SmoothingMode = smoothingMode5;
			}
			using GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(e.Tab.TabContentBounds.Right, e.Tab.TabContentBounds.Bottom, e.Tab.TabContentBounds.Left, e.Tab.TabContentBounds.Bottom);
			using Pen pen3 = new Pen(ColorTable.TabBorder);
			SmoothingMode smoothingMode6 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.DrawPath(pen3, graphicsPath);
			e.Graphics.SmoothingMode = smoothingMode6;
		}
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using (GraphicsPath path6 = FlatRectangle(e.Tab.TabContentBounds))
		{
			using SolidBrush brush3 = new SolidBrush(ColorTable.TabCompleteBackground_2013);
			SmoothingMode smoothingMode7 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.FillPath(brush3, path6);
			e.Graphics.SmoothingMode = smoothingMode7;
		}
		using GraphicsPath path7 = CreateCompleteTabPath_2013(e.Tab);
		using Pen pen4 = new Pen(ColorTable.TabBorder_2013);
		SmoothingMode smoothingMode8 = e.Graphics.SmoothingMode;
		e.Graphics.SmoothingMode = SmoothingMode.None;
		e.Graphics.DrawPath(pen4, path7);
		e.Graphics.SmoothingMode = smoothingMode8;
	}

	public void DrawTabActiveSelected(RibbonTabRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			using (GraphicsPath path = CreateTabPath_2010(e.Tab))
			{
				Pen pen = new Pen(Color.FromArgb(150, Color.Gold))
				{
					Width = 2f
				};
				e.Graphics.DrawPath(pen, path);
				pen.Dispose();
			}
		}
	}

	public void DrawTabNormal(RibbonTabRenderEventArgs e)
	{
		if (e.Tab.Invisible)
		{
			return;
		}
		RectangleF clipBounds = e.Graphics.ClipBounds;
		Rectangle clip = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right, e.Tab.TabBounds.Bottom);
		Rectangle rectangle = Rectangle.FromLTRB(e.Tab.TabBounds.Left - 1, e.Tab.TabBounds.Top - 1, e.Tab.TabBounds.Right, e.Tab.TabBounds.Bottom);
		e.Graphics.SetClip(clip);
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			using (Brush brush = new SolidBrush(ColorTable.RibbonBackground))
			{
				e.Graphics.FillRectangle(brush, rectangle);
			}
			if (e.Tab.Contextual)
			{
				using GraphicsPath path = FlatRectangle(e.Tab.Bounds);
				Color color = Color.FromArgb(40, e.Tab.Context.GlowColor);
				Color color2 = Color.FromArgb(20, e.Tab.Context.GlowColor);
				Color color3 = Color.FromArgb(0, e.Tab.Context.GlowColor);
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, color, color3, 90f);
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3] { color, color2, color3 };
				colorBlend.Positions = new float[3] { 0f, 0.3f, 1f };
				ColorBlend interpolationColors = colorBlend;
				linearGradientBrush.InterpolationColors = interpolationColors;
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(linearGradientBrush, path);
				e.Graphics.SmoothingMode = smoothingMode;
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				WinApi.FillForGlass(e.Graphics, rectangle);
			}
			else
			{
				using Brush brush2 = new SolidBrush(ColorTable.RibbonBackground);
				e.Graphics.FillRectangle(brush2, rectangle);
			}
			if (e.Tab.Contextual)
			{
				using GraphicsPath path2 = FlatRectangle(e.Tab.Bounds);
				Color color4 = Color.FromArgb(40, e.Tab.Context.GlowColor);
				Color color5 = Color.FromArgb(20, e.Tab.Context.GlowColor);
				Color color6 = Color.FromArgb(0, e.Tab.Context.GlowColor);
				using LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rectangle, color4, color6, 90f);
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3] { color4, color5, color6 };
				colorBlend.Positions = new float[3] { 0f, 0.3f, 1f };
				ColorBlend interpolationColors2 = colorBlend;
				linearGradientBrush2.InterpolationColors = interpolationColors2;
				SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(linearGradientBrush2, path2);
				e.Graphics.SmoothingMode = smoothingMode2;
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				WinApi.FillForGlass(e.Graphics, rectangle);
			}
			else
			{
				using Brush brush3 = new SolidBrush(ColorTable.TabNormalBackground_2013);
				e.Graphics.FillRectangle(brush3, rectangle);
			}
			if (e.Tab.Contextual)
			{
				using GraphicsPath path3 = FlatRectangle(e.Tab.Bounds);
				Color color7 = Color.FromArgb(40, e.Tab.Context.GlowColor);
				Color color8 = Color.FromArgb(20, e.Tab.Context.GlowColor);
				Color color9 = Color.FromArgb(0, e.Tab.Context.GlowColor);
				using LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(rectangle, color7, color9, 90f);
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3] { color7, color8, color9 };
				colorBlend.Positions = new float[3] { 0f, 0.3f, 1f };
				ColorBlend interpolationColors3 = colorBlend;
				linearGradientBrush3.InterpolationColors = interpolationColors3;
				SmoothingMode smoothingMode3 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(linearGradientBrush3, path3);
				e.Graphics.SmoothingMode = smoothingMode3;
			}
		}
		e.Graphics.SetClip(clipBounds);
	}

	public void DrawTabSelected(RibbonTabRenderEventArgs e)
	{
		if (e.Tab.Invisible)
		{
			return;
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			Rectangle r = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right - 1, e.Tab.TabBounds.Bottom);
			Rectangle rectangle = Rectangle.FromLTRB(r.Left + 1, r.Top + 1, r.Right - 1, r.Bottom);
			Rectangle r2 = Rectangle.FromLTRB(rectangle.Left + 1, rectangle.Top + 1, rectangle.Right - 1, rectangle.Top + e.Tab.TabBounds.Height / 2);
			GraphicsPath graphicsPath = RoundRectangle(r, 3, Corners.North);
			GraphicsPath graphicsPath2 = RoundRectangle(rectangle, 3, Corners.North);
			GraphicsPath graphicsPath3 = RoundRectangle(r2, 3, Corners.North);
			using (Pen pen = new Pen(ColorTable.TabBorder))
			{
				e.Graphics.DrawPath(pen, graphicsPath);
			}
			using (Pen pen2 = new Pen(Color.FromArgb(200, Color.White)))
			{
				e.Graphics.DrawPath(pen2, graphicsPath2);
			}
			using (GraphicsPath graphicsPath4 = new GraphicsPath())
			{
				graphicsPath4.AddRectangle(rectangle);
				graphicsPath4.CloseFigure();
				PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath4);
				pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(rectangle.Left + rectangle.Width / 2), Convert.ToSingle(rectangle.Top - 5));
				pathGradientBrush.CenterColor = Color.Transparent;
				pathGradientBrush.SurroundColors = new Color[1] { ColorTable.TabSelectedGlow };
				PathGradientBrush pathGradientBrush2 = pathGradientBrush;
				Blend blend = new Blend(3);
				blend.Factors = new float[3] { 0f, 0.9f, 0f };
				blend.Positions = new float[3] { 0f, 0.8f, 1f };
				Blend blend2 = blend;
				pathGradientBrush2.Blend = blend2;
				e.Graphics.FillPath(pathGradientBrush2, graphicsPath4);
				pathGradientBrush2.Dispose();
			}
			using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, Color.White)))
			{
				e.Graphics.FillPath(brush, graphicsPath3);
			}
			graphicsPath.Dispose();
			graphicsPath2.Dispose();
			graphicsPath3.Dispose();
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Rectangle r3 = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right - 1, e.Tab.TabBounds.Bottom);
			Rectangle rectangle2 = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right - 1, r3.Bottom);
			Rectangle r4 = Rectangle.FromLTRB(rectangle2.Left + 1, rectangle2.Top + 1, rectangle2.Right - 1, rectangle2.Top + e.Tab.TabBounds.Height);
			RoundRectangle(r3, 3, Corners.North);
			GraphicsPath path = RoundRectangle(rectangle2, 3, Corners.North);
			RoundRectangle(r4, 3, Corners.North);
			if (e.Tab.Contextual)
			{
				using GraphicsPath path2 = RoundRectangle(r3, 6, Corners.North);
				Color color = Color.FromArgb(200, e.Tab.Context.GlowColor);
				Color color2 = Color.FromArgb(40, e.Tab.Context.GlowColor);
				Color color3 = Color.FromArgb(0, e.Tab.Context.GlowColor);
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Tab.TabBounds, color, color3, 90f);
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3] { color, color2, color3 };
				colorBlend.Positions = new float[3] { 0f, 0.3f, 1f };
				ColorBlend interpolationColors = colorBlend;
				linearGradientBrush.InterpolationColors = interpolationColors;
				e.Graphics.FillPath(linearGradientBrush, path2);
			}
			using (GraphicsPath path3 = CreateTabPath_2010(e.Tab))
			{
				using Pen pen3 = new Pen(ColorTable.TabSelectedBorder);
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.DrawPath(pen3, path3);
				e.Graphics.SmoothingMode = smoothingMode;
			}
			using (GraphicsPath graphicsPath5 = new GraphicsPath())
			{
				graphicsPath5.AddRectangle(rectangle2);
				graphicsPath5.CloseFigure();
				LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rectangle2, Color.FromArgb(50, Color.Gray), Color.FromArgb(80, Color.White), 90f);
				Blend blend = new Blend(3);
				blend.Factors = new float[3] { 0f, 0.6f, 1f };
				blend.Positions = new float[3] { 0f, 0.2f, 1f };
				Blend blend3 = blend;
				linearGradientBrush2.Blend = blend3;
				e.Graphics.FillPath(linearGradientBrush2, graphicsPath5);
				linearGradientBrush2.Dispose();
			}
			using Pen pen4 = new Pen(Color.FromArgb(200, Color.White));
			e.Graphics.DrawPath(pen4, path);
		}
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		Rectangle r5 = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right - 1, e.Tab.TabBounds.Bottom);
		Rectangle r6 = Rectangle.FromLTRB(r5.Left + 1, r5.Top + 1, r5.Right - 1, r5.Bottom);
		Rectangle r7 = Rectangle.FromLTRB(r6.Left + 1, r6.Top + 1, r6.Right - 1, r6.Top + e.Tab.TabBounds.Height);
		GraphicsPath path4 = FlatRectangle(r5);
		FlatRectangle(r6);
		FlatRectangle(r7);
		using (SolidBrush brush2 = new SolidBrush(ColorTable.ButtonSelected_2013))
		{
			e.Graphics.FillPath(brush2, path4);
		}
		using GraphicsPath path5 = CreateTabPath_2013(e.Tab);
		using Pen pen5 = new Pen(ColorTable.ButtonSelected_2013);
		SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		e.Graphics.DrawPath(pen5, path5);
		e.Graphics.SmoothingMode = smoothingMode2;
	}

	public void DrawTabPressed(RibbonTabRenderEventArgs e)
	{
	}

	public void DrawTabActive(RibbonTabRenderEventArgs e)
	{
		if (e.Tab.Invisible)
		{
			return;
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Rectangle r = new Rectangle(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Width, 4);
			Rectangle tabBounds = e.Tab.TabBounds;
			tabBounds.Offset(2, 1);
			Rectangle tabBounds2 = e.Tab.TabBounds;
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
			{
				using GraphicsPath path = RoundRectangle(tabBounds, 6, Corners.North);
				using PathGradientBrush pathGradientBrush = new PathGradientBrush(path);
				pathGradientBrush.WrapMode = WrapMode.Clamp;
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3]
				{
					Color.Transparent,
					Color.FromArgb(50, Color.Black),
					Color.FromArgb(100, Color.Black)
				};
				colorBlend.Positions = new float[3] { 0f, 0.1f, 1f };
				ColorBlend interpolationColors = colorBlend;
				pathGradientBrush.InterpolationColors = interpolationColors;
				e.Graphics.FillPath(pathGradientBrush, path);
			}
			using (GraphicsPath path2 = RoundRectangle(tabBounds2, 6, Corners.North))
			{
				Color tabNorth = ColorTable.TabNorth;
				Color tabSouth = ColorTable.TabSouth;
				if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
				{
					using Pen pen = new Pen(tabNorth, 1.6f);
					e.Graphics.DrawPath(pen, path2);
				}
				using LinearGradientBrush brush = new LinearGradientBrush(e.Tab.TabBounds, tabNorth, tabSouth, 90f);
				e.Graphics.FillPath(brush, path2);
			}
			if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007)
			{
				return;
			}
			using GraphicsPath path3 = RoundRectangle(r, 6, Corners.North);
			using Brush brush2 = new SolidBrush(Color.FromArgb(180, Color.White));
			e.Graphics.FillPath(brush2, path3);
			return;
		}
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using GraphicsPath path4 = FlatRectangle(new Rectangle(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Width, e.Tab.TabBounds.Height + 1));
		using SolidBrush brush3 = new SolidBrush(ColorTable.TabActiveBackbround_2013);
		e.Graphics.FillPath(brush3, path4);
	}

	public void DrawTabMinimized(RibbonTabRenderEventArgs e)
	{
		if (e.Tab.Invisible)
		{
			return;
		}
		if (e.Tab.Selected)
		{
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
			{
				Rectangle r = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right - 1, e.Tab.TabBounds.Bottom);
				Rectangle rectangle = Rectangle.FromLTRB(r.Left + 1, r.Top + 1, r.Right - 1, r.Bottom);
				Rectangle r2 = Rectangle.FromLTRB(rectangle.Left + 1, rectangle.Top + 1, rectangle.Right - 1, rectangle.Top + e.Tab.TabBounds.Height / 2);
				GraphicsPath graphicsPath = RoundRectangle(r, 3, Corners.North);
				GraphicsPath graphicsPath2 = RoundRectangle(rectangle, 3, Corners.North);
				GraphicsPath graphicsPath3 = RoundRectangle(r2, 3, Corners.North);
				using (Pen pen = new Pen(ColorTable.TabBorder))
				{
					e.Graphics.DrawPath(pen, graphicsPath);
				}
				using (Pen pen2 = new Pen(Color.FromArgb(200, Color.White)))
				{
					e.Graphics.DrawPath(pen2, graphicsPath2);
				}
				using (GraphicsPath graphicsPath4 = new GraphicsPath())
				{
					graphicsPath4.AddRectangle(rectangle);
					graphicsPath4.CloseFigure();
					PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath4);
					pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(rectangle.Left + rectangle.Width / 2), Convert.ToSingle(rectangle.Top - 5));
					pathGradientBrush.CenterColor = Color.Transparent;
					pathGradientBrush.SurroundColors = new Color[1] { ColorTable.TabSelectedGlow };
					PathGradientBrush pathGradientBrush2 = pathGradientBrush;
					Blend blend = new Blend(3);
					blend.Factors = new float[3] { 0f, 0.9f, 0f };
					blend.Positions = new float[3] { 0f, 0.8f, 1f };
					Blend blend2 = blend;
					pathGradientBrush2.Blend = blend2;
					e.Graphics.FillPath(pathGradientBrush2, graphicsPath4);
					pathGradientBrush2.Dispose();
				}
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, Color.White)))
				{
					e.Graphics.FillPath(brush, graphicsPath3);
				}
				graphicsPath.Dispose();
				graphicsPath2.Dispose();
				graphicsPath3.Dispose();
			}
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				Rectangle r3 = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right - 1, e.Tab.TabBounds.Bottom);
				Rectangle rectangle2 = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right - 1, r3.Bottom);
				Rectangle r4 = Rectangle.FromLTRB(rectangle2.Left + 1, rectangle2.Top + 1, rectangle2.Right - 1, rectangle2.Top + e.Tab.TabBounds.Height);
				RoundRectangle(r3, 3, Corners.North);
				GraphicsPath path = RoundRectangle(rectangle2, 3, Corners.North);
				RoundRectangle(r4, 3, Corners.North);
				using (GraphicsPath path2 = CreateTabPath_2010(e.Tab))
				{
					using Pen pen3 = new Pen(ColorTable.TabSelectedBorder);
					SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
					e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
					e.Graphics.DrawPath(pen3, path2);
					e.Graphics.SmoothingMode = smoothingMode;
				}
				using (GraphicsPath graphicsPath5 = new GraphicsPath())
				{
					graphicsPath5.AddRectangle(rectangle2);
					graphicsPath5.CloseFigure();
					LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle2, Color.FromArgb(50, Color.Gray), Color.FromArgb(80, Color.White), 90f);
					Blend blend = new Blend(3);
					blend.Factors = new float[3] { 0f, 0.6f, 1f };
					blend.Positions = new float[3] { 0f, 0.2f, 1f };
					Blend blend3 = blend;
					linearGradientBrush.Blend = blend3;
					e.Graphics.FillPath(linearGradientBrush, graphicsPath5);
					linearGradientBrush.Dispose();
				}
				using Pen pen4 = new Pen(Color.FromArgb(200, Color.White));
				e.Graphics.DrawPath(pen4, path);
			}
			if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
			{
				return;
			}
			Rectangle r5 = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right - 1, e.Tab.TabBounds.Bottom);
			Rectangle r6 = Rectangle.FromLTRB(r5.Left + 1, r5.Top + 1, r5.Right - 1, r5.Bottom);
			Rectangle r7 = Rectangle.FromLTRB(r6.Left + 1, r6.Top + 1, r6.Right - 1, r6.Top + e.Tab.TabBounds.Height);
			GraphicsPath path3 = FlatRectangle(r5);
			FlatRectangle(r6);
			FlatRectangle(r7);
			using (SolidBrush brush2 = new SolidBrush(ColorTable.ButtonSelected_2013))
			{
				e.Graphics.FillPath(brush2, path3);
			}
			using GraphicsPath path4 = CreateTabPath_2013(e.Tab);
			using Pen pen5 = new Pen(ColorTable.ButtonSelected_2013);
			SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.DrawPath(pen5, path4);
			e.Graphics.SmoothingMode = smoothingMode2;
			return;
		}
		RectangleF clipBounds = e.Graphics.ClipBounds;
		Rectangle clip = Rectangle.FromLTRB(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Right, e.Tab.TabBounds.Bottom);
		Rectangle rectangle3 = Rectangle.FromLTRB(e.Tab.TabBounds.Left - 1, e.Tab.TabBounds.Top - 1, e.Tab.TabBounds.Right, e.Tab.TabBounds.Bottom);
		e.Graphics.SetClip(clip);
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			using Brush brush3 = new SolidBrush(ColorTable.RibbonBackground);
			e.Graphics.FillRectangle(brush3, rectangle3);
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				WinApi.FillForGlass(e.Graphics, rectangle3);
			}
			else
			{
				using Brush brush4 = new SolidBrush(ColorTable.RibbonBackground);
				e.Graphics.FillRectangle(brush4, rectangle3);
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				WinApi.FillForGlass(e.Graphics, rectangle3);
			}
			else
			{
				using Brush brush5 = new SolidBrush(ColorTable.RibbonBackground_2013);
				e.Graphics.FillRectangle(brush5, rectangle3);
			}
		}
		e.Graphics.SetClip(clipBounds);
	}

	public void DrawPanelNormal(RibbonPanelRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			Rectangle r = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
			Rectangle r2 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.Bounds.Top + 1, e.Panel.Bounds.Right + 1, e.Panel.Bounds.Bottom);
			Rectangle r3 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
			GraphicsPath graphicsPath = RoundRectangle(r, 3);
			GraphicsPath graphicsPath2 = RoundRectangle(r2, 3);
			GraphicsPath graphicsPath3 = RoundRectangle(r3, 3, Corners.South);
			using (Pen pen = new Pen(ColorTable.PanelLightBorder))
			{
				e.Graphics.DrawPath(pen, graphicsPath2);
			}
			using (Pen pen2 = new Pen(ColorTable.PanelDarkBorder))
			{
				e.Graphics.DrawPath(pen2, graphicsPath);
			}
			using (SolidBrush brush = new SolidBrush(ColorTable.PanelTextBackground))
			{
				e.Graphics.FillPath(brush, graphicsPath3);
			}
			graphicsPath3.Dispose();
			graphicsPath.Dispose();
			graphicsPath2.Dispose();
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Rectangle rect = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 2, e.Panel.Bounds.Bottom);
			Rectangle rectangle = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom);
			Rectangle rectangle2 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
			using (LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(30, ColorTable.PanelLightBorder), ColorTable.PanelLightBorder, 90f))
			{
				using Pen pen3 = new Pen(brush2);
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.DrawLine(pen3, rect.Left, rect.Top, rect.Left, rect.Bottom);
				e.Graphics.DrawLine(pen3, rect.Right, rect.Top, rect.Right, rect.Bottom);
				e.Graphics.DrawLine(pen3, rectangle2.Right, rectangle2.Top, rectangle2.Right, rectangle2.Bottom);
				e.Graphics.SmoothingMode = smoothingMode;
			}
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(30, ColorTable.PanelDarkBorder), ColorTable.PanelDarkBorder, LinearGradientMode.Vertical))
			{
				linearGradientBrush.WrapMode = WrapMode.TileFlipX;
				using Pen pen4 = new Pen(linearGradientBrush);
				SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.DrawLine(pen4, rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
				e.Graphics.SmoothingMode = smoothingMode2;
			}
			using (Pen pen5 = new Pen(ColorTable.TabContentSouth))
			{
				SmoothingMode smoothingMode3 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.DrawLine(pen5, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
				e.Graphics.SmoothingMode = smoothingMode3;
			}
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				using GraphicsPath path = RoundRectangle(Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1), 3, Corners.South);
				using SolidBrush brush3 = new SolidBrush(Color.FromArgb(200, LightenColor(ColorTable.PanelTextBackground, 0.2f)));
				e.Graphics.FillPath(brush3, path);
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			using Pen pen6 = new Pen(ColorTable.PanelBorder_2013);
			e.Graphics.DrawLine(pen6, new Point(e.Panel.Bounds.Right, e.Panel.Bounds.Top), new Point(e.Panel.Bounds.Right, e.Panel.Bounds.Bottom));
		}
		if (e.Panel.ButtonMoreVisible)
		{
			DrawButtonMoreGlyph(e.Graphics, e.Panel.ButtonMoreBounds, e.Panel.ButtonMoreEnabled && e.Panel.Enabled);
		}
	}

	public void DrawPanelSelected(RibbonPanelRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			Rectangle r = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
			Rectangle r2 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.Bounds.Top + 1, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
			Rectangle r3 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
			GraphicsPath graphicsPath = RoundRectangle(r, 3);
			GraphicsPath graphicsPath2 = RoundRectangle(r2, 3);
			GraphicsPath graphicsPath3 = RoundRectangle(r3, 3, Corners.South);
			using (Pen pen = new Pen(ColorTable.PanelLightBorder))
			{
				e.Graphics.DrawPath(pen, graphicsPath2);
			}
			using (Pen pen2 = new Pen(ColorTable.PanelDarkBorder))
			{
				e.Graphics.DrawPath(pen2, graphicsPath);
			}
			using (SolidBrush brush = new SolidBrush(ColorTable.PanelBackgroundSelected))
			{
				e.Graphics.FillPath(brush, graphicsPath2);
			}
			using (SolidBrush brush2 = new SolidBrush(ColorTable.PanelTextBackgroundSelected))
			{
				e.Graphics.FillPath(brush2, graphicsPath3);
			}
			if (e.Panel.ButtonMoreVisible)
			{
				if (e.Panel.ButtonMorePressed)
				{
					DrawButtonPressed(e.Graphics, e.Panel.ButtonMoreBounds, Corners.SouthEast, e.Ribbon);
				}
				else if (e.Panel.ButtonMoreSelected)
				{
					DrawButtonSelected(e.Graphics, e.Panel.ButtonMoreBounds, Corners.SouthEast, e.Ribbon);
				}
				DrawButtonMoreGlyph(e.Graphics, e.Panel.ButtonMoreBounds, e.Panel.ButtonMoreEnabled && e.Panel.Enabled);
			}
			graphicsPath3.Dispose();
			graphicsPath.Dispose();
			graphicsPath2.Dispose();
		}
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended)
		{
			return;
		}
		Rectangle rectangle = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 2, e.Panel.Bounds.Bottom);
		Rectangle rectangle2 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom);
		Rectangle rectangle3 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
		Rectangle rect = new Rectangle(e.Panel.Bounds.Left + (int)(0.1 * (double)e.Panel.Bounds.Width), e.Panel.Bounds.Top, e.Panel.Bounds.Width - (int)(0.2 * (double)e.Panel.Bounds.Width), 2 * e.Panel.Bounds.Height - 1);
		using (GraphicsPath graphicsPath4 = new GraphicsPath())
		{
			graphicsPath4.AddArc(rect, 180f, 180f);
			graphicsPath4.CloseFigure();
			PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath4);
			pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(rectangle.Left + rectangle.Width / 2), Convert.ToSingle(rectangle.Bottom));
			pathGradientBrush.CenterColor = ColorTable.PanelBackgroundSelected;
			pathGradientBrush.SurroundColors = new Color[1] { Color.Transparent };
			PathGradientBrush pathGradientBrush2 = pathGradientBrush;
			pathGradientBrush2.SetSigmaBellShape(1f, 1f);
			SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.FillPath(pathGradientBrush2, graphicsPath4);
			e.Graphics.SmoothingMode = smoothingMode;
			pathGradientBrush2.Dispose();
		}
		using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(90, Color.White), Color.FromArgb(220, Color.White), LinearGradientMode.Vertical))
		{
			Blend blend = new Blend();
			blend.Factors = new float[3] { 0f, 1f, 1f };
			blend.Positions = new float[3] { 0f, 0.5f, 1f };
			Blend blend2 = blend;
			linearGradientBrush.Blend = blend2;
			linearGradientBrush.WrapMode = WrapMode.TileFlipX;
			using Pen pen3 = new Pen(linearGradientBrush);
			SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.DrawLine(pen3, rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
			e.Graphics.SmoothingMode = smoothingMode2;
		}
		using (LinearGradientBrush brush3 = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(30, ColorTable.PanelLightBorder), ColorTable.PanelLightBorder, LinearGradientMode.Vertical))
		{
			using Pen pen4 = new Pen(brush3);
			SmoothingMode smoothingMode3 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.DrawLine(pen4, rectangle3.Right, rectangle3.Top, rectangle3.Right, rectangle3.Bottom);
			e.Graphics.SmoothingMode = smoothingMode3;
		}
		using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(30, ColorTable.PanelDarkBorder), ColorTable.PanelDarkBorder, LinearGradientMode.Vertical))
		{
			linearGradientBrush2.WrapMode = WrapMode.TileFlipX;
			using Pen pen5 = new Pen(linearGradientBrush2);
			SmoothingMode smoothingMode4 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.DrawLine(pen5, rectangle2.Right, rectangle2.Top, rectangle2.Right, rectangle2.Bottom);
			e.Graphics.SmoothingMode = smoothingMode4;
		}
		using (Pen pen6 = new Pen(Color.FromArgb(220, Color.White)))
		{
			SmoothingMode smoothingMode5 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.DrawLine(pen6, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
			e.Graphics.SmoothingMode = smoothingMode5;
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using GraphicsPath path = RoundRectangle(Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1), 3, Corners.South);
			using SolidBrush brush4 = new SolidBrush(ColorTable.PanelTextBackground);
			e.Graphics.FillPath(brush4, path);
		}
		if (e.Panel.ButtonMoreVisible)
		{
			if (e.Panel.ButtonMorePressed)
			{
				DrawButtonPressed(e.Graphics, e.Panel.ButtonMoreBounds, Corners.SouthEast, e.Ribbon);
			}
			else if (e.Panel.ButtonMoreSelected)
			{
				DrawButtonSelected(e.Graphics, e.Panel.ButtonMoreBounds, Corners.SouthEast, e.Ribbon);
			}
			DrawButtonMoreGlyph(e.Graphics, e.Panel.ButtonMoreBounds, e.Panel.ButtonMoreEnabled && e.Panel.Enabled);
		}
	}

	public void DrawButtonMoreGlyph(Graphics g, Rectangle b, bool enabled)
	{
		if (_ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			Color color = (enabled ? ColorTable.Arrow : ColorTable.ArrowDisabled);
			Color arrowLight = ColorTable.ArrowLight;
			Rectangle rectangle = CenterOn(b, new Rectangle(Point.Empty, _ownerRibbon.PanelMoreSize));
			Rectangle rectangle2 = rectangle;
			rectangle2.Offset(1, 1);
			DrawButtonMoreGlyph(g, rectangle2.Location, arrowLight);
			DrawButtonMoreGlyph(g, rectangle.Location, color);
		}
		if (_ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2010 || _ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Color color2 = (enabled ? Color.FromArgb(180, ColorTable.Arrow) : ColorTable.ArrowDisabled);
			DrawButtonMoreGlyph(g, CenterOn(b, new Rectangle(Point.Empty, _ownerRibbon.PanelMoreSize)).Location, color2);
		}
		if (_ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			Color color3 = (enabled ? ColorTable.Arrow : ColorTable.ArrowDisabled);
			Color arrowLight2 = ColorTable.ArrowLight;
			Rectangle rectangle3 = CenterOn(b, new Rectangle(Point.Empty, _ownerRibbon.PanelMoreSize));
			Rectangle rectangle4 = rectangle3;
			rectangle4.Offset(1, 1);
			DrawButtonMoreGlyph(g, rectangle4.Location, arrowLight2);
			DrawButtonMoreGlyph(g, rectangle3.Location, color3);
		}
	}

	public void DrawButtonMoreGlyph(Graphics gr, Point p, Color color)
	{
		Point point = p;
		Point pt = new Point(p.X + _ownerRibbon.PanelMoreSize.Width - 1, p.Y);
		Point pt2 = new Point(p.X, p.Y + _ownerRibbon.PanelMoreSize.Height - 1);
		Point point2 = new Point(p.X + _ownerRibbon.PanelMoreSize.Width, p.Y + _ownerRibbon.PanelMoreSize.Height);
		Point point3 = new Point(point2.X, point2.Y - 3);
		Point point4 = new Point(point2.X - 3, point2.Y);
		Point pt3 = new Point(point2.X - 3, point2.Y - 3);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(pt2, point);
		graphicsPath.AddLine(point, pt);
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddLine(pt3, point2);
		graphicsPath2.AddLine(point2, point3);
		graphicsPath2.AddLine(point3, point4);
		graphicsPath2.AddLine(point4, point2);
		SmoothingMode smoothingMode = gr.SmoothingMode;
		gr.SmoothingMode = SmoothingMode.None;
		using (Pen pen = new Pen(color))
		{
			gr.DrawPath(pen, graphicsPath);
			gr.DrawPath(pen, graphicsPath2);
		}
		gr.SmoothingMode = smoothingMode;
	}

	public void DrawPanelOverflowNormal(RibbonPanelRenderEventArgs e)
	{
		Rectangle r = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
		Rectangle r2 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.Bounds.Top + 1, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
		GraphicsPath graphicsPath = RoundRectangle(r, 3);
		GraphicsPath graphicsPath2 = RoundRectangle(r2, 3);
		using (Pen pen = new Pen(ColorTable.PanelLightBorder))
		{
			e.Graphics.DrawPath(pen, graphicsPath2);
		}
		using (Pen pen2 = new Pen(ColorTable.PanelDarkBorder))
		{
			e.Graphics.DrawPath(pen2, graphicsPath);
		}
		DrawPanelOverflowImage(e);
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
	}

	[Obsolete("use DrawPanelOverflowSelected")]
	public void DrawPannelOveflowSelected(RibbonPanelRenderEventArgs e)
	{
		DrawPanelOverflowSelected(e);
	}

	public void DrawPanelOverflowSelected(RibbonPanelRenderEventArgs e)
	{
		Rectangle r = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
		Rectangle rectangle = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.Bounds.Top + 1, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
		GraphicsPath graphicsPath = RoundRectangle(r, 3);
		GraphicsPath graphicsPath2 = RoundRectangle(rectangle, 3);
		using (Pen pen = new Pen(ColorTable.PanelLightBorder))
		{
			e.Graphics.DrawPath(pen, graphicsPath2);
		}
		using (Pen pen2 = new Pen(ColorTable.PanelDarkBorder))
		{
			e.Graphics.DrawPath(pen2, graphicsPath);
		}
		using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, ColorTable.PanelOverflowBackgroundSelectedNorth, Color.Transparent, 90f))
		{
			e.Graphics.FillPath(brush, graphicsPath2);
		}
		DrawPanelOverflowImage(e);
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
	}

	public void DrawPanelOverflowPressed(RibbonPanelRenderEventArgs e)
	{
		Rectangle r = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
		Rectangle rectangle = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.Bounds.Top + 1, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
		Rectangle rectangle2 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Top + 17);
		GraphicsPath graphicsPath = RoundRectangle(r, 3);
		GraphicsPath graphicsPath2 = RoundRectangle(rectangle, 3);
		using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, ColorTable.PanelOverflowBackgroundPressed, ColorTable.PanelOverflowBackgroundSelectedSouth, 90f))
		{
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			e.Graphics.FillPath(linearGradientBrush, graphicsPath);
		}
		using (GraphicsPath path = RoundRectangle(rectangle2, 3, Corners.North))
		{
			using LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rectangle2, Color.FromArgb(150, Color.White), Color.FromArgb(50, Color.White), 90f);
			linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
			e.Graphics.FillPath(linearGradientBrush2, path);
		}
		using (Pen pen = new Pen(Color.FromArgb(40, Color.White)))
		{
			e.Graphics.DrawPath(pen, graphicsPath2);
		}
		using (Pen pen2 = new Pen(ColorTable.PanelDarkBorder))
		{
			e.Graphics.DrawPath(pen2, graphicsPath);
		}
		DrawPanelOverflowImage(e);
		DrawPressedShadow(e.Graphics, rectangle2);
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
	}

	public void DrawPanelOverflowImage(RibbonPanelRenderEventArgs e)
	{
		int num = 3;
		Size size = new Size(32, 32);
		Rectangle rectangle = new Rectangle(new Point(e.Panel.Bounds.Left + (e.Panel.Bounds.Width - size.Width) / 2, e.Panel.Bounds.Top + 5), size);
		Rectangle r = Rectangle.FromLTRB(rectangle.Left, rectangle.Bottom - 10, rectangle.Right, rectangle.Bottom);
		Rectangle rectangle2 = Rectangle.FromLTRB(e.Panel.Bounds.Left + num, rectangle.Bottom + num, e.Panel.Bounds.Right - num, e.Panel.Bounds.Bottom - num);
		using GraphicsPath path = RoundRectangle(rectangle, 5);
		using GraphicsPath path2 = RoundRectangle(r, 5, Corners.South);
		using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, ColorTable.TabContentNorth, ColorTable.TabContentSouth, 90f))
		{
			e.Graphics.FillPath(brush, path);
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			using SolidBrush brush2 = new SolidBrush(ColorTable.PanelTextBackground);
			e.Graphics.FillPath(brush2, path2);
		}
		using (Pen pen = new Pen(ColorTable.PanelDarkBorder))
		{
			e.Graphics.DrawPath(pen, path);
		}
		if (e.Panel.Image != null)
		{
			e.Graphics.DrawImage(e.Panel.Image, rectangle.Left + (rectangle.Width - e.Panel.Image.Width) / 2, rectangle.Top + (rectangle.Height - r.Height - e.Panel.Image.Height) / 2, e.Panel.Image.Width, e.Panel.Image.Height);
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using StringFormat format = StringFormatFactory.CenterNearTrimChar();
			using SolidBrush brush3 = new SolidBrush(GetTextColor(e.Panel.Enabled, ColorTable.Text));
			e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, brush3, rectangle2, format);
		}
		else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			using StringFormat format2 = StringFormatFactory.CenterNearTrimChar();
			using SolidBrush brush4 = new SolidBrush(GetTextColor(e.Panel.Enabled, ColorTable.RibbonItemText_2013));
			e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, brush4, rectangle2, format2);
		}
		if (e.Panel.Text != null)
		{
			Rectangle rectangle3 = LargeButtonDropDownArrowBounds(e.Graphics, e.Panel.Owner.Font, e.Panel.Text, rectangle2);
			if (rectangle3.Right < e.Panel.Bounds.Right)
			{
				Rectangle b = rectangle3;
				b.Offset(0, 1);
				Color arrowLight = ColorTable.ArrowLight;
				Color arrow = ColorTable.Arrow;
				DrawArrow(e.Graphics, b, arrowLight, RibbonArrowDirection.Down);
				DrawArrow(e.Graphics, rectangle3, arrow, RibbonArrowDirection.Down);
			}
		}
	}

	private Corners ButtonCorners(RibbonButton button)
	{
		if (!(button.OwnerItem is RibbonItemGroup))
		{
			return Corners.All;
		}
		RibbonItemGroup ribbonItemGroup = button.OwnerItem as RibbonItemGroup;
		Corners corners = Corners.None;
		if (button == ribbonItemGroup.FirstItem)
		{
			corners |= Corners.West;
		}
		if (button == ribbonItemGroup.LastItem)
		{
			corners |= Corners.East;
		}
		return corners;
	}

	private Corners ButtonFaceRounding(RibbonButton button)
	{
		if (!(button.OwnerItem is RibbonItemGroup))
		{
			if (button.SizeMode == RibbonElementSizeMode.Large)
			{
				return Corners.North;
			}
			return Corners.West;
		}
		Corners corners = Corners.None;
		RibbonItemGroup ribbonItemGroup = button.OwnerItem as RibbonItemGroup;
		if (button == ribbonItemGroup.FirstItem)
		{
			corners |= Corners.West;
		}
		return corners;
	}

	private Corners ButtonDdRounding(RibbonButton button)
	{
		if (!(button.OwnerItem is RibbonItemGroup))
		{
			if (button.SizeMode == RibbonElementSizeMode.Large)
			{
				return Corners.South;
			}
			return Corners.East;
		}
		Corners corners = Corners.None;
		RibbonItemGroup ribbonItemGroup = button.OwnerItem as RibbonItemGroup;
		if (button == ribbonItemGroup.LastItem)
		{
			corners |= Corners.East;
		}
		return corners;
	}

	public void DrawOrbOptionButton(Graphics g, Rectangle bounds)
	{
		bounds.Width--;
		bounds.Height--;
		using GraphicsPath path = RoundRectangle(bounds, 3);
		using (SolidBrush brush = new SolidBrush(ColorTable.OrbOptionBackground))
		{
			g.FillPath(brush, path);
		}
		GradientRect(g, Rectangle.FromLTRB(bounds.Left, bounds.Top + bounds.Height / 2, bounds.Right, bounds.Bottom - 2), ColorTable.OrbOptionShine, ColorTable.OrbOptionBackground);
		using Pen pen = new Pen(ColorTable.OrbOptionBorder);
		g.DrawPath(pen, path);
	}

	public void DrawButton(Graphics g, Rectangle bounds, Corners corners)
	{
		if (bounds.Height <= 0 || bounds.Width <= 0)
		{
			return;
		}
		Rectangle r = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
		Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
		Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double)bounds.Height * 0.36));
		using GraphicsPath path = RoundRectangle(r, 3, corners);
		using (SolidBrush brush = new SolidBrush(ColorTable.ButtonBgOut))
		{
			g.FillPath(brush, path);
		}
		using (GraphicsPath graphicsPath = new GraphicsPath())
		{
			graphicsPath.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
			graphicsPath.CloseFigure();
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.WrapMode = WrapMode.Clamp;
			pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
			pathGradientBrush.CenterColor = ColorTable.ButtonBgCenter;
			pathGradientBrush.SurroundColors = new Color[1] { ColorTable.ButtonBgOut };
			Blend blend = new Blend(3);
			blend.Factors = new float[3] { 0f, 0.8f, 0f };
			blend.Positions = new float[3] { 0f, 0.3f, 1f };
			Region clip = g.Clip;
			Region region = new Region(path);
			region.Intersect(clip);
			g.SetClip(region.GetBounds(g));
			g.FillPath(pathGradientBrush, graphicsPath);
			g.Clip = clip;
		}
		using (Pen pen = new Pen(ColorTable.ButtonBorderOut))
		{
			g.DrawPath(pen, path);
		}
		using (GraphicsPath path2 = RoundRectangle(r2, 3, corners))
		{
			using Pen pen2 = new Pen(ColorTable.ButtonBorderIn);
			g.DrawPath(pen2, path2);
		}
		using GraphicsPath path3 = RoundRectangle(rectangle, 3, (corners & Corners.NorthWest) | (corners & Corners.NorthEast));
		if (rectangle.Width > 0 && rectangle.Height > 0)
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, ColorTable.ButtonGlossyNorth, ColorTable.ButtonGlossySouth, 90f))
			{
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				g.FillPath(linearGradientBrush, path3);
				return;
			}
		}
	}

	public Rectangle LargeButtonDropDownArrowBounds(Graphics g, Font font, string text, Rectangle textLayout)
	{
		_ = Rectangle.Empty;
		bool flag = text.Contains(" ");
		StringFormat stringFormat = new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = (flag ? StringAlignment.Center : StringAlignment.Near),
			Trimming = StringTrimming.EllipsisCharacter
		};
		stringFormat.SetMeasurableCharacterRanges(new CharacterRange[1]
		{
			new CharacterRange(0, text.Length)
		});
		Region[] array = g.MeasureCharacterRanges(text, font, textLayout, stringFormat);
		Rectangle rectangle = Rectangle.Round(array[array.Length - 1].GetBounds(g));
		if (flag)
		{
			return new Rectangle(rectangle.Right + 3, rectangle.Top + (rectangle.Height - arrowSize.Height) / 2, arrowSize.Width, arrowSize.Height);
		}
		return new Rectangle(textLayout.Left + (textLayout.Width - arrowSize.Width) / 2, rectangle.Bottom + (textLayout.Bottom - rectangle.Bottom - arrowSize.Height) / 2, arrowSize.Width, arrowSize.Height);
	}

	public void DrawButtonDropDownArrow(Graphics g, RibbonButton button, Rectangle textLayout)
	{
		Rectangle empty = Rectangle.Empty;
		empty = ((button.SizeMode != RibbonElementSizeMode.Large && button.SizeMode != RibbonElementSizeMode.Overflow) ? textLayout : LargeButtonDropDownArrowBounds(g, button.Owner.Font, button.Text, textLayout));
		DrawArrowShaded(g, empty, button.DropDownArrowDirection, button.Enabled);
	}

	public void DrawButtonDisabled(Graphics g, Rectangle bounds, Corners corners)
	{
		if (bounds.Height <= 0 || bounds.Width <= 0)
		{
			return;
		}
		Rectangle r = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
		Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
		Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double)bounds.Height * 0.36));
		using GraphicsPath path = RoundRectangle(r, 3, corners);
		using (SolidBrush brush = new SolidBrush(ColorTable.ButtonDisabledBgOut))
		{
			g.FillPath(brush, path);
		}
		using (GraphicsPath graphicsPath = new GraphicsPath())
		{
			graphicsPath.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
			graphicsPath.CloseFigure();
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.WrapMode = WrapMode.Clamp;
			pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
			pathGradientBrush.CenterColor = ColorTable.ButtonDisabledBgCenter;
			pathGradientBrush.SurroundColors = new Color[1] { ColorTable.ButtonDisabledBgOut };
			Blend blend = new Blend(3);
			blend.Factors = new float[3] { 0f, 0.8f, 0f };
			blend.Positions = new float[3] { 0f, 0.3f, 1f };
			Region clip = g.Clip;
			Region region = new Region(path);
			region.Intersect(clip);
			g.SetClip(region.GetBounds(g));
			g.FillPath(pathGradientBrush, graphicsPath);
			g.Clip = clip;
		}
		using (Pen pen = new Pen(ColorTable.ButtonDisabledBorderOut))
		{
			g.DrawPath(pen, path);
		}
		using (GraphicsPath path2 = RoundRectangle(r2, 3, corners))
		{
			using Pen pen2 = new Pen(ColorTable.ButtonDisabledBorderIn);
			g.DrawPath(pen2, path2);
		}
		using GraphicsPath path3 = RoundRectangle(rectangle, 3, (corners & Corners.NorthWest) | (corners & Corners.NorthEast));
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, ColorTable.ButtonDisabledGlossyNorth, ColorTable.ButtonDisabledGlossySouth, 90f);
		linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
		g.FillPath(linearGradientBrush, path3);
	}

	public void DrawButtonPressed(Graphics g, Rectangle bounds, Corners corners, Ribbon ribbon)
	{
		if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Rectangle r = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
			using GraphicsPath path = RoundRectangle(r, 3, corners);
			Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
			Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double)bounds.Height * 0.36));
			using (SolidBrush brush = new SolidBrush(ColorTable.ButtonPressedBgOut))
			{
				g.FillPath(brush, path);
			}
			using (Pen pen = new Pen(ColorTable.ButtonPressedBorderOut))
			{
				g.DrawPath(pen, path);
			}
			using (GraphicsPath path2 = RoundRectangle(r2, 3, corners))
			{
				using Pen pen2 = new Pen(ColorTable.ButtonPressedBorderIn);
				g.DrawPath(pen2, path2);
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
				graphicsPath.CloseFigure();
				using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
				pathGradientBrush.WrapMode = WrapMode.Clamp;
				pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
				pathGradientBrush.CenterColor = ColorTable.ButtonPressedBgCenter;
				pathGradientBrush.SurroundColors = new Color[1] { ColorTable.ButtonPressedBgOut };
				Blend blend = new Blend(3);
				blend.Factors = new float[3] { 0f, 0.8f, 0f };
				blend.Positions = new float[3] { 0f, 0.3f, 1f };
				Region clip = g.Clip;
				Region region = new Region(path);
				region.Intersect(clip);
				g.SetClip(region.GetBounds(g));
				g.FillPath(pathGradientBrush, graphicsPath);
				g.Clip = clip;
			}
			using (GraphicsPath path3 = RoundRectangle(rectangle, 3, (corners & Corners.NorthWest) | (corners & Corners.NorthEast)))
			{
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, ColorTable.ButtonPressedGlossyNorth, ColorTable.ButtonPressedGlossySouth, 90f);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				g.FillPath(linearGradientBrush, path3);
			}
			DrawPressedShadow(g, r);
			return;
		}
		if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using GraphicsPath path4 = FlatRectangle(bounds);
		using SolidBrush brush2 = new SolidBrush(ColorTable.ButtonPressed_2013);
		g.FillPath(brush2, path4);
	}

	public void DrawButtonSelected(Graphics g, Rectangle bounds, Corners corners, Ribbon ribbon)
	{
		if (bounds.Height <= 0 || bounds.Width <= 0)
		{
			return;
		}
		if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (GraphicsPath path = RoundRectangle(Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1), 3, corners))
			{
				Rectangle r = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
				Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double)bounds.Height * 0.36));
				using (SolidBrush brush = new SolidBrush(ColorTable.ButtonSelectedBgOut))
				{
					g.FillPath(brush, path);
				}
				using (Pen pen = new Pen(ColorTable.ButtonSelectedBorderOut))
				{
					g.DrawPath(pen, path);
				}
				using (GraphicsPath path2 = RoundRectangle(r, 3, corners))
				{
					using Pen pen2 = new Pen(ColorTable.ButtonSelectedBorderIn);
					g.DrawPath(pen2, path2);
				}
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					graphicsPath.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
					graphicsPath.CloseFigure();
					using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
					pathGradientBrush.WrapMode = WrapMode.Clamp;
					pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
					pathGradientBrush.CenterColor = ColorTable.ButtonSelectedBgCenter;
					pathGradientBrush.SurroundColors = new Color[1] { ColorTable.ButtonSelectedBgOut };
					Blend blend = new Blend(3);
					blend.Factors = new float[3] { 0f, 0.8f, 0f };
					blend.Positions = new float[3] { 0f, 0.3f, 1f };
					Region clip = g.Clip;
					Region region = new Region(path);
					region.Intersect(clip);
					g.SetClip(region.GetBounds(g));
					g.FillPath(pathGradientBrush, graphicsPath);
					g.Clip = clip;
				}
				using GraphicsPath path3 = RoundRectangle(rectangle, 3, (corners & Corners.NorthWest) | (corners & Corners.NorthEast));
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, ColorTable.ButtonSelectedGlossyNorth, ColorTable.ButtonSelectedGlossySouth, 90f);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				g.FillPath(linearGradientBrush, path3);
				return;
			}
		}
		if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using GraphicsPath path4 = FlatRectangle(bounds);
		using SolidBrush brush2 = new SolidBrush(ColorTable.ButtonSelected_2013);
		g.FillPath(brush2, path4);
	}

	public void DrawButtonPressed(Graphics g, RibbonButton button, Ribbon ribbon)
	{
		DrawButtonPressed(g, button.Bounds, ButtonCorners(button), ribbon);
	}

	public void DrawButtonChecked(Graphics g, RibbonButton button, Ribbon ribbon)
	{
		DrawButtonChecked(g, button.Bounds, ButtonCorners(button), ribbon);
	}

	public void DrawButtonCheckedSelected(Graphics g, RibbonButton button, Ribbon ribbon)
	{
		DrawButtonCheckedSelected(g, button.Bounds, ButtonCorners(button), ribbon);
	}

	public void DrawButtonChecked(Graphics g, Rectangle bounds, Corners corners, Ribbon ribbon)
	{
		if (bounds.Height <= 0 || bounds.Width <= 0)
		{
			return;
		}
		if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Rectangle r = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
			Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
			Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double)bounds.Height * 0.36));
			using GraphicsPath path = RoundRectangle(r, 3, corners);
			using (SolidBrush brush = new SolidBrush(ColorTable.ButtonCheckedBgOut))
			{
				g.FillPath(brush, path);
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
				graphicsPath.CloseFigure();
				using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
				pathGradientBrush.WrapMode = WrapMode.Clamp;
				pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
				pathGradientBrush.CenterColor = ColorTable.ButtonCheckedBgCenter;
				pathGradientBrush.SurroundColors = new Color[1] { ColorTable.ButtonCheckedBgOut };
				Blend blend = new Blend(3);
				blend.Factors = new float[3] { 0f, 0.8f, 0f };
				blend.Positions = new float[3] { 0f, 0.3f, 1f };
				Region clip = g.Clip;
				Region region = new Region(path);
				region.Intersect(clip);
				g.SetClip(region.GetBounds(g));
				g.FillPath(pathGradientBrush, graphicsPath);
				g.Clip = clip;
			}
			using (Pen pen = new Pen(ColorTable.ButtonCheckedBorderOut))
			{
				g.DrawPath(pen, path);
			}
			using (GraphicsPath path2 = RoundRectangle(r2, 3, corners))
			{
				using Pen pen2 = new Pen(ColorTable.ButtonCheckedBorderIn);
				g.DrawPath(pen2, path2);
			}
			using GraphicsPath path3 = RoundRectangle(rectangle, 3, (corners & Corners.NorthWest) | (corners & Corners.NorthEast));
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, ColorTable.ButtonCheckedGlossyNorth, ColorTable.ButtonCheckedGlossySouth, 90f);
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			g.FillPath(linearGradientBrush, path3);
		}
		if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using GraphicsPath path4 = FlatRectangle(bounds);
		using SolidBrush brush2 = new SolidBrush(ColorTable.ButtonChecked_2013);
		g.FillPath(brush2, path4);
	}

	public void DrawButtonCheckedSelected(Graphics g, Rectangle bounds, Corners corners, Ribbon ribbon)
	{
		if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using GraphicsPath path = RoundRectangle(Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1), 3, corners);
			Rectangle r = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
			Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double)bounds.Height * 0.36));
			using (SolidBrush brush = new SolidBrush(ColorTable.ButtonCheckedSelectedBgOut))
			{
				g.FillPath(brush, path);
			}
			using (Pen pen = new Pen(ColorTable.ButtonCheckedSelectedBorderOut))
			{
				g.DrawPath(pen, path);
			}
			using (GraphicsPath path2 = RoundRectangle(r, 3, corners))
			{
				using Pen pen2 = new Pen(ColorTable.ButtonCheckedSelectedBorderIn);
				g.DrawPath(pen2, path2);
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
				graphicsPath.CloseFigure();
				using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
				pathGradientBrush.WrapMode = WrapMode.Clamp;
				pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
				pathGradientBrush.CenterColor = ColorTable.ButtonCheckedSelectedBgCenter;
				pathGradientBrush.SurroundColors = new Color[1] { ColorTable.ButtonCheckedSelectedBgOut };
				Blend blend = new Blend(3);
				blend.Factors = new float[3] { 0f, 0.8f, 0f };
				blend.Positions = new float[3] { 0f, 0.3f, 1f };
				Region clip = g.Clip;
				Region region = new Region(path);
				region.Intersect(clip);
				g.SetClip(region.GetBounds(g));
				g.FillPath(pathGradientBrush, graphicsPath);
				g.Clip = clip;
			}
			using GraphicsPath path3 = RoundRectangle(rectangle, 3, (corners & Corners.NorthWest) | (corners & Corners.NorthEast));
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, ColorTable.ButtonCheckedSelectedGlossyNorth, ColorTable.ButtonCheckedSelectedGlossySouth, 90f);
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			g.FillPath(linearGradientBrush, path3);
		}
		if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using GraphicsPath path4 = FlatRectangle(bounds);
		using SolidBrush brush2 = new SolidBrush(ColorTable.ButtonCheckedSelectedBgOut);
		g.FillPath(brush2, path4);
	}

	public void DrawButtonSelected(Graphics g, RibbonButton button, Ribbon ribbon)
	{
		DrawButtonSelected(g, button.Bounds, ButtonCorners(button), ribbon);
	}

	public void DrawSplitButton(RibbonItemRenderEventArgs e, RibbonButton button)
	{
	}

	public void DrawSplitButtonPressed(RibbonItemRenderEventArgs e, RibbonButton button)
	{
	}

	public void DrawSplitButtonSelected(RibbonItemRenderEventArgs e, RibbonButton button)
	{
		Rectangle r = Rectangle.FromLTRB(button.DropDownBounds.Left, button.DropDownBounds.Top, button.DropDownBounds.Right - 1, button.DropDownBounds.Bottom - 1);
		Rectangle r2 = Rectangle.FromLTRB(r.Left + 1, r.Top + 1, r.Right - 1, r.Bottom - 1);
		Rectangle r3 = Rectangle.FromLTRB(button.ButtonFaceBounds.Left, button.ButtonFaceBounds.Top, button.ButtonFaceBounds.Right - 1, button.ButtonFaceBounds.Bottom - 1);
		Rectangle r4 = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right + ((button.SizeMode == RibbonElementSizeMode.Large) ? (-1) : 0), r3.Bottom + ((button.SizeMode != RibbonElementSizeMode.Large) ? (-1) : 0));
		Corners corners = ButtonFaceRounding(button);
		Corners corners2 = ButtonDdRounding(button);
		GraphicsPath graphicsPath = RoundRectangle(r, 3, corners2);
		GraphicsPath graphicsPath2 = RoundRectangle(r2, 2, corners2);
		GraphicsPath graphicsPath3 = RoundRectangle(r3, 3, corners);
		GraphicsPath graphicsPath4 = RoundRectangle(r4, 2, corners);
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(150, Color.White)))
		{
			e.Graphics.FillPath(brush, graphicsPath2);
		}
		using (Pen pen = new Pen((button.Pressed && button.SizeMode != RibbonElementSizeMode.DropDown) ? ColorTable.ButtonPressedBorderOut : ColorTable.ButtonSelectedBorderOut))
		{
			e.Graphics.DrawPath(pen, graphicsPath);
		}
		using (Pen pen2 = new Pen((button.Pressed && button.SizeMode != RibbonElementSizeMode.DropDown) ? ColorTable.ButtonPressedBorderIn : ColorTable.ButtonSelectedBorderIn))
		{
			e.Graphics.DrawPath(pen2, graphicsPath4);
		}
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
		graphicsPath3.Dispose();
		graphicsPath4.Dispose();
	}

	public void DrawSplitButtonDropDownPressed(RibbonItemRenderEventArgs e, RibbonButton button)
	{
	}

	public void DrawSplitButtonDropDownSelected(RibbonItemRenderEventArgs e, RibbonButton button)
	{
		Rectangle r = Rectangle.FromLTRB(button.DropDownBounds.Left, button.DropDownBounds.Top, button.DropDownBounds.Right - 1, button.DropDownBounds.Bottom - 1);
		Rectangle r2 = Rectangle.FromLTRB(r.Left + 1, r.Top + ((button.SizeMode == RibbonElementSizeMode.Large) ? 1 : 0), r.Right - 1, r.Bottom - 1);
		Rectangle r3 = Rectangle.FromLTRB(button.ButtonFaceBounds.Left, button.ButtonFaceBounds.Top, button.ButtonFaceBounds.Right - 1, button.ButtonFaceBounds.Bottom - 1);
		Rectangle r4 = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right + ((button.SizeMode == RibbonElementSizeMode.Large) ? (-1) : 0), r3.Bottom + ((button.SizeMode != RibbonElementSizeMode.Large) ? (-1) : 0));
		Corners corners = ButtonFaceRounding(button);
		Corners corners2 = ButtonDdRounding(button);
		GraphicsPath graphicsPath = RoundRectangle(r, 3, corners2);
		GraphicsPath graphicsPath2 = RoundRectangle(r2, 2, corners2);
		GraphicsPath graphicsPath3 = RoundRectangle(r3, 3, corners);
		GraphicsPath graphicsPath4 = RoundRectangle(r4, 2, corners);
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(150, Color.White)))
		{
			e.Graphics.FillPath(brush, graphicsPath4);
		}
		using (Pen pen = new Pen((button.Pressed && button.SizeMode != RibbonElementSizeMode.DropDown) ? ColorTable.ButtonPressedBorderIn : ColorTable.ButtonSelectedBorderIn))
		{
			e.Graphics.DrawPath(pen, graphicsPath4);
		}
		using (Pen pen2 = new Pen((button.Pressed && button.SizeMode != RibbonElementSizeMode.DropDown) ? ColorTable.ButtonPressedBorderOut : ColorTable.ButtonSelectedBorderOut))
		{
			e.Graphics.DrawPath(pen2, graphicsPath3);
		}
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
		graphicsPath3.Dispose();
		graphicsPath4.Dispose();
	}

	public void DrawItemGroup(RibbonItemRenderEventArgs e, RibbonItemGroup grp)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			Rectangle r = Rectangle.FromLTRB(grp.Bounds.Left, grp.Bounds.Top, grp.Bounds.Right - 1, grp.Bounds.Bottom - 1);
			Rectangle rectangle = Rectangle.FromLTRB(r.Left + 1, r.Top + 1, r.Right - 1, r.Bottom - 1);
			Rectangle rectangle2 = Rectangle.FromLTRB(r.Left + 1, r.Top + r.Height / 2 + 1, r.Right - 1, r.Bottom - 1);
			GraphicsPath graphicsPath = RoundRectangle(r, 2);
			GraphicsPath graphicsPath2 = RoundRectangle(rectangle, 2);
			GraphicsPath path = RoundRectangle(rectangle2, 2);
			using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, ColorTable.ItemGroupBgNorth, ColorTable.ItemGroupBgSouth, 90f))
			{
				e.Graphics.FillPath(brush, graphicsPath2);
			}
			using (LinearGradientBrush brush2 = new LinearGradientBrush(rectangle2, ColorTable.ItemGroupBgGlossy, Color.Transparent, 90f))
			{
				e.Graphics.FillPath(brush2, path);
			}
			graphicsPath.Dispose();
			graphicsPath2.Dispose();
		}
	}

	public void DrawItemGroupBorder(RibbonItemRenderEventArgs e, RibbonItemGroup grp)
	{
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007 && !e.Ribbon.IsDesignMode())
		{
			return;
		}
		Rectangle r = Rectangle.FromLTRB(grp.Bounds.Left, grp.Bounds.Top, grp.Bounds.Right - 1, grp.Bounds.Bottom - 1);
		Rectangle r2 = Rectangle.FromLTRB(r.Left + 1, r.Top + 1, r.Right - 1, r.Bottom - 1);
		GraphicsPath graphicsPath = RoundRectangle(r, 2);
		GraphicsPath graphicsPath2 = RoundRectangle(r2, 2);
		using (Pen pen = new Pen(ColorTable.ItemGroupSeparatorDark))
		{
			using Pen pen2 = new Pen(ColorTable.ItemGroupSeparatorLight);
			foreach (RibbonItem item in grp.Items)
			{
				if (item == grp.LastItem)
				{
					break;
				}
				e.Graphics.DrawLine(pen, new Point(item.Bounds.Right, item.Bounds.Top), new Point(item.Bounds.Right, item.Bounds.Bottom));
				e.Graphics.DrawLine(pen2, new Point(item.Bounds.Right + 1, item.Bounds.Top), new Point(item.Bounds.Right + 1, item.Bounds.Bottom));
			}
		}
		using (Pen pen3 = new Pen(ColorTable.ItemGroupOuterBorder))
		{
			e.Graphics.DrawPath(pen3, graphicsPath);
		}
		using (Pen pen4 = new Pen(ColorTable.ItemGroupInnerBorder))
		{
			e.Graphics.DrawPath(pen4, graphicsPath2);
		}
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
	}

	public void DrawButtonList(Graphics g, RibbonButtonList list, Ribbon ribbon)
	{
		using (GraphicsPath path = RoundRectangle(Rectangle.FromLTRB(list.Bounds.Left, list.Bounds.Top, list.Bounds.Right - 1, list.Bounds.Bottom), 3, Corners.East))
		{
			Color color = (list.Selected ? ColorTable.ButtonListBgSelected : ColorTable.ButtonListBg);
			if (list.Canvas is RibbonDropDown)
			{
				color = ColorTable.DropDownBg;
			}
			using (SolidBrush brush = new SolidBrush(color))
			{
				g.FillPath(brush, path);
			}
			using Pen pen = new Pen(ColorTable.ButtonListBorder);
			g.DrawPath(pen, path);
		}
		if (list.ScrollType == RibbonButtonList.ListScrollType.Scrollbar && ScrollBarRenderer.IsSupported)
		{
			ScrollBarRenderer.DrawUpperVerticalTrack(g, list.ScrollBarBounds, ScrollBarState.Normal);
			if (list.ThumbPressed)
			{
				ScrollBarRenderer.DrawVerticalThumb(g, list.ThumbBounds, ScrollBarState.Pressed);
				ScrollBarRenderer.DrawVerticalThumbGrip(g, list.ThumbBounds, ScrollBarState.Pressed);
			}
			else if (list.ThumbSelected)
			{
				ScrollBarRenderer.DrawVerticalThumb(g, list.ThumbBounds, ScrollBarState.Hot);
				ScrollBarRenderer.DrawVerticalThumbGrip(g, list.ThumbBounds, ScrollBarState.Hot);
			}
			else
			{
				ScrollBarRenderer.DrawVerticalThumb(g, list.ThumbBounds, ScrollBarState.Normal);
				ScrollBarRenderer.DrawVerticalThumbGrip(g, list.ThumbBounds, ScrollBarState.Normal);
			}
			if (list.ButtonUpPressed)
			{
				ScrollBarRenderer.DrawArrowButton(g, list.ButtonUpBounds, ScrollBarArrowButtonState.UpPressed);
			}
			else if (list.ButtonUpSelected)
			{
				ScrollBarRenderer.DrawArrowButton(g, list.ButtonUpBounds, ScrollBarArrowButtonState.UpHot);
			}
			else
			{
				ScrollBarRenderer.DrawArrowButton(g, list.ButtonUpBounds, ScrollBarArrowButtonState.UpNormal);
			}
			if (list.ButtonDownPressed)
			{
				ScrollBarRenderer.DrawArrowButton(g, list.ButtonDownBounds, ScrollBarArrowButtonState.DownPressed);
			}
			else if (list.ButtonDownSelected)
			{
				ScrollBarRenderer.DrawArrowButton(g, list.ButtonDownBounds, ScrollBarArrowButtonState.DownHot);
			}
			else
			{
				ScrollBarRenderer.DrawArrowButton(g, list.ButtonDownBounds, ScrollBarArrowButtonState.DownNormal);
			}
			return;
		}
		if (list.ScrollType == RibbonButtonList.ListScrollType.Scrollbar)
		{
			using SolidBrush brush2 = new SolidBrush(ColorTable.ButtonGlossyNorth);
			g.FillRectangle(brush2, list.ScrollBarBounds);
		}
		if (!list.ButtonDownEnabled)
		{
			DrawButtonDisabled(g, list.ButtonDownBounds, (!list.ButtonDropDownPresent) ? Corners.SouthEast : Corners.None);
		}
		else if (list.ButtonDownPressed)
		{
			DrawButtonPressed(g, list.ButtonDownBounds, (!list.ButtonDropDownPresent) ? Corners.SouthEast : Corners.None, ribbon);
		}
		else if (list.ButtonDownSelected)
		{
			DrawButtonSelected(g, list.ButtonDownBounds, (!list.ButtonDropDownPresent) ? Corners.SouthEast : Corners.None, ribbon);
		}
		else
		{
			DrawButton(g, list.ButtonDownBounds, Corners.None);
		}
		if (!list.ButtonUpEnabled)
		{
			DrawButtonDisabled(g, list.ButtonUpBounds, Corners.NorthEast);
		}
		else if (list.ButtonUpPressed)
		{
			DrawButtonPressed(g, list.ButtonUpBounds, Corners.NorthEast, ribbon);
		}
		else if (list.ButtonUpSelected)
		{
			DrawButtonSelected(g, list.ButtonUpBounds, Corners.NorthEast, ribbon);
		}
		else
		{
			DrawButton(g, list.ButtonUpBounds, Corners.NorthEast);
		}
		if (list.ButtonDropDownPresent)
		{
			if (list.ButtonDropDownPressed)
			{
				DrawButtonPressed(g, list.ButtonDropDownBounds, Corners.SouthEast, ribbon);
			}
			else if (list.ButtonDropDownSelected)
			{
				DrawButtonSelected(g, list.ButtonDropDownBounds, Corners.SouthEast, ribbon);
			}
			else
			{
				DrawButton(g, list.ButtonDropDownBounds, Corners.SouthEast);
			}
		}
		if (list.ScrollType == RibbonButtonList.ListScrollType.Scrollbar && list.ScrollBarEnabled)
		{
			if (list.ThumbPressed)
			{
				DrawButtonPressed(g, list.ThumbBounds, Corners.All, ribbon);
			}
			else if (list.ThumbSelected)
			{
				DrawButtonSelected(g, list.ThumbBounds, Corners.All, ribbon);
			}
			else
			{
				DrawButton(g, list.ThumbBounds, Corners.All);
			}
		}
		Color arrow = ColorTable.Arrow;
		Color arrowLight = ColorTable.ArrowLight;
		Color arrowDisabled = ColorTable.ArrowDisabled;
		Rectangle b = CenterOn(list.ButtonUpBounds, new Rectangle(Point.Empty, arrowSize));
		b.Offset(0, 1);
		Rectangle b2 = CenterOn(list.ButtonDownBounds, new Rectangle(Point.Empty, arrowSize));
		b2.Offset(0, 1);
		Rectangle b3 = CenterOn(list.ButtonDropDownBounds, new Rectangle(Point.Empty, arrowSize));
		b3.Offset(0, 3);
		DrawArrow(g, b, list.ButtonUpEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Up);
		b.Offset(0, -1);
		DrawArrow(g, b, list.ButtonUpEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Up);
		DrawArrow(g, b2, list.ButtonDownEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Down);
		b2.Offset(0, -1);
		DrawArrow(g, b2, list.ButtonDownEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Down);
		if (list.ButtonDropDownPresent)
		{
			using (SolidBrush brush3 = new SolidBrush(ColorTable.Arrow))
			{
				SmoothingMode smoothingMode = g.SmoothingMode;
				g.SmoothingMode = SmoothingMode.None;
				g.FillRectangle(brush3, new Rectangle(new Point(b3.Left - 1, b3.Top - 4), new Size(arrowSize.Width + 2, 1)));
				g.SmoothingMode = smoothingMode;
			}
			DrawArrow(g, b3, arrowLight, RibbonArrowDirection.Down);
			b3.Offset(0, -1);
			DrawArrow(g, b3, arrow, RibbonArrowDirection.Down);
		}
	}

	public void DrawSeparator(Graphics g, RibbonSeparator separator, Ribbon ribbon)
	{
		if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			if (separator.SizeMode == RibbonElementSizeMode.DropDown)
			{
				if (!string.IsNullOrEmpty(separator.Text))
				{
					using (SolidBrush brush = new SolidBrush(ColorTable.SeparatorBg))
					{
						g.FillRectangle(brush, separator.Bounds);
					}
					using Pen pen = new Pen(ColorTable.SeparatorLine);
					g.DrawLine(pen, new Point(separator.Bounds.Left, separator.Bounds.Bottom), new Point(separator.Bounds.Right, separator.Bounds.Bottom));
				}
				else
				{
					using Pen pen2 = new Pen(ColorTable.DropDownImageSeparator);
					g.DrawLine(pen2, new Point(separator.Bounds.Left + ((separator.DropDownWidth != RibbonSeparatorDropDownWidth.Full) ? 40 : 0), separator.Bounds.Top), new Point(separator.Bounds.Right, separator.Bounds.Top));
				}
			}
			else if (separator.OwnerPanel == null)
			{
				using (Pen pen3 = new Pen(ColorTable.QATSeparatorDark))
				{
					g.DrawLine(pen3, new Point(separator.Bounds.Left + 1, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 1, separator.Bounds.Bottom - 1));
				}
				using Pen pen4 = new Pen(ColorTable.QATSeparatorLight);
				g.DrawLine(pen4, new Point(separator.Bounds.Left + 2, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 2, separator.Bounds.Bottom - 1));
			}
			else
			{
				using (Pen pen5 = new Pen(ColorTable.SeparatorDark))
				{
					g.DrawLine(pen5, new Point(separator.Bounds.Left + 1, separator.Bounds.Top), new Point(separator.Bounds.Left + 1, separator.Bounds.Bottom));
				}
				using Pen pen6 = new Pen(ColorTable.SeparatorLight);
				g.DrawLine(pen6, new Point(separator.Bounds.Left + 2, separator.Bounds.Top), new Point(separator.Bounds.Left + 2, separator.Bounds.Bottom));
			}
		}
		if (ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended)
		{
			return;
		}
		if (separator.SizeMode == RibbonElementSizeMode.DropDown)
		{
			if (!string.IsNullOrEmpty(separator.Text))
			{
				using (SolidBrush brush2 = new SolidBrush(ColorTable.SeparatorBg))
				{
					g.FillRectangle(brush2, separator.Bounds);
				}
				using Pen pen7 = new Pen(ColorTable.SeparatorLine);
				g.DrawLine(pen7, new Point(separator.Bounds.Left, separator.Bounds.Bottom), new Point(separator.Bounds.Right, separator.Bounds.Bottom));
				return;
			}
			using Pen pen8 = new Pen(ColorTable.DropDownImageSeparator);
			if (separator.DropDownWidth == RibbonSeparatorDropDownWidth.Partial)
			{
				pen8.DashStyle = DashStyle.Dash;
			}
			g.DrawLine(pen8, new Point(separator.Bounds.Left + ((separator.DropDownWidth != RibbonSeparatorDropDownWidth.Full) ? 40 : 0), separator.Bounds.Top), new Point(separator.Bounds.Right, separator.Bounds.Top));
			return;
		}
		if (separator.OwnerPanel == null)
		{
			using (Pen pen9 = new Pen(ColorTable.QATSeparatorDark))
			{
				SmoothingMode smoothingMode = g.SmoothingMode;
				g.SmoothingMode = SmoothingMode.None;
				g.DrawLine(pen9, new Point(separator.Bounds.Left + 1, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 1, separator.Bounds.Bottom - 1));
				g.SmoothingMode = smoothingMode;
			}
			using Pen pen10 = new Pen(ColorTable.QATSeparatorLight);
			SmoothingMode smoothingMode2 = g.SmoothingMode;
			g.SmoothingMode = SmoothingMode.None;
			g.DrawLine(pen10, new Point(separator.Bounds.Left + 2, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 2, separator.Bounds.Bottom - 1));
			g.SmoothingMode = smoothingMode2;
			return;
		}
		using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(separator.Bounds.Left, separator.Bounds.Top), new Point(separator.Bounds.Left, separator.Bounds.Bottom), Color.FromArgb(50, ColorTable.SeparatorDark), ColorTable.SeparatorDark))
		{
			linearGradientBrush.SetSigmaBellShape(0.5f);
			using Pen pen11 = new Pen(linearGradientBrush);
			SmoothingMode smoothingMode3 = g.SmoothingMode;
			g.SmoothingMode = SmoothingMode.None;
			g.DrawLine(pen11, separator.Bounds.Left + 2, separator.Bounds.Top + 3, separator.Bounds.Left + 2, separator.Bounds.Bottom - 7);
			g.SmoothingMode = smoothingMode3;
		}
		using LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new Point(separator.Bounds.Left, separator.Bounds.Top), new Point(separator.Bounds.Left, separator.Bounds.Bottom), Color.FromArgb(50, ColorTable.SeparatorLight), ColorTable.SeparatorLight);
		linearGradientBrush2.SetSigmaBellShape(0.5f);
		using Pen pen12 = new Pen(linearGradientBrush2);
		SmoothingMode smoothingMode4 = g.SmoothingMode;
		g.SmoothingMode = SmoothingMode.None;
		g.DrawLine(pen12, separator.Bounds.Left + 1, separator.Bounds.Top + 3, separator.Bounds.Left + 1, separator.Bounds.Bottom - 7);
		g.DrawLine(pen12, separator.Bounds.Left + 3, separator.Bounds.Top + 3, separator.Bounds.Left + 3, separator.Bounds.Bottom - 7);
		g.SmoothingMode = smoothingMode4;
	}

	public void DrawTextBoxDisabled(Graphics g, Rectangle bounds)
	{
		using (SolidBrush brush = new SolidBrush(SystemColors.Control))
		{
			g.FillRectangle(brush, bounds);
		}
		using Pen pen = new Pen(ColorTable.TextBoxBorder);
		g.DrawRectangle(pen, bounds);
	}

	public void DrawTextBoxUnselected(Graphics g, Rectangle bounds)
	{
		using (SolidBrush brush = new SolidBrush(ColorTable.TextBoxUnselectedBg))
		{
			g.FillRectangle(brush, bounds);
		}
		using Pen pen = new Pen(ColorTable.TextBoxBorder);
		g.DrawRectangle(pen, bounds);
	}

	public void DrawTextBoxSelected(Graphics g, Rectangle bounds)
	{
		using (RoundRectangle(bounds, 3))
		{
			using (SolidBrush brush = new SolidBrush(SystemColors.Window))
			{
				g.FillRectangle(brush, bounds);
			}
			using Pen pen = new Pen(ColorTable.TextBoxBorder);
			g.DrawRectangle(pen, bounds);
		}
	}

	[Obsolete("use DrawComboBoxDropDown")]
	public void DrawComboxDropDown(Graphics g, RibbonComboBox b, Ribbon ribbon)
	{
		DrawComboBoxDropDown(g, b, ribbon);
	}

	public void DrawComboBoxDropDown(Graphics g, RibbonComboBox b, Ribbon ribbon)
	{
		if (b.DropDownButtonPressed)
		{
			DrawButtonPressed(g, b.DropDownButtonBounds, Corners.None, ribbon);
		}
		else if (b.DropDownButtonSelected)
		{
			DrawButtonSelected(g, b.DropDownButtonBounds, Corners.None, ribbon);
		}
		else if (b.Selected)
		{
			DrawButton(g, b.DropDownButtonBounds, Corners.None);
		}
		DrawArrowShaded(g, b.DropDownButtonBounds, RibbonArrowDirection.Down, enabled: true);
	}

	public void DrawUpDownButtons(Graphics g, RibbonUpDown b, Ribbon ribbon)
	{
		if (b.UpButtonPressed)
		{
			DrawButtonPressed(g, b.UpButtonBounds, Corners.None, ribbon);
		}
		else if (b.UpButtonSelected)
		{
			DrawButtonSelected(g, b.UpButtonBounds, Corners.None, ribbon);
		}
		else
		{
			DrawButton(g, b.UpButtonBounds, Corners.None);
		}
		if (b.DownButtonPressed)
		{
			DrawButtonPressed(g, b.DownButtonBounds, Corners.None, ribbon);
		}
		else if (b.DownButtonSelected)
		{
			DrawButtonSelected(g, b.DownButtonBounds, Corners.None, ribbon);
		}
		else
		{
			DrawButton(g, b.DownButtonBounds, Corners.None);
		}
		DrawArrowShaded(g, b.UpButtonBounds, RibbonArrowDirection.Up, enabled: true);
		DrawArrowShaded(g, b.DownButtonBounds, RibbonArrowDirection.Down, enabled: true);
	}

	public void DrawCaptionBarBackground(Rectangle r, Graphics g)
	{
		SmoothingMode smoothingMode = g.SmoothingMode;
		Rectangle rectangle = new Rectangle(r.Left, r.Top, r.Width, 4);
		Rectangle rectangle2 = new Rectangle(r.Left, rectangle.Bottom, r.Width, 4);
		Rectangle rectangle3 = new Rectangle(r.Left, rectangle2.Bottom, r.Width, r.Height - 8);
		Rectangle rectangle4 = new Rectangle(r.Left, rectangle3.Bottom, r.Width, 1);
		Rectangle[] array = new Rectangle[4] { rectangle, rectangle2, rectangle3, rectangle4 };
		Color[,] array2 = new Color[4, 2]
		{
			{ ColorTable.Caption1, ColorTable.Caption2 },
			{ ColorTable.Caption3, ColorTable.Caption4 },
			{ ColorTable.Caption5, ColorTable.Caption6 },
			{ ColorTable.Caption7, ColorTable.Caption7 }
		};
		g.SmoothingMode = SmoothingMode.None;
		for (int i = 0; i < array.Length; i++)
		{
			Rectangle rect = array[i];
			rect.Height += 2;
			rect.Y--;
			using LinearGradientBrush brush = new LinearGradientBrush(rect, array2[i, 0], array2[i, 1], 90f);
			g.FillRectangle(brush, array[i]);
		}
		g.SmoothingMode = smoothingMode;
	}

	private void DrawCaptionBarText(Rectangle captionBar, RibbonRenderEventArgs e)
	{
		Form form = e.Ribbon.FindForm();
		if (form == null)
		{
			return;
		}
		Font font = new Font(SystemFonts.CaptionFont, FontStyle.Regular);
		if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
		{
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				WinApi.DrawTextOnGlass(e.Graphics, form.Text, font, captionBar, 10);
			}
			else
			{
				WinApi.DrawTextOnGlass(e.Graphics, form.Text, SystemFonts.CaptionFont, captionBar, 10);
			}
		}
		else
		{
			if (e.Ribbon.ActualBorderMode != RibbonWindowMode.NonClientAreaCustomDrawn)
			{
				return;
			}
			using StringFormat format = StringFormatFactory.CenterNoWrapTrimEllipsis();
			using Brush brush = new SolidBrush(ColorTable.FormBorder);
			e.Graphics.DrawString(form.Text, font, brush, captionBar, format);
		}
	}

	private GraphicsPath CreateQuickAccessPath(Point a, Point b, Point c, Point d, Point e, Rectangle bounds, int offsetx, int offsety, Ribbon ribbon)
	{
		a.Offset(offsetx, offsety);
		b.Offset(offsetx, offsety);
		c.Offset(offsetx, offsety);
		d.Offset(offsetx, offsety);
		e.Offset(offsetx, offsety);
		GraphicsPath graphicsPath = new GraphicsPath();
		if (ribbon.RightToLeft == RightToLeft.No)
		{
			graphicsPath.AddLine(a, b);
			graphicsPath.AddArc(new Rectangle(b.X - bounds.Height / 2, b.Y, bounds.Height, bounds.Height), -90f, 180f);
			graphicsPath.AddLine(d, c);
			if (ribbon.OrbVisible)
			{
				graphicsPath.AddCurve(new Point[3] { c, e, a });
			}
			else
			{
				graphicsPath.AddArc(new Rectangle(a.X - bounds.Height / 2, a.Y, bounds.Height, bounds.Height), 90f, 180f);
			}
		}
		else
		{
			graphicsPath.AddLine(d, c);
			graphicsPath.AddArc(new Rectangle(a.X - bounds.Height / 2, a.Y, bounds.Height, bounds.Height), 90f, 180f);
			graphicsPath.AddLine(a, b);
			if (ribbon.OrbVisible)
			{
				graphicsPath.AddCurve(new Point[3] { b, e, d });
			}
			else
			{
				graphicsPath.AddArc(new Rectangle(b.X - bounds.Height / 2, b.Y, bounds.Height, bounds.Height), -90f, 180f);
			}
		}
		return graphicsPath;
	}

	public void DrawOrb(Graphics g, Rectangle r, Image image, bool selected, bool pressed)
	{
		Rectangle rectangle = r;
		rectangle.Inflate(-1, -1);
		Rectangle rect = r;
		rect.Offset(1, 1);
		rect.Inflate(2, 2);
		Color color;
		Color color2;
		Color centerColor;
		Color color3;
		if (pressed)
		{
			color = ColorTable.OrbPressedBackgroundDark;
			color2 = ColorTable.OrbPressedBackgroundMedium;
			centerColor = ColorTable.OrbPressedBackgroundLight;
			color3 = ColorTable.OrbPressedLight;
		}
		else if (selected)
		{
			color = ColorTable.OrbSelectedBackgroundDark;
			color2 = ColorTable.OrbSelectedBackgroundDark;
			centerColor = ColorTable.OrbSelectedBackgroundLight;
			color3 = ColorTable.OrbSelectedLight;
		}
		else
		{
			color = ColorTable.OrbBackgroundDark;
			color2 = ColorTable.OrbBackgroundMedium;
			centerColor = ColorTable.OrbBackgroundLight;
			color3 = ColorTable.OrbLight;
		}
		using (GraphicsPath graphicsPath = new GraphicsPath())
		{
			graphicsPath.AddEllipse(rect);
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.WrapMode = WrapMode.Clamp;
			pathGradientBrush.CenterPoint = new PointF(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			pathGradientBrush.CenterColor = Color.FromArgb(180, Color.Black);
			pathGradientBrush.SurroundColors = new Color[1] { Color.Transparent };
			Blend blend = new Blend(3);
			blend.Factors = new float[3] { 0f, 1f, 1f };
			blend.Positions = new float[3] { 0f, 0.2f, 1f };
			Blend blend2 = blend;
			pathGradientBrush.Blend = blend2;
			g.FillPath(pathGradientBrush, graphicsPath);
		}
		using (Pen pen = new Pen(color, 1f))
		{
			g.DrawEllipse(pen, r);
		}
		using (GraphicsPath graphicsPath2 = new GraphicsPath())
		{
			graphicsPath2.AddEllipse(r);
			using PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath2);
			pathGradientBrush2.WrapMode = WrapMode.Clamp;
			pathGradientBrush2.CenterPoint = new PointF(Convert.ToSingle(r.Left + r.Width / 2), Convert.ToSingle(r.Bottom));
			pathGradientBrush2.CenterColor = centerColor;
			pathGradientBrush2.SurroundColors = new Color[1] { color2 };
			Blend blend = new Blend(3);
			blend.Factors = new float[3] { 0f, 0.8f, 1f };
			blend.Positions = new float[3] { 0f, 0.5f, 1f };
			Blend blend3 = blend;
			pathGradientBrush2.Blend = blend3;
			g.FillPath(pathGradientBrush2, graphicsPath2);
		}
		Rectangle rect2 = new Rectangle(0, 0, r.Width / 2, r.Height / 2);
		rect2.X = r.X + (r.Width - rect2.Width) / 2;
		rect2.Y = r.Y + r.Height / 2;
		using (GraphicsPath graphicsPath3 = new GraphicsPath())
		{
			graphicsPath3.AddEllipse(rect2);
			using PathGradientBrush pathGradientBrush3 = new PathGradientBrush(graphicsPath3);
			pathGradientBrush3.WrapMode = WrapMode.Clamp;
			pathGradientBrush3.CenterPoint = new PointF(Convert.ToSingle(r.Left + r.Width / 2), Convert.ToSingle(r.Bottom));
			pathGradientBrush3.CenterColor = Color.White;
			pathGradientBrush3.SurroundColors = new Color[1] { Color.Transparent };
			g.FillPath(pathGradientBrush3, graphicsPath3);
		}
		using (GraphicsPath graphicsPath4 = new GraphicsPath())
		{
			int num = 160;
			int num2 = 180 + (180 - num) / 2;
			graphicsPath4.AddArc(rectangle, num2, num);
			Point point = Point.Round(graphicsPath4.PathData.Points[0]);
			Point point2 = Point.Round(graphicsPath4.PathData.Points[graphicsPath4.PathData.Points.Length - 1]);
			Point point3 = new Point(rectangle.Left + rectangle.Width / 2, point2.Y - 3);
			graphicsPath4.AddCurve(new Point[3] { point2, point3, point });
			using (PathGradientBrush pathGradientBrush4 = new PathGradientBrush(graphicsPath4))
			{
				pathGradientBrush4.WrapMode = WrapMode.Clamp;
				pathGradientBrush4.CenterPoint = point3;
				pathGradientBrush4.CenterColor = Color.Transparent;
				pathGradientBrush4.SurroundColors = new Color[1] { color3 };
				Blend blend = new Blend(3);
				blend.Factors = new float[3] { 0.3f, 0.8f, 1f };
				blend.Positions = new float[3] { 0f, 0.5f, 1f };
				Blend blend4 = blend;
				pathGradientBrush4.Blend = blend4;
				g.FillPath(pathGradientBrush4, graphicsPath4);
			}
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(r.Left, r.Top), new Point(r.Left, point.Y), Color.White, Color.Transparent);
			Blend blend = new Blend(4);
			blend.Factors = new float[4] { 0f, 0.4f, 0.8f, 1f };
			blend.Positions = new float[4] { 0f, 0.3f, 0.4f, 1f };
			Blend blend5 = blend;
			linearGradientBrush.Blend = blend5;
			g.FillPath(linearGradientBrush, graphicsPath4);
		}
		using (GraphicsPath graphicsPath5 = new GraphicsPath())
		{
			int num = 160;
			int num2 = 180 + (180 - num) / 2;
			graphicsPath5.AddArc(rectangle, num2, num);
			using Pen pen2 = new Pen(Color.White);
			g.DrawPath(pen2, graphicsPath5);
		}
		using (GraphicsPath graphicsPath6 = new GraphicsPath())
		{
			int num = 160;
			int num2 = (180 - num) / 2;
			graphicsPath6.AddArc(rectangle, num2, num);
			Point point4 = Point.Round(graphicsPath6.PathData.Points[0]);
			Rectangle rect3 = rectangle;
			rect3.Inflate(-1, -1);
			num = 160;
			num2 = (180 - num) / 2;
			graphicsPath6.AddArc(rect3, num2, num);
			using LinearGradientBrush brush = new LinearGradientBrush(new Point(rectangle.Left, rectangle.Bottom), new Point(rectangle.Left, point4.Y - 1), color3, Color.FromArgb(50, color3));
			g.FillPath(brush, graphicsPath6);
		}
		if (image != null)
		{
			Rectangle rect4 = new Rectangle(Point.Empty, image.Size);
			rect4.X = r.X + (r.Width - rect4.Width) / 2;
			rect4.Y = r.Y + (r.Height - rect4.Height) / 2;
			g.DrawImage(image, rect4);
		}
	}

	public void DrawOrbNormal(RibbonRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (GraphicsPath path = RoundRectangle(e.ClipRectangle, 2, Corners.North))
			{
				e.Graphics.FillPath(new SolidBrush(ColorTable.OrbButtonBackground), path);
				using (Pen pen = new Pen(ColorTable.OrbButtonBorderDark))
				{
					e.Graphics.DrawPath(pen, path);
				}
				using (GraphicsPath path2 = RoundRectangle(Rectangle.FromLTRB(e.ClipRectangle.Left + 1, e.ClipRectangle.Top + 1, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom), 2, Corners.North))
				{
					using Pen pen2 = new Pen(ColorTable.OrbButtonMedium);
					e.Graphics.DrawPath(pen2, path2);
				}
				int num = e.ClipRectangle.Height / 2;
				Rectangle rect = Rectangle.FromLTRB(e.ClipRectangle.Left + 1, e.ClipRectangle.Top + num, e.ClipRectangle.Right - 2, e.ClipRectangle.Bottom - 1);
				Color orbButtonDark = ColorTable.OrbButtonDark;
				Color orbButtonLight = ColorTable.OrbButtonLight;
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, e.ClipRectangle.Top + num), new Point(0, e.ClipRectangle.Bottom), orbButtonDark, orbButtonLight);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				e.Graphics.FillRectangle(linearGradientBrush, rect);
				return;
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			using (GraphicsPath path3 = FlatRectangle(e.ClipRectangle))
			{
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(new SolidBrush(ColorTable.OrbButton_2013), path3);
				e.Graphics.SmoothingMode = smoothingMode;
			}
		}
	}

	public void DrawOrbSelected(RibbonRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (GraphicsPath path = RoundRectangle(e.ClipRectangle, 2, Corners.North))
			{
				e.Graphics.FillPath(new SolidBrush(ColorTable.ButtonPressedGlossySouth), path);
				using (Pen pen = new Pen(ColorTable.ButtonPressedBorderOut))
				{
					e.Graphics.DrawPath(pen, path);
				}
				using (GraphicsPath path2 = RoundRectangle(Rectangle.FromLTRB(e.ClipRectangle.Left + 1, e.ClipRectangle.Top + 1, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom), 2, Corners.North))
				{
					using Pen pen2 = new Pen(ColorTable.ButtonPressedBorderIn);
					e.Graphics.DrawPath(pen2, path2);
				}
				Color buttonSelectedGlossyNorth = ColorTable.ButtonSelectedGlossyNorth;
				Color buttonSelectedGlossySouth = ColorTable.ButtonSelectedGlossySouth;
				int num = e.ClipRectangle.Height / 2;
				Rectangle rect = Rectangle.FromLTRB(e.ClipRectangle.Left + 1, e.ClipRectangle.Top + num, e.ClipRectangle.Right - 2, e.ClipRectangle.Bottom - 1);
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, e.ClipRectangle.Top + num), new Point(0, e.ClipRectangle.Bottom), buttonSelectedGlossyNorth, buttonSelectedGlossySouth);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				e.Graphics.FillRectangle(linearGradientBrush, rect);
				return;
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			using (GraphicsPath path3 = FlatRectangle(e.ClipRectangle))
			{
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(new SolidBrush(ColorTable.OrbButtonSelected_2013), path3);
				e.Graphics.SmoothingMode = smoothingMode;
			}
		}
	}

	public void DrawOrbPressed(RibbonRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (GraphicsPath path = RoundRectangle(e.ClipRectangle, 2, Corners.North))
			{
				e.Graphics.FillPath(new SolidBrush(ColorTable.ButtonPressedGlossySouth), path);
				using (Pen pen = new Pen(ColorTable.ButtonPressedBorderOut))
				{
					e.Graphics.DrawPath(pen, path);
				}
				using (GraphicsPath path2 = RoundRectangle(Rectangle.FromLTRB(e.ClipRectangle.Left + 1, e.ClipRectangle.Top + 1, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom), 2, Corners.North))
				{
					using Pen pen2 = new Pen(ColorTable.ButtonPressedBorderIn);
					e.Graphics.DrawPath(pen2, path2);
				}
				Color buttonPressedGlossyNorth = ColorTable.ButtonPressedGlossyNorth;
				Color buttonPressedGlossySouth = ColorTable.ButtonPressedGlossySouth;
				int num = e.ClipRectangle.Height / 2;
				Rectangle rect = Rectangle.FromLTRB(e.ClipRectangle.Left + 1, e.ClipRectangle.Top + num, e.ClipRectangle.Right - 2, e.ClipRectangle.Bottom - 1);
				using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, e.ClipRectangle.Top + num), new Point(0, e.ClipRectangle.Bottom), buttonPressedGlossyNorth, buttonPressedGlossySouth);
				linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
				e.Graphics.FillRectangle(linearGradientBrush, rect);
				return;
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			using (GraphicsPath path3 = FlatRectangle(e.ClipRectangle))
			{
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillPath(new SolidBrush(ColorTable.OrbButtonPressed_2013), path3);
				e.Graphics.SmoothingMode = smoothingMode;
			}
		}
	}

	public override void OnRenderRibbonCaptionBar(RibbonRenderEventArgs e)
	{
		if (e.Ribbon.CaptionBarVisible)
		{
			new Rectangle(0, 0, e.Ribbon.Width, e.Ribbon.CaptionBarSize);
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				_ = RibbonDesigner.Current;
			}
			DrawCaptionBarText(e.Ribbon.CaptionTextBounds, e);
		}
	}

	public override void OnRenderOrbDropDownBackground(RibbonOrbDropDownEventArgs e)
	{
		int width = e.RibbonOrbDropDown.Width;
		int height = e.RibbonOrbDropDown.Height;
		Rectangle contentBounds = e.RibbonOrbDropDown.ContentBounds;
		Rectangle contentButtonsBounds = e.RibbonOrbDropDown.ContentButtonsBounds;
		Rectangle r = new Rectangle(0, 0, width - 1, height - 1);
		Rectangle r2 = new Rectangle(1, 1, width - 3, height - 3);
		Rectangle r3 = new Rectangle(1, 1, width - 3, contentBounds.Top / 2);
		Rectangle r4 = new Rectangle(1, r3.Bottom, r3.Width, contentBounds.Top / 2);
		Rectangle r5 = Rectangle.FromLTRB(1, (height - contentBounds.Bottom) / 2 + contentBounds.Bottom, width - 1, height - 1);
		Color orbDropDownDarkBorder = ColorTable.OrbDropDownDarkBorder;
		Color orbDropDownLightBorder = ColorTable.OrbDropDownLightBorder;
		Color orbDropDownBack = ColorTable.OrbDropDownBack;
		Color orbDropDownNorthA = ColorTable.OrbDropDownNorthA;
		Color orbDropDownNorthB = ColorTable.OrbDropDownNorthB;
		Color orbDropDownNorthC = ColorTable.OrbDropDownNorthC;
		Color orbDropDownNorthD = ColorTable.OrbDropDownNorthD;
		Color orbDropDownSouthC = ColorTable.OrbDropDownSouthC;
		Color orbDropDownSouthD = ColorTable.OrbDropDownSouthD;
		Color orbDropDownContentbg = ColorTable.OrbDropDownContentbg;
		Color orbDropDownContentbglight = ColorTable.OrbDropDownContentbglight;
		Color orbDropDownSeparatorlight = ColorTable.OrbDropDownSeparatorlight;
		Color orbDropDownSeparatordark = ColorTable.OrbDropDownSeparatordark;
		GraphicsPath graphicsPath = RoundRectangle(r2, 6);
		GraphicsPath graphicsPath2 = RoundRectangle(r, 6);
		e.Graphics.SmoothingMode = SmoothingMode.None;
		using (Brush brush = new SolidBrush(Color.FromArgb(142, 142, 142)))
		{
			e.Graphics.FillRectangle(brush, new Rectangle(width - 10, height - 10, 10, 10));
		}
		using (Brush brush2 = new SolidBrush(orbDropDownBack))
		{
			e.Graphics.FillPath(brush2, graphicsPath2);
		}
		GradientRect(e.Graphics, r3, orbDropDownNorthA, orbDropDownNorthB);
		GradientRect(e.Graphics, r4, orbDropDownNorthC, orbDropDownNorthD);
		GradientRect(e.Graphics, r5, orbDropDownSouthC, orbDropDownSouthD);
		using (Pen pen = new Pen(orbDropDownDarkBorder))
		{
			e.Graphics.DrawPath(pen, graphicsPath2);
		}
		SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		using (Pen pen2 = new Pen(orbDropDownLightBorder))
		{
			e.Graphics.DrawPath(pen2, graphicsPath);
		}
		e.Graphics.SmoothingMode = smoothingMode;
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
		r2 = contentBounds;
		r2.Inflate(0, 0);
		r = contentBounds;
		r.Inflate(1, 1);
		using (SolidBrush brush3 = new SolidBrush(orbDropDownContentbg))
		{
			e.Graphics.FillRectangle(brush3, contentBounds);
		}
		if (e.RibbonOrbDropDown.ContentRecentItemsCaptionBounds.Height > 0)
		{
			Rectangle contentRecentItemsCaptionBounds = e.RibbonOrbDropDown.ContentRecentItemsCaptionBounds;
			int num = Convert.ToInt32(e.RibbonOrbDropDown.RecentItemsCaptionLineSpacing / 2);
			using (Pen pen3 = new Pen(orbDropDownSeparatorlight))
			{
				e.Graphics.DrawLine(pen3, new Point(contentBounds.Left, contentRecentItemsCaptionBounds.Bottom - num), new Point(contentBounds.Right, contentRecentItemsCaptionBounds.Bottom - num));
			}
			using (Pen pen4 = new Pen(orbDropDownSeparatordark))
			{
				e.Graphics.DrawLine(pen4, new Point(contentBounds.Left, contentRecentItemsCaptionBounds.Bottom - num - 1), new Point(contentBounds.Right, contentRecentItemsCaptionBounds.Bottom - num - 1));
			}
			contentRecentItemsCaptionBounds.X += e.Ribbon.ItemMargin.Left;
			contentRecentItemsCaptionBounds.Width -= e.Ribbon.ItemMargin.Left + e.Ribbon.ItemMargin.Right;
			contentRecentItemsCaptionBounds.Height -= e.RibbonOrbDropDown.RecentItemsCaptionLineSpacing;
			StringFormat stringFormat = new StringFormat
			{
				LineAlignment = StringAlignment.Center
			};
			if (e.Ribbon.RightToLeft == RightToLeft.Yes)
			{
				stringFormat.Alignment = StringAlignment.Far;
			}
			else
			{
				stringFormat.Alignment = StringAlignment.Near;
			}
			e.Graphics.DrawString(e.RibbonOrbDropDown.RecentItemsCaption, new Font(e.Ribbon.RibbonTabFont.FontFamily, e.Ribbon.RibbonTabFont.Size, FontStyle.Bold), Brushes.DarkBlue, contentRecentItemsCaptionBounds, stringFormat);
		}
		using (SolidBrush brush4 = new SolidBrush(orbDropDownContentbglight))
		{
			e.Graphics.FillRectangle(brush4, contentButtonsBounds);
		}
		using (Pen pen5 = new Pen(orbDropDownSeparatorlight))
		{
			e.Graphics.DrawLine(pen5, contentButtonsBounds.Right, contentButtonsBounds.Top, contentButtonsBounds.Right, contentButtonsBounds.Bottom);
		}
		using (Pen pen6 = new Pen(orbDropDownSeparatordark))
		{
			e.Graphics.DrawLine(pen6, contentButtonsBounds.Right - 1, contentButtonsBounds.Top, contentButtonsBounds.Right - 1, contentButtonsBounds.Bottom);
		}
		using (Pen pen7 = new Pen(orbDropDownLightBorder))
		{
			e.Graphics.DrawRectangle(pen7, r);
		}
		using (Pen pen8 = new Pen(orbDropDownDarkBorder))
		{
			e.Graphics.DrawRectangle(pen8, r2);
		}
		if (e.Ribbon.OrbVisible && e.Ribbon.CaptionBarVisible && e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			Rectangle r6 = e.Ribbon.RectangleToScreen(e.Ribbon.OrbBounds);
			r6 = e.RibbonOrbDropDown.RectangleToClient(r6);
			DrawOrb(e.Graphics, r6, e.Ribbon.OrbImage, e.Ribbon.OrbSelected, e.Ribbon.OrbPressed);
		}
	}

	public override void OnRenderRibbonQuickAccessToolbarBackground(RibbonRenderEventArgs e)
	{
		Rectangle bounds = e.Ribbon.QuickAccessToolbar.Bounds;
		Padding padding = e.Ribbon.QuickAccessToolbar.Padding;
		Padding margin = e.Ribbon.QuickAccessToolbar.Margin;
		Point point = new Point(bounds.Left - (e.Ribbon.OrbVisible ? margin.Left : 0), bounds.Top);
		Point point2 = new Point(bounds.Right + padding.Right, bounds.Top);
		Point point3 = new Point(bounds.Left, bounds.Bottom);
		Point point4 = new Point(point2.X, point3.Y);
		Point e2 = new Point(point3.X - 2, point.Y + bounds.Height / 2 - 1);
		bool flag = e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass && RibbonDesigner.Current == null;
		if (e.Ribbon.RightToLeft == RightToLeft.Yes)
		{
			point = new Point(bounds.Left + padding.Left, bounds.Top);
			point2 = new Point(bounds.Right + (e.Ribbon.OrbVisible ? margin.Right : 0), bounds.Top);
			point3 = new Point(point.X, bounds.Bottom);
			point4 = new Point(bounds.Right, bounds.Bottom);
			e2 = new Point(point4.X + 2, point2.Y + bounds.Height / 2 - 1);
		}
		using GraphicsPath path = CreateQuickAccessPath(point, point2, point3, point4, e2, bounds, 0, 0, e.Ribbon);
		if (!flag)
		{
			using Pen pen = new Pen(ColorTable.QuickAccessBorderLight, 3f);
			e.Graphics.DrawPath(pen, path);
		}
		using (Pen pen2 = new Pen(ColorTable.QuickAccessBorderDark, 1f))
		{
			if (flag)
			{
				pen2.Color = Color.FromArgb(150, 150, 150);
			}
			e.Graphics.DrawPath(pen2, path);
		}
		if (e.Ribbon.RightToLeft == RightToLeft.Yes)
		{
			point2 = point;
			point4 = point3;
		}
		if (!flag)
		{
			using (LinearGradientBrush brush = new LinearGradientBrush(point2, point4, Color.FromArgb(150, ColorTable.QuickAccessUpper), Color.FromArgb(150, ColorTable.QuickAccessLower)))
			{
				e.Graphics.FillPath(brush, path);
				return;
			}
		}
		using LinearGradientBrush brush2 = new LinearGradientBrush(point2, point4, Color.FromArgb(66, RibbonProfesionalRendererColorTable.ToGray(ColorTable.QuickAccessUpper)), Color.FromArgb(66, RibbonProfesionalRendererColorTable.ToGray(ColorTable.QuickAccessLower)));
		e.Graphics.FillPath(brush2, path);
	}

	private string FormatText(string text, string altKey, bool altPressed)
	{
		if (altPressed && !string.IsNullOrEmpty(altKey) && text.Contains(altKey))
		{
			return new Regex(Regex.Escape(altKey), RegexOptions.IgnoreCase).Replace(text.Replace("&", ""), "&" + altKey, 1).Replace("&&", "&");
		}
		return text;
	}

	public override void OnRenderRibbonOrb(RibbonRenderEventArgs e)
	{
		if (!e.Ribbon.OrbVisible)
		{
			return;
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			if (e.Ribbon.CaptionBarVisible)
			{
				DrawOrb(e.Graphics, e.Ribbon.OrbBounds, e.Ribbon.OrbImage, e.Ribbon.OrbSelected, e.Ribbon.OrbPressed);
			}
		}
		else
		{
			if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
			{
				return;
			}
			RibbonRenderEventArgs e2 = new RibbonRenderEventArgs(e.Ribbon, e.Graphics, e.Ribbon.OrbBounds);
			if (e.Ribbon.OrbPressed)
			{
				DrawOrbPressed(e2);
			}
			else if (e.Ribbon.OrbSelected)
			{
				DrawOrbSelected(e2);
			}
			else
			{
				DrawOrbNormal(e2);
			}
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				if (e.Ribbon.OrbText != string.Empty)
				{
					using StringFormat format = StringFormatFactory.CenterNoWrapTrimEllipsis();
					using Brush brush = new SolidBrush(ColorTable.OrbButtonText);
					e.Graphics.DrawString(FormatText(e.Ribbon.OrbText, e.Ribbon.AltKey, e.Ribbon.AltPressed), e.Ribbon.RibbonTabFont, brush, e.Ribbon.OrbBounds, format);
				}
			}
			else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013 && e.Ribbon.OrbText != string.Empty)
			{
				using StringFormat format2 = StringFormatFactory.CenterNoWrapTrimEllipsis();
				using Brush brush2 = new SolidBrush(ColorTable.OrbButtonText_2013);
				e.Graphics.DrawString(FormatText(e.Ribbon.OrbText, e.Ribbon.AltKey, e.Ribbon.AltPressed), e.Ribbon.RibbonTabFont, brush2, e.Ribbon.OrbBounds, format2);
			}
			if (e.Ribbon.OrbImage != null)
			{
				Rectangle rect = new Rectangle(Point.Empty, e.Ribbon.OrbImage.Size);
				rect.X = e.Ribbon.OrbBounds.X + (e.Ribbon.OrbBounds.Width - rect.Width) / 2;
				rect.Y = e.Ribbon.OrbBounds.Y + (e.Ribbon.OrbBounds.Height - rect.Height) / 2;
				e.Graphics.DrawImage(e.Ribbon.OrbImage, rect);
			}
		}
	}

	public override void OnRenderRibbonBackground(RibbonRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			e.Graphics.Clear(ColorTable.RibbonBackground);
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass && !e.Ribbon.IsDesignMode())
			{
				WinApi.FillForGlass(e.Graphics, new Rectangle(0, 0, e.Ribbon.Width, e.Ribbon.CaptionBarSize + 1));
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			e.Graphics.Clear(ColorTable.RibbonBackground);
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				WinApi.FillForGlass(e.Graphics, new Rectangle(0, 0, e.Ribbon.Width, e.Ribbon.CaptionBarSize + e.Ribbon.TabsMargin.Top));
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			e.Graphics.Clear(ColorTable.RibbonBackground_2013);
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				WinApi.FillForGlass(e.Graphics, new Rectangle(0, 0, e.Ribbon.Width, e.Ribbon.CaptionBarSize + e.Ribbon.TabsMargin.Top));
			}
		}
	}

	public override void OnRenderRibbonTab(RibbonTabRenderEventArgs e)
	{
		if (e.Ribbon.Minimized && !e.Ribbon.Expanded)
		{
			DrawTabMinimized(e);
		}
		else if (e.Tab.Active)
		{
			DrawTabNormal(e);
			DrawTabActive(e);
			DrawCompleteTab(e);
			if (e.Tab.Selected && !e.Tab.Invisible)
			{
				DrawTabActiveSelected(e);
			}
		}
		else if (!e.Tab.Pressed)
		{
			if (e.Tab.Selected)
			{
				DrawTabNormal(e);
				DrawTabSelected(e);
			}
			else
			{
				DrawTabNormal(e);
			}
		}
	}

	public override void OnRenderRibbonContext(RibbonContextRenderEventArgs e)
	{
		DrawContextNormal(e);
	}

	private void DrawContextNormal(RibbonContextRenderEventArgs e)
	{
		RectangleF clipBounds = e.Graphics.ClipBounds;
		Rectangle clip = Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top, e.Context.Bounds.Right, e.Context.Bounds.Bottom);
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top + 13, e.Context.Bounds.Right, e.Context.Bounds.Bottom);
		}
		else
		{
			Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top, e.Context.Bounds.Right, e.Context.Bounds.Bottom);
		}
		Rectangle rect = ((e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended) ? Rectangle.FromLTRB(e.Context.HeaderBounds.Left, e.Context.HeaderBounds.Top, e.Context.HeaderBounds.Right, e.Context.HeaderBounds.Bottom) : Rectangle.FromLTRB(e.Context.HeaderBounds.Left, e.Context.HeaderBounds.Top + 13, e.Context.HeaderBounds.Right, e.Context.HeaderBounds.Bottom));
		Rectangle rect2 = ((e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended) ? Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top, e.Context.Bounds.Right, e.Context.Bounds.Top + 5) : Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top + 13, e.Context.Bounds.Right, e.Context.Bounds.Top + 5));
		e.Graphics.SetClip(clip);
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			Color color = Color.FromArgb(200, DarkenColor(e.Context.GlowColor, 0.3f));
			Color color2 = Color.FromArgb(120, DarkenColor(e.Context.GlowColor, 0.2f));
			Color color3 = Color.FromArgb(40, DarkenColor(e.Context.GlowColor, 0f));
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color, color3, 90f))
			{
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3] { color, color2, color3 };
				colorBlend.Positions = new float[3] { 0f, 0.3f, 1f };
				ColorBlend interpolationColors = colorBlend;
				linearGradientBrush.InterpolationColors = interpolationColors;
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillRectangle(linearGradientBrush, rect);
				e.Graphics.SmoothingMode = smoothingMode;
			}
			using Brush brush = new SolidBrush(e.Context.GlowColor);
			SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.FillRectangle(brush, rect2);
			e.Graphics.SmoothingMode = smoothingMode2;
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			Color color4;
			Color color5;
			Color color6;
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010)
			{
				color4 = Color.FromArgb(200, DarkenColor(e.Context.GlowColor, 0.3f));
				color5 = Color.FromArgb(120, DarkenColor(e.Context.GlowColor, 0.2f));
				color6 = Color.FromArgb(40, DarkenColor(e.Context.GlowColor, 0f));
			}
			else
			{
				color4 = Color.FromArgb(200, DarkenColor(e.Context.GlowColor, 0.1f));
				color5 = color4;
				color6 = color4;
			}
			using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect, color4, color6, 90f))
			{
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3] { color4, color5, color6 };
				colorBlend.Positions = new float[3] { 0f, 0.3f, 1f };
				ColorBlend interpolationColors2 = colorBlend;
				linearGradientBrush2.InterpolationColors = interpolationColors2;
				SmoothingMode smoothingMode3 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillRectangle(linearGradientBrush2, rect);
				e.Graphics.SmoothingMode = smoothingMode3;
			}
			using Brush brush2 = new SolidBrush(e.Context.GlowColor);
			SmoothingMode smoothingMode4 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.FillRectangle(brush2, rect2);
			e.Graphics.SmoothingMode = smoothingMode4;
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			Color color7 = Color.FromArgb(200, DarkenColor(e.Context.GlowColor, 0.3f));
			Color color8 = Color.FromArgb(120, DarkenColor(e.Context.GlowColor, 0.2f));
			Color color9 = Color.FromArgb(40, DarkenColor(e.Context.GlowColor, 0f));
			using (LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(rect, color7, color9, 90f))
			{
				ColorBlend colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[3] { color7, color8, color9 };
				colorBlend.Positions = new float[3] { 0f, 0.3f, 1f };
				ColorBlend interpolationColors3 = colorBlend;
				linearGradientBrush3.InterpolationColors = interpolationColors3;
				SmoothingMode smoothingMode5 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.FillRectangle(linearGradientBrush3, rect);
				e.Graphics.SmoothingMode = smoothingMode5;
			}
			using Brush brush3 = new SolidBrush(e.Context.GlowColor);
			SmoothingMode smoothingMode6 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.FillRectangle(brush3, rect2);
			e.Graphics.SmoothingMode = smoothingMode6;
		}
		e.Graphics.SetClip(clipBounds);
	}

	public override void OnRenderRibbonContextText(RibbonContextRenderEventArgs e)
	{
		StringFormat stringFormat = StringFormatFactory.CenterNoWrapTrimEllipsis();
		stringFormat.LineAlignment = StringAlignment.Near;
		Rectangle rectangle = ((e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended) ? Rectangle.FromLTRB(e.Context.Bounds.Left + e.Ribbon.TabTextMargin.Left, e.Context.Bounds.Top + e.Ribbon.TabTextMargin.Top + 3, e.Context.Bounds.Right - e.Ribbon.TabTextMargin.Right, e.Context.Bounds.Bottom - e.Ribbon.TabTextMargin.Bottom) : Rectangle.FromLTRB(e.Context.Bounds.Left + e.Ribbon.TabTextMargin.Left, e.Context.Bounds.Top + e.Ribbon.TabTextMargin.Top + 9, e.Context.Bounds.Right - e.Ribbon.TabTextMargin.Right, e.Context.Bounds.Bottom - e.Ribbon.TabTextMargin.Bottom));
		Rectangle rectangle2 = rectangle;
		rectangle2.Offset(0, 1);
		string text = e.Context.Text;
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended)
		{
			using Brush brush = new SolidBrush(GetTextColor(enabled: true, DarkenColor(e.Context.GlowColor, 0.5f)));
			if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				float emSize = e.Graphics.DpiY * e.Ribbon.RibbonTabFont.Size / 72f;
				graphicsPath.AddString(text, e.Ribbon.RibbonTabFont.FontFamily, 1, emSize, rectangle2, stringFormat);
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.FillPath(brush, graphicsPath);
				e.Graphics.SmoothingMode = smoothingMode;
			}
			else
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				Font font = new Font(e.Ribbon.RibbonTabFont, FontStyle.Bold);
				e.Graphics.DrawString(text, font, brush, rectangle2, stringFormat);
			}
		}
		using Brush brush2 = new SolidBrush(GetTextColor(enabled: true, Color.White));
		if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddString(emSize: (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended) ? (e.Graphics.DpiY * e.Ribbon.RibbonTabFont.Size / 72f) : (e.Graphics.DpiY * e.Ribbon.RibbonTabFont.Size / 96f), s: text, family: e.Ribbon.RibbonTabFont.FontFamily, style: 1, layoutRect: rectangle, format: stringFormat);
			SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.FillPath(brush2, graphicsPath2);
			e.Graphics.SmoothingMode = smoothingMode2;
		}
		else
		{
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			Font font2 = new Font(e.Ribbon.RibbonTabFont, FontStyle.Bold);
			e.Graphics.DrawString(text, font2, brush2, rectangle, stringFormat);
		}
	}

	public override void OnRenderRibbonTabText(RibbonTabRenderEventArgs e)
	{
		StringFormat stringFormat = StringFormatFactory.CenterNoWrapTrimEllipsis();
		if (e.Ribbon.AltPressed)
		{
			stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
		}
		else
		{
			stringFormat.HotkeyPrefix = HotkeyPrefix.Hide;
		}
		Rectangle rectangle = Rectangle.FromLTRB(e.Tab.TabBounds.Left + e.Ribbon.TabTextMargin.Left, e.Tab.TabBounds.Top + e.Ribbon.TabTextMargin.Top, e.Tab.TabBounds.Right - e.Ribbon.TabTextMargin.Right, e.Tab.TabBounds.Bottom - e.Ribbon.TabTextMargin.Bottom);
		string text = e.Tab.Text;
		text = FormatText(text, e.Tab.AltKey, e.Ribbon.AltPressed);
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (Brush brush = new SolidBrush(GetTextColor(e.Tab.Enabled, e.Tab.Active ? ColorTable.TabActiveText : ColorTable.TabText)))
			{
				if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
				{
					GraphicsPath graphicsPath = new GraphicsPath();
					float emSize = e.Graphics.DpiY * e.Ribbon.RibbonTabFont.Size / 72f;
					graphicsPath.AddString(text, e.Ribbon.RibbonTabFont.FontFamily, 0, emSize, rectangle, stringFormat);
					SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
					e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
					e.Graphics.FillPath(brush, graphicsPath);
					e.Graphics.SmoothingMode = smoothingMode;
				}
				else
				{
					e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
					e.Graphics.DrawString(text, e.Ribbon.RibbonTabFont, brush, rectangle, stringFormat);
				}
				return;
			}
		}
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using Brush brush2 = new SolidBrush(GetTextColor(e.Tab.Enabled, (e.Tab.Active || e.Tab.Selected) ? ColorTable.TabText_2013 : ColorTable.TabTextSelected_2013));
		if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			float emSize2 = e.Graphics.DpiY * e.Ribbon.RibbonTabFont.Size / 72f;
			graphicsPath2.AddString(text, e.Ribbon.RibbonTabFont.FontFamily, 0, emSize2, rectangle, stringFormat);
			SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.FillPath(brush2, graphicsPath2);
			e.Graphics.SmoothingMode = smoothingMode2;
		}
		else
		{
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			e.Graphics.DrawString(text, e.Ribbon.RibbonTabFont, brush2, rectangle, stringFormat);
		}
	}

	public override void OnRenderRibbonPanelBackground(RibbonPanelRenderEventArgs e)
	{
		if (e.Panel.OverflowMode && !(e.Canvas is RibbonPanelPopup))
		{
			if (e.Panel.Pressed)
			{
				DrawPanelOverflowPressed(e);
			}
			else if (e.Panel.Selected)
			{
				DrawPanelOverflowSelected(e);
			}
			else
			{
				DrawPanelOverflowNormal(e);
			}
		}
		else if (e.Panel.Selected && (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended))
		{
			DrawPanelSelected(e);
		}
		else
		{
			DrawPanelNormal(e);
		}
	}

	public override void OnRenderRibbonPanelText(RibbonPanelRenderEventArgs e)
	{
		if (e.Panel.OverflowMode && !(e.Canvas is RibbonPanelPopup))
		{
			return;
		}
		Rectangle rectangle = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (StringFormat format = StringFormatFactory.Center())
			{
				using Brush brush = new SolidBrush(GetTextColor(e.Panel.Enabled, ColorTable.PanelText));
				e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, brush, rectangle, format);
				return;
			}
		}
		if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
		{
			return;
		}
		using StringFormat format2 = StringFormatFactory.Center();
		using Brush brush2 = new SolidBrush(GetTextColor(e.Panel.Enabled, ColorTable.PanelText_2013));
		e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, brush2, rectangle, format2);
	}

	public override void OnRenderRibbonItem(RibbonItemRenderEventArgs e)
	{
		if (e.Item is RibbonButton)
		{
			RibbonButton ribbonButton = e.Item as RibbonButton;
			if (ribbonButton.Enabled)
			{
				if (ribbonButton.Style == RibbonButtonStyle.Normal)
				{
					if (ribbonButton.SizeMode == RibbonElementSizeMode.DropDown)
					{
						if (ribbonButton.Selected)
						{
							DrawButtonSelected(e.Graphics, ribbonButton, e.Ribbon);
						}
					}
					else if (ribbonButton.Pressed)
					{
						DrawButtonPressed(e.Graphics, ribbonButton, e.Ribbon);
					}
					else if (ribbonButton.Selected && ribbonButton.Checked)
					{
						DrawButtonCheckedSelected(e.Graphics, ribbonButton, e.Ribbon);
					}
					else if (ribbonButton.Selected && !ribbonButton.Checked)
					{
						DrawButtonSelected(e.Graphics, ribbonButton, e.Ribbon);
					}
					else if (ribbonButton.Checked)
					{
						DrawButtonChecked(e.Graphics, ribbonButton, e.Ribbon);
					}
					else if (ribbonButton is RibbonOrbOptionButton)
					{
						DrawOrbOptionButton(e.Graphics, ribbonButton.Bounds);
					}
				}
				else
				{
					if (ribbonButton.Style == RibbonButtonStyle.DropDownListItem)
					{
						using SolidBrush brush = new SolidBrush(ColorTable.DropDownBg);
						SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
						e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
						e.Graphics.FillRectangle(brush, ribbonButton.Bounds);
						e.Graphics.SmoothingMode = smoothingMode;
					}
					if (ribbonButton.DropDownPressed && ribbonButton.SizeMode != RibbonElementSizeMode.DropDown)
					{
						DrawButtonPressed(e.Graphics, ribbonButton, e.Ribbon);
						DrawSplitButtonDropDownSelected(e, ribbonButton);
					}
					else if (ribbonButton.Pressed && ribbonButton.SizeMode != RibbonElementSizeMode.DropDown)
					{
						DrawButtonPressed(e.Graphics, ribbonButton, e.Ribbon);
						DrawSplitButtonSelected(e, ribbonButton);
					}
					else if (ribbonButton.DropDownSelected)
					{
						DrawButtonSelected(e.Graphics, ribbonButton, e.Ribbon);
						DrawSplitButtonDropDownSelected(e, ribbonButton);
					}
					else if (ribbonButton.Selected)
					{
						DrawButtonSelected(e.Graphics, ribbonButton, e.Ribbon);
						DrawSplitButtonSelected(e, ribbonButton);
					}
					else if (ribbonButton.Checked)
					{
						DrawButtonChecked(e.Graphics, ribbonButton, e.Ribbon);
					}
					else
					{
						DrawSplitButton(e, ribbonButton);
					}
				}
			}
			if (ribbonButton.Style != RibbonButtonStyle.Normal && (ribbonButton.Style != RibbonButtonStyle.DropDown || ribbonButton.SizeMode != RibbonElementSizeMode.Large))
			{
				if (ribbonButton.Style == RibbonButtonStyle.DropDown)
				{
					DrawButtonDropDownArrow(e.Graphics, ribbonButton, ribbonButton.OnGetDropDownBounds(ribbonButton.SizeMode, ribbonButton.Bounds));
				}
				else
				{
					DrawButtonDropDownArrow(e.Graphics, ribbonButton, ribbonButton.DropDownBounds);
				}
			}
		}
		else if (e.Item is RibbonItemGroup)
		{
			DrawItemGroup(e, e.Item as RibbonItemGroup);
		}
		else if (e.Item is RibbonButtonList)
		{
			DrawButtonList(e.Graphics, e.Item as RibbonButtonList, e.Ribbon);
		}
		else if (e.Item is RibbonSeparator)
		{
			if (e.Item.Visible)
			{
				DrawSeparator(e.Graphics, e.Item as RibbonSeparator, e.Ribbon);
			}
		}
		else if (e.Item is RibbonUpDown)
		{
			RibbonUpDown ribbonUpDown = e.Item as RibbonUpDown;
			if (ribbonUpDown.Enabled)
			{
				if (ribbonUpDown != null && (ribbonUpDown.Selected || ribbonUpDown.Editing))
				{
					DrawTextBoxSelected(e.Graphics, ribbonUpDown.TextBoxBounds);
				}
				else
				{
					DrawTextBoxUnselected(e.Graphics, ribbonUpDown.TextBoxBounds);
				}
			}
			else
			{
				DrawTextBoxDisabled(e.Graphics, ribbonUpDown.TextBoxBounds);
			}
			DrawUpDownButtons(e.Graphics, ribbonUpDown, e.Ribbon);
		}
		else if (e.Item is RibbonComboBox)
		{
			RibbonComboBox ribbonComboBox = e.Item as RibbonComboBox;
			if (ribbonComboBox.Enabled)
			{
				if (ribbonComboBox != null && (ribbonComboBox.Selected || ribbonComboBox.DropDownVisible || ribbonComboBox.Editing))
				{
					DrawTextBoxSelected(e.Graphics, ribbonComboBox.TextBoxBounds);
				}
				else
				{
					DrawTextBoxUnselected(e.Graphics, ribbonComboBox.TextBoxBounds);
				}
			}
			else
			{
				DrawTextBoxDisabled(e.Graphics, ribbonComboBox.TextBoxBounds);
			}
			DrawComboBoxDropDown(e.Graphics, ribbonComboBox, e.Ribbon);
		}
		else
		{
			if (!(e.Item is RibbonTextBox))
			{
				return;
			}
			RibbonTextBox ribbonTextBox = e.Item as RibbonTextBox;
			if (ribbonTextBox.Enabled)
			{
				if (ribbonTextBox != null && (ribbonTextBox.Selected || ribbonTextBox.Editing))
				{
					DrawTextBoxSelected(e.Graphics, ribbonTextBox.TextBoxBounds);
				}
				else
				{
					DrawTextBoxUnselected(e.Graphics, ribbonTextBox.TextBoxBounds);
				}
			}
			else
			{
				DrawTextBoxDisabled(e.Graphics, ribbonTextBox.TextBoxBounds);
			}
		}
	}

	public override void OnRenderRibbonItemBorder(RibbonItemRenderEventArgs e)
	{
		if (e.Item is RibbonItemGroup)
		{
			DrawItemGroupBorder(e, e.Item as RibbonItemGroup);
		}
	}

	public override void OnRenderRibbonItemText(RibbonTextEventArgs e)
	{
		Color color = e.Color;
		StringFormat format = e.Format;
		Font font = e.Ribbon.Font;
		bool flag = false;
		if (e.Item is RibbonButton)
		{
			RibbonButton ribbonButton = e.Item as RibbonButton;
			if (ribbonButton is RibbonCaptionButton)
			{
				if (WinApi.IsWindows)
				{
					font = new Font("Marlett", font.Size);
				}
				flag = true;
				color = ColorTable.Arrow;
			}
			if (ribbonButton.Style == RibbonButtonStyle.DropDown && ribbonButton.SizeMode == RibbonElementSizeMode.Large)
			{
				DrawButtonDropDownArrow(e.Graphics, ribbonButton, e.Bounds);
			}
		}
		else if (e.Item is RibbonSeparator)
		{
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				color = GetTextColor(e.Item.Enabled, ColorTable.Text);
			}
			else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
			{
				color = GetTextColor(e.Item.Enabled, ColorTable.RibbonItemText_2013);
			}
		}
		if (flag || !e.Item.Enabled)
		{
			Rectangle bounds = e.Bounds;
			bounds.Y++;
			using SolidBrush brush = new SolidBrush(ColorTable.ArrowLight);
			e.Graphics.DrawString(e.Text, new Font(font, e.Style), brush, bounds, format);
		}
		if (color.Equals(Color.Empty))
		{
			if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				color = GetTextColor(e.Item.Enabled, ColorTable.Text);
			}
			else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
			{
				color = GetTextColor(e.Item.Enabled, ColorTable.RibbonItemText_2013);
			}
		}
		using SolidBrush brush2 = new SolidBrush(color);
		e.Graphics.DrawString(e.Text, new Font(font, e.Style), brush2, e.Bounds, format);
	}

	public override void OnRenderRibbonItemImage(RibbonItemBoundsEventArgs e)
	{
		Image image = (e.Item.ShowFlashImage ? e.Item.FlashImage : e.Item.Image);
		if (e.Item is RibbonButton)
		{
			if (e.Item.SizeMode != RibbonElementSizeMode.Large && e.Item.SizeMode != RibbonElementSizeMode.Overflow)
			{
				image = (e.Item.ShowFlashImage ? (e.Item as RibbonButton).FlashSmallImage : (e.Item as RibbonButton).SmallImage);
			}
			if (e.Item.SizeMode == RibbonElementSizeMode.DropDown && e.Item.Checked)
			{
				using Pen pen = new Pen(ColorTable.DropDownCheckedButtonGlyphBorder);
				using SolidBrush brush = new SolidBrush(ColorTable.DropDownCheckedButtonGlyphBg);
				using (GraphicsPath path = RoundRectangle(Rectangle.FromLTRB(e.Bounds.Left - 2, e.Bounds.Top - 2, e.Bounds.Right + 1, e.Bounds.Bottom + 1), 3, Corners.All))
				{
					SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
					e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
					e.Graphics.DrawPath(pen, path);
					e.Graphics.FillPath(brush, path);
					e.Graphics.SmoothingMode = smoothingMode;
				}
				if (image != null)
				{
					Rectangle rectangle = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
					ControlPaint.DrawMenuGlyph(e.Graphics, rectangle, MenuGlyph.Checkmark, pen.Color, Color.Transparent);
				}
			}
		}
		if (image != null)
		{
			if (!e.Item.Enabled)
			{
				image = RibbonRenderer.CreateDisabledImage(image);
			}
			e.Graphics.DrawImage(image, e.Bounds);
		}
	}

	public override void OnRenderPanelPopupBackground(RibbonCanvasEventArgs e)
	{
		if (!(e.RelatedObject is RibbonPanel ribbonPanel))
		{
			return;
		}
		Rectangle r = Rectangle.FromLTRB(e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
		Rectangle r2 = Rectangle.FromLTRB(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
		Rectangle r3 = Rectangle.FromLTRB(e.Bounds.Left + 1, ribbonPanel.ContentBounds.Bottom, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
		GraphicsPath graphicsPath = RoundRectangle(r, 3);
		GraphicsPath graphicsPath2 = RoundRectangle(r2, 3);
		GraphicsPath graphicsPath3 = RoundRectangle(r3, 3, Corners.South);
		using (Pen pen = new Pen(ColorTable.PanelLightBorder))
		{
			e.Graphics.DrawPath(pen, graphicsPath2);
		}
		using (Pen pen2 = new Pen(ColorTable.PanelDarkBorder))
		{
			e.Graphics.DrawPath(pen2, graphicsPath);
		}
		using (SolidBrush brush = new SolidBrush(ColorTable.PanelBackgroundSelected))
		{
			e.Graphics.FillPath(brush, graphicsPath2);
		}
		if (_ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			using SolidBrush brush2 = new SolidBrush(ColorTable.PanelTextBackground);
			e.Graphics.FillPath(brush2, graphicsPath3);
		}
		graphicsPath3.Dispose();
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
	}

	public override void OnRenderDropDownBackground(RibbonCanvasEventArgs e)
	{
		Rectangle rect = new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1);
		RibbonDropDown ribbonDropDown = e.Canvas as RibbonDropDown;
		using (SolidBrush brush = new SolidBrush(ColorTable.DropDownBg))
		{
			e.Graphics.Clear(Color.Transparent);
			SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.FillRectangle(brush, rect);
			e.Graphics.SmoothingMode = smoothingMode;
		}
		using (Pen pen = new Pen(ColorTable.DropDownBorder))
		{
			if (ribbonDropDown != null)
			{
				using GraphicsPath path = RoundRectangle(new Rectangle(Point.Empty, new Size(ribbonDropDown.Size.Width - 1, ribbonDropDown.Size.Height - 1)), ribbonDropDown.BorderRoundness);
				SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.DrawPath(pen, path);
				e.Graphics.SmoothingMode = smoothingMode2;
			}
			else
			{
				e.Graphics.DrawRectangle(pen, rect);
			}
		}
		if (!ribbonDropDown.ShowSizingGrip)
		{
			return;
		}
		Rectangle rect2 = Rectangle.FromLTRB(e.Bounds.Left + 1, e.Bounds.Bottom - ribbonDropDown.SizingGripHeight, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
		if (rect2.Height > 0 && rect2.Width > 0)
		{
			using (LinearGradientBrush brush2 = new LinearGradientBrush(rect2, ColorTable.DropDownGripNorth, ColorTable.DropDownGripSouth, 90f))
			{
				e.Graphics.FillRectangle(brush2, rect2);
			}
			using (Pen pen2 = new Pen(ColorTable.DropDownGripBorder))
			{
				e.Graphics.DrawLine(pen2, rect2.Location, new Point(rect2.Right - 1, rect2.Top));
			}
			DrawGripDot(e.Graphics, new Point(rect2.Right - 7, rect2.Bottom - 3));
			DrawGripDot(e.Graphics, new Point(rect2.Right - 3, rect2.Bottom - 7));
			DrawGripDot(e.Graphics, new Point(rect2.Right - 3, rect2.Bottom - 3));
		}
	}

	public override void OnRenderDropDownDropDownImageSeparator(RibbonItem item, RibbonCanvasEventArgs e)
	{
		if (!(e.Canvas is RibbonDropDown { DrawIconsBar: not false }))
		{
			return;
		}
		Rectangle rect = new Rectangle(item.Bounds.Left, item.Bounds.Top, 26, item.Bounds.Height);
		using (new Pen(ColorTable.DropDownImageBg))
		{
			using SolidBrush brush = new SolidBrush(ColorTable.DropDownImageBg);
			SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.FillRectangle(brush, rect);
			e.Graphics.SmoothingMode = smoothingMode;
		}
		using Pen pen = new Pen(ColorTable.DropDownImageSeparator);
		SmoothingMode smoothingMode2 = e.Graphics.SmoothingMode;
		e.Graphics.SmoothingMode = SmoothingMode.None;
		e.Graphics.DrawLine(pen, new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom - 1));
		e.Graphics.SmoothingMode = smoothingMode2;
	}

	public override void OnRenderTabScrollButtons(RibbonTabRenderEventArgs e)
	{
		if (e.Tab.ScrollLeftVisible)
		{
			if (e.Tab.ScrollLeftSelected)
			{
				DrawButtonSelected(e.Graphics, e.Tab.ScrollLeftBounds, Corners.West, e.Ribbon);
			}
			else
			{
				DrawButton(e.Graphics, e.Tab.ScrollLeftBounds, Corners.West);
			}
			DrawArrowShaded(e.Graphics, e.Tab.ScrollLeftBounds, RibbonArrowDirection.Right, enabled: true);
		}
		if (e.Tab.ScrollRightVisible)
		{
			if (e.Tab.ScrollRightSelected)
			{
				DrawButtonSelected(e.Graphics, e.Tab.ScrollRightBounds, Corners.East, e.Ribbon);
			}
			else
			{
				DrawButton(e.Graphics, e.Tab.ScrollRightBounds, Corners.East);
			}
			DrawArrowShaded(e.Graphics, e.Tab.ScrollRightBounds, RibbonArrowDirection.Left, enabled: true);
		}
	}

	public override void OnRenderScrollbar(Graphics g, Control ctl, Ribbon ribbon)
	{
		RibbonDropDown ribbonDropDown = (RibbonDropDown)ctl;
		if (ScrollBarRenderer.IsSupported)
		{
			ScrollBarRenderer.DrawUpperVerticalTrack(g, ribbonDropDown.ScrollBarBounds, ScrollBarState.Normal);
			if (ribbonDropDown.ThumbPressed)
			{
				ScrollBarRenderer.DrawVerticalThumb(g, ribbonDropDown.ThumbBounds, ScrollBarState.Pressed);
				ScrollBarRenderer.DrawVerticalThumbGrip(g, ribbonDropDown.ThumbBounds, ScrollBarState.Pressed);
			}
			else if (ribbonDropDown.ThumbSelected)
			{
				ScrollBarRenderer.DrawVerticalThumb(g, ribbonDropDown.ThumbBounds, ScrollBarState.Hot);
				ScrollBarRenderer.DrawVerticalThumbGrip(g, ribbonDropDown.ThumbBounds, ScrollBarState.Hot);
			}
			else
			{
				ScrollBarRenderer.DrawVerticalThumb(g, ribbonDropDown.ThumbBounds, ScrollBarState.Normal);
				ScrollBarRenderer.DrawVerticalThumbGrip(g, ribbonDropDown.ThumbBounds, ScrollBarState.Normal);
			}
			if (ribbonDropDown.ButtonUpPressed)
			{
				ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonUpBounds, ScrollBarArrowButtonState.UpPressed);
			}
			else if (ribbonDropDown.ButtonUpSelected)
			{
				ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonUpBounds, ScrollBarArrowButtonState.UpHot);
			}
			else
			{
				ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonUpBounds, ScrollBarArrowButtonState.UpNormal);
			}
			if (ribbonDropDown.ButtonDownPressed)
			{
				ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonDownBounds, ScrollBarArrowButtonState.DownPressed);
			}
			else if (ribbonDropDown.ButtonDownSelected)
			{
				ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonDownBounds, ScrollBarArrowButtonState.DownHot);
			}
			else
			{
				ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonDownBounds, ScrollBarArrowButtonState.DownNormal);
			}
			return;
		}
		using (SolidBrush brush = new SolidBrush(ColorTable.ButtonGlossyNorth))
		{
			g.FillRectangle(brush, ribbonDropDown.ScrollBarBounds);
		}
		if (!ribbonDropDown.ButtonDownEnabled)
		{
			DrawButtonDisabled(g, ribbonDropDown.ButtonDownBounds, Corners.SouthEast);
		}
		else if (ribbonDropDown.ButtonDownPressed)
		{
			DrawButtonPressed(g, ribbonDropDown.ButtonDownBounds, Corners.SouthEast, ribbon);
		}
		else if (ribbonDropDown.ButtonDownSelected)
		{
			DrawButtonSelected(g, ribbonDropDown.ButtonDownBounds, Corners.SouthEast, ribbon);
		}
		else
		{
			DrawButton(g, ribbonDropDown.ButtonDownBounds, Corners.None);
		}
		if (!ribbonDropDown.ButtonUpEnabled)
		{
			DrawButtonDisabled(g, ribbonDropDown.ButtonUpBounds, Corners.NorthEast);
		}
		else if (ribbonDropDown.ButtonUpPressed)
		{
			DrawButtonPressed(g, ribbonDropDown.ButtonUpBounds, Corners.NorthEast, ribbon);
		}
		else if (ribbonDropDown.ButtonUpSelected)
		{
			DrawButtonSelected(g, ribbonDropDown.ButtonUpBounds, Corners.NorthEast, ribbon);
		}
		else
		{
			DrawButton(g, ribbonDropDown.ButtonUpBounds, Corners.NorthEast);
		}
		if (ribbonDropDown.ScrollBarEnabled)
		{
			if (ribbonDropDown.ThumbPressed)
			{
				DrawButtonPressed(g, ribbonDropDown.ThumbBounds, Corners.All, ribbon);
			}
			else if (ribbonDropDown.ThumbSelected)
			{
				DrawButtonSelected(g, ribbonDropDown.ThumbBounds, Corners.All, ribbon);
			}
			else
			{
				DrawButton(g, ribbonDropDown.ThumbBounds, Corners.All);
			}
		}
		Color arrow = ColorTable.Arrow;
		Color arrowLight = ColorTable.ArrowLight;
		Color arrowDisabled = ColorTable.ArrowDisabled;
		Rectangle b = CenterOn(ribbonDropDown.ButtonUpBounds, new Rectangle(Point.Empty, arrowSize));
		b.Offset(0, 1);
		Rectangle b2 = CenterOn(ribbonDropDown.ButtonDownBounds, new Rectangle(Point.Empty, arrowSize));
		b2.Offset(0, 1);
		DrawArrow(g, b, ribbonDropDown.ButtonUpEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Up);
		b.Offset(0, -1);
		DrawArrow(g, b, ribbonDropDown.ButtonUpEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Up);
		DrawArrow(g, b2, ribbonDropDown.ButtonDownEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Down);
		b2.Offset(0, -1);
		DrawArrow(g, b2, ribbonDropDown.ButtonDownEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Down);
	}

	public override void OnRenderToolTipBackground(RibbonToolTipRenderEventArgs e)
	{
		Rectangle r = Rectangle.FromLTRB(e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1);
		Rectangle r2 = Rectangle.FromLTRB(e.ClipRectangle.Left + 1, e.ClipRectangle.Top + 1, e.ClipRectangle.Right - 2, e.ClipRectangle.Bottom - 1);
		GraphicsPath graphicsPath = RoundRectangle(r, 3);
		GraphicsPath graphicsPath2 = RoundRectangle(r2, 3);
		Rectangle clipRectangle = e.ClipRectangle;
		clipRectangle.Offset(2, 1);
		using (GraphicsPath path = RoundRectangle(clipRectangle, 3, Corners.All))
		{
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(path);
			pathGradientBrush.WrapMode = WrapMode.Clamp;
			ColorBlend colorBlend = new ColorBlend(3);
			colorBlend.Colors = new Color[3]
			{
				Color.Transparent,
				Color.FromArgb(50, Color.Black),
				Color.FromArgb(100, Color.Black)
			};
			colorBlend.Positions = new float[3] { 0f, 0.1f, 1f };
			ColorBlend interpolationColors = colorBlend;
			pathGradientBrush.InterpolationColors = interpolationColors;
			e.Graphics.FillPath(pathGradientBrush, path);
		}
		using (LinearGradientBrush brush = new LinearGradientBrush(e.ClipRectangle, ColorTable.ToolTipContentNorth, ColorTable.ToolTipContentSouth, 90f))
		{
			e.Graphics.FillPath(brush, graphicsPath);
		}
		using (Pen pen = new Pen(ColorTable.ToolTipLightBorder))
		{
			e.Graphics.DrawPath(pen, graphicsPath2);
		}
		using (Pen pen2 = new Pen(ColorTable.ToolTipDarkBorder))
		{
			e.Graphics.DrawPath(pen2, graphicsPath);
		}
		graphicsPath.Dispose();
		graphicsPath2.Dispose();
	}

	public override void OnRenderToolTipText(RibbonToolTipRenderEventArgs e)
	{
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
		{
			using (Brush brush = new SolidBrush(ColorTable.ToolTipText))
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				e.Graphics.DrawString(e.Text, e.Font, brush, e.ClipRectangle, e.Format);
				return;
			}
		}
		if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
		{
			using (Brush brush2 = new SolidBrush(ColorTable.ToolTipText_2013))
			{
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				e.Graphics.DrawString(e.Text, e.Font, brush2, e.ClipRectangle, e.Format);
			}
		}
	}

	public override void OnRenderToolTipImage(RibbonToolTipRenderEventArgs e)
	{
		e.Graphics.DrawImage(e.TipImage, e.ClipRectangle);
	}
}
