// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509AttrCertParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509AttrCertParser
{
  private static readonly PemParser PemAttrCertParser = new PemParser("ATTRIBUTE CERTIFICATE");
  private Asn1Set sData;
  private int sDataObjectCount;
  private Stream currentStream;

  private X509V2AttributeCertificate ReadDerCertificate(Asn1InputStream dIn)
  {
    Asn1Sequence asn1Sequence = (Asn1Sequence) dIn.ReadObject();
    if (asn1Sequence.Count <= 1 || !(asn1Sequence[0] is DerObjectIdentifier) || !asn1Sequence[0].Equals((object) PkcsObjectIdentifiers.SignedData))
      return new X509V2AttributeCertificate(AttributeCertificate.GetInstance((object) asn1Sequence));
    this.sData = SignedData.GetInstance((object) Asn1Sequence.GetInstance((Asn1TaggedObject) asn1Sequence[1], true)).Certificates;
    return this.GetCertificate();
  }

  private X509V2AttributeCertificate GetCertificate()
  {
    if (this.sData != null)
    {
      while (this.sDataObjectCount < this.sData.Count)
      {
        if (this.sData[this.sDataObjectCount++].ToAsn1Object() is Asn1TaggedObject asn1Object && asn1Object.TagNo == 2)
          return new X509V2AttributeCertificate(AttributeCertificate.GetInstance((object) Asn1Sequence.GetInstance(asn1Object, false)));
      }
    }
    return (X509V2AttributeCertificate) null;
  }

  private X509V2AttributeCertificate ReadPemCertificate(Stream inStream)
  {
    Asn1Sequence asn1Sequence = X509AttrCertParser.PemAttrCertParser.ReadPemObject(inStream);
    return asn1Sequence != null ? new X509V2AttributeCertificate(AttributeCertificate.GetInstance((object) asn1Sequence)) : (X509V2AttributeCertificate) null;
  }

  public X509V2AttributeCertificate ReadAttrCert(byte[] input)
  {
    return this.ReadAttrCert((Stream) new MemoryStream(input, false));
  }

  public IList<X509V2AttributeCertificate> ReadAttrCerts(byte[] input)
  {
    return this.ReadAttrCerts((Stream) new MemoryStream(input, false));
  }

  public X509V2AttributeCertificate ReadAttrCert(Stream inStream)
  {
    if (inStream == null)
      throw new ArgumentNullException(nameof (inStream));
    if (!inStream.CanRead)
      throw new ArgumentException("inStream must be read-able", nameof (inStream));
    if (this.currentStream == null)
    {
      this.currentStream = inStream;
      this.sData = (Asn1Set) null;
      this.sDataObjectCount = 0;
    }
    else if (this.currentStream != inStream)
    {
      this.currentStream = inStream;
      this.sData = (Asn1Set) null;
      this.sDataObjectCount = 0;
    }
    try
    {
      if (this.sData != null)
      {
        if (this.sDataObjectCount != this.sData.Count)
          return this.GetCertificate();
        this.sData = (Asn1Set) null;
        this.sDataObjectCount = 0;
        return (X509V2AttributeCertificate) null;
      }
      int b = inStream.ReadByte();
      if (b < 0)
        return (X509V2AttributeCertificate) null;
      if (inStream.CanSeek)
      {
        inStream.Seek(-1L, SeekOrigin.Current);
      }
      else
      {
        PushbackStream pushbackStream = new PushbackStream(inStream);
        pushbackStream.Unread(b);
        inStream = (Stream) pushbackStream;
      }
      return b != 48 /*0x30*/ ? this.ReadPemCertificate(inStream) : this.ReadDerCertificate(new Asn1InputStream(inStream));
    }
    catch (CertificateException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new CertificateException(ex.ToString());
    }
  }

  public IList<X509V2AttributeCertificate> ReadAttrCerts(Stream inStream)
  {
    List<X509V2AttributeCertificate> attributeCertificateList = new List<X509V2AttributeCertificate>();
    X509V2AttributeCertificate attributeCertificate;
    while ((attributeCertificate = this.ReadAttrCert(inStream)) != null)
      attributeCertificateList.Add(attributeCertificate);
    return (IList<X509V2AttributeCertificate>) attributeCertificateList;
  }
}
