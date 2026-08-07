// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.PrfAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class PrfAlgorithm
{
  public const int ssl_prf_legacy = 0;
  public const int tls_prf_legacy = 1;
  public const int tls_prf_sha256 = 2;
  public const int tls_prf_sha384 = 3;
  public const int tls13_hkdf_sha256 = 4;
  public const int tls13_hkdf_sha384 = 5;
  public const int tls13_hkdf_sm3 = 7;

  public static string GetName(int prfAlgorithm)
  {
    switch (prfAlgorithm)
    {
      case 0:
        return "ssl_prf_legacy";
      case 1:
        return "tls_prf_legacy";
      case 2:
        return "tls_prf_sha256";
      case 3:
        return "tls_prf_sha384";
      case 4:
        return "tls13_hkdf_sha256";
      case 5:
        return "tls13_hkdf_sha384";
      case 7:
        return "tls13_hkdf_sm3";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(int prfAlgorithm)
  {
    return $"{PrfAlgorithm.GetName(prfAlgorithm)}({prfAlgorithm.ToString()})";
  }
}
