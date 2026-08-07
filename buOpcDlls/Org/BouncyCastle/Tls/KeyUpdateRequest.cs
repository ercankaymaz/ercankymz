// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.KeyUpdateRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class KeyUpdateRequest
{
  public const short update_not_requested = 0;
  public const short update_requested = 1;

  public static string GetName(short keyUpdateRequest)
  {
    if (keyUpdateRequest == (short) 0)
      return "update_not_requested";
    return keyUpdateRequest != (short) 1 ? "UNKNOWN" : "update_requested";
  }

  public static string GetText(short keyUpdateRequest)
  {
    return $"{KeyUpdateRequest.GetName(keyUpdateRequest)}({keyUpdateRequest.ToString()})";
  }

  public static bool IsValid(short keyUpdateRequest)
  {
    return keyUpdateRequest >= (short) 0 && keyUpdateRequest <= (short) 1;
  }
}
