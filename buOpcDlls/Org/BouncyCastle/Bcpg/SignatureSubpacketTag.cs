// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.SignatureSubpacketTag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public enum SignatureSubpacketTag
{
  CreationTime = 2,
  ExpireTime = 3,
  Exportable = 4,
  TrustSig = 5,
  RegExp = 6,
  Revocable = 7,
  KeyExpireTime = 9,
  Placeholder = 10, // 0x0000000A
  PreferredSymmetricAlgorithms = 11, // 0x0000000B
  RevocationKey = 12, // 0x0000000C
  IssuerKeyId = 16, // 0x00000010
  NotationData = 20, // 0x00000014
  PreferredHashAlgorithms = 21, // 0x00000015
  PreferredCompressionAlgorithms = 22, // 0x00000016
  KeyServerPreferences = 23, // 0x00000017
  PreferredKeyServer = 24, // 0x00000018
  PrimaryUserId = 25, // 0x00000019
  PolicyUrl = 26, // 0x0000001A
  KeyFlags = 27, // 0x0000001B
  SignerUserId = 28, // 0x0000001C
  RevocationReason = 29, // 0x0000001D
  Features = 30, // 0x0000001E
  SignatureTarget = 31, // 0x0000001F
  EmbeddedSignature = 32, // 0x00000020
  IssuerFingerprint = 33, // 0x00000021
  IntendedRecipientFingerprint = 35, // 0x00000023
  AttestedCertifications = 37, // 0x00000025
  KeyBlock = 38, // 0x00000026
  PreferredAeadAlgorithms = 39, // 0x00000027
}
