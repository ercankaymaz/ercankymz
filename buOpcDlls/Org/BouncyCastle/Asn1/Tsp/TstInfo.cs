// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Tsp.TstInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Tsp;

public class TstInfo : Asn1Encodable
{
  private readonly DerInteger version;
  private readonly DerObjectIdentifier tsaPolicyId;
  private readonly MessageImprint messageImprint;
  private readonly DerInteger serialNumber;
  private readonly Asn1GeneralizedTime genTime;
  private readonly Accuracy accuracy;
  private readonly DerBoolean ordering;
  private readonly DerInteger nonce;
  private readonly GeneralName tsa;
  private readonly X509Extensions extensions;

  public static TstInfo GetInstance(object obj)
  {
    if (obj is TstInfo)
      return (TstInfo) obj;
    return obj == null ? (TstInfo) null : new TstInfo(Asn1Sequence.GetInstance(obj));
  }

  private TstInfo(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.version = DerInteger.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    this.tsaPolicyId = DerObjectIdentifier.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    this.messageImprint = MessageImprint.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    this.serialNumber = DerInteger.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    this.genTime = Asn1GeneralizedTime.GetInstance((object) enumerator.Current);
    this.ordering = DerBoolean.False;
    while (enumerator.MoveNext())
    {
      Asn1Object current = (Asn1Object) enumerator.Current;
      if (current is Asn1TaggedObject asn1TaggedObject)
      {
        switch (asn1TaggedObject.TagNo)
        {
          case 0:
            this.tsa = GeneralName.GetInstance(asn1TaggedObject, true);
            break;
          case 1:
            this.extensions = X509Extensions.GetInstance(asn1TaggedObject, false);
            break;
          default:
            throw new ArgumentException("Unknown tag value " + asn1TaggedObject.TagNo.ToString());
        }
      }
      if (current is Asn1Sequence)
        this.accuracy = Accuracy.GetInstance((object) current);
      if (current is DerBoolean)
        this.ordering = DerBoolean.GetInstance((object) current);
      if (current is DerInteger)
        this.nonce = DerInteger.GetInstance((object) current);
    }
  }

  public TstInfo(
    DerObjectIdentifier tsaPolicyId,
    MessageImprint messageImprint,
    DerInteger serialNumber,
    Asn1GeneralizedTime genTime,
    Accuracy accuracy,
    DerBoolean ordering,
    DerInteger nonce,
    GeneralName tsa,
    X509Extensions extensions)
  {
    this.version = new DerInteger(1);
    this.tsaPolicyId = tsaPolicyId;
    this.messageImprint = messageImprint;
    this.serialNumber = serialNumber;
    this.genTime = genTime;
    this.accuracy = accuracy;
    this.ordering = ordering;
    this.nonce = nonce;
    this.tsa = tsa;
    this.extensions = extensions;
  }

  public DerInteger Version => this.version;

  public MessageImprint MessageImprint => this.messageImprint;

  public DerObjectIdentifier Policy => this.tsaPolicyId;

  public DerInteger SerialNumber => this.serialNumber;

  public Accuracy Accuracy => this.accuracy;

  public Asn1GeneralizedTime GenTime => this.genTime;

  public DerBoolean Ordering => this.ordering;

  public DerInteger Nonce => this.nonce;

  public GeneralName Tsa => this.tsa;

  public X509Extensions Extensions => this.extensions;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[5]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.tsaPolicyId,
      (Asn1Encodable) this.messageImprint,
      (Asn1Encodable) this.serialNumber,
      (Asn1Encodable) this.genTime
    });
    elementVector.AddOptional((Asn1Encodable) this.accuracy);
    if (this.ordering != null && this.ordering.IsTrue)
      elementVector.Add((Asn1Encodable) this.ordering);
    elementVector.AddOptional((Asn1Encodable) this.nonce);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.tsa);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.extensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
