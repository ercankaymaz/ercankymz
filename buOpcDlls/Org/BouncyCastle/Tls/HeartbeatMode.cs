// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HeartbeatMode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class HeartbeatMode
{
  public const short peer_allowed_to_send = 1;
  public const short peer_not_allowed_to_send = 2;

  public static string GetName(short heartbeatMode)
  {
    if (heartbeatMode == (short) 1)
      return "peer_allowed_to_send";
    return heartbeatMode != (short) 2 ? "UNKNOWN" : "peer_not_allowed_to_send";
  }

  public static string GetText(short heartbeatMode)
  {
    return $"{HeartbeatMode.GetName(heartbeatMode)}({heartbeatMode.ToString()})";
  }

  public static bool IsValid(short heartbeatMode)
  {
    return heartbeatMode >= (short) 1 && heartbeatMode <= (short) 2;
  }
}
