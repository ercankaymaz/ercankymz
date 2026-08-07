// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.ProtectedPart
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class ProtectedPart : Asn1Encodable
{
  private readonly PkiHeader m_header;
  private readonly PkiBody m_body;

  public static ProtectedPart GetInstance(object obj)
  {
    if (obj == null)
      return (ProtectedPart) null;
    return obj is ProtectedPart protectedPart ? protectedPart : new ProtectedPart(Asn1Sequence.GetInstance(obj));
  }

  public static ProtectedPart GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return ProtectedPart.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private ProtectedPart(Asn1Sequence seq)
  {
    this.m_header = PkiHeader.GetInstance((object) seq[0]);
    this.m_body = PkiBody.GetInstance((object) seq[1]);
  }

  public ProtectedPart(PkiHeader header, PkiBody body)
  {
    this.m_header = header;
    this.m_body = body;
  }

  public virtual PkiHeader Header => this.m_header;

  public virtual PkiBody Body => this.m_body;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.m_header, (Asn1Encodable) this.m_body);
  }
}
