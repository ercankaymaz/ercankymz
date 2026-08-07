// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.Calc
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;

#nullable disable
namespace PdfSharp.Internal;

internal static class Calc
{
  public const double Deg2Rad = 0.017453292519943295;

  public static XSize PageSizeToSize(PageSize value)
  {
    XSize size;
    switch (value)
    {
      case PageSize.A0:
        size = new XSize(2380.0, 3368.0);
        break;
      case PageSize.A1:
        size = new XSize(1684.0, 2380.0);
        break;
      case PageSize.A2:
        size = new XSize(1190.0, 1684.0);
        break;
      case PageSize.A3:
        size = new XSize(842.0, 1190.0);
        break;
      case PageSize.A4:
        size = new XSize(595.0, 842.0);
        break;
      case PageSize.A5:
        size = new XSize(420.0, 595.0);
        break;
      case PageSize.B4:
        size = new XSize(729.0, 1032.0);
        break;
      case PageSize.B5:
        size = new XSize(516.0, 729.0);
        break;
      case PageSize.Quarto:
        size = new XSize(610.0, 780.0);
        break;
      case PageSize.Executive:
        size = new XSize(540.0, 720.0);
        break;
      case PageSize.Letter:
        size = new XSize(612.0, 792.0);
        break;
      case PageSize.Legal:
        size = new XSize(612.0, 1008.0);
        break;
      case PageSize.Ledger:
        size = new XSize(1224.0, 792.0);
        break;
      case PageSize.Tabloid:
        size = new XSize(792.0, 1224.0);
        break;
      case PageSize.Folio:
        size = new XSize(612.0, 936.0);
        break;
      case PageSize.Statement:
        size = new XSize(396.0, 612.0);
        break;
      case PageSize.Size10x14:
        size = new XSize(720.0, 1008.0);
        break;
      default:
        throw new ArgumentException("Invalid PageSize.");
    }
    return size;
  }
}
