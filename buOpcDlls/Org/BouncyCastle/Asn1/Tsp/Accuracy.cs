// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Tsp.Accuracy
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Tsp;

public class Accuracy : Asn1Encodable
{
  private readonly DerInteger seconds;
  private readonly DerInteger millis;
  private readonly DerInteger micros;
  protected const int MinMillis = 1;
  protected const int MaxMillis = 999;
  protected const int MinMicros = 1;
  protected const int MaxMicros = 999;

  public Accuracy(DerInteger seconds, DerInteger millis, DerInteger micros)
  {
    if (millis != null)
    {
      int intValueExact = millis.IntValueExact;
      if (intValueExact < 1 || intValueExact > 999)
        throw new ArgumentException("Invalid millis field : not in (1..999)");
    }
    if (micros != null)
    {
      int intValueExact = micros.IntValueExact;
      if (intValueExact < 1 || intValueExact > 999)
        throw new ArgumentException("Invalid micros field : not in (1..999)");
    }
    this.seconds = seconds;
    this.millis = millis;
    this.micros = micros;
  }

  private Accuracy(Asn1Sequence seq)
  {
    for (int index = 0; index < seq.Count; ++index)
    {
      if (seq[index] is DerInteger derInteger)
        this.seconds = derInteger;
      else if (seq[index] is Asn1TaggedObject taggedObject)
      {
        switch (taggedObject.TagNo)
        {
          case 0:
            this.millis = DerInteger.GetInstance(taggedObject, false);
            int intValueExact1 = this.millis.IntValueExact;
            if (intValueExact1 < 1 || intValueExact1 > 999)
              throw new ArgumentException("Invalid millis field : not in (1..999)");
            continue;
          case 1:
            this.micros = DerInteger.GetInstance(taggedObject, false);
            int intValueExact2 = this.micros.IntValueExact;
            if (intValueExact2 < 1 || intValueExact2 > 999)
              throw new ArgumentException("Invalid micros field : not in (1..999)");
            continue;
          default:
            throw new ArgumentException("Invalid tag number");
        }
      }
    }
  }

  public static Accuracy GetInstance(object obj)
  {
    if (obj is Accuracy)
      return (Accuracy) obj;
    return obj == null ? (Accuracy) null : new Accuracy(Asn1Sequence.GetInstance(obj));
  }

  public DerInteger Seconds => this.seconds;

  public DerInteger Millis => this.millis;

  public DerInteger Micros => this.micros;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptional((Asn1Encodable) this.seconds);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.millis);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.micros);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
