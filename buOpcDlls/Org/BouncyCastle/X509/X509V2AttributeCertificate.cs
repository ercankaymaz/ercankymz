// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509V2AttributeCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509V2AttributeCertificate : X509ExtensionBase
{
  private readonly AttributeCertificate cert;
  private readonly DateTime notBefore;
  private readonly DateTime notAfter;

  private static AttributeCertificate GetObject(Stream input)
  {
    try
    {
      return AttributeCertificate.GetInstance((object) Asn1Object.FromStream(input));
    }
    catch (IOException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new IOException("exception decoding certificate structure", ex);
    }
  }

  public X509V2AttributeCertificate(Stream encIn)
    : this(X509V2AttributeCertificate.GetObject(encIn))
  {
  }

  public X509V2AttributeCertificate(byte[] encoded)
    : this((Stream) new MemoryStream(encoded, false))
  {
  }

  public X509V2AttributeCertificate(AttributeCertificate cert)
  {
    this.cert = cert;
    try
    {
      this.notAfter = cert.ACInfo.AttrCertValidityPeriod.NotAfterTime.ToDateTime();
      this.notBefore = cert.ACInfo.AttrCertValidityPeriod.NotBeforeTime.ToDateTime();
    }
    catch (Exception ex)
    {
      throw new IOException("invalid data structure in certificate!", ex);
    }
  }

  public virtual AttributeCertificate AttributeCertificate => this.cert;

  public virtual int Version => this.cert.ACInfo.Version.IntValueExact + 1;

  public virtual BigInteger SerialNumber => this.cert.ACInfo.SerialNumber.Value;

  public virtual AttributeCertificateHolder Holder
  {
    get => new AttributeCertificateHolder((Asn1Sequence) this.cert.ACInfo.Holder.ToAsn1Object());
  }

  public virtual AttributeCertificateIssuer Issuer
  {
    get => new AttributeCertificateIssuer(this.cert.ACInfo.Issuer);
  }

  public virtual DateTime NotBefore => this.notBefore;

  public virtual DateTime NotAfter => this.notAfter;

  public virtual bool[] GetIssuerUniqueID()
  {
    DerBitString issuerUniqueId1 = this.cert.ACInfo.IssuerUniqueID;
    if (issuerUniqueId1 == null)
      return (bool[]) null;
    byte[] bytes = issuerUniqueId1.GetBytes();
    bool[] issuerUniqueId2 = new bool[bytes.Length * 8 - issuerUniqueId1.PadBits];
    for (int index = 0; index != issuerUniqueId2.Length; ++index)
      issuerUniqueId2[index] = ((uint) bytes[index / 8] & (uint) (128 /*0x80*/ >> index % 8)) > 0U;
    return issuerUniqueId2;
  }

  public virtual bool IsValidNow => this.IsValid(DateTime.UtcNow);

  public virtual bool IsValid(DateTime date)
  {
    return date.CompareTo(this.NotBefore) >= 0 && date.CompareTo(this.NotAfter) <= 0;
  }

  public virtual void CheckValidity() => this.CheckValidity(DateTime.UtcNow);

  public virtual void CheckValidity(DateTime date)
  {
    if (date.CompareTo(this.NotAfter) > 0)
      throw new CertificateExpiredException("certificate expired on " + this.NotAfter.ToString());
    if (date.CompareTo(this.NotBefore) < 0)
      throw new CertificateNotYetValidException("certificate not valid until " + this.NotBefore.ToString());
  }

  public virtual AlgorithmIdentifier SignatureAlgorithm => this.cert.SignatureAlgorithm;

  public virtual byte[] GetSignature() => this.cert.GetSignatureOctets();

  public virtual bool IsSignatureValid(AsymmetricKeyParameter key)
  {
    return this.CheckSignatureValid((IVerifierFactory) new Asn1VerifierFactory(this.cert.SignatureAlgorithm, key));
  }

  public virtual bool IsSignatureValid(IVerifierFactoryProvider verifierProvider)
  {
    return this.CheckSignatureValid(verifierProvider.CreateVerifierFactory((object) this.cert.SignatureAlgorithm));
  }

  public virtual void Verify(AsymmetricKeyParameter key)
  {
    this.CheckSignature((IVerifierFactory) new Asn1VerifierFactory(this.cert.SignatureAlgorithm, key));
  }

  public virtual void Verify(IVerifierFactoryProvider verifierProvider)
  {
    this.CheckSignature(verifierProvider.CreateVerifierFactory((object) this.cert.SignatureAlgorithm));
  }

  protected virtual void CheckSignature(IVerifierFactory verifier)
  {
    if (!this.CheckSignatureValid(verifier))
      throw new InvalidKeyException("Public key presented not for certificate signature");
  }

  protected virtual bool CheckSignatureValid(IVerifierFactory verifier)
  {
    AttributeCertificateInfo acInfo = this.cert.ACInfo;
    if (!this.cert.SignatureAlgorithm.Equals((object) acInfo.Signature))
      throw new CertificateException("Signature algorithm in certificate info not same as outer certificate");
    return X509Utilities.VerifySignature(verifier, (Asn1Encodable) acInfo, this.cert.SignatureValue);
  }

  public virtual byte[] GetEncoded() => this.cert.GetEncoded();

  protected override X509Extensions GetX509Extensions() => this.cert.ACInfo.Extensions;

  public virtual X509Attribute[] GetAttributes()
  {
    Asn1Sequence attributes1 = this.cert.ACInfo.Attributes;
    X509Attribute[] attributes2 = new X509Attribute[attributes1.Count];
    for (int index = 0; index != attributes1.Count; ++index)
      attributes2[index] = new X509Attribute(attributes1[index]);
    return attributes2;
  }

  public virtual X509Attribute[] GetAttributes(string oid)
  {
    Asn1Sequence attributes = this.cert.ACInfo.Attributes;
    List<X509Attribute> x509AttributeList = new List<X509Attribute>();
    for (int index = 0; index != attributes.Count; ++index)
    {
      X509Attribute x509Attribute = new X509Attribute(attributes[index]);
      if (x509Attribute.Oid.Equals(oid))
        x509AttributeList.Add(x509Attribute);
    }
    return x509AttributeList.Count < 1 ? (X509Attribute[]) null : x509AttributeList.ToArray();
  }

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is X509V2AttributeCertificate attributeCertificate && this.cert.Equals((object) attributeCertificate.cert);
  }

  public override int GetHashCode() => this.cert.GetHashCode();
}
