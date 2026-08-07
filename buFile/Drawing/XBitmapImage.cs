// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XBitmapImage
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System.Drawing;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XBitmapImage : XBitmapSource
{
  internal XBitmapImage(int width, int height)
  {
    try
    {
      Lock.EnterGdiPlus();
      this._gdiImage = (Image) new Bitmap(width, height);
    }
    finally
    {
      Lock.ExitGdiPlus();
    }
    this.Initialize();
  }

  public static XBitmapSource CreateBitmap(int width, int height)
  {
    return (XBitmapSource) new XBitmapImage(width, height);
  }
}
