// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CachedInformationType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class CachedInformationType
{
  public const short cert = 1;
  public const short cert_req = 2;

  public static string GetName(short cachedInformationType)
  {
    if (cachedInformationType == (short) 1)
      return "cert";
    return cachedInformationType != (short) 2 ? "UNKNOWN" : "cert_req";
  }

  public static string GetText(short cachedInformationType)
  {
    return $"{CachedInformationType.GetName(cachedInformationType)}({cachedInformationType.ToString()})";
  }
}
