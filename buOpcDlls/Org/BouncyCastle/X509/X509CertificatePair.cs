// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509CertificatePair
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security.Certificates;
using System;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509CertificatePair
{
  private readonly X509Certificate m_forward;
  private readonly X509Certificate m_reverse;

  public X509CertificatePair(X509Certificate forward, X509Certificate reverse)
  {
    this.m_forward = forward != null || reverse != null ? forward : throw new ArgumentException("At least one of the pair shall be present");
    this.m_reverse = reverse;
  }

  public X509CertificatePair(CertificatePair pair)
  {
    X509CertificateStructure forward = pair.Forward;
    X509CertificateStructure reverse = pair.Reverse;
    this.m_forward = forward == null ? (X509Certificate) null : new X509Certificate(forward);
    this.m_reverse = reverse == null ? (X509Certificate) null : new X509Certificate(reverse);
  }

  public CertificatePair GetCertificatePair()
  {
    return new CertificatePair(this.m_forward?.CertificateStructure, this.m_reverse?.CertificateStructure);
  }

  public byte[] GetEncoded()
  {
    try
    {
      return this.GetCertificatePair().GetEncoded("DER");
    }
    catch (Exception ex)
    {
      throw new CertificateEncodingException(ex.Message, ex);
    }
  }

  public X509Certificate Forward => this.m_forward;

  public X509Certificate Reverse => this.m_reverse;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is X509CertificatePair x509CertificatePair && object.Equals((object) this.m_forward, (object) x509CertificatePair.m_forward) && object.Equals((object) this.m_reverse, (object) x509CertificatePair.m_reverse);
  }

  public override int GetHashCode()
  {
    int hashCode = -1;
    if (this.m_forward != null)
      hashCode ^= this.m_forward.GetHashCode();
    if (this.m_reverse != null)
      hashCode = hashCode * 17 ^ this.m_reverse.GetHashCode();
    return hashCode;
  }
}
