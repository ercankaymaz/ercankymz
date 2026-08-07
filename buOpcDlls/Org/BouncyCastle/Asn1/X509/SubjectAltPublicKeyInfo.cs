// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.SubjectAltPublicKeyInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class SubjectAltPublicKeyInfo : Asn1Encodable
{
  private readonly AlgorithmIdentifier m_algorithm;
  private readonly DerBitString m_subjectAltPublicKey;

  public static SubjectAltPublicKeyInfo GetInstance(object obj)
  {
    if (obj == null)
      return (SubjectAltPublicKeyInfo) null;
    return obj is SubjectAltPublicKeyInfo altPublicKeyInfo ? altPublicKeyInfo : new SubjectAltPublicKeyInfo(Asn1Sequence.GetInstance(obj));
  }

  public static SubjectAltPublicKeyInfo GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return SubjectAltPublicKeyInfo.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public static SubjectAltPublicKeyInfo FromExtensions(X509Extensions extensions)
  {
    return SubjectAltPublicKeyInfo.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.SubjectAltPublicKeyInfo));
  }

  private SubjectAltPublicKeyInfo(Asn1Sequence seq)
  {
    this.m_algorithm = seq.Count == 2 ? AlgorithmIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("extension should contain only 2 elements");
    this.m_subjectAltPublicKey = DerBitString.GetInstance((object) seq[1]);
  }

  public SubjectAltPublicKeyInfo(AlgorithmIdentifier algorithm, DerBitString subjectAltPublicKey)
  {
    this.m_algorithm = algorithm;
    this.m_subjectAltPublicKey = subjectAltPublicKey;
  }

  public SubjectAltPublicKeyInfo(SubjectPublicKeyInfo subjectPublicKeyInfo)
  {
    this.m_algorithm = subjectPublicKeyInfo.AlgorithmID;
    this.m_subjectAltPublicKey = subjectPublicKeyInfo.PublicKeyData;
  }

  public AlgorithmIdentifier Algorithm => this.Algorithm;

  public DerBitString SubjectAltPublicKey => this.m_subjectAltPublicKey;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.m_algorithm, (Asn1Encodable) this.m_subjectAltPublicKey);
  }
}
