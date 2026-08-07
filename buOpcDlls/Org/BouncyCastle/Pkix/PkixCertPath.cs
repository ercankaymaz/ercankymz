// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPath
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixCertPath
{
  private static readonly List<string> EncodingNames = new List<string>()
  {
    "PkiPath",
    "PEM",
    "PKCS7"
  };
  private readonly IList<X509Certificate> m_certificates;

  private static IList<X509Certificate> SortCerts(IList<X509Certificate> certs)
  {
    if (certs.Count < 2)
      return certs;
    X509Name issuerDn1 = certs[0].IssuerDN;
    bool flag1 = true;
    for (int index = 1; index != certs.Count; ++index)
    {
      X509Certificate cert = certs[index];
      if (issuerDn1.Equivalent(cert.SubjectDN, true))
      {
        issuerDn1 = cert.IssuerDN;
      }
      else
      {
        flag1 = false;
        break;
      }
    }
    if (flag1)
      return certs;
    List<X509Certificate> x509CertificateList1 = new List<X509Certificate>(certs.Count);
    List<X509Certificate> x509CertificateList2 = new List<X509Certificate>((IEnumerable<X509Certificate>) certs);
    for (int index = 0; index < certs.Count; ++index)
    {
      X509Certificate cert1 = certs[index];
      bool flag2 = false;
      X509Name subjectDn = cert1.SubjectDN;
      foreach (X509Certificate cert2 in (IEnumerable<X509Certificate>) certs)
      {
        if (cert2.IssuerDN.Equivalent(subjectDn, true))
        {
          flag2 = true;
          break;
        }
      }
      if (!flag2)
      {
        x509CertificateList1.Add(cert1);
        certs.RemoveAt(index);
      }
    }
    if (x509CertificateList1.Count > 1)
      return (IList<X509Certificate>) x509CertificateList2;
    for (int index1 = 0; index1 != x509CertificateList1.Count; ++index1)
    {
      X509Name issuerDn2 = x509CertificateList1[index1].IssuerDN;
      for (int index2 = 0; index2 < certs.Count; ++index2)
      {
        X509Certificate cert = certs[index2];
        if (issuerDn2.Equivalent(cert.SubjectDN, true))
        {
          x509CertificateList1.Add(cert);
          certs.RemoveAt(index2);
          break;
        }
      }
    }
    return certs.Count > 0 ? (IList<X509Certificate>) x509CertificateList2 : (IList<X509Certificate>) x509CertificateList1;
  }

  public PkixCertPath(IList<X509Certificate> certificates)
  {
    this.m_certificates = PkixCertPath.SortCerts((IList<X509Certificate>) new List<X509Certificate>((IEnumerable<X509Certificate>) certificates));
  }

  public PkixCertPath(Stream inStream)
    : this(inStream, "PkiPath")
  {
  }

  public PkixCertPath(Stream inStream, string encoding)
  {
    IList<X509Certificate> certs;
    try
    {
      if (Platform.EqualsIgnoreCase("PkiPath", encoding))
      {
        using (Asn1InputStream asn1InputStream = new Asn1InputStream(inStream, int.MaxValue, true))
        {
          X509Certificate[] collection = asn1InputStream.ReadObject() is Asn1Sequence asn1Sequence ? asn1Sequence.MapElements<X509Certificate>((Func<Asn1Encodable, X509Certificate>) (element => new X509Certificate(X509CertificateStructure.GetInstance((object) element.ToAsn1Object())))) : throw new CertificateException("input stream does not contain a ASN1 SEQUENCE while reading PkiPath encoded data to load CertPath");
          Array.Reverse((Array) collection);
          certs = (IList<X509Certificate>) new List<X509Certificate>((IEnumerable<X509Certificate>) collection);
        }
      }
      else
      {
        if (!Platform.EqualsIgnoreCase("PEM", encoding) && !Platform.EqualsIgnoreCase("PKCS7", encoding))
          throw new CertificateException("unsupported encoding: " + encoding);
        certs = new X509CertificateParser().ReadCertificates(inStream);
      }
    }
    catch (IOException ex)
    {
      throw new CertificateException("IOException throw while decoding CertPath:\n" + ex.ToString());
    }
    this.m_certificates = PkixCertPath.SortCerts(certs);
  }

  public virtual IEnumerable<string> Encodings
  {
    get => CollectionUtilities.Proxy<string>((IEnumerable<string>) PkixCertPath.EncodingNames);
  }

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    if (!(obj is PkixCertPath pkixCertPath))
      return false;
    IList<X509Certificate> certificates1 = this.Certificates;
    IList<X509Certificate> certificates2 = pkixCertPath.Certificates;
    if (certificates1.Count != certificates2.Count)
      return false;
    IEnumerator<X509Certificate> enumerator1 = certificates1.GetEnumerator();
    IEnumerator<X509Certificate> enumerator2 = certificates2.GetEnumerator();
    while (enumerator1.MoveNext())
    {
      enumerator2.MoveNext();
      if (!object.Equals((object) enumerator1.Current, (object) enumerator2.Current))
        return false;
    }
    return true;
  }

  public override int GetHashCode() => this.m_certificates.GetHashCode();

  public virtual byte[] GetEncoded() => this.GetEncoded(PkixCertPath.EncodingNames[0]);

  public virtual byte[] GetEncoded(string encoding)
  {
    if (Platform.EqualsIgnoreCase(encoding, "PkiPath"))
    {
      Asn1EncodableVector elementVector = new Asn1EncodableVector(this.m_certificates.Count);
      for (int index = this.m_certificates.Count - 1; index >= 0; --index)
        elementVector.Add((Asn1Encodable) this.ToAsn1Object(this.m_certificates[index]));
      return this.ToDerEncoded((Asn1Encodable) new DerSequence(elementVector));
    }
    if (Platform.EqualsIgnoreCase(encoding, "PKCS7"))
    {
      ContentInfo _contentInfo = new ContentInfo(PkcsObjectIdentifiers.Data, (Asn1Encodable) null);
      Asn1EncodableVector elementVector = new Asn1EncodableVector(this.m_certificates.Count);
      foreach (X509Certificate certificate in (IEnumerable<X509Certificate>) this.m_certificates)
        elementVector.Add((Asn1Encodable) this.ToAsn1Object(certificate));
      SignedData content = new SignedData(new DerInteger(1), (Asn1Set) new DerSet(), _contentInfo, (Asn1Set) new DerSet(elementVector), (Asn1Set) null, (Asn1Set) new DerSet());
      return this.ToDerEncoded((Asn1Encodable) new ContentInfo(PkcsObjectIdentifiers.SignedData, (Asn1Encodable) content));
    }
    if (!Platform.EqualsIgnoreCase(encoding, "PEM"))
      throw new CertificateEncodingException("unsupported encoding: " + encoding);
    MemoryStream memoryStream = new MemoryStream();
    try
    {
      using (PemWriter pemWriter = new PemWriter((TextWriter) new StreamWriter((Stream) memoryStream)))
      {
        foreach (X509Certificate certificate in (IEnumerable<X509Certificate>) this.m_certificates)
          pemWriter.WriteObject((object) certificate);
      }
    }
    catch (Exception ex)
    {
      throw new CertificateEncodingException("can't encode certificate for PEM encoded path");
    }
    return memoryStream.ToArray();
  }

  public virtual IList<X509Certificate> Certificates
  {
    get => CollectionUtilities.ReadOnly<X509Certificate>(this.m_certificates);
  }

  private Asn1Object ToAsn1Object(X509Certificate cert)
  {
    try
    {
      return cert.CertificateStructure.ToAsn1Object();
    }
    catch (Exception ex)
    {
      throw new CertificateEncodingException("Exception while encoding certificate", ex);
    }
  }

  private byte[] ToDerEncoded(Asn1Encodable obj)
  {
    try
    {
      return obj.GetEncoded("DER");
    }
    catch (IOException ex)
    {
      throw new CertificateEncodingException("Exception thrown", (Exception) ex);
    }
  }
}
