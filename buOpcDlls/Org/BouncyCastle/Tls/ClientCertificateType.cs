// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ClientCertificateType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class ClientCertificateType
{
  public const short rsa_sign = 1;
  public const short dss_sign = 2;
  public const short rsa_fixed_dh = 3;
  public const short dss_fixed_dh = 4;
  public const short rsa_ephemeral_dh_RESERVED = 5;
  public const short dss_ephemeral_dh_RESERVED = 6;
  public const short fortezza_dms_RESERVED = 20;
  public const short ecdsa_sign = 64 /*0x40*/;
  public const short rsa_fixed_ecdh = 65;
  public const short ecdsa_fixed_ecdh = 66;
  public const short gost_sign256 = 67;
  public const short gost_sign512 = 68;

  public static string GetName(short clientCertificateType)
  {
    switch (clientCertificateType)
    {
      case 1:
        return "rsa_sign";
      case 2:
        return "dss_sign";
      case 3:
        return "rsa_fixed_dh";
      case 4:
        return "dss_fixed_dh";
      case 5:
        return "rsa_ephemeral_dh_RESERVED";
      case 6:
        return "dss_ephemeral_dh_RESERVED";
      case 20:
        return "fortezza_dms_RESERVED";
      case 64 /*0x40*/:
        return "ecdsa_sign";
      case 65:
        return "rsa_fixed_ecdh";
      case 66:
        return "ecdsa_fixed_ecdh";
      case 67:
        return "gost_sign256";
      case 68:
        return "gost_sign512";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(short clientCertificateType)
  {
    return $"{ClientCertificateType.GetName(clientCertificateType)}({clientCertificateType.ToString()})";
  }
}
