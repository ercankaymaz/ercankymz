// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.NameType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class NameType
{
  public const short host_name = 0;

  public static string GetName(short nameType) => nameType == (short) 0 ? "host_name" : "UNKNOWN";

  public static string GetText(short nameType)
  {
    return $"{NameType.GetName(nameType)}({nameType.ToString()})";
  }

  public static bool IsRecognized(short nameType) => nameType == (short) 0;

  public static bool IsValid(short nameType) => TlsUtilities.IsValidUint8(nameType);
}
