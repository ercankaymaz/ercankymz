// Decompiled with JetBrains decompiler
// Type: StPictureBox.CImageData
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using Sentech.StApiDotNET;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

#nullable disable
namespace StPictureBox;

public class CImageData : IDisposable
{
  private Bitmap m_Bitmap = (Bitmap) null;
  private CStPixelFormatConverter m_Converter = (CStPixelFormatConverter) null;

  public Bitmap CreateBitmap(IStImage stImage)
  {
    if (this.m_Converter == null)
      this.m_Converter = new CStPixelFormatConverter();
    bool isColor = CStApiDotNet.GetIStPixelFormatInfo(stImage.ImagePixelFormat).IsColor;
    this.m_Converter.DestinationPixelFormat = !isColor ? eStPixelFormatNamingConvention.Mono8 : eStPixelFormatNamingConvention.BGR8;
    if (this.m_Bitmap != null && (this.m_Bitmap.Width != (int) stImage.ImageWidth || this.m_Bitmap.Height != (int) stImage.ImageHeight))
    {
      this.m_Bitmap.Dispose();
      this.m_Bitmap = (Bitmap) null;
    }
    if (this.m_Bitmap == null)
    {
      if (isColor)
      {
        this.m_Bitmap = new Bitmap((int) stImage.ImageWidth, (int) stImage.ImageHeight, PixelFormat.Format24bppRgb);
      }
      else
      {
        this.m_Bitmap = new Bitmap((int) stImage.ImageWidth, (int) stImage.ImageHeight, PixelFormat.Format8bppIndexed);
        ColorPalette palette = this.m_Bitmap.Palette;
        for (int index = 0; index < 256 /*0x0100*/; ++index)
          palette.Entries[index] = Color.FromArgb(index, index, index);
        this.m_Bitmap.Palette = palette;
      }
    }
    using (CStImageBuffer stImageBuffer = CStApiDotNet.CreateStImageBuffer())
    {
      this.m_Converter.Convert(stImage, (IStImageBuffer) stImageBuffer);
      BitmapData bitmapdata = this.m_Bitmap.LockBits(new Rectangle(0, 0, this.m_Bitmap.Width, this.m_Bitmap.Height), ImageLockMode.WriteOnly, this.m_Bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      byte[] byteArray = stImageBuffer.GetIStImage().GetByteArray();
      Marshal.Copy(byteArray, 0, scan0, byteArray.Length);
      this.m_Bitmap.UnlockBits(bitmapdata);
    }
    return this.m_Bitmap;
  }

  public void Dispose()
  {
    if (this.m_Bitmap != null)
    {
      this.m_Bitmap.Dispose();
      this.m_Bitmap = (Bitmap) null;
    }
    if (this.m_Converter == null)
      return;
    this.m_Converter.Dispose();
    this.m_Converter = (CStPixelFormatConverter) null;
  }
}
