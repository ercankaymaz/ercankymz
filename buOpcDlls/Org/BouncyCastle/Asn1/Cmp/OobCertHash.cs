// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.OobCertHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class OobCertHash : Asn1Encodable
{
  private readonly AlgorithmIdentifier m_hashAlg;
  private readonly CertId m_certId;
  private readonly DerBitString m_hashVal;

  public static OobCertHash GetInstance(object obj)
  {
    if (obj == null)
      return (OobCertHash) null;
    return obj is OobCertHash oobCertHash ? oobCertHash : new OobCertHash(Asn1Sequence.GetInstance(obj));
  }

  public static OobCertHash GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return OobCertHash.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private OobCertHash(Asn1Sequence seq)
  {
    int num1 = seq.Count - 1;
    Asn1Sequence asn1Sequence = seq;
    int index1 = num1;
    int num2 = index1 - 1;
    this.m_hashVal = DerBitString.GetInstance((object) asn1Sequence[index1]);
    for (int index2 = num2; index2 >= 0; --index2)
    {
      Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject) seq[index2];
      if (asn1TaggedObject.TagNo == 0)
        this.m_hashAlg = AlgorithmIdentifier.GetInstance(asn1TaggedObject, true);
      else
        this.m_certId = CertId.GetInstance(asn1TaggedObject, true);
    }
  }

  public virtual CertId CertID => this.m_certId;

  public virtual AlgorithmIdentifier HashAlg => this.m_hashAlg;

  public virtual DerBitString HashVal => this.m_hashVal;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_hashAlg);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.m_certId);
    elementVector.Add((Asn1Encodable) this.m_hashVal);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
