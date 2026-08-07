// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateCompressionAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class CertificateCompressionAlgorithm
{
  public const int zlib = 1;
  public const int brotli = 2;
  public const int zstd = 3;

  public static string GetName(int certificateCompressionAlgorithm)
  {
    switch (certificateCompressionAlgorithm)
    {
      case 1:
        return "zlib";
      case 2:
        return "brotli";
      case 3:
        return "zstd";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(int certificateCompressionAlgorithm)
  {
    return $"{CertificateCompressionAlgorithm.GetName(certificateCompressionAlgorithm)}({certificateCompressionAlgorithm.ToString()})";
  }

  public static bool IsRecognized(int certificateCompressionAlgorithm)
  {
    switch (certificateCompressionAlgorithm)
    {
      case 1:
      case 2:
      case 3:
        return true;
      default:
        return false;
    }
  }
}
