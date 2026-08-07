// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ContentType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class ContentType
{
  public const short change_cipher_spec = 20;
  public const short alert = 21;
  public const short handshake = 22;
  public const short application_data = 23;
  public const short heartbeat = 24;
  public const short tls12_cid = 25;

  public static string GetName(short contentType)
  {
    switch (contentType)
    {
      case 20:
        return "change_cipher_spec";
      case 21:
        return "alert";
      case 22:
        return "handshake";
      case 23:
        return "application_data";
      case 24:
        return "heartbeat";
      case 25:
        return "tls12_cid";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(short contentType)
  {
    return $"{ContentType.GetName(contentType)}({contentType.ToString()})";
  }
}
