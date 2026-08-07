// Decompiled with JetBrains decompiler
// Type: PdfSharp.PageSizeConverter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;

#nullable disable
namespace PdfSharp;

public static class PageSizeConverter
{
  public static XSize ToSize(PageSize value)
  {
    XSize size;
    switch (value)
    {
      case PageSize.A0:
        size = new XSize(2384.0, 3370.0);
        break;
      case PageSize.A1:
        size = new XSize(1684.0, 2384.0);
        break;
      case PageSize.A2:
        size = new XSize(1191.0, 1684.0);
        break;
      case PageSize.A3:
        size = new XSize(842.0, 1191.0);
        break;
      case PageSize.A4:
        size = new XSize(595.0, 842.0);
        break;
      case PageSize.A5:
        size = new XSize(420.0, 595.0);
        break;
      case PageSize.RA0:
        size = new XSize(2438.0, 3458.0);
        break;
      case PageSize.RA1:
        size = new XSize(1729.0, 2438.0);
        break;
      case PageSize.RA2:
        size = new XSize(1219.0, 1729.0);
        break;
      case PageSize.RA3:
        size = new XSize(865.0, 1219.0);
        break;
      case PageSize.RA4:
        size = new XSize(609.0, 865.0);
        break;
      case PageSize.RA5:
        size = new XSize(433.0, 609.0);
        break;
      case PageSize.B0:
        size = new XSize(2835.0, 4008.0);
        break;
      case PageSize.B1:
        size = new XSize(2004.0, 2835.0);
        break;
      case PageSize.B2:
        size = new XSize(1417.0, 2004.0);
        break;
      case PageSize.B3:
        size = new XSize(1001.0, 1417.0);
        break;
      case PageSize.B4:
        size = new XSize(709.0, 1001.0);
        break;
      case PageSize.B5:
        size = new XSize(499.0, 709.0);
        break;
      case PageSize.Quarto:
        size = new XSize(576.0, 720.0);
        break;
      case PageSize.Foolscap:
        size = new XSize(576.0, 936.0);
        break;
      case PageSize.Executive:
        size = new XSize(540.0, 720.0);
        break;
      case PageSize.GovernmentLetter:
        size = new XSize(576.0, 756.0);
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
      case PageSize.Post:
        size = new XSize(1126.0, 1386.0);
        break;
      case PageSize.Crown:
        size = new XSize(1440.0, 1080.0);
        break;
      case PageSize.LargePost:
        size = new XSize(1188.0, 1512.0);
        break;
      case PageSize.Demy:
        size = new XSize(1260.0, 1584.0);
        break;
      case PageSize.Medium:
        size = new XSize(1296.0, 1656.0);
        break;
      case PageSize.Royal:
        size = new XSize(1440.0, 1800.0);
        break;
      case PageSize.Elephant:
        size = new XSize(1565.0, 2016.0);
        break;
      case PageSize.DoubleDemy:
        size = new XSize(1692.0, 2520.0);
        break;
      case PageSize.QuadDemy:
        size = new XSize(2520.0, 3240.0);
        break;
      case PageSize.STMT:
        size = new XSize(396.0, 612.0);
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
        throw new ArgumentException("Invalid PageSize.", nameof (value));
    }
    return size;
  }
}
