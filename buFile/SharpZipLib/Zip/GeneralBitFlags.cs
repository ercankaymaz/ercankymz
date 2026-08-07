// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.GeneralBitFlags
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip;

[Flags]
public enum GeneralBitFlags
{
  Encrypted = 1,
  Method = 6,
  Descriptor = 8,
  ReservedPKware4 = 16, // 0x00000010
  Patched = 32, // 0x00000020
  StrongEncryption = 64, // 0x00000040
  Unused7 = 128, // 0x00000080
  Unused8 = 256, // 0x00000100
  Unused9 = 512, // 0x00000200
  Unused10 = 1024, // 0x00000400
  UnicodeText = 2048, // 0x00000800
  EnhancedCompress = 4096, // 0x00001000
  HeaderMasked = 8192, // 0x00002000
  ReservedPkware14 = 16384, // 0x00004000
  ReservedPkware15 = 32768, // 0x00008000
}
