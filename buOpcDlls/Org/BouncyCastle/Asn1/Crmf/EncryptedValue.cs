// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.EncryptedValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class EncryptedValue : Asn1Encodable
{
  private readonly AlgorithmIdentifier m_intendedAlg;
  private readonly AlgorithmIdentifier m_symmAlg;
  private readonly DerBitString m_encSymmKey;
  private readonly AlgorithmIdentifier m_keyAlg;
  private readonly Asn1OctetString m_valueHint;
  private readonly DerBitString m_encValue;

  public static EncryptedValue GetInstance(object obj)
  {
    if (obj is EncryptedValue instance)
      return instance;
    return obj != null ? new EncryptedValue(Asn1Sequence.GetInstance(obj)) : (EncryptedValue) null;
  }

  private EncryptedValue(Asn1Sequence seq)
  {
    int index;
    for (index = 0; seq[index] is Asn1TaggedObject taggedObject; ++index)
    {
      switch (taggedObject.TagNo)
      {
        case 0:
          this.m_intendedAlg = AlgorithmIdentifier.GetInstance(taggedObject, false);
          break;
        case 1:
          this.m_symmAlg = AlgorithmIdentifier.GetInstance(taggedObject, false);
          break;
        case 2:
          this.m_encSymmKey = DerBitString.GetInstance(taggedObject, false);
          break;
        case 3:
          this.m_keyAlg = AlgorithmIdentifier.GetInstance(taggedObject, false);
          break;
        case 4:
          this.m_valueHint = Asn1OctetString.GetInstance(taggedObject, false);
          break;
      }
    }
    this.m_encValue = DerBitString.GetInstance((object) seq[index]);
  }

  public EncryptedValue(
    AlgorithmIdentifier intendedAlg,
    AlgorithmIdentifier symmAlg,
    DerBitString encSymmKey,
    AlgorithmIdentifier keyAlg,
    Asn1OctetString valueHint,
    DerBitString encValue)
  {
    if (encValue == null)
      throw new ArgumentNullException(nameof (encValue));
    this.m_intendedAlg = intendedAlg;
    this.m_symmAlg = symmAlg;
    this.m_encSymmKey = encSymmKey;
    this.m_keyAlg = keyAlg;
    this.m_valueHint = valueHint;
    this.m_encValue = encValue;
  }

  public virtual AlgorithmIdentifier IntendedAlg => this.m_intendedAlg;

  public virtual AlgorithmIdentifier SymmAlg => this.m_symmAlg;

  public virtual DerBitString EncSymmKey => this.m_encSymmKey;

  public virtual AlgorithmIdentifier KeyAlg => this.m_keyAlg;

  public virtual Asn1OctetString ValueHint => this.m_valueHint;

  public virtual DerBitString EncValue => this.m_encValue;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(6);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.m_intendedAlg);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.m_symmAlg);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.m_encSymmKey);
    elementVector.AddOptionalTagged(false, 3, (Asn1Encodable) this.m_keyAlg);
    elementVector.AddOptionalTagged(false, 4, (Asn1Encodable) this.m_valueHint);
    elementVector.Add((Asn1Encodable) this.m_encValue);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
