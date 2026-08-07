// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SrtpProtectionProfile
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class SrtpProtectionProfile
{
  public const int SRTP_AES128_CM_HMAC_SHA1_80 = 1;
  public const int SRTP_AES128_CM_HMAC_SHA1_32 = 2;
  public const int SRTP_NULL_HMAC_SHA1_80 = 5;
  public const int SRTP_NULL_HMAC_SHA1_32 = 6;
  public const int SRTP_AEAD_AES_128_GCM = 7;
  public const int SRTP_AEAD_AES_256_GCM = 8;
}
