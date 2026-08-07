// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiBody
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.Pkcs;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiBody : Asn1Encodable, IAsn1Choice
{
  public const int TYPE_INIT_REQ = 0;
  public const int TYPE_INIT_REP = 1;
  public const int TYPE_CERT_REQ = 2;
  public const int TYPE_CERT_REP = 3;
  public const int TYPE_P10_CERT_REQ = 4;
  public const int TYPE_POPO_CHALL = 5;
  public const int TYPE_POPO_REP = 6;
  public const int TYPE_KEY_UPDATE_REQ = 7;
  public const int TYPE_KEY_UPDATE_REP = 8;
  public const int TYPE_KEY_RECOVERY_REQ = 9;
  public const int TYPE_KEY_RECOVERY_REP = 10;
  public const int TYPE_REVOCATION_REQ = 11;
  public const int TYPE_REVOCATION_REP = 12;
  public const int TYPE_CROSS_CERT_REQ = 13;
  public const int TYPE_CROSS_CERT_REP = 14;
  public const int TYPE_CA_KEY_UPDATE_ANN = 15;
  public const int TYPE_CERT_ANN = 16 /*0x10*/;
  public const int TYPE_REVOCATION_ANN = 17;
  public const int TYPE_CRL_ANN = 18;
  public const int TYPE_CONFIRM = 19;
  public const int TYPE_NESTED = 20;
  public const int TYPE_GEN_MSG = 21;
  public const int TYPE_GEN_REP = 22;
  public const int TYPE_ERROR = 23;
  public const int TYPE_CERT_CONFIRM = 24;
  public const int TYPE_POLL_REQ = 25;
  public const int TYPE_POLL_REP = 26;
  private readonly int m_tagNo;
  private readonly Asn1Encodable m_body;

  public static PkiBody GetInstance(object obj)
  {
    if (obj == null)
      return (PkiBody) null;
    return obj is PkiBody pkiBody ? pkiBody : new PkiBody(Asn1TaggedObject.GetInstance(obj));
  }

  public static PkiBody GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Asn1Utilities.GetInstanceFromChoice<PkiBody>(taggedObject, declaredExplicit, new Func<object, PkiBody>(PkiBody.GetInstance));
  }

  private PkiBody(Asn1TaggedObject taggedObject)
  {
    this.m_tagNo = taggedObject.TagNo;
    this.m_body = PkiBody.GetBodyForType(this.m_tagNo, (Asn1Encodable) taggedObject.GetObject());
  }

  public PkiBody(int type, Asn1Encodable content)
  {
    this.m_tagNo = type;
    this.m_body = PkiBody.GetBodyForType(type, content);
  }

  private static Asn1Encodable GetBodyForType(int type, Asn1Encodable o)
  {
    switch (type)
    {
      case 0:
        return (Asn1Encodable) CertReqMessages.GetInstance((object) o);
      case 1:
        return (Asn1Encodable) CertRepMessage.GetInstance((object) o);
      case 2:
        return (Asn1Encodable) CertReqMessages.GetInstance((object) o);
      case 3:
        return (Asn1Encodable) CertRepMessage.GetInstance((object) o);
      case 4:
        return (Asn1Encodable) CertificationRequest.GetInstance((object) o);
      case 5:
        return (Asn1Encodable) PopoDecKeyChallContent.GetInstance((object) o);
      case 6:
        return (Asn1Encodable) PopoDecKeyRespContent.GetInstance((object) o);
      case 7:
        return (Asn1Encodable) CertReqMessages.GetInstance((object) o);
      case 8:
        return (Asn1Encodable) CertRepMessage.GetInstance((object) o);
      case 9:
        return (Asn1Encodable) CertReqMessages.GetInstance((object) o);
      case 10:
        return (Asn1Encodable) KeyRecRepContent.GetInstance((object) o);
      case 11:
        return (Asn1Encodable) RevReqContent.GetInstance((object) o);
      case 12:
        return (Asn1Encodable) RevRepContent.GetInstance((object) o);
      case 13:
        return (Asn1Encodable) CertReqMessages.GetInstance((object) o);
      case 14:
        return (Asn1Encodable) CertRepMessage.GetInstance((object) o);
      case 15:
        return (Asn1Encodable) CAKeyUpdAnnContent.GetInstance((object) o);
      case 16 /*0x10*/:
        return (Asn1Encodable) CmpCertificate.GetInstance((object) o);
      case 17:
        return (Asn1Encodable) RevAnnContent.GetInstance((object) o);
      case 18:
        return (Asn1Encodable) CrlAnnContent.GetInstance((object) o);
      case 19:
        return (Asn1Encodable) PkiConfirmContent.GetInstance((object) o);
      case 20:
        return (Asn1Encodable) PkiMessages.GetInstance((object) o);
      case 21:
        return (Asn1Encodable) GenMsgContent.GetInstance((object) o);
      case 22:
        return (Asn1Encodable) GenRepContent.GetInstance((object) o);
      case 23:
        return (Asn1Encodable) ErrorMsgContent.GetInstance((object) o);
      case 24:
        return (Asn1Encodable) CertConfirmContent.GetInstance((object) o);
      case 25:
        return (Asn1Encodable) PollReqContent.GetInstance((object) o);
      case 26:
        return (Asn1Encodable) PollRepContent.GetInstance((object) o);
      default:
        throw new ArgumentException("unknown tag number: " + type.ToString(), nameof (type));
    }
  }

  public virtual Asn1Encodable Content => this.m_body;

  public virtual int Type => this.m_tagNo;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerTaggedObject(true, this.m_tagNo, this.m_body);
  }
}
