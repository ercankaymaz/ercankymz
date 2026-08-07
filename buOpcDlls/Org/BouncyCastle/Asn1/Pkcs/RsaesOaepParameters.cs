// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.RsaesOaepParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class RsaesOaepParameters : Asn1Encodable
{
  private AlgorithmIdentifier hashAlgorithm;
  private AlgorithmIdentifier maskGenAlgorithm;
  private AlgorithmIdentifier pSourceAlgorithm;
  public static readonly AlgorithmIdentifier DefaultHashAlgorithm = new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, (Asn1Encodable) DerNull.Instance);
  public static readonly AlgorithmIdentifier DefaultMaskGenFunction = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) RsaesOaepParameters.DefaultHashAlgorithm);
  public static readonly AlgorithmIdentifier DefaultPSourceAlgorithm = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdPSpecified, (Asn1Encodable) new DerOctetString(new byte[0]));

  public static RsaesOaepParameters GetInstance(object obj)
  {
    switch (obj)
    {
      case RsaesOaepParameters _:
        return (RsaesOaepParameters) obj;
      case Asn1Sequence _:
        return new RsaesOaepParameters((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public RsaesOaepParameters()
    : this(RsaesOaepParameters.DefaultHashAlgorithm, RsaesOaepParameters.DefaultMaskGenFunction, RsaesOaepParameters.DefaultPSourceAlgorithm)
  {
  }

  public RsaesOaepParameters(
    AlgorithmIdentifier hashAlgorithm,
    AlgorithmIdentifier maskGenAlgorithm)
    : this(hashAlgorithm, maskGenAlgorithm, RsaesOaepParameters.DefaultPSourceAlgorithm)
  {
  }

  public RsaesOaepParameters(
    AlgorithmIdentifier hashAlgorithm,
    AlgorithmIdentifier maskGenAlgorithm,
    AlgorithmIdentifier pSourceAlgorithm)
  {
    this.hashAlgorithm = hashAlgorithm;
    this.maskGenAlgorithm = maskGenAlgorithm;
    this.pSourceAlgorithm = pSourceAlgorithm;
  }

  public RsaesOaepParameters(Asn1Sequence seq)
  {
    this.hashAlgorithm = RsaesOaepParameters.DefaultHashAlgorithm;
    this.maskGenAlgorithm = RsaesOaepParameters.DefaultMaskGenFunction;
    this.pSourceAlgorithm = RsaesOaepParameters.DefaultPSourceAlgorithm;
    for (int index = 0; index != seq.Count; ++index)
    {
      Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject) seq[index];
      switch (asn1TaggedObject.TagNo)
      {
        case 0:
          this.hashAlgorithm = AlgorithmIdentifier.GetInstance(asn1TaggedObject, true);
          break;
        case 1:
          this.maskGenAlgorithm = AlgorithmIdentifier.GetInstance(asn1TaggedObject, true);
          break;
        case 2:
          this.pSourceAlgorithm = AlgorithmIdentifier.GetInstance(asn1TaggedObject, true);
          break;
        default:
          throw new ArgumentException("unknown tag");
      }
    }
  }

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public AlgorithmIdentifier MaskGenAlgorithm => this.maskGenAlgorithm;

  public AlgorithmIdentifier PSourceAlgorithm => this.pSourceAlgorithm;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    if (!this.hashAlgorithm.Equals((object) RsaesOaepParameters.DefaultHashAlgorithm))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) this.hashAlgorithm));
    if (!this.maskGenAlgorithm.Equals((object) RsaesOaepParameters.DefaultMaskGenFunction))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 1, (Asn1Encodable) this.maskGenAlgorithm));
    if (!this.pSourceAlgorithm.Equals((object) RsaesOaepParameters.DefaultPSourceAlgorithm))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 2, (Asn1Encodable) this.pSourceAlgorithm));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
