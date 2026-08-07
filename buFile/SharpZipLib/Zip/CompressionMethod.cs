// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.CompressionMethod
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.SharpZipLib.Zip;

public enum CompressionMethod
{
  Stored = 0,
  Deflated = 8,
  Deflate64 = 9,
  BZip2 = 11, // 0x0000000B
  WinZipAES = 99, // 0x00000063
}
