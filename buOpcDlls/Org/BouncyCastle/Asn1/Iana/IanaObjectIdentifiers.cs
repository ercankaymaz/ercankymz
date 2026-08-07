// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Iana.IanaObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Iana;

public abstract class IanaObjectIdentifiers
{
  public static readonly DerObjectIdentifier IsakmpOakley = new DerObjectIdentifier("1.3.6.1.5.5.8.1");
  public static readonly DerObjectIdentifier HmacMD5 = new DerObjectIdentifier(IanaObjectIdentifiers.IsakmpOakley?.ToString() + ".1");
  public static readonly DerObjectIdentifier HmacSha1 = new DerObjectIdentifier(IanaObjectIdentifiers.IsakmpOakley?.ToString() + ".2");
  public static readonly DerObjectIdentifier HmacTiger = new DerObjectIdentifier(IanaObjectIdentifiers.IsakmpOakley?.ToString() + ".3");
  public static readonly DerObjectIdentifier HmacRipeMD160 = new DerObjectIdentifier(IanaObjectIdentifiers.IsakmpOakley?.ToString() + ".4");
}
