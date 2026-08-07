// Decompiled with JetBrains decompiler
// Type: buCore.CMYK
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System.Drawing;

#nullable disable
namespace buCore;

public class CMYK
{
  public double C = 0.0;
  public double M = 0.0;
  public double Y = 0.0;
  public double K = 0.0;

  public static CMYK RGBtoCMYK(Color c)
  {
    CMYK cmyk = new CMYK();
    double num = 1.0;
    cmyk.C = (double) ((int) byte.MaxValue - (int) c.R) / (double) byte.MaxValue;
    if (num > cmyk.C)
      num = cmyk.C;
    cmyk.M = (double) ((int) byte.MaxValue - (int) c.G) / (double) byte.MaxValue;
    if (num > cmyk.M)
      num = cmyk.M;
    cmyk.Y = (double) ((int) byte.MaxValue - (int) c.B) / (double) byte.MaxValue;
    if (num > cmyk.Y)
      num = cmyk.Y;
    if (num > 0.0)
      cmyk.K = num;
    return cmyk;
  }

  public static Color CMYKtoRGB(CMYK _cmyk)
  {
    return Color.FromArgb(CMYK.Round((double) byte.MaxValue - (double) byte.MaxValue * _cmyk.C), CMYK.Round((double) byte.MaxValue - (double) byte.MaxValue * _cmyk.M), CMYK.Round((double) byte.MaxValue - (double) byte.MaxValue * _cmyk.Y));
  }

  public static int Round(double val)
  {
    int num = (int) val;
    if ((int) (val * 100.0) % 100 >= 50)
      ++num;
    return num;
  }
}
