// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509CRL
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class X509CRL : IX509CRL
{
  private bool m_decoded;
  private X509Signature m_signature;
  private X500DistinguishedName m_issuerName;
  private DateTime m_thisUpdate;
  private DateTime m_nextUpdate;
  private HashAlgorithmName m_hashAlgorithmName;
  private List<RevokedCertificate> m_revokedCertificates;
  private X509ExtensionCollection m_crlExtensions;

  public X509CRL(string filePath)
    : this()
  {
    this.RawData = File.ReadAllBytes(filePath);
  }

  public X509CRL(byte[] crl)
    : this()
  {
    this.RawData = crl;
  }

  public X509CRL(IX509CRL crl)
  {
    this.m_decoded = true;
    this.m_issuerName = crl.IssuerName;
    this.m_hashAlgorithmName = crl.HashAlgorithmName;
    this.m_thisUpdate = crl.ThisUpdate;
    this.m_nextUpdate = crl.NextUpdate;
    this.m_revokedCertificates = new List<RevokedCertificate>((IEnumerable<RevokedCertificate>) crl.RevokedCertificates);
    this.m_crlExtensions = new X509ExtensionCollection();
    foreach (X509Extension crlExtension in crl.CrlExtensions)
      this.m_crlExtensions.Add(crlExtension);
    this.RawData = crl.RawData;
  }

  internal X509CRL()
  {
    this.m_decoded = false;
    this.m_thisUpdate = DateTime.MinValue;
    this.m_nextUpdate = DateTime.MinValue;
    this.m_revokedCertificates = new List<RevokedCertificate>();
    this.m_crlExtensions = new X509ExtensionCollection();
  }

  public X500DistinguishedName IssuerName
  {
    get
    {
      this.EnsureDecoded();
      return this.m_issuerName;
    }
  }

  public string Issuer => this.IssuerName.Name;

  public DateTime ThisUpdate
  {
    get
    {
      this.EnsureDecoded();
      return this.m_thisUpdate;
    }
  }

  public DateTime NextUpdate
  {
    get
    {
      this.EnsureDecoded();
      return this.m_nextUpdate;
    }
  }

  public HashAlgorithmName HashAlgorithmName
  {
    get
    {
      this.EnsureDecoded();
      return this.m_hashAlgorithmName;
    }
  }

  public IList<RevokedCertificate> RevokedCertificates
  {
    get
    {
      this.EnsureDecoded();
      return (IList<RevokedCertificate>) this.m_revokedCertificates.AsReadOnly();
    }
  }

  public X509ExtensionCollection CrlExtensions
  {
    get
    {
      this.EnsureDecoded();
      return this.m_crlExtensions;
    }
  }

  public byte[] RawData { get; private set; }

  public bool VerifySignature(X509Certificate2 issuer, bool throwOnError)
  {
    bool flag;
    try
    {
      flag = new X509Signature(this.RawData).Verify(issuer);
    }
    catch (Exception ex)
    {
      flag = false;
    }
    return !(!flag & throwOnError) ? flag : throw new CryptographicException("Could not verify signature on CRL.");
  }

  public bool IsRevoked(X509Certificate2 certificate)
  {
    if (certificate.IssuerName.Equals((object) this.IssuerName))
      throw new CryptographicException("Certificate was not created by the CRL Issuer.");
    this.EnsureDecoded();
    byte[] serialNumber = certificate.GetSerialNumber();
    foreach (RevokedCertificate revokedCertificate in (IEnumerable<RevokedCertificate>) this.RevokedCertificates)
    {
      if (((IEnumerable<byte>) serialNumber).SequenceEqual<byte>((IEnumerable<byte>) revokedCertificate.UserCertificate))
        return true;
    }
    return false;
  }

  internal void Decode(byte[] crl)
  {
    this.m_signature = new X509Signature(crl);
    this.DecodeCrl(this.m_signature.Tbs);
  }

  internal void DecodeCrl(byte[] tbs)
  {
    try
    {
      System.Formats.Asn1.AsnReader asnReader1 = new System.Formats.Asn1.AsnReader((System.ReadOnlyMemory<byte>) tbs, System.Formats.Asn1.AsnEncodingRules.DER);
      System.Formats.Asn1.Asn1Tag sequence = System.Formats.Asn1.Asn1Tag.Sequence;
      System.Formats.Asn1.AsnReader asnReader2 = asnReader1.ReadSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
      asnReader1.ThrowIfNotEmpty();
      if (asnReader2 == null)
        throw new CryptographicException("The CRL contains ivalid data.");
      uint num = 0;
      System.Formats.Asn1.Asn1Tag asn1Tag1 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.UniversalTagNumber.Integer);
      if (asnReader2.PeekTag() == asn1Tag1 && asnReader2.TryReadUInt32(out num) && num != 1U)
        throw new AsnContentException($"The CRL contains an incorrect version {num}");
      System.Formats.Asn1.AsnReader asnReader3 = asnReader2.ReadSequence();
      this.m_hashAlgorithmName = Oids.GetHashAlgorithmName(asnReader3.ReadObjectIdentifier());
      if (asnReader3.HasData)
        asnReader3.ReadNull();
      asnReader3.ThrowIfNotEmpty();
      this.m_issuerName = new X500DistinguishedName(asnReader2.ReadEncodedValue().ToArray());
      this.m_thisUpdate = X509CRL.ReadTime(asnReader2, false);
      this.m_nextUpdate = X509CRL.ReadTime(asnReader2, true);
      System.Formats.Asn1.Asn1Tag asn1Tag2 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.UniversalTagNumber.Sequence, true);
      if (asnReader2.PeekTag() == asn1Tag2)
      {
        System.Formats.Asn1.AsnReader asnReader4 = asnReader2.ReadSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
        List<RevokedCertificate> revokedCertificateList = new List<RevokedCertificate>();
        while (asnReader4.HasData)
        {
          System.Formats.Asn1.AsnReader asnReader5 = asnReader4.ReadSequence();
          RevokedCertificate revokedCertificate = new RevokedCertificate(asnReader5.ReadInteger().ToByteArray());
          revokedCertificate.RevocationDate = X509CRL.ReadTime(asnReader5, false);
          if (num == 1U && asnReader5.HasData)
          {
            System.Formats.Asn1.AsnReader reader = asnReader5.ReadSequence();
            while (reader.HasData)
            {
              X509Extension extension = reader.ReadExtension();
              revokedCertificate.CrlEntryExtensions.Add(extension);
            }
            reader.ThrowIfNotEmpty();
          }
          asnReader5.ThrowIfNotEmpty();
          revokedCertificateList.Add(revokedCertificate);
        }
        asnReader4.ThrowIfNotEmpty();
        this.m_revokedCertificates = revokedCertificateList;
      }
      if (num == 1U && asnReader2.HasData)
      {
        System.Formats.Asn1.Asn1Tag asn1Tag3 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 0);
        System.Formats.Asn1.AsnReader asnReader6 = asnReader2.ReadSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag3));
        X509ExtensionCollection extensionCollection = new X509ExtensionCollection();
        System.Formats.Asn1.Asn1Tag? expectedTag = new System.Formats.Asn1.Asn1Tag?();
        System.Formats.Asn1.AsnReader reader = asnReader6.ReadSequence(expectedTag);
        while (reader.HasData)
        {
          X509Extension extension = reader.ReadExtension();
          extensionCollection.Add(extension);
        }
        this.m_crlExtensions = extensionCollection;
      }
      asnReader2.ThrowIfNotEmpty();
      this.m_decoded = true;
    }
    catch (AsnContentException ex)
    {
      throw new CryptographicException("Failed to decode the CRL.", (Exception) ex);
    }
  }

  private static DateTime ReadTime(System.Formats.Asn1.AsnReader asnReader, bool optional)
  {
    System.Formats.Asn1.Asn1Tag asn1Tag = asnReader.PeekTag();
    if (asn1Tag.TagValue == System.Formats.Asn1.Asn1Tag.UtcTime.TagValue)
      return asnReader.ReadUtcTime().UtcDateTime;
    if (asn1Tag.TagValue == System.Formats.Asn1.Asn1Tag.GeneralizedTime.TagValue)
      return asnReader.ReadGeneralizedTime().UtcDateTime;
    if (!optional)
      throw new AsnContentException("The CRL contains an invalid time tag.");
    return DateTime.MinValue;
  }

  private void EnsureDecoded()
  {
    if (this.m_decoded)
      return;
    this.Decode(this.RawData);
  }
}
