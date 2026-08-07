// Decompiled with JetBrains decompiler
// Type: buControls.Controls.ControlGeometry
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

#nullable disable
namespace buControls.Controls;

public static class ControlGeometry
{
  public static void drawString(
    RectangleF rect,
    string Text,
    buControlDisplay Display,
    ref Graphics Grph)
  {
    Grph.DrawString(Text, Display.Fonts.Font, (Brush) new SolidBrush(Display.Fonts.ForeColor), rect, ControlGeometry.AlignmentToStringFormat(Display.Fonts.Alignment));
  }

  public static void drawString(
    RectangleF rect,
    string Text,
    buControlDisplay Display,
    HotkeyPrefix HotPrefix,
    ref Graphics Grph)
  {
    Grph.DrawString(Text, Display.Fonts.Font, (Brush) new SolidBrush(Display.Fonts.ForeColor), rect, ControlGeometry.AlignmentToStringFormat(Display.Fonts.Alignment, HotPrefix));
  }

  public static void drawString(
    RectangleF rect,
    string Text,
    float Angle,
    buControlDisplay Display,
    HotkeyPrefix HotPrefix,
    ref Graphics Grph)
  {
    SizeF sizeF1 = new SizeF(rect.Width, rect.Height);
    if ((double) Angle != 0.0)
    {
      Grph.TranslateTransform(sizeF1.Width / 2f + rect.X, sizeF1.Height / 2f + rect.Y);
      Grph.RotateTransform(Angle);
      SizeF sizeF2 = Grph.MeasureString(Text, Display.Fonts.Font);
      Grph.DrawString(Text, Display.Fonts.Font, (Brush) new SolidBrush(Display.Fonts.ForeColor), (float) -((double) sizeF2.Width / 2.0), (float) -((double) sizeF2.Height / 2.0));
      Grph.ResetTransform();
    }
    else
      Grph.DrawString(Text, Display.Fonts.Font, (Brush) new SolidBrush(Display.Fonts.ForeColor), rect, ControlGeometry.AlignmentToStringFormat(Display.Fonts.Alignment, HotPrefix));
  }

  public static void drawGeometry(
    RectangleF rect,
    buControlGeometry Geometry,
    buControlDisplay Display,
    RoundRectangleType RoundRectangleType,
    ref Graphics Grph)
  {
    try
    {
      RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width - 1f, rect.Height - 1f);
      buControlDisplay disp = new buControlDisplay(Display);
      GraphicsPath graphicsPath = new GraphicsPath();
      if (!((double) rectangleF.Height > 0.0 & (double) rectangleF.Width > 0.0))
        return;
      if (Geometry.ShapeMode == ShapeType.Arc)
      {
        if (RoundRectangleType == RoundRectangleType.RoundRectAll)
          graphicsPath = ControlGeometry.RoundRect(rectangleF, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeft)
          graphicsPath = ControlGeometry.RoundLeftRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectRight)
          graphicsPath = ControlGeometry.RoundRightRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectUp)
          graphicsPath = ControlGeometry.RoundUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectDown)
          graphicsPath = ControlGeometry.RoundDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectRightUp)
          graphicsPath = ControlGeometry.RoundRightUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectRightDown)
          graphicsPath = ControlGeometry.RoundRightDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeftDown)
          graphicsPath = ControlGeometry.RoundLeftDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeftUp)
          graphicsPath = ControlGeometry.RoundLeftUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, Geometry.ArcDiameter);
        if (RoundRectangleType == RoundRectangleType.RoundRectNone)
        {
          graphicsPath = ControlGeometry.Rectangle(rectangleF);
          graphicsPath.CloseFigure();
        }
      }
      if (Geometry.ShapeMode == ShapeType.Rectangle)
      {
        graphicsPath = ControlGeometry.Rectangle(rectangleF);
        graphicsPath.CloseFigure();
      }
      if (Geometry.ShapeMode == ShapeType.Ellipse)
        graphicsPath = ControlGeometry.Ellipse(rectangleF);
      Brush brush = (Brush) null;
      ControlGeometry.SelectBrush(rectangleF, graphicsPath, disp, ref brush);
      Grph.FillPath(brush, graphicsPath);
      if (!disp.Border.Visible)
        return;
      float width = disp.Border.Thickness;
      if ((double) width <= 0.0)
        width = 1f;
      Grph.DrawPath(new Pen(disp.Border.Color, width), graphicsPath);
    }
    catch (Exception ex)
    {
    }
  }

  public static void drawGeometry(
    RectangleF rect,
    int ArcDia,
    ShapeType Shape,
    buControlDisplay Display,
    RoundRectangleType RoundRectangleType,
    ref Graphics Grph)
  {
    try
    {
      RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width - 1f, rect.Height - 1f);
      buControlDisplay disp = new buControlDisplay(Display);
      GraphicsPath graphicsPath = new GraphicsPath();
      if (!((double) rectangleF.Height > 0.0 & (double) rectangleF.Width > 0.0))
        return;
      if (Shape == ShapeType.Arc)
      {
        if (RoundRectangleType == RoundRectangleType.RoundRectAll)
          graphicsPath = ControlGeometry.RoundRect(rectangleF, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeft)
          graphicsPath = ControlGeometry.RoundLeftRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectRight)
          graphicsPath = ControlGeometry.RoundRightRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectUp)
          graphicsPath = ControlGeometry.RoundUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectDown)
          graphicsPath = ControlGeometry.RoundDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectRightUp)
          graphicsPath = ControlGeometry.RoundRightUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectRightDown)
          graphicsPath = ControlGeometry.RoundRightDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeftDown)
          graphicsPath = ControlGeometry.RoundLeftDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeftUp)
          graphicsPath = ControlGeometry.RoundLeftUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectNone)
        {
          graphicsPath = ControlGeometry.Rectangle(rectangleF);
          graphicsPath.CloseFigure();
        }
      }
      if (Shape == ShapeType.Rectangle)
      {
        graphicsPath = ControlGeometry.Rectangle(rectangleF);
        graphicsPath.CloseFigure();
      }
      if (Shape == ShapeType.Ellipse)
        graphicsPath = ControlGeometry.Ellipse(rectangleF);
      Brush brush = (Brush) null;
      ControlGeometry.SelectBrush(rectangleF, graphicsPath, disp, ref brush);
      Grph.FillPath(brush, graphicsPath);
      if (!disp.Border.Visible)
        return;
      float width = disp.Border.Thickness;
      if ((double) width <= 0.0)
        width = 1f;
      Grph.DrawPath(new Pen(disp.Border.Color, width), graphicsPath);
    }
    catch (Exception ex)
    {
    }
  }

  public static void drawGeometry(
    RectangleF rect,
    RectangleF rectScale,
    int ArcDia,
    ShapeType Shape,
    buControlDisplay Display,
    RoundRectangleType RoundRectangleType,
    ref Graphics Grph)
  {
    try
    {
      RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width - 1f, rect.Height - 1f);
      buControlDisplay disp = new buControlDisplay(Display);
      GraphicsPath graphicsPath = new GraphicsPath();
      if (!((double) rectangleF.Height > 0.0 & (double) rectangleF.Width > 0.0))
        return;
      if (Shape == ShapeType.Arc)
      {
        if (RoundRectangleType == RoundRectangleType.RoundRectAll)
          graphicsPath = ControlGeometry.RoundRect(rectangleF, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeft)
          graphicsPath = ControlGeometry.RoundLeftRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectRight)
          graphicsPath = ControlGeometry.RoundRightRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectUp)
          graphicsPath = ControlGeometry.RoundUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectDown)
          graphicsPath = ControlGeometry.RoundDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectRightUp)
          graphicsPath = ControlGeometry.RoundRightUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectRightDown)
          graphicsPath = ControlGeometry.RoundRightDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeftDown)
          graphicsPath = ControlGeometry.RoundLeftDownRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectLeftUp)
          graphicsPath = ControlGeometry.RoundLeftUpRect(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, ArcDia);
        if (RoundRectangleType == RoundRectangleType.RoundRectNone)
        {
          graphicsPath = ControlGeometry.Rectangle(rectangleF);
          graphicsPath.CloseFigure();
        }
      }
      if (Shape == ShapeType.Rectangle)
      {
        graphicsPath = ControlGeometry.Rectangle(rectangleF);
        graphicsPath.CloseFigure();
      }
      if (Shape == ShapeType.Ellipse)
        graphicsPath = ControlGeometry.Ellipse(rectangleF);
      Brush brush = (Brush) null;
      if ((double) rectScale.Width > 0.0 & (double) rectScale.Height > 0.0)
        ControlGeometry.SelectBrush(rectScale, graphicsPath, disp, ref brush);
      if (brush == null)
        ControlGeometry.SelectBrush(rectangleF, graphicsPath, disp, ref brush);
      Grph.FillPath(brush, graphicsPath);
      if (!disp.Border.Visible)
        return;
      float width = disp.Border.Thickness;
      if ((double) width <= 0.0)
        width = 1f;
      Grph.DrawPath(new Pen(disp.Border.Color, width), graphicsPath);
    }
    catch (Exception ex)
    {
    }
  }

  public static void SelectBrush(
    RectangleF rect,
    GraphicsPath pathControl,
    buControlDisplay disp,
    ref Brush brush)
  {
    try
    {
      if (disp.GradientType == GradientMode.Lineer)
      {
        LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, disp.LineerGradient.FirstColor, disp.LineerGradient.SecondColor, disp.LineerGradient.GradientAngle);
        brush = (Brush) linearGradientBrush;
      }
      else if (disp.GradientType == GradientMode.Path)
      {
        PathGradientBrush pathGradientBrush = new PathGradientBrush(pathControl);
        pathGradientBrush.CenterColor = disp.PathGradient.CenterColor;
        Color[] colorArray = new Color[1]
        {
          disp.PathGradient.SurroundColor
        };
        pathGradientBrush.SurroundColors = colorArray;
        pathGradientBrush.CenterPoint = new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
        pathGradientBrush.InterpolationColors = new ColorBlend()
        {
          Positions = new float[2]{ 0.0f, 1f },
          Colors = new Color[2]
          {
            disp.PathGradient.SurroundColor,
            disp.PathGradient.CenterColor
          }
        };
        pathGradientBrush.FocusScales = new PointF(0.4f, 0.4f);
        brush = (Brush) pathGradientBrush;
      }
      else if (disp.GradientType == GradientMode.InterpolatedPath)
      {
        PathGradientBrush pathGradientBrush = new PathGradientBrush(pathControl);
        if (disp.PathInterpolatedGradient.ColorCount < 2)
          disp.PathInterpolatedGradient.ColorCount = 2;
        if (disp.PathInterpolatedGradient.ColorCount > 4)
          disp.PathInterpolatedGradient.ColorCount = 4;
        pathGradientBrush.CenterPoint = new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
        Color[] colorArray = new Color[disp.PathInterpolatedGradient.ColorCount];
        float[] numArray = (float[]) null;
        if (disp.PathInterpolatedGradient.ColorCount == 2)
        {
          colorArray[0] = disp.PathInterpolatedGradient.FirstColor;
          colorArray[1] = disp.PathInterpolatedGradient.SecondColor;
          numArray = new float[2]{ 0.0f, 1f };
        }
        if (disp.PathInterpolatedGradient.ColorCount == 3)
        {
          colorArray[0] = disp.PathInterpolatedGradient.FirstColor;
          colorArray[1] = disp.PathInterpolatedGradient.SecondColor;
          colorArray[2] = disp.PathInterpolatedGradient.ThirdColor;
          numArray = new float[3]{ 0.0f, 0.5f, 1f };
        }
        if (disp.PathInterpolatedGradient.ColorCount == 4)
        {
          colorArray[0] = disp.PathInterpolatedGradient.FirstColor;
          colorArray[1] = disp.PathInterpolatedGradient.SecondColor;
          colorArray[2] = disp.PathInterpolatedGradient.ThirdColor;
          colorArray[3] = disp.PathInterpolatedGradient.FourthColor;
          numArray = new float[4]
          {
            0.0f,
            0.33f,
            0.66f,
            0.0f
          };
          numArray[1] = 1f;
        }
        pathGradientBrush.InterpolationColors = new ColorBlend()
        {
          Colors = colorArray,
          Positions = numArray
        };
        brush = (Brush) pathGradientBrush;
      }
      else
      {
        SolidBrush solidBrush = new SolidBrush(disp.BackColor);
        brush = (Brush) solidBrush;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static RectangleF GetTextRectangleFromImage(
    Image img,
    ContentAlignment imageAlignment,
    RectangleF ControlSize,
    buControlGeometry Geometry,
    int ImageBorderOffset)
  {
    RectangleF rectangleFromImage = new RectangleF(ControlSize.X, ControlSize.Y, ControlSize.Width, ControlSize.Height);
    if (imageAlignment == ContentAlignment.BottomLeft | imageAlignment == ContentAlignment.MiddleLeft | imageAlignment == ContentAlignment.TopLeft && img != null)
    {
      rectangleFromImage.X = (float) img.Width + Geometry.Space + (float) ImageBorderOffset;
      rectangleFromImage.Width = rectangleFromImage.Width - rectangleFromImage.X - Geometry.Space;
    }
    if (imageAlignment == ContentAlignment.BottomCenter | imageAlignment == ContentAlignment.MiddleCenter | imageAlignment == ContentAlignment.TopCenter)
      ;
    if (imageAlignment == ContentAlignment.BottomRight | imageAlignment == ContentAlignment.MiddleRight | imageAlignment == ContentAlignment.TopRight && img != null)
      rectangleFromImage.Width = rectangleFromImage.Width - (float) img.Width - Geometry.Space - (float) ImageBorderOffset;
    if (imageAlignment == ContentAlignment.TopLeft | imageAlignment == ContentAlignment.TopCenter | imageAlignment == ContentAlignment.TopRight && img != null)
    {
      rectangleFromImage.Y = (float) img.Height + Geometry.Space + (float) ImageBorderOffset;
      rectangleFromImage.Height = rectangleFromImage.Height - rectangleFromImage.Y - Geometry.Space;
    }
    if (imageAlignment == ContentAlignment.BottomLeft | imageAlignment == ContentAlignment.BottomCenter | imageAlignment == ContentAlignment.BottomRight && img != null)
      rectangleFromImage.Height = rectangleFromImage.Height - (float) img.Height - Geometry.Space - (float) ImageBorderOffset;
    return rectangleFromImage;
  }

  public static StringFormat AlignmentToStringFormat(ContentAlignment Align)
  {
    return ControlGeometry.AlignmentToStringFormat(Align, HotkeyPrefix.None);
  }

  public static StringFormat AlignmentToStringFormat(ContentAlignment Align, HotkeyPrefix Prefix)
  {
    StringFormat stringFormat = new StringFormat();
    stringFormat.HotkeyPrefix = Prefix;
    switch (Align)
    {
      case ContentAlignment.TopLeft:
        stringFormat.LineAlignment = StringAlignment.Near;
        stringFormat.Alignment = StringAlignment.Near;
        break;
      case ContentAlignment.TopCenter:
        stringFormat.LineAlignment = StringAlignment.Near;
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
      case ContentAlignment.BottomCenter:
        stringFormat.LineAlignment = StringAlignment.Far;
        stringFormat.Alignment = StringAlignment.Center;
        break;
      case ContentAlignment.BottomRight:
        stringFormat.LineAlignment = StringAlignment.Far;
        stringFormat.Alignment = StringAlignment.Far;
        break;
    }
    return stringFormat;
  }

  public static double MultiplyRatioFromValue(double Value)
  {
    return Value >= 0.0 ? (Value <= 0.0 ? 0.0 : 1.0) : -1.0;
  }

  public static void CalcMainArea(
    float Width,
    float Height,
    buControlGeometry Geo,
    buControlCaption Caption,
    ref rectDraw rectCaption,
    ref RectangleF areaControl)
  {
    buControlUnit Unit = new buControlUnit();
    Unit.Visible = false;
    buControlCheckTick CaptionTick = new buControlCheckTick();
    CaptionTick.Visible = false;
    rectDraw rectUnit = new rectDraw();
    rectDraw rectCheckTick = new rectDraw();
    ControlGeometry.CalcMainArea(Width, Height, Geo, Caption, Unit, CaptionTick, ref rectCaption, ref rectUnit, ref rectCheckTick, ref areaControl);
  }

  public static void CalcMainArea(
    float Width,
    float Height,
    buControlGeometry Geo,
    buControlCaption Caption,
    float ValueWidth,
    ref rectDraw rectCaption,
    ref rectDraw rectValue,
    ref RectangleF areaControl)
  {
    buControlUnit Unit = new buControlUnit();
    Unit.Visible = true;
    Unit.Width = (int) ValueWidth;
    buControlCheckTick CaptionTick = new buControlCheckTick();
    CaptionTick.Visible = false;
    rectDraw rectCheckTick = new rectDraw();
    ControlGeometry.CalcMainArea(Width, Height, Geo, Caption, Unit, CaptionTick, ref rectCaption, ref rectValue, ref rectCheckTick, ref areaControl);
  }

  public static void CalcMainArea(
    float Width,
    float Height,
    buControlGeometry Geo,
    buControlCaption Caption,
    buControlUnit Unit,
    ref rectDraw rectCaption,
    ref rectDraw rectUnit,
    ref RectangleF areaControl)
  {
    buControlCheckTick CaptionTick = new buControlCheckTick();
    CaptionTick.Visible = false;
    rectDraw rectCheckTick = new rectDraw();
    ControlGeometry.CalcMainArea(Width, Height, Geo, Caption, Unit, CaptionTick, ref rectCaption, ref rectUnit, ref rectCheckTick, ref areaControl);
  }

  public static void CalcMainArea(
    float Width,
    float Height,
    buControlGeometry Geo,
    buControlCaption Caption,
    buControlUnit Unit,
    buControlCheckTick CaptionTick,
    ref rectDraw rectCaption,
    ref rectDraw rectUnit,
    ref rectDraw rectCheckTick,
    ref RectangleF areaControl)
  {
    float width1 = (float) Caption.Width;
    float width2 = (float) Unit.Width;
    float num1 = Height;
    double space1 = (double) Geo.Space;
    double space2 = (double) Geo.Space;
    float num2 = Convert.ToSingle(Caption.HeightPersentage) / 100f;
    float num3;
    if (Caption.Visible)
    {
      if (Caption.OnTop)
      {
        num3 = Width;
        float num4 = (float) ((double) Height * (double) num2 - (double) Geo.ArcDiameter * (double) num2);
        rectCaption.RoundType = RoundRectangleType.RoundRectUp;
        rectCaption.rect.X = 1f;
        rectCaption.rect.Y = 1f;
        rectCaption.rect.Width = Width - 1f;
        rectCaption.rect.Height = num4;
      }
      else
      {
        num3 = (float) Caption.Width;
        num1 = Height - 2f;
        rectCaption.RoundType = RoundRectangleType.RoundRectLeft;
        rectCaption.rect.X = 1f;
        rectCaption.rect.Y = 1f;
        rectCaption.rect.Width = num3 - 1f;
        rectCaption.rect.Height = Height - 2f;
      }
      rectCaption.rectText = new RectangleF(rectCaption.rect.X, rectCaption.rect.Y, rectCaption.rect.Width, rectCaption.rect.Height);
    }
    else
    {
      num3 = 0.0f;
      num1 = 0.0f;
      rectCaption = new rectDraw();
      rectCaption.rectText = new RectangleF();
    }
    float num5;
    if (Unit.Visible)
    {
      if (Caption.Visible)
      {
        if (Caption.OnTop)
        {
          num5 = (float) Unit.Width;
          double height = (double) rectCaption.rect.Height;
          rectUnit.RoundType = RoundRectangleType.RoundRectRightUp;
          rectUnit.rect.X = Width - (float) Unit.Width;
          rectUnit.rect.Y = 0.0f;
          rectUnit.rect.Width = (float) Unit.Width;
          rectUnit.rect.Height = rectCaption.rect.Height;
          rectCaption.rect.Width = Width - (float) Unit.Width;
          rectCaption.rectText.Width = rectCaption.rect.Width;
        }
        else
        {
          num5 = (float) Unit.Width;
          rectUnit.RoundType = RoundRectangleType.RoundRectRight;
          rectUnit.rect.X = Width - (float) Unit.Width;
          rectUnit.rect.Y = 0.0f;
          rectUnit.rect.Width = (float) Unit.Width;
          rectUnit.rect.Height = Height;
        }
        rectUnit.rectText = new RectangleF(rectUnit.rect.X, rectUnit.rect.Y, rectUnit.rect.Width, rectUnit.rect.Height);
      }
      else
      {
        num5 = (float) Unit.Width;
        rectUnit.rect.X = Width - (float) Unit.Width;
        rectUnit.rect.Y = 0.0f;
        rectUnit.rect.Width = (float) Unit.Width;
        rectUnit.rect.Height = Height;
        rectUnit.rectText = new RectangleF(rectUnit.rect.X, rectUnit.rect.Y, rectUnit.rect.Width, rectUnit.rect.Height);
      }
    }
    else
    {
      num5 = 0.0f;
      rectUnit = new rectDraw();
      rectUnit.rectText = new RectangleF();
    }
    if (CaptionTick.Visible & Caption.Visible)
    {
      if (!CaptionTick.RightSide)
      {
        rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
        rectCheckTick.rect.X = rectCaption.rect.X + (float) (int) Geo.Space + (float) CaptionTick.Space;
        rectCheckTick.rect.Y = (float) (int) (((double) rectCaption.rect.Height - (double) CaptionTick.BoxSize) / 2.0);
        rectCheckTick.rect.Width = (float) CaptionTick.BoxSize;
        rectCheckTick.rect.Height = (float) CaptionTick.BoxSize;
        rectCaption.rectText.X = (float) ((double) rectCheckTick.rect.X + (double) rectCheckTick.rect.Width + (double) Geo.Space * 2.0);
        rectCaption.rectText.Width = rectCaption.rect.Width - rectCaption.rectText.X;
      }
      else if (Unit.Visible)
      {
        if (!Caption.OnTop)
        {
          rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
          rectCheckTick.rect.X = rectUnit.rect.Width + rectUnit.rect.X - (float) CaptionTick.BoxSize - (float) (int) Geo.Space - (float) CaptionTick.Space;
          rectCheckTick.rect.Y = (float) (int) (((double) rectCaption.rect.Height - (double) CaptionTick.BoxSize) / 2.0);
          rectCheckTick.rect.Width = (float) CaptionTick.BoxSize;
          rectCheckTick.rect.Height = (float) CaptionTick.BoxSize;
          rectUnit.rectText.Width = rectUnit.rect.Width - (float) CaptionTick.BoxSize - (float) CaptionTick.Space - Geo.Space;
        }
        else
        {
          rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
          rectCheckTick.rect.X = rectCaption.rect.Width - (float) CaptionTick.BoxSize - (float) (int) Geo.Space - (float) CaptionTick.Space;
          rectCheckTick.rect.Y = (float) (int) (((double) rectCaption.rect.Height - (double) CaptionTick.BoxSize) / 2.0);
          rectCheckTick.rect.Width = (float) CaptionTick.BoxSize;
          rectCheckTick.rect.Height = (float) CaptionTick.BoxSize;
          rectCaption.rectText.Width = rectCaption.rect.Width - (float) CaptionTick.BoxSize - (float) CaptionTick.Space - Geo.Space;
        }
      }
      else if (!Caption.OnTop)
      {
        rectUnit.rect.Width = (float) (CaptionTick.BoxSize + 6);
        rectUnit.rect.X = Width - rectUnit.rect.Width;
        rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
        rectCheckTick.rect.X = rectUnit.rect.X + (float) CaptionTick.Space;
        rectCheckTick.rect.Y = (float) (int) (((double) rectCaption.rect.Height - (double) CaptionTick.BoxSize) / 2.0);
        rectCheckTick.rect.Width = (float) CaptionTick.BoxSize;
        rectCheckTick.rect.Height = (float) CaptionTick.BoxSize;
        rectUnit.rectText.Width = 0.0f;
      }
      else
      {
        rectCheckTick.RoundType = RoundRectangleType.RoundRectAll;
        rectCheckTick.rect.X = rectCaption.rect.Width - (float) CaptionTick.BoxSize - (float) (int) Geo.Space - (float) CaptionTick.Space;
        rectCheckTick.rect.Y = (float) (int) (((double) rectCaption.rect.Height - (double) CaptionTick.BoxSize) / 2.0);
        rectCheckTick.rect.Width = (float) CaptionTick.BoxSize;
        rectCheckTick.rect.Height = (float) CaptionTick.BoxSize;
        rectCaption.rectText.Width = rectCaption.rect.Width - (float) CaptionTick.BoxSize - (float) CaptionTick.Space - Geo.Space;
      }
      rectCheckTick.rectText = new RectangleF(rectCheckTick.rect.X - 8f, rectCheckTick.rect.Y, rectCheckTick.rect.Width + 16f, rectCheckTick.rect.Height);
    }
    else
    {
      rectCheckTick.rect = new RectangleF();
      rectCheckTick.rectText = new RectangleF();
    }
    if (!Caption.Visible)
    {
      areaControl.X = 0.0f;
      areaControl.Y = 0.0f;
      areaControl.Width = Width;
      areaControl.Height = Height;
      if (!Unit.Visible)
        return;
      areaControl.X = 0.0f;
      areaControl.Y = 0.0f;
      areaControl.Width = Width - (float) Unit.Width;
      areaControl.Height = Height;
    }
    else if (!Caption.OnTop)
    {
      areaControl.X = (float) Caption.Width;
      areaControl.Y = 0.0f;
      areaControl.Width = Width - num3 - num5;
      areaControl.Height = Height;
    }
    else
    {
      float num6 = (float) ((double) Height * (double) num2 - (double) Geo.ArcDiameter * (double) num2 + 1.0);
      areaControl.X = 0.0f;
      areaControl.Y = num6;
      areaControl.Width = Width;
      areaControl.Height = Height - num6;
    }
  }

  public static string LanguageSelect(buControlLanguage Lang, string OrjText)
  {
    string str = OrjText;
    if (Lang.MultiLanguageEnable)
    {
      if (Lang.SelectedLanguage == 0 | Lang.SelectedLanguage == 1)
        str = Lang.Language1;
      if (Lang.SelectedLanguage == 2)
        str = Lang.Language2;
      if (Lang.SelectedLanguage == 3)
        str = Lang.Language3;
      if (Lang.SelectedLanguage == 4)
        str = Lang.Language4;
      if (Lang.SelectedLanguage == 5)
        str = Lang.Language5;
      if (Lang.SelectedLanguage == 6)
        str = Lang.Language6;
    }
    return str;
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

  public static GraphicsPath RoundRect(System.Drawing.Rectangle Rectangle, int Curve)
  {
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 0.0f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 90f, 90f);
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundRect(RectangleF Rectangle, int Curve)
  {
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(Rectangle.X, Rectangle.Y, (float) num, (float) num), -180f, 90f);
    graphicsPath.AddArc(new RectangleF(Rectangle.Width - (float) num + Rectangle.X, Rectangle.Y, (float) num, (float) num), -90f, 90f);
    graphicsPath.AddArc(new RectangleF(Rectangle.Width - (float) num + Rectangle.X, Rectangle.Height - (float) num + Rectangle.Y, (float) num, (float) num), 0.0f, 90f);
    graphicsPath.AddArc(new RectangleF(Rectangle.X, Rectangle.Height - (float) num + Rectangle.Y, (float) num, (float) num), 90f, 90f);
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundRectByType(
    System.Drawing.Rectangle Rectangle,
    int Curve,
    RoundRectangleType Type)
  {
    GraphicsPath graphicsPath1 = new GraphicsPath();
    GraphicsPath graphicsPath2;
    if (Type == RoundRectangleType.RoundRectAll)
      graphicsPath2 = ControlGeometry.RoundRect(Rectangle, Curve);
    else if (Type == RoundRectangleType.RoundRectLeft)
      graphicsPath2 = ControlGeometry.RoundLeftRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectRight)
      graphicsPath2 = ControlGeometry.RoundRightRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectUp)
      graphicsPath2 = ControlGeometry.RoundUpRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectDown)
      graphicsPath2 = ControlGeometry.RoundDownRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectDown)
    {
      graphicsPath1.AddRectangle(Rectangle);
      graphicsPath2 = graphicsPath1;
    }
    else
      graphicsPath2 = graphicsPath1;
    return graphicsPath2;
  }

  public static GraphicsPath RoundRectByType(
    RectangleF Rectangle,
    int Curve,
    RoundRectangleType Type)
  {
    GraphicsPath graphicsPath1 = new GraphicsPath();
    GraphicsPath graphicsPath2;
    if (Type == RoundRectangleType.RoundRectAll)
      graphicsPath2 = ControlGeometry.RoundRect(Rectangle, Curve);
    else if (Type == RoundRectangleType.RoundRectLeft)
      graphicsPath2 = ControlGeometry.RoundLeftRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectRight)
      graphicsPath2 = ControlGeometry.RoundRightRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectUp)
      graphicsPath2 = ControlGeometry.RoundUpRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectDown)
      graphicsPath2 = ControlGeometry.RoundDownRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Curve);
    else if (Type == RoundRectangleType.RoundRectDown)
    {
      graphicsPath1.AddRectangle(Rectangle);
      graphicsPath2 = graphicsPath1;
    }
    else
      graphicsPath2 = graphicsPath1;
    return graphicsPath2;
  }

  public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
  {
    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.X, rectangle.Y, num, num), -180f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.Width - num + rectangle.X, rectangle.Y, num, num), -90f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.Width - num + rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 0.0f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 90f, 90f);
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundRect(float X, float Y, float Width, float Height, int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, (float) num, (float) num), -180f, 90f);
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Y, (float) num, (float) num), -90f, 90f);
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 0.0f, 90f);
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 90f, 90f);
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundUpRect(int X, int Y, int Width, int Height, int Curve)
  {
    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.X, rectangle.Y, num, num), -180f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.Width - num + rectangle.X, rectangle.Y, num, num), -90f, 90f);
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
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, (float) num, (float) num), -180f, 90f);
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Y, (float) num, (float) num), -90f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + (float) Curve), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundDownRect(int X, int Y, int Width, int Height, int Curve)
  {
    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.Width - num + rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 0.0f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 90f, 90f);
    graphicsPath.AddLine(new Point(rectangle.X, rectangle.Height - num + rectangle.Y), new Point(rectangle.X, rectangle.Y));
    graphicsPath.AddLine(new Point(rectangle.X, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundDownRect(
    float X,
    float Y,
    float Width,
    float Height,
    int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 0.0f, 90f);
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 90f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y), new PointF(rectangleF.X, rectangleF.Y));
    graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundRightRect(int X, int Y, int Width, int Height, int Curve)
  {
    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.Width - num + rectangle.X, rectangle.Y, num, num), -90f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.Width - num + rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 0.0f, 90f);
    graphicsPath.AddLine(new Point(rectangle.X + rectangle.Width - Curve, rectangle.Y + rectangle.Height), new Point(rectangle.X, rectangle.Y + rectangle.Height));
    graphicsPath.AddLine(new Point(rectangle.X, rectangle.Y + rectangle.Height), new Point(rectangle.X, rectangle.Y));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundRightRect(
    float X,
    float Y,
    float Width,
    float Height,
    int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Y, (float) num, (float) num), -90f, 90f);
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 0.0f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width - (float) Curve, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
    graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundLeftRect(int X, int Y, int Width, int Height, int Curve)
  {
    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 90f, 90f);
    graphicsPath.AddArc(new System.Drawing.Rectangle(rectangle.X, rectangle.Y, num, num), -180f, 90f);
    graphicsPath.AddLine(new Point(rectangle.X + Curve, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y));
    graphicsPath.AddLine(new Point(rectangle.X + rectangle.Width, rectangle.Y), new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundLeftRect(
    float X,
    float Y,
    float Width,
    float Height,
    int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 90f, 90f);
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, (float) num, (float) num), -180f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X + (float) Curve, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundRightUpRect(
    float X,
    float Y,
    float Width,
    float Height,
    int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Y, (float) num, (float) num), -90f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + (float) Curve), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width - (float) Curve, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
    graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundRightDownRect(
    float X,
    float Y,
    float Width,
    float Height,
    int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.Width - (float) num + rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 0.0f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width - (float) Curve, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
    graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y));
    graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundLeftDownRect(
    float X,
    float Y,
    float Width,
    float Height,
    int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Height - (float) num + rectangleF.Y, (float) num, (float) num), 90f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height - (float) Curve), new PointF(rectangleF.X, rectangleF.Y));
    graphicsPath.AddLine(new PointF(rectangleF.X + (float) Curve, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath RoundLeftUpRect(
    float X,
    float Y,
    float Width,
    float Height,
    int Curve)
  {
    RectangleF rectangleF = new RectangleF(X, Y, Width, Height);
    GraphicsPath graphicsPath = new GraphicsPath();
    int num = Curve * 2;
    graphicsPath.AddArc(new RectangleF(rectangleF.X, rectangleF.Y, (float) num, (float) num), -180f, 90f);
    graphicsPath.AddLine(new PointF(rectangleF.X + (float) Curve, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y));
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y), new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height));
    graphicsPath.AddLine(new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height), new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height));
    graphicsPath.CloseFigure();
    return graphicsPath;
  }
}
