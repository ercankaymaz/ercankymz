// Decompiled with JetBrains decompiler
// Type: buCore.buImage
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

#nullable disable
namespace buCore;

public class buImage
{
  public buImage()
  {
    if (!buVector.smethod_0(nameof (buImage)))
      throw new RegisterException(nameof (buImage));
  }

  public static Color InvertColor(Color BaseColor)
  {
    buVector.smethod_0(nameof (buImage));
    return Color.FromArgb((int) byte.MaxValue - (int) BaseColor.R, (int) byte.MaxValue - (int) BaseColor.G, (int) byte.MaxValue - (int) BaseColor.B);
  }

  public static Color InvertColorNoGray(Color BaseColor)
  {
    byte red = ~BaseColor.R;
    byte green = ~BaseColor.G;
    byte blue = ~BaseColor.B;
    Color color = Color.FromArgb((int) BaseColor.A, (int) red, (int) green, (int) blue);
    if (Math.Abs(Convert.ToInt32(BaseColor.R) - Convert.ToInt32(color.R)) < 2 & Math.Abs(Convert.ToInt32(BaseColor.G) - Convert.ToInt32(color.G)) < 2 & Math.Abs(Convert.ToInt32(BaseColor.B) - Convert.ToInt32(color.B)) < 2)
      color = Color.Black;
    return color;
  }

  public static void GetKnowColorToList(ref List<Color> ColorList)
  {
    ColorList.Clear();
    foreach (string name in Enum.GetNames(typeof (KnownColor)))
    {
      Color color = Color.FromName(name);
      ColorList.Add(color);
    }
  }

  public static Color ColorFromBool(bool State, Color TrueColor, Color FalseColor)
  {
    buVector.smethod_0("");
    return !State ? FalseColor : TrueColor;
  }

  public static void GetPopularKnowColorToList(ref List<Color> ColorList)
  {
    ColorList.Clear();
    ColorList.Add(Color.Red);
    ColorList.Add(Color.Blue);
    ColorList.Add(Color.Green);
    ColorList.Add(Color.Gold);
    ColorList.Add(Color.DarkOrange);
    ColorList.Add(Color.Cyan);
    ColorList.Add(Color.Brown);
    ColorList.Add(Color.Lime);
    ColorList.Add(Color.Magenta);
    ColorList.Add(Color.Linen);
    ColorList.Add(Color.Tan);
    ColorList.Add(Color.Pink);
    ColorList.Add(Color.AliceBlue);
    ColorList.Add(Color.Turquoise);
    ColorList.Add(Color.Purple);
    ColorList.Add(Color.DarkBlue);
    ColorList.Add(Color.Beige);
    ColorList.Add(Color.RosyBrown);
    ColorList.Add(Color.LightSalmon);
    ColorList.Add(Color.AntiqueWhite);
    ColorList.Add(Color.LightSeaGreen);
    ColorList.Add(Color.Aqua);
    ColorList.Add(Color.LightSkyBlue);
    ColorList.Add(Color.Aquamarine);
    ColorList.Add(Color.Azure);
    ColorList.Add(Color.LightSteelBlue);
    ColorList.Add(Color.LightYellow);
    ColorList.Add(Color.Bisque);
    ColorList.Add(Color.LimeGreen);
    ColorList.Add(Color.BlanchedAlmond);
    ColorList.Add(Color.BlueViolet);
    ColorList.Add(Color.Maroon);
    ColorList.Add(Color.MediumAquamarine);
    ColorList.Add(Color.BurlyWood);
    ColorList.Add(Color.MediumBlue);
    ColorList.Add(Color.CadetBlue);
    ColorList.Add(Color.MediumOrchid);
    ColorList.Add(Color.Chartreuse);
    ColorList.Add(Color.MediumPurple);
    ColorList.Add(Color.Chocolate);
    ColorList.Add(Color.MediumSeaGreen);
    ColorList.Add(Color.Coral);
    ColorList.Add(Color.MediumSlateBlue);
    ColorList.Add(Color.CornflowerBlue);
    ColorList.Add(Color.MediumSpringGreen);
    ColorList.Add(Color.Cornsilk);
    ColorList.Add(Color.MediumTurquoise);
    ColorList.Add(Color.Crimson);
    ColorList.Add(Color.MediumVioletRed);
    ColorList.Add(Color.MidnightBlue);
    ColorList.Add(Color.MintCream);
    ColorList.Add(Color.DarkCyan);
    ColorList.Add(Color.MistyRose);
    ColorList.Add(Color.DarkGoldenrod);
    ColorList.Add(Color.Moccasin);
    ColorList.Add(Color.NavajoWhite);
    ColorList.Add(Color.DarkGreen);
    ColorList.Add(Color.Navy);
    ColorList.Add(Color.DarkKhaki);
    ColorList.Add(Color.OldLace);
    ColorList.Add(Color.DarkMagenta);
    ColorList.Add(Color.Olive);
    ColorList.Add(Color.DarkOliveGreen);
    ColorList.Add(Color.OliveDrab);
    ColorList.Add(Color.Orange);
    ColorList.Add(Color.DarkOrchid);
    ColorList.Add(Color.OrangeRed);
    ColorList.Add(Color.DarkRed);
    ColorList.Add(Color.Orchid);
    ColorList.Add(Color.DarkSalmon);
    ColorList.Add(Color.PaleGoldenrod);
    ColorList.Add(Color.DarkSeaGreen);
    ColorList.Add(Color.PaleGreen);
    ColorList.Add(Color.DarkSlateBlue);
    ColorList.Add(Color.PaleTurquoise);
    ColorList.Add(Color.PaleVioletRed);
    ColorList.Add(Color.DarkTurquoise);
    ColorList.Add(Color.PapayaWhip);
    ColorList.Add(Color.DarkViolet);
    ColorList.Add(Color.PeachPuff);
    ColorList.Add(Color.DeepPink);
    ColorList.Add(Color.Peru);
    ColorList.Add(Color.DeepSkyBlue);
    ColorList.Add(Color.Plum);
    ColorList.Add(Color.DodgerBlue);
    ColorList.Add(Color.PowderBlue);
    ColorList.Add(Color.Firebrick);
    ColorList.Add(Color.FloralWhite);
    ColorList.Add(Color.ForestGreen);
    ColorList.Add(Color.Fuchsia);
    ColorList.Add(Color.RoyalBlue);
    ColorList.Add(Color.Gainsboro);
    ColorList.Add(Color.SaddleBrown);
    ColorList.Add(Color.GhostWhite);
    ColorList.Add(Color.Salmon);
    ColorList.Add(Color.SandyBrown);
    ColorList.Add(Color.Goldenrod);
    ColorList.Add(Color.SeaGreen);
    ColorList.Add(Color.SeaShell);
    ColorList.Add(Color.Sienna);
    ColorList.Add(Color.GreenYellow);
    ColorList.Add(Color.Silver);
    ColorList.Add(Color.Honeydew);
    ColorList.Add(Color.SkyBlue);
    ColorList.Add(Color.HotPink);
    ColorList.Add(Color.SlateBlue);
    ColorList.Add(Color.IndianRed);
    ColorList.Add(Color.Indigo);
    ColorList.Add(Color.Snow);
    ColorList.Add(Color.Ivory);
    ColorList.Add(Color.SpringGreen);
    ColorList.Add(Color.Khaki);
    ColorList.Add(Color.SteelBlue);
    ColorList.Add(Color.Lavender);
    ColorList.Add(Color.LavenderBlush);
    ColorList.Add(Color.Teal);
    ColorList.Add(Color.Thistle);
    ColorList.Add(Color.LemonChiffon);
    ColorList.Add(Color.Tomato);
    ColorList.Add(Color.LightBlue);
    ColorList.Add(Color.LightCoral);
    ColorList.Add(Color.Violet);
    ColorList.Add(Color.LightCyan);
    ColorList.Add(Color.Wheat);
    ColorList.Add(Color.LightGoldenrodYellow);
    ColorList.Add(Color.LightGreen);
    ColorList.Add(Color.WhiteSmoke);
    ColorList.Add(Color.Yellow);
    ColorList.Add(Color.LightPink);
    ColorList.Add(Color.YellowGreen);
  }

  public static void GetKnowColorToList(ref List<Color> ColorList, List<Color> Exceptions)
  {
    ColorList.Clear();
    foreach (string name in Enum.GetNames(typeof (KnownColor)))
    {
      bool flag = true;
      Color color = Color.FromName(name);
      for (int index = 0; index <= Exceptions.Count - 1; ++index)
      {
        if (Exceptions[index] == color)
          flag = false;
      }
      if (flag)
        ColorList.Add(color);
    }
  }

  public static string GetColorKnownName(Color clr)
  {
    return !clr.IsKnownColor ? clr.ToString().Replace("Color", "") : clr.ToKnownColor().ToString();
  }

  public static Color ColorToneChange(Color BaseColor, double factor)
  {
    double red = (double) BaseColor.R * factor > (double) byte.MaxValue ? (double) byte.MaxValue : (double) BaseColor.R * factor;
    double green = (double) BaseColor.G * factor > (double) byte.MaxValue ? (double) byte.MaxValue : (double) BaseColor.G * factor;
    double blue = (double) BaseColor.B * factor > (double) byte.MaxValue ? (double) byte.MaxValue : (double) BaseColor.B * factor;
    return Color.FromArgb((int) BaseColor.A, (int) red, (int) green, (int) blue);
  }

  public static void GetImageSizeWithFilename(string FileName, ref int Width, ref int Height)
  {
    Image image = Image.FromFile(FileName);
    Width = image.Width;
    Height = image.Height;
  }

  public static Bitmap ResizeImage(Image image, int width, int height)
  {
    Rectangle destRect = new Rectangle(0, 0, width, height);
    Bitmap bitmap = new Bitmap(width, height);
    bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    using (Graphics graphics = Graphics.FromImage((Image) bitmap))
    {
      graphics.CompositingMode = CompositingMode.SourceCopy;
      graphics.CompositingQuality = CompositingQuality.HighQuality;
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      using (ImageAttributes imageAttr = new ImageAttributes())
      {
        imageAttr.SetWrapMode(WrapMode.TileFlipXY);
        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
      }
    }
    return bitmap;
  }

  public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
  {
    Bitmap bitmap = new Bitmap(width, height);
    using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      graphics.DrawImage((Image) bmp, 0, 0, width, height);
    return bitmap;
  }

  public static Bitmap CropBitmap(Bitmap bmp, int x, int y, int width, int height)
  {
    Rectangle srcRect = new Rectangle(x, y, width, height);
    Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
    Graphics.FromImage((Image) bitmap).DrawImage((Image) bmp, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
    return bitmap;
  }

  public static Bitmap Rotate(Bitmap OriginalImage, double Angle)
  {
    Angle %= 360.0;
    double num1 = (double) (OriginalImage.Width / 2);
    double num2 = (double) (OriginalImage.Height / 2);
    double pi = Math.PI;
    double num3 = Angle * pi / 180.0;
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x1 = 0; x1 < OriginalImage.Width; ++x1)
    {
      for (int y1 = 0; y1 < OriginalImage.Height; ++y1)
      {
        int x2 = (int) (Math.Cos(num3) * ((double) x1 - num1) - Math.Sin(num3) * ((double) y1 - num2) + num1);
        int y2 = (int) (Math.Sin(num3) * ((double) x1 - num1) + Math.Cos(num3) * ((double) y1 - num2) + num2);
        Color color = new Color();
        if ((x2 < 0 ? 1 : (x2 >= OriginalImage.Width ? 1 : 0)) == 0 && (y2 < 0 ? 1 : (y2 >= OriginalImage.Height ? 1 : 0)) == 0)
        {
          Color pixel = OriginalImage.GetPixel(x2, y2);
          bitmap.SetPixel(x1, y1, pixel);
        }
      }
    }
    return bitmap;
  }

  public static bool isColorSimilar(Color BaseColor, Color SimilarColor, double Limit)
  {
    double num1 = Convert.ToDouble(BaseColor.R);
    double num2 = Convert.ToDouble(BaseColor.G);
    double num3 = Convert.ToDouble(BaseColor.B);
    double num4 = Math.Pow(Convert.ToDouble(SimilarColor.R) - num1, 2.0);
    double num5 = Math.Pow(Convert.ToDouble(SimilarColor.G) - num2, 2.0);
    double num6 = Math.Sqrt(Math.Pow(Convert.ToDouble(SimilarColor.B) - num3, 2.0) + num5 + num4);
    bool flag;
    if (num6 == 0.0)
      flag = true;
    else if (num6 < Limit)
    {
      Limit = num6;
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public static bool isColorSAme(Color BaseColor, Color refColor)
  {
    return (int) BaseColor.A == (int) refColor.A && (int) BaseColor.R == (int) refColor.R && (int) BaseColor.G == (int) refColor.G && (int) BaseColor.B == (int) refColor.B;
  }
}
