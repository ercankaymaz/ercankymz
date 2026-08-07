// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XBitmapSource
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;

#nullable disable
namespace PdfSharp.Drawing;

public abstract class XBitmapSource : XImage
{
  public override int PixelWidth
  {
    get
    {
      try
      {
        Lock.EnterGdiPlus();
        return this._gdiImage.Width;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public override int PixelHeight
  {
    get
    {
      try
      {
        Lock.EnterGdiPlus();
        return this._gdiImage.Height;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }
}
