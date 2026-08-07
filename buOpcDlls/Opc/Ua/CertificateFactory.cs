// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class CertificateFactory
{
  public static readonly ushort DefaultKeySize = 2048 /*0x0800*/;
  public static readonly ushort DefaultHashSize = 256 /*0x0100*/;
  public static readonly ushort DefaultLifeTime = 12;
  private static readonly Dictionary<string, X509Certificate2> m_certificates = new Dictionary<string, X509Certificate2>();
  private static readonly object m_certificatesLock = new object();

  public static X509Certificate2 Create(byte[] encodedData, bool useCache)
  {
    return useCache ? CertificateFactory.Load(new X509Certificate2(encodedData), false) : new X509Certificate2(encodedData);
  }

  public static X509Certificate2 Load(X509Certificate2 certificate, bool ensurePrivateKeyAccessible)
  {
    if (certificate == null)
      return (X509Certificate2) null;
    lock (CertificateFactory.m_certificatesLock)
    {
      X509Certificate2 x509Certificate2 = (X509Certificate2) null;
      if (CertificateFactory.m_certificates.TryGetValue(certificate.Thumbprint, out x509Certificate2))
        return x509Certificate2;
      if (!certificate.HasPrivateKey || !ensurePrivateKeyAccessible)
        return certificate;
      if (ensurePrivateKeyAccessible && !X509Utils.VerifyRSAKeyPair(certificate, certificate))
      {
        Utils.LogWarning("Trying to add certificate to cache with invalid private key.");
        return (X509Certificate2) null;
      }
      CertificateFactory.m_certificates[certificate.Thumbprint] = certificate;
      if (CertificateFactory.m_certificates.Count > 100)
        Utils.LogWarning("Certificate cache has {0} certificates in it.", (object) CertificateFactory.m_certificates.Count);
    }
    return certificate;
  }

  public static ICertificateBuilder CreateCertificate(string subjectName)
  {
    return CertificateBuilder.Create(subjectName);
  }

  public static ICertificateBuilder CreateCertificate(
    string applicationUri,
    string applicationName,
    string subjectName,
    IList<string> domainNames)
  {
    CertificateFactory.SetSuitableDefaults(ref applicationUri, ref applicationName, ref subjectName, ref domainNames);
    return CertificateBuilder.Create(subjectName).AddExtension((X509Extension) new X509SubjectAltNameExtension(applicationUri, (IEnumerable<string>) domainNames));
  }

  [Obsolete("Use the new CreateCertificate methods with CertificateBuilder.")]
  public static X509Certificate2 CreateCertificate(
    string storeType,
    string storePath,
    string password,
    string applicationUri,
    string applicationName,
    string subjectName,
    IList<string> domainNames,
    ushort keySize,
    DateTime startTime,
    ushort lifetimeInMonths,
    ushort hashSizeInBits,
    bool isCA = false,
    X509Certificate2 issuerCAKeyCert = null,
    byte[] publicKey = null,
    int pathLengthConstraint = 0)
  {
    return CertificateFactory.CreateCertificate(applicationUri, applicationName, subjectName, domainNames, keySize, startTime, lifetimeInMonths, hashSizeInBits, isCA, issuerCAKeyCert, publicKey, pathLengthConstraint).AddToStore(storeType, storePath, password);
  }

  public static X509CRL RevokeCertificate(
    X509Certificate2 issuerCertificate,
    X509CRLCollection issuerCrls,
    X509Certificate2Collection revokedCertificates)
  {
    return CertificateFactory.RevokeCertificate(issuerCertificate, issuerCrls, revokedCertificates, DateTime.UtcNow, DateTime.UtcNow.AddMonths(12));
  }

  public static X509CRL RevokeCertificate(
    X509Certificate2 issuerCertificate,
    X509CRLCollection issuerCrls,
    X509Certificate2Collection revokedCertificates,
    DateTime thisUpdate,
    DateTime nextUpdate)
  {
    if (!issuerCertificate.HasPrivateKey)
      throw new ServiceResultException(2148663296U /*0x80120000*/, "Issuer certificate has no private key, cannot revoke certificate.");
    BigInteger bigInteger = (BigInteger) 0;
    Dictionary<string, RevokedCertificate> dictionary = new Dictionary<string, RevokedCertificate>();
    if (issuerCrls != null)
    {
      foreach (X509CRL issuerCrl in (List<X509CRL>) issuerCrls)
      {
        X509CrlNumberExtension extension = issuerCrl.CrlExtensions.FindExtension<X509CrlNumberExtension>();
        if (extension != null && extension.CrlNumber > bigInteger)
          bigInteger = extension.CrlNumber;
        foreach (RevokedCertificate revokedCertificate in (IEnumerable<RevokedCertificate>) issuerCrl.RevokedCertificates)
        {
          if (!dictionary.ContainsKey(revokedCertificate.SerialNumber))
            dictionary[revokedCertificate.SerialNumber] = revokedCertificate;
        }
      }
    }
    if (revokedCertificates != null)
    {
      foreach (X509Certificate2 revokedCertificate1 in revokedCertificates)
      {
        if (!dictionary.ContainsKey(revokedCertificate1.SerialNumber))
        {
          RevokedCertificate revokedCertificate2 = new RevokedCertificate(revokedCertificate1.SerialNumber, CRLReason.PrivilegeWithdrawn);
          dictionary[revokedCertificate1.SerialNumber] = revokedCertificate2;
        }
      }
    }
    return new X509CRL(CrlBuilder.Create(issuerCertificate.SubjectName).AddRevokedCertificates((IList<RevokedCertificate>) dictionary.Values.ToList<RevokedCertificate>()).SetThisUpdate(thisUpdate).SetNextUpdate(nextUpdate).AddCRLExtension(X509Extensions.BuildAuthorityKeyIdentifier(issuerCertificate)).AddCRLExtension(X509Extensions.BuildCRLNumber(bigInteger + (BigInteger) 1)).CreateForRSA(issuerCertificate));
  }

  public static byte[] CreateSigningRequest(X509Certificate2 certificate, IList<string> domainNames = null)
  {
    RSA key = certificate.HasPrivateKey ? RSACertificateExtensions.GetRSAPublicKey(certificate) : throw new NotSupportedException("Need a certificate with a private key.");
    CertificateRequest certificateRequest = new CertificateRequest(certificate.SubjectName, key, Opc.Ua.Security.Certificates.Oids.GetHashAlgorithmName(certificate.SignatureAlgorithm.Value), RSASignaturePadding.Pkcs1);
    X509SubjectAltNameExtension extension = certificate.FindExtension<X509SubjectAltNameExtension>();
    domainNames = domainNames ?? (IList<string>) new List<string>();
    if (extension != null)
    {
      foreach (string domainName in (IEnumerable<string>) extension.DomainNames)
      {
        string name = domainName;
        if (!domainNames.Any<string>((Func<string, bool>) (s => s.Equals(name, StringComparison.OrdinalIgnoreCase))))
          domainNames.Add(name);
      }
      foreach (string ipAddress1 in (IEnumerable<string>) extension.IPAddresses)
      {
        string ipAddress = ipAddress1;
        if (!domainNames.Any<string>((Func<string, bool>) (s => s.Equals(ipAddress, StringComparison.OrdinalIgnoreCase))))
          domainNames.Add(ipAddress);
      }
    }
    X509SubjectAltNameExtension encodedExtension = new X509SubjectAltNameExtension(X509Utils.GetApplicationUriFromCertificate(certificate), (IEnumerable<string>) domainNames);
    certificateRequest.CertificateExtensions.Add(new X509Extension((AsnEncodedData) encodedExtension, false));
    using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(certificate))
    {
      X509SignatureGenerator forRsa = X509SignatureGenerator.CreateForRSA(rsaPrivateKey, RSASignaturePadding.Pkcs1);
      return certificateRequest.CreateSigningRequest(forRsa);
    }
  }

  public static X509Certificate2 CreateCertificateWithPrivateKey(
    X509Certificate2 certificate,
    X509Certificate2 certificateWithPrivateKey)
  {
    if (!certificateWithPrivateKey.HasPrivateKey)
      throw new NotSupportedException("Need a certificate with a private key.");
    return X509Utils.VerifyRSAKeyPair(certificate, certificateWithPrivateKey) ? certificate.CopyWithPrivateKey(RSACertificateExtensions.GetRSAPrivateKey(certificateWithPrivateKey)) : throw new NotSupportedException("The public and the private key pair doesn't match.");
  }

  public static X509Certificate2 CreateCertificateWithPEMPrivateKey(
    X509Certificate2 certificate,
    byte[] pemDataBlob,
    string password = null)
  {
    RSA privateKey = PEMReader.ImportPrivateKeyFromPEM(pemDataBlob, password);
    return new X509Certificate2(certificate.RawData).CopyWithPrivateKey(privateKey);
  }

  [Obsolete("Use the new CreateCertificate methods with CertificateBuilder.")]
  internal static X509Certificate2 CreateCertificate(
    string applicationUri,
    string applicationName,
    string subjectName,
    IList<string> domainNames,
    ushort keySize,
    DateTime startTime,
    ushort lifetimeInMonths,
    ushort hashSizeInBits,
    bool isCA = false,
    X509Certificate2 issuerCAKeyCert = null,
    byte[] publicKey = null,
    int pathLengthConstraint = 0)
  {
    ICertificateBuilder certificateBuilder = !isCA ? CertificateFactory.CreateCertificate(applicationUri, applicationName, subjectName, domainNames) : CertificateFactory.CreateCertificate(subjectName);
    certificateBuilder.SetNotBefore(startTime);
    certificateBuilder.SetNotAfter(startTime.AddMonths((int) lifetimeInMonths));
    certificateBuilder.SetHashAlgorithm(X509Utils.GetRSAHashAlgorithmName((uint) hashSizeInBits));
    if (isCA)
      certificateBuilder.SetCAConstraint(pathLengthConstraint);
    ICertificateBuilderCreateForRSA builderCreateForRsa;
    if (issuerCAKeyCert != null)
    {
      ICertificateBuilderIssuer certificateBuilderIssuer = certificateBuilder.SetIssuer(issuerCAKeyCert);
      builderCreateForRsa = publicKey == null ? (ICertificateBuilderCreateForRSA) certificateBuilderIssuer.SetRSAKeySize(keySize) : (ICertificateBuilderCreateForRSA) certificateBuilderIssuer.SetRSAPublicKey(publicKey);
    }
    else
      builderCreateForRsa = (ICertificateBuilderCreateForRSA) certificateBuilder.SetRSAKeySize(keySize);
    return builderCreateForRsa.CreateForRSA();
  }

  private static void SetSuitableDefaults(
    ref string applicationUri,
    ref string applicationName,
    ref string subjectName,
    ref IList<string> domainNames)
  {
    List<string> stringList = (List<string>) null;
    if (!string.IsNullOrEmpty(subjectName))
      stringList = X509Utils.ParseDistinguishedName(subjectName);
    if (string.IsNullOrEmpty(applicationName))
    {
      if (stringList == null)
        throw new ArgumentNullException(nameof (applicationName), "Must specify a applicationName or a subjectName.");
      for (int index = 0; index < stringList.Count; ++index)
      {
        if (stringList[index].StartsWith("CN=", StringComparison.Ordinal))
        {
          applicationName = stringList[index].Substring(3).Trim();
          break;
        }
      }
    }
    if (string.IsNullOrEmpty(applicationName))
      throw new ArgumentNullException(nameof (applicationName), "Must specify a applicationName or a subjectName.");
    StringBuilder stringBuilder1 = new StringBuilder();
    for (int index = 0; index < applicationName.Length; ++index)
    {
      char c = applicationName[index];
      if (char.IsControl(c) || c == '/' || c == ',' || c == ';')
        c = '+';
      stringBuilder1.Append(c);
    }
    applicationName = stringBuilder1.ToString();
    if (domainNames == null || domainNames.Count == 0)
    {
      domainNames = (IList<string>) new List<string>();
      domainNames.Add(Utils.GetHostName());
    }
    if (string.IsNullOrEmpty(applicationUri))
    {
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("urn:");
      stringBuilder2.Append(domainNames[0]);
      stringBuilder2.Append(':');
      stringBuilder2.Append(applicationName);
      applicationUri = stringBuilder2.ToString();
    }
    if (Utils.ParseUri(applicationUri) == (Uri) null)
      throw new ArgumentNullException(nameof (applicationUri), "Must specify a valid URL.");
    if (string.IsNullOrEmpty(subjectName))
      subjectName = Utils.Format("CN={0}", (object) applicationName);
    if (!subjectName.Contains("CN="))
      subjectName = Utils.Format("CN={0}", (object) subjectName);
    if (domainNames == null || domainNames.Count <= 0)
      return;
    if (!subjectName.Contains("DC=") && !subjectName.Contains<char>('='))
      subjectName += Utils.Format(", DC={0}", (object) domainNames[0]);
    else
      subjectName = Utils.ReplaceDCLocalhost(subjectName, domainNames[0]);
  }
}
