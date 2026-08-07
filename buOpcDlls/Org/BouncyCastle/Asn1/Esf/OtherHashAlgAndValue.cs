// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OtherHashAlgAndValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OtherHashAlgAndValue : Asn1Encodable
{
  private readonly AlgorithmIdentifier hashAlgorithm;
  private readonly Asn1OctetString hashValue;

  public static OtherHashAlgAndValue GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OtherHashAlgAndValue _:
        return (OtherHashAlgAndValue) obj;
      case Asn1Sequence _:
        return new OtherHashAlgAndValue((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'OtherHashAlgAndValue' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OtherHashAlgAndValue(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.hashAlgorithm = seq.Count == 2 ? AlgorithmIdentifier.GetInstance((object) seq[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.hashValue = (Asn1OctetString) seq[1].ToAsn1Object();
  }

  public OtherHashAlgAndValue(AlgorithmIdentifier hashAlgorithm, byte[] hashValue)
  {
    if (hashAlgorithm == null)
      throw new ArgumentNullException(nameof (hashAlgorithm));
    if (hashValue == null)
      throw new ArgumentNullException(nameof (hashValue));
    this.hashAlgorithm = hashAlgorithm;
    this.hashValue = (Asn1OctetString) new DerOctetString(hashValue);
  }

  public OtherHashAlgAndValue(AlgorithmIdentifier hashAlgorithm, Asn1OctetString hashValue)
  {
    if (hashAlgorithm == null)
      throw new ArgumentNullException(nameof (hashAlgorithm));
    if (hashValue == null)
      throw new ArgumentNullException(nameof (hashValue));
    this.hashAlgorithm = hashAlgorithm;
    this.hashValue = hashValue;
  }

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public byte[] GetHashValue() => this.hashValue.GetOctets();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.hashAlgorithm, (Asn1Encodable) this.hashValue);
  }
}
