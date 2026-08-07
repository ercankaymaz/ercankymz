// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XImageFormat
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XImageFormat
{
  private readonly Guid _guid;
  private static readonly XImageFormat _png = new XImageFormat(new Guid("{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}"));
  private static readonly XImageFormat _gif = new XImageFormat(new Guid("{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}"));
  private static readonly XImageFormat _jpeg = new XImageFormat(new Guid("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}"));
  private static readonly XImageFormat _tiff = new XImageFormat(new Guid("{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}"));
  private static readonly XImageFormat _icon = new XImageFormat(new Guid("{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}"));
  private static readonly XImageFormat _pdf = new XImageFormat(new Guid("{84570158-DBF0-4C6B-8368-62D6A3CA76E0}"));

  private XImageFormat(Guid guid) => this._guid = guid;

  internal Guid Guid => this._guid;

  public override bool Equals(object obj)
  {
    return obj is XImageFormat ximageFormat && this._guid == ximageFormat._guid;
  }

  public override int GetHashCode() => this._guid.GetHashCode();

  public static XImageFormat Png => XImageFormat._png;

  public static XImageFormat Gif => XImageFormat._gif;

  public static XImageFormat Jpeg => XImageFormat._jpeg;

  public static XImageFormat Tiff => XImageFormat._tiff;

  public static XImageFormat Pdf => XImageFormat._pdf;

  public static XImageFormat Icon => XImageFormat._icon;
}
