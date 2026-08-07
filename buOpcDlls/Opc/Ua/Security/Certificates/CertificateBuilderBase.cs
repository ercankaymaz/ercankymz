// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.CertificateBuilderBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public abstract class CertificateBuilderBase : 
  IX509Certificate,
  ICertificateBuilder,
  ICertificateBuilderConfig,
  ICertificateBuilderPublicKey,
  ICertificateBuilderRSAPublicKey,
  ICertificateBuilderECDsaPublicKey,
  ICertificateBuilderSetIssuer,
  ICertificateBuilderParameter,
  ICertificateBuilderRSAParameter,
  ICertificateBuilderECCParameter,
  ICertificateBuilderCreateForRSA,
  ICertificateBuilderIssuer,
  ICertificateBuilderCreateGenerator,
  ICertificateBuilderCreateForRSAGenerator,
  ICertificateBuilderCreateForECDsaGenerator,
  ICertificateBuilderCreateForRSAAny,
  ICertificateBuilderCreateForECDsa,
  ICertificateBuilderCreateForECDsaAny
{
  protected bool m_isCA;
  protected int m_pathLengthConstraint;
  protected int m_serialNumberLength;
  protected bool m_presetSerial;
  protected byte[] m_serialNumber;
  protected X509ExtensionCollection m_extensions;
  protected RSA m_rsaPublicKey;
  protected int m_keySize;
  protected ECDsa m_ecdsaPublicKey;
  protected ECCurve? m_curve;
  private X509Certificate2 m_issuerCAKeyCert;
  private DateTime m_notBefore;
  private DateTime m_notAfter;
  private HashAlgorithmName m_hashAlgorithmName;
  private X500DistinguishedName m_subjectName;
  private X500DistinguishedName m_issuerName;

  protected CertificateBuilderBase(X500DistinguishedName subjectName)
  {
    this.m_issuerName = this.m_subjectName = subjectName;
    this.Initialize();
  }

  protected CertificateBuilderBase(string subjectName)
  {
    this.m_issuerName = this.m_subjectName = new X500DistinguishedName(subjectName);
    this.Initialize();
  }

  protected virtual void Initialize()
  {
    DateTime dateTime = DateTime.UtcNow;
    dateTime = dateTime.AddDays(-1.0);
    this.m_notBefore = dateTime.Date;
    this.m_notAfter = this.NotBefore.AddMonths((int) X509Defaults.LifeTime);
    this.m_hashAlgorithmName = X509Defaults.HashAlgorithmName;
    this.m_serialNumberLength = X509Defaults.SerialNumberLengthMin;
    this.m_extensions = new X509ExtensionCollection();
  }

  public X500DistinguishedName SubjectName => this.m_subjectName;

  public X500DistinguishedName IssuerName => this.m_issuerName;

  public DateTime NotBefore => this.m_notBefore;

  public DateTime NotAfter => this.m_notAfter;

  public string SerialNumber => this.m_serialNumber.ToHexString(true);

  public byte[] GetSerialNumber() => this.m_serialNumber;

  public HashAlgorithmName HashAlgorithmName => this.m_hashAlgorithmName;

  public X509ExtensionCollection Extensions => this.m_extensions;

  public abstract X509Certificate2 CreateForRSA();

  public abstract X509Certificate2 CreateForRSA(X509SignatureGenerator generator);

  public abstract X509Certificate2 CreateForECDsa();

  public abstract X509Certificate2 CreateForECDsa(X509SignatureGenerator generator);

  public ICertificateBuilder SetSerialNumberLength(int length)
  {
    this.m_serialNumberLength = length <= X509Defaults.SerialNumberLengthMax && length != 0 ? length : throw new ArgumentOutOfRangeException(nameof (length), "SerialNumber length out of Range");
    this.m_presetSerial = false;
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder SetSerialNumber(byte[] serialNumber)
  {
    if (serialNumber.Length > X509Defaults.SerialNumberLengthMax || serialNumber.Length == 0)
      throw new ArgumentOutOfRangeException(nameof (serialNumber), "SerialNumber array exceeds supported length.");
    this.m_serialNumberLength = serialNumber.Length;
    this.m_serialNumber = new byte[serialNumber.Length];
    Array.Copy((Array) serialNumber, (Array) this.m_serialNumber, serialNumber.Length);
    this.m_serialNumber[this.m_serialNumberLength - 1] &= (byte) 127 /*0x7F*/;
    this.m_presetSerial = true;
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder CreateSerialNumber()
  {
    this.NewSerialNumber();
    this.m_presetSerial = true;
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder SetNotBefore(DateTime notBefore)
  {
    this.m_notBefore = notBefore;
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder SetNotAfter(DateTime notAfter)
  {
    this.m_notAfter = notAfter;
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder SetLifeTime(TimeSpan lifeTime)
  {
    this.m_notAfter = this.m_notBefore.Add(lifeTime);
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder SetLifeTime(ushort months)
  {
    this.m_notAfter = this.m_notBefore.AddMonths(months == (ushort) 0 ? (int) X509Defaults.LifeTime : (int) months);
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName)
  {
    this.m_hashAlgorithmName = hashAlgorithmName;
    return (ICertificateBuilder) this;
  }

  public ICertificateBuilder SetCAConstraint(int pathLengthConstraint = -1)
  {
    this.m_isCA = true;
    this.m_pathLengthConstraint = pathLengthConstraint;
    this.m_serialNumberLength = X509Defaults.SerialNumberLengthMax;
    return (ICertificateBuilder) this;
  }

  public virtual ICertificateBuilderCreateForRSAAny SetRSAKeySize(ushort keySize)
  {
    if (keySize == (ushort) 0)
      keySize = X509Defaults.RSAKeySize;
    if ((int) keySize % 1024 /*0x0400*/ != 0 || (int) keySize < (int) X509Defaults.RSAKeySizeMin || (int) keySize > (int) X509Defaults.RSAKeySizeMax)
      throw new ArgumentException("KeySize must be a multiple of 1024 or is not in the allowed range.", nameof (keySize));
    this.m_keySize = (int) keySize;
    return (ICertificateBuilderCreateForRSAAny) this;
  }

  public virtual ICertificateBuilder AddExtension(X509Extension extension)
  {
    if (extension == null)
      throw new ArgumentNullException(nameof (extension));
    this.m_extensions.Add(extension);
    return (ICertificateBuilder) this;
  }

  public virtual ICertificateBuilderCreateForECDsaAny SetECCurve(ECCurve curve)
  {
    this.m_curve = new ECCurve?(curve);
    return (ICertificateBuilderCreateForECDsaAny) this;
  }

  public abstract ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(byte[] publicKey);

  public virtual ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(ECDsa publicKey)
  {
    this.m_ecdsaPublicKey = publicKey != null ? publicKey : throw new ArgumentNullException(nameof (publicKey));
    return (ICertificateBuilderCreateForECDsaAny) this;
  }

  public abstract ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey);

  public virtual ICertificateBuilderCreateForRSAAny SetRSAPublicKey(RSA publicKey)
  {
    this.m_rsaPublicKey = publicKey != null ? publicKey : throw new ArgumentNullException(nameof (publicKey));
    return (ICertificateBuilderCreateForRSAAny) this;
  }

  public virtual ICertificateBuilderIssuer SetIssuer(X509Certificate2 issuerCertificate)
  {
    this.m_issuerCAKeyCert = issuerCertificate != null ? issuerCertificate : throw new ArgumentNullException(nameof (issuerCertificate));
    this.m_issuerName = issuerCertificate.SubjectName;
    return (ICertificateBuilderIssuer) this;
  }

  protected X509Certificate2 IssuerCAKeyCert => this.m_issuerCAKeyCert;

  protected void ValidateSettings()
  {
    if (this.m_issuerCAKeyCert == null)
      return;
    DateTime dateTime;
    if (this.NotAfter.ToUniversalTime() > this.m_issuerCAKeyCert.NotAfter.ToUniversalTime())
    {
      dateTime = this.m_issuerCAKeyCert.NotAfter;
      this.m_notAfter = dateTime.ToUniversalTime();
    }
    dateTime = this.NotBefore;
    DateTime universalTime1 = dateTime.ToUniversalTime();
    dateTime = this.m_issuerCAKeyCert.NotBefore;
    DateTime universalTime2 = dateTime.ToUniversalTime();
    if (!(universalTime1 < universalTime2))
      return;
    dateTime = this.m_issuerCAKeyCert.NotBefore;
    this.m_notBefore = dateTime.ToUniversalTime();
  }

  protected virtual void NewSerialNumber()
  {
    using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
    {
      this.m_serialNumber = new byte[this.m_serialNumberLength];
      randomNumberGenerator.GetBytes(this.m_serialNumber);
    }
    this.m_serialNumber[this.m_serialNumberLength - 1] &= (byte) 127 /*0x7F*/;
  }
}
