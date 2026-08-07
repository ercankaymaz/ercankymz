// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.IdentifierType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class IdentifierType
{
  public const short pre_agreed = 0;
  public const short key_sha1_hash = 1;
  public const short x509_name = 2;
  public const short cert_sha1_hash = 3;

  public static string GetName(short identifierType)
  {
    switch (identifierType)
    {
      case 0:
        return "pre_agreed";
      case 1:
        return "key_sha1_hash";
      case 2:
        return "x509_name";
      case 3:
        return "cert_sha1_hash";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(short identifierType)
  {
    return $"{IdentifierType.GetName(identifierType)}({identifierType.ToString()})";
  }
}
