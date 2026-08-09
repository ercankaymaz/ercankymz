using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace buControls.Controls;

public static class ControlGeometry
{
	public static void drawString(RectangleF rect, string Text, buControlDisplay Display, ref Graphics Grph)
	{
		Grph.DrawString(Text, Display.Fonts.Font, new SolidBrush(Display.Fonts.ForeColor), rect, AlignmentToStringFormat(Display.Fonts.Alignment));
	}

	public static void drawString(RectangleF rect, string Text, buControlDisplay Display, HotkeyPrefix HotPrefix, ref Graphics Grph)
	{
		Grph.DrawString(Text, Display.Fonts.Font, new SolidBrush(Display.Fonts.ForeColor), rect, AlignmentToStringFormat(Display.Fonts.Alignment, HotPrefix));
	}

	public static void drawString(RectangleF rect, string Text, float Angle, buControlDisplay Display, HotkeyPrefix HotPrefix, ref Graphics Grph)
	{
		SizeF sizeF = new SizeF(rect.Width, rect.Height);
		if (Angle == 0f)
		{
			Grph.DrawString(Text, Display.Fonts.Font, new SolidBrush(Display.Fonts.ForeColor), rect, AlignmentToStringFormat(Display.Fonts.Alignment, HotPrefix));
			return;
		}
		Grph.TranslateTransform(sizeF.Width / 2f + rect.X, sizeF.Height / 2f + rect.Y);
		Grph.RotateTransform(Angle);
		sizeF = Grph.MeasureString(Text, Display.Fonts.Font);
		Grph.DrawString(Text, Display.Fonts.Font, new SolidBrush(Display.Fonts.ForeColor), 0f - sizeF.Width / 2f, 0f - sizeF.Height / 2f);
		Grph.ResetTransform();
	}

	public static void drawGeometry(RectangleF rect, buControlGeometry Geometry, buControlDisplay Display, RoundRectangleType RoundRectangleType, ref Graphics Grph)
	{
		try
		{
			RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width - 1f, rect.Height - 1f);
			buControlDisplay buControlDisplay2 = new buControlDisplay(Display);
			GraphicsPath graphicsPath = new GraphicsPath();
			if (!((rectangleF.Height > 0f) & (rectangleF.Width > 0f)))
			{
				return;
			}
			if (Geometry.ShapeMode == ShapeType.Arc)
			{
				if (RoundRectangleType == RoundRectangleType.RoundRectAll)
				{
					graphicsPath = RoundRect(rectangleF, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeft)
				{
					graphicsPath = RoundLeftRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRight)
				{
					graphicsPath = RoundRightRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectUp)
				{
					graphicsPath = RoundUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectDown)
				{
					graphicsPath = RoundDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRightUp)
				{
					graphicsPath = RoundRightUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRightDown)
				{
					graphicsPath = RoundRightDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeftDown)
				{
					graphicsPath = RoundLeftDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeftUp)
				{
					graphicsPath = RoundLeftUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectNone)
				{
					graphicsPath = Rectangle(rectangleF);
					graphicsPath.CloseFigure();
				}
			}
			if (Geometry.ShapeMode == ShapeType.Rectangle)
			{
				graphicsPath = Rectangle(rectangleF);
				graphicsPath.CloseFigure();
			}
			if (Geometry.ShapeMode == ShapeType.Ellipse)
			{
				graphicsPath = Ellipse(rectangleF);
			}
			Brush brush = null;
			SelectBrush(rectangleF, graphicsPath, buControlDisplay2, ref brush);
			Grph.FillPath(brush, graphicsPath);
			if (buControlDisplay2.Border.Visible)
			{
				float num = buControlDisplay2.Border.Thickness;
				if (num <= 0f)
				{
					num = 1f;
				}
				Grph.DrawPath(new Pen(buControlDisplay2.Border.Color, num), graphicsPath);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void drawGeometry(RectangleF rect, int ArcDia, ShapeType Shape, buControlDisplay Display, RoundRectangleType RoundRectangleType, ref Graphics Grph)
	{
		try
		{
			RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width - 1f, rect.Height - 1f);
			buControlDisplay buControlDisplay2 = new buControlDisplay(Display);
			GraphicsPath graphicsPath = new GraphicsPath();
			if (!((rectangleF.Height > 0f) & (rectangleF.Width > 0f)))
			{
				return;
			}
			if (Shape == ShapeType.Arc)
			{
				if (RoundRectangleType == RoundRectangleType.RoundRectAll)
				{
					graphicsPath = RoundRect(rectangleF, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeft)
				{
					graphicsPath = RoundLeftRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRight)
				{
					graphicsPath = RoundRightRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectUp)
				{
					graphicsPath = RoundUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectDown)
				{
					graphicsPath = RoundDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRightUp)
				{
					graphicsPath = RoundRightUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRightDown)
				{
					graphicsPath = RoundRightDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeftDown)
				{
					graphicsPath = RoundLeftDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeftUp)
				{
					graphicsPath = RoundLeftUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectNone)
				{
					graphicsPath = Rectangle(rectangleF);
					graphicsPath.CloseFigure();
				}
			}
			if (Shape == ShapeType.Rectangle)
			{
				graphicsPath = Rectangle(rectangleF);
				graphicsPath.CloseFigure();
			}
			if (Shape == ShapeType.Ellipse)
			{
				graphicsPath = Ellipse(rectangleF);
			}
			Brush brush = null;
			SelectBrush(rectangleF, graphicsPath, buControlDisplay2, ref brush);
			Grph.FillPath(brush, graphicsPath);
			if (buControlDisplay2.Border.Visible)
			{
				float num = buControlDisplay2.Border.Thickness;
				if (num <= 0f)
				{
					num = 1f;
				}
				Grph.DrawPath(new Pen(buControlDisplay2.Border.Color, num), graphicsPath);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void drawGeometry(RectangleF rect, RectangleF rectScale, int ArcDia, ShapeType Shape, buControlDisplay Display, RoundRectangleType RoundRectangleType, ref Graphics Grph)
	{
		try
		{
			RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width - 1f, rect.Height - 1f);
			buControlDisplay buControlDisplay2 = new buControlDisplay(Display);
			GraphicsPath graphicsPath = new GraphicsPath();
			if (!((rectangleF.Height > 0f) & (rectangleF.Width > 0f)))
			{
				return;
			}
			if (Shape == ShapeType.Arc)
			{
				if (RoundRectangleType == RoundRectangleType.RoundRectAll)
				{
					graphicsPath = RoundRect(rectangleF, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeft)
				{
					graphicsPath = RoundLeftRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRight)
				{
					graphicsPath = RoundRightRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectUp)
				{
					graphicsPath = RoundUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectDown)
				{
					graphicsPath = RoundDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRightUp)
				{
					graphicsPath = RoundRightUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectRightDown)
				{
					graphicsPath = RoundRightDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeftDown)
				{
					graphicsPath = RoundLeftDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectLeftUp)
				{
					graphicsPath = RoundLeftUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
				}
				if (RoundRectangleType == RoundRectangleType.RoundRectNone)
				{
					graphicsPath = Rectangle(rectangleF);
					graphicsPath.CloseFigure();
				}
			}
			if (Shape == ShapeType.Rectangle)
			{
				graphicsPath = Rectangle(rectangleF);
				graphicsPath.CloseFigure();
			}
			if (Shape == ShapeType.Ellipse)
			{
				graphicsPath = Ellipse(rectangleF);
			}
			Brush brush = null;
			if ((rectScale.Width > 0f) & (rectScale.Height > 0f))
			{
				SelectBrush(rectScale, graphicsPath, buControlDisplay2, ref brush);
			}
			if (brush == null)
			{
				SelectBrush(rectangleF, graphicsPath, buControlDisplay2, ref brush);
			}
			Grph.FillPath(brush, graphicsPath);
			if (buControlDisplay2.Border.Visible)
			{
				float num = buControlDisplay2.Border.Thickness;
				if (num <= 0f)
				{
					num = 1f;
				}
				Grph.DrawPath(new Pen(buControlDisplay2.Border.Color, num), graphicsPath);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void SelectBrush(RectangleF rect, GraphicsPath pathControl, buControlDisplay disp, ref Brush brush)
	{
		try
		{
			if (disp.GradientType != GradientMode.Lineer)
			{
				if (disp.GradientType != GradientMode.Path)
				{
					if (disp.GradientType != GradientMode.InterpolatedPath)
					{
						SolidBrush solidBrush = new SolidBrush(disp.BackColor);
						brush = solidBrush;
						return;
					}
					PathGradientBrush pathGradientBrush = new PathGradientBrush(pathControl);
					if (disp.PathInterpolatedGradient.ColorCount < 2)
					{
						disp.PathInterpolatedGradient.ColorCount = 2;
					}
					if (disp.PathInterpolatedGradient.ColorCount > 4)
					{
						disp.PathInterpolatedGradient.ColorCount = 4;
					}
					pathGradientBrush.CenterPoint = new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
					Color[] array = new Color[disp.PathInterpolatedGradient.ColorCount];
					float[] array2 = null;
					if (disp.PathInterpolatedGradient.ColorCount == 2)
					{
						array[0] = disp.PathInterpolatedGradient.FirstColor;
						array[1] = disp.PathInterpolatedGradient.SecondColor;
						array2 = new float[2] { 0f, 1f };
					}
					if (disp.PathInterpolatedGradient.ColorCount == 3)
					{
						array[0] = disp.PathInterpolatedGradient.FirstColor;
						array[1] = disp.PathInterpolatedGradient.SecondColor;
						array[2] = disp.PathInterpolatedGradient.ThirdColor;
						array2 = new float[3] { 0f, 0.5f, 1f };
					}
					if (disp.PathInterpolatedGradient.ColorCount == 4)
					{
						array[0] = disp.PathInterpolatedGradient.FirstColor;
						array[1] = disp.PathInterpolatedGradient.SecondColor;
						array[2] = disp.PathInterpolatedGradient.ThirdColor;
						array[3] = disp.PathInterpolatedGradient.FourthColor;
						array2 = new float[4];
						array2[0] = 0f;
						array2[1] = 0.33f;
						array2[2] = 0.66f;
						array2[1] = 1f;
					}
					ColorBlend colorBlend = new ColorBlend();
					colorBlend.Colors = array;
					colorBlend.Positions = array2;
					pathGradientBrush.InterpolationColors = colorBlend;
					brush = pathGradientBrush;
				}
				else
				{
					PathGradientBrush pathGradientBrush2 = new PathGradientBrush(pathControl);
					pathGradientBrush2.CenterColor = disp.PathGradient.CenterColor;
					Color[] surroundColors = new Color[1] { disp.PathGradient.SurroundColor };
					pathGradientBrush2.SurroundColors = surroundColors;
					pathGradientBrush2.CenterPoint = new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
					ColorBlend colorBlend2 = new ColorBlend();
					colorBlend2.Positions = new float[2] { 0f, 1f };
					colorBlend2.Colors = new Color[2]
					{
						disp.PathGradient.SurroundColor,
						disp.PathGradient.CenterColor
					};
					pathGradientBrush2.InterpolationColors = colorBlend2;
					pathGradientBrush2.FocusScales = new PointF(0.4f, 0.4f);
					brush = pathGradientBrush2;
				}
			}
			else
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, disp.LineerGradient.FirstColor, disp.LineerGradient.SecondColor, disp.LineerGradient.GradientAngle);
				brush = linearGradientBrush;
			}
		}
		catch (Exception)
		{
		}
	}

	public static RectangleF GetTextRectangleFromImage(Image img, ContentAlignment imageAlignment, RectangleF ControlSize, buControlGeometry Geometry, int ImageBorderOffset)
	{
		RectangleF result = new RectangleF(ControlSize.X, ControlSize.Y, ControlSize.Width, ControlSize.Height);
		if ((imageAlignment == ContentAlignment.BottomLeft || imageAlignment == ContentAlignment.MiddleLeft || imageAlignment == ContentAlignment.TopLeft) && img != null)
		{
			result.X = (float)img.Width + Geometry.Space + (float)ImageBorderOffset;
			result.Width = result.Width - result.X - Geometry.Space;
		}
		if (!(imageAlignment == ContentAlignment.BottomCenter || imageAlignment == ContentAlignment.MiddleCenter || imageAlignment == ContentAlignment.TopCenter))
		{
		}
		if ((imageAlignment == ContentAlignment.BottomRight || imageAlignment == ContentAlignment.MiddleRight || imageAlignment == ContentAlignment.TopRight) && img != null)
		{
			result.Width = result.Width - (float)img.Width - Geometry.Space - (float)ImageBorderOffset;
		}
		if ((imageAlignment == ContentAlignment.TopLeft || imageAlignment == ContentAlignment.TopCenter || imageAlignment == ContentAlignment.TopRight) && img != null)
		{
			result.Y = (float)img.Height + Geometry.Space + (float)ImageBorderOffset;
			result.Height = result.Height - result.Y - Geometry.Space;
		}
		if ((imageAlignment == ContentAlignment.BottomLeft || imageAlignment == ContentAlignment.BottomCenter || imageAlignment == ContentAlignment.BottomRight) && img != null)
		{
			result.Height = result.Height - (float)img.Height - Geometry.Space - (float)ImageBorderOffset;
		}
		return result;
	}

	public static StringFormat AlignmentToStringFormat(ContentAlignment Align)
	{
		return AlignmentToStringFormat(Align, HotkeyPrefix.None);
	}

	public static StringFormat AlignmentToStringFormat(ContentAlignment Align, HotkeyPrefix Prefix)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.HotkeyPrefix = Prefix;
		switch (Align)
		{
		case ContentAlignment.BottomCenter:
			stringFormat.LineAlignment = StringAlignment.Far;
			stringFormat.Alignment = StringAlignment.Center;
			break;
		case ContentAlignment.TopRight:
			stringFormat.LineAlignment = StringAlignment.Near;
			stringFormat.Alignment = StringAlignment.Far;
			break;
		case ContentAlignment.MiddleLeft:
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.Alignment = StringAlignment.Near;
			break;
		case ContentAlignment.MiddleCenter:
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.Alignment = StringAlignment.Center;
			break;
		case ContentAlignment.MiddleRight:
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.Alignment = StringAlignment.Far;
			break;
		case ContentAlignment.BottomLeft:
			stringFormat.LineAlignment = StringAlignment.Far;
			stringFormat.Alignment = StringAlignment.Near;
			break;
		case ContentAlignment.BottomRight:
			stringFormat.LineAlignment = StringAlignment.Far;
			stringFormat.Alignment = StringAlignment.Far;
			break;
		case ContentAlignment.TopLeft:
			stringFormat.LineAlignment = StringAlignment.Near;
			stringFormat.Alignment = StringAlignment.Near;
			break;
		case ContentAlignment.TopCenter:
			stringFormat.LineAlignment = StringAlignment.Near;
			stringFormat.Alignment = StringAlignment.Center;
			break;
		}
		return stringFormat;
	}

	public static double MultiplyRatioFromValue(double Value)
	{
		if (!(Value < 0.0))
		{
			if (!(Value > 0.0))
			{
				return 0.0;
			}
			return 1.0;
		}
		return -1.0;
	}

	public static void CalcMainArea(float Width, float Height, buControlGeometry Geo, buControlCaption Caption, ref rectDraw rectCaption, ref RectangleF areaControl)
	{
		buControlUnit buControlUnit2 = new buControlUnit();
		buControlUnit2.Visible = false;
		buControlCheckTick buControlCheckTick2 = new buControlCheckTick();
		buControlCheckTick2.Visible = false;
		rectDraw rectUnit = new rectDraw();
		rectDraw rectCheckTick = new rectDraw();
		CalcMainArea(Width, Height, Geo, Caption, buControlUnit2, buControlCheckTick2, ref rectCaption, ref rectUnit, ref rectCheckTick, ref areaControl);
	}

	public static void CalcMainArea(float Width, float Height, buControlGeometry Geo, buControlCaption Caption, float ValueWidth, ref rectDraw rectCaption, ref rectDraw rectValue, ref RectangleF areaControl)
	{
		buControlUnit buControlUnit2 = new buControlUnit();
		buControlUnit2.Visible = true;
		buControlUnit2.Width = (int)ValueWidth;
		buControlCheckTick buControlCheckTick2 = new buControlCheckTick();
		buControlCheckTick2.Visible = false;
		rectDraw rectCheckTick = new rectDraw();
		CalcMainArea(Width, Height, Geo, Caption, buControlUnit2, buControlCheckTick2, ref rectCaption, ref rectValue, ref rectCheckTick, ref areaControl);
	}

	public static void CalcMainArea(float Width, float Height, buControlGeometry Geo, buControlCaption Caption, buControlUnit Unit, ref rectDraw rectCaption, ref rectDraw rectUnit, ref RectangleF areaControl)
	{
		buControlCheckTick buControlCheckTick2 = new buControlCheckTick();
		buControlCheckTick2.Visible = false;
		rectDraw rectCheckTick = new rectDraw();
		CalcMainArea(Width, Height, Geo, Caption, Unit, buControlCheckTick2, ref rectCaption, ref rectUnit, ref rectCheckTick, ref areaControl);
	}

	public static void CalcMainArea(float Width, float Height, buControlGeometry Geo, buControlCaption Caption, buControlUnit Unit, buControlCheckTick CaptionTick, ref rectDraw rectCaption, ref rectDraw rectUnit, ref rectDraw rectCheckTick, ref RectangleF areaControl)
	{
		float num = Caption.Width;
		float num2 = Unit.Width;
		float num3 = Height;
		_ = Geo.Space;
		_ = Geo.Space;
		float num4 = Convert.ToSingle(Caption.HeightPersentage) / 100f;
		if (!Caption.Visible)
		{
			num = 0f;
			num3 = 0f;
			rectCaption = new rectDraw();
			rectCaption.rectText = default(RectangleF);
		}
		else
		{
			if (!Caption.OnTop)
			{
				num = Caption.Width;
				num3 = Height - 2f;
				rectCaption.RoundType = RoundRectangleType.RoundRectLeft;
				rectCaption.rect.X = 1f;
				rectCaption.rect.Y = 1f;
				rectCaption.rect.Width = num - 1f;
				rectCaption.rect.Height = Height - 2f;
			}
			else
			{
				num = Width;
				num3 = Height * num4 - (float)Geo.ArcDiameter * num4;
				rectCaption.RoundType = RoundRectangleType.RoundRectUp;
				rectCaption.rect.X = 1f;
				rectCaption.rect.Y = 1f;
				rectCaption.rect.Width = Width - 1f;
				rectCaption.rect.Height = num3;
			}
			rectCaption.rectText = new RectangleF(rectCaption.rect.X, rectCaption.rect.Y, rectCaption.rect.Width, rectCaption.rect.Height);
		}
		if (!Unit.Visible)
		{
			num2 = 0f;
			rectUnit = new rectDraw();
			rectUnit.rectText = default(RectangleF);
		}
		else if (!Caption.Visible)
		{
			num2 = Unit.Width;
			rectUnit.rect.X = Width - (float)Unit.Width;
			rectUnit.rect.Y = 0f;
			rectUnit.rect.Width = Unit.Width;
			rectUnit.rect.Height = Height;
			rectUnit.rectText = new RectangleF(rectUnit.rect.X, rectUnit.rect.Y, rectUnit.rect.Width, rectUnit.rect.Height);
		}
		else
		{
			if (!Caption.OnTop)
			{
				num2 = Unit.Width;
				rectUnit.RoundType = RoundRectangleType.RoundRectRight;
				rectUnit.rect.X = Width - (float)Unit.Width;
				rectUnit.rect.Y = 0f;
				rectUnit.rect.Width = Unit.Width;
				rectUnit.rect.Height = Height;
			}
			else
			{
				num2 = Unit.Width;
				_ = rectCaption.rect.Height;
				rectUnit.RoundType = RoundRectangleType.RoundRectRightUp;
				rectUnit.rect.X = Width - (float)Unit.Width;
				rectUnit.rect.Y = 0f;
				rectUnit.rect.Width = Unit.Width;
				rectUnit.rect.Height = rectCaption.rect.Height;
				rectCaption.rect.Width = Width - (float)Unit.Width;
				rectCaption.rectText.Width = rectCaption.rect.Width;
			}
			rectUnit.rectText = new RectangleF(rectUnit.rect.X, rectUnit.rect.Y, rectUnit.rect.Width, rectUnit.rect.Height);
		}
		if (!(CaptionTick.Visible & Caption.Visible))
		{
			rectCheckTick.rect = default(RectangleF);
			rectCheckTick.rectText = default(RectangleF);
		}
		else
		{
			if (CaptionTick.RightSide)
			{
				if (!Unit.Visible)
				{
					if (Caption.OnTop)
					{
						rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
						rectCheckTick.rect.X = rectCaption.rect.Width - (float)CaptionTick.BoxSize - (float)(int)Geo.Space - (float)CaptionTick.Space;
						rectCheckTick.rect.Y = (int)((rectCaption.rect.Height - (float)CaptionTick.BoxSize) / 2f);
						rectCheckTick.rect.Width = CaptionTick.BoxSize;
						rectCheckTick.rect.Height = CaptionTick.BoxSize;
						rectCaption.rectText.Width = rectCaption.rect.Width - (float)CaptionTick.BoxSize - (float)CaptionTick.Space - Geo.Space;
					}
					else
					{
						rectUnit.rect.Width = CaptionTick.BoxSize + 6;
						rectUnit.rect.X = Width - rectUnit.rect.Width;
						rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
						rectCheckTick.rect.X = rectUnit.rect.X + (float)CaptionTick.Space;
						rectCheckTick.rect.Y = (int)((rectCaption.rect.Height - (float)CaptionTick.BoxSize) / 2f);
						rectCheckTick.rect.Width = CaptionTick.BoxSize;
						rectCheckTick.rect.Height = CaptionTick.BoxSize;
						rectUnit.rectText.Width = 0f;
					}
				}
				else if (Caption.OnTop)
				{
					rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
					rectCheckTick.rect.X = rectCaption.rect.Width - (float)CaptionTick.BoxSize - (float)(int)Geo.Space - (float)CaptionTick.Space;
					rectCheckTick.rect.Y = (int)((rectCaption.rect.Height - (float)CaptionTick.BoxSize) / 2f);
					rectCheckTick.rect.Width = CaptionTick.BoxSize;
					rectCheckTick.rect.Height = CaptionTick.BoxSize;
					rectCaption.rectText.Width = rectCaption.rect.Width - (float)CaptionTick.BoxSize - (float)CaptionTick.Space - Geo.Space;
				}
				else
				{
					rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
					rectCheckTick.rect.X = rectUnit.rect.Width + rectUnit.rect.X - (float)CaptionTick.BoxSize - (float)(int)Geo.Space - (float)CaptionTick.Space;
					rectCheckTick.rect.Y = (int)((rectCaption.rect.Height - (float)CaptionTick.BoxSize) / 2f);
					rectCheckTick.rect.Width = CaptionTick.BoxSize;
					rectCheckTick.rect.Height = CaptionTick.BoxSize;
					rectUnit.rectText.Width = rectUnit.rect.Width - (float)CaptionTick.BoxSize - (float)CaptionTick.Space - Geo.Space;
				}
			}
			else
			{
				rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
				rectCheckTick.rect.X = rectCaption.rect.X + (float)(int)Geo.Space + (float)CaptionTick.Space;
				rectCheckTick.rect.Y = (int)((rectCaption.rect.Height - (float)CaptionTick.BoxSize) / 2f);
				rectCheckTick.rect.Width = CaptionTick.BoxSize;
				rectCheckTick.rect.Height = CaptionTick.BoxSize;
				rectCaption.rectText.X = rectCheckTick.rect.X + rectCheckTick.rect.Width + Geo.Space * 2f;
				rectCaption.rectText.Width = rectCaption.rect.Width - rectCaption.rectText.X;
			}
			rectCheckTick.rectText = new RectangleF(rectCheckTick.rect.X - 8f, rectCheckTick.rect.Y, rectCheckTick.rect.Width + 16f, rectCheckTick.rect.Height);
		}
		if (Caption.Visible)
		{
			if (Caption.OnTop)
			{
				float num5 = Height * num4 - (float)Geo.ArcDiameter * num4 + 1f;
				areaControl.X = 0f;
				areaControl.Y = num5;
				areaControl.Width = Width;
				areaControl.Height = Height - num5;
			}
			else
			{
				areaControl.X = Caption.Width;
				areaControl.Y = 0f;
				areaControl.Width = Width - num - num2;
				areaControl.Height = Height;
			}
		}
		else
		{
			areaControl.X = 0f;
			areaControl.Y = 0f;
			areaControl.Width = Width;
			areaControl.Height = Height;
			if (Unit.Visible)
			{
				areaControl.X = 0f;
				areaControl.Y = 0f;
				areaControl.Width = Width - (float)Unit.Width;
				areaControl.Height = Height;
			}
		}
	}

	public static string LanguageSelect(buControlLanguage Lang, string OrjText)
	{
		string result = OrjText;
		if (Lang.MultiLanguageEnable)
		{
			if ((Lang.SelectedLanguage == 0) | (Lang.SelectedLanguage == 1))
			{
				result = Lang.Language1;
			}
			if (Lang.SelectedLanguage == 2)
			{
				result = Lang.Language2;
			}
			if (Lang.SelectedLanguage == 3)
			{
				result = Lang.Language3;
			}
			if (Lang.SelectedLanguage == 4)
			{
				result = Lang.Language4;
			}
			if (Lang.SelectedLanguage == 5)
			{
				result = Lang.Language5;
			}
			if (Lang.SelectedLanguage == 6)
			{
				result = Lang.Language6;
			}
		}
		return result;
	}

	public static GraphicsPath Curve(PointF[] CurvePoint, PointF Tension)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddCurve(CurvePoint);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath Ellipse(RectangleF Rectangle)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(Rectangle);
		return graphicsPath;
	}

	public static GraphicsPath Rectangle(RectangleF Rectangle)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(Rectangle);
		return graphicsPath;
	}

	public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
		graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
		graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 0f, 90f);
		graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundRect(RectangleF Rectangle, int Curve)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
		graphicsPath.AddArc(new RectangleF(Rectangle.Width - (float)num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
		graphicsPath.AddArc(new RectangleF(Rectangle.Width - (float)num + Rectangle.X, Rectangle.Height - (float)num + Rectangle.Y, num, num), 0f, 90f);
		graphicsPath.AddArc(new RectangleF(Rectangle.X, Rectangle.Height - (float)num + Rectangle.Y, num, num), 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundRectByType(Rectangle Rectangle, int Curve, RoundRectangleType Type)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (Type)
		{
		default:
			if (Type != RoundRectangleType.RoundRectDown)
			{
				return graphicsPath;
			}
			graphicsPath.AddRectangle(Rectangle);
			return graphicsPath;
		case RoundRectangleType.RoundRectAll:
			return RoundRect(Rectangle, Curve);
		case RoundRectangleType.RoundRectLeft:
			return RoundLeftRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		case RoundRectangleType.RoundRectRight:
			return RoundRightRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		case RoundRectangleType.RoundRectUp:
			return RoundUpRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		case RoundRectangleType.RoundRectDown:
			return RoundDownRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		}
	}

	public static GraphicsPath RoundRectByType(RectangleF Rectangle, int Curve, RoundRectangleType Type)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (Type)
		{
		default:
			if (Type != RoundRectangleType.RoundRectDown)
			{
				return graphicsPath;
			}
			graphicsPath.AddRectangle(Rectangle);
			return graphicsPath;
		case RoundRectangleType.RoundRectAll:
			return RoundRect(Rectangle, Curve);
		case RoundRectangleType.RoundRectLeft:
			return RoundLeftRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		case RoundRectangleType.RoundRectRight:
			return RoundRightRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		case RoundRectangleType.RoundRectUp:
			return RoundUpRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		case RoundRectangleType.RoundRectDown:
			return RoundDownRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
		}
	}

	public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
	{
		Rectangle rectangle = new Rectangle(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Y, num, num), -180f, 90f);
		graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Y, num, num), -90f, 90f);
		graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 0f, 90f);
		graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, num, num), -180f, 90f);
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Y, num, num), -90f, 90f);
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 0f, 90f);
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundUpRect(int X, int Y, int Width, int Height, int Curve)
	{
		Rectangle rectangle = new Rectangle(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Y, num, num), -180f, 90f);
		graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Y, num, num), -90f, 90f);
		graphicsPath.AddLine(new Point(rectangle.X + rectangle.Width, rectangle.Y + Curve), new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
		graphicsPath.AddLine(new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), new Point(rectangle.X, rectangle.Y + rectangle.Height));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundUpRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, num, num), -180f, 90f);
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Y, num, num), -90f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + (float)Curve), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundDownRect(int X, int Y, int Width, int Height, int Curve)
	{
		Rectangle rectangle = new Rectangle(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 0f, 90f);
		graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 90f, 90f);
		graphicsPath.AddLine(new Point(rectangle.X, rectangle.Height - num + rectangle.Y), new Point(rectangle.X, rectangle.Y));
		graphicsPath.AddLine(new Point(rectangle.X, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundDownRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 0f, 90f);
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 90f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y), new PointF(rectangleF.X, rectangleF.Y));
		graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundRightRect(int X, int Y, int Width, int Height, int Curve)
	{
		Rectangle rectangle = new Rectangle(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Y, num, num), -90f, 90f);
		graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 0f, 90f);
		graphicsPath.AddLine(new Point(rectangle.X + rectangle.Width - Curve, rectangle.Y + rectangle.Height), new Point(rectangle.X, rectangle.Y + rectangle.Height));
		graphicsPath.AddLine(new Point(rectangle.X, rectangle.Y + rectangle.Height), new Point(rectangle.X, rectangle.Y));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundRightRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Y, num, num), -90f, 90f);
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 0f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width - (float)Curve, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
		graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundLeftRect(int X, int Y, int Width, int Height, int Curve)
	{
		Rectangle rectangle = new Rectangle(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 90f, 90f);
		graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Y, num, num), -180f, 90f);
		graphicsPath.AddLine(new Point(rectangle.X + Curve, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y));
		graphicsPath.AddLine(new Point(rectangle.X + rectangle.Width, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundLeftRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 90f, 90f);
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, num, num), -180f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X + (float)Curve, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundRightUpRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Y, num, num), -90f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + (float)Curve), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width - (float)Curve, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
		graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundRightDownRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float)num + rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 0f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width - (float)Curve, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
		graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y));
		graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundLeftDownRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float)num + rectangleF.Y, num, num), 90f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height - (float)Curve), new PointF(rectangleF.X, rectangleF.Y));
		graphicsPath.AddLine(new PointF(rectangleF.X + (float)Curve, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static GraphicsPath RoundLeftUpRect(float X, float Y, float Width, float Height, int Curve)
	{
		RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Curve * 2;
		graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, num, num), -180f, 90f);
		graphicsPath.AddLine(new PointF(rectangleF.X + (float)Curve, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
		graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
