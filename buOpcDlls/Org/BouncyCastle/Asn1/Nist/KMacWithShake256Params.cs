// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Nist.KMacWithShake256Params
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Nist;

public class KMacWithShake256Params : Asn1Encodable
{
  private static readonly byte[] EMPTY_STRING = new byte[0];
  private static readonly int DEF_LENGTH = 512 /*0x0200*/;
  private readonly int outputLength;
  private readonly byte[] customizationString;

  public KMacWithShake256Params(int outputLength)
  {
    this.outputLength = outputLength;
    this.customizationString = KMacWithShake256Params.EMPTY_STRING;
  }

  public KMacWithShake256Params(int outputLength, byte[] customizationString)
  {
    this.outputLength = outputLength;
    this.customizationString = Arrays.Clone(customizationString);
  }

  public static KMacWithShake256Params GetInstance(object o)
  {
    if (o is KMacWithShake256Params)
      return (KMacWithShake256Params) o;
    return o != null ? new KMacWithShake256Params(Asn1Sequence.GetInstance(o)) : (KMacWithShake256Params) null;
  }

  private KMacWithShake256Params(Asn1Sequence seq)
  {
    if (seq.Count > 2)
      throw new InvalidOperationException("sequence size greater than 2");
    if (seq.Count == 2)
    {
      this.outputLength = DerInteger.GetInstance((object) seq[0]).IntValueExact;
      this.customizationString = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[1]).GetOctets());
    }
    else if (seq.Count == 1)
    {
      if (seq[0] is DerInteger derInteger)
      {
        this.outputLength = derInteger.IntValueExact;
        this.customizationString = KMacWithShake256Params.EMPTY_STRING;
      }
      else
      {
        this.outputLength = KMacWithShake256Params.DEF_LENGTH;
        this.customizationString = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[0]).GetOctets());
      }
    }
    else
    {
      this.outputLength = KMacWithShake256Params.DEF_LENGTH;
      this.customizationString = KMacWithShake256Params.EMPTY_STRING;
    }
  }

  public int OutputLength => this.outputLength;

  public byte[] CustomizationString => Arrays.Clone(this.customizationString);

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    if (this.outputLength != KMacWithShake256Params.DEF_LENGTH)
      elementVector.Add((Asn1Encodable) new DerInteger(this.outputLength));
    if (this.customizationString.Length != 0)
      elementVector.Add((Asn1Encodable) new DerOctetString(this.CustomizationString));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
