// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.AlertLevel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class AlertLevel
{
  public const short warning = 1;
  public const short fatal = 2;

  public static string GetName(short alertDescription)
  {
    if (alertDescription == (short) 1)
      return "warning";
    return alertDescription != (short) 2 ? "UNKNOWN" : "fatal";
  }

  public static string GetText(short alertDescription)
  {
    return $"{AlertLevel.GetName(alertDescription)}({alertDescription.ToString()})";
  }
}
