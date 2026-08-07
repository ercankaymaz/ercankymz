// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XStringFormat
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing;

public class XStringFormat
{
  private XStringAlignment _alignment;
  private XLineAlignment _lineAlignment;

  public XStringAlignment Alignment
  {
    get => this._alignment;
    set => this._alignment = value;
  }

  public XLineAlignment LineAlignment
  {
    get => this._lineAlignment;
    set => this._lineAlignment = value;
  }

  [Obsolete("Use XStringFormats.Default. (Note plural in class name.)")]
  public static XStringFormat Default => XStringFormats.Default;

  [Obsolete("Use XStringFormats.Default. (Note plural in class name.)")]
  public static XStringFormat TopLeft => XStringFormats.TopLeft;

  [Obsolete("Use XStringFormats.Center. (Note plural in class name.)")]
  public static XStringFormat Center => XStringFormats.Center;

  [Obsolete("Use XStringFormats.TopCenter. (Note plural in class name.)")]
  public static XStringFormat TopCenter => XStringFormats.TopCenter;

  [Obsolete("Use XStringFormats.BottomCenter. (Note plural in class name.)")]
  public static XStringFormat BottomCenter => XStringFormats.BottomCenter;
}
