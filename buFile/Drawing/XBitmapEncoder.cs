// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XBitmapEncoder
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.IO;

#nullable disable
namespace PdfSharp.Drawing;

public abstract class XBitmapEncoder
{
  private XBitmapSource _source;

  internal XBitmapEncoder()
  {
  }

  public static XBitmapEncoder GetPngEncoder() => (XBitmapEncoder) new XPngBitmapEncoder();

  public XBitmapSource Source
  {
    get => this._source;
    set => this._source = value;
  }

  public abstract void Save(Stream stream);
}
