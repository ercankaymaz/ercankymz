// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.CertificateBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class CertificateBuilder : CertificateBuilderBase
{
  public static ICertificateBuilder Create(X500DistinguishedName subjectName)
  {
    return (ICertificateBuilder) new CertificateBuilder(subjectName);
  }

  public static ICertificateBuilder Create(string subjectName)
  {
    return (ICertificateBuilder) new CertificateBuilder(subjectName);
  }

  private CertificateBuilder(X500DistinguishedName subjectName)
    : base(subjectName)
  {
  }

  private CertificateBuilder(string subjectName)
    : base(subjectName)
  {
  }

  public override X509Certificate2 CreateForRSA()
  {
    this.CreateDefaults();
    if (this.m_rsaPublicKey != null && (this.IssuerCAKeyCert == null || !this.IssuerCAKeyCert.HasPrivateKey))
      throw new NotSupportedException("Cannot use a public key without a issuer certificate with a private key.");
    RSA rsa = (RSA) null;
    RSA key = this.m_rsaPublicKey;
    if (key == null)
    {
      rsa = RSA.Create(this.m_keySize == 0 ? (int) X509Defaults.RSAKeySize : this.m_keySize);
      key = rsa;
    }
    RSASignaturePadding pkcs1 = RSASignaturePadding.Pkcs1;
    CertificateRequest request = new CertificateRequest(this.SubjectName, key, this.HashAlgorithmName, pkcs1);
    this.CreateX509Extensions(request, false);
    byte[] array = ((IEnumerable<byte>) this.m_serialNumber).Reverse<byte>().ToArray<byte>();
    X509Certificate2 certificate;
    if (this.IssuerCAKeyCert != null)
    {
      using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(this.IssuerCAKeyCert))
        certificate = request.Create(this.IssuerCAKeyCert.SubjectName, X509SignatureGenerator.CreateForRSA(rsaPrivateKey, pkcs1), (DateTimeOffset) this.NotBefore, (DateTimeOffset) this.NotAfter, array);
    }
    else
      certificate = request.Create(this.SubjectName, X509SignatureGenerator.CreateForRSA(rsa, pkcs1), (DateTimeOffset) this.NotBefore, (DateTimeOffset) this.NotAfter, array);
    return rsa != null ? certificate.CopyWithPrivateKey(rsa) : certificate;
  }

  public override X509Certificate2 CreateForRSA(X509SignatureGenerator generator)
  {
    this.CreateDefaults();
    if (this.m_rsaPublicKey == null && this.IssuerCAKeyCert == null)
      throw new NotSupportedException("Need an issuer certificate or a public key for a signature generator.");
    X500DistinguishedName subjectName = this.SubjectName;
    if (this.IssuerCAKeyCert != null)
      subjectName = this.IssuerCAKeyCert.SubjectName;
    RSA privateKey = (RSA) null;
    RSA key = this.m_rsaPublicKey;
    if (key == null)
    {
      privateKey = RSA.Create(this.m_keySize == 0 ? (int) X509Defaults.RSAKeySize : this.m_keySize);
      key = privateKey;
    }
    CertificateRequest request = new CertificateRequest(this.SubjectName, key, this.HashAlgorithmName, RSASignaturePadding.Pkcs1);
    this.CreateX509Extensions(request, false);
    X509Certificate2 certificate = request.Create(subjectName, generator, (DateTimeOffset) this.NotBefore, (DateTimeOffset) this.NotAfter, ((IEnumerable<byte>) this.m_serialNumber).Reverse<byte>().ToArray<byte>());
    return privateKey != null ? certificate.CopyWithPrivateKey(privateKey) : certificate;
  }

  public override X509Certificate2 CreateForECDsa()
  {
    if (this.m_ecdsaPublicKey != null && this.IssuerCAKeyCert == null)
      throw new NotSupportedException("Cannot use a public key without a issuer certificate with a private key.");
    if (this.m_ecdsaPublicKey == null && !this.m_curve.HasValue)
      throw new NotSupportedException("Need a public key or a ECCurve to create the certificate.");
    this.CreateDefaults();
    ECDsa ecDsa = (ECDsa) null;
    ECDsa key = this.m_ecdsaPublicKey;
    if (key == null)
    {
      ecDsa = ECDsa.Create(this.m_curve.Value);
      key = ecDsa;
    }
    CertificateRequest request = new CertificateRequest(this.SubjectName, key, this.HashAlgorithmName);
    this.CreateX509Extensions(request, true);
    byte[] array = ((IEnumerable<byte>) this.m_serialNumber).Reverse<byte>().ToArray<byte>();
    if (this.IssuerCAKeyCert == null)
      return request.Create(this.SubjectName, X509SignatureGenerator.CreateForECDsa(ecDsa), (DateTimeOffset) this.NotBefore, (DateTimeOffset) this.NotAfter, array).CopyWithPrivateKey(ecDsa);
    using (ECDsa ecDsaPrivateKey = ECDsaCertificateExtensions.GetECDsaPrivateKey(this.IssuerCAKeyCert))
      return request.Create(this.IssuerCAKeyCert.SubjectName, X509SignatureGenerator.CreateForECDsa(ecDsaPrivateKey), (DateTimeOffset) this.NotBefore, (DateTimeOffset) this.NotAfter, array);
  }

  public override X509Certificate2 CreateForECDsa(X509SignatureGenerator generator)
  {
    if (this.IssuerCAKeyCert == null)
      throw new NotSupportedException("X509 Signature generator requires an issuer certificate.");
    if (this.m_ecdsaPublicKey == null && !this.m_curve.HasValue)
      throw new NotSupportedException("Need a public key or a ECCurve to create the certificate.");
    this.CreateDefaults();
    ECDsa privateKey = (ECDsa) null;
    ECDsa key = this.m_ecdsaPublicKey;
    if (key == null)
    {
      privateKey = ECDsa.Create(this.m_curve.Value);
      key = privateKey;
    }
    CertificateRequest request = new CertificateRequest(this.SubjectName, key, this.HashAlgorithmName);
    this.CreateX509Extensions(request, true);
    X509Certificate2 certificate = request.Create(this.IssuerCAKeyCert.SubjectName, generator, (DateTimeOffset) this.NotBefore, (DateTimeOffset) this.NotAfter, ((IEnumerable<byte>) this.m_serialNumber).Reverse<byte>().ToArray<byte>());
    return privateKey != null ? certificate.CopyWithPrivateKey(privateKey) : certificate;
  }

  public override ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(byte[] publicKey)
  {
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    throw new NotSupportedException("Import a ECDsaPublicKey is not supported on this platform.");
  }

  public override ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey)
  {
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    int length;
    try
    {
      this.m_rsaPublicKey = Opc.Ua.Security.Certificates.BouncyCastle.X509Utils.SetRSAPublicKey(publicKey);
      length = publicKey.Length;
    }
    catch (Exception ex)
    {
      throw new ArgumentException("Failed to decode the public key.", ex);
    }
    if (publicKey.Length != length)
      throw new ArgumentException("Decoded the public key but extra bytes were found.");
    return (ICertificateBuilderCreateForRSAAny) this;
  }

  private void CreateDefaults()
  {
    if (!this.m_presetSerial)
      this.NewSerialNumber();
    this.m_presetSerial = false;
    this.ValidateSettings();
  }

  private void CreateX509Extensions(CertificateRequest request, bool forECDsa)
  {
    if (this.m_extensions.FindExtension<X509BasicConstraintsExtension>() == null)
    {
      X509BasicConstraintsExtension basicContraints = this.GetBasicContraints();
      request.CertificateExtensions.Add((X509Extension) basicContraints);
    }
    X509SubjectKeyIdentifierExtension identifierExtension = new X509SubjectKeyIdentifierExtension(request.PublicKey, X509SubjectKeyIdentifierHashAlgorithm.Sha1, false);
    if (this.m_extensions.FindExtension<X509SubjectKeyIdentifierExtension>() == null)
      request.CertificateExtensions.Add((X509Extension) identifierExtension);
    if (this.m_extensions.FindExtension<X509AuthorityKeyIdentifierExtension>() == null)
    {
      X509Extension x509Extension = this.IssuerCAKeyCert != null ? X509Extensions.BuildAuthorityKeyIdentifier(this.IssuerCAKeyCert) : (X509Extension) new X509AuthorityKeyIdentifierExtension(identifierExtension.SubjectKeyIdentifier.FromHexString(), this.IssuerName, this.m_serialNumber);
      request.CertificateExtensions.Add(x509Extension);
    }
    if (this.m_extensions.FindExtension<X509KeyUsageExtension>() == null)
    {
      X509KeyUsageFlags keyUsages;
      if (this.m_isCA)
      {
        keyUsages = X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.DigitalSignature;
      }
      else
      {
        keyUsages = !forECDsa ? X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature : X509KeyUsageFlags.KeyAgreement | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature;
        if (this.IssuerCAKeyCert == null)
          keyUsages |= X509KeyUsageFlags.KeyCertSign;
      }
      request.CertificateExtensions.Add((X509Extension) new X509KeyUsageExtension(keyUsages, true));
    }
    if (!this.m_isCA && this.m_extensions.FindExtension<X509EnhancedKeyUsageExtension>() == null)
      request.CertificateExtensions.Add((X509Extension) new X509EnhancedKeyUsageExtension(new OidCollection()
      {
        new Oid("1.3.6.1.5.5.7.3.1"),
        new Oid("1.3.6.1.5.5.7.3.2")
      }, true));
    foreach (X509Extension extension in this.m_extensions)
      request.CertificateExtensions.Add(extension);
  }

  private X509BasicConstraintsExtension GetBasicContraints()
  {
    if (!this.m_isCA && this.IssuerCAKeyCert == null)
      return new X509BasicConstraintsExtension(false, false, 0, true);
    return this.m_isCA && this.m_pathLengthConstraint >= 0 ? new X509BasicConstraintsExtension(true, true, this.m_pathLengthConstraint, true) : new X509BasicConstraintsExtension(this.m_isCA, false, 0, true);
  }
}
