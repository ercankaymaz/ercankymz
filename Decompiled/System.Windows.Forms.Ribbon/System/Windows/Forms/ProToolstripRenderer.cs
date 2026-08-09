using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace System.Windows.Forms;

public class ProToolstripRenderer : ToolStripProfessionalRenderer
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

	public enum ButtonTextAlign
	{
		Left,
		Right,
		Up,
		Down,
		UpperLeft,
		UpperRight,
		BottomLeft,
		BottomRight,
		Center,
		MiddleLeft
	}

	private static Bitmap titleBarGripBmp;

	private static readonly string titleBarGripEnc = "Qk16AQAAAAAAADYAAAAoAAAAIwAAAAMAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAAuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5ANj+RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5ANj+RzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMANj+";

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
		graphicsPath.AddLine(r.Left, r.Bottom, r.Left, r.Top);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	private Corners ToolStripItemCorners(ToolStripItem item)
	{
		if (item.Owner == null)
		{
			return Corners.All;
		}
		_ = item.Owner;
		int num = item.Owner.Items.Count - 1;
		Corners corners = Corners.None;
		if (item.Owner.Items.IndexOf(item) == 0)
		{
			corners |= Corners.West;
		}
		if (item.Owner.Items.IndexOf(item) == num)
		{
			corners |= Corners.East;
		}
		return corners;
	}

	private void DrawTitleBar(Graphics g, Rectangle rect)
	{
		Image image = titleBarGripBmp;
		SolidBrush brush = new SolidBrush(Theme.Standard.RendererColorTable.RibbonBackground);
		g.FillRectangle(brush, rect);
		g.DrawImage(image, new Point(Convert.ToInt32(rect.X + (rect.Width / 2 - image.Width / 2)), rect.Y + 1));
	}

	protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
	{
		DrawTitleBar(e.Graphics, new Rectangle(0, 0, e.ToolStrip.Width, 7));
	}

	protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
	{
	}

	internal static Bitmap DeserializeFromBase64(string data)
	{
		return new Bitmap(new MemoryStream(Convert.FromBase64String(data)));
	}

	public ProToolstripRenderer(bool Gripper)
	{
		titleBarGripBmp = DeserializeFromBase64(titleBarGripEnc);
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		base.OnRenderToolStripBackground(e);
		try
		{
			if (Theme.Standard.Style == RibbonOrbStyle.Office_2013)
			{
				SolidBrush brush = new SolidBrush(Theme.Standard.RendererColorTable.RibbonBackground_2013);
				Rectangle rect = new Rectangle(0, e.ToolStrip.Height - 2, e.ToolStrip.Width, 1);
				e.Graphics.FillRectangle(brush, e.AffectedBounds);
				e.Graphics.FillRectangle(new SolidBrush(Theme.Standard.RendererColorTable.clrVerBG_Shadow), rect);
			}
			else
			{
				Rectangle rect2 = new Rectangle(0, e.ToolStrip.Height - 2, e.ToolStrip.Width, 1);
				SolidBrush brush2 = new SolidBrush(Theme.Standard.RendererColorTable.RibbonBackground);
				e.Graphics.FillRectangle(brush2, e.AffectedBounds);
				e.Graphics.FillRectangle(new SolidBrush(Theme.Standard.RendererColorTable.clrVerBG_Shadow), rect2);
			}
		}
		catch
		{
		}
	}

	protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
	{
		base.OnRenderMenuItemBackground(e);
		RenderBackground(e);
		DrawText(e, e.Graphics);
	}

	protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
	{
		base.OnRenderDropDownButtonBackground(e);
		RenderBackground(e);
		DrawText(e, e.Graphics);
	}

	protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
	{
		base.OnRenderButtonBackground(e);
		RenderBackground(e);
		DrawText(e, e.Graphics);
	}

	protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
	{
		base.OnRenderItemBackground(e);
		RenderBackground(e);
		DrawText(e, e.Graphics);
	}

	protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
	{
		base.OnRenderLabelBackground(e);
		RenderBackground(e);
		DrawText(e, e.Graphics);
	}

	private void RenderBackground(ToolStripItemRenderEventArgs e)
	{
		if (e.Item.Selected | ((ToolStripButton)e.Item).Checked)
		{
			RenderItemBackgroundSelected(e);
		}
		if (e.Item.Pressed)
		{
			RenderItemBackgroundPressed(e);
		}
		if (!e.Item.Selected & !e.Item.Pressed & !((ToolStripButton)e.Item).Checked)
		{
			RenderItemBackgroundDefault(e);
		}
	}

	private void RenderItemBackgroundSelected(ToolStripItemRenderEventArgs e)
	{
		if (e.Item.Bounds.Height <= 0 || e.Item.Bounds.Width <= 0)
		{
			return;
		}
		if (Theme.Standard.Style == RibbonOrbStyle.Office_2013)
		{
			Rectangle rect = new Rectangle(1, 1, e.Item.Width - 1, e.Item.Height - 1);
			Rectangle rect2 = new Rectangle(2, 2, e.Item.Width - 2, e.Item.Height - 2);
			using SolidBrush brush = new SolidBrush(Theme.Standard.RendererColorTable.ButtonSelected_2013);
			using (SolidBrush brush2 = new SolidBrush(Theme.Standard.RendererColorTable.ButtonBorderIn))
			{
				e.Graphics.FillRectangle(brush2, rect);
			}
			e.Graphics.FillRectangle(brush, rect2);
			return;
		}
		Rectangle rect3 = new Rectangle(1, 1, e.Item.Width - 1, e.Item.Height - 1);
		new Rectangle(2, 2, e.Item.Width - 2, e.Item.Height - 2);
		Rectangle rectangle = Rectangle.FromLTRB(1, 1, e.Item.Width - 2, e.Item.Height - 2);
		Rectangle rectangle2 = Rectangle.FromLTRB(1, 1, e.Item.Width - 2, 1 + Convert.ToInt32((double)e.Item.Bounds.Height * 0.36));
		using (SolidBrush brush3 = new SolidBrush(Theme.Standard.RendererColorTable.ButtonSelectedBgOut))
		{
			e.Graphics.FillRectangle(brush3, rect3);
		}
		using (Pen pen = new Pen(Theme.Standard.RendererColorTable.ButtonSelectedBorderOut))
		{
			e.Graphics.DrawRectangle(pen, rect3);
		}
		Rectangle rect4 = Rectangle.Round(rectangle);
		using (Pen pen2 = new Pen(Theme.Standard.RendererColorTable.ButtonSelectedBorderIn))
		{
			e.Graphics.DrawRectangle(pen2, rect4);
		}
		using (GraphicsPath graphicsPath = new GraphicsPath())
		{
			graphicsPath.AddEllipse(new Rectangle(1, 1, e.Item.Width, e.Item.Height * 2));
			graphicsPath.CloseFigure();
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.WrapMode = WrapMode.Clamp;
			pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(1 + e.Item.Width / 2), Convert.ToSingle(e.Item.Bounds.Height));
			pathGradientBrush.CenterColor = Theme.Standard.RendererColorTable.ButtonSelectedBgCenter;
			pathGradientBrush.SurroundColors = new Color[1] { Theme.Standard.RendererColorTable.ButtonSelectedBgOut };
			Blend blend = new Blend(3);
			blend.Factors = new float[3] { 0f, 0.8f, 0f };
			blend.Positions = new float[3] { 0f, 0.3f, 1f };
			Region clip = e.Graphics.Clip;
			Region region = new Region(rect3);
			region.Intersect(clip);
			e.Graphics.SetClip(region.GetBounds(e.Graphics));
			e.Graphics.FillPath(pathGradientBrush, graphicsPath);
			e.Graphics.Clip = clip;
		}
		using GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddRectangle(Rectangle.Round(rectangle2));
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle2, Theme.Standard.RendererColorTable.ButtonSelectedGlossyNorth, Theme.Standard.RendererColorTable.ButtonSelectedGlossySouth, 90f);
		linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
		e.Graphics.FillPath(linearGradientBrush, graphicsPath2);
	}

	private void RenderItemBackgroundPressed(ToolStripItemRenderEventArgs e)
	{
		if (Theme.Standard.Style == RibbonOrbStyle.Office_2013)
		{
			Rectangle rect = new Rectangle(1, 1, e.Item.Width - 1, e.Item.Height - 1);
			Rectangle rect2 = new Rectangle(2, 2, e.Item.Width - 2, e.Item.Height - 2);
			using SolidBrush brush = new SolidBrush(Theme.Standard.RendererColorTable.ButtonPressed_2013);
			using (SolidBrush brush2 = new SolidBrush(Theme.Standard.RendererColorTable.ButtonBorderOut))
			{
				e.Graphics.FillRectangle(brush2, rect);
			}
			e.Graphics.FillRectangle(brush, rect2);
			return;
		}
		Rectangle rect3 = new Rectangle(1, 1, e.Item.Width - 1, e.Item.Height - 1);
		new Rectangle(2, 2, e.Item.Width - 2, e.Item.Height - 2);
		Rectangle rectangle = Rectangle.FromLTRB(1, 1, e.Item.Width - 2, e.Item.Height - 2);
		Rectangle rectangle2 = Rectangle.FromLTRB(1, 1, e.Item.Width - 2, 1 + Convert.ToInt32((double)e.Item.Bounds.Height * 0.36));
		using (SolidBrush brush3 = new SolidBrush(Theme.Standard.RendererColorTable.ButtonPressedBgOut))
		{
			e.Graphics.FillRectangle(brush3, rect3);
		}
		using (Pen pen = new Pen(Theme.Standard.RendererColorTable.ButtonPressedBorderOut))
		{
			e.Graphics.DrawRectangle(pen, rect3);
		}
		Rectangle rect4 = Rectangle.Round(rectangle);
		using (Pen pen2 = new Pen(Theme.Standard.RendererColorTable.ButtonPressedBorderIn))
		{
			e.Graphics.DrawRectangle(pen2, rect4);
		}
		using (GraphicsPath graphicsPath = new GraphicsPath())
		{
			graphicsPath.AddEllipse(new Rectangle(1, 1, e.Item.Width, e.Item.Height * 2));
			graphicsPath.CloseFigure();
			using PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.WrapMode = WrapMode.Clamp;
			pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(1 + e.Item.Width / 2), Convert.ToSingle(e.Item.Bounds.Height));
			pathGradientBrush.CenterColor = Theme.Standard.RendererColorTable.ButtonPressedBgCenter;
			pathGradientBrush.SurroundColors = new Color[1] { Theme.Standard.RendererColorTable.ButtonPressedBgOut };
			Blend blend = new Blend(3);
			blend.Factors = new float[3] { 0f, 0.8f, 0f };
			blend.Positions = new float[3] { 0f, 0.3f, 1f };
			Region clip = e.Graphics.Clip;
			Region region = new Region(rect3);
			region.Intersect(clip);
			e.Graphics.SetClip(region.GetBounds(e.Graphics));
			e.Graphics.FillPath(pathGradientBrush, graphicsPath);
			e.Graphics.Clip = clip;
		}
		using GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddRectangle(Rectangle.Round(rectangle2));
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle2, Theme.Standard.RendererColorTable.ButtonPressedGlossyNorth, Theme.Standard.RendererColorTable.ButtonPressedGlossySouth, 90f);
		linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
		e.Graphics.FillPath(linearGradientBrush, graphicsPath2);
	}

	private void RenderItemBackgroundDefault(ToolStripItemRenderEventArgs e)
	{
		if (Theme.Standard.Style == RibbonOrbStyle.Office_2013)
		{
			Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
			using SolidBrush brush = new SolidBrush(Theme.Standard.RendererColorTable.RibbonBackground_2013);
			e.Graphics.FillRectangle(brush, rect);
			return;
		}
		Rectangle rect2 = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
		using SolidBrush brush2 = new SolidBrush(Theme.Standard.RendererColorTable.RibbonBackground);
		e.Graphics.FillRectangle(brush2, rect2);
	}

	private void DrawText(ToolStripItemRenderEventArgs e, Graphics graphics)
	{
		try
		{
			Font font = e.Item.Font;
			if (Theme.Standard.Style == RibbonOrbStyle.Office_2013)
			{
				if (e.Item.Text != string.Empty)
				{
					if (e.Item.Enabled)
					{
						if (e.Item is ToolStripButton)
						{
							if ((e.Item.Selected | e.Item.Pressed) & !((ToolStripButton)e.Item).Checked)
							{
								e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemTextPressed_2013;
							}
							else if (!e.Item.Selected & !e.Item.Pressed & !((ToolStripButton)e.Item).Checked)
							{
								e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemText_2013;
							}
							else if (((ToolStripButton)e.Item).Checked)
							{
								e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemTextSelected_2013;
							}
						}
						else if (e.Item is ToolStripLabel)
						{
							e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemText_2013;
						}
					}
					else if (e.Item.ForeColor != Color.DarkGray)
					{
						e.Item.ForeColor = Color.DarkGray;
					}
				}
			}
			else if (e.Item.Text != string.Empty)
			{
				if (e.Item.Enabled)
				{
					if (e.Item is ToolStripButton)
					{
						if ((e.Item.Selected | e.Item.Pressed) & !((ToolStripButton)e.Item).Checked)
						{
							e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemTextPressed;
						}
						else if (!e.Item.Selected & !e.Item.Pressed & !((ToolStripButton)e.Item).Checked)
						{
							e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemText;
						}
						else if (((ToolStripButton)e.Item).Checked)
						{
							e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemTextSelected;
						}
					}
					else if (e.Item is ToolStripLabel)
					{
						e.Item.ForeColor = Theme.Standard.RendererColorTable.ToolStripItemText;
					}
				}
				else if (e.Item.ForeColor != Color.DarkGray)
				{
					e.Item.ForeColor = Color.DarkGray;
				}
			}
			if ((e.Item is ToolStripButton) | (e.Item is ToolStripMenuItem) | (e.Item is ToolStripDropDownButton) | (e.Item is ToolStripLabel))
			{
				switch (e.Item.DisplayStyle)
				{
				case ToolStripItemDisplayStyle.Image:
					if (!e.Item.AutoSize)
					{
						if (e.Item.GetCurrentParent().TextDirection == ToolStripTextDirection.Vertical90)
						{
							e.Item.Size = new Size(e.Item.Image.Height + 2, e.Item.Image.Width + 2);
						}
						else if (e.Item.GetCurrentParent().TextDirection == ToolStripTextDirection.Horizontal)
						{
							e.Item.Size = new Size(e.Item.Image.Width + 2, e.Item.Image.Height + 2);
						}
					}
					break;
				case ToolStripItemDisplayStyle.ImageAndText:
					if (!e.Item.AutoSize)
					{
						if (e.Item.GetCurrentParent().TextDirection == ToolStripTextDirection.Vertical90)
						{
							e.Item.Size = new Size(Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Height + (float)e.Item.Image.Height + 10f), Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Width + 8f));
						}
						else if (e.Item.GetCurrentParent().TextDirection == ToolStripTextDirection.Horizontal)
						{
							e.Item.Size = new Size(Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Width + (float)e.Item.Image.Width + 10f), Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Height + 8f));
						}
					}
					e.Item.ImageAlign = ContentAlignment.MiddleLeft;
					e.Item.TextAlign = ContentAlignment.MiddleRight;
					break;
				case ToolStripItemDisplayStyle.Text:
					if (!e.Item.AutoSize)
					{
						if (e.Item.GetCurrentParent().TextDirection == ToolStripTextDirection.Vertical90)
						{
							e.Item.Size = new Size(Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Height + 8f), Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Width + 8f));
						}
						else if (e.Item.GetCurrentParent().TextDirection == ToolStripTextDirection.Horizontal)
						{
							e.Item.Size = new Size(Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Width + 8f), Convert.ToInt32(graphics.MeasureString(e.Item.Text, font).Height + 8f));
						}
					}
					break;
				case ToolStripItemDisplayStyle.None:
					break;
				}
			}
			else if (!(e.Item is ToolStripSeparator))
			{
				_ = e.Item is ToolStripTextBox;
			}
		}
		catch
		{
		}
	}
}
