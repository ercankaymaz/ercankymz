// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509Crl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Utilities;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509Crl : X509ExtensionBase
{
  private readonly CertificateList c;
  private readonly string sigAlgName;
  private readonly byte[] sigAlgParams;
  private readonly bool isIndirect;
  private X509Crl.CachedEncoding cachedEncoding;
  private volatile bool hashValueSet;
  private volatile int hashValue;

  public X509Crl(byte[] encoding)
    : this(CertificateList.GetInstance((object) encoding))
  {
  }

  public X509Crl(CertificateList c)
  {
    this.c = c;
    try
    {
      this.sigAlgName = X509SignatureUtilities.GetSignatureName(c.SignatureAlgorithm);
      Asn1Encodable parameters = c.SignatureAlgorithm.Parameters;
      this.sigAlgParams = parameters == null ? (byte[]) null : parameters.GetEncoded("DER");
      this.isIndirect = this.IsIndirectCrl;
    }
    catch (Exception ex)
    {
      throw new CrlException("CRL contents invalid: " + ex?.ToString());
    }
  }

  public virtual CertificateList CertificateList => this.c;

  protected override X509Extensions GetX509Extensions()
  {
    return this.c.Version < 2 ? (X509Extensions) null : this.c.TbsCertList.Extensions;
  }

  public virtual bool IsSignatureValid(AsymmetricKeyParameter key)
  {
    return this.CheckSignatureValid((IVerifierFactory) new Asn1VerifierFactory(this.c.SignatureAlgorithm, key));
  }

  public virtual bool IsSignatureValid(IVerifierFactoryProvider verifierProvider)
  {
    return this.CheckSignatureValid(verifierProvider.CreateVerifierFactory((object) this.c.SignatureAlgorithm));
  }

  public virtual bool IsAlternativeSignatureValid(IVerifierFactoryProvider verifierProvider)
  {
    TbsCertificateList tbsCertList = this.c.TbsCertList;
    X509Extensions extensions = tbsCertList.Extensions;
    AltSignatureAlgorithm signatureAlgorithm = AltSignatureAlgorithm.FromExtensions(extensions);
    AltSignatureValue altSignatureValue = AltSignatureValue.FromExtensions(extensions);
    IVerifierFactory verifierFactory = verifierProvider.CreateVerifierFactory((object) signatureAlgorithm.Algorithm);
    Asn1Sequence instance = Asn1Sequence.GetInstance((object) tbsCertList.ToAsn1Object());
    Asn1EncodableVector elementVector = new Asn1EncodableVector();
    int num = 1;
    if (instance[0] is DerInteger element)
    {
      elementVector.Add((Asn1Encodable) element);
      ++num;
    }
    for (int index = num; index < instance.Count - 1; ++index)
      elementVector.Add(instance[index]);
    elementVector.Add((Asn1Encodable) X509Utilities.TrimExtensions(0, extensions));
    return X509Utilities.VerifySignature(verifierFactory, (Asn1Encodable) new DerSequence(elementVector), altSignatureValue.Signature);
  }

  public virtual void Verify(AsymmetricKeyParameter publicKey)
  {
    this.CheckSignature((IVerifierFactory) new Asn1VerifierFactory(this.c.SignatureAlgorithm, publicKey));
  }

  public virtual void Verify(IVerifierFactoryProvider verifierProvider)
  {
    this.CheckSignature(verifierProvider.CreateVerifierFactory((object) this.c.SignatureAlgorithm));
  }

  public virtual void VerifyAltSignature(IVerifierFactoryProvider verifierProvider)
  {
    if (!this.IsAlternativeSignatureValid(verifierProvider))
      throw new InvalidKeyException("CRL alternative signature does not verify with supplied public key.");
  }

  protected virtual void CheckSignature(IVerifierFactory verifier)
  {
    if (!this.CheckSignatureValid(verifier))
      throw new InvalidKeyException("CRL does not verify with supplied public key.");
  }

  protected virtual bool CheckSignatureValid(IVerifierFactory verifier)
  {
    TbsCertificateList tbsCertList = this.c.TbsCertList;
    if (!this.c.SignatureAlgorithm.Equals((object) tbsCertList.Signature))
      throw new CrlException("Signature algorithm on CertificateList does not match TbsCertList.");
    return X509Utilities.VerifySignature(verifier, (Asn1Encodable) tbsCertList, this.c.Signature);
  }

  public virtual int Version => this.c.Version;

  public virtual X509Name IssuerDN => this.c.Issuer;

  public virtual DateTime ThisUpdate => this.c.ThisUpdate.ToDateTime();

  public virtual DateTime? NextUpdate => this.c.NextUpdate?.ToDateTime();

  private ISet<X509CrlEntry> LoadCrlEntries()
  {
    HashSet<X509CrlEntry> x509CrlEntrySet = new HashSet<X509CrlEntry>();
    IEnumerable<CrlEntry> certificateEnumeration = this.c.GetRevokedCertificateEnumeration();
    X509Name previousCertificateIssuer = this.IssuerDN;
    foreach (CrlEntry c in certificateEnumeration)
    {
      X509CrlEntry x509CrlEntry = new X509CrlEntry(c, this.isIndirect, previousCertificateIssuer);
      x509CrlEntrySet.Add(x509CrlEntry);
      previousCertificateIssuer = x509CrlEntry.GetCertificateIssuer();
    }
    return (ISet<X509CrlEntry>) x509CrlEntrySet;
  }

  public virtual X509CrlEntry GetRevokedCertificate(BigInteger serialNumber)
  {
    IEnumerable<CrlEntry> certificateEnumeration = this.c.GetRevokedCertificateEnumeration();
    X509Name previousCertificateIssuer = this.IssuerDN;
    foreach (CrlEntry c in certificateEnumeration)
    {
      X509CrlEntry revokedCertificate = new X509CrlEntry(c, this.isIndirect, previousCertificateIssuer);
      if (serialNumber.Equals(c.UserCertificate.Value))
        return revokedCertificate;
      previousCertificateIssuer = revokedCertificate.GetCertificateIssuer();
    }
    return (X509CrlEntry) null;
  }

  public virtual ISet<X509CrlEntry> GetRevokedCertificates()
  {
    ISet<X509CrlEntry> x509CrlEntrySet = this.LoadCrlEntries();
    return x509CrlEntrySet.Count > 0 ? x509CrlEntrySet : (ISet<X509CrlEntry>) null;
  }

  public virtual byte[] GetTbsCertList()
  {
    try
    {
      return this.c.TbsCertList.GetDerEncoded();
    }
    catch (Exception ex)
    {
      throw new CrlException(ex.ToString());
    }
  }

  public virtual byte[] GetSignature() => this.c.GetSignatureOctets();

  public virtual string SigAlgName => this.sigAlgName;

  public virtual string SigAlgOid => this.c.SignatureAlgorithm.Algorithm.Id;

  public virtual byte[] GetSigAlgParams() => Arrays.Clone(this.sigAlgParams);

  public virtual byte[] GetEncoded() => Arrays.Clone(this.GetCachedEncoding().GetEncoded());

  public override bool Equals(object other)
  {
    if (this == other)
      return true;
    if (!(other is X509Crl x509Crl))
      return false;
    if (this.hashValueSet && x509Crl.hashValueSet)
    {
      if (this.hashValue != x509Crl.hashValue)
        return false;
    }
    else if (this.cachedEncoding == null || x509Crl.cachedEncoding == null)
    {
      DerBitString signature = this.c.Signature;
      if (signature != null && !signature.Equals((Asn1Object) x509Crl.c.Signature))
        return false;
    }
    byte[] encoding1 = this.GetCachedEncoding().Encoding;
    byte[] encoding2 = x509Crl.GetCachedEncoding().Encoding;
    return encoding1 != null && encoding2 != null && Arrays.AreEqual(encoding1, encoding2);
  }

  public override int GetHashCode()
  {
    if (!this.hashValueSet)
    {
      this.hashValue = Arrays.GetHashCode(this.GetCachedEncoding().Encoding);
      this.hashValueSet = true;
    }
    return this.hashValue;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("              Version: ").Append(this.Version).AppendLine();
    stringBuilder.Append("             IssuerDN: ").Append((object) this.IssuerDN).AppendLine();
    stringBuilder.Append("          This update: ").Append((object) this.ThisUpdate).AppendLine();
    stringBuilder.Append("          Next update: ").Append((object) this.NextUpdate).AppendLine();
    stringBuilder.Append("  Signature Algorithm: ").Append(this.SigAlgName).AppendLine();
    byte[] signature = this.GetSignature();
    stringBuilder.Append("            Signature: ");
    stringBuilder.AppendLine(Hex.ToHexString(signature, 0, 20));
    for (int off = 20; off < signature.Length; off += 20)
    {
      int length = System.Math.Min(20, signature.Length - off);
      stringBuilder.Append("                       ");
      stringBuilder.AppendLine(Hex.ToHexString(signature, off, length));
    }
    X509Extensions extensions = this.c.TbsCertList.Extensions;
    if (extensions != null)
    {
      IEnumerator<DerObjectIdentifier> enumerator = extensions.ExtensionOids.GetEnumerator();
      if (enumerator.MoveNext())
        stringBuilder.AppendLine("           Extensions:");
      do
      {
        DerObjectIdentifier current = enumerator.Current;
        X509Extension extension = extensions.GetExtension(current);
        if (extension.Value == null)
          stringBuilder.AppendLine();
        else
          goto label_8;
label_7:
        continue;
label_8:
        Asn1Object asn1Object = X509ExtensionUtilities.FromExtensionValue(extension.Value);
        stringBuilder.Append("                       critical(").Append(extension.IsCritical).Append(") ");
        try
        {
          if (current.Equals((Asn1Object) X509Extensions.CrlNumber))
          {
            stringBuilder.Append((object) new CrlNumber(DerInteger.GetInstance((object) asn1Object).PositiveValue)).AppendLine();
            goto label_7;
          }
          if (current.Equals((Asn1Object) X509Extensions.DeltaCrlIndicator))
          {
            stringBuilder.Append("Base CRL: " + new CrlNumber(DerInteger.GetInstance((object) asn1Object).PositiveValue)?.ToString()).AppendLine();
            goto label_7;
          }
          if (current.Equals((Asn1Object) X509Extensions.IssuingDistributionPoint))
          {
            stringBuilder.Append((object) IssuingDistributionPoint.GetInstance((object) (Asn1Sequence) asn1Object)).AppendLine();
            goto label_7;
          }
          if (current.Equals((Asn1Object) X509Extensions.CrlDistributionPoints))
          {
            stringBuilder.Append((object) CrlDistPoint.GetInstance((object) (Asn1Sequence) asn1Object)).AppendLine();
            goto label_7;
          }
          if (current.Equals((Asn1Object) X509Extensions.FreshestCrl))
          {
            stringBuilder.Append((object) CrlDistPoint.GetInstance((object) (Asn1Sequence) asn1Object)).AppendLine();
            goto label_7;
          }
          stringBuilder.Append(current.Id);
          stringBuilder.Append(" value = ").Append(Asn1Dump.DumpAsString((Asn1Encodable) asn1Object)).AppendLine();
          goto label_7;
        }
        catch (Exception ex)
        {
          stringBuilder.Append(current.Id);
          stringBuilder.Append(" value = ").Append("*****").AppendLine();
          goto label_7;
        }
      }
      while (enumerator.MoveNext());
    }
    ISet<X509CrlEntry> revokedCertificates = this.GetRevokedCertificates();
    if (revokedCertificates != null)
    {
      foreach (X509CrlEntry x509CrlEntry in (IEnumerable<X509CrlEntry>) revokedCertificates)
      {
        stringBuilder.Append((object) x509CrlEntry);
        stringBuilder.AppendLine();
      }
    }
    return stringBuilder.ToString();
  }

  public virtual bool IsRevoked(X509Certificate cert)
  {
    CrlEntry[] revokedCertificates = this.c.GetRevokedCertificates();
    if (revokedCertificates != null)
    {
      BigInteger serialNumber = cert.SerialNumber;
      for (int index = 0; index < revokedCertificates.Length; ++index)
      {
        if (revokedCertificates[index].UserCertificate.HasValue(serialNumber))
          return true;
      }
    }
    return false;
  }

  protected virtual bool IsIndirectCrl
  {
    get
    {
      Asn1OctetString extensionValue = this.GetExtensionValue(X509Extensions.IssuingDistributionPoint);
      bool isIndirectCrl = false;
      try
      {
        if (extensionValue != null)
          isIndirectCrl = IssuingDistributionPoint.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue)).IsIndirectCrl;
      }
      catch (Exception ex)
      {
        throw new CrlException("Exception reading IssuingDistributionPoint" + ex?.ToString());
      }
      return isIndirectCrl;
    }
  }

  private X509Crl.CachedEncoding GetCachedEncoding()
  {
    return Objects.EnsureSingletonInitialized<X509Crl.CachedEncoding, CertificateList>(ref this.cachedEncoding, this.c, new Func<CertificateList, X509Crl.CachedEncoding>(X509Crl.CreateCachedEncoding));
  }

  private static X509Crl.CachedEncoding CreateCachedEncoding(CertificateList c)
  {
    byte[] encoding = (byte[]) null;
    CrlException exception = (CrlException) null;
    try
    {
      encoding = c.GetEncoded("DER");
    }
    catch (IOException ex)
    {
      exception = new CrlException("Failed to DER-encode CRL", (Exception) ex);
    }
    return new X509Crl.CachedEncoding(encoding, exception);
  }

  private class CachedEncoding
  {
    private readonly byte[] encoding;
    private readonly CrlException exception;

    internal CachedEncoding(byte[] encoding, CrlException exception)
    {
      this.encoding = encoding;
      this.exception = exception;
    }

    internal byte[] Encoding => this.encoding;

    internal byte[] GetEncoded()
    {
      if (this.exception != null)
        throw this.exception;
      return this.encoding != null ? this.encoding : throw new CrlException();
    }
  }
}
