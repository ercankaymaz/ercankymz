// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CrlIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CrlIdentifier : Asn1Encodable
{
  private readonly X509Name m_crlIssuer;
  private readonly Asn1UtcTime m_crlIssuedTime;
  private readonly DerInteger m_crlNumber;

  public static CrlIdentifier GetInstance(object obj)
  {
    if (obj == null)
      return (CrlIdentifier) null;
    return obj is CrlIdentifier crlIdentifier ? crlIdentifier : new CrlIdentifier(Asn1Sequence.GetInstance(obj));
  }

  public static CrlIdentifier GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CrlIdentifier.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CrlIdentifier(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.m_crlIssuer = seq.Count >= 2 && seq.Count <= 3 ? X509Name.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.m_crlIssuedTime = Asn1UtcTime.GetInstance((object) seq[1]);
    this.m_crlIssuedTime.ToDateTime(2049);
    if (seq.Count <= 2)
      return;
    this.m_crlNumber = DerInteger.GetInstance((object) seq[2]);
  }

  public CrlIdentifier(X509Name crlIssuer, DateTime crlIssuedTime)
    : this(crlIssuer, crlIssuedTime, (BigInteger) null)
  {
  }

  public CrlIdentifier(X509Name crlIssuer, DateTime crlIssuedTime, BigInteger crlNumber)
    : this(crlIssuer, new Asn1UtcTime(crlIssuedTime, 2049), crlNumber)
  {
  }

  public CrlIdentifier(X509Name crlIssuer, Asn1UtcTime crlIssuedTime)
    : this(crlIssuer, crlIssuedTime, (BigInteger) null)
  {
  }

  public CrlIdentifier(X509Name crlIssuer, Asn1UtcTime crlIssuedTime, BigInteger crlNumber)
  {
    this.m_crlIssuer = crlIssuer ?? throw new ArgumentNullException(nameof (crlIssuer));
    this.m_crlIssuedTime = crlIssuedTime ?? throw new ArgumentNullException(nameof (crlIssuedTime));
    if (crlNumber != null)
      this.m_crlNumber = new DerInteger(crlNumber);
    this.m_crlIssuedTime.ToDateTime(2049);
  }

  public X509Name CrlIssuer => this.m_crlIssuer;

  public DateTime CrlIssuedTime => this.m_crlIssuedTime.ToDateTime(2049);

  public BigInteger CrlNumber => this.m_crlNumber?.Value;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_crlIssuer.ToAsn1Object(), (Asn1Encodable) this.m_crlIssuedTime);
    elementVector.AddOptional((Asn1Encodable) this.m_crlNumber);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
