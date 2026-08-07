// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.SignaturePolicyId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class SignaturePolicyId : Asn1Encodable
{
  private readonly DerObjectIdentifier m_sigPolicyIdentifier;
  private readonly OtherHashAlgAndValue m_sigPolicyHash;
  private readonly Asn1Sequence m_sigPolicyQualifiers;

  public static SignaturePolicyId GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (SignaturePolicyId) null;
      case SignaturePolicyId instance:
        return instance;
      case Asn1Sequence seq:
        return new SignaturePolicyId(seq);
      default:
        throw new ArgumentException("Unknown object in 'SignaturePolicyId' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private SignaturePolicyId(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.m_sigPolicyIdentifier = seq.Count >= 2 && seq.Count <= 3 ? (DerObjectIdentifier) seq[0].ToAsn1Object() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.m_sigPolicyHash = OtherHashAlgAndValue.GetInstance((object) seq[1].ToAsn1Object());
    if (seq.Count <= 2)
      return;
    this.m_sigPolicyQualifiers = (Asn1Sequence) seq[2].ToAsn1Object();
  }

  public SignaturePolicyId(
    DerObjectIdentifier sigPolicyIdentifier,
    OtherHashAlgAndValue sigPolicyHash)
    : this(sigPolicyIdentifier, sigPolicyHash, (SigPolicyQualifierInfo[]) null)
  {
  }

  public SignaturePolicyId(
    DerObjectIdentifier sigPolicyIdentifier,
    OtherHashAlgAndValue sigPolicyHash,
    params SigPolicyQualifierInfo[] sigPolicyQualifiers)
  {
    if (sigPolicyIdentifier == null)
      throw new ArgumentNullException(nameof (sigPolicyIdentifier));
    if (sigPolicyHash == null)
      throw new ArgumentNullException(nameof (sigPolicyHash));
    this.m_sigPolicyIdentifier = sigPolicyIdentifier;
    this.m_sigPolicyHash = sigPolicyHash;
    if (sigPolicyQualifiers == null)
      return;
    this.m_sigPolicyQualifiers = (Asn1Sequence) new DerSequence((Asn1Encodable[]) sigPolicyQualifiers);
  }

  public SignaturePolicyId(
    DerObjectIdentifier sigPolicyIdentifier,
    OtherHashAlgAndValue sigPolicyHash,
    IEnumerable<SigPolicyQualifierInfo> sigPolicyQualifiers)
  {
    if (sigPolicyIdentifier == null)
      throw new ArgumentNullException(nameof (sigPolicyIdentifier));
    if (sigPolicyHash == null)
      throw new ArgumentNullException(nameof (sigPolicyHash));
    this.m_sigPolicyIdentifier = sigPolicyIdentifier;
    this.m_sigPolicyHash = sigPolicyHash;
    if (sigPolicyQualifiers == null)
      return;
    this.m_sigPolicyQualifiers = (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) sigPolicyQualifiers));
  }

  public DerObjectIdentifier SigPolicyIdentifier => this.m_sigPolicyIdentifier;

  public OtherHashAlgAndValue SigPolicyHash => this.m_sigPolicyHash;

  public SigPolicyQualifierInfo[] GetSigPolicyQualifiers()
  {
    return this.m_sigPolicyQualifiers?.MapElements<SigPolicyQualifierInfo>(new Func<Asn1Encodable, SigPolicyQualifierInfo>(SigPolicyQualifierInfo.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_sigPolicyIdentifier, (Asn1Encodable) this.m_sigPolicyHash.ToAsn1Object());
    if (this.m_sigPolicyQualifiers != null)
      elementVector.Add((Asn1Encodable) this.m_sigPolicyQualifiers.ToAsn1Object());
    return (Asn1Object) new DerSequence(elementVector);
  }
}
