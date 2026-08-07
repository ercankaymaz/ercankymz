// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.OcspRespStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public abstract class OcspRespStatus
{
  public const int Successful = 0;
  public const int MalformedRequest = 1;
  public const int InternalError = 2;
  public const int TryLater = 3;
  public const int SigRequired = 5;
  public const int Unauthorized = 6;
}
