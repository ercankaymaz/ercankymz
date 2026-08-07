// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.PskKeyExchangeMode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class PskKeyExchangeMode
{
  public const short psk_ke = 0;
  public const short psk_dhe_ke = 1;

  public static string GetName(short pskKeyExchangeMode)
  {
    if (pskKeyExchangeMode == (short) 0)
      return "psk_ke";
    return pskKeyExchangeMode != (short) 1 ? "UNKNOWN" : "psk_dhe_ke";
  }

  public static string GetText(short pskKeyExchangeMode)
  {
    return $"{PskKeyExchangeMode.GetName(pskKeyExchangeMode)}({pskKeyExchangeMode.ToString()})";
  }
}
