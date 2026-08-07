// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.MacAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class MacAlgorithm
{
  public const int cls_null = 0;
  public const int md5 = 1;
  public const int sha = 2;
  public const int hmac_md5 = 1;
  public const int hmac_sha1 = 2;
  public const int hmac_sha256 = 3;
  public const int hmac_sha384 = 4;
  public const int hmac_sha512 = 5;

  public static string GetName(int macAlgorithm)
  {
    switch (macAlgorithm)
    {
      case 0:
        return "null";
      case 1:
        return "hmac_md5";
      case 2:
        return "hmac_sha1";
      case 3:
        return "hmac_sha256";
      case 4:
        return "hmac_sha384";
      case 5:
        return "hmac_sha512";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(int macAlgorithm)
  {
    return $"{MacAlgorithm.GetName(macAlgorithm)}({macAlgorithm.ToString()})";
  }

  public static bool IsHmac(int macAlgorithm)
  {
    switch (macAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
        return true;
      default:
        return false;
    }
  }
}
