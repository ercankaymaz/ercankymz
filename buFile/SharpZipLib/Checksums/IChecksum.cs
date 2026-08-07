// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Checksums.IChecksum
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.SharpZipLib.Checksums;

internal interface IChecksum
{
  long Value { get; }

  void Reset();

  void Update(int value);

  void Update(byte[] buffer);

  void Update(byte[] buffer, int offset, int count);
}
