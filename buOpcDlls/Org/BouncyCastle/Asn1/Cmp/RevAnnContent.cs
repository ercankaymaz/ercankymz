// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.RevAnnContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class RevAnnContent : Asn1Encodable
{
  private readonly PkiStatusEncodable m_status;
  private readonly CertId m_certID;
  private readonly Asn1GeneralizedTime m_willBeRevokedAt;
  private readonly Asn1GeneralizedTime m_badSinceDate;
  private readonly X509Extensions m_crlDetails;

  public static RevAnnContent GetInstance(object obj)
  {
    if (obj == null)
      return (RevAnnContent) null;
    return obj is RevAnnContent revAnnContent ? revAnnContent : new RevAnnContent(Asn1Sequence.GetInstance(obj));
  }

  public static RevAnnContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return RevAnnContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public RevAnnContent(
    PkiStatusEncodable status,
    CertId certID,
    Asn1GeneralizedTime willBeRevokedAt,
    Asn1GeneralizedTime badSinceDate)
    : this(status, certID, willBeRevokedAt, badSinceDate, (X509Extensions) null)
  {
  }

  public RevAnnContent(
    PkiStatusEncodable status,
    CertId certID,
    Asn1GeneralizedTime willBeRevokedAt,
    Asn1GeneralizedTime badSinceDate,
    X509Extensions crlDetails)
  {
    this.m_status = status;
    this.m_certID = certID;
    this.m_willBeRevokedAt = willBeRevokedAt;
    this.m_badSinceDate = badSinceDate;
    this.m_crlDetails = crlDetails;
  }

  private RevAnnContent(Asn1Sequence seq)
  {
    this.m_status = PkiStatusEncodable.GetInstance((object) seq[0]);
    this.m_certID = CertId.GetInstance((object) seq[1]);
    this.m_willBeRevokedAt = Asn1GeneralizedTime.GetInstance((object) seq[2]);
    this.m_badSinceDate = Asn1GeneralizedTime.GetInstance((object) seq[3]);
    if (seq.Count <= 4)
      return;
    this.m_crlDetails = X509Extensions.GetInstance((object) seq[4]);
  }

  public virtual PkiStatusEncodable Status => this.m_status;

  public virtual CertId CertID => this.m_certID;

  public virtual Asn1GeneralizedTime WillBeRevokedAt => this.m_willBeRevokedAt;

  public virtual Asn1GeneralizedTime BadSinceDate => this.m_badSinceDate;

  public virtual X509Extensions CrlDetails => this.m_crlDetails;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[4]
    {
      (Asn1Encodable) this.m_status,
      (Asn1Encodable) this.m_certID,
      (Asn1Encodable) this.m_willBeRevokedAt,
      (Asn1Encodable) this.m_badSinceDate
    });
    elementVector.AddOptional((Asn1Encodable) this.m_crlDetails);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
