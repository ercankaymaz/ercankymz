// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.HashAlgorithmTag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public enum HashAlgorithmTag
{
  MD5 = 1,
  Sha1 = 2,
  RipeMD160 = 3,
  DoubleSha = 4,
  MD2 = 5,
  Tiger192 = 6,
  Haval5pass160 = 7,
  Sha256 = 8,
  Sha384 = 9,
  Sha512 = 10, // 0x0000000A
  Sha224 = 11, // 0x0000000B
  Sha3_256 = 12, // 0x0000000C
  Sha3_512 = 14, // 0x0000000E
  MD4 = 301, // 0x0000012D
  Sha3_224 = 312, // 0x00000138
  Sha3_256_Old = 313, // 0x00000139
  Sha3_384 = 314, // 0x0000013A
  Sha3_512_Old = 315, // 0x0000013B
  SM3 = 326, // 0x00000146
}
