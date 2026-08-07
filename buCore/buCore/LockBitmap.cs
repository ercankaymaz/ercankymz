// Decompiled with JetBrains decompiler
// Type: buCore.LockBitmap
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

#nullable disable
namespace buCore;

public class LockBitmap
{
  private Bitmap source = (Bitmap) null;
  private IntPtr intptr_0 = IntPtr.Zero;
  private BitmapData bitmapData_0 = (BitmapData) null;

  public byte[] Pixels { get; set; }

  public int Depth { get; private set; }

  public int Width { get; private set; }

  public int Height { get; private set; }

  public LockBitmap(Bitmap source) => this.source = source;

  public void LockBits()
  {
    try
    {
      this.Width = this.source.Width;
      this.Height = this.source.Height;
      int num1 = this.Width * this.Height;
      Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
      this.Depth = Image.GetPixelFormatSize(this.source.PixelFormat);
      if ((this.Depth == 8 || this.Depth == 24 ? 0 : (this.Depth != 32 /*0x20*/ ? 1 : 0)) != 0)
        throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
      this.bitmapData_0 = this.source.LockBits(rect, ImageLockMode.ReadWrite, this.source.PixelFormat);
      int num2 = this.Depth / 8;
      this.Pixels = new byte[num1 * num2];
      this.intptr_0 = this.bitmapData_0.Scan0;
      Marshal.Copy(this.intptr_0, this.Pixels, 0, this.Pixels.Length);
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  public void UnlockBits()
  {
    try
    {
      Marshal.Copy(this.Pixels, 0, this.intptr_0, this.Pixels.Length);
      this.source.UnlockBits(this.bitmapData_0);
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  public Color GetPixel(int x, int y)
  {
    Color pixel1 = Color.Empty;
    int num = this.Depth / 8;
    int index = (y * this.Width + x) * num;
    if (index > this.Pixels.Length - num)
      throw new IndexOutOfRangeException();
    if (this.Depth == 32 /*0x20*/)
    {
      byte pixel2 = this.Pixels[index];
      byte pixel3 = this.Pixels[index + 1];
      byte pixel4 = this.Pixels[index + 2];
      pixel1 = Color.FromArgb((int) this.Pixels[index + 3], (int) pixel4, (int) pixel3, (int) pixel2);
    }
    if (this.Depth == 24)
    {
      byte pixel5 = this.Pixels[index];
      byte pixel6 = this.Pixels[index + 1];
      pixel1 = Color.FromArgb((int) this.Pixels[index + 2], (int) pixel6, (int) pixel5);
    }
    if (this.Depth == 8)
    {
      byte pixel7 = this.Pixels[index];
      pixel1 = Color.FromArgb((int) pixel7, (int) pixel7, (int) pixel7);
    }
    return pixel1;
  }

  public void SetPixel(int x, int y, Color color)
  {
    int num = this.Depth / 8;
    int index = (y * this.Width + x) * num;
    if (this.Depth == 32 /*0x20*/)
    {
      this.Pixels[index] = color.B;
      this.Pixels[index + 1] = color.G;
      this.Pixels[index + 2] = color.R;
      this.Pixels[index + 3] = color.A;
    }
    if (this.Depth == 24)
    {
      this.Pixels[index] = color.B;
      this.Pixels[index + 1] = color.G;
      this.Pixels[index + 2] = color.R;
    }
    if (this.Depth != 8)
      return;
    this.Pixels[index] = color.B;
  }
}
