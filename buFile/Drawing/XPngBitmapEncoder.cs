// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XPngBitmapEncoder
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;

#nullable disable
namespace PdfSharp.Drawing;

internal sealed class XPngBitmapEncoder : XBitmapEncoder
{
  internal XPngBitmapEncoder()
  {
  }

  public override void Save(Stream stream)
  {
    if (this.Source == null)
      throw new InvalidOperationException("No image source.");
    if (this.Source.AssociatedGraphics != null)
    {
      this.Source.DisassociateWithGraphics();
      Debug.Assert(this.Source.AssociatedGraphics == null);
    }
    try
    {
      Lock.EnterGdiPlus();
      this.Source._gdiImage.Save(stream, ImageFormat.Png);
    }
    finally
    {
      Lock.ExitGdiPlus();
    }
  }
}
