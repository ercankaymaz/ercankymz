// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.ImageInformation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing;

internal class ImageInformation
{
  internal ImageInformation.ImageFormats ImageFormat;
  internal uint Width;
  internal uint Height;
  internal Decimal HorizontalDPI;
  internal Decimal VerticalDPI;
  internal Decimal HorizontalDPM;
  internal Decimal VerticalDPM;
  internal Decimal HorizontalAspectRatio;
  internal Decimal VerticalAspectRatio;
  internal uint ColorsUsed;

  internal enum ImageFormats
  {
    JPEG,
    JPEGGRAY,
    JPEGRGBW,
    JPEGCMYK,
    Palette1,
    Palette4,
    Palette8,
    RGB24,
    ARGB32,
  }
}
