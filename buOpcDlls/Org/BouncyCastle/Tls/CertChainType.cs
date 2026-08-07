// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertChainType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class CertChainType
{
  public const short individual_certs = 0;
  public const short pkipath = 1;

  public static string GetName(short certChainType)
  {
    if (certChainType == (short) 0)
      return "individual_certs";
    return certChainType != (short) 1 ? "UNKNOWN" : "pkipath";
  }

  public static string GetText(short certChainType)
  {
    return $"{CertChainType.GetName(certChainType)}({certChainType.ToString()})";
  }

  public static bool IsValid(short certChainType)
  {
    return certChainType >= (short) 0 && certChainType <= (short) 1;
  }
}
