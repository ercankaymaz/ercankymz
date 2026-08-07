// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509CertificateParser
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

public class X509CertificateParser
{
  private static readonly PemParser PemCertParser = new PemParser("CERTIFICATE");
  private Asn1Set sData;
  private int sDataObjectCount;
  private Stream currentStream;

  private X509Certificate ReadDerCertificate(Asn1InputStream dIn)
  {
    Asn1Sequence asn1Sequence = (Asn1Sequence) dIn.ReadObject();
    if (asn1Sequence.Count <= 1 || !(asn1Sequence[0] is DerObjectIdentifier) || !asn1Sequence[0].Equals((object) PkcsObjectIdentifiers.SignedData))
      return new X509Certificate(X509CertificateStructure.GetInstance((object) asn1Sequence));
    this.sData = SignedData.GetInstance((object) Asn1Sequence.GetInstance((Asn1TaggedObject) asn1Sequence[1], true)).Certificates;
    return this.GetCertificate();
  }

  private X509Certificate ReadPemCertificate(Stream inStream)
  {
    Asn1Sequence asn1Sequence = X509CertificateParser.PemCertParser.ReadPemObject(inStream);
    return asn1Sequence != null ? new X509Certificate(X509CertificateStructure.GetInstance((object) asn1Sequence)) : (X509Certificate) null;
  }

  private X509Certificate GetCertificate()
  {
    if (this.sData != null)
    {
      while (this.sDataObjectCount < this.sData.Count)
      {
        object obj = (object) this.sData[this.sDataObjectCount++];
        if (obj is Asn1Sequence)
          return new X509Certificate(X509CertificateStructure.GetInstance(obj));
      }
    }
    return (X509Certificate) null;
  }

  public X509Certificate ReadCertificate(byte[] input)
  {
    return this.ReadCertificate((Stream) new MemoryStream(input, false));
  }

  public IList<X509Certificate> ReadCertificates(byte[] input)
  {
    return this.ReadCertificates((Stream) new MemoryStream(input, false));
  }

  public X509Certificate ReadCertificate(Stream inStream)
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
        return (X509Certificate) null;
      }
      int b = inStream.ReadByte();
      if (b < 0)
        return (X509Certificate) null;
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
      if (b != 48 /*0x30*/)
        return this.ReadPemCertificate(inStream);
      using (Asn1InputStream dIn = new Asn1InputStream(inStream, int.MaxValue, true))
        return this.ReadDerCertificate(dIn);
    }
    catch (CertificateException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new CertificateException("Failed to read certificate", ex);
    }
  }

  public IList<X509Certificate> ReadCertificates(Stream inStream)
  {
    return (IList<X509Certificate>) new List<X509Certificate>(this.ParseCertificates(inStream));
  }

  public IEnumerable<X509Certificate> ParseCertificates(Stream inStream)
  {
    X509Certificate certificate;
    while ((certificate = this.ReadCertificate(inStream)) != null)
      yield return certificate;
  }
}
