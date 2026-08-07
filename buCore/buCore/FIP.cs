// Decompiled with JetBrains decompiler
// Type: buCore.FIP
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

#nullable disable
namespace buCore;

public class FIP
{
  public double[,] LPF1()
  {
    return new double[3, 3]
    {
      {
        0.1111,
        0.1111,
        0.1111
      },
      {
        0.1111,
        0.1111,
        0.1111
      },
      {
        0.1111,
        0.1111,
        0.1111
      }
    };
  }

  public double[,] LPF2()
  {
    return new double[3, 3]
    {
      {
        0.1,
        0.1,
        0.1
      },
      {
        0.1,
        0.2,
        0.1
      },
      {
        0.1,
        0.1,
        0.1
      }
    };
  }

  public double[,] LPF3()
  {
    return new double[3, 3]
    {
      {
        1.0 / 16.0,
        0.125,
        1.0 / 16.0
      },
      {
        0.125,
        0.25,
        0.125
      },
      {
        1.0 / 16.0,
        0.125,
        1.0 / 16.0
      }
    };
  }

  public double[,] LPF4()
  {
    return new double[5, 5]
    {
      {
        0.00366,
        0.01465,
        0.02564,
        0.01465,
        0.00366
      },
      {
        0.01465,
        0.05861,
        0.09524,
        0.05861,
        0.01465
      },
      {
        0.02564,
        0.09524,
        0.15018,
        0.09524,
        0.02564
      },
      {
        0.01465,
        0.05861,
        0.09524,
        0.05861,
        0.01465
      },
      {
        0.00366,
        0.01465,
        0.02564,
        0.01465,
        0.00366
      }
    };
  }

  public int[,] HPF1()
  {
    return new int[3, 3]
    {
      {
        -1,
        -1,
        -1
      },
      {
        -1,
        9,
        -1
      },
      {
        -1,
        -1,
        -1
      }
    };
  }

  public int[,] HPF2()
  {
    return new int[3, 3]
    {
      {
        0,
        -1,
        0
      },
      {
        -1,
        5,
        -1
      },
      {
        0,
        -1,
        0
      }
    };
  }

  public int[,] HPF3()
  {
    return new int[3, 3]
    {
      {
        1,
        -2,
        1
      },
      {
        -2,
        5,
        -2
      },
      {
        1,
        -2,
        1
      }
    };
  }

  public int[,] HPF4()
  {
    return new int[5, 5]
    {
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        -1,
        -1,
        25,
        -1,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      }
    };
  }

  public int[,] LaplaceF1()
  {
    return new int[3, 3]
    {
      {
        -1,
        -1,
        -1
      },
      {
        -1,
        8,
        -1
      },
      {
        -1,
        -1,
        -1
      }
    };
  }

  public int[,] LaplaceF2()
  {
    return new int[3, 3]
    {
      {
        0,
        -1,
        0
      },
      {
        -1,
        4,
        -1
      },
      {
        0,
        -1,
        0
      }
    };
  }

  public int[,] LaplaceF3()
  {
    return new int[3, 3]
    {
      {
        1,
        -2,
        1
      },
      {
        -2,
        4,
        -2
      },
      {
        1,
        -2,
        1
      }
    };
  }

  public int[,] LaplaceF4()
  {
    return new int[5, 5]
    {
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        -1,
        -1,
        24,
        -1,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      }
    };
  }

  public double[,] GF1()
  {
    return new double[3, 3]
    {
      {
        1.0 / 16.0,
        0.125,
        1.0 / 16.0
      },
      {
        0.125,
        0.25,
        0.125
      },
      {
        1.0 / 16.0,
        0.125,
        1.0 / 16.0
      }
    };
  }

  public double[,] GF2()
  {
    return new double[5, 5]
    {
      {
        12.0 / 625.0,
        12.0 / 625.0,
        0.0385,
        12.0 / 625.0,
        0.01921
      },
      {
        12.0 / 625.0,
        0.0385,
        0.0769,
        0.0385,
        12.0 / 625.0
      },
      {
        0.0385,
        0.0769,
        0.1538,
        0.0769,
        0.0385
      },
      {
        12.0 / 625.0,
        0.0385,
        0.0769,
        0.0385,
        12.0 / 625.0
      },
      {
        12.0 / 625.0,
        12.0 / 625.0,
        0.0385,
        12.0 / 625.0,
        12.0 / 625.0
      }
    };
  }

  public double[,] GF3()
  {
    return new double[7, 7]
    {
      {
        0.00714,
        0.00714,
        0.01429,
        0.01429,
        0.01429,
        0.00714,
        0.00714
      },
      {
        0.00714,
        0.01429,
        0.01429,
        0.02857,
        0.01429,
        0.01429,
        0.00714
      },
      {
        0.01429,
        0.01429,
        0.02857,
        0.05714,
        0.02857,
        0.01429,
        0.01429
      },
      {
        0.01429,
        0.02857,
        0.05714,
        0.11429,
        0.05714,
        0.02857,
        0.01429
      },
      {
        0.01429,
        0.01429,
        0.02857,
        0.05714,
        0.02857,
        0.01429,
        0.01429
      },
      {
        0.00714,
        0.01429,
        0.01429,
        0.02857,
        0.01429,
        0.01429,
        0.00714
      },
      {
        0.00714,
        0.00714,
        0.01429,
        0.01429,
        0.01429,
        0.00714,
        0.00714
      }
    };
  }

  public Bitmap Resize(Bitmap OriginalImage, int Width, int Height)
  {
    Bitmap bitmap = (Width <= 0 ? 1 : (Height <= 0 ? 1 : 0)) == 0 ? new Bitmap(Width, Height) : throw new Exception("Output image width and height must be positive");
    double num1 = Convert.ToDouble(OriginalImage.Width) / Convert.ToDouble(Width);
    double num2 = Convert.ToDouble(OriginalImage.Height) / Convert.ToDouble(Height);
    for (int x1 = 0; x1 < Width; ++x1)
    {
      for (int y1 = 0; y1 < Height; ++y1)
      {
        int x2 = (int) ((double) x1 * num1);
        int y2 = (int) ((double) y1 * num2);
        if (x2 >= OriginalImage.Width)
          x2 = OriginalImage.Width - 1;
        if (y2 >= OriginalImage.Height)
          y2 = OriginalImage.Height - 1;
        Color pixel = OriginalImage.GetPixel(x2, y2);
        bitmap.SetPixel(x1, y1, pixel);
      }
    }
    return bitmap;
  }

  public Bitmap Resize2(Bitmap OriginalImage, int Width, int Height)
  {
    Bitmap bitmap = (Width <= 0 ? 1 : (Height <= 0 ? 1 : 0)) == 0 ? new Bitmap(Width, Height) : throw new Exception("Output image width and height must be positive");
    double num1 = Convert.ToDouble(OriginalImage.Width) / Convert.ToDouble(Width);
    double num2 = Convert.ToDouble(OriginalImage.Height) / Convert.ToDouble(Height);
    for (int x1 = 0; x1 < Width; ++x1)
    {
      for (int y1 = 0; y1 < Height; ++y1)
      {
        int x2 = (int) ((double) x1 * num1);
        int y2 = (int) ((double) y1 * num2);
        if (x2 >= OriginalImage.Width)
          x2 = OriginalImage.Width - 1;
        if (y2 >= OriginalImage.Height)
          y2 = OriginalImage.Height - 1;
        double d1 = (double) x1 * num1 % (double) x2;
        double d2 = (double) y1 * num2 % (double) y2;
        if (double.IsNaN(d1))
          d1 = 0.0;
        if (double.IsNaN(d2))
          d2 = 0.0;
        int x3 = x2 + 1;
        int y3 = y2 + 1;
        if (x3 >= OriginalImage.Width)
          x3 = x2;
        if (y3 >= OriginalImage.Height)
          y3 = y2;
        Color pixel1 = OriginalImage.GetPixel(x2, y2);
        Color pixel2 = OriginalImage.GetPixel(x3, y2);
        Color pixel3 = OriginalImage.GetPixel(x2, y3);
        Color pixel4 = OriginalImage.GetPixel(x3, y3);
        double num3 = (1.0 - d1) * (double) pixel1.R + d1 * (double) pixel2.R;
        double num4 = (1.0 - d1) * (double) pixel3.R + d1 * (double) pixel4.R;
        int red = (int) ((1.0 - d2) * num3 + d2 * num4);
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        double num5 = (1.0 - d1) * (double) pixel1.G + d1 * (double) pixel2.G;
        double num6 = (1.0 - d1) * (double) pixel3.G + d1 * (double) pixel4.G;
        int green = (int) ((1.0 - d2) * num5 + d2 * num6);
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        double num7 = (1.0 - d1) * (double) pixel1.B + d1 * (double) pixel2.B;
        double num8 = (1.0 - d1) * (double) pixel3.B + d1 * (double) pixel4.B;
        int blue = (int) ((1.0 - d2) * num7 + d2 * num8);
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap;
  }

  public Bitmap Rotate(Bitmap OriginalImage, double Angle)
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

  public Bitmap Rotate(Bitmap OriginalImage, double Angle, int xCenter, int yCenter)
  {
    Angle %= 360.0;
    if ((xCenter < 0 || xCenter > OriginalImage.Width || yCenter < 0 ? 1 : (yCenter > OriginalImage.Height ? 1 : 0)) != 0)
      throw new Exception("The center of rotation point must be in range of image dimensions");
    double num1 = Convert.ToDouble(xCenter);
    double num2 = Convert.ToDouble(yCenter);
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

  public double[] rgb2hsv(Color pixel)
  {
    double[] numArray = new double[3];
    double num1 = (double) Math.Min(Math.Min(pixel.R, pixel.G), pixel.B);
    double num2 = (double) Math.Max(Math.Max(pixel.R, pixel.G), pixel.B);
    double num3 = num2 - num1;
    numArray[2] = 100.0 * num2 / (double) byte.MaxValue;
    numArray[1] = num2 != 0.0 ? num3 / num2 : 0.0;
    numArray[0] = num3 != 0.0 ? ((int) num2 != (int) pixel.R ? ((int) num2 != (int) pixel.G ? 60.0 * (Convert.ToDouble((int) pixel.R - (int) pixel.G) / num3 + 4.0) : 60.0 * (Convert.ToDouble((int) pixel.B - (int) pixel.R) / num3 + 2.0)) : 60.0 * (Convert.ToDouble((int) pixel.G - (int) pixel.B) / num3 % 6.0)) : 0.0;
    return numArray;
  }

  public Color hsv2rgb(double[] hsv)
  {
    Color color = new Color();
    double num1 = hsv[1] / 100.0 * (hsv[2] / 100.0);
    double num2 = hsv[2] / 100.0 - num1;
    double num3 = num1 * (1.0 - Math.Abs(hsv[0] / 60.0 % 2.0 - 1.0));
    double num4 = 0.0;
    double num5 = 0.0;
    double num6 = 0.0;
    if (hsv[0] < 60.0)
    {
      num4 = num1;
      num5 = num3;
      num6 = 0.0;
    }
    else if (hsv[0] < 120.0)
    {
      num4 = num3;
      num5 = num1;
      num6 = 0.0;
    }
    else if (hsv[0] < 180.0)
    {
      num4 = 0.0;
      num5 = num1;
      num6 = num3;
    }
    else if (hsv[0] < 240.0)
    {
      num4 = 0.0;
      num5 = num3;
      num6 = num1;
    }
    else if (hsv[0] < 300.0)
    {
      num4 = num3;
      num5 = 0.0;
      num6 = num1;
    }
    else if (hsv[0] < 360.0)
    {
      num4 = num1;
      num5 = 0.0;
      num6 = num3;
    }
    int red = (int) ((num4 + num2) * (double) byte.MaxValue);
    int green = (int) ((num5 + num2) * (double) byte.MaxValue);
    int blue = (int) ((num6 + num2) * (double) byte.MaxValue);
    if (red > (int) byte.MaxValue)
      red = (int) byte.MaxValue;
    if (red < 0)
      red = 0;
    if (green > (int) byte.MaxValue)
      green = (int) byte.MaxValue;
    if (green < 0)
      green = 0;
    if (blue > (int) byte.MaxValue)
      blue = (int) byte.MaxValue;
    if (blue < 0)
      blue = 0;
    return Color.FromArgb((int) byte.MaxValue, red, green, blue);
  }

  public double[] rgb2cmyk(Color pixel)
  {
    double val1 = Convert.ToDouble(pixel.R) / (double) byte.MaxValue;
    double val2_1 = Convert.ToDouble(pixel.G) / (double) byte.MaxValue;
    double val2_2 = Convert.ToDouble(pixel.B) / (double) byte.MaxValue;
    double num = 1.0 - Math.Max(Math.Max(val1, val2_2), val2_1);
    return new double[4]
    {
      (1.0 - val1 - num) / (1.0 - num),
      (1.0 - val2_1 - num) / (1.0 - num),
      (1.0 - val2_2 - num) / (1.0 - num),
      num
    };
  }

  public Color cmyk2rgb(double[] cmyk)
  {
    Color color = new Color();
    double num1 = (double) byte.MaxValue * (1.0 - cmyk[0]) * (1.0 - cmyk[3]);
    double num2 = (double) byte.MaxValue * (1.0 - cmyk[1]) * (1.0 - cmyk[3]);
    double num3 = (double) byte.MaxValue * (1.0 - cmyk[2]) * (1.0 - cmyk[3]);
    int red = (int) num1;
    int green = (int) num2;
    int blue = (int) num3;
    if (red > (int) byte.MaxValue)
      red = (int) byte.MaxValue;
    if (red < 0)
      red = 0;
    if (green > (int) byte.MaxValue)
      green = (int) byte.MaxValue;
    if (green < 0)
      green = 0;
    if (blue > (int) byte.MaxValue)
      blue = (int) byte.MaxValue;
    if (blue < 0)
      blue = 0;
    return Color.FromArgb((int) byte.MaxValue, red, green, blue);
  }

  public Color color2greyscale(Color pixel)
  {
    int num = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
    return Color.FromArgb((int) byte.MaxValue, num, num, num);
  }

  public Bitmap[] CMYKLayers(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    Bitmap bitmap2 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    Bitmap bitmap3 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    Bitmap bitmap4 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        double[] numArray = this.rgb2cmyk(OriginalImage.GetPixel(x, y));
        double num1 = numArray[0];
        double num2 = numArray[1];
        double num3 = numArray[2];
        double num4 = numArray[3];
        Color color1 = this.cmyk2rgb(new double[4]
        {
          num1,
          0.0,
          0.0,
          0.0
        });
        Color color2 = this.cmyk2rgb(new double[4]
        {
          0.0,
          num2,
          0.0,
          0.0
        });
        Color color3 = this.cmyk2rgb(new double[4]
        {
          0.0,
          0.0,
          num3,
          0.0
        });
        Color color4 = this.cmyk2rgb(new double[4]
        {
          0.0,
          0.0,
          0.0,
          num4
        });
        bitmap1.SetPixel(x, y, color1);
        bitmap2.SetPixel(x, y, color2);
        bitmap3.SetPixel(x, y, color3);
        bitmap4.SetPixel(x, y, color4);
      }
    }
    return new Bitmap[4]
    {
      bitmap1,
      bitmap2,
      bitmap3,
      bitmap4
    };
  }

  public Complex[,] DFT(Bitmap OriginalImage)
  {
    Complex[,] complexArray = new Complex[OriginalImage.Width, OriginalImage.Height];
    Bitmap greyscale = this.ToGreyscale(OriginalImage);
    int width = OriginalImage.Width;
    int height = OriginalImage.Height;
    for (int index1 = 0; index1 < width; ++index1)
    {
      for (int index2 = 0; index2 < height; ++index2)
      {
        Complex complex1 = (Complex) 0;
        for (int y = 0; y < height; ++y)
        {
          for (int x = 0; x < width; ++x)
          {
            double num = Convert.ToDouble(greyscale.GetPixel(x, y).R);
            Complex complex2 = Complex.Exp(-new Complex(0.0, 1.0) * (Complex) 2 * (Complex) Math.PI * (Complex) ((double) (index1 * x) / Convert.ToDouble(width) + (double) (index2 * y) / Convert.ToDouble(height)));
            complex1 += (Complex) num * complex2;
          }
        }
        complexArray[index1, index2] = complex1 / (Complex) Math.Sqrt((double) (width * height));
      }
    }
    return complexArray;
  }

  public Complex[,] SDFT(Bitmap OriginalImage)
  {
    Complex[,] complexArray = new Complex[OriginalImage.Width, OriginalImage.Height];
    double[,] numArray = Class30.smethod_55(this.ToGreyscale(OriginalImage), this);
    int width = OriginalImage.Width;
    int height = OriginalImage.Height;
    for (int index1 = 0; index1 < width; ++index1)
    {
      for (int index2 = 0; index2 < height; ++index2)
      {
        Complex complex1 = (Complex) 0;
        for (int index3 = 0; index3 < height; ++index3)
        {
          for (int index4 = 0; index4 < width; ++index4)
          {
            double num = numArray[index4, index3];
            Complex complex2 = Complex.Exp(-new Complex(0.0, 1.0) * (Complex) 2 * (Complex) Math.PI * (Complex) ((double) (index1 * index4) / Convert.ToDouble(width) + (double) (index2 * index3) / Convert.ToDouble(height)));
            complex1 += (Complex) num * complex2;
          }
        }
        complexArray[index1, index2] = complex1 / (Complex) Math.Sqrt((double) (width * height));
      }
    }
    return complexArray;
  }

  public Complex[,] SDFT(double[,] Data)
  {
    Complex[,] complexArray = new Complex[Data.GetLength(0), Data.GetLength(1)];
    Data = Class30.smethod_40(this, Data);
    int length1 = Data.GetLength(0);
    int length2 = Data.GetLength(1);
    for (int index1 = 0; index1 < length1; ++index1)
    {
      for (int index2 = 0; index2 < length2; ++index2)
      {
        Complex complex1 = (Complex) 0;
        for (int index3 = 0; index3 < length2; ++index3)
        {
          for (int index4 = 0; index4 < length1; ++index4)
          {
            double num = Data[index4, index3];
            Complex complex2 = Complex.Exp(-new Complex(0.0, 1.0) * (Complex) 2 * (Complex) Math.PI * (Complex) ((double) (index1 * index4) / Convert.ToDouble(length1) + (double) (index2 * index3) / Convert.ToDouble(length2)));
            complex1 += (Complex) num * complex2;
          }
        }
        complexArray[index1, index2] = complex1 / (Complex) Math.Sqrt(Convert.ToDouble(length1) * Convert.ToDouble(length2));
      }
    }
    return complexArray;
  }

  public Complex[,] DFT(double[,] Data)
  {
    Complex[,] complexArray = new Complex[Data.GetLength(0), Data.GetLength(1)];
    int length1 = Data.GetLength(0);
    int length2 = Data.GetLength(1);
    for (int index1 = 0; index1 < length1; ++index1)
    {
      for (int index2 = 0; index2 < length2; ++index2)
      {
        Complex complex1 = (Complex) 0;
        for (int index3 = 0; index3 < length2; ++index3)
        {
          for (int index4 = 0; index4 < length1; ++index4)
          {
            double num = Data[index4, index3];
            Complex complex2 = Complex.Exp(-new Complex(0.0, 1.0) * (Complex) 2 * (Complex) Math.PI * (Complex) ((double) (index1 * index4) / Convert.ToDouble(length1) + (double) (index2 * index3) / Convert.ToDouble(length2)));
            complex1 += (Complex) num * complex2;
          }
        }
        complexArray[index1, index2] = complex1 / (Complex) Math.Sqrt(Convert.ToDouble(length1) * Convert.ToDouble(length2));
      }
    }
    return complexArray;
  }

  public Bitmap iDFT(Complex[,] Spectrum)
  {
    Bitmap bitmap = new Bitmap(Spectrum.GetLength(0), Spectrum.GetLength(1));
    for (int x = 0; x < Spectrum.GetLength(0); ++x)
    {
      for (int y = 0; y < Spectrum.GetLength(1); ++y)
      {
        double num1 = Convert.ToDouble(x);
        double num2 = Convert.ToDouble(y);
        Complex complex1 = new Complex(0.0, 1.0);
        Complex complex2 = (Complex) 0;
        for (int index1 = 0; index1 < Spectrum.GetLength(0); ++index1)
        {
          for (int index2 = 0; index2 < Spectrum.GetLength(1); ++index2)
          {
            double num3 = Convert.ToDouble(index1);
            double num4 = Convert.ToDouble(index2);
            double num5 = num3 * num1 / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
            Complex complex3 = Complex.Exp(complex1 * (Complex) 2 * (Complex) Math.PI * (Complex) num5);
            complex2 += Spectrum[index1, index2] * complex3;
          }
        }
        int num6 = (int) (complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1))));
        if (num6 > (int) byte.MaxValue)
          num6 = (int) byte.MaxValue;
        bitmap.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num6, num6, num6));
      }
    }
    return bitmap;
  }

  public double[,] iDFT2(Complex[,] Spectrum)
  {
    double[,] numArray = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
    for (int index1 = 0; index1 < Spectrum.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < Spectrum.GetLength(1); ++index2)
      {
        double num1 = Convert.ToDouble(index1);
        double num2 = Convert.ToDouble(index2);
        Complex complex1 = new Complex(0.0, 1.0);
        Complex complex2 = (Complex) 0;
        for (int index3 = 0; index3 < Spectrum.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Spectrum.GetLength(1); ++index4)
          {
            double num3 = Convert.ToDouble(index3);
            double num4 = Convert.ToDouble(index4);
            double num5 = num3 * num1 / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
            Complex complex3 = Complex.Exp(complex1 * (Complex) 2 * (Complex) Math.PI * (Complex) num5);
            complex2 += Spectrum[index3, index4] * complex3;
          }
        }
        numArray[index1, index2] = complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1)));
      }
    }
    return numArray;
  }

  public double[,] iSDFT2(Complex[,] Spectrum)
  {
    double[,] double_0 = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
    for (int index1 = 0; index1 < Spectrum.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < Spectrum.GetLength(1); ++index2)
      {
        double num1 = Convert.ToDouble(index1);
        double num2 = Convert.ToDouble(index2);
        Complex complex1 = new Complex(0.0, 1.0);
        Complex complex2 = (Complex) 0;
        for (int index3 = 0; index3 < Spectrum.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Spectrum.GetLength(1); ++index4)
          {
            double num3 = Convert.ToDouble(index3);
            double num4 = Convert.ToDouble(index4);
            double num5 = num3 * num1 / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
            Complex complex3 = Complex.Exp(complex1 * (Complex) 2 * (Complex) Math.PI * (Complex) num5);
            complex2 += Spectrum[index3, index4] * complex3;
          }
        }
        double_0[index1, index2] = complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1)));
      }
    }
    return Class30.smethod_40(this, double_0);
  }

  public Bitmap iSDFT(Complex[,] Spectrum)
  {
    double[,] Matrix = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
    for (int index1 = 0; index1 < Spectrum.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < Spectrum.GetLength(1); ++index2)
      {
        double num1 = Convert.ToDouble(index1);
        double num2 = Convert.ToDouble(index2);
        Complex complex1 = new Complex(0.0, 1.0);
        Complex complex2 = (Complex) 0;
        for (int index3 = 0; index3 < Spectrum.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Spectrum.GetLength(1); ++index4)
          {
            double num3 = Convert.ToDouble(index3);
            double num4 = Convert.ToDouble(index4);
            double num5 = num3 * num1 / Convert.ToDouble(Spectrum.GetLength(0)) + num4 * num2 / Convert.ToDouble(Spectrum.GetLength(1));
            Complex complex3 = Complex.Exp(complex1 * (Complex) 2 * (Complex) Math.PI * (Complex) num5);
            complex2 += Spectrum[index3, index4] * complex3;
          }
        }
        Matrix[index1, index2] = complex2.Magnitude / Math.Sqrt(Convert.ToDouble(Spectrum.GetLength(0)) * Convert.ToDouble(Spectrum.GetLength(1)));
      }
    }
    return this.Matrix2Image(Matrix);
  }

  public Bitmap Matrix2Image(double[,] Matrix)
  {
    Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
    for (int x = 0; x < Matrix.GetLength(0); ++x)
    {
      for (int y = 0; y < Matrix.GetLength(1); ++y)
      {
        int num = (int) Matrix[x, y];
        if (num > (int) byte.MaxValue)
          num = (int) byte.MaxValue;
        if (num < 0)
          num = 0;
        bitmap.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num, num, num));
      }
    }
    return bitmap;
  }

  public Bitmap Matrix2Image(int[,] Matrix)
  {
    Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
    for (int x = 0; x < Matrix.GetLength(0); ++x)
    {
      for (int y = 0; y < Matrix.GetLength(1); ++y)
      {
        int num = Matrix[x, y];
        if (num > (int) byte.MaxValue)
          num = (int) byte.MaxValue;
        if (num < 0)
          num = 0;
        bitmap.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num, num, num));
      }
    }
    return bitmap;
  }

  public double[,] Magnitude(Complex[,] Spectrum)
  {
    double[,] numArray = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
    for (int index1 = 0; index1 < Spectrum.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < Spectrum.GetLength(1); ++index2)
        numArray[index1, index2] = Spectrum[index1, index2].Magnitude;
    }
    return numArray;
  }

  public double[,] Phase(Complex[,] Spectrum)
  {
    double[,] numArray = new double[Spectrum.GetLength(0), Spectrum.GetLength(1)];
    for (int index1 = 0; index1 < Spectrum.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < Spectrum.GetLength(1); ++index2)
        numArray[index1, index2] = Spectrum[index1, index2].Phase;
    }
    return numArray;
  }

  public Bitmap Matrix2ImageLog(double[,] Matrix)
  {
    Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
    double num1 = ((IEnumerable) Matrix).Cast<double>().Max();
    for (int x = 0; x < Matrix.GetLength(0); ++x)
    {
      for (int y = 0; y < Matrix.GetLength(1); ++y)
      {
        int num2 = (int) ((double) byte.MaxValue / Math.Log10(1.0 + num1) * Math.Log10(1.0 + Matrix[x, y]));
        Color color = Color.FromArgb((int) byte.MaxValue, num2, num2, num2);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap Matrix2ImageMax(double[,] Matrix)
  {
    Bitmap bitmap = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));
    double num1 = ((IEnumerable) Matrix).Cast<double>().Max();
    for (int x = 0; x < Matrix.GetLength(0); ++x)
    {
      for (int y = 0; y < Matrix.GetLength(1); ++y)
      {
        int num2 = (int) (Matrix[x, y] / num1);
        if (num2 > (int) byte.MaxValue)
          num2 = (int) byte.MaxValue;
        Color color = Color.FromArgb((int) byte.MaxValue, num2, num2, num2);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public int[,,] RGBMatrix(Bitmap OriginalImage)
  {
    int width = OriginalImage.Width;
    int height = OriginalImage.Height;
    int[,,] numArray = new int[3, width, height];
    for (int x = 0; x < width; ++x)
    {
      for (int y = 0; y < height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        numArray[0, x, y] = (int) pixel.R;
        numArray[1, x, y] = (int) pixel.G;
        numArray[2, x, y] = (int) pixel.B;
      }
    }
    return numArray;
  }

  public int[,] RMatrix(Bitmap OriginalImage)
  {
    int[,,] numArray1 = this.RGBMatrix(OriginalImage);
    int[,] numArray2 = new int[OriginalImage.Width, OriginalImage.Height];
    for (int index1 = 0; index1 < OriginalImage.Width; ++index1)
    {
      for (int index2 = 0; index2 < OriginalImage.Height; ++index2)
        numArray2[index1, index2] = numArray1[0, index1, index2];
    }
    return numArray2;
  }

  public int[,] GMatrix(Bitmap OriginalImage)
  {
    int[,,] numArray1 = this.RGBMatrix(OriginalImage);
    int[,] numArray2 = new int[OriginalImage.Width, OriginalImage.Height];
    for (int index1 = 0; index1 < OriginalImage.Width; ++index1)
    {
      for (int index2 = 0; index2 < OriginalImage.Height; ++index2)
        numArray2[index1, index2] = numArray1[1, index1, index2];
    }
    return numArray2;
  }

  public int[,] BMatrix(Bitmap OriginalImage)
  {
    int[,,] numArray1 = this.RGBMatrix(OriginalImage);
    int[,] numArray2 = new int[OriginalImage.Width, OriginalImage.Height];
    for (int index1 = 0; index1 < OriginalImage.Width; ++index1)
    {
      for (int index2 = 0; index2 < OriginalImage.Height; ++index2)
        numArray2[index1, index2] = numArray1[2, index1, index2];
    }
    return numArray2;
  }

  public Bitmap[] RGBLayers(Bitmap OriginalImage)
  {
    int width = OriginalImage.Width;
    int height = OriginalImage.Height;
    Bitmap bitmap1 = new Bitmap(width, height);
    Bitmap bitmap2 = new Bitmap(width, height);
    Bitmap bitmap3 = new Bitmap(width, height);
    for (int x = 0; x < width; ++x)
    {
      for (int y = 0; y < height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        bitmap1.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, (int) pixel.R, 0, 0));
        bitmap2.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, 0, (int) pixel.G, 0));
        bitmap3.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, 0, 0, (int) pixel.B));
      }
    }
    return new Bitmap[3]{ bitmap1, bitmap2, bitmap3 };
  }

  public Bitmap LogaritmicScaling(Bitmap OriginalImage)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    int[,] source1 = this.RMatrix(OriginalImage);
    int[,] source2 = this.GMatrix(OriginalImage);
    int[,] source3 = this.BMatrix(OriginalImage);
    double num1 = Convert.ToDouble(((IEnumerable) source1).Cast<int>().Max());
    double num2 = Convert.ToDouble(((IEnumerable) source2).Cast<int>().Max());
    double num3 = Convert.ToDouble(((IEnumerable) source3).Cast<int>().Max());
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, (int) ((double) byte.MaxValue / Math.Log10(1.0 + num1) * Math.Log10((double) (1 + (int) OriginalImage.GetPixel(x, y).R))), (int) ((double) byte.MaxValue / Math.Log10(1.0 + num2) * Math.Log10((double) (1 + (int) OriginalImage.GetPixel(x, y).G))), (int) ((double) byte.MaxValue / Math.Log10(1.0 + num3) * Math.Log10((double) (1 + (int) OriginalImage.GetPixel(x, y).B))));
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap ToGreyscale(Bitmap OriginalImage)
  {
    Bitmap greyscale = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        Color color = Color.FromArgb((int) byte.MaxValue, num, num, num);
        greyscale.SetPixel(x, y, color);
      }
    }
    return greyscale;
  }

  public Bitmap ToGreyscaleAVG(Bitmap OriginalImage)
  {
    Bitmap greyscaleAvg = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num = ((int) pixel.R + (int) pixel.G + (int) pixel.B) / 3;
        Color color = Color.FromArgb((int) byte.MaxValue, num, num, num);
        greyscaleAvg.SetPixel(x, y, color);
      }
    }
    return greyscaleAvg;
  }

  public Bitmap ToGreyscaleLightness(Bitmap OriginalImage)
  {
    Bitmap greyscaleLightness = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num = ((int) Math.Max(pixel.R, Math.Max(pixel.G, pixel.B)) + (int) Math.Min(pixel.R, Math.Min(pixel.G, pixel.B))) / 2;
        Color color = Color.FromArgb((int) byte.MaxValue, num, num, num);
        greyscaleLightness.SetPixel(x, y, color);
      }
    }
    return greyscaleLightness;
  }

  public Bitmap InverseImage(Bitmap OriginalImage, int threshold)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    if ((threshold < 1 ? 1 : (threshold > 254 ? 1 : 0)) != 0)
      throw new Exception("Threshold value must be in range from 1 to 254");
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num1 = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        int num2 = Math.Abs(threshold - num1);
        int num3 = 0;
        if (num1 >= threshold)
          num3 = threshold - num2;
        if (num1 < threshold)
          num3 = threshold + num2;
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, num3, num3, num3);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap NegativeImageGS(Bitmap OriginalImage)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num = (int) byte.MaxValue - (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        if (num > (int) byte.MaxValue)
          num = (int) byte.MaxValue;
        if (num < 0)
          num = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, num, num, num);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap NegativeImageColor(Bitmap OriginalImage)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int red = (int) byte.MaxValue - (int) pixel.R;
        int green = (int) byte.MaxValue - (int) pixel.G;
        int blue = (int) byte.MaxValue - (int) pixel.B;
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, red, green, blue);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap AddImages(Bitmap Left, Bitmap Right)
  {
    if (Left.Width != Right.Width)
      throw new Exception("Images dimension must be equal.");
    if (Left.Height != Right.Height)
      throw new Exception("Images dimension must be equal.");
    Bitmap bitmap = new Bitmap(Left.Width, Left.Height);
    for (int x = 0; x < Left.Width; ++x)
    {
      for (int y = 0; y < Left.Height; ++y)
      {
        Color pixel1 = Left.GetPixel(x, y);
        Color pixel2 = Right.GetPixel(x, y);
        int num = (int) ((double) pixel1.R * 0.3 + (double) pixel1.G * 0.59 + (double) pixel1.B * 0.11) + (int) ((double) pixel2.R * 0.3 + (double) pixel2.G * 0.59 + (double) pixel2.B * 0.11);
        if (num > (int) byte.MaxValue)
          num = (int) byte.MaxValue;
        if (num < 0)
          num = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, num, num, num);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap SubtractImages(Bitmap Left, Bitmap Right)
  {
    if (Left.Width != Right.Width)
      throw new Exception("Images dimension must be equal.");
    if (Left.Height != Right.Height)
      throw new Exception("Images dimension must be equal.");
    Bitmap bitmap = new Bitmap(Left.Width, Left.Height);
    for (int x = 0; x < Left.Width; ++x)
    {
      for (int y = 0; y < Left.Height; ++y)
      {
        Color pixel1 = Left.GetPixel(x, y);
        Color pixel2 = Right.GetPixel(x, y);
        int num = (int) ((double) pixel1.R * 0.3 + (double) pixel1.G * 0.59 + (double) pixel1.B * 0.11) - (int) ((double) pixel2.R * 0.3 + (double) pixel2.G * 0.59 + (double) pixel2.B * 0.11);
        if (num > (int) byte.MaxValue)
          num = (int) byte.MaxValue;
        if (num < 0)
          num = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, num, num, num);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap ToBlackwhite(Bitmap OriginalImage, int threshold)
  {
    Bitmap blackwhite = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    if ((threshold < 1 ? 1 : (threshold > 254 ? 1 : 0)) != 0)
      throw new Exception("Threshold value must be in range from 1 to 254");
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int maxValue = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11) <= threshold ? 0 : (int) byte.MaxValue;
        Color color = Color.FromArgb((int) byte.MaxValue, maxValue, maxValue, maxValue);
        blackwhite.SetPixel(x, y, color);
      }
    }
    return blackwhite;
  }

  public Bitmap ToBlackwhiteInverse(Bitmap OriginalImage, int threshold)
  {
    Bitmap blackwhiteInverse = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    if ((threshold < 1 ? 1 : (threshold > 254 ? 1 : 0)) != 0)
      throw new Exception("Threshold value must be in range from 1 to 254");
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int maxValue = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11) <= threshold ? (int) byte.MaxValue : 0;
        Color color = Color.FromArgb((int) byte.MaxValue, maxValue, maxValue, maxValue);
        blackwhiteInverse.SetPixel(x, y, color);
      }
    }
    return blackwhiteInverse;
  }

  public int[] Histogram(Bitmap OriginalImage)
  {
    int[] numArray = new int[256 /*0x0100*/];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      numArray[index] = 0;
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int index = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        ++numArray[index];
      }
    }
    return numArray;
  }

  public int[,] RGBHistogram(Bitmap OriginalImage)
  {
    int[,] numArray = new int[3, 256 /*0x0100*/];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
    {
      numArray[0, index] = 0;
      numArray[1, index] = 0;
      numArray[2, index] = 0;
    }
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        ++numArray[0, (int) pixel.R];
        ++numArray[1, (int) pixel.G];
        ++numArray[2, (int) pixel.B];
      }
    }
    return numArray;
  }

  public int MinBrightness(Bitmap OriginalImage)
  {
    int num1 = (int) byte.MaxValue;
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num2 = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        if (num2 < num1)
          num1 = num2;
      }
    }
    return num1;
  }

  public int MaxBrightness(Bitmap OriginalImage)
  {
    int num1 = 0;
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num2 = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        if (num2 > num1)
          num1 = num2;
      }
    }
    return num1;
  }

  public Bitmap ContrastStretching(Bitmap OriginalImage)
  {
    Bitmap OriginalImage1 = OriginalImage;
    int num1 = 0;
    int maxValue = (int) byte.MaxValue;
    int num2 = this.MinBrightness(OriginalImage1);
    int num3 = this.MaxBrightness(OriginalImage1);
    for (int x = 0; x < OriginalImage1.Width; ++x)
    {
      for (int y = 0; y < OriginalImage1.Height; ++y)
      {
        Color pixel = OriginalImage1.GetPixel(x, y);
        int num4 = (int) (Convert.ToDouble((int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11) - num2) / Convert.ToDouble(num3 - num2) * (double) (maxValue - num1) + (double) num1);
        OriginalImage1.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num4, num4, num4));
      }
    }
    return OriginalImage1;
  }

  public Bitmap ContrastStretching(Bitmap OriginalImage, int RMinSet, int RMaxSet)
  {
    Bitmap OriginalImage1 = OriginalImage;
    if (RMinSet >= RMaxSet)
      throw new Exception("Minimum available brightness value must be lower then maximum available brightness value");
    if (RMinSet < 0)
      throw new Exception("Minimum available brightness value must be positive or zero");
    if (RMaxSet > (int) byte.MaxValue)
      throw new Exception("Maximum available brightness value must be positive lower or equal 255");
    int num1 = RMinSet;
    int num2 = RMaxSet;
    int num3 = this.MinBrightness(OriginalImage1);
    int num4 = this.MaxBrightness(OriginalImage1);
    for (int x = 0; x < OriginalImage1.Width; ++x)
    {
      for (int y = 0; y < OriginalImage1.Height; ++y)
      {
        Color pixel = OriginalImage1.GetPixel(x, y);
        int num5 = (int) (Convert.ToDouble((int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11) - num3) / Convert.ToDouble(num4 - num3) * (double) (num2 - num1) + (double) num1);
        OriginalImage1.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num5, num5, num5));
      }
    }
    return OriginalImage1;
  }

  public Bitmap HistogramShift(Bitmap OriginalImage, int offset)
  {
    Bitmap bitmap = OriginalImage;
    if ((offset < 1 ? 1 : (offset > 254 ? 1 : 0)) != 0)
      throw new Exception("Offset value must be in range from 1 to 254");
    for (int x = 0; x < bitmap.Width; ++x)
    {
      for (int y = 0; y < bitmap.Height; ++y)
      {
        Color pixel = bitmap.GetPixel(x, y);
        int num = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11) + offset;
        bitmap.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num, num, num));
      }
    }
    return bitmap;
  }

  public Bitmap HistoramEqualization(Bitmap OriginalImage)
  {
    Bitmap OriginalImage1 = OriginalImage;
    int[] numArray = this.Histogram(OriginalImage1);
    int num1 = OriginalImage1.Width * OriginalImage1.Height;
    for (int x = 0; x < OriginalImage1.Width; ++x)
    {
      for (int y = 0; y < OriginalImage1.Height; ++y)
      {
        Color pixel = OriginalImage1.GetPixel(x, y);
        int num2 = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        double num3 = 0.0;
        for (int index = 0; index < num2 + 1; ++index)
          num3 += Convert.ToDouble(numArray[index]) / (double) num1;
        int int16 = (int) Convert.ToInt16(Math.Floor((double) byte.MaxValue * num3));
        OriginalImage1.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, int16, int16, int16));
      }
    }
    return OriginalImage1;
  }

  public Bitmap ImageFilterGS(Bitmap OriginalImage, int[,] Filter)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (Filter.GetLength(0) != Filter.GetLength(1))
      throw new Exception("Filter mask must be square.");
    if (Filter.GetLength(0) % 2 == 0)
      throw new Exception("Filter mask dimesion must be odd.");
    int num1 = Filter.GetLength(0) >= 3 ? (int) Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray = new int[Filter.GetLength(0), Filter.GetLength(0)];
        int index1 = 0;
        int index2 = 0;
        int num2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num3 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray[index1, index2] = (int) num3;
            ++index2;
          }
          ++index1;
          index2 = 0;
        }
        for (int index3 = 0; index3 < Filter.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Filter.GetLength(0); ++index4)
            num2 += numArray[index3, index4] * Filter[index3, index4];
        }
        if (num2 > (int) byte.MaxValue)
          num2 = (int) byte.MaxValue;
        if (num2 < 0)
          num2 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num2, num2, num2));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageFilterGS(Bitmap OriginalImage, int[,] Filter, double Coef)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (Filter.GetLength(0) != Filter.GetLength(1))
      throw new Exception("Filter mask must be square.");
    if (Filter.GetLength(0) % 2 == 0)
      throw new Exception("Filter mask dimesion must be odd.");
    int num1 = Filter.GetLength(0) >= 3 ? (int) Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray = new int[Filter.GetLength(0), Filter.GetLength(0)];
        int index1 = 0;
        int index2 = 0;
        int num2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num3 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray[index1, index2] = (int) num3;
            ++index2;
          }
          ++index1;
          index2 = 0;
        }
        for (int index3 = 0; index3 < Filter.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Filter.GetLength(0); ++index4)
            num2 += numArray[index3, index4] * Filter[index3, index4];
        }
        int num4 = (int) (Convert.ToDouble(num2) / Coef);
        if (num4 > (int) byte.MaxValue)
          num4 = (int) byte.MaxValue;
        if (num4 < 0)
          num4 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num4, num4, num4));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageFilterGS(Bitmap OriginalImage, double[,] Filter)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (Filter.GetLength(0) != Filter.GetLength(1))
      throw new Exception("Filter mask must be square.");
    if (Filter.GetLength(0) % 2 == 0)
      throw new Exception("Filter mask dimesion must be odd.");
    int num1 = Filter.GetLength(0) >= 3 ? (int) Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        double[,] numArray = new double[Filter.GetLength(0), Filter.GetLength(0)];
        int index1 = 0;
        int index2 = 0;
        int num2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num3 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray[index1, index2] = num3;
            ++index2;
          }
          ++index1;
          index2 = 0;
        }
        for (int index3 = 0; index3 < Filter.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Filter.GetLength(0); ++index4)
            num2 += (int) (numArray[index3, index4] * Filter[index3, index4]);
        }
        if (num2 > (int) byte.MaxValue)
          num2 = (int) byte.MaxValue;
        if (num2 < 0)
          num2 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num2, num2, num2));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageFilterColor(Bitmap OriginalImage, int[,] Filter)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (Filter.GetLength(0) != Filter.GetLength(1))
      throw new Exception("Filter mask must be square.");
    if (Filter.GetLength(0) % 2 == 0)
      throw new Exception("Filter mask dimesion must be odd.");
    int num1 = Filter.GetLength(0) >= 3 ? (int) Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,,] numArray = new int[3, Filter.GetLength(0), Filter.GetLength(0)];
        int index1 = 0;
        int index2 = 0;
        int red = 0;
        int green = 0;
        int blue = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble(pixel.R);
            double num3 = Convert.ToDouble(pixel.G);
            double num4 = Convert.ToDouble(pixel.B);
            numArray[0, index1, index2] = (int) num2;
            numArray[1, index1, index2] = (int) num3;
            numArray[2, index1, index2] = (int) num4;
            ++index2;
          }
          ++index1;
          index2 = 0;
        }
        for (int index3 = 0; index3 < Filter.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Filter.GetLength(0); ++index4)
          {
            red += numArray[0, index3, index4] * Filter[index3, index4];
            green += numArray[1, index3, index4] * Filter[index3, index4];
            blue += numArray[2, index3, index4] * Filter[index3, index4];
          }
        }
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageFilterColor(Bitmap OriginalImage, int[,] Filter, double Coef)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (Filter.GetLength(0) != Filter.GetLength(1))
      throw new Exception("Filter mask must be square.");
    if (Filter.GetLength(0) % 2 == 0)
      throw new Exception("Filter mask dimesion must be odd.");
    int num1 = Filter.GetLength(0) >= 3 ? (int) Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,,] numArray = new int[3, Filter.GetLength(0), Filter.GetLength(0)];
        int index1 = 0;
        int index2 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num5 = Convert.ToDouble(pixel.R);
            double num6 = Convert.ToDouble(pixel.G);
            double num7 = Convert.ToDouble(pixel.B);
            numArray[0, index1, index2] = (int) num5;
            numArray[1, index1, index2] = (int) num6;
            numArray[2, index1, index2] = (int) num7;
            ++index2;
          }
          ++index1;
          index2 = 0;
        }
        for (int index3 = 0; index3 < Filter.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Filter.GetLength(0); ++index4)
          {
            num2 += numArray[0, index3, index4] * Filter[index3, index4];
            num3 += numArray[1, index3, index4] * Filter[index3, index4];
            num4 += numArray[2, index3, index4] * Filter[index3, index4];
          }
        }
        int red = (int) (Convert.ToDouble(num2) / Coef);
        int green = (int) (Convert.ToDouble(num3) / Coef);
        int blue = (int) (Convert.ToDouble(num4) / Coef);
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageFilterColor(Bitmap OriginalImage, double[,] Filter)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (Filter.GetLength(0) != Filter.GetLength(1))
      throw new Exception("Filter mask must be square.");
    if (Filter.GetLength(0) % 2 == 0)
      throw new Exception("Filter mask dimesion must be odd.");
    int num1 = Filter.GetLength(0) >= 3 ? (int) Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        double[,,] numArray = new double[3, Filter.GetLength(0), Filter.GetLength(0)];
        int index1 = 0;
        int index2 = 0;
        int red = 0;
        int green = 0;
        int blue = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble(pixel.R);
            double num3 = Convert.ToDouble(pixel.G);
            double num4 = Convert.ToDouble(pixel.B);
            numArray[0, index1, index2] = (double) (int) num2;
            numArray[1, index1, index2] = (double) (int) num3;
            numArray[2, index1, index2] = (double) (int) num4;
            ++index2;
          }
          ++index1;
          index2 = 0;
        }
        for (int index3 = 0; index3 < Filter.GetLength(0); ++index3)
        {
          for (int index4 = 0; index4 < Filter.GetLength(0); ++index4)
          {
            red += (int) (numArray[0, index3, index4] * Filter[index3, index4]);
            green += (int) (numArray[1, index3, index4] * Filter[index3, index4]);
            blue += (int) (numArray[2, index3, index4] * Filter[index3, index4]);
          }
        }
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageSobelFilterGS(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    for (int x = 1; x < bitmap1.Width - 1; ++x)
    {
      for (int y = 1; y < bitmap1.Height - 1; ++y)
      {
        Color pixel1 = bitmap1.GetPixel(x - 1, y - 1);
        Color pixel2 = bitmap1.GetPixel(x, y - 1);
        Color pixel3 = bitmap1.GetPixel(x + 1, y - 1);
        Color pixel4 = bitmap1.GetPixel(x - 1, y);
        Color pixel5 = bitmap1.GetPixel(x, y);
        Color pixel6 = bitmap1.GetPixel(x + 1, y);
        Color pixel7 = bitmap1.GetPixel(x - 1, y + 1);
        Color pixel8 = bitmap1.GetPixel(x, y + 1);
        Color pixel9 = bitmap1.GetPixel(x + 1, y + 1);
        double num1 = Convert.ToDouble((double) pixel1.R * 0.3 + (double) pixel1.G * 0.59 + (double) pixel1.B * 0.11);
        double num2 = Convert.ToDouble((double) pixel2.R * 0.3 + (double) pixel2.G * 0.59 + (double) pixel2.B * 0.11);
        double num3 = Convert.ToDouble((double) pixel3.R * 0.3 + (double) pixel3.G * 0.59 + (double) pixel3.B * 0.11);
        double num4 = Convert.ToDouble((double) pixel4.R * 0.3 + (double) pixel4.G * 0.59 + (double) pixel4.B * 0.11);
        Convert.ToDouble((double) pixel5.R * 0.3 + (double) pixel5.G * 0.59 + (double) pixel5.B * 0.11);
        double num5 = Convert.ToDouble((double) pixel6.R * 0.3 + (double) pixel6.G * 0.59 + (double) pixel6.B * 0.11);
        double num6 = Convert.ToDouble((double) pixel7.R * 0.3 + (double) pixel7.G * 0.59 + (double) pixel7.B * 0.11);
        double num7 = Convert.ToDouble((double) pixel8.R * 0.3 + (double) pixel8.G * 0.59 + (double) pixel8.B * 0.11);
        double num8 = Convert.ToDouble((double) pixel9.R * 0.3 + (double) pixel9.G * 0.59 + (double) pixel9.B * 0.11);
        int num9 = (int) (num1 + (num2 + num2) + num3 - num6 - (num7 + num7) - num8);
        int num10 = (int) (num3 + (num5 + num5) + num8 - num1 - (num4 + num4) - num6);
        int num11 = Math.Abs(num9) + Math.Abs(num10);
        if (num11 > (int) byte.MaxValue)
          num11 = (int) byte.MaxValue;
        if (num11 < 0)
          num11 = 0;
        bitmap2.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num11, num11, num11));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageSobelFilterColor(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    for (int x = 1; x < bitmap1.Width - 1; ++x)
    {
      for (int y = 1; y < bitmap1.Height - 1; ++y)
      {
        Color pixel1 = bitmap1.GetPixel(x - 1, y - 1);
        Color pixel2 = bitmap1.GetPixel(x, y - 1);
        Color pixel3 = bitmap1.GetPixel(x + 1, y - 1);
        Color pixel4 = bitmap1.GetPixel(x - 1, y);
        Color pixel5 = bitmap1.GetPixel(x, y);
        Color pixel6 = bitmap1.GetPixel(x + 1, y);
        Color pixel7 = bitmap1.GetPixel(x - 1, y + 1);
        Color pixel8 = bitmap1.GetPixel(x, y + 1);
        Color pixel9 = bitmap1.GetPixel(x + 1, y + 1);
        double num1 = Convert.ToDouble(pixel1.R);
        double num2 = Convert.ToDouble(pixel2.R);
        double num3 = Convert.ToDouble(pixel3.R);
        double num4 = Convert.ToDouble(pixel4.R);
        Convert.ToDouble(pixel5.R);
        double num5 = Convert.ToDouble(pixel6.R);
        double num6 = Convert.ToDouble(pixel7.R);
        double num7 = Convert.ToDouble(pixel8.R);
        double num8 = Convert.ToDouble(pixel9.R);
        double num9 = Convert.ToDouble(pixel1.G);
        double num10 = Convert.ToDouble(pixel2.G);
        double num11 = Convert.ToDouble(pixel3.G);
        double num12 = Convert.ToDouble(pixel4.G);
        Convert.ToDouble(pixel5.G);
        double num13 = Convert.ToDouble(pixel6.G);
        double num14 = Convert.ToDouble(pixel7.G);
        double num15 = Convert.ToDouble(pixel8.G);
        double num16 = Convert.ToDouble(pixel9.G);
        double num17 = Convert.ToDouble(pixel1.B);
        double num18 = Convert.ToDouble(pixel2.B);
        double num19 = Convert.ToDouble(pixel3.B);
        double num20 = Convert.ToDouble(pixel4.B);
        Convert.ToDouble(pixel5.B);
        double num21 = Convert.ToDouble(pixel6.B);
        double num22 = Convert.ToDouble(pixel7.B);
        double num23 = Convert.ToDouble(pixel8.B);
        double num24 = Convert.ToDouble(pixel9.B);
        int num25 = (int) (num1 + (num2 + num2) + num3 - num6 - (num7 + num7) - num8);
        int num26 = (int) (num3 + (num5 + num5) + num8 - num1 - (num4 + num4) - num6);
        int red = Math.Abs(num25) + Math.Abs(num26);
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        int num27 = (int) (num9 + (num10 + num10) + num11 - num14 - (num15 + num15) - num16);
        int num28 = (int) (num11 + (num13 + num13) + num16 - num9 - (num12 + num12) - num14);
        int green = Math.Abs(num27) + Math.Abs(num28);
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        int num29 = (int) (num17 + (num18 + num18) + num19 - num22 - (num23 + num23) - num24);
        int num30 = (int) (num19 + (num21 + num21) + num24 - num17 - (num20 + num20) - num22);
        int blue = Math.Abs(num29) + Math.Abs(num30);
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImagePrewittFilterGS(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    for (int x = 1; x < bitmap1.Width - 1; ++x)
    {
      for (int y = 1; y < bitmap1.Height - 1; ++y)
      {
        Color pixel1 = bitmap1.GetPixel(x - 1, y - 1);
        Color pixel2 = bitmap1.GetPixel(x, y - 1);
        Color pixel3 = bitmap1.GetPixel(x + 1, y - 1);
        Color pixel4 = bitmap1.GetPixel(x - 1, y);
        Color pixel5 = bitmap1.GetPixel(x, y);
        Color pixel6 = bitmap1.GetPixel(x + 1, y);
        Color pixel7 = bitmap1.GetPixel(x - 1, y + 1);
        Color pixel8 = bitmap1.GetPixel(x, y + 1);
        Color pixel9 = bitmap1.GetPixel(x + 1, y + 1);
        double num1 = Convert.ToDouble((double) pixel1.R * 0.3 + (double) pixel1.G * 0.59 + (double) pixel1.B * 0.11);
        double num2 = Convert.ToDouble((double) pixel2.R * 0.3 + (double) pixel2.G * 0.59 + (double) pixel2.B * 0.11);
        double num3 = Convert.ToDouble((double) pixel3.R * 0.3 + (double) pixel3.G * 0.59 + (double) pixel3.B * 0.11);
        double num4 = Convert.ToDouble((double) pixel4.R * 0.3 + (double) pixel4.G * 0.59 + (double) pixel4.B * 0.11);
        Convert.ToDouble((double) pixel5.R * 0.3 + (double) pixel5.G * 0.59 + (double) pixel5.B * 0.11);
        double num5 = Convert.ToDouble((double) pixel6.R * 0.3 + (double) pixel6.G * 0.59 + (double) pixel6.B * 0.11);
        double num6 = Convert.ToDouble((double) pixel7.R * 0.3 + (double) pixel7.G * 0.59 + (double) pixel7.B * 0.11);
        double num7 = Convert.ToDouble((double) pixel8.R * 0.3 + (double) pixel8.G * 0.59 + (double) pixel8.B * 0.11);
        double num8 = Convert.ToDouble((double) pixel9.R * 0.3 + (double) pixel9.G * 0.59 + (double) pixel9.B * 0.11);
        int num9 = (int) (num1 + num2 + num3 - num6 - num7 - num8);
        int num10 = (int) (num1 - num3 + num4 - num5 + num6 - num8);
        int num11 = Math.Abs(num9) + Math.Abs(num10);
        if (num11 > (int) byte.MaxValue)
          num11 = (int) byte.MaxValue;
        if (num11 < 0)
          num11 = 0;
        bitmap2.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, num11, num11, num11));
      }
    }
    return bitmap2;
  }

  public Bitmap ImagePrewittFilterColor(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    for (int x = 1; x < bitmap1.Width - 1; ++x)
    {
      for (int y = 1; y < bitmap1.Height - 1; ++y)
      {
        Color pixel1 = bitmap1.GetPixel(x - 1, y - 1);
        Color pixel2 = bitmap1.GetPixel(x, y - 1);
        Color pixel3 = bitmap1.GetPixel(x + 1, y - 1);
        Color pixel4 = bitmap1.GetPixel(x - 1, y);
        Color pixel5 = bitmap1.GetPixel(x, y);
        Color pixel6 = bitmap1.GetPixel(x + 1, y);
        Color pixel7 = bitmap1.GetPixel(x - 1, y + 1);
        Color pixel8 = bitmap1.GetPixel(x, y + 1);
        Color pixel9 = bitmap1.GetPixel(x + 1, y + 1);
        double num1 = Convert.ToDouble(pixel1.R);
        double num2 = Convert.ToDouble(pixel2.R);
        double num3 = Convert.ToDouble(pixel3.R);
        double num4 = Convert.ToDouble(pixel4.R);
        Convert.ToDouble(pixel5.R);
        double num5 = Convert.ToDouble(pixel6.R);
        double num6 = Convert.ToDouble(pixel7.R);
        double num7 = Convert.ToDouble(pixel8.R);
        double num8 = Convert.ToDouble(pixel9.R);
        double num9 = Convert.ToDouble(pixel1.G);
        double num10 = Convert.ToDouble(pixel2.G);
        double num11 = Convert.ToDouble(pixel3.G);
        double num12 = Convert.ToDouble(pixel4.G);
        Convert.ToDouble(pixel5.G);
        double num13 = Convert.ToDouble(pixel6.G);
        double num14 = Convert.ToDouble(pixel7.G);
        double num15 = Convert.ToDouble(pixel8.G);
        double num16 = Convert.ToDouble(pixel9.G);
        double num17 = Convert.ToDouble(pixel1.B);
        double num18 = Convert.ToDouble(pixel2.B);
        double num19 = Convert.ToDouble(pixel3.B);
        double num20 = Convert.ToDouble(pixel4.B);
        Convert.ToDouble(pixel5.B);
        double num21 = Convert.ToDouble(pixel6.B);
        double num22 = Convert.ToDouble(pixel7.B);
        double num23 = Convert.ToDouble(pixel8.B);
        double num24 = Convert.ToDouble(pixel9.B);
        int num25 = (int) (num1 + num2 + num3 - num6 - num7 - num8);
        int num26 = (int) (num1 - num3 + num4 - num5 + num6 - num8);
        int red = Math.Abs(num25) + Math.Abs(num26);
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        int num27 = (int) (num9 + num10 + num11 - num14 - num15 - num16);
        int num28 = (int) (num9 - num11 + num12 - num13 + num14 - num16);
        int green = Math.Abs(num27) + Math.Abs(num28);
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        int num29 = (int) (num17 + num18 + num19 - num22 - num23 - num24);
        int num30 = (int) (num17 - num19 + num20 - num21 + num22 - num24);
        int blue = Math.Abs(num29) + Math.Abs(num30);
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x, y, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageMedianFilterGS(Bitmap OriginalImage, int size)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (size % 2 == 0)
      throw new Exception("Median filter dimesion must be odd.");
    int num1 = size >= 3 ? (int) Math.Floor(Convert.ToDouble(size / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[] array = new int[size * size];
        int index1 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            array[index1] = (int) num2;
            ++index1;
          }
        }
        Array.Sort<int>(array);
        int length = array.Length;
        int index2 = length / 2;
        int num3 = (int) (length % 2 != 0 ? (Decimal) array[index2] : ((Decimal) array[index2] + (Decimal) array[index2 + 1]) / 2M);
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num3, num3, num3));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageMedianFilterColor(Bitmap OriginalImage, int size)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (size % 2 == 0)
      throw new Exception("Median filter dimesion must be odd.");
    int num1 = size >= 3 ? (int) Math.Floor(Convert.ToDouble(size / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[] array1 = new int[size * size];
        int[] array2 = new int[size * size];
        int[] array3 = new int[size * size];
        int index1 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble(pixel.R);
            double num3 = Convert.ToDouble(pixel.G);
            double num4 = Convert.ToDouble(pixel.B);
            array1[index1] = (int) num2;
            array2[index1] = (int) num3;
            array3[index1] = (int) num4;
            ++index1;
          }
        }
        Array.Sort<int>(array1);
        Array.Sort<int>(array3);
        Array.Sort<int>(array2);
        int length = array1.Length;
        int index2 = length / 2;
        Decimal num5 = length % 2 != 0 ? (Decimal) array1[index2] : ((Decimal) array1[index2] + (Decimal) array1[index2 + 1]) / 2M;
        Decimal num6 = length % 2 != 0 ? (Decimal) array2[index2] : ((Decimal) array2[index2] + (Decimal) array2[index2 + 1]) / 2M;
        Decimal num7 = length % 2 != 0 ? (Decimal) array3[index2] : ((Decimal) array3[index2] + (Decimal) array3[index2 + 1]) / 2M;
        int red = (int) num5;
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        int green = (int) num6;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        int blue = (int) num7;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageErosionFilterGS(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    int length = 3;
    int num1 = (int) Math.Floor(Convert.ToDouble(1));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray = new int[length, length];
        int index1 = 0;
        int index2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray[index2, index1] = (int) num2;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] source = new int[length * length - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              source[index3] = numArray[index4, index5];
              ++index3;
            }
          }
        }
        int num3 = ((IEnumerable<int>) source).Min();
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num3, num3, num3));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageErosionFilterGS(Bitmap OriginalImage, int size)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (size % 2 == 0)
      throw new Exception("Filter filter dimesion must be odd.");
    int num1 = size >= 3 ? (int) Math.Floor(Convert.ToDouble(size / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray = new int[size, size];
        int index1 = 0;
        int index2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray[index2, index1] = (int) num2;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] source = new int[size * size - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              source[index3] = numArray[index4, index5];
              ++index3;
            }
          }
        }
        int num3 = ((IEnumerable<int>) source).Min();
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num3, num3, num3));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageDilatationFilterGS(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    int length = 3;
    int num1 = (int) Math.Floor(Convert.ToDouble(1));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray = new int[length, length];
        int index1 = 0;
        int index2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray[index2, index1] = (int) num2;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] source = new int[length * length - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              source[index3] = numArray[index4, index5];
              ++index3;
            }
          }
        }
        int num3 = ((IEnumerable<int>) source).Max();
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num3, num3, num3));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageDilatationFilterGS(Bitmap OriginalImage, int size)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (size % 2 == 0)
      throw new Exception("Filter filter dimesion must be odd.");
    int num1 = size >= 3 ? (int) Math.Floor(Convert.ToDouble(size / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray = new int[size, size];
        int index1 = 0;
        int index2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray[index2, index1] = (int) num2;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] source = new int[size * size - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              source[index3] = numArray[index4, index5];
              ++index3;
            }
          }
        }
        int num3 = ((IEnumerable<int>) source).Max();
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num3, num3, num3));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageSDROMFilterGS(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    int[] numArray1 = new int[4]{ 20, 40, 60, 80 /*0x50*/ };
    int length = 3;
    int num1 = (int) Math.Floor(Convert.ToDouble(1));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray2 = new int[length, length];
        int index1 = 0;
        int index2 = 0;
        Color pixel1 = bitmap1.GetPixel(x1, y1);
        int num2 = (int) Convert.ToDouble((double) pixel1.R * 0.3 + (double) pixel1.G * 0.59 + (double) pixel1.B * 0.11);
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel2 = bitmap1.GetPixel(x2, y2);
            double num3 = Convert.ToDouble((double) pixel2.R * 0.3 + (double) pixel2.G * 0.59 + (double) pixel2.B * 0.11);
            numArray2[index2, index1] = (int) num3;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] array = new int[length * length - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray2.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray2.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              array[index3] = numArray2[index4, index5];
              ++index3;
            }
          }
        }
        Array.Sort<int>(array);
        int index6 = array.Length / 2 - 1;
        int num4 = (int) ((Convert.ToDouble(array[index6]) + Convert.ToDouble(array[index6 + 1])) / 2.0);
        int[] numArray3 = new int[index6 + 1];
        for (int index7 = 0; index7 < index6; ++index7)
          numArray3[index7] = num2 > num4 ? num2 - array[array.GetLength(0) - 1 - index7] : array[index7] - num2;
        int num5 = num2;
        for (int index8 = 0; index8 < index6; ++index8)
        {
          if (numArray3[index8] > numArray1[index8])
          {
            num5 = num4;
            break;
          }
        }
        if (num5 > (int) byte.MaxValue)
          num5 = (int) byte.MaxValue;
        if (num5 < 0)
          num5 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num5, num5, num5));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageSDROMFilterGS(Bitmap OriginalImage, int size, int[] thresholds)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (size % 2 == 0)
      throw new Exception("SDROM filter dimesion must be odd.");
    if (size < 3)
      throw new Exception("SDROM filter dimesion must be positive greater or equal 3.");
    if (thresholds.GetLength(0) != (size * size - 1) / 2)
      throw new Exception($"Thresholds list size must be {((size * size - 1) / 2).ToString()} for used mask dimension");
    for (int index = 0; index < thresholds.GetLength(0) - 1; ++index)
    {
      if (thresholds[index] >= thresholds[index + 1])
        throw new Exception("Each next element of thresholds list must be greater then previous one.");
    }
    int num1 = (int) Math.Floor(Convert.ToDouble(size / 2));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray1 = new int[size, size];
        int index1 = 0;
        int index2 = 0;
        Color pixel1 = bitmap1.GetPixel(x1, y1);
        int num2 = (int) Convert.ToDouble((double) pixel1.R * 0.3 + (double) pixel1.G * 0.59 + (double) pixel1.B * 0.11);
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel2 = bitmap1.GetPixel(x2, y2);
            double num3 = Convert.ToDouble((double) pixel2.R * 0.3 + (double) pixel2.G * 0.59 + (double) pixel2.B * 0.11);
            numArray1[index2, index1] = (int) num3;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] array = new int[size * size - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray1.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray1.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              array[index3] = numArray1[index4, index5];
              ++index3;
            }
          }
        }
        Array.Sort<int>(array);
        int index6 = array.Length / 2 - 1;
        int num4 = (int) ((Convert.ToDouble(array[index6]) + Convert.ToDouble(array[index6 + 1])) / 2.0);
        int[] numArray2 = new int[index6 + 1];
        for (int index7 = 0; index7 < index6; ++index7)
          numArray2[index7] = num2 > num4 ? num2 - array[array.GetLength(0) - 1 - index7] : array[index7] - num2;
        int num5 = num2;
        for (int index8 = 0; index8 < index6; ++index8)
        {
          if (numArray2[index8] > thresholds[index8])
          {
            num5 = num4;
            break;
          }
        }
        if (num5 > (int) byte.MaxValue)
          num5 = (int) byte.MaxValue;
        if (num5 < 0)
          num5 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num5, num5, num5));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageSDROMFilterColor(Bitmap OriginalImage)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    int[] numArray1 = new int[4]{ 20, 40, 60, 80 /*0x50*/ };
    int length = 3;
    int num1 = (int) Math.Floor(Convert.ToDouble(1));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray2 = new int[length, length];
        int[,] numArray3 = new int[length, length];
        int[,] numArray4 = new int[length, length];
        int index1 = 0;
        int index2 = 0;
        Color pixel1 = bitmap1.GetPixel(x1, y1);
        int r = (int) pixel1.R;
        int g = (int) pixel1.G;
        int b = (int) pixel1.B;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel2 = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble(pixel2.R);
            double num3 = Convert.ToDouble(pixel2.G);
            double num4 = Convert.ToDouble(pixel2.B);
            numArray2[index2, index1] = (int) num2;
            numArray3[index2, index1] = (int) num3;
            numArray4[index2, index1] = (int) num4;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] array1 = new int[length * length - 1];
        int[] array2 = new int[length * length - 1];
        int[] array3 = new int[length * length - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray2.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray2.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              array1[index3] = numArray2[index4, index5];
              array2[index3] = numArray3[index4, index5];
              array3[index3] = numArray4[index4, index5];
              ++index3;
            }
          }
        }
        Array.Sort<int>(array1);
        Array.Sort<int>(array2);
        Array.Sort<int>(array3);
        int index6 = array1.Length / 2 - 1;
        int num5 = (int) ((Convert.ToDouble(array1[index6]) + Convert.ToDouble(array1[index6 + 1])) / 2.0);
        int num6 = (int) ((Convert.ToDouble(array2[index6]) + Convert.ToDouble(array2[index6 + 1])) / 2.0);
        int num7 = (int) ((Convert.ToDouble(array3[index6]) + Convert.ToDouble(array3[index6 + 1])) / 2.0);
        int[] numArray5 = new int[index6 + 1];
        int[] numArray6 = new int[index6 + 1];
        int[] numArray7 = new int[index6 + 1];
        for (int index7 = 0; index7 < index6; ++index7)
        {
          numArray5[index7] = r > num5 ? r - array1[array1.GetLength(0) - 1 - index7] : array1[index7] - r;
          numArray6[index7] = g > num6 ? g - array2[array2.GetLength(0) - 1 - index7] : array2[index7] - g;
          numArray7[index7] = b > num7 ? b - array3[array3.GetLength(0) - 1 - index7] : array3[index7] - b;
        }
        int red = r;
        for (int index8 = 0; index8 < index6; ++index8)
        {
          if (numArray5[index8] > numArray1[index8])
          {
            red = num5;
            break;
          }
        }
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        int green = g;
        for (int index9 = 0; index9 < index6; ++index9)
        {
          if (numArray6[index9] > numArray1[index9])
          {
            green = num6;
            break;
          }
        }
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        int blue = b;
        for (int index10 = 0; index10 < index6; ++index10)
        {
          if (numArray7[index10] > numArray1[index10])
          {
            blue = num7;
            break;
          }
        }
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageSDROMFilterColor(Bitmap OriginalImage, int size, int[] thresholds)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (size % 2 == 0)
      throw new Exception("SDROM filter dimesion must be odd.");
    if (size < 3)
      throw new Exception("SDROM filter dimesion must be positive greater or equal 3.");
    if (thresholds.GetLength(0) != (size * size - 1) / 2)
      throw new Exception($"Thresholds list size must be {((size * size - 1) / 2).ToString()} for used mask dimension");
    for (int index = 0; index < thresholds.GetLength(0) - 1; ++index)
    {
      if (thresholds[index] >= thresholds[index + 1])
        throw new Exception("Each next element of thresholds list must be greater then previous one.");
    }
    int num1 = (int) Math.Floor(Convert.ToDouble(size / 2));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray1 = new int[size, size];
        int[,] numArray2 = new int[size, size];
        int[,] numArray3 = new int[size, size];
        int index1 = 0;
        int index2 = 0;
        Color pixel1 = bitmap1.GetPixel(x1, y1);
        int r = (int) pixel1.R;
        int g = (int) pixel1.G;
        int b = (int) pixel1.B;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel2 = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble(pixel2.R);
            double num3 = Convert.ToDouble(pixel2.G);
            double num4 = Convert.ToDouble(pixel2.B);
            numArray1[index2, index1] = (int) num2;
            numArray2[index2, index1] = (int) num3;
            numArray3[index2, index1] = (int) num4;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] array1 = new int[size * size - 1];
        int[] array2 = new int[size * size - 1];
        int[] array3 = new int[size * size - 1];
        int index3 = 0;
        for (int index4 = 0; index4 < numArray1.GetLength(0); ++index4)
        {
          for (int index5 = 0; index5 < numArray1.GetLength(1); ++index5)
          {
            if ((index4 != num1 ? 0 : (index5 == num1 ? 1 : 0)) == 0)
            {
              array1[index3] = numArray1[index4, index5];
              array2[index3] = numArray2[index4, index5];
              array3[index3] = numArray3[index4, index5];
              ++index3;
            }
          }
        }
        Array.Sort<int>(array1);
        Array.Sort<int>(array2);
        Array.Sort<int>(array3);
        int index6 = array1.Length / 2 - 1;
        int num5 = (int) ((Convert.ToDouble(array1[index6]) + Convert.ToDouble(array1[index6 + 1])) / 2.0);
        int num6 = (int) ((Convert.ToDouble(array2[index6]) + Convert.ToDouble(array2[index6 + 1])) / 2.0);
        int num7 = (int) ((Convert.ToDouble(array3[index6]) + Convert.ToDouble(array3[index6 + 1])) / 2.0);
        int[] numArray4 = new int[index6 + 1];
        int[] numArray5 = new int[index6 + 1];
        int[] numArray6 = new int[index6 + 1];
        for (int index7 = 0; index7 < index6; ++index7)
        {
          numArray4[index7] = r > num5 ? r - array1[array1.GetLength(0) - 1 - index7] : array1[index7] - r;
          numArray5[index7] = g > num6 ? g - array2[array2.GetLength(0) - 1 - index7] : array2[index7] - g;
          numArray6[index7] = b > num7 ? b - array3[array3.GetLength(0) - 1 - index7] : array3[index7] - b;
        }
        int red = r;
        for (int index8 = 0; index8 < index6; ++index8)
        {
          if (numArray4[index8] > thresholds[index8])
          {
            red = num5;
            break;
          }
        }
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        int green = g;
        for (int index9 = 0; index9 < index6; ++index9)
        {
          if (numArray5[index9] > thresholds[index9])
          {
            green = num6;
            break;
          }
        }
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        int blue = b;
        for (int index10 = 0; index10 < index6; ++index10)
        {
          if (numArray6[index10] > thresholds[index10])
          {
            blue = num7;
            break;
          }
        }
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageOpenGS(Bitmap OriginalImage)
  {
    return this.ImageDilatationFilterGS(this.ImageErosionFilterGS(OriginalImage));
  }

  public Bitmap ImageOpenGS(Bitmap OriginalImage, int size)
  {
    return this.ImageDilatationFilterGS(this.ImageErosionFilterGS(OriginalImage, size), size);
  }

  public Bitmap ImageCloseGS(Bitmap OriginalImage)
  {
    return this.ImageErosionFilterGS(this.ImageDilatationFilterGS(OriginalImage));
  }

  public Bitmap ImageCloseGS(Bitmap OriginalImage, int size)
  {
    return this.ImageErosionFilterGS(this.ImageDilatationFilterGS(OriginalImage, size), size);
  }

  public Bitmap ColorFiltration(Bitmap OriginalImage, string color)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    if ((!(color != "Magenta") || !(color != "Yellow") || !(color != "Cyan") || !(color != "Magenta-Yellow") || !(color != "Cyan-Magenta") ? 0 : (color != "Yellow-Cyan" ? 1 : 0)) != 0)
      throw new Exception("Available color filters are: Magenta, Yellow, Cyan, Magenta-Yellow, Cyan-Magenta, Yellow-Cyan");
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int r = (int) pixel.R;
        int g = (int) pixel.G;
        int b = (int) pixel.B;
        Color color1;
        switch (color)
        {
          case "Magenta":
            color1 = Color.FromArgb((int) byte.MaxValue, r, 0, b);
            break;
          case "Yellow":
            color1 = Color.FromArgb((int) byte.MaxValue, r, g, 0);
            break;
          case "Cyan":
            color1 = Color.FromArgb((int) byte.MaxValue, 0, g, b);
            break;
          case "Magenta-Yellow":
            color1 = Color.FromArgb((int) byte.MaxValue, r, 0, 0);
            break;
          case "Yellow-Cyan":
            color1 = Color.FromArgb((int) byte.MaxValue, 0, g, 0);
            break;
          case "Cyan-Magenta":
            color1 = Color.FromArgb((int) byte.MaxValue, 0, 0, b);
            break;
          default:
            color1 = Color.FromArgb((int) byte.MaxValue, r, g, b);
            break;
        }
        bitmap.SetPixel(x, y, color1);
      }
    }
    return bitmap;
  }

  public Bitmap GammaCorrection(Bitmap OriginalImage, double Gamma)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int red = (int) ((double) byte.MaxValue * Math.Pow(Convert.ToDouble(pixel.R) / (double) byte.MaxValue, Gamma));
        int green = (int) ((double) byte.MaxValue * Math.Pow(Convert.ToDouble(pixel.G) / (double) byte.MaxValue, Gamma));
        int blue = (int) ((double) byte.MaxValue * Math.Pow(Convert.ToDouble(pixel.B) / (double) byte.MaxValue, Gamma));
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, red, green, blue);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap GammaCorrectionGS(Bitmap OriginalImage, double Gamma)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num = (int) ((double) byte.MaxValue * Math.Pow(Convert.ToDouble((int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11)) / (double) byte.MaxValue, Gamma));
        if (num > (int) byte.MaxValue)
          num = (int) byte.MaxValue;
        if (num < 0)
          num = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, num, num, num);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap Sepia(Bitmap OriginalImage, double Coef)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        int num = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
        int red = (int) ((double) num + 2.0 * Coef);
        int green = (int) ((double) num + Coef);
        int blue = num;
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, red, green, blue);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap ColorAccent(Bitmap OriginalImage, double h, double range)
  {
    Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    double num1 = (h - range / 2.0 + 360.0) % 360.0;
    double num2 = (h + range / 2.0 + 360.0) % 360.0;
    for (int x = 0; x < OriginalImage.Width; ++x)
    {
      for (int y = 0; y < OriginalImage.Height; ++y)
      {
        Color pixel = OriginalImage.GetPixel(x, y);
        double[] numArray = this.rgb2hsv(pixel);
        int red;
        int green;
        int blue;
        if (num1 <= num2)
        {
          if ((numArray[0] > num2 ? 0 : (numArray[0] >= num1 ? 1 : 0)) != 0)
          {
            red = (int) pixel.R;
            green = (int) pixel.G;
            blue = (int) pixel.B;
          }
          else
          {
            int num3 = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            red = num3;
            green = num3;
            blue = num3;
          }
        }
        else if ((numArray[0] <= num2 ? 1 : (numArray[0] >= num1 ? 1 : 0)) != 0)
        {
          red = (int) pixel.R;
          green = (int) pixel.G;
          blue = (int) pixel.B;
        }
        else
        {
          int num4 = (int) ((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
          red = num4;
          green = num4;
          blue = num4;
        }
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        Color color = Color.FromArgb((int) byte.MaxValue, red, green, blue);
        bitmap.SetPixel(x, y, color);
      }
    }
    return bitmap;
  }

  public Bitmap ImageKuwaharaFilterGS(Bitmap OriginalImage, int FilterSize)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (FilterSize % 2 == 0)
      throw new Exception("Filter size must be odd.");
    if (FilterSize < 3)
      throw new Exception("Filter size must be positive greater then 2.");
    int length = 2 * FilterSize - 1;
    int num1 = (int) Math.Floor(Convert.ToDouble(length / 2));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,] numArray1 = new int[length, length];
        int index1 = 0;
        int index2 = 0;
        bitmap1.GetPixel(x1, y1);
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble((double) pixel.R * 0.3 + (double) pixel.G * 0.59 + (double) pixel.B * 0.11);
            numArray1[index2, index1] = (int) num2;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[] numArray2 = new int[FilterSize * FilterSize];
        int[] numArray3 = new int[FilterSize * FilterSize];
        int[] numArray4 = new int[FilterSize * FilterSize];
        int[] numArray5 = new int[FilterSize * FilterSize];
        int index3 = 0;
        for (int index4 = 0; index4 < FilterSize; ++index4)
        {
          for (int index5 = 0; index5 < FilterSize; ++index5)
          {
            numArray2[index3] = numArray1[index4, index5];
            ++index3;
          }
        }
        int index6 = 0;
        for (int index7 = 0; index7 < FilterSize; ++index7)
        {
          for (int index8 = FilterSize - 1; index8 < numArray1.GetLength(1); ++index8)
          {
            numArray3[index6] = numArray1[index7, index8];
            ++index6;
          }
        }
        int index9 = 0;
        for (int index10 = FilterSize - 1; index10 < numArray1.GetLength(0); ++index10)
        {
          for (int index11 = 0; index11 < FilterSize; ++index11)
          {
            numArray4[index9] = numArray1[index10, index11];
            ++index9;
          }
        }
        int index12 = 0;
        for (int index13 = FilterSize - 1; index13 < numArray1.GetLength(0); ++index13)
        {
          for (int index14 = FilterSize - 1; index14 < numArray1.GetLength(1); ++index14)
          {
            numArray5[index12] = numArray1[index13, index14];
            ++index12;
          }
        }
        double[] numArray6 = new double[4];
        double[] numArray7 = new double[4];
        for (int index15 = 0; index15 < FilterSize * FilterSize; ++index15)
        {
          numArray6[0] += Convert.ToDouble(numArray2[index15]) / (double) (FilterSize * FilterSize);
          numArray6[1] += Convert.ToDouble(numArray3[index15]) / (double) (FilterSize * FilterSize);
          numArray6[2] += Convert.ToDouble(numArray4[index15]) / (double) (FilterSize * FilterSize);
          numArray6[3] += Convert.ToDouble(numArray5[index15]) / (double) (FilterSize * FilterSize);
        }
        for (int index16 = 0; index16 < FilterSize * FilterSize; ++index16)
        {
          numArray7[0] += Math.Pow(Convert.ToDouble(numArray2[index16]) - numArray6[0], 2.0) / (double) (FilterSize * FilterSize);
          numArray7[1] += Math.Pow(Convert.ToDouble(numArray3[index16]) - numArray6[1], 2.0) / (double) (FilterSize * FilterSize);
          numArray7[2] += Math.Pow(Convert.ToDouble(numArray4[index16]) - numArray6[2], 2.0) / (double) (FilterSize * FilterSize);
          numArray7[3] += Math.Pow(Convert.ToDouble(numArray5[index16]) - numArray6[3], 2.0) / (double) (FilterSize * FilterSize);
        }
        int index17 = Array.IndexOf<double>(numArray7, ((IEnumerable<double>) numArray7).Min());
        int num3 = (int) numArray6[index17];
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, num3, num3, num3));
      }
    }
    return bitmap2;
  }

  public Bitmap ImageKuwaharaFilterColor(Bitmap OriginalImage, int FilterSize)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if (FilterSize % 2 == 0)
      throw new Exception("Filter size must be odd.");
    if (FilterSize < 3)
      throw new Exception("Filter size must be positive greater then 2.");
    int length = 2 * FilterSize - 1;
    int num1 = (int) Math.Floor(Convert.ToDouble(length / 2));
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        int[,,] numArray1 = new int[3, length, length];
        int index1 = 0;
        int index2 = 0;
        bitmap1.GetPixel(x1, y1);
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble(pixel.R);
            double num3 = Convert.ToDouble(pixel.G);
            double num4 = Convert.ToDouble(pixel.B);
            numArray1[0, index2, index1] = (int) num2;
            numArray1[1, index2, index1] = (int) num3;
            numArray1[2, index2, index1] = (int) num4;
            ++index1;
          }
          ++index2;
          index1 = 0;
        }
        int[,] numArray2 = new int[3, FilterSize * FilterSize];
        int[,] numArray3 = new int[3, FilterSize * FilterSize];
        int[,] numArray4 = new int[3, FilterSize * FilterSize];
        int[,] numArray5 = new int[3, FilterSize * FilterSize];
        int index3 = 0;
        for (int index4 = 0; index4 < FilterSize; ++index4)
        {
          for (int index5 = 0; index5 < FilterSize; ++index5)
          {
            numArray2[0, index3] = numArray1[0, index4, index5];
            numArray2[1, index3] = numArray1[1, index4, index5];
            numArray2[2, index3] = numArray1[2, index4, index5];
            ++index3;
          }
        }
        int index6 = 0;
        for (int index7 = 0; index7 < FilterSize; ++index7)
        {
          for (int index8 = FilterSize - 1; index8 < numArray1.GetLength(1); ++index8)
          {
            numArray3[0, index6] = numArray1[0, index7, index8];
            numArray3[1, index6] = numArray1[1, index7, index8];
            numArray3[2, index6] = numArray1[2, index7, index8];
            ++index6;
          }
        }
        int index9 = 0;
        for (int index10 = FilterSize - 1; index10 < numArray1.GetLength(0); ++index10)
        {
          for (int index11 = 0; index11 < FilterSize; ++index11)
          {
            numArray4[0, index9] = numArray1[0, index10, index11];
            numArray4[1, index9] = numArray1[1, index10, index11];
            numArray4[2, index9] = numArray1[2, index10, index11];
            ++index9;
          }
        }
        int index12 = 0;
        for (int index13 = FilterSize - 1; index13 < numArray1.GetLength(0); ++index13)
        {
          for (int index14 = FilterSize - 1; index14 < numArray1.GetLength(1); ++index14)
          {
            numArray5[0, index12] = numArray1[0, index13, index14];
            numArray5[1, index12] = numArray1[1, index13, index14];
            numArray5[2, index12] = numArray1[2, index13, index14];
            ++index12;
          }
        }
        double[] numArray6 = new double[4];
        double[] numArray7 = new double[4];
        double[] numArray8 = new double[4];
        double[] numArray9 = new double[4];
        double[] numArray10 = new double[4];
        double[] numArray11 = new double[4];
        for (int index15 = 0; index15 < FilterSize * FilterSize; ++index15)
        {
          numArray6[0] += Convert.ToDouble(numArray2[0, index15]) / (double) (FilterSize * FilterSize);
          numArray6[1] += Convert.ToDouble(numArray3[0, index15]) / (double) (FilterSize * FilterSize);
          numArray6[2] += Convert.ToDouble(numArray4[0, index15]) / (double) (FilterSize * FilterSize);
          numArray6[3] += Convert.ToDouble(numArray5[0, index15]) / (double) (FilterSize * FilterSize);
          numArray7[0] += Convert.ToDouble(numArray2[1, index15]) / (double) (FilterSize * FilterSize);
          numArray7[1] += Convert.ToDouble(numArray3[1, index15]) / (double) (FilterSize * FilterSize);
          numArray7[2] += Convert.ToDouble(numArray4[1, index15]) / (double) (FilterSize * FilterSize);
          numArray7[3] += Convert.ToDouble(numArray5[1, index15]) / (double) (FilterSize * FilterSize);
          numArray8[0] += Convert.ToDouble(numArray2[2, index15]) / (double) (FilterSize * FilterSize);
          numArray8[1] += Convert.ToDouble(numArray3[2, index15]) / (double) (FilterSize * FilterSize);
          numArray8[2] += Convert.ToDouble(numArray4[2, index15]) / (double) (FilterSize * FilterSize);
          numArray8[3] += Convert.ToDouble(numArray5[2, index15]) / (double) (FilterSize * FilterSize);
        }
        for (int index16 = 0; index16 < FilterSize * FilterSize; ++index16)
        {
          numArray9[0] += Math.Pow(Convert.ToDouble(numArray2[0, index16]) - numArray6[0], 2.0) / (double) (FilterSize * FilterSize);
          numArray9[1] += Math.Pow(Convert.ToDouble(numArray3[0, index16]) - numArray6[1], 2.0) / (double) (FilterSize * FilterSize);
          numArray9[2] += Math.Pow(Convert.ToDouble(numArray4[0, index16]) - numArray6[2], 2.0) / (double) (FilterSize * FilterSize);
          numArray9[3] += Math.Pow(Convert.ToDouble(numArray5[0, index16]) - numArray6[3], 2.0) / (double) (FilterSize * FilterSize);
          numArray10[0] += Math.Pow(Convert.ToDouble(numArray2[1, index16]) - numArray7[0], 2.0) / (double) (FilterSize * FilterSize);
          numArray10[1] += Math.Pow(Convert.ToDouble(numArray3[1, index16]) - numArray7[1], 2.0) / (double) (FilterSize * FilterSize);
          numArray10[2] += Math.Pow(Convert.ToDouble(numArray4[1, index16]) - numArray7[2], 2.0) / (double) (FilterSize * FilterSize);
          numArray10[3] += Math.Pow(Convert.ToDouble(numArray5[1, index16]) - numArray7[3], 2.0) / (double) (FilterSize * FilterSize);
          numArray11[0] += Math.Pow(Convert.ToDouble(numArray2[2, index16]) - numArray8[0], 2.0) / (double) (FilterSize * FilterSize);
          numArray11[1] += Math.Pow(Convert.ToDouble(numArray3[2, index16]) - numArray8[1], 2.0) / (double) (FilterSize * FilterSize);
          numArray11[2] += Math.Pow(Convert.ToDouble(numArray4[2, index16]) - numArray8[2], 2.0) / (double) (FilterSize * FilterSize);
          numArray11[3] += Math.Pow(Convert.ToDouble(numArray5[2, index16]) - numArray8[3], 2.0) / (double) (FilterSize * FilterSize);
        }
        int index17 = Array.IndexOf<double>(numArray9, ((IEnumerable<double>) numArray9).Min());
        int index18 = Array.IndexOf<double>(numArray10, ((IEnumerable<double>) numArray10).Min());
        int index19 = Array.IndexOf<double>(numArray11, ((IEnumerable<double>) numArray11).Min());
        int red = (int) numArray6[index17];
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        int green = (int) numArray7[index18];
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        int blue = (int) numArray8[index19];
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap TiltShift(Bitmap OriginalImage)
  {
    int width = OriginalImage.Width;
    int height = OriginalImage.Height;
    Bitmap bitmap = new Bitmap(width, height);
    int num1 = height / 2;
    int num2 = num1 + num1 / 2;
    Color pixel;
    for (int x = 0; x < width; ++x)
    {
      for (int y1 = 0; y1 < height; ++y1)
      {
        if ((y1 < num1 ? 0 : (y1 <= num2 ? 1 : 0)) != 0)
          bitmap.SetPixel(x, y1, OriginalImage.GetPixel(x, y1));
        else if (y1 < num1)
        {
          double num3 = 0.1 + 5.9 * Convert.ToDouble(num1 - y1) / Convert.ToDouble(num1);
          List<double> doubleList = new List<double>();
          for (int index = 0; index < 1000; ++index)
          {
            double num4 = Convert.ToDouble(index);
            double num5 = 1.0 / (Math.Sqrt(2.0 * Math.PI) * num3) * Math.Exp(-num4 * num4 / (2.0 * num3 * num3));
            if (num5 >= 0.003)
              doubleList.Add(num5);
            else
              break;
          }
          double num6 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num7 = Convert.ToDouble(pixel.R);
          double num8 = num6 * num7;
          double num9 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num10 = Convert.ToDouble(pixel.G);
          double num11 = num9 * num10;
          double num12 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num13 = Convert.ToDouble(pixel.B);
          double num14 = num12 * num13;
          double num15 = doubleList[0];
          for (int index = 1; index < doubleList.Count; ++index)
            num15 += 2.0 * doubleList[index];
          for (int index = 1; index < doubleList.Count; ++index)
          {
            int y2 = y1 - index;
            int y3 = y1 + index;
            if (y2 < 0)
              Math.Abs(y2);
            else if (y3 >= height)
            {
              int num16 = y3 + index - height + 1;
            }
            else
            {
              double num17 = num8;
              double num18 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y2);
              double num19 = Convert.ToDouble(pixel.R);
              pixel = OriginalImage.GetPixel(x, y3);
              double num20 = Convert.ToDouble(pixel.R);
              double num21 = num19 + num20;
              double num22 = num18 * num21;
              num8 = num17 + num22;
              double num23 = num11;
              double num24 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y2);
              double num25 = Convert.ToDouble(pixel.G);
              pixel = OriginalImage.GetPixel(x, y3);
              double num26 = Convert.ToDouble(pixel.G);
              double num27 = num25 + num26;
              double num28 = num24 * num27;
              num11 = num23 + num28;
              double num29 = num14;
              double num30 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y2);
              double num31 = Convert.ToDouble(pixel.B);
              pixel = OriginalImage.GetPixel(x, y3);
              double num32 = Convert.ToDouble(pixel.B);
              double num33 = num31 + num32;
              double num34 = num30 * num33;
              num14 = num29 + num34;
            }
          }
          int red = (int) (num8 / num15);
          int green = (int) (num11 / num15);
          int blue = (int) (num14 / num15);
          if (red > (int) byte.MaxValue)
            red = (int) byte.MaxValue;
          if (red < 0)
            red = 0;
          if (green > (int) byte.MaxValue)
            green = (int) byte.MaxValue;
          if (green < 0)
            green = 0;
          if (blue > (int) byte.MaxValue)
            blue = (int) byte.MaxValue;
          if (blue < 0)
            blue = 0;
          bitmap.SetPixel(x, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
        }
        else if (y1 > num2)
        {
          double num35 = 0.1 + 5.9 * Convert.ToDouble(y1 - num2) / Convert.ToDouble(num1);
          List<double> doubleList = new List<double>();
          for (int index = 0; index < 1000; ++index)
          {
            double num36 = Convert.ToDouble(index);
            double num37 = 1.0 / (Math.Sqrt(2.0 * Math.PI) * num35) * Math.Exp(-num36 * num36 / (2.0 * num35 * num35));
            if (num37 >= 0.003)
              doubleList.Add(num37);
            else
              break;
          }
          double num38 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num39 = Convert.ToDouble(pixel.R);
          double num40 = num38 * num39;
          double num41 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num42 = Convert.ToDouble(pixel.G);
          double num43 = num41 * num42;
          double num44 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num45 = Convert.ToDouble(pixel.B);
          double num46 = num44 * num45;
          double num47 = doubleList[0];
          for (int index = 1; index < doubleList.Count; ++index)
            num47 += 2.0 * doubleList[index];
          for (int index = 1; index < doubleList.Count; ++index)
          {
            int y4 = y1 - index;
            int y5 = y1 + index;
            if (y4 < 0)
              Math.Abs(y4);
            else if (y5 >= height)
            {
              int num48 = y5 + index - height + 1;
            }
            else
            {
              double num49 = num40;
              double num50 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y4);
              double num51 = Convert.ToDouble(pixel.R);
              pixel = OriginalImage.GetPixel(x, y5);
              double num52 = Convert.ToDouble(pixel.R);
              double num53 = num51 + num52;
              double num54 = num50 * num53;
              num40 = num49 + num54;
              double num55 = num43;
              double num56 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y4);
              double num57 = Convert.ToDouble(pixel.G);
              pixel = OriginalImage.GetPixel(x, y5);
              double num58 = Convert.ToDouble(pixel.G);
              double num59 = num57 + num58;
              double num60 = num56 * num59;
              num43 = num55 + num60;
              double num61 = num46;
              double num62 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y4);
              double num63 = Convert.ToDouble(pixel.B);
              pixel = OriginalImage.GetPixel(x, y5);
              double num64 = Convert.ToDouble(pixel.B);
              double num65 = num63 + num64;
              double num66 = num62 * num65;
              num46 = num61 + num66;
            }
          }
          int red = (int) (num40 / num47);
          int green = (int) (num43 / num47);
          int blue = (int) (num46 / num47);
          if (red > (int) byte.MaxValue)
            red = (int) byte.MaxValue;
          if (red < 0)
            red = 0;
          if (green > (int) byte.MaxValue)
            green = (int) byte.MaxValue;
          if (green < 0)
            green = 0;
          if (blue > (int) byte.MaxValue)
            blue = (int) byte.MaxValue;
          if (blue < 0)
            blue = 0;
          bitmap.SetPixel(x, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
        }
      }
    }
    return bitmap;
  }

  public Bitmap Blurring(Bitmap OriginalImage, int X, int Y, double r)
  {
    int width = OriginalImage.Width;
    int height = OriginalImage.Height;
    if ((X < 0 || X >= width || Y < 0 ? 1 : (Y >= height ? 1 : 0)) != 0)
      throw new Exception("Center of sharp region must be in dimensions of image");
    Bitmap bitmap = new Bitmap(width, height);
    for (int x = 0; x < width; ++x)
    {
      for (int y1 = 0; y1 < height; ++y1)
      {
        double num1 = Math.Abs(Convert.ToDouble(x) - Convert.ToDouble(X));
        double num2 = Math.Abs(Convert.ToDouble(y1) - Convert.ToDouble(Y));
        double num3 = Math.Sqrt(num1 * num1 + num2 * num2);
        if (num3 <= r)
        {
          bitmap.SetPixel(x, y1, OriginalImage.GetPixel(x, y1));
        }
        else
        {
          double num4 = 0.1 + 5.9 * Convert.ToDouble(num3) / Convert.ToDouble(2.0 * r);
          List<double> doubleList = new List<double>();
          for (int index = 0; index < 1000; ++index)
          {
            double num5 = Convert.ToDouble(index);
            double num6 = 1.0 / (Math.Sqrt(2.0 * Math.PI) * num4) * Math.Exp(-num5 * num5 / (2.0 * num4 * num4));
            if (num6 >= 0.003)
              doubleList.Add(num6);
            else
              break;
          }
          double num7 = doubleList[0];
          Color pixel = OriginalImage.GetPixel(x, y1);
          double num8 = Convert.ToDouble(pixel.R);
          double num9 = num7 * num8;
          double num10 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num11 = Convert.ToDouble(pixel.G);
          double num12 = num10 * num11;
          double num13 = doubleList[0];
          pixel = OriginalImage.GetPixel(x, y1);
          double num14 = Convert.ToDouble(pixel.B);
          double num15 = num13 * num14;
          double num16 = doubleList[0];
          for (int index = 1; index < doubleList.Count; ++index)
            num16 += 2.0 * doubleList[index];
          for (int index = 1; index < doubleList.Count; ++index)
          {
            int y2 = y1 - index;
            int y3 = y1 + index;
            if (y2 < 0)
              Math.Abs(y2);
            else if (y3 >= height)
            {
              int num17 = y3 + index - height + 1;
            }
            else
            {
              double num18 = num9;
              double num19 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y2);
              double num20 = Convert.ToDouble(pixel.R);
              pixel = OriginalImage.GetPixel(x, y3);
              double num21 = Convert.ToDouble(pixel.R);
              double num22 = num20 + num21;
              double num23 = num19 * num22;
              num9 = num18 + num23;
              double num24 = num12;
              double num25 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y2);
              double num26 = Convert.ToDouble(pixel.G);
              pixel = OriginalImage.GetPixel(x, y3);
              double num27 = Convert.ToDouble(pixel.G);
              double num28 = num26 + num27;
              double num29 = num25 * num28;
              num12 = num24 + num29;
              double num30 = num15;
              double num31 = doubleList[index];
              pixel = OriginalImage.GetPixel(x, y2);
              double num32 = Convert.ToDouble(pixel.B);
              pixel = OriginalImage.GetPixel(x, y3);
              double num33 = Convert.ToDouble(pixel.B);
              double num34 = num32 + num33;
              double num35 = num31 * num34;
              num15 = num30 + num35;
            }
          }
          int red = (int) (num9 / num16);
          int green = (int) (num12 / num16);
          int blue = (int) (num15 / num16);
          if (red > (int) byte.MaxValue)
            red = (int) byte.MaxValue;
          if (red < 0)
            red = 0;
          if (green > (int) byte.MaxValue)
            green = (int) byte.MaxValue;
          if (green < 0)
            green = 0;
          if (blue > (int) byte.MaxValue)
            blue = (int) byte.MaxValue;
          if (blue < 0)
            blue = 0;
          bitmap.SetPixel(x, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
        }
      }
    }
    return bitmap;
  }

  public Bitmap OilPaint(Bitmap OriginalImage, int R, int Level)
  {
    Bitmap bitmap1 = OriginalImage;
    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
    if ((Level < 1 ? 1 : (Level > (int) byte.MaxValue ? 1 : 0)) != 0)
      throw new Exception("Available intensity levels must be between 1 and 255");
    if (R % 2 == 0)
      throw new Exception("Filter mask dimesion must be odd.");
    int num1 = R >= 3 ? (int) Math.Floor(Convert.ToDouble(R / 2)) : throw new Exception("Filter mask dimesion must be greater or equal 3.");
    for (int x1 = num1; x1 < bitmap1.Width - num1; ++x1)
    {
      for (int y1 = num1; y1 < bitmap1.Height - num1; ++y1)
      {
        double[,,] numArray1 = new double[3, R, R];
        int index1 = 0;
        int index2 = 0;
        for (int x2 = x1 - num1; x2 < x1 + num1 + 1; ++x2)
        {
          for (int y2 = y1 - num1; y2 < y1 + num1 + 1; ++y2)
          {
            Color pixel = bitmap1.GetPixel(x2, y2);
            double num2 = Convert.ToDouble(pixel.R);
            double num3 = Convert.ToDouble(pixel.G);
            double num4 = Convert.ToDouble(pixel.B);
            numArray1[0, index1, index2] = (double) (int) num2;
            numArray1[1, index1, index2] = (double) (int) num3;
            numArray1[2, index1, index2] = (double) (int) num4;
            ++index2;
          }
          ++index1;
          index2 = 0;
        }
        int[] numArray2 = new int[256 /*0x0100*/];
        int[] numArray3 = new int[256 /*0x0100*/];
        int[] numArray4 = new int[256 /*0x0100*/];
        int[] numArray5 = new int[256 /*0x0100*/];
        for (int index3 = 0; index3 < R; ++index3)
        {
          for (int index4 = 0; index4 < R; ++index4)
          {
            int index5 = (int) ((numArray1[0, index3, index4] + numArray1[1, index3, index4] + numArray1[2, index3, index4]) / 3.0 * Convert.ToDouble(Level) / (double) byte.MaxValue);
            ++numArray5[index5];
            numArray2[index5] += (int) numArray1[0, index3, index4];
            numArray3[index5] += (int) numArray1[1, index3, index4];
            numArray4[index5] += (int) numArray1[2, index3, index4];
          }
        }
        int num5 = 0;
        int index6 = 0;
        for (int index7 = 0; index7 < 256 /*0x0100*/; ++index7)
        {
          if (numArray5[index7] > num5)
          {
            num5 = numArray5[index7];
            index6 = index7;
          }
        }
        int red = numArray2[index6] / num5;
        int green = numArray3[index6] / num5;
        int blue = numArray4[index6] / num5;
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (green < 0)
          green = 0;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (blue < 0)
          blue = 0;
        bitmap2.SetPixel(x1, y1, Color.FromArgb((int) byte.MaxValue, red, green, blue));
      }
    }
    return bitmap2;
  }

  public Bitmap Cartoon(Bitmap OriginalImage, int R, int Level, int InverseThreshold)
  {
    Bitmap OriginalImage1 = OriginalImage;
    Bitmap bitmap1 = new Bitmap(OriginalImage1.Width, OriginalImage1.Height);
    Bitmap bitmap2 = this.OilPaint(OriginalImage1, R, Level);
    Bitmap blackwhiteInverse = this.ToBlackwhiteInverse(this.ImageSobelFilterGS(OriginalImage1), InverseThreshold);
    for (int x = 0; x < OriginalImage1.Width; ++x)
    {
      for (int y = 0; y < OriginalImage1.Height; ++y)
      {
        if (blackwhiteInverse.GetPixel(x, y).R == byte.MaxValue)
          bitmap1.SetPixel(x, y, bitmap2.GetPixel(x, y));
        else
          bitmap1.SetPixel(x, y, blackwhiteInverse.GetPixel(x, y));
      }
    }
    return bitmap1;
  }

  public Bitmap Cartoon(
    Bitmap OriginalImage,
    int R,
    int Level,
    int InverseThreshold,
    int[,] EdgeFilter)
  {
    Bitmap OriginalImage1 = OriginalImage;
    Bitmap bitmap1 = new Bitmap(OriginalImage1.Width, OriginalImage1.Height);
    Bitmap bitmap2 = this.OilPaint(OriginalImage1, R, Level);
    Bitmap blackwhiteInverse = this.ToBlackwhiteInverse(this.ImageFilterGS(OriginalImage1, EdgeFilter), InverseThreshold);
    for (int x = 0; x < OriginalImage1.Width; ++x)
    {
      for (int y = 0; y < OriginalImage1.Height; ++y)
      {
        if (blackwhiteInverse.GetPixel(x, y).R == byte.MaxValue)
          bitmap1.SetPixel(x, y, bitmap2.GetPixel(x, y));
        else
          bitmap1.SetPixel(x, y, blackwhiteInverse.GetPixel(x, y));
      }
    }
    return bitmap1;
  }

  public Bitmap SketchCharcoal(Bitmap OriginalImage)
  {
    return this.ImageMedianFilterGS(this.InverseImage(this.ImageSobelFilterGS(this.ImageMedianFilterGS(OriginalImage, 5)), 80 /*0x50*/), 5);
  }

  public Bitmap Sketch(Bitmap OriginalImage)
  {
    return this.ImageSDROMFilterGS(this.ToBlackwhiteInverse(this.ImageFilterGS(OriginalImage, this.LaplaceF1()), 35));
  }
}
