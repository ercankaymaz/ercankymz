// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.GcmParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class GcmParameters : Asn1Encodable
{
  private const int DefaultIcvLen = 12;
  private readonly byte[] m_nonce;
  private readonly int m_icvLen;

  public static GcmParameters GetInstance(object obj)
  {
    if (obj == null)
      return (GcmParameters) null;
    return obj is GcmParameters gcmParameters ? gcmParameters : new GcmParameters(Asn1Sequence.GetInstance(obj));
  }

  public static GcmParameters GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return GcmParameters.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private GcmParameters(Asn1Sequence seq)
  {
    int count = seq.Count;
    switch (count)
    {
      case 1:
      case 2:
        this.m_nonce = Asn1OctetString.GetInstance((object) seq[0]).GetOctets();
        if (count > 1)
        {
          this.m_icvLen = DerInteger.GetInstance((object) seq[1]).IntValueExact;
          break;
        }
        this.m_icvLen = 12;
        break;
      default:
        throw new ArgumentException("Bad sequence size: " + count.ToString(), nameof (seq));
    }
  }

  public GcmParameters(byte[] nonce, int icvLen)
  {
    this.m_nonce = Arrays.Clone(nonce);
    this.m_icvLen = icvLen;
  }

  public byte[] GetNonce() => Arrays.Clone(this.m_nonce);

  public int IcvLen => this.m_icvLen;

  public override Asn1Object ToAsn1Object()
  {
    DerOctetString derOctetString = new DerOctetString(this.m_nonce);
    return this.m_icvLen != 12 ? (Asn1Object) new DerSequence((Asn1Encodable) derOctetString, (Asn1Encodable) new DerInteger(this.m_icvLen)) : (Asn1Object) new DerSequence((Asn1Encodable) derOctetString);
  }
}
