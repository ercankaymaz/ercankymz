// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.PacketTag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public enum PacketTag
{
  Reserved = 0,
  PublicKeyEncryptedSession = 1,
  Signature = 2,
  SymmetricKeyEncryptedSessionKey = 3,
  OnePassSignature = 4,
  SecretKey = 5,
  PublicKey = 6,
  SecretSubkey = 7,
  CompressedData = 8,
  SymmetricKeyEncrypted = 9,
  Marker = 10, // 0x0000000A
  LiteralData = 11, // 0x0000000B
  Trust = 12, // 0x0000000C
  UserId = 13, // 0x0000000D
  PublicSubkey = 14, // 0x0000000E
  UserAttribute = 17, // 0x00000011
  SymmetricEncryptedIntegrityProtected = 18, // 0x00000012
  ModificationDetectionCode = 19, // 0x00000013
  Experimental1 = 60, // 0x0000003C
  Experimental2 = 61, // 0x0000003D
  Experimental3 = 62, // 0x0000003E
  Experimental4 = 63, // 0x0000003F
}
