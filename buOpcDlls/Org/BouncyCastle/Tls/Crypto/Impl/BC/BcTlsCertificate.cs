// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsCertificate : BcTlsRawKeyCertificate
{
  protected readonly X509CertificateStructure m_certificate;

  public static BcTlsCertificate Convert(BcTlsCrypto crypto, TlsCertificate certificate)
  {
    return certificate is BcTlsCertificate ? (BcTlsCertificate) certificate : new BcTlsCertificate(crypto, certificate.GetEncoded());
  }

  public static X509CertificateStructure ParseCertificate(byte[] encoding)
  {
    try
    {
      return X509CertificateStructure.GetInstance((object) TlsUtilities.ReadAsn1Object(encoding));
    }
    catch (Exception ex)
    {
      throw new TlsFatalAlert((short) 42, ex);
    }
  }

  public BcTlsCertificate(BcTlsCrypto crypto, byte[] encoding)
    : this(crypto, BcTlsCertificate.ParseCertificate(encoding))
  {
  }

  public BcTlsCertificate(BcTlsCrypto crypto, X509CertificateStructure certificate)
    : base(crypto, certificate.SubjectPublicKeyInfo)
  {
    this.m_certificate = certificate;
  }

  public virtual X509CertificateStructure X509CertificateStructure => this.m_certificate;

  public override byte[] GetEncoded() => this.m_certificate.GetEncoded("DER");

  public override byte[] GetExtension(DerObjectIdentifier extensionOid)
  {
    X509Extensions extensions = this.m_certificate.TbsCertificate.Extensions;
    if (extensions != null)
    {
      X509Extension extension = extensions.GetExtension(extensionOid);
      if (extension != null)
        return Arrays.Clone(extension.Value.GetOctets());
    }
    return (byte[]) null;
  }

  public override BigInteger SerialNumber => this.m_certificate.SerialNumber.Value;

  public override string SigAlgOid => this.m_certificate.SignatureAlgorithm.Algorithm.Id;

  public override Asn1Encodable GetSigAlgParams()
  {
    return this.m_certificate.SignatureAlgorithm.Parameters;
  }

  protected override bool SupportsKeyUsage(int keyUsageBits)
  {
    X509Extensions extensions = this.m_certificate.TbsCertificate.Extensions;
    if (extensions != null)
    {
      KeyUsage keyUsage = KeyUsage.FromExtensions(extensions);
      if (keyUsage != null && ((int) keyUsage.GetBytes()[0] & (int) byte.MaxValue & keyUsageBits) != keyUsageBits)
        return false;
    }
    return true;
  }
}
