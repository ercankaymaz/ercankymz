// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiConfirmContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiConfirmContent : Asn1Encodable
{
  private readonly Asn1Null m_val;

  public static PkiConfirmContent GetInstance(object obj)
  {
    if (obj == null)
      return (PkiConfirmContent) null;
    return obj is PkiConfirmContent pkiConfirmContent ? pkiConfirmContent : new PkiConfirmContent(Asn1Null.GetInstance(obj));
  }

  public static PkiConfirmContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PkiConfirmContent.GetInstance((object) Asn1Null.GetInstance(taggedObject, declaredExplicit));
  }

  public PkiConfirmContent()
    : this((Asn1Null) DerNull.Instance)
  {
  }

  private PkiConfirmContent(Asn1Null val) => this.m_val = val;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_val;
}
