// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509CertPairParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509CertPairParser
{
  private Stream currentStream;

  private X509CertificatePair ReadDerCrossCertificatePair(Stream inStream)
  {
    using (Asn1InputStream asn1InputStream = new Asn1InputStream(inStream, int.MaxValue, true))
      return new X509CertificatePair(CertificatePair.GetInstance((object) asn1InputStream.ReadObject()));
  }

  public X509CertificatePair ReadCertPair(byte[] input)
  {
    return this.ReadCertPair((Stream) new MemoryStream(input, false));
  }

  public IList<X509CertificatePair> ReadCertPairs(byte[] input)
  {
    return this.ReadCertPairs((Stream) new MemoryStream(input, false));
  }

  public X509CertificatePair ReadCertPair(Stream inStream)
  {
    if (inStream == null)
      throw new ArgumentNullException(nameof (inStream));
    if (!inStream.CanRead)
      throw new ArgumentException("inStream must be read-able", nameof (inStream));
    if (this.currentStream == null)
      this.currentStream = inStream;
    else if (this.currentStream != inStream)
      this.currentStream = inStream;
    try
    {
      int b = inStream.ReadByte();
      if (b < 0)
        return (X509CertificatePair) null;
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
      return this.ReadDerCrossCertificatePair(inStream);
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

  public IList<X509CertificatePair> ReadCertPairs(Stream inStream)
  {
    List<X509CertificatePair> x509CertificatePairList = new List<X509CertificatePair>();
    X509CertificatePair x509CertificatePair;
    while ((x509CertificatePair = this.ReadCertPair(inStream)) != null)
      x509CertificatePairList.Add(x509CertificatePair);
    return (IList<X509CertificatePair>) x509CertificatePairList;
  }
}
