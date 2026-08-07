// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HeartbeatMessageType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class HeartbeatMessageType
{
  public const short heartbeat_request = 1;
  public const short heartbeat_response = 2;

  public static string GetName(short heartbeatMessageType)
  {
    if (heartbeatMessageType == (short) 1)
      return "heartbeat_request";
    return heartbeatMessageType != (short) 2 ? "UNKNOWN" : "heartbeat_response";
  }

  public static string GetText(short heartbeatMessageType)
  {
    return $"{HeartbeatMessageType.GetName(heartbeatMessageType)}({heartbeatMessageType.ToString()})";
  }

  public static bool IsValid(short heartbeatMessageType)
  {
    return heartbeatMessageType >= (short) 1 && heartbeatMessageType <= (short) 2;
  }
}
