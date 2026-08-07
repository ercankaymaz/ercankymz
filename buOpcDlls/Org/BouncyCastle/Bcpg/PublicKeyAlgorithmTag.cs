// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.PublicKeyAlgorithmTag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public enum PublicKeyAlgorithmTag
{
  RsaGeneral = 1,
  RsaEncrypt = 2,
  RsaSign = 3,
  ElGamalEncrypt = 16, // 0x00000010
  Dsa = 17, // 0x00000011
  ECDH = 18, // 0x00000012
  ECDsa = 19, // 0x00000013
  ElGamalGeneral = 20, // 0x00000014
  DiffieHellman = 21, // 0x00000015
  EdDsa = 22, // 0x00000016
  EdDsa_Legacy = 22, // 0x00000016
  Experimental_1 = 100, // 0x00000064
  Experimental_2 = 101, // 0x00000065
  Experimental_3 = 102, // 0x00000066
  Experimental_4 = 103, // 0x00000067
  Experimental_5 = 104, // 0x00000068
  Experimental_6 = 105, // 0x00000069
  Experimental_7 = 106, // 0x0000006A
  Experimental_8 = 107, // 0x0000006B
  Experimental_9 = 108, // 0x0000006C
  Experimental_10 = 109, // 0x0000006D
  Experimental_11 = 110, // 0x0000006E
}
