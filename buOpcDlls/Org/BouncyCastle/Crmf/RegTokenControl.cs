// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.RegTokenControl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Crmf;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class RegTokenControl : IControl
{
  private static readonly DerObjectIdentifier type = CrmfObjectIdentifiers.id_regCtrl_regToken;
  private readonly DerUtf8String token;

  public RegTokenControl(DerUtf8String token) => this.token = token;

  public RegTokenControl(string token) => this.token = new DerUtf8String(token);

  public DerObjectIdentifier Type => RegTokenControl.type;

  public Asn1Encodable Value => (Asn1Encodable) this.token;
}
