// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.EncryptionAlgorithm
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.SharpZipLib.Zip;

public enum EncryptionAlgorithm
{
  None = 0,
  PkzipClassic = 1,
  Des = 26113, // 0x00006601
  RC2 = 26114, // 0x00006602
  TripleDes168 = 26115, // 0x00006603
  TripleDes112 = 26121, // 0x00006609
  Aes128 = 26126, // 0x0000660E
  Aes192 = 26127, // 0x0000660F
  Aes256 = 26128, // 0x00006610
  RC2Corrected = 26370, // 0x00006702
  Blowfish = 26400, // 0x00006720
  Twofish = 26401, // 0x00006721
  RC4 = 26625, // 0x00006801
  Unknown = 65535, // 0x0000FFFF
}
