// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HandshakeType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class HandshakeType
{
  public const short hello_request = 0;
  public const short client_hello = 1;
  public const short server_hello = 2;
  public const short certificate = 11;
  public const short server_key_exchange = 12;
  public const short certificate_request = 13;
  public const short server_hello_done = 14;
  public const short certificate_verify = 15;
  public const short client_key_exchange = 16 /*0x10*/;
  public const short finished = 20;
  public const short certificate_url = 21;
  public const short certificate_status = 22;
  public const short hello_verify_request = 3;
  public const short supplemental_data = 23;
  public const short new_session_ticket = 4;
  public const short end_of_early_data = 5;
  public const short hello_retry_request = 6;
  public const short encrypted_extensions = 8;
  public const short key_update = 24;
  public const short message_hash = 254;
  public const short compressed_certificate = 25;

  public static string GetName(short handshakeType)
  {
    switch (handshakeType)
    {
      case 0:
        return "hello_request";
      case 1:
        return "client_hello";
      case 2:
        return "server_hello";
      case 3:
        return "hello_verify_request";
      case 4:
        return "new_session_ticket";
      case 5:
        return "end_of_early_data";
      case 6:
        return "hello_retry_request";
      case 8:
        return "encrypted_extensions";
      case 11:
        return "certificate";
      case 12:
        return "server_key_exchange";
      case 13:
        return "certificate_request";
      case 14:
        return "server_hello_done";
      case 15:
        return "certificate_verify";
      case 16 /*0x10*/:
        return "client_key_exchange";
      case 20:
        return "finished";
      case 21:
        return "certificate_url";
      case 22:
        return "certificate_status";
      case 23:
        return "supplemental_data";
      case 24:
        return "key_update";
      case 25:
        return "compressed_certificate";
      case 254:
        return "message_hash";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(short handshakeType)
  {
    return $"{HandshakeType.GetName(handshakeType)}({handshakeType.ToString()})";
  }

  public static bool IsRecognized(short handshakeType)
  {
    switch (handshakeType)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 8:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
      case 16 /*0x10*/:
      case 20:
      case 21:
      case 22:
      case 23:
      case 24:
      case 25:
      case 254:
        return true;
      default:
        return false;
    }
  }
}
