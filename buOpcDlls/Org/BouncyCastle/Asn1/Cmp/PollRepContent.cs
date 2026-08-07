// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PollRepContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PollRepContent : Asn1Encodable
{
  private readonly DerInteger[] m_certReqID;
  private readonly DerInteger[] m_checkAfter;
  private readonly PkiFreeText[] m_reason;

  public static PollRepContent GetInstance(object obj)
  {
    if (obj == null)
      return (PollRepContent) null;
    return obj is PollRepContent pollRepContent ? pollRepContent : new PollRepContent(Asn1Sequence.GetInstance(obj));
  }

  public static PollRepContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PollRepContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private PollRepContent(Asn1Sequence seq)
  {
    int count = seq.Count;
    this.m_certReqID = new DerInteger[count];
    this.m_checkAfter = new DerInteger[count];
    this.m_reason = new PkiFreeText[count];
    for (int index = 0; index != count; ++index)
    {
      Asn1Sequence instance = Asn1Sequence.GetInstance((object) seq[index]);
      this.m_certReqID[index] = DerInteger.GetInstance((object) instance[0]);
      this.m_checkAfter[index] = DerInteger.GetInstance((object) instance[1]);
      if (instance.Count > 2)
        this.m_reason[index] = PkiFreeText.GetInstance((object) instance[2]);
    }
  }

  public PollRepContent(DerInteger certReqID, DerInteger checkAfter)
    : this(certReqID, checkAfter, (PkiFreeText) null)
  {
  }

  public PollRepContent(DerInteger certReqID, DerInteger checkAfter, PkiFreeText reason)
  {
    this.m_certReqID = new DerInteger[1]{ certReqID };
    this.m_checkAfter = new DerInteger[1]{ checkAfter };
    this.m_reason = new PkiFreeText[1]{ reason };
  }

  public virtual int Count => this.m_certReqID.Length;

  public virtual DerInteger GetCertReqID(int index) => this.m_certReqID[index];

  public virtual DerInteger GetCheckAfter(int index) => this.m_checkAfter[index];

  public virtual PkiFreeText GetReason(int index) => this.m_reason[index];

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector1 = new Asn1EncodableVector(this.m_certReqID.Length);
    for (int index = 0; index != this.m_certReqID.Length; ++index)
    {
      Asn1EncodableVector elementVector2 = new Asn1EncodableVector(3);
      elementVector2.Add((Asn1Encodable) this.m_certReqID[index]);
      elementVector2.Add((Asn1Encodable) this.m_checkAfter[index]);
      elementVector2.AddOptional((Asn1Encodable) this.m_reason[index]);
      elementVector1.Add((Asn1Encodable) new DerSequence(elementVector2));
    }
    return (Asn1Object) new DerSequence(elementVector1);
  }
}
