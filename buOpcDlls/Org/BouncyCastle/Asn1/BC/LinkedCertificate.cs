// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BC.LinkedCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.BC;

public class LinkedCertificate : Asn1Encodable
{
  private readonly DigestInfo mDigest;
  private readonly GeneralName mCertLocation;
  private X509Name mCertIssuer;
  private GeneralNames mCACerts;

  public LinkedCertificate(DigestInfo digest, GeneralName certLocation)
    : this(digest, certLocation, (X509Name) null, (GeneralNames) null)
  {
  }

  public LinkedCertificate(
    DigestInfo digest,
    GeneralName certLocation,
    X509Name certIssuer,
    GeneralNames caCerts)
  {
    this.mDigest = digest;
    this.mCertLocation = certLocation;
    this.mCertIssuer = certIssuer;
    this.mCACerts = caCerts;
  }

  private LinkedCertificate(Asn1Sequence seq)
  {
    this.mDigest = DigestInfo.GetInstance((object) seq[0]);
    this.mCertLocation = GeneralName.GetInstance((object) seq[1]);
    for (int index = 2; index < seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      switch (instance.TagNo)
      {
        case 0:
          this.mCertIssuer = X509Name.GetInstance(instance, false);
          break;
        case 1:
          this.mCACerts = GeneralNames.GetInstance(instance, false);
          break;
        default:
          throw new ArgumentException("unknown tag in tagged field");
      }
    }
  }

  public static LinkedCertificate GetInstance(object obj)
  {
    if (obj is LinkedCertificate)
      return (LinkedCertificate) obj;
    return obj != null ? new LinkedCertificate(Asn1Sequence.GetInstance(obj)) : (LinkedCertificate) null;
  }

  public virtual DigestInfo Digest => this.mDigest;

  public virtual GeneralName CertLocation => this.mCertLocation;

  public virtual X509Name CertIssuer => this.mCertIssuer;

  public virtual GeneralNames CACerts => this.mCACerts;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.mDigest, (Asn1Encodable) this.mCertLocation);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.mCertIssuer);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.mCACerts);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
