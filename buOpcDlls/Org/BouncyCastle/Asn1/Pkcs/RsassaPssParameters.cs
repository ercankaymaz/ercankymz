// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class RsassaPssParameters : Asn1Encodable
{
  private AlgorithmIdentifier hashAlgorithm;
  private AlgorithmIdentifier maskGenAlgorithm;
  private DerInteger saltLength;
  private DerInteger trailerField;
  public static readonly AlgorithmIdentifier DefaultHashAlgorithm = new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, (Asn1Encodable) DerNull.Instance);
  public static readonly AlgorithmIdentifier DefaultMaskGenFunction = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) RsassaPssParameters.DefaultHashAlgorithm);
  public static readonly DerInteger DefaultSaltLength = new DerInteger(20);
  public static readonly DerInteger DefaultTrailerField = new DerInteger(1);

  public static RsassaPssParameters GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case RsassaPssParameters _:
        return (RsassaPssParameters) obj;
      case Asn1Sequence _:
        return new RsassaPssParameters((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public RsassaPssParameters()
  {
    this.hashAlgorithm = RsassaPssParameters.DefaultHashAlgorithm;
    this.maskGenAlgorithm = RsassaPssParameters.DefaultMaskGenFunction;
    this.saltLength = RsassaPssParameters.DefaultSaltLength;
    this.trailerField = RsassaPssParameters.DefaultTrailerField;
  }

  public RsassaPssParameters(
    AlgorithmIdentifier hashAlgorithm,
    AlgorithmIdentifier maskGenAlgorithm,
    DerInteger saltLength,
    DerInteger trailerField)
  {
    this.hashAlgorithm = hashAlgorithm;
    this.maskGenAlgorithm = maskGenAlgorithm;
    this.saltLength = saltLength;
    this.trailerField = trailerField;
  }

  public RsassaPssParameters(Asn1Sequence seq)
  {
    this.hashAlgorithm = RsassaPssParameters.DefaultHashAlgorithm;
    this.maskGenAlgorithm = RsassaPssParameters.DefaultMaskGenFunction;
    this.saltLength = RsassaPssParameters.DefaultSaltLength;
    this.trailerField = RsassaPssParameters.DefaultTrailerField;
    for (int index = 0; index != seq.Count; ++index)
    {
      Asn1TaggedObject taggedObject = (Asn1TaggedObject) seq[index];
      switch (taggedObject.TagNo)
      {
        case 0:
          this.hashAlgorithm = AlgorithmIdentifier.GetInstance(taggedObject, true);
          break;
        case 1:
          this.maskGenAlgorithm = AlgorithmIdentifier.GetInstance(taggedObject, true);
          break;
        case 2:
          this.saltLength = DerInteger.GetInstance(taggedObject, true);
          break;
        case 3:
          this.trailerField = DerInteger.GetInstance(taggedObject, true);
          break;
        default:
          throw new ArgumentException("unknown tag");
      }
    }
  }

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public AlgorithmIdentifier MaskGenAlgorithm => this.maskGenAlgorithm;

  public DerInteger SaltLength => this.saltLength;

  public DerInteger TrailerField => this.trailerField;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(4);
    if (!this.hashAlgorithm.Equals((object) RsassaPssParameters.DefaultHashAlgorithm))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) this.hashAlgorithm));
    if (!this.maskGenAlgorithm.Equals((object) RsassaPssParameters.DefaultMaskGenFunction))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 1, (Asn1Encodable) this.maskGenAlgorithm));
    if (!this.saltLength.Equals((Asn1Object) RsassaPssParameters.DefaultSaltLength))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 2, (Asn1Encodable) this.saltLength));
    if (!this.trailerField.Equals((Asn1Object) RsassaPssParameters.DefaultTrailerField))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 3, (Asn1Encodable) this.trailerField));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
