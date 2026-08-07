// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.Challenge
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class Challenge : Asn1Encodable
{
  private readonly AlgorithmIdentifier m_owf;
  private readonly Asn1OctetString m_witness;
  private readonly Asn1OctetString m_challenge;

  public static Challenge GetInstance(object obj)
  {
    if (obj == null)
      return (Challenge) null;
    return obj is Challenge challenge ? challenge : new Challenge(Asn1Sequence.GetInstance(obj));
  }

  public static Challenge GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Challenge.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private Challenge(Asn1Sequence seq)
  {
    int num = 0;
    if (seq.Count == 3)
      this.m_owf = AlgorithmIdentifier.GetInstance((object) seq[num++]);
    Asn1Sequence asn1Sequence = seq;
    int index1 = num;
    int index2 = index1 + 1;
    this.m_witness = Asn1OctetString.GetInstance((object) asn1Sequence[index1]);
    this.m_challenge = Asn1OctetString.GetInstance((object) seq[index2]);
  }

  public Challenge(byte[] witness, byte[] challenge)
    : this((AlgorithmIdentifier) null, witness, challenge)
  {
  }

  public Challenge(AlgorithmIdentifier owf, byte[] witness, byte[] challenge)
  {
    this.m_owf = owf;
    this.m_witness = (Asn1OctetString) new DerOctetString(witness);
    this.m_challenge = (Asn1OctetString) new DerOctetString(challenge);
  }

  public virtual AlgorithmIdentifier Owf => this.m_owf;

  public virtual Asn1OctetString Witness => this.m_witness;

  public virtual Asn1OctetString ChallengeValue => this.m_challenge;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptional((Asn1Encodable) this.m_owf);
    elementVector.Add((Asn1Encodable) this.m_witness, (Asn1Encodable) this.m_challenge);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public class Rand : Asn1Encodable
  {
    private readonly DerInteger m_intVal;
    private readonly GeneralName m_sender;

    public static Challenge.Rand GetInstance(object obj)
    {
      if (obj == null)
        return (Challenge.Rand) null;
      return obj is Challenge.Rand rand ? rand : new Challenge.Rand(Asn1Sequence.GetInstance(obj));
    }

    public static Challenge.Rand GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
    {
      return Challenge.Rand.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
    }

    public Rand(DerInteger intVal, GeneralName sender)
    {
      this.m_intVal = intVal;
      this.m_sender = sender;
    }

    public Rand(Asn1Sequence seq)
    {
      this.m_intVal = seq.Count == 2 ? DerInteger.GetInstance((object) seq[0]) : throw new ArgumentException("expected sequence size of 2", nameof (seq));
      this.m_sender = GeneralName.GetInstance((object) seq[1]);
    }

    public virtual DerInteger IntVal => this.m_intVal;

    public virtual GeneralName Sender => this.m_sender;

    public override Asn1Object ToAsn1Object()
    {
      return (Asn1Object) new DerSequence((Asn1Encodable) this.m_intVal, (Asn1Encodable) this.m_sender);
    }
  }
}
