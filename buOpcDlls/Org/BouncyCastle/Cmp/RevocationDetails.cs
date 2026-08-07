// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.RevocationDetails
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public struct RevocationDetails(RevDetails revDetails)
{
  private readonly RevDetails m_revDetails = revDetails;

  public X509Name Subject => this.m_revDetails.CertDetails.Subject;

  public X509Name Issuer => this.m_revDetails.CertDetails.Issuer;

  public BigInteger SerialNumber => this.m_revDetails.CertDetails.SerialNumber.Value;

  public RevDetails ToASN1Structure() => this.m_revDetails;
}
