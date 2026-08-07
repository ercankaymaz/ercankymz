// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.RevocationDetailsBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public sealed class RevocationDetailsBuilder
{
  private readonly CertTemplateBuilder m_templateBuilder = new CertTemplateBuilder();

  public RevocationDetailsBuilder SetPublicKey(SubjectPublicKeyInfo publicKey)
  {
    if (publicKey != null)
      this.m_templateBuilder.SetPublicKey(publicKey);
    return this;
  }

  public RevocationDetailsBuilder SetIssuer(X509Name issuer)
  {
    if (issuer != null)
      this.m_templateBuilder.SetIssuer(issuer);
    return this;
  }

  public RevocationDetailsBuilder SetSerialNumber(BigInteger serialNumber)
  {
    if (serialNumber != null)
      this.m_templateBuilder.SetSerialNumber(new DerInteger(serialNumber));
    return this;
  }

  public RevocationDetailsBuilder SetSubject(X509Name subject)
  {
    if (subject != null)
      this.m_templateBuilder.SetSubject(subject);
    return this;
  }

  public RevocationDetails Build()
  {
    return new RevocationDetails(new RevDetails(this.m_templateBuilder.Build()));
  }
}
