// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.Utilities
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

#nullable disable
namespace DevAge.Drawing;

public static class Utilities
{
  private static ImageAttributes imageAttributes_0;

  public static void DrawRoundedRectangle(Graphics g, RoundedRectangle roundRect, Pen pen)
  {
    int width1 = (int) pen.Width;
    Rectangle rect;
    ref Rectangle local = ref rect;
    Rectangle rectangle = roundRect.Rectangle;
    int x = rectangle.X + width1 / 2;
    rectangle = roundRect.Rectangle;
    int y = rectangle.Y + width1 / 2;
    rectangle = roundRect.Rectangle;
    int width2 = rectangle.Width - width1;
    rectangle = roundRect.Rectangle;
    int height = rectangle.Height - width1;
    local = new Rectangle(x, y, width2, height);
    RoundedRectangle roundedRectangle = new RoundedRectangle(rect, roundRect.RoundValue);
    g.DrawPath(pen, roundedRectangle.ToGraphicsPath());
  }

  public static void FillRoundedRectangle(Graphics g, RoundedRectangle roundRect, Brush brush)
  {
    Rectangle rect;
    ref Rectangle local = ref rect;
    Rectangle rectangle = roundRect.Rectangle;
    int x = rectangle.X;
    rectangle = roundRect.Rectangle;
    int y = rectangle.Y;
    rectangle = roundRect.Rectangle;
    int width = rectangle.Width - 1;
    rectangle = roundRect.Rectangle;
    int height = rectangle.Height - 1;
    local = new Rectangle(x, y, width, height);
    RoundedRectangle roundedRectangle = new RoundedRectangle(rect, roundRect.RoundValue);
    g.FillRegion(brush, new Region(roundedRectangle.ToGraphicsPath()));
  }

  public static void DrawGradient3DBorder(
    Graphics g,
    Rectangle p_HeaderRectangle,
    Color p_BackColor,
    Color p_DarkColor,
    Color p_LightColor,
    int p_DarkGradientNumber,
    int p_LightGradientNumber,
    Gradient3DBorderStyle p_Style)
  {
    Color p_EndColor1;
    int p_NumberOfGradients1;
    Color p_EndColor2;
    int p_NumberOfGradients2;
    if (p_Style == Gradient3DBorderStyle.Raised)
    {
      p_EndColor1 = p_LightColor;
      p_NumberOfGradients1 = p_LightGradientNumber;
      p_EndColor2 = p_DarkColor;
      p_NumberOfGradients2 = p_DarkGradientNumber;
    }
    else
    {
      p_EndColor1 = p_DarkColor;
      p_NumberOfGradients1 = p_DarkGradientNumber;
      p_EndColor2 = p_LightColor;
      p_NumberOfGradients2 = p_LightGradientNumber;
    }
    Color[] colorGradient1 = Utilities.CalculateColorGradient(p_BackColor, p_EndColor1, p_NumberOfGradients1);
    using (Pen pen = new Pen(colorGradient1[0]))
    {
      for (int index = 0; index < colorGradient1.Length; ++index)
      {
        pen.Color = colorGradient1[colorGradient1.Length - (index + 1)];
        g.DrawLine(pen, p_HeaderRectangle.Left + index, p_HeaderRectangle.Top + index, p_HeaderRectangle.Right - (index + 1), p_HeaderRectangle.Top + index);
        g.DrawLine(pen, p_HeaderRectangle.Left + index, p_HeaderRectangle.Top + index, p_HeaderRectangle.Left + index, p_HeaderRectangle.Bottom - (index + 1));
      }
    }
    Color[] colorGradient2 = Utilities.CalculateColorGradient(p_BackColor, p_EndColor2, p_NumberOfGradients2);
    using (Pen pen = new Pen(colorGradient2[0]))
    {
      for (int index = 0; index < colorGradient2.Length; ++index)
      {
        pen.Color = colorGradient2[colorGradient2.Length - (index + 1)];
        g.DrawLine(pen, p_HeaderRectangle.Left + index, p_HeaderRectangle.Bottom - (index + 1), p_HeaderRectangle.Right - (index + 1), p_HeaderRectangle.Bottom - (index + 1));
        g.DrawLine(pen, p_HeaderRectangle.Right - (index + 1), p_HeaderRectangle.Top + index, p_HeaderRectangle.Right - (index + 1), p_HeaderRectangle.Bottom - (index + 1));
      }
    }
  }

  public static Color[] CalculateColorGradient(
    Color p_StartColor,
    Color p_EndColor,
    int p_NumberOfGradients)
  {
    Color[] colorGradient = p_NumberOfGradients >= 2 ? new Color[p_NumberOfGradients] : throw new ArgumentException("Invalid Number of gradients, must be 2 or more");
    colorGradient[0] = p_StartColor;
    colorGradient[colorGradient.Length - 1] = p_EndColor;
    float num1 = (float) ((int) p_EndColor.A - (int) p_StartColor.A) / (float) p_NumberOfGradients;
    float num2 = (float) ((int) p_EndColor.R - (int) p_StartColor.R) / (float) p_NumberOfGradients;
    float num3 = (float) ((int) p_EndColor.G - (int) p_StartColor.G) / (float) p_NumberOfGradients;
    float num4 = (float) ((int) p_EndColor.B - (int) p_StartColor.B) / (float) p_NumberOfGradients;
    for (int index = 1; index < colorGradient.Length - 1; ++index)
      colorGradient[index] = Color.FromArgb((int) ((double) p_StartColor.A + (double) num1 * (double) index), (int) ((double) p_StartColor.R + (double) num2 * (double) index), (int) ((double) p_StartColor.G + (double) num3 * (double) index), (int) ((double) p_StartColor.B + (double) num4 * (double) index));
    return colorGradient;
  }

  public static Color CalculateMiddleColor(Color p_StartColor, Color p_EndColor)
  {
    return Utilities.CalculateColorGradient(p_StartColor, p_EndColor, 3)[1];
  }

  public static Color CalculateLightDarkColor(Color source, float light)
  {
    Color lightDarkColor;
    if ((double) light == 0.0)
    {
      lightDarkColor = source;
    }
    else
    {
      if (((double) light > 1.0 ? 1 : ((double) light < -1.0 ? 1 : 0)) != 0)
        throw new ArgumentException("Must be between 1 and -1", nameof (light));
      float num1;
      float num2;
      float num3;
      if ((double) light < 0.0)
      {
        num1 = (float) source.R / 100f;
        num2 = (float) source.G / 100f;
        num3 = (float) source.B / 100f;
      }
      else
      {
        num1 = (float) ((int) byte.MaxValue - (int) source.R) / 100f;
        num2 = (float) ((int) byte.MaxValue - (int) source.G) / 100f;
        num3 = (float) ((int) byte.MaxValue - (int) source.B) / 100f;
      }
      int red = (int) source.R + (int) ((double) num1 * (double) light * 100.0);
      int green = (int) source.G + (int) ((double) num2 * (double) light * 100.0);
      int blue = (int) source.B + (int) ((double) num3 * (double) light * 100.0);
      if (red > (int) byte.MaxValue)
        red = (int) byte.MaxValue;
      else if (red < 0)
        red = 0;
      if (green > (int) byte.MaxValue)
        green = (int) byte.MaxValue;
      else if (green < 0)
        green = 0;
      if (blue > (int) byte.MaxValue)
        blue = (int) byte.MaxValue;
      else if (blue < 0)
        blue = 0;
      lightDarkColor = Color.FromArgb((int) source.A, red, green, blue);
    }
    return lightDarkColor;
  }

  public static ContentAlignment StringFormatToContentAlignment(StringFormat p_StringFormat)
  {
    return (!Utilities.IsBottom(p_StringFormat) ? 0 : (Utilities.IsLeft(p_StringFormat) ? 1 : 0)) == 0 ? ((!Utilities.IsBottom(p_StringFormat) ? 0 : (Utilities.IsRight(p_StringFormat) ? 1 : 0)) == 0 ? ((!Utilities.IsBottom(p_StringFormat) ? 0 : (Utilities.IsCenter(p_StringFormat) ? 1 : 0)) == 0 ? ((!Utilities.IsTop(p_StringFormat) ? 0 : (Utilities.IsLeft(p_StringFormat) ? 1 : 0)) == 0 ? ((!Utilities.IsTop(p_StringFormat) ? 0 : (Utilities.IsRight(p_StringFormat) ? 1 : 0)) == 0 ? ((!Utilities.IsTop(p_StringFormat) ? 0 : (Utilities.IsCenter(p_StringFormat) ? 1 : 0)) == 0 ? ((!Utilities.IsMiddle(p_StringFormat) ? 0 : (Utilities.IsLeft(p_StringFormat) ? 1 : 0)) == 0 ? ((!Utilities.IsMiddle(p_StringFormat) ? 0 : (Utilities.IsRight(p_StringFormat) ? 1 : 0)) == 0 ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleRight) : ContentAlignment.MiddleLeft) : ContentAlignment.TopCenter) : ContentAlignment.TopRight) : ContentAlignment.TopLeft) : ContentAlignment.BottomCenter) : ContentAlignment.BottomRight) : ContentAlignment.BottomLeft;
  }

  public static void ApplyContentAlignmentToStringFormat(
    ContentAlignment pAlignment,
    StringFormat stringFormat)
  {
    stringFormat.LineAlignment = !Utilities.IsBottom(pAlignment) ? (!Utilities.IsMiddle(pAlignment) ? StringAlignment.Near : StringAlignment.Center) : StringAlignment.Far;
    if (Utilities.IsRight(pAlignment))
      stringFormat.Alignment = StringAlignment.Far;
    else if (Utilities.IsCenter(pAlignment))
      stringFormat.Alignment = StringAlignment.Center;
    else
      stringFormat.Alignment = StringAlignment.Near;
  }

  public static bool IsBottom(ContentAlignment a)
  {
    return a == ContentAlignment.BottomCenter || a == ContentAlignment.BottomLeft || a == ContentAlignment.BottomRight;
  }

  public static bool IsTop(ContentAlignment a)
  {
    return a == ContentAlignment.TopCenter || a == ContentAlignment.TopLeft || a == ContentAlignment.TopRight;
  }

  public static bool IsMiddle(ContentAlignment a)
  {
    return a == ContentAlignment.MiddleCenter || a == ContentAlignment.MiddleLeft || a == ContentAlignment.MiddleRight;
  }

  public static bool IsCenter(ContentAlignment a)
  {
    return a == ContentAlignment.BottomCenter || a == ContentAlignment.MiddleCenter || a == ContentAlignment.TopCenter;
  }

  public static bool IsLeft(ContentAlignment a)
  {
    return a == ContentAlignment.BottomLeft || a == ContentAlignment.MiddleLeft || a == ContentAlignment.TopLeft;
  }

  public static bool IsRight(ContentAlignment a)
  {
    return a == ContentAlignment.BottomRight || a == ContentAlignment.MiddleRight || a == ContentAlignment.TopRight;
  }

  public static bool IsBottom(StringFormat a) => a.LineAlignment == StringAlignment.Far;

  public static bool IsTop(StringFormat a) => a.LineAlignment == StringAlignment.Near;

  public static bool IsMiddle(StringFormat a) => a.LineAlignment == StringAlignment.Center;

  public static bool IsCenter(StringFormat a) => a.Alignment == StringAlignment.Center;

  public static bool IsLeft(StringFormat a) => a.Alignment == StringAlignment.Near;

  public static bool IsRight(StringFormat a) => a.Alignment == StringAlignment.Far;

  public static byte[] ImageToBytes(Image img, ImageFormat imgFormat)
  {
    byte[] bytes;
    if (img == null)
    {
      bytes = new byte[0];
    }
    else
    {
      byte[] array;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        img.Save((Stream) memoryStream, imgFormat);
        array = memoryStream.ToArray();
      }
      bytes = array;
    }
    return bytes;
  }

  public static Image BytesToImage(byte[] bytes)
  {
    Image image1;
    if ((bytes == null ? 1 : (bytes.Length == 0 ? 1 : 0)) != 0)
    {
      image1 = (Image) null;
    }
    else
    {
      Image image2;
      using (MemoryStream memoryStream = new MemoryStream(bytes))
        image2 = Image.FromStream((Stream) memoryStream);
      image1 = image2;
    }
    return image1;
  }

  public static Image CreateDisabledImage(Image image, Color background)
  {
    Image disabledImage;
    if (image == null)
    {
      disabledImage = (Image) null;
    }
    else
    {
      Size size = image.Size;
      if (Utilities.imageAttributes_0 == null)
      {
        float[][] newColorMatrix1 = new float[5][]
        {
          new float[5]{ 0.2125f, 0.2125f, 0.2125f, 0.0f, 0.0f },
          new float[5]{ 0.2577f, 0.2577f, 0.2577f, 0.0f, 0.0f },
          new float[5]{ 0.0361f, 0.0361f, 0.0361f, 0.0f, 0.0f },
          null,
          null
        };
        float[] numArray = new float[5]
        {
          0.0f,
          0.0f,
          0.0f,
          1f,
          0.0f
        };
        newColorMatrix1[3] = numArray;
        newColorMatrix1[4] = new float[5]
        {
          0.38f,
          0.38f,
          0.38f,
          0.0f,
          1f
        };
        ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix1);
        Utilities.imageAttributes_0 = new ImageAttributes();
        Utilities.imageAttributes_0.ClearColorKey();
        Utilities.imageAttributes_0.SetColorMatrix(newColorMatrix2);
      }
      Bitmap bitmap = new Bitmap(image.Width, image.Height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        graphics.DrawImage(image, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, Utilities.imageAttributes_0);
      disabledImage = (Image) bitmap;
    }
    return disabledImage;
  }

  public static SizeF CheckMeasure(SizeF measureSize, SizeF minSize, SizeF maxSize)
  {
    if (((double) minSize.Width <= 0.0 ? 0 : ((double) measureSize.Width < (double) minSize.Width ? 1 : 0)) != 0)
      measureSize.Width = minSize.Width;
    if (((double) minSize.Height <= 0.0 ? 0 : ((double) measureSize.Height < (double) minSize.Height ? 1 : 0)) != 0)
      measureSize.Height = minSize.Height;
    if (((double) maxSize.Width <= 0.0 ? 0 : ((double) measureSize.Width > (double) maxSize.Width ? 1 : 0)) != 0)
      measureSize.Width = maxSize.Width;
    if (((double) maxSize.Height <= 0.0 ? 0 : ((double) measureSize.Height > (double) maxSize.Height ? 1 : 0)) != 0)
      measureSize.Height = maxSize.Height;
    return measureSize;
  }

  public static Size SizeFToSize(SizeF sizef)
  {
    return new Size((int) Math.Ceiling((double) sizef.Width), (int) Math.Ceiling((double) sizef.Height));
  }
}
