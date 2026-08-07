// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ClientAuthenticationType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class ClientAuthenticationType
{
  public const short anonymous = 0;
  public const short certificate_based = 1;
  public const short psk = 2;
}
